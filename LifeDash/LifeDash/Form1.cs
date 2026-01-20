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

namespace LifeDash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
            textBox2.UseSystemPasswordChar = true;
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

            StreamReader sr = new StreamReader("korisnik.txt");
            string line;
            bool nasao = false;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] podaci = line.Split('|');
                if (podaci[0]==username && podaci[1] == password)
                {
                    nasao = true;
                    break;
                }
            }

            sr.Close();
            if (nasao) {
                MessageBox.Show("Login successful!");
                Form3 home = new Form3();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}
