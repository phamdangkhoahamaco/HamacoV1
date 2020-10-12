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
    public partial class rpbaocaotonkho : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbaocaotonkho()
        {
            InitializeComponent();
        }
       
        public void gettieude(string a,string kho,string userid,string ngaychungtu,string tsbt,string an)
        {            
            string tenkho = "", tinh = "Cần Thơ",TDV=null,TK=null;
            if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctkthdtndn")
            {
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
                tinh = gen.GetString("select ProvinceName from Stock a, Province b where a.Province=b.ProvinceCode and StockID='" + kho + "'");
                TDV = gen.GetString("select TDV from Stock a, Province b where a.Province=b.ProvinceCode and StockID='" + kho + "'");
                TK = gen.GetString("select TK from Stock a, Province b where a.Province=b.ProvinceCode and StockID='" + kho + "'");
            }
            else if (tsbt == "tsbtbctktttdv" || tsbt == "tsbtbctktndntdv")
            {
                tenkho = gen.GetString("select BranchName from Branch where BranchID='" + kho + "'");
                string makho = gen.GetString("select BranchCode from Branch where BranchID='" + kho + "'");
                tenkho = ("ĐƠN VỊ " + makho + " - " + tenkho).ToUpper();
                tinh = gen.GetString("select ProvinceName from Branch a, Province b where a.Province=b.ProvinceCode and BranchID='" + kho + "'");
                TDV = gen.GetString("select TDV from Branch a, Province b where a.Province=b.ProvinceCode and BranchID='" + kho + "'");
                TK = gen.GetString("select TK from Branch a, Province b where a.Province=b.ProvinceCode and BranchID='" + kho + "'");
            }
            try
            {
                userid = gen.GetString("select FullName from MSC_User where UserID='" + userid + "'");
            }
            catch { }
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
           
            try
            {
                if (ngaychungtu.Length > 10)
                {
                    xrLabel7.Text = tinh + ", ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
                    if (DateTime.Parse(ngaychungtu) < DateTime.Parse("07/01/2017"))
                        xrTableCell13.Text = "Trị giá bán";
                }
                else
                {
                    xrLabel7.Text = tinh + ", ngày " + ngaychungtu.Substring(0, 2) + " tháng " + ngaychungtu.Substring(3, 2) + " năm " + ngaychungtu.Substring(6, 4);
                    if (DateTime.Parse(ngaychungtu.Substring(3, 2) + "/" + ngaychungtu.Substring(0, 2) + "/" + ngaychungtu.Substring(6, 4)) < DateTime.Parse("07/01/2017"))
                        xrTableCell13.Text = "Trị giá bán";
                }
            }
            catch
            {
                xrLabel7.Text = tinh + ", ngày " + ngaychungtu.Substring(0, 2) + " tháng " + ngaychungtu.Substring(3, 2) + " năm " +  ngaychungtu.Substring(6,4);
                if (DateTime.Parse(ngaychungtu.Substring(3, 2) + "/" + ngaychungtu.Substring(0, 2) + "/" + ngaychungtu.Substring(6, 4)) < DateTime.Parse("07/01/2017"))
                    xrTableCell13.Text = "Trị giá bán";
            }
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
            if (an == "an")
                Detail.Visible = false;
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("nhom");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell39.DataBindings.Add("Text", DataSource, "nhomhang");

            xrTableCell40.DataBindings.Add("Text", DataSource, "dongia", "{0:n2}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n2}";
            xrTableCell40.Summary = summary;

            xrTableCell41.DataBindings.Add("Text", DataSource, "tondau", "{0:n2}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n2}";
            xrTableCell41.Summary = summary1;

            xrTableCell42.DataBindings.Add("Text", DataSource, "tientondau", "{0:n0}");
            XRSummary summary2 = new XRSummary();
            summary2.Running = SummaryRunning.Group;
            summary2.IgnoreNullValues = true;
            summary2.FormatString = "{0:n0}";
            xrTableCell42.Summary = summary2;

            xrTableCell43.DataBindings.Add("Text", DataSource, "nhapdau", "{0:n2}");
            XRSummary summary3 = new XRSummary();
            summary3.Running = SummaryRunning.Group;
            summary3.IgnoreNullValues = true;
            summary3.FormatString = "{0:n2}";
            xrTableCell43.Summary = summary3;

            xrTableCell44.DataBindings.Add("Text", DataSource, "tiennhapdau", "{0:n0}");
            XRSummary summary4 = new XRSummary();
            summary4.Running = SummaryRunning.Group;
            summary4.IgnoreNullValues = true;
            summary4.FormatString = "{0:n0}";
            xrTableCell44.Summary = summary4;

            xrTableCell45.DataBindings.Add("Text", DataSource, "nhapchuyen", "{0:n2}");
            XRSummary summary5 = new XRSummary();
            summary5.Running = SummaryRunning.Group;
            summary5.IgnoreNullValues = true;
            summary5.FormatString = "{0:n2}";
            xrTableCell45.Summary = summary5;

            xrTableCell46.DataBindings.Add("Text", DataSource, "tiennhapchuyen", "{0:n0}");
            XRSummary summary6 = new XRSummary();
            summary6.Running = SummaryRunning.Group;
            summary6.IgnoreNullValues = true;
            summary6.FormatString = "{0:n0}";
            xrTableCell46.Summary = summary6;

            xrTableCell47.DataBindings.Add("Text", DataSource, "xuatchuyen", "{0:n2}");
            XRSummary summary7 = new XRSummary();
            summary7.Running = SummaryRunning.Group;
            summary7.IgnoreNullValues = true;
            summary7.FormatString = "{0:n2}";
            xrTableCell47.Summary = summary7;

            xrTableCell48.DataBindings.Add("Text", DataSource, "tienxuatchuyen", "{0:n0}");
            XRSummary summary8 = new XRSummary();
            summary8.Running = SummaryRunning.Group;
            summary8.IgnoreNullValues = true;
            summary8.FormatString = "{0:n0}";
            xrTableCell48.Summary = summary8;

            xrTableCell49.DataBindings.Add("Text", DataSource, "xuatban", "{0:n2}");
            XRSummary summary9 = new XRSummary();
            summary9.Running = SummaryRunning.Group;
            summary9.IgnoreNullValues = true;
            summary9.FormatString = "{0:n2}";
            xrTableCell49.Summary = summary9;

            xrTableCell50.DataBindings.Add("Text", DataSource, "trigiaton", "{0:n0}");
            XRSummary summary10 = new XRSummary();
            summary10.Running = SummaryRunning.Group;
            summary10.IgnoreNullValues = true;
            summary10.FormatString = "{0:n0}";
            xrTableCell50.Summary = summary10;

            xrTableCell51.DataBindings.Add("Text", DataSource, "tienxuatban", "{0:n0}");
            XRSummary summary11 = new XRSummary();
            summary11.Running = SummaryRunning.Group;
            summary11.IgnoreNullValues = true;
            summary11.FormatString = "{0:n0}";
            xrTableCell51.Summary = summary11;

            xrTableCell52.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            XRSummary summary12 = new XRSummary();
            summary12.Running = SummaryRunning.Group;
            summary12.IgnoreNullValues = true;
            summary12.FormatString = "{0:n0}";
            xrTableCell52.Summary = summary12;

            xrTableCell53.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n2}");
            XRSummary summary13 = new XRSummary();
            summary13.Running = SummaryRunning.Group;
            summary13.IgnoreNullValues = true;
            summary13.FormatString = "{0:n2}";
            xrTableCell53.Summary = summary13;

            xrTableCell23.DataBindings.Add("Text", DataSource, "tttoncuoi", "{0:n0}");
            XRSummary summary14 = new XRSummary();
            summary14.Running = SummaryRunning.Group;
            summary14.IgnoreNullValues = true;
            summary14.FormatString = "{0:n0}";
            xrTableCell23.Summary = summary14;




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
            xrTableCell70.DataBindings.Add("Text", DataSource, "tttoncuoi", "{0:n0}");
            xrTableCell70.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell69.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n2}");
            xrTableCell69.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell68.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            xrTableCell68.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell67.DataBindings.Add("Text", DataSource, "tienxuatban", "{0:n0}");
            xrTableCell67.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell66.DataBindings.Add("Text", DataSource, "trigiaton", "{0:n0}");
            xrTableCell66.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n2}";
            xrTableCell65.DataBindings.Add("Text", DataSource, "xuatban", "{0:n2}");
            xrTableCell65.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell64.DataBindings.Add("Text", DataSource, "tienxuatchuyen", "{0:n0}");
            xrTableCell64.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n2}";
            xrTableCell63.DataBindings.Add("Text", DataSource, "xuatchuyen", "{0:n2}");
            xrTableCell63.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell62.DataBindings.Add("Text", DataSource, "tiennhapchuyen", "{0:n0}");
            xrTableCell62.Summary = summarytotal9;

            

            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n2}";
            xrTableCell61.DataBindings.Add("Text", DataSource, "nhapchuyen", "{0:n2}");
            xrTableCell61.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell60.DataBindings.Add("Text", DataSource, "tiennhapdau", "{0:n0}");
            xrTableCell60.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n2}";
            xrTableCell59.DataBindings.Add("Text", DataSource, "nhapdau", "{0:n2}");
            xrTableCell59.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell58.DataBindings.Add("Text", DataSource, "tientondau", "{0:n0}");
            xrTableCell58.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Report;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n2}";
            xrTableCell57.DataBindings.Add("Text", DataSource, "tondau", "{0:n0}");
            xrTableCell57.Summary = summarytotal15;

            summarytotal10.Running = SummaryRunning.Report;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n2}";
            xrTableCell56.DataBindings.Add("Text", DataSource, "dongia", "{0:n2}");
            xrTableCell56.Summary = summarytotal10;         

            tenhang.DataBindings.Add("Text", DataSource, "tenhang");
            xrTableCell24.DataBindings.Add("Text", DataSource, "dongia",  "{0:n2}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "tondau",  "{0:n2}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "tientondau",  "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "nhapdau",  "{0:n2}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "tiennhapdau",  "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "nhapchuyen",  "{0:n2}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "tiennhapchuyen",  "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "xuatchuyen",  "{0:n2}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "tienxuatchuyen", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "xuatban", "{0:n2}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "trigiaton", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "tienxuatban", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n2}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "tttoncuoi", "{0:n0}");

        }

    }
}
