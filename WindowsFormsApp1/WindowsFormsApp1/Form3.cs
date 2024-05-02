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

            /*var model = new PlotModel { Title = "HeatMapSeries" };
            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(500), HighColor = OxyColors.Gray, LowColor = OxyColors.Black });
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                MinorStep = 1,
                ItemsSource = featureColumns,
                LabelField = "Item1",
                GapWidth = 0.5,
                Minimum = -1
            };
            model.Axes.Add(categoryAxis);

            var hms = new HeatMapSeries { X0 = 1, X1 = matrix.GetLength(0), Y0 = 1, Y1 = matrix.GetLength(0), Data = matrix, Interpolate = false };
            model.Series.Add(hms);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                model.Annotations.Add(new TextAnnotation
                {
                    TextPosition = new DataPoint(allcolumns[row].Length * -0.04, row + 1),
                    Text = allcolumns[row],
                    StrokeThickness = 0
                });
                model.Annotations.Add(new TextAnnotation
                {
                    TextPosition = new DataPoint(row+1, allcolumns[row].Length * -0.075),
                    Text = allcolumns[row],
                    StrokeThickness = 0,
                    TextRotation = -90
                });

                for (int column = 0; column < matrix.GetLength(0); column++)
                {
                    model.Annotations.Add(new TextAnnotation 
         
                    { 
                     TextPosition = new DataPoint(column+1,row+0.75), 
                     Text = matrix[row, column].ToString("F2"),
                     StrokeThickness = 0
                    });
                }
            }
            correlationPlotView.Model = model;*/
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
