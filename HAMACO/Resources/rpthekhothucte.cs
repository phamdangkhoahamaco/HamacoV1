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
    public partial class rpthekhothucte : DevExpress.XtraReports.UI.XtraReport
    {
        public rpthekhothucte()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string mahang, string kho, string congty, string user)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
            string nam = String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            DataTable temp = new DataTable();
            
            if (user == "1")
                xrLabel2.Text = "THẺ KHO HÀNG HÓA THỰC TẾ TỪ NGÀY  " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu)) + " ĐẾN NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(congty));
            else
                xrLabel2.Text = "THẺ KHO HÀNG HÓA THỰC TẾ THÁNG " + thang + " NĂM " + nam;

            try
            {
                temp = gen.GetTable("select StockCode,StockName from Stock where StockID='" + kho + "'");
                xrLabel3.Text = temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString();
            }
            catch
            { xrLabel2.Text = "THẺ KHO HÀNG GỬI KHÁCH HÀNG TỪ NGÀY  " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu)) + " ĐẾN NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(congty)); }

            temp = gen.GetTable("select InventoryItemCode,InventoryItemName from InventoryItem where InventoryItemID='" + mahang + "'");
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


            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "slqdtondau", "{0:n0}");
            xrTableCell39.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n2}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "tientondau", "{0:n2}");
            xrTableCell40.Summary = summarytotal3;


            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "slqdnhap", "{0:n0}");
            xrTableCell42.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n2}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "sotiennhap", "{0:n2}");
            xrTableCell43.Summary = summarytotal6;


            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell45.DataBindings.Add("Text", DataSource, "slqdxuat", "{0:n0}");
            xrTableCell45.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n2}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "sotienxuat", "{0:n2}");
            xrTableCell46.Summary = summarytotal9;


            summarytotal12.Running = SummaryRunning.None;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "slqdtoncuoi", "{0:n0}");
            xrTableCell48.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.None;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n2}";
            xrTableCell49.DataBindings.Add("Text", DataSource, "sotientoncuoi", "{0:n2}");
            xrTableCell48.Summary = summarytotal13;


            xrTableCell20.DataBindings.Add("Text", DataSource, "ngay", "{0:dd-MM-yyyy}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "sophieu");
            xrTableCell22.DataBindings.Add("Text", DataSource, "tenkhach");
            xrTableCell24.DataBindings.Add("Text", DataSource, "slqdtondau", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "tientondau", "{0:n2}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "slqdnhap", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "sotiennhap", "{0:n2}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "slqdxuat", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "sotienxuat", "{0:n2}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "slqdtoncuoi", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "sotientoncuoi", "{0:n2}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "phuongtien");
        }
    }
}
