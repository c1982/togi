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
            this.tsDugmeler = new System.Windows.Forms.ToolStrip();
            this.tsRecents = new System.Windows.Forms.ToolStripButton();
            this.tsReplys = new System.Windows.Forms.ToolStripButton();
            this.tsMessages = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.checkingForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkingForNewTweetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkingTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNotificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdvanced = new System.Windows.Forms.ToolStripMenuItem();
            this.lClose = new System.Windows.Forms.Label();
            this.Tablo = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lScreenName = new System.Windows.Forms.Label();
            this.tsDugmeler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 25);
            this.toolStripLabel1.Text = "Durum";
            // 
            // tsSettings
            // 
            this.tsSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkingForNewVersionToolStripMenuItem,
            this.toolStripSeparator2,
            this.checkingForNewTweetsToolStripMenuItem,
            this.checkingTimeToolStripMenuItem,
            this.showNotificationsToolStripMenuItem,
            this.toolStripSeparator1,
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
            // checkingForNewVersionToolStripMenuItem
            // 
            this.checkingForNewVersionToolStripMenuItem.Name = "checkingForNewVersionToolStripMenuItem";
            this.checkingForNewVersionToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.checkingForNewVersionToolStripMenuItem.Text = "Checking for New Version";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // checkingForNewTweetsToolStripMenuItem
            // 
            this.checkingForNewTweetsToolStripMenuItem.Checked = true;
            this.checkingForNewTweetsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkingForNewTweetsToolStripMenuItem.Name = "checkingForNewTweetsToolStripMenuItem";
            this.checkingForNewTweetsToolStripMenuItem.ShowShortcutKeys = false;
            this.checkingForNewTweetsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.checkingForNewTweetsToolStripMenuItem.Text = "Checking for new tweets";
            // 
            // checkingTimeToolStripMenuItem
            // 
            this.checkingTimeToolStripMenuItem.Checked = true;
            this.checkingTimeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkingTimeToolStripMenuItem.Name = "checkingTimeToolStripMenuItem";
            this.checkingTimeToolStripMenuItem.ShowShortcutKeys = false;
            this.checkingTimeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.checkingTimeToolStripMenuItem.Text = "Shorting Url";
            // 
            // showNotificationsToolStripMenuItem
            // 
            this.showNotificationsToolStripMenuItem.Checked = true;
            this.showNotificationsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNotificationsToolStripMenuItem.Name = "showNotificationsToolStripMenuItem";
            this.showNotificationsToolStripMenuItem.ShowShortcutKeys = false;
            this.showNotificationsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.showNotificationsToolStripMenuItem.Text = "Show Notifications";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // tsAdvanced
            // 
            this.tsAdvanced.Name = "tsAdvanced";
            this.tsAdvanced.Size = new System.Drawing.Size(211, 22);
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
            this.pictureBox1.Location = new System.Drawing.Point(2, 7);
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
            this.lScreenName.Location = new System.Drawing.Point(21, 8);
            this.lScreenName.Name = "lScreenName";
            this.lScreenName.Size = new System.Drawing.Size(37, 14);
            this.lScreenName.TabIndex = 8;
            this.lScreenName.Text = "c1982";
            // 
            // TimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(379, 426);
            this.ControlBox = false;
            this.Controls.Add(this.lScreenName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Tablo);
            this.Controls.Add(this.lClose);
            this.Controls.Add(this.tsDugmeler);
            this.Name = "TimeLine";
            this.Load += new System.EventHandler(this.TimeLine_Load);
            this.tsDugmeler.ResumeLayout(false);
            this.tsDugmeler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem checkingForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkingForNewTweetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkingTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNotificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsAdvanced;

    }
}