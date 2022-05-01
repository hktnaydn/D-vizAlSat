using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace DövizAlSat
{

    public partial class kayitformu : Form
    {
        static public string adsoyad { get; set; }
        static public string cepno { get; set; }
        static public string eposta { get; set; }
        static public string tcno { get; set; }
        static public string pass { get; set; }
        static public string tekrarpassw { get; set; }

        MySqlConnection connection = Form1.baglanti;
        char? none = null;
        public kayitformu()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kayitformu_Load(object sender, EventArgs e)
        {

        }
        bool hareket;
        int fare_x;
        int fare_y;
        private void kayitformu_MouseDown(object sender, MouseEventArgs e)
        {
            hareket = true;
            fare_x = e.X;
            fare_y = e.Y;
        }

        private void kayitformu_MouseMove(object sender, MouseEventArgs e)
        {
            if (hareket)
            { this.SetDesktopLocation(MousePosition.X - fare_x, MousePosition.Y - fare_y); }

        }

        private void kayitformu_MouseUp(object sender, MouseEventArgs e)
        {
            hareket = false;
        }

        private void adtextb_Enter(object sender, EventArgs e)
        {
            if (adtextb.Text == "Ad Ve Soyad")
            {
                adtextb.Text = "";
                adtextb.ForeColor = Color.White;
            }
        }

        private void adtextb_Leave(object sender, EventArgs e)
        {
            if (adtextb.Text == "")
            {
                adtextb.Text = "Ad Ve Soyad";
                adtextb.ForeColor = Color.Silver;
            }
        }

        private void emailtextb_Enter(object sender, EventArgs e)
        {
            if (emailtextb.Text == "E-posta")
            {
                emailtextb.Text = "";
                emailtextb.ForeColor = Color.White;
            }
        }

        private void emailtextb_Leave(object sender, EventArgs e)
        {
            if (emailtextb.Text == "")
            {
                emailtextb.Text = "E-posta";
                emailtextb.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Cep Telefonu")
            {
                textBox2.Text = "0";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Cep Telefonu";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kimlik Numarası")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kimlik Numarası";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void passtextb_Enter(object sender, EventArgs e)
        {
            parolaLbl.Visible = true;
            if (passtextb.Text == "Parola")
            {
                passtextb.Text = "";
                passtextb.ForeColor = Color.White;
                passtextb.PasswordChar = '*';
            }
        }

        private void passtextb_Leave(object sender, EventArgs e)
        {

            if (passtextb.Text == "")
            {
                passtextb.Text = "Parola";
                passtextb.ForeColor = Color.Silver;
                passtextb.PasswordChar = Convert.ToChar(none);
            }
        }

        private void tekrarpass_Enter(object sender, EventArgs e)
        {
            if (tekrarpass.Text == "Parola Tekrar")
            {
                tekrarpass.Text = "";
                tekrarpass.ForeColor = Color.White;
                tekrarpass.PasswordChar = '*';
            }
        }

        private void tekrarpass_Leave(object sender, EventArgs e)
        {
            if (tekrarpass.Text == "")
            {
                tekrarpass.Text = "Parola Tekrar";
                tekrarpass.ForeColor = Color.Silver;
                tekrarpass.PasswordChar = Convert.ToChar(none);
            }
        }

        private void passtextb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tekrarpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tcuzunluk = textBox1.TextLength;
            int cepnouzunluk = textBox2.TextLength;
            
            int passuzunluk = passtextb.TextLength;
            int passuzunluktekrar = tekrarpass.TextLength;
            adsoyad = adtextb.Text;
            adsoyad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(adsoyad);
            cepno = textBox2.Text;
            eposta = emailtextb.Text;
            tcno = textBox1.Text;
            pass = passtextb.Text;
            tekrarpassw = tekrarpass.Text;
            int i = 0;
            connection.Open();
            MySqlCommand epostatest = new MySqlCommand("select email from kayit where email='" + sifrelemealg.sezar(eposta, 2) + "'", connection);
            MySqlDataReader reader = epostatest.ExecuteReader();
            while (reader.Read())
            {
                if (eposta == sifrelemealg.desezar(reader["email"].ToString().Trim(), 2))
                {
                    i++;
                }

            }
            connection.Close();
            if(checkBox1.Checked==true && checkBox2.Checked==true)
            { 
            if (tcuzunluk == 11 && cepnouzunluk == 11)
            {
                if (passuzunluk == 6 && passuzunluktekrar == 6)
                {
                    if (i == 1)
                    {
                        MessageBox.Show("Bu e-posta zaten sistemimizde kayıtlı");
                    }
                    else
                    {
                        if (passtextb.Text == tekrarpass.Text)
                        {
                            if (adtextb.Text != "Ad Ve Soyad" && textBox1.Text != "Kimlik Numarası" && textBox2.Text != "Cep Telefonu" && emailtextb.Text != "E-posta" && passtextb.Text != "Parola" && tekrarpass.Text != "Parola Tekrar")
                            {
                                epostakontrol epostakontrol = new epostakontrol();
                                epostakontrol.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Boş alanları doldurun lütfen", "DÖVİZ AL-SAT");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Parolalar Eşleşmedi Tekrar Giriniz", "DÖVİZ AL-SAT");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Parolanız 6 haneden oluşmalıdır");
                }
            }
            else
            {
                MessageBox.Show("Kimlik numaranızı veya cep numaranızı yanlış girdiniz doğru giriniz");
            }
            }
            else
            {
                MessageBox.Show("Kutucukları işaretlemediniz");
            }
        }

        private void adtextb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Şirketin resmi dili İngilizce'dir. Şirket faaliyetlerinin daha ayrıntılı bir açıklaması için lütfen sitenin İngilizce versiyonunu ziyaret edin. İngilizce dışındaki dillere tercüme edilen bilgiler sadece bilgi amaçlıdır ve yasal bir kuvveti yoktur, diğer dillerde verilen bilgilerin doğruluğundan Şirket sorumlu değildir.Lütfen bu koşulları ve kuralları dikkatli okuyun.");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Şirketin resmi dili İngilizce'dir. Şirket faaliyetlerinin daha ayrıntılı bir açıklaması için lütfen sitenin İngilizce versiyonunu ziyaret edin. İngilizce dışındaki dillere tercüme edilen bilgiler sadece bilgi amaçlıdır ve yasal bir kuvveti yoktur, diğer dillerde verilen bilgilerin doğruluğundan Şirket sorumlu değildir..");
        }
    }
    }


