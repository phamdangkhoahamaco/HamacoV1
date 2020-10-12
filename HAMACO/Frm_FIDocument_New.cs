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
using System.Globalization;
using System.Data.Entity.Validation;
using DevExpress.XtraSplashScreen;

namespace HAMACO
{
    public partial class Frm_FIDocument_New : DevExpress.XtraEditors.XtraForm
    {
        string active = "", FIDoc = "", MMDoc = "", MaKH = "", StockCode2 = "";
        gencon gen = new gencon();
        Guid RefID; // RefID cua FIDocument
        Boolean status;
        int FiscalYear, FiscalPeriod, Posted;        
        string errors = "";
        DataTable danhmuc = new DataTable();
        public Frm_FIDocument_New()
        {
            InitializeComponent();
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
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public string getStockCode2(string a)
        {
            StockCode2 = a;
            return StockCode2;
        }
        public string getFIDoc(string a)
        {
            FIDoc = a;
            return FIDoc;
        }
        public string getMaKH(string a)
        {
            MaKH = a;
            return MaKH;
        }
        public string getMMDoc(string a)
        {
            MMDoc = a;
            return MMDoc;
        }
        private void Frm_FIDocument_New_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(Frm_wait), true, true, false);
            if (Globals.transactioncode == "PTTM") this.Text = "Phiếu thu tiền mặt";
            else if (Globals.transactioncode == "PCTM") this.Text = "Phiếu chi tiền mặt";
            else if (Globals.transactioncode == "PCNH") this.Text = "Phiếu chi ngân hàng";
            else if (Globals.transactioncode == "PTNH") this.Text = "Phiếu thu ngân hàng";
            else if (Globals.transactioncode == "PHKT") this.Text = "Phiếu kế toán";
            txtDocType.Text = Globals.transactioncode;            

            //LOAD active fields (edit/create/view)
            status = false; //0: Create, 1: Edit; 2 :view readonly
            danhmuc = gen.GetTable("select STT,DebitAccount,CreditAccount from DANHMUC where Phieu='" + Globals.transactioncode.Trim() + "' order by STT");

            if (active == "") active = "0";
            if (active == "2") status =  true;
            if (active == "0")
            {
                txtMaKH.Visible = false; txtAccountingObjectCode.Visible = true;
                load_txtStockCode1();                
                load_txtDanhMuc();
            }
            else
            {
                load_txtStockCode1();
                txtMaKH.Visible = true;
                txtAccountingObjectCode.Visible = false;
            }

            load_cbthue(); // thue xuat
            load_activeform(status);
            load_grid_item(); // line item table FI Document Detail
            SplashScreenManager.CloseForm(false);
        }

        private void load_cbthue()
        {
            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            //cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");
        }

        private void load_txtDanhMuc()
        {
            string SQLString = "SELECT STT,DanhMuc as 'Danh mục',STUFF((SELECT Distinct ' ' + DebitAccount FROM (select * from danhmuc where Phieu='" + Globals.transactioncode.Trim() + "') T ";
            SQLString += "WHERE (STT = S.STT) FOR XML PATH ('')),1,1,'') as 'Tài khoản nợ',STUFF((SELECT Distinct ' ' + CreditAccount FROM (select * from danhmuc where Phieu='" + Globals.transactioncode.Trim() + "') T ";
            SQLString += "WHERE (STT = S.STT) FOR XML PATH ('')),1,1,'') AS 'Tài khoản có' FROM (select * from danhmuc where Phieu='" + Globals.transactioncode.Trim() + "') S GROUP BY STT,DanhMuc";
            txtDanhMuc.Properties.DataSource = gen.GetTable(SQLString);
            txtDanhMuc.Properties.DisplayMember = "Danh mục";
            txtDanhMuc.Properties.ValueMember = "STT";

            txtDanhMuc.Properties.View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtDanhMuc.Properties.View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            txtDanhMuc.Properties.PopupFormSize = new Size(700, 500);
            txtDanhMuc.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
        }

