namespace TimeLineControl
{
    partial class TweetItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FullName = new System.Windows.Forms.Label();
            this.TweetText = new System.Windows.Forms.LinkLabel();
            this.ItemMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsReply = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReTweet = new System.Windows.Forms.ToolStripMenuItem();
            this.ts1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ts2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.lTime = new System.Windows.Forms.Label();
            this.pFavoriIcon = new System.Windows.Forms.PictureBox();
            this.ProfileImage = new System.Windows.Forms.PictureBox();
            this.ItemMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFavoriIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // FullName
            // 
            this.FullName.AutoSize = true;
            this.FullName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.FullName.ForeColor = System.Drawing.Color.Gray;
            this.FullName.Location = new System.Drawing.Point(40, 3);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(57, 14);
            this.FullName.TabIndex = 1;
            this.FullName.Text = "FullName";
            // 
            // TweetText
            // 
            this.TweetText.ActiveLinkColor = System.Drawing.Color.Red;
            this.TweetText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TweetText.BackColor = System.Drawing.Color.Transparent;
            this.TweetText.ContextMenuStrip = this.ItemMenu;
            this.TweetText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TweetText.ForeColor = System.Drawing.Color.Gray;
            this.TweetText.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.TweetText.LinkColor = System.Drawing.Color.RoyalBlue;
            this.TweetText.Location = new System.Drawing.Point(39, 16);
            this.TweetText.Name = "TweetText";
            this.TweetText.Size = new System.Drawing.Size(253, 42);
            this.TweetText.TabIndex = 0;
            this.TweetText.UseCompatibleTextRendering = true;
            this.TweetText.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TweetText.MouseLeave += new System.EventHandler(this.TweetItem_MouseLeave);
            this.TweetText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TweetText_LinkClicked);
            this.TweetText.MouseHover += new System.EventHandler(this.TweetItem_MouseHover);
            this.TweetText.MouseEnter += new System.EventHandler(this.TweetItem_MouseHover);
            // 
            // ItemMenu
            // 
            this.ItemMenu.BackgroundImage = global::TimeLineControl.Properties.Resources.bg2;
            this.ItemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsReply,
            this.tsReTweet,
            this.ts1,
            this.tsMessage,
            this.tsFavorite,
            this.tsDelete,
            this.ts2,
            this.tsUserInfo});
            this.ItemMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ItemMenu.Name = "ItemMenu";
            this.ItemMenu.ShowImageMargin = false;
            this.ItemMenu.ShowItemToolTips = false;
            this.ItemMenu.Size = new System.Drawing.Size(130, 148);
            // 
            // tsReply
            // 
            this.tsReply.Name = "tsReply";
            this.tsReply.Size = new System.Drawing.Size(129, 22);
            this.tsReply.Text = "Reply";
            // 
            // tsReTweet
            // 
            this.tsReTweet.Name = "tsReTweet";
            this.tsReTweet.Size = new System.Drawing.Size(129, 22);
            this.tsReTweet.Text = "Re Tweet";
            // 
            // ts1
            // 
            this.ts1.Name = "ts1";
            this.ts1.Size = new System.Drawing.Size(126, 6);
            // 
            // tsMessage
            // 
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.Size = new System.Drawing.Size(129, 22);
            this.tsMessage.Text = "Message User";
            // 
            // tsFavorite
            // 
            this.tsFavorite.Name = "tsFavorite";
            this.tsFavorite.Size = new System.Drawing.Size(129, 22);
            this.tsFavorite.Text = "Mark as Favorite";
            // 
            // tsDelete
            // 
            this.tsDelete.Enabled = false;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(129, 22);
            this.tsDelete.Text = "Delete Tweet";
            // 
            // ts2
            // 
            this.ts2.Name = "ts2";
            this.ts2.Size = new System.Drawing.Size(126, 6);
            // 
            // tsUserInfo
            // 
            this.tsUserInfo.Name = "tsUserInfo";
            this.tsUserInfo.Size = new System.Drawing.Size(129, 22);
            this.tsUserInfo.Text = "User Info";
            // 
            // lTime
            // 
            this.lTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTime.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lTime.ForeColor = System.Drawing.Color.Gray;
            this.lTime.Location = new System.Drawing.Point(147, 3);
            this.lTime.Margin = new System.Windows.Forms.Padding(0);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(148, 13);
            this.lTime.TabIndex = 2;
            this.lTime.Text = "28 dakika önce";
            this.lTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pFavoriIcon
            // 
            this.pFavoriIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pFavoriIcon.BackColor = System.Drawing.Color.Transparent;
            this.pFavoriIcon.Image = global::TimeLineControl.Properties.Resources.icon_star_full;
            this.pFavoriIcon.Location = new System.Drawing.Point(277, 43);
            this.pFavoriIcon.Name = "pFavoriIcon";
            this.pFavoriIcon.Size = new System.Drawing.Size(16, 16);
            this.pFavoriIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pFavoriIcon.TabIndex = 12;
            this.pFavoriIcon.TabStop = false;
            this.pFavoriIcon.Visible = false;
            // 
            // ProfileImage
            // 
            this.ProfileImage.BackColor = System.Drawing.Color.Transparent;
            this.ProfileImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProfileImage.Image = global::TimeLineControl.Properties.Resources.default_profile_normal;
            this.ProfileImage.Location = new System.Drawing.Point(3, 3);
            this.ProfileImage.Name = "ProfileImage";
            this.ProfileImage.Size = new System.Drawing.Size(31, 31);
            this.ProfileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfileImage.TabIndex = 6;
            this.ProfileImage.TabStop = false;
            this.ProfileImage.Click += new System.EventHandler(this.ProfileImage_Click);
            // 
            // TweetItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.pFavoriIcon);
            this.Controls.Add(this.TweetText);
            this.Controls.Add(this.FullName);
            this.Controls.Add(this.ProfileImage);
            this.Controls.Add(this.lTime);
            this.Name = "TweetItem";
            this.Size = new System.Drawing.Size(296, 61);
            this.Load += new System.EventHandler(this.TweetItem_Load);
            this.MouseLeave += new System.EventHandler(this.TweetItem_MouseLeave);
            this.MouseHover += new System.EventHandler(this.TweetItem_MouseHover);
            this.MouseEnter += new System.EventHandler(this.TweetItem_MouseHover);
            this.ItemMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pFavoriIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FullName;
        private System.Windows.Forms.PictureBox ProfileImage;
        private System.Windows.Forms.ToolStripSeparator ts1;
        private System.Windows.Forms.PictureBox pFavoriIcon;
        public System.Windows.Forms.ContextMenuStrip ItemMenu;
        public System.Windows.Forms.ToolStripMenuItem tsFavorite;
        public System.Windows.Forms.ToolStripMenuItem tsReply;
        public System.Windows.Forms.ToolStripMenuItem tsReTweet;
        public System.Windows.Forms.ToolStripMenuItem tsMessage;
        public System.Windows.Forms.ToolStripMenuItem tsDelete;
        public System.Windows.Forms.LinkLabel TweetText;
        private System.Windows.Forms.ToolStripSeparator ts2;
        public System.Windows.Forms.ToolStripMenuItem tsUserInfo;
        public System.Windows.Forms.Label lTime;
    }
}
