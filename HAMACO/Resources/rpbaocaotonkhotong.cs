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
    public partial class rpbaocaotonkhotong : DevExpress.XtraReports.UI.XtraReport
    {
        string ngaychungtu;
        public rpbaocaotonkhotong()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b)
        {
            ngaychungtu = a;
            string thang = String.Format("{0:MM}", DateTime.Parse(a));
            string nam = String.Format("{0:yyyy}", DateTime.Parse(a));
            string ten = "Báo cáo tồn kho tháng " + thang + " năm " + nam;
            xrLabel2.Text = ten.ToUpper();
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel6.Text = ten;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

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

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell70.DataBindings.Add("Text", DataSource, "tttoncuoi", "{0:n0}");
            xrTableCell70.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell69.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n2}");
            xrTableCell69.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell68.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            xrTableCell68.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell67.DataBindings.Add("Text", DataSource, "tienxuatban", "{0:n0}");
            xrTableCell67.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell66.DataBindings.Add("Text", DataSource, "trigiaton", "{0:n0}");
            xrTableCell66.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n2}";
            xrTableCell65.DataBindings.Add("Text", DataSource, "xuatban", "{0:n2}");
            xrTableCell65.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell64.DataBindings.Add("Text", DataSource, "tienxuatchuyen", "{0:n0}");
            xrTableCell64.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n2}";
            xrTableCell63.DataBindings.Add("Text", DataSource, "xuatchuyen", "{0:n2}");
            xrTableCell63.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell62.DataBindings.Add("Text", DataSource, "tiennhapchuyen", "{0:n0}");
            xrTableCell62.Summary = summarytotal9;



            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n2}";
            xrTableCell61.DataBindings.Add("Text", DataSource, "nhapchuyen", "{0:n2}");
            xrTableCell61.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell60.DataBindings.Add("Text", DataSource, "tiennhapdau", "{0:n0}");
            xrTableCell60.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n2}";
            xrTableCell59.DataBindings.Add("Text", DataSource, "nhapdau", "{0:n2}");
            xrTableCell59.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell58.DataBindings.Add("Text", DataSource, "tientondau", "{0:n0}");
            xrTableCell58.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Report;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n2}";
            xrTableCell57.DataBindings.Add("Text", DataSource, "tondau", "{0:n0}");
            xrTableCell57.Summary = summarytotal15;

            tenhang.DataBindings.Add("Text", DataSource, "tenkho");
            xrTableCell25.DataBindings.Add("Text", DataSource, "tondau", "{0:n2}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "tientondau", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "nhapdau", "{0:n2}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "tiennhapdau", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "nhapchuyen", "{0:n2}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "tiennhapchuyen", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "xuatchuyen", "{0:n2}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "tienxuatchuyen", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "xuatban", "{0:n2}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "trigiaton", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "tienxuatban", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n2}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "tttoncuoi", "{0:n0}");

        }

        private void tenhang_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            DataTable temp=new DataTable();
            gencon gen=new gencon();
            baocaotonkho bctk=new baocaotonkho();
            
            temp=gen.GetTable("select a.StockID from Stock a, Stock b where a.StockID=b.Parent and a.StockCode='"+ e.Brick.Text.Substring(0,2)+"'");
            if (temp.Rows.Count > 1)
            {
                string makho = gen.GetString("select BranchID from Stock where StockCode='" + e.Brick.Text.Substring(0, 2) + "'");
                bctk.inbctktong(ngaychungtu, "tsbtbctktttdv", makho);
            }
            else
            {
                string makho = gen.GetString("select StockID from Stock where StockCode='" + e.Brick.Text.Substring(0, 2) + "'");
                bctk.inbctktong(ngaychungtu, "tsbtbctktsl", makho);
            }
        }
    }
}
