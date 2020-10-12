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
    public partial class rphantichnoquahan : DevExpress.XtraReports.UI.XtraReport
    {
        public rphantichnoquahan()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = a;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            GroupHeader1.Visible = false;
            DataSource = da;

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
            xrTableCell23.DataBindings.Add("Text", DataSource, "Tổng số tiền nợ", "{0:n0}");
            xrTableCell23.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số tiền quá hạn", "{0:n0}");
            xrTableCell24.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell25.DataBindings.Add("Text", DataSource, "Dưới 1 tháng", "{0:n0}");
            xrTableCell25.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell26.DataBindings.Add("Text", DataSource, "Trên 1 tháng", "{0:n0}");
            xrTableCell26.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Trên 2 tháng", "{0:n0}");
            xrTableCell27.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Trên 3 tháng", "{0:n0}");
            xrTableCell28.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Trên 6 tháng", "{0:n0}");
            xrTableCell29.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Trên 1 năm", "{0:n0}");
            xrTableCell30.Summary = summarytotal8;

            xrTableCell11.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Họ tên khách hàng");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tổng số tiền nợ", "{0:0,0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền quá hạn", "{0:0,0}");
            xrTableCell15.DataBindings.Add("Text", DataSource, "Dưới 1 tháng", "{0:0,0}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Trên 1 tháng", "{0:0,0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Trên 2 tháng", "{0:0,0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Trên 3 tháng", "{0:0,0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Trên 6 tháng", "{0:0,0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Trên 1 năm", "{0:0,0}");
        }

        public void BindDatagroup(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Kho");
            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell21.DataBindings.Add("Text", DataSource, "Tên kho");

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


            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Tổng số tiền nợ", "{0:n0}");
            xrTableCell31.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Số tiền quá hạn", "{0:n0}");
            xrTableCell32.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Group;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Dưới 1 tháng", "{0:n0}");
            xrTableCell33.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Group;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Trên 1 tháng", "{0:n0}");
            xrTableCell34.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Group;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "Trên 2 tháng", "{0:n0}");
            xrTableCell35.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Group;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Trên 3 tháng", "{0:n0}");
            xrTableCell36.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Group;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell37.DataBindings.Add("Text", DataSource, "Trên 6 tháng", "{0:n0}");
            xrTableCell37.Summary = summarytotal15;

            summarytotal16.Running = SummaryRunning.Group;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell38.DataBindings.Add("Text", DataSource, "Trên 1 năm", "{0:n0}");
            xrTableCell38.Summary = summarytotal16;





            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Tổng số tiền nợ", "{0:n0}");
            xrTableCell23.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số tiền quá hạn", "{0:n0}");
            xrTableCell24.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell25.DataBindings.Add("Text", DataSource, "Dưới 1 tháng", "{0:n0}");
            xrTableCell25.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell26.DataBindings.Add("Text", DataSource, "Trên 1 tháng", "{0:n0}");
            xrTableCell26.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Trên 2 tháng", "{0:n0}");
            xrTableCell27.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Trên 3 tháng", "{0:n0}");
            xrTableCell28.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Trên 6 tháng", "{0:n0}");
            xrTableCell29.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Trên 1 năm", "{0:n0}");
            xrTableCell30.Summary = summarytotal8;

            xrTableCell11.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Họ tên khách hàng");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tổng số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền quá hạn", "{0:n0}");
            xrTableCell15.DataBindings.Add("Text", DataSource, "Dưới 1 tháng", "{0:n0}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Trên 1 tháng", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Trên 2 tháng", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Trên 3 tháng", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Trên 6 tháng", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Trên 1 năm", "{0:n0}");
        }

    }
}
