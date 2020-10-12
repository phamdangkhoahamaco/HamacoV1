using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HAMACO.Resources
{
    public partial class rpthekholaigop : DevExpress.XtraReports.UI.XtraReport
    {
        public rpthekholaigop()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string mahang, string kho)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
            string nam = String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            DataTable temp = new DataTable();
            try
            {
                temp = gen.GetTable("select StockCode,StockName from Stock where StockID='" + kho + "'");
                xrLabel3.Text = temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString();
            }
            catch
            {
                temp = gen.GetTable("select BranchCode,BranchName from Branch where BranchID='" + kho + "'");
                xrLabel3.Text = temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString();
            }
            xrLabel3.Text = "Kho " + xrLabel3.Text;
            xrLabel2.Text = "NHẬT KÝ NHẬP XUẤT HÀNG HÓA THÁNG " + thang + " NĂM " + nam;
            try
            {
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName from InventoryItem where InventoryItemID='" + mahang + "'");
            }
            catch { temp = gen.GetTable("select InventoryItemCode,InventoryItemName from InventoryItem where InventoryItemCode='" + mahang + "'"); }
            
            xrLabel5.Text = "MẶT HÀNG: " + temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString().ToUpper();
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();
            XRSummary summarytotal9 = new XRSummary();
            XRSummary summarytotal10 = new XRSummary();
            XRSummary summarytotal11 = new XRSummary();
            XRSummary summarytotal12 = new XRSummary();
            XRSummary summarytotal13 = new XRSummary();

            
            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell41.DataBindings.Add("Text", DataSource, "slnhap", "{0:n0}");
            xrTableCell41.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n2}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "slqdnhap", "{0:n2}");
            xrTableCell42.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "sotiennhap", "{0:n0}");
            xrTableCell43.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell44.DataBindings.Add("Text", DataSource, "slxuat", "{0:n0}");
            xrTableCell44.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n2}";
            xrTableCell45.DataBindings.Add("Text", DataSource, "slqdxuat", "{0:n2}");
            xrTableCell45.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "sotienxuat", "{0:n0}");
            xrTableCell46.Summary = summarytotal9;

            xrTableCell20.DataBindings.Add("Text", DataSource, "ngay", "{0:dd-MM-yy}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "sophieu");
            xrTableCell22.DataBindings.Add("Text", DataSource, "tenkhach");
            xrTableCell26.DataBindings.Add("Text", DataSource, "slnhap", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "slqdnhap", "{0:n2}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "sotiennhap", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "slxuat", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "slqdxuat", "{0:n2}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "sotienxuat", "{0:n0}");
        }
    }
}
