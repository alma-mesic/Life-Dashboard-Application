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

        int i, j, k;

        void progress(int energy, int focus, int stress, int happiness)
        {
            progressBar1.Value = energy;
            progressBar2.Value = focus;
            progressBar3.Value = stress;
            progressBar4.Value = happiness;
        }

        void state(int energy, int focus, int stress, int happiness, int i, int j, int k)
        {
            if (energy < 20)
            {
                pictureBox1.Image = imageList1.Images[k];
            }

        }
        private void dailyMissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if(Form1.avatar == "Koala")//3 4 5
            {
                pictureBox1.Image = imageList1.Images[3];
                i = 3;
                j = 4;
                k = 5;
            }
            else if(Form1.avatar== "Teddy-bear")// 0 1 2
            {
                pictureBox1.Image= imageList1.Images[0];
                i = 0;
                j = 1;
                k = 2;
            }
            else // 6 7 8
            {
                pictureBox1.Image=imageList1.Images[6];
                i = 6;
                j = 7;
                k = 8;
            }
            progressBar1.Maximum = 100;
            progressBar2.Maximum = 100;
            progressBar3.Maximum = 100;
            progressBar4.Maximum = 100;

            progress(energy,focus,stress,happiness);

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Studying for upcoming test...","Study",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

            energy -= 15;
            focus += 10;
            stress -= 10;
            happiness -= 15;
            if (energy < 0) energy = 0;
            if (stress < 0) stress = 0;
            if (happiness < 0) happiness = 0;
            if (focus < 0) focus = 0;

            progress(energy, focus, stress, happiness);
            state(energy,focus,stress,happiness,i,j,k);
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
