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
    public partial class satilacak : Form
    {
        public satilacak()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cuzdan cuzdan = new cuzdan();
            cuzdan.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dolarsat dolarsat = new dolarsat();
            dolarsat.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eurosatt eurosatt = new eurosatt();
            eurosatt.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            steral steral = new steral();
            steral.Show();
            this.Close();
        }

        private void satilacak_Load(object sender, EventArgs e)
        {

        }
    }
}
