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
    public partial class Frm_Users : DevExpress.XtraEditors.XtraForm
    {

        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string userid = Globals.userid;
        string username = "";
        string SQLString = "";
        public Frm_Users()
        {
            InitializeComponent();
        }

        private void Frm_Users_Load(object sender, EventArgs e)
        {
            txtSQL.Visible = false;
            lblUsername.Text = "";
            lblStatus.Text = "User: " + Globals.username + "; Transaction: SU01";
            // view tooltip
            toolTip1.SetToolTip(btnNew, "Create");
            toolTip1.SetToolTip(btnEdit, "Edit");
            //toolTip1.SetToolTip(btnDisplay, "Display");
            toolTip1.SetToolTip(btnCopy, "Copy");
            toolTip1.SetToolTip(btnLock, "Lock/Unlock");
            toolTip1.SetToolTip(btnChangePW, "Change Password");
            gridControl1.Visible = false;
            //load_txtUser();
        }



        //enter ra ten username
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                //MessageBox.Show("ButtonEdit Validated!");

                lblUsername.Text = gen.GetString2("MSC_User", "FullName", "UserName", txtUser.Text);
                return true;
            }
            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (txtUser.Text == "")
            {
                XtraMessageBox.Show("Please enter the Username", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                username = gen.GetString3("MSC_User", "UserName", "UserName", txtUser.Text, "CompanyCode", Globals.companycode);
                if (username == "")
                {
                    Frm_user F = new Frm_user();
                    F.getusername(txtUser.Text);
                    F.getactive("0"); //  tao moi
                    F.Show();
                }
                else
                {
                    XtraMessageBox.Show("This user " + username + " is already existed", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }

        private void btnEdit_Click(object sender, EventArgs e)

        {

            if (txtUser.Text == "")
            {
                XtraMessageBox.Show("Please enter the Username", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                username = gen.GetString3("MSC_User", "UserName", "UserName", txtUser.Text, "CompanyCode", Globals.companycode);

                if (username != "")
                {
                    Frm_user F = new Frm_user();
                    F.getusername(txtUser.Text);
                    F.getactive("1");
                    F.Show();
                }
                else
                {
                    XtraMessageBox.Show("This user " + username + " is not existed", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
           
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

            if (txtUser.Text == "")
            {
                XtraMessageBox.Show("Please enter the Username", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string username2 = gen.GetString3("MSC_User", "UserName", "UserName", txtUser.Text, "CompanyCode", Globals.companycode);
                if (username2 != "")
                {
                    Frm_UserCopy F = new Frm_UserCopy();
                    F.getusername(txtUser.Text);
                    F.Show();
                }
                else
                {
                      XtraMessageBox.Show("This user is not existed", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                }
            }
           
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                XtraMessageBox.Show("Please enter the Username", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string username2 = gen.GetString3("MSC_User", "UserName", "UserName", txtUser.Text,"CompanyCode",Globals.companycode);
                if (username2 != "")
                {                    
                    Frm_UserLock F = new Frm_UserLock();
                    F.getusername(txtUser.Text);
                    F.Show();
                }
                else
                {
                    XtraMessageBox.Show("This user is not existed", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChangePW_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                XtraMessageBox.Show("Please enter the Username", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string username2 = gen.GetString3("MSC_User", "UserName", "UserName", txtUser.Text, "CompanyCode", Globals.companycode);
                if (username2 != "")
                {                    
                    Frm_UserSetPW F = new Frm_UserSetPW();
                    F.getusername(txtUser.Text);
                    F.Show();
                }
                else
                {
                    XtraMessageBox.Show("This user is not existed", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtUser_EditValueChanged(object sender, EventArgs e)
        {
            lblUsername.Text = gen.GetString2("MSC_User",  "FullName", "UserName", txtUser.Text);
        }

        private void btnContent_Click(object sender, EventArgs e)
        {
            gridControl1.Visible = true;
            SQLString = "select a.UserID,a.UserName,a.FullName, a.Email, a.JobTitle,a.Inactive,b.BranchName from MSC_User a, Branch b ";
            SQLString += " where a.BranchID = b.BranchID and a.CompanyCode = '" + Globals.companycode + "'";
            gridView1.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            gridView1.Columns.Clear();
            try
            {
                temp = gen.GetTable(SQLString);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Text = SQLString;
            }
            txtSQL.Visible = true;
            txtSQL.Text = SQLString;
            dt.Columns.Add("UserID", Type.GetType("System.String"));
            dt.Columns.Add("UserName", Type.GetType("System.String"));
            dt.Columns.Add("Full Name", Type.GetType("System.String"));
            dt.Columns.Add("Email", Type.GetType("System.String"));
            dt.Columns.Add("Job Title", Type.GetType("System.String"));
            dt.Columns.Add("Branch Name", Type.GetType("System.String"));
            dt.Columns.Add("Is Lock", Type.GetType("System.Boolean"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i].Field<Guid>("UserID").ToString();
                dr[1] = temp.Rows[i].Field<string>("UserName").ToString();
                dr[2] = temp.Rows[i].Field<string>("FullName");
                dr[3] = temp.Rows[i].Field<string>("Email");
                dr[4] = temp.Rows[i].Field<string>("JobTitle");
                dr[5] = temp.Rows[i].Field<string>("BranchName");
                dr[6] = temp.Rows[i].Field<bool>("Inactive");
                if (temp.Rows[i].Field<bool>("Inactive") == true)
                    dr[6] = true;
                else
                    dr[6] = false;
                dt.Rows.Add(dr);
            }
           
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.Columns[0].Visible = false;
            gridView1.OptionsView.ShowFooter = true;
           

            gridView1.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }

        private void txtUser_EditValueChanged_1(object sender, EventArgs e)
        {
            lblUsername.Text = gen.GetString2("MSC_User", "FullName", "UserName", txtUser.Text);
        }
    }
}