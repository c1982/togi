using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Xml;
using TogiApi.Tools;

namespace TogiApi
{
    public class Twitter : IDisposable
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Twitter()
        {
            Crypto decode_ = new Crypto();
            if(!String.IsNullOrEmpty(Regedit.GetKey_("login_name")))
                UserName = decode_.DecryptString(Regedit.GetKey_("login_name"));

            if (!String.IsNullOrEmpty(Regedit.GetKey_("login_pass")))
                Password = decode_.DecryptString(Regedit.GetKey_("login_pass"));
        }

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
                
                // Proxy Kullanılacak mı?
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

        public void Update(string UpdateText)
        {
            if (String.IsNullOrEmpty(UpdateText))
                return;

            // Url Kısaltma Kontrolü.
            if (Regedit.GetKey_("check_shorturl").Equals("true"))
            {
                Tools.ShortUrl kisalt_ = new TogiApi.Tools.ShortUrl(UpdateText);
                UpdateText = kisalt_.NewText;
            }

            // Parametreler
            NameValueCollection Postlar = new NameValueCollection();
            Postlar.Add("status", UpdateText);
            Postlar.Add("source", "togi");

            Istek("http://twitter.com/statuses/update.xml", 
                "POST", 
                Postlar);
        }

        public void Destroy(string StatusId)
        {
            if (String.IsNullOrEmpty(StatusId))
                return;

            NameValueCollection Postlar = new NameValueCollection();
            Postlar.Add("id", StatusId);

            Istek(String.Format("http://twitter.com/statuses/destroy/{0}.xml", StatusId),
                "POST",
                Postlar);
        }

        public void DestroyMessages(string StatusId)
        {
            if (String.IsNullOrEmpty(StatusId))
                return;

            NameValueCollection Postlar = new NameValueCollection();
            Postlar.Add("id", StatusId);

            Istek(String.Format("http://twitter.com/direct_messages/destroy/{0}.xml", StatusId),
                "POST",
                Postlar);
        }

        public void Favorite(string StatusId)
        {
            if (String.IsNullOrEmpty(StatusId))
                return;

            NameValueCollection Postlar = new NameValueCollection();
            Postlar.Add("id", StatusId);

            Istek(String.Format("http://twitter.com/favorites/create/{0}.xml",StatusId),
                "POST",
                Postlar);
        }

        public void UnFavorite(string StatusId)
        {
            if (String.IsNullOrEmpty(StatusId))
                return;

            NameValueCollection Postlar = new NameValueCollection();
            Postlar.Add("id", StatusId);

            Istek(String.Format("http://twitter.com/favorites/destroy/{0}.xml", StatusId),
                "POST",
                Postlar);
        }

        public User ShowUser(string ScreenName)
        {
            string XmlData = Istek(String.Format("http://twitter.com/users/show/{0}.xml",ScreenName)
                ,"GET"
                , null);

            return new User(XmlData);
        }

        public IList<Tweet> FriendsTimeLine(string SinceId)
        {
            string XmlString;
            string ApiUri;

            ApiUri = String.IsNullOrEmpty(SinceId) ? "http://twitter.com/statuses/friends_timeline.xml" :
                "http://twitter.com/statuses/friends_timeline.xml?since_id=" + SinceId +"&count=50";

            XmlString = Istek(ApiUri, "GET", null);

            return FriendsTimeLineParser(XmlString, Tweet.TweetTypes.Normal);
        }

        public IList<Tweet> FriendsTimeLine(string SinceId, bool Max)
        {
            string XmlString;
            string ApiUri;

            ApiUri = String.IsNullOrEmpty(SinceId) ? "http://twitter.com/statuses/friends_timeline.xml" :
                "http://twitter.com/statuses/friends_timeline.xml?max_id=" + SinceId;

            XmlString = Istek(ApiUri, "GET", null);

            return FriendsTimeLineParser(XmlString, Tweet.TweetTypes.Normal);
        }

        public IList<Tweet> RepliesTimeLine(string SinceId)
        {
            string XmlString;
            string ApiUri;

            ApiUri = String.IsNullOrEmpty(SinceId) ? "http://twitter.com/statuses/replies.xml" :
                "http://twitter.com/statuses/replies.xml?since_id="+ SinceId;

            XmlString = Istek(ApiUri, "GET", null);

            return FriendsTimeLineParser(XmlString, Tweet.TweetTypes.Reply);
        }

        public IList<Tweet> RepliesTimeLine(string SinceId, bool Max)
        {
            string XmlString;
            string ApiUri;

            ApiUri = String.IsNullOrEmpty(SinceId) ? "http://twitter.com/statuses/replies.xml" :
                "http://twitter.com/statuses/replies.xml?max_id=" + SinceId;

            XmlString = Istek(ApiUri, "GET", null);

            return FriendsTimeLineParser(XmlString, Tweet.TweetTypes.Reply);
        }

