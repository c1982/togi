using System;
using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Runtime;
using System.Runtime.InteropServices; 

namespace TogiApi
{
    public class Utils
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

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

        public static bool IsConnected( )
        {
            int Desc ;
            return InternetGetConnectedState( out Desc, 0 );
        }

    }
        
}
