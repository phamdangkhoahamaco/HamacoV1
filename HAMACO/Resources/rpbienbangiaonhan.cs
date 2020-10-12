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
    public partial class rpbienbangiaonhan : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbienbangiaonhan()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();

        public void gettieude(String nguoinop, String diachi, String noigiao, String ngaychungtu, String sophieu, String kho, String phuongtien, String phieu,string tienthue,string tongcong,string tienchu,string thue)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel11.Text = nguoinop;
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel6.Text = kho;
            xrLabel2.Text = phieu;
            xrLabel13.Text = diachi;
            xrLabel15.Text = noigiao;
            xrLabel7.Text = phuongtien;
            xrTableCell14.Text = Double.Parse(thue).ToString()+"%";
            xrTableCell17.Text = String.Format("{0:n0}", Double.Parse(tienthue));
            xrTableCell21.Text = String.Format("{0:n0}", Double.Parse(tongcong));
            xrLabel21.Text = tienchu;
            xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
        }

        public void gettieudetra(String nguoinop, String diachi, String noigiao, String ngaychungtu, String sophieu, String kho, String phuongtien, String phieu, string tienthue, string tongcong, string tienchu, string thue)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel11.Text = nguoinop;
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel6.Text = kho;
            xrLabel2.Text = phieu;
            xrLabel13.Text = diachi;
            xrLabel15.Visible = false;
            xrLabel5.Visible = false;
            xrLabel18.Text = "Lý do:";
            this.xrLabel7.SizeF = new System.Drawing.SizeF(500F, 15.00001F);
            xrTableCell58.Text = "Người lập";
            xrTableCell60.Text = "Thủ kho";
            xrTableCell61.Text = "Trưởng đơn vị";
            xrLabel7.Text = phuongtien;
            xrTableCell14.Text = Double.Parse(thue).ToString() + "%";
            xrTableCell17.Text = String.Format("{0:n0}", Double.Parse(tienthue));
            xrTableCell21.Text = String.Format("{0:n0}", Double.Parse(tongcong));
            xrLabel21.Text = tienchu;
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

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell13.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            xrTableCell11.Summary = summarytotal1;

            xrTableCell1.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell3.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        }
    }
}
