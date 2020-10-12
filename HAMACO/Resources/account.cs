using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace HAMACO.Resources
{
    class account
    {
        gencon gen = new gencon();
        gencon_vt gencon_vt = new gencon_vt();
        gencon_ta gen_ta = new gencon_ta();
        gencon_tn gen_tn = new gencon_tn();
        gencon_chk_tp gen_tp = new gencon_chk_tp();
        gencon_chk_vt gen_vt = new gencon_chk_vt();
        gencon_vithanh gen_vithanh = new gencon_vithanh();

        public void loadaccount(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view )
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            view.Columns.Clear();
            string sql = "select * from Account where Grade='" + 1 + "' order by AccountNumber";
            string max = gen.GetString("select max(Grade) from Account");
            int maxi = int.Parse(max);
            temp = gen.GetTable(sql);
            int count = temp.Rows.Count;
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tiếng anh", Type.GetType("System.String"));
            dt.Columns.Add("Nhóm tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tính chất", Type.GetType("System.String"));
            dt.Columns.Add("Ngừng theo dõi", Type.GetType("System.Boolean"));
            for (int i = 0; i < count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][17].ToString();
                dr[4] = temp.Rows[i][7].ToString();
                if (temp.Rows[i][8].ToString() == "0") dr[5] = "Dư nợ";
                else if (temp.Rows[i][8].ToString() == "1") dr[5] = "Dư có";
                else if (temp.Rows[i][8].ToString() == "2") dr[5] = "Lưỡng tính";
                else dr[5] = "Không có số dư";
                dr[6] = temp.Rows[i][13].ToString();
                dt.Rows.Add(dr);
                if (temp.Rows[i][6].ToString() == "True")
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

            view.Columns["Nhóm tài khoản"].GroupIndex = 0;
            view.ExpandAllGroups();
           
            /*GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "ProductName";
            item.DisplayFormat = "  Số dòng {0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Tính chất"];*/

        }


        public void dequy(int m, int max, DataTable dt, string pid, string kc)
        {
            if (m < max)
            {
                kc = kc + "      ";
                DataTable da = new DataTable();
                string sql = "select * from Account where ParentID='" + pid + "' order by AccountNumber";
                da = gen.GetTable(sql);
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = kc+da.Rows[i][1].ToString();
                    dr[2] = da.Rows[i][2].ToString();
                    dr[3] = da.Rows[i][17].ToString();
                    dr[4] = da.Rows[i][7].ToString();
                    if (da.Rows[i][8].ToString() == "0") dr[5] = "Dư nợ";
                    else if (da.Rows[i][8].ToString() == "1") dr[5] = "Dư có";
                    else if (da.Rows[i][8].ToString() == "2") dr[5] = "Lưỡng tính";
                    else dr[5] = "Không có số dư";
                    dr[6] = da.Rows[i][13].ToString();
                    dt.Rows.Add(dr);
                    if (da.Rows[i][6].ToString() == "True")
                    {
                        int n = m + 1;
                        dequy(n, max, dt, da.Rows[i][0].ToString(), kc);
                    }
                }
            }
        }

        public void tsbthttk(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            /*try
            {*/
                Frm_account u = new Frm_account();
                u.myac = new Frm_account.ac(F.refreshaccount);
                u.getactive(a);
                u.getuserid(userid);
                u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                u.ShowDialog();
            /*}
            catch { MessageBox.Show("Vui lòng chọn tài khoản trước khi sửa hoặc thêm."); }*/
        }

        public void checkaccount(string a, string sql, Frm_account F)
        {
            if (a == "") MessageBox.Show("Tên tài khoản không được bỏ trống.", "HAMACO");
            else
            {
                gen.ExcuteNonquery(sql);
                //gencon_vt.ExcuteNonquery(sql);
                //gen_ta.ExcuteNonquery(sql);
                //gen_tn.ExcuteNonquery(sql);
                //gen_tp.ExcuteNonquery(sql);
                //gen_vt.ExcuteNonquery(sql);
                //gen_vithanh.ExcuteNonquery(sql);
                F.myac();
                F.Close();
            }
        }

        public void deleteaccount(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa " + view.GetRowCellValue(view.FocusedRowHandle, "Số tài khoản").ToString().Trim() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from Account where AccountID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn tài khoản trước khi xóa."); }
        }
    }
}
