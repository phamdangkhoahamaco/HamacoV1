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
using System.Data.Entity.Validation;

namespace HAMACO
{
    public partial class Frm_CTXNT : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        string active = "0", InventoryItemCode = ""; //0: new, 1; edit; 2: view
        Boolean status;
        int FiscalYear, FiscalPeriod, INOut, Posted;

        private void Frm_CTXNT_Load(object sender, EventArgs e)
        {
            txtYear.Text = DateTime.Now.Year.ToString();
            txtMonth.Text = DateTime.Now.Month.ToString();
            status = true; //0: Create, 1: Edit; 2 :view
            if (active == "") active = "0";
            if (active == "2") status = false;
            load_activeform(status);
            load_grid_item(); // line item table MM Document Detail
        }

        private void load_grid_item()
        {
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var dt = ctx.MMDocumentDetails
                .Where(c => c.InventoryItemCode == InventoryItemCode && c.RefDate.Value.Year == FiscalYear && c.RefDate.Value.Month == FiscalPeriod && c.INOut==1)
                .ToList();
            gridControl_Nhap.DataSource = new BindingList<MMDocumentDetail>(dt);

            var dt2 = ctx.MMDocumentDetails
               .Where(c => c.InventoryItemCode == InventoryItemCode && c.RefDate.Value.Year == FiscalYear && c.RefDate.Value.Month == FiscalPeriod && c.INOut == 0)
               .ToList();
            gridControl_Xuat.DataSource = new BindingList<MMDocumentDetail>(dt2);
        }

        private void load_activeform(bool status)
        {
            FiscalYear = Int32.Parse(txtYear.Text);
            FiscalPeriod = Int32.Parse(txtMonth.Text);
            txtCompanyCode.Text = Globals.companycode;
            txtInventoryItemCode.Text = InventoryItemCode;
            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;
            if (active == "2" || active == "1") // display or edit
            {
                var db = gen.GetNewEntity(); // khai bao new entity Framework                   
                var dt = db.BaoCaoTonKhoes.FirstOrDefault(x => x.InventoryItemCode == InventoryItemCode && x.CompanyCode == Globals.companycode
                && x.FiscalPeriod == FiscalPeriod && x.FiscalYear == FiscalYear);
                if (dt != null)
                {
                    txtInventoryItemName.Text = dt.InventoryItemName;
                    txtUnit.Text = dt.Unit;
                    txtUnitPrice.Text = dt.UnitPrice.ToString();
                    txtStockCode.Text = dt.StockCode;
                    txtQuantityCK.Text = dt.QuantityCK.ToString();
                    txtQuantityDK.Text = dt.QuantityDK.ToString();
                    txtQuantityNTK.Text = dt.QuantityNTK.ToString();
                    txtQuantityXTK.Text = dt.QuantityXTK.ToString();
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework                       
            var dt = db.BaoCaoTonKhoes.FirstOrDefault(x => x.StockCode == txtStockCode.Text && x.CompanyCode == Globals.companycode
            && x.InventoryItemCode == txtInventoryItemCode.Text && x.FiscalYear == FiscalYear && x.FiscalPeriod == FiscalPeriod);


            BaoCaoTonKho data = new BaoCaoTonKho();// class BaoCaoTonKho
            data.CompanyCode = Globals.companycode;
            data.FiscalYear = FiscalYear;
            data.FiscalPeriod = FiscalPeriod;
            data.InventoryItemCode = txtInventoryItemCode.Text;
            data.StockCode = txtStockCode.Text;
            //txtSQL.Text = "SELECT * from BaoCaoTonKho WHERE StockCode='" + StockCode + "' AND InventoryItemCode='" + inventoryItemCode + "' AND FiscalYear=" + FiscalYear + " AND FiscalPeriod=" + FiscalPeriod;
            //XtraMessageBox.Show("update_tonkho" + txtSQL.Text, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dt != null)
            {
                // chi can update lai so lieu
              //  XtraMessageBox.Show("update_tonkho2" + quantity.ToString() + Posted + INOut, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data.QuantityDK = dt.QuantityDK;
                data.QuantityCK = dt.QuantityCK;
                data.QuantityCK2 = dt.QuantityCK2;
                data.QuantityNTK2 = dt.QuantityNTK2;
                data.QuantityXTK2 = dt.QuantityXTK2;
                data.QuantityNTK = dt.QuantityNTK;
                data.QuantityXTK = dt.QuantityXTK;
                data.InventoryItemName = dt.InventoryItemName;
                data.Unit = dt.Unit;
                data.UnitPrice = dt.UnitPrice;

                try
                {
                    data.QuantityNTK = sltk(txtInventoryItemCode.Text,FiscalPeriod,FiscalYear,1,1);
                    data.QuantityNTK2 = data.QuantityNTK + sltk(txtInventoryItemCode.Text, FiscalPeriod, FiscalYear, 0, 1); // plan
                    data.QuantityXTK = sltk(txtInventoryItemCode.Text, FiscalPeriod, FiscalYear, 1, 0);
                    data.QuantityXTK2 = data.QuantityXTK + sltk(txtInventoryItemCode.Text, FiscalPeriod, FiscalYear, 0, 0); // plan

                    data.QuantityCK = data.QuantityDK + data.QuantityNTK - data.QuantityXTK;
                    data.QuantityCK2 = data.QuantityDK + data.QuantityNTK2 - data.QuantityXTK2;

                    var db2 = gen.GetNewEntity(); // khai bao new entity Framework                       
                    db2.Entry(data).State = System.Data.Entity.EntityState.Modified; // update                                
                    db2.SaveChanges();
                    
                    XtraMessageBox.Show( "Update successful","Hamaco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantityNTK.Text = data.QuantityNTK.ToString();
                    txtQuantityXTK.Text = data.QuantityXTK.ToString();
                    txtQuantityCK.Text = data.QuantityCK.ToString();
                }
                catch (DbEntityValidationException ex) // exception khac
                {
                    XtraMessageBox.Show(ex.Message, "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // tao moi
            {
                XtraMessageBox.Show("Chưa có mã này", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public decimal sltk(string code, int thang, int year, int Posted, int INOut) 
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.MMDocumentDetails.Where(c => c.InventoryItemCode == code && c.RefDate.Value.Month == thang
            && c.RefDate.Value.Year == year && c.Posted == Posted && c.INOut == INOut);

            if ((from x in luyke select x.Quantity).Sum() != null) kq = (from x in luyke select x.Quantity).Sum() ?? 0;

            return kq;
        }

        public Frm_CTXNT()
        {
            InitializeComponent();
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }

        public string getMaHH(string a)
        {
            InventoryItemCode = a;
            return InventoryItemCode;
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
    }
}