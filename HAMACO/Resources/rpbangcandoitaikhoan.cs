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
    public partial class rpbangcandoitaikhoan : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        string tsbt1, tungay1, denngay1;
        DataTable dt = new DataTable();
        public rpbangcandoitaikhoan()
        {
            InitializeComponent();
        }
        public void gettieude(string tsbt, string denngay,string tungay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrTableCell37.Text = gen.GetString("select Top 1 Title from Center");
            xrTableCell40.Text = gen.GetString("select Top 1 DGM from Center");
            xrTableCell39.Text = gen.GetString("select Top 1 ChiefAccountant from Center");
            string diachi = gen.GetString("select Top 1 Province from Center") + ", ngày ";
            try
            {
                string ngay = DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month).ToString();
                diachi = diachi + ngay + " tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
            }
            catch
            {
                string ngay = DateTime.DaysInMonth(DateTime.Parse(tungay).Year, DateTime.Parse(tungay).Month).ToString();
                diachi = diachi + ngay + " tháng " + String.Format("{0:MM}", DateTime.Parse(tungay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(tungay));
            }
            xrTableCell25.Text = diachi;

            tsbt1 = tsbt;
            tungay1 = tungay;
            denngay1 = denngay;
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
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            if (tsbt == "scth" || tsbt == "sktth")
                xrTableCell15.ForeColor = System.Drawing.Color.Navy;
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            dt = da;
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
            xrTableCell27.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell27.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell28.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell29.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell30.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell31.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell32.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell33.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
            xrTableCell34.Summary = summarytotal8;

            xrTableCell15.DataBindings.Add("Text", DataSource, "Tài khoản");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên tài khoản");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
        }

        private void xrTableCell15_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            tonghoptaikhoan thtk = new tonghoptaikhoan();
            string name = gen.GetString("select AccountName from Account where AccountNumber='" + e.Brick.Text + "'");
            if (tsbt1 == "sktth" || tsbt1 == "sktthtomtat")
            {
                Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
                F.getngaychungtu(tungay1);
                F.getngaycuoi(denngay1);
                F.gettsbt(tsbt1);
                F.getuser(e.Brick.Text);
                F.ShowDialog();
            }
            else if (tsbt1 == "scth" || tsbt1 == "scthtomtat")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (e.Brick.Text == dt.Rows[i][0].ToString())
                    {
                        string nodau = dt.Rows[i][2].ToString();
                        string codau = dt.Rows[i][3].ToString();
                        string lkno = dt.Rows[i][6].ToString();
                        string lkco = dt.Rows[i][7].ToString();
                        string nocuoi = dt.Rows[i][8].ToString();
                        string cocuoi = dt.Rows[i][9].ToString();
                        thtk.loadchitietsctongth(tungay1, denngay1, tsbt1, e.Brick.Text, name, nodau, codau, lkno, lkco, nocuoi, cocuoi);
                        return;
                    }
                }
            }
        }
    }
}
