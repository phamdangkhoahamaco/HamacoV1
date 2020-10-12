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
    public partial class rpdondathangmn : DevExpress.XtraReports.UI.XtraReport
    {
        public rpdondathangmn()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        Frm_nhapxuat ThisF = new Frm_nhapxuat();
        string roleID, tsbtID, loaiID;
        public void gettieude(string phieu, string tsbt, string loai, Frm_nhapxuat F)
        {
            roleID = phieu;
            tsbtID = tsbt;
            loaiID = loai;
            ThisF = F;

            DataTable temp = new DataTable();

            xrLabel14.Text = gen.GetString("select Top 1 CompanyName from Center");
            //xrLabel20.Text = gen.GetString("select Top 1 Phone from Center");
            xrLabel20.Text = "02923.830.582 - Fax: 02923.731.505";

            if (tsbt == "tsbtddhphieumn")
            {
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,b.Address,Tel,Fax,JournalMemo,RefDate,ShippingNo,Cancel,CustomField6,DocumentIncluded,CustomField3,CustomField1,a.AccountingObjectID,RefType,a.ContactName from DDHNCC a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + phieu + "'");
            }
            xrLabel3.Text = "Ngày  " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][6].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][6].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][6].ToString()));
            xrLabel9.Text = temp.Rows[0][0].ToString();

            if (temp.Rows[0][14].ToString() == "0")
                xrLabel34.Text = "[X]";
            else
            {
                if (temp.Rows[0][8].ToString() == "True")
                    xrLabel30.Text = "[X]";
                else
                    xrLabel32.Text = "[X]";
            }

            xrLabel26.Text = temp.Rows[0][7].ToString();
            xrLabel13.Text = temp.Rows[0][9].ToString();
            xrLabel22.Text = temp.Rows[0][10].ToString();
            xrLabel18.Text = temp.Rows[0][11].ToString();           
            xrTableCell3.Text = temp.Rows[0][15].ToString();

            //xrLabel24.Text = temp.Rows[0][12].ToString();
            xrLabel45.Text = "Nơi nhận hàng: " + temp.Rows[0][12].ToString();

            try
            {
                xrLabel29.Text = gen.GetString("select Top 1 a.ParentContract from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where AccountingObjectID='" + temp.Rows[0][13].ToString() + "' and SignedDate<='" + temp.Rows[0][6].ToString() + "'and EffectiveDate>='" + temp.Rows[0][6].ToString() + "' and Inactive=1 group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate"); ;
            }
            catch { }
        }

        public void BindData(string phieu, string tsbt)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("ĐVT", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Bó/cuộn", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("STT", Type.GetType("System.Double"));

            DataTable temp = new DataTable();
            if (tsbt == "tsbtddhphieumn")
            {
                if (loaiID == "0")
                    temp = gen.GetTable("select InventoryItemName, case when Quantity=0 then ConvertUnit else b.Unit end, Quantity,QuantityConvert,a.ConvertRate, case when Quantity=0 then Amount/QuantityConvert else Amount/Quantity end from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
                else
                    temp = gen.GetTable("select InventoryItemName, case when Quantity=0 then ConvertUnit else b.Unit end, Quantity,QuantityConvert,a.ConvertRate, Amount/NULLIF(a.ConvertRate,0) from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];

                if (loaiID != "1")
                {
                    if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                        dr[2] = temp.Rows[i][2];
                    else
                        dr[3] = temp.Rows[i][3];

                    if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                        dr[5] = temp.Rows[i][5];
                }
                else
                {
                    if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    {
                        dr[4] = temp.Rows[i][4];
                        dr[5] = temp.Rows[i][5];
                    }
                }

                

                dr[6] = i + 1;
                dt.Rows.Add(dr);
            }

            DataSource = dt;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();

            xrTableCell1.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");           
            xrTableCell5.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Bó/cuộn", "{0:n0}");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            //xrTableCell8.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
        }

        private void xrLabel7_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(tsbtID);
            F.getrole(roleID);
            if (loaiID == "0")
                F.getkho("1");
            else
                F.getkho("0");
            F.ShowDialog();
            ThisF.Close();
        }
    }
}
