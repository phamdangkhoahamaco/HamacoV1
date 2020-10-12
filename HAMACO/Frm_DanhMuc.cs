using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources; // import bo thu vien cua HAMACO
using System.Linq;
using System.Data.Entity;

namespace HAMACO
{
    public partial class Frm_DanhMuc : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string username = Globals.username;
        string userid = Globals.userid;
        string SQLString = "";
        string ngaychungtu = "";
        public Frm_DanhMuc()
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


        private void Frm_DanhMuc_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "User: " + Globals.username + "; Transaction: " + Globals.transactioncode;
            this.Text = gen.GetString2("Transactions", "TransactionName", "TransactionCode", Globals.transactioncode);
            lblTitle.Text = this.Text;
            
            //default value
            lblStockName.Text = ""; lblBranchName.Text = "";
            txtYear.Text = DateTime.Now.Year.ToString();
            txtMonth.Text = DateTime.Now.Month.ToString();            
            //ledv.Visible = false; 
            txtSQL.Visible = false;
            
            groupBox1.Visible = false; groupBox2.Visible = false;
            if (Globals.transactioncode == "CU00") groupBox1.Visible = true;
            if (Globals.transactioncode == "VE00") groupBox1.Visible = true;
            if (Globals.transactioncode == "EM00") groupBox1.Visible = true;
            if (Globals.transactioncode == "HDKH") groupBox2.Visible = true;
            if (Globals.transactioncode == "PLBL") groupBox2.Visible = true;
            if (Globals.transactioncode == "DNDH") groupBox2.Visible = true;
            //DNDH

