using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;


namespace HAMACO.Resources
{
    public partial class rpbangketheodoinganhang : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangketheodoinganhang()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "BẢNG KÊ THEO DÕI TÀI KHOẢN NGÂN HÀNG";
            xrLabel5.Text = "NGÀY " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel3.Text = "Bảng kê theo dõi tài khoản ngân hàng ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(string ngay)
        {
            string thang = DateTime.Parse(ngay).Month.ToString();
            string nam = DateTime.Parse(ngay).Year.ToString();
            string thangtruoc = DateTime.Parse(ngay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngay).AddMonths(-1).Year.ToString();

            DataTable dt = new DataTable();
            dt.Columns.Add("Ngân hàng", Type.GetType("System.String"));
            dt.Columns.Add("Đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Công nợ trả", Type.GetType("System.Double"));
            dt.Columns.Add("Chuyển trả", Type.GetType("System.Double"));
            dt.Columns.Add("Thu nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Lãi vay", Type.GetType("System.Double"));
            dt.Columns.Add("Chuyển khoản", Type.GetType("System.Double"));
            dt.Columns.Add("Cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Đầu kỳ vay", Type.GetType("System.Double"));
            dt.Columns.Add("Vay nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Trả nợ vay", Type.GetType("System.Double"));
            dt.Columns.Add("Cuối kỳ vay", Type.GetType("System.Double"));

            DataTable temp = gen.GetTable("tonghoptaikhoanquytonnganhang '" + ngay + "','" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "'");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString().Replace("Tiền gửi NH","").Replace("(VND)","").Replace("(VNĐ)","").Trim();
                if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                    dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7];
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8];
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[9] = temp.Rows[i][9];
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = temp.Rows[i][10];
                 if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[11] = temp.Rows[i][11];
                dt.Rows.Add(dr);
            }

            DataSource = dt;
        
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();
            XRSummary summarytotal9 = new XRSummary();
            XRSummary summarytotal10 = new XRSummary();
            XRSummary summarytotal11 = new XRSummary();

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Đầu kỳ", "{0:n0}");
            xrTableCell23.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Công nợ trả", "{0:n0}");
            xrTableCell24.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell25.DataBindings.Add("Text", DataSource, "Chuyển trả", "{0:n0}");
            xrTableCell25.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell26.DataBindings.Add("Text", DataSource, "Thu nợ", "{0:n0}");
            xrTableCell26.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Lãi vay", "{0:n0}");
            xrTableCell27.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Chuyển khoản", "{0:n0}");
            xrTableCell28.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Cuối kỳ", "{0:n0}");
            xrTableCell29.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Đầu kỳ vay", "{0:n0}");
            xrTableCell30.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Vay nợ", "{0:n0}");
            xrTableCell31.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Report;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Trả nợ vay", "{0:n0}");
            xrTableCell32.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Cuối kỳ vay", "{0:n0}");
            xrTableCell33.Summary = summarytotal11;

            xrTableCell22.DataBindings.Add("Text", DataSource, "Ngân hàng");
            xrTableCell1.DataBindings.Add("Text", DataSource, "Đầu kỳ", "{0:n0}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Công nợ trả", "{0:n0}");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Chuyển trả", "{0:n0}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Thu nợ", "{0:n0}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Lãi vay", "{0:n0}");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Chuyển khoản", "{0:n0}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Cuối kỳ", "{0:n0}");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Đầu kỳ vay", "{0:n0}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Vay nợ", "{0:n0}");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Trả nợ vay", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Cuối kỳ vay", "{0:n0}");
        }
    }
}
