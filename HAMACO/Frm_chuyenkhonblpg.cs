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
    public partial class Frm_chuyenkhonblpg : DevExpress.XtraEditors.XtraForm
    {
        public Frm_chuyenkhonblpg()
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
        private void Frm_chuyenkhonblpg_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole();
            if (pt == "pck" || pt=="tsbtpncknblpg")
                refreshpck();
            else
            {
                labelControl13.Text = "Phiếu xuất hàng gửi bán LPG";
                refreshpxhgb();
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

        DataTable dt = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
        phieuchuyenkhonblpg pck = new phieuchuyenkhonblpg();
        phieuxuathanggblpg pxhgb = new phieuxuathanggblpg();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup,roleid,subsys,click;
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
        public string getsub(string a)
        {
            subsys = a;
            return subsys;
        }
        public string getroleid(string a)
        {
            roleid = a;
            return roleid;
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
        public void refreshpck()
        {
            pck.loadpck(active, role, gridControl1, gridView1, txtsct, ledvn, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, dongia, thanhtien, txtsctn, txtcth, chiphi, txtnhd, txtms, txtkhhd, txtshd,gridControl2,gridView2,txtpxv,txtpnv,txtcthv,tsbttruoc,tsbtsau,pt);
        }
        public void refreshpxhgb()
        {
            pxhgb.loadpck(active, role, gridControl1, gridView1, txtsct, ledvn, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, dongia, thanhtien, txtsctn, txtcth, chiphi, txtnhd, txtms, txtkhhd, txtshd, gridControl2, gridView2, txtpxv, txtpnv, txtcthv,tsbttruoc,tsbtsau,pt);
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                {
                    ledv.Properties.ReadOnly = false;
                    ledvn.Properties.ReadOnly = false;
                }
                ledt.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                txtms.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                txtnhd.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                txtngh.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
            }
            else
            {
                ledv.Properties.ReadOnly = true;
                ledvn.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtms.Properties.ReadOnly = true;
                txtkhhd.Properties.ReadOnly = true;
                txtshd.Properties.ReadOnly = true;
                txtnhd.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                txtngh.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
            }
        }


        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                txtname.Text = da.Rows[0][2].ToString();
            }
            catch { }
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    if (pt == "pck")
                        pck.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), ledvn.EditValue.ToString(), txtsctn, txtpxv, txtpnv,tsbttruoc,tsbtsau);
                    else
                        pxhgb.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), ledvn.EditValue.ToString(), txtsctn, txtpxv, txtpnv,tsbttruoc,tsbtsau);
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
            else if (e.Column.FieldName == "Số lượng quy đổi" || e.Column.FieldName == "Đơn giá")
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
                    Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                    Double chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                    txtcth.Text = String.Format("{0:n0}", thanhtien + chiphi);
                    if (caseup == "2")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], (b / a).ToString());
                        }
                    }
                }
            
        }

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView2.UpdateCurrentRow();
            if (e.Column.FieldName == "Số lượng" || e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "1")
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString() != "" && gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Đơn giá").ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {
                Double thanhtien = Double.Parse(gridView2.Columns["Thành tiền"].SummaryText);
                txtcthv.Text = String.Format("{0:n0}", thanhtien);
                if (caseup == "2")
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString() != "" && gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
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
            ledt.Focus();
            if (pt == "pck")
                pck.checkpck(active, role, this, gridView1, ledt, ledv, ledvn, txtsct, txtname, txtngh, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtptvc, userid, branchid, txtsctn, txtms, txtkhhd, txtshd, txtnhd, txtpxv, txtpnv, gridView2,tsbttruoc,tsbtsau);
            else
                pxhgb.checkpck(active, role, this, gridView1, ledt, ledv, ledvn, txtsct, txtname, txtngh, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtptvc, userid, branchid, txtsctn, txtms, txtkhhd, txtshd, txtnhd, txtpxv, txtpnv, gridView2,tsbttruoc,tsbtsau);
            refreshrole();
            click = "true";
            change();
            click = "false";
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            this.Text = "Sửa phiếu nhập kho LPG";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();

            ledt.EditValue = "3";
            txtldn.Text = "";
            txtngh.Text = "";
            txtname.Text = "";
            txtptvc.Text = "";
            txtnhd.EditValue = DateTime.Parse(ngaychungtu);
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            change();
            if (pt == "pck")
            {
                pck.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), ledvn.EditValue.ToString(), txtsctn,txtpxv,txtpnv,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu xuất chuyển kho nội bộ LPG";
            }
            else
            {
                pxhgb.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), ledvn.EditValue.ToString(), txtsctn, txtpxv, txtpnv,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu xuất hàng gửi bán LPG";
            }
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }
            
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            if (pt == "pck")
                gen.ExcuteNonquery("update INInward set Posted='True' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INOutward set Posted='True' where RefID='" + role + "'");
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
            if (pt == "pck")
                gen.ExcuteNonquery("update INInward set Posted='False' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INOutward set Posted='False' where RefID='" + role + "'");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pck" || pt=="tsbtpncknblpg")
                refreshpck();
            else
                refreshpxhgb();
            change();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pck")
            {
                pck.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpck();
            }
            else if (pt == "tsbtpncknblpg")
            {
                pck.checktruoc(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpck();
            }
            else if(pt=="tsbtpnhgblpg")
            {
                pxhgb.checktruoc(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else
            {
                pxhgb.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgb();
            }

        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pck")
            {
                pck.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpck();
            }
            else if (pt == "tsbtpncknblpg")
            {
                pck.checktruoc(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpck();
            }
            else if(pt=="tsbtpnhgblpg")
            {
                pxhgb.checktruoc(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else
            {
                pxhgb.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgb();
            }
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pck")
            {
                pck.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpck();
            }
            else if (pt == "tsbtpncknblpg")
            {
                pck.checksau(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpck();
            }
            else if(pt=="tsbtpnhgblpg")
            {
                pxhgb.checksau(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else
            {
                pxhgb.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgb();
            }
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pck")
            {
                pck.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpck();
            }
            else if (pt == "tsbtpncknblpg")
            {
                pck.checksau(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpck();
            }
            else if(pt=="tsbtpnhgblpg")
            {
                pxhgb.checksau(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else
            {
                pxhgb.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgb();
            }
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txtcth.Text.Replace(".", ""));
            }
            catch { } 
        }

        private void ledvn_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    if (pt == "pck")
                        pck.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), ledvn.EditValue.ToString(), txtsctn, txtpxv, txtpnv,tsbttruoc,tsbtsau);
                    else
                        pxhgb.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), ledvn.EditValue.ToString(), txtsctn, txtpxv, txtpnv,tsbttruoc,tsbtsau);
                }
            }
            catch
            {}
        }

        private void txtcthv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lbtienvo.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txtcthv.Text.Replace(".", ""));
            }
            catch { } 
        }

        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                Frm_chonhoadon F = new Frm_chonhoadon();
                F.gettsbt("khachhang");
                F.getmk("cnblpg");
                F.getCNBLPG(this);
                F.ShowDialog();
            }
        }
        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                Frm_chonhoadon F = new Frm_chonhoadon();
                F.getmk("cnblpg");
                F.getCNBLPG(this);
                F.gettsbt("hanghoa");
                F.ShowDialog();
            }
        }

        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(role);
            F.Show();
        }
    }
}