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

            Form3.SetRoundCorners(panel1, 30);
            Form3.SetRoundCorners(panel2, 30);
            Form3.SetRoundCorners(panel3, 30);
            Form3.SetRoundCorners(richTextBox1, 20);
            Form3.SetRoundCorners(richTextBox2, 20);
            Form3.SetRoundCorners(richTextBox3, 20);
            this.StartPosition = FormStartPosition.CenterScreen;
            panel1.BackColor = Color.FromArgb(130, 255, 255, 255);
            panel2.BackColor = Color.FromArgb(130, 255, 255, 255);
            panel3.BackColor = Color.FromArgb(130, 255, 255, 255);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            
            richTextBox1.SelectAll();
            richTextBox2.SelectAll();
            richTextBox3.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.DeselectAll();
            richTextBox2.DeselectAll();
            richTextBox3.DeselectAll();
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
