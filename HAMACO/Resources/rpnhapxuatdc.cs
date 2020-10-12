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
    public partial class rpnhapxuatdc : DevExpress.XtraReports.UI.XtraReport
    {
        public rpnhapxuatdc()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string phieu, string sophieu, string kho, string congty, string nguoinop, string diachi
          , string lydo, string sotienchu, string hoten, string no,string co,string hoadon,string ngayhoadon)
        {
            xrLabel11.Text = nguoinop;
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel6.Text = kho;
            xrLabel2.Text = phieu;
            xrLabel13.Text = diachi;
            xrLabel15.Text = lydo;
            xrLabel21.Text = sotienchu;
            xrLabel16.Text = hoten;
            xrLabel7.Text = "Nợ: " + no;
            xrLabel8.Text = "Có: "+co;
            xrLabel4.Text = "Hóa đơn số: " + hoadon;
            xrLabel5.Text = "Ngày hóa đơn: " + String.Format("{0:dd-MM-yyyy}",DateTime.Parse(ngayhoadon));
            xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
        }
        public void BindData(DataTable da)
        {
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell18.Summary = summarytotal;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        }

    }
}
