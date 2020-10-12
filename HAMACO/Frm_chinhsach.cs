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
    public partial class Frm_chinhsach : DevExpress.XtraEditors.XtraForm
    {
        public Frm_chinhsach()
        {
            InitializeComponent();
        }
        public delegate void ac();
        public ac myac;
        gencon gen = new gencon();
        string active, userid, role, ngaychungtu;
        chinhsachnhacungcap csncc = new chinhsachnhacungcap();
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
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        private void Frm_chinhsach_Load(object sender, EventArgs e)
        {
            lauser.Text = userid;
            csncc.loadstart(lencc, ngaychungtu, rbthang, rbkg, txtscs,txttsl,txtdsl,txtck);
            if (active == "1")
                csncc.loadchinhsach(role, lencc, lencs, txtscs, detn, dedn, txttsl, txtdsl, txtck, rbthang, rbquy, rbnam, rbkg, rbtan, txtnd, lauser);
        }

        private void baadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (detn.EditValue == null || dedn.EditValue == null)
            {
                XtraMessageBox.Show("Ngày tháng năm bạn không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txttsl.Text == "" || txtdsl.Text == "" || txtck.Text == "")
            {
                XtraMessageBox.Show("Sản lượng hoặc chiết khấu không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            csncc.checkhd(active, role, lencc, lencs, txtscs, detn, dedn, txttsl, txtdsl, txtck, rbthang, rbquy, rbnam, rbkg, rbtan, txtnd, lauser);
            XtraMessageBox.Show("Dữ liệu đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            myac();
            this.Close();
        }

        private void lencc_EditValueChanged(object sender, EventArgs e)
        {
            DataTable da = gen.GetTable("select PolicyCode as 'Chính sách số',PolicyName as 'Nội dung'  from  Policy where (YEAR(BeginDate)='" + DateTime.Parse(ngaychungtu).Year + "' or YEAR(EndDate)='" + DateTime.Parse(ngaychungtu).Year + "') and PolicyCode=PolicyParent and InventoryItemCode='" + lencc.EditValue + "'  order by PolicyCode");
            lencs.Properties.DataSource = da;
            lencs.Properties.DisplayMember = "Chính sách số";
            lencs.Properties.ValueMember = "Chính sách số";
            lencs.Properties.PopupWidth = 300;
            lencs.ItemIndex = -1;
        }

    }
}