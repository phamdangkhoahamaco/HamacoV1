using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using HAMACO.Resources;

namespace HAMACO
{
    class distrist
    {
        gencon gen = new gencon();
        public void loaddistrist(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            
            string sql = "select DistristID,DistristCode,DistristName,a.Description,ProvinceName from Distrist a, Province b where a.ProvinceID=b.ProvinceID order by ProvinceName";
           
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã Quận/Huyện", Type.GetType("System.String"));
            dt.Columns.Add("Tên Quận/Huyện", Type.GetType("System.String"));
            dt.Columns.Add("Tên Tỉnh/Thành", Type.GetType("System.String"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][4].ToString();
                dr[4] = temp.Rows[i][3].ToString();
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

        public void tsbtdistrist(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            try
            {
                Frm_distrist m = new Frm_distrist();
                m.myac = new Frm_distrist.ac(F.refreshdistrist);
                m.getactive(a);
                m.getuserid(userid);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                m.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn tỉnh/thành trước khi sửa."); }
        }

        public void checkdistrist(string ac, TextBox a, TextBox b, string sql, Frm_distrist F)
        {
            if (a.Text == "") MessageBox.Show("Mã quận/huyện không được bỏ trống.", "HAMACO");
            else if (b.Text == "") MessageBox.Show("Tên quận/huyện không được bỏ trống.", "HAMACO");
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
                        string kq = gen.GetString("select * from Distrist where DistristCode='" + a.Text + "'");
                        MessageBox.Show("Mã quận/huyện này đã tồn tại.", "HAMACO");
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

        public void tsbtdeletedistrist(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa quận/huyện " + view.GetRowCellValue(view.FocusedRowHandle, "Mã Quận/Huyện").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from Distrist where DistristID='" + name + "'");
                    //F.refreshdistrist();
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn quận/huyện trước khi xóa."); }
        }

    }
}
