using System;
using System.Windows.Forms;
using TimeLineControl;
using TogiApi;

namespace Togi
{
    public partial class Notification : Form
    {
        private delegate void SetTweetItem(Tweet ti, string lTimeCaption);

        public Notification(Tweet t, string lTimeCaption)
        {
            InitializeComponent();
            SetTweetItemThisForm(t, lTimeCaption);
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            NoticeTime.Start();
        }

        private void NoticeTime_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetTweetItemThisForm(Tweet ti, string lTimeCaption)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetTweetItem(SetTweetItemThisForm), new object[] { ti, lTimeCaption });
            }

            TweetItem content_ = new TweetItem(ti);
            content_.lTime.Text = lTimeCaption;
            content_.Dock = DockStyle.Fill;
            this.Controls.Add(content_);  
        }
    }
}
