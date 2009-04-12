namespace Togi
{
    partial class TimeLine
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeLine));
            this.tsDugmeler = new System.Windows.Forms.ToolStrip();
            this.tsRecents = new System.Windows.Forms.ToolStripButton();
            this.tsReplys = new System.Windows.Forms.ToolStripButton();
            this.tsMessages = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsCheckNewVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ts1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCheckTweets = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShorgUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowNotice = new System.Windows.Forms.ToolStripMenuItem();
            this.st2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdvanced = new System.Windows.Forms.ToolStripMenuItem();
            this.lClose = new System.Windows.Forms.Label();
            this.Tablo = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lScreenName = new System.Windows.Forms.Label();
            this.TogiNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCheckTweetsNow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.Zaman = new System.Windows.Forms.Timer(this.components);
            this.tsDugmeler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.NotifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsDugmeler
            // 
            this.tsDugmeler.BackColor = System.Drawing.Color.Transparent;
            this.tsDugmeler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsDugmeler.GripMargin = new System.Windows.Forms.Padding(1);
            this.tsDugmeler.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDugmeler.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsDugmeler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRecents,
            this.tsReplys,
            this.tsMessages,
            this.toolStripLabel1,
            this.tsSettings});
            this.tsDugmeler.Location = new System.Drawing.Point(0, 398);
            this.tsDugmeler.Name = "tsDugmeler";
            this.tsDugmeler.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsDugmeler.Size = new System.Drawing.Size(379, 28);
            this.tsDugmeler.TabIndex = 1;
            // 
            // tsRecents
            // 
            this.tsRecents.BackColor = System.Drawing.Color.Transparent;
            this.tsRecents.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tsRecents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsRecents.Image = global::Togi.Properties.Resources.Akis;
            this.tsRecents.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsRecents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRecents.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.tsRecents.Name = "tsRecents";
            this.tsRecents.Size = new System.Drawing.Size(26, 26);
            this.tsRecents.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsRecents.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsRecents.ToolTipText = "Recents";
            this.tsRecents.Click += new System.EventHandler(this.tsRecents_Click);
            // 
            // tsReplys
            // 
            this.tsReplys.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.tsReplys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsReplys.Image = global::Togi.Properties.Resources.Replies1;
            this.tsReplys.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsReplys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsReplys.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.tsReplys.Name = "tsReplys";
            this.tsReplys.Size = new System.Drawing.Size(26, 26);
            this.tsReplys.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsReplys.ToolTipText = "Replies";
            this.tsReplys.Click += new System.EventHandler(this.tsReplys_Click);
            // 
            // tsMessages
            // 
            this.tsMessages.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.tsMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMessages.Image = global::Togi.Properties.Resources.Messages1;
            this.tsMessages.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMessages.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.tsMessages.Name = "tsMessages";
            this.tsMessages.Size = new System.Drawing.Size(26, 26);
            this.tsMessages.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsMessages.ToolTipText = "Messages";
            this.tsMessages.Click += new System.EventHandler(this.tsMessages_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 25);
            this.toolStripLabel1.Text = "Durum";
            // 
            // tsSettings
            // 
            this.tsSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCheckNewVersion,
            this.tsChangeUser,
            this.ts1,
            this.tsCheckTweets,
            this.tsShorgUrl,
            this.tsShowNotice,
            this.st2,
            this.tsAdvanced});
            this.tsSettings.Image = global::Togi.Properties.Resources.Settings1;
            this.tsSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSettings.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.tsSettings.Name = "tsSettings";
            this.tsSettings.ShowDropDownArrow = false;
            this.tsSettings.Size = new System.Drawing.Size(26, 26);
            this.tsSettings.ToolTipText = "Settings";
            // 
            // tsCheckNewVersion
            // 
            this.tsCheckNewVersion.Name = "tsCheckNewVersion";
            this.tsCheckNewVersion.Size = new System.Drawing.Size(207, 22);
            this.tsCheckNewVersion.Text = "Checking for New Version";
            // 
            // tsChangeUser
            // 
            this.tsChangeUser.Name = "tsChangeUser";
            this.tsChangeUser.Size = new System.Drawing.Size(207, 22);
            this.tsChangeUser.Text = "Change User";
            this.tsChangeUser.Click += new System.EventHandler(this.tsChangeUser_Click);
            // 
            // ts1
            // 
            this.ts1.Name = "ts1";
            this.ts1.Size = new System.Drawing.Size(204, 6);
            // 
            // tsCheckTweets
            // 
            this.tsCheckTweets.Checked = true;
            this.tsCheckTweets.CheckOnClick = true;
            this.tsCheckTweets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsCheckTweets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsCheckTweets.Name = "tsCheckTweets";
            this.tsCheckTweets.ShowShortcutKeys = false;
            this.tsCheckTweets.Size = new System.Drawing.Size(207, 22);
            this.tsCheckTweets.Text = "Checking for new tweets";
            this.tsCheckTweets.CheckedChanged += new System.EventHandler(this.tsCheckTweets_CheckedChanged);
            // 
            // tsShorgUrl
            // 
            this.tsShorgUrl.Checked = true;
            this.tsShorgUrl.CheckOnClick = true;
            this.tsShorgUrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsShorgUrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsShorgUrl.Name = "tsShorgUrl";
            this.tsShorgUrl.ShowShortcutKeys = false;
            this.tsShorgUrl.Size = new System.Drawing.Size(207, 22);
            this.tsShorgUrl.Text = "Shorting Url";
            this.tsShorgUrl.CheckedChanged += new System.EventHandler(this.tsShorgUrl_CheckedChanged);
            // 
            // tsShowNotice
            // 
            this.tsShowNotice.Checked = true;
            this.tsShowNotice.CheckOnClick = true;
            this.tsShowNotice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsShowNotice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsShowNotice.Name = "tsShowNotice";
            this.tsShowNotice.ShowShortcutKeys = false;
            this.tsShowNotice.Size = new System.Drawing.Size(207, 22);
            this.tsShowNotice.Text = "Show Notifications";
            this.tsShowNotice.CheckedChanged += new System.EventHandler(this.tsShowNotice_CheckedChanged);
            // 
            // st2
            // 
            this.st2.Name = "st2";
            this.st2.Size = new System.Drawing.Size(204, 6);
            // 
            // tsAdvanced
            // 
            this.tsAdvanced.Name = "tsAdvanced";
            this.tsAdvanced.Size = new System.Drawing.Size(207, 22);
            this.tsAdvanced.Text = "Advanced";
            this.tsAdvanced.Click += new System.EventHandler(this.tsAdvanced_Click);
            // 
            // lClose
            // 
            this.lClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lClose.AutoSize = true;
            this.lClose.BackColor = System.Drawing.Color.Red;
            this.lClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lClose.ForeColor = System.Drawing.Color.White;
            this.lClose.Location = new System.Drawing.Point(361, 7);
            this.lClose.Margin = new System.Windows.Forms.Padding(3);
            this.lClose.Name = "lClose";
            this.lClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lClose.Size = new System.Drawing.Size(15, 13);
            this.lClose.TabIndex = 2;
            this.lClose.Text = "X";
            this.lClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lClose.Click += new System.EventHandler(this.lClose_Click_1);
            // 
            // Tablo
            // 
            this.Tablo.AllowDrop = true;
            this.Tablo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Tablo.AutoScroll = true;
            this.Tablo.BackColor = System.Drawing.Color.LightCyan;
            this.Tablo.ColumnCount = 1;
            this.Tablo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Tablo.Location = new System.Drawing.Point(2, 25);
            this.Tablo.Margin = new System.Windows.Forms.Padding(0);
            this.Tablo.Name = "Tablo";
            this.Tablo.RowCount = 1;
            this.Tablo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Tablo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 368F));
            this.Tablo.Size = new System.Drawing.Size(375, 368);
            this.Tablo.TabIndex = 0;
            this.Tablo.TabStop = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Togi.Properties.Resources.favicon;
            this.pictureBox1.Location = new System.Drawing.Point(2, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lScreenName
            // 
            this.lScreenName.AutoSize = true;
            this.lScreenName.BackColor = System.Drawing.Color.Transparent;
            this.lScreenName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScreenName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lScreenName.Location = new System.Drawing.Point(19, 6);
            this.lScreenName.Name = "lScreenName";
            this.lScreenName.Size = new System.Drawing.Size(37, 14);
            this.lScreenName.TabIndex = 8;
            this.lScreenName.Text = "c1982";
            // 
            // TogiNotify
            // 
            this.TogiNotify.ContextMenuStrip = this.NotifyMenu;
            this.TogiNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("TogiNotify.Icon")));
            this.TogiNotify.Text = "Togi Twitter Client";
            this.TogiNotify.Visible = true;
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeUserToolStripMenuItem,
            this.tsCheckTweetsNow,
            this.toolStripSeparator1,
            this.tsShow,
            this.tsExit});
            this.NotifyMenu.Name = "NotifyMenu";
            this.NotifyMenu.ShowImageMargin = false;
            this.NotifyMenu.Size = new System.Drawing.Size(152, 98);
            // 
            // changeUserToolStripMenuItem
            // 
            this.changeUserToolStripMenuItem.Name = "changeUserToolStripMenuItem";
            this.changeUserToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.changeUserToolStripMenuItem.Text = "Change User";
            this.changeUserToolStripMenuItem.Click += new System.EventHandler(this.tsChangeUser_Click);
            // 
            // tsCheckTweetsNow
            // 
            this.tsCheckTweetsNow.Name = "tsCheckTweetsNow";
            this.tsCheckTweetsNow.Size = new System.Drawing.Size(151, 22);
            this.tsCheckTweetsNow.Text = "Check Tweets Now";
            this.tsCheckTweetsNow.Click += new System.EventHandler(this.Zaman_Tick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // tsShow
            // 
            this.tsShow.Name = "tsShow";
            this.tsShow.Size = new System.Drawing.Size(151, 22);
            this.tsShow.Text = "Show";
            this.tsShow.Click += new System.EventHandler(this.tsShow_Click);
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(151, 22);
            this.tsExit.Text = "Exit";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // Zaman
            // 
            this.Zaman.Tick += new System.EventHandler(this.Zaman_Tick);
            // 
            // TimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(379, 426);
            this.Controls.Add(this.lScreenName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Tablo);
            this.Controls.Add(this.lClose);
            this.Controls.Add(this.tsDugmeler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeLine";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TimeLine_Load);
            this.tsDugmeler.ResumeLayout(false);
            this.tsDugmeler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.NotifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDugmeler;
        private System.Windows.Forms.ToolStripButton tsRecents;
        private System.Windows.Forms.ToolStripButton tsReplys;
        private System.Windows.Forms.ToolStripButton tsMessages;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label lClose;
        private System.Windows.Forms.TableLayoutPanel Tablo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lScreenName;
        private System.Windows.Forms.ToolStripDropDownButton tsSettings;
        private System.Windows.Forms.ToolStripMenuItem tsCheckNewVersion;
        private System.Windows.Forms.ToolStripSeparator ts1;
        private System.Windows.Forms.ToolStripMenuItem tsCheckTweets;
        private System.Windows.Forms.ToolStripMenuItem tsShorgUrl;
        private System.Windows.Forms.ToolStripMenuItem tsShowNotice;
        private System.Windows.Forms.ToolStripSeparator st2;
        private System.Windows.Forms.ToolStripMenuItem tsAdvanced;
        private System.Windows.Forms.ToolStripMenuItem tsChangeUser;
        private System.Windows.Forms.NotifyIcon TogiNotify;
        private System.Windows.Forms.Timer Zaman;
        private System.Windows.Forms.ContextMenuStrip NotifyMenu;
        private System.Windows.Forms.ToolStripMenuItem tsShow;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem changeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsCheckTweetsNow;

    }
}