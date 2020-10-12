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
using System.IO.Ports;

namespace HAMACO
{
    public partial class Frm_phieunhapkhovat : DevExpress.XtraEditors.XtraForm
    {
        public Frm_phieunhapkhovat()
        {
            InitializeComponent();
        }

        //static SerialPort _serialPort;

        DataTable dt = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
        DataTable hangton = new DataTable();
        hdbanhang hdbh = new hdbanhang();
        phieuxuatkhocothue pxk = new phieuxuatkhocothue();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        int chon = 0;
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup, click, roleid, subsys, load = null, mahangtam, loi, phieu = null, hopdong = null;
        int K = -2;
        Double slhien = 0, slqdhien = 0,congnotam=0;
        public string getloi(string a)
        {
            loi = a;
            return loi;
        }
        public string getphieu(string a)
        {
            phieu = a;
            return phieu;
        }
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
        public int getchon(int a)
        {
            chon = a;
            return chon;
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

        public void refreshpxk()
        {
            congnotam = 0;
            txtck.EditValue = 0;
            pxk.loadpxk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, dongia, thanhtien, txtcth, cbthue, lenv, chiphi, chietkhau, txtck, tsbttruoc, tsbtsau, khach, hang, txttthue, gridControl2, gridView2, txtname, txtdc, txtptgh, chtm, txtdienthoai, txtddh, txttaixe, txtcmnd, txtsdttaixe,txtgn,chvctc,txtvc);
            if (active == "1")
            {
                congnotam = Double.Parse(txttc.EditValue.ToString());
                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        hopdong = sehd.Text;
                        break;
                    }
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (pt == "pxkbarem")
                this.myac();
            else 
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
        }


        private void Frm_phieunhapkhovat_KeyUp(object sender, KeyEventArgs e)
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

