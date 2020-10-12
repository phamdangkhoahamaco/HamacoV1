using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
namespace HAMACO.Resources
{
    public partial class rpluuchuyentiente : DevExpress.XtraReports.UI.XtraReport
    {
        public rpluuchuyentiente()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay,string denngay)
        {
            string thangso = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            string namso = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();
            string thangtruoc= DateTime.Parse(tungay).Month.ToString();
            string thang = DateTime.Parse(denngay).Month.ToString();
            string nam = DateTime.Parse(denngay).Year.ToString();

            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            if (thangtruoc == thang)
                xrTableCell31.Text = "Tháng " + thang + " Năm " + nam;
            else if (thangtruoc == "1" && thang == "3")
                xrTableCell31.Text = "Quý " + 1 + " - " + nam;
            else if (thangtruoc == "4" && thang == "6")
                xrTableCell31.Text = "Quý " + 2 + " - " + nam;
            else if (thangtruoc == "7" && thang == "9")
                xrTableCell31.Text = "Quý " + 3 + " - " + nam;
            else if (thangtruoc == "10" && thang == "12")
                xrTableCell31.Text = "Quý " + 4 + " - " + nam;
            else if (thangtruoc == "1" && thang == "12")
                xrTableCell31.Text = "Năm " + nam;
            else
                xrTableCell31.Text = "Tháng " + thangtruoc + " - " + thang + " Năm " + nam;

            DataTable temp = new DataTable();
            temp = gen.GetTable("tonghopluuchuyentiente '" + thangso + "', '" + namso + "','" + thangtruoc + "','" + thang + "','" + nam + "'");
            DataTable dt = new DataTable();
            dt.Columns.Add("Tiền", Type.GetType("System.String"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                {
                    if (Double.Parse(temp.Rows[i][1].ToString()) < 0)
                    {
                        dr[0] = "(" + String.Format("{0:n0}", 0 - Double.Parse(temp.Rows[i][1].ToString())) + ")";
                    }
                    else
                    {
                        dr[0] = String.Format("{0:n0}", Double.Parse(temp.Rows[i][1].ToString()));
                    }
                }
                else
                {
                    dr[0] = "-";
                }
                dt.Rows.Add(dr);
            }

            xrTableCell3.Text = dt.Rows[0][0].ToString();
            xrTableCell6.Text = dt.Rows[1][0].ToString();
            xrTableCell12.Text = dt.Rows[2][0].ToString();
            xrTableCell15.Text = dt.Rows[3][0].ToString();
            xrTableCell18.Text = dt.Rows[4][0].ToString();
            xrTableCell21.Text = dt.Rows[5][0].ToString();
            xrTableCell24.Text = dt.Rows[6][0].ToString();
            xrTableCell27.Text = dt.Rows[7][0].ToString();

            xrTableCell36.Text = dt.Rows[8][0].ToString();
            xrTableCell39.Text = dt.Rows[9][0].ToString();
            xrTableCell42.Text = dt.Rows[10][0].ToString();
            xrTableCell45.Text = dt.Rows[11][0].ToString();
            xrTableCell48.Text = dt.Rows[12][0].ToString();
            xrTableCell51.Text = dt.Rows[13][0].ToString();
            xrTableCell54.Text = dt.Rows[14][0].ToString();
            xrTableCell57.Text = dt.Rows[15][0].ToString();

            xrTableCell63.Text = dt.Rows[16][0].ToString();
            xrTableCell66.Text = dt.Rows[17][0].ToString();
            xrTableCell69.Text = dt.Rows[18][0].ToString();
            xrTableCell72.Text = dt.Rows[19][0].ToString();
            xrTableCell75.Text = dt.Rows[20][0].ToString();
            xrTableCell78.Text = dt.Rows[21][0].ToString();
            xrTableCell84.Text = dt.Rows[22][0].ToString();

            xrTableCell81.Text = dt.Rows[23][0].ToString();
            xrTableCell87.Text = dt.Rows[24][0].ToString();
            xrTableCell90.Text = dt.Rows[25][0].ToString();
            xrTableCell93.Text = dt.Rows[26][0].ToString();
        }
    }
}
