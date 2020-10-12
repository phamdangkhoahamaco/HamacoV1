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
using HAMACO.Resources; // import bo thu vien cua HAMACO
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace HAMACO
{
    public partial class Frm_FIDocument : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string username = Globals.username;
        string userid = Globals.userid;
        string SQLString = "";                        
        
        public Frm_FIDocument()
        {
            InitializeComponent();
        }

        private void Frm_FIDocument_Load(object sender, EventArgs e)
        {
            lbHeaderText.Text = "";
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Frm_FIDocument_New m = new Frm_FIDocument_New();
            m.getactive("2"); // view                
            m.getFIDoc(txtFIDocNo.Text);
            m.ShowDialog();
        }

        private void txtFIDocNo_EditValueChanged(object sender, EventArgs e)
        {
            lbHeaderText.Text = gen.GetString2("FIDocument", "FIHeader", "FIDoc",txtFIDocNo.Text);
        }
    }
}