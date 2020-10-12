using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace HAMACO.Resources
{
    class mscrole
    {
        gencon gen = new gencon();
        //click vào danh sách phân quyền đổi nội dung của tab
        public void changetabrole(ListView lvinfo, ListView lvuser, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                DataTable da = new DataTable();
                string info = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                lvinfo.Clear();
                lvinfo.Columns.Add("", 180);
                lvinfo.Columns.Add("", 180);
                lvinfo.View = View.Details;
                da = gen.GetTable("select * from MSC_Role where RoleID = '" + info + "'");
                ListViewItem item1;
                item1 = new ListViewItem("Mã vai trò");
                item1.SubItems.Add(da.Rows[0][1].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Tên vai trò");
                item1.SubItems.Add(da.Rows[0][2].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Diễn giải");
                item1.SubItems.Add(da.Rows[0][3].ToString());
                lvinfo.Items.Add(item1);
                lvuser.Clear();
                lvuser.Columns.Add("Tên đăng nhập", 180);
                lvuser.Columns.Add("Họ và tên", 180);
                lvuser.Columns.Add("Diễn giải", 180);
                lvuser.View = View.Details;
                da = gen.GetTable("select b.UserJoinRoleID,c.UserName,c.FullName,c.Description from MSC_UserJoinRole b,MSC_User c where b.RoleID = '" + info + "' and b.UserID=c.UserID");
                ListViewItem item2;
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    item2 = new ListViewItem(da.Rows[i][1].ToString());
                    item2.SubItems.Add(da.Rows[0][2].ToString());
                    item2.SubItems.Add(da.Rows[0][3].ToString());
                    item2.Name = da.Rows[0][0].ToString();
                    lvuser.Items.Add(item2);
                }
                gen.ResizeListViewColumns(lvuser);
            }
            catch { }
        }
        //
        //dữ liệu phân quyền
        public void loadrole(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view,string sql)
        {
           
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã vai trò", Type.GetType("System.String"));
            dt.Columns.Add("Tên vai trò", Type.GetType("System.String"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
      
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
           
        }
        ////
        //cây phân cấp level 3
        /*public void tvlevel3(TreeView tvmsc, int level, int level1, int level2, int level3, int k, DataTable dachil1)
        {
            DataTable dachil2 = new DataTable();
            tvmsc.Nodes[level].Nodes[level1].Nodes[level2].Nodes.Add(dachil1.Rows[k][0].ToString(), dachil1.Rows[k][1].ToString());
            string id2 = dachil1.Rows[k][0].ToString();
            dachil2 = gen.GetTable("select * from MSC_SubSystem where ParentSubSystemCode = '" + id2 + "' order by SortOrder ");
            int countchil2 = dachil2.Rows.Count;
            for (int l = 0; l < countchil2; l++)
            {
                tvmsc.Nodes[level].Nodes[level1].Nodes[level2].Nodes[level3].Nodes.Add(dachil2.Rows[l][0].ToString(), dachil2.Rows[l][1].ToString());
            }
        }
        //câp phân cấp level 2
        public void tvlevel2(TreeView tvmsc, int level, int level1, int level2, int j, DataTable dachil)
        {
            DataTable dachil1 = new DataTable();
            tvmsc.Nodes[level].Nodes[level1].Nodes.Add(dachil.Rows[j][0].ToString(), dachil.Rows[j][1].ToString());
            string id1 = dachil.Rows[j][0].ToString();
            dachil1 = gen.GetTable("select * from MSC_SubSystem where ParentSubSystemCode = '" + id1 + "' order by SortOrder ");
            int countchil1 = dachil1.Rows.Count;
            int level3 = 0;
            for (int k = 0; k < countchil1; k++)
            {
                tvlevel3(tvmsc, level, level1, level2, level3, k, dachil1);
                level3++;
            }
        }
        /////
        //cây phân cấp level 1
        //
        public void tvlevel1( TreeView tvmsc,int level,int level1,int i, DataTable da)
        {
            DataTable dachil = new DataTable();
            tvmsc.Nodes[level].Nodes.Add(da.Rows[i][0].ToString(), da.Rows[i][1].ToString());
            string id = da.Rows[i][0].ToString();
            dachil = gen.GetTable("select * from MSC_SubSystem where ParentSubSystemCode = '" + id + "' order by SortOrder ");
            int countchil = dachil.Rows.Count;
            int level2 = 0;
            for (int j = 0; j < countchil; j++)
            {
                tvlevel2(tvmsc, level, level1, level2, j, dachil);
                level2++;
            }
        }

        */

        public void tvlevel(TreeView tvmsc, int level, int level1, DataTable temp,string cha,string tencha)
        {
            int level2 = 0;
            tvmsc.Nodes[level].Nodes.Add(cha,tencha);
            for (int j = 0; j < temp.Rows.Count; j++)
            {
                if (temp.Rows[j][3].ToString() == cha)
                {
                    tvlevel11(tvmsc, level, level1,level2, temp, temp.Rows[j][0].ToString(), temp.Rows[j][1].ToString());
                    level2++;
                }
            }
        }

        public void tvlevel11(TreeView tvmsc, int level, int level1, int level2,DataTable temp, string cha,string tencha)
        {
            int level3 = 0;
            tvmsc.Nodes[level].Nodes[level1].Nodes.Add(cha,tencha);
            for (int k = 0; k < temp.Rows.Count; k++)
            {
                if (temp.Rows[k][3].ToString() == cha)
                {
                    tvlevel111(tvmsc, level, level1,level2,level3, temp, temp.Rows[k][0].ToString(), temp.Rows[k][1].ToString());
                    level3++;
                }
            }
        }

        public void tvlevel111(TreeView tvmsc, int level, int level1, int level2, int level3, DataTable temp,string cha,string tencha)
        {
            tvmsc.Nodes[level].Nodes[level1].Nodes[level2].Nodes.Add(cha, tencha);
            for (int m = 0; m < temp.Rows.Count; m++)
            {
                if (temp.Rows[m][3].ToString() == cha)
                {
                    tvmsc.Nodes[level].Nodes[level1].Nodes[level2].Nodes[level3].Nodes.Add(temp.Rows[m][0].ToString(), temp.Rows[m][1].ToString());
                }
            }
        }

        //tạo listview phân quyền cho cây phân quyền
        public void lvmscrole(DataTable da,string ex,int start,ListView lvmsc,string[,] mscstr)
        {
            da = gen.GetTable("select b.PermissionID,b.PermissionName,a.SubSystemCode from MSC_RegisPermisionForSubSystem a, MSC_Permission b where SubSystemCode = '" + ex + "' and a.PermissionID=b.PermissionID");
            lvmsc.Clear();
            lvmsc.Columns.Add("Chọn", 80, HorizontalAlignment.Center);
            lvmsc.Columns.Add("Tên", 167);
            lvmsc.View = View.Details;
            ListViewItem item;
            int count = da.Rows.Count;
            for (int i = 0; i < count; i++)
            {

                item = new ListViewItem("");
                item.SubItems.Add(da.Rows[i][1].ToString());
                item.Name = da.Rows[i][0].ToString();

                for (int j = 0; j < start; j++)
                {
                    if (da.Rows[i][2].ToString() == mscstr[j, 0] && da.Rows[i][0].ToString() == mscstr[j, 1] && mscstr[j, 2] == "1")
                    {
                        item.Checked = true;
                    }
                }
                lvmsc.Items.Add(item);
            }
        }

        //luu trữ những thay dổi khi check
        public void checkinfo(string a, string b,string sql, FRM_MSCROLE F,string c,string role)
        {
            if (a == "")   MessageBox.Show("Mã vai trò không được bỏ trống.", "HAMACO");
            else if (b == "") MessageBox.Show("Tên vai trò không được bỏ trống.", "HAMACO");
            else
            {

                if (c == "0")
                {
                    try
                    {
                        string kq = gen.GetString("select * from MSC_Role where RoleCode='" + a + "'");
                        MessageBox.Show("Vai trò này đã tồn tại.", "HAMACO");                       
                    }
                    catch 
                    {
                        gen.ExcuteNonquery(sql);
                        string id = gen.GetString("select * from MSC_Role where RoleCode='" + a + "'");
                        DataTable da = new DataTable();
                        da = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='"+role+"'");
                        for (int i = 0; i < da.Rows.Count; i++)
                        {
                            gen.ExcuteNonquery("insert into MSC_RolePermissionMaping values(newid(),'"+da.Rows[i][1].ToString()+"','"+id+"','"+da.Rows[i][3].ToString()+"')");
                        }
                        F.myac();
                        F.Close();
                    }
                }
                else 
                {
                    gen.ExcuteNonquery(sql);
                    F.myac();
                    F.Close();
                }
                
            }
        }
        //kiểm tra xem có chọn chưa và được phép phân quyền
        public void tstbmsc(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() != "b7e767cb-2731-434c-a513-61ed7497db6f")
                {
                    MSC F = new MSC();
                    F.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    F.Show();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không được phân quyền cho ADMIN.", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch
            {
               DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn nhóm trước khi phân quyền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }        
        }
        //tsbt chức năng sửa và thêm
        public void tstbcnmsc(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            try
            {
                FRM_MSCROLE m = new FRM_MSCROLE();
                m.myac = new FRM_MSCROLE.ac(F.refreshmsc);
                m.getactive(a);
                m.getuserid(userid);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                else
                {
                    try
                    {
                        m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    catch { }
                }
                m.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn nhóm trước khi sửa."); }
        }
        //chức năng xóa
        public void tstbdelete(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa " + view.GetRowCellValue(view.FocusedRowHandle, "Mã vai trò").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from MSC_Role where RoleID='" + name + "'");
                    gen.ExcuteNonquery("delete from MSC_RolePermissionMaping where RoleID='" + name + "'");
                    //F.refreshmsc();
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn nhóm trước khi xóa."); }
        }
        //liệt kê danh sách người dùng//////////////////////////////////////////
        public void loaduser(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable("select a.UserID,UserName,FullName,Email,MobilePhone,BranchName,RoleName from (Select UserID,UserName,FullName,Email,MobilePhone,BranchName from MSC_User a, Branch b where a.BranchID=b.BranchID) a left join (select RoleName,UserID from MSC_Role a, MSC_UserJoinRole b where a.RoleID=b.RoleID) b on a.UserID=b.UserID order by BranchName,FullName");
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Họ và tên", Type.GetType("System.String"));
            dt.Columns.Add("Tên đăng nhập", Type.GetType("System.String"));
            dt.Columns.Add("Email", Type.GetType("System.String"));
            dt.Columns.Add("Di động", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Vai trò", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][2].ToString();
                dr[2] = temp.Rows[i][1].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dr[6] = temp.Rows[i][6].ToString();
                dt.Rows.Add(dr);
            }
            
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
     
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
           
        }
        //liệt kê nội dung của user và vai trò của nó
        public void changetabuser(ListView lvinfo, ListView lvuser, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                DataTable da = new DataTable();
                string info = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                lvinfo.Clear();
                lvinfo.Columns.Add("", 180);
                lvinfo.Columns.Add("", 180);
                lvinfo.View = View.Details;
                da = gen.GetTable("select * from MSC_User where UserID = '" + info + "'");
                ListViewItem item1;
                item1 = new ListViewItem("Họ và tên");
                item1.SubItems.Add(da.Rows[0][5].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Chức danh");
                item1.SubItems.Add(da.Rows[0][4].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("ĐT cơ quan");
                item1.SubItems.Add(da.Rows[0][11].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Fax");
                item1.SubItems.Add(da.Rows[0][14].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Email");
                item1.SubItems.Add(da.Rows[0][9].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("ĐC cơ quan");
                item1.SubItems.Add(da.Rows[0][15].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("ĐC nhà riêng");
                item1.SubItems.Add(da.Rows[0][16].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("ĐT nhà riêng");
                item1.SubItems.Add(da.Rows[0][12].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Diễn giải");
                item1.SubItems.Add(da.Rows[0][6].ToString());
                lvinfo.Items.Add(item1);

                lvuser.Clear();
                lvuser.Columns.Add("Mã vai trò", 180);
                lvuser.Columns.Add("Tên vai trò", 180);
                lvuser.Columns.Add("Diễn giải", 180);
                lvuser.View = View.Details;
                da = gen.GetTable("select a.RoleID,a.RoleCode,a.RoleName,a.Description from MSC_Role a, MSC_UserJoinRole b where a.RoleID=b.RoleID and b.UserID='" + info + "'");
                ListViewItem item2;
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    item2 = new ListViewItem(da.Rows[i][1].ToString());
                    item2.SubItems.Add(da.Rows[0][2].ToString());
                    item2.SubItems.Add(da.Rows[0][3].ToString());
                    item2.Name = da.Rows[0][0].ToString();
                    lvuser.Items.Add(item2);
                }
                gen.ResizeListViewColumns(lvuser);
            }
            catch
            {
                lvinfo.Clear();
                lvuser.Clear();
            }
        }
        //chức năng thêm sửa của  user
        public void tstbcnuser(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            try
            {
                Frm_user u = new Frm_user();
                u.myac = new Frm_user.ac(F.refreshuser);
                u.getactive(a);
                if (a == "1")
                {
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn user trước khi sửa."); }
        }
        //kiểm tra thêm sửa của user 
        public void checkinfouser(TextBox a, TextBox b, TextBox c, string sql, Frm_user F, string d, DevExpress.XtraGrid.Views.Grid.GridView view, string role, DevExpress.XtraGrid.Views.Grid.GridView viewmn)
        {
            if (a.Text == "") MessageBox.Show("Tên đăng nhập không được bỏ trống.", "HAMACO");
            else if (b.Text != c.Text)
            { 
                MessageBox.Show("Vui lòng nhập lại pass"); 
                b.Text = "";
                c.Text=""; 
                b.Focus(); 
            }
            else
            {
                if (d == "0")
                {
                    try
                    {
                        string kq = gen.GetString("select * from MSC_User where UserName='" +a.Text + "'");
                        MessageBox.Show("Tên đăng nhập này đã tồn tại.", "HAMACO");
                    }
                    catch
                    {
                        b.Text = gen.EncodeMD5(b.Text);
                        gen.ExcuteNonquery(sql);
                        gen.ExcuteNonquery("update MSC_User set Password='" + b.Text + "' where UserName='"+a.Text+"'");
                        string us = gen.GetString("select * from  MSC_User where UserName='" + a.Text + "'");
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            if (view.GetRowCellValue(i, "Chọn").ToString() == "True")
                            {
                                string stock = view.GetRowCellValue(i, "ID").ToString();
                                gen.ExcuteNonquery("insert into MSC_UserJoinStock values(newid(),'"+us+"','"+stock+"')");
                            }

                        }
                        for (int i = 0; i < viewmn.RowCount; i++)
                        {
                            if (viewmn.GetRowCellValue(i, "Chọn").ToString() == "True")
                            {
                                string mn = viewmn.GetRowCellValue(i, "Mã ngành").ToString();
                                gen.ExcuteNonquery("insert into MSC_UserMN values(newid(),'" + us + "','" + mn + "')");
                            }

                        }
                            F.myac();
                        F.Close();
                    }
                }
                else
                {
                    try
                    {
                        string exit = gen.GetString("select * from MSC_User where UserID='" + role + "' and Password='" + b.Text + "'");                       
                    }
                    catch
                    {
                        b.Text = gen.EncodeMD5(b.Text);
                    }
                    gen.ExcuteNonquery(sql);
                    gen.ExcuteNonquery("update MSC_User set Password='" + b.Text + "' where UserID='" + role + "'");
                    gen.ExcuteNonquery("delete from MSC_UserJoinStock where UserID='"+role+"'");
                    gen.ExcuteNonquery("delete from MSC_UserMN where UserID='" + role + "'");
                    for (int i = 0; i < view.RowCount; i++)
                    {
                        if (view.GetRowCellValue(i, "Chọn").ToString() == "True")
                        {
                            string stock = view.GetRowCellValue(i, "ID").ToString();
                            gen.ExcuteNonquery("insert into MSC_UserJoinStock values(newid(),'" + role + "','" + stock + "')");
                        }

                    }
                    for (int i = 0; i < viewmn.RowCount; i++)
                    {
                        if (viewmn.GetRowCellValue(i, "Chọn").ToString() == "True")
                        {
                            string mn = viewmn.GetRowCellValue(i, "Mã ngành").ToString();
                            gen.ExcuteNonquery("insert into MSC_UserMN values(newid(),'" + role + "','" + mn + "')");
                        }

                    }
                    F.myac();
                    F.Close();
                }
            }
        }
        // chọn vai trò................................................
        public void tstbchoiceuser(Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                Frm_choicerole u = new Frm_choicerole();
                u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                u.Text = "Chọn vai trò";
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn user trước khi chọn vai trò."); }
        }
        //xóa user khỏi hệ thống
        public void tstbdeleteuser(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa " + view.GetRowCellValue(view.FocusedRowHandle, "Họ và tên").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from MSC_User where UserID='" + name + "'");
                    gen.ExcuteNonquery("delete from MSC_UserJoinRole where UserID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn user trước khi xóa."); }
        }
    }
}
