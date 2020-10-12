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
using System.Data.OleDb; // import
using HAMACO.Resources; // import bo thu vien cua HAMACO

namespace HAMACO
{
    public partial class Frm_TableView : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string username = Globals.username;
        string SQLString = "";
        public Frm_TableView()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            if (keyData == (Keys.Enter))
            {
                //lblRoleName.Text = gen.GetString2("Roles", "RoleName", "RoleCode", txtRoleCode.Text, clientid);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Frm_TableView_Load(object sender, EventArgs e)
        {
            txtSQL.Visible = false;
            lblSum.Text = "";

            lblStatus.Text = "Client: " + Globals.clientid + "; User: " + Globals.username + "; Transaction: SE11";
            // kiem tra permission                       
            if (gen.checkPermission(Globals.username, "SE11", Globals.companycode) == false)
            {
                XtraMessageBox.Show("You do not the permission to execute this transaction code", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            lvpq.Visible = false;

            toolTip1.SetToolTip(btnDisplay, "Display");
            toolTip1.SetToolTip(btnContent, "Content");

            // Load table co trong DB.
            load_tablename();

            //load datagrid of tables in the DB
            load_datagrid();
        }

        private void load_datagrid()
        {
            lvpq.Visible = true;
            SQLString = "SELECT count(*) FROM information_schema.tables";
            lblSum.Text = gen.GetString(SQLString);

            lblSum.Text = "There are " + lblSum.Text + " tables and views in the database.";

            SQLString = "SELECT * FROM information_schema.tables";
            try
            {
                dt = gen.GetTable(SQLString);
            }
            catch
            {
                XtraMessageBox.Show(SQLString, "load_datagrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Visible = true;
                txtSQL.Text = SQLString;
            }
            DataTable temp = new DataTable();
            temp.Columns.Add("No");
            temp.Columns.Add("Table Name");
            temp.Columns.Add("Type");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = i + 1;
                dr[1] = dt.Rows[i][2].ToString();
                dr[2] = dt.Rows[i][3].ToString();

                temp.Rows.Add(dr);
            }
            lvpq.DataSource = temp;
        }

        private void load_tablename()
        {
            string SQLString = "SELECT * FROM information_schema.tables";

            try
            {
                dt = gen.GetTable(SQLString);
            }
            catch
            {
                XtraMessageBox.Show(SQLString, "load_tablename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Visible = true;
                txtSQL.Text = SQLString;
            }

            txtTableName.Properties.View.Columns.Clear();

            DataTable temp = new DataTable();
            temp.Columns.Add("Table Name");
            temp.Columns.Add("Type");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = dt.Rows[i][2].ToString();
                dr[1] = dt.Rows[i][3].ToString();
                temp.Rows.Add(dr);
            }
            txtTableName.Properties.DataSource = temp;
            txtTableName.Properties.DisplayMember = "Table Name";
            txtTableName.Properties.ValueMember = "Table Name";
            txtTableName.Focus();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            lvpq.Visible = true;
            SQLString = "SELECT c.name 'Column Name', t.Name 'Data type', c.max_length 'Max Length', c.is_nullable, ISNULL(i.is_primary_key, 0) 'Primary Key' FROM";
            SQLString += " sys.columns c INNER JOIN sys.types t ON c.user_type_id = t.user_type_id LEFT OUTER JOIN sys.index_columns ic ON ic.object_id = c.object_id AND ";
            SQLString += " ic.column_id = c.column_id LEFT OUTER JOIN sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id ";
            SQLString += " WHERE c.object_id = OBJECT_ID('" + txtTableName.Text + "')";
            try
            {
                dt.Rows.Clear();
                dt = gen.GetTable(SQLString);
            }
            catch
            {
                XtraMessageBox.Show(SQLString, "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Visible = true;
                txtSQL.Text = SQLString;

            }
            DataTable temp = new DataTable();
            temp.Rows.Clear();

            temp.Columns.Add("Column Name");
            temp.Columns.Add("Data type");
            temp.Columns.Add("Max length");
            temp.Columns.Add("Is NULL");
            temp.Columns.Add("Is Primary Key");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = dt.Rows[i][0].ToString();
                dr[1] = dt.Rows[i][1].ToString();
                dr[2] = dt.Rows[i][2].ToString();
                dr[3] = dt.Rows[i][3].ToString();
                temp.Rows.Add(dr);
            }
            lvpq.DataSource = null;
            view.Columns.Clear();
            lvpq.DataSource = temp;
        }
      

        private void btnContent_Click(object sender, EventArgs e)
        {
            if (txtTableName.Text == "")
            {
                XtraMessageBox.Show("Please enter the table name", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // view content of a table
                DataTable temp = new DataTable();
                DataTable dt = new DataTable();
                string code = txtTableName.Text;

                SQLString = "SELECT	name FROM sys.columns where object_id = OBJECT_ID('" + code + "')";
                dt = gen.GetTable(SQLString);
                int sum = dt.Rows.Count; // so cot trong table
                if (sum > 10) sum = 10;
                for (int i = 0; i < sum; i++)
                {
                    string name = dt.Rows[i][0].ToString();
                    temp.Columns.Add(name);
                }
                                             
                               
                view.OptionsView.ColumnAutoWidth = true;                                
                view.Columns.Clear();


                var db = gen.GetNewEntity(); // khai bao new entity Framework
                {
                    var select = from s in db.Accounts select s; // chua lay table name dong duoc
                    foreach (var data in select.Take(5))
                    {
                        DataRow dr = temp.NewRow();
                        dr[0] = data.AccountNumber;
                        dr[1] = data.AccountName;
                        temp.Rows.Add(dr);
                    }
                }

                lvpq.DataSource = temp;

                view.OptionsBehavior.Editable = false;
                view.OptionsSelection.EnableAppearanceFocusedCell = false;
                view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                //view.Columns[0].Visible = false;

                view.OptionsView.ShowFooter = true;
                view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            }
        }
    }
}
  
