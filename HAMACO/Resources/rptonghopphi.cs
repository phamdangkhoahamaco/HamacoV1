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
    public partial class rptonghopphi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptonghopphi()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        string userid = null, denngay=null, tungay=null,tsbt1=null;
        public void gettieude(string congty, string ngaychungtu, string ngaydau, string tsbt)
        {
            userid = congty;
            denngay = ngaychungtu;
            tungay = ngaydau;
            tsbt1 = tsbt;

            if (tsbt == "tsbtbkthcpthuan")
            {
                xrTableCell15.Text = "Trên báo cáo";
                xrTableCell17.Text = "Ghi ngoài";
            }

            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");

            if (DateTime.Parse(tungay).Month == DateTime.Parse(denngay).Month)
                xrLabel5.Text = "THÁNG " + DateTime.Parse(denngay).Month + " NĂM " + DateTime.Parse(denngay).Year;
            else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 3)
                xrLabel5.Text = "QUÝ I NĂM " + DateTime.Parse(denngay).Year;
            else if (DateTime.Parse(tungay).Month == 4 && DateTime.Parse(denngay).Month == 6)
                xrLabel5.Text = "QUÝ II NĂM " + DateTime.Parse(denngay).Year;
            else if (DateTime.Parse(tungay).Month == 7 && DateTime.Parse(denngay).Month == 9)
                xrLabel5.Text = "QUÝ III NĂM " + DateTime.Parse(denngay).Year;
            else if (DateTime.Parse(tungay).Month == 10 && DateTime.Parse(denngay).Month == 12)
                xrLabel5.Text = "QUÝ VI NĂM " + DateTime.Parse(denngay).Year;
            else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 12)
                xrLabel5.Text = "NĂM " + DateTime.Parse(denngay).Year;
            else
                xrLabel5.Text = "TỪ THÁNG " + DateTime.Parse(tungay).Month + " ĐẾN THÁNG " + DateTime.Parse(denngay).Month + " NĂM " + DateTime.Parse(denngay).Year;
            
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {

            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Tài khoản tổng hợp");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tài khoản tổng hợp");


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell3.Summary = summarytotal;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell4.Summary = summarytotal2;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell16.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell19.Summary = summarytotal3;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Tài khoản");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Tên tài khoản");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
        }

        public void BindDatakho(DataTable da)
        {

            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Tên kho");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên kho");


            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell3.Summary = summarytotal;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell4.Summary = summarytotal2;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell16.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
            xrTableCell19.Summary = summarytotal3;

            xrTableCell1.DataBindings.Add("Text", DataSource, "Tài khoản");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Tên tài khoản");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số tiền nợ", "{0:n0}");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền có", "{0:n0}");
        }

        private void xrTableCell1_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            try
            {
                if (tsbt1 != "tsbtbkthcptn" && tsbt1 != "tsbtbkthtncp")
                {
                    if (DateTime.Parse(tungay).Month == DateTime.Parse(denngay).Month)
                    {
                        tonghoptaikhoan thtk = new tonghoptaikhoan();
                        string name = gen.GetString("select AccountName from Account where AccountNumber='" + e.Brick.Text + "'");
                        thtk.loadchitietskt(denngay, "tsbtthp", userid, "", e.Brick.Text, name);
                    }
                }
            }
            catch { }
        }

        private void xrTableCell2_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            try
            {
                if (tsbt1 == "tsbtbkthcptn")
                {
                    string dulieu = e.Brick.Text.Replace("Tài khoản tổng hợp: ",""), name = e.Brick.Text.Replace("Tài khoản tổng hợp: ", "");
                    tonghoptaikhoan thtk = new tonghoptaikhoan();
                    if (name != "")
                        name = gen.GetString("select InventoryCategoryName from InventoryItemCategory where InventoryCategoryCode='" + dulieu + "'");
                    thtk.loadchitietskt(denngay, "tsbtbkthcptn", userid, "", dulieu, name);
                }
                else if (tsbt1 == "tsbtbkthtncp")
                {
                    string name = e.Brick.Text.Replace("Tài khoản tổng hợp: ", ""),dulieu=null;
                    tonghoptaikhoan thtk = new tonghoptaikhoan();
                    if (name != "")
                        dulieu = gen.GetString("select GroupCostID from GroupCost  where GroupCost=N'" + name + "'");
                    thtk.loadchitietskt(denngay, "tsbtbkthtncp", userid, "", dulieu, name);
                }
            }
            catch { }
        }
    }
}
