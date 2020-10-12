using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbienbanxacnhannonoibo : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbienbanxacnhannonoibo()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string ngaychungtu, string denngay, string manganh,string userid)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel6.Text = gen.GetString("select Top 1 Address from Center");
            xrLabel4.Text = "Điện thoại: " + gen.GetString("select Top 1 Phone from Center");

            xrLabel35.Text = "THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));

            DataTable data = gen.GetTable("select ca AS 'CA',RefDate,InventoryItemName,d.ConvertUnit,QuantityConvert,a.UnitPrice,a.Amount,Taixe as 'NGUOIMUAHANG',Soxe AS 'PHUONGTIEN',Sokm as 'GHICHU' from OUTdeficitDetail a, (select * from OUTdeficit where MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and Cancel='True') b, (select * from MSC_UserJoinStock where UserID='" + userid + "') c,InventoryItem d where a.RefID=b.RefID and b.StockID=c.StockID and a.InventoryItemID=d.InventoryItemID and a.Description='" + manganh + "' order by RefDate,CA");
          
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
            dt.Columns.Add("Ghi chú", Type.GetType("System.Double"));
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
                else if (data.Rows[i][2].ToString().Substring(0, 3) == "261")
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
            xrTableCell23.DataBindings.Add("Text", DataSource, "Ghi chú", "{0:n0}");

            xrLabel29.Text ="Bằng chữ: "+ doi.ChuyenSo(phatsinh.ToString());
        }
    }
}
