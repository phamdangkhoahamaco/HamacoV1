using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
namespace HAMACO.Resources
{
    public partial class rpbangkehoadonthanhtoan : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        doiso ds = new doiso();
        public rpbangkehoadonthanhtoan()
        {
            InitializeComponent();
        }
        public void gettieude(string makhach, string kho, string tungay,string denngay,string tsbt)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = gen.GetString("select Top 1 Address from Center");
            xrTableCell33.Text = gen.GetString("select Top 1  CEO from Center");
            xrLabel6.Text = "TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel13.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);

            DataTable khach = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Address,CompanyTaxCode from AccountingObject where AccountingObjectID='" + makhach + "'");
            xrLabel8.Text = khach.Rows[0][1].ToString().ToUpper() + " (" + khach.Rows[0][0].ToString() + ")";
            xrLabel7.Text = khach.Rows[0][2].ToString();
            xrLabel9.Text = khach.Rows[0][3].ToString();
            xrTableCell4.Text = "Xác nhận của "+khach.Rows[0][1].ToString();

            DataTable dt = new DataTable();
            string ngay = String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay));
            string thangtruoc = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Tổng", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền hàng", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế", Type.GetType("System.Double"));
            dt.Columns.Add("Thanh toán", Type.GetType("System.Double"));
            dt.Columns.Add("Tồn", Type.GetType("System.Double"));
            dt.Columns.Add("Ký hiệu", Type.GetType("System.String"));
            dt.Columns.Add("TS", Type.GetType("System.String"));

            if (tsbt == "331")
                xrLabel5.Text = "BẢNG KÊ HÓA ĐƠN MUA HÀNG VÀ CHỨNG TỪ ĐÃ THANH TOÁN";
            
            DataTable temp = new DataTable();
            temp = gen.GetTable("baocaocongnochitiet131tndnbh '" + kho + "','" + tungay + "','" + denngay + "','" + ngay + "','" + thangtruoc + "','" + namtruoc + "','" + tsbt + "','" + makhach + "'");
            
            
            Double luyke = 0;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                if (temp.Rows[i][1].ToString() != "")
                    dr[1] = temp.Rows[i][1].ToString();
                else
                {
                    dr[0] = temp.Rows[i][4].ToString();
                    if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    {
                        dr[3] = temp.Rows[i][5];
                        luyke = luyke + Double.Parse(temp.Rows[i][5].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    {
                        dr[3] = "-" + temp.Rows[i][6];
                        luyke = luyke - Double.Parse(temp.Rows[i][6].ToString());
                    }
                    
                }
                dr[2] = temp.Rows[i][2].ToString();
                dr[8] = temp.Rows[i][11].ToString();
                dr[9] = temp.Rows[i][12].ToString();

                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[5] = temp.Rows[i][13].ToString();
                
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                {
                    dr[3] = temp.Rows[i][7];
                    luyke = luyke + Double.Parse(temp.Rows[i][7].ToString());
                }

                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                    dr[4] = temp.Rows[i][14];

                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                {
                    dr[6] = temp.Rows[i][8];
                    luyke = luyke - Double.Parse(temp.Rows[i][8].ToString());
                }
                if (luyke != 0)
                    dr[7] = luyke;            
                dt.Rows.Add(dr);
            }
            xrLabel15.Text = String.Format("{0:n0}", luyke);
            
            if (luyke < 0)
            {
                luyke = 0 - luyke;
                xrLabel17.Text = "Bằng chữ: (" + ds.ChuyenSo(luyke.ToString()).Replace(".","")+").";
            }
            else
            xrLabel17.Text = "Bằng chữ: "+ds.ChuyenSo(luyke.ToString());
            
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            DataSource = dt;

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tiền hàng", "{0:n0}");
            xrTableCell13.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell20.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            xrTableCell20.Summary = summarytotal1;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Tổng", "{0:n0}");
            xrTableCell21.Summary = summarytotal5;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Thanh toán", "{0:n0}");
            xrTableCell23.Summary = summarytotal4;

            summarytotal2.Running = SummaryRunning.None;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Tồn", "{0:n0}");
            xrTableCell30.Summary = summarytotal2;

            xrTableCell60.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell1.DataBindings.Add("Text", DataSource, "Ký hiệu");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Tiền hàng", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "TS");
            xrTableCell26.DataBindings.Add("Text", DataSource, "Thuế", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Tổng", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Thanh toán", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Tồn", "{0:n0}");
        }
    }
}
