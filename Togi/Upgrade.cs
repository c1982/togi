using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Reflection;
using TogiApi;

namespace Togi
{
    public partial class Upgrade : Form
    {        
        private Thread thrDownload;
        private Stream strResponse;
        private Stream strLocal;
        private HttpWebRequest webRequest;
        private HttpWebResponse webResponse;
        private static int PercentProgress;
        private delegate void UpdateProgessCallback(Int64 BytesRead, Int64 TotalBytes);
        private ResourceManager dil_;
        private CultureInfo cInfo_;

        public Upgrade()
        {
            InitializeComponent();
            LanguageCtor();
        }

        private void Download()
        {
            string DownloadUrl = "http://www.oguzhan.info/togi/TogiSetup.0.2.6.exe";
            string SavePath = String.Format("{0}\\togi_setup.exe",Application.StartupPath);

            using (WebClient wcDownload = new WebClient())
            {
                try
                {
                    webRequest = (HttpWebRequest)WebRequest.Create(DownloadUrl);                    
                    webRequest.Credentials = CredentialCache.DefaultCredentials;                    
                    webResponse = (HttpWebResponse)webRequest.GetResponse();
                    Int64 fileSize = webResponse.ContentLength;
                    strResponse = wcDownload.OpenRead(DownloadUrl);
                    strLocal = new FileStream(SavePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    
                    int bytesSize = 0;                    
                    byte[] downBuffer = new byte[2048];
                    
                    while ((bytesSize = strResponse.Read(downBuffer, 0, downBuffer.Length)) > 0)
                    {                    
                        strLocal.Write(downBuffer, 0, bytesSize);                    
                        this.Invoke(new UpdateProgessCallback(UpdateProgress), new object[] { strLocal.Length, fileSize });
                    }
                }
                finally
                {
                    strResponse.Close();
                    strLocal.Close();

                    Process.Start(SavePath);
                    this.DialogResult = DialogResult.Ignore;
                }
            }
        }

        private void UpdateProgress(Int64 BytesRead, Int64 TotalBytes)
        {
            PercentProgress = Convert.ToInt32((BytesRead * 100) / TotalBytes);
            progressBar1.Value = PercentProgress;

            label1.Text = String.Format(dil_.GetString("UPGRADE_STATUS"),
                BytesRead,
                TotalBytes,
                PercentProgress);
        }

        private void Upgrade_Load(object sender, EventArgs e)
        {      
            thrDownload = new Thread(Download);
            thrDownload.Start();
        }

        private void lClose_Click(object sender, EventArgs e)
        {
            webResponse.Close();
            strResponse.Close();
            strLocal.Close();
            thrDownload.Abort();

            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void LanguageCtor()
        {
            cInfo_ = Tools.Setup.GetCultureInfo();
            Thread.CurrentThread.CurrentUICulture = cInfo_;
            dil_ = Tools.Setup.GetResourceManager();

            label_title.Text = dil_.GetString("UPGRADE_TITLE");
            lClose.Text = dil_.GetString("INFO_BUTTON_1");
        }
    }
}
