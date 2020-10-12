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
    public partial class Frm_hoadonxhgb : DevExpress.XtraEditors.XtraForm
    {
        public Frm_hoadonxhgb()
        {
            InitializeComponent();
        }

        gencon gen = new gencon();
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        hoadonxhgb hdmh = new hoadonxhgb();
        doiso doi = new doiso();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup, roleid, subsys, click;
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
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
        public void refreshhdmh()
        {
            hdmh.loadpck(active,role,gridControl3, gridView3, txtsct, ledv, denct, denht, tkco, soluong, soluongquydoi, this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, dongia, thanhtien, txtcth, chiphi, txtnhd, txtms, txtkhhd, txtshd,cbthue,txthtt,txthttt,txttthue,tsbttruoc,tsbtsau,khach,hang,txtquyen,ledvx);
        }
        public void getdoituong(string a, string check)
        {
            if (check == "1")
                ledt.EditValue = a;
            else if (check == "2")
            {
                try
                {
                    string temp = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Tên hàng").ToString();
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Mã hàng"], a);
                }
                catch
                {
                    gridView3.AddNewRow();
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Mã hàng"], a);
                }
            }
            else if (check == "3")
                gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Mã khách"], a);
        }



        private void Frm_hoadonxhgb_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
            {
                if (tsbtadd.Enabled == true)
                    tsbtadd_Click(this, e);
            }
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (tsbtsua.Enabled == true)
                    tsbtsua_Click(this, e);
            }
            else if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
            {
                if (tsbtcat.Enabled == true)
                    tsbtcat_Click(this, e);
            }
            else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
            {
                if (tsbtnap.Enabled == true)
                    tsbtnap_Click(this, e);
            }
            else if (e.KeyCode == Keys.I && e.Modifiers == Keys.Control)
            {
                if (tsbtin.Enabled == true)
                    tsbtin_Click(this, e);
            }
            else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            {
                if (tsbtghiso.Enabled == true)
                    tsbtghiso_Click(this, e);
            }
            else if (e.KeyCode == Keys.B && e.Modifiers == Keys.Control)
            {
                if (tsbtboghi.Enabled == true)
                    tsbtboghi_Click(this, e);
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                if (tsbttruoc.Enabled == true)
                    tsbttruoc_ButtonClick(this, e);
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                if (tsbtsau.Enabled == true)
                    tsbtsau_ButtonClick(this, e);
            }
            else if (e.KeyCode == Keys.End)
            {
                if (tsbtsau.Enabled == true)
                    tsbtsaucung_Click(this, e);
            }
            else if (e.KeyCode == Keys.Home)
            {
                if (tsbttruoc.Enabled == true)
                    tsbttruocnhat_Click(this, e);
            }
        }

        private void Frm_hoadonxhgb_Load(object sender, EventArgs e)
        {
            refreshrole();
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshhdmh();
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
                if(active=="0")
                    ledv.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                gridView3.OptionsBehavior.Editable = true;
                gridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                txtldn.Properties.ReadOnly = false;
                txtms.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                txthtt.Properties.ReadOnly = false;
                txthttt.Properties.ReadOnly = false;
                txtnhd.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
            }
            else
            {
                ledv.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                gridView3.OptionsBehavior.Editable = false;
                gridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                denht.Properties.ReadOnly = true;
                txtms.Properties.ReadOnly = true;
                txtkhhd.Properties.ReadOnly = true;
                txthttt.Properties.ReadOnly = true;
                txtshd.Properties.ReadOnly = true;
                txtnhd.Properties.ReadOnly = true;
                txthtt.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
            }
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            hdmh.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            hdmh.loadhb(gridControl1, gridView1,active,ngaychungtu,ledv.EditValue.ToString(),branchid);
            hdmh.delete(gridView3);
            txtcth.Text = "0";
        }

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                txtname.Text = da.Rows[0][2].ToString();
                txtdc.Text = da.Rows[0][7].ToString();
            }
            catch { }*/
            try
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtname.Text = khach.Rows[i][2].ToString();
                        txtdc.Text = khach.Rows[i][3].ToString();
                        return;
                    }
                }
            }
            catch { }
        }

        private void gridView3_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView3.UpdateCurrentRow();
            if (e.Column.FieldName == "Mã hàng")
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        return;
                    }
                }
            }
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "1";

                    for (int i = 0; i < hang.Rows.Count; i++)
                    {
                        if (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            Double quydoi = Double.Parse(hang.Rows[i][5].ToString());
                            Double sl = Double.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Số lượng").ToString());
                            gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Số lượng quy đổi"], Math.Round((sl * quydoi), 2).ToString());
                            return;
                        }
                    }
                }
                catch { }
            }
            else  if (e.Column.FieldName == "Số lượng quy đổi" || e.Column.FieldName == "Đơn giá")
                {
                    if (caseup == "1")
                    {
                        if (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Đơn giá").ToString() != "")
                        {
                            Double a = Double.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Đơn giá").ToString());
                            gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                        }
                    }
                }
                else if (e.Column.FieldName == "Thành tiền" || e.Column.FieldName == "Chi phí")
                {
                    Double thanhtien = Double.Parse(gridView3.Columns["Thành tiền"].SummaryText);
                    Double chiphi = Double.Parse(gridView3.Columns["Chi phí"].SummaryText);
                    txtcth.Text = String.Format("{0:n0}", thanhtien + chiphi);
                    if (caseup == "2")
                    {
                        if (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Thành tiền").ToString());
                            gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
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
        private void thanhtien_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "2";
        }

        private void gridView3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView3.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                gridView3.DeleteRow(gridView3.FocusedRowHandle);
                txtcth.Text = gridView3.Columns["Thành tiền"].SummaryText;
            }
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Nhấn Yes để chương trình tự động tổng hợp hóa đơn.", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                while (gridView3.RowCount > 1)
                {
                    gridView3.DeleteRow(0);
                }
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (i < 10)
                    {
                        gridView3.AddNewRow();
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Số lượng"], gridView1.GetRowCellValue(i, "Số lượng").ToString());
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Số lượng quy đổi"], gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                        caseup = "2";
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Thành tiền"], gridView1.GetRowCellValue(i, "Thành tiền").ToString());
                    }
                }
                xtraTabControl1.SelectedTabPage = xtraTabPage3;
            }
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            hdmh.checkpck(active, role, this, gridView3, ledt, ledv, txtsct, txtname, txtdc, txtldn, denct, denht, ngaychungtu, cbthue, userid, branchid, txtms, txtkhhd, txtshd, txtnhd, txthtt, txthttt, txttthue, tsbttruoc, tsbtsau,txtquyen,ledvx);
            refreshrole();
            click = "true";
            change();
            click = "false";
            if (active == "1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong;
            cth = Double.Parse(txtcth.Text);
            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong;
            cth = Double.Parse(txtcth.Text);
            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt;
            txttthue.EditValue =  gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth, gtgt, tong;
                try
                {
                    cth = Double.Parse(txtcth.Text);
                }
                catch { cth = 0; }

                gtgt = Double.Parse(txttthue.Text);
                tong = cth + gtgt;

                txttc.Text = String.Format("{0:n0}", tong);

                if (cth == 0)
                    lbtienchu.Text = "Không đồng";
            }
            catch { }
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", ""));
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();
            ledt.EditValue = null;
            txtms.Text = "";
            txtldn.Text = "";
            txtkhhd.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            txthttt.Text = "";
            txthtt.EditValue = 0;
            txtshd.Text = "";
            txtnhd.EditValue = DateTime.Parse(ngaychungtu); ;
            txtcth.Text = "0";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            change();
            hdmh.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            hdmh.loadhb(gridControl1, gridView1, active, ngaychungtu, ledv.EditValue.ToString(), branchid);
            hdmh.delete(gridView3);
            this.Text = "Thêm hóa đơn hàng gửi bán";
            
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            this.Text = "Sửa hóa đơn hàng gửi bán";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            gen.ExcuteNonquery("update SSInvoiceBranch set Posted='True' where RefID='" + role + "'");
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
            gen.ExcuteNonquery("update SSInvoiceBranch set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refreshhdmh();
            change();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            //string branch = gen.GetString("select BranchID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            refreshrole();
            hdmh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, branchid,ledv.EditValue.ToString());
            refreshhdmh();
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            hdmh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, branchid,ledv.EditValue.ToString());
            refreshhdmh();
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            hdmh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, branchid,ledv.EditValue.ToString());
            refreshhdmh();
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            hdmh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, branchid,ledv.EditValue.ToString());
            refreshhdmh();
            change();
        }

        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(role);
            F.Show();
        }

        private void tkco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                Frm_chonhoadon F = new Frm_chonhoadon();
                F.getHDGB(this);
                F.getmk("hdgb");
                F.gethang(hang);
                F.gettsbt("hanghoa");
                F.ShowDialog();
            }
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }
    }
}