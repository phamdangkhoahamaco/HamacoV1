using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;

namespace HAMACO.Resources
{
    public partial class rpthuchitienhangngay : DevExpress.XtraReports.UI.XtraReport
    {
        public rpthuchitienhangngay()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b, string c)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = a;
            xrLabel3.Text = c;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();
            XRSummary summarytotal9 = new XRSummary();
            XRSummary summarytotal10 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "C5119", "{0:n0}");
            xrTableCell28.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "C131", "{0:n0}");
            xrTableCell29.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "C1313", "{0:n0}");
            xrTableCell30.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "C1319", "{0:n0}");
            xrTableCell31.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "C336", "{0:n0}");
            xrTableCell32.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "N331", "{0:n0}");
            xrTableCell33.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "N3313", "{0:n0}");
            xrTableCell34.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "N3319", "{0:n0}");
            xrTableCell35.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "N336", "{0:n0}");
            xrTableCell36.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell26.DataBindings.Add("Text", DataSource, "Phiếu", "{0:n0}");
            xrTableCell26.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Report;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Khách hàng", "{0:n0}");
            xrTableCell27.Summary = summarytotal10;

            xrTableCell12.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Phiếu", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Khách hàng", "{0:n0}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "C5119", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "C131", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "C1313", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "C1319", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "C336", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "N331", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "N3313", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "N3319", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "N336", "{0:n0}");
        }
    }
}
