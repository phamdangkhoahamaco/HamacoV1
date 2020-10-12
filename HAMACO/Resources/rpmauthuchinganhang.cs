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
    public partial class rpmauthuchinganhang : DevExpress.XtraReports.UI.XtraReport
    {
        public rpmauthuchinganhang()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string phieu, string mauso, string sophieu, string kho, string congty, string nguoinop, string diachi
           , string lydo, string sotien, string sotienchu, string chungtugoc, string hoten, DataTable dttien, DataTable dttk)
        {
            if (phieu == "PHIẾU KẾ TOÁN")
                xrTableCell60.Text = "Người lập phiếu";
            xrLabel11.Text = nguoinop;
            xrLabel7.Text = mauso;
            xrLabel9.Text = "Số: " + sophieu;
            xrLabel6.Text = kho;
            xrLabel2.Text = phieu;
            xrLabel13.Text = diachi;
            xrLabel15.Text = lydo;
            xrLabel19.Text = chungtugoc;
            xrLabel21.Text = sotienchu;
            xrLabel4.Text = hoten;
            xrLabel17.Text = String.Format("{0:n0}", Double.Parse(sotien));
            xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            if (dttien.Rows[0][0].ToString() != "")
            {
                xrTableCell1.Text = dttien.Rows[0][0].ToString();
                xrTableCell4.Text = dttien.Rows[0][1].ToString();
                xrTableCell5.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[0][2].ToString()));
            }

            if (dttien.Rows[1][0].ToString() != "")
            {
                xrTableCell10.Text = dttien.Rows[1][0].ToString();
                xrTableCell12.Text = dttien.Rows[1][1].ToString();
                xrTableCell13.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[1][2].ToString()));
            }

            if (dttien.Rows[2][0].ToString() != "")
            {
                xrTableCell14.Text = dttien.Rows[2][0].ToString();
                xrTableCell15.Text = dttien.Rows[2][1].ToString();
                xrTableCell16.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[2][2].ToString()));
            }

            if (dttien.Rows[3][0].ToString() != "")
            {
                xrTableCell17.Text = dttien.Rows[3][0].ToString();
                xrTableCell18.Text = dttien.Rows[3][1].ToString();
                xrTableCell19.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[3][2].ToString()));
            }

            if (dttien.Rows[4][0].ToString() != "")
            {
                xrTableCell23.Text = dttien.Rows[4][0].ToString();
                xrTableCell24.Text = dttien.Rows[4][1].ToString();
                xrTableCell25.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[4][2].ToString()));
            }

            if (dttien.Rows[5][0].ToString() != "")
            {
                xrTableCell20.Text = dttien.Rows[5][0].ToString();
                xrTableCell21.Text = dttien.Rows[5][1].ToString();
                xrTableCell22.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[5][2].ToString()));
            }

            if (dttien.Rows[6][0].ToString() != "")
            {
                xrTableCell26.Text = dttien.Rows[6][0].ToString();
                xrTableCell27.Text = dttien.Rows[6][1].ToString();
                xrTableCell28.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[6][2].ToString()));
            }

            if (dttien.Rows[7][0].ToString() != "")
            {
                xrTableCell29.Text = dttien.Rows[7][0].ToString();
                xrTableCell30.Text = dttien.Rows[7][1].ToString();
                xrTableCell31.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[7][2].ToString()));
            }

            if (dttien.Rows[8][0].ToString() != "")
            {
                xrTableCell32.Text = dttien.Rows[8][0].ToString();
                xrTableCell33.Text = dttien.Rows[8][1].ToString();
                xrTableCell34.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[8][2].ToString()));
            }

            if (dttien.Rows[9][0].ToString() != "")
            {
                xrTableCell35.Text = dttien.Rows[9][0].ToString();
                xrTableCell36.Text = dttien.Rows[9][1].ToString();
                xrTableCell37.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[9][2].ToString()));
            }

            if (dttien.Rows[10][0].ToString() != "")
            {
                xrTableCell38.Text = dttien.Rows[10][0].ToString();
                xrTableCell39.Text = dttien.Rows[10][1].ToString();
                xrTableCell40.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[10][2].ToString()));
            }

            if (dttien.Rows[11][0].ToString() != "")
            {
                xrTableCell41.Text = dttien.Rows[11][0].ToString();
                xrTableCell42.Text = dttien.Rows[11][1].ToString();
                xrTableCell43.Text = String.Format("{0:n0}", Double.Parse(dttien.Rows[11][2].ToString()));
            }

            if (dttk.Rows[0][0].ToString() != "")
            {
                xrTableCell2.Text = dttk.Rows[0][2].ToString();
                xrTableCell7.Text = dttk.Rows[0][0].ToString();
                xrTableCell8.Text = String.Format("{0:n0}", Double.Parse(dttk.Rows[0][1].ToString()));
            }

            if (dttk.Rows[1][0].ToString() != "")
            {
                xrTableCell44.Text = dttk.Rows[1][0].ToString();
                xrTableCell45.Text = String.Format("{0:n0}", Double.Parse(dttk.Rows[1][1].ToString()));
            }

            if (dttk.Rows[2][0].ToString() != "")
            {
                xrTableCell46.Text = dttk.Rows[2][0].ToString();
                xrTableCell47.Text = String.Format("{0:n0}", Double.Parse(dttk.Rows[2][1].ToString()));
            }

            if (dttk.Rows[3][0].ToString() != "")
            {
                xrTableCell48.Text = dttk.Rows[3][0].ToString();
                xrTableCell49.Text = String.Format("{0:n0}", Double.Parse(dttk.Rows[3][1].ToString()));
            }

            if (dttk.Rows[4][0].ToString() != "")
            {
                xrTableCell50.Text = dttk.Rows[4][0].ToString();
                xrTableCell51.Text = String.Format("{0:n0}", Double.Parse(dttk.Rows[4][1].ToString()));
            }

            if (dttk.Rows[5][0].ToString() != "")
            {
                xrTableCell52.Text = dttk.Rows[5][0].ToString();
                xrTableCell53.Text = String.Format("{0:n0}", Double.Parse(dttk.Rows[5][1].ToString()));
            }

            if (dttk.Rows[6][0].ToString() != "")
            {
                xrTableCell54.Text = dttk.Rows[6][0].ToString();
                xrTableCell55.Text = String.Format("{0:n0}", Double.Parse(dttk.Rows[6][1].ToString()));
            }

            xrTableCell57.Text = String.Format("{0:n0}", Double.Parse(sotien));

            this.PageHeight = 570;
        }

    }
}
