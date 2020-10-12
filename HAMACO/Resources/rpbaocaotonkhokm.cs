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
    public partial class rpbaocaotonkhokm : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaotonkhokm()
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
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("nhomhang");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell39.DataBindings.Add("Text", DataSource, "tennhom");

            xrTableCell43.DataBindings.Add("Text", DataSource, "slbbkmtd", "{0:n0}");
            XRSummary summary15 = new XRSummary();
            summary15.Running = SummaryRunning.Group;
            summary15.IgnoreNullValues = true;
            summary15.FormatString = "{0:n0}";
            xrTableCell43.Summary = summary15;

            xrTableCell44.DataBindings.Add("Text", DataSource, "slkmtd", "{0:n2}");
            XRSummary summary16 = new XRSummary();
            summary16.Running = SummaryRunning.Group;
            summary16.IgnoreNullValues = true;
            summary16.FormatString = "{0:n2}";
            xrTableCell44.Summary = summary16;

            xrTableCell45.DataBindings.Add("Text", DataSource, "slbbnhapkm", "{0:n0}");
            XRSummary summary17 = new XRSummary();
            summary17.Running = SummaryRunning.Group;
            summary17.IgnoreNullValues = true;
            summary17.FormatString = "{0:n0}";
            xrTableCell45.Summary = summary17;

            xrTableCell46.DataBindings.Add("Text", DataSource, "slnhapkm", "{0:n2}");
            XRSummary summary18 = new XRSummary();
            summary18.Running = SummaryRunning.Group;
            summary18.IgnoreNullValues = true;
            summary18.FormatString = "{0:n2}";
            xrTableCell46.Summary = summary18;

            xrTableCell47.DataBindings.Add("Text", DataSource, "slbbxuatkm", "{0:n0}");
            XRSummary summary19 = new XRSummary();
            summary19.Running = SummaryRunning.Group;
            summary19.IgnoreNullValues = true;
            summary19.FormatString = "{0:n0}";
            xrTableCell47.Summary = summary19;

            xrTableCell48.DataBindings.Add("Text", DataSource, "slxuatkm", "{0:n2}");
            XRSummary summary20 = new XRSummary();
            summary20.Running = SummaryRunning.Group;
            summary20.IgnoreNullValues = true;
            summary20.FormatString = "{0:n2}";
            xrTableCell48.Summary = summary20;

            xrTableCell51.DataBindings.Add("Text", DataSource, "slbbtonkm", "{0:n0}");
            XRSummary summary21 = new XRSummary();
            summary21.Running = SummaryRunning.Group;
            summary21.IgnoreNullValues = true;
            summary21.FormatString = "{0:n0}";
            xrTableCell51.Summary = summary21;

            xrTableCell52.DataBindings.Add("Text", DataSource, "sltonkm", "{0:n2}");
            XRSummary summary22 = new XRSummary();
            summary22.Running = SummaryRunning.Group;
            summary22.IgnoreNullValues = true;
            summary22.FormatString = "{0:n2}";
            xrTableCell52.Summary = summary22;




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
            XRSummary summarytotal17 = new XRSummary();
            XRSummary summarytotal18 = new XRSummary();
            XRSummary summarytotal19 = new XRSummary();
            XRSummary summarytotal20 = new XRSummary();
            XRSummary summarytotal21 = new XRSummary();
            XRSummary summarytotal22 = new XRSummary();
            XRSummary summarytotal23 = new XRSummary();


            summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "slbbkmtd", "{0:n0}");
            xrTableCell7.Summary = summarytotal16;

            summarytotal17.Running = SummaryRunning.Report;
            summarytotal17.IgnoreNullValues = true;
            summarytotal17.FormatString = "{0:n2}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "slkmtd", "{0:n2}");
            xrTableCell13.Summary = summarytotal17;

            summarytotal18.Running = SummaryRunning.Report;
            summarytotal18.IgnoreNullValues = true;
            summarytotal18.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "slbbnhapkm", "{0:n0}");
            xrTableCell19.Summary = summarytotal18;

            summarytotal19.Running = SummaryRunning.Report;
            summarytotal19.IgnoreNullValues = true;
            summarytotal19.FormatString = "{0:n2}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "slnhapkm", "{0:n2}");
            xrTableCell20.Summary = summarytotal19;

            summarytotal20.Running = SummaryRunning.Report;
            summarytotal20.IgnoreNullValues = true;
            summarytotal20.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "slbbxuatkm", "{0:n0}");
            xrTableCell21.Summary = summarytotal20;

            summarytotal21.Running = SummaryRunning.Report;
            summarytotal21.IgnoreNullValues = true;
            summarytotal21.FormatString = "{0:n2}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "slxuatkm", "{0:n2}");
            xrTableCell23.Summary = summarytotal21;

            summarytotal22.Running = SummaryRunning.Report;
            summarytotal22.IgnoreNullValues = true;
            summarytotal22.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "slbbtonkm", "{0:n0}");
            xrTableCell30.Summary = summarytotal22;

            summarytotal23.Running = SummaryRunning.Report;
            summarytotal23.IgnoreNullValues = true;
            summarytotal23.FormatString = "{0:n2}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "sltonkm", "{0:n2}");
            xrTableCell31.Summary = summarytotal23;

            xrTableCell60.DataBindings.Add("Text", DataSource, "mahang");
            xrTableCell2.DataBindings.Add("Text", DataSource, "tenhang");
            xrTableCell14.DataBindings.Add("Text", DataSource, "slbbkmtd", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "slkmtd", "{0:n2}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "slbbnhapkm", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "slnhapkm", "{0:n2}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "slbbxuatkm", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "slxuatkm", "{0:n2}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "slbbtonkm", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "sltonkm", "{0:n2}");
        }

    }
}
