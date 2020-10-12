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
    public partial class rpphieudathang : DevExpress.XtraReports.UI.XtraReport
    {
        public rpphieudathang()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string phieu, string tsbt)
        {
            DataTable temp = new DataTable();

            xrLabel1.Text = xrTableCell61.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel4.Text = "Điện thoại: " + gen.GetString("select Top 1 Phone from Center");
            xrLabel6.Text = gen.GetString("select Top 1 Address from Center");

            if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1800506679")
                xrPictureBox2.Visible = true;

            if (tsbt == "pxhtphieu")
              temp=  gen.GetTable("select RefNo,b.AccountingObjectName,b.Address,Tel,Fax,JournalMemo,RefDate from OUTdeficit a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + phieu + "'");
            else if (tsbt == "tsbthdmhkpnphieu")
                temp = gen.GetTable("select a.RefNo,b.AccountingObjectName,b.Address,Tel,Fax,PUJournalMemo,PURefDate,ShippingNo from PUInvoice a, AccountingObject b, INInward c where a.ShippingMethodID=c.RefID and a.AccountingObjectID=b.AccountingObjectID and a.RefID='" + phieu + "'");
            else if (tsbt == "tsbthdbhkpnphieu")
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,b.Address,Tel,Fax,PUJournalMemo,PURefDate from SSInvoice a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + phieu + "'");
            else if (tsbt == "tsbtpnkttphieu")
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,b.Address,Tel,Fax,JournalMemo,RefDate,ShippingNo from INInwardTT a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + phieu + "'");
            else if (tsbt == "tsbtddhphieu" || tsbt == "tsbtddhphieusl")
            {
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,b.Address,Tel,Fax,a.Contactname,RefDate,ShippingNo,Cancel,a.StockID, CustomField6, CustomField3,DocumentIncluded,a.CustomField1 from DDHNCC a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + phieu + "'");
                xrLabel25.Text = "- Hình thức thanh toán: ";
                if (temp.Rows[0][8].ToString() == "True")
                    xrLabel25.Text = xrLabel25.Text + "Thanh toán ngay";
                else
                    xrLabel25.Text = xrLabel25.Text + "Trả chậm";
                xrLabel22.Text = temp.Rows[0][10].ToString();
                xrLabel23.Text = temp.Rows[0][11].ToString();
                xrLabel29.Text ="- Yêu cầu khác: "+ temp.Rows[0][12].ToString();
            }
            xrLabel9.Text = temp.Rows[0][0].ToString();
            xrLabel17.Text = xrTableCell58.Text = temp.Rows[0][1].ToString().ToUpper();
            xrLabel14.Text = temp.Rows[0][2].ToString();
            xrLabel20.Text = temp.Rows[0][3].ToString();
            
            try
            {
                xrLabel21.Text = temp.Rows[0][7].ToString();
            }
            catch { }

            xrLabel11.Text = temp.Rows[0][4].ToString();
            
            /*
            string[] strS = temp.Rows[0][5].ToString().Split('-');
            xrLabel15.Text = strS[0].ToString().Trim();
            try
            {
                xrLabel32.Text = strS[1].ToString().Trim();
            }
            catch { }
             */

            xrLabel15.Text = temp.Rows[0][13].ToString();
            xrLabel32.Text = temp.Rows[0][5].ToString();

            xrLabel34.Text = "- Yêu cầu thời gian giao hàng: từ ngày " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][6].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][6].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][6].ToString()));
            xrLabel3.Text = "Cần Thơ, ngày  " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][6].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][6].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][6].ToString()));
            temp = gen.GetTable("select top 1 ContractCode,SignedDate  from OUTdeficit a, ContractB b  where a.AccountingObjectID=b.AccountingObjectID and ContractName=N'Mua hàng' and SignedDate<=RefDate and EffectiveDate>=RefDate and b.No=0 and RefID='" + phieu + "' order by b.SignedDate");
            try { xrLabel13.Text = "Căn cứ theo hợp đồng số " + temp.Rows[0][0].ToString() + " ký ngày " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][1].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][1].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][1].ToString()));}
            catch { }
        }

        public void BindData(string phieu, string tsbt, string kho)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("ĐVT", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("STT", Type.GetType("System.Double"));

            DataTable temp = new DataTable();
            if (tsbt == "pxhtphieu")
                temp = gen.GetTable("select InventoryItemName, case when Quantity=0 then ConvertUnit else Unit end, Quantity,QuantityConvert, Amount/QuantityConvert from OUTdeficitDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            else if (tsbt == "tsbthdmhkpnphieu")
                temp = gen.GetTable("select InventoryItemName, case when Quantity=0 then ConvertUnit else b.Unit end, Quantity,QuantityConvert,Amount/QuantityConvert from PUInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            else if (tsbt == "tsbtddhphieu")
            {
                if (kho == "0")
                    temp = gen.GetTable("select InventoryItemName, case when Quantity=0 then ConvertUnit else b.Unit end, Quantity,QuantityConvert,Amount/QuantityConvert from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
                else if (kho == "1")
                    temp = gen.GetTable("select InventoryItemName, ConvertUnit, Quantity,QuantityConvert,Amount/QuantityConvert from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
                else if (kho == "2")
                {
                    temp = gen.GetTable("select InventoryItemName,'',case when Quantity=0 then QuantityConvert else 0 end,a.ConvertRate,0 from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
                    xrTableCell7.Text = "Trọng lượng";
                    xrTableCell16.Text = "Số Bó (Cuộn)";  
                }                              
            }
            else if (tsbt == "tsbtddhphieusl")
                temp = gen.GetTable("select InventoryItemName, case when Quantity=0 then ConvertUnit else b.Unit end, Quantity,QuantityConvert,Amount/QuantityConvert from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            else if (tsbt == "tsbthdbhkpnphieu")
                temp = gen.GetTable("select InventoryItemName, case when Quantity=0 then ConvertUnit else b.Unit end, Quantity,QuantityConvert,Amount/QuantityConvert from SSInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            else if (tsbt == "tsbtpnkttphieu")
                temp = gen.GetTable("select InventoryItemName, case when Quantity=0 then ConvertUnit else b.Unit end, Quantity,QuantityConvert,0 from INInwardDetailTT a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
                       
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4];
                dr[5] = i + 1;
                dt.Rows.Add(dr);
            }

            DataSource = dt;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n2}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell18.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;

            xrTableCell1.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell3.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            //xrTableCell5.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
        }
    }
}
