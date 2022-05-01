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
    public partial class euroal : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public euroal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tlbakiye = null;
            double bakiye, kaceuro, sonfiyat, yenibakiye, euroeski = 0, euroyeni;
            if (textBox1.Text == null || textBox1.Text == "".Trim())
            {

                MessageBox.Show("Lütfen bir değer giriniz");
            }
            else
            {
                kaceuro = Convert.ToDouble(textBox1.Text);

                string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
                var xmldoc = new XmlDocument();
                xmldoc.Load(anlik);
                string eursat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexSelling").InnerXml;
                sonfiyat = Convert.ToDouble(eursat) / 10000;


                connection.Open();
                MySqlCommand tlbakiyesi = new MySqlCommand("select tl,eur from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
                MySqlDataReader reader = tlbakiyesi.ExecuteReader();
                while (reader.Read())
                {
                    tlbakiye = reader["tl"].ToString().Trim();
                    euroeski = Convert.ToDouble(reader["eur"]);
                }
                connection.Close();


                bakiye = Convert.ToDouble(tlbakiye);
                if (kaceuro * sonfiyat > bakiye)
                {
                    MessageBox.Show("Yetersiz bakiye");
                }
                else
                {
                    yenibakiye = bakiye - kaceuro * sonfiyat;
                    euroyeni = kaceuro + euroeski;
                    connection.Open();
                    MySqlCommand komut = new MySqlCommand("update cuzdan set tl='" + yenibakiye + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komut.ExecuteNonQuery();
                    MySqlCommand komutiki = new MySqlCommand("update cuzdan set eur='" + euroyeni + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komutiki.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(kaceuro.ToString() + " euro hesabınıza tanımlandı");
                    cuzdan cuzdan = new cuzdan();
                    cuzdan.Show();
                    this.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string eursat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexSelling").InnerXml;
            eursatlbl.Text = string.Format(eursat);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cuzdan cuzdan = new cuzdan();
            cuzdan.Show();
            this.Close();
        }

        private void euroal_Load(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string eursat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexSelling").InnerXml;
            eursatlbl.Text = string.Format(eursat);

            connection.Open();
            MySqlCommand tlbakiyesi = new MySqlCommand("select tl from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
            MySqlDataReader reader = tlbakiyesi.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = reader["tl"].ToString().Trim();
            }
            connection.Close();
        }
    }
}
