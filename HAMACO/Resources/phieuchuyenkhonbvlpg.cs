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
    class phieuchuyenkhonbvlpg
    {
        gencon gen = new gencon();
        public void loadpck(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
            dt.Columns.Add("Mã kho nhận", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho nhận", Type.GetType("System.String"));
            dt.Columns.Add("Chứng từ nhận", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Đã nhận", Type.GetType("System.Boolean"));
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
                dr[9] = temp.Rows[i][9].ToString();
                if (temp.Rows[i][10].ToString() == "1")
                    dr[10] = "True";
                else
                    dr[10] = "False";
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

            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Mã kho nhận"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã kho nhận"].Caption = "Kho nhận";
            view.Columns["Mã kho nhận"].Width = 50;
            view.Columns["Đã nhận"].Width = 50;
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void tsbtpck(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid,string subsys,string ngaychungtu, string userid, string branchid,string tsbt,DataTable khach,DataTable hang)
        {
            try
            {
            Frm_chuyenkhonb u = new Frm_chuyenkhonb();
            u.myac = new Frm_chuyenkhonb.ac(F.refreshcknbvlpg);
            u.getactive(a);
            u.getroleid(roleid);
            u.getkhach(khach);
            u.gethang(hang);
            u.getsub(subsys);
            if (tsbt == "tsbtpncknbvlpg")
                u.getpt(tsbt);
            else
                u.getpt("pckv");
            u.getdate(ngaychungtu);
            u.getuser(userid);
            u.getbranch(branchid);
            
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
            catch { MessageBox.Show("Vui lòng chọn phiếu xuất chuyển kho nội bộ vỏ LPG trước khi sửa."); }
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
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Đã nhận", Type.GetType("System.Boolean"));
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
                dr[9] = temp.Rows[i][9].ToString();
                if (temp.Rows[i][10].ToString() == "1")
                    dr[10] = "True";
                else
                    dr[10] = "False";
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

            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Mã kho xuất"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã kho xuất"].Caption = "Kho xuất";
            view.Columns["Mã kho xuất"].Width = 50;
            view.Columns["Đã nhận"].Width = 50;
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

       

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, LookUpEdit ledvn, LookUpEdit ledv, LookUpEdit ledt, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, TextEdit txtnhd,DataTable khach,DataTable hang)
        {
           
            DataTable da = new DataTable();
            DataTable temp = new DataTable();
            DataTable temp1 = new DataTable();
            DataTable temp2 = new DataTable();

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
            ledvn.Properties.DataSource = temp1;
            ledvn.Properties.DisplayMember = "Mã kho";
            ledvn.Properties.ValueMember = "Mã kho";
            ledvn.ItemIndex = 0;
            ledvn.Properties.PopupWidth = 300;

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
            ledt.Properties.ValueMember = "Mã đối tượng";*/

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


            /*da = gen.GetTable("select InventoryItemCode,InventoryItemName from InventoryItem where Parent is not Null order by InventoryItemCode");
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
            mahang.ValueMember = "Mã hàng";*/
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

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
           
            dt.Columns.Add("Đơn giá phí", Type.GetType("System.Double"));
            dt.Columns.Add("Bốc xếp", Type.GetType("System.Double"));

            dt.Columns.Add("Diễn giải");

            dt.Columns.Add("Đơn giá xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Bốc xếp xuất", Type.GetType("System.Double"));



            gridControl1.DataSource = dt;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;

            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;

            gridView1.Columns["Đơn giá phí"].ColumnEdit = dongia;
            gridView1.Columns["Bốc xếp"].ColumnEdit = thanhtien;

            gridView1.Columns["Đơn giá xuất"].ColumnEdit = dongia;
            gridView1.Columns["Bốc xếp xuất"].ColumnEdit = thanhtien;

            gridView1.Columns["Đơn giá phí"].Caption = "Đơn giá nhập";
            gridView1.Columns["Bốc xếp"].Caption = "Bốc xếp nhập";
            gridView1.Columns["Đơn giá phí"].ColumnEdit = dongia;
            gridView1.Columns["Bốc xếp"].ColumnEdit = thanhtien;
           
            gridView1.Columns["Diễn giải"].Width = 300;
            gridView1.Columns["Diễn giải"].Visible = false;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Đơn giá phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá phí"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Bốc xếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Bốc xếp"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Đơn giá xuất"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá xuất"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Bốc xếp xuất"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Bốc xếp xuất"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

        }

        public void loadpck(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit ledvn, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_chuyenkhonb F, LookUpEdit ledt, TextEdit txtldn,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, TextEdit txtptvc, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, TextEdit txtpnv, TextEdit txtcth, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, TextEdit txtnhd, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,string pt,DataTable khach,DataTable hang, CheckEdit nhan,TextEdit txtgiaonhan,TextEdit txttaixe)
        {
            DataTable dt = new DataTable();
            loadstart(gridControl1, gridView1, ledvn, ledv, ledt, denct, denht, mahang, soluong, soluongqd, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dongia, thanhtien, chiphi, txtnhd,khach,hang);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  InventoryItemCode,Quantity,Description,InventoryItemName,a.UnitPrice,a.Amount,a.UnitPriceConvertOC,a.AmountOC,UnitPriceOC,UnitPriceConvert from INTransferSUDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][3].ToString();
                    dr[2] = da.Rows[i][1].ToString();
                    dr[3] = da.Rows[i][4].ToString();
                    dr[4] = da.Rows[i][5].ToString();
                    dr[7] = da.Rows[i][2].ToString();

                    if (da.Rows[i][6].ToString() != "")
                        dr[5] = da.Rows[i][6].ToString();
                    if (da.Rows[i][7].ToString() != "")
                        dr[6] = da.Rows[i][7].ToString();
                    if (da.Rows[i][8].ToString() != "")
                        dr[8] = da.Rows[i][8].ToString();
                    else
                        dr[8] = "0";
                    if (da.Rows[i][9].ToString() != "")
                        dr[9] = da.Rows[i][9].ToString();
                    else
                        dr[9] = "0";

                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;

                tsbtcat.Enabled = false;

                F.Text = "Xem phiếu xuất chuyển kho nội bộ vỏ LPG";

                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,InvSeries,RefDate,PostedDate,RefNo,OutwardStockID,Posted,InvNo,Cancel,ShippingNo,RefNoIn,InwardStockID,No,InvDate,PostVersion,a.CustomField1,a.CustomField2  from INTransferSU a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID  and RefID='" + role + "'");

                string kho = gen.GetString("select StockCode from Stock where StockID='" + da.Rows[0][7].ToString() + "'");
                string khon = gen.GetString("select StockCode from Stock where StockID='" + da.Rows[0][13].ToString() + "'");
                ledvn.EditValue = khon;
                ledv.EditValue = kho;
                ledt.EditValue = da.Rows[0][0].ToString();
                txtldn.Text = da.Rows[0][2].ToString();

                txtshd.Text = da.Rows[0][9].ToString();
                txtkhhd.Text = da.Rows[0][3].ToString();
                txtms.Text = da.Rows[0][14].ToString();
                txtnhd.EditValue = DateTime.Parse(da.Rows[0][15].ToString());

                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][6].ToString();
                txtpnv.Text = da.Rows[0][12].ToString();
                txtngh.Text = da.Rows[0][1].ToString();
                txtptvc.Text = da.Rows[0][11].ToString();
                txtgiaonhan.Text = da.Rows[0][16].ToString();
                txttaixe.Text = da.Rows[0][17].ToString();
                if (da.Rows[0][8].ToString() == "True")
                {
                    tsbtghiso.Visible = false;
                    tsbtboghi.Visible = true;
                    tsbtsua.Enabled = false;
                    nhan.Enabled = false;
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

                if (da.Rows[0][16].ToString() == "1")
                    nhan.Checked = true;
                else
                    nhan.Checked = false;

                Double tongthanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                txtcth.Text = String.Format("{0:n0}", tongthanhtien);

                if (pt == "tsbtpncknbvlpg")
                    checktruocsaunhap(tsbttruoc, tsbtsau, ledvn.EditValue.ToString(), txtpnv.Text, ngaychungtu);
                else
                    checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                F.Text = "Thêm phiếu xuất chuyển kho nội bộ vỏ LPG";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                denht.EditValue = DateTime.Parse(ngaychungtu);
                txtnhd.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
                nhan.Checked = false;
            }
        }

        public void checkpck(string active, string role, Frm_chuyenkhonb F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, LookUpEdit ledvn, TextEdit txtsct, TextEdit txtname, TextEdit txtngh, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtptvc, string userid, string branchid, TextEdit txtpnv, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd, TextEdit txtnhd, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,string bat,TextEdit txtgiaonhan,TextEdit txttaixe)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 12];
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
                        detail[i, 1] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                    detail[i, 2] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        detail[i, 4] = "0";
                    else
                        detail[i, 4] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        detail[i, 5] = "0";
                    else
                        detail[i, 5] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    detail[i, 3] = gridView1.GetRowCellValue(i, "Diễn giải").ToString();

                    if (gridView1.GetRowCellValue(i, "Đơn giá phí").ToString() == "")
                        detail[i, 6] = "0";
                    else detail[i, 6] = gridView1.GetRowCellValue(i, "Đơn giá phí").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Bốc xếp").ToString() == "")
                        detail[i, 7] = "0";
                    else detail[i, 7] = gridView1.GetRowCellValue(i, "Bốc xếp").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Đơn giá xuất").ToString() == "")
                        detail[i, 8] = "0";
                    else detail[i, 8] = gridView1.GetRowCellValue(i, "Đơn giá xuất").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Bốc xếp xuất").ToString() == "")
                        detail[i, 9] = "0";
                    else detail[i, 9] = gridView1.GetRowCellValue(i, "Bốc xếp xuất").ToString().Replace(".", "").Replace(",", ".");
                }

                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> <Đơn giá> <Thành tiền> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string dvn = gen.GetString("select * from Stock where StockCode='" + ledvn.EditValue.ToString() + "'");
                    string tongtien = gridView1.Columns["Thành tiền"].SummaryText.Replace(".", "");
                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from INTransferSU where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }

                        try
                        {
                            string ton = gen.GetString("select * from INTransferSU where RefNoIn='" + txtpnv.Text + "'");
                            themsctn(ngaychungtu, txtpnv, ledvn.EditValue.ToString());
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu nhập của bạn thành " + txtpnv.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }

                        gen.ExcuteNonquery("insert into INTransferSU(RefID,RefType,RefDate,PostedDate,RefNo,RefNoIn,AccountingObjectID,AccountingObjectName,Contactname,JournalMemo,Posted,OutwardStockID,InwardStockID,ShippingNo,TotalAmount,No,InvSeries,InvNo,InvDate,UserID,CustomField1,CustomField2) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + txtpnv.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + dvn + "','" + txtptvc.Text + "','" + tongtien + "','" + txtms.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "','" + txtnhd.EditValue.ToString() + "','" + userid + "',N'" + txtgiaonhan.Text + "',N'" + txttaixe.Text + "')");
                        string refid = gen.GetString("select * from INTransferSU where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        if (DateTime.Parse(ngaychungtu) < DateTime.Parse("09/01/2017"))
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','336','1563','" + tongtien + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtpnv.Text + "','1563','336','" + tongtien + "','" + dt + "','" + dvn + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        }
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INTransferSUDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,UnitPrice,Amount,UnitPriceConvertOC,AmountOC,UnitPriceOC,UnitPriceConvert) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "')");
                        }

                    }
                    else
                    {
                        if (bat == "1")
                        {
                            try
                            {
                                string ton = gen.GetString("select * from INTransferSU where RefNoIn='" + txtpnv.Text + "'");
                                themsctn(ngaychungtu, txtpnv, ledvn.EditValue.ToString());
                                XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu nhập của bạn thành " + txtpnv.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch { }
                        }
                        gen.ExcuteNonquery("update INTransferSU set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',RefNoIn='" + txtpnv.Text + "',InwardStockID='" + dvn + "',Posted='False',ShippingNo='" + txtptvc.Text + "',TotalAmount='" + tongtien + "',No='" + txtms.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',InvDate='" + txtnhd.EditValue.ToString() + "',UserID='" + userid + "',CustomField1=N'" + txtgiaonhan.Text + "',CustomField2=N'" + txttaixe.Text + "'  where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  INTransferSUDetail where RefID='" + role + "'");                       
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        if (DateTime.Parse(ngaychungtu) < DateTime.Parse("09/01/2017"))
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','336','1563','" + tongtien + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtpnv.Text + "','1563','336','" + tongtien + "','" + dt + "','" + dvn + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        }
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INTransferSUDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,UnitPrice,Amount,UnitPriceConvertOC,AmountOC,UnitPriceOC,UnitPriceConvert) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "')");
                        }

                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu xuất chuyển kho vỏ LPG";
                }

            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*public void themsct(string ngaychungtu, TextEdit txtsct, string ledv, string ledvn, TextEdit txtpnv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkho = gen.GetString("select * from Stock where StockCode='" + ledv + "'");
            string idkhon = gen.GetString("select * from Stock where StockCode='" + ledvn + "'");
            string dv = gen.GetString("select BranchCode from Branch a, Stock b where a.BranchID=b.BranchID and b.StockCode='" + ledv + "'");
            string dvn = gen.GetString("select BranchCode from Branch a, Stock b where a.BranchID=b.BranchID and b.StockCode='" + ledvn + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = dv + "-" + ledv + "-XKVT";
            string sophieuvo = dvn + "-" + ledvn + "-NKVT";
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from INTransferSU where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID='" + idkho + "'  order by RefNo DESC");
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
                    string id = gen.GetString("select Top 1 RefNoIn from INTransferSU where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID='" + idkhon + "'  order by RefNoIn DESC");
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
            checktruocsau(tsbttruoc, tsbtsau, ledv, sophieu, ngaychungtu);
        }*/

        public void themsct(string ngaychungtu, TextEdit txtsct, string ledv,ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkho = gen.GetString("select * from Stock where StockCode='" + ledv + "'");
            string dv = gen.GetString("select BranchCode from Branch a, Stock b where a.BranchID=b.BranchID and b.StockCode='" + ledv + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = dv + "-" + ledv + "-XKVT";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INTransferSU where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, ledv, sophieu, ngaychungtu);
        }

        public void themsctn(string ngaychungtu, TextEdit txtsctn, string ledvn)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkhon = gen.GetString("select * from Stock where StockCode='" + ledvn + "'");
            string dvn = gen.GetString("select BranchCode from Branch a, Stock b where a.BranchID=b.BranchID and b.StockCode='" + ledvn + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieuvo = dvn + "-" + ledvn + "-NKVT";

            try
            {
                string id = gen.GetString("select Top 1 RefNoIn from INTransferSU where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID='" + idkhon + "'  order by RefNoIn DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieuvo = sophieuvo + "0";
                }
                sophieuvo = sophieuvo + ct.ToString() + nam;
            }
            catch { sophieuvo = sophieuvo + "00001" + nam; }
            txtsctn.Text = sophieuvo;
        }

        public void tsbtdeletepnk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from INTransferSU where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu xuất chuyển kho nội bộ vỏ LPG" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from INTransferSU where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from INTransferSUDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                    /*gen.ExcuteNonquery("update BADeposit set Cancel='True',Posted='True' where RefID='" + name + "'");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Hủy"], "True");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số tiền"], "0");*/
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu xuất chuyển kho vỏ LPG trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_chuyenkhonb F, string ngay, string mk,string pt)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    if (pt == "tsbtpncknbvlpg")
                        id = gen.GetString("select Top 1 * from INTransferSU where RefNoIn < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and InwardStockID='" + idkho + "' order by RefNoIn DESC");
                    else
                        id = gen.GetString("select Top 1 * from INTransferSU where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and OutwardStockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    if (pt == "tsbtpncknbvlpg")
                        id = gen.GetString("select Top 1 * from INTransferSU where RefNoIn < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and InwardStockID='" + idkho + "' order by RefNoIn ASC");
                    else
                        id = gen.GetString("select Top 1 * from INTransferSU where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and OutwardStockID='" + idkho + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_chuyenkhonb F, string ngay, string mk,string pt)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    if(pt=="tsbtpncknbvlpg")
                        id = gen.GetString("select Top 1 * from INTransferSU where RefNoIn > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and InwardStockID='" + idkho + "'  order by RefNoIn ASC");
                    else
                        id = gen.GetString("select Top 1 * from INTransferSU where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and OutwardStockID='" + idkho + "'  order by RefNo ASC");
                else
                {
                    if (pt == "tsbtpncknbvlpg")
                        id = gen.GetString("select Top 1 * from INTransferSU where RefNoIn > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and InwardStockID='" + idkho + "' order by RefNoIn DESC");
                    else
                        id = gen.GetString("select Top 1 * from INTransferSU where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and OutwardStockID='" + idkho + "' order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from INTransferSU where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INTransferSU where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checktruocsaunhap(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from INTransferSU where RefNoIn > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INTransferSU where RefNoIn < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
