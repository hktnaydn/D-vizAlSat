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
    public partial class parayukle : Form
    {
        MySqlConnection connection = Form1.baglanti;
        public parayukle()
        {
            InitializeComponent();
        }

        private void parayukle_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.musterino;
            if(comboBox3.SelectedIndex==-1)
            {
                button1.Enabled = false;
            }
            
        }

        private void bakiyetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            double tl = 0, usd = 0, euro = 0, sterlin = 0, bakiyetext;
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
            if (bakiyetxt.Text == "".Trim())
            {
                MessageBox.Show("Bakiye giriniz");
            }
            else
            {
                bakiyetext = Convert.ToDouble(bakiyetxt.Text);
                int bir, iki, uc, dort, bes;
                bir = textBox2.TextLength;
                iki = textBox3.TextLength;
                uc = textBox4.TextLength;
                dort = textBox5.TextLength;
                bes = textBox6.TextLength;

                if (bir == 4 && iki == 4 && uc == 4 && dort == 4)
                {
                    string visamaster = textBox2.Text.ToString();
                    string ilksayii = visamaster.Substring(0, 1);


                    if (ilksayii == "4" || ilksayii == "5")
                    {

                        if (bes == 3)
                        {
                            if (textBox1.Text.Trim() == "")
                            {
                                MessageBox.Show("Lütfen Adınızı giriniz");
                            }
                            else
                            {
                                if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                                {
                                    MessageBox.Show("Son kullanım tarihini girmediniz");
                                }
                                else
                                {
                                    if (bakiyetxt.Text.Trim() == "")

                                    {
                                        MessageBox.Show("Lütfen yüklenecek bakiyeyi giriniz");
                                    }
                                    else
                                    {
                                        connection.Open();

                                        if (comboBox3.SelectedIndex == 0)
                                        {
                                            MySqlCommand tldegis = new MySqlCommand("update cuzdan set tl='" + (bakiyetext + tl) + "'where cuzdanno='" + Form1.musterino + "'", connection);
                                            tldegis.ExecuteNonQuery();
                                            MessageBox.Show("Başarılı bir şekilde hesabınıza aktarıldı");
                                        }
                                        else if (comboBox3.SelectedIndex == 1)
                                        {
                                            MySqlCommand usddegis = new MySqlCommand("update cuzdan set usd='" + (bakiyetext + usd) + "'where cuzdanno='" + Form1.musterino + "'", connection);
                                            usddegis.ExecuteNonQuery();
                                            MessageBox.Show("Başarılı bir şekilde hesabınıza aktarıldı");
                                        }
                                        else if (comboBox3.SelectedIndex == 2)
                                        {
                                            MySqlCommand eurdegis = new MySqlCommand("update cuzdan set eur='" + (bakiyetext + euro) + "'where cuzdanno='" + Form1.musterino + "'", connection);
                                            eurdegis.ExecuteNonQuery();
                                            MessageBox.Show("Başarılı bir şekilde hesabınıza aktarıldı");
                                        }
                                        else if (comboBox3.SelectedIndex == 3)
                                        {
                                            MySqlCommand sterdegis = new MySqlCommand("update cuzdan set sterlin='" + (bakiyetext + sterlin) + "'where cuzdanno='" + Form1.musterino + "'", connection);
                                            sterdegis.ExecuteNonQuery();
                                            MessageBox.Show("Başarılı bir şekilde hesabınıza aktarıldı");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Lütfen para birimi seçiniz");
                                        }
                                    }
                                    connection.Close();
                                    cuzdan c = new cuzdan();
                                    c.Show();
                                    this.Close();

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("CVV eksik girildi");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Kart numarası geçersiz");
                    }

                }
                else
                {
                    MessageBox.Show("Kart numaranızı eksik girdiniz");
                }
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cuzdan cuzdan = new cuzdan();
            cuzdan.Show();
            this.Close();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }
    }
}
