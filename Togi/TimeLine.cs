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
        public IList<Tweet> FriendsTimeLine { get; set; }
        public IList<Tweet> RepliesTimeLine { get; set; }

        public TimeLine()
        {
            InitializeComponent();
            TableCtor();
        }        

        private void lClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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
            LoadReplies();

            // Mesajlar yukleniyor.

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
            Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass);
            RepliesTimeLine = t.RepliesTimeLine((string)SinceId);
        }

        private void FillTableTweet(IList<Tweet> TweetList)
        {
            int TableRowIndex = 0;
            Tablo.Controls.Clear();

            lock (this)
            {
                foreach (Tweet item in TweetList)
                {
                    TweetItem tw = new TweetItem(item);
                    tw.Dock = DockStyle.Bottom;

                    Tablo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    Tablo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    Tablo.Controls.Add(tw, 1, TableRowIndex);
                    TableRowIndex++;
                }   
            }
        }

        private void tsRecents_Click(object sender, EventArgs e)
        {
            FillTableTweet(RepliesTimeLine);
        }

        private void tsReplys_Click(object sender, EventArgs e)
        {
            FillTableTweet(RepliesTimeLine);
        }
    }
}
