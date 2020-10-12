using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace HAMACO.Resources
{
    class nhanvien
    {
        gencon gen = new gencon();
        public void loadnv(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã nhân viên", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhân viên", Type.GetType("System.String"));
            dt.Columns.Add("Chức vụ", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Ngừng theo dõi", Type.GetType("System.Boolean"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][17].ToString();
                string dv = gen.GetString("select BranchName from Branch where BranchID='" + temp.Rows[i][4].ToString() + "'");
                dr[4] = dv;
                dr[5] = temp.Rows[i][34].ToString();
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

        public void changetabnhanvien(ListView lvinfo, ListView lvuser, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                DataTable da = new DataTable();
                string info = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();

                lvinfo.Clear();
                lvinfo.Columns.Add("", 180);
                lvinfo.Columns.Add("", 300);
                lvinfo.Columns.Add("", 180);
                lvinfo.Columns.Add("", 300);
                lvinfo.View = View.Details;
                da = gen.GetTable("select * from AccountingObject  where AccountingObjectID = '" + info + "'");
                ListViewItem item1;
                item1 = new ListViewItem("Mã nhân viên");
                item1.SubItems.Add(da.Rows[0][1].ToString());
                item1.SubItems.Add("Điện thoại cơ quan");
                item1.SubItems.Add(da.Rows[0][20].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Tên nhân viên");
                item1.SubItems.Add(da.Rows[0][2].ToString());
                item1.SubItems.Add("Điện thoại nhà riêng");
                item1.SubItems.Add(da.Rows[0][21].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Giới tính");
                if (da.Rows[0][18].ToString() == "1")
                    item1.SubItems.Add("Nam");
                else
                    item1.SubItems.Add("Nữ");
                item1.SubItems.Add("Điện thoại nhà riêng");
                item1.SubItems.Add(da.Rows[0][19].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Đơn vị");
                string dv = gen.GetString("select BranchName from Branch where BranchID='" + da.Rows[0][4].ToString() + "'");
                item1.SubItems.Add(dv);
                item1.SubItems.Add("Số CMND");
                item1.SubItems.Add(da.Rows[0][26].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Chức vụ");
                item1.SubItems.Add(da.Rows[0][17].ToString());
                item1.SubItems.Add("Email");
                item1.SubItems.Add(da.Rows[0][10].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Hệ số lương");
                item1.SubItems.Add(da.Rows[0][37].ToString());
                item1.SubItems.Add("TK ngân hàng");
                item1.SubItems.Add(da.Rows[0][12].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Giảm trừ gia cảnh");
                item1.SubItems.Add(da.Rows[0][33].ToString());
                item1.SubItems.Add("Tên ngân hàng");
                item1.SubItems.Add(da.Rows[0][13].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Địa chỉ");
                item1.SubItems.Add(da.Rows[0][7].ToString());
                item1.SubItems.Add("Mã số thuế");
                item1.SubItems.Add(da.Rows[0][14].ToString());
                lvinfo.Items.Add(item1);
                gen.ResizeListViewColumns(lvuser);
            }
            catch { }
        }

        public void tsbtnhanvien(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            try
            {
                Frm_nhanvien m = new Frm_nhanvien();
                m.myac = new Frm_nhanvien.ac(F.refreshnhanvien);
                m.getactive(a);
                m.getuserid(userid);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                m.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn nhân viên trước khi sửa."); }
        }

        public void checknhanvien(string ac, TextBox a, TextBox b, string sql, Frm_nhanvien F)
        {
            if (a.Text == "") MessageBox.Show("Mã nhân viên không được bỏ trống.", "HAMACO");
            else if (b.Text == "") MessageBox.Show("Tên nhân viên không được bỏ trống.", "HAMACO");
            else
            {
                if (ac == "1")
                {
                    gen.ExcuteNonquery(sql);
                    F.myac();
                    F.Close();
                }
                else
                {
                    try
                    {
                        string kq = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + a.Text + "'");
                        MessageBox.Show("Mã nhân viên này đã tồn tại.", "HAMACO");
                    }
                    catch
                    {
                        gen.ExcuteNonquery(sql);
                        F.myac();
                        F.Close();
                    }
                }
            }
        }

        public void tsbtdeletenhanvien(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + view.GetRowCellValue(view.FocusedRowHandle, "Mã nhân viên").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from AccountingObject where AccountingObjectID='" + name + "'");
                    //F.refreshnhanvien();
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn nhân viên trước khi xóa."); }
        }
    }
}
