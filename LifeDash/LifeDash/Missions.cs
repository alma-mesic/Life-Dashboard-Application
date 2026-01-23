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
    public partial class Missions : Form
    {
        public Missions()
        {
            InitializeComponent();
        }
        string task = "",priority="";

        private int setPriority(string task) // function for seting priority
        {
            if (task.EndsWith("[H]")) return 3;
            if (task.EndsWith("[M]")) return 2;
            return 1; 
        }

        private void Missions_Load(object sender, EventArgs e)
        {
            radioButton3.Select(); //putting tasks on low priority list if user does not select otherwise
        }

        private void button1_Click(object sender, EventArgs e) //adding tasks in listbox1
        {
            if (radioButton1.Checked)
            {
                priority = "[H]";
            }
            else if (radioButton2.Checked)
            {
                priority = "[M]";
            }
            else
            {
                priority = "[L]";
            }
            task = textBox1.Text + priority;
            listBox1.Items.Add(task);
            textBox1.Clear();
        }
        private void button2_Click(object sender, EventArgs e) //deleting items from listbox1
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        private void button3_Click(object sender, EventArgs e) // sorting by alphabet
        {
            listBox1.Sorted = true;
        }
        private void button4_Click(object sender, EventArgs e) // closing the form and going to home
        {
            Form3 home = new Form3();
            home.Show();
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e) // sorting by priority
        {
            string[] items = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                items[i] = listBox1.Items[i].ToString();
            }

            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = i + 1; j < items.Length; j++)
                {
                    int p1 = setPriority(items[i]);
                    int p2 = setPriority(items[j]);
                    if (p2 > p1)
                    {
                        string temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }

            listBox1.Items.Clear();
            for (int i = 0; i < items.Length; i++)
            {
                listBox1.Items.Add(items[i]);
            }
        }

        private void button6_Click(object sender, EventArgs e) //completing the task
        {
            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
            MessageBox.Show("You successfully compleated the task:\n"+task + "!", "Task completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
