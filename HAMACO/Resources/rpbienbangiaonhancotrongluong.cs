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
    public partial class rpbienbangiaonhancotrongluong : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbienbangiaonhancotrongluong()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();

        public void gettieude(String nguoinop, String diachi, String noigiao, String ngaychungtu, String sophieu, String kho, String phuongtien, String phieu, string tienchu, string hoten, string daidien, string sdt,string giaohang, string sodienthoai,string taixe, string cmnd, string sdttaixe)
        {
            xrLabel39.Text = xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel40.Text = gen.GetString("select Top 1 Bank from Center");
            xrLabel4.Text = "Điện thoại: " + gen.GetString("select Top 1 Phone from Center");
            xrLabel6.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel11.Text = nguoinop.ToUpper();
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel17.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel49.Text = gen.GetString("select StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel14.Text = gen.GetString("select Description from Stock where StockID='" + kho + "'");
            xrLabel20.Text = gen.GetString("select Note from Stock where StockID='" + kho + "'");
            xrLabel2.Text = phieu;
            xrLabel13.Text = diachi;
            xrLabel15.Text = noigiao;
            xrLabel32.Text = giaohang;
            xrLabel24.Text = sdt;
            xrLabel7.Text = phuongtien;
            xrLabel31.Text = "Số tiền chữ: " + tienchu;
            xrLabel3.Text = "Hôm nay, ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ". Chúng tôi gồm có:";
            xrLabel22.Text = xrLabel35.Text = hoten;
            xrLabel26.Text = daidien;
            xrLabel42.Text = sodienthoai;
            xrLabel43.Text = taixe;
            xrLabel45.Text = cmnd;
            xrLabel47.Text = sdttaixe;
        }
        public void BindData(DataTable da)
        {
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell13.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
            xrTableCell18.Summary = summarytotal2;

            xrTableCell1.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell3.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Ghi chú");
        }
    }
}
