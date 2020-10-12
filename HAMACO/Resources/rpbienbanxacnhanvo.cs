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
    public partial class rpbienbanxacnhanvo : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbienbanxacnhanvo()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(String ngaychungtu, string makhach )
        {
            xrLabel17.Text = xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel4.Text = "Điện thoại: " + gen.GetString("select Top 1 Phone from Center");
            xrLabel20.Text = gen.GetString("select Top 1 Phone from Center");
            //xrLabel22.Text = gen.GetString("select Top 1 CEO from Center");
            //xrLabel42.Text = gen.GetString("select Top 1 Title from Center");
            xrLabel6.Text = xrLabel14.Text = gen.GetString("select Top 1 Address from Center");           
            xrLabel3.Text = "Hôm nay, ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ". Chúng tôi gồm có:";
            xrLabel18.Text = "- Nếu sau ngày "+String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu).AddMonths(2)) +" mà Bên mua không xác nhận và gửi lại cho Bên bán thì xem như số liệu trên là đúng và có giá trị pháp lý như Bên Mua đã ký xác nhận.";

            DataTable temp = gen.GetTable("select AccountingObjectName,Address,Tel,Website,ContactTitle from AccountingObject where AccountingObjectCode='" + makhach + "'");
            xrLabel11.Text = temp.Rows[0][0].ToString();
            xrLabel13.Text = temp.Rows[0][1].ToString();
            xrLabel24.Text = temp.Rows[0][2].ToString();
            xrLabel26.Text = temp.Rows[0][3].ToString();
            xrLabel7.Text = temp.Rows[0][4].ToString();
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Cuối kỳ", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Tiền cuối kỳ", "{0:n0}");
            xrTableCell12.Summary = summarytotal;

            xrTableCell2.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Cuối kỳ", "{0:n0}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Tiền cuối kỳ", "{0:n0}");
        }
    }
}
