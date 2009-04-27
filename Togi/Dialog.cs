using System;
using System.Windows.Forms;
using TogiApi;
using System.Threading;

namespace Togi
{
    public partial class Dialog : Form
    {
        private User TwitterUser;
        private Tweet CurrentTweet;

        public Dialog(User u)
        {            
            InitializeComponent();
            TwitterUser = u;

            pPicture.Image = TwitterUser.ImageNormal;
            LabelUserName.Text = String.Format("{0} ({1})",
                        TwitterUser.Name,
                        TwitterUser.ScreenName);

        }
        
        public Dialog(User u, Tweet ct)
        {
            InitializeComponent();
            TwitterUser = u;
            CurrentTweet = ct;

            pPicture.Image = TwitterUser.ImageNormal;
            LabelUserName.Text = String.Format("{0} ({1})",
                        TwitterUser.Name,
                        TwitterUser.ScreenName);

        }

        internal void ShowDialog(string action_)
        {
            switch (action_)
            {
                case "reply":
                    txtGuncelle.Text = "@" + CurrentTweet.UserScreenName + " ";
                    txtGuncelle.SelectionStart = txtGuncelle.Text.Length;

                    break;
                case "messages":
                    txtGuncelle.Text = "D " + CurrentTweet.UserScreenName + " ";
                    txtGuncelle.SelectionStart = txtGuncelle.Text.Length;

                    break;
                case "retweet":
                    txtGuncelle.Text = "RT @" + CurrentTweet.UserScreenName + ": " + CurrentTweet.Text;
                    txtGuncelle.SelectionStart = txtGuncelle.Text.Length;
                    break;
                default:
                    break;
            }

            this.ShowDialog();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtGuncelle.Text))
            {
                txtGuncelle.Focus();
                return;
            }
            else
            {
                Thread t = new Thread(new ParameterizedThreadStart(Guncelle));
                t.Start(txtGuncelle.Text);
            }
        }

        private void Guncelle(object Status)
        {
            try
            {
                if (Status != null)
                {
                    Twitter t = new Twitter(TwitterUser.UserName, TwitterUser.UserPass);
                    t.Update(Status.ToString());
                }                
            }
            catch (Exception emsg)
            {
                MessageBox.Show(emsg.Message);
            }
        }

        private void txtGuncelle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    this.txtGuncelle.SelectAll();
                }
            }
        }

        private void txtGuncelle_TextChanged(object sender, EventArgs e)
        {
            if (lblTolerans.Text.Length >= 0)
            {
                lblTolerans.Text = ((140 - txtGuncelle.Text.Length)).ToString();
            }
        }

    }
}
