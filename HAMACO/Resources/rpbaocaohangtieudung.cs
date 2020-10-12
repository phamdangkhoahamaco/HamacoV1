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
    public partial class rpbaocaohangtieudung : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaohangtieudung()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        string ngay = null;
        public void gettieude(string ngaychungtu)
        {
            ngaychungtu = DateTime.Parse(ngaychungtu).ToShortDateString();
            ngay = ngaychungtu;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel6.Text = "Tại ngày " + string.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + string.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + string.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrTableCell32.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            string ngaychungtutruoc = DateTime.Parse(ngaychungtu).AddDays(-1).ToShortDateString();
            string donvi = gen.GetString("select BranchID from Stock where StockCode='02'");
            string makho = gen.GetString("select StockID from Stock where StockCode='02'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            //xrTableCell24.Text = string.Format("{0:n0}",Double.Parse(gen.GetString("baocaocongnokiemtrahangtieudung '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'")));

            xrTableCell36.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(Amount),0) from HACHTOAN where DAY(RefDate)='" + DateTime.Parse(ngaychungtu).Day + "' and MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and DebitAccount='1111' and StockID='" + makho + "'")));
            xrTableCell33.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(Amount),0) from HACHTOAN where DAY(RefDate)<='" + DateTime.Parse(ngaychungtu).Day + "' and MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and DebitAccount='1111' and StockID='" + makho + "'")));

            xrTableCell41.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(Amount),0) from HACHTOAN where DAY(RefDate)='" + DateTime.Parse(ngaychungtu).Day + "' and MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and CreditAccount='1111' and StockID='" + makho + "'")));
            xrTableCell38.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(Amount),0) from HACHTOAN where DAY(RefDate)<='" + DateTime.Parse(ngaychungtu).Day + "' and MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and CreditAccount='1111' and StockID='" + makho + "'")));

            //xrTableCell64.Text = string.Format("{0:n0}", Double.Parse(xrTableCell36.Text) - Double.Parse(xrTableCell41.Text));
            xrTableCell61.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(Amount),0) from HACHTOAN where DAY(RefDate)<='" + DateTime.Parse(ngaychungtu).Day + "' and DebitAccount='1111' and StockID='" + makho + "'")) - Double.Parse(gen.GetString("select  COALESCE(sum(Amount),0) from HACHTOAN where DAY(RefDate)<='" + DateTime.Parse(ngaychungtu).Day + "' and MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and CreditAccount='1111' and StockID='" + makho + "'")));

            xrTableCell42.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,2)='IN' and StockID='" + makho + "'")));
            xrTableCell37.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)<='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,2)='IN' and StockID='" + makho + "'")));

            xrTableCell50.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,3)='UNI' and StockID='" + makho + "'")));
            xrTableCell49.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)<='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,3)='UNI' and StockID='" + makho + "'")));

            xrTableCell46.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,3)='MAR' and StockID='" + makho + "'")));
            xrTableCell45.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)<='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,3)='MAR' and StockID='" + makho + "'")));

            xrTableCell58.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and JournalMemo=N'Đường' and StockID='" + makho + "'")));
            xrTableCell57.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)<='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and JournalMemo=N'Đường' and StockID='" + makho + "'")));

            xrTableCell12.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and StockID='" + makho + "'")));
            xrTableCell1.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select COALESCE(sum(TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/1.1,0) from INOutward where DAY(RefDate)<='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and StockID='" + makho + "'")));

            DataTable tonkho = gen.GetTable("baocaotonkhotheothangthuctehangtieudung '" + makho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            Double tongtonkho = 0, tongtonkho1 = 0, khac1 = 0, khac2 = 0;
            for (int i = 0; i < tonkho.Rows.Count; i++)
            {
                if (tonkho.Rows[i][0].ToString().ToUpper() == "UNI")
                    xrTableCell22.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][1].ToString()));
                else if (tonkho.Rows[i][0].ToString().ToUpper() == "GAU")
                    xrTableCell10.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][1].ToString()));
                else if (tonkho.Rows[i][0].ToString().ToUpper() == "MAR")
                    xrTableCell16.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][1].ToString()));
                else if (tonkho.Rows[i][0].ToString().ToUpper() == "DUO")
                    xrTableCell54.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][1].ToString()));
                tongtonkho = tongtonkho + Double.Parse(tonkho.Rows[i][1].ToString());
            }
            xrTableCell4.Text = string.Format("{0:n0}", tongtonkho);

            tonkho=gen.GetTable("baocaocongnokiemtrahangtieudung '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'");
            tongtonkho = 0;
            for (int i = 0; i < tonkho.Rows.Count; i++)
            {
                if (tonkho.Rows[i][0].ToString().ToUpper() == "UNI")
                {
                    xrTableCell75.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][1].ToString()));
                    xrTableCell70.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][2].ToString()));
                }
                else if (tonkho.Rows[i][0].ToString().ToUpper() == "GAU")
                {
                    xrTableCell53.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][1].ToString()));
                    xrTableCell2.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][2].ToString()));
                }
                else if (tonkho.Rows[i][0].ToString().ToUpper() == "MAR")
                {
                    xrTableCell74.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][1].ToString()));
                    xrTableCell65.Text = string.Format("{0:n0}", Double.Parse(tonkho.Rows[i][2].ToString()));
                }
                else
                {
                    khac1 = khac1 + Double.Parse(tonkho.Rows[i][1].ToString());
                    khac2 = khac2 + Double.Parse(tonkho.Rows[i][2].ToString());
                }
                tongtonkho = tongtonkho + Double.Parse(tonkho.Rows[i][1].ToString());
                tongtonkho1 = tongtonkho1 + Double.Parse(tonkho.Rows[i][2].ToString());
            }
            xrTableCell24.Text = string.Format("{0:n0}", tongtonkho);
            xrTableCell19.Text = string.Format("{0:n0}", khac1);
            xrTableCell72.Text = string.Format("{0:n0}", khac2);
            xrTableCell76.Text = string.Format("{0:n0}", tongtonkho1);

            xrTableCell82.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalAmount-TotalFreightAmount+TotalAmountOC),0) from INOutwardBK where RefType='901' and DAY(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,2)='IN' and StockID='" + makho + "'")));
            xrTableCell93.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalAmount-TotalFreightAmount+TotalAmountOC),0) from INOutwardBK where RefType='901' and DAY(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Day + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,3)='UNI' and StockID='" + makho + "'")));

            xrTableCell92.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalFreightAmount/1.1),0) from INOutward where YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,2)='IN' and StockID='" + makho + "'")));
            xrTableCell98.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalFreightAmount/1.1),0) from INOutward where YEAR(RefDate)='" + DateTime.Parse(ngaychungtutruoc).Year + "' and SUBSTRING(JournalMemo,1,3)='UNI' and StockID='" + makho + "'")));

            xrTableCell90.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalFreightAmount/1.1),0) from INOutward where RefDate<='" + ngaychungtutruoc + "' and SUBSTRING(JournalMemo,1,2)='IN' and StockID='" + makho + "'")) - Double.Parse(gen.GetString("select COALESCE(SUM(Amount),0) from HACHTOAN where CreditAccount='1388' and AccountingObjectID='10E6D9B7-A3D2-4149-9A22-7DDF3562C93E' and RefDate<='" + ngaychungtutruoc + "'")));
            xrTableCell104.Text = string.Format("{0:n0}", Double.Parse(gen.GetString("select  COALESCE(sum(TotalFreightAmount/1.1),0) from INOutward where RefDate<='" + ngaychungtutruoc + "' and SUBSTRING(JournalMemo,1,3)='UNI' and StockID='" + makho + "'")) - Double.Parse(gen.GetString("select COALESCE(SUM(Amount),0) from HACHTOAN where CreditAccount='1388' and AccountingObjectID='21EA1C1A-6A9A-4E81-86E6-A3B5D37989A6' and RefDate<='" + ngaychungtutruoc + "'")));
        
        }

        private void xrTableCell27_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("bccnhtdbk");
            F.getngay(ngay);
            F.ShowDialog();
        }

        private void xrTableCell6_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            //baocaotonkho bctk = new baocaotonkho();
            //bctk.loadbctkthdtndnbcnhangtieudung(ngay);
        }
        private void xrTableCell31_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            Frm_rpcongno F = new Frm_rpcongno();
            F.gettsbt("bctqtdv");
            F.getngaychungtu(ngay);
            F.getkho(gen.GetString("select BranchID from Stock where StockCode='02'"));
            F.ShowDialog();
        }

        private void xrTableCell81_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            Frm_rpcongno F = new Frm_rpcongno();
            F.gettsbt("bcthkh");
            F.getngaychungtu(ngay);
            F.getkho(gen.GetString("select BranchID from Stock where StockCode='02'"));
            F.ShowDialog();
        }
    }
}
