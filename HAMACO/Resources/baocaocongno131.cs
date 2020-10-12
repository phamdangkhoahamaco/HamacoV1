using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace HAMACO.Resources
{
    class baocaocongno131
    {
        gencon gen = new gencon();
        public void loadcn(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid,string ngaychungtu,string tsbt)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
            if (tsbt == "tsbtbccn131")
                    temp = gen.GetTable("baocaocongno131theodonvi '"+ngaychungtu+"','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131'");
            else if (tsbt == "tsbtbccn131tdv")
                temp = gen.GetTable("baocaocongno131theodonvichung '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131'");   
            else if (tsbt == "tsbtbccn131tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '"+ngaychungtu+"','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131'");
            else if (tsbt == "tsbtbccn331")
                temp = gen.GetTable("baocaocongno131theodonvi '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','331'");
            else if (tsbt == "tsbtbccn331tdv")
                temp = gen.GetTable("baocaocongno131theodonvichung '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','331'");
            else if (tsbt == "tsbtbccn331tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','331'");
            else if (tsbt == "tsbtbccn1313")
                temp = gen.GetTable("baocaocongno131theodonvi '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1313'");
            else if (tsbt == "tsbtbccn1313tdv")
                temp = gen.GetTable("baocaocongno131theodonvichung '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1313'");
            else if (tsbt == "tsbtbccn1313tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1313'");
            else if (tsbt == "tsbtbccn3313")
                temp = gen.GetTable("baocaocongno131theodonvi '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3313'");
            else if (tsbt == "tsbtbccn3313tdv")
                temp = gen.GetTable("baocaocongno131theodonvichung '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3313'");
            else if (tsbt == "tsbtbccn3313tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3313'");
            else if (tsbt == "tsbtbccn141")
                temp = gen.GetTable("baocaocongno141theodonvi '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','141'");
            else if (tsbt == "tsbtbccn141tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','141'");
            else if (tsbt == "tsbtbccn3388tdv")
                temp = gen.GetTable("baocaocongno131theodonvi '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3388'");
            else if (tsbt == "tsbtbccn1388")
                temp = gen.GetTable("baocaocongno131theodonvi '" + ngaychungtu + "','" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1388'");
            else if (tsbt == "tsbtbccn1388tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1388'");
            else if (tsbt == "tsbtbccn3388tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3388'");
            else if (tsbt == "tsbtbccn33881tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','33881'");
            else if (tsbt == "tsbtbccn33882tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','33882'");
            else if (tsbt == "tsbtbccn341118tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','341118'");
            else if (tsbt == "tsbtbccn341128tct")
                temp = gen.GetTable("baocaocongno131theodonvitoancongty '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','341128'");
            
            dt.Columns.Add("Mã", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));
           
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
            view.Columns["Nợ đầu kỳ"].Caption = "Nợ đầu kỳ";

            view.Columns["Nợ phát sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ phát sinh"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ phát sinh"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ phát sinh"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Nợ phát sinh"].Caption = "Phát sinh nợ";

            view.Columns["Nợ lũy kế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ lũy kế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ lũy kế"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ lũy kế"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Nợ lũy kế"].Caption = "Lũy kế nợ";

            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ cuối kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ cuối kỳ"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Nợ cuối kỳ"].Caption = "Nợ cuối kỳ";

            view.Columns["Có đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có đầu kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có đầu kỳ"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Có đầu kỳ"].Caption = "Có đầu kỳ";

            view.Columns["Có phát sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có phát sinh"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có phát sinh"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có phát sinh"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Có phát sinh"].Caption = "Phát sinh có";

            view.Columns["Có lũy kế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có lũy kế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có lũy kế"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có lũy kế"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Có lũy kế"].Caption = "Lũy kế có";

            view.Columns["Có cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có cuối kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có cuối kỳ"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Có cuối kỳ"].Caption = "Có cuối kỳ";

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns[0].Visible = false;
            view.Columns[2].Width = 200;
            view.FocusedRowHandle = 1;
            view.FocusedRowHandle = 0;
        }

        public void loadbccntheokho(string ngaychungtu, string tsbt, string donvi, GridView view)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Kho", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            DataTable temp = new DataTable();
            temp = gen.GetTable("select StockCode+' - '+StockName,AccountingObjectCode,AccountingObjectName,Case when (DebitAmount-CreditAmount)-(DebitArising-CreditArising)>0 then (DebitAmount-CreditAmount)-(DebitArising-CreditArising) else 0 end as sl,Case when (DebitAmount-CreditAmount)-(DebitArising-CreditArising)<0 then 0-((DebitAmount-CreditAmount)-(DebitArising-CreditArising)) else 0 end as slqd,DebitArising,CreditArising,DebitAccumulated,CreditAccumulated,DebitAmount,CreditAmount from AccountAccumulated a, Stock b, AccountingObject c where a.AccountingObjectID=c.AccountingObjectID and a.StockID=b.StockID and AccountNumber='131' and MONTH(PostDate)='" + thang + "' and YEAR(PostDate)='" + nam + "' order by StockCode,AccountingObjectCode");
            
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
                dt.Rows.Add(dr);
            }
            
            if (tsbt == "tsbtbccn131tct" || tsbt == "tsbtbccn331tct" || tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388" || tsbt == "tsbtbccn1388tct" || tsbt == "tsbtbccn3388tct" || tsbt == "tsbtbccn1313tct" || tsbt == "tsbtbccn3313tct")
            {
                donvi = gen.GetString("select Top 1 CompanyName from Center");
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt+"kho");
            rp.Show();
        }

        public void loadbccn(string ngaychungtu, string tsbt, string donvi,GridView view,string userid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Lãi quá hạn", Type.GetType("System.Double"));
            
            for (int i = 0; i < view.RowCount; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = view.GetRowCellValue(i, "Mã khách").ToString();
                dr[1] = view.GetRowCellValue(i, "Họ tên khách hàng").ToString();
                if (view.GetRowCellValue(i, "Nợ đầu kỳ").ToString()!="")
                    dr[2] = view.GetRowCellValue(i, "Nợ đầu kỳ").ToString();
                if (view.GetRowCellValue(i, "Có đầu kỳ").ToString()!="")
                    dr[3] = view.GetRowCellValue(i, "Có đầu kỳ").ToString();
                if (view.GetRowCellValue(i, "Nợ phát sinh").ToString()!="")
                    dr[4] = view.GetRowCellValue(i, "Nợ phát sinh").ToString();
                if (view.GetRowCellValue(i, "Có phát sinh").ToString()!="")
                    dr[5] = view.GetRowCellValue(i, "Có phát sinh").ToString();
                if (tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388")
                {
                    if (view.GetRowCellValue(i, "Lãi suất").ToString() != "")
                        dr[6] = view.GetRowCellValue(i, "Lãi suất").ToString();
                    if (view.GetRowCellValue(i, "Thuế TNCN").ToString() != "")
                        dr[7] = view.GetRowCellValue(i, "Thuế TNCN").ToString();
                }
                else
                {
                    if (view.GetRowCellValue(i, "Nợ lũy kế").ToString() != "")
                        dr[6] = view.GetRowCellValue(i, "Nợ lũy kế").ToString();
                    if (view.GetRowCellValue(i, "Có lũy kế").ToString() != "")
                        dr[7] = view.GetRowCellValue(i, "Có lũy kế").ToString();
                }
                if (view.GetRowCellValue(i, "Nợ cuối kỳ").ToString()!="")
                    dr[8] = view.GetRowCellValue(i, "Nợ cuối kỳ").ToString();
                if (view.GetRowCellValue(i, "Có cuối kỳ").ToString()!="")
                    dr[9] = view.GetRowCellValue(i, "Có cuối kỳ").ToString();
                dt.Rows.Add(dr);
            }
            if (tsbt == "tsbtbccn131" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn3313")
            {
                donvi = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + donvi + "'").ToUpper();
            }
            else if (tsbt == "tsbtbccn131tct" || tsbt == "tsbtbccn331tct" || tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388" || tsbt == "tsbtbccn1388tct" || tsbt == "tsbtbccn3388tct" || tsbt == "tsbtbccn1313tct" || tsbt == "tsbtbccn3313tct")
            {
                donvi = gen.GetString("select Top 1 CompanyName from Center");
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getuserid(userid);
            rp.gettenkho(donvi);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbccntomtat(string ngaychungtu, string tsbt, string donvi, GridView view)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.GetRowCellValue(i, "Nợ cuối kỳ").ToString() != "" || view.GetRowCellValue(i, "Có cuối kỳ").ToString() != "")
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = view.GetRowCellValue(i, "Mã khách").ToString();
                    dr[1] = view.GetRowCellValue(i, "Họ tên khách hàng").ToString();
                    if (view.GetRowCellValue(i, "Nợ đầu kỳ").ToString() != "")
                        dr[2] = view.GetRowCellValue(i, "Nợ đầu kỳ").ToString();
                    if (view.GetRowCellValue(i, "Có đầu kỳ").ToString() != "")
                        dr[3] = view.GetRowCellValue(i, "Có đầu kỳ").ToString();
                    if (view.GetRowCellValue(i, "Nợ phát sinh").ToString() != "")
                        dr[4] = view.GetRowCellValue(i, "Nợ phát sinh").ToString();
                    if (view.GetRowCellValue(i, "Có phát sinh").ToString() != "")
                        dr[5] = view.GetRowCellValue(i, "Có phát sinh").ToString();
                    if (tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388")
                    {
                        if (view.GetRowCellValue(i, "Lãi suất").ToString() != "")
                            dr[6] = view.GetRowCellValue(i, "Lãi suất").ToString();
                        if (view.GetRowCellValue(i, "Thuế TNCN").ToString() != "")
                            dr[7] = view.GetRowCellValue(i, "Thuế TNCN").ToString();
                    }
                    else
                    {
                        if (view.GetRowCellValue(i, "Nợ lũy kế").ToString() != "")
                            dr[6] = view.GetRowCellValue(i, "Nợ lũy kế").ToString();
                        if (view.GetRowCellValue(i, "Có lũy kế").ToString() != "")
                            dr[7] = view.GetRowCellValue(i, "Có lũy kế").ToString();
                    }
                    if (view.GetRowCellValue(i, "Nợ cuối kỳ").ToString() != "")
                        dr[8] = view.GetRowCellValue(i, "Nợ cuối kỳ").ToString();
                    if (view.GetRowCellValue(i, "Có cuối kỳ").ToString() != "")
                        dr[9] = view.GetRowCellValue(i, "Có cuối kỳ").ToString();
                    dt.Rows.Add(dr);
                }
            }
            if (tsbt == "tsbtbccn131" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn3313")
            {
                donvi = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + donvi + "'").ToUpper();
            }
            else if (tsbt == "tsbtbccn131tct" || tsbt == "tsbtbccn331tct" || tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388" || tsbt == "tsbtbccn3388tct" || tsbt == "tsbtbccn1388tct" || tsbt == "tsbtbccn1313tct" || tsbt == "tsbtbccn3313tct")
            {
                donvi = gen.GetString("select Top 1 CompanyName from Center");
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbccntt(string tungay, string denngay, string tsbt, string donvi)
        {
            
            DataTable dt = new DataTable();
            DataTable  temp=new DataTable();
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            if (tsbt == "bkcntt" || tsbt == "bkcnttct")
            {
                temp = gen.GetTable("baocaocongnothucte '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "'");
            }
            else if (tsbt == "bkcntttdv")
                temp = gen.GetTable("baocaocongnothuctetaidonvi '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "'");
           
            for (int i = 0; i < temp.Rows.Count; i++)
           {
               DataRow dr = dt.NewRow();
               dr[0] = temp.Rows[i][0].ToString();
               dr[1] = temp.Rows[i][1].ToString();
               if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
               {
                   if (Double.Parse(temp.Rows[i][2].ToString()) > 0)
                    dr[2] = temp.Rows[i][2].ToString();
                   if (Double.Parse(temp.Rows[i][2].ToString()) < 0)
                       dr[3] = 0 - Double.Parse(temp.Rows[i][2].ToString());
               }

               if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                   dr[4] = temp.Rows[i][3].ToString();
               if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                   dr[5] = temp.Rows[i][4].ToString();

               if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
               {
                   if (Double.Parse(temp.Rows[i][5].ToString()) > 0)
                       dr[6] = temp.Rows[i][5].ToString();
                   else if (Double.Parse(temp.Rows[i][5].ToString()) < 0)
                       dr[7] = 0 - Double.Parse(temp.Rows[i][5].ToString());
               }
               dt.Rows.Add(dr);
           }
           
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbkthpsv(string tungay, string denngay, string tsbt, string donvi)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));

            dt.Columns.Add("Xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Nhập", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ lại", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Trả nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền trả", Type.GetType("System.Double"));

            dt.Columns.Add("Nhập thế chân", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá nhập", Type.GetType("System.Double"));            
            dt.Columns.Add("Xuất thế chân", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Chênh lệch", Type.GetType("System.Double"));

            if (tsbt == "bkthpsv")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachphatsinhtong',''");
            else if (tsbt == "bkthpsvp")
            {
                string makhach = denngay;
                denngay = DateTime.Parse(tungay).AddDays(1).AddSeconds(-1).ToString();
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachphatsinhtongphieukho',''");
                tsbt = "bkthpsv";
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
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
                {
                    dr[11] = temp.Rows[i][11].ToString();
                    dr[12] = temp.Rows[i][13].ToString();
                }
                if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                {
                    dr[13] = temp.Rows[i][12].ToString();
                    dr[14] = temp.Rows[i][13].ToString();
                }
                if (Double.Parse(temp.Rows[i][15].ToString()) != 0)
                    dr[15] = temp.Rows[i][15].ToString();
                dt.Rows.Add(dr);
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbccntndn(string tungay, string denngay, string tsbt, string donvi)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            string account = tsbt.Replace("tndn", "").Replace("tdv", "").Replace("tct", "").Replace("bh", "").Replace("th","").Replace("tk","");
            if (tsbt == "131tndn" || tsbt == "131tndnbh" || tsbt == "331tndnbh" || tsbt == "331tndn" || tsbt == "1313tndn" || tsbt == "3313tndn" || tsbt == "1388tndn" || tsbt == "3388tndn")
                temp = gen.GetTable("baocaocongnotungaydenngay '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','" + account + "'");
            else if (tsbt == "131tndntdv" || tsbt == "331tndntdv" || tsbt == "1313tndntdv" || tsbt == "3313tndntdv")
                temp = gen.GetTable("baocaocongnotungaydenngaytheodonvi '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','" + account + "'");
            else if (tsbt == "131tndntct" || tsbt == "331tndntct" || tsbt == "1313tndntct" || tsbt == "3313tndntct" || tsbt == "141tndntct" || tsbt == "1388tndntct" || tsbt == "3388tndntct" || tsbt == "341118tndntct" || tsbt == "341128tndntct")
                temp = gen.GetTable("baocaocongnotungaydenngaytoancongty '" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','" + account + "'");
            else if (tsbt == "tsbtbccnvkh")
                temp = gen.GetTable("baocaocongnotongvotungaydenngaytheodonvi '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','131'");
            else if (tsbt == "tsbtbccnvkhth")
                temp = gen.GetTable("baocaocongnotongvotungaydenngaytheocongty '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','131'");
            else if (tsbt == "tsbtbccnvkhtk")
                temp = gen.GetTable("baocaocongnotongvotungaydenngaytheocongty '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','131kho'");
            else if (tsbt == "tsbtbccnvncc")
                temp = gen.GetTable("baocaocongnotongvotungaydenngaytheodonvi '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','331'");
            else if (tsbt == "tsbtbccnvnccth")
                temp = gen.GetTable("baocaocongnotongvotungaydenngaytheocongty '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','331'");
            else if (tsbt == "131tndntdvth")
                temp = gen.GetTable("baocaocongnotungaydenngaytonghop '" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','" + account + "','" + donvi + "'");
            else if (tsbt == "131tndntdvthtk")
                temp = gen.GetTable("baocaocongnotungaydenngaytonghoptk '" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','" + account + "','" + donvi + "'");

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
                dt.Rows.Add(dr);
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt);
            rp.Show();
        }


        public void loadbccnvotndn(string tungay, string denngay, string tsbt, string donvi, string makhach)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));

            dt.Columns.Add("Đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nhập", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền nhập", Type.GetType("System.Double"));

            dt.Columns.Add("Xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền xuất", Type.GetType("System.Double"));

            dt.Columns.Add("Cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Loại", Type.GetType("System.String"));
            if (tsbt == "tsbtbccnvkh")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheodonvi '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachchitiet',''");
            else if (tsbt == "tsbtbccnvkhth" || tsbt == "tsbtbccnvkhthbbxn")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachchitiet',''");
            else if (tsbt == "tsbtbccnvncc")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheodonvi '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','nhacungcapchitiet',''");
            else if (tsbt == "tsbtbccnvnccth")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','nhacungcapchitiet',''");
            else if (tsbt == "tsbtbccnvkhtk")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachchitietkho',''");
            
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
               
                if (tsbt == "tsbtbccnvkhthbbxn")
                {
                    dr[8] = i + 1;
                    if (Double.Parse(temp.Rows[i][0].ToString()) < 15)
                        dr[9] = temp.Rows[i][9].ToString();
                    else
                        dr[10] = temp.Rows[i][9].ToString();
                }
                else
                {
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                        dr[8] = temp.Rows[i][8].ToString();
                    if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                        dr[9] = temp.Rows[i][9].ToString();
                    if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                        dr[10] = temp.Rows[i][10].ToString();
                }
                dt.Rows.Add(dr);
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt+"chitietvo");
            rp.gettenkh(makhach);
            rp.Show();
        }

        public void loadbccnvotndnphatsinh(string tungay, string denngay, string tsbt, string donvi, string makhach)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nhập", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá nhập", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền nhập", Type.GetType("System.Double"));

            dt.Columns.Add("Xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền xuất", Type.GetType("System.Double"));

            if (tsbt == "tsbtbccnvkh")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheodonvi '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachchitietphatsinh',''");
            else if (tsbt == "tsbtbccnvkhth")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachchitietphatsinhtong',''");
            else if (tsbt == "tsbtbccnvkhtk")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachchitietphatsinhtongkho',''");
            else if (tsbt == "tsbtbccnvkhthphieu")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','khachchitietphatsinhtongphieu',''");
            else if (tsbt == "tsbtbccnvncc")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheodonvi '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','nhacungcapchitietphatsinh',''");
            else if (tsbt == "tsbtbccnvnccth")
                temp = gen.GetTable("baocaocongnovotungaydenngaytheocongty '" + donvi + "','" + makhach + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "','nhacungcapchitietphatsinh',''");
           
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
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
                
                dt.Rows.Add(dr);
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt + "chitietvophatsinh");
            rp.gettenkh(makhach);
            rp.Show();
        }

        public void loadbccntndnhmn(string ngaychungtu, string tsbt, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string userid)
        {
            view.Columns.Clear();
            view.ViewCaption = "   Công nợ quá hạn và hạn mức hợp đồng";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Hạn mức", Type.GetType("System.Double"));
            dt.Columns.Add("Tối đa", Type.GetType("System.Double"));            
            dt.Columns.Add("Nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Quá hạn", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 30 ngày", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 60 ngày", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 90 ngày", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 06 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Vượt hạn mức", Type.GetType("System.Double"));
            dt.Columns.Add("Hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Mã", Type.GetType("System.String"));

            //if (tsbt == "131tndntcthmn")
            temp = gen.GetTable("baocaocongnotungaydenngaytoancongtyhanmucno '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131','" + userid + "','1'");


            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                    dr[4] = temp.Rows[i][13].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[5] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[6] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[7] = temp.Rows[i][6].ToString();
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[8] = temp.Rows[i][7].ToString();
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    dr[9] = temp.Rows[i][8].ToString();
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[10] = temp.Rows[i][9].ToString();
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[11] = temp.Rows[i][10].ToString();
                dr[12] = temp.Rows[i][11].ToString();
                dr[13] = temp.Rows[i][12].ToString();
                dt.Rows.Add(dr);
            }            

                lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.OptionsView.ShowFooter = true;

            view.Columns["Mã"].Visible = false;
            view.Columns["Hợp đồng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hợp đồng"].Width = 100;

            view.Columns["Hạn mức"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tối đa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tối đa"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Quá hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quá hạn"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Trên 30 ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 30 ngày"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 60 ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 60 ngày"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 90 ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 90 ngày"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 06 tháng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 06 tháng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Vượt hạn mức"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Vượt hạn mức"].DisplayFormat.FormatString = "{0:n0}";


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Nợ";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Nợ"];

            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Quá hạn";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Quá hạn"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Trên 30 ngày";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Trên 30 ngày"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Trên 60 ngày";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Trên 60 ngày"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Trên 90 ngày";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Trên 90 ngày"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "Trên 06 tháng";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["Trên 06 tháng"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "Vượt hạn mức";
            item6.DisplayFormat = "{0:n0}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["Vượt hạn mức"];

            view.Columns["Nợ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Hạn mức"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Hạn mức"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tối đa"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tối đa"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 30 ngày"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 30 ngày"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 60 ngày"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 60 ngày"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 90 ngày"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 90 ngày"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 06 tháng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 06 tháng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Vượt hạn mức"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Vượt hạn mức"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Nợ"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            view.Columns["Nợ"].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            view.Columns["Quá hạn"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            view.Columns["Vượt hạn mức"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            view.Columns["Vượt hạn mức"].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);

            view.Columns["Họ tên khách hàng"].Width = 200;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void loadbccntndnhmnin(string tungay, string ngaychungtu, string tsbt, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Kho", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Quá hạn", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 30", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 60", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 90", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 06", Type.GetType("System.Double"));
            dt.Columns.Add("Vượt", Type.GetType("System.Double"));
            dt.Columns.Add("Hợp đồng", Type.GetType("System.String"));

            DialogResult dr1 = XtraMessageBox.Show("Nhấn 'Yes' để in bảng đầy đủ, 'No' để in bảng tóm tắt.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (dr1 == DialogResult.Yes)
            {
                for (int i = 0; i < view.RowCount - 1; i++)
                {
                    DataRow dr = dt.NewRow();
                    try
                    {
                        dr[0] = view.GetRowCellValue(i, "Mã kho").ToString();
                        dr[1] = view.GetRowCellValue(i, "Mã khách").ToString();
                        dr[2] = view.GetRowCellValue(i, "Họ tên khách hàng").ToString();
                        if (view.GetRowCellValue(i, "Hạn mức").ToString() != "")
                            dr[3] = view.GetRowCellValue(i, "Hạn mức").ToString();
                        if (view.GetRowCellValue(i, "Nợ").ToString() != "")
                            dr[4] = view.GetRowCellValue(i, "Nợ").ToString();
                        if (view.GetRowCellValue(i, "Quá hạn").ToString() != "")
                            dr[5] = view.GetRowCellValue(i, "Quá hạn").ToString();
                        if (view.GetRowCellValue(i, "Trên 30 ngày").ToString() != "")
                            dr[6] = view.GetRowCellValue(i, "Trên 30 ngày").ToString();
                        if (view.GetRowCellValue(i, "Trên 60 ngày").ToString() != "")
                            dr[7] = view.GetRowCellValue(i, "Trên 60 ngày").ToString();
                        if (view.GetRowCellValue(i, "Trên 90 ngày").ToString() != "")
                            dr[8] = view.GetRowCellValue(i, "Trên 90 ngày").ToString();
                        if (view.GetRowCellValue(i, "Trên 06 tháng").ToString() != "")
                            dr[9] = view.GetRowCellValue(i, "Trên 06 tháng").ToString();
                        if (view.GetRowCellValue(i, "Vượt hạn mức").ToString() != "")
                            dr[10] = view.GetRowCellValue(i, "Vượt hạn mức").ToString();
                        if (view.GetRowCellValue(i, "Hợp đồng").ToString() != "")
                            dr[11] = view.GetRowCellValue(i, "Hợp đồng").ToString();
                        dt.Rows.Add(dr);
                    }
                    catch { }
                }
            }
            else if (dr1 == DialogResult.No)
            {
                for (int i = 0; i < view.RowCount - 1; i++)
                {
                    DataRow dr = dt.NewRow();
                    try
                    {
                        if (Double.Parse(view.GetRowCellValue(i, "Nợ").ToString()) >= 40000000)
                        {
                            dr[0] = view.GetRowCellValue(i, "Mã kho").ToString();
                            dr[1] = view.GetRowCellValue(i, "Mã khách").ToString();
                            dr[2] = view.GetRowCellValue(i, "Họ tên khách hàng").ToString();
                            if (view.GetRowCellValue(i, "Hạn mức").ToString() != "")
                                dr[3] = view.GetRowCellValue(i, "Hạn mức").ToString();
                            if (view.GetRowCellValue(i, "Nợ").ToString() != "")
                                dr[4] = view.GetRowCellValue(i, "Nợ").ToString();
                            if (view.GetRowCellValue(i, "Quá hạn").ToString() != "")
                                dr[5] = view.GetRowCellValue(i, "Quá hạn").ToString();
                            if (view.GetRowCellValue(i, "Trên 30 ngày").ToString() != "")
                                dr[6] = view.GetRowCellValue(i, "Trên 30 ngày").ToString();
                            if (view.GetRowCellValue(i, "Trên 60 ngày").ToString() != "")
                                dr[7] = view.GetRowCellValue(i, "Trên 60 ngày").ToString();
                            if (view.GetRowCellValue(i, "Trên 90 ngày").ToString() != "")
                                dr[8] = view.GetRowCellValue(i, "Trên 90 ngày").ToString();
                            if (view.GetRowCellValue(i, "Trên 06 tháng").ToString() != "")
                                dr[9] = view.GetRowCellValue(i, "Trên 06 tháng").ToString();
                            if (view.GetRowCellValue(i, "Vượt hạn mức").ToString() != "")
                                dr[10] = view.GetRowCellValue(i, "Vượt hạn mức").ToString();
                            if (view.GetRowCellValue(i, "Hợp đồng").ToString() != "")
                                dr[11] = view.GetRowCellValue(i, "Hợp đồng").ToString();
                            dt.Rows.Add(dr);
                        }
                    }
                    catch { }
                }
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(tungay);
            rp.getdenngay(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbchitietcn(string ngaychungtu, string tsbt, string branchid, GridView view,string congty)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.String"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Lũy kế nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Lũy kế có", Type.GetType("System.Double"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));

            DataTable temp = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            string makhach = view.GetRowCellValue(view.FocusedRowHandle, "Mã").ToString();

            string no = null;
            string co = null;
            try
            {
                no = view.GetRowCellValue(view.FocusedRowHandle, "Nợ cuối kỳ").ToString();
                co = view.GetRowCellValue(view.FocusedRowHandle, "Có cuối kỳ").ToString();
            }
            catch { no = view.GetRowCellValue(view.FocusedRowHandle, "Nợ").ToString(); }
            string kho = "";
            
            if (tsbt == "tsbtbccn131")
            {
                temp = gen.GetTable("baocaocongnochitiet131 '" + branchid + "','" + thang + "','" + nam + "','"+thangtruoc+"','"+namtruoc+"','131','" + makhach + "'");
                string ma = gen.GetString("select StockCode from Stock where StockID='" + branchid + "'");
                branchid = gen.GetString("select StockName from Stock where StockID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 131 - " + ma + " - " + makhach;
                kho = "an";
            }
            else if (tsbt == "tsbtbccn131tdv")
            {
                temp = gen.GetTable("baocaocongnochitiet131chung '" + branchid + "','" + thang + "','" + nam + "','"+thangtruoc+"','"+namtruoc+"','131','" + makhach + "'");
                string ma = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
                branchid = gen.GetString("select BranchName from Branch where BranchID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 131 - " + ma + " - " + makhach;
                tsbt = "tsbtbccn131";
                kho = "hien";
            }
            else if (tsbt == "tsbtbccn131tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','"+thangtruoc+"','"+namtruoc+"','131','" + makhach + "'");      
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }
            else if (tsbt == "tsbtbccn331")
            {
                temp = gen.GetTable("baocaocongnochitiet131 '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','331','" + makhach + "'");
                string ma = gen.GetString("select StockCode from Stock where StockID='" + branchid + "'");
                branchid = gen.GetString("select StockName from Stock where StockID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 331 - " + ma + " - " + makhach;
                kho = "an";
            }
            else if (tsbt == "tsbtbccn331tdv")
            {
                temp = gen.GetTable("baocaocongnochitiet131chung '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','331','" + makhach + "'");
                string ma = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
                branchid = gen.GetString("select BranchName from Branch where BranchID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 331 - " + ma + " - " + makhach;
                tsbt = "tsbtbccn331";
                kho = "hien";
            }
            else if (tsbt == "tsbtbccn331tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','331','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn1313")
            {
                temp = gen.GetTable("baocaocongnochitiet131 '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1313','" + makhach + "'");
                string ma = gen.GetString("select StockCode from Stock where StockID='" + branchid + "'");
                branchid = gen.GetString("select StockName from Stock where StockID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 1313 - " + ma + " - " + makhach;
                kho = "an";
            }
            else if (tsbt == "tsbtbccn1313tdv")
            {
                temp = gen.GetTable("baocaocongnochitiet131chung '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1313','" + makhach + "'");
                string ma = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
                branchid = gen.GetString("select BranchName from Branch where BranchID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 1313 - " + ma + " - " + makhach;
                tsbt = "tsbtbccn1313";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn1313tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1313','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn3313")
            {
                temp = gen.GetTable("baocaocongnochitiet131 '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3313','" + makhach + "'");
                string ma = gen.GetString("select StockCode from Stock where StockID='" + branchid + "'");
                branchid = gen.GetString("select StockName from Stock where StockID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 3313 - " + ma + " - " + makhach;
                kho = "an";
            }

            else if (tsbt == "tsbtbccn3313tdv")
            {
                temp = gen.GetTable("baocaocongnochitiet131chung '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3313','" + makhach + "'");
                string ma = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
                branchid = gen.GetString("select BranchName from Branch where BranchID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 3313 - " + ma + " - " + makhach;
                tsbt = "tsbtbccn3313";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn3313tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3313','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn141")
            {
                temp = gen.GetTable("baocaocongnochitiet131chung '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','141','" + makhach + "'");
                string ma = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
                branchid = gen.GetString("select BranchName from Branch where BranchID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 141 - " + ma + " - " + makhach;
                kho = "an";
            }

            else if (tsbt == "tsbtbccn141tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','141','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "an";
            }

            else if (tsbt == "tsbtbccn3388tdv")
            {
                temp = gen.GetTable("baocaocongnochitiet131 '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3388','" + makhach + "'");
                string ma = gen.GetString("select StockCode from Stock where StockID='" + branchid + "'");
                branchid = gen.GetString("select StockName from Stock where StockID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 3388 - " + ma + " - " + makhach;
                kho = "an";
            }

            else if (tsbt == "tsbtbccn1388")
            {
                temp = gen.GetTable("baocaocongnochitiet131 '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1388','" + makhach + "'");
                string ma = gen.GetString("select StockCode from Stock where StockID='" + branchid + "'");
                branchid = gen.GetString("select StockName from Stock where StockID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = "Chi tiết TK: 1388 - " + ma + " - " + makhach;
                kho = "an";
            }

            else if (tsbt == "tsbtbccn1388tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','1388','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn3388tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3388','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn33881tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','33881','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }
            else if (tsbt == "tsbtbccn33882tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','33882','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn341118tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','341118','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }

            else if (tsbt == "tsbtbccn341128tct")
            {
                temp = gen.GetTable("baocaocongnochitiet131toancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','341128','" + makhach + "'");
                string ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
                branchid = makhach.ToUpper();
                makhach = "";
                kho = "hien";
            }
                Double luyke = 0;
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    try
                    {
                        if (temp.Rows[i][9].ToString() != temp.Rows[i - 1][9].ToString())
                        {
                            luyke = 0;
                        }
                    }
                    catch { }
                    dr[0] = temp.Rows[i][0].ToString();
                    if (temp.Rows[i][1].ToString()!="")
                        dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = temp.Rows[i][3].ToString();
                    dr[4] = temp.Rows[i][4].ToString();
                    if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    {
                        dr[5] = temp.Rows[i][5];
                        luyke = luyke + Double.Parse(temp.Rows[i][5].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    {
                        dr[6] = temp.Rows[i][6];
                        luyke = luyke - Double.Parse(temp.Rows[i][6].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    {
                        dr[7] = temp.Rows[i][7];
                        luyke = luyke + Double.Parse(temp.Rows[i][7].ToString());
                    }
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    {
                        dr[8] = temp.Rows[i][8];
                        luyke = luyke - Double.Parse(temp.Rows[i][8].ToString());
                    }
                    if (luyke > 0)
                        dr[9] = luyke;
                    else if (luyke < 0)
                        dr[10] = 0 - luyke;
                    dt.Rows.Add(dr);
                    try {
                        dr[11] = temp.Rows[i][9];
                        dr[12] = temp.Rows[i][9]+" - "+temp.Rows[i][10];
                    }
                    catch { }
                 }
           
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getluyke(congty);
            rp.getdata(dt);
            rp.gettenkho(branchid);
            rp.getngaychungtu(ngaychungtu);
            if (tsbt == "tsbtbccn131" || tsbt == "tsbtbccn131tct")
                tsbt = "tsbtchitietcongno131";
            else if (tsbt == "tsbtbccn331" || tsbt == "tsbtbccn331tct")
                tsbt = "tsbtchitietcongno331";
            else if (tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn1313tct")
                tsbt = "tsbtchitietcongno1313";
            else if (tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3313tct")
                tsbt = "tsbtchitietcongno3313";
            else if (tsbt == "tsbtbccn141" || tsbt == "tsbtbccn141tct")
                tsbt = "tsbtchitietcongno141";
            else if (tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn3388tct")
                tsbt = "tsbtchitietcongno3388";
            else if (tsbt == "tsbtbccn1388" || tsbt == "tsbtbccn1388tct")
                tsbt = "tsbtchitietcongno1388";
            else if (tsbt == "tsbtbccn341118tct")
                tsbt = "tsbtchitietcongno341118";
            else if (tsbt == "tsbtbccn341128tct")
                tsbt = "tsbtchitietcongno341128";
            else if (tsbt == "tsbtbccn33881tct")
                tsbt = "tsbtchitietcongno33881";
            else if (tsbt == "tsbtbccn33882tct")
                tsbt = "tsbtchitietcongno33882";
            rp.getkho(kho);
            rp.gettsbt(tsbt);
            rp.gettungay(no);
            rp.getdenngay(co);
            rp.gettenkh(makhach);
            rp.Show();
        }


        public void loadbchitietcntndn(string tungay, string denngay, string tsbt, string kho,string makhach,string no,string co)
        {
            DataTable dt = new DataTable();
            string ngay = String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay));
            string thangtruoc = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.String"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Lũy kế nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Lũy kế có", Type.GetType("System.Double"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            string taikhoan = tsbt.Replace("tndn", "").Replace("tdv","").Replace("tct","");
            DataTable temp = new DataTable();
            string an = "an";
            if (tsbt == "131tndn" || tsbt == "331tndn" || tsbt == "1313tndn" || tsbt == "3313tndn" || tsbt == "1388tndn" || tsbt == "3388tndn")
            {
                temp = gen.GetTable("baocaocongnochitiet131tndn '" + kho + "','" + tungay + "','" + denngay + "','" + ngay + "','" + thangtruoc + "','" + namtruoc + "','" + taikhoan + "','" + makhach + "'");
            }
            else if (tsbt == "131tndntdv" || tsbt == "331tndntdv" || tsbt == "1313tndntdv" || tsbt == "3313tndntdv")
            {
                temp = gen.GetTable("baocaocongnochitiet131tndntdv '" + kho + "','" + tungay + "','" + denngay + "','" + ngay + "','" + thangtruoc + "','" + namtruoc + "','" + taikhoan + "','" + makhach + "'");
                an = "hien";
            }
            else if (tsbt == "131tndntct" || tsbt == "331tndntct" || tsbt == "1313tndntct" || tsbt == "3313tndntct" || tsbt == "1388tndntct" || tsbt == "3388tndntct" || tsbt == "141tndntct" || tsbt == "341118tndntct" || tsbt == "341128tndntct")
            {
                temp = gen.GetTable("baocaocongnochitiet131tndntct '" + tungay + "','" + denngay + "','" + ngay + "','" + thangtruoc + "','" + namtruoc + "','" + taikhoan + "','" + makhach + "'");
                an = "hien";
            }

            Double luyke = 0;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                try
                {
                    if (temp.Rows[i][9].ToString() != temp.Rows[i - 1][9].ToString())
                    {
                        luyke = 0;
                    }
                }
                catch { }
                dr[0] = temp.Rows[i][0].ToString();
                if (temp.Rows[i][1].ToString() != "")
                    dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                {
                    dr[5] = temp.Rows[i][5];
                    luyke = luyke + Double.Parse(temp.Rows[i][5].ToString());
                }
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                {
                    dr[6] = temp.Rows[i][6];
                    luyke = luyke - Double.Parse(temp.Rows[i][6].ToString());
                }
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                {
                    dr[7] = temp.Rows[i][7];
                    luyke = luyke + Double.Parse(temp.Rows[i][7].ToString());
                }
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                {
                    dr[8] = temp.Rows[i][8];
                    luyke = luyke - Double.Parse(temp.Rows[i][8].ToString());
                }
                if (luyke > 0)
                    dr[9] = luyke;
                else if (luyke < 0)
                    dr[10] = 0 - luyke;
                dt.Rows.Add(dr);
                try
                {
                    dr[11] = temp.Rows[i][9];
                    dr[12] = temp.Rows[i][9] + " - " + temp.Rows[i][10];
                }
                catch { }
                try
                {
                    if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                        dr[13] = temp.Rows[i][11];
                    if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                        dr[14] = temp.Rows[i][12];
                }
                catch { }
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(co);
            rp.getluyke(no);
            rp.gettenkho(an);
            rp.getkho(kho);
            rp.gettsbt(tsbt+"chitiet");
            rp.gettungay(tungay);
            rp.getdenngay(denngay);
            rp.gettenkh(makhach);
            rp.Show();
        }

        public void loadbchitietcntndnbh(string tungay, string denngay, string tsbt, string kho, string makhach)
        {
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getkho(kho);
            rp.gettsbt(tsbt + "chitiet");
            rp.gettungay(tungay);
            rp.getdenngay(denngay);
            rp.gettenkh(makhach);
            rp.Show();
        }

        public void loadStock(string ngaychungtu, LookUpEdit ledv,string tsbt,string userid)
        {
            DataTable dt = new DataTable();
            DataTable da = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            string taikhoan="";
            if (tsbt == "tsbtbccn131" || tsbt == "tsbtbcptcn131")
                taikhoan = "131";
            else if (tsbt == "tsbtbccn331")
                taikhoan = "331";
            else if (tsbt == "tsbtbccn1313")
                taikhoan = "1313";
            else if (tsbt == "tsbtbccn3313")
                taikhoan = "3313";
            else if (tsbt == "tsbtbccn3388tdv")
                taikhoan = "3388";
            else if (tsbt == "tsbtbccn1388")
                taikhoan = "1388";
            else if (tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctkvlpgtndn")
            {
                if (DateTime.Parse(ngaychungtu) < DateTime.Parse("09/01/2017"))
                    taikhoan = "1563";
                else
                    taikhoan = "003";
            }
            dt.Columns.Add("Mã kho");
            dt.Columns.Add("Tên kho");
            da = gen.GetTable("baocaocongnolaykho '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + taikhoan + "','" + userid + "'");
            
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = da.Rows[i][0];
                dr[1] = da.Rows[i][1];
                dt.Rows.Add(dr);
            }
            ledv.Properties.DataSource = dt;
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.DisplayMember = "Mã kho";
        }




        public void loadBranch(string ngaychungtu, LookUpEdit ledv, string tsbt, string userid)
        {
            DataTable dt = new DataTable();
            DataTable da = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            string taikhoan = "";
            if (tsbt == "tsbtbccn131tdv" || tsbt == "tsbtbcptcn131tdv")
                taikhoan = "131";
            else if (tsbt == "tsbtbccn331tdv")
                taikhoan = "331";
            else if (tsbt == "tsbtbccn1313tdv")
                taikhoan = "1313";
            else if (tsbt == "tsbtbccn3313tdv")
                taikhoan = "1313";
            else if (tsbt == "tsbtbctkvlpgtttdv" || tsbt == "tsbtbctkvlpgtndntdv")
                taikhoan = "1563";
            dt.Columns.Add("Mã đơn vị");
            dt.Columns.Add("Tên đơn vị");
            da = gen.GetTable("baocaocongnolaydonvi '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + taikhoan + "','" + userid + "'");

            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = da.Rows[i][0];
                dr[1] = da.Rows[i][1];
                dt.Rows.Add(dr);
            }
            ledv.Properties.DataSource = dt;
            ledv.Properties.ValueMember = "Mã đơn vị";
            ledv.Properties.DisplayMember = "Mã đơn vị";
        }


       

        public void loadptcn(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid, string ngaychungtu, string tsbt, string userid)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
            if (tsbt == "tsbtbcptcn131")
            {
                temp = gen.GetTable("baocaocongno131theodonviphantichn '" + branchid + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131','"+ngaychungtu+"'");
            }
            else if (tsbt == "tsbtbcptcn131tdv")
            {
                DataTable da = gen.GetTable("select DISTINCT StockID from Stock a, Branch b where a.BranchID=b.BranchID and (b.Parent='"+branchid+"' or b.BranchID='"+branchid+"')");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    gen.GetTable("baocaocongno131theodonviphantichn '" + da.Rows[i][0] + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131','" + ngaychungtu + "'");
                }
                temp = gen.GetTable("baocaocongno131theodonvichinhphantichno '" + branchid + "','" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131'");
            }
            else
            {
                DataTable da = gen.GetTable("baocaocongnolaykho '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','" + 131 + "','" + userid + "'");

                for (int i = 0; i < da.Rows.Count; i++)
                {
                    gen.GetTable("baocaocongno131theodonviphantichn '" +  da.Rows[i][2] + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131','" + ngaychungtu + "'");
                }
                temp = gen.GetTable("baocaocongno131toancongtyphantichno '"+ngaychungtu+"','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131'");
            }
            dt.Columns.Add("Mã", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Tổng số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền quá hạn", Type.GetType("System.Double"));

            dt.Columns.Add("Dưới 1 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 1 tháng", Type.GetType("System.Double"));

            dt.Columns.Add("Trên 2 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 3 tháng", Type.GetType("System.Double"));

            dt.Columns.Add("Trên 6 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 1 năm", Type.GetType("System.Double"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                if(Double.Parse(temp.Rows[i][3].ToString())!=0)
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
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns["Tổng số tiền nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng số tiền nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng số tiền nợ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng số tiền nợ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số tiền quá hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền quá hạn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền quá hạn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền quá hạn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Dưới 1 tháng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Dưới 1 tháng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Dưới 1 tháng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Dưới 1 tháng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 1 tháng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 1 tháng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 1 tháng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 1 tháng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 2 tháng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 2 tháng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 2 tháng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 2 tháng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 3 tháng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 3 tháng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 3 tháng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 3 tháng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 6 tháng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 6 tháng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 6 tháng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 6 tháng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 1 năm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 1 năm"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 1 năm"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 1 năm"].SummaryItem.DisplayFormat = "{0:n0}";
            

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns[0].Visible = false;
            view.Columns[2].Width = 200;
            view.FocusedRowHandle = 1;
            view.FocusedRowHandle = 0;
        }

        public void loadbcptcn(string ngaychungtu, string tsbt, string donvi, GridView view)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Tổng số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền quá hạn", Type.GetType("System.Double"));

            dt.Columns.Add("Dưới 1 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 1 tháng", Type.GetType("System.Double"));

            dt.Columns.Add("Trên 2 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 3 tháng", Type.GetType("System.Double"));

            dt.Columns.Add("Trên 6 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 1 năm", Type.GetType("System.Double"));            

            for (int i = 0; i < view.RowCount; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = view.GetRowCellValue(i, "Mã khách").ToString();
                dr[1] = view.GetRowCellValue(i, "Họ tên khách hàng").ToString();
                if (view.GetRowCellValue(i, "Tổng số tiền nợ").ToString() != "")
                    dr[2] = view.GetRowCellValue(i, "Tổng số tiền nợ").ToString();
                if (view.GetRowCellValue(i, "Số tiền quá hạn").ToString() != "")
                    dr[3] = view.GetRowCellValue(i, "Số tiền quá hạn").ToString();
                if (view.GetRowCellValue(i, "Dưới 1 tháng").ToString() != "")
                    dr[4] = view.GetRowCellValue(i, "Dưới 1 tháng").ToString();
                if (view.GetRowCellValue(i, "Trên 1 tháng").ToString() != "")
                    dr[5] = view.GetRowCellValue(i, "Trên 1 tháng").ToString();
                if (view.GetRowCellValue(i, "Trên 2 tháng").ToString() != "")
                    dr[6] = view.GetRowCellValue(i, "Trên 2 tháng").ToString();
                if (view.GetRowCellValue(i, "Trên 3 tháng").ToString() != "")
                    dr[7] = view.GetRowCellValue(i, "Trên 3 tháng").ToString();
                if (view.GetRowCellValue(i, "Trên 6 tháng").ToString() != "")
                    dr[8] = view.GetRowCellValue(i, "Trên 6 tháng").ToString();
                if (view.GetRowCellValue(i, "Trên 1 năm").ToString() != "")
                    dr[9] = view.GetRowCellValue(i, "Trên 1 năm").ToString();
                dt.Rows.Add(dr);
            }
            if (tsbt == "tsbtbcptcn131")
            {
                donvi = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + donvi + "'").ToUpper() ;
            }
            else if (tsbt == "tsbtbcptcn131tdv")
            {
                donvi = gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + donvi + "'").ToUpper();
            }
            else if (tsbt == "tsbtbcptcn131tct")
            {
                donvi = "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG";
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadbcptcnkho(string ngaychungtu, string tsbt)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
            dt.Columns.Add("Mã", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Tổng số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền quá hạn", Type.GetType("System.Double"));

            dt.Columns.Add("Dưới 1 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 1 tháng", Type.GetType("System.Double"));

            dt.Columns.Add("Trên 2 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 3 tháng", Type.GetType("System.Double"));

            dt.Columns.Add("Trên 6 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 1 năm", Type.GetType("System.Double"));

            dt.Columns.Add("Kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));

            temp = gen.GetTable("baocaocongno131toancongtyphantichnotheokho '" + ngaychungtu + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131'");

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
                dr[11] = temp.Rows[i][11].ToString();
                dr[12] = temp.Rows[i][12].ToString();
                dt.Rows.Add(dr);
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt+"kho");
            rp.Show();
        }

        public void loadbchitietptcn(string ngaychungtu, string tsbt, string branchid, GridView view)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Ngày nợ", Type.GetType("System.DateTime"));

            dt.Columns.Add("Phiếu trả", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền trả", Type.GetType("System.Double"));

            dt.Columns.Add("Ngày trả", Type.GetType("System.DateTime"));

            dt.Columns.Add("Số dư nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số quá hạn", Type.GetType("System.Double"));
            dt.Columns.Add("Số ngày", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn vị", Type.GetType("System.String"));


            DataTable temp = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string makhach = view.GetRowCellValue(view.FocusedRowHandle, "Mã").ToString();
            string luyke = view.GetRowCellValue(view.FocusedRowHandle, "Tổng số tiền nợ").ToString();


            if (tsbt == "tsbtbcptcn131")
            {
                temp = gen.GetTable("select Substring(SaleCode,7,15),Invoice,ExDate,SaleMoney,SaleDate,Substring(PayCode,7,15),PayMoney,PayDate,ExitsMoney,NoID,DateEx from OpenExDate WHERE Month(PostedDate)='" + thang + "' and  Year(PostedDate)='" + nam + "' and AccountingObjectID='" + makhach + "' and BranchID='" + branchid + "' order by DATEADD(day,ExDate,SaleDate) ASC");
                tsbt = "tsbtchitietphantichcongno";
            }
            else if (tsbt == "tsbtbcptcn131tdv")
            {
                temp = gen.GetTable("select Substring(SaleCode,7,15),Invoice,ExDate,SaleMoney,SaleDate,Substring(PayCode,7,15),PayMoney,PayDate,ExitsMoney,NoID,DateEx,StockCode,StockName from OpenExDate  a, Stock b WHERE a.BranchID=b.StockID and Month(PostedDate)='" + thang + "' and  Year(PostedDate)='" + nam + "' and AccountingObjectID='" + makhach + "' and a.BranchID in (select DISTINCT StockID  from Stock a, Branch b where a.BranchID=b.BranchID and (b.Parent='"+branchid+"' or b.BranchID='"+branchid+"'))");
            }
            else if (tsbt == "tsbtbcptcn131tct")
            {
                temp = gen.GetTable("select Substring(SaleCode,7,15),Invoice,ExDate,SaleMoney,SaleDate,Substring(PayCode,7,15),PayMoney,PayDate,ExitsMoney,NoID,DateEx,StockCode,StockName from OpenExDate a, Stock b WHERE a.BranchID=b.StockID and Month(PostedDate)='" + thang + "' and  Year(PostedDate)='" + nam + "' and AccountingObjectID='" + makhach + "'");
                tsbt = "tsbtchitietphantichcongnotct";
            }
             
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                
                DataRow dr = dt.NewRow();
                if (temp.Rows[i][9].ToString() == "2")
                {
                    dr[5] = temp.Rows[i][0].ToString();
                    dr[6] = temp.Rows[i][3].ToString();
                    dr[7] = temp.Rows[i][4].ToString();
                }
                else 
                {
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[3] = temp.Rows[i][3].ToString();
                    if (temp.Rows[i][4].ToString() != "")
                    dr[4] = temp.Rows[i][4].ToString();
                    if(temp.Rows[i][1].ToString()!="")
                        dr[1] = temp.Rows[i][1].ToString();
                    if (temp.Rows[i][2].ToString() != "")
                        dr[2] = temp.Rows[i][2].ToString();
                    if (temp.Rows[i][5].ToString() != "")
                        dr[5] = temp.Rows[i][5].ToString();
                    if (temp.Rows[i][6].ToString() != "")
                        dr[6] = temp.Rows[i][6].ToString();
                    if (temp.Rows[i][7].ToString() != "")
                        dr[7] = temp.Rows[i][7].ToString();
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                        dr[8] = temp.Rows[i][8].ToString();
                    if (temp.Rows[i][10].ToString() != "")
                    {
                        if (Double.Parse(temp.Rows[i][10].ToString()) > 0)
                        {
                            dr[9] = temp.Rows[i][8].ToString();
                            dr[10] = temp.Rows[i][10].ToString();
                        }
                    }
                }
                if (tsbt == "tsbtchitietphantichcongnotct" || tsbt == "tsbtbcptcn131tdv")
                {
                    dr[11] = temp.Rows[i][11].ToString() + " - " + temp.Rows[i][12].ToString();
                }
                dt.Rows.Add(dr);
            }

            string ma;
            if (tsbt == "tsbtchitietphantichcongno")
            {
                ma = gen.GetString("select StockCode from Stock where StockID='" + branchid + "'");
                branchid = gen.GetString("select StockName from Stock where StockID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
            }
            else if (tsbt == "tsbtbcptcn131tdv")
            {
                ma = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
                branchid = gen.GetString("select BranchName from Branch where BranchID='" + branchid + "'");
                branchid = (ma + " - " + branchid).ToUpper();
                tsbt = "tsbtchitietphantichcongnotct";
            }
            else
            {
                branchid = "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG";
            }

            ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
            makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
            makhach = "Chi tiết phân tích công nợ - " + ma + " - " + makhach;

            Frm_rpcongno rp = new Frm_rpcongno();
            if(luyke!="")
                rp.getluyke(luyke);
            rp.getdata(dt);
            rp.gettenkho(branchid);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.gettenkh(makhach);
            rp.Show();
        }





        public void loadcn31188(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string branchid, string ngaychungtu, string tsbt)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
            if (tsbt == "tsbtbccn31188")
            {
                if (ngay == DateTime.Parse(ngaychungtu).Day.ToString())
                    temp = gen.GetTable("baocaocongno31188theodonvitinhlai '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','31188','" + tungaydau + "','" + ngaychungtu + "',1");
                else
                    temp = gen.GetTable("baocaocongno31188theodonvitinhlai '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','31188','" + tungaydau + "','" + ngaychungtu + "',0");
            }
            else if (tsbt == "tsbtbccn3388")
            {
                if (ngay == DateTime.Parse(ngaychungtu).Day.ToString())
                    temp = gen.GetTable("baocaocongno31188theodonvitinhlai '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3388','" + tungaydau + "','" + ngaychungtu + "',1");
                else
                    temp = gen.GetTable("baocaocongno31188theodonvitinhlai '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','3388','" + tungaydau + "','" + ngaychungtu + "',0");
            }
           
            dt.Columns.Add("Mã", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Lãi suất", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế TNCN", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Chọn", Type.GetType("System.Boolean"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                Double no = 0;
                Double co = 0;
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                if (temp.Rows[i][3].ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    {
                        dr[3] = temp.Rows[i][3].ToString();
                        no = no + Double.Parse(temp.Rows[i][3].ToString());
                    }
                }
                if (temp.Rows[i][4].ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    {
                        dr[4] = temp.Rows[i][4].ToString();
                        co = co + Double.Parse(temp.Rows[i][4].ToString());
                    }
                }
                if (temp.Rows[i][5].ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    {
                        dr[5] = temp.Rows[i][5].ToString();
                        no = no + Double.Parse(temp.Rows[i][5].ToString());
                    }
                }
                if (temp.Rows[i][6].ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    {
                        dr[6] = temp.Rows[i][6].ToString();
                        co = co + Double.Parse(temp.Rows[i][6].ToString());
                    }
                }
                if (temp.Rows[i][7].ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    {
                        dr[7] = temp.Rows[i][7].ToString();
                        co = co + Double.Parse(temp.Rows[i][7].ToString());
                    }
                }
                if (temp.Rows[i][8].ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                    {
                        dr[8] = temp.Rows[i][8].ToString();
                        no = no + Double.Parse(temp.Rows[i][8].ToString());
                    }
                }

                if (no - co > 0)
                    dr[9] = (no - co).ToString();
                else if (co - no > 0)
                    dr[10] = (co - no).ToString();

                if (temp.Rows[i][9].ToString() == "")
                    dr[11] = "False";
                else
                    dr[11] = "True";
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
            view.Columns["Nợ đầu kỳ"].Caption = "Nợ đầu kỳ";

            view.Columns["Nợ phát sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ phát sinh"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ phát sinh"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ phát sinh"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Nợ phát sinh"].Caption = "Phát sinh nợ";

            view.Columns["Lãi suất"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lãi suất"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lãi suất"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lãi suất"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Lãi suất"].Caption = "Lãi suất";

            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ cuối kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ cuối kỳ"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Nợ cuối kỳ"].Caption = "Nợ cuối kỳ";

            view.Columns["Có đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có đầu kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có đầu kỳ"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Có đầu kỳ"].Caption = "Có đầu kỳ";

            view.Columns["Có phát sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có phát sinh"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có phát sinh"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có phát sinh"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Có phát sinh"].Caption = "Phát sinh có";

            view.Columns["Thuế TNCN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thuế TNCN"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thuế TNCN"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thuế TNCN"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Thuế TNCN"].Caption = "Thuế TNCN";

            view.Columns["Có cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có cuối kỳ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Có cuối kỳ"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Có cuối kỳ"].Caption = "Có cuối kỳ";

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns[0].Visible = false;
            view.Columns[2].Width = 200;
            view.FocusedRowHandle = 1;
            view.FocusedRowHandle = 0;
        }



        public void loadbchitietlai(string ngaychungtu, string tsbt, string branchid, GridView view)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Từ ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Đến ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Số ngày", Type.GetType("System.Double"));

            dt.Columns.Add("Gửi vào", Type.GetType("System.Double"));
            dt.Columns.Add("Rút ra", Type.GetType("System.Double"));

            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));

            dt.Columns.Add("Lãi suất", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền lãi", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế TNCN", Type.GetType("System.Double"));
            dt.Columns.Add("Thực lãi", Type.GetType("System.Double"));


            DataTable temp = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string makhach = "";
            Double luyke=0;
            if (tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388")
            {
                 makhach = view.GetRowCellValue(view.FocusedRowHandle, "Mã").ToString();
                 try
                 {
                     luyke = luyke + Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Có cuối kỳ").ToString());
                 }
                 catch { }
                try
                 {
                     luyke = luyke  - Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Lãi suất").ToString());
                 }
                 catch { }
                try
                 {
                     luyke = luyke + Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Thuế TNCN").ToString());
                 }
                 catch { }
                   
            }
            else if (tsbt == "tsbtbccn31188ctth" || tsbt == "tsbtbccn3388ctth")
            {
                try
                {
                    luyke = luyke + Double.Parse(view.Columns["Có cuối kỳ"].SummaryText);
                }
                catch { }
                try
                {
                    luyke = luyke - Double.Parse(view.Columns["Lãi suất"].SummaryText);
                }
                catch { }
                try
                {
                    luyke = luyke+ Double.Parse(view.Columns["Thuế TNCN"].SummaryText);
                }
                catch { }
            }
          
            


            if (tsbt == "tsbtbccn31188")
            {
                temp = gen.GetTable("select a.RefID,a.AccountingObjectID,a.PostedDate,Amount,DateStart,DateEnd,Days,Interest,TaxAmount,AmoutCC,AccountNumber,AmoutPP,Tax,AccountingObjectCode,AccountingObjectName from Detail33 a, AccountingObject b WHERE a.AccountingObjectID=b.AccountingObjectID and Month(PostedDate)='" + thang + "' and  Year(PostedDate)='" + nam + "' and AccountNumber='31188' and a.AccountingObjectID='" + makhach + "' order by DateStart");
            }
            else if (tsbt == "tsbtbccn31188ctth")
            {
                temp = gen.GetTable("select a.RefID,a.AccountingObjectID,a.PostedDate,Amount,DateStart,DateEnd,Days,Interest,TaxAmount,AmoutCC,AccountNumber,AmoutPP,Tax,AccountingObjectCode,AccountingObjectName from Detail33 a, AccountingObject b WHERE a.AccountingObjectID=b.AccountingObjectID and Month(PostedDate)='" + thang + "' and  Year(PostedDate)='" + nam + "' and AccountNumber='31188' order by a.AccountingObjectID, DateStart");
            }
            else if (tsbt == "tsbtbccn3388")
            {
                temp = gen.GetTable("select a.RefID,a.AccountingObjectID,a.PostedDate,Amount,DateStart,DateEnd,Days,Interest,TaxAmount,AmoutCC,AccountNumber,AmoutPP,Tax,AccountingObjectCode,AccountingObjectName from Detail33 a, AccountingObject b WHERE a.AccountingObjectID=b.AccountingObjectID and Month(PostedDate)='" + thang + "' and  Year(PostedDate)='" + nam + "' and AccountNumber='3388' and a.AccountingObjectID='" + makhach + "' order by DateStart");
            }
            else if (tsbt == "tsbtbccn3388ctth")
            {
                temp = gen.GetTable("select a.RefID,a.AccountingObjectID,a.PostedDate,Amount,DateStart,DateEnd,Days,Interest,TaxAmount,AmoutCC,AccountNumber,AmoutPP,Tax,AccountingObjectCode,AccountingObjectName from Detail33 a, AccountingObject b WHERE a.AccountingObjectID=b.AccountingObjectID and Month(PostedDate)='" + thang + "' and  Year(PostedDate)='" + nam + "' and AccountNumber='3388' order by a.AccountingObjectID, DateStart");
            }

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                /*if (temp.Rows[i][7].ToString().ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][7].ToString().ToString()) != 0)
                    {*/
                        DataRow dr = dt.NewRow();
                        if (temp.Rows[i][9].ToString() != "")
                        {
                            if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                            {
                                dr[5] = temp.Rows[i][9].ToString();
                            }
                        }
                        if (temp.Rows[i][11].ToString() != "")
                        {
                            if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                            {
                                dr[6] = temp.Rows[i][11].ToString();
                            }
                        }

                        dr[0] = temp.Rows[i][13].ToString();
                        dr[1] = temp.Rows[i][14].ToString();
                        dr[2] = temp.Rows[i][4].ToString();
                        dr[3] = temp.Rows[i][5].ToString();
                        try
                        {
                            if (Double.Parse(temp.Rows[i][3].ToString().ToString()) != 0)
                                dr[7] = temp.Rows[i][3].ToString();

                            dr[8] = temp.Rows[i][12].ToString();

                            if (Double.Parse(temp.Rows[i][6].ToString().ToString()) != 0)
                                dr[4] = temp.Rows[i][6].ToString();

                            if (Double.Parse(temp.Rows[i][7].ToString().ToString()) != 0)
                                dr[9] = temp.Rows[i][7].ToString();
                            if (Double.Parse(temp.Rows[i][8].ToString().ToString()) != 0)
                                dr[10] = temp.Rows[i][8].ToString();
                            if (Double.Parse(temp.Rows[i][7].ToString()) - Double.Parse(temp.Rows[i][8].ToString()) != 0)
                                dr[11] = Double.Parse(temp.Rows[i][7].ToString()) - Double.Parse(temp.Rows[i][8].ToString());

                        }
                        catch { }
                        dt.Rows.Add(dr);
                    /*}
                }*/
            }

            if (tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388")
            {
                string ma;
                ma = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectID='" + makhach + "'");
                makhach = ma + " - " + makhach;
            }
            else if (tsbt == "tsbtbccn31188ctth" || tsbt == "tsbtbccn3388ctth")
            {
                makhach = "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG";
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            if (luyke != 0)
                rp.getluyke(luyke.ToString());
            rp.getdata(dt);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt+"lai");
            rp.gettenkh(makhach);
            rp.Show();
        }

        public void loadbchitietlaitndn(string tungay, string denngay)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Từ ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Đến ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Số ngày", Type.GetType("System.Double"));

            dt.Columns.Add("Gửi vào", Type.GetType("System.Double"));
            dt.Columns.Add("Rút ra", Type.GetType("System.Double"));

            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));

            dt.Columns.Add("Lãi suất", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền lãi", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế TNCN", Type.GetType("System.Double"));
            dt.Columns.Add("Thực lãi", Type.GetType("System.Double"));


            DataTable temp = new DataTable();
            string thangtruoc = DateTime.Parse(tungay).Month.ToString();
            string thangsau = DateTime.Parse(denngay).Month.ToString();
            string nam = DateTime.Parse(denngay).Year.ToString();
            Double luyke = 0;

            temp = gen.GetTable("select a.RefID,a.AccountingObjectID,a.PostedDate,Amount,DateStart,DateEnd,Days,Interest,TaxAmount,AmoutCC,AccountNumber,AmoutPP,Tax,AccountingObjectCode,AccountingObjectName from Detail33 a, AccountingObject b WHERE a.AccountingObjectID=b.AccountingObjectID and Month(PostedDate)>='" + thangtruoc + "' and Month(PostedDate)<='" + thangsau + "' and  Year(PostedDate)='" + nam + "' and AccountNumber='3388' order by a.AccountingObjectID, DateStart");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (temp.Rows[i][9].ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    {
                        dr[5] = temp.Rows[i][9].ToString();
                    }
                }
                if (temp.Rows[i][11].ToString() != "")
                {
                    if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    {
                        dr[6] = temp.Rows[i][11].ToString();
                    }
                }

                dr[0] = temp.Rows[i][13].ToString();
                dr[1] = temp.Rows[i][14].ToString();
                dr[2] = temp.Rows[i][4].ToString();
                dr[3] = temp.Rows[i][5].ToString();
                try
                {
                    if (Double.Parse(temp.Rows[i][3].ToString().ToString()) != 0)
                        dr[7] = temp.Rows[i][3].ToString();

                    dr[8] = temp.Rows[i][12].ToString();

                    if (Double.Parse(temp.Rows[i][6].ToString().ToString()) != 0)
                        dr[4] = temp.Rows[i][6].ToString();


                    /*dr[9] = temp.Rows[i][7].ToString();
                    dr[10] = temp.Rows[i][8].ToString();
                    dr[11] = Double.Parse(temp.Rows[i][7].ToString()) - Double.Parse(temp.Rows[i][8].ToString());*/
                    if (Double.Parse(temp.Rows[i][7].ToString().ToString()) != 0)
                        dr[9] = temp.Rows[i][7].ToString();
                    if (Double.Parse(temp.Rows[i][8].ToString().ToString()) != 0)
                        dr[10] = temp.Rows[i][8].ToString();
                    if (Double.Parse(temp.Rows[i][7].ToString()) - Double.Parse(temp.Rows[i][8].ToString()) != 0)
                        dr[11] = Double.Parse(temp.Rows[i][7].ToString()) - Double.Parse(temp.Rows[i][8].ToString());

                }
                catch { }
                dt.Rows.Add(dr);
               
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            if (luyke != 0)
                rp.getluyke(luyke.ToString());
            rp.getdata(dt);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt("31188laitndn");
            rp.gettenkh("");
            rp.Show();
        }

        public void loadchitietnothucte(string makhach,string tungay, string denngay, string kho,string dauky,string loai)
        {
            DataTable dt = new DataTable();
            makhach=gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='"+makhach+"'");
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Thanh toán", Type.GetType("System.Double"));
            dt.Columns.Add("Dư nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));
            dt.Columns.Add("Order", Type.GetType("System.Double"));
           
            Double duno = 0;
            try
            {
                duno = Double.Parse(dauky);
            }
            catch { }

            string hoadon="no";
            DialogResult dtr = XtraMessageBox.Show("Nhấn 'Yes' để in bảng kê chi tiết có hóa đơn, 'No' để in bảng kê chi tiết.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (dtr == DialogResult.Yes)
                hoadon = "co";

            DataTable temp=new DataTable();

            if(loai=="donvi")
                temp = gen.GetTable("baocaocongnothuctechitiettaidonvi '"+kho+"','"+makhach+"','"+tungay+"','"+denngay+"','"+loai+"'");
            else
                temp = gen.GetTable("baocaocongnothuctechitiet '"+kho+"','"+makhach+"','"+tungay+"','"+denngay+"','"+loai+"'");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                if (Double.Parse(temp.Rows[i][6].ToString())!=0)
                    dr[6] = temp.Rows[i][6].ToString();
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7].ToString();
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                {
                    dr[8] = temp.Rows[i][8].ToString();
                    duno=duno + Double.Parse(temp.Rows[i][8].ToString());
                }
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                {
                    dr[9] = temp.Rows[i][9].ToString();
                    duno = duno - Double.Parse(temp.Rows[i][9].ToString());
                }
                if (duno != 0)
                    dr[10] = duno.ToString();
                dr[11] = temp.Rows[i][10].ToString();
                dr[12] = temp.Rows[i][11].ToString();

                if (temp.Rows[i][12].ToString() != "")
                {
                    if (hoadon == "co")
                    {
                        DataTable da = gen.GetTable("select Distinct  CAST (InvNo AS float) from SSInvoice a, SSInvoiceINOutward b where a.RefID=b.SSInvoiceID and INOutwardID='" + temp.Rows[i][12] + "' order by CAST(a.InvNo as Float)");
                        for (int j = 0; j < da.Rows.Count; j++)
                        {
                            if (dr[2].ToString() == "")
                                dr[2] = da.Rows[j][0].ToString();
                            else
                                dr[2] = dr[2] + "," + da.Rows[j][0].ToString();
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(kho);
            rp.getkho(makhach);
            rp.getluyke(dauky);
            rp.gettungay(duno.ToString());
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt("tsbtbcctcntt");
            rp.Show();
        }

        public void loadsdhd(string tungay, string denngay,string tct,string userid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Quyển", Type.GetType("System.String"));
            dt.Columns.Add("Số SD", Type.GetType("System.Double"));
            dt.Columns.Add("Từ số", Type.GetType("System.String"));
            dt.Columns.Add("Đến số", Type.GetType("System.String"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Số KSD", Type.GetType("System.Double"));
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ký hiệu", Type.GetType("System.String"));
            /*dt.Columns.Add("Kho", Type.GetType("System.String"*));
            dt.Columns.Add("ID", Type.GetType("System.String"));
            DataTable temp = new DataTable();*/
            /*if (tct == "0")
                temp = gen.GetTable("select * from (select ParalellRefNo,COUNT(InvNo) as dem,MIN(InvNo) as nn,MAX(InvNo) as ln,SUM(TotalAmount+TotalCost-TotalDiscountAmount-TotalFreightAmount+TotalVATAmount) as tt,CAST (MAX(InvNo) AS float)-CAST (MIN(InvNo) AS float)-COUNT(InvNo)+1  as ksd,StockName+' - '+StockCode as tenkho,StockCode,StockID from SSInvoice a, Stock b where a.BranchID=b.StockID and PURefDate>='" + tungay + "' and PURefDate<='" + denngay + "' and a.BranchID='" + kho + "' group by StockName+' - '+StockCode,ParalellRefNo,StockCode,StockID) a order by ParalellRefNo");
            else
                temp = gen.GetTable("select * from (select ParalellRefNo,COUNT(InvNo) as dem,MIN(InvNo) as nn,MAX(InvNo) as ln,SUM(TotalAmount+TotalCost-TotalDiscountAmount-TotalFreightAmount+TotalVATAmount) as tt,CAST (MAX(InvNo) AS float)-CAST (MIN(InvNo) AS float)-COUNT(InvNo)+1  as ksd,StockName+' - '+StockCode as tenkho,StockCode,StockID from SSInvoice a, Stock b where a.BranchID=b.StockID and PURefDate>='" + tungay + "' and PURefDate<='" + denngay + "' and a.BranchID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') group by StockName+' - '+StockCode,ParalellRefNo,StockCode,StockID) a order by ParalellRefNo");
            */
            DataTable temp = new DataTable();
            //temp = gen.GetTable("selec * from (select ParalellRefNo,COUNT(InvNo) as dem,MIN(InvNo) as nn,MAX(InvNo) as ln,SUM(TotalAmount+TotalCost-TotalDiscountAmount-TotalFreightAmount+TotalVATAmount) as tt,CAST (MAX(InvNo) AS float)-CAST (MIN(InvNo) AS float)-COUNT(InvNo)+1  as ksd,InvSeries from SSInvoice a, Stock b where a.BranchID=b.StockID and PURefDate>='" + tungay + "' and PURefDate<='" + denngay + "' and a.BranchID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') group by ParalellRefNo,InvSeries) a order by ParalellRefNo");
            //temp = gen.GetTable("select * from (select ParalellRefNo,COUNT(InvNo) as dem,MIN(Cast(InvNo as Float)) as nn,MAX(Cast(InvNo as Float)) as ln,SUM(TotalAmount+TotalCost-TotalDiscountAmount-TotalFreightAmount+TotalVATAmount) as tt,CAST (MAX(CAST(InvNo as Float)) AS float)-CAST (MIN(CAST(InvNo as Float)) AS float)-COUNT(InvNo)+1  as ksd,InvSeries from SSInvoice a, Stock b where a.BranchID=b.StockID and PURefDate>='" + tungay + "' and PURefDate<='" + denngay + "' and a.BranchID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') group by ParalellRefNo,InvSeries) a order by ParalellRefNo");
            temp = gen.GetTable("bangketinhhinhsudunghoadon '" + userid + "','" + tungay + "','" + denngay + "'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    if (temp.Rows[i][0].ToString() != "")
                        dr[0] = temp.Rows[i][0].ToString();
                
                    if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                        dr[1] = temp.Rows[i][1].ToString();

                    if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                        dr[2] = temp.Rows[i][2].ToString();
                    if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                        dr[3] = temp.Rows[i][3].ToString();
                  
                    if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                        dr[4] = temp.Rows[i][4].ToString();
                    dr[7] = temp.Rows[i][6].ToString();
                    /*dr[8] = temp.Rows[i][7].ToString();
                    dr[9] = temp.Rows[i][8].ToString();*/
                    if (Double.Parse(temp.Rows[i][5].ToString()) > 0)
                    {
                        dr[5] = temp.Rows[i][5].ToString();
                        if (Double.Parse(temp.Rows[i][5].ToString()) < 50)
                        {
                            //DataTable da = gen.GetTable("select CAST (InvNo AS float) from SSInvoice where PURefDate>='" + tungay + "' and PURefDate<='" + denngay + "' and BranchID='" + temp.Rows[i][8].ToString() + "' and ParalellRefNo='" + temp.Rows[i][0].ToString() + "' order by CAST (InvNo AS float)");
                            DataTable da = gen.GetTable("select CAST (InvNo AS float) from SSInvoice where PURefDate>='" + tungay + "' and PURefDate<='" + denngay + "' and InvSeries='" + temp.Rows[i][6].ToString() + "' and ParalellRefNo='" + temp.Rows[i][0].ToString() + "' order by CAST (InvNo AS float)");
                            for (int j = 0; j < da.Rows.Count - 1; j++)
                            {
                                string check = "0";
                                Double sodau = Double.Parse(da.Rows[j][0].ToString());
                                while (check == "0")
                                {
                                    if (sodau + 1 == Double.Parse(da.Rows[j + 1][0].ToString()))
                                    {
                                        check = "1";
                                    }
                                    else if (sodau == Double.Parse(da.Rows[j + 1][0].ToString()))
                                    {
                                        check = "1";
                                        MessageBox.Show("Vui lòng xem lại số hóa đơn "+sodau.ToString());
                                    }
                                    else
                                    {
                                        if (dr[6].ToString() == "")
                                            dr[6] = (sodau + 1).ToString();
                                        else
                                            dr[6] = dr[6] + "," + (sodau + 1).ToString();
                                        sodau = sodau + 1;
                                    }
                                }
                            }
                        }
                        else dr[6] = "Không thể liệt kê";
                    }
                    else if(Double.Parse(temp.Rows[i][5].ToString()) < 0)
                    {
                        dr[5] = temp.Rows[i][5].ToString();
                        dr[6] = "Không thể liệt kê";
                    }
                    dt.Rows.Add(dr);
                }
                catch{ }
            }
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getkho(tct);
            rp.getdenngay(denngay);
            rp.gettsbt("thsdhd");
            rp.Show();
        }
    }
}
