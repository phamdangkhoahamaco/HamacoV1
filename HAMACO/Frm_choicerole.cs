using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_choicerole : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        mscrole mscrole = new mscrole();
        string role;
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public Frm_choicerole()
        {
            InitializeComponent();
        }

        private void Frm_choicerole_Load(object sender, EventArgs e)
        {
            mscrole.loadrole(lvpq, view, "Select * from MSC_Role where RoleID not in (select RoleID from MSC_UserJoinRole where UserID='" + role + "')");
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            gen.ExcuteNonquery("delete from MSC_UserJoinRole where UserID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_UserJoinRole values(newid(),'" + role + "','" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "','4eb226e3-fb42-4ab4-b82e-7021d2322b40')");
            this.Close();
        }

    }
}