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
    public partial class rpphieudathangvinaduongbo : DevExpress.XtraReports.UI.XtraReport
    {
        public rpphieudathangvinaduongbo()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string phieu, string tsbt)
        {
            DataTable temp = new DataTable();

            temp = gen.GetTable("select RefNo,b.AccountingObjectName,b.Address,Tel,Fax,a.Contactname,RefDate,ShippingNo,Cancel,a.StockID, CustomField6, CustomField3,DocumentIncluded from DDHNCC a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + phieu + "'");
            xrTableCell79.Text = xrLabel17.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel14.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(temp.Rows[0][6].ToString()));
            xrLabel9.Text = temp.Rows[0][0].ToString();
            xrLabel11.Text = temp.Rows[0][4].ToString();
            xrLabel7.Text = temp.Rows[0][7].ToString();
            xrLabel10.Text = temp.Rows[0][12].ToString();
            xrLabel11.Text = temp.Rows[0][10].ToString();
            xrLabel6.Text = temp.Rows[0][11].ToString();
            xrLabel5.Text = "GIẤY GIỚI THIỆU: Có giá trị đến hết ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(temp.Rows[0][6].ToString()));
        }

        public void BindData(string phieu, string tsbt)
        {
            DataTable temp = gen.GetTable("select SaleDescription,QuantityConvert/1000.0,a.ConvertRate,PurchaseDescription from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (temp.Rows[i][0].ToString() == "06")
                    xrTableCell7.Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][1].ToString()));
                else if (temp.Rows[i][0].ToString() == "08")
                    xrTableCell11.Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][1].ToString()));
                else if (temp.Rows[i][0].ToString() == "D10")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell15.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell60.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D12")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell21.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell61.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D14")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell23.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell62.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D16")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell25.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell63.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D18")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell26.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell64.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D20")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell27.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell65.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D22")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell28.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell66.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D25")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell31.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell67.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D28")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell32.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell68.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "D32")
                {
                    if (temp.Rows[i][3].ToString() == "CB300 V")
                        xrTableCell33.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    else if (temp.Rows[i][3].ToString() == "CB400 V")
                        xrTableCell69.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                }
                else if (temp.Rows[i][0].ToString() == "P14")
                    xrTableCell34.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                else if (temp.Rows[i][0].ToString() == "P16")
                    xrTableCell35.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                else if (temp.Rows[i][0].ToString() == "P18")
                    xrTableCell36.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                else if (temp.Rows[i][0].ToString() == "P20")
                    xrTableCell37.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                else if (temp.Rows[i][0].ToString() == "P22")
                    xrTableCell38.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                else if (temp.Rows[i][0].ToString() == "P25")
                    xrTableCell39.Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
            }
        }
    }
}
