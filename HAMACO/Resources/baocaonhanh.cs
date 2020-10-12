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
    class baocaonhanh
    {
        gencon gen = new gencon();

        public void loadsanluongtheothang(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid, string ngaychungtu, string tsbt)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = gen.GetTable("bangketonghopbaocaonhanh '" + branchid + "','" + ngaychungtu + "','" + ngaychungtu + "','sanluongtheothang'");
            view.Columns.Clear();

            dt.Columns.Add("Mã loại", Type.GetType("System.String"));
            dt.Columns.Add("Tên loại", Type.GetType("System.String"));
            dt.Columns.Add("Mặt hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tháng 01", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 02", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 03", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 04", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 05", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 06", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 07", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 08", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 09", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 10", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 11", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 12", Type.GetType("System.Double"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();

                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6].ToString();
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7].ToString();
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8].ToString();
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[9] = temp.Rows[i][9].ToString();
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = temp.Rows[i][10].ToString();
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[11] = temp.Rows[i][11].ToString();
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[12] = temp.Rows[i][12].ToString();
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[13] = temp.Rows[i][13].ToString();
                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                    dr[14] = temp.Rows[i][14].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns["Tháng 01"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 01"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 01"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 01"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 02"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 02"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 02"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 02"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 03"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 03"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 03"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 03"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 04"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 04"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 04"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 04"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 05"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 05"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 05"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 05"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 06"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 06"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 06"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 06"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 07"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 07"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 07"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 07"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 08"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 08"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 08"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 08"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 09"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 09"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 09"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 09"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 10"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 10"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 10"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 10"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 11"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 11"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 11"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 11"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tháng 12"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 12"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 12"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tháng 12"].SummaryItem.DisplayFormat = "{0:n0}";
     

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns[2].Width = 200;


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Tháng 01";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Tháng 01"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Tháng 02";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Tháng 02"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Tháng 03";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Tháng 03"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Tháng 04";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Tháng 04"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "Tháng 05";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["Tháng 05"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "Tháng 06";
            item6.DisplayFormat = "{0:n0}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["Tháng 06"];

            GridGroupSummaryItem item7 = new GridGroupSummaryItem();
            item7.FieldName = "Tháng 07";
            item7.DisplayFormat = "{0:n0}";
            item7.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item7);
            item7.ShowInGroupColumnFooter = view.Columns["Tháng 07"];

            GridGroupSummaryItem item8 = new GridGroupSummaryItem();
            item8.FieldName = "Tháng 08";
            item8.DisplayFormat = "{0:n0}";
            item8.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item8);
            item8.ShowInGroupColumnFooter = view.Columns["Tháng 08"];

            GridGroupSummaryItem item9 = new GridGroupSummaryItem();
            item9.FieldName = "Tháng 09";
            item9.DisplayFormat = "{0:n0}";
            item9.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item9);
            item9.ShowInGroupColumnFooter = view.Columns["Tháng 09"];

            GridGroupSummaryItem item10 = new GridGroupSummaryItem();
            item10.FieldName = "Tháng 10";
            item10.DisplayFormat = "{0:n0}";
            item10.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item10);
            item10.ShowInGroupColumnFooter = view.Columns["Tháng 10"];

            GridGroupSummaryItem item11 = new GridGroupSummaryItem();
            item11.FieldName = "Tháng 11";
            item11.DisplayFormat = "{0:n0}";
            item11.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item11);
            item11.ShowInGroupColumnFooter = view.Columns["Tháng 11"];

            GridGroupSummaryItem item12 = new GridGroupSummaryItem();
            item12.FieldName = "Tháng 12";
            item12.DisplayFormat = "{0:n0}";
            item12.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item12);
            item12.ShowInGroupColumnFooter = view.Columns["Tháng 12"];

            view.Columns[0].GroupIndex = 0;
            view.ExpandAllGroups();

        }

        public void loadluutrutonkho(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid, string ngaychungtu, string tsbt)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = gen.GetTable("bangketonkhomathangtheongay '" + branchid + "','" + DateTime.Parse(ngaychungtu).Month + "','" + DateTime.Parse(ngaychungtu).Year + "','" + ngaychungtu + "','','',''");
            view.Columns.Clear();

            dt.Columns.Add("Loại", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("0", Type.GetType("System.Double"));
            dt.Columns.Add("10", Type.GetType("System.Double"));
            dt.Columns.Add("30", Type.GetType("System.Double"));
            dt.Columns.Add("45", Type.GetType("System.Double"));
            dt.Columns.Add("60", Type.GetType("System.Double"));
            dt.Columns.Add("75", Type.GetType("System.Double"));
            dt.Columns.Add("90", Type.GetType("System.Double"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();

                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6].ToString();
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7].ToString();
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8].ToString();
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[9] = temp.Rows[i][9].ToString();
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = temp.Rows[i][10].ToString();
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[11] = temp.Rows[i][11].ToString();
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[12] = temp.Rows[i][12].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns["0"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["0"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["0"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["0"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["0"].Caption = "< 10 ngày";

            view.Columns["10"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["10"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["10"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["10"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["10"].Caption = "> 10 ngày";

            view.Columns["30"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["30"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["30"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["30"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["30"].Caption = "> 30 ngày";

            view.Columns["45"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["45"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["45"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["45"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["45"].Caption = "> 45 ngày";

            view.Columns["60"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["60"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["60"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["60"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["60"].Caption = "> 60 ngày";

            view.Columns["75"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["75"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["75"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["75"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["75"].Caption = "> 75 ngày";

            view.Columns["90"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["90"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["90"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["90"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["90"].Caption = "> 90 ngày";

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns[2].Width = 200;


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "0";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["0"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "10";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["10"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "30";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["30"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "45";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["45"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "60";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["60"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "75";
            item6.DisplayFormat = "{0:n0}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["75"];

            GridGroupSummaryItem item7 = new GridGroupSummaryItem();
            item7.FieldName = "90";
            item7.DisplayFormat = "{0:n0}";
            item7.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item7);
            item7.ShowInGroupColumnFooter = view.Columns["90"];

            GridGroupSummaryItem item8 = new GridGroupSummaryItem();
            item8.FieldName = "Số lượng";
            item8.DisplayFormat = "{0:n0}";
            item8.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item8);
            item8.ShowInGroupColumnFooter = view.Columns["Số lượng"];

            GridGroupSummaryItem item9 = new GridGroupSummaryItem();
            item9.FieldName = "Trọng lượng";
            item9.DisplayFormat = "{0:n0}";
            item9.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item9);
            item9.ShowInGroupColumnFooter = view.Columns["Trọng lượng"];

            GridGroupSummaryItem item10 = new GridGroupSummaryItem();
            item10.FieldName = "Số tiền";
            item10.DisplayFormat = "{0:n0}";
            item10.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item10);
            item10.ShowInGroupColumnFooter = view.Columns["Số tiền"];

            view.Columns[0].GroupIndex = 0;
            view.ExpandAllGroups();

        }

        public void loaddoanhthutheothang(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid, string ngaychungtu, string tsbt)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp =new DataTable();
            if(tsbt=="tsbtbcdtlntt")
                temp = gen.GetTable("bangketonghopbaocaonhanh '" + branchid + "','" + ngaychungtu + "','" + ngaychungtu + "','doanhthuloinhuantheothang'");
            else if (tsbt == "tsbtbcdtlnct")
                temp = gen.GetTable("bangketonghopbaocaonhanh '" + branchid + "','" + ngaychungtu + "','" + ngaychungtu + "','doanhthuloinhuanchitiet'");
              
            view.Columns.Clear();

            dt.Columns.Add("Mã số", Type.GetType("System.String"));
            dt.Columns.Add("Nội dung", Type.GetType("System.String"));
            dt.Columns.Add("Tháng 01", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 02", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 03", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 04", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 05", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 06", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 07", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 08", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 09", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 10", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 11", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 12", Type.GetType("System.Double"));
            dt.Columns.Add("Tổng cộng", Type.GetType("System.Double"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (temp.Rows[i][0].ToString() == "01" || temp.Rows[i][0].ToString() == "02" || temp.Rows[i][0].ToString() == "03" || temp.Rows[i][0].ToString() == "04" || temp.Rows[i][0].ToString() == "09" || temp.Rows[i][0].ToString() == "10" || temp.Rows[i][0].ToString() == "11" || temp.Rows[i][0].ToString() == "18" || temp.Rows[i][0].ToString() == "19" || temp.Rows[i][0].ToString() == "26")
                    dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();

                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2].ToString();
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6].ToString();
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7].ToString();
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8].ToString();
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[9] = temp.Rows[i][9].ToString();
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = temp.Rows[i][10].ToString();
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[11] = temp.Rows[i][11].ToString();
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[12] = temp.Rows[i][12].ToString();
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[13] = temp.Rows[i][13].ToString();
                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                    dr[14] = temp.Rows[i][14].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns["Tháng 01"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 01"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 02"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 02"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 03"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 03"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 04"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 04"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 05"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 05"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 06"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 06"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 07"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 07"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 08"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 08"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 09"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 09"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 10"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 10"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 11"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 11"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tháng 12"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 12"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tổng cộng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng cộng"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns[1].Width = 150;
            view.Columns[0].Width = 50;
            view.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loaddoanhthutheoquy(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid, string ngaychungtu, string tsbt)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = gen.GetTable("bangketonghopbaocaonhanh '" + branchid + "','" + ngaychungtu + "','" + ngaychungtu + "','doanhthuloinhuantheoquy'");
            view.Columns.Clear();

            dt.Columns.Add("Mã số", Type.GetType("System.String"));
            dt.Columns.Add("Nội dung", Type.GetType("System.String"));
            dt.Columns.Add("Quý 01", Type.GetType("System.Double"));
            dt.Columns.Add("Quý 02", Type.GetType("System.Double"));
            dt.Columns.Add("Quý 03", Type.GetType("System.Double"));
            dt.Columns.Add("Quý 04", Type.GetType("System.Double"));
            dt.Columns.Add("Tổng cộng", Type.GetType("System.Double"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();

                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2].ToString();
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns["Quý 01"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quý 01"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Quý 02"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quý 02"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Quý 03"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quý 03"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Quý 04"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quý 04"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tổng cộng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng cộng"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns[1].Width = 200;
            view.Columns[0].Width = 50;
            view.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadsanluongtheoquy(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid, string ngaychungtu, string tsbt)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = gen.GetTable("bangketonghopbaocaonhanh '" + branchid + "','" + ngaychungtu + "','" + ngaychungtu + "','sanluongtheoquy'");
            view.Columns.Clear();

            dt.Columns.Add("Mã loại", Type.GetType("System.String"));
            dt.Columns.Add("Tên loại", Type.GetType("System.String"));
            dt.Columns.Add("Mặt hàng", Type.GetType("System.String"));
            dt.Columns.Add("Quý 01", Type.GetType("System.Double"));
            dt.Columns.Add("Quý 02", Type.GetType("System.Double"));
            dt.Columns.Add("Quý 03", Type.GetType("System.Double"));
            dt.Columns.Add("Quý 04", Type.GetType("System.Double"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();

                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns["Quý 01"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quý 01"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Quý 01"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Quý 01"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Quý 02"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quý 02"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Quý 02"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Quý 02"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Quý 03"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quý 03"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Quý 03"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Quý 03"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Quý 04"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quý 04"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Quý 04"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Quý 04"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns[2].Width = 200;


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Quý 01";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Quý 01"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Quý 02";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Quý 02"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Quý 03";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Quý 03"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Quý 04";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Quý 04"];

            view.Columns[0].GroupIndex = 0;
            view.ExpandAllGroups();

        }

        public void loaddoanhthusanluong(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid, string tungay, string denngay, string tsbt)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp=new DataTable();
            if (tsbt == "tsbtbcdtsl")
                temp = gen.GetTable("bangketonghopbaocaonhanh '" + branchid + "','" + tungay + "','" + denngay + "','doanhthusanluong'");
            else if (tsbt == "tsbtdskhm")
                temp = gen.GetTable("bangketonghopbaocaonhanh '" + branchid + "','" + tungay + "','" + denngay + "','danhsachmoi'");
            else if (tsbt == "tsbtdskhkpsdt")
                temp = gen.GetTable("bangketonghopbaocaonhanh '" + branchid + "','" + tungay + "','" + denngay + "','danhsachkhongphatsinh'");
            view.Columns.Clear();

            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            if (tsbt == "tsbtbcdtsl")
                dt.Columns.Add("Doanh thu", Type.GetType("System.Double"));
            dt.Columns.Add("Kỳ trước", Type.GetType("System.Double"));
            dt.Columns.Add("Xi măng", Type.GetType("System.Double"));
            dt.Columns.Add("Cát đá", Type.GetType("System.Double"));
            dt.Columns.Add("Nhớt", Type.GetType("System.Double"));
            dt.Columns.Add("Xăng", Type.GetType("System.Double"));
            dt.Columns.Add("Dầu", Type.GetType("System.Double"));
            dt.Columns.Add("LPG", Type.GetType("System.Double"));
            dt.Columns.Add("Bếp", Type.GetType("System.Double"));
            dt.Columns.Add("Bột trét", Type.GetType("System.Double"));
            dt.Columns.Add("Sơn", Type.GetType("System.Double"));
            dt.Columns.Add("Bê tông", Type.GetType("System.Double"));
            dt.Columns.Add("Thép", Type.GetType("System.Double"));
            dt.Columns.Add("Khác", Type.GetType("System.Double"));


            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();

                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2].ToString();
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6].ToString();
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7].ToString();
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8].ToString();
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[9] = temp.Rows[i][9].ToString();
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = temp.Rows[i][10].ToString();
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[11] = temp.Rows[i][11].ToString();
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[12] = temp.Rows[i][12].ToString();
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[13] = temp.Rows[i][13].ToString();
                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                    dr[14] = temp.Rows[i][14].ToString();
                if (tsbt == "tsbtbcdtsl")
                    if (Double.Parse(temp.Rows[i][15].ToString()) != 0)
                        dr[15] = temp.Rows[i][15].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            if (tsbt == "tsbtbcdtsl")
            {
                view.Columns["Doanh thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Doanh thu"].DisplayFormat.FormatString = "{0:n0}";
                view.Columns["Doanh thu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                view.Columns["Doanh thu"].SummaryItem.DisplayFormat = "{0:n0}";
            }

            view.Columns["Kỳ trước"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Kỳ trước"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Kỳ trước"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Kỳ trước"].SummaryItem.DisplayFormat = "{0:n0}";
            if (tsbt == "tsbtdskhm")
                view.Columns["Kỳ trước"].Caption = "Doanh thu";


            view.Columns["Xi măng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Xi măng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Xi măng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Xi măng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Cát đá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Cát đá"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Cát đá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Cát đá"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Nhớt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nhớt"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nhớt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nhớt"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Xăng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Xăng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Xăng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Xăng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Dầu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Dầu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Dầu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Dầu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["LPG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["LPG"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["LPG"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["LPG"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Bếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Bếp"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Bếp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Bếp"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Bột trét"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Bột trét"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Bột trét"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Bột trét"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Sơn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Sơn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Sơn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Sơn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Bê tông"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Bê tông"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Bê tông"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Bê tông"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Thép"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thép"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thép"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thép"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Khác"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Khác"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Khác"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";            
        }

    }
}
