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
    public partial class rpbangkehanghoatheoxe : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkehanghoatheoxe()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay,string soxe, string taixe, string tsbt)
        {
            xrLabel9.Text = xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "BẢNG KÊ TỔNG HỢP HÀNG HÓA THEO XE";
            xrLabel10.Text = xrLabel5.Text = soxe + " - " + taixe;
            xrLabel7.Text = "Giao nhận: ";
            xrLabel3.Text = "Từ ngày: " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);

            DataTable temp = gen.GetTable("select InventoryItemCode,InventoryItemName,sum(a.Quantity),sum(a.QuantityConvert) from INOutwardLPGDetail a, INOutwardLPG b, InventoryItem d where a.RefID=b.RefID and a.InventoryItemID=d.InventoryItemID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and CustomField6=N'" + soxe + "' and ShippingNo=N'" + taixe + "' group by InventoryItemCode,InventoryItemName");
            for (int i = 0; i < 14; i++)
            {
                if (i < temp.Rows.Count)
                {
                    xrTable6.Rows[i].Cells[0].Text = temp.Rows[i][0].ToString();
                    xrTable6.Rows[i].Cells[1].Text = temp.Rows[i][1].ToString();
                    xrTable6.Rows[i].Cells[2].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    xrTable6.Rows[i].Cells[3].Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][3].ToString()));
                }
            }
            if (tsbt == "bkthhhtxtomtat") 
            {
                PageHeader.Visible = false;
                Detail.Visible = false;
                GroupFooter1.Visible = false;
                GroupHeader1.Visible = false;
                xrTable4.Visible = false;
                xrLabel6.Text = xrLabel6.Text + " " + xrLabel3.Text.ToUpper();
                xrLabel9.Visible = true;
                xrLabel10.Visible = true;
                ReportHeader.Visible = false;
            }
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            GroupField groupField = new GroupField("Ngày lập");
            GroupHeader1.GroupFields.Add(groupField);



            xrTableCell1.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Tên khách");

            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell4.Summary = summary;

            xrTableCell5.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n2}";
            xrTableCell5.Summary = summary1;


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
            summarytotal.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell22.Summary = summarytotal;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell101.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell101.Summary = summarytotal3;


            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell23.Summary = summarytotal1;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell102.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell102.Summary = summarytotal4;

            xrTableCell10.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Phương tiện");
        }
    }
}