        private void load_grid_item()
        {
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var dt = ctx.FIDocumentDetails
                .Where(c => c.FIDoc == FIDoc)
                .ToList();
            gridControl_Item.DataSource = new BindingList<FIDocumentDetail>(dt);            

            if (active == "2")
            {
                gridView1.OptionsBehavior.Editable = false;
                btnSave.Visible = false;
            }
            if (active == "1" || active == "2")
            {
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                //colInventoryItemCode.Visible = false;
            }
            else
            {
                //colInventoryItemCode2.Visible = false; // hidden cot maHH
            }
        }

        private void load_creditaccount()
        {
            string SQL = "";
            if (Globals.transactioncode == "PCTM")
            {
                SQL = "select distinct AccountNumber, AccountName from Account where AccountCategoryID='111' and IsParent=0";
            }
            else if (Globals.transactioncode == "PCNH")
            {
                SQL = "select distinct AccountNumber, AccountName from Account where AccountCategoryID='112' and IsParent=0";
            }
            else if (Globals.transactioncode == "PTTM" || Globals.transactioncode == "PTNH" || Globals.transactioncode == "PHKT")
            {
                SQL = "select distinct AccountNumber, b.AccountName from DANHMUC a, Account b";
                SQL += " where a.CreditAccount = b.AccountNumber and Phieu = '" + Globals.transactioncode + "' AND STT = " + txtDanhMuc.EditValue;
            }
            try
            {
                rep_creditaccount.DataSource = gen.GetTable(SQL);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "load_account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            rep_creditaccount.ValueMember = "AccountNumber";
            rep_creditaccount.DisplayMember = "AccountNumber";

            rep_creditaccount.NullText = @"Chọn tài khoản có";
            colCreditAccount.ColumnEdit = rep_creditaccount;
        }

        private void load_debitaccount()
        {
            string SQL = "";
            if (Globals.transactioncode=="PCTM" || Globals.transactioncode == "PCNH" || Globals.transactioncode == "PHKT")
            {
                SQL = "select distinct AccountNumber, b.AccountName from DANHMUC a, Account b";
                SQL += " where a.DebitAccount = b.AccountNumber and Phieu = '" + Globals.transactioncode + "' AND STT = " + txtDanhMuc.EditValue;
            }else if (Globals.transactioncode == "PTTM")
            {
                SQL = "select distinct AccountNumber, AccountName from Account where AccountCategoryID='111' and IsParent=0";
            }
            else if (Globals.transactioncode == "PTNH")
            {
                SQL = "select distinct AccountNumber, AccountName from Account where AccountCategoryID='112' and IsParent=0";
            }
            try
            {
                rep_debitaccount.DataSource = gen.GetTable(SQL);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "load_debitaccount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            rep_debitaccount.ValueMember = "AccountNumber";
            rep_debitaccount.DisplayMember = "AccountNumber";

            rep_debitaccount.NullText = @"Chọn tài khoản nợ";
            colDebitAccount.ColumnEdit = rep_debitaccount;

        }

        private void txtDanhMuc_EditValueChanged(object sender, EventArgs e)
        {
            load_debitaccount(); // dropbox account khi select TN No
            load_creditaccount(); // dropbox account khi select Tk Co
            load_makh(); // dropbox khachhang + txtAccountingObjectCode
            txtAccountingObjectCode.Text = MaKH; // gan value truyen tham so
            //load_txtAccountingObjectCode(); // load cai nay la nang nhat ne
            txtFIHeader.Text = txtDanhMuc.Text;          
            
        }

        private void load_makh()
        {
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

            rep_maKH.DataSource = tmp;
            txtAccountingObjectCode.Properties.DataSource = tmp;

            rep_maKH.ValueMember = "AccountingObjectCode";
            rep_maKH.DisplayMember = "AccountingObjectCode";
            txtAccountingObjectCode.Properties.DisplayMember = "AccountingObjectCode";
            txtAccountingObjectCode.Properties.ValueMember = "AccountingObjectCode";

            rep_maKH.NullText = @"Chọn mã KH";
            colAccountingObjectCode.ColumnEdit = rep_maKH;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework                   
            if (e.Column.FieldName == "AccountingObjectCode")
            {
                var value = gridView1.GetRowCellValue(e.RowHandle, e.Column);
                var dt = db.AccountingObjects.FirstOrDefault(x => x.AccountingObjectCode == (string)value && x.CompanyCode == Globals.companycode); 
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "AccountingObjectName", dt.AccountingObjectName);                    
                }
                
            }else if (e.Column.FieldName == "DebitAccount" || e.Column.FieldName == "DebitAccount2")
            {
                var value = gridView1.GetRowCellValue(e.RowHandle, e.Column);
                var dt = db.Accounts.FirstOrDefault(x => x.AccountNumber == (string)value);
                if (dt != null)
                {
                    txtTKNo.Text = dt.AccountName;
                }
            }
            else if (e.Column.FieldName == "CreditAccount")
            {
                var value = gridView1.GetRowCellValue(e.RowHandle, e.Column);
                var dt = db.Accounts.FirstOrDefault(x => x.AccountNumber == (string)value);
                if (dt != null)
                {
                    txtTKCo.Text = dt.AccountName;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //var db = gen.GetNewEntity(); // khai bao new entity Framework    
            //var value = gridView1.GetRowCellValue(e.RowHandle, e.Column);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStockCode1.Text == "[EditValue is null]")
            {
                XtraMessageBox.Show("Vui lòng nhập mã kho đặt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockCode1.Focus();
            }
            else if (txtStockCode2.Text == "[EditValue is null]") // đặt hàng nội bộ
            {
                XtraMessageBox.Show("Vui lòng nhập mã kho cung ứng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockCode2.Focus();
            }
            else if (txtAccountingObjectCode.Text == "[EditValue is null]")
            {
                XtraMessageBox.Show("Vui lòng nhập mã đối tượng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountingObjectCode.Focus();
            }
            else if (txtRefDate.Text == "" || txtPostedDate.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập ngày", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefDate.Focus();
            }
            else if (txtFIHeader.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập ô lý do", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountingObjectCode.Focus();
            }
            else
            {
                errors = "";
                create_FIDocument(FIDoc); // tao header
                create_FIDocumentDetail(FIDoc); // item
                                                //checked xem co loi ko moi bao;
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

        private void create_FIDocumentDetail(string FIDoc)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework
            txtSQL.Text += gridView1.RowCount;
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                
                FIDocumentDetail data = new FIDocumentDetail();// class MMDocumentDetail
                if (active == "0") data.RefDetailID = Guid.NewGuid();// tao guiid moi
                else data.RefDetailID = Guid.Parse(gridView1.GetRowCellValue(i, "RefDetailID").ToString());

                data.DebitAccount = gridView1.GetRowCellValue(i, "DebitAccount").ToString();
                data.CreditAccount = gridView1.GetRowCellValue(i, "CreditAccount").ToString();
                try {
                    data.ItemNote = gridView1.GetRowCellValue(i, "ItemNote").ToString();
                }
                catch { }
                
                data.AccountingObjectCode = gridView1.GetRowCellValue(i, "AccountingObjectCode").ToString();
                data.AccountingObjectName = gridView1.GetRowCellValue(i, "AccountingObjectName").ToString();
                try
                {
                    data.Amount = Decimal.Parse(gridView1.GetRowCellValue(i, "Amount").ToString());
                }
                catch { data.Amount = 0; }
                if (data.Amount == 0) errors = "Xem lại cột thành tiền";                                

                data.FIDoc = FIDoc;
                data.CompanyCode = Globals.companycode;
                data.FIHeader = txtFIHeader.Text;
                data.DocType = txtDocType.Text;
                data.StockCode = txtStockCode2.Text;
                data.Posted = Posted;
                try
                {
                    data.RefDate = DateTime.ParseExact(txtRefDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch { data.RefDate = DateTime.Parse(txtRefDate.Text); }
                try
                {
                    if (active == "0") db.FIDocumentDetails.Add(data); //insert                
                    else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update                                
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
        }

        private void create_FIDocument(string FIDoc)
        {
            FIDocument data = new FIDocument();// class MMDocument
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
                else data.Posted = 1;
            }
            Posted = data.Posted??0;

            data.CompanyCode = Globals.companycode;
            data.FIDoc = FIDoc;
            data.MMDoc = txtMMDoc.Text;
            data.StockCode1 = txtStockCode1.Text;
            data.StockCode2 = txtStockCode2.Text;
            data.DocType = txtDocType.Text;


            try { data.TaxCode = Int32.Parse(cbthue.Text); }
            catch { data.TaxCode = 0; }

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
            data.AccountingObjectCode = txtAccountingObjectCode.Text;
            data.AccountingObjectName = txtAccountingObjectName.Text;
            data.AccountingObjectAddress = txtAccountingObjectAddress.Text;            
            data.FIHeader = txtFIHeader.Text; // ly do   
            data.UserName = Globals.username; // nguoi tao phieu
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
                if (active == "0") db.FIDocuments.Add(data); //insert                
                else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update
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

        private void load_activeform(bool status)
        {
            txtCompanyCode.ReadOnly = status; txtCompanyCode.Text = Globals.companycode;
            txtFIDoc.ReadOnly = status;

            if (active == "0") FIDoc = DateTime.Now.ToString("yyyyMMddhhmmss");
            if (active == "0") txtUserName.Text = Globals.username;
            txtFIDoc.Text = FIDoc;
            txtMMDoc.Text = MMDoc;            
            //txtAccountingObjectName.Text = MaKH;
            //txtDanhMuc.Text = "Thu tiền khách hàng";
            txtStockCode2.Text = StockCode2; //get value
            txtStockCode1.Text = StockCode2; //get value

            txtAccountingObjectCode.ReadOnly = status;
            txtRefDate.ReadOnly = status;
            txtPostedDate.ReadOnly = status;
            txtAccountingObjectAddress.ReadOnly = status;
            txtNguoiNop.ReadOnly = status;
            txtFIHeader.ReadOnly = status;
            cbthue.ReadOnly = status;
            txtMMDoc.ReadOnly = status;


            //defaut date

            if (active == "0") txtPostedDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.ToString());
            if (active == "0") txtRefDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.ToString());
            //tinh lai nam, thang refdate
            if (active == "0") FiscalYear = DateTime.Now.Year;
            if (active == "0") FiscalPeriod = DateTime.Now.Month;

            if (active == "2" || active == "1") // display or edit
            {
                lblDanhMuc.Visible = false;
                txtDanhMuc.Visible = false;
                colAccountingObjectCode.Visible = false;
                colAccountingObjectCode2.Visible = true;
                colDebitAccount.Visible = false;
                colDebitAccount2.Visible = true;
                colCreditAccount.Visible = false;
                colCreditAccount2.Visible = true;
                var db = gen.GetNewEntity(); // khai bao new entity Framework                   
                var dt = db.FIDocuments.FirstOrDefault(x => x.FIDoc == FIDoc && x.CompanyCode == Globals.companycode);
                if (dt != null)
                {
                    RefID = dt.RefID;
                    //txtStockCode1.Text = dt.StockCode1;
                    txtStockCode1.Enabled = false;
                    txtStockCode2.Enabled = false;

                    txtStockName1.Text = gen.GetString2("Stock","StockName","StockCode", dt.StockCode1);
                    txtStockName2.Text = gen.GetString2("Stock", "StockName", "StockCode", dt.StockCode2);

            
                    txtStockCode1.EditValue = dt.StockCode1;
                    txtStockCode2.EditValue = dt.StockCode2;
                    txtUserName.Text = dt.UserName;

                    txtAccountingObjectCode.EditValue = dt.AccountingObjectCode;
                    txtMaKH.Text = dt.AccountingObjectCode; 
                    txtAccountingObjectName.Text = dt.AccountingObjectName;
                    txtAccountingObjectAddress.Text = dt.AccountingObjectAddress;
                    cbthue.Text = dt.TaxCode.ToString();

                    txtDocType.Text = dt.DocType.ToString();
                    if (txtDocType.Text == "PTTM") this.Text = "Phiếu thu tiền mặt";
                    else if (txtDocType.Text == "PCTM") this.Text = "Phiếu chi tiền mặt";
                    else if (txtDocType.Text == "PCNH") this.Text = "Phiếu chi ngân hàng";
                    else if (txtDocType.Text == "PTNH") this.Text = "Phiếu thu ngân hàng";
                    else if (txtDocType.Text == "PHKT") this.Text = "Phiếu kế toán";
                    lblDocTypeName.Text = this.Text;
                    //XtraMessageBox.Show(txtDocType.Text + this.Text, "Approve", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtPostedDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dt.PostedDate.ToString()));
                    txtRefDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dt.RefDate.ToString()));
                    FiscalYear = dt.RefDate.Year;
                    FiscalPeriod = dt.RefDate.Month;
                    txtMMDoc.Text = dt.MMDoc;

                    txtFIHeader.Text = dt.FIHeader;
                    txtPosted.Text = dt.Posted.ToString();
                    if (txtPosted.Text == "1") lblStatus.Text = "Approved";
                    else lblStatus.Text = "Inactive";
                    txtUserName2.Text = dt.UserName2;

                    if (active == "2" && dt.Posted == 0) // view & approve=0
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
            else
            {
                colAccountingObjectCode.Visible = true;
                colAccountingObjectCode2.Visible = false;
                colDebitAccount.Visible = true;
                colDebitAccount2.Visible = false;
                colCreditAccount.Visible = true;
                colCreditAccount2.Visible = false;
            }
        }

        private void txtStockCode1_EditValueChanged(object sender, EventArgs e)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework                   
            var dt = db.Stocks.FirstOrDefault(x => x.StockCode == txtStockCode1.Text && x.CompanyCode == Globals.companycode);
            if (dt != null)
            {
                txtStockName1.Text = dt.StockName;
            }
        }

        private void txtStockCode2_EditValueChanged(object sender, EventArgs e)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework                   
            var dt = db.Stocks.FirstOrDefault(x => x.StockCode == txtStockCode2.Text && x.CompanyCode == Globals.companycode);
            if (dt != null)
            {
                txtStockName2.Text = dt.StockName;
            }
        }

        private void txtAccountingObjectCode_EditValueChanged(object sender, EventArgs e)
        {
           
            var db = gen.GetNewEntity(); // khai bao new entity Framework                   
            var dt = db.AccountingObjects.FirstOrDefault(x => x.AccountingObjectCode == txtAccountingObjectCode.Text && x.CompanyCode == Globals.companycode);
            if (dt != null)
            {
                txtAccountingObjectName.Text = dt.AccountingObjectName;
                txtAccountingObjectAddress.Text = dt.Address;
                //txtCompanyTaxCode.Text = dt.CompanyTaxCode;
            }
        }

        private void gridControl_Item_Click(object sender, EventArgs e)
        {

        }

        private void txtDocType_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            String SQL = "update FIDocument SET Posted=1, UserName2 ='" + Globals.username + "' where FIDoc='" + FIDoc + "'";
            SQL += ";update FIDocumentDetail SET Posted = 1 where FIDoc = '" + FIDoc + "'";
            errors = "";
            try
            {
                gen.ExcuteNonquery(SQL);
                
                // update table AccountPeriod
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string DebitAccount = gridView1.GetRowCellValue(i, "DebitAccount").ToString();
                    string CreditAccount = gridView1.GetRowCellValue(i, "CreditAccount").ToString();                    
                    string AccountingObjectCode = gridView1.GetRowCellValue(i, "AccountingObjectCode").ToString();
                    update_table_AccountPeriod(DebitAccount);
                    update_table_AccountPeriod(CreditAccount);
                    update_table_AccountCustomerPeriod(DebitAccount, AccountingObjectCode);
                    update_table_AccountCustomerPeriod(CreditAccount, AccountingObjectCode); // co ma KH
                    // co makh va stock code
                    update_table_AccountCustomerStockPeriod(DebitAccount, txtStockCode2.Text, AccountingObjectCode);
                    update_table_AccountCustomerStockPeriod(CreditAccount, txtStockCode2.Text, AccountingObjectCode); // co ma KH
                }
                
            }
            catch (DbEntityValidationException ex) // exception khac
            {
                errors += ex.Message;
            }

            if(errors=="") XtraMessageBox.Show("Đã approve thành công phiếu FI này", "Approve", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else XtraMessageBox.Show(errors, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);

            btnApprove.Visible = false;
            btnDelete.Visible = false;
        }

        private void update_table_AccountCustomerStockPeriod(string AccountNumber, string StockCode, string AccountingObjectCode)
        {
            // kiem tra xem trong table AccountCustomerStockPeriod co data chưa
            var db = gen.GetNewEntity(); // khai bao new entity Framework                       
            var dt = db.AccountCustomerStockPeriods.FirstOrDefault(x => x.CompanyCode == Globals.companycode && x.AccountingObjectCode == AccountingObjectCode
            && x.AccountNumber == AccountNumber && x.StockCode == StockCode && x.FiscalYear == FiscalYear && x.FiscalPeriod == FiscalPeriod);
            AccountCustomerStockPeriod data = new AccountCustomerStockPeriod();// class AccountCustomerStockPeriod
            data.CompanyCode = Globals.companycode;
            data.FiscalYear = FiscalYear;
            data.FiscalPeriod = FiscalPeriod;
            data.AccountNumber = AccountNumber;
            data.AccountingObjectCode = AccountingObjectCode;
            data.StockCode = StockCode;
            if (dt != null) // co du lieu
            {
                // chi can update lai so lieu
                data.AccountingObjectName = dt.AccountingObjectName;
                data.NoDK = dt.NoDK;
                data.CoDK = dt.CoDK;

                try
                {
                    data.PSNo = psnokh2(AccountNumber, AccountingObjectCode, StockCode, FiscalPeriod, FiscalYear);
                    data.PSCo = pscokh2(AccountNumber, AccountingObjectCode, StockCode, FiscalPeriod, FiscalYear);
                    data.NoCK = data.NoDK + data.PSNo;
                    data.CoCK = data.CoDK + data.PSCo;
                    data.LKNo = lknokh2(AccountNumber, AccountingObjectCode, StockCode, FiscalYear);
                    data.LKCo = lkcokh2(AccountNumber, AccountingObjectCode, StockCode, FiscalYear);

                    var db2 = gen.GetNewEntity(); // khai bao new entity Framework                       
                    db2.Entry(data).State = System.Data.Entity.EntityState.Modified; // update                                
                    db2.SaveChanges();
                }
                catch (DbEntityValidationException ex) // exception khac
                {
                    errors += ex.Message;
                }
            }
            else // nesu khong co thi tao moi
            {
                data.AccountingObjectName = gen.GetString2("AccountingObject", "AccountingObjectName", "AccountingObjectCode", AccountingObjectCode);
                data.NoDK = 0;
                data.CoDK = 0;
                try
                {
                    data.PSNo = psnokh2(AccountNumber, AccountingObjectCode, StockCode, FiscalPeriod, FiscalYear);
                    data.PSCo = pscokh2(AccountNumber, AccountingObjectCode, StockCode, FiscalPeriod, FiscalYear);
                    data.NoCK = data.NoDK + data.PSNo;
                    data.CoCK = data.CoDK + data.PSCo;
                    data.LKNo = lknokh2(AccountNumber, AccountingObjectCode, StockCode, FiscalYear);
                    data.LKCo = lkcokh2(AccountNumber, AccountingObjectCode, StockCode, FiscalYear);

                    var db2 = gen.GetNewEntity(); // khai bao new entity Framework                       
                    db2.AccountCustomerStockPeriods.Add(data); // insert
                    db2.SaveChanges();
                }
                catch (DbEntityValidationException ex) // exception khac
                {
                    errors += ex.Message;
                }
            }
        }

        private void update_table_AccountCustomerPeriod(string AccountNumber, string AccountingObjectCode)
        {
            // kiem tra xem trong table AccountCustomerPeriod co data chưa
            var db = gen.GetNewEntity(); // khai bao new entity Framework                       
            var dt = db.AccountCustomerPeriods.FirstOrDefault(x => x.CompanyCode == Globals.companycode && x.AccountingObjectCode == AccountingObjectCode
            && x.AccountNumber == AccountNumber && x.FiscalYear == FiscalYear && x.FiscalPeriod == FiscalPeriod);
            AccountCustomerPeriod data = new AccountCustomerPeriod();// class AccountCustomerPeriod
            data.CompanyCode = Globals.companycode;
            data.FiscalYear = FiscalYear;
            data.FiscalPeriod = FiscalPeriod;
            data.AccountNumber = AccountNumber;
            data.AccountingObjectCode = AccountingObjectCode;
            if (dt != null) // co du lieu
            {
                // chi can update lai so lieu
                data.AccountingObjectName = dt.AccountingObjectName;
                data.NoDK = dt.NoDK;
                data.CoDK = dt.CoDK;

                try
                {
                    data.PSNo = psnokh(AccountNumber, AccountingObjectCode, FiscalPeriod, FiscalYear);
                    data.PSCo = pscokh(AccountNumber, AccountingObjectCode, FiscalPeriod, FiscalYear);
                    data.NoCK = data.NoDK + data.PSNo;
                    data.CoCK = data.CoDK + data.PSCo;
                    data.LKNo = lknokh(AccountNumber, AccountingObjectCode, FiscalYear);
                    data.LKCo = lkcokh(AccountNumber, AccountingObjectCode, FiscalYear);

                    var db2 = gen.GetNewEntity(); // khai bao new entity Framework                       
                    db2.Entry(data).State = System.Data.Entity.EntityState.Modified; // update                                
                    db2.SaveChanges();
                }
                catch (DbEntityValidationException ex) // exception khac
                {
                    errors += ex.Message;
                }
            }
            else // nesu khong co thi tao moi
            {
                data.AccountingObjectName = gen.GetString2("AccountingObject", "AccountingObjectName", "AccountingObjectCode", AccountingObjectCode);
                data.NoDK = 0;
                data.CoDK = 0;
                try
                {
                    data.PSNo = psnokh(AccountNumber, AccountingObjectCode, FiscalPeriod, FiscalYear);
                    data.PSCo = pscokh(AccountNumber, AccountingObjectCode, FiscalPeriod, FiscalYear);
                    data.NoCK = data.NoDK + data.PSNo;
                    data.CoCK = data.CoDK + data.PSCo;
                    data.LKNo = lknokh(AccountNumber, AccountingObjectCode, FiscalYear);
                    data.LKCo = lkcokh(AccountNumber, AccountingObjectCode, FiscalYear);

                    var db2 = gen.GetNewEntity(); // khai bao new entity Framework                       
                    db2.AccountCustomerPeriods.Add(data); // insert
                    db2.SaveChanges();
                }
                catch (DbEntityValidationException ex) // exception khac
                {
                    errors += ex.Message;
                }
            }
        }
        private decimal lknokh2(string AccountNumber, string AccountingObjectCode, string StockCode, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.DebitAccount == AccountNumber && c.StockCode == StockCode
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1 && c.AccountingObjectCode == AccountingObjectCode);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal lkcokh2(string AccountNumber, string AccountingObjectCode, string StockCode, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.CreditAccount == AccountNumber && c.StockCode == StockCode
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1 && c.AccountingObjectCode == AccountingObjectCode);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }

        private decimal lknokh(string AccountNumber, string AccountingObjectCode, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.DebitAccount == AccountNumber 
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1 && c.AccountingObjectCode == AccountingObjectCode);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal lkcokh(string AccountNumber, string AccountingObjectCode, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.CreditAccount == AccountNumber
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1 && c.AccountingObjectCode == AccountingObjectCode);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal psnokh2(string AccountNumber, string AccountingObjectCode, string StockCode, int FiscalPeriod, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.DebitAccount == AccountNumber && c.RefDate.Value.Month == FiscalPeriod
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1 && c.AccountingObjectCode == AccountingObjectCode && c.StockCode == StockCode);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal pscokh2(string AccountNumber, string AccountingObjectCode, string StockCode, int FiscalPeriod, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.CreditAccount == AccountNumber && c.RefDate.Value.Month == FiscalPeriod
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1 && c.AccountingObjectCode == AccountingObjectCode && c.StockCode == StockCode);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal psnokh(string AccountNumber, string AccountingObjectCode, int FiscalPeriod, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.DebitAccount == AccountNumber && c.RefDate.Value.Month == FiscalPeriod
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1 && c.AccountingObjectCode == AccountingObjectCode);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal pscokh(string AccountNumber, string AccountingObjectCode, int FiscalPeriod, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.CreditAccount == AccountNumber && c.RefDate.Value.Month == FiscalPeriod
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1 && c.AccountingObjectCode == AccountingObjectCode);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }

        private void update_table_AccountPeriod(string AccountNumber)
        {
            // kiem tra xem trong table AccountPeriod co data chưa
            var db = gen.GetNewEntity(); // khai bao new entity Framework                       
            var dt = db.AccountPeriods.FirstOrDefault(x => x.CompanyCode == Globals.companycode
            && x.AccountNumber == AccountNumber && x.FiscalYear == FiscalYear && x.FiscalPeriod == FiscalPeriod);
            AccountPeriod data = new AccountPeriod();// class AccountPeriod
            data.CompanyCode = Globals.companycode;
            data.FiscalYear = FiscalYear;
            data.FiscalPeriod = FiscalPeriod;
            data.AccountNumber = AccountNumber;
            if (dt != null) // co du lieu
            {
                // chi can update lai so lieu
                data.AccountName = dt.AccountName;
                data.NoDK = dt.NoDK;
                data.CoDK = dt.CoDK;
                
                try
                {
                    data.PSNo = psno(AccountNumber, FiscalPeriod, FiscalYear);
                    data.PSCo = psco(AccountNumber, FiscalPeriod, FiscalYear);
                    data.NoCK = data.NoDK + data.PSNo;
                    data.CoCK = data.CoDK + data.PSCo;
                    data.LKNo = lkno(AccountNumber, FiscalYear);
                    data.LKCo = lkco(AccountNumber, FiscalYear);

                    var db2 = gen.GetNewEntity(); // khai bao new entity Framework                       
                    db2.Entry(data).State = System.Data.Entity.EntityState.Modified; // update                                
                    db2.SaveChanges();
                }
                catch (DbEntityValidationException ex) // exception khac
                {
                    errors += ex.Message;
                }
            }
            else // nesu khong co thi tao moi
            {
                data.AccountName = gen.GetString2("Account", "AccountName", "AccountNumber", AccountNumber);
                data.NoDK = 0;
                data.CoDK = 0;
                try
                {
                    data.PSNo = psno(AccountNumber, FiscalPeriod, FiscalYear);
                    data.PSCo = psco(AccountNumber, FiscalPeriod, FiscalYear);
                    data.NoCK = data.NoDK + data.PSNo;
                    data.CoCK = data.CoDK + data.PSCo;
                    data.LKNo = lkno(AccountNumber, FiscalYear);
                    data.LKCo = lkco(AccountNumber, FiscalYear);

                    var db2 = gen.GetNewEntity(); // khai bao new entity Framework                       
                    db2.AccountPeriods.Add(data); // insert
                    db2.SaveChanges();
                }
                catch (DbEntityValidationException ex) // exception khac
                {
                    errors += ex.Message;
                }
            }
        }

        private decimal lkno(string AccountNumber, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.DebitAccount == AccountNumber 
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal lkco(string AccountNumber, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.CreditAccount == AccountNumber
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }

        private decimal psno(string AccountNumber, int FiscalPeriod, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.DebitAccount == AccountNumber && c.RefDate.Value.Month == FiscalPeriod
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal psco(string AccountNumber, int FiscalPeriod, int FiscalYear)
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var luyke = ctx.FIDocumentDetails.Where(c => c.CreditAccount == AccountNumber && c.RefDate.Value.Month == FiscalPeriod
            && c.RefDate.Value.Year == FiscalYear && c.Posted == 1);

            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;

            return kq;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete this FI Document?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {               
                gen.ExcuteNonquery("delete FIDocument where FIDoc='" + FIDoc + "'"); //xoa header khi bi loi
                gen.ExcuteNonquery("delete FIDocument where FIDoc='" + FIDoc + "'");
                XtraMessageBox.Show("Xóa thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void load_txtAccountingObjectCode()
        {
            DataTable temp2 = new DataTable();
            temp2.Clear();

            temp2.Columns.Add("Code");
            temp2.Columns.Add("Name");
            if (active == "0")
            {
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
            }
            
            txtAccountingObjectCode.Properties.DataSource = temp2;
            txtAccountingObjectCode.Properties.DisplayMember = "Code";
            txtAccountingObjectCode.Properties.ValueMember = "Code";
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

        private void load_txtStockCode1() // load ca 2
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
            txtStockCode2.Properties.DataSource = temp2;
            txtStockCode2.Properties.DisplayMember = "Stock Code";
            txtStockCode2.Properties.ValueMember = "Stock Code";
        }
    }
}