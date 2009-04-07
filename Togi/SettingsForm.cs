using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TogiApi;

namespace Togi
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
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
            Regedit.SetKey_("proxy_server", tProxyServer.Text);
            Regedit.SetKey_("proxy_port", tProxyPort.Text);
            Regedit.SetKey_("proxy_user", tProxyUser.Text);
            Regedit.SetKey_("proxy_pass", tProxyPass.Text);
        }
    }
}
