namespace HAMACO.Resources
{
    partial class rpthongkedoanhthu
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.SimpleDiagram3D simpleDiagram3D1 = new DevExpress.XtraCharts.SimpleDiagram3D();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Doughnut3DSeriesLabel doughnut3DSeriesLabel1 = new DevExpress.XtraCharts.Doughnut3DSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions1 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.Doughnut3DSeriesView doughnut3DSeriesView1 = new DevExpress.XtraCharts.Doughnut3DSeriesView();
            DevExpress.XtraCharts.Doughnut3DSeriesLabel doughnut3DSeriesLabel2 = new DevExpress.XtraCharts.Doughnut3DSeriesLabel();
            DevExpress.XtraCharts.Doughnut3DSeriesView doughnut3DSeriesView2 = new DevExpress.XtraCharts.Doughnut3DSeriesView();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrChart2 = new DevExpress.XtraReports.UI.XRChart();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 611.6011F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 30F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 30F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart2});
            this.ReportHeader.HeightF = 611F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrChart2
            // 
            this.xrChart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrChart2.BorderColor = System.Drawing.Color.Black;
            this.xrChart2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            simpleDiagram3D1.PerspectiveEnabled = false;
            simpleDiagram3D1.RotationMatrixSerializable = "0.579403144131448;0.582793684297382;-0.569774971470039;0;-0.630086505007572;0.763" +
                "720221865782;0.140436529865369;0;0.516994190274843;0.277638153459439;0.809712333" +
                "465223;0;0;0;0;1";
            this.xrChart2.Diagram = simpleDiagram3D1;
            this.xrChart2.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.xrChart2.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Bottom;
            this.xrChart2.Legend.EquallySpacedItems = false;
            this.xrChart2.LocationFloat = new DevExpress.Utils.PointFloat(300F, 0F);
            this.xrChart2.Name = "xrChart2";
            doughnut3DSeriesLabel1.Font = new System.Drawing.Font("Tahoma", 10F);
            doughnut3DSeriesLabel1.LineVisible = true;
            piePointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
            doughnut3DSeriesLabel1.PointOptions = piePointOptions1;
            doughnut3DSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            series1.Label = doughnut3DSeriesLabel1;
            series1.Name = "Series 1";
            series1.View = doughnut3DSeriesView1;
            this.xrChart2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            doughnut3DSeriesLabel2.LineVisible = true;
            this.xrChart2.SeriesTemplate.Label = doughnut3DSeriesLabel2;
            this.xrChart2.SeriesTemplate.View = doughnut3DSeriesView2;
            this.xrChart2.SizeF = new System.Drawing.SizeF(500F, 611F);
            // 
            // rpthongkedoanhthu
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRChart xrChart2;
    }
}
