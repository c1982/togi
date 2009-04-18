namespace Togi
{
    partial class Login
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
            this.tSname = new System.Windows.Forms.TextBox();
            this.tPass = new System.Windows.Forms.TextBox();
            this.btLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lScreenName = new System.Windows.Forms.Label();
            this.lPassword = new System.Windows.Forms.Label();
            this.T1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cRemember = new System.Windows.Forms.CheckBox();
            this.lClose = new System.Windows.Forms.Label();
            this.P1 = new System.Windows.Forms.Panel();
            this.P2 = new System.Windows.Forms.Panel();
            this.lLoading = new System.Windows.Forms.Label();
            this.pLoadingIcon = new System.Windows.Forms.PictureBox();
            this.T1.SuspendLayout();
            this.P1.SuspendLayout();
            this.P2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pLoadingIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tSname
            // 
            this.tSname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T1.SetColumnSpan(this.tSname, 2);
            this.tSname.Dock = System.Windows.Forms.DockStyle.Top;
            this.tSname.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tSname.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tSname.Location = new System.Drawing.Point(3, 15);
            this.tSname.MaxLength = 50;
            this.tSname.Name = "tSname";
            this.tSname.ShortcutsEnabled = false;
            this.tSname.Size = new System.Drawing.Size(217, 23);
            this.tSname.TabIndex = 0;
            this.tSname.Text = "tellibahce";
            // 
            // tPass
            // 
            this.tPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tPass.Dock = System.Windows.Forms.DockStyle.Top;
            this.tPass.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tPass.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tPass.Location = new System.Drawing.Point(3, 70);
            this.tPass.MaxLength = 50;
            this.tPass.Name = "tPass";
            this.tPass.PasswordChar = '*';
            this.tPass.Size = new System.Drawing.Size(217, 23);
            this.tPass.TabIndex = 1;
            this.tPass.Text = "osman12";
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.Transparent;
            this.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogin.Location = new System.Drawing.Point(151, 118);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 2;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(40, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 68);
            this.label1.TabIndex = 3;
            this.label1.Text = "Togi";
            // 
            // lScreenName
            // 
            this.lScreenName.AutoSize = true;
            this.lScreenName.BackColor = System.Drawing.Color.Transparent;
            this.lScreenName.Location = new System.Drawing.Point(3, 0);
            this.lScreenName.Name = "lScreenName";
            this.lScreenName.Size = new System.Drawing.Size(72, 12);
            this.lScreenName.TabIndex = 4;
            this.lScreenName.Text = "Screen Name";
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(3, 53);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(53, 13);
            this.lPassword.TabIndex = 5;
            this.lPassword.Text = "Password";
            // 
            // T1
            // 
            this.T1.BackColor = System.Drawing.Color.Transparent;
            this.T1.ColumnCount = 1;
            this.T1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.T1.Controls.Add(this.lScreenName, 0, 0);
            this.T1.Controls.Add(this.lPassword, 0, 2);
            this.T1.Controls.Add(this.tPass, 0, 3);
            this.T1.Controls.Add(this.tSname, 1, 0);
            this.T1.Location = new System.Drawing.Point(3, 3);
            this.T1.Name = "T1";
            this.T1.RowCount = 4;
            this.T1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5942F));
            this.T1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.60714F));
            this.T1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.T1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.28571F));
            this.T1.Size = new System.Drawing.Size(223, 112);
            this.T1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(151, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Twitter Client";
            // 
            // cRemember
            // 
            this.cRemember.AutoSize = true;
            this.cRemember.BackColor = System.Drawing.Color.Transparent;
            this.cRemember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cRemember.Location = new System.Drawing.Point(6, 122);
            this.cRemember.Name = "cRemember";
            this.cRemember.Size = new System.Drawing.Size(91, 17);
            this.cRemember.TabIndex = 1;
            this.cRemember.Text = "Remember me";
            this.cRemember.UseVisualStyleBackColor = false;
            // 
            // lClose
            // 
            this.lClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lClose.AutoSize = true;
            this.lClose.BackColor = System.Drawing.Color.Transparent;
            this.lClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lClose.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lClose.ForeColor = System.Drawing.Color.LightCyan;
            this.lClose.Location = new System.Drawing.Point(223, 1);
            this.lClose.Margin = new System.Windows.Forms.Padding(0);
            this.lClose.Name = "lClose";
            this.lClose.Size = new System.Drawing.Size(18, 19);
            this.lClose.TabIndex = 3;
            this.lClose.Text = "X";
            this.lClose.Click += new System.EventHandler(this.lClose_Click);
            // 
            // P1
            // 
            this.P1.BackColor = System.Drawing.Color.Transparent;
            this.P1.Controls.Add(this.T1);
            this.P1.Controls.Add(this.btLogin);
            this.P1.Controls.Add(this.cRemember);
            this.P1.Location = new System.Drawing.Point(6, 72);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(232, 151);
            this.P1.TabIndex = 8;
            // 
            // P2
            // 
            this.P2.BackColor = System.Drawing.Color.Transparent;
            this.P2.Controls.Add(this.lLoading);
            this.P2.Controls.Add(this.pLoadingIcon);
            this.P2.Location = new System.Drawing.Point(10, 89);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(224, 83);
            this.P2.TabIndex = 10;
            this.P2.Visible = false;
            // 
            // lLoading
            // 
            this.lLoading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lLoading.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lLoading.Location = new System.Drawing.Point(0, 0);
            this.lLoading.Name = "lLoading";
            this.lLoading.Size = new System.Drawing.Size(224, 23);
            this.lLoading.TabIndex = 1;
            this.lLoading.Text = "Loading...";
            this.lLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pLoadingIcon
            // 
            this.pLoadingIcon.Image = global::Togi.Properties.Resources._32_0;
            this.pLoadingIcon.Location = new System.Drawing.Point(87, 27);
            this.pLoadingIcon.Name = "pLoadingIcon";
            this.pLoadingIcon.Size = new System.Drawing.Size(50, 50);
            this.pLoadingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pLoadingIcon.TabIndex = 0;
            this.pLoadingIcon.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(245, 260);
            this.ControlBox = false;
            this.Controls.Add(this.lClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.P1);
            this.Controls.Add(this.P2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.T1.ResumeLayout(false);
            this.T1.PerformLayout();
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.P2.ResumeLayout(false);
            this.P2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pLoadingIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tSname;
        private System.Windows.Forms.TextBox tPass;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lScreenName;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.TableLayoutPanel T1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cRemember;
        private System.Windows.Forms.Label lClose;
        private System.Windows.Forms.Panel P1;
        private System.Windows.Forms.Panel P2;
        private System.Windows.Forms.PictureBox pLoadingIcon;
        private System.Windows.Forms.Label lLoading;
    }
}