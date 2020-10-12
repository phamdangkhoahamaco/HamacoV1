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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;

namespace HAMACO
{
    public partial class Frm_phieuthuV2 : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        DataTable taikhoan = new DataTable();
        DataTable danhmuc = new DataTable();
        gencon gen = new gencon();
        phieuthutm pttm = new phieuthutm();
        phieuthunh ptnh = new phieuthunh();
        phieuchitm pctm = new phieuchitm();
        phieuchinh pcnh = new phieuchinh();
        phieuketoan pkt = new phieuketoan();
        phieuthuchi ptctm = new phieuthuchi();

      
        string duyet = "";
        string tablename = "";
        string refid, active, pt, ngaychungtu, userid, roleid, subsys, click, load = null;
        
        int K = -2, auto = 0;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            if (keyData == (Keys.Enter))
            {

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
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
        public string getrefid(string a)
        {
            refid = a;
            return refid;
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
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public string getpt(string a)
        {
            pt = a;
            return pt;
        }

        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        

        public Frm_phieuthuV2()
        {
            InitializeComponent();
        }

    

     

        private void refreshrole()
        {
            tsbtsua.Enabled = false;
            tsbtadd.Enabled = false;
            tsbtcat.Enabled = false;// luu
            toolduyet.Enabled = true;
            tsbtkc.Enabled = false;
            tsbtxoa.Enabled = false;
            tsbtin.Enabled = false;
            tsbtnap.Enabled = false;
            tsbtghiso.Visible = false;
            tsbtghiso.Enabled = false;
            tsbtboghi.Visible = false;
            tsbtboghi.Enabled = false;
            tsbttruoc.Enabled = false;
            tsbtsau.Enabled = false;


            if (active == "0")
            {
                tsbtcat.Enabled = true;                
                tsbtkc.Enabled = true;
            }
            else
            {
                tsbtnap.Enabled = true;
                //MSC_RolePermissionMaping --> check lai phan quyen sau
                tsbtxoa.Enabled = true; // in chi tiet
                tsbtsua.Enabled = true;
                tsbtin.Enabled = true; // in tong hop
                tsbtboghi.Enabled = true;
                tsbtghiso.Enabled = true;
                toolduyet.Visible = true;
                /*
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
                    else if (dt.Rows[i][3].ToString() == "LOCKINPUT")
                        toolduyet.Visible = true;
                }*/
            }
        }


        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (auto == 0)
            {
                if (searchdanhmuc.EditValue == null)
                {
                    XtraMessageBox.Show("Bạn phải chọn danh mục trước khi nhập dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    return;
                }
                gridView1.UpdateCurrentRow();
                if (e.Column.FieldName == "Tài khoản có" || e.Column.FieldName == "Tài khoản nợ")
                {
                    if (gridView1.FocusedRowHandle < 1)
                    {
                        if (e.Column.FieldName == "Tài khoản có")
                        {
                            if (pt == "pttm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "1111");
                            else if (pt == "ptnh") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], "1121");
                        }
                        else
                        {
                            if (pt == "pctm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "1111");
                            else if (pt == "pcnh") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], "1121");
                        }
                    }
                    else
                    {
                        if (e.Column.FieldName == "Tài khoản có")
                        {
                            if (pt == "pttm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản nợ").ToString());
                            else if (pt == "ptnh") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản nợ").ToString());
                        }
                        else
                        {
                            if (pt == "pctm") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
                            else if (pt == "pcnh") gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Tài khoản có").ToString());
                        }
                    }

                    if (cechd.Checked == true)
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString() == "33311" || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString() == "1331" || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản nợ").ToString() == "1331" || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản nợ").ToString() == "33311")
                            return;

