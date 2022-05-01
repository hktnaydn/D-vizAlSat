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
    public partial class dolaral : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public dolaral()
        {
            InitializeComponent();
        }

        private void usdsatlbl_Click(object sender, EventArgs e)
        {

        }

        private void dolaral_Load(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string USDSAT = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerXml;
            usdsatlbl.Text = string.Format(USDSAT);

            connection.Open();
            MySqlCommand tlbakiyesi = new MySqlCommand("select tl from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
            MySqlDataReader reader = tlbakiyesi.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = reader["tl"].ToString().Trim();
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlik);
            string USDSAT = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerXml;
            usdsatlbl.Text = string.Format(USDSAT);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tlbakiye=null;
            double bakiye,kacdolar,sonfiyat,yenibakiye,dolareski=0,dolaryeni;
            if(textBox1.Text==null || textBox1.Text=="".Trim())
            {

                MessageBox.Show("Lütfen bir değer giriniz");
            }
            else { 
                        kacdolar = Convert.ToDouble(textBox1.Text);

                        string anlik = "https://www.tcmb.gov.tr/kurlar/today.xml";
                        var xmldoc = new XmlDocument();
                        xmldoc.Load(anlik);
                        string USDSAT = xmldoc.SelectSingleNode("//Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerXml;

                        sonfiyat = Convert.ToDouble(USDSAT)/10000;


                        connection.Open();
                        MySqlCommand tlbakiyesi = new MySqlCommand("select tl,usd from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
                        MySqlDataReader reader = tlbakiyesi.ExecuteReader();
                        while (reader.Read())
                        {
                            tlbakiye = reader["tl"].ToString().Trim();
                            dolareski = Convert.ToDouble(reader["usd"]);
                        }
                        connection.Close();

                        
                        bakiye = Convert.ToDouble(tlbakiye);
                        if(kacdolar*sonfiyat>bakiye)
                        {
                            MessageBox.Show("Yetersiz bakiye");
                        }
                        else
                        {
                                yenibakiye = bakiye - kacdolar * sonfiyat;
                                dolaryeni = kacdolar + dolareski;
                                connection.Open();
                                MySqlCommand komut = new MySqlCommand("update cuzdan set tl='" + yenibakiye + "'where cuzdanno='" + Form1.musterino + "'", connection);
                                komut.ExecuteNonQuery();
                                MySqlCommand komutiki = new MySqlCommand("update cuzdan set usd='" +dolaryeni+ "'where cuzdanno='" + Form1.musterino + "'", connection);
                                komutiki.ExecuteNonQuery();
                                connection.Close();
                                MessageBox.Show(kacdolar.ToString()+" Dolar hesabınıza tanımlandı");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
