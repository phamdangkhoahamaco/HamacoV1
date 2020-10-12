using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_branch : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        branch branch = new branch();
        string active, role,userid;
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
        public Frm_branch()
        {
            InitializeComponent();
        }
        
        private void Frm_branch_Load(object sender, EventArgs e)
        {
            DataTable da = new DataTable();
            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã tỉnh");
            temp1.Columns.Add("Tên tỉnh");
            da = gen.GetTable("select * from Province order by ProvinceName");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp1.Rows.Add(dr);
            }
            leprovince.Properties.DataSource = temp1;
            leprovince.Properties.ValueMember = "Mã tỉnh";
            leprovince.Properties.DisplayMember = "Tên tỉnh";
            leprovince.EditValue = "CT";

            radioButton1.Checked = true;


            DataTable dt1 = new DataTable();
            DataTable temp9 = gen.GetTable("select InventoryCategoryCode as 'Mã ngành',InventoryCategoryName as 'Tên ngành' from InventoryItemCategory where IsParent=0 and Grade=3 order by InventoryCategoryCode");
            dt1.Columns.Add("Mã ngành", Type.GetType("System.String"));
            dt1.Columns.Add("Tên ngành", Type.GetType("System.String"));
            dt1.Columns.Add("Hạn mức", Type.GetType("System.Double"));
            for (int i = 0; i < temp9.Rows.Count; i++)
            {
                DataRow dr = dt1.NewRow();
                dr[0] = temp9.Rows[i][0].ToString();
                dr[1] = temp9.Rows[i][1].ToString();
                dt1.Rows.Add(dr);
            }
            DAT.DataSource = dt1;

            ViewDAT.OptionsBehavior.Editable = true;
            ViewDAT.Columns["Mã ngành"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Tên ngành"].OptionsColumn.AllowEdit = false;
            ViewDAT.Columns["Hạn mức"].OptionsColumn.AllowEdit = true;

            ViewDAT.Columns["Hạn mức"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewDAT.Columns["Hạn mức"].DisplayFormat.FormatString = "{0:n0}";

            ViewDAT.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            
            if (active == "1")
            {
                this.Text = "Sửa đơn vị";
                //da = gen.GetTable("select * from Branch where BranchID='" + role + "'");
                Guid branchid = Guid.Parse(role);
                var ctx = gen.GetNewEntity();
                var query = ctx.Branches
                                  .Where(c => c.BranchID == branchid).OrderBy(c => c.BranchCode);
                foreach (var data in query)
                {
                    txtcode.Text = data.BranchCode;
                    txtname.Text = data.BranchName;
                    txtdg.Text = data.Description;
                    if (data.IsDependent == true)
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                }           
               

                DataTable temp = new DataTable();
                var query1 = ctx.Branches
                            .Where(p => p.CompanyCode == Globals.companycode && p.BranchCode != txtcode.Text)
                            .Select(p => new { p.BranchCode, p.BranchName })
                            .ToList();
                temp = gen.ConvertToDataTable(query1);
                ledv.Properties.DataSource = temp;
                ledv.Properties.ValueMember = "BranchCode";
                ledv.Properties.DisplayMember = "BranchCode";
                
                //stock
                var query2 = ctx.Stocks.Where(c => c.CompanyCode == Globals.companycode)
                            .Select(c => new { c.StockCode, c.StockName })
                            .ToList();
                temp = gen.ConvertToDataTable(query2);                
                lekho.Properties.DataSource = temp;
                lekho.Properties.ValueMember = "StockCode";
                lekho.Properties.DisplayMember = "StockCode";
                foreach (var data in query)
                {
                    if (data.Parent != null)
                    {
                        string dv = gen.GetString("select BranchCode from Branch where BranchID='" + data.Parent.ToString() + "'");
                        ledv.EditValue = dv;
                    }
                    if (data.StockBranch != null)
                    {
                        string dv = gen.GetString("select StockCode from Stock where StockID='" + data.StockBranch + "'");
                        lekho.EditValue = dv;
                    }
                    leprovince.EditValue = data.Province;
                    txtmst.Text = data.Code; // ma so thue
                }
                
                
            }
            else
            {
                this.Text = "Thêm đơn vị";
                //da = gen.GetTable("select BranchCode,BranchName from Branch");
                //chuyen sang dung kieu moi
                var db= gen.GetNewEntity(); // khai bao new entity Framework
                {
                    var query = db.Branches
                        .Where(p => p.CompanyCode == Globals.companycode)
                        .Select(p=>new { p.BranchCode, p.BranchName})
                        .ToList();
                    da = gen.ConvertToDataTable(query);
                }
                

                ledv.Properties.DataSource = da;
                ledv.Properties.ValueMember = "BranchCode";
                ledv.Properties.DisplayMember = "BranchCode";
                da = gen.GetTable("select StockCode,StockName from Stock");
                lekho.Properties.DataSource = da;
                lekho.Properties.ValueMember = "StockCode";
                lekho.Properties.DisplayMember = "StockCode";
                lekho.ItemIndex = 0;
            }
        }

        private void tstbcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            if (keyData == (Keys.Enter))
            {

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            //branch.checkbranch(active, txtcode, txtname, this, ledv, txtdg, radioButton1, role,lekho,leprovince,txtmst);            
            Branch data = new Branch();// lop branch
            if (active == "0")
            {
                data.BranchID = Guid.NewGuid();// tao guiid moi
            }
            else
            {                
                data.BranchID = Guid.Parse(role) ;
            }
            //data.ClientID = Globals.clientid;
            data.CompanyCode = Globals.companycode;
            data.BranchCode = txtcode.Text;
            data.BranchName = txtname.Text;
            data.Description = txtdg.Text;
            data.IsDependent = true;
            data.Inactive = false;
            data.Grade = 1;
            data.Province = leprovince.EditValue.ToString();
            //string dv = gen.GetString("select BranchCode from Branch where BranchID='" + ledv.EditValue + "'");
            Guid stockid = Guid.Parse(gen.GetString("select StockID from Stock where StockCode='" + lekho.EditValue + "'")); 
            data.StockBranch = stockid;
            try
            {
                Guid branchid = Guid.Parse(gen.GetString("select BranchID from Branch where BranchCode='" + ledv.EditValue + "'"));
                data.Parent = branchid;
            }
            catch
            {
                data.Parent = null;
            }


            var db = gen.GetNewEntity(); // khai bao new entity Framework
            
                try
                {
                    if (active == "0") db.Branches.Add(data); //insert
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

            
            

            //Guid branchid = "";
            //data.StockBranch = lekho.EditValue;
            //sql = "update Branch set BranchCode=N'" + a.Text + "', BranchName=N'" + b.Text + "',Description=N'" + txtdg.Text + "',IsDependent='" + th + "',Parent=NULL,Grade=1,StockBranch='" + kho + "',Province='" + leprovince.EditValue.ToString() + "',Code='" + txtmst.Text + "' where BranchID='" + role + "'";

        }
    }
}