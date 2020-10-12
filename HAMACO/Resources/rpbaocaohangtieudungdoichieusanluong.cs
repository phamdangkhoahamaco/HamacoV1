using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbaocaohangtieudungdoichieusanluong : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaohangtieudungdoichieusanluong()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string makhuyenmai)
        {
            xrLabel5.Text = "BÁO CÁO ĐỐI CHIẾU KHUYẾN MÃI UNILEVER";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel6.Text = "MÃ KHUYẾN MÃI - " + makhuyenmai.ToUpper();
            xrLabel7.Text = "Ngày bắt đầu " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " Ngày kết thúc " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = gen.GetTable("select Substring(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày lập',REPLACE(InvoiceNo,'UNI','') as 'Đơn hàng',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng',Case when Freecode='" + makhuyenmai + "' then Quantity end as 'Số lượng',Case when Freecode<>'" + makhuyenmai + "' then Quantity end as 'Số lượng khác',Case when Freecode<>'" + makhuyenmai + "' then FreeCode end as 'Chương trình khác',QuantityConvert as 'Ghi nhận',Case when chenhlech<>0 then chenhlech end as 'Chênh lệch' from (select b.RefNo,b.RefDate,a.InvoiceNo,a.Quantity,b.QuantityConvert,FreeCode,COALESCE(Quantity,0)-COALESCE(QuantityConvert,0) as chenhlech,case when b.InventoryItemID Is null then a.InventoryItemID else b.InventoryItemID end mahang from (select a.RefNo,a.RefDate,c.InvoiceNo,QuantityConvert,b.InventoryItemID from INOutward a, INOutwardDetail b, (select distinct InvoiceNo from INOutwardCheck where FreeCode='" + makhuyenmai + "') c where a.ParalellRefNo=c.InvoiceNo and a.RefID=b.RefID and b.Amount=0) b full outer join (select b.InventoryItemID,Quantity,InvoiceNo,FreeCode from (select * from INOutwardCheck a, (select distinct InvoiceNo as hoadon from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.hoadon) a, InventoryItem b where a.InventoryItemCode=b.InventoryItemCode) a on a.InventoryItemID=b.InventoryItemID and a.InvoiceNo=b.InvoiceNo) a, InventoryItem b where a.mahang=b.InventoryItemID order by a.InvoiceNo,[Số lượng] DESC");
            DataSource = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Đơn hàng");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell10.DataBindings.Add("Text", DataSource, "Đơn hàng");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd/MM/yy}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Số phiếu");

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell20.Summary = summarytotal4;

            xrTableCell30.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số lượng khác", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Chương trình khác");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Ghi nhận", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
        }

        public void gettieudegau(string tungay, string denngay, string makhuyenmai)
        {
            xrLabel5.Text = "BÁO CÁO ĐỐI CHIẾU KHUYẾN MÃI GẤU ĐỎ";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel6.Text = "MÃ KHUYẾN MÃI - " + makhuyenmai.ToUpper();
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = gen.GetTable("select Substring(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày lập',REPLACE(InvoiceNo,'UNI','') as 'Đơn hàng',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng',Case when Freecode='" + makhuyenmai + "' then Quantity end as 'Số lượng',Case when Freecode<>'" + makhuyenmai + "' then Quantity end as 'Số lượng khác',Case when Freecode<>'" + makhuyenmai + "' then FreeCode end as 'Chương trình khác',QuantityConvert as 'Ghi nhận',Case when chenhlech<>0 then chenhlech end as 'Chênh lệch' from (select b.RefNo,b.RefDate,a.InvoiceNo,a.Quantity,b.QuantityConvert,FreeCode,COALESCE(Quantity,0)-COALESCE(QuantityConvert,0) as chenhlech,case when b.InventoryItemID Is null then a.InventoryItemID else b.InventoryItemID end mahang from (select a.RefNo,a.RefDate,c.InvoiceNo,QuantityConvert,b.InventoryItemID from INOutward a, INOutwardDetail b, (select distinct InvoiceNo from INOutwardCheck where FreeCode='" + makhuyenmai + "') c where a.JournalMemo=c.InvoiceNo and a.RefID=b.RefID and b.Amount=0) b full outer join (select b.InventoryItemID,Quantity,InvoiceNo,FreeCode from (select * from INOutwardCheck a, (select distinct InvoiceNo as hoadon from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.hoadon) a, InventoryItem b where a.InventoryItemCode=b.InventoryItemCode) a on a.InventoryItemID=b.InventoryItemID and a.InvoiceNo=b.InvoiceNo) a, InventoryItem b where a.mahang=b.InventoryItemID order by a.InvoiceNo,[Số lượng] DESC");
            DataSource = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Đơn hàng");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell10.DataBindings.Add("Text", DataSource, "Đơn hàng");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd/MM/yy}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Số phiếu");

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell20.Summary = summarytotal4;

            xrTableCell30.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số lượng khác", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Chương trình khác");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Ghi nhận", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
        }
    }
}
