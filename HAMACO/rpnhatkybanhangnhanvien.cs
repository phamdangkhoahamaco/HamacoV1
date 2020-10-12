using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;

namespace HAMACO
{
    public partial class rpnhatkybanhangnhanvien : DevExpress.XtraReports.UI.XtraReport
    {
        public rpnhatkybanhangnhanvien()
        {
            InitializeComponent();
        }

        gencon gen = new gencon();
       
        public void gettieude(string nhanvien, string ngaychungtu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "NHẬT KÝ BÁN HÀNG NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel5.Text = gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='" + nhanvien + "'").ToUpper();
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;           
            XRSummary summarytotal1 = new XRSummary();
            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell7.Summary = summarytotal1;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Đơn hàng");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Tên khách");           
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
        }
    }
}
