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
    public partial class rpketquathuhanghanghoa : DevExpress.XtraReports.UI.XtraReport
    {
        public rpketquathuhanghanghoa()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude( string ngaychungtu)
        {
            xrLabel3.Text = "BẢNG KÊ TIÊU THỤ HÀNG HÓA THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();   
            DataTable temp = new DataTable();
            
            temp = gen.GetTable("baocaoketquatieuthuhanghoa '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            int z = 0;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                while ((z + 1).ToString() != temp.Rows[i][temp.Columns.Count - 1].ToString())
                {
                    for (int j = 0; j < temp.Columns.Count - 1; j++)
                    {
                        xrTable7.Rows[z].Cells[j + 1].Text = "";
                    }
                    z++;
                }


                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {
                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        xrTable7.Rows[z].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable7.Rows[z].Cells[j + 1].Text = "";
                }
                z++;
            }
            
            temp = gen.GetTable("baocaoketquatieuthuhanghoagas '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {
                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        xrTable15.Rows[i+1].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable15.Rows[i+1].Cells[j + 1].Text = "";
                }
            }
            
            temp = gen.GetTable("baocaoketquatieuthuhanghoanhot '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {
                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        xrTable16.Rows[i + 1].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable16.Rows[i + 1].Cells[j + 1].Text = "";
                }
            }
        }

        public void gettieudetuthang(string ngaychungtu, string denngay)
        {
            xrLabel3.Text = "BẢNG KÊ TIÊU THỤ HÀNG HÓA TỪ THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " ĐẾN THÁNG " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));

            string thangtruoc = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(denngay).Year.ToString();

            string thang = DateTime.Parse(denngay).Month.ToString();
            string namtruoc = DateTime.Parse(denngay).AddYears(-1).Year.ToString();
            xrTableCell9.Text = xrTableCell153.Text = xrTableCell303.Text = xrTableCell333.Text = xrTableCell348.Text = xrTableCell378.Text = xrTableCell408.Text = xrTableCell438.Text = xrTableCell468.Text = xrTableCell498.Text = xrTableCell581.Text = "Tăng giảm so năm " + namtruoc + " (%)";
            
            DataTable temp = new DataTable();

            temp = gen.GetTable("baocaoketquatieuthuhanghoatuthang '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            int z = 0;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                while ((z + 1).ToString() != temp.Rows[i][temp.Columns.Count - 1].ToString())
                {
                    for (int j = 0; j < temp.Columns.Count - 1; j++)
                    {
                        xrTable7.Rows[z].Cells[j + 1].Text = "";
                    }
                    z++;
                }


                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {
                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        xrTable7.Rows[z].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable7.Rows[z].Cells[j + 1].Text = "";
                }
                z++;
            }

            temp = gen.GetTable("baocaoketquatieuthuhanghoagastuthang '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {
                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        xrTable15.Rows[i + 1].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable15.Rows[i + 1].Cells[j + 1].Text = "";
                }
            }

            temp = gen.GetTable("baocaoketquatieuthuhanghoanhottuthang '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {
                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        xrTable16.Rows[i + 1].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable16.Rows[i + 1].Cells[j + 1].Text = "";
                }
            }
        }
    }
}
