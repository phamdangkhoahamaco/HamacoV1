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
    public partial class Frm_hdmhkpn : DevExpress.XtraEditors.XtraForm
    {
        public Frm_hdmhkpn()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
        hdmhkpn pxk = new hdmhkpn();
        public delegate void ac();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup, click = null, roleid, subsys, load = null,thue=null,phieu;
        int K = -2;

        public string getphieu(string a)
        {
            phieu = a;
            return phieu;
        }

        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
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
        public void refreshpxk()
        {
            pxk.loadpxk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtptvc, dongia, thanhtien, txtcth, cbthue, le1562, chiphi, tsbttruoc, tsbtsau, txtnhd, txthtt, txthttt, txtms, txtkhhd, txtshd, txtdc, txttthue, txtspx, khach, hang, txtname, txtmst, cbtkdu, txtddh, chhnk, txtck, txttaixe, txtgn);
            if (active == "1")
                thue = txttthue.Text;
        } 

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
                    {
                        tsbtin.Enabled = true;
                        toolStripSplitButton1.Enabled = true;
                    }
                    else if (dt.Rows[i][3].ToString() == "UNPOST")
                    {
                        tsbtboghi.Enabled = true;
                        tsbtboghi.Visible = true;
                    }
                    else if (dt.Rows[i][3].ToString() == "POST")
                    {
                        tsbtghiso.Enabled = true;
                        tsbtghiso.Visible = true;
                    }
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
                le1562.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                txtctg.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                txtms.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                txthtt.Properties.ReadOnly = false;
                txthttt.Properties.ReadOnly = false;
                txtnhd.Properties.ReadOnly = false;
                ledv.Properties.ReadOnly = false;
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                ledt.Focus();
            }
            else
            {
                ledv.Properties.ReadOnly = true;
                le1562.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                txtctg.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
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
                ledt.Focus();
            }
        }

        private void Frm_hdmhkpn_KeyUp(object sender, KeyEventArgs e)
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

        private void Frm_hdmhkpn_Load(object sender, EventArgs e)
        {
            txthttt.Text = "TM/CK";
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole();
            if (pt == "pxk")
            {
                refreshpxk();
                labelControl1.Text = "Hóa đơn mua hàng kiêm phiếu nhập kho";
            }
            else if (pt == "hdmh")
            {
                refreshpxk();
                txtddh.Text = phieu;
            }
            change();
            load = "0";
            radioGroup1.SelectedIndex = -1;
        }

        private void cbldt_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtname.Text = khach.Rows[i][2].ToString();
                        txtdc.Text = khach.Rows[i][3].ToString();
                        txtmst.Text = khach.Rows[i][4].ToString();
                        return;
                    }
                }
            }
            catch { }
        }

        private void le1562_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (le1562.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtname1562.Text = khach.Rows[i][2].ToString();
                        return;
                    }
                }
            }
            catch { txtname1562.Text = ""; }
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double cth = 0, thue = 0, gtgt = 0, tong = 0, chiphi = 0, chietkhau = 0;
            try
            {
                chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
            }
            catch
            { }
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch {}

            try
            {
                chietkhau = Double.Parse(txtck.Text);
                cth = cth - chietkhau;
            }
            catch { }

            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt + chiphi;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            Double cth=0, thue=0, gtgt=0, tong=0, chiphi=0, chietkhau=0;
            cth = Double.Parse(txtcth.Text);
            try
            {
                chietkhau = Double.Parse(txtck.Text);
                cth = cth - chietkhau;
            }
            catch
            {}
            try
            {
                chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
            }
            catch
            {}

            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt + chiphi;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth = 0, gtgt = 0, tong = 0, chiphi = 0, chietkhau = 0;
                try
                {
                    chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                }
                catch{}
                try
                {
                    cth = Double.Parse(txtcth.Text);
                }
                catch {}
                try
                {
                    chietkhau = Double.Parse(txtck.Text);
                    cth = cth - chietkhau;
                }
                catch{ }

                gtgt = Double.Parse(txttthue.Text);
                tong = cth + gtgt + chiphi;
                txttc.Text = String.Format("{0:n0}", tong);

                if (cth == 0)
                    lbtienchu.Text = "Không đồng";
            }
            catch { }
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txttc.Text) < 0)
                    lbtienchu.Text = "Số tiền viết bằng chữ: (" + doi.ChuyenSo((0 - Double.Parse(txttc.Text.Replace(".", ""))).ToString()) + ")";
                else
                    lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", ""));
            }
            catch
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: Không đồng.";
            }
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    pxk.themsct(ngaychungtu, txtsct, branchid, ledv.EditValue.ToString(), tsbttruoc, tsbtsau, txtms, txtkhhd, txtshd);
                    pxk.themsctpx(ngaychungtu, txtspx, ledv.EditValue.ToString(), branchid);
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
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        return;
                    }
                }

            }
            else if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "1";
                    for (int i = 0; i < hang.Rows.Count; i++)
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double quydoi = Double.Parse(hang.Rows[i][5].ToString());
                            quydoi = Math.Round((sl * quydoi), 2);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], quydoi.ToString());
                        }
                    }
                }
                catch { }
            }

            else if (e.Column.FieldName == "Số lượng quy đổi" || e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "1")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Đơn giá phí")
            {
                if (caseup == "1")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp"], Math.Round((a * b), 0).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền" || e.Column.FieldName == "Bốc xếp")
            {
                Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                txtcth.Text = String.Format("{0:n0}", thanhtien);
                if (caseup == "2")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                    }
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá phí"], Math.Round((b / a), 2).ToString());
                    }
                }
            }

            else if (e.Column.FieldName == "Chi phí")
            {
                Double cth, thue, gtgt, tong, chiphi;
                try
                {
                    chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                }
                catch
                {
                    chiphi = 0;
                }
                try
                {
                    cth = Double.Parse(txtcth.Text);
                }
                catch { cth = 0; }
                if (cbthue.Text != "" && cbthue.Text != "0")
                {
                    thue = Double.Parse(cbthue.Text);
                    gtgt = Math.Round((cth / 100) * thue, 0);
                }
                else
                {
                    gtgt = 0;
                }
                tong = cth + gtgt + chiphi;
                txttthue.EditValue = gtgt;
                txttc.Text = String.Format("{0:n0}", tong);
                if (cth == 0)
                    lbtienchu.Text = "";
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
            else if (K == -3)
            {
                le1562.EditValue = searchLookUpEdit1.EditValue;
                le1562.Focus();
            }
            else if (K != -1)
            {
                    try
                    {
                        string temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tên hàng").ToString();
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

        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = gridView1.FocusedRowHandle;
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
        }
        private void lenv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                le1562.EditValue = null;
            }
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = -3;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
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

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (active == "1" && thue != txttthue.Text)
            {
                DialogResult dr = XtraMessageBox.Show("Thuế được thay từ < " + thue + " đồng > sang < " + txttthue.Text + " đồng >, bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Cancel)
                    return;
            }
            pxk.checkhdmh(active, role, this, gridView1, ledt, cbldt, txtsct, txtname, txtdc, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa,
                tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txtshd, txtkhhd, txtnhd, txthtt, txthttt, txtms, le1562, branchid, userid, txttthue, ledv, tsbttruoc, tsbtsau, txtmst, txtctg, txtptvc, txtspx, cbtkdu, txtddh, chhnk, txtck, txttaixe, txtgn);
            refreshrole();
            click = "true";
            change();
            click = "false";
            if (active == "1")
            {
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
                thue = txttthue.Text;
            }
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            this.Text = "Sửa hóa đơn mua hàng";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            txtddh.Text = "";
            active = "0";
            chhnk.Checked = false;
            refreshrole();
            cbldt.SelectedIndex = 0;
            ledt.EditValue = null;
            le1562.EditValue = null;
            txtms.Text = "";
            txttaixe.Text = "";
            txtgn.Text = "";
            txtldn.Text = "";
            txtkhhd.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            txthtt.EditValue = 0;
            txtck.EditValue = 0;
            txtshd.Text = "";
            txtnhd.EditValue = DateTime.Parse(ngaychungtu);          
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            pxk.themsct(ngaychungtu, txtsct, branchid, ledv.EditValue.ToString(), tsbttruoc, tsbtsau, txtms, txtkhhd, txtshd);
            pxk.themsctpx(ngaychungtu, txtspx, ledv.EditValue.ToString(), branchid);

            this.Text = "Thêm hóa đơn mua hàng kiêm phiếu nhập";
            change();
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }
            txtcth.Text = "0";
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            gen.ExcuteNonquery("update PUInvoice set Posted='True' where RefID='" + role + "'");
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
            gen.ExcuteNonquery("update PUInvoice set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refreshpxk();
            change();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            pxk.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshpxk();
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            pxk.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshpxk();
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            pxk.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshpxk();
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            pxk.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshpxk();
            change();
        }

        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("hdmh");
            F.getrole(role);
            F.Show();
        }

        private void toolddh_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbthdmhkpnphieu");
            F.getrole(role);
            F.ShowDialog();
        }

        private void toolbbgnh_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbthdmhkpnbienban");
            F.getrole(role);
            F.getkho("0");
            F.ShowDialog();
        }

        private void txtddh_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
            {
                DataTable temp = gen.GetTable("select StockCode,AccountingObjectCode,JournalMemo,DocumentIncluded,ShippingNo,a.RefID from DDHNCC a, Stock b, AccountingObject c where a.AccountingObjectID=c.AccountingObjectID and a.StockID=b.StockID and RefNo='" + txtddh.Text + "'");
                ledv.EditValue = temp.Rows[0][0].ToString();
                ledt.EditValue = temp.Rows[0][1].ToString();
                txtldn.EditValue = temp.Rows[0][2].ToString();
                txtctg.EditValue = temp.Rows[0][3].ToString();
                txtptvc.EditValue = temp.Rows[0][4].ToString();
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,a.Quantity,a.QuantityConvert,a.UnitPrice,a.Amount,SortOrder from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + temp.Rows[0][5].ToString() + "' Order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], temp.Rows[i][0].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], temp.Rows[i][1].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], Double.Parse(temp.Rows[i][2].ToString()));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Double.Parse(temp.Rows[i][3].ToString()));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Double.Parse(temp.Rows[i][4].ToString()));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Double.Parse(temp.Rows[i][5].ToString()));
                    gridView1.UpdateCurrentRow();
                }
            }
        }

        private void hdmhpnk_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("pnk");
            F.getrole(gen.GetString("select ShippingMethodID from PUInvoice where RefID='" + role + "'"));
            F.ShowDialog();
        }

        private void pnvlpg_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("hdmhvosl");
            F.getrole(role);
            F.ShowDialog();

        }

        private void txtck_EditValueChanged(object sender, EventArgs e)
        {
            Double cth = 0, thue = 0, gtgt = 0, tong = 0, chiphi = 0, chietkhau = 0;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { }
            try
            {
                chietkhau = Double.Parse(txtck.Text);
                cth = cth - chietkhau;
            }
            catch
            { }
            try
            {
                chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
            }
            catch
            { }

            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt + chiphi;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }
    }
}