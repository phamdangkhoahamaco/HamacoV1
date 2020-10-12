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
    class phieuxuatgas
    {
        gencon gen = new gencon();
        public void loadpxk(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
            dt.Columns.Add("Chứng từ vỏ", Type.GetType("System.String"));
            dt.Columns.Add("Hủy", Type.GetType("System.Boolean"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][4].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][6].ToString();
                dr[5] = temp.Rows[i][9].ToString();
                try
                {
                    dr[6] = gen.GetString("select a.refNo from INOutwardSU a, INOutward b where b.RefID='" + temp.Rows[i][0].ToString() + "' and a.RefID=b.refSUID");
                }
                catch { }
                if (temp.Rows[i][42].ToString() == "True")
                    dr[7] = "True";
                else
                    dr[7] = "False";

                dr[8] = gen.GetString("select StockCode from Stock where StockID='" + temp.Rows[i][22].ToString() + "'");
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

        public void tsbtpxk(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid,string subsys,string ngaychungtu, string userid, string branchid)
        {
            try
            {
            Frm_phieunhapgas u = new Frm_phieunhapgas();
            u.myac = new Frm_phieunhapgas.ac(F.refreshpxkgas);
            u.getactive(a);
            u.getroleid(roleid);
            u.getsub(subsys);
            u.getpt("pxk");
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
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập kho Gas trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DataTable dt1, DevExpress.XtraGrid.GridControl gridControl2, GridView gridView2,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, ComboBoxEdit cbthue, LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau)
        {
            cbldt.Properties.Items.Clear();
            cbldt.Properties.Items.Add("Khách hàng");
            cbldt.Properties.Items.Add("Nhà cung cấp");
            cbldt.Properties.Items.Add("Nhân viên");
            cbldt.SelectedIndex = 0;

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            DataTable da = new DataTable();
            DataTable temp = new DataTable();

            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            da = gen.GetTable("select * from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockID");
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
            lenv.Properties.PopupWidth = 300;


            da = gen.GetTable("select InventoryItemCode,InventoryItemName from InventoryItem where InventoryItemID in (select Parent from InventoryItem ) order by InventoryItemCode");
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

            da = gen.GetTable("select AccountingObjectCode,AccountingObjectName from AccountingObject a, Branch b where a.BranchID=b.BranchID and b.BranchID='" + branchid + "' and IsEmployee='True' order by AccountingObjectCode");
            DataTable temp4 = new DataTable();
            temp4.Columns.Add("Mã nhân viên");
            temp4.Columns.Add("Tên nhân viên");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp4.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
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
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền CK", Type.GetType("System.Double"));
            gridControl1.DataSource = dt;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Chi phí"].ColumnEdit = chiphi;
            gridView1.Columns["Chiết khấu"].ColumnEdit = chietkhau;

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Đơn giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
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

            gridView1.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Tiền CK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Tiền CK"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Tiền CK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Tiền CK"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Tiền CK"].OptionsColumn.AllowEdit = false;


            dt1.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt1.Columns.Add("Tên hàng");
            dt1.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt1.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt1.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt1.Columns.Add("Diễn giải");
            gridControl2.DataSource = dt1;
            gridView2.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView2.Columns["Thành tiền"].ColumnEdit = thanhtien;

            gridView2.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView2.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView2.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            gridView2.Columns["Đơn giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Đơn giá"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView2.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView2.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView2.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView2.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            gridView2.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["Số lượng"].OptionsColumn.AllowEdit = false;


        }

        public void loadpxk(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_phieunhapgas F, LookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, TextEdit txtptvc, DevExpress.XtraGrid.GridControl gridControl2, GridView gridView2, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, TextEdit txtpnv, ComboBoxEdit cbthue, TextEdit txtcth, LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau, TextEdit txtck, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dt1, gridControl2, gridView2, dongia, thanhtien,cbthue,lenv,chiphi,chietkhau);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  InventoryItemCode,Quantity,QuantityConvert,DiscountRate,InventoryItemName,a.UnitPrice,a.Amount,Cost,DiscountAmount from INOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][4].ToString();
                    dr[2] = da.Rows[i][1].ToString();
                    dr[3] = da.Rows[i][2].ToString();
                    dr[4] = da.Rows[i][5].ToString();
                    dr[5] = da.Rows[i][6].ToString();
                    dr[6] = da.Rows[i][7].ToString();
                    dr[7] = da.Rows[i][3].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;

                da = gen.GetTable("select  InventoryItemCode,Quantity,QuantityConvert,Description,InventoryItemName,a.UnitPrice,a.Amount from INOutwardSUDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID in (select refSUID from INOutward where refID='" + role + "') order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt1.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][4].ToString();
                    dr[2] = da.Rows[i][1].ToString();
                    dr[3] = da.Rows[i][5].ToString();
                    dr[4] = da.Rows[i][6].ToString();
                    dr[5] = da.Rows[i][3].ToString();
                    dt1.Rows.Add(dr);
                }
                gridControl2.DataSource = dt1;

                tsbtcat.Enabled = false;

                F.Text = "Xem phiếu xuất kho LPG";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,Tax,EmployeeIDSA  from INOutward a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                string No = gen.GetString("select a.refNo from INOutwardSU a, INOutward b where b.RefID='" + role + "' and a.RefID=b.refSUID");
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
                txtpnv.Text = No;
                txtngh.Text = da.Rows[0][1].ToString();
                txtptvc.Text = da.Rows[0][11].ToString();
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
                    cbthue.Text = da.Rows[0][12].ToString();
                }
                catch { }
          
                txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView1.Columns["Thành tiền"].SummaryText) + Double.Parse(gridView1.Columns["Chi phí"].SummaryText));
                txtck.Text = gridView1.Columns["Tiền CK"].SummaryText;
                try
                {
                    string nv = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][13].ToString() + "'");
                    lenv.EditValue = nv;
                }
                catch
                {
                    lenv.EditValue = "3";
                }
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                F.Text = "Thêm phiếu xuất kho LPG";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                denht.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void checkpxk(string active, string role, Frm_phieunhapgas F, GridView gridView1, GridView gridView2, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, TextEdit txtpnv, ComboBoxEdit cbthue, LookUpEdit lenv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 8];
                string[,] detail1 = new string[20, 8];
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
                    detail[i, 6] = gridView1.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Chiết khấu").ToString() == "")
                        detail[i, 3] = "0";
                    else
                        detail[i, 3] = gridView1.GetRowCellValue(i, "Chiết khấu").ToString();
                    if (gridView1.GetRowCellValue(i, "Tiền CK").ToString() == "")
                        detail[i, 7] = "0";
                    else
                        detail[i, 7] = gridView1.GetRowCellValue(i, "Tiền CK").ToString();
                }


                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "Mã hàng").ToString() == "")
                        check = "1";
                    else
                    {
                        string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView2.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        detail1[i, 0] = mh;
                    }
                    if (gridView2.GetRowCellValue(i, "Số lượng").ToString() == "")
                        check = "1";
                    detail1[i, 1] = gridView2.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                    detail1[i, 2] = gridView2.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                    detail1[i, 3] = gridView2.GetRowCellValue(i, "Diễn giải").ToString();

                    if (gridView2.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail1[i, 4] = gridView2.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "");
                    if (gridView2.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail1[i, 5] = gridView2.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                }

                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> <Đơn giá> <Thành tiền> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";
                    string tongtien = gridView2.Columns["Thành tiền"].SummaryText.Replace(".", "");

                    string tongthanhtien = gridView1.Columns["Thành tiền"].SummaryText;
                    string tongchiphi = gridView1.Columns["Tiền CK"].SummaryText;
                    tongthanhtien = tongthanhtien.Replace(".", "");
                    tongchiphi = tongchiphi.Replace(".", "");

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
                            string ton = gen.GetString("select * from INOutward where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, txtpnv,tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        try
                        {
                            string ton = gen.GetString("select * from INOutwardSU where RefNo='" + txtpnv.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, txtpnv,tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtpnv.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }

                        try
                        {
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + nv + "','" + tongchiphi + "','" + tongthanhtien + "')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tongchiphi + "','" + tongthanhtien + "')");
                        }
                        string refid = gen.GetString("select * from INOutward where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "',0,0,'" + detail[i, 6] + "','" + detail[i, 7] + "')");
                        }

                        gen.ExcuteNonquery("insert into INOutwardSU(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,TotalAmount,UserID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtpnv.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + tongtien + "','"+userid+"')");
                        string id = gen.GetString("select * from INOutwardSU where RefNo='" + txtpnv.Text + "'");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + id + "','" + txtsct.Text + "','1313','1563','" + tongtien + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','"+dt+"')");
                        gen.ExcuteNonquery("update INOutward set refSUID='" + id + "' where refID='" + refid + "' ");
                        for (int i = 0; i < gridView2.RowCount; i++)
                        {
                            gen.ExcuteNonquery("insert into INOutwardSUDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,QuantityExits,QuantityConvertExits,UnitPrice,Amount,DebitAccount,CreditAccount) values(newid(),'" + id + "','" + detail1[i, 1] + "','" + detail1[i, 2] + "'," + i + ",'" + detail1[i, 0] + "',N'" + detail1[i, 3] + "',0,0,'" + detail1[i, 4] + "','" + detail1[i, 5] + "','1313','1563')");
                        }

                    }
                    else
                    {
                        try
                        {
                            gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA='" + nv + "',TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "'  where RefID='" + role + "'");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "'  where RefID='" + role + "'");
                        }
                        gen.ExcuteNonquery("delete  from  INOutwardDetail where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "',0,0,'" + detail[i, 6] + "','" + detail[i, 7] + "')");
                        }

                        string id = gen.GetString("select refSUID from INOutward where refID='" + role + "'");
                        gen.ExcuteNonquery("update INOutwardSU set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',TotalAmount='" + tongtien + "',UserID='"+userid+"'  where RefID = '" + id + "'");
                        gen.ExcuteNonquery("delete  from  INOutwardSUDetail where RefID ='" + id + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + id + "'");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + id + "','" + txtsct.Text + "','1313','1563','" + tongtien + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','"+dt+"')");
                        for (int i = 0; i < gridView2.RowCount; i++)
                        {
                            gen.ExcuteNonquery("insert into INOutwardSUDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,QuantityExits,QuantityConvertExits,UnitPrice,Amount,DebitAccount,CreditAccount) values(newid(),'" + id + "','" + detail1[i, 1] + "','" + detail1[i, 2] + "'," + i + ",'" + detail1[i, 0] + "',N'" + detail1[i, 3] + "',0,0,'" + detail1[i, 4] + "','" + detail1[i, 5] + "','1313','1563')");
                        }

                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu nhập kho Gas";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void themsct(string ngaychungtu, TextEdit txtsct, string mk, string branchid, TextEdit txtpnv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PXKH";
            string sophieuvo = branch + "-" + mk + "-PXVT";
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                    int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                    for (int i = 0; i < dai - ct.ToString().Length; i++)
                    {
                        sophieu = sophieu + "0";
                    }
                    sophieu = sophieu + ct.ToString() + nam;
                }
                catch { sophieu = sophieu + "00001" + nam; }

                try
                {
                    string id = gen.GetString("select Top 1 RefNo from INOutwardSU where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                    int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                    for (int i = 0; i < dai - ct.ToString().Length; i++)
                    {
                        sophieuvo = sophieuvo + "0";
                    }
                    sophieuvo = sophieuvo + ct.ToString() + nam;
                }
                catch { sophieuvo = sophieuvo + "00001" + nam; }
            txtsct.Text = sophieu;
            txtpnv.Text = sophieuvo;
            checktruocsau(tsbttruoc, tsbtsau, mk, sophieu, ngaychungtu);
        }

        public void tsbtdeletepnk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from INOutward where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu nhập kho " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string id = gen.GetString("select refSUID from INOutward where refID='" + name + "'");
                    gen.ExcuteNonquery("delete from INOutwardSUDetail where RefID='" + id + "'");
                    gen.ExcuteNonquery("delete from INOutwardSU where RefID='" + id + "'");                    
                    gen.ExcuteNonquery("delete HACHTOAN where RefID='" + id + "'");
                    gen.ExcuteNonquery("delete from INOutwardDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from INOutward where RefID='" + name + "'");                    
                    gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");                    
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu nhập kho trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapgas F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and refSUID is not Null and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and refSUID is not Null and StockID='" + idkho + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapgas F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and refSUID is not Null and StockID='" + idkho + "'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and refSUID is not Null and StockID='" + idkho + "' order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and refSUID is not Null and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and refSUID is not Null and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
