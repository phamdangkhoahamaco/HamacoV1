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
    public partial class rpbaocaocongnohangtieudung : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaocongnohangtieudung()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel3.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel5.Text = "Đến ngày " + string.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + string.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + string.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            DataTable da = gen.GetTable("select SUBSTRING(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày',AccountingObjectName as 'Tên khách',DebitAmount as 'Thành tiền',case when Note='' then CreditAmount end as 'Nợ',EmployeeIDSAName as 'Nhân viên',case when Note<>'' then N'Chưa giao' else NoteMain end as 'Ghi chú', EmployeeIDSACode as 'Ngành' from OpeningAccountEntry131TTBackup where PostedDate='" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' order by RefDate,SUBSTRING(RefNo,7,9)");
            if (da.Rows.Count == 0)
            {
                da = gen.GetTable("select SUBSTRING(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày',AccountingObjectName as 'Tên khách',DebitAmount as 'Thành tiền',case when Note='' then CreditAmount end as 'Nợ',EmployeeIDSAName as 'Nhân viên',case when Note<>'' then N'Chưa giao' else NoteMain end as 'Ghi chú', EmployeeIDSACode as 'Ngành' from OpeningAccountEntry131TTBackup where PostedDate=(select MAX(PostedDate) from OpeningAccountEntry131TTBackup where PostedDate<'" + DateTime.Parse(ngaychungtu).ToShortDateString() + "') order by RefDate,SUBSTRING(RefNo,7,9)");
            }
            
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Ngành");
            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell14.DataBindings.Add("Text", DataSource, "Ngành");

            xrTableCell18.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n0}";
            xrTableCell18.Summary = summary1;

            XRSummary summarytotal = new XRSummary();
            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            xrTableCell16.Summary = summarytotal;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Ngày","{0:dd/MM/yyyy}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Nhân viên");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Ghi chú");
        }

        public void gettieudebk(string ngaychungtu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel3.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel5.Text = "Đến ngày " + string.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + string.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + string.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);


            DataTable da = gen.GetTable("select SUBSTRING(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày',AccountingObjectName as 'Tên khách',DebitAmount as 'Thành tiền',case when Note='' then CreditAmount end as 'Nợ',EmployeeIDSAName as 'Nhân viên',case when Note<>'' then N'Chưa giao' else NoteMain end as 'Ghi chú', EmployeeIDSACode as 'Ngành' from OpeningAccountEntry131TTBackup where PostedDate='" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' order by RefDate,SUBSTRING(RefNo,7,9)");
            if (da.Rows.Count == 0)
            {
                da = gen.GetTable("select SUBSTRING(RefNo,7,9) as 'Số phiếu',RefDate as 'Ngày',AccountingObjectName as 'Tên khách',DebitAmount as 'Thành tiền',case when Note='' then CreditAmount end as 'Nợ',EmployeeIDSAName as 'Nhân viên',case when Note<>'' then N'Chưa giao' else NoteMain end as 'Ghi chú', EmployeeIDSACode as 'Ngành' from OpeningAccountEntry131TTBackup where PostedDate=(select MAX(PostedDate) from OpeningAccountEntry131TTBackup where PostedDate<'" + DateTime.Parse(ngaychungtu).ToShortDateString() + "') order by RefDate,SUBSTRING(RefNo,7,9)");
            }
            
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Ngành");
            GroupHeader1.GroupFields.Add(groupField1);
            xrTableCell14.DataBindings.Add("Text", DataSource, "Ngành");

            xrTableCell18.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            XRSummary summary1 = new XRSummary();
            summary1.Running = SummaryRunning.Group;
            summary1.IgnoreNullValues = true;
            summary1.FormatString = "{0:n0}";
            xrTableCell18.Summary = summary1;

            XRSummary summarytotal = new XRSummary();
            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            xrTableCell16.Summary = summarytotal;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd/MM/yyyy}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Nợ", "{0:n0}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Nhân viên");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Ghi chú");
        }

    }
}
