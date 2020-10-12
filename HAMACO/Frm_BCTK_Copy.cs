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
using DevExpress.XtraNavBar; // de tao menu
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
// tài liệu hd: https://docs.google.com/document/d/1S8h8c42pISc1oWR564a7cL5sGsulZd8caxpg8MfstFA/edit?usp=sharing
namespace HAMACO
{
   
    public partial class Frm_BCTK_Copy : DevExpress.XtraEditors.XtraForm
    {
        String username;
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string userid = Globals.userid;
        string SQLString = "", StockCode = "";
        //getStockCode
        public string getStockCode(string a)
        {
            StockCode = a;
            return StockCode;
        }
        public Frm_BCTK_Copy()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
           
        }

        private void copyStock(string username1, string username2)
        {
            //copy Stock
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.UserJoinStocks
            .Where(c => c.UserName == username1 && c.CompanyCode == Globals.companycode);
            foreach (var data in query)
            {
                UserJoinStock obj = new UserJoinStock();
                obj.StockCode = data.StockCode;
                obj.UserName = username2;
                obj.CompanyCode = data.CompanyCode;
                ctx.UserJoinStocks.Add(obj); //insert 
            }
            try
            {
                ctx.SaveChanges();
                XtraMessageBox.Show("Copy stocks successfully", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //catch (DbUpdateException ex) // exception khac
            catch (DbUpdateConcurrencyException ex) // exception khac
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form_UserCopy_Load(object sender, EventArgs e)
        {
           
        }
        public string getusername(string a)
        {
            username = a;
            return username;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            //copy role

            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.BaoCaoTonKhoes
            .Where(c => c.StockCode == StockCode && c.CompanyCode == Globals.companycode && c.FiscalPeriod.ToString() == txtMonth.Text
            && c.FiscalYear.ToString() == txtYear.Text);
            foreach (var data in query)
            {
                BaoCaoTonKho obj = new BaoCaoTonKho();
                obj.StockCode = data.StockCode;                
                obj.CompanyCode = data.CompanyCode;
                obj.FiscalPeriod = Int32.Parse(txtMonth2.Text);
                obj.FiscalYear = Int32.Parse(txtYear2.Text);
                obj.InventoryItemCode = data.InventoryItemCode;
                obj.InventoryItemName = data.InventoryItemName;
                obj.Unit = data.Unit;
                obj.UnitPrice = data.UnitPrice;
                obj.QuantityDK = data.QuantityCK; // DK = CK
                obj.QuantityCK = data.QuantityCK;
                obj.QuantityCK2 = data.QuantityCK;//plan                
                obj.QuantityNTK2 = 0;
                obj.QuantityXTK2 = 0;
                obj.QuantityNTK = 0;
                obj.QuantityXTK = 0;
                
                ctx.BaoCaoTonKhoes.Add(obj); //insert  
            }
            try
            {
                ctx.SaveChanges();
                XtraMessageBox.Show("Copy bao cao ton kho successfully", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbEntityValidationException ex) // exception khac            
            {
                foreach (var ve in ex.EntityValidationErrors)
                {
                    XtraMessageBox.Show(ve.Entry.Entity.GetType().Name + ve.Entry.State, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Frm_BCTK_Copy_Load(object sender, EventArgs e)
        {
            txtYear.Text = DateTime.Now.Year.ToString();
            txtMonth.Text = DateTime.Now.Month.ToString();
            txtYear2.Text = DateTime.Now.Year.ToString();
            txtMonth2.Text = (Int32.Parse(txtMonth.Text) + 1).ToString();
            txtStockCode.Text = StockCode;
        }

    }
}