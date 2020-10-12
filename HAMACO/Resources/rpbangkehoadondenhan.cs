using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbangkehoadondenhan : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkehoadondenhan()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string userid)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel6.Text = "TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel13.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Ký hiệu", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));            
            dt.Columns.Add("Tiền hàng", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế", Type.GetType("System.Double"));
            dt.Columns.Add("Tổng", Type.GetType("System.Double"));
            dt.Columns.Add("Đến hạn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tài khoản", Type.GetType("System.String"));

            DataTable temp = new DataTable();
            temp = gen.GetTable("bangkehoadondenhanthanhtoan '" + tungay + "','" + denngay + "','" + userid + "'");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dr[6] = temp.Rows[i][6].ToString();
                dr[7] = temp.Rows[i][7].ToString();
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8].ToString();
                dr[9] = temp.Rows[i][9].ToString();
                dr[10] = temp.Rows[i][10].ToString();
                dt.Rows.Add(dr);
            }

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            DataSource = dt;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Khách hàng");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell4.DataBindings.Add("Text", DataSource, "Khách hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tài khoản");

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell38.DataBindings.Add("Text", DataSource, "Tiền hàng", "{0:n0}");
            xrTableCell38.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            xrTableCell40.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell41.DataBindings.Add("Text", DataSource, "Tổng", "{0:n0}");
            xrTableCell41.Summary = summarytotal2;


            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tiền hàng", "{0:n0}");
            xrTableCell13.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            xrTableCell20.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Tổng", "{0:n0}");
            xrTableCell21.Summary = summarytotal5;
           

            xrTableCell60.DataBindings.Add("Text", DataSource, "Mã kho");
            xrTableCell1.DataBindings.Add("Text", DataSource, "Ký hiệu");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd/MM/yyyy}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Tiền hàng", "{0:n0}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Tổng", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Đến hạn", "{0:dd/MM/yyyy}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            
        }
    }
}
