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
    public partial class Frm_plbl : DevExpress.XtraEditors.XtraForm
    {
        public Frm_plbl()
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
            try
            {
                DataTable dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "ADD")
                    {
                        baadd.Enabled = true;
                        lehd.Properties.ReadOnly = false;
                        txtshd.Properties.ReadOnly = false;
                        //ledv.Properties.ReadOnly = false;
                        txttenbl.Properties.ReadOnly = false;
                        txtsdt.Properties.ReadOnly = false;
                        txtfax.Properties.ReadOnly = false;
                        txtndd.Properties.ReadOnly = false;
                        txtcv.Properties.ReadOnly = false;
                        txtguq.Properties.ReadOnly = false;                       
                        txtnc.Properties.ReadOnly = false;
                        denk.Properties.ReadOnly = false;
                        denhh.Properties.ReadOnly = false;
                        txthmn.Properties.ReadOnly = false;
                        txthmtd.Properties.ReadOnly = false;
                        txthn.Properties.ReadOnly = false;
                        groupBox2.Enabled = true;
                        txtndtd.Properties.ReadOnly = false;
                        txtddgh.Properties.ReadOnly = false;
                        denl.Properties.ReadOnly = false;
                        deng.Properties.ReadOnly = false;
                        denqv.Properties.ReadOnly = false;
                        txtnl.Properties.ReadOnly = false;
                        chenqv.Properties.ReadOnly = false;
                    }
                }
            }
            catch
            { }

        }
        private void Frm_plbl_Load(object sender, EventArgs e)
        {
            refreshrole();
            hd.loadstartplbl(lehd, ledv, sekh, khach, userid, rbpl);
            if (active == "1")
                hd.loadplbl(active, role, lehd, txtshd, ledv, sekh, txtsdt, txtfax, txtndd, txtcv, txtguq, txtnc, txtndtd, denk, denhh, txthmn, txthn, rbpl, rbbl, txtddgh, denl, deng, denqv, txtnl, txttenbl, chenqv, txthmtd);
            this.Height = 600;
        }

        private void sekh_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                if (sekh.EditValue.ToString() == khach.Rows[i][1].ToString())
                {
                    txttkh.EditValue = khach.Rows[i][2].ToString();
                    return;
                }
            }
        }

        private void rbpl_CheckedChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = false;
        }

        private void rbbl_CheckedChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = true;
        }

        private void lehd_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = gen.GetTable("select top 1 StockCode,AccountingObjectCode,EffectiveDate,DebtLimit,LimitDate,DeliveryPlace from contractB a, Stock b, AccountingObject c  where a.StockID=b.StockID and a.AccountingObjectID=c.AccountingObjectID and ParentContract=N'" + lehd.EditValue.ToString() + "' order by SignedDate DESC");
            ledv.EditValue = dt.Rows[0][0];
            sekh.EditValue = dt.Rows[0][1];
            denhh.EditValue=dt.Rows[0][2];
            txthmn.EditValue = double.Parse(dt.Rows[0][3].ToString());
            txthn.EditValue = dt.Rows[0][4];
            txtddgh.EditValue = dt.Rows[0][5];
        }

        private void denk_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
                denl.EditValue = deng.EditValue = denqv.EditValue = denk.EditValue;
        }

        private void baadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtshd.Focus();
            if (txtshd.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập Số phụ lục - bảo lãnh.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(lehd.EditValue==null)
            {
                XtraMessageBox.Show("Bạn chưa chọn Hợp đồng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (denk.EditValue == null)
            {
                XtraMessageBox.Show("Bạn chưa nhập Ngày ký.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (active == "0")
                try
                {
                    gen.GetString("select * from ContractB where ContractCode=N'" + txtshd.EditValue + "'");
                    XtraMessageBox.Show("Phụ lục - Bảo lãnh này đã có trong hệ thống.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                catch { }
            hd.checkplbl(active, role, lehd, txtshd, ledv, sekh, txtsdt, txtfax, txtndd, txtcv, txtguq, txtnc, txtndtd, denk, denhh, txthmn, txthn, rbpl, rbbl, txtddgh, denl, deng, denqv, txtnl, txttenbl, chenqv, txthmtd);
            XtraMessageBox.Show("Dữ liệu đã được cập nhật.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            myac();
            this.Close();
        }

        private void baxem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (active == "1")
                hd.loadplbl(active, role, lehd, txtshd, ledv, sekh, txtsdt, txtfax, txtndd, txtcv, txtguq, txtnc, txtndtd, denk, denhh, txthmn, txthn, rbpl, rbbl, txtddgh, denl, deng, denqv, txtnl, txttenbl,chenqv,txthmtd);
        }

        private void txthmn_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
                txthmtd.Text = txthmtd.Text;
        }
    }
}