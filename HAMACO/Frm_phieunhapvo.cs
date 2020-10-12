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
    public partial class Frm_phieunhapvo : DevExpress.XtraEditors.XtraForm
    {
        public Frm_phieunhapvo()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
        phieunhapvo pnk = new phieunhapvo();
        phieunhapvodk pnktddh = new phieunhapvodk();
        phieuxuatvo pxk = new phieuxuatvo();
        public delegate void ac();
        public ac myac;
        int K=-2;
        string role, active, ngaychungtu, userid, branchid, pt, caseup,roleid,subsys,click,load=null;
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

        private void Frm_phieunhapvo_KeyUp(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
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
            else*/
            if (tsbtcat.Enabled == true)
            {
                if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
                {
                    try
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mượn"], "True");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Trả"], "False");
                    }
                    catch { }
                }
                else if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
                {
                    try
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mượn"], "False");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Trả"], "True");                       
                    }
                    catch { }
                }
                else if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
                {
                    try
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mượn"], "False");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Trả"], "False");
                    }
                    catch { }
                }
            }
        }

        private void Frm_nhapkhovo_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole(); 
            if (pt == "pnk")
            {
                refreshpnk();
                chtc.Text = "Phiếu nhập thế chân vỏ";
            }
            else if (pt == "pxk")
            {
                refreshpxk();
                labelControl13.Text = "Phiếu xuất kho Vỏ LPG";
                chtc.Text = "Phiếu xuất thế chân vỏ";
            }
            else if (pt == "pnkvtddh")
            {
                refreshpnktddh();
                labelControl13.Text = "Phiếu nhập kho vỏ LPG theo đơn đặt hàng";
            }
            change();
            radioGroup1.SelectedIndex=-1;
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
        public void refreshpnktddh()
        {
            pnktddh.loadpnk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, dongia, thanhtien, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, taikhoan, tsbttruoc, tsbtsau, khach, hang, chtc, congty,txttaixe);
        }
        public void refreshpnk()
        {
            pnk.loadpnk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, dongia, thanhtien, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, taikhoan, tsbttruoc, tsbtsau, khach, hang, chtc);
        }
        public void refreshpxk()
        {
            pxk.loadpxk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, dongia, thanhtien, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, taikhoan, tsbttruoc, tsbtsau, khach, hang, chtc,txttaixe);
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
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                txtngh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                chtc.Properties.ReadOnly = false;
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
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                txtngh.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
                chtc.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                ledv.Focus();
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
                    else if (pt == "pnkvtddh")
                        pnktddh.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
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

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Tài khoản nợ")
            {
                if (gridView1.FocusedRowHandle > 0) 
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
            }

            else if (e.Column.FieldName == "Mã hàng")
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Diễn giải"], hang.Rows[i][7].ToString());
                        try
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], hang.Rows[i][6].ToString());
                        }
                        catch { }
                        return;
                    }
                }
            }

            else if (e.Column.FieldName == "Số lượng" || e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "1")
                {
                    Double a = 0, b = 0, c = 0;
                    if (pt == "pnkvtddh")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "")
                            a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng xuất").ToString() != "")
                            b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng xuất").ToString());
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thế chân").ToString() != "")
                            c = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thế chân").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chênh lệch"], (b - a - c).ToString());
                    }

                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());

                    }

                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá BX").ToString() != "")
                    {
                        a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá BX").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp"], Math.Round((a * b), 0).ToString());

                    }
                }
            }
            else if (e.Column.FieldName == "Đơn giá BX")
            {
                if (caseup == "1")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá BX").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá BX").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp"], Math.Round((a * b), 0).ToString());
                    }
                }        
            }
            else if (e.Column.FieldName == "Bốc xếp")
            {
                if (caseup == "2")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá BX"], Math.Round((b / a), 2).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thế chân")
            {
                if (caseup == "1")
                {
                    Double a = 0, b = 0, c = 0;
                    if (pt == "pnkvtddh")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "")
                            a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng xuất").ToString() != "")
                            b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng xuất").ToString());
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thế chân").ToString() != "")
                            c = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thế chân").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chênh lệch"], (b - a - c).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {
                if (caseup == "2")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Khác")
            {
                if (pt == "pnk")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Khác").ToString() == "True")
                    {
                        if (cbldt.EditValue.ToString() == "Khách hàng")
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "131");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "34412");
                        }
                        else
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "24412");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "331");
                        }

                    }
                    else
                    {
                        if (cbldt.EditValue.ToString() == "Khách hàng")
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "131");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "34411");
                        }
                        else
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "24411");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "331");
                        }
                    }
                }
                else if (pt == "pxk")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Khác").ToString() == "True")
                    {
                        if (cbldt.EditValue.ToString() == "Khách hàng")
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "34412");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "131");
                        }
                        else
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "331");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "24412");
                        }

                    }
                    else
                    {
                        if (cbldt.EditValue.ToString() == "Khách hàng")
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "34411");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "131");
                        }
                        else
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "331");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "24411");
                        }
                    }
                }

            }
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

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (pt == "pnk")
                pnk.checkpnk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, tsbttruoc, tsbtsau, chtc);
            else if (pt == "pnkvtddh")
                pnktddh.checkpnk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, tsbttruoc, tsbtsau, chtc, txttaixe);
            else
                pxk.checkpxk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, tsbttruoc, tsbtsau, chtc,txttaixe);
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
            this.Text = "Sửa phiếu nhập kho";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();
            cbldt.SelectedIndex = 0;
            ledt.EditValue = null;
            txtctg.Text = "";
            txtldn.Text = "";
            txtngh.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            txtptvc.Text = "";
            txttaixe.Text = "";
            txtmst.Text = "";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            change();
            if (pt == "pnk")
                pnk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);                
            else if (pt == "pnkvtddh")
                pnktddh.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            else
                pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
       
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
                gen.ExcuteNonquery("update INInwardSU set Posted='True' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INOutwardSU set Posted='True' where RefID='" + role + "'");
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
                gen.ExcuteNonquery("update INInwardSU set Posted='False' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INOutwardSU set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pnk")
                refreshpnk();
            else
                refreshpxk();
            change();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            refreshrole();
            if (pt == "pnk")
            {
                pnk.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnk();
            }
            else if (pt == "pnkvtddh")
            {
                pnktddh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnktddh();
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
            else if (pt == "pnkvtddh")
            {
                pnktddh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnktddh();
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
            else if (pt == "pnkvtddh")
            {
                pnktddh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnktddh();
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
            else if (pt == "pnkvtddh")
            {
                pnktddh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpnktddh();
            }
            else
            {
                pxk.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            }
            change();
        }

        private void tsbtin_ButtonClick(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            if (pt == "pnkvtddh")
            {
                F.gettsbt("pnkvo");
                F.getrole(gen.GetString("select RefID from INInwardSU where RefNo='" + txtsct.Text + "'"));
            }
            else
            {
                F.gettsbt(pt + "vo");
                F.getrole(role);
            }
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

        private void insl_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            if (pt == "pnkvtddh")
            {
                F.gettsbt("pnkvosl");
                F.getrole(gen.GetString("select RefID from INInwardSU where RefNo='" + txtsct.Text + "'"));
            }
            else
            {
                F.gettsbt(pt + "vosl");
                F.getrole(role);
            }
            F.ShowDialog();
        }

        private void ktps_Click(object sender, EventArgs e)
        {
            baocaocongno131 bccn = new baocaocongno131();
            denht.EditValue = DateTime.Parse(DateTime.Parse(denht.EditValue.ToString()).Month + "/" + DateTime.Parse(denht.EditValue.ToString()).Day + "/" + DateTime.Parse(denht.EditValue.ToString()).Year);
            string donvi = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            bccn.loadbkthpsv(denht.EditValue.ToString(), ledt.EditValue.ToString(), "bkthpsvp", donvi);
        }

        private void txtctg_EditValueChanged(object sender, EventArgs e)
        {
            if (txtctg.Text.Length == 21 && pt == "pnkvtddh" && txtctg.Properties.ReadOnly==false)
            {
                while (gridView1.RowCount > 1)
                {
                    gridView1.DeleteRow(0);
                }
                DataTable temp = new DataTable();
                temp = gen.GetTable("select  InventoryItemCode,Quantity,Quantity,c.CustomField2,c.CustomField6,ShippingNo from INOutwardLPGDetail a,InventoryItem b,INOutwardLPG c where a.InventoryItemID=b.InventoryItemID and a.RefID=c.RefID and RefNo='" + txtctg.Text + "' order by SortOrder");
                
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    txtngh.Text = temp.Rows[i][3].ToString();
                    txtptvc.Text = temp.Rows[i][4].ToString();
                    txttaixe.Text = temp.Rows[i][5].ToString();
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], temp.Rows[i][0].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng xuất"], temp.Rows[i][1].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chênh lệch"],temp.Rows[i][2].ToString());
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