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
    public partial class rptonghoptaikhoantong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptonghoptaikhoantong()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b,string diachi)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrTableCell37.Text = gen.GetString("select Top 1 Title from Center");
            xrTableCell40.Text = gen.GetString("select Top 1 DGM from Center");
            xrTableCell39.Text = gen.GetString("select Top 1 ChiefAccountant from Center");
            xrTableCell34.Text = diachi;
            xrLabel2.Text = a;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
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


            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yy}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
        }
        public void BindDatasum(DataTable da)
        {
            /*DataSource = da;
            xrTableCell8.DataBindings.Add("Text", DataSource, "Nợ đầu", "{0:0,0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Có đầu", "{0:0,0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Lũy kế nợ", "{0:0,0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Lũy kế có", "{0:0,0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Nợ cuối", "{0:0,0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Có cuối", "{0:0,0}");*/

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
