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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string birthday = dateTimePicker1.Value.ToShortDateString();
            string gen="";
            if (radioButton1.Checked)
            {
                gen = "Male";
            }
            else if(radioButton2.Checked)
            {
                gen = "Female";
            }
            
            if(username=="" || password=="" || birthday=="" || gen == "")
            {
                MessageBox.Show("Please fill all fields!");
            }
            else
            {
                StreamWriter sw = new StreamWriter("korisnik.txt", true);
                sw.WriteLine(username + "|" + password + "|" + birthday + "|" + gen + "\n");
                sw.Close();

                MessageBox.Show("Account created!");

                Form3 home = new Form3();
                home.Show();
                this.Hide();

            }
        }
    }
}
