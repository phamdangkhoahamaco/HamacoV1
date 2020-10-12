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
using DevExpress.XtraNavBar; // de tao menu
// tài liệu hd: https://docs.google.com/document/d/1S8h8c42pISc1oWR564a7cL5sGsulZd8caxpg8MfstFA/edit?usp=sharing

namespace HAMACO
{
    public partial class Frm_UserLock : DevExpress.XtraEditors.XtraForm
    {
        String username;
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string userid = Globals.userid;
        string SQLString = "";
        public Frm_UserLock()
        {
            InitializeComponent();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            SQLString = "UPDATE [MSC_User] SET InActive=1 WHERE CompanyCode='" + Globals.companycode + "' AND username='" + username + "'";
            try
            {
                gen.ExcuteNonquery(SQLString);
                XtraMessageBox.Show("This user is locked successfully!", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                XtraMessageBox.Show(SQLString, "btnLock_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string getusername(string a)
        {
            username = a;
            return username;
        }

        private void Frm_UserLock_Load(object sender, EventArgs e)
        {
            lblLock.Text = "";
            string InActive = gen.GetString3("MSC_User", "InActive", "UserName", username, "CompanyCode", Globals.companycode);
            if (InActive == "True")
            {
                lblLock.Text = "This user " + username + " is locked" ;
                btnLock.Visible = false;
                toolTip1.SetToolTip(btnUnlock, "UnLock");
            }
            else
            {
                lblLock.Text = "This user " + username + " is not locked";
                btnUnlock.Visible = false;
                toolTip1.SetToolTip(btnLock, "Lock");
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            SQLString = "UPDATE [MSC_User] SET InActive=0 WHERE CompanyCode='" + Globals.companycode + "' AND username='" + username + "'";
            try
            {
                gen.ExcuteNonquery(SQLString);
                XtraMessageBox.Show("This user is unlocked successfully!", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                XtraMessageBox.Show(SQLString, "btnUnlock_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}