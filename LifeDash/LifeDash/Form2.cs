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
            this.Size = new Size(1100, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public static string avatar = "";
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
            panel1.BackColor = Color.FromArgb(100, 255, 255, 255);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            radioButton1.BackColor = Color.Transparent;
            radioButton2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;

            textBox1.BackColor = Color.FromArgb(240, 240, 240);

            textBox2.BackColor = Color.FromArgb(240, 240, 240);
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
            if (comboBox1.SelectedItem != null)
            {
                avatar = comboBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select an avatar!");
                return;
            }
            string gen = "";
            if (radioButton1.Checked)
            {
                gen = "Male";
            }
            else if(radioButton2.Checked)
            {
                gen = "Female";
            }
            
            if(username=="" || password=="" || birthday=="" || gen == "" || avatar==null)
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StreamWriter sw = new StreamWriter("korisnik.txt", true);
                sw.WriteLine(username + "|" + password + "|" + birthday + "|" + gen + "|" + avatar);
                sw.Close();

                MessageBox.Show("Account created!");

                Form3 home = new Form3(avatar);
                home.Show();
                this.Hide();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
