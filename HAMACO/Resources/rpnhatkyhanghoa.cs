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
    public partial class rpnhatkyhanghoa : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpnhatkyhanghoa()
        {
            InitializeComponent();
        }
        public void gettieude(string makho, string userid, string tsbt, string tungay, string denngay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            if (DateTime.Parse(tungay).Day == 1 && DateTime.Parse(denngay).Day == DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month) && DateTime.Parse(tungay).Year == DateTime.Parse(denngay).Year)
            {
                if (DateTime.Parse(tungay).Month == DateTime.Parse(denngay).Month)
                    xrLabel2.Text = "THÁNG " + DateTime.Parse(denngay).Month + " NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 3)
                    xrLabel2.Text = "QUÝ I NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 4 && DateTime.Parse(denngay).Month == 6)
                    xrLabel2.Text = "QUÝ II NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 7 && DateTime.Parse(denngay).Month == 9)
                    xrLabel2.Text = "QUÝ III NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 10 && DateTime.Parse(denngay).Month == 12)
                    xrLabel2.Text = "QUÝ VI NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 12)
                    xrLabel2.Text = "NĂM " + DateTime.Parse(denngay).Year;
                else
                {
                    tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                    denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                    xrLabel2.Text = "TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay;
                }
            }
            else
            {
                tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                xrLabel2.Text = "TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay;
            }
            xrLabel5.Text = gen.GetString("select StockCode+' - '+StockName from  Stock where StockID='" + makho + "'").ToUpper();
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            if (tsbt == "snkbh")
                xrLabel2.Text = "SỔ NHẬT KÝ BÁN HÀNG " + xrLabel2.Text;
            else if (tsbt == "snkmh")
                xrLabel2.Text = "SỔ NHẬT KÝ MUA HÀNG " + xrLabel2.Text;
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
            xrTableCell7.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell7.Summary = summarytotal;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n0}");
            xrTableCell10.Summary = summarytotal2;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;


            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Ngày HĐ","{0:dd-MM-yyyy}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Hạn nợ");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Mã nhóm");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Tên nhóm");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
        }
    }
}
