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
            this.ProfileImage = new System.Windows.Forms.PictureBox();
            this.TweetText = new System.Windows.Forms.LinkLabel();
            this.ItemMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reTweetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).BeginInit();
            this.ItemMenu.SuspendLayout();
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
            this.TweetText.Location = new System.Drawing.Point(40, 17);
            this.TweetText.Name = "TweetText";
            this.TweetText.Size = new System.Drawing.Size(253, 44);
            this.TweetText.TabIndex = 9;
            this.TweetText.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TweetText.MouseLeave += new System.EventHandler(this.TweetItem_MouseLeave);
            this.TweetText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TweetText_LinkClicked);
            this.TweetText.MouseHover += new System.EventHandler(this.TweetItem_MouseHover);
            this.TweetText.MouseEnter += new System.EventHandler(this.TweetItem_MouseHover);
            // 
            // ItemMenu
            // 
            this.ItemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replyToolStripMenuItem,
            this.reTweetToolStripMenuItem,
            this.toolStripSeparator1,
            this.messageToolStripMenuItem,
            this.markAsFavoritesToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ItemMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ItemMenu.Name = "ItemMenu";
            this.ItemMenu.ShowImageMargin = false;
            this.ItemMenu.ShowItemToolTips = false;
            this.ItemMenu.Size = new System.Drawing.Size(136, 120);
            // 
            // replyToolStripMenuItem
            // 
            this.replyToolStripMenuItem.Name = "replyToolStripMenuItem";
            this.replyToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.replyToolStripMenuItem.Text = "Reply";
            // 
            // reTweetToolStripMenuItem
            // 
            this.reTweetToolStripMenuItem.Name = "reTweetToolStripMenuItem";
            this.reTweetToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.reTweetToolStripMenuItem.Text = "Re Tweet";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.messageToolStripMenuItem.Text = "Message User";
            // 
            // markAsFavoritesToolStripMenuItem
            // 
            this.markAsFavoritesToolStripMenuItem.Name = "markAsFavoritesToolStripMenuItem";
            this.markAsFavoritesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.markAsFavoritesToolStripMenuItem.Text = "Mark as Favorite";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.deleteToolStripMenuItem.Text = "Delete Tweet";
            // 
            // lTime
            // 
            this.lTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTime.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lTime.ForeColor = System.Drawing.Color.Gray;
            this.lTime.Location = new System.Drawing.Point(195, 4);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(101, 13);
            this.lTime.TabIndex = 11;
            this.lTime.Text = "lTime";
            this.lTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TweetItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.TweetText);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.FullName);
            this.Controls.Add(this.ProfileImage);
            this.Name = "TweetItem";
            this.Size = new System.Drawing.Size(296, 61);
            this.Load += new System.EventHandler(this.TweetItem_Load);
            this.MouseLeave += new System.EventHandler(this.TweetItem_MouseLeave);
            this.MouseHover += new System.EventHandler(this.TweetItem_MouseHover);
            this.MouseEnter += new System.EventHandler(this.TweetItem_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).EndInit();
            this.ItemMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FullName;
        private System.Windows.Forms.PictureBox ProfileImage;
        private System.Windows.Forms.LinkLabel TweetText;
        private System.Windows.Forms.ContextMenuStrip ItemMenu;
        private System.Windows.Forms.ToolStripMenuItem replyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reTweetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markAsFavoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label lTime;
    }
}
