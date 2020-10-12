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
    public partial class rpphieudathangvinagiaygioithieu : DevExpress.XtraReports.UI.XtraReport
    {
        public rpphieudathangvinagiaygioithieu()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string phieu, string tsbt)
        {
            DataTable temp = new DataTable();

            temp = gen.GetTable("select RefNo,b.AccountingObjectName,b.Address,Tel,Fax,a.Contactname,RefDate,ShippingNo,Cancel,a.StockID, CustomField6, CustomField3,DocumentIncluded from DDHNCC a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + phieu + "'");
            xrLabel12.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel13.Text = "Giấy giới thiệu có giá trị đến hết ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(temp.Rows[0][6].ToString()));
            xrLabel14.Text = temp.Rows[0][7].ToString();
            xrLabel7.Text = temp.Rows[0][10].ToString();
            xrLabel10.Text = temp.Rows[0][11].ToString();
            xrLabel5.Text = "Đến kho thép VINAKYOEI nhận thép theo đơn hàng " + temp.Rows[0][0].ToString() + " như sau:";
            xrLabel15.Text = "Cần Thơ, ngày " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][6].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][6].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][6].ToString()));
        }
        public void BindData(string phieu, string tsbt)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Loại hàng", Type.GetType("System.String"));
            dt.Columns.Add("Mác thép", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.String"));


            DataTable temp = gen.GetTable("select SaleDescription,PurchaseDescription, QuantityConvert/1000.0,a.ConvertRate from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString() + " bó";
                dt.Rows.Add(dr);
            }

            DataSource = dt;
           
            xrTableCell1.DataBindings.Add("Text", DataSource, "Loại hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Mác thép");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n2}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Trọng lượng");
        }
    }
}
