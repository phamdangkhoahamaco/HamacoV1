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
    public partial class rpcongnothuctechitiet : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpcongnothuctechitiet()
        {
            InitializeComponent();
        }
        public void gettieude(string tungay, string denngay, string kho, string makhach,string duno,string cuoiky)
        {
            try
            {
                if (Double.Parse(duno) != 0)
                    xrTableCell40.Text = String.Format("{0:n0}", Double.Parse(duno));
            }
            catch { }
            try
            {
                if (Double.Parse(cuoiky) != 0)
                    xrTableCell33.Text = String.Format("{0:n0}", Double.Parse(cuoiky));
            }
            catch { }
            xrTableCell39.Text = "Số dư nợ đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay));
            xrLabel3.Text = gen.GetString("select AccountingObjectName +' ('+AccountingObjectCode+')' from AccountingObject where AccountingObjectID='"+makhach+"'");
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "BẢNG KÊ CHI TIẾT CÔNG NỢ THỰC TẾ";
            xrLabel6.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel5.Text = "Từ ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel8.Text =xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Ngày lập");
            GroupField groupField2 = new GroupField("Order");
            GroupField groupField1 = new GroupField("Phiếu");

            GroupHeader1.GroupFields.Add(groupField);
            GroupHeader1.GroupFields.Add(groupField2);
            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell6.DataBindings.Add("Text", DataSource, "Ngày lập","{0:dd-MM-yyyy}");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Phương tiện");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Ghi chú");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();
          

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n2}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            xrTableCell27.Summary = summarytotal;   

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell29.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Thanh toán", "{0:n0}");
            xrTableCell30.Summary = summarytotal4;



            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            xrTableCell22.Summary = summarytotal1;

            summarytotal7.Running = SummaryRunning.Group;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell31.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.Func = DevExpress.XtraReports.UI.SummaryFunc.Max;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell38.DataBindings.Add("Text", DataSource, "Dư nợ", "{0:n0}");
            xrTableCell38.Summary = summarytotal8;


            xrTableCell43.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đơn vị tính");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Thanh toán", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Dư nợ", "{0:n0}");
            //xrTableCell24.DataBindings.Add("Text", DataSource, "Ghi chú");
        }
    }
}
