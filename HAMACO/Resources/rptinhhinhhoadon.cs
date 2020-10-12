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
    public partial class rptinhhinhhoadon : DevExpress.XtraReports.UI.XtraReport
    {
        public rptinhhinhhoadon()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string denngay, string kho,string tct)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "TÌNH HÌNH SỬ DỤNG HÓA ĐƠN THÁNG " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
            xrLabel5.Text = "Cần thơ, ngày " + String.Format("{0:dd}", DateTime.Parse(denngay)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
            
            /*if (tct == "0")
            {
                xrLabel3.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
                xrLabel5.Text = gen.GetString("select ProvinceName from Stock a, Province b where a.Province=b.ProvinceCode and StockID='" + kho + "'") + ", ngày " + String.Format("{0:dd}", DateTime.Parse(denngay)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
                GroupHeader1.Visible = false;
            }*/

            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now); 
            xrTableCell20.Text = gen.GetString("select Top 1 DGM from Center");
            xrTableCell18.Text = gen.GetString("select Top 1 ChiefAccountant from Center");
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


            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell8.DataBindings.Add("Text", DataSource, "Số SD", "{0:n0}");
            xrTableCell8.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell9.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell9.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số KSD", "{0:n0}");
            xrTableCell19.Summary = summarytotal4;

           /* Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Kho");
            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell32.DataBindings.Add("Text", DataSource, "Tên kho");*/


           /* summarytotal5.Running = SummaryRunning.Group;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Số SD", "{0:n0}");
            xrTableCell23.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Group;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell27.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Group;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số KSD", "{0:n0}");
            xrTableCell22.Summary = summarytotal7;*/


            xrTableCell6.DataBindings.Add("Text", DataSource, "Quyển");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số SD", "{0:n0}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Từ số");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Đến số");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số KSD", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Phiếu");
        }
    }
}
