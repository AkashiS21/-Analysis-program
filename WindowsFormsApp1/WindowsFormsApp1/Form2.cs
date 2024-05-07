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
                    listBox4.Items.Add(columnName);
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (listBox5.Items.Count == 0 || listBox3.Items.Count == 0)
            {
                MessageBox.Show("Выбирите хотя бы один параметр и одну цель <3", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<string> featureColumns = listBox5.Items.Cast<string>().ToList();
                List<string> targetColumns = listBox3.Items.Cast<string>().ToList();


                Parser parser = new Parser();
                CorrelationAnalyzer analyzer = new CorrelationAnalyzer();


                DataTable data = parser.LoadDataFromCSV(filePath);

                var matrix = analyzer.AnalyzeCorrelation(data, featureColumns, targetColumns);
                Form3 form3 = new Form3();
                form3.SetCorrelationResults(matrix, featureColumns, targetColumns);
                form3.Show();
            }
            

        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count < 2) 
            {
                MessageBox.Show("Количество параметров должно быть не меньше двух <3","Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<string> featureColumns = listBox5.Items.Cast<string>().ToList();
                List<string> targetColumns = listBox3.Items.Cast<string>().ToList();


                Parser parser = new Parser();
                CorrelationAnalyzer analyzer = new CorrelationAnalyzer();


                DataTable data = parser.LoadDataFromCSV(filePath);

                var matrix = analyzer.AnalyzeCorrelation(data, featureColumns, targetColumns);
                var x = 0;
                var y = 1;

                ScatterPlotForm scatterplotform = new ScatterPlotForm(data, x, y);
                scatterplotform.Show();
            }
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
            string pdfFilePath = @"C:\Users\пк\kursach\-Analysis-program\WindowsFormsApp1\WindowsFormsApp1\Resources\Руководство корреляция.pdf";

            try
            {
                // Открыть PDF-файл
                System.Diagnostics.Process.Start(pdfFilePath);
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

            //TODO сделать пейджи отдельно для графика и для матрицы
            //TODO 2 пейдж матрица(корреляция только в матрице), элементы: 3 листа, стрелки, кнопки "параметры", "гитхаб", "построить матрицу", "сброс", "информация для пользователя", реализовать ограничение минимум 1 таргет
            //TODO 1 пейдж график, элементы: 2 листа, таргета нет, ограничение на 2 параметра максимум. кнопки "гитхаб", "построить график", "сброс", "информация для пользователя"
            // в форме 3 матрица сделать пояснения к ячейкам снизу либо в ячейках через меседжбокс
            // реализовать полноэкранный режим на всех формах.

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                listBox4.Items.Add(listBox3.SelectedItem);
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem != null)
            {
                listBox5.Items.Add(listBox4.SelectedItem);
                listBox4.Items.Remove(listBox4.SelectedItem);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem != null)
            {
                listBox3.Items.Add(listBox4.SelectedItem);
                listBox4.Items.Remove(listBox4.SelectedItem);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedItem != null)
            {
                listBox4.Items.Add(listBox5.SelectedItem);
                listBox5.Items.Remove(listBox5.SelectedItem);
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            foreach (var item in listBox5.Items.Cast<string>().ToList())
            {
                listBox4.Items.Add(item);
            }
            listBox5.Items.Clear();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            foreach (var item in listBox4.Items.Cast<string>().ToList())
            {
                listBox5.Items.Add(item);
            }
            listBox4.Items.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            string firstLine = File.ReadLines(filePath).First();
            string[] columnNames = firstLine.Split(';');
            foreach (string columnName in columnNames)
            {
                listBox4.Items.Add(columnName);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string pdfFilePath = @"C:\Users\пк\kursach\-Analysis-program\WindowsFormsApp1\WindowsFormsApp1\Resources\Руководство корреляция.pdf";

            try
            {
                // Открыть PDF-файл
                System.Diagnostics.Process.Start(pdfFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия документа: " + ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string github = "Ссылка на проект на гитхабе:\n\n" +
                    "https://github.com/AkashiS21/-Analysis-program\n";

            MessageBox.Show(github, "GitHub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
