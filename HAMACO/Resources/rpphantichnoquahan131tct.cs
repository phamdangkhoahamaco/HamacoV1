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
    public partial class rpphantichnoquahan131tct : DevExpress.XtraReports.UI.XtraReport
    {
        public rpphantichnoquahan131tct()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b, string c, string d)
        {
            try
            {
                xrTableCell29.Text = String.Format("{0:n0}", Double.Parse(d));
            }
            catch { }
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel3.Text = c;
            xrLabel2.Text = a;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Đơn vị");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell43.DataBindings.Add("Text", DataSource, "Đơn vị");

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
            xrTableCell32.DataBindings.Add("Text", DataSource, "Số quá hạn", "{0:n0}");
            xrTableCell32.Summary = summarytotal;

            /*summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell23.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell24.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell25.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell25.Summary = summarytotal4;*/

            xrTableCell15.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Hạn nợ");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:0,0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Ngày nợ", "{0:dd-MM-yyyy}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Phiếu trả");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền trả", "{0:0,0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Ngày trả", "{0:dd-MM-yyyy}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Số dư nợ", "{0:0,0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Số quá hạn", "{0:0,0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Số ngày", "{0:n0}");
        }
    }
}
