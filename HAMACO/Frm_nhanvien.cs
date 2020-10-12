using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using System.Threading;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace HAMACO
{
    public partial class Frm_nhanvien : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        nhanvien nhanvien = new nhanvien();
        string tag;
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
        public Frm_nhanvien()
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

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Frm_nhanvien_Load(object sender, EventArgs e)
        {
            DataTable da1 = new DataTable();
            da1.Columns.Add("ID", typeof(String));
            da1.Columns.Add("Name", typeof(String));
            DataTable data = new DataTable();
            //data = gen.GetTable("select branchCode, branchName,branchID from Branch");
            var db= gen.GetNewEntity(); // khai bao new entity Framework
            {
                var query = db.Branches
                    .Where(p => p.CompanyCode == Globals.companycode)
                    .Select(p => new { p.BranchID, p.BranchName })
                    .ToList();
                data = gen.ConvertToDataTable(query);
            }

            for (int i = 0; i < data.Rows.Count; i++)
            {
                da1.Rows.Add(new String[] { data.Rows[i][0].ToString(), data.Rows[i][1].ToString() });                
            }
            cbbranch.DataSource = da1;
            cbbranch.DisplayMember = "Name";
            cbbranch.ValueMember = "ID";

            rbmale.Checked = true;
            if (active == "1")
            {
                this.Text = "Sửa nhân viên";
                txtma.ReadOnly = true;
                DataTable da = new DataTable();
                var ctx = gen.GetNewEntity(); // khai bao new entity Framework;
                var stdId = Guid.Parse(role);
                var query = ctx.AccountingObjects
                    .Join(ctx.Branches, a => a.BranchID, b => b.BranchID,
                    (a, b) => new {
                        a.AccountingObjectID, a.AccountingObjectCode, a.AccountingObjectName,
                        a.Inactive, b.BranchName,
                        a.CompanyCode,
                        a.IsEmployee, a.ContactSex, a.EmployeeBirthday, a.IssueDate, a.CompanyTaxCode, a.IdentificationNumber, a.IssueBy,
                        a.FamilyDeductionAmount, a.SalaryScaleID, a.BankAccount, a.BankName, a.Address, a.ContactAddress, a.ContactHomeTel,
                        a.ContactMobile, a.ContactEmail, a.ContactTitle, a.IsCustomer, a.IsVendor, a.IsPersonal, a.BranchID
                    }
                    )
                    .Where(c =>c.CompanyCode == Globals.companycode && c.AccountingObjectID == stdId)
                    .OrderBy(x => new { x.BranchName, x.AccountingObjectName });

                //da = gen.GetTable("select * from AccountingObject  where AccountingObjectID = '" + role + "'");
                foreach (var data2 in query)
                {
                    txtma.Text = data2.AccountingObjectCode;
                    txtname.Text = data2.AccountingObjectName;
                    if(data2.ContactSex == 0) rbfemale.Checked = true;
                    try
                    {
                        dtborn.Value = Convert.ToDateTime(data2.EmployeeBirthday);
                    }
                    catch { }
                    try
                    {
                        dtngaycap.Value = Convert.ToDateTime(data2.IssueDate);
                    }
                    catch { }
                    txtmst.Text = data2.CompanyTaxCode;
                    txtcmnd.Text = data2.IdentificationNumber;
                    txtnoicap.Text = data2.IssueBy;
                    txtgtgc.Text = data2.FamilyDeductionAmount.ToString();
                    try
                    {
                        string[] s = data2.SalaryScaleID.ToString().Split('.');
                        txthsl.Text = s[0] + "." + s[1].Substring(0, 4);
                    }
                    catch { }
                    txttknh.Text = data2.BankAccount;
                    txtnh.Text = data2.BankName;
                    txtdc.Text = data2.Address;
                    txtdtcq.Text = data2.ContactAddress;
                    txtdtnr.Text = data2.ContactHomeTel;
                    txtdtdd.Text = data2.ContactMobile;
                    txtemail.Text = data2.ContactEmail;
                    txtcv.Text = data2.ContactTitle;
                    chbkh.Checked = (bool)data2.IsCustomer;
                    chncc.Checked = (bool)data2.IsVendor;
                    chbntd.Checked = (bool)data2.IsPersonal;
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (data2.BranchID == Guid.Parse(data.Rows[i][0].ToString()))
                            cbbranch.SelectedIndex = i;
                    }
                }             
                                         

                

            }

        }

        private void txthsl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] s;
                s = txthsl.Text.Split('.');
                if ((int)s[1].Length > 4)
                {
                    txthsl.Text = s[0] + '.' + tag;
                    txthsl.SelectionStart = txthsl.Text.Length;
                }
            }
            catch { }
        }

        private void txthsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string[] s = txthsl.Text.Split('.');
                tag = s[1].ToString();
            }
            catch { }
            string decimalString = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            char decimalChar = Convert.ToChar(decimalString);
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) { }
            else if (e.KeyChar.ToString() == decimalString && txthsl.Text.IndexOf(decimalString) == -1) { }
            else
            {
                e.Handled = true;
            }
        }

        private void txtgtgc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtgtgc.Text = string.Format("{0:0,0}", decimal.Parse(txtgtgc.Text));
                txtgtgc.SelectionStart = txtgtgc.Text.Length;
            }
            catch { }
        }
        private void txtgtgc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            string code = txtma.Text;
            string name = txtname.Text.Replace("'","''");
            string branch = cbbranch.SelectedValue.ToString();
            //string branchID = gen.GetString("select BranchID from Branch where BranchCode='" + branch + "'");
            string dc = txtdc.Text.Replace("'", "''");
            string mst = txtmst.Text;
            string email = txtemail.Text;
            if (txtemail.Text != "")
                try
                {
                    gen.GetString("select * from AccountingObject where AccountingObjectCode='" + txtemail.Text + "'");
                }
                catch
                {
                    XtraMessageBox.Show("Mã khách phụ không tồn tại vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            string tknh = txttknh.Text;
            string tnh = txtnh.Text;
            string chucdanh = txtcv.Text;
            string cmnd = txtcmnd.Text;
            DateTime ngaycap = dtngaycap.Value;
            DateTime ngaysinh = dtborn.Value;
            string noicap = txtnoicap.Text;
            string dtcq = txtdtcq.Text;
            string dtnr = txtdtnr.Text;
            string dtdd = txtdtdd.Text;
            string kh = chbkh.Checked.ToString();
            string ncc = chncc.Checked.ToString();
            string person = "True";
            string ntd = chbntd.Checked.ToString();
            string sex;
            string hsl = txthsl.Text;
            if (txthsl.Text == "")
                hsl = "0";
            string gtgc = txtgtgc.Text.Replace(",", ".");
            if (rbfemale.Checked == true) sex = "0";
            else sex = "1";

            /*if (active == "1")
            {
                string sql = "update AccountingObject set AccountingObjectName=N'" + name + "',BranchID='" + branchID + "',ContactSex='" + sex + "',
                EmployeeBirthday='" + ngaysinh + "',Address=N'" + dc + "',EmailAddress='" + email + "',BankAccount='" + tknh + "',BankName='" + tnh + "',
                CompanyTaxCode='" + mst + "',ContactTitle=N'" + chucdanh + "',ContactMobile='" + dtdd + "',ContactOfficeTel='" + dtcq + "',
                ContactHomeTel='" + dtnr + "',IsPersonal='" + person + "',IdentificationNumber='" + cmnd + "',IssueDate='" + ngaycap + "',
                IssueBy='" + noicap + "',Inactive='" + ntd + "',IsVendor='" + ncc + "',IsCustomer='" + kh + "',FamilyDeductionAmount='" + gtgc + "',SalaryScaleID='" + hsl + "' where AccountingObjectID='" + role + "'";
                nhanvien.checknhanvien(active, txtma, txtname, sql, this);
            }
            else
            {
                string nv = "True";
                string insu = "False";
                string labe = "False";
                //string sql = "insert into AccountingObject(AccountingObjectID,AccountingObjectCode,AccountingObjectName,BranchID,Address,EmailAddress,BankAccount,BankName,CompanyTaxCode,ContactTitle,ContactMobile,ContactOfficeTel,ContactHomeTel,IsPersonal,IdentificationNumber,IssueDate,IssueBy,Inactive,IsVendor,IsCustomer,IsEmployee,Insured,LabourUnionFee,FamilyDeductionAmount,AccountingObjectCategory,ContactSex,EmployeeBirthday,SalaryScaleID)  values(newid(),'" + code + "',N'" + name + "','" + branchID + "',N'" + dc + "','" + email + "','" + tknh + "','" + tnh + "','" + mst + "',N'" + chucdanh + "','" + dtdd + "','" + dtcq + "','" + dtnr + "','" + person + "','" + cmnd + "','" + ngaycap + "','" + noicap + "','" + ntd + "','" + ncc + "','" + kh + "','" + nv + "','" + insu + "','" + labe + "','" + gtgc + "','','" + sex + "','" + ngaysinh + "','" + hsl + "')";
                //nhanvien.checknhanvien(active, txtma, txtname, sql, this);               
            }*/
            AccountingObject data = new AccountingObject();
            if (active == "0")
            {
                data.AccountingObjectID = Guid.NewGuid();// tao guiid moi
            }
            else
            {
                data.AccountingObjectID = Guid.Parse(role); ;
            }
            //data.ClientID = Globals.clientid;
            data.CompanyCode = Globals.companycode;
            data.AccountingObjectCode = code;
            data.AccountingObjectName = name;
            data.BranchID = Guid.Parse(branch);
            data.ContactSex = Int32.Parse(sex);
            data.EmployeeBirthday = ngaysinh;
            data.Address = dc;
            data.EmailAddress = email;
            data.BankAccount = tknh;
            data.BankName = tnh;
            data.CompanyTaxCode = mst;
            data.ContactTitle = chucdanh;
            data.ContactMobile = dtdd;
            
            data.ContactOfficeTel = dtcq;
            data.ContactHomeTel = dtnr;
            data.IsPersonal = true;
            data.IsEmployee = true;
            data.IdentificationNumber = cmnd;
            data.IssueDate = ngaycap;
            data.ContactTitle = chucdanh;
            data.IssueBy = noicap;
            
            data.Inactive = chbntd.Checked;
            data.IsVendor = chncc.Checked;
            data.IsCustomer = chbkh.Checked;
            try
            {
                data.FamilyDeductionAmount = Int32.Parse(gtgc);
                data.SalaryScaleID = Int32.Parse(hsl);
            }
            catch
            {

            }
            
            
            
            var db= gen.GetNewEntity(); // khai bao new entity Framework
                {
                    try
                    {
                        if (active == "0") db.AccountingObjects.Add(data); //insert
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
                }
                            

            //lvpq.DataSource = data ;
            //txtSQL.Text = data.AccountingObjectID + data.AccountingObjectCode;

        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
 