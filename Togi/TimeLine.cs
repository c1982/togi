﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TogiApi;
using TimeLineControl;
using System.Threading;

namespace Togi
{
    public partial class TimeLine : Form
    {        
        private User TwitterUser;
        public IList<TweetItem> FriendsTimeLine { get; set; }
        public IList<TweetItem> RepliesTimeLine { get; set; }
        public IList<TweetItem> MessagesTimeLine { get; set; }

        private const int WM_HOTKEY = 0x0312;

        private delegate void del_OpenNoticeForm(TweetItem t);
        private delegate void SetTextToolStripButtons(ToolStripButton ts, int Count_);        

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
            // Login Prosedürü.
            using (Login lgn = new Login())
            {
                if (lgn.ShowDialog() == DialogResult.OK)
                {
                    TwitterUser = lgn.LoginUser;
                    FriendsTimeLine = lgn.FriendsTimeLine;

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
                    Application.Exit();
                }
            }

            // TimeLine yükleniyor.
            if(FriendsTimeLine != null)
                FillTableTweet(FriendsTimeLine);

            // Repliesler yukleniyor.
            //Thread l_replies = new Thread(new ThreadStart(LoadReplies));
            //l_replies.SetApartmentState(ApartmentState.STA);
            //l_replies.Start();                       
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

        private void LoadReplies()
        {
            string SinceId;

            SinceId = Regedit.GetKey_("since_reply");
            SinceId = String.IsNullOrEmpty(SinceId) ? "" : SinceId;

            Thread t_replies = new Thread(new ParameterizedThreadStart(GetReplies));
            t_replies.SetApartmentState(ApartmentState.STA);
            t_replies.Start(SinceId);
        }

        private void LoadMessages()
        {
            string SinceId;
            SinceId = Regedit.GetKey_("since_message");
            SinceId = String.IsNullOrEmpty(SinceId) ? "" : SinceId;

            Thread t_replies = new Thread(new ParameterizedThreadStart(GetMessages));
            t_replies.SetApartmentState(ApartmentState.STA);
            t_replies.Start(SinceId);
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
            }
        }

        private void FillTableTweet(IList<TweetItem> TweetList)
        {

            if (TweetList == null)
                return;

            int TableRowIndex = 0;
            //Tablo.Visible = false;
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

            //Tablo.ResumeLayout();
            //Tablo.Visible = true;
            Tablo.Focus();
        }

        private void tsRecents_Click(object sender, EventArgs e)
        {
            tsRecents.Text = String.Empty;

            //Thread k = new Thread(new ParameterizedThreadStart(FillTableTweet));
            //k.Start(FriendsTimeLine);
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
                Thread l_messages = new Thread(new ThreadStart(LoadMessages));
                l_messages.SetApartmentState(ApartmentState.STA);
                l_messages.Start();

                do
                {
                    Thread.Sleep(2000);

                } while (l_messages.IsAlive);

                Thread.Sleep(2000);

                FillTableTweet(MessagesTimeLine);
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

        #endregion

        #region CheckNewTweets

        private void CheckNewTweets()
        {
            int NewTweetCount;

            using (Tools.CheckTweets chck = new Togi.Tools.CheckTweets(TwitterUser))
            {
                bool ShowNotice = bool.Parse(Regedit.GetKey_("check_notice"));

                //#region Recents
                //IList<TweetItem> tmp_recents = chck.CheckTimeLine();
                //NewTweetCount = tmp_recents.Count;

                //foreach (TweetItem it in tmp_recents)
                //{
                //    FriendsTimeLine.Insert(0, it);

                //    if(ShowNotice)
                //        OpenNoticeForm(it);
                //}

                //SetTweetNumber(tsRecents, NewTweetCount);
                //#endregion

                //#region Replies
                //IList<TweetItem> tmp_replies= chck.CheckReplies();
                //NewTweetCount = tmp_replies.Count;

                //foreach (TweetItem it in tmp_replies)
                //{
                //    RepliesTimeLine.Insert(0, it);

                //    if (ShowNotice)
                //        OpenNoticeForm(it);
                //}
                //SetTweetNumber(tsReplys, NewTweetCount);
                //#endregion

                //#region Messages
                //IList<TweetItem> tmp_messages = chck.CheckMessages();
                //NewTweetCount = tmp_messages.Count;

                //foreach (TweetItem it in tmp_messages)
                //{
                //    MessagesTimeLine.Insert(0, it);

                //    if (ShowNotice)
                //        OpenNoticeForm(it);
                //}
                //SetTweetNumber(tsMessages, NewTweetCount);
                //#endregion

                AddNewTweetInList(chck.CheckTimeLine(), Tweet.TweetTypes.Normal, out NewTweetCount);
                SetTweetNumber(tsRecents, NewTweetCount);

                AddNewTweetInList(chck.CheckReplies(), Tweet.TweetTypes.Reply, out NewTweetCount);
                SetTweetNumber(tsReplys, NewTweetCount);

                AddNewTweetInList(chck.CheckMessages(), Tweet.TweetTypes.Message, out NewTweetCount);
                SetTweetNumber(tsMessages, NewTweetCount);
            }

            //string SinceId = Regedit.GetKey_("since_recent");
            //Twitter TwitterApi = new Twitter(TwitterUser.UserName, TwitterUser.UserPass);
            //AddNewTweetInList(LoadTweetItem(TwitterApi.FriendsTimeLine(SinceId)), Tweet.TweetTypes.Normal, out NewTweetCount);

            //foreach (TweetItem it in LoadTweetItem(TwitterApi.FriendsTimeLine(SinceId)))
            //{
            //    FriendsTimeLine.Insert(0, it);
            //}

        }

        private IList<TweetItem> LoadTweetItem(IList<Tweet> liste)
        {
            IList<TweetItem> fTimeLine_ = new List<TweetItem>();

            lock (this)
            {
                foreach (Tweet item in liste)
                {
                    fTimeLine_.Add(new TweetItem(item));
                }
            }

            return fTimeLine_;
        }

        private void AddNewTweetInList(IList<TweetItem> tList_, Tweet.TweetTypes tip, out int NewTweetCount)
        {
            IList<TweetItem> tList = tList_;

            NewTweetCount = 0;
            lock (this)
            {
                if (tList != null)
                {                    
                    NewTweetCount = tList.Count;
                    foreach (TweetItem item in tList)
                    {
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
                            //if (Regedit.GetKey_("check_notice").Equals("true"))
                            //{
                            //    OpenNoticeForm(item);
                            //}
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





    }
}
