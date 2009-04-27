using System;
using TogiApi;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Togi.Tools
{
    public class Setup
    {
        public Setup()
        {

        }

        public void LoadRegistry()
        {
            SetKey("check_time", "3");
            SetKey("language", "en-US");
            SetKey("proxy", "false");
            SetKey("short_url", "tinyurl.com");
            SetKey("check_notice", "true");
            SetKey("check_shorturl", "true");
            SetKey("check_tweets", "true");
            SetKey("run", "true");
        }

        private void SetKey(string Key_, string Value_)
        {
            if(String.IsNullOrEmpty(Regedit.GetKey_(Key_)))
                Regedit.SetKey_(Key_, Value_);
        }

        public bool NewVersion()
        {
            string strReturn_ = String.Empty;
            bool blReturn_ = false;
            byte[] DonenYanit;

            DonenYanit = null;

            try
            {
                using (WebClient wClient = new WebClient())
                {
                    System.Net.ServicePointManager.Expect100Continue = false;
                    DonenYanit = wClient.DownloadData("http://www.oguzhan.info/togi/togi.txt");
                    strReturn_ = Encoding.UTF8.GetString(DonenYanit);

                    if (strReturn_ != Application.ProductVersion)
                    {
                        blReturn_ = true;
                    }
                }

                blReturn_ = true;
            }
            catch { }

            return blReturn_;
        }
    }
}
