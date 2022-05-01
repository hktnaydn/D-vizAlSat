using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DövizAlSat
{
    public partial class sifrekod : Form
    {
        public sifrekod()
        {
            InitializeComponent();
        }

        private void kodtxt_Enter(object sender, EventArgs e)
        {
            if (kodtxt.Text == "Kod")
            {
                kodtxt.Text = "";
                kodtxt.ForeColor = Color.White;
            }
        }

        private void kodtxt_Leave(object sender, EventArgs e)
        {
            if (kodtxt.Text == "")
            {
                kodtxt.Text = "Kod";
                kodtxt.ForeColor = Color.Silver;
            }
        }

        private void onaybuton_Click(object sender, EventArgs e)
        {
            string rasgelesayi;
           rasgelesayi=sifreunuttum.rand_code.ToString();
            if(rasgelesayi==kodtxt.Text)
            {
                MessageBox.Show("Kod Eşleşti, Devam edelim");
                sifredegis sd = new sifredegis();
                sd.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kod yanlış");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void sifrekod_Load(object sender, EventArgs e)
        {

        }
    }
}
