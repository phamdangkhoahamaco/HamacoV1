using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources; // import bo thu vien cua HAMACO
using System.IO;
using Z.Dapper.Plus;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
//using EntityFramework.BulkInsert;

// tài liệu hd: https://docs.google.com/document/d/1S8h8c42pISc1oWR564a7cL5sGsulZd8caxpg8MfstFA/edit?usp=sharing
// Video: https://youtu.be/2lyyuHUXY_E

namespace HAMACO
{
    public partial class Frm_Transactions : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        string SQLString = "";
        DataTableCollection tables;
        public Frm_Transactions()
        {
            InitializeComponent();
        }

        private void Frm_Transactions_Load(object sender, EventArgs e)
        {
            lblTransactionName.Text = "";
            //txtTransactionCode.MaxLength = 4;
            // txtTransactionCode. = 4;
            lblStatus.Text = "User: " + Globals.username + "; Transaction: SE93";
            toolTip1.SetToolTip(btnNew, "Create");
            toolTip1.SetToolTip(btnEdit, "Edit");
            //toolTip1.SetToolTip(btnDisplay, "Display");
            view_content();
            load_txtTableName();
        }

        private void load_txtTableName()
        {
            DataTable temp2 = new DataTable();
            temp2.Clear();
            temp2.Columns.Add("Table Name");
            var ctx3 = gen.GetNewEntity(); // khai bao new entity Framework
            var query3 = ctx3.TableImports
                .OrderBy(c => c.TableName);
            foreach (var data in query3)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = data.TableName;
                temp2.Rows.Add(dr);
            }
            txtTableName.Properties.DataSource = temp2;
            txtTableName.Properties.DisplayMember = "Table Name";
            txtTableName.Properties.ValueMember = "Table Name";
        }

        private void view_content()
        {
            /*DataTable dt = gen.GetTable("SELECT * FROM Transactions");
            if (dt != null)
            {
                List<Transaction> list = new List<Transaction>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Transaction obj = new Transaction();
                    obj.TransactionCode = dt.Rows[i]["TransactionCode"].ToString();
                    obj.TransactionName = dt.Rows[i]["TransactionName"].ToString();
                    obj.FormName = dt.Rows[i]["FormName"].ToString();
                    obj.SortNo = Int32.Parse(dt.Rows[i]["SortNo"].ToString());
                    obj.IsParent = Int32.Parse(dt.Rows[i]["IsParent"].ToString());
                    obj.ParentFolder = dt.Rows[i]["ParentFolder"].ToString();
                    obj.RoleCode = dt.Rows[i]["RoleCode"].ToString();
                    obj.IsDisplay = Int32.Parse(dt.Rows[i]["IsDisplay"].ToString());
                    //obj.ProcedureName

                    list.Add(obj);
                }*/
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var dt = ctx.Transactions
                .ToList();
            dataGridView1.DataSource = new BindingList<Transaction>(dt);
            //dataGridView1.DataSource = list;
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                lblTransactionName.Text = gen.GetString2("Transactions", "TransactionName", "TransactionCode", txtTransactionCode.Text);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtTransactionCode.Text == "")
            {
                XtraMessageBox.Show("Please enter the transaction code", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string tcode = gen.GetString2("Transactions", "TransactionCode", "TransactionCode", txtTransactionCode.Text);
                if (tcode == "")
                {
                    Frm_TransactionMaintain F = new Frm_TransactionMaintain();
                    F.gettcode(txtTransactionCode.Text);
                    F.getactive("0");
                    F.Show();
                }
                else
                {
                    XtraMessageBox.Show("This transaction is already existed", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTransactionCode.Text == "")
            {
                XtraMessageBox.Show("Please enter the transaction code", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string tcode = gen.GetString2("Transactions", "TransactionCode", "TransactionCode", txtTransactionCode.Text);
                if (tcode != "")
                {
                    Frm_TransactionMaintain F = new Frm_TransactionMaintain();
                    F.gettcode(txtTransactionCode.Text);
                    F.getactive("1");
                    F.Show();
                }
                else
                {
                    XtraMessageBox.Show("This transaction is not existed", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            tables = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tables)
                                cboSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }// end
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            if (txtTableName.Text == "[EditValue is null]")
            {
                MessageBox.Show("Please input the table name");
            }
            else if (txtTableName.Text.Trim() == "Transactions")
            {
                try
                {
                    Insert(dataGridView1.DataSource as List<Transaction>);
                    MessageBox.Show("Finished !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (txtTableName.Text.Trim() == "UserJoinStock")
            {
                try
                {
                    Insert2(dataGridView1.DataSource as List<UserJoinStock>);
                    MessageBox.Show("Finished !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void Insert2(List<UserJoinStock> list)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework
            //EntityHamaco
            DataTable dt = tables[cboSheet.SelectedItem.ToString()];
            foreach (UserJoinStock item in list)
            {
                UserJoinStock obj = new UserJoinStock();
                obj.StockCode = item.StockCode;
                obj.UserName = item.UserName;
                obj.CompanyCode = item.CompanyCode;
                // neu insert bi loi thi update (da ton tai roi thi update)
                try
                {
                    db.UserJoinStocks.Add(obj); //insert  
                    db.SaveChanges();
                }
                catch
                {
                    db.Entry(obj).State = System.Data.Entity.EntityState.Modified; // update
                    db.SaveChanges();
                }
            }

            // insert 
            try
            {

                db.SaveChanges();
                XtraMessageBox.Show("Submit successfully", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //catch (DbUpdateException ex) // exception khac
            catch (DbUpdateConcurrencyException ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtSQL.Text = ex.Message + data + active;
            }
        }
        private void Insert(List<Transaction> list)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework
            //EntityHamaco
            DataTable dt = tables[cboSheet.SelectedItem.ToString()];
            //for (int i = 0; i < list.Count; i++)
            foreach (Transaction item in list)
            {
                Transaction obj = new Transaction();
                obj.TransactionCode = item.TransactionCode;
                obj.TransactionName = item.TransactionName;
                obj.FormName = item.FormName;
                obj.SortNo = item.SortNo;
                obj.IsParent = item.IsParent;
                obj.ParentFolder = item.ParentFolder;
                obj.RoleCode = item.RoleCode;
                obj.IsDisplay = item.IsDisplay;
                // neu insert bi loi thi update (da ton tai roi thi update)
                try
                {
                    db.Transactions.Add(obj); //insert  
                    db.SaveChanges();
                }
                catch
                {
                    db.Entry(obj).State = System.Data.Entity.EntityState.Modified; // update
                    db.SaveChanges();
                }



                //XtraMessageBox.Show(item.TransactionCode, "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // insert 
            try
            {

                db.SaveChanges();
                XtraMessageBox.Show("Submit successfully", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //catch (DbUpdateException ex) // exception khac
            catch (DbUpdateConcurrencyException ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtSQL.Text = ex.Message + data + active;
            }
        }
        private void view_list_transaction(DataTable dt)
        {
            List<Transaction> list = new List<Transaction>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Transaction obj = new Transaction();
                obj.TransactionCode = dt.Rows[i]["TransactionCode"].ToString();
                obj.TransactionName = dt.Rows[i]["TransactionName"].ToString();
                obj.FormName = dt.Rows[i]["FormName"].ToString();
                obj.SortNo = Int32.Parse(dt.Rows[i]["SortNo"].ToString());
                obj.IsParent = Int32.Parse(dt.Rows[i]["IsParent"].ToString());
                obj.ParentFolder = dt.Rows[i]["ParentFolder"].ToString();
                obj.RoleCode = dt.Rows[i]["RoleCode"].ToString();
                obj.IsDisplay = Int32.Parse(dt.Rows[i]["IsDisplay"].ToString());

                list.Add(obj);
            }
            dataGridView1.DataSource = list;
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tables[cboSheet.SelectedItem.ToString()];
            if (dt != null)
            {
                if (txtTableName.Text == "[EditValue is null]")
                {
                    MessageBox.Show("Please input the table name");
                }
                else if (txtTableName.Text.Trim() == "Transactions")
                {
                    view_list_transaction(dt);
                }
                else if (txtTableName.Text.Trim() == "UserJoinStock")
                {
                    view_list_UserJoinStock(dt);
                   // MessageBox.Show(txtTableName.Text);
                }
            }

        }

        private void view_list_UserJoinStock(DataTable dt)
        {
            List<UserJoinStock> list = new List<UserJoinStock>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserJoinStock obj = new UserJoinStock();
                obj.StockCode = dt.Rows[i]["StockCode"].ToString();
                obj.UserName = dt.Rows[i]["UserName"].ToString();
                obj.CompanyCode = dt.Rows[i]["CompanyCode"].ToString();
                list.Add(obj);
            }
            dataGridView1.DataSource = list;
        }
    }   
}