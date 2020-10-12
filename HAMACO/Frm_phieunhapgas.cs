using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HAMACO.Resources;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace HAMACO
{
    public partial class Frm_phieunhapgas : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
        phieunhapgas pnk = new phieunhapgas();
        phieuxuatgas pxk = new phieuxuatgas();
        hdbanhang hdbh = new hdbanhang();
        hdmuahang hdmh = new hdmuahang();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup,roleid,subsys,click;
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getroleid(string a)
        {
            roleid = a;
            return roleid;
        }
        public string getsub(string a)
        {
            subsys = a;
            return subsys;
        }
        public string getpt(string a)
        {
            pt = a;
            return pt;
        }
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public string getbranch(string a)
        {
            branchid = a;
            return branchid;
        }
        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }
        public void refreshpnk()
        {
            pnk.loadpnk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc,gridControl2,gridView2,dongia,thanhtien,txtpnv,lenv,tsbttruoc,tsbtsau);
        }
        public void refreshpxk()
        {
            pxk.loadpxk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, gridControl2, gridView2, dongia, thanhtien, txtpnv,cbthue,txtcth,lenv,chiphi,chietkhau,txtck,tsbttruoc,tsbtsau);
        }
        public Frm_phieunhapgas()
        {
            InitializeComponent();
        }
        public void getdoituong(string a, string check)
        {
            if (check == "1")
                ledt.EditValue = a;
            else if (check == "2")
            {
                try
                {
                    string temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tên hàng").ToString();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], a);
                }
                catch
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], a);
                }
            }
            else if (check == "3")
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], a);
        }
        private void Frm_phieunhapgas_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole();
            if (pt == "pnk")
            {
                labelControl12.Hide();
                cbthue.Hide();
                panelControl6.Hide();
                refreshpnk();
            }
            else if (pt == "pxk")
            {
                refreshpxk();
                labelControl13.Text = "Phiếu xuất kho Gas";
            }
            change();
        }
        private void refreshrole()
        {
            tsbtsua.Enabled = false;
            tsbtadd.Enabled = false;
            tsbtcat.Enabled = false;
            tsbtxoa.Enabled = false;
            tsbtin.Enabled = false;
            tsbtnap.Enabled = false;
            tsbtghiso.Visible = false;
            tsbtghiso.Enabled = false;
            tsbtboghi.Visible = false;
            tsbtboghi.Enabled = false;

            if (active == "0")
            {
                tsbtcat.Enabled = true;
                tsbtadd.Enabled = true;
            }
            else
            {
                tsbtnap.Enabled = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "ADD")
                        tsbtadd.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "DELETE")
                        tsbtxoa.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "EDIT")
                        tsbtsua.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "PRINT")
                        tsbtin.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "UNPOST")
                        tsbtboghi.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "POST")
                        tsbtghiso.Enabled = true;
                }
            }
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                {
                    ledv.Properties.ReadOnly = false;
                }
                cbldt.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                txtngh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
            }
            else
            {
                ledv.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                txtngh.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
            }
            ledv.Focus();
        }

        private void cbldt_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable da = new DataTable();
            DataTable temp = new DataTable();
            temp.Columns.Add("Mã đối tượng");
            temp.Columns.Add("Tên đối tượng");

            if (cbldt.EditValue.ToString() == "Khách hàng")
                da = gen.GetTable("select * from AccountingObject where IsCustomer='True' order by AccountingObjectCode");
            else if (cbldt.EditValue.ToString() == "Nhà cung cấp")
                da = gen.GetTable("select * from AccountingObject where IsVendor='True' order by AccountingObjectCode");
            else
                da = gen.GetTable("select * from AccountingObject where IsEmployee='True' order by AccountingObjectCode");

            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            ledt.Properties.DataSource = temp;
            ledt.Properties.DisplayMember = "Mã đối tượng";
            ledt.Properties.ValueMember = "Mã đối tượng";
        }

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                txtname.Text = da.Rows[0][2].ToString();
                if (cbldt.EditValue.ToString() == "Nhân viên")
                {
                    DataTable temp = new DataTable();
                    temp = gen.GetTable("select BranchName from AccountingObject a, Branch b where a.BranchID=b.BranchID and AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                    txtdc.Text = temp.Rows[0][0].ToString();
                }
                else
                {
                    txtdc.Text = da.Rows[0][7].ToString();
                }
                txtmst.Text = da.Rows[0][14].ToString();
            }
            catch { }
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    if (pt == "pnk")
                        pnk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,txtpnv,tsbttruoc,tsbtsau);
                    else
                        pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,txtpnv,tsbttruoc,tsbtsau);
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Mã hàng")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select * from InventoryItem where Parent in (select InventoryItemID from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() + "')");
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tên hàng").ToString() == "")
                {
                    string tenhang = gen.GetString("select InventoryItemName from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() + "'");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], tenhang);
                    gridView2.AddNewRow();
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], da.Rows[0][2].ToString());
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tên hàng"], da.Rows[0][4].ToString());
                }
                else 
                {
                    string tenhang = gen.GetString("select InventoryItemName from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() + "'");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], tenhang);
                    gridView2.SetRowCellValue(gridView1.FocusedRowHandle, gridView2.Columns["Mã hàng"], da.Rows[0][2].ToString());
                    gridView2.SetRowCellValue(gridView1.FocusedRowHandle, gridView2.Columns["Tên hàng"], da.Rows[0][4].ToString());
                }
                gridView2.UpdateCurrentRow();
            }
            else if (e.Column.FieldName == "Số lượng")
            {
                gridView2.SetRowCellValue(gridView1.FocusedRowHandle, gridView2.Columns["Số lượng"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                gridView2.UpdateCurrentRow();
            }
            if (pt == "pxk")
            {
                if (e.Column.FieldName == "Số lượng quy đổi" || e.Column.FieldName == "Đơn giá")
                {
                    if (caseup == "1")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], (a * b).ToString());
                        }
                    }
                }
                else if (e.Column.FieldName == "Thành tiền" || e.Column.FieldName == "Chi phí")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a / 100), 0).ToString());
                    }
                    Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                    Double chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                    txtcth.Text = String.Format("{0:n0}", thanhtien + chiphi);
                    if (caseup == "2")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Chiết khấu")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a / 100), 0).ToString());
                        Double ck = Double.Parse(gridView1.Columns["Tiền CK"].SummaryText);
                        txtck.Text = String.Format("{0:n0}", ck);
                    }
                }
            }
        }

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView2.UpdateCurrentRow();
            if (e.Column.FieldName == "Số lượng")
            {
                if (caseup == "1")
                {
                    if (gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                        gridView2.SetRowCellValue(gridView1.FocusedRowHandle, gridView2.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                    }
                }
            }
           else if (e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "1")
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString() != "" && gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Đơn giá").ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {
                if (caseup == "2")
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString() != "" && gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Thành tiền").ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], Math.Round((b / a),2).ToString());
                    }
                }
            }
        }

        private void dongia_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "1";
        }
        private void soluongqd_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "1";
        }
        private void soluong_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "1";
        }
        private void thanhtien_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "2";
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView1.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                gridView2.DeleteRow(gridView1.FocusedRowHandle);
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                
            }
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            if (pt == "pnk")
                pnk.checkpnk(active, role, this, gridView1, gridView2, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, txtpnv,lenv,tsbttruoc,tsbtsau);
            else
                pxk.checkpxk(active, role, this, gridView1, gridView2, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid,txtpnv,cbthue,lenv,tsbttruoc,tsbtsau);
            refreshrole();
            click = "true";
            change();
            click = "false";
            if (active == "1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            this.Text = "Sửa phiếu nhập kho";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();

            cbldt.SelectedIndex = 0;
            ledt.EditValue =null;
            txtctg.Text = "";
            txtldn.Text = "";
            txtngh.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            txtptvc.Text = "";
            txtmst.Text = "";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            txtcth.Text = "0";
            txtck.Text = "0";
            if (pt == "pnk")
            {
                pnk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,txtpnv,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu nhập kho LPG";
            }
            else
            {
                pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,txtpnv,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu xuất kho LPG";
            }
            change();
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }

            while (gridView2.RowCount > 0)
            {
                gridView2.DeleteRow(0);
            }
            
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            if (pt == "pnk")
                gen.ExcuteNonquery("update INInward set Posted='True' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INOutward set Posted='True' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Ghi sổ','" + txtsct.Text + "')");
        }

        private void tsbtboghi_Click(object sender, EventArgs e)
        {
            tsbtghiso.Visible = true;
            tsbtboghi.Visible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][3].ToString() == "EDIT")
                    tsbtsua.Enabled = true;
            }
            if (pt == "pnk")
                gen.ExcuteNonquery("update INInward set Posted='False' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INOutward set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pnk")
                refreshpnk();
            else
                refreshpxk();
            change();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pnk")
            {
                pnk.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnk();
            }
            else
            {
                pxk.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }

        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pnk")
            {
                pnk.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnk();
            }
            else
            {
                pxk.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pnk")
            {
                pnk.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnk();
            }
            else
            {
                pxk.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pnk")
            {
                pnk.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnk();
            }
            else
            {
                pxk.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            
            Double cth, thue, gtgt, tong, ck;
            cth = Double.Parse(txtcth.Text);
            try
            {
                ck = Double.Parse(txtck.Text);
            }
            catch { ck = 0; }
            cth = cth - ck;
            try
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = (cth / 100) * thue;
            }
            catch
            {
                gtgt = 0;
            }
            tong = cth + gtgt;
            txttthue.Text = String.Format("{0:n0}", gtgt);
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
            
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", ""));
            }
            catch { }
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth, thue, gtgt, tong, ck;
                cth = Double.Parse(txtcth.Text);
                ck = Double.Parse(txtck.Text);
                cth = cth - ck;
                if (cbthue.Text != "" && cbthue.Text != "0")
                {
                    thue = Double.Parse(cbthue.Text);
                    gtgt = (cth / 100) * thue;
                }
                else
                {
                    gtgt = 0;
                }

                tong = cth + gtgt;
                txttthue.Text = String.Format("{0:n0}", gtgt);
                txttc.Text = String.Format("{0:n0}", tong);
                if (cth == 0)
                    lbtienchu.Text = "";
            }
            catch { }
        }

        private void lenv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select * from AccountingObject where AccountingObjectCode='" + lenv.EditValue.ToString() + "'");
                txtnv.Text = da.Rows[0][2].ToString();
            }
            catch
            {
                txtnv.Text = "";
            }
        }

        private void txtck_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong, ck;
            cth = Double.Parse(txtcth.Text);
            ck = Double.Parse(txtck.Text);
            cth = cth - ck;
            try
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = (cth / 100) * thue;
            }
            catch
            {
                gtgt = 0;
            }

            tong = cth + gtgt;
            txttthue.Text = String.Format("{0:n0}", gtgt);
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txttc_EditValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", "").Replace("-", ""));
            }
            catch { }
        }

        private void tsbtin_ButtonClick(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt+"lpg");
            F.getrole(role);
            F.getcongty("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            F.ShowDialog();
        }

        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                Frm_chonhoadon F = new Frm_chonhoadon();
                F.gettsbt("khachhang");
                F.getmk("png");
                F.getPNG(this);
                F.ShowDialog();
            }
        }
        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                Frm_chonhoadon F = new Frm_chonhoadon();
                F.getmk("png");
                F.getPNG(this);
                F.gettsbt("hanghoa");
                F.ShowDialog();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pt == "pxk") 
                hdbh.tsbthdbhchuyen("0",role,roleid,subsys,ngaychungtu, userid, branchid,ledt.EditValue.ToString(),ledv.EditValue.ToString(),khach,hang,lenv.EditValue.ToString(),"");
            else
                hdmh.tsbthdbhchuyen("0", role, roleid, subsys, ngaychungtu, userid, branchid, ledt.EditValue.ToString(),ledv.EditValue.ToString(),khach,hang);
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }
    }
}