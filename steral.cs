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
    public partial class steral : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public steral()
        {
            InitializeComponent();
        }

        private void steral_Load(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string steral = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexBuying").InnerXml;
            usdsatlbl.Text = string.Format(steral);

            connection.Open();
            MySqlCommand sterbakiyesi = new MySqlCommand("select sterlin from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
            MySqlDataReader reader = sterbakiyesi.ExecuteReader();
            while (reader.Read())
            {
                label2.Text = reader["sterlin"].ToString().Trim();
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double eskitl = 0, kacsterlin, sonfiyat, yenibakiye, sterlineski = 0, sterlinyeni;
            if (textBox1.Text == null || textBox1.Text == "".Trim())
            {

                MessageBox.Show("Lütfen bir değer giriniz");
            }
            else
            {
                kacsterlin = Convert.ToDouble(textBox1.Text);

                string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
                var xmldoc = new XmlDocument();
                xmldoc.Load(anlik);
                string sterlinAL = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexBuying").InnerXml;

                sonfiyat = Convert.ToDouble(sterlinAL) / 10000;


                connection.Open();
                MySqlCommand tlbakiyesi = new MySqlCommand("select tl,sterlin from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
                MySqlDataReader reader = tlbakiyesi.ExecuteReader();
                while (reader.Read())
                {
                    eskitl = Convert.ToDouble(reader["tl"]);
                    sterlineski = Convert.ToDouble(reader["sterlin"]);
                }
                connection.Close();

                if (kacsterlin > sterlineski)
                {
                    MessageBox.Show("Yetersiz bakiye");
                }
                else
                {
                    yenibakiye = eskitl + kacsterlin * sonfiyat;
                    sterlinyeni = sterlineski - kacsterlin;
                    connection.Open();
                    MySqlCommand komut = new MySqlCommand("update cuzdan set tl='" + yenibakiye + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komut.ExecuteNonQuery();
                    MySqlCommand komutiki = new MySqlCommand("update cuzdan set sterlin='" + sterlinyeni + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komutiki.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(kacsterlin.ToString() + " sterlin satıldı");
                    cuzdan cuzdan = new cuzdan();
                    cuzdan.Show();
                    this.Close();

                }
            }
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
            string STERal = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexBuying").InnerXml;
            usdsatlbl.Text = string.Format(STERal);
        }
    }
}
