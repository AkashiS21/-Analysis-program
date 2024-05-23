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
                var pngFileName = saveScreenshot.FileName; // Получаем имя файла из диалогового окна
                var pngFilePath = Path.Combine(desktopPath, pngFileName); // Полный путь к PNG-файлу
                var pdfFilePath = Path.Combine(desktopPath, Path.GetFileNameWithoutExtension(pngFileName) + ".pdf"); //  Полный путь к PDF-файлу

                // Сохраняем диаграмму в файл PNG
                var pngExporter = new PngExporter { Width = this.Width, Height = this.Height };
                pngExporter.ExportToFile(plotView1.Model, pngFilePath);

                // Создаем PDF-документ
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.Background(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(20));

                        page.Header()
                            .Text("Отчет")
                            .SemiBold().FontSize(32).FontColor(Colors.Black)
                            .AlignCenter();

                        page.Content()
                            .AlignCenter()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(20);
                                x.Item().Text("Вы сохранили построенный график.");
                                x.Item().Image(pngFilePath);
                            });

                        page.Footer()                             
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Спасибо что пользуетесь нашим приложением\n")
                                .SemiBold().FontSize(14).FontColor(Colors.Black);
                            });
                    });
                })
                .GeneratePdf(pdfFilePath);
                MessageBox.Show("Данные успешно сохранены в файл pdf.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
