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
    public partial class rpbaocaotonkhotonghop : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbaocaotonkhotonghop()
        {
            InitializeComponent();
        }
        public void gettieude(string kho, string userid, string ngaychungtu, string tungay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel2.Text = "BÁO CÁO TỒN KHO TỪ NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel6.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
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
            XRSummary summarytotal16 = new XRSummary();
            XRSummary summarytotal17 = new XRSummary();
            XRSummary summarytotal18 = new XRSummary();
            XRSummary summarytotal19 = new XRSummary();
            XRSummary summarytotal20 = new XRSummary();
            
            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "TỒN ĐẦU", "{0:n0}");
            xrTableCell39.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "VỎ RỔNG", "{0:n0}");
            xrTableCell40.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "TỔNG VỎ", "{0:n0}");
            xrTableCell42.Summary = summarytotal3;


            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "NHẬP HÀNG", "{0:n0}");
            xrTableCell43.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell45.DataBindings.Add("Text", DataSource, "NHẬP VỎ", "{0:n0}");
            xrTableCell45.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO", "{0:n0}");
            xrTableCell46.Summary = summarytotal6;

            summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell48.Summary = summarytotal16;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell49.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO", "{0:n0}");
            xrTableCell49.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell44.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell44.Summary = summarytotal8;

            summarytotal17.Running = SummaryRunning.Report;
            summarytotal17.IgnoreNullValues = true;
            summarytotal17.FormatString = "{0:n0}";
            xrTableCell50.DataBindings.Add("Text", DataSource, "XUẤT BÁN", "{0:n0}");
            xrTableCell50.Summary = summarytotal17;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "XUẤT VỎ", "{0:n0}");
            xrTableCell47.Summary = summarytotal9;



            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell51.DataBindings.Add("Text", DataSource, "TỒN KHO", "{0:n0}");
            xrTableCell51.Summary = summarytotal11;

            summarytotal18.Running = SummaryRunning.Report;
            summarytotal18.IgnoreNullValues = true;
            summarytotal18.FormatString = "{0:n0}";
            xrTableCell53.DataBindings.Add("Text", DataSource, "TỒN VỎ RỔNG", "{0:n0}");
            xrTableCell53.Summary = summarytotal18;

            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell52.DataBindings.Add("Text", DataSource, "TỔNG VỎ TỒN", "{0:n0}");
            xrTableCell52.Summary = summarytotal12;

           

            xrTableCell20.DataBindings.Add("Text", DataSource, "MÃ HÀNG");
            xrTableCell21.DataBindings.Add("Text", DataSource, "TÊN HÀNG");
            xrTableCell24.DataBindings.Add("Text", DataSource, "TỒN ĐẦU", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "VỎ RỔNG", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "TỔNG VỎ", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "NHẬP HÀNG", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "NHẬP VỎ", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "XUẤT BÁN", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "XUẤT VỎ", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "TỒN KHO", "{0:n0}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "TỒN VỎ RỔNG", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "TỔNG VỎ TỒN", "{0:n0}");
        }

        public void BindDataVO(DataTable da)
        {

            xrLabel2.Text = xrLabel2.Text.Replace("BÁO CÁO TỒN KHO", "BÁO CÁO TỒN KHO VỎ");

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
            XRSummary summarytotal16 = new XRSummary();
            XRSummary summarytotal17 = new XRSummary();
            XRSummary summarytotal18 = new XRSummary();
            XRSummary summarytotal19 = new XRSummary();
            XRSummary summarytotal20 = new XRSummary();

            /*summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "TỒN ĐẦU", "{0:n0}");
            xrTableCell39.Summary = summarytotal;*/

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "VỎ RỔNG", "{0:n0}");
            xrTableCell40.Summary = summarytotal1;

            /*summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "TỔNG VỎ", "{0:n0}");
            xrTableCell42.Summary = summarytotal3;*/


            /*summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "NHẬP HÀNG", "{0:n0}");
            xrTableCell43.Summary = summarytotal4;*/

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell45.DataBindings.Add("Text", DataSource, "NHẬP VỎ", "{0:n0}");
            xrTableCell45.Summary = summarytotal5;

            /*summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO", "{0:n0}");
            xrTableCell46.Summary = summarytotal6;*/

            summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell48.Summary = summarytotal16;

            /*summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell49.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO", "{0:n0}");
            xrTableCell49.Summary = summarytotal7;*/

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell44.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell44.Summary = summarytotal8;

            /*summarytotal17.Running = SummaryRunning.Report;
            summarytotal17.IgnoreNullValues = true;
            summarytotal17.FormatString = "{0:n0}";
            xrTableCell50.DataBindings.Add("Text", DataSource, "XUẤT BÁN", "{0:n0}");
            xrTableCell50.Summary = summarytotal17;*/

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "XUẤT VỎ", "{0:n0}");
            xrTableCell47.Summary = summarytotal9;



            /*summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell51.DataBindings.Add("Text", DataSource, "TỒN KHO", "{0:n0}");
            xrTableCell51.Summary = summarytotal11;*/

            summarytotal18.Running = SummaryRunning.Report;
            summarytotal18.IgnoreNullValues = true;
            summarytotal18.FormatString = "{0:n0}";
            xrTableCell53.DataBindings.Add("Text", DataSource, "TỒN VỎ RỔNG", "{0:n0}");
            xrTableCell53.Summary = summarytotal18;

            /*summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell52.DataBindings.Add("Text", DataSource, "TỔNG VỎ TỒN", "{0:n0}");
            xrTableCell52.Summary = summarytotal12;*/



            xrTableCell20.DataBindings.Add("Text", DataSource, "MÃ HÀNG");
            xrTableCell21.DataBindings.Add("Text", DataSource, "TÊN HÀNG");
            //xrTableCell24.DataBindings.Add("Text", DataSource, "TỒN ĐẦU", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "VỎ RỔNG", "{0:n0}");
            //xrTableCell28.DataBindings.Add("Text", DataSource, "TỔNG VỎ", "{0:n0}");
            //xrTableCell29.DataBindings.Add("Text", DataSource, "NHẬP HÀNG", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "NHẬP VỎ", "{0:n0}");
            //xrTableCell32.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO VỎ", "{0:n0}");
            //xrTableCell27.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO VỎ", "{0:n0}");
            //xrTableCell33.DataBindings.Add("Text", DataSource, "XUẤT BÁN", "{0:n0}");
            xrTableCell35.DataBindings.Add("Text", DataSource, "XUẤT VỎ", "{0:n0}");
            //xrTableCell37.DataBindings.Add("Text", DataSource, "TỒN KHO", "{0:n0}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "TỒN VỎ RỔNG", "{0:n0}");
            //xrTableCell41.DataBindings.Add("Text", DataSource, "TỔNG VỎ TỒN", "{0:n0}");
        }

        public void BindDataLPG(DataTable da)
        {
            xrLabel2.Text = xrLabel2.Text.Replace("BÁO CÁO TỒN KHO", "BÁO CÁO TỒN KHO LPG");
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
            XRSummary summarytotal16 = new XRSummary();
            XRSummary summarytotal17 = new XRSummary();
            XRSummary summarytotal18 = new XRSummary();
            XRSummary summarytotal19 = new XRSummary();
            XRSummary summarytotal20 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "TỒN ĐẦU", "{0:n0}");
            xrTableCell39.Summary = summarytotal;

            /*summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "VỎ RỔNG", "{0:n0}");
            xrTableCell40.Summary = summarytotal1;*/

            /*summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "TỔNG VỎ", "{0:n0}");
            xrTableCell42.Summary = summarytotal3;*/


            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "NHẬP HÀNG", "{0:n0}");
            xrTableCell43.Summary = summarytotal4;

            /*summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell45.DataBindings.Add("Text", DataSource, "NHẬP VỎ", "{0:n0}");
            xrTableCell45.Summary = summarytotal5;*/

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO", "{0:n0}");
            xrTableCell46.Summary = summarytotal6;

            /*summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell48.Summary = summarytotal16;*/

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell49.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO", "{0:n0}");
            xrTableCell49.Summary = summarytotal7;

            /*summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell44.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell44.Summary = summarytotal8;*/

            summarytotal17.Running = SummaryRunning.Report;
            summarytotal17.IgnoreNullValues = true;
            summarytotal17.FormatString = "{0:n0}";
            xrTableCell50.DataBindings.Add("Text", DataSource, "XUẤT BÁN", "{0:n0}");
            xrTableCell50.Summary = summarytotal17;

            /*summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "XUẤT VỎ", "{0:n0}");
            xrTableCell47.Summary = summarytotal9;*/



            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell51.DataBindings.Add("Text", DataSource, "TỒN KHO", "{0:n0}");
            xrTableCell51.Summary = summarytotal11;

            /*summarytotal18.Running = SummaryRunning.Report;
            summarytotal18.IgnoreNullValues = true;
            summarytotal18.FormatString = "{0:n0}";
            xrTableCell53.DataBindings.Add("Text", DataSource, "TỒN VỎ RỔNG", "{0:n0}");
            xrTableCell53.Summary = summarytotal18;*/

            /*summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell52.DataBindings.Add("Text", DataSource, "TỔNG VỎ TỒN", "{0:n0}");
            xrTableCell52.Summary = summarytotal12;*/



            xrTableCell20.DataBindings.Add("Text", DataSource, "MÃ HÀNG");
            xrTableCell21.DataBindings.Add("Text", DataSource, "TÊN HÀNG");
            xrTableCell24.DataBindings.Add("Text", DataSource, "TỒN ĐẦU", "{0:n0}");
            //xrTableCell25.DataBindings.Add("Text", DataSource, "VỎ RỔNG", "{0:n0}");
            //xrTableCell28.DataBindings.Add("Text", DataSource, "TỔNG VỎ", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "NHẬP HÀNG", "{0:n0}");
            //xrTableCell31.DataBindings.Add("Text", DataSource, "NHẬP VỎ", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO", "{0:n0}");
            //xrTableCell34.DataBindings.Add("Text", DataSource, "NHẬP CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO", "{0:n0}");
            //xrTableCell30.DataBindings.Add("Text", DataSource, "XUẤT CHUYỂN KHO VỎ", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "XUẤT BÁN", "{0:n0}");
            //xrTableCell35.DataBindings.Add("Text", DataSource, "XUẤT VỎ", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "TỒN KHO", "{0:n0}");
            //xrTableCell38.DataBindings.Add("Text", DataSource, "TỒN VỎ RỔNG", "{0:n0}");
            //xrTableCell41.DataBindings.Add("Text", DataSource, "TỔNG VỎ TỒN", "{0:n0}");
        }
    }
}
