using System;
using System.Drawing;
using System.Xml;

namespace TogiApi
{
    public class User
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public string Bio { get; set; }
        public Bitmap ImageNormal { get; set; }
        
        public short FollowersCnt { get; set; }
        public short FriendsCnt { get; set; }
        public short StatusCnt { get; set; }

        public User(string XmlData)
        {
            XmlParse(XmlData);
        }

        private void XmlParse(string XmlData)
        {
            string ImageUrl;

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(XmlData);

            UserId = Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/id"));
            Name = Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/name"));
            ScreenName = Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/screen_name"));
            Location = Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/location"));
            Url = Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/location"));

            ImageUrl = Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/profile_image_url"));
            ImageNormal = Utils.GetImage(ImageUrl);

            FollowersCnt = Convert.ToInt16(Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/followers_count")));
            FriendsCnt = Convert.ToInt16(Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/friends_count")));
            StatusCnt = Convert.ToInt16(Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/statuses_count")));

            Bio = Utils.GetValueFromNode(xdoc.SelectSingleNode("/user/description"));
        }
    }
}
