using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using MySql.Data.MySqlClient;

namespace DövizAlSat
{
    public partial class sifreunuttum : Form
    {
        public static string epostasifreunuttum = null;
        MySqlConnection connection = Form1.baglanti;
        static Random random = new Random();
        public static int rand_code = random.Next(10000, 99999);
        public sifreunuttum()
        {
            InitializeComponent();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "E-posta")
            {
                MessageBox.Show("Lütfen E-postanı gir");
            }
            else
            {
                string epostasi = textBox2.Text.ToString();
                connection.Open();
                MySqlCommand epostakontrol = new MySqlCommand("select email from kayit", connection);
                MySqlDataReader reader = epostakontrol.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    if (epostasi == sifrelemealg.desezar(reader["email"].ToString().Trim(), 2))
                    {
                        epostasifreunuttum = textBox2.Text.ToString();
                        i++;
                        MessageBox.Show("Kodunu yolladık kontrol et");
                        connection.Close();
                        postagonder();
                        sifrekod sk = new sifrekod();
                        sk.Show();
                        this.Close();
                        break;
                    }
                    
                }
                if (i == 0)
                    MessageBox.Show("Kayıtlarımızda böyle bir epostaya raslamadık");
                connection.Close();
            }
            



            
        }
        private void postagonder()
        {
            connection.Open();
            string musterinum = null;
            string eposta = null;
            eposta = textBox2.Text;
            MySqlCommand epostakontrol = new MySqlCommand("select musterino from kayit where email='" + sifrelemealg.sezar(eposta, 2) + "'", connection);
            MySqlDataReader reader = epostakontrol.ExecuteReader();
            while (reader.Read())
            {
                musterinum = reader["musterino"].ToString().Trim();

            }
            SmtpClient CLİENT = new SmtpClient();
            MailMessage message = new MailMessage();

            CLİENT.Credentials = new NetworkCredential("dovizalsat@hotmail.com", "Haktan123");
            CLİENT.Port = 587;
            CLİENT.Host = "smtp.live.com";
            CLİENT.EnableSsl = true;
            message.To.Add(textBox2.Text);
            message.From = new MailAddress("dovizalsat@hotmail.com", "DövizALSAT");
            message.Subject = "Müşteri numarası ve onay kodu, DövizALSAT";
            message.Body = "Onay kodun = " + rand_code+"  Müşteri numaran = "+ musterinum;
            CLİENT.Send(message);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "E-posta")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "E-posta";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
