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
    public partial class Frm_stock : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        stock stock = new stock();
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
        public Frm_stock()
        {
            InitializeComponent();
        }

        private void Frm_stock_Load(object sender, EventArgs e)
        {

            DataTable daa = new DataTable();
            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã tỉnh");
            temp1.Columns.Add("Tên tỉnh");
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework;
            //var query = from ctx.Province ;
            var query = ctx.Provinces
                            .OrderBy(c => c.ProvinceName);

            //.OrderBy(c => c.BranchCode);

            //daa = gen.GetTable("select * from Province order by ProvinceName");
            foreach (var data2 in query)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = data2.ProvinceCode;
                dr[1] = data2.ProvinceName;   
                temp1.Rows.Add(dr);
            }
            
            leprovince.Properties.DataSource = temp1;
            leprovince.Properties.ValueMember = "Mã tỉnh";
            leprovince.Properties.DisplayMember = "Tên tỉnh";
            leprovince.EditValue = "CT";


            DataTable data = new DataTable();

            DataTable da2 = new DataTable();
            da2.Columns.Add("Mã kho");
            da2.Columns.Add("Tên kho");
            //data = gen.GetTable("select StockCode,StockName from Stock order by StockCode");
            var query1 = ctx.Stocks
                           .OrderBy(c => c.StockCode)
                           .Select(c => new { c.StockCode, c.StockName });
            foreach (var data2 in query1)
            {
                DataRow dr = da2.NewRow();
                dr[0] = data2.StockCode;
                dr[1] = data2.StockName;
                da2.Rows.Add(dr);
            }
            lekho.Properties.DataSource = da2;
            lekho.Properties.DisplayMember = "Mã kho";
            lekho.Properties.ValueMember = "Mã kho";


            DataTable da1 = new DataTable();
            da1.Columns.Add("ID", typeof(String));
            da1.Columns.Add("Name", typeof(String));
            //data = gen.GetTable("select branchCode, branchName,branchID from Branch order by branchCode");
            var query2 = ctx.Branches
                           .OrderBy(c => c.BranchCode);
                           //.Select(c => new { c.BranchCode, c.BranchName, c.BranchID });
            /*for (int i = 0; i < data.Rows.Count; i++)
            {
                da1.Rows.Add(new String[] { data.Rows[i][0].ToString(), data.Rows[i][1].ToString() });
            }*/
            foreach (var data2 in query2)
            {
                DataRow dr = da1.NewRow();
                dr[0] = data2.BranchCode;
                dr[1] = data2.BranchName;
                da1.Rows.Add(dr);
            }
            cbbranch.Properties.DataSource = da1;
            cbbranch.Properties.DisplayMember = "ID";
            cbbranch.Properties.ValueMember = "ID";


            if (active == "1")
            {
                this.Text = "Sửa kho";
                txtcode.ReadOnly = true;
                DataTable da = new DataTable();
                //da = gen.GetTable("select * from Stock where StockID='" + role + "'");\
                var db= gen.GetNewEntity(); // khai bao new entity Framework
                {
                    Guid stockid = Guid.Parse(role);
                    var query3 = ctx.Stocks
                           .Where(c => c.StockID== stockid  && c.CompanyCode == Globals.companycode)
                           .OrderBy(c => c.StockCode);
                    //da = gen.ConvertToDataTable(query3);
                    foreach (var data2 in query3)
                    {
                        txtcode.Text = data2.StockCode;
                        txtname.Text = data2.StockName;
                        txtdg.Text = data2.Description;
                       // string stockid = data2.StockID.ToString();
                        lekho.EditValue = gen.GetString2("Stock", "StockCode", "StockID", data2.StockID.ToString(), Globals.clientid);
                        cbbranch.EditValue = gen.GetString2("Branch", "BranchCode", "BranchID", data2.BranchID.ToString(), Globals.clientid);
                        chbntd.Checked = data2.Inactive;
                        LPG.Checked = (bool) data2.LPG ;
                        leprovince.EditValue = data2.Province;
                        txtmst.Text = data2.Code;
                        txttcn.Text = data2.InvName;
                        txtnote.Text = data2.Note;
                    }
                }
                
                /*                
                try
                {
                    lekho.EditValue = gen.GetString("select StockCode from Stock where StockID='" + da.Rows[0][8].ToString() + "'");                  
                }
                catch 
                {
                    lekho.EditValue = da.Rows[0][1].ToString();
                }*/
                /*for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (da.Rows[0][4].ToString() == data.Rows[i][2].ToString())
                        cbbranch.SelectedIndex = i;
                }*/
                
            }
            else
            {
                this.Text = "Thêm kho";
                lekho.ItemIndex = 0;
                chbntd.Hide();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            string branch = gen.GetString("select BranchID from Branch where BranchCode='" + cbbranch.EditValue.ToString() + "'");
            string khochinh = gen.GetString("select StockID from Stock where StockCode='" + lekho.EditValue.ToString() + "'");
            Stock data = new Stock();
            if (active == "0")
            {
                data.StockID = Guid.NewGuid();// tao guiid moi
            }
            else
            {                
                data.StockID = Guid.Parse(role);
            }
            //cac field khac null phai co
            //data.ClientID = Globals.clientid;
            data.CompanyCode = Globals.companycode;
            data.StockCode = txtcode.Text; // khong null
            data.StockName = txtname.Text; // khong null
            data.Description = txtdg.Text;
            data.BranchID = Guid.Parse(branch);
            data.Inactive = chbntd.Checked; // khong null
            data.LPG = LPG.Checked;
            data.Parent = Guid.Parse(khochinh);
            data.Province = leprovince.EditValue.ToString();
            data.Code = txtmst.Text;
            data.InvName = txttcn.Text;
            data.Note = txtnote.Text;
            //txtSQL.Text = data.StockID + active;
            var db= gen.GetNewEntity(); // khai bao new entity Framework
            {
                try
                {
                    if (active == "0") db.Stocks.Add(data); //insert
                    else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update
                    db.SaveChanges();
                    XtraMessageBox.Show("Submit successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //catch (DbUpdateException ex) // exception khac
                catch (DbUpdateException ex) // exception khac
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    txtSQL.Text = ex.Message + data.Province  + data.StockID + active;
                }

            }

            /*if (active == "1")
            {
                string sql = "update Stock set StockName=N'" + txtname.Text + "',Description=N'" + txtdg.Text + "',BranchID='" + branch + "',Inactive='" + chbntd.Checked.ToString() + 
                "',LPG='"+LPG.Checked.ToString()+"',Parent='"+khochinh+"',Province='"+leprovince.EditValue.ToString()+"',Code='"+txtmst.Text+"',InvName=N'"+txttcn.Text+"', Note=N'"+txtnote.Text+"' where StockID='" + role + "'";
                stock.checkstock(active, txtcode, txtname, sql, this);
            }
            else
            {
                string sql = "insert into Stock values(newid(),'" + txtcode.Text + "',N'" + txtname.Text + "',N'" + txtdg.Text + "','" + branch + "','','False','"+LPG.Checked.ToString()+"','"+khochinh+"','"+leprovince.EditValue.ToString()+"','"+txtmst+"',N'"+txttcn.Text+"', N'"+txtnote.Text+"',NULL,NULL)";
                stock.checkstock(active, txtcode, txtname, sql, this);
            }*/
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

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}