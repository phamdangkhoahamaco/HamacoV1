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
using DevExpress.XtraGrid.Views.Grid;

namespace HAMACO
{
    public partial class Frm_RolePermissionMapping : DevExpress.XtraEditors.XtraForm
    {
        String roleid;
        String rolecode;
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string userid = Globals.userid;
        string SQLString = "";
        public Frm_RolePermissionMapping()
        {
            InitializeComponent();
        }

        private void Frm_RolePermissionMapping_Load(object sender, EventArgs e)
        {
            txtRoleCode.Text = gen.GetString2("Roles", "rolecode", "roleid", roleid, clientid);
            //SQLString = "select [rolecode] from [Roles] where roleid='" + a + "' AND ClientID=" + cliendid;
            lblRoleName.Text = gen.GetString2("Roles", "rolename", "roleid", roleid, clientid);

            //load lai datagrid RolePermissionMapping
            Datagrid_update(roleid);

            // Load txtTransactionCode table.
            load_txtTransactionCode(roleid);

            //load combobox permission
            load_permission();
        }

        private void load_permission()
        {
            txtPermission.Items.Add("EDIT");
            txtPermission.Items.Add("DISPLAY");

        }
        private void load_txtTransactionCode(string roleid)  //load search edit table transactions
        {
            string SQLString = "select * from transactions where ClientID=" + clientid;
            SQLString += " AND TransactionCode NOT IN ((select TransactionCode from RolePermissionMapping where RoleID = '" + roleid + "'))";

            try
            {
                dt = gen.GetTable(SQLString);
            }
            catch
            {
                XtraMessageBox.Show(SQLString, "load_txtTransactionCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Text = SQLString;
            }

            txtTransactionCode.Properties.View.Columns.Clear();

            DataTable temp = new DataTable();
            temp.Columns.Add("Transaction Code");
            temp.Columns.Add("Transaction Name");
            temp.Columns.Add("Module");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = dt.Rows[i][1].ToString();
                dr[1] = dt.Rows[i][2].ToString();
                dr[2] = dt.Rows[i][4].ToString();
                temp.Rows.Add(dr);
            }
            txtTransactionCode.Properties.DataSource = temp;
            txtTransactionCode.Properties.DisplayMember = "Transaction Code";
            txtTransactionCode.Properties.ValueMember = "Transaction Code";
            txtTransactionCode.Focus();
        }

        public string getroleid(string a)
        {
            roleid = a;
            return roleid;
        }

        public string getrolecode(string a)
        {

            SQLString = "select [rolecode] from [Roles] where roleid='" + a + "' AND ClientID=" + clientid;
            String rolecode = "";
            try
            {
                rolecode = gen.GetString(SQLString);
            }
            catch
            {
                rolecode = "";
                //txtSQL.Text = SQLString;
            }
            return rolecode;
        }

        public string getrolename(string a)
        {

            SQLString = "select [rolename] from [Roles] where roleid='" + a + "' AND ClientID=" + clientid;
            String rolename = "";
            try
            {
                rolename = gen.GetString(SQLString);
            }
            catch
            {
                rolename = "";
                //txtSQL.Text = SQLString;
            }
            return rolename;
        }


        private void Datagrid_update(string roleid)
        {
            SQLString = "select * from [RolePermissionMapping] where RoleID='" + roleid + "' AND ClientID=" + clientid;
            try
            {
                dt = gen.GetTable(SQLString);
            }
            catch
            {
                XtraMessageBox.Show(SQLString, "Datagrid_update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataTable temp = new DataTable();
            temp.Columns.Add("Transaction Code");
            temp.Columns.Add("Permission");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = dt.Rows[i][1].ToString();
                dr[1] = dt.Rows[i][3].ToString();
                temp.Rows.Add(dr);
            }
            gridControl1.DataSource = temp;
        }

        private void txtTransactionCode_EditValueChanged(object sender, EventArgs e)
        {

            lblTransactionName.Text = gen.GetString2("Transactions", "Transactionname", "TransactionCode", txtTransactionCode.Text, clientid);
        }



        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            // add table RolePermissionMapping
            SQLString = "INSERT INTO RolePermissionMapping ([ClientId],[TransactionCode], [RoleID], [PermissionID]) VALUES (" + clientid;
            SQLString += ",'" + txtTransactionCode.Text + "'";
            SQLString += ",'" + roleid + "','" + txtPermission.Text + "')";
            try
            {
                gen.ExcuteNonquery(SQLString);
                XtraMessageBox.Show("This transaction is added successfully!", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //update lai datagrid
                Datagrid_update(roleid);
            }
            catch
            {
                //XtraMessageBox.Show(SQLString, "btnAddTransaction_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Text = SQLString;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            //
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
    }
