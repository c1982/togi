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

namespace Togi
{
    public partial class TimeLine : Form
    {        
        private User TwitterUser;
        public IList<TweetItem> FriendsTimeLine { get; set; }
        public IList<TweetItem> RepliesTimeLine { get; set; }
        public IList<TweetItem> MessagesTimeLine { get; set; }

        private const int WM_HOTKEY = 0x0312;
        public TimeLine()
        {
            InitializeComponent();

            TableCtor();
            MenuCtor();

            // Togi is Offline;
            TogiNotify.Icon = Properties.Resources.favicon_offline;
        }        

        private void lClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
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
            Thread l_replies = new Thread(new ThreadStart(LoadReplies));
            l_replies.SetApartmentState(ApartmentState.STA);
            l_replies.Start();                       
        }

        private void tsAdvanced_Click(object sender, EventArgs e)
        {
            using (SettingsForm s = new SettingsForm())
            {
                s.ShowDialog();                                    
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

        private void LoadReplies()
        {
            string SinceId;

            SinceId = Regedit.GetKey_("since_replies");

            Thread t_replies = new Thread(new ParameterizedThreadStart(GetReplies));
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

        private void LoadMessages()
        {
            string SinceId;

            SinceId = Regedit.GetKey_("since_messages");
            Thread t_replies = new Thread(new ParameterizedThreadStart(GetMessages));
            t_replies.SetApartmentState(ApartmentState.STA);
            t_replies.Start(SinceId);
        }

        private void GetMessages(object SinceId)
        {
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

        private void FillTableTweet(IList<TweetItem> TweetList)
        {
            int TableRowIndex = 0;
            Tablo.Visible = false;
            Tablo.Controls.Clear();

            lock (this)
            {
                if (TweetList != null)
                {
                    foreach (TweetItem item in TweetList)
                    {
                        item.Dock = DockStyle.Bottom;

                        Tablo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        Tablo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                        Tablo.Controls.Add(item, 1, TableRowIndex);
                        TableRowIndex++;
                    }
                }
            }

            Tablo.Visible = true;
            Tablo.Focus();
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

                Thread.Sleep(1000);

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
    }
}
