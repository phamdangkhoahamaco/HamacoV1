using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace HAMACO.Resources
{
    class province
    {
        gencon gen = new gencon();
        public void loadprovince(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {           
            string sql = "select * from Province order by ProvinceCode";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã Tỉnh/Thành", Type.GetType("System.String"));
            dt.Columns.Add("Tên Tỉnh/Thành", Type.GetType("System.String"));
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

        public void tsbtprovince(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            try
            {
                Frm_province m = new Frm_province();
                m.myac = new Frm_province.ac(F.refreshprovince);
                m.getactive(a);
                m.getuserid(userid);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                m.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn Tỉnh/Thành trước khi sửa."); }
        }

        public void checkprovince(string ac, TextBox a, TextBox b, string sql, Frm_province F)
        {
            if (a.Text == "") MessageBox.Show("Mã Tỉnh/Thành không được bỏ trống.", "HAMACO");
            else if (b.Text == "") MessageBox.Show("Tên Tỉnh/Thành không được bỏ trống.", "HAMACO");
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
                        string kq = gen.GetString("select * from Province where ProvinceCode='" + a.Text + "'");
                        MessageBox.Show("Mã Tỉnh/Thành này đã tồn tại.", "HAMACO");
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

        public void tsbtdeleteprovince(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa Tỉnh/Thành " + view.GetRowCellValue(view.FocusedRowHandle, "Mã Tỉnh/Thành").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from Province where ProvinceID='" + name + "'");
                    gen.ExcuteNonquery("delete from Distrist where ProvinceID='" + name + "'");
                    //F.refreshprovince();
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn Tỉnh/Thành trước khi xóa."); }
        }

    }
}
