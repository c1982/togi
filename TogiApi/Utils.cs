using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;
using System.Globalization;

namespace TogiApi
{
    public class Utils
    {
        public static Bitmap GetImage(string Uri_)
        {
            Bitmap Resim;
            try
            {
                using (WebClient istek = new WebClient())
                {
                    using (Stream Strm = istek.OpenRead(Uri_))
                    {                        
                        Resim = new Bitmap(Strm);                        
                        Strm.Dispose();
                    }
                }
            }
            catch
            {
                Resim = null;
            }

            return Resim;
        }

        public static string GetValueFromNode(XmlNode xNode)
        {
            string strValue = String.Empty;

            XmlNode x_Node = xNode;
            if (x_Node != null)
            {
                strValue = x_Node.InnerText;
            }

            return strValue;
        }

        public static DateTime TarihVer(string Tarih)
        {
            return DateTime.ParseExact(Tarih, @"ddd MMM dd HH:mm:ss zzzzz yyyy",
                                                CultureInfo.InvariantCulture,
                                                    DateTimeStyles.AdjustToUniversal).AddHours(ZamanFarki());
        }

        private static int ZamanFarki()
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            DateTime baseUTC = DateTime.Now;

            DateTime localTime = localZone.ToLocalTime(baseUTC);
            TimeSpan localOffset = localZone.GetUtcOffset(localTime);

            return localOffset.Hours;
        }


    }
        
}
