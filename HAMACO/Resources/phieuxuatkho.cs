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
    class phieuxuatkho
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
            dt.Columns.Add("Thuế", Type.GetType("System.String"));
            dt.Columns.Add("Tổng tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.Boolean"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Hủy", Type.GetType("System.Boolean"));
            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Người duyệt", Type.GetType("System.String"));
            dt.Columns.Add("Hạch toán", Type.GetType("System.String"));
            dt.Columns.Add("Đơn hàng", Type.GetType("System.String"));
            dt.Columns.Add("Người lập", Type.GetType("System.String"));
            dt.Columns.Add("User", Type.GetType("System.String"));
            dt.Columns.Add("Nhân viên", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên", Type.GetType("System.String"));
            dt.Columns.Add("Chọn", Type.GetType("System.Boolean"));
            /*dt.Columns.Add("Thanh toán", Type.GetType("System.Double"));
            dt.Columns.Add("Bù", Type.GetType("System.Double"));
            dt.Columns.Add("Giao", Type.GetType("System.Boolean"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));*/

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dr[6] = temp.Rows[i][9].ToString();
                /*try
                {*/
                if (temp.Rows[i][10].ToString() != "")
                    dr[7] = temp.Rows[i][10].ToString();
                /*}
                catch { }*/
         

                dr[8] = temp.Rows[i][18].ToString();

                if (temp.Rows[i][6].ToString() == "True")
                    dr[9] = "True";
                else
                    dr[9] = "False";

                dr[10] = temp.Rows[i][8].ToString();

                if (temp.Rows[i][7].ToString() == "True")
                    dr[11] = "True";
                else
                    dr[11] = "False";              
                
                
                dr[12] = temp.Rows[i][11].ToString();
                dr[13] = temp.Rows[i][12].ToString();
                dr[14] = temp.Rows[i][13].ToString();
                /*try
                {*/
                if (temp.Rows[i][14].ToString() != "")
                    if (DateTime.Parse(temp.Rows[i][14].ToString()).Hour >= 15)
                        dr[15] = "1";
                /*}
                catch { }*/
                dr[16] = temp.Rows[i][15].ToString();
                dr[17] = temp.Rows[i][16].ToString();
                dr[18] = temp.Rows[i][17].ToString();
                dr[19] = temp.Rows[i][20].ToString();
                dr[20] = temp.Rows[i][21].ToString();
                /*if (temp.Rows[i][22].ToString() != "")                   
                        dr[22] = temp.Rows[i][22].ToString();
                if (temp.Rows[i][23].ToString() != "")
                        dr[23] = temp.Rows[i][23].ToString();
                if (temp.Rows[i][24].ToString() == "1")
                    dr[24] = "True";
                dr[25] = temp.Rows[i][25].ToString();*/
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = true;
            view.Columns[1].OptionsColumn.AllowEdit = false;
            view.Columns[2].OptionsColumn.AllowEdit = false;
            view.Columns[3].OptionsColumn.AllowEdit = false;
            view.Columns[4].OptionsColumn.AllowEdit = false;
            view.Columns[5].OptionsColumn.AllowEdit = false;
            view.Columns[6].OptionsColumn.AllowEdit = false;
            view.Columns[7].OptionsColumn.AllowEdit = false;
            view.Columns[8].OptionsColumn.AllowEdit = false;
            view.Columns[9].OptionsColumn.AllowEdit = false;
            view.Columns[12].OptionsColumn.AllowEdit = false;
            view.Columns[13].OptionsColumn.AllowEdit = false;
            view.Columns[14].OptionsColumn.AllowEdit = false;
            view.Columns[15].OptionsColumn.AllowEdit = false;
            view.Columns[16].OptionsColumn.AllowEdit = false;
            view.Columns[17].OptionsColumn.AllowEdit = false;
            view.Columns[18].OptionsColumn.AllowEdit = false;
            view.Columns[19].OptionsColumn.AllowEdit = false;
            view.Columns[20].OptionsColumn.AllowEdit = false;
            //view.Columns[22].ColumnEdit = thanhtien;
            //view.OptionsSelection.EnableAppearanceFocusedCell = false;
            //view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            
            view.Columns[0].Visible = false;
            view.Columns[11].Visible = false;
            view.Columns[14].Visible = false;
            view.Columns[15].Visible = false;
            view.Columns[16].Visible = false;
            view.Columns[18].Visible = false;
            view.Columns["Chọn"].Visible = false;
            //view.Columns["Thanh toán"].Visible = false;
            //view.Columns["Bù"].Visible = false;
            //view.Columns["Ghi chú"].Visible = false;
            //view.Columns["Giao"].Visible = false;
            view.Columns[6].Width = 50;
            view.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày chứng từ"].Width = 100;
            view.Columns["Ngày chứng từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hạch toán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hạch toán"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hạch toán"].Width = 100;
            view.Columns["Ngày hạch toán"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].Width = 100;
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Tổng tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            //view.Columns["Thanh toán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //view.Columns["Thanh toán"].DisplayFormat.FormatString = "{0:n0}";
            //view.Columns["Thanh toán"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //view.Columns["Thanh toán"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chiết khấu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chiết khấu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Hóa đơn"].Width = 50;
            view.Columns["Nhân viên"].Width = 70;
            view.Columns["Họ tên"].Width = 100;
            //view.Columns["Thanh toán"].Width = 100;
            //view.Columns["Bù"].Width = 80;
            //view.Columns["Ghi chú"].Width = 100;
            view.Columns["Mã kho"].GroupIndex = 0;
            view.Columns["Chọn"].Width = 50;
            //view.Columns["Giao"].Width = 50;
            view.ExpandAllGroups();
        }

        public void tsbtpxk(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string roleid,string subsys, string ngaychungtu, string userid, string branchid, DataTable khach,DataTable hang)
        {
            try
            {
                Frm_phieunhapkho u = new Frm_phieunhapkho();
                u.myac = new Frm_phieunhapkho.ac(F.refreshpxk);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getpt("pxk");
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
            catch { MessageBox.Show("Vui lòng chọn phiếu xuất kho trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, ComboBoxEdit cbthue, LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau, DataTable khach, DataTable hang)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = true;
            tsbtboghi.Enabled = true;
            tsbtghiso.Enabled = true;
            tsbtnap.Enabled = true;
            tsbtxoa.Enabled = true;
            tsbtsua.Enabled = true;
            tsbtin.Enabled = true;
            cbldt.Properties.Items.Clear();
            cbldt.Properties.Items.Add("Khách hàng");
            cbldt.Properties.Items.Add("Nhà cung cấp");
            cbldt.Properties.Items.Add("Nhân viên");
            cbldt.SelectedIndex = 0;

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");
            cbthue.SelectedIndex = 2;

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
            mahang.PopupWidth = 300;
            */
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

            /*da = gen.GetTable("select AccountingObjectCode,AccountingObjectName from AccountingObject a, Branch b where a.BranchID=b.BranchID and b.BranchID='" + branchid + "' and IsEmployee='True' order by AccountingObjectCode");
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
            */
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
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền CK", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng tồn", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi tồn", Type.GetType("System.Double"));
            dt.Columns.Add("ID", Type.GetType("System.String"));
           
            gridControl1.DataSource = dt;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Số lượng tồn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng tồn"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi tồn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi tồn"].DisplayFormat.FormatString = "{0:n2}";

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
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
        }

        public void loadpxk(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_phieunhapkho F, LookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, TextEdit txtptvc, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, TextEdit txtcth,ComboBoxEdit cbthue
            , LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau, TextEdit ttck, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, TextEdit txtthue, TextEdit txtten, TextEdit txtdc)
        {
            DataTable dt = new DataTable();
            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dongia,thanhtien,cbthue,lenv,chiphi,chietkhau,khach,hang);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  InventoryItemCode,Quantity,QuantityConvert,DiscountRate,InventoryItemName,a.UnitPrice,a.Amount,Cost,DiscountAmount,QuantityExits,QuantityConvertExits,RefDetailID from INOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
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
                    dr[9] = da.Rows[i][9].ToString();
                    dr[10] = da.Rows[i][10].ToString();
                    dr[11] = da.Rows[i][11].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                F.Text = "Xem phiếu xuất kho";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,Tax,EmployeeIDSA,TotalAmountOC,IsExport,a.AccountingObjectName,a.AccountingObjectAddress  from INOutward a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
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
                    tsbtsua.Enabled = false;
                }
                try
                {
                    string px = gen.GetString("select RefID from SSInvoice where ShippingMethodID='" + role + "'");
                    tsbtsua.Enabled = false;
                    tsbtboghi.Enabled = false;
                }
                catch { }
                try
                {
                    cbthue.Text = da.Rows[0][12].ToString();
                }
                catch { }
                try
                {
                    string nv = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][13].ToString() + "'");
                    lenv.EditValue = nv;
                }
                catch 
                {
                    lenv.EditValue= "3";
                }
                txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView1.Columns["Thành tiền"].SummaryText) + Double.Parse(gridView1.Columns["Chi phí"].SummaryText));
                ttck.Text = gridView1.Columns["Tiền CK"].SummaryText;
                txtthue.EditValue = da.Rows[0][14].ToString();
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
                txtten.Text = da.Rows[0][16].ToString();
                txtdc.Text = da.Rows[0][17].ToString();
            }
            else
            {
                F.Text = "Thêm phiếu xuất kho";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                denht.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void checkpxk(string active, string role, Frm_phieunhapkho F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, ComboBoxEdit cbthue, LookUpEdit lenv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,TextEdit txttthue)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 20];
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

                    if (gridView1.GetRowCellValue(i, "Số lượng tồn").ToString() == "")
                        detail[i, 8] = "0";
                    else
                        detail[i, 8] = gridView1.GetRowCellValue(i, "Số lượng tồn").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi tồn").ToString() == "")
                        detail[i, 9] = "0";
                    else
                        detail[i, 9] = gridView1.GetRowCellValue(i, "Số lượng quy đổi tồn").ToString().Replace(".", "").Replace(",", ".");
                    detail[i, 10] = gridView1.GetRowCellValue(i, "ID").ToString();
                }

                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";

                    string tongthanhtien = Math.Round(Double.Parse(gridView1.Columns["Thành tiền"].SummaryText) + Double.Parse(gridView1.Columns["Chi phí"].SummaryText), 0).ToString();
                    string tongchiphi = gridView1.Columns["Tiền CK"].SummaryText;
                    tongthanhtien = tongthanhtien.Replace(".", "");
                    tongchiphi = tongchiphi.Replace(".", "");
                    string thue = txttthue.EditValue.ToString().Replace(".", "");
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
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        try
                        {
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + nv + "','" + tongchiphi + "','" + tongthanhtien + "','" + thue + "')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,TotalAmountOC) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tongchiphi + "','" + tongthanhtien + "','" + thue + "')");
                        }
                        string refid = gen.GetString("select * from INOutward where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "',0,0,'" + detail[i, 6] + "','" + detail[i, 7] + "')");
                        }

                    }
                    else
                    {
                        Double hangxuat = 0;
                        try
                        {
                            hangxuat = Double.Parse(gen.GetString("select sum(QuantityConvertExits) from INOutwardDetail where RefID='" + role + "'"));
                        }
                        catch { }
                        if (hangxuat != 0)
                        {
                            if (dt != gen.GetString("select AccountingObjectID from INOutward where RefID='" + role + "'"))
                            {
                                XtraMessageBox.Show("Phiếu đã được xuất hóa đơn bạn không thể đổi tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ledt.EditValue = gen.GetString("select AccountingObjectCode from INOutward a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                                return;
                            }
                        }

                        try
                        {
                            gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA='" + nv + "',TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "'  where RefID='" + role + "'");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "'  where RefID='" + role + "'");
                        }
                        gen.ExcuteNonquery("delete  from  INOutwardDetail where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            if (detail[i, 10] == "")
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 6] + "','" + detail[i, 7] + "')");
                            else
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount) values('" + detail[i, 10] + "','" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 6] + "','" + detail[i, 7] + "')");
                        }

                        Double ton = 0;
                        try
                        {
                            ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INOutwardDetail where RefID='" + role + "'"));
                        }
                        catch { }
                        if (ton == 0)
                            gen.ExcuteNonquery("update INOutward set IsExport='True' where RefID='" + role + "'");
                        else
                            gen.ExcuteNonquery("update INOutward set IsExport='False' where RefID='" + role + "'");
                    }
                    //F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu xuất kho";
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
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PXKH";
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
            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, mk, sophieu, ngaychungtu);
        }


        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void tsbtdeletepxk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F, string userid)
        {
            try
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, "User").ToString() != userid && Double.Parse(gen.GetString("select AuthenticationType from MSC_User where UserID='" + userid + "'")) < 2)
                {
                    XtraMessageBox.Show("Bạn không phải người lập đơn hàng này nên không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from INOutward where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string hoadon = view.GetRowCellValue(view.FocusedRowHandle, "Hóa đơn").ToString();
                string Tax = view.GetRowCellValue(view.FocusedRowHandle, "Thuế").ToString();
                if (Tax == "False")
                {
                    if (hoadon == "False")
                    {
                        try
                        {
                            Double temp = Double.Parse(gen.GetString("select sum(QuantityConvertExits) as QuantityConvertExits  from  INOutwardDetail where RefID= '" + name + "'"));
                            if (temp != 0)
                            {
                                XtraMessageBox.Show("Một phần phiếu đã được xuất hóa đơn bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu xuất kho " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    gen.ExcuteNonquery("delete from INOutwardDetail where RefID='" + name + "'");
                                    gen.ExcuteNonquery("delete from INOutward where RefID='" + name + "'");                                    
                                    view.DeleteRow(view.FocusedRowHandle);
                                }
                            }
                        }
                        catch
                        {
                            if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu xuất kho " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                gen.ExcuteNonquery("delete from INOutward where RefID='" + name + "'");
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Phiếu đã được xuất hóa đơn bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Phiếu đã được xuất theo đơn giá có thuế bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu xuất kho trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
 }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapkho F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
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
                    id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }

        public void updatepn(GridView view, string ngaychungtu)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='"+view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString()+"'");
            gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=0,QuantityConvertExits=0 where RefID in (select RefID from INOutward where  StockID='" + makho + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "')");
            gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=COALESCE(b.Quantity,0),QuantityConvertExits=COALESCE(b.QuantityConvert,0) from INOutwardDetail a, (select sum(Quantity) as Quantity,sum(QuantityConvert) as QuantityConvert,RefIDD  from SSInvoiceINOutward where SSInvoiceID in (select RefID from SSInvoice where BranchID='" + makho + "' and MONTH(PURefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(PURefDate)='" + DateTime.Parse(ngaychungtu).Year + "') group by RefIDD) b where a.RefDetailID=b.RefIDD");
            /*string hdid = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
            gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=0,QuantityConvertExits=0 where RefID='" + hdid + "'");
            gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=COALESCE(b.Quantity,0),QuantityConvertExits=COALESCE(b.QuantityConvert,0) from INOutwardDetail a, (select sum(Quantity) as Quantity,sum(QuantityConvert) as QuantityConvert,RefIDD  from SSInvoiceINOutward where INOutwardID='" + hdid + "' group by RefIDD) b where a.RefDetailID=b.RefIDD");
            Double ton = 0;
            try
            {
                ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INOutwardDetail where RefID='" + hdid + "'"));
            }
            catch { }
            if (ton == 0)
            {
                gen.ExcuteNonquery("update INOutward set IsExport='True' where RefID='" + hdid + "'");
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Hóa đơn"], "True");
            }
            else
            {
                gen.ExcuteNonquery("update INOutward set IsExport='False' where RefID='" + hdid + "'");
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Hóa đơn"], "False");
            }*/
            //gen.ExcuteNonquery("update B set IsExport = case when soton=0 then 'True' else 'False' end from (select A.RefID,SUM(QuantityConvert-QuantityConvertExits) as soton from (select RefID,IsExport from INOutward with (nolock) where RefID in (select distinct INOutwardID from SSInvoiceINOutward with (nolock) where SSInvoiceID in (select RefID from SSInvoice where BranchID='" + makho + "' and MONTH(PURefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(PURefDate)='" + DateTime.Parse(ngaychungtu).Year + "') )) A, INOutwardDetail B with (nolock) where A.RefID=B.RefID group by A.RefID) A, INOutward B where A.RefID=B.RefID");
            gen.ExcuteNonquery("update INOutward set IsExport='0' where StockID='" + makho + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "'");
            gen.ExcuteNonquery("update INOutward set IsExport='1' where StockID='" + makho + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "' and RefID in (select RefID from (select a.RefID,SUM(QuantityConvert-QuantityConvertExits) as soluong from INOutward a, INOutwardDetail b where a.StockID='" + makho + "' and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "' and a.RefID=b.RefID group by a.RefID) a where soluong=0 )");
        }
    }
}
