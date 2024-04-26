using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2(string filePath)
        {
            InitializeComponent();
            LoadColumnNamesFromCSV(filePath);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
            MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                Form1 form3 = new Form1();
                form3.Show();
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoadColumnNamesFromCSV(string filePath)
        {
            try
            {
                
                string firstLine = File.ReadLines(filePath).First();
                
                string[] columnNames = firstLine.Split(',');
                foreach (string columnName in columnNames)
                {
                    listBox1.Items.Add(columnName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных из файла: " + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
