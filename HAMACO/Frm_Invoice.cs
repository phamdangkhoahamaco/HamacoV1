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
using System.Data.SqlClient;


namespace HAMACO
{
    public partial class Frm_Invoice : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Invoice()
        {
            InitializeComponent();
            //default
            deTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            deDenNgay.DateTime = DateTime.Now;
        }

        public static SqlConnection conn()
        {
            SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"server=.\SQLEXPRESS;database=Inventory;uid=sa;pwd=123;";
            con.ConnectionString = @"server=SQL2016A.HAMACO.VN,65102;database=Hamacov3;uid=PhamDangKhoa;pwd=Khoa123456;";
            return con;
        }
        private void load1_Click(object sender, EventArgs e) // tai du lieu
        {
            String SQLString = "SELECT a.MMDoc, a.RefDate, TotalAmount, a.AccountingObjectName, " +
                "c.CompanyTaxCode, a.AccountingObjectAddress, c.ContactMobile, c.ContactEmail, c.BankAccount, " +
                "c.BankName, 'TM/CK' as PayNo, 'VND' AS Tiente, 0, a.MMHeader FROM MMDocument a LEFT JOIN AccountingObject c " +
                "on a.AccountingObjectCode = c.AccountingObjectCode " +
                "WHERE RefType=31 AND RefDate >= '" + deTuNgay.DateTime.Date + "' AND RefDate <= '" + deDenNgay.DateTime.Date + "' order by MMDoc";
            DataTable dtData = p._SQLTraveDatatable(SQLString, conn());
            grid1.DataSource = dtData;
            view1.RefreshData();

        }

        private void export2_Click(object sender, EventArgs e) // xuat excel
        {
            p.export_Excel("Hóa đơn Hamaco", view1);
        }

        private void CreateInvoice_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {

                DataRow fRow = view1.GetFocusedDataRow(); // lay du lieu nguyen 1 dong
                if (fRow != null)
                {
                   Frm_ProductOrder f = new Frm_ProductOrder();
                    f.getMMDoc(fRow["MMDoc"].ToString());
                    f.getactive("1");
                   f.ShowDialog();
                }
            }
        }
    }
}