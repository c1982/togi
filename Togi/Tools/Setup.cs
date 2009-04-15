using System;
using System.Collections.Generic;
using System.Text;
using TogiApi;

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
            SetKey("language", "Türkçe");
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
    }
}
