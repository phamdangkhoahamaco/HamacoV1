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
    public partial class Frm_hdmuahang : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        doiso doi = new doiso();
        gencon gen = new gencon();
        hdmuahang hdmh = new hdmuahang();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup,roleid,subsys,click,phieu,doituong=null,kho=null,load=null,thue=null;
        Double sl = 0;
        Double slqd = 0;
        int K = -2;

        public string getdoituong(string a)
        {
            doituong = a;
            return doituong;
        }
        public string getphieu(string a)
        {
            phieu = a;
            return phieu;
        }
        public string getkho(string a)
        {
            kho = a;
            return kho;
        }
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
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
        public string getbranch(string a)
        {
            branchid = a;
            return branchid;
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
        public void refreshhdmh()
        {
            hdmh.loadstart(gridControl1, gridView1, gridView2, gridView3, cbldt, cbthue, denct, denht, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin,
             ngaychungtu, userid, branchid, active, le1562, this, txtsct, role, txtldn, txtms, txtkhhd, txtshd, txtnhd, txthtt, txthttt, txtcth,txttthue,ledv,tsbttruoc,tsbtsau,khach,hang,txtmst);
            if (active == "1")
                thue = txttthue.Text;
        }
        public Frm_hdmuahang()
        {
            InitializeComponent();
        }


       private void phieunhaphang_Load(object sender, EventArgs e)
        {
            hdmh.loadbox(gridControl1, gridView1, soluong, soluongquydoi, dongia, thanhtien, chiphi);
            hdmh.loadboxhd(gridControl2, gridView2);
            refreshhdmh();
            change();
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (active == "1" && thue != txttthue.Text)
            {
                DialogResult dr = XtraMessageBox.Show("Thuế được thay từ < " + thue + " đồng > sang < " + txttthue.Text + " đồng >, bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Cancel)
                    return;
            }
            hdmh.checkhdmh(active, role, this, gridView1, gridView2, gridView3, ledt, cbldt, txtsct, txtname, txtdc, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa,
                tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, cbthue, txtshd, txtkhhd, txtnhd, txthtt, txthttt, txtms, le1562, branchid, userid,txttthue,ledv.EditValue.ToString(),tsbttruoc,tsbtsau,txtmst);
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
            /*gridView1.UpdateCurrentRow();

            if (e.Column.FieldName == "Số lượng quy đổi")
            {
                try
                {
                    Double soluongqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                    Double soluongtqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL tồn quy đổi").ToString());
                    if (soluongtqd >= soluongqd)
                    {
                        hdmh.loadthhd(gridView2, gridView1, "1");
                        if (caseup == "1")
                        {
                            try
                            {
                                Double soluongton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                                Double tl = soluongton / soluongtqd;
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], (soluongqd * tl).ToString());
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
                        hdmh.loadthhd(gridView2, gridView1, "1");
                        if (caseup == "3")
                        {
                            caseup = "1";
                            Double soluongtonqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL tồn quy đổi").ToString());
                            Double tl = soluongtonqd / soluongtqd;
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], (soluongqd * tl).ToString());
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
                {
                    //XtraMessageBox.Show("Không có < Số lượng tồn > vui lòng kiểm tra lại.", "Thông báo");
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], 0);
                }
            }
            else if (e.Column.FieldName == "Đơn giá" || e.Column.FieldName == "Thành tiền")
            {
                hdmh.loadthhd(gridView2, gridView1, "1");
            }

            if (e.Column.FieldName == "Số lượng quy đổi" || e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "1")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], (a * b).ToString());
                    }
                }
            }
            else if (e.Column.FieldName == "Thành tiền" || e.Column.FieldName == "Chi phí")
            {
                hdmh.loadthhd(gridView2, gridView1, "1");
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
                if (caseup == "2")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], (b / a).ToString());
                    }
                }
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
                                    Double soluongton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                                    Double tl = soluongton / soluongtqd;
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], Math.Round((soluongqd * tl), 0).ToString());
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * soluongqd), 0).ToString());
                                }
                                catch
                                { }
                                hdmh.loadthhdmain(gridView2, gridView1, txtcth);
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
                    Double soluongqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                    Double soluongtqd = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                    if (soluongtqd >= soluongqd)
                    {
                        if (caseup == "3")
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
                    }
                    else
                    {
                        XtraMessageBox.Show("< Số lượng > không được lớn hơn < Số lượng tồn >.", "Thông báo");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], sl.ToString());
                    }

                }
                catch
                { }
            }
            else if (e.Column.FieldName == "Thành tiền")
            {
                if (caseup == "2")
                {
                    try
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((a/b), 2).ToString());
                    }
                    catch { }
                    hdmh.loadthhdmain(gridView2, gridView1, txtcth);
                }
            }
            else if (e.Column.FieldName == "Đơn giá")
            {
                if (caseup == "1")
                {
                    try
                    {
                        Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                        Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                    }
                    catch { }
                    hdmh.loadthhdmain(gridView2, gridView1, txtcth);
                }
            }
            else if (e.Column.FieldName == "Chi phí")
            {
                try
                {
                    Double cth = 0, gtgt, tong, chiphi;
                    try
                    {
                        chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                    }
                    catch
                    {
                        chiphi = 0;
                    }
                    try
                    {
                        cth = Double.Parse(txtcth.Text);
                    }
                    catch { cth = 0; }

                    gtgt = Double.Parse(txttthue.Text);
                    tong = cth + gtgt + chiphi;
                    txttc.Text = String.Format("{0:n0}", tong);

                    if (cth == 0)
                        lbtienchu.Text = "Không đồng";
                }
                catch { }
                
            }
        }

        private void dongia_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "1";
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

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                /*DataTable da = new DataTable();
                string kho = gen.GetString("select StockID from Stock where StockCode='"+ledv.EditValue.ToString()+"'");
                da = gen.GetTable("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                txtname.Text = da.Rows[0][2].ToString();
                if (cbldt.EditValue.ToString() == "Nhân viên")
                {
                    DataTable temp = new DataTable();
                    temp = gen.GetTable("select BranchName from AccountingObject a, Branch b where a.BranchID=b.BranchID and AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                    txtdc.Text = temp.Rows[0][0].ToString();
                }
                else
                {
                    txtdc.Text = da.Rows[0][7].ToString();
                }
                */
                string kho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                hdmh.loadpnk(gridControl3, gridView3, "select * from INInward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (IsExport IS NULL or IsExport='False') and AccountingObjectID in (select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "') and StockID='" + kho + "'  order by RefNo");
                hdmh.delete(gridView1);
                hdmh.delete(gridView2);
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
                        return;
                    }
                }
            }
            catch { }
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
                        string pnkid = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ID").ToString();
                        hdmh.loadcthd(gridView1, pnkid);
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Chọn"], "True");
                    }
                    else
                    {
                        string sct = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Số chứng từ").ToString();
                        hdmh.deletesct(gridView1, sct);
                        hdmh.deletethhd(gridView2, gridView1);
                        gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Chọn"], "False");
                        hdmh.loadthhd(gridView2, gridView1, "0");
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
                }
            }
            catch { }
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
            Double cth, thue, gtgt, tong,chiphi;
            try
            {
                chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
            }
            catch
            {
                chiphi = 0;
            }
            cth = Double.Parse(txtcth.Text);
            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt+chiphi;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txttc.Text) < 0)
                    lbtienchu.Text = "Số tiền viết bằng chữ: (" + doi.ChuyenSo((0 - Double.Parse(txttc.Text.Replace(".", ""))).ToString())+")";
                else
                    lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", ""));
            }
            catch 
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: Không đồng.";
            }
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double cth, thue, gtgt, tong,chiphi;
            try
            {
                chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
            }
            catch 
            {
                chiphi = 0;
            }
            cth = Double.Parse(txtcth.Text);
            if (cbthue.Text != "" && cbthue.Text != "0")
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0);
            }
            else
            {
                gtgt = 0;
            }
            tong = cth + gtgt+chiphi;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                cbldt.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                gridView1.OptionsBehavior.Editable = true;
                //gridView3.OptionsBehavior.Editable = true;
                txtldn.Properties.ReadOnly = false;
                txtms.Properties.ReadOnly = false;
                txtkhhd.Properties.ReadOnly = false;
                txtshd.Properties.ReadOnly = false;
                txthtt.Properties.ReadOnly = false;
                txthttt.Properties.ReadOnly = false;
                txtnhd.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                le1562.Properties.ReadOnly = false;
                ledv.Properties.ReadOnly = false;
                if (active == "1")
                {
                    tsbtnap.Enabled = true;
                    ledv.Properties.ReadOnly = true;
                }
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;

            }
            else
            {
                cbldt.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                gridView1.OptionsBehavior.Editable = false;
                //gridView3.OptionsBehavior.Editable = false;
                denht.Properties.ReadOnly = true;
                txtms.Properties.ReadOnly = true;
                txtkhhd.Properties.ReadOnly = true;
                txthttt.Properties.ReadOnly = true;
                le1562.Properties.ReadOnly = true;
                txtshd.Properties.ReadOnly = true;
                txtnhd.Properties.ReadOnly = true;
                txthtt.Properties.ReadOnly = true;
                ledv.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
            }
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            this.Text = "Sửa hóa đơn mua hàng";
            tsbtcat.Enabled = true;
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            refreshrole();

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
            txtnhd.EditValue = DateTime.Parse(ngaychungtu);
            txtcth.Text = "0";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);

            hdmh.themsct(ngaychungtu, txtsct, branchid,ledv.EditValue.ToString(),tsbttruoc,tsbtsau,txtms,txtkhhd,txtshd);
            this.Text = "Thêm hóa đơn mua hàng";
            change();
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
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            hdmh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshhdmh();
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            hdmh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshhdmh();
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            hdmh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshhdmh();
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            active = "1";
            refreshrole();
            hdmh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, makho);
            refreshhdmh();
            change();
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            gen.ExcuteNonquery("update PUInvoice set Posted='True' where RefID='" + role + "'");
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
            gen.ExcuteNonquery("update PUInvoice set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refreshhdmh();
            change();
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
                }
                catch { }
            }
            else if (dr == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void Frm_hdmuahang_KeyUp(object sender, KeyEventArgs e)
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
                    tsbtin_Click(this, e);
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

        private void Frm_hdmuahang_Load(object sender, EventArgs e)
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
            hdmh.loadbox(gridControl1, gridView1, soluong, soluongquydoi, dongia, thanhtien, chiphi);
            hdmh.loadboxhd(gridControl2, gridView2);
            refreshhdmh();
            change();
            
            if (active == "0")
            {
                if (kho != null)
                {
                    ledv.EditValue = kho;
                    if (doituong != null)
                        ledt.EditValue = doituong;

                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (gridView3.GetRowCellValue(i, "ID").ToString() == phieu)
                        {
                            string pnkid = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ID").ToString();
                            hdmh.loadcthd(gridView1, pnkid);
                            gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Chọn"], "True");
                        }
                    }

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng"], gridView1.GetRowCellValue(i, "Số lượng tồn").ToString());
                        gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng quy đổi"], gridView1.GetRowCellValue(i, "SL tồn quy đổi").ToString());
                    }
                }
            }
            load = "0";
            radioGroup1.SelectedIndex = -1;
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
                        tsbtboghi.Enabled = true;
                    else if (dt.Rows[i][3].ToString() == "POST")
                        tsbtghiso.Enabled = true;
                }
            }
        }

        private void gridControl3_Click(object sender, EventArgs e)
        {

        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth=0, gtgt, tong,chiphi;
                try
                {
                    chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText);
                }
                catch
                {
                    chiphi = 0;
                }
                try
                {
                    cth = Double.Parse(txtcth.Text);
                }
                catch { cth = 0;}
        
                gtgt = Double.Parse(txttthue.Text);
                tong = cth + gtgt + chiphi;
                txttc.Text = String.Format("{0:n0}", tong);

                if (cth == 0)
                    lbtienchu.Text = "Không đồng";
            }
            catch { }
        }
    
        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
            {
                string kho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                hdmh.themsct(ngaychungtu, txtsct, branchid, ledv.EditValue.ToString(), tsbttruoc, tsbtsau, txtms, txtkhhd, txtshd);
                try
                {
                    hdmh.loadpnk(gridControl3, gridView3, "select * from INInward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (IsExport IS NULL or IsExport='False') and AccountingObjectID in (select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "') and StockID='" + kho + "'  order by RefNo");
                    hdmh.delete(gridView1);
                    hdmh.delete(gridView2);
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

        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = -1;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
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

        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(pt);
            F.getrole(role);
            F.Show();
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

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }
    }
}