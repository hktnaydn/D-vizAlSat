namespace DövizAlSat
{
    partial class sifredegis
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
            this.emailtextb = new System.Windows.Forms.TextBox();
            this.passtextb = new System.Windows.Forms.TextBox();
            this.tekrarpass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailtextb
            // 
            this.emailtextb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.emailtextb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailtextb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.emailtextb.ForeColor = System.Drawing.Color.Silver;
            this.emailtextb.Location = new System.Drawing.Point(292, 78);
            this.emailtextb.Margin = new System.Windows.Forms.Padding(4);
            this.emailtextb.MaxLength = 55;
            this.emailtextb.Name = "emailtextb";
            this.emailtextb.Size = new System.Drawing.Size(237, 25);
            this.emailtextb.TabIndex = 7;
            this.emailtextb.Text = "E-posta";
            this.emailtextb.Enter += new System.EventHandler(this.emailtextb_Enter);
            this.emailtextb.Leave += new System.EventHandler(this.emailtextb_Leave);
            // 
            // passtextb
            // 
            this.passtextb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.passtextb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passtextb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.passtextb.ForeColor = System.Drawing.Color.Silver;
            this.passtextb.Location = new System.Drawing.Point(292, 148);
            this.passtextb.Margin = new System.Windows.Forms.Padding(4);
            this.passtextb.MaxLength = 6;
            this.passtextb.Name = "passtextb";
            this.passtextb.Size = new System.Drawing.Size(237, 25);
            this.passtextb.TabIndex = 8;
            this.passtextb.Text = "Parola";
            this.passtextb.Enter += new System.EventHandler(this.passtextb_Enter);
            this.passtextb.Leave += new System.EventHandler(this.passtextb_Leave);
            // 
            // tekrarpass
            // 
            this.tekrarpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.tekrarpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tekrarpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.tekrarpass.ForeColor = System.Drawing.Color.Silver;
            this.tekrarpass.Location = new System.Drawing.Point(292, 208);
            this.tekrarpass.Margin = new System.Windows.Forms.Padding(4);
            this.tekrarpass.MaxLength = 6;
            this.tekrarpass.Name = "tekrarpass";
            this.tekrarpass.Size = new System.Drawing.Size(237, 25);
            this.tekrarpass.TabIndex = 9;
            this.tekrarpass.Text = "Parola Tekrar";
            this.tekrarpass.Enter += new System.EventHandler(this.tekrarpass_Enter);
            this.tekrarpass.Leave += new System.EventHandler(this.tekrarpass_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Myanmar Text", 13F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(278, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Tamamla";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::DövizAlSat.Properties.Resources.kapatttt;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(12, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 75);
            this.button4.TabIndex = 19;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // sifredegis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = global::DövizAlSat.Properties.Resources.sifresıfırla;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tekrarpass);
            this.Controls.Add(this.passtextb);
            this.Controls.Add(this.emailtextb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sifredegis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sifredegis";
            this.Load += new System.EventHandler(this.sifredegis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailtextb;
        private System.Windows.Forms.TextBox passtextb;
        private System.Windows.Forms.TextBox tekrarpass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}