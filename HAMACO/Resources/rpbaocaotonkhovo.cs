using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace HAMACO.Resources
{
    public partial class rpbaocaotonkhovo : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaotonkhovo()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string kho, string userid, string ngaychungtu, string tsbt)
        {
            string tenkho = "", tinh = "Cần Thơ", TDV = null, TK = null;
            if (tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctkvlpgtndn" || tsbt == "tsbtbctkbcnvotndn")
            {
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
                tinh = gen.GetString("select ProvinceName from Stock a, Province b where a.Province=b.ProvinceCode and StockID='" + kho + "'");
                TDV = gen.GetString("select TDV from Stock a, Province b where a.Province=b.ProvinceCode and StockID='" + kho + "'");
                TK = gen.GetString("select TK from Stock a, Province b where a.Province=b.ProvinceCode and StockID='" + kho + "'");
            }
            else if (tsbt == "tsbtbctkvlpgtttdv" || tsbt == "tsbtbctkvlpgtndntdv" || tsbt == "tsbtbctkbcnvo")
            {
                tenkho = gen.GetString("select BranchName from Branch where BranchID='" + kho + "'");
                string makho = gen.GetString("select BranchCode from Branch where BranchID='" + kho + "'");
                tenkho = ("ĐƠN VỊ " + makho + " - " + tenkho).ToUpper();
                tinh = gen.GetString("select ProvinceName from Branch a, Province b where a.Province=b.ProvinceCode and BranchID='" + kho + "'");
                TDV = gen.GetString("select TDV from Branch a, Province b where a.Province=b.ProvinceCode and BranchID='" + kho + "'");
                TK = gen.GetString("select TK from Branch a, Province b where a.Province=b.ProvinceCode and BranchID='" + kho + "'");
            }
            userid = gen.GetString("select FullName from MSC_User where UserID='" + userid + "'");

            try
            {
                xrLabel7.Text = tinh + ", ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            }
            catch
            {
                xrLabel7.Text = tinh + ", ngày " + ngaychungtu.Substring(0, 2) + " tháng " + ngaychungtu.Substring(3, 2) + " năm " + ngaychungtu.Substring(6, 4);
            }
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = a;
            xrLabel5.Text = tenkho;
            char[] charArr = a.ToLower().ToCharArray();
            charArr[0] = Char.ToUpper(charArr[0]);
            xrLabel6.Text = new String(charArr);
            if (tenkho != "")
            {
                xrLabel6.Text = xrLabel6.Text + " - " + tenkho;
            }
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrTableCell73.Text = userid;
            xrTableCell74.Text = TK;
            xrTableCell75.Text = TDV;
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
            XRSummary summarytotal15 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell70.DataBindings.Add("Text", DataSource, "Số tiền TCK", "{0:n0}");
            xrTableCell70.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell69.DataBindings.Add("Text", DataSource, "Số lượng TCK", "{0:n0}");
            xrTableCell69.Summary = summarytotal1;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell67.DataBindings.Add("Text", DataSource, "Số tiền XTK", "{0:n0}");
            xrTableCell67.Summary = summarytotal4;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell65.DataBindings.Add("Text", DataSource, "Số lượng XTK", "{0:n0}");
            xrTableCell65.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell64.DataBindings.Add("Text", DataSource, "Số tiền XCK", "{0:n0}");
            xrTableCell64.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell63.DataBindings.Add("Text", DataSource, "Số lượng XCK", "{0:n0}");
            xrTableCell63.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell62.DataBindings.Add("Text", DataSource, "Số tiền NCK", "{0:n0}");
            xrTableCell62.Summary = summarytotal9;



            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell61.DataBindings.Add("Text", DataSource, "Số lượng NCK", "{0:n0}");
            xrTableCell61.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell60.DataBindings.Add("Text", DataSource, "Số tiền NTK", "{0:n0}");
            xrTableCell60.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell59.DataBindings.Add("Text", DataSource, "Số lượng NTK", "{0:n0}");
            xrTableCell59.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell58.DataBindings.Add("Text", DataSource, "Số tiền ĐK", "{0:n0}");
            xrTableCell58.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Report;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell57.DataBindings.Add("Text", DataSource, "Số lượng ĐK", "{0:n0}");
            xrTableCell57.Summary = summarytotal15;

            summarytotal10.Running = SummaryRunning.Report;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell55.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell55.Summary = summarytotal10;

            tenhang.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell52.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "Số lượng ĐK", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Số tiền ĐK", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Số lượng NTK", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Số tiền NTK", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Số lượng NCK", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Số tiền NCK", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Số lượng XCK", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Số tiền XCK", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Số lượng XTK", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "Số tiền XTK", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "Số lượng TCK", "{0:n0}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "Số tiền TCK", "{0:n0}");

        }

    }
}
