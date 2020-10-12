using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;

namespace HAMACO.Resources
{
    public partial class rpbangketravotheoxe : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangketravotheoxe()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string soxe)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel7.Text = "SỐ XE: " + soxe.ToUpper();
            xrLabel3.Text = "NGÀY GIAO HÀNG: TỪ NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            DataSource = gen.GetTable("select b.AccountingObjectName as 'Khách hàng' from INOutward a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefDate>='" + tungay + "' and RefDate <='" + denngay + "' and CustomField6=N'" + soxe + "' order by AccountingObjectCode");
            xrTableCell65.DataBindings.Add("Text", DataSource, "Khách hàng");
        }
    }
}
