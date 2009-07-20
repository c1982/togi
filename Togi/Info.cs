using System;
using System.Drawing;
using System.Windows.Forms;
using TogiApi;
using System.Threading;
using System.Globalization;
using System.Resources;

namespace Togi
{
    public partial class Info : Form
    {
        private User User_;
        private string ScreenName;
        private delegate void dSetTextValue(Label label_, string text_);
        private delegate void dSetImage(Bitmap img);

        public Info()
        {
            InitializeComponent();
            LanguageCtor();
        }

        public Info(string sn_)
        {
            InitializeComponent();
            LanguageCtor();
            ScreenName = sn_;
        }

        private void lClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            Thread th_ = new Thread(new ThreadStart(GetUserInfo));
            th_.SetApartmentState(ApartmentState.STA);
            th_.Start();
        }

        private void GetUserInfo()
        {
            using (Twitter t = new Twitter())
            {
                User_ = t.ShowUser(ScreenName);
                ShowTextValues();
            }
        }

        private void ShowTextValues()
        {
            if (User_ == null)
                return;

            SetText(l_Bio_Value, User_.Bio);
            SetText(l_Fallowers, User_.FollowersCnt.ToString());
            SetText(l_Fallowing, User_.FriendsCnt.ToString());
            SetText(l_Location_Value, User_.Location);
            SetText(l_Name_Value, User_.Name);
            SetText(l_Web_Value, User_.Url);
            SetText(l_Updates, User_.StatusCnt.ToString());
            SetImage(User_.ImageNormal);
        }

        private void LanguageCtor()
        {
            CultureInfo cInfo_ = Tools.Setup.GetCultureInfo();
            Thread.CurrentThread.CurrentUICulture = cInfo_;
            ResourceManager dil_ = Tools.Setup.GetResourceManager();

            l_Name.Text = dil_.GetString("INFO_LABEL_1");            
            l_Location.Text = dil_.GetString("INFO_LABEL_2");
            l_Web.Text = dil_.GetString("INFO_LABEL_3");
            l_Bio.Text = dil_.GetString("INFO_LABEL_4");

            label5.Text = dil_.GetString("INFO_LABEL_5");
            label6.Text = dil_.GetString("INFO_LABEL_6");
            label7.Text = dil_.GetString("INFO_LABEL_7");
            
            lClose.Text = dil_.GetString("INFO_BUTTON_1");

            dil_.ReleaseAllResources();
        }

        private void SetText(Label label_, string text_)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new dSetTextValue(SetText), new object[] { label_, text_ });
                return;
            }

            label_.Text = text_;
        }

        private void SetImage(Bitmap img)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new dSetImage(SetImage), new object[] { img});
                return;
            }

            pb1.Image = img;
        }
    }
}
