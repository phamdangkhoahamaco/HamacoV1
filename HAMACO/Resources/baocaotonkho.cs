using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace HAMACO.Resources
{
    class baocaotonkho
    {
        gencon gen = new gencon();
       
        public void loadbctktsl(DevExpress.XtraGrid.GridControl lvpq, GridView view,string ngaychungtu, string tsbt, string kho)
        {
            DataTable dt = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();       

            string sql = "";
            if (tsbt == "tsbtbctktsl")
            {
                sql = "baocaotonkhotheothangnew '" + ngaychungtu + "','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
            }
            else if (tsbt == "tsbtbctktslcu")
            {
                sql = "baocaotonkhotheothangnewnew '" + ngaychungtu + "','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
            }
            else if (tsbt == "tsbtbctkthtct")
                sql = "baocaotonkhotheothangtoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
            else
                sql = "baocaotonkhotheothangtheodonvi '" + ngaychungtu + "','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";            
            // XtraMessageBox.Show(sql, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            laydulieu(dt, sql, tsbt);
            
            view.Columns.Clear();
            lvpq.DataSource = dt;

            view.OptionsBehavior.Editable = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            view.Columns[17].Visible = false;
            view.Columns[18].Visible = false;
            view.Columns[19].Visible = false;
            view.OptionsView.ColumnAutoWidth = false;

            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Số lượng ĐK";
            item.DisplayFormat = "{0:n2}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Số lượng ĐK"];

            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Số tiền ĐK";
            item1.DisplayFormat = "{0:n2}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Số tiền ĐK"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Số lượng NTK";
            item2.DisplayFormat = "{0:n2}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Số lượng NTK"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Số tiền NTK";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Số tiền NTK"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Số lượng NCK";
            item4.DisplayFormat = "{0:n2}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Số lượng NCK"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "Số tiền NCK";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["Số tiền NCK"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "Số lượng XCK";
            item6.DisplayFormat = "{0:n2}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["Số lượng XCK"];

            GridGroupSummaryItem item7 = new GridGroupSummaryItem();
            item7.FieldName = "Số tiền XCK";
            item7.DisplayFormat = "{0:n0}";
            item7.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item7);
            item7.ShowInGroupColumnFooter = view.Columns["Số tiền XCK"];

            GridGroupSummaryItem item8 = new GridGroupSummaryItem();
            item8.FieldName = "Số lượng XTK";
            item8.DisplayFormat = "{0:n2}";
            item8.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item8);
            item8.ShowInGroupColumnFooter = view.Columns["Số lượng XTK"];

            GridGroupSummaryItem item9 = new GridGroupSummaryItem();
            item9.FieldName = "Trị giá vốn";
            item9.DisplayFormat = "{0:n0}";
            item9.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item9);
            item9.ShowInGroupColumnFooter = view.Columns["Trị giá vốn"];

            GridGroupSummaryItem item10 = new GridGroupSummaryItem();
            item10.FieldName = "Số tiền XTK";
            item10.DisplayFormat = "{0:n0}";
            item10.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item10);
            item10.ShowInGroupColumnFooter = view.Columns["Số tiền XTK"];

            GridGroupSummaryItem item11 = new GridGroupSummaryItem();
            item11.FieldName = "SLBB TCK";
            item11.DisplayFormat = "{0:n0}";
            item11.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item11);
            item11.ShowInGroupColumnFooter = view.Columns["SLBB TCK"];

            GridGroupSummaryItem item12 = new GridGroupSummaryItem();
            item12.FieldName = "Số lượng TCK";
            item12.DisplayFormat = "{0:n2}";
            item12.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item12);
            item12.ShowInGroupColumnFooter = view.Columns["Số lượng TCK"];

            GridGroupSummaryItem item13 = new GridGroupSummaryItem();
            item13.FieldName = "Số tiền TCK";
            item13.DisplayFormat = "{0:n0}";
            item13.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item13);
            item13.ShowInGroupColumnFooter = view.Columns["Số tiền TCK"];

            view.Columns["Mã hàng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Tên hàng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Số tiền TCK"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Số lượng TCK"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;

            view.Columns["Mã hàng"].Width = 120;
            view.Columns["Tên hàng"].Width = 250;
            view.Columns["Đơn giá"].Width = 120;
            view.Columns["Số lượng ĐK"].Width = 120;
            view.Columns["Số tiền ĐK"].Width = 120;
            view.Columns["Số lượng NTK"].Width = 120;
            view.Columns["Số tiền NTK"].Width = 120;

            view.Columns["Số lượng NCK"].Width = 120;
            view.Columns["Số tiền NCK"].Width = 120;
            view.Columns["Số lượng XCK"].Width = 120;
            view.Columns["Số tiền XCK"].Width = 120;

            view.Columns["Số lượng XTK"].Width = 120;
            view.Columns["Trị giá vốn"].Width = 120;
            view.Columns["Số tiền XTK"].Width = 120;

            view.Columns["SLBB TCK"].Width = 120;
            view.Columns["Số lượng TCK"].Width = 120;
            view.Columns["Số tiền TCK"].Width = 120;

            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns["Số lượng NTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng NTK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng NTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng NTK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền NTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền NTK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền NTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền NTK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng ĐK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng ĐK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng ĐK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng ĐK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền ĐK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền ĐK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền ĐK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền ĐK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng NCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng NCK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng NCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng NCK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền NCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền NCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền NCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền NCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng XCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng XCK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng XCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng XCK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền XCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền XCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền XCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền XCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng XTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng XTK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng XTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng XTK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền XTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền XTK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền XTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền XTK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trị giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trị giá vốn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trị giá vốn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trị giá vốn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["SLBB TCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["SLBB TCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["SLBB TCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["SLBB TCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng TCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng TCK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng TCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng TCK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền TCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền TCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền TCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền TCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Nhóm hàng"].GroupIndex = 0;
            view.ExpandAllGroups();

        }

        public void inbctk(string ngaychungtu, string tsbt, string kho,GridView view,string userid,string an)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("tenhang", Type.GetType("System.String"));
            dt.Columns.Add("dongia", Type.GetType("System.Double"));
            dt.Columns.Add("tondau", Type.GetType("System.Double"));
            dt.Columns.Add("tientondau", Type.GetType("System.Double"));
            dt.Columns.Add("nhapdau", Type.GetType("System.Double"));
            dt.Columns.Add("tiennhapdau", Type.GetType("System.Double"));
            dt.Columns.Add("nhapchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("tiennhapchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("xuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("tienxuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("xuatban", Type.GetType("System.Double"));
            dt.Columns.Add("trigiaton", Type.GetType("System.Double"));
            dt.Columns.Add("tienxuatban", Type.GetType("System.Double"));
            dt.Columns.Add("slbb", Type.GetType("System.Double"));
            dt.Columns.Add("sltoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("tttoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("nhomhang", Type.GetType("System.String"));
            dt.Columns.Add("nhom", Type.GetType("System.String"));
            
            for (int i = 0; i < view.DataRowCount; i++)
            {
                if (view.GetRowCellValue(i, "Số lượng ĐK").ToString() != "" || view.GetRowCellValue(i, "Số tiền ĐK").ToString() != "" || view.GetRowCellValue(i, "Số lượng NTK").ToString() != "" || view.GetRowCellValue(i, "Số tiền NTK").ToString() != "" || view.GetRowCellValue(i, "Số lượng NCK").ToString() != "" || view.GetRowCellValue(i, "Số tiền NCK").ToString() != ""
                    || view.GetRowCellValue(i, "Số lượng XCK").ToString() != "" || view.GetRowCellValue(i, "Số tiền XCK").ToString() != "" || view.GetRowCellValue(i, "Số lượng XTK").ToString() != "" || view.GetRowCellValue(i, "Trị giá vốn").ToString() != "" || view.GetRowCellValue(i, "Số tiền XTK").ToString() != "" || view.GetRowCellValue(i, "SLBB TCK").ToString() != "" || view.GetRowCellValue(i, "Số lượng TCK").ToString() != "" || view.GetRowCellValue(i, "Số tiền TCK").ToString() != "")
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = view.GetRowCellValue(i, "Tên hàng").ToString();
                    if (view.GetRowCellValue(i, "Đơn giá").ToString() != "")
                        dr[1] = view.GetRowCellValue(i, "Đơn giá").ToString();
                    if (view.GetRowCellValue(i, "Số lượng ĐK").ToString() != "")
                        dr[2] = view.GetRowCellValue(i, "Số lượng ĐK").ToString();
                    if (view.GetRowCellValue(i, "Số tiền ĐK").ToString() != "")
                        dr[3] = view.GetRowCellValue(i, "Số tiền ĐK").ToString();
                    if (view.GetRowCellValue(i, "Số lượng NTK").ToString() != "")
                        dr[4] = view.GetRowCellValue(i, "Số lượng NTK").ToString();
                    if (view.GetRowCellValue(i, "Số tiền NTK").ToString() != "")
                        dr[5] = view.GetRowCellValue(i, "Số tiền NTK").ToString();
                    if (view.GetRowCellValue(i, "Số lượng NCK").ToString() != "")
                        dr[6] = view.GetRowCellValue(i, "Số lượng NCK").ToString();
                    if (view.GetRowCellValue(i, "Số tiền NCK").ToString() != "")
                        dr[7] = view.GetRowCellValue(i, "Số tiền NCK").ToString();
                    if (view.GetRowCellValue(i, "Số lượng XCK").ToString() != "")
                        dr[8] = view.GetRowCellValue(i, "Số lượng XCK").ToString();
                    if (view.GetRowCellValue(i, "Số tiền XCK").ToString() != "")
                        dr[9] = view.GetRowCellValue(i, "Số tiền XCK").ToString();
                    if (view.GetRowCellValue(i, "Số lượng XTK").ToString() != "")
                        dr[10] = view.GetRowCellValue(i, "Số lượng XTK").ToString();
                    if (view.GetRowCellValue(i, "Trị giá vốn").ToString() != "")
                        dr[11] = view.GetRowCellValue(i, "Trị giá vốn").ToString();
                    if (view.GetRowCellValue(i, "Số tiền XTK").ToString() != "")
                        if (Double.Parse(view.GetRowCellValue(i, "Số tiền XTK").ToString()) != 0)
                            dr[12] = view.GetRowCellValue(i, "Số tiền XTK").ToString();
                    if (view.GetRowCellValue(i, "SLBB TCK").ToString() != "")
                        dr[13] = view.GetRowCellValue(i, "SLBB TCK").ToString();
                    if (view.GetRowCellValue(i, "Số lượng TCK").ToString() != "")
                        dr[14] = view.GetRowCellValue(i, "Số lượng TCK").ToString();
                    if (view.GetRowCellValue(i, "Số tiền TCK").ToString() != "")
                        dr[15] = view.GetRowCellValue(i, "Số tiền TCK").ToString();
                    dr[16] = view.GetRowCellValue(i, "Tên nhóm").ToString();
                    dr[17] = view.GetRowCellValue(i, "Nhóm").ToString();

                    dt.Rows.Add(dr);
                }
            }         

            Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.gettinh(userid);
            rp.getan(an);
            rp.Show();
        }

        public void inbctktndn(string tungay,string denngay, string tsbt, string kho, GridView view,string userid,string an)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("tenhang", Type.GetType("System.String"));
            dt.Columns.Add("dongia", Type.GetType("System.Double"));
            dt.Columns.Add("tondau", Type.GetType("System.Double"));
            dt.Columns.Add("tientondau", Type.GetType("System.Double"));
            dt.Columns.Add("nhapdau", Type.GetType("System.Double"));
            dt.Columns.Add("tiennhapdau", Type.GetType("System.Double"));
            dt.Columns.Add("nhapchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("tiennhapchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("xuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("tienxuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("xuatban", Type.GetType("System.Double"));
            dt.Columns.Add("trigiaton", Type.GetType("System.Double"));
            dt.Columns.Add("tienxuatban", Type.GetType("System.Double"));
            dt.Columns.Add("slbb", Type.GetType("System.Double"));
            dt.Columns.Add("sltoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("tttoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("nhomhang", Type.GetType("System.String"));
            dt.Columns.Add("nhom", Type.GetType("System.String"));

            for (int i = 0; i < view.DataRowCount; i++)
            {
                DataRow dr = dt.NewRow();

                dr[0] = view.GetRowCellValue(i, "Tên hàng").ToString();
                if (view.GetRowCellValue(i, "Đơn giá").ToString() != "")
                    dr[1] = view.GetRowCellValue(i, "Đơn giá").ToString();
                if (view.GetRowCellValue(i, "Số lượng ĐK").ToString() != "")
                    dr[2] = view.GetRowCellValue(i, "Số lượng ĐK").ToString();
                if (view.GetRowCellValue(i, "Số tiền ĐK").ToString() != "")
                    dr[3] = view.GetRowCellValue(i, "Số tiền ĐK").ToString();
                if (view.GetRowCellValue(i, "Số lượng NTK").ToString() != "")
                    dr[4] = view.GetRowCellValue(i, "Số lượng NTK").ToString();
                if (view.GetRowCellValue(i, "Số tiền NTK").ToString() != "")
                    dr[5] = view.GetRowCellValue(i, "Số tiền NTK").ToString();
                if (view.GetRowCellValue(i, "Số lượng NCK").ToString() != "")
                    dr[6] = view.GetRowCellValue(i, "Số lượng NCK").ToString();
                if (view.GetRowCellValue(i, "Số tiền NCK").ToString() != "")
                    dr[7] = view.GetRowCellValue(i, "Số tiền NCK").ToString();
                if (view.GetRowCellValue(i, "Số lượng XCK").ToString() != "")
                    dr[8] = view.GetRowCellValue(i, "Số lượng XCK").ToString();
                if (view.GetRowCellValue(i, "Số tiền XCK").ToString() != "")
                    dr[9] = view.GetRowCellValue(i, "Số tiền XCK").ToString();
                if (view.GetRowCellValue(i, "Số lượng XTK").ToString() != "")
                    dr[10] = view.GetRowCellValue(i, "Số lượng XTK").ToString();
                if (view.GetRowCellValue(i, "Trị giá vốn").ToString() != "")
                    dr[11] = view.GetRowCellValue(i, "Trị giá vốn").ToString();
                if (view.GetRowCellValue(i, "Số tiền XTK").ToString() != "")
                    dr[12] = view.GetRowCellValue(i, "Số tiền XTK").ToString();
                if (view.GetRowCellValue(i, "SLBB TCK").ToString() != "")
                    dr[13] = view.GetRowCellValue(i, "SLBB TCK").ToString();
                if (view.GetRowCellValue(i, "Số lượng TCK").ToString() != "")
                    dr[14] = view.GetRowCellValue(i, "Số lượng TCK").ToString();
                if (view.GetRowCellValue(i, "Số tiền TCK").ToString() != "")
                    dr[15] = view.GetRowCellValue(i, "Số tiền TCK").ToString();
                dr[16] = view.GetRowCellValue(i, "Tên nhóm").ToString();
                dr[17] = view.GetRowCellValue(i, "Nhóm").ToString();

                dt.Rows.Add(dr);
            }

           Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
           rp.gettinh(userid);
           rp.getdata(dt);
           rp.getkho(kho);
           rp.gettungay(tungay);
           rp.getdenngay(denngay);
           rp.gettsbt(tsbt);
           rp.getan(an);
           rp.Show();
        }

        public void inbctktong(string ngaychungtu, string tsbt, string kho)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString(); 
      
            string sql = "";
            string tenkho="";
            if (tsbt == "tsbtbctktsl")
            {
                sql = "baocaotonkhotheothangnew '"+ngaychungtu+"','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
            }
            else if (tsbt == "tsbtbctktslcu")
            {
                sql = "baocaotonkhotheothangnewnew '" + ngaychungtu + "','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
            }
            else if (tsbt == "tsbtbctktttdv")
            {
                sql = "baocaotonkhotheothangtheodonvi '"+ngaychungtu+"','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
                tenkho = gen.GetString("select BranchName from Branch where BranchID='" + kho + "'");
                string makho = gen.GetString("select BranchCode from Branch where BranchID='" + kho + "'");
                tenkho = ("ĐƠN VỊ " + makho + " - " + tenkho).ToUpper();
            }
            laydulieu(dt, sql, tsbt+"tong");
            Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
            rp.gettenkho(tenkho);
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbctkthdtndnbcn(string tungay, string denngay, string tsbt, string userid, string kho)
        {
            DataTable dt = new DataTable();

            string thangtruoc = DateTime.Parse(tungay).Month.ToString();
            string namtruoc = DateTime.Parse(tungay).Year.ToString();

            string thangtruoccuoi = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            string namtruoccuoi = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();

            string tungaydau = DateTime.Parse(thangtruoc + "/1/" + namtruoc).ToString();
            string denngaydau = DateTime.Parse(DateTime.Parse(tungay).ToShortDateString()).AddSeconds(-1).ToString();

            string tungaycuoi = DateTime.Parse(tungay).ToString();
            string denngaycuoi = DateTime.Parse(DateTime.Parse(denngay).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            string thangcuoi = DateTime.Parse(denngay).Month.ToString();
            string namcuoi = DateTime.Parse(denngay).Year.ToString();

            string thang = DateTime.Parse(denngay).AddMonths(-1).Month.ToString();
            string nam = DateTime.Parse(denngay).AddMonths(-1).Year.ToString();


            if (tsbt == "tsbtbctkbcn")
            {
                string sql = "baocaotonkhotungaydenngaytheodonvibcn '" + kho + "','" + thangtruoccuoi + "','" + namtruoccuoi + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + thang + "','" + nam + "','" + thangcuoi + "','" + namcuoi + "','" + tungaycuoi + "','" + denngaycuoi + "'";
                laydulieubcn(dt, sql, tsbt);
            }
            else if (tsbt == "bctkhhtn" || tsbt == "bctkhhtnlpg" || tsbt == "bctkhhtnvo")
            {                
                //DataSet da = new DataSet();
                //da.Tables.Add(gen.GetTable("baocaotonkhotungaydenngaytheokhobcn '" + kho + "','" + thangtruoccuoi + "','" + namtruoccuoi + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + thang + "','" + nam + "','" + thangcuoi + "','" + namcuoi + "','" + tungaycuoi + "','" + denngaycuoi + "'"));
                //gen.CreateExcel(da, "Baocaotonkhotonghop_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) +"_"+String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay)) + ".xlsx");
                //return;
                dt = gen.GetTable("baocaotonkhotungaydenngaytheokhobcn'" + kho + "','" + thangtruoccuoi + "','" + namtruoccuoi + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + thang + "','" + nam + "','" + thangcuoi + "','" + namcuoi + "','" + tungaycuoi + "','" + denngaycuoi + "'");
            }
            Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(denngay);
            rp.gettungay(tungay);
            rp.gettsbt(tsbt);
            rp.Show();

        }

        public void loadbctkthdtndnbcnhangtieudung(string ngaychungtu, string kho)
        {
            DataTable dt = new DataTable();
            //string kho = gen.GetString("select * from Stock where StockCode='02'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            string sql = "baocaotonkhotheothangthuctehangtieudungchitiet '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";

            laydulieubcn(dt, sql, "tsbtbctkbcn");

            Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt("bctkhtd");
            rp.ShowDialog();
        }

        public void loadbctkthdtndnbcnnganhhang(string ngaychungtu, string userid)
        {
            DataTable dt = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            string sql = "baocaotonkhotheothangthuctenganhhang '" + userid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";

            laydulieubcn(dt, sql, "tsbtbctkbcn");

            Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
            rp.getdata(dt);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt("bctkhtd");
            rp.ShowDialog();
        }
        
        public void loadbctkthdtndn(DevExpress.XtraGrid.GridControl lvpq, GridView view, string tungay, string denngay, string tsbt, string kho)
        {
            DataTable dt = new DataTable();

            string thangtruoc = DateTime.Parse(tungay).Month.ToString();
            string namtruoc = DateTime.Parse(tungay).Year.ToString();

            string thangtruoccuoi = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            string namtruoccuoi = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();

            string tungaydau = DateTime.Parse(thangtruoc+"/1/"+namtruoc).ToString();
            string denngaydau = DateTime.Parse(DateTime.Parse(tungay).ToShortDateString()).AddSeconds(-1).ToString();

            string tungaycuoi = DateTime.Parse(tungay).ToString();
            string denngaycuoi = DateTime.Parse(DateTime.Parse(denngay).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            string thangcuoi = DateTime.Parse(denngay).Month.ToString();
            string namcuoi = DateTime.Parse(denngay).Year.ToString();

            string thang = DateTime.Parse(denngay).AddMonths(-1).Month.ToString();
            string nam = DateTime.Parse(denngay).AddMonths(-1).Year.ToString();

            string sql = null;        
            if (tsbt == "tsbtbctkthdtndn")
            {
                sql = "baocaotonkhotungaydenngay '" + kho + "','" + thangtruoccuoi + "','" + namtruoccuoi + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + thang + "','" + nam + "','" + thangcuoi + "','" + namcuoi + "','" + tungaycuoi + "','" + denngaycuoi + "'";             
            }
            else if (tsbt == "tsbtbctktndntdv")
            {
                sql = "baocaotonkhotungaydenngaytheodonvi '" + kho + "','" + thangtruoccuoi + "','" + namtruoccuoi + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + thang + "','" + nam + "','" + thangcuoi + "','" + namcuoi + "','" + tungaycuoi + "','" + denngaycuoi + "'";
            }
            else 
            {
                sql = "baocaotonkhotungaydenngaytoancongty '" + thangtruoccuoi + "','" + namtruoccuoi + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + thang + "','" + nam + "','" + thangcuoi + "','" + namcuoi + "','" + tungaycuoi + "','" + denngaycuoi + "'";
            }

            laydulieu(dt, sql,tsbt);

            view.Columns.Clear();
            lvpq.DataSource = dt;

            view.OptionsBehavior.Editable = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            view.Columns[17].Visible = false;
            view.Columns[18].Visible = false;
            view.Columns[19].Visible = false;
            view.OptionsView.ColumnAutoWidth = false;

            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";



            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Số lượng ĐK";
            item.DisplayFormat = "{0:n2}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Số lượng ĐK"];

            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Số tiền ĐK";
            item1.DisplayFormat = "{0:n2}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Số tiền ĐK"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Số lượng NTK";
            item2.DisplayFormat = "{0:n2}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Số lượng NTK"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Số tiền NTK";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Số tiền NTK"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Số lượng NCK";
            item4.DisplayFormat = "{0:n2}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Số lượng NCK"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "Số tiền NCK";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["Số tiền NCK"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "Số lượng XCK";
            item6.DisplayFormat = "{0:n2}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["Số lượng XCK"];

            GridGroupSummaryItem item7 = new GridGroupSummaryItem();
            item7.FieldName = "Số tiền XCK";
            item7.DisplayFormat = "{0:n0}";
            item7.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item7);
            item7.ShowInGroupColumnFooter = view.Columns["Số tiền XCK"];

            GridGroupSummaryItem item8 = new GridGroupSummaryItem();
            item8.FieldName = "Số lượng XTK";
            item8.DisplayFormat = "{0:n2}";
            item8.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item8);
            item8.ShowInGroupColumnFooter = view.Columns["Số lượng XTK"];

            GridGroupSummaryItem item9 = new GridGroupSummaryItem();
            item9.FieldName = "Trị giá vốn";
            item9.DisplayFormat = "{0:n0}";
            item9.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item9);
            item9.ShowInGroupColumnFooter = view.Columns["Trị giá vốn"];

            GridGroupSummaryItem item10 = new GridGroupSummaryItem();
            item10.FieldName = "Số tiền XTK";
            item10.DisplayFormat = "{0:n0}";
            item10.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item10);
            item10.ShowInGroupColumnFooter = view.Columns["Số tiền XTK"];

            GridGroupSummaryItem item11 = new GridGroupSummaryItem();
            item11.FieldName = "SLBB TCK";
            item11.DisplayFormat = "{0:n0}";
            item11.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item11);
            item11.ShowInGroupColumnFooter = view.Columns["SLBB TCK"];

            GridGroupSummaryItem item12 = new GridGroupSummaryItem();
            item12.FieldName = "Số lượng TCK";
            item12.DisplayFormat = "{0:n2}";
            item12.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item12);
            item12.ShowInGroupColumnFooter = view.Columns["Số lượng TCK"];

            GridGroupSummaryItem item13 = new GridGroupSummaryItem();
            item13.FieldName = "Số tiền TCK";
            item13.DisplayFormat = "{0:n0}";
            item13.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item13);
            item13.ShowInGroupColumnFooter = view.Columns["Số tiền TCK"];

            view.Columns["Mã hàng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Tên hàng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Số tiền TCK"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Số lượng TCK"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;

            view.Columns["Mã hàng"].Width = 120;
            view.Columns["Tên hàng"].Width = 250;
            view.Columns["Đơn giá"].Width = 120;
            view.Columns["Số lượng ĐK"].Width = 120;
            view.Columns["Số tiền ĐK"].Width = 120;
            view.Columns["Số lượng NTK"].Width = 120;
            view.Columns["Số tiền NTK"].Width = 120;

            view.Columns["Số lượng NCK"].Width = 120;
            view.Columns["Số tiền NCK"].Width = 120;
            view.Columns["Số lượng XCK"].Width = 120;
            view.Columns["Số tiền XCK"].Width = 120;

            view.Columns["Số lượng XTK"].Width = 120;
            view.Columns["Trị giá vốn"].Width = 120;
            view.Columns["Số tiền XTK"].Width = 120;

            view.Columns["SLBB TCK"].Width = 120;
            view.Columns["Số lượng TCK"].Width = 120;
            view.Columns["Số tiền TCK"].Width = 120;

            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns["Số lượng NTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng NTK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng NTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng NTK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền NTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền NTK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền NTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền NTK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng ĐK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng ĐK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng ĐK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng ĐK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền ĐK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền ĐK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền ĐK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền ĐK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng NCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng NCK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng NCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng NCK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền NCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền NCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền NCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền NCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng XCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng XCK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng XCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng XCK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền XCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền XCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền XCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền XCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng XTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng XTK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng XTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng XTK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền XTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền XTK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền XTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền XTK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trị giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trị giá vốn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trị giá vốn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trị giá vốn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["SLBB TCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["SLBB TCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["SLBB TCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["SLBB TCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng TCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng TCK"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Số lượng TCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng TCK"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số tiền TCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền TCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền TCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền TCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Nhóm hàng"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void laydulieubcn(DataTable dt,string sql ,string loai)
        {
            DataTable temp = new DataTable();
            temp = gen.GetTable(sql);

            DataTable da = new DataTable();
                dt.Columns.Add("tenhang", Type.GetType("System.String"));
                dt.Columns.Add("dongia", Type.GetType("System.Double"));
                dt.Columns.Add("sodau", Type.GetType("System.Double"));
                dt.Columns.Add("tondau", Type.GetType("System.Double"));
                dt.Columns.Add("tientondau", Type.GetType("System.Double"));
                dt.Columns.Add("sonhap", Type.GetType("System.Double"));
                dt.Columns.Add("nhapdau", Type.GetType("System.Double"));
                dt.Columns.Add("tiennhapdau", Type.GetType("System.Double"));
                dt.Columns.Add("sonhapchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("nhapchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("tiennhapchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("soxuatchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("xuatchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("tienxuatchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("soxuatban", Type.GetType("System.Double"));
                dt.Columns.Add("xuatban", Type.GetType("System.Double"));
                dt.Columns.Add("trigiaton", Type.GetType("System.Double"));
                dt.Columns.Add("tienxuatban", Type.GetType("System.Double"));
                dt.Columns.Add("slbb", Type.GetType("System.Double"));
                dt.Columns.Add("sltoncuoi", Type.GetType("System.Double"));
                dt.Columns.Add("tttoncuoi", Type.GetType("System.Double"));
                dt.Columns.Add("nhomhang", Type.GetType("System.String"));
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("nhom", Type.GetType("System.String"));
                dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
                dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
                dt.Columns.Add("Công ty", Type.GetType("System.String"));
                dt.Columns.Add("Lãi gộp", Type.GetType("System.Double"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[25] = temp.Rows[i][24];
                dr[0] = temp.Rows[i][1];
                
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[1] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[2] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[3] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[4] = temp.Rows[i][5];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[5] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[6] = temp.Rows[i][7];
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[7] = temp.Rows[i][8];
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[8] = temp.Rows[i][9];
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[9] = temp.Rows[i][10];
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[10] = temp.Rows[i][11];
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[11] = temp.Rows[i][12];
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[12] = temp.Rows[i][13];
                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                    dr[13] = temp.Rows[i][14];
                if (Double.Parse(temp.Rows[i][15].ToString()) != 0)
                    dr[14] = temp.Rows[i][15];
                if (Double.Parse(temp.Rows[i][16].ToString()) != 0)
                    dr[15] = temp.Rows[i][16];
                if (Double.Parse(temp.Rows[i][17].ToString()) != 0)
                    dr[16] = temp.Rows[i][17];
                if (Double.Parse(temp.Rows[i][18].ToString()) != 0)
                    dr[17] = temp.Rows[i][18];
                if (Double.Parse(temp.Rows[i][19].ToString()) != 0)
                    dr[18] = temp.Rows[i][19];
                if (Double.Parse(temp.Rows[i][20].ToString()) != 0)
                    dr[19] = temp.Rows[i][20];
                if (Double.Parse(temp.Rows[i][21].ToString()) != 0)
                    dr[20] = temp.Rows[i][21];
                dr[21] = temp.Rows[i][22].ToString() + " " + temp.Rows[i][23].ToString();
                dr[22] = temp.Rows[i][0].ToString();
                dr[23] = temp.Rows[i][22].ToString();
                dr[24] = temp.Rows[i][23].ToString();
                dr[26] = temp.Rows[i][25].ToString();
                if (Double.Parse(temp.Rows[i][18].ToString()) != Double.Parse(temp.Rows[i][17].ToString()))
                    dr[27] = (Double.Parse(temp.Rows[i][18].ToString()) - Double.Parse(temp.Rows[i][17].ToString())).ToString();
                dt.Rows.Add(dr);
            }

        }

        public void laydulieu(DataTable dt,string sql,string loai)
        {
            DataTable temp = new DataTable();
            temp = gen.GetTable(sql);

            DataTable da = new DataTable();
            if (loai == "tsbtbctktttdvtong" || loai=="tsbtbctktsltong")
            {
                dt.Columns.Add("tenhang", Type.GetType("System.String"));
                dt.Columns.Add("dongia", Type.GetType("System.Double"));
                dt.Columns.Add("tondau", Type.GetType("System.Double"));
                dt.Columns.Add("tientondau", Type.GetType("System.Double"));
                dt.Columns.Add("nhapdau", Type.GetType("System.Double"));
                dt.Columns.Add("tiennhapdau", Type.GetType("System.Double"));
                dt.Columns.Add("nhapchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("tiennhapchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("xuatchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("tienxuatchuyen", Type.GetType("System.Double"));
                dt.Columns.Add("xuatban", Type.GetType("System.Double"));
                dt.Columns.Add("trigiaton", Type.GetType("System.Double"));
                dt.Columns.Add("tienxuatban", Type.GetType("System.Double"));
                dt.Columns.Add("slbb", Type.GetType("System.Double"));
                dt.Columns.Add("sltoncuoi", Type.GetType("System.Double"));
                dt.Columns.Add("tttoncuoi", Type.GetType("System.Double"));
                dt.Columns.Add("nhomhang", Type.GetType("System.String"));              
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("nhom", Type.GetType("System.String"));
                dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
                dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            }
            else
            {
                dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
                dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
                dt.Columns.Add("Số lượng ĐK", Type.GetType("System.Double"));
                dt.Columns.Add("Số tiền ĐK", Type.GetType("System.Double"));
                dt.Columns.Add("Số lượng NTK", Type.GetType("System.Double"));
                dt.Columns.Add("Số tiền NTK", Type.GetType("System.Double"));
                dt.Columns.Add("Số lượng NCK", Type.GetType("System.Double"));
                dt.Columns.Add("Số tiền NCK", Type.GetType("System.Double"));
                dt.Columns.Add("Số lượng XCK", Type.GetType("System.Double"));
                dt.Columns.Add("Số tiền XCK", Type.GetType("System.Double"));
                dt.Columns.Add("Số lượng XTK", Type.GetType("System.Double"));
                dt.Columns.Add("Trị giá vốn", Type.GetType("System.Double"));
                dt.Columns.Add("Số tiền XTK", Type.GetType("System.Double"));
                dt.Columns.Add("SLBB TCK", Type.GetType("System.Double"));
                dt.Columns.Add("Số lượng TCK", Type.GetType("System.Double"));
                dt.Columns.Add("Số tiền TCK", Type.GetType("System.Double"));
                dt.Columns.Add("Nhóm hàng", Type.GetType("System.String"));
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("Nhóm", Type.GetType("System.String"));
                dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
                dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            }
           
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[17] = temp.Rows[i][0];
                dr[0] = temp.Rows[i][1];

                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[1] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[2] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[3] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[4] = temp.Rows[i][5];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[5] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[6] = temp.Rows[i][7];
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[7] = temp.Rows[i][8];
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[8] = temp.Rows[i][9];
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[9] = temp.Rows[i][10];
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[10] = temp.Rows[i][11];
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[11] = temp.Rows[i][12];
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[12] = temp.Rows[i][13];
                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                    dr[13] = temp.Rows[i][14];
                if (Double.Parse(temp.Rows[i][15].ToString()) != 0)
                    dr[14] = temp.Rows[i][15];
                if (Double.Parse(temp.Rows[i][16].ToString()) != 0)
                    dr[15] = temp.Rows[i][16];
                dr[16] = temp.Rows[i][17].ToString() + " " + temp.Rows[i][18].ToString();
                dr[18] = temp.Rows[i][17].ToString();
                dr[19] = temp.Rows[i][18].ToString();
                dr[20] = temp.Rows[i][19].ToString();
                dt.Rows.Add(dr);
            }
        
        }

        public void inthekho(string ngaychungtu, string tsbt, string kho, string mahang,string congty,string userid, DataTable hang, DataTable khach)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();       
            dt.Columns.Add("ngay", Type.GetType("System.DateTime"));
            dt.Columns.Add("sophieu", Type.GetType("System.String"));
            dt.Columns.Add("tenkhach", Type.GetType("System.String"));
            dt.Columns.Add("sltondau", Type.GetType("System.Double"));
            dt.Columns.Add("slqdtondau", Type.GetType("System.Double"));
            dt.Columns.Add("tientondau", Type.GetType("System.Double"));
            dt.Columns.Add("slnhap", Type.GetType("System.Double"));
            dt.Columns.Add("slqdnhap", Type.GetType("System.Double"));
            dt.Columns.Add("sotiennhap", Type.GetType("System.Double"));
            dt.Columns.Add("slxuat", Type.GetType("System.Double"));
            dt.Columns.Add("slqdxuat", Type.GetType("System.Double"));
            dt.Columns.Add("sotienxuat", Type.GetType("System.Double"));
            dt.Columns.Add("sltoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("slqdtoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("sotientoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("hoadon", Type.GetType("System.String"));

            if(tsbt=="tsbtbctktttdv")
                temp = gen.GetTable("baocaotonkhothekhodonvi '" + kho + "','" + mahang + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            else if (tsbt == "tsbtbctktslcu")
                temp = gen.GetTable("baocaotonkhothekhonew '" + kho + "','" + mahang + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            else if (tsbt == "tsbtbkclgdgv")
            {
                temp = gen.GetTable("baocaotonkhothekhochenhlech '" + mahang + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
                kho = gen.GetString("select Top 1 StockID from Stock");
            }
            else
                temp = gen.GetTable("baocaotonkhothekho '" + kho + "','" + mahang + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            Double sl = 0; Double slqd = 0; Double sotien = 0;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (temp.Rows[i][1].ToString() == "")
                {
                    dr[2] = "Số tồn tháng trước";
                    if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    {
                        dr[3] = temp.Rows[i][3];
                        sl = sl + Double.Parse(temp.Rows[i][3].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    {
                        dr[4] = temp.Rows[i][4];
                        slqd = slqd + Double.Parse(temp.Rows[i][4].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    {
                        dr[5] = temp.Rows[i][5];
                        sotien = sotien + Double.Parse(temp.Rows[i][5].ToString());
                    }

                    if (sl != 0)
                        dr[12] = sl;
                    if (slqd != 0)
                        dr[13] = slqd;
                    if (sotien != 0)
                        dr[14] = sotien;

                }
                else
                {
                    dr[0] = temp.Rows[i][0];
                    dr[1] = temp.Rows[i][1];
                    dr[2] = temp.Rows[i][2];
                    if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    {
                        dr[6] = temp.Rows[i][6];
                        sl = sl + Double.Parse(temp.Rows[i][6].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    {
                        dr[7] = temp.Rows[i][7];
                        slqd = slqd + Double.Parse(temp.Rows[i][7].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    {
                        dr[8] = temp.Rows[i][8];
                        sotien = sotien + Double.Parse(temp.Rows[i][8].ToString());
                    }

                    if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    {
                        dr[9] = temp.Rows[i][9];
                        sl = sl - Double.Parse(temp.Rows[i][9].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    {
                        dr[10] = temp.Rows[i][10];
                        slqd = slqd - Double.Parse(temp.Rows[i][10].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    {
                        dr[11] = temp.Rows[i][11];
                        sotien = sotien - Double.Parse(temp.Rows[i][11].ToString());
                    }

                    if (sl != 0)
                        dr[12] = sl;
                    if (slqd != 0)
                        dr[13] = slqd;
                    if (sotien != 0)
                        dr[14] = sotien;
                    slqd = Double.Parse(slqd.ToString());
                    dr[15] = temp.Rows[i][12].ToString();
                }
                dt.Rows.Add(dr);
            }
            
            Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
            rp.getdata(dt);
            rp.getngaychungtu(ngaychungtu);
            rp.getkho(kho);
            rp.gethang(hang);
            rp.getkhach(khach);
            rp.gettenkho(mahang);
            rp.gettungay(congty);
            rp.getdenngay(userid);
            rp.gettsbt(tsbt+"thekho");
            rp.Show();
        }

        public void inthekholaigop(string ngaychungtu, string tsbt, string kho, string mahang)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();           
            dt.Columns.Add("sophieu", Type.GetType("System.String"));
            dt.Columns.Add("ngay", Type.GetType("System.DateTime"));
            dt.Columns.Add("tenkhach", Type.GetType("System.String"));
            dt.Columns.Add("slnhap", Type.GetType("System.Double"));
            dt.Columns.Add("slqdnhap", Type.GetType("System.Double"));
            dt.Columns.Add("sotiennhap", Type.GetType("System.Double"));
            dt.Columns.Add("slxuat", Type.GetType("System.Double"));
            dt.Columns.Add("slqdxuat", Type.GetType("System.Double"));
            dt.Columns.Add("sotienxuat", Type.GetType("System.Double"));
            
            if (tsbt == "tsbtbcthlthh")
                temp = gen.GetTable("bangketonkhomathangtheongay '" + kho + "','" + thang + "','" + nam + "','" + ngaychungtu + "','mahang','','" + mahang + "'");
            else if (tsbt=="tsbtlaigopkinhdoanh")
                temp = gen.GetTable("bangkelaigopkinhdoanh '" + kho + "','" + thang + "','" + nam + "','" + ngaychungtu + "','mahang','','" + mahang + "'");
           
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7];
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8];
                dt.Rows.Add(dr);
            }
            Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
            rp.getdata(dt);
            rp.getngaychungtu(ngaychungtu);
            rp.getkho(kho);
            rp.gettenkho(mahang);
            rp.gettsbt(tsbt + "chitiet");
            rp.ShowDialog();
        }

        public void intonghop(string ngaychungtu,string kho,string tsbt)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("tenkho", Type.GetType("System.String"));
            dt.Columns.Add("tondau", Type.GetType("System.Double"));
            dt.Columns.Add("tientondau", Type.GetType("System.Double"));
            dt.Columns.Add("nhapdau", Type.GetType("System.Double"));
            dt.Columns.Add("tiennhapdau", Type.GetType("System.Double"));
            dt.Columns.Add("nhapchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("tiennhapchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("xuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("tienxuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("xuatban", Type.GetType("System.Double"));
            dt.Columns.Add("trigiaton", Type.GetType("System.Double"));
            dt.Columns.Add("tienxuatban", Type.GetType("System.Double"));
            dt.Columns.Add("slbb", Type.GetType("System.Double"));
            dt.Columns.Add("sltoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("tttoncuoi", Type.GetType("System.Double"));
            temp = gen.GetTable("select c.StockCode,c.StockName,sum(BeginQuantityConvert),sum(BeginTotalAmount),sum(INQuantityConvert),sum(INTotalAmount),sum(INStockQuantityConvert),sum(INStockTotalAmount),sum(OUTStockQuantityConvert),sum(OUTStockTotalAmount),sum(OUTQuantityConvert),sum(CapitalValue),sum(OUTTotalAmount),sum(EndQuantity),sum(EndQuantityConvert),sum(EndTotalAmount)" +
                "from StockExits a, Stock b,Stock c where a.StockID=b.StockID and b.Parent=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' group by  c.StockCode,c.StockName");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString() +" - "+ temp.Rows[i][1].ToString();

                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[1] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[2] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[3] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[4] = temp.Rows[i][5];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[5] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[6] = temp.Rows[i][7];
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[7] = temp.Rows[i][8];
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[8] = temp.Rows[i][9];
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[9] = temp.Rows[i][10];
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[10] = temp.Rows[i][11];
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[11] = temp.Rows[i][12];
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[12] = temp.Rows[i][13];
                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                    dr[13] = temp.Rows[i][14];
                if (Double.Parse(temp.Rows[i][15].ToString()) != 0)
                    dr[14] = temp.Rows[i][15];
                dt.Rows.Add(dr);
            }
            Frm_rpbaocaotonkho rp = new Frm_rpbaocaotonkho();
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt+"tong");
            rp.Show();
        }

        public void baocaonhapxuatthucte(string tungay, string denngay,string kho, string tsbt)
        {            
            Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
            rp.gettenkho(gen.GetString("select StockCode+' - '+ StockName from hamaco.dbo.Stock with (NOLOCK) where StockID='" + kho + "'"));
            rp.getdata(gen.GetTable("baocaotonkhonhapxuatthucte'" + kho + "','" + tungay + "','" + denngay + "'"));
            rp.gettungay(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt);
            rp.getkho(kho);
            rp.Show();
        }
    }
}
