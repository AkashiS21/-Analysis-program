using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WindowsFormsApp1.Service;




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
        private bool IsDigitsOnly(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void dalee(object sender, EventArgs e)
        {         
                Form2 form2 = new Form2(filePath, this);
                form2.Owner = this;
                form2.Show();
                this.Hide();
           
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

        private void button6_Click(object sender, EventArgs e)
        {
            string pdfFilePath = @"C:\Users\пк\kursach\-Analysis-program\WindowsFormsApp1\WindowsFormsApp1\Resources\github.pdf";
            try
            {
                System.Diagnostics.Process.Start(pdfFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия документа: " + ex.Message);
            }
        }
    }
}
