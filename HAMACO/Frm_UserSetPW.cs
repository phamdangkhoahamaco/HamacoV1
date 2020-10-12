using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources; // import bo thu vien cua HAMACO
// tài liệu hd: https://docs.google.com/document/d/1S8h8c42pISc1oWR564a7cL5sGsulZd8caxpg8MfstFA/edit?usp=sharing

namespace HAMACO
{
    public partial class Frm_UserSetPW : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string userid = Globals.userid;
        string username = "";
        string SQLString = "";
        public Frm_UserSetPW()
        {
            InitializeComponent();
        }

        private void Frm_UserSetPW_Load(object sender, EventArgs e)
        {
            txtten.Text = username;
        }

        public string getusername(string a)
        {
            username = a;
            return username;
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            if (txtmk.Text != txtmk2.Text || txtmk.Text == "")
            {
                XtraMessageBox.Show("Mật khẩu mới chưa khớp hoặc bạn chưa nhập mật khẩu mới.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmk2.Text = "";
                txtmk.Text = "";
                txtmk.Focus();
            }
            else
            {
                SQLString = "update MSC_User set Password='" + gen.EncodeMD5(txtmk.Text) + "' where Username='" + username + "' AND CompanyCode='" + Globals.companycode + "'";
                try
                {
                    gen.ExcuteNonquery(SQLString);
                    XtraMessageBox.Show("Mật khẩu của bạn đã được thay đổi.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmk2.Text = "";
                    txtmk.Text = "";
                    txtmk.Text = "";
                    txtmk2.Focus();                    
                }
                catch
                {
                    XtraMessageBox.Show(SQLString, "btlogin_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmk2.Text = "";
                    txtmk2.Focus();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtmk2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtten_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtmk_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}