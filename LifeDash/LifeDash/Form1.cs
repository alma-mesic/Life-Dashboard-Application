using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace LifeDash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1100, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public static string avatar = "";
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar= true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form3.SetRoundCorners(panel1, 30);

            textBox2.UseSystemPasswordChar = true;
            panel1.BackColor = Color.FromArgb(100, 255, 255, 255);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;

            textBox1.BackColor = Color.FromArgb(240, 240, 240);

            textBox2.BackColor = Color.FromArgb(240, 240, 240);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 signupForm = new Form2();
            signupForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;  
            
            if(username=="" || password == "")
            {
                MessageBox.Show("Error!\nYou must enter username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StreamReader sr = new StreamReader("korisnik.txt");
                string line;
                bool nasao = false;

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] podaci = line.Split('|');
                    if (podaci[0] == username && podaci[1] == password)
                    {
                        avatar = podaci[4];
                        nasao = true;
                        break;
                    }
                }

                sr.Close();
                if (nasao)
                {
                    Form3 home = new Form3(avatar);
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
