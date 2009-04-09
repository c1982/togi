using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TimeLineControl
{
    public class TweetUtils
    {
        public static void LinkEkle(LinkLabel Status)
        {
            Status.Links.Clear();
            string Desen = @"((mailto\:|(news|(ht|f)tp(s?))\://){1}\S+)";

            MatchCollection Uyanlar = Regex.Matches(Status.Text, Desen);
            for (int ls = 0; ls < Uyanlar.Count; ls++)
            {
                Status.Links.Add(Uyanlar[ls].Index, Uyanlar[ls].Length, Uyanlar[ls].Value);
            }

            UserLinkEkle(Status);
        }

        public static void UserLinkEkle(LinkLabel Status)
        {
            string Desen = "@[a-zA-Z0-9_]+";

            MatchCollection Uyanlar = Regex.Matches(Status.Text, Desen);
            for (int ls = 0; ls < Uyanlar.Count; ls++)
            {
                //Bug: Overlapping link regions.
                if (!Regex.Match(Uyanlar[ls].Value, @"((mailto\:|(news|(ht|f)tp(s?))))").Success)
                {
                    Status.Links.Add(Uyanlar[ls].Index, Uyanlar[ls].Length, "http://twitter.com/" + Uyanlar[ls].Value.Remove(0, 1));
                }
            }
        }

        public static string ToRelativeDate(DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now - dateTime;

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                return timeSpan.Seconds + " saniye önce";
            }

            if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                return timeSpan.Minutes > 1 ? timeSpan.Minutes + " dakika önce" : "şimdi";
            }

            if (timeSpan <= TimeSpan.FromHours(24))
            {
                return timeSpan.Hours > 1 ? timeSpan.Hours + " saat önce" : "bir saat önce";
            }

            if (timeSpan <= TimeSpan.FromDays(30))
            {
                return timeSpan.Days > 1 ? timeSpan.Days + " gün önce" : "dün";
            }

            if (timeSpan <= TimeSpan.FromDays(365))
            {
                return timeSpan.Days > 30 ? timeSpan.Days / 30 + " ay önce" : "geçen ay";
            }

            return timeSpan.Days > 365 ? timeSpan.Days / 365 + " yıl önce" : "geçen sene";
        }
    }
}
