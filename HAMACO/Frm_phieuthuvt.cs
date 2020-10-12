using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using DevExpress.XtraGrid.Views.Base;

namespace HAMACO
{
    public partial class Frm_phieuthuvt : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        phieuthutmvt pttmvt = new phieuthutmvt();
        phieuthunhvt ptnhvt = new phieuthunhvt();
        phieuchitmvt pctmvt = new phieuchitmvt();
        phieuchinhvt pcnhvt = new phieuchinhvt();
        doiso doi = new doiso();
        gencon gen = new gencon();
        public delegate void ac();
        public ac myac;
        string role, active, pt, ngaychungtu, caseup,roleid,userid,subsys,click,load=null;
        int K = -2;
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getroleid(string a)
        {
            roleid = a;
            return roleid;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
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
        public string getpt(string a)
        {
            pt = a;
            return pt;
        }
        public void refeshpttmvt()
        {
            pttmvt.loadtmvt(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, tkno, tkco, mahang, soluong, dongia, thanhtien,
                       this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue, txtshd, txtkhhd, txtnhd, txtcth,tsbttruoc,tsbtsau,khach,hang);
        }

        public void refeshptnhvt()
        {
            ptnhvt.loadnhvt(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, tkno, tkco, mahang, soluong, dongia, thanhtien,
                       this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue, txtshd, txtkhhd, txtnhd, txtcth, tsbttruoc, tsbtsau, khach, hang);
        }
        public void refeshpctmvt()
        {
            pctmvt.loadctmvt(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, tkno, tkco, mahang, soluong, dongia, thanhtien,
                       this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue, txtshd, txtkhhd, txtnhd, txtcth, tsbttruoc, tsbtsau, khach, hang);
        }
        public void refeshpcnhvt()
        {
            pcnhvt.loadcnhvt(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, tkno, tkco, mahang, soluong, dongia, thanhtien,
                       this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue, txtshd, txtkhhd, txtnhd, txtcth, tsbttruoc, tsbtsau, khach, hang);
        }
        public Frm_phieuthuvt()
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

        private void Frm_phieuthuvt_KeyUp(object sender, KeyEventArgs e)
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

        private void Frm_phieuthuvt_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole();
            if (pt == "pttmvt")
                refeshpttmvt();
            else if (pt == "ptnhvt")
            {
                labelControl1.Text = "Phiếu thu ngân hàng bán vật tư";
                refeshptnhvt();
            }
            else if (pt == "pctmvt")
            {
                labelControl1.Text = "Phiếu chi tiền mặt mua vật tư";
                refeshpctmvt();
            }
            else if (pt == "pcnhvt")
            {
                labelControl1.Text = "Phiếu chi ngân hàng mua vật tư";
                refeshpcnhvt();
            }
            change();
            load = "0";
            radioGroup1.SelectedIndex = -1;
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

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView1.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = gridView1.FocusedRowHandle;
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                    if (gridView1.FocusedColumn == gridView1.Columns[0])
                        gridView1.FocusedColumn = gridView1.Columns[1];
                    else if (gridView1.FocusedColumn == gridView1.Columns[1])
                        gridView1.FocusedColumn = gridView1.Columns[2];
                    else if (gridView1.FocusedColumn == gridView1.Columns[2])
                        gridView1.FocusedColumn = gridView1.Columns[3];
                    else if (gridView1.FocusedColumn == gridView1.Columns[3])
                        gridView1.FocusedColumn = gridView1.Columns[4];
                    else if (gridView1.FocusedColumn == gridView1.Columns[4])
                        gridView1.FocusedColumn = gridView1.Columns[5];
                    else if (gridView1.FocusedColumn == gridView1.Columns[5])
                        gridView1.FocusedColumn = gridView1.Columns[0];
            }
        }
        
        private void txtldn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtctg.Focus();
        }
        private void cbthue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtkhhd.Focus();
        }
        private void txtkhhd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtshd.Focus();
        }
        private void txtctg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbthue.Focus();
        }
        private void txtshd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtnhd.Focus();
        }
        private void txtnhd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridView1.Focus();
        }
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Tài khoản có" || e.Column.FieldName == "Tài khoản nợ")
            {
                if (gridView1.FocusedRowHandle < 1)
                {
                    if (e.Column.FieldName == "Tài khoản có")
                    {
                        if (pt == "pttmvt") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "1111");
                        else if (pt == "ptnhvt") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "1121");
                    }
                    else
                    {
                        if (pt == "pctmvt") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "1111");
                        else if (pt == "pcnhvt") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "1121");
                    }
                }
                else
                {
                    if (e.Column.FieldName == "Tài khoản có")
                    {
                        if (pt == "pttmvt") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản nợ").ToString());
                        else if (pt == "ptnhvt") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản nợ").ToString());
                    }
                    else
                    {
                        if (pt == "pctmvt") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
                        else if (pt == "pcnhvt") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Số lượng" || e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "1")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], (a * b).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {
                txtcth.Text = gridView1.Columns["Thành tiền"].SummaryText;
                if (caseup == "2")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], (b / a).ToString());
                    }
                }
            }
        }

        private void cbldt_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*DataTable da = new DataTable();
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
            ledt.Properties.ValueMember = "Mã đối tượng";*/
            if (load == null)
            {
                DataTable da = new DataTable();
                DataTable temp = new DataTable();
                temp.Columns.Add("Mã đối tượng");
                temp.Columns.Add("Tên đối tượng");
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    DataRow dr = temp.NewRow();
                    dr[0] = khach.Rows[i][1].ToString();
                    dr[1] = khach.Rows[i][2].ToString();
                    temp.Rows.Add(dr);
                }
                ledt.Properties.DataSource = temp;
                ledt.Properties.DisplayMember = "Mã đối tượng";
                ledt.Properties.ValueMember = "Mã đối tượng";
                ledt.Properties.PopupWidth = 400;
            }
        }

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                /*DataTable da = new DataTable();
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
                }*/
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

        private void tsbtboghi_Click(object sender, EventArgs e)
        {
            tsbtghiso.Visible = true;
            tsbtboghi.Visible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][3].ToString() == "EDIT")
                    tsbtsua.Enabled = true;
            }
            if (pt == "pttmvt")
                gen.ExcuteNonquery("update SUCAReceipt set Posted='False' where RefID='" + role + "'");
            else if (pt == "ptnhvt") gen.ExcuteNonquery("update SUBADeposit set Posted='False' where RefID='" + role + "'");
            else if (pt == "pctmvt") gen.ExcuteNonquery("update SUCAPayment set Posted='False' where RefID='" + role + "'");
            else if (pt == "pcnhvt") gen.ExcuteNonquery("update SUBATransfer set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            if (pt == "pttmvt")
                this.Text = "Sửa phiếu thu tiền mặt bán vật tư";
            else if (pt == "ptnhvt") this.Text = "Sửa phiếu thu ngân hàng bán vật tư";
            else if (pt == "pctmvt") this.Text = "Sửa phiếu chi tiền mặt mua vật tư";
            else if (pt == "pcnhvt") this.Text = "Sửa phiếu chi ngân hàng mua vật tư";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (pt == "pttmvt")
                pttmvt.checkpttmvt(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txtshd, txtkhhd, txtnhd,userid,tsbttruoc,tsbtsau);
            else if (pt == "ptnhvt") ptnhvt.checkptnhvt(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txtshd, txtkhhd, txtnhd,userid,tsbttruoc,tsbtsau);
            else if (pt == "pctmvt") pctmvt.checkpctmvt(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txtshd, txtkhhd, txtnhd,userid,tsbttruoc,tsbtsau);
            else if (pt == "pcnhvt") pcnhvt.checkpcnhvt(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txtshd, txtkhhd, txtnhd,userid,tsbttruoc,tsbtsau);
            refreshrole();
            click = "true";
            change();
            click = "false";
            if (active == "1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();
            cbldt.SelectedIndex = 0;
            ledt.EditValue = "3";
            txtctg.Text = "";
            txtldn.Text = "";
            txtnn.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            txtnhd.Text = "";
            txtshd.Text = "";
            txtkhhd.Text = "";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Now;
            txtcth.Text = "0";
            if (pt == "pttmvt")
            {
                pttmvt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu thu tiền mặt bán vật tư";
            }
            if (pt == "ptnhvt")
            {
                ptnhvt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu thu ngân hàng bán vật tư";
            }
            if (pt == "pctmvt")
            {
                pctmvt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu chi tiền mặt mua vật tư";
            }
            if (pt == "pcnhvt")
            {
                pcnhvt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu chi ngân hàng mua vật tư";
            }
            change();
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }
            
        }

        private void txtsct_EditValueChanged(object sender, EventArgs e)
        {
            if (txtsct.Text.Length == 21)
            {
                if (pt == "pttmvt")
                {
                    try
                    {
                        string ma = gen.GetString("select * from SUCAReceipt where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshpttmvt();
                    }
                    catch
                    {
                        if (active == "1")
                        {
                            MessageBox.Show("Không tìm thấy số phiếu " + txtsct.Text);
                        }
                    }
                }
                else if (pt == "ptnhvt")
                {
                    try
                    {
                        string ma = gen.GetString("select * from SUBADeposit where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshptnhvt();
                    }
                    catch
                    {
                        if (active == "1")
                        {
                            MessageBox.Show("Không tìm thấy số phiếu " + txtsct.Text);
                        }
                    }
                }
                else if (pt == "pctmvt")
                {
                    try
                    {
                        string ma = gen.GetString("select * from SUCAPayment  where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshpctmvt();
                    }
                    catch
                    {
                        if (active == "1")
                        {
                            MessageBox.Show("Không tìm thấy số phiếu " + txtsct.Text);
                        }
                    }
                }
                else if (pt == "pcnh")
                {
                    try
                    {
                        string ma = gen.GetString("select * from SUBATransfer  where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshpcnhvt();
                    }
                    catch
                    {
                        if (active == "1")
                        {
                            MessageBox.Show("Không tìm thấy số phiếu " + txtsct.Text);
                        }
                    }
                }
                change();
            }
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            if (pt == "pttmvt")
            {
                gen.ExcuteNonquery("update SUCAReceipt set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "ptnhvt")
            {
                gen.ExcuteNonquery("update SUBADeposit set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "pctmvt")
            {
                gen.ExcuteNonquery("update SUCAPayment set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "pcnhvt")
            {
                gen.ExcuteNonquery("update SUBATransfer set Posted='True' where RefID='" + role + "'");
            }
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Ghi sổ','" + txtsct.Text + "')");
        }

        private void dongia_EditValueChanged(object sender, EventArgs e)
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

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong;
            cth = Double.Parse(txtcth.Text);
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
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", ""));
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong;
            cth = Double.Parse(txtcth.Text);
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
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pttmvt")
                refeshpttmvt();
            else if (pt == "ptnhvt") refeshptnhvt();
            else if (pt == "pctmvt") refeshpctmvt();
            else if (pt == "pcnhvt") refeshpcnhvt();
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pttmvt")
            {
                pttmvt.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpttmvt();
            }
            else if (pt == "ptnhvt")
            {
                ptnhvt.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshptnhvt();
            }
            else if (pt == "pctmvt")
            {
                pctmvt.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpctmvt();
            }
            else if (pt == "pcnhvt")
            {
                pcnhvt.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpcnhvt();
            }
            change();
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
                txtnn.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                txtnhd.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                ledv.Focus();
            }
            else
            {
                ledv.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtnn.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                txtnhd.Properties.ReadOnly = true;
                txtkhhd.Properties.ReadOnly = true;
                txtshd.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
            }
            ledv.Focus();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pttmvt")
            {
                pttmvt.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpttmvt();
            }
            else if (pt == "ptnhvt")
            {
                ptnhvt.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshptnhvt();
            }
            else if (pt == "pctmvt")
            {
                pctmvt.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpctmvt();
            }
            else if (pt == "pcnhvt")
            {
                pcnhvt.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpcnhvt();
            }
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pttmvt")
            {
                pttmvt.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpttmvt();
            }
            else if (pt == "ptnhvt")
            {
                ptnhvt.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshptnhvt();
            }
            else if (pt == "pctmvt")
            {
                pctmvt.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpctmvt();
            }
            else if (pt == "pcnhvt")
            {
                pcnhvt.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpcnhvt();
            }
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pttmvt")
            {
                pttmvt.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpttmvt();
            }
            else if (pt == "ptnhvt")
            {
                ptnhvt.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshptnhvt();
            }
            else if (pt == "pctmvt")
            {
                pctmvt.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpctmvt();
            }
            else if (pt == "pcnhvt")
            {
                pcnhvt.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refeshpcnhvt();
            }
            change();
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    if (pt == "pttmvt")
                        pttmvt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                    else if (pt == "ptnhvt") ptnhvt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                    else if (pt == "pctmvt") pctmvt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                    else if (pt == "pcnhvt") pcnhvt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                }
            }
            catch { }
        }

        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = -1;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }
        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = gridView1.FocusedRowHandle;
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
        }

        private void txtctg_EditValueChanged(object sender, EventArgs e)
        {
            if (txtctg.Text.Length == 21 && tsbtcat.Enabled==true)
            {
                DataTable temp = new DataTable();
                while (gridView1.RowCount > 1)
                {
                    gridView1.DeleteRow(0);
                }
                if (pt == "pttmvt")
                    temp = gen.GetTable("select  DebitAccount,1111,InventoryItemCode,Quantity,a.UnitPrice,Amount from INOutwardSUDetail a,INOutwardSU b,InventoryItem c where a.InventoryItemID=c.InventoryItemID and a.RefID=b.RefID and RefNo='" + txtctg.Text + "' order by SortOrder");
                else if (pt == "pctmvt")
                    temp = gen.GetTable("select  CreditAccount,1111,InventoryItemCode,Quantity,a.UnitPrice,Amount from INInwardSUDetail a,INInwardSU b,InventoryItem c where a.InventoryItemID=c.InventoryItemID and a.RefID=b.RefID and RefNo='" + txtctg.Text + "' order by SortOrder");
                else if (pt == "ptnhvt")
                    temp = gen.GetTable("select  DebitAccount,11211,InventoryItemCode,Quantity,a.UnitPrice,Amount from INOutwardSUDetail a,INOutwardSU b,InventoryItem c where a.InventoryItemID=c.InventoryItemID and a.RefID=b.RefID and RefNo='" + txtctg.Text + "' order by SortOrder");
                else if (pt == "pcnhvt")
                    temp = gen.GetTable("select  CreditAccount,11211,InventoryItemCode,Quantity,a.UnitPrice,Amount from INInwardSUDetail a,INInwardSU b,InventoryItem c where a.InventoryItemID=c.InventoryItemID and a.RefID=b.RefID and RefNo='" + txtctg.Text + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0], temp.Rows[i][0].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], temp.Rows[i][1].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2], temp.Rows[i][2].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3], temp.Rows[i][3].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4], temp.Rows[i][4].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5], temp.Rows[i][5].ToString());
                }
            }
        }

        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt(pt);
            F.ShowDialog();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchLookUpEdit1.Properties.View.Columns.Clear();
            if (radioGroup1.SelectedIndex == 0)
            {
                DataTable temp = new DataTable();
                temp.Columns.Add("Mã khách");
                temp.Columns.Add("Tên khách");
                temp.Columns.Add("Địa chỉ");
                temp.Columns.Add("Mã số thuế");
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    DataRow dr = temp.NewRow();
                    dr[0] = khach.Rows[i][1].ToString();
                    dr[1] = khach.Rows[i][2].ToString();
                    dr[2] = khach.Rows[i][3].ToString();
                    dr[3] = khach.Rows[i][4].ToString();
                    temp.Rows.Add(dr);
                }
                searchLookUpEdit1.Properties.DataSource = temp;
                searchLookUpEdit1.Properties.DisplayMember = "Mã khách";
                searchLookUpEdit1.Properties.ValueMember = "Mã khách";
                searchLookUpEdit1.Focus();
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                DataTable temp = new DataTable();
                temp.Columns.Add("Mã hàng");
                temp.Columns.Add("Tên hàng hóa");
                temp.Columns.Add("Đơn vị tính");
                temp.Columns.Add("Đơn vị quy đổi");
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    DataRow dr = temp.NewRow();
                    dr[0] = hang.Rows[i][1].ToString();
                    dr[1] = hang.Rows[i][2].ToString();
                    dr[2] = hang.Rows[i][3].ToString();
                    dr[3] = hang.Rows[i][4].ToString();
                    temp.Rows.Add(dr);
                }
                searchLookUpEdit1.Properties.DataSource = temp;
                searchLookUpEdit1.Properties.DisplayMember = "Mã hàng";
                searchLookUpEdit1.Properties.ValueMember = "Mã hàng";
                K = gridView1.RowCount;
                searchLookUpEdit1.Focus();
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (K == -1)
            {
                ledt.EditValue = searchLookUpEdit1.EditValue;
                ledt.Focus();
            }
            else if (K != -1)
            {
                try
                {
                    string temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                    gridView1.Focus();
                }
                catch
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                    gridView1.Focus();
                }
            }
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }
    }
}