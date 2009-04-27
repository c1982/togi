using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace TogiApi.Tools
{
    public class ShortUrl
    {
        public string NewText { get; set; }

        public ShortUrl(string StatusText)
        {
            NewText = MakeShort(StatusText);
        }

        private string MakeShort(string StatusText)
        {
            string KisaUrl;
            string Desen = @"((mailto\:|(news|(ht|f)tp(s?))\://){1}\S+)";

            // Adresler ayıklanıyor.
            MatchCollection Uyanlar = Regex.Matches(StatusText, Desen);
            if (Uyanlar.Count > 0)
            {
                // Kısa Url yaratılıyor.    
                switch (Regedit.GetKey_("url.fm"))
                {
                    case "tinyurl.com":
                        KisaUrl = TinyUrl(Uyanlar[0].Value);
                        break;

                    case "kissa.be":
                        KisaUrl = Kissa(Uyanlar[0].Value);
                        break;

                    case "is.gd":
                        KisaUrl = IsGd(Uyanlar[0].Value);
                        break;

                    case "bit.ly":
                        KisaUrl = BitLy(Uyanlar[0].Value);
                        break;

                    default:
                        KisaUrl = TinyUrl(Uyanlar[0].Value);
                        break;
                }

                // Uzun URL yi Kısa Url ile değiştiriyoruz.
                return Regex.Replace(StatusText, Desen, KisaUrl);
            }
            else
            {
                return StatusText;
            }
        }

        private string Pattern_(string Url, string ApiUrl)
        {
            try
            {
                if (Url.Length <= 30)
                {
                    return Url;
                }

                if (!Url.ToLower().StartsWith("http") && !Url.ToLower().StartsWith("ftp"))
                {
                    Url = "http://" + Url;
                }

                string text;

                var request = WebRequest.Create(ApiUrl + Url);
                var res = request.GetResponse();
                
                using (var reader = new StreamReader(res.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                }

                return text;
            }
            catch (Exception)
            {
                return Url;
            }
        }

        private string TinyUrl(string Url)
        {
            return Pattern_(Url, "http://tinyurl.com/api-create.php?url=");
        }

        private string Kissa(string Url)
        {
            return Pattern_(Url, "http://kissa.be/api.php?url=");
        }

        private string IsGd(string Url)
        {
            return Pattern_(Url, "http://is.gd/api.php?longurl=");
        }

        private string BitLy(string Url)
        {
            return Pattern_(Url, "http://bit.ly/api?url=");
        }



    }
}
