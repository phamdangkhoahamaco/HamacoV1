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
    class phieuxuatkhocothue
    {
        gencon gen = new gencon();
        public void tsbtpxk(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang)
        {
            try
            {
                Frm_phieunhapkhovat u = new Frm_phieunhapkhovat();
                u.myac = new Frm_phieunhapkhovat.ac(F.refreshpxkct);
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

        public void tsbtpxkchuyen(string a, string phieu, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang)
        {
            try
            {
                Frm_phieunhapkhovat u = new Frm_phieunhapkhovat();
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getpt("pxk");
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.getkhach(khach);
                u.gethang(hang);
                u.getphieu(phieu);
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu xuất kho trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, ComboBoxEdit cbthue, LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau, DataTable khach, DataTable hang, DevExpress.XtraGrid.GridControl gridControl2, GridView gridView2, DataTable dt1)
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
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền CK", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng tồn", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi tồn", Type.GetType("System.Double"));
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("ĐG vận chuyển", Type.GetType("System.Double"));
            dt.Columns.Add("Vận chuyển", Type.GetType("System.Double"));
            dt.Columns.Add("Phí khác", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));

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
            gridView1.Columns["Chi phí"].ColumnEdit = chietkhau;
            gridView1.Columns["Tiền CK"].ColumnEdit = chiphi;
            gridView1.Columns["Chiết khấu"].ColumnEdit = chietkhau;
            gridView1.Columns["ĐG vận chuyển"].ColumnEdit = chietkhau;
            gridView1.Columns["Vận chuyển"].ColumnEdit = chiphi;
            gridView1.Columns["Phí khác"].ColumnEdit = chiphi;

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Chi phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chi phí"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Chi phí"].Caption = "ĐG Số lượng";

            gridView1.Columns["Phí khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Phí khác"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            gridView1.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Chiết khấu"].Caption = "Đơn giá phí";

            gridView1.Columns["Tiền CK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Tiền CK"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Tiền CK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Tiền CK"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Tiền CK"].Caption = "Bốc xếp";

            gridView1.Columns["ĐG vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["ĐG vận chuyển"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Vận chuyển"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Vận chuyển"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Vận chuyển"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;




            dt1.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt1.Columns.Add("Tên hàng");
            dt1.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt1.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt1.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt1.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt1.Columns.Add("Chi phí", Type.GetType("System.Double"));
            dt1.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt1.Columns.Add("Tiền CK", Type.GetType("System.Double"));

            gridControl2.DataSource = dt1;
            gridView2.Columns["Số lượng"].ColumnEdit = soluong;
            gridView2.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;

            gridView2.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView2.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView2.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView2.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView2.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView2.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView2.Columns["Chi phí"].ColumnEdit = chiphi;
            gridView2.Columns["Chiết khấu"].ColumnEdit = chietkhau;
            

            gridView2.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            gridView2.Columns["Đơn giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
            gridView2.Columns["Đơn giá"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView2.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView2.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView2.Columns["Chi phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Chi phí"].DisplayFormat.FormatString = "{0:n0}";
            gridView2.Columns["Chi phí"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Chi phí"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView2.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView2.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            gridView2.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n2}";

            gridView2.Columns["Tiền CK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Tiền CK"].DisplayFormat.FormatString = "{0:n0}";
            gridView2.Columns["Tiền CK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Tiền CK"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView2.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["Số lượng quy đổi"].OptionsColumn.AllowEdit = false;
 
            gridView2.Columns[6].Visible = false;
            gridView2.Columns[7].Visible = false;
            gridView2.Columns[8].Visible = false;
        }

        public void loadpxk(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_phieunhapkhovat F, LookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, TextEdit txtptvc, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, TextEdit txtcth, ComboBoxEdit cbthue
            , LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau, TextEdit txtck, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, TextEdit txtthue, DevExpress.XtraGrid.GridControl gridControl2, GridView gridView2, TextEdit txtten, TextEdit txtdc, TextEdit txtptgh, CheckEdit chtm, TextEdit txtdienthoai,TextEdit txtddh,TextEdit txttaixe,TextEdit txtcmnd, TextEdit txtsdttaixe,TextEdit txtgn, CheckEdit chvctc, TextEdit txtvc)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            txttaixe.Text = "";
            txtcmnd.Text = "";
            txtsdttaixe.Text = "";
            txtgn.Text = "";

            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dongia, thanhtien, cbthue, lenv, chiphi, chietkhau, khach, hang,gridControl2,gridView2,dt1);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  InventoryItemCode,Quantity,QuantityConvert,a.ConvertRate,InventoryItemName,a.UnitPriceOC,a.AmountOC,a.UnitPriceConvert,a.UnitPriceConvertOC,QuantityExits,QuantityConvertExits,RefDetailID,a.UnitPrice,a.Amount,DiscountRate,DiscountAmount,Cost,COALESCE(a.CustomField1,0),COALESCE(a.CustomField2,0),a.CustomField3,DGPhi from INOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][4].ToString();
                    dr[2] = da.Rows[i][1].ToString();
                    dr[3] = da.Rows[i][2].ToString();
                    dr[4] = da.Rows[i][7].ToString();
                    dr[5] = da.Rows[i][5].ToString();
                    dr[6] = da.Rows[i][6].ToString();
                    dr[7] = da.Rows[i][3].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    dr[9] = da.Rows[i][9].ToString();
                    dr[10] = da.Rows[i][10].ToString();
                    dr[11] = da.Rows[i][11].ToString();
                    dr[12] = da.Rows[i][17].ToString();
                    dr[13] = da.Rows[i][18].ToString();
                    if (da.Rows[i][20].ToString() != "")
                        dr[14] = da.Rows[i][20].ToString();
                    else dr[14] = "0";
                    dr[15] = da.Rows[i][19].ToString();
                    dt.Rows.Add(dr);

                    DataRow dr1 = dt1.NewRow();
                    dr1[0] = da.Rows[i][0].ToString();
                    dr1[1] = da.Rows[i][4].ToString();
                    dr1[2] = da.Rows[i][1].ToString();
                    dr1[3] = da.Rows[i][2].ToString();
                    dr1[4] = da.Rows[i][12].ToString();
                    dr1[5] = da.Rows[i][13].ToString();
                    dt1.Rows.Add(dr1);
                }
                gridControl1.DataSource = dt;
                gridControl2.DataSource = dt1;
                tsbtcat.Enabled = false;
                
                F.Text = "Xem phiếu xuất kho";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,Tax,EmployeeIDSA,TotalAmountOC,IsExport,a.AccountingObjectName,a.AccountingObjectAddress,CustomField6,RefType,OriginalRefNo,a.CustomField5,TotalFreightAmount,Taixe,CMND,Dienthoai,Shipper,CurrencyID  from INOutward a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");

                txttaixe.Text = da.Rows[0][23].ToString();
                txtcmnd.Text = da.Rows[0][24].ToString();
                txtsdttaixe.Text = da.Rows[0][25].ToString();
                txtgn.Text = da.Rows[0][26].ToString();

                txtddh.Text = da.Rows[0][21].ToString();
                txtdienthoai.Text = da.Rows[0][20].ToString();
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
                    F.getchon(1);
                    cbthue.Text = da.Rows[0][12].ToString();
                }
                catch { }
                try
                {
                    lenv.EditValue = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][13].ToString() + "'");
                }
                catch
                {
                    lenv.EditValue = "3";
                }

                txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
                txtck.EditValue = Double.Parse(da.Rows[0][22].ToString());    
                txtthue.EditValue = da.Rows[0][14].ToString();                                      
               
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
                txtten.Text = da.Rows[0][16].ToString();
                txtdc.Text = da.Rows[0][17].ToString();
                txtptgh.Text = da.Rows[0][18].ToString();

                if (da.Rows[0][19].ToString() == "1")
                    chtm.Checked = true;
                else
                    chtm.Checked = false;

                txtvc.EditValue = Double.Parse(gridView1.Columns["Vận chuyển"].SummaryText);

                if (da.Rows[0][27].ToString() == "True")
                    chvctc.Checked = true;
                else
                    chvctc.Checked = false;
            }
            else
            {
                F.Text = "Thêm phiếu xuất kho";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                denht.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
                chtm.Checked = false;
            }
        }

        public void checkpxk(string active, string role, Frm_phieunhapkhovat F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, ComboBoxEdit cbthue, LookUpEdit lenv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txttthue, GridView gridView2, DataTable hangton, TextEdit txtptgh, CheckEdit chtm, TextEdit txtdienthoai, TextEdit txtddh, TextEdit txtck, TextEdit txttc,TextEdit txttaixe,TextEdit txtcmnd,TextEdit txtsdttaixe,TextEdit txtgn, CheckEdit chvctc)
        {
            /*if (active == "0" && DateTime.Parse(DateTime.Parse(denct.EditValue.ToString()).ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ngày lập phiếu xuất kho không được nhỏ hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string tienmat = "0";
                if (chtm.Checked == true)
                    tienmat = "1";
                string[,] detail = new string[120, 25];
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


                    if (gridView2.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail[i, 4] = gridView2.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView2.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 5] = gridView2.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    if (gridView2.GetRowCellValue(i, "Chi phí").ToString() == "")
                        detail[i, 6] = "0";
                    else
                        detail[i, 6] = gridView2.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView2.GetRowCellValue(i, "Chiết khấu").ToString() == "")
                        detail[i, 3] = "0";
                    else
                        detail[i, 3] = gridView2.GetRowCellValue(i, "Chiết khấu").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView2.GetRowCellValue(i, "Tiền CK").ToString() == "")
                        detail[i, 7] = "0";
                    else
                        detail[i, 7] = gridView2.GetRowCellValue(i, "Tiền CK").ToString().ToString().Replace(".", "");


                    if (gridView1.GetRowCellValue(i, "Số lượng tồn").ToString() == "")
                        detail[i, 8] = "0";
                    else
                        detail[i, 8] = gridView1.GetRowCellValue(i, "Số lượng tồn").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi tồn").ToString() == "")
                        detail[i, 9] = "0";
                    else
                        detail[i, 9] = gridView1.GetRowCellValue(i, "Số lượng quy đổi tồn").ToString().Replace(".", "").Replace(",", ".");
                    detail[i, 10] = gridView1.GetRowCellValue(i, "ID").ToString();


                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail[i, 11] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 12] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "Chi phí").ToString() == "")
                        detail[i, 15] = "0";
                    else
                        detail[i, 15] = gridView1.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Chiết khấu").ToString() == "")
                        detail[i, 13] = "0";
                    else
                        detail[i, 13] = gridView1.GetRowCellValue(i, "Chiết khấu").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Tiền CK").ToString() == "")
                        detail[i, 14] = "0";
                    else
                        detail[i, 14] = gridView1.GetRowCellValue(i, "Tiền CK").ToString().ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "ĐG vận chuyển").ToString() == "")
                        detail[i, 16] = "0";
                    else
                        detail[i, 16] = gridView1.GetRowCellValue(i, "ĐG vận chuyển").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Vận chuyển").ToString() == "")
                        detail[i, 17] = "0";
                    else
                        detail[i, 17] = gridView1.GetRowCellValue(i, "Vận chuyển").ToString().ToString().Replace(".", "");
                    detail[i, 18] = gridView1.GetRowCellValue(i, "Ghi chú").ToString();

                    if (gridView1.GetRowCellValue(i, "Phí khác").ToString() == "")
                        detail[i, 19] = "0";
                    else
                        detail[i, 19] = gridView1.GetRowCellValue(i, "Phí khác").ToString().ToString().Replace(".", "");
                }

                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.getloi("1");
                    return;
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";

                    string tongthanhtien = Math.Round(Double.Parse(gridView2.Columns["Thành tiền"].SummaryText) + Double.Parse(gridView2.Columns["Chi phí"].SummaryText), 0).ToString();
                    string tongchiphi = txtck.EditValue.ToString().Replace(".", "");
                    tongthanhtien = tongthanhtien.Replace(".", "");
                    string thue = txttthue.EditValue.ToString().Replace(".", "");
                    string tongcong = txttc.EditValue.ToString().Replace(".", "");

                    string sql = "";

                    if (Double.Parse(gridView1.Columns["Thành tiền"].SummaryText) != Double.Parse(tongcong) + Double.Parse(tongchiphi))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Tổng tiền có thuế và chưa thuế không đúng vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        F.getloi("1");
                        return;
                    }

                    string nv = "NULL";
                    try
                    {
                        nv = "'"+gen.GetString("select * from AccountingObject where AccountingObjectCode='" + lenv.EditValue.ToString() + "'")+"'";
                    }
                    catch { }

                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from INOutward where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            //XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        /*try
                        {*/
                        gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5,Taixe,CMND,Dienthoai,Shipper,CurrencyID) values(newid(),'" + tienmat + "','" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text.Replace("'", "''") + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "'," + nv + ",'" + tongchiphi + "','" + tongthanhtien + "','" + thue + "','True',N'" + txtptgh.Text + "','" + txtdienthoai.Text + "','" + txtddh.Text + "',N'" + txttaixe.Text + "',N'" + txtcmnd.Text + "',N'" + txtsdttaixe.Text + "',N'" + txtgn.Text + "','" + chvctc.Checked + "')");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6) values(newid(),'"+tienmat+"','" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tongchiphi + "','" + tongthanhtien + "','" + thue + "','True',N'"+txtptgh.Text+"')");
                        }*/
                        string refid = gen.GetString("select * from INOutward where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            //gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3,DGPhi) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "',0,0,'" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "',N'" + detail[i, 18] + "','" + detail[i, 19] + "')");
                            sql = sql + "insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3,DGPhi) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "',0,0,'" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "',N'" + detail[i, 18] + "','" + detail[i, 19] + "');";
                            /*
                            for (int j = 0; j < hangton.Rows.Count; j++)
                            {
                                if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                {
                                    hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail[i, 1]);
                                    hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail[i, 2]);
                                    break;
                                }
                            }
                            */
                        }
                        if (sql != "")
                            gen.ExcuteNonquery(sql);
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


                        /*try
                        {*/
                        gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text.Replace("'", "''") + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA=" + nv + ",TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',CustomField6=N'" + txtptgh.Text + "',RefType='" + tienmat + "',OriginalRefNo='" + txtdienthoai.Text + "',CustomField5='" + txtddh.Text + "',Taixe=N'" + txttaixe.Text + "',CMND=N'" + txtcmnd.Text + "',Dienthoai=N'" + txtsdttaixe.Text + "',Shipper=N'" + txtgn.Text + "',CurrencyID='" + chvctc.Checked + "'  where RefID='" + role + "'");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',CustomField6=N'" + txtptgh.Text + "',RefType='" + tienmat + "'  where RefID='" + role + "'");
                        }*/
                        /*
                        DataTable hangchuyen = gen.GetTable("select InventoryItemID,Quantity,QuantityConvert from INOutwardDetail where RefID='" + role + "' ");
                        for (int z = 0; z < hangchuyen.Rows.Count; z++)
                        {
                            for (int j = 0; j < hangton.Rows.Count; j++)
                            {
                                if (hangchuyen.Rows[z][0].ToString().ToLower() == hangton.Rows[j][0].ToString().ToLower())
                                {
                                    hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) + Double.Parse(hangchuyen.Rows[z][1].ToString());
                                    hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) + Double.Parse(hangchuyen.Rows[z][2].ToString());
                                    break;
                                }
                            }
                        }
                        */
                        gen.ExcuteNonquery("delete  from  INOutwardDetail where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            if (detail[i, 10] == "")
                            {
                                //gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3,DGPhi) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "',N'" + detail[i, 18] + "','" + detail[i, 19] + "')");
                                sql = sql + "insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3,DGPhi) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "',N'" + detail[i, 18] + "','" + detail[i, 19] + "');";
                            }
                            else
                            {
                                //gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3,DGPhi) values('" + detail[i, 10] + "','" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "',N'" + detail[i, 18] + "','" + detail[i, 19] + "')");
                                sql = sql + "insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3,DGPhi) values('" + detail[i, 10] + "','" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "',N'" + detail[i, 18] + "','" + detail[i, 19] + "');";
                            }
                            /*
                            for (int j = 0; j < hangton.Rows.Count; j++)
                            {
                                if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                {
                                    hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail[i, 1]);
                                    hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail[i, 2]);
                                    break;
                                }
                            }
                            */
                        }
                        if (sql != "")
                            gen.ExcuteNonquery(sql);

                        Double ton = 0;
                        try
                        {
                            ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INOutwardDetail where RefID='" + role + "'"));
                        }
                        catch { }
                        if (ton == 0)
                        {
                            gen.ExcuteNonquery("update INOutward set IsExport='True' where RefID='" + role + "'");
                        }
                        else
                        {
                            gen.ExcuteNonquery("update INOutward set IsExport='False' where RefID='" + role + "'");
                        }
                    }
                    //F.getactive("1");
                    //F.gethangton(hangton);
                    F.Text = "Xem phiếu xuất kho";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                F.getloi("1");
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
                string id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  and Cancel='True'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  and Cancel='True'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void tsbtdeletepxk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F,string userid)
        {
            try
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, "User").ToString() != userid && Double.Parse(gen.GetString("select AuthenticationType from MSC_User where UserID='" + userid + "'")) < 2)
                {
                    XtraMessageBox.Show("Bạn không phải người lập đơn hàng này nên không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                string phieu = view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString();
                if (gen.GetString("select Posted from INOutward where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string hoadon = view.GetRowCellValue(view.FocusedRowHandle, "Hóa đơn").ToString();
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
                                try
                                {
                                    gen.ExcuteNonquery("update DDH set RefIDInOutward=NULL where RefIDInOutward='" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "'");
                                }
                                catch { }
                                gen.ExcuteNonquery("insert INOutwardBK select * from INOutward where RefID='" + name + "'");
                                gen.ExcuteNonquery("insert INOutwardDetailBK select * from INOutwardDetail where RefID='" + name + "'");
                                gen.ExcuteNonquery("delete from INOutwardDetail where RefID='" + name + "'");
                                gen.ExcuteNonquery("delete from INOutward where RefID='" + name + "'");
                                view.DeleteRow(view.FocusedRowHandle);
                                //gen.ExcuteNonquery("delete from OpeningAccountEntry131TT where RefNo='" + phieu + "'");
                            }
                        }
                    }
                    catch
                    {
                        if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu xuất kho " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            gen.ExcuteNonquery("delete from INOutward where RefID='" + name + "'");
                            view.DeleteRow(view.FocusedRowHandle);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Phiếu đã được xuất hóa đơn bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu xuất kho trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void tsbtdeletepxktra(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F, string userid)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                string phieu = view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString();
                if (gen.GetString("select Posted from INOutward where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể trả hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string hoadon = view.GetRowCellValue(view.FocusedRowHandle, "Hóa đơn").ToString();
                if (hoadon == "False")
                {
                    try
                    {
                        Double temp = Double.Parse(gen.GetString("select sum(QuantityConvertExits) as QuantityConvertExits  from  INOutwardDetail where RefID= '" + name + "'"));
                        if (temp != 0)
                        {
                            XtraMessageBox.Show("Một phần phiếu đã được xuất hóa đơn bạn không thể trả hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (XtraMessageBox.Show("Bạn có chắc muốn trả hàng phiếu xuất kho " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                try
                                {
                                    gen.ExcuteNonquery("update DDH set RefIDInOutward=NULL where RefIDInOutward='" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "'");
                                }
                                catch { }
                                gen.ExcuteNonquery("insert INOutwardBK select * from INOutward where RefID='" + name + "'");
                                gen.ExcuteNonquery("insert INOutwardDetailBK select * from INOutwardDetail where RefID='" + name + "'");
                                gen.ExcuteNonquery("update INOutwardBK set RefType='901' where RefID='" + name + "'");
                                gen.ExcuteNonquery("delete from INOutwardDetail where RefID='" + name + "'");
                                gen.ExcuteNonquery("delete from INOutward where RefID='" + name + "'");
                                view.DeleteRow(view.FocusedRowHandle);
                                //gen.ExcuteNonquery("delete from OpeningAccountEntry131TT where RefNo='" + phieu + "'");
                            }
                        }
                    }
                    catch
                    {
                        if (XtraMessageBox.Show("Bạn có chắc muốn trả hàng phiếu xuất kho " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            gen.ExcuteNonquery("delete from INOutward where RefID='" + name + "'");
                            view.DeleteRow(view.FocusedRowHandle);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Phiếu đã được xuất hóa đơn bạn không thể trả hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu xuất kho trước khi trả hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapkhovat F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' and Cancel='True' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' and Cancel='True' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhapkhovat F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' and Cancel='True'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' and Cancel='True' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }

        public void loadthhdmain(DevExpress.XtraGrid.Views.Grid.GridView gridView2, DevExpress.XtraGrid.Views.Grid.GridView gridView1, TextEdit txtcth, ComboBoxEdit cbthue)
        {

            while (gridView2.RowCount > 0)
            {
                gridView2.DeleteRow(0);
            }
            Double thue = 0;
            try
            {
                thue = Double.Parse(cbthue.EditValue.ToString());
            }
            catch { cbthue.EditValue = 0; }
            int dong = 1;
            if (gridView1.OptionsView.NewItemRowPosition == DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None)
                dong = 0;
            for (int i = 0; i < gridView1.RowCount-dong; i++)
            {
                Double soluong = 0;
                Double soluongqd = 0;
                Double thanhtien = 0;
                Double dongiaban = 0;
                
                try
                {
                    soluongqd = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                    if (soluongqd != 0)
                    {
                        try
                        {
                            soluong = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng").ToString());
                        }
                        catch { }
                        try
                        {
                            thanhtien = Double.Parse(gridView1.GetRowCellValue(i, "Thành tiền").ToString());
                        }
                        catch { }
                        try
                        {
                            dongiaban = Double.Parse(gridView1.GetRowCellValue(i, "Đơn giá").ToString());
                        }
                        catch { }

                        thanhtien = Math.Round(thanhtien / ((100 + thue) / 100), 0);
                        dongiaban = Math.Round(thanhtien / soluongqd, 2);

                        if (gridView2.RowCount > 0)
                        {
                            gridView2.AddNewRow();
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tên hàng"], gridView1.GetRowCellValue(i, "Tên hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], soluong);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], dongiaban);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], thanhtien);
                            gridView2.UpdateCurrentRow();
                        }
                        else
                        {
                            gridView2.AddNewRow();
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tên hàng"], gridView1.GetRowCellValue(i, "Tên hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], soluong);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], dongiaban);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], thanhtien);
                            gridView2.UpdateCurrentRow();
                        }
                    }
                }
                catch { }
            }
            txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
        }

    }
}
