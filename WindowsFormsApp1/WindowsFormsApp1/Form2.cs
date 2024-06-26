﻿using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private string filePath;
        private Form1 form1;
        private Form3 form3;
        public Form2(string filePath, Form1 form1)
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
                using (var reader = new StreamReader(filePath))
                {
                    if (!reader.EndOfStream)
                    {
                        string firstLine = reader.ReadLine();
                        string[] columnNames = firstLine.Split(';');

                        foreach (string columnName in columnNames)
                        {
                            listBox1.Items.Add(columnName);
                            listBox4.Items.Add(columnName);
                        }
                    }
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        foreach (string value in values)
                        {
                            if (!double.TryParse(value, out _))
                            {
                                MessageBox.Show("Файл содержит не числовые значения!");
                                return;
                            }
                        }
                    }
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
                MessageBox.Show("Выберите хотя бы один параметр и одну цель <3", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (listBox2.Items.Count != 2)
            {
                MessageBox.Show("Количество параметров должно быть  равное 2 ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<string> featureColumns = listBox2.Items.Cast<string>().ToList();
                List<string> targetColumns = listBox2.Items.Cast<string>().ToList();

                Parser parser = new Parser();
                CorrelationAnalyzer analyzer = new CorrelationAnalyzer();

                DataTable data = parser.LoadDataFromCSV(filePath);

                var matrix = analyzer.AnalyzeCorrelation(data, featureColumns, targetColumns);
                int x = data.Columns.IndexOf(featureColumns[0]);
                int y = data.Columns.IndexOf(targetColumns[1]);
                var model = CreateScatterPlot(data, x, y);
                ScatterPlotForm scatterplotform = new ScatterPlotForm(model);
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
            this.Close();
            Form1 form = new Form1();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string github = "Ссылка на проект на гитхабе:\n\n" +
                    "https://github.com/AkashiS21/-Analysis-program\n";

            MessageBox.Show(github, "GitHub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string pdfFilePath = @"C:\Users\zhere\kursach\WindowsFormsApp1\WindowsFormsApp1\Resources\параметры.pdf";

            try
            {
                System.Diagnostics.Process.Start(pdfFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия документа: " + ex.Message);
            }
        }

        private void AnalyzeCorrelation()
        {
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
            string pdfFilePath = @"C:\Users\zhere\kursach\WindowsFormsApp1\WindowsFormsApp1\Resources\Руководство корреляция.pdf";

            try
            {
                System.Diagnostics.Process.Start(pdfFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия документа: " + ex.Message);
            }
        }
        private PlotModel CreateHistogram(List<double> data)
        {
            var model = new PlotModel { Title = "Диаграмма распределения" };
            var histogramSeries = new HistogramSeries { FillColor = OxyColor.FromRgb(176, 212, 255), StrokeThickness = 1 ,TrackerFormatString = "Начальное значение: {5}\nКонечное значение: {6}\nКоличество значений: {7}" };

            int binCount = 9;
            double min = data.Min();
            double max = data.Max();
            double binWidth = (max - min) / binCount; 

            for (int i = 0; i < binCount; i++)
            {
                double binStart = min + i * binWidth;
                double binEnd = binStart + binWidth;
                int count = data.Count(x => x >= binStart && x < binEnd);
                double area = (binEnd - binStart) * count;
                histogramSeries.Items.Add(new HistogramItem(binStart, binEnd, area, count));
            }
            var annotation = new TextAnnotation()
            {
                Text = "В данный момент вы видите перед собой диаграмму распределения, которая показывает какие интервалы значений наиболее часто встречаются в загруженных данных.\nПо оси х - интервал, к которому пренадлежат значения, по оси у - значение.\nКликните на любой столбец чтобы узнать подробную информацию!!!",
                TextPosition = new DataPoint(50, 17), 
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center,
                TextVerticalAlignment = VerticalAlignment.Middle,
                TextRotation = 0
            };
            model.Annotations.Add(annotation);
            model.Series.Add(histogramSeries);
            model.Axes.Add(new LinearAxis()
            {
                Title = "Количество значений",
                Position = AxisPosition.Left,
            });
            model.Axes.Add(new LinearAxis()
            {
                Title = "Интервал значений",
                Position = AxisPosition.Bottom,
            });
            return model;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 1)
            {
                MessageBox.Show("Количество параметров должно быть  равное 1 ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<string> selectedColumn = listBox2.Items.Cast<string>().ToList();

            Parser parser = new Parser();
            DataTable data = parser.LoadDataFromCSV(filePath);

            int columnIndex = data.Columns.IndexOf(selectedColumn[0]);
            if (columnIndex == -1)
            {
                MessageBox.Show("Выбранный столбец не найден в данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<double> columnData = new List<double>();
            foreach (DataRow row in data.Rows)
            {
                if (double.TryParse(row[columnIndex].ToString(), out double value))
                {
                    columnData.Add(value);
                }
            }

            var model = CreateHistogram(columnData);
            ScatterPlotForm scatterplotform = new ScatterPlotForm(model);
            scatterplotform.Show();
        }
        private PlotModel CreateQuantilePlot(List<double> data)
        {

            var model = new PlotModel { Title = "Упорядоченные по возрастанию данные" };
            
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

            
            data.Sort();

            for (int i = 0; i < data.Count; i++)
            {
                double quantile = (double)(i*100) / data.Count;
                scatterSeries.Points.Add(new ScatterPoint(quantile, data[i]));
            }
            model.Series.Add(scatterSeries);
            var annotation = new TextAnnotation()
            {
                Text = "В данный момент вы видите перед собой значения выбранного параметра, упорядоченные по возрастанию.\nПо оси х - индекс, по оси у - значение.\nЭтот график необходим, чтобы понять, в каком интервале находятся значения этого параметра.\nВы можете нажать на любую точку,чтобы узнать её индекс и значение",
                TextPosition = new DataPoint(60, 3), 
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                
                
            };
            model.Annotations.Add(annotation);
            model.Axes.Add(new LinearAxis()
            {
                Title = "Индекс",
                Position = AxisPosition.Bottom,
            });
            model.Axes.Add(new LinearAxis()
            {
                Title = "Значение",
                Position = AxisPosition.Left,
            });
            return model;

        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 1)
            {
                MessageBox.Show("Количество параметров должно быть  равное 1 ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<string> selectedColumn = listBox2.Items.Cast<string>().ToList();

            Parser parser = new Parser();
            DataTable data = parser.LoadDataFromCSV(filePath);

            int columnIndex = data.Columns.IndexOf(selectedColumn[0]);
            if (columnIndex == -1)
            {
                MessageBox.Show("Выбранный столбец не найден в данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<double> columnData = new List<double>();
            foreach (DataRow row in data.Rows)
            {
                if (double.TryParse(row[columnIndex].ToString(), out double value))
                {
                    columnData.Add(value);
                }
            }

            PlotModel model = CreateQuantilePlot(columnData);
            ScatterPlotForm scatterplotform = new ScatterPlotForm(model);
            scatterplotform.Show();
        }
        private PlotModel CreateScatterPlot(DataTable data, int x, int y)
        {
            var model = new PlotModel { Title = "График рассеяния между двумя переменными" };

            var xColumn = data.Columns[x];
            var yColumn = data.Columns[y];

            var scatterSeries = new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColor.FromRgb(176, 212, 255),
            };
            var annotation = new TextAnnotation()
            {
                Text = "Вы смотрите на график рассеяния, который визуализирует зависимость между значениями двух выбранных переменных.\nЧем ближе точки находятся друг к другу, тем плотнее их связь.\nЕсли точки хаотично разбросаны по пространству, значит связь между переменными крайне низкая или полностью отсутствует.",
                TextPosition = new DataPoint(50 ,- 0.5),
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                TextVerticalAlignment = VerticalAlignment.Bottom,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center,

            };
            model.Annotations.Add(annotation);
            for (var i = 0; i < data.Rows.Count; i++)
            {
                var xOffset = double.Parse(data.Rows[i][x].ToString());
                var yOffset = double.Parse(data.Rows[i][y].ToString());

                scatterSeries.Points.Add(new ScatterPoint(xOffset, yOffset));
            }

            model.Series.Add(scatterSeries);

            model.Axes.Add(new LinearAxis()
            {
                Title = yColumn.ColumnName,
                Position = AxisPosition.Left,
            });

            model.Axes.Add(new LinearAxis()
            {
                Title = xColumn.ColumnName,
                Position = AxisPosition.Bottom,
            });

            return model;

        }
        private PlotModel CreateScatterPlotone(DataTable data, int x)
        {
            var model = new PlotModel { Title = "Функция распределения" };

            var xColumn = data.Columns[x];

            var series = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColor.FromRgb(176, 212, 255),
            };

            var list = Enumerable.Range(0, data.Rows.Count)
                .Select(i => double.Parse(data.Rows[i][x].ToString()))
                .ToList();

            var maxIndex = list.IndexOf(list.Max());

            var middle = list[maxIndex];
            var left = list.Take(maxIndex).OrderBy(v => v);
            var right = list.Skip(maxIndex + 1).OrderByDescending(v => v);

            var items = left.Concat(new[] { middle }).Concat(right).ToList();

            for (var i = 0; i < data.Rows.Count; i++)
            {
                series.Points.Add(new DataPoint(i, items[i]));
            }

            var average = items.Last(v => v >= items.Average());
            var averageIndex = items.IndexOf(average);
            model.Annotations.Add(CreateLine(OxyColors.Green, averageIndex, "Среднее значение"));

            var sorted = list.OrderBy(v => v).ToList();

            var median = sorted[sorted.Count / 2];
            var medianIndex = items.IndexOf(median);
            model.Annotations.Add(CreateLine(OxyColors.Red, medianIndex, "Медиана"));

            model.Annotations.Add(CreateLine(OxyColors.Blue, items.IndexOf(items.Min()), "Минимальное значение"));
            model.Annotations.Add(CreateLine(OxyColors.Blue, items.IndexOf(items.Max()), "Максимальное значение"));

            var annotation = new TextAnnotation()
            {
                Text = "Вы смотрите на функцию распределения, построенную по выбранному параметру.\nПо оси х - индекс, по оси у - значение.\nНа графике изображены минимальное, максимальное и среднее значения, а также медиана, расчитанные исходя из значений заданного параметра.",
                TextPosition = new DataPoint(50, -3),
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                TextVerticalAlignment = VerticalAlignment.Bottom,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center,

            };
            model.Annotations.Add(annotation);
            model.Annotations.Add(new LineAnnotation
            {
                StrokeThickness = 1,
                Color = OxyColors.Black,
                LineStyle = LineStyle.Solid,
                X = 0
            });

            model.Series.Add(series);
            model.Axes.Add(new LinearAxis()
            {
                Title = "Значение",
                Position = AxisPosition.Left,
            });
            model.Axes.Add(new LinearAxis()
            {
                Title = "Индекс",
                Position = AxisPosition.Bottom,
            });
            return model;
        }

        private LineAnnotation CreateLine(OxyColor color, double x, string text)
        {
            return new LineAnnotation()
            {
                StrokeThickness = 2,
                Color = color,
                Type = LineAnnotationType.Vertical,
                X = x,
                Y = 0,
                Text = text,
            };
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 1)
            {
                MessageBox.Show("Количество параметров должно быть  равное 1 ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<string> featureColumns = listBox2.Items.Cast<string>().ToList();
                List<string> targetColumns = listBox2.Items.Cast<string>().ToList();


                Parser parser = new Parser();
                CorrelationAnalyzer analyzer = new CorrelationAnalyzer();


                DataTable data = parser.LoadDataFromCSV(filePath);

                var matrix = analyzer.AnalyzeCorrelation(data, featureColumns, targetColumns);
                int x = data.Columns.IndexOf(featureColumns[0]);
                var model = CreateScatterPlotone(data, x);
                ScatterPlotForm scatterplotform = new ScatterPlotForm(model);
                scatterplotform.Show();
            }
        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
        }
    }
}
