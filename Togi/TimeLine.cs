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

        private void FillTableTweet(IList<TweetItem> TweetList)
        {
            int TableRowIndex = 0;
            Tablo.Controls.Clear();

            lock (this)
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

            this.Tablo.Focus();
        }

        private void tsRecents_Click(object sender, EventArgs e)
        {
            FillTableTweet(FriendsTimeLine);
        }

        private void tsReplys_Click(object sender, EventArgs e)
        {
            FillTableTweet(RepliesTimeLine);
        }
    }
}
