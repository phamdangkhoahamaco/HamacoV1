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
using HAMACO.Resources;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;

namespace HAMACO
{
    public partial class Frm_Main : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dtMenu = new DataTable();
        DataTable dtTree = new DataTable();
        string contextMenuID = "";
        public Frm_Main()
        {
            InitializeComponent();
            WindowsFormsSettings.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;


        }



        private void Frm_Main_Load(object sender, EventArgs e)
        {

            lblStatus1.Caption = "Company: " + Globals.companyname + "| User: " + Globals.username + "| Version: " + Globals.version;
            // lblTransactionName.Text = "";
            this.Text = Globals.companyname;

            LoadDataTableMenu();
            loadTreeMenu();
        }

        void LoadDataTableMenu()
        {
            dtMenu = p._SQLTraveDatatable("SELECT t.TransactionCode, t.RoleCode, t1.RoleName, formName, TransactionName, ParentFolder, IsParent, t2.TransactionCode as fav FROM Transactions t LEFT JOIN Roles t1 ON t.RoleCode = t1.RoleCode LEFT JOIN TransactionFav t2 ON t.TransactionCode = t2.TransactionCode  and t2.username = '" + Globals.username + "' WHERE t.rolecode IN ( SELECT RoleCode FROM UserJoinRole WHERE username = '" + Globals.username + "' ) and t.IsDisplay = 1 ORDER BY SortNo ASC", gen.GetConn());

        }

        void loadTreeMenu()
        {
            treeMenu.ClearNodes();
            dtTree = new DataTable();
            DataRow[] found;
            DataTable dtDistintParentFolder;
            DataView viewFolder;

            if (txtSearh.Text == "")
                dtTree = dtMenu.Copy();
            else
            {
                found = dtMenu.Select("TransactionName like '%" + txtSearh.Text + "%' or TransactionCode  like '%" + txtSearh.Text + "%'");
                if (found.Count() > 0)
                    dtTree = found.CopyToDataTable();
            }

            if (dtTree.Rows.Count == 0)
                return;

            DataView view = new DataView(dtTree);
            DataTable dtDistintRoleName = view.ToTable(true, "RoleCode", "RoleName");
            string code;
            string name;

            treeMenu.BeginUpdate();
            treeMenu.Columns.Add();
            treeMenu.Columns[0].Caption = "ID";
            treeMenu.Columns[0].VisibleIndex = -1;
            treeMenu.Columns.Add();
            treeMenu.Columns[1].Caption = "";
            treeMenu.Columns[1].VisibleIndex = 0;
            treeMenu.EndUpdate();
            treeMenu.BeginUnboundLoad();
            TreeListNode parentForRootNodes = null;

            TreeListNode FavoriteNode = treeMenu.AppendNode(new object[] { "Fav", "Favorite" }, parentForRootNodes);
            FavoriteNode.StateImageIndex = 0;

            foreach (DataRow rowSub in dtTree.Select("Fav is not null and Fav <> ''"))
            {
                code = rowSub["formName"].ToString();
                name = rowSub["TransactionCode"].ToString().Trim() + " - " + rowSub["TransactionName"];
                TreeListNode subNode = treeMenu.AppendNode(new object[] { code, name }, FavoriteNode);
                subNode.StateImageIndex = 1;
                subNode.Tag = name;
            }

            foreach (DataRow rowRole in dtDistintRoleName.Rows)
            {
                code = rowRole["RoleCode"].ToString();
                name = rowRole["RoleName"].ToString();
                TreeListNode RoleNode = treeMenu.AppendNode(new object[] { code, name }, parentForRootNodes);
                RoleNode.StateImageIndex = 0;

                found = dtTree.Select("RoleCode = '" + code + "' and IsParent = 1");
                if (found.Count() > 0)
                {
                    viewFolder = new DataView(found.CopyToDataTable());
                    dtDistintParentFolder = viewFolder.ToTable(true, "ParentFolder");
                    foreach (DataRow rowFolder in dtDistintParentFolder.Rows)
                    {
                        name = rowFolder["ParentFolder"].ToString();
                        TreeListNode folderNode = treeMenu.AppendNode(new object[] { name, name }, RoleNode);
                        folderNode.StateImageIndex = 0;
                        foreach (DataRow rowSub in dtTree.Select("ParentFolder = '" + name + "'"))
                        {
                            code = rowSub["formName"].ToString();
                            name = rowSub["TransactionCode"].ToString().Trim() + " - " + rowSub["TransactionName"];
                            TreeListNode subNode = treeMenu.AppendNode(new object[] { code, name }, folderNode);
                            subNode.StateImageIndex = 3;
                            subNode.Tag = name;
                        }
                    }
                }

                found = dtTree.Select("RoleCode = '" + rowRole["RoleCode"].ToString() + "' and IsParent = 0");
                if (found.Count() > 0)
                {
                    foreach (DataRow rowSub in found)
                    {
                        code = rowSub["formName"].ToString();
                        name = rowSub["TransactionCode"].ToString().Trim() + " - " + rowSub["TransactionName"];
                        TreeListNode subNode = treeMenu.AppendNode(new object[] { code, name }, RoleNode);
                        subNode.StateImageIndex = 3;
                        subNode.Tag = name;
                    }
                }
            }
            treeMenu.EndUnboundLoad();
            //expand

            if (txtSearh.Text != "")
                treeMenu.ExpandAll();
            else
                treeMenu.ExpandToLevel(0);


        }


        private void txtSearh_EditValueChanged(object sender, EventArgs e)
        {
            loadTreeMenu();
        }
        private void treeMenu_MouseClick(object sender, MouseEventArgs e)
        {
            TreeList treeList = sender as TreeList;
            TreeListHitInfo info = treeList.CalcHitInfo(e.Location);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //bật menu

                if (info.HitInfoType == HitInfoType.Cell && info.Node.Tag != null)
                {

                    string idNode = "";
                    string nameNode = "";
                    idNode = info.Node.GetValue("ID").ToString();
                    nameNode = info.Node.Tag.ToString();

                    var type = Type.GetType("HAMACO." + idNode);
                    if (type != null)
                    {
                        var form = Activator.CreateInstance(type) as Form;
                        if (form != null)
                        {
                            if (nameNode.Contains('-'))
                                Globals.transactioncode = nameNode.Split('-')[0].ToString().Trim();

                            form.Text = nameNode;
                            picLogo.Visible = false;
                            form.MdiParent = this;
                            form.Show();
                        }
                    }
                    else
                        MessageBox.Show("cannot open form");
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (info.HitInfoType == HitInfoType.Cell && info.Node.Tag != null)
                {
                    string idNode = info.Node.ParentNode.GetValue("ID").ToString();
                    string nameNode = info.Node.Tag.ToString();
                  
                 
                    if (nameNode.Contains('-'))
                        contextMenuID = nameNode.Split('-')[0].ToString().Trim();

                    if (idNode == "Fav")
                    {
                        deleteFavMenu.Show(new Point(e.X, e.Y + 80));
                    }
                    else
                    {
                        DataRow[] found = dtTree.Select("transactioncode = '" + contextMenuID + "' and (Fav is not null or Fav <> '')");
                        if (found.Count() == 0)
                        {
                            addFavMenu.Show(new Point(e.X, e.Y + 80));
                        }
                           
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "Delete from TransactionFav Where username  ='" + Globals.username + "' and  TransactionCode ='" + contextMenuID + "';";
            gen.ExcuteNonquery(sql);

            LoadDataTableMenu();
            loadTreeMenu();

        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "insert into TransactionFav(UserName,TransactionCode) VALUES ('" + Globals.username + "','" + contextMenuID + "');";
            try
            {
                gen.ExcuteNonquery(sql);
            }
            catch (Exception)
            {


            }


            LoadDataTableMenu();
            loadTreeMenu();
        }

        private void txtSearh_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && dtTree.Rows.Count>0)
            {
                DataRow[] found = dtTree.Select("TransactionName like '%" + txtSearh.Text + "%' or TransactionCode  like '%" + txtSearh.Text + "%'");
                if (found.Count() == 1)
                {
                    string idNode = found[0]["formName"].ToString();
                    string nameNode = found[0]["TransactionCode"].ToString().Trim() + " - " + found[0]["TransactionName"];

                    var type = Type.GetType("HAMACO." + idNode);
                    if (type != null)
                    {
                        var form = Activator.CreateInstance(type) as Form;
                        if (form != null)
                        {
                            if (nameNode.Contains('-'))
                                Globals.transactioncode = nameNode.Split('-')[0].ToString().Trim();
                            form.Text = nameNode;

                            picLogo.Visible = false;
                            form.MdiParent = this;
                            form.Show();
                        }
                    }
                    else
                        MessageBox.Show("cannot open form");
                }
            }
        }
    }
}
