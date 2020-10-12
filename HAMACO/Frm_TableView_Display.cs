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

namespace HAMACO
{
    public partial class Frm_TableView_Display : DevExpress.XtraEditors.XtraForm
    {
        String code; // type = "Create"/"Update"
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;

        string SQLString = "";
        public Frm_TableView_Display()
        {
            InitializeComponent();
        }

        private void btnContent_Click(object sender, EventArgs e)
        {
            // view content
            DataTable temp = new DataTable();

            SQLString = "SELECT	name FROM sys.columns where object_id = OBJECT_ID('" + code + "')";
            dt = gen.GetTable(SQLString);
            int sum = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i][0].ToString();
                temp.Columns.Add(name);
            }

            //content
            SQLString = "SELECT * FROM " + code + " WHERE ClientID=" + Globals.clientid;
            DataTable dt2 = new DataTable();
            try
            {
                dt2 = gen.GetTable(SQLString);
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    DataRow dr = temp.NewRow();
                    for (int i = 0; i < sum; i++)
                    {
                        dr[j + i] = dt2.Rows[j + i][i].ToString(); // dong j cot i                        
                    }
                    temp.Rows.Add(dr);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Visible = true;
                txtSQL.Text = ex.ToString();
            }

            gridControl1.Visible = true;
            gridControl1.DataSource = temp;
        }

        private void Frm_TableView_Display_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Data Browser: Table " + code;
            txtSQL.Visible = false;

            gridControl1.Visible = false;
            // load field primary key
            load_primary_key_field();
        }

        private void load_primary_key_field()
        {
            SQLString = "SELECT name FROM sys.columns where object_id = OBJECT_ID('" + code + "') and column_id in ";
            SQLString += " (SELECT column_id FROM sys.index_columns where object_id = OBJECT_ID('" + code + "') and column_id in ";
            SQLString += "(SELECT column_id FROM sys.columns where object_id = OBJECT_ID('" + code + "')))";
            try
            {
                dt = gen.GetTable(SQLString);
            }
            catch
            {
                XtraMessageBox.Show(SQLString, "load_primary_key_field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Visible = true;
                txtSQL.Text = SQLString;
            }

            int n = 4;
            TextBox[] textBoxes = new TextBox[n];
            Label[] labels = new Label[n];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i][0].ToString();

                labels[i] = new Label();
                textBoxes[i] = new TextBox();
                labels[i].Text = name;

                labels[i].Left = 10;
                labels[i].Top = 100 + (i + 1) * 20;
                textBoxes[i].Left = 120;
                textBoxes[i].Top = 100 + (i + 1) * 20;
                if (labels[i].Text == "ClientID")
                {
                    textBoxes[i].Text = Globals.clientid.ToString();
                }

                this.Controls.Add(labels[i]);
                this.Controls.Add(textBoxes[i]);
            }
        }
        public string getcode(string a)
        {
            code = a;
            return code;
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
    }
}