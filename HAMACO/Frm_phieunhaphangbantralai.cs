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
    public partial class Frm_phieunhaphangbantralai : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        doiso doi = new doiso();
        gencon gen = new gencon();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup,hoadon,roleid,subsys,click;
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

        public string gethd(string a)
        {
            hoadon = a;
            return hoadon;
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


        public void gethoadon()
        {
            try
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select * from SSInvoice where RefID='" + hoadon + "'");
                bthd.EditValue = da.Rows[0][5];
                if (ckhd.Checked == false)
                {
                    txtms.Text = da.Rows[0][67].ToString();
                    txtkhhd.Text = da.Rows[0][68].ToString();
                    txtshd.Text = da.Rows[0][69].ToString();
                    txtnhd.EditValue = DateTime.Parse(da.Rows[0][14].ToString());
                    cbthue.Text = da.Rows[0][66].ToString();
                }
                else
                {
                    txtms.Text = "";
                    txtkhhd.Text = "";
                    txtshd.Text = "";
                    txtcth.Text = "0";
                    txtnhd.EditValue = DateTime.Now;
                }

                da = gen.GetTable("select InventoryItemCode,InventoryItemName from SSInvoiceDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + hoadon + "' order by SortOrder ");
                while (gridView1.RowCount > 0)
                {
                    gridView1.DeleteRow(0);
                }
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], da.Rows[i][0].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], da.Rows[i][1].ToString());
                }
                gridView1.UpdateCurrentRow();
            }
            catch { }
        }

        public Frm_phieunhaphangbantralai()
        {
            InitializeComponent();
        }

        private void bthd_Click(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='"+ledv.EditValue.ToString()+"'");
            pnhbtl.tsbtchonhd(this, ledt, ngaychungtu, makho);
        }

        phieunhaphangbantralai pnhbtl = new phieunhaphangbantralai();
        public void refreshpnhbtl()
        {
            pnhbtl.loadpnhbtl(active, role, gridControl1, gridView1, txtsct, ledv, denct, denht, mahang, soluong, soluongqd, dongia,chiphi, thanhtien,
                       this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, txtshd, txtkhhd, txtnhd, txtcth,txttthue, userid, branchid, txtms,cbthue,bthd,ckhd,tsbttruoc,tsbtsau,khach,hang);
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
        private void Frm_phieunhaphangbantralai_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole(); 
            refreshpnhbtl();
            change();
        }

        private void ledt_EditValueChanged(object sender, EventArgs e)
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

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                txttthue.Text = String.Format("{0:n0}", gtgt);
                txttc.Text = String.Format("{0:n0}", tong);
            }
            catch { }
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
            {
                pnhbtl.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            }
        }

        private void ckhd_CheckedChanged(object sender, EventArgs e)
        {
            gethoadon();
        }


        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "1";
                    for (int i = 0; i < hang.Rows.Count; i++)
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            Double quydoi = Double.Parse(hang.Rows[i][5].ToString());
                            Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Math.Round((sl * quydoi), 2).ToString());
                            return;
                        }
                    }
                }
                catch { }
            }
            if (e.Column.FieldName == "Số lượng quy đổi" || e.Column.FieldName == "Đơn giá" || e.Column.FieldName == "Đơn giá phí")
            {
                if (caseup == "1")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                        Double c = 0;
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString() != "")
                            c = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * (b + c)), 0).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {
                Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                if (caseup == "2")
                {
                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round(b/a, 2).ToString());
                }
                txtcth.Text = String.Format("{0:n0}", thanhtien);
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
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", ""));
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
            txttthue.Text = String.Format("{0:n0}", gtgt);
            txttc.Text = String.Format("{0:n0}", tong);
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            pnhbtl.checkpndc(active, role, this, gridView1, ledt, ledv, txtsct, txtname, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtshd, txtkhhd, txtnhd, userid, branchid, txtms, cbthue, ckhd, hoadon, txttthue, tsbttruoc, tsbtsau);
            refreshrole();
            click = "true";
            change();
            click = "false";
            if (active == "1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                {
                    ledv.Properties.ReadOnly = false;
                }
                ledt.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                gridView1.OptionsBehavior.Editable = true;
                txtnhd.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                txtms.Properties.ReadOnly = false;
                ckhd.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                txttthue.Properties.ReadOnly = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
            }
            else
            {
                ledv.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                gridView1.OptionsBehavior.Editable = false;
                txtnhd.Properties.ReadOnly = true;
                txtkhhd.Properties.ReadOnly = true;
                txtshd.Properties.ReadOnly = true;
                txtms.Properties.ReadOnly = true;
                ckhd.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                txttthue.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
            }
        }

        private void bthd_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "1")
                gethoadon();
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            this.Text = "Sửa phiếu nhập hàng bán trả lại";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();

            ledt.EditValue = null;
            txtldn.Text = "";
            txtname.Text = "";
            txtdc.Text = "";           
            hoadon = "";
            ckhd.Checked = false;
            bthd.EditValue= null ;          
            txtmst.Text = "";
            txtms.Text = "";
            txtkhhd.Text = "";
            txtshd.Text = "";
            txtcth.Text = "0";
            txtnhd.EditValue = DateTime.Now;
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Now;
            txtcth.Text = "0";
            pnhbtl.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            this.Text = "Thêm phiếu nhập hàng bán trả lại";
            change();
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
            gen.ExcuteNonquery("update INReInward set Posted='True' where RefID='" + role + "'");
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
            gen.ExcuteNonquery("update INReInward set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refreshpnhbtl();
            change();
        }
        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                Frm_chonhoadon F = new Frm_chonhoadon();
                F.gettsbt("khachhang");
                F.getPNHBTL(this);
                F.getkhach(khach);
                F.getmk("pnhbtl");
                F.ShowDialog();
            }
        }
        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                Frm_chonhoadon F = new Frm_chonhoadon();
                F.gettsbt("hanghoa");
                F.getPNHBTL(this);
                F.gethang(hang);
                F.getmk("pnhbtl");
                F.ShowDialog();
            }
        }

        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("pnkbienbantra");
            F.getrole(role);
            F.ShowDialog();
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
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
                lbtienchu.Text = "Không đồng.";
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }
    }
}