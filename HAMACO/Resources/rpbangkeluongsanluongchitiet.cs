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
    public partial class rpbangkeluongsanluongchitiet : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbangkeluongsanluongchitiet()
        {
            InitializeComponent();
        }
        public void gettieude(string ngaythang, string kho, string nhanvien)
        {
            xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel2.Text = "BẢNG KÊ CHI TIẾT LƯƠNG SẢN LƯỢNG THÁNG " + String.Format("{0:MM}", DateTime.Parse(ngaythang)) + " NĂM " + String.Format("{0:yyyy}", DateTime.Parse(ngaythang));
            xrLabel3.Text = "Mã khách: " + gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='" + nhanvien + "'");
            xrLabel6.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel4.Text = "Bảng kê chi tiết lương sản lượng tháng " + String.Format("{0:MM}", DateTime.Parse(ngaythang)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaythang)) + " - " + gen.GetString("select AccountingObjectName+'('+AccountingObjectCode+')' from AccountingObject where AccountingObjectID='" + nhanvien + "'");
        }
        public void gettieudedonvi(string kho, string nhanvien)
        {
            xrLabel5.Text = "KHO " + gen.GetString("select BranchCode+' - '+BranchName from Branch where BranchID='" + kho + "'").ToUpper();
            xrLabel2.Text = "BẢNG KÊ CHI TIẾT LỊCH SỬ THANH TOÁN";
            xrLabel3.Text = "Mã khách: " + gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='" + nhanvien + "'");
            xrLabel6.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel4.Text = "Bảng kê chi tiết lịch sử thanh toán - " + gen.GetString("select AccountingObjectName+'('+AccountingObjectCode+')' from AccountingObject where AccountingObjectID='" + nhanvien + "'");
        }
        public void Bindata(string ngaythang, string kho, string nhanvien)
        {
            DataTable da = new DataTable();
            
            da.Columns.Add("ID", Type.GetType("System.String"));
            da.Columns.Add("Mã khách", Type.GetType("System.String"));
            da.Columns.Add("Tên Khách", Type.GetType("System.String"));
            da.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            da.Columns.Add("Lập mua", Type.GetType("System.DateTime"));
            da.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            da.Columns.Add("Đến hạn", Type.GetType("System.DateTime"));
            da.Columns.Add("Tiền mua", Type.GetType("System.Double"));
            da.Columns.Add("Ngày trả", Type.GetType("System.DateTime"));
            da.Columns.Add("Tiền trả", Type.GetType("System.Double"));
            da.Columns.Add("Trả cho", Type.GetType("System.Double"));
            da.Columns.Add("Còn nợ", Type.GetType("System.Double"));
            da.Columns.Add("Trễ hạn", Type.GetType("System.Double"));
            da.Columns.Add("HP", Type.GetType("System.Double"));
            da.Columns.Add("VKS", Type.GetType("System.Double"));
            da.Columns.Add("CN", Type.GetType("System.Double"));
            da.Columns.Add("Tkhac", Type.GetType("System.Double"));
            da.Columns.Add("NS", Type.GetType("System.Double"));
            da.Columns.Add("Fico", Type.GetType("System.Double"));
            da.Columns.Add("XMkhac", Type.GetType("System.Double"));
            da.Columns.Add("Cát", Type.GetType("System.Double"));
            da.Columns.Add("Đá", Type.GetType("System.Double"));
            da.Columns.Add("Gạch", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            da.Columns.Add("Lãi", Type.GetType("System.Double"));
            da.Columns.Add("Thu nhập", Type.GetType("System.Double"));
            da.Columns.Add("Quá hạn", Type.GetType("System.Double"));
            da.Columns.Add("Phiếu trả", Type.GetType("System.String"));

            da.Columns.Add("HPT", Type.GetType("System.Double"));
            da.Columns.Add("VKST", Type.GetType("System.Double"));
            da.Columns.Add("CNT", Type.GetType("System.Double"));
            da.Columns.Add("TkhacT", Type.GetType("System.Double"));
            da.Columns.Add("NST", Type.GetType("System.Double"));
            da.Columns.Add("FicoT", Type.GetType("System.Double"));
            da.Columns.Add("XMkhacT", Type.GetType("System.Double"));
            da.Columns.Add("CátT", Type.GetType("System.Double"));
            da.Columns.Add("ĐáT", Type.GetType("System.Double"));
            da.Columns.Add("GạchT", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiềnT", Type.GetType("System.Double"));
            da.Columns.Add("Quá hạnT", Type.GetType("System.Double"));
            da.Columns.Add("Thu nhậpT", Type.GetType("System.Double"));

            da.Columns.Add("VAS", Type.GetType("System.Double"));
            da.Columns.Add("VAST", Type.GetType("System.Double"));

            DataTable dt = gen.GetTable("bangkeluongvaphibanhangchitiet '" + kho + "','" + ngaythang + "','" + nhanvien + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Double thanhtien = 0;
                Double lai = 0;
                DataRow dr = da.NewRow();
                dr[0] = dt.Rows[i][0];
                dr[1] = dt.Rows[i][1];
                dr[2] = dt.Rows[i][2];
                dr[3] = dt.Rows[i][3];
                
                if (dt.Rows[i][4].ToString() != "")
                    dr[4] = dt.Rows[i][4];
                if (dt.Rows[i][5].ToString() != "")
                    dr[5] = dt.Rows[i][5];
                if (dt.Rows[i][6].ToString() != "")
                    dr[6] = dt.Rows[i][6];
                if (dt.Rows[i][7].ToString() != "")
                    dr[7] = dt.Rows[i][7];
                if (dt.Rows[i][8].ToString() != "")
                    dr[8] = dt.Rows[i][8];
                if (dt.Rows[i][9].ToString() != "")
                    dr[9] = dt.Rows[i][9];
                if (dt.Rows[i][10].ToString() != "")
                    dr[10] = dt.Rows[i][10];
                if (dt.Rows[i][11].ToString() != "" && dt.Rows[i][11].ToString() != "0")
                    dr[11] = dt.Rows[i][11];
                if (dt.Rows[i][12].ToString() != "" && dt.Rows[i][12].ToString() != "0")
                    dr[12] = 0 - Double.Parse(dt.Rows[i][12].ToString());

                if (Double.Parse(dt.Rows[i][13].ToString()) != 0)
                    dr[13] = dt.Rows[i][13];
                if (Double.Parse(dt.Rows[i][14].ToString()) != 0)
                    dr[14] = dt.Rows[i][14];
                if (Double.Parse(dt.Rows[i][15].ToString()) != 0)
                    dr[15] = dt.Rows[i][15];
                if (Double.Parse(dt.Rows[i][16].ToString()) != 0)
                    dr[16] = dt.Rows[i][16];
                if (Double.Parse(dt.Rows[i][17].ToString()) != 0)
                    dr[17] = dt.Rows[i][17];
                if (Double.Parse(dt.Rows[i][18].ToString()) != 0)
                    dr[18] = dt.Rows[i][18];
                if (Double.Parse(dt.Rows[i][19].ToString()) != 0)
                    dr[19] = dt.Rows[i][19];
                if (Double.Parse(dt.Rows[i][20].ToString()) != 0)
                    dr[20] = dt.Rows[i][20];
                if (Double.Parse(dt.Rows[i][21].ToString()) != 0)
                    dr[21] = dt.Rows[i][21];
                if (Double.Parse(dt.Rows[i][22].ToString()) != 0)
                    dr[22] = dt.Rows[i][22];
                
                if (Double.Parse(dt.Rows[i][23].ToString()) != 0)
                {
                    dr[23] = dt.Rows[i][23];
                    thanhtien = Double.Parse(dt.Rows[i][23].ToString());
                }
                if (Double.Parse(dt.Rows[i][24].ToString()) != 0)
                    dr[24] = 0 - Double.Parse(dt.Rows[i][24].ToString());

                if (Double.Parse(dt.Rows[i][26].ToString()) != 0)
                {
                    dr[26] = 0 - Double.Parse(dt.Rows[i][26].ToString());
                    lai = 0 - Double.Parse(dt.Rows[i][26].ToString());
                }                
                if (thanhtien - lai > 0)
                    dr[25] = thanhtien - lai;
                if (dt.Rows[i][25].ToString() != "")
                    dr[27] = dt.Rows[i][25];

                //Tổng các mặt hàng
                if (Double.Parse(dt.Rows[i][27].ToString()) != 0)
                    dr[28] = dt.Rows[i][27];
                if (Double.Parse(dt.Rows[i][28].ToString()) != 0)
                    dr[29] = dt.Rows[i][28];
                if (Double.Parse(dt.Rows[i][29].ToString()) != 0)
                    dr[30] = dt.Rows[i][29];
                if (Double.Parse(dt.Rows[i][30].ToString()) != 0)
                    dr[31] = dt.Rows[i][30];
                if (Double.Parse(dt.Rows[i][31].ToString()) != 0)
                    dr[32] = dt.Rows[i][31];
                if (Double.Parse(dt.Rows[i][32].ToString()) != 0)
                    dr[33] = dt.Rows[i][32];
                if (Double.Parse(dt.Rows[i][33].ToString()) != 0)
                    dr[34] = dt.Rows[i][33];
                if (Double.Parse(dt.Rows[i][34].ToString()) != 0)
                    dr[35] = dt.Rows[i][34];
                if (Double.Parse(dt.Rows[i][35].ToString()) != 0)
                    dr[36] = dt.Rows[i][35];
                if (Double.Parse(dt.Rows[i][36].ToString()) != 0)
                    dr[37] = dt.Rows[i][36];

                if (Double.Parse(dt.Rows[i][37].ToString()) != 0)
                {
                    dr[38] = dt.Rows[i][37];
                    thanhtien = Double.Parse(dt.Rows[i][37].ToString());
                }
                if (Double.Parse(dt.Rows[i][38].ToString()) != 0)
                {
                    dr[39] = 0 - Double.Parse(dt.Rows[i][38].ToString());
                    lai = 0 - Double.Parse(dt.Rows[i][38].ToString());
                }
                if (thanhtien - lai > 0)
                    dr[40] = thanhtien - lai;

                if (Double.Parse(dt.Rows[i][39].ToString()) != 0)
                    dr[41] = dt.Rows[i][39];
                if (Double.Parse(dt.Rows[i][40].ToString()) != 0)
                    dr[42] = dt.Rows[i][40];

                da.Rows.Add(dr);
            }
            DataSource = da;
            Bands.Add(GroupHeader1);
            Bands.Add(GroupHeader2);

            GroupField groupField2 = new GroupField("Mã Khách");
            GroupHeader2.GroupFields.Add(groupField2);

            GroupField groupField1 = new GroupField("Hóa đơn");
            GroupField groupField3 = new GroupField("Đến hạn");
            GroupHeader1.GroupFields.Add(groupField3);
            GroupHeader1.GroupFields.Add(groupField1);

            
            

            xrTableCell45.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell47.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Lập mua", "{0:dd/MM/yy}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Hạn nợ","{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Đến hạn", "{0:dd/MM/yy}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Tiền mua", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "HP", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "VKS", "{0:n0}");
            xrTableCell79.DataBindings.Add("Text", DataSource, "VAS", "{0:n0}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "CN", "{0:n0}");
            xrTableCell39.DataBindings.Add("Text", DataSource, "Tkhac", "{0:n0}");
            xrTableCell40.DataBindings.Add("Text", DataSource, "NS", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Fico", "{0:n0}");
            xrTableCell42.DataBindings.Add("Text", DataSource, "XMkhac", "{0:n0}");
            xrTableCell54.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell65.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell66.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell43.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell46.DataBindings.Add("Text", DataSource, "Thu nhập", "{0:n0}");
            xrTableCell44.DataBindings.Add("Text", DataSource, "Quá hạn", "{0:n0}");

            xrTableCell48.DataBindings.Add("Text", DataSource, "HPT", "{0:n0}");
            xrTableCell49.DataBindings.Add("Text", DataSource, "VKST", "{0:n0}");
            xrTableCell78.DataBindings.Add("Text", DataSource, "VAST", "{0:n0}");
            xrTableCell50.DataBindings.Add("Text", DataSource, "CNT", "{0:n0}");
            xrTableCell51.DataBindings.Add("Text", DataSource, "TkhacT", "{0:n0}");
            xrTableCell52.DataBindings.Add("Text", DataSource, "NST", "{0:n0}");
            xrTableCell53.DataBindings.Add("Text", DataSource, "FicoT", "{0:n0}");
            xrTableCell60.DataBindings.Add("Text", DataSource, "XMkhacT", "{0:n0}");
            xrTableCell61.DataBindings.Add("Text", DataSource, "CátT", "{0:n0}");
            xrTableCell62.DataBindings.Add("Text", DataSource, "ĐáT", "{0:n0}");
            xrTableCell63.DataBindings.Add("Text", DataSource, "GạchT", "{0:n0}");
            xrTableCell64.DataBindings.Add("Text", DataSource, "Thành tiềnT", "{0:n0}");
            xrTableCell67.DataBindings.Add("Text", DataSource, "Quá hạnT", "{0:n0}");
            xrTableCell68.DataBindings.Add("Text", DataSource, "Thu nhậpT", "{0:n0}");

            xrTableCell26.DataBindings.Add("Text", DataSource, "Ngày trả", "{0:dd/MM/yy}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Tiền trả", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Trả cho", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Còn nợ", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Trễ hạn", "{0:n0}");
            xrTableCell72.DataBindings.Add("Text", DataSource, "Lãi", "{0:n0}");
            xrTableCell71.DataBindings.Add("Text", DataSource, "Phiếu trả");
        }

        public void Bindatanew(string ngaythang, string kho, string nhanvien)
        {
            DataTable da = new DataTable();

            da.Columns.Add("ID", Type.GetType("System.String"));
            da.Columns.Add("Mã khách", Type.GetType("System.String"));
            da.Columns.Add("Tên Khách", Type.GetType("System.String"));
            da.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            da.Columns.Add("Lập mua", Type.GetType("System.DateTime"));
            da.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            da.Columns.Add("Đến hạn", Type.GetType("System.DateTime"));
            da.Columns.Add("Tiền mua", Type.GetType("System.Double"));
            da.Columns.Add("Ngày trả", Type.GetType("System.DateTime"));
            da.Columns.Add("Tiền trả", Type.GetType("System.Double"));
            da.Columns.Add("Trả cho", Type.GetType("System.Double"));
            da.Columns.Add("Còn nợ", Type.GetType("System.Double"));
            da.Columns.Add("Trễ hạn", Type.GetType("System.Double"));
            da.Columns.Add("HP", Type.GetType("System.Double"));
            da.Columns.Add("VKS", Type.GetType("System.Double"));
            da.Columns.Add("CN", Type.GetType("System.Double"));
            da.Columns.Add("Tkhac", Type.GetType("System.Double"));
            da.Columns.Add("NS", Type.GetType("System.Double"));
            da.Columns.Add("Fico", Type.GetType("System.Double"));
            da.Columns.Add("XMkhac", Type.GetType("System.Double"));
            da.Columns.Add("Cát", Type.GetType("System.Double"));
            da.Columns.Add("Đá", Type.GetType("System.Double"));
            da.Columns.Add("Gạch", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            da.Columns.Add("Lãi", Type.GetType("System.Double"));
            da.Columns.Add("Thu nhập", Type.GetType("System.Double"));
            da.Columns.Add("Quá hạn", Type.GetType("System.Double"));
            da.Columns.Add("Phiếu trả", Type.GetType("System.String"));

            da.Columns.Add("HPT", Type.GetType("System.Double"));
            da.Columns.Add("VKST", Type.GetType("System.Double"));
            da.Columns.Add("CNT", Type.GetType("System.Double"));
            da.Columns.Add("TkhacT", Type.GetType("System.Double"));
            da.Columns.Add("NST", Type.GetType("System.Double"));
            da.Columns.Add("FicoT", Type.GetType("System.Double"));
            da.Columns.Add("XMkhacT", Type.GetType("System.Double"));
            da.Columns.Add("CátT", Type.GetType("System.Double"));
            da.Columns.Add("ĐáT", Type.GetType("System.Double"));
            da.Columns.Add("GạchT", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiềnT", Type.GetType("System.Double"));
            da.Columns.Add("Quá hạnT", Type.GetType("System.Double"));
            da.Columns.Add("Thu nhậpT", Type.GetType("System.Double"));

            da.Columns.Add("VAS", Type.GetType("System.Double"));
            da.Columns.Add("VAST", Type.GetType("System.Double"));

            DataTable dt = gen.GetTable("bangkeluongvaphibanhangchitietnew '" + kho + "','" + ngaythang + "','" + nhanvien + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Double thanhtien = 0;
                Double lai = 0;
                DataRow dr = da.NewRow();
                dr[0] = dt.Rows[i][0];
                dr[1] = dt.Rows[i][1];
                dr[2] = dt.Rows[i][2];
                dr[3] = dt.Rows[i][3];

                if (dt.Rows[i][4].ToString() != "")
                    dr[4] = dt.Rows[i][4];
                if (dt.Rows[i][5].ToString() != "")
                    dr[5] = dt.Rows[i][5];
                if (dt.Rows[i][6].ToString() != "")
                    dr[6] = dt.Rows[i][6];
                if (dt.Rows[i][7].ToString() != "")
                    dr[7] = dt.Rows[i][7];
                if (dt.Rows[i][8].ToString() != "")
                    dr[8] = dt.Rows[i][8];
                if (dt.Rows[i][9].ToString() != "")
                    dr[9] = dt.Rows[i][9];
                if (dt.Rows[i][10].ToString() != "")
                    dr[10] = dt.Rows[i][10];
                if (dt.Rows[i][11].ToString() != "" && dt.Rows[i][11].ToString() != "0")
                    dr[11] = dt.Rows[i][11];
                if (dt.Rows[i][12].ToString() != "" && dt.Rows[i][12].ToString() != "0")
                    dr[12] = 0 - Double.Parse(dt.Rows[i][12].ToString());

                if (Double.Parse(dt.Rows[i][13].ToString()) != 0)
                    dr[13] = dt.Rows[i][13];
                if (Double.Parse(dt.Rows[i][14].ToString()) != 0)
                    dr[14] = dt.Rows[i][14];
                if (Double.Parse(dt.Rows[i][15].ToString()) != 0)
                    dr[15] = dt.Rows[i][15];
                if (Double.Parse(dt.Rows[i][16].ToString()) != 0)
                    dr[16] = dt.Rows[i][16];
                if (Double.Parse(dt.Rows[i][17].ToString()) != 0)
                    dr[17] = dt.Rows[i][17];
                if (Double.Parse(dt.Rows[i][18].ToString()) != 0)
                    dr[18] = dt.Rows[i][18];
                if (Double.Parse(dt.Rows[i][19].ToString()) != 0)
                    dr[19] = dt.Rows[i][19];
                if (Double.Parse(dt.Rows[i][20].ToString()) != 0)
                    dr[20] = dt.Rows[i][20];
                if (Double.Parse(dt.Rows[i][21].ToString()) != 0)
                    dr[21] = dt.Rows[i][21];
                if (Double.Parse(dt.Rows[i][22].ToString()) != 0)
                    dr[22] = dt.Rows[i][22];

                if (Double.Parse(dt.Rows[i][23].ToString()) != 0)
                {
                    dr[23] = dt.Rows[i][23];
                    thanhtien = Double.Parse(dt.Rows[i][23].ToString());
                }
                if (Double.Parse(dt.Rows[i][24].ToString()) != 0)
                    dr[24] = 0 - Double.Parse(dt.Rows[i][24].ToString());

                if (Double.Parse(dt.Rows[i][26].ToString()) != 0)
                {
                    dr[26] = 0 - Double.Parse(dt.Rows[i][26].ToString());
                    lai = 0 - Double.Parse(dt.Rows[i][26].ToString());
                }
                if (thanhtien - lai > 0)
                    dr[25] = thanhtien - lai;
                if (dt.Rows[i][25].ToString() != "")
                    dr[27] = dt.Rows[i][25];

                //Tổng các mặt hàng
                if (Double.Parse(dt.Rows[i][27].ToString()) != 0)
                    dr[28] = dt.Rows[i][27];
                if (Double.Parse(dt.Rows[i][28].ToString()) != 0)
                    dr[29] = dt.Rows[i][28];
                if (Double.Parse(dt.Rows[i][29].ToString()) != 0)
                    dr[30] = dt.Rows[i][29];
                if (Double.Parse(dt.Rows[i][30].ToString()) != 0)
                    dr[31] = dt.Rows[i][30];
                if (Double.Parse(dt.Rows[i][31].ToString()) != 0)
                    dr[32] = dt.Rows[i][31];
                if (Double.Parse(dt.Rows[i][32].ToString()) != 0)
                    dr[33] = dt.Rows[i][32];
                if (Double.Parse(dt.Rows[i][33].ToString()) != 0)
                    dr[34] = dt.Rows[i][33];
                if (Double.Parse(dt.Rows[i][34].ToString()) != 0)
                    dr[35] = dt.Rows[i][34];
                if (Double.Parse(dt.Rows[i][35].ToString()) != 0)
                    dr[36] = dt.Rows[i][35];
                if (Double.Parse(dt.Rows[i][36].ToString()) != 0)
                    dr[37] = dt.Rows[i][36];

                if (Double.Parse(dt.Rows[i][37].ToString()) != 0)
                {
                    dr[38] = dt.Rows[i][37];
                    thanhtien = Double.Parse(dt.Rows[i][37].ToString());
                }
                if (Double.Parse(dt.Rows[i][38].ToString()) != 0)
                {
                    dr[39] = 0 - Double.Parse(dt.Rows[i][38].ToString());
                    lai = 0 - Double.Parse(dt.Rows[i][38].ToString());
                }
                if (thanhtien - lai > 0)
                    dr[40] = thanhtien - lai;

                if (Double.Parse(dt.Rows[i][39].ToString()) != 0)
                    dr[41] = dt.Rows[i][39];
                if (Double.Parse(dt.Rows[i][40].ToString()) != 0)
                    dr[42] = dt.Rows[i][40];

                da.Rows.Add(dr);
            }
            DataSource = da;
            Bands.Add(GroupHeader1);
            Bands.Add(GroupHeader2);

            GroupField groupField2 = new GroupField("Mã Khách");
            GroupHeader2.GroupFields.Add(groupField2);

            GroupField groupField1 = new GroupField("Hóa đơn");
            GroupField groupField3 = new GroupField("Đến hạn");
            GroupHeader1.GroupFields.Add(groupField3);
            GroupHeader1.GroupFields.Add(groupField1);




            xrTableCell45.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell47.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Lập mua", "{0:dd/MM/yy}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Đến hạn", "{0:dd/MM/yy}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Tiền mua", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "HP", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "VKS", "{0:n0}");
            xrTableCell79.DataBindings.Add("Text", DataSource, "VAS", "{0:n0}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "CN", "{0:n0}");
            xrTableCell39.DataBindings.Add("Text", DataSource, "Tkhac", "{0:n0}");
            xrTableCell40.DataBindings.Add("Text", DataSource, "NS", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Fico", "{0:n0}");
            xrTableCell42.DataBindings.Add("Text", DataSource, "XMkhac", "{0:n0}");
            xrTableCell54.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell65.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell66.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell43.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell46.DataBindings.Add("Text", DataSource, "Thu nhập", "{0:n0}");
            xrTableCell44.DataBindings.Add("Text", DataSource, "Quá hạn", "{0:n0}");

            xrTableCell48.DataBindings.Add("Text", DataSource, "HPT", "{0:n0}");
            xrTableCell49.DataBindings.Add("Text", DataSource, "VKST", "{0:n0}");
            xrTableCell78.DataBindings.Add("Text", DataSource, "VAST", "{0:n0}");
            xrTableCell50.DataBindings.Add("Text", DataSource, "CNT", "{0:n0}");
            xrTableCell51.DataBindings.Add("Text", DataSource, "TkhacT", "{0:n0}");
            xrTableCell52.DataBindings.Add("Text", DataSource, "NST", "{0:n0}");
            xrTableCell53.DataBindings.Add("Text", DataSource, "FicoT", "{0:n0}");
            xrTableCell60.DataBindings.Add("Text", DataSource, "XMkhacT", "{0:n0}");
            xrTableCell61.DataBindings.Add("Text", DataSource, "CátT", "{0:n0}");
            xrTableCell62.DataBindings.Add("Text", DataSource, "ĐáT", "{0:n0}");
            xrTableCell63.DataBindings.Add("Text", DataSource, "GạchT", "{0:n0}");
            xrTableCell64.DataBindings.Add("Text", DataSource, "Thành tiềnT", "{0:n0}");
            xrTableCell67.DataBindings.Add("Text", DataSource, "Quá hạnT", "{0:n0}");
            xrTableCell68.DataBindings.Add("Text", DataSource, "Thu nhậpT", "{0:n0}");

            xrTableCell26.DataBindings.Add("Text", DataSource, "Ngày trả", "{0:dd/MM/yy}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Tiền trả", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Trả cho", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Còn nợ", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Trễ hạn", "{0:n0}");
            xrTableCell72.DataBindings.Add("Text", DataSource, "Lãi", "{0:n0}");
            xrTableCell71.DataBindings.Add("Text", DataSource, "Phiếu trả");
        }

        public void Bindatatt(string ngaythang, string kho, string nhanvien, string makhach)
        {
            string thang = DateTime.Parse(ngaythang).Month.ToString();
            string nam = DateTime.Parse(ngaythang).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaythang).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaythang).AddMonths(-1).Year.ToString();

            DataTable da = new DataTable();

            da.Columns.Add("ID", Type.GetType("System.String"));
            da.Columns.Add("Mã khách", Type.GetType("System.String"));
            da.Columns.Add("Tên Khách", Type.GetType("System.String"));
            da.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            da.Columns.Add("Lập mua", Type.GetType("System.DateTime"));
            da.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            da.Columns.Add("Đến hạn", Type.GetType("System.DateTime"));
            da.Columns.Add("Tiền mua", Type.GetType("System.Double"));
            da.Columns.Add("Ngày trả", Type.GetType("System.DateTime"));
            da.Columns.Add("Tiền trả", Type.GetType("System.Double"));
            da.Columns.Add("Trả cho", Type.GetType("System.Double"));
            da.Columns.Add("Còn nợ", Type.GetType("System.Double"));
            da.Columns.Add("Trễ hạn", Type.GetType("System.Double"));
            da.Columns.Add("HP", Type.GetType("System.Double"));
            da.Columns.Add("VKS", Type.GetType("System.Double"));
            da.Columns.Add("CN", Type.GetType("System.Double"));
            da.Columns.Add("Tkhac", Type.GetType("System.Double"));
            da.Columns.Add("NS", Type.GetType("System.Double"));
            da.Columns.Add("Fico", Type.GetType("System.Double"));
            da.Columns.Add("XMkhac", Type.GetType("System.Double"));
            da.Columns.Add("Cát", Type.GetType("System.Double"));
            da.Columns.Add("Đá", Type.GetType("System.Double"));
            da.Columns.Add("Gạch", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            da.Columns.Add("Lãi", Type.GetType("System.Double"));
            da.Columns.Add("Thu nhập", Type.GetType("System.Double"));
            da.Columns.Add("Quá hạn", Type.GetType("System.Double"));
            da.Columns.Add("Phiếu trả", Type.GetType("System.String"));

            da.Columns.Add("HPT", Type.GetType("System.Double"));
            da.Columns.Add("VKST", Type.GetType("System.Double"));
            da.Columns.Add("CNT", Type.GetType("System.Double"));
            da.Columns.Add("TkhacT", Type.GetType("System.Double"));
            da.Columns.Add("NST", Type.GetType("System.Double"));
            da.Columns.Add("FicoT", Type.GetType("System.Double"));
            da.Columns.Add("XMkhacT", Type.GetType("System.Double"));
            da.Columns.Add("CátT", Type.GetType("System.Double"));
            da.Columns.Add("ĐáT", Type.GetType("System.Double"));
            da.Columns.Add("GạchT", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiềnT", Type.GetType("System.Double"));
            da.Columns.Add("Quá hạnT", Type.GetType("System.Double"));
            da.Columns.Add("Thu nhậpT", Type.GetType("System.Double"));

            da.Columns.Add("VAS", Type.GetType("System.Double"));
            da.Columns.Add("VAST", Type.GetType("System.Double"));

            gen.ExcuteNonquery("delete  from OpenExDateSalaryList where BranchID='" + kho + "' and EmployeeID='" + nhanvien + "' and AccountingObjectID='" + makhach + "'");
            gen.ExcuteNonquery("tonghopluongvaphihotrothongke '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "','131','" + makhach + "','" + ngaythang + "','" + nhanvien + "'");
            DataTable dt = gen.GetTable("bangkeluongvaphibanhangchitiet '" + kho + "','" + ngaythang + "','" + nhanvien + "'");
            gen.ExcuteNonquery("delete  from OpenExDateSalaryList where BranchID='" + kho + "' and EmployeeID='" + nhanvien + "' and AccountingObjectID='" + makhach + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Double thanhtien = 0;
                Double lai = 0;
                DataRow dr = da.NewRow();
                dr[0] = dt.Rows[i][0];
                dr[1] = dt.Rows[i][1];
                dr[2] = dt.Rows[i][2];
                dr[3] = dt.Rows[i][3];

                if (dt.Rows[i][4].ToString() != "")
                    dr[4] = dt.Rows[i][4];
                if (dt.Rows[i][5].ToString() != "")
                    dr[5] = dt.Rows[i][5];
                if (dt.Rows[i][6].ToString() != "")
                    dr[6] = dt.Rows[i][6];
                if (dt.Rows[i][7].ToString() != "")
                    dr[7] = dt.Rows[i][7];
                if (dt.Rows[i][8].ToString() != "")
                    dr[8] = dt.Rows[i][8];
                if (dt.Rows[i][9].ToString() != "")
                    dr[9] = dt.Rows[i][9];
                if (dt.Rows[i][10].ToString() != "")
                    dr[10] = dt.Rows[i][10];
                if (dt.Rows[i][11].ToString() != "" && dt.Rows[i][11].ToString() != "0")
                    dr[11] = dt.Rows[i][11];
                if (dt.Rows[i][12].ToString() != "" && dt.Rows[i][12].ToString() != "0")
                    dr[12] = 0 - Double.Parse(dt.Rows[i][12].ToString());

                if (Double.Parse(dt.Rows[i][13].ToString()) != 0)
                    dr[13] = dt.Rows[i][13];
                if (Double.Parse(dt.Rows[i][14].ToString()) != 0)
                    dr[14] = dt.Rows[i][14];
                if (Double.Parse(dt.Rows[i][15].ToString()) != 0)
                    dr[15] = dt.Rows[i][15];
                if (Double.Parse(dt.Rows[i][16].ToString()) != 0)
                    dr[16] = dt.Rows[i][16];
                if (Double.Parse(dt.Rows[i][17].ToString()) != 0)
                    dr[17] = dt.Rows[i][17];
                if (Double.Parse(dt.Rows[i][18].ToString()) != 0)
                    dr[18] = dt.Rows[i][18];
                if (Double.Parse(dt.Rows[i][19].ToString()) != 0)
                    dr[19] = dt.Rows[i][19];
                if (Double.Parse(dt.Rows[i][20].ToString()) != 0)
                    dr[20] = dt.Rows[i][20];
                if (Double.Parse(dt.Rows[i][21].ToString()) != 0)
                    dr[21] = dt.Rows[i][21];
                if (Double.Parse(dt.Rows[i][22].ToString()) != 0)
                    dr[22] = dt.Rows[i][22];

                if (Double.Parse(dt.Rows[i][23].ToString()) != 0)
                {
                    dr[23] = dt.Rows[i][23];
                    thanhtien = Double.Parse(dt.Rows[i][23].ToString());
                }
                if (Double.Parse(dt.Rows[i][24].ToString()) != 0)
                    dr[24] = 0 - Double.Parse(dt.Rows[i][24].ToString());

                if (Double.Parse(dt.Rows[i][26].ToString()) != 0)
                {
                    dr[26] = 0 - Double.Parse(dt.Rows[i][26].ToString());
                    lai = 0 - Double.Parse(dt.Rows[i][26].ToString());
                }
                if (thanhtien - lai > 0)
                    dr[25] = thanhtien - lai;
                if (dt.Rows[i][25].ToString() != "")
                    dr[27] = dt.Rows[i][25];

                //Tổng các mặt hàng
                if (Double.Parse(dt.Rows[i][27].ToString()) != 0)
                    dr[28] = dt.Rows[i][27];
                if (Double.Parse(dt.Rows[i][28].ToString()) != 0)
                    dr[29] = dt.Rows[i][28];
                if (Double.Parse(dt.Rows[i][29].ToString()) != 0)
                    dr[30] = dt.Rows[i][29];
                if (Double.Parse(dt.Rows[i][30].ToString()) != 0)
                    dr[31] = dt.Rows[i][30];
                if (Double.Parse(dt.Rows[i][31].ToString()) != 0)
                    dr[32] = dt.Rows[i][31];
                if (Double.Parse(dt.Rows[i][32].ToString()) != 0)
                    dr[33] = dt.Rows[i][32];
                if (Double.Parse(dt.Rows[i][33].ToString()) != 0)
                    dr[34] = dt.Rows[i][33];
                if (Double.Parse(dt.Rows[i][34].ToString()) != 0)
                    dr[35] = dt.Rows[i][34];
                if (Double.Parse(dt.Rows[i][35].ToString()) != 0)
                    dr[36] = dt.Rows[i][35];
                if (Double.Parse(dt.Rows[i][36].ToString()) != 0)
                    dr[37] = dt.Rows[i][36];

                if (Double.Parse(dt.Rows[i][37].ToString()) != 0)
                {
                    dr[38] = dt.Rows[i][37];
                    thanhtien = Double.Parse(dt.Rows[i][37].ToString());
                }
                if (Double.Parse(dt.Rows[i][38].ToString()) != 0)
                {
                    dr[39] = 0 - Double.Parse(dt.Rows[i][38].ToString());
                    lai = 0 - Double.Parse(dt.Rows[i][38].ToString());
                }
                if (thanhtien - lai > 0)
                    dr[40] = thanhtien - lai;

                if (Double.Parse(dt.Rows[i][39].ToString()) != 0)
                    dr[41] = dt.Rows[i][39];
                if (Double.Parse(dt.Rows[i][40].ToString()) != 0)
                    dr[42] = dt.Rows[i][40];

                da.Rows.Add(dr);
            }
            DataSource = da;
            Bands.Add(GroupHeader1);
            Bands.Add(GroupHeader2);

            GroupField groupField2 = new GroupField("Mã Khách");
            GroupHeader2.GroupFields.Add(groupField2);

            GroupField groupField1 = new GroupField("Hóa đơn");
            GroupField groupField3 = new GroupField("Đến hạn");
            GroupHeader1.GroupFields.Add(groupField3);
            GroupHeader1.GroupFields.Add(groupField1);


            xrTableCell45.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell47.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Lập mua", "{0:dd/MM/yy}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Đến hạn", "{0:dd/MM/yy}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Tiền mua", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "HP", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "VKS", "{0:n0}");
            xrTableCell79.DataBindings.Add("Text", DataSource, "VAS", "{0:n0}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "CN", "{0:n0}");
            xrTableCell39.DataBindings.Add("Text", DataSource, "Tkhac", "{0:n0}");
            xrTableCell40.DataBindings.Add("Text", DataSource, "NS", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Fico", "{0:n0}");
            xrTableCell42.DataBindings.Add("Text", DataSource, "XMkhac", "{0:n0}");
            xrTableCell54.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell65.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell66.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell43.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell46.DataBindings.Add("Text", DataSource, "Thu nhập", "{0:n0}");
            xrTableCell44.DataBindings.Add("Text", DataSource, "Quá hạn", "{0:n0}");

            xrTableCell48.DataBindings.Add("Text", DataSource, "HPT", "{0:n0}");
            xrTableCell49.DataBindings.Add("Text", DataSource, "VKST", "{0:n0}");
            xrTableCell78.DataBindings.Add("Text", DataSource, "VAST", "{0:n0}");
            xrTableCell50.DataBindings.Add("Text", DataSource, "CNT", "{0:n0}");
            xrTableCell51.DataBindings.Add("Text", DataSource, "TkhacT", "{0:n0}");
            xrTableCell52.DataBindings.Add("Text", DataSource, "NST", "{0:n0}");
            xrTableCell53.DataBindings.Add("Text", DataSource, "FicoT", "{0:n0}");
            xrTableCell60.DataBindings.Add("Text", DataSource, "XMkhacT", "{0:n0}");
            xrTableCell61.DataBindings.Add("Text", DataSource, "CátT", "{0:n0}");
            xrTableCell62.DataBindings.Add("Text", DataSource, "ĐáT", "{0:n0}");
            xrTableCell63.DataBindings.Add("Text", DataSource, "GạchT", "{0:n0}");
            xrTableCell64.DataBindings.Add("Text", DataSource, "Thành tiềnT", "{0:n0}");
            xrTableCell67.DataBindings.Add("Text", DataSource, "Quá hạnT", "{0:n0}");
            xrTableCell68.DataBindings.Add("Text", DataSource, "Thu nhậpT", "{0:n0}");

            xrTableCell26.DataBindings.Add("Text", DataSource, "Ngày trả", "{0:dd/MM/yy}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Tiền trả", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Trả cho", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Còn nợ", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Trễ hạn", "{0:n0}");
            xrTableCell72.DataBindings.Add("Text", DataSource, "Lãi", "{0:n0}");
            xrTableCell71.DataBindings.Add("Text", DataSource, "Phiếu trả");
        }


        public void Bindatalichsu(string ngaythang, string kho, string nhanvien, string makhach)
        {
            string thang = DateTime.Parse(ngaythang).Month.ToString();
            string nam = DateTime.Parse(ngaythang).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaythang).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaythang).AddMonths(-1).Year.ToString();

            DataTable da = new DataTable();

            da.Columns.Add("ID", Type.GetType("System.String"));
            da.Columns.Add("Mã khách", Type.GetType("System.String"));
            da.Columns.Add("Tên Khách", Type.GetType("System.String"));
            da.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            da.Columns.Add("Lập mua", Type.GetType("System.DateTime"));
            da.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            da.Columns.Add("Đến hạn", Type.GetType("System.DateTime"));
            da.Columns.Add("Tiền mua", Type.GetType("System.Double"));
            da.Columns.Add("Ngày trả", Type.GetType("System.DateTime"));
            da.Columns.Add("Tiền trả", Type.GetType("System.Double"));
            da.Columns.Add("Trả cho", Type.GetType("System.Double"));
            da.Columns.Add("Còn nợ", Type.GetType("System.Double"));
            da.Columns.Add("Trễ hạn", Type.GetType("System.Double"));
            da.Columns.Add("HP", Type.GetType("System.Double"));
            da.Columns.Add("VKS", Type.GetType("System.Double"));
            da.Columns.Add("CN", Type.GetType("System.Double"));
            da.Columns.Add("Tkhac", Type.GetType("System.Double"));
            da.Columns.Add("NS", Type.GetType("System.Double"));
            da.Columns.Add("Fico", Type.GetType("System.Double"));
            da.Columns.Add("XMkhac", Type.GetType("System.Double"));
            da.Columns.Add("Cát", Type.GetType("System.Double"));
            da.Columns.Add("Đá", Type.GetType("System.Double"));
            da.Columns.Add("Gạch", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            da.Columns.Add("Lãi", Type.GetType("System.Double"));
            da.Columns.Add("Thu nhập", Type.GetType("System.Double"));
            da.Columns.Add("Quá hạn", Type.GetType("System.Double"));
            da.Columns.Add("Phiếu trả", Type.GetType("System.String"));

            da.Columns.Add("HPT", Type.GetType("System.Double"));
            da.Columns.Add("VKST", Type.GetType("System.Double"));
            da.Columns.Add("CNT", Type.GetType("System.Double"));
            da.Columns.Add("TkhacT", Type.GetType("System.Double"));
            da.Columns.Add("NST", Type.GetType("System.Double"));
            da.Columns.Add("FicoT", Type.GetType("System.Double"));
            da.Columns.Add("XMkhacT", Type.GetType("System.Double"));
            da.Columns.Add("CátT", Type.GetType("System.Double"));
            da.Columns.Add("ĐáT", Type.GetType("System.Double"));
            da.Columns.Add("GạchT", Type.GetType("System.Double"));
            da.Columns.Add("Thành tiềnT", Type.GetType("System.Double"));
            da.Columns.Add("Quá hạnT", Type.GetType("System.Double"));
            da.Columns.Add("Thu nhậpT", Type.GetType("System.Double"));
            gen.ExcuteNonquery("delete  from OpenExDateSalaryList where BranchID='" + kho + "' and EmployeeID='" + nhanvien + "' and AccountingObjectID='" + makhach + "'");
            gen.ExcuteNonquery("tonghopluongvaphihotrothongkelichsu '" + kho + "','131','" + makhach + "','" + ngaythang + "','" + nhanvien + "'");
            DataTable dt = gen.GetTable("bangkeluongvaphibanhangchitietlichsu '" + kho + "','" + ngaythang + "','" + nhanvien + "'");
            gen.ExcuteNonquery("delete  from OpenExDateSalaryList where BranchID='" + kho + "' and EmployeeID='" + nhanvien + "' and AccountingObjectID='" + makhach + "'");
            Double conno = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Double thanhtien = 0;
                Double lai = 0;
                DataRow dr = da.NewRow();
                dr[0] = dt.Rows[i][0];
                dr[1] = dt.Rows[i][1];
                dr[2] = dt.Rows[i][2];
                dr[3] = dt.Rows[i][3];

                if (dt.Rows[i][4].ToString() != "")
                    dr[4] = dt.Rows[i][4];
                if (dt.Rows[i][5].ToString() != "")
                    dr[5] = dt.Rows[i][5];
                if (dt.Rows[i][6].ToString() != "")
                    dr[6] = dt.Rows[i][6];
                if (dt.Rows[i][7].ToString() != "")
                    dr[7] = dt.Rows[i][7];
                if (dt.Rows[i][8].ToString() != "")
                    dr[8] = dt.Rows[i][8];
                if (dt.Rows[i][9].ToString() != "")
                    dr[9] = dt.Rows[i][9];
                if (dt.Rows[i][10].ToString() != "")
                    dr[10] = dt.Rows[i][10];
                if (Double.Parse(dt.Rows[i][11].ToString()) != 0)
                {
                    dr[11] = dt.Rows[i][11];
                    conno = conno + Double.Parse(dt.Rows[i][11].ToString());
                }
                else
                    conno = 0;
                if (dt.Rows[i][12].ToString() != "" && dt.Rows[i][12].ToString() != "0")
                    dr[12] = 0 - Double.Parse(dt.Rows[i][12].ToString());

                if (Double.Parse(dt.Rows[i][13].ToString()) != 0)
                    dr[13] = dt.Rows[i][13];
                if (Double.Parse(dt.Rows[i][14].ToString()) != 0)
                    dr[14] = dt.Rows[i][14];
                if (Double.Parse(dt.Rows[i][15].ToString()) != 0)
                    dr[15] = dt.Rows[i][15];
                if (Double.Parse(dt.Rows[i][16].ToString()) != 0)
                    dr[16] = dt.Rows[i][16];
                if (Double.Parse(dt.Rows[i][17].ToString()) != 0)
                    dr[17] = dt.Rows[i][17];
                if (Double.Parse(dt.Rows[i][18].ToString()) != 0)
                    dr[18] = dt.Rows[i][18];
                if (Double.Parse(dt.Rows[i][19].ToString()) != 0)
                    dr[19] = dt.Rows[i][19];
                if (Double.Parse(dt.Rows[i][20].ToString()) != 0)
                    dr[20] = dt.Rows[i][20];
                if (Double.Parse(dt.Rows[i][21].ToString()) != 0)
                    dr[21] = dt.Rows[i][21];
                if (Double.Parse(dt.Rows[i][22].ToString()) != 0)
                    dr[22] = dt.Rows[i][22];

                if (Double.Parse(dt.Rows[i][23].ToString()) != 0)
                {
                    dr[23] = dt.Rows[i][23];
                    thanhtien = Double.Parse(dt.Rows[i][23].ToString());
                }
                if (Double.Parse(dt.Rows[i][24].ToString()) != 0)
                    dr[24] = 0 - Double.Parse(dt.Rows[i][24].ToString());

                if (Double.Parse(dt.Rows[i][26].ToString()) != 0)
                {
                    dr[26] = 0 - Double.Parse(dt.Rows[i][26].ToString());
                    lai = 0 - Double.Parse(dt.Rows[i][26].ToString());
                }
                if (thanhtien - lai > 0)
                    dr[25] = thanhtien - lai;
                if (dt.Rows[i][25].ToString() != "")
                    dr[27] = dt.Rows[i][25];

                //Tổng các mặt hàng
                if (Double.Parse(dt.Rows[i][27].ToString()) != 0)
                    dr[28] = dt.Rows[i][27];
                if (Double.Parse(dt.Rows[i][28].ToString()) != 0)
                    dr[29] = dt.Rows[i][28];
                if (Double.Parse(dt.Rows[i][29].ToString()) != 0)
                    dr[30] = dt.Rows[i][29];
                if (Double.Parse(dt.Rows[i][30].ToString()) != 0)
                    dr[31] = dt.Rows[i][30];
                if (Double.Parse(dt.Rows[i][31].ToString()) != 0)
                    dr[32] = dt.Rows[i][31];
                if (Double.Parse(dt.Rows[i][32].ToString()) != 0)
                    dr[33] = dt.Rows[i][32];
                if (Double.Parse(dt.Rows[i][33].ToString()) != 0)
                    dr[34] = dt.Rows[i][33];
                if (Double.Parse(dt.Rows[i][34].ToString()) != 0)
                    dr[35] = dt.Rows[i][34];
                if (Double.Parse(dt.Rows[i][35].ToString()) != 0)
                    dr[36] = dt.Rows[i][35];
                if (Double.Parse(dt.Rows[i][36].ToString()) != 0)
                    dr[37] = dt.Rows[i][36];

                if (Double.Parse(dt.Rows[i][37].ToString()) != 0)
                {
                    dr[38] = dt.Rows[i][37];
                    thanhtien = Double.Parse(dt.Rows[i][37].ToString());
                }
                if (Double.Parse(dt.Rows[i][38].ToString()) != 0)
                {
                    dr[39] = 0 - Double.Parse(dt.Rows[i][38].ToString());
                    lai = 0 - Double.Parse(dt.Rows[i][38].ToString());
                }
                if (thanhtien - lai > 0)
                    dr[40] = thanhtien - lai;
                da.Rows.Add(dr);
            }
            if (conno != 0)
                xrTableCell75.Text = String.Format("{0:n0}", conno);
 
            DataSource = da;

            Bands.Add(GroupHeader1);
            Bands.Add(GroupHeader2);

            GroupField groupField2 = new GroupField("Mã Khách");
            GroupHeader2.GroupFields.Add(groupField2);

            GroupField groupField1 = new GroupField("Hóa đơn");
            GroupField groupField3 = new GroupField("Đến hạn");
            GroupHeader1.GroupFields.Add(groupField3);
            GroupHeader1.GroupFields.Add(groupField1);

            xrTableCell67.DataBindings.Add("Text", DataSource, "Lãi", "{0:n0}");
            XRSummary summary = new XRSummary();
            summary.Running = SummaryRunning.Group;
            summary.IgnoreNullValues = true;
            summary.FormatString = "{0:n0}";
            xrTableCell67.Summary = summary;

            xrTableCell45.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell47.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Lập mua", "{0:dd/MM/yy}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Đến hạn", "{0:dd/MM/yy}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "Tiền mua", "{0:n0}");
            xrTableCell36.DataBindings.Add("Text", DataSource, "HP", "{0:n0}");
            xrTableCell37.DataBindings.Add("Text", DataSource, "VKS", "{0:n0}");
            xrTableCell38.DataBindings.Add("Text", DataSource, "CN", "{0:n0}");
            xrTableCell39.DataBindings.Add("Text", DataSource, "Tkhac", "{0:n0}");
            xrTableCell40.DataBindings.Add("Text", DataSource, "NS", "{0:n0}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Fico", "{0:n0}");
            xrTableCell42.DataBindings.Add("Text", DataSource, "XMkhac", "{0:n0}");
            xrTableCell54.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell65.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell66.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell43.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell46.DataBindings.Add("Text", DataSource, "Thu nhập", "{0:n0}");
            xrTableCell44.DataBindings.Add("Text", DataSource, "Quá hạn", "{0:n0}");

            xrTableCell48.DataBindings.Add("Text", DataSource, "HPT", "{0:n0}");
            xrTableCell49.DataBindings.Add("Text", DataSource, "VKST", "{0:n0}");
            xrTableCell50.DataBindings.Add("Text", DataSource, "CNT", "{0:n0}");
            xrTableCell51.DataBindings.Add("Text", DataSource, "TkhacT", "{0:n0}");
            xrTableCell52.DataBindings.Add("Text", DataSource, "NST", "{0:n0}");
            xrTableCell53.DataBindings.Add("Text", DataSource, "FicoT", "{0:n0}");
            xrTableCell60.DataBindings.Add("Text", DataSource, "XMkhacT", "{0:n0}");
            xrTableCell61.DataBindings.Add("Text", DataSource, "CátT", "{0:n0}");
            xrTableCell62.DataBindings.Add("Text", DataSource, "ĐáT", "{0:n0}");
            xrTableCell63.DataBindings.Add("Text", DataSource, "GạchT", "{0:n0}");
            xrTableCell64.DataBindings.Add("Text", DataSource, "Thành tiềnT", "{0:n0}");
            //xrTableCell67.DataBindings.Add("Text", DataSource, "Quá hạnT", "{0:n0}");
            xrTableCell68.DataBindings.Add("Text", DataSource, "Thu nhậpT", "{0:n0}");

            xrTableCell26.DataBindings.Add("Text", DataSource, "Ngày trả", "{0:dd/MM/yy}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "Tiền trả", "{0:n0}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "Trả cho", "{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "Còn nợ", "{0:n0}");
            xrTableCell34.DataBindings.Add("Text", DataSource, "Trễ hạn", "{0:n0}");
            xrTableCell72.DataBindings.Add("Text", DataSource, "Lãi", "{0:n0}");
            xrTableCell71.DataBindings.Add("Text", DataSource, "Phiếu trả");
        }

    }
}
