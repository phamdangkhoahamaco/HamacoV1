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
    public partial class rpbangkexuatkhotong : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbangkexuatkhotong()
        {
            InitializeComponent();
        }
        public void gettieude(string nhanvien, string ngaychungtu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "ĐƠN HÀNG TỔNG NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel5.Text = gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='" + nhanvien + "'").ToUpper();
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
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
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n0}");
            xrTableCell23.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Khuyến mãi", "{0:n0}");
            xrTableCell24.Summary = summarytotal3;

            xrTableCell16.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Đơn vị tính");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n0}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Khuyến mãi", "{0:n0}");
        }
    }
}
