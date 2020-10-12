﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;

namespace HAMACO.Resources
{
    public partial class rptonghoptaikhoanphieu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptonghoptaikhoanphieu()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string a, string b, string c, string diachi)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrTableCell24.Text = gen.GetString("select Top 1 Title from Center");
            xrTableCell30.Text = diachi;
            xrLabel2.Text = a;
            xrLabel3.Text = c;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();

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

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell26.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell26.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n2}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell27.Summary = summarytotal3;

            xrTableCell6.DataBindings.Add("Text", DataSource, "Số phiếu");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yy}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Tên khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Lý do");
            xrTableCell11.DataBindings.Add("Text", DataSource, "TK nợ");
            xrTableCell12.DataBindings.Add("Text", DataSource, "TK có");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Mã kho");
        }
    }
}
