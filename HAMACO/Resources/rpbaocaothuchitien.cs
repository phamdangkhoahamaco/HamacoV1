using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbaocaothuchitien : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaothuchitien()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string userid)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = xrLabel2.Text + "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));           
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);

            DataTable temp = gen.GetTable("baocaothuchitien '" + userid + "','" + DateTime.Parse(ngaychungtu).Month + "','" + DateTime.Parse(ngaychungtu).Year + "'");

            DataTable dt = new DataTable();
            dt.Columns.Add("Thứ", Type.GetType("System.String"));
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tiền mặt U55", Type.GetType("System.Double"));
            dt.Columns.Add("Ngân hàng U55", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền mặt U166", Type.GetType("System.Double"));
            dt.Columns.Add("Ngân hàng U166", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền mặt Gau166", Type.GetType("System.Double"));
            dt.Columns.Add("Ngân hàng Gau166", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền mặt Mar166", Type.GetType("System.Double"));
            dt.Columns.Add("Ngân hàng Mar166", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền mặt UTN", Type.GetType("System.Double"));
            dt.Columns.Add("Ngân hàng UTN", Type.GetType("System.Double"));
            dt.Columns.Add("Tổng thu", Type.GetType("System.Double"));
            dt.Columns.Add("Tổng chi", Type.GetType("System.Double"));
            dt.Columns.Add("Thanh toán", Type.GetType("System.Double"));
            dt.Columns.Add("Thực nộp 166", Type.GetType("System.Double"));
            dt.Columns.Add("Thực nộp TN", Type.GetType("System.Double"));
            int ngay = Int32.Parse(DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString());
            for (int j = 1; j <= ngay; j++)
            {
                string check = "0";
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (j == Int32.Parse(temp.Rows[i][0].ToString()))
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = gen.NgayTrongTuan(Int32.Parse(DateTime.Parse(ngaychungtu).Year.ToString()), Int32.Parse(DateTime.Parse(ngaychungtu).Month.ToString()), j);
                        dr[1] = temp.Rows[i][1];
                        dr[2] = temp.Rows[i][2];
                        dr[3] = temp.Rows[i][3];
                        dr[4] = temp.Rows[i][4];
                        dr[5] = temp.Rows[i][5];
                        dr[6] = temp.Rows[i][6];
                        dr[7] = temp.Rows[i][7];
                        dr[8] = temp.Rows[i][8];
                        dr[9] = temp.Rows[i][9];
                        dr[10] = temp.Rows[i][10];
                        dr[11] = temp.Rows[i][11];
                        dr[12] = temp.Rows[i][12];
                        dr[13] = temp.Rows[i][13];
                        dr[14] = temp.Rows[i][14];
                        dr[15] = temp.Rows[i][15];
                        dr[16] = temp.Rows[i][16];
                        dt.Rows.Add(dr);
                        check = "1";
                    }
                }
                if (check == "0")
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = gen.NgayTrongTuan(Int32.Parse(DateTime.Parse(ngaychungtu).Year.ToString()), Int32.Parse(DateTime.Parse(ngaychungtu).Month.ToString()),j);
                    dr[1] = DateTime.Parse(ngaychungtu).Month.ToString() + "/" + j.ToString() +"/"+ DateTime.Parse(ngaychungtu).Year.ToString();
                    dt.Rows.Add(dr);
                }
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
            XRSummary summarytotal12 = new XRSummary();
            XRSummary summarytotal13 = new XRSummary();
            XRSummary summarytotal14 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "Tiền mặt U55", "{0:n0}");
            xrTableCell43.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell44.DataBindings.Add("Text", DataSource, "Ngân hàng U55", "{0:n0}");
            xrTableCell44.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell45.DataBindings.Add("Text", DataSource, "Tiền mặt U166", "{0:n0}");
            xrTableCell45.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "Ngân hàng U166", "{0:n0}");
            xrTableCell46.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "Tiền mặt Gau166", "{0:n0}");
            xrTableCell47.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "Ngân hàng Gau166", "{0:n0}");
            xrTableCell48.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell49.DataBindings.Add("Text", DataSource, "Tiền mặt Mar166", "{0:n0}");
            xrTableCell49.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell50.DataBindings.Add("Text", DataSource, "Ngân hàng Mar166", "{0:n0}");
            xrTableCell50.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell51.DataBindings.Add("Text", DataSource, "Tiền mặt UTN", "{0:n0}");
            xrTableCell51.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Report;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell52.DataBindings.Add("Text", DataSource, "Ngân hàng UTN", "{0:n0}");
            xrTableCell52.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell53.DataBindings.Add("Text", DataSource, "Tổng thu", "{0:n0}");
            xrTableCell53.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell54.DataBindings.Add("Text", DataSource, "Tổng chi", "{0:n0}");
            xrTableCell54.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell55.DataBindings.Add("Text", DataSource, "Thanh toán", "{0:n0}");
            xrTableCell55.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell56.DataBindings.Add("Text", DataSource, "Thực nộp 166", "{0:n0}");
            xrTableCell56.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Report;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell57.DataBindings.Add("Text", DataSource, "Thực nộp TN", "{0:n0}");
            xrTableCell57.Summary = summarytotal15;

            xrTableCell21.DataBindings.Add("Text", DataSource, "Thứ");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd/MM/yyyy}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Tiền mặt U55", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Ngân hàng U55", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Tiền mặt U166", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Ngân hàng U166", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Tiền mặt Gau166", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Ngân hàng Gau166", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Tiền mặt Mar166", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Ngân hàng Mar166", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Tiền mặt UTN", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Ngân hàng UTN", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "Tổng thu", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "Tổng chi", "{0:n0}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "Thanh toán", "{0:n0}");
            xrTableCell39.DataBindings.Add("Text", DataSource, "Thực nộp 166", "{0:n0}");
            xrTableCell40.DataBindings.Add("Text", DataSource, "Thực nộp TN", "{0:n0}");
        }
    }
}
