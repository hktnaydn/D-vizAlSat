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
    public partial class Form1 : Form
    {
        public static string musterino = null;
        public Form1()
        {
       
            InitializeComponent();
        }
            public static  MySqlConnectionStringBuilder build=new MySqlConnectionStringBuilder();
            public static  MySqlConnection baglanti;

        private void Form1_Load(object sender, EventArgs e)
        {
                build.Server = "localhost";
                build.UserID = "root";
                build.Database = "dovizalsat";
                build.Password = "safranbolu78";
                baglanti = new MySqlConnection(build.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        bool hareket;
        int fare_x;
        int fare_y;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            hareket = true;
            fare_x = e.X;
            fare_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            hareket = false;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(hareket)
                this.SetDesktopLocation(MousePosition.X - fare_x, MousePosition.Y - fare_y);

        }

   

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Müşteri No")
            {
                textBox1.Text = "";
                textBox1.ForeColor =Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Müşteri No";
                textBox1.ForeColor = Color.Silver;
            }
        }

 
        char? none = null;
  

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        bool isThere;
        private void button2_Click(object sender, EventArgs e)
        {
            string musteri = textBox1.Text;
            string sifresi = password.Text;

           

            baglanti.Open();
               MySqlCommand command = new MySqlCommand("select * from kayit", baglanti);
               MySqlDataReader reader = command.ExecuteReader();

               while (reader.Read())
               {
                if ((musteri == sifrelemealg.desezar(reader["tcno"].ToString().Trim(),2) || musteri == reader["musterino"].ToString().Trim()) && sifresi == sifrelemealg.desezar(reader["pass"].ToString().Trim(),2))
                   {
                       isThere = true;
                       break;
                   }
                   else
                   {
                       isThere = false;
                   }
               }
               baglanti.Close();
               if(isThere)
               {
                musterino = textBox1.Text;
                   MessageBox.Show("Başarıyla giriş yaptınız", "Program");
                Anasayfam anasayfa = new Anasayfam();
                anasayfa.Show();
                this.Hide();
            }
               else
               {
                   MessageBox.Show("Giriş başarısız", "Program");
               }
            
        }

        private void password_Enter_1(object sender, EventArgs e)
        {
            if (password.Text == "Şifre")
            {
                password.Text = "";
                password.ForeColor = Color.White;
                password.PasswordChar = '*';
                 
            }
        }

        private void password_Leave_1(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Şifre";
                password.ForeColor = Color.Silver;
                password.PasswordChar = Convert.ToChar(none);
            }
        }

        private void password_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            kayitformu kayitformu = new kayitformu();
            kayitformu.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifreunuttum su = new sifreunuttum();
            su.Show();
            

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
