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
    public partial class rpbangkeluongsanluong : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbangkeluongsanluong()
        {
            InitializeComponent();
        }
        public void gettieude(string ngaythang, string kho, string nhanvien)
        {
            xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel2.Text = "BẢNG KÊ LƯƠNG SẢN LƯỢNG THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaythang)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaythang));
            xrLabel3.Text = "Nhân viên: " + gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='" + nhanvien + "'");
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel4.Text = "Bảng kê lương sản lượng tháng " + String.Format("{0:MM}", DateTime.Parse(ngaythang)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaythang)) + " - " + gen.GetString("select AccountingObjectName+'('+AccountingObjectCode+')' from AccountingObject where AccountingObjectID='" + nhanvien + "'");
            
            DataTable temp = gen.GetTable("select HP,VKS,VAS,CN,TKhac,NS,Fico,XMKhac,Sand,Stone,Bricks from SalaryDG where MONTH('" + ngaythang + "')=MONTH(DateLine) and YEAR('" + ngaythang + "')=YEAR(DateLine) and EmployeeID='" + nhanvien + "' and General=0");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count; j++)
                {

                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        xrTable9.Rows[i].Cells[j + 1].Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable9.Rows[i].Cells[j + 1].Text = "";
                }
            }
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

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "HP", "{0:n0}");
            xrTableCell27.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "VKS", "{0:n0}");
            xrTableCell28.Summary = summarytotal1;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell74.DataBindings.Add("Text", DataSource, "VAS", "{0:n0}");
            xrTableCell74.Summary = summarytotal14;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "CN", "{0:n0}");
            xrTableCell29.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell67.DataBindings.Add("Text", DataSource, "Tkhac", "{0:n0}");
            xrTableCell67.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell68.DataBindings.Add("Text", DataSource, "NS", "{0:n0}");
            xrTableCell68.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell69.DataBindings.Add("Text", DataSource, "Fico", "{0:n0}");
            xrTableCell69.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell81.DataBindings.Add("Text", DataSource, "XMkhac", "{0:n0}");
            xrTableCell81.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell82.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell82.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell83.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell83.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Report;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell84.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell84.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell85.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell85.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell86.DataBindings.Add("Text", DataSource, "Lãi", "{0:n0}");
            xrTableCell86.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell87.DataBindings.Add("Text", DataSource, "Thu nhập", "{0:n0}");
            xrTableCell87.Summary = summarytotal13;


            xrTableCell10.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell17.DataBindings.Add("Text", DataSource, "HP", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "VKS", "{0:n0}");
            xrTableCell73.DataBindings.Add("Text", DataSource, "VAS", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "CN", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Tkhac", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "NS", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Fico", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "XMkhac", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell54.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell65.DataBindings.Add("Text", DataSource, "Lãi", "{0:n0}");
            xrTableCell66.DataBindings.Add("Text", DataSource, "Thu nhập", "{0:n0}");
        }
    }
}
