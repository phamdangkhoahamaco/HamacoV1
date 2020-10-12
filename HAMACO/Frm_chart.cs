using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;


namespace HAMACO
{
    public partial class Frm_chart : DevExpress.XtraEditors.XtraForm
    {
        public Frm_chart()
        {
            InitializeComponent();

            this.Chart.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.Chart_CustomDrawSeriesPoint);
        }
        ChartControl Chart = new ChartControl();

        private void Chart_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
        {
            e.LegendText = e.LegendText + ": " + e.SeriesPoint.Values[0].ToString();
            //e.LegendText = e.LabelText;
        }

        private void Frm_chart_Load(object sender, EventArgs e)
        {
            Chart.BorderOptions.Visible = false;
            /*
            ChartControl sideBySideBarChart = new ChartControl();

            
            Series series1 = new Series("Side-by-Side Bar Series 1", ViewType.Bar);
            series1.Points.Add(new SeriesPoint("A", new double[] { 10 }));
            series1.Points.Add(new SeriesPoint("B", new double[] { 12 }));
            series1.Points.Add(new SeriesPoint("C", new double[] { 14 }));
            series1.Points.Add(new SeriesPoint("D", new double[] { 17 }));

           
            Series series2 = new Series("Side-by-Side Bar Series 2", ViewType.Bar);
            series2.Points.Add(new SeriesPoint("A", new double[] { 15 }));
            series2.Points.Add(new SeriesPoint("B", new double[] { 18 }));
            series2.Points.Add(new SeriesPoint("C", new double[] { 25 }));
            series2.Points.Add(new SeriesPoint("D", new double[] { 33 }));


            sideBySideBarChart.Series.Add(series1);
            sideBySideBarChart.Series.Add(series2);

            
            ((XYDiagram)sideBySideBarChart.Diagram).Rotated = true;

            
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Side-by-Side Bar Chart";
            sideBySideBarChart.Titles.Add(chartTitle1);

            
            sideBySideBarChart.Dock = DockStyle.Fill;
            this.Controls.Add(sideBySideBarChart);
        
            */
            
            

            // Create a pie series.
            Series series1 = new Series("",ViewType.Pie);

            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();
            chartTitle1.Text = "Phân tích nợ quá hạn từ tháng 01 đến tháng 03 năm 2016";
            chartTitle2.Text = " Tổng nợ quá hạn 3.000.000.000 đồng";
            chartTitle1.Alignment = StringAlignment.Center;
            chartTitle2.Alignment = StringAlignment.Near;
            chartTitle1.Font = new Font("Arial", 14, FontStyle.Bold);
            chartTitle1.TextColor = Color.Red;
            chartTitle2.Font = new Font("Arial", 12, FontStyle.Bold);
            chartTitle2.TextColor = Color.DarkBlue;
            chartTitle1.Dock = ChartTitleDockStyle.Bottom;
            chartTitle2.Dock = ChartTitleDockStyle.Top;
            Chart.Titles.AddRange(new ChartTitle[] {chartTitle1,chartTitle2});

            Legend legend = Chart.Legend;
            legend.AlignmentHorizontal = LegendAlignmentHorizontal.Left;
            legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
            legend.Shadow.Visible = true;
            legend.Font = new Font("Arial", 9, FontStyle.Regular);
            legend.Direction = LegendDirection.LeftToRight;
            legend.HorizontalIndent = 10;
            legend.VerticalIndent = 10;
            legend.MaxHorizontalPercentage = 30;
            legend.MaxVerticalPercentage = 30;
            

            // Populate the series with points.

            series1.Points.Add(new SeriesPoint("Trên 1 tháng", 17.0752));
            series1.Points.Add(new SeriesPoint("Trên 2 tháng", 9.98467));
            series1.Points.Add(new SeriesPoint("Trên 3 tháng", 9.63142));
            series1.Points.Add(new SeriesPoint("Trên 6 tháng", 9.59696));
            series1.Points.Add(new SeriesPoint("Trên 1 năm", 8.511965));
            series1.Points.Add(new SeriesPoint("Trên 3 năm", 7.68685));
            series1.Points.Add(new SeriesPoint("Dưới 1 tháng", 81.2));

            series1.LegendPointOptions.Pattern = "{A}";
            
            // Add the series to the chart.
            Chart.Series.Add(series1);

            // Format the the series labels.
            //series1.Label.TextPattern = "{A}: {VP:p0}";
           

            // Detect overlapping of series labels.
            
            // Adjust the position of series labels. 
            ((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PiePointOptions)series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
            //((PiePointOptions)series1.Label.PointOptions).PercentOptions.ValueAsPercent = false;
            //((PiePointOptions)series1.Label.PointOptions).ValueNumericOptions.Format = NumericFormat.General;
            //((PiePointOptions)series1.Label.PointOptions).ValueNumericOptions.Precision = 0;

            // Detect overlapping of series labels.
            ((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series.
            PieSeriesView myView = (PieSeriesView)series1.View;

            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series1.Name;

            // Specify a data filter to explode points.
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                DataFilterCondition.NotEqual, "Dưới 1 tháng"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 30;
            myView.RuntimeExploding = true;
            //myView.HeightToWidthRatio = 0.75;

            // Hide the legend (if necessary).
            //pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add the chart to the form.
            Chart.Dock = DockStyle.Fill;
            this.Controls.Add(Chart);
        
            /*
            ChartControl PieChart3D = new ChartControl();

            // Create a pie series.
            Series series1 = new Series("Pie Series 1", ViewType.Pie3D);

            // Populate the series with points.
            series1.Points.Add(new SeriesPoint("Russia", 17.0752));
            series1.Points.Add(new SeriesPoint("Canada", 9.98467));
            series1.Points.Add(new SeriesPoint("USA", 9.63142));
            series1.Points.Add(new SeriesPoint("China", 9.59696));
            series1.Points.Add(new SeriesPoint("Brazil", 8.511965));
            series1.Points.Add(new SeriesPoint("Australia", 7.68685));
            series1.Points.Add(new SeriesPoint("India", 3.28759));
            series1.Points.Add(new SeriesPoint("Others", 81.2));

            // Add the series to the chart.
            PieChart3D.Series.Add(series1);

            // Adjust the value numeric options of the series.
            series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            series1.PointOptions.ValueNumericOptions.Precision = 0;

            // Adjust the view-type-specific options of the series.
            ((Pie3DSeriesView)series1.View).Depth = 30;
            ((Pie3DSeriesView)series1.View).ExplodedPoints.Add(series1.Points[0]);
            ((Pie3DSeriesView)series1.View).ExplodedDistancePercentage = 30;

            // Access the diagram's options.
            ((SimpleDiagram3D)PieChart3D.Diagram).RotationType = RotationType.UseAngles;
            ((SimpleDiagram3D)PieChart3D.Diagram).RotationAngleX = -35;

            // Add a title to the chart and hide the legend.
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "3D Pie Chart";
            PieChart3D.Titles.Add(chartTitle1);
            PieChart3D.Legend.Visible = false;

            // Add the chart to the form.
            PieChart3D.Dock = DockStyle.Fill;
            this.Controls.Add(PieChart3D);
             */
            
            //pieChart.ShowPrintPreview();
        }

        private void barin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Chart.ShowRibbonPrintPreview();
        }
    }
}