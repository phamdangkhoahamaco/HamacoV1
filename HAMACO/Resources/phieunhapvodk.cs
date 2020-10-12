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
    class phieunhapvodk
    {
        gencon gen = new gencon();
        public void loadpnk(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string userid, string ngaychungtu)
        {
            string sql = "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,JournalMemo,TotalAmount,DocumentIncluded,StockCode from INInwardLPG a, Stock b where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo";
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Ngày chứng từ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hạch toán", Type.GetType("System.DateTime"));
            dt.Columns.Add("Nhà cung cấp", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chứng từ gốc", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dr[6] = temp.Rows[i][6].ToString();
                dr[7] = temp.Rows[i][7].ToString();
                dr[8] = temp.Rows[i][8].ToString();
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

            view.Columns["Chứng từ gốc"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Chứng từ gốc"].Width = 100;
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void tsbtpnk(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang)
        {
            try
            {
                Frm_phieunhapvo u = new Frm_phieunhapvo();
                u.myac = new Frm_phieunhapvo.ac(F.refreshpnkvotddh);
                u.getactive(a);
                u.getsub(subsys);
                u.getroleid(roleid);
                u.getkhach(khach);
                u.gethang(hang);
                u.getpt("pnkvtddh");
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                /*try
                {*/
                if (a == "1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                else
                {
                    try
                    {
                        u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());
                    }
                    catch
                    {
                        u.getrole(gen.GetString("select Top 1 StockCode from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode"));
                    }
                }
                /*}
                catch { }*/
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập kho trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit taikhoan, DataTable khach, DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit congty)
        {
            cbldt.Properties.Items.Clear();
            cbldt.Properties.Items.Add("Khách hàng");
            cbldt.Properties.Items.Add("Nhà cung cấp");
            cbldt.Properties.Items.Add("Nhân viên");
            cbldt.SelectedIndex = 0;

            DataTable da = new DataTable();
            DataTable temp = new DataTable();

            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            da = gen.GetTable("select * from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;

            da = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã tài khoản");
            temp1.Columns.Add("Tên tài khoản");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp1.Rows.Add(dr);
            }
            taikhoan.DataSource = temp1;
            taikhoan.DisplayMember = "Mã tài khoản";
            taikhoan.ValueMember = "Mã tài khoản";

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

            DataTable temp5 = new DataTable();
            temp5.Columns.Add("Công ty");
            temp5.Rows.Add("HAMACO");
            temp5.Rows.Add("Thiên An");
            temp5.Rows.Add("Dịch vụ HAMACO");
            congty.DataSource = temp5;
            congty.DisplayMember = "Công ty";
            congty.ValueMember = "Công ty";
            congty.PopupWidth = 100;

            dt.Columns.Add("Tài khoản nợ");
            dt.Columns.Add("Tài khoản có");
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Thế chân", Type.GetType("System.Double"));
            dt.Columns.Add("Chênh lệch", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá BX", Type.GetType("System.Double"));
            dt.Columns.Add("Bốc xếp", Type.GetType("System.Double"));
            dt.Columns.Add("Diễn giải");

            gridControl1.DataSource = dt;
            gridView1.Columns["Tài khoản nợ"].ColumnEdit = taikhoan;
            gridView1.Columns["Tài khoản có"].ColumnEdit = taikhoan;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng xuất"].ColumnEdit = soluong;
            gridView1.Columns["Thế chân"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Chênh lệch"].ColumnEdit = soluong;
            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Diễn giải"].Width = 100;
            gridView1.Columns["Diễn giải"].ColumnEdit = congty;
            gridView1.Columns["Diễn giải"].Caption = "Công ty";

            gridView1.Columns["Đơn giá BX"].ColumnEdit = dongia;
            gridView1.Columns["Bốc xếp"].ColumnEdit = thanhtien;

            gridView1.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Số lượng xuất"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Chênh lệch"].OptionsColumn.AllowEdit = false;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;

            gridView1.Columns["Số lượng xuất"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng xuất"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Số lượng xuất"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng xuất"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng xuất"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;

            gridView1.Columns["Thế chân"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thế chân"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thế chân"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thế chân"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng"].Caption = "Số lượng nhập";

            gridView1.Columns["Chênh lệch"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chênh lệch"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Chênh lệch"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Chênh lệch"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Chênh lệch"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Đơn giá BX"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá BX"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Bốc xếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Bốc xếp"].DisplayFormat.FormatString = "{0:n0}";


            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";
        }

        public void loadpnk(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, Frm_phieunhapvo F, LookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, TextEdit txtptvc, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit taikhoan, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, CheckEdit chtc, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit congty,TextEdit txttaixe)
        {
            DataTable dt = new DataTable();
            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, mahang, soluong, dongia, thanhtien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, taikhoan, khach, hang, congty);
            if (active == "1")
            {
                DataTable da = new DataTable();

                da = gen.GetTable("select  CreditAccount,DebitAccount,InventoryItemCode,InventoryItemName,QuantityExits,Quantity,a.ConvertRate,QuantityConvertExits,a.UnitPrice,a.Amount,a.UnitPriceConvertOC,a.AmountOC,Description from INInwardLPGDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[2] = da.Rows[i][2].ToString();
                    dr[3] = da.Rows[i][3].ToString();
                    dr[4] = da.Rows[i][4].ToString();
                    dr[5] = da.Rows[i][5].ToString();
                    dr[6] = da.Rows[i][6].ToString();
                    dr[7] = da.Rows[i][7].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    dr[9] = da.Rows[i][9].ToString();
                    if (da.Rows[i][10].ToString() != "")
                        dr[10] = da.Rows[i][10].ToString();
                    if (da.Rows[i][11].ToString() != "")
                        dr[11] = da.Rows[i][11].ToString();
                    dr[12] = da.Rows[i][12].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,InwardType,a.CustomField2  from INInwardLPG a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                try
                {
                    cbldt.SelectedIndex = Int32.Parse(da.Rows[0][9].ToString());
                }
                catch { }
                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                try
                {
                    txtldn.Text = da.Rows[0][2].ToString();
                }
                catch { }

                txtctg.Properties.ReadOnly = true;
                txtctg.Text = da.Rows[0][3].ToString();

                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][6].ToString();
                txtngh.Text = da.Rows[0][1].ToString();
                txtptvc.Text = da.Rows[0][11].ToString();
                txttaixe.Text = da.Rows[0][13].ToString();
                if (da.Rows[0][8].ToString() == "True")
                {
                    tsbtghiso.Visible = false;
                    tsbtboghi.Visible = true;
                    tsbtsua.Enabled = false;
                }
                else
                {
                    tsbtboghi.Visible = false;
                    tsbtghiso.Visible = true;
                }
                if (da.Rows[0][10].ToString() == "True")
                {
                    tsbtboghi.Enabled = false;
                    tsbtghiso.Enabled = false;
                }
                if (da.Rows[0][12].ToString() == "True")
                    chtc.Checked = true;
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                F.Text = "Thêm phiếu nhập Vỏ";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                chtc.Checked = false;
                denht.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void checkpnk(string active, string role, Frm_phieunhapvo F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, CheckEdit chtc,TextEdit txttaixe)
        {
            /*try
            {*/
                string dtt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string dt = gen.GetString("select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string dt_ta = gen.GetString("select * from hamaco_ta.dbo.AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string dt_tn = gen.GetString("select * from hamaco_tn.dbo.AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                
                string[,] detail = new string[20, 15];
                Double[,] tong = new Double[20, 20];
                for (int j = 0; j < 3; j++)
                {
                    tong[j, 0] = 0;
                    tong[j, 1] = 0;
                    tong[j, 2] = 0;
                }
                string check = "0";

                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == "")
                        check = "1";
                    else
                        detail[i, 0] = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");


                    if (gridView1.GetRowCellValue(i, "Số lượng").ToString() == "")
                    {
                        detail[i, 1] = "0";
                        detail[i, 2] = "0";
                    }
                    else
                    {
                        detail[i, 1] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                        detail[i, 2] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                    }

                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        detail[i, 4] = "0";
                    else detail[i, 4] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        detail[i, 5] = "0";
                    else detail[i, 5] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "Số lượng xuất").ToString() == "")
                        detail[i, 8] = "0";
                    else detail[i, 8] = gridView1.GetRowCellValue(i, "Số lượng xuất").ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "Chênh lệch").ToString() == "")
                        detail[i, 9] = "0";
                    else detail[i, 9] = gridView1.GetRowCellValue(i, "Chênh lệch").ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "Thế chân").ToString() == "")
                        detail[i, 11] = "0";
                    else detail[i, 11] = gridView1.GetRowCellValue(i, "Thế chân").ToString().Replace(".", "");


                    if (gridView1.GetRowCellValue(i, "Đơn giá BX").ToString() == "")
                        detail[i, 12] = "0";
                    else detail[i, 12] = gridView1.GetRowCellValue(i, "Đơn giá BX").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Bốc xếp").ToString() == "")
                        detail[i, 13] = "0";
                    else detail[i, 13] = gridView1.GetRowCellValue(i, "Bốc xếp").ToString().Replace(".", "").Replace(",", ".");


                    if (cbldt.EditValue.ToString() == "Khách hàng")
                    {
                        if (Double.Parse(detail[i, 9]) > 0)
                        {
                            detail[i, 7] = "131";
                            detail[i, 6] = "34411";
                        }
                        else if (Double.Parse(detail[i, 9]) < 0)
                        {
                            detail[i, 6] = "131";
                            detail[i, 7] = "34411";
                        }
                    }
                    else
                    {
                        if (Double.Parse(detail[i, 9]) < 0)
                        {
                            detail[i, 6] = "331";
                            detail[i, 7] = "24411";
                        }
                    }
                    

                    detail[i, 3] = gridView1.GetRowCellValue(i, "Diễn giải").ToString();

                    if (detail[i, 3] == "HAMACO")
                    {
                        detail[i, 10] = gen.GetString("select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        tong[0, 0] = tong[0, 0] + Double.Parse(detail[i, 5]);
                    }
                    else if (detail[i, 3] == "Thiên An")
                    {
                        detail[i, 10] = gen.GetString("select * from hamaco_ta.dbo.InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        tong[1, 0] = tong[1, 0] + Double.Parse(detail[i, 5]);
                    }
                    else if (detail[i, 3] == "Dịch vụ HAMACO")
                    {
                        detail[i, 10] = gen.GetString("select * from hamaco_tn.dbo.InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        tong[2, 0] = tong[2, 0] + Double.Parse(detail[i, 5]);
                    }
                }
                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> <Đơn giá> <Thành tiền> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";
                    string tongtien = gridView1.Columns["Thành tiền"].SummaryText.Replace(".", "");
                    if (active == "0")
                    {
                        /*try
                        {
                            string ton = gen.GetString("select * from INInwardLPG where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            //XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }*/

                        themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);

                        gen.ExcuteNonquery("insert into INInwardLPG(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,TotalAmount,UserID,InwardType,CustomField2) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dtt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + tongtien + "','" + userid + "','" + chtc.Checked + "',N'" + txttaixe.Text + "')");
                        gen.ExcuteNonquery("insert into hamaco.dbo.INInwardSU(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,TotalAmount,UserID,InwardType,CustomField2) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + tong[0, 0] + "','" + userid + "','" + chtc.Checked + "',N'" + txttaixe.Text + "')");
                        gen.ExcuteNonquery("insert into hamaco_ta.dbo.INInwardSU(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,TotalAmount,UserID,InwardType,CustomField2) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt_ta + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + tong[1, 0] + "','" + userid + "','" + chtc.Checked + "',N'" + txttaixe.Text + "')");
                        gen.ExcuteNonquery("insert into hamaco_tn.dbo.INInwardSU(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,TotalAmount,UserID,InwardType,CustomField2) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt_tn + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + tong[2, 0] + "','" + userid + "','" + chtc.Checked + "',N'" + txttaixe.Text + "')");
                        
                        string refid = gen.GetString("select * from INInwardLPG where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);

                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INInwardLPGDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,QuantityExits,QuantityConvertExits,UnitPrice,Amount,DebitAccount,CreditAccount,ListItemID,ConvertRate,UnitPriceConvertOC,AmountOC) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 7] + "','" + detail[i, 6] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "')");
                        }
                    }
                    else
                    {
                        gen.ExcuteNonquery("update INInwardLPG set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dtt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',TotalAmount='" + tongtien + "',UserID='" + userid + "', InwardType='" + chtc.Checked + "',CustomField2=N'" + txttaixe.Text + "'  where RefID = '" + role + "'");
                        gen.ExcuteNonquery("update hamaco.dbo.INInwardSU set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',TotalAmount='" + tong[0, 0] + "',UserID='" + userid + "', InwardType='" + chtc.Checked + "',CustomField2=N'" + txttaixe.Text + "'  where RefNo = '" + txtsct.Text + "'");
                        gen.ExcuteNonquery("update hamaco_ta.dbo.INInwardSU set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt_ta + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',TotalAmount='" + tong[1, 0] + "',UserID='" + userid + "', InwardType='" + chtc.Checked + "',CustomField2=N'" + txttaixe.Text + "'  where RefNo = '" + txtsct.Text + "'");
                        gen.ExcuteNonquery("update hamaco_tn.dbo.INInwardSU set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt_tn + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',TotalAmount='" + tong[2, 0] + "',UserID='" + userid + "', InwardType='" + chtc.Checked + "',CustomField2=N'" + txttaixe.Text + "'  where RefNo = '" + txtsct.Text + "'");
                        
                        gen.ExcuteNonquery("delete  from  INInwardLPGDetail where RefID ='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INInwardLPGDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,QuantityExits,QuantityConvertExits,UnitPrice,Amount,DebitAccount,CreditAccount,ListItemID,ConvertRate,UnitPriceConvertOC,AmountOC) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 7] + "','" + detail[i, 6] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "')");
                        }
                    }
                    gen.ExcuteNonquery("dondathangvolpg '" + txtsct.Text + "'");
                    F.getactive("1");
                }
            /*}
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }


        public void themsct(string ngaychungtu, TextEdit txtsct, string mk, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PNVT";

            try
            {
                string id = gen.GetString("select Top 1 RefNo from INInwardLPG where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }

            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, mk, sophieu, ngaychungtu);
        }

        public void tsbtdeletepnk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                string name_vt = gen.GetString("select * from hamaco.dbo.INInwardSU where RefNo='" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "'");
                string name_ta = gen.GetString("select * from hamaco_ta.dbo.INInwardSU where RefNo='" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "'");
                string name_tn = gen.GetString("select * from hamaco_tn.dbo.INInwardSU where RefNo='" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "'");
                
                if (gen.GetString("select Posted from INInwardLPG where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu nhập kho Vỏ" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from INInwardLPGDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from INInwardLPG where RefID='" + name + "'");
                    
                    gen.ExcuteNonquery("delete from hamaco.dbo.INInwardSUDetail where RefID='" + name_vt + "'");
                    gen.ExcuteNonquery("delete from hamaco.dbo.INInwardSU where RefID='" + name_vt + "'");

                    gen.ExcuteNonquery("delete from hamaco_ta.dbo.INInwardSUDetail where RefID='" + name_ta + "'");
                    gen.ExcuteNonquery("delete from hamaco_ta.dbo.INInwardSU where RefID='" + name_ta + "'");

                    gen.ExcuteNonquery("delete from hamaco_tn.dbo.INInwardSUDetail where RefID='" + name_tn + "'");
                    gen.ExcuteNonquery("delete from hamaco_tn.dbo.INInwardSU where RefID='" + name_tn + "'");                    
                    
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu nhập kho trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapvo F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INInwardLPG where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INInwardLPG where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapvo F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INInwardLPG where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INInwardLPG where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }

        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from INInwardLPG where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INInwardLPG where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
