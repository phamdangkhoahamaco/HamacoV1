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
using DevExpress.XtraSplashScreen;
using System.Data.Entity;
using System.Threading;
//using Z.Dapper.Plus;
using System.Data.SqlClient;
using DevExpress.XtraGrid;

namespace HAMACO
{
    public partial class Frm_BaoCao : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        string username = Globals.username;
        string userid = Globals.userid;
        string ngay, denngay, tungay, ngaydau, ngaycuoi, thangso, namso, thangdau, thangtruoc;
        int nam, thang;
        string transactioncode, Year, Month, AccountNumber, StockCode, AccountingObjectCode;

        public Frm_BaoCao()
        {
            InitializeComponent();
        }

        /*gettransactioncode("SOCAICT"); // view chi tiet so cai                
               m.getAccountNumber(view.GetRowCellValue(view.FocusedRowHandle, gen.getFieldNameVN("BCTK", "AccountNumber")).ToString());
               m.getYear(txtYear.Text);
               m.getMonth(txtMonth.Text);
               */

        public string gettransactioncode(string a)
        {
            transactioncode = a;
            Globals.transactioncode = transactioncode;
            return transactioncode;
        }
        public string getAccountNumber(string a)
        {
            AccountNumber = a;
            txtAccountNumber.EditValue = AccountNumber;
            return AccountNumber;
        }
        //AccountingObjectCode
        public string getAccountingObjectCode(string a)
        {
            AccountingObjectCode = a;            
            return AccountingObjectCode;
        }
        public string getStockCode(string a)
        {
            StockCode = a;
            ledv.EditValue = StockCode;
            return StockCode;
        }
        public string getYear(string a)
        {
            Year = a;
            txtYear.Text = Year;
            return Year;
        }
        public string getMonth (string a)
        {
            Month = a;
            txtMonth.Text = Month;
            return Month;
        }
        private void Frm_BaoCao_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "User: " + Globals.username + "; Transaction: BC00";
            //txtSQL.Visible = false;
            this.Text = gen.GetString2("Transactions", "TransactionName", "TransactionCode", Globals.transactioncode);
            //default value
            //lblStockName.Text = ""; lblBranchName.Text = "";
            txtYear.Text = DateTime.Now.Year.ToString();
            txtMonth.Text = DateTime.Now.Month.ToString();
            
            // for testing
            //txtMonth.Text = "2";

            //txtMonth.Text = "02";
            //ledv.Visible = false; 
            //txtSQL.Visible = false;

            groupBox1.Visible = false; groupBox2.Visible = false;
            // kiem tra permission                       
            if (gen.checkPermission(Globals.username, Globals.transactioncode, Globals.companycode) == false)
            {
                XtraMessageBox.Show("You do not the permission to execute this transaction code " + Globals.transactioncode + "/" +Globals.companycode, "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                lvpq.Visible = false;

                //load_txtDocType(); // load doc type table
                load_ledv(); // stock
                load_txtAccountNumber(); // Ma TK

                if (Globals.transactioncode == "HDKD") groupBox2.Visible = true;
                else if (Globals.transactioncode == "CDKT") groupBox2.Visible = true;
                else if(Globals.transactioncode == "CDTK") groupBox2.Visible = true;
                else if (Globals.transactioncode == "LCTT") groupBox2.Visible = true;
                else if (Globals.transactioncode == "CNQH") groupBox2.Visible = true;
                else if (Globals.transactioncode == "NVNN") groupBox2.Visible = true;
                else if (Globals.transactioncode == "DMCP") groupBox2.Visible = true;
                else if (Globals.transactioncode == "DMCP") groupBox1.Visible = true;
                else if (Globals.transactioncode == "BCTK") groupBox1.Visible = true; // ton kho


                // khai bao ngay

                ngay = DateTime.DaysInMonth(Int32.Parse(txtYear.Text), Int32.Parse(txtMonth.Text)).ToString();
                denngay = DateTime.Parse(txtMonth.Text + "/" + ngay + "/" + txtYear.Text).ToString();
                tungay = DateTime.Parse(txtMonth.Text + "/1/" + txtYear.Text).ToString();
                ngaydau = tungay;
                ngaycuoi = DateTime.Parse(denngay).AddDays(1).AddSeconds(-1).ToString();

                thangso = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
                namso = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();
                thangtruoc = DateTime.Parse(tungay).Month.ToString();
                ///thangtruoc = thangso;
                thangdau = thangtruoc;
                thang = DateTime.Parse(denngay).Month;
                nam = DateTime.Parse(denngay).Year;

                load_content();
            }

           
        }

        private void load_txtAccountNumber()
        {
         
            DataTable dtTemp = p._SQLTraveDatatable("Select AccountNumber,AccountName from AccountPeriod where (NoCK>0 or CoCK>0) and  FiscalPeriod = '" + thang + "' and  FiscalPeriod = '" + thang+"' and   CompanyCode ='" + Globals.companycode + "'  ORDER BY AccountNumber", gen.GetConn());
            txtAccountNumber.Properties.DataSource = dtTemp;
            txtAccountNumber.Properties.DisplayMember = "AccountName";
            txtAccountNumber.Properties.ValueMember = "AccountNumber";
            txtAccountNumber.Focus();
        }

