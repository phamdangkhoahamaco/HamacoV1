using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpphieuxuatkhokiemvanchuyen : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpphieuxuatkhokiemvanchuyen()
        {
            InitializeComponent();
        }
        public void gettieude(string ngayhoadon, string nguoinop, string phuongtien, string tukho, string denkho, Double tongtien,string lydo,string phieu)
        {
            xrLabel4.Text = phieu;
            xrLabel3.Text = String.Format("{0:dd               MM                  yy}", DateTime.Parse(ngayhoadon));
            xrLabel10.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel12.Text = nguoinop;
            xrLabel11.Text = phuongtien;
            xrLabel13.Text = tukho;
            xrLabel15.Text = denkho;
            xrLabel1.Text = String.Format("{0:n0}", tongtien);
            xrLabel2.Text = lydo;
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            xrTableCell4.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n2}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        }
    }
}
