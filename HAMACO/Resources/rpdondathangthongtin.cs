using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpdondathangthongtin : DevExpress.XtraReports.UI.XtraReport
    {
        public rpdondathangthongtin()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string MMDoc)
        {
            //DataTable temp = gen.GetTable("select 0 c.StockCode,c.StockName,2 c.Description,3 FullName,4 RefDate,RefNo,c.StockID,7 c.Note,ShippingNo,FullName,TotalAmountOC,TotalAmount-TotalFreightAmount+TotalAmountOC,Tax,b.AccountingObjectName,a.Contactname ,a.AccountingObjectName,a.AccountingObjectCode  from DDH a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.InStockID=c.StockID and a.RefID='" + role + "'");            
            String MySQL = "select StockCode2,StockName, c.Description,d.FullName, a.RefDate,RefNo, a.TotalAmount, a.AccountingObjectName, a.AccountingObjectCode,AccountingObjectAddress,Dienthoai,";
            MySQL += "Taixe,a.ContactName from [MMDocument] a, Stock c,MSC_User d";
            MySQL += "  where a.StockCode2 = c.StockCode and a.UserName = d.UserName and MMDoc = '" + MMDoc + "'";
            DataTable temp = gen.GetTable(MySQL);
            DataRow[] dr2 = temp.Select(); // lay dong dau tien
            foreach (DataRow row in dr2)
            {
                //xrLabel3.Text = "Hôm nay, ngày " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][4].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][4].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][4].ToString())) + ":";
                xrLabel3.Text = "Hôm nay, ngày " + String.Format("{0:dd}", DateTime.Parse(row["RefDate"].ToString()));
                xrLabel3.Text += " tháng " + String.Format("{0:MM}", DateTime.Parse(row["RefDate"].ToString()));
                xrLabel3.Text += " năm " + String.Format("{0:yyyy}", DateTime.Parse(row["RefDate"].ToString())) + ":";
                xrLabel11.Text = row["StockName"].ToString().ToUpper() + " (" + row["StockCode2"].ToString() + ")";
                xrLabel24.Text = row["Dienthoai"].ToString().ToUpper(); // dien thoai 
                xrLabel13.Text = row["AccountingObjectAddress"].ToString().ToUpper(); // dia chi AccountingObjectAddress
                xrLabel35.Text = xrLabel26.Text = row["FullName"].ToString().ToUpper(); // dai dien + ky ten nhan vien ban hang
                xrLabel9.Text = "Số đơn hàng: " + row["RefNo"].ToString().ToUpper();
                xrLabel7.Text = row["Taixe"].ToString().ToUpper(); // phuong tien van chuyen hay ShippingNo???
                //xrLabel15.Text = row["RefNo"].ToString().ToUpper();
                xrLabel15.Text = MMDoc;
                xrLabel8.Text = row["AccountingObjectName"].ToString().ToUpper() + " (" + row["AccountingObjectCode"].ToString() + ")"; // ten khach hang
            }
            

            
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("ĐVT", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));            
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));
            dt.Columns.Add("STT", Type.GetType("System.String"));

            //temp = gen.GetTable("select b.InventoryItemName,Quantity,b.Unit,QuantityConvert from DDHDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "'");
            temp = gen.GetTable("select InventoryItemName,Unit,Quantity,QuantityConvert from MMDocumentDetail WHERE MMDoc = '" + MMDoc + "'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                dr[4] = "";
                dr[5] = i + 1;
                dt.Rows.Add(dr);
            }

            DataSource = dt;
            

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            
            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}"); // trọng lượng
            xrTableCell12.Summary = summarytotal2;
            

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell11.Summary = summarytotal3;

            xrTableCell1.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell3.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
        }
    }
}
