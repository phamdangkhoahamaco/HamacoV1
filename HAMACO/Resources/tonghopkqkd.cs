using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraSplashScreen;

namespace HAMACO.Resources
{
    class tonghopkqkd
    {
        gencon gen = new gencon();
        public void loadkhauhao(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Code", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài sản", Type.GetType("System.String"));
            dt.Columns.Add("Sử dụng", Type.GetType("System.DateTime"));
            dt.Columns.Add("Thời gian", Type.GetType("System.Double"));
            dt.Columns.Add("Hết khấu hao", Type.GetType("System.DateTime"));
            dt.Columns.Add("Nguyên giá", Type.GetType("System.Double"));
            dt.Columns.Add("Khấu hao", Type.GetType("System.Double"));
            dt.Columns.Add("Giá trị còn lại", Type.GetType("System.Double"));
            dt.Columns.Add("Còn lại", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế suất", Type.GetType("System.String"));
            dt.Columns.Add("Lãi vay", Type.GetType("System.Double"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("ID kho", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                if (temp.Rows[i][3].ToString() != "")
                    dr[3] = temp.Rows[i][3].ToString();
                if (temp.Rows[i][4].ToString() != "")
                    dr[4] = temp.Rows[i][4].ToString();
                if (temp.Rows[i][5].ToString() != "")
                    dr[5] = temp.Rows[i][5].ToString();
                dr[6] = temp.Rows[i][6].ToString();
                if (temp.Rows[i][5].ToString() != "")
                    dr[7] = temp.Rows[i][7].ToString();
                if (temp.Rows[i][8].ToString() != "")
                    dr[8] = temp.Rows[i][8].ToString();
                if (temp.Rows[i][9].ToString() != "")
                    dr[9] = temp.Rows[i][9].ToString();
                if (temp.Rows[i][10].ToString() != "")
                    dr[10] = Double.Parse(temp.Rows[i][10].ToString()) + "%";
                if (temp.Rows[i][11].ToString() != "")
                    dr[11] = temp.Rows[i][11].ToString();
                dr[12] = temp.Rows[i][12].ToString();
                dr[13] = temp.Rows[i][13].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;

            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[1].Visible = false;
            view.Columns[13].Visible = false;

            view.Columns["Sử dụng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Sử dụng"].DisplayFormat.FormatString = "MM/yyyy";
            view.Columns["Sử dụng"].Width = 100;
            view.Columns["Sử dụng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Thời gian"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thời gian"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thời gian"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Thời gian"].Width = 100;

            view.Columns["Hết khấu hao"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Hết khấu hao"].DisplayFormat.FormatString = "MM/yyyy";
            view.Columns["Hết khấu hao"].Width = 100;
            view.Columns["Hết khấu hao"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
           
            view.Columns["Nguyên giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nguyên giá"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nguyên giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nguyên giá"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Khấu hao"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Khấu hao"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Khấu hao"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Khấu hao"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Giá trị còn lại"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Giá trị còn lại"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Giá trị còn lại"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Giá trị còn lại"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Còn lại"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Còn lại"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Còn lại"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Còn lại"].Width = 100;

            view.Columns["Thuế suất"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Thuế suất"].Width = 100;

            view.Columns["Lãi vay"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lãi vay"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lãi vay"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lãi vay"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;

            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Nguyên giá";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Nguyên giá"];

            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Khấu hao";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Khấu hao"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Giá trị còn lại";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Giá trị còn lại"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Lãi vay";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Lãi vay"];


            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
            view.Columns["Tên tài sản"].BestFit();
        }

        public void tsbtckkh(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string ngay)
        {            
            try
            {
                Depreciation m = new Depreciation();
                m.myac = new Depreciation.ac(F.refreshckkh);
                m.getactive(a);
                m.getngay(ngay);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                m.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn Tài sản khấu hao trước khi sửa."); }
        }

        public void tsbttgp(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string ngay)
        {
            try
            {
                Frm_Descasc m = new Frm_Descasc();
                m.myac = new Frm_Descasc.ac(F.refreshtgp);
                m.getactive(a);
                m.getngay(ngay);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                m.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn Chi phí trước khi sửa."); }
        }

        public void loadtanggiam(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Code", Type.GetType("System.String"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            dt.Columns.Add("Thời gian", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tăng giảm phí", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí khác", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
          
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                if (temp.Rows[i][7].ToString() == "0")
                    dr[4] = temp.Rows[i][4].ToString();  
                else
                    dr[5] = temp.Rows[i][4].ToString();  
                dr[6] = temp.Rows[i][5].ToString();
                dr[7] = temp.Rows[i][6].ToString();  
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;

            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[1].Visible = false;

            view.Columns["Thời gian"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Thời gian"].DisplayFormat.FormatString = "MM/yyyy";
            view.Columns["Thời gian"].Width = 100;
            view.Columns["Thời gian"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Tăng giảm phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tăng giảm phí"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tăng giảm phí"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tăng giảm phí"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chi phí khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chi phí khác"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chi phí khác"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chi phí khác"].SummaryItem.DisplayFormat = "{0:n0}";


            view.OptionsView.ShowFooter = true;

            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Tăng giảm phí";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Tăng giảm phí"];

            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Chi phí khác";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Chi phí khác"];

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
            view.Columns["Tăng giảm phí"].Width = 200;
            view.Columns["Chi phí khác"].Width = 200;
            view.Columns["Diễn giải"].BestFit();
        }

        public void tsbtdeleteckkh(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa tài sản " + view.GetRowCellValue(view.FocusedRowHandle, "Tên tài sản").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from Depreciation where DepreciationID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn tài sản trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public void tsbtdeletetgp(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa " + view.GetRowCellValue(view.FocusedRowHandle, "Diễn giải").ToString() + " từ kho "+view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString()+"?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from Descasc where DescascID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

    }
}
