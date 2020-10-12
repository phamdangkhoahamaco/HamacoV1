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
    public partial class rphoadonbanhangthienan : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rphoadonbanhangthienan()
        {
            InitializeComponent();
        }
        public void gettieude(string ngayhoadon, string mst, string nguoinop, string donvi, string diachi, string thanhtoan, Double tongtienhang, Double tienthue, Double thue, Double tongtien, string hoten, string sotienchu, string co, string kho,string phieu,string makhach)
        {
            xrLabel13.Text = donvi;
            xrLabel15.Text = diachi;
            xrLabel9.Text = phieu;
            xrLabel11.Text = makhach;
            xrLabel21.Text = thanhtoan;
            if (mst == "")
                mst = "/";
            xrLabel3.Text = String.Format("{0:dd          MM        yyyy}", DateTime.Parse(ngayhoadon));
            String[] mstt = Array.ConvertAll<Char, String>(mst.ToCharArray(), Convert.ToString);
            xrLabel6.Text = String.Join("    ", mstt);
            xrLabel1.Text = String.Format("{0:n0}", tongtienhang);
            xrLabel5.Text = String.Format("{0:n0}", tongtien);
            if (thue == -100)
            {
                xrLabel2.Text = "/";
                xrLabel4.Text = "/";
            }
            else
            {
                xrLabel2.Text = String.Format("{0:n0}", tienthue);
                xrLabel4.Text = String.Format("{0:n0}", thue);
            }
            xrLabel8.Text = hoten;
            xrLabel7.Text = sotienchu;
            if (co == "1")
                xrLabel19.Visible = true;
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            xrTableCell4.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Loại");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell1.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n2}";
            xrLabel10.DataBindings.Add("Text", DataSource, "Loại", "{0:n2}");
            xrLabel10.Summary = summarytotal;

            /*summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrLabel11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrLabel11.Summary = summarytotal1;*/
        }
    }
}
