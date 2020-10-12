using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace HAMACO.Resources
{
    class baocaotonkhovo
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
            if (tsbt == "tsbtbctkvlpgtt")
                sql = "baocaotonkhovotheothang '"+ngaychungtu+"','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
            else if (tsbt == "tsbtbctkvlpgtttct")
                sql = "baocaotonkhovotheothangtoancongty '"+ngaychungtu+"','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";
            else
                sql = "baocaotonkhovotheothangtheodonvi '"+ngaychungtu+"','" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'";

            laydulieu(dt, sql,tsbt);

            view.Columns.Clear();
            lvpq.DataSource = dt;

            view.OptionsBehavior.Editable = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            view.Columns[15].Visible = false;
            view.OptionsView.ColumnAutoWidth = false;

            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

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
            view.Columns["Số tiền XTK"].Width = 120;
            view.Columns["Số lượng TCK"].Width = 120;
            view.Columns["Số tiền TCK"].Width = 120;

            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns["Số lượng NTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng NTK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng NTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng NTK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số tiền NTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền NTK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền NTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền NTK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng ĐK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng ĐK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng ĐK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng ĐK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số tiền ĐK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền ĐK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền ĐK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền ĐK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng NCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng NCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng NCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng NCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số tiền NCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền NCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền NCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền NCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng XCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng XCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng XCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng XCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số tiền XCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền XCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền XCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền XCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng XTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng XTK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng XTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng XTK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số tiền XTK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền XTK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền XTK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền XTK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng TCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng TCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng TCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng TCK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số tiền TCK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền TCK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền TCK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền TCK"].SummaryItem.DisplayFormat = "{0:n0}";
        }

        public void inbctk(string ngaychungtu, string tsbt, string kho, GridView view,string userid)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
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
            dt.Columns.Add("Số tiền XTK", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng TCK", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền TCK", Type.GetType("System.Double"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            /*
            string tenkho = "";
            if (tsbt == "tsbtbctkvlpgtt")
            {
                tenkho = gen.GetString("select StockName from Stock where StockID='" + kho + "'");
                string makho = gen.GetString("select StockCode from Stock where StockID='" + kho + "'");
                tenkho = ("KHO " + makho + " - " + tenkho).ToUpper();
            }
            else if (tsbt == "tsbtbctkvlpgtttdv")
            {
                tenkho = gen.GetString("select BranchName from Branch where BranchID='" + kho + "'");
                string makho = gen.GetString("select BranchCode from Branch where BranchID='" + kho + "'");
                tenkho = ("ĐƠN VỊ " + makho + " - " + tenkho).ToUpper();
            }
            */

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
                if (view.GetRowCellValue(i, "Số tiền XTK").ToString() != "")
                    dr[11] = view.GetRowCellValue(i, "Số tiền XTK").ToString();
                if (view.GetRowCellValue(i, "Số lượng TCK").ToString() != "")
                    dr[12] = view.GetRowCellValue(i, "Số lượng TCK").ToString();
                if (view.GetRowCellValue(i, "Số tiền TCK").ToString() != "")
                    dr[13] = view.GetRowCellValue(i, "Số tiền TCK").ToString();
                dr[14] = view.GetRowCellValue(i, "Mã hàng").ToString();
                dt.Rows.Add(dr);
            }


            Frm_rpbaocaotonkhovo rp = new Frm_rpbaocaotonkhovo();
            rp.getuser(userid);
            rp.getdata(dt);
            rp.getkho(kho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbctkthdtndn(DateEdit tungay, DateEdit denngay, string kho, string tsbt,string userid)
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

            string tungaydaucuoi = DateTime.Parse(denngay.DateTime.Month + "/1/" + denngay.DateTime.Year).ToString();

            string thangcuoi = DateTime.Parse(denngay.EditValue.ToString()).Month.ToString();
            string namcuoi = DateTime.Parse(denngay.EditValue.ToString()).Year.ToString();

            string thangtruoccuoi = denngay.DateTime.AddMonths(-1).Month.ToString();
            string namtruoccuoi = denngay.DateTime.AddMonths(-1).Year.ToString();
           
            string sql = "";
            if (tsbt == "tsbtbctkvlpgtndn")
                sql = "baocaotonkhovotungaydenngay '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";             
            else if (tsbt == "tsbtbctkvlpgtndntct")
                sql = "baocaotonkhovotungaydenngaytoancongty '" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";
            else if (tsbt == "tsbtbctkbcnvo")
                sql = "baocaotonkhovotungaydenngaytheodonvicongty '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";
            else if (tsbt == "tsbtbctkbcnvotndn")
                sql = "baocaotonkhovotungaydenngaytheokhocongty '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";             
            else
                sql = "baocaotonkhovotungaydenngaytheodonvi '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "'";
           
            laydulieu(dt, sql,tsbt);
            Frm_rpbaocaotonkhovo rp = new Frm_rpbaocaotonkhovo();
            rp.getuser(userid);
            rp.getdata(dt);
            rp.getkho(kho);
            rp.gettungay(tungay.EditValue.ToString());
            rp.getdenngay(denngay.EditValue.ToString());
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void laydulieu(DataTable dt, string sql,string loai)
        {
            
            DataTable temp = new DataTable();
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
            dt.Columns.Add("Số tiền XTK", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng TCK", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền TCK", Type.GetType("System.Double"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("ID", Type.GetType("System.String"));
            temp = gen.GetTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[15] = temp.Rows[i][0];
                dr[14] = temp.Rows[i][15];
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
                dt.Rows.Add(dr);
            }

        }

        public void inthekho(string ngaychungtu, string tsbt, string kho, string mahang, string congty, string userid)
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
            dt.Columns.Add("slqdtondau", Type.GetType("System.Double"));
            dt.Columns.Add("tientondau", Type.GetType("System.Double"));
            dt.Columns.Add("slqdnhap", Type.GetType("System.Double"));
            dt.Columns.Add("sotiennhap", Type.GetType("System.Double"));
            dt.Columns.Add("slqdxuat", Type.GetType("System.Double"));
            dt.Columns.Add("sotienxuat", Type.GetType("System.Double"));
            dt.Columns.Add("slqdtoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("sotientoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("phuongtien", Type.GetType("System.String"));
            if (tsbt == "tsbtbctktttt")
                temp = gen.GetTable("baocaotonkhothekhothucte '" + kho + "','" + mahang + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            else
                temp = gen.GetTable("baocaotonkhothekhovo '" + kho + "','" + mahang + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            Double slqd = 0; Double sotien = 0;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (temp.Rows[i][1].ToString() == "")
                {
                    dr[2] = "Số tồn tháng trước";
                    if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    {
                        dr[3] = temp.Rows[i][3];
                        slqd = slqd + Double.Parse(temp.Rows[i][3].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    {
                        dr[4] = temp.Rows[i][4];
                        sotien = sotien + Double.Parse(temp.Rows[i][4].ToString());
                    }
                }
                else
                {
                    dr[0] = temp.Rows[i][0];
                    dr[1] = temp.Rows[i][1];
                    dr[2] = temp.Rows[i][2];
                    if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    {
                        dr[5] = temp.Rows[i][5];
                        slqd = slqd + Double.Parse(temp.Rows[i][5].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    {
                        dr[6] = temp.Rows[i][6];
                        sotien = sotien + Double.Parse(temp.Rows[i][6].ToString());
                    }

                    if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    {
                        dr[7] = temp.Rows[i][7];
                        slqd = slqd - Double.Parse(temp.Rows[i][7].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    {
                        dr[8] = temp.Rows[i][8];
                        sotien = sotien - Double.Parse(temp.Rows[i][8].ToString());
                    }

                    if (slqd != 0)
                        dr[9] = slqd;
                    if (sotien != 0)
                        dr[10] = sotien;
                    dr[11] = temp.Rows[i][9];
                }
                dt.Rows.Add(dr);
            }

            Frm_rpbaocaotonkhovo rp = new Frm_rpbaocaotonkhovo();
            rp.getdata(dt);
            rp.getngaychungtu(ngaychungtu);
            rp.getkho(kho);
            rp.gettenkho(mahang);
            rp.gettungay(congty);
            rp.getdenngay(userid);
            rp.gettsbt(tsbt + "thekho");
            rp.Show();
        }

        public void inthekhotndn(string tungay,string denngay, string tsbt, string kho, string mahang, string sldk,string slqddk , string loai)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            if (tsbt != "tsbtbctktttndntaidvhanggui")
            {
                tungay = DateTime.Parse(tungay.Substring(3, 2) + "/" + tungay.Substring(0, 2) + "/" + tungay.Substring(6, 4)).ToString();
                denngay = DateTime.Parse(denngay.Substring(3, 2) + "/" + denngay.Substring(0, 2) + "/" + denngay.Substring(6, 4)).AddDays(1).AddSeconds(-1).ToString();
            }
            dt.Columns.Add("ngay", Type.GetType("System.DateTime"));
            dt.Columns.Add("sophieu", Type.GetType("System.String"));
            dt.Columns.Add("tenkhach", Type.GetType("System.String"));
            dt.Columns.Add("slqdtondau", Type.GetType("System.Double"));
            dt.Columns.Add("tientondau", Type.GetType("System.Double"));
            dt.Columns.Add("slqdnhap", Type.GetType("System.Double"));
            dt.Columns.Add("sotiennhap", Type.GetType("System.Double"));
            dt.Columns.Add("slqdxuat", Type.GetType("System.Double"));
            dt.Columns.Add("sotienxuat", Type.GetType("System.Double"));
            dt.Columns.Add("slqdtoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("sotientoncuoi", Type.GetType("System.Double"));
            dt.Columns.Add("phuongtien", Type.GetType("System.String"));
            
            if (tsbt == "tsbtbctktttndntpxk")
                temp = gen.GetTable("baocaotonkhothekhothuctetndn '" + kho + "','" + mahang + "','" + tungay + "','" + denngay + "'");
            else if (tsbt == "tsbtbctktttndntaidv" || tsbt == "tsbtbctktttndntaidvhanggui")
                temp = gen.GetTable("baocaotonkhothekhothuctetaidv '" + kho + "','" + mahang + "','" + tungay + "','" + denngay + "','" + loai + "'");
            else if(tsbt == "bchgkh")
                temp = gen.GetTable("baocaotonkhothekhohanggui '" + kho + "','" + mahang + "','" + tungay + "','" + denngay + "','" + loai + "'");
           
            Double sldk1 = 0; Double slqddk1 = 0;
            Double slqd = 0; Double sotien = 0;

            try
            {
                sldk1 = Double.Parse(sldk);
            }
            catch { }
            try
            {
                slqddk1 = Double.Parse(slqddk);
            }
            catch { }

            if (sldk1 != 0 || slqddk1!=0)
                {
                    DataRow dr1 = dt.NewRow();
                    dr1[2] = "Số tồn từ ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay));
                    if (sldk1!=0)
                    {
                        dr1[3] = sldk1;
                        slqd = slqd + sldk1;
                    }
                    if (slqddk1 != 0)
                    {
                        dr1[4] = slqddk1;
                        sotien = sotien + slqddk1;
                    }
                    dt.Rows.Add(dr1);
                }

            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                {
                    dr[5] = temp.Rows[i][5];
                    slqd = slqd + Double.Parse(temp.Rows[i][5].ToString());
                }
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                {
                    dr[6] = temp.Rows[i][6];
                    sotien = sotien + Double.Parse(temp.Rows[i][6].ToString());
                }

                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                {
                    dr[7] = temp.Rows[i][7];
                    slqd = slqd - Double.Parse(temp.Rows[i][7].ToString());
                }
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                {
                    dr[8] = temp.Rows[i][8];
                    sotien = sotien - Double.Parse(temp.Rows[i][8].ToString());
                }

                if (slqd != 0)
                    dr[9] = slqd;
                if (sotien != 0)
                    dr[10] = sotien;
                dr[11] = temp.Rows[i][9];
                dt.Rows.Add(dr);
            }
            
            Frm_rpbaocaotonkhovo rp = new Frm_rpbaocaotonkhovo();
            rp.getdata(dt);
            rp.getngaychungtu(tungay);
            rp.getkho(kho);
            rp.gettenkho(mahang);
            rp.gettungay(denngay);
            rp.gettsbt(tsbt + "thekho");
            rp.Show();
        }
    }
}
