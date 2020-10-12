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
    public partial class Frm_hdbhkpx : DevExpress.XtraEditors.XtraForm
    {
        public Frm_hdbhkpx()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
        hdbhkpx pxk = new hdbhkpx();
        DataTable hangton = new DataTable();
        public delegate void ac();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup, click = null, roleid, subsys, load = null,thue=null;
        int K = -2;

        public DataTable gethangton(DataTable a)
        {
            hangton = a;
            gridView1_FocusedRowChanged();
            return hangton;
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
            pxk.loadpxk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, dongia, thanhtien, txtcth, cbthue, lenv, chiphi, chietkhau, txtck, tsbttruoc, tsbtsau, txtnhd, txthtt, txthttt, leprovince, cbban, txtquyen, gridControl2, gridView2, txtms, txtkhhd, txtshd, txtldkt, txttdd, txtdc, txtkt, chmoney, chpayphone, txttthue, txtspx, txtspkm, tkno, tkco, txtck,khach,hang,txtname,txtmst,txtghichu);
            if (active == "1")
                thue = txttthue.Text;
        }


        private void Frm_hdbhkpx_KeyUp(object sender, KeyEventArgs e)
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
                    tsbtin_ButtonClick(this, e);
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


        private void Frm_hdbhkpx_Load(object sender, EventArgs e)
        {
            txthttt.Text = "TM/CK";
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole();
            if (pt == "pxk")
            {
                refreshpxk();
                labelControl13.Text = "Hóa đơn bán hàng kiêm phiếu xuất kho";
            }
            change();
            load = "0";
            radioGroup1.SelectedIndex = -1;

            if (gen.GetString("select CompanyTaxCode from Center") == "")
                toolStripSplitButton1.Visible = true;
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

        private void refreshrole()
        {
            /*
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
            */
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
                lenv.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView2.OptionsBehavior.Editable = true;
                txtngh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                txtms.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                txthtt.Properties.ReadOnly = false;
                txthttt.Properties.ReadOnly = false;
                txtnhd.Properties.ReadOnly = false;
                leprovince.Properties.ReadOnly = false;
                chmoney.Properties.ReadOnly = false;
                chpayphone.Properties.ReadOnly = false;
                ledv.Properties.ReadOnly = false;
                cbban.Properties.ReadOnly = false;
                txttdd.Properties.ReadOnly = false;
                chton.Properties.ReadOnly = false;
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
                lenv.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView2.OptionsBehavior.Editable = false;
                txtngh.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
                txtms.Properties.ReadOnly = true;
                txtkhhd.Properties.ReadOnly = true;
                txthttt.Properties.ReadOnly = true;
                txtshd.Properties.ReadOnly = true;
                txtnhd.Properties.ReadOnly = true;
                txthtt.Properties.ReadOnly = true;
                leprovince.Properties.ReadOnly = true;
                chmoney.Properties.ReadOnly = true;
                chpayphone.Properties.ReadOnly = true;
                cbban.Properties.ReadOnly = true;
                txttdd.Properties.ReadOnly = true;
                chton.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                ledt.Focus();
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
            ledt.Properties.ValueMember = "Mã đối tượng";
            ledt.Properties.PopupWidth = 400;*/
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
            /*try
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
            catch { }*/
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

        private void lenv_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select * from AccountingObject where AccountingObjectCode='" + lenv.EditValue.ToString() + "'");
                txtnv.Text = da.Rows[0][2].ToString();
            }
            catch
            {
                txtnv.Text = "";
            }*/
            try
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (lenv.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtnv.Text = khach.Rows[i][2].ToString();
                        return;
                    }
                }
            }
            catch { txtnv.Text = ""; }
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                    gtgt = Math.Round((cth / 100) * thue, 0);
                }
                catch
                {
                    gtgt = 0;
                }
                tong = cth + gtgt;
                txttthue.Text = String.Format("{0:n0}", gtgt);
                txttc.Text = String.Format("{0:n0}", tong);
            }
            catch { }
        }

        private void txtkt_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong, ck, kt;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { cth = 0; }
            try
            {
                ck = Double.Parse(txtck.Text);
            }
            catch { ck = 0; }
            kt = Double.Parse(txtkt.Text);
            cth = cth - ck - kt;

            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = (cth / 100) * thue;
            }
            else
            {
                gtgt = 0;
            }

            txttthue.EditValue = gtgt;
            tong = cth + gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "Không đồng";
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong, ck, kt;
            cth = Double.Parse(txtcth.Text);
            try
            {
                ck = Double.Parse(txtck.Text);
            }
            catch { ck = 0; }
            try
            {
                kt = Double.Parse(txtkt.Text);
            }
            catch { kt = 0; }
            cth = cth - ck - kt;
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
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txtck_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth, gtgt, tong, ck, kt;
                try
                {
                    cth = Double.Parse(txtcth.Text);
                }
                catch { cth = 0; }
                try
                {
                    ck = Double.Parse(txtck.Text);
                }
                catch { ck = 0; }
                try
                {
                    kt = Double.Parse(txtkt.Text);
                }
                catch { kt = 0; }
                cth = cth - ck - kt;
                gtgt = Double.Parse(txttthue.Text);
                tong = cth + gtgt;

                txttc.Text = String.Format("{0:n0}", tong);

                if (cth == 0)
                    lbtienchu.Text = "Không đồng";
            }
            catch { }
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth, gtgt, tong, ck, kt;
                try
                {
                    cth = Double.Parse(txtcth.Text);
                }
                catch { cth = 0; }
                try
                {
                    ck = Double.Parse(txtck.Text);
                }
                catch { ck = 0; }
                try
                {
                    kt = Double.Parse(txtkt.Text);
                }
                catch { kt = 0; }
                cth = cth - ck - kt;
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
            try
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", "").Replace("-", ""));
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Mã hàng")
            {
                /*string tenhang = gen.GetString("select InventoryItemName from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() + "'");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], tenhang);*/
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        return;
                    }
                }

            }
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "1";
                    /*Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                    Double quydoi = Double.Parse(gen.GetString("select ConvertRate from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() + "'"));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Math.Round((sl * quydoi), 2).ToString());*/
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
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                        }
                    }
                }
                else if (e.Column.FieldName == "Thành tiền" || e.Column.FieldName == "Chi phí")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "" && gen.GetString("select CompanyTaxCode from Center") != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a / 100), 0).ToString());
                    }
                    Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                    Double chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                    txtcth.Text = String.Format("{0:n0}", thanhtien + chiphi);

                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "" && gen.GetString("select CompanyTaxCode from Center") != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a / 100), 0).ToString());
                        Double ck = Double.Parse(gridView1.Columns["Tiền CK"].SummaryText);
                        txtck.Text = String.Format("{0:n0}", ck);
                    }

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
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "" && gen.GetString("select CompanyTaxCode from Center") != "")
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
            if (e.Column.FieldName == "Mã hàng")
            {
                string tenhang = gen.GetString("select InventoryItemName from InventoryItem where InventoryItemCode='" + gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Mã hàng").ToString() + "'");
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tên hàng"], tenhang);

            }
            if (e.Column.FieldName == "Tài khoản nợ")
            {
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tài khoản có"], "156");

            }
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "1";
                    Double sl = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString());
                    Double quydoi = Double.Parse(gen.GetString("select ConvertRate from InventoryItem where InventoryItemCode='" + gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Mã hàng").ToString() + "'"));
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], Math.Round((sl * quydoi), 2).ToString());
                }
                catch { }
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

        private void gridView2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView2.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = gridView2.FocusedRowHandle;
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau, txtquyen, txtms, txtkhhd, txtshd,"0");
                    pxk.themsctpx(ngaychungtu, txtspx, ledv.EditValue.ToString(), branchid);
                }

                string kho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                hangton = gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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
            pxk.checkpxk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, cbthue, lenv, tsbttruoc, tsbtsau, txtquyen, txtms, txtkhhd, txtshd, txtnhd, txthtt, txthttt, chmoney, chpayphone, leprovince, cbban, txtkt, txtspx,txtspkm,txtldkt, txttdd, txttthue, gridView2,chton,txtghichu,hangton);
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
            this.Text = "Sửa hóa đơn bán hàng kiêm phiếu xuất";
            tsbtcat.Enabled = true;
            change();
        }

        private void txtspkm_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "1")
            {
                try
                {
                    DataTable da = new DataTable();
                    string refidkm = gen.GetString("select * from INOutwardFree where RefNo='" + txtspkm.Text + "'");
                    string check = gen.GetString("select ExitsStore from INOutwardFree where RefNo='" + txtspkm.Text + "'");
                    if (check == "True")
                        chton.Checked = true;

                    da = gen.GetTable("select  DebitAccount,CreditAccount,InventoryItemCode,InventoryItemName,Quantity,QuantityConvert from INOutwardFreeDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + refidkm + "' order by SortOrder");
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        gridView2.AddNewRow();
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tài khoản có"], da.Rows[i][1].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tài khoản nợ"], da.Rows[i][0].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], da.Rows[i][2].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], da.Rows[i][4].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], da.Rows[i][5].ToString());
                    }
                }
                catch { }
            }
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();
            chton.Checked = false;
            cbldt.SelectedIndex = 0;
            ledt.EditValue = null;
            lenv.EditValue = null;
            txtms.Text = "";
            txtghichu.Text = "";
            txtldn.Text = "";
            txtkhhd.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            txthtt.EditValue = 0;
            txtshd.Text = "";
            txtnhd.EditValue = DateTime.Parse(ngaychungtu); ;
            txtcth.Text = "0";
            txtck.Text = "0";
            txtkt.Text = "0";
            txtspkm.Text = "";
            txtldkt.Text = "";
            txtmst.Text = "";
            chmoney.EditValue = false;
            chpayphone.EditValue = false;
            leprovince.EditValue = "CT";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            txtngh.Text = "";
            txtptvc.Text = "";
            txttdd.Text = "";

            pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau, txtquyen, txtms, txtkhhd, txtshd, "0");
            pxk.themsctpx(ngaychungtu, txtspx, ledv.EditValue.ToString(), branchid);

            this.Text = "Thêm hóa đơn mua hàng";
            change();
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }
            while (gridView2.RowCount > 1)
            {
                gridView2.DeleteRow(0);
            }
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            txtspkm.Text = "";
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

        private void tsbtin_ButtonClick(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("hdbh");
            F.getrole(role);
            F.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("hdbhtsl");
            F.getrole(role);
            F.Show();
        }

        private void chuyểnHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("hdbhksl");
            F.getrole(role);
            F.Show();
        }

        private void inĐơnGiáKèmSốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("hdbhdgsl");
            F.getrole(role);
            F.Show();
        }

        private void inBảngKêGiaoNhậnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string px = gen.GetString("select ShippingMethodID from SSInvoice where RefID='" + role + "'");
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "bienban");
            F.getrole(px);
            F.ShowDialog();
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
            gen.ExcuteNonquery("update SSInvoice set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            gen.ExcuteNonquery("update SSInvoice set Posted='True' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Ghi sổ','" + txtsct.Text + "')");
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

        private void lenv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                lenv.EditValue = null;
            }
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = -3;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }

        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    K = gridView1.FocusedRowHandle;
                else
                    K = gridView2.FocusedRowHandle;
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
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    K = gridView1.RowCount;
                else
                    K = gridView2.RowCount;            
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
                lenv.EditValue = searchLookUpEdit1.EditValue;
                lenv.Focus();
            }
            else if (K != -1)
            {
                if (xtraTabControl1.SelectedTabPageIndex == 0)
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
                else
                {
                    try
                    {
                        string temp = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "Tên hàng").ToString();
                        gridView2.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                        gridView2.Focus();
                    }
                    catch
                    {
                        gridView2.AddNewRow();
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                        gridView2.Focus();
                    }
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, EventArgs e)
        {
            gridView1_FocusedRowChanged();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            gridView1_FocusedRowChanged();
        }

        private void gridView1_FocusedRowChanged()
        {
            try
            {
                for (int i = 0; i < hangton.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hangton.Rows[i][3].ToString())
                    {
                        if (Double.Parse(hangton.Rows[i][1].ToString()) != 0)
                            textEdit1.Text = String.Format("{0:n0}", Double.Parse(hangton.Rows[i][1].ToString()));
                        else
                            textEdit1.Text = null;
                        if (Double.Parse(hangton.Rows[i][2].ToString()) != 0)
                            textEdit2.Text = String.Format("{0:n2}", Double.Parse(hangton.Rows[i][2].ToString()));
                        else
                            textEdit2.Text = null;
                        if (Double.Parse(hangton.Rows[i][1].ToString()) != 0 && Double.Parse(hangton.Rows[i][2].ToString()) != 0)
                            textEdit3.Text = String.Format("{0:n3}", Math.Round(Double.Parse(hangton.Rows[i][2].ToString()) / Double.Parse(hangton.Rows[i][1].ToString()), 3));
                        else
                            textEdit3.Text = null;
                        return;
                    }
                }
                textEdit1.Text = null;
                textEdit2.Text = null;
                textEdit3.Text = null;
            }
            catch
            {
                textEdit1.Text = null;
                textEdit2.Text = null;
                textEdit3.Text = null;
            }
        }

        private void toolddh_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbthdbhkpnphieu");
            F.getrole(role);
            F.ShowDialog();
        }

        private void toolbbgnh_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbthdbhkpnbienban");
            F.getrole(role);
            F.getkho("0");
            F.ShowDialog();
        }

    }
}