        public IList<Tweet> MessageTimeLine(string SinceId)
        {
            string XmlString;
            string ApiUri;

            ApiUri = String.IsNullOrEmpty(SinceId) ? "http://twitter.com/direct_messages.xml" :
                "http://twitter.com/direct_messages.xml?since_id=" + SinceId;

            XmlString = Istek(ApiUri, "GET", null);

            return MessageTimeLineParser(XmlString);
        }

        public IList<Tweet> MessageTimeLine(string SinceId, bool Max)
        {
            string XmlString;
            string ApiUri;

            ApiUri = String.IsNullOrEmpty(SinceId) ? "http://twitter.com/direct_messages.xml" :
                "http://twitter.com/direct_messages.xml?max_id=" + SinceId;

            XmlString = Istek(ApiUri, "GET", null);

            return MessageTimeLineParser(XmlString);
        }

        private IList<Tweet> FriendsTimeLineParser(string XmlString, Tweet.TweetTypes tip)
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
                    TimeLine.Add(CreateTweet(Liste[i], tip));
                }
            }

            return TimeLine;
        }

        private IList<Tweet> MessageTimeLineParser(string XmlString)
        {
            IList<Tweet> TimeLine = new List<Tweet>();

            XmlDocument Xdoc = new XmlDocument();
            XmlNodeList Liste = null;

            Xdoc.LoadXml(XmlString);
            XmlElement Kok = Xdoc.DocumentElement;

            // TimeLine dolu ise.
            if (Kok.SelectSingleNode("/direct-messages/direct_message") != null)
            {
                Liste = Xdoc.SelectNodes("/direct-messages/direct_message");

                // Xml Listesi Aktarılıyor.
                for (int i = 0; i < Liste.Count; i++)
                {
                    TimeLine.Add(CreateMessage(Liste[i]));
                }
            }

            return TimeLine;
        }

        private Tweet CreateTweet(XmlNode XmlTweet, Tweet.TweetTypes tip)
        {
            Tweet t = new Tweet();
            t.CreateAt = Utils.TarihVer(XmlTweet.SelectSingleNode("created_at").InnerText);
            t.Id = XmlTweet.SelectSingleNode("id").InnerText;
            t.isRead = false;
            t.isFavorite = bool.Parse(XmlTweet.SelectSingleNode("favorited").InnerText);

            t.ReplyScreenName = XmlTweet.SelectSingleNode("in_reply_to_screen_name").InnerText;
            t.ReplyStatusId = XmlTweet.SelectSingleNode("in_reply_to_status_id").InnerText;
            t.ReplyUserId = XmlTweet.SelectSingleNode("in_reply_to_user_id").InnerText;

            t.TweetType = tip;

            t.Source = XmlTweet.SelectSingleNode("source").InnerText;
            t.Text = XmlTweet.SelectSingleNode("text").InnerText;

            t.UserId = XmlTweet.SelectSingleNode("user/id").InnerText;
            t.UserName = XmlTweet.SelectSingleNode("user/name").InnerText;
            t.UserScreenName = XmlTweet.SelectSingleNode("user/screen_name").InnerText;
            t.ProfilImageUrl = XmlTweet.SelectSingleNode("user/profile_image_url").InnerText;

            return t;
        }

        private Tweet CreateMessage(XmlNode XmlTweet)
        {
            Tweet t = new Tweet();
            t.CreateAt = Utils.TarihVer(XmlTweet.SelectSingleNode("created_at").InnerText);
            t.Id = XmlTweet.SelectSingleNode("id").InnerText;
            t.isRead = false;
            t.TweetType = Tweet.TweetTypes.Message;

            t.Text = XmlTweet.SelectSingleNode("text").InnerText;

            t.UserId = XmlTweet.SelectSingleNode("sender/id").InnerText;
            t.UserName = XmlTweet.SelectSingleNode("sender/name").InnerText;
            t.UserScreenName = XmlTweet.SelectSingleNode("sender/screen_name").InnerText;
            t.ProfilImageUrl = XmlTweet.SelectSingleNode("sender/profile_image_url").InnerText;

            return t;
        }
        
        public void SetSinceId(Tweet t)
        {
            switch (t.TweetType)
            {
                case Tweet.TweetTypes.Normal:
                    Regedit.SetKey_("since_recent", t.Id);
                    break;
                case Tweet.TweetTypes.Reply:
                    Regedit.SetKey_("since_reply", t.Id);
                    break;
                case Tweet.TweetTypes.Message:
                    Regedit.SetKey_("since_message", t.Id);
                    break;
                default:
                    break;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            
        }

        #endregion
    }
}
