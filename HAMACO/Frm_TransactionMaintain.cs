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
using DevExpress.XtraNavBar; // de tao menu
using HAMACO.Resources; // import bo thu vien cua HAMACO
using System.Data.Entity.Infrastructure;
// tài liệu hd: https://docs.google.com/document/d/1S8h8c42pISc1oWR564a7cL5sGsulZd8caxpg8MfstFA/edit?usp=sharing


namespace HAMACO
{
    public partial class Frm_TransactionMaintain : DevExpress.XtraEditors.XtraForm
    {
        String username;
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string userid = Globals.userid;
        string tcode, active;
        string SQLString = "";
        public Frm_TransactionMaintain()
        {
            InitializeComponent();
        }

        private void Frm_TransactionMaintain_Load(object sender, EventArgs e)
        {
            //load combobox module
            load_module();
            txtSQL.Visible = false;
            txtTransactionCode.Enabled = false;
            txtTransactionCode.Text = tcode;

            if (active == "1")
            {
                this.Text = "Modify transaction";
                var ctx = gen.GetNewEntity(); // khai bao new entity Framework
                var data = ctx.Transactions.FirstOrDefault(c => c.TransactionCode == txtTransactionCode.Text);

                if (data != null)
                {
                    txtFormName.Text = data.FormName;                    
                    txtTransactionName.Text = data.TransactionName;
                    txtSortNo.Text = data.SortNo.ToString();
                    txtIsParent.Text = data.IsParent.ToString();
                    txtIsDisplay.Text = data.IsDisplay.ToString();
                    txtRoleCode.Text = data.RoleCode;
                    txtParentFolder.Text = data.ParentFolder;
                    txtIsDynamic.Text = data.IsDynamic.ToString();
                    txtProcedureName.Text = data.ProcedureName;
                }
                load_grid_item(); // table Transactions_DynamicReport
            }
        }

        private void load_grid_item()
        {
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var dt = ctx.Transactions_DynamicReport
                .Where(c => c.TransactionCode == txtTransactionCode.Text)
                .OrderBy(c=> new{c.IsInput,c.OrderNo})
                .ToList();
            gridControl_Item.DataSource = new BindingList<Transactions_DynamicReport>(dt);

            if (active == "2")
            {
                gridView1.OptionsBehavior.Editable = false;
                btnSave.Visible = false;
            }
            if (active == "2") gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        private void load_module()
        {
            /*txtModule.Items.Add("SY");
            txtModule.Items.Add("FI");
            txtModule.Items.Add("BC");
            */
            DataTable da = new DataTable();
            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Role Code");
            temp1.Columns.Add("Role Name");
            da = gen.GetTable("select * from Roles order by RoleCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();                
                temp1.Rows.Add(dr);
            }
            txtRoleCode.Properties.DataSource = temp1;
            txtRoleCode.Properties.ValueMember = "Role Code";
            txtRoleCode.Properties.DisplayMember = "Role Code";
        }

        public string gettcode(string a)
        {
            tcode = a;
            return tcode;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTransactionName.Text == "" || txtFormName.Text == "")
            {
                XtraMessageBox.Show("Fill in all required entry fields", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //cach moi dung Entity Framework
                Transaction data = new Transaction();// lop Transaction

                data.TransactionCode = txtTransactionCode.Text; // khoa chinh
                data.FormName = txtFormName.Text;
                data.TransactionName = txtTransactionName.Text  ;
                data.SortNo = Int32.Parse(txtSortNo.Text);
                data.IsParent = Int32.Parse(txtIsParent.Text);
                data.IsDisplay = Int32.Parse(txtIsDisplay.Text);
                data.RoleCode = txtRoleCode.Text;
                data.ParentFolder = txtParentFolder.Text;
                data.IsDynamic = Int32.Parse(txtIsDynamic.Text);
                data.ProcedureName = txtProcedureName.Text;
                var db = gen.GetNewEntity(); // khai bao new entity Framework
                try
                {
                    if (active == "0") db.Transactions.Add(data); //insert
                    else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update
                    db.SaveChanges();
                    XtraMessageBox.Show("Submit successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //catch (DbUpdateException ex) // exception khac
                catch (DbUpdateConcurrencyException ex) // exception khac
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message + active, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSQL.Text = ex.Message + data + active;
                }

                //update luon line o duoi
                update_Transactions_DynamicReport();
            }
        }

        private void update_Transactions_DynamicReport()
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework
            //txtSQL.Text += gridView1.RowCount;
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                Transactions_DynamicReport data = new Transactions_DynamicReport();// class Transactions_DynamicReport

                data.TransactionCode = txtTransactionCode.Text;
                data.FieldName = gridView1.GetRowCellValue(i, "FieldName").ToString();
                data.FieldNameVN = gridView1.GetRowCellValue(i, "FieldNameVN").ToString();
                data.TypeName = gridView1.GetRowCellValue(i, "TypeName").ToString();
                try { data.IsInput = Int32.Parse(gridView1.GetRowCellValue(i, "IsInput").ToString()); } catch { }
                try { data.OrderNo = Int32.Parse(gridView1.GetRowCellValue(i, "OrderNo").ToString()); }catch { }
                try { data.IsSum = Int32.Parse(gridView1.GetRowCellValue(i, "IsSum").ToString()); } catch { }

                try
                {
                    db.Transactions_DynamicReport.Add(data); //insert                                    
                    db.SaveChanges();
                    
                }                
                catch 
                {                    
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update                                
                    db.SaveChanges();
                }
            }
        }
    }
}