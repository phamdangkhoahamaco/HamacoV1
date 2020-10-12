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
    public partial class rpbaocaoketquahoatdongkinhdoanh : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbaocaoketquahoatdongkinhdoanh()
        {
            InitializeComponent();
        }
        public void gettieude(string denngay,string tungay)
        {

            if (DateTime.Parse(tungay).Day == 1 && DateTime.Parse(denngay).Day == DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month) && DateTime.Parse(tungay).Year == DateTime.Parse(denngay).Year)
            {
                if (DateTime.Parse(tungay).Month == DateTime.Parse(denngay).Month)
                {
                     xrLabel6.Text = "THÁNG " + DateTime.Parse(denngay).Month + " NĂM " + DateTime.Parse(denngay).Year;
                     xrLabel3.Text = "Cho tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay)) + " kết thúc ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                     xrTableCell31.Text ="Tháng "+String.Format("{0:M/yyyy}", DateTime.Parse(denngay));
                     xrTableCell32.Text ="Tháng "+String.Format("{0:M/yyyy}", DateTime.Parse(denngay).AddMonths(-1));
                     if (DateTime.Parse(tungay).Month == 1)
                     { xrTableCell32.Text = "01/01/" + String.Format("{0:yyyy}", DateTime.Parse(denngay)); }
                }
                else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 3)
                {
                    xrLabel6.Text = "Quý 1 năm " + DateTime.Parse(denngay).Year;
                     xrLabel3.Text = "Cho "+xrLabel6.Text+" kết thúc ngày "+ string.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                    xrTableCell31.Text ="Quý 1/"+String.Format("{0:yyyy}", DateTime.Parse(denngay));
                    xrTableCell32.Text ="Quý 1/"+String.Format("{0:yyyy}", DateTime.Parse(denngay).AddYears(-1));
                }
                else if (DateTime.Parse(tungay).Month == 4 && DateTime.Parse(denngay).Month == 6)
                {
                    xrLabel6.Text = "Quý 2 năm " + DateTime.Parse(denngay).Year;
                     xrLabel3.Text = "Cho "+xrLabel6.Text+" kết thúc ngày "+ string.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                     xrTableCell31.Text ="Quý 2/"+String.Format("{0:yyyy}", DateTime.Parse(denngay));
                    xrTableCell32.Text ="Quý 2/"+String.Format("{0:yyyy}", DateTime.Parse(denngay).AddYears(-1));
                }
                else if (DateTime.Parse(tungay).Month == 7 && DateTime.Parse(denngay).Month == 9)
                {
                    xrLabel6.Text = "Quý 3 năm " + DateTime.Parse(denngay).Year;
                     xrLabel3.Text = "Cho "+xrLabel6.Text+" kết thúc ngày "+ string.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                     xrTableCell31.Text ="Quý 3/"+String.Format("{0:yyyy}", DateTime.Parse(denngay));
                    xrTableCell32.Text ="Quý 3/"+String.Format("{0:yyyy}", DateTime.Parse(denngay).AddYears(-1));
                }
                else if (DateTime.Parse(tungay).Month == 10 && DateTime.Parse(denngay).Month == 12)
                {
                    xrLabel6.Text = "Quý 4 năm " + DateTime.Parse(denngay).Year;
                     xrLabel3.Text = "Cho "+xrLabel6.Text+" kết thúc ngày "+ string.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                     xrTableCell31.Text ="Quý 4/"+String.Format("{0:yyyy}", DateTime.Parse(denngay));
                    xrTableCell32.Text ="Quý 4/"+String.Format("{0:yyyy}", DateTime.Parse(denngay).AddYears(-1));
                }
                else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 12)
                {
                    xrLabel6.Text = "NĂM " + DateTime.Parse(denngay).Year;
                     xrLabel3.Text = "Cho "+xrLabel6.Text+" kết thúc ngày "+ string.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                     xrTableCell31.Text ="Năm "+String.Format("{0:yyyy}", DateTime.Parse(denngay));
                    xrTableCell32.Text ="Năm "+String.Format("{0:yyyy}", DateTime.Parse(denngay).AddYears(-1));
                }
            }
            xrLabel6.Text = xrLabel6.Text.ToUpper();
            xrTableCell90.Text="Cần thơ, ngày "+string.Format("{0:dd}", DateTime.Parse(denngay))+" tháng "+string.Format("{0:MM}", DateTime.Parse(denngay))+ " năm "+string.Format("{0:yyyy}", DateTime.Parse(denngay));
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = gen.GetString("select Top 1 Address from Center");
            xrTableCell109.Text = gen.GetString("select Top 1 DGM from Center");
            xrTableCell98.Text = gen.GetString("select Top 1 Title from Center");
            xrTableCell108.Text = gen.GetString("select Top 1 ChiefAccountant from Center");
        }

        public void BindData(DataTable dt)
        {
           
            xrTableCell20.Text = dt.Rows[0][0].ToString();
            xrTableCell21.Text = dt.Rows[0][1].ToString();
            xrTableCell99.Text = dt.Rows[0][2].ToString();

            xrTableCell4.Text = dt.Rows[1][0].ToString();
            xrTableCell5.Text = dt.Rows[1][1].ToString();
            xrTableCell106.Text = dt.Rows[1][2].ToString();

            xrTableCell9.Text = dt.Rows[2][0].ToString();
            xrTableCell10.Text = dt.Rows[2][1].ToString();
            xrTableCell110.Text = dt.Rows[2][2].ToString();

            xrTableCell14.Text = dt.Rows[3][0].ToString();
            xrTableCell15.Text = dt.Rows[3][1].ToString();
            xrTableCell111.Text = dt.Rows[3][2].ToString();

            xrTableCell24.Text = dt.Rows[4][0].ToString();
            xrTableCell25.Text = dt.Rows[4][1].ToString();
            xrTableCell112.Text = dt.Rows[4][2].ToString();

            xrTableCell34.Text = dt.Rows[5][0].ToString();
            xrTableCell35.Text = dt.Rows[5][1].ToString();
            xrTableCell113.Text = dt.Rows[5][2].ToString();

            xrTableCell39.Text = dt.Rows[6][0].ToString();
            xrTableCell40.Text = dt.Rows[6][1].ToString();
            xrTableCell114.Text = dt.Rows[6][2].ToString();

            xrTableCell44.Text = dt.Rows[7][0].ToString();
            xrTableCell45.Text = dt.Rows[7][1].ToString();
            xrTableCell115.Text = dt.Rows[7][2].ToString();

            xrTableCell49.Text = dt.Rows[8][0].ToString();
            xrTableCell50.Text = dt.Rows[8][1].ToString();
            xrTableCell116.Text = dt.Rows[8][2].ToString();

            xrTableCell54.Text = dt.Rows[9][0].ToString();
            xrTableCell55.Text = dt.Rows[9][1].ToString();
            xrTableCell117.Text = dt.Rows[9][2].ToString();

            xrTableCell59.Text = dt.Rows[10][0].ToString();
            xrTableCell60.Text = dt.Rows[10][1].ToString();
            xrTableCell118.Text = dt.Rows[10][2].ToString();

            xrTableCell64.Text = dt.Rows[11][0].ToString();
            xrTableCell65.Text = dt.Rows[11][1].ToString();
            xrTableCell119.Text = dt.Rows[11][2].ToString();

            xrTableCell69.Text = dt.Rows[12][0].ToString();
            xrTableCell70.Text = dt.Rows[12][1].ToString();
            xrTableCell120.Text = dt.Rows[12][2].ToString();

            xrTableCell74.Text = dt.Rows[13][0].ToString();
            xrTableCell75.Text = dt.Rows[13][1].ToString();
            xrTableCell121.Text = dt.Rows[13][2].ToString();

            xrTableCell84.Text = dt.Rows[14][0].ToString();
            xrTableCell85.Text = dt.Rows[14][1].ToString();
            xrTableCell122.Text = dt.Rows[14][2].ToString();

            xrTableCell94.Text = dt.Rows[15][0].ToString();
            xrTableCell95.Text = dt.Rows[15][1].ToString();
            xrTableCell123.Text = dt.Rows[15][2].ToString();

            xrTableCell104.Text = dt.Rows[16][0].ToString();
            xrTableCell105.Text = dt.Rows[16][1].ToString();
            xrTableCell124.Text = dt.Rows[16][2].ToString();

            xrTableCell79.Text = dt.Rows[17][0].ToString();
            xrTableCell80.Text = dt.Rows[17][1].ToString();
            xrTableCell125.Text = dt.Rows[17][2].ToString();
        }
    }
}
