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
    public partial class rptonghopdoanhthu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptonghopdoanhthu()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string denngay,string userid,string tungay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");

            if (DateTime.Parse(tungay).Day == 1 && DateTime.Parse(denngay).Day == DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month) && DateTime.Parse(tungay).Year == DateTime.Parse(denngay).Year)
            {
                if (DateTime.Parse(tungay).Month == DateTime.Parse(denngay).Month)
                    xrLabel5.Text = "THÁNG " + DateTime.Parse(denngay).Month + " NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 3)
                    xrLabel5.Text = "QUÝ I NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 4 && DateTime.Parse(denngay).Month == 6)
                    xrLabel5.Text = "QUÝ II NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 7 && DateTime.Parse(denngay).Month == 9)
                    xrLabel5.Text = "QUÝ III NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 10 && DateTime.Parse(denngay).Month == 12)
                    xrLabel5.Text = "QUÝ VI NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 12)
                    xrLabel5.Text = "NĂM " + DateTime.Parse(denngay).Year;
                else
                    xrLabel5.Text = "TỪ THÁNG " + DateTime.Parse(tungay).Month + " ĐẾN THÁNG " + DateTime.Parse(denngay).Month + " NĂM " + DateTime.Parse(denngay).Year;
            }

            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {

            DataSource = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Doanh thu", "{0:n0}");
            xrTableCell7.Summary = summarytotal;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Chi phí", "{0:n0}");
            xrTableCell10.Summary = summarytotal2;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;


            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã kho");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên kho");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Doanh thu", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Chi phí", "{0:n0}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
        }
    }
}
