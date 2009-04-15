using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TogiApi;
using TimeLineControl;
using System.Threading;
using System.Collections;

namespace Togi
{
    public partial class TimeLine : Form
    {        
        static private User TwitterUser;
        
        public IList<TweetItem> FriendsTimeLine { get; set; }
        public IList<TweetItem> RepliesTimeLine { get; set; }
        public IList<TweetItem> MessagesTimeLine { get; set; }

        private const int WM_HOTKEY = 0x0312;

        private delegate void SetFavoriteIcon(bool isFavorite);
        private delegate void del_OpenNoticeForm(TweetItem t);
        private delegate void SetTextToolStripButtons(ToolStripButton ts, int Count_);
        private delegate void SetTextStatusMesage(string text_);


        #region Construct
        public TimeLine()
        {            
            InitializeComponent();

            TableCtor();
            MenuCtor();

            // Togi is Offline;
            TogiNotify.Icon = Properties.Resources.favicon_offline;
        }        

        private void TimeLine_Load(object sender, EventArgs e)
        {
            LoginIn();            
        }

        private void LoginIn()
        {
            // Login Prosedürü.
            using (Login lgn = new Login())
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

                    //WndProc'u çalıştırır.
                    Tools.HandleKeys.RegisterRecordKey(this.Handle);

                    // Check Schedule
                    SetZamanTimer();
                }
                else
                {
                    if(TwitterUser == null)
                        Application.Exit();
                }
            }

            // TimeLine yükleniyor.
            if (FriendsTimeLine != null)
                FillTableTweet(FriendsTimeLine);

            // Repliesler yukleniyor. Since Id Yok
            Thread l_replies = new Thread(new ParameterizedThreadStart(GetReplies));
            l_replies.SetApartmentState(ApartmentState.STA);
            l_replies.Start(String.Empty);  
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

