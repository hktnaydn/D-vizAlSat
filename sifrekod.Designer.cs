namespace DövizAlSat
{
    partial class sifrekod
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
            this.onaybuton = new System.Windows.Forms.Button();
            this.kodtxt = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // onaybuton
            // 
            this.onaybuton.BackColor = System.Drawing.Color.Transparent;
            this.onaybuton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.onaybuton.Font = new System.Drawing.Font("Myanmar Text", 10F);
            this.onaybuton.ForeColor = System.Drawing.Color.Transparent;
            this.onaybuton.Location = new System.Drawing.Point(201, 191);
            this.onaybuton.Name = "onaybuton";
            this.onaybuton.Size = new System.Drawing.Size(204, 34);
            this.onaybuton.TabIndex = 1;
            this.onaybuton.Text = "Onayla";
            this.onaybuton.UseVisualStyleBackColor = false;
            this.onaybuton.Click += new System.EventHandler(this.onaybuton_Click);
            // 
            // kodtxt
            // 
            this.kodtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.kodtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kodtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.kodtxt.ForeColor = System.Drawing.Color.Silver;
            this.kodtxt.Location = new System.Drawing.Point(210, 138);
            this.kodtxt.Margin = new System.Windows.Forms.Padding(4);
            this.kodtxt.MaxLength = 11;
            this.kodtxt.Name = "kodtxt";
            this.kodtxt.Size = new System.Drawing.Size(178, 21);
            this.kodtxt.TabIndex = 12;
            this.kodtxt.Text = "Kod";
            this.kodtxt.Enter += new System.EventHandler(this.kodtxt_Enter);
            this.kodtxt.Leave += new System.EventHandler(this.kodtxt_Leave);
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
            this.button4.Size = new System.Drawing.Size(69, 61);
            this.button4.TabIndex = 13;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // sifrekod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DövizAlSat.Properties.Resources.epostakontrol2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(608, 355);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.kodtxt);
            this.Controls.Add(this.onaybuton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sifrekod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sifrekod";
            this.Load += new System.EventHandler(this.sifrekod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onaybuton;
        private System.Windows.Forms.TextBox kodtxt;
        private System.Windows.Forms.Button button4;
    }
}