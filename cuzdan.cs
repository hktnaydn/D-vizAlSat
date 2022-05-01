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
using System.Xml;

namespace DövizAlSat
{
    public partial class cuzdan : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public cuzdan()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hesapbilgileri hb = new hesapbilgileri();
            hb.Show();
            this.Hide();
        }

        private void anasayfabtn_Click(object sender, EventArgs e)
        {
            Anasayfam home = new Anasayfam();
            home.Show();
            this.Hide();
        }

        private void cuzdan_Load(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand cuzdanveri = new MySqlCommand("select tl,usd,eur,sterlin from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
            MySqlDataReader reader = cuzdanveri.ExecuteReader();
            while (reader.Read())
            {
                tllbl.Text= reader["tl"].ToString().Trim();
                usdlbl.Text = reader["usd"].ToString().Trim();
                eurlbl.Text = reader["eur"].ToString().Trim();
                gbplbl.Text = reader["sterlin"].ToString().Trim();
                
            }
            connection.Close();
        }

        private void yuklebtn_Click(object sender, EventArgs e)
        {
            parayukle py = new parayukle();
            py.Show();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string USDAL = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/BanknoteBuying").InnerXml;
            string USDSAT = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/BanknoteSelling").InnerXml;
            string eural = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/BanknoteBuying").InnerXml;
            string eursat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/BanknoteSelling").InnerXml;
            string steral = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/BanknoteBuying").InnerXml;
            string stersat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/BanknoteSelling").InnerXml;
         

            connection.Open();

            MySqlCommand bakiyekontrol = new MySqlCommand("select tl,usd,eur,sterlin from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
            MySqlDataReader reader = bakiyekontrol.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToDouble(reader["tl"]) + (Convert.ToInt32(reader["usd"]) * (Convert.ToDouble(USDSAT) / 10000)) + (Convert.ToInt32(reader["eur"]) * (Convert.ToDouble(eursat) / 10000)) + (Convert.ToInt32(reader["sterlin"]) * (Convert.ToDouble(stersat) / 10000)) > 1000)
                {
                    alsat asat = new alsat();
                    asat.Show();
                    this.Hide();
                }
                else
                {
                    Double guncelbakiye;
                    guncelbakiye = Convert.ToDouble(reader["tl"]) + (Convert.ToInt32(reader["usd"]) * (Convert.ToDouble(USDSAT) / 10000)) + (Convert.ToInt32(reader["eur"]) * (Convert.ToDouble(eursat) / 10000)) + (Convert.ToInt32(reader["sterlin"]) * (Convert.ToDouble(stersat) / 10000));
                    MessageBox.Show("İşlem yapabilmek için dövizlerinizin toplamı minimum 1000 tl olmalıdır. Güncel toplam döviziniz = " + guncelbakiye.ToString() + " Türk Lirası etmektedir");

                }


            }
            connection.Close();
        }

        private void cekbtn_Click(object sender, EventArgs e)
        {
            paracek paracek = new paracek();
            paracek.Show();
            this.Close();
        }
        bool hareket;
        int fare_x;
        int fare_y;
        private void cuzdan_MouseMove(object sender, MouseEventArgs e)
        {
            if (hareket)
                this.SetDesktopLocation(MousePosition.X - fare_x, MousePosition.Y - fare_y);
        }

        private void cuzdan_MouseUp(object sender, MouseEventArgs e)
        {
            hareket = false;
        }

        private void cuzdan_MouseDown(object sender, MouseEventArgs e)
        {
            hareket = true;
            fare_x = e.X;
            fare_y = e.Y;
        }
    }
}
