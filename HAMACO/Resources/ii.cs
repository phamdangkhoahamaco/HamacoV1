using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel.Design;

namespace HAMACO.Resources
{
    class ii
    {
        gencon gen = new gencon();
        //gencon_ta genta = new gencon_ta();
        //gencon_tn gentn = new gencon_tn();
        //gencon_chk_tp gentp = new gencon_chk_tp();
        //gencon_chk_vt genvt = new gencon_chk_vt();
        public void loadii(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {           
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã vật tư hàng hóa", Type.GetType("System.String"));
            dt.Columns.Add("Tên vật tư hàng hóa", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị quy đổi", Type.GetType("System.String"));
            dt.Columns.Add("Tỷ lệ", Type.GetType("System.Double"));
            dt.Columns.Add("Loại vật tư hàng hóa, công cụ dụng cụ", Type.GetType("System.String"));
            dt.Columns.Add("Ngừng theo dõi", Type.GetType("System.Boolean"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                if(temp.Rows[i][5].ToString()=="")
                    dr[5] = 1;
                else
                    dr[5] = temp.Rows[i][5].ToString();

                dr[6] = temp.Rows[i][6].ToString();

                if (temp.Rows[i][7].ToString() == "True")
                    dr[7] = "True";
                else
                    dr[7] = "False";
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Tỷ lệ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tỷ lệ"].DisplayFormat.FormatString = "{0:n2}";          

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
           
        }

        public void tsbtii(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            /*try
            {*/
                Frm_ii m = new Frm_ii();
                m.myac = new Frm_ii.ac(F.refreshii);
                m.getactive(a);
                m.getuserid(userid);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                m.ShowDialog();
            /*}
            catch { MessageBox.Show("Vui lòng chọn vật tư hàng hóa trước khi sửa."); }*/
        }

        public void loadiiccomtc(DevExpress.XtraEditors.LookUpEdit le,string ac,string vt)
        {         
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã tính chất", Type.GetType("System.String"));
            dt.Columns.Add("Tên tính chất", Type.GetType("System.String"));
                DataRow dr = dt.NewRow();
                dr[0] = "0";
                dr[1] = "Hàng hóa";
                dt.Rows.Add(dr);
                DataRow dr1 = dt.NewRow();
                dr1[0] = "1";
                dr1[1] = "Vật tư";
                dt.Rows.Add(dr1);
            le.Properties.DataSource = dt;
            le.Properties.DisplayMember = "Tên tính chất";
            le.Properties.ValueMember = "Mã tính chất";
            if (ac == "1")
            {
                try
                {
                    int a = Convert.ToInt32(vt);
                    le.ItemIndex = a;
                }
                catch
                {
                    le.EditValue="3";
                }
            }
            else le.ItemIndex = 0;
        }

        public void loadiimb(DevExpress.XtraEditors.LookUpEdit le)
        {
            le.Properties.PopupWidth = 400;
            DataTable da = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã bình", Type.GetType("System.String"));
            dt.Columns.Add("Tên bình", Type.GetType("System.String"));
            string sql = "select * from InventoryItem";
            da = gen.GetTable(sql);
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = da.Rows[i][2].ToString();
                dr[1] = da.Rows[i][4].ToString();
                dt.Rows.Add(dr);
            }
            le.Properties.DataSource = dt;
            le.Properties.DisplayMember = "Mã bình";
            le.Properties.ValueMember = "Mã bình";
        }

        public void loadiimbrole(DevExpress.XtraEditors.LookUpEdit le,string ma)
        {
            if (ma != "")
            {
                DataTable da = new DataTable();
                string sql = "select * from InventoryItem where InventoryItemID='"+ma+"'";
                da = gen.GetTable(sql);
                le.EditValue = da.Rows[0][2].ToString();
            }
        }

        public void loadiiccomthue(DevExpress.XtraEditors.LookUpEdit le, string ac, string vt)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã giá trị", Type.GetType("System.String"));
            dt.Columns.Add("Giá trị", Type.GetType("System.String"));
            DataRow dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "0%";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1[0] = "5";
            dr1[1] = "5%";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2[0] = "10";
            dr2[1] = "10%";
            dt.Rows.Add(dr2);
            le.Properties.DataSource = dt;
            le.Properties.DisplayMember = "Giá trị";
            le.Properties.ValueMember = "Mã giá trị";
            try
            {
                string[] a = vt.Split('.');
                if (a[0] == "0") 
                {
                    le.ItemIndex = 0;
                }
                else if (a[0] == "5")
                {
                    le.ItemIndex = 1;
                }
                else if (a[0] == "10")
                {
                    le.ItemIndex = 2;
                }
                else le.ItemIndex = 0;
            }
            catch 
            {
            }
        }

        public void loadiiccom(DevExpress.XtraEditors.LookUpEdit le,string role,string ac)
        {
            DataTable da = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã loại", Type.GetType("System.String"));
            dt.Columns.Add("Tên loại", Type.GetType("System.String"));
            string max = gen.GetString("select max(Grade) from InventoryItemCategory");
            int maxi = int.Parse(max);
            string sql = "select * from InventoryItemCategory where Grade='" + 1 + "'";
            da = gen.GetTable(sql);
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = da.Rows[i][5].ToString();
                dr[1] = da.Rows[i][6].ToString();
                dt.Rows.Add(dr);
                if (da.Rows[i][3].ToString() == "True")
                {
                    string kc = "";
                    dequy(1, maxi, da.Rows[i][0].ToString(), kc, dt);
                }
            }
            le.Properties.DataSource=dt;
            le.Properties.DisplayMember="Tên loại";
            le.Properties.ValueMember = "Mã loại";
            le.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            
            if (ac == "1")
            {
                da = gen.GetTable("select InventoryCategoryCode from InventoryItem a, InventoryItemCategory b where a.InventoryCategoryID=b.InventoryCategoryID and InventoryItemID='" + role + "'");
                int j = 0;
                foreach (DataRow r in dt.Rows)
                {
                    if (r[0].ToString().Trim() == da.Rows[0][0].ToString())
                    {
                        break;
                    }
                    j++;
                }
                le.ItemIndex = j;
            }
            else  le.ItemIndex=0; 
        }

        public void dequy(int m, int max, string pid, string kc, DataTable dt)
        {
            if (m < max)
            {
                kc = kc + "      ";
                DataTable da = new DataTable();
                string sql = "select * from InventoryItemCategory where ParentID='" + pid + "'";
                da = gen.GetTable(sql);
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] =kc+ da.Rows[i][5].ToString();
                    dr[1] = da.Rows[i][6].ToString();
                    dt.Rows.Add(dr);
                    if (da.Rows[i][3].ToString() == "True")
                    {
                        int n = m + 1;
                        dequy(n, max, da.Rows[i][0].ToString(), kc, dt);
                    }
                }
            }
        }


        public void checkii(string ac, DevExpress.XtraEditors.TextEdit a, DevExpress.XtraEditors.TextEdit b, string sql, Frm_ii F)
        {
            try
            {
                string kq = gen.GetString("select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + a.Text + "'");
                MessageBox.Show("Mã vật tư, hàng hóa này đã tồn tại.", "HAMACO");
            }
            catch
            {
                gen.ExcuteNonquery(sql);
                gen.ExcuteNonquery("insert into hamaco_ta.dbo.InventoryItem select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + a.Text + "'");
                gen.ExcuteNonquery("insert into hamaco_tn.dbo.InventoryItem select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + a.Text + "'");
                gen.ExcuteNonquery("insert into hamaco_vithanh.dbo.InventoryItem select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + a.Text + "'");
                gen.ExcuteNonquery("insert into hamaco_qlk.dbo.InventoryItem select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + a.Text + "'");
                F.myac();
                F.Close();
            }
        }

        public void tsbtdeleteii(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa vật tư hàng hóa " + view.GetRowCellValue(view.FocusedRowHandle, "Mã vật tư hàng hóa").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from InventoryItem where InventoryItemID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn vật tư hàng hóa trước khi xóa."); }
        }

    }
}
