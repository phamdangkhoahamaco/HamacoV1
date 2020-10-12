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
    public partial class rpthuegtgt : DevExpress.XtraReports.UI.XtraReport
    {
        public rpthuegtgt()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string congty, string mst, string tsbt,string tinh,string noiky)
        {
            xrLabel18.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel17.Text = mst;
            xrLabel16.Text =  gen.GetString("select Top 1 CompanyName from Center").ToUpper() + tinh.ToUpper();
            xrLabel9.Text = noiky + ", " + "ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            if (tsbt == "tsbtthuedaura")
            {
                GroupHeader2.Visible = false;
                xrTableCell3.Text = "Tên người mua";
                xrTableCell5.Text = "Mã số thuế người mua";
                xrLabel3.Text = "BẢNG KÊ HÓA ĐƠN, CHỨNG TỪ HÀNG HÓA, DỊCH VỤ BÁN RA";
                xrLabel12.Text = "Tổng giá trị hàng hóa, dịch vụ bán ra:";
                xrLabel13.Text = "Tổng thuế GTGT của hàng hóa, dịch vụ bán ra:";
            }
        }

        public void BindData(DataTable da)
        {
           
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Nhóm");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell36.DataBindings.Add("Text", DataSource, "Loại");


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();


            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Doanh số", "{0:n0}");
            xrTableCell31.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Thuế GTGT", "{0:n0}");
            xrTableCell33.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrLabel14.DataBindings.Add("Text", DataSource, "Doanh số", "{0:n0}");
            xrLabel14.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrLabel15.DataBindings.Add("Text", DataSource, "Thuế GTGT", "{0:n0}");
            xrLabel15.Summary = summarytotal3;

            /*summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "C336", "{0:n0}");
            xrTableCell32.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "N331", "{0:n0}");
            xrTableCell33.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "N3313", "{0:n0}");
            xrTableCell34.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "N3319", "{0:n0}");
            xrTableCell35.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "N336", "{0:n0}");
            xrTableCell36.Summary = summarytotal8;*/

            xrTableCell13.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Ký hiệu");
            xrTableCell37.DataBindings.Add("Text", DataSource, "Mẫu số");
            xrTableCell15.DataBindings.Add("Text", DataSource, "Số hóa đơn");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Ngày hóa đơn", "{0:dd-MM-yyyy}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Tên người bán");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Mã số thuế");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Mặt hàng");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Doanh số", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Thuế");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Thuế GTGT", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Ghi chú");
        }
    }
}