        private void GetReplies(object SinceId)
        {
            if (TwitterUser == null)
                return;
            
            IList<TweetItem> tmp_list = new List<TweetItem>();
            Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass);
            lock (this)
            {
                foreach (Tweet item in t.RepliesTimeLine((string)SinceId))
                {
                    tmp_list.Add(new TweetItem(item));
                }

                AddEvents(tmp_list);
                RepliesTimeLine = tmp_list;
            }
        }

        private void GetMessages(object SinceId)
        {
            if (TwitterUser == null)
                return;

            IList<TweetItem> tmp_list = new List<TweetItem>();
            Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass);
            lock (this)
            {
                foreach (Tweet item in t.MessageTimeLine((string)SinceId))
                {
                    tmp_list.Add(new TweetItem(item));
                }

                AddEvents(tmp_list);
                MessagesTimeLine = tmp_list;
                
            }
        }

        #endregion

        #region Events
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
                            item.Dock = DockStyle.Bottom;
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

        private void tsRecents_Click(object sender, EventArgs e)
        {
            tsRecents.Text = String.Empty;

            FillTableTweet(FriendsTimeLine);
        }

        private void tsReplys_Click(object sender, EventArgs e)
        {
            tsReplys.Text = String.Empty;
            FillTableTweet(RepliesTimeLine);
        }

        private void tsMessages_Click(object sender, EventArgs e)
        {
            tsMessages.Text = String.Empty;

            // Mesajlar yukleniyor.
            if (MessagesTimeLine == null)
            {
                Thread l_messages = new Thread(new ParameterizedThreadStart(GetMessages));
                l_messages.SetApartmentState(ApartmentState.STA);
                l_messages.Start(String.Empty);
            }
            else
            {
                FillTableTweet(MessagesTimeLine);
            }
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

        private void SetZamanTimer()
        {
            string IntTimeString = Regedit.GetKey_("check_time");
            int IntTime = String.IsNullOrEmpty(IntTimeString) ? 3 : int.Parse(IntTimeString);
            IntTime = (IntTime * 60) * 1000;

            Zaman.Enabled = true;
            Zaman.Interval = IntTime;
            Zaman.Start();
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
            
            if (MessageBox.Show("Kullanıcıyı değiştirmek istiyormusun?", "Togi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Regedit.SetKey_("login_name", String.Empty);
                Regedit.SetKey_("login_pass", String.Empty);                

                LoginIn();
            }
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
            int NewTweetCount;
            NewTweetCount = 0;

            using (Tools.CheckTweets chck = new Togi.Tools.CheckTweets(TwitterUser))
            {
                SetStatusMsg("checking tweets...");
                AddNewTweetInList(chck.CheckTimeLine(), Tweet.TweetTypes.Normal, out NewTweetCount);
                SetTweetNumber(tsRecents, NewTweetCount);

                SetStatusMsg("checking replies...");
                AddNewTweetInList(chck.CheckReplies(), Tweet.TweetTypes.Reply, out NewTweetCount);
                SetTweetNumber(tsReplys, NewTweetCount);

                SetStatusMsg("checking messages...");
                AddNewTweetInList(chck.CheckMessages(), Tweet.TweetTypes.Message, out NewTweetCount);
                SetTweetNumber(tsMessages, NewTweetCount);
            }

            SetStatusMsg(String.Format("check time {0}",DateTime.Now.ToShortTimeString()));
            
        }

        private void AddNewTweetInList(IList<TweetItem> tList_, Tweet.TweetTypes tip, out int NewTweetCount)
        {
            string ShotNoticeStr_ = Regedit.GetKey_("check_notice");
            bool ShowNotice = String.IsNullOrEmpty(ShotNoticeStr_) ? true : 
                bool.Parse(ShotNoticeStr_);

            IList<TweetItem> tList = tList_;

            NewTweetCount = 0;
            lock (this)
            {
                if (tList != null)
                {                    
                    NewTweetCount = tList.Count;
                    foreach (TweetItem item in tList)
                    {
                        // Olaylar yükleniyor
                        AddEventsTweetItem(item);

                        if (item != null)
                        {
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
                            //if (ShowNotice)                            
                            //    OpenNoticeForm(item);                            
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

            if(Count_ > 0)
                ts.Text = Count_.ToString();

        }

        private void OpenNoticeForm(TweetItem t)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new del_OpenNoticeForm(OpenNoticeForm), new object[] { t});
                return;
            }

            Notification n = new Notification(t);
            n.Notice();
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

            // TeetType'ı denetleniyor.
            item.TweetTypeSec_ += new TweetItem.SetTweetType(item_TweetTypeSec_);
            item_TweetTypeSec_(item, new EventArgs());

            item.tsDelete.Click += new EventHandler(tsDelete_Click);

            //Silinebilirliği denetleniyor.
            item.TweetAllowDelete_ += new TweetItem.AllowDelete(item_TweetAllowDelete_);
            item_TweetAllowDelete_(item, new EventArgs());
            
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
                    Thread th = new Thread(new ParameterizedThreadStart(DestroyStatus));
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
                if (ti.ItemTweet.ReplyScreenName.Equals(TwitterUser.ScreenName))
                    ti.ItemTweet.TweetType = Tweet.TweetTypes.Reply;
            }
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

        private void SetFavoriteById(string TweetId, bool isFavorite)
        {
            lock (FriendsTimeLine)
            {
                foreach (TweetItem item in FriendsTimeLine)
                {
                    if (item.ItemTweet.Id.Equals(TweetId))
                    {
                        item.ShowFavoriteIcon(isFavorite);                        
                        break;
                    }
                }
            }
        }

        private void SetDestroyById(string TweetId)
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
                        break;
                    }
                }
            }
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
            }
        }

        public void DestroyFavorite(object TweetId)
        {
            using (Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass))
            {
                t.UnFavorite(TweetId.ToString());
                SetFavoriteById(TweetId.ToString(),false);
            }
        }

        public void DestroyStatus(object TweetId)
        {
            using (Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass))
            {
                t.Destroy(TweetId.ToString());
                SetDestroyById(TweetId.ToString());
            }
        }

        #endregion
    }
}
