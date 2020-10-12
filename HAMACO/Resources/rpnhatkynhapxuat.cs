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
    public partial class rpnhatkynhapxuat : DevExpress.XtraReports.UI.XtraReport
    {
        public rpnhatkynhapxuat()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string kho,string phieu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = phieu;
            try
            {
                xrLabel3.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            }
            catch { xrLabel3.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'").ToUpper(); }
            xrLabel5.Text = "Từ ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

           
            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            Bands.Add(GroupHeader2);
            GroupField groupField = new GroupField("Ngày lập");
            GroupHeader2.GroupFields.Add(groupField);

            xrTableCell14.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Phương tiện");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Nơi giao");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");

            XRSummary summarytotal = new XRSummary();
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


            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell2.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell2.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n2}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell3.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Group;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell5.DataBindings.Add("Text", DataSource, "Chưa thuế", "{0:n0}");
            xrTableCell5.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Group;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell7.Summary = summarytotal12;





            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell27.Summary = summarytotal;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n2}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell28.Summary = summarytotal5;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell33.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Chưa thuế", "{0:n0}");
            xrTableCell30.Summary = summarytotal4;



            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell35.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell36.Summary = summarytotal2;

            summarytotal7.Running = SummaryRunning.Group;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "Chưa thuế", "{0:n0}");
            xrTableCell40.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell42.Summary = summarytotal8;


            xrTableCell43.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đơn vị tính");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Chưa thuế", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Ghi chú");
        }
    }
}
