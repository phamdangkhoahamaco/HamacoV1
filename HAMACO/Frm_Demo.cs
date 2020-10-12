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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
//https://www.youtube.com/watch?v=5jjKGiminpk
//cach dung GridControl and LookupEdit (Devexpress)
namespace HAMACO
{
    public partial class Frm_Demo : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        dondathangncc ddhncc = new dondathangncc();
        DataTable dt = new DataTable();
        int clientid = Globals.clientid;
        private decimal qty = 0;
        private decimal amount = 0;
        private decimal vat = 0;
        private decimal price = 0;
        string SQLString = "";

        public Frm_Demo()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                //MessageBox.Show("ButtonEdit Validated!");

                //lblUsername.Text = gen.GetString2("Users", "FullName", "UserName", txtUser.Text, clientid);
                return true;
            }

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Frm_Demo2_Load(object sender, EventArgs e)
        {           
            load_item();
            // Load dữ liệu cho gridcontrol
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var dt = ctx.MMDocumentDetails.ToList();
            gridControl1.DataSource = new BindingList<MMDocumentDetail>(dt);
        }

        private void load_item()
        {
            var ctx = gen.GetNewEntity(); // khai bao new entity Framework
            var dt = ctx.InventoryItems.ToList();
            rep_mahang.DataSource = dt;

            rep_mahang.ValueMember = "InventoryItemCode";
            rep_mahang.DisplayMember = "InventoryItemCode";

            rep_mahang.NullText = @"Chọn vật tư";
            CotInventoryItemCode.ColumnEdit = rep_mahang;
        }

        private void load_txtDocType()
        {
            txtDocType.Properties.View.Columns.Clear();

            DataTable temp = new DataTable();
            temp.Columns.Add("Type");
            temp.Columns.Add("Type Name");

            var db = gen.GetNewEntity(); // khai bao new entity Framework            
            var query = db.Transactions
                .Where(p => p.FormName == "Frm_BaoCao" && p.TransactionCode != "BC00");
            foreach (var data in query)
            {
                DataRow dr = temp.NewRow();
                dr[0] = data.TransactionCode;
                dr[1] = data.TransactionName;
                temp.Rows.Add(dr);
            }


            txtDocType.Properties.DataSource = temp;
            txtDocType.Properties.DisplayMember = "Type";
            txtDocType.Properties.ValueMember = "Type";
            txtDocType.Focus();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var db = gen.GetNewEntity(); // khai bao new entity Framework       
            if (e.Column.FieldName== "InventoryItemCode")
            {
                var value = gridView1.GetRowCellValue(e.RowHandle, e.Column);
                var dt = db.InventoryItems.FirstOrDefault(x => x.InventoryItemCode == (string)value && x.CompanyCode == Globals.companycode);
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "InventoryItemName", dt.InventoryItemName);
                    //gridView1.SetFocusedRowCellValue(CotInventoryItemName, dt.InventoryItemName);
                    gridView1.SetRowCellValue(e.RowHandle, "Unit", dt.Unit);
                    gridView1.SetRowCellValue(e.RowHandle, "ConvertUnit", dt.ConvertUnit);
                    gridView1.SetRowCellValue(e.RowHandle, "UnitPrice", dt.UnitPrice);
                    if (gridView1.GetFocusedRowCellValue(CotQuantity)== "")
                    {
                        qty = 0;
                    }
                    else
                    {
                        qty = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(CotQuantity));
                        price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(CotUnitPrice));
                        amount = qty * price;
                        gridView1.SetFocusedRowCellValue(CotAmount, amount);                        
                    }
                }
            }
            if (e.Column == CotQuantity)
            {
                qty = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(CotQuantity));
                price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(CotUnitPrice));
                amount = qty * price;
                gridView1.SetFocusedRowCellValue(CotAmount, amount);                
            }
           
        }
    }
}