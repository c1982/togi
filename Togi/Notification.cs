using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TimeLineControl;

namespace Togi
{
    public partial class Notification : Form
    {
        //private TweetItem tItem;
        private Rectangle Screen_;
        protected const Int32 SW_SHOWNOACTIVATE = 4;
        protected const Int32 HWND_TOPMOST = -1;
        protected const Int32 SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll")]
        protected static extern bool ShowWindow(IntPtr hWnd, Int32 flags);
        [DllImport("user32.dll")]
        protected static extern bool SetWindowPos(IntPtr hWnd, Int32 hWndInsertAfter, Int32 X, Int32 Y, Int32 cx, Int32 cy, uint uFlags);

        private delegate void SetTweetItem(TweetItem ti);
        public Notification(TweetItem t)
        {
            InitializeComponent();
            Screen_ = Screen.GetWorkingArea(Screen.PrimaryScreen.Bounds);
            SetTweetItemThisForm(t);
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Left = screenWidth - this.Width;
            this.Top = screenHeight - this.Height;
        }

        public void Notice()
        {
            ShowWindow(Handle, SW_SHOWNOACTIVATE);
            //SetWindowPos(Handle, HWND_TOPMOST, Screen_.Width, Screen_.Bottom, this.Width, 0, SWP_NOACTIVATE);
            NoticeTime.Start();
        }

        private void NoticeTime_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetTweetItemThisForm(TweetItem ti)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetTweetItem(SetTweetItemThisForm), new object[] { ti });
            }

            ti.Dock = DockStyle.Fill;
            this.Controls.Add(ti);  
        }
    }
}
