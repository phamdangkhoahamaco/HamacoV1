using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class unchdbank : DevExpress.XtraReports.UI.XtraReport
    {
        public unchdbank()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string role)
        {
            xrLabel3.Text = gen.GetString("select Top 1 CompanyName from Center");
            DataTable dt = gen.GetTable("select SUBSTRING(RefNo,7,15),RefDate, AccountingObjectBankAccount,AccountingObjectBankName,AccountingObjectName,Contactname,DocumentIncluded, TotalAmount, JournalMemo, Cancel from BAAccreditative where RefID='" + role + "'");
            xrLabel4.Text = String.Format("{0:       dd   MM   yyyy}", DateTime.Parse(dt.Rows[0][1].ToString()));
            xrLabel1.Text = dt.Rows[0][2].ToString();
            xrLabel2.Text = dt.Rows[0][3].ToString();
            xrLabel6.Text = dt.Rows[0][4].ToString();
            xrLabel5.Text = dt.Rows[0][5].ToString();

            try
            {
                string[] strS = dt.Rows[0][6].ToString().Split(',');
                xrLabel7.Text = strS[0].ToString().Trim();
                xrLabel12.Text = strS[1].ToString().Trim();
            }
            catch
            {
                xrLabel7.Text = dt.Rows[0][6].ToString().Replace(",", "");
            }

            //xrLabel7.Text = dt.Rows[0][6].ToString().Replace(",", "");
            xrLabel8.Text = String.Format("{0:n0}", Double.Parse(dt.Rows[0][7].ToString()));
            xrLabel9.Text = doi.ChuyenSo(Double.Parse(dt.Rows[0][7].ToString()).ToString());
            xrLabel9.Text = "                                            " + xrLabel9.Text.Substring(0, 1).ToUpper() + xrLabel9.Text.Substring(1, xrLabel9.Text.Length - 1);
            xrLabel11.Text = dt.Rows[0][8].ToString();
            if (dt.Rows[0][9].ToString() == "True")
                xrLabel1.Text = null;
        }
    }
}
