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

namespace HAMACO
{
    public partial class Frm_report : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dtsum = new DataTable();
        DataTable temp = new DataTable(); // data chinh
        DataTable temp2 = new DataTable(); // header
        DataTable temp3 = new DataTable(); // 
        int clientid = Globals.clientid;
        string username = Globals.username;
        string SQLString = "";
        string title;
        public Frm_report()
        {
            InitializeComponent();
        }
        public string gettitle(string a)
        {
            title = a;
            return title;
        }

        public DataTable getdata(DataTable a)
        {
            temp = a;
            return temp;
        }
        public DataTable getdata2(DataTable a)
        {
            temp2 = a;
            return temp2;
        }
        public DataTable getdata3(DataTable a)
        {
            temp3 = a;
            return temp3;
        }

        public DataTable getdatasum(DataTable a)
        {
            dtsum = a;
            return dtsum;
        }

        private void Frm_report_Load(object sender, EventArgs e)
        {
            if(title== "Báo cáo tồn kho hàng hóa theo số lượng") get_report_BCTK();
            this.Text = title;
        }

        private void get_report_BCTK() // bao cao ton kho
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("InventoryItemCode", Type.GetType("System.String")); //0
            dt.Columns.Add("TenHH", Type.GetType("System.String")); //1
            dt.Columns.Add("StockCode", Type.GetType("System.String")); //2
            dt.Columns.Add("QuantityDK", Type.GetType("System.Double"));
            dt.Columns.Add("AmountDK", Type.GetType("System.Double"));
            dt.Columns.Add("QuantityNTK", Type.GetType("System.Double"));
            dt.Columns.Add("AmountNTK", Type.GetType("System.Double"));
            dt.Columns.Add("QuantityXTK", Type.GetType("System.Double"));
            dt.Columns.Add("AmountXTK", Type.GetType("System.Double"));
            dt.Columns.Add("QuantityCK", Type.GetType("System.Double"));
            dt.Columns.Add("AmountCK", Type.GetType("System.Double"));




            //temp = gen.GetTable("SELECT * from UserSalary where clientid = " + clientid + " AND CompanyCode = '" + Globals.companycode + "'");
            //temp = dt; // get data 

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i].Field<string>("InventoryItemCode");
                dr[1] = "";
                dr[2] = temp.Rows[i].Field<string>("StockCode");
                dr[3] = temp.Rows[i].Field<int>("QuantityDK").ToString();
                dr[4] = temp.Rows[i].Field<int>("AmountDK").ToString();
                dr[5] = temp.Rows[i].Field<int>("QuantityNTK").ToString();
                dr[6] = temp.Rows[i].Field<int>("QuantityNTK").ToString();
                dr[7] = temp.Rows[i].Field<int>("AmountNTK").ToString();
                dr[8] = temp.Rows[i].Field<int>("AmountXTK").ToString();
                dr[9] = temp.Rows[i].Field<int>("QuantityCK").ToString();
                dr[10] = temp.Rows[i].Field<int>("AmountCK").ToString();
                dt.Rows.Add(dr);
            }
            
            rpbaocaotonkho rpbaocaotonkho = new rpbaocaotonkho();
            string thang = String.Format("{0:MM}", DateTime.Parse(Globals.ngaychungtu));
            string nam = DateTime.Parse(Globals.ngaychungtu).Year.ToString();
            string stockcode = temp2.Rows[0][0].ToString();
            string khoid = gen.GetString2("Stock", "StockID", "StockCode", stockcode, clientid);

            rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THÁNG " + thang + " NĂM " + nam, khoid , Globals.userid, Globals.ngaychungtu, "tsbtbctktsl", "");
            rpbaocaotonkho.BindData(dt);
            printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
            rpbaocaotonkho.CreateDocument();
        }
    }
}