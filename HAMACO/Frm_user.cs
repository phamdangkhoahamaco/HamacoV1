using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_user : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        mscrole mscrole = new mscrole();
        string active, role,userid, username, password;
        public delegate void ac();
        public ac myac;
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public string getuserid(string a)
        {
            userid = a;
            return userid;
        }
        public string getusername(string a)
        {
            username = a;
            return username;
        }
        public Frm_user()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Frm_user_Load(object sender, EventArgs e)
        {
            txtSQL.Visible = false;
            txtCompanyCode.ReadOnly = true;
            txtInactive.ReadOnly = true;

            //branch
            load_ledv();
            //kho
            load_txtStockCode();
            load_txtStockCode2();
            // role
            load_txtRole();

            if (active == "1")
            {
                this.Text = "Sửa người dùng";
                var ctx = gen.GetNewEntity(); // khai bao new entity Framework
                var query = ctx.MSC_User
                        .Where(c => c.UserName == username && c.CompanyCode == Globals.companycode);

                //da = gen.GetTable("select * from MSC_User where UserID = '" + role + "'");
                foreach (var data in query)
                {
                    txtuser.Text = data.UserName;
                    txtname.Text = data.FullName;
                    txtjob.Text = data.JobTitle;
                    txtdes.Text = data.Description;
                    txtInactive.Text = data.Inactive.ToString();
                    txtCompanyCode.Text = data.CompanyCode;
                    txtmail.Text = data.Email;
                    txtweb.Text = data.Website;
                    txtwphone.Text = data.WorkPhone;
                    txtphone.Text = data.MobilePhone;
                    txthphone.Text = data.HomePhone;
                    txtfax.Text = data.Fax;
                    txtwadress.Text = data.WorkAddress;
                    txthadress.Text = data.HomeAddress;
                    string dv = gen.GetString("select BranchCode from Branch where BranchID='" + data.BranchID.ToString() + "'");
                    ledv.EditValue = dv;
                    role = data.UserID.ToString(); // doi dang GUID --> string
                    password = data.Password;
                }


                load_lai_grid_kho();
                load_lai_grid_kho2();
                load_lai_grid_role();

            }                
            else
            {
                this.Text = "Thêm người dùng";
                txtCompanyCode.Text = Globals.companycode;
                txtInactive.Text = "False";
                txtuser.Text = username;
                txtuser.ReadOnly = true;
            }
        }

        private void load_txtStockCode2()
        {
            DataTable temp2 = new DataTable();
            temp2.Clear();

            temp2.Columns.Add("Stock Code");
            temp2.Columns.Add("Stock Name");
            var ctx3 = gen.GetNewEntity(); // khai bao new entity Framework
            var query3 = ctx3.Stocks
                .Where(c => c.CompanyCode == Globals.companycode)
                .OrderBy(c => c.StockCode);
            foreach (var data in query3)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = data.StockCode;
                dr[1] = data.StockName;
                temp2.Rows.Add(dr);
            }
            txtStockCode2.Properties.DataSource = temp2;
            txtStockCode2.Properties.DisplayMember = "Stock Code";
            txtStockCode2.Properties.ValueMember = "Stock Code";
        }

        private void load_ledv()
        {
            DataTable temp2 = new DataTable();
            temp2.Clear();

            temp2.Columns.Add("Mã đơn vị");
            temp2.Columns.Add("Tên đơn vị");
            var ctx3 = gen.GetNewEntity(); // khai bao new entity Framework
            var query3 = ctx3.Branches
                .Where(c => c.CompanyCode == Globals.companycode)
                .OrderBy(c => c.BranchCode);
            foreach (var data in query3)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = data.BranchCode;
                dr[1] = data.BranchName;
                temp2.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp2;
            ledv.Properties.DisplayMember = "Tên đơn vị";
            ledv.Properties.ValueMember = "Mã đơn vị";
        }

        private void load_txtRole()
        {
            DataTable temp2 = new DataTable();
            temp2.Clear();

            temp2.Columns.Add("Role Code");
            temp2.Columns.Add("Role Name");
            var ctx3 = gen.GetNewEntity(); // khai bao new entity Framework
            var query3 = ctx3.Roles
                .OrderBy(c => c.RoleCode);
            foreach (var data in query3)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = data.RoleCode;
                dr[1] = data.RoleName;
                temp2.Rows.Add(dr);
            }
            txtRole.Properties.DataSource = temp2;
            txtRole.Properties.DisplayMember = "Role Code";
            txtRole.Properties.ValueMember = "Role Code";
        }

        private void load_lai_grid_role()
        {
            DataTable dt = new DataTable();
            var ctx2 = gen.GetNewEntity(); // khai bao new entity Framework
            var query2 = ctx2.UserJoinRoles
                     .Join(ctx2.Roles, c => c.RoleCode, d => d.RoleCode,
                     (c, d) => new { c.RoleCode, d.RoleName, c.CompanyCode, c.UserName }
                     )
                    .Where(c => c.UserName == username && c.CompanyCode == Globals.companycode);

            dt.Columns.Add("Role Code", Type.GetType("System.String"));
            dt.Columns.Add("Role Name", Type.GetType("System.String"));
            foreach (var data in query2)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.RoleCode;
                dr[1] = data.RoleName;
                dt.Rows.Add(dr);
            }
            gridControl_Role.DataSource = dt;
            gridView_Role.OptionsBehavior.Editable = false;
            gridView_Role.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView_Role.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            string branchid = gen.GetString("select * from Branch where BranchCode='" + ledv.EditValue.ToString() + "'");

            // viet theo kieu moi
            MSC_User data = new MSC_User();// lop MSC_User
            if (active == "0")
            {
                data.UserID = Guid.NewGuid();// tao guiid moi
            }
            else
            {
                data.UserID = Guid.Parse(role);
            }
            if (txtInactive.Text == "True") data.Inactive = true; // locked
            else data.Inactive = false;

            data.UserName = txtuser.Text;
            data.FullName = txtname.Text;
            data.JobTitle = txtjob.Text;
            data.Description = txtdes.Text;            
            data.CompanyCode = txtCompanyCode.Text;
            data.Email = txtmail.Text;
            data.Website = txtweb.Text;
            data.WorkPhone = txtwphone.Text;
            data.MobilePhone = txtphone.Text;
            data.HomePhone = txthphone.Text;
            data.Fax = txtfax.Text;
            data.WorkAddress = txtwadress.Text;
            data.HomeAddress = txthadress.Text;
            data.Password = password; // luu lai password tru khi bi loi reset
            try
            {
               Guid branchid2 = Guid.Parse(gen.GetString("select BranchID from Branch where BranchCode='" + ledv.EditValue + "'"));
                data.BranchID = branchid2;
            }
            catch
            {
                data.BranchID = null;
            }
            var db = gen.GetNewEntity(); // khai bao new entity Framework

            try
            {
                if (active == "0") db.MSC_User.Add(data); //insert
                else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update
                db.SaveChanges();
                XtraMessageBox.Show("Submit successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //catch (DbUpdateException ex) // exception khac
            catch (DbEntityValidationException ex) // exception khac
            {
                txtSQL.Visible = true;
                txtSQL.Text = role;
                foreach (var eve in ex.EntityValidationErrors)
                {
                    txtSQL.Text += "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                    txtSQL.Text += eve.Entry.Entity.GetType().Name;
                    txtSQL.Text += eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        //txtSQL.Text += ve.ErrorMessage;
                        XtraMessageBox.Show(ve.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //throw;
            }
        }

        private void view_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddRole_Click(object sender, EventArgs e) // add role
        {
            // insert in to UserJoinRole
            UserJoinRole data = new UserJoinRole();// lop UserJoinRole            

            data.UserName = txtuser.Text;
            data.CompanyCode = Globals.companycode;
            data.RoleCode = txtRole.Text;

            var db = gen.GetNewEntity(); // khai bao new entity Framework

            try
            {
                db.UserJoinRoles.Add(data); //insert
                db.SaveChanges();
                XtraMessageBox.Show("Insert successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_lai_grid_role();
            }
            catch (Exception ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DeleteRole_Click(object sender, EventArgs e) // delete role
        {
            // delete UserJoinRole
            UserJoinRole data = new UserJoinRole();// lop UserJoinRole            

            data.UserName = txtuser.Text;
            data.CompanyCode = Globals.companycode;
            data.RoleCode = txtRole.Text;
            var db = gen.GetNewEntity(); // khai bao new entity Framework
            try
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted; // delete
                db.SaveChanges();
                XtraMessageBox.Show("Deleted successfully", "btn_DeleteRole_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_lai_grid_role();
            }
            catch (Exception ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStockCode2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtStockCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd2_Click(object sender, EventArgs e) 
        {
            // insert in to UserJoinStock
            UserJoinStock_Approve data = new UserJoinStock_Approve();// lop UserJoinStock_Approve            

            data.UserName = txtuser.Text;
            data.CompanyCode = Globals.companycode;
            data.StockCode = txtStockCode2.Text;

            var db = gen.GetNewEntity(); // khai bao new entity Framework

            try
            {
                db.UserJoinStock_Approve.Add(data); //insert
                db.SaveChanges();
                XtraMessageBox.Show("Insert successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_lai_grid_kho2();
            }
            catch (Exception ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_lai_grid_kho2()
        {
            DataTable dt = new DataTable();
            var ctx2 = gen.GetNewEntity(); // khai bao new entity Framework
            var query2 = ctx2.UserJoinStock_Approve
                     .Join(ctx2.Stocks, c => c.StockCode, d => d.StockCode,
                     (c, d) => new { c.StockCode, d.StockName, c.CompanyCode, c.UserName }
                     )
                    .Where(c => c.UserName == username && c.CompanyCode == Globals.companycode);

            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            foreach (var data in query2)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.StockCode;
                dr[1] = data.StockName;
                dt.Rows.Add(dr);
            }
            gridControl2.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            UserJoinStock_Approve data = new UserJoinStock_Approve();// lop UserJoinStock            

            data.UserName = txtuser.Text;
            data.CompanyCode = Globals.companycode;
            data.StockCode = txtStockCode2.Text;
            var db = gen.GetNewEntity(); // khai bao new entity Framework
            try
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted; // delete
                db.SaveChanges();
                XtraMessageBox.Show("Deleted successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_lai_grid_kho2();
            }
            catch (Exception ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbok_Click(object sender, EventArgs e) // add stock (kho)
        {
            // insert in to UserJoinStock
            UserJoinStock data = new UserJoinStock() ;// lop UserJoinStock            
            
            data.UserName = txtuser.Text;
            data.CompanyCode = Globals.companycode;
            data.StockCode = txtStockCode.Text;            
            
            var db = gen.GetNewEntity(); // khai bao new entity Framework

            try
            {
                db.UserJoinStocks.Add(data); //insert
                db.SaveChanges();
                XtraMessageBox.Show("Insert successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_lai_grid_kho();
            }
            catch (Exception ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_lai_grid_kho()
        {
            DataTable dt = new DataTable();
            var ctx2 = gen.GetNewEntity(); // khai bao new entity Framework
            var query2 = ctx2.UserJoinStocks
                     .Join(ctx2.Stocks, c => c.StockCode, d => d.StockCode,
                     (c, d) => new { c.StockCode, d.StockName, c.CompanyCode, c.UserName }
                     )
                    .Where(c => c.UserName == username && c.CompanyCode == Globals.companycode);

            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            foreach (var data in query2)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.StockCode;
                dr[1] = data.StockName;
                dt.Rows.Add(dr);
            }
            gridControl1.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        }

        private void load_txtStockCode()
        {
            DataTable temp2 = new DataTable();
            temp2.Clear(); 

           temp2.Columns.Add("Stock Code");
            temp2.Columns.Add("Stock Name");
            var ctx3 = gen.GetNewEntity(); // khai bao new entity Framework
            var query3 = ctx3.Stocks
                .Where(c => c.CompanyCode == Globals.companycode)
                .OrderBy(c => c.StockCode);
            foreach (var data in query3)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = data.StockCode;
                dr[1] = data.StockName;
                temp2.Rows.Add(dr);
            }
            txtStockCode.Properties.DataSource = temp2;
            txtStockCode.Properties.DisplayMember = "Stock Code";
            txtStockCode.Properties.ValueMember = "Stock Code";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // delete to UserJoinStock
            if (XtraMessageBox.Show("Do you want to delete this order?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                UserJoinStock data = new UserJoinStock();// lop UserJoinStock            

                data.UserName = txtuser.Text;
                data.CompanyCode = Globals.companycode;
                data.StockCode = txtStockCode.Text;
                var db = gen.GetNewEntity(); // khai bao new entity Framework
                try
                {
                    db.Entry(data).State = System.Data.Entity.EntityState.Deleted; // delete
                    db.SaveChanges();
                    XtraMessageBox.Show("Deleted successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_lai_grid_kho();
                }
                catch (Exception ex) // exception khac
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        
        } 
    }
}