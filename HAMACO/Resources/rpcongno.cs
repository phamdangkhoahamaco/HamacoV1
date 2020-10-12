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
    public partial class rpcongno : DevExpress.XtraReports.UI.XtraReport
    {
        public rpcongno()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void getuserid(string a)
        {
            try
            {
                xrTableCell43.Text = gen.GetString("select FullName from MSC_User where UserID='" + a + "'");
            }
            catch { }
            try
            {
                xrTableCell45.Text = gen.GetString("select TDV from MSC_User a, Branch b where a.BranchID=b.BranchID and UserID='" + a + "'");
            }
            catch { }

            xrTableCell44.Text = gen.GetString("select Top 1 ChiefAccountant from Center");
        }
        public void gettieude(string a, string b)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = a;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        
        }
        public void gettieudelai(string a, string b)
        {
            xrTableCell6.Text = "Lãi suất";
            xrTableCell13.Text = "Tiền lãi";
            xrTableCell9.Text = "Thuế TNCN";
            xrLabel2.Text = a;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            GroupHeader1.Visible = false;
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
            xrTableCell27.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell27.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell28.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell29.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell30.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell31.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell32.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell33.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
            xrTableCell34.Summary = summarytotal8;

            xrTableCell15.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Họ tên khách hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
        }


        public void BindDatakho(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Kho");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell25.DataBindings.Add("Text", DataSource, "Kho");

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
            XRSummary summarytotal12= new XRSummary();
            XRSummary summarytotal13= new XRSummary();
            XRSummary summarytotal14= new XRSummary();
            XRSummary summarytotal15= new XRSummary();
            XRSummary summarytotal16= new XRSummary();


            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell35.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell36.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Group;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell37.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell37.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Group;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell38.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell38.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Group;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell39.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Group;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell40.Summary = summarytotal14;

            summarytotal15.Running= SummaryRunning.Group;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell41.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell41.Summary = summarytotal15;

            summarytotal16.Running = SummaryRunning.Group;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
            xrTableCell42.Summary = summarytotal16;


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell27.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell28.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell29.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell30.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell31.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell32.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell33.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
            xrTableCell34.Summary = summarytotal8;

            xrTableCell15.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Họ tên khách hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
        }
    }
}
