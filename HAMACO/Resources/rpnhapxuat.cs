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
    public partial class rpnhapxuat : DevExpress.XtraReports.UI.XtraReport
    {
        public rpnhapxuat()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string phieu, string sophieu, string kho, string congty, string nguoinop, string diachi
           , string lydo, string khachhang, string phuongtien, string thucte, string hoten)
        {
            xrLabel11.Text = nguoinop;
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel6.Text = kho;
            xrLabel2.Text = phieu;

            if (phieu == "PHIẾU XUẤT KHO")
            {
                xrLabel2.Text = "PHIẾU XUẤT KHO KIÊM                                  BIÊN BẢN GIAO NHẬN HÀNG";
                xrTableCell5.Text = "Thực xuất";
                xrTableCell9.Text = "Ghi chú";
            }

            else if (phieu == "YÊU CẦU CUNG CẤP HÀNG")
            {
                xrLabel2.Text = "LỆNH XUẤT HÀNG";
                xrTableCell9.Text = "Thực xuất";
                xrTableCell5.Text = "Yêu cầu";

                xrTableCell58.Text = "";
                xrTableCell24.Text = "BỐC XẾP";
                xrTableCell62.Text = "THỦ KHO";

                xrTableCell20.Text = "";
                xrTableCell14.Text = "KẾ TOÁN";
            }

            else if (phieu == "PHIẾU NHẬP KHO")
                xrTableCell58.Text = "BÊN VẬN CHUYỂN";
            
            xrLabel13.Text = diachi;
            xrLabel15.Text = lydo;
            xrLabel21.Text = phuongtien;
            xrLabel4.Text = hoten;
            xrLabel10.Text = khachhang;
            //xrTableCell7.Text = thucte;
            try
            {
                xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            }
            catch { }
                xrLabel5.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + String.Format("{0: dd-MM-yyyy}", DateTime.Now);

        }

        public void BindData(DataTable da)
        {
            if (da.Rows.Count > 11)
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


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell17.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell17.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
            xrTableCell18.Summary = summarytotal1;

            xrTableCell4.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
        }

    }
}
