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
    public partial class rpbangkexuatnhapvo : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkexuatnhapvo()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string kho, string phieu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            if (phieu == "bkhdbvt")
            {
                xrLabel2.Text = "BẢNG KÊ XUẤT VỎ LPG";
                xrTableCell50.Text = "Nợ 1313";
                xrTableCell52.Text = "Nợ 3313";
            }
            else if (phieu == "bknckvlpg")
                xrLabel2.Text = "BẢNG KÊ NHẬP CHUYỂN VỎ LPG";
            else if (phieu == "bkxckvlpg")
                xrLabel2.Text = "BẢNG KÊ XUẤT CHUYỂN VỎ LPG";
            else if (phieu == "snkxktx")
                xrLabel2.Text = "SỔ NHẬT KÝ XUẤT KHO";

            xrLabel3.Text = xrLabel6.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel5.Text = "Từ ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;


            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            xrTableCell6.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tên khách");

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
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "1313", "{0:n0}");
            xrTableCell3.Summary = summarytotal10;

            summarytotal12.Running = SummaryRunning.Group;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "3313", "{0:n0}");
            xrTableCell32.Summary = summarytotal12;





            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell28.Summary = summarytotal;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "1313", "{0:n0}");
            xrTableCell30.Summary = summarytotal5;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "3313", "{0:n0}");
            xrTableCell33.Summary = summarytotal3;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell43.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "1313", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "3313", "{0:n0}");
        }
    }
}
