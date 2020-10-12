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
    public partial class rpnhapmua : DevExpress.XtraReports.UI.XtraReport
    {
        public rpnhapmua()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string phieu, string sophieu, string kho, Double tongtien, string nguoinop, string diachi
         , string lydo, string sotienchu, string hoten, string thue, Double chiphi, string hoadon, string ngayhoadon,Double tienthue,string lydothat, Double chietkhau)
        {
            xrLabel11.Text = nguoinop;
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel6.Text = kho;
            xrLabel2.Text = phieu;
            xrLabel13.Text = diachi;
            xrLabel15.Text = lydo;
            if (chiphi != 0)
                xrTableCell23.Text = String.Format("{0:n0}", chiphi);

            if (chietkhau != 0)
                xrTableCell30.Text = String.Format("{0:n0}", chietkhau);

                 xrTableCell26.Text = thue + "%";
                 xrTableCell21.Text = String.Format("{0:n0}", tongtien);
                 xrTableCell29.Text = String.Format("{0:n0}", tienthue);

            xrLabel21.Text = sotienchu;
            xrLabel16.Text = hoten;
            xrLabel18.Text = lydothat;
            xrLabel4.Text = hoadon;
            xrLabel5.Text = String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngayhoadon));
            xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
        }

        public void BindData(DataTable da)
        {

            if (da.Rows.Count > 10)
            {
                this.PageHeight = 1169;
                this.PageWidth = 827;
                this.PaperKind = System.Drawing.Printing.PaperKind.A4;

                this.TopMargin.HeightF = 40F;
                this.BottomMargin.HeightF = 40F;
            }

            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell18.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell15.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell15.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
            xrTableCell16.Summary = summarytotal2;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell4.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        }
    }
}
