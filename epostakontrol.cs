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
using System.Net.Mail;
using System.Net;

namespace DövizAlSat
{
    public partial class epostakontrol : Form
    {
        MySqlConnection connection = Form1.baglanti;
        static Random random = new Random();
        int rand_code = random.Next(10000, 99999);
        public epostakontrol()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

            if (textBox2.Text == "Kod")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Kod";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text==rand_code.ToString())
            { 
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("Insert into kayit (adsoyad,cepno,email,tcno,pass,passtekrar) values ('" + kayitformu.adsoyad + "','" + sifrelemealg.sezar(kayitformu.cepno, 2) + "','" + sifrelemealg.sezar(kayitformu.eposta, 2) + "','" + sifrelemealg.sezar(kayitformu.tcno, 2) + "','" + sifrelemealg.sezar(kayitformu.pass, 2) + "','" + sifrelemealg.sezar(kayitformu.tekrarpassw, 2) + "')", connection);
                command.ExecuteNonQuery();
                

                    MySqlCommand musterinokomut = new MySqlCommand("select max(musterino) from kayit", connection);
                MySqlCommand komut = new MySqlCommand("Insert into cuzdan (cuzdanno,tl,usd,eur,sterlin) values ('" + musterinokomut.ExecuteScalar() + "','" +"0" + "','" + "0"+ "','" + "0" + "','" + "0" + "')", connection);
                komut.ExecuteNonQuery();
                MessageBox.Show("Tebrikler hesabınız oluşturuldu! Müşteri numaranız : " + musterinokomut.ExecuteScalar().ToString(), "DÖVİZ AL-SAT");
                    connection.Close();
                Form1 giris = new Form1();
                giris.Show();
                    this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen doğru kodu giriniz","Program");
            }


        }
        private void postagonder()
        {
            SmtpClient CLİENT = new SmtpClient();
            MailMessage message = new MailMessage();
            
            CLİENT.Credentials = new NetworkCredential("dovizalsat@hotmail.com","Haktan123");
            CLİENT.Port = 587;
            CLİENT.Host = "smtp.office365.com";
            CLİENT.EnableSsl = true;
            message.To.Add(kayitformu.eposta);
            message.From = new MailAddress("dovizalsat@hotmail.com","DövizALSAT");
            message.Subject = "Hesap Onayı, DövizALSAT";
            message.Body = "Onay kodun = "+rand_code;
            CLİENT.Send(message);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void epostakontrol_Load(object sender, EventArgs e)
        {
            postagonder();
        }

        private void epostakontrol_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
