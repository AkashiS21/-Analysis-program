using System.Data;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using OxyPlot.WindowsForms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Document = QuestPDF.Fluent.Document;
using System;





namespace WindowsFormsApp1
{
    public partial class ScatterPlotForm : Form
    {
        private SaveFileDialog saveScreenshot;
        
        public ScatterPlotForm(PlotModel model)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            plotView1.Model = model;

            this.WindowState = FormWindowState.Maximized;

            saveScreenshot = new SaveFileDialog();
            saveScreenshot.Filter = "PNG файлы (*.png)|*.png";
            saveScreenshot.RestoreDirectory = true;
        }
        

        private void plotView1_Click(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            if (saveScreenshot.ShowDialog() == DialogResult.OK)
            {
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                var pdfFilePath = Path.Combine(desktopPath, "Отчёт.pdf");
                var pngExporter = new PngExporter { Width = this.Width, Height = this.Height};
                pngExporter.ExportToFile(plotView1.Model, saveScreenshot.FileName);

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.Background(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(20));

                        page.Header()
                            .Text("Ваша диаграмма")
                            .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(20);

                                x.Item().Text(Placeholders.LoremIpsum());
                                x.Item().Image(saveScreenshot.FileName);
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Спасибо что пользуетесь нашим приложением\n");
                                x.CurrentPageNumber();
                                
                            });
                    });
                })
                .GeneratePdf(pdfFilePath);
            }
        }

    }
}
