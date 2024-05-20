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
            Dock = DockStyle.Top;
            plotView1.Model = model;

            this.WindowState = FormWindowState.Maximized;
        }
        

        private void plotView1_Click(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
