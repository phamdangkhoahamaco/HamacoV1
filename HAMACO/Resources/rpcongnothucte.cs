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
    public partial class rpcongnothucte : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        string tungay1, denngay1, kho1,loai;
        DataTable dt1 = new DataTable();
        public rpcongnothucte()
        {
            InitializeComponent();
        }
        public DataTable getdata(DataTable a)
        {
            dt1 = a;
            return dt1;
        }
        public void gettieude(string tungay, string denngay, string kho,string loai1)
        {
            loai = loai1;
            tungay1 = tungay;
            denngay1 = denngay;
            kho1 = kho;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "BẢNG KÊ CÔNG NỢ THỰC TẾ";
            xrLabel3.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel5.Text = "Từ ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

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
            xrTableCell23.DataBindings.Add("Text", DataSource, "Nợ cuối kỳ", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Có cuối kỳ", "{0:n0}");
        }

        private void xrTableCell15_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            baocaocongno131 bccn = new baocaocongno131();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][0].ToString() == e.Brick.Text)
                {
                    if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004" && kho1.ToUpper() == "E074A43F-0D0E-4D8F-BE2C-BFA6B32DBD5F")
                    {
                        Frm_nhapxuat F = new Frm_nhapxuat();
                        F.gettsbt("tsbtbccn131bienbanxacnhannochitiet");
                        F.getngay(tungay1);
                        F.getdenngay(denngay1);
                        F.getrole(e.Brick.Text);
                        if (dt1.Rows[i][6].ToString() != "")
                            F.getcongty(dt1.Rows[i][6].ToString());
                        else
                            F.getcongty("-" + dt1.Rows[i][7].ToString());
                        F.getdauky(dt1.Rows[i][5].ToString());
                        F.getkho(kho1);
                        F.ShowDialog();
                    }
                    else
                    {
                        if (dt1.Rows[i][2].ToString() != "")
                            bccn.loadchitietnothucte(e.Brick.Text, tungay1, denngay1, kho1, dt1.Rows[i][2].ToString(), loai);
                        else
                            bccn.loadchitietnothucte(e.Brick.Text, tungay1, denngay1, kho1, "-" + dt1.Rows[i][3].ToString(), loai);
                    }
                }
            }
        }
    }

}
