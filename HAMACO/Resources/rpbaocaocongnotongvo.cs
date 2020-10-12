using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HAMACO.Resources
{
    public partial class rpbaocaocongnotongvo : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaocongnotongvo()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        string tungay1, denngay1, kho1, tsbt1;
        DataTable dt1 = new DataTable();

        public void gettieude(string tungay, string denngay,string tsbt, string kho)
        {
            tungay1 = tungay;
            denngay1 = denngay;
            kho1 = kho;
            tsbt1 = tsbt;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            if (tsbt == "tsbtbccnvkh" || tsbt == "tsbtbccnvkhth" || tsbt == "tsbtbccnvkhtk")
                xrLabel2.Text = "BÁO CÁO CÔNG NỢ VỎ KHÁCH HÀNG ";
            else
                xrLabel2.Text = "BÁO CÁO CÔNG NỢ VỎ NHÀ CUNG CẤP ";
            xrLabel3.Text="TỪ NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            if (tsbt == "tsbtbccnvkhtk")
                xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            else
                xrLabel5.Text = "ĐƠN VỊ " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'").ToUpper();
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            dt1 = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell27.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell28.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell29.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell30.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell31.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell32.Summary = summarytotal6;


            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell33.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
            xrTableCell34.Summary = summarytotal8;


            xrTableCell15.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Họ tên khách hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Nợ đầu kỳ", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Có đầu kỳ", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Nợ phát sinh", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Có phát sinh", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Nợ lũy kế", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Có lũy kế", "{0:n0}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
        }

        private void xrTableCell15_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            baocaocongno131 bccn = new baocaocongno131();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][1].ToString() == e.Brick.Text)
                {
                    DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' bảng kê tổng hợp, 'No' để in bảng kê phát sinh, 'Cancel' để in biên bản xác nhận vỏ.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        if (tsbt1 == "tsbtbccnvkh" || tsbt1 == "tsbtbccnvncc")
                            bccn.loadbccnvotndn(tungay1, denngay1, tsbt1, kho1, dt1.Rows[i][0].ToString());
                        else if (tsbt1 == "tsbtbccnvkhth" || tsbt1 == "tsbtbccnvnccth" || tsbt1 == "tsbtbccnvkhtk")
                            bccn.loadbccnvotndn(tungay1, denngay1, tsbt1, kho1, dt1.Rows[i][1].ToString());
                    }
                    else if (dr == DialogResult.No)
                    {
                        if (tsbt1 == "tsbtbccnvkh" || tsbt1 == "tsbtbccnvncc")
                            bccn.loadbccnvotndnphatsinh(tungay1, denngay1, tsbt1, kho1, dt1.Rows[i][0].ToString());
                        else if (tsbt1 == "tsbtbccnvkhth" || tsbt1 == "tsbtbccnvkhtk" || tsbt1 == "tsbtbccnvnccth")
                            bccn.loadbccnvotndnphatsinh(tungay1, denngay1, tsbt1, kho1, dt1.Rows[i][1].ToString());
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        if (tsbt1 == "tsbtbccnvkhth")
                            bccn.loadbccnvotndn(tungay1, denngay1, tsbt1+"bbxn", kho1, dt1.Rows[i][1].ToString());
                    }
                    return;
                }
            }
        }
    }
}
