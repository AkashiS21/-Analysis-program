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
using System.IO;
using static System.Net.WebRequestMethods;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
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

                    Form2 form2 = new Form2(filePath);
                    form2.Owner = this;
                    form2.Show();
                    this.Hide();
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

        }

    }
}
