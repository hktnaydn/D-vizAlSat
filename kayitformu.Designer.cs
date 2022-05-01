namespace DövizAlSat
{
    partial class kayitformu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.adtextb = new System.Windows.Forms.TextBox();
            this.emailtextb = new System.Windows.Forms.TextBox();
            this.passtextb = new System.Windows.Forms.TextBox();
            this.tekrarpass = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.parolaLbl = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Myanmar Text", 13F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(276, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Devam Et";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::DövizAlSat.Properties.Resources.kapaat;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(13, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 37);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // adtextb
            // 
            this.adtextb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.adtextb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adtextb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.adtextb.ForeColor = System.Drawing.Color.Silver;
            this.adtextb.Location = new System.Drawing.Point(285, 101);
            this.adtextb.Margin = new System.Windows.Forms.Padding(4);
            this.adtextb.MaxLength = 55;
            this.adtextb.Name = "adtextb";
            this.adtextb.Size = new System.Drawing.Size(237, 25);
            this.adtextb.TabIndex = 5;
            this.adtextb.Text = "Ad Ve Soyad";
            this.adtextb.Enter += new System.EventHandler(this.adtextb_Enter);
            this.adtextb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.adtextb_KeyPress);
            this.adtextb.Leave += new System.EventHandler(this.adtextb_Leave);
            // 
            // emailtextb
            // 
            this.emailtextb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.emailtextb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailtextb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.emailtextb.ForeColor = System.Drawing.Color.Silver;
            this.emailtextb.Location = new System.Drawing.Point(285, 173);
            this.emailtextb.Margin = new System.Windows.Forms.Padding(4);
            this.emailtextb.MaxLength = 55;
            this.emailtextb.Name = "emailtextb";
            this.emailtextb.Size = new System.Drawing.Size(237, 25);
            this.emailtextb.TabIndex = 6;
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
            this.passtextb.Location = new System.Drawing.Point(285, 246);
            this.passtextb.Margin = new System.Windows.Forms.Padding(4);
            this.passtextb.MaxLength = 6;
            this.passtextb.Name = "passtextb";
            this.passtextb.Size = new System.Drawing.Size(237, 25);
            this.passtextb.TabIndex = 7;
            this.passtextb.Text = "Parola";
            this.passtextb.Enter += new System.EventHandler(this.passtextb_Enter);
            this.passtextb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passtextb_KeyPress);
            this.passtextb.Leave += new System.EventHandler(this.passtextb_Leave);
            // 
            // tekrarpass
            // 
            this.tekrarpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.tekrarpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tekrarpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.tekrarpass.ForeColor = System.Drawing.Color.Silver;
            this.tekrarpass.Location = new System.Drawing.Point(285, 319);
            this.tekrarpass.Margin = new System.Windows.Forms.Padding(4);
            this.tekrarpass.MaxLength = 6;
            this.tekrarpass.Name = "tekrarpass";
            this.tekrarpass.Size = new System.Drawing.Size(237, 25);
            this.tekrarpass.TabIndex = 8;
            this.tekrarpass.Text = "Parola Tekrar";
            this.tekrarpass.Enter += new System.EventHandler(this.tekrarpass_Enter);
            this.tekrarpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tekrarpass_KeyPress);
            this.tekrarpass.Leave += new System.EventHandler(this.tekrarpass_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox1.ForeColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(555, 173);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MaxLength = 11;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 25);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Kimlik Numarası";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox2.ForeColor = System.Drawing.Color.Silver;
            this.textBox2.Location = new System.Drawing.Point(53, 173);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.MaxLength = 11;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(194, 25);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Cep Telefonu";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // parolaLbl
            // 
            this.parolaLbl.AutoSize = true;
            this.parolaLbl.BackColor = System.Drawing.Color.Transparent;
            this.parolaLbl.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.parolaLbl.ForeColor = System.Drawing.Color.White;
            this.parolaLbl.Location = new System.Drawing.Point(550, 248);
            this.parolaLbl.Name = "parolaLbl";
            this.parolaLbl.Size = new System.Drawing.Size(245, 26);
            this.parolaLbl.TabIndex = 11;
            this.parolaLbl.Text = "*6 haneli *Sadece rakam";
            this.parolaLbl.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.checkBox1.Location = new System.Drawing.Point(522, 420);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(522, 443);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(160, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Gizlilik Sözleşmesi\'ni okudum ve kabul ediyorum.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(190, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ana Sözleşme\'yi okudum ve kabul ediyorum.";
            // 
            // kayitformu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DövizAlSat.Properties.Resources.kayitekrannn1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(805, 485);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.parolaLbl);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tekrarpass);
            this.Controls.Add(this.passtextb);
            this.Controls.Add(this.emailtextb);
            this.Controls.Add(this.adtextb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kayitformu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "kayitformu";
            this.Load += new System.EventHandler(this.kayitformu_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kayitformu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.kayitformu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.kayitformu_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox emailtextb;
        private System.Windows.Forms.TextBox passtextb;
        private System.Windows.Forms.TextBox tekrarpass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label parolaLbl;
        private System.Windows.Forms.TextBox adtextb;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}