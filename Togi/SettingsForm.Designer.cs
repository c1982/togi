namespace Togi
{
    partial class SettingsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cShorUrl = new System.Windows.Forms.ComboBox();
            this.cRun = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cLang = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nCheckTime = new System.Windows.Forms.NumericUpDown();
            this.tpProxy = new System.Windows.Forms.TabPage();
            this.bProxySave = new System.Windows.Forms.Button();
            this.cProxy = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tProxyPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tProxyUser = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tProxyServer = new System.Windows.Forms.TextBox();
            this.tProxyPort = new System.Windows.Forms.TextBox();
            this.tpAbout = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCheckTime)).BeginInit();
            this.tpProxy.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tpAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tpGeneral);
            this.tabControl1.Controls.Add(this.tpProxy);
            this.tabControl1.Controls.Add(this.tpAbout);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(316, 288);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.tpGeneral.Controls.Add(this.groupBox3);
            this.tpGeneral.Controls.Add(this.cRun);
            this.tpGeneral.Controls.Add(this.groupBox2);
            this.tpGeneral.Controls.Add(this.groupBox1);
            this.tpGeneral.Location = new System.Drawing.Point(4, 25);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(308, 259);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cShorUrl);
            this.groupBox3.Location = new System.Drawing.Point(8, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 72);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Short Url Service";
            // 
            // cShorUrl
            // 
            this.cShorUrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cShorUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cShorUrl.FormattingEnabled = true;
            this.cShorUrl.Items.AddRange(new object[] {
            "tinyurl.com",
            "shorl.com",
            "url.fm",
            "kissa.be",
            "is.gd",
            "bit.ly"});
            this.cShorUrl.Location = new System.Drawing.Point(22, 30);
            this.cShorUrl.Name = "cShorUrl";
            this.cShorUrl.Size = new System.Drawing.Size(254, 21);
            this.cShorUrl.TabIndex = 1;
            this.cShorUrl.SelectedIndexChanged += new System.EventHandler(this.cShorUrl_SelectedIndexChanged);
            // 
            // cRun
            // 
            this.cRun.AutoSize = true;
            this.cRun.BackColor = System.Drawing.Color.Transparent;
            this.cRun.Checked = true;
            this.cRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cRun.Location = new System.Drawing.Point(8, 234);
            this.cRun.Name = "cRun";
            this.cRun.Size = new System.Drawing.Size(125, 17);
            this.cRun.TabIndex = 3;
            this.cRun.Text = "Run on windows start";
            this.cRun.UseVisualStyleBackColor = false;
            this.cRun.CheckedChanged += new System.EventHandler(this.cRun_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cLang);
            this.groupBox2.Location = new System.Drawing.Point(8, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Languages";
            // 
            // cLang
            // 
            this.cLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cLang.FormattingEnabled = true;
            this.cLang.Items.AddRange(new object[] {
            "Türkçe",
            "English",
            "German"});
            this.cLang.Location = new System.Drawing.Point(22, 32);
            this.cLang.Name = "cLang";
            this.cLang.Size = new System.Drawing.Size(254, 21);
            this.cLang.TabIndex = 0;
            this.cLang.SelectedIndexChanged += new System.EventHandler(this.cLang_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nCheckTime);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Checking Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Minutes";
            // 
            // nCheckTime
            // 
            this.nCheckTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nCheckTime.Location = new System.Drawing.Point(22, 19);
            this.nCheckTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nCheckTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCheckTime.Name = "nCheckTime";
            this.nCheckTime.Size = new System.Drawing.Size(52, 20);
            this.nCheckTime.TabIndex = 2;
            this.nCheckTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCheckTime.ValueChanged += new System.EventHandler(this.nCheckTime_ValueChanged);
            // 
            // tpProxy
            // 
            this.tpProxy.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.tpProxy.Controls.Add(this.bProxySave);
            this.tpProxy.Controls.Add(this.cProxy);
            this.tpProxy.Controls.Add(this.groupBox5);
            this.tpProxy.Controls.Add(this.groupBox4);
            this.tpProxy.Location = new System.Drawing.Point(4, 25);
            this.tpProxy.Name = "tpProxy";
            this.tpProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tpProxy.Size = new System.Drawing.Size(308, 259);
            this.tpProxy.TabIndex = 1;
            this.tpProxy.Text = "Proxy";
            this.tpProxy.UseVisualStyleBackColor = true;
            // 
            // bProxySave
            // 
            this.bProxySave.BackColor = System.Drawing.Color.Transparent;
            this.bProxySave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bProxySave.Location = new System.Drawing.Point(225, 228);
            this.bProxySave.Name = "bProxySave";
            this.bProxySave.Size = new System.Drawing.Size(75, 23);
            this.bProxySave.TabIndex = 7;
            this.bProxySave.Text = "Save";
            this.bProxySave.UseVisualStyleBackColor = false;
            this.bProxySave.Click += new System.EventHandler(this.bProxySave_Click);
            // 
            // cProxy
            // 
            this.cProxy.AutoSize = true;
            this.cProxy.BackColor = System.Drawing.Color.Transparent;
            this.cProxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cProxy.Location = new System.Drawing.Point(9, 7);
            this.cProxy.Name = "cProxy";
            this.cProxy.Size = new System.Drawing.Size(93, 17);
            this.cProxy.TabIndex = 6;
            this.cProxy.Text = "Use web proxy";
            this.cProxy.UseVisualStyleBackColor = false;
            this.cProxy.CheckedChanged += new System.EventHandler(this.cProxy_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.tableLayoutPanel1);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Location = new System.Drawing.Point(9, 116);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(291, 107);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Proxy Account";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tProxyPass, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tProxyUser, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(29, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(230, 79);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Username";
            // 
            // tProxyPass
            // 
            this.tProxyPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tProxyPass.Location = new System.Drawing.Point(3, 55);
            this.tProxyPass.Name = "tProxyPass";
            this.tProxyPass.Size = new System.Drawing.Size(224, 20);
            this.tProxyPass.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Password";
            // 
            // tProxyUser
            // 
            this.tProxyUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tProxyUser.Location = new System.Drawing.Point(3, 16);
            this.tProxyUser.Name = "tProxyUser";
            this.tProxyUser.Size = new System.Drawing.Size(224, 20);
            this.tProxyUser.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tProxyServer);
            this.groupBox4.Controls.Add(this.tProxyPort);
            this.groupBox4.Location = new System.Drawing.Point(8, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(292, 80);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Proxy Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Port Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ip Address";
            // 
            // tProxyServer
            // 
            this.tProxyServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tProxyServer.Location = new System.Drawing.Point(33, 42);
            this.tProxyServer.Name = "tProxyServer";
            this.tProxyServer.Size = new System.Drawing.Size(139, 20);
            this.tProxyServer.TabIndex = 0;
            // 
            // tProxyPort
            // 
            this.tProxyPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tProxyPort.Location = new System.Drawing.Point(178, 42);
            this.tProxyPort.Name = "tProxyPort";
            this.tProxyPort.Size = new System.Drawing.Size(79, 20);
            this.tProxyPort.TabIndex = 3;
            // 
            // tpAbout
            // 
            this.tpAbout.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.tpAbout.Controls.Add(this.pictureBox1);
            this.tpAbout.Controls.Add(this.label2);
            this.tpAbout.Controls.Add(this.label1);
            this.tpAbout.Location = new System.Drawing.Point(4, 25);
            this.tpAbout.Name = "tpAbout";
            this.tpAbout.Size = new System.Drawing.Size(308, 259);
            this.tpAbout.TabIndex = 2;
            this.tpAbout.Text = "About";
            this.tpAbout.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Togi.Properties.Resources.powered_by_twitter_sig;
            this.pictureBox1.Location = new System.Drawing.Point(168, 245);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 11);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version: 1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(96, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oğuzhan YILMAZ\r\naspsrc@gmail.com\r\nwww.oguzhan.info/togi\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(316, 288);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.tabControl1.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCheckTime)).EndInit();
            this.tpProxy.ResumeLayout(false);
            this.tpProxy.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tpAbout.ResumeLayout(false);
            this.tpAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpProxy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cShorUrl;
        private System.Windows.Forms.CheckBox cRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cLang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tpAbout;
        private System.Windows.Forms.NumericUpDown nCheckTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tProxyServer;
        private System.Windows.Forms.TextBox tProxyPort;
        private System.Windows.Forms.TextBox tProxyPass;
        private System.Windows.Forms.TextBox tProxyUser;
        private System.Windows.Forms.CheckBox cProxy;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bProxySave;
        private System.Windows.Forms.Label label7;
    }
}