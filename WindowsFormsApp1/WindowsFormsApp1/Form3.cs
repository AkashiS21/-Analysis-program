using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private string filePath;
        private Form2 form2;

        public Form3()
        {
            InitializeComponent();
        }
        public void SetCorrelationResults(Dictionary<string, double> results)
        {
            // Здесь вы будете обрабатывать результаты и выводить их на форму
            // Например, можно добавить их в ListBox, DataGridView или вывести как текст
            // Пример с ListBox:
            foreach (var item in results)
            {
                listBox1.Items.Add($"{item.Key}: {item.Value:F4}");
            }
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
        MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.form2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
