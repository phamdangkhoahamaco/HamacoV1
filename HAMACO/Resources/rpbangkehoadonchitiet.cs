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
    public partial class rpbangkehoadonchitiet : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbangkehoadonchitiet()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude()
        {
            xrLabel2.Text = "BẢNG KÊ CHI TIẾT HÓA ĐƠN BÁN HÀNG";
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }
        public void BindData(Int32 dem, string[,] hoadon)
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Bốc xếp", Type.GetType("System.Double"));
            dt.Columns.Add("Chênh lệch", Type.GetType("System.Double"));
            for (int z = 0; z <= dem; z++)
            {
                temp = gen.GetTable("tonghopketquakinhdoanhtheohoadon '"+hoadon[z,0]+"'");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0];
                    dr[1] = temp.Rows[i][1];
                    dr[2] = String.Format("{0:MM-dd-yyyy}", DateTime.Parse(temp.Rows[i][2].ToString()));
                    dr[3] = temp.Rows[i][3];
                    dr[4] = temp.Rows[i][4];
                    dr[5] = temp.Rows[i][5];
                    dr[6] = temp.Rows[i][6];
                    if (Double.Parse(temp.Rows[i][7].ToString())!=0)
                        dr[7] = temp.Rows[i][7];
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                        dr[8] = temp.Rows[i][8];
                    if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                        dr[9] = temp.Rows[i][9];
                    if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                        dr[10] = temp.Rows[i][10];
                    if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                        dr[11] = temp.Rows[i][11];
                    if (Double.Parse(temp.Rows[i][12].ToString()) != 0)
                        dr[12] = temp.Rows[i][12];
                    if (Double.Parse(temp.Rows[i][13].ToString()) != 0)
                        dr[13] = temp.Rows[i][13];
                    dr[14] = Double.Parse(temp.Rows[i][12].ToString()) - Double.Parse(temp.Rows[i][13].ToString()) - Double.Parse(temp.Rows[i][10].ToString());
                    dt.Rows.Add(dr);
                }
            }
            DataSource = dt;

            Bands.Add(GroupHeader2);
            GroupField groupField = new GroupField("Mã khách");
            GroupHeader2.GroupFields.Add(groupField);

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            xrTableCell10.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell11.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Ngày", "{0:dd-MM-yyyy}");

            xrTableCell14.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell35.DataBindings.Add("Text", DataSource, "Tên khách");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();
            XRSummary summarytotal9 = new XRSummary();
            XRSummary summarytotal10 = new XRSummary();
            XRSummary summarytotal11 = new XRSummary();
            XRSummary summarytotal12 = new XRSummary();
            XRSummary summarytotal13 = new XRSummary();
            XRSummary summarytotal14 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();
            XRSummary summarytotal16 = new XRSummary();
            XRSummary summarytotal17 = new XRSummary();

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell21.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell21.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell32.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Giá vốn", "{0:n0}");
            xrTableCell3.Summary = summarytotal2;

            summarytotal3.Running = SummaryRunning.Group;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell4.DataBindings.Add("Text", DataSource, "Giá bán", "{0:n0}");
            xrTableCell4.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Group;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell5.DataBindings.Add("Text", DataSource, "Bốc xếp", "{0:n0}");
            xrTableCell5.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Group;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            xrTableCell7.Summary = summarytotal5;



            summarytotal6.Running = SummaryRunning.Group;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell36.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Group;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n2}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell39.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "Giá vốn", "{0:n0}");
            xrTableCell40.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "Giá bán", "{0:n0}");
            xrTableCell42.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell53.DataBindings.Add("Text", DataSource, "Bốc xếp", "{0:n0}");
            xrTableCell53.Summary = summarytotal10;

            summarytotal11.Running = SummaryRunning.Group;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell2.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            xrTableCell2.Summary = summarytotal11;



            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell27.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n2}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell28.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Giá vốn", "{0:n0}");
            xrTableCell29.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Report;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell30.DataBindings.Add("Text", DataSource, "Giá bán", "{0:n0}");
            xrTableCell30.Summary = summarytotal15;

            summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Bốc xếp", "{0:n0}");
            xrTableCell33.Summary = summarytotal16;

            summarytotal17.Running = SummaryRunning.Report;
            summarytotal17.IgnoreNullValues = true;
            summarytotal17.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
            xrTableCell34.Summary = summarytotal17;
          

            xrTableCell15.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell43.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đơn giá vốn", "{0:n2}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Đơn giá bán", "{0:n2}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell23.DataBindings.Add("Text", DataSource, "Giá vốn", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Giá bán", "{0:n0}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "Bốc xếp", "{0:n0}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Chênh lệch", "{0:n0}");
        }
    }
}
