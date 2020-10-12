using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace HAMACO.Resources
{
    class branch
    {
        gencon gen = new gencon();
        public void loadbranch(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
           
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable("Select * from Branch where Grade='" + 1 + "' order by BranchCode");
            string max = gen.GetString("select max(Grade) from Branch");
            int maxi = int.Parse(max);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Tên đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dt.Rows.Add(dr);
                if (temp.Rows[i][7].ToString() == "True")
                {
                    string kc = "";
                    dequy(1, maxi, dt, temp.Rows[i][0].ToString(), kc);
                }
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; 
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
           
        }

        public void dequy(int m, int max, DataTable dt, string pid, string kc)
        {
            if (m < max)
            {
                kc = kc + "      ";
                DataTable da = new DataTable();
                string sql = "select * from Branch where Parent='" + pid + "' order by BranchCode";
                da = gen.GetTable(sql);
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = kc + da.Rows[i][1].ToString();
                    dr[2] = da.Rows[i][2].ToString();
                    dr[3] = da.Rows[i][3].ToString();
                    dt.Rows.Add(dr);
                    if (da.Rows[i][7].ToString() == "True")
                    {
                        int n = m + 1;
                        dequy(n, max, dt, da.Rows[i][0].ToString(), kc);
                    }
                }
            }
        }


        public void tsbtbranch(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            try
            {
                Frm_branch m = new Frm_branch();
                m.myac = new Frm_branch.ac(F.refreshbranch);
                m.getactive(a);
                m.getuserid(userid);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                m.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn đơn vị trước khi sửa."); }
        }

        public void checkbranch(string ac, TextBox a, TextBox b, Frm_branch F, DevExpress.XtraEditors.LookUpEdit ledv, TextBox txtdg, RadioButton radioButton1, string role, DevExpress.XtraEditors.LookUpEdit lekho, DevExpress.XtraEditors.LookUpEdit leprovince, TextBox txtmst)
        {
            if (a.Text == "") MessageBox.Show("Mã đơn vị không được bỏ trống.", "HAMACO");
            else if (b.Text == "") MessageBox.Show("Tên đơn vị không được bỏ trống.", "HAMACO");
            else
            {
                string sql, dv;
                string th = radioButton1.Checked.ToString();
                string kho = gen.GetString("select * from Stock where StockCode='" + lekho.EditValue + "'");
                if (ac == "1")
                {
                    try
                    {
                        dv = ledv.EditValue.ToString();
                        DataTable temp = new DataTable();
                        temp = gen.GetTable("select * from Branch where BranchCode='" + dv + "'");
                        dv = temp.Rows[0][0].ToString();
                        int bac = Int32.Parse(temp.Rows[0][9].ToString()) + 1;
                        sql = "update Branch set BranchCode=N'" + a.Text + "', BranchName=N'" + b.Text + "',Description=N'" + txtdg.Text + "',IsDependent='" + th + "',Parent='" + dv + "',Grade=" + bac + ",StockBranch='"+kho+"',Province='"+leprovince.EditValue.ToString()+"',Code='"+txtmst.Text+"' where BranchID='" + role + "'";
                        gen.ExcuteNonquery("update Branch set IsParent='True' where BranchID='" + dv + "'");
                    }
                    catch
                    {
                        sql = "update Branch set BranchCode=N'" + a.Text + "', BranchName=N'" + b.Text + "',Description=N'" + txtdg.Text + "',IsDependent='" + th + "',Parent=NULL,Grade=1,StockBranch='"+kho+"',Province='"+leprovince.EditValue.ToString()+"',Code='"+txtmst.Text+"' where BranchID='" + role + "'";
                    }     
                    gen.ExcuteNonquery(sql);
                    F.myac();
                    F.Close();
                }
                else
                {
                    try
                    {
                        string kq = gen.GetString("select * from Branch where BranchCode='" + a.Text + "'");
                        MessageBox.Show("Mã đơn vị này đã tồn tại.", "HAMACO");
                    }
                    catch 
                    {
                        try
                        {
                            dv = ledv.EditValue.ToString();
                            DataTable temp = new DataTable();
                            temp = gen.GetTable("select * from Branch where BranchCode='" + dv + "'");
                            dv = temp.Rows[0][0].ToString();
                            int bac = Int32.Parse(temp.Rows[0][9].ToString()) + 1;
                            sql = "insert into Branch values(newid(),'" + a.Text + "',N'" + b.Text + "',N'" + txtdg.Text + "','" + th + "','False','False','False','" + dv + "'," + bac + ",'"+kho+"','"+leprovince.EditValue.ToString()+"','"+txtmst.Text+"')";
                            gen.ExcuteNonquery("update Branch set IsParent='True' where BranchID='" + dv + "'");
                        }
                        catch
                        {
                            sql = "insert into Branch values(newid(),'" + a.Text + "',N'" + b.Text + "',N'" + txtdg.Text + "','" + th + "','False','False','False',NULL,1,'"+kho+"','"+leprovince.EditValue.ToString()+"','"+txtmst.Text+"')";
                        }
                        gen.ExcuteNonquery(sql);
                        F.myac();
                        F.Close();
                    }
                }
            }
        }

        public void tsbtdeletebranch(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa đơn vị " + view.GetRowCellValue(view.FocusedRowHandle, "Mã đơn vị").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from Branch where BranchID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn đơn vị trước khi xóa."); }
        }
    }
}
