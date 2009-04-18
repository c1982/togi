using System;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Reflection;
using TogiApi;

namespace Togi
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LanguageCtor();
            LoadValues();
        }

        private void nCheckTime_ValueChanged(object sender, EventArgs e)
        {   
            
            Regedit.SetKey_("check_time", nCheckTime.Value.ToString());
        }

        private void cLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cLang.Text))
                Regedit.SetKey_("language", cLang.Text);
        }

        private void cShorUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cShorUrl.Text))
                Regedit.SetKey_("short_url", cShorUrl.Text);
        }

        private void cRun_CheckedChanged(object sender, EventArgs e)
        {
            Regedit.SetKey_("run", cRun.Checked ? "true":"false");
        }

        private void cProxy_CheckedChanged(object sender, EventArgs e)
        {
            Regedit.SetKey_("proxy", cProxy.Checked ? "true" : "false");
        }

        private void bProxySave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tProxyServer.Text))
            {
                tProxyServer.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tProxyPort.Text))
            {
                tProxyPort.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tProxyUser.Text))
            {
                tProxyUser.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tProxyPass.Text))
            {
                tProxyPass.Focus();
                return;
            }


            Regedit.SetKey_("proxy_server", tProxyServer.Text);
            Regedit.SetKey_("proxy_port", tProxyPort.Text);
            Regedit.SetKey_("proxy_user", tProxyUser.Text);
            Regedit.SetKey_("proxy_pass", tProxyPass.Text);
        }

        private void LoadValues()
        {
            string v_CheckTime = Regedit.GetKey_("check_time");
            string v_Languages = Regedit.GetKey_("language");
            string v_ShorUrl = Regedit.GetKey_("short_url");
            string v_Run = Regedit.GetKey_("run");

            string v_Proxy = Regedit.GetKey_("proxy");
            string v_Proxy_Pass = Regedit.GetKey_("proxy_pass");
            string v_Proxy_Port = Regedit.GetKey_("proxy_port");
            string v_Proxy_Server = Regedit.GetKey_("proxy_server");
            string v_Proxy_User = Regedit.GetKey_("proxy_user");


            nCheckTime.Value = String.IsNullOrEmpty(v_CheckTime) ? 3 : int.Parse(v_CheckTime);
            cLang.SelectedIndex = cLang.FindString(v_Languages);
            cShorUrl.SelectedIndex = cShorUrl.FindString(v_ShorUrl);
            cRun.Checked = String.IsNullOrEmpty(v_Run) ? true : bool.Parse(v_Run);

            cProxy.Checked = String.IsNullOrEmpty(v_Proxy) ? true : bool.Parse(v_Proxy);
            tProxyPass.Text = v_Proxy_Pass;
            tProxyPort.Text = v_Proxy_Port;
            tProxyServer.Text = v_Proxy_Server;
            tProxyUser.Text = v_Proxy_User;

        }

        private void LanguageCtor()
        {
            string CultureName = Regedit.GetKey_("language");

            CultureInfo cInfo_ = new CultureInfo(String.IsNullOrEmpty(CultureName) ?
                "en-US" :
                CultureName);

            Thread.CurrentThread.CurrentUICulture = cInfo_;

            ResourceManager dil_ = new ResourceManager("Togi.Lang.Language",
                Assembly.GetExecutingAssembly());

            groupBox1.Text = dil_.GetString("SETTINGS_BOX_1");
            groupBox2.Text = dil_.GetString("SETTINGS_BOX_2");
            groupBox3.Text = dil_.GetString("SETTINGS_BOX_3");
            groupBox4.Text = dil_.GetString("SETTINGS_BOX_4");
            groupBox5.Text = dil_.GetString("SETTINGS_BOX_5");

            cRun.Text = dil_.GetString("SETTINGS_CHECK_1");
            cProxy.Text = dil_.GetString("SETTINGS_CHECK_2");

            lMinutes.Text = dil_.GetString("SETTINGS_BOX_1_1");
            IpAdresi.Text = dil_.GetString("SETTINGS_LABEL_1");
            l_Port.Text = dil_.GetString("SETTINGS_LABEL_2");
            lUserName.Text = dil_.GetString("LOGIN_LABEL_1");
            lPassword.Text = dil_.GetString("LOGIN_LABEL_2");

            bProxySave.Text = dil_.GetString("SETTINGS_BUTTON_1");

            tpGeneral.Text = dil_.GetString("SETTINGS_MENU_1");
            tpAbout.Text = dil_.GetString("SETTINGS_MENU_3");
            tpProxy.Text = dil_.GetString("SETTINGS_MENU_2");

            dil_.ReleaseAllResources();
        }

        private void link_language_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.oguzhan.info/togi");
        }
    }
}
