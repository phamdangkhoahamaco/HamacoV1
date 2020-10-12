using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace HAMACO.Resources
{
    class InventoryItemCategory
    {
        gencon gen = new gencon();
        gencon_ta gen_ta = new gencon_ta();
        gencon_tn gen_tn = new gencon_tn();
        gencon_chk_tp gen_chk_tp = new gencon_chk_tp();
        gencon_chk_vt gen_chk_vt = new gencon_chk_vt();
        public void loadiic(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            string sql = "select * from InventoryItemCategory where Grade='" + 1 + "'";
            string max = gen.GetString("select max(Grade) from InventoryItemCategory");
            int maxi = int.Parse(max);
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã loại vật tư hàng hóa, công cụ dụng cụ", Type.GetType("System.String"));
            dt.Columns.Add("Tên loại vật tư hàng hóa, công cụ dụng cụ", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][5].ToString();
                dr[2] = temp.Rows[i][6].ToString();
                dt.Rows.Add(dr);
                if (temp.Rows[i][3].ToString() == "True")
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
                string sql = "select * from InventoryItemCategory where ParentID='"+pid+"'";
                da = gen.GetTable(sql);
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = kc+da.Rows[i][5].ToString();
                    dr[2] = da.Rows[i][6].ToString();
                    dt.Rows.Add(dr);
                    if (da.Rows[i][3].ToString() == "True")
                    {
                        int n=m+1;
                        dequy(n, max, dt, da.Rows[i][0].ToString(),kc);
                    }
                }
            }
        }

        public void tsbtiic(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            try
            {
                Frm_iic m = new Frm_iic();
                m.myac = new Frm_iic.ac(F.refreshiic);
                m.getactive(a);
                m.getuserid(userid);
                try
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    m.ShowDialog();
                }
                catch 
                {
                    m.getrole("");
                    m.ShowDialog();
                }
                
            }
            catch { MessageBox.Show("Vui lòng chọn loại vật tư hàng hóa, công cụ dụng cụ trước khi sửa."); }
        }

        public void find(string a, string b, string sql, Frm_iic F)
        {
            
            string m = gen.GetString("select Grade from InventoryItemCategory where InventoryCategoryID='" + a + "'");
            string max = gen.GetString( "select Grade from InventoryItemCategory where InventoryCategoryID='" + b + "'");
            int con = int.Parse(m);
            int cha = int.Parse(max);
            if (con >= cha)
            {
                if (a == b)
                {
                    MessageBox.Show("Không được chuyển mục này","HAMACO");
                }
                else
                {
                    a = gen.GetString("select ParentID from InventoryItemCategory where InventoryCategoryID='" + a + "'");
                    find(a, b, sql, F);
                }

            }
            else 
            {
                gen.ExcuteNonquery(sql);
                gen_ta.ExcuteNonquery(sql);
                gen_tn.ExcuteNonquery(sql);
                gen_chk_tp.ExcuteNonquery(sql);
                gen_chk_vt.ExcuteNonquery(sql);
                F.myac();
                F.Close();
            }
            
        }

        public void checkiic(string ac, TextBox a, TextBox b, string sql, Frm_iic F,string p, string r)
        {
            if (a.Text == "") MessageBox.Show("Mã loại vật tư hàng hóa, công cụ dụng cụ không được bỏ trống.", "HAMACO");
            else if (b.Text == "") MessageBox.Show("Tên loại vật tư hàng hóa, công cụ dụng cụ không được bỏ trống.", "HAMACO");
            else
            {
                if (ac == "1")
                {
                    find(p,r,sql,F);
                }
                else
                {
                    try
                    {
                        string kq = gen.GetString("select * from InventoryItemCategory where InventoryCategoryCode='" + a.Text + "'");
                        MessageBox.Show("Mã loại vật tư hàng hóa, công cụ dụng cụ này đã tồn tại.", "HAMACO");
                    }
                    catch
                    {
                        gen.ExcuteNonquery(sql);
                        gen_ta.ExcuteNonquery(sql);
                        gen_tn.ExcuteNonquery(sql);
                        gen_chk_tp.ExcuteNonquery(sql);
                        gen_chk_vt.ExcuteNonquery(sql);
                        F.myac();
                        F.Close();
                    }
                }
            }
        }

        public void tsbtdeleteiic(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa loại vật tư hàng hóa, công cụ dụng cụ " + view.GetRowCellValue(view.FocusedRowHandle, "Mã loại vật tư hàng hóa, công cụ dụng cụ").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from InventoryItemCategory where InventoryCategoryID='" + name + "'");
                    gen_ta.ExcuteNonquery("delete from InventoryItemCategory where InventoryCategoryID='" + name + "'");
                    gen_tn.ExcuteNonquery("delete from InventoryItemCategory where InventoryCategoryID='" + name + "'");
                    gen_chk_tp.ExcuteNonquery("delete from InventoryItemCategory where InventoryCategoryID='" + name + "'");
                    gen_chk_vt.ExcuteNonquery("delete from InventoryItemCategory where InventoryCategoryID='" + name + "'");
                    //F.refreshiic();
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn loại vật tư hàng hóa, công cụ dụng cụ trước khi xóa."); }
        }
    }
}
