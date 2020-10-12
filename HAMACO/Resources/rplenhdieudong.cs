using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rplenhdieudong : DevExpress.XtraReports.UI.XtraReport
    {
        public rplenhdieudong()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngayhoadon, string nguoinop, string phuongtien, string tukho, string denkho, Double tongtien, string lydo, string phieu)
        {
            xrLabel3.Text = gen.GetString("select Top 1 Province from Center")+", ngày " + String.Format("{0:dd}", DateTime.Parse(ngayhoadon)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngayhoadon)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngayhoadon));
            xrLabel4.Text = "Số: "+phieu;
            xrLabel2.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "Địa chỉ: "+gen.GetString("select Top 1 Address from Center");
            xrLabel8.Text = "-    Lý do điều động: " + lydo;
            xrLabel9.Text = "-    Phương tiện vận chuyển: " + phuongtien;
            xrLabel6.Text = "-    Nơi đi: " + tukho;
            xrLabel7.Text = "-    Nơi đến: " + denkho;
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            xrTableCell4.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng QĐ", "{0:n0}");
        }
    }
}
