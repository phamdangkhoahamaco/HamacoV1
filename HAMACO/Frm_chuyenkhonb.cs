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
    public partial class Frm_chuyenkhonb : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable hangton = new DataTable();
        DataTable hang = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
        phieuchuyenkhonb pck = new phieuchuyenkhonb();
        phieuchuyenkhonbvlpg pckv = new phieuchuyenkhonbvlpg();
        int K = -2;
        int nhan = 0;
        phieuxuathanggb pxhgb = new phieuxuathanggb();
        phieuxuathanggbvlpg pxhgbvlpg = new phieuxuathanggbvlpg();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup,roleid,subsys,click,khosua=null,phieusua=null,bat=null;
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
        public DataTable gethangton(DataTable a)
        {
            hangton = a;
            view_FocusedRowChanged();
            return hangton;
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

        public Frm_chuyenkhonb()
        {
            InitializeComponent();
        }

        private void Frm_chuyenkhonb_KeyUp(object sender, KeyEventArgs e)
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
                    tsbtxoa_Click(this, e);
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


        private void Frm_chuyenkhonb_Load(object sender, EventArgs e)
        {
            try
            {
                dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
                tsbtsau.Enabled = false;
            }
            refreshrole();
            if (pt == "pck" || pt == "tsbtpncknb")
            {
                refreshpnk();
            }
            else if (pt == "pckv" || pt=="tsbtpncknbvlpg")
            {
                refreshpckv();
                labelControl13.Text = "Phiếu xuất chuyển kho nội bộ vỏ LPG";
            }
            else if (pt == "pxhgb" || pt=="tsbtpnhgb" )
            {
                refreshpxhgb();
                labelControl13.Text = "Phiếu xuất hàng gửi bán";
            }
            else
            {
                refreshpxhgbvlpg();
                labelControl13.Text = "Phiếu xuất hàng gửi bán vỏ LPG";
            }
            if (pt == "pck" || pt == "pxhgb" || pt == "tsbtcknbvlpg" || pt == "tsbtxhgbvlpg")
                checkEdit2.Enabled = false;
            change();
            radioGroup1.SelectedIndex = -1;
        }

        private void refreshrole()
        {
            tsbtsua.Enabled = false;
            tsbtadd.Enabled = false;
            tsbtcat.Enabled = false;
            tsbtxoa.Enabled = false;
            //tsbtin.Enabled = false;
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

       
        public void refreshpnk()
        {
            nhan = 0;
            pck.loadpck(active, role, gridControl1, gridView1, txtsct, ledvn, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, dongia, thanhtien, txtsctn, txtcth, chiphi, txtnhd, txtms, txtkhhd, txtshd, tsbttruoc, tsbtsau, pt,khach,hang,checkEdit1,checkEdit2);
            gridView1.BestFitColumns();
            nhan = 1;
        }
        public void refreshpckv()
        {
            nhan = 0;
            pckv.loadpck(active, role, gridControl1, gridView1, txtsct, ledvn, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, dongia, thanhtien, txtsctn, txtcth, chiphi, txtnhd, txtms, txtkhhd, txtshd,tsbttruoc,tsbtsau,pt,khach,hang,checkEdit2,txtgiaonhan,txttaixe);
            gridView1.BestFitColumns();
            nhan = 1;
        }
        public void refreshpxhgb()
        {
            nhan = 0;
            pxhgb.loadpck(active, role, gridControl1, gridView1, txtsct, ledvn, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, dongia, thanhtien, txtsctn, txtcth, chiphi, txtnhd, txtms, txtkhhd, txtshd,tsbttruoc,tsbtsau,pt,khach,hang,checkEdit1,checkEdit2);
            gridView1.BestFitColumns();
            nhan = 1;
        }
        public void refreshpxhgbvlpg()
        {
            nhan = 0;
            pxhgbvlpg.loadpck(active, role, gridControl1, gridView1, txtsct, ledvn, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, dongia, thanhtien, txtsctn, txtcth, chiphi, txtnhd, txtms, txtkhhd, txtshd,tsbttruoc,tsbtsau,pt,khach,hang,checkEdit2);
            gridView1.BestFitColumns();
            nhan = 1;
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                {
                    ledv.Properties.ReadOnly = false;
                }
                ledvn.Properties.ReadOnly = false;
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
                txtms.Properties.ReadOnly =true;
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

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (pt == "pck" || pt == "pxhgb")
                {
                    string kho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                    string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                    hangton = gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
                }

                if (active == "0")
                {
                    if (pt == "pck")
                    {
                        pck.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                        pck.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                    }
                    else if (pt == "pckv")
                    {
                        pckv.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc, tsbtsau);
                        pckv.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                    }
                    else if (pt == "pxhgb")
                    {
                        pxhgb.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                        pxhgb.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                    }
                    else
                    {
                        pxhgbvlpg.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                        pxhgbvlpg.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                    }
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
                        if (pt == "pckv")
                        {
                            try
                            {
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], hang.Rows[i][6].ToString());
                            }
                            catch { }
                        }
                        return;
                    }
                }
            }

            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "1";
                    for (int i = 0; i < hangton.Rows.Count; i++)
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hangton.Rows[i][3].ToString() && hangton.Rows[i][6].ToString() != "")
                        {
                            Double quydoi = Double.Parse(hangton.Rows[i][6].ToString());
                            Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], hangton.Rows[i][4].ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Math.Round((sl * quydoi), 2).ToString());
                            return;
                        }
                    }

                    for (int i = 0; i < hang.Rows.Count; i++)
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            Double quydoi = Double.Parse(hang.Rows[i][5].ToString());
                            Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            if (pt == "pckv")
                            {
                                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                                }
                                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp"], Math.Round((a * b), 0).ToString());
                                }
                                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá xuất").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá xuất").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp xuất"], Math.Round((a * b), 0).ToString());
                                }
                            }
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Math.Round((sl * quydoi), 2).ToString());
                            return;
                        }
                    }
                }
                catch { }
            }

            if (e.Column.FieldName == "Số lượng quy đổi" || e.Column.FieldName == "Đơn giá" || e.Column.FieldName == "Đơn giá phí" || e.Column.FieldName == "Đơn giá xuất")
            {
                if (caseup == "1")
                {
                    if (pt == "pck" || pt == "pxhgb")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp"], Math.Round((a * b), 0).ToString());
                        }
                    }
                    else
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá phí").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp"], Math.Round((a * b), 0).ToString());
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá xuất").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá xuất").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Bốc xếp xuất"], Math.Round((a * b), 0).ToString());
                        }
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền" || e.Column.FieldName == "Chi phí" || e.Column.FieldName == "Bốc xếp" || e.Column.FieldName == "Bốc xếp xuất")
            {
                try
                {
                    Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                    Double chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                    txtcth.Text = String.Format("{0:n0}", thanhtien + chiphi);
                }
                catch
                {
                    Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                    txtcth.Text = String.Format("{0:n0}", thanhtien);
                }
                if (caseup == "2")
                {
                    if (pt == "pck" || pt == "pxhgb")
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
                    else
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá phí"], Math.Round((b / a), 2).ToString());
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp xuất").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bốc xếp xuất").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá xuất"], Math.Round((b / a), 2).ToString());
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
                Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                Double chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                txtcth.Text = String.Format("{0:n0}", thanhtien + chiphi);
            }
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (pt == "pck")
                pck.checkpck(active, role, this, gridView1, ledt, ledv, ledvn, txtsct, txtname, txtngh, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtptvc, userid, branchid, txtsctn, txtms, txtkhhd, txtshd, txtnhd, tsbttruoc, tsbtsau, bat, hangton, checkEdit1);
            else if (pt == "pckv")
                pckv.checkpck(active, role, this, gridView1, ledt, ledv, ledvn, txtsct, txtname, txtngh, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtptvc, userid, branchid, txtsctn, txtms, txtkhhd, txtshd, txtnhd, tsbttruoc, tsbtsau, bat, txtgiaonhan, txttaixe);
            else if (pt == "pxhgb")
                pxhgb.checkpck(active, role, this, gridView1, ledt, ledv, ledvn, txtsct, txtname, txtngh, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtptvc, userid, branchid, txtsctn, txtms, txtkhhd, txtshd, txtnhd, tsbttruoc, tsbtsau, bat, hangton, checkEdit1);
            else
                pxhgbvlpg.checkpck(active, role, this, gridView1, ledt, ledv, ledvn, txtsct, txtname, txtngh, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtptvc, userid, branchid, txtsctn, txtms, txtkhhd, txtshd, txtnhd, tsbttruoc, tsbtsau, bat);
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
            khosua = ledvn.EditValue.ToString();
            phieusua = txtsctn.Text;
            bat = "0";
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
            checkEdit1.EditValue = false;
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            change();
            if (pt == "pck")
            {
                pck.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                pck.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                this.Text = "Thêm phiếu xuất chuyển hàng nội bộ";
            }
            else if(pt=="pckv")
            {
                pckv.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                pckv.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                this.Text = "Thêm phiếu xuất chuyển kho nội bộ vỏ LPG";
            }
            else if (pt == "pxhgb")
            {
                pxhgb.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc,tsbtsau);
                pxhgb.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                this.Text = "Thêm phiếu xuất hàng gửi bán";
            }
            else
            {
                pxhgbvlpg.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                pxhgbvlpg.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                this.Text = "Thêm phiếu xuất hàng gửi bán vỏ LPG";
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
                gen.ExcuteNonquery("update INTransfer set Posted='True' where RefID='" + role + "'");
            else if(pt=="pckv")
                gen.ExcuteNonquery("update INTransferSU set Posted='True' where RefID='" + role + "'");
            else if (pt == "pxhgb")
                gen.ExcuteNonquery("update INTransferBranch set Posted='True' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INTransferBranchSU set Posted='True' where RefID='" + role + "'");
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
                gen.ExcuteNonquery("update INTransfer set Posted='False' where RefID='" + role + "'");
            else if(pt=="pckv")
                gen.ExcuteNonquery("update INTransferSU set Posted='False' where RefID='" + role + "'");
            else if (pt == "pxhgb")
                gen.ExcuteNonquery("update INTransferBranch set Posted='False' where RefID='" + role + "'");
            else
                gen.ExcuteNonquery("update INTransferBranchSU set Posted='False' where RefID='" + role + "'");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pck" || pt=="tsbtpncknb")
                refreshpnk();
            else if(pt=="pckv" || pt=="tsbtpncknbvlpg")
                refreshpckv();
            else if (pt == "pxhgb" || pt=="tsbtpnhgb")
                refreshpxhgb();
            else
                refreshpxhgbvlpg();
            change();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pck")
            {
                pck.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpnk();
            }
            else if ( pt == "tsbtpncknb")
            {
                pck.checktruoc(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(), pt);
                refreshpnk();
            }
            else if(pt=="pckv")
            {
                pckv.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpckv();
            }
            else if (pt == "tsbtpncknbvlpg")
            {
                pckv.checktruoc(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpckv();
            }
            else if (pt == "pxhgb")
            {
                pxhgb.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else if (pt == "tsbtpnhgb")
            {
                pxhgb.checktruoc(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else if(pt=="tsbtpnhgbvlpg")
            {
                pxhgbvlpg.checktruoc(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgbvlpg();
            }
            else
            {
                pxhgbvlpg.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgbvlpg();
            }
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pck")
            {
                pck.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpnk();
            }
            else if (pt == "tsbtpncknb")
            {
                
                pck.checktruoc(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpnk();
            }
            else if(pt=="pckv")
            {
                pckv.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpckv();
            }
            else if (pt == "tsbtpncknbvlpg")
            {
                pckv.checktruoc(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpckv();
            }
            else if (pt == "pxhgb")
            {
                pxhgb.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else if (pt == "tsbtpnhgb")
            {
                pxhgb.checktruoc(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else if(pt=="tsbtpnhgbvlpg")
            {
                pxhgbvlpg.checktruoc(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgbvlpg();
            }
            else
            {
                pxhgbvlpg.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgbvlpg();
            }
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pck" || pt == "pncknb")
            {
                pck.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpnk();
            }
            else if (pt == "tsbtpncknb")
            {
                pck.checksau(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(), pt);
                refreshpnk();
            }
            else if(pt=="pckv")
            {
                pckv.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpckv();
            }
            else if (pt == "tsbtpncknbvlpg")
            {
                pckv.checksau(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpckv();
            }
            else if (pt == "pxhgb")
            {
                pxhgb.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else if (pt == "tsbtpnhgb")
            {
                pxhgb.checksau(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else if(pt=="tsbtpnhgbvlpg")
            {
                pxhgbvlpg.checksau(txtsctn.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgbvlpg();
            }
            else
            {
                pxhgbvlpg.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgbvlpg();
            }
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            if (pt == "pck"|| pt=="pncknb")
            {
                pck.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpnk();
            }
            else if (pt == "tsbtpncknb")
            {
                pck.checksau(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(), pt);
                refreshpnk();
            }
            else if(pt=="pckv") 
            {
                pckv.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpckv();
            }
            else if (pt == "tsbtpncknbvlpg")
            {
                pckv.checksau(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpckv();
            }
            else if (pt == "pxhgb")
            {
                pxhgb.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else if (pt == "tsbtpnhgb")
            {
                pxhgb.checksau(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgb();
            }
            else if(pt=="tsbtpnhgbvlpg")
            {
                pxhgbvlpg.checksau(txtsctn.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvn.EditValue.ToString(),pt);
                refreshpxhgbvlpg();
            }
            else
            {
                pxhgbvlpg.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString(),pt);
                refreshpxhgbvlpg();
            }
            change();
        }

        private void ledvn_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "1")
                {
                    if (ledvn.EditValue.ToString() == khosua)
                    {
                        txtsctn.Text = phieusua;
                        bat = "0";
                    }
                    else
                    {
                        if (pt == "pck")
                            pck.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                        else if (pt == "pckv")
                            pckv.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                        else if (pt == "pxhgb")
                            pxhgb.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                        else
                            pxhgbvlpg.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                        bat = "1";
                    }
                }
               
            else
            {
                if (pt == "pck")
                {
                    pck.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                    pck.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                }
                else if (pt == "pckv")
                {
                    pckv.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                    pckv.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                }
                else if (pt == "pxhgb")
                {
                    pxhgb.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                    pxhgb.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                }
                else
                {
                    pxhgbvlpg.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), tsbttruoc, tsbtsau);
                    pxhgbvlpg.themsctn(ngaychungtu, txtsctn, ledvn.EditValue.ToString());
                }
            }
            }
            catch
            {}
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txtcth.Text.Replace(".", ""));
            }
            catch { }
        }

        private void tsbtxoa_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt+"px");
            F.getrole(role);
            F.Show();
        }

        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(role);
            F.Show();
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

        private void view_FocusedRowChanged(object sender, EventArgs e)
        {
            view_FocusedRowChanged();
        }


        private void view_FocusedRowChanged()
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
                        if (Double.Parse(hangton.Rows[i][4].ToString()) != 0)
                            textEdit4.Text = String.Format("{0:n2}", Double.Parse(hangton.Rows[i][4].ToString()));
                        else
                            textEdit4.Text = null;
                        return;
                    }
                }
                textEdit1.Text = null;
                textEdit2.Text = null;
                textEdit3.Text = null;
                textEdit4.Text = null;
            }
            catch
            {
                textEdit1.Text = null;
                textEdit2.Text = null;
                textEdit3.Text = null;
                textEdit4.Text = null;
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

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (active == "1" && nhan==1)
            {
                if (checkEdit2.Checked == true)
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn nhận lượng hàng điều này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (pt == "tsbtpncknb")
                            gen.ExcuteNonquery("update INTransfer set PostVersion=1 where RefID='" + role + "'");
                        else if (pt == "tsbtpnhgb")
                            gen.ExcuteNonquery("update INTransferBranch set PostVersion=1 where RefID='" + role + "'");
                        else if(pt=="tsbtpncknbvlpg")
                            gen.ExcuteNonquery("update INTransferSU set PostVersion=1 where RefID='" + role + "'");
                        else if(pt=="tsbtpnhgbvlpg")
                            gen.ExcuteNonquery("update INTransferBranchSU set PostVersion=1 where RefID='" + role + "'");
                    }
                    else
                    {
                        nhan = 0;
                        checkEdit2.Checked = false;
                        nhan = 1;
                    }
                }
                else if (checkEdit2.Checked == false)
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn hủy nhận lượng hàng điều này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (pt == "tsbtpncknb")
                            gen.ExcuteNonquery("update INTransfer set PostVersion=0 where RefID='" + role + "'");
                        else if (pt == "tsbtpnhgb")
                            gen.ExcuteNonquery("update INTransferBranch set PostVersion=0 where RefID='" + role + "'");
                        else if (pt == "tsbtpncknbvlpg")
                            gen.ExcuteNonquery("update INTransferSU set PostVersion=0 where RefID='" + role + "'");
                        else if (pt == "tsbtpnhgbvlpg")
                            gen.ExcuteNonquery("update INTransferBranchSU set PostVersion=0 where RefID='" + role + "'");
                    }
                    else
                    {
                        nhan = 0;
                        checkEdit2.Checked = true;
                        nhan = 1;
                    }
                }
            }
        }

    }
}