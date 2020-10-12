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
    public partial class rpchitietcongno : DevExpress.XtraReports.UI.XtraReport
    {
        public rpchitietcongno()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b,string c,string d,string no,string co,string tsbt)
        {
            try
            {
                xrTableCell26.Text = String.Format("{0:n0}",Double.Parse(no));
            }
            catch { }
            try
            {
                xrTableCell32.Text = String.Format("{0:n0}", Double.Parse(co));
            }
            catch { }
            if (tsbt == "an")
            {
                GroupHeader1.Visible = false;
                GroupFooter1.Visible = false;
            }
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel3.Text = c;
            xrLabel2.Text = a;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }


        public void gettieudetndn(string ten, string makhach,string kho,string an,string no,string co)
        {
            try
            {
                xrTableCell26.Text = String.Format("{0:n0}", Double.Parse(no));
            }
            catch { }
            try
            {
                xrTableCell32.Text = String.Format("{0:n0}", Double.Parse(co));
            }
            catch { }
            if (an == "an")
            {
                GroupHeader1.Visible = false;
                GroupFooter1.Visible = false;
            }
            xrLabel3.Text = gen.GetString("select AccountingObjectName+' ('+AccountingObjectCode+') ' from AccountingObject where AccountingObjectID='" + makhach + "'") + ten.ToLower();
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            try
            {
                xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            }
            catch
            {
                try
                {
                    xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'").ToUpper();
                }
                catch
                {
                    xrLabel5.Text = gen.GetString("select Top 1 CompanyName from Center");
                }
            }
            xrLabel2.Text = ten;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField2 = new GroupField("Mã kho");
            GroupHeader1.GroupFields.Add(groupField2);
            xrLabel6.DataBindings.Add("Text", DataSource, "Tên kho");

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


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
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
            xrTableCell25.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.None;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell38.DataBindings.Add("Text", DataSource, "Lũy kế nợ", "{0:n0}");
            xrTableCell38.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.None;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "Lũy kế có", "{0:n0}");
            xrTableCell39.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Group;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell34.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell35.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell36.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell37.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell37.Summary = summarytotal10;


            xrTableCell9.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Ngày lập","{0:dd-MM-yyyy}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Diễn giải");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell15.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Lũy kế nợ", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Lũy kế có", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Hạn nợ");
        }

        public void BindDatatndn(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField2 = new GroupField("Mã kho");
            GroupHeader1.GroupFields.Add(groupField2);
            xrLabel6.DataBindings.Add("Text", DataSource, "Tên kho");

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


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
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
            xrTableCell25.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.None;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell38.DataBindings.Add("Text", DataSource, "Lũy kế nợ", "{0:n0}");
            xrTableCell38.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.None;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "Lũy kế có", "{0:n0}");
            xrTableCell39.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Group;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell34.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell35.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell36.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell37.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell37.Summary = summarytotal10;


            xrTableCell9.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Diễn giải");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell15.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Lũy kế nợ", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Lũy kế có", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Hạn nợ");
        }
    }
}
