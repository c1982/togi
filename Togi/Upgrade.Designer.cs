namespace Togi
{
    partial class Upgrade
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lClose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "...";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.BackColor = System.Drawing.Color.Transparent;
            this.label_title.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_title.ForeColor = System.Drawing.Color.Black;
            this.label_title.Location = new System.Drawing.Point(14, 11);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(137, 14);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "Upgrade Togi Twitter Client";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.PowderBlue;
            this.progressBar1.Location = new System.Drawing.Point(17, 27);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(292, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // lClose
            // 
            this.lClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lClose.BackColor = System.Drawing.Color.LightCoral;
            this.lClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lClose.ForeColor = System.Drawing.Color.White;
            this.lClose.Location = new System.Drawing.Point(231, 54);
            this.lClose.Margin = new System.Windows.Forms.Padding(0);
            this.lClose.Name = "lClose";
            this.lClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lClose.Size = new System.Drawing.Size(78, 19);
            this.lClose.TabIndex = 1;
            this.lClose.Text = "Cancel";
            this.lClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lClose.Click += new System.EventHandler(this.lClose_Click);
            // 
            // Upgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(321, 82);
            this.ControlBox = false;
            this.Controls.Add(this.lClose);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Upgrade";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Upgrade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lClose;
    }
}