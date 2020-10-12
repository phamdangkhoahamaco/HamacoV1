using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_account : DevExpress.XtraEditors.XtraForm
    {

        gencon gen = new gencon();
        account account = new account();
        int lop = 0;
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
        public Frm_account()
        {
            InitializeComponent();
        }

        private void Frm_account_Load(object sender, EventArgs e)
        {
            DataTable da = new DataTable();
            da.Columns.Add("ID", typeof(String));
            da.Columns.Add("Name", typeof(String));
            DataTable data = new DataTable();
            data = gen.GetTable("select AccountCategoryID, AccountCategoryName from AccountCategory ");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                da.Rows.Add(new String[] { data.Rows[i][0].ToString(), data.Rows[i][1].ToString() });
            }
            cbntk.DataSource = da;
            cbntk.DisplayMember = "ID";
            cbntk.ValueMember = "ID";

            DataTable da1 = new DataTable();
            da1.Columns.Add("ID", typeof(String));
            da1.Columns.Add("Name", typeof(String));
            data.Clear();
            data = gen.GetTable("select AccountNumber, AccountName,AccountID from Account order by AccountNumber");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                da1.Rows.Add(new String[] { data.Rows[i][0].ToString(), data.Rows[i][1].ToString() });
            }
            cbtkth.DataSource = da1;
            cbtkth.DisplayMember = "ID";
            cbtkth.ValueMember = "ID";

            clsItem cls;
            cls = new clsItem("0", "Dư nợ");
            cbtc.Items.Add(cls);
            cls = new clsItem("1", "Dư có");
            cbtc.Items.Add(cls);
            cls = new clsItem("2", "Lưỡng tính");
            cbtc.Items.Add(cls);
            cls = new clsItem("3", "Không có số dư");
            cbtc.Items.Add(cls);
            cbtc.DisplayMember = "PstrName";
            cbtc.ValueMember = "PstrValue";


            clsItem cls1;
            cls1 = new clsItem("0", "Nhà cung cấp");
            cbdt.Items.Add(cls1);
            cls1 = new clsItem("1", "Khách hàng");
            cbdt.Items.Add(cls1);
            cls1 = new clsItem("2", "Nhân viên");
            cbdt.Items.Add(cls1);
            cbdt.DisplayMember = "PstrName";
            cbdt.ValueMember = "PstrValue";


            clsItem cls2;
            cls2 = new clsItem("1", "Chi phí nhân sự");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("2", "Chi phi khấu hao TSCĐ");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("3", "Chi phí nhiên liệu");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("4", "Chi phí thuê phương tiện ");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("5", "Chi phí cầu phà, bến bãi, đường bộ");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("6", "Chi phí bốc xếp");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("7", "Chi phí phân bổ CCDC");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("8", "Chi phí bảo trì và sửa chữa phương tiện vận chuyển");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("9", "Chi phí vận chuyển khác");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("10", "Chi phí quà tặng khách hàng");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("11", "Chi phí thuê đất, văn phòng làm việc");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("12", "Chi phí tiếp khách");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("13", "Chi phí điện");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("14", "Chi phí nước");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("15", "Chi phí điện thoại");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("16", "Phí dịch vụ bảo vệ");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("17", "Chi phí văn phòng phẩm");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("18", "Chi phí công tác ");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("19", "Chi phí chuyển tiền");
            cbnhomcp.Items.Add(cls2);
            cls2 = new clsItem("20", "Chi phí khác");
            cbnhomcp.Items.Add(cls2);           
            cbnhomcp.DisplayMember = "PstrName";
            cbnhomcp.ValueMember = "PstrValue";

            DataTable da2 = new DataTable();
            da2 = gen.GetTable("select * from Account where AccountID='" + role + "'");
            
            cbtc.SelectedIndex = (int)da2.Rows[0][8];
            try
            {
                cbnhomcp.SelectedIndex = (int)da2.Rows[0][19]-1;
            }
            catch { }


            for (int i = 0; i < da.Rows.Count; i++)
            {
                if (da2.Rows[0][7].ToString() == da.Rows[i][0].ToString())
                {
                    cbntk.SelectedIndex = i;
                }
            }
            txtten.Text = da2.Rows[0][2].ToString();
            txttta.Text = da2.Rows[0][17].ToString();
            txtdg.Text = da2.Rows[0][3].ToString();
            if (da2.Rows[0][15].ToString() == "")
                cbdt.SelectedIndex = -1;
            else
                cbdt.SelectedIndex = (int)da2.Rows[0][15];

            chbdt.Checked = (bool)da2.Rows[0][9];
            cbdt.Enabled = (bool)da2.Rows[0][9];
            chbcp.Checked = (bool)da2.Rows[0][11];
            chbhd.Checked = (bool)da2.Rows[0][12];
            chbvthh.Checked = (bool)da2.Rows[0][10];
            chtknh.Checked = (bool)da2.Rows[0][16];
            chbctnt.Checked = (bool)da2.Rows[0][14];
            lop = (int)da2.Rows[0][5] + 1;
            if (da2.Rows[0][13].ToString() == "True")
                chbntd.Checked = true;
            else
                chbntd.Checked = false;
            if (da2.Rows[0][18].ToString() == "True")
                cbtonquy.Checked = true;
            else
                cbtonquy.Checked = false;

            int ch = 0;
            for (int i = 9; i < 17; i++)
            {
                if (da2.Rows[0][i].ToString() == "True" && i != 13) ch = 1;
            }
            if (ch == 0)
            {
                chbct.Checked = true;
                chbct.Checked = false;
            }
            else chbct.Checked = true;

            if (active == "1")
            {
                this.Text = "Sửa tài khoản";
                txtstk.ReadOnly = true;
                txtstk.Text = da2.Rows[0][1].ToString();
                if (da2.Rows[0][6].ToString() == "True")
                {
                    cbtkth.Enabled = false;
                    cbtkth.SelectedIndex = -1;
                }

                if (da2.Rows[0][4].ToString() == "")
                {
                    cbtkth.SelectedIndex = -1;
                }
                else
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (da2.Rows[0][4].ToString() == data.Rows[i][2].ToString())
                        {
                            cbtkth.SelectedIndex = i;
                        }
                    }
                }
            }
            else
            {
                this.Text = "Thêm tài khoản";
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (da2.Rows[0][1].ToString() == data.Rows[i][0].ToString())
                    {
                        cbtkth.SelectedIndex = i;
                    }
                }
                txtstk.Text = cbtkth.SelectedValue.ToString();
                chbntd.Hide();
            }
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            string tkth = "";
            string stk = txtstk.Text;
            string name = txtten.Text;
            string namee = txttta.Text;
            string ntk = cbntk.SelectedValue.ToString();
            string dg = txtdg.Text;
            string ntd = chbntd.Checked.ToString();
            string tonquy = cbtonquy.Checked.ToString();

            clsItem cls2 = (clsItem)cbnhomcp.SelectedItem;
            string nhom = "0";
            if (cbnhomcp.Text != "")
                nhom = cls2.PstrValue;

            clsItem cls1 = (clsItem)cbtc.SelectedItem;
            string tc = cls1.PstrValue;

            clsItem cls = (clsItem)cbdt.SelectedItem;
            string dt = cls.PstrValue;

            string chdt = chbdt.Checked.ToString();
            string chcp = chbcp.Checked.ToString();
            string chhd = chbhd.Checked.ToString();
            string vthh = chbvthh.Checked.ToString();
            string tknh = chtknh.Checked.ToString();
            string ctnt = chbctnt.Checked.ToString();
            string sql;

            //update kieu moi                                    
            Account data = new Account();// lop Account
            if (active == "0")
            {
                data.AccountID = Guid.NewGuid();// tao guiid moi
            }
            else
            {
                data.AccountID = Guid.Parse(role);
            }
            // AccountingObjectType='" + dt + "',DetailByBankAccount='" + tknh + "',Exits='" + tonquy + "',GroupCost='" + nhom + "' where AccountNumber='" + stk + "'";
            data.AccountName = name;
            data.AccountNameEnglish = namee;
            data.Description = dg;
            data.AccountCategoryID = ntk;
            data.AccountCategoryKind = Int32.Parse(tc);
            data.DetailByAccountingObject = chbdt.Checked;
            data.DetailByInventoryItem = chbvthh.Checked;
            data.DetailByJob = chbcp.Checked;
            data.DetailByContract = chbhd.Checked;
            data.Inactive = chbntd.Checked;
            data.DetailByForeignCurrency = chbctnt.Checked;

            data.AccountingObjectType = Int32.Parse(dt);
            data.DetailByBankAccount = chtknh.Checked;
            data.Exits = cbtonquy.Checked;
            data.GroupCost = Int32.Parse(nhom);
            data.AccountNumber = stk;

            var db= gen.GetNewEntity(); // khai bao new entity Framework
            {
                try
                {
                    if (active == "0") db.Accounts.Add(data); //insert
                    else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update
                    db.SaveChanges();
                    XtraMessageBox.Show("Submit successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //catch (DbUpdateException ex) // exception khac
                catch (DbUpdateConcurrencyException ex) // exception khac
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message + active, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtSQL.Text = ex.Message + data + active;
                }

            }
            /*
            if (active == "1")
            {

                try
                {
                    tkth = cbtkth.SelectedValue.ToString();
                    sql = "update Account set AccountName=N'" + name + "',AccountNameEnglish=N'" + namee + "',Description=N'" + dg + "',AccountCategoryID='" + ntk + "',AccountCategoryKind='" + tc + "',DetailByAccountingObject='" + chdt + "',DetailByInventoryItem='" + vthh + "',DetailByJob='" + chcp + "',DetailByContract='" + chhd + "',Inactive='" + ntd + "',DetailByForeignCurrency='" + ctnt + "',AccountingObjectType='" + dt + "',DetailByBankAccount='" + tknh + "',Exits='" + tonquy + "',GroupCost='" + nhom + "' where AccountNumber='" + stk + "'";
                }
                catch
                {
                    sql = "update Account set AccountName=N'" + name + "',AccountNameEnglish=N'" + namee + "',Description=N'" + dg + "',AccountCategoryID='" + ntk + "',ParentID=NULL,AccountCategoryKind='" + tc + "',DetailByAccountingObject='" + chdt + "',DetailByInventoryItem='" + vthh + "',DetailByJob='" + chcp + "',DetailByContract='" + chhd + "',Inactive='" + ntd + "',DetailByForeignCurrency='" + ctnt + "',AccountingObjectType='" + dt + "',DetailByBankAccount='" + tknh + "',Exits='" + tonquy + "',GroupCost='" + nhom + "' where AccountNumber='" + stk + "'";
                }
                account.checkaccount(name, sql, this);
            }
            else
            {
                sql = "insert into Account values(newid(),'" + stk + "',N'" + name + "','" + dg + "','" + role + "','" + lop + "','False','" + ntk + "','" + tc + "','" + chdt + "','" + vthh + "','" + chcp + "','" + chhd + "','False','" + ctnt + "','" + dt + "','" + tknh + "','" + namee + "','"+tonquy+"','"+nhom+"')";
                tkth = cbtkth.SelectedValue.ToString();
                account.checkaccount(name, sql, this);
            }*/
        }

        private void chbct_CheckedChanged(object sender, EventArgs e)
        {
            if (chbct.Checked == false)
            {
                chbdt.Enabled = false;
                chbcp.Enabled = false;
                chbhd.Enabled = false;
                chbvthh.Enabled = false;
                chtknh.Enabled = false;
                chbctnt.Enabled = false;
                chbdt.Checked = false;
                chbcp.Checked = false;
                chbhd.Checked = false;
                chbvthh.Checked = false;
                chtknh.Checked = false;
                chbctnt.Checked = false;
            }
            else
            {
                if (chbvthh.Checked == false)
                {
                    chbdt.Enabled = true;
                }
                chbcp.Enabled = true;
                chbhd.Enabled = true;
                if (chbdt.Checked == false)
                {
                    chbvthh.Enabled = true;
                }
                chtknh.Enabled = true;
                chbctnt.Enabled = true;
            }
        }

        private void chbdt_CheckedChanged(object sender, EventArgs e)
        {
            if (chbdt.Checked == true)
            {
                cbdt.Enabled = true;
                chbvthh.Checked = false;
                chbvthh.Enabled = false;
            }
            else
            {
                cbdt.Enabled = false;
                cbdt.SelectedIndex = 0;
                if (chbct.Checked == true)
                {
                    chbvthh.Enabled = true;
                }
            }
        }

        private void chbvthh_CheckedChanged(object sender, EventArgs e)
        {
            if (chbvthh.Checked == true)
            {
                chbdt.Enabled = false;
                chbdt.Checked = false;
            }
            else
            {
                if (chbct.Checked == true)
                {
                    chbdt.Enabled = true;
                }
            }
        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbcp_CheckedChanged(object sender, EventArgs e)
        {
            if (chbcp.Checked == true)
                cbnhomcp.Enabled = true;
            else
                cbnhomcp.Enabled = false;
        }
      
    }
}