﻿using System;
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
                
                string[] columnNames = firstLine.Split(';');
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items.Cast<string>().ToList())
            {
                listBox2.Items.Add(item);
            }
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox3.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                listBox1.Items.Add(listBox3.SelectedItem);
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
        }
    }
}
