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
    public partial class rpketquakinhdoanh : DevExpress.XtraReports.UI.XtraReport
    {
        public rpketquakinhdoanh()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        string tsbt1 = null, tungay1=null,denngay1=null;
        public void gettieude(string denngay, string kho, string congty,string tsbt,string tungay)
        {
            tsbt1 = tsbt;
            tungay1 = tungay;
            denngay1 = denngay;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center"); ;
            DataTable temp = new DataTable();
            if (tsbt == "tsbtthkqkd")
            {
                temp = gen.GetTable("select StockCode,StockName from Stock where StockID='" + kho + "'");
                xrLabel3.Text = "KHO "+(temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString()).ToUpper();
            }
            else if (tsbt == "tsbtthkqkdtdv")
            {
                temp = gen.GetTable("select BranchCode,BranchName from Branch where BranchID='" + kho + "'");
                xrLabel3.Text = "ĐƠN VỊ "+(temp.Rows[0][0].ToString() + " - " + temp.Rows[0][1].ToString()).ToUpper();
            }
            else if (tsbt == "tsbtthkqkdcuahang")
            {
                Detail.Visible = false;
                xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                xrTableCell20.Text = "Mã kho";
                xrTableCell21.Text = "Tên kho";
            }
            else if (tsbt == "tsbtthkqkdloaihang")
            {
                Detail.Visible = false;
                xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                xrTableCell20.Text = "Mã loại";
                xrTableCell21.Text = "Tên loại";
                xrTableCell4.ForeColor = System.Drawing.Color.Black;
                xrTableCell23.ForeColor = System.Drawing.Color.Black;
                xrTableCell24.Text = "Chi phí";
            }
            else if (tsbt == "tsbtthkqkdkhuvuc")
            {
                Detail.Visible = false;
                xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                xrTableCell20.Text = "Mã khu vực";
                xrTableCell21.Text = "Tên khu vực";
            }
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
            xrLabel2.Text = "TÌNH HÌNH KẾT QUẢ KINH DOANH "+xrLabel2.Text;
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Nhóm hàng");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell1.DataBindings.Add("Text", DataSource, "Nhóm hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên nhóm");

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
            XRSummary summarytotal14 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();
            XRSummary summarytotal16 = new XRSummary();

            summarytotal15.Running = SummaryRunning.Group;
            summarytotal15.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell4.DataBindings.Add("Text", DataSource, "Đơn giá vốn", "{0:n0}");
            xrTableCell4.Summary = summarytotal15;


            summarytotal14.Running = SummaryRunning.Group;
            summarytotal14.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n2}";
            xrTableCell6.DataBindings.Add("Text", DataSource, "Đơn giá bán", "{0:n2}");
            xrTableCell6.Summary = summarytotal14;

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            xrTableCell3.Summary = summarytotal1;

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

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell26.DataBindings.Add("Text", DataSource, "Trị giá vốn", "{0:n0}");
            xrTableCell26.Summary = summarytotal9;

            summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Đơn giá vốn", "{0:n0}");
            xrTableCell23.Summary = summarytotal16;


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
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng","{0:n2}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Đơn giá vốn","{0:n2}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Trị giá vốn", "{0:n0}");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Đơn giá bán", "{0:n2}");
            xrTableCell15.DataBindings.Add("Text", DataSource, "Trị giá bán", "{0:n0}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
        }



        private void xrTableCell1_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            try
            {
                if (tsbt1 == "tsbtthkqkdloaihang")
                {
                    string dulieu = e.Brick.Text, name = e.Brick.Text;
                    tonghoptaikhoan thtk = new tonghoptaikhoan();
                    if (name != "")
                        name = gen.GetString("select InventoryCategoryName from InventoryItemCategory where InventoryCategoryCode='" + dulieu + "'");
                    thtk.loadchitietskt(denngay1, "tsbtbkthcptn", "", "", dulieu, name);
                }
            }
            catch { }
        }
    }
}
