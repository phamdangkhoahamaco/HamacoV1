using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbangkechitietkinhdoanh : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkechitietkinhdoanh()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string makho)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "BẢNG KÊ CHI TIẾT KẾT QUẢ KINH DOANH THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel3.Text = "Kết quả kinh doanh tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + " - " + gen.GetString("select StockName from Stock where StockID='" + makho + "'");
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrLabel5.Text = "ĐƠN VỊ - " + gen.GetString("select StockName from Stock where StockID='" + makho + "'").ToUpper();
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            xrTableCell2.DataBindings.Add("Text", DataSource, "Diễn giải");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell1.DataBindings.Add("Text", DataSource, "Kỳ trước", "{0:n0}");
        }
    }
}
