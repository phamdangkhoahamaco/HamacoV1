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
    public partial class rpbangkehanghoatong : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkehanghoatong()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string congty, string phieu, string kho, string ngay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = phieu;
            xrLabel5.Text = kho;
            xrLabel3.Text = ngay;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Ngày");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell2.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");

            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell4.Summary = summary;

            xrTableCell5.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n2}";
            xrTableCell5.Summary = summary1;

            xrTableCell7.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
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
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell23.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell24.Summary = summarytotal3;

            xrTableCell10.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
        }
    }
}
