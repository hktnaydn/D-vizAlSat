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
    public partial class dovizsec : Form
    {
        public dovizsec()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dolaral dolaral = new dolaral();
            dolaral.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cuzdan cuzdan = new cuzdan();
            cuzdan.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            euroal euroal = new euroal();
            euroal.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sterlinal steral = new sterlinal();
            steral.Show();
            this.Close();
        }

        private void dovizsec_Load(object sender, EventArgs e)
        {

        }
    }
}
