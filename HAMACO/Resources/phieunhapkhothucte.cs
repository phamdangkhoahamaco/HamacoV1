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
    class phieunhapkhothucte
    {
        gencon gen = new gencon();
        public void loadpnk(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
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
            dt.Columns.Add("Hàng gửi", Type.GetType("System.Boolean"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Cắt hàng", Type.GetType("System.Boolean"));
            dt.Columns.Add("Nhà máy", Type.GetType("System.Boolean"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][4].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][6].ToString();
                dr[5] = temp.Rows[i][9].ToString();
                if (temp.Rows[i][1].ToString() == "1" || temp.Rows[i][1].ToString() == "4")
                    dr[6] = "True";
                else if (temp.Rows[i][1].ToString() == "2")
                    dr[8] = "True";
                else if (temp.Rows[i][1].ToString() == "5")
                    dr[9] = "True";

                dr[7] = gen.GetString("select StockCode from Stock where StockID='" + temp.Rows[i][22].ToString() + "'");
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

            view.Columns["Hàng gửi"].Width = 80;
            view.Columns["Cắt hàng"].Width = 80;
            view.Columns["Nhà máy"].Width = 80;
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void tsbtpnk(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang, string tsbt)
        {
            try
            {
                Frm_phieunhapkho u = new Frm_phieunhapkho();
                if (tsbt == "tsbtpxkhg")
                    u.myac = new Frm_phieunhapkho.ac(F.refreshpxkhgkh);
                else
                    u.myac = new Frm_phieunhapkho.ac(F.refreshpnktt);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getpt(tsbt);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.getkhach(khach);
                u.gethang(hang);

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
               
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập kho trước khi sửa."); }
        }

        public void tsbtpnkchuyen(string a, string donhang, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang, string tsbt)
        {
            try
            {
                Frm_phieunhapkho u = new Frm_phieunhapkho();
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getpt(tsbt);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.getkhach(khach);
                u.gethang(hang);
                u.getphieu(donhang);
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập kho trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, LookUpEdit lenv, DataTable khach, DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien)
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
            mahang.PopupWidth = 300;
           
            DataTable temp4 = new DataTable();
            temp4.Columns.Add("Mã nhân viên");
            temp4.Columns.Add("Tên nhân viên");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp4.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp4.Rows.Add(dr);
            }
            lenv.Properties.DataSource = temp4;
            lenv.Properties.DisplayMember = "Mã nhân viên";
            lenv.Properties.ValueMember = "Mã nhân viên";
            lenv.Properties.PopupWidth = 300;

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá phí", Type.GetType("System.Double"));
            dt.Columns.Add("Bốc xếp", Type.GetType("System.Double"));
            dt.Columns.Add("Diễn giải");
            dt.Columns.Add("Số lượng tồn", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi tồn", Type.GetType("System.Double"));
            gridControl1.DataSource = dt;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;

            gridView1.Columns["Bốc xếp"].ColumnEdit = thanhtien;
            gridView1.Columns["Đơn giá phí"].ColumnEdit = dongia;

            gridView1.Columns["Diễn giải"].Width = 300;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Đơn giá phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá phí"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Bốc xếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Bốc xếp"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Bốc xếp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Bốc xếp"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Số lượng tồn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng tồn"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng quy đổi tồn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng quy đổi tồn"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            gridView1.Columns[6].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[8].Visible = false;
        }

        public void loadpnk(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_phieunhapkho F, LookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, TextEdit txtptvc, LookUpEdit lenv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, CheckEdit cthg, CheckEdit chpck, string tsbt, CheckEdit chhtk, CheckEdit chtnm, CheckEdit chhgnb)
        {
            DataTable dt = new DataTable();

            cthg.Checked = false;
            chpck.Checked = false;
            chhtk.Checked = false;
            chhgnb.Checked = false;

            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, lenv, khach, hang, dongia, thanhtien);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  InventoryItemCode,InventoryItemName,Quantity,QuantityConvert,UnitPriceOC,UnitPriceConvert,Description,QuantityExits,QuantityConvertExits from INInwardDetailTT a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][1].ToString();
                    dr[2] = da.Rows[i][2].ToString();
                    dr[3] = da.Rows[i][3].ToString();
                    try
                    {
                        dr[4] = da.Rows[i][4].ToString();
                        dr[5] = da.Rows[i][5].ToString();
                    }
                    catch
                    {
                        dr[4] = 0;
                        dr[5] = 0;
                    }
                    dr[6] = da.Rows[i][6].ToString();
                    dr[7] = da.Rows[i][7].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                F.Text = "Xem phiếu nhập kho";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,EmployeeIDPU,RefType from INInwardTT a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
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
                txtctg.Text = da.Rows[0][3].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][6].ToString();
                txtngh.Text = da.Rows[0][1].ToString();
                txtptvc.Text = da.Rows[0][11].ToString();

                if (da.Rows[0][13].ToString() == "1")
                    cthg.Checked = true;
                else if (da.Rows[0][13].ToString() == "2")
                    chpck.Checked = true;
                else if (da.Rows[0][13].ToString() == "4")
                    chhtk.Checked = true;
                else if (da.Rows[0][13].ToString() == "5")
                    chtnm.Checked = true;
                else if (da.Rows[0][13].ToString() == "6")
                    chhgnb.Checked = true;

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
                try
                {
                    string px = gen.GetString("select RefID from PUInvoice where ShippingMethodID='" + role + "'");
                    tsbtsua.Enabled = false;
                    tsbtboghi.Enabled = false;
                }
                catch { }
                try
                {
                    string nv = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][12].ToString() + "'");
                    lenv.EditValue = nv;
                }
                catch
                {
                    lenv.EditValue = "3";
                }
                if (tsbt == "tsbtpxkhg")
                    checktruocsauxkhg(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
                else
                    checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                F.Text = "Thêm phiếu nhập kho";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                denht.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void checkpnk(string active, string role, Frm_phieunhapkho F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, LookUpEdit lenv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, CheckEdit cthg, CheckEdit chpck, string tsbt, CheckEdit chhtk, CheckEdit chtnm,CheckEdit chhgnb)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 10];
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
                    detail[i, 3] = gridView1.GetRowCellValue(i, "Diễn giải").ToString();

                    if (gridView1.GetRowCellValue(i, "Số lượng tồn").ToString() == "")
                        detail[i, 4] = "0";
                    else
                        detail[i, 4] = gridView1.GetRowCellValue(i, "Số lượng tồn").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi tồn").ToString() == "")
                        detail[i, 5] = "0";
                    else
                        detail[i, 5] = gridView1.GetRowCellValue(i, "Số lượng quy đổi tồn").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Đơn giá phí").ToString() == "")
                        detail[i, 6] = "0";
                    else
                        detail[i, 6] = gridView1.GetRowCellValue(i, "Đơn giá phí").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Bốc xếp").ToString() == "")
                        detail[i, 7] = "0";
                    else
                        detail[i, 7] = gridView1.GetRowCellValue(i, "Bốc xếp").ToString().Replace(".", "").Replace(",", ".");
                }
                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string ldt;
                    string hanggui = "0";
                    if (cthg.Checked == true)
                        hanggui = "1";
                    else if (chpck.Checked == true)
                        hanggui = "2";
                    else if (chhtk.Checked == true)
                        hanggui = "4";
                    else if (chtnm.Checked == true)
                        hanggui = "5";
                    else if (chhgnb.Checked == true)
                        hanggui = "6";
                    if (tsbt == "tsbtpxkhg" && chhtk.Checked == false && chtnm.Checked == false)
                        hanggui = "3";

                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";

                    string nv = "";
                    try
                    {
                        nv = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + lenv.EditValue.ToString() + "'");
                    }
                    catch { }

                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from INInwardTT where RefNo='" + txtsct.Text + "'");
                            if (tsbt == "tsbtpxkhg")
                                themsctxkhg(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            else
                                themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        try
                        {
                            gen.ExcuteNonquery("insert into INInwardTT(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,EmployeeID,EmployeeIDPU) values(newid(),'" + hanggui + "','" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + userid + "','" + nv + "')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into INInwardTT(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,EmployeeID) values(newid(),'" + hanggui + "','" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + userid + "')");
                        }
                        string refid = gen.GetString("select * from INInwardTT where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        F.getactive("1");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INInwardDetailTT(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvert) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "',0,0,'" + detail[i, 6] + "','" + detail[i, 7] + "')");
                        }
                    }
                    else
                    {
                        try
                        {
                            gen.ExcuteNonquery("update INInwardTT set RefNo='" + txtsct.Text + "', RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',EmployeeID='" + userid + "',EmployeeIDPU='" + nv + "',RefType='" + hanggui + "'   where RefID='" + role + "'");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("update INInwardTT set RefNo='" + txtsct.Text + "', RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',EmployeeID='" + userid + "',EmployeeIDPU=Null,RefType='" + hanggui + "'  where RefID='" + role + "'");
                        }
                        gen.ExcuteNonquery("delete  from  INInwardDetailTT where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INInwardDetailTT(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvert) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "')");
                        }

                        Double ton = 0;
                        try
                        {
                            ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INInwardDetailTT where RefID='" + role + "'"));
                        }
                        catch { }
                        if (ton == 0)
                            gen.ExcuteNonquery("update INInwardTT set IsExport='True' where RefID='" + role + "'");
                        else
                            gen.ExcuteNonquery("update INInwardTT set IsExport='False' where RefID='" + role + "'");
                    }
                    F.getactive("1");
                    F.Text = "Xem phiếu nhập kho";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void themsct(string ngaychungtu, TextEdit txtsct, string mk, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            //string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + gen.GetString("select BranchID from Stock where StockCode='" + mk + "'") + "'");
            string idkho = gen.GetString("select StockID from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PNTT";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INInwardTT where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "' and RefType<>'3'  order by RefNo DESC");
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

        public void themsctxkhg(string ngaychungtu, TextEdit txtsct, string mk, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            //string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + gen.GetString("select BranchID from Stock where StockCode='" + mk + "'") + "'");
            string idkho = gen.GetString("select StockID from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PXHG";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INInwardTT where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "' and RefType='3'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtsct.Text = sophieu;            
            checktruocsauxkhg(tsbttruoc, tsbtsau, mk, sophieu, ngaychungtu);
        }

        public void tsbtdeletepnk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                try
                {
                    Double temp = Double.Parse(gen.GetString("select sum(QuantityConvertExits) as QuantityConvertExits  from  INInwardDetailTT where RefID= '" + name + "'"));
                    if (temp != 0)
                    {
                        XtraMessageBox.Show("Một phần phiếu đã được xuất hóa đơn bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu xuất kho " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            gen.ExcuteNonquery("delete from INInwardTT where RefID='" + name + "'");
                            gen.ExcuteNonquery("delete from INInwardDetailTT where RefID='" + name + "'");
                            view.DeleteRow(view.FocusedRowHandle);
                        }
                    }
                }
                catch
                {
                    if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu xuất kho " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        gen.ExcuteNonquery("delete from INInwardTT where RefID='" + name + "'");
                    }
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapkho F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INInwardTT where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  and RefType<>'3' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INInwardTT where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  and RefType<>'3' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapkho F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INInwardTT where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  and RefType<>'3'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INInwardTT where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  and RefType<>'3' order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from INInwardTT where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and RefType<>'3' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INInwardTT where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'  and RefType<>'3' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }



        public void checktruocxkhg(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapkho F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INInwardTT where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  and RefType='3' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INInwardTT where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  and RefType='3' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksauxkhg(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapkho F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INInwardTT where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  and RefType='3'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INInwardTT where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  and RefType='3' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }

        public void checktruocsauxkhg(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from INInwardTT where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and RefType='3' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INInwardTT where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'  and RefType='3' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

    }
}
