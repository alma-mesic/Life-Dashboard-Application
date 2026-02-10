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
using System.Drawing.Drawing2D;

namespace LifeDash
{
    public partial class Form3 : Form
    {
        public Form3(string avatar1) //konstruktor
        {
            InitializeComponent();
            avatar = avatar1;
        }
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public static int score = 0;
        public static int coins = 0;
        private string avatar;

        public static int energy = 100;
        public static int focus = 50;
        public static int happiness = 75;
        int stress = 25;

        public const int maxi = 100;

        int i, j, k, p;

        public static void SetRoundCorners(Control c, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(c.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(c.Width - radius, c.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, c.Height - radius, radius, radius, 90, 90);

            c.Region = new Region(path);
        }

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
            }
        }
        
        void state() //setting photo by emotions
        {

            if (energy <= 25)
            {
                pictureBox1.Image = imageList1.Images[k]; // sleepy
                toolStripStatusLabel1.Text = "I´m so sleepy...";
            }
            else if (stress >= 70)
            {
                pictureBox1.Image = imageList1.Images[j]; // stressed
                toolStripStatusLabel1.Text = "I´m stressed out";
            }
            else if (happiness <= 30)
            {
                pictureBox1.Image = imageList1.Images[p]; // sad
                toolStripStatusLabel1.Text = "I´m so sad...";
            }
            else
            {
                pictureBox1.Image = imageList1.Images[i]; // happy
                toolStripStatusLabel1.Text = "I´m happy!";
            }
        }

        void set() // sets values when button is pressed 
        {
            energy = provjera(energy);
            focus = provjera(focus);
            stress = provjera(stress);
            happiness = provjera(happiness);

            state();
            progress(energy, focus, stress, happiness);
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            SetRoundCorners(panel1, 30);
            SetRoundCorners(panel2, 30);

            panel1.BackColor = Color.FromArgb(130, 255, 255, 255);
            panel2.BackColor = Color.FromArgb(130, 255, 255, 255);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;

            if (Form1.avatar == "Koala" || Form2.avatar == "Koala")// 4 5 6 7
            {
                pictureBox1.Image = imageList1.Images[4];
                i = 4;
                j = 5;
                k = 6;
                p = 7;
            }
            else if (Form1.avatar == "Teddy-bear" || Form2.avatar == "Teddy-bear")// 0 1 2 3
            {
                pictureBox1.Image = imageList1.Images[0];
                i = 0;
                j = 1;
                k = 2;
                p = 3;
            }
            else if (Form1.avatar == "Bunny" || Form2.avatar == "Bunny") // 8 9 10 11
            {
                pictureBox1.Image = imageList1.Images[8];
                i = 8;
                j = 9;
                k = 10;
                p = 11;
            }
            progressBar1.Maximum = 100;
            progressBar2.Maximum = 100;
            progressBar3.Maximum = 100;
            progressBar4.Maximum = 100;

            progress(energy, focus, stress, happiness);

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();

            state();
        }
       
        private void button1_Click(object sender, EventArgs e) //study button
        {
            MessageBox.Show("Studying for upcoming test...","Study",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

            energy -= 10;
            focus += 20;
            stress -= 10;
            happiness -= 5;

            set();

            score += 20;
            coins += 5;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();

        }

        private void button2_Click(object sender, EventArgs e) // train button
        {
            MessageBox.Show("Training...", "Train", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            energy -= 30;
            focus += 5;
            stress -= 25;
            happiness += 25;

            set();

            score += 25;
            coins += 10;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button3_Click(object sender, EventArgs e) // sleep button
        {
            MessageBox.Show("Sleeping...", "Sleep", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            energy += 50;
            focus += 10;
            stress -= 35;
            happiness += 25;

            set();

            score += 15;
            coins += 5;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }
        private void button4_Click(object sender, EventArgs e) // eat button
        {
            MessageBox.Show("Eating...", "Eat", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            energy += 20;
            focus += 10;
            stress -= 10;
            happiness += 10;

            set();

            score += 25;
            coins += 10;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }
        private void button5_Click(object sender, EventArgs e) // scroll tiktok button
        {
            MessageBox.Show("Scrolling tiktok...", "Scroll tiktok", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            energy -= 5;
            focus -= 30;
            stress += 20;
            happiness += 10;

            set();

            score += 10;
            coins += 0;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }
        private void button6_Click(object sender, EventArgs e) // do nothing button
        {
            MessageBox.Show("Doing nothing for a while...", "Do nothing", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            energy += 10;
            focus -= 5;
            stress += 20;
            happiness += 5;

            set();

            score += 10;
            coins += 3;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button7_Click(object sender, EventArgs e) // automatically sets energy on 0
        {
            energy = 0;
            focus = 100;
            stress = 0;
            happiness = 100;

            set();

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button8_Click(object sender, EventArgs e) // automatically sets stress on 100
        {
            stress = 100;
            energy = 100;
            focus = 100;
            happiness = 100;

            set();

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button9_Click(object sender, EventArgs e) // automatically sets happiness on 100
        {
            happiness = 100;
            energy = 100;
            focus = 100;
            stress = 0;

            set();

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button10_Click(object sender, EventArgs e) // automatically sets happiness on 0
        {
            happiness = 0;
            energy = 100;
            focus = 100;
            stress = 0;

            set();

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }
        private void dailyMissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Missions missions = new Missions();
            missions.Show();
            this.Hide();
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
            this.Hide();
        }
        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings profile = new Settings();
            profile.Show();
            this.Hide();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(comboBox1.SelectedItem.ToString() == "All")
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                button11.Visible = true;
                button12.Visible = true;
            }
            else if(comboBox1.SelectedItem.ToString() == "Productive")
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "Waste Time")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
            }
            else if (comboBox1.SelectedItem.ToString() == "Relax")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = true;
                button12.Visible = false;
            }
            else if (comboBox1.SelectedItem.ToString() == "System")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                button11.Visible = false;
                button12.Visible = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hanging out with friends...", "Socialize", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            energy -= 10;
            focus -= 10;
            stress -= 20;
            happiness += 25;

            set();

            score += 15;
            coins += 8;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cleaning and organizing...", "Organize", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            energy -= 15;
            focus += 10;
            stress -= 20;
            happiness += 10;

            set();

            score += 20;
            coins += 6;

            label5.Text = "Score: " + score.ToString();
            label6.Text = "Coins: " + coins.ToString();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.ShowDialog();
            this.Close();
        }
        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
