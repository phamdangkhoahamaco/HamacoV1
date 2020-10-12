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
    public partial class rpbangcandoiketoan : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbangcandoiketoan()
        {
            InitializeComponent();
        }
        public void gettieude(string ngaychungtu, string userid)
        {
            xrTableCell32.Text=xrTableCell1.Text = "01/01/" + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrTableCell31.Text=xrTableCell2.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel6.Text = " Tại ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu))+" tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            if (DateTime.Parse(ngaychungtu).Month.ToString() == "3")
                xrLabel10.Text=xrLabel3.Text = "Cho Quý 1 năm 2013 kết thúc ngày 31/03/2013";
            else
                xrLabel10.Text=xrLabel3.Text = "Cho tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + " kết thúc ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel1.Text = xrLabel8.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = xrLabel9.Text = gen.GetString("select Top 1 Address from Center");
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
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();

            XRSummary summarytotal8 = new XRSummary();
            XRSummary summarytotal9 = new XRSummary();
            XRSummary summarytotal10 = new XRSummary();
            XRSummary summarytotal11 = new XRSummary();


            Bands.Add(GroupHeader1);
            GroupField groupField2 = new GroupField("Nhóm 1");
            GroupHeader1.GroupFields.Add(groupField2);

            xrTableCell12.DataBindings.Add("Text", DataSource, "Nhóm 1");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Mã số 1");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Thuyết minh");

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell15.DataBindings.Add("Text", DataSource, "Số cuối kỳ", "{0:n0}");
            xrTableCell15.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số đầu kỳ", "{0:n0}");
            xrTableCell16.Summary = summarytotal1;

            Bands.Add(GroupHeader2);
            GroupField groupField1 = new GroupField("Nhóm 2");
            GroupHeader2.GroupFields.Add(groupField1);

            xrTableCell7.DataBindings.Add("Text", DataSource, "Nhóm 2");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Mã số 2");

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số cuối kỳ", "{0:n0}");
            xrTableCell10.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Group;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số đầu kỳ", "{0:n0}");
            xrTableCell11.Summary = summarytotal3;

            Bands.Add(GroupHeader3);
            GroupField groupField = new GroupField("STT");
            GroupHeader3.GroupFields.Add(groupField);

            xrTableCell6.DataBindings.Add("Text", DataSource, "Nhóm 3");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Tên nhóm 3");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Mã số 3");

            summarytotal4.Running = SummaryRunning.Group;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số cuối kỳ", "{0:n0}");
            xrTableCell24.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Group;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell25.DataBindings.Add("Text", DataSource, "Số đầu kỳ", "{0:n0}");
            xrTableCell25.Summary = summarytotal5;
          

           

            

            
            /*
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
            xrTableCell37.Summary = summarytotal11;*/

            xrTableCell17.DataBindings.Add("Text", DataSource, "Chỉ tiêu");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Mã số");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Thuyết minh chỉ tiêu");
            /*xrTableCell20.DataBindings.Add("Text", DataSource, "Số cuối kỳ", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số đầu kỳ", "{0:n0}");*/
            xrTableCell20.DataBindings.Add("Text", DataSource, "Cuối kỳ");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Đầu kỳ");
        }
    }
}
