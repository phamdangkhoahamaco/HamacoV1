using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
namespace HAMACO.Resources
{
    public partial class uncvietcombank : DevExpress.XtraReports.UI.XtraReport
    {
        
        public uncvietcombank()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string role)
        {
            xrLabel3.Text = gen.GetString("select Top 1 CompanyName from Center");
            DataTable dt = gen.GetTable("select SUBSTRING(RefNo,7,15),RefDate, AccountingObjectBankAccount,AccountingObjectBankName,Case when (b.ContactName is not null and b.ContactName <>'') then b.Contactname else a.AccountingObjectName end as tendung,a.Contactname,DocumentIncluded, TotalAmount, JournalMemo, Cancel from BAAccreditative a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
            xrLabel4.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dt.Rows[0][1].ToString()));
            xrLabel1.Text = dt.Rows[0][2].ToString();
            xrLabel2.Text = dt.Rows[0][3].ToString();
            xrLabel6.Text = dt.Rows[0][4].ToString();
            xrLabel5.Text = dt.Rows[0][5].ToString();
            xrLabel7.Text = dt.Rows[0][6].ToString();
            xrLabel8.Text = String.Format("{0:n0}", Double.Parse(dt.Rows[0][7].ToString()));
            xrLabel9.Text = doi.ChuyenSo(Double.Parse(dt.Rows[0][7].ToString()).ToString());
            xrLabel9.Text = "                        " + xrLabel9.Text.Substring(0, 1).ToUpper() + xrLabel9.Text.Substring(1, xrLabel9.Text.Length - 1);
            xrLabel11.Text = "                                         " + dt.Rows[0][8].ToString();
            if (dt.Rows[0][9].ToString() == "True")
                xrLabel1.Text = null;
        }
    }
}
