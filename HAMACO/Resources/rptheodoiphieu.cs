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
    public partial class rptheodoiphieu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptheodoiphieu()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string congty, string ngaychungtu, string nhanvien,string phieu)
        {
            xrLabel2.Text = phieu;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel3.Text = nhanvien;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {

            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Số phiếu");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell1.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Nhân viên");


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell13.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell19.Summary = summarytotal1;

            xrTableCell7.DataBindings.Add("Text", DataSource, "Tài khoản nợ");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tài khoản có");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
        }

        public void BindDataSum(DataTable da)
        {
            xrTable4.Visible = false;
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Số phiếu");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell1.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Nhân viên");


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell19.Summary = summarytotal1;

            xrTableCell7.DataBindings.Add("Text", DataSource, "Tài khoản nợ");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tài khoản có");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
        }
    }
}
