using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbienbanxacnhannochitiet : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbienbanxacnhannochitiet()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string ngaychungtu, string denngay, string makhach, string sotien, string tienchu, string kho, string dauky)
        {
            xrLabel1.Text = xrLabel25.Text = xrLabel34.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel6.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel4.Text = "Điện thoại: " + gen.GetString("select Top 1 Phone from Center");

            DataTable temp = gen.GetTable("select AccountingObjectName,AccountingObjectCode,Address,AccountingObjectID from AccountingObject where AccountingObjectCode='" + makhach + "'");
            xrLabel11.Text = "Khách hàng: "+temp.Rows[0][0].ToString().ToUpper() + " (" + temp.Rows[0][1].ToString() + ")";
            string tenkhach = temp.Rows[0][0].ToString().ToUpper();
            xrLabel13.Text = "Địa chỉ: "+temp.Rows[0][2].ToString();
            makhach = temp.Rows[0][3].ToString();

            string hopdong = null, ngayky = null;

            xrLabel5.Text = "- Hôm nay, ngày " + String.Format("{0:dd}", DateTime.Parse(denngay)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay)) + ". Chúng tôi xác nhận công nợ từ ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + " đến " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));

            xrLabel24.Text = xrLabel1.Text + " đề nghị quý khách hàng đối chiếu, xác nhận số dư nợ trên và thanh toán số tiền đến hạn (lãi quá hạn đính kèm bảng kê nếu có) nói trên. Đồng thời gửi lại cho Công ty Chúng tôi theo địa chỉ: ";

            temp = gen.GetTable("select Top 1 a.ParentContract,a.SignedDate from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where AccountingObjectID='" + makhach + "' and SignedDate<='" + denngay + "'and EffectiveDate>='" + denngay + "' group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
            try
            {
                hopdong = " theo hợp đồng số " + temp.Rows[0][0].ToString();
                ngayky = ", ký ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(temp.Rows[0][1].ToString()));
            }
            catch
            {
                hopdong = null;
                ngayky = null;
            }
            xrLabel3.Text = "- Căn cứ vào các điều khoản, điều kiện thỏa thuận mua bán" + hopdong + ngayky + ".";

            xrLabel9.Text = "1. Nợ đến ngày  " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu).AddDays(-1));
            xrLabel10.Text = "2. Nợ phát sinh từ  " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + " đến " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
            xrLabel12.Text = "3. Đã thanh toán đến ngày  " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
            xrLabel14.Text = "4. Công nợ phải trả đến ngày  " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));

            
            xrLabel18.Text = String.Format("{0:n0}", Double.Parse(sotien));
            xrLabel29.Text = tienchu;
            
            xrLabel30.Text = "Địa chỉ: " + gen.GetString("select Top 1 Address from Center");
            xrLabel39.Text = "Số tài khoản: " + gen.GetString("select Top 1 Bank from Center");


            DataTable data = gen.GetTable("select  CustomField6 AS 'CA',RefDate,InventoryItemName,c.ConvertUnit,QuantityConvert,b.UnitPriceOC,b.AmountOC,DocumentIncluded as 'NGUOIMUAHANG',ShippingNo AS 'PHUONGTIEN',a.Contactname as 'GHICHU' from INOutward a, INOutwardDetail b, InventoryItem c where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and a.AccountingObjectID='" + makhach + "' and RefDate>='" + ngaychungtu + "' and RefDate<='" + denngay + "' and a.StockID='" + kho + "' order by RefDate");

            DataTable dt = new DataTable();
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("CA", Type.GetType("System.String"));
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("ĐVT", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));           
            dt.Columns.Add("Người mua", Type.GetType("System.String"));
            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));
            Double phatsinh = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i + 1;
                dr[1] = data.Rows[i][0];
                dr[2] = data.Rows[i][1];
                if (data.Rows[i][2].ToString() == "Xăng RON 95")
                    dr[3] = "A95";
                else if (data.Rows[i][2].ToString() == "Xăng E5 RON 92")
                    dr[3] = "E5";
                else if (data.Rows[i][2].ToString() == "Dầu DO 0.05% S")
                    dr[3] = "DO";
                else if (data.Rows[i][2].ToString().Substring(0,3) == "261")
                    dr[3] = "Nhớt";
                else
                    dr[3] = data.Rows[i][2];
                dr[4] = data.Rows[i][3];


                if (Double.Parse(data.Rows[i][4].ToString()) != 0)
                    dr[5] = data.Rows[i][4];
                if (Double.Parse(data.Rows[i][5].ToString()) != 0)
                    dr[6] = data.Rows[i][5];
                if (Double.Parse(data.Rows[i][6].ToString()) != 0)
                {
                    dr[7] = data.Rows[i][6];
                    phatsinh = phatsinh + Double.Parse(data.Rows[i][6].ToString());
                }

                dr[8] = data.Rows[i][7];
                dr[9] = data.Rows[i][8];
                dr[10] = data.Rows[i][9];
                
                dt.Rows.Add(dr);
            }

            DataSource = dt;

            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell10.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell12.Summary = summarytotal2;

            xrTableCell2.DataBindings.Add("Text", DataSource, "STT", "{0:n2}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "CA", "{0:n0}");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd/MM/yyyy}");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Tên hàng", "{0:n0}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Người mua");
            xrTableCell22.DataBindings.Add("Text", DataSource, "Phương tiện");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Ghi chú");

            xrLabel16.Text = String.Format("{0:n0}", phatsinh);
            Double phatsinhco = 0;
            if (dauky != "")
            {
                xrLabel17.Text = String.Format("{0:n0}", Double.Parse(dauky));
                phatsinhco = Double.Parse(dauky);
            }
            xrLabel15.Text = String.Format("{0:n0}", Double.Parse(sotien) + phatsinhco - phatsinh);
        }
    }
}
