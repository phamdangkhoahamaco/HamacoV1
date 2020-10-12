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
    public partial class rpsocai : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpsocai()
        {
            InitializeComponent();
        }

        public void gettieude(string a, string b,string diachi)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrTableCell37.Text = gen.GetString("select Top 1 Title from Center");
            xrTableCell40.Text = gen.GetString("select Top 1 DGM from Center");
            xrTableCell39.Text = gen.GetString("select Top 1 ChiefAccountant from Center");
            xrTableCell34.Text = diachi;
            xrLabel2.Text = a;
            xrLabel5.Text = b;
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell21.Summary = summarytotal1;

            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
        }
        public void BindDatasum(DataTable da)
        {
            try { xrTableCell8.Text = String.Format("{0:n0}", Double.Parse(da.Rows[0][0].ToString())); }
            catch { }
            try { xrTableCell26.Text = String.Format("{0:n0}", Double.Parse(da.Rows[0][1].ToString())); }
            catch { }
            try { xrTableCell30.Text = String.Format("{0:n0}", Double.Parse(da.Rows[0][2].ToString())); }
            catch { }
            try { xrTableCell31.Text = String.Format("{0:n0}", Double.Parse(da.Rows[0][3].ToString())); }
            catch { }
            try { xrTableCell32.Text = String.Format("{0:n0}", Double.Parse(da.Rows[0][4].ToString())); }
            catch { }
            try { xrTableCell33.Text = String.Format("{0:n0}", Double.Parse(da.Rows[0][5].ToString())); }
            catch { }
        }
    }
}