        private void load_ledv()
        {           
            DataTable dtTemp = p._SQLTraveDatatable("Select StockCode,StockName from Stock where  CompanyCode ='" + Globals.companycode + "'  ORDER BY StockCode", gen.GetConn());

            ledv.Properties.DataSource = dtTemp;
            ledv.Properties.DisplayMember = "StockName";
            ledv.Properties.ValueMember = "Stock";
            ledv.Focus();
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



        private void btnContent_Click(object sender, EventArgs e)
        {
            load_content();
        }

        private void load_content()
        {
            lvpq.Visible = true;
           // SplashScreenManager.ShowForm(this, typeof(Frm_wait), true, true, false);
                        
            if (Globals.transactioncode == "HDKD") load_form_HDKD(); // bao cao hoat dong kinh doanh
            else if (Globals.transactioncode == "CDKT") load_form_CDKT(); // bao cao Bảng cân đối kế toán
            //else if (Globals.transactioncode == "CDTK") load_form_CDTK(); // bao cao Bảng cân đối tai khoan
            else if (Globals.transactioncode == "LCTT") load_form_LCTT(); // bao cao luu chuyen tien te
            else if (Globals.transactioncode == "CNQH") load_form_CNQH(); // bao cao cong no qua han
            else if (Globals.transactioncode == "NVNN") load_form_NVNN(); // bao cao BÁO CÁO TÌNH HÌNH THỰC HIỆN NGHĨA VỤ VỚI NHA NUOC
            else if (Globals.transactioncode == "DMCP") load_form_DMCP(); // bao cao danh mục chi phí
            //else if (Globals.transactioncode == "VATI") load_form_VATI(); // bao cao tsbtthuedauvao
            //else if (Globals.transactioncode == "BCTK") load_form_BCTK(); // bao cao Báo cáo tồn kho hàng hóa --> bao cao dong
            else //IsDynamic
            {
                load_dynamic_form(); // load dynamic form
            }
          // SplashScreenManager.CloseForm(false);
        }

        private void load_dynamic_form() // load form dong
        {
            dt.Clear();
            dt.Columns.Clear();            
            //input
            DataTable TableInput = gen.GetTable("select * from Transactions_DynamicReport where TransactionCode='" + Globals.transactioncode +  "' and IsInput=1 ORDER BY OrderNo");
            string ProcedureName = gen.GetString2("Transactions", "ProcedureName", "TransactionCode",Globals.transactioncode);
            string SQL = "execute " + ProcedureName + " ";
            //txtSQL.Text += TableInput.Rows.Count + Globals.transactioncode;
            for (int i = 0; i < TableInput.Rows.Count; i++)
            {
                if (i > 0) SQL += ",";
                if (TableInput.Rows[i][1].ToString().Trim() == "CompanyCode") SQL += " '" + Globals.companycode + "'";
                if (TableInput.Rows[i][1].ToString().Trim() == "AccountingObjectCode") SQL += " '" + AccountingObjectCode + "'";
                if (TableInput.Rows[i][1].ToString().Trim() == "StockCode")
                {
                    groupBox1.Visible = true;
                    if (ledv.EditValue == null) 
                        SQL += " ''" ;
                    else SQL += " '" + ledv.EditValue + "'";
                }
                if (TableInput.Rows[i][1].ToString().Trim() == "AccountNumber")
                {
                    groupBox3.Visible = true;
                    if (txtAccountNumber.EditValue == null)
                        SQL += " ''";
                    else SQL += " '" + txtAccountNumber.EditValue.ToString() + "'";
                }
                if (TableInput.Rows[i][1].ToString().Trim() == "Year")
                {
                    groupBox2.Visible = true;
                    if (txtYear.Text == "") txtYear.Text = DateTime.Now.Year.ToString();
                    SQL += txtYear.Text;
                }
                if (TableInput.Rows[i][1].ToString().Trim() == "Month")
                {
                    groupBox2.Visible = true;
                    if (txtMonth.Text == "") txtMonth.Text = DateTime.Now.Month.ToString();
                    SQL += txtMonth.Text;
                }
                //txtSQL.Text += TableInput.Rows[i][1];
            }

            DataTable temp = TableInput;
            try { temp = gen.GetTable(SQL); }
            catch { txtSQL.Text += SQL; }

            txtSQL.Text += SQL;
            // datable output
            DataTable TableOutput = gen.GetTable("select * from Transactions_DynamicReport where TransactionCode='" + Globals.transactioncode + "' and IsInput=0 ORDER BY OrderNo");
            
            //txtSQL.Text += "select * from Transactions_DynamicReport where TransactionCode='" + Globals.transactioncode + "' and IsInput=0 ORDER BY OrderNo";
            try
            {
                for (int i = 0; i < TableOutput.Rows.Count; i++)
                {
                    txtSQL.Text += TableOutput.Rows[i]["FieldName"].ToString().Trim();
                    //add header                
                    if (TableOutput.Rows[i]["TypeName"].ToString().Trim() == "String") dt.Columns.Add(TableOutput.Rows[i]["FieldNameVN"].ToString().Trim(), Type.GetType("System.String"));
                    if (TableOutput.Rows[i]["TypeName"].ToString().Trim() == "Boolean") dt.Columns.Add(TableOutput.Rows[i]["FieldNameVN"].ToString().Trim(), Type.GetType("System.Boolean"));
                    if (TableOutput.Rows[i]["TypeName"].ToString().Trim() == "Double") dt.Columns.Add(TableOutput.Rows[i]["FieldNameVN"].ToString().Trim(), Type.GetType("System.Double"));
                    if (TableOutput.Rows[i]["TypeName"].ToString().Trim() == "Date") dt.Columns.Add(TableOutput.Rows[i]["FieldNameVN"].ToString().Trim(), Type.GetType("System.DateTime"));
                    if (TableOutput.Rows[i]["TypeName"].ToString().Trim() == "Int") dt.Columns.Add(TableOutput.Rows[i]["FieldNameVN"].ToString().Trim(), Type.GetType("System.Double"));                                                                
                }

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < TableOutput.Rows.Count; j++)
                    {
                        dr[j] = temp.Rows[i][j];
                    }

                    dt.Rows.Add(dr);
                }
                
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "load_dynamic_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                       
            lvpq.DataSource = dt;

            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";
           
            // view columns setting
            for (int i = 0; i < TableOutput.Rows.Count; i++)
            {
                if (TableOutput.Rows[i]["TypeName"].ToString().Trim() == "Int" || TableOutput.Rows[i]["TypeName"].ToString().Trim() == "Double") 
                {
                    view.Columns[TableOutput.Rows[i]["FieldNameVN"].ToString().Trim()].DisplayFormat.FormatString = "{0:n0}";
                    view.Columns[TableOutput.Rows[i]["FieldNameVN"].ToString().Trim()].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                }
                //sum
                if (TableOutput.Rows[i]["IsSum"].ToString() == "1")
                {
                    //txtSQL.Text = TableOutput.Rows[i]["IsSum"].ToString() + TableOutput.Rows[i]["FieldNameVN"].ToString().Trim();
                    try
                    {
                        GridGroupSummaryItem item = new GridGroupSummaryItem();
                        item.FieldName = TableOutput.Rows[i]["FieldNameVN"].ToString().Trim();
                        item.DisplayFormat = "{0:n0}";
                        item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        view.GroupSummary.Add(item);
                        item.ShowInGroupColumnFooter = view.Columns[TableOutput.Rows[i]["FieldNameVN"].ToString().Trim()];
                        view.Columns[TableOutput.Rows[i]["FieldNameVN"].ToString().Trim()].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        view.Columns[TableOutput.Rows[i]["FieldNameVN"].ToString().Trim()].SummaryItem.DisplayFormat = "{0:n0}";

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "IsSum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                view.ExpandAllGroups();
            }
           // txtSQL.Text = TableOutput.Rows.Count.ToString();
        }

       

       

        private void load_form_DMCP() //bao cao danh mục chi phí
        {
            ngay = DateTime.DaysInMonth(Int32.Parse(txtYear.Text), Int32.Parse(txtMonth.Text)).ToString();
            denngay = DateTime.Parse(txtMonth.Text + "/" + ngay + "/" + txtYear.Text).ToString();
            thang = DateTime.Parse(denngay).Month;
            nam = DateTime.Parse(denngay).Year;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            Guid? StockId = Guid.Empty;
            String sql = "select stockid from Stock where StockCode='" + ledv.EditValue + "'";
            SqlConnection conn = gen.GetConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                StockId = Guid.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "load_form_DMCP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Text = sql;
            }

        
            dt.Columns.Add("Danh mục chi phí", Type.GetType("System.String"));
            dt.Columns.Add("Tháng 01", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 02", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 03", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 04", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 05", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 06", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 07", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 08", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 09", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 10", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 11", Type.GetType("System.Double"));
            dt.Columns.Add("Tháng 12", Type.GetType("System.Double"));
            dt.Columns.Add("Tổng cộng", Type.GetType("System.Double"));

            string mySQL = "DECLARE @tab1 AS TABLE (stt int,danhmuc nvarchar(100),amount money)";
            mySQL += " insert @tab1 select distinct stt,danhmuc,0 from DANHMUC where phieu = 'pctm'";
            mySQL += " DECLARE @tab2 AS TABLE(RefOrder int, TotalAmount money)";
            mySQL += " insert @tab2 select RefOrder, sum(TotalAmount) from CAPayment where StockId ='" + StockId.ToString() + "' AND month(PostedDate) = " + thang + " and year(PostedDate) =  " + nam + "  group by RefOrder";
            mySQL += " DECLARE @tab3 AS TABLE (danhmuc nvarchar(100),TotalAmount money)";
            mySQL += " delete @tab1 delete @tab2";
            mySQL += " insert @tab1 select distinct stt,danhmuc,0 from DANHMUC where phieu='pcnh'";
            mySQL += " insert @tab2 select RefOrder, sum(TotalAmount) from BATransfer where StockId ='" + StockId.ToString() + "' AND month(PostedDate) =  " + thang + "  and year(PostedDate) = " + nam + "  group by RefOrder";
            mySQL += " insert @tab3 select danhmuc, TotalAmount from @tab1 as a left join @tab2 as b ON  a.stt = b.RefOrder";
            mySQL += " DECLARE @tab4 AS TABLE (danhmuc nvarchar(100),TotalAmount money)";
            mySQL += " insert @tab4 select danhmuc,sum(TotalAmount) from @tab3  group by danhmuc";
            mySQL += " select * from @tab4 where TotalAmount is not NULL";
            //viet lai
            mySQL = "DECLARE @tab5 AS TABLE (danhmuc nvarchar(100),thang1 money,thang2 money,thang3 money,thang4 money,thang5 money,thang6 money,thang7 money,thang8 money,thang9 money,thang10 money,thang11 money,thang12 money, tongcong money) ";
            mySQL += " DECLARE @tab4 AS TABLE (danhmuc nvarchar(100),TotalAmount money) ";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',1," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,TotalAmount,0,0,0,0,0,0,0,0,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";            
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',2," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,TotalAmount,0,0,0,0,0,0,0,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',3," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,TotalAmount,0,0,0,0,0,0,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',4," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,TotalAmount,0,0,0,0,0,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',5," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,TotalAmount,0,0,0,0,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',6," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,0,TotalAmount,0,0,0,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',7," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,0,0,TotalAmount,0,0,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',8," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,0,0,0,TotalAmount,0,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',9," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,0,0,0,0,TotalAmount,0,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',10," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,0,0,0,0,0,TotalAmount,0,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',11," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,0,0,0,0,0,0,TotalAmount,0,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',12," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,0,0,0,0,0,0,0,TotalAmount,0 from @tab4";
            mySQL += " delete @tab4";
            mySQL += " insert into @tab4 exec baocaodanhmucchiphitheothang '" + StockId.ToString() + "',13," + nam + "";
            mySQL += " INSERT INTO @tab5 select danhmuc,0,0,0,0,0,0,0,0,0,0,0,0,TotalAmount from @tab4";
            mySQL += " select danhmuc, sum(thang1) as thang1, sum(thang2) as thang2, sum(thang3) as thang3, sum(thang4) as thang4, sum(thang5) as thang5, sum(thang6) as thang6,   ";
            mySQL += " sum(thang7) as thang7, sum(thang8) as thang8, sum(thang9) as thang9, sum(thang10) as thang10, sum(thang11) as thang11, sum(thang12) as thang12, sum(tongcong) as tongcong   ";
            mySQL += " from @tab5  group by danhmuc";
            try
            {
                temp = gen.GetTable(mySQL);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "load_form_DMCP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Text = mySQL;
            }

            txtSQL.Text = mySQL + thangtruoc + namso + thangdau + thang + nam;

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i]["danhmuc"];
                dr[1] = temp.Rows[i]["thang1"].ToString();
                dr[2] = temp.Rows[i]["thang2"].ToString();
                dr[3] = temp.Rows[i]["thang3"].ToString();
                dr[4] = temp.Rows[i]["thang4"].ToString();
                dr[5] = temp.Rows[i]["thang5"].ToString();
                dr[6] = temp.Rows[i]["thang6"].ToString();
                dr[7] = temp.Rows[i]["thang7"].ToString();
                dr[8] = temp.Rows[i]["thang8"].ToString();
                dr[9] = temp.Rows[i]["thang9"].ToString();
                dr[10] = temp.Rows[i]["thang10"].ToString();
                dr[11] = temp.Rows[i]["thang11"].ToString();
                dr[12] = temp.Rows[i]["thang12"].ToString();
                dr[13] = temp.Rows[i]["tongcong"].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.OptionsView.ShowFooter = true;
            //view.Columns["STT"].Visible = false;
            view.Columns["Danh mục chi phí"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            
            view.Columns["Danh mục chi phí"].BestFit();
            view.Columns["Tháng 01"].Width = 100;
            view.Columns["Tháng 01"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 01"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 02"].Width = 100;
            view.Columns["Tháng 02"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 02"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 03"].Width = 100;
            view.Columns["Tháng 03"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 03"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 04"].Width = 100;
            view.Columns["Tháng 04"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 04"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 05"].Width = 100;
            view.Columns["Tháng 05"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 05"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 06"].Width = 100;
            view.Columns["Tháng 06"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 06"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 07"].Width = 100;
            view.Columns["Tháng 07"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 07"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 08"].Width = 100;
            view.Columns["Tháng 08"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 08"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 09"].Width = 100;
            view.Columns["Tháng 09"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 09"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 10"].Width = 100;
            view.Columns["Tháng 10"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 10"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 11"].Width = 100;
            view.Columns["Tháng 11"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 11"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tháng 12"].Width = 100;
            view.Columns["Tháng 12"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tháng 12"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng cộng"].Width = 100;
            view.Columns["Tổng cộng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng cộng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            
        }

        private void load_form_NVNN() // BÁO CÁO TÌNH HÌNH THỰC HIỆN NGHĨA VỤ VỚI NHA NUOC
        {
            ngay = DateTime.DaysInMonth(Int32.Parse(txtYear.Text), Int32.Parse(txtMonth.Text)).ToString();
            denngay = DateTime.Parse(txtMonth.Text + "/" + ngay + "/" + txtYear.Text).ToString();
            tungay = DateTime.Parse(txtMonth.Text + "/1/" + txtYear.Text).ToString();
            ngaydau = tungay;
            ngaycuoi = DateTime.Parse(denngay).AddDays(1).AddSeconds(-1).ToString();

            thangso = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            namso = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();
            thangtruoc = DateTime.Parse(tungay).Month.ToString();
            ///thangtruoc = thangso;
            thangdau = thangtruoc;
            thang = DateTime.Parse(denngay).Month;
            nam = DateTime.Parse(denngay).Year;

            //tsbtttthnvvnn     
            // sheet: https://docs.google.com/spreadsheets/d/1GJ-xBqakaWhfVzFpLHCRGX7AYAlCCbTzKgavGjGNKOQ/edit#gid=0
            DataTable temp = new DataTable();
            DataTable temp2 = new DataTable();
            DataTable temp3 = new DataTable();
            DataTable dt = new DataTable();
            dt.Clear(); temp.Clear();
            temp2.Clear(); temp3.Clear();
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Chỉ tiêu", Type.GetType("System.String"));
            dt.Columns.Add("Mã số", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));

            var ctx = gen.GetNewEntity();
            // tinh tien
            //string mySQL = //"tinhhinhthuchiennghiavuvoinhanuoc '" + thangso + "','" + namso + "','" + thangtruoc + "','" + thang + "','" + nam + "'";
            // thangtruoc, namtruoc, thangdau, thang, nam
            //'1', '2020', '2', '2', '2020'
            string mySQL = "DECLARE @tab1 AS TABLE(col1 nvarchar(100), col2 nvarchar(100), col3 nvarchar(10), col4 money, col5 money, col6 money, col7 money, col8 money, col9 money, col10 money, col11 money)";
            mySQL += " insert into @tab1 select AccountingObjectID,StockID,AccountNumber,0,0,0,0,0,0,DebitAmount,CreditAmount from AccountAccumulated where Month(PostDate)=" + thangso + " and Year(PostDate)=" + namso ;
            mySQL += " insert into @tab1 select AccountingObjectID,StockID,AccountNumber,0,0,0,0,DebitArising,CreditArising,0,0 from AccountAccumulated where Month(PostDate)>= " + thangtruoc + " and Month(PostDate)<= " + thang + " and Year(PostDate)=" + nam;
            mySQL += " insert into @tab1 select AccountingObjectID,StockID,AccountNumber,DebitAmount,CreditAmount,DebitAccumulated,CreditAccumulated,0,0,0,0 from AccountAccumulated where Month(PostDate)=" + thang + " and Year(PostDate)=" + nam;
            mySQL += " DECLARE @tab2 AS TABLE (col1 nvarchar(100),col2 nvarchar(100),col4 money,col5 money,col6 money,col7 money,col8 money,col9 money,col10 money,col11 money)";
            mySQL += " insert into @tab2 select col3, AccountName, COALESCE(sum(col4), 0), COALESCE(sum(col5), 0), COALESCE(sum(col6), 0), COALESCE(sum(col7), 0), COALESCE(sum(col8), 0), COALESCE(sum(col9), 0), COALESCE(sum(col10), 0), COALESCE(sum(col11), 0) from @tab1 a,Account b where col3 = AccountNumber  group by col3,AccountName";
            mySQL += " SELECT * from @tab2";
            try
            {
                temp = gen.GetTable(mySQL);
            }
            catch { }
            txtSQL.Text = mySQL + thangtruoc + namso + thangdau + thang + nam;

            mySQL = "Select * from  AccountSum where ((DebitAccount = '33311' and CreditAccount = '1111') OR (DebitAccount='331' and CreditAccount='1331')) and Month(PostDate)>= " + thangdau + " and Month(PostDate)<= " + thang + " and Year(PostDate)= " + nam;
            try
            {
                temp2 = gen.GetTable(mySQL);
            }
            catch { }

            mySQL = "Select * from  Targets4 where thang < " + thang + " and nam= " + nam;
            try
            {
                temp3 = gen.GetTable(mySQL);
            }
            catch { }
            
            //txtSQL.Text = matrix[242, 1111] + "";

            var query = ctx.BaoCaoTinhHinhThucHienNghiaVuNNs
            .OrderBy(x => x.OrderID);
            decimal[] list3 = new decimal[71];
            decimal[] list4 = new decimal[71];
            decimal[] list5 = new decimal[71];
            decimal[] list6 = new decimal[71];
            decimal[] list7 = new decimal[71];
            decimal[] list8 = new decimal[71];            
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.STT;
                dr[1] = data.ChiTieu;
                if (data.MaSo != "01" || data.MaSo != "30" || data.MaSo != "40")
                    dr[1] = "      " + data.ChiTieu;
                dr[2] = data.MaSo;
                dr[3] = 0; // NoDK
                dr[4] = 0; // NoPS
                dr[5] = 0; // CoPS
                dr[6] = 0; // NoLK
                dr[7] = 0; // CoLK
                dr[8] = 0; // NoCK
                
                decimal sotien = 0;
                try
                {
                    if (data.MaSo == "11")
                    {
                        sotien = NVNN_getsotien(temp, "col11", "33311", "1331") - NVNN_getsotien(temp, "col10", "33311", "1331");
                        //sotien =
                        list3[data.STT] = sotien;
                        list4[data.STT] = temp2.AsEnumerable().Where(y => y.Field<string>("DebitAccount") == "331" && y.Field<string>("CreditAccount") == "1331")
                                   .Sum(x => x.Field<decimal>("Amount"));
                        list5[data.STT] = temp2.AsEnumerable().Where(y => y.Field<string>("DebitAccount") == "33311" && y.Field<string>("CreditAccount") == "1111")
                                   .Sum(x => x.Field<decimal>("Amount"));
                        list6[data.STT] = list4[data.STT];
                        list7[data.STT] = list5[data.STT];
                        if (thang != 1)
                        {
                            list6[data.STT] = temp3.AsEnumerable()
                                   .Sum(x => x.Field<decimal>("debit"));
                            list7[data.STT] = temp3.AsEnumerable()
                                   .Sum(x => x.Field<decimal>("Credit"));
                        }
                        list4[data.STT] += NVNN_getsotien(temp, "col9", "33311") - NVNN_getsotien(temp, "col8", "1331");
                        list6[data.STT] += list4[data.STT];
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "33311", "1331") - NVNN_getsotien(temp, "col4", "33311", "1331");

                    }
                    if (data.MaSo == "12")
                    {
                        sotien = NVNN_getsotien(temp, "col11", "33312") - NVNN_getsotien(temp, "col10", "33312");
                        list3[data.STT] = sotien;
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "33312");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "33312");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "33312");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "33312");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "33312") - NVNN_getsotien(temp, "col4", "33312");
                    }
                    if (data.MaSo == "13")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "3332") - NVNN_getsotien(temp, "col10", "3332");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "3332");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "3332");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "3332");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "3332");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "3332") - NVNN_getsotien(temp, "col4", "3332");

                    }
                    if (data.MaSo == "14")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "3333") - NVNN_getsotien(temp, "col10", "3333");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "3333");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "3333");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "3333");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "3333");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "3333") - NVNN_getsotien(temp, "col4", "3333");
                    }
                    if (data.MaSo == "15")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "3334") - NVNN_getsotien(temp, "col10", "3334");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "3334");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "3334");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "3334");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "3334");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "3334") - NVNN_getsotien(temp, "col4", "3334");
                    }
                    if (data.MaSo == "16")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "33351", "33352", "33353") - NVNN_getsotien(temp, "col10", "33351", "33352", "33353");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "33351", "33352", "33353");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "33351", "33352", "33353");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "33351", "33352", "33353");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "33351", "33352", "33353");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "33351", "33352", "33353") - NVNN_getsotien(temp, "col4", "33351", "33352", "33353");
                    }
                    if (data.MaSo == "17")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "3336") - NVNN_getsotien(temp, "col10", "3336");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "3336");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "3336");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "3336");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "3336");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "3336") - NVNN_getsotien(temp, "col4", "3336");
                    }
                    if (data.MaSo == "18")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "3337") - NVNN_getsotien(temp, "col10", "3337");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "3337");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "3337");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "3337");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "3337");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "3337") - NVNN_getsotien(temp, "col4", "3337");
                    }
                    if (data.MaSo == "19")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "64251") - NVNN_getsotien(temp, "col10", "64251");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "64251");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "64251");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "64251");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "64251");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "64251") - NVNN_getsotien(temp, "col4", "64251");
                    }
                    if (data.MaSo == "20")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "3338") - NVNN_getsotien(temp, "col10", "3338");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "3338");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "3338");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "3338");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "3338");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "3338") - NVNN_getsotien(temp, "col4", "3338");
                    }
                    if (data.MaSo == "31" || data.MaSo == "32")
                    {
                        list3[data.STT] = NVNN_getsotien(temp, "col11", "33310") - NVNN_getsotien(temp, "col10", "33310");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "33310");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "33310");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "33310");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "33310");
                        list8[data.STT] = NVNN_getsotien(temp, "col5", "33310") - NVNN_getsotien(temp, "col4", "33310");
                    }
                    
                    if (data.MaSo == "33")
                    {
                        list8[data.STT] = NVNN_getsotien(temp, "col11", "3339") - NVNN_getsotien(temp, "col10", "3339");
                        list4[data.STT] = NVNN_getsotien(temp, "col9", "3339");
                        list5[data.STT] = NVNN_getsotien(temp, "col8", "3339");
                        list6[data.STT] = NVNN_getsotien(temp, "col7", "3339");
                        list7[data.STT] = NVNN_getsotien(temp, "col6", "3339");
                        list3[data.STT] = NVNN_getsotien(temp, "col5", "3339") - NVNN_getsotien(temp, "col4", "3339");
                    }
                    else if (data.MaSo == "30")
                    {
                        list3[data.STT] = list3[13]+ list3[14]+ list3[15];
                        list4[12] = list4[13] + list4[14] + list4[15];
                        list5[12] = list5[13] + list5[14] + list5[15];
                        list6[12] = list6[13] + list6[14] + list6[15];
                        list7[12] = list7[13] + list7[14] + list7[15];
                        list8[12] = list8[13] + list8[14] + list8[15];
                    }
                    else if (data.MaSo == "01")
                    {
                        list4[1] = list4[2] + list4[3] + list4[4] + list4[5] + list4[6] + list4[7] + list4[8] + list4[9] + list4[10] + list4[11];
                        list5[1] = list5[2] + list5[3] + list5[4] + list5[5] + list5[6] + list5[7] + list5[8] + list5[9] + list5[10] + list5[11];
                        list6[1] = list6[2] + list6[3] + list6[4] + list6[5] + list6[6] + list6[7] + list6[8] + list6[9] + list6[10] + list6[11];
                        list7[1] = list7[2] + list7[3] + list7[4] + list7[5] + list7[6] + list7[7] + list7[8] + list7[9] + list7[10] + list7[11];
                        list8[1] = list8[2] + list8[3] + list8[4] + list8[5] + list8[6] + list8[7] + list8[8] + list8[9] + list8[10] + list8[11];
                    }
                    else if (data.MaSo == "40")
                    {
                        list4[16] = list4[1] + list4[12];
                        list5[16] = list5[1] + list5[12];
                        list6[16] = list6[1] + list6[12];
                        list7[16] = list7[1] + list7[12];
                        list8[16] = list8[1] + list8[12];
                    }
                    
                    dr[3] = list3[data.STT]; //NoDK
                    dr[4] = list4[data.STT]; // NoPS
                    dr[5] = list5[data.STT]; // CoPS
                    dr[6] = list6[data.STT]; // NoLK
                    dr[7] = list7[data.STT]; // CoLK
                    dr[8] = list8[data.STT]; // NoCK

                }                
                catch (Exception ex )
                { XtraMessageBox.Show(ex.Message + ex.TargetSite, "error", MessageBoxButtons.OK, MessageBoxIcon.Information); }                    

                //dr[3] = sotien;
                dt.Rows.Add(dr);
                //txtSQL.Text = list[21] + "";
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.OptionsView.ShowFooter = true;
            view.Columns["STT"].Visible = false;            
            view.Columns["Mã số"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            view.Columns["Chỉ tiêu"].Width = 1000;
            view.Columns["Mã số"].BestFit();
            view.Columns["Nợ đầu kỳ"].Width = 100;
            view.Columns["Nợ đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ phát sinh"].Width = 100;
            view.Columns["Nợ phát sinh"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ phát sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có phát sinh"].Width = 100;
            view.Columns["Có phát sinh"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có phát sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ lũy kế"].Width = 100;
            view.Columns["Nợ lũy kế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ lũy kế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có lũy kế"].Width = 100;
            view.Columns["Có lũy kế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có lũy kế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ cuối kỳ"].Width = 100;
            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;                        
        }

        private decimal NVNN_getsotien(DataTable temp, string colname, string colvalue1)
        {
            decimal sotien = 0;
            sotien = temp.AsEnumerable().Where(y => y.Field<string>("col1") == colvalue1)
                       .Sum(x => x.Field<decimal>(colname));
            return sotien;
        }
        private decimal NVNN_getsotien(DataTable temp, string colname, string colvalue1, string colvalue2)
        {
            decimal sotien = 0;
            sotien = temp.AsEnumerable().Where(y => y.Field<string>("col1") == colvalue1 || y.Field<string>("col1") == colvalue2)
                       .Sum(x => x.Field<decimal>(colname));
            return sotien;
        }
        private decimal NVNN_getsotien(DataTable temp, string colname, string colvalue1, string colvalue2, string colvalue3)
        {
            decimal sotien = 0;
            sotien = temp.AsEnumerable().Where(y => y.Field<string>("col1") == colvalue1 || y.Field<string>("col1") == colvalue2 || y.Field<string>("col1") == colvalue3)
                       .Sum(x => x.Field<decimal>(colname));
            return sotien;
        }

        private void load_form_CNQH() // Công nợ quá hạn và hạn mức hợp đồng
        {
            view.Columns.Clear();
            view.ViewCaption = "   Công nợ quá hạn và hạn mức hợp đồng";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            //string ngaychungtu = Globals.ngaychungtu;
            string ngaychungtu = DateTime.Parse(txtMonth.Text + "/" + DateTime.Now.Day + "/" + txtYear.Text).ToString();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Hạn mức", Type.GetType("System.Double"));
            dt.Columns.Add("Tối đa", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Quá hạn", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 30 ngày", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 60 ngày", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 90 ngày", Type.GetType("System.Double"));
            dt.Columns.Add("Trên 06 tháng", Type.GetType("System.Double"));
            dt.Columns.Add("Vượt hạn mức", Type.GetType("System.Double"));
            dt.Columns.Add("Hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Mã", Type.GetType("System.String"));
            //DateTime ngaychungtu2 = DateTime.Now;
            DateTime ngaychungtu2 = DateTime.Parse(txtMonth.Text + "/" + DateTime.Now.Day + "/" + txtYear.Text);
            var ctx = gen.GetNewEntity();            
            var query2 = ctx.BaoCaoCongNoQuaHans
                .Where(c => c.CompanyCode == Globals.companycode && c.ngaychungtu == ngaychungtu2)
                .OrderBy(x => x.Branch);
            if (query2.FirstOrDefault() == null) // tinh toan
            {
                string mySQL = "DECLARE @tab AS TABLE(AccountingObjectID NVARCHAR(100),BeginDebit money, BeginCredit money,Debit money, Credit money,EndDebit money, EndCredit money,EndD money, EndC money,Stock NVARCHAR(100)) ";
                mySQL += "insert into @tab(AccountingObjectID,Debit,EndDebit,EndD,Stock) select AccountingObjectID,Amount,Amount,Amount,Parent from HACHTOAN a with (nolock), Stock b with (nolock) where a.StockID=b.StockID";
                mySQL += " and Month(RefDate)= " + thang + " and Year(RefDate)= " + nam + "and DebitAccount = '131' and Amount<>0";
                mySQL += "insert into @tab(AccountingObjectID,BeginDebit,BeginCredit,EndDebit,EndCredit,EndD,EndC,Stock) ";
                if (thang == "1")
                {
                    mySQL += "select AccountingObjectID,DebitAmount,CreditAmount,0,0,DebitAmount,CreditAmount,StockID from AccountAccumulated with (nolock) where Month(PostDate)=" + thangtruoc + " and Year(PostDate)=" + namtruoc;
                    mySQL += " and AccountNumber='131' and (DebitAmount <>0 or CreditAmount<>0 )";
                }
                else
                {
                    mySQL += "select AccountingObjectID,DebitAmount,CreditAmount,DebitAccumulated,CreditAccumulated,DebitAmount,CreditAmount,StockID from AccountAccumulated with (nolock) where Month(PostDate)=" + thangtruoc + " and Year(PostDate)=" + namtruoc;
                    mySQL += " and AccountNumber='131'";
                }
                mySQL += "DECLARE @tab1 AS TABLE (AccountingObjectID NVARCHAR(100),BeginDebit money,BeginCredit money,Debit money, Credit money,EndDebit money,EndCredit money,EndD money,EndC money,Stock NVARCHAR(100))";
                mySQL += "insert into @tab1 select AccountingObjectID,COALESCE(sum(BeginDebit),0),COALESCE(sum(BeginCredit),0),COALESCE(sum(Debit),0),COALESCE(sum(Credit),0),COALESCE(sum(EndDebit),0),COALESCE(sum(EndCredit),0),";
                mySQL += " COALESCE(sum(EndD), 0),COALESCE(sum(EndC), 0),Stock from @tab group by AccountingObjectID, Stock ";
                mySQL += "update @tab1 set EndD=COALESCE(EndD,0)-COALESCE(EndC,0),EndC=0 ";
                mySQL += "update @tab1 set EndC=abs(EndD),EndD=0 where EndD<0 ";
                mySQL += " delete @tab1 where EndD = 0 and EndC = 0 and BeginCredit = 0 and BeginDebit = 0";
                
                // select chinh ne
                mySQL += " select a.Stock,BranchCode, BranchName,c.AccountingObjectCode,c.AccountingObjectName,c.AccountingObjectID, ";
                mySQL += "sum(DebtLimit) as DebtLimit,sum(DebtLimitMax) as DebtLimitMax,sum(EndD) as EndD,sum(quahan) as quahan,sum(tren1) as tren1,sum(tren2) as tren2,";
                mySQL += "sum(tren3) as tren3,sum(tren6) as tren6, sum(case when EndD - DebtLimitMax > 0  then EndD - DebtLimitMax else 0 end) as VuotHanMuc,";
                mySQL += "Hopdong,c.AccountingObjectID from ";
                mySQL += "(select Stock, a.AccountingObjectID, COALESCE(DebtLimit,0) as DebtLimit,a.EndD,COALESCE(quahan, 0) as quahan,COALESCE(tren1, 0) as tren1,COALESCE(tren2, 0) as tren2,COALESCE(tren3, 0) as tren3,COALESCE(tren6, 0) as tren6, Hopdong,COALESCE(DebtLimitMax, 0) as DebtLimitMax from";
                mySQL += " (select a.AccountingObjectID, a.EndD, a.DebtLimit, Stock, Hopdong, a.DebtLimitMax from";
                mySQL += "(select a.Stock, a.AccountingObjectID, a.EndD, b.DebtLimit, Hopdong, b.DebtLimitMax from(select * from @tab1 where (EndD <> 0 or EndC <> 0) and EndD > EndC) a left join";
                mySQL += "(SELECT BranchID, AccountingObjectID,";
                mySQL += "STUFF(( SELECT Distinct ' ' + ParentContract";
                mySQL += " FROM(select a.DebtLimit, a.BranchID, a.AccountingObjectID, a.ParentContract, a.DebtLimitMax from(select a.*, b.BranchID from contractB a with(nolock), Stock b with(nolock) where a.Inactive <> 0 and a.StockID = b.StockID) a, (select a.AccountingObjectID, a.ParentContract, ";
                mySQL += " MAX(a.SignedDate) as SignedDate, b.BranchID from contractB a with(nolock), Stock b with(nolock)  where a.StockID = b.StockID and  a.SignedDate <= '" + ngaychungtu + "'";
                mySQL += " and a.EffectiveDate >= CONVERT(Date, '" + ngaychungtu + "', 101) group by a.AccountingObjectID, b.BranchID, a.ParentContract) b where a.AccountingObjectID = b.AccountingObjectID and a.BranchID = b.BranchID and a.ParentContract = b.ParentContract and a.SignedDate = b.SignedDate) T";
                mySQL += " WHERE(AccountingObjectID = S.AccountingObjectID and BranchID = S.BranchID)";
                mySQL += " FOR XML PATH(''))";
                mySQL += " , 1, 1, '') AS Hopdong, SUM(DebtLimit) as DebtLimit,SUM(DebtLimitMax) as DebtLimitMax";
                mySQL += " FROM(select a.DebtLimit, a.BranchID, a.AccountingObjectID, a.ParentContract, a.DebtLimitMax from(select a.*, b.BranchID from contractB a with(nolock), Stock b with(nolock) where a.Inactive <> 0 and a.StockID = b.StockID) a, ";
                mySQL += " (select a.AccountingObjectID, a.ParentContract, MAX(a.SignedDate) as SignedDate, b.BranchID from contractB a with(nolock), Stock b with(nolock)  where a.StockID = b.StockID and a.SignedDate <= '" + ngaychungtu + "'";
                mySQL += "  and a.EffectiveDate >= CONVERT(Date, '" + ngaychungtu + "', 101) group by a.AccountingObjectID, b.BranchID, a.ParentContract) b where a.AccountingObjectID = b.AccountingObjectID and a.BranchID = b.BranchID and a.ParentContract = b.ParentContract and a.SignedDate = b.SignedDate) S";
                mySQL += " GROUP BY BranchID, AccountingObjectID) b";
                mySQL += " on a.AccountingObjectID = b.AccountingObjectID and a.Stock in (select StockID from Stock with(nolock) where BranchID= b.BranchID) ) a ) a left join";
                mySQL += " (select StockID, a.AccountingObjectID, DebitAmount, quahan, tren1, tren2, tren3, tren6 from";
                mySQL += " (select StockID, a.AccountingObjectID, DebitAmount, quahan, tren1, tren2, tren3 from";
                mySQL += " (select StockID, a.AccountingObjectID, DebitAmount, quahan, tren1, tren2 from";
                mySQL += " (select StockID, a.AccountingObjectID, DebitAmount, quahan, tren1 from";
                mySQL += " (select StockID, a.AccountingObjectID, DebitAmount, quahan from";
                mySQL += " (select StockID, AccountingObjectID, sum(DebitAmount) as DebitAmount from AccountAccumulated where Month(PostDate) = " + thang + " and Year(PostDate) = " + nam + " and AccountNumber = '131' and DebitAmount <> 0 group by AccountingObjectID, StockID) a left join";
                mySQL += " (select BranchID, AccountingObjectID, sum(ExitsMoney) as quahan from OpenExDate where Month(PostedDate) = " + thang + " and Year(PostedDate) = " + nam + " and DateEx > 0 group by AccountingObjectID, BranchID) b on a.AccountingObjectID = b.AccountingObjectID and a.StockID = b.BranchID) a left join";
                mySQL += " (select BranchID, AccountingObjectID, sum(ExitsMoney) as tren1 from OpenExDate where Month(PostedDate) =  " + thang + " and Year(PostedDate) = " + nam + " and DateEx >= 30 and DateEx < 60 group by AccountingObjectID, BranchID) b on a.AccountingObjectID = b.AccountingObjectID and a.StockID = b.BranchID) a left join";
                mySQL += " (select BranchID, AccountingObjectID, sum(ExitsMoney) as tren2 from OpenExDate where Month(PostedDate) = " + thang + " and Year(PostedDate) = " + nam + " and DateEx >= 60 and DateEx < 90 group by AccountingObjectID, BranchID) b on a.AccountingObjectID = b.AccountingObjectID and a.StockID = b.BranchID) a left join";
                mySQL += " (select BranchID, AccountingObjectID, sum(ExitsMoney) as tren3 from OpenExDate where Month(PostedDate) = " + thang + " and Year(PostedDate) = " + nam + " and DateEx >= 90 and DateEx < 180 group by AccountingObjectID, BranchID) b on a.AccountingObjectID = b.AccountingObjectID and a.StockID = b.BranchID) a left join";
                mySQL += " (select BranchID, AccountingObjectID, sum(ExitsMoney) as tren6 from OpenExDate where Month(PostedDate) = " + thang + " and Year(PostedDate) = " + nam + " and DateEx >= 180 group by AccountingObjectID, BranchID) b on a.AccountingObjectID = b.AccountingObjectID and a.StockID = b.BranchID) b on a.AccountingObjectID = b.AccountingObjectID and a.Stock = b.StockID) a, Stock b with(nolock), AccountingObject c with(nolock), Branch d with(nolock)";
                mySQL += "   where a.AccountingObjectID = c.AccountingObjectID and a.Stock = b.StockID and b.BranchID = d.BranchID ";
                //and b.StockID in (select StockID from MSC_UserJoinStock where UserID = @userid) 
                mySQL += " group by a.Stock,BranchCode, BranchName,c.AccountingObjectCode,c.AccountingObjectID,c.AccountingObjectName,Hopdong,c.AccountingObjectID order by sum(EndD) DESC,AccountingObjectCode";
                
                DataTable tab1 = new DataTable();
                List<BaoCaoCongNoQuaHan> data2a = new List<BaoCaoCongNoQuaHan>();
                try
                {
                    tab1 = gen.GetTable(mySQL);
                    for (int i = 0; i < tab1.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = tab1.Rows[i]["BranchCode"].ToString() + "-" + tab1.Rows[i]["BranchName"].ToString();
                        dr[1] = tab1.Rows[i]["AccountingObjectCode"].ToString();
                        dr[2] = tab1.Rows[i]["AccountingObjectName"].ToString();
                        dr[3] = tab1.Rows[i]["DebtLimit"].ToString();
                        dr[4] = tab1.Rows[i]["DebtLimitMax"].ToString();
                        dr[5] = tab1.Rows[i]["EndD"].ToString();
                        dr[6] = tab1.Rows[i]["quahan"].ToString();
                        dr[7] = tab1.Rows[i]["tren1"].ToString();
                        dr[8] = tab1.Rows[i]["tren2"].ToString();
                        dr[9] = tab1.Rows[i]["tren3"].ToString();                        
                        dr[10] = tab1.Rows[i]["tren6"].ToString();
                        if (Double.Parse(tab1.Rows[i]["VuotHanMuc"].ToString()) != 0)
                            dr[11] = tab1.Rows[i]["VuotHanMuc"].ToString();
                       // else dr[11] = "";

                        //dr[11] = tab1.Rows[i]["VuotHanMuc"].ToString();
                        dr[12] = tab1.Rows[i]["HopDong"].ToString();
                        dr[13] = tab1.Rows[i]["Stock"].ToString();
                        dt.Rows.Add(dr);

                        
                        BaoCaoCongNoQuaHan obj = new BaoCaoCongNoQuaHan();
                        obj.Branch = dr[0].ToString();
                        obj.AccountingObjectCode = dr[1].ToString();
                        obj.AccountingObjectName = dr[2].ToString();
                        obj.HanMuc = Decimal.Parse(dr[3].ToString());
                        obj.ToiDa = Decimal.Parse(dr[4].ToString());
                        obj.No = Convert.ToDecimal(dr[5], null);
                        obj.QuaHan = Convert.ToDecimal(dr[6], null);
                        obj.Tren30Ngay = Convert.ToDecimal(dr[7], null);
                        obj.Tren60Ngay = Convert.ToDecimal(dr[8], null);
                        obj.Tren90Ngay = Convert.ToDecimal(dr[9], null);
                        obj.Tren6Thang = Convert.ToDecimal(dr[10], null);
                        if (Double.Parse(tab1.Rows[i]["VuotHanMuc"].ToString()) != 0)
                            obj.VuotHanMuc = Convert.ToDecimal(dr[11], null);
                        else obj.VuotHanMuc = 0;
                        obj.HopDong = dr[12].ToString();
                        //obj.ClientID = Globals.clientid;
                        obj.CompanyCode = Globals.companycode;
                        obj.ngaychungtu = ngaychungtu2;
                        obj.StockID = Guid.Parse(tab1.Rows[i]["Stock"].ToString());
                        obj.AccountingObjectID = Guid.Parse(tab1.Rows[i]["AccountingObjectID"].ToString());
                        data2a.Add(obj); // object table


                    }// for each
                     // update DB
                    try
                    {
                        Insert_CNQH(data2a as List<BaoCaoCongNoQuaHan>);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite, "tab1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSQL.Text = mySQL ;
                }
            }
            else// hien lai thoi
            {
                foreach (var data in query2)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = data.Branch; // BranchCode + BranchName
                    dr[1] = data.AccountingObjectCode;
                    dr[2] = data.AccountingObjectName;
                    dr[3] = data.HanMuc;
                    dr[4] = data.ToiDa;
                    dr[5] = data.No;
                    dr[6] = data.QuaHan;
                    dr[7] = data.Tren30Ngay;
                    dr[8] = data.Tren60Ngay;
                    dr[9] = data.Tren90Ngay;
                    dr[10] = data.Tren6Thang;
                    dr[11] = data.VuotHanMuc;
                    //if (data.VuotHanMuc == 0) dr[11] = DBNull.Value.ToString();
                    dr[12] = data.HopDong;
                    dr[13] = data.StockID;
                    dt.Rows.Add(dr);
                }
            }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.OptionsView.ShowFooter = true;

            view.Columns["Mã"].Visible = false;
            view.Columns["Hợp đồng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hợp đồng"].Width = 100;

            view.Columns["Hạn mức"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Tối đa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tối đa"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Quá hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Quá hạn"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Trên 30 ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 30 ngày"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 60 ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 60 ngày"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 90 ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 90 ngày"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trên 06 tháng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trên 06 tháng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Vượt hạn mức"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Vượt hạn mức"].DisplayFormat.FormatString = "{0:n0}";


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Nợ";
            item.DisplayFormat = "{0:n0}";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item);
            item.ShowInGroupColumnFooter = view.Columns["Nợ"];

            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = "Quá hạn";
            item1.DisplayFormat = "{0:n0}";
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item1);
            item1.ShowInGroupColumnFooter = view.Columns["Quá hạn"];

            GridGroupSummaryItem item2 = new GridGroupSummaryItem();
            item2.FieldName = "Trên 30 ngày";
            item2.DisplayFormat = "{0:n0}";
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item2);
            item2.ShowInGroupColumnFooter = view.Columns["Trên 30 ngày"];

            GridGroupSummaryItem item3 = new GridGroupSummaryItem();
            item3.FieldName = "Trên 60 ngày";
            item3.DisplayFormat = "{0:n0}";
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item3);
            item3.ShowInGroupColumnFooter = view.Columns["Trên 60 ngày"];

            GridGroupSummaryItem item4 = new GridGroupSummaryItem();
            item4.FieldName = "Trên 90 ngày";
            item4.DisplayFormat = "{0:n0}";
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item4);
            item4.ShowInGroupColumnFooter = view.Columns["Trên 90 ngày"];

            GridGroupSummaryItem item5 = new GridGroupSummaryItem();
            item5.FieldName = "Trên 06 tháng";
            item5.DisplayFormat = "{0:n0}";
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item5);
            item5.ShowInGroupColumnFooter = view.Columns["Trên 06 tháng"];

            GridGroupSummaryItem item6 = new GridGroupSummaryItem();
            item6.FieldName = "Vượt hạn mức";
            item6.DisplayFormat = "{0:n0}";
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.GroupSummary.Add(item6);
            item6.ShowInGroupColumnFooter = view.Columns["Vượt hạn mức"];

            view.Columns["Nợ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nợ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Hạn mức"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Hạn mức"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tối đa"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tối đa"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 30 ngày"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 30 ngày"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 60 ngày"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 60 ngày"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 90 ngày"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 90 ngày"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trên 06 tháng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trên 06 tháng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Vượt hạn mức"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Vượt hạn mức"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Nợ"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            view.Columns["Nợ"].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            view.Columns["Quá hạn"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            view.Columns["Vượt hạn mức"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            view.Columns["Vượt hạn mức"].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);

            view.Columns["Họ tên khách hàng"].Width = 200;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        private void Insert_CNQH(List<BaoCaoCongNoQuaHan> list)
        {
            throw new NotImplementedException();
        }

        private void load_form_LCTT()
        {
            //excel: https://docs.google.com/spreadsheets/d/1ucFIkjmRokEO78JJdE7yOM2ADkQlaqvnSy8vA7AHlAg/edit#gid=0

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("STT", Type.GetType("System.Double"));
            dt.Columns.Add("Chỉ tiêu", Type.GetType("System.String"));
            dt.Columns.Add("Mã số", Type.GetType("System.String"));            
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            var ctx = gen.GetNewEntity();
            // tinh tien
            string mySQL = "select DebitAccount,CreditAccount,sum(Amount) as Amount from HACHTOAN where MONTH(RefDate)>=" + thangtruoc;
                mySQL += " and MONTH(RefDate)<=" + thang + " and YEAR(RefDate)=" + nam + " group by DebitAccount,CreditAccount";
            try
            {
                temp = gen.GetTable(mySQL);
            }
            catch { }
            //txtSQL.Text = matrix[242, 1111] + "";

                var query = ctx.BaoCaoLuuChuyenTienTes                
                .OrderBy(x => x.STT);
            decimal[] list = new decimal[71];
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();
                dr[0] = data.STT;
                dr[1] = data.ChiTieu;
                dr[2] = data.MaSo;
                dr[3] = 0;
                decimal sotien = 0;              

                try
                {
                    if (data.MaSo == "01")
                    {
                        sotien = temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Substring(0, 3) == "111"
                        && (y.Field<string>("CreditAccount").Substring(0, 3) == "131" || (y.Field<string>("CreditAccount").Length >= 4 && y.Field<string>("CreditAccount").Substring(0, 4) == "5113")))
                        || (y.Field<string>("DebitAccount").Substring(0, 3) == "112"
                        && (y.Field<string>("CreditAccount").Substring(0, 3) == "131" || y.Field<string>("CreditAccount").Substring(0, 3) == "511"))
                       ))
                       .Sum(x => x.Field<decimal>("Amount"));
                        list[1] = sotien;
                    }
                    else if (data.MaSo == "02")
                    {
                        sotien -= temp.AsEnumerable().Where(y => (((y.Field<string>("DebitAccount").Substring(0, 3) == "131" ||
                       y.Field<string>("DebitAccount").Substring(0, 3) == "133" || y.Field<string>("DebitAccount").Substring(0, 3) == "331" ||
                       y.Field<string>("DebitAccount").Substring(0, 3) == "641" || y.Field<string>("DebitAccount").Substring(0, 3) == "642"
                       ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "111" || y.Field<string>("CreditAccount").Substring(0, 3) == "112"))                       
                       ))
                       .Sum(x => x.Field<decimal>("Amount"));
                        try
                        {
                            sotien -= temp.AsEnumerable().Where(y => y.Field<string>("CreditAccount").Length >= 6 &&
                         y.Field<string>("DebitAccount").Substring(0, 3) == "331" && (y.Field<string>("CreditAccount").Substring(0, 6) == "341111" ||
                  y.Field<string>("CreditAccount").Substring(0, 6) == "341112" || y.Field<string>("CreditAccount").Substring(0, 6) == "341116"))
                    .Sum(x => x.Field<decimal>("Amount")); // neu len <6 thi ko tinh
                        }
                        catch { }
                        
                        list[2] = sotien;
                    }
                        
                    else if (data.MaSo == "03")
                    {
                        sotien -= temp.AsEnumerable().Where(y => y.Field<string>("DebitAccount").Substring(0, 3) == "334"
                        && (y.Field<string>("CreditAccount").Substring(0, 3) == "111" || y.Field<string>("CreditAccount").Substring(0, 3) == "112"))
                        .Sum(x => x.Field<decimal>("Amount"));
                        list[3] = sotien;
                    }
                        
                    else if (data.MaSo == "04")
                    {
                        sotien -= temp.AsEnumerable().Where(y => y.Field<string>("DebitAccount").Substring(0, 3) == "635"
                        && (y.Field<string>("CreditAccount").Substring(0, 3) == "111" || y.Field<string>("CreditAccount").Substring(0, 3) == "112"))
                        .Sum(x => x.Field<decimal>("Amount"));
                        list[4] = sotien;
                    }
                        
                    else if (data.MaSo == "05")
                    {
                        sotien -= temp.AsEnumerable().Where(y => (y.Field<string>("CreditAccount").Length >= 4 && y.Field<string>("DebitAccount").Substring(0, 4) == "3334")
                        && y.Field<string>("CreditAccount").Substring(0, 3) == "112")
                        .Sum(x => x.Field<decimal>("Amount"));
                        list[5] = sotien;
                    }
                        
                    else if (data.MaSo == "06")
                    {
                        sotien = temp.AsEnumerable().Where(y => (((y.Field<string>("CreditAccount").Substring(0, 3) == "141" || y.Field<string>("CreditAccount").Substring(0, 3) == "515" ||
                        y.Field<string>("CreditAccount").Substring(0, 3) == "411" || y.Field<string>("CreditAccount").Substring(0, 3) == "421" ||
                       y.Field<string>("CreditAccount").Substring(0, 3) == "331" || y.Field<string>("CreditAccount").Substring(0, 3) == "333" ||
                       y.Field<string>("CreditAccount").Substring(0, 3) == "334" || y.Field<string>("CreditAccount").Substring(0, 3) == "632" ||
                       y.Field<string>("CreditAccount").Substring(0, 3) == "635" || y.Field<string>("CreditAccount").Substring(0, 3) == "641" ||
                        y.Field<string>("CreditAccount").Substring(0, 3) == "642" || y.Field<string>("CreditAccount").Substring(0, 3) == "711"
                       ) && (y.Field<string>("DebitAccount").Substring(0, 3) == "111" || y.Field<string>("DebitAccount").Substring(0, 3) == "112"))
                       )).Sum(x => x.Field<decimal>("Amount"));

                        sotien += temp.AsEnumerable().Where(y => y.Field<string>("CreditAccount").Length >= 4 &&
                        (y.Field<string>("DebitAccount").Substring(0, 3) == "111" || y.Field<string>("DebitAccount").Substring(0, 3) == "112")
                        && (y.Field<string>("CreditAccount").Substring(0, 4) == "1388" ||
                        y.Field<string>("CreditAccount").Substring(0, 4) == "3382" || y.Field<string>("CreditAccount").Substring(0, 4) == "3383"||
                        y.Field<string>("CreditAccount").Substring(0, 4) == "3384" || y.Field<string>("CreditAccount").Substring(0, 4) == "3386" ||
                        y.Field<string>("CreditAccount").Substring(0, 4) == "3388" || y.Field<string>("CreditAccount").Substring(0, 4) == "3389" ||
                        y.Field<string>("CreditAccount").Substring(0, 4) == "3532" || y.Field<string>("CreditAccount").Substring(0, 4) == "4211"
                        ))
                   .Sum(x => x.Field<decimal>("Amount")); // neu len <4 thi ko tinh
                        list[6] = sotien;
                    }
                    else if (data.MaSo == "07")
                    {
                        sotien -= temp.AsEnumerable().Where(y => (((y.Field<string>("DebitAccount").Substring(0, 3) == "335" || y.Field<string>("DebitAccount").Substring(0, 3) == "351" ||
                        y.Field<string>("DebitAccount").Substring(0, 3) == "141" || y.Field<string>("DebitAccount").Substring(0, 3) == "144" ||
                        y.Field<string>("DebitAccount").Substring(0, 3) == "142" 
                       ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "111"))
                       )).Sum(x => x.Field<decimal>("Amount"));
                        sotien -= temp.AsEnumerable().Where(y => (((y.Field<string>("DebitAccount").Substring(0, 3) == "335" || y.Field<string>("DebitAccount").Substring(0, 3) == "351" 
                        || y.Field<string>("DebitAccount").Substring(0, 3) == "353" ||
                        y.Field<string>("DebitAccount").Substring(0, 3) == "141" || y.Field<string>("DebitAccount").Substring(0, 3) == "515"                         
                       ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "112"))
                       )).Sum(x => x.Field<decimal>("Amount"));
                        //dk length
                        try
                        {
                            sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Length >= 4 &&
                       (y.Field<string>("DebitAccount").Substring(0, 3) == "333" && y.Field<string>("DebitAccount").Substring(0, 3) != "3334"
                      ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "112"))
                      )).Sum(x => x.Field<decimal>("Amount"));
                            //dk length4 tk 111
                            sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Length >= 4 &&
                            (y.Field<string>("DebitAccount").Substring(0, 4) == "3388" || y.Field<string>("DebitAccount").Substring(0, 4) == "3383" ||
                            y.Field<string>("DebitAccount").Substring(0, 4) == "3389" || y.Field<string>("DebitAccount").Substring(0, 4) == "3382" ||
                            y.Field<string>("DebitAccount").Substring(0, 4) == "3384" || y.Field<string>("DebitAccount").Substring(0, 4) == "3386" ||
                            y.Field<string>("DebitAccount").Substring(0, 4) == "1388" || y.Field<string>("DebitAccount").Substring(0, 4) == "3531" ||
                            y.Field<string>("DebitAccount").Substring(0, 4) == "3532" || y.Field<string>("DebitAccount").Substring(0, 4) == "3337" ||
                            y.Field<string>("DebitAccount").Substring(0, 4) == "3338"
                           ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "111"))
                           )).Sum(x => x.Field<decimal>("Amount"));
                            //dk length5 tk 111
                            sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Length >= 5 &&
                            (y.Field<string>("DebitAccount").Substring(0, 5) == "33311" || y.Field<string>("DebitAccount").Substring(0, 5) == "33351" ||
                            y.Field<string>("DebitAccount").Substring(0, 5) == "33352"
                           ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "111"))
                           )).Sum(x => x.Field<decimal>("Amount"));
                            //dk length4 tk 112
                            sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Length >= 4 &&
                            (y.Field<string>("DebitAccount").Substring(0, 4) == "3388" || y.Field<string>("DebitAccount").Substring(0, 4) == "3383" ||
                            y.Field<string>("DebitAccount").Substring(0, 4) == "3389" || y.Field<string>("DebitAccount").Substring(0, 4) == "3382" ||
                            y.Field<string>("DebitAccount").Substring(0, 4) == "3384" || y.Field<string>("DebitAccount").Substring(0, 4) == "3386" ||
                            y.Field<string>("DebitAccount").Substring(0, 4) == "1388"
                           ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "112"))
                           )).Sum(x => x.Field<decimal>("Amount"));
                            //dk length4 tk 3338
                            sotien -= temp.AsEnumerable().Where(y => (y.Field<string>("DebitAccount").Length >= 4 && y.Field<string>("CreditAccount").Length >= 4 &&
                           ((y.Field<string>("DebitAccount").Substring(0, 4) == "2113" && y.Field<string>("CreditAccount").Substring(0, 4) == "3338") ||
                           ((y.Field<string>("DebitAccount").Substring(0, 4) == "2412" || y.Field<string>("DebitAccount").Substring(0, 4) == "2113")
                           && y.Field<string>("CreditAccount").Substring(0, 4) == "1388"))
                           )).Sum(x => x.Field<decimal>("Amount"));
                        }
                        catch { }                                               
                        list[7] = sotien;
                    }
                    else if (data.MaSo == "20")
                    {
                        list[20] = list[1] + list[2] + list[3] + list[4] + list[5] + list[6] + list[7];
                        sotien = list[20];
                    }
                    else if (data.MaSo == "21")
                    {
                        sotien -= temp.AsEnumerable().Where(y => (((y.Field<string>("DebitAccount").Substring(0, 3) == "211" || y.Field<string>("DebitAccount").Substring(0, 3) == "242" ||
                        y.Field<string>("DebitAccount").Substring(0, 3) == "241" 
                       ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "111"))
                       )).Sum(x => x.Field<decimal>("Amount"));

                        sotien -= temp.AsEnumerable().Where(y => (((y.Field<string>("DebitAccount").Substring(0, 3) == "211" || y.Field<string>("DebitAccount").Substring(0, 3) == "241"
                        || y.Field<string>("DebitAccount").Substring(0, 3) == "213" ||  y.Field<string>("DebitAccount").Substring(0, 3) == "242" 
                       ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "112"))
                       )).Sum(x => x.Field<decimal>("Amount"));
                        sotien -= temp.AsEnumerable().Where(y => (((y.Field<string>("DebitAccount").Substring(0, 3) == "211" 
                       ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "113"))
                       )).Sum(x => x.Field<decimal>("Amount"));

                        //dk length tk credit
                        try
                        {
                            sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("CreditAccount").Length >= 4 &&
                        y.Field<string>("CreditAccount").Substring(0, 5) == "1388" && (y.Field<string>("DebitAccount").Substring(0, 3) == "241" || y.Field<string>("DebitAccount").Substring(0, 3) == "211"))
                       )).Sum(x => x.Field<decimal>("Amount"));
                            //dk length tk credit
                            sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("CreditAccount").Length >= 4 &&
                            y.Field<string>("CreditAccount").Substring(0, 5) == "3338" && y.Field<string>("DebitAccount").Substring(0, 3) == "211")
                           )).Sum(x => x.Field<decimal>("Amount"));
                            //dk length tk DebitAccount
                            sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Length >= 4 &&
                            y.Field<string>("DebitAccount").Substring(0, 5) == "3339" && y.Field<string>("CreditAccount").Substring(0, 3) == "111")
                           )).Sum(x => x.Field<decimal>("Amount"));
                           
                        }
                        catch
                        {
                            //XtraMessageBox.Show(sotien + "-" + list[21], "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        list[21] = sotien;
                    }
                    else if (data.MaSo == "22")
                    {
                        sotien = temp.AsEnumerable().Where(y => (((y.Field<string>("DebitAccount").Substring(0, 3) == "111" 
                       ) && (y.Field<string>("CreditAccount").Substring(0, 3) == "241"))
                       )).Sum(x => x.Field<decimal>("Amount"));
                        //dk length tk credit
                        try
                        {
                            sotien += temp.AsEnumerable().Where(y => ((y.Field<string>("CreditAccount").Length >= 4 &&
                        ((y.Field<string>("CreditAccount").Substring(0, 5) == "2113" && y.Field<string>("DebitAccount").Substring(0, 3) == "111") ||
                         (y.Field<string>("CreditAccount").Substring(0, 5) == "2112" && y.Field<string>("DebitAccount").Substring(0, 3) == "111")))
                       )).Sum(x => x.Field<decimal>("Amount"));
                        }
                        catch { }
                        
                        list[22] = sotien;
                    }
                    else if (data.MaSo == "23")
                    {
                        sotien = temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Substring(0, 3) == "128"
                        && (y.Field<string>("CreditAccount").Substring(0, 3) == "111" || y.Field<string>("CreditAccount").Substring(0, 3) == "112")) ||
                       (y.Field<string>("DebitAccount").Substring(0, 3) == "228" && y.Field<string>("CreditAccount").Substring(0, 3) == "112")
                       )).Sum(x => x.Field<decimal>("Amount"));
                        list[23] = sotien;
                    }
                    else if (data.MaSo == "24")
                    {
                        sotien = temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Substring(0, 3) == "112"
                        && y.Field<string>("CreditAccount").Substring(0, 3) == "128")
                       )).Sum(x => x.Field<decimal>("Amount"));
                        list[24] = sotien;
                    }
                    else if (data.MaSo == "25")
                    {
                        sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Substring(0, 3) == "222"
                        && y.Field<string>("CreditAccount").Substring(0, 3) == "112")
                       )).Sum(x => x.Field<decimal>("Amount"));
                        list[25] = sotien;
                    }
                    else if (data.MaSo == "26")
                    {
                        sotien = temp.AsEnumerable().Where(y => ((y.Field<string>("DebitAccount").Substring(0, 3) == "111"
                        && y.Field<string>("CreditAccount").Substring(0, 3) == "2282" && y.Field<string>("CreditAccount").Length >= 4) ||
                       (y.Field<string>("DebitAccount").Substring(0, 3) == "112" && y.Field<string>("CreditAccount").Substring(0, 3) == "2281" && y.Field<string>("CreditAccount").Length >= 4)
                       )).Sum(x => x.Field<decimal>("Amount"));
                        list[26] = sotien;
                    }
                    else if (data.MaSo == "30")
                    {
                        list[30] = list[21] + list[22] + list[23] + list[24] + list[25] + list[26] + list[27];
                        sotien = list[30];
                    }
                    else if (data.MaSo == "32")
                    {
                        sotien -= temp.AsEnumerable().Where(y => (y.Field<string>("DebitAccount").Substring(0, 3) == "419"
                        && (y.Field<string>("CreditAccount").Substring(0, 3) == "112" || y.Field<string>("CreditAccount").Substring(0, 3) == "111")
                       )).Sum(x => x.Field<decimal>("Amount"));
                        list[32] = sotien;
                    }
                    else if (data.MaSo == "33")
                    {
                        sotien = temp.AsEnumerable().Where(y => (y.Field<string>("DebitAccount").Substring(0, 3) == "112"
                        && (y.Field<string>("CreditAccount").Substring(0, 3) == "311" || y.Field<string>("CreditAccount").Substring(0, 3) == "341")
                       )).Sum(x => x.Field<decimal>("Amount"));
                        //dk length tk credit
                        try
                        {
                            sotien += temp.AsEnumerable().Where(y => ((y.Field<string>("CreditAccount").Length >= 6 && y.Field<string>("DebitAccount").Substring(0, 3) == "331" &
                        (y.Field<string>("CreditAccount").Substring(0, 6) == "341111" || y.Field<string>("CreditAccount").Substring(0, 6) == "341112" || y.Field<string>("CreditAccount").Substring(0, 6) == "341116"))                          
                       )).Sum(x => x.Field<decimal>("Amount"));
                        }
                        catch { }
                        list[33] = sotien;
                    }
                    else if (data.MaSo == "34")
                    {
                        sotien -= temp.AsEnumerable().Where(y => (y.Field<string>("CreditAccount").Substring(0, 3) == "112"
                        && (y.Field<string>("DebitAccount").Substring(0, 3) == "311" || y.Field<string>("DebitAccount").Substring(0, 3) == "341")
                       )).Sum(x => x.Field<decimal>("Amount"));
                        //dk length tk credit
                        try
                        {
                            sotien -= temp.AsEnumerable().Where(y => ((y.Field<string>("CreditAccount").Length >= 4 && y.Field<string>("DebitAccount").Length >= 5 &
                        (y.Field<string>("DebitAccount").Substring(0, 5) == "11226" && y.Field<string>("CreditAccount").Substring(0, 4) == "1281"))
                       )).Sum(x => x.Field<decimal>("Amount"));
                        }
                        catch { }
                        list[34] = sotien;
                    }
                    else if (data.MaSo == "36")
                    {
                        sotien -= temp.AsEnumerable().Where(y => (y.Field<string>("DebitAccount").Substring(0, 3) == "421"
                        && (y.Field<string>("CreditAccount").Substring(0, 3) == "111" || y.Field<string>("CreditAccount").Substring(0, 3) == "112")
                       )).Sum(x => x.Field<decimal>("Amount"));
                        
                        list[36] = sotien;
                    }
                    else if (data.MaSo == "40")
                    {
                        list[40] = list[31] + list[32] + list[33] + list[34] + list[35] + list[36];
                        sotien = list[40];
                    }
                    else if (data.MaSo == "50")
                    {
                        list[50] = list[20] + list[30] + list[40];
                        sotien = list[50];
                    }
                    else if (data.MaSo == "60")
                    {
                        //list[60] = list[20] + list[30] + list[40];
                        mySQL = "SELECT SUM(DebitAmount - CreditAmount) from AccountAccumulated where Month(PostDate) = " + thangso + " and Year(PostDate)=" + namso;
                        mySQL +=" and(SUBSTRING(AccountNumber, 1, 3) = '111' or SUBSTRING(AccountNumber, 1, 3) = '112')";
                        try
                        {
                            list[60] = decimal.Parse(gen.GetString(mySQL));
                        }
                        catch { }
                        sotien = list[60];
                    }
                    else if (data.MaSo == "70")
                    {
                        list[70] = list[50] + list[60];
                        sotien = list[70];
                    }

                }
                catch { }
                //catch (Exception ex )
                //{ XtraMessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information); }                    
               
                dr[3] = sotien;
                dt.Rows.Add(dr);
                txtSQL.Text = list[21] + "";
            }
            
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.OptionsView.ShowFooter = true;
            view.Columns["STT"].Visible = false;
            //view.Columns["ClientID"].Visible = false;
            /*view.Columns["CompanyCode"].Visible = false;
            view.Columns["Year"].Visible = false;
            view.Columns["Month"].Visible = false;*/
            view.Columns["STT"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            view.Columns["Chỉ tiêu"].Width = 1000;
            view.Columns["Mã số"].BestFit();            
            view.Columns["Số tiền"].Width = 100;            
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            

            //txtSQL.Text = ngaydau + ngaycuoi;
        }

        private void load_form_CDTK()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));
            int nam = Int32.Parse(txtYear.Text);
            int thang = Int32.Parse(txtMonth.Text);
            int thangtruoc = thang - 1;

            string mySQL = "DECLARE @tab1 AS TABLE (col1 nvarchar(100),col2 nvarchar(100),col3 nvarchar(10),col4 money,col5 money,col6 money,col7 money,col8 money,col9 money,col10 money,col11 money)";
            mySQL += " insert into @tab1 select AccountingObjectID,StockID,AccountNumber,0,0,0,0,0,0,DebitAmount,CreditAmount from AccountAccumulated where Month(PostDate)=" + thangtruoc + " and Year(PostDate)=" + nam;
            mySQL += " insert into @tab1 select AccountingObjectID,StockID,AccountNumber,0,0,0,0,DebitArising,CreditArising,0,0 from AccountAccumulated where Month(PostDate)>=" + thangtruoc + "  and Month(PostDate)<= " + thang + " and Year(PostDate)=" + nam;
            mySQL += " insert into @tab1 select AccountingObjectID,StockID,AccountNumber,DebitAmount,CreditAmount,DebitAccumulated,CreditAccumulated,0,0,0,0 from AccountAccumulated where Month(PostDate)= " + thang + " and Year(PostDate)=" + nam;
            mySQL += " select col3, AccountName, COALESCE(sum(col4), 0), COALESCE(sum(col5), 0), COALESCE(sum(col6), 0), COALESCE(sum(col7), 0), COALESCE(sum(col8), 0), COALESCE(sum(col9), 0), COALESCE(sum(col10), 0), COALESCE(sum(col11), 0) from @tab1 a,Account b where col3 = AccountNumber  group by col3,AccountName";
            DataTable temp = new DataTable();
            try
            {
                temp = gen.GetTable(mySQL);
                Double dkn = 0, dkc = 0, psn = 0, psc = 0, lkn = 0, lkc = 0, ckn = 0, ckc = 0;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0 || Double.Parse(temp.Rows[i][9].ToString()) != 0 || Double.Parse(temp.Rows[i][2].ToString()) != 0 || Double.Parse(temp.Rows[i][3].ToString()) != 0 || Double.Parse(temp.Rows[i][6].ToString()) != 0 || Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    {
                        if (temp.Rows[i][0].ToString() == "156" || temp.Rows[i][0].ToString() == "1561" || temp.Rows[i][0].ToString() == "1562")
                        {
                            if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                                ckn = ckn + Double.Parse(temp.Rows[i][8].ToString());
                            if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                                ckc = ckc + Double.Parse(temp.Rows[i][9].ToString());

                            if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                                dkn = dkn + Double.Parse(temp.Rows[i][2].ToString());
                            if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                                dkc = dkc + Double.Parse(temp.Rows[i][3].ToString());

                            if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                                psn = psn + Double.Parse(temp.Rows[i][4].ToString());
                            if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                                psc = psc + Double.Parse(temp.Rows[i][5].ToString());

                            if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                                lkn = lkn + Double.Parse(temp.Rows[i][6].ToString());
                            if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                                lkc = lkc + Double.Parse(temp.Rows[i][7].ToString());

                            if (temp.Rows[i][0].ToString() == "1562" || (temp.Rows[i][0].ToString() == "1561" && temp.Rows[i + 1][0].ToString() != "1562"))
                            {
                                DataRow dr = dt.NewRow();
                                dr[0] = "156";
                                dr[1] = "Hàng hóa";

                                if (ckn != 0 || ckc != 0)
                                    dr[2] = ckn - ckc;
                                /*if (ckc != 0)
                                    dr[3] = ckc;*/

                                if (dkn != 0 || dkc != 0)
                                    dr[8] = dkn - dkc;
                                /*if (dkc != 0)
                                    dr[9] = dkc;*/

                                if (psn != 0)
                                    dr[6] = psn;
                                if (psc != 0)
                                    dr[7] = psc;

                                if (lkn != 0)
                                    dr[4] = lkn;
                                if (lkc != 0)
                                    dr[5] = lkc;

                                dt.Rows.Add(dr);
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = temp.Rows[i][0];
                            dr[1] = temp.Rows[i][1];

                            if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                                dr[2] = temp.Rows[i][8];
                            if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                                dr[3] = temp.Rows[i][9];

                            if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                                dr[8] = temp.Rows[i][2];
                            if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                                dr[9] = temp.Rows[i][3];

                            if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                                dr[6] = temp.Rows[i][4];
                            if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                                dr[7] = temp.Rows[i][5];

                            if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                                dr[4] = temp.Rows[i][6];
                            if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                                dr[5] = temp.Rows[i][7];
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            catch { }
                lvpq.DataSource = dt;
            txtSQL.Text = mySQL;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.OptionsView.ShowFooter = true;
            //view.Columns["STT"].Visible = false;
            //view.Columns["ClientID"].Visible = false;
            //view.Columns["STT"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //view.Columns["Chỉ tiêu"].Width = 1000;
            view.Columns["Tài khoản"].BestFit();
            view.Columns["Tên tài khoản"].BestFit();
            view.Columns["Nợ đầu kỳ"].Width = 100;
            view.Columns["Có đầu kỳ"].Width = 100;
            view.Columns["Có đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Nợ đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ phát sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có phát sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ lũy kế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Có lũy kế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            view.Columns["Có cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            view.Columns["Có cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có lũy kế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ lũy kế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có phát sinh"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ phát sinh"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Có đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nợ đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }

        private decimal CDTK_NoCK(string accountNumber, int thangtruoc, int nam)
        {
            decimal kq = 0;
           /* var ctx = gen.GetNewEntity();
            var quy1 = ctx.AccountAccumulateds
             .Where(c => c.PostDate.Value.Month == thangtruoc && c.PostDate.Value.Year == nam && c.AccountNumber == accountNumber);                 
                if ((from x in quy1 select x.DebitAmount).Sum() != null) kq = (from x in quy1 select x.DebitAmount).Sum() ?? 0;
            */
            return kq;
        }

            private void load_form_CDKT() // can doi ke toan
        {
            //https://docs.google.com/spreadsheets/d/1YiTQoXWULmN62v6xVsLhV2s17C-XmSvo1rEglEUeM_4/edit#gid=0
            //sheet: https://docs.google.com/spreadsheets/d/1HonIEe3O09SHbVhV8HdQDsHFB4VQ62FqxDN4DuMlQac/edit#gid=0
            DataTable dt = new DataTable();            
            dt.Columns.Add("STT", Type.GetType("System.Double"));
            dt.Columns.Add("Chỉ tiêu", Type.GetType("System.String"));
            dt.Columns.Add("Mã số", Type.GetType("System.String"));
            dt.Columns.Add("Thuyết minh", Type.GetType("System.String"));
            dt.Columns.Add("Số cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Số đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("ClientID", Type.GetType("System.Double"));
            dt.Columns.Add("CompanyCode", Type.GetType("System.String"));
            dt.Columns.Add("Year", Type.GetType("System.Double"));
            dt.Columns.Add("Month", Type.GetType("System.Double"));
            int nam = Int32.Parse(txtYear.Text);
            int thang = Int32.Parse(txtMonth.Text);

            var ctx = gen.GetNewEntity();
            var query2 = ctx.BaoCaoBangCanDoiKeToan_Period
                .Where(c=>c.CompanyCode == Globals.companycode && c.Year == nam && c.Month == thang)
                .OrderBy(x => x.STT);
            if (query2.FirstOrDefault() == null) // tinh toan
            {
                var query = ctx.BaoCaoBangCanDoiKeToans
                .OrderBy(x => x.OrderID);
                decimal[] list = new decimal[116]; decimal[] list2 = new decimal[116];
                list[0] = 1; list2[0] = 1;
                string thangtruoc = (Int32.Parse(txtMonth.Text) - 1).ToString();
                List<BaoCaoBangCanDoiKeToan_Period> data2 = new List<BaoCaoBangCanDoiKeToan_Period>();

                foreach (var data in query)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = data.STT;
                    dr[1] = data.ChiTieu;
                    dr[2] = data.MaSo;
                    dr[3] = data.ThuyetMinh;
                    list[data.OrderID] = soCDKT(data.MaSo, Int32.Parse(txtMonth.Text), Int32.Parse(txtYear.Text)); 
                    dr[4] = list[data.OrderID];
                    list2[data.OrderID] = soluyke_CDKT(data.MaSo, thangtruoc, txtMonth.Text, txtYear.Text);
                    dr[5] = list2[data.OrderID];
                    if (data.MaSo == "221")
                    {
                        list[38] = list[1] + list[2];
                        list2[38] = list2[1] + list2[2];
                        dr[4] = list[38];
                        dr[5] = list2[38];
                    }
                    if (data.MaSo == "224")
                    {
                        list[39] = list[3] + list[4];
                        list2[39] = list2[3] + list2[4];
                        dr[4] = list[39];
                        dr[5] = list2[39];
                    }
                    if (data.MaSo == "227")
                    {
                        list[40] = list[5] + list[6];
                        list2[40] = list2[5] + list2[6];
                        dr[4] = list[40];
                        dr[5] = list2[40];
                    }
                    if (data.MaSo == "230")
                    {
                        list[102] = list[41] + list[42];
                        list2[102] = list2[41] + list2[42];
                        dr[4] = list[102];
                        dr[5] = list2[102];
                    }
                    if (data.MaSo == "240")
                    {
                        list[103] = list[43] + list[44];
                        list2[103] = list2[43] + list2[44];
                        dr[4] = list[103];
                        dr[5] = list2[103];
                    }
                    if (data.MaSo == "250")
                    {
                        list[104] = list[45] + list[46] + list[47] + list[48] + list[49];
                        list2[104] = list2[45] + list2[46] + list2[47] + list2[48] + list2[49];
                        dr[4] = list[104];
                        dr[5] = list2[104];
                    }
                    if (data.MaSo == "260")
                    {
                        list[105] = list[50] + list[51] + list[52] + list[53];
                        list2[105] = list2[50] + list2[51] + list2[52] + list2[53];
                        dr[4] = list[105];
                        dr[5] = list2[105];
                    }
                    if (data.MaSo == "270")
                    {
                        list[112] = list[110] + list[111];
                        list2[112] = list2[110] + list2[111];
                        dr[4] = list[112];
                        dr[5] = list2[112];
                    }
                    if (data.MaSo == "100")
                    {
                        list[110] = list[95] + list[96] + list[97] + list[98] + list[99];
                        list2[110] = list2[95] + list2[96] + list2[97] + list2[98] + list2[99];
                        dr[4] = list[110];
                        dr[5] = list2[110];
                    }
                    if (data.MaSo == "110")
                    {
                        list[95] = list[11] + list[12];
                        list2[95] = list2[11] + list2[12];
                        dr[4] = list[95];
                        dr[5] = list2[95];
                    }
                    if (data.MaSo == "120")
                    {
                        list[96] = list[13] + list[14] + list[15];
                        list2[96] = list2[13] + list2[14] + list2[15];
                        dr[4] = list[96];
                        dr[5] = list2[96];
                    }
                    if (data.MaSo == "130")
                    {
                        list[97] = list[16] + list[17] + list[18] + list[19] + list[20] + list[21] + list[22] + list[23];
                        list2[97] = list2[16] + list2[17] + list2[18] + list2[19] + list2[20] + list2[21] + list2[22] + list2[23];
                        dr[4] = list[97];
                        dr[5] = list2[97];
                    }
                    if (data.MaSo == "140")
                    {
                        list[98] = list[24] + list[25];
                        list2[98] = list2[24] + list2[25];
                        dr[4] = list[98];
                        dr[5] = list2[98];
                    }
                    if (data.MaSo == "150")
                    {
                        list[99] = list[26] + list[27] + list[28] + list[29] + list[30];
                        list2[99] = list2[26] + list2[27] + list2[28] + list2[29] + list2[30];
                        dr[4] = list[98];
                        dr[5] = list2[98];
                    }
                    if (data.MaSo == "200")
                    {
                        list[111] = list[100] + list[101] + list[102] + list[103] + list[104] + list[105];
                        list2[111] = list2[100] + list2[101] + list2[102] + list2[103] + list2[104] + list2[105];
                        dr[4] = list[111];
                        dr[5] = list2[111];
                    }
                    if (data.MaSo == "210")
                    {
                        list[100] = list[31] + list[32] + list[33] + list[34] + list[35] + list[36] + list[37];
                        list2[100] = list2[31] + list2[32] + list2[33] + list2[34] + list2[35] + list2[36] + list2[37];
                        dr[4] = list[100];
                        dr[5] = list2[100];
                    }
                    if (data.MaSo == "220")
                    {
                        list[101] = list[38] + list[39] + list[40];
                        list2[101] = list2[38] + list2[39] + list2[40];
                        dr[4] = list[101];
                        dr[5] = list2[101];
                    }
                    if (data.MaSo == "300")
                    {
                        list[113] = list[106] + list[107];
                        list2[113] = list2[106] + list2[107];
                        dr[4] = list[113];
                        dr[5] = list2[113];
                    }
                    if (data.MaSo == "310")
                    {
                        list[106] = list[54] + list[55] + list[56] + list[57] + list[58] + list[59] + list[60] + list[61] + list[62] + list[63] + list[64] + list[65] + list[66] + list[67];
                        list2[106] = list2[54] + list2[55] + list2[56] + list2[57] + list2[58] + list2[59] + list2[60] + list2[61] + list2[62] + list2[63] + list2[64] + list2[65] + list2[66] + list2[67];
                        dr[4] = list[106];
                        dr[5] = list2[106];
                    }
                    if (data.MaSo == "330")
                    {
                        list[107] = list[68] + list[69] + list[70] + list[71] + list[72] + list[73] + list[74] + list[75] + list[76] + list[77] + list[78] + list[79] + list[80];
                        list2[107] = list2[68] + list2[69] + list2[70] + list2[71] + list2[72] + list2[73] + list2[74] + list2[75] + list2[76] + list2[77] + list2[78] + list2[79] + list2[80];
                        dr[4] = list[107];
                        dr[5] = list2[107];
                    }
                    if (data.MaSo == "400")
                    {
                        list[114] = list[108] + list[109];
                        list2[114] = list2[108] + list2[109];
                        dr[4] = list[114];
                        dr[5] = list2[114];
                    }
                    if (data.MaSo == "410")
                    {
                        list[108] = list[81] + list[82] + list[83] + list[84] + list[85] + list[86] + list[87] + list[88] + list[89] + list[90] + list[91] + list[92];
                        list2[108] = list2[81] + list2[82] + list2[83] + list2[84] + list2[85] + list2[86] + list2[87] + list2[88] + list2[89] + list2[90] + list2[91] + list2[92];
                        dr[4] = list[108];
                        dr[5] = list2[108];
                    }
                    if (data.MaSo == "411")
                    {
                        list[81] = list[7] + list[8];
                        list2[81] = list2[7] + list2[8];
                        dr[4] = list[81];
                        dr[5] = list2[81];
                    }
                    if (data.MaSo == "421")
                    {
                        list[91] = list[9] + list[10];
                        list2[91] = list2[9] + list2[10];
                        dr[4] = list[91];
                        dr[5] = list2[91];
                    }
                    if (data.MaSo == "430")
                    {
                        list[109] = list[93] + list[94];
                        list2[109] = list2[93] + list2[94];
                        dr[4] = list[109];
                        dr[5] = list2[109];
                    }
                    if (data.MaSo == "440")
                    {
                        list[115] = list[113] + list[114];
                        list2[115] = list2[113] + list2[114];
                        dr[4] = list[115];
                        dr[5] = list2[115];
                    }

                    dr[6] = Globals.clientid;
                    dr[7] = Globals.companycode;
                    dr[8] = Int32.Parse(txtYear.Text);
                    dr[9] = Int32.Parse(txtMonth.Text);
                    dt.Rows.Add(dr);
                    BaoCaoBangCanDoiKeToan_Period obj = new BaoCaoBangCanDoiKeToan_Period();
                    obj.STT = data.STT;
                    obj.ChiTieu = data.ChiTieu;
                    obj.OrderID = data.OrderID;
                    obj.MaSo = data.MaSo;
                    obj.ThuyetMinh = data.ThuyetMinh;
                    obj.Quy1 = Convert.ToDecimal(dr[4], null);
                    obj.Quy2 = Convert.ToDecimal(dr[5], null);
                    //obj.ClientID = Globals.clientid;
                    obj.CompanyCode = Globals.companycode;
                    obj.Year = Int32.Parse(txtYear.Text);
                    obj.Month = Int32.Parse(txtMonth.Text);
                    data2.Add(obj); // object table
                                   
                    
                }// for each
                 // update DB
                try
                {
                    Insert_CDKT(data2 as List<BaoCaoBangCanDoiKeToan_Period>);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // view ket qua
                foreach (var data in query2)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = data.STT;
                    dr[1] = data.ChiTieu;
                    dr[2] = data.MaSo;
                    dr[3] = data.ThuyetMinh;
                    dr[4] = data.Quy1;
                    dr[5] = data.Quy2;
                    dr[6] = Globals.clientid;
                    dr[7] = Globals.companycode;
                    dr[8] = Int32.Parse(txtYear.Text);
                    dr[9] = Int32.Parse(txtMonth.Text);
                    dt.Rows.Add(dr);
                }
            }


            //dt.Rows.Add(dr);
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.OptionsView.ShowFooter = true;
            view.Columns["STT"].Visible = false;
            view.Columns["ClientID"].Visible = false;
            /*view.Columns["CompanyCode"].Visible = false;
            view.Columns["Year"].Visible = false;
            view.Columns["Month"].Visible = false;*/
            view.Columns["STT"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            view.Columns["Chỉ tiêu"].Width = 1000;
            view.Columns["Mã số"].BestFit();
            view.Columns["Thuyết minh"].BestFit();
            view.Columns["Số cuối kỳ"].Width = 100;
            view.Columns["Số đầu kỳ"].Width = 100;
            view.Columns["Số đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            
        }

        private void Insert_CDKT(List<BaoCaoBangCanDoiKeToan_Period> list)
        {
            /*DapperPlusManager.Entity<BaoCaoBangCanDoiKeToan_Period>().Table("BaoCaoBangCanDoiKeToan_Period");
            SqlConnection conn = gen.GetConn(); //khai bao 1 doi tuong Connection    

            using (IDbConnection db = conn)
            {
                try
                {
                    db.BulkInsert(list);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                }

            }*/
        }

        private decimal soCDKT_Debit(string AccountCategoryID, int month, int year)  // can doi ke toan debit
        {
            decimal kq = 0;
             var ctx = gen.GetNewEntity();
            var quy1 = ctx.FIDocumentDetails
                          .Join(ctx.Accounts, a => a.DebitAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.RefDate, a.Posted })
                 .Where(c => (c.AccountCategoryID == AccountCategoryID)
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

            if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            return kq;
        }
        private decimal soCDKT_Debit(string AccountCategoryID, string AccountNumber, int month, int year)  // can doi ke toan debit
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var quy1 = ctx.FIDocumentDetails
                          .Join(ctx.Accounts, a => a.DebitAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.RefDate, a.Posted })
                 .Where(c => (c.AccountCategoryID == AccountCategoryID || c.AccountNumber == AccountNumber)
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

            if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            return kq;
        }
        private decimal soCDKT_Credit(string AccountCategoryID, string AccountNumber, int month, int year)  // can doi ke toan debit
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var quy1 = ctx.FIDocumentDetails
                          .Join(ctx.Accounts, a => a.CreditAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.RefDate, a.Posted })
                 .Where(c => (c.AccountCategoryID == AccountCategoryID || c.AccountNumber == AccountNumber)
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

            if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            return kq;
        }
        private decimal soCDKT_Credit(string AccountCategoryID, int month, int year)  // can doi ke toan debit
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var quy1 = ctx.FIDocumentDetails
                          .Join(ctx.Accounts, a => a.CreditAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.RefDate, a.Posted })
                 .Where(c => (c.AccountCategoryID == AccountCategoryID)
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

            if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            return kq;
        }
        private decimal soCDKT_Debit2(string AccountNumber, int month, int year)  // can doi ke toan debit
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var quy1 = ctx.FIDocumentDetails
                 .Where(c => (c.DebitAccount == AccountNumber)
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

            if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            return kq;
        }
        private decimal soCDKT_Debit2(string AccountNumber1 , string AccountNumber2, string AccountNumber3, int month, int year)  // can doi ke toan debit 3 tham so
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var quy1 = ctx.FIDocumentDetails
                 .Where(c => (c.DebitAccount == AccountNumber1|| c.DebitAccount == AccountNumber2|| c.DebitAccount == AccountNumber3)
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

            if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;

            return kq;
        }
        private decimal soCDKT_Credit2(string AccountNumber, int month, int year)  // can doi ke toan credit
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var quy1 = ctx.FIDocumentDetails
                 .Where(c => (c.CreditAccount == AccountNumber)
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

            if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            return kq;
        }
        private decimal soCDKT_Credit2(string AccountNumber1, string AccountNumber2, string AccountNumber3, int month, int year)  // can doi ke toan credit 3 tham so
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();
            var quy1 = ctx.FIDocumentDetails
                 .Where(c => (c.CreditAccount == AccountNumber1 || c.CreditAccount == AccountNumber2 || c.CreditAccount == AccountNumber3)
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

            if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;

            return kq;
        }

        private void lvpq_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            p.export_Excel("Báo cáo",view);
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {

        }

        private void view_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (Globals.transactioncode == "DNDH")
                {
                    Frm_ProductOrder m = new Frm_ProductOrder();
                    m.getactive("2"); // view thoi
                    m.getMMDoc(view.GetRowCellValue(view.FocusedRowHandle, "MMDoc").ToString());                    
                    m.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtSQL.Text = sql;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (Globals.transactioncode == "DNDH")
            {
                Frm_ProductOrder m = new Frm_ProductOrder();
                m.getactive("0"); // create don dat hang MM              
                m.ShowDialog();
            }
            else if(Globals.transactioncode == "PTTM" || Globals.transactioncode == "PCTM" || Globals.transactioncode == "PCNH" || Globals.transactioncode == "PTNH"
                || Globals.transactioncode == "PHKT") //specs: https://docs.google.com/document/d/1sYAv27WsAv9VDewNP5jDPd92Pydu1b0v3eR0JbmzuQo/edit
            {
                Frm_FIDocument_New m = new Frm_FIDocument_New();
                m.getactive("0"); // create phieu FI               
                m.ShowDialog();
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
                    XtraMessageBox.Show(ex.Message, "btnNew_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Globals.transactioncode == "CU00" || Globals.transactioncode == "VE00")
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Globals.transactioncode == "DNDH")
            {               
                Frm_ProductOrder m = new Frm_ProductOrder();
                m.getactive("1"); // edit
                m.getMMDoc(view.GetRowCellValue(view.FocusedRowHandle, gen.getFieldNameVN("DNDH", "MMDoc")).ToString());
                m.ShowDialog();
            }
            else if (Globals.transactioncode == "PTTM" || Globals.transactioncode == "PCTM" || Globals.transactioncode == "PCNH" || Globals.transactioncode == "PTNH"
                || Globals.transactioncode == "PHKT")
            {                
                Frm_FIDocument_New m = new Frm_FIDocument_New();
                m.getactive("1"); // edit                
                m.getFIDoc(view.GetRowCellValue(view.FocusedRowHandle, gen.getFieldNameVN(Globals.transactioncode, "FIDoc")).ToString());
                m.ShowDialog();
            }
        }

     
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (Globals.transactioncode == "DNDH")
            {
                Frm_ProductOrder m = new Frm_ProductOrder();
                m.getactive("2"); // view thoi
                m.getMMDoc(view.GetRowCellValue(view.FocusedRowHandle, gen.getFieldNameVN("DNDH", "MMDoc")).ToString());
                m.ShowDialog();
            }
            else if (Globals.transactioncode == "BCTK")
            {
                Frm_CTXNT m = new Frm_CTXNT(); // chi tiet xuat nhap ton cua 1 ma hh
                m.getactive("2"); // view thoi                
                m.getMaHH(view.GetRowCellValue(view.FocusedRowHandle, gen.getFieldNameVN("BCTK", "InventoryItemCode")).ToString());
                m.ShowDialog();
            }
            else if (Globals.transactioncode == "PTTM" || Globals.transactioncode == "PCTM" || Globals.transactioncode == "PCNH" || Globals.transactioncode == "PTNH"
                || Globals.transactioncode == "PHKT")
            {
                Frm_FIDocument_New m = new Frm_FIDocument_New();
                m.getactive("2"); // view                
                m.getFIDoc(view.GetRowCellValue(view.FocusedRowHandle, gen.getFieldNameVN(Globals.transactioncode, "FIDoc")).ToString());
                m.ShowDialog();
            }
            else if (Globals.transactioncode == "SOCAI")
            {
                Frm_BaoCao m = new Frm_BaoCao(); // chi tiet phieu FIDocumentDetail cua 1 tk
                m.gettransactioncode("SOCAICT"); // view chi tiet so cai                
                m.getAccountNumber(view.GetRowCellValue(view.FocusedRowHandle, gen.getFieldNameVN("SOCAI", "AccountNumber")).ToString());
                m.getYear(txtYear.Text);
                m.getMonth(txtMonth.Text);
                m.ShowDialog();
            }
            else if (Globals.transactioncode == "BCCN")
            {
                Frm_BaoCao m = new Frm_BaoCao(); // chi tiet bao cao cong no cua 1 tk
                m.gettransactioncode("BCCNCT");
                m.getAccountNumber(txtAccountNumber.EditValue.ToString());
                m.getStockCode(ledv.EditValue.ToString());
                m.getAccountingObjectCode(view.GetRowCellValue(view.FocusedRowHandle, gen.getFieldNameVN("BCCN", "AccountingObjectCode")).ToString());
                m.getYear(txtYear.Text);
                m.getMonth(txtMonth.Text);
                m.ShowDialog();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (Globals.transactioncode == "BCTK")
            {
                Frm_BCTK_Copy m = new Frm_BCTK_Copy(); // copy so lieu ton kho
                m.getStockCode(ledv.EditValue.ToString()); // view thoi                
                m.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private decimal soCDKT_Debit(string AccountCategoryID, string AccountNumber, string month, string year)  // can doi ke toan debit 2 tham so
        {
            decimal kq = 0;
           /* var ctx = gen.GetNewEntity();
            var quy1 = ctx.AccountAccumulateds
                          .Join(ctx.Accounts, a => a.AccountNumber, b => b.AccountNumber,
                 (a, b) => new { a.DebitAmount, b.AccountCategoryID, b.AccountNumber, a.PostDate })
                 .Where(c => (c.AccountCategoryID == AccountCategoryID || c.AccountNumber == AccountNumber) && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
            if ((from x in quy1 select x.DebitAmount).Sum() != null) kq = (from x in quy1 select x.DebitAmount).Sum() ?? 0;*/
            return kq;
        }
        private decimal soCDKT_Credit(string AccountCategoryID, string AccountNumber, string month, string year)  // can doi ke toan credit 2 tham so
        {
            decimal kq = 0;
           /* var ctx = gen.GetNewEntity();
            var quy1 = ctx.AccountAccumulateds
                          .Join(ctx.Accounts, a => a.AccountNumber, b => b.AccountNumber,
                 (a, b) => new { a.CreditAmount, b.AccountCategoryID, b.AccountNumber, a.PostDate })
                 .Where(c => (c.AccountCategoryID == AccountCategoryID || c.AccountNumber == AccountNumber) && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
            if ((from x in quy1 select x.CreditAmount).Sum() != null) kq = (from x in quy1 select x.CreditAmount).Sum() ?? 0;*/
            return kq;
        }
        private decimal soCDKT(string code, int month, int year)  // can doi ke toan
        {
            decimal kq = 0;
            var ctx = gen.GetNewEntity();            
            if (code == "111")
            {
                var quy1 = ctx.FIDocumentDetails
                          .Join(ctx.Accounts, a => a.DebitAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.RefDate, a.Posted })
                 .Where(c => (c.AccountCategoryID == "111" || c.AccountCategoryID == "112" || c.AccountCategoryID == "113") 
                 && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);                

                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            }
            else if(code == "112")
            {
                var quy1 = ctx.FIDocumentDetails.Where(c => (c.DebitAccount == "1281" || c.DebitAccount == "1288")
                   && c.RefDate.Value.Month == month && c.RefDate.Value.Year == year && c.Posted == 1);

                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            }
            else if(code == "121" || code == "131")
            {
                kq = soCDKT_Debit(code, month, year);
            }
            else if (code == "132")
            {
                kq = soCDKT_Debit("331", month, year);
            }
            else if (code == "133")
            {
                kq = soCDKT_Debit2("1362", "1363", "1368", month, year);
            }
            else if (code == "134")
            {
                kq = soCDKT_Debit2("337", month, year);
            }
            else if (code == "135")
            {
                kq = soCDKT_Debit2("1283", month, year);
            }
            else if (code == "136")
            {                
                var quy1 = ctx.FIDocumentDetails
                          .Join(ctx.Accounts, a => a.DebitAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.RefDate, a.Posted })
                 .Where(c => (c.AccountCategoryID == "334" || c.AccountCategoryID == "338" || c.AccountCategoryID == "141" 
                 || c.AccountNumber == "1385" || c.AccountNumber == "1388") && c.RefDate.Value.Month == month && c.Posted == 1
                 && c.RefDate.Value.Year == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;                
            }
            else if (code == "137")
            {
                kq -= soCDKT_Credit2("2293", month, year);
            }
            else if (code == "139")
            {
                kq = soCDKT_Debit2("1381", month, year);
            }
            else if (code == "122")
            {
                kq -= soCDKT_Credit2("2291", month, year);
            }
            else if (code == "123")
            {
                kq = soCDKT_Debit2("1282", month, year);                
            }
            else if (code == "141")
            {
                var quy1 = ctx.FIDocumentDetails
                          .Join(ctx.Accounts, a => a.DebitAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.RefDate, a.Posted })
                 .Where(c => (c.AccountCategoryID == "151" || c.AccountCategoryID == "152" || c.AccountCategoryID == "153" || c.AccountCategoryID == "154"
                 || (c.AccountCategoryID == "156" && c.AccountCategoryID != "1563") || c.AccountCategoryID == "158") && c.RefDate.Value.Month == month && c.Posted == 1
                 && c.RefDate.Value.Year == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
              
            }
            
            else if (code == "149")
            {
                kq -= soCDKT_Credit2("2294", month, year);
            }           
            else if (code == "152")
            {
                kq = soCDKT_Debit("133", month, year);
            }
            else if (code == "153")
            {
                kq = soCDKT_Debit("333", month, year);
            }
            else if (code == "154")
            {
                kq = soCDKT_Debit("171", month, year);
            }
            else if (code == "155") // khoi tinh 151,212,215,219
            {
               // kq = soCDKT_Debit2("0", month, year);
            }
            else if (code == "213")
            {
                kq = soCDKT_Debit2("1361", month, year);
            }
            else if (code == "214")
            {
                kq = soCDKT_Debit2("1362", "1363", "1368", month, year);
            }
            else if (code == "216")
            {
                kq = soCDKT_Debit("244", month, year);
            }
            else if (code == "222")
            {
                kq = soCDKT_Debit("211", month, year);
            }
            else if (code == "223")
            {
                kq -= soCDKT_Credit2("2141", month, year); // so am
            }
            else if (code == "225")
            {
                kq = soCDKT_Debit("212", month, year);
            }
            else if (code == "226")
            {
                kq -= soCDKT_Credit2("2142", month, year);
            }
            else if (code == "228")
            {
                kq = soCDKT_Debit("213", month, year);
            }
            else if (code == "229")
            {
                kq -= soCDKT_Credit2("2143", month, year);
            }
            else if (code == "231")
            {
                kq = soCDKT_Debit("217", month, year);
            }
            else if (code == "232")
            {
                kq -= soCDKT_Credit2("2147", month, year);
            }
            else if (code == "241")
            {
                kq = soCDKT_Debit2("2294", month, year);
            }
            else if (code == "242")
            {
                kq = soCDKT_Debit("241", month, year);
            }
            else if (code == "251")
            {
                kq = soCDKT_Debit("221", month, year);
            }
            else if (code == "252")
            {
                kq = soCDKT_Debit("222", month, year);
            }
            else if (code == "253")
            {
                kq = soCDKT_Debit2("2281", month, year);
            }
            else if (code == "254")
            {
                kq -= soCDKT_Credit2("2292", month, year);
            }
            else if (code == "255")
            {
               // khong can tinh
            }
            else if (code == "261")
            {
                kq = soCDKT_Debit("242", "1563", month, year);               
            }
            else if (code == "262")
            {
                kq = soCDKT_Debit("243", month, year);
            }
            else if (code == "263")
            {
                kq = soCDKT_Debit2("1534", month, year);
            }
            else if (code == "268")
            {
                kq = soCDKT_Debit2("2288", month, year);
            }
            if (code == "311") 
            {
                kq = soCDKT_Credit("331", month, year);
            }
            if (code == "312") 
            {
                kq = soCDKT_Credit("131", month, year);
            }
            if (code == "313") 
            {
                kq = soCDKT_Credit("333", month, year);
            }
            else if (code == "314")
            {
                kq = soCDKT_Credit("334", month, year);
            }
            else if (code == "315")
            {
                kq = soCDKT_Credit("335", month, year);
            }
            else if (code == "316")
            {
                kq = soCDKT_Credit2("3362", "3363", "3368", month, year);
            }
            else if (code == "317")
            {
                kq = soCDKT_Credit("337", month, year);
            }
            else if (code == "318")
            {
                kq = soCDKT_Credit2("3387", month, year); // so duong
            }
            else if (code == "319")
            {
                var quy1 = ctx.FIDocumentDetails
                          .Join(ctx.Accounts, a => a.CreditAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.RefDate, a.Posted })
                 .Where(c => ((c.AccountCategoryID == "338" && c.AccountNumber != "3387") || c.AccountCategoryID == "138" || c.AccountCategoryID == "344")
                 && c.RefDate.Value.Month == month && c.Posted == 1
                 && c.RefDate.Value.Year == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
               
                kq -= soCDKT_Debit("344", month, year); 
            }
            else if (code == "320")
            {
                kq = soCDKT_Credit("341", "34311", month, year); // or
            }
            else if (code == "321")
            {
                kq = soCDKT_Credit("352", month, year);
            }
            else if (code == "322")
            {
                kq = soCDKT_Credit("353", month, year);
            }
            else if (code == "323")
            {
                kq = soCDKT_Credit("357", month, year);
            }
            else if (code == "324")
            {
                kq = soCDKT_Credit("171", month, year);
            }
            else if (code == "334")
            {
                kq = soCDKT_Credit2("3361", month, year);
            }
            else if (code == "335")
            {
                kq = soCDKT_Credit2("3363", "3363", "3368", month, year);
            }
            else if (code == "338")
            {                
                kq = soCDKT_Credit2("34313", month, year) - soCDKT_Debit2("34312", month, year);
            }
            else if (code == "339")
            {
                kq = soCDKT_Credit2("3432", month, year);   
            }
            else if (code == "340")
            {
                kq = soCDKT_Credit2("41112", month, year);
            }
            else if (code == "341")
            {
                kq = soCDKT_Credit("347", month, year); 
            }
            else if (code == "343")
            {
                kq = soCDKT_Credit("356", month, year);
            }
            else if (code == "411a")
            {
                kq = soCDKT_Credit2("41111", "41111", "4111", month, year);
            }
            else if (code == "411b")
            {
                kq = soCDKT_Credit2("41112", month, year);
            }
            else if (code == "412")
            {
                kq = soCDKT_Credit2("4112", month, year) - soCDKT_Debit2("4112", month, year); 
            }
            else if (code == "413")
            {
                kq = soCDKT_Credit2("4113", month, year);
            }
            else if (code == "414")
            {
                kq = soCDKT_Credit2("4118", month, year);
            }
            else if (code == "415")
            {
                kq -= soCDKT_Debit("419", month, year);
            }
            else if (code == "416")
            {
                kq = soCDKT_Credit("412", month, year)  - soCDKT_Debit("412", month, year);
            }
            else if (code == "417")
            {
                kq = soCDKT_Credit("413", month, year);
            }
            else if (code == "418")
            {
                kq = soCDKT_Credit("414", month, year);
            }
            else if (code == "419")
            {
                kq = soCDKT_Credit("417", month, year);
            }
            else if (code == "420")
            {
                kq = soCDKT_Credit("418", month, year) - soCDKT_Debit("418", month, year);                
            }
            else if (code == "421a")
            {
                kq = soCDKT_Credit2("4211", month, year) - soCDKT_Debit2("4211",month, year);
            }
            else if (code == "421b")
            {
                kq = soCDKT_Credit2("4212", month, year) - soCDKT_Debit2("4212", month, year);
            }
            else if (code == "422")
            {
                kq = soCDKT_Credit("441", month, year);
            }
            else if (code == "432")
            {
                kq = soCDKT_Credit("466", month, year);
            }
            return kq;
        }

        private void load_form_HDKD()
        {
            
            string thangtruoc = (Int32.Parse(txtMonth.Text) - 1).ToString(); 

            //string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString(); 
            //string namdauky = DateTime.Parse(ngaychungtu).AddYears(-1).Year.ToString();

            DataTable dt = new DataTable();
            dt.Columns.Add("Chỉ tiêu", Type.GetType("System.String"));
            dt.Columns.Add("Mã số", Type.GetType("System.String"));
            dt.Columns.Add("Thuyết minh", Type.GetType("System.String"));            
            dt.Columns.Add("Số cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Số đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Lũy kế", Type.GetType("System.Double"));

            
            var ctx = gen.GetNewEntity();
            var query = ctx.BaoCaoKetQuaHoatDongKinhDoanhs
                 .OrderBy(x => x.STT);            
            decimal[] list = new decimal[19]; decimal[] list2 = new decimal[19];
            list[0] = 1; list2[0] = 1;

            string sql = "delete Targets2 where Month(PostDate)= " + txtMonth.Text + " and Year(PostDate)= " + txtYear.Text;            
            foreach (var data in query)
            {
                DataRow dr = dt.NewRow();                
                dr[0] = data.ChiTieu ;
                dr[1] = data.MaSo;
                dr[2] = data.ThuyetMinh;
                list[data.STT] = SoHDKD(data.MaSo, txtMonth.Text, txtYear.Text); ;
                list2[data.STT] = SoHDKD(data.MaSo, thangtruoc, txtYear.Text); ;
                dr[3] = list[data.STT];
                dr[4] = list2[data.STT];
                if (data.MaSo == "10")
                {
                    list[3] = list[1] + list[2];
                    list2[3] = list2[1] + list2[2];
                    dr[3] = list[3];
                    dr[4] = list2[3];
                }
                if (data.MaSo == "20")
                {
                    list[5] = list[3] - list[4];
                    list2[5] = list2[3] - list2[4];
                    dr[3] = list[5];
                    dr[4] = list2[5];
                }
                if (data.MaSo == "30")//5+6-7-9-10
                {
                    list[11] = list[5] + list[6] - list[7] - list[9] - list[10];
                    list2[11] = list2[5] + list2[6] - list2[7] - list2[9] - list2[10];
                    dr[3] = list[11];
                    dr[4] = list2[11];

                }
                if (data.MaSo == "40")
                {
                    list[14] = list[12] - list[13];
                    list2[14] = list2[12] - list2[13];
                    dr[3] = list[14];
                    dr[4] = list2[14];
                }
                if (data.MaSo == "50")
                {//30+40
                    list[15] = list[11] + list[14];
                    list2[15] = list2[11] + list2[14];
                    dr[3] = list[15];
                    dr[4] = list2[15];
                }
                if (data.MaSo == "60")
                {
                    dr[3] = list[15] - list[16] - list[17];
                    dr[4] = list2[15] - list2[16] - list2[17];
                }
                dr[5] = soluyke_HDKD(data.MaSo,thangtruoc, txtMonth.Text, txtYear.Text);
                txtSQL.Text = thangtruoc;
                // update DB                  
                int days = DateTime.DaysInMonth(Int32.Parse(txtYear.Text), Int32.Parse(txtMonth.Text));
                DateTime ngaychungtu = new DateTime( Int32.Parse(txtYear.Text), Int32.Parse(txtMonth.Text), days);
                sql += "insert into Targets2 select newid(),'"+ data.MaSo + "'," + dr[3] + ",'" + ngaychungtu + "';";
                //insert into Targets2 select newid(),maso,sum(sotien) as sotien,@ngaychungtu from @candoi group by maso
                dt.Rows.Add(dr);
            }
            
            try
            {
                gen.ExcuteNonquery(sql); // insert table  Targets2
            }
            catch { txtSQL.Text = sql; }

            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;            
            view.OptionsView.ShowFooter = true;
            view.Columns["Lũy kế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lũy kế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lũy kế"].Width = 100;
            view.Columns["Chỉ tiêu"].Width = 1000;
            view.Columns["Mã số"].BestFit();
            view.Columns["Thuyết minh"].BestFit();
            view.Columns["Số cuối kỳ"].Width = 100;
            view.Columns["Số đầu kỳ"].Width = 100;
            view.Columns["Số đầu kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số đầu kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số cuối kỳ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số cuối kỳ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            

        }
        public decimal SoHDKD(string code, string month, string year) // so tien hdkd
        {
            
            decimal kq = 0;
            /*var ctx = gen.GetNewEntity();
            
            if (code == "01")
            {
                var quy1 = ctx.AccountSums
                          .Join(ctx.Accounts, a => a.CreditAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.PostDate })
                 .Where(c => c.AccountCategoryID == "511" && c.AccountNumber != "51112" && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            }
            else if (code == "02")
            {
                var quy1 = ctx.AccountSums
                          .Join(ctx.Accounts, a => a.DebitAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.PostDate, a.CreditAccount })
                 .Where(c => c.AccountCategoryID == "511" && ( c.CreditAccount == "521" || c.CreditAccount == "5211" || c.CreditAccount == "5212" || c.CreditAccount == "5213"
                 || c.CreditAccount == "531" || c.CreditAccount == "532" || c.CreditAccount == "3331" || c.CreditAccount == "3332" || c.CreditAccount == "3333" || c.CreditAccount == "131")
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            }

                else if (code == "11")
            {
                var quy1 = ctx.AccountSums
                 .Where(c => c.DebitAccount == "911" && c.CreditAccount == "632" && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;

                var quy2 = ctx.AccountSums
                 .Where(c => c.DebitAccount == "632" && c.CreditAccount == "157" && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy2 select x.Amount).Sum() != null) kq -= (from x in quy2 select x.Amount).Sum() ?? 0;
            }

            else if (code == "21")
            {
                var quy1 = ctx.AccountSums
                 .Where(c => c.DebitAccount == "515" && c.CreditAccount == "911" && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;                
            }
            else if (code == "22")
            {
                var quy1 = ctx.AccountSums
                 .Where(c => c.DebitAccount == "911" && ( c.CreditAccount == "635" || c.CreditAccount == "6351" || c.CreditAccount == "6352")
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
                var quy2 = ctx.AccountSums
                                 .Where(c => c.CreditAccount == "911" && (c.DebitAccount == "635" || c.DebitAccount == "6351" || c.DebitAccount == "6352")
                                 && c.PostDate.Value.Month.ToString() == month
                                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy2 select x.Amount).Sum() != null) kq -= (from x in quy2 select x.Amount).Sum() ?? 0;
            }
            
            else if (code == "23")
            {
                var quy1 = ctx.AccountSums
                 .Where(c => (c.CreditAccount == "635" || c.CreditAccount == "6351" || c.CreditAccount == "6352")
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;                
            }
            else if (code == "24")
            {
                var quy1 = ctx.AccountSums
                    .Join(ctx.Accounts, a => a.CreditAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.PostDate, a.DebitAccount })
                 .Where(c => c.AccountCategoryID == "641" && c.DebitAccount == "911" 
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
                var quy2 = ctx.AccountSums
                    .Join(ctx.Accounts, a => a.DebitAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.PostDate, a.CreditAccount })
                                 .Where(c => c.AccountCategoryID == "641" && c.CreditAccount == "911"
                                 && c.PostDate.Value.Month.ToString() == month
                                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy2 select x.Amount).Sum() != null) kq -= (from x in quy2 select x.Amount).Sum() ?? 0;
            }
            else if (code == "25")
            {
                var quy1 = ctx.AccountSums
                    .Join(ctx.Accounts, a => a.CreditAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.PostDate, a.DebitAccount })
                 .Where(c => c.AccountCategoryID == "642" && c.DebitAccount == "911"
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
                var quy2 = ctx.AccountSums
                    .Join(ctx.Accounts, a => a.DebitAccount, b => b.AccountNumber,
                 (a, b) => new { a.Amount, b.AccountCategoryID, b.AccountNumber, a.PostDate, a.CreditAccount })
                                 .Where(c => c.AccountCategoryID == "642" && c.CreditAccount == "911"
                                 && c.PostDate.Value.Month.ToString() == month
                                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy2 select x.Amount).Sum() != null) kq -= (from x in quy2 select x.Amount).Sum() ?? 0;
            }

            else if (code == "31")
            {
                var quy1 = ctx.AccountSums
                 .Where(c => (c.DebitAccount == "711" || c.DebitAccount == "71111" || c.DebitAccount == "71112" || c.DebitAccount == "71113" || c.DebitAccount == "71114")
                 && c.CreditAccount == "911"
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            }
            else if (code == "32")
            {
                var quy1 = ctx.AccountSums
                 .Where(c => c.CreditAccount == "811"
                 && c.DebitAccount == "911"
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            }

            else if (code == "51")
            {
                var quy1 = ctx.AccountSums
                 .Where(c => c.CreditAccount == "8211" && c.DebitAccount == "911"
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            }
            else if (code == "52")
            {
                var quy1 = ctx.AccountSums
                 .Where(c => c.CreditAccount == "8212" && c.DebitAccount == "911"
                 && c.PostDate.Value.Month.ToString() == month
                 && c.PostDate.Value.Year.ToString() == year);
                if ((from x in quy1 select x.Amount).Sum() != null) kq = (from x in quy1 select x.Amount).Sum() ?? 0;
            }
            */
            return kq;
        }

        public decimal soluyke_HDKD(string code, string thangtruoc, string thang, string year)
        {
            decimal kq = 0;
           /* var ctx = gen.GetNewEntity();
            int month1 = Int32.Parse(thangtruoc);
            int month2 = Int32.Parse(thang);

            var luyke = ctx.Targets2
         .Where(c => c.PostDate.Value.Month >= month1 && c.PostDate.Value.Month <= month2
         && c.PostDate.Value.Year.ToString() == year && c.Code == code);
            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;*/
            return kq;
        }
        public decimal soluyke_CDKT(string code, string thangtruoc, string thang, string year) // can doi ke toan
        {
            decimal kq = 0;
           /* var ctx = gen.GetNewEntity();
            int month1 = Int32.Parse(thangtruoc);
            int month2 = Int32.Parse(thang);

            var luyke = ctx.Targets
         .Where(c => c.PostDate.Value.Month >= month1 && c.PostDate.Value.Month < month2
         && c.PostDate.Value.Year.ToString() == year && c.Code == code);
            if ((from x in luyke select x.Amount).Sum() != null) kq = (from x in luyke select x.Amount).Sum() ?? 0;
            */
            return kq;
        }

        private void view_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try {
                if (e.RowHandle >= 0)
                {
                    if (Globals.transactioncode == "CNQH" && view.GetRowCellDisplayText(e.RowHandle, view.Columns[11]) != "0")
                    {
                        e.Appearance.BackColor = Color.Salmon;
                        e.Appearance.BackColor2 = Color.SeaShell;
                    }
                }

                    if (Globals.transactioncode == "CDKT")
                {
                    if (e.CellValue.ToString() == "110" || e.CellValue.ToString() == "120" || e.CellValue.ToString() == "130" || e.CellValue.ToString() == "140" || e.CellValue.ToString() == "150" ||
                    e.CellValue.ToString() == "210" || e.CellValue.ToString() == "220" || e.CellValue.ToString() == "230" || e.CellValue.ToString() == "240" || e.CellValue.ToString() == "250" ||
                    e.CellValue.ToString() == "260" || e.CellValue.ToString() == "310" || e.CellValue.ToString() == "330" || e.CellValue.ToString() == "410" || e.CellValue.ToString() == "430")
                    {
                        e.Appearance.BackColor2 = Color.LightSkyBlue;
                    }
                    if (e.CellValue.ToString() == "100" || e.CellValue.ToString() == "200" || e.CellValue.ToString() == "300" || e.CellValue.ToString() == "400"
                        || e.CellValue.ToString() == "440" || e.CellValue.ToString() == "270")
                    {
                        e.Appearance.BackColor = Color.NavajoWhite;

                    }
                }
                else if (Globals.transactioncode == "LCTT")
                {
                    if (e.CellValue.ToString() == "20" || e.CellValue.ToString() == "30" || e.CellValue.ToString() == "40" || e.CellValue.ToString() == "50" || e.CellValue.ToString() == "70")
                    {
                        e.Appearance.BackColor = Color.NavajoWhite;

                    }
                }
                
            } catch{ }
            


        }
    }
}
