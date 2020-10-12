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
using HAMACO.Resources; // import ham thu vien Hamaco
using DevExpress.XtraNavBar; // de tao menu
using DevExpress.XtraBars;

namespace HAMACO
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string userid = Globals.userid;
        string username = Globals.username;
        string SQLString = "";
        string tname;
        public MainForm()
        {
            InitializeComponent();
        }

        private void load_topmenu()
        {
            // tao menu dua vao profile
            barManager1.BeginUpdate();

            Bar bar1 = new Bar(barManager1, "My MainMenu");

            bar1.DockStyle = BarDockStyle.Top;

            //bar1.DockRow = 0;
            barManager1.MainMenu = bar1;

            BarSubItem subMenuSystem = new BarSubItem(barManager1, "System");
            BarButtonItem buttonOld = new BarButtonItem(barManager1, "Old version");
            BarButtonItem buttonOpen = new BarButtonItem(barManager1, "Change Password");
            BarButtonItem buttonExit = new BarButtonItem(barManager1, "Exit");

            subMenuSystem.AddItems(new BarItem[] { buttonOld, buttonOpen, buttonExit });
            //tao menu con trong profile UserJoinRole
            SQLString = "select * from UserJoinRole where username='" + Globals.username + "'";
            dt = gen.GetTable(SQLString);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string rcode = dt.Rows[i]["RoleCode"].ToString(); // rolecode
                string rolename = gen.GetString2("Roles","RoleName", "RoleCode", rcode);
                BarSubItem subMenuFunctionsi = new BarSubItem(barManager1, rolename);
                bar1.AddItems(new BarItem[] { subMenuFunctionsi });

                // ung voi moi profile tao menu con transaction 
             
                try
                {
                    var ctx = gen.GetNewEntity(); // khai bao new entity Framework
                    var query = ctx.Transactions                                    
                                      .Where(c => c.RoleCode == rcode && c.IsDisplay == 1 && c.IsParent == 0).OrderBy(c => c.SortNo); // khong co folder cha
                    foreach (var data in query)
                    {
                        string tcode = data.TransactionCode.Trim();
                        string TransactionName = data.TransactionName;
                        BarButtonItem buttonj = new BarButtonItem(barManager1, tcode + " - " + TransactionName);
                        subMenuFunctionsi.AddItems(new BarItem[] { buttonj });
                    }
                }
                catch
                {
                   // MessageBox.Show(SQLString);
                }
                // hien tiep cac folder
                DataTable dt2 = new DataTable();
                SQLString = "select ParentFolder from Transactions where IsDisplay = 1 and IsParent = 1 and rolecode='" + rcode + "' group by ParentFolder";
                dt2 = gen.GetTable(SQLString);
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    string ParentFolder = dt2.Rows[j]["ParentFolder"].ToString();                     
                    BarSubItem subMenuFunctionsj = new BarSubItem(barManager1, ParentFolder);
                    subMenuFunctionsi.AddItems(new BarItem[] { subMenuFunctionsj });
                    // tao tiep transaction con
                    var ctx = gen.GetNewEntity(); // khai bao new entity Framework
                    var query = ctx.Transactions
                                      .Where(c => c.RoleCode == rcode && c.IsDisplay == 1 && c.IsParent == 1 && c.ParentFolder== ParentFolder).OrderBy(c => c.SortNo); 
                    foreach (var data in query)
                    {
                        string tcode = data.TransactionCode.Trim();
                        string TransactionName = data.TransactionName;
                        BarButtonItem buttonj = new BarButtonItem(barManager1, tcode + " - " + TransactionName);
                        subMenuFunctionsj.AddItems(new BarItem[] { buttonj });
                    }
                }

            }

            //Add the sub-menus to the bar1 
            bar1.AddItems(new BarItem[] { subMenuSystem });            
            barManager1.ItemClick += new ItemClickEventHandler(barManager1_ItemClick);
            barManager1.EndUpdate();
        }

        private void barManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarSubItem subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            switch (e.Item.Caption)
            {
                case "Exit":
                    this.Close();
                    break;
                case "Change Password":
                    Frm_UserSetPW F = new Frm_UserSetPW(); // goi form change password   
                    F.getusername(Globals.username);
                    F.Show();
                    break;
                case "Old version":
                    Form1 F1 = new Form1(); // goi form1
                    //F1.getform(this); //-- cua Form1
                    F1.getuserid(userid); //-- cua Form1
                    F1.Show();
                    break;
                default:
                    string chuoi = e.Item.Caption;
                    string[] tcode2 = chuoi.Split('-');
                    //MessageBox.Show(tcode2[0]);
                    string fname = gen.GetString2("Transactions", "FormName", "TransactionCode", tcode2[0], clientid);
                    Globals.transactioncode = tcode2[0].ToUpper().Trim();
                    //MessageBox.Show(fname);
                    var type = Type.GetType("HAMACO." + fname);
                    var F2 = Activator.CreateInstance(type) as Form;
                    F2.Show();
                    break;
            }
        }

        private void load_menuFav()
        {
            //SQLString = "select * from TransactionFav where ClientID=" + clientid + " AND username ='" + username + "'";
            SQLString = "select a.TransactionCode,a.UserName, b.TransactionName, b.FormName from TransactionFav a, Transactions b " +
                "where  a.TransactionCode = b.TransactionCode ";
            SQLString += " AND  a.username ='" + username + "'";
            try
            {
                dt = gen.GetTable(SQLString);
            }
            catch
            {
               // MessageBox.Show(SQLString);
            }

            DataTable temp2 = new DataTable();

            navBarControl1.BeginUpdate();
            navBarGroup1.ItemLinks.Clear();
            navBarControl1.Groups.Add(navBarGroup1);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tcode = dt.Rows[i][0].ToString().Trim();
                //txtSQL.Text = tcode;
                string tname = gen.GetString("select TransactionName from transactions where transactioncode='" + tcode + "'");
                NavBarItem itemInbox = new NavBarItem(tcode.ToUpper() + " - " + tname);
                navBarGroup1.ItemLinks.Add(itemInbox);

                //lblSQL.Text = tcode;
            }
            navBarGroup1.Expanded = true;
            navBarControl1.EndUpdate();
            navBarControl1.LinkClicked += new NavBarLinkEventHandler(navBarControl1_LinkClicked);
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void buttonEdit1_Enter(object sender, EventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                //MessageBox.Show("ButtonEdit Validated!");

                tname = gen.GetString2("Transactions", "FormName", "TransactionCode", txtTransactionCode.Text, clientid);
                if (tname != "")
                {

                    // Tao form dong
                    Globals.transactioncode = txtTransactionCode.Text.ToUpper().Trim();
                    var type = Type.GetType("HAMACO." + tname);
                    var F = Activator.CreateInstance(type) as Form;
                    try
                    {
                        F.Show();
                    }catch(Exception ex)
                    {
                         MessageBox.Show(ex.Message + tname); 
                    }
                    
                }
                else
                {
                    XtraMessageBox.Show("Tên transaction không đúng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return true;
            }

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblSQL.Text = "Company: " + Globals.companyname + "| User: " + Globals.username + "| Version: " + Globals.version;
            // lblTransactionName.Text = "";
            this.Text = Globals.companyname;
            // tao dong Menu Fav       
            load_menuFav();

            // load top menu (tao menu dong theo profile
            load_topmenu();

        }

        void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

            // Tao form dong
            string chuoi = e.Link.Caption;
            string[] tcode2 = chuoi.Split('-');
            string fname = gen.GetString2("Transactions", "FormName", "TransactionCode", tcode2[0], clientid);
            Globals.transactioncode = tcode2[0].ToUpper().Trim();
            //txtSQL.Text = SQLString;
            try
            {                
                //MessageBox.Show(fname);
                var type = Type.GetType("HAMACO." + fname);
                var F2 = Activator.CreateInstance(type) as Form;
                F2.Show();             
            }
            catch
            {
                //MessageBox.Show(SQLString);
            }


        }

       

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtTransactionCode.Text == "")
            {
                XtraMessageBox.Show("Please enter the transaction", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tname = gen.GetString2("Transactions", "FormName", "TransactionCode", txtTransactionCode.Text, clientid);
                if (tname != "")
                {
                    // add to Fav
                    SQLString = "INSERT INTO TransactionFav ([TransactionCode],[username]) VALUES (" + "'";
                    SQLString += txtTransactionCode.Text + "','" + username + "')";
                    try
                    {
                        gen.ExcuteNonquery(SQLString);
                        XtraMessageBox.Show("This transaction is created to the favorite successfully!", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // load lai menu Fav
                        load_menuFav();
                    }
                    catch
                    {
                        SQLString = "This transaction is existed already in the favorite";
                        XtraMessageBox.Show(SQLString, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //txtSQL.Text = SQLString;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên transaction không đúng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnDeleteFav_Click(object sender, EventArgs e)
        {
            if (txtTransactionCode.Text == "")
            {
                XtraMessageBox.Show("Please enter the transaction", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tname = gen.GetString2("Transactions", "FormName", "TransactionCode", txtTransactionCode.Text, clientid);
                if (tname != "")
                {
                    // delete to Fav
                    SQLString = "DELETE TransactionFav WHERE TransactionCode='" + txtTransactionCode.Text + "' AND ";
                    SQLString += " username='" + username + "'";
                    try
                    {
                        gen.ExcuteNonquery(SQLString);
                        XtraMessageBox.Show("This transaction is deleted from the favorite successfully!", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // load lai menu Fav
                        load_menuFav();
                    }
                    catch
                    {
                        XtraMessageBox.Show(SQLString, "btnDeleteFav_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //txtSQL.Text = SQLString;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên transaction không đúng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtTransactionCode_EditValueChanged(object sender, EventArgs e)
        {

        }

      

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }
    }
}