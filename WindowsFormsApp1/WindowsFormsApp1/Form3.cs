using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
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
            
            var model = new PlotModel { Title = "HeatMapSeries" };
            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(500), HighColor = OxyColors.Gray, LowColor = OxyColors.Black });

            var hms = new HeatMapSeries { X0 = 0, X1 = matrix.GetLength(0), Y0 = 0, Y1 = matrix.GetLength(0), Data = matrix, Interpolate = false };
            model.Series.Add(hms);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(0); column++)
                {
                    model.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(column,row), Text = matrix[row, column].ToString() });
                }
            }
            correlationPlotView.Model = model;
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
    }
}
