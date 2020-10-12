using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using DevExpress.XtraGrid.Views.Base;

namespace HAMACO
{
    public partial class Frm_hdbanhang : DevExpress.XtraEditors.XtraForm
    {
        public Frm_hdbanhang()
        {
            InitializeComponent();
        }
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();

        DataTable dt = new DataTable();
        doiso doi = new doiso();
        gencon gen = new gencon();
        string add = "0";
        hdbanhang hdbh = new hdbanhang();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup,roleid,subsys,click,doituong=null,phieu,kho=null,load=null,thue=null, nhanvien=null,chietkhau=null;
        Double sl = 0;
        Double slqd = 0;
        int K = -2;
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getnhanvien(string a)
        {
            nhanvien = a;
            return nhanvien;
        }
        public string getdoituong(string a)
        {
            doituong = a;
            return doituong;
        }
        public string getkho(string a)
        {
            kho = a;
            return kho;
        }
        public string getphieu(string a)
        {
            phieu = a;
            return phieu;
        }
        public string getroleid(string a)
        {
            roleid = a;
            return roleid;
        }
        public string getsub(string a)
        {
            subsys = a;
            return subsys;
        }
        public string getpt(string a)
        {
            pt = a;
            return pt;
        }
        public string getck(string a)
        {
            chietkhau = a;
            return chietkhau;
        }
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }
        public string getbranch(string a)
        {
            branchid = a;
            return branchid;
        }
        public void refreshhdbh()
        {
            hdbh.loadstart(gridControl1, gridControl2, gridView1, gridView2, gridView3, gridView5, cbldt, cbthue, denct, denht, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin,
             ngaychungtu, userid, branchid, active, le1562, this, txtsct, role, txtldn, txtms, txtkhhd, txtshd, txtnhd, txthtt, txthttt, txtcth, txttthue, txtkt, txtldkt, chmoney, chpayphone, leprovince, ledv, cbban, tsbttruoc, tsbtsau, txtquyen, txttdd, txtdc, khach, hang, txtname, txtghichu, chethhd, txtmst, searchncc, chphieu);
            if (active == "1")
                thue = txttthue.Text;
        }


