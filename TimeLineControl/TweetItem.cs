using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TogiApi;
using System.Threading;

namespace TimeLineControl
{
    public partial class TweetItem : UserControl
    {
        delegate void SetPicture(Bitmap Resim);

        public TweetItem(Tweet t)
        {
            InitializeComponent();

            TweetText.Links.Clear();
            TweetText.Text = t.Text.Trim();

            FullName.Text = String.Format("{0} ({1})",
                t.UserName,
                t.UserScreenName);

            lTime.Text = TweetUtils.ToRelativeDate(t.CreateAt);

            TweetUtils.LinkEkle(TweetText);
            Thread img = new Thread(new ParameterizedThreadStart(ShowProfileImage));
            img.Start(t.ProfilImageUrl);
        }

        private void ShowProfileImage(object ImageUrl)
        {
            // Progil Resmi Çağırılıyor.
            SetProgfileImage(Utils.GetImage((string)ImageUrl));
        }

        private void SetProgfileImage(Bitmap Resim)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetPicture(SetProgfileImage),new object[]{Resim});
                return;
            }

            ProfileImage.Image = Resim;
        }

        private void TweetText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            }
            catch
            {
                
                // Lay Lay Lom...
            }
        }

        private void TweetItem_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(115, 229, 229);
        }

        private void TweetItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.PaleTurquoise;
        }
    }
}
