using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpdondathanglpgnew : DevExpress.XtraReports.UI.XtraReport
    {
        public rpdondathanglpgnew()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        doiso doi = new doiso();
        public void gettieude(string role)
        {
            DataTable temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,b.Contactname,RefDate,RefNo,c.StockID,Tel,ShippingNo,FullName,TotalAmountOC,TotalAmount-TotalFreightAmount+TotalAmountOC,Tax,b.AccountingObjectName,CustomField6,a.Contactname,TotalFreightAmount  from INOutwardLPG a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
            xrLabel29.Text=xrLabel31.Text = "Ngày " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][4].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][4].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][4].ToString()));
            xrLabel11.Text = xrLabel21.Text = temp.Rows[0][1].ToString().ToUpper() + "(" + temp.Rows[0][0].ToString() + ")";
            xrLabel34.Text = xrLabel13.Text = temp.Rows[0][2].ToString().ToUpper();
            xrLabel24.Text = temp.Rows[0][7].ToString().ToUpper();
            xrLabel26.Text = temp.Rows[0][3].ToString().ToUpper();
            xrLabel7.Text = temp.Rows[0][8].ToString().ToUpper();
            xrLabel15.Text = temp.Rows[0][15].ToString().ToUpper();
            xrLabel9.Text = xrLabel8.Text = "Số " + temp.Rows[0][5].ToString().ToUpper();
            //xrLabel30.Text = xrLabel37.Text = "Số tiền bằng chữ: " + doi.ChuyenSo(Double.Parse(temp.Rows[0][11].ToString()).ToString());

            Double chietkhau = 0;

            if (Double.Parse(temp.Rows[0][16].ToString()) != 0)
            {
                chietkhau=Double.Parse(temp.Rows[0][16].ToString());
                xrTableCell82.Text = String.Format("{0:n0}", chietkhau);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("ĐVT", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Công ty", Type.GetType("System.String"));
            dt.Columns.Add("Địa chỉ", Type.GetType("System.String"));
            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));

           

            DataTable congty = gen.GetTable("select distinct Description from INOutwardLPGDetail where RefID='" + role + "'");
            for (int i = 0; i < congty.Rows.Count; i++)
            {
                Double tongtien = 0;

                if (congty.Rows[i][0].ToString() == "HAMACO")
                    xrLabel39.Text = gen.GetString("select RefNo from hamaco.dbo.INOutward where INOutwardRefID='" + role + "'");
                else if (congty.Rows[i][0].ToString() == "Thiên An")
                    xrLabel40.Text = gen.GetString("select RefNo from hamaco_ta.dbo.INOutward where INOutwardRefID='" + role + "'");
                else if (congty.Rows[i][0].ToString() == "Dịch vụ HAMACO")
                    xrLabel41.Text = gen.GetString("select RefNo from hamaco_tn.dbo.INOutward where INOutwardRefID='" + role + "'");

                temp = gen.GetTable("bangkedondathanglpg '" + role + "',N'" + congty.Rows[i][0].ToString() + "'");
                for (int j = 0; j < 8; j++)
                {
                    DataRow dr = dt.NewRow();
                    if (j < temp.Rows.Count)
                    {
                        dr[0] = temp.Rows[j][0];
                        dr[1] = temp.Rows[j][1];
                        dr[2] = temp.Rows[j][2];
                        dr[3] = temp.Rows[j][3];
                        dr[4] = temp.Rows[j][4];
                        tongtien = tongtien + Double.Parse(temp.Rows[j][4].ToString());
                        dr[5] = temp.Rows[j][5];
                        dr[6] = temp.Rows[j][6];
                        dr[7] = temp.Rows[j][7];
                        dr[8] = j + 1;
                        dr[9] = temp.Rows[j][8];
                    }
                    else
                    {
                        dr[5] = temp.Rows[0][5];
                        dr[6] = temp.Rows[0][6];
                        dr[7] = temp.Rows[0][7];
                    }
                    dt.Rows.Add(dr);
                }

                xrTableCell108.Text = String.Format("{0:n0}", tongtien-chietkhau);
                xrLabel30.Text = xrLabel37.Text = "Số tiền bằng chữ: " + doi.ChuyenSo((tongtien-chietkhau).ToString());
            }           

            temp = gen.GetTable("bangkedondathanglpg '" + role + "','chung'");
            for (int i = 0; i < 9; i++)
            {
                if (i < temp.Rows.Count)
                {
                    xrTable7.Rows[i].Cells[1].Text = temp.Rows[i][0].ToString();
                    xrTable7.Rows[i].Cells[2].Text = temp.Rows[i][1].ToString();
                    xrTable7.Rows[i].Cells[3].Text = Double.Parse(temp.Rows[i][2].ToString()).ToString();
                }
            }
            

            DataSource = dt;

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Công ty");

            GroupHeader1.GroupFields.Add(groupField);
            xrLabel1.DataBindings.Add("Text", DataSource, "Công ty");
            xrLabel6.DataBindings.Add("Text", DataSource, "Địa chỉ");
            //xrLabel9.DataBindings.Add("Text", DataSource, "Số phiếu");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();

            summarytotal.Running = SummaryRunning.Group;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell46.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell46.Summary = summarytotal;
            /*
            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell108.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrTableCell108.Summary = summarytotal1;
            */
            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n0}";
            xrLabel28.DataBindings.Add("Text", DataSource, "Thành tiền", "{0:n0}");
            xrLabel28.Summary = summarytotal2;


            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell106.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell106.Summary = summarytotal3;

            xrTableCell2.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell4.DataBindings.Add("Text", DataSource, "ĐVT");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Mã hàng");
        }

    }
}
