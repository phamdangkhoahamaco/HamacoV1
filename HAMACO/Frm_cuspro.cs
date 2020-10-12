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
    public partial class Frm_cuspro : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        cuspro cuspro = new cuspro();
        string khtemp, ncctemp;
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
        public Frm_cuspro()
        {
            InitializeComponent();
        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void Frm_cuspro_Load(object sender, EventArgs e)
        {
            DataTable da1 = new DataTable();
            da1.Columns.Add("ID", typeof(String));
            da1.Columns.Add("Name", typeof(String));
            DataTable data = new DataTable();            
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

            //clsItem cls;
            DataTable da2 = new DataTable();
            DataTable dapro = new DataTable();
            //dapro = gen.GetTable("select * from Province order by ProvinceName");
            var db2 = gen.GetNewEntity(); // khai bao new entity Framework
            {
                var query = db2.Provinces
                    .Select(p => new { p.ProvinceID, p.ProvinceName })
                    .ToList();
                dapro = gen.ConvertToDataTable(query);
            }
            da2.Columns.Add("ID", Type.GetType("System.String"));
            da2.Columns.Add("Name", Type.GetType("System.String"));
            for (int i = 0; i < dapro.Rows.Count; i++)
            {
                DataRow dr = da2.NewRow();
                dr[0] = dapro.Rows[i][0].ToString();
                dr[1] = dapro.Rows[i][1].ToString();                
                da2.Rows.Add(dr);
            }
           // XtraMessageBox.Show(dapro.Rows.Count + dapro.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            cbprovince.DataSource = da2;
            cbprovince.DisplayMember = "Name";
            cbprovince.ValueMember = "ID";

            if (active == "1")
            {
                this.Text = "Sửa khách hàng, nhà cung cấp";
                txtma.ReadOnly = true;
                DataTable da = new DataTable();
                // da = gen.GetTable("select * from AccountingObject  where AccountingObjectID = '" + role + "'");
                var ctx = gen.GetNewEntity(); // khai bao new entity Framework;
                var stdId = Guid.Parse(role);
                var query = ctx.AccountingObjects
                .Where(c => c.CompanyCode == Globals.companycode && c.AccountingObjectID == stdId)
                .OrderBy(x => x.AccountingObjectName);
                foreach (var data2 in query)
                {
                    txtma.Text = data2.AccountingObjectCode;
                    txttc.Text = data2.AccountingObjectName;
                    txtdc.Text = data2.Address;
                    txtmst.Text = data2.CompanyTaxCode;
                    txtdt.Text = data2.Tel;
                    txtfax.Text = data2.Fax;
                    txtwweb.Text = data2.Website;
                    txtemail.Text = data2.EmailAddress;
                    txttknh.Text = data2.BankAccount;
                    txtnh.Text = data2.BankName;
                    txtdg.Text = data2.Description;
                    txtsntd.Text = data2.MaximizeDebtAmount.ToString();
                    txthn.Text = data2.DueTime.ToString();
                    txttencon.Text = data2.ContactName;
                    txtcdcon.Text = data2.ContactTitle;
                    txtdccon.Text = data2.ContactAddress;
                    txtdtcq.Text = data2.ContactOfficeTel;
                    txtdtnr.Text = data2.ContactHomeTel;
                    txtdtdd.Text = data2.ContactMobile;
                    txtemailcon.Text = data2.ContactEmail;
                    txtscmnd.Text = data2.IdentificationNumber;
                    try
                    {
                        dateTimePicker1.Value = Convert.ToDateTime(data2.IssueDate);
                    }
                    catch { }
                    if (data2.IsVendor == data2.IsCustomer)
                    {
                        rbkhncc.Checked = true;
                        khtemp = "True";
                        ncctemp = "True";
                    }
                    else
                    {
                        rbncc.Checked = (bool)data2.IsVendor;
                        rbkh.Checked = (bool)data2.IsCustomer;
                        ncctemp = data2.IsVendor.ToString();
                        khtemp = data2.IsCustomer.ToString();
                    }
                    chbntd.Checked = (bool)data2.Inactive;
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (data2.BranchID == Guid.Parse(data.Rows[i][0].ToString()))
                            cbbranch.SelectedIndex = i;
                    }
                    if (data2.IsPersonal == true)
                        rbcn.Checked = true;
                    for (int i = 0; i < dapro.Rows.Count; i++)
                    {
                        if (data2.Province == dapro.Rows[i][0].ToString())
                            cbprovince.SelectedIndex = i;
                    }
                    for (int i = 0; i < cbdistrist.Items.Count; i++)
                    {
                        clsItem cls1 = (clsItem)cbdistrist.Items[i];
                        string tt = cls1.PstrValue;
                        if (data2.District == tt)
                            cbdistrist.SelectedIndex = i;
                    }
                }                             
            }
            else
            {
                this.Text = "Thêm khách hàng, nhà cung cấp";
                rbkhncc.Checked = true;
                rbtc.Checked = true;
            }
        }


        private void txtsntd_TextChanged(object sender, EventArgs e)
        {
            txtsntd.Text = string.Format("{0:0,0}", decimal.Parse(txtsntd.Text));
            txtsntd.SelectionStart = txtsntd.Text.Length;
        }

        private void txtsntd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txthn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void rbcn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcn.Checked == true)
            {
                label17.Hide();
                label18.Hide();
                txttencon.Hide();
                txtcdcon.Hide();
                txtdccon.Hide();
                txtemailcon.Hide();
                label12.Hide();
                txtdt.Hide();
                label19.Hide();
                label26.Hide();
                label13.Hide();
                txtfax.Hide();
                label4.Hide();
                txtmst.Hide();
            }
        }

        private void rbtc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtc.Checked == true)
            {
                label17.Show();
                label18.Show();
                txttencon.Show();
                txtcdcon.Show();
                txtdccon.Show();
                txtemailcon.Show();
                label12.Show();
                txtdt.Show();
                label19.Show();
                label26.Show();
                label13.Show();
                txtfax.Show();
                label4.Show();
                txtmst.Show();
            }
        }

        private void cbprovince_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbdistrist.Items.Clear();
            cbdistrist.Text = "";
            clsItem cls1 = (clsItem)cbprovince.SelectedItem;
            string tt = cls1.PstrValue;
            clsItem cls;
            DataTable dapro = new DataTable();
            dapro = gen.GetTable("select * from Distrist where ProvinceID='" + tt + "'  order by DistristName");
            for (int i = 0; i < dapro.Rows.Count; i++)
            {
                cls = new clsItem(dapro.Rows[i][0].ToString(), dapro.Rows[i][2].ToString());
                cbdistrist.Items.Add(cls);
            }
            cbdistrist.DisplayMember = "PstrName";
            cbdistrist.ValueMember = "PstrValue";
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            string code = txtma.Text;
            string name = txttc.Text.Replace("'", "''");
            string branch = cbbranch.SelectedValue.ToString(); // branchID
            //string branchID = gen.GetString("select BranchID from Branch where BranchCode='" + branch + "'");
            string dc = txtdc.Text.Replace("'", "''");
            string mst = txtmst.Text;
            string dt = txtdt.Text;
            string fax = txtfax.Text;
            

            string web = txtwweb.Text;

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
            string dg = txtdg.Text;
            string sntd = txtsntd.Text;
            string hn = txthn.Text;
            string tinh, quan;
            try
            {
                clsItem cls1 = (clsItem)cbprovince.SelectedItem;
                tinh = cls1.PstrValue;
            }
            catch { tinh = ""; }
            try
            {
                clsItem cls2 = (clsItem)cbdistrist.SelectedItem;
                quan = cls2.PstrValue;
            }
            catch { quan = ""; }
            string tencon = txttencon.Text.Replace("'", "''");
            string chucdanh = txtcdcon.Text;
            string dccon = txtdccon.Text.Replace("'", "''");
            string cmnd = txtscmnd.Text;
            DateTime ngaycap = dateTimePicker1.Value;
            string noicap = txtnccon.Text;
            string dtcq = txtdtcq.Text;
            string dtnr = txtdtnr.Text;
            string dtdd = txtdtdd.Text;
            string emailcon = txtemailcon.Text;
            string kh, ncc;

            if (rbkhncc.Checked == true)
            {
                kh = "True";
                ncc = "True";
            }
            else
            {
                kh = rbkh.Checked.ToString();
                ncc = rbncc.Checked.ToString();
            }

            string person = rbcn.Checked.ToString();
            string ntd = chbntd.Checked.ToString();

            string khncc;
            if (rbkhncc.Checked == true)
            {
                khncc = "Khách hàng; Nhà cung cấp";
            }
            else
            {
                if (rbncc.Checked == true)
                    khncc = "Nhà cung cấp";
                else
                    khncc = "Khách hàng";
            }
            

            if (txtma.Text == "") MessageBox.Show("Mã khách hàng, nhà cung cấp không được bỏ trống.", "HAMACO");
            else if (txttc.Text == "") MessageBox.Show("Tên khách hàng, nhà cung cấp không được bỏ trống.", "HAMACO");
            /*else
            {
                if (active == "1")
                {
                    try
                    {
                        string kq = gen.GetString("select * from hamaco.dbo.AccountingObject where CompanyTaxCode='" + txtmst.Text + "' and CompanyTaxCode<>'' and AccountingObjectCode<>'" + txtma.Text + "'");
                        MessageBox.Show("Mã số thuế này đã tồn tại. Vui lòng kiểm tra lại.", "Thông báo");
                        return;
                    }
                    catch
                    {
                        gen.ExcuteNonquery("update hamaco.dbo.AccountingObject set AccountingObjectName=N'" + name + "',BranchID='" + branchID + "',Address=N'" + dc + "',Tel='" + dt + "',Fax='" + fax + "',EmailAddress='" + email + "',Website=N'" + web + "',BankAccount='" + tknh + "',BankName=N'" + tnh + "',CompanyTaxCode='" + mst + "',Description=N'" + dg + "',ContactName=N'" + tencon + "',ContactTitle=N'" + chucdanh + "',ContactMobile='" + dtdd + "',ContactEmail='" + emailcon + "',ContactOfficeTel='" + dtcq + "',ContactHomeTel='" + dtnr + "',ContactAddress=N'" + dccon + "',IsPersonal='" + person + "',IdentificationNumber='" + cmnd + "',IssueDate='" + ngaycap + "',IssueBy=N'" + noicap + "',Inactive='" + ntd + "',DueTime='" + hn + "',MaximizeDebtAmount='" + sntd + "',IsVendor='" + ncc + "',IsCustomer='" + kh + "',Province='" + tinh + "',District='" + quan + "',AccountingObjectCategory=N'" + khncc + "',Village=N'" + cbprovince.Text + "' where AccountingObjectCode='" + txtma.Text + "'");
                        gen.ExcuteNonquery("update hamaco_ta.dbo.AccountingObject set AccountingObjectName=N'" + name + "',BranchID='" + branchID + "',Address=N'" + dc + "',Tel='" + dt + "',Fax='" + fax + "',EmailAddress='" + email + "',Website=N'" + web + "',BankAccount='" + tknh + "',BankName=N'" + tnh + "',CompanyTaxCode='" + mst + "',Description=N'" + dg + "',ContactName=N'" + tencon + "',ContactTitle=N'" + chucdanh + "',ContactMobile='" + dtdd + "',ContactEmail='" + emailcon + "',ContactOfficeTel='" + dtcq + "',ContactHomeTel='" + dtnr + "',ContactAddress=N'" + dccon + "',IsPersonal='" + person + "',IdentificationNumber='" + cmnd + "',IssueDate='" + ngaycap + "',IssueBy=N'" + noicap + "',Inactive='" + ntd + "',DueTime='" + hn + "',MaximizeDebtAmount='" + sntd + "',IsVendor='" + ncc + "',IsCustomer='" + kh + "',Province='" + tinh + "',District='" + quan + "',AccountingObjectCategory=N'" + khncc + "',Village=N'" + cbprovince.Text + "' where AccountingObjectCode='" + txtma.Text + "'");
                        gen.ExcuteNonquery("update hamaco_tn.dbo.AccountingObject set AccountingObjectName=N'" + name + "',BranchID='" + branchID + "',Address=N'" + dc + "',Tel='" + dt + "',Fax='" + fax + "',EmailAddress='" + email + "',Website=N'" + web + "',BankAccount='" + tknh + "',BankName=N'" + tnh + "',CompanyTaxCode='" + mst + "',Description=N'" + dg + "',ContactName=N'" + tencon + "',ContactTitle=N'" + chucdanh + "',ContactMobile='" + dtdd + "',ContactEmail='" + emailcon + "',ContactOfficeTel='" + dtcq + "',ContactHomeTel='" + dtnr + "',ContactAddress=N'" + dccon + "',IsPersonal='" + person + "',IdentificationNumber='" + cmnd + "',IssueDate='" + ngaycap + "',IssueBy=N'" + noicap + "',Inactive='" + ntd + "',DueTime='" + hn + "',MaximizeDebtAmount='" + sntd + "',IsVendor='" + ncc + "',IsCustomer='" + kh + "',Province='" + tinh + "',District='" + quan + "',AccountingObjectCategory=N'" + khncc + "',Village=N'" + cbprovince.Text + "' where AccountingObjectCode='" + txtma.Text + "'");
                        gen.ExcuteNonquery("update hamaco_vithanh.dbo.AccountingObject set AccountingObjectName=N'" + name + "',BranchID='" + branchID + "',Address=N'" + dc + "',Tel='" + dt + "',Fax='" + fax + "',EmailAddress='" + email + "',Website=N'" + web + "',BankAccount='" + tknh + "',BankName=N'" + tnh + "',CompanyTaxCode='" + mst + "',Description=N'" + dg + "',ContactName=N'" + tencon + "',ContactTitle=N'" + chucdanh + "',ContactMobile='" + dtdd + "',ContactEmail='" + emailcon + "',ContactOfficeTel='" + dtcq + "',ContactHomeTel='" + dtnr + "',ContactAddress=N'" + dccon + "',IsPersonal='" + person + "',IdentificationNumber='" + cmnd + "',IssueDate='" + ngaycap + "',IssueBy=N'" + noicap + "',Inactive='" + ntd + "',DueTime='" + hn + "',MaximizeDebtAmount='" + sntd + "',IsVendor='" + ncc + "',IsCustomer='" + kh + "',Province='" + tinh + "',District='" + quan + "',AccountingObjectCategory=N'" + khncc + "',Village=N'" + cbprovince.Text + "' where AccountingObjectCode='" + txtma.Text + "'");
                        //gen.ExcuteNonquery("update hamaco_qlk.dbo.AccountingObject set AccountingObjectName=N'" + name + "',BranchID='" + branchID + "',Address=N'" + dc + "',Tel='" + dt + "',Fax='" + fax + "',EmailAddress='" + email + "',Website=N'" + web + "',BankAccount='" + tknh + "',BankName=N'" + tnh + "',CompanyTaxCode='" + mst + "',Description=N'" + dg + "',ContactName=N'" + tencon + "',ContactTitle=N'" + chucdanh + "',ContactMobile='" + dtdd + "',ContactEmail='" + emailcon + "',ContactOfficeTel='" + dtcq + "',ContactHomeTel='" + dtnr + "',ContactAddress=N'" + dccon + "',IsPersonal='" + person + "',IdentificationNumber='" + cmnd + "',IssueDate='" + ngaycap + "',IssueBy=N'" + noicap + "',Inactive='" + ntd + "',DueTime='" + hn + "',MaximizeDebtAmount='" + sntd + "',IsVendor='" + ncc + "',IsCustomer='" + kh + "',Province='" + tinh + "',District='" + quan + "',AccountingObjectCategory=N'" + khncc + "',Village=N'" + cbprovince.Text + "' where AccountingObjectCode='" + txtma.Text + "'");
                        this.myac();
                        this.Close();
                    }                    
                }
                else
                {
                    try
                    {
                        string kq = gen.GetString("select * from hamaco.dbo.AccountingObject where CompanyTaxCode='" + txtmst.Text + "' and CompanyTaxCode<>''");
                        MessageBox.Show("Mã số thuế này đã tồn tại. Vui lòng kiểm tra lại.", "Thông báo");
                        return;
                    }
                    catch
                    {
                        string nv = "False";
                        string insu = "False";
                        string labe = "False";
                        string sql = "insert into hamaco.dbo.AccountingObject(AccountingObjectID,AccountingObjectCode,AccountingObjectName,BranchID,Address,Tel,Fax,EmailAddress,Website,BankAccount,BankName,CompanyTaxCode,Description,ContactName,ContactTitle,ContactMobile,ContactEmail,ContactOfficeTel,ContactHomeTel,ContactAddress,IsPersonal,IdentificationNumber,IssueDate,IssueBy,Inactive,DueTime,MaximizeDebtAmount,IsVendor,IsCustomer,Province,District,IsEmployee,Insured,LabourUnionFee,FamilyDeductionAmount,AccountingObjectCategory,Village)  values(newid(),'" + code + "',N'" + name + "','" + branchID + "',N'" + dc + "','" + dt + "','" + fax + "','" + email + "',N'" + web + "','" + tknh + "',N'" + tnh + "','" + mst + "',N'" + dg + "',N'" + tencon + "',N'" + chucdanh + "','" + dtdd + "','" + emailcon + "','" + dtcq + "','" + dtnr + "',N'" + dccon + "','" + person + "','" + cmnd + "','" + ngaycap + "',N'" + noicap + "','" + ntd + "','" + hn + "','" + sntd + "','" + ncc + "','" + kh + "','" + tinh + "','" + quan + "','" + nv + "','" + insu + "','" + labe + "','0',N'" + khncc + "',N'" + cbprovince.Text + "')";
                        cuspro.checkcuspro(active, txtma, txttc, sql, this);
                    }
                }
                if (active == "1")
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa mã khách','" + txtma.Text + "')");
                else
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm mã khách','" + txtma.Text + "')");
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
            //data.BranchID = Guid.Parse(branch);

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
            data.IsEmployee = false;
            data.IdentificationNumber = cmnd;
            data.IssueDate = ngaycap;
            data.ContactTitle = chucdanh;
            data.IssueBy = noicap;

            data.Tel = txtdt.Text; 
            data.Fax = txtfax.Text;
            data.Website = txtwweb.Text;
            
            data.Description = txtdg.Text;
            try {
                data.MaximizeDebtAmount = Int32.Parse(txtsntd.Text);
                data.DueTime = Int32.Parse(txthn.Text);
            } catch
            {

            }
            
            data.ContactName = txttencon.Text;
            
            data.ContactAddress = txtdccon.Text;
            data.ContactEmail = txtemailcon.Text;            

            data.Inactive = chbntd.Checked;            
            if (rbkhncc.Checked == true)
            {
                data.IsCustomer = true;
                data.IsVendor = true;
            }
            else
            {
                if (rbncc.Checked == true)
                    data.IsVendor = true;
                else
                    data.IsCustomer = true;
            }
            try
            {
                //data.BranchID = Guid.Parse(cbbranch.Text);
                data.BranchID = Guid.Parse(branch);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message + active, "branch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            data.Inactive = chbntd.Checked;
            data.IsPersonal = rbcn.Checked;
            data.Province = tinh;
            data.District = quan;            

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
                  //  txtSQL.Text = ex.Message + data + active;
                }
            }
        }

        private void rbkhncc_CheckedChanged(object sender, EventArgs e)
        {
            if (active == "1" && rbkhncc.Checked == false)
            {
                if (khtemp == ncctemp)
                {
                    if (rbkh.Checked == true)
                    {
                        MessageBox.Show("Bạn không thể chuyển từ < khách hàng - nhà cung cấp > sang < khách hàng >");
                        rbkhncc.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("Bạn không thể chuyển từ < khách hàng - nhà cung cấp > sang < nhà cung cấp >");
                        rbkhncc.Checked = true;
                    }
                }
            }
        }

        private void rbkh_CheckedChanged(object sender, EventArgs e)
        {
            if (active == "1" && khtemp == "True" && rbncc.Checked == true)
            {
                MessageBox.Show("Bạn không thể chuyển từ < khách hàng > sang < nhà cung cấp >");
                rbkh.Checked = true;
            }
        }

        private void rbncc_CheckedChanged(object sender, EventArgs e)
        {
            if (active == "1" && ncctemp == "True" && rbkh.Checked == true)
            {
                MessageBox.Show("Bạn không thể chuyển từ < nhà cung cấp > sang < khách hàng >");
                rbncc.Checked = true;
            }
        }

        private void rbkhncc_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}