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
    public partial class rpmauthuchivattu : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpmauthuchivattu()
        {
            InitializeComponent();
        }
        public void gettieude(string ngaychungtu, string phieu, string mauso, string sophieu, string kho, string congty, string nguoinop, string diachi
           , string lydo, string sotien, string sotienchu, string chungtugoc, string hoten, string nguoinhan,string no, string co)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel11.Text = nguoinop;
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel6.Text = kho;
            xrLabel2.Text = phieu;
            xrLabel13.Text = diachi;
            xrLabel15.Text = lydo;
            xrLabel7.Text = chungtugoc;
            xrLabel21.Text = sotienchu;
            xrLabel4.Text = hoten;
            xrLabel10.Text=xrTableCell61.Text = nguoinhan;
            xrLabel17.Text = no;
            xrLabel19.Text = co;
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
            xrTableCell13.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell13.Summary = summarytotal;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Tên vật tư");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Mã số");
            xrTableCell3.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        }

    }
}
