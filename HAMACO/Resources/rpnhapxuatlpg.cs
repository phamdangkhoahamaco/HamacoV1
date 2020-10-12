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
    public partial class rpnhapxuatlpg : DevExpress.XtraReports.UI.XtraReport
    {
        public rpnhapxuatlpg()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string phieu, string sophieu, string kho, string congty, string nguoinop, string diachi
          , string lydo, string khachhang, string phuongtien, string thucte, string hoten,string sophieuvo,string phieuvo)
        {
            xrLabel11.Text = nguoinop;
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel6.Text = kho;
            xrLabel2.Text = phieu;
            xrLabel13.Text = diachi;
            xrLabel15.Text = lydo;
            xrLabel21.Text = phuongtien;
            xrLabel27.Text = hoten;
            xrLabel10.Text = khachhang;
            xrTableCell7.Text = thucte;
            xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));

            xrLabel17.Text = nguoinop;
            xrLabel26.Text = "Số: " + sophieuvo;
            xrLabel4.Text = congty;
            xrLabel5.Text = kho;
            xrLabel7.Text = phieuvo;
            xrLabel19.Text = diachi;
            xrLabel23.Text = lydo;
            xrLabel25.Text = phuongtien;
            xrLabel16.Text = khachhang;
            xrTableCell7.Text = thucte;
            xrLabel8.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
        
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Loại");
            GroupHeader1.GroupFields.Add(groupField);

            xrTableCell23.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n2}";
            xrTableCell23.Summary = summary;

            xrTableCell15.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
        }

    }
}
