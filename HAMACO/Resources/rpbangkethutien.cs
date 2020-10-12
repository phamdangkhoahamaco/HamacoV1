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
    public partial class rpbangkethutien : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkethutien()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string kho, string phieu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel3.Text = "KHO "+gen.GetString("select StockCode+' - '+StockName from Stock where StockID='"+kho+"'").ToUpper();
            xrLabel2.Text = phieu;
            xrLabel5.Text = "TỪ NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            XRSummary summarytotal1 = new XRSummary();

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell16.Summary = summarytotal1;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
        }
    }
}
