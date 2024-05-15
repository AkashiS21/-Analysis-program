using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using WindowsFormsApp1.Properties;
using WindowsFormsApp1.Service;
using Microsoft.Office.Interop.Word;
using System.Drawing.Text;
using System.Runtime.CompilerServices;




namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public System.Drawing.Point mouseLocation;
        private string filePath;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void RoundedLabel(Label label, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(label.ClientRectangle.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(label.ClientRectangle.Width - radius, label.ClientRectangle.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, label.ClientRectangle.Height - radius, radius, radius, 90, 90);
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.CloseFigure();
            label.Region = new Region(path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                

                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1; 
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    

                    string filePath = openFileDialog.FileName;
                    this.filePath = filePath;

                    Parser parser = new Parser();    
                    System.Data.DataTable data = parser.LoadDataFromCSV(filePath);
                    dataGridView1.DataSource = data;

                }

            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string authors = "Авторы приложения:\n\n" +
                     "- Чудаков Александр Дмитриевич\n" +
                     "- Жерельев Егор Иванович\n" +
                     "- Коржавина Василиса Евгеневна\n";

            MessageBox.Show(authors, "Авторы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pdfFilePath = @"C:\Users\пк\kursach\-Analysis-program\WindowsFormsApp1\WindowsFormsApp1\Resources\Руководство главное окно.pdf";

            try
            {
                
                System.Diagnostics.Process.Start(pdfFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия документа: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dalee(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0 && dataGridView1.Columns.Count > 0)
            {
                Form2 form2 = new Form2(filePath, this);
                form2.Owner = this;
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пожалуйста загрузите валидный датасет.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mouseLocation.X;
                this.Top += e.Y - mouseLocation.Y;
            }
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new System.Drawing.Point(e.X, e.Y);
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click_3(object sender, EventArgs e)
        {

        }
    }
}
