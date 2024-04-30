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
        public void SetCorrelationResults(Dictionary<string, double> correlationResults, List<string> featureColumns)
        {
            // Получаем список столбцов (целевые + признаки)
            List<string> allColumns = correlationResults.Keys.ToList();
            allColumns.AddRange(featureColumns);
            allColumns = allColumns.Distinct().ToList();

            // Создаем столбцы и строки DataGridView
            correlationMatrixDataGridView.Columns.Clear();
            correlationMatrixDataGridView.Rows.Clear();
            foreach (string column in allColumns)
            {
                correlationMatrixDataGridView.Columns.Add(column, column);
            }
            correlationMatrixDataGridView.Rows.Add(allColumns.Count);

            // Заполняем DataGridView значениями корреляции
            for (int i = 0; i < allColumns.Count; i++)
            {
                string rowColumn = allColumns[i];
                correlationMatrixDataGridView.Rows[i].HeaderCell.Value = rowColumn;
                for (int j = 0; j < allColumns.Count; j++)
                {
                    string column = allColumns[j];
                    double correlation = 0.0;
                    if (i == j)
                    {
                        correlation = 1.0; // Корреляция столбца с самим собой
                    }
                    else if (correlationResults.ContainsKey(rowColumn) && featureColumns.Contains(column))
                    {
                        correlation = correlationResults[rowColumn]; // Суммарная корреляция с признаками
                    }
                    else if (correlationResults.ContainsKey(column) && featureColumns.Contains(rowColumn))
                    {
                        correlation = correlationResults[column]; // Суммарная корреляция с признаками (симметрично)
                    }
                    correlationMatrixDataGridView.Rows[i].Cells[j].Value = correlation.ToString("F4");
                }
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
