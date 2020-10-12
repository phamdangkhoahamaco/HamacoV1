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
    public partial class rpbaocaotonkhobcn : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbaocaotonkhobcn()
        {
            InitializeComponent();
        }
        public void gettieude(string kho, string userid, string ngaychungtu, string tungay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'").ToUpper();
            xrLabel2.Text = "BÁO CÁO TỒN KHO TỪ NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
            xrLabel6.Text = "Báo cáo tồn kho từ ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + " - " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'");
        }
        public void gettieudehangtieudung(string kho, string ngaychungtu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            try
            {
                xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
                xrLabel6.Text = "Báo cáo tồn kho tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + " - " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'");
            }
            catch
            {
                xrLabel5.Text = "THEO NGÀNH HÀNG";
                xrLabel6.Text = "Báo cáo tồn kho theo ngành hàng tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            }
            xrLabel2.Text = "BÁO CÁO TỒN KHO THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

           
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("nhom");
            GroupHeader1.GroupFields.Add(groupField);

            Bands.Add(GroupHeader2);
            GroupField groupField1 = new GroupField("Công ty");
            GroupHeader2.GroupFields.Add(groupField1);

            xrTableCell92.DataBindings.Add("Text", DataSource, "Công ty");
            xrTableCell39.DataBindings.Add("Text", DataSource, "nhomhang");



            xrTableCell91.DataBindings.Add("Text", DataSource, "sodau", "{0:n0}");
            XRSummary summary34 = new XRSummary();
            summary34.Running = SummaryRunning.Group;
            summary34.IgnoreNullValues = true;
            summary34.FormatString = "{0:n0}";
            xrTableCell91.Summary = summary34;

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


            xrTableCell90.DataBindings.Add("Text", DataSource, "sonhap", "{0:n0}");
            XRSummary summary33 = new XRSummary();
            summary33.Running = SummaryRunning.Group;
            summary33.IgnoreNullValues = true;
            summary33.FormatString = "{0:n0}";
            xrTableCell90.Summary = summary33;


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

            xrTableCell89.DataBindings.Add("Text", DataSource, "sonhapchuyen", "{0:n0}");
            XRSummary summary32 = new XRSummary();
            summary32.Running = SummaryRunning.Group;
            summary32.IgnoreNullValues = true;
            summary32.FormatString = "{0:n0}";
            xrTableCell89.Summary = summary32;

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

            xrTableCell88.DataBindings.Add("Text", DataSource, "soxuatchuyen", "{0:n0}");
            XRSummary summary31 = new XRSummary();
            summary31.Running = SummaryRunning.Group;
            summary31.IgnoreNullValues = true;
            summary31.FormatString = "{0:n0}";
            xrTableCell88.Summary = summary31;


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

            xrTableCell87.DataBindings.Add("Text", DataSource, "soxuatban", "{0:n0}");
            XRSummary summary30 = new XRSummary();
            summary30.Running = SummaryRunning.Group;
            summary30.IgnoreNullValues = true;
            summary30.FormatString = "{0:n0}";
            xrTableCell87.Summary = summary30;

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


            xrTableCell52.DataBindings.Add("Text", DataSource, "Lãi gộp", "{0:n0}");
            XRSummary summary100 = new XRSummary();
            summary100.Running = SummaryRunning.Group;
            summary100.IgnoreNullValues = true;
            summary100.FormatString = "{0:n0}";
            xrTableCell52.Summary = summary100;

            xrTableCell114.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            XRSummary summary12 = new XRSummary();
            summary12.Running = SummaryRunning.Group;
            summary12.IgnoreNullValues = true;
            summary12.FormatString = "{0:n0}";
            xrTableCell114.Summary = summary12;




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









            xrTableCell94.DataBindings.Add("Text", DataSource, "sodau", "{0:n0}");
            XRSummary summary44 = new XRSummary();
            summary44.Running = SummaryRunning.Group;
            summary44.IgnoreNullValues = true;
            summary44.FormatString = "{0:n0}";
            xrTableCell94.Summary = summary44;

            xrTableCell95.DataBindings.Add("Text", DataSource, "tondau", "{0:n2}");
            XRSummary summary45 = new XRSummary();
            summary45.Running = SummaryRunning.Group;
            summary45.IgnoreNullValues = true;
            summary45.FormatString = "{0:n2}";
            xrTableCell95.Summary = summary45;

            xrTableCell96.DataBindings.Add("Text", DataSource, "tientondau", "{0:n0}");
            XRSummary summary46 = new XRSummary();
            summary46.Running = SummaryRunning.Group;
            summary46.IgnoreNullValues = true;
            summary46.FormatString = "{0:n0}";
            xrTableCell96.Summary = summary46;


            xrTableCell97.DataBindings.Add("Text", DataSource, "sonhap", "{0:n0}");
            XRSummary summary47 = new XRSummary();
            summary47.Running = SummaryRunning.Group;
            summary47.IgnoreNullValues = true;
            summary47.FormatString = "{0:n0}";
            xrTableCell97.Summary = summary47;


            xrTableCell98.DataBindings.Add("Text", DataSource, "nhapdau", "{0:n2}");
            XRSummary summary48 = new XRSummary();
            summary48.Running = SummaryRunning.Group;
            summary48.IgnoreNullValues = true;
            summary48.FormatString = "{0:n2}";
            xrTableCell98.Summary = summary48;

            xrTableCell99.DataBindings.Add("Text", DataSource, "tiennhapdau", "{0:n0}");
            XRSummary summary49 = new XRSummary();
            summary49.Running = SummaryRunning.Group;
            summary49.IgnoreNullValues = true;
            summary49.FormatString = "{0:n0}";
            xrTableCell99.Summary = summary49;

            xrTableCell100.DataBindings.Add("Text", DataSource, "sonhapchuyen", "{0:n0}");
            XRSummary summary50 = new XRSummary();
            summary50.Running = SummaryRunning.Group;
            summary50.IgnoreNullValues = true;
            summary50.FormatString = "{0:n0}";
            xrTableCell100.Summary = summary50;

            xrTableCell101.DataBindings.Add("Text", DataSource, "nhapchuyen", "{0:n2}");
            XRSummary summary51 = new XRSummary();
            summary51.Running = SummaryRunning.Group;
            summary51.IgnoreNullValues = true;
            summary51.FormatString = "{0:n2}";
            xrTableCell101.Summary = summary51;

            xrTableCell102.DataBindings.Add("Text", DataSource, "tiennhapchuyen", "{0:n0}");
            XRSummary summary52 = new XRSummary();
            summary52.Running = SummaryRunning.Group;
            summary52.IgnoreNullValues = true;
            summary52.FormatString = "{0:n0}";
            xrTableCell102.Summary = summary52;

            xrTableCell103.DataBindings.Add("Text", DataSource, "soxuatchuyen", "{0:n0}");
            XRSummary summary53 = new XRSummary();
            summary53.Running = SummaryRunning.Group;
            summary53.IgnoreNullValues = true;
            summary53.FormatString = "{0:n0}";
            xrTableCell103.Summary = summary53;


            xrTableCell104.DataBindings.Add("Text", DataSource, "xuatchuyen", "{0:n2}");
            XRSummary summary54 = new XRSummary();
            summary54.Running = SummaryRunning.Group;
            summary54.IgnoreNullValues = true;
            summary54.FormatString = "{0:n2}";
            xrTableCell104.Summary = summary54;

            xrTableCell105.DataBindings.Add("Text", DataSource, "tienxuatchuyen", "{0:n0}");
            XRSummary summary55 = new XRSummary();
            summary55.Running = SummaryRunning.Group;
            summary55.IgnoreNullValues = true;
            summary55.FormatString = "{0:n0}";
            xrTableCell105.Summary = summary55;

            xrTableCell106.DataBindings.Add("Text", DataSource, "soxuatban", "{0:n0}");
            XRSummary summary56 = new XRSummary();
            summary56.Running = SummaryRunning.Group;
            summary56.IgnoreNullValues = true;
            summary56.FormatString = "{0:n0}";
            xrTableCell106.Summary = summary56;

            xrTableCell107.DataBindings.Add("Text", DataSource, "xuatban", "{0:n2}");
            XRSummary summary57 = new XRSummary();
            summary57.Running = SummaryRunning.Group;
            summary57.IgnoreNullValues = true;
            summary57.FormatString = "{0:n2}";
            xrTableCell107.Summary = summary57;

            xrTableCell108.DataBindings.Add("Text", DataSource, "trigiaton", "{0:n0}");
            XRSummary summary58 = new XRSummary();
            summary58.Running = SummaryRunning.Group;
            summary58.IgnoreNullValues = true;
            summary58.FormatString = "{0:n0}";
            xrTableCell108.Summary = summary58;

            xrTableCell109.DataBindings.Add("Text", DataSource, "tienxuatban", "{0:n0}");
            XRSummary summary59 = new XRSummary();
            summary59.Running = SummaryRunning.Group;
            summary59.IgnoreNullValues = true;
            summary59.FormatString = "{0:n0}";
            xrTableCell109.Summary = summary59;

            xrTableCell110.DataBindings.Add("Text", DataSource, "Lãi gộp", "{0:n0}");
            XRSummary summary101 = new XRSummary();
            summary101.Running = SummaryRunning.Group;
            summary101.IgnoreNullValues = true;
            summary101.FormatString = "{0:n0}";
            xrTableCell110.Summary = summary101;

            xrTableCell115.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            XRSummary summary60 = new XRSummary();
            summary60.Running = SummaryRunning.Group;
            summary60.IgnoreNullValues = true;
            summary60.FormatString = "{0:n0}";
            xrTableCell115.Summary = summary60;

            xrTableCell111.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n2}");
            XRSummary summary61 = new XRSummary();
            summary61.Running = SummaryRunning.Group;
            summary61.IgnoreNullValues = true;
            summary61.FormatString = "{0:n2}";
            xrTableCell111.Summary = summary61;

            xrTableCell112.DataBindings.Add("Text", DataSource, "tttoncuoi", "{0:n0}");
            XRSummary summary62 = new XRSummary();
            summary62.Running = SummaryRunning.Group;
            summary62.IgnoreNullValues = true;
            summary62.FormatString = "{0:n0}";
            xrTableCell112.Summary = summary62;




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
            XRSummary summarytotal16 = new XRSummary();
            XRSummary summarytotal17 = new XRSummary();
            XRSummary summarytotal18 = new XRSummary();
            XRSummary summarytotal19 = new XRSummary();
            XRSummary summarytotal20 = new XRSummary();
            XRSummary summarytotal102 = new XRSummary();

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

            summarytotal102.Running = SummaryRunning.Report;
            summarytotal102.IgnoreNullValues = true;
            summarytotal102.FormatString = "{0:n0}";
            xrTableCell68.DataBindings.Add("Text", DataSource, "Lãi gộp", "{0:n0}");
            xrTableCell68.Summary = summarytotal102;


            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell116.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            xrTableCell116.Summary = summarytotal3;


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
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell79.DataBindings.Add("Text", DataSource, "soxuatban", "{0:n0}");
            xrTableCell79.Summary = summarytotal6;

            summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n2}";
            xrTableCell65.DataBindings.Add("Text", DataSource, "xuatban", "{0:n2}");
            xrTableCell65.Summary = summarytotal16;

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

            summarytotal17.Running = SummaryRunning.Report;
            summarytotal17.IgnoreNullValues = true;
            summarytotal17.FormatString = "{0:n0}";
            xrTableCell83.DataBindings.Add("Text", DataSource, "soxuatchuyen", "{0:n0}");
            xrTableCell83.Summary = summarytotal17;

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

            summarytotal18.Running = SummaryRunning.Report;
            summarytotal18.IgnoreNullValues = true;
            summarytotal18.FormatString = "{0:n0}";
            xrTableCell84.DataBindings.Add("Text", DataSource, "sonhapchuyen", "{0:n0}");
            xrTableCell84.Summary = summarytotal18;

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

            summarytotal19.Running = SummaryRunning.Report;
            summarytotal19.IgnoreNullValues = true;
            summarytotal19.FormatString = "{0:n0}";
            xrTableCell85.DataBindings.Add("Text", DataSource, "sonhap", "{0:n0}");
            xrTableCell85.Summary = summarytotal19;

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
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell86.DataBindings.Add("Text", DataSource, "sodau", "{0:n0}");
            xrTableCell86.Summary = summarytotal10;  





            xrTableCell71.DataBindings.Add("Text", DataSource, "Mã hàng");
            tenhang.DataBindings.Add("Text", DataSource, "tenhang");
            xrTableCell24.DataBindings.Add("Text", DataSource, "dongia", "{0:n2}");
            xrTableCell74.DataBindings.Add("Text", DataSource, "sodau", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "tondau", "{0:n2}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "tientondau", "{0:n0}");
            xrTableCell78.DataBindings.Add("Text", DataSource, "sonhap", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "nhapdau", "{0:n2}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "tiennhapdau", "{0:n0}");
            xrTableCell82.DataBindings.Add("Text", DataSource, "sonhapchuyen", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "nhapchuyen", "{0:n2}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "tiennhapchuyen", "{0:n0}");
            xrTableCell81.DataBindings.Add("Text", DataSource, "soxuatchuyen", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "xuatchuyen", "{0:n2}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "tienxuatchuyen", "{0:n0}");
            xrTableCell80.DataBindings.Add("Text", DataSource, "soxuatban", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "xuatban", "{0:n2}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "trigiaton", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "tienxuatban", "{0:n0}");
            xrTableCell113.DataBindings.Add("Text", DataSource, "slbb", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n2}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "tttoncuoi", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "Lãi gộp", "{0:n0}");
        }
    }
}
