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
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private string filePath;
        private Form1 form1;
        private Form3 form3;
        

        public Form2(string filePath,Form1 form1)
        {
            this.form1 = form1;
            this.filePath = filePath;
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
            this.form1.Show();
                
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
            // Получаем список выбранных столбцов
            List<string> featureColumns = listBox2.Items.Cast<string>().ToList();
            List<string> targetColumns = listBox3.Items.Cast<string>().ToList();

            // Создаем экземпляры Parser и CorrelationAnalyzer
            Parser parser = new Parser();
            CorrelationAnalyzer analyzer = new CorrelationAnalyzer();

            // Загружаем данные из CSV файла
            DataTable data = parser.LoadDataFromCSV(filePath);

            var matrix = analyzer.AnalyzeCorrelation(data, featureColumns, targetColumns);
            Form3 form3 = new Form3();
            form3.SetCorrelationResults(matrix, featureColumns, targetColumns);
            form3.Show();
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

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox2.Items.Cast<string>().ToList())
            {
                listBox1.Items.Add(item);
            }
            listBox2.Items.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox1.Items.Clear();
            string firstLine = File.ReadLines(filePath).First();
            string[] columnNames = firstLine.Split(';');
            foreach (string columnName in columnNames)
            {
                listBox1.Items.Add(columnName);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string github = "Ссылка на проект на гитхабе:\n\n" +
                    "https://github.com/AkashiS21/-Analysis-program\n";

            MessageBox.Show(github, "GitHub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string wordFilePath = @"C:\Users\пк\kursach\-Analysis-program\WindowsFormsApp1\WindowsFormsApp1\Resources\Корреляция.docx";

            try
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Open(wordFilePath);
                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия документа: " + ex.Message);
            }
        }

        private void AnalyzeCorrelation()
        {
            //List<string> featureColumns = listBox2.Items.Cast<string>().ToList();
            //List<string> targetColumns = listBox3.Items.Cast<string>().ToList();

            //Parser parser = new Parser();
            //DataTable data = parser.LoadDataFromCSV(filePath);

            //CorrelationAnalyzer analyzer = new CorrelationAnalyzer();
            //Dictionary<string, double> correlationResults = analyzer.AnalyzeCorrelation(data, featureColumns, targetColumns);
        }
    }
}
