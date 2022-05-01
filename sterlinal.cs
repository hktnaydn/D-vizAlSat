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
    public partial class sterlinal : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public sterlinal()
        {
            InitializeComponent();
        }

        private void sterlinal_Load(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string stersat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexSelling").InnerXml;
            stersatlbl.Text = string.Format(stersat);

            connection.Open();
            MySqlCommand tlbakiyesi = new MySqlCommand("select tl from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
            MySqlDataReader reader = tlbakiyesi.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = reader["tl"].ToString().Trim();
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string tlbakiye = null;
            double bakiye, kacsterlin, sonfiyat, yenibakiye, sterlineski = 0, sterlinyeni;
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
                string stersat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexSelling").InnerXml;

                sonfiyat = Convert.ToDouble(stersat) / 10000;


                connection.Open();
                MySqlCommand tlbakiyesi = new MySqlCommand("select tl,sterlin from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
                MySqlDataReader reader = tlbakiyesi.ExecuteReader();
                while (reader.Read())
                {
                    tlbakiye = reader["tl"].ToString().Trim();
                    sterlineski = Convert.ToDouble(reader["sterlin"]);
                }
                connection.Close();


                bakiye = Convert.ToDouble(tlbakiye);
                if (kacsterlin * sonfiyat > bakiye)
                {
                    MessageBox.Show("Yetersiz bakiye");
                }
                else
                {
                    yenibakiye = bakiye - kacsterlin * sonfiyat;
                    sterlinyeni = kacsterlin + sterlineski;
                    connection.Open();
                    MySqlCommand komut = new MySqlCommand("update cuzdan set tl='" + yenibakiye + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komut.ExecuteNonQuery();
                    MySqlCommand komutiki = new MySqlCommand("update cuzdan set sterlin='" + sterlinyeni + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komutiki.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(kacsterlin.ToString() + " sterlin hesabınıza tanımlandı");
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
            string stersat = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='GBP']/ForexSelling").InnerXml;
            stersatlbl.Text = string.Format(stersat);
        }
    }
}
