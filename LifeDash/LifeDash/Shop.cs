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
        private void Shop_Load(object sender, EventArgs e)
        {
            label8.Text = "Score: " + Form3.score.ToString();
            label4.Text = "Coins: " + Form3.coins.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form3.coins>= 30)
            {
                MessageBox.Show("You successfully purchased a happiness potion! 🥳", "Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Form3.coins -= 30;
                Form3.happiness += 50;

                if (Form3.happiness > Form3.maxi)
                {
                    Form3.happiness = Form3.maxi;
                }
            }
            else
            {
                MessageBox.Show("You do not have enough coins!\nGo earn some!", "Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            label8.Text = "Score: " + Form3.score.ToString();
            label4.Text = "Coins: " + Form3.coins.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form3.coins>=100)
            {
                MessageBox.Show("You successfully purchased a health potion! 🥳", "Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Form3.coins -= 100;
                Form3.energy += 50;

                if (Form3.energy > Form3.maxi)
                {
                    Form3.energy = Form3.maxi;
                }
            }
            else
            {
                MessageBox.Show("You do not have enough coins!\nGo earn some!", "Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            label8.Text = "Score: " + Form3.score.ToString();
            label4.Text = "Coins: " + Form3.coins.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form3.coins >= 15)
            {
                MessageBox.Show("You successfully purchased a focus potion! 🥳", "Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form3.coins -= 15;
                Form3.focus += 30;

                if (Form3.focus > Form3.maxi)
                {
                    Form3.focus = Form3.maxi;
                }
            }
            else
            {
                MessageBox.Show("You do not have enough coins!\nGo earn some!", "Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            label8.Text = "Score: " + Form3.score.ToString();
            label4.Text = "Coins: " + Form3.coins.ToString();
        }
    }
}
