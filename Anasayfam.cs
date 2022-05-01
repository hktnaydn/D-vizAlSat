using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;

namespace DövizAlSat
{
    public partial class Anasayfam : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public static string anlik;
        public Anasayfam()
        {
            InitializeComponent();
        }

        private void Anasayfam_Load(object sender, EventArgs e)
        {
            timer1.Start();



            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/ekonomi/");


            while (xmloku.Read())
            {

                if (xmloku.Name == "title")
                {
                    if (Haberler.Items.Count <= 25)
                    {
                        Haberler.Items.Add(xmloku.ReadString());
                    }
                    else
                        break;



                }

            }
            for (int i = 0; i < Haberler.Items.Count; i++)
            {
                if (Haberler.Items[i] == null || Haberler.Items[i].ToString() == "")
                {
                    Haberler.Items.RemoveAt(i);
                }
            }
        }

        private void Haberler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Haberler.SelectedItem.ToString() == "Hürriyet")
            {
                MessageBox.Show("Hürriyet Gazetesi");
            }
            else
            {
                int i = 0, a = 0;
                a = Haberler.SelectedIndex;
                string[] detaylar = new string[170];
                XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/ekonomi/");

                while (xmloku.Read())
                {

                    if (xmloku.Name == "description")
                    {
                        i++;
                        detaylar[i] = xmloku.ReadString();

                    }
                }
                MessageBox.Show(detaylar[a].ToString(), Haberler.SelectedItem.ToString());
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            cuzdan c = new cuzdan();
            c.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string USDAL = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexBuying").InnerXml;
            string USDSAT = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerXml;
            string eural = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexBuying").InnerXml;
            string eursat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexSelling").InnerXml;
            string steral = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexBuying").InnerXml;
            string stersat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexSelling").InnerXml;


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

        private void timer1_Tick(object sender, EventArgs e)
        {
            anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            DateTime tarih = Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            string USDAL = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexBuying").InnerXml;
            string USDSAT = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerXml;
            string eural = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexBuying").InnerXml;
            string eursat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexSelling").InnerXml;
            string steral = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexBuying").InnerXml;
            string stersat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexSelling").InnerXml;
            usdallbl.Text = string.Format(USDAL);
            usdsatlbl.Text = string.Format(USDSAT);
            eurallbl.Text = string.Format(eural);
            eursatlbl.Text = string.Format(eursat);
            sterlinallbl.Text = string.Format(steral);
            sterlinsatlbl.Text = string.Format(stersat);
        }

        private void sterlinallbl_Click(object sender, EventArgs e)
        {

        }

        bool hareket;
        int fare_x;
        int fare_y;
        private void Anasayfam_MouseDown(object sender, MouseEventArgs e)
        {
            hareket = true;
            fare_x = e.X;
            fare_y = e.Y;
        }


        private void Anasayfam_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (hareket)
                this.SetDesktopLocation(MousePosition.X - fare_x, MousePosition.Y - fare_y);
        }

        private void Anasayfam_MouseUp_1(object sender, MouseEventArgs e)
        {
            hareket = false;
        }
    }
}
