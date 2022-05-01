using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DövizAlSat
{
    public partial class sifredegis : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public sifredegis()
        {
            InitializeComponent();
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

        private void passtextb_Enter(object sender, EventArgs e)
        {
            if (passtextb.Text == "Parola")
            {
                passtextb.Text = "";
                passtextb.ForeColor = Color.White;
                passtextb.PasswordChar = '*';
            }
        }
        char? none = null;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (passtextb.Text == tekrarpass.Text && sifreunuttum.epostasifreunuttum==emailtextb.Text.ToString())
            {
                if (emailtextb.Text != "E-posta" && passtextb.Text != "Parola" && tekrarpass.Text != "Parola Tekrar")
                {
                    connection.Open();
                    MySqlCommand komut = new MySqlCommand("update kayit set pass='" + sifrelemealg.sezar(passtextb.Text.ToString(),2) + "'where email='" + sifrelemealg.sezar(emailtextb.Text.ToString(),2) + "'", connection);
                    komut.ExecuteNonQuery();
                    MySqlCommand komutiki = new MySqlCommand("update kayit set passtekrar='" + sifrelemealg.sezar(passtextb.Text.ToString(), 2) + "'where email='" + sifrelemealg.sezar(emailtextb.Text.ToString(), 2) + "'", connection);
                    komutiki.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Şifren Güncellendi. Giriş yapabilirsin","Döviz AL-SAT");
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Boş alanları doldurun lütfen", "DÖVİZ AL-SAT");
                }
            }
            else
            {
                MessageBox.Show("Parolalar eşleşmedi ya da e-postayı yanlış girdin", "DÖVİZ AL-SAT");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void sifredegis_Load(object sender, EventArgs e)
        {

        }
    }
}
