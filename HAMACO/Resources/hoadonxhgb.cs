using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace HAMACO.Resources
{
    class hoadonxhgb
    {

        gencon gen = new gencon();
        public void loadhdbh(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Đối tượng", Type.GetType("System.String"));
            dt.Columns.Add("Ngày chứng từ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hóa đơn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Thuế", Type.GetType("System.Double"));
            dt.Columns.Add("Cộng tiền hàng", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền thuế", Type.GetType("System.Double"));            
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Hủy", Type.GetType("System.Boolean"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho xuất", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][5].ToString();
                dr[2] = temp.Rows[i][8].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][14].ToString();
                dr[5] = temp.Rows[i][64].ToString();
                dr[6] = temp.Rows[i][69].ToString();
                dr[9] = Double.Parse(temp.Rows[i][42].ToString());

                if (temp.Rows[i][66].ToString() != "")
                {
                    dr[7] = Double.Parse(temp.Rows[i][66].ToString());
                }
                dr[8] = Double.Parse(temp.Rows[i][38].ToString()) + Double.Parse(temp.Rows[i][46].ToString());
                dr[10] = (Double.Parse(temp.Rows[i][38].ToString()) + Double.Parse(temp.Rows[i][46].ToString()) + Double.Parse(temp.Rows[i][42].ToString())).ToString();
                
                dr[11] = "False";
                if (temp.Rows[i][63].ToString() == "True")
                {
                    dr[11] = "True";
                }
                try
                {
                    dr[12] = gen.GetString("select StockCode from Stock where StockID='" + temp.Rows[i][59].ToString() + "'");
                }
                catch { }
                try
                {
                    dr[13] = gen.GetString("select StockCode from Stock where StockID='" + temp.Rows[i][65].ToString() + "'");
                }
                catch { }
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Ngày chứng từ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày chứng từ"].Width = 100;
            view.Columns["Ngày chứng từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hóa đơn"].Width = 100;
            view.Columns["Ngày hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hóa đơn"].Width = 100;
            view.OptionsView.ShowFooter = true;
            view.Columns["Tiền thuế"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tiền thuế"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Tiền thuế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tiền thuế"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn nợ"].Width = 50;
            view.Columns["Thuế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thuế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thuế"].Width = 50;

            view.Columns["Cộng tiền hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Cộng tiền hàng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Cộng tiền hàng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Cộng tiền hàng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Hủy"].Width = 100;
            view.Columns["Mã kho xuất"].GroupIndex = 0;
            view.Columns["Mã kho"].GroupIndex = 1;
            
            view.ExpandAllGroups();
        }
        public void loadpnck(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Ngày chứng từ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hạch toán", Type.GetType("System.DateTime"));
            dt.Columns.Add("Mã kho xuất", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho xuất", Type.GetType("System.String"));
            dt.Columns.Add("Chứng từ xuất", Type.GetType("System.String"));
            dt.Columns.Add("Hủy", Type.GetType("System.Boolean"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][33].ToString();
                dr[2] = temp.Rows[i][3].ToString();
                dr[3] = temp.Rows[i][4].ToString();
                dr[4] = gen.GetString("select StockCode from Stock where StockID='" + temp.Rows[i][13].ToString() + "'");
                dr[5] = gen.GetString("select StockName from Stock where StockID='" + temp.Rows[i][13].ToString() + "'");
                dr[6] = temp.Rows[i][5].ToString();
                if (temp.Rows[i][34].ToString() == "True")
                    dr[7] = "True";
                else
                    dr[7] = "False";

                dr[8] = gen.GetString("select StockCode from Stock where StockID='" + temp.Rows[i][12].ToString() + "'");
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Ngày chứng từ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày chứng từ"].Width = 100;
            view.Columns["Ngày chứng từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hạch toán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hạch toán"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hạch toán"].Width = 100;
            view.Columns["Ngày hạch toán"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Hủy"].Width = 100;
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }
        public void tsbtpck(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid,DataTable khach,DataTable hang)
        {
            try
            {
            Frm_hoadonxhgb u = new Frm_hoadonxhgb();
            u.myac = new Frm_hoadonxhgb.ac(F.refreshhdxhgb);
            u.getpt("tsbthdxhgb");
            u.getactive(a);
            u.getsub(subsys);
            u.getroleid(roleid);
            u.gethang(hang);
            u.getkhach(khach);
            u.getdate(ngaychungtu);
            u.getuser(userid);
            u.getbranch(branchid);
            
                if (a == "1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                else
                    try
                    {
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());
                    }
                    catch { }
            u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu xuất hàng gửi bán trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1,  LookUpEdit ledv, LookUpEdit ledt, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, TextEdit txtnhd, ComboBoxEdit cbthue, DataTable khach, DataTable hang, LookUpEdit ledvx)
        {
            DataTable da = new DataTable();
            
            DataTable temp1 = new DataTable();
            DataTable temp2 = new DataTable();
            DataTable temp4 = new DataTable();

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            temp1.Columns.Add("Mã kho");
            temp1.Columns.Add("Tên kho");
            da = gen.GetTable("select * from Stock order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp1.Rows.Add(dr);
            }  
            ledv.Properties.DataSource = temp1;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;


            temp4.Columns.Add("Mã kho");
            temp4.Columns.Add("Tên kho");
            da = gen.GetTable("select StockCode,StockName from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='" + userid + "' order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp4.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp4.Rows.Add(dr);
            }
            ledvx.Properties.DataSource = temp4;
            ledvx.Properties.DisplayMember = "Mã kho";
            ledvx.Properties.ValueMember = "Mã kho";
            ledvx.Properties.PopupWidth = 300;

            /*temp2.Columns.Add("Mã đối tượng");
            temp2.Columns.Add("Tên đối tượng");
            da = gen.GetTable("select * from AccountingObject where IsEmployee='True' order by AccountingObjectCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp2.Rows.Add(dr);
            }
            ledt.Properties.DataSource = temp2;
            ledt.Properties.DisplayMember = "Mã đối tượng";
            ledt.Properties.ValueMember = "Mã đối tượng";
            ledt.Properties.PopupWidth = 400;*/

            temp2.Columns.Add("Mã đối tượng");
            temp2.Columns.Add("Tên đối tượng");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp2.Rows.Add(dr);
            }
            ledt.Properties.DataSource = temp2;
            ledt.Properties.DisplayMember = "Mã đối tượng";
            ledt.Properties.ValueMember = "Mã đối tượng";
            ledt.Properties.PopupWidth = 400;

            /*da = gen.GetTable("select InventoryItemCode,InventoryItemName from InventoryItem order by InventoryItemCode");
            DataTable temp3 = new DataTable();
            temp3.Columns.Add("Mã hàng");
            temp3.Columns.Add("Tên hàng");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp3.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp3.Rows.Add(dr);
            }
            mahang.DataSource = temp3;
            mahang.DisplayMember = "Mã hàng";
            mahang.ValueMember = "Mã hàng";
            mahang.PopupWidth = 400;*/
            DataTable temp3 = new DataTable();
            temp3.Columns.Add("Mã hàng");
            temp3.Columns.Add("Tên hàng");
            for (int i = 0; i < hang.Rows.Count; i++)
            {
                DataRow dr = temp3.NewRow();
                dr[0] = hang.Rows[i][1].ToString();
                dr[1] = hang.Rows[i][2].ToString();
                temp3.Rows.Add(dr);
            }
            mahang.DataSource = temp3;
            mahang.DisplayMember = "Mã hàng";
            mahang.ValueMember = "Mã hàng";
            mahang.PopupWidth = 400;

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));
        
            gridControl1.DataSource = dt;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;

            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Chi phí"].ColumnEdit = chiphi;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Đơn giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Đơn giá"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Chi phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chi phí"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Chi phí"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Chi phí"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

        }

        public void loadpck(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_hoadonxhgb F, LookUpEdit ledt, TextEdit txtldn,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string userid, string branchid, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, TextEdit txtcth, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, TextEdit txtnhd, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd, ComboBoxEdit cbthue, TextEdit txthtt, TextEdit txthttt, TextEdit txtttthue, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, TextEdit txtquyen, LookUpEdit ledvx)
        {
            DataTable dt = new DataTable();
            loadstart(gridControl1, gridView1, ledv, ledt, denct, denht, mahang, soluong, soluongqd, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dongia, thanhtien, chiphi, txtnhd,cbthue,khach,hang,ledvx);
            if (active == "1")
            {
                
                DataTable da = new DataTable();

                F.Text = "Xem hóa đơn xuất hàng gửi bán";

                da = gen.GetTable("select AccountingObjectCode,RefNo,Posted,AccountingObjectType,Cancel,PUPostedDate,PURefDate,CABARefDate,PUJournalMemo,TotalAmount,DueDateTime,AccountingObjectID1562,Tax,No,InvSeries,InvNo,PayNo,TotalVatAmount,StockCode,ParalellRefNo,AccountingObjectID1562  from SSInvoiceBranch a, AccountingObject b, Stock c where a.StockID=c.StockID and a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");

                ledv.EditValue = da.Rows[0][18].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                txtldn.Text = da.Rows[0][8].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][6].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][1].ToString();
                txtms.Text = da.Rows[0][13].ToString();
                txtkhhd.Text = da.Rows[0][14].ToString();
                txtshd.Text = da.Rows[0][15].ToString();
                txtnhd.EditValue = DateTime.Parse(da.Rows[0][7].ToString());
                txthtt.Text = da.Rows[0][10].ToString();
                txthttt.Text = da.Rows[0][16].ToString();
                cbthue.Text = da.Rows[0][12].ToString();
                txtquyen.Text = da.Rows[0][19].ToString();
                Double tienthue = 0;
                try
                {
                    ledvx.EditValue = gen.GetString("select StockCode from Stock where StockID='" + da.Rows[0][20].ToString() + "'");

                }
                catch 
                {
                    ledvx.EditValue = null;
                }
                try
                {
                    tienthue = Double.Parse(da.Rows[0][17].ToString());
                }
                catch { }
             
                if (da.Rows[0][2].ToString() == "True")
                {
                    tsbtghiso.Visible = false;
                    tsbtboghi.Visible = true;
                    tsbtsua.Enabled = false;
                }
                else
                {
                    tsbtboghi.Visible = false;
                    tsbtghiso.Visible = true;
                    tsbtsua.Enabled = true;
                }

                da = gen.GetTable("select  InventoryItemCode,InventoryItemName,Quantity,QuantityConvert,a.UnitPrice,a.Amount,FreightAmount from SSInvoiceBranchDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][1].ToString();
                    dr[2] = da.Rows[i][2].ToString();
                    dr[3] = da.Rows[i][3].ToString();
                    dr[4] = da.Rows[i][4].ToString();
                    dr[5] = da.Rows[i][5].ToString();
                    dr[6] = da.Rows[i][6].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;

                Double tongthanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                Double tongchiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                txtcth.Text = String.Format("{0:n0}", tongthanhtien + tongchiphi);
                txtttthue.EditValue = tienthue;
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu, branchid);
            }
            else
            {
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                cbthue.EditValue = "10";
                ledvx.ItemIndex = 0;
                F.Text = "Thêm hóa đơn xuất hàng gửi bán";
                denct.EditValue = DateTime.Parse(ngaychungtu);
                denht.EditValue = DateTime.Parse(ngaychungtu);
                txtnhd.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void loadhb(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, string active,string ngaychungtu,string ledv,string branchid)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            string kho = gen.GetString("select StockID from Stock where StockCode='"+ledv+"'");

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            gridView1.Columns.Clear();
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            temp = gen.GetTable("layhangbantheothang '"+thangtruoc+"','"+namtruoc+"','"+thang+"','"+nam+"','"+kho+"','"+branchid+"'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dt.Rows.Add(dr);
            }
            gridControl1.DataSource = dt;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        }

        public void checkpck(string active, string role, Frm_hoadonxhgb F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, TextEdit txtsct, TextEdit txtname,TextEdit txtdc,TextEdit txtldn, DateEdit denct, DateEdit denht,string ngaychungtu,
            ComboBoxEdit cbthue, string userid, string branchid, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd, TextEdit txtnhd, TextEdit txthtt, TextEdit txthttt, TextEdit txtthue, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtquyen, LookUpEdit ledvx)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 8];
                string check = "0";
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == "")
                        check = "1";
                    else
                    {
                        string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        detail[i, 0] = mh;
                    }
                    if (gridView1.GetRowCellValue(i, "Số lượng").ToString() == "")
                        detail[i, 1] = "0";
                    else
                        detail[i, 1] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString() == "")
                        check = "1";
                    detail[i, 2] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail[i, 4] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 5] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Chi phí").ToString() == "")
                        detail[i, 6] = "0";
                    else detail[i, 6] = gridView1.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "");

                }

                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> <Đơn giá> <Thành tiền> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string dvx = gen.GetString("select * from Stock where StockCode='" + ledvx.EditValue.ToString() + "'");
                    string tongtien = gridView1.Columns["Thành tiền"].SummaryText.Replace(".", "");
                    string chiphi = gridView1.Columns["Chi phí"].SummaryText.Replace(".", "");
                    Double tongcong = Double.Parse(tongtien) + Double.Parse(chiphi);
                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from SSInvoiceBranch where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }

                        gen.ExcuteNonquery("insert into SSInvoiceBranch(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,PUJournalMemo,Posted,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalVatAmount,StockID,ParalellRefNo,AccountingObjectID1562) values(newid(),'" + branchid + "',101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtldn.Text + "','False','" + tongtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "','" + txthtt.Text + "','" + chiphi + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + txtthue.Text.Replace(".", "") + "','" + dv + "','" + txtquyen.Text + "','" + dvx + "')");
                        string refid = gen.GetString("select * from SSInvoiceBranch where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1368','51112','" + tongcong.ToString() + "','" + dt + "','" + dvx + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1368','33311','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dvx + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into SSInvoiceBranchDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,Amount,FreightAmount) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "')");
                        }

                    }
                    else
                    {
                        gen.ExcuteNonquery("update SSInvoiceBranch set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text + "',PUJournalMemo=N'" + txtldn.Text + "',TotalAmount='" + tongtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + chiphi + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalVatAmount='" + txtthue.Text.Replace(".", "") + "',StockID='" + dv + "',ParalellRefNo='" + txtquyen.Text + "',AccountingObjectID1562='"+dvx+"' where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  SSInvoiceBranchDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1368','51112','" + tongcong.ToString() + "','" + dt + "','" + dvx + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1368','33311','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dvx + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into SSInvoiceBranchDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,Amount,FreightAmount) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "')");
                        }

                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu hóa đơn xuất hàng gửi bán";
                }

            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void delete(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = view.RowCount - 1; i >= 0; i--)
            {
                view.DeleteRow(i);
            }
            view.UpdateCurrentRow();
        }

        public void themsct(string ngaychungtu, TextEdit txtsct, string ledv, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkho = gen.GetString("select * from Stock where StockCode='" + ledv + "'");
            string dv = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = dv + "-" + ledv + "-HDGB";
           
            try
            {
                string id = gen.GetString("select Top 1 RefNo from SSInvoiceBranch where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by SUBSTRING(RefNo,4,12) DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam;}

            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, ledv, sophieu, ngaychungtu,branchid);
        }

        public void tsbtdeletepnk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu xuất hàng gửi bán " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from SSInvoiceBranchDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from SSInvoiceBranch where RefID='" + name + "'");                   
                    gen.ExcuteNonquery("delete from HACHTOAN where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu xuất hàng gửi bán trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hoadonxhgb F, string ngay, string branchid,string ledv)
        {
            try
            {
                ledv = gen.GetString("select * from Stock where StockCode='" + ledv + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from SSInvoiceBranch where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and StockID='"+ledv+"' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from SSInvoiceBranch where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and StockID='"+ledv+"' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hoadonxhgb F, string ngay, string branchid,string ledv)
        {
            try
            {
                ledv = gen.GetString("select * from Stock where StockCode='"+ledv+"'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from SSInvoiceBranch where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and StockID='"+ledv+"'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from SSInvoiceBranch where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and StockID='" + ledv + "' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }

        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu,string branchid)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from SSInvoiceBranch where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + branchid + "' and StockID='"+idkho+"'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from SSInvoiceBranch where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + branchid + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
