using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot.WindowsForms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private PlotView plotView;
        private string filePath;
        private Form2 form2;

        public Form3()
        {
            InitializeComponent();
            InitializePlot();

        }
        private void InitializePlot()
        {
            plotView = new PlotView();
            plotView.Dock = DockStyle.Fill;
            Controls.Add(plotView);
        }


        public void SetCorrelationResults(double[,] matrix, List<string> featureColumns, List<string> targetColumns)
        {
            var length = matrix.GetLength(0);
            var labels = featureColumns.Concat(targetColumns).ToList();

            foreach (var label in labels)
            {
                dataGridView.Columns.Add(label, label);
            }
            dataGridView.Rows.Add(length);

            for (int row = 0; row < length; row++)
            {
                dataGridView.Rows[row].HeaderCell.Value = labels[row];
                dataGridView.RowHeadersWidth = 250;

                for (int col = 0; col < length; col++)
                {
                    var value = matrix[row, col];
                    dataGridView.Rows[row].Cells[col].Value = value.ToString("F2");

                    var style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.FromArgb(
                            red: (int)((value + 1) * 255.0 / 2.0),
                            green: 0,
                            blue: 255 - (int)((value + 1) * 255.0 / 2.0)
                        ),
                        ForeColor = Color.White,
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                    };

                    dataGridView.Rows[row].Cells[col].Style = style;
                }
            }
            dataGridView.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var selectedRowName = dataGridView.Rows[e.RowIndex].HeaderCell.Value.ToString();
                    var selectedColumnName = dataGridView.Columns[e.ColumnIndex].HeaderText;
                    var selectedCellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); 
                    string dependencyValue = null;

                    if (double.TryParse(selectedCellValue, out double cellValue)) 
                    {
                        var dependency = $"У параметров: {selectedRowName} -> {selectedColumnName}";
                        if (cellValue > 0 && cellValue <= 0.40)
                        {
                            dependencyValue = " - небольшая зависимость друг от друга";
                        }
                        else if (cellValue > 0.40 && cellValue < 0.70)
                        {
                            dependencyValue = " - довольно высокий показатель зависимости друг от друга";
                        }
                        else if (cellValue > 0.70 && cellValue < 1)
                        {
                            dependencyValue = " - очень высокий показатель зависимости друг от друга";
                        }
                        else if (cellValue < 0 && cellValue >= -0.50)
                        {
                            dependencyValue = " -слабая зависимость";
                        }
                        else if (cellValue < -0.50 && cellValue >= -1)
                        {
                            dependencyValue = " - зависимость практически отсутствует";
                        }
                        else if (cellValue == -1)
                        {
                            dependencyValue = " - полное отсутствие зависимости";
                        }
                        else if (cellValue == 1)
                        {
                            dependencyValue = " - абсолютная зависимость";
                        }
                        MessageBox.Show(dependency + dependencyValue);
                    }
                    else
                    {
                        MessageBox.Show("Невозможно преобразовать значение ячейки в число.");
                    }
                }
            };
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

        private void plotView1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }
    }
}
