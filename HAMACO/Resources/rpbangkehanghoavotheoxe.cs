using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using HAMACO.Resources;
using System.Data;
using System.Data.SqlClient;

namespace HAMACO.Resources
{
    public partial class rpbangkehanghoavotheoxe : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkehanghoavotheoxe()
        {
            InitializeComponent();
        }

        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string soxe, string taixe, string tsbt)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "BẢNG KÊ TỔNG HỢP VỎ THEO XE";
            xrLabel5.Text = soxe + " - " + taixe;
            xrLabel3.Text = "Từ ngày: " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }


        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);

            GroupField groupField = new GroupField("Ngày lập");
            GroupHeader1.GroupFields.Add(groupField);

            xrTableCell1.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");

            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell4.Summary = summary;


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            xrTableCell6.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
        }
    }
}
