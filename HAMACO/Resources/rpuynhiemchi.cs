using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpuynhiemchi : DevExpress.XtraReports.UI.XtraReport
    {
        public rpuynhiemchi()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string role)
        {
            xrLabel14.Text = gen.GetString("select Top 1 CompanyName from Center").ToUpper();
            DataTable dt = gen.GetTable("select SUBSTRING(RefNo,7,15),RefDate, AccountingObjectBankAccount,AccountingObjectBankName,AccountingObjectName,Contactname,DocumentIncluded, TotalAmount, JournalMemo, Cancel from BAAccreditative where RefID='" + role + "'");
            xrLabel3.Text="Số: "+dt.Rows[0][0].ToString();
            xrLabel4.Text = "Ngày: " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dt.Rows[0][1].ToString()));
            xrLabel15.Text = dt.Rows[0][2].ToString();
            xrLabel16.Text = dt.Rows[0][3].ToString();
            xrLabel19.Text = dt.Rows[0][4].ToString().ToUpper();
            xrLabel20.Text = dt.Rows[0][5].ToString();
            xrLabel22.Text = dt.Rows[0][6].ToString();
            xrLabel10.Text = String.Format("{0:n0}", Double.Parse(dt.Rows[0][7].ToString()));
            xrLabel24.Text = doi.ChuyenSo(Double.Parse(dt.Rows[0][7].ToString()).ToString());
            xrLabel24.Text = xrLabel24.Text.Substring(0, 1).ToUpper() + xrLabel24.Text.Substring(1, xrLabel24.Text.Length-1);
            xrLabel26.Text = dt.Rows[0][8].ToString();
            if (dt.Rows[0][9].ToString() == "True")
                xrLabel15.Text = null;
        }
    }
}
