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
    class tonghoptaikhoan
    {
        gencon gen = new gencon();
        public void loadthtkskt(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu,string tsbt)
        {
            view.Columns.Clear();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Phát sinh nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Phát sinh có", Type.GetType("System.Double"));
            dt.Columns.Add("Lũy kế nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Lũy kế có", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            if (tsbt == "tsbtthtktq")
                temp = gen.GetTable("tonghoptaikhoanquy '" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "'");
            else
                temp = gen.GetTable("tonghoptaikhoan '" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "'");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];

                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[2] = temp.Rows[i][8];
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[3] = temp.Rows[i][9];

                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[8]= temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[9] = temp.Rows[i][3];

                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[6] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[7] = temp.Rows[i][5];

                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[4] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[5] = temp.Rows[i][7];
                dt.Rows.Add(dr);       
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns["Nợ đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ đầu kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ đầu kỳ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Có đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có đầu kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có đầu kỳ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Phát sinh nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Phát sinh nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Phát sinh nợ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Phát sinh nợ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Phát sinh có"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Phát sinh có"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Phát sinh có"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Phát sinh có"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Lũy kế nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lũy kế nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lũy kế nợ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lũy kế nợ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Lũy kế có"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lũy kế có"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lũy kế có"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lũy kế có"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ cuối kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ cuối kỳ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Có cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có cuối kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có cuối kỳ"].SummaryItem.DisplayFormat = "{0:n0}";            
        }

        public void loadketquakinhdoanh(string makho, string ngaychungtu,string tungay, string tsbt,string userid)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Trị giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Trị giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Chênh lệch", Type.GetType("System.Double"));
            dt.Columns.Add("Nhóm hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            if(tsbt=="tsbtthkqkd")
                temp = gen.GetTable("tonghopketquakinhdoanhtheokho '"+thangtruoc+"','"+namtruoc+"','"+thang+"','"+nam+"','"+tungay+"','"+ngaychungtu+"','"+makho+"'");
            else if (tsbt == "tsbtthkqkdtdv")
                temp = gen.GetTable("tonghopketquakinhdoanhtheodonvi '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + tungay + "','" + ngaychungtu + "','" + makho + "','" + userid + "'");
            else
            {
                temp = gen.GetTable("tonghopketquakinhdoanhtoancongty '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + tungay + "','" + ngaychungtu + "','" + userid + "','" + tsbt + "'");
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][2].ToString())!=0)
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
            Frm_rpbaocaotonkho F = new Frm_rpbaocaotonkho();
            F.getdata(dt);
            F.getngaychungtu(ngaychungtu);
            F.getdenngay(tungay);
            F.getkho(makho);
            F.gettsbt(tsbt);
            F.Show();
        }

        public void loadketqualaigopkinhdoanh(string makho, string ngaychungtu, string tsbt, string userid, string tungay)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Trị giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Trị giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Chênh lệch", Type.GetType("System.Double"));
            dt.Columns.Add("Nhóm hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
            dt.Columns.Add("ID", Type.GetType("System.String"));

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            if (tsbt == "tsbtlaigopkinhdoanh")
                temp = gen.GetTable("bangkelaigopkinhdoanh '" + makho + "','" + thang + "','" + nam + "','" + ngaychungtu + "','','" + userid + "',''");
          
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
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8];
                dr[9] = temp.Rows[i][9];
                dr[10] = temp.Rows[i][10];
                dr[11] = temp.Rows[i][11];
                dt.Rows.Add(dr);
            }
            Frm_rpbaocaotonkho F = new Frm_rpbaocaotonkho();
            F.getdata(dt);
            F.getngaychungtu(ngaychungtu);
            F.gettungay(tungay);
            F.getkho(makho);
            F.gettsbt(tsbt);
            F.Show();
        }

        public void loadketqualaigopkinhdoanhchitiet(string makho, string ngaychungtu, string tsbt, string userid, string tungay, string mahang)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Trị giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Trị giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Chênh lệch", Type.GetType("System.Double"));
            dt.Columns.Add("Nhóm hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
            dt.Columns.Add("ID", Type.GetType("System.String"));

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            if (tsbt == "tsbtlaigopkinhdoanh")
                temp = gen.GetTable("bangkelaigopkinhdoanh '" + makho + "','" + thang + "','" + nam + "','" + ngaychungtu + "','mahang','" + userid + "','" + mahang + "'");

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
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8];
                dr[9] = temp.Rows[i][9];
                dr[10] = temp.Rows[i][10];
                dr[11] = temp.Rows[i][11];
                dt.Rows.Add(dr);
            }
            Frm_rpbaocaotonkho F = new Frm_rpbaocaotonkho();
            F.getdata(dt);
            F.getngaychungtu(ngaychungtu);
            F.gettungay(tungay);
            F.getkho(makho);
            F.gettsbt(tsbt);
            F.Show();
        }

        public void loadStock(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu,string account,string tsbt)
        {
            view.Columns.Clear();
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            ngaychungtu = DateTime.Parse(DateTime.Parse(ngaychungtu).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            if (tsbt == "tsbtbctcth")
                temp = gen.GetTable("thuchitienhang '" + tungaydau + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + account + "'");
            else if (tsbt == "tsbtthkqkd")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from SSInvoice a,Stock b,Stock c where b.StockID=c.Parent and a.BranchID=b.Parent and Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "' and a.BranchID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "tsbtghiso" || tsbt == "tsbtboghi")
                temp = gen.GetTable("select DISTINCT StockID,StockCode,StockName from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "tsbtthuedaura")
                temp = gen.GetTable("select distinct a.StockID,StockCode,StockName from Stock a, HACHTOAN b where a.StockID=b.StockID and (DebitAccount='33311' or CreditAccount='33311') and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "tsbtthuedauvao")
                temp = gen.GetTable("select distinct a.StockID,StockCode,StockName from Stock a, HACHTOAN b where a.StockID=b.StockID and (DebitAccount='1331' or CreditAccount='1331') and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "tsbtthtkskt")
            {
                string tinhchat = gen.GetString("select AccountCategoryKind from Account where AccountNumber='" + account + "'");
                if (tinhchat == "2" || account == "632" || account == "156")
                    temp = gen.GetTable("select DISTINCT(b.StockID), b.StockCode,b.StockName from AccountSum a, Stock b where a.StockID=b.StockID and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' order by b.StockCode");
                else
                    temp = gen.GetTable("select DISTINCT(b.StockID), b.StockCode,b.StockName from HACHTOAN a, Stock b where a.StockID=b.StockID and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' order by b.StockCode");
            }
            else if (tsbt == "tsbtctlv")
                temp = gen.GetTable("select distinct a.StockID,StockCode,StockName from Stock a where a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and substring(DefaultAccountNumber,1,1)<>'0' order by StockCode");

            else if (tsbt == "tsbtctlvtn")
                temp = gen.GetTable("select distinct ItemSource as '1',ItemSource as '2',ItemSource as '3' from (select a.* from InventoryItem a, MSC_UserMN b where a.ItemSource=b.MN and UserID='" + account + "') a, (select * from HACHTOAN where MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' ) b where a.ItemSource=b.Occupation order by ItemSource");

            else if (tsbt == "bkpxhtdnbdc")
                temp = gen.GetTable("select distinct a.Description,a.Description,c.InventoryCategoryName from OUTdeficitDetail a, (select * from OUTdeficit where MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and Cancel='True') b, InventoryItemCategory c where a.RefID=b.RefID and a.Description=c.InventoryCategoryCode");

            else if (tsbt == "tsbtctkqkd" || tsbt == "tsbtctkqkdtt")
                temp = gen.GetTable("select distinct a.StockID,a.StockCode,StockName from Stock a, (select substring(DefaultAccountNumber,4,2) as StockCode from Stock) b where a.StockCode=b.StockCode and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by a.StockCode");
            else
                temp = gen.GetTable("select DISTINCT(c.StockID), c.StockCode,c.StockName from AccountSum a, Stock b, Stock c where b.Parent=c.StockID and a.StockID=b.StockID and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' order by c.StockCode");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;

            if (tsbt == "tsbtctlvtn" || tsbt == "bkpxhtdnbdc") 
            
            {
                view.Columns[1].Caption = "Mã ngành";
                view.Columns[2].Caption = "Tên ngành";
            }

            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.BestFitColumns();
            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadbcthhdkd(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view,string tsbt)
        {
            view.Columns.Clear();
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
  
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Tên báo cáo", Type.GetType("System.String"));

            if (tsbt == "tsbtthkqkd")
            {
                DataRow dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Chi tiết theo từng cửa hàng";
                dt.Rows.Add(dr);
                DataRow dr1 = dt.NewRow();
                dr1[0] = "2";
                dr1[1] = "Chi tiết theo từng mặt hàng";
                dt.Rows.Add(dr1);
                DataRow dr2 = dt.NewRow();
                dr2[0] = "3";
                dr2[1] = "Tổng hợp theo từng khu vực";
                dt.Rows.Add(dr2);
                DataRow dr3 = dt.NewRow();
                dr3[0] = "4";
                dr3[1] = "Tổng hợp theo từng cửa hàng";
                dt.Rows.Add(dr3);
                DataRow dr4 = dt.NewRow();
                dr4[0] = "5";
                dr4[1] = "Tổng hợp theo từng ngành hàng";
                dt.Rows.Add(dr4);
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Bảng cân đối tài khoản";
                dt.Rows.Add(dr);
                DataRow dr1 = dt.NewRow();
                dr1[0] = "2";
                dr1[1] = "Bảng cân đối kế toán";
                dt.Rows.Add(dr1);
                DataRow dr2 = dt.NewRow();
                dr2[0] = "3";
                dr2[1] = "Tình hình kết quả kinh doanh";
                dt.Rows.Add(dr2);
                DataRow dr3 = dt.NewRow();
                dr3[0] = "4";
                dr3[1] = "Lưu chuyển tiền tệ";
                dt.Rows.Add(dr3);
                DataRow dr4 = dt.NewRow();
                dr4[0] = "5";
                dr4[1] = "Tình hình thực hiện nghĩa vụ với nhà nước";
                dt.Rows.Add(dr4);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.BestFitColumns();
            view.Columns["STT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadStockmain(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string tungay, string denngay, string account, string tsbt)
        {
            view.Columns.Clear();
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));

            if (tsbt == "sctbhtkhvhd" || tsbt == "sctbhtkhvmh" || tsbt == "bkcthdbh" || tsbt == "lvphtbhtnvvsl" || tsbt == "snkbh" || tsbt == "thsdhd" || tsbt == "tsbtthbhtdtkh")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from SSInvoice a,Stock b,Stock c where b.StockID=c.Parent and a.BranchID=b.Parent and PURefDate>='" + tungay + "' and PURefDate <='" + denngay + "' and a.BranchID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "sctmhtmh" || tsbt == "snkmh")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from PUInvoice a,Stock b,Stock c where b.StockID=c.Parent and a.BranchID=b.Parent and PURefDate>='" + tungay + "' and PURefDate <='" + denngay + "' and a.BranchID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "snkxk" || tsbt == "snkxktx" || tsbt == "snkxkct" || tsbt == "bkcpbh" || tsbt == "bkcntt" || tsbt == "bkcntttdv" || tsbt == "bkcnttct" || tsbt == "bkcpbx" || tsbt == "bkcpk" || tsbt == "bkcpvcbh" || tsbt == "bkxktkhvmh" || tsbt == "bkpxbhttm" || tsbt == "bkxktmhpx")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INOutward a,Stock b where a.StockID=b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "bkcpbxthhh")
                temp = gen.GetTable("bangkelaykho '" + tungay + "','" + denngay + "','" + account + "','khotonghop'");
            else if (tsbt == "bkcpbxv")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INOutwardSU a,Stock b where a.StockID=b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "bkcpbxthnv")
            {
                if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004")
                    temp = gen.GetTable("select DISTINCT ShippingNo,ShippingNo,ShippingNo from INOutwardLPG a where RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and ShippingNo<>''");
                else
                    temp = gen.GetTable("select DISTINCT Taixe,Taixe,Taixe from INOutward a where RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and Taixe<>''");
            }
            else if (tsbt == "bkcpbxth")
            {
                if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004")
                    temp = gen.GetTable("select DISTINCT CustomField2,CustomField2,CustomField2 from INOutwardLPG a where RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and CustomField2<>''");
                else
                    temp = gen.GetTable("select DISTINCT Shipper,Shipper,Shipper from INOutward a where RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and Shipper<>''");
            }
            else if (tsbt == "bkthbhtnvkd")
                temp = gen.GetTable("select DISTINCT b.AccountingObjectID,AccountingObjectCode,b.AccountingObjectName from INOutward a, AccountingObject b where RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and EmployeeIDSA=b.AccountingObjectID order by AccountingObjectCode");
            else if (tsbt == "bkthbhtnvkdlqh")
                temp = gen.GetTable("select DISTINCT a.StockID,StockCode,StockName  from INOutward a, Stock b where RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and a.StockID=b.StockID order by StockCode");
            else if (tsbt == "snknk" || tsbt == "bkcpbxnh")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INInward a,Stock b where a.StockID=b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "bkcpbxnhv")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INInwardSU a,Stock b where a.StockID=b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "bkpxhtdnb")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from OUTdeficit a,Stock b where a.StockID=b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and Cancel='True' order by StockCode");
            else if (tsbt == "bkcpbxnhtdv")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INInwardTT a,Stock b where a.StockID=b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "bkhdbvt")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INOutwardSU a,Stock b where a.StockID= b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "bknmvt")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INInwardSU a,Stock b where a.StockID= b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "bknckvlpg")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INTransferSU a,Stock b where a.InwardStockID= b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "bkxckvlpg")
                temp = gen.GetTable("select DISTINCT b.StockID,b.StockCode,b.StockName from INTransferSU a,Stock b where a.OutwardStockID= b.StockID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            else if (tsbt == "snkxcnbtc")
                temp = gen.GetTable("select Distinct OutStockID,b.StockCode,b.StockName from DDH a, Stock b where a.OutStockID=b.StockID and RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and  OutStockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by b.StockCode");

            else if (tsbt == "tsbtbctkhtd" || tsbt == "bctqtkho" || tsbt == "barthkqkdhtd")
                temp = gen.GetTable("select distinct a.StockID,StockCode,StockName from MSC_UserJoinStock a, Stock b where a.StockID=b.StockID and UserID='" + account + "' order by StockCode");

            else if (tsbt == "131tndn" || tsbt == "131tndnbh" || tsbt == "331tndnbh" || tsbt == "331tndn" || tsbt == "1313tndn" || tsbt == "3313tndn" || tsbt == "1388tndn" || tsbt == "3388tndn" || tsbt == "sctbhtkhvmh" || tsbt == "lvphtbhtnvvsl" || tsbt == "snkbh" || tsbt == "thsdhd")
            {
                tsbt = tsbt.Replace("tndn", "").Replace("bh", "");
                temp = gen.GetTable("baocaocongnotungaydenngaylaykho '" + tsbt + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','kho','" + account + "'");
            }
            else if (tsbt == "bkcpbxxck" || tsbt == "bkcpvcxck")
                temp = gen.GetTable("bangkelaykho '" + tungay + "','" + denngay + "','" + account + "','kho'");
            else if (tsbt == "bkcpbxxckv")
                temp = gen.GetTable("bangkelaykho '" + tungay + "','" + denngay + "','" + account + "','khovo'");
            else if (tsbt == "bkcpbxnck" || tsbt == "bkcpvcnck")
                temp = gen.GetTable("bangkelaykho '" + tungay + "','" + denngay + "','" + account + "','khonhan'");
            else if (tsbt == "bkcpbxnckv")
                temp = gen.GetTable("bangkelaykho '" + tungay + "','" + denngay + "','" + account + "','khonhanvo'");
            else if (tsbt == "bchgkh")
                temp = gen.GetTable("bangkelaykho '" + tungay + "','" + denngay + "','" + account + "','khogui'");
            else if (tsbt == "bchgkhkhach")
                temp = gen.GetTable("bangkelaykho '" + tungay + "','" + denngay + "','" + account + "','khoguikhach'");
            else if (tsbt == "bkptttkh")
                temp = gen.GetTable("select Distinct b.StockID,StockCode,StockName from HACHTOAN a, Stock b where a.StockID=b.StockID and RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and CreditAccount='131' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");

            else if (tsbt == "sktth" || tsbt == "sktthtomtat")
            {
                string tinhchat = gen.GetString("select AccountCategoryKind from Account where AccountNumber='" + account + "'");
                if (tinhchat == "2" || account == "632" || account == "156")
                    temp = gen.GetTable("select DISTINCT(b.StockID), b.StockCode,b.StockName from AccountSum a, Stock b where a.StockID=b.StockID and (substring(DebitAccount,1," + account.Length + ")='" + account + "' or substring(CreditAccount,1," + account.Length + ")='" + account + "') and PostDate>='" + tungay + "' and PostDate <='" + denngay + "' order by b.StockCode");
                else
                    temp = gen.GetTable("select DISTINCT(b.StockID), b.StockCode,b.StockName from HACHTOAN a, Stock b where a.StockID=b.StockID and (substring(DebitAccount,1," + account.Length + ")='" + account + "' or substring(CreditAccount,1," + account.Length + ")='" + account + "') and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' order by b.StockCode");
            }
            else if (tsbt == "tsbtbaocaosanluong" || tsbt == "tsbtbaocaoluongsanluong")
                temp = gen.GetTable("select distinct EmployeeID,EmployeeCode,EmployeeName from SalaryList where MonthS=MONTH('" + denngay + "') and Years=YEAR('" + denngay + "') and StockID='" + account + "' order by EmployeeCode");
            else if (tsbt == "tsbtlaigopkinhdoanh")
                temp = gen.GetTable("bangkelaigopkinhdoanh '','','','" + denngay + "','kho','" + account + "',''");
            else if (tsbt == "tsbtbcthlthh")
                temp = gen.GetTable("bangketonkhomathangtheongay '','','','" + denngay + "','kho','" + account + "',''");

            else if (tsbt == "tsbtbctkbcnvotndn")
            {
                string thang = DateTime.Parse(denngay).Month.ToString();
                string nam = DateTime.Parse(denngay).Year.ToString();
                string thangtruoc = DateTime.Parse(denngay).AddMonths(-1).Month.ToString();
                string namtruoc = DateTime.Parse(denngay).AddMonths(-1).Year.ToString();
                string taikhoan = "003";
                temp = gen.GetTable("baocaocongnolaykho '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + taikhoan + "','" + account + "'");
            }
            else if (tsbt == "bkcpbxhgncc")
                temp = gen.GetTable("select distinct a.AccountingObjectID,b.AccountingObjectCode,b.AccountingObjectName  from INInward a, AccountingObject b  where a.AccountingObjectID=b.AccountingObjectID and RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and AccountingObjectType='2' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "')  order by b.AccountingObjectCode");
            else if (tsbt == "bkthhhtx")
                temp = gen.GetTable("select distinct CustomField6,CustomField6,ShippingNo from INOutwardLPG where RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and (CustomField6<>'' or ShippingNo<>'') ");

            else if (tsbt == "tsbtpnkvtddh")
                temp = gen.GetTable("select distinct Contactname,Contactname,ShippingNo from INInwardLPG where RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and ShippingNo<>'' ");

            else if (tsbt == "bctkhhtn" || tsbt == "bctkhhtnlpg" || tsbt == "bctkhhtnvo" || tsbt == "bctknxtt")
                temp = gen.GetTable("select StockID,StockCode,StockName from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') and Inactive=0 order by StockCode");
            else if (tsbt == "bkthhkm")
                temp = gen.GetTable("select distinct c.StockID,StockCode,StockName from INOutwardLPG a,INOutwardLPGQTDetail b, Stock c  where a.StockID=c.StockID and a.RefID=b.RefID and RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + account + "') order by StockCode");
            if (tsbt == "tsbtbctkbcnvotndn")
            {
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][2];
                    dr[1] = temp.Rows[i][0];
                    dr[2] = temp.Rows[i][1];
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0];
                    dr[1] = temp.Rows[i][1];
                    dr[2] = temp.Rows[i][2];
                    dt.Rows.Add(dr);
                }
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.BestFitColumns();
            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            if (tsbt == "tsbtbaocaosanluong" || tsbt == "bkthbhtnvkd")
            {
                view.Columns["Mã kho"].Caption = "Mã nhân viên";
                view.Columns["Tên kho"].Caption = "Tên nhân viên";
            }
            else if (tsbt == "bkcpbxthnv" || tsbt == "bkcpbxth")
            {
                view.Columns["Mã kho"].Caption = "Mã nhân viên";
                view.Columns["Tên kho"].Caption = "Tên nhân viên";
                view.Columns["Mã kho"].Visible = false;
            }
            else if (tsbt == "bkcpbxhgncc")
            {
                view.Columns["Mã kho"].Caption = "Mã nhà cung cấp";
                view.Columns["Tên kho"].Caption = "Tên nhà cung cấp";
            }
            else if (tsbt == "bkthhhtx")
            {
                view.Columns["Mã kho"].Caption = "Số xe";
                view.Columns["Tên kho"].Caption = "Tài xế";
            }
        }

        public void loadStockmainhangtieudung(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string tungay, string denngay, string tsbt)
        {
            view.Columns.Clear();
            view.OptionsView.ColumnAutoWidth = true;
            if (tsbt == "bardckmckunilever")
                lvpq.DataSource = gen.GetTable("select FreeCode as 'Mã khuyến mãi',EmployeeIDSACode as 'Loại',StartDate as 'Bắt đầu',EndDate as 'Kết thúc',SUM(Quantity) as 'Số lượng',Checked as 'Duyệt' from INOutwardCheck where (StartDate<='" + denngay + "' and StartDate>='" + tungay + "') or ((EndDate<='" + denngay + "' and EndDate>='" + tungay + "') or EndDate is NULL) and CheckDate is NULL group by FreeCode,EmployeeIDSACode,StartDate,EndDate,Checked order by EndDate");
            else if (tsbt == "bardckmckgaudo")
                lvpq.DataSource = gen.GetTable("select FreeCode as 'Mã khuyến mãi',EmployeeIDSACode as 'Loại',StartDate as 'Bắt đầu',EndDate as 'Kết thúc',SUM(Quantity) as 'Số lượng',Checked as 'Duyệt' from INOutwardCheck where CheckDate is not NULL and CheckDate>='" + tungay + "' and CheckDate<='" + denngay + "' group by FreeCode,EmployeeIDSACode,StartDate,EndDate,Checked order by EmployeeIDSACode");
            view.Columns["Bắt đầu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Bắt đầu"].DisplayFormat.FormatString = "dd/MM/yyyy";

            view.Columns["Kết thúc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Kết thúc"].DisplayFormat.FormatString = "dd/MM/yyyy";

            
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.BestFitColumns();
            view.Columns["Mã khuyến mãi"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Bắt đầu"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Kết thúc"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng"].Visible = false;
        }


        public void loadkhuyenmainhangtieudung(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu)
        {
            view.Columns.Clear();
            view.OptionsView.ColumnAutoWidth = true;

            lvpq.DataSource = gen.GetTable("select FreeCode as 'Mã khuyến mãi',EmployeeIDSACode as 'Loại',StartDate as 'Bắt đầu',EndDate as 'Kết thúc',SUM(Quantity) as 'Số lượng',SUM(Amount) as 'Số tiền',Checked as 'Duyệt', case when substring(a.InvoiceNo,1,1)='U' then 'Uniclever' else N'Gấu Đỏ' end  as 'Ngành hàng' from INOutwardCheck a, (select * from INOutward where MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "') b where a.InvoiceNo=b.ParalellRefNo or a.InvoiceNo=JournalMemo group by FreeCode,EmployeeIDSACode,StartDate,EndDate,Checked,substring(a.InvoiceNo,1,1) order by EndDate");
            
            view.Columns["Bắt đầu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Bắt đầu"].DisplayFormat.FormatString = "dd/MM/yyyy";

            view.Columns["Kết thúc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Kết thúc"].DisplayFormat.FormatString = "dd/MM/yyyy";


            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Số tiền";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Số tiền"];

            view.BestFitColumns();
            view.Columns["Bắt đầu"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Kết thúc"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng"].Visible = false;

            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Ngành hàng"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void loadthechan(string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            //DataSet da = new DataSet();
            //da.Tables.Add(gen.GetTable("bangkelichsuthechan '" + userid + "'"));
            view.ViewCaption = "Lịch sử thế chân vỏ";
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable da = gen.GetTable("bangkelichsuthechan '" + userid + "'");
            lvpq.DataSource = da;

            view.Columns["Xuất"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Xuất"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Xuất"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Xuất"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Ngày chứng từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatString = "dd/MM/yyyy";

            view.Columns["Mã hàng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["TK Nợ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["TK Có"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            view.Columns["Đơn giá thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá thu"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tổng thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng thu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng thu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng thu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Nhập"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nhập"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nhập"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nhập"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Đơn giá chi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá chi"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tổng chi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng chi"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng chi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng chi"].SummaryItem.DisplayFormat = "{0:n0}";


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Xuất";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Xuất"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Tổng thu";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Tổng thu"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Nhập";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Nhập"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Tổng chi";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Tổng chi"];

            view.Columns["Ngày chứng từ"].Width = 80;
            view.Columns["Số phiếu"].Width = 100;
            view.Columns["Tên hàng"].Width = 120;
            //view.Columns["Mã khách"].GroupIndex = 0;
            view.Columns["Tên khách hàng"].GroupIndex = 0;
            view.Columns["Mã hàng"].GroupIndex = 1;
            view.ExpandAllGroups();

            //gen.CreateExcel(da, "Lichsuthechanvolpg.xlsx");}
        }
        public void loadptcn(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            /*
            DataTable da = gen.GetTable("baocaocongnolaykho '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + 131 + "','" + userid + "'");

            for (int i = 0; i < da.Rows.Count; i++)
            {
                gen.GetTable("baocaocongno131theodonviphantichn '" + da.Rows[i][2] + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131','" + ngaychungtu + "'");
            }
            */

            /*
            da = gen.GetTable("hamaco_ta.dbo.baocaocongnolaykho '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + 131 + "','" + userid + "'");

            for (int i = 0; i < da.Rows.Count; i++)
            {
                gen.GetTable("hamaco_ta.dbo.baocaocongno131theodonviphantichn '" + da.Rows[i][2] + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131','" + ngaychungtu + "'");
            }
            */
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;

            DataTable temp = gen.GetTable("baocaocongnotheonganhhang '" + thang + "','" + nam + "','" + userid + "'");
            //gen.CreateExcel(temp, "Baocaocongnotheonganh_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
            lvpq.DataSource = temp;

            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Còn nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Còn nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Còn nợ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Còn nợ"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Còn nợ"].AppearanceCell.BackColor = Color.SeaShell;

            view.Columns["Ngày hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatString = "dd/MM/yyyy";

            view.Columns["Ngày đến hạn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày đến hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày đến hạn"].DisplayFormat.FormatString = "dd/MM/yyyy";

            view.Columns["Quá hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quá hạn"].DisplayFormat.FormatString = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Thành tiền";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Thành tiền"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Còn nợ";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Còn nợ"];

            view.Columns["Mã ngành"].GroupIndex = 0;
            view.Columns["Mã khách"].GroupIndex = 1;
            view.ExpandAllGroups();

        }

        public void loadbkcthddtt(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;

            DataTable temp = gen.GetTable("bangkechitiethoadonduocthangtoan '" + thang + "','" + nam + "','" + userid + "'");
            
            lvpq.DataSource = temp;
            
            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Ngày hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatString = "dd/MM/yyyy";

            view.Columns["Hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã ngành"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.OptionsView.ColumnAutoWidth = true;
        }


        public void loadBranchmain(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string tungay, string denngay, string userid, string tsbt)
        {
            view.Columns.Clear();
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Tên đơn vị", Type.GetType("System.String"));

            if (tsbt == "sctbhtkhvmhth" || tsbt == "tsbtbctkbcn" || tsbt == "tsbtbctkbcnvo" || tsbt == "tsbtbcslbhtt" || tsbt == "tsbtbcslbhtq" || tsbt == "tsbtbcdtsl" || tsbt == "tsbtdskhm" || tsbt == "tsbtdskhkpsdt" || tsbt == "tsbtbcdtlntt" || tsbt == "tsbtbcdtlnct" || tsbt == "tsbtbcdtlntq")
                temp = gen.GetTable("baocaosanluong '" + tungay + "','" + denngay + "','" + userid + "','" + tsbt + "','kho',''");
           
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.BestFitColumns();
            view.Columns["Mã đơn vị"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadnhanvien(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string tungay, string denngay, string kho, string tsbt)
        {
            view.Columns.Clear();
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã nhân viên", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhân viên", Type.GetType("System.String"));

            if (tsbt == "lvphtbhtnvvsl")
                temp = gen.GetTable("select DISTINCT b.AccountingObjectID,b.AccountingObjectCode,b.AccountingObjectName from SSInvoice a, AccountingObject b where b.AccountingObjectID=a.AccountingObjectID1562 and PURefDate>='" + tungay + "' and PURefDate <='" + denngay + "' and a.BranchID ='" + kho + "' order by b.AccountingObjectCode");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.BestFitColumns();
            view.Columns["Mã nhân viên"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadStocktdv(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu, string userid, string tsbt)
        {
            view.Columns.Clear();
            
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Tên đơn vị", Type.GetType("System.String"));

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
           
            temp = gen.GetTable("select DISTINCT c.BranchID,BranchCode,BranchName from SSInvoice a,Stock b,Branch c where b.BranchID=c.BranchID and a.BranchID=b.StockID and Month(PURefDate)='"+thang+"' and Year(PURefDate)='"+nam+"' and a.BranchID in (select StockID from MSC_UserJoinStock where UserID='"+userid+"') order by BranchCode");
            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.BestFitColumns();
            view.Columns["Mã đơn vị"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadStocktdvtndn(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string tungay, string denngay, string account, string tsbt)
        {
            view.Columns.Clear();

            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Tên đơn vị", Type.GetType("System.String"));

            if (tsbt == "131tndntdv" || tsbt == "331tndntdv" || tsbt == "1313tndntdv" || tsbt == "1313tndnbccnv" || tsbt == "3313tndntdv")
            {
                tsbt = tsbt.Replace("tndntdv", "").Replace("tndnbccnv", "");
                temp = gen.GetTable("baocaocongnotungaydenngaylaykho '" + tsbt + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','','" + account + "'");
            }
            else if (tsbt == "131tndntdvth")
            {
                tsbt = tsbt.Replace("tndntdvth", "");
                temp = gen.GetTable("hamaco.dbo.baocaocongnotungaydenngaylaykhotonghop '" + tsbt + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','donvi','" + account + "'");
            }
            else if (tsbt == "131tndntdvthtk")
            {
                tsbt = tsbt.Replace("tndntdvthtk", "");
                temp = gen.GetTable("hamaco.dbo.baocaocongnotungaydenngaylaykhotonghop '" + tsbt + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','kho','" + account + "'");
            }
            else if (tsbt == "tsbtbccnvkh" || tsbt == "tsbtbccnvkhth" )
                temp = gen.GetTable("baocaocongnovotungaydenngaytheodonvi '','','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khokhach','" + account + "'");
            else if (tsbt == "tsbtbccnvkhtk" || tsbt == "bkthpsv")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheodonvi '','','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khokhachtk','" + account + "'");
            else if (tsbt == "tsbtbccnvncc" || tsbt == "tsbtbccnvnccth")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheodonvi '','','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khonhacungcap','" + account + "'");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.BestFitColumns();
            view.Columns["Mã đơn vị"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadStocktkv(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu, string userid, string tsbt)
        {
            view.Columns.Clear();
            lvpq.Enabled = true;
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã khu vực", Type.GetType("System.String"));
            dt.Columns.Add("Tên khu vực", Type.GetType("System.String"));

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            temp = gen.GetTable("select DISTINCT ProvinceID,ProvinceCode,ProvinceName from Stock a, Province b where a.Province=b.ProvinceCode and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by ProvinceCode");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.BestFitColumns();
            view.Columns["Mã khu vực"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadStockbkhh(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu,string ngaycuoi, string tsbt,string userid)
        {
            view.Columns.Clear();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("IDS", Type.GetType("System.String"));
            if (tsbt == "tsbtbkhhnd" || tsbt == "snkncnb")
            {
                dt.Columns.Add("Kho nhập", Type.GetType("System.String"));
                dt.Columns.Add("Kho xuất", Type.GetType("System.String"));
            }
            else
            {
                dt.Columns.Add("Kho xuất", Type.GetType("System.String"));
                dt.Columns.Add("Kho nhập", Type.GetType("System.String"));
            }
            if (tsbt == "tsbtbkhhnd")
                temp = gen.GetTable("thongkekhonhapxuatdieu '" + ngaychungtu + "','" + ngaycuoi + "','nhap','" + userid + "'");
            else if (tsbt == "snkxcnb")
                //temp = gen.GetTable("select Distinct InwardStockID,OutwardStockID,b.StockCode,b.StockName,c.StockCode,c.StockName from INTransfer a, Stock b, Stock c where a.OutwardStockID=b.StockID and a.InwardStockID=c.StockID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and  OutwardStockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by b.StockCode,c.StockCode");
                temp = gen.GetTable("select Distinct InStockID,OutStockID,b.StockCode,b.StockName,c.StockCode,c.StockName from DDH a, Stock b, Stock c where a.OutStockID=b.StockID and a.InStockID=c.StockID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and  OutStockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by b.StockCode, c.StockCode");
            else if (tsbt == "snkncnb")
                temp = gen.GetTable("select Distinct OutwardStockID,InwardStockID,c.StockCode,c.StockName,b.StockCode,b.StockName from INTransfer a, Stock b, Stock c where a.OutwardStockID=b.StockID and a.InwardStockID=c.StockID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and  InwardStockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by c.StockCode,b.StockCode");
            else
                temp = gen.GetTable("thongkekhonhapxuatdieu '" + ngaychungtu + "','" + ngaycuoi + "','xuat','" + userid + "'");

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0];
                    dr[1] = temp.Rows[i][1];
                    dr[2] ="   "+ temp.Rows[i][2] + " - " + temp.Rows[i][3];
                    dr[3] ="   "+ temp.Rows[i][4] + " - " + temp.Rows[i][5];
                    dt.Rows.Add(dr);
                }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[1].Visible = false;
        }

        public void loadbangkehanghoa(string ngaychungtu, string ngaycuoi, string tsbt, string khonhap, string khoxuat, string tennhap, string tenxuat, string tong)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Ngày hóa đơn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));

            if (tsbt == "tsbtbkhhnd")
                temp = gen.GetTable("thongkehanghoanhapxuatdieu '" + ngaychungtu + "','" + ngaycuoi + "','" + khonhap + "','" + khoxuat + "','nhap'," + tong + "");
            else if (tsbt == "snkxk")
                temp = gen.GetTable("select SUBSTRING(RefNo,7,16),RefDate,InventoryItemName,a.Quantity,a.QuantityConvert,a.Amount,InventoryItemCode,c.AccountingObjectName from INOutwardDetail a, INOutward b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + khonhap + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefNo");
            else if (tsbt == "snknk")
                temp = gen.GetTable("select SUBSTRING(b.RefNo,7,16),PURefDate,InventoryItemName,a.Quantity,a.QuantityConvert,a.Amount,InventoryItemCode,c.AccountingObjectName,b.InvNo,CABARefDate, e.ShippingNo from PUInvoiceDetail a, PUInvoice b, AccountingObject c, InventoryItem d, INInward e where b.ShippingMethodID=e.RefID and  a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.BranchID='" + khonhap + "' and PURefDate>='" + ngaychungtu + "' and PURefDate <='" + ngaycuoi + "' order by b.RefNo");
            else
                temp = gen.GetTable("thongkehanghoanhapxuatdieu '" + ngaychungtu + "','" + ngaycuoi + "','" + khonhap + "','" + khoxuat + "','xuat'," + tong + "");
            
            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                dr[4] = temp.Rows[i][4];
                if (tsbt == "snkxk")
                {
                    dr[6] = temp.Rows[i][7];
                    dr[7] = temp.Rows[i][6];
                }
                else if (tsbt == "snknk")
                {
                    dr[5] = temp.Rows[i][5];
                    dr[6] = temp.Rows[i][7];
                    dr[7] = temp.Rows[i][6];
                }
                else
                {
                    dr[5] = temp.Rows[i][5];
                }
                try
                {
                    dr[8] = temp.Rows[i][8];
                    dr[9] = temp.Rows[i][9];
                    dr[10] = temp.Rows[i][10];
                }
                catch { }
                
                dt.Rows.Add(dr);
            }

            Frm_nhapxuat rp = new Frm_nhapxuat();
            rp.getdata(dt);
            rp.getcongty("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            if (tsbt == "tsbtbkhhnd")
                rp.getrole("Vào " + tennhap.Trim() + " từ " + tenxuat.Trim());
            else if (tsbt == "snkxk" || tsbt=="snknk")
            {
                rp.getrole(tennhap);
            }
            else
                rp.getrole("Từ " + tenxuat.Trim() + " đến " + tennhap.Trim());
            rp.getngay("Từ ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu)) + " đến " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaycuoi)));
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbangkenhapxuatvo(string ngaychungtu, string ngaycuoi, string tsbt, string kho)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("1313", Type.GetType("System.Double"));
            dt.Columns.Add("3313", Type.GetType("System.Double"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));

            if (tsbt == "bkhdbvt")
                temp = gen.GetTable("select RefNo,InventoryItemName,a.Quantity,0,0,DebitAccount,c.AccountingObjectName,InventoryItemCode from INOutwardSUDetail a, INOutwardSU b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and CreditAccount='003' order by RefNo, SortOrder");
            else if (tsbt == "bknmvt")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in bảng kê chi tiết, 'No' để in bảng kê tổng hợp theo xe.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                    temp = gen.GetTable("select RefNo,InventoryItemName,a.Quantity,0,0,CreditAccount,c.AccountingObjectName,InventoryItemCode from INInwardSUDetail a, INInwardSU b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefNo,SortOrder");
                else if (dr == DialogResult.No)
                    temp = gen.GetTable("select soxe,tenhang,SUM(soluong),trongluong,dongia,thanhtien,taixe,mahang from( select case when ShippingNo='' or ShippingNo='TVC' then RefNo else ShippingNo end as soxe,d.InventoryItemName as tenhang,a.Quantity as soluong,0 as trongluong,0 as dongia ,'' as thanhtien,case when ShippingNo='' or ShippingNo='TVC' then AccountingObjectName else Contactname end as taixe,InventoryItemCode as mahang from INInwardLPGDetail a, INInwardLPG b, InventoryItem d where a.RefID=b.RefID and a.InventoryItemID=d.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and b.StockID='" + kho + "') a group by soxe,tenhang,trongluong,dongia,thanhtien,taixe,mahang order by soxe,mahang");
            }
            else if (tsbt == "bknckvlpg")
                temp = gen.GetTable("select RefNoIn,InventoryItemName,a.Quantity,0,0,CreditAccount,c.AccountingObjectName,InventoryItemCode from INTransferSUDetail a, INTransferSU b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.InwardStockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefNo,SortOrder");
            else if (tsbt == "bkxckvlpg")
                temp = gen.GetTable("select RefNo,InventoryItemName,a.Quantity,0,0,CreditAccount,c.AccountingObjectName,InventoryItemCode from INTransferSUDetail a, INTransferSU b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.OutwardStockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefNo,SortOrder");
            else if (tsbt == "snkxktx")
                temp = gen.GetTable("select soxe,tenhang,SUM(soluong),trongluong,dongia,thanhtien,taixe,mahang from( select case when ShippingNo='' or ShippingNo='TVC' then RefNo else CustomField6 end as soxe,d.InventoryItemName as tenhang,a.Quantity as soluong,0 as trongluong,0 as dongia ,'' as thanhtien,case when ShippingNo='' or ShippingNo='TVC' then AccountingObjectName else ShippingNo end as taixe,InventoryItemCode as mahang from INOutwardLPGDetail a, INOutwardLPG b, InventoryItem d where a.RefID=b.RefID and a.InventoryItemID=d.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and b.StockID='" + kho + "') a group by soxe,tenhang,trongluong,dongia,thanhtien,taixe,mahang order by soxe,mahang");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                if (temp.Rows[i][5].ToString() == "1313")
                    dr[4] = temp.Rows[i][4];
                else
                    dr[5] = temp.Rows[i][4];
                dr[6] = temp.Rows[i][6];
                dr[7] = temp.Rows[i][7];
                dt.Rows.Add(dr);
            }

            Frm_nhapxuat rp = new Frm_nhapxuat();
            rp.getdata(dt);
            rp.getngay(ngaychungtu);
            rp.getkho(kho);
            rp.getcongty(ngaycuoi);
            rp.gettsbt(tsbt);
            rp.Show();
        }


        public void loadbangkephieuthu(string ngaychungtu, string ngaycuoi, string tsbt, string kho)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Phiếu số", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tài khoản nợ", Type.GetType("System.String"));
            dt.Columns.Add("Tài khoản có", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));

            if (tsbt == "bkptttkh")
                temp = gen.GetTable("select RefNo,CONVERT(varchar,RefDate,111),DebitAccount,CreditAccount,Amount,AccountingObjectCode,AccountingObjectName from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and CreditAccount='131' and StockID='" + kho + "' order by CONVERT(varchar,RefDate,111),RefNo");
            else if (tsbt == "tsbtptc")
                temp = gen.GetTable("select RefNo,CONVERT(varchar,RefDate,111),DebitAccount,CreditAccount,Amount,AccountingObjectCode,c.AccountingObjectName from CAReceiptTT a, CAReceiptDetailTT b, AccountingObject c where b.AccountingObjectID=c.AccountingObjectID and a.RefID=b.RefID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + kho + "') order by RefNo,CONVERT(varchar,RefDate,111)");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                dr[4] = temp.Rows[i][4];
                dr[5] = temp.Rows[i][5];
                dr[6] = temp.Rows[i][6];
                dt.Rows.Add(dr);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            gen.CreateExcel(ds, "Bangkethutienkhachhang.xlsx");
           
        }

        public void loadnhatkybanhangchitiet(string ngaychungtu,string tsbt, string[,] hoadon, Int32 dem)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            string makho = gen.GetString("select StockID from Stock where StockCode='" + hoadon[0, 1] + "'");
            gen.ExcuteNonquery("dongiavontheokhotungmathang '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + namtruoc + "','" + makho + "'");
            Frm_nhapxuat rp = new Frm_nhapxuat();
            rp.gettsbt(tsbt+"banhangchitiet");
            rp.gethoadon(hoadon);
            rp.getdem(dem);
            rp.Show();
        }

        public void loadnhatkynhaphang(string ngaychungtu, string ngaycuoi, string tsbt,string kho,string khoxuat)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));
            dt.Columns.Add("Nơi giao", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Chưa thuế", Type.GetType("System.Double"));
            dt.Columns.Add("Có thuế", Type.GetType("System.Double"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));

            dt.Columns.Add("Thép", Type.GetType("System.Double"));
            dt.Columns.Add("Xi măng", Type.GetType("System.Double"));
            dt.Columns.Add("Cát", Type.GetType("System.Double"));
            dt.Columns.Add("Đá", Type.GetType("System.Double"));
            dt.Columns.Add("Gạch", Type.GetType("System.Double"));
            dt.Columns.Add("Khác", Type.GetType("System.Double"));

            if (tsbt == "snkxk")
                temp = gen.GetTable("baocaonhapxuatthucte '" + kho + "','" + ngaychungtu + "','" + ngaycuoi + "', 'khong'");
            else if (tsbt == "snkxkct")
            {
                temp = gen.GetTable("baocaonhapxuatthucte '" + kho + "','" + ngaychungtu + "','" + ngaycuoi + "', 'thue'");
            }
            else if (tsbt == "bkpxbhttm")
                temp = gen.GetTable("baocaonhapxuatthucte '" + kho + "','" + ngaychungtu + "','" + ngaycuoi + "', 'tienmat'");
            else if (tsbt == "bkpxhtdnb")
                temp = gen.GetTable("baocaonhapxuatthucte '" + kho + "','" + ngaychungtu + "','" + ngaycuoi + "', 'noibo'");
            else if (tsbt == "tsbtpxk")
            {
                temp = gen.GetTable("baocaonhapxuatthucte '" + kho + "','" + ngaychungtu + "','" + ngaycuoi + "', 'thuekhongphieu'");
                kho = gen.GetString("select * from Stock where StockCode='" + khoxuat + "'");
                khoxuat = "co";
            }
            else if (tsbt == "tsbtpxkct")
            {
                temp = gen.GetTable("baocaonhapxuatthucte '" + kho + "','" + ngaychungtu + "','" + ngaycuoi + "', 'thuephieu'");
                kho = gen.GetString("select * from Stock where StockCode='" + khoxuat + "'");
                khoxuat = "co";
            }
            else if (tsbt == "tsbthdbh")
            {
                temp = gen.GetTable("baocaonhapxuatthucte '" + kho + "','" + ngaychungtu + "','" + ngaycuoi + "', 'thuephieuhd'");
                kho = gen.GetString("select * from Stock where StockCode='" + khoxuat + "'");
                khoxuat = "co";
            }
            else if (tsbt == "tsbttrahang")
            {
                temp = gen.GetTable("baocaonhapxuatthucte '" + kho + "','" + ngaychungtu + "','" + ngaycuoi + "', 'thuephieutrahang'");
                kho = khoxuat;
                khoxuat = "";
            }
            else if (tsbt == "snkxcnb")
                //temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,Round((a.Amount+a.Cost)/a.QuantityConvert,2),a.Amount+Cost,a.Amount+Cost,0,RefNoIn,NULL from INTransferDetail a, INTransfer  b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.OutwardStockID='" + kho + "' and b.InwardStockID='" + khoxuat + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "'");
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.QuantityExits=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.QuantityExits,a.QuantityConvertExits,Cost,DiscountAmount,DiscountAmount,0,'',NULL from DDHDetail a, DDH  b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.OutStockID='" + kho + "' and b.InStockID='" + khoxuat + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and INOut='True'");
            else if (tsbt == "snkncnb")
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.QuantityExits=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.QuantityExits,a.QuantityConvertExits,Cost,DiscountAmount,DiscountAmount,0,'',NULL from DDHDetail a, DDH  b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.OutStockID='" + khoxuat + "' and b.InStockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and Status='True'");
            else if (tsbt == "snkxcnbtc")
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.QuantityExits=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.QuantityExits,a.QuantityConvertExits,Cost,DiscountAmount,DiscountAmount,0,'',NULL from DDHDetail a, DDH  b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.OutStockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and INOut='True'");
            else if (tsbt == "bchgkhkhach")
            {
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.QuantityExits=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.QuantityExits,a.QuantityConvertExits,Cost,DiscountAmount,DiscountAmount,0,'',NULL from DDHDetail a, DDH  b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and (b.OutStockID='" + kho + "' or b.InStockID='" + kho + "') and b.AccountingObjectID='" + khoxuat + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and INOut='True'");
                khoxuat = "";
            }
            else if (tsbt == "bkcpbx")
            {
                if (gen.GetString("select CompanyTaxCode from Center") == "")
                    temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.DiscountRate,a.DiscountRate*a.QuantityConvert,a.DiscountRate*a.QuantityConvert,c.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardDetail a, INOutward b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and a.DiscountRate<>0");
                else
                    temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.ConvertRate,a.UnitPriceConvertOC,a.UnitPriceConvertOC,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardDetail a, INOutward b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and a.UnitPriceConvertOC<>0");
            }
            else if (tsbt == "bkcpk")
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.DGPhi,a.DGPhi*QuantityConvert,a.DGPhi*QuantityConvert,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardDetail a, INOutward b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and a.DGPhi<>0");
            else if (tsbt == "bkcpbxv")
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.UnitPriceConvertOC,a.AmountOC,a.AmountOC,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardSUDetail a, INOutwardSU b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and a.AmountOC<>0");
            else if (tsbt == "bkcpvcbh")
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.CustomField1,a.CustomField2,a.CustomField2,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardDetail a, INOutward b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and a.CustomField2<>0");
            else if (tsbt == "bkcpbxthnv")
            {
                if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004")
                    temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,SaleDescription,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.ConvertRate,a.UnitPriceConvertOC,a.UnitPriceConvertOC,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardLPGDetail a, INOutwardLPG b, AccountingObject c, InventoryItem d where b.ShippingNo=N'" + kho + "' and a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefDate");
                else
                    temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,SaleDescription,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,0,0,0,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardDetail a, INOutward b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.Taixe=N'" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefDate");
                //else return;
            }
            else if (tsbt == "bkcpbxth")
            {
                if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004")
                    temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,SaleDescription,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.ConvertRate,a.UnitPriceConvertOC,a.UnitPriceConvertOC,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardLPGDetail a, INOutwardLPG b, AccountingObject c, InventoryItem d where b.CustomField2=N'" + kho + "' and a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefDate");
                else
                    temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,SaleDescription,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,0,0,0,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardDetail a, INOutward b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and Shipper=N'" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefDate");
                //else return;
            }
            else if (tsbt == "bkthhkm")
                temp = gen.GetTable("select substring(RefNo,4,12),RefDate,InventoryItemName,ShippingNo,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,0,0,0,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardLPGQTDetail a, INOutwardLPG b, AccountingObject c, InventoryItem d where b.StockID='" + kho + "' and a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' order by RefDate");
            else if (tsbt == "bkthhhtx")
                temp = gen.GetTable("select substring(RefNo,7,9),RefDate,InventoryItemName,a.CustomField1,b.Contactname,b.AccountingObjectAddress,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.ConvertRate,a.UnitPriceConvertOC,a.UnitPriceConvertOC,b.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INOutwardLPGDetail a, INOutwardLPG b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and CustomField6=N'" + kho + "' and ShippingNo=N'" + khoxuat + "'");

            else if (tsbt == "tsbtpnkvtddh")
                temp = gen.GetTable("select InventoryItemCode,CAST(RefDate as DATE),InventoryItemName,NULL,NULL,NULL,0,sum(a.Quantity),sum(a.QuantityConvert),0,0,0,Null,Null,NULL from INInwardLPGDetail a, INInwardLPG b, InventoryItem d where a.RefID=b.RefID and a.InventoryItemID=d.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and Contactname=N'" + kho + "' and ShippingNo=N'" + khoxuat + "' group by InventoryItemCode,CAST(RefDate as DATE),InventoryItemName order by InventoryItemCode");

            else if (tsbt == "bkcpbxxck")
                temp = gen.GetTable("bangkelaykho '" + ngaychungtu + "','" + ngaycuoi + "','" + kho + "','dulieu'");
            else if (tsbt == "bkcpbxxckv")
                temp = gen.GetTable("bangkelaykho '" + ngaychungtu + "','" + ngaycuoi + "','" + kho + "','dulieuvo'");
            else if (tsbt == "bkcpbxnck")
                temp = gen.GetTable("bangkelaykho '" + ngaychungtu + "','" + ngaycuoi + "','" + kho + "','bocxepnhan'");
            else if (tsbt == "bkcpbxthhh")
                temp = gen.GetTable("bangkelaykho '" + ngaychungtu + "','" + ngaycuoi + "','" + kho + "','bocxeptonghop'");
            else if (tsbt == "bkcpbxnckv")
                temp = gen.GetTable("bangkelaykho '" + ngaychungtu + "','" + ngaycuoi + "','" + kho + "','bocxepnhanvo'");
            else if (tsbt == "bkcpvcnck")
                temp = gen.GetTable("bangkelaykho '" + ngaychungtu + "','" + ngaycuoi + "','" + kho + "','vanchuyennhan'");
            else if (tsbt == "bkcpvcxck")
                temp = gen.GetTable("bangkelaykho '" + ngaychungtu + "','" + ngaycuoi + "','" + kho + "','vanchuyenxuat'");
            else if (tsbt == "bkcpbxnh")
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.UnitPriceOC,a.UnitPriceConvert,a.UnitPriceConvert,c.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INInwardDetail a, INInward b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and AccountingObjectType<>'2' and a.UnitPriceConvert<>0");
            else if (tsbt == "bkcpbxnhv")
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.UnitPriceConvertOC,a.AmountOC,a.AmountOC,c.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INInwardSUDetail a, INInwardSU b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and a.AmountOC<>0");
            else if (tsbt == "bkcpbxnhtdv")
                temp = gen.GetTable("select RefNo,RefDate,InventoryItemName,ShippingNo,b.Contactname,JournalMemo,CASE WHEN a.Quantity=0 THEN d.ConvertUnit ELSE d.Unit END AS ConvertUnit,a.Quantity,a.QuantityConvert,a.UnitPriceOC,a.UnitPriceConvert,a.UnitPriceConvert,c.AccountingObjectName+'('+AccountingObjectCode+')',InventoryItemCode,NULL from INInwardDetailTT a, INInwardTT b, AccountingObject c, InventoryItem d where a.RefID=b.RefID and b.AccountingObjectID=c.AccountingObjectID and a.InventoryItemID=d.InventoryItemID and b.StockID='" + kho + "' and RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and a.UnitPriceConvert<>0");



            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = String.Format("{0:MM-dd-yyyy}", DateTime.Parse(temp.Rows[i][1].ToString()));
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                if (temp.Rows[i][4].ToString() != "")
                    dr[4] = "ĐĐGH: " + temp.Rows[i][4];
               
                dr[6] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7];
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = temp.Rows[i][8];
                try
                {
                    if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                        dr[9] = temp.Rows[i][9];
                }
                catch { }
                try
                {
                    if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                        dr[10] = temp.Rows[i][10];
                }
                catch { }
                try
                {
                    if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    {
                        dr[11] = temp.Rows[i][11];
                        string nhom=temp.Rows[i][13].ToString().Substring(0,3);
                        if (nhom == "724")
                            dr[14] = temp.Rows[i][11];
                        else if (nhom == "252")
                            dr[15] = temp.Rows[i][11];
                        else if (nhom == "254")
                            dr[16] = temp.Rows[i][11];
                        else if (nhom == "253")
                            dr[17] = temp.Rows[i][11];
                        else if (nhom == "693" || nhom == "691")
                            dr[18] = temp.Rows[i][11];
                        else dr[19] = temp.Rows[i][11];
                    }
                }
                catch { }
                dr[12] = temp.Rows[i][12];
                dr[13] = temp.Rows[i][13];

                if (temp.Rows[i][14].ToString() != "")
                {
                    if (khoxuat == "co")
                    {
                        DataTable da = gen.GetTable("select Distinct  CAST (InvNo AS float) from SSInvoice a, SSInvoiceINOutward b where a.RefID=b.SSInvoiceID and INOutwardID='" + temp.Rows[i][14] + "' order by CAST(a.InvNo as Float)");
                        for (int j = 0; j < da.Rows.Count; j++)
                        {
                            if (dr[5].ToString() == "")
                                dr[5] = da.Rows[j][0].ToString();
                            else
                                dr[5] = dr[5] + "," + da.Rows[j][0].ToString();
                        }
                    }
                }
                else
                {
                    dr[5] = "Ghi chú: " + temp.Rows[i][5].ToString();
                }

                /*if (tsbt == "bkcpbx" || tsbt == "bkcpbxxck" || tsbt == "bkcpbxnh" || tsbt == "bkcpbxnhtdv")
                    //dr[5] = temp.Rows[i][12].ToString();*/

                dt.Rows.Add(dr);
            }

            Frm_nhapxuat rp = new Frm_nhapxuat();
            rp.getdata(dt);
            rp.getcongty(kho);
            rp.getngay(ngaychungtu);
            rp.getrole(ngaycuoi);
            rp.getkho(khoxuat);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadnhaphangtrongkymain(string makho, string tungay, string denngay, string tsbt, string userid)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            if (tsbt == "sctmhtmh")
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,sum(Quantity),sum(QuantityConvert),sum(Amount),InventoryCategoryCode,InventoryCategoryName,b.PurchaseDescription from PUInvoiceDetail a, InventoryItem b,InventoryItemCategory c" +
                    " where b.InventoryCategoryID=c.InventoryCategoryID and a.InventoryItemID=b.InventoryItemID and RefID in (select RefID from PUInvoice a, Stock b where a.BranchID=b.StockID and PURefDate >= '" + tungay + "' and PURefDate <='" + denngay + "' and Parent='" + makho + "')" +
                    "group by InventoryItemCode,InventoryItemName,InventoryCategoryName,InventoryCategoryCode,b.PurchaseDescription");
            
            else if (tsbt == "sctbhtkhvmh")
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,sum(Quantity),sum(QuantityConvert),sum(Amount),AccountingObjectCode,c.AccountingObjectName from SSInvoiceDetail a, InventoryItem b,AccountingObject c,SSInvoice d" +
                    " where c.AccountingObjectID=d.AccountingObjectID and a.InventoryItemID=b.InventoryItemID and a.RefID=d.RefID and PURefDate >= '" + tungay + "' and PURefDate <='" + denngay + "' and d.BranchID ='" + makho + "'" +
                    "group by InventoryItemCode,InventoryItemName,AccountingObjectCode,c.AccountingObjectName");

            else if (tsbt == "bkcthdbh")
                temp = gen.GetTable("select substring(RefNo,7,15) as RefNo,c.AccountingObjectName, QuantityConvert,a.UnitPrice,Amount,InventoryItemCode,InventoryItemName from SSInvoiceDetail a, InventoryItem b,AccountingObject c,SSInvoice d" +
                    " where c.AccountingObjectID=d.AccountingObjectID and a.InventoryItemID=b.InventoryItemID and a.RefID=d.RefID and PURefDate >= '" + tungay + "' and PURefDate <='" + denngay + "' and d.BranchID ='" + makho + "'" +
                    "order by RefNo");
            
            else if (tsbt == "bkxktkhvmh")
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,sum(Quantity),sum(QuantityConvert),sum(AmountOC),AccountingObjectCode,c.AccountingObjectName from INOutwardDetail a, InventoryItem b,AccountingObject c, INOutward d" +
                    " where c.AccountingObjectID=d.AccountingObjectID and a.InventoryItemID=b.InventoryItemID and a.RefID=d.RefID and RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and d.StockID='" + makho + "'" +
                    "group by InventoryItemCode,InventoryItemName,AccountingObjectCode,c.AccountingObjectName");

            else if (tsbt == "bkxktmhpx")
                temp = gen.GetTable("select Substring(RefNo,7,15) as RefNo,AccountingObjectName,Quantity,QuantityConvert,AmountOC,InventoryItemCode,InventoryItemName,a.UnitPrice from INOutwardDetail a, InventoryItem b, INOutward d" +
                    " where a.InventoryItemID=b.InventoryItemID and a.RefID=d.RefID and RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and d.StockID='" + makho + "' order by  RefNo");

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                dr[4] = temp.Rows[i][4];
                dr[5] = temp.Rows[i][5];
                dr[6] = temp.Rows[i][6];
                if (tsbt == "bkxktmhpx")
                    dr[7] = temp.Rows[i][7];
                if (tsbt == "sctmhtmh")
                    dr[8] = temp.Rows[i][7];
                dt.Rows.Add(dr);
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getaccount(userid);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt);
            rp.getkho(makho);
            rp.Show();
        }


        public void loadchitiethoadon(string hoadon, string sohoadon, string tsbt, string ngay)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            if (tsbt == "tsbthdbhchitiet")
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,QuantityConvert,a.UnitPrice,a.TotalAmount,substring(RefNo,7,15) as RefNo,d.AccountingObjectName, RefDate from SSInvoiceINOutward a, InventoryItem b,AccountingObject c, INOutward d where c.AccountingObjectID=d.AccountingObjectID and a.InventoryItemID=b.InventoryItemID and a.INOutwardID=d.RefID and a.SSInvoiceID='" + hoadon + "' order by RefNo");
            else if (tsbt == "tsbthdbhchitiettomtat")
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,sum(QuantityConvert),sum(a.TotalAmount)/sum(QuantityConvert),sum(a.TotalAmount),NULL,NULL,NULL from SSInvoiceINOutward a, InventoryItem b,AccountingObject c, INOutward d where c.AccountingObjectID=d.AccountingObjectID and a.InventoryItemID=b.InventoryItemID and a.INOutwardID=d.RefID and a.SSInvoiceID='" + hoadon + "' group by InventoryItemCode,InventoryItemName order by InventoryItemCode");
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.DateTime"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString())!=0)
                    dr[3] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4];
                dr[5] = temp.Rows[i][5];
                dr[6] = temp.Rows[i][6];
                dr[8] = temp.Rows[i][7];
                dt.Rows.Add(dr);
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(ngay);
            rp.gettsbt(tsbt);
            rp.getkho(sohoadon);
            rp.gettenkh(hoadon);
            rp.Show();
        }

        public void loadbaocaosanluong(string madonvi, string tungay, string denngay, string tsbt, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();
            if (tsbt == "sctbhtkhvmhth" || tsbt == "sctbhtkhvmhthnhom")
                temp = gen.GetTable("baocaosanluong '" + tungay + "','" + denngay + "','" + userid + "','" + tsbt + "','sanluong','" + madonvi + "'");
            lvpq.DataSource = temp;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Số lượng";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Số lượng"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Trọng lượng";
            item1.DisplayFormat = "{0:n2}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Trọng lượng"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Thành tiền";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Thành tiền"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Giá vốn";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Giá vốn"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Chênh lệch";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Chênh lệch"];


            view.Columns["Chênh lệch"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chênh lệch"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chênh lệch"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chênh lệch"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Chênh lệch"].AppearanceCell.BackColor = Color.SeaShell;

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            
            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Đơn giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá vốn"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns["Giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Giá vốn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Giá vốn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Giá vốn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Ngày"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã kho"].Width = 50;

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Ngành hàng"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void loadbaocaotinhhinhkinhdoanh(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string tsbt)
        {
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            if (tsbt == "barthkqkdhtd")
                temp = gen.GetTable("tonghopketquakinhdoanhtheokhohangtieudung '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + userid + "'");
            else if (tsbt == "barthkqkdtn")
            {
                temp = gen.GetTable("tonghopketquakinhdoanhtheokhotheonganh '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + userid + "'");
                tsbt = "barthkqkdhtd";
            }
            lvpq.DataSource = temp;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Số lượng";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Số lượng"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Khuyến mãi";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Khuyến mãi"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Thành tiền";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Thành tiền"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item2.FieldName = "Doanh thu";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item2.ShowInGroupColumnFooter = view.Columns["Doanh thu"];


            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Giá vốn";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Giá vốn"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Lãi gộp";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Lãi gộp"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "Giá vốn khuyến mãi";
            item6.DisplayFormat = "{0:n0}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["Giá vốn khuyến mãi"];


            view.Columns["Lãi gộp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lãi gộp"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lãi gộp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lãi gộp"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Lãi gộp"].AppearanceCell.BackColor = Color.SeaShell;

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Khuyến mãi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Khuyến mãi"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Khuyến mãi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Khuyến mãi"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Giá vốn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Giá vốn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Giá vốn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Giá vốn khuyến mãi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Giá vốn khuyến mãi"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Giá vốn khuyến mãi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Giá vốn khuyến mãi"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Doanh thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Doanh thu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Doanh thu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Doanh thu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["ĐVT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["ĐVT"].Width = 50;

            view.Columns["Quy cách"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quy cách"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Quy cách"].Width = 50;

            view.Columns["Tỷ lệ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tỷ lệ"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Tỷ lệ"].Width = 50;
            view.Columns["Tỷ lệ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Ngành hàng"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void loadbaocaotinhhinhgiaonhan(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();
            
            temp = gen.GetTable("baocaotinhhinhgiaonhan '" + userid + "','"+ngaychungtu+"'");
            lvpq.DataSource = temp;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Đơn rớt";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Đơn rớt"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Hôm nay";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Hôm nay"];


            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Doanh thu";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Doanh thu"];


            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Doanh thu trước";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Doanh thu trước"];


            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Ngày trước";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Ngày trước"];

            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Đơn rớt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn rớt"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Đơn rớt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Đơn rớt"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Ngày trước"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Ngày trước"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Ngày trước"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Ngày trước"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Hôm nay"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hôm nay"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hôm nay"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Hôm nay"].SummaryItem.DisplayFormat = "{0:n0}";


            view.Columns["Doanh thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Doanh thu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Doanh thu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Doanh thu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Doanh thu ngày trước"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Doanh thu ngày trước"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Doanh thu ngày trước"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Doanh thu ngày trước"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsBehavior.Editable = true;
            view.Columns[0].OptionsColumn.AllowEdit = false;
            view.Columns[1].OptionsColumn.AllowEdit = false;
            view.Columns[2].OptionsColumn.AllowEdit = false;
            view.Columns[3].OptionsColumn.AllowEdit = false;
            view.Columns[4].OptionsColumn.AllowEdit = false;
            view.Columns[5].OptionsColumn.AllowEdit = false;
            view.Columns[6].OptionsColumn.AllowEdit = false;
            view.Columns[7].OptionsColumn.AllowEdit = false;
           
           
            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Ngành hàng"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void loadbaocaodoanhthutrahang(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();

            temp = gen.GetTable("baocaodoanhthutrahang '" + userid + "','" + ngaychungtu + "'");
            lvpq.DataSource = temp;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Đơn rớt";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Đơn rớt"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Đơn hàng";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Đơn hàng"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Doanh thu";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Doanh thu"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Doanh thu rớt";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Doanh thu rớt"];

            view.Columns["Doanh thu rớt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Doanh thu rớt"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Doanh thu rớt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Doanh thu rớt"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Đơn rớt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn rớt"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Đơn rớt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Đơn rớt"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Doanh thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Doanh thu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Doanh thu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Doanh thu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Đơn hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn hàng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Đơn hàng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Đơn hàng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tỷ lệ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tỷ lệ"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Ngành hàng"].GroupIndex = 0;
            view.ExpandAllGroups();
        }


        public void loadbaocaotinhhinhkinhdoanhloinhuan(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            temp = gen.GetTable("tonghopketquakinhdoanhtheokhohangtieudungloinhuan '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + userid + "'");
            lvpq.DataSource = temp;


            
            view.Columns["Lãi gộp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lãi gộp"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lãi gộp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lãi gộp"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Thu nhập khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thu nhập khác"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thu nhập khác"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thu nhập khác"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chi phí khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chi phí khác"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chi phí khác"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chi phí khác"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tăng giảm phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tăng giảm phí"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tăng giảm phí"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tăng giảm phí"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Lãi vay"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lãi vay"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lãi vay"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lãi vay"].SummaryItem.DisplayFormat = "{0:n0}";
            

            view.Columns["Lương"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lương"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lương"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lương"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chi phí tài chính"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chi phí tài chính"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chi phí tài chính"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chi phí tài chính"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chi phí bán hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chi phí bán hàng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chi phí bán hàng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chi phí bán hàng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Giá vốn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Giá vốn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Giá vốn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Doanh thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Doanh thu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Doanh thu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Doanh thu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chi phí quản lý"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chi phí quản lý"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chi phí quản lý"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chi phí quản lý"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chiết khấu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chiết khấu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tổng chi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng chi"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng chi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng chi"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Tổng chi"].AppearanceCell.BackColor = Color.SeaShell;

            view.Columns["Tổng thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng thu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng thu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng thu"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Tổng thu"].AppearanceCell.BackColor = Color.SeaShell;

            view.Columns["Lợi nhuận"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lợi nhuận"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lợi nhuận"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lợi nhuận"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Lợi nhuận"].AppearanceCell.BackColor = Color.Salmon;

            view.Columns["Mã ngành"].Visible = false;

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }


        public void bangkegiadieuchenhlechgiavon(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();
            temp = gen.GetTable("bangkegiadieuchenhlechgiavon '" + ngaychungtu + "','" + userid + "'");
            lvpq.DataSource = temp;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Số lượng";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Số lượng"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Trọng lượng";
            item1.DisplayFormat = "{0:n2}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Trọng lượng"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Đơn giá";
            item2.DisplayFormat = "{0:n2}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Đơn giá"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Thành tiền";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Thành tiền"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Đơn giá vốn";
            item4.DisplayFormat = "{0:n2}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Đơn giá vốn"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "Giá vốn";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["Giá vốn"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "Chênh lệch";
            item6.DisplayFormat = "{0:n0}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["Chênh lệch"];


            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns["Đơn giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá vốn"].DisplayFormat.FormatString = "{0:n2}";
            
            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n2}";


            view.Columns["Giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Giá vốn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Giá vốn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Giá vốn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chênh lệch"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chênh lệch"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chênh lệch"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chênh lệch"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Kho nhận"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Kho nhận"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["ID"].Visible = false;
            view.Columns["Mã hàng"].Width = 100;
            view.Columns["Tên hàng"].Width = 180;
          
            view.Columns["Kho nhận"].GroupIndex = 0;
            view.Columns["Kho xuất"].GroupIndex = 1;
            view.ExpandAllGroups();
        }

        public void loadbaocaocongnotheonganh(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();
            temp = gen.GetTable("baocaocongnotheonganhhangchitiet '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + userid + "'");
            lvpq.DataSource = temp;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Đầu kỳ";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Đầu kỳ"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Phát sinh nợ";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Phát sinh nợ"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Phát sinh có";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Phát sinh có"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Số dư cuối kỳ";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Số dư cuối kỳ"];


            view.Columns["Đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Đầu kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Đầu kỳ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Phát sinh nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Phát sinh nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Phát sinh nợ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Phát sinh nợ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Phát sinh có"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Phát sinh có"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Phát sinh có"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Phát sinh có"].SummaryItem.DisplayFormat = "{0:n0}";


            view.Columns["Số dư cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số dư cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số dư cuối kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số dư cuối kỳ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Mã khách"].Width = 100;
            view.Columns["Tên khách hàng"].Width = 250;

            view.Columns["Mã ngành"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void loadbaocaosanluongmuaban(string tungay, string denngay, string tsbt,DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string userid)
        {
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();
            temp = gen.GetTable("baocaosanluongmuaban '" + tungay + "','" + denngay + "','" + userid + "'");
            lvpq.DataSource = temp;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Số lượng mua";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Số lượng mua"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Trọng lượng mua";
            item1.DisplayFormat = "{0:n2}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Trọng lượng mua"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Số lượng bán";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Số lượng bán"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Trọng lượng bán";
            item3.DisplayFormat = "{0:n2}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Trọng lượng bán"];


            view.Columns["Số lượng mua"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng mua"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng mua"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng mua"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng bán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng bán"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng bán"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng bán"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trọng lượng mua"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng mua"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Trọng lượng mua"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trọng lượng mua"].SummaryItem.DisplayFormat = "{0:n2}";

          
            view.Columns["Trọng lượng bán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng bán"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trọng lượng bán"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trọng lượng bán"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Mã đơn vị"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã nhóm"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã nhà cung cấp"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Mã nhóm"].Width = 50;
            view.Columns["Mã nhà cung cấp"].Width = 100;
            view.Columns["Mã đơn vị"].Width = 50;
            view.Columns["Tên đơn vị"].Width = 150;

            view.Columns["Mã nhóm"].GroupIndex = 0;
            view.Columns["Nhà cung cấp"].GroupIndex = 1;
            view.ExpandAllGroups();
        }


        public void loadbaocaosanluongchietkhau(string ngaychungtu, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            view.OptionsView.ShowGroupPanel = true;
            DataTable temp = new DataTable();
            temp = gen.GetTable("baocaosanluongchietkhau '" + DateTime.Parse(ngaychungtu).Month.ToString() + "','" + DateTime.Parse(ngaychungtu).Year.ToString() + "','" + userid + "'");
            lvpq.DataSource = temp;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Số lượng";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Số lượng"];


            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Trọng lượng";
            item1.DisplayFormat = "{0:n2}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Trọng lượng"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "CK sản lượng";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["CK sản lượng"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "CK thanh toán";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["CK thanh toán"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "CK trực tiếp";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["CK trực tiếp"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "CK ngắn hạn";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["CK ngắn hạn"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "Hỗ trợ vùng";
            item6.DisplayFormat = "{0:n0}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["Hỗ trợ vùng"];

            GridGroupSummaryItem item7 = new GridGroupSummaryItem();
            item7.FieldName = "Hỗ trợ CT";
            item7.DisplayFormat = "{0:n0}";
            item7.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item7);
            item7.ShowInGroupColumnFooter = view.Columns["Hỗ trợ CT"];

            GridGroupSummaryItem item8 = new GridGroupSummaryItem();
            item8.FieldName = "Hỗ trợ VC";
            item8.DisplayFormat = "{0:n0}";
            item8.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item8);
            item8.ShowInGroupColumnFooter = view.Columns["Hỗ trợ VC"];

            GridGroupSummaryItem item9 = new GridGroupSummaryItem();
            item9.FieldName = "CK khác";
            item9.DisplayFormat = "{0:n0}";
            item9.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item9);
            item9.ShowInGroupColumnFooter = view.Columns["CK khác"];

            GridGroupSummaryItem item10 = new GridGroupSummaryItem();
            item10.FieldName = "Tổng";
            item10.DisplayFormat = "{0:n0}";
            item10.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item10);
            item10.ShowInGroupColumnFooter = view.Columns["Tổng"];

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["CK sản lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["CK sản lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["CK sản lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["CK sản lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["CK thanh toán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["CK thanh toán"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["CK thanh toán"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["CK thanh toán"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["CK trực tiếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["CK trực tiếp"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["CK trực tiếp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["CK trực tiếp"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["CK ngắn hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["CK ngắn hạn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["CK ngắn hạn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["CK ngắn hạn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Hỗ trợ vùng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hỗ trợ vùng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hỗ trợ vùng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Hỗ trợ vùng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Hỗ trợ CT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hỗ trợ CT"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hỗ trợ CT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Hỗ trợ CT"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Hỗ trợ VC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hỗ trợ VC"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hỗ trợ VC"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Hỗ trợ VC"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["CK khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["CK khác"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["CK khác"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["CK khác"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tổng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng"].SummaryItem.DisplayFormat = "{0:n0}";

            

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

         
            view.Columns["Nhà cung cấp"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;            
            view.Columns["Nhà cung cấp"].Width = 50;
            view.Columns["Tên hàng"].Width = 150;
            view.Columns["Nhà cung cấp"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void loadnhapxuathangtrongkymain(string madonvi, string tungay, string denngay, string tsbt, string userid, string loai)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            /*if (tsbt == "sctbhtkhvmhth")
            {
                temp = gen.GetTable("hamaco.dbo.baocaosanluong '" + tungay + "','" + denngay + "','" + userid + "','" + tsbt + "','sanluong','" + madonvi + "'");
                if (loai == "No")
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(temp);
                    gen.CreateExcel(ds, "Bangkebanhang_" + gen.GetString("select BranchCode from Branch where BranchID='" + madonvi + "'") + "_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + "_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay)));
                    return;
                }
            }*/

            dt.Columns.Add("Mã nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            for (int i = 0; i < temp.Rows.Count; i++)
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
                dt.Rows.Add(dr);
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getaccount(userid);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt);
            rp.getkho(madonvi);
            rp.Show();
        }

        public void loadnhaphangtrongkytheohdmain(string makho, string tungay, string denngay, string tsbt, string userid)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            if (tsbt == "sctbhtkhvhd")
            {
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,sum(Quantity),sum(QuantityConvert),sum(Amount),AccountingObjectCode,c.AccountingObjectName,d.InvNo,PURefDate,TotalDiscountAmount from SSInvoiceDetail a, InventoryItem b,AccountingObject c,SSInvoice d" +
                    " where c.AccountingObjectID=d.AccountingObjectID and a.InventoryItemID=b.InventoryItemID and a.RefID=d.RefID and PURefDate>='" + tungay + "' and PURefDate <='" + denngay + "' and d.BranchID ='" + makho + "'" +
                    "group by InventoryItemCode,InventoryItemName,AccountingObjectCode,c.AccountingObjectName,d.InvNo,PURefDate,TotalDiscountAmount");
            }
            else if (tsbt == "snkmh")
                temp = gen.GetTable("select * from (select  '' as sophieu,AccountingObjectCode,sum(TotalAmount+TotalFreightAmount) as thanhtien,sum(TotalVATAmount) as thue,sum(TotalVATAmount+TotalAmount+TotalFreightAmount) as tongtien,b.AccountingObjectName,Tax,InvNo,cast(CABARefDate as date) as ngaylap,DueDateTime from PUInvoice a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and a.BranchID='" + makho + "' and PURefDate>='" + tungay + "' and PURefDate <='" + denngay + "' group by AccountingObjectCode,b.AccountingObjectName,Tax,InvNo,cast(CABARefDate as date),DueDateTime) a order by AccountingObjectCode,InvNo,ngaylap");
            else if (tsbt == "snkbh")
                temp = gen.GetTable("select SUBSTRING(RefNo,7,16),AccountingObjectCode,TotalAmount-TotalDiscountAmount-TotalFreightAmount+TotalCost,TotalVATAmount,TotalVATAmount+TotalAmount-TotalDiscountAmount-TotalFreightAmount+TotalCost,b.AccountingObjectName,Tax,InvNo,CABARefDate,DueDateTime from SSInvoice a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and a.BranchID='" + makho + "' and PURefDate>='" + tungay + "' and PURefDate <='" + denngay + "' order by RefNo  ");

            else if (tsbt == "tsbtthbhtdtkh")
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,sum(Quantity),sum(QuantityConvert),sum(Amount),CASE WHEN d.IssueBy=N'Bán lẻ' then '01' when d.IssueBy=N'Bán sỉ' then '02' else '03' end,d.IssueBy,c.InventoryCategoryName,'',sum(TotalDiscountAmount) from SSInvoiceDetail a, InventoryItem b,InventoryItemCategory c,SSInvoice d where a.InventoryItemID=b.InventoryItemID and b.InventoryCategoryID=c.InventoryCategoryID and a.RefID=d.RefID and PURefDate>='" + tungay + "' and PURefDate <='" + denngay + "' and d.BranchID ='" + makho + "' group by InventoryItemCode,InventoryItemName,SUBSTRING(InventoryItemCode,1,3),d.IssueBy,c.InventoryCategoryName");

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Ngày HĐ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            
            for (int i = 0; i < temp.Rows.Count; i++)
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
                if (temp.Rows[i][8].ToString() != "")
                    dr[8] = temp.Rows[i][8];
                if (tsbt == "snkmh" || tsbt == "snkbh")
                    dr[9] = temp.Rows[i][9];
                else if (tsbt == "sctbhtkhvhd" || tsbt == "tsbtthbhtdtkh")
                {
                    if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                        dr[9] = temp.Rows[i][9];
                }
                dt.Rows.Add(dr);
            }
            if (tsbt == "sctbhtkhvhd")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in chi tiết, 'No' để xuất excel.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.No)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    gen.CreateExcel(ds,"Bangketonghophanghoa.xlsx");
                    return;
                }
                else if (dr == DialogResult.Cancel)
                    return;
            }
           
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getaccount(userid);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt);
            rp.getkho(makho);
            rp.Show();
        }

        public void loadbangkehanghoatong(string ngaychungtu, string ngaycuoi, string tsbt, string khonhap, string khoxuat, string tennhap, string tenxuat, string tong)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Nhóm", Type.GetType("System.String"));
            if (tsbt == "tsbtbkhhnd")
                temp = gen.GetTable("thongkehanghoanhapxuatdieu '" + ngaychungtu + "','" + ngaycuoi + "','" + khonhap + "','" + khoxuat + "','nhap'," + tong + "");
            else if (tsbt == "bkthbhtnvkd")
            {
                //temp = gen.GetTable("select InventoryItemCode,InventoryItemName,SUM(Quantity),SUM(QuantityConvert),0 from INOutward a,INOutwardDetail b, InventoryItem c where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and EmployeeIDSA='" + khonhap + "' group by InventoryItemCode,InventoryItemName order by SUBSTRING(InventoryItemCode,8,2),InventoryItemCode");   
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,SUM(Quantity),SUM(QuantityConvert),0,InventoryCategoryName from INOutward a,INOutwardDetail b, InventoryItem c, InventoryItemCategory d where c.InventoryCategoryID=d.InventoryCategoryID and a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and EmployeeIDSA='" + khonhap + "' group by InventoryItemCode,InventoryItemName,InventoryCategoryName order by SUBSTRING(InventoryItemCode,8,2),InventoryItemCode");
            }
            else
                temp = gen.GetTable("thongkehanghoanhapxuatdieu '" + ngaychungtu + "','" + ngaycuoi + "','" + khonhap + "','" + khoxuat + "','xuat'," + tong + "");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (tong == "2")
                    dr[5] = temp.Rows[i][0];
                else
                    dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                dr[4] = temp.Rows[i][4];
                if (tsbt == "bkthbhtnvkd")
                    dr[6] = temp.Rows[i][5];
                dt.Rows.Add(dr);
            }

            Frm_nhapxuat rp = new Frm_nhapxuat();
            rp.getdata(dt);
            rp.getcongty("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            if (tsbt == "tsbtbkhhnd")
                rp.getrole("Vào " + tennhap.Trim() + " từ " + tenxuat.Trim());
            else if (tsbt == "bkthbhtnvkd")
                rp.getrole(khoxuat + " - " + tennhap);
            else
                rp.getrole("Từ " + tenxuat.Trim() + " đến " + tennhap.Trim());
            rp.getngay("Từ ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu)) + " đến " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaycuoi))); 
            rp.gettsbt(tsbt+tong);
            rp.Show();
        }

        public void loadchitietskt(string ngaychungtu, string tsbt, string kho,string tenkho,string account,string accountname)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("TK nợ", Type.GetType("System.String"));
            dt.Columns.Add("TK có", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền có", Type.GetType("System.Double"));
            if (tsbt == "tsbtthp")
                temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and StockID in (select StockID from MSC_UserJoinStock where UserID='" + kho + "') and Amount<>0  group by RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by RefDate,RefNo");
            else if (tsbt == "tsbtbkthcptn")
            {
                if (account == "")
                    temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b,Account c where (a.DebitAccount=c.AccountNumber) and a.AccountingObjectID=b.AccountingObjectID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and  (Occupation='" + account + "' or Occupation is NULL) and DetailByJob='True' and SUBSTRING(DebitAccount,1,1)<>'3' and SUBSTRING(AccountNumber,1,2)<>'51'  group by RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by RefDate,RefNo");
                else
                    temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b,Account c where (a.DebitAccount=c.AccountNumber) and a.AccountingObjectID=b.AccountingObjectID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and  Occupation='" + account + "' and DetailByJob='True' and SUBSTRING(DebitAccount,1,1)<>'3' and SUBSTRING(DebitAccount,1,2)<>'51'  group by RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by RefDate,RefNo");
            }
            else if (tsbt == "tsbtbkthtncp")
            {
                if (account == "")
                    temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,Occupation+' - '+JournalMemo as JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b,Account c, MSC_UserMN d where a.Occupation=d.MN and d.UserID='" + kho + "' and (a.DebitAccount=c.AccountNumber or a.CreditAccount=c.AccountNumber) and a.AccountingObjectID=b.AccountingObjectID and RefDate>='" + tenkho + "' and RefDate<='" + ngaychungtu + "' and (a.GroupCost='' or a.GroupCost is NULL) and DetailByJob='True' and SUBSTRING(DebitAccount,1,1)<>'3' and SUBSTRING(DebitAccount,1,2)<>'51'  group by RefNo,RefDate,AccountingObjectName,Occupation+' - '+JournalMemo,DebitAccount,CreditAccount) a order by RefDate,RefNo");
                else
                    temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,Occupation+' - '+JournalMemo as JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b,Account c, MSC_UserMN d where a.Occupation=d.MN and d.UserID='" + kho + "' and (a.DebitAccount=c.AccountNumber or a.CreditAccount=c.AccountNumber) and a.AccountingObjectID=b.AccountingObjectID and RefDate>='" + tenkho + "' and RefDate<='" + ngaychungtu + "' and a.GroupCost='" + account + "' and DetailByJob='True' and SUBSTRING(DebitAccount,1,1)<>'3' and SUBSTRING(DebitAccount,1,2)<>'51'  group by RefNo,RefDate,AccountingObjectName,Occupation+' - '+JournalMemo,DebitAccount,CreditAccount) a order by RefDate,RefNo");
            }
            else
            {
                string tinhchat = gen.GetString("select AccountCategoryKind from Account where AccountNumber='" + account + "'");
                if (tinhchat == "2" || account == "632" || account == "156")
                    temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from AccountSum a, AccountingObject b where a.UserID=b.AccountingObjectID and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and StockID='" + kho + "' and Amount<>0  group by RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, PostDate,111),RefNo");
                else
                    temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and StockID='" + kho + "' and Amount<>0  group by RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, RefDate,111),RefNo");
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                if (temp.Rows[i][4].ToString() == account)
                {
                    dr[5] = temp.Rows[i][5];
                    dr[6] = temp.Rows[i][6];
                }
                else if (temp.Rows[i][5].ToString() == account)
                {
                    dr[4] = temp.Rows[i][4];
                    dr[7] = temp.Rows[i][6];
                }
                else
                {
                    dr[4] = temp.Rows[i][4];
                    dr[5] = temp.Rows[i][5];
                    if (Double.Parse(temp.Rows[i][4].ToString().Substring(0, 1)) < 5)
                        dr[7] = temp.Rows[i][6];
                    else
                        dr[6] = temp.Rows[i][6];
                    tsbt = "tsbtthp";
                }

                dt.Rows.Add(dr);
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.gettenkho(tenkho);
            rp.gettungay(tenkho);
            rp.getdata(dt);
            rp.gettenkh(account+" - "+accountname);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadchitietsktth(string tungay, string denngay, string tsbt, string account, string accountname, string kho)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("TK nợ", Type.GetType("System.String"));
            dt.Columns.Add("TK có", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền có", Type.GetType("System.Double"));
            string tinhchat = gen.GetString("select AccountCategoryKind from Account where AccountNumber='" + account + "'");
            if (tsbt == "sktth")
            {
                if (kho == "")
                {
                    if (tinhchat == "2" || account == "632" || account == "156")
                        temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from AccountSum a, AccountingObject b where a.UserID=b.AccountingObjectID and Month(PostDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(PostDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Amount<>0  group by RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, PostDate,111),RefNo");
                    else
                        temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and Month(RefDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(RefDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Amount<>0  group by RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, RefDate,111),RefNo");
                }
                else
                {
                    if (tinhchat == "2" || account == "632" || account == "156")
                        temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from AccountSum a, AccountingObject b where a.UserID=b.AccountingObjectID and Month(PostDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(PostDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Amount<>0 and StockID='" + kho + "'  group by RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, PostDate,111),RefNo");
                    else
                        temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and Month(RefDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(RefDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Amount<>0 and StockID='" + kho + "'  group by RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, RefDate,111),RefNo");
                }
            }
            else
            {
                if (kho == "")
                {
                    if (tinhchat == "2" || account == "632" || account == "156")
                        temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from AccountSum a, AccountingObject b where a.UserID=b.AccountingObjectID and Month(PostDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(PostDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and (substring(DebitAccount,1," + account.Length + ")='" + account + "' or substring(CreditAccount,1," + account.Length + ")='" + account + "') and Amount<>0  group by RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, PostDate,111),RefNo");
                    else
                        temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and Month(RefDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(RefDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and (substring(DebitAccount,1," + account.Length + ")='" + account + "' or substring(CreditAccount,1," + account.Length + ")='" + account + "') and Amount<>0  group by RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, RefDate,111),RefNo");
                }
                else
                {
                    if (tinhchat == "2" || account == "632" || account == "156")
                        temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from AccountSum a, AccountingObject b where a.UserID=b.AccountingObjectID and Month(PostDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(PostDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and (substring(DebitAccount,1," + account.Length + ")='" + account + "' or substring(CreditAccount,1," + account.Length + ")='" + account + "') and Amount<>0 and StockID='" + kho + "'  group by RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, PostDate,111),RefNo");
                    else
                        temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and Month(RefDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(RefDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and (substring(DebitAccount,1," + account.Length + ")='" + account + "' or substring(CreditAccount,1," + account.Length + ")='" + account + "') and Amount<>0 and StockID='" + kho + "'  group by RefNo,RefDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, RefDate,111),RefNo");
                }
            }

            int dai = 0;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];

                if (tsbt == "sktthtomtat")
                {
                    dr[4] = temp.Rows[i][4];
                    dr[5] = temp.Rows[i][5];
                    
                    if (temp.Rows[i][4].ToString().Length < account.Length)
                        dai = temp.Rows[i][4].ToString().Length;    
                    else
                        dai = account.Length;

                    if (temp.Rows[i][4].ToString().Substring(0, dai) == account)
                            dr[6] = temp.Rows[i][6];                       
                    else
                            dr[7] = temp.Rows[i][6];
                }
                else
                {
                    if (temp.Rows[i][4].ToString() == account)
                    {
                        dr[5] = temp.Rows[i][5];
                        dr[6] = temp.Rows[i][6];
                    }
                    else
                    {
                        dr[4] = temp.Rows[i][4];
                        dr[7] = temp.Rows[i][6];
                    }
                }
                dt.Rows.Add(dr);
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkh(account + " - " + accountname);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.getkho(kho);
            rp.gettsbt(tsbt.Replace("tomtat","")+"chitiet");
            rp.Show();
        }

        public void loadchitietskttong(string ngaychungtu, string tsbt, string account, string accountname,string lkno,string lkco,string cuoino,string cuoico)
        {
            DataTable dt = new DataTable();
            DataTable dtsum = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("TK nợ", Type.GetType("System.String"));
            dt.Columns.Add("TK có", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền có", Type.GetType("System.Double"));

            //temp = gen.GetTable("select SUBSTRING (RefNo,4,12),PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,Amount from AccountSum a, AccountingObject b where a.UserID=b.AccountingObjectID and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Amount<>0 order by PostDate");
            temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from AccountSum a, AccountingObject b,Stock c where a.StockID=c.StockID and a.UserID=b.AccountingObjectID and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Amount<>0  group by RefNo,PostDate,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount) a order by PostDate,RefNo");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                if (temp.Rows[i][4].ToString() == account)
                {
                    dr[5] = temp.Rows[i][5];
                    dr[6] = temp.Rows[i][6];
                }
                else
                {
                    dr[4] = temp.Rows[i][4];
                    dr[7] = temp.Rows[i][6];
                }
                dt.Rows.Add(dr);
            }

            dtsum.Columns.Add("Nợ đầu", Type.GetType("System.Double"));
            dtsum.Columns.Add("Có đầu", Type.GetType("System.Double"));
            dtsum.Columns.Add("Lũy kế nợ", Type.GetType("System.Double"));
            dtsum.Columns.Add("Lũy kế có", Type.GetType("System.Double"));
            dtsum.Columns.Add("Nợ cuối", Type.GetType("System.Double"));
            dtsum.Columns.Add("Có cuối", Type.GetType("System.Double"));
            temp = gen.GetTable("select COALESCE(sum(DebitAmount),0),COALESCE(sum(CreditAmount),0) from AccountAccumulated where Month(PostDate)='" + DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString() + "' and AccountNumber='" + account + "' ");
            
                DataRow dr1 = dtsum.NewRow();
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (Double.Parse(temp.Rows[i][0].ToString()) != 0)
                        dr1[0] = temp.Rows[i][0].ToString();
                    if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                        dr1[1] = temp.Rows[i][1].ToString();
                }
                if (lkno != "")
                    dr1[2] = lkno;
                if (lkco != "")
                    dr1[3] = lkco;
                if (cuoino != "")
                    dr1[4] = cuoino;
                if (cuoico != "")
                    dr1[5] = cuoico;              
                dtsum.Rows.Add(dr1);
        
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getdatasum(dtsum);
            rp.gettenkh(account + " - " + accountname);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt+"tong");
            rp.Show();
        }

        public void bangkethutienmat(string tungay, string denngay, string kho,string tsbt)
        {
            DataTable dt = new DataTable();
            DataTable dtsum = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            temp = gen.GetTable("select * from (select b.AccountingObjectCode,b.AccountingObjectName,Sum(TotalAmount-TotalFreightAmount+TotalAmountOC) as Amount from INOutward a, AccountingObject b where a.StockID='" + kho + "' and a.AccountingObjectID=b.AccountingObjectID and RefDate >='" + tungay + "' and RefDate <='" + denngay + "' and RefType=1 group by b.AccountingObjectCode,b.AccountingObjectName) a order by AccountingObjectCode");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }

            Frm_nhapxuat rp = new Frm_nhapxuat();
            rp.getdata(dt);
            rp.getngay(tungay);
            rp.getrole(denngay);
            rp.getkho(kho);
            rp.gettsbt(tsbt);
            rp.Show();
           
        }
        
        public void bangkesanluongbanhang(string tungay, string denngay, string kho, string nhanvien)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Thép", Type.GetType("System.Double"));
            dt.Columns.Add("Xi măng", Type.GetType("System.Double"));
            dt.Columns.Add("Cát", Type.GetType("System.Double"));
            dt.Columns.Add("Đá", Type.GetType("System.Double"));
            dt.Columns.Add("Gạch", Type.GetType("System.Double"));
            temp = gen.GetTable("bangkesanluongbanhang '" + denngay + "','" + nhanvien + "','" + kho+ "','1'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i+1;
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
                dt.Rows.Add(dr);
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(denngay);
            rp.getkho(kho);
            rp.getuserid(nhanvien);
            rp.gettsbt("tsbtbangkesanluong");
            rp.Show();
        }

        public void bangkeluongsanluongbanhang(string tungay, string denngay, string kho, string nhanvien)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));            
            
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("HP", Type.GetType("System.Double"));
            dt.Columns.Add("VKS", Type.GetType("System.Double"));
            dt.Columns.Add("CN", Type.GetType("System.Double"));
            dt.Columns.Add("Tkhac", Type.GetType("System.Double"));
            dt.Columns.Add("NS", Type.GetType("System.Double"));
            dt.Columns.Add("Fico", Type.GetType("System.Double"));
            dt.Columns.Add("XMkhac", Type.GetType("System.Double"));
            dt.Columns.Add("Cát", Type.GetType("System.Double"));
            dt.Columns.Add("Đá", Type.GetType("System.Double"));
            dt.Columns.Add("Gạch", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Lãi", Type.GetType("System.Double"));
            dt.Columns.Add("Thu nhập", Type.GetType("System.Double"));
            dt.Columns.Add("VAS", Type.GetType("System.Double"));
            string thang = DateTime.Parse(denngay).Month.ToString();
            string nam = DateTime.Parse(denngay).Year.ToString();
            string thangtruoc = DateTime.Parse(denngay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(denngay).AddMonths(-1).Year.ToString();
            //gen.ExcuteNonquery("bangkesanluongbanhang '" + denngay + "','" + nhanvien + "','" + kho + "','2'");
            temp = gen.GetTable("bangkeluongvaphibanhang '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + denngay + "','" + nhanvien + "'");     
           

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                Double thanhtien = 0;
                Double lai = 0;
                DataRow dr = dt.NewRow();
                dr[0] = i + 1;
                dr[1] = temp.Rows[i][0];
                dr[2] = temp.Rows[i][1];
                dr[3] = temp.Rows[i][2];
                dr[4] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[5] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[6] = temp.Rows[i][5];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[7] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[8] = temp.Rows[i][7];
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[9] = temp.Rows[i][8];
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[10] = temp.Rows[i][9];
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[11] = temp.Rows[i][10];
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[12] = temp.Rows[i][11];
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[13] = temp.Rows[i][12];
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[14] = temp.Rows[i][13];
                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                {
                    dr[15] = temp.Rows[i][14];
                    thanhtien = Double.Parse(temp.Rows[i][14].ToString());
                }
                if (Double.Parse(temp.Rows[i][15].ToString()) < 0)
                {
                    dr[16] = 0 - Double.Parse(temp.Rows[i][15].ToString());
                    lai = 0 - Double.Parse(temp.Rows[i][15].ToString());                  
                }
                if (thanhtien - lai > 0)
                    dr[17] = thanhtien - lai;

                if (Double.Parse(temp.Rows[i][16].ToString()) != 0)
                    dr[18] = temp.Rows[i][16];

                dt.Rows.Add(dr);
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(denngay);
            rp.getkho(kho);
            rp.getuserid(nhanvien);
            rp.gettsbt("tsbtbangkeluongsanluong");
            rp.Show();
        }

        public void bangkelaihoadonquahan(string tungay, string denngay, string kho, string nhanvien)
        {

            if (DateTime.Parse(denngay) > DateTime.Parse("10/01/2019"))
            {
                XtraMessageBox.Show("Chức năng này chỉ có giá trị đến tháng 09 năm 2019.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SplashScreenManager.ShowForm(typeof(Frm_wait));

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("HP", Type.GetType("System.Double"));
            dt.Columns.Add("VKS", Type.GetType("System.Double"));
            dt.Columns.Add("CN", Type.GetType("System.Double"));
            dt.Columns.Add("Tkhac", Type.GetType("System.Double"));
            dt.Columns.Add("NS", Type.GetType("System.Double"));
            dt.Columns.Add("Fico", Type.GetType("System.Double"));
            dt.Columns.Add("XMkhac", Type.GetType("System.Double"));
            dt.Columns.Add("Cát", Type.GetType("System.Double"));
            dt.Columns.Add("Đá", Type.GetType("System.Double"));
            dt.Columns.Add("Gạch", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Lãi", Type.GetType("System.Double"));
            dt.Columns.Add("Thu nhập", Type.GetType("System.Double"));
            dt.Columns.Add("VAS", Type.GetType("System.Double"));
            string thang = DateTime.Parse(denngay).Month.ToString();
            string nam = DateTime.Parse(denngay).Year.ToString();
            string thangtruoc = DateTime.Parse(denngay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(denngay).AddMonths(-1).Year.ToString();
            //gen.ExcuteNonquery("bangkesanluongbanhang '" + denngay + "','" + nhanvien + "','" + kho + "','2'");
            temp = gen.GetTable("bangkeluongvaphibanhang '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + denngay + "','" + nhanvien + "'");


            for (int i = 0; i < temp.Rows.Count; i++)
            {
                Double thanhtien = 0;
                Double lai = 0;
                DataRow dr = dt.NewRow();
                dr[0] = i + 1;
                dr[1] = temp.Rows[i][0];
                dr[2] = temp.Rows[i][1];
                dr[3] = temp.Rows[i][2];
                dr[4] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[5] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[6] = temp.Rows[i][5];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[7] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[8] = temp.Rows[i][7];
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[9] = temp.Rows[i][8];
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[10] = temp.Rows[i][9];
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[11] = temp.Rows[i][10];
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[12] = temp.Rows[i][11];
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                    dr[13] = temp.Rows[i][12];
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[14] = temp.Rows[i][13];
                if (Double.Parse(temp.Rows[i][14].ToString()) != 0)
                {
                    dr[15] = temp.Rows[i][14];
                    thanhtien = Double.Parse(temp.Rows[i][14].ToString());
                }
                if (Double.Parse(temp.Rows[i][15].ToString()) < 0)
                {
                    dr[16] = 0 - Double.Parse(temp.Rows[i][15].ToString());
                    lai = 0 - Double.Parse(temp.Rows[i][15].ToString());
                }
                if (thanhtien - lai > 0)
                    dr[17] = thanhtien - lai;

                if (Double.Parse(temp.Rows[i][16].ToString()) != 0)
                    dr[18] = temp.Rows[i][16];

                dt.Rows.Add(dr);
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(denngay);
            rp.getkho(kho);
            rp.getuserid(nhanvien);
            rp.gettsbt("tsbtbangkeluongsanluong");
            rp.Show();
        }

        public void loadchitietsctong(string ngaychungtu, string tsbt, GridView viewsum )
        {
            string account, accountname,lkno, lkco, cuoino, cuoico;
            account = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Tài khoản").ToString();
            accountname = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Tên tài khoản").ToString();
            lkno = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Lũy kế nợ").ToString();
            lkco = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Lũy kế có").ToString();
            cuoino = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Nợ cuối kỳ").ToString();
            cuoico = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Có cuối kỳ").ToString();
           
            DataTable dt = new DataTable();
            DataTable dtsum = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("TK nợ", Type.GetType("System.String"));
            dt.Columns.Add("TK có", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền có", Type.GetType("System.Double"));

            temp = gen.GetTable("select * from (select AccountName,CreditAccount,sum(Amount) as Amount from AccountSum a, Account b where a.CreditAccount=b.AccountNumber and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and  DebitAccount='" + account + "' and Amount <> 0 group by CreditAccount,AccountName) a order by CreditAccount");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[2] = temp.Rows[i][1];
                dr[3] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }
            temp = gen.GetTable("select * from (select AccountName,DebitAccount,sum(Amount) as Amount from AccountSum a, Account b where a.DebitAccount=b.AccountNumber and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and  CreditAccount='" + account + "' and Amount <> 0 group by DebitAccount,AccountName) a order by DebitAccount");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[4] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }

            dtsum.Columns.Add("Nợ đầu", Type.GetType("System.Double"));
            dtsum.Columns.Add("Có đầu", Type.GetType("System.Double"));
            dtsum.Columns.Add("Lũy kế nợ", Type.GetType("System.Double"));
            dtsum.Columns.Add("Lũy kế có", Type.GetType("System.Double"));
            dtsum.Columns.Add("Nợ cuối", Type.GetType("System.Double"));
            dtsum.Columns.Add("Có cuối", Type.GetType("System.Double"));
            temp = gen.GetTable("select COALESCE(sum(DebitAmount),0),COALESCE(sum(CreditAmount),0) from AccountAccumulated where Month(PostDate)='" + DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString() + "' and AccountNumber='" + account + "' ");

            DataRow dr1 = dtsum.NewRow();
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (Double.Parse(temp.Rows[i][0].ToString()) != 0)
                    dr1[0] = temp.Rows[i][0].ToString();
                if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                    dr1[1] = temp.Rows[i][1].ToString();
            }
            if (lkno != "")
                dr1[2] = lkno;
            if (lkco != "")
                dr1[3] = lkco;
            if (cuoino != "")
                dr1[4] = cuoino;
            if (cuoico != "")
                dr1[5] = cuoico;
            dtsum.Rows.Add(dr1);

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getdatasum(dtsum);
            rp.gettenkh(account + " - " + accountname);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadchitietsctongth(string tungay, string denngay, string tsbt, string account, string accountname, string nodau, string codau, string lkno, string lkco, string cuoino, string cuoico)
        {
            DataTable dt = new DataTable();
            DataTable dtsum = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("TK nợ", Type.GetType("System.String"));
            dt.Columns.Add("TK có", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền có", Type.GetType("System.Double"));

            if (account == "156")
                temp = gen.GetTable("select * from (select AccountName,CreditAccount,sum(Amount) as Amount from AccountSum a, Account b where a.CreditAccount=b.AccountNumber and Month(PostDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(PostDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and  (DebitAccount='156' or DebitAccount='1561' or DebitAccount='1562')  and Amount <> 0 group by CreditAccount,AccountName) a order by CreditAccount");
            else
                temp = gen.GetTable("select * from (select AccountName,CreditAccount,sum(Amount) as Amount from AccountSum a, Account b where a.CreditAccount=b.AccountNumber and Month(PostDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(PostDate)<='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and  substring(DebitAccount,1," + account.Length + ")='" + account + "' and Amount <> 0 group by CreditAccount,AccountName) a order by CreditAccount");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[2] = temp.Rows[i][1];
                dr[3] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }
            if (account == "156")
                temp = gen.GetTable("select * from (select AccountName,DebitAccount,sum(Amount) as Amount from AccountSum a, Account b where a.DebitAccount=b.AccountNumber and Month(PostDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(PostDate) <='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and  (CreditAccount='156' or CreditAccount='1561' or CreditAccount='1562' ) and Amount <> 0 group by DebitAccount,AccountName) a order by DebitAccount");
            else
                temp = gen.GetTable("select * from (select AccountName,DebitAccount,sum(Amount) as Amount from AccountSum a, Account b where a.DebitAccount=b.AccountNumber and Month(PostDate)>='" + DateTime.Parse(tungay).Month.ToString() + "' and Month(PostDate) <='" + DateTime.Parse(denngay).Month.ToString() + "' and Year(PostDate)='" + DateTime.Parse(denngay).Year.ToString() + "' and  substring(CreditAccount,1," + account.Length + ")='" + account + "' and Amount <> 0 group by DebitAccount,AccountName) a order by DebitAccount");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[4] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }

            dtsum.Columns.Add("Nợ đầu", Type.GetType("System.Double"));
            dtsum.Columns.Add("Có đầu", Type.GetType("System.Double"));
            dtsum.Columns.Add("Lũy kế nợ", Type.GetType("System.Double"));
            dtsum.Columns.Add("Lũy kế có", Type.GetType("System.Double"));
            dtsum.Columns.Add("Nợ cuối", Type.GetType("System.Double"));
            dtsum.Columns.Add("Có cuối", Type.GetType("System.Double"));
            
            DataRow dr1 = dtsum.NewRow();
            if (nodau != "")
                dr1[0] = nodau;
            if (codau != "")
                dr1[1] = codau;
            if (lkno != "")
                dr1[2] = lkno;
            if (lkco != "")
                dr1[3] = lkco;
            if (cuoino != "")
                dr1[4] = cuoino;
            if (cuoico != "")
                dr1[5] = cuoico;
            dtsum.Rows.Add(dr1);

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getdatasum(dtsum);
            rp.gettenkh(account + " - " + accountname);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt.Replace("tomtat","")+"chitiet");
            rp.Show();
        }

        public void loaddate(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu, string account)
        {
            view.Columns.Clear();

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("1", Type.GetType("System.String"));
            dt.Columns.Add("2", Type.GetType("System.String"));
            dt.Columns.Add("3", Type.GetType("System.String"));
            dt.Columns.Add("4", Type.GetType("System.String"));
            dt.Columns.Add("5", Type.GetType("System.String"));
            dt.Columns.Add("6", Type.GetType("System.String"));
            dt.Columns.Add("7", Type.GetType("System.String"));

            temp = gen.GetTable("select DISTINCT(col1) from (select day(RefDate) as col1 from HACHTOAN where (DebitAccount='" + account + "' or CreditAccount='" + account + "') and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "') a order by col1");

            int j = 0;
            int i = 0;
            for(int dong=0;dong<5;dong++)
            {
                DataRow dr = dt.NewRow();
                for (int cot = 0; cot <= 6; cot++)
                {
                    j++;
                    try
                    {
                        if (j == int.Parse(temp.Rows[i][0].ToString()))
                        {
                            i++;
                            dr[cot] = j;
                        }
                    }
                    catch 
                    {
                        dr[cot] = "";
                    }
                }
                dt.Rows.Add(dr);
            }

            lvpq.DataSource = dt;
        }

        public void loaddate(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu)
        {
            view.Columns.Clear();

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("1", Type.GetType("System.String"));
            dt.Columns.Add("2", Type.GetType("System.String"));
            dt.Columns.Add("3", Type.GetType("System.String"));
            dt.Columns.Add("4", Type.GetType("System.String"));
            dt.Columns.Add("5", Type.GetType("System.String"));
            dt.Columns.Add("6", Type.GetType("System.String"));
            dt.Columns.Add("7", Type.GetType("System.String"));

            temp = gen.GetTable("select DISTINCT(col1) from (select day(RefDate) as col1 from HACHTOAN a, Account b where (a.DebitAccount=b.AccountNumber or a.CreditAccount=b.AccountNumber) and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "' and b.Exits='True' and b.AccountNumber<>'1111') a order by col1");

            int j = 0;
            int i = 0;
            for (int dong = 0; dong < 5; dong++)
            {
                DataRow dr = dt.NewRow();
                for (int cot = 0; cot <= 6; cot++)
                {
                    j++;
                    try
                    {
                        if (j == int.Parse(temp.Rows[i][0].ToString()))
                        {
                            i++;
                            dr[cot] = j;
                        }
                    }
                    catch
                    {
                        dr[cot] = "";
                    }
                }
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
        }

        public void loadton(DevExpress.XtraGrid.Views.Grid.GridView view, string account,string accountname, string tsbt,string ngay)
        {
            string thang = DateTime.Parse(ngay).Month.ToString();
            string nam = DateTime.Parse(ngay).Year.ToString();
            string thangtruoc = DateTime.Parse(ngay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngay).AddMonths(-1).Year.ToString();
            Double tondau = 0;
            Double toncuoi = 0;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            if (tsbt == "tsbtthtktqtong")
                dt.Columns.Add("Tên khách hàng", Type.GetType("System.DateTime"));
            else
                dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("TK nợ", Type.GetType("System.String"));
            dt.Columns.Add("TK có", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền có", Type.GetType("System.Double"));

            if(tsbt=="tsbtthtktqtong")
                temp = gen.GetTable(" select * from (select SUBSTRING (RefNo,4,12) as RefNo,RefDate,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN a where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') group by SUBSTRING (RefNo,4,12),RefDate,JournalMemo,DebitAccount,CreditAccount) a order by Convert(varchar, RefDate,111),SUBSTRING(RefNo,3,4),RefNo");
            else
                temp = gen.GetTable("select * from (select SUBSTRING (RefNo,4,12) as RefNo,AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,sum(Amount) as Amount,RefDate from HACHTOAN a, AccountingObject b where a.AccountingObjectIDMain=b.AccountingObjectID and day(RefDate)='" + DateTime.Parse(ngay).Day.ToString() + "' and Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "' and (DebitAccount='" + account + "' or CreditAccount='" + account + "') group by SUBSTRING (RefNo,4,12),AccountingObjectName,JournalMemo,DebitAccount,CreditAccount,RefDate) a order by Convert(varchar, RefDate,111),SUBSTRING (RefNo,3,4),RefNo");
            for (int i = 0; i < temp.Rows.Count; i++)
            {                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                if (temp.Rows[i][3].ToString() == account)
                {
                    dr[4] = temp.Rows[i][4];
                    dr[5] = temp.Rows[i][5];
                }
                else
                {
                    dr[3] = temp.Rows[i][3];
                    dr[6] = temp.Rows[i][5];
                }
                dt.Rows.Add(dr);
            }
            if (tsbt == "tsbtthtktqtong")
            {
                int dau = 2;
                int cuoi = 2;
                if (view.GetRowCellValue(view.FocusedRowHandle, "Nợ đầu kỳ").ToString() != "")
                {
                    tondau = Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Nợ đầu kỳ").ToString());
                    dau = 0;
                }
                else if (view.GetRowCellValue(view.FocusedRowHandle, "Có đầu kỳ").ToString() != "")
                {
                    tondau = Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Có đầu kỳ").ToString());
                    dau=1;
                }

                if (view.GetRowCellValue(view.FocusedRowHandle, "Nợ cuối kỳ").ToString() != "")
                {
                    toncuoi = Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Nợ cuối kỳ").ToString());
                    cuoi=0;
                }
                else if (view.GetRowCellValue(view.FocusedRowHandle, "Có cuối kỳ").ToString() != "")
                {
                    toncuoi = Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Có cuối kỳ").ToString());
                    cuoi=1;
                }
               
                string loai = gen.GetString("select AccountCategoryKind from Account where AccountNumber='"+account+"'");
               
                if (dau.ToString() != loai && dau!=2 )
                {
                    tondau = 0 - tondau;
                }
                if (cuoi.ToString() != loai && dau!=2)
                {
                    toncuoi = 0 - toncuoi;
                }
            }
            else
            {
                temp = gen.GetTable("tonghoptaikhoanquyton '" + ngay + "','" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + account + "'");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                        tondau = Double.Parse(temp.Rows[i][1].ToString());
                    if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                        toncuoi = Double.Parse(temp.Rows[i][2].ToString());
                }
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettungay(tondau.ToString());
            rp.getdenngay(toncuoi.ToString());
            rp.getaccount(account);
            rp.gettenkh(account + " - " + accountname);
            rp.getngaychungtu(ngay);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadtontheothang(DevExpress.XtraGrid.Views.Grid.GridView view, string account, string accountname, string tsbt, string ngay)
        {
            string thang = DateTime.Parse(ngay).Month.ToString();
            string nam = DateTime.Parse(ngay).Year.ToString();
            Double tondau = 0;
            try
            {
                tondau = Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Nợ đầu kỳ").ToString());
            }
            catch { }
            try
            {
                tondau = tondau - Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Có đầu kỳ").ToString());
            }
            catch { }
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tồn đầu", Type.GetType("System.Double"));
            dt.Columns.Add("Thu", Type.GetType("System.Double"));
            dt.Columns.Add("Chi", Type.GetType("System.Double"));
            dt.Columns.Add("Tồn cuối", Type.GetType("System.Double"));

            temp = gen.GetTable("tonghoptaikhoanquytheothang '" + account + "','" + thang + "','" + nam + "'");

            int ngaytt = int.Parse(DateTime.DaysInMonth(DateTime.Parse(ngay).Year, DateTime.Parse(ngay).Month).ToString());
            int i=0;
            int j = 1;
            while (j <= ngaytt)
            {
                if (j.ToString() != temp.Rows[i][0].ToString())
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DateTime.Parse(thang + "/" + j.ToString() + "/" + nam);
                    dr[1] = tondau;
                    dr[4] = tondau;
                    dt.Rows.Add(dr);
                    j++;
                }
                else
                {
                    DataRow dr1 = dt.NewRow();
                    dr1[0] = DateTime.Parse(thang + "/" + j.ToString() + "/" + nam);
                    if (tondau != 0)
                        dr1[1] = tondau;
                    if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                        dr1[2] = temp.Rows[i][1].ToString();
                    if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                        dr1[3] = temp.Rows[i][2].ToString();
                    tondau = tondau + Double.Parse(temp.Rows[i][1].ToString()) - Double.Parse(temp.Rows[i][2].ToString());
                    if (tondau != 0)
                        dr1[4] = tondau;
                    dt.Rows.Add(dr1);
                    if (i < temp.Rows.Count - 1)
                        i++;
                    j++;
                }
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getaccount(account);
            rp.gettenkh(account + " - " + accountname);
            rp.getngaychungtu(ngay);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbaocaothuchi(string ngaychungtu, string tsbt, string makho,string tenkho)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));         
            dt.Columns.Add("Khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("C5119", Type.GetType("System.String"));
            dt.Columns.Add("C131", Type.GetType("System.Double"));
            dt.Columns.Add("C1313", Type.GetType("System.Double"));
            dt.Columns.Add("C1319", Type.GetType("System.Double"));
            dt.Columns.Add("C336", Type.GetType("System.Double"));
            dt.Columns.Add("N331", Type.GetType("System.Double"));
            dt.Columns.Add("N3313", Type.GetType("System.Double"));
            dt.Columns.Add("N3319", Type.GetType("System.Double"));
            dt.Columns.Add("N336", Type.GetType("System.Double"));

            temp = gen.GetTable("thuchitienhangtheokho '"+thang+"','"+nam+"','"+makho+"'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = Double.Parse(temp.Rows[i][3].ToString());
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = Double.Parse(temp.Rows[i][4].ToString());
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = Double.Parse(temp.Rows[i][5].ToString());
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = Double.Parse(temp.Rows[i][6].ToString());
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = Double.Parse(temp.Rows[i][7].ToString());
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[8] = Double.Parse(temp.Rows[i][8].ToString());
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[9] = Double.Parse(temp.Rows[i][9].ToString());
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = Double.Parse(temp.Rows[i][10].ToString());
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[11] = Double.Parse(temp.Rows[i][11].ToString());
                dt.Rows.Add(dr);
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkh(tenkho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbaocaothuchingay(string ngaychungtu, string tsbt, string makho, string tenkho)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();

            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Phiếu", Type.GetType("System.Double"));
            dt.Columns.Add("Khách hàng", Type.GetType("System.Double"));
            dt.Columns.Add("C5119", Type.GetType("System.String"));
            dt.Columns.Add("C131", Type.GetType("System.Double"));
            dt.Columns.Add("C1313", Type.GetType("System.Double"));
            dt.Columns.Add("C1319", Type.GetType("System.Double"));
            dt.Columns.Add("C336", Type.GetType("System.Double"));
            dt.Columns.Add("N331", Type.GetType("System.Double"));
            dt.Columns.Add("N3313", Type.GetType("System.Double"));
            dt.Columns.Add("N3319", Type.GetType("System.Double"));
            dt.Columns.Add("N336", Type.GetType("System.Double"));

            temp = gen.GetTable("thuchitienhangtheongay '" + thang + "','" + nam + "','" + makho + "'");
            int i=0;
            for (int j = 1; j <= int.Parse(ngay) ; j++)
            {
                DataRow dr = dt.NewRow();
                if (i < temp.Rows.Count)
                {
                        if (j == int.Parse(temp.Rows[i][0].ToString()))
                        {
                            dr[0] = DateTime.Parse(thang + "/"+temp.Rows[i][0].ToString()+"/" + nam).ToString();
                            if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                                dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                            if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                                dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                            if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                                dr[3] = Double.Parse(temp.Rows[i][3].ToString());
                            if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                                dr[4] = Double.Parse(temp.Rows[i][4].ToString());
                            if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                                dr[5] = Double.Parse(temp.Rows[i][5].ToString());
                            if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                                dr[6] = Double.Parse(temp.Rows[i][6].ToString());
                            if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                                dr[7] = Double.Parse(temp.Rows[i][7].ToString());
                            if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                                dr[8] = Double.Parse(temp.Rows[i][8].ToString());
                            if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                                dr[9] = Double.Parse(temp.Rows[i][9].ToString());
                            if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                                dr[10] = Double.Parse(temp.Rows[i][10].ToString());
                            if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                                dr[11] = Double.Parse(temp.Rows[i][11].ToString());
                            i++;
                        }
                   else
                        dr[0] = DateTime.Parse(thang +"/" +j.ToString() +"/"+ nam).ToString();
                }
                else
                {
                    dr[0] = DateTime.Parse(thang + "/" + j.ToString() + "/" + nam).ToString();
                }
                dt.Rows.Add(dr);
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkh(tenkho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt+"tong");
            rp.Show();
        }


        public void loadchitietlaivay(string ngaychungtu, string tsbt, string makho, string tenkho)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            DataTable congtru = new DataTable();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();

            string ngaydauthang = DateTime.Parse(thang + "/1/" + nam).ToString();
            string ngaycuoithang = DateTime.Parse(thang + "/" + ngay + "/" + nam).AddDays(1).ToShortDateString();
            
            //Double ngaytruoc =Double.Parse(DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).AddMonths(-1).Year, DateTime.Parse(ngaychungtu).AddMonths(-1).Month).ToString());
            //string tungay = DateTime.Parse(thangtruoc + "/" + (Math.Round(ngaytruoc/2,0)+1).ToString() + "/" + namtruoc).ToString();
            //string denngay = DateTime.Parse(thang + "/" + (Math.Round(Double.Parse(ngay) / 2, 0)).ToString() + "/" + nam).ToString();
            //denngay = DateTime.Parse(DateTime.Parse(denngay).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();
          
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tiền vay", Type.GetType("System.Double"));
            dt.Columns.Add("Cộng hàng điều", Type.GetType("System.Double"));
            dt.Columns.Add("Trừ hàng điều", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền trả", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền lãi", Type.GetType("System.Double"));
            //congtru = gen.GetTable("bangketinhlaivay '" + makho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "','" + tungay + "','" + denngay + "'," + Math.Round((ngaytruoc-1) / 2, 0, MidpointRounding.AwayFromZero) + "");
            congtru = gen.GetTable("bangketinhlaivay '" + makho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "','" + ngaydauthang + "','" + ngaycuoithang + "',0");
            string loai = gen.GetString("select DefaultAccountNumber from Stock where StockID='" + makho + "'");

            if (loai.Substring(0, 1) == "2")
                temp = gen.GetTable("thuchitienhangtheongayloai '" + thang + "','" + nam + "','" + makho + "','"+loai.Substring(1,2)+"'");
            else if(loai.Substring(1, 2) == "10")
                temp = gen.GetTable("thuchitienhangtheongaycon '" + thang + "','" + nam + "','" + makho + "'");
            else
                temp = gen.GetTable("thuchitienhangtheongay '" + thang + "','" + nam + "','" + makho + "'");


            Double tondau = 0;
            try
            {
                tondau = Double.Parse(gen.GetString("select Beginning from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + makho + "'"));
            }
            catch { }
            Double laisuat = Double.Parse(gen.GetString("select Top 1 PercentMoney from PercentSyn where Postdate<='" + ngaychungtu + "' order by PostDate DESC"));
            Double lai, tonglai = 0;
            int i = 0,z = 0;
            for (int j = 1; j <= int.Parse(ngay); j++)
            {
                DataRow dr = dt.NewRow();
                if (i < temp.Rows.Count)
                {
                    if (j == int.Parse(temp.Rows[i][0].ToString()))
                    {
                        dr[0] = DateTime.Parse(thang + "/" + temp.Rows[i][0].ToString() + "/" + nam).ToString();
                        if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                        {
                            dr[1] = Double.Parse(temp.Rows[i][11].ToString());
                            tondau = tondau + Double.Parse(temp.Rows[i][11].ToString());
                        }
                        if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                        {
                            dr[4] = Double.Parse(temp.Rows[i][6].ToString());
                            tondau = tondau - Double.Parse(temp.Rows[i][6].ToString());
                        }
                        i++;
                    }
                    else
                        dr[0] = DateTime.Parse(thang + "/" + j.ToString() + "/" + nam).ToString();
                }
                else
                {
                    dr[0] = DateTime.Parse(thang + "/" + j.ToString() + "/" + nam).ToString();
                }

                if (z < congtru.Rows.Count)
                {
                    if (j == int.Parse(congtru.Rows[z][0].ToString()))
                    {
                        if (Double.Parse(congtru.Rows[z][1].ToString()) != 0)
                        {
                            dr[2] = Double.Parse(congtru.Rows[z][1].ToString());
                            tondau = tondau + Double.Parse(congtru.Rows[z][1].ToString());
                        }
                        if (Double.Parse(congtru.Rows[z][2].ToString()) != 0)
                        {
                            dr[3] = Double.Parse(congtru.Rows[z][2].ToString());
                            tondau = tondau - Double.Parse(congtru.Rows[z][2].ToString());
                        }
                        z++;
                    }
                }

                lai = Math.Round(tondau * laisuat / 36000,0);
                tonglai = lai + tonglai;
                dr[5] = tondau.ToString();
                dr[6] = lai.ToString();
                dt.Rows.Add(dr);
            }
            
                gen.ExcuteNonquery("update Syncost set Surplus='" + tondau + "', Interest='" + tonglai + "' where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + makho + "' ");
            
            try
            {
                string matam = gen.GetString("select a.StockCode from Stock a, Stock b where a.StockID='" + makho + "' and a.StockCode=b.StockCode and a.StockCode=SUBSTRING(b.DefaultAccountNumber,4,2)");
                gen.ExcuteNonquery("bangkechitietkinhdoanh '" + makho + "','" + thang + "','" + nam + "','" + ngaychungtu + "'");
            }
            catch {}
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkh(tenkho);
            rp.getkho(makho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }


        public void loadchitietlaivaytheonganh(string ngaychungtu, string tsbt, string makho, string tenkho)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
           

            SplashScreenManager.ShowForm(typeof(Frm_wait));
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tiền vay", Type.GetType("System.Double"));
            dt.Columns.Add("Cộng hàng điều", Type.GetType("System.Double"));
            dt.Columns.Add("Trừ hàng điều", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền trả", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền lãi", Type.GetType("System.Double"));


            temp = gen.GetTable("thuchitienhangtheongaytheonganh '" + thang + "','" + nam + "','" + makho + "'");
           

            Double tondau = 0;
            try
            {
                tondau = Double.Parse( gen.GetString("bangketinhlaivaytheonganh '" + makho + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "'"));
            }
            catch { }
            Double laisuat = Double.Parse(gen.GetString("select Top 1 PercentMoney from PercentSyn where Postdate<='" + ngaychungtu + "' order by PostDate DESC"));
            Double lai, tonglai = 0;
            int i = 0;
            for (int j = 1; j <= int.Parse(ngay); j++)
            {
                DataRow dr = dt.NewRow();
                if (i < temp.Rows.Count)
                {
                    if (j == int.Parse(temp.Rows[i][0].ToString()))
                    {
                        dr[0] = DateTime.Parse(thang + "/" + temp.Rows[i][0].ToString() + "/" + nam).ToString();
                        if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                        {
                            dr[1] = Double.Parse(temp.Rows[i][11].ToString());
                            tondau = tondau + Double.Parse(temp.Rows[i][11].ToString());
                        }
                        if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                        {
                            dr[4] = Double.Parse(temp.Rows[i][6].ToString());
                            tondau = tondau - Double.Parse(temp.Rows[i][6].ToString());
                        }
                        i++;
                    }
                    else
                        dr[0] = DateTime.Parse(thang + "/" + j.ToString() + "/" + nam).ToString();
                }
                else
                {
                    dr[0] = DateTime.Parse(thang + "/" + j.ToString() + "/" + nam).ToString();
                }

                lai = Math.Round(tondau * laisuat / 36000, 0);
                tonglai = lai + tonglai;
                dr[5] = tondau.ToString();
                dr[6] = lai.ToString();
                dt.Rows.Add(dr);
            }

            gen.ExcuteNonquery("update SyncostMN set Cuoiky='" + tondau + "',Lai='" + tonglai + "' where Month(Posteddate)='" + thang + "' and YEAR(Posteddate)='" + nam + "' and Manganh='" + makho + "' ");

            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkh(tenkho);
            rp.getkho(makho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadchitietkinhdoanh(string ngaychungtu, string tsbt, string makho)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            DataTable congtru = new DataTable();
            DataTable kho = new DataTable();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
            Double ngaytruoc = Double.Parse(DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).AddMonths(-1).Year, DateTime.Parse(ngaychungtu).AddMonths(-1).Month).ToString());
            string tungay = DateTime.Parse(thangtruoc + "/" + (Math.Round(ngaytruoc / 2, 0) + 1).ToString() + "/" + namtruoc).ToString();
            string denngay = DateTime.Parse(thang + "/" + (Math.Round(Double.Parse(ngay) / 2, 0)).ToString() + "/" + nam).ToString();
            denngay = DateTime.Parse(DateTime.Parse(denngay).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();
            SplashScreenManager.ShowForm(typeof(Frm_wait));

            string ngaydauthang = DateTime.Parse(thang + "/1/" + nam).ToString();
            string ngaycuoithang = DateTime.Parse(thang + "/" + ngay + "/" + nam).AddDays(1).ToShortDateString();


            kho = gen.GetTable("select distinct a.StockID,StockCode,StockName from Stock a where substring(DefaultAccountNumber,1,1)<>'0' and substring(DefaultAccountNumber,4,2)=(select StockCode from Stock where StockID='" + makho + "') order by StockCode");
            for (int k = 0; k < kho.Rows.Count; k++)
            {
                string mk = kho.Rows[k][0].ToString();

                //congtru = gen.GetTable("bangketinhlaivay '" + mk + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "','" + tungay + "','" + denngay + "'," + Math.Round((ngaytruoc - 1) / 2, 0, MidpointRounding.AwayFromZero) + "");

                congtru = gen.GetTable("bangketinhlaivay '" + makho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "','" + ngaydauthang + "','" + ngaycuoithang + "',0");
                
                string loai = gen.GetString("select DefaultAccountNumber from Stock where StockID='" + mk + "'");
                if (loai.Substring(0, 1) == "2")
                    temp = gen.GetTable("thuchitienhangtheongayloai '" + thang + "','" + nam + "','" + mk + "','" + loai.Substring(1, 2) + "'");
                else if (loai.Substring(1, 2) == "10")
                    temp = gen.GetTable("thuchitienhangtheongaycon '" + thang + "','" + nam + "','" + mk + "'");
                else
                    temp = gen.GetTable("thuchitienhangtheongay '" + thang + "','" + nam + "','" + mk + "'");

                //Double tondau = Double.Parse(gen.GetString("select Beginning from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + mk + "'"));
                Double tondau = 0;
                try
                {
                    tondau = Double.Parse(gen.GetString("select Beginning from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + mk + "'"));
                }
                catch { }
                
                Double laisuat = Double.Parse(gen.GetString("select Top 1 PercentMoney from PercentSyn where Postdate<='" + ngaychungtu + "' order by PostDate DESC"));
                Double lai, tonglai = 0;
                int i = 0, z = 0;
                for (int j = 1; j <= int.Parse(ngay); j++)
                {
                    if (i < temp.Rows.Count)
                    {
                        if (j == int.Parse(temp.Rows[i][0].ToString()))
                        {
                            if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                                tondau = tondau + Double.Parse(temp.Rows[i][11].ToString());
                            if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                                tondau = tondau - Double.Parse(temp.Rows[i][6].ToString());
                            i++;
                        }
                    }

                    if (z < congtru.Rows.Count)
                    {
                        if (j == int.Parse(congtru.Rows[z][0].ToString()))
                        {
                            if (Double.Parse(congtru.Rows[z][1].ToString()) != 0)
                                tondau = tondau + Double.Parse(congtru.Rows[z][1].ToString());
                            if (Double.Parse(congtru.Rows[z][2].ToString()) != 0)
                                tondau = tondau - Double.Parse(congtru.Rows[z][2].ToString());
                            z++;
                        }
                    }
                    lai = Math.Round(tondau * laisuat / 36000, 0);
                    tonglai = lai + tonglai;
                }
                gen.ExcuteNonquery("update Syncost set Surplus='" + tondau + "', Interest='" + tonglai + "' where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + mk + "' ");
            }

            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            dt.Columns.Add("Kỳ trước", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));

            if (tsbt == "tsbtctkqkd")
                temp = gen.GetTable("bangkechitietkinhdoanh '" + makho + "','" + thang + "','" + nam + "','" + ngaychungtu + "'");
            else if (tsbt == "tsbtctkqkdtt")
                temp = gen.GetTable("bangkechitietkinhdoanhthucte '" + makho + "','" + thang + "','" + nam + "','" + ngaychungtu + "'");

            for (int k = 0; k < temp.Rows.Count; k++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[k][1].ToString();
                if (Double.Parse(temp.Rows[k][2].ToString()) != 0)
                    dr[1] = temp.Rows[k][2].ToString();
                if (Double.Parse(temp.Rows[k][3].ToString()) != 0)
                    dr[2] = temp.Rows[k][3].ToString();
                dt.Rows.Add(dr);
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getkho(makho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }


        public void loadchitietkinhdoanhthucte(string ngaychungtu, string tsbt, string makho)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            DataTable congtru = new DataTable();
            DataTable kho = new DataTable();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
            Double ngaytruoc = Double.Parse(DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).AddMonths(-1).Year, DateTime.Parse(ngaychungtu).AddMonths(-1).Month).ToString());
            string tungay = DateTime.Parse(thangtruoc + "/" + (Math.Round(ngaytruoc / 2, 0) + 1).ToString() + "/" + namtruoc).ToString();
            string denngay = DateTime.Parse(thang + "/" + (Math.Round(Double.Parse(ngay) / 2, 0)).ToString() + "/" + nam).ToString();
            denngay = DateTime.Parse(DateTime.Parse(denngay).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();
            SplashScreenManager.ShowForm(typeof(Frm_wait));

            string ngaydauthang = DateTime.Parse(thang + "/1/" + nam).ToString();
            string ngaycuoithang = DateTime.Parse(thang + "/" + ngay + "/" + nam).AddDays(1).ToShortDateString();


            kho = gen.GetTable("select distinct a.StockID,StockCode,StockName from Stock a where substring(DefaultAccountNumber,1,1)<>'0' and substring(DefaultAccountNumber,4,2)=(select StockCode from Stock where StockID='" + makho + "') order by StockCode");
            for (int k = 0; k < kho.Rows.Count; k++)
            {
                string mk = kho.Rows[k][0].ToString();

                //congtru = gen.GetTable("bangketinhlaivay '" + mk + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "','" + tungay + "','" + denngay + "'," + Math.Round((ngaytruoc - 1) / 2, 0, MidpointRounding.AwayFromZero) + "");

                congtru = gen.GetTable("bangketinhlaivay '" + makho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "','" + ngaydauthang + "','" + ngaycuoithang + "',0");

                string loai = gen.GetString("select DefaultAccountNumber from Stock where StockID='" + mk + "'");
                if (loai.Substring(0, 1) == "2")
                    temp = gen.GetTable("thuchitienhangtheongayloai '" + thang + "','" + nam + "','" + mk + "','" + loai.Substring(1, 2) + "'");
                else if (loai.Substring(1, 2) == "10")
                    temp = gen.GetTable("thuchitienhangtheongaycon '" + thang + "','" + nam + "','" + mk + "'");
                else
                    temp = gen.GetTable("thuchitienhangtheongay '" + thang + "','" + nam + "','" + mk + "'");
                Double tondau = Double.Parse(gen.GetString("select Beginning from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + mk + "'"));
                Double laisuat = Double.Parse(gen.GetString("select Top 1 PercentMoney from PercentSyn where Postdate<='" + ngaychungtu + "' order by PostDate DESC"));
                Double lai, tonglai = 0;
                int i = 0, z = 0;
                for (int j = 1; j <= int.Parse(ngay); j++)
                {
                    if (i < temp.Rows.Count)
                    {
                        if (j == int.Parse(temp.Rows[i][0].ToString()))
                        {
                            if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                                tondau = tondau + Double.Parse(temp.Rows[i][11].ToString());
                            if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                                tondau = tondau - Double.Parse(temp.Rows[i][6].ToString());
                            i++;
                        }
                    }

                    if (z < congtru.Rows.Count)
                    {
                        if (j == int.Parse(congtru.Rows[z][0].ToString()))
                        {
                            if (Double.Parse(congtru.Rows[z][1].ToString()) != 0)
                                tondau = tondau + Double.Parse(congtru.Rows[z][1].ToString());
                            if (Double.Parse(congtru.Rows[z][2].ToString()) != 0)
                                tondau = tondau - Double.Parse(congtru.Rows[z][2].ToString());
                            z++;
                        }
                    }
                    lai = Math.Round(tondau * laisuat / 36000, 0);
                    tonglai = lai + tonglai;
                }
                gen.ExcuteNonquery("update Syncost set Surplus='" + tondau + "', Interest='" + tonglai + "' where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + mk + "' ");
            }

            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            dt.Columns.Add("Kỳ trước", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));

            temp = gen.GetTable("bangkechitietkinhdoanhthucte '" + makho + "','" + thang + "','" + nam + "','" + ngaychungtu + "'");
            for (int k = 0; k < temp.Rows.Count; k++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[k][1].ToString();
                if (Double.Parse(temp.Rows[k][2].ToString()) != 0)
                    dr[1] = temp.Rows[k][2].ToString();
                if (Double.Parse(temp.Rows[k][3].ToString()) != 0)
                    dr[2] = temp.Rows[k][3].ToString();
                dt.Rows.Add(dr);
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getkho(makho);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadketquakinhdoanhtonghop(string tudenngay, string ngaychungtu, string tsbt)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            DataTable congtru = new DataTable();
            DataTable kho = new DataTable();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
            Double ngaytruoc = Double.Parse(DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).AddMonths(-1).Year, DateTime.Parse(ngaychungtu).AddMonths(-1).Month).ToString());
            string tungay = DateTime.Parse(thangtruoc + "/" + (Math.Round(ngaytruoc / 2, 0) + 1).ToString() + "/" + namtruoc).ToString();
            string denngay = DateTime.Parse(thang + "/" + (Math.Round(Double.Parse(ngay) / 2, 0)).ToString() + "/" + nam).ToString();
            denngay = DateTime.Parse(DateTime.Parse(denngay).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            string ngaydauthang = DateTime.Parse(thang + "/1/" + nam).ToString();
            string ngaycuoithang = DateTime.Parse(thang + "/" + ngay + "/" + nam).AddDays(1).ToShortDateString();

            kho = gen.GetTable("select distinct a.StockID,StockCode,StockName from Stock a where substring(DefaultAccountNumber,1,1)<>'0' order by StockCode");
            for (int k = 0; k < kho.Rows.Count; k++)
            {
                string makho = kho.Rows[k][0].ToString();

                //congtru = gen.GetTable("bangketinhlaivay '" + makho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "','" + tungay + "','" + denngay + "'," + Math.Round((ngaytruoc - 1) / 2, 0, MidpointRounding.AwayFromZero) + "");

                congtru = gen.GetTable("bangketinhlaivay '" + makho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + ngaychungtu + "','" + ngaydauthang + "','" + ngaycuoithang + "',0");

                string loai = gen.GetString("select DefaultAccountNumber from Stock where StockID='" + makho + "'");
                if (loai.Substring(0, 1) == "2")
                    temp = gen.GetTable("thuchitienhangtheongayloai '" + thang + "','" + nam + "','" + makho + "','" + loai.Substring(1, 2) + "'");
                else if (loai.Substring(1, 2) == "10")
                    temp = gen.GetTable("thuchitienhangtheongaycon '" + thang + "','" + nam + "','" + makho + "'");
                else
                    temp = gen.GetTable("thuchitienhangtheongay '" + thang + "','" + nam + "','" + makho + "'");
                Double tondau = Double.Parse(gen.GetString("select Beginning from Syncost where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + makho + "'"));
                Double laisuat = Double.Parse(gen.GetString("select Top 1 PercentMoney from PercentSyn where Postdate<='" + ngaychungtu + "' order by PostDate DESC"));
                Double lai, tonglai = 0;
                int i = 0, z = 0;
                for (int j = 1; j <= int.Parse(ngay); j++)
                {
                    if (i < temp.Rows.Count)
                    {
                        if (j == int.Parse(temp.Rows[i][0].ToString()))
                        {
                            if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                                tondau = tondau + Double.Parse(temp.Rows[i][11].ToString());
                            if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                                tondau = tondau - Double.Parse(temp.Rows[i][6].ToString());
                            i++;
                        }
                    }        

                    if (z < congtru.Rows.Count)
                    {
                        if (j == int.Parse(congtru.Rows[z][0].ToString()))
                        {
                            if (Double.Parse(congtru.Rows[z][1].ToString()) != 0)
                                tondau = tondau + Double.Parse(congtru.Rows[z][1].ToString());
                            if (Double.Parse(congtru.Rows[z][2].ToString()) != 0)
                                tondau = tondau - Double.Parse(congtru.Rows[z][2].ToString());
                            z++;
                        }
                    }
                    lai = Math.Round(tondau * laisuat / 36000, 0);
                    tonglai = lai + tonglai;
                }
                gen.ExcuteNonquery("update Syncost set Surplus='" + tondau + "', Interest='" + tonglai + "' where Month(Postdate)='" + thang + "' and YEAR(Postdate)='" + nam + "' and StockID='" + makho + "' ");
            }
            
            kho = gen.GetTable("select distinct a.StockID,a.StockCode,StockName from Stock a, (select substring(DefaultAccountNumber,4,2) as StockCode from Stock) b where a.StockCode=b.StockCode order by a.StockCode DESC");
            for (int k = 0; k < kho.Rows.Count; k++)
            {
                string makho = kho.Rows[k][0].ToString();
                gen.GetTable("bangkechitietkinhdoanh '" + makho + "','" + thang + "','" + nam + "','" + ngaychungtu + "'");
            }
           
            dt = gen.GetTable("bangkeketquakinhdoanhtonghop '" + DateTime.Parse(tudenngay).Month + "','" + thang + "','" + nam + "',1");
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getngaychungtu(ngaychungtu);
            rp.gettungay(tudenngay);
            rp.getdata(dt);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbaocaotinhhinhmuaban(string tudenngay, string ngaychungtu, string tsbt)        
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            Frm_rpcongno rp = new Frm_rpcongno();
            DataTable dt = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            dt = gen.GetTable("baocaotinhhinhmuaban '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "',1");

            rp.getngaychungtu(ngaychungtu);
            rp.gettungay(tudenngay);
            rp.getdata(dt);
            rp.gettsbt(tsbt);
            rp.Show();
            SplashScreenManager.CloseForm();
        }
    }
}
