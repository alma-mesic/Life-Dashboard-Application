using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LifeDash
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        int score = 0;
        int coins = 0;

        int energy = 100;
        int focus = 50;
        int stress = 25;
        int happiness = 75;

        int i, j, k, p;

        int provjera (int value) //making sure the values dont go over the limit
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;

            return value;
        }
        void progress(int energy, int focus, int stress, int happiness) //connecting emotions and progress bar
        {
            progressBar1.Value = energy;
            progressBar2.Value = focus;
            progressBar3.Value = stress;
            progressBar4.Value = happiness;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

           
            if (progressBar1.Value == 0 || progressBar2.Value == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = false;
            }
            if (progressBar3.Value == 100)
            {
                button3.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
            if (progressBar4.Value == 0)
            {
                button1.Enabled = false;
                button5.Enabled = false;
            }
        }
        
        void state(int energy, int focus, int stress, int happiness, int i, int j, int k, int p) //seting photo by emotions
        {
            if (stress >= 75)
            {
                pictureBox1.Image = imageList1.Images[j]; // stressed
            }
            else if (energy <= 20)
            {
                pictureBox1.Image = imageList1.Images[k]; // sleepy
            }
            else if (happiness < 20)
            {
                pictureBox1.Image = imageList1.Images[p]; // sad
            }
            else
            {
                pictureBox1.Image = imageList1.Images[i]; // happy
            }

        }

        void set(int energy, int focus, int stress, int happiness) // sets values when button is pressed 
        {
            energy = provjera(energy);
            focus = provjera(focus);
            stress = provjera(stress);
            happiness = provjera(happiness);

            state(energy, focus, stress, happiness, i, j, k, p);
            progress(energy, focus, stress, happiness);
        }

        private void dailyMissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Missions missions = new Missions();
            missions.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if(Form1.avatar == "Koala")// 4 5 6 7
            {
                pictureBox1.Image = imageList1.Images[4];
                i = 4;
                j = 5;
                k = 6;
                p = 7;
            }
            else if(Form1.avatar== "Teddy-bear")// 0 1 2 3
            {
                pictureBox1.Image= imageList1.Images[0];
                i = 0;
                j = 1;
                k = 2;
                p = 3;
            }
            else if (Form1.avatar == "Bunny") // 8 9 10 11
            {
                pictureBox1.Image=imageList1.Images[8];
                i = 8;
                j = 9;
                k = 10;
                p = 11;
            }
            progressBar1.Maximum = 100;
            progressBar2.Maximum = 100;
            progressBar3.Maximum = 100;
            progressBar4.Maximum = 100;

            progress(energy,focus,stress,happiness);

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();

            state(energy, focus, stress, happiness, i, j, k, p);

        }

        private void button2_Click(object sender, EventArgs e) // train button
        {
            MessageBox.Show("Training...", "Train", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            energy -= 40;
            focus -= 10;
            stress -= 15;
            happiness += 25;

            set(energy,focus,stress,happiness);

            score += 25;
            coins += 10;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button3_Click(object sender, EventArgs e) // sleep button
        {
            MessageBox.Show("Sleeping...", "Sleep", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            energy += 50;
            focus -= 50;
            stress -= 20;
            happiness += 35;

            set(energy, focus, stress, happiness);

            score += 15;
            coins += 5;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings profile = new Settings();
            profile.Show();
            this.Hide();
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e) // scroll tiktok button
        {
            MessageBox.Show("Scrolling tiktok...", "Scroll tiktok", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            energy -= 15;
            focus -= 25;
            stress += 15;
            happiness += 15;

            set(energy, focus, stress, happiness);

            score += 10;
            coins += 0;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // eat button
        {
            MessageBox.Show("Eating...", "Eat", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            energy += 30;
            focus += 20;
            stress -= 10;
            happiness += 25;

            set(energy, focus, stress, happiness);

            score += 25;
            coins += 10;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button6_Click(object sender, EventArgs e) // do nothing button
        {
            MessageBox.Show("Doing nothing for a while...", "Do nothing", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            energy += 20;
            focus -= 5;
            stress += 10;
            happiness += 15;

            set(energy, focus, stress, happiness);

            score += 10;
            coins += 3;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button1_Click(object sender, EventArgs e) //study button
        {
            MessageBox.Show("Studying for upcoming test...","Study",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

            energy -= 15;
            focus += 10;
            stress -= 10;
            happiness -= 15;

            set(energy, focus, stress, happiness);

            score += 20;
            coins += 5;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("korisnik.txt");
            sw.Write("score: " + score + "|coins: " + coins + "\n");
            sw.Close();

            Form1 login = new Form1();
            login.ShowDialog();
            this.Hide();
        }
    }
}
