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
    public partial class Frm_phieudieuchinh : DevExpress.XtraEditors.XtraForm
    {
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        Boolean noibo = false;
        string phieu = null;

        public Boolean getnoibo(Boolean a)
        {
            noibo = a;
            return noibo;
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

        public string getphieu(string a)
        {
            phieu = a;
            return phieu;
        }

        public Frm_phieudieuchinh()
        {
            InitializeComponent();
        }
        int K = -2;
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


        private void Frm_phieudieuchinh_KeyUp(object sender, KeyEventArgs e)
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

        private void Frm_phieudieuchinh_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole(); 
            if (pt == "pndc") refreshpndc();
            else if (pt == "pndctk")
            {
                labelControl13.Text = "Phiếu điều chỉnh tồn kho";
                refreshpdctk();
            }
            else if (pt == "pxdc")
            {
                labelControl13.Text = "Phiếu xuất điều chỉnh";
                refreshpxdc();
            }
            else if (pt == "pnht")
            {
                labelControl13.Text = "Phiếu nhập hàng";
                refreshpnht();
                toolhtgv.Visible = true;
                if (phieu != null)
                    getdata();
            }
            else if (pt == "pxht")
            {
                refreshpxht();
                if (noibo == false)
                {
                    labelControl13.Text = "Phiếu xuất hàng";
                    cghd.Visible = true;
                }
                else
                {
                    labelControl13.Text = "Phiếu xuất hàng tiêu dùng nội bộ";
                    gridView1.Columns["Số KM"].Visible = true;
                    gridView1.Columns["Số xe"].Visible = true;
                    gridView1.Columns["Tài xế"].Visible = true;
                    gridView1.Columns["Ca"].Visible = true;                
                }
            }
            else if (pt == "pnhkm")
            {
                labelControl13.Text = "Phiếu nhập hàng khuyến mãi";
                refreshpnhkm();
            }
            else if (pt == "pxhkm")
            {
                labelControl13.Text = "Phiếu xuất hàng khuyến mãi";
                refreshpxhkm();
            }

            change();
            radioGroup1.SelectedIndex = -1;

            if (gen.GetString("select CompanyTaxCode from Center") == "")
                toolin.Visible = true;

        }
        DataTable dt = new DataTable();
        phieunhapdieuchinh pndc = new phieunhapdieuchinh();
        phieunhapdieuchinhtk pndctk = new phieunhapdieuchinhtk();
        phieuxuatdieuchinh pxdc = new phieuxuatdieuchinh();
        phieunhaphangthua pnht = new phieunhaphangthua();
        phieuxuathangthieu pxht = new phieuxuathangthieu();
        phieunhaphangkhuyenmai pnhkm = new phieunhaphangkhuyenmai();
        phieuxuathangkhuyenmai pxhkm = new phieuxuathangkhuyenmai();
        doiso doi = new doiso();
        gencon gen = new gencon();
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
        public void refreshpndc()
        {
            pndc.loadpndc(active, role, gridControl1, gridView1, txtsct, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien,
                       this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, txtshd, txtkhhd, txtnhd, txtcth, userid, branchid, txtms, tsbttruoc, tsbtsau, khach, hang, rpmanganh, rpmachiphi);
        }
        public void refreshpdctk()
        {
            pndctk.loadpndc(active, role, gridControl1, gridView1, txtsct, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien,
                       this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, txtshd, txtkhhd, txtnhd, txtcth, userid, branchid, txtms, tsbttruoc, tsbtsau, khach, hang);
        }
        public void refreshpxdc()
        {
            pxdc.loadpxdc(active, role, gridControl1, gridView1, txtsct, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien,
                       this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, txtshd, txtkhhd, txtnhd, txtcth, userid, branchid, txtms, tsbttruoc, tsbtsau, khach, hang, rpmanganh, rpmachiphi);
        }
        public void refreshpnht()
        {
            pnht.loadpnht(active, role, gridControl1, gridView1, txtsct, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien,
                       this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, txtshd, txtkhhd, txtnhd, txtcth, userid, branchid, txtms, tsbttruoc, tsbtsau, khach, hang, rpmanganh, rpmachiphi, txtthuesuat);
        }
        public void refreshpxht()
        {
            pxht.loadpxht(active, role, gridControl1, gridView1, txtsct, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien,
                       this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, txtshd, txtkhhd, txtnhd, txtcth, userid, branchid, txtms, tsbttruoc, tsbtsau, khach, hang, noibo, txtthuesuat, rpmanganh, rpmachiphi, cghd);
        }
        public void refreshpnhkm()
        {
            pnhkm.loadpnht(active, role, gridControl1, gridView1, txtsct, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien,
                       this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, txtshd, txtkhhd, txtnhd, txtcth, userid, branchid, txtms, khach, hang, rpmanganh, rpmachiphi);
        }
        public void refreshpxhkm()
        {
            pxhkm.loadpxht(active, role, gridControl1, gridView1, txtsct, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien,
                       this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, txtshd, txtkhhd, txtnhd, txtcth, userid, branchid, txtms, khach, hang, rpmanganh, rpmachiphi);
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

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Tài khoản có" || e.Column.FieldName == "Tài khoản nợ")
            {
                if (gridView1.FocusedRowHandle < 1)
                {
                    if (e.Column.FieldName == "Tài khoản có")
                    {
                        if (pt == "pndc" || pt=="pndctk") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "156");
                        else if (pt == "pnht") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "156");
                        else if (pt == "pnhkm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "156");
                    }
                    else
                    {
                        if (pt == "pxdc") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "156");
                        else if (pt == "pxht") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "156");
                        else if (pt == "pxhkm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "156");
                    }
                }
                else
                {
                    if (e.Column.FieldName == "Tài khoản có")
                    {
                        if (pt == "pndc" || pt == "pnhkm" || pt=="pndctk") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản nợ").ToString());
                        else if (pt == "pnht") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản nợ").ToString());
                    }
                    else
                    {
                        if (pt == "pxdc" || pt == "pxhkm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
                        else if (pt == "pxht") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
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
                            Double quydoi = Double.Parse(hang.Rows[i][5].ToString());
                            Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Math.Round((sl * quydoi), 2).ToString());
                            return;
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
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b),0).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {
                txtcth.Text = gridView1.Columns["Thành tiền"].SummaryText;
                if (caseup == "2")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        if (a != 0)
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                        else
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], "0");
                    }
                }
            }
        }

        private void tsbtboghi_Click(object sender, EventArgs e)
        {
            tsbtghiso.Visible = true;
            tsbtghiso.Enabled = true;
            tsbtboghi.Visible = false;
            tsbtsua.Enabled = true;
            tsbtxoa.Enabled = true;
            if (pt == "pndc") gen.ExcuteNonquery("update INAdjustment set Posted='False' where RefID='" + role + "'");
            else if (pt == "pxdc") gen.ExcuteNonquery("update OUTAdjustment set Posted='False' where RefID='" + role + "'");
            else if (pt == "pnht") gen.ExcuteNonquery("update INSurplus set Posted='False' where RefID='" + role + "'");
            else if (pt == "pxht") gen.ExcuteNonquery("update OUTdeficit set Posted='False' where RefID='" + role + "'");
            else if (pt == "pnhkm") gen.ExcuteNonquery("update INInwardFree set Posted='False' where RefID='" + role + "'");
            else if (pt == "pxhkm") gen.ExcuteNonquery("update INOutwardFree set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }


        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            if (pt == "pndc") this.Text = "Sửa phiếu nhập điều chỉnh";
            else if (pt == "pndctk") this.Text = "Sửa phiếu điều chỉnh tồn kho";
            else if (pt == "pxdc") this.Text = "Sửa phiếu xuất điều chỉnh";
            else if (pt == "pnht") this.Text = "Sửa phiếu nhập hàng";
            else if (pt == "pxht") this.Text = "Sửa phiếu xuất hàng";
            else if (pt == "pnhkm") this.Text = "Sửa phiếu nhập hàng khuyến mãi";
            else if (pt == "pxhkm") this.Text = "Sửa phiếu xuất hàng khuyến mãi";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (pt == "pndc") pndc.checkpndc(active, role, this, gridView1, ledt, ledv, txtsct, txtname, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtshd, txtkhhd, txtnhd, userid, branchid, txtms, tsbttruoc, tsbtsau);
            else if (pt == "pndctk") pndctk.checkpndc(active, role, this, gridView1, ledt, ledv, txtsct, txtname, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtshd, txtkhhd, txtnhd, userid, branchid, txtms, tsbttruoc, tsbtsau);
            else if (pt == "pxdc") pxdc.checkpxdc(active, role, this, gridView1, ledt, ledv, txtsct, txtname, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtshd, txtkhhd, txtnhd, userid, branchid, txtms, tsbttruoc, tsbtsau);
            else if (pt == "pnht") pnht.checkpnht(active, role, this, gridView1, ledt, ledv, txtsct, txtname, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtshd, txtkhhd, txtnhd, userid, branchid, txtms, tsbttruoc, tsbtsau,txtthuesuat);
            else if (pt == "pxht") pxht.checkpxht(active, role, this, gridView1, ledt, ledv, txtsct, txtname, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtshd, txtkhhd, txtnhd, userid, branchid, txtms, tsbttruoc, tsbtsau, noibo, txtthuesuat, cghd);
            else if (pt == "pnhkm") pnhkm.checkpnht(active, role, this, gridView1, ledt, ledv, txtsct, txtname, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtshd, txtkhhd, txtnhd, userid, branchid, txtms);
            else if (pt == "pxhkm") pxhkm.checkpxht(active, role, this, gridView1, ledt, ledv, txtsct, txtname, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtshd, txtkhhd, txtnhd, userid, branchid, txtms);
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
            cghd.Checked = false;
            ledt.EditValue = "3";
            txtldn.Text = "";
            txtname.Text = "";
            txtthuesuat.EditValue = null;
            txtnhd.EditValue = DateTime.Parse(ngaychungtu);
            txtshd.Text = "";
            txtkhhd.Text = "";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            txtcth.Text = "0";
            txtms.Text = "";
            change();
            if (pt == "pndc")
            {
                pndc.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),branchid,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu nhập điều chinh";
            }
            else if (pt == "pndctk")
            {
                pndctk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                this.Text = "Thêm phiếu nhập điều chinh";
            }
            else if (pt == "pxdc")
            {
                pxdc.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu xuất điều chỉnh";
            }
            else if (pt == "pnht")
            {
                pnht.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu nhập hàng";
            }
            else if (pt == "pxht")
            {
                pxht.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau,noibo);
                this.Text = "Thêm phiếu xuất hàng";
            }
            else if (pt == "pnhkm")
            {
                pnhkm.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid);
                this.Text = "Thêm phiếu nhập hàng khuyến mãi";
            }
            else if (pt == "pxhkm")
            {
                pxhkm.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid);
                this.Text = "Thêm phiếu xuất hàng khuyến mãi";
            }

            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }
            
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtghiso.Visible = true;
            tsbtboghi.Visible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][3].ToString() == "EDIT")
                    tsbtsua.Enabled = true;
            }
            if (pt == "pndc")
            {
                gen.ExcuteNonquery("update INAdjustment set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "pndctk")
            {
                gen.ExcuteNonquery("update INAdjustmentTT set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "pxdc")
            {
                gen.ExcuteNonquery("update OUTAdjustment set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "pnht")
            {
                gen.ExcuteNonquery("update INSurplus set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "pxht")
            {
                gen.ExcuteNonquery("update OUTdeficit set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "pnhkm")
            {
                gen.ExcuteNonquery("update INInwardFree set Posted='True' where RefID='" + role + "'");
            }
            else if (pt == "pxhkm")
            {
                gen.ExcuteNonquery("update INOutwardFree set Posted='True' where RefID='" + role + "'");
            }
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Ghi sổ','" + txtsct.Text + "')");
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

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txtcth.Text.Replace(".", "").Replace("-",""));
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pndc")
            {
                pndc.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpndc();
            }
            else if (pt == "pndctk")
            {
                pndctk.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpdctk();
            }
            else if (pt == "pxdc")
            {
                pxdc.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxdc();
            }
            else if (pt == "pnht")
            {
                pnht.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnht();
            }
            else if (pt == "pxht")
            {
                pxht.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),noibo);
                refreshpxht();
            }
            else if (pt == "pnhkm")
            {
                pnhkm.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnhkm();
            }
            else if (pt == "pxhkm")
            {
                pxhkm.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxhkm();
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
                ledt.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                txtnhd.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtthuesuat.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                txtms.Properties.ReadOnly = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                toolhtgv.Enabled = true;
            }
            else
            {
                toolhtgv.Enabled = false;
                ledv.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                txtnhd.Properties.ReadOnly = true;
                txtkhhd.Properties.ReadOnly = true;
                txtthuesuat.Properties.ReadOnly = true;
                txtshd.Properties.ReadOnly = true;
                txtms.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
            }
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pndc")
            {
                pndc.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpndc();
            }
            else if (pt == "pndctk")
            {
                pndctk.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpdctk();
            }
            else if (pt == "pxdc")
            {
                pxdc.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxdc();
            }
            else if (pt == "pnht")
            {
                pnht.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnht();
            }
            else if (pt == "pxht")
            {
                pxht.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),noibo);
                refreshpxht();
            }
            else if (pt == "pnhkm")
            {
                pnhkm.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnhkm();
            }
            else if (pt == "pxhkm")
            {
                pxhkm.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxhkm();
            }
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pndc")
            {
                pndc.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpndc();
            }
            else if (pt == "pndctk")
            {
                pndctk.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpdctk();
            }
            else if (pt == "pxdc")
            {
                pxdc.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxdc();
            }
            else if (pt == "pnht")
            {
                pnht.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnht();
            }
            else if (pt == "pxht")
            {
                pxht.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),noibo);
                refreshpxht();
            }
            else if (pt == "pnhkm")
            {
                pnhkm.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnhkm();
            }
            else if (pt == "pxhkm")
            {
                pxhkm.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxhkm();
            }
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pndc")
            {
                pndc.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpndc();
            }
            else if (pt == "pndctk")
            {
                pndctk.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpdctk();
            }
            else if (pt == "pxdc")
            {
                pxdc.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxdc();
            }
            else if (pt == "pnht")
            {
                pnht.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnht();
            }
            else if (pt == "pxht")
            {
                pxht.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),noibo);
                refreshpxht();
            }
            else if (pt == "pnhkm")
            {
                pnhkm.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnhkm();
            }
            else if (pt == "pxhkm")
            {
                pxhkm.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxhkm();
            }
            change();
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    if (pt == "pndc") pndc.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),branchid,tsbttruoc,tsbtsau);
                    else if (pt == "pndctk") pndctk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                    else if (pt == "pxdc") pxdc.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                    else if (pt == "pnht") pnht.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                    else if (pt == "pxht") pxht.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau,noibo);
                    else if (pt == "pnhkm") pnhkm.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid);
                    else if (pt == "pxhkm") pxhkm.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid);
                }
            }
            catch { }
        }

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                txtname.Text = da.Rows[0][2].ToString();
            }
            catch { }*/
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                {
                    txtname.Text = khach.Rows[i][2].ToString();
                    return;
                }
            }
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pndc")
                refreshpndc();
            else if (pt == "pndctk") refreshpdctk();
            else if (pt == "pxdc") refreshpxdc();
            else if (pt == "pnht") refreshpnht();
            else if (pt == "pxht") refreshpxht();
            else if (pt == "pnhkm") refreshpnhkm();
            else if (pt == "pxhkm") refreshpxhkm();
            change();
        }

        private void tsbtin_Click(object sender, EventArgs e)
        {
            if (pt == "pxht")
            {
                DialogResult dr = XtraMessageBox.Show("Yes để in phiếu xuất, No để in hóa đơn.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dr == DialogResult.No)
                {
                    Frm_nhapxuat H = new Frm_nhapxuat();
                    H.gettsbt("hdbhpnht");
                    H.getrole(role);
                    H.ShowDialog();
                    return;
                }
                else if (dr == DialogResult.Cancel)
                    return;
            }
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(role);
            F.getcongty("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            F.getnoibo(noibo);
            F.ShowDialog();
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
                    string temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString();
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


        private void gridView1_FocusedRowChanged(object sender, EventArgs e)
        {
            gridView1_FocusedRowChanged();
        }

        private void gridView1_FocusedRowChanged()
        {
            try
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        textEdit1.Text = hang.Rows[i][2].ToString();
                        return;
                    }
                }
                textEdit1.Text = null;
            }
            catch
            {
                textEdit1.Text = null;
            }
        }

        private void toolphieudatmua_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt+"phieu");
            F.getrole(role);
            F.getnoibo(noibo);
            F.ShowDialog();
        }

        private void toolbienbangiaonhan_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "bienban");
            F.getrole(role);
            F.getkho("0");
            F.ShowDialog();
        }


        private void getdata()
        {
            if (active == "0")
            {
                DataTable temp = gen.GetTable("select StockCode,a.AccountingObjectCode,JournalMemo,DocumentIncluded,ShippingNo,a.RefID from DDH a, Stock b, AccountingObject c where a.AccountingObjectID=c.AccountingObjectID and a.InStockID=b.StockID and RefNo='" + phieu + "'");
                ledv.EditValue = temp.Rows[0][0].ToString();
                ledt.EditValue = temp.Rows[0][1].ToString();
                txtldn.EditValue = "Vận chuyển nhập kho theo đơn đặt hàng " + phieu;
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,a.Quantity,a.QuantityConvert,a.CustomField3,a.CustomField4 from DDHDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + temp.Rows[0][5].ToString() + "' and (QuantityExits<>0 or QuantityConvertExits<>0)");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "331");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "1562");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], temp.Rows[i][0].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], temp.Rows[i][1].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Double.Parse(temp.Rows[i][5].ToString()));
                    gridView1.UpdateCurrentRow();
                }
            }
        }

        private void toolhtgv_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chọn đúng ngày hạch toán giá vốn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string thang = DateTime.Parse(denht.EditValue.ToString()).Month.ToString();
                string nam = DateTime.Parse(denht.EditValue.ToString()).Year.ToString();
                string thangtruoc = DateTime.Parse(denht.EditValue.ToString()).AddMonths(-1).Month.ToString();
                string namtruoc = DateTime.Parse(denht.EditValue.ToString()).AddMonths(-1).Year.ToString();
                gen.ExcuteNonquery("dongiavontheokhotungmathangtoancongty '" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
                DataTable temp = gen.GetTable("select InventoryItemCode,TotalAmount from OpeningInventoryEntryUnit a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "'");
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    for (int j = 0; j < temp.Rows.Count; j++)
                    {
                        if (gridView1.GetRowCellValue(i, "Mã hàng").ToString().ToUpper() == temp.Rows[j][0].ToString().ToUpper())
                        {
                            Double b = Double.Parse(temp.Rows[j][1].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Đơn giá"], b);
                            Double a = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                            gridView1.UpdateCurrentRow();
                            j = temp.Rows.Count;
                        }
                    }
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