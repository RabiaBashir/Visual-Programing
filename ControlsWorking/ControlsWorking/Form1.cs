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

namespace ControlsWorking
{
    public partial class Form1 : Form
    { 

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if(comboBox1.SelectedItem=="Countries")
            {
                comboBox2.Items.Add("Iran");
                comboBox2.Items.Add("Pakistan");
            }
                
            else if(comboBox1.SelectedItem=="Cities")
            {
                comboBox2.Items.Add("Karachi");
                comboBox2.Items.Add("Lahore");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Countries");
            comboBox1.Items.Add("Cities");
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Cities");
            comboBox1.SelectedIndex = 1;
            radioButton1.Checked = true;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Both;
            checkBox1.Checked = true;
            listBox1.Items.Add("Monday");
            listBox1.Items.Add("Tuesday");
            listBox1.Items.Add("Wednesday");
            listBox1.SelectionMode = SelectionMode.MultiSimple;
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result=comboBox1.Text;
            MessageBox.Show(result);
        }

       
            

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                MessageBox.Show("You select PAKISTAN");
            }
            else if(radioButton2.Checked==true)
            {
                MessageBox.Show("You select AMERICA");
            }
            else 
            {
                MessageBox.Show("You select SOUTH AFRICA");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           DateTime DT =dateTimePicker1.Value;
           MessageBox.Show("YOU SELECT"+DT);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            for(int i=0;i<100;i++)
            {
                progressBar1.Value=i;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("c:\\blue_piece.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                MessageBox.Show("You select Red");
            }
            else if(checkBox2.Checked==true)
            {
                MessageBox.Show("You select Green");
            }
            else
            {
                MessageBox.Show("You select Black");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach(Object result in listBox1.SelectedItems)
            {
                MessageBox.Show(result.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                string filename = ofd.FileName;
                MessageBox.Show(filename);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           string res =saveFileDialog1.FileName;
           File.WriteAllText(res,"test");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        }
    }

