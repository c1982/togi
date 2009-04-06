using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Togi.Tools
{
    public class Crypto
    {
        SymmetricAlgorithm mCSP;

        #region "Constants"
        const string _key = "NYYObMInlTtentKODigMiSE/NSp/4JQv";
        const string _IV = "PenS8UCVF7s=";
        #endregion

        public Crypto()
        {
            mCSP = SetEnc();
            mCSP.IV = Convert.FromBase64String(_IV);
            mCSP.Key = Convert.FromBase64String(_key);
        }

        public string EncryptString(string Value)
        {
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            Byte[] byt = new byte[64];

            try
            {
                ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);

                byt = Encoding.UTF8.GetBytes(Value);

                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();

                cs.Close();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception Ex)
            {
                throw (new Exception("An error occurred while encrypting string", Ex));
            }
        }
        public string DecryptString(string Value)
        {
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            Byte[] byt = new byte[64];
            try
            {
                ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);

                byt = Convert.FromBase64String(Value);

                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();

                cs.Close();
                string test = Encoding.UTF8.GetString(ms.ToArray());
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw (new Exception("An error occurred while decrypting string", ex));
            }
        }
        private SymmetricAlgorithm SetEnc()
        {
            return new TripleDESCryptoServiceProvider();
        }
    }
}
