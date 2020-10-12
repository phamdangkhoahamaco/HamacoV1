using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
namespace HAMACO.Resources
{
    public partial class rpbaocaotinhhinhmuaban : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaotinhhinhmuaban()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string tungay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "BÁO CÁO TÌNH HÌNH MUA BÁN ";
            if (DateTime.Parse(tungay).Month == DateTime.Parse(ngaychungtu).Month)
                xrLabel2.Text = xrLabel2.Text + "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            else
                xrLabel2.Text = xrLabel2.Text + "TỪ THÁNG " + String.Format("{0:MM}", DateTime.Parse(tungay)) + " ĐẾN THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void BindData(DataTable temp, string tudenngay, string ngaychungtu)
        {
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {

                    if (Double.Parse(temp.Rows[i][j + 1].ToString()) != 0)
                    {
                        if (j == 3 || j == 7 || j == 8)
                            xrTable2.Rows[i].Cells[j + 1].Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][j + 1].ToString()))+"%";
                        else
                            xrTable2.Rows[i].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j + 1].ToString()));
                    }
                    else
                        xrTable2.Rows[i].Cells[j + 1].Text = "";
                }
            }
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            temp = gen.GetTable("baocaotinhhinhmuaban '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "',2");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {

                    if (Double.Parse(temp.Rows[i][j + 1].ToString()) != 0)
                        xrTable3.Rows[i].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j + 1].ToString()));
                    else
                        xrTable3.Rows[i].Cells[j + 1].Text = "";
                }
            }

            temp = gen.GetTable("baocaotinhhinhmuaban '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "',3");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count-1; j++)
                {
                    if (j == 1)
                    {
                        if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                            xrTable6.Rows[i].Cells[j].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                        else
                            xrTable6.Rows[i].Cells[j].Text = "";
                    }
                    else
                        xrTable6.Rows[i].Cells[j].Text = temp.Rows[i][j].ToString().ToUpper();
                }
            }

            temp = gen.GetTable("baocaotinhhinhmuaban '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "',4");
            xrTableCell260.Text = xrTableCell256.Text;
            xrTableCell262.Text = xrTableCell442.Text;
            Double tong=Double.Parse(xrTableCell260.Text)+Double.Parse(xrTableCell262.Text);
            if (Double.Parse(temp.Rows[0][0].ToString()) != 0)
            {
                xrTableCell264.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[0][0].ToString()));
                tong = tong + Double.Parse(temp.Rows[0][0].ToString());
            }
            xrTableCell266.Text = String.Format("{0:n0}", tong);


            temp = gen.GetTable("baocaotinhhinhmuaban '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "',5");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 1; j++)
                {
                    if (j >= 1)
                    {
                        if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                            xrTable10.Rows[i].Cells[j].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                        else
                            xrTable10.Rows[i].Cells[j].Text = "";
                    }
                    else
                        xrTable10.Rows[i].Cells[j].Text = temp.Rows[i][j].ToString().ToUpper();
                }
            }
        }
    }
}
