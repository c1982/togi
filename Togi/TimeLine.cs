using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TogiApi;
using TimeLineControl;
using System.Threading;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace Togi
{
    public partial class TimeLine : Form
    {
        static private User TwitterUser;
        
        public IList<TweetItem> FriendsTimeLine { get; set; }
        public IList<TweetItem> RepliesTimeLine { get; set; }
        public IList<TweetItem> MessagesTimeLine { get; set; }
        
        private bool mouse_is_down;
        private Point mouse_pos;
        private ResourceManager dil_;
        private CultureInfo cInfo_;
        private byte NoticePadding;

        private delegate void SetFavoriteIcon(bool isFavorite);
        private delegate void del_OpenNoticeForm(Tweet t);
        private delegate void SetTextToolStripButtons(ToolStripButton ts, int Count_);
        private delegate void SetTextStatusMesage(string text_);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,           // window handle
             int hWndInsertAfter,    // placement-order handle
             int X,          // horizontal position
             int Y,          // vertical position
             int cx,         // width
             int cy,         // height
             uint uFlags);       // window positioning flags

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const int WM_HOTKEY = 0x0312;

        #region Construct

        public TimeLine()
        {            
            InitializeComponent();

            string CultureName = Regedit.GetKey_("language");

            cInfo_ = new CultureInfo(String.IsNullOrEmpty(CultureName) ? 
                "en-US":
                CultureName);

            Thread.CurrentThread.CurrentUICulture = cInfo_;
            
            dil_ = new ResourceManager("Togi.Lang.Language",
                Assembly.GetExecutingAssembly());

            // Başlangıçta çalıştır
            if(Regedit.GetKey_("run").Equals("true"))
                Regedit.SetRun();

            LanguageCtor();
            TableCtor();
            MenuCtor();

            // Togi is Offline;
            TogiNotify.Icon = Properties.Resources.favicon_offline;
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {
            LoginIn(false);
        }

        private void LoginIn(bool ChangeUser)
        {
            // Login Prosedürü.
            using (Login lgn = new Login(ChangeUser))
            {
                if (lgn.ShowDialog() == DialogResult.OK)
                {
                    // Veriler sıfırlanıyor.
                    FriendsTimeLine = null;
                    RepliesTimeLine = null;
                    MessagesTimeLine = null;

                    // Veriler yükleniyor.
                    TwitterUser = lgn.LoginUser;
                    FriendsTimeLine = lgn.FriendsTimeLine;

                    AddEvents(FriendsTimeLine);

                    lScreenName.Text = String.Format("{0} ({1})",
                        TwitterUser.Name,
                        TwitterUser.ScreenName);

                    // Togi is Online;
                    TogiNotify.Icon = Properties.Resources.favicon_online;

                    // WndProc'u çalıştırır.
                    Tools.HandleKeys.RegisterRecordKey(this.Handle);

                    // Check Schedule
                    SetZamanTimer();
                }
                else
                {
                    if (lgn.DialogResult == DialogResult.Abort)
                            Application.Exit();
                }
            }

            // TimeLine yükleniyor.
            if (FriendsTimeLine != null)
            {
                FillTableTweet(FriendsTimeLine);

                // Okunmayanların Sayısı
                SetTweetNumber(tsRecents, GetUnreadItem(FriendsTimeLine));
            }

            //Replies ve Messages
            if (TwitterUser != null)
            {
                Thread get_tweets = new Thread(new ThreadStart(LoadRepliesAndMessages));
                get_tweets.SetApartmentState(ApartmentState.STA);
                get_tweets.Start();
            }
        }

        private void TableCtor()
        {
            Padding p = Tablo.Padding;
            Tablo.Padding = new Padding(p.Left, p.Top - 10,
                SystemInformation.VerticalScrollBarWidth - 15, p.Bottom - 15);

            Tablo.RowStyles.Clear();
            this.Tablo.Focus();
        }

        private void MenuCtor()
        {
            string ShowNotice = Regedit.GetKey_("check_notice");
            string CheckTweets = Regedit.GetKey_("check_tweets");
            string CheckShortUrl = Regedit.GetKey_("check_shorturl");

            tsShowNotice.Checked = String.IsNullOrEmpty(ShowNotice) ? true : 
                bool.Parse(ShowNotice);

            tsCheckTweets.Checked = String.IsNullOrEmpty(CheckTweets) ? true :
                bool.Parse(CheckTweets);

            tsShorgUrl.Checked = String.IsNullOrEmpty(CheckShortUrl) ? true :
                bool.Parse(CheckShortUrl);
        }

        private int GetUnreadItem(IList<TweetItem> liste_)
        {
            if (liste_ == null)
                return 0;

            int UnreadItem = 0;
            lock (liste_)
            {
                foreach (TweetItem item in liste_)
                {
                    if (item.ItemTweet.isRead == false)
                        UnreadItem++;
                }
            }

            return UnreadItem;
        }

        private void LoadRepliesAndMessages()
        {
            using (Tools.CheckTweets get_tweets = new Togi.Tools.CheckTweets(TwitterUser))
            {
                RepliesTimeLine = get_tweets.CheckRepliesFirsTime();
                AddEvents(RepliesTimeLine);
                SetTweetNumber(tsReplys, GetUnreadItem(RepliesTimeLine));

                MessagesTimeLine = get_tweets.CheckMessagesFirsTime();
                AddEvents(MessagesTimeLine);
                SetTweetNumber(tsMessages, GetUnreadItem(MessagesTimeLine));
            }
        }

        private void ReadAllItems()
        {
            if(FriendsTimeLine != null)
                MarkAsReadItem(FriendsTimeLine);

            if(RepliesTimeLine != null)
                MarkAsReadItem(RepliesTimeLine);

            if(MessagesTimeLine != null)
                MarkAsReadItem(MessagesTimeLine);

            SetTweetNumber(tsReplys, 0);
            SetTweetNumber(tsRecents, 0);
            SetTweetNumber(tsMessages, 0);

            SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_3", cInfo_));                                 
        }


        private void MarkAsReadItem(IList<TweetItem> liste_)
        {
            lock (liste_)
            {
                foreach (TweetItem item in liste_)
                {
                    item.IsRead = true;
                }
            }
        }

        private void ShowFavorites()
        {
            IList<TweetItem> favorites_ = new List<TweetItem>();

            if(FriendsTimeLine !=null)
                AddFavorites(FriendsTimeLine, favorites_);

            if(RepliesTimeLine !=null)
                AddFavorites(RepliesTimeLine, favorites_);

            if (favorites_ != null && favorites_.Count > 0)
            {
                FillTableTweet(favorites_);

                SetStatusMsg(String.Format(dil_.GetString("TIME_LINE_MESAJ_1_1", cInfo_),
                    favorites_.Count));
            }
            else
            { 
                SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_2", cInfo_)); 
            }

        }

        private void AddFavorites(IList<TweetItem> source_, IList<TweetItem> destination_)
        {
            if (source_ == null)
                return;

            lock (source_)
            {
                foreach (TweetItem item in source_)
                {
                    if (item.ItemTweet.isFavorite)
                        destination_.Add(item);
                }
            }
        }

        private void ShowUnreadItems()
        {
            IList<TweetItem> unreads_ = new List<TweetItem>();
            AddUnreadItems(FriendsTimeLine, unreads_);
            AddUnreadItems(RepliesTimeLine, unreads_);
            AddUnreadItems(MessagesTimeLine, unreads_);

            if (unreads_ != null && unreads_.Count > 0)
            {
                FillTableTweet(unreads_);

                SetStatusMsg(String.Format(dil_.GetString("TIME_LINE_MESAJ_3_1", cInfo_),
                    unreads_.Count));
            }
            else
            { SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_1", cInfo_)); }
        }

        private void AddUnreadItems(IList<TweetItem> source_, IList<TweetItem> destination_)
        {
            if (source_ == null)
                return;

            lock (source_)
            {
                foreach (TweetItem item in source_)
                {
                    if (!item.ItemTweet.isRead)
                        destination_.Add(item);
                }
            }
        }

        private void FillTableTweet(IList<TweetItem> TweetList)
        {
            if (TweetList == null)
                return;

            int TableRowIndex = 0;
            Tablo.RowCount = 0;
            Tablo.Visible = false;
            Tablo.Controls.Clear();
            Tablo.RowStyles.Clear();

            lock (TweetList)
            {
                IList<TweetItem> tmpList = TweetList;

                if (TweetList != null)
                {
                    foreach (TweetItem item in tmpList)
                    {
                        //if (!item.IsDisposed)
                        //{
                        item.Dock = DockStyle.Top;                        
                        Tablo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        Tablo.Controls.Add(item, 1, TableRowIndex);
                        TableRowIndex++;
                        //}
                    }
                }
            }

            Tablo.Visible = true;
            Tablo.Focus();
        }

        private void SetZamanTimer()
        {
            string IntTimeString = Regedit.GetKey_("check_time");
            int IntTime = String.IsNullOrEmpty(IntTimeString) ? 3 : int.Parse(IntTimeString);
            IntTime = (IntTime * 60) * 1000;

            Zaman.Enabled = true;
            Zaman.Interval = IntTime;
            Zaman.Start();
        }

        private void LanguageCtor()
        {            
            //Set controls value from resource file;
            lTools.Text = dil_.GetString("TIME_LINE_TOOLS");
            tsRecents.ToolTipText = dil_.GetString("TIME_LINE_RECENTS_BUTTON");
            tsReplys.ToolTipText = dil_.GetString("TIME_LINE_REPLIES_BUTTON");
            tsMessages.ToolTipText = dil_.GetString("TIME_LINE_MESSAGES_BUTTON");
            tsSettings.ToolTipText = dil_.GetString("TIME_LINE_MENU_1");

            tsStatus.Text = dil_.GetString("TIME_LINE_STATUS_TEXT_DEFAULT");
            
            tsCheckNewVersion.Text = dil_.GetString("TIME_LINE_MENU_6");            
            tsChangeUser.Text = dil_.GetString("TIME_LINE_MENU_5");
            tsCheckTweets.Text = dil_.GetString("TIME_LINE_MENU_4");
            tsShorgUrl.Text = dil_.GetString("TIME_LINE_MENU_3");
            tsShowNotice.Text = dil_.GetString("TIME_LINE_MENU_2");
            tsAdvanced.Text = dil_.GetString("TIME_LINE_MENU_1");

            tsShowFavorites.Text = dil_.GetString("TIME_LINE_TOOLS_MENU_1");
            tsUnreads.Text = dil_.GetString("TIME_LINE_TOOLS_MENU_2");
            tsReadAll.Text = dil_.GetString("TIME_LINE_TOOLS_MENU_3");

            tsExit.Text = dil_.GetString("TIME_LINE_NOTIFY_MENU_1");
            tsShow.Text = dil_.GetString("TIME_LINE_NOTIFY_MENU_2");
            tsChangeUserNow.Text = dil_.GetString("TIME_LINE_MENU_5");
            tsCheckTweetsNow.Text = dil_.GetString("TIME_LINE_MENU_4");

            this.Refresh();

        }

        #endregion

        #region Events

        private void TogiNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void tsUnreads_Click(object sender, EventArgs e)
        {
            ShowUnreadItems();
        }

        private void tsShowFavorites_Click(object sender, EventArgs e)
        {
            ShowFavorites();
        }

        private void lTools_MouseDown(object sender, MouseEventArgs e)
        {
            ToolsMenu.Show((Label)sender, new Point(e.X, e.Y));
        }

        private void tsReadAll_Click(object sender, EventArgs e)
        {
            ReadAllItems();
        }

        private void lClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tsAdvanced_Click(object sender, EventArgs e)
        {
            using (SettingsForm s = new SettingsForm())
            {
                s.ShowDialog();
                s.Dispose();
            }

            //Refresh culture Info
            string CultureName = Regedit.GetKey_("language");
            cInfo_ = new CultureInfo(String.IsNullOrEmpty(CultureName) ?
                "en-US" :
                CultureName);

            LanguageCtor();
        }

        private void tsRecents_Click(object sender, EventArgs e)
        {            
            FillTableTweet(FriendsTimeLine);
        }

        private void tsReplys_Click(object sender, EventArgs e)
        {            
            FillTableTweet(RepliesTimeLine);
        }

        private void tsMessages_Click(object sender, EventArgs e)
        {
            FillTableTweet(MessagesTimeLine);
        }

        private void tsShowNotice_CheckedChanged(object sender, EventArgs e)
        {
            Regedit.SetKey_("check_notice", tsShowNotice.Checked ? "true" : "false");
        }

        private void tsShorgUrl_CheckedChanged(object sender, EventArgs e)
        {
            Regedit.SetKey_("check_shorturl", tsShorgUrl.Checked ? "true" : "false");
        }

        private void tsCheckTweets_CheckedChanged(object sender, EventArgs e)
        {
            Regedit.SetKey_("check_tweets", tsCheckTweets.Checked ? "true" : "false");
        }

        // CTRL + ALT + ENTER Event
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_HOTKEY:
                    ButtonPressed(msg.WParam.ToInt32());
                    return;
            }

            base.WndProc(ref msg);
        }

        private void ButtonPressed(int button)
        {
            OpenUpdateForm();
        }

        private void OpenUpdateForm()
        {
            if (Application.OpenForms["Dialog"] != null)
            {
                Application.OpenForms["Dialog"].Show();
            }
            else
            {
                Dialog dForm = new Dialog(TwitterUser);
                dForm.ShowDialog();
                dForm.Dispose();
            }
        }      

        private void Zaman_Tick(object sender, EventArgs e)
        {
            Thread tCheck = new Thread(new ThreadStart(CheckNewTweets));
            tCheck.SetApartmentState(ApartmentState.STA);
            tCheck.Start();
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsShow_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void tsChangeUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(dil_.GetString("TIME_LINE_MESAJ_11", cInfo_), "Togi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginIn(true);
            }
        }

        private void TimeLine_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_pos.X = e.X;
            this.mouse_pos.Y = e.Y;
            this.mouse_is_down = true;
        }

        private void TimeLine_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouse_is_down)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.X -= this.mouse_pos.X;
                mousePosition.Y -= this.mouse_pos.Y;
                base.Location = mousePosition;
            }
        }

        private void TimeLine_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouse_is_down = false;
        }

        private void Tablo_ControlAdded(object sender, ControlEventArgs e)
        {
            // Saniye yenileniyor.
            TweetItem ti = (TweetItem)e.Control;
            ti.lTime.Text = String.Format(dil_.GetString("ITEM_MENU_8", cInfo_),
                ToRelativeDate(ti.ItemTweet.CreateAt),
                ti.ItemTweet.Source);
        }

        #endregion

        #region CheckNewTweets

        private void SetStatusMsg(string text_)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetTextStatusMesage(SetStatusMsg), new object[] { text_ });
                return;
            }

            tsStatus.Text = text_;
        }

        private void CheckNewTweets()
        {
            using (Tools.CheckTweets chck = new Togi.Tools.CheckTweets(TwitterUser))
            {
                SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_4", cInfo_));
                AddNewTweetInList(chck.CheckTimeLine(), Tweet.TweetTypes.Normal);
                SetTweetNumber(tsRecents, GetUnreadItem(FriendsTimeLine));

                SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_5", cInfo_));
                AddNewTweetInList(chck.CheckReplies(), Tweet.TweetTypes.Reply);
                SetTweetNumber(tsReplys, GetUnreadItem(RepliesTimeLine));

                SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_6", cInfo_));
                AddNewTweetInList(chck.CheckMessages(), Tweet.TweetTypes.Message);
                SetTweetNumber(tsMessages, GetUnreadItem(MessagesTimeLine));
            }

            SetStatusMsg(String.Format(dil_.GetString("TIME_LINE_MESAJ_7", cInfo_), 
                DateTime.Now.ToShortTimeString()));                        
        }

        private void AddNewTweetInList(IList<TweetItem> tList_, 
            Tweet.TweetTypes tip)
        {
            NoticePadding = 0;
            string ShotNoticeStr_ = Regedit.GetKey_("check_notice");
            bool ShowNotice = String.IsNullOrEmpty(ShotNoticeStr_) ? true : 
                bool.Parse(ShotNoticeStr_);

            IList<TweetItem> tList = tList_;
            
            lock (this)
            {
                if (tList != null)
                {                    
                    foreach (TweetItem item in tList)
                    {
                        if (item != null)
                        {
                            // Olaylar yükleniyor
                            AddEventsTweetItem(item);

                            switch (tip)
                            {
                                case Tweet.TweetTypes.Normal:

                                    if(FriendsTimeLine != null)
                                        FriendsTimeLine.Insert(0, item);

                                    break;
                                case Tweet.TweetTypes.Reply:

                                    if(RepliesTimeLine != null)
                                        RepliesTimeLine.Insert(0, item);

                                    break;
                                case Tweet.TweetTypes.Message:

                                    if(MessagesTimeLine != null)
                                        MessagesTimeLine.Insert(0, item);

                                    break;
                                default:
                                    break;
                            }

                            // Show Notice
                            if (ShowNotice)
                            {
                                OpenNoticeForm(item.ItemTweet);                                
                            }
                        }
                    }
                }
            }
        }
        
        private void SetTweetNumber(ToolStripButton ts, int Count_)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetTextToolStripButtons(SetTweetNumber), new object[]{ts, Count_});
                return;
            }

            ts.Text = Count_.Equals(0) ? String.Empty : Count_.ToString();
        }

        private void OpenNoticeForm(Tweet t)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new del_OpenNoticeForm(OpenNoticeForm), new object[] { t});
                return;
            }

            string lTimeCaption = String.Format(dil_.GetString("ITEM_MENU_8", cInfo_),
                ToRelativeDate(t.CreateAt),
                t.Source);

            Notification n = new Notification(t, lTimeCaption);

            ShowWindow(n.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(n.Handle.ToInt32(), HWND_TOPMOST,
            (Screen.PrimaryScreen.WorkingArea.Width - n.Width)-5,
            (Screen.PrimaryScreen.WorkingArea.Height - n.Height) - NoticePadding, 
            n.Width, n.Height,
            SWP_NOACTIVATE);

            NoticePadding += 64;
        }

        #endregion

        #region TweetItemEvents

        private void AddEvents(IList<TweetItem> liste_)
        {
            lock (liste_)
            {
                foreach (TweetItem item in liste_)
                {
                    AddEventsTweetItem(item);                    
                }
            }
        }

        private void AddEventsTweetItem(TweetItem item)
        {
            
            item.tsReply.Click += new EventHandler(tsReply_Click);
            item.tsFavorite.Click += new EventHandler(tsFavorite_Click);
            item.tsReTweet.Click += new EventHandler(tsReTweet_Click);
            item.tsMessage.Click += new EventHandler(tsMessage_Click);

            // TweetType'ı denetleniyor.
            item.TweetTypeSec_ += new TweetItem.SetTweetType(item_TweetTypeSec_);
            item_TweetTypeSec_(item, new EventArgs());

            item.tsDelete.Click += new EventHandler(tsDelete_Click);

            //Silinebilirliği denetleniyor.
            item.TweetAllowDelete_ += new TweetItem.AllowDelete(item_TweetAllowDelete_);
            item_TweetAllowDelete_(item, new EventArgs());
            
            //Okundu.
            item.TweetText.Click += new EventHandler(TweetText_Click);

            //Info
            item.tsUserInfo.Click += new EventHandler(tsUserInfo_Click);

            //Okunduğu zaman
            item.SetRead_ += new TweetItem.dSetRead(item_SetRead_);
        }

        void item_SetRead_(object sender, EventArgs e)
        {
            TweetItem ti = (TweetItem)sender;
            ti.SetBackColorDefault(ti.ItemTweet.TweetType);            
        }

        void tsUserInfo_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu_ = (ToolStripMenuItem)sender;
            if (menu_.Tag != null)
            {
                TweetItem ti = GetTweetItemById(menu_.Tag.ToString());
                if (ti != null)
                {
                    using (Info fo = new Info(ti.ItemTweet.UserScreenName))
                    {
                        fo.ShowDialog();
                        fo.Dispose();
                    }
                }
            }
        }

        void TweetText_Click(object sender, EventArgs e)
        {
            LinkLabel link_ = (LinkLabel)sender;
            if (link_.Tag != null)
            {
                TweetItem ti = GetTweetItemById(link_.Tag.ToString());
                if (ti != null)
                {
                    ti.Focus();

                    // Okundu;
                    ti.IsRead = true;
                    ti.SetBackColorDefault(ti.ItemTweet.TweetType);

                    // Buton sayıları güncelleniyor.
                    RefreshReadItem(ti.ItemTweet.TweetType);

                    //FriendsTimeLine'da Replies olanlar.
                    if (ti.ItemTweet.TweetType == Tweet.TweetTypes.Reply)
                    {
                        TweetItem sub_ti = GetTweetItemByIdPrivate(link_.Tag.ToString());
                        if (sub_ti != null)
                        {
                            sub_ti.IsRead= true;                            
                            RefreshReadItem(Tweet.TweetTypes.Normal);
                        }                        
                    }
                }
            }
        }

        void item_TweetAllowDelete_(object sender, EventArgs e)
        {
            TweetItem ti = (TweetItem)sender;
            if (ti != null)
            {
                if (ti.ItemTweet.UserScreenName.Equals(TwitterUser.ScreenName))
                    ti.tsDelete.Enabled = true;
            }
        }

        void tsDelete_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu_ = (ToolStripMenuItem)sender;
            if (menu_.Tag != null)
            {
                TweetItem ti = GetTweetItemById(menu_.Tag.ToString());
                if (ti != null)
                {
                    if (ti.ItemTweet.TweetType == Tweet.TweetTypes.Deleted)
                        return;

                    ParameterizedThreadStart DestroyAction = ti.ItemTweet.TweetType == Tweet.TweetTypes.Message ?
                        new ParameterizedThreadStart(DestroyMessages) :
                        new ParameterizedThreadStart(DestroyStatus);

                    Thread th = new Thread(new ParameterizedThreadStart(DestroyAction));
                    th.SetApartmentState(ApartmentState.STA);
                    th.IsBackground = true;
                    th.Start(menu_.Tag);
                }
            }
        }

        void item_TweetTypeSec_(object sender, EventArgs e)
        {
            TweetItem ti = (TweetItem)sender;
            if (ti != null)
            {
                if(ti.ItemTweet.TweetType != Tweet.TweetTypes.Message)
                    if (ti.ItemTweet.ReplyScreenName.Equals(TwitterUser.ScreenName))
                        ti.ItemTweet.TweetType = Tweet.TweetTypes.Reply;

                TweetItemLanguageCtor(ti);
            }
        }

        void TweetItemLanguageCtor(TweetItem ti)
        {
            ti.tsReply.Text = dil_.GetString("ITEM_MENU_1", cInfo_);
            ti.tsReTweet.Text = dil_.GetString("ITEM_MENU_2", cInfo_);
            ti.tsMessage.Text = dil_.GetString("ITEM_MENU_3", cInfo_);        
            ti.SetMenuText(ti.tsFavorite, dil_.GetString(ti.ItemTweet.isFavorite ? "ITEM_MENU_5" : "ITEM_MENU_4", cInfo_));
            ti.tsDelete.Text = dil_.GetString("ITEM_MENU_6", cInfo_);
            ti.tsUserInfo.Text = dil_.GetString("ITEM_MENU_7", cInfo_);

            ti.lTime.Text = String.Format(dil_.GetString("ITEM_MENU_8",cInfo_),
                ToRelativeDate(ti.ItemTweet.CreateAt),
                ti.ItemTweet.Source);
            
        }

        void tsMessage_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu_ = (ToolStripMenuItem)sender;
            if (menu_.Tag != null)
            {
                TweetItem ti = GetTweetItemById(menu_.Tag.ToString());
                if (ti != null)
                {
                    Dialog d = new Dialog(TwitterUser, ti.ItemTweet);
                    d.ShowDialog("messages");
                    d.Dispose();
                }
            }
        }

        void tsReTweet_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu_ = (ToolStripMenuItem)sender;
            if (menu_.Tag != null)
            {
                TweetItem ti = GetTweetItemById(menu_.Tag.ToString());
                if (ti != null)
                {
                    Dialog d = new Dialog(TwitterUser, ti.ItemTweet);
                    d.ShowDialog("retweet");
                    d.Dispose();
                }
            }
        }

        void tsReply_Click(object sender, EventArgs e)
        {            
            ToolStripMenuItem menu_ = (ToolStripMenuItem)sender;
            if (menu_.Tag != null)
            {
                TweetItem ti = GetTweetItemById(menu_.Tag.ToString());
                if (ti != null)
                {
                    Dialog d = new Dialog(TwitterUser, ti.ItemTweet);
                    d.ShowDialog("reply");
                    d.Dispose();
                }
            }
        }

        void tsFavorite_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu_ = (ToolStripMenuItem)sender;
            if (menu_.Tag != null)
            {
                TweetItem ti = GetTweetItemById(menu_.Tag.ToString());
                if (ti != null)
                {
                    ParameterizedThreadStart FavoriteAction = ti.ItemTweet.isFavorite ? 
                        new ParameterizedThreadStart(DestroyFavorite) :
                        new ParameterizedThreadStart(CreateFavorite);

                    Thread th = new Thread(new ParameterizedThreadStart(FavoriteAction));
                    th.SetApartmentState(ApartmentState.STA);
                    th.IsBackground = true;
                    th.Start(menu_.Tag);
                }
            }
        }

        private void RefreshReadItem(Tweet.TweetTypes tip)
        {
            switch (tip)
            {
                case Tweet.TweetTypes.Normal:
                    SetTweetNumber(tsRecents, GetUnreadItem(FriendsTimeLine));
                    break;
                case Tweet.TweetTypes.Reply:
                    SetTweetNumber(tsReplys, GetUnreadItem(RepliesTimeLine));
                    break;
                case Tweet.TweetTypes.Message:
                    SetTweetNumber(tsMessages, GetUnreadItem(MessagesTimeLine));
                    break;
                case Tweet.TweetTypes.Deleted:
                    break;
                default:
                    break;
            }
        }

        private void SetFavoriteById(string TweetId, bool isFavorite)
        {
            if (FriendsTimeLine != null)
            {
                lock (FriendsTimeLine)
                {
                    foreach (TweetItem item in FriendsTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            item.ItemTweet.isFavorite = isFavorite;
                            item.ShowFavoriteIcon(isFavorite);

                            item.SetMenuText(item.tsFavorite,
                                dil_.GetString(isFavorite ? "ITEM_MENU_5" : "ITEM_MENU_4", cInfo_));

                            return;
                        }
                    }
                }
            }

            if (RepliesTimeLine != null)
            {
                lock (RepliesTimeLine)
                {
                    foreach (TweetItem item in RepliesTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            item.ItemTweet.isFavorite = isFavorite;
                            item.ShowFavoriteIcon(isFavorite);

                            item.SetMenuText(item.tsFavorite, 
                                dil_.GetString(isFavorite ? "ITEM_MENU_5" : "ITEM_MENU_4", cInfo_));

                            return;
                        }
                    }
                }
            }
        }

        private void SetDestroyById(string TweetId)
        {
            if (FriendsTimeLine != null)
            {
                lock (FriendsTimeLine)
                {
                    foreach (TweetItem item in FriendsTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            item.ItemTweet.TweetType = Tweet.TweetTypes.Deleted;

                            //Silindiği zaman arka planı grip yapan olay.
                            item.SetBackColorDefault(Tweet.TweetTypes.Deleted);
                            item.SetDeletedStatusText();
                            return;
                        }
                    }
                }
            }

            if (RepliesTimeLine != null)
            {
                lock (RepliesTimeLine)
                {
                    foreach (TweetItem item in RepliesTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            item.ItemTweet.TweetType = Tweet.TweetTypes.Deleted;

                            //Silindiği zaman arka planı grip yapan olay.
                            item.SetBackColorDefault(Tweet.TweetTypes.Deleted);
                            item.SetDeletedStatusText();
                            return;
                        }
                    }
                }
            }

            if (MessagesTimeLine != null)
            {
                lock (MessagesTimeLine)
                {
                    foreach (TweetItem item in MessagesTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            item.ItemTweet.TweetType = Tweet.TweetTypes.Deleted;

                            //Silindiği zaman arka planı grip yapan olay.
                            item.SetBackColorDefault(Tweet.TweetTypes.Deleted);
                            item.SetDeletedStatusText();
                            return;
                        }
                    }
                }
            }
        }

        private TweetItem GetTweetItemByIdPrivate(string TweetId)
        {
            TweetItem ti = null;

            if (FriendsTimeLine != null)
            {
                lock (FriendsTimeLine)
                {
                    foreach (TweetItem item in FriendsTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            ti = item;
                            break;
                        }
                    }
                }
            }
            return ti;
        }

        private TweetItem GetTweetItemById(string TweetId)
        {
            TweetItem ti = null;

            if (FriendsTimeLine != null)
            {
                lock (FriendsTimeLine)
                {
                    foreach (TweetItem item in FriendsTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            ti = item;
                            break;
                        }
                    }
                }
            }

            if (RepliesTimeLine != null)
            {
                lock (RepliesTimeLine)
                {

                    foreach (TweetItem item in RepliesTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            ti = item;
                            break;
                        }
                    }
                }
            }

            if (MessagesTimeLine != null)
            {
                lock (MessagesTimeLine)
                {
                    foreach (TweetItem item in MessagesTimeLine)
                    {
                        if (item.ItemTweet.Id.Equals(TweetId))
                        {
                            ti = item;
                            break;
                        }
                    }
                }
            }

            return ti;
        }

        public void CreateFavorite(object TweetId)
        {
            using (Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass))
            {
                t.Favorite(TweetId.ToString());
                SetFavoriteById(TweetId.ToString(),true);

                SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_8_0", cInfo_));
            }
        }

        public void DestroyFavorite(object TweetId)
        {
            using (Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass))
            {
                t.UnFavorite(TweetId.ToString());
                SetFavoriteById(TweetId.ToString(),false);

                SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_8_1", cInfo_));
            }
        }

        public void DestroyStatus(object TweetId)
        {
            using (Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass))
            {
                t.Destroy(TweetId.ToString());
                SetDestroyById(TweetId.ToString());

                SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_9", cInfo_));
            }
        }

        public void DestroyMessages(object TweetId)
        {
            using (Twitter t = new Twitter(TwitterUser.UserName, 
                TwitterUser.UserPass))
            {
                t.DestroyMessages(TweetId.ToString());
                SetDestroyById(TweetId.ToString());

                SetStatusMsg(dil_.GetString("TIME_LINE_MESAJ_10", cInfo_));
            }
        }

        public string ToRelativeDate(DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now - dateTime;

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                return String.Format(dil_.GetString("ITEM_TIME_1", cInfo_),
                    timeSpan.Seconds);
            }

            if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                return timeSpan.Minutes > 1 ? 
                    String.Format(dil_.GetString("ITEM_TIME_2_0",cInfo_),
                    timeSpan.Minutes) : dil_.GetString("ITEM_TIME_2_1", cInfo_);
            }

            if (timeSpan <= TimeSpan.FromHours(24))
            {
                return timeSpan.Hours > 1 ? String.Format(dil_.GetString("ITEM_TIME_3_0",cInfo_),
                    timeSpan.Hours) : dil_.GetString("ITEM_TIME_3_1", cInfo_);
            }

            if (timeSpan <= TimeSpan.FromDays(30))
            {
                return timeSpan.Days > 1 ? String.Format(dil_.GetString("ITEM_TIME_4_0", cInfo_),
                    timeSpan.Days) : dil_.GetString("ITEM_TIME_4_1", cInfo_);
            }

            if (timeSpan <= TimeSpan.FromDays(365))
            {
                return timeSpan.Days > 30 ? String.Format(dil_.GetString("ITEM_TIME_5_0", cInfo_),
                    (timeSpan.Days/30)) : dil_.GetString("ITEM_TIME_5_1", cInfo_);                   
            }

            return timeSpan.Days > 365 ? String.Format(dil_.GetString("ITEM_TIME_6_0", cInfo_),
                    (timeSpan.Days/365)) : dil_.GetString("ITEM_TIME_6_1", cInfo_); 
        }

        #endregion

    }
}
