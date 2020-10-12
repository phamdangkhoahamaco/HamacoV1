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
    public partial class rpbaocaocongnovotongphatsinh : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaocongnovotongphatsinh()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        string tungay1 = null;
        string denngay1 = null;
        string kho1 = null;
        public void gettieude(string tungay, string denngay, string kho)
        {
            tungay1 = tungay;
            denngay1 = denngay;
            kho1 = kho;
            xrLabel1.Text = gen.GetString("select CompanyName from Center");
            xrLabel2.Text = "BẢNG KÊ TỔNG HỢP PHÁT SINH VỎ " + "TỪ NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            try
            {
                xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'").ToUpper();
            }
            catch { xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper(); }
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader2);
            GroupField groupField2 = new GroupField("Ngày");
            GroupHeader2.GroupFields.Add(groupField2);
            xrTableCell35.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Mã khách");
            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell25.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Tên khách");

            
            xrTableCell27.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n0}";
            xrTableCell27.Summary = summary1;

            xrTableCell28.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            XRSummary summary2 = new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell28.Summary = summary2;

            xrTableCell29.DataBindings.Add("Text", DataSource, "Nợ lại", "{0:n0}");
            XRSummary summary3 = new XRSummary();
            summary3.Running = SummaryRunning.Group;
            summary3.IgnoreNullValues = true;
            summary3.FormatString = "{0:n0}";
            xrTableCell29.Summary = summary3;

            xrTableCell31.DataBindings.Add("Text", DataSource, "Trả nợ", "{0:n0}");
            XRSummary summary4 = new XRSummary();
            summary4.Running = SummaryRunning.Group;
            summary4.IgnoreNullValues = true;
            summary4.FormatString = "{0:n0}";
            xrTableCell31.Summary = summary4;

            xrTableCell33.DataBindings.Add("Text", DataSource, "Xuất thế chân", "{0:n0}");
            XRSummary summary5 = new XRSummary();
            summary5.Running = SummaryRunning.Group;
            summary5.IgnoreNullValues = true;
            summary5.FormatString = "{0:n0}";
            xrTableCell33.Summary = summary5;

            xrTableCell42.DataBindings.Add("Text", DataSource, "Nhập thế chân", "{0:n0}");
            XRSummary summary6 = new XRSummary();
            summary6.Running = SummaryRunning.Group;
            summary6.IgnoreNullValues = true;
            summary6.FormatString = "{0:n0}";
            xrTableCell42.Summary = summary6;

            xrTableCell54.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            XRSummary summary7 = new XRSummary();
            summary7.Running = SummaryRunning.Group;
            summary7.IgnoreNullValues = true;
            summary7.FormatString = "{0:n0}";
            xrTableCell54.Summary = summary7;

            
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
            xrTableCell46.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            xrTableCell46.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            xrTableCell47.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "Nợ lại", "{0:n0}");
            xrTableCell48.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell50.DataBindings.Add("Text", DataSource, "Trả nợ", "{0:n0}");
            xrTableCell50.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell52.DataBindings.Add("Text", DataSource, "Xuất thế chân", "{0:n0}");
            xrTableCell52.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell55.DataBindings.Add("Text", DataSource, "Nhập thế chân", "{0:n0}");
            xrTableCell55.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell57.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            xrTableCell57.Summary = summarytotal7;
            
            xrTableCell15.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Xuất", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Nhập", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Nợ lại", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Tiền nợ", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Trả nợ", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Tiền trả", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Xuất thế chân", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Đơn giá xuất", "{0:n0}");
            xrTableCell39.DataBindings.Add("Text", DataSource, "Nhập thế chân", "{0:n0}");
            xrTableCell40.DataBindings.Add("Text", DataSource, "Đơn giá nhập", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
        }

        private void xrTableCell25_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            baocaocongno131 bccn = new baocaocongno131();
            bccn.loadbccnvotndnphatsinh(tungay1, denngay1, "tsbtbccnvkhthphieu", kho1, e.Brick.Text);       
        }
    }
}
