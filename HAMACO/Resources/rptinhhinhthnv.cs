using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
namespace HAMACO.Resources
{
    public partial class rptinhhinhthnv : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rptinhhinhthnv()
        {
            InitializeComponent();
        }
        public void gettieude(string tungay, string denngay)
        {
            string thangso = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            string namso = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();
            string thangtruoc = DateTime.Parse(tungay).Month.ToString();
            string thang = DateTime.Parse(denngay).Month.ToString();
            string nam = DateTime.Parse(denngay).Year.ToString();
            
            if (thangtruoc == thang)
                xrLabel1.Text = "Kết quả kinh doanh tháng " + thang + " năm " + nam;
            else if (thangtruoc == "1" && thang == "3")
                xrLabel1.Text = "Kết quả kinh doanh quý " + 1 + " năm " + nam;
            else if (thangtruoc == "4" && thang == "6")
                xrLabel1.Text = "Kết quả kinh doanh quý " + 2 + " năm " + nam;
            else if (thangtruoc == "7" && thang == "9")
                xrLabel1.Text = "Kết quả kinh doanh quý " + 3 + " năm " + nam;
            else if (thangtruoc == "10" && thang == "12")
                xrLabel1.Text = "Kết quả kinh doanh quý " + 4 + " năm " + nam;
            else if (thangtruoc == "1" && thang == "12")
                xrLabel1.Text = "Kết quả kinh doanh năm " + nam;
            else
                xrLabel1.Text = "Kết quả kinh doanh tháng " + thangtruoc + " - " + thang + " năm " + nam;

            DataTable temp = gen.GetTable("tinhhinhthuchiennghiavuvoinhanuoc '" + thangso + "','" + namso + "','" + thangtruoc + "','" + thang + "','" + nam + "'");
            DataTable dt = new DataTable();
            dt.Columns.Add("Chỉ tiêu", Type.GetType("System.String"));
            dt.Columns.Add("Mã số", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Mã nhóm", Type.GetType("System.String"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();

                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2].ToString();
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6].ToString();
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7].ToString();

                dr[8] = temp.Rows[i][8].ToString();
                dr[9] = temp.Rows[i][9].ToString();
                dt.Rows.Add(dr);
            }

            DataSource = dt;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Nhóm");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell1.DataBindings.Add("Text", DataSource, "Nhóm");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Mã nhóm");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();

            XRSummary summarytotal10 = new XRSummary();
            XRSummary summarytotal11 = new XRSummary();
            XRSummary summarytotal12 = new XRSummary();
            XRSummary summarytotal13 = new XRSummary();
            XRSummary summarytotal14 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell29.Summary = summarytotal;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell30.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell31.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell32.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell33.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell34.Summary = summarytotal7;



            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell14.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell14.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Group;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell15.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell15.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Group;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell16.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Group;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell18.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Group;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell10.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Group;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell17.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell17.Summary = summarytotal15;

            xrTableCell19.DataBindings.Add("Text", DataSource, "Chỉ tiêu");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Mã số");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
        }
    }
}
