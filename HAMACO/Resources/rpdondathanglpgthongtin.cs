using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpdondathanglpgthongtin : DevExpress.XtraReports.UI.XtraReport
    {
        public rpdondathanglpgthongtin()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string role)
        {
            DataTable temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,b.Contactname,RefDate,RefNo,c.StockID,Tel,ShippingNo,FullName,TotalAmountOC,TotalAmount-TotalFreightAmount+TotalAmountOC,Tax,b.AccountingObjectName,CustomField6,a.Contactname  from INOutwardLPG a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
            xrLabel3.Text = "Hôm nay, ngày " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][4].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][4].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][4].ToString())) + ":";
            xrLabel11.Text = temp.Rows[0][1].ToString().ToUpper() + "(" + temp.Rows[0][0].ToString() + ")";
            xrLabel13.Text = temp.Rows[0][2].ToString().ToUpper();
            xrLabel24.Text = temp.Rows[0][7].ToString().ToUpper();
            xrLabel26.Text = temp.Rows[0][3].ToString().ToUpper();
            xrLabel31.Text = "Số tiền bằng chữ: " + doi.ChuyenSo(Double.Parse(temp.Rows[0][11].ToString()).ToString());
            xrLabel9.Text = "Số đơn hàng: " + temp.Rows[0][5].ToString().ToUpper();
            xrLabel7.Text = temp.Rows[0][8].ToString().ToUpper();
            xrLabel15.Text = temp.Rows[0][15].ToString().ToUpper();

            
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("ĐVT", Type.GetType("System.String"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("STT", Type.GetType("System.String"));

            temp = gen.GetTable("bangkedondathanglpg '" + role + "',N'chung'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3];
                dr[4] = temp.Rows[i][4];
                dr[5] = temp.Rows[i][5];
                dr[6] = i + 1;
                dt.Rows.Add(dr);
            }

            DataSource = dt;

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell13.Summary = summarytotal2;


            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell11.Summary = summarytotal3;

            xrTableCell1.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell3.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            
        }
    }
}
