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
    public partial class rpbangkechiphi : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkechiphi()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string tsbt, string tungay, string denngay, string makhach)
        {
            xrLabel7.Text = "Căn cứ theo hợp đồng thuê kho, quản lý, bốc xếp số: ";
            DataTable temp = gen.GetTable("select top 1 ContractCode,SignedDate,a.AccountingObjectName  from AccountingObject a, ContractB b  where a.AccountingObjectID=b.AccountingObjectID and a.AccountingObjectID='" + makhach + "' and ContractName=N'Cho thuê kho' and SignedDate<='" + denngay + "' and EffectiveDate>='" + denngay + "' and b.No=0 order by b.SignedDate");
            try
            {
                xrLabel7.Text = xrLabel7.Text + temp.Rows[0][0].ToString() + " ký ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(temp.Rows[0][1].ToString()));
                xrLabel7.Text = xrLabel7.Text + " giữa " + temp.Rows[0][2].ToString() + " và Công ty Cổ phần Vật tư Hậu Giang";
                xrTableCell58.Text = temp.Rows[0][2].ToString().ToUpper();
                xrLabel5.Text = "Chúng tôi đề nghị " + temp.Rows[0][2].ToString() + " ký xác nhận và thanh toán cho Công ty chúng tôi theo hợp đồng.";
            }
            catch { }
            xrLabel8.Text = "- Căn cứ vào tình hình hàng hóa xuất kho từ ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
            xrLabel13.Text = "Cần Thơ, ngày " + String.Format("{0:dd}", DateTime.Parse(denngay)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
        }

        public void BindData(string tungay, string denngay, string userid, string makhach)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("ĐVT", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("STT", Type.GetType("System.Double"));
            //DataTable temp = gen.GetTable("select InventoryItemName,b.ConvertUnit,Sum(QuantityConvert),Avg(DiscountRate),Round(Round(Sum(QuantityConvert),0)*Avg(DiscountRate),0) from SSInvoiceINOutward a, InventoryItem b, SSInvoice c  where c.AccountingObjectID='09FCFA3B-7B4C-4616-B813-7D3DB106A588' and a.SSInvoiceID=c.RefID and a.InventoryItemID=b.InventoryItemID and c.PURefDate>='" + tungay + "' and PURefDate<='" + denngay + "' and DiscountRate<>0 group by InventoryItemName,b.ConvertUnit  order by InventoryItemName");
            DataTable temp = gen.GetTable("select InventoryItemName,b.ConvertUnit,Sum(QuantityConvert),Avg(UnitPriceOC),sum(UnitPriceConvert) from INInwardDetail a, InventoryItem b, INInward c  where c.AccountingObjectID='"+makhach+"' and a.RefID=c.RefID and a.InventoryItemID=b.InventoryItemID and c.RefDate>='" + tungay + "' and RefDate<='" + denngay + "' and UnitPriceConvert<>0 and AccountingObjectType='2' and c.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') group by InventoryItemName,b.ConvertUnit  order by InventoryItemName");
            Double tong = 0;
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
                {
                    dr[4] = temp.Rows[i][4];
                    tong = tong + Double.Parse(temp.Rows[i][4].ToString());
                }
                dr[5] = i + 1;
                dt.Rows.Add(dr);
            }

            xrLabel10.Text = string.Format("{0:n0}", tong)+" đồng";
            xrLabel11.Text = string.Format("{0:n0}", Math.Round(tong/10,0)) + " đồng";
            xrLabel12.Text = string.Format("{0:n0}", tong+Math.Round(tong / 10, 0)) + " đồng";
            tong = tong + Math.Round(tong / 10, 0);
            xrLabel35.Text = "Bằng chữ: " + doi.ChuyenSo(tong.ToString());
            DataSource = dt;
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
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell5.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
        }
    }
}
