namespace WindowsFormsApp1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.correlationPlotView = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // correlationPlotView
            // 
            this.correlationPlotView.Location = new System.Drawing.Point(26, 34);
            this.correlationPlotView.Name = "correlationPlotView";
            this.correlationPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.correlationPlotView.Size = new System.Drawing.Size(752, 348);
            this.correlationPlotView.TabIndex = 1;
            this.correlationPlotView.Text = "plotView1";
            this.correlationPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.correlationPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.correlationPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.correlationPlotView.Click += new System.EventHandler(this.plotView1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.correlationPlotView);
            this.Name = "Form3";
            this.Text = "Корреляция";
            this.ResumeLayout(false);

        }

        #endregion
        private OxyPlot.WindowsForms.PlotView correlationPlotView;
    }
}