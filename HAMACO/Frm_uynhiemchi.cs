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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace HAMACO
{
    public partial class Frm_uynhiemchi : DevExpress.XtraEditors.XtraForm
    {
        public Frm_uynhiemchi()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        uynhiemchi unc = new uynhiemchi();
        DataTable danhmuc = new DataTable();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, roleid, subsys;
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable taikhoan = new DataTable();
        DataTable taikhoanchinh = new DataTable();
        DataTable thuhuong = new DataTable();
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
        public string getsub(string a)
        {
            subsys = a;
            return subsys;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
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

        public void refeshunc()
        {
            txtthuhuong.Text = null;
            unc.loadunc(chvay, cechd, active, role, gridControl1, gridView1, txtsct, letk, leth, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien,
                        this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, cbthue, tsbttruoc, tsbtsau, khach, userid, rpmanganh, rpmachiphi, txtunc, searchdanhmuc);
        }
        private void refreshrole()
        {
            tsbtsua.Enabled = false;
            tsbtadd.Enabled = false;
            tsbtcat.Enabled = false;
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
                    else if (dt.Rows[i][3].ToString() == "EDIT")
                        tsbtsua.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "PRINT")
                        tsbtin.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "UNPOST")
                        tsbtboghi.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "POST")
                        tsbtghiso.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "LOCKINPUT")
                        tsbtduyet.Visible = true;
                }
            }
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                    tsbtduyet.Enabled = false;
                else
                    tsbtduyet.Enabled = true;
                ledv.Properties.ReadOnly = false;
                letk.Properties.ReadOnly = false;
                leth.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                txtnn.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                cechd.Properties.ReadOnly = false;
                chvay.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                tsbtin.Enabled = false;
                if (active == "1")
                {
                    tsbtnap.Enabled = true;
                    txtthuhuong.Text = null;
                }
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                ledv.Focus();
            }
            else
            {
                tsbtduyet.Enabled = false;
                ledv.Properties.ReadOnly = true;
                letk.Properties.ReadOnly = true;
                leth.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtnn.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                cechd.Properties.ReadOnly = true;
                chvay.Properties.ReadOnly = true;
                tsbtghiso.Visible = false;
                tsbtghiso.Visible = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                ledv.Focus();
            }
        }

        private void Frm_uynhiemchi_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            taikhoanchinh = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
            taikhoan = gen.GetTable("select Description,AccountNameEnglish from Account where DetailByBankAccount=1 and Description<>'' order by AccountNameEnglish,Description");
            danhmuc = gen.GetTable("select STT,DebitAmout,CreditAmount from DANHMUC where Phieu='pcnh' order by STT");
            refeshunc();
            refreshrole();
            change();
        }

        private void Frm_uynhiemchi_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát và làm mới dữ liệu?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    this.myac();
                }
                catch { }
            }
            else if (dr == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (searchdanhmuc.EditValue == null)
            {
                XtraMessageBox.Show("Bạn phải chọn danh mục trước khi nhập dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                return;
            }

            gridView1.UpdateCurrentRow();

            if (e.Column.FieldName == "Tài khoản có" || e.Column.FieldName == "Tài khoản nợ")
            {
                if (gridView1.FocusedRowHandle < 1)
                {
                    if (e.Column.FieldName == "Tài khoản nợ")
                    {
                        if (letk.EditValue != null)
                            if (letk.EditValue.ToString() != "3")
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gen.GetString("select AccountNumber from Account where Description='" + letk.EditValue.ToString() + "'"));
                    }
                }
                else
                {
                    if (e.Column.FieldName == "Tài khoản nợ")
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
                }

                if (cechd.Checked == true)
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString() == "33311" || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString() == "1331" || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản nợ").ToString() == "1331" || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản nợ").ToString() == "33311")
                        return;

                if (e.Column.FieldName == "Tài khoản có")
                {
                    for (int i = 0; i < danhmuc.Rows.Count; i++)
                        if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString() && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString() == danhmuc.Rows[i][2].ToString())
                            return;
                    for (int i = 0; i < danhmuc.Rows.Count; i++)
                        if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString())
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], danhmuc.Rows[i][2].ToString());
                            return;
                        }
                }
                else if (e.Column.FieldName == "Tài khoản nợ")
                {
                    for (int i = 0; i < danhmuc.Rows.Count; i++)
                        if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString() && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản nợ").ToString() == danhmuc.Rows[i][1].ToString())
                            return;
                    for (int i = 0; i < danhmuc.Rows.Count; i++)
                        if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString())
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], danhmuc.Rows[i][1].ToString());
                            return;
                        }
                }
            }
            if (gridView1.RowCount == 14)
                gridView1.DeleteRow(gridView1.FocusedRowHandle);

        }

        private void rpkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = gridView1.FocusedRowHandle;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }

        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = -1;
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
        }

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                {
                    txtname.Text = khach.Rows[i][2].ToString();
                    txtdc.Text = khach.Rows[i][3].ToString();
                    thuhuong = gen.GetTable("select distinct Contactname as 'Tài khoản', DocumentIncluded as 'Ngân hàng' from BAAccreditative where AccountingObjectID='" + khach.Rows[i][0].ToString() + "' order by DocumentIncluded,Contactname ");
                    leth.Properties.DataSource = thuhuong;
                    leth.Properties.DisplayMember = "Tài khoản";
                    leth.Properties.ValueMember = "Tài khoản";
                    leth.Properties.PopupWidth = 300;

                    try
                    {
                        DataTable temp = gen.GetTable("select AccountingObjectBankAccount,Contactname,JournalMemo from BAAccreditative where AccountingObjectID='" + khach.Rows[i][0].ToString() + "'  order by RefNo DESC");
                        letk.EditValue = temp.Rows[0][0].ToString();
                        leth.EditValue = temp.Rows[0][1].ToString();
                        txtldn.Text = temp.Rows[0][2].ToString();
                    }
                    catch
                    {}
                    return;
                }
            }
        }

        private void letk_EditValueChanged(object sender, EventArgs e)
        {
            vietcombank.Enabled = false;
            vietinbank.Enabled = false;
            sacombank.Enabled = false;
            eximbank.Enabled = false;
            bidv.Enabled = false;
            mbbank.Enabled = false;
            hdbank.Enabled = false;

            for (int i = 0; i < taikhoan.Rows.Count; i++)
                if (letk.EditValue.ToString() == taikhoan.Rows[i][0].ToString())
                {
                    txtnn.Text = taikhoan.Rows[i][1].ToString();
                    if (taikhoan.Rows[i][1].ToString().IndexOf("Công Thương") >= 0)
                        vietinbank.Enabled = true;
                    else if (taikhoan.Rows[i][1].ToString().IndexOf("Đầu tư") >= 0)
                        bidv.Enabled = true;
                    else if (taikhoan.Rows[i][1].ToString().IndexOf("Eximbank") >= 0)
                        eximbank.Enabled = true;
                    else if (taikhoan.Rows[i][1].ToString().IndexOf("Sacombank") >= 0)
                        sacombank.Enabled = true;
                    else if (taikhoan.Rows[i][1].ToString().IndexOf("MB Bank") >= 0)
                        mbbank.Enabled = true;
                    else if (taikhoan.Rows[i][1].ToString().IndexOf("HD Bank") >= 0)
                        hdbank.Enabled = true;
                    else
                        vietcombank.Enabled = true;
                    return;
                }
        }

        private void leth_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < thuhuong.Rows.Count; i++)
                if (leth.EditValue.ToString() == thuhuong.Rows[i][0].ToString())
                {
                    txtctg.Text = thuhuong.Rows[i][1].ToString();
                    return;
                }
        }

        private void Bthien_Click(object sender, EventArgs e)
        {
            txtthuhuong.Visible = true;
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            if (txtldn.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn chưa nhập lý do lập ủy nhiệm chi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtldn.Focus();
                return;
            }
            ledt.Focus();
            unc.checkunc(active, role, this, gridView1, ledt, ledv, letk,leth, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso,chvay, tsbtcat,  tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue,userid,txtthuhuong,tsbttruoc,tsbtsau,"0");
            refreshrole();
            change();             
            if(active=="1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
        }

        private void cechd_CheckedChanged(object sender, EventArgs e)
        {
            if (cechd.Checked == true)
            {
                gridView1.Columns[5].Visible = true;
                gridView1.Columns[4].Visible = true;
                gridView1.Columns[3].Visible = true;
                gridView1.Columns[2].Visible = true;
                gridView1.Focus();
            }
            else
            {
                gridView1.Columns[2].Visible = false;
                gridView1.Columns[3].Visible = false;
                gridView1.Columns[4].Visible = false;
                gridView1.Columns[5].Visible = false;
                gridView1.Focus();
            }
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            tsbtcat.Enabled = true;
            change();
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
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex != -1)
            {
                searchLookUpEdit1.Properties.View.Columns.Clear();
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
                    string temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], searchLookUpEdit1.EditValue);
                    gridView1.Focus();
                }
                catch
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], searchLookUpEdit1.EditValue);
                    gridView1.Focus();
                }
            }
        }

        private void view_FocusedRowChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã khách").ToString() == khach.Rows[i][1].ToString())
                    {
                        textEdit2.Text = khach.Rows[i][2].ToString();
                        break;
                    }
            }
            catch {textEdit2.Text = null;}

            try
            {
                for (int i = 0; i < taikhoanchinh.Rows.Count; i++)
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString() == taikhoanchinh.Rows[i][0].ToString())
                    {
                        textEdit1.Text = taikhoanchinh.Rows[i][0].ToString() + " - " + taikhoanchinh.Rows[i][1].ToString();
                        break;
                    }
            }
            catch{ textEdit1.Text = null; }

            try
            {
                for (int i = 0; i < taikhoanchinh.Rows.Count; i++)
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() == taikhoanchinh.Rows[i][0].ToString())
                    {
                        textEdit3.Text = taikhoanchinh.Rows[i][0].ToString() + " - " + taikhoanchinh.Rows[i][1].ToString();
                        break;
                    }
            }
            catch { textEdit3.Text = null; }
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refeshunc();
            change();
        }

        private void nphhd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                if (gridView1.FocusedRowHandle > 0)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Ngày phát hành HĐ").ToString() != "")
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Ngày phát hành HĐ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Ngày phát hành HĐ").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số hóa đơn"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Số hóa đơn").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Loại hóa đơn"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Loại hóa đơn").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Ký hiệu hóa đơn"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Ký hiệu hóa đơn").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Mã khách").ToString());
                    gridView1.FocusedColumn = gridView1.Columns["Số tiền"];
                }
            }
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            gen.ExcuteNonquery("update BAAccreditative set Posted='True' where RefID='" + role + "'");
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
            gen.ExcuteNonquery("update BAAccreditative set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            txtunc.Text = "";
            refreshrole();
            change();
            ledt.EditValue = "3";
            letk.EditValue = "3";
            leth.EditValue = "3";
            ledv.ItemIndex = 0;
            txtctg.Text = "";
            txtldn.Text = "";
            txtnn.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            txtthuhuong.Text = "";
            cbthue.EditValue = null;
            chvay.Checked = false;
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Now;           
            unc.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);
            cechd.Checked = false;
            chvay.Checked = false;
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            unc.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, userid);
            refeshunc();
            change();
        }
        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            unc.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, userid);
            refeshunc();
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            unc.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, userid);
            refeshunc();
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            unc.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, userid);
            refeshunc();
            change();
        }

        private void vietcombank_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("tsbtuncvietcombank");
            F.ShowDialog();
        }

        private void vietinbank_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("tsbtuncvietinbank");
            F.ShowDialog();
        }

        private void sacombank_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("tsbtuncsacombank");
            F.ShowDialog();
        }

        private void eximbank_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("tsbtunceximbank");
            F.ShowDialog();
        }

        private void bidv_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("tsbtuncbidv");
            F.ShowDialog();
        }

        private void uncpc_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("uncpc");
            F.ShowDialog();
        }

        private void sacombanknew_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("tsbtuncsacombanknew");
            F.ShowDialog();
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }

        private void mbbank_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("tsbtuncmbbank");
            F.ShowDialog();

        }

        private void tsbtduyet_Click(object sender, EventArgs e)
        {
            if (txtldn.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn chưa nhập lý do lập ủy nhiệm chi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtldn.Focus();
                return;
            }
            ledt.Focus();
            unc.checkunc(active, role, this, gridView1, ledt, ledv, letk, leth, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, chvay, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, txtthuhuong, tsbttruoc, tsbtsau, "1");
            refreshrole();
            change();
            if (active == "1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
        }

        private void hdbank_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt("tsbtunchdbank");
            F.ShowDialog();
        }

        private void searchdanhmuc_EditValueChanged(object sender, EventArgs e)
        {
            if (tsbtcat.Enabled == true)
            {
                while (gridView1.RowCount > 1)
                {
                    gridView1.DeleteRow(0);
                }
            }
        }
    }
}