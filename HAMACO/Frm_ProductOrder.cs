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
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Data.Entity.Validation;

namespace HAMACO
{
    public partial class Frm_ProductOrder : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        string active = "0", MMDoc = ""; //0: new, 1; edit; 2: view
        Guid RefID; // RefID cua MMDocument
        Boolean status;
        int FiscalYear, FiscalPeriod, INOut, Posted;
        private decimal qty = 0;
        private decimal amount = 0;
        private decimal vat = 0;
        private decimal price = 0;
        string errors = "";

        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public string getMMDoc(string a)
        {
            MMDoc = a;
            return MMDoc;
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
        public Frm_ProductOrder()
        {
            InitializeComponent();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {

        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {

        }

        private void Frm_ProductOrder_Load(object sender, EventArgs e)
        {
            if (Globals.transactioncode == "ME23" || Globals.transactioncode == "DNDH") // don dat hang
            {
                this.Text = "Đơn đặt hàng nội bộ";
                txtRefType.Text = "11";                
            }

            lblRefName.Text = this.Text; lblTenPhieu.Text = "";


            //LOAD active fields (edit/create/view)
            status = false; //0: Create, 1: Edit; 2 :view status of readonly
            if (active == "") active = "0";
            if (active == "2") status = true;
            if (active == "0")
            {
                txtMaKH.Visible = false; txtAccountingObjectCode.Visible = true;
            }
            else
            {
                txtMaKH.Visible = true;  txtAccountingObjectCode.Visible = false;
            }

            load_txtStockCode1();
            load_txtStockCode2();
            load_cbthue(); // thue xuat

            load_activeform(status);
            load_grid_item(); // line item table MM Document Detail
            load_grid_FIDoc(); // load table FIDocument voi dk MMDoc = MMDoc
        }

        private void load_grid_FIDoc()
        {
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var dt = ctx.FIDocuments
                .Where(c => c.MMDoc == MMDoc && c.CompanyCode== Globals.companycode)
                .ToList();
            gridControl_FIDoc.DataSource = new BindingList<FIDocument>(dt);
            gridView_FIDoc.OptionsBehavior.Editable = false;
            gridView_FIDoc.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            // detail gridcontrol1 & gridview5
            string mySQL = "select b.FIDoc,b.DebitAccount, b.CreditAccount, case ";
            mySQL += " when b.DebitAccount = '131' then b.Amount";
            mySQL += " else (0 - b.Amount)";
            mySQL += " end as Amount, b.AccountingObjectCode, b.AccountingObjectName, b.Description";
            mySQL += " from FIDocument a, FIDocumentDetail b where a.FIDoc = b.FIDoc";
            mySQL += " and a.MMDoc = '" + MMDoc + "'";
            DataTable dt2 = gen.GetTable(mySQL);
            gridControl1.DataSource = dt2;
            gridView5.OptionsBehavior.Editable = false;
            gridView5.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        private void load_cbthue()
        {
            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            //cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");
        }

        private void load_txtStockCode1()
        {
            DataTable temp2 = new DataTable();
            temp2.Clear();

            temp2.Columns.Add("Stock Code");
            temp2.Columns.Add("Stock Name");
            var ctx3 = gen.GetNewEntity(); // khai bao new entity Framework
            var query3 = ctx3.Stocks
            .Where(c => c.CompanyCode == Globals.companycode)
            .OrderBy(c => c.StockCode);
            foreach (var data in query3)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = data.StockCode;
                dr[1] = data.StockName;
                temp2.Rows.Add(dr);
            }
            txtStockCode1.Properties.DataSource = temp2;
            txtStockCode1.Properties.DisplayMember = "Stock Code";
            txtStockCode1.Properties.ValueMember = "Stock Code";
        }

        private void load_grid_item()
        {
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var dt = ctx.MMDocumentDetails
                .Where(c => c.MMDoc == MMDoc)
                .ToList();
            gridControl_Item.DataSource = new BindingList<MMDocumentDetail>(dt);
            
                        
                //gridControl_Item.DataSource = dt;
                if (active == "0" || active == "1")
            {
                if (txtStockCode2.Text != "[EditValue is null]") load_MaHH(txtStockCode2.Text);
            }
            
            if (active == "2")
            {                
                gridView1.OptionsBehavior.Editable = false;
                btnSave.Visible = false;
            }
            if (active == "1" || active == "2")
            {
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                colInventoryItemCode.Visible = false;
            }
            else
            {
                colInventoryItemCode2.Visible = false; // hidden cot maHH
            }
        }

        private void load_MaHH(string stockcode) // load dropbox Ma HH trong grid
        {
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework            
            var dt = ctx.BaoCaoTonKhoes
                .Where(x => x.CompanyCode == Globals.companycode && x.FiscalYear == FiscalYear
                    && x.FiscalPeriod == FiscalPeriod && x.StockCode == stockcode).ToList(); // so luong ton kho >0 moi cho dat
            txtSQL.Text = "SELECT * from BaoCaoTonKho WHERE FiscalYear=" + FiscalYear + " AND FiscalPeriod=" + FiscalPeriod + " AND StockCode = '" + stockcode + "'";
            rep_mahang.DataSource = dt;

            rep_mahang.ValueMember = "InventoryItemCode";
            rep_mahang.DisplayMember = "InventoryItemCode";

            rep_mahang.NullText = @"Chọn vật tư";
            colInventoryItemCode.ColumnEdit = rep_mahang;
        }

        private void load_activeform(bool status)
        {
            txtRefType.ReadOnly = status; txtCompanyCode.ReadOnly = status; txtCompanyCode.Text = Globals.companycode;
            txtMMDoc.ReadOnly = status; 

            if(active=="0") MMDoc = DateTime.Now.ToString("yyyyMMddhhmmss");
            if (active == "0") txtUserName.Text = Globals.username;
            if (active == "0" || active=="1") btnPrint.Visible = false;

            txtMMDoc.Text = MMDoc;

            

            txtAccountingObjectCode.ReadOnly = status;
            txtRefDate.ReadOnly = status;
            txtPostedDate.ReadOnly = status;
            txtAccountingObjectAddress.ReadOnly = status;
            txtMMHeader.ReadOnly = status;
            cbthue.ReadOnly = status;            

            //defaut date

            if (active == "0") txtPostedDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.ToString());
            if (active == "0") txtRefDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.ToString());
            //tinh lai nam, thang refdate
            if (active == "0") FiscalYear = DateTime.Now.Year;
            if (active == "0") FiscalPeriod = DateTime.Now.Month;            

            if (active == "2" || active == "1") // display or edit
            {
                txtStockCode1.Enabled = false;
                txtStockCode2.Enabled = false;

                //hidden cot SL ton kho
                gridView1.Columns["QuantityCK2"].Visible = false;
                var db = gen.GetNewEntity(); // khai bao new entity Framework                   
                var dt = db.MMDocuments.FirstOrDefault(x => x.MMDoc == MMDoc && x.CompanyCode == Globals.companycode);
                if (dt != null)
                {
                    RefID = dt.RefID;
                    txtStockCode1.Text = dt.StockCode1;
                    txtStockCode2.Text = dt.StockCode2;
                    txtUserName.Text = dt.UserName;
                    txtAccountingObjectCode.Text = dt.AccountingObjectCode;
                    txtAccountingObjectName.Text = dt.AccountingObjectName;
                    txtMaKH.Text = dt.AccountingObjectCode;
                    txtAccountingObjectAddress.Text = dt.AccountingObjectAddress;
                    txtCompanyTaxCode.Text = dt.CompanyTaxCode;
                    txtRefType.Text = dt.RefType.ToString();                    
                    txtPostedDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dt.PostedDate.ToString()));
                    txtRefDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dt.RefDate.ToString()));
                    FiscalYear = dt.RefDate.Year;
                    FiscalPeriod = dt.RefDate.Month;

                    txtMMHeader.Text = dt.MMHeader;
                    txtPosted.Text = dt.Posted.ToString();
                    if (txtPosted.Text == "1") lblStatus.Text = "Approved";
                    else lblStatus.Text = "Inactive";
                    txtUserName2.Text = dt.UserName2;

                    cbthue.Text = dt.TaxCode.ToString();
                    //cbthue.EditValue = dt.TaxCode.ToString();

                    if (active == "2" && dt.Posted==0) // view & approve=0
                    {
                        // kiem tra quyen
                        var db2 = gen.GetNewEntity(); // khai bao new entity Framework                   
                        var dt2a = db.UserJoinStock_Approve.FirstOrDefault(x => x.StockCode == txtStockCode2.Text && x.CompanyCode == Globals.companycode && x.UserName == Globals.username);
                        if (dt2a != null)
                        {
                            btnApprove.Visible = true;
                            btnDelete.Visible = true;
                        }                            
                    }
                    // radio box
                    if (dt.INOut == 0)
                    {
                        radioGroup1.SelectedIndex = 0; // giao thang thi inout=0 --> phieu xuat
                        lblTenPhieu.Text = "--> Phiếu xuất";
                        btnPrint.Text = "In phiếu xuất";
                    }
                    else {
                        radioGroup1.SelectedIndex = 1; // giao thang thi inout=1 --> phieu nhap
                        lblTenPhieu.Text = "--> Phiếu nhập";
                        btnPrint.Text = "In phiếu nhập";
                    }
                    if (txtRefType.Text=="11") btnPrint.Text = "In đơn đặt hàng";
                    INOut = dt.INOut;