            // kiem tra permission                       
            if (gen.checkPermission(Globals.username, Globals.transactioncode, Globals.companycode) == false)
            {
                XtraMessageBox.Show("You do not the permission to execute this transaction code " + Globals.transactioncode, "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            lvpq.Visible = false;

            
            load_ledv(); // load form don vi
            load_lekho(); // load form kho

            // just for testing
            txtMonth.Text = "1";
            lekho.Text = "01";
            // load content
            lvpq.Visible = true;
            if (Globals.transactioncode == "BR00") load_form_donvi();
            else if (Globals.transactioncode == "CO00") load_form_company(); // companies
            else if (Globals.transactioncode == "ST00") load_form_kho();
            else if (Globals.transactioncode == "EM00") load_form_employee(); // join 2 table
            else if (Globals.transactioncode == "CU00") load_form_customer();
            else if (Globals.transactioncode == "VE00") load_form_vendor();
            else if (Globals.transactioncode == "HDKH") load_form_contract();//tsbthdkh - hop dong --> join 3 table
            else if (Globals.transactioncode == "PLBL") load_form_PLBL();//tsbtplbl - hop dong --> join 3 table
            else if (Globals.transactioncode == "DMVT") load_form_DMVT(); //Loại vật tư hàng hóa, công cụ dụng cụ
            else if (Globals.transactioncode == "VTHH") load_form_VTHH(); // Vật tư hàng hóa
            else if (Globals.transactioncode == "HTTK") load_form_HTTK(); //Hệ thống tài khoản
            else if (Globals.transactioncode == "NHTK") load_form_NHTK(); //Nhóm tài khoản
            else if (Globals.transactioncode == "DNDH") load_form_DNDH(); //Đơn đặt hàng
        }

        private void load_lekho()
        {
            DataTable da = new DataTable();
            var db= gen.GetNewEntity(); // khai bao new entity Framework
            {
                var query = db.Stocks
                    .Where(p =>  p.CompanyCode == Globals.companycode)
                    .OrderBy(p => p.StockCode)
                    .Select(p => new { p.StockCode, p.StockName })
                    .ToList();
                da = gen.ConvertToDataTable(query);
            }

            lekho.Properties.DataSource = da;
            lekho.Properties.ValueMember = "StockCode";
            lekho.Properties.DisplayMember = "StockCode";
        }

        private void load_ledv() // don vi
        {
            DataTable da = new DataTable();
            var db= gen.GetNewEntity(); // khai bao new entity Framework
            {
                var query = db.Branches
                         .Where(p =>  p.CompanyCode == Globals.companycode)
                         .Select(p => new { p.BranchCode, p.BranchName })
                         .OrderBy(p=>p.BranchCode)
                         .ToList();
                da = gen.ConvertToDataTable(query);
            }        

            ledv.Properties.DataSource = da;
            ledv.Properties.ValueMember = "BranchCode";
            ledv.Properties.DisplayMember = "BranchCode";            
        }

  

        private void btnContent_Click(object sender, EventArgs e)
        {
            lvpq.Visible = true;
            if (Globals.transactioncode == "BR00") load_form_donvi();
            else if (Globals.transactioncode == "CO00") load_form_company(); // companies
            else if (Globals.transactioncode == "ST00") load_form_kho();
            else if (Globals.transactioncode == "EM00") load_form_employee(); // join 2 table
            else if (Globals.transactioncode == "CU00") load_form_customer();
            else if (Globals.transactioncode == "VE00") load_form_vendor();
            else if (Globals.transactioncode == "HDKH") load_form_contract();//tsbthdkh - hop dong --> join 3 table
            else if (Globals.transactioncode == "PLBL") load_form_PLBL();//tsbtplbl - hop dong --> join 3 table            
            else if (Globals.transactioncode == "HTTK") load_form_HTTK(); //Hệ thống tài khoản
            else if (Globals.transactioncode == "NHTK") load_form_NHTK(); //Nhóm tài khoản
            else if (Globals.transactioncode == "DNDH") load_form_DNDH(); //Đơn đặt hàng
            else if (Globals.transactioncode == "DMVT") load_form_DMVT(); //Loại vật tư hàng hóa, công cụ dụng cụ
            else if (Globals.transactioncode == "VTHH") load_form_VTHH(); // Vật tư hàng hóa

        }

        private void load_form_VTHH()
        {
            //tsbt = "tsbtvthh";
            //refresh("DImnuDictionaryInventoryItem");
            //hang = gen.GetTable("select InventoryItemID as 'ID',InventoryItemCode as 'Mã hàng hóa',InventoryItemName as 'Tên hàng',Unit as 'Đơn vị tính', ConvertUnit as 'Đơn vị quy đổi',ConvertRate as 'Tỷ lệ quy đổi' from InventoryItem with (NOLOCK) order by InventoryItemCode");
            //select InventoryItemID,InventoryItemCode,InventoryItemName,c.Unit,c.ConvertUnit,c.ConvertRate,d.InventoryCategoryName,c.Inactive from InventoryItem a with (NOLOCK), InventoryItemCategory b with (NOLOCK) where a.InventoryCategoryID=b.InventoryCategoryID order by InventoryItemCode
            view.ViewCaption = "   Vật tư hàng hóa";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            //temp = gen.GetTable(sql);
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.InventoryItems
                .Join(ctx.InventoryItemCategories, c => c.InventoryCategoryID, d => d.InventoryCategoryID,
                  (c, d) => new { c.InventoryItemID, c.InventoryItemCode, c.InventoryItemName, c.CompanyCode,
                      c.Unit, c.ConvertUnit, c.ConvertRate, d.InventoryCategoryName, c.Inactive })
                .Where(c => c.CompanyCode == Globals.companycode)
                              .OrderBy(c => c.InventoryItemCode);

            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã vật tư hàng hóa", Type.GetType("System.String"));
            dt.Columns.Add("Tên vật tư hàng hóa", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị quy đổi", Type.GetType("System.String"));
            dt.Columns.Add("Tỷ lệ", Type.GetType("System.Double"));
            dt.Columns.Add("Loại vật tư hàng hóa, công cụ dụng cụ", Type.GetType("System.String"));
            dt.Columns.Add("Ngừng theo dõi", Type.GetType("System.Boolean"));
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.InventoryItemID;
                dr[1] = data.InventoryItemCode;
                dr[2] = data.InventoryItemName;
                dr[3] = data.Unit;
                dr[4] = data.ConvertUnit;
                if (data.ConvertRate.ToString() == "")
                    dr[5] = 1;
                else
                    dr[5] = data.ConvertRate.ToString();

                dr[6] = data.InventoryCategoryName;

                if (data.Inactive == true)
                    dr[7] = "True";
                else
                    dr[7] = "False";
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Tỷ lệ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tỷ lệ"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.OptionsView.ShowFooter = true;
        }

        private void load_form_company()
        {
            string sql = "select * FROM Companies order by CompanyCode";

            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);


            dt.Columns.Add("Code", Type.GetType("System.Double"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Address", Type.GetType("System.String"));
            dt.Columns.Add("Tax Code", Type.GetType("System.String"));            

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();                
                dt.Rows.Add(dr);
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.OptionsView.ColumnAutoWidth = false;

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Name"].BestFit();
            view.Columns["Address"].BestFit();
            view.Columns["Tax Code"].BestFit();

        }

        private void load_form_DNDH() //Đơn đặt hàng MM
        {
            /*tsbt = "tsbtddh";
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.getrole(userid);
            F.gettsbt(tsbt);
            F.getngay(ngaychungtu);
            F.ShowDialog();

            refresh("INmnuBusinessINOutwardList");
            
            refreshddh();*/
            //lblStockName.Text = gen.GetString2("Stock", "StockName","StockCode",lekho.Text,clientid);

            string sql = "select Case when Sale=0 then COALESCE(Tien,TotalAmount)-CostCap-COALESCE(TotalCost,0)-COALESCE(TotalTransport,0) else 0 end,";
            sql += "RefID,RefNo,PostedDate,RefDate,d.AccountingObjectCode,d.AccountingObjectName,b.StockCode,JournalMemo,COALESCE(Tien,TotalAmount),CostCap,";
            sql += "c.StockCode,ShippingNo,ReceiveMethod,Sale,Stock,InOut,Status,RefIDInOutward,a.Export,COALESCE(TotalTransport,0) ";
            sql += " from (select a.*,b.IsExport as Export,b.TotalAmount as Tien from (select * from DDH where Month(RefDate)='" + txtMonth.Text + "' and  Year(RefDate)='" + txtYear.Text + "') a ";
            sql += " left join  INOutward b on a.RefIDInOutward=b.RefNo) a, Stock b, Stock c, AccountingObject d where a.AccountingObjectID=d.AccountingObjectID and a.OutStockID=b.StockID and a.InStockID=c.StockID and ";
            sql += " b.StockCode ='" + lekho.Text + "' order by RefNo";

            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);


            dt.Columns.Add("Lãi lỗ", Type.GetType("System.Double"));
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Đặt hàng", Type.GetType("System.DateTime"));
            dt.Columns.Add("Xuất kho", Type.GetType("System.DateTime"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Cung ứng", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));

            dt.Columns.Add("Tiền hàng", Type.GetType("System.Double"));
            dt.Columns.Add("Giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Kho nhận", Type.GetType("System.String"));
            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));
            dt.Columns.Add("Tài xế", Type.GetType("System.String"));
            dt.Columns.Add("Trạng thái", Type.GetType("System.String"));
            dt.Columns.Add("Từ", Type.GetType("System.String"));
            dt.Columns.Add("Chuyển", Type.GetType("System.Boolean"));
            dt.Columns.Add("Nhận", Type.GetType("System.Boolean"));
            dt.Columns.Add("Xuất", Type.GetType("System.Boolean"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.Boolean"));

            dt.Columns.Add("Vận chuyển", Type.GetType("System.Double"));
            dt.Columns.Add("Lãi", Type.GetType("System.Double"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (Double.Parse(temp.Rows[i][0].ToString()) < 0)
                    dr[0] = temp.Rows[i][0].ToString();

                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dr[6] = temp.Rows[i][6].ToString();
                dr[7] = temp.Rows[i][7].ToString();
                dr[8] = temp.Rows[i][8].ToString();

                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[9] = temp.Rows[i][9].ToString();
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = temp.Rows[i][10].ToString();
                dr[11] = temp.Rows[i][11].ToString();
                dr[12] = temp.Rows[i][12].ToString();
                dr[13] = temp.Rows[i][13].ToString();
                if (temp.Rows[i][14].ToString() == "True")
                    dr[14] = "Nhập kho";
                else
                {
                    dr[14] = "Giao thẳng";
                    if (temp.Rows[i][18].ToString() != "")
                        dr[18] = "True";
                    if (temp.Rows[i][19].ToString() == "True")
                        dr[19] = "True";

                    if (Double.Parse(temp.Rows[i][20].ToString()) != 0)
                        dr[20] = temp.Rows[i][20].ToString();
                    dr[21] = temp.Rows[i][0].ToString();
                }

                if (temp.Rows[i][15].ToString() == "0")
                    dr[15] = "Công ty";
                else if (temp.Rows[i][15].ToString() == "1")
                    dr[15] = "Nhà máy";

                if (temp.Rows[i][16].ToString() == "True")
                    dr[16] = "True";
                if (temp.Rows[i][17].ToString() == "True")
                    dr[17] = "True";

                dt.Rows.Add(dr);
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[1].Visible = false;
            view.OptionsView.ColumnAutoWidth = false;

            view.Columns["Xuất kho"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Xuất kho"].DisplayFormat.FormatString = "dd/MM/yyyy";

            view.Columns["Xuất kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Đặt hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Đặt hàng"].DisplayFormat.FormatString = "dd/MM/yyyy";

            view.Columns["Đặt hàng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Tiền hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tiền hàng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tiền hàng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tiền hàng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Giá vốn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Giá vốn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Giá vốn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";


            view.Columns["Trạng thái"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Kho nhận"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Cung ứng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Số chứng từ"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Đặt hàng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Xuất kho"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            view.Columns["Hóa đơn"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Xuất"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Nhận"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Chuyển"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Từ"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Trạng thái"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;

            view.Columns["Hóa đơn"].Width = 60;
            view.Columns["Xuất"].Width = 50;
            view.Columns["Nhận"].Width = 50;
            view.Columns["Chuyển"].Width = 60;
            view.Columns["Trạng thái"].Width = 80;
            view.Columns["Từ"].Width = 70;
            view.Columns["Kho nhận"].Width = 70;
            view.Columns["Cung ứng"].Width = 70;

            view.Columns["Số chứng từ"].Width = 170;
            view.Columns["Xuất kho"].Width = 80;
            view.Columns["Đặt hàng"].Width = 80;
            view.Columns["Giá vốn"].Width = 100;
            view.Columns["Tiền hàng"].Width = 100;
            view.Columns["Mã khách"].Width = 100;
            view.Columns["Tên khách hàng"].Width = 200;

            view.Columns["Lý do"].Width = 150;
            view.Columns["Phương tiện"].Width = 150;
            view.Columns["Tài xế"].Width = 150;
            view.Columns["Vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Vận chuyển"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Vận chuyển"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Vận chuyển"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Lãi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lãi"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lãi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lãi"].SummaryItem.DisplayFormat = "{0:n0}";

            view.ExpandAllGroups();
        }

        private void load_form_NHTK() //Nhóm tài khoản
        {
            //tsbt = "tsbtntk";
            //refresh("DImnuDictionaryAccountCategory");
            view.ViewCaption = "   Nhóm tài khoản";
            //accountgroup.loadgroupaccount(lvpq, view);
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable("Select * from AccountCategory");
            dt.Columns.Add("Mã nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm", Type.GetType("System.String"));
            dt.Columns.Add("Tính chất", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                if (temp.Rows[i][2].ToString() == "0") dr[2] = "Dư nợ";
                else if (temp.Rows[i][2].ToString() == "1") dr[2] = "Dư có";
                else if (temp.Rows[i][2].ToString() == "2") dr[2] = "Lưỡng tính";
                else dr[2] = "Không có số dư";
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

        }

        private void load_form_HTTK() // Hệ thống tài khoản
        {
            //tsbt = "tsbthttk";
            //refresh("DImnuDictionaryAccount");
            view.ViewCaption = "   Hệ thống tài khoản";
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            view.Columns.Clear();            
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.Accounts
                              .Where(c =>  c.Grade == 1)
                              .OrderBy(c => c.AccountNumber);
            

            string max = ctx.Accounts
                .Select(p => p.Grade).Max().ToString();
            int maxi = int.Parse(max);

            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tiếng anh", Type.GetType("System.String"));
            dt.Columns.Add("Nhóm tài khoản", Type.GetType("System.String"));//4
            dt.Columns.Add("Tính chất", Type.GetType("System.String"));
            dt.Columns.Add("Ngừng theo dõi", Type.GetType("System.Boolean"));
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();

                dr[0] = data.AccountID;
                dr[1] = data.AccountNumber;
                dr[2] = data.AccountName;
                dr[3] = data.AccountNameEnglish;
                dr[4] = data.AccountCategoryID;
                if (data.AccountCategoryKind == 0) dr[5] = "Dư nợ";
                else if (data.AccountCategoryKind == 1) dr[5] = "Dư có";
                else if (data.AccountCategoryKind == 2) dr[5] = "Lưỡng tính";
                else dr[5] = "Không có số dư";
                dr[6] = data.Inactive;

                dt.Rows.Add(dr);
                if (data.IsParent == true)
                {
                    string kc = "";
                    dequy(1, maxi, dt, data.AccountID, kc);
                }
                
            }

           // txtSQL.Text = max + Globals.transactioncode;
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Nhóm tài khoản"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        private void load_form_DMVT() // Loại vật tư hàng hóa, công cụ dụng cụ - tsbtlvthh
        {
            view.ViewCaption = "   Loại vật tư hàng hóa, công cụ dụng cụ";
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();            
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.InventoryItemCategories
                              .Where(c => c.CompanyCode == Globals.companycode && c.Grade == 1)
                              .OrderBy(c => c.InventoryCategoryCode);           


            int maxi = ctx.InventoryItemCategories.Where(c => c.CompanyCode == Globals.companycode)
                .Select(p => p.Grade).Max() ?? 0;
            //int maxAge = context.Persons.Max(p => p.Age);
            //temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã loại vật tư hàng hóa, công cụ dụng cụ", Type.GetType("System.String"));
            dt.Columns.Add("Tên loại vật tư hàng hóa, công cụ dụng cụ", Type.GetType("System.String"));
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                
                dr[0] = data.InventoryCategoryID;
                dr[1] = data.InventoryCategoryCode;
                dr[2] = data.InventoryCategoryName;
                dt.Rows.Add(dr);
                if (data.IsParent == true)
                {
                    string kc = "";
                    dequy(1, maxi, dt, data.InventoryCategoryID, kc);
                }

                //dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

        }
        

        private void load_form_PLBL() //  Phụ lục - Bảo lãnh
        {
            if (txtMonth.Text == "" || txtYear.Text == "" || lekho.Text == "[EditValue is null]")
            {
                XtraMessageBox.Show("Please input the required fields", "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            view.ViewCaption = "   Phụ lục - Bảo lãnh";
            view.OptionsView.ColumnAutoWidth = true;
            DataTable da = new DataTable();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            int nam = Int32.Parse(txtYear.Text);

           /* var query = ctx.ContractBs
                 .Join(ctx.AccountingObjects, a => a.AccountingObjectID, c => c.AccountingObjectID,
                (a, c) => new {
                    a.ContractID,
                    a.ContractCode,
                    a.ContractName,
                    c.AccountingObjectName,
                    a.SignedDate,
                    a.EffectiveDate,
                    a.DebtLimit,
                    a.LimitDate,
                    a.NoPay,
                    a.NoContract,
                    a.Closed,
                    c.AccountingObjectCode,
                    a.Saved,
                    a.Inactive,                    
                    a.CompanyCode,
                    a.DebtLimitMax,
                    a.StockID,
                    a.ParentContract, a.No                    
                }
                )
                .Join(ctx.Stocks, a => a.StockID, b => b.StockID,
                (a, c) => new
                {
                    a.ContractID,
                    a.ContractCode,
                    a.ContractName,
                    a.AccountingObjectName,
                    a.SignedDate,
                    a.EffectiveDate,
                    a.DebtLimit,
                    a.LimitDate,
                    a.NoPay, a.No,
                    a.NoContract,
                    a.Closed,
                    a.AccountingObjectCode,
                    a.Saved,                   
                    a.CompanyCode,
                    c.StockName,
                    c.StockCode,
                    a.DebtLimitMax,
                    a.StockID,
                    a.Inactive, a.ParentContract
                })
                .Where(x => x.CompanyCode == Globals.companycode
                && x.EffectiveDate.Value.Year >= nam
                //&& x.SignedDate.Value.Month.ToString() == txtMonth.Text
                && x.StockCode == lekho.Text)
                .OrderBy(x => new{ x.ParentContract, x.SignedDate});*/

            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số", Type.GetType("System.String"));
            dt.Columns.Add("Tên", Type.GetType("System.String"));
            dt.Columns.Add("Khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Ngày ký", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hết hạn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hạn mức nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn mức tối đa", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Nơi lưu", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Hiệu lực", Type.GetType("System.Boolean"));

            /*foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                //ContractID,ContractCode,ContractName,c.AccountingObjectName,a.SignedDate,a.EffectiveDate,6 a.DebtLimit,8 a.LimitDate, 9 a.ParentContract,
                //10 c.AccountingObjectCode,11 Saved, 12b.StockCode + ' - ' + StockName,12 No,a.Inactive,a.DebtLimitMax
                    dr[0] = data.ContractID;
                dr[1] = data.ContractCode;
                dr[2] = data.ContractName;
                if (data.No == 1)
                    dr[2] = "Phụ lục";
                dr[3] = data.AccountingObjectName;
                dr[4] = data.SignedDate;
                dr[5] = data.EffectiveDate;
                dr[6] = data.DebtLimit;
                if (data.DebtLimitMax != null) dr[7] = data.DebtLimitMax;//
                dr[8] = data.LimitDate;
                dr[9] = data.ParentContract;
                dr[10] = data.AccountingObjectCode;
                dr[11] = data.Saved;
                dr[12] = data.StockCode + " - " + data.StockName;
                dr[13] = "False";               
                if (data.Inactive == 1)
                {
                    dr[13] = "True";
                }
                dt.Rows.Add(dr);
            }
            */
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Ngày ký"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày ký"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày ký"].Width = 100;
            view.Columns["Ngày ký"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hết hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hết hạn"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hết hạn"].Width = 100;
            view.Columns["Ngày hết hạn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hạn mức nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức nợ"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn mức tối đa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức tối đa"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn mức tối đa"].AppearanceCell.BackColor = System.Drawing.Color.Salmon;
            view.Columns["Hạn mức tối đa"].AppearanceCell.BackColor2 = System.Drawing.Color.SeaShell;

            view.OptionsView.ShowFooter = true;
            view.Columns["Hợp đồng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Nơi lưu"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Hạn nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn nợ"].Width = 50;

            view.Columns["Khách hàng"].Width = 250;
            view.Columns["Hiệu lực"].Width = 50;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Đơn vị"].GroupIndex = 0;
            view.ExpandAllGroups();
            view.Columns["Số"].BestFit();
        }

        private void load_form_contract()
        {
            if(txtMonth.Text == "" || txtYear.Text=="" || lekho.Text== "[EditValue is null]")
            {
                XtraMessageBox.Show("Please input the required fields", "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            view.OptionsView.ColumnAutoWidth = true;
            DataTable da = new DataTable();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            /*var query = ctx.ContractBs
                 .Join(ctx.AccountingObjects, a => a.AccountingObjectID, c => c.AccountingObjectID,
                (a, c) => new {
                    a.ContractID, a.ContractCode,
                    a.ContractName,
                    c.AccountingObjectName,
                    a.SignedDate,
                    a.EffectiveDate,
                    a.DebtLimit,
                    a.LimitDate,
                    a.NoPay,
                    a.NoContract,
                    a.Closed,
                    c.AccountingObjectCode, a.Saved,                    
                    a.Inactive,                  
                    a.CompanyCode, a.DebtLimitMax, a.StockID
                }
                )                
                .Join(ctx.Stocks, a => a.StockID, b => b.StockID,
                (a,c)=> new
                {
                    a.ContractID,
                    a.ContractCode,
                    a.ContractName,
                    a.AccountingObjectName,
                    a.SignedDate,
                    a.EffectiveDate,
                    a.DebtLimit,
                    a.LimitDate,
                    a.NoPay,
                    a.NoContract,
                    a.Closed,
                    a.AccountingObjectCode,
                    a.Saved,                    
                    a.CompanyCode,c.StockName, c.StockCode,
                    a.DebtLimitMax,
                    a.StockID, a.Inactive
                })
                .Where(x => x.CompanyCode == Globals.companycode 
                && x.SignedDate.Value.Year.ToString() == txtYear.Text
                && x.SignedDate.Value.Month.ToString() == txtMonth.Text
                && x.StockCode == lekho.Text)
                .OrderBy(x => x.ContractName);                        

            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Loại hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Ngày ký", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hết hạn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hạn mức nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn mức tối đa", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hình thức", Type.GetType("System.String"));
            dt.Columns.Add("Hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Nơi lưu", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Thanh lý", Type.GetType("System.Boolean"));
            dt.Columns.Add("Hiệu lực", Type.GetType("System.Boolean"));

            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.ContractID;
                dr[1] = data.ContractCode;
                dr[2] = data.ContractName;
                dr[3] = data.AccountingObjectName;
                dr[4] = data.SignedDate;
                dr[5] = data.EffectiveDate;
                dr[6] = data.DebtLimit;
                if (data.DebtLimitMax !=null) dr[7] = data.DebtLimitMax;//
                dr[8] = data.LimitDate;

                if (data.NoPay == 1)
                    dr[9] = "Tiền mặt";
                else if (data.NoPay == 2)
                    dr[9] = "Tín chấp";
                else if (data.NoPay == 3)
                    dr[9] = "Bảo lãnh";

                if (data.NoContract == 1)
                    dr[10] = "Nguyên tắc";
                else if (data.NoContract == 2)
                    dr[10] = "Đơn hàng";
                dr[11] = data.AccountingObjectCode;
                dr[12] = data.Saved;
                dr[13] = data.StockName;
                dr[14] = "False";
                if (data.Closed == 1)
                {
                    dr[14] = "True";
                }
                dr[15] = "False";
                if (data.Inactive == 1)
                {
                    dr[15] = "True";
                }
                dt.Rows.Add(dr);
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.OptionsView.ShowFooter = true;
            view.Columns["Ngày ký"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày ký"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày ký"].Width = 100;
            view.Columns["Ngày ký"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hết hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hết hạn"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hết hạn"].Width = 100;
            view.Columns["Ngày hết hạn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hạn mức nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức nợ"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn mức tối đa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức tối đa"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn mức tối đa"].AppearanceCell.BackColor = System.Drawing.Color.Salmon;
            view.Columns["Hạn mức tối đa"].AppearanceCell.BackColor2 = System.Drawing.Color.SeaShell;

            view.OptionsView.ShowFooter = true;
            view.Columns["Hình thức"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hợp đồng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Nơi lưu"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Hạn nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn nợ"].Width = 50;

            view.Columns["Khách hàng"].Width = 250;
            view.Columns["Thanh lý"].Width = 50;
            view.Columns["Hiệu lực"].Width = 50;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Đơn vị"].GroupIndex = 0;
            view.ExpandAllGroups();
            view.Columns["Số hợp đồng"].BestFit();*/
        }

        private void load_form_vendor()
        {
            if (ledv.Text == "[EditValue is null]")
            {
                XtraMessageBox.Show("Please input the required fields", "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            view.OptionsView.ColumnAutoWidth = true;
            DataTable da = new DataTable();
            //string sql = "select * from Stock order by StockCode";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.AccountingObjects
                .Join(ctx.Branches, a => a.BranchID, b => b.BranchID,
               (a, b) => new {
                   a.AccountingObjectID,
                   a.AccountingObjectCode,
                   a.AccountingObjectName,
                   a.ContactTitle,
                   a.Inactive,
                   b.BranchName,                   
                   a.CompanyCode,
                   a.IsVendor,
                   a.ContactAddress,
                   a.CompanyTaxCode,
                   b.BranchCode
               }
               )
               .Where(c =>  c.CompanyCode == Globals.companycode && c.IsVendor == true
               && c.BranchCode == ledv.Text)
               .OrderBy(x => new { x.BranchName, x.AccountingObjectName });
            

            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã nhà cung cấp", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhà cung cấp", Type.GetType("System.String"));
            dt.Columns.Add("Địa chỉ", Type.GetType("System.String"));
            dt.Columns.Add("Mã số thuế", Type.GetType("System.String"));

            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.AccountingObjectID;
                dr[1] = data.AccountingObjectCode;
                dr[2] = data.AccountingObjectName;
                dr[3] = data.ContactAddress;
                dr[4] = data.CompanyTaxCode;
                dt.Rows.Add(dr);
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }

        private void load_form_customer()
        {
            if (ledv.Text == "[EditValue is null]")
            {
                XtraMessageBox.Show("Please input the required fields", "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            view.OptionsView.ColumnAutoWidth = true;
            DataTable da = new DataTable();
            //string sql = "select * from Stock order by StockCode";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.AccountingObjects
                 .Join(ctx.Branches, a => a.BranchID, b => b.BranchID,
                (a, b) => new {
                    a.AccountingObjectID,
                    a.AccountingObjectCode,
                    a.AccountingObjectName,
                    a.ContactTitle,
                    a.Inactive,
                    b.BranchName,                 
                    a.CompanyCode,
                    a.IsCustomer, a.ContactAddress, a.CompanyTaxCode,
                    b.BranchCode
                }
                )
                .Where(c => c.CompanyCode == Globals.companycode && c.IsCustomer == true
                && c.BranchCode == ledv.Text)
                .OrderBy(x => new { x.BranchName, x.AccountingObjectName });

            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Địa chỉ", Type.GetType("System.String"));
            dt.Columns.Add("Mã số thuế", Type.GetType("System.String"));            

            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.AccountingObjectID;
                dr[1] = data.AccountingObjectCode;
                dr[2] = data.AccountingObjectName;
                dr[3] = data.ContactAddress;
                dr[4] = data.CompanyTaxCode;                
                dt.Rows.Add(dr);
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            lvpq.UseEmbeddedNavigator = true;
            lvpq.EmbeddedNavigator.ButtonClick += EmbeddedNavigator_ButtonClick;
            var button = lvpq.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button.Tag = "refresh";
            //txtSQL.Text = query.ToString();
        }

        private void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "refresh")
            {
                // load records  
            }
        }

        private void load_form_employee()
        {
            // xem tai lieu ve join LINQ: https://entityframework.net/joining
            if (ledv.Text == "[EditValue is null]")
            {
                XtraMessageBox.Show("Please input the required fields", "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            view.OptionsView.ColumnAutoWidth = true;
            DataTable da = new DataTable();
            //string sql = "select * from Stock order by StockCode";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            //temp = gen.GetTable(sql);
            //select * from AccountingObject with (NOLOCK) where IsEmployee='True' order by BranchID, AccountingObjectName
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework

            var query = ctx.AccountingObjects
                .Join(ctx.Branches, a => a.BranchID, b => b.BranchID,
                (a, b) => new { a.AccountingObjectID, a.AccountingObjectCode, a.AccountingObjectName, a.ContactTitle, a.Inactive, b.BranchName,
                     a.CompanyCode, a.IsEmployee, b.BranchCode
                }
                )
                .Where(c => c.CompanyCode == Globals.companycode && c.IsEmployee == true
                && c.BranchCode == ledv.Text)
                .OrderBy(x => new { x.BranchName, x.AccountingObjectName });


            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã nhân viên", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhân viên", Type.GetType("System.String"));
            dt.Columns.Add("Chức vụ", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Ngừng theo dõi", Type.GetType("System.Boolean"));
            
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.AccountingObjectID;
                dr[1] = data.AccountingObjectCode;
                dr[2] = data.AccountingObjectName;
                dr[3] = data.ContactTitle;                
                dr[4] = data.BranchName;
                dr[5] = data.Inactive.ToString();
                dt.Rows.Add(dr);
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            txtSQL.Text = query.ToString();
        }

        private void load_form_kho()
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable da = new DataTable();
            //string sql = "select * from Stock order by StockCode";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            //temp = gen.GetTable(sql);
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.Stocks
                              .Where(c =>c.CompanyCode == Globals.companycode).OrderBy(c => c.StockCode);

            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.StockID;
                dr[1] = data.StockCode;
                dr[2] = data.StockName;
                dr[3] = data.Description;
                dt.Rows.Add(dr);                
            }

            /*for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dt.Rows.Add(dr);
            }*/
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }

        private void load_form_donvi()
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();                        
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var query = ctx.Branches
                              .Where(c => c.Grade == 1).OrderBy(c => c.BranchCode);
            
            string max = gen.GetString("select max(Grade) from Branch");
            int maxi = int.Parse(max);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Tên đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.BranchID;
                dr[1] = data.BranchCode;
                dr[2] = data.BranchName;
                dr[3] = data.Description;                
                dt.Rows.Add(dr);
                if (data.IsParent.ToString() == "True")
                {
                    string kc = "";
                    dequy(1, maxi, dt, data.BranchID, kc);
                }
            }
            
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }
        public void dequy(int m, int max, DataTable dt, Guid pid, string kc)
        {
            if (m < max)
            {
                kc = kc + "      ";
                DataTable da = new DataTable();                
                var ctx = gen.GetNewEntity(); // khai bao new entity Framework

                if (Globals.transactioncode == "BR00")
                {
                    var query = ctx.Branches
                                  .Where(c => c.Parent == pid).OrderBy(c => c.BranchCode);
                    foreach (var data in query)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = data.BranchID;
                        dr[1] = kc + data.BranchCode;
                        dr[2] = data.BranchName;
                        dr[3] = data.Description;
                        dt.Rows.Add(dr);
                        if (data.IsParent.ToString() == "True")
                        {
                            int n = m + 1;
                            dequy(1, max, dt, data.BranchID, kc);
                        }
                    }
                }else if (Globals.transactioncode == "DMVT")
                {
                    var query = ctx.InventoryItemCategories
                                 .Where(c => c.ParentID == pid).OrderBy(c => c.InventoryCategoryCode);
                    foreach (var data in query)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = data.InventoryCategoryID;
                        dr[1] = kc + data.InventoryCategoryCode;
                        dr[2] = data.InventoryCategoryName;
                        dt.Rows.Add(dr);
                        if (data.IsParent.ToString() == "True")
                        {
                            int n = m + 1;
                            dequy(1, max, dt, data.InventoryCategoryID, kc);
                        }
                    }
                }
                else if (Globals.transactioncode == "HTTK")
                {
                    var query = ctx.Accounts
                                 .Where(c => c.ParentID == pid).OrderBy(c => c.AccountNumber);
                    foreach (var data in query)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = data.AccountID;
                        dr[1] = kc + data.AccountNumber;
                        dr[2] = data.AccountName;
                        dr[3] = data.AccountNameEnglish;
                        dr[4] = data.AccountCategoryID;
                        if (data.AccountCategoryKind == 0) dr[5] = "Dư nợ";
                        else if (data.AccountCategoryKind == 1) dr[5] = "Dư có";
                        else if (data.AccountCategoryKind == 2) dr[5] = "Lưỡng tính";
                        else dr[5] = "Không có số dư";
                        dr[6] = data.Inactive;

                        dt.Rows.Add(dr);
                        if (data.IsParent == true)
                        {
                            int n = m + 1;
                            dequy(1, max, dt, data.AccountID, kc);
                        }
                    }
                }


            }
        }

        private void txtDocType_EditValueChanged(object sender, EventArgs e)
        {
            //lblTypeName.Text = gen.GetString2("Transactions", "TransactionName", "TransactionCode",Globals.transactioncode);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (Globals.transactioncode == "BR00")
            {
                try
                {
                    Frm_branch m = new Frm_branch();
                    //m.myac = new Frm_branch.ac(F.refreshbranch);
                    m.getactive("0");
                    m.getuserid(Globals.userid);                    
                    m.ShowDialog();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtSQL.Text = sql;
                }
            }else if (Globals.transactioncode == "ST00")
            {
                try
                {
                    Frm_stock m = new Frm_stock();                    
                    m.getactive("0");
                    m.getuserid(Globals.userid);
                    m.ShowDialog();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtSQL.Text = sql;
                }
            }
            else if (Globals.transactioncode == "EM00")
            {
                try
                {
                    Frm_nhanvien m = new Frm_nhanvien();
                    m.getactive("0");
                    m.getuserid(Globals.userid);
                    m.ShowDialog();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtSQL.Text = sql;
                }
            }
            else if (Globals.transactioncode == "CU00"|| Globals.transactioncode == "VE00")
            {
                try
                {
                    Frm_cuspro m = new Frm_cuspro();
                    m.getactive("0");
                    m.getuserid(Globals.userid);
                    m.ShowDialog();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            else if (Globals.transactioncode == "DNDH")
            {
                Frm_DNDH u = new Frm_DNDH();
                //u.myac = new Frm_ddh.ac(F.refreshddh);
                u.getactive("0");
                u.getkhach(Globals.khach);
                u.gethang(Globals.hang);
                //u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                u.ShowDialog();
            }

        }

        private void view_DoubleClick(object sender, EventArgs e)
        {
                        
                try
                {

                    if (Globals.transactioncode == "BR00")
                    {
                        Frm_branch m = new Frm_branch();
                        m.getactive("1");
                        m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        m.getuserid(Globals.userid);
                        m.ShowDialog();
                }else if (Globals.transactioncode == "ST00")
                {
                        Frm_stock m = new Frm_stock();
                        m.getactive("1");
                        m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        m.getuserid(Globals.userid);
                        m.ShowDialog();
                }
                else if (Globals.transactioncode == "EM00")
                {
                    Frm_nhanvien m = new Frm_nhanvien();
                    m.getactive("1");
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    m.getuserid(Globals.userid);
                    m.ShowDialog();
                }
                else if (Globals.transactioncode == "CU00" || Globals.transactioncode == "VE00")
                {
                    Frm_cuspro m = new Frm_cuspro();
                    m.getactive("1");
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    m.getuserid(Globals.userid);
                    m.ShowDialog();
                }
                else if (Globals.transactioncode == "HDKH")
                {
                    Frm_hdkh m = new Frm_hdkh();
                    m.getactive("1");
                    m.getsub("CT");
                    m.getdate(Globals.ngaychungtu);
                    m.getkhach(Globals.khach);
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    m.getuser(Globals.userid);
                    m.ShowDialog();
                }
                else if (Globals.transactioncode == "HTTK")
                {                    
                    Frm_account u = new Frm_account();
                    //u.myac = new Frm_account.ac(F.refreshaccount);
                    u.getactive("1");
                    u.getuserid(Globals.userid);
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    u.ShowDialog();
                }
                else if (Globals.transactioncode == "DNDH")
                {
                    Frm_DNDH u = new Frm_DNDH();
                    //u.myac = new Frm_ddh.ac(F.refreshddh);
                    u.getactive("1");
                    u.getkhach(Globals.khach);
                    u.gethang(Globals.hang);
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());                    
                    u.ShowDialog();
                }
                //
            }
            catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtSQL.Text = sql;
                }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Globals.transactioncode == "BR00")
            {
                try
                {
                    Frm_branch m = new Frm_branch();
                    //m.myac = new Frm_branch.ac(F.refreshbranch);
                    m.getactive("1");
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    m.getuserid(Globals.userid);
                    m.ShowDialog();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "btnContent_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtSQL.Text = sql;
                }
            }
        }

        private void lvpq_Click(object sender, EventArgs e)
        {

        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            lblStockName.Text = gen.GetString2("Stock", "StockName","StockCode",lekho.Text,clientid);
        }

        private void ledv_EditValueChanged_1(object sender, EventArgs e)
        {
            lblBranchName.Text = gen.GetString2("Branch", "BranchName", "BranchCode", ledv.Text, clientid);
        }

        private void view_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (Globals.transactioncode == "DNDH")
                    {
                        if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[0]) != "")
                        {
                            e.Appearance.BackColor = Color.Salmon;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[10]) == "")
                        {
                            e.Appearance.BackColor2 = Color.Red;
                            e.Appearance.BackColor = Color.SeaShell;
                        }
                    }
                }
            }
            catch { }
        }

        private void view_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}