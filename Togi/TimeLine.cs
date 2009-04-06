using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TogiApi;
using TimeLineControl;

namespace Togi
{
    public partial class TimeLine : Form
    {
        private User TwitterUser;
        public IList<Tweet> FriendsTimeLine { get; set; }

        public TimeLine()
        {
            InitializeComponent();
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

            int TableRowIndex = 0;
            Tablo.Controls.Clear();
            Tablo.RowStyles.Clear();

            foreach (Tweet item in FriendsTimeLine)
            {
                TweetItem tw = new TweetItem(item);
                tw.Dock = DockStyle.Bottom;

                Tablo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                Tablo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                Tablo.Controls.Add(tw, 1, TableRowIndex);
                TableRowIndex++;
            }
        }

        private void tsAdvanced_Click(object sender, EventArgs e)
        {
            using (SettingsForm s = new SettingsForm())
            {
                s.ShowDialog();                                    
            }
        }
    }
}