        private void phieunhaphang_Load(object sender, EventArgs e)
        {
            hdbh.loadbox(gridControl1, gridView1, soluong, soluongquydoi, dongia, thanhtien, chiphi, tienck);
            hdbh.loadboxhd(gridControl2, gridView2);
            refreshhdbh();
            change();         
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            if (txtname1562.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập nhân viên bán hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ledt.Focus();
            if (active == "1" && thue != txttthue.Text)
            {
                DialogResult dr = XtraMessageBox.Show("Thuế được thay từ < " + thue + " đồng > sang < " + txttthue.Text + " đồng >, bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Cancel)
                    return;
            }
            hdbh.checkhdbh(active, role, this, gridView1, gridView2, gridView3, gridView5, ledt, cbldt, txtsct, txtname, txtdc, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa,
                tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txtshd, txtkhhd, txtnhd, txthtt, txthttt, txtms, le1562, branchid, userid, txtkt, txttthue, txtldkt, chmoney, chpayphone, leprovince, ledv, cbban, tsbttruoc, tsbtsau, txtquyen, txttdd, txtghichu, chethhd, txtmst, searchncc);
            refreshrole();
            click = "true";
            change();
            click = "false";
            if (active == "1")
            {
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
                thue = txttthue.Text;
            }
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //gridView1.UpdateCurrentRow();

            /*if (e.Column.FieldName == "Số lượng quy đổi")
            {
                try
                {
                    Double soluongqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                    Double soluongtqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL tồn quy đổi").ToString());
                    if (soluongtqd >= soluongqd)
                    {
                        hdbh.loadthhd(gridView2, gridView1, "1",add);
                        if (caseup == "1")
                        {
                            try
                            {
                                Double soluongton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                                Double tl = soluongton / soluongtqd;
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], Math.Round((soluongqd * tl),0).ToString());
                                slqd = 0;
                            }
                            catch
                            { }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("< Số lượng quy đổi > không được lớn hơn < Số lượng tồn quy đổi >.", "Thông báo");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], slqd.ToString());
                    }

                }
                catch { }
            }
            else if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    Double soluongqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                    Double soluongtqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                    if (soluongtqd >= soluongqd)
                    {
                        hdbh.loadthhd(gridView2, gridView1, "1",add);
                        if (caseup == "3")
                        {
                            caseup = "1";
                            Double soluongtonqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL tồn quy đổi").ToString());
                            Double tl = soluongtonqd / soluongtqd;
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Math.Round((soluongqd * tl),2).ToString());
                            sl = 0;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("< Số lượng > không được lớn hơn < Số lượng tồn >.", "Thông báo");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], sl.ToString());
                    }

                }
                catch
                {}
            }
            else if (e.Column.FieldName == "Đơn giá" || e.Column.FieldName == "Thành tiền")
            {
                hdbh.loadthhd(gridView2, gridView1, "1",add);
                txtcth.Text = String.Format("{0:n0}",Double.Parse(gridView1.Columns["Tiền CK"].SummaryText)+Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));

            }

            if (e.Column.FieldName == "Số lượng quy đổi" || e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "1")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b),0).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "")
                {
                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a / 100), 0).ToString());
                }
            
                if (caseup == "2")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a),2).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Tiền CK")
            {
                hdbh.loadthhd(gridView2, gridView1, "1",add);
                Double ck = 0;
                try
                {
                    ck = Double.Parse(gridView1.Columns["Tiền CK"].SummaryText);
                }
                catch { }
                txtck.Text = String.Format("{0:n0}", ck);
            }
            */
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Số lượng quy đổi")
            {
                gridView1.UpdateCurrentRow();
                try
                {
                    Double soluongqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                    Double soluongtqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL tồn quy đổi").ToString());
                    if (soluongtqd >= soluongqd)
                    {
                        if (caseup == "1")
                        {
                            if (slqd != soluongqd)
                            {
                                try
                                {
                                    Double soluongtam = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tạm").ToString());
                                    if (soluongtam == soluongqd)
                                    {
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền tạm").ToString());
                                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((a / soluongqd), 2).ToString());
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí tạm").ToString());
                                    }
                                    else
                                    {
                                        if (active == "0")
                                        {
                                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((soluongqd * a), 0).ToString());
                                        }
                                        else
                                        {
                                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((a / soluongqd), 2).ToString());
                                        }
                                        Double chiphitam = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí tạm").ToString());
                                        if ( chiphitam== 0)
                                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], chiphitam.ToString());
                                        else
                                        {
                                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], Math.Round((chiphitam/soluongtam)*soluongqd,2).ToString());
                                        }
                                    }
                                    if (active == "0")
                                    {
                                        Double soluongton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                                        Double tl = soluongton / soluongtqd;
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], Math.Round((soluongqd * tl), 0).ToString());
                                    }
                                }
                                catch
                                { }
                                hdbh.loadthhdmain(gridView2, gridView1,txtcth,chethhd.Checked.ToString());
                                slqd = 0;
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("< Số lượng quy đổi > không được lớn hơn < Số lượng tồn quy đổi >.", "Thông báo");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], slqd.ToString());
                    }

                }
                catch { }
            }
            else if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    if (caseup == "3")
                    {
                        Double soluongqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                        Double soluongtqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                        if (soluongtqd >= soluongqd)
                        {

                            caseup = "1";
                            if (soluongtqd == soluongqd)
                            {
                                Double soluongtonqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL tồn quy đổi").ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], soluongtonqd.ToString());
                            }
                            else
                            {
                                Double soluongtonqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL tồn quy đổi").ToString());
                                Double tl = soluongtonqd / soluongtqd;
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Math.Round((soluongqd * tl), 2).ToString());
                            }
                            sl = 0;

                        }
                        else
                        {
                            XtraMessageBox.Show("< Số lượng > không được lớn hơn < Số lượng tồn >.", "Thông báo");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], sl.ToString());
                        }
                        hdbh.loadthhdmain(gridView2, gridView1, txtcth, chethhd.Checked.ToString());
                    }
                }
                catch
                { }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {

                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "")
                {
                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a / 100), 0).ToString());
                }

                if (caseup == "2")
                {
                    hdbh.loadthhdmain(gridView2, gridView1, txtcth, chethhd.Checked.ToString());
                }
            }
            else if (e.Column.FieldName == "Tiền CK")
            {
                Double ck = 0;
                try
                {
                    ck = Double.Parse(gridView1.Columns["Tiền CK"].SummaryText);
                }
                catch { }
                txtck.Text = String.Format("{0:n0}", ck);
            }
        }


        private void gridView5_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Chọn")
            {
                if (gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "Chọn").ToString() == "False")
                {
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Chọn"], "True");
                    DataTable da = new DataTable();
                    da = gen.GetTable("select InventoryItemCode,a.Quantity,a.QuantityConvert from INOutwardFreeDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "ID").ToString() + "' order by SortOrder ");
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        gridView2.AddNewRow();
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số chứng từ"], gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "Số chứng từ").ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], da.Rows[i][0].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], da.Rows[i][1].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], da.Rows[i][2].ToString());
                    }
                    gridView2.UpdateCurrentRow();
                }
                else
                {
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Chọn"], "False");
                    
                    for (int i = gridView2.RowCount; i > 0; i--)
                    {
                        try
                        {
                            if (gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "Số chứng từ").ToString() == gridView2.GetRowCellValue(i - 1, "Số chứng từ").ToString())
                            {
                                gridView2.DeleteRow(i-1);
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        private void soluongquydoi_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "1";
            try
            {
                slqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
            }
            catch { }
        }
        private void soluong_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "3";
            try
            {
                sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
            }
            catch { }
        }
        private void thanhtien_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "2";
        }
        /*
        private void chietkhau_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "4";
        }

        private void tienck_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "5";
        }
       */
        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string kho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                hdbh.loadpnk(gridControl3, gridView3, "select * from INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (IsExport IS NULL or IsExport='False') and AccountingObjectID in  (select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "') and StockID='" + kho + "' order by RefNo");
                hdbh.loadpxkm(gridControl4, gridView5, "select * from INOutwardFree where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (IsExport IS NULL or IsExport='False') and AccountingObjectID in (select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "') and StockID='" + kho + "' order by RefNo");
                hdbh.delete(gridView1);
                hdbh.delete(gridView2);
                Double thanhtien = 0;
                Double chiphi = 0;
                try
                {
                    thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                }
                catch { }
                try
                {
                    chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                }
                catch { }
                txtcth.Text = String.Format("{0:n0}", thanhtien + chiphi);

                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtname.Text = khach.Rows[i][2].ToString();
                        txtdc.Text = khach.Rows[i][3].ToString();
                        txtmst.Text = khach.Rows[i][4].ToString();
                        loadhanmuc(khach.Rows[i][0].ToString());
                        return;
                    }
                }               
            }
            catch { }        
            
        }

        private void loadhanmuc(string makhach)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");            
            DataTable da = gen.GetTable("select a.ParentContract,DebtLimitMax,LimitDate,a.SignedDate,EffectiveDate from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where (ContractName=N'Bán hàng' or ContractName=N'' or No='2') and  AccountingObjectID='" + makhach + "' and SignedDate<='" + ngaychungtu + "'and EffectiveDate>='" + ngaychungtu + "' and Inactive=1 and StockID in ( select StockID from Stock where BranchID='" + donvi + "') group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
            txthtt.EditValue = 0;
            for (int j = 0; j < da.Rows.Count; j++)
            {
                txthtt.EditValue = Double.Parse(da.Rows[j][2].ToString());                
            }
        }

        private void cbldt_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*DataTable da = new DataTable();
            DataTable temp = new DataTable();
            temp.Columns.Add("Mã đối tượng");
            temp.Columns.Add("Tên đối tượng");

            if (cbldt.EditValue.ToString() == "Khách hàng")
                da = gen.GetTable("select * from AccountingObject where IsCustomer='True' order by AccountingObjectCode");
            else if (cbldt.EditValue.ToString() == "Nhà cung cấp")
                da = gen.GetTable("select * from AccountingObject where IsVendor='True' order by AccountingObjectCode");
            else
                da = gen.GetTable("select * from AccountingObject where IsEmployee='True' order by AccountingObjectCode");

            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            ledt.Properties.DataSource = temp;
            ledt.Properties.DisplayMember = "Mã đối tượng";
            ledt.Properties.ValueMember = "Mã đối tượng";
            ledt.Properties.PopupWidth = 400;*/
            if (load == null)
            {
                DataTable da = new DataTable();
                DataTable temp = new DataTable();
                temp.Columns.Add("Mã đối tượng");
                temp.Columns.Add("Tên đối tượng");
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    DataRow dr = temp.NewRow();
                    dr[0] = khach.Rows[i][1].ToString();
                    dr[1] = khach.Rows[i][2].ToString();
                    temp.Rows.Add(dr);
                }
                ledt.Properties.DataSource = temp;
                ledt.Properties.DisplayMember = "Mã đối tượng";
                ledt.Properties.ValueMember = "Mã đối tượng";
                ledt.Properties.PopupWidth = 400;

                searchncc.Properties.DataSource = temp;
                searchncc.Properties.DisplayMember = "Mã đối tượng";
                searchncc.Properties.ValueMember = "Mã đối tượng";
            }
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            try
            {
                if (tsbtcat.Enabled == true)
                {
                    if (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Chọn").ToString() == "False")
                    {
                        add = "1";
                        string pnkid = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ID").ToString();
                        hdbh.loadcthd(gridView1, pnkid, chphieu);
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Chọn"], "True");
                        Double chietkhau = Double.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Chiết khấu").ToString());
                        if (txtkt.Text != "")
                        {
                            txtkt.EditValue = Double.Parse(txtkt.EditValue.ToString()) + chietkhau;
                            if (Double.Parse(txtkt.EditValue.ToString()) != 0)
                                txtldkt.Text = "Chiết khấu";
                            else
                                txtldkt.Text = "";
                        }
                        else
                        {
                            txtkt.EditValue = chietkhau;
                            txtldkt.Text = "Chiết khấu";
                        }
                        add = "0";
                    }
                    else
                    {
                        string sct = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Số chứng từ").ToString();
                        hdbh.deletesct(gridView1, sct);
                        hdbh.deletethhd(gridView2, gridView1);
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Chọn"], "False");
                        hdbh.loadthhd(gridView2, gridView1, "0", add);
                        Double thanhtien = 0;
                        try
                        {
                            thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                        }
                        catch { }
                        txtcth.Text = String.Format("{0:n0}", thanhtien);

                        Double chietkhau = Double.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Chiết khấu").ToString());
                        txtkt.EditValue = Double.Parse(txtkt.EditValue.ToString()) - chietkhau;
                        if (Double.Parse(txtkt.EditValue.ToString()) == 0)
                            txtldkt.Text = "";
                        hdbh.loadthhdmain(gridView2, gridView1, txtcth, chethhd.Checked.ToString());
                    }
                    
                }
            }
            catch {}
        }

        private void gridView3_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            /*if (e.Column.FieldName == "Chọn")
            {
                try
                {
                    if (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Chọn").ToString() == "True")
                    {
                        add = "1";
                        string pnkid = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ID").ToString();
                        hdbh.loadcthd(gridView1, pnkid);
                        add = "0";
                    }
                    else
                    {
                        string sct = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Số chứng từ").ToString();
                        hdbh.deletesct(gridView1, sct);
                        hdbh.deletethhd(gridView2, gridView1);
                        hdbh.loadthhd(gridView2, gridView1, "0", add);
                        Double thanhtien = 0;
                        Double ck = 0;
                        try
                        {
                            thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                        }
                        catch { }
                        try
                        {
                            ck = Double.Parse(gridView1.Columns["Tiền CK"].SummaryText);
                        }
                        catch { }
                        txtcth.Text = String.Format("{0:n0}", thanhtien);
                        txtck.Text = String.Format("{0:n0}", ck);
                    }
                    hdbh.loadthhdmain(gridView2, gridView1, txtcth, chethhd.Checked.ToString());
                }
                catch { }
            }*/
        }

        private void le1562_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                txtname1562.Text = gen.GetString("select AccountingObjectName from AccountingObject where AccountingObjectCode='" + le1562.EditValue.ToString() + "'");
            }
            catch { txtname1562.Text = ""; }*/
            try
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (le1562.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtname1562.Text = khach.Rows[i][2].ToString();
                        return;
                    }
                }
            }
            catch { txtname1562.EditValue = null; }
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong,ck,kt;
            cth = Double.Parse(txtcth.Text);
            try
            {
                ck = Double.Parse(txtck.Text);
            }
            catch { ck = 0; }
            try
            {
                kt = Double.Parse(txtkt.Text);
            }
            catch { kt = 0; }
            cth = cth - ck-kt;
            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt;
            txttthue.EditValue =  gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", "").Replace("-", ""));
            }
            catch { }
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong,ck,kt;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { cth = 0; }
            try
            {
                ck = Double.Parse(txtck.Text);
            }
            catch { ck = 0; }
            try
            {
                kt = Double.Parse(txtkt.Text);
            }
            catch { kt = 0; }
            cth = cth - ck - kt;
            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue,0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt;
            txttthue.EditValue =  gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                cbldt.Properties.ReadOnly = false;
                txtname.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                gridView1.OptionsBehavior.Editable = true;
                txtldn.Properties.ReadOnly = false;
                txtms.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                txthtt.Properties.ReadOnly = false;
                txthttt.Properties.ReadOnly = false;
                txtnhd.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                le1562.Properties.ReadOnly = false;
                leprovince.Properties.ReadOnly = false;
                chmoney.Properties.ReadOnly = false;
                chpayphone.Properties.ReadOnly = false;
                ledv.Properties.ReadOnly = false;
                cbban.Properties.ReadOnly = false;
                txttdd.Properties.ReadOnly = false;
                if (active == "1")
                {
                    tsbtnap.Enabled = true;
                    ledv.Properties.ReadOnly = true;
                }
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                ledt.Focus();
            }
            else
            {
                cbldt.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtname.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                gridView1.OptionsBehavior.Editable = false;
                denht.Properties.ReadOnly = true;
                txtms.Properties.ReadOnly = true;
                txtkhhd.Properties.ReadOnly = true;
                txthttt.Properties.ReadOnly = true;
                le1562.Properties.ReadOnly = true;
                txtshd.Properties.ReadOnly = true;
                txtnhd.Properties.ReadOnly = true;
                txthtt.Properties.ReadOnly = true;
                leprovince.Properties.ReadOnly = true;
                chmoney.Properties.ReadOnly = true;
                chpayphone.Properties.ReadOnly = true;
                ledv.Properties.ReadOnly = true;
                cbban.Properties.ReadOnly = true;
                txttdd.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                ledt.Focus();
            }
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            this.Text = "Sửa hóa đơn bán hàng";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();
            searchncc.EditValue = "";
            cbldt.SelectedIndex = 0;
            ledt.EditValue = null;
            le1562.EditValue = null;
            txtms.Text = "";
            txtldn.Text = "";
            txtkhhd.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            txthttt.Text = "";
            txthtt.EditValue = 0;
            txtshd.Text = "";
            txtnhd.EditValue = DateTime.Parse(ngaychungtu); ;
            txtcth.Text = "0";
            txtck.Text = "0";
            txtkt.Text = "0";
            txtldkt.Text = "";
            txtmst.Text = "";
            chmoney.EditValue = false;
            chpayphone.EditValue = false;
            leprovince.EditValue = "CT";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);

            hdbh.themsct(ngaychungtu, txtsct, branchid,ledv.EditValue.ToString(),tsbttruoc,tsbtsau,txtquyen,txtms,txtkhhd,txtshd);
            this.Text = "Thêm hóa đơn mua hàng";
            change();
            while (gridView5.RowCount > 0)
            {
                gridView5.DeleteRow(0);
            }
            while (gridView1.RowCount > 0)
            {
                gridView1.DeleteRow(0);
            }
            while (gridView2.RowCount > 0)
            {
                gridView2.DeleteRow(0);
            }
            while (gridView3.RowCount > 0)
            {
                gridView3.DeleteRow(0);
            }
            
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='"+ledv.EditValue.ToString()+"'");
            active = "1";
            refreshrole();
            hdbh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshhdbh();
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            hdbh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshhdbh();
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            hdbh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshhdbh();
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            hdbh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshhdbh();
            change();
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            gen.ExcuteNonquery("update SSInvoice set Posted='True' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Ghi sổ','" + txtsct.Text + "')");
        }

        private void tsbtboghi_Click(object sender, EventArgs e)
        {
            tsbtghiso.Visible = true;
            tsbtboghi.Visible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][3].ToString() == "EDIT")
                    tsbtsua.Enabled = true;
            }
            gen.ExcuteNonquery("update SSInvoice set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refreshhdbh();
            change();
        }


        private void refreshrole()
        {
            tsbtsua.Enabled = false;
            tsbtadd.Enabled = false;
            tsbtcat.Enabled = false;
            tsbtxoa.Enabled = false;
            tsbtin.Enabled = false;
            tsbtnap.Enabled = false;
            tsbtghiso.Visible = false;
            tsbtghiso.Enabled = false;
            tsbtboghi.Visible = false;
            tsbtboghi.Enabled = false;

            if (active == "0")
            {
                tsbtcat.Enabled = true;
                tsbtadd.Enabled = true;
            }
            else
            {
                tsbtnap.Enabled = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "ADD")
                        tsbtadd.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "DELETE")
                        tsbtxoa.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "EDIT")
                        tsbtsua.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "PRINT")
                        tsbtin.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "UNPOST")
                    {
                        tsbtboghi.Enabled = true;
                        tsbtboghi.Visible = true;
                    }
                    else if (dt.Rows[i][3].ToString() == "POST")
                    {
                        tsbtghiso.Enabled = true;
                        tsbtghiso.Visible = true;
                    }
                }
            }
        }

        public void getdoituong(string a, string check)
        {
            if (check == "1")
                ledt.EditValue = a;
            else if (check == "2")
            {
                try
                {
                    string temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tên hàng").ToString();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], a);
                }
                catch
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], a);
                }
            }
            else if (check == "3")
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], a);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát và làm mới dữ liệu?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    this.myac();
                    this.Dispose();
                    System.GC.Collect();
                }
                catch { }
            }
            else if (dr == DialogResult.No)
            {
                this.Dispose();
                System.GC.Collect();
            }
            else if (dr == DialogResult.Cancel)
                e.Cancel = true;
        }


        private void Frm_hdbanhang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
            {
                if (tsbtadd.Enabled == true)
                    tsbtadd_Click(this, e);
            }
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (tsbtsua.Enabled == true)
                    tsbtsua_Click(this, e);
            }
            else if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
            {
                if (tsbtcat.Enabled == true)
                    tsbtcat_Click(this, e);
            }
            else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
            {
                if (tsbtnap.Enabled == true)
                    tsbtnap_Click(this, e);
            }
            else if (e.KeyCode == Keys.I && e.Modifiers == Keys.Control)
            {
                if (tsbtin.Enabled == true)
                    tsbtin_ButtonClick(this, e);
            }
            else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            {
                if (tsbtghiso.Enabled == true)
                    tsbtghiso_Click(this, e);
            }
            else if (e.KeyCode == Keys.B && e.Modifiers == Keys.Control)
            {
                if (tsbtboghi.Enabled == true)
                    tsbtboghi_Click(this, e);
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                if (tsbttruoc.Enabled == true)
                    tsbttruoc_ButtonClick(this, e);
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                if (tsbtsau.Enabled == true)
                    tsbtsau_ButtonClick(this, e);
            }
            else if (e.KeyCode == Keys.End)
            {
                if (tsbtsau.Enabled == true)
                    tsbtsaucung_Click(this, e);
            }
            else if (e.KeyCode == Keys.Home)
            {
                if (tsbttruoc.Enabled == true)
                    tsbttruocnhat_Click(this, e);
            }
        }

        private void Frm_hdbanhang_Load(object sender, EventArgs e)
        {
            try
            {
                dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
                tsbtsau.Enabled = false;
            }
            refreshrole();
            hdbh.loadbox(gridControl1, gridView1, soluong, soluongquydoi, dongia, thanhtien, chiphi, tienck);
            hdbh.loadboxhd(gridControl2, gridView2);
            refreshhdbh();
            change();
            load="0";
            if (active == "0")
            {
                if (kho != null)
                {
                    ledv.EditValue = kho;
                    if (doituong != null)
                        ledt.EditValue = doituong;
                    if (nhanvien != null)
                        le1562.EditValue = nhanvien;

                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (gridView3.GetRowCellValue(i, "ID").ToString() == phieu)
                        {
                            add = "1";
                            string pnkid = gridView3.GetRowCellValue(i, "ID").ToString();
                            hdbh.loadcthd(gridView1, pnkid, chphieu);
                            gridView3.SetRowCellValue(i, gridView3.Columns["Chọn"], "True");
                            add = "0";
                        }
                    }
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        gridView1.FocusedRowHandle = j;
                        if (Double.Parse(gridView1.GetRowCellValue(j, "SL tồn quy đổi").ToString()) != 0)
                        {
                            gridView1.SetRowCellValue(j, gridView1.Columns["Số lượng"], gridView1.GetRowCellValue(j, "Số lượng tồn").ToString());
                            gridView1.SetRowCellValue(j, gridView1.Columns["Số lượng quy đổi"], gridView1.GetRowCellValue(j, "SL tồn quy đổi").ToString());
                            gridView1.SetRowCellValue(j, gridView1.Columns["Thành tiền"], gridView1.GetRowCellValue(j, "Thành tiền tạm").ToString());
                            gridView1.SetRowCellValue(j, gridView1.Columns["Chi phí"], gridView1.GetRowCellValue(j, "Chi phí tạm").ToString());
                            gridView1.UpdateTotalSummary();
                        }
                    }
                    txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView1.Columns["Tiền CK"].SummaryText) + Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
                    hdbh.loadthhdmain(gridView2, gridView1, txtcth, chethhd.Checked.ToString());

                    if (chietkhau != null)
                    {
                        txtkt.EditValue = Double.Parse(chietkhau) / (1 + Double.Parse(cbthue.Text) / 100);
                        txtldkt.Text = "Chiết khấu";
                    }
                }
            }
            else
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
            radioGroup1.SelectedIndex = -1;
        }

        private void txtck_EditValueChanged(object sender, EventArgs e)
        {
                Double cth, thue, gtgt, tong, ck;
                try
                {
                    cth = Double.Parse(txtcth.Text);
                }
                catch { cth = 0; }
                ck = Double.Parse(txtck.Text);
                cth = cth - ck;
                if (cbthue.Text != "" && cbthue.Text != "0")
                {
                    thue = Double.Parse(cbthue.Text);
                    gtgt = Math.Round((cth / 100) * thue, 0);
                }
                else
                {
                    gtgt = 0;
                }

                tong = cth + gtgt;
                txttthue.EditValue =  gtgt;
                txttc.Text = String.Format("{0:n0}", tong);
                if (cth == 0)
                    lbtienchu.Text = "Không đồng";
        }

        private void txtkt_EditValueChanged(object sender, EventArgs e)
        {
            Double cth,thue, gtgt, tong, ck, kt;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { cth = 0; }
            try
            {
                ck = Double.Parse(txtck.Text);
            }
            catch { ck = 0; }
            kt = Double.Parse(txtkt.Text);
            cth = cth - ck - kt;

            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }

            txttthue.EditValue =  gtgt;
            tong = cth + gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "Không đồng";
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth, gtgt, tong, ck, kt;
                try
                {
                    cth = Double.Parse(txtcth.Text);
                }
                catch { cth = 0; }
                try
                {
                    ck = Double.Parse(txtck.Text);
                }
                catch { ck = 0; }
                try
                {
                    kt = Double.Parse(txtkt.Text);
                }
                catch { kt = 0; }
                cth = cth - ck - kt;
                gtgt = Double.Parse(txttthue.Text);
                tong = cth + gtgt;

                txttc.Text = String.Format("{0:n0}", tong);

                if (cth == 0)
                    lbtienchu.Text = "Không đồng";
            }
            catch { }
        }

        private void tsbtin_ButtonClick(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(role);
            F.getcongty(chinten.Checked.ToString());
            F.ShowDialog();
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
            {
                string kho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                hdbh.themsct(ngaychungtu, txtsct, branchid, ledv.EditValue.ToString(), tsbttruoc, tsbtsau, txtquyen, txtms, txtkhhd, txtshd);
                try
                {
                    hdbh.loadpnk(gridControl3, gridView3, "select * from INOutward where StockID='" + kho + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (IsExport IS NULL or IsExport='False') and AccountingObjectID in  (select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "') order by RefNo");
                    hdbh.loadpxkm(gridControl4, gridView5, "select * from INOutwardFree where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (IsExport IS NULL or IsExport='False') and AccountingObjectID in (select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "') and StockID='" + kho + "' order by RefNo");
                    hdbh.delete(gridView1);
                    hdbh.delete(gridView2);
                    Double thanhtien = 0;
                    Double chiphi = 0;
                    try
                    {
                        thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                    }
                    catch { }
                    try
                    {
                        chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                    }
                    catch { }
                    txtcth.Text = String.Format("{0:n0}", thanhtien + chiphi);
                }
                catch { }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt+"tsl");
            F.getrole(role);
            F.getcongty(chinten.Checked.ToString());
            F.ShowDialog();
        }

        private void mẫuInTheoTrọngLượngKèmSốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "ksl");
            F.getrole(role);
            F.ShowDialog();
        }
        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = -1;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                K = 1;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }
        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                    gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng"], gridView1.GetRowCellValue(i, "Số lượng tồn").ToString());
            }
        }
        private void lenv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                le1562.EditValue = null;
            }
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = 0;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }
        private void searchncc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                searchncc.EditValue = "";
            }
        }
        private void mẫuĐơnGiáTheoTheoSốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "dgsl");
            F.getrole(role);
            F.ShowDialog();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex != -1)
            {
                searchLookUpEdit1.Properties.View.Columns.Clear();
                DataTable temp = new DataTable();
                temp.Columns.Add("Mã khách");
                temp.Columns.Add("Tên khách");
                temp.Columns.Add("Địa chỉ");
                temp.Columns.Add("Mã số thuế");
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    DataRow dr = temp.NewRow();
                    dr[0] = khach.Rows[i][1].ToString();
                    dr[1] = khach.Rows[i][2].ToString();
                    dr[2] = khach.Rows[i][3].ToString();
                    dr[3] = khach.Rows[i][4].ToString();
                    temp.Rows.Add(dr);
                }
                searchLookUpEdit1.Properties.DataSource = temp;
                searchLookUpEdit1.Properties.DisplayMember = "Mã khách";
                searchLookUpEdit1.Properties.ValueMember = "Mã khách";
                searchLookUpEdit1.Focus();
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (K == -1)
            {
                ledt.EditValue = searchLookUpEdit1.EditValue;
                ledt.Focus();
            }
            else if (K == 0)
            {
                le1562.EditValue = searchLookUpEdit1.EditValue;
                le1562.Focus();
            }
            else if (K == 1)
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (searchLookUpEdit1.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtname.Text = khach.Rows[i][2].ToString();
                        txtdc.Text = khach.Rows[i][3].ToString();
                        txtmst.Text = khach.Rows[i][4].ToString();
                        ledt.Focus();
                        return;
                    }
                }
            }
        }

        private void chethhd_CheckedChanged(object sender, EventArgs e)
        {
            hdbh.loadthhdmain(gridView2, gridView1, txtcth, chethhd.Checked.ToString());
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }



        private void gridView1_FocusedRowChanged(object sender, EventArgs e)
        {
            gridView1_FocusedRowChanged();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            gridView1_FocusedRowChanged();
        }

        private void gridView2_FocusedRowChanged(object sender, EventArgs e)
        {
            gridView2_FocusedRowChanged();
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            gridView2_FocusedRowChanged();
        }

        private void gridView1_FocusedRowChanged()
        {
            try
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        textEdit1.Text= hang.Rows[i][2].ToString();
                        return;
                    }
                }
                textEdit1.Text = null;
            }
            catch
            {
                textEdit1.Text = null;
            }
        }

        private void gridView2_FocusedRowChanged()
        {
            try
            {
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                    {
                        textEdit1.Text = hang.Rows[i][2].ToString();
                        return;
                    }
                }
                textEdit1.Text = null;
            }
            catch
            {
                textEdit1.Text = null;
            }
        }




        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (tsbtcat.Enabled == false)
            {
                try
                {
                    if (gen.GetString("select Cancel from INOutward where RefID='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString() + "'") == "True")
                    {
                        Frm_phieunhapkhovat u = new Frm_phieunhapkhovat();
                        u.myac = new Frm_phieunhapkhovat.ac(refreshhdbh);
                        u.getactive("1");
                        u.getroleid(roleid);
                        u.getsub(subsys);
                        u.getpt("pxkbarem");
                        u.getdate(ngaychungtu);
                        u.getuser(userid);
                        u.getbranch(branchid);
                        u.getkhach(khach);
                        u.gethang(hang);
                        u.getrole(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
                        u.ShowDialog();
                    }
                    else
                    {
                        Frm_phieunhapkho u = new Frm_phieunhapkho();
                        u.myac = new Frm_phieunhapkho.ac(refreshhdbh);
                        u.getactive("1");
                        u.getroleid(roleid);
                        u.getsub(subsys);
                        u.getpt("pxk");
                        u.getdate(ngaychungtu);
                        u.getuser(userid);
                        u.getbranch(branchid);
                        u.getkhach(khach);
                        u.gethang(hang);
                        u.getrole(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
                        u.ShowDialog();
                    }
                }
                catch { MessageBox.Show("Vui lòng chọn phiếu xuất kho trước khi sửa."); }
            }
        }

        private void mẫuInTheoBảngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt+"bangke");
            F.getrole(role);
            F.getcongty(chinten.Checked.ToString());
            F.ShowDialog();
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }

        private void biênBảnHàngGửiLạiKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt + "bienbanguilaikho");
            F.getrole(role);
            F.ShowDialog();
        }

    }
}