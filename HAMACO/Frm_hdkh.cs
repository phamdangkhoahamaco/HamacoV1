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
using System.Data.Entity.Infrastructure;

namespace HAMACO
{
    public partial class Frm_hdkh : DevExpress.XtraEditors.XtraForm
    {
        public Frm_hdkh()
        {
            InitializeComponent();
        }
        Hopdong hd = new Hopdong();
        DataTable khach = new DataTable();
        gencon gen = new gencon();
        public delegate void ac();
        public ac myac;
        string roleid, subsys, ngaychungtu, active, userid, role;
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
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
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
        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        public string getrole(string a)
        {
            role = a;
            return role;
        }

        private void refreshrole()
        {
            // update 2020
            if(active == "1")
            {
                baadd.Enabled = true;
                cblhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                ledv.Properties.ReadOnly = false;
                sekh.Properties.ReadOnly = false;
                txtsdt.Properties.ReadOnly = false;
                txtfax.Properties.ReadOnly = false;
                txtndd.Properties.ReadOnly = false;
                txtcv.Properties.ReadOnly = false;
                txtguq.Properties.ReadOnly = false;
                txtsgpkq.Properties.ReadOnly = false;
                txtnc.Properties.ReadOnly = false;
                txtltd.Properties.ReadOnly = false;
                dentd.Properties.ReadOnly = false;
                txtnh.Properties.ReadOnly = false;
                txtstk.Properties.ReadOnly = false;
                denk.Properties.ReadOnly = false;
                denhh.Properties.ReadOnly = false;
                txthmtd.Properties.ReadOnly = false;
                txthmn.Properties.ReadOnly = false;
                txthn.Properties.ReadOnly = false;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                txtddgh.Properties.ReadOnly = false;
                denl.Properties.ReadOnly = false;
                deng.Properties.ReadOnly = false;
                denqv.Properties.ReadOnly = false;
                txtnl.Properties.ReadOnly = false;
                chetl.Properties.ReadOnly = false;
                dentl.Properties.ReadOnly = false;
                chenqv.Properties.ReadOnly = false;
            }
            try
            {
                DataTable dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
                // can chinh lai sau nay
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "ADD")
                    {
                        baadd.Enabled = true;
                        cblhd.Properties.ReadOnly = false;
                        txtshd.Properties.ReadOnly = false;
                        ledv.Properties.ReadOnly = false;
                        sekh.Properties.ReadOnly = false;
                        txtsdt.Properties.ReadOnly = false;
                        txtfax.Properties.ReadOnly = false;
                        txtndd.Properties.ReadOnly = false;
                        txtcv.Properties.ReadOnly = false;
                        txtguq.Properties.ReadOnly = false;
                        txtsgpkq.Properties.ReadOnly = false;
                        txtnc.Properties.ReadOnly = false;
                        txtltd.Properties.ReadOnly = false;
                        dentd.Properties.ReadOnly = false;
                        txtnh.Properties.ReadOnly = false;
                        txtstk.Properties.ReadOnly = false;
                        denk.Properties.ReadOnly = false;
                        denhh.Properties.ReadOnly = false;
                        txthmtd.Properties.ReadOnly = false;
                        txthmn.Properties.ReadOnly = false;
                        txthn.Properties.ReadOnly = false;
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = true;
                        txtddgh.Properties.ReadOnly = false;
                        denl.Properties.ReadOnly = false;
                        deng.Properties.ReadOnly = false;
                        denqv.Properties.ReadOnly = false;
                        txtnl.Properties.ReadOnly = false;
                        chetl.Properties.ReadOnly = false;
                        dentl.Properties.ReadOnly = false;
                        chenqv.Properties.ReadOnly = false;
                    }
                }
            }
            catch
            { }
            
        }

        private void Frm_hdkh_Load(object sender, EventArgs e)
        {
            refreshrole();
            hd.loadstart(cblhd, ledv, sekh, khach, userid, rbhdnt, rbtm);
            if (active == "1")
                hd.loadhdkh(role, cblhd, txtshd, ledv, sekh, txtsdt, txtfax, txtndd, txtcv, txtguq, txtsgpkq, txtnc, txtltd, dentd, txtnh, txtstk, denk, denhh, txthmn, txthn, rbhdnt, rbhddh, rbtm, rbtc, rbbl, txtddgh, denl, deng, denqv, txtnl, chetl, dentl, chenqv, txthmtd);
            this.Height = 680;
        }

        private void sekh_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                if (sekh.EditValue.ToString() == khach.Rows[i][1].ToString())
                {
                    if (active == "0")
                    {
                        try
                        {
                            DataTable thongtin = gen.GetTable("select top 1 SignerName,Position,License,Proxy,IssuedBy,Change,ChangeDate from contractB where No=0 and AccountingObjectID='" + khach.Rows[i][0].ToString() + "' order by SignedDate DESC");
                            txtndd.EditValue = thongtin.Rows[0][0].ToString();
                            txtcv.EditValue = thongtin.Rows[0][1].ToString();
                            txtguq.EditValue = thongtin.Rows[0][2].ToString();
                            txtsgpkq.EditValue = thongtin.Rows[0][3].ToString();
                            txtnc.EditValue = thongtin.Rows[0][4].ToString();
                            txtltd.EditValue = thongtin.Rows[0][5].ToString();
                            dentd.EditValue = DateTime.Parse(thongtin.Rows[0][6].ToString());
                        }
                        catch { }                       
                    }
                    txttkh.EditValue = khach.Rows[i][2].ToString();
                    return;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            if (keyData == (Keys.Enter))
            {

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void baadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtshd.Focus();
            if (txtshd.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập Số hợp đồng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (sekh.EditValue == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn Khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //else if (denk.EditValue == null || dentd.EditValue == null || denl.EditValue==null || deng.EditValue==null || denqv.EditValue==null || dentl.EditValue==null)
            else if (denk.EditValue.ToString() == "" || dentd.EditValue.ToString() == "" || denl.EditValue.ToString() == "" || deng.EditValue.ToString() == "" 
                || denqv.ToString() == "" || dentl.ToString() == "")
            {
                XtraMessageBox.Show("Ngày tháng năm bạn không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txthmn.EditValue.ToString() == "" || txthn.EditValue.ToString() == "" || txthmtd.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Hạn mức nợ và Hạn nợ không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(active=="0")
                try
                {
                    gen.GetString("select * from ContractB where ContractCode=N'" + txtshd.EditValue + "'");
                    XtraMessageBox.Show("Hợp đồng này đã có trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                catch { }
            //hd.checkhd(active, role, cblhd, txtshd, ledv, sekh, txtsdt, txtfax, txtndd, txtcv, txtguq, txtsgpkq, txtnc, txtltd, dentd, txtnh, txtstk, denk, denhh, txthmn, txthn, rbhdnt, rbhddh, rbtm, rbtc, rbbl, txtddgh, denl, deng, denqv, txtnl, chetl, dentl, chenqv, txthmtd);
            //XtraMessageBox.Show("Dữ liệu đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //update kieu moi                                    
            /*
            ContractB data = new ContractB();// lop ContractB
            if (active == "0")
            {
                data.ContractID = Guid.NewGuid();// tao guiid moi
            }
            else
            {
                data.ContractID = Guid.Parse(role);
            }
           // data.ClientID = Globals.clientid;
            data.CompanyCode = Globals.companycode;
            data.ContractCode = txtshd.EditValue.ToString();
            data.ContractName = cblhd.EditValue.ToString();
            data.SignerName = txtndd.EditValue.ToString();
            data.Position = txtcv.EditValue.ToString();
            data.License = txtguq.EditValue.ToString();
            data.IssuedBy = txtnc.EditValue.ToString();
            data.Change = Int32.Parse(txtltd.EditValue.ToString());
            data.ChangeDate = DateTime.Parse(dentd.EditValue.ToString());
            data.CompanyTel = txtsdt.EditValue.ToString();
            data.CompanyFax = txtfax.EditValue.ToString();
            data.CompanyBankAccount = txtstk.EditValue.ToString();
            data.CompanyBankName = txtnh.EditValue.ToString();
            data.Proxy = txtsgpkq.EditValue.ToString();            
            data.SignedDate = DateTime.Parse(denk.EditValue.ToString());
            data.EffectiveDate = DateTime.Parse(denhh.EditValue.ToString());
            data.DebtLimit = Decimal.Parse(txthmn.EditValue.ToString());
            data.LimitDate = Int32.Parse(txthn.EditValue.ToString());
            int hinhthuc = 1;
            if (rbtc.Checked == true)
                hinhthuc = 2;
            else if (rbbl.Checked == true)
                hinhthuc = 3;
            data.NoPay = hinhthuc;
            int loaihopdong = 1;
            if (rbhddh.Checked == true)
                loaihopdong = 2;
            data.NoContract = loaihopdong;
            data.DeliveryPlace = txtddgh.EditValue.ToString();
            data.Saved = txtnl.EditValue.ToString();
            data.Founded = DateTime.Parse(denl.EditValue.ToString());
            data.Send = DateTime.Parse(deng.EditValue.ToString());
            data.Received = DateTime.Parse(denqv.EditValue.ToString());
            int thanhly = 0;
            if (chetl.Checked == true)
                thanhly = 1;
            data.Closed = thanhly;
            data.ClosedDate = DateTime.Parse(dentl.EditValue.ToString());
            data.ParentContract = txtshd.EditValue.ToString();
            int ngayve = 0;
            if (chenqv.Checked == true)
                ngayve = 1;
            data.Inactive = ngayve;
            data.DebtLimitMax = Decimal.Parse(txthmtd.EditValue.ToString());


            // DebtLimitMax=N'" + txthmtd.EditValue + "' where ContractID='" + role + "'");
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue + "'");
            data.StockID = Guid.Parse(makho);
            string makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + sekh.EditValue + "'");            
            data.AccountingObjectID = Guid.Parse(makhach);
            using (hamacoEntities3 db = new hamacoEntities3())
            {
                try
                {
                    if (active == "0") db.ContractBs.Add(data); //insert
                    else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update
                    db.SaveChanges();
                    XtraMessageBox.Show("Submit successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //catch (DbUpdateException ex) // exception khac
                catch (DbUpdateConcurrencyException ex) // exception khac
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message + active, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtSQL.Text = ex.Message + data + active;
                }

            }






            myac();
            this.Close();
            */
        }

        private void baxem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (active == "1")
                hd.loadhdkh(role, cblhd, txtshd, ledv, sekh, txtsdt, txtfax, txtndd, txtcv, txtguq, txtsgpkq, txtnc, txtltd, dentd, txtnh, txtstk, denk, denhh, txthmn, txthn, rbhdnt, rbhddh, rbtm, rbtc, rbbl, txtddgh, denl, deng, denqv, txtnl, chetl, dentl,chenqv,txthmtd);
        }

        private void txthmn_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
                txthmtd.Text = txthmn.Text;
        }
    }
}