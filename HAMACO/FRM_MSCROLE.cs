using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class FRM_MSCROLE : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        mscrole mscrole = new mscrole();
        string active, role="1a864d31-4560-4d42-9d63-bd02422a6237",userid;
        public delegate void ac();
        public ac myac;
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        
        public string getuserid(string a)
        {
            userid = a;
            return userid;
        }
        
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public FRM_MSCROLE()
        {
            InitializeComponent();
        }

        private void FRM_MSCROLE_Load(object sender, EventArgs e)
        {
            if (active == "1")
            {
                this.Text = "Sửa vai trò";
                this.txtmsccode.ReadOnly = true;
                DataTable da = new DataTable();
                da = gen.GetTable("select * from MSC_Role where RoleID = '" + role + "'");
                txtmsccode.Text = da.Rows[0][1].ToString();
                txtmscname.Text = da.Rows[0][2].ToString();
                txtmscdg.Text = da.Rows[0][3].ToString();
            }
            else { this.Text = "Thêm vai trò"; }

        }

        private void tssave_Click(object sender, EventArgs e)
        {
            if (active == "1")
            {
                string sql = "update MSC_Role set RoleName=N'" + txtmscname.Text + "', Description=N'" + txtmscdg.Text + "' where RoleID='" + role + "'";
                mscrole.checkinfo(txtmsccode.Text, txtmscname.Text, sql, this, "1",role);
            }
            else
            {
                string sql = "insert into MSC_Role values(newid(),N'" + txtmsccode.Text + "',N'" + txtmscname.Text + "',N'" + txtmscdg.Text + "','1')";
                mscrole.checkinfo(txtmsccode.Text, txtmscname.Text, sql, this, "0",role);
            }
        }

        private void tscancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}