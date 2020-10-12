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
    class baocaotonkhothucte
    {
        gencon gen = new gencon();
        public void loadbctktsl(DevExpress.XtraGrid.GridControl lvpq, GridView view, string ngaychungtu, string tsbt, string kho)
        {
            DataTable dt = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            string sql = "";

            if (gen.GetString("select CompanyTaxCode from Center") == "")
            {
                if (tsbt == "tsbtbctktttt")
                    gen.ExcuteNonquery("baocaotonkhotheothangnew '" + ngaychungtu + "','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
                else if (tsbt == "tsbtbctktttttdv")
                    gen.ExcuteNonquery("baocaotonkhotheothangtheodonvi '" + ngaychungtu + "','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
                else
                    gen.ExcuteNonquery("baocaotonkhotheothangtoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            }

            if (tsbt == "tsbtbctktttt")
                sql = "baocaotonkhotheothangthucte '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
            else if (tsbt == "tsbtbctktttttdv")
                sql = "baocaotonkhotheothangthuctetheodonvi '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
            else
                sql = "baocaotonkhotheothangthuctetoancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";               

            laydulieu(dt, sql);
            view.Columns.Clear();
            lvpq.DataSource = dt;

            view.OptionsBehavior.Editable = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            view.Columns[24].Visible = false;
            view.Columns[14].Visible = false;
            view.OptionsView.ColumnAutoWidth = false;

            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "slbbdau";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["slbbdau"];

            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "sldau";
            item1.DisplayFormat = "{0:n2}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["sldau"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "slbbnhap";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["slbbnhap"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "slbbchuyen";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["slbbchuyen"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "slchuyen";
            item4.DisplayFormat = "{0:n2}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["slchuyen"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "slbbxuatchuyen";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["slbbxuatchuyen"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "slxuatchuyen";
            item6.DisplayFormat = "{0:n2}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["slxuatchuyen"];

            GridGroupSummaryItem item7 = new GridGroupSummaryItem();
            item7.FieldName = "slbbxuat";
            item7.DisplayFormat = "{0:n0}";
            item7.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item7);
            item7.ShowInGroupColumnFooter = view.Columns["slbbxuat"];

            GridGroupSummaryItem item8 = new GridGroupSummaryItem();
            item8.FieldName = "slxuat";
            item8.DisplayFormat = "{0:n2}";
            item8.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item8);
            item8.ShowInGroupColumnFooter = view.Columns["slxuat"];

            GridGroupSummaryItem item9 = new GridGroupSummaryItem();
            item9.FieldName = "slbbton";
            item9.DisplayFormat = "{0:n0}";
            item9.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item9);
            item9.ShowInGroupColumnFooter = view.Columns["slbbton"];

            GridGroupSummaryItem item10 = new GridGroupSummaryItem();
            item10.FieldName = "slton";
            item10.DisplayFormat = "{0:n2}";
            item10.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item10);
            item10.ShowInGroupColumnFooter = view.Columns["slton"];

            GridGroupSummaryItem item11 = new GridGroupSummaryItem();
            item11.FieldName = "slbbkmtd";
            item11.DisplayFormat = "{0:n0}";
            item11.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item11);
            item11.ShowInGroupColumnFooter = view.Columns["slbbkmtd"];

            GridGroupSummaryItem item12 = new GridGroupSummaryItem();
            item12.FieldName = "slkmtd";
            item12.DisplayFormat = "{0:n2}";
            item12.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item12);
            item12.ShowInGroupColumnFooter = view.Columns["slkmtd"];

            GridGroupSummaryItem item13 = new GridGroupSummaryItem();
            item13.FieldName = "slbbnhapkm";
            item13.DisplayFormat = "{0:n0}";
            item13.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item13);
            item13.ShowInGroupColumnFooter = view.Columns["slbbnhapkm"];

            GridGroupSummaryItem item14 = new GridGroupSummaryItem();
            item14.FieldName = "slnhapkm";
            item14.DisplayFormat = "{0:n2}";
            item14.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item14);
            item14.ShowInGroupColumnFooter = view.Columns["slnhapkm"];

            GridGroupSummaryItem item15 = new GridGroupSummaryItem();
            item15.FieldName = "slbbxuatkm";
            item15.DisplayFormat = "{0:n0}";
            item15.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item15);
            item15.ShowInGroupColumnFooter = view.Columns["slbbxuatkm"];

            GridGroupSummaryItem item16 = new GridGroupSummaryItem();
            item16.FieldName = "slxuatkm";
            item16.DisplayFormat = "{0:n2}";
            item16.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item16);
            item16.ShowInGroupColumnFooter = view.Columns["slxuatkm"];

            GridGroupSummaryItem item17 = new GridGroupSummaryItem();
            item17.FieldName = "slbbtonkm";
            item17.DisplayFormat = "{0:n0}";
            item17.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item17);
            item17.ShowInGroupColumnFooter = view.Columns["slbbtonkm"];

            GridGroupSummaryItem item18 = new GridGroupSummaryItem();
            item18.FieldName = "sltonkm";
            item18.DisplayFormat = "{0:n2}";
            item18.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item18);
            item18.ShowInGroupColumnFooter = view.Columns["sltonkm"];


            view.Columns["mahang"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["tenhang"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            try
            {
                view.Columns["Giá trị"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
                view.Columns["Giá trị"].Visible = false;
            }
            catch { }
            view.Columns["slton"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["slbbton"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
           

            view.Columns["mahang"].Width = 120;
            view.Columns["tenhang"].Width = 250;
            view.Columns["slbbdau"].Width = 120;
            view.Columns["sldau"].Width = 120;
            view.Columns["slbbnhap"].Width = 120;
            view.Columns["slnhap"].Width = 120;
            view.Columns["slbbchuyen"].Width = 120;

            view.Columns["slchuyen"].Width = 120;
            view.Columns["slbbxuatchuyen"].Width = 120;
            view.Columns["slxuatchuyen"].Width = 120;
            view.Columns["slbbxuat"].Width = 120;

            view.Columns["slxuat"].Width = 120;
            view.Columns["slbbton"].Width = 120;
            view.Columns["slton"].Width = 120;
            view.Columns[25].Width = 120;

            view.Columns["slbbkmtd"].Width = 120;
            view.Columns["slkmtd"].Width = 120;
            view.Columns["slbbnhapkm"].Width = 120;
            view.Columns["slnhapkm"].Width = 120;
            view.Columns["slbbxuatkm"].Width = 120;
            view.Columns["slxuatkm"].Width = 120;
            view.Columns["slbbtonkm"].Width = 120;
            view.Columns["sltonkm"].Width = 120;

            view.Columns["slbbdau"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbdau"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbdau"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbdau"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["sldau"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["sldau"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["sldau"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["sldau"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbnhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbnhap"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbnhap"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbnhap"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["slnhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slnhap"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["slnhap"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slnhap"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbchuyen"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbchuyen"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbchuyen"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbchuyen"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["slchuyen"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slchuyen"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["slchuyen"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slchuyen"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbxuatchuyen"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbxuatchuyen"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbxuatchuyen"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbxuatchuyen"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["slxuatchuyen"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slxuatchuyen"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["slxuatchuyen"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slxuatchuyen"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbxuat"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbxuat"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbxuat"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbxuat"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["slxuat"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slxuat"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["slxuat"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slxuat"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbton"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbton"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbton"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbton"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["slton"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slton"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["slton"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slton"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbkmtd"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbkmtd"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbkmtd"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbkmtd"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["slkmtd"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slkmtd"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["slkmtd"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slkmtd"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbnhapkm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbnhapkm"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbnhapkm"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbnhapkm"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["slnhapkm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slnhapkm"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["slnhapkm"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slnhapkm"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbxuatkm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbxuatkm"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbxuatkm"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbxuatkm"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["slxuatkm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slxuatkm"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["slxuatkm"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slxuatkm"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["slbbtonkm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["slbbtonkm"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["slbbtonkm"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["slbbtonkm"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["sltonkm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["sltonkm"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["sltonkm"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["sltonkm"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns[25].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns[25].DisplayFormat.FormatString = "{0:n0}";
            view.Columns[25].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[25].SummaryItem.DisplayFormat = "{0:n0}";


            view.Columns["nhomhang"].GroupIndex = 0;
            view.ExpandAllGroups();

        }

        public void inbctk(string ngaychungtu, string tsbt, string kho, GridView view)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("tenhang", Type.GetType("System.String"));
            dt.Columns.Add("slbbdau", Type.GetType("System.Double"));
            dt.Columns.Add("sldau", Type.GetType("System.Double"));
            dt.Columns.Add("slbbnhap", Type.GetType("System.Double"));
            dt.Columns.Add("slnhap", Type.GetType("System.Double"));
            dt.Columns.Add("slbbchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("slchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("slbbxuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("slxuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("slbbxuat", Type.GetType("System.Double"));
            dt.Columns.Add("slxuat", Type.GetType("System.Double"));
            dt.Columns.Add("slbbton", Type.GetType("System.Double"));
            dt.Columns.Add("slton", Type.GetType("System.Double"));
            dt.Columns.Add("nhomhang", Type.GetType("System.String"));
            dt.Columns.Add("tennhom", Type.GetType("System.String"));
            dt.Columns.Add("mahang", Type.GetType("System.String"));

            string tenkho = "";
            if (tsbt == "tsbtbctktttt")
            {
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
            }
            else if (tsbt == "tsbtbctktttttdv")
            {
                tenkho = gen.GetString("select BranchName from Branch where BranchID='" + kho + "'");
                string makho = gen.GetString("select BranchCode from Branch where BranchID='" + kho + "'");
                tenkho = ("ĐƠN VỊ " + makho + " - " + tenkho).ToUpper();
            }


            for (int i = 0; i < view.DataRowCount; i++)
            {
                DataRow dr = dt.NewRow();

                dr[0] = view.GetRowCellValue(i, "tenhang").ToString();
                if (view.GetRowCellValue(i, "slbbdau").ToString() != "")
                    dr[1] = view.GetRowCellValue(i, "slbbdau").ToString();
                if (view.GetRowCellValue(i, "sldau").ToString() != "")
                    dr[2] = view.GetRowCellValue(i, "sldau").ToString();
                if (view.GetRowCellValue(i, "slbbnhap").ToString() != "")
                    dr[3] = view.GetRowCellValue(i, "slbbnhap").ToString();
                if (view.GetRowCellValue(i, "slnhap").ToString() != "")
                    dr[4] = view.GetRowCellValue(i, "slnhap").ToString();
                if (view.GetRowCellValue(i, "slbbchuyen").ToString() != "")
                    dr[5] = view.GetRowCellValue(i, "slbbchuyen").ToString();
                if (view.GetRowCellValue(i, "slchuyen").ToString() != "")
                    dr[6] = view.GetRowCellValue(i, "slchuyen").ToString();
                if (view.GetRowCellValue(i, "slbbxuatchuyen").ToString() != "")
                    dr[7] = view.GetRowCellValue(i, "slbbxuatchuyen").ToString();
                if (view.GetRowCellValue(i, "slxuatchuyen").ToString() != "")
                    dr[8] = view.GetRowCellValue(i, "slxuatchuyen").ToString();
                if (view.GetRowCellValue(i, "slbbxuat").ToString() != "")
                    dr[9] = view.GetRowCellValue(i, "slbbxuat").ToString();
                if (view.GetRowCellValue(i, "slxuat").ToString() != "")
                    dr[10] = view.GetRowCellValue(i, "slxuat").ToString();
                if (view.GetRowCellValue(i, "slbbton").ToString() != "")
                    dr[11] = view.GetRowCellValue(i, "slbbton").ToString();
                if (view.GetRowCellValue(i, "slton").ToString() != "")
                    dr[12] = view.GetRowCellValue(i, "slton").ToString();
                dr[13] = view.GetRowCellValue(i, "nhomhang").ToString();
                dr[14] = view.GetRowCellValue(i, "tennhom").ToString();
                dr[15] = view.GetRowCellValue(i, "mahang").ToString();
                dt.Rows.Add(dr);
            }

            Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
            rp.gettenkho(tenkho);
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }





        public void inbctkcthgb(string ngaychungtu, string tsbt, string kho)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Công ty", Type.GetType("System.Double"));
            dt.Columns.Add("TL Công ty", Type.GetType("System.Double"));
            dt.Columns.Add("Hàng gửi", Type.GetType("System.Double"));
            dt.Columns.Add("TL hàng gửi", Type.GetType("System.Double"));
            dt.Columns.Add("Tồn cuối", Type.GetType("System.Double"));
            dt.Columns.Add("TL tồn cuối", Type.GetType("System.Double"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            if (tsbt == "tsbtbctktttttdvloai")
                temp = gen.GetTable("baocaotonkhotheothangthuctetheodonvichitiet '" + kho + "','" + DateTime.Parse(ngaychungtu).Month + "','" + DateTime.Parse(ngaychungtu).Year + "','0'");
            else
                temp = gen.GetTable("baocaotonkhotheothangthuctetheodonvichitiet '" + kho + "','" + DateTime.Parse(ngaychungtu).Month + "','" + DateTime.Parse(ngaychungtu).Year + "','1'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
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
                dr[8] = temp.Rows[i][8];
                dr[9] = temp.Rows[i][9];
                dt.Rows.Add(dr);                
            }
            Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();            
            rp.gettenkho(gen.GetString("select N'ĐƠN VỊ '+BranchCode+' '+BranchName from Branch where BranchID='" + kho + "'").ToUpper());
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt+"hanggui");
            rp.Show();
        }

        public void inbctkkm(string ngaychungtu, string tsbt, string kho, GridView view)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("tenhang", Type.GetType("System.String"));
            dt.Columns.Add("slbbkmtd", Type.GetType("System.Double"));
            dt.Columns.Add("slkmtd", Type.GetType("System.Double"));
            dt.Columns.Add("slbbnhapkm", Type.GetType("System.Double"));
            dt.Columns.Add("slnhapkm", Type.GetType("System.Double"));
            dt.Columns.Add("slbbxuatkm", Type.GetType("System.Double"));
            dt.Columns.Add("slxuatkm", Type.GetType("System.Double"));
            dt.Columns.Add("slbbtonkm", Type.GetType("System.Double"));
            dt.Columns.Add("sltonkm", Type.GetType("System.Double"));
            dt.Columns.Add("nhomhang", Type.GetType("System.String"));
            dt.Columns.Add("tennhom", Type.GetType("System.String"));
            dt.Columns.Add("mahang", Type.GetType("System.String"));

            temp.Columns.Add("tenhang", Type.GetType("System.String"));
            temp.Columns.Add("slbbkmtd", Type.GetType("System.Double"));
            temp.Columns.Add("slkmtd", Type.GetType("System.Double"));
            temp.Columns.Add("slbbnhapkm", Type.GetType("System.Double"));
            temp.Columns.Add("slnhapkm", Type.GetType("System.Double"));
            temp.Columns.Add("slbbxuatkm", Type.GetType("System.Double"));
            temp.Columns.Add("slxuatkm", Type.GetType("System.Double"));
            temp.Columns.Add("slbbtonkm", Type.GetType("System.Double"));
            temp.Columns.Add("sltonkm", Type.GetType("System.Double"));
            temp.Columns.Add("nhomhang", Type.GetType("System.String"));
            temp.Columns.Add("tennhom", Type.GetType("System.String"));
            temp.Columns.Add("mahang", Type.GetType("System.String"));

            string tenkho = "";
            if (tsbt == "tsbtbctktttt" || tsbt == "tsbtbctktttthg")
            {
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
            }
            else if (tsbt == "tsbtbctktttttdv")
            {
                tenkho = gen.GetString("select BranchName from Branch where BranchID='" + kho + "'");
                string makho = gen.GetString("select BranchCode from Branch where BranchID='" + kho + "'");
                tenkho = ("ĐƠN VỊ " + makho + " - " + tenkho).ToUpper();
            }

            if (tsbt == "tsbtbctktttthg")
            {
                for (int i = 0; i < view.DataRowCount; i++)
                {
                    DataRow dr = temp.NewRow();
                    dr[0] = view.GetRowCellValue(i, "tenhang").ToString();

                    if (view.GetRowCellValue(i, "slbbdau").ToString() != "")
                    {
                        dr[1] = view.GetRowCellValue(i, "slbbdau").ToString();
                        if (view.GetRowCellValue(i, "slbbkmtd").ToString() != "")
                            dr[1] = Double.Parse(view.GetRowCellValue(i, "slbbdau").ToString()) - Double.Parse(view.GetRowCellValue(i, "slbbkmtd").ToString());
                    }
                    if (view.GetRowCellValue(i, "sldau").ToString() != "")
                    {
                        dr[2] = view.GetRowCellValue(i, "sldau").ToString();
                        if (view.GetRowCellValue(i, "slkmtd").ToString() != "")
                            dr[2] = Double.Parse(view.GetRowCellValue(i, "sldau").ToString()) - Double.Parse(view.GetRowCellValue(i, "slkmtd").ToString());
                    }
                    if (view.GetRowCellValue(i, "slbbnhap").ToString() != "" || (view.GetRowCellValue(i, "slbbchuyen").ToString() != ""))
                    {
                        try
                        {
                            dr[3] = Double.Parse(view.GetRowCellValue(i, "slbbnhap").ToString());
                        }
                        catch { dr[3] = 0; }
                        if (view.GetRowCellValue(i, "slbbchuyen").ToString() != "")
                            dr[3] = Double.Parse(dr[3].ToString()) + Double.Parse(view.GetRowCellValue(i, "slbbchuyen").ToString());
                        if (view.GetRowCellValue(i, "slbbnhapkm").ToString() != "")
                            dr[3] = Double.Parse(dr[3].ToString()) - Double.Parse(view.GetRowCellValue(i, "slbbnhapkm").ToString());
                    }
                    if (view.GetRowCellValue(i, "slnhap").ToString() != "" || (view.GetRowCellValue(i, "slchuyen").ToString() != ""))
                    {
                        try
                        {
                            dr[4] = Double.Parse(view.GetRowCellValue(i, "slnhap").ToString());
                        }
                        catch { dr[4] = 0; }
                        if (view.GetRowCellValue(i, "slchuyen").ToString() != "")
                            dr[4] = Double.Parse(dr[4].ToString()) + Double.Parse(view.GetRowCellValue(i, "slchuyen").ToString());
                        if (view.GetRowCellValue(i, "slnhapkm").ToString() != "")
                            dr[4] = Double.Parse(dr[4].ToString()) - Double.Parse(view.GetRowCellValue(i, "slnhapkm").ToString());
                    }

                    if (view.GetRowCellValue(i, "slbbxuat").ToString() != "" || view.GetRowCellValue(i, "slbbxuatchuyen").ToString() != "")
                    {
                        try
                        {
                            dr[5] = Double.Parse(view.GetRowCellValue(i, "slbbxuat").ToString());
                        }
                        catch { dr[5] = 0; }
                        if (view.GetRowCellValue(i, "slbbxuatchuyen").ToString() != "")
                            dr[5] = Double.Parse(dr[5].ToString()) + Double.Parse(view.GetRowCellValue(i, "slbbxuatchuyen").ToString());
                        if (view.GetRowCellValue(i, "slbbxuatkm").ToString() != "")
                            dr[5] = Double.Parse(dr[5].ToString()) - Double.Parse(view.GetRowCellValue(i, "slbbxuatkm").ToString());
                    }
                    if (view.GetRowCellValue(i, "slxuat").ToString() != "" || (view.GetRowCellValue(i, "slxuatchuyen").ToString() != ""))
                    {
                        try
                        {
                            dr[6] = Double.Parse(view.GetRowCellValue(i, "slxuat").ToString());
                        }
                        catch { dr[6] = 0; }
                        if (view.GetRowCellValue(i, "slxuatchuyen").ToString() != "")
                            dr[6] = Double.Parse(dr[6].ToString()) + Double.Parse(view.GetRowCellValue(i, "slxuatchuyen").ToString());
                        if (view.GetRowCellValue(i, "slxuatkm").ToString() != "")
                            dr[6] = Double.Parse(dr[6].ToString()) - Double.Parse(view.GetRowCellValue(i, "slxuatkm").ToString());
                    }
                    if (view.GetRowCellValue(i, "slbbton").ToString() != "")
                    {
                        dr[7] = view.GetRowCellValue(i, "slbbton").ToString();
                        if (view.GetRowCellValue(i, "slbbtonkm").ToString() != "")
                            dr[7] = Double.Parse(dr[7].ToString()) - Double.Parse(view.GetRowCellValue(i, "slbbtonkm").ToString());
                    }
                    if (view.GetRowCellValue(i, "slton").ToString() != "")
                    {
                        dr[8] = view.GetRowCellValue(i, "slton").ToString();
                        if (view.GetRowCellValue(i, "sltonkm").ToString() != "")
                            dr[8] = Double.Parse(dr[8].ToString()) - Double.Parse(view.GetRowCellValue(i, "sltonkm").ToString());
                    }
                    dr[9] = view.GetRowCellValue(i, "nhomhang").ToString();
                    dr[10] = view.GetRowCellValue(i, "tennhom").ToString();
                    dr[11] = view.GetRowCellValue(i, "mahang").ToString();
                    temp.Rows.Add(dr);
                }

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if ((temp.Rows[i][1].ToString() != "0" && temp.Rows[i][1].ToString() != "") || (temp.Rows[i][2].ToString() != "0" && temp.Rows[i][2].ToString() != "") || (temp.Rows[i][3].ToString() != "0" && temp.Rows[i][3].ToString() != "") || (temp.Rows[i][4].ToString() != "0" && temp.Rows[i][4].ToString() != "") || (temp.Rows[i][5].ToString() != "0" && temp.Rows[i][5].ToString() != "") || (temp.Rows[i][6].ToString() != "0" && temp.Rows[i][6].ToString() != "") || (temp.Rows[i][7].ToString() != "0" && temp.Rows[i][7].ToString() != "") || (temp.Rows[i][8].ToString() != "0" && temp.Rows[i][8].ToString() != ""))
                    {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0];
                    dr[1] = temp.Rows[i][1];
                    dr[2] = temp.Rows[i][2];
                    dr[3] = temp.Rows[i][3];
                    dr[4] = temp.Rows[i][4];
                    dr[5] = temp.Rows[i][5];
                    dr[6] = temp.Rows[i][6];
                    dr[7] = temp.Rows[i][7];
                    dr[8] = temp.Rows[i][8];
                    dr[9] = temp.Rows[i][9];
                    dr[10] = temp.Rows[i][10];
                    dr[11] = temp.Rows[i][11];
                    dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                for (int i = 0; i < view.DataRowCount; i++)
                {
                    if (view.GetRowCellValue(i, "slbbkmtd").ToString() != "" || view.GetRowCellValue(i, "slkmtd").ToString() != "" || view.GetRowCellValue(i, "slbbnhapkm").ToString() != "" || view.GetRowCellValue(i, "slnhapkm").ToString() != "" || view.GetRowCellValue(i, "slbbxuatkm").ToString() != "" || view.GetRowCellValue(i, "slxuatkm").ToString() != "" || view.GetRowCellValue(i, "slbbtonkm").ToString() != "" || view.GetRowCellValue(i, "sltonkm").ToString() != "")
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = view.GetRowCellValue(i, "tenhang").ToString();
                        if (view.GetRowCellValue(i, "slbbkmtd").ToString() != "")
                            dr[1] = view.GetRowCellValue(i, "slbbkmtd").ToString();
                        if (view.GetRowCellValue(i, "slkmtd").ToString() != "")
                            dr[2] = view.GetRowCellValue(i, "slkmtd").ToString();
                        if (view.GetRowCellValue(i, "slbbnhapkm").ToString() != "")
                            dr[3] = view.GetRowCellValue(i, "slbbnhapkm").ToString();
                        if (view.GetRowCellValue(i, "slnhapkm").ToString() != "")
                            dr[4] = view.GetRowCellValue(i, "slnhapkm").ToString();
                        if (view.GetRowCellValue(i, "slbbxuatkm").ToString() != "")
                            dr[5] = view.GetRowCellValue(i, "slbbxuatkm").ToString();
                        if (view.GetRowCellValue(i, "slxuatkm").ToString() != "")
                            dr[6] = view.GetRowCellValue(i, "slxuatkm").ToString();
                        if (view.GetRowCellValue(i, "slbbtonkm").ToString() != "")
                            dr[7] = view.GetRowCellValue(i, "slbbtonkm").ToString();
                        if (view.GetRowCellValue(i, "sltonkm").ToString() != "")
                            dr[8] = view.GetRowCellValue(i, "sltonkm").ToString();
                        dr[9] = view.GetRowCellValue(i, "nhomhang").ToString();
                        dr[10] = view.GetRowCellValue(i, "tennhom").ToString();
                        dr[11] = view.GetRowCellValue(i, "mahang").ToString();
                        dt.Rows.Add(dr);
                    }
                }
            }

            Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
            rp.gettenkho(tenkho);
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt+"km");
            rp.Show();
        }

        public void loadbctkthdtndn(DateEdit tungay, DateEdit denngay, string kho, string tsbt)
        {
            DataTable dt = new DataTable();
            string thang = DateTime.Parse(tungay.EditValue.ToString()).Month.ToString();
            string nam = DateTime.Parse(tungay.EditValue.ToString()).Year.ToString();

            string thangtruoc = tungay.DateTime.AddMonths(-1).Month.ToString();
            string namtruoc = tungay.DateTime.AddMonths(-1).Year.ToString();

            string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
            string denngaydau = DateTime.Parse(tungay.DateTime.ToShortDateString()).AddSeconds(-1).ToString();

            string tungaycuoi = DateTime.Parse(tungay.DateTime.ToShortDateString()).ToString();
            string denngaycuoi = DateTime.Parse(denngay.DateTime.AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            string sql = "";
            string tenkho = "";
            if (tsbt == "tsbtbctktttndn")
            {
                sql = "baocaotonkhotungaydenngaythucte '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO "+makho + " - " + tenkho).ToUpper();
            }
            else if (tsbt == "tsbtbctktttndntpxk")
            {
                sql = "baocaotonkhotungaydenngaythuctetndn '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
            }
            else if (tsbt == "tsbtbctktttndntaidv")
            {
                sql = "baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','0'";
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
            }
            else if (tsbt == "tsbtbctktttndntct" || tsbt == "tsbtbctktttndnhgtct")
            {
                sql = "baocaotonkhotungaydenngaythuctetoancongty '" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";
                tenkho = "";
            }
            else
            {
                sql = "baocaotonkhotungaydenngaythuctetheodonvi '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";
                tenkho = gen.GetString("select BranchName from Branch where BranchID='" + kho + "'");
                string makho = gen.GetString("select BranchCode from Branch where BranchID='" + kho + "'");
                tenkho = ("ĐƠN VỊ " + makho + " - " + tenkho).ToUpper();
            }
            laydulieu(dt, sql);
            Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
            rp.gettenkho(tenkho);
            rp.getdata(dt);
            rp.getkho(kho);
            rp.gettungay(tungay.EditValue.ToString());
            rp.getdenngay(denngay.EditValue.ToString());
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbctkthdtndn(DateEdit tungay, DateEdit denngay, string makhach, string tsbt, string userid)
        {
            DataTable dt = new DataTable();
            string thang = DateTime.Parse(tungay.EditValue.ToString()).Month.ToString();
            string nam = DateTime.Parse(tungay.EditValue.ToString()).Year.ToString();

            string thangtruoc = tungay.DateTime.AddMonths(-1).Month.ToString();
            string namtruoc = tungay.DateTime.AddMonths(-1).Year.ToString();

            string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
            string denngaydau = DateTime.Parse(tungay.DateTime.ToShortDateString()).AddSeconds(-1).ToString();

            string tungaycuoi = DateTime.Parse(tungay.DateTime.ToShortDateString()).ToString();
            string denngaycuoi = DateTime.Parse(denngay.DateTime.AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            string sql = "";
            string tenkho = "";
            if (tsbt == "bchgkh")
            {
                sql = "baocaotonkhotungaydenngayhanggui '" + makhach + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','0','" + userid + "'";
                tenkho = gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
            }
            else if (tsbt == "bchgkhkhach")
            {
                sql = "baocaotonkhotungaydenngayhanggui '" + makhach + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','1','" + userid + "'";
                tenkho = gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
            }
            
            laydulieu(dt, sql);
            Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
            rp.gettenkho(tenkho);
            rp.getdata(dt);
            rp.getkho(userid);
            rp.gettungay(tungay.EditValue.ToString());
            rp.getdenngay(denngay.EditValue.ToString());
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void laydulieu(DataTable dt, string sql)
        {
            DataTable temp = new DataTable();
            dt.Columns.Add("tenhang", Type.GetType("System.String"));
            dt.Columns.Add("slbbdau", Type.GetType("System.Double"));
            dt.Columns.Add("sldau", Type.GetType("System.Double"));
            dt.Columns.Add("slbbnhap", Type.GetType("System.Double"));
            dt.Columns.Add("slnhap", Type.GetType("System.Double"));
            dt.Columns.Add("slbbchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("slchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("slbbxuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("slxuatchuyen", Type.GetType("System.Double"));
            dt.Columns.Add("slbbxuat", Type.GetType("System.Double"));
            dt.Columns.Add("slxuat", Type.GetType("System.Double"));
            dt.Columns.Add("slbbton", Type.GetType("System.Double"));
            dt.Columns.Add("slton", Type.GetType("System.Double"));
            dt.Columns.Add("nhomhang", Type.GetType("System.String"));
            dt.Columns.Add("tennhom", Type.GetType("System.String"));
            dt.Columns.Add("mahang", Type.GetType("System.String"));

            dt.Columns.Add("slbbkmtd", Type.GetType("System.Double"));
            dt.Columns.Add("slkmtd", Type.GetType("System.Double"));
            dt.Columns.Add("slbbnhapkm", Type.GetType("System.Double"));
            dt.Columns.Add("slnhapkm", Type.GetType("System.Double"));
            dt.Columns.Add("slbbxuatkm", Type.GetType("System.Double"));
            dt.Columns.Add("slxuatkm", Type.GetType("System.Double"));
            dt.Columns.Add("slbbtonkm", Type.GetType("System.Double"));
            dt.Columns.Add("sltonkm", Type.GetType("System.Double"));
            dt.Columns.Add("ID", Type.GetType("System.String"));

            dt.Columns["tenhang"].Caption="Tên hàng";
            dt.Columns["slbbdau"].Caption="SLBB TĐK";
            dt.Columns["sldau"].Caption="Số lượng TĐK";
            dt.Columns["slbbnhap"].Caption="SLBB NTK";
            dt.Columns["slnhap"].Caption="Số lượng NTK";
            dt.Columns["slbbchuyen"].Caption="SLBB NCK";
            dt.Columns["slchuyen"].Caption="Số lượng NCK";
            dt.Columns["slbbxuatchuyen"].Caption="SLBB XCK";
            dt.Columns["slxuatchuyen"].Caption="Số lượng XCK";
            dt.Columns["slbbxuat"].Caption="SLBB XTK";
            dt.Columns["slxuat"].Caption="Số lượng XTK";
            dt.Columns["slbbton"].Caption="SLBB TCK";
            dt.Columns["slton"].Caption="Số lượng TCK";
            dt.Columns["mahang"].Caption="Mã hàng";
            dt.Columns["nhomhang"].Caption = "Nhóm hàng";

            dt.Columns["slbbkmtd"].Caption="SLBB TĐKM";
            dt.Columns["slkmtd"].Caption="Số lượng TĐKM";
            dt.Columns["slbbnhapkm"].Caption="SLBB NKM";
            dt.Columns["slnhapkm"].Caption="Số lượng NKM";
            dt.Columns["slbbxuatkm"].Caption="SLBB XKM";
            dt.Columns["slxuatkm"].Caption="SLBB XKM";
            dt.Columns["slbbtonkm"].Caption="SLBB TCKM";
            dt.Columns["sltonkm"].Caption="Số lượng TCKM";
               
         

            temp = gen.GetTable(sql);
            if (temp.Columns.Count > 28)
            {
                dt.Columns.Add("slbbdau1", Type.GetType("System.Double"));
                dt.Columns.Add("sldau1", Type.GetType("System.Double"));
                dt.Columns.Add("slbbnhap1", Type.GetType("System.Double"));
                dt.Columns.Add("slnhap1", Type.GetType("System.Double"));
                dt.Columns.Add("slbbxuat1", Type.GetType("System.Double"));
                dt.Columns.Add("slxuat1", Type.GetType("System.Double"));
                dt.Columns.Add("slbbton1", Type.GetType("System.Double"));
                dt.Columns.Add("slton1", Type.GetType("System.Double"));

            }
            else
            {
                dt.Columns.Add("Giá trị", Type.GetType("System.Double"));
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[15] = temp.Rows[i][16];
                dr[0] = temp.Rows[i][1];
                dr[24] = temp.Rows[i][0];
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
                dr[13] = temp.Rows[i][14].ToString() + " " + temp.Rows[i][15].ToString();
                dr[14] = temp.Rows[i][15].ToString();

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
                if (Double.Parse(temp.Rows[i][22].ToString()) != 0)
                    dr[21] = temp.Rows[i][22];
                if (Double.Parse(temp.Rows[i][23].ToString()) != 0)
                    dr[22] = temp.Rows[i][23];
                if (Double.Parse(temp.Rows[i][24].ToString()) != 0)
                    dr[23] = temp.Rows[i][24];

                try
                {
                    if (Double.Parse(temp.Rows[i][25].ToString()) != 0)
                        dr[25] = temp.Rows[i][25];
                    if (Double.Parse(temp.Rows[i][26].ToString()) != 0)
                        dr[26] = temp.Rows[i][26];
                    if (Double.Parse(temp.Rows[i][27].ToString()) != 0)
                        dr[27] = temp.Rows[i][27];
                    if (Double.Parse(temp.Rows[i][28].ToString()) != 0)
                        dr[28] = temp.Rows[i][28];
                    if (Double.Parse(temp.Rows[i][29].ToString()) != 0)
                        dr[29] = temp.Rows[i][29];
                    if (Double.Parse(temp.Rows[i][30].ToString()) != 0)
                        dr[30] = temp.Rows[i][30];
                    if (Double.Parse(temp.Rows[i][31].ToString()) != 0)
                        dr[31] = temp.Rows[i][31];
                    if (Double.Parse(temp.Rows[i][32].ToString()) != 0)
                        dr[32] = temp.Rows[i][32];
                }catch{}
                dt.Rows.Add(dr);
            }

        }
    }
}
