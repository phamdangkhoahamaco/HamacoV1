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
    public partial class rpnhapchuyenkho : DevExpress.XtraReports.UI.XtraReport
    {
        public rpnhapchuyenkho()
        {
            InitializeComponent();
        }

        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string nguoinop, string phuongtien, string kho, string khoden, string diachi, string lydo,string sophieu, string sotienchu,string khotren,string phieutren,string tenphieu)
        {
            if (tenphieu == "NHẬP CHUYỂN KHO NỘI BỘ" || tenphieu == "NHẬP CHUYỂN KHO VỎ NỘI BỘ" || tenphieu == "NHẬP HÀNG GỬI BÁN")
            {
                xrTableCell24.Text = "THỦ KHO GIAO";
                xrTableCell25.Text = "KẾ TOÁN GIAO";
            }
            xrLabel2.Text = tenphieu;
            xrLabel11.Text = nguoinop;
            xrLabel9.Text = "Số: " + phieutren;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel17.Text = sophieu;
            xrLabel5.Text = kho;
            xrLabel13.Text = diachi;
            xrLabel15.Text = lydo;
            xrLabel19.Text = phuongtien;
            xrLabel8.Text = khoden;
            if (sotienchu == "")
            {
                xrLabel20.Visible = false;
                xrLabel21.Visible = false;
            }
            xrLabel21.Text = sotienchu;
            xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
        }
        public void BindData(DataTable da)
        {
            if (da.Rows.Count > 9)
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
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n0}");
            xrTableCell16.Summary = summarytotal2;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        }
    }
}
