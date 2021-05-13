
namespace UserInterface
{
    partial class SecurityReportGraphModal
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chrtSecurityReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblSecurityReport = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chrtSecurityReport)).BeginInit();
            this.SuspendLayout();
            // 
            // chrtSecurityReport
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtSecurityReport.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtSecurityReport.Legends.Add(legend1);
            this.chrtSecurityReport.Location = new System.Drawing.Point(47, 68);
            this.chrtSecurityReport.Name = "chrtSecurityReport";
            this.chrtSecurityReport.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chrtSecurityReport.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.DarkOrange,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.DarkGreen};
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Red";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Orange";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Yellow";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Light Green";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Dark Green";
            this.chrtSecurityReport.Series.Add(series1);
            this.chrtSecurityReport.Series.Add(series2);
            this.chrtSecurityReport.Series.Add(series3);
            this.chrtSecurityReport.Series.Add(series4);
            this.chrtSecurityReport.Series.Add(series5);
            this.chrtSecurityReport.Size = new System.Drawing.Size(698, 318);
            this.chrtSecurityReport.TabIndex = 0;
            this.chrtSecurityReport.Text = "chart1";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(635, 392);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 46);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSecurityReport
            // 
            this.lblSecurityReport.AutoSize = true;
            this.lblSecurityReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurityReport.Location = new System.Drawing.Point(12, 11);
            this.lblSecurityReport.Name = "lblSecurityReport";
            this.lblSecurityReport.Size = new System.Drawing.Size(272, 39);
            this.lblSecurityReport.TabIndex = 2;
            this.lblSecurityReport.Text = "Security Report";
            // 
            // SecurityReportGraphModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSecurityReport);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chrtSecurityReport);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "SecurityReportGraphModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security level Chart";
            this.Load += new System.EventHandler(this.SecurityReportGraphModal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chrtSecurityReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrtSecurityReport;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblSecurityReport;
    }
}