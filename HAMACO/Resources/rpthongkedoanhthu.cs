using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace HAMACO.Resources
{
    public partial class rpthongkedoanhthu : DevExpress.XtraReports.UI.XtraReport
    {
        public rpthongkedoanhthu()
        {
            InitializeComponent();
        }
        public void BindData(DataTable da)
        {
            //ChartControl xrChart2 = new ChartControl();
            // Create a pie series.
            Series series1 = new Series("A Pie Series", ViewType.Pie);

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
            xrChart2.Series.Add(series1);

            // Adjust the point options of the series.
            series1.Label.PointOptions.PointView = PointView.ArgumentAndValues;
            series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            series1.Label.PointOptions.ValueNumericOptions.Precision = 0;

            // Detect overlapping of series labels.
            /*((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series.
            PieSeriesView myView = (PieSeriesView)series1.View;

            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series1.Name;

            // Specify a data filter to explode points.
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                DataFilterCondition.NotEqual, "Others"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 30;
            myView.RuntimeExploding = true;
            myView.HeightToWidthRatio = 0.75;*/

            // Hide the legend (if necessary).
            //xrChart2.Legend.Visible = false;

            // Add the chart to the form.
        }
    }
}
