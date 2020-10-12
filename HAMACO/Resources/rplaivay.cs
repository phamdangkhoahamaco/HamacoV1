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
    public partial class rplaivay : DevExpress.XtraReports.UI.XtraReport
    {
        public rplaivay()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b, string c, string ngaychungtu, string makho, string tsbt)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = a;
            xrLabel3.Text = c;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            if (tsbt == "tsbtctlvtn")             
            {
               xrLabel17.Text = xrLabel11.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Dauky from SyncostMN where Month(PostedDate)='" + thang + "' and YEAR(PostedDate)='" + nam + "' and Manganh='" + makho + "'")));
               xrLabel5.Text = "MÃ NGÀNH " + makho;
               xrLabel23.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Lai from SyncostMN where Month(PostedDate)='" + thang + "' and YEAR(PostedDate)='" + nam + "' and Manganh='" + makho + "'")));
            }
            else
            {
                if (thang != "1")
                {
                    try
                    {
                        xrLabel11.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Surplus from Syncost where Month(Postdate)='" + thangtruoc + "' and YEAR(Postdate)='" + namtruoc + "' and StockID='" + makho + "'")));
                    }
                    catch { } try
                    {
                        xrLabel14.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Cost from Syncost where Month(Postdate)='" + thangtruoc + "' and YEAR(Postdate)='" + namtruoc + "' and StockID='" + makho + "'")));
                    }
                    catch { } try
                    {
                        xrLabel12.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select VATOut from Syncost where Month(Postdate)='" + thangtruoc + "' and YEAR(Postdate)='" + namtruoc + "' and StockID='" + makho + "'")));
                    }
                    catch { } try
                    {
                        xrLabel13.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select VATIn from Syncost where Month(Postdate)='" + thangtruoc + "' and YEAR(Postdate)='" + namtruoc + "' and StockID='" + makho + "'")));
                    }
                    catch { } try
                    {
                        xrLabel15.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Depreciation from Syncost where Month(Postdate)='" + thangtruoc + "' and YEAR(Postdate)='" + namtruoc + "' and StockID='" + makho + "'")));
                    }
                    catch { }
                }
                else
                {
                    xrLabel6.Text = "Tồn kho cuối kỳ trước:";
                    xrLabel7.Text = "Nợ phải thu cuối kỳ trước:";
                    xrLabel8.Text = "Nợ phải trả cuối kỳ trước:";
                    xrLabel9.Text = "Có phải thu cuối kỳ trước:";
                    xrLabel10.Text = "Có phải trả cuối kỳ trước:";
                    if (gen.GetString("select SUBSTRING(DefaultAccountNumber,1,1) from Stock where StockID='" + makho + "'") == "2")
                    {
                        xrLabel11.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(Amount),0) from OpeningInventoryEntry where Month(RefOrder)='" + thangtruoc + "' and Year(RefOrder)='" + namtruoc + "' and StockID in (select StockID from (select SUBSTRING(DefaultAccountNumber,2,2) as kho from Stock where StockID='" + makho + "') a, Stock b where kho=SUBSTRING(DefaultAccountNumber,2,2))")));
                        xrLabel12.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(DebitAmount),0) from AccountAccumulated where Month(PostDate)='" + thangtruoc + "' and Year(PostDate)='" + namtruoc + "' and SUBSTRING(AccountNumber,1,3)='131' and StockID in (select StockID from (select SUBSTRING(DefaultAccountNumber,2,2) as kho from Stock where StockID='" + makho + "') a, Stock b where kho=SUBSTRING(DefaultAccountNumber,2,2))")));
                        xrLabel13.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(DebitAmount),0) from AccountAccumulated where Month(PostDate)='" + thangtruoc + "' and Year(PostDate)='" + namtruoc + "' and SUBSTRING(AccountNumber,1,3)='331' and StockID in (select StockID from (select SUBSTRING(DefaultAccountNumber,2,2) as kho from Stock where StockID='" + makho + "') a, Stock b where kho=SUBSTRING(DefaultAccountNumber,2,2))")));
                        xrLabel14.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(CreditAmount),0) from AccountAccumulated where Month(PostDate)='" + thangtruoc + "' and Year(PostDate)='" + namtruoc + "' and SUBSTRING(AccountNumber,1,3)='131' and StockID in (select StockID from (select SUBSTRING(DefaultAccountNumber,2,2) as kho from Stock where StockID='" + makho + "') a, Stock b where kho=SUBSTRING(DefaultAccountNumber,2,2))")));
                        xrLabel15.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(CreditAmount),0) from AccountAccumulated where Month(PostDate)='" + thangtruoc + "' and Year(PostDate)='" + namtruoc + "' and SUBSTRING(AccountNumber,1,3)='331' and StockID in (select StockID from (select SUBSTRING(DefaultAccountNumber,2,2) as kho from Stock where StockID='" + makho + "') a, Stock b where kho=SUBSTRING(DefaultAccountNumber,2,2))")));
                    }
                    else
                    {
                        if (gen.GetString("select LPG from Stock where StockID='" + makho + "'") == "False")
                            xrLabel11.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(Amount),0) from OpeningInventoryEntry where Month(RefOrder)='" + thangtruoc + "' and Year(RefOrder)='" + namtruoc + "' and StockID='" + makho + "'")));
                        else
                            xrLabel11.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(Amount),0) from OpeningInventoryEntrySU where Month(RefOrder)='" + thangtruoc + "' and Year(RefOrder)='" + namtruoc + "' and StockID='" + makho + "'")));
                        xrLabel12.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(DebitAmount),0) from AccountAccumulated where Month(PostDate)='" + thangtruoc + "' and Year(PostDate)='" + namtruoc + "' and SUBSTRING(AccountNumber,1,3)='131' and StockID='" + makho + "'")));
                        xrLabel13.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(DebitAmount),0) from AccountAccumulated where Month(PostDate)='" + thangtruoc + "' and Year(PostDate)='" + namtruoc + "' and SUBSTRING(AccountNumber,1,3)='331' and StockID='" + makho + "'")));
                        xrLabel14.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(CreditAmount),0) from AccountAccumulated where Month(PostDate)='" + thangtruoc + "' and Year(PostDate)='" + namtruoc + "' and SUBSTRING(AccountNumber,1,3)='131' and StockID='" + makho + "'")));
                        xrLabel15.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(SUM(CreditAmount),0) from AccountAccumulated where Month(PostDate)='" + thangtruoc + "' and Year(PostDate)='" + namtruoc + "' and SUBSTRING(AccountNumber,1,3)='331' and StockID='" + makho + "'")));
                    }
                }
                xrLabel17.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Beginning from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + makho + "'")));
                xrLabel19.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Payment from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + makho + "'")));
                xrLabel21.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Other from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + makho + "'")));
                xrLabel23.Text = String.Format("{0:n0}", Double.Parse(gen.GetString("select Interest+Payment+Other from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + makho + "'")));
            }
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tiền vay", "{0:n0}");
            xrTableCell16.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell17.DataBindings.Add("Text", DataSource, "Cộng hàng điều", "{0:n0}");
            xrTableCell17.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Trừ hàng điều", "{0:n0}");
            xrTableCell18.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Tiền trả", "{0:n0}");
            xrTableCell19.Summary = summarytotal3;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Tiền lãi", "{0:n0}");
            xrTableCell21.Summary = summarytotal5;

            xrTableCell7.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Tiền vay", "{0:n0}");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Cộng hàng điều", "{0:n0}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Trừ hàng điều", "{0:n0}");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Tiền trả", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tiền lãi", "{0:n0}");
        }
    }
}
