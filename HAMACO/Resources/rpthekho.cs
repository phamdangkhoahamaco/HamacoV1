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
    public partial class rpthekho : DevExpress.XtraReports.UI.XtraReport
    {
        public rpthekho()
        {
            InitializeComponent();
        }
        string thang,nam,userid;
        gencon gen = new gencon();

        DataTable hang = new DataTable();
        DataTable khach = new DataTable();
        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }
        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }

        public void gettieude(string ngaychungtu, string mahang, string kho,string congty,string user)        
        {
            userid = user;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            thang = String.Format("{0:MM}",DateTime.Parse(ngaychungtu));
            nam = String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            DataTable temp = new DataTable();
            try
            {
                temp = gen.GetTable("select StockCode,StockName from Stock where StockID='" + kho + "'");
                xrLabel3.Text = temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString();
            }
            catch 
            {
                temp = gen.GetTable("select BranchCode,BranchName from Branch where BranchID='" + kho + "'");
                xrLabel3.Text = temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString();
            }
            
            xrLabel2.Text = "THẺ KHO HÀNG HÓA THÁNG "+thang+" NĂM "+nam;
            temp = gen.GetTable("select InventoryItemCode,InventoryItemName from InventoryItem where InventoryItemID='" + mahang + "'");
            xrLabel5.Text = "MẶT HÀNG: "+temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString().ToUpper();
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
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

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell38.DataBindings.Add("Text", DataSource, "sltondau", "{0:n0}");
            xrTableCell38.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "slqdtondau", "{0:n2}");
            xrTableCell39.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "tientondau", "{0:n0}");
            xrTableCell40.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell41.DataBindings.Add("Text", DataSource, "slnhap", "{0:n0}");
            xrTableCell41.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n2}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "slqdnhap", "{0:n2}");
            xrTableCell42.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell43.DataBindings.Add("Text", DataSource, "sotiennhap", "{0:n0}");
            xrTableCell43.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell44.DataBindings.Add("Text", DataSource, "slxuat", "{0:n0}");
            xrTableCell44.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n2}";
            xrTableCell45.DataBindings.Add("Text", DataSource, "slqdxuat", "{0:n2}");
            xrTableCell45.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "sotienxuat", "{0:n0}");
            xrTableCell46.Summary = summarytotal9;



            summarytotal11.Running = SummaryRunning.None;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell47.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n0}");
            xrTableCell47.Summary = summarytotal11;

            summarytotal10.Running = SummaryRunning.None;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n2}";
            xrTableCell48.DataBindings.Add("Text", DataSource, "slqdtoncuoi", "{0:n2}");
            xrTableCell48.Summary = summarytotal10;

            summarytotal13.Running = SummaryRunning.None;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell49.DataBindings.Add("Text", DataSource, "sotientoncuoi", "{0:n0}");
            xrTableCell49.Summary = summarytotal13;


            xrTableCell20.DataBindings.Add("Text", DataSource, "ngay","{0:dd-MM-yy}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "sophieu");
            xrTableCell22.DataBindings.Add("Text", DataSource, "tenkhach");
            xrTableCell23.DataBindings.Add("Text", DataSource, "sltondau", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "slqdtondau", "{0:n2}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "tientondau", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "slnhap", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "slqdnhap", "{0:n2}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "sotiennhap", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "slxuat", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "slqdxuat", "{0:n2}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "sotienxuat", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "sltoncuoi", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "slqdtoncuoi", "{0:n2}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "sotientoncuoi", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "hoadon");
        }


        private void xrTableCell21_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            search search = new search();
            search.gethang(hang);
            search.getkhach(khach);
            search.searchform(e.Brick.Text, thang, nam,userid);
        }

    }
}
