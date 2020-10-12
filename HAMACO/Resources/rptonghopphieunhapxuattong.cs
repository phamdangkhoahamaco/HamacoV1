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
    public partial class rptonghopphieunhapxuattong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptonghopphieunhapxuattong()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string congty, string ngaychungtu, string phieu)
        {
            if (phieu == "tsbtthpnxtttong")
                xrLabel2.Text = "BẢNG KÊ TỔNG HỢP PHIẾU NHẬP XUẤT THỪA THIẾU";
            else
                xrLabel2.Text = "BẢNG KÊ TỔNG HỢP PHIẾU NHẬP XUẤT ĐIỀU CHỈNH";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {

            DataSource = da;

            XRSummary summarytotal8 = new XRSummary();
            XRSummary summarytotal9 = new XRSummary();
            XRSummary summarytotal10 = new XRSummary();
            XRSummary summarytotal11 = new XRSummary();


            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n2}";
            xrTableCell2.DataBindings.Add("Text", DataSource, "Số lượng nhập", "{0:n2}");
            xrTableCell2.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số tiền nhập", "{0:n0}");
            xrTableCell3.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Report;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n2}";
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng xuất", "{0:n2}");
            xrTableCell4.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell5.DataBindings.Add("Text", DataSource, "Số tiền xuất", "{0:n0}");
            xrTableCell5.Summary = summarytotal11;

          
            xrTableCell8.DataBindings.Add("Text", DataSource, "Tên kho");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Số lượng nhập", "{0:n2}");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Số tiền nhập", "{0:n0}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số lượng xuất", "{0:n2}");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền xuất", "{0:n0}");
        }
    }
}
