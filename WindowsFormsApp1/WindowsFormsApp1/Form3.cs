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
        // FIX: Uninitialized fields
        private string filePath;
        private Form2 form2;

        public Form3()
        {
            InitializeComponent();
        }

        public void SetCorrelationResults(double[,] matrix, List<string> featureColumns, List<string> targetColumns)
        {
            correlationMatrixDataGridView.Columns.Clear();
            correlationMatrixDataGridView.Rows.Clear();

            var columns = featureColumns.Concat(targetColumns).ToList();

            foreach (string column in columns)
            {
                correlationMatrixDataGridView.Columns.Add(column, column);
            }

            for (var row = 0; row < columns.Count; row++)
            {
                correlationMatrixDataGridView.Rows.Add(columns.Count);
                correlationMatrixDataGridView.Rows[row].HeaderCell.Value = columns[row];

                for (var column = 0; column < columns.Count; column++)
                {
                    correlationMatrixDataGridView.Rows[row].Cells[column].Value = matrix[row, column];
                }
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // FIX: This will throw NullReferenceException
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
