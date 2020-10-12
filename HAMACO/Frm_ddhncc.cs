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
    public partial class Frm_ddhncc : DevExpress.XtraEditors.XtraForm
    {
        public Frm_ddhncc()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        DataTable hangton = new DataTable();
        gencon gen = new gencon();
        dondathangncc ddh = new dondathangncc();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        int K = -2;
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup, click, roleid, subsys, loi = "0", phieu = null, phuongtien = null, taixe = null, cmnd = null;
        Double tonkhotam = 0;
 
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getphuongtien(string a)
        {
            phuongtien = a;
            return phuongtien;
        }
        public string gettaixe(string a)
        {
            taixe = a;
            return taixe;
        }
        public string getcmnd(string a)
        {
            cmnd = a;
            return cmnd;
        }
        public string getphieu(string a)
        {
            phieu = a;
            return phieu;
        }
        public string getroleid(string a)
        {
            roleid = a;
            return roleid;
        }
        public string getloi(string a)
        {
            loi = a;
            return loi;
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

        public void refreshddh()
        {
            ddh.loadddh(active, role, DAT, ViewDAT, txtsct, ledvdat, denct, denht, mahang, soluong, trongluong, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, txtptvc, tsbttruoc, tsbtsau, khach, hang, dongia, thanhtien, TON, ViewTON, cbthue, txtghichu, txtptgh, txthn, chduyet, radioGroup2, radioGroup3, txtcth, txttthue, lbduyet, txtcmnd);
            if (active == "1")
                tonkhotam = Double.Parse(txtcth.EditValue.ToString());
        }

        private void loadkhach()
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
            ledt.Properties.DataSource = temp;
            ledt.Properties.DisplayMember = "Mã khách";
            ledt.Properties.ValueMember = "Mã khách";
            ledt.Properties.PopupFormWidth = 900;

            lehg.Properties.DataSource = temp;
            lehg.Properties.DisplayMember = "Mã khách";
            lehg.Properties.ValueMember = "Mã khách";
            lehg.Properties.PopupFormWidth = 900;
        }
        /*
        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{DOWN}");
        }
        */
        private void Frm_ddhncc_Load(object sender, EventArgs e)
        {
            loadkhach();
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            refreshrole();
            refreshddh();
            change();
            radioGroup1.SelectedIndex = -1;
            if(phieu!=null)
                loaddonhang();
        }

        private void loaddonhang()
        {
            if (active == "0")
            {
                txtptvc.Text = phuongtien;
                txtptgh.Text = taixe;
                txtcmnd.Text = cmnd;
                DataTable temp =  gen.GetTable("select StockCode,c.AccountingObjectCode,JournalMemo,DocumentIncluded,ShippingNo,a.RefID from DDH a, Stock b, AccountingObject c where a.AccountingObjectID=c.AccountingObjectID and a.InStockID=b.StockID and RefNo='" + phieu + "'");
                
                temp = gen.GetTable("select InventoryItemCode,InventoryItemName,a.QuantityExits,a.QuantityConvertExits from DDHDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + temp.Rows[0][5].ToString() + "'");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    ViewDAT.AddNewRow();
                    ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Mã hàng"], temp.Rows[i][0].ToString());
                    ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Tên hàng"], temp.Rows[i][1].ToString());
                    ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Số lượng đặt"], Double.Parse(temp.Rows[i][2].ToString()));
                    ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Trọng lượng đặt"], Double.Parse(temp.Rows[i][3].ToString()));
                    ViewDAT.UpdateCurrentRow();
                }
            }
        }


        private void Frm_ddhncc_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void ViewDAT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                try
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(ViewDAT.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    ViewDAT.DeleteRow(ViewDAT.FocusedRowHandle);
                    txtcth.Text = String.Format("{0:n0}", Double.Parse(ViewDAT.Columns["Thành tiền"].SummaryText));
                }
                catch { }
            }
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = gridView1.FocusedRowHandle;
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
        }

        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
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
                    ledvdat.Properties.ReadOnly = false;
                }
                denct.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                lehg.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                txtngh.Properties.ReadOnly = false;
                txtptgh.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                txthn.Properties.ReadOnly = false;
                txtcmnd.Properties.ReadOnly = false;
                txtghichu.Properties.ReadOnly = false;
                ViewDAT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

                if (Double.Parse(gen.GetString("select AuthenticationType from MSC_User where UserID='" + userid + "'")) > 0)
                    chduyet.Enabled = true;

                ViewDAT.OptionsBehavior.Editable = true;
                if (chduyet.Checked == true)
                {
                    ViewDAT.Columns["Số lượng đặt"].OptionsColumn.AllowEdit = false;
                    ViewDAT.Columns["Trọng lượng đặt"].OptionsColumn.AllowEdit = false;
                    ViewDAT.Columns["Bó"].OptionsColumn.AllowEdit = false;
                    //ViewDAT.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
                    //ViewDAT.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
                    //ViewDAT.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
                    //ViewDAT.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;                
                }

                tsbtxoa.Enabled = false;
                sehd.Enabled = true;
                tsbtin.Enabled = false;
                radioGroup2.Enabled = true;
                radioGroup3.Enabled = true;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                ledt.Focus();
            }
            else
            {
                chduyet.Enabled = false;
                if (chduyet.Checked == false)
                    tsbtin.Enabled = false;
                ledvdat.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                lehg.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtngh.Properties.ReadOnly = true;
                txtptgh.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                txthn.Properties.ReadOnly = true;
                txtcmnd.Properties.ReadOnly = true;
                txtghichu.Properties.ReadOnly = true;
                sehd.Enabled = false;
                radioGroup2.Enabled = false;
                radioGroup3.Enabled = false;
                ViewDAT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                ViewDAT.OptionsBehavior.Editable = false;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                ledt.Focus();
            }
        }

        private void ViewDAT_FocusedRowChanged(object sender, EventArgs e)
        {
            ViewDAT_FocusedRowChanged();
        }

        private void ViewDAT_FocusedRowChanged()
        {
            /*
            try
            {
                while (ViewTON.RowCount > 0)
                {
                    ViewTON.DeleteRow(0);
                }

                string mahangtam=ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Mã hàng").ToString();
                labeltenhang.Text = "Tên hàng: " + ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Tên hàng").ToString();
                for (int j = 0; j < hangton.Rows.Count; j++)
                {
                    if (mahangtam.Length == 9)
                    {
                        if (mahangtam.Substring(7, 2) == hangton.Rows[j][3].ToString().Substring(7, 2) && mahangtam.Substring(0, 3) == hangton.Rows[j][3].ToString().Substring(0, 3))
                        {
                            if (Double.Parse(hangton.Rows[j][1].ToString()) != 0 || Double.Parse(hangton.Rows[j][2].ToString()) != 0)
                            {
                                ViewTON.AddNewRow();
                                ViewTON.SetRowCellValue(ViewTON.FocusedRowHandle, ViewTON.Columns["Mã hàng"], hangton.Rows[j][3].ToString());
                                ViewTON.SetRowCellValue(ViewTON.FocusedRowHandle, ViewTON.Columns["Tên hàng"], hangton.Rows[j][5].ToString());
                                ViewTON.SetRowCellValue(ViewTON.FocusedRowHandle, ViewTON.Columns["Số lượng"], hangton.Rows[j][1].ToString());
                                ViewTON.SetRowCellValue(ViewTON.FocusedRowHandle, ViewTON.Columns["Trọng lượng"], hangton.Rows[j][2].ToString());
                                ViewTON.UpdateCurrentRow();
                            }
                        }
                    }
                    else if (mahangtam.Length > 9)
                    {
                        if (mahangtam.Substring(0, 9) == hangton.Rows[j][3].ToString().Substring(0, 9))
                        {
                            if (Double.Parse(hangton.Rows[j][1].ToString()) != 0 || Double.Parse(hangton.Rows[j][2].ToString()) != 0)
                            {
                                ViewTON.AddNewRow();
                                ViewTON.SetRowCellValue(ViewTON.FocusedRowHandle, ViewTON.Columns["Mã hàng"], hangton.Rows[j][3].ToString());
                                ViewTON.SetRowCellValue(ViewTON.FocusedRowHandle, ViewTON.Columns["Tên hàng"], hangton.Rows[j][5].ToString());
                                ViewTON.SetRowCellValue(ViewTON.FocusedRowHandle, ViewTON.Columns["Số lượng"], hangton.Rows[j][1].ToString());
                                ViewTON.SetRowCellValue(ViewTON.FocusedRowHandle, ViewTON.Columns["Trọng lượng"], hangton.Rows[j][2].ToString());
                                ViewTON.UpdateCurrentRow();
                            }
                        }
                    
                    }
                }
                
                for (int i = 0; i < hangton.Rows.Count; i++)
                {
                    if (mahangtam == hangton.Rows[i][3].ToString())
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
            */
        }

        private void ledvdat_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                    ddh.themsct(ngaychungtu, txtsct, ledvdat.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);

                string kho = gen.GetString("select * from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                //hangton = gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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
                        loadhanmuc(khach.Rows[i][0].ToString());
                        return;
                    }
                }
            }
            catch { }
        }

        private void loadhanmuc(string makhach)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
            Double hanmuc = 0;
            DataTable temp = new DataTable();
            DataTable da = gen.GetTable("select a.ParentContract,DebtLimit,LimitDate,a.SignedDate,EffectiveDate from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where AccountingObjectID='" + makhach + "' and SignedDate<='" + ngaychungtu + "'and EffectiveDate>='" + ngaychungtu + "' and Inactive=1 group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
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
            try
            {
                txtcn.EditValue = 0 - Double.Parse(gen.GetString("bangkecongnohanmuckhachhang '','" + makhach + "', '" + ngaychungtu + "'"));
            }
            catch { txtcn.EditValue = 0; }
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {  
            /*if(txthn.Text=="")
            {
                XtraMessageBox.Show("Khách hàng có quá hạn trên 30 ngày vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

            /*for (int i = 0; i < khach.Rows.Count; i++)
                if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())                    
                    loadhanmuc(khach.Rows[i][0].ToString());*/
                  
            string kho = gen.GetString("select * from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
            string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            if (ledvdat.EditValue.ToString() != "01" && radioGroup2.SelectedIndex == 2 && lehg.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập mã khách hàng giao thẳng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (ledvdat.EditValue.ToString() != "01" && radioGroup2.SelectedIndex == 2)
            {
                if (gen.GetString("select Prefix from AccountingObject where AccountingObjectCode='" + lehg.EditValue.ToString() + "'") != "1")
                    if (Double.Parse(gen.GetString("select COALESCE(sum(ExitsMoney),0) from OpenExDate where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and DateEx>30 and AccountingObjectID='" + gen.GetString("select AccountingObjectID  from AccountingObject where AccountingObjectCode='" + lehg.EditValue.ToString() + "' ") + "'")) > 1000000)
                    {
                        XtraMessageBox.Show("Khách hàng có quá hạn trên 30 ngày vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                /*if (sehdkhach.Text == "")
                {
                    if ((active == "0" && Double.Parse(txtcnkhach.EditValue.ToString()) > 1000000) || (active == "1" && Double.Parse(txtcnkhach.EditValue.ToString()) - Double.Parse(txttc.EditValue.ToString()) > 1000000))
                    {
                        XtraMessageBox.Show("Vui lòng thu tiền khách hàng trước khi bán lô hàng tiếp theo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (sehdkhach.Text != "" && Double.Parse(txthmkhach.EditValue.ToString()) < Double.Parse(txtcnkhach.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ khách hàng vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/
                /*Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;
                if (Double.Parse(txthmkhach.EditValue.ToString()) + Double.Parse(txthmkhach.EditValue.ToString())*phantram < Double.Parse(txtcnkhach.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/
                Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;
                Double dinhmuc = 0;
                if (phantram > 0 && phantram < 0.5)
                    dinhmuc = 100000000;
                else if (phantram >= 0.5)
                    dinhmuc = 300000000;

                if (Double.Parse(txthmkhach.EditValue.ToString()) + Double.Parse(txthmkhach.EditValue.ToString()) * phantram < Double.Parse(txtcnkhach.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) || Double.Parse(txthmkhach.EditValue.ToString()) + dinhmuc < Double.Parse(txtcnkhach.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt định mức cho phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Double dangky = 0;
            Double hientai = 0;
            if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004" || gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
            {
                string manganh = "";
                try
                {
                    
                    manganh = gen.GetString("select ItemSource from InventoryItem where InventoryItemCode='" + ViewDAT.GetRowCellValue(0, "Mã hàng").ToString() + "'");
                    //hientai = Double.Parse(gen.GetString("baocaotonkhotheothangtheodonvikiemtra '" + donvi + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'"));
                    hientai = Double.Parse(gen.GetString("baocaotonkhotheothangtheonganhkiemtra'" + manganh + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'"));
                }
                catch { }
                try
                {
                    dangky = Double.Parse(gen.GetString("select COALESCE(AmountStock,0) from AmountBranchMN where Year='" + nam + "' and MN='" + manganh + "'"));
                }
                catch { }                
            }
            else
            {
                dangky = Double.Parse(gen.GetString("select COALESCE(sum(AmountStock),0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));
                hientai = Double.Parse(gen.GetString("baocaotonkhotheothangtheodonvikiemtra '" + donvi + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'"));
            }

            hientai = hientai + Double.Parse(gen.GetString("select COALESCE(SUM(TotalAmount),0) from DDHNCC a, Stock b where a.StockID=b.StockID and BranchID='" + donvi + "' and  MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and Posted is NULL and RefType='1'")) - tonkhotam + Double.Parse(txtcth.EditValue.ToString());

            if (dangky < hientai && radioGroup2.SelectedIndex == 1)
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại Tồn kho hiện tại " + String.Format("{0:n0}", hientai) + " đồng so với mức đăng ký là " + String.Format("{0:n0}", dangky) + " đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ddh.checkpxk(active, role, this, ViewDAT, ledt, ledvdat, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, txtptvc, userid, branchid, cbthue, tsbttruoc, tsbtsau, txttthue, txtptgh, radioGroup3, radioGroup2, txtghichu, txthn, chduyet, txtcmnd, lehg, lbduyet.Text);
            if (loi == "0")
            {
                refreshrole();
                click = "true";
                change();
                click = "false";

                if (active == "1")
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
                else
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
                tonkhotam = Double.Parse(txtcth.EditValue.ToString());
                //hangton = gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            }
            else loi = "0";
        }

        private void ViewDAT_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Mã hàng")
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                        labeltenhang.Text = "Tên hàng: " + hang.Rows[i][2].ToString();
                        ViewDAT_FocusedRowChanged();
                        return;
                    }
                }
            }
            ViewDAT.UpdateCurrentRow();

            if (e.Column.FieldName == "Số lượng đặt")
            {
                try
                {
                    ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Số lượng"], ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Số lượng đặt").ToString());
                    Double sl = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Số lượng").ToString());
                    for (int i = 0; i < hang.Rows.Count; i++)
                        if (ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Trọng lượng đặt"], Math.Round(sl * Double.Parse(hang.Rows[i][5].ToString()), 2, MidpointRounding.AwayFromZero).ToString());
                            return;
                        }
                }
                catch { }
            }

            if (e.Column.FieldName == "Trọng lượng đặt")
            {
                ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Trọng lượng"], ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng đặt").ToString());
            }

            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    caseup = "1";
                    Double sl = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Số lượng").ToString());
                    for (int i = 0; i < hang.Rows.Count; i++)
                        if (ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Trọng lượng"], Math.Round(sl * Double.Parse(hang.Rows[i][5].ToString()),2, MidpointRounding.AwayFromZero).ToString());
                            return;
                        }
                }
                catch { }
            }

            if (e.Column.FieldName == "Trọng lượng")
            {
                if (ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Đơn giá").ToString() != "")
                {
                    Double a = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng").ToString());
                    Double b = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Đơn giá").ToString());
                    ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                }
                else if (ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Thành tiền").ToString() != "")
                {
                    Double a = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng").ToString());
                    Double b = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Thành tiền").ToString());
                    ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Đơn giá"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                }
            }

            else if (e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "3")
                {
                    if (ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng").ToString());
                        Double b = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Đơn giá").ToString());
                        ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Thành tiền"], Math.Round((a * b), 0, MidpointRounding.AwayFromZero).ToString());
                    }
                }
            }

            else if (e.Column.FieldName == "Thành tiền")
            {
                if (caseup == "5")
                {
                    if (ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng").ToString() != "" && ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Trọng lượng").ToString());
                        Double b = Double.Parse(ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Thành tiền").ToString());
                        ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Đơn giá"], Math.Round((b / a), 2, MidpointRounding.AwayFromZero).ToString());
                    }
                }
                try
                {
                    txtcth.Text = String.Format("{0:n0}", Double.Parse(ViewDAT.Columns["Thành tiền"].SummaryText));
                }
                catch { }
            }           
            
        }

        private void dongia_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "3";
        }
        private void thanhtien_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "5";
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

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
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
            tonkhotam = 0;
            refreshrole();
            lbduyet.Text = "";
            chduyet.Checked = false;
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
            txtghichu.Text = "";
            txtcmnd.Text = "";
           

            sehd.EditValue = null;
            txthm.Text = "0";
            txthn.Text = "0";
            txtcn.Text = "0";

            denht.EditValue = DateTime.Parse(ngaychungtu);
            denct.EditValue = DateTime.Parse(ngaychungtu);
            txtcth.Text = "0";
            change();
            ddh.themsct(ngaychungtu, txtsct, ledvdat.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            while (ViewDAT.RowCount > 1)
            {
                ViewDAT.DeleteRow(0);
            }
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refreshddh();
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            ddh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvdat.EditValue.ToString());
            refreshddh();
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            ddh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvdat.EditValue.ToString());
            refreshddh();
            change();
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            ddh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledvdat.EditValue.ToString());
            refreshddh();
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            ddh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledvdat.EditValue.ToString());
            refreshddh();
            change();
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {

        }

        private void btchd_Click(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex == 0)
            {
                phieunhapkhothucte pnktt = new phieunhapkhothucte();
                pnktt.tsbtpnkchuyen("0", txtsct.Text, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, "tsbtpnktt");
            }
            else
            {
                hdmhkpn hdmh = new hdmhkpn();
                hdmh.tsbthdbhchuyen("0", txtsct.Text, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            }
        }


        private void btddh_Click(object sender, EventArgs e)
        {
            
        }

        private void btddhmn_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieumn");
            F.getkho("0");
            F.getrole(role);
            F.ShowDialog();
        }

        private void btddhbbgnhhp_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbthddhbienbanhp");
            F.getrole(role);
            F.getkho("0");
            F.ShowDialog();
        }

        private void pnk_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("ddhpnk");
            F.getrole(role);
            F.ShowDialog();
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lehg.Visible = false;
            if (radioGroup2.SelectedIndex == 0)
                btchd.Text = "Chuyển phiếu nhập kho hàng gửi";
            else if (radioGroup2.SelectedIndex == 2)
            {
                cpxk.Enabled = true;
                lehg.Visible = true;
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string temp = ViewDAT.GetRowCellValue(ViewDAT.FocusedRowHandle, "Tên hàng").ToString();
                ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                ViewDAT.Focus();
            }
            catch
            {
                ViewDAT.AddNewRow();
                ViewDAT.SetRowCellValue(ViewDAT.FocusedRowHandle, ViewDAT.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                ViewDAT.Focus();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchLookUpEdit1.Properties.View.Columns.Clear();
            if (radioGroup1.SelectedIndex == 0)
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

        private void bkttth_Click(object sender, EventArgs e)
        {
            string ngaycuoi = DateTime.Parse(DateTime.Parse(denct.EditValue.ToString()).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.getngay(DateTime.Parse(DateTime.Parse(denct.EditValue.ToString()).ToShortDateString()).ToString());
            F.getcongty(ngaycuoi);
            F.gettsbt("bangkehoadondenhan");
            F.getrole(txtsct.Text);
            F.ShowDialog();
        }

        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup3.SelectedIndex == 1)
            { bkttth.Enabled = true; }
        }

        private void cpxk_Click(object sender, EventArgs e)
        {
            phieuxuatkhocothue pxkct = new phieuxuatkhocothue();
            pxkct.tsbtpxkchuyen("0", txtsct.Text, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
        }

        private void lehg_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (lehg.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuckhach(khach.Rows[i][0].ToString());
                        return;
                    }
                }
            }
            catch { }
        }

        private void loadhanmuckhach(string makhach)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
            string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
            Double hanmuc = 0, hanno = 0;
            DataTable temp = new DataTable();
            DataTable da = gen.GetTable("select a.ParentContract,DebtLimitMax,LimitDate,a.SignedDate,EffectiveDate from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where AccountingObjectID='" + makhach + "' and SignedDate<='" + ngaychungtu + "'and EffectiveDate>='" + ngaychungtu + "' and Inactive=1 and StockID in ( select StockID from Stock where BranchID='" + donvi + "') group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
            if (da.Rows.Count > 0 || gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004" || gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
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
                sehdkhach.Properties.DataSource = temp;
                sehdkhach.Properties.DisplayMember = "Hợp đồng";
                sehdkhach.Properties.ValueMember = "Hợp đồng";
                sehdkhach.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
                if (temp.Rows.Count > 0)
                    sehdkhach.EditValue = da.Rows[temp.Rows.Count - 1][0].ToString();
                txthmkhach.EditValue = hanmuc;
                txthnkhach.EditValue = hanno;
                try
                {
                    txtcnkhach.EditValue = Double.Parse(gen.GetString("bangkecongnohanmuckhachhang '" + donvi + "','" + makhach + "', '" + ngaychungtu + "'"));
                }
                catch { txtcnkhach.EditValue = 0; }
            }
            else
            {
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                txtcnkhach.EditValue = Double.Parse(gen.GetString("baocaocongnokiemtrakhonghopdong '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'"));
                txthmkhach.EditValue = Double.Parse(gen.GetString("select COALESCE(Amount,0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));
                sehdkhach.EditValue = null;
                txthnkhach.EditValue = 0;
            }
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }

        private void btmddh_Click(object sender, EventArgs e)
        {
           
        }

        private void btddhmnmtsltl_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieumn");
            F.getkho("0");
            F.getrole(role);
            F.ShowDialog();
        }

        private void btddhmnmtb_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieumn");
            F.getkho("1");
            F.getrole(role);
            F.ShowDialog();
        }

        private void btmddhmtsl_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieu");
            F.getkho("0");
            F.getrole(role);
            F.ShowDialog();
        }

        private void btmddhmttl_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieu");
            F.getkho("1");
            F.getrole(role);
            F.ShowDialog();
        }

        private void btmddhmtb_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieu");
            F.getkho("2");
            F.getrole(role);
            F.ShowDialog();
        }

        private void btddhmnmdt_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieuvina");
            F.getkho("0");
            F.getrole(role);
            F.ShowDialog();
        }

        private void btddhmnmdb_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieuvina");
            F.getkho("1");
            F.getrole(role);
            F.ShowDialog();
        }

        private void mẫuTheoSốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieu");
            F.getkho("0");
            F.getrole(role);
            F.ShowDialog();
        }

        private void mẫuTheoTrọngLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieu");
            F.getkho("1");
            F.getrole(role);
            F.ShowDialog();
        }

        private void mẫuTheoBóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieu");
            F.getkho("2");
            F.getrole(role);
            F.ShowDialog();
        }

        private void mẫuTheoSốLượngTrọngLượngkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieumn");
            F.getkho("0");
            F.getrole(role);
            F.ShowDialog();
        }

        private void mẫuTheoBóToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieumn");
            F.getkho("1");
            F.getrole(role);
            F.ShowDialog();
        }

        private void mẫuĐườngThủyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieuvina");
            F.getkho("0");
            F.getrole(role);
            F.ShowDialog();
        }

        private void mẫuĐườngBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieuvina");
            F.getkho("1");
            F.getrole(role);
            F.ShowDialog();
        }

        private void biênBảnGiaoNhậnHàngHòaPhátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbthddhbienbanhp");
            F.getrole(role);
            F.getkho("0");
            F.ShowDialog();
        }

        private void giấyGiớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("tsbtddhphieuvina");
            F.getkho("2");
            F.getrole(role);
            F.ShowDialog();
        }

    }
}