using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpketquakinhdoanhtonghop : DevExpress.XtraReports.UI.XtraReport
    {
        public rpketquakinhdoanhtonghop()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string tungay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = "BÁO CÁO KẾT QUẢ KINH DOANH TỔNG HỢP ";
            if (DateTime.Parse(tungay).Month == DateTime.Parse(ngaychungtu).Month)
            {
                xrLabel2.Text = xrLabel2.Text + "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
                xrLabel4.Text = "Kết quả kinh doanh tổng hợp tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            }
            else
            {
                xrLabel2.Text = xrLabel2.Text + "TỪ THÁNG " + String.Format("{0:MM}", DateTime.Parse(tungay)) + " ĐẾN THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
                xrLabel4.Text = "Kết quả kinh doanh tổng hợp từ tháng " + String.Format("{0:MM}", DateTime.Parse(tungay)) + " đến tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            }
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }
        
        public void BindData(DataTable temp, string tudenngay, string ngaychungtu)
        {
            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 3; j++)
                {
                    if (Double.Parse(temp.Rows[i][j + 3].ToString()) != 0)
                        xrTable2.Rows[i].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j + 3].ToString()));
                    else
                        xrTable2.Rows[i].Cells[j + 1].Text = "";
                }
            }
            
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            temp = gen.GetTable("bangkeketquakinhdoanhtonghop '" + DateTime.Parse(tudenngay).Month + "','" + thang + "','" + nam + "',2");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count - 3; j++)
                {
                    if (Double.Parse(temp.Rows[i][j + 3].ToString()) != 0)
                        if (j == 0)
                            xrTable3.Rows[i].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j + 3].ToString()));
                        else
                            xrTable3.Rows[i].Cells[j + 1].Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][j + 3].ToString()) * 100) + "%";
                    else
                        xrTable3.Rows[i].Cells[j + 1].Text = "";
                }
            }
            
            DataTable TN = new DataTable();
            TN = gen.GetTable("bangkeketquakinhdoanhtonghop '" + DateTime.Parse(tudenngay).Month + "','" + thang + "','" + nam + "',3");
            for (int i = 0; i < TN.Rows.Count; i++)
            {
                for (int j = 1; j < TN.Columns.Count; j++)
                {
                    if (Double.Parse(TN.Rows[i][j].ToString()) != 0)
                    {
                        if (j == 1)
                            xrTable6.Rows[i].Cells[j].Text = String.Format("{0:n0}", Double.Parse(TN.Rows[i][j].ToString()));
                        else
                            if (i == 2)
                                xrTable6.Rows[i].Cells[j].Text = String.Format("{0:n2}", Double.Parse(TN.Rows[i][j].ToString())) + "%";
                    }
                    else
                        xrTable6.Rows[i].Cells[j].Text = "";
                }
            }

            DataTable TA = new DataTable();
            TA = gen.GetTable("bangkeketquakinhdoanhtonghop '" + DateTime.Parse(tudenngay).Month + "','" + thang + "','" + nam + "',4");
            for (int i = 0; i < TA.Rows.Count; i++)
            {
                for (int j = 1; j < TA.Columns.Count; j++)
                {
                    if (Double.Parse(TA.Rows[i][j].ToString()) != 0)
                    {
                        if (j == 1)
                            xrTable10.Rows[i].Cells[j].Text = String.Format("{0:n0}", Double.Parse(TA.Rows[i][j].ToString()));
                        else
                            if (i == 2)
                                xrTable10.Rows[i].Cells[j].Text = String.Format("{0:n2}", Double.Parse(TA.Rows[i][j].ToString())) + "%";
                    }
                    else
                        xrTable10.Rows[i].Cells[j].Text = "";
                }
            }

            DataTable TP = new DataTable();
            TP = gen.GetTable("bangkeketquakinhdoanhtonghop '" + DateTime.Parse(tudenngay).Month + "','" + thang + "','" + nam + "',5");
            for (int i = 0; i < TP.Rows.Count; i++)
            {
                for (int j = 1; j < TP.Columns.Count; j++)
                {
                    if (Double.Parse(TP.Rows[i][j].ToString()) != 0)
                    {
                        if (j == 1)
                            xrTable12.Rows[i].Cells[j].Text = String.Format("{0:n0}", Double.Parse(TP.Rows[i][j].ToString()));
                        else
                            if (i == 2)
                                xrTable12.Rows[i].Cells[j].Text = String.Format("{0:n2}", Double.Parse(TP.Rows[i][j].ToString())) + "%";
                    }
                    else
                        xrTable12.Rows[i].Cells[j].Text = "";
                }
            }
            try
            {
            DataTable VT = new DataTable();
            VT = gen.GetTable("bangkeketquakinhdoanhtonghop '" + DateTime.Parse(tudenngay).Month + "','" + thang + "','" + nam + "',6");           
                for (int i = 0; i < VT.Rows.Count; i++)
                {
                    for (int j = 1; j < VT.Columns.Count; j++)
                    {
                        if (Double.Parse(VT.Rows[i][j].ToString()) != 0)
                        {
                            if (j == 1)
                                xrTable14.Rows[i].Cells[j].Text = String.Format("{0:n0}", Double.Parse(VT.Rows[i][j].ToString()));
                            else
                                if (i == 2)
                                    xrTable14.Rows[i].Cells[j].Text = String.Format("{0:n2}", Double.Parse(VT.Rows[i][j].ToString())) + "%";
                        }
                        else
                            xrTable14.Rows[i].Cells[j].Text = "";
                    }
                }
            }
            catch { }
        
            try
            {
                xrTableCell329.Text = xrTableCell182.Text;
                xrTableCell332.Text = xrTableCell441.Text;
                xrTableCell330.Text = xrTableCell269.Text;
                xrTableCell340.Text = String.Format("{0:n0}", Double.Parse(xrTableCell329.Text) + Double.Parse(xrTableCell332.Text) + Double.Parse(xrTableCell330.Text));
            }
            catch { }
        }
       
    }
}
