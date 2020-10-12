using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HAMACO.Resources;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace HAMACO
{
    public partial class Frm_nhapxuat : DevExpress.XtraEditors.XtraForm
    {
        public Frm_nhapxuat()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void Frm_nhapxuat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (tsbt == "snkxk" || tsbt == "snkxkct" || tsbt == "tsbtpxk" || tsbt == "tsbtpxkct")
                {
                    ngaychungtu = String.Format("{0:dd-MM-yyy}", DateTime.Parse(ngaychungtu));
                    role = String.Format("{0:dd-MM-yyy}", DateTime.Parse(role));
                    DataSet ds = new DataSet();
                    ds.Tables.Add(da);
                    gen.CreateExcel(ds, "Bangkexuatkho_"+gen.GetString("select StockCode from Stock where StockID='"+congty+"'")+"_" + ngaychungtu + "_" + role + ".xlsx");
                }
                else if (tsbt == "snknk")
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(da);
                    gen.CreateExcel(ds, "Bangkenhapkho_" + role + ".xlsx");
                }
                else if (tsbt == "bccnhtd")
                {
                    if (XtraMessageBox.Show("Bạn có thực sự muốn lưu công nợ này vào ngày "+String.Format("{0:dd-MM-yyy}", DateTime.Parse(ngaychungtu))+"?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        gen.ExcuteNonquery("delete OpeningAccountEntry131TTBackup where PostedDate='" + DateTime.Parse(ngaychungtu).ToShortDateString() + "'");
                        gen.ExcuteNonquery("insert OpeningAccountEntry131TTBackup select *,PostedDate='" + DateTime.Parse(ngaychungtu).ToShortDateString() + "' from OpeningAccountEntry131TT");
                    }               
                }
                this.Close();

            }
        }
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        DataTable da = new DataTable();
        DataTable temp = new DataTable();
        doiso doi = new doiso();
        Boolean noibo = false;
        string[,] hoadon = new string[20, 2];
        Int32 dem = 0;
        public Boolean getnoibo(Boolean a)
        {
            noibo = a;
            return noibo;
        }
        public Int32 getdem(Int32 a)
        {
            dem = a;
            return dem;
        }
        public string[,] gethoadon(string[,] a)
        {
            hoadon = a;
            return hoadon;
        }
        string tsbt, MMDoc, role, nguoinop, diachi, sophieu, lydo, thucte, phuongtien, hoten, kho, congty, phieu, ngaychungtu, phieuvo, sophieuvo, no, co, sodienthoai, denngay, dauky;
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
        public string getdauky(string a)
        {
            dauky = a;
            return dauky;
        }
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getMMDoc(string a)
        {
            MMDoc = a;
            return MMDoc;
        }
        public string getkho(string a)
        {
            kho = a;
            return kho;
        }
        public string getcongty(string a)
        {
            congty = a;
            return congty;
        }
        public string getngay(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getdenngay(string a)
        {
            denngay = a;
            return denngay;
        }
        public DataTable getdata(DataTable a)
        {
            da = a;
            return da;
        }
        private void Frm_nhapxuat_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("ĐVT", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Loại", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng QĐ", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double")); 
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));
            if (tsbt == "pnk")
            { 
                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit from INInwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                int dem = 11;
                if (da.Rows.Count > 11)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i+1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        if (Double.Parse(da.Rows[i][0].ToString()) == Double.Parse(da.Rows[i][1].ToString()) || Double.Parse(da.Rows[i][0].ToString()) == 0)
                        {
                            dr[2] = da.Rows[i][4].ToString();
                            //dr[3] = da.Rows[i][1].ToString();
                        }
                        else
                        {
                            dr[2] = da.Rows[i][3].ToString();
                            //dr[3] = da.Rows[i][0].ToString();
                        }
                        if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                            dr[3] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                            dr[5] = da.Rows[i][1].ToString();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName  from INInward a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU NHẬP KHO";
                thucte = "Thực nhập";
                
                rpnhapxuat thuchi = new rpnhapxuat();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo,"Nhà cung cấp:", phuongtien, thucte, hoten);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "ddhpnk")
            {
                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit from DDHNCCDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                int dem = 11;
                if (da.Rows.Count > 11)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        if (Double.Parse(da.Rows[i][0].ToString()) == Double.Parse(da.Rows[i][1].ToString()) || Double.Parse(da.Rows[i][0].ToString()) == 0)
                        {
                            dr[2] = da.Rows[i][4].ToString();
                            //dr[3] = da.Rows[i][1].ToString();
                        }
                        else
                        {
                            dr[2] = da.Rows[i][3].ToString();
                            //dr[3] = da.Rows[i][0].ToString();
                        }
                        if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                            dr[3] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                            dr[5] = da.Rows[i][1].ToString();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName  from DDHNCC a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU NHẬP KHO";
                thucte = "Thực nhập";

                rpnhapxuat thuchi = new rpnhapxuat();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, "Nhà cung cấp:", phuongtien, thucte, hoten);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtpnktt")
            {
                this.Text = "Phiếu nhập kho thực tế";
                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit from INInwardDetailTT a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                int dem = 11;
                if (da.Rows.Count > 11)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        if (Double.Parse(da.Rows[i][0].ToString()) == Double.Parse(da.Rows[i][1].ToString()) || Double.Parse(da.Rows[i][0].ToString()) == 0)
                        {
                            dr[2] = da.Rows[i][4].ToString();
                            //dr[3] = da.Rows[i][1].ToString();
                        }
                        else
                        {
                            dr[2] = da.Rows[i][3].ToString();
                            //dr[3] = da.Rows[i][0].ToString();
                        }
                        if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                            dr[3] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                            dr[5] = da.Rows[i][1].ToString();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName  from INInwardTT a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU NHẬP KHO";
                thucte = "Thực nhập";

                rpnhapxuat thuchi = new rpnhapxuat();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, "Nhà cung cấp:", phuongtien, thucte, hoten);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pxk" || tsbt=="pxkddh")
            {
                this.Text = "Phiếu xuất kho";
                if (tsbt == "pxkddh")
                    da = gen.GetTable("select  QuantityExits,QuantityConvertExits,InventoryItemName,b.ConvertUnit,b.Unit from DDHDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.ConvertUnit,b.Unit from INOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                int dem = 11;
                if (da.Rows.Count > 11)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        if (Double.Parse(da.Rows[i][0].ToString()) == Double.Parse(da.Rows[i][1].ToString()) || Double.Parse(da.Rows[i][0].ToString()) == 0)
                        {
                            dr[2] = da.Rows[i][3].ToString();
                            //dr[3] = da.Rows[i][1].ToString();
                        }
                        else
                        {
                            dr[2] = da.Rows[i][4].ToString();
                            //dr[3] = da.Rows[i][0].ToString();
                        }
                        if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                            dr[3] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                            dr[5] = da.Rows[i][1].ToString();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }
                if (tsbt == "pxkddh")
                    temp = gen.GetTable("select b.AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,JournalMemo,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName  from DDH  a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.InStockID=c.StockID and a.RefID='" + role + "'");
                else
                    temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,JournalMemo,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName  from INOutward a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                if (congty == "1")
                    phieu = "YÊU CẦU CUNG CẤP HÀNG";
                else phieu = "PHIẾU XUẤT KHO";
                    
                thucte = "Thực xuất";

                rpnhapxuat thuchi = new rpnhapxuat();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, "Tên khách hàng:", phuongtien, thucte, hoten);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pxktrong")
            {
                this.Text = "Phiếu xuất kho";
                
                for (int i = 0; i < 11; i++)
                {                   
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                }               
                phieu = "YÊU CẦU CUNG CẤP HÀNG";             
                thucte = "Thực xuất";

                rpnhapxuat thuchi = new rpnhapxuat();
                thuchi.gettieude("",phieu,"", kho,"","","","", "Tên khách hàng:","","","");
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "barbctct")
            {
                this.Text = "Báo cáo thu chi tiền";
                rpbaocaothuchitien thuchi = new rpbaocaothuchitien();
                thuchi.gettieude(ngaychungtu, role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pxkbienban")
            {
                this.Text = "Biên bản giao nhận hàng";
                temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,a.Contactname,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName,TotalAmountOC,TotalAmount-TotalFreightAmount+TotalAmountOC,Tax  from INOutward a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "BIÊN BẢN GIAO NHẬN HÀNG";
                thucte = "Thực xuất";
                string thuexuat = temp.Rows[0][12].ToString();
                da = gen.GetTable("select InventoryItemName,b.Unit,Quantity,b.ConvertUnit,QuantityConvert,a.Amount+a.Cost-a.DiscountAmount,a.UnitPrice from INOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                string thue=temp.Rows[0][10].ToString();
                string tongcong=temp.Rows[0][11].ToString();
                string sotienchu = doi.ChuyenSo(Double.Parse(tongcong).ToString());

                int dem = 9;
                if (da.Rows.Count > 9)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][2].ToString()) != 0)
                        {
                            dr[2] = da.Rows[i][1].ToString();
                            dr[3] = da.Rows[i][2].ToString();
                            dr[6] = Math.Round((Double.Parse(da.Rows[i][5].ToString()) / Double.Parse(da.Rows[i][2].ToString())), 2).ToString();
                            dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dr[2] = da.Rows[i][3].ToString();
                            dr[3] = da.Rows[i][4].ToString();
                            dr[6] =da.Rows[i][6].ToString();
                            dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                            dt.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }

                }
                
                rpbienbangiaonhan thuchi = new rpbienbangiaonhan();
                thuchi.gettieude(nguoinop,diachi,lydo,ngaychungtu,sophieu,kho,phuongtien,phieu,thue,tongcong,sotienchu,thuexuat);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }


            else if (tsbt == "pnkbienbantra")
            {
                this.Text = "Phiếu nhập hàng bán trả lại";
                temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,Address,a.Contactname,RefDate,RefNo,StockCode,StockName,JournalMemo,FullName,TotalVatAmount,TotalAmount+TotalVatAmount,Tax  from INReInward a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU NHẬP HÀNG BÁN TRẢ LẠI";
                thucte = "Thực nhập";             
                da = gen.GetTable("select InventoryItemName,b.Unit,Quantity,b.ConvertUnit,QuantityConvert,a.Amount,a.UnitPrice from INReInwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                string thuexuat = temp.Rows[0][12].ToString();
                string thue = temp.Rows[0][10].ToString();
                string tongcong = temp.Rows[0][11].ToString();
                string sotienchu = doi.ChuyenSo(Double.Parse(tongcong).ToString());

                int dem = 9;
                if (da.Rows.Count > 9)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][2].ToString()) != 0)
                        {
                            dr[2] = da.Rows[i][1].ToString();
                            dr[3] = da.Rows[i][2].ToString();
                            dr[6] = Math.Round((Double.Parse(da.Rows[i][5].ToString()) / Double.Parse(da.Rows[i][2].ToString())), 2).ToString();
                            dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dr[2] = da.Rows[i][3].ToString();
                            dr[3] = da.Rows[i][4].ToString();
                            dr[6] = da.Rows[i][6].ToString();
                            dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                            dt.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }

                }

                rpbienbangiaonhan thuchi = new rpbienbangiaonhan();
                thuchi.gettieudetra(nguoinop, diachi, lydo, ngaychungtu, sophieu, kho, phuongtien, phieu, thue, tongcong, sotienchu, thuexuat);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pxhmtlbienbantra")
            {
                this.Text = "Phiếu xuất hàng mua trả lại";
                temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,Address,a.Contactname,RefDate,RefNo,StockCode,StockName,JournalMemo,FullName,TotalVatAmount,TotalAmount+TotalVatAmount,Tax  from INReOutward a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU XUẤT HÀNG MUA TRẢ LẠI";
                thucte = "Thực xuất";
                da = gen.GetTable("select InventoryItemName,b.Unit,Quantity,b.ConvertUnit,QuantityConvert,a.Amount,a.UnitPrice from INReOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                string thuexuat = temp.Rows[0][12].ToString();
                string thue = temp.Rows[0][10].ToString();
                string tongcong = temp.Rows[0][11].ToString();
                string sotienchu = doi.ChuyenSo(Double.Parse(tongcong).ToString());

                int dem = 9;
                if (da.Rows.Count > 9)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][2].ToString()) != 0)
                        {
                            dr[2] = da.Rows[i][1].ToString();
                            dr[3] = da.Rows[i][2].ToString();
                            dr[6] = Math.Round((Double.Parse(da.Rows[i][5].ToString()) / Double.Parse(da.Rows[i][2].ToString())), 2).ToString();
                            dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dr[2] = da.Rows[i][3].ToString();
                            dr[3] = da.Rows[i][4].ToString();
                            dr[6] = da.Rows[i][6].ToString();
                            dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                            dt.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }

                }

                rpbienbangiaonhan thuchi = new rpbienbangiaonhan();
                thuchi.gettieudetra(nguoinop, diachi, lydo, ngaychungtu, sophieu, kho, phuongtien, phieu, thue, tongcong, sotienchu, thuexuat);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pxkbienbanvat" || tsbt == "pxkbienbanvatddh")
            {
                this.Text = "Biên bản giao nhận hàng"; // da viet lai moi
                // đã xóa code cũ.
                DataTable dt = new DataTable();
                dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
                dt.Columns.Add("ĐVT", Type.GetType("System.String"));
                dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
                dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
                dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
                dt.Columns.Add("STT", Type.GetType("System.String"));

                //temp = gen.GetTable("select b.InventoryItemName,Quantity,b.Unit,QuantityConvert from DDHDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "'");
                DataTable  temp = gen.GetTable("select InventoryItemName,Unit,QuantityConvert,UnitPrice,Amount from MMDocumentDetail WHERE MMDoc = '" + MMDoc + "'");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0];
                    dr[1] = temp.Rows[i][1];
                    dr[2] = temp.Rows[i][2];
                    dr[3] = temp.Rows[i][3];
                    dr[4] = temp.Rows[i][4];
                    dr[5] = i + 1;
                    dt.Rows.Add(dr);
                }

                String MySQL = "select StockCode2,StockName, c.Description,d.FullName, a.RefDate,RefNo, a.TotalAmount, a.AccountingObjectName, a.AccountingObjectCode,AccountingObjectAddress,Dienthoai,";
                MySQL += "Taixe,a.ContactName, MMHeader, a.TotalAmount from [MMDocument] a, Stock c,MSC_User d";
                MySQL += "  where a.StockCode2 = c.StockCode and a.UserName = d.UserName and MMDoc = '" + MMDoc + "'";
                DataTable temp2 = gen.GetTable(MySQL);
                DataRow[] dr2 = temp2.Select(); // lay dong dau tien
                string sotienchu = "";
                foreach (DataRow row in dr2)
                {
                    ngaychungtu = row["RefDate"].ToString();
                    nguoinop = row["AccountingObjectName"].ToString();
                    diachi = row["AccountingObjectAddress"].ToString();
                    lydo = row["MMHeader"].ToString();
                    sophieu = MMDoc;
                    kho = row["StockCode2"].ToString();
                    phuongtien = row["Taixe"].ToString();                    
                    phieu = "BIÊN BẢN GIAO NHẬN HÀNG";
                    hoten = row["FullName"].ToString();
                    sotienchu = doi.ChuyenSo(Double.Parse(row["TotalAmount"].ToString()).ToString());  // so tien
                }

                
                rpbienbangiaonhanvat thuchi = new rpbienbangiaonhanvat(); // bien ban giao nhan VAT
                thuchi.gettieude(nguoinop, diachi, lydo, ngaychungtu, sophieu, kho, phuongtien, phieu, sotienchu, hoten);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "dondathangthongtin")
            {
                this.Text = "Thông tin đơn đặt hàng";
                rpdondathangthongtin thuchi = new rpdondathangthongtin();
                thuchi.gettieude(MMDoc);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbccn131bienbanxacnhanno")
            {
                this.Text = "Biên bản xác nhận nợ";
                rpbienbanxacnhanno thuchi = new rpbienbanxacnhanno();
                if (congty == null)
                    congty = "0";
                string sotienchu = "Bằng chữ: " + doi.ChuyenSo(Double.Parse(congty.Replace(".", "").Replace("-", "")).ToString());
                thuchi.gettieude(ngaychungtu, ngaychungtu, role, congty, sotienchu, kho);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbccn131bienbanxacnhannochitiet")
            {
                this.Text = "Biên bản xác nhận nợ chi tiết";
                rpbienbanxacnhannochitiet  thuchi = new rpbienbanxacnhannochitiet();
                if (congty == "")
                    congty = "0";
                string sotienchu = "Bằng chữ: " + doi.ChuyenSo(Double.Parse(congty.Replace(".", "").Replace("-", "")).ToString());
                thuchi.gettieude(ngaychungtu, denngay, role, congty, sotienchu, kho, dauky);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "bkpxhtdnbdc")
            {
                this.Text = "Biên bản xác nhận ";
                rpbienbanxacnhannonoibo thuchi = new rpbienbanxacnhannonoibo();
                thuchi.gettieude(ngaychungtu, denngay, role, kho);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "pxkbienbanvatxacnhan" || tsbt == "pxkbienbanvatsoluong" || tsbt == "pxkbienbanvatsoluongddh" || tsbt == "pxkbienbanvatxacnhanddh")
            {
                this.Text = "Biên bản giao nhận hàng";
                if (tsbt == "pxkbienbanvatsoluongddh" || tsbt == "pxkbienbanvatxacnhanddh")
                    temp = gen.GetTable("select b.AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,a.Contactname,RefDate,RefNo,c.StockID,OriginalRefNo,ShippingNo,FullName,0,TotalAmount+TotalAmountOC,Tax,b.AccountingObjectName,a.ReceiveMethod,d.MobilePhone,a.DocumentIncluded,Taixe,CMND,Dienthoai  from DDH a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.InStockID=c.StockID and a.RefID='" + role + "'");
                else
                    temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,a.Contactname,RefDate,RefNo,c.StockID,OriginalRefNo,ShippingNo,FullName,TotalFreightAmount,TotalAmount-TotalFreightAmount/1.1+TotalAmountOC,Tax,b.AccountingObjectName,CustomField6,d.MobilePhone,a.DocumentIncluded,Taixe,CMND,Dienthoai from INOutward a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][13].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                string giaohang = temp.Rows[0][14].ToString();
                string daidien = temp.Rows[0][16].ToString();
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                sodienthoai = temp.Rows[0][15].ToString();

                string taixe = temp.Rows[0][17].ToString();
                string cmnd = temp.Rows[0][18].ToString();
                string sdttaixe = temp.Rows[0][19].ToString();

                string sdt = temp.Rows[0][7].ToString();
                phieu = "BIÊN BẢN GIAO NHẬN HÀNG";

                string sotienchu = doi.ChuyenSo(Math.Round(Double.Parse(temp.Rows[0][11].ToString()),0).ToString());

                if (tsbt == "pxkbienbanvatsoluongddh" || tsbt == "pxkbienbanvatxacnhanddh")
                    da = gen.GetTable("select InventoryItemName,b.Unit,QuantityExits,b.ConvertUnit,QuantityConvertExits,a.AmountOC,a.UnitPriceOC,a.DiscountRate,'' from DDHDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else
                    da = gen.GetTable("select InventoryItemName,b.Unit,Quantity,b.ConvertUnit,QuantityConvert,a.AmountOC,a.UnitPriceOC,a.UnitPriceConvert,a.CustomField3 from INOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = (i + 1).ToString();
                    dr[1] = da.Rows[i][0].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    if (Double.Parse(da.Rows[i][2].ToString()) != 0)
                    {
                        dr[2] = da.Rows[i][1].ToString();
                        dr[3] = da.Rows[i][2].ToString();
                        dr[6] = da.Rows[i][7].ToString();
                        dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                    }
                    else
                    {
                        dr[2] = da.Rows[i][3].ToString();
                        dr[3] = da.Rows[i][4].ToString();
                        dr[6] = da.Rows[i][6].ToString();
                        dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                    }
                    dt.Rows.Add(dr);
                }

                if (Double.Parse(temp.Rows[0][10].ToString()) != 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[1] = "Chiết khấu";
                    if (Double.Parse(temp.Rows[0][10].ToString()) > 0)
                        dr[7] = Math.Round(0 - Double.Parse(temp.Rows[0][10].ToString()), 0);
                    else
                        dr[7] = Math.Round(Double.Parse(temp.Rows[0][10].ToString()), 0);
                    dt.Rows.Add(dr);
                }
                

                DataTable da1 = new DataTable();
                try
                {
                    da1 = gen.GetTable("select Description,CustomField1,Quantity from INOutwardLPGQTDetail where RefID='" + congty + "' order by SortOrder");
                }
                catch { }

                for (int i = 0; i < da1.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = (da.Rows.Count + i + 1).ToString();
                    dr[1] = da1.Rows[i][0].ToString();
                    dr[2] = da1.Rows[i][1].ToString();
                    dr[3] = da1.Rows[i][2].ToString();
                    dr[8] = "Khuyến mãi";
                    dt.Rows.Add(dr);
                }

                if (tsbt == "pxkbienbanvatxacnhan" || tsbt == "pxkbienbanvatxacnhanddh")
                {
                    rpbienbangiaonhandaydu thuchi = new rpbienbangiaonhandaydu();
                    thuchi.gettieude(nguoinop, diachi, lydo, ngaychungtu, sophieu, kho, phuongtien, phieu, sotienchu, hoten, daidien, sdt, giaohang, sodienthoai, taixe, cmnd, sdttaixe);
                    thuchi.BindData(dt);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else
                {
                    rpbienbangiaonhantheosoluong thuchi = new rpbienbangiaonhantheosoluong();
                    thuchi.gettieude(nguoinop, diachi, lydo, ngaychungtu, sophieu, kho, phuongtien, phieu, sotienchu, hoten, daidien, sdt, giaohang, sodienthoai, taixe, cmnd, sdttaixe);
                    thuchi.BindData(dt);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
            }

            else if (tsbt == "pxkbienbanvattrongluong" || tsbt == "pxkbienbanvattrongluongddh")
            {
                this.Text = "Biên bản giao nhận hàng";
                if (tsbt == "pxkbienbanvattrongluong")
                    temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,a.Contactname,RefDate,RefNo,c.StockID,OriginalRefNo,ShippingNo,FullName,TotalFreightAmount,TotalAmount-TotalFreightAmount/1.1+TotalAmountOC,Tax,b.AccountingObjectName,CustomField6,d.MobilePhone,a.DocumentIncluded,Taixe,CMND,Dienthoai  from INOutward a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                else if (tsbt == "pxkbienbanvattrongluongddh")
                    temp = gen.GetTable("select b.AccountingObjectCode,a.AccountingObjectName,a.AccountingObjectAddress,a.Contactname,RefDate,RefNo,c.StockID,OriginalRefNo,ShippingNo,FullName,0,TotalAmount+TotalAmountOC,Tax,b.AccountingObjectName,a.ReceiveMethod,d.MobilePhone,a.DocumentIncluded,Taixe,CMND,Dienthoai  from DDH a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.InStockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][13].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                string daidien = temp.Rows[0][16].ToString();
                string giaohang = temp.Rows[0][14].ToString();
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                string sdt = temp.Rows[0][7].ToString();
                sodienthoai = temp.Rows[0][15].ToString();

                string taixe = temp.Rows[0][17].ToString();
                string cmnd = temp.Rows[0][18].ToString();
                string sdttaixe = temp.Rows[0][19].ToString();

                phieu = "BIÊN BẢN GIAO NHẬN HÀNG";

                string sotienchu = doi.ChuyenSo(Math.Round(Double.Parse(temp.Rows[0][11].ToString()), 0).ToString());

                if (tsbt == "pxkbienbanvattrongluong")
                    da = gen.GetTable("select InventoryItemName,b.Unit,Quantity,b.ConvertUnit,QuantityConvert,a.AmountOC,a.UnitPriceOC,a.UnitPriceConvert,a.CustomField3 from INOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else if (tsbt == "pxkbienbanvattrongluongddh")
                    da = gen.GetTable("select InventoryItemName,b.Unit,QuantityExits,b.ConvertUnit,QuantityConvertExits,a.AmountOC,a.UnitPriceOC,a.UnitPriceConvert from DDHDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = (i + 1).ToString();
                    dr[1] = da.Rows[i][0].ToString();
                    dr[2] = da.Rows[i][3].ToString();
                    try
                    {
                        dr[8] = da.Rows[i][8].ToString();
                    }
                    catch { }
                    if (Double.Parse(da.Rows[i][2].ToString()) != 0)
                        dr[3] = da.Rows[i][2].ToString();
                    dr[5] = da.Rows[i][4].ToString();
                    dr[6] = da.Rows[i][6].ToString();
                    dr[7] = Math.Round(Double.Parse(da.Rows[i][5].ToString()), 0);
                    dt.Rows.Add(dr);
                }

                if (Double.Parse(temp.Rows[0][10].ToString()) != 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[1] = "Chiết khấu";
                    if (Double.Parse(temp.Rows[0][10].ToString()) > 0)
                        dr[7] = Math.Round(0 - Double.Parse(temp.Rows[0][10].ToString()), 0);
                    else
                        dr[7] = Math.Round(Double.Parse(temp.Rows[0][10].ToString()), 0);
                    dt.Rows.Add(dr);
                }

                DataTable da1 = new DataTable();
                try
                {
                    da1 = gen.GetTable("select Description,CustomField1,Quantity from INOutwardLPGQTDetail where RefID='" + congty + "' order by SortOrder");
                }
                catch { }

                for (int i = 0; i < da1.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = (da.Rows.Count + i + 1).ToString();
                    dr[1] = da1.Rows[i][0].ToString();
                    dr[2] = da1.Rows[i][1].ToString();
                    dr[3] = da1.Rows[i][2].ToString();
                    dr[8] = "Khuyến mãi";
                    dt.Rows.Add(dr);
                }

                rpbienbangiaonhancotrongluong thuchi = new rpbienbangiaonhancotrongluong();
                
                thuchi.gettieude(nguoinop, diachi, lydo, ngaychungtu, sophieu, kho, phuongtien, phieu, sotienchu, hoten, daidien, sdt, giaohang, sodienthoai,taixe,cmnd,sdttaixe);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pnklpg")
            {
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,a.JournalMemo,a.RefDate,a.RefNo,StockCode,StockName,a.ShippingNo,FullName,RefSUID,e.RefNo  from INInward a, AccountingObject b,Stock c,MSC_User d,INInwardSU e  where a.RefSUID=e.RefID and a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU NHẬP KHO LPG";
                thucte = "Thực nhập";
                phieuvo = temp.Rows[0][10].ToString();
                sophieuvo = temp.Rows[0][11].ToString();

                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit from INInwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < 8; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][3].ToString();
                        dr[3] = da.Rows[i][0].ToString();
                        dr[4] = "1";
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr[4] = "1";
                        dt.Rows.Add(dr);
                    }
                }

                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit from INInwardSUDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieuvo + "' order by SortOrder");
                for (int i = 0; i < 8; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][3].ToString();
                        dr[3] = da.Rows[i][0].ToString();
                        dr[4] = "2";
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr[4] = "2";
                        dt.Rows.Add(dr);
                    }
                }

                rpnhapxuatlpg thuchi = new rpnhapxuatlpg();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, "Nhà cung cấp:", phuongtien, thucte, hoten, sophieuvo, "PHIẾU NHẬP VỎ LPG");
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pxklpg")
            {
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,a.JournalMemo,a.RefDate,a.RefNo,StockCode,StockName,a.ShippingNo,FullName,RefSUID,e.RefNo  from INOutward a, AccountingObject b,Stock c,MSC_User d,INOutwardSU e  where a.RefSUID=e.RefID and a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU XUẤT KHO LPG";
                thucte = "Thực xuất";
                phieuvo = temp.Rows[0][10].ToString();
                sophieuvo = temp.Rows[0][11].ToString();

                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit from INOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < 8; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][3].ToString();
                        dr[3] = da.Rows[i][0].ToString();
                        dr[4] = "1";
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr[4] = "1";
                        dt.Rows.Add(dr);
                    }
                }

                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit from INOutwardSUDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieuvo + "' order by SortOrder");
                for (int i = 0; i < 8; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][3].ToString();
                        dr[3] = da.Rows[i][0].ToString();
                        dr[4] = "2";
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr[4] = "2";
                        dt.Rows.Add(dr);
                    }
                }

                rpnhapxuatlpg thuchi = new rpnhapxuatlpg();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, "Tên khách hàng:", phuongtien, thucte, hoten, sophieuvo, "PHIẾU XUẤT VỎ LPG");
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pnkvo" || tsbt=="pnkvosl")
            {
                this.Text = "Phiếu nhập vỏ";
                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,a.Amount,InventoryItemCode from INInwardSUDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' and (DebitAccount='003' or DebitAccount='1563') order by SortOrder");
                for (int i = 0; i < 10; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][3].ToString();
                        dr[3] = da.Rows[i][0].ToString();
                        dr[4] = da.Rows[i][7].ToString();
                        if (tsbt == "pnkvo")
                        {                            
                            dr[6] = da.Rows[i][5].ToString();
                            dr[7] = da.Rows[i][6].ToString();
                        }
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }
                //temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName  from INInwardSU a, AccountingObject b,Stock c,MSC_User d where a.UserID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName,TotalAmount,DocumentIncluded  from INInwardSU a, AccountingObject b,Stock c,MSC_User d where a.UserID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU NHẬP VẬT TƯ";
               
                string sotienchu = doi.ChuyenSo(Double.Parse(temp.Rows[0][10].ToString().Replace("-","")).ToString());
                
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                string chungtugoc = temp.Rows[0][11].ToString();

                rpnhapxuatvo thuchi = new rpnhapxuatvo();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, sotienchu, chungtugoc, hoten, "n", phuongtien);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt=="hdmhvosl")
            {
                this.Text = "Phiếu nhập vỏ";
                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,a.ToTalAmount,InventoryItemCode from PUInvoiceINInward a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and PUInvoiceID='" + role + "' order by SortOrder");
                for (int i = 0; i < 10; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][3].ToString();
                        dr[3] = da.Rows[i][0].ToString();
                        dr[4] = da.Rows[i][7].ToString();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,PUJournalMemo,PURefDate,RefNo,StockCode,StockName,NULL,FullName,TotalAmount,InvNo  from PUInvoice a, AccountingObject b,Stock c,MSC_User d where a.UserID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.BranchID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU NHẬP VẬT TƯ";
                string sotienchu = doi.ChuyenSo(Double.Parse(temp.Rows[0][10].ToString()).ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                string chungtugoc = temp.Rows[0][11].ToString();

                rpnhapxuatvo thuchi = new rpnhapxuatvo();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, sotienchu, chungtugoc, hoten, "n", phuongtien);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pxkvo" || tsbt=="pxkvosl")
            {
                this.Text = "Phiếu xuất vỏ";
                da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,a.Amount,InventoryItemCode from INOutwardSUDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' and (CreditAccount='003' or CreditAccount='1563') order by SortOrder");
                for (int i = 0; i < 10; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][3].ToString();
                        dr[3] = da.Rows[i][0].ToString();
                        dr[4] = da.Rows[i][7].ToString();
                        if (tsbt == "pxkvo")
                        {
                            dr[6] = da.Rows[i][5].ToString();
                            dr[7] = da.Rows[i][6].ToString();
                        }
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,ShippingNo,FullName,TotalAmount,DocumentIncluded  from INOutwardSU a, AccountingObject b,Stock c,MSC_User d where a.UserID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                phuongtien = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                phieu = "PHIẾU XUẤT VẬT TƯ";
                string sotienchu = doi.ChuyenSo(Double.Parse(temp.Rows[0][10].ToString()).ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                string chungtugoc = temp.Rows[0][11].ToString();

                rpnhapxuatvo thuchi = new rpnhapxuatvo();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, sotienchu, chungtugoc, hoten, "x", phuongtien);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pndc" || tsbt == "pxdc" || tsbt == "pnht" || tsbt == "pxht" || tsbt == "pnhkm" || tsbt == "pxhkm")
            {
                this.Text = "Phiếu nhập xuất";
                if (tsbt == "pndc")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.ConvertUnit,Amount,a.UnitPrice,DebitAccount,CreditAccount from INAdjustmentDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else if (tsbt == "pxdc")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.ConvertUnit,Amount,a.UnitPrice,DebitAccount,CreditAccount from OUTAdjustmentDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else if (tsbt == "pnht")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.ConvertUnit,Amount,a.UnitPrice,DebitAccount,CreditAccount from INSurplusDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else if (tsbt == "pxht")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.ConvertUnit,Amount,a.UnitPrice,DebitAccount,CreditAccount from OUTdeficitDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else if (tsbt == "pnhkm")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.ConvertUnit,Amount,a.UnitPrice,DebitAccount,CreditAccount from INInwardFreeDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else if (tsbt == "pxhkm")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.ConvertUnit,Amount,a.UnitPrice,DebitAccount,CreditAccount from INOutwardFreeDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < 9; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][3].ToString();
                        if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                            dr[3] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                            dr[5] = da.Rows[i][1].ToString();
                        if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                            dr[6] = da.Rows[i][5].ToString();
                        if (Double.Parse(da.Rows[i][4].ToString()) != 0)
                            dr[7] = da.Rows[i][4].ToString();
                        no = da.Rows[i][6].ToString();
                        co = da.Rows[i][7].ToString();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }

                if (tsbt == "pndc")
                    temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,InvDate,FullName,InvNo,TotalAmount  from INAdjustment a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                else if (tsbt == "pxdc")
                    temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,InvDate,FullName,InvNo,TotalAmount  from OUTAdjustment a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                else if (tsbt == "pnht")
                    temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,InvDate,FullName,InvNo,TotalAmount  from INSurplus a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                else if (tsbt == "pxht")
                    temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,InvDate,FullName,InvNo,TotalAmount  from OUTdeficit a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                else if (tsbt == "pnhkm")
                    temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,InvDate,FullName,InvNo,TotalAmount  from INInwardFree a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                else if (tsbt == "pxhkm")
                    temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,Address,JournalMemo,RefDate,RefNo,StockCode,StockName,InvDate,FullName,InvNo,TotalAmount  from INOutwardFree a, AccountingObject b,Stock c,MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                ngaychungtu = temp.Rows[0][4].ToString();
                sophieu = temp.Rows[0][5].ToString();
                kho = temp.Rows[0][6].ToString() + " - " + temp.Rows[0][7].ToString();
                string ngayhoadon = temp.Rows[0][8].ToString();
                hoten = temp.Rows[0][9].ToString();
                if (tsbt == "pndc")
                    phieu = "PHIẾU NHẬP ĐIỀU CHỈNH";
                else if (tsbt == "pxdc")
                    phieu = "PHIẾU XUẤT ĐIỀU CHỈNH";
                else if (tsbt == "pnht")
                    phieu = "PHIẾU NHẬP HÀNG";
                else if (tsbt == "pxht")
                {
                    if (noibo == false)
                        phieu = "PHIẾU XUẤT HÀNG";
                    else
                        phieu = "PHIẾU XUẤT HÀNG      TIÊU DÙNG NỘI BỘ";
                }
                else if (tsbt == "pnhkm")
                    phieu = "PHIẾU NHẬP KHUYẾN MÃI";
                else if (tsbt == "pxhkm")
                    phieu = "PHIẾU XUẤT KHUYẾN MÃI";
                string hoadon = temp.Rows[0][10].ToString();

                string sotienchu = doi.ChuyenSo(Double.Parse(temp.Rows[0][11].ToString()).ToString().Replace("-",""));
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                if (Double.Parse(temp.Rows[0][11].ToString()) == 0)
                    sotienchu = "Không đồng.";
                else if (Double.Parse(temp.Rows[0][11].ToString()) < 0)
                    sotienchu = "(" + sotienchu.Replace(".","") + ").";

                rpnhapxuatdc thuchi = new rpnhapxuatdc();
                thuchi.gettieude(ngaychungtu, phieu, sophieu, kho, congty, nguoinop, diachi, lydo, sotienchu, hoten, no, co, hoadon, ngayhoadon);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "pxhtphieu" || tsbt == "tsbthdmhkpnphieu" || tsbt == "tsbthdbhkpnphieu" || tsbt == "tsbtpnkttphieu" || tsbt == "tsbtddhphieu" || tsbt == "tsbtddhphieusl")
            {
                this.Text = "Phiếu đặt hàng";
                rpphieudathang thuchi = new rpphieudathang();
                thuchi.gettieude(role, tsbt);
                thuchi.BindData(role, tsbt, kho);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtddhphieuvina")
            {
                 this.Text = "Phiếu đặt hàng";
                 if (kho == "0")
                 {
                     rpphieudathangvina thuchi = new rpphieudathangvina();
                     thuchi.gettieude(role, tsbt);
                     thuchi.BindData(role, tsbt);
                     printControl1.PrintingSystem = thuchi.PrintingSystem;
                     thuchi.CreateDocument();
                 }
                 else if (kho == "1")
                 {
                     rpphieudathangvinaduongbo thuchi = new rpphieudathangvinaduongbo();
                     thuchi.gettieude(role, tsbt);
                     thuchi.BindData(role, tsbt);
                     printControl1.PrintingSystem = thuchi.PrintingSystem;
                     thuchi.CreateDocument();
                 }
                 else if (kho == "2")
                 {
                     rpphieudathangvinagiaygioithieu thuchi = new rpphieudathangvinagiaygioithieu();
                     thuchi.gettieude(role, tsbt);
                     thuchi.BindData(role, tsbt);
                     printControl1.PrintingSystem = thuchi.PrintingSystem;
                     thuchi.CreateDocument();
                 }
            }
            else if (tsbt == "tsbtddhphieumn")
            {
                this.Text = "Phiếu đặt hàng";
                rpdondathangmn thuchi = new rpdondathangmn();
                thuchi.gettieude(role, tsbt, kho, this);
                thuchi.BindData(role, tsbt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "pxhtbienban" || tsbt == "tsbthdmhkpnbienban" || tsbt == "tsbthdbhkpnbienban" || tsbt == "tsbtpnkttbienban" || tsbt == "tsbthddhbienbanhp")
            {
                this.Text = "Biên bản giao nhận hàng hóa";
                rpbienbangiaonhanhanghoa thuchi = new rpbienbangiaonhanhanghoa();
                thuchi.BindData(role, tsbt);
                thuchi.gettieude(role, kho, tsbt, this);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "hdmh")
            {
                this.Text = "Hóa đơn mua hàng";
                temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,AccountingObjectAddress,PURefDate,CABARefDate,FullName,TotalAmount+TotalFreightAmount+TotalVatAmount-TotalFreightAmountOC,Tax,COALESCE(TotalFreightAmount,0),a.BranchID,RefNo,InvNo,TotalVatAmount,PUJournalMemo,a.CustomField4,COALESCE(TotalFreightAmountOC,0)  from PUInvoice a, AccountingObject b, MSC_User d where a.UserID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + "(" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                ngaychungtu = temp.Rows[0][3].ToString();
                string ngayhd = temp.Rows[0][4].ToString();
                hoten = temp.Rows[0][5].ToString();
                Double tongtien = Double.Parse(temp.Rows[0][6].ToString());
                string sotienchu = null;
                try
                {
                    sotienchu = doi.ChuyenSo(tongtien.ToString());
                }
                catch
                {
                    sotienchu = doi.ChuyenSo(tongtien.ToString().Replace("-", ""));
                }
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                if (tongtien < 0)
                    sotienchu = "(" + sotienchu + ")";
                Double thue = Double.Parse(temp.Rows[0][7].ToString());
                Double chiphi = Double.Parse(temp.Rows[0][8].ToString());

                Double chietkhau = Double.Parse(temp.Rows[0][15].ToString());

                string lydothat = temp.Rows[0][13].ToString();
                sophieu = temp.Rows[0][10].ToString();
                string shd = temp.Rows[0][11].ToString();
                Double tienthue = Double.Parse(temp.Rows[0][12].ToString());
                kho = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + temp.Rows[0][9].ToString() + "'");

                string phieunhap = null;
                da = gen.GetTable("select  InventoryItemName,Quantity,QuantityConvert,a.UnitPrice,TotalAmount,INInwardID,Unit from PUInvoiceINInward a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and PUInvoiceID='" + role + "' order by SortOrder ");
                int dem = 10;
                if (da.Rows.Count > 10)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][0].ToString();
                        dr[2] = da.Rows[i][6].ToString();
                        if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                            dr[3] = da.Rows[i][1].ToString();
                        if (Double.Parse(da.Rows[i][2].ToString()) != 0)
                            dr[5] = da.Rows[i][2].ToString();
                        if (Double.Parse(da.Rows[i][3].ToString()) != 0)
                            dr[6] = da.Rows[i][3].ToString();
                        if (Double.Parse(da.Rows[i][4].ToString()) != 0)
                            dr[7] = da.Rows[i][4].ToString();
                        dt.Rows.Add(dr);
                        phieunhap = da.Rows[i][5].ToString();
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }
                string ptvc = gen.GetString("select ShippingNo from INInward where RefID='" + phieunhap + "'");
                rpnhapmua thuchi = new rpnhapmua();
                thuchi.gettieude(ngaychungtu, "PHIẾU NHẬP HÀNG", sophieu, kho, tongtien, nguoinop, diachi, ptvc, sotienchu, hoten, thue.ToString(), chiphi, shd, ngayhd, tienthue, lydothat, chietkhau);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "hdbh" || tsbt == "hdbhbangke" || tsbt == "hdbhtsl" || tsbt == "hdbhksl" || tsbt == "tsbthdxhgb" || tsbt == "hdbhdgsl" || tsbt == "hdbhpnht")
            {
                this.Text = "Hóa đơn bán hàng";
                string ghichu = "";
                if (tsbt == "tsbthdxhgb")
                {
                    temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,AccountingObjectAddress,CompanyTaxCode,CABARefDate,FullName,PayNo,TotalAmount-TotalFreightAmount,TotalVatAmount,Tax,COALESCE(TotalDiscountAmount,0),DocumentIncluded,CABAContactName,Reconciled,a.BranchID,RefNo,a.CustomField5  from SSInvoiceBranch a, AccountingObject b, MSC_User d where a.UserID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.RefID='" + role + "'");
                    nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                }
                else if (tsbt == "hdbhpnht")
                {
                    temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,CompanyTaxCode,RefDate,FullName,'',TotalAmount,Round(TotalAmount*COALESCE(Tax,0)/100,0),Tax,0,DocumentIncluded,'','',a.StockID,RefNo,''  from OUTdeficit a, AccountingObject b, MSC_User d where a.EmployeeID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.RefID='" + role + "'");
                    nguoinop = temp.Rows[0][1].ToString();
                }
                else
                {
                    temp = gen.GetTable("select AccountingObjectCode,a.AccountingObjectName,AccountingObjectAddress,CompanyTaxCode,CABARefDate,FullName,PayNo,TotalAmount-TotalFreightAmount+TotalCost,TotalVatAmount,Tax,TotalDiscountAmount,DocumentIncluded,CABAContactName,Reconciled,a.BranchID,RefNo,a.CustomField5,a.CustomField4  from SSInvoice a, AccountingObject b, MSC_User d where a.UserID=d.UserID and a.AccountingObjectID=b.AccountingObjectID and a.RefID='" + role + "'");
                    nguoinop = temp.Rows[0][12].ToString();
                    ghichu = temp.Rows[0][17].ToString();
                }
                string makhachhang = "(" + temp.Rows[0][0].ToString() + ")";
                kho = temp.Rows[0][1].ToString();
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString(); //mst
                if (lydo == "")
                    lydo = temp.Rows[0][16].ToString();

                ngaychungtu = temp.Rows[0][4].ToString();
                hoten = temp.Rows[0][5].ToString();
                phuongtien = temp.Rows[0][6].ToString();
                Double khautru = Double.Parse(temp.Rows[0][10].ToString());
                Double tongtruockhautru = Double.Parse(temp.Rows[0][7].ToString());
                Double tongtienhang = Double.Parse(temp.Rows[0][7].ToString()) - khautru;
                Double tienthue = Double.Parse(temp.Rows[0][8].ToString());
                string lydokhautru = temp.Rows[0][11].ToString();
                Double tongtien = tongtienhang + tienthue;
                string sotienchu = doi.ChuyenSo(tongtien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                if (tongtien == 0)
                    sotienchu = "Không đồng.";
                Double thue = 0;
                try
                {
                    thue = Double.Parse(temp.Rows[0][9].ToString());
                }
                catch { thue = -100; }
                if (temp.Rows[0][13].ToString() == "True")
                    co = "1";
                phieuvo = temp.Rows[0][14].ToString();
                string phieu = temp.Rows[0][15].ToString();
                if (tsbt == "tsbthdxhgb")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,Amount from SSInvoiceBranchDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                 else if (tsbt == "hdbhpnht")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,Amount from OUTdeficitDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,Amount from SSInvoiceDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1800506679" || gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004" || gen.GetString("select Top 1 CompanyTaxCode from Center") == "6300285815" || gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
                {
                    if (tsbt == "hdbhbangke")
                    {
                        DataRow dr1 = dt.NewRow();
                        dr1[0] = "1";
                        dr1[1] = ghichu;
                        dr1[7] = tongtruockhautru;
                        dt.Rows.Add(dr1);

                        for (int i = 1; i < 11; i++)
                        {
                            if (khautru != 0)
                            {
                                DataRow dr = dt.NewRow();
                                dr[0] = (i + 1).ToString();
                                dr[1] = lydokhautru;
                                dr[7] = khautru;
                                khautru = 0;
                                dt.Rows.Add(dr);
                            }
                            else
                            {
                                DataRow dr = dt.NewRow();
                                dt.Rows.Add(dr);
                            }
                        }
                        ghichu = tsbt;
                    }
                    else
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            if (i < da.Rows.Count)
                            {
                                DataRow dr = dt.NewRow();
                                dr[0] = (i + 1).ToString();
                                dr[1] = da.Rows[i][2].ToString().Replace(" Hương Vị", "").Replace(" HV", "");

                                if (tsbt == "hdbh" || tsbt == "tsbthdxhgb" || tsbt == "hdbhpnht")
                                {
                                    dr[2] = da.Rows[i][4].ToString();
                                    if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                                    {
                                        if (Double.Parse(da.Rows[i][1].ToString()) < 10)
                                            dr[4] = String.Format("{0:0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                        else
                                            dr[4] = String.Format("{0:0,0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                    }
                                    if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                                        dr[6] = da.Rows[i][5].ToString();
                                }
                                else if (tsbt == "hdbhtsl")
                                {
                                    dr[2] = da.Rows[i][3].ToString();
                                    if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                                    {
                                        dr[4] = String.Format("{0:n0}", Double.Parse(da.Rows[i][0].ToString()));
                                        if (Double.Parse(da.Rows[i][6].ToString()) != 0)
                                        {
                                            Double DG = Math.Round(Double.Parse(da.Rows[i][6].ToString()) / Double.Parse(da.Rows[i][0].ToString()), 2);
                                            dr[6] = DG;
                                        }
                                    }
                                    else
                                    {
                                        if (Double.Parse(da.Rows[i][1].ToString()) < 10)
                                            dr[4] = String.Format("{0:0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                        else
                                            dr[4] = String.Format("{0:0,0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                        if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                                            dr[6] = da.Rows[i][5].ToString();
                                    }
                                }
                                else if (tsbt == "hdbhdgsl")
                                {
                                    dr[2] = da.Rows[i][3].ToString();
                                    if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                                    {
                                        if (Double.Parse(da.Rows[i][1].ToString()) < 10)
                                            dr[4] = String.Format("{0:0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                        else
                                            dr[4] = String.Format("{0:0,0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                    }

                                    if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                                    {
                                        dr[3] = Math.Round(Double.Parse(da.Rows[i][0].ToString()), 0).ToString();
                                        Double DG = Math.Round(Double.Parse(da.Rows[i][6].ToString()) / Double.Parse(da.Rows[i][0].ToString()), 2);
                                        dr[6] = DG;
                                    }
                                    else
                                        dr[6] = da.Rows[i][5].ToString();
                                }
                                else
                                {
                                    dr[2] = da.Rows[i][4].ToString();
                                    if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                                    {
                                        if (Double.Parse(da.Rows[i][1].ToString()) < 10)
                                            dr[4] = String.Format("{0:0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                        else
                                            dr[4] = String.Format("{0:0,0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                    }
                                    if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                                        dr[6] = da.Rows[i][5].ToString();
                                    if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                                        dr[3] = Math.Round(Double.Parse(da.Rows[i][0].ToString()), 0).ToString();
                                }

                                if (Double.Parse(da.Rows[i][6].ToString()) != 0)
                                    dr[7] = da.Rows[i][6].ToString();

                                dt.Rows.Add(dr);
                            }
                            else if (i == da.Rows.Count && khautru != 0)
                            {
                                DataRow dr = dt.NewRow();
                                dr[0] = (i + 1).ToString();
                                dr[1] = lydokhautru;
                                dr[7] = khautru;
                                dt.Rows.Add(dr);
                            }
                            else
                            {
                                DataRow dr = dt.NewRow();
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                    if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1800506679")
                    {
                        rphoadonbanhang thuchi = new rphoadonbanhang();
                        thuchi.gettieude(ngaychungtu, lydo, nguoinop, kho, diachi, phuongtien, tongtienhang, tienthue, thue, tongtien, hoten, sotienchu, co, phieuvo, phieu, makhachhang, ghichu);
                        thuchi.BindData(dt);
                        printControl1.PrintingSystem = thuchi.PrintingSystem;
                        thuchi.CreateDocument();
                    }
                    else if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
                    {
                        rphoadonbanhanghangtieudung thuchi = new rphoadonbanhanghangtieudung();
                        thuchi.gettieude(ngaychungtu, lydo, nguoinop, kho, diachi, phuongtien, tongtienhang, tienthue, thue, tongtien, hoten, sotienchu, co, phieuvo, phieu, makhachhang, ghichu,congty);
                        thuchi.BindData(dt);
                        printControl1.PrintingSystem = thuchi.PrintingSystem;
                        thuchi.CreateDocument();
                    }
                    else
                    {
                        rphoadonbanhangthienngan thuchi = new rphoadonbanhangthienngan();
                        thuchi.gettieude(ngaychungtu, lydo, nguoinop, kho, diachi, phuongtien, tongtienhang, tienthue, thue, tongtien, hoten, sotienchu, co, phieuvo, phieu, makhachhang, ghichu);
                        thuchi.BindData(dt);
                        printControl1.PrintingSystem = thuchi.PrintingSystem;
                        thuchi.CreateDocument();
                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (i < da.Rows.Count)
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = (i + 1).ToString();
                            dr[1] = da.Rows[i][2].ToString();

                            if (tsbt == "hdbh" || tsbt == "tsbthdxhgb")
                            {
                                dr[2] = da.Rows[i][4].ToString();
                                if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                                {
                                    if (Double.Parse(da.Rows[i][1].ToString()) < 10)
                                        dr[4] = String.Format("{0:0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                    else
                                        dr[4] = String.Format("{0:0,0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                }
                                if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                                    dr[6] = da.Rows[i][5].ToString();
                            }
                            else if (tsbt == "hdbhtsl")
                            {
                                dr[2] = da.Rows[i][3].ToString();
                                if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                                {
                                    dr[4] = String.Format("{0:0}", Double.Parse(da.Rows[i][0].ToString()));
                                    if (Double.Parse(da.Rows[i][6].ToString()) != 0)
                                    {
                                        Double DG = Math.Round(Double.Parse(da.Rows[i][6].ToString()) / Double.Parse(da.Rows[i][0].ToString()), 2);
                                        dr[6] = DG;
                                    }
                                }
                                else
                                {
                                    if (Double.Parse(da.Rows[i][1].ToString()) < 10)
                                        dr[4] = String.Format("{0:0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                    else
                                        dr[4] = String.Format("{0:0,0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                    if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                                        dr[6] = da.Rows[i][5].ToString();
                                }
                            }
                            else
                            {
                                dr[2] = da.Rows[i][4].ToString();
                                if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                                {
                                    if (Double.Parse(da.Rows[i][1].ToString()) < 10)
                                        dr[4] = String.Format("{0:0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                    else
                                        dr[4] = String.Format("{0:0,0.00}", Double.Parse(da.Rows[i][1].ToString()));
                                }
                                if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                                    dr[6] = da.Rows[i][5].ToString();
                                if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                                    dr[3] = Math.Round(Double.Parse(da.Rows[i][0].ToString()), 0).ToString();
                            }

                            if (Double.Parse(da.Rows[i][6].ToString()) != 0)
                                dr[7] = da.Rows[i][6].ToString();

                            dt.Rows.Add(dr);
                        }
                        else if (i == da.Rows.Count && khautru != 0)
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = (i + 1).ToString();
                            dr[1] = lydokhautru;
                            dr[7] = khautru;
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dt.Rows.Add(dr);
                        }
                    }
                    rphoadonbanhangthienan thuchi = new rphoadonbanhangthienan();
                    thuchi.gettieude(ngaychungtu, lydo, nguoinop, kho, diachi, phuongtien, tongtienhang, tienthue, thue, tongtien, hoten, sotienchu, co, phieuvo, phieu, makhachhang);
                    thuchi.BindData(dt);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
            }
            else if (tsbt == "tsbthdbhbanhangchitiet")
            {
                this.Text = "Bảng kê chi tiết bán hàng";
                rpbangkehoadonchitiet thuchi = new rpbangkehoadonchitiet();
                thuchi.gettieude();
                thuchi.BindData(dem, hoadon);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "bchtd")
            {
                this.Text = "Báo cáo hàng tiêu dùng";
                rpbaocaohangtieudung thuchi = new rpbaocaohangtieudung();
                thuchi.gettieude(ngaychungtu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "bccnhtd")
            {
                this.Text = "Báo cáo công nợ ngành hàng tiêu dùng";
                rpbaocaocongnohangtieudung thuchi = new rpbaocaocongnohangtieudung();
                thuchi.gettieude(ngaychungtu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "bccnhtdbk")
            {
                this.Text = "Báo cáo công nợ ngành hàng tiêu dùng ngày";
                rpbaocaocongnohangtieudung thuchi = new rpbaocaocongnohangtieudung();
                thuchi.gettieudebk(ngaychungtu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "pck" || tsbt == "pxhgb" || tsbt == "lddnb" || tsbt=="lddgb")
            {
                this.Text = "Phiếu nhập xuất chuyển kho";
                if (tsbt == "pck" || tsbt=="lddnb")
                {
                    temp = gen.GetTable("select RefDate,Contactname,ShippingNo,OutwardStockID,InwardStockID,TotalAmount,JournalMemo,RefNo from INTransfer where RefID='" + role + "'");
                }
                else
                {
                    temp = gen.GetTable("select RefDate,Contactname,ShippingNo,OutwardStockID,InwardStockID,TotalAmount,JournalMemo,RefNo from INTransferBranch where RefID='" + role + "'");
                }
                ngaychungtu = temp.Rows[0][0].ToString();
                nguoinop = temp.Rows[0][1].ToString();
                phuongtien = temp.Rows[0][2].ToString();
                kho = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + temp.Rows[0][3].ToString() + "'");
                phieuvo = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + temp.Rows[0][4].ToString() + "'");
                Double tongtienhang = Double.Parse(temp.Rows[0][5].ToString());
                lydo = temp.Rows[0][6].ToString();
                phieu = temp.Rows[0][7].ToString();

                if (tsbt == "pck" || tsbt=="lddnb")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,Amount from INTransferDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,Amount from INTransferBranchDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");

                for (int i = 0; i < 10; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][4].ToString();
                        if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                            dr[5] = da.Rows[i][1].ToString();
                        if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                            dr[6] = da.Rows[i][5].ToString();
                        if (Double.Parse(da.Rows[i][6].ToString()) != 0)
                            dr[7] = da.Rows[i][6].ToString();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }
                if (tsbt == "lddnb"||tsbt=="lddgb")
                {
                    rplenhdieudong thuchi = new rplenhdieudong();
                    thuchi.gettieude(ngaychungtu, nguoinop, phuongtien, kho, phieuvo, tongtienhang, lydo, phieu);
                    thuchi.BindData(dt);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else
                {
                    rpphieuxuatkhokiemvanchuyen thuchi = new rpphieuxuatkhokiemvanchuyen();
                    thuchi.gettieude(ngaychungtu, nguoinop, phuongtien, kho, phieuvo, tongtienhang, lydo, phieu);
                    thuchi.BindData(dt);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
            }

            else if (tsbt == "pckpx" || tsbt == "pxhgbpx" || tsbt == "tsbtpncknb" || tsbt == "tsbtpnhgb" || tsbt == "pckvpx" || tsbt == "tsbtpncknbvlpg")
            {
                this.Text = "Phiếu nhập xuất chuyển kho";
                if (tsbt == "pckpx" || tsbt == "tsbtpncknb")
                    temp = gen.GetTable("select RefDate,b.AccountingObjectName+' ('+AccountingObjectCode+')',ShippingNo,OutwardStockID,InwardStockID,TotalAmount,JournalMemo,RefNo,b.Address,case when RefSUID is NULL then RefNoIn else (select RefNO from DDH where RefID=RefSUID) end from INTransfer a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                else if (tsbt == "pckvpx" || tsbt == "tsbtpncknbvlpg")
                    temp = gen.GetTable("select RefDate,b.AccountingObjectName+' ('+AccountingObjectCode+')',ShippingNo,OutwardStockID,InwardStockID,TotalAmount,JournalMemo,RefNo,b.Address,RefNoIn from INTransferSU a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                else
                    temp = gen.GetTable("select RefDate,b.AccountingObjectName+' ('+AccountingObjectCode+')',ShippingNo,OutwardStockID,InwardStockID,TotalAmount,JournalMemo,RefNo,b.Address,case when RefSUID is NULL then RefNoIn else (select RefNO from DDH where RefID=RefSUID) end from INTransferBranch a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                ngaychungtu = temp.Rows[0][0].ToString();
                nguoinop = temp.Rows[0][1].ToString();
                phuongtien = temp.Rows[0][2].ToString();
                kho = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + temp.Rows[0][3].ToString() + "'");
                phieuvo = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + temp.Rows[0][4].ToString() + "'");
                Double tongtienhang = Double.Parse(temp.Rows[0][5].ToString());
                lydo = temp.Rows[0][6].ToString();
                phieu = temp.Rows[0][7].ToString();
                string khotren = kho, phieutren = phieu;
                string tenphieu = null;
                if (tsbt == "pckpx")
                    tenphieu = "XUẤT CHUYỂN KHO NỘI BỘ";
                else if (tsbt == "pckvpx")
                    tenphieu = "XUẤT CHUYỂN KHO VỎ NỘI BỘ";
                else if (tsbt == "tsbtpncknb")
                    tenphieu = "NHẬP CHUYỂN KHO NỘI BỘ";
                else if (tsbt == "tsbtpncknbvlpg")
                    tenphieu = "NHẬP CHUYỂN KHO VỎ NỘI BỘ";
                else if (tsbt == "pxhgbpx")
                    tenphieu = "XUẤT HÀNG GỬI BÁN";
                else if (tsbt == "tsbtpnhgb")
                    tenphieu = "NHẬP HÀNG GỬI BÁN";
                if (tsbt == "tsbtpncknb" || tsbt == "tsbtpnhgb")
                {
                    khotren = phieuvo;
                    phieutren = temp.Rows[0][9].ToString();
                }
                else if (tsbt == "pxhgbpx" || tsbt == "pckpx")
                    phieu = temp.Rows[0][9].ToString();

                string sotienchu = doi.ChuyenSo(Double.Parse(tongtienhang.ToString()).ToString());
                diachi = temp.Rows[0][8].ToString();

                if (tsbt == "tsbtpncknb")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,Amount from INTransferDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else if (tsbt == "pckpx")
                {
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,0,0 from INTransferDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                    sotienchu = "";
                }
                else if (tsbt == "pckvpx" || tsbt == "tsbtpncknbvlpg")
                {
                    da = gen.GetTable("select  Quantity,0,InventoryItemName,b.Unit,b.Unit,0,0 from INTransferSUDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                    sotienchu = "";
                }
                else if (tsbt == "tsbtpnhgb")
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,a.UnitPrice,Amount from INTransferBranchDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                else if (tsbt == "pxhgbpx")
                {
                    da = gen.GetTable("select  Quantity,QuantityConvert,InventoryItemName,b.Unit,b.ConvertUnit,0,0 from INTransferBranchDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                    sotienchu = "";
                }
                int dem = 9;
                if (da.Rows.Count > 9)
                    dem = da.Rows.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (i < da.Rows.Count)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = da.Rows[i][2].ToString();
                        dr[2] = da.Rows[i][4].ToString();
                        if (Double.Parse(da.Rows[i][0].ToString()) != 0)
                            dr[3] = da.Rows[i][0].ToString();
                        if (Double.Parse(da.Rows[i][1].ToString()) != 0)
                            dr[5] = da.Rows[i][1].ToString();
                        if (Double.Parse(da.Rows[i][5].ToString()) != 0)
                            dr[6] = da.Rows[i][5].ToString();
                        if (Double.Parse(da.Rows[i][6].ToString()) != 0)
                            dr[7] = da.Rows[i][6].ToString();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                }
                rpnhapchuyenkho thuchi = new rpnhapchuyenkho();
                thuchi.gettieude(ngaychungtu, nguoinop, phuongtien, kho, phieuvo, diachi, lydo, phieu, sotienchu, khotren, phieutren, tenphieu);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }


            else if (tsbt == "tsbtbkhhnd" || tsbt == "tsbtbkhhxd" || tsbt == "snknk")
            {
                this.Text = "Bảng kê hàng hóa";
                if (tsbt == "tsbtbkhhnd")
                    phieu = "BẢNG KÊ HÀNG HÓA NHẬP ĐIỀU NỘI BỘ";
                else if (tsbt == "snknk")
                    phieu = "SỔ NHẬT KÝ NHẬP KHO";
                else if (tsbt == "tsbtbkhhxd")
                    phieu = "BẢNG KÊ HÀNG HÓA XUẤT ĐIỀU NỘI BỘ";
                rpbangkehanghoa thuchi = new rpbangkehanghoa();
                thuchi.gettieude(congty, phieu, role, ngaychungtu);
                thuchi.BindData(da);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtddh" || tsbt == "tsbtcdh" || tsbt == "tsbtddhtk" || tsbt == "tsbtpxkctloi" || tsbt == "tsbtddhlpg")
            {
                this.Text = "Bảng kê lỗi barem hàng hóa";
                phieu = "BẢNG KÊ LỖI BAREM HÀNG HÓA";
                rpbangkehanghoa thuchi = new rpbangkehanghoa();
                if (tsbt == "tsbtddh")
                    da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',RefDate as 'Ngày',a.AccountingObjectName as 'Tên khách',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng',QuantityExits as 'Số lượng',QuantityConvertExits as 'Số lượng quy đổi',ROUND(QuantityConvertExits/QuantityExits,2) as 'Số tiền',Round(c.ConvertRate,2) as 'Barem' from DDH a, DDHDetail b, InventoryItem c where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and QuantityExits<>0 and (Round(QuantityConvertExits/QuantityExits,2)>Round(c.ConvertRate,2)+1 or Round(QuantityConvertExits/QuantityExits,2)<Round(c.ConvertRate,2)-1 ) and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.InStockID in (select StockID from MSC_UserJoinStock where UserID='" + role + "') order by RefDate,RefNo");
                else if (tsbt == "tsbtcdh" || tsbt == "tsbtddhtk")
                    da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',RefDate as 'Ngày',a.AccountingObjectName as 'Tên khách',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng',QuantityExits as 'Số lượng',QuantityConvertExits as 'Số lượng quy đổi',ROUND(QuantityConvertExits/QuantityExits,2) as 'Số tiền',Round(c.ConvertRate,2) as 'Barem' from DDH a, DDHDetail b, InventoryItem c where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and QuantityExits<>0 and (Round(QuantityConvertExits/QuantityExits,2)>Round(c.ConvertRate,2)+1 or Round(QuantityConvertExits/QuantityExits,2)<Round(c.ConvertRate,2)-1 ) and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.OutStockID in (select StockID from MSC_UserJoinStock where UserID='" + role + "') order by RefDate,RefNo");
                else if (tsbt == "tsbtpxkctloi")
                    da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',RefDate as 'Ngày',a.AccountingObjectName as 'Tên khách',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng',Quantity as 'Số lượng',QuantityConvert as 'Số lượng quy đổi',ROUND(QuantityConvert/Quantity,2) as 'Số tiền',Round(c.ConvertRate,2) as 'Barem' from INOutward a, INOutwardDetail b, InventoryItem c where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and Quantity<>0 and (Round(QuantityConvert/Quantity,2)>Round(c.ConvertRate,2)+1 or Round(QuantityConvert/Quantity,2)<Round(c.ConvertRate,2)-1 ) and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + role + "') order by RefDate,RefNo");
                else if (tsbt == "tsbtddhlpg")
                    da = gen.GetTable("select substring(RefNo,4,12) as 'Số phiếu',RefDate as 'Ngày',a.AccountingObjectName as 'Tên khách',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng',Quantity as 'Số lượng',QuantityConvert as 'Số lượng quy đổi',ROUND(QuantityConvert/Quantity,2) as 'Số tiền',Round(c.ConvertRate,2) as 'Barem' from INOutwardLPG a, INOutwardLPGDetail b, InventoryItem c where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and Quantity<>0 and (Round(QuantityConvert/Quantity,2)>Round(c.ConvertRate,2) or Round(QuantityConvert/Quantity,2)<Round(c.ConvertRate,2)) and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + role + "') order by RefDate,RefNo");
                if (da.Rows.Count == 0)
                    this.Close();
                thuchi.gettieudeloi(phieu, ngaychungtu);
                thuchi.BindDataloi(da);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }


            else if (tsbt == "snkxk" || tsbt == "snkxcnb" || tsbt == "snkncnb" || tsbt == "snkxcnbtc" || tsbt == "bchgkhkhach" || tsbt == "bkhdbvt" || tsbt == "bknmvt" || tsbt == "snkxktx" || tsbt == "bknckvlpg" || tsbt == "bkxckvlpg" || tsbt == "bkcpbx" || tsbt == "bkcpk" || tsbt == "bkcpbxthhh" || tsbt == "bkcpbxv" || tsbt == "bkcpvcbh" || tsbt == "bkcpbxth" || tsbt == "bkcpbxthnv" || tsbt == "bkthhkm" || tsbt == "bkcpbxnh" || tsbt == "bkcpbxnhv" || tsbt == "bkcpbxnhtdv" || tsbt == "bkcpbxxck" || tsbt == "bkcpbxxckv" || tsbt == "bkcpbxnck" || tsbt == "bkcpbxnckv" || tsbt == "bkcpvcnck" || tsbt == "bkcpvcxck" || tsbt == "snkxkct" || tsbt == "tsbtpxk" || tsbt == "tsbtpxkct" || tsbt == "tsbthdbh" || tsbt == "tsbttrahang" || tsbt == "bkpxbhttm" || tsbt == "bkpxhtdnb" || tsbt == "bkthhhtx" || tsbt == "tsbtpnkvtddh")
            {
                this.Text = "Bảng kê hàng hóa";
                if (tsbt == "snkxk" || tsbt == "snkxkct" || tsbt == "tsbtpxk" || tsbt == "tsbtpxkct")
                {
                    phieu = "SỔ NHẬT KÝ XUẤT KHO";
                    rpnhatkynhapxuat thuchi = new rpnhatkynhapxuat();
                    thuchi.gettieude(ngaychungtu, role, congty, phieu);
                    thuchi.BindData(da);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else if (tsbt == "bkthhhtx")
                {
                     DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để bảng kê hàng hóa, 'No' để in bảng kê tóm tắt.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                     if (dr == DialogResult.Yes)
                     {
                         rpbangkehanghoatheoxe thuchi = new rpbangkehanghoatheoxe();
                         thuchi.gettieude(ngaychungtu, role, congty, kho, tsbt);
                         thuchi.BindData(da);
                         printControl1.PrintingSystem = thuchi.PrintingSystem;
                         thuchi.CreateDocument();
                     }
                     /*else if (dr == DialogResult.No)
                     {
                         rpbangketravotheoxe thuchi = new rpbangketravotheoxe();
                         thuchi.gettieude(ngaychungtu, role, congty);
                         printControl1.PrintingSystem = thuchi.PrintingSystem;
                         thuchi.CreateDocument();
                     }*/
                     else if (dr == DialogResult.No)
                     {
                         rpbangkehanghoatheoxe thuchi = new rpbangkehanghoatheoxe();
                         thuchi.gettieude(ngaychungtu, role, congty, kho, tsbt+"tomtat");
                         thuchi.BindData(da);
                         printControl1.PrintingSystem = thuchi.PrintingSystem;
                         thuchi.CreateDocument();
                     }
                     else
                         this.Close();
                }
                else if (tsbt == "tsbtpnkvtddh")
                {
                    rpbangkehanghoavotheoxe thuchi = new rpbangkehanghoavotheoxe();
                    thuchi.gettieude(ngaychungtu, role, congty, kho, tsbt);
                    thuchi.BindData(da);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else if (tsbt == "tsbthdbh")
                {
                    phieu = "BẢNG KÊ XUẤT KHO";
                    rpnhatkynhapxuat thuchi = new rpnhatkynhapxuat();
                    thuchi.gettieude(ngaychungtu, role, congty, phieu);
                    thuchi.BindData(da);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else if (tsbt == "tsbttrahang")
                {
                    phieu = "BẢNG KÊ ĐƠN HÀNG TRẢ";
                    rpnhatkynhapxuat thuchi = new rpnhatkynhapxuat();
                    thuchi.gettieude(ngaychungtu, role, congty, phieu);
                    thuchi.BindData(da);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else if (tsbt == "snkxcnb" || tsbt == "snkxcnbtc" || tsbt == "bchgkhkhach" || tsbt == "snkncnb")
                {
                    if (tsbt == "snkncnb")
                        phieu = "SỔ NHẬT KÝ NHẬP CHUYỂN NỘI BỘ";
                    else if(tsbt=="bchgkhkhach")
                        phieu = "SỔ NHẬT KÝ HÀNG GỬI KHÁCH HÀNG";
                    else
                        phieu = "SỔ NHẬT KÝ XUẤT CHUYỂN NỘI BỘ";
                    rpnhatkyxuatkhotomtat thuchi = new rpnhatkyxuatkhotomtat();
                    thuchi.gettieude(ngaychungtu, role, congty, phieu, kho);
                    thuchi.BindData(da);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else if (tsbt == "bkthhkm")
                {
                    phieu = "BẢNG KÊ TỔNG HỢP HÀNG KHUYẾN MÃI";
                    rpbangkehanghoa thuchi = new rpbangkehanghoa();
                    thuchi.gettieudekm(ngaychungtu, role, congty, phieu, kho);
                    thuchi.BindDatakm(da);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else if (tsbt == "bkcpbx" || tsbt == "bkcpk" || tsbt == "bkcpbxthhh" || tsbt == "bkcpbxv" || tsbt == "bkcpvcbh" || tsbt == "bkcpbxth" || tsbt == "bkcpbxthnv" || tsbt == "bkcpbxxck" || tsbt == "bkcpbxxckv" || tsbt == "bkcpbxnck" || tsbt == "bkcpbxnckv" || tsbt == "bkcpvcnck" || tsbt == "bkcpvcxck" || tsbt == "bkcpbxnh" || tsbt == "bkcpbxnhv" || tsbt == "bkcpbxnhtdv" || tsbt == "bkpxbhttm" || tsbt == "bkpxhtdnb")
                {
                    if (tsbt == "bkcpbx")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP BÁN HÀNG";
                    else if (tsbt == "bkcpk")
                        phieu = "BẢNG KÊ CHI PHÍ                                                                                                                                                                                                                      ''.................................................''";
                    else if (tsbt == "bkcpbxv")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP XUẤT KHO VỎ";
                    else if (tsbt == "bkcpbxthhh")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP TỔNG HỢP";
                    else if(tsbt == "bkcpbxth")
                        phieu = "BẢNG KÊ BÁN HÀNG THEO GIAO NHẬN";
                    else if (tsbt == "bkcpbxthnv")
                        phieu = "BẢNG KÊ BÁN HÀNG THEO TÀI XẾ";
                    else if (tsbt == "bkcpvcbh")
                        phieu = "BẢNG KÊ CHI PHÍ VẬN CHUYỂN BÁN HÀNG";
                    else if (tsbt == "bkcpbxxck")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP XUẤT CHUYỂN KHO";
                    else if (tsbt == "bkcpbxxckv")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP XUẤT CHUYỂN KHO VỎ";
                    else if (tsbt == "bkcpbxnck")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP NHẬP CHUYỂN KHO";
                    else if (tsbt == "bkcpbxnckv")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP NHẬP CHUYỂN KHO VỎ";
                    else if (tsbt == "bkcpvcnck")
                        phieu = "BẢNG KÊ CHI PHÍ VẬN CHUYỂN NHẬP CHUYỂN KHO";
                    else if (tsbt == "bkcpvcxck")
                        phieu = "BẢNG KÊ CHI PHÍ VẬN CHUYỂN XUẤT CHUYỂN KHO";
                    else if (tsbt == "bkcpbxnh")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP NHẬP KHO";
                    else if (tsbt == "bkcpbxnhv")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP NHẬP KHO VỎ";
                    else if (tsbt == "bkcpbxnhtdv")
                        phieu = "BẢNG KÊ CHI PHÍ BỐC XẾP NHẬP KHO TẠI ĐƠN VỊ";
                    else if (tsbt == "bkpxbhttm")
                        phieu = "BẢNG KÊ PHIẾU XUẤT BÁN HÀNG TRẢ TIỀN MẶT";
                    else if (tsbt == "bkpxhtdnb")
                        phieu = "BẢNG KÊ PHIẾU XUẤT HÀNG TIÊU DÙNG NỘI BỘ";
                    rpnhatkyxuatkhochiphi thuchi = new rpnhatkyxuatkhochiphi();
                    thuchi.gettieude(ngaychungtu, role, congty, phieu, kho);
                    if (tsbt == "bkpxhtdnb")
                        thuchi.BindDatanoibo(da);
                    else if (tsbt == "bkcpbxth" || tsbt == "bkcpbxthnv")
                        thuchi.BindDatath(da);
                    else
                        thuchi.BindData(da);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }

                else if (tsbt == "bkhdbvt" || tsbt == "bknmvt" || tsbt == "bknckvlpg" || tsbt == "bkxckvlpg" || tsbt == "snkxktx")
                {
                    phieu = tsbt;
                    rpbangkexuatnhapvo thuchi = new rpbangkexuatnhapvo();
                    thuchi.gettieude(ngaychungtu, congty, kho, phieu);
                    thuchi.BindData(da);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
            }

            else if (tsbt == "tsbtbkhhnd1" || tsbt == "tsbtbkhhxd1")
            {
                this.Text = "Bảng kê hàng hóa";
                if (tsbt == "tsbtbkhhnd1")
                    phieu = "BẢNG KÊ HÀNG HÓA NHẬP ĐIỀU NỘI BỘ";
                else if (tsbt == "tsbtbkhhxd1")
                    phieu = "BẢNG KÊ HÀNG HÓA XUẤT ĐIỀU NỘI BỘ";
                rpbangkehanghoatong thuchi = new rpbangkehanghoatong();
                thuchi.gettieude(congty, phieu, role, ngaychungtu);
                thuchi.BindData(da);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbkhhnd2" || tsbt == "tsbtbkhhxd2")
            {
                this.Text = "Bảng kê hàng hóa";
                if (tsbt == "tsbtbkhhnd2")
                    phieu = "BẢNG KÊ HÀNG HÓA NHẬP ĐIỀU NỘI BỘ";
                else if (tsbt == "tsbtbkhhxd2")
                    phieu = "BẢNG KÊ HÀNG HÓA XUẤT ĐIỀU NỘI BỘ";
                rpbangkehanghoatonghop thuchi = new rpbangkehanghoatonghop();
                thuchi.gettieude(congty, phieu, role, ngaychungtu);
                thuchi.BindData(da);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "bkthbhtnvkd2")
            {
                this.Text = "Bảng kê hàng hóa";
                phieu = "BẢNG KÊ SẢN LƯỢNG THEO NHÂN VIÊN KINH DOANH";
                rpbangkehanghoatonghop thuchi = new rpbangkehanghoatonghop();
                thuchi.gettieude(congty, phieu, role, ngaychungtu);
                thuchi.BindData2(da);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "bkpxbhttmtong")
            {
                this.Text = "Bảng kê tổng hợp phiếu xuất thu tiền mặt";
                phieu = "BẢNG KÊ TỔNG HỢP THU PHIẾU XUẤT THU TIỀN MẶT";
                rpbangkethutien thuchi = new rpbangkethutien();
                thuchi.gettieude(ngaychungtu, role, kho, phieu);
                thuchi.BindData(da);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "bkthbhtnvkd")
            {
                this.Text = "Nhật ký bán hàng";
                rpnhatkybanhangnhanvien thuchi = new rpnhatkybanhangnhanvien();
                thuchi.BindData(da);
                thuchi.gettieude(role, ngaychungtu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "bkthbhtnvkdintong")
            {
                this.Text = "Bảng kê xuất kho";
                rpbangkexuatkhotong thuchi = new rpbangkexuatkhotong();
                thuchi.BindData(da);
                thuchi.gettieude(role, ngaychungtu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "bkpxhtdnbbangkechiphi" || tsbt == "bkcpbxhgncc")
            {
                this.Text = "Bảng kê chi phí";
                rpbangkechiphi thuchi = new rpbangkechiphi();
                thuchi.BindData(ngaychungtu, congty, kho, role);
                thuchi.gettieude(tsbt, ngaychungtu, congty, role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "bangkehoadondenhan")
            {
                this.Text = "Bảng kê hóa đơn mua vào đến hạn thanh toán";
                rpbangkehoadondenhan thuchi = new rpbangkehoadondenhan();
                thuchi.gettieude(ngaychungtu, congty, role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
        }
    }
}