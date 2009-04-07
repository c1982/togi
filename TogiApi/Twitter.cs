﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Xml;

namespace TogiApi
{
    public class Twitter
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Twitter(string user, string pass)
        {
            UserName = user;
            Password = pass;
        }

        private string Istek(string HttpUrl, string Method, NameValueCollection Parametreler)
        {
            byte[] DonenYanit;

            DonenYanit = null;
            System.Net.ServicePointManager.Expect100Continue = false;
            using (WebClient wClient = new WebClient())
            {
                
                wClient.Credentials = new NetworkCredential(UserName, Password);
                wClient.Headers.Add("X-Twitter-Client", "Togi");
                wClient.Headers.Add("X-Twitter-Version", "0.3.0");
                wClient.Headers.Add("X-Twitter-URL", "http://www.oguzhan.info/togi");

                if (UseProxy())
                {
                    string ProxyUser;
                    string ProxyPass;

                    ProxyUser = Regedit.GetKey_("proxy_user");
                    ProxyPass = Regedit.GetKey_("proxy_pass");

                    ICredentials cred = new NetworkCredential(ProxyUser, ProxyPass);
                    wClient.Proxy = CreateProxy();
                    wClient.Proxy.Credentials = cred;                
                }
 
                DonenYanit = Method.Equals("POST") ? 
                                wClient.UploadValues(HttpUrl, Method, Parametreler) :
                                wClient.DownloadData(HttpUrl);

                wClient.Dispose();
            }

            return Encoding.UTF8.GetString(DonenYanit);
        }

        private WebProxy CreateProxy()
        {
            string proxyAddress;
            proxyAddress = String.Format("http://{0}:{1}",
                Regedit.GetKey_("proxy_server"),
                Regedit.GetKey_("proxy_port"));

            WebProxy p = new WebProxy();            
            p.Address = new Uri(proxyAddress); // format: http://proxy.domain.com:8080
            p.BypassProxyOnLocal = true;            

            return p;
        }

        private bool UseProxy()
        {
            string GetProxy;
            GetProxy = Regedit.GetKey_("proxy");
            if (String.IsNullOrEmpty(GetProxy))
                GetProxy = "false";

            return bool.Parse(GetProxy);
        }

        public User ShowUser(string ScreenName)
        {
            NameValueCollection Gonder = new NameValueCollection();
            Gonder.Add(String.Empty, String.Empty);

            string XmlData = Istek(String.Format("http://twitter.com/users/show/{0}.xml",ScreenName)
                ,"GET"
                , Gonder);

            return new User(XmlData);
        }

        public IList<Tweet> FriendsTimeLine(string SinceId)
        {
            string XmlString;
            NameValueCollection Gonder = new NameValueCollection();

            if (!String.IsNullOrEmpty(SinceId))
            {
                Gonder.Add("since_id", SinceId);
            }

            XmlString = Istek(@"http://twitter.com/statuses/friends_timeline.xml", "POST", Gonder);

            return FriendsTimeLineParser(XmlString);
        }

        private IList<Tweet> FriendsTimeLineParser(string XmlString)
        {
            IList<Tweet> TimeLine = new List<Tweet>();

            XmlDocument Xdoc = new XmlDocument();
            XmlNodeList Liste = null;

            Xdoc.LoadXml(XmlString);           
            XmlElement Kok = Xdoc.DocumentElement;

            // TimeLine dolu ise.
            if (Kok.SelectSingleNode("/statuses/status") != null)
            {
                Liste = Xdoc.SelectNodes("/statuses/status");

                // Xml Listesi Aktarılıyor.
                for (int i = 0; i < Liste.Count; i++)
                {
                    TimeLine.Add(CreateTweet(Liste[i]));
                }
            }

            return TimeLine;
        }

        private Tweet CreateTweet(XmlNode XmlTweet)
        {
            Tweet t = new Tweet();
            t.CreateAt = Utils.TarihVer(XmlTweet.SelectSingleNode("created_at").InnerText);
            t.Id = XmlTweet.SelectSingleNode("id").InnerText;
            t.isRead = false;
            t.isFavorite = bool.Parse(XmlTweet.SelectSingleNode("favorited").InnerText);

            t.ReplyScreenName = XmlTweet.SelectSingleNode("in_reply_to_screen_name").InnerText;
            t.ReplyStatusId = XmlTweet.SelectSingleNode("in_reply_to_status_id").InnerText;
            t.ReplyUserId = XmlTweet.SelectSingleNode("in_reply_to_user_id").InnerText;

            t.Source = XmlTweet.SelectSingleNode("source").InnerText;
            t.Text = XmlTweet.SelectSingleNode("text").InnerText;

            t.UserId = XmlTweet.SelectSingleNode("user/id").InnerText;
            t.UserName = XmlTweet.SelectSingleNode("user/name").InnerText;
            t.UserScreenName = XmlTweet.SelectSingleNode("user/screen_name").InnerText;
            t.ProfilImageUrl = XmlTweet.SelectSingleNode("user/profile_image_url").InnerText;

            return t;
        }
    }
}
