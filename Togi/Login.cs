using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TogiApi;
using System.Collections;
using TogiApi.Tools;
using TimeLineControl;

namespace Togi
{
    public partial class Login : Form
    {
        public User LoginUser { get; set; }
        public IList<TweetItem> FriendsTimeLine { get; set; }

        private Thread lng;
        private string ScreenName;
        private string Password;

        delegate void SetText(string Yazi, Label Kontrol);
        delegate void SetVisible(Panel p, bool Display);

        public Login()
        {
            InitializeComponent();
            FriendsTimeLine = new List<TweetItem>();

            //Write registry default values
            Tools.Setup ChkSetup = new Togi.Tools.Setup();
            ChkSetup.LoadRegistry();

            if (isSave(out ScreenName, out Password))
            {
                LoginStart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tSname.Text))
            {
                tSname.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tPass.Text))
            {
                tPass.Focus();
                return;
            }

            ScreenName = tSname.Text;
            Password = tPass.Text;

            LoginStart();
        }

        private void LoginStart()
        {
            SetPanelVisibility(P1, false);
            SetPanelVisibility(P2, true);

            lng = new Thread(TwitterLogin);
            lng.SetApartmentState(ApartmentState.STA);
            lng.Start();
        }

        private void TwitterLogin()
        {
            //try
            //{
                string SinceId = Regedit.GetKey_("since_recent");
                Thread.Sleep(1000);

                Twitter login = new Twitter(ScreenName, Password);

                // TimeLine geliyor
                SetTextBoxText("Loading Timeline...", lLoading);

                //1. Okunmamislar Aliniyor. Since_id
                LoadTweetItem(login.FriendsTimeLine(SinceId), false);

                //2. SinceId Yenileniyor
                if(FriendsTimeLine.Count > 0)
                    login.SetSinceId(FriendsTimeLine[0].ItemTweet);

                //3. Okunmuslar Aliniyor. Max_id
                LoadTweetItem(login.FriendsTimeLine(SinceId, true), true);                

                //4. User Bilgileri Aliniyor.
                SetTextBoxText("Loading Session...", lLoading);
                LoginUser = login.ShowUser(ScreenName);
                LoginUser.UserName = ScreenName;
                LoginUser.UserPass = Password;

                // Hesap Regedit'e yazılyor.
                if (cRemember.Checked)
                    RememberThisAccount(ScreenName, Password);

                DialogResult = DialogResult.OK;
            //}
            //catch(Exception ex)
            //{
            //    SetTextBoxText(ex.Message , lLoading);
            //    Thread.Sleep(2000);

            //    SetPanelVisibility(P1, true);
            //    SetPanelVisibility(P2, false);
            //}
        }

        private void LoadTweetItem(IList<Tweet> liste,bool isRead)
        {
            lock (this)
            {
                foreach (Tweet item in liste)
                {
                    item.isRead = isRead;
                    TweetItem ti = new TweetItem(item);
                    FriendsTimeLine.Add(ti);
                }
            }
        }

        private void lClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void SetTextBoxText(string Yazi, Label Kontrol)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetText(SetTextBoxText), new object[] { Yazi, Kontrol });
                return;
            }

            Kontrol.Text = Yazi;
        }

        private void SetPanelVisibility(Panel p, bool Display)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetVisible(SetPanelVisibility), new object[] { p, Display });
                return;
            }

            p.Visible = Display;
        }

        private void RememberThisAccount(string lUser, string lPass)
        {
            string EncodePass;
            string EncodeScreenName;

            Crypto encode_ = new Crypto();
            EncodePass = encode_.EncryptString(lUser);
            EncodeScreenName = encode_.EncryptString(lPass);

            Regedit.SetKey_("login_name", EncodePass);
            Regedit.SetKey_("login_pass", EncodeScreenName);
        }

        private bool isSave(out string lUser, out string lPass)
        {
            bool CheckSave;
            CheckSave = false;

            Crypto decode_ = new Crypto();

            lUser = Regedit.GetKey_("login_name");
            lPass = Regedit.GetKey_("login_pass");

            if (!String.IsNullOrEmpty(lUser) && !String.IsNullOrEmpty(lPass))
            {
                lUser = decode_.DecryptString(lUser);
                lPass = decode_.DecryptString(lPass);
                CheckSave = true;
            }

            return CheckSave;
        }



    }
}
