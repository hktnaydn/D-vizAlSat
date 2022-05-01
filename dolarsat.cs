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
    public partial class dolarsat : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public dolarsat()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cuzdan cuzdan = new cuzdan();
            cuzdan.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string USDAL = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexBuying").InnerXml;
            usdsatlbl.Text = string.Format(USDAL);
        }

        private void dolarsat_Load(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string USDAL = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexBuying").InnerXml;
            usdsatlbl.Text = string.Format(USDAL);

            connection.Open();
            MySqlCommand usdbakiyesi = new MySqlCommand("select usd from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
            MySqlDataReader reader = usdbakiyesi.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = reader["usd"].ToString().Trim();
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            double eskitl=0, kacdolar, sonfiyat, yenibakiye, dolareski = 0, dolaryeni;
            if (textBox1.Text == null || textBox1.Text == "".Trim())
            {

                MessageBox.Show("Lütfen bir değer giriniz");
            }
            else
            {
                kacdolar = Convert.ToDouble(textBox1.Text);

                string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
                var xmldoc = new XmlDocument();
                xmldoc.Load(anlik);
                string USDAL = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexBuying").InnerXml;

                sonfiyat = Convert.ToDouble(USDAL) / 10000;


                connection.Open();
                MySqlCommand tlbakiyesi = new MySqlCommand("select tl,usd from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
                MySqlDataReader reader = tlbakiyesi.ExecuteReader();
                while (reader.Read())
                {
                    eskitl = Convert.ToDouble(reader["tl"]);
                    dolareski = Convert.ToDouble(reader["usd"]);
                }
                connection.Close();
                
                if (kacdolar > dolareski)
                {
                    MessageBox.Show("Yetersiz bakiye");
                }
                else
                {
                    yenibakiye = eskitl + kacdolar * sonfiyat;
                    dolaryeni = dolareski-kacdolar;
                    connection.Open();
                    MySqlCommand komut = new MySqlCommand("update cuzdan set tl='" + yenibakiye + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komut.ExecuteNonQuery();
                    MySqlCommand komutiki = new MySqlCommand("update cuzdan set usd='" + dolaryeni + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komutiki.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(kacdolar.ToString() + " Dolar satıldı");
                    cuzdan cuzdan = new cuzdan();
                    cuzdan.Show();
                    this.Close();

                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
