using System.Data;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace WindowsFormsApp1
{
    public partial class ScatterPlotForm : Form
    {
        public ScatterPlotForm(DataTable data, int x, int y)
        {
            InitializeComponent();
            InitializeScatterPlot(data, x, y);
        }

        private void InitializeScatterPlot(DataTable data, int x, int y)
        {
            var model = new PlotModel();

            var xColumn = data.Columns[x];
            var yColumn = data.Columns[y];

            var scatterSeries = new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Blue,
            };

            for (var i = 0; i < data.Rows.Count; i++)
            {
                var xOffset = double.Parse(data.Rows[i][x].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
                var yOffset = double.Parse(data.Rows[i][y].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);

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

            plotView1.Model = model;
        }
    }
}
