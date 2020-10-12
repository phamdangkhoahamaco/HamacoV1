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
    public partial class Frm_ddh : DevExpress.XtraEditors.XtraForm
    {
        public Frm_ddh()
        {
            InitializeComponent();
        }
        gencon gen=new gencon();
        DataTable dt = new DataTable();
        dondathang ddh = new dondathang();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        DataTable hangton = new DataTable();
        DataTable hangtoncungungthucte = new DataTable();
        int nhan = 0;
        Double congnotam = 0, trongluongtam = 0, laisuat = 0, tonkhotam = 0;
        int chon = 0;
        DataTable hangtoncungung = new DataTable();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, phieu, caseup, roleid, subsys, click, loi, phieucl, ngaygiadieu, mahangcl, hoadondieu, hopdong=null;
        int key = 0;
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }

        public string gethoadondieu(string a)
        {
            hoadondieu = a;
            return hoadondieu;
        }

        public string getmahang(string a)
        {
            mahangcl = a;
            return mahangcl;
        }
        public string getdategiadieu(string a)
        {
            ngaygiadieu = a;
            return ngaygiadieu;
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
            phieu = a;
            return phieu;
        }

        public string getphieucl(string a)
        {
            phieucl = a;
            return phieucl;
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
        public string getloi(string a)
        {
            loi = a;
            return loi;
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
                if (phieu == "tsbtddh")
                    tsbtadd.Enabled = true;
            }
            else
            {
                tsbtnap.Enabled = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "ADD" && phieu == "tsbtddh")
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

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup2.EditValue.ToString() == "1")
            {
                txtpxk.Visible = false;
                panel1.Visible = false;
                sbok.Visible = false;
                panelControl2.Height = 255;
                xtraTabPage4.PageVisible = false;
                xtraTabPage2.Text = "Chi tiết nhập kho";
                ViewVAT.Columns["ĐG số lượng"].Visible = false;
                ViewVAT.Columns["Đơn giá"].Visible = false;
                ViewVAT.Columns["Thành tiền"].Visible = false;
            }
            else
            {
                txtpxk.Visible = true;
                panel1.Visible = true;
                sbok.Visible = true;
                panelControl2.Height = 331;
                xtraTabPage4.PageVisible = true;
                xtraTabPage2.Text = "Chi tiết có thuế";
                ViewVAT.Columns["Thành tiền"].Visible = true;
                ViewVAT.Columns["Đơn giá"].Visible = true;
                ViewVAT.Columns["ĐG số lượng"].Visible = true;
                /*if (ledt.EditValue != null)
                    for (int i = 0; i < khach.Rows.Count; i++)
                        if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                            loadhanmuc(khach.Rows[i][0].ToString());
                */
                lailo();
            }
        }

        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*try
            {*/
                if (radioGroup3.SelectedIndex == 1)
                {
                    chdxck.Text = "Đã nhận hàng từ nhà máy";
                    if (chdn.Checked == false && tsbtcat.Enabled == true)
                        chdxck.Enabled = true;
                }
                else if (radioGroup3.SelectedIndex == 0)
                {
                    chdxck.Text = "Đã xuất chuyển kho";
                    if (phieu == "tsbtcdh")
                        chdxck.Enabled = false;
                }
            /*}
            catch 
            { 
                chdxck.Checked = false;
                nhan = 0;
                    chdn.Checked = false;
                nhan = 1;
                chdn.Enabled = false;
            }*/
        }

        public void refreshddh()
        {
            nhan = 0;
            congnotam = 0;
            ddh.loadddh(VAT, ViewVAT, NOVAT, ViewNOVAT, CU, ViewCU, ledvdat, ledvnhan, denct, mahang, soluong, trongluong, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dongia, thanhtien, cbthue, lenv, bocxep, vanchuyen, khach, hang, role, txtldn, txtctg, txtsct, txtngh, txtptvc, txtcth, txttthue, txtname, txtdc, txtptgh, 
                radioGroup2, radioGroup3, chdxck, txtgiavon, txtcn, phieu, txtsctchuyen, txtsctnhan, dendh, chdn, txtpxk, tsbttruoc, tsbtsau, this, chhc, chgbct, txtbx, txtvc, chduyet, lbduyet, txtdienthoai, chnhtk, chot, txttaixe, txtcmnd, txtsdttaixe, legd, txtpk,chvctc);
            if (active == "1")
            {
                congnotam = Double.Parse(txttc.EditValue.ToString());
                tonkhotam = Double.Parse(txtgiavon.EditValue.ToString());
                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        hopdong = sehd.Text;
                        break;
                    }
            }
            nhan = 1;
            
            for (int i = 0; i < ViewVAT.RowCount-1; i++)
            {
                Double ton = 0;
                for (int j = 0; j < hangtoncungungthucte.Rows.Count; j++)
                {
                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() == hangtoncungungthucte.Rows[j][0].ToString())
                    {
                        ton = 1;
                        if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0)
                        {
                            Double soluong1 = 0;
                     
                            if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) - soluong1 < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                {
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n2}", Double.Parse(hangtoncungungthucte.Rows[j][6].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }

                        else if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                        {
                            Double trongluong1 = 0;
                            
                            if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) - trongluong1 < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                {
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n2}", Double.Parse(hangtoncungungthucte.Rows[j][7].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }
                        else
                        {
                            if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                            {
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        break;
                    }
                }
                if (ton == 0)
                {
                    if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                    {
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                        XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                }
            }

            trongluongtam = Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText);

        }

        private void Frm_ddh_Load(object sender, EventArgs e)
        {
            laisuat = Double.Parse(gen.GetString("select Top 1 PercentMoney from PercentSyn where Postdate<='" + ngaychungtu + "' order by PostDate DESC"));
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            if (Double.Parse(gen.GetString("select AuthenticationType from MSC_User where UserID='" + userid + "'")) > 1)
                chduyet.Enabled = true;
            refreshrole();
            refreshddh();
            change();
            status();

            if (phieucl != null)
            {
                if (active == "0")
                {
                    ledvdat.EditValue = role;
                    ledvdat.Enabled = false;
                }
                hangtoncungung = gen.GetTable("select * from StockIIGD where PostedDate = (select MAX(PostedDate) from StockIIGD where PostedDate<='" + ngaygiadieu + "') ");
            }
            else { ngaygiadieu = ngaychungtu; }
            //hangtonthucte();
        }

        private void Frm_ddh_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát và làm mới dữ liệu?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    this.myac();
                }
                catch { }
                this.Dispose();
            }
            else if (dr == DialogResult.No)
                this.Dispose();
            else if (dr == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                {
                    ledvnhan.Properties.ReadOnly = false;
                    legd.Properties.ReadOnly = false;
                    ledvdat.Properties.ReadOnly = false;
                }
                if (txtsctchuyen.Text == "")
                {
                    ledvnhan.Properties.ReadOnly = false;
                    legd.Properties.ReadOnly = false;
                }               

                txtdienthoai.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                dendh.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                lenv.Properties.ReadOnly = false;
                txtname.Properties.ReadOnly = false;
                txtdc.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                ViewVAT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                ViewVAT.OptionsBehavior.Editable = true;
                ViewCU.OptionsBehavior.Editable = true;
                ViewNOVAT.OptionsBehavior.Editable = true;
                txtngh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptgh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                chhc.Enabled = true;
                
                if (active == "1")
                {
                    tsbtnap.Enabled = true;
                    if (phieu == "tsbtddhtk" && chdn.Checked == false)
                    {
                        chdxck.Enabled = true;
                        if (chnhtk.Checked == true)
                            radioGroup3.Enabled = true;
                    }
                    else if (phieu == "tsbtcdh")
                    {
                        if (chdn.Checked == false && radioGroup3.SelectedIndex.ToString() == "1")
                        {
                            chdxck.Enabled = true;
                            radioGroup3.Enabled = true;
                        }
                        else if (chdn.Checked == false)
                        {
                            radioGroup3.Enabled = true;
                        }
                    }
                    else if (phieu == "tsbtddh")
                        chvctc.Enabled = true;
                }
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                sehd.Properties.ReadOnly = false;
                ledt.Focus();
            }
            else
            {
                txtdienthoai.Properties.ReadOnly = true;
                ledvnhan.Properties.ReadOnly = true;
                legd.Properties.ReadOnly = true;
                ledvdat.Properties.ReadOnly = true;
                lenv.Properties.ReadOnly = true;
                txtname.Properties.ReadOnly = true;
                txtdc.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                dendh.Properties.ReadOnly = true;
                txtptgh.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                ViewVAT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                ViewVAT.OptionsBehavior.Editable = false;
                ViewCU.OptionsBehavior.Editable = false;
                ViewNOVAT.OptionsBehavior.Editable = false;
                txtngh.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
                sehd.Properties.ReadOnly = true;
                chhc.Enabled = false;
                chvctc.Enabled = false;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                ledt.Focus();
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

        private void loadhanmuc( string makhach)
        {
            lbngd.Visible = false;
            dengd.Visible = false;
            if (radioGroup2.SelectedIndex == 0)
            {
                string makho = gen.GetString("select StockID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
                string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
                Double hanmuc = 0, hanno=0;
                DataTable temp = new DataTable();
                DataTable da = gen.GetTable("select a.ParentContract,DebtLimitMax,LimitDate,a.SignedDate,EffectiveDate,a.ContractName from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate,ContractName from contractB where (ContractName=N'Bán hàng' or ContractName=N'Gửi kho' or ContractName=N'' or No='2') and  AccountingObjectID='" + makhach + "' and SignedDate<='" + ngaychungtu + "'and EffectiveDate>='" + ngaychungtu + "' and Inactive=1 and DebtLimit>0 and StockID in ( select StockID from Stock where BranchID='" + donvi + "') group by ParentContract,ContractName) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
                if (da.Rows.Count > 0)
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
                        if (da.Rows[j][5].ToString() == "Gửi kho")
                        {
                            if (phieu == "tsbtddh")
                            {
                                lbngd.Visible = true;
                                dengd.Visible = true;
                            }
                            hanmuc = hanmuc - Double.Parse(da.Rows[j][1].ToString());
                        }
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

        private void ViewNOVAT_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ViewNOVAT.UpdateCurrentRow();
            if (e.Column.FieldName == "Thành tiền" && caseup == "5")
                txtcth.Text = String.Format("{0:n0}", Double.Parse(ViewNOVAT.Columns["Thành tiền"].SummaryText));
        }

        private void ViewVAT_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Mã hàng")
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        labeltenhang.Text = "Tên hàng: "+ hang.Rows[i][2].ToString();

                        if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString() != "")
                        {
                            Double sl = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString());
                            for (int k = 0; k < hang.Rows.Count; k++)
                                if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[k][1].ToString())
                                {
                                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Trọng lượng"], Math.Round(sl * Double.Parse(hang.Rows[k][5].ToString()), 2, MidpointRounding.AwayFromZero).ToString());
                                    break;
                                }
                        }

                        ddh.loadchuathue(ViewVAT, ViewNOVAT, ViewCU, txtcth, txtgiavon, cbthue,chgbct);
                      
                        for (int j = 0; j < hangtoncungungthucte.Rows.Count; j++)
                        {
                            if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hangtoncungungthucte.Rows[j][0].ToString())
                            {
                                if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0)
                                {
                                    Double soluong = 0;
                                    try {soluong = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString()); }
                                    catch { }
                                    if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) - soluong < 0 && ledvnhan.EditValue.ToString() != null)
                                    {
                                        if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                        {
                                            ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                                            XtraMessageBox.Show(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n0}", Double.Parse(hangtoncungungthucte.Rows[j][6].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "0");
                                }

                                else if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                                {
                                    Double trongluong = 0;
                                    try { trongluong = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString()); }
                                    catch { }
                                    if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) - trongluong < 0 && ledvnhan.EditValue.ToString() != null)
                                    {
                                        if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                        {
                                            ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                                            XtraMessageBox.Show(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n2}", Double.Parse(hangtoncungungthucte.Rows[j][7].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "0");
                                }
                                else
                                {
                                    if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                    {
                                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                                        XtraMessageBox.Show(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString() + " hàng không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                return;
                            }
                        }
                        if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                        {
                            ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                            XtraMessageBox.Show(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString() + " hàng không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        return;
                    }
                }
            }
            ViewVAT.UpdateCurrentRow();
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "1";
                    Double sl = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString());
                    for (int i = 0; i < hang.Rows.Count; i++)
                        if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Trọng lượng"], Math.Round(sl * Double.Parse(hang.Rows[i][5].ToString()),2, MidpointRounding.AwayFromZero).ToString());
                            return;
                        }
                }
                catch { }
            }

            if (e.Column.FieldName == "Trọng lượng")
            {
                if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Đơn giá").ToString() != "")
                {
                    Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                    Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Đơn giá").ToString());
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                }
                else if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString() != "")
                {
                    Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                    Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString());
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Đơn giá"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                }
                
                if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString() != "")
                {
                    Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString());
                    Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString());
                    if (a != 0)
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["ĐG số lượng"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                }
                if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG bốc xếp").ToString() != "")
                {
                    Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG bốc xếp").ToString());
                    Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Bốc xếp"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                }
                if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Phí khác").ToString() != "")
                {
                    Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Phí khác").ToString());
                    Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Chi phí khác"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                }
                if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG vận chuyển").ToString() != "")
                {
                    if (chvctc.Checked == false)
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG vận chuyển").ToString());
                        Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Vận chuyển"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                    else
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Vận chuyển").ToString());
                        Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["ĐG vận chuyển"], Math.Round((a / b), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                }
                ddh.loadchuathue(ViewVAT, ViewNOVAT, ViewCU, txtcth, txtgiavon, cbthue, chgbct);
               
                for (int j = 0; j < hangtoncungungthucte.Rows.Count; j++)
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hangtoncungungthucte.Rows[j][0].ToString())
                    {
                        if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0)
                        {
                            Double soluong = 0;
                            try { soluong = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) - soluong < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                {
                                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n0}", Double.Parse(hangtoncungungthucte.Rows[j][6].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                                ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "0");
                        }

                        else if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                        {
                            Double trongluong = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                            if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) - trongluong < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                {
                                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n2}", Double.Parse(hangtoncungungthucte.Rows[j][7].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                                ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "0");
                        }
                        else
                        {
                            if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                            {
                                ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                                XtraMessageBox.Show(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString() + " hàng không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        return;
                    }
                }
                
                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                {
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString() + " hàng không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            else if (e.Column.FieldName == "ĐG số lượng")
            {
                if (caseup == "3")
                {
                    caseup = "4";
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG số lượng").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG số lượng").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString());
                        if (a != 0)
                            ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Đơn giá"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                }
            }

            else if (e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "3")
                {
                    caseup = "4";
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Đơn giá").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString());
                        if (a != 0)
                            ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["ĐG số lượng"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                }
            }

            else if (e.Column.FieldName == "Thành tiền")
            {
                if (caseup == "5")
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Đơn giá"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Số lượng").ToString());
                        Double b = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Thành tiền").ToString());
                        if (a != 0)
                            ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["ĐG số lượng"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                }
                ddh.loadchuathue(ViewVAT, ViewNOVAT, ViewCU, txtcth, txtgiavon, cbthue, chgbct);
            }

            else if (e.Column.FieldName == "ĐG bốc xếp")
            {
                if (caseup == "6")
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG bốc xếp").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG bốc xếp").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Bốc xếp"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                }
                txtbx.Text = String.Format("{0:n0}", Double.Parse(ViewVAT.Columns["Bốc xếp"].SummaryText));
            }

            else if (e.Column.FieldName == "ĐG vận chuyển")
            {
                if (caseup == "7")
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG vận chuyển").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG vận chuyển").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Vận chuyển"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                }
            }

            else if (e.Column.FieldName == "Vận chuyển")
            {
                if (caseup == "5")
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Vận chuyển").ToString() != "")
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Vận chuyển").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["ĐG vận chuyển"], Math.Round((a/b), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                }
                if (caseup != "10")
                    txtvc.EditValue = Double.Parse(ViewVAT.Columns["Vận chuyển"].SummaryText);
            }

            else if (e.Column.FieldName == "Phí khác")
            {
                if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Phí khác").ToString() != "")
                {
                    Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Phí khác").ToString());
                    Double b = Double.Parse(ViewCU.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Chi phí khác"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                }
                txtpk.Text = String.Format("{0:n0}", Double.Parse(ViewVAT.Columns["Chi phí khác"].SummaryText));
            }
        }

        private void ViewCU_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ViewCU.UpdateCurrentRow();
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "2";
                    Double sl = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Số lượng").ToString());
                    for (int i = 0; i < hang.Rows.Count; i++)
                    {
                        if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Trọng lượng"], Math.Round((sl * Double.Parse(hang.Rows[i][5].ToString())),2, MidpointRounding.AwayFromZero).ToString());
                            for (int j = 0; j < hangtoncungung.Rows.Count; j++)
                            {
                                if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Mã hàng").ToString() == hangtoncungung.Rows[j][2].ToString())
                                {
                                    ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Đơn giá"], hangtoncungung.Rows[j][Int32.Parse(legd.EditValue.ToString()) + 2].ToString());
                                    Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                                    Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Đơn giá").ToString());
                                    ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                                    return;
                                }
                            }
                        }
                    }
                    ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Đơn giá"], "0");
                    return;
                }
                catch { }
            }

            if (e.Column.FieldName == "Trọng lượng")
            {
                if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Đơn giá").ToString() != "")
                {
                    Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                    Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Đơn giá").ToString());
                    ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                }
                else if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Thành tiền").ToString() != "")
                {
                    Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                    Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Thành tiền").ToString());
                    ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Đơn giá"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                }      

                if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "ĐG bốc xếp").ToString() != "")
                {
                    Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "ĐG bốc xếp").ToString());
                    Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                    ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Bốc xếp"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                }

                if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "ĐG vận chuyển").ToString() != "")
                {
                    Double c = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "ĐG vận chuyển").ToString());
                    Double d = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                    ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Vận chuyển"], Math.Round((c * d), 0, MidpointRounding.AwayFromZero).ToString());

                    if (chvctc.Checked == false)
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "ĐG vận chuyển").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Vận chuyển"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                    else
                    {
                        Double a = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Vận chuyển").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["ĐG vận chuyển"], Math.Round((a / b), 2, MidpointRounding.AwayFromZero).ToString());
                    }

                }              

            }

            else if (e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "3")
                {
                    if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Đơn giá").ToString());
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                }
            }

            else if (e.Column.FieldName == "Thành tiền")
            {
                if (caseup == "5")
                {
                    if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Thành tiền").ToString());
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Đơn giá"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                }
                txtgiavon.Text = String.Format("{0:n0}", Double.Parse(ViewCU.Columns["Thành tiền"].SummaryText));
            }


            else if (e.Column.FieldName == "ĐG bốc xếp")
            {
                if (caseup == "6")
                {
                    if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "ĐG bốc xếp").ToString() != "")
                    {
                        Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "ĐG bốc xếp").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Bốc xếp"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                }
            }

            else if (e.Column.FieldName == "ĐG vận chuyển")
            {
                if (caseup == "7")
                {
                    if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "ĐG vận chuyển").ToString() != "")
                    {
                        Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "ĐG vận chuyển").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Vận chuyển"], Math.Round((b * a), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                }
            }

            else if (e.Column.FieldName == "Vận chuyển")
            {
                if (caseup == "5")
                {
                    if (ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Vận chuyển").ToString() != "")
                    {
                        Double a = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Vận chuyển").ToString());
                        Double b = Double.Parse(ViewCU.GetRowCellValue(ViewCU.FocusedRowHandle, "Trọng lượng").ToString());
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["ĐG vận chuyển"], Math.Round((a/b), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                }
            }
        }

        private void ViewVAT_FocusedRowChanged(object sender, EventArgs e)
        {
            ViewVAT_FocusedRowChanged();
        }

        private void dongia_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "3";
        }
        private void thanhtien_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "5";
        }
        private void bocxep_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "6";
        }
        private void vanchuyen_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "7";
        }

        private void ViewVAT_FocusedRowChanged()
        {
            /*try
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {                       
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        labeltenhang.Text = "Tên hàng: " + hang.Rows[i][2].ToString();

                        for (int j = 0; j < hangton.Rows.Count; j++)
                        {
                            if (hang.Rows[i][1].ToString() == hangton.Rows[j][3].ToString())
                            {
                                if (Double.Parse(hangton.Rows[j][1].ToString()) != 0)
                                    textEdit1.EditValue = Double.Parse(hangton.Rows[j][1].ToString());
                                else
                                    textEdit1.Text = null;
                                if (Double.Parse(hangton.Rows[j][2].ToString()) != 0)
                                    textEdit2.Text = String.Format("{0:n2}", Double.Parse(hangton.Rows[j][2].ToString()));
                                else
                                    textEdit2.Text = null;
                                if (Double.Parse(hangton.Rows[j][1].ToString()) != 0 && Double.Parse(hangton.Rows[j][2].ToString()) != 0)
                                    textEdit3.Text = String.Format("{0:n3}", Math.Round(Double.Parse(hangton.Rows[j][2].ToString()) / Double.Parse(hangton.Rows[j][1].ToString()), 3));
                                else
                                    textEdit3.Text = null;
                                return;
                            }
                        }
                        textEdit1.Text = null;
                        textEdit2.Text = null;
                        textEdit3.Text = null;
                        return;
                    }
                }
            }
            catch { }
            */
            /*try
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString() && ledt.Enabled == true)
                    {
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        labeltenhang.Text = "Mặt hàng: " + hang.Rows[i][2].ToString();
                        Double trongluong = 0;
                        if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString() != "")
                            trongluong = Double.Parse(ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Trọng lượng").ToString());
                        for (int j = 0; j < hangtoncung.Rows.Count; j++)
                        {
                            if (hang.Rows[i][1].ToString() == hangtoncung.Rows[j][0].ToString())
                            {
                                if (Double.Parse(hangtoncung.Rows[j][6].ToString()) != 0)
                                    textEdit1.EditValue = Double.Parse(hangtoncung.Rows[j][6].ToString());
                                else
                                    textEdit1.Text = null;
                                if (Double.Parse(hangtoncung.Rows[j][7].ToString()) != 0)
                                    textEdit2.Text = String.Format("{0:n2}", Double.Parse(hangtoncung.Rows[j][7].ToString()));
                                else
                                    textEdit2.Text = null;
                                if (Double.Parse(hangtoncung.Rows[j][6].ToString()) != 0 && Double.Parse(hangtoncung.Rows[j][7].ToString()) != 0)
                                    textEdit3.Text = String.Format("{0:n3}", Math.Round(Double.Parse(hangtoncung.Rows[j][7].ToString()) / Double.Parse(hangtoncung.Rows[j][6].ToString()), 3));
                                else
                                    textEdit3.Text = null;
                                return;
                            }
                        }
                        textEdit1.Text = null;
                        textEdit2.Text = null;
                        textEdit3.Text = null;
                        if (ledvnhan.EditValue.ToString() != null)
                        {
                            if (ledvnhan.EditValue.ToString() != "01")
                                ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "1");
                            XtraMessageBox.Show(labeltenhang.Text + " không có tồn kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                        else
                            ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Âm kho"], "0");
                            return;
                    }
                }
            }
            catch { }*/
            try
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        labeltenhang.Text = "Tên hàng: " + hang.Rows[i][2].ToString();

                        for (int j = 0; j < hangtoncungungthucte.Rows.Count; j++)
                        {
                            if (ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Mã hàng").ToString() == hangtoncungungthucte.Rows[j][0].ToString())
                            {
                                if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                                {
                                    if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0)
                                        textEdit1.EditValue = Double.Parse(hangtoncungungthucte.Rows[j][6].ToString());
                                    else
                                        textEdit1.Text = null;
                                    if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                                        textEdit2.Text = String.Format("{0:n2}", Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()));
                                    else
                                        textEdit2.Text = null;
                                    if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0 && Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                                        textEdit3.Text = String.Format("{0:n3}", Math.Round(Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) / Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()), 3));
                                    else
                                        textEdit3.Text = null;
                                    return;
                                }
                            }
                        }
                    }
                }
                textEdit1.Text = null;
                textEdit2.Text = null;
                textEdit3.Text = null;
            }
            catch { }
        }

   
        private void ViewVAT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true && chdxck.Checked==false && chot.Checked==false)
            {
                try
                {
                    if (XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(ViewVAT.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    ViewNOVAT.DeleteRow(ViewVAT.FocusedRowHandle);
                    ViewCU.DeleteRow(ViewVAT.FocusedRowHandle);
                    ViewVAT.DeleteRow(ViewVAT.FocusedRowHandle);
                    txtgiavon.Text = String.Format("{0:n0}", Double.Parse(ViewCU.Columns["Thành tiền"].SummaryText));
                    txtcth.Text = String.Format("{0:n0}", Double.Parse(ViewNOVAT.Columns["Thành tiền"].SummaryText));
                }
                catch{ }
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
                searchLookUpEdit1.Focus();
            }
            searchLookUpEdit1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }

        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                key = -1;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }

        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                key = ViewVAT.FocusedRowHandle;
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
        }
        private void lenv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
                lenv.EditValue = null;
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                key = -2;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (key == -1)
            {
                ledt.EditValue = searchLookUpEdit1.EditValue;
                ledt.Focus();
            }
            else if (key == -2)
            {
                lenv.EditValue = searchLookUpEdit1.EditValue;
                lenv.Focus();
            }
            else if (key != -1 && key != -2)
            {
                try
                {
                    string temp = ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString();
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                    ViewVAT.Focus();
                }
                catch
                {
                    ViewVAT.AddNewRow();
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                    ViewVAT.Focus();
                }
            }
        }

        private void ledvdat_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
                ddh.themsct(ngaychungtu, txtsct, ledvdat.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            //hangton = ddh.hangton(ledvdat, ngaychungtu);
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, gtgt;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { cth = 0; }
            gtgt = Double.Parse(txttthue.Text);
            txttc.Text = String.Format("{0:n0}", cth + gtgt);
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chon == 0)
                    ddh.loadchuathue(ViewVAT, ViewNOVAT, ViewCU, txtcth, txtgiavon, cbthue, chgbct);
                else chon = 0;
            }
            catch { }
            Double cth, thue, gtgt;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { cth = 0; }
            try
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0, MidpointRounding.AwayFromZero);
            }
            catch { gtgt = 0; }
            txttc.Text = String.Format("{0:n0}", cth + gtgt);
            txttthue.EditValue = gtgt;
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt;
            cth = Double.Parse(txtcth.Text);
            try
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0, MidpointRounding.AwayFromZero);
            }
            catch { gtgt = 0; }
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", cth + gtgt);
            lailo();
        }

        private void status()
        {
            if (phieu == "tsbtddh")
            {
                lbtenddh.Text = "Đơn đặt hàng";
                radioGroup3.Enabled = false;
                chdxck.Enabled = false;

                if (chot.Checked == true)
                {
                    chot.Enabled = false;
                    ledvnhan.Enabled = false;
                }
                else
                    chot.Enabled = true;

                if (chdxck.Checked==true)
                    chgbct.Enabled = false;
                else
                    chgbct.Enabled = true;

                ViewCU.OptionsBehavior.Editable = false;

                if (chdxck.Checked == true && tsbtsua.Enabled == true)
                    chdn.Enabled = true;
                else
                    chdn.Enabled = false;

                dendh.Enabled = true;
                if (radioGroup2.SelectedIndex == 0)
                {
                    btbbgnhtsl.Visible = true;
                    btbbgnh.Visible = true;
                    btbbgnhtl.Visible = true;
                    btbbgnhkxnn.Visible = true;
                }
                if (txtsctchuyen.Text != "")
                {
                    btpnck.Visible = true;
                    if (radioGroup2.SelectedIndex == 0 && chdxck.Checked == true)
                    {
                        btcpxk.Visible = true;
                        btcpxkttt.Visible = true;
                    }
                }
                if (txtpxk.Text != "")
                {
                    btcpxk.Enabled = false;
                    btcpxkttt.Enabled = false;
                    btchd.Visible = true;
                    sbok.Visible = true;
                    chgbct.Enabled = false;
                    dengd.Enabled = false;
                }
                else
                {
                    btcpxk.Enabled = true;
                    btcpxkttt.Enabled = true;
                    btchd.Visible = false;
                    sbok.Visible = false;
                }

                if (chdxck.Checked == true || chot.Checked == true)
                {
                    ViewVAT.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["ĐG số lượng"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    ViewVAT.Columns["Số lượng"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["Trọng lượng"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["ĐG số lượng"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["Đơn giá"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["Thành tiền"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["Mã hàng"].OptionsColumn.AllowEdit = true;
                    if (chduyet.Checked == true)
                        ViewVAT.Columns["Giảm giá"].OptionsColumn.AllowEdit = false;
                    else
                        ViewVAT.Columns["Giảm giá"].OptionsColumn.AllowEdit = true;
                }
            }
            else if (phieu == "tsbtcdh")
            {

                if (chot.Checked == true)
                {
                    chot.Enabled = true;
                    ledvnhan.Enabled = false;
                }
                else
                    chot.Enabled = false;

                lbtenddh.Text = "Chuyển đơn hàng";
                radioGroup2.Enabled = false;
                chnhtk.Enabled = false;
                ViewVAT.OptionsBehavior.Editable = false;
                ViewNOVAT.OptionsBehavior.Editable = false;
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
                if (radioGroup2.SelectedIndex == 0)
                {
                    btbbgnhtsl.Visible = true;
                    btbbgnh.Visible = true;
                    btbbgnhtl.Visible = true;
                    btbbgnhkxnn.Visible = true;
                }
                if (radioGroup3.SelectedIndex == 0)
                {
                    ViewCU.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Bốc xếp"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Vận chuyển"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["ĐG bốc xếp"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["ĐG vận chuyển"].OptionsColumn.AllowEdit = false;
                }
                if (chdn.Checked == true)
                {
                    ViewCU.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;
                }
                /*
                ViewCU.Columns["Số lượng"].OptionsColumn.AllowEdit = true;
                ViewCU.Columns["Trọng lượng"].OptionsColumn.AllowEdit = true;
                ViewCU.Columns["Đơn giá"].OptionsColumn.AllowEdit = true;
                ViewCU.Columns["Thành tiền"].OptionsColumn.AllowEdit = true;
                */
                denct.Enabled = true;
                if (txtsctchuyen.Text != "")
                {
                    btpxck.Visible = true;
                    btpxkkvcnb.Visible = true;
                }
            }
            else if (phieu == "tsbtddhtk")
            {
                lbtenddh.Text = "Đơn đặt hàng tại kho";

                if (chot.Checked == true)
                {
                    chot.Enabled = true;
                    ledvnhan.Enabled = false;
                }
                else
                    chot.Enabled = false;

                radioGroup2.Enabled = false;
                chnhtk.Enabled = false;
                if (chnhtk.Checked == false)
                    radioGroup3.Enabled = false;
                xtraTabPage2.PageVisible = false;
                xtraTabPage4.PageVisible = false;
                
                if (chdn.Checked == true)
                {
                    ViewCU.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
                }
                ViewCU.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
                ViewCU.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;
                denct.Enabled = true;
                if (radioGroup2.SelectedIndex == 0)
                {
                    btbbgnhtsl.Visible = true;
                    btbbgnh.Visible = true;
                    btbbgnhtl.Visible = true;
                    btbbgnhkxnn.Visible = true;
                }
                if (txtsctchuyen.Text != "")
                {
                    btpxck.Visible = true;
                    btpxkkvcnb.Visible = true;
                }
            }

            if (chhc.Checked == true)
                chhc.Enabled = false;
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();

            string ngaychungtu = Globals.ngaychungtu;

            Double dasudung = 0;
            Double luongchia = 0;           

            string kho = gen.GetString("select * from Stock where StockCode='" + ledvnhan.EditValue.ToString() + "'");
            string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            if (radioGroup2.SelectedIndex == 1 && gen.GetString("select Top 1 CompanyTaxCode from Center") == "1800506679")
            {
                Double dangky = Double.Parse(gen.GetString("select COALESCE(sum(AmountStock),0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));

                Double hientai = Double.Parse(gen.GetString("baocaotonkhotheothangtheodonvikiemtra '" + donvi + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'"));
                hientai = hientai + Double.Parse(gen.GetString("select COALESCE(SUM(TotalAmount),0) from DDHNCC a, Stock b where a.StockID=b.StockID and BranchID='" + donvi + "' and  MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and Posted is NULL and RefType='1'")) - tonkhotam + Double.Parse(txtgiavon.EditValue.ToString());

                if (dangky < hientai)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tồn kho hiện tại " + String.Format("{0:n0}", hientai) + " đồng so với mức đăng ký là " + String.Format("{0:n0}", dangky) + " đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (phieucl != null)
            {
                dasudung = Double.Parse(gen.GetString("select TotalTransport from DDHCL where RefNo='" + phieucl + "'"));
                luongchia = Double.Parse(gen.GetString("select TotalAmount from DDHCL where RefNo='" + phieucl + "'"));
                for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString().Substring(0, 3) != mahangcl.Substring(0, 3) || ViewVAT.GetRowCellValue(i, "Mã hàng").ToString().Substring(7, 2) != mahangcl.Substring(7, 2))
                    {
                        XtraMessageBox.Show("Vui lòng đặt đúng loại hàng được chia.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                if (dasudung - trongluongtam + Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText) > luongchia + luongchia * 2 / 100)
                {
                    XtraMessageBox.Show("Trọng lượng vượt quá đơn hàng được chia.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            kiemtrahangam();
            if (ledvnhan.EditValue.ToString() == "13" || ledvnhan.EditValue.ToString() == "16")
                if (phieu == "tsbtddh" && chdxck.Checked == false)
                {
                    for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                    {
                        if (ViewVAT.GetRowCellValue(i, "Âm kho").ToString() == "1")
                        {
                            XtraMessageBox.Show("Có hàng âm trong đơn hàng vui lòng kiểm tra lại hoặc đặt vào kho khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            
            if (radioGroup2.SelectedIndex == 0 && phieu == "tsbtddh")
            {
                if (txtnv.Text == "")
                {
                    XtraMessageBox.Show("Bạn chưa nhập nhân viên bán hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (gen.GetString("select Prefix from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'") != "1")
                    if (Double.Parse(gen.GetString("select COALESCE(sum(ExitsMoney),0) from OpenExDate where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and DateEx>30 and AccountingObjectID='" + gen.GetString("select AccountingObjectID  from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "' ") + "'")) > 1000000)
                    {
                        XtraMessageBox.Show("Khách hàng có quá hạn trên 30 ngày vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                string giaban = txtcth.EditValue.ToString();
                if (txtpxk.Text != "")
                    giaban = txtgxk.EditValue.ToString();

                if ((Double.Parse(txtgiavon.EditValue.ToString()) - Double.Parse(giaban)) / Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText) > Double.Parse(gen.GetString("select Top 1 Dongia from Center")) && phieu == "tsbtddh")
                {
                    XtraMessageBox.Show("Đơn giá bán chưa hợp lý, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Double.Parse(txtcth.EditValue.ToString()) < 0)
                {
                    XtraMessageBox.Show("Thành tiền chưa đúng vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        if (hopdong != sehd.Text)
                            congnotam = 0;
                        break;
                    }               

                if (chdxck.Checked == false)
                {
                    Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;
                    Double dinhmuc = 0;
                    if (phantram > 0 && phantram < 0.5)
                        dinhmuc = 100000000;
                    else if (phantram >= 0.5)
                        dinhmuc = 300000000;

                    if (Double.Parse(txthm.EditValue.ToString()) + Double.Parse(txthm.EditValue.ToString()) * phantram < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam || Double.Parse(txthm.EditValue.ToString()) + dinhmuc < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam)
                    {
                        XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt định mức cho phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                Double hientai = Double.Parse(gen.GetString("baocaocongnokiemtra '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'"));
                hientai = hientai + Double.Parse(txttc.EditValue.ToString()) - congnotam;
                Double dangky = 0;
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

            ddh.checkpxk(active, role, this, ViewVAT, ledt, ledvdat, ledvnhan, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, dendh, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, cbthue, lenv, tsbttruoc, tsbtsau, txttthue, ViewNOVAT, hangton, txtptgh, ViewCU, radioGroup2, radioGroup3, chdxck, txtcth, txtcn, txtgiavon, txtsctchuyen, txtsctnhan, chhc, chgbct, txtbx, txtvc, txtdienthoai, chnhtk, chot, txttaixe, txtcmnd, txtsdttaixe, legd, phieucl, ngaygiadieu, txtpk, chvctc);
            
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
                status();
                click = "false";

                congnotam = Double.Parse(txttc.EditValue.ToString());
                tonkhotam = Double.Parse(txtgiavon.EditValue.ToString());
                hopdong = sehd.Text;

                //hangtoncungung = gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
                /*
                string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
                string denngaydau = DateTime.Parse(DateTime.Parse(tungaydau).ToShortDateString()).AddSeconds(-1).ToString();
                string tungaycuoi = tungaydau;
                string denngaycuoi = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();
                hangtoncungungthucte = gen.GetTable("baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','4'");
                */
                //------------------------------------hangtonthucte();
                //hangton = ddh.hangton(ledvdat, ngaychungtu);
                if (txtpxk.Text != "")
                    gen.ExcuteNonquery("Update a Set a.CustomField1= Round(b.CustomField4/a.QuantityConvert,2), a.CustomField2=b.CustomField4 From (select * from INOutwardDetail where RefID='" + gen.GetString("select RefID from INOutward where RefNo='" + txtpxk.Text + "'") + "') a , ( select * from DDHDetail where RefID='" + role + "') b  where a.InventoryItemID = b.InventoryItemID  and a.Quantity = b.Quantity ");

                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        break;
                    }

                if (phieucl != null)
                {
                    gen.ExcuteNonquery("Update DDHCL set TotalTransport=(select sum(QuantityConvertExits) as trongluong from DDH a, DDHDetail b where a.RefID=b.RefID and RefNoCL='" + phieucl + "') where RefNo='" + phieucl + "'");
                    trongluongtam = Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText);
                }
            }
            else
                loi = "0";
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            hangtonthucte();
            active = "1";
            tsbtcat.Enabled = true;
            tsbtxoa.Enabled = false;
            tsbtin.Enabled = false;
            tsbtnap.Enabled = true;
            tsbtsua.Enabled = false;
            tsbtghiso.Enabled = false;
            change();
            status();
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refreshddh();
            change();
            status();
        }

        private void hangtonthucte()
        {
            string thang = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
            string nam = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();

            string thangtruoc = DateTime.Parse(DateTime.Now.ToString()).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(DateTime.Now.ToString()).AddMonths(-1).Year.ToString();

            string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
            string denngaydau = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).ToShortDateString()).AddSeconds(-1).ToString();

            string tungaycuoi = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).ToShortDateString()).ToString();
            string denngaycuoi = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            string kho = gen.GetString("select * from Stock where StockCode='" + ledvnhan.EditValue.ToString() + "'");
            //hangtoncung = gen.GetTable("baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','4'");
            hangtoncungungthucte = gen.GetTable("baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','" + role + "' ");
        }

        private void ledvnhan_EditValueChanged(object sender, EventArgs e)
        {  /*          
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            string kho = gen.GetString("select * from Stock where StockCode='" + ledvnhan.EditValue.ToString() + "'");         
            */
            //hangtoncungung = gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            /*
            if (txtsctchuyen.Text == "")
            {
                string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
                string denngaydau = DateTime.Parse(DateTime.Parse(tungaydau).ToShortDateString()).AddSeconds(-1).ToString();

                string tungaycuoi = tungaydau;
                string denngaycuoi = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();
       
                hangtoncungungthucte = gen.GetTable("baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','4'");
            }
            */
            try
            {
                if (chon == 0)
                    ddh.loadchuathue(ViewVAT, ViewNOVAT, ViewCU, txtcth, txtgiavon, cbthue, chgbct);
                else
                    chon = 0;
            }
            catch { }
            
            hangtonthucte();

            for (int i = 0; i < ViewVAT.RowCount - 1; i++)
            {
                Double ton = 0;
                for (int j = 0; j < hangtoncungungthucte.Rows.Count; j++)
                {
                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() == hangtoncungungthucte.Rows[j][0].ToString())
                    {
                        ton = 1;

                        if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0)
                        {
                            Double soluong = 0;
                            try { soluong = Double.Parse(ViewVAT.GetRowCellValue(i, "Số lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) - soluong < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                {
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n0}", Double.Parse(hangtoncungungthucte.Rows[j][6].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }

                        else if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                        {
                            Double trongluong1 = 0;
                            try { trongluong1 = Double.Parse(ViewVAT.GetRowCellValue(i, "Trọng lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) - trongluong1 < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                {
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n2}", Double.Parse(hangtoncungungthucte.Rows[j][7].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }
                        else
                        {
                            if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                            {
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        break;
                    }
                }
                if (ton == 0)
                {
                    if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                    {
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                        XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                }
            }

        }

        private void kiemtrahangam()
        {
            hangtonthucte();

            for (int i = 0; i < ViewVAT.RowCount - 1; i++)
            {
                Double ton = 0;
                for (int j = 0; j < hangtoncungungthucte.Rows.Count; j++)
                {
                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() == hangtoncungungthucte.Rows[j][0].ToString())
                    {
                        ton = 1;

                        if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0)
                        {
                            Double soluong = 0;
                            try { soluong = Double.Parse(ViewVAT.GetRowCellValue(i, "Số lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) - soluong < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }

                        else if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                        {
                            Double trongluong1 = 0;
                            try { trongluong1 = Double.Parse(ViewVAT.GetRowCellValue(i, "Trọng lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) - trongluong1 < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }
                        else
                        {
                            if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                            {
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                            }
                        }
                        break;
                    }
                }
                if (ton == 0)
                {
                    if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                    {
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                    }
                    else
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                }
            }
        }

        private void chdn_CheckedChanged(object sender, EventArgs e)
        {

            string kho = gen.GetString("select * from Stock where StockCode='" + ledvnhan.EditValue.ToString() + "'");
            string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            if (radioGroup2.SelectedIndex == 1 && gen.GetString("select Top 1 CompanyTaxCode from Center") == "1800506679")
            {
                Double dangky = Double.Parse(gen.GetString("select COALESCE(sum(AmountStock),0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));

                Double hientai = Double.Parse(gen.GetString("baocaotonkhotheothangtheodonvikiemtra '" + donvi + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'"));
                hientai = hientai + Double.Parse(gen.GetString("select COALESCE(SUM(TotalAmount),0) from DDHNCC a, Stock b where a.StockID=b.StockID and BranchID='" + donvi + "' and  MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and Posted is NULL and RefType='1'")) - tonkhotam + Double.Parse(txtgiavon.EditValue.ToString());

                if (dangky < hientai)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tồn kho hiện tại " + String.Format("{0:n0}", hientai) + " đồng so với mức đăng ký là " + String.Format("{0:n0}", dangky) + " đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (active == "1" && nhan == 1)
            {
                if (chdn.Checked == true)
                {
                    if (XtraMessageBox.Show("Bạn thực sự muốn nhận lượng hàng điều này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        gen.ExcuteNonquery("update DDH set Status='True' where RefID='" + role + "'");
                        gen.ExcuteNonquery("update INTransfer set PostVersion=1 where RefSUID='" + role + "'");
                        gen.ExcuteNonquery("update INTransferBranch set PostVersion=1 where RefSUID='" + role + "'");                    
                    }
                    else
                    {
                        nhan = 0;
                        chdn.Checked = false;
                        nhan = 1;
                    }
                }
                else if (chdn.Checked == false)
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn hủy nhận lượng hàng điều này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        gen.ExcuteNonquery("update DDH set Status='False' where RefID='" + role + "'");
                        gen.ExcuteNonquery("update INTransfer set PostVersion=0 where RefSUID='" + role + "'");
                        gen.ExcuteNonquery("update INTransferBranch set PostVersion=0 where RefSUID='" + role + "'");                       
                    }
                    else
                    {
                        nhan = 0;
                        chdn.Checked = true;
                        nhan = 1;
                    }
                }
            }
        }

        private void btpxkkvcnb_Click(object sender, EventArgs e)
        {
            if (txtsctchuyen.Text == "")
            {
                XtraMessageBox.Show("Đơn hàng này chưa được chuyển kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string pt = null;
            string rolept = null;
            if (txtsctchuyen.Text.Substring(6, 4) == "XHGB")
            {
                pt = "pxhgb";
                rolept = gen.GetString("select RefID from INTransferBranch where RefNo='" + txtsctchuyen.Text + "'");
            }
            else if (txtsctchuyen.Text.Substring(6, 4) == "XKNB")
            {
                pt = "pck";
                rolept = gen.GetString("select RefID from INTransfer where RefNo='" + txtsctchuyen.Text + "'");
            }
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(rolept);
            F.ShowDialog();
        }

        private void btpxck_Click(object sender, EventArgs e)
        {
            if (txtsctchuyen.Text == "")
            {
                XtraMessageBox.Show("Đơn hàng này chưa được chuyển kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string pt = null;
            string rolept = null;
            if (txtsctchuyen.Text.Substring(6, 4) == "XHGB")
            {
                pt = "pxhgbpx";
                rolept = gen.GetString("select RefID from INTransferBranch where RefNo='" + txtsctchuyen.Text + "'");
            }
            else if (txtsctchuyen.Text.Substring(6, 4) == "XKNB")
            {
                pt = "pckpx";
                rolept = gen.GetString("select RefID from INTransfer where RefNo='" + txtsctchuyen.Text + "'");
            }
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(rolept);
            F.ShowDialog();
        }

        private void btpnck_Click(object sender, EventArgs e)
        {
            if (txtsctchuyen.Text == "")
            {
                XtraMessageBox.Show("Đơn hàng này chưa được chuyển kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string pt = null;
            string rolept = null;
            if (txtsctchuyen.Text.Substring(6, 4) == "XHGB")
            {
                pt = "tsbtpnhgb";
                rolept = gen.GetString("select RefID from INTransferBranch where RefNo='" + txtsctchuyen.Text + "'");
            }
            else if (txtsctchuyen.Text.Substring(6, 4) == "XKNB")
            {
                pt = "tsbtpncknb";
                rolept = gen.GetString("select RefID from INTransfer where RefNo='" + txtsctchuyen.Text + "'");
            }
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(rolept);
            F.ShowDialog();
        }

        private void btcpxk_Click(object sender, EventArgs e)
        {
            if (txtpxk.Text == "")
            {
                if (XtraMessageBox.Show("Bạn thực sự muốn chuyển đơn hàng này thành phiếu xuất kho?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ddh.themsctpxk(ngaychungtu, txtpxk, ledvdat.EditValue.ToString(), branchid);
                    string thue = (1 + Double.Parse(cbthue.EditValue.ToString()) / 100).ToString().Replace(",",".");
                    gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID,OriginalRefNo,Taixe,CMND,Dienthoai,CurrencyID) select newid(),NULL,RefDate,RefDate,'" + txtpxk.EditValue.ToString() + "',AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,0,InStockID,0,ShippingNo,Tax,EmployeeID,EmployeeIDSA,0,TotalAmount,TotalAmountOC,'True',ReceiveMethod,RefID,OriginalRefNo,Taixe,CMND,Dienthoai,RefIDInvoice from DDH where RefID='" + role + "'");
                    string phieuxuat = gen.GetString("select RefID from INOutward where RefNo='" + txtpxk.EditValue.ToString() + "'");
                    
                    if (chgbct.Checked == false)
                        gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,DGPhi,PhiKhac) select NEWID(),'" + phieuxuat + "',QuantityExits,QuantityConvertExits,SortOrder,InventoryItemID,0,UnitPrice,case when QuantityConvert<>QuantityConvertExits then  Round((QuantityConvertExits*UnitPriceOC)/" + thue + ",0) else Amount end,0,0,0,0,UnitPriceOC,case when QuantityConvert<>QuantityConvertExits then Round(QuantityConvertExits*UnitPriceOC,0) else AmountOC end,CustomField1,CustomField2,DiscountRate,CustomField3,CustomField4,DGPhi,PhiKhac from DDHDetail where RefID='" + role + "'");
                    else
                        gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,DGPhi,PhiKhac) select NEWID(),'" + phieuxuat + "',QuantityExits,QuantityConvertExits,SortOrder,InventoryItemID,0,UnitPrice,case when QuantityConvert<>QuantityConvertExits then  Round(QuantityConvertExits*UnitPriceOC,0) else Amount end,0,0,0,0,UnitPriceOC,case when QuantityConvert<>QuantityConvertExits then Round(QuantityConvertExits*UnitPriceOC,0) else AmountOC end,CustomField1,CustomField2,DiscountRate,CustomField3,CustomField4,DGPhi,PhiKhac from DDHDetail where RefID='" + role + "'");
                    
                    gen.ExcuteNonquery("update DDH set RefIDInOutward='" + txtpxk.EditValue.ToString() + "' where RefID='" + role + "'");
                    try
                    {
                        gen.GetString("select * from DDHDetail where QuantityConvert<>QuantityConvertExits and RefID='" + role + "'");
                        if (chgbct.Checked == false)
                            gen.ExcuteNonquery("update INOutward set TotalAmount=(select round(SUM(QuantityConvertExits*UnitPriceOC)/" + thue + ",0)  from  DDHDetail where RefID='" + role + "'),TotalAmountOC=(select round(round(SUM(QuantityConvertExits*UnitPriceOC)/" + thue + ",0)/NULLIF(Tax,0),0)  from  DDHDetail where RefID='" + role + "') where RefID='" + phieuxuat + "'");
                        else
                            gen.ExcuteNonquery("update INOutward set TotalAmount=(select round(SUM(QuantityConvertExits*UnitPriceOC),0)  from  DDHDetail where RefID='" + role + "'),TotalAmountOC=(select round(round(SUM(QuantityConvertExits*UnitPriceOC),0)/NULLIF(Tax,0),0)  from  DDHDetail where RefID='" + role + "') where RefID='" + phieuxuat + "'");
                    }
                    catch { }
                    
                    status();
                }
            }
            else
                XtraMessageBox.Show("Đơn hàng đã được chuyển thành phiếu xuất kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            if (phieu == "tsbtddh")
            {
                role = null;
                chvctc.Checked = false;
                hangtonthucte();
                ledvnhan.Enabled = true;
                phieucl = null;
                tonkhotam = 0;
                ngaygiadieu = ngaychungtu;
                chnhtk.Checked = false;
                txtdienthoai.Text = "";
                chduyet.Checked = false;
                chot.Checked = false;
                lbduyet.Text = "";
                txttaixe.Text = "";
                txtcmnd.Text = "";
                txtsdttaixe.Text = "";
                active = "0";
                congnotam = 0;
                hopdong = null;
                refreshrole();
                ledt.EditValue = null;
                txtname.Text = "";
                txtdc.Text = "";
                txtmst.Text = "";
                txtldn.Text = "";
                txtngh.Text = "";
                txtctg.Text = "";
                txtptgh.Text = "";
                txtptvc.Text = "";
                txtctg.Text = "";
                lenv.EditValue = null;
                txtnv.Text = "";
                txtpxk.Text = "";
                sbok.Visible = false;
                txtbx.Text = "0";
                txtvc.Text = "0";
                txtpk.Text = "0";
                sehd.EditValue = null;
                txthm.Text = "0";
                txthn.Text = "0";
                txtcn.Text = "0";

                dendh.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
                hangtoncungung = gen.GetTable("select * from StockIIGD where PostedDate = (select MAX(PostedDate) from StockIIGD where PostedDate<='" + denct.EditValue.ToString() + "') ");
                txtpxk.Text = "";
                txtsctchuyen.Text = "";
                txtsctnhan.Text = "";
                chhc.Checked = false;
                chdn.Checked = false;
                chdxck.Checked = false;

                radioGroup3.SelectedIndex = -1;


                txtcth.Text = "0";
                txtgiavon.Text = "0";
                change();
                status();

                ddh.themsct(ngaychungtu, txtsct, ledvdat.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                this.Text = "Thêm đơn đặt hàng";
                while (ViewVAT.RowCount > 1)
                {
                    ViewVAT.DeleteRow(0);
                }
                while (ViewNOVAT.RowCount > 0)
                {
                    ViewNOVAT.DeleteRow(0);
                }
                while (ViewCU.RowCount > 0)
                {
                    ViewCU.DeleteRow(0);
                }
            }
        }

        private void lailo()
        {
            if (radioGroup2.SelectedIndex == 0)
            {
                Double cth = 0, giavon = 0, bocxep = 0, vanchuyen = 0, phikhac = 0;
                if (txtgxk.Text != "")
                    cth = Double.Parse(txtgxk.EditValue.ToString());
                else if (txtcth.Text != "")
                    cth = Double.Parse(txtcth.EditValue.ToString());
                if (txtgiavon.Text != "")
                    giavon = Double.Parse(txtgiavon.EditValue.ToString());
                if (txtbx.Text != "")
                    bocxep = Double.Parse(txtbx.EditValue.ToString());
                if (txtvc.Text != "")
                    vanchuyen = Double.Parse(txtvc.EditValue.ToString());
                if (txtpk.Text != "")
                    phikhac = Double.Parse(txtpk.EditValue.ToString());
                txtll.Text = String.Format("{0:n0}", cth - giavon - bocxep - vanchuyen - phikhac);
                if (cth - giavon - bocxep - vanchuyen - phikhac < 0)
                {
                    this.txtll.Properties.Appearance.BackColor = System.Drawing.Color.Salmon;
                    this.txtll.Properties.Appearance.BackColor2 = System.Drawing.Color.SeaShell;
                }
                else
                    this.txtll.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            }
            else
                txtll.Text = "0";
        }


        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            phieucl = null;
            refreshrole();
            ddh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvdat.EditValue.ToString());
            refreshddh();
            change();
            status();
        }

        private void btbbgnhtsl_Click(object sender, EventArgs e)
        {
            if (txtpxk.Text == "" && radioGroup2.SelectedIndex==0)
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvatsoluongddh");
                F.getrole(role);
                F.ShowDialog();
            }
            else
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvatsoluong");
                F.getrole(gen.GetString("select RefID from InOutward where RefNo='" + txtpxk.Text + "'"));
                F.ShowDialog();
            }
        }

        private void btbbgnh_Click(object sender, EventArgs e)
        {
            if (txtpxk.Text == "" && radioGroup2.SelectedIndex == 0)
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvatddh");
                F.getrole(role);
                F.ShowDialog();
            }
            else
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvat");
                F.getrole(gen.GetString("select RefID from InOutward where RefNo='" + txtpxk.Text + "'"));
                F.ShowDialog();
            }
        }

        private void btbbgnhtl_Click(object sender, EventArgs e)
        {
            if (txtpxk.Text == "" && radioGroup2.SelectedIndex == 0)
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvattrongluongddh");
                F.getrole(role);
                F.ShowDialog();
            }
            else
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvattrongluong");
                F.getrole(gen.GetString("select RefID from InOutward where RefNo='" + txtpxk.Text + "'"));
                F.ShowDialog();
            }
        }

        private void btbbgnhkxnn_Click(object sender, EventArgs e)
        {
            if (txtpxk.Text == "" && radioGroup2.SelectedIndex == 0)
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvatxacnhanddh");
                F.getrole(role);
                F.ShowDialog();
            }
            else
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvatxacnhan");
                F.getrole(gen.GetString("select RefID from InOutward where RefNo='" + txtpxk.Text + "'"));
                F.ShowDialog();
            }
        }

        private void btchd_Click(object sender, EventArgs e)
        {
            hdbanhang hdbh = new hdbanhang();
            hdbh.tsbthdbhchuyen("0", gen.GetString("select RefID from InOutward where RefNo='" + txtpxk.Text + "'"), roleid, subsys, ngaychungtu, userid, branchid, ledt.EditValue.ToString(), ledvdat.EditValue.ToString(), khach, hang,lenv.EditValue.ToString(),"0");
        }

        private void btddh_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("dondathangthongtin");
            F.getrole(role);
            F.ShowDialog();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            phieucl = null;
            refreshrole();
            ddh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvdat.EditValue.ToString());
            refreshddh();
            change();
            status();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            phieucl = null;
            refreshrole();
            ddh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvdat.EditValue.ToString());
            refreshddh();
            change();
            status();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            phieucl = null;
            refreshrole();
            ddh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvdat.EditValue.ToString());
            refreshddh();
            change();
            status();
        }

        private void sbok_Click(object sender, EventArgs e)
        {
            ddh.tsbtpxk(txtpxk.Text, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
        }

        private void tsbtin_ButtonClick(object sender, EventArgs e)
        {

        }

        private void pxk_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("pxkddh");
            F.getrole(role);
            if (chdxck.Checked == false)
                F.getcongty("1");
            F.ShowDialog();
        }

        private void VAT_Click(object sender, EventArgs e)
        {
            ViewVAT_FocusedRowChanged();
        }

        private void chgbct_CheckedChanged(object sender, EventArgs e)
        {
            if (chgbct.Checked == true)
                ViewVAT.Columns["ĐG số lượng"].Visible = false;
            else
                ViewVAT.Columns["ĐG số lượng"].Visible = true;
            try
            {
                if (chon == 0)
                    ddh.loadchuathue(ViewVAT, ViewNOVAT, ViewCU, txtcth, txtgiavon, cbthue, chgbct);
                else chon = 0;
            }
            catch { }
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {

        }

        private void txtgiavon_EditValueChanged(object sender, EventArgs e)
        {
            lailo();
            tinhlaisuat();
        }

        private void txtvc_EditValueChanged(object sender, EventArgs e)
        {
            lailo();
        }

        private void txtbx_EditValueChanged(object sender, EventArgs e)
        {
            lailo();
        }

        private void ldd_Click(object sender, EventArgs e)
        {
            if (txtsctchuyen.Text == "")
            {
                XtraMessageBox.Show("Đơn hàng này chưa được chuyển kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string pt = null;
            string rolept = null;
            if (txtsctchuyen.Text.Substring(6, 4) == "XHGB")
            {
                pt = "lddgb";
                rolept = gen.GetString("select RefID from INTransferBranch where RefNo='" + txtsctchuyen.Text + "'");
            }
            else if (txtsctchuyen.Text.Substring(6, 4) == "XKNB")
            {
                pt = "lddnb";
                rolept = gen.GetString("select RefID from INTransfer where RefNo='" + txtsctchuyen.Text + "'");
            }
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(rolept);
            F.ShowDialog();
        }

        private void txtpxk_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtpxk.Text != "")
                    txtgxk.EditValue = Double.Parse(gen.GetString("select TotalAmount from INOutward where RefNo='" + txtpxk.Text + "'"));
                else txtgxk.Text = "";
            }
            catch {}
        }

        private void cpnvc_Click(object sender, EventArgs e)
        {
            phieunhaphangthua pnht = new phieunhaphangthua();
            pnht.tsbtpnhtchuyen("0", txtsct.Text,roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
        }

        private void sehd_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtgxk_EditValueChanged(object sender, EventArgs e)
        {
            lailo();
        }

        private void chduyet_CheckedChanged(object sender, EventArgs e)
        {
            if (chduyet.Checked == true && lbduyet.Text == "")
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có thực sự muốn duyệt giảm giá đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lbduyet.Text = gen.GetString("select FullName from MSC_User where UserID='" + userid + "'");
                    chduyet.Enabled = false;
                    gen.ExcuteNonquery("update DDH set UserCheck=N'" + lbduyet.Text + "' where RefID='" + role + "'");
                }
                else
                    chduyet.Checked = false;
        }

        private void lbduyet_Click(object sender, EventArgs e)
        {

        }

        private void btcpxkttt_Click(object sender, EventArgs e)
        {
            if (txtpxk.Text == "")
            {
                if (XtraMessageBox.Show("Bạn thực sự muốn chuyển đơn hàng này thành phiếu xuất kho?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ddh.themsctpxk(ngaychungtu, txtpxk, ledvdat.EditValue.ToString(), branchid);
                    string thue = (1 + Double.Parse(cbthue.EditValue.ToString()) / 100).ToString().Replace(",",".");
                    gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID,OriginalRefNo,Taixe,CMND,Dienthoai,CurrencyID) select newid(),NULL,RefDate,RefDate,'" + txtpxk.EditValue.ToString() + "',AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,0,InStockID,0,ShippingNo,Tax,EmployeeID,EmployeeIDSA,0,TotalAmount,TotalAmountOC,'True',ReceiveMethod,RefID,OriginalRefNo,Taixe,CMND,Dienthoai,RefIDInvoice from DDH where RefID='" + role + "'");
                    string phieuxuat = gen.GetString("select RefID from INOutward where RefNo='" + txtpxk.EditValue.ToString() + "'");
                    
                    if (chgbct.Checked == false)
                        gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,DGPhi,PhiKhac) select NEWID(),'" + phieuxuat + "',QuantityExits,QuantityConvertExits,SortOrder,InventoryItemID,0,Round(Amount/QuantityConvertExits,2),Amount,0,0,0,0,Round(AmountOC/QuantityConvertExits,2),AmountOC,CustomField1,CustomField2,DiscountRate,CustomField3,CustomField4,DGPhi,PhiKhac from DDHDetail where RefID='" + role + "'");
                    else
                        gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,DGPhi,PhiKhac) select NEWID(),'" + phieuxuat + "',QuantityExits,QuantityConvertExits,SortOrder,InventoryItemID,0,Round(Amount/QuantityConvertExits,2),Amount,0,0,0,0,Round(AmountOC/QuantityConvertExits,2),AmountOC,CustomField1,CustomField2,DiscountRate,CustomField3,CustomField4,DGPhi,PhiKhac from DDHDetail where RefID='" + role + "'");
                    
                    gen.ExcuteNonquery("update DDH set RefIDInOutward='" + txtpxk.EditValue.ToString() + "' where RefID='" + role + "'");
                        try
                        {
                            gen.GetString("select * from DDHDetail where QuantityConvert<>QuantityConvertExits and RefID='" + role + "'");
                            if (chgbct.Checked == false)
                                gen.ExcuteNonquery("update INOutward set TotalAmount=(select round(SUM(case when QuantityConvertExits=0 then 0 else AmountOC end)/" + thue + ",0)  from  DDHDetail where RefID='" + role + "'),TotalAmountOC=(select round(round(SUM(case when QuantityConvertExits=0 then 0 else AmountOC end)/" + thue + ",0)/NULLIF(Tax,0),0)  from  DDHDetail where RefID='" + role + "') where RefID='" + phieuxuat + "'");
                            else
                                gen.ExcuteNonquery("update INOutward set TotalAmount=(select round(SUM(case when QuantityConvertExits=0 then 0 else AmountOC end),0)  from  DDHDetail where RefID='" + role + "'),TotalAmountOC=(select round(round(SUM(case when QuantityConvertExits=0 then 0 else AmountOC end),0)/NULLIF(Tax,0),0)  from  DDHDetail where RefID='" + role + "') where RefID='" + phieuxuat + "'");
                        }
                        catch { }
                    
                    status();
                }
            }
            else
                XtraMessageBox.Show("Đơn hàng đã được chuyển thành phiếu xuất kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
        }

        private void chnhtk_CheckedChanged(object sender, EventArgs e)
        {
            if (chnhtk.Checked == true)
            {
                radioGroup3.Properties.Items.RemoveAt(1);
                radioGroup3.Properties.Items.RemoveAt(0);
                this.radioGroup3.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
                new DevExpress.XtraEditors.Controls.RadioGroupItem(0D, "Từ công ty"),
                new DevExpress.XtraEditors.Controls.RadioGroupItem(1D, "Từ nhà máy",false)});
            }
            else
            {
                radioGroup3.Properties.Items.RemoveAt(1);
                radioGroup3.Properties.Items.RemoveAt(0);
                this.radioGroup3.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
                new DevExpress.XtraEditors.Controls.RadioGroupItem(0D, "Từ công ty"),
                new DevExpress.XtraEditors.Controls.RadioGroupItem(1D, "Từ nhà máy")});
            }
        }

        private void chdxck_CheckedChanged(object sender, EventArgs e)
        {
            if (chdxck.Checked == true && radioGroup3.SelectedIndex == -1)
                radioGroup3.SelectedIndex = 0;
        }

        private void cpnktt_Click(object sender, EventArgs e)
        {
            phieunhapkhothucte pnktt = new phieunhapkhothucte();
            pnktt.tsbtpnkchuyen("0", txtsct.Text, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, "tsbtpnktt");
        }

        private void dendh_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(dendh.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(dendh.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                dendh.EditValue = ngaychungtu;
        }

        private void cdlsddhncc_Click(object sender, EventArgs e)
        {
            dondathangncc ddhncc = new dondathangncc();
            ddhncc.tsbtddhnccchuyen("0", txtsct.Text, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, txtptvc.Text, txttaixe.Text, txtcmnd.Text);
        }

        private void legd_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ViewCU.RowCount; i++)
            {
                Double ton = 0;
                for (int j = 0; j < hangtoncungung.Rows.Count; j++)
                {
                    if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString() == hangtoncungung.Rows[j][2].ToString())
                    {
                        ton = 1;
                        ViewCU.SetRowCellValue(i, ViewCU.Columns["Đơn giá"], hangtoncungung.Rows[j][Int32.Parse(legd.EditValue.ToString()) + 2].ToString());
                        if (ViewCU.GetRowCellValue(i, "Trọng lượng").ToString() != "")
                        {
                            Double a = Double.Parse(ViewCU.GetRowCellValue(i, "Trọng lượng").ToString());
                            Double b = Double.Parse(ViewCU.GetRowCellValue(i, "Đơn giá").ToString());
                            ViewCU.SetRowCellValue(i, ViewCU.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                        }
                        break;
                    }
                }
                if (ton == 0)
                {
                    ViewCU.SetRowCellValue(i, ViewCU.Columns["Đơn giá"], "0");
                    ViewCU.SetRowCellValue(i, ViewCU.Columns["Thành tiền"], "0");
                }
            }
            try
            {
                ViewCU.UpdateSummary();
                txtgiavon.Text = String.Format("{0:n0}", Double.Parse(ViewCU.Columns["Thành tiền"].SummaryText));
            }
            catch { }
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (phieucl == null)
            {
                hangtoncungung = gen.GetTable("select * from StockIIGD where PostedDate = (select MAX(PostedDate) from StockIIGD where PostedDate<='" + denct.EditValue.ToString() + "') ");
            }
            
            for (int i = 0; i < ViewCU.RowCount; i++)
            {
                Double ton = 0;
                for (int j = 0; j < hangtoncungung.Rows.Count; j++)
                {
                    if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString() == hangtoncungung.Rows[j][2].ToString())
                    {
                        ton = 1;
                        ViewCU.SetRowCellValue(i, ViewCU.Columns["Đơn giá"], hangtoncungung.Rows[j][Int32.Parse(legd.EditValue.ToString()) + 2].ToString());
                        if (ViewCU.GetRowCellValue(i, "Trọng lượng").ToString() != "")
                        {
                            Double a = Double.Parse(ViewCU.GetRowCellValue(i, "Trọng lượng").ToString());
                            Double b = Double.Parse(ViewCU.GetRowCellValue(i, "Đơn giá").ToString());
                            ViewCU.SetRowCellValue(i, ViewCU.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                        }
                        break;
                    }
                }
                if (ton == 0)
                {
                    ViewCU.SetRowCellValue(i, ViewCU.Columns["Đơn giá"], "0");
                    ViewCU.SetRowCellValue(i, ViewCU.Columns["Thành tiền"], "0");
                }
            }
            try
            {
                ViewCU.UpdateSummary();
                txtgiavon.Text = String.Format("{0:n0}", Double.Parse(ViewCU.Columns["Thành tiền"].SummaryText));
            }
            catch { }
        }

        private void lbgd_Click(object sender, EventArgs e)
        {
            if (chdn.Checked == true)
            {
                XtraMessageBox.Show("Đơn hàng đã được nhận không thể thay đổi giá điều.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (phieu == "tsbtcdh" && chdn.Checked == false)
            {
                Frm_chonhoadon u = new Frm_chonhoadon();
                u.myac = new Frm_chonhoadon.ac(getgiadieu);
                u.getdate(ngaychungtu);
                u.getbranch(gen.GetString("select StockID from Stock where StockCode='" + ledvnhan.EditValue.ToString() + "'").ToUpper());
                u.gettsbt("ddh");
                u.getformddh(this);
                u.ShowDialog();
            }
        }

        private void getgiadieu()
        {
            DataTable dongiacungung = gen.GetTable("select InventoryItemCode,Round(a.Amount/a.QuantityConvert,2) from PUInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + hoadondieu + "'");
            for (int i = 0; i < ViewCU.RowCount; i++)
            {
                for (int j = 0; j < dongiacungung.Rows.Count; j++)
                {
                    if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString() == dongiacungung.Rows[j][0].ToString())
                    {
                        ViewCU.SetRowCellValue(i, ViewCU.Columns["Đơn giá"], dongiacungung.Rows[j][1].ToString());
                        if (ViewCU.GetRowCellValue(i, "Trọng lượng").ToString() != "")
                        {
                            Double a = Double.Parse(ViewCU.GetRowCellValue(i, "Trọng lượng").ToString());
                            Double b = Double.Parse(ViewCU.GetRowCellValue(i, "Đơn giá").ToString());
                            ViewCU.SetRowCellValue(i, ViewCU.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                        }
                        break;
                    }
                }
            }
            ViewCU.UpdateSummary();
            txtgiavon.Text = String.Format("{0:n0}", Double.Parse(ViewCU.Columns["Thành tiền"].SummaryText));
        }

        private void tinhlaisuat()
        {
            Double vks = 30, taydo = 7, vas = 7, pomina = 45, miennam = 40, hoaphat = 30, tonglai = 0, hanno = 0;
            if(txthn.Text!="")
                hanno=Double.Parse(txthn.Text);
            for (int i = 0; i < ViewCU.RowCount; i++)
            {
                if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString().Substring(0,3) == "724")
                {
                    if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString().Substring(7, 2) == "01")
                        tonglai = tonglai + Double.Parse(ViewCU.GetRowCellValue(i, "Thành tiền").ToString()) * (hoaphat - hanno) * laisuat / 36000;
                    else if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString().Substring(7, 2) == "04")
                        tonglai = tonglai + Double.Parse(ViewCU.GetRowCellValue(i, "Thành tiền").ToString()) * (miennam - hanno) * laisuat / 36000;
                    else if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString().Substring(7, 2) == "05")
                        tonglai = tonglai + Double.Parse(ViewCU.GetRowCellValue(i, "Thành tiền").ToString()) * (vks - hanno) * laisuat / 36000;
                    else if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString().Substring(7, 2) == "08")
                        tonglai = tonglai + Double.Parse(ViewCU.GetRowCellValue(i, "Thành tiền").ToString()) * (taydo - hanno) * laisuat / 36000;
                    else if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString().Substring(7, 2) == "11")
                        tonglai = tonglai + Double.Parse(ViewCU.GetRowCellValue(i, "Thành tiền").ToString()) * (pomina - hanno) * laisuat / 36000;
                    else if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString().Substring(7, 2) == "84")
                        tonglai = tonglai + Double.Parse(ViewCU.GetRowCellValue(i, "Thành tiền").ToString()) * (vas - hanno) * laisuat / 36000;
                }
            }
            txtlai.EditValue = String.Format("{0:n0}", tonglai);
        }

        private void dengd_EditValueChanged(object sender, EventArgs e)
        {
            if (dengd.EditValue != null)
            {
                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();

                if (DateTime.Parse(dengd.EditValue.ToString()) < DateTime.Parse(thang + "/25/" + nam))
                {
                    XtraMessageBox.Show("Bạn không thể chỉnh giá trước ngày 25, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                    dengd.EditValue = null;
                    return;
                }

                if (phieucl == null)
                {
                    hangtoncungung = gen.GetTable("select * from StockIIGD where PostedDate = (select MAX(PostedDate) from StockIIGD where PostedDate<='" + dengd.EditValue.ToString() + "') ");
                }

                for (int i = 0; i < ViewCU.RowCount; i++)
                {
                    Double ton = 0;
                    for (int j = 0; j < hangtoncungung.Rows.Count; j++)
                    {
                        if (ViewCU.GetRowCellValue(i, "Mã hàng").ToString() == hangtoncungung.Rows[j][2].ToString())
                        {
                            ton = 1;
                            ViewCU.SetRowCellValue(i, ViewCU.Columns["Đơn giá"], hangtoncungung.Rows[j][Int32.Parse(legd.EditValue.ToString()) + 2].ToString());
                            if (ViewCU.GetRowCellValue(i, "Trọng lượng").ToString() != "")
                            {
                                Double a = Double.Parse(ViewCU.GetRowCellValue(i, "Trọng lượng").ToString());
                                Double b = Double.Parse(ViewCU.GetRowCellValue(i, "Đơn giá").ToString());
                                ViewCU.SetRowCellValue(i, ViewCU.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                            }
                            break;
                        }
                    }
                    if (ton == 0)
                    {
                        ViewCU.SetRowCellValue(i, ViewCU.Columns["Đơn giá"], "0");
                        ViewCU.SetRowCellValue(i, ViewCU.Columns["Thành tiền"], "0");
                    }
                }
                try
                {
                    ViewCU.UpdateSummary();
                    txtgiavon.Text = String.Format("{0:n0}", Double.Parse(ViewCU.Columns["Thành tiền"].SummaryText));
                }
                catch { }
            }
        }

        private void txtpk_EditValueChanged(object sender, EventArgs e)
        {
            lailo();
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
            {
                txtvc.Properties.ReadOnly = false;
                /*Double tyle = Double.Parse(txtvc.EditValue.ToString()) / Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText);
                for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                {
                    Double b = Double.Parse(ViewCU.GetRowCellValue(i, "Trọng lượng").ToString());
                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Vận chuyển"], Math.Round((tyle * b), 0, MidpointRounding.AwayFromZero).ToString());
                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["ĐG vận chuyển"], Math.Round((tyle), 2, MidpointRounding.AwayFromZero).ToString());
                }*/
            }
            else { txtvc.Properties.ReadOnly = true; }
        }

        private void txtvc_KeyUp(object sender, KeyEventArgs e)
        {
            caseup = "10";
            if (tsbtcat.Enabled == true && txtvc.Text != "" && chvctc.Checked == true && (caseup != "5" || caseup != "7"))
            {
                Double tyle = Double.Parse(txtvc.EditValue.ToString()) / Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText);
                for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                {
                    Double b = Double.Parse(ViewCU.GetRowCellValue(i, "Trọng lượng").ToString());
                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Vận chuyển"], Math.Round((tyle * b), 0, MidpointRounding.AwayFromZero).ToString());
                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["ĐG vận chuyển"], Math.Round((tyle), 2, MidpointRounding.AwayFromZero).ToString());
                }
            }
            caseup = null;
        }    
    }
}