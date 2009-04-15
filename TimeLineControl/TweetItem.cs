using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TogiApi;
using System.Threading;
using System.Net;
using System.IO;
using System.ComponentModel.Design;

namespace TimeLineControl
{

    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))] 
    public partial class TweetItem : UserControl
    {
        
        public delegate void SetTweetType(object sender, EventArgs e);
        public delegate void AllowDelete(object sender, EventArgs e);

        delegate void SetPicture(Bitmap Resim);
        delegate void SetFavoriteIcon(bool isFavorite);
        delegate void SetMenuTextDelegate(ToolStripMenuItem tmenu, string text_);
        delegate void SetDeletedTextDelegate();

        public event SetTweetType TweetTypeSec_;
        public event AllowDelete TweetAllowDelete_;

        public Tweet ItemTweet;
        private Bitmap Resim;
        private WebClient ResimIstegi;
        private sbyte ImageRetriveCount;

        public TweetItem()
        {
            InitializeComponent();                      
        }

        public TweetItem(Tweet t)
        {
            InitializeComponent();
            ItemTweet = t;            
        }

        void ResimIstegi_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            try
            {
                SetProgfileImage(new Bitmap(e.Result));
            }
            catch
            {
                if (ImageRetriveCount < 3)
                {
                    Thread img = new Thread(new ParameterizedThreadStart(ShowProfileImage));
                    img.Start(ItemTweet.ProfilImageUrl);
                }
            }
        }

        private void SetControlValues()
        {
            TweetText.Links.Clear();
            TweetText.Text = System.Web.HttpUtility.HtmlDecode(ItemTweet.Text.Trim());

            FullName.Text = String.Format("{0} ({1})",
                ItemTweet.UserName,
                ItemTweet.UserScreenName);

            lTime.Text = String.Format("{0} from {1}",
                TweetUtils.ToRelativeDate(ItemTweet.CreateAt),
                TweetUtils.GetSourceFromLink(ItemTweet.Source)
                );

            if (!ItemTweet.isRead)
            {
                SetBackColorIsRead(ItemTweet.TweetType); 
            }
            else
            {
                SetBackColorDefault(ItemTweet.TweetType);
            } 

            Resim = Properties.Resources.default_profile_normal;
            TweetUtils.LinkEkle(TweetText);

            tsFavorite.Tag = ItemTweet.Id;
            tsReply.Tag = ItemTweet.Id;
            tsReTweet.Tag = ItemTweet.Id;
            tsMessage.Tag = ItemTweet.Id;
            tsDelete.Tag = ItemTweet.Id;
            TweetText.Tag = ItemTweet.Id;

            // Mesaj'da menüler kapatılır.
            if (ItemTweet.TweetType == Tweet.TweetTypes.Message)
            {
                tsFavorite.Enabled = false;
                tsReply.Enabled = false;
                tsReTweet.Enabled = false;
                tsDelete.Tag = true;
            }

            // Favori ise yıldızı göster.
            ShowFavoriteIcon(ItemTweet.isFavorite);

            // Favori ise favoriyi sil yaz.
            if (ItemTweet.isFavorite)
                SetMenuText(tsFavorite, "Un-Favorite");

            // Resim Aliniyor.
            Thread img = new Thread(new ParameterizedThreadStart(ShowProfileImage));
            img.Start(ItemTweet.ProfilImageUrl);

        }


        private void ShowProfileImage(object ImageUrl)
        {
            ImageRetriveCount++;
            // Profil Resmi Çağırılıyor.
            ResimIstegi = new WebClient();
            ResimIstegi.OpenReadAsync(new Uri((string)ImageUrl));
            ResimIstegi.OpenReadCompleted += new OpenReadCompletedEventHandler(ResimIstegi_OpenReadCompleted);
        }

        private void SetProgfileImage(Bitmap Resim)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetPicture(SetProgfileImage),new object[]{Resim});
                return;
            }

            ProfileImage.Image = Resim;
        }

        private void SetMenuText(ToolStripMenuItem tmenu, string text_)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetMenuTextDelegate(SetMenuText), new object[] { tmenu, text_ });
                return;
            }

            tmenu.Text = text_;
        }

        public void SetDeletedStatusText()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetDeletedTextDelegate(SetDeletedStatusText), new object[] {});
                return;
            }

            TweetText.Font = new System.Drawing.Font("Arial", 8.25F, 
                System.Drawing.FontStyle.Strikeout, 
                System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        }

        private void TweetText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            //}
            //catch
            //{                
            //    // Lay Lay Lom...
            //}
        }

        private void TweetItem_MouseHover(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(115, 229, 229); 
            if (ItemTweet.isRead)
            {
                SetBackColorIsRead(ItemTweet.TweetType);
            }
        }

        private void TweetItem_MouseLeave(object sender, EventArgs e)
        {
            //this.BackColor = Color.PaleTurquoise;
            if (ItemTweet.isRead)
            {
                SetBackColorDefault(ItemTweet.TweetType);
            }
        }

        private void SetBackColorIsRead(Tweet.TweetTypes tp)
        {
            this.TweetText.ForeColor = Color.Black;
            this.TweetText.LinkColor = Color.RoyalBlue;
            this.FullName.ForeColor = Color.Black;
            this.lTime.ForeColor = Color.Black;

            switch (tp)
            {
                case TogiApi.Tweet.TweetTypes.Normal:
                    this.BackColor = Color.FromArgb(115, 229, 229);
                    break;

                case TogiApi.Tweet.TweetTypes.Message:
                    this.BackColor = Color.Orange;
                    break;

                case TogiApi.Tweet.TweetTypes.Reply:
                    this.BackColor = Color.FromArgb(171, 229, 113);                     
                    break;

                case TogiApi.Tweet.TweetTypes.Deleted:
                    this.BackColor = Color.WhiteSmoke;
                    break;

                default:
                    break;
            }
        }

        public void SetBackColorDefault(Tweet.TweetTypes tp)
        {
            this.TweetText.ForeColor = Color.Gray;
            this.TweetText.LinkColor = Color.RoyalBlue;
            this.FullName.ForeColor = Color.Gray;
            this.lTime.ForeColor = Color.Gray;

            switch (tp)
            {
                case TogiApi.Tweet.TweetTypes.Normal:
                    this.BackColor = Color.PaleTurquoise;
                    break;

                case TogiApi.Tweet.TweetTypes.Message:
                    this.BackColor = Color.Wheat;
                    break;

                case TogiApi.Tweet.TweetTypes.Reply:              
                    this.BackColor = Color.FromArgb(195, 238, 190);
                    break;

                case TogiApi.Tweet.TweetTypes.Deleted:
                    this.BackColor = Color.WhiteSmoke;
                    break;

                default:
                    break;
            }
        }

        private void TweetItem_Load(object sender, EventArgs e)
        {
            SetControlValues();
        }

        public void ShowFavoriteIcon(bool isFavorite)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetFavoriteIcon(ShowFavoriteIcon), new object[] { isFavorite});
                return;
            }
            
            pFavoriIcon.Visible = isFavorite;
        }

        private void ProfileImage_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(String.Format("http://twitter.com/{0}/statuses/{1}",
                    ItemTweet.UserScreenName,
                    ItemTweet.Id));
            }
            catch
            {
                // Lay lay lom.
            }
        }
    }
}
