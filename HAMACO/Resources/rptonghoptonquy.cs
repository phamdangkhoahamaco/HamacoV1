using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
namespace HAMACO.Resources
{
    public partial class rptonghoptonquy : DevExpress.XtraReports.UI.XtraReport
    {
        public rptonghoptonquy()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string taikhoan, string tentk, string ngaychungtu, DataTable dt)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrTableCell21.Text = gen.GetString("select Top 1  ChiefAccountant from Center");
            xrTableCell20.Text = gen.GetString("select Top 1 Cashier from Center");
            xrLabel5.Text = tentk.ToUpper();
            string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            xrLabel3.Text = "THÁNG " + thang + " NĂM " + nam;
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            
            DataSource = dt;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Thu", "{0:n0}");
            xrTableCell13.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell14.DataBindings.Add("Text", DataSource, "Chi", "{0:n0}");
            xrTableCell14.Summary = summarytotal1;

            xrTableCell6.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Tồn đầu", "{0:n0}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Thu", "{0:n0}");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Chi", "{0:n0}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tồn cuối", "{0:n0}");
        }
    }
}
