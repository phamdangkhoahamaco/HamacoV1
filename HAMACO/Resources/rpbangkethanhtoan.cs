using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbangkethanhtoan : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkethanhtoan()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string role)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            DataTable temp = gen.GetTable("select ContactTitle,b.AccountingObjectName,Tax,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName,a.CustomField5  from CAPayment a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
            xrLabel11.Text = temp.Rows[0][1].ToString();
            if (temp.Rows[0][2].ToString() != "")
                xrTableCell2.Text = "Thuế suất " + temp.Rows[0][2].ToString() + "%";
            xrLabel17.Text = temp.Rows[0][0].ToString();
            xrLabel13.Text = temp.Rows[0][8].ToString();
            xrLabel15.Text= temp.Rows[0][3].ToString();
            xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][5].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][5].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][5].ToString()));
            xrLabel6.Text = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
            xrLabel21.Text = doi.ChuyenSo(Double.Parse(temp.Rows[0][9].ToString()).ToString());
            xrLabel9.Text = temp.Rows[0][11].ToString();
        }

        public void BindData(string role)
        {
            DataSource = gen.GetTable("bangkethanhtoan '" + role + "'");
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            
            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell16.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell17.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            xrTableCell17.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell18.Summary = summarytotal3;

            xrTableCell5.DataBindings.Add("Text", DataSource, "Diễn giải");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Ngày","{0:dd/MM/yy}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Số");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Ký hiệu");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        
        }
    }
}
