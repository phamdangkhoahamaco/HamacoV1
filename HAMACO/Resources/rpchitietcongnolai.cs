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
    public partial class rpchitietcongnolai : DevExpress.XtraReports.UI.XtraReport
    {
        public rpchitietcongnolai()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b, string d)
        {
            try
            {
                xrTableCell44.Text = String.Format("{0:n0}", Double.Parse(d));
            }
            catch { }
            xrLabel2.Text = a;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Mã khách");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell11.DataBindings.Add("Text", DataSource, "Mã khách");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell12.DataBindings.Add("Text", DataSource, "Tên khách");

            xrTableCell49.DataBindings.Add("Text", DataSource, "Số ngày", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell49.Summary = summary;

            xrTableCell50.DataBindings.Add("Text", DataSource, "Gửi vào", "{0:n0}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n0}";
            xrTableCell50.Summary = summary1;

            xrTableCell51.DataBindings.Add("Text", DataSource, "Rút ra", "{0:n0}");
            XRSummary summary2= new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell51.Summary = summary2;

            xrTableCell54.DataBindings.Add("Text", DataSource, "Tiền lãi", "{0:n0}");
            XRSummary summary3 = new XRSummary();
            summary3.Running = SummaryRunning.Group;
            summary3.IgnoreNullValues = true;
            summary3.FormatString = "{0:n0}";
            xrTableCell54.Summary = summary3;

            xrTableCell55.DataBindings.Add("Text", DataSource, "Thuế TNCN", "{0:n0}");
            XRSummary summary4 = new XRSummary();
            summary4.Running = SummaryRunning.Group;
            summary4.IgnoreNullValues = true;
            summary4.FormatString = "{0:n0}";
            xrTableCell55.Summary = summary4;

            xrTableCell56.DataBindings.Add("Text", DataSource, "Thực lãi", "{0:n0}");
            XRSummary summary5 = new XRSummary();
            summary5.Running = SummaryRunning.Group;
            summary5.IgnoreNullValues = true;
            summary5.FormatString = "{0:n0}";
            xrTableCell56.Summary = summary5;


            xrTableCell52.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            XRSummary summary7 = new XRSummary();
            summary7.Running = SummaryRunning.None;
            summary7.IgnoreNullValues = true;
            summary7.FormatString = "{0:n0}";
            xrTableCell52.Summary = summary7;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();

            
            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "Thuế TNCN", "{0:n0}");
            xrTableCell47.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "Gửi vào", "{0:n0}");
            xrTableCell42.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "Rút ra", "{0:n0}");
            xrTableCell43.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "Tiền lãi", "{0:n0}");
            xrTableCell46.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "Thực lãi", "{0:n0}");
            xrTableCell48.Summary = summarytotal5;

            xrTableCell26.DataBindings.Add("Text", DataSource, "Từ ngày", "{0:dd-MM-yyyy}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Đến ngày", "{0:dd-MM-yyyy}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Số ngày", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Gửi vào", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Rút ra", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Lãi suất", "{0:n2}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Tiền lãi", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "Thuế TNCN", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "Thực lãi", "{0:n0}");
        }

        public void BindDataTong(DataTable da)
        {
            DataSource = da;

            GroupHeader1.Visible = false;
            Detail.Visible = false;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Mã khách");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell11.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell39.DataBindings.Add("Text", DataSource, "Mã khách");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell12.DataBindings.Add("Text", DataSource, "Tên khách");

            xrTableCell49.DataBindings.Add("Text", DataSource, "Số ngày", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell49.Summary = summary;

            xrTableCell50.DataBindings.Add("Text", DataSource, "Gửi vào", "{0:n0}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n0}";
            xrTableCell50.Summary = summary1;

            xrTableCell51.DataBindings.Add("Text", DataSource, "Rút ra", "{0:n0}");
            XRSummary summary2 = new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell51.Summary = summary2;

            xrTableCell54.DataBindings.Add("Text", DataSource, "Tiền lãi", "{0:n0}");
            XRSummary summary3 = new XRSummary();
            summary3.Running = SummaryRunning.Group;
            summary3.IgnoreNullValues = true;
            summary3.FormatString = "{0:n0}";
            xrTableCell54.Summary = summary3;

            xrTableCell55.DataBindings.Add("Text", DataSource, "Thuế TNCN", "{0:n0}");
            XRSummary summary4 = new XRSummary();
            summary4.Running = SummaryRunning.Group;
            summary4.IgnoreNullValues = true;
            summary4.FormatString = "{0:n0}";
            xrTableCell55.Summary = summary4;

            xrTableCell56.DataBindings.Add("Text", DataSource, "Thực lãi", "{0:n0}");
            XRSummary summary5 = new XRSummary();
            summary5.Running = SummaryRunning.Group;
            summary5.IgnoreNullValues = true;
            summary5.FormatString = "{0:n0}";
            xrTableCell56.Summary = summary5;


            xrTableCell52.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            XRSummary summary7 = new XRSummary();
            summary7.Running = SummaryRunning.None;
            summary7.IgnoreNullValues = true;
            summary7.FormatString = "{0:n0}";
            xrTableCell52.Summary = summary7;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "Thuế TNCN", "{0:n0}");
            xrTableCell47.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "Gửi vào", "{0:n0}");
            xrTableCell42.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "Rút ra", "{0:n0}");
            xrTableCell43.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "Tiền lãi", "{0:n0}");
            xrTableCell46.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "Thực lãi", "{0:n0}");
            xrTableCell48.Summary = summarytotal5;

            xrTableCell26.DataBindings.Add("Text", DataSource, "Từ ngày", "{0:dd-MM-yyyy}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Đến ngày", "{0:dd-MM-yyyy}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Số ngày", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Gửi vào", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Rút ra", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Lãi suất", "{0:n2}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Tiền lãi", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "Thuế TNCN", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "Thực lãi", "{0:n0}");
        }
    }
}
