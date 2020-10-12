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
    public partial class rphoadonbanhang : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rphoadonbanhang()
        {
            InitializeComponent();
        }
        string ma = null;
        public void gettieude(string ngayhoadon,string mst,string nguoinop,string donvi,string diachi,string thanhtoan,Double tongtienhang,Double tienthue,Double thue,Double tongtien,string hoten,string sotienchu,string co,string kho,string phieu,string makhach,string ghichu)
        {
            xrLabel11.Text = nguoinop;
            xrLabel13.Text = donvi;
            xrLabel15.Text = diachi;
            xrLabel14.Text = ma = phieu;
            xrLabel16.Text = makhach;
            xrLabel21.Text = thanhtoan;
            xrLabel20.Text = ghichu;
            xrLabel3.Text = String.Format("{0:dd             MM               yyyy}", DateTime.Parse(ngayhoadon));
            
            if (mst == "")
                mst = "/";
            String[] mstt = Array.ConvertAll<Char, String>(mst.ToCharArray(), Convert.ToString);
            xrLabel6.Text = String.Join("    ", mstt);

            string taikhoan = gen.GetString("select BankAccount from AccountingObject where AccountingObjectCode='"+makhach.Replace("(","").Replace(")","")+"'");
            //String[] taikhoantk = Array.ConvertAll<Char, String>(taikhoan.ToCharArray(), Convert.ToString);
            //xrLabel22.Text = String.Join("    ", taikhoantk);
            xrLabel22.Text = taikhoan;

            xrLabel1.Text = String.Format("{0:n0}",tongtienhang);
            if (thue == -100)
            {
                xrLabel2.Text = "/";
                xrLabel4.Text = "/";
            }
            else
            {
                xrLabel2.Text = String.Format("{0:n0}", tienthue);
                xrLabel4.Text = String.Format("{0:n0}", thue);
            }
            xrLabel5.Text = String.Format("{0:n0}", tongtien);
            
            xrLabel8.Text = hoten;
            xrLabel7.Text = sotienchu;
            if (co == "1")
                xrLabel19.Visible = true;
            try
            {
                DataTable temp = gen.GetTable("select InvName,Description,Code,Province from Stock where StockID='" + kho + "'");
                {
                    if (temp.Rows[0][3].ToString() != "CT")
                    {
                        xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(83F, 190F);
                        ReportHeader.Visible = true;
                        xrLabel9.Text = temp.Rows[0][0].ToString();
                        xrLabel10.Text = temp.Rows[0][1].ToString();
                        String[] msttcn = Array.ConvertAll<Char, String>(temp.Rows[0][2].ToString().ToCharArray(), Convert.ToString);
                        xrLabel12.Text = String.Join("    ", msttcn);
                    }
                }
            }
            catch { }
        }
        public void BindData(DataTable da)
        {
            DataSource = da;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();

            if (ma.Substring(0, 2) == "07")
            {
                summarytotal.Running = SummaryRunning.Report;
                summarytotal.IgnoreNullValues = true;
                summarytotal.FormatString = "{0:n0}";
                xrLabel18.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
                xrLabel18.Summary = summarytotal;

                summarytotal1.Running = SummaryRunning.Report;
                summarytotal1.IgnoreNullValues = true;
                summarytotal1.FormatString = "{0:n2}";
                xrLabel17.DataBindings.Add("Text", DataSource, "Loại", "{0:n2}");
                xrLabel17.Summary = summarytotal1;
            }

            xrTableCell4.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell11.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Loại");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell1.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
        }
    }
}
