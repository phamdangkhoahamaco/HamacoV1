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
    public partial class rptonghopphieunhapxuat : DevExpress.XtraReports.UI.XtraReport
    {
        public rptonghopphieunhapxuat()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string congty, string ngaychungtu, string kho, string phieu)
        {
            if (phieu == "tsbtthpnxtt")
            {
                xrLabel2.Text = "BẢNG KÊ TỔNG HỢP PHIẾU NHẬP XUẤT";

            }
            else
                xrLabel2.Text = "BẢNG KÊ TỔNG HỢP PHIẾU NHẬP XUẤT ĐIỀU CHỈNH";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel3.Text =kho;
            if (kho != "")
                GroupHeader2.Visible = false;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }
        public void BindData(DataTable da)
        {

            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField2 = new GroupField("Ngày");
            GroupHeader1.GroupFields.Add(groupField2);

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Số phiếu");
            GroupHeader1.GroupFields.Add(groupField);

            Bands.Add(GroupHeader2);
            GroupField groupField1 = new GroupField("Tên kho");
            GroupHeader2.GroupFields.Add(groupField1);
          
            xrLabel6.DataBindings.Add("Text", DataSource, "Tên kho");

            xrTableCell3.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Khách hàng");
            xrTableCell38.DataBindings.Add("Text", DataSource, "Hóa đơn");


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


            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n2}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Số lượng nhập", "{0:n2}");
            xrTableCell7.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số tiền nhập", "{0:n0}");
            xrTableCell10.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng xuất", "{0:n2}");
            xrTableCell11.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Group;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số tiền xuất", "{0:n0}");
            xrTableCell12.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Group;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n2}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Số lượng nhập", "{0:n2}");
            xrTableCell28.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Group;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Số tiền nhập", "{0:n0}");
            xrTableCell29.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Group;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n2}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Số lượng xuất", "{0:n2}");
            xrTableCell30.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Group;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Số tiền xuất", "{0:n0}");
            xrTableCell31.Summary = summarytotal7;


            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n2}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Số lượng nhập", "{0:n2}");
            xrTableCell34.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "Số tiền nhập", "{0:n0}");
            xrTableCell35.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Report;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n2}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Số lượng xuất", "{0:n2}");
            xrTableCell36.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell37.DataBindings.Add("Text", DataSource, "Số tiền xuất", "{0:n0}");
            xrTableCell37.Summary = summarytotal11;

            xrTableCell13.DataBindings.Add("Text", DataSource, "Nợ");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Có");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số lượng nhập", "{0:n2}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số tiền nhập", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Số lượng xuất", "{0:n2}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số tiền xuất", "{0:n0}");
        }
    }
}
