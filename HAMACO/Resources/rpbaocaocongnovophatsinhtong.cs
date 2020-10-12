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
    public partial class rpbaocaocongnovophatsinhtong : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaocongnovophatsinhtong()
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
                xrLabel3.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'").ToUpper();
            }
            catch { xrLabel3.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper(); }
            try
            {
                xrLabel5.Text = gen.GetString("SELECT AccountingObjectCode+' - '+AccountingObjectName FROM AccountingObject WHERE AccountingObjectID='" + makhach + "'").ToUpper();
            }
            catch { xrLabel5.Text = gen.GetString("SELECT AccountingObjectCode+' - '+AccountingObjectName FROM AccountingObject WHERE AccountingObjectCode='" + makhach + "'").ToUpper(); }
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Ngày");
            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell11.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");

            xrTableCell15.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n0}";
            xrTableCell15.Summary = summary1;

            xrTableCell13.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            XRSummary summary2 = new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell13.Summary = summary2;

            xrTableCell17.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            XRSummary summary3 = new XRSummary();
            summary3.Running = SummaryRunning.Group;
            summary3.IgnoreNullValues = true;
            summary3.FormatString = "{0:n0}";
            xrTableCell17.Summary = summary3;

            xrTableCell14.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
            XRSummary summary4 = new XRSummary();
            summary4.Running = SummaryRunning.Group;
            summary4.IgnoreNullValues = true;
            summary4.FormatString = "{0:n0}";
            xrTableCell14.Summary = summary4;

            xrTableCell16.DataBindings.Add("Text", DataSource, "Đơn giá nhập", "{0:n0}");
            XRSummary summary5 = new XRSummary();
            summary5.Running = SummaryRunning.Group;
            summary5.IgnoreNullValues = true;
            summary5.FormatString = "{0:n0}";
            xrTableCell16.Summary = summary5;

            xrTableCell18.DataBindings.Add("Text", DataSource, "Đơn giá xuất", "{0:n0}");
            XRSummary summary6 = new XRSummary();
            summary6.Running = SummaryRunning.Group;
            summary6.IgnoreNullValues = true;
            summary6.FormatString = "{0:n0}";
            xrTableCell18.Summary = summary6;


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
            xrTableCell29.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            xrTableCell29.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            xrTableCell31.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            xrTableCell32.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
            xrTableCell34.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Đơn giá nhập", "{0:n0}");
            xrTableCell30.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Đơn giá xuất", "{0:n0}");
            xrTableCell33.Summary = summarytotal6;

            xrTableCell19.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Đơn giá nhập", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "Đơn giá xuất", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
        }

        public void BindDataphieu(DataTable da)
        {
            DataSource = da;

            GroupField groupField2 = new GroupField("Ngày");
            GroupHeader1.GroupFields.Add(groupField2);
            xrTableCell11.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Số phiếu");
            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số phiếu");           
            

            xrTableCell15.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n0}";
            xrTableCell15.Summary = summary1;

            xrTableCell13.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            XRSummary summary2 = new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell13.Summary = summary2;

            xrTableCell17.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            XRSummary summary3 = new XRSummary();
            summary3.Running = SummaryRunning.Group;
            summary3.IgnoreNullValues = true;
            summary3.FormatString = "{0:n0}";
            xrTableCell17.Summary = summary3;

            xrTableCell14.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
            XRSummary summary4 = new XRSummary();
            summary4.Running = SummaryRunning.Group;
            summary4.IgnoreNullValues = true;
            summary4.FormatString = "{0:n0}";
            xrTableCell14.Summary = summary4;

            xrTableCell16.DataBindings.Add("Text", DataSource, "Đơn giá nhập", "{0:n0}");
            XRSummary summary5 = new XRSummary();
            summary5.Running = SummaryRunning.Group;
            summary5.IgnoreNullValues = true;
            summary5.FormatString = "{0:n0}";
            xrTableCell16.Summary = summary5;

            xrTableCell18.DataBindings.Add("Text", DataSource, "Đơn giá xuất", "{0:n0}");
            XRSummary summary6 = new XRSummary();
            summary6.Running = SummaryRunning.Group;
            summary6.IgnoreNullValues = true;
            summary6.FormatString = "{0:n0}";
            xrTableCell18.Summary = summary6;


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
            xrTableCell29.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            xrTableCell29.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            xrTableCell31.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            xrTableCell32.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
            xrTableCell34.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Đơn giá nhập", "{0:n0}");
            xrTableCell30.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Đơn giá xuất", "{0:n0}");
            xrTableCell33.Summary = summarytotal6;

            xrTableCell19.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Đơn giá nhập", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Tiền nhập", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "Đơn giá xuất", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Tiền xuất", "{0:n0}");
        }
    }
}
