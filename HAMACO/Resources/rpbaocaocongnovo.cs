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
    public partial class rpbaocaocongnovo : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaocongnovo()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();

        public void gettieude(string tungay, string denngay, string kho, string makhach)
        {
            xrLabel1.Text = gen.GetString("select CompanyName from Center");
            xrLabel2.Text = "BÁO CÁO CÔNG NỢ VỎ " + "TỪ NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            try
            {
                xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'").ToUpper();
            }
            catch { xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper(); }
            try
            {
                xrLabel3.Text = gen.GetString("SELECT AccountingObjectCode+' - '+AccountingObjectName FROM AccountingObject WHERE AccountingObjectID='" + makhach + "'").ToUpper();
            }
            catch { xrLabel3.Text = gen.GetString("SELECT AccountingObjectCode+' - '+AccountingObjectName FROM AccountingObject WHERE AccountingObjectCode='" + makhach + "'").ToUpper(); }
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            GroupHeader1.Visible = false;
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Loại");
            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell25.DataBindings.Add("Text", DataSource, "Loại");

            xrTableCell35.DataBindings.Add("Text", DataSource, "Đầu kỳ", "{0:n0}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n0}";
            xrTableCell35.Summary = summary1;

            xrTableCell36.DataBindings.Add("Text", DataSource, "Tiền đầu kỳ", "{0:n0}");
            XRSummary summary2 = new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell36.Summary = summary2;

            xrTableCell37.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            XRSummary summary3 = new XRSummary();
            summary3.Running = SummaryRunning.Group;
            summary3.IgnoreNullValues = true;
            summary3.FormatString = "{0:n0}";
            xrTableCell37.Summary = summary3;

            xrTableCell38.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            XRSummary summary4 = new XRSummary();
            summary4.Running = SummaryRunning.Group;
            summary4.IgnoreNullValues = true;
            summary4.FormatString = "{0:n0}";
            xrTableCell38.Summary = summary4;

            xrTableCell39.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            XRSummary summary5 = new XRSummary();
            summary5.Running = SummaryRunning.Group;
            summary5.IgnoreNullValues = true;
            summary5.FormatString = "{0:n0}";
            xrTableCell39.Summary = summary5;

            xrTableCell40.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
            XRSummary summary6 = new XRSummary();
            summary6.Running = SummaryRunning.Group;
            summary6.IgnoreNullValues = true;
            summary6.FormatString = "{0:n0}";
            xrTableCell40.Summary = summary6;

            xrTableCell41.DataBindings.Add("Text", DataSource, "Cuối kỳ", "{0:n0}");
            XRSummary summary7 = new XRSummary();
            summary7.Running = SummaryRunning.Group;
            summary7.IgnoreNullValues = true;
            summary7.FormatString = "{0:n0}";
            xrTableCell41.Summary = summary7;


            xrTableCell42.DataBindings.Add("Text", DataSource, "Tiền cuối kỳ", "{0:n0}");
            XRSummary summary8 = new XRSummary();
            summary8.Running = SummaryRunning.Group;
            summary8.IgnoreNullValues = true;
            summary8.FormatString = "{0:n0}";
            xrTableCell42.Summary = summary8;
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
            xrTableCell27.DataBindings.Add("Text", DataSource, "Đầu kỳ", "{0:n0}");
            xrTableCell27.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Tiền đầu kỳ", "{0:n0}");
            xrTableCell28.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            xrTableCell29.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            xrTableCell30.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            xrTableCell31.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
            xrTableCell32.Summary = summarytotal6;


            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Cuối kỳ", "{0:n0}");
            xrTableCell33.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Tiền cuối kỳ", "{0:n0}");
            xrTableCell34.Summary = summarytotal8;


            xrTableCell15.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đầu kỳ", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Tiền đầu kỳ", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Cuối kỳ", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Tiền cuối kỳ", "{0:n0}");
        }
    }
}
