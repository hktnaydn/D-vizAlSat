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

namespace DövizAlSat
{
    public partial class paracek : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public paracek()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cuzdan cuzdan = new cuzdan();
            cuzdan.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                textBox1.Text = "TR";
            }
        }

        private void paracek_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Bankayı ve para birimini seçiniz");
            }
            else if(textBox3.TextLength!=24)
            {
                MessageBox.Show("İban'ı eksiksiz giriniz");
            }
            else if(textBox2.TextLength==0)
            {
                MessageBox.Show("Lütfen çekmek istediğiniz tutarı giriniz");
            }
            else
            {
                connection.Open();
                double tl = 0, usd = 0, euro = 0, sterlin = 0, bakiyetext=0;
                bakiyetext = Convert.ToDouble(textBox2.Text);
                MySqlCommand bakiyeler = new MySqlCommand("select tl,usd,eur,sterlin from cuzdan where cuzdanno='" + Form1.musterino + "'", connection);
                MySqlDataReader reader = bakiyeler.ExecuteReader();
                while (reader.Read())
                {
                    tl = Convert.ToDouble(reader["tl"]);
                    usd = Convert.ToDouble(reader["usd"]);
                    euro = Convert.ToDouble(reader["eur"]);
                    sterlin = Convert.ToDouble(reader["sterlin"]);
                }
                connection.Close();

                connection.Open();
                if (comboBox2.SelectedIndex == 0)
                {
                    if(bakiyetext>tl)
                    {
                        MessageBox.Show("Tutar geçersiz");
                    }
                    else
                    {
                        MySqlCommand tldegis = new MySqlCommand("update cuzdan set tl='" + (tl - bakiyetext) + "'where cuzdanno='" + Form1.musterino + "'", connection);
                        tldegis.ExecuteNonQuery();
                        MessageBox.Show("İşleminiz onaylandı. İyi Günler");
                        connection.Close();
                        cuzdan cuzdan = new cuzdan();
                        cuzdan.Show();
                        this.Close();
                    }
                    
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    if (bakiyetext > usd)
                    {
                        MessageBox.Show("Tutar geçersiz");
                    }
                    else
                    {
                        MySqlCommand usddegis = new MySqlCommand("update cuzdan set usd='" + (usd - bakiyetext) + "'where cuzdanno='" + Form1.musterino + "'", connection);
                        usddegis.ExecuteNonQuery();
                        MessageBox.Show("İşleminiz onaylandı. İyi Günler");
                        connection.Close();
                        cuzdan cuzdan = new cuzdan();
                        cuzdan.Show();
                        this.Close();
                    }
                    
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    if (bakiyetext > euro)
                    {
                        MessageBox.Show("Tutar geçersiz");
                    }
                    else {
                        MySqlCommand eurdegis = new MySqlCommand("update cuzdan set eur='" + (euro - bakiyetext) + "'where cuzdanno='" + Form1.musterino + "'", connection);
                        eurdegis.ExecuteNonQuery();
                        MessageBox.Show("İşleminiz onaylandı. İyi Günler");
                        connection.Close();
                        cuzdan cuzdan = new cuzdan();
                        cuzdan.Show();
                        this.Close();
                    }
                    
                }
                else if (comboBox2.SelectedIndex == 3)
                {
                    if (bakiyetext > sterlin)
                    {
                        MessageBox.Show("Tutar geçersiz");
                    }
                    else
                    {
                        MySqlCommand sterdegis = new MySqlCommand("update cuzdan set sterlin='" + (sterlin - bakiyetext) + "'where cuzdanno='" + Form1.musterino + "'", connection);
                        sterdegis.ExecuteNonQuery();
                        MessageBox.Show("İşleminiz onaylandı. İyi Günler");
                        connection.Close();
                        cuzdan cuzdan = new cuzdan();
                        cuzdan.Show();
                        this.Close();
                    }
                   
                }
            }
            connection.Close();
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
