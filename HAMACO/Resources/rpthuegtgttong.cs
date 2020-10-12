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
    public partial class rpthuegtgttong : DevExpress.XtraReports.UI.XtraReport
    {
        public rpthuegtgttong()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string congty, string tsbt, string ngay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            if (tsbt == "tsbtthuedaura")
                xrLabel2.Text = "BẢNG TỔNG HỢP THUẾ GTGT ĐẦU RA THEO KHO";
            xrLabel5.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngay)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " Mã kho: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Mã kho");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell2.DataBindings.Add("Text", DataSource, "Mã kho");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Tên kho");

            xrTableCell4.DataBindings.Add("Text", DataSource, "Doanh thu", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell4.Summary = summary;

            xrTableCell7.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            XRSummary summary2 = new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell7.Summary = summary2;


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Doanh thu", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            xrTableCell24.Summary = summarytotal3;

            xrTableCell11.DataBindings.Add("Text", DataSource, "Doanh thu", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Thuế suất");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
        }
    }
}
