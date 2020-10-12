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
    class hdmhkpn
    {
        gencon gen = new gencon();
        public void tsbtpxk(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang)
        {
            try
            {
                Frm_hdmhkpn u = new Frm_hdmhkpn();
                u.myac = new Frm_hdmhkpn.ac(F.refreshhdmhkpn);
                u.getactive(a);
                u.getroleid(roleid);
                u.getkhach(khach);
                u.gethang(hang);
                u.getsub(subsys);
                u.getpt("pxk");
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
            catch { MessageBox.Show("Vui lòng chọn phiếu trước khi sửa."); }
        }

        public void tsbthdbhchuyen(string a, string ma,string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang)
        {
            try
            {
                Frm_hdmhkpn u = new Frm_hdmhkpn();
                u.getactive(a);
                u.getpt("hdmh");
                u.getsub(subsys);
                u.getkhach(khach);
                u.getroleid(roleid);
                u.gethang(hang);               
                u.getphieu(ma);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn hóa đơn bán hàng trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
           DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
           ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, ComboBoxEdit cbthue, LookUpEdit lenv,
           TextEdit txtnhd, TextEdit txthtt, TextEdit txthttt, DataTable khach, DataTable hang, ComboBoxEdit cbtkdu)
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
            cbldt.Properties.Items.Add("Gửi hàng");
            cbldt.SelectedIndex = 0;

            cbtkdu.Properties.Items.Clear();
            cbtkdu.Properties.Items.Add("331");
            cbtkdu.Properties.Items.Add("2421");
            cbtkdu.Properties.Items.Add("335");
            cbtkdu.SelectedIndex = 0;

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

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
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));

            dt.Columns.Add("Đơn giá phí", Type.GetType("System.Double"));
            dt.Columns.Add("Bốc xếp", Type.GetType("System.Double"));
           
            gridControl1.DataSource = dt;

            gridView1.Columns["Đơn giá phí"].ColumnEdit = dongia;
            gridView1.Columns["Bốc xếp"].ColumnEdit = thanhtien;

            gridView1.Columns["Bốc xếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Bốc xếp"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Bốc xếp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Bốc xếp"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Đơn giá phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá phí"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Đơn giá phí"].Caption = "ĐG Bốc xếp";


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
            gridView1.Columns["Số lượng quy đổi"].Caption = "Trọng lượng";

            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Chi phí"].ColumnEdit = chiphi;

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
        }

        public void loadpxk(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_hdmhkpn F, LookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtptvc, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, TextEdit txtcth, ComboBoxEdit cbthue
            , LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtnhd, TextEdit txthtt, TextEdit txthttt, TextEdit txtms,
            TextEdit txtkhhd, TextEdit txtshd, TextEdit txtdc, TextEdit txttthue, TextEdit txtspx, DataTable khach, DataTable hang, TextEdit txtname, TextEdit txtmst, ComboBoxEdit cbtkdu, TextEdit txtddh, CheckEdit chhnk, TextEdit txtck, TextEdit txttaixe,TextEdit txtgn)
        {
            DataTable dt = new DataTable();
            txtck.EditValue = 0;
            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dongia, thanhtien, chiphi, cbthue, lenv, txtnhd, txthtt, txthttt, khach, hang, cbtkdu);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select InventoryItemCode,InventoryItemName,a.Quantity,a.QuantityConvert,a.UnitPrice,a.TotalAmount,N1562,c.UnitPriceOC,c.UnitPriceConvert from PUInvoiceINInward a,InventoryItem b,INInwardDetail c  where a.INInwardID=c.RefID and a.SortOrder=c.SortOrder and a.InventoryItemID=b.InventoryItemID and PUInvoiceID='" + role + "' order by a.SortOrder");
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
                    try
                    {
                        dr[7] = da.Rows[i][7].ToString();
                        dr[8] = da.Rows[i][8].ToString();
                    }
                    catch
                    {
                        dr[7] = 0;
                        dr[8] = 0;
                    }
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                F.Text = "Xem hóa đơn mua hàng kiêm phiếu nhập";

                da = gen.GetTable("select AccountingObjectCode,RefNo,Posted,AccountingObjectType,Cancel,PUPostedDate,PURefDate,CABARefDate,PUJournalMemo,TotalAmount,DueDateTime,AccountingObjectID1562,Tax,No,InvSeries,InvNo,PayNo,TotalVatAmount,StockCode,a.CustomField4,ShippingMethodID, RefType,InwardRefNo,IsExport,IsImportPurchase,TotalFreightAmountOC,CABAAccountingObjectBankAccount,CABAAccountingObjectBankName,CABAContactName  from PUInvoice a, AccountingObject b,Stock c where a.BranchID=c.StockID and a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                
                if (da.Rows[0][24].ToString() == "True")
                    chhnk.Checked = true;
                else
                    chhnk.Checked = false;
                
                try
                {
                    cbldt.SelectedIndex = Int32.Parse(da.Rows[0][3].ToString());
                }
                catch { }
                if (da.Rows[0][21].ToString() == "335")
                    cbtkdu.SelectedIndex = 2;
                else if (da.Rows[0][21].ToString() == "2421")
                    cbtkdu.SelectedIndex = 1;
                else cbtkdu.SelectedIndex = 0;

                ledv.EditValue = da.Rows[0][18].ToString();
                txtmst.EditValue = da.Rows[0][19].ToString();
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
                txtddh.Text = da.Rows[0][22].ToString();
                Double tienthue = 0;
                try
                {
                    tienthue = Double.Parse(da.Rows[0][17].ToString());
                }
                catch { }
                try
                {
                    string n1562 = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][11].ToString() + "'");
                    lenv.EditValue = n1562;
                }
                catch { lenv.EditValue = null; }

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
                }
                if (da.Rows[0][23].ToString() == "True")
                {
                    tsbtboghi.Enabled = false;
                    //tsbtsua.Enabled = false;
                }

                txtck.Text = String.Format("{0:n0}",Double.Parse(da.Rows[0][25].ToString()));
                txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView1.Columns["Thành tiền"].SummaryText));
                txttthue.EditValue = tienthue;

                txtptvc.Text = da.Rows[0][26].ToString();
                txttaixe.Text = da.Rows[0][27].ToString();
                txtgn.Text = da.Rows[0][28].ToString();
                
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);

                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo from INInward a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + da.Rows[0][20].ToString() + "'");

                txtctg.Text = da.Rows[0][3].ToString();
                txtspx.Text = da.Rows[0][6].ToString();               
               
            }
            else
            {
                F.Text = "Thêm hóa đơn mua hàng kiêm phiếu nhập";
                cbldt.SelectedIndex = 0;
                cbthue.EditValue = "10";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                txthttt.Text = "TM/CK";
                txthtt.Text = "0";
                denct.EditValue = DateTime.Parse(ngaychungtu);
                denht.EditValue = DateTime.Parse(ngaychungtu);
                txtnhd.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void themsct(string ngaychungtu, TextEdit txtsct, string branchid, string kho, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd)
        {
            DataTable da = new DataTable();
            int dai = 5;
            //string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + gen.GetString("select BranchID from Stock where StockCode='" + kho + "'") + "'");
            string makho = gen.GetString("select StockID from Stock where StockCode='" + kho + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + kho + "-HDMH";

            try
            {
                string id = gen.GetString("select Top 1 RefNo from PUInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + makho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;


                DataTable temp = gen.GetTable("select Top 1 No,No,InvSeries,InvNo from PUInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + makho + "'  order by RefNo DESC");
                txtms.Text = temp.Rows[0][1].ToString();
                txtkhhd.Text = temp.Rows[0][2].ToString();

                try
                {
                    int daihd = temp.Rows[0][3].ToString().ToString().Length;
                    int hd = Int32.Parse(temp.Rows[0][3].ToString()) + 1;

                    txtshd.Text = hd.ToString();
                    for (int i = 0; i < daihd - hd.ToString().Length; i++)
                    {
                        txtshd.Text = "0" + txtshd.Text;
                    }
                }
                catch { }

            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, kho, sophieu, ngaychungtu);
        }

        public void themsctpx(string ngaychungtu, TextEdit txtsct, string mk, string branchid)
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
            string sophieu = branch + "-" + mk + "-PNKH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INInward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtsct.Text = sophieu;
        }

        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hdmhkpn F, string ngay, string branchid)
        {
            try
            {
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from PUInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and Cancel='True' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from PUInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and Cancel='True' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hdmhkpn F, string ngay, string branchid)
        {
            try
            {
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from PUInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and Cancel='True'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from PUInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and Cancel='True' order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from PUInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + idkho + "' and Cancel='True'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from PUInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + idkho + "' and Cancel='True'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checkhdmh(string active, string role, Frm_hdmhkpn F, GridView gridView1, LookUpEdit ledt, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, ComboBoxEdit cbthue, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txthtt,
           TextEdit txthttt, TextEdit txtms, LookUpEdit le1562, string branchid, string userid, TextEdit txtthue, LookUpEdit ledv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtmst, TextEdit txtctg, TextEdit txtptvc, TextEdit txtspx, ComboBoxEdit cbtkdu, TextEdit txtddh, CheckEdit chhnk, TextEdit txtck,TextEdit txttaixe,TextEdit txtgn)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[600, 30];
                string check = "0";
                string hnk = "331";
                if (chhnk.Checked == true)
                    hnk = "33312";
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
                        detail[i, 2] = "0";
                    else
                        detail[i, 2] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        detail[i, 3] = "0";
                    else 
                        detail[i, 3] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 4] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Chi phí").ToString() == "")
                        detail[i, 5] = "0";
                    else
                        detail[i, 5] = gridView1.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "");

                    Double tienc = Double.Parse(detail[i, 4]) + Double.Parse(detail[i, 5]);
                    Double slqd = Double.Parse(detail[i, 2]);
                    detail[i, 6] = tienc.ToString();
                    if (slqd == 0)
                        detail[i, 7] = "0";
                    else
                        detail[i, 7] = Math.Round((tienc / slqd), 2).ToString();

                    if (gridView1.GetRowCellValue(i, "Đơn giá phí").ToString() == "")
                        detail[i, 8] = "0";
                    else
                        detail[i, 8] = gridView1.GetRowCellValue(i, "Đơn giá phí").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Bốc xếp").ToString() == "")
                        detail[i, 9] = "0";
                    else
                        detail[i, 9] = gridView1.GetRowCellValue(i, "Bốc xếp").ToString().Replace(".", "").Replace(",", ".");
                }

                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {    
                    string tongthanhtien = gridView1.Columns["Thành tiền"].SummaryText;
                    string tongchiphi = gridView1.Columns["Chi phí"].SummaryText;

                  
                    if (Double.Parse(tongchiphi) != 0 && le1562.EditValue == null)
                    {
                        XtraMessageBox.Show("Vui lòng chọn đối tượng 1562", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tongthanhtien = tongthanhtien.Replace(".", "");
                    tongchiphi = tongchiphi.Replace(".", "");
                    tongthanhtien = Math.Round(Double.Parse(tongthanhtien), 0).ToString();
                    
                    string chietkhau = "0";
                    if (txtck.Text != "")
                        chietkhau = txtck.Text.Replace(".", "");

                    //string tongthanhtientruck = Math.Round(Double.Parse(tongthanhtien) - Double.Parse(chietkhau), 0).ToString();

                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");

                    string nv = "";
                    try
                    {
                        nv = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + le1562.EditValue.ToString() + "'");
                    }
                    catch { }

                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from INInward where RefNo='" + txtspx.Text + "'");
                            themsctpx(ngaychungtu, txtspx, ledv.EditValue.ToString(), branchid);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtspx.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        try
                        {
                            string ton = gen.GetString("select * from PUInvoice where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, branchid, ledv.EditValue.ToString(), tsbttruoc, tsbtsau, txtms, txtkhhd, txtshd);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        try
                        {
                            gen.ExcuteNonquery("insert into INInward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,EmployeeID,EmployeeIDPU,IsExport) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtspx.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "','',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + userid + "','" + nv + "','True')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into INInward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,EmployeeID,IsExport) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtspx.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "','',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + userid + "','True')");
                        }
                        string refidpx = gen.GetString("select * from INInward where RefNo='" + txtspx.Text + "'");

                        try
                        {
                            gen.ExcuteNonquery("insert into PUInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,AccountingObjectID1562,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalVatAmount,CustomField4,Cancel,ShippingMethodID,InwardRefNo,IsImportPurchase,TotalFreightAmountOC,CABAAccountingObjectBankAccount,CABAAccountingObjectBankName,CABAContactName) values(newid(),'" + dv + "','" + cbtkdu.EditValue.ToString() + "','" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "','" + nv + "',N'" + txtldn.Text + "','False','" + ldt + "','" + tongthanhtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "'," + txthtt.Text + ",'" + tongchiphi + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + txtthue.Text.Replace(".", "") + "','" + txtmst.Text + "','True','" + refidpx + "','" + txtddh.Text + "','" + chhnk.Checked + "','" + chietkhau + "',N'" + txtptvc.Text + "',N'" + txttaixe.Text + "',N'" + txtgn.Text + "')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into PUInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalVatAmount,CustomField4,Cancel,ShippingMethodID,InwardRefNo,IsImportPurchase,TotalFreightAmountOC,CABAAccountingObjectBankAccount,CABAAccountingObjectBankName,CABAContactName) values(newid(),'" + dv + "','" + cbtkdu.EditValue.ToString() + "','" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtldn.Text + "','False','" + ldt + "','" + tongthanhtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "'," + txthtt.Text + ",'" + tongchiphi + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + txtthue.Text.Replace(".", "") + "','" + txtmst.Text + "','True','" + refidpx + "','" + txtddh.Text + "','" + chhnk.Checked + "','" + chietkhau + "',N'" + txtptvc.Text + "',N'" + txttaixe.Text + "',N'" + txtgn.Text + "')");
                        }
                        string refid = gen.GetString("select * from PUInvoice where RefNo='" + txtsct.Text + "'");

                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1561','331','" + tongthanhtien + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        if (txtck.Text != "")
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','331','1388','" + chietkhau + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        try
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1562','"+cbtkdu.EditValue.ToString()+"','" + tongchiphi + "','" + nv + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + nv + "')");
                        }
                        catch { }
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1331','" + hnk + "','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        F.getrole(refid);

                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            try
                            {
                                gen.ExcuteNonquery("insert into PUInvoiceINInward values(newid(),'" + refid + "','"+refidpx+"','"+dv+"','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','331','" + detail[i, 5] + "','" + i + "')");
                                gen.ExcuteNonquery("insert into PUInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice) values(newid(),'" + refid + "','" + detail[i, 6] + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 7] + "')");
                                gen.ExcuteNonquery("insert into INInwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvert) values(newid(),'" + refidpx + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 8] + "','" + detail[i, 9] + "')");
                            }
                            catch { }
                        }
            
                    }
                    else
                    {
                        string refid = role;
                        string refidpx = gen.GetString("select * from INInward where RefNo='" + txtspx.Text + "'");

                        try
                        {
                            gen.ExcuteNonquery("update INInward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',EmployeeID='" + userid + "',EmployeeIDPU='" + nv + "'  where RefID='" + refidpx + "'");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("update INInward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',EmployeeID='" + userid + "',EmployeeIDPU=Null  where RefID='" + refidpx + "'");
                        }

                        gen.ExcuteNonquery("delete  from  INInwardDetail where RefID='" + refidpx + "'");
                        gen.ExcuteNonquery("delete from PUInvoiceDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete from PUInvoiceINInward where PUInvoiceID='" + role + "'");

                        try
                        {
                            gen.ExcuteNonquery("update PUInvoice set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text + "',AccountingObjectID1562='" + nv + "',PUJournalMemo=N'" + txtldn.Text + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tongthanhtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + tongchiphi + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalVatAmount='" + txtthue.Text.Replace(".", "") + "',CustomField4='" + txtmst.Text + "',RefType='" + cbtkdu.EditValue.ToString() + "',InwardRefNo='" + txtddh.Text + "',IsImportPurchase='" + chhnk.Checked + "',TotalFreightAmountOC='" + chietkhau + "',CABAAccountingObjectBankAccount=N'" + txtptvc.Text + "',CABAAccountingObjectBankName=N'" + txttaixe.Text + "',CABAContactName=N'" + txtgn.Text + "' where RefID='" + role + "'");
                            gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1561','331','" + tongthanhtien + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                            if (txtck.Text != "")
                                gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','331','1388','" + chietkhau + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1562','"+cbtkdu.EditValue.ToString()+"','" + tongchiphi + "','" + nv + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + nv + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1331','" + hnk + "','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("update PUInvoice set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text + "',PUJournalMemo=N'" + txtldn.Text + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tongthanhtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + tongchiphi + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalVatAmount='" + txtthue.Text.Replace(".", "") + "',CustomField4='" + txtmst.Text + "',RefType='" + cbtkdu.EditValue.ToString() + "',InwardRefNo='" + txtddh.Text + "',IsImportPurchase='" + chhnk.Checked + "',TotalFreightAmountOC='" + chietkhau + "',CABAAccountingObjectBankAccount=N'" + txtptvc.Text + "',CABAAccountingObjectBankName=N'" + txttaixe.Text + "',CABAContactName=N'" + txtgn.Text + "' where RefID='" + role + "'");
                            gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                            if (txtck.Text != "")
                                gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','331','1388','" + chietkhau + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1561','331','" + tongthanhtien + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1331','" + hnk + "','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        }

                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            try
                            {
                                gen.ExcuteNonquery("insert into PUInvoiceINInward values(newid(),'" + refid + "','" + refidpx + "','" + dv + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','331','" + detail[i, 5] + "','" + i + "')");
                                gen.ExcuteNonquery("insert into PUInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice) values(newid(),'" + refid + "','" + detail[i, 6] + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 7] + "')");
                                gen.ExcuteNonquery("insert into INInwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvert) values(newid(),'" + refidpx + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 8] + "','" + detail[i, 9] + "')");
                            }
                            catch { }
                        }
                    }
                    F.getactive("1");
                    gen.ExcuteNonquery("update DDHNCC set IsExport='True' where RefNo='" + txtddh.Text + "'");
                    F.Text = "Xem hóa đơn mua hàng kiêm phiếu nhập";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void tsbtdelete(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                string ghiso = gen.GetString("select Posted from PUInvoice where RefID='" + name + "'");
                if (ghiso == "False")
                {
                    string px = gen.GetString("select ShippingMethodID from PUInvoice where RefID='" + name + "'");
                    if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        gen.ExcuteNonquery("delete from PUInvoiceDetail where RefID='" + name + "'");
                        gen.ExcuteNonquery("delete from PUInvoiceINInward where PUInvoiceID='" + name + "'");

                        gen.ExcuteNonquery("delete from PUInvoice where RefID='" + name + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");

                        gen.ExcuteNonquery("delete from INInward where RefID='" + px + "'");
                        gen.ExcuteNonquery("delete from INInwardDetail where RefID='" + px + "'");

                        view.DeleteRow(view.FocusedRowHandle);

                    }
                }
                else
                    XtraMessageBox.Show("Hóa đơn đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { XtraMessageBox.Show("Vui lòng chọn hóa đơn trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }
    }
}
