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
    public partial class rpbangkehanghoa : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkehanghoa()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string congty, string phieu, string kho, string ngay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = phieu;
            xrLabel5.Text = kho;
            xrLabel3.Text = ngay;
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }
        public void gettieudeloi(string phieu,string ngay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = phieu;
            xrTableCell18.Text = "Barem";
            xrLabel5.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngay)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }
        public void gettieudekm(string tungay, string denngay, string kho, string phieu, string khonhap)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = phieu;
            xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel3.Text = "Từ ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Số phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            GroupField groupField = new GroupField("Ngày");
            GroupHeader1.GroupFields.Add(groupField);

            

            xrTableCell1.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Tên khách");

            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell4.Summary = summary;

            xrTableCell5.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n2}";
            xrTableCell5.Summary = summary1;

            xrTableCell7.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            XRSummary summary2 = new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell7.Summary = summary2;


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell23.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell24.Summary = summarytotal3;

            /*summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell25.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell25.Summary = summarytotal4;*/

            xrTableCell10.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Mã hàng");
        }

        public void BindDataloi(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Số phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            GroupField groupField = new GroupField("Ngày");
            GroupHeader1.GroupFields.Add(groupField);



            xrTableCell1.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Tên khách");

            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell4.Summary = summary;

            xrTableCell5.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n2}";
            xrTableCell5.Summary = summary1;


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell23.Summary = summarytotal1;


            xrTableCell10.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n2}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Barem", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Mã hàng");
        }


        public void BindDatakm(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Mã hàng");
            GroupHeader1.GroupFields.Add(groupField1);


            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Tên hàng");

            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell4.Summary = summary;

            xrTableCell5.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n2}";
            xrTableCell5.Summary = summary1;



            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell23.Summary = summarytotal1;


            xrTableCell16.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tên khách");
        }
    }
}
