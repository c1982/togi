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

namespace Togi
{
    public partial class Login : Form
    {
        public User LoginUser { get; set; }
        public IList<Tweet> FriendsTimeLine { get; set; }

        private Thread lng;
        private string ScreenName;
        private string Password;

        delegate void SetText(string Yazi, Label Kontrol);
        delegate void SetVisible(Panel p, bool Display);

        public Login()
        {
            InitializeComponent();

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
            lng.IsBackground = true;
            lng.Start();
        }

        private void TwitterLogin()
        {
            try
            {
                Thread.Sleep(1000);
                Twitter login = new Twitter(ScreenName, Password);

                // TimeLine geliyor
                SetTextBoxText("TimeLine yükleniyor...", lLoading);
                FriendsTimeLine = login.FriendsTimeLine("");

                // User bilgileri geliyor
                SetTextBoxText("Oturum açılıyor...", lLoading);
                LoginUser = login.ShowUser(ScreenName);
                LoginUser.UserName = ScreenName;
                LoginUser.UserPass = Password;

                // Hesap Regedit'e yazılyor.
                if (cRemember.Checked)
                    RememberThisAccount(ScreenName, Password);

                DialogResult = DialogResult.OK;
            }
            catch
            {
                SetTextBoxText("Incorrect Login", lLoading);
                Thread.Sleep(2000);

                SetPanelVisibility(P1, true);
                SetPanelVisibility(P2, false);
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

            Tools.Crypto encode_ = new Togi.Tools.Crypto();
            EncodePass = encode_.EncryptString(lUser);
            EncodeScreenName = encode_.EncryptString(lPass);

            Tools.Regedit.SetKey_("login_name", EncodePass);
            Tools.Regedit.SetKey_("login_pass", EncodeScreenName);
        }

        private bool isSave(out string lUser, out string lPass)
        {
            bool CheckSave;
            CheckSave = false;

            Tools.Crypto decode_ = new Togi.Tools.Crypto();

            lUser = Tools.Regedit.GetKey_("login_name");
            lPass = Tools.Regedit.GetKey_("login_pass");

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