                    if (dt.Factory == 0) radioGroup2.SelectedIndex = 0; // giao tu cty Factory=0
                    else radioGroup2.SelectedIndex = 1; // giao tu cty Factory=1
                                       

                    var dt2 = db.Stocks.FirstOrDefault(x => x.StockCode == txtStockCode2.Text && x.CompanyCode == Globals.companycode);
                    if (dt2 != null)
                    {
                        txtStockName2.Text = dt2.StockName;
                    }
                    var dt3 = db.Stocks.FirstOrDefault(x => x.StockCode == txtStockCode1.Text && x.CompanyCode == Globals.companycode);
                    if (dt3 != null)
                    {
                        txtStockCode1.Text = dt3.StockName;
                    }
                }
            }


        }

        private void create_MMDocument(string MMDoc)
        {
            MMDocument data = new MMDocument();// class MMDocument
            if (active == "0")
            {
                data.RefID = Guid.NewGuid();// tao guiid moi
                data.Posted = 0;// phieu tam
                lblStatus.Text = "Inactive";
            }
            else
            {
                data.RefID = RefID;
                if (txtPosted.Text == "0") data.Posted = 0;
                else data.Posted = 0;
            }
            Posted = data.Posted;

            data.CompanyCode = Globals.companycode;
            data.MMDoc = MMDoc;
            data.StockCode1 = txtStockCode1.Text;
            data.StockCode2 = txtStockCode2.Text;
            data.RefType = Int32.Parse(txtRefType.Text);
            try
            {
                data.TaxCode = Int32.Parse(cbthue.Text);
            }
            catch { data.TaxCode = 0;}
            try
            {
                data.PostedDate = DateTime.ParseExact(txtPostedDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);                
            }
            catch
            {
                data.PostedDate = DateTime.Parse(txtPostedDate.Text);
            }
            try {
                data.RefDate = DateTime.ParseExact(txtRefDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch { data.RefDate = DateTime.Parse(txtRefDate.Text); }
            //tinh lai nam, thang refdate
            FiscalYear = data.RefDate.Year;
            FiscalPeriod = data.RefDate.Month;

            data.RefNo = txtRefNo.Text;
            data.AccountingObjectCode = txtAccountingObjectCode.Text;
            data.AccountingObjectName = txtAccountingObjectName.Text;
            data.AccountingObjectAddress = txtAccountingObjectAddress.Text;
            data.CompanyTaxCode = txtCompanyTaxCode.Text;
            data.MMHeader = txtMMHeader.Text; // ly do   
            data.UserName = Globals.username; // nguoi tao phieu
            //sum
            try
            {
                data.TotalAmount = Decimal.Parse(gridView1.Columns["Amount"].SummaryText);
            }
            catch {
                errors = "loi totalamount";
            }

            if (radioGroup1.SelectedIndex == -1) errors = "Vui lòng nhập loại hàng nhập kho hay giao thẳng";
            if (radioGroup2.SelectedIndex == -1) errors = "Vui lòng nhập loại giao tại cty hay giao tại nhà máy";
            if (data.TotalAmount==0) errors = "Xem lại cột Thành tiền";

            if (radioGroup1.SelectedIndex==0) data.INOut = 0; // giao thang thi inout=0 --> phieu xuat
            else data.INOut = 1; //  inout=1 --> phieu nhap
            INOut = data.INOut;

            if ((radioGroup2.SelectedIndex == 0)) data.Factory = 0; // giao tu cty Factory=0
            else data.Factory = 1; // giao tu cty Factory=1                       

            
            //txtSQL.Text = radioGroup1.SelectedIndex.ToString() + radioGroup2.SelectedIndex.ToString();
            var db = gen.GetNewEntity(); // khai bao new entity Framework

            try
            {
                if (active == "0") db.MMDocuments.Add(data); //insert                
                else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update
                db.SaveChanges();
                /*if (active == "0") XtraMessageBox.Show("New MM Doc inserted successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else XtraMessageBox.Show("MM Doc updated successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
            catch (DbEntityValidationException ex) // exception khac
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    txtSQL.Text = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                    txtSQL.Text += eve.Entry.Entity.GetType().Name;
                    txtSQL.Text += eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        XtraMessageBox.Show(ve.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                errors = txtSQL.Text;
            }
        }

        private void load_txtAccountingObjectCode()
        {
            /*DataTable temp2 = new DataTable();
            temp2.Clear();

            temp2.Columns.Add("Code");
            temp2.Columns.Add("Name");
            var ctx3 = gen.GetNewEntity(); // khai bao new entity Framework
            var query3 = ctx3.AccountingObjects
            .Where(c => c.CompanyCode == Globals.companycode)
            .OrderBy(c => c.AccountingObjectCode);
            foreach (var data in query3)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = data.AccountingObjectCode;
                dr[1] = data.AccountingObjectName;
                temp2.Rows.Add(dr);
            }
            txtAccountingObjectCode.Properties.DataSource = temp2;
            txtAccountingObjectCode.Properties.DisplayMember = "Code";
            txtAccountingObjectCode.Properties.ValueMember = "Code";*/
            string SQL = "";
            SQL = "select AccountingObjectCode, AccountingObjectName from AccountingObject";
            DataTable tmp = new DataTable();
            try
            {
                tmp = gen.GetTable(SQL);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "load_makh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            txtAccountingObjectCode.Properties.DataSource = tmp;
            txtAccountingObjectCode.Properties.DisplayMember = "AccountingObjectCode";
            txtAccountingObjectCode.Properties.ValueMember = "AccountingObjectCode";
        }

        private void txtStockCode_EditValueChanged(object sender, EventArgs e)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework                   
            var dt = db.Stocks.FirstOrDefault(x => x.StockCode == txtStockCode2.Text && x.CompanyCode == Globals.companycode);
            if (dt != null)
            {
                txtStockName2.Text = dt.StockName;                
            }
            load_MaHH(txtStockCode2.Text); // load lại mã khách hàng theo stockcode
        }

        private void txtAccountingObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework                   
            var dt = db.AccountingObjects.FirstOrDefault(x => x.AccountingObjectCode == txtAccountingObjectCode.Text && x.CompanyCode == Globals.companycode);
            if (dt != null)
            {
                txtAccountingObjectName.Text = dt.AccountingObjectName;
                txtAccountingObjectAddress.Text = dt.Address;
                txtCompanyTaxCode.Text = dt.CompanyTaxCode;
            }
        }
        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
        }

        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if ((active == "0" || active == "1") && (txtStockCode2.Text == "[EditValue is null]" || txtStockCode2.Text == ""))
            {
                XtraMessageBox.Show("Please input the stock code first", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //if (active == "0" || active == "1") create_MMDocumentDetail(MMDoc,txtInventoryItemCode.Text); // tao chung tu moi MM
            }
        }

        private void create_MMDocumentDetail(string mMDoc)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework
            txtSQL.Text += gridView1.RowCount;
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                //txtSQL.Text += gridView1.GetRowCellValue(i, "InventoryItemCode").ToString();
                MMDocumentDetail data = new MMDocumentDetail();// class MMDocumentDetail
                if (active == "0") data.RefDetailID = Guid.NewGuid();// tao guiid moi
                else data.RefDetailID = Guid.Parse(gridView1.GetRowCellValue(i, "RefDetailID").ToString());

                data.InventoryItemCode = gridView1.GetRowCellValue(i, "InventoryItemCode").ToString();
                data.InventoryItemName = gridView1.GetRowCellValue(i, "InventoryItemName").ToString();
                data.Unit = gridView1.GetRowCellValue(i, "Unit").ToString();
                try { data.UnitPrice = Decimal.Parse(gridView1.GetRowCellValue(i, "UnitPrice").ToString()); } catch { data.UnitPrice = 0; }                
                try { data.Quantity = Decimal.Parse(gridView1.GetRowCellValue(i, "Quantity").ToString());}
                catch { data.Quantity = 0; }
                try
                {
                    data.QuantityCK2 = Decimal.Parse(gridView1.GetRowCellValue(i, "QuantityCK2").ToString()); // ton kho plan
                }
                catch { data.QuantityCK2 = 0; }                
                
                try
                {
                    data.QuantityConvert = Decimal.Parse(gridView1.GetRowCellValue(i, "QuantityConvert").ToString());
                }
                catch { data.QuantityConvert = 0; }
                try
                {
                    data.Amount = Decimal.Parse(gridView1.GetRowCellValue(i, "Amount").ToString());
                }
                catch { data.Amount = 0; }
                if (data.Amount == 0) errors = "Xem lại cột thành tiền";
                // neu phieu xuat  --> check ton kho
                if (data.QuantityCK2 < data.Quantity && radioGroup1.SelectedIndex == 0) errors = "Bạn không được đặt quá số lượng tồn kho";

                data.MMDoc = MMDoc;
                data.StockCode = txtStockCode2.Text;
                data.Posted = Posted;
                data.RefType = Int32.Parse (txtRefType.Text);
                data.INOut = INOut;
                data.MMHeader = txtMMHeader.Text;
                try
                {
                    data.RefDate = DateTime.ParseExact(txtRefDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch { data.RefDate = DateTime.Parse(txtRefDate.Text); }
                try
                {
                    if (active == "0") db.MMDocumentDetails.Add(data); //insert                
                    else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update                                
                    db.SaveChanges(); 
                    //XtraMessageBox.Show("New item inserted", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (radioGroup1.SelectedIndex == 0 && radioGroup1.SelectedIndex == 1) // gui thang tu nha may
                    {
                        // khong tinh ton kho
                    }
                    else
                    {
                        // se tinh ton kho
                        if (active == "0") update_tonkho(data.InventoryItemCode, data.Quantity??0, txtStockCode2.Text);
                    }
                }
                //catch (DbUpdateException ex) // exception khac
                catch (DbEntityValidationException ex) // exception khac
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        /*txtSQL.Text = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                        txtSQL.Text += eve.Entry.Entity.GetType().Name;
                        txtSQL.Text += eve.Entry.State;*/
                        foreach (var ve in eve.ValidationErrors)
                        {
                            // XtraMessageBox.Show(ve.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errors += eve.Entry.Entity.GetType().Name;
                            errors += eve.Entry.State;
                        }

                    }                    
                }
            }

            
            
        }

        private void update_tonkho(string inventoryItemCode, decimal quantity, string StockCode)
        {
            //kiem tra xem trong table baocaotonkho co data chưa                        
            var db = gen.GetNewEntity(); // khai bao new entity Framework                       
            var dt = db.BaoCaoTonKhoes.FirstOrDefault(x => x.StockCode == StockCode && x.CompanyCode == Globals.companycode
            &&x.InventoryItemCode == inventoryItemCode && x.FiscalYear == FiscalYear && x.FiscalPeriod == FiscalPeriod);

            //XtraMessageBox.Show("update_tonkho" + quantity.ToString() + Posted + INOut, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BaoCaoTonKho data = new BaoCaoTonKho();// class BaoCaoTonKho
            data.CompanyCode = Globals.companycode;
            data.FiscalYear = FiscalYear;
            data.FiscalPeriod = FiscalPeriod;
            data.InventoryItemCode = inventoryItemCode;
            data.StockCode = StockCode;
            txtSQL.Text = "SELECT * from BaoCaoTonKho WHERE StockCode='" + StockCode + "' AND InventoryItemCode='" + inventoryItemCode + "' AND FiscalYear=" + FiscalYear + " AND FiscalPeriod=" + FiscalPeriod;
            //XtraMessageBox.Show("update_tonkho" + txtSQL.Text, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dt != null)
            {
                // chi can update lai so lieu
                //XtraMessageBox.Show("update_tonkho2" + quantity.ToString() + Posted + INOut, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    // update lai SL trong table MMDocumentDetail
                    data.QuantityNTK = sltk(inventoryItemCode, FiscalPeriod, FiscalYear, 1, 1);
                    data.QuantityNTK2 = data.QuantityNTK + sltk(inventoryItemCode, FiscalPeriod, FiscalYear, 0, 1); // plan
                    data.QuantityXTK = sltk(inventoryItemCode, FiscalPeriod, FiscalYear, 1, 0);
                    data.QuantityXTK2 = data.QuantityXTK + sltk(inventoryItemCode, FiscalPeriod, FiscalYear, 0, 0); // plan              

                    data.QuantityCK = data.QuantityDK + data.QuantityNTK - data.QuantityXTK;
                    data.QuantityCK2 = data.QuantityDK + data.QuantityNTK2 - data.QuantityXTK2;

                    var db2 = gen.GetNewEntity(); // khai bao new entity Framework                       
                    db2.Entry(data).State = System.Data.Entity.EntityState.Modified; // update                                
                    db2.SaveChanges();
                    //txtSQL.Text = "Posted:" + Posted.ToString() + "INOut:" + INOut + data.QuantityXTK;
                    //XtraMessageBox.Show(txtSQL.Text, "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DbEntityValidationException ex) // exception khac
                {
                    errors += ex.Message;
                }
            }
            else // tao moi
            {
                errors += "Chưa có mã " + inventoryItemCode + " trong bảng tồn kho tháng này.";
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
          

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

        private void gridView_Item_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) 
            // cac ham thay doi so tien, so dong view dua vao day
        {

        }

        private void gridControl_Item_Click(object sender, EventArgs e)
        {

        }



        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                // giao thang thi inout=2 --> phieu xuat
                lblTenPhieu.Text = "--> Phiếu xuất";
            }
            else
            {
                // giao thang thi inout=1 --> phieu nhap
                lblTenPhieu.Text = "--> Phiếu nhập";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete this order?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                // xoa ton kho truoc
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    MMDocumentDetail data = new MMDocumentDetail();// class MMDocumentDetail                                        
                    data.InventoryItemCode = gridView1.GetRowCellValue(i, "InventoryItemCode").ToString();
                    try { data.Quantity = Decimal.Parse(gridView1.GetRowCellValue(i, "Quantity").ToString()); }
                    catch { data.Quantity = 0; }
                    try
                    {
                        data.QuantityCK2 = Decimal.Parse(gridView1.GetRowCellValue(i, "QuantityCK2").ToString()); // ton kho plan
                    }
                    catch { data.QuantityCK2 = 0; }

                    try
                    {
                        data.QuantityConvert = Decimal.Parse(gridView1.GetRowCellValue(i, "QuantityConvert").ToString());
                    }
                    catch { data.QuantityConvert = 0; }
                    try
                    {
                        data.Amount = Decimal.Parse(gridView1.GetRowCellValue(i, "Amount").ToString());
                    }
                    catch { data.Amount = 0; }
                    //update_tonkho(data.InventoryItemCode, 0 - data.Quantity, txtStockCode2.Text);
                }
                gen.ExcuteNonquery("delete MMDocument where MMDoc='" + MMDoc + "'"); //xoa header khi bi loi
                gen.ExcuteNonquery("delete MMDocumentDetail where MMDoc='" + MMDoc + "'");
                XtraMessageBox.Show("Xóa thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string RefType = "21"; // nhap kho
            if (INOut == 0) RefType = "31"; // xuat
            txtSQL.Text = "INOut"  + INOut;
            gen.ExcuteNonquery("update MMDocument SET Posted=1, RefType=" + RefType + ", UserName2 ='" + Globals.username + "' where MMDoc='" + MMDoc + "'"); // approve
            gen.ExcuteNonquery("update MMDocumentDetail SET Posted=1, RefType=" + RefType + " where MMDoc='" + MMDoc + "'"); // approve
             
            Posted = 1;                                                                                  //Update lai table ton kho
            for (int i = 0; i < gridView1.RowCount; i++)
            {                
                string InventoryItemCode = gridView1.GetRowCellValue(i, "InventoryItemCode").ToString();
                Decimal Quantity = Decimal.Parse(gridView1.GetRowCellValue(i, "Quantity").ToString());
                update_tonkho(InventoryItemCode, Quantity, txtStockCode2.Text);
            }
            XtraMessageBox.Show("Đã approve thành công phiếu đặt hàng này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnApprove.Visible = false;
            btnDelete.Visible = false;
            // tao chung tu FI khi phieu xuat          Nếu ko thuế thì ghi nhận N131, C5113
            //Nếu có thuế thì ghi nhận N131, C5111 và C 33311
            createFIDoc(INOut);

        }

        private void createFIDoc(int INOut)
        {
            // total amount
            decimal TotalAmount = 0;
            try
            {
                TotalAmount = Decimal.Parse(gridView1.Columns["Amount"].SummaryText);
            }
            catch
            {
                TotalAmount = 0;
            }
            // tao chung tu FI khi phieu xuat          Nếu ko thuế thì ghi nhận N131, C5113
            //Nếu có thuế thì ghi nhận N131, C5111 và C33311
            string FIDoc = DateTime.Now.ToString("yyyyMMddhhmmss"); // default tao FIDoc

            if (INOut==0) // xuat
            {
                if(cbthue.Text =="0") // khong thue               
                {
                    create_FIDocument(FIDoc);
                    create_FIDocumentDetail(FIDoc, "131", "5113", TotalAmount); // item                   
                }
                else // co thue
                {
                    decimal thue = 0;
                    try { thue = decimal.Parse(cbthue.Text); } catch { thue = 0;}
                    decimal sotienthue = Math.Round(TotalAmount * thue / 100,0);
                    decimal sotien = TotalAmount - sotienthue;
                    create_FIDocument(FIDoc);
                    create_FIDocumentDetail(FIDoc, "131", "5111", sotien); // item 511
                    create_FIDocumentDetail(FIDoc, "131", "33311", sotienthue); // item tax
                }

                if (errors == "")
                {
                    if (active == "0") XtraMessageBox.Show("New FI Doc inserted successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else XtraMessageBox.Show("FI Doc updated successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    active = "2"; // view
                    load_activeform(status);
                    btnSave.Visible = false;
                }
                else
                {
                    XtraMessageBox.Show("Errors:" + errors, "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gen.ExcuteNonquery("delete FIDocument where FIDoc='" + FIDoc + "'"); //xoa header khi bi loi
                    gen.ExcuteNonquery("delete FIDocumentDetail where FIDoc='" + FIDoc + "'");
                }
            }
        }

        private void create_FIDocumentDetail(string FIDoc, string DebitAccount, string CreditAccount, decimal amount)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework
            FIDocumentDetail data = new FIDocumentDetail();// class MMDocumentDetail
            data.RefDetailID = Guid.NewGuid();// tao guiid moi

            data.DebitAccount = DebitAccount;
            data.CreditAccount = CreditAccount;
            data.ItemNote = "Tao TK tu dong";
            data.AccountingObjectCode = txtMaKH.Text;
            data.AccountingObjectName = txtAccountingObjectName.Text;
            data.Amount = amount;
            data.FIDoc = FIDoc;
            data.CompanyCode = Globals.companycode;
            data.FIHeader = "Line TK " + CreditAccount;
            data.DocType = "PHKT";
            data.StockCode = txtStockCode2.Text;
            data.Posted = 1;
            try
            {
                data.RefDate = DateTime.ParseExact(txtRefDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch { data.RefDate = DateTime.Parse(txtRefDate.Text); }
            try
            {
                db.FIDocumentDetails.Add(data); //insert                               
                db.SaveChanges();
            }
            //catch (DbUpdateException ex) // exception khac
            catch (DbEntityValidationException ex) // exception khac
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errors += eve.Entry.Entity.GetType().Name;
                        errors += eve.Entry.State;
                    }

                }
            }

        }

        private void create_FIDocument(string FIDoc)
        {
            FIDocument data = new FIDocument();// class MMDocument
            data.RefID = Guid.NewGuid();// tao guiid moi
            data.Posted = 1; // phieu active tu dong
            data.CompanyCode = Globals.companycode;
            data.FIDoc = FIDoc;
            data.StockCode1 = txtStockCode1.Text;
            data.StockCode2 = txtStockCode2.Text;
            data.DocType = "PHKT";
            try
            {
                data.PostedDate = DateTime.ParseExact(txtPostedDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                data.PostedDate = DateTime.Parse(txtPostedDate.Text);
            }
            try
            {
                data.RefDate = DateTime.ParseExact(txtRefDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch { data.RefDate = DateTime.Parse(txtRefDate.Text); }
            //tinh lai nam, thang refdate
            FiscalYear = data.RefDate.Year;
            FiscalPeriod = data.RefDate.Month;

            data.RefNo = FIDoc;
            data.MMDoc = MMDoc; // gan MM Doc
            data.AccountingObjectCode = txtAccountingObjectCode.Text;
            data.AccountingObjectName = txtAccountingObjectName.Text;
            data.AccountingObjectAddress = txtAccountingObjectAddress.Text;
            data.FIHeader = "Phieu xuat tu dong"; // ly do   
            data.UserName = Globals.username; // nguoi tao phieu
            try { data.TaxCode = Int32.Parse(cbthue.Text); }
            catch { data.TaxCode = 0;}
            
            //sum
            try
            {
                data.TotalAmount = Decimal.Parse(gridView1.Columns["Amount"].SummaryText);
            }
            catch
            {
                errors = "loi totalamount";
            }

            if (data.TotalAmount == 0) errors = "Xem lại cột Thành tiền";

            var db = gen.GetNewEntity(); // khai bao new entity Framework

            try
            {
               db.FIDocuments.Add(data); //insert                               
               db.SaveChanges();
            }
            catch (DbEntityValidationException ex) // exception khac
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    txtSQL.Text = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                    txtSQL.Text += eve.Entry.Entity.GetType().Name;
                    txtSQL.Text += eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        XtraMessageBox.Show(ve.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                errors = txtSQL.Text;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework                   
            if (e.Column.FieldName == "InventoryItemCode")
            {
                var value = gridView1.GetRowCellValue(e.RowHandle, e.Column);
                var dt = db.BaoCaoTonKhoes.FirstOrDefault(x => x.InventoryItemCode == (string)value && x.CompanyCode == Globals.companycode && x.FiscalYear == FiscalYear
                    && x.FiscalPeriod == FiscalPeriod && x.StockCode == txtStockCode2.Text); // so luong ton kho >0 moi cho dat
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "InventoryItemName", dt.InventoryItemName);
                    gridView1.SetRowCellValue(e.RowHandle, "Unit", dt.Unit);
                    gridView1.SetRowCellValue(e.RowHandle, "UnitPrice", dt.UnitPrice);
                    gridView1.SetRowCellValue(e.RowHandle, "QuantityCK2", dt.QuantityCK2); //set so du cuoi ky

                    if (gridView1.GetFocusedRowCellValue(colQuantity) == "")
                    {
                        qty = 0;
                    }
                    else if (gridView1.GetFocusedRowCellValue(colQuantityConvert) == "")
                    {
                        gridView1.SetFocusedRowCellValue(colQuantityConvert, 0);
                    }
                    else if (gridView1.GetFocusedRowCellValue(colUnitPrice) == "")
                    {
                        price = 0;
                    }
                    else
                    {
                        qty = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colQuantity));
                        price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colUnitPrice));
                        amount = qty * price;
                        gridView1.SetFocusedRowCellValue(colAmount, amount);
                    }
                }
            }
            if (e.Column == colQuantity)
            {
                qty = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colQuantity));
                price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colUnitPrice));
                amount = qty * price;
                gridView1.SetFocusedRowCellValue(colAmount, amount);
            }
            if (e.Column == colUnitPrice)
            {
                qty = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colQuantity));
                price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colUnitPrice));
                amount = qty * price;
                gridView1.SetFocusedRowCellValue(colAmount, amount);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (active=="2" && txtRefType.Text=="11") // don dat hang
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("dondathangthongtin");
                F.getMMDoc(MMDoc);
                F.ShowDialog();
            }else if (active == "2" && txtRefType.Text == "31") // phieu xuat
            {
                Frm_nhapxuat F = new Frm_nhapxuat();
                F.gettsbt("pxkbienbanvatddh"); // Biên bản giao nhận hàng
                F.getMMDoc(MMDoc);
                F.ShowDialog();
            }


        }

        private void btnPTTM_Click(object sender, EventArgs e)
        {
            Globals.transactioncode = "PTTM";
            Frm_FIDocument_New m = new Frm_FIDocument_New();
            m.getactive("0"); // create phieu FI   
            m.getMMDoc(MMDoc);
            m.getStockCode2(txtStockCode2.Text);
            m.getMaKH(txtMaKH.Text);            
            m.ShowDialog();
        }

        private void ViewDAT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStockCode1.Text == "[EditValue is null]")
            {
                XtraMessageBox.Show("Vui lòng nhập mã kho đặt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockCode1.Focus();
            }
            else if(txtStockCode2.Text == "[EditValue is null]" && txtRefType.Text=="11") // đặt hàng nội bộ
            {
                XtraMessageBox.Show("Vui lòng nhập mã kho cung ứng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockCode2.Focus();
            }
            else if (txtAccountingObjectCode.Text == "[EditValue is null]")
            {
                XtraMessageBox.Show("Vui lòng nhập mã đối tượng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountingObjectCode.Focus();
            }
            else if (txtRefDate.Text == "" || txtPostedDate.Text=="")
            {
                XtraMessageBox.Show("Vui lòng nhập ngày", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefDate.Focus();
            }
            else if (txtMMHeader.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập ô lý do", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountingObjectCode.Focus();
            }            
            else
            {
                errors = "";
                create_MMDocument(MMDoc); // tao header
                create_MMDocumentDetail(MMDoc); // item
                                                //checked xem co loi ko moi bao;
                if (errors == "")
                {
                    if (active == "0") XtraMessageBox.Show("New MM Doc inserted successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else XtraMessageBox.Show("MM Doc updated successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    active = "2"; // view
                    load_activeform(status);
                    btnSave.Visible = false;
                }
                else
                {
                    XtraMessageBox.Show("Errors:" + errors, "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gen.ExcuteNonquery("delete MMDocument where MMDoc='" + MMDoc + "'"); //xoa header khi bi loi
                    gen.ExcuteNonquery("delete MMDocumentDetail where MMDoc='" + MMDoc + "'");
                }
                     
                
            }
            
        }

        private void txtStockCode1_EditValueChanged(object sender, EventArgs e)
        {
            load_txtAccountingObjectCode();

            var db = gen.GetNewEntity(); // khai bao new entity Framework                   
            var dt = db.Stocks.FirstOrDefault(x => x.StockCode == txtStockCode1.Text && x.CompanyCode == Globals.companycode);
            if (dt != null)
            {
                txtStockName1.Text = dt.StockName;
            }
        }

        private void load_txtStockCode2()
        {
            DataTable temp2 = new DataTable();
            temp2.Clear();

            temp2.Columns.Add("Stock Code");
            temp2.Columns.Add("Stock Name");
            var ctx3 = gen.GetNewEntity(); // khai bao new entity Framework
            var query3 = ctx3.Stocks
            .Where(c => c.CompanyCode == Globals.companycode)
            .OrderBy(c => c.StockCode);
            foreach (var data in query3)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = data.StockCode;
                dr[1] = data.StockName;
                temp2.Rows.Add(dr);
            }
            txtStockCode2.Properties.DataSource = temp2;
            txtStockCode2.Properties.DisplayMember = "Stock Code";
            txtStockCode2.Properties.ValueMember = "Stock Code";
        }
    }
}