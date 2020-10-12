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
    public partial class rpbienbangiaonhanlpgle : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbienbangiaonhanlpgle()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(String phieu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            DataTable temp = gen.GetTable("select StockCode+'-'+StockName,a.AccountingObjectName+'('+AccountingObjectCode+')',a.AccountingObjectAddress,DocumentIncluded,TotalAmount+TotalAmountOC,RefDate,CustomField8,RefNo from INOutwardLPG a, AccountingObject b, Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + phieu + "'");
            xrLabel6.Text = temp.Rows[0][0].ToString();
            xrLabel11.Text = temp.Rows[0][1].ToString().ToUpper();
            xrLabel13.Text = temp.Rows[0][2].ToString().ToUpper();
            xrLabel7.Text = temp.Rows[0][3].ToString();
            xrLabel9.Text = "Số: " + temp.Rows[0][7].ToString();
            xrLabel5.Text = temp.Rows[0][6].ToString();
            xrLabel21.Text = doi.ChuyenSo(Double.Parse(temp.Rows[0][4].ToString()).ToString());
            xrLabel3.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][5].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][5].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][5].ToString()));
        }

        public void BindData(string phieu)
        {
            DataTable da = new DataTable();
            da.Columns.Add("Mã hàng", Type.GetType("System.String"));
            da.Columns.Add("Tên hàng", Type.GetType("System.String"));
            da.Columns.Add("ĐVT", Type.GetType("System.String"));
            da.Columns.Add("Số lượng", Type.GetType("System.Double"));
            da.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            da.Columns.Add("STT", Type.GetType("System.String"));
            int stt = 0;
            DataTable temp = gen.GetTable("select InventoryItemCode,InventoryItemName,b.Unit,Case when Quantity=0 then QuantityConvert else Quantity end ,Case when Quantity=0 then AmountOC/QuantityConvert else AmountOC/Quantity end,AmountOC from INOutwardLPGDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by SortOrder");
            stt = temp.Rows.Count;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                    DataRow dr = da.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = temp.Rows[i][3].ToString();
                    dr[4] = temp.Rows[i][4].ToString();
                    dr[5] = temp.Rows[i][5].ToString();
                    dr[6] = i + 1;
                    da.Rows.Add(dr);
            }
            temp = gen.GetTable("select Description,CustomField1,Quantity from INOutwardLPGQTDetail where RefID='" + phieu + "' order by SortOrder");
            if (stt == 0)
            {
                stt = 1;
                xrLabel2.Text = "PHIẾU SỬA CHỮA";
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = da.NewRow();
                dr[1] = temp.Rows[i][0].ToString();
                dr[2] = temp.Rows[i][1].ToString();
                dr[3] = temp.Rows[i][2].ToString();
                dr[6] = stt = stt + i;
                da.Rows.Add(dr);
            }
            for (int i=stt; i < 8; i++)
            {
                DataRow dr = da.NewRow();
                da.Rows.Add(dr);
            }
            
            DataSource = da;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell13.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;

            xrTableCell1.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell10.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell3.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n0}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        }
    }
}
