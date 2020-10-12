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
    public partial class rps07 : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rps07()
        {
            InitializeComponent();
        }

        public void gettieude(string a, string b, string c,string d,string e,string f,string g,int tong)
        {
            xrLabel6.Text = g;
            xrLabel2.Text = a;
            xrLabel11.Text = a;
            xrLabel12.Text = d;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrTableCell37.Text = gen.GetString("select Top 1 Cashier from Center");
            xrTableCell38.Text = gen.GetString("select Top 1 ChiefAccountant from Center");
            xrTableCell40.Text = gen.GetString("select Top 1 DGM from Center");
            xrLabel5.Text = b;
            xrLabel7.Text = c;
            try { xrTableCell8.Text = String.Format("{0:n0}", Double.Parse(e)); }
            catch { }
            try { xrTableCell9.Text = String.Format("{0:n0}", Double.Parse(f)); }
            catch { }
            xrLabel9.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrLabel8.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            if (tong == 1)
            {
                xrTableCell3.Text = "Tồn đầu kỳ:";
                xrTableCell1.Text = "Tồn cuối kỳ:";
                xrTableCell25.Text =xrTableCell15.Text= "Ngày lập";

                this.xrTableCell25.Weight = 0.20003476919479912D;
                this.xrTableCell26.Weight = 0.63400912907805478D;

                this.xrTableCell15.Weight = 0.20003476919479912D;
                this.xrTableCell2.Weight = 0.63400912907805478D;

                this.xrTableCell6.Weight = 0.29291479967154791D;
                this.xrTableCell16.Weight = 0.2540018961516657D;
                this.xrTableCell10.Weight = 0.81750123807472133D;

                this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            }
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell21.Summary = summarytotal1;


            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
        }

        public void BindDatatong(DataTable da)
        {
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell21.Summary = summarytotal1;


            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng", "{0:dd-MM-yyyy}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
        }


        public void gettieudetheodonvi(string ngaychungtu, string donvi)
        {
            xrLabel2.Text = "SỔ QUỸ TIỀN MẶT";
            xrTableCell39.Text = "Trưởng đơn vị";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + donvi + "'");
            xrLabel7.Text = "Ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel9.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
            xrLabel8.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',AccountingObjectName as 'Tên khách hàng',a.JournalMemo as 'Lý do',case when DebitAccount<>'1111' then DebitAccount end as 'TK nợ',case when CreditAccount<>'1111' then CreditAccount end as 'TK có', case when DebitAccount='1111' then Amount end as 'Số tiền nợ',case when CreditAccount='1111' then Amount end as 'Số tiền có'  from HACHTOAN a, AccountingObject b where a.AccountingObjectIDMain=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and CAST(RefDate as date)='" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' and Goods in (select StockID from Stock where BranchID='" + donvi + "') order by DebitAccount,RefNo");
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell21.Summary = summarytotal1;


            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");

            Double Tonquy = Double.Parse(gen.GetString("select COALESCE(SUM(TKNo),0) - COALESCE(SUM(TKCo),0) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' and Goods in (select StockID from Stock where BranchID='" + donvi + "')) a"));
            xrTableCell8.Text = String.Format("{0:n0}", Tonquy);
            Tonquy = Double.Parse(gen.GetString("select COALESCE(SUM(TKNo),0) - COALESCE(SUM(TKCo),0) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).AddDays(1).ToShortDateString() + "' and Goods in (select StockID from Stock where BranchID='" + donvi + "')) a"));
            xrTableCell9.Text = String.Format("{0:n0}", Tonquy);
        }

        public void gettieudetheokho(string ngaychungtu, string donvi)
        {
            xrLabel2.Text = "SỔ QUỸ TIỀN MẶT";
            xrTableCell39.Text = "Trưởng đơn vị";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + donvi + "'");
            xrLabel7.Text = "Ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel9.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
            xrLabel8.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',AccountingObjectName as 'Tên khách hàng',a.JournalMemo as 'Lý do',case when DebitAccount<>'1111' then DebitAccount end as 'TK nợ',case when CreditAccount<>'1111' then CreditAccount end as 'TK có', case when DebitAccount='1111' then Amount end as 'Số tiền nợ',case when CreditAccount='1111' then Amount end as 'Số tiền có'  from HACHTOAN a, AccountingObject b where a.AccountingObjectIDMain=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and CAST(RefDate as date)='" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' and Goods ='" + donvi + "' order by DebitAccount,RefNo");
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell21.Summary = summarytotal1;


            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");

            Double Tonquy = 0;
            try
            {
                Tonquy = Double.Parse(gen.GetString("select COALESCE(SUM(TKNo),0) - COALESCE(SUM(TKCo),0) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' and Goods ='" + donvi + "') a"));
            }
            catch { }
            xrTableCell8.Text = String.Format("{0:n0}", Tonquy);
            Tonquy = 0;
            try
            {
                Tonquy = Double.Parse(gen.GetString("select COALESCE(SUM(TKNo),0) - COALESCE(SUM(TKCo),0) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).AddDays(1).ToShortDateString() + "' and Goods ='" + donvi + "') a"));
            }
            catch { }
            xrTableCell9.Text = String.Format("{0:n0}", Tonquy);
        }


        public void gettieudetheodonvithang(string ngaychungtu, string donvi)
        {
            xrLabel2.Text = "SỔ QUỸ TIỀN MẶT";
            xrTableCell39.Text = "Trưởng đơn vị";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + donvi + "'");
            xrLabel7.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel9.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
            xrLabel8.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',AccountingObjectName as 'Tên khách hàng',a.JournalMemo as 'Lý do',case when DebitAccount<>'1111' then DebitAccount end as 'TK nợ',case when CreditAccount<>'1111' then CreditAccount end as 'TK có', case when DebitAccount='1111' then Amount end as 'Số tiền nợ',case when CreditAccount='1111' then Amount end as 'Số tiền có'  from HACHTOAN a, AccountingObject b where a.AccountingObjectIDMain=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "' and Goods in (select StockID from Stock where BranchID='" + donvi + "') order by DebitAccount,RefNo");
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell21.Summary = summarytotal1;


            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");

            //Double Tonquy = Double.Parse(gen.GetString("select SUM(TKNo) - SUM(TKCo) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' and StockID in (select StockID from Stock where BranchID='" + donvi + "')) a"));
            xrTableCell8.Text = "";
            //Tonquy = Double.Parse(gen.GetString("select SUM(TKNo) - SUM(TKCo) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).AddDays(1).ToShortDateString() + "' and StockID in (select StockID from Stock where BranchID='" + donvi + "')) a"));
            xrTableCell9.Text = "";
            xrTableCell3.Text = "";
            xrTableCell1.Text = "";
        }

        public void gettieudetheokhothang(string ngaychungtu, string donvi)
        {
            xrLabel2.Text = "SỔ QUỸ TIỀN MẶT";
            xrTableCell39.Text = "Trưởng đơn vị";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + donvi + "'");
            xrLabel7.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel9.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
            xrLabel8.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',AccountingObjectName as 'Tên khách hàng',a.JournalMemo as 'Lý do',case when DebitAccount<>'1111' then DebitAccount end as 'TK nợ',case when CreditAccount<>'1111' then CreditAccount end as 'TK có', case when DebitAccount='1111' then Amount end as 'Số tiền nợ',case when CreditAccount='1111' then Amount end as 'Số tiền có'  from HACHTOAN a, AccountingObject b where a.AccountingObjectIDMain=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "' and Goods ='" + donvi + "' order by DebitAccount,substring(RefNo,4,12)");
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell21.Summary = summarytotal1;


            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");

            //Double Tonquy = Double.Parse(gen.GetString("select SUM(TKNo) - SUM(TKCo) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' and StockID in (select StockID from Stock where BranchID='" + donvi + "')) a"));
            xrTableCell8.Text = "";
            //Tonquy = Double.Parse(gen.GetString("select SUM(TKNo) - SUM(TKCo) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).AddDays(1).ToShortDateString() + "' and StockID in (select StockID from Stock where BranchID='" + donvi + "')) a"));
            xrTableCell9.Text = "";
            xrTableCell3.Text = "";
            xrTableCell1.Text = "";
        }

        public void gettieudephatsinhtheodonvi(string ngaychungtu, string donvi)
        {
            xrLabel2.Text = "SỔ QUỸ TIỀN MẶT";
            xrTableCell39.Text = "Trưởng đơn vị";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + donvi + "'");
            xrLabel7.Text = "Ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel9.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
            xrLabel8.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',AccountingObjectName as 'Tên khách hàng',a.JournalMemo as 'Lý do',case when DebitAccount<>'1111' then DebitAccount end as 'TK nợ',case when CreditAccount<>'1111' then CreditAccount end as 'TK có', case when DebitAccount='1111' then Amount end as 'Số tiền nợ',case when CreditAccount='1111' then Amount end as 'Số tiền có'  from HACHTOAN a, AccountingObject b where a.AccountingObjectIDMain=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and CAST(RefDate as date)='" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' and StockID in (select StockID from Stock where BranchID='" + donvi + "') order by DebitAccount,RefNo");
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell20.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell21.Summary = summarytotal1;


            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");

            Double Tonquy = Double.Parse(gen.GetString("select COALESCE(SUM(TKNo),0) - COALESCE(SUM(TKCo),0) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' and StockID in (select StockID from Stock where BranchID='" + donvi + "')) a"));
            xrTableCell8.Text = String.Format("{0:n0}", Tonquy);
            Tonquy = Double.Parse(gen.GetString("select COALESCE(SUM(TKNo),0) - COALESCE(SUM(TKCo),0) from (select case when DebitAccount='1111' then Amount end as 'TKNo', case when CreditAccount='1111' then Amount end as 'TKCo' from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and (CreditAccount='1111' or DebitAccount='1111') and RefDate<'" + DateTime.Parse(ngaychungtu).AddDays(1).ToShortDateString() + "' and StockID in (select StockID from Stock where BranchID='" + donvi + "')) a"));
            xrTableCell9.Text = String.Format("{0:n0}", Tonquy);
        }

    }
}
