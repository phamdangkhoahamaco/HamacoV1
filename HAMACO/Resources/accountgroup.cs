using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace HAMACO.Resources
{
    class accountgroup
    {
        gencon gen = new gencon();

        public void loadgroupaccount(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable("Select * from AccountCategory");
            dt.Columns.Add("Mã nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Tính chất", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                if (temp.Rows[i][2].ToString() == "0") dr[2] = "Dư nợ";
                else if (temp.Rows[i][2].ToString() == "1") dr[2] = "Dư có";
                else if (temp.Rows[i][2].ToString() == "2") dr[2] = "Lưỡng tính";
                else dr[2] = "Không có số dư";
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";
           
        }

        public void tsbtntk(Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                Frm_accountgroup u = new Frm_accountgroup();
                u.myac = new Frm_accountgroup.ac(F.refreshaccountgroup);
                u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã nhóm").ToString());
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn nhóm tài khoản trước khi sửa."); }
        }

        public void checkaccountgroup(string a, string sql, Frm_accountgroup F)
        {
            if (a == "") MessageBox.Show("Tên tài khoản không được bỏ trống.", "HAMACO");
            else
            {
                    gen.ExcuteNonquery(sql);
                    F.myac();
                    F.Close();
            }
        }

    }
}
