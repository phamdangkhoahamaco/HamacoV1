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
    public partial class rpbangkesanluongnew : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbangkesanluongnew()
        {
            InitializeComponent();
        }
        public void gettieude(string ngaythang, string kho, string nhanvien)
        {
            xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel2.Text = "BẢNG KÊ LÃI QUÁ HẠN HÓA ĐƠN THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaythang)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaythang));
            xrLabel3.Text = "Nhân viên: " + gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='" + nhanvien + "'");
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
        }

        public void BindData(string denngay, string kho, string nhanvien)
        {
            string thang = DateTime.Parse(denngay).Month.ToString();
            string nam = DateTime.Parse(denngay).Year.ToString();
            string thangtruoc = DateTime.Parse(denngay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(denngay).AddMonths(-1).Year.ToString();
            DataTable da = gen.GetTable("bangkeluongvaphibanhang '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + denngay + "','" + nhanvien + "'");

            DataSource = da;

            XRSummary summarytotal = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell141.DataBindings.Add("Text", DataSource, "Lai", "{0:n0}");
            xrTableCell141.Summary = summarytotal;

            xrTableCell6.DataBindings.Add("Text", DataSource, "Makhach");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tenkhach");
            xrTableCell140.DataBindings.Add("Text", DataSource, "Lai", "{0:n0}");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Hoadon");
        }
    }
}
