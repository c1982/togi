using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TimeLineControl;
using TogiApi;

namespace Togi
{
    public partial class Notification : Form
    {
        private delegate void SetTweetItem(Tweet ti);
        public Notification(Tweet t)
        {
            InitializeComponent();
            SetTweetItemThisForm(t);
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            NoticeTime.Start();
        }

        private void NoticeTime_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetTweetItemThisForm(Tweet ti)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetTweetItem(SetTweetItemThisForm), new object[] { ti });
            }

            TweetItem content_ = new TweetItem(ti);
            content_.Dock = DockStyle.Fill;
            this.Controls.Add(content_);  
        }
    }
}
