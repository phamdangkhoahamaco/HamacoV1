using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbaocaohangtieudungdoichieu : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaohangtieudungdoichieu()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string makhuyenmai)
        {

            xrLabel5.Text = "BÁO CÁO ĐỐI CHIẾU CHIẾT KHẤU UNILEVER";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel6.Text = "MÃ KHUYẾN MÃI - " + makhuyenmai.ToUpper();
            
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = new DataTable();
            try
            {
                xrLabel7.Text = "Ngày bắt đầu " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " Ngày kết thúc " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
                da = gen.GetTable("select Substring(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày lập',REPLACE(InvoiceNo,'UNI','') as 'Đơn hàng',case when FreeCode='" + makhuyenmai + "' then sotien end as 'Số tiền',case when FreeCode<>'" + makhuyenmai + "' then sotien end as 'Tiền khác', case when FreeCode<>'" + makhuyenmai + "' then FreeCode end 'Chương trình khác',tongtien as 'Tổng tiền',chietkhau as 'Chiết khấu',Case when tongtien-chietkhau<>0 then tongtien-chietkhau end as 'Chênh lệch' from (select a.InvoiceNo,FreeCode,sotien,tongtien from (select a.InvoiceNo,FreeCode,SUM(Amount) as sotien from (select * from INOutwardCheck where Amount<>0) a, (select distinct InvoiceNo  from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.InvoiceNo group by a.InvoiceNo,FreeCode) a,(select a.InvoiceNo,SUM(Amount) as tongtien from (select * from INOutwardCheck where Amount<>0) a, (select distinct InvoiceNo  from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.InvoiceNo group by a.InvoiceNo) b where a.InvoiceNo=b.InvoiceNo) a,(select RefNo,RefDate,ParalellRefNo,Round(TotalFreightAmount/1.1,0) as chietkhau from INOutward) b where a.InvoiceNo=b.ParalellRefNo order by RefNo,RefDate,[Số tiền] DESC");
            }
            catch
            {
                xrLabel7.Text = "Ngày bắt đầu " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay));
                da = gen.GetTable("select Substring(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày lập',REPLACE(InvoiceNo,'UNI','') as 'Đơn hàng',case when FreeCode='" + makhuyenmai + "' then sotien end as 'Số tiền',case when FreeCode<>'" + makhuyenmai + "' then sotien end as 'Tiền khác', case when FreeCode<>'" + makhuyenmai + "' then FreeCode end 'Chương trình khác',tongtien as 'Tổng tiền',chietkhau as 'Chiết khấu',Case when tongtien-chietkhau<>0 then tongtien-chietkhau end as 'Chênh lệch' from (select a.InvoiceNo,FreeCode,sotien,tongtien from (select a.InvoiceNo,FreeCode,SUM(Amount) as sotien from (select * from INOutwardCheck where Amount<>0) a, (select distinct InvoiceNo  from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.InvoiceNo group by a.InvoiceNo,FreeCode) a,(select a.InvoiceNo,SUM(Amount) as tongtien from (select * from INOutwardCheck where Amount<>0) a, (select distinct InvoiceNo  from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.InvoiceNo group by a.InvoiceNo) b where a.InvoiceNo=b.InvoiceNo) a,(select RefNo,RefDate,ParalellRefNo,Round(TotalFreightAmount/1.1,0) as chietkhau from INOutward where Month(RefDate)='" + DateTime.Parse(tungay).Month + "' and Year(RefDate)='" + DateTime.Parse(tungay).Year + "') b where a.InvoiceNo=b.ParalellRefNo order by RefNo,RefDate,[Số tiền] DESC");
                //da = gen.GetTable("select Substring(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày lập',REPLACE(InvoiceNo,'UNI','') as 'Đơn hàng',case when FreeCode='" + makhuyenmai + "' then sotien end as 'Số tiền',case when FreeCode<>'" + makhuyenmai + "' then sotien end as 'Tiền khác', case when FreeCode<>'" + makhuyenmai + "' then FreeCode end 'Chương trình khác',tongtien as 'Tổng tiền',chietkhau as 'Chiết khấu',Case when tongtien-chietkhau<>0 then tongtien-chietkhau end as 'Chênh lệch' from (select a.InvoiceNo,FreeCode,sotien,tongtien from (select a.InvoiceNo,FreeCode,SUM(Amount) as sotien from (select * from INOutwardCheck where Amount<>0) a, (select distinct InvoiceNo  from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.InvoiceNo group by a.InvoiceNo,FreeCode) a,(select a.InvoiceNo,SUM(Amount) as tongtien from (select * from INOutwardCheck where Amount<>0) a, (select distinct InvoiceNo  from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.InvoiceNo group by a.InvoiceNo) b where a.InvoiceNo=b.InvoiceNo) a,(select RefNo,RefDate,ParalellRefNo,Round(TotalFreightAmount/1.1,0) as chietkhau from INOutward) b where a.InvoiceNo=b.ParalellRefNo order by RefNo,RefDate,[Số tiền] DESC");
            }
            
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
            xrTableCell15.DataBindings.Add("Text", DataSource, "Chiết khấu", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            
            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell11.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Tiền khác", "{0:n0}");
            xrTableCell12.Summary = summarytotal1;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell20.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Tiền khác", "{0:n0}");
            xrTableCell21.Summary = summarytotal5;
           
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Tiền khác", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Chương trình khác");

        }

        public void gettieudegau(string tungay, string denngay, string makhuyenmai)
        {
            xrLabel5.Text = "BÁO CÁO ĐỐI CHIẾU CHIẾT KHẤU GẤU ĐỎ";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel6.Text = "MÃ KHUYẾN MÃI - " + makhuyenmai.ToUpper();

            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = new DataTable();
            da = gen.GetTable("select Substring(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày lập',REPLACE(InvoiceNo,'UNI','') as 'Đơn hàng',case when FreeCode='" + makhuyenmai + "' then sotien end as 'Số tiền',case when FreeCode<>'" + makhuyenmai + "' then sotien end as 'Tiền khác', case when FreeCode<>'" + makhuyenmai + "' then FreeCode end 'Chương trình khác',tongtien as 'Tổng tiền',chietkhau as 'Chiết khấu',Case when tongtien-chietkhau<>0 then tongtien-chietkhau end as 'Chênh lệch' from (select a.InvoiceNo,FreeCode,sotien,tongtien from (select a.InvoiceNo,FreeCode,SUM(Amount) as sotien from (select * from INOutwardCheck where Amount<>0) a, (select distinct InvoiceNo  from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.InvoiceNo group by a.InvoiceNo,FreeCode) a,(select a.InvoiceNo,SUM(Amount) as tongtien from (select * from INOutwardCheck where Amount<>0) a, (select distinct InvoiceNo  from INOutwardCheck where FreeCode='" + makhuyenmai + "') b where a.InvoiceNo=b.InvoiceNo group by a.InvoiceNo) b where a.InvoiceNo=b.InvoiceNo) a,(select RefNo,RefDate,JournalMemo,Round(TotalFreightAmount/1.1,0) as chietkhau from INOutward) b where a.InvoiceNo=b.JournalMemo order by RefNo,RefDate,[Số tiền] DESC");          

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
            xrTableCell15.DataBindings.Add("Text", DataSource, "Chiết khấu", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell11.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Tiền khác", "{0:n0}");
            xrTableCell12.Summary = summarytotal1;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell20.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Tiền khác", "{0:n0}");
            xrTableCell21.Summary = summarytotal5;

            xrTableCell22.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Tiền khác", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Chương trình khác");
        }
    }
}
