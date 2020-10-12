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
using System.Data.Entity.Infrastructure;
// tài liệu hd: https://docs.google.com/document/d/1S8h8c42pISc1oWR564a7cL5sGsulZd8caxpg8MfstFA/edit?usp=sharing
namespace HAMACO
{
   
    public partial class Frm_UserCopy : DevExpress.XtraEditors.XtraForm
    {
        String username;
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string userid = Globals.userid;
        string SQLString = "";
        public Frm_UserCopy()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtUsernameFrom.Text == "" || txtUsernameFrom.Text == txtUsernameTo.Text)
            {
                XtraMessageBox.Show("Please enter the Username", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string username2 = gen.GetString3("MSC_User", "UserName", "UserName", txtUsernameTo.Text, "CompanyCode", Globals.companycode);
                if (username2 == "")
                {                                        
                    Frm_user F = new Frm_user();
                    F.getusername(txtUsernameTo.Text);
                    F.getactive("0");
                    F.Show();
                    copyRoles(txtUsernameFrom.Text, txtUsernameTo.Text); // copy role                    
                    copyStock(txtUsernameFrom.Text, txtUsernameTo.Text);
                }
                else
                {
                    // XtraMessageBox.Show("This user is already existed", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    copyRoles(txtUsernameFrom.Text, txtUsernameTo.Text); // copy role va companycode
                    copyStock(txtUsernameFrom.Text, txtUsernameTo.Text);
                    Frm_user F = new Frm_user();
                    F.getusername(txtUsernameTo.Text);
                    F.getactive("1");
                    F.Show();
                }
            }
        }

        private void copyStock(string username1, string username2)
        {
            //copy Stock
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.UserJoinStocks
            .Where(c => c.UserName == username1 && c.CompanyCode == Globals.companycode);
            foreach (var data in query)
            {
                UserJoinStock obj = new UserJoinStock();
                obj.StockCode = data.StockCode;
                obj.UserName = username2;
                obj.CompanyCode = data.CompanyCode;
                ctx.UserJoinStocks.Add(obj); //insert 
            }
            try
            {
                ctx.SaveChanges();
                XtraMessageBox.Show("Copy stocks successfully", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //catch (DbUpdateException ex) // exception khac
            catch (DbUpdateConcurrencyException ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyRoles(string user1, string user2)
        {
            //copy role
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.UserJoinRoles
            .Where(c => c.UserName == user1 && c.CompanyCode == Globals.companycode);
            foreach (var data in query)
            {
                UserJoinRole obj = new UserJoinRole();
                obj.RoleCode = data.RoleCode;
                obj.UserName = user2;
                obj.CompanyCode = data.CompanyCode;
                ctx.UserJoinRoles.Add(obj); //insert  
            }
            try
            {
                ctx.SaveChanges();
                XtraMessageBox.Show("Copy roles successfully", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //catch (DbUpdateException ex) // exception khac
            catch (DbUpdateConcurrencyException ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

        }

        private void Form_UserCopy_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnCopy, "Copy");
            txtUsernameFrom.Text = username;
            txtUsernameFrom.Enabled = false;
            checkBox1.Enabled = false; checkBox2.Enabled = false;
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }
        public string getusername(string a)
        {
            username = a;
            return username;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}