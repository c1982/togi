using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
                    break;
                default:
                    break;
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtGuncelle.Text))
            {
                return;
            }

            Thread t = new Thread(new ParameterizedThreadStart(Guncelle));
            t.Start(txtGuncelle.Text);
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

    }
}
