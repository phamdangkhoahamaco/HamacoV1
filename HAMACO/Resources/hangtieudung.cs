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
    class hangtieudung
    {
        gencon gen = new gencon();

        public void loadstart(LookUpEdit ledv, string userid)
        {
            DataTable temp = new DataTable();
            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            temp = gen.GetTable("select StockCode as 'Mã kho',StockName as 'Tên kho' from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode");
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;
            ledv.ItemIndex = 0;
        }

        public void loadStockmain(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string tungay, string denngay, string kho, string tsbt)
        {
            view.Columns.Clear();
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));

           if (tsbt == "bkthbhtnvkd")
                temp = gen.GetTable("select DISTINCT b.AccountingObjectID,AccountingObjectCode,b.AccountingObjectName from INOutward a, AccountingObject b where RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and a.StockID = (select StockID from Stock where StockCode='" + kho + "') and EmployeeIDSA=b.AccountingObjectID order by AccountingObjectCode");
            
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

            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            if (tsbt == "bkthbhtnvkd")
            {
                view.Columns["Mã kho"].Caption = "Mã nhân viên";
                view.Columns["Tên kho"].Caption = "Tên nhân viên";
            }
        }


        public void loadbangkehangtheongay(string ngaychungtu, string ngaycuoi, string tsbt, string manhanvien, DevExpress.XtraGrid.GridControl DAT, DevExpress.XtraGrid.Views.Grid.GridView ViewDAT)
        {

            ViewDAT.Columns.Clear();
            ViewDAT.OptionsView.ColumnAutoWidth = true;

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã vạch mới", Type.GetType("System.String"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));
            dt.Columns.Add("Đồng ý", Type.GetType("System.Boolean"));

            temp = gen.GetTable("select InventoryItemCode,InventoryItemName,SUM(Quantity),SUM(QuantityConvert),UnitPriceOC,sum(AmountOC) from INOutward a,INOutwardDetail b, InventoryItem c where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and EmployeeIDSA='" + manhanvien + "' group by InventoryItemCode,InventoryItemName,UnitPriceOC order by UnitPriceOC DESC,SUBSTRING(InventoryItemCode,8,2),InventoryItemCode");
           
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                dr[4] = temp.Rows[i][4];
                dr[5] = temp.Rows[i][5];
                dt.Rows.Add(dr);
            }

            DAT.DataSource = dt;           

            ViewDAT.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;

            ViewDAT.Columns["Đơn giá"].Visible = false;
            ViewDAT.Columns["Thành tiền"].Visible = false;
            ViewDAT.Columns["Ghi chú"].Visible = false;
            ViewDAT.Columns["Mã vạch mới"].Visible = false;

            ViewDAT.Columns["Mã hàng"].Width = 80;            
            ViewDAT.Columns["Tên hàng"].Width = 200;
            ViewDAT.Columns["Số lượng"].Width = 80;
            ViewDAT.Columns["Trọng lượng"].Width = 100;
            ViewDAT.Columns["Đơn giá"].Width = 100;
            ViewDAT.Columns["Thành tiền"].Width = 100;
            ViewDAT.Columns["Đồng ý"].Width = 80;

            ViewDAT.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewDAT.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            ViewDAT.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewDAT.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewDAT.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewDAT.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n0}";
            ViewDAT.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewDAT.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewDAT.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewDAT.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            ViewDAT.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewDAT.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            ViewDAT.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewDAT.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

        }

        public void loadbanghanghoa(DevExpress.XtraGrid.GridControl DAT, DevExpress.XtraGrid.Views.Grid.GridView ViewDAT, DataTable temp)
        {

            ViewDAT.Columns.Clear();
            ViewDAT.OptionsView.ColumnAutoWidth = true;

            DataTable dt = new DataTable();
           
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Đồng ý", Type.GetType("System.Boolean"));
            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dt.Rows.Add(dr);
            }

            DAT.DataSource = dt;

            ViewDAT.Columns["ID"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;

            ViewDAT.Columns["ID"].Visible = false;

            ViewDAT.Columns["Mã hàng"].Width = 80;
            ViewDAT.Columns["Tên hàng"].Width = 200;
            ViewDAT.Columns["Đồng ý"].Width = 80;
        }

        public void loadbangkehangtheongayin(string ngaychungtu, string ngaycuoi, string manhanvien)
        {

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Khuyến mãi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));

            temp = gen.GetTable("select InventoryItemCode,InventoryItemName,SUM(Quantity),SUM(QuantityConvert),UnitPriceOC,sum(AmountOC),case when Quantity=0 then c.ConvertUnit else c.Unit end as loai from INOutward a,INOutwardDetail b, InventoryItem c where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and EmployeeIDSA='" + manhanvien + "' and RefType<>'1' group by InventoryItemCode,InventoryItemName,UnitPriceOC,case when Quantity=0 then c.ConvertUnit else c.Unit end order by UnitPriceOC DESC,SUBSTRING(InventoryItemCode,8,2),InventoryItemCode");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                {
                    dr[2] = temp.Rows[i][2];
                    dr[3] = temp.Rows[i][3];
                }
                else
                    dr[4] = temp.Rows[i][3];
                dr[5] = temp.Rows[i][6];
                dt.Rows.Add(dr);
            }
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.getdata(dt);
            F.getngay(ngaychungtu);
            F.getrole(manhanvien);
            F.gettsbt("bkthbhtnvkdintong");
            F.ShowDialog();
        }

        public void loadbangkebanhangtheongay(string ngaychungtu, string ngaycuoi, string manhanvien)
        {
            manhanvien = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectID='" + manhanvien + "'");
            DataTable temp = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',JournalMemo as 'Đơn hàng', AccountingObjectCode as 'Mã khách', a.AccountingObjectName as 'Tên khách' ,a.AccountingObjectAddress as 'Địa chỉ',TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)) as 'Số tiền' from INOutward a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefDate>='" + ngaychungtu + "' and RefDate<='" + ngaycuoi + "' and EmployeeIDSA='" + manhanvien + "' order by AccountingObjectCode");
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.getdata(temp);
            F.getngay(ngaychungtu);
            F.getrole(manhanvien);
            F.gettsbt("bkthbhtnvkd");
            F.ShowDialog();
        }

        public void loadbangkehangtheongayin(string ngaychungtu, string userid)
        {

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Khuyến mãi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));
            string manhanvien = null;

            temp = gen.GetTable("select InventoryItemCode,InventoryItemName,SUM(Quantity),SUM(QuantityConvert),UnitPriceOC,sum(AmountOC),case when Quantity=0 then c.ConvertUnit else c.Unit end as loai,EmployeeIDSACode from INOutward a,INOutwardDetail b, InventoryItem c, (select * from OpeningAccountEntry131TT where EmployeeIDSAName='" + userid + "') d where a.RefNo=d.RefNo and a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and RefType<>'1' group by InventoryItemCode,InventoryItemName,UnitPriceOC,EmployeeIDSACode,case when Quantity=0 then c.ConvertUnit else c.Unit end order by UnitPriceOC DESC,SUBSTRING(InventoryItemCode,8,2),InventoryItemCode");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                {
                    dr[2] = temp.Rows[i][2];
                    dr[3] = temp.Rows[i][3];
                }
                else
                    dr[4] = temp.Rows[i][3];
                dr[5] = temp.Rows[i][6];
                manhanvien = temp.Rows[i][7].ToString();
                dt.Rows.Add(dr);
            }
            if (manhanvien != null)
            {
                manhanvien = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + manhanvien + "'");
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.getdata(dt);
                F.getngay(ngaychungtu);
                F.getrole(manhanvien);
                F.gettsbt("bkthbhtnvkdintong");
                F.ShowDialog();
            }
        }

    }
}
