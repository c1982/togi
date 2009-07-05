using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Web;

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
            SearchLinkEkle(Status);
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
                    Status.Links.Add(Uyanlar[ls].Index, 
                        Uyanlar[ls].Length, 
                        "http://twitter.com/" + Uyanlar[ls].Value.Remove(0, 1));
                }
            }
        }

        private static void SearchLinkEkle(LinkLabel Status)
        {
            string Desen = "#[a-zA-Z0-9_]+";

            MatchCollection Uyanlar = Regex.Matches(Status.Text, Desen);
            for (int ls = 0; ls < Uyanlar.Count; ls++)
            {
                if (!Regex.Match(Uyanlar[ls].Value, @"((mailto\:|(news|(ht|f)tp(s?))))").Success)
                {
                    Status.Links.Add(Uyanlar[ls].Index, 
                        Uyanlar[ls].Length, 
                        string.Format("http://search.twitter.com/search?q={0}",
                        Uyanlar[ls].Value.Replace("#","%23")));
                }
            }
        }
    }
}
