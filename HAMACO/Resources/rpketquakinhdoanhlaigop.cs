using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HAMACO.Resources
{
    public partial class rpketquakinhdoanhlaigop : DevExpress.XtraReports.UI.XtraReport
    {
        public rpketquakinhdoanhlaigop()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        DataTable dt1 = new DataTable();
        string kho1 = null;
        string ngaychungtu = null;
        string tsbt1 = null;
        public void gettieude(string denngay, string kho, string tsbt, string tungay)
        {
            kho1 = kho;
            ngaychungtu = denngay;
            tsbt1 = tsbt;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            DataTable temp = new DataTable();
            temp = gen.GetTable("select StockCode,StockName from Stock where StockID='" + kho + "'");
            xrLabel3.Text = "KHO " + (temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString()).ToUpper();
            
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
            xrLabel2.Text = "TÌNH HÌNH KẾT QUẢ KINH DOANH " + xrLabel2.Text;
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Nhóm hàng");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell1.DataBindings.Add("Text", DataSource, "Nhóm hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên nhóm");
            dt1 = da;
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();
            XRSummary summarytotal9 = new XRSummary();
            XRSummary summarytotal10 = new XRSummary();
            XRSummary summarytotal11 = new XRSummary();
            XRSummary summarytotal12 = new XRSummary();
            XRSummary summarytotal13 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();
            XRSummary summarytotal16 = new XRSummary();

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell3.Summary = summarytotal1;

            summarytotal15.Running = SummaryRunning.Group;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n2}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell33.Summary = summarytotal15;

            summarytotal3.Running = SummaryRunning.Group;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell5.DataBindings.Add("Text", DataSource, "Trị giá vốn", "{0:n0}");
            xrTableCell5.Summary = summarytotal3;


            summarytotal6.Running = SummaryRunning.Group;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Trị giá bán", "{0:n0}");
            xrTableCell7.Summary = summarytotal6;


            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell8.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            xrTableCell8.Summary = summarytotal8;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n2}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            xrTableCell19.Summary = summarytotal5;

            summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n2}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell35.Summary = summarytotal16;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell26.DataBindings.Add("Text", DataSource, "Trị giá vốn", "{0:n0}");
            xrTableCell26.Summary = summarytotal9;


            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Trị giá bán", "{0:n0}");
            xrTableCell30.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            xrTableCell32.Summary = summarytotal13;


            xrTableCell9.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Đơn giá vốn", "{0:n2}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Trị giá vốn", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Đơn giá bán", "{0:n2}");
            xrTableCell15.DataBindings.Add("Text", DataSource, "Trị giá bán", "{0:n0}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
        }

        private void xrTableCell9_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            baocaotonkho bctk = new baocaotonkho();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][0].ToString() == e.Brick.Text)
                {
                    bctk.inthekholaigop(ngaychungtu, tsbt1, kho1, dt1.Rows[i][11].ToString());
                    return;
                }
            }
        }
    }
}