        private void Frm_phieunhapkhovat_Load(object sender, EventArgs e)
        {
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole();
            refreshpxk();
            change();
            load = "0";
            radioGroup1.SelectedIndex = -1;
            radioGroup2.SelectedIndex = -1;
            if (phieu != null)
                txtddh.Text = phieu;
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

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                {
                    ledv.Properties.ReadOnly = false;
                }

                txtdienthoai.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;

                cbldt.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                lenv.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                
                cbthue.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                txtngh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptgh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                chvctc.Enabled = true;
                if (active == "1")
                {
                    tsbtnap.Enabled = true;
                }
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                ledt.Focus();
            }
            else
            {
                txtdienthoai.Properties.ReadOnly = true;
                ledv.Properties.ReadOnly = true;
                lenv.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                txtptgh.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                txtngh.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
                chvctc.Enabled = false;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                ledt.Focus();
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

        private void chiphi_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "5";
        }
        private void chietkhau_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "6";
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

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                    pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);

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

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {*/
            if (ledt.EditValue != null)
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtname.Text = khach.Rows[i][2].ToString();
                        txtdc.Text = khach.Rows[i][3].ToString();
                        txtmst.Text = khach.Rows[i][4].ToString();
                        //loadhanmuc(khach.Rows[i][0].ToString());
                        //congnotam = 0;
                        return;
                    }
                }
            else
            {
                sehd.EditValue = null;
                txthn.EditValue = 0;
                txthm.EditValue = 0;
                txtcn.EditValue = 0;
            }
            /*}
            catch { }*/
        }

        private void loadhanmuc(string makhach)
        {
                string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                Double hanmuc = 0, hanno = 0;
                DataTable temp = new DataTable();
                DataTable da = gen.GetTable("select a.ParentContract,DebtLimitMax,LimitDate,a.SignedDate,EffectiveDate from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where (ContractName=N'Bán hàng' or ContractName=N'' or No='2') and AccountingObjectID='" + makhach + "' and SignedDate<='" + ngaychungtu + "'and EffectiveDate>='" + ngaychungtu + "' and DebtLimit>0 and Inactive=1 and StockID in ( select StockID from Stock where BranchID='" + donvi + "') group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
                if (da.Rows.Count > 0 || gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004")
                {
                    temp.Columns.Add("Hợp đồng");
                    temp.Columns.Add("Hạn mức");
                    temp.Columns.Add("Hạn nợ");
                    temp.Columns.Add("Ngày ký");
                    temp.Columns.Add("Ngày hết hạn");
                    for (int j = 0; j < da.Rows.Count; j++)
                    {
                        DataRow dr = temp.NewRow();
                        dr[0] = da.Rows[j][0].ToString();
                        dr[1] = String.Format("{0:n0}", Double.Parse(da.Rows[j][1].ToString()));
                        hanmuc = hanmuc + Double.Parse(da.Rows[j][1].ToString());
                        dr[2] = String.Format("{0:n0}", Double.Parse(da.Rows[j][2].ToString()));
                        hanno = Double.Parse(da.Rows[j][2].ToString());
                        dr[3] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(da.Rows[j][3].ToString()));
                        dr[4] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(da.Rows[j][4].ToString()));
                        temp.Rows.Add(dr);
                    }
                    sehd.Properties.DataSource = temp;
                    sehd.Properties.DisplayMember = "Hợp đồng";
                    sehd.Properties.ValueMember = "Hợp đồng";
                    sehd.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
                    if (temp.Rows.Count > 0)
                        sehd.EditValue = da.Rows[temp.Rows.Count - 1][0].ToString();
                    txthm.EditValue = hanmuc;
                    txthn.EditValue = hanno;
                    /*try
                    {*/
                        txtcn.EditValue = Double.Parse(gen.GetString("bangkecongnohanmuckhachhang '" + donvi + "','" + makhach + "', '" + ngaychungtu + "'"));
                    /*}
                    catch { txtcn.EditValue = 0; }*/
                }
                else if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
                {
                    txthm.EditValue = "1.000.000";
                    txthn.EditValue = "0";
                    txtcn.EditValue = Double.Parse(gen.GetString("bangkecongnohanmuckhachhang '" + donvi + "','" + makhach + "', '" + ngaychungtu + "'"));
                }
                else
                {
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                    string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                    txtcn.EditValue = Double.Parse(gen.GetString("baocaocongnokiemtrakhonghopdong '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'"));
                    txthm.EditValue = Double.Parse(gen.GetString("select COALESCE(Amount,0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));
                    sehd.EditValue = null;
                    txthn.EditValue = 0;
                }
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

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chon == 0)
                    pxk.loadthhdmain(gridView2, gridView1, txtcth, cbthue);
                else chon = 0;
            }
            catch { }
            try
            {
                Double cth, thue, gtgt, tong, ck;
                cth = Double.Parse(txtcth.Text);
                try
                {
                    ck = Double.Parse(txtck.Text);
                }
                catch { ck = 0; }

                try
                {
                    thue = Double.Parse(cbthue.Text);
                    ck = ck / (1 + Double.Parse(cbthue.Text) / 100);
                    gtgt = Math.Round(((cth - ck) / 100) * thue, 0, MidpointRounding.AwayFromZero);
                }
                catch
                {
                    gtgt = 0;
                }
                tong = cth + gtgt - ck;
                txttc.Text = String.Format("{0:n0}", tong);
                txttthue.EditValue = gtgt;
            }
            catch { }
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

            try
            {
                thue = Double.Parse(cbthue.Text);
                ck = ck / (1 + Double.Parse(cbthue.Text) / 100);
                gtgt = Math.Round(((cth - ck) / 100) * thue, 0, MidpointRounding.AwayFromZero);
            }
            catch
            {
                gtgt = 0;
            }
            tong = cth + gtgt - ck;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txtck_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth, thue, gtgt, tong, ck;
                cth = Double.Parse(txtcth.Text);
                ck = Double.Parse(txtck.Text);
                try
                {
                    thue = Double.Parse(cbthue.Text);
                    ck = ck / (1 + thue / 100);
                    gtgt = Math.Round(((cth - ck) / 100) * thue, 0, MidpointRounding.AwayFromZero);
                }
                catch
                {
                    gtgt = 0;
                }

                tong = cth + gtgt - ck;
                txttthue.EditValue = gtgt;
                txttc.Text = String.Format("{0:n0}", tong);
                if (cth == 0)
                    lbtienchu.Text = "";
            }
            catch { }
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
                ck = ck / (1 + Double.Parse(cbthue.Text) / 100);
            }
            catch { ck = 0; }

            gtgt = Double.Parse(txttthue.Text);
            tong = cth + gtgt - ck;

            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", "").Replace("-", ""));
            }
            catch { }
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
            if (pt == "pxk" || pt=="pxkbarem")
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

                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                            {
                                Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                                Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                                if (a != 0)
                                 gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], Math.Round((b / a), 2).ToString());
                            }
                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "")
                            {
                                Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                                Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a), 0).ToString());
                            }
                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ĐG vận chuyển").ToString() != "")
                            {
                                if (chvctc.Checked == false)
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ĐG vận chuyển").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Vận chuyển"], Math.Round((b * a), 0).ToString());
                                }
                                else
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Vận chuyển").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ĐG vận chuyển"], Math.Round((a/b), 2).ToString());
                                }
                            }
                            pxk.loadthhdmain(gridView2, gridView1, txtcth,cbthue);
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
                            pxk.loadthhdmain(gridView2, gridView1, txtcth,cbthue);
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            if (a != 0)
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], Math.Round((b / a), 2).ToString());
                        }
                    }

                }

                else if (e.Column.FieldName == "Thành tiền")
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
                            pxk.loadthhdmain(gridView2, gridView1, txtcth,cbthue);
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            if (a != 0)
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], Math.Round((b / a), 2).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Chiết khấu")
                {
                    if (caseup == "6")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a), 0).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Vận chuyển")
                {
                    if (caseup == "5")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Vận chuyển").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Vận chuyển").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ĐG vận chuyển"], Math.Round((a/b), 2).ToString());
                        }
                    }
                    if (caseup != "10")
                        txtvc.EditValue = Double.Parse(gridView1.Columns["Vận chuyển"].SummaryText);
                }

                else if (e.Column.FieldName == "ĐG vận chuyển")
                {
                    if (caseup == "6")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ĐG vận chuyển").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ĐG vận chuyển").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Vận chuyển"], Math.Round((a * b), 0).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Tiền CK")
                {
                    if (caseup == "5")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tiền CK").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tiền CK").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chiết khấu"], Math.Round((a/b), 2).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Chi phí")
                {
                    if (caseup == "6")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                            pxk.loadthhdmain(gridView2, gridView1, txtcth,cbthue);
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            if (a != 0)                     
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                        }
                    }
                }
            }
        }

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView2.UpdateCurrentRow();
            txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
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
                            gridView2.DeleteRow(gridView1.FocusedRowHandle);
                            gridView1.DeleteRow(gridView1.FocusedRowHandle);
                            txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
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

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            if (txtnv.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập nhân viên bán hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < khach.Rows.Count; i++)
                if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                {
                    loadhanmuc(khach.Rows[i][0].ToString());
                    if (hopdong != sehd.Text)
                    {
                        congnotam = 0;
                    }
                    break;
                }

            if (gen.GetString("select Prefix from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'") != "1")
                if (Double.Parse(gen.GetString("select COALESCE(sum(ExitsMoney),0) from OpenExDate where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and DateEx>30 and AccountingObjectID='" + gen.GetString("select AccountingObjectID  from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "' ") + "'")) > 1000000)
                {
                    XtraMessageBox.Show("Khách hàng có quá hạn trên 30 ngày vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            if (Double.Parse(txtcth.EditValue.ToString()) <= 0)
            {
                XtraMessageBox.Show("Thành tiền chưa đúng vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*if (sehd.Text == "" || (sehd.Text != "" && Double.Parse(txthm.EditValue.ToString())==0))
            {
                if (ledv.EditValue.ToString() != "02")
                {
                    if ((active == "0" && Double.Parse(txtcn.EditValue.ToString()) > 1000000) || (active == "1" && Double.Parse(txtcn.EditValue.ToString()) - Double.Parse(txttc.EditValue.ToString()) > 1000000))
                    {
                        XtraMessageBox.Show("Vui lòng thu tiền khách hàng trước khi bán lô hàng tiếp theo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            
            else if (sehd.Text != "" && Double.Parse(txthm.EditValue.ToString()) < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam)
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/         

            string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            Double hientai = 0;
            Double dangky = 0;

            if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004" || gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
            {
                Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;
 
                Double dinhmuc = 0;
                if (phantram > 0 && phantram < 0.5)
                    dinhmuc = 50000000;
                else if (phantram > 0.5 && phantram < 1)
                    dinhmuc = 150000000;
                else if (phantram == 1)
                    dinhmuc = 300000000;

                if (sehd.Text != "" && (Double.Parse(txthm.EditValue.ToString()) + Double.Parse(txthm.EditValue.ToString()) * phantram < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam || Double.Parse(txthm.EditValue.ToString()) + dinhmuc < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam))
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
                    if (Double.Parse(txthm.EditValue.ToString()) < Double.Parse(txtcn.EditValue.ToString()) - congnotam)
                    {
                        XtraMessageBox.Show("Vui lòng thu tiền trước khi xuất lô hàng tiếp theo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                string manganh = "";
                try
                {
                    manganh = gen.GetString("select ItemSource from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(0, "Mã hàng").ToString() + "'");
                    hientai = Double.Parse(gen.GetString("baocaocongnotheonganhhangchan '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + manganh + "'"));
                }
                catch { }

                hientai = hientai + Double.Parse(txttc.EditValue.ToString()) - congnotam;

                try
                {
                    dangky = Double.Parse(gen.GetString("select COALESCE(Amount,0) from AmountBranchMN where Year='" + nam + "' and MN='" + manganh + "'"));
                }
                catch { }

                if (dangky < hientai)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ hiện tại " + String.Format("{0:n0}", hientai) + " đồng so với mức đăng ký là " + String.Format("{0:n0}", dangky) + " đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;

                Double dinhmuc = 0;
                if (phantram > 0 && phantram < 0.5)
                    dinhmuc = 100000000;
                else if (phantram >= 0.5)
                    dinhmuc = 300000000;

                if ((Double.Parse(txthm.EditValue.ToString()) + Double.Parse(txthm.EditValue.ToString()) * phantram < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam || Double.Parse(txthm.EditValue.ToString()) + dinhmuc < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam))
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                hientai = Double.Parse(gen.GetString("baocaocongnokiemtra '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'"));
                hientai = hientai + Double.Parse(txttc.EditValue.ToString()) - congnotam;
                try
                {
                    dangky = Double.Parse(gen.GetString("select COALESCE(AmountMax,0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));
                }
                catch { }
                if (dangky < hientai)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ hiện tại " + String.Format("{0:n0}", hientai) + " đồng so với mức đăng ký là " + String.Format("{0:n0}", dangky) + " đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            pxk.checkpxk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, cbthue, lenv, tsbttruoc, tsbtsau, txttthue, gridView2, hangton, txtptgh, chtm, txtdienthoai, txtddh, txtck, txttc, txttaixe, txtcmnd, txtsdttaixe, txtgn, chvctc);
            if (loi != "1")
            {
                if (active == "1")
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
                else
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
                active = "1";
                refreshrole();
                click = "true";
                change();
                click = "false";

                congnotam = Double.Parse(txttc.EditValue.ToString());
                hopdong = sehd.Text;
                /*
                string kho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                hangton = gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
                */
                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        break;
                    }                
            }
            else loi = "0";
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            try
            {
                string phieu = gen.GetString("select RefNo from hamaco.dbo.INOutwardLPG where RefID=(select INOutwardRefID from INOutward where RefID='" + role + "')");        
                XtraMessageBox.Show("Phiếu xuất kho này được tạo bởi đơn đặt hàng "+phieu+" vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch { }
            active = "1";
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
            txtdienthoai.Text = "";
            congnotam = 0;
            txtvc.Text = "0";
            chvctc.Checked = false;
            hopdong = null;
            refreshrole();
            cbldt.SelectedIndex = 0;
            ledt.EditValue = null;
            if (gen.GetString("select Top 1 CompanyTaxCode from Center") != "1801115004")
                lenv.EditValue = null;
            txtctg.Text = "";
            txttaixe.Text = "";
            txtcmnd.Text = "";
            txtsdttaixe.Text = "";
            txtptgh.Text = "";
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
            pxk.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            this.Text = "Thêm phiếu xuất kho";
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }

            while (gridView2.RowCount > 0)
            {
                gridView2.DeleteRow(0);
            }
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
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
            gen.ExcuteNonquery("update INOutward set Posted='False' where RefID='" + role + "'");
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
            active = "1";
            refreshrole();
                pxk.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
                refreshpxk();
            change();
        }

        private void tsbtin_ButtonClick(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("pxk");
            F.getrole(role);
            F.getcongty("1");
            F.ShowDialog();
        }

        private void chuyểnHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                hdbh.tsbthdbhchuyen("0", role, roleid, subsys, ngaychungtu, userid, branchid, ledt.EditValue.ToString(), ledv.EditValue.ToString(), khach, hang, lenv.EditValue.ToString(),txtck.Text);
            }
            catch { hdbh.tsbthdbhchuyen("0", role, roleid, subsys, ngaychungtu, userid, branchid, ledt.EditValue.ToString(), ledv.EditValue.ToString(), khach, hang, null, txtck.Text); }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "bienbanvat");
            F.getrole(role);
            F.ShowDialog();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            pxk.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
            refreshpxk();
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            pxk.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
            refreshpxk();
            change();
        }

        private void biênBảnGiaoHàngKiêmXácNhậnNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "bienbanvatxacnhan");
            F.getrole(role);
            F.ShowDialog();
        }

        private void biênBảnGiaoNhậnHàngKèmSốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "bienbanvattrongluong");
            F.getrole(role);
            F.ShowDialog();
        }

        private void biênBảnGiaoNhậnHàngTheoSốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "bienbanvatsoluong");
            F.getrole(role);
            F.ShowDialog();
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


        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            pxk.loadthhdmain(gridView2, gridView1, txtcth,cbthue);
        }

        private void gridView1_FocusedRowChanged(object sender, EventArgs e)
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

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex != -1)
            {
                string kho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                hangton = gen.GetTable("baocaotonkhotheothangthuctetttaidv '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
                gridView1_FocusedRowChanged();
            }            
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            pxk.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
            refreshpxk();
            change();
        }

        private void txtddh_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
            {
                DataTable temp = gen.GetTable("select StockCode,AccountingObjectCode,JournalMemo,DocumentIncluded,ShippingNo,a.RefID from DDHNCC a, Stock b, AccountingObject c where a.AccountingObjectID=c.AccountingObjectID and a.StockID=b.StockID and RefNo='" + txtddh.Text + "'");
                ledv.EditValue = temp.Rows[0][0].ToString();
                txtldn.EditValue = temp.Rows[0][2].ToString();
                txtctg.EditValue = temp.Rows[0][3].ToString();
                txtptvc.EditValue = temp.Rows[0][4].ToString();
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,a.Quantity,a.QuantityConvert,a.UnitPrice,a.Amount from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + temp.Rows[0][5].ToString() + "'");
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

        private void biênBảnGiaoNhậnHàngKhôngGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(role);
            F.getcongty("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            F.ShowDialog();
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }

        private void inPhiếuXuấtKhoTrốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("pxktrong");
            F.getrole(role);
            F.getcongty("1");
            F.ShowDialog();
        }

        private void tsbtxoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < khach.Rows.Count; i++)
                if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                {
                    loadhanmuc(khach.Rows[i][0].ToString());
                    return;
                }
        }

        private void btkiemtra_Click(object sender, EventArgs e)
        {
            if (ledt.EditValue != null)
                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        return;
                    }
        }

        private void chvctc_CheckedChanged(object sender, EventArgs e)
        {
            if (chvctc.Checked == true)
                txtvc.Properties.ReadOnly = false;
            else { txtvc.Properties.ReadOnly = true; }
        }

        private void txtvc_KeyUp(object sender, KeyEventArgs e)
        {
            caseup = "10";
            if (tsbtcat.Enabled == true && txtvc.Text != "" && chvctc.Checked == true && (caseup != "5" || caseup != "6"))
            {
                Double tyle = Double.Parse(txtvc.EditValue.ToString()) / Double.Parse(gridView1.Columns["Số lượng quy đổi"].SummaryText);
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    Double b = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                    gridView1.SetRowCellValue(i, gridView1.Columns["Vận chuyển"], Math.Round((tyle * b), 0, MidpointRounding.AwayFromZero).ToString());
                    gridView1.SetRowCellValue(i, gridView1.Columns["ĐG vận chuyển"], Math.Round((tyle), 2, MidpointRounding.AwayFromZero).ToString());
                }
            }
            caseup = null;
        }
    }
}