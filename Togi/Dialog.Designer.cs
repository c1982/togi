namespace Togi
{
    partial class Dialog
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
            this.txtGuncelle = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.lblTolerans = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGuncelle
            // 
            this.txtGuncelle.BackColor = System.Drawing.Color.White;
            this.txtGuncelle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGuncelle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelle.ForeColor = System.Drawing.Color.Gray;
            this.txtGuncelle.Location = new System.Drawing.Point(12, 30);
            this.txtGuncelle.MaxLength = 512;
            this.txtGuncelle.Multiline = true;
            this.txtGuncelle.Name = "txtGuncelle";
            this.txtGuncelle.Size = new System.Drawing.Size(332, 67);
            this.txtGuncelle.TabIndex = 0;
            this.txtGuncelle.TextChanged += new System.EventHandler(this.txtGuncelle_TextChanged);
            this.txtGuncelle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGuncelle_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Togi.Properties.Resources.arr;
            this.pictureBox2.Location = new System.Drawing.Point(205, 97);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 11);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pPicture
            // 
            this.pPicture.BackColor = System.Drawing.Color.Transparent;
            this.pPicture.Location = new System.Drawing.Point(194, 110);
            this.pPicture.Name = "pPicture";
            this.pPicture.Size = new System.Drawing.Size(48, 48);
            this.pPicture.TabIndex = 9;
            this.pPicture.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Togi.Properties.Resources.favicon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // LabelUserName
            // 
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.BackColor = System.Drawing.Color.Transparent;
            this.LabelUserName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUserName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LabelUserName.Location = new System.Drawing.Point(30, 13);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(33, 14);
            this.LabelUserName.TabIndex = 11;
            this.LabelUserName.Text = "user";
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Transparent;
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bClose.ForeColor = System.Drawing.Color.White;
            this.bClose.Location = new System.Drawing.Point(341, -3);
            this.bClose.Margin = new System.Windows.Forms.Padding(0);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(12, 18);
            this.bClose.TabIndex = 2;
            this.bClose.Text = "X";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bUpdate.BackColor = System.Drawing.Color.Transparent;
            this.bUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bUpdate.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.bUpdate.FlatAppearance.BorderSize = 0;
            this.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bUpdate.ForeColor = System.Drawing.Color.PowderBlue;
            this.bUpdate.Location = new System.Drawing.Point(287, 100);
            this.bUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(57, 22);
            this.bUpdate.TabIndex = 1;
            this.bUpdate.Text = "Update";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // lblTolerans
            // 
            this.lblTolerans.AutoEllipsis = true;
            this.lblTolerans.AutoSize = true;
            this.lblTolerans.BackColor = System.Drawing.Color.Transparent;
            this.lblTolerans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTolerans.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTolerans.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTolerans.Location = new System.Drawing.Point(9, 100);
            this.lblTolerans.Name = "lblTolerans";
            this.lblTolerans.Size = new System.Drawing.Size(25, 14);
            this.lblTolerans.TabIndex = 12;
            this.lblTolerans.Text = "140";
            // 
            // Dialog
            // 
            this.AcceptButton = this.bUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Togi.Properties.Resources.bg2;
            this.CancelButton = this.bClose;
            this.ClientSize = new System.Drawing.Size(354, 163);
            this.ControlBox = false;
            this.Controls.Add(this.lblTolerans);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.LabelUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pPicture);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtGuncelle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Dialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Dialog_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dialog_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dialog_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGuncelle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelUserName;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Label lblTolerans;
    }
}