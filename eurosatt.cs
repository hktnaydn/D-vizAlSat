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
    public partial class eurosatt : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public eurosatt()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void eurosatt_Load(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string euroal = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexBuying").InnerXml;
            usdsatlbl.Text = string.Format(euroal);

            connection.Open();
            MySqlCommand EURObakiyesi = new MySqlCommand("select eur from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
            MySqlDataReader reader = EURObakiyesi.ExecuteReader();
            while (reader.Read())
            {
                label2.Text = reader["eur"].ToString().Trim();
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string euroal = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexBuying").InnerXml;
            usdsatlbl.Text = string.Format(euroal);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double eskitl = 0, kaceuro, sonfiyat, yenibakiye, euroeski = 0, euroyeni;
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
                string EUROAL = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='EUR']/ForexBuying").InnerXml;

                sonfiyat = Convert.ToDouble(EUROAL) / 10000;


                connection.Open();
                MySqlCommand tlbakiyesi = new MySqlCommand("select tl,eur from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
                MySqlDataReader reader = tlbakiyesi.ExecuteReader();
                while (reader.Read())
                {
                    eskitl = Convert.ToDouble(reader["tl"]);
                    euroeski = Convert.ToDouble(reader["eur"]);
                }
                connection.Close();

                if (kaceuro > euroeski)
                {
                    MessageBox.Show("Yetersiz bakiye");
                }
                else
                {
                    yenibakiye = eskitl + kaceuro * sonfiyat;
                    euroyeni = euroeski - kaceuro;
                    connection.Open();
                    MySqlCommand komut = new MySqlCommand("update cuzdan set tl='" + yenibakiye + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komut.ExecuteNonQuery();
                    MySqlCommand komutiki = new MySqlCommand("update cuzdan set eur='" + euroyeni + "'where cuzdanno='" + Form1.musterino + "'", connection);
                    komutiki.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(kaceuro.ToString() + " euro satıldı");
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
