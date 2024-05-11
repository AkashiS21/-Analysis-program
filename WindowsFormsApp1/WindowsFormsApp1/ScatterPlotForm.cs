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
        public ScatterPlotForm(PlotModel model)
        {
            InitializeComponent();
            plotView1.Model = model;
        }
    }
}
