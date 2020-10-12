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
    public partial class Frm_phieunhapkho : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
        phieunhapkho pnk = new phieunhapkho();
        phieunhapkhothucte tsbtpnktt = new phieunhapkhothucte();
        phieuxuatkho pxk = new phieuxuatkho();
        hdbanhang hdbh = new hdbanhang();
        hdmuahang hdmh = new hdmuahang();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup, click, roleid, subsys, load = null, mahangtam, phieu = null;
        int K = -2;
        Double slhien = 0,slqdhien=0;

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
            pnk.loadpnk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc,lenv,tsbttruoc,tsbtsau,khach,hang,dongia,thanhtien);
        }
        public void refreshtsbtpnktt()
        {
            tsbtpnktt.loadpnk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, lenv, tsbttruoc, tsbtsau, khach, hang, dongia, thanhtien, cthg, chpck, pt, chhtk,chtnm,chhgnb);
        }
        public void refreshpxk()
        {
            pxk.loadpxk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc,dongia,thanhtien,txtcth,cbthue,lenv,chiphi,chietkhau,txtck,tsbttruoc,tsbtsau,khach,hang,txttthue,txtname,txtdc);
        }
        public Frm_phieunhapkho()
        {
            InitializeComponent();
        }
        public void getdoituong(string a, string check)
        {
            if(check=="1")
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

        private void Frm_phieunhapkho_KeyUp(object sender, KeyEventArgs e)
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

        private void Frm_phieunhapkho_Load(object sender, EventArgs e)
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
                labelControl13.Text = "Phiếu xuất kho hàng hóa";
            }
            else if (pt == "tsbtpxkhg")
            {
                refreshtsbtpnktt();
                labelControl13.Text = "Phiếu xuất kho hàng gửi";
                chhtk.Visible = true;
                chtnm.Visible = true;
            }
            else if (pt == "tsbtpnktt")
            {
                labelControl12.Hide();
                chpck.Visible = true;
                cthg.Visible = true;
                //chhgnb.Visible = true;  
                cbthue.Hide();
                panelControl6.Hide();
                refreshtsbtpnktt();
                toolStripSplitButton1.Visible = true;
                if (phieu != null)
                    loaddonhang();
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
                    {
                        tsbtin.Enabled = true;
                        toolStripSplitButton1.Enabled = true;
                    }
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
                lenv.Properties.ReadOnly = false;
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
                txtngh.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
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

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    if (pt == "pnk")
                        pnk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                    else if (pt == "tsbtpnktt")
                        tsbtpnktt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                    else if (pt == "tsbtpxkhg")
                        tsbtpnktt.themsctxkhg(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                    else
                        pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
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
            if (e.Column.FieldName == "Mã hàng")
            {
                try
                {
                    if (caseup == "4")
                    {
                        Double ketqua = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString());
                        if (ketqua != 0)
                        {
                            XtraMessageBox.Show("< Số lượng quy đổi đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString() + " bạn không được nhập mã khác", "Thông báo");
                            caseup = null;
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], mahangtam);
                        }
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
                    }
                }
                catch
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
            }
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    Double kiemtra = 0;
                    Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                    if (active == "1")
                    {
                        try
                        {
                            Double slton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                            if (sl >= slton)
                                kiemtra = 1;
                        }
                        catch { kiemtra = 1; }
                    }
                    if (kiemtra == 1 || active == "0")
                    {
                        caseup = "1";
                        for (int i = 0; i < hang.Rows.Count; i++)
                        {
                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                            {
                                Double quydoi = Double.Parse(hang.Rows[i][5].ToString());
                                quydoi = Math.Round((sl * quydoi), 2);
                                if (active == "1")
                                {
                                    try
                                    {
                                        if (quydoi >= Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString()))
                                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], quydoi.ToString());
                                    }
                                    catch
                                    {
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi tồn"], "0");
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], quydoi.ToString());
                                    }
                                }
                                else
                                {
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], quydoi.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("< Số lượng đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString() + " vui lòng nhập số lượng lớn hơn", "Thông báo");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], slhien.ToString());
                    }
                }
                catch { }
            }
            if (pt == "pxk")
            {
                if (e.Column.FieldName == "Số lượng quy đổi")
                {
                    if (caseup == "1")
                    {
                        Double kiemtra = 0;
                        Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        if (active == "1")
                        {
                            try
                            {
                                Double slton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString());
                                if (sl >= slton)
                                    kiemtra = 1;
                            }
                            catch { kiemtra = 1; }
                        }
                        if (kiemtra == 1 || active == "0")
                        {
                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                            {
                                Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                            }
                            else if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                            {
                                Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("< Số lượng quy đổi đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString() + " vui lòng nhập số lượng quy đổi lớn hơn", "Thông báo");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], slqdhien.ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Đơn giá")
                {
                    if (caseup == "7")
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
            else
            {
                if (e.Column.FieldName == "Số lượng quy đổi")
                {
                    if (caseup == "1")
                    {
                        Double kiemtra = 0;
                        Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        if (active == "1")
                        {
                            try
                            {
                                Double slton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString());
                                if (sl >= slton)
                                    kiemtra = 1;
                            }
                            catch 
                            {
                                kiemtra = 1;
                            } 
                        }
                        if (kiemtra == 1 || active == "0")
                        {
                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString() != "")
                            {
                                Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString());
                                Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá phí"], Math.Round((a / b), 2).ToString());
                            }
                            else if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString() != "")
                            {
                                Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString());
                                Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp"], Math.Round((b * a), 0).ToString());
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("< Số lượng quy đổi đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString() + " vui lòng nhập số lượng quy đổi lớn hơn", "Thông báo");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], slqdhien.ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Đơn giá phí")
                {
                    if (caseup == "7")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp"], Math.Round((b * a), 0).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Bốc xếp")
                {
                    if (caseup == "2")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá phí"], Math.Round((a / b), 2).ToString());
                        }
                    }
                }
            }
        }

        private void dongia_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "7";
        }
        private void soluong_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "3";
            try
            {
                slhien = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
            }
            catch { }
        }
        private void soluongqd_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "1";
            try
            {
                slqdhien = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
            }
            catch { }
        }
        private void mahang_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "4";
            try
            {       
                mahangtam = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString();
            }
            catch { }
        }
        private void thanhtien_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "2";
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                try
                {
                    Double ton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString());
                    if (ton != 0)
                    {
                        XtraMessageBox.Show("< Số lượng quy đổi đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString() + " nên bạn không được xóa dòng này", "Thông báo");
                    }
                    else
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView1.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;
                        gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    }
                }
                catch
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView1.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                }
            }
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (pt == "pnk")
                pnk.checkpnk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, lenv, tsbttruoc, tsbtsau);
            else if (pt == "tsbtpnktt" || pt == "tsbtpxkhg")
                tsbtpnktt.checkpnk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, lenv, tsbttruoc, tsbtsau, cthg, chpck, pt, chhtk, chtnm, chhgnb);
            else
                pxk.checkpxk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, cbthue, lenv, tsbttruoc, tsbtsau, txttthue);
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
            if (pt == "pnk" || pt=="tsbtpnktt")
                this.Text = "Sửa phiếu nhập kho";
            else if(pt=="tsbtpxkhg")
                this.Text = "Sửa phiếu xuất kho hàng gửi khách hàng";
            else
                this.Text = "Sửa phiếu xuất kho";
            tsbtcat.Enabled = true;
            tsbtxoa.Enabled = false;
            tsbtin.Enabled = false;
            tsbtnap.Enabled = true;
            tsbtsua.Enabled = false;
            tsbtghiso.Enabled = false;
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();
            cbldt.SelectedIndex = 0;
            ledt.EditValue = "3";
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
            change();
            if (pt == "pnk")
            {
                pnk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu nhập kho";
            }
            else if (pt == "tsbtpnktt")
            {
                tsbtpnktt.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                this.Text = "Thêm phiếu nhập kho";
            }
            else if (pt == "tsbtpxkhg")
            {
                tsbtpnktt.themsctxkhg(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                this.Text = "Thêm phiếu xuất kho hàng gửi khách hàng";
            }
            else
            {
                pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                this.Text = "Thêm phiếu xuất kho";
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
            if (pt == "pnk")
                gen.ExcuteNonquery("update INInward set Posted='True' where RefID='" + role + "'");
            else if (pt == "tsbtpnktt" || pt=="tsbtpxkhg")
                gen.ExcuteNonquery("update INInwardTT set Posted='True' where RefID='" + role + "'");
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
            else if (pt == "tsbtpnktt" || pt == "tsbtpxkhg")
                gen.ExcuteNonquery("update INInwardTT set Posted='False' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INOutward set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pnk")
                refreshpnk();
            else if (pt == "tsbtpnktt" || pt=="tsbtpxkhg")
                refreshtsbtpnktt();
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
            else if (pt == "tsbtpnktt")
            {
                tsbtpnktt.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshtsbtpnktt();
            }
            else if (pt == "tsbtpxkhg")
            {
                tsbtpnktt.checktruocxkhg(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshtsbtpnktt();
            }
            else
            {
                pxk.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }
            change();
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
            else if (pt == "tsbtpnktt")
            {
                tsbtpnktt.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshtsbtpnktt();
            }
            else if (pt == "tsbtpxkhg")
            {
                tsbtpnktt.checktruocxkhg(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshtsbtpnktt();
            }
            else
            {
                pxk.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }
            change();
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
            else if (pt == "tsbtpnktt")
            {
                tsbtpnktt.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshtsbtpnktt();
            }
            else if (pt == "tsbtpxkhg")
            {
                tsbtpnktt.checksauxkhg(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshtsbtpnktt();
            }
            else
            {
                pxk.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }
            change();
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
            else if (pt == "tsbtpnktt")
            {
                tsbtpnktt.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshtsbtpnktt();
            }
            else if (pt == "tsbtpxkhg")
            {
                tsbtpnktt.checksauxkhg(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshtsbtpnktt();
            }
            else
            {
                pxk.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }
            change();
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
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            catch
            {
                gtgt = 0;
            }
            tong = cth + gtgt;
            txttthue.EditValue =  gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", ""));
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
                txttc.Text = String.Format("{0:n0}", tong);
                txttthue.EditValue = gtgt;
            }
            catch { }
        }

        private void lenv_EditValueChanged(object sender, EventArgs e)
        {
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
            catch { txtnv.EditValue = null; }
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
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            catch
            {
                gtgt = 0;
            }

            tong = cth + gtgt;
            txttthue.EditValue = gtgt;
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
                F.gettsbt(pt);
                F.getrole(role);
                F.getcongty("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
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

        private void chuyểnHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pt == "pxk")
                hdbh.tsbthdbhchuyen("0", role, roleid, subsys, ngaychungtu, userid, branchid, ledt.EditValue.ToString(), ledv.EditValue.ToString(),khach,hang, lenv.EditValue.ToString(),"");
            else if (pt == "pnk")
                hdmh.tsbthdbhchuyen("0", role, roleid, subsys, ngaychungtu, userid, branchid, ledt.EditValue.ToString(), ledv.EditValue.ToString(),khach,hang);
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, gtgt, tong, ck;
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

            cth = cth - ck;
            gtgt = Double.Parse(txttthue.Text);
            tong = cth + gtgt;

            txttthue.EditValue =  gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt+"bienban");
            F.getrole(role);
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
                caseup = "4";
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

        private void chpck_CheckedChanged(object sender, EventArgs e)
        {
            if (chpck.Checked == true)
                cthg.Checked = false;
        }

        private void cthg_CheckedChanged(object sender, EventArgs e)
        {
            if (cthg.Checked == true)
                chpck.Checked = false;
        }

        private void chtnm_CheckedChanged(object sender, EventArgs e)
        {
            if (chtnm.Checked == true)
                chhtk.Checked = false;
        }

        private void chhtk_CheckedChanged(object sender, EventArgs e)
        {
            if (chhtk.Checked == true)
                chtnm.Checked = false;
        }

        private void toolddh_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtpnkttphieu");
            F.getrole(role);
            F.ShowDialog();
        }

        private void toolbbgnh_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtpnkttbienban");
            F.getrole(role);
            F.getkho("0");
            F.ShowDialog();
        }

        private void loaddonhang()
        {
            if (active == "0")
            {
                DataTable temp=new DataTable();
                if (phieu.Substring(6, 4) == "DDHN")
                {
                    temp = gen.GetTable("select StockCode,AccountingObjectCode,JournalMemo,DocumentIncluded,ShippingNo,a.RefID from DDHNCC a, Stock b, AccountingObject c where a.AccountingObjectID=c.AccountingObjectID and a.StockID=b.StockID and RefNo='" + phieu + "'");
                    cthg.Checked = true;
                }
                else if (phieu.Substring(6, 4) == "DDHH")
                    temp = gen.GetTable("select StockCode,c.AccountingObjectCode,JournalMemo,DocumentIncluded,ShippingNo,a.RefID from DDH a, Stock b, AccountingObject c where a.AccountingObjectID=c.AccountingObjectID and a.InStockID=b.StockID and RefNo='" + phieu + "'");
                ledv.EditValue = temp.Rows[0][0].ToString();
                ledt.EditValue = temp.Rows[0][1].ToString();
                txtldn.EditValue = temp.Rows[0][2].ToString();
                txtptvc.EditValue = temp.Rows[0][4].ToString();
                txtctg.Text = phieu;
                if (phieu.Substring(6, 4) == "DDHN")
                    temp = gen.GetTable("select InventoryItemCode,InventoryItemName,a.Quantity,a.QuantityConvert from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + temp.Rows[0][5].ToString() + "'");
                else if (phieu.Substring(6, 4) == "DDHH")
                    temp = gen.GetTable("select InventoryItemCode,InventoryItemName,a.QuantityExits,a.QuantityConvertExits from DDHDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + temp.Rows[0][5].ToString() + "'");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], temp.Rows[i][0].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], temp.Rows[i][1].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], Double.Parse(temp.Rows[i][2].ToString()));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Double.Parse(temp.Rows[i][3].ToString()));
                    gridView1.UpdateCurrentRow();
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