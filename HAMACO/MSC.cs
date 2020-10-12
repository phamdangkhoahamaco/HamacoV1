using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using DevExpress.XtraSplashScreen;

namespace HAMACO
{
    public partial class MSC : DevExpress.XtraEditors.XtraForm
    {
        DataTable da = new DataTable();
        DataTable temp = new DataTable();
        gencon gen = new gencon();
        mscrole mscrole = new mscrole();
        int start, check;
        string ex, role;
        string[,] mscstr = new string[3000, 3];
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public MSC()
        {
            InitializeComponent();
        }

        private void MSC_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            temp = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + role + "'");
            
            int counttemp = temp.Rows.Count;
            for (start = 0; start < counttemp; start++)
            {
                mscstr[start, 0] = temp.Rows[start][1].ToString();
                mscstr[start, 1] = temp.Rows[start][3].ToString();
                mscstr[start, 2] = "1";
            }
            ImageList il = new ImageList();
            il.Images.Add(HAMACO.Properties.Resources.previous);
            tvmsc.ImageList = il;
            this.tvmsc.Nodes.Add("HAMACO");
            temp = gen.GetTable("select * from MSC_SubSystem  order by SortOrder");
            int level = 0; int level1 = 0;
            for(int i=0;i<temp.Rows.Count;i++)
            {
                if(temp.Rows[i][3].ToString()=="ROOT")
                {
                    mscrole.tvlevel(tvmsc, level, level1, temp, temp.Rows[i][0].ToString(), temp.Rows[i][1].ToString());
                    level1++;
                }
            }
            tvmsc.Nodes[0].Expand();
            SplashScreenManager.CloseForm();
            //tạo cây phân quyền
            /*da = gen.GetTable("select * from MSC_SubSystem where ParentSubSystemCode = 'Root' order by SortOrder ");
            int count = da.Rows.Count;
            int level = 0; int level1 = 0;
            for (int i = 0; i < count; i++)
            {
                mscrole.tvlevel1(tvmsc, level, level1, i, da);
                level1++;
            }*/
        }


        private void tvmsc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            check = 0;
            ex = e.Node.Name;
            mscrole.lvmscrole(da, ex, start, lvmsc, mscstr);
            check = 1;
        }

        private void lvmsc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int exitrole = 0;
            if (check == 1)
            {
                for (int i = 0; i < start; i++)
                {
                    if (mscstr[i, 0] == ex && mscstr[i, 1] == lvmsc.Items[e.Index].Name)
                    {
                        exitrole = 1;
                        if (mscstr[i, 2] == "1")
                        {
                            mscstr[i, 2] = "0";
                            break;
                        }
                        else
                        {
                            mscstr[i, 2] = "1";
                            break;
                        }
                    }
                }
                if (exitrole == 0)
                {
                    start++;
                    mscstr[start, 0] = ex;
                    mscstr[start, 1] = lvmsc.Items[e.Index].Name;
                    mscstr[start, 2] = "1";
                }
            }
        }

        private void huy_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void luu_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            gen.ExcuteNonquery("delete from MSC_RolePermissionMaping where RoleID='" + role + "'");
            for (int i = 0; i <= start; i++)
            {
                if (mscstr[i, 2] == "1")
                {
                    gen.ExcuteNonquery("insert into MSC_RolePermissionMaping values(newid(),'" + mscstr[i, 0] + "','" + role + "','" + mscstr[i, 1] + "')");
                }
            }
            SplashScreenManager.CloseForm();
            this.Close();
            this.Dispose();
        }

        private void checkall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvmsc.Items.Count; i++)
            {
                if (lvmsc.Items[i].Checked == false)
                {
                    lvmsc.Items[i].Checked = true;
                }
            }

        }

        private void uncheckall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvmsc.Items.Count; i++)
            {
                if (lvmsc.Items[i].Checked == true)
                {
                    lvmsc.Items[i].Checked = false;
                }
            }
        }

        private void exall_Click(object sender, EventArgs e)
        {
            tvmsc.ExpandAll();
        }

        private void crollall_Click(object sender, EventArgs e)
        {
            tvmsc.CollapseAll();
        }
     
    }
}