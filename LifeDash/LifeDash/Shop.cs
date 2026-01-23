using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeDash
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) //go back button
        {
            Form3 home = new Form3();
            home.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