                    if (e.Column.FieldName == "Tài khoản có")
                    {
                        for (int i = 0; i < danhmuc.Rows.Count; i++)
                            if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString() && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString() == danhmuc.Rows[i][2].ToString())
                                return;
                        for (int i = 0; i < danhmuc.Rows.Count; i++)
                            if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString())
                            {
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], danhmuc.Rows[i][2].ToString());
                                return;
                            }
                    }
                    else if (e.Column.FieldName == "Tài khoản nợ")
                    {
                        for (int i = 0; i < danhmuc.Rows.Count; i++)
                            if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString() && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản nợ").ToString() == danhmuc.Rows[i][1].ToString())
                                return;
                        for (int i = 0; i < danhmuc.Rows.Count; i++)
                            if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString())
                            {
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], danhmuc.Rows[i][1].ToString());
                                return;
                            }
                    }
                }

                if (gridView1.RowCount == 14 && auto == 0)
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);

                if (e.Column.FieldName == "Mã khách")
                {
                    for (int i = 0; i < khach.Rows.Count; i++)
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã khách").ToString() == khach.Rows[i][1].ToString())
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Ghi chú"], khach.Rows[i][5].ToString());
                            txtnn.Text = khach.Rows[i][5].ToString();
                            return;
                        }
                    }
                }
            }
        }



        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            string[,] detail = new string[20, 15];
            string check = "0";
            string dt = ""; //ma doi tuong  - AccountingObjectID
            try
            {
                string SQLString = "select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'";
                dt = gen.GetString(SQLString); //AccountingObjectID                
                
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Tài khoản có").ToString() == "")
                        check = "1";
                    detail[i, 0] = gridView1.GetRowCellValue(i, "Tài khoản có").ToString();
                    if (gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString() == "")
                        check = "1";
                    detail[i, 1] = gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString();

                    detail[i, 2] = "NULL";
                    if (gridView1.GetRowCellValue(i, "Ngày phát hành HĐ").ToString() != "")
                        detail[i, 2] = "'" + gridView1.GetRowCellValue(i, "Ngày phát hành HĐ").ToString() + "'";

                    detail[i, 3] = gridView1.GetRowCellValue(i, "Loại hóa đơn").ToString();
                    detail[i, 4] = gridView1.GetRowCellValue(i, "Số hóa đơn").ToString();
                    if (gridView1.GetRowCellValue(i, "Số tiền").ToString() == "")
                        check = "1";
                    detail[i, 5] = gridView1.GetRowCellValue(i, "Số tiền").ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "Mã khách").ToString() == "")
                        check = "1";
                    else
                    {
                        try
                        {
                            DataTable mk = gen.GetTable("select AccountingObjectID,BranchID from AccountingObject where AccountingObjectCode='" + gridView1.GetRowCellValue(i, "Mã khách").ToString() + "'");
                            detail[i, 6] = mk.Rows[0][0].ToString();
                            if (gridView1.GetRowCellValue(i, "Tài khoản có").ToString() == "141")
                                detail[i, 8] = "'" + mk.Rows[0][1].ToString() + "'";
                            else detail[i, 8] = "NULL";
                        }
                        catch
                        {
                            detail[i, 6] = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + gridView1.GetRowCellValue(i, "Mã khách").ToString() + "'");
                            detail[i, 8] = "NULL";
                        }
                    }
                    detail[i, 7] = gridView1.GetRowCellValue(i, "Diễn giải").ToString();
                    detail[i, 9] = gridView1.GetRowCellValue(i, "Ký hiệu hóa đơn").ToString();
                    detail[i, 10] = gridView1.GetRowCellValue(i, "Nhóm chi phí").ToString();
                    detail[i, 11] = gridView1.GetRowCellValue(i, "Ghi chú").ToString();
                }
            }catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtSQL.Text = ex.Message + ex.StackTrace + ex.TargetSite.ToString() + SQLString2 + SQLString3;
                return;
            }

                tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtkc.Enabled = false;
            if (pt != "")  gen.ExcuteNonquery("update " + tablename + " set Posted='True' where RefID='" + refid + "'");            

            //insert vao table FIDocument
            string SQLString2 = "select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'";
            string SQLString3 = "select StockID from Stock where StockCode='" + letq.EditValue.ToString() + "'";
            string dv = gen.GetString(SQLString2);
            string dvtq = gen.GetString(SQLString3);
            string tong = gridView1.Columns["Số tiền"].SummaryText;
            tong = tong.Replace("Tổng tiền =", "").Trim();
            tong = tong.Replace(".", "");
            string ldt;
            if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
            else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
            else ldt = "2";

            string duyet = "2";

            String FIDocNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            // reftype = 101 ???
            SQLString2 = "insert into FIDocument(ClientID,CompanyCode,FIDocNo,FiscalYear,FiscalPeriod,DocType,RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,RefOrder,ShippingMethodID,EditVersion,CustomField5)";
            SQLString2 += " values(" + Globals.clientid + ",'" + Globals.companycode + "','" + FIDocNo + "'," + year + "," + thang + ",'" + pt.ToUpper() + "','" + refid + "','101','" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtnn.Text + "',N'" + txtldn.Text;
            SQLString2 += "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + tong + "','" + cbthue.Text + "','" + Globals.userid + "','" + ledt.EditValue.ToString() + "','" + dvtq + "'," + duyet + ",'" + txtsct.Text + "')";
            try {
                gen.ExcuteNonquery(SQLString2);
                XtraMessageBox.Show("Updated successfully", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite.ToString(), "FIDocument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtSQL.Text = ex.Message + ex.StackTrace + ex.TargetSite.ToString() + SQLString2;
                return;
            }

            //detail
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                // insert detail lineitem
                SQLString3 = "insert into FIDocumentDetail(ClientID,CompanyCode,FIDocNo,RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,StockID,CustomField5,CustomField4,Note) ";
                SQLString3 += "values(" + Globals.clientid + ",'" + Globals.companycode + "','" + FIDocNo + "',newid(), '" + refid + "', N'" + detail[i, 7] + "', '" + detail[i, 1] + "', '" + detail[i, 0] + "', '" + detail[i, 5] + "', '" + detail[i, 6] + "', " + detail[i, 2] + ", '" + detail[i, 3] + "', '" + detail[i, 4] + "', " + i + ", " + detail[i, 8] + ", '" + detail[i, 9] + "', N'" + detail[i, 10] + "', N'" + detail[i, 11] + "')";
                try { gen.ExcuteNonquery(SQLString3);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite.ToString(), "FIDocumentDetail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSQL.Text = ex.Message + ex.StackTrace + ex.TargetSite.ToString() + SQLString3;
                    return;
                }

            }
            //XtraMessageBox.Show(SQLString3 + gridView1.RowCount, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //txtSQL.Text = SQLString3;

            //luu log
            //gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Ghi sổ','" + txtsct.Text + "')");
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
            if (pt == "pttm")
                gen.ExcuteNonquery("update CAReceipt set Posted='False' where RefID='" + refid + "'");
            else if (pt == "ptnh") gen.ExcuteNonquery("update BADeposit set Posted='False' where RefID='" + refid + "'");
            else if (pt == "pctm") gen.ExcuteNonquery("update CAPayment set Posted='False' where RefID='" + refid + "'");
            else if (pt == "pcnh") gen.ExcuteNonquery("update BATransfer set Posted='False' where RefID='" + refid + "'");
            else if (pt == "pkt") gen.ExcuteNonquery("update GLVoucher set Posted='False' where RefID='" + refid + "'");
            //gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            tsbtcat.Enabled = true;
            toolduyet.Enabled = true;
            tsbtkc.Enabled = true;
            change();
        }

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {

                ledv.Enabled = true;
                if (active == "1")
                    if (pt == "pttm" || pt == "pctm")
                        ledv.Enabled = false;
                letq.Enabled = true;
                searchdanhmuc.Properties.ReadOnly = false;
                cbldt.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                txtnn.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                cechd.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                if (gridView1.RowCount < 14)
                {
                    gridView1.OptionsBehavior.Editable = true;
                }
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                if (tsbtkc.Visible == true)
                    tsbtkc.Enabled = true;
                tsbtghiso.Visible = false;
                ledv.Focus();
            }
            else
            {
                ledv.Enabled = false;
                letq.Enabled = false;
                searchdanhmuc.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtnn.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                cechd.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                ledv.Focus();
            }
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView1.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = gridView1.FocusedRowHandle;                
            }
            else if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            ledt.Focus(); // doi tuong
            Frm_phieuthuV2 u = new Frm_phieuthuV2();
            if (cbthue.Text != "")
                try
                {
                    Double.Parse(cbthue.Text);
                }
                catch
                {
                    XtraMessageBox.Show("Thuế suất không đúng định dạng. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            if (pt != "") checkpttm("1",active);           
        }

        private void checkpttm(string duyet, string active) // ham viet chung
        {
            // check phieu thu tien mat
            string SQLString = "";
            string SQLString2 = "";
            string SQLString3 = "";
            try
            {
                int count = gridView1.RowCount;
                if (active == "0") count = count - 1;
                SQLString = "select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'";
                string dt = gen.GetString(SQLString); //AccountingObjectID
                string[,] detail = new string[20, 15];
                string check = "0";
                for (int i = 0; i < count; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Tài khoản có").ToString() == "")
                        check = "1";
                    detail[i, 0] = gridView1.GetRowCellValue(i, "Tài khoản có").ToString();
                    if (gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString() == "")
                        check = "1";
                    detail[i, 1] = gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString();

                    detail[i, 2] = "NULL";
                    if (gridView1.GetRowCellValue(i, "Ngày phát hành HĐ").ToString() != "")
                        detail[i, 2] = "'" + gridView1.GetRowCellValue(i, "Ngày phát hành HĐ").ToString() + "'";

                    detail[i, 3] = gridView1.GetRowCellValue(i, "Loại hóa đơn").ToString();
                    detail[i, 4] = gridView1.GetRowCellValue(i, "Số hóa đơn").ToString();
                    if (gridView1.GetRowCellValue(i, "Số tiền").ToString() == "")
                        check = "1";
                    detail[i, 5] = gridView1.GetRowCellValue(i, "Số tiền").ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "Mã khách").ToString() == "")
                        check = "1";
                    else
                    {
                        try
                        {
                            DataTable mk = gen.GetTable("select AccountingObjectID,BranchID from AccountingObject where AccountingObjectCode='" + gridView1.GetRowCellValue(i, "Mã khách").ToString() + "'");
                            detail[i, 6] = mk.Rows[0][0].ToString();
                            if (gridView1.GetRowCellValue(i, "Tài khoản có").ToString() == "141")
                                detail[i, 8] = "'" + mk.Rows[0][1].ToString() + "'";
                            else detail[i, 8] = "NULL"; //stockid
                        }
                        catch
                        {
                            detail[i, 6] = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + gridView1.GetRowCellValue(i, "Mã khách").ToString() + "'");
                            detail[i, 8] = "NULL";
                        }
                    }
                    detail[i, 7] = gridView1.GetRowCellValue(i, "Diễn giải").ToString();
                    detail[i, 9] = gridView1.GetRowCellValue(i, "Ký hiệu hóa đơn").ToString();
                    detail[i, 10] = gridView1.GetRowCellValue(i, "Nhóm chi phí").ToString();
                    detail[i, 11] = gridView1.GetRowCellValue(i, "Ghi chú").ToString();
                }
                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Tài khoản có> <Tài khoản nợ> <Số tiền> <Mã Khách> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SQLString2 = "select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'";
                    if (pt == "pttm" || pt == "pctm") SQLString3 = "select StockID from Stock where StockCode='" + letq.EditValue.ToString() + "'";
                    string dv = gen.GetString(SQLString2);
                    string dvtq = "";
                    if (pt == "pttm" || pt == "pctm") dvtq = gen.GetString(SQLString3);
                    //if phieu thu ngan hang, phieu ke toan khong can ton quy
                    if (pt == "ptnh" || pt == "pcnh" || pt == "phkt") dvtq = dv;

                    string tong = gridView1.Columns["Số tiền"].SummaryText;
                    tong = tong.Replace("Tổng tiền =", "").Trim();
                    tong = tong.Replace(".", "");
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";
                    if (active == "0")
                    {
                        try
                        {
                            //string ton = gen.GetString("select * from CAReceipt where RefNo='" + txtsct.Text + "'");
                            //themsct(); // them so chung tu
                        }
                        catch { }
                        // field duyet - edit version
                        if (duyet == "") duyet = "1";
                        
                        SQLString2 = "insert into " + tablename + "(ClientID,CompanyCode,RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,RefOrder,ShippingMethodID,EditVersion,CustomField5)";
                        SQLString2 += " values(" + Globals.clientid + ",'" + Globals.companycode + "',newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtnn.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + tong + "','" + cbthue.Text + "','" + Globals.userid + "','" + searchdanhmuc.EditValue.ToString() + "','" + dvtq + "'," + duyet + ",'" + txtsct.Text + "')";
                        gen.ExcuteNonquery(SQLString2);
                        string refid = gen.GetString("select RefID from " + tablename + " where RefNo='" + txtsct.Text + "'");
                        getrefid(refid);
                        for (int i = 0; i < count; i++)
                        {
                            // insert detail lineitem
                            SQLString3 = "insert into " + tablename + "Detail(ClientID,CompanyCode,RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,StockID,CustomField5,CustomField4,Note) ";
                            SQLString3 += "values(" + Globals.clientid + ",'" + Globals.companycode + "',newid(), '" + refid + "', N'" + detail[i, 7] + "', '" + detail[i, 1] + "', '" + detail[i, 0] + "', '" + detail[i, 5] + "', '" + detail[i, 6] + "', " + detail[i, 2] + ", '" + detail[i, 3] + "', '" + detail[i, 4] + "', " + i + ", " + detail[i, 8] + ", '" + detail[i, 9] + "', N'" + detail[i, 10] + "', N'" + detail[i, 11] + "')";
                            gen.ExcuteNonquery(SQLString3);
                        }
                    }
                    else // active = 1 (da luu roi)
                    {
                       
                        if (duyet == "2")
                        {
                            if (gen.GetString("select EditVersion from " + tablename + " where RefID='" + refid + "'") != "2")
                                themsctmoi();
                            tsbtcat.Visible = false;
                        }
                        
                        SQLString2 = "update " + tablename + " set RefNo='" + txtsct.Text + "', RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',";
                        SQLString2 += "AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtnn.Text + "',JournalMemo=N'" + txtldn.Text;
                        SQLString2 += "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tong + "',Tax='" + cbthue.Text + "',UserID='" + Globals.userid;
                        SQLString2 += "',ShippingMethodID='" + dvtq + "',EditVersion=" + duyet + "  where RefID='" + refid + "' AND ClientID=" + Globals.clientid;
                        gen.ExcuteNonquery(SQLString2);
                        //gen.ExcuteNonquery("delete  from  " + tablename + "Detail where RefID='" + refid + "'"); --> xoa hoi nguy hiem --> ham update

                        for (int i = 0; i < count; i++) // luu thi ko tinh line cuoi
                        {
                            SQLString2 = "update " + tablename + "Detail set Amount=" + detail[i, 5] + ",AccountingObjectID='" + detail[i, 6] + "'";
                            SQLString2 += ",Note=N'" + detail[i, 11] + "',CustomField4=N'" + detail[i, 10] + "'  where RefID='" + refid + "' AND ClientID=" + Globals.clientid;
                            SQLString2 += " AND DebitAccount='" + detail[i, 1] + "' AND CreditAccount='" + detail[i, 0] + "'";
                            //SQLString3 = " insert into " + tablename + "Detail(ClientID,CompanyCode,RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,StockID,CustomField5,CustomField4,Note) ";
                            //SQLString3 += "values(" + Globals.clientid + ",'" + Globals.companycode + "',newid(), '" + refid + "', N'" + detail[i, 7] + "', '" + detail[i, 1] + "', '" + detail[i, 0] + "', '" + detail[i, 5] + "', '" + detail[i, 6] + "', " + detail[i, 2] + ", '" + detail[i, 3] + "', '" + detail[i, 4] + "', " + i + ", " + detail[i, 8] + ", '" + detail[i, 9] + "', N'" + detail[i, 10] + "', N'" + detail[i, 11] + "')";

                            gen.ExcuteNonquery(SQLString2);
                        }
                    }                    
                    getactive("1");
                    string typename = gen.GetString2("FIDocumentType", "TypeName", "DocType", pt.ToUpper(), Globals.clientid);
                    Text = "Xem " + typename;
                    XtraMessageBox.Show("Phiếu đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSQL.Text = ex.Message + ex.StackTrace + ex.TargetSite.ToString() + SQLString2 + SQLString3;
                return;
            }
        }

        private void themsctmoi()
        {
            // them sct moi
            if (DateTime.Parse(ngaychungtu) >= DateTime.Parse("06/01/2019"))
            {
                int dai = 5;
                DataTable da = new DataTable();
                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                if (thang.Length < 2) thang = "0" + thang;
                string year = DateTime.Parse(ngaychungtu).Year.ToString();
                string sophieu = null;

                string donvi = gen.GetString("select BranchCode from MSC_User a, Branch b where a.BranchID=b.BranchID and a.UserID='" + Globals.userid + "'");
                string nam = "-" + thang + "-" + year.Substring(2, 2);
                sophieu = donvi + "-" + donvi + "-" + pt.ToString().ToUpper();
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from " + tablename + " where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and EditVersion='2'  order by RefNo DESC");
                    int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                    for (int i = 0; i < dai - ct.ToString().Length; i++)
                    {
                        sophieu = sophieu + "0";
                    }
                    sophieu = sophieu + ct.ToString() + nam;
                }
                catch { sophieu = sophieu + "00001" + nam; }

                txtsct.Text = sophieu;
                //checktruocsau(tsbttruoc, tsbtsau, sophieu, ngaychungtu, userid);
            }
        }

        private void themsct()
        {
            // them so chung tu
            int dai = 5;
            DataTable da = new DataTable();            
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string sophieu = null;
            string kho = ledv.EditValue.ToString(); // kho - don vi

            string donvi = gen.GetString("select BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and a.StockCode='" + kho + "'");
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            sophieu = donvi + "-" + kho + "-PTAM";
            try
            {
                string id = gen.GetString("select Top 1 CustomField5 from  " + tablename + " where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + gen.GetString("select StockID from Stock where StockCode='" + kho + "'") + "'  order by CustomField5 DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }

            txtsct.Text = sophieu;            
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            txtspt.Text = "";
            refreshrole();
            change();
            cbldt.SelectedIndex = 0;
            ledt.EditValue = "3";
            ledv.ItemIndex = 0;
            txtctg.Text = "";
            txtldn.Text = "";
            txtnn.Text = "";
            txtname.Text = "";
            txtdc.Text = "";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Now;
            if (pt == "pttm")
            {
                pttm.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid, ledv.EditValue.ToString());
                this.Text = "Thêm phiếu thu tiền mặt";
                tsbtcat.Visible = true;
                tsbtkc.Visible = true;
                tsbtkc.Enabled = false;
            }
            if (pt == "ptctm")
            {
                ptctm.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);
                this.Text = "Thêm phiếu thu tiền mặt";
            }
            else if (pt == "ptnh")
            {
                ptnh.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);
                this.Text = "Thêm phiếu thu ngân hàng";
            }
            else if (pt == "pctm")
            {
                pctm.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid, ledv.EditValue.ToString());
                this.Text = "Thêm phiếu chi tiền mặt";
                tsbtcat.Visible = true;
            }
            else if (pt == "pcnh")
            {
                pcnh.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);
                this.Text = "Thêm phiếu chi ngân hàng";
            }
            else if (pt == "pkt")
            {
                pkt.themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);
                this.Text = "Thêm phiếu kế toán";
            }
            cechd.Checked = false;
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            if (pt == "pttm")
                loadtm();
            /* else if (pt == "ptnh") refeshptnh();
             else if (pt == "pctm") refeshpctm();
             else if (pt == "pcnh") refeshpcnh();
             else if (pt == "pkt") refeshpkt();
             else if (pt == "ptctm") refeshptctm();*/
            change();
        }


        private void tsbtin_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(refid);

            string pt2 = pt; // cac phieu khac nhu PTTM 4 chu so, phieu ke toan pkt
            if (pt == "phkt") pt2 = "pkt";

            F.gettsbt(pt2);
            F.getcongty("CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            F.ShowDialog();
        }

        private void cechd_CheckedChanged(object sender, EventArgs e)
        {
            if (cechd.Checked == true)
            {
                gridView1.Columns[5].Visible = true;
                gridView1.Columns[4].Visible = true;
                gridView1.Columns[3].Visible = true;
                gridView1.Columns[2].Visible = true;
                gridView1.Focus();
            }
            else
            {
                gridView1.Columns[2].Visible = false;
                gridView1.Columns[3].Visible = false;
                gridView1.Columns[4].Visible = false;
                gridView1.Columns[5].Visible = false;
                gridView1.Focus();
            }
        }

        private void x()
        {
            if (tsbtcat.Enabled == true)
            {

                ledv.Enabled = true;
                if (active == "1")
                    if (pt == "pttm" || pt == "pctm")
                        ledv.Enabled = false;
                letq.Enabled = true;
                searchdanhmuc.Properties.ReadOnly = false;
                cbldt.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                txtnn.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                cechd.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                if (gridView1.RowCount < 14)
                {
                    gridView1.OptionsBehavior.Editable = true;
                }
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                if (active == "1")
                    tsbtnap.Enabled = true;
                tsbtsua.Enabled = false;
                if (tsbtkc.Visible == true)
                    tsbtkc.Enabled = true;
                tsbtghiso.Visible = false;
                ledv.Focus();
            }
            else
            {
                ledv.Enabled = false;
                letq.Enabled = false;
                searchdanhmuc.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtnn.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                cechd.Properties.ReadOnly = true;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                ledv.Focus();
            }
        }



        private void txtld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtctg.Focus();
        }
        private void cbthue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridView1.Focus();
        }
        private void txtctg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbthue.Focus();
        }


        private void nphhd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                if (gridView1.FocusedRowHandle > 0)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Ngày phát hành HĐ").ToString() != "")
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Ngày phát hành HĐ"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Ngày phát hành HĐ").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số hóa đơn"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Số hóa đơn").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Loại hóa đơn"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Loại hóa đơn").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Ký hiệu hóa đơn"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Ký hiệu hóa đơn").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle - 1, "Mã khách").ToString());
                    gridView1.FocusedColumn = gridView1.Columns["Số tiền"];
                }
            }
        }

        private void tsbtxoa_Click_1(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(refid);
            F.gettsbt(pt + "chitiet");
            F.ShowDialog();
        }


  
        private void Frm_phieuthuV2_Load(object sender, EventArgs e)
        {
            //dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            txtSQL.Visible = false; // de test thoi
            txtSQL.Text = refid;
            tsbttruoc.Visible = false; tsbtsau.Visible = false; tsbtadd.Visible = false;
            tsbtsua.Visible = false;
            txtCompanyCode.Text = Globals.companycode; txtCompanyCode.Enabled = false;


            taikhoan = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");            
            danhmuc = gen.GetTable("select STT,DebitAmout,CreditAmount from DANHMUC where Phieu='" + pt + "' order by STT");
            khach = gen.GetTable("select AccountingObjectID as 'ID',AccountingObjectCode as 'Mã khách hàng',AccountingObjectName as 'Tên khách',Address as 'Địa chỉ', CompanyTaxCode as 'Mã số thuế', ContactHomeTel as 'Đội' from AccountingObject with (NOLOCK) order by AccountingObjectCode");
            // ngay chung tu
            ngaychungtu = Globals.ngaychungtu;
            // them so chung tu
            //themsct();
            // table name
            tablename = gen.GetString2("FIDocumentType", "TableName", "DocType", pt.ToUpper(), Globals.clientid).Trim();

            labelControl13.Visible = false;
            txthtt.Visible = false;
            refreshrole();
            
            if (pt == "pttm")
            {
                letq.Visible = true;
                lbtq.Visible = true;
                toolptt.Visible = true;
                toolptt.Text = "In phiếu thu đơn vị";
                tsbtkc.Visible = true;
                tsbtkc.Text = "Duyệt tại đơn vị";
                lbspt.Visible = true;
                txtspt.Visible = true;                
            }
            else if (pt == "pctm")
            {
                labelControl1.Text = "Phiếu chi tiền mặt";
                labelControl4.Text = "   Người nhận       ";

                letq.Visible = true;
                lbtq.Visible = true;
                toolptt.Visible = true;

                lbspt.Visible = true;
                lbspt.Text = "Số phiếu chi";
                txtspt.Visible = true;
                
            }
            else if (pt == "ptnh")
            {
                labelControl1.Text = "Phiếu thu ngân hàng";
                labelControl13.Visible = true;
                txthtt.Visible = true;                
            }
            else if (pt == "pcnh")
            {
                labelControl1.Text = "Phiếu chi ngân hàng";
                labelControl4.Text = "   Người nhận       ";
                labelControl13.Visible = true;
                txthtt.Visible = true;                
            }
            else if (pt == "phkt")
            {
                labelControl1.Text = "Phiếu Kế toán";
                labelControl4.Text = "   Người nhận       ";
                labelControl13.Visible = true;
                txthtt.Visible = true;
                tsbtkc.Visible = true;                
            }
            change(); // enable cac button len
            loadtm(); // load cac form default len

            //XtraMessageBox.Show(pt + letq.Visible, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            radioGroup1.SelectedIndex = -1;
        }

        private void loadtm()
        {
            // load tien mat
            DataTable dt = new DataTable();
            //phieuchitm ctm = new phieuchitm();
            // ton quy
            letq.Properties.DataSource = gen.GetTable("select StockCode as 'Mã đơn vị',StockName as 'Tên đơn vị' from Stock order by StockCode ");
            letq.Properties.DisplayMember = "Mã đơn vị";
            letq.Properties.ValueMember = "Mã đơn vị";
            letq.Properties.PopupWidth = 300;


            // cho nay add column cho dt

            if (pt == "pttm" || pt == "ptnh")
            {
                dt.Columns.Add("Tài khoản có");
                dt.Columns.Add("Tài khoản nợ");
            }
            else
            {
                dt.Columns.Add("Tài khoản nợ");
                dt.Columns.Add("Tài khoản có");
            }
            dt.Columns.Add("Ngày phát hành HĐ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Số hóa đơn");
            dt.Columns.Add("Loại hóa đơn");
            dt.Columns.Add("Ký hiệu hóa đơn");
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã khách");
            dt.Columns.Add("Diễn giải");
            dt.Columns.Add("Nhóm chi phí");
            dt.Columns.Add("Ghi chú");
            gridControl1.DataSource = dt;

            gridView1.Columns["Tài khoản nợ"].ColumnEdit = tkco;
            gridView1.Columns["Tài khoản có"].ColumnEdit = repositoryItemLookUpEdit1;

            gridView1.Columns["Mã khách"].ColumnEdit = rpkh;
            //gridView1.Columns["Mã khách"].ColumnEdit = searchLookUpEdit1;

            gridView1.Columns["Ngày phát hành HĐ"].ColumnEdit = nphhd;
            gridView1.Columns["Số tiền"].ColumnEdit = sotien;
            gridView1.Columns["Diễn giải"].ColumnEdit = rpmanganh;
            gridView1.Columns["Nhóm chi phí"].ColumnEdit = rpmachiphi;

            gridView1.Columns["Diễn giải"].Width = 100;
            gridView1.Columns["Diễn giải"].Caption = "Mã ngành";
            gridView1.Columns["Loại hóa đơn"].Caption = "Mẫu số";

            gridView1.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số tiền"].SummaryItem.DisplayFormat = "Tổng tiền = {0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            loadstart(); // add column cho dt roi nhe, khoi tao cac bien

            if (active == "1")
            {
                DataTable da = new DataTable();
                string SQlString = "select  a.Description,CreditAccount, DebitAccount,Amount,AccountingObjectCode,InvDate,InvSeries,InvNo,CustomField5,CustomField4,Note from " + tablename + "Detail a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + refid + "' order by SortOrder";
                /*if(pt=="pctm") SQlString = "select  a.Description,DebitAccount,CreditAccount,Amount,AccountingObjectCode,InvDate,InvSeries,InvNo,CustomField5,CustomField4,Note from CAPaymentDetail a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + refid + "' order by SortOrder";
                if (pt == "pcnh") SQlString = "select  a.Description,DebitAccount,CreditAccount,Amount,AccountingObjectCode,InvDate,InvSeries,InvNo,CustomField5,CustomField4,Note from BATransferDetail a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + refid + "' order by SortOrder";
                if (pt == "ptnh") SQlString = "select  a.Description,CreditAccount,DebitAccount,Amount,AccountingObjectCode,InvDate,InvSeries,InvNo,CustomField5,CustomField4,Note from BATransferDetail a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + refid + "' order by SortOrder";*/
                da = gen.GetTable(SQlString);
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][1].ToString();
                    dr[1] = da.Rows[i][2].ToString();

                    if (da.Rows[i][5].ToString() != "")
                    {
                        dr[2] = DateTime.Parse(da.Rows[i][5].ToString());
                        cechd.Checked = true;
                    }
                    dr[3] = da.Rows[i][7].ToString();
                    dr[4] = da.Rows[i][6].ToString();
                    dr[5] = da.Rows[i][8].ToString();
                    dr[6] = da.Rows[i][3].ToString();
                    dr[7] = da.Rows[i][4].ToString();
                    dr[8] = da.Rows[i][0].ToString();
                    dr[9] = da.Rows[i][9].ToString();
                    dr[10] = da.Rows[i][10].ToString();
                    dt.Rows.Add(dr);
                }
                try
                {
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //MessageBox.Show(da.Rows.Count+"");
                txtSQL.Text = SQlString;


                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                Text = "Xem phiếu thu tiền mặt";
                if (pt == "pctm") Text = "Xem phiếu chi tiền mặt";
                if (pt == "pcnh") Text = "Xem phiếu chi ngân hàng";
                if (pt == "ptnh") Text = "Xem phiếu thu ngân hàng";
                if (pt == "phkt") Text = "Xem phiếu kế toán";

                SQlString = "select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,a.RefOrder,ShippingMethodID,EditVersion,a.CustomField5  from  " + tablename + " a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + refid + "'";               
                //if (pt == "pctm") SQlString ="select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,a.RefOrder,ShippingMethodID,EditVersion,a.CustomField5  from CAPayment a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + refid + "'";

                da = gen.GetTable(SQlString);
                try
                {
                    cbldt.SelectedIndex = Int32.Parse(da.Rows[0][9].ToString());
                }
                catch { }
                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                txtnn.Text = da.Rows[0][1].ToString();
                txtldn.Text = da.Rows[0][2].ToString();
                txtctg.Text = da.Rows[0][3].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][6].ToString();
                cbthue.Text = da.Rows[0][11].ToString();
                searchdanhmuc.EditValue = da.Rows[0][12].ToString(); //search lookitem

                //XtraMessageBox.Show(da.Rows[0][12].ToString(), "searchdanhmuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSQL.Text = SQlString;
                if (da.Rows[0][13].ToString() != "")
                    letq.EditValue = gen.GetString("select StockCode from Stock where StockID='" + da.Rows[0][13].ToString() + "'");

                if (da.Rows[0][8].ToString() == "True")
                {
                    tsbtghiso.Visible = false;
                    tsbtboghi.Visible = true;
                    tsbtsua.Enabled = false;
                }
                else
                {
                    tsbtboghi.Visible = false;
                    tsbtghiso.Visible = true;
                }
                if (da.Rows[0][10].ToString() == "True")
                {
                    tsbtboghi.Enabled = false;
                    tsbtghiso.Enabled = false;
                }

                if (da.Rows[0][14].ToString() == "2" || da.Rows[0][14].ToString() == "1")
                {
                    tsbtcat.Visible = false;
                    tsbtkc.Visible = false;
                }
                txtspt.Text = da.Rows[0][15].ToString();
                //checktruocsau(tsbttruoc, tsbtsau, txtsct.Text, ngaychungtu, userid);
            }
            else
            {
                /*try
                {*/
                Text = "Thêm phiếu thu tiền mặt";
                if (pt == "pctm") Text = "Thêm phiếu chi tiền mặt";
                //themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid, ledv.EditValue.ToString());
                denct.EditValue = DateTime.Parse(ngaychungtu);
                denht.EditValue = DateTime.Parse(ngaychungtu);
                cechd.Checked = true;
                cechd.Checked = false;
                /*}
                catch
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.Close();
                }*/
            }
        }

        private void loadstart()
        {
            // load start tien mat
            // ledt doi tuong
            ledt.Properties.View.Columns.Clear();
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
            ledt.Properties.DataSource = temp;
            ledt.Properties.DisplayMember = "Mã khách";
            ledt.Properties.ValueMember = "Mã khách";
            ledt.Focus();

            //////

            cbldt.Properties.Items.Clear();
            cbldt.Properties.Items.Add("Khách hàng");
            cbldt.Properties.Items.Add("Nhà cung cấp");
            cbldt.Properties.Items.Add("Nhân viên");
            cbldt.SelectedIndex = 0;

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            DataTable da = new DataTable();
            temp = new DataTable();

            temp.Columns.Add("Mã đơn vị");
            temp.Columns.Add("Tên đơn vị");
            //da = gen.GetTable("select * from Stock order by StockCode");
            da = gen.GetTable("select a.StocKID,StockCode,StockName from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='" + Globals.userid + "' order by StockCode ");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã đơn vị";
            ledv.Properties.ValueMember = "Mã đơn vị";
            ledv.ItemIndex = 0;
            ledv.Properties.PopupWidth = 300;

            
            da = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
            
            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã tài khoản");
            temp1.Columns.Add("Tên tài khoản");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp1.Rows.Add(dr);
            }

            if (pt == "pttm" || pt == "pctm")

                da = gen.GetTable("select AccountNumber,AccountName from Account where AccountCategoryID=111 and AccountNumber<>111 order by AccountNumber");

            DataTable temp2 = new DataTable();
            temp2.Columns.Add("Mã tài khoản");
            temp2.Columns.Add("Tên tài khoản");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp2.Rows.Add(dr);
            }
            if (pt == "pttm" || pt == "ptnh")
            {
                repositoryItemLookUpEdit1.DataSource = temp1;
                repositoryItemLookUpEdit1.DisplayMember = "Mã tài khoản";
                repositoryItemLookUpEdit1.ValueMember = "Mã tài khoản";
                tkco.DataSource = temp2;
                tkco.DisplayMember = "Mã tài khoản";
                tkco.ValueMember = "Mã tài khoản";
            }
            else
            {
                tkco.DataSource = temp1;
                tkco.DisplayMember = "Mã tài khoản";
                tkco.ValueMember = "Mã tài khoản";

                repositoryItemLookUpEdit1.DataSource = temp2;
                repositoryItemLookUpEdit1.DisplayMember = "Mã tài khoản";
                repositoryItemLookUpEdit1.ValueMember = "Mã tài khoản";
            }
            repositoryItemLookUpEdit1.PopupWidth = 200;

            // khach hang o lineitem
            DataTable temp3 = new DataTable();
            temp3.Columns.Add("Mã đối tượng");
            temp3.Columns.Add("Tên đối tượng");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp3.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp3.Rows.Add(dr);
            }
            rpkh.DataSource = temp3;
            rpkh.DisplayMember = "Mã đối tượng";
            rpkh.ValueMember = "Mã đối tượng";
            rpkh.PopupWidth = 400;


            rpmanganh.DataSource = gen.GetTable("select InventoryCategoryCode as 'Mã ngành',InventoryCategoryName as 'Tên ngành' from InventoryItemCategory where IsParent=0 and Grade=3 and Inactive='False' order by InventoryCategoryCode");
            rpmanganh.DisplayMember = "Mã ngành";
            rpmanganh.ValueMember = "Mã ngành";
            rpmanganh.PopupWidth = 100;

            rpmachiphi.DataSource = gen.GetTable("select GroupCostID as 'Mã chi phí',GroupCost as 'Chi phí' from GroupCost Order by GroupCostID");
            rpmachiphi.DisplayMember = "Chi phí";
            rpmachiphi.ValueMember = "Mã chi phí";
            rpmachiphi.PopupWidth = 200;
            // search edit danh muc
            string pt2 = pt; // cac phieu khac nhu PTTM 4 chu so, phieu ke toan pkt
            if (pt=="phkt") pt2="pkt";
            string SQLString = "SELECT STT,DanhMuc as 'Danh mục',STUFF((SELECT Distinct ' ' + DebitAmout FROM (select * from danhmuc where Phieu='" + pt2 + "') T ";
            SQLString += "WHERE (STT = S.STT) FOR XML PATH ('')),1,1,'') as 'Tài khoản nợ',STUFF((SELECT Distinct ' ' + CreditAmount FROM (select * from danhmuc where Phieu='" + pt2 + "') T ";
            SQLString += "WHERE (STT = S.STT) FOR XML PATH ('')),1,1,'') AS 'Tài khoản có' FROM (select * from danhmuc where Phieu='" + pt2 + "') S GROUP BY STT,DanhMuc";
            searchdanhmuc.Properties.DataSource = gen.GetTable(SQLString);
            searchdanhmuc.Properties.DisplayMember = "Danh mục";
            searchdanhmuc.Properties.ValueMember = "STT";

            searchdanhmuc.Properties.View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            searchdanhmuc.Properties.View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            searchdanhmuc.Properties.PopupFormSize = new Size(700, 500);
            searchdanhmuc.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;

           

            cechd.Checked = false;
        }

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            /*for (int i = 0; i < khach.Rows.Count; i++)
            {
                if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                {
                    txtname.Text = khach.Rows[i][2].ToString();
                    txtdc.Text = khach.Rows[i][3].ToString();
                    return;
                }
            }*/
            // viet lai
            txtname.Text = gen.GetString2("AccountingObject", "AccountingObjectName", "AccountingObjectCode", ledt.EditValue.ToString(),Globals.clientid);
            txtdc.Text = gen.GetString2("AccountingObject", "Address", "AccountingObjectCode", ledt.EditValue.ToString(), Globals.clientid);
        }

        private void searchdanhmuc_EditValueChanged_1(object sender, EventArgs e)
        {

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
            //XtraMessageBox.Show(khach.Rows.Count + "", "radioGroup1_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void view_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            // click vao thay doi ten khach hang
            try
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã khách").ToString() == khach.Rows[i][1].ToString())
                    {
                        textEdit2.Text = khach.Rows[i][2].ToString(); // ten khach hang
                        break;
                    }
                }
            }
            catch
            {
                textEdit2.Text = null;
            }

            try
            {
                for (int i = 0; i < taikhoan.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString() == taikhoan.Rows[i][0].ToString())
                    {
                        textEdit1.Text = taikhoan.Rows[i][0].ToString() + " - " + taikhoan.Rows[i][1].ToString(); // TK No
                        break;
                    }
                }
            }
            catch
            {
                textEdit1.Text = null;
            }

            try
            {
                for (int i = 0; i < taikhoan.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() == taikhoan.Rows[i][0].ToString())
                    {
                        textEdit3.Text = taikhoan.Rows[i][0].ToString() + " - " + taikhoan.Rows[i][1].ToString(); // Tk co
                        break;
                    }
                }
            }
            catch
            {
                textEdit3.Text = null;
            }
        }

        private void letq_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (K == -1)
            {
                ledt.EditValue = searchLookUpEdit1.EditValue;
                ledt.Focus();
            }
            else if (K != -1)
            {
                try
                {
                    string temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tài khoản có").ToString();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], searchLookUpEdit1.EditValue);
                    gridView1.Focus();
                }
                catch
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã khách"], searchLookUpEdit1.EditValue);
                    gridView1.Focus();
                }
            }
        }

        private void Frm_phieuthuV2_KeyUp(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (tsbtxoa.Enabled == true)
                    tsbtxoa_Click_1(this, e);
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
        }



        private void tsbtkc_Click(object sender, EventArgs e)
        {

        }

        private void btdulieu_Click(object sender, EventArgs e)
        {
            string ngaycuoi = DateTime.Parse(DateTime.Parse(denht.EditValue.ToString()).ToShortDateString()).AddDays(1).AddSeconds(-1).ToString();
            string ngaydau = DateTime.Parse(denht.EditValue.ToString()).ToShortDateString();
            //pttm.loadStockmain(lenv, ngaydau, ngaycuoi, ledv.Text);
        }

        private void searchdanhmuc_EditValueChanged(object sender, EventArgs e)
        {
            if (tsbtcat.Enabled == true) // nut luu
            {
                while (gridView1.RowCount > 1)
                {
                    gridView1.DeleteRow(0);
                }
                for (int i = 0; i < danhmuc.Rows.Count; i++) // add tu dong detail tu table danh muc vao  TK No/co
                {
                    if (danhmuc.Rows[i][0].ToString() == searchdanhmuc.EditValue.ToString())
                    {
                        gridView1.AddNewRow();
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản nợ"], danhmuc.Rows[i][1].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tài khoản có"], danhmuc.Rows[i][2].ToString());
                        gridView1.Focus();
                        return;
                    }
                }
            }
        }

        private void toolptt_Click(object sender, EventArgs e)
        {
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getrole(refid);
            if (pt == "pttm")
                F.gettsbt(pt + "donvi");
            else if (pt == "pctm")
                F.gettsbt(pt + "bangkethanhtoan");
            F.ShowDialog();
        }

        private void toolduyet_Click(object sender, EventArgs e)
        {
            ledt.Focus();
            if (cbthue.Text != "")
                try
                {
                    Double.Parse(cbthue.Text);
                }
                catch
                {
                    XtraMessageBox.Show("Thuế suất không đúng định dạng. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            checkpttm("2", "1");
            XtraMessageBox.Show("Phiếu đã duyệt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            /*luu log
             * if (active == "1")
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Duyệt','" + txtsct.Text + "')");
            else
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Duyệt','" + txtsct.Text + "')");
            */
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            /*if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;*/
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            themsct();
            if (active == "0")
                letq.EditValue = ledv.EditValue;
        }
    }
}