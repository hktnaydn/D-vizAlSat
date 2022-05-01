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
    public partial class alsat : Form
    {
        public alsat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dovizsec ds = new dovizsec();
            ds.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cuzdan cuzdan = new cuzdan();
            cuzdan.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            satilacak satilacak = new satilacak();
            satilacak.Show();
            this.Close();

        }

        private void alsat_Load(object sender, EventArgs e)
        {

        }
    }
}
