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
    public partial class rpcongnohanmucno : DevExpress.XtraReports.UI.XtraReport
    {
        public rpcongnohanmucno()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string tsbt)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "CÔNG NỢ QUÁ HẠN VÀ HẠN MỨC HỢP ĐỒNG";
            xrLabel3.Text = "Công nợ quá hạn và hạn mức hợp đồng tháng " + String.Format("{0:MM}", DateTime.Parse(tungay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
            xrLabel5.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(tungay)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }


        public void BindData(DataTable da)
        {
            DataSource = da;
            
            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Kho");

            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell43.DataBindings.Add("Text", DataSource, "Kho");

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
            XRSummary summarytotal14 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();
            XRSummary summarytotal16 = new XRSummary();

            XRSummary summarytotal21 = new XRSummary();
            XRSummary summarytotal22 = new XRSummary();            
            XRSummary summarytotal23 = new XRSummary();
            XRSummary summarytotal24 = new XRSummary();
            XRSummary summarytotal25 = new XRSummary();
            XRSummary summarytotal26 = new XRSummary();
            XRSummary summarytotal27 = new XRSummary();
            XRSummary summarytotal28 = new XRSummary();


            summarytotal21.Running = SummaryRunning.Group;
            summarytotal21.IgnoreNullValues = true;
            summarytotal21.FormatString = "{0:n0}";
            xrTableCell44.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell44.Summary = summarytotal21;

            summarytotal22.Running = SummaryRunning.Group;
            summarytotal22.IgnoreNullValues = true;
            summarytotal22.FormatString = "{0:n0}";
            xrTableCell45.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            xrTableCell45.Summary = summarytotal22;

            summarytotal23.Running = SummaryRunning.Group;
            summarytotal23.IgnoreNullValues = true;
            summarytotal23.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "Quá hạn", "{0:n0}");
            xrTableCell46.Summary = summarytotal23;

            summarytotal24.Running = SummaryRunning.Group;
            summarytotal24.IgnoreNullValues = true;
            summarytotal24.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "Trên 30", "{0:n0}");
            xrTableCell47.Summary = summarytotal24;

            summarytotal25.Running = SummaryRunning.Group;
            summarytotal25.IgnoreNullValues = true;
            summarytotal25.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "Trên 60", "{0:n0}");
            xrTableCell48.Summary = summarytotal25;


            summarytotal27.Running = SummaryRunning.Group;
            summarytotal27.IgnoreNullValues = true;
            summarytotal27.FormatString = "{0:n0}";
            xrTableCell50.DataBindings.Add("Text", DataSource, "Trên 90", "{0:n0}");
            xrTableCell50.Summary = summarytotal27;

            summarytotal28.Running = SummaryRunning.Group;
            summarytotal28.IgnoreNullValues = true;
            summarytotal28.FormatString = "{0:n0}";
            xrTableCell51.DataBindings.Add("Text", DataSource, "Trên 06", "{0:n0}");
            xrTableCell51.Summary = summarytotal28;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Vượt", "{0:n0}");
            xrTableCell32.Summary = summarytotal10;


            
            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell27.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            xrTableCell28.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Quá hạn", "{0:n0}");
            xrTableCell29.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Trên 30", "{0:n0}");
            xrTableCell30.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Trên 60", "{0:n0}");
            xrTableCell31.Summary = summarytotal5;

          
            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Trên 90", "{0:n0}");
            xrTableCell33.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Trên 06", "{0:n0}");
            xrTableCell34.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell49.DataBindings.Add("Text", DataSource, "Vượt", "{0:n0}");
            xrTableCell49.Summary = summarytotal9;

            
            xrTableCell15.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Họ tên khách hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Quá hạn", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Trên 30", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Trên 60", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Trên 90", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Trên 06", "{0:n0}");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Vượt", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Hợp đồng");
        }
    }
}
