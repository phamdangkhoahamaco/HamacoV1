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
using DevExpress.XtraSplashScreen;

namespace HAMACO
{
    public partial class Frm_phieuthu : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable taikhoan = new DataTable();
        DataTable danhmuc = new DataTable();
        gencon gen = new gencon();
        phieuthutm pttm = new phieuthutm();
        phieuthunh ptnh = new phieuthunh();
        phieuchitm pctm = new phieuchitm();
        phieuchinh pcnh = new phieuchinh();
        phieuketoan pkt = new phieuketoan();
        phieuthuchi ptctm = new phieuthuchi();

        public delegate void ac();
        public ac myac;
        string role, active, pt, ngaychungtu, userid, roleid, subsys, click, load = null;
        int K = -2, auto = 0;
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
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
       
        public void refeshpttm()
        {
            pttm.loadtm(cechd, active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien,
                       this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue, tsbttruoc, tsbtsau, khach, userid, rpmanganh, rpmachiphi, searchdanhmuc, letq, tsbtkc, txtspt);
        }
        public void refeshptctm()
        {
            ptctm.loadtm(cechd, active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien,
                       this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue, tsbttruoc, tsbtsau, khach, userid,rpmanganh,rpmachiphi,searchdanhmuc);
        }
        public void refeshptnh()
        {
            ptnh.loadnh(cechd, active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien,
                        this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue,txthtt,tsbttruoc,tsbtsau,khach,userid,rpmanganh,rpmachiphi,searchdanhmuc);
        }
        public void refeshpctm()
        {
            pctm.loadctm(cechd, active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien,
                        this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue, tsbttruoc, tsbtsau, khach, userid, rpmanganh, rpmachiphi, searchdanhmuc, toolduyet, letq, txtspt);
        }
        public void refeshpcnh()
        {
            pcnh.loadcnh(cechd, active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien,
                        this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue,txthtt,tsbttruoc,tsbtsau,khach,userid,rpmanganh,rpmachiphi,searchdanhmuc);
        }
        public void refeshpkt()
        {
            pkt.loadpkt(cechd, active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien,
                        this, ledt, txtnn, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, pt, cbthue, txthtt, tsbttruoc, tsbtsau, khach, userid, tsbtkc,rpmanganh,rpmachiphi,searchdanhmuc);
        }
        public Frm_phieuthu()
        {
            InitializeComponent();
        }

        private void Frm_phieuthu_KeyUp(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (tsbtxoa.Enabled == true)
                    tsbtxoa_Click_1(this, e);
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

        private void Frm_phieuthu_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            
            if (DateTime.Parse(ngaychungtu).Year >= 2015)
                taikhoan = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
            else
                taikhoan = gen.GetTable("select AccountNumber,AccountName from Account2014 order by AccountNumber");

            danhmuc = gen.GetTable("select STT,DebitAmout,CreditAmount from DANHMUC where Phieu='" + pt + "' order by STT");
            
            labelControl13.Visible = false;
            txthtt.Visible = false;
            refreshrole();
            if (pt == "pttm")
            {
                letq.Visible = true;
                lbtq.Visible = true;
                toolptt.Visible = true;
                toolptt.Text = "In phiếu thu đơn vị";
                tsbtkc.Visible = true;
                tsbtkc.Text = "Duyệt tại đơn vị";
                lbspt.Visible = true;
                txtspt.Visible = true;
                refeshpttm();
            }
            else if (pt == "ptnh")
            {
                labelControl1.Text = "Phiếu thu ngân hàng";
                labelControl13.Visible = true;
                txthtt.Visible = true;
                refeshptnh();
            }
            else if (pt == "ptctm")
            {
                labelControl1.Text = "Phiếu thu chi";
                refeshptctm();
            }
            else if (pt == "pctm")
            {
                labelControl1.Text = "Phiếu chi tiền mặt";
                labelControl4.Text = "   Người nhận       ";

                letq.Visible = true;
                lbtq.Visible = true;
                toolptt.Visible = true;

                lbspt.Visible = true;
                lbspt.Text = "Số phiếu chi";
                txtspt.Visible = true;

                refeshpctm();
            }
            else if (pt == "pcnh")
            {
                labelControl1.Text = "Phiếu chi ngân hàng";
                labelControl4.Text = "   Người nhận       ";
                labelControl13.Visible = true;
                txthtt.Visible = true;
                refeshpcnh();
            }
            else if (pt == "pkt")
            {
                labelControl1.Text = "Phiếu Kế toán";
                labelControl4.Text = "   Người nhận       ";
                labelControl13.Visible = true;
                txthtt.Visible = true;
                tsbtkc.Visible = true;
                refeshpkt();
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
            toolduyet.Enabled = false;
            tsbtkc.Enabled = false;
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
                tsbtkc.Enabled = true;
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
                    else if (dt.Rows[i][3].ToString() == "LOCKINPUT")
                        toolduyet.Visible = true;
                }
            }
        }
        

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (auto == 0)
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
                        if (e.Column.FieldName == "Tài khoản có")
                        {
                            if (pt == "pttm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "1111");
                            else if (pt == "ptnh") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "1121");
                        }
                        else
                        {
                            if (pt == "pctm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "1111");
                            else if (pt == "pcnh") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "1121");
                        }
                    }
                    else
                    {
                        if (e.Column.FieldName == "Tài khoản có")
                        {
                            if (pt == "pttm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản nợ").ToString());
                            else if (pt == "ptnh") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản nợ").ToString());
                        }
                        else
                        {
                            if (pt == "pctm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
                            else if (pt == "pcnh") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
                        }
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

                if (gridView1.RowCount == 14 && auto == 0)
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);

                if (e.Column.FieldName == "Mã khách")
                {
                    for (int i = 0; i < khach.Rows.Count; i++)
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã khách").ToString() == khach.Rows[i][1].ToString())
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Ghi chú"], khach.Rows[i][5].ToString());
                            txtnn.Text = khach.Rows[i][5].ToString();
                            return;
                        }
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
            }
            catch { }*/
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

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtkc.Enabled = false;
            if (pt == "pttm")
                gen.ExcuteNonquery("update CAReceipt set Posted='True' where RefID='" + role + "'");
            else if (pt == "ptnh") gen.ExcuteNonquery("update BADeposit set Posted='True' where RefID='" + role + "'");
            else if (pt == "pctm") gen.ExcuteNonquery("update CAPayment set Posted='True' where RefID='" + role + "'");
            else if (pt == "pcnh") gen.ExcuteNonquery("update BATransfer set Posted='True' where RefID='" + role + "'");
            else if (pt == "pkt") gen.ExcuteNonquery("update GLVoucher set Posted='True' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Ghi sổ','"+txtsct.Text+"')");
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
            if (pt == "pttm")
                gen.ExcuteNonquery("update CAReceipt set Posted='False' where RefID='" + role + "'");
            else if (pt == "ptnh") gen.ExcuteNonquery("update BADeposit set Posted='False' where RefID='" + role + "'");
            else if (pt == "pctm") gen.ExcuteNonquery("update CAPayment set Posted='False' where RefID='" + role + "'");
            else if (pt == "pcnh") gen.ExcuteNonquery("update BATransfer set Posted='False' where RefID='" + role + "'");
            else if (pt == "pkt") gen.ExcuteNonquery("update GLVoucher set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            tsbtcat.Enabled = true;
            toolduyet.Enabled = true;
            tsbtkc.Enabled = true;
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
            else if (e.KeyCode == Keys.Enter)
            {
                /*if (cechd.Checked == false)
                {
                    if (gridView1.FocusedColumn == gridView1.Columns[0])
                        gridView1.FocusedColumn = gridView1.Columns[1];
                    else if (gridView1.FocusedColumn == gridView1.Columns[1])
                        gridView1.FocusedColumn = gridView1.Columns[6];
                    else if (gridView1.FocusedColumn == gridView1.Columns[6])
                        gridView1.FocusedColumn = gridView1.Columns[7];
                    else if (gridView1.FocusedColumn == gridView1.Columns[7])
                        gridView1.FocusedColumn = gridView1.Columns[0];
                }
                else if (cechd.Checked == true)
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
                        gridView1.FocusedColumn = gridView1.Columns[6];
                    else if (gridView1.FocusedColumn == gridView1.Columns[6])
                        gridView1.FocusedColumn = gridView1.Columns[7];
                    else if (gridView1.FocusedColumn == gridView1.Columns[7])
                        gridView1.FocusedColumn = gridView1.Columns[0];
                }*/
            }
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (cbthue.Text != "")
                try
                {
                    Double.Parse(cbthue.Text);
                }
                catch
                {
                    XtraMessageBox.Show("Thuế suất không đúng định dạng. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            if (pt == "pttm") pttm.checkpttm(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, tsbttruoc, tsbtsau, searchdanhmuc, letq, "0");
            else if (pt == "ptctm") ptctm.checkpttm(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, tsbttruoc, tsbtsau, searchdanhmuc);
            else if (pt == "ptnh") ptnh.checkptnh(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, txthtt, tsbttruoc, tsbtsau, searchdanhmuc);
            else if (pt == "pctm") pctm.checkpctm(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, tsbttruoc, tsbtsau, searchdanhmuc, "0", letq);
            else if (pt == "pcnh") pcnh.checkpcnh(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, txthtt, tsbttruoc, tsbtsau, searchdanhmuc);
            else if (pt == "pkt") pkt.checkpkt(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txthtt, userid, tsbttruoc, tsbtsau, tsbtkc, searchdanhmuc);
            refreshrole();
            click = "true";
            change();
            click = "false";
            if(active=="1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
            
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            txtspt.Text = "";
            refreshrole();
            change();
            cbldt.SelectedIndex = 0;
            ledt.EditValue = "3";
            ledv.ItemIndex = 0;
            txtctg.Text = "";
            txtldn.Text = "";
            txtnn.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Now;
            if (pt == "pttm")
            {
                pttm.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid, ledv.EditValue.ToString());
                this.Text = "Thêm phiếu thu tiền mặt";
                tsbtcat.Visible = true;
                tsbtkc.Visible = true;
                tsbtkc.Enabled = false;
            }
            if (pt == "ptctm")
            {
                ptctm.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);
                this.Text = "Thêm phiếu thu tiền mặt";
            }
            else if (pt == "ptnh")
            {
                ptnh.themsct(ngaychungtu, txtsct,tsbttruoc,tsbtsau,userid);
                this.Text = "Thêm phiếu thu ngân hàng";
            }
            else if (pt == "pctm")
            {
                pctm.themsct(ngaychungtu, txtsct,tsbttruoc,tsbtsau,userid,ledv.EditValue.ToString());
                this.Text = "Thêm phiếu chi tiền mặt";
                tsbtcat.Visible = true;
            }
            else if (pt == "pcnh")
            {
                pcnh.themsct(ngaychungtu, txtsct,tsbttruoc,tsbtsau,userid);
                this.Text = "Thêm phiếu chi ngân hàng";
            }
            else if (pt == "pkt")
            {
                pkt.themsct(ngaychungtu, txtsct,tsbttruoc,tsbtsau,userid);
                this.Text = "Thêm phiếu kế toán";
            }
            cechd.Checked = false;
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pttm")
                refeshpttm();
            else if (pt == "ptnh") refeshptnh();
            else if (pt == "pctm") refeshpctm();
            else if (pt == "pcnh") refeshpcnh();
            else if (pt == "pkt") refeshpkt();
            else if (pt == "ptctm") refeshptctm();
            change();
        }

        /*
        private void txtsct_EditValueChanged(object sender, EventArgs e)
        {
            if (txtsct.Text.Length == 21)
            {
                if (pt == "pttm")
                {
                    try
                    {
                        string ma = gen.GetString("select * from CAReceipt where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshpttm();
                    }
                    catch
                    {
                        if (active == "1")
                        {
                            MessageBox.Show("Không tìm thấy số phiếu " + txtsct.Text);
                        }
                    }
                }
                else if (pt == "ptnh")
                {
                    try
                    {
                        string ma = gen.GetString("select * from BADeposit where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshptnh();
                    }
                    catch
                    {
                        if (active == "1")
                        {
                            MessageBox.Show("Không tìm thấy số phiếu " + txtsct.Text);
                        }
                    }
                }
                else if (pt == "pctm")
                {
                    try
                    {
                        string ma = gen.GetString("select * from CAPayment  where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshpctm();
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
                        string ma = gen.GetString("select * from BATransfer  where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshpcnh();
                    }
                    catch
                    {
                        if (active == "1")
                        {
                            MessageBox.Show("Không tìm thấy số phiếu " + txtsct.Text);
                        }
                    }
                }
                else if (pt == "pkt")
                {
                    try
                    {
                        string ma = gen.GetString("select * from GLVoucher  where RefNo='" + txtsct.Text + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                        role = ma;
                        active = "1";
                        refeshpkt();
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
        
        */
        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pttm")
            {
                pttm.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpttm();
            }
            else if (pt == "ptctm")
            {
                ptctm.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, userid);
                refeshptctm();
            }
            else if (pt == "ptnh")
            {
                ptnh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshptnh();
            }
            else if (pt == "pctm")
            {
                pctm.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpctm();
            }
            else if (pt == "pcnh")
            {
                pcnh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpcnh();
            }
            else if (pt == "pkt")
            {
                pkt.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpkt();
            }
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pttm")
            {
                pttm.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpttm();
            }
            else if (pt == "ptctm")
            {
                ptctm.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, userid);
                refeshptctm();
            }
            else if (pt == "ptnh")
            {
                ptnh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshptnh();
            }
            else if (pt == "pctm")
            {
                pctm.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpctm();
            }
            else if (pt == "pcnh")
            {
                pcnh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpcnh();
            }
            else if (pt == "pkt")
            {
                pkt.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpkt();
            }
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pttm")
            {
                pttm.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpttm();
            }
            else if (pt == "ptctm")
            {
                ptctm.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, userid);
                refeshptctm();
            }
            else if (pt == "ptnh")
            {
                ptnh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshptnh();
            }
            else if (pt == "pctm")
            {
                pctm.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpctm();
            }
            else if (pt == "pcnh")
            {
                pcnh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpcnh();
            }
            else if (pt == "pkt")
            {
                pkt.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpkt();
            }
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pttm")
            {
                pttm.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpttm();
            }
            else if (pt == "ptctm")
            {
                ptctm.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, userid);
                refeshptctm();
            }
            else if (pt == "ptnh")
            {
                ptnh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshptnh();
            }
            else if (pt == "pctm")
            {
                pctm.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpctm();
            }
            else if (pt == "pcnh")
            {
                pcnh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpcnh();
            }
            else if (pt == "pkt")
            {
                pkt.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu,userid);
                refeshpkt();
            }
            change();
        }

        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt(pt);
            F.getcongty("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            F.ShowDialog();
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

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                
                ledv.Enabled = true;
                if (active == "1")
                    if (pt == "pttm" || pt == "pctm")
                        ledv.Enabled = false;
                letq.Enabled = true;
                searchdanhmuc.Properties.ReadOnly = false;
                cbldt.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                txtnn.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                cechd.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                if (gridView1.RowCount < 14)
                {                   
                    gridView1.OptionsBehavior.Editable = true;
                }
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                if(active=="1")
                    tsbtnap.Enabled = true;           
                tsbtsua.Enabled = false;
                if (tsbtkc.Visible == true)
                    tsbtkc.Enabled = true;
                tsbtghiso.Visible = false;
                ledv.Focus();
            }
            else
            {
                ledv.Enabled = false;
                letq.Enabled = false;
                searchdanhmuc.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtnn.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                cechd.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                ledv.Focus();
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

        private void txtld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtctg.Focus();
        }
        private void cbthue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridView1.Focus();
        }
        private void txtctg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbthue.Focus();
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

        private void tsbtxoa_Click_1(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            F.gettsbt(pt + "chitiet");
            F.ShowDialog();
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

        private void tsbtkc_Click(object sender, EventArgs e)
        {
            if (pt == "pkt")
            {
                if (XtraMessageBox.Show("Dữ liệu trong phiếu này sẽ được xóa và thay bằng dữ liệu tự động, Bạn có chắc trước khi thực hiện bước tiếp theo?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(typeof(Frm_wait));
                    auto = 1;
                    searchdanhmuc.EditValue = 0;
                    if (ledt.EditValue == null)
                        ledt.EditValue = "090";
                    txtldn.Text = "Phiếu kết chuyển tự động";
                    while (gridView1.RowCount > 1)
                        gridView1.DeleteRow(0);

                    if (active == "1")
                    {
                        gen.ExcuteNonquery("delete  from  GLVoucherDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                    }

                    string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                    string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                    DataTable ketchuyen = gen.GetTable("tonghoptaikhoan '" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "'");

                    for (int i = 0; i < ketchuyen.Rows.Count; i++)
                    {
                        if ((ketchuyen.Rows[i][0].ToString().Substring(0, 2) == "51" || ketchuyen.Rows[i][0].ToString().Substring(0, 1) == "7" || ketchuyen.Rows[i][0].ToString().Substring(0, 1) == "6") && Double.Parse(ketchuyen.Rows[i][3].ToString()) != 0)
                        {
                            gridView1.AddNewRow();
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], ketchuyen.Rows[i][0].ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "911");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số tiền"], Double.Parse(ketchuyen.Rows[i][3].ToString()));
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], "090");
                            gridView1.UpdateCurrentRow();
                        }
                        else if ((ketchuyen.Rows[i][0].ToString().Substring(0, 1) == "6" || ketchuyen.Rows[i][0].ToString().Substring(0, 2) == "81") && Double.Parse(ketchuyen.Rows[i][2].ToString()) != 0)
                        {
                            gridView1.AddNewRow();
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], ketchuyen.Rows[i][0].ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "911");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số tiền"], Double.Parse(ketchuyen.Rows[i][2].ToString()));
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], "090");
                            gridView1.UpdateCurrentRow();
                        }
                    }
                    auto = 0;
                    gridView1.OptionsBehavior.Editable = false;
                    SplashScreenManager.CloseForm();
                }
            }
            else if (pt == "pttm")
            {
                ledt.Focus();
                if (cbthue.Text != "")
                    try
                    {
                        Double.Parse(cbthue.Text);
                    }
                    catch
                    {
                        XtraMessageBox.Show("Thuế suất không đúng định dạng. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                pttm.checkpttm(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, tsbttruoc, tsbtsau, searchdanhmuc, letq, "1");  
                refreshrole();
                click = "true";
                change();
                click = "false";
                if (active == "1")
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Duyệt đơn vị','" + txtsct.Text + "')");
                else
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Duyệt đơn vị','" + txtsct.Text + "')");
                tsbtkc.Visible = false;
                tsbtcat.Visible = false;
            }

        }

        private void btdulieu_Click(object sender, EventArgs e)
        {
            string ngaycuoi = DateTime.Parse(DateTime.Parse(denht.EditValue.ToString()).ToShortDateString()).AddDays(1).AddSeconds(-1).ToString();
            string ngaydau = DateTime.Parse(denht.EditValue.ToString()).ToShortDateString();
            //pttm.loadStockmain(lenv, ngaydau, ngaycuoi, ledv.Text);
        }

        private void searchdanhmuc_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void toolptt_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(role);
            if (pt == "pttm")
                F.gettsbt(pt + "donvi");
            else if (pt == "pctm")
                F.gettsbt(pt + "bangkethanhtoan");       
            F.ShowDialog();
        }

        private void toolduyet_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (cbthue.Text != "")
                try
                {
                    Double.Parse(cbthue.Text);
                }
                catch
                {
                    XtraMessageBox.Show("Thuế suất không đúng định dạng. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            if (pt == "pttm") pttm.checkpttm(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, tsbttruoc, tsbtsau, searchdanhmuc, letq, "2");
            else if (pt == "ptctm") ptctm.checkpttm(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, tsbttruoc, tsbtsau, searchdanhmuc);
            else if (pt == "ptnh") ptnh.checkptnh(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, txthtt, tsbttruoc, tsbtsau, searchdanhmuc);
            else if (pt == "pctm") pctm.checkpctm(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, tsbttruoc, tsbtsau, searchdanhmuc, "1", letq);
            else if (pt == "pcnh") pcnh.checkpcnh(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, userid, txthtt, tsbttruoc, tsbtsau, searchdanhmuc);
            else if (pt == "pkt") pkt.checkpkt(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtnn, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txthtt, userid, tsbttruoc, tsbtsau, tsbtkc, searchdanhmuc);
            refreshrole();
            click = "true";
            change();
            click = "false";
            if (active == "1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Duyệt','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Duyệt','" + txtsct.Text + "')");
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            if (pt == "pttm")
            {
                pttm.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid, ledv.EditValue.ToString());
                if (active == "0")
                    letq.EditValue = ledv.EditValue;
            }
            else if (pt == "pctm")
            {
                pctm.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid, ledv.EditValue.ToString());
                if (active == "0")
                    letq.EditValue = ledv.EditValue;
            }
        }
    }
}