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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }
        
        private void button4_Click(object sender, EventArgs e)// go back button
        {
            Form3 home = new Form3();
            home.Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e) //exit
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string oldPass = textBox2.Text;
            string newPass = textBox3.Text;
            string username = textBox1.Text;

            if(oldPass=="" || newPass == "" || username=="")
            {
                MessageBox.Show("Enter username, old password, and new password!");
                return;
            }

            StreamReader sr = new StreamReader("korisnik.txt");

            string fileContent = "";
            bool changed = false;
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                int separator = line.IndexOf('|');
                if (separator != -1)
                {
                    string[] parts = line.Split('|');
                    string user = parts[0].Trim();
                    string pass = parts[1].Trim();

                    if (user == username && pass == oldPass)
                    {
                        parts[1] = newPass;
                        changed = true;
                        textBox1.ForeColor = Color.Green;
                    }

                    line = string.Join("|", parts);
                }

                fileContent += line + "\n";
            }

            sr.Close();

            StreamWriter sw = new StreamWriter("korisnik.txt");
            sw.Write(fileContent);
            sw.Close();

            if (changed)
                MessageBox.Show("Password changed successfully!");
            else
            {
                textBox1.ForeColor = Color.Red;
                MessageBox.Show("Username not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
