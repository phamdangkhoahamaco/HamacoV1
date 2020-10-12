using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources; // import bo thu vien cua HAMACO
using DevExpress.XtraSplashScreen;
using System.Data.Entity.Infrastructure;

namespace HAMACO
{
    public partial class Frm_DNDH : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        dondathang ddh = new dondathang();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        DataTable hangton = new DataTable();
        DataTable hangtoncungungthucte = new DataTable();
        int nhan = 0;
        Double congnotam = 0, trongluongtam = 0, laisuat = 0, tonkhotam = 0;
        int chon = 0;
        DataTable hangtoncungung = new DataTable();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, phieu, caseup, roleid, subsys, click, loi, phieucl, ngaygiadieu, mahangcl, hoadondieu, hopdong = null;

        private void tsbtcat_Click(object sender, EventArgs e) // luu thong tin
        {
            ledt.Focus();
            ngaychungtu = Globals.ngaychungtu;

            if (phieu == "tsbtcdh")
                if (radioGroup3.SelectedIndex != 0 && radioGroup3.SelectedIndex != 1)
                {
                    XtraMessageBox.Show("Vui lòng chọn nơi xuất chuyển kho <Từ công ty> hoặc <Từ nhà máy>.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            Double dasudung = 0;
            Double luongchia = 0;

            string kho = "";
            string donvi = "";
            try
            {
                kho = gen.GetString("select StockId from Stock where StockCode='" + ledvnhan.EditValue.ToString() + "'");
                donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ///txtSQL.Text = sql;
            }
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();




            if (radioGroup2.SelectedIndex == 1 && gen.GetString("select Top 1 CompanyTaxCode from Center") == "1800506679")
            {
                Double dangky = 0;

                Double hientai = 0;
                try
                {
                    dangky = Double.Parse(gen.GetString("select COALESCE(sum(AmountStock),0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));

                    hientai = Double.Parse(gen.GetString("baocaotonkhotheothangtheodonvikiemtra '" + donvi + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'"));
                    hientai = hientai + Double.Parse(gen.GetString("select COALESCE(SUM(TotalAmount),0) from DDHNCC a, Stock b where a.StockID=b.StockID and BranchID='" + donvi + "' and  MONTH(RefDate)='" + thang + "' and YEAR(RefDate)='" + nam + "' and Posted is NULL and RefType='1'")) - tonkhotam + Double.Parse(txtgiavon.EditValue.ToString());
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dangky < hientai)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tồn kho hiện tại " + String.Format("{0:n0}", hientai) + " đồng so với mức đăng ký là " + String.Format("{0:n0}", dangky) + " đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (phieucl != null)
            {
                try
                {
                    dasudung = Double.Parse(gen.GetString("select TotalTransport from DDHCL where RefNo='" + phieucl + "'"));
                    luongchia = Double.Parse(gen.GetString("select TotalAmount from DDHCL where RefNo='" + phieucl + "'"));
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString().Substring(0, 3) != mahangcl.Substring(0, 3) || ViewVAT.GetRowCellValue(i, "Mã hàng").ToString().Substring(7, 2) != mahangcl.Substring(7, 2))
                    {
                        XtraMessageBox.Show("Vui lòng đặt đúng loại hàng được chia.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                if (dasudung - trongluongtam + Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText) > luongchia + luongchia * 2 / 100)
                {
                    XtraMessageBox.Show("Trọng lượng vượt quá đơn hàng được chia.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            kiemtrahangam(); // kiem tra hang am
            if (ledvnhan.EditValue.ToString() == "13" || ledvnhan.EditValue.ToString() == "16")
                if (phieu == "tsbtddh" && chdxck.Checked == false)
                {
                    for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                    {
                        if (ViewVAT.GetRowCellValue(i, "Âm kho").ToString() == "1")
                        {
                            XtraMessageBox.Show("Có hàng âm trong đơn hàng vui lòng kiểm tra lại hoặc đặt vào kho khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

            if (radioGroup2.SelectedIndex == 0 && phieu == "tsbtddh")
            {
                if (txtnv.Text == "")
                {
                    XtraMessageBox.Show("Bạn chưa nhập nhân viên bán hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string Prefix = "";
                double ExitsMoney = 0;
                try
                {
                    Prefix = gen.GetString("select Prefix from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                    ExitsMoney = Double.Parse(gen.GetString("select COALESCE(sum(ExitsMoney),0) from OpenExDate where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and DateEx>30 and AccountingObjectID='" + gen.GetString("select AccountingObjectID  from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "' ") + "'"));
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Prefix != "1")
                    if (ExitsMoney > 1000000)
                    {
                        XtraMessageBox.Show("Khách hàng có quá hạn trên 30 ngày vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                string giaban = txtcth.EditValue.ToString();
                if (txtpxk.Text != "")
                    giaban = txtgxk.EditValue.ToString();

                if ((Double.Parse(txtgiavon.EditValue.ToString()) - Double.Parse(giaban)) / Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText) > Double.Parse(gen.GetString("select Top 1 Dongia from Center")) && phieu == "tsbtddh")
                {
                    XtraMessageBox.Show("Đơn giá bán chưa hợp lý, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Double.Parse(txtcth.EditValue.ToString()) < 0)
                {
                    XtraMessageBox.Show("Thành tiền chưa đúng vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        if (hopdong != sehd.Text)
                            congnotam = 0;
                        break;
                    }

                if (chdxck.Checked == false)
                {
                    Double phantram = 0;
                    Double dinhmuc = 0;
                    try
                    {
                        phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (phantram > 0 && phantram < 0.5)
                        dinhmuc = 100000000;
                    else if (phantram >= 0.5)
                        dinhmuc = 300000000;

                    if (Double.Parse(txthm.EditValue.ToString()) + Double.Parse(txthm.EditValue.ToString()) * phantram < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam || Double.Parse(txthm.EditValue.ToString()) + dinhmuc < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam)
                    {
                        XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt định mức cho phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                Double hientai = 0;
                Double dangky = 0;
                try
                {
                    hientai = Double.Parse(gen.GetString("baocaocongnokiemtra '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'"));
                    hientai = hientai + Double.Parse(txttc.EditValue.ToString()) - congnotam;
                    dangky = Double.Parse(gen.GetString("select COALESCE(AmountMax,0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dangky < hientai)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ hiện tại " + String.Format("{0:n0}", hientai) + " đồng so với mức đăng ký là " + String.Format("{0:n0}", dangky) + " đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            checkpxk(); // check phieu xuat kho

            if (loi != "1") // khong bi loi
            {
                /*if (active == "1")
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
                else
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");*/
                active = "1";
                refreshrole();
                click = "true";
                change();
                status();
                click = "false";

                congnotam = Double.Parse(txttc.EditValue.ToString());
                tonkhotam = Double.Parse(txtgiavon.EditValue.ToString());
                hopdong = sehd.Text;

                // update sau
                //if (txtpxk.Text != "") 
                // gen.ExcuteNonquery("Update a Set a.CustomField1= Round(b.CustomField4/a.QuantityConvert,2), a.CustomField2=b.CustomField4 From (select * from INOutwardDetail where RefID='" + gen.GetString("select RefID from INOutward where RefNo='" + txtpxk.Text + "'") + "') a , ( select * from DDHDetail where RefID='" + role + "') b  where a.InventoryItemID = b.InventoryItemID  and a.Quantity = b.Quantity ");

                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        break;
                    }

                if (phieucl != null)
                {
                    // update sau
                    //gen.ExcuteNonquery("Update DDHCL set TotalTransport=(select sum(QuantityConvertExits) as trongluong from DDH a, DDHDetail b where a.RefID=b.RefID and RefNoCL='" + phieucl + "') where RefNo='" + phieucl + "'");
                    trongluongtam = Double.Parse(ViewCU.Columns["Trọng lượng"].SummaryText);
                }
            }
            else
                loi = "0";

            //     XtraMessageBox.Show("Toi day chua ku", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void status()
        {
            if (phieu == "tsbtddh")
            {
                lbtenddh.Text = "Đơn đặt hàng";
                radioGroup3.Enabled = false;
                chdxck.Enabled = false;

                if (chot.Checked == true)
                {
                    chot.Enabled = false;
                    ledvnhan.Enabled = false;
                }
                else
                    chot.Enabled = true;

                if (chdxck.Checked == true)
                    chgbct.Enabled = false;
                else
                    chgbct.Enabled = true;

                ViewCU.OptionsBehavior.Editable = false;

                if (chdxck.Checked == true && tsbtsua.Enabled == true)
                    chdn.Enabled = true;
                else
                    chdn.Enabled = false;

                dendh.Enabled = true;
                if (radioGroup2.SelectedIndex == 0)
                {
                    btbbgnhtsl.Visible = true;
                    btbbgnh.Visible = true;
                    btbbgnhtl.Visible = true;
                    btbbgnhkxnn.Visible = true;
                }
                if (txtsctchuyen.Text != "")
                {
                    btpnck.Visible = true;
                    if (radioGroup2.SelectedIndex == 0 && chdxck.Checked == true)
                    {
                        btcpxk.Visible = true;
                        btcpxkttt.Visible = true;
                    }
                }
                if (txtpxk.Text != "")
                {
                    btcpxk.Enabled = false;
                    btcpxkttt.Enabled = false;
                    btchd.Visible = true;
                    sbok.Visible = true;
                    chgbct.Enabled = false;
                    dengd.Enabled = false;
                }
                else
                {
                    btcpxk.Enabled = true;
                    btcpxkttt.Enabled = true;
                    btchd.Visible = false;
                    sbok.Visible = false;
                }

                if (chdxck.Checked == true || chot.Checked == true)
                {
                    ViewVAT.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["ĐG số lượng"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;
                    ViewVAT.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    ViewVAT.Columns["Số lượng"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["Trọng lượng"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["ĐG số lượng"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["Đơn giá"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["Thành tiền"].OptionsColumn.AllowEdit = true;
                    ViewVAT.Columns["Mã hàng"].OptionsColumn.AllowEdit = true;
                    if (chduyet.Checked == true)
                        ViewVAT.Columns["Giảm giá"].OptionsColumn.AllowEdit = false;
                    else
                        ViewVAT.Columns["Giảm giá"].OptionsColumn.AllowEdit = true;
                }
            }
            else if (phieu == "tsbtcdh")
            {

                if (chot.Checked == true)
                {
                    chot.Enabled = true;
                    ledvnhan.Enabled = false;
                }
                else
                    chot.Enabled = false;

                lbtenddh.Text = "Chuyển đơn hàng";
                radioGroup2.Enabled = false;
                chnhtk.Enabled = false;
                ViewVAT.OptionsBehavior.Editable = false;
                ViewNOVAT.OptionsBehavior.Editable = false;
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
                if (radioGroup2.SelectedIndex == 0)
                {
                    btbbgnhtsl.Visible = true;
                    btbbgnh.Visible = true;
                    btbbgnhtl.Visible = true;
                    btbbgnhkxnn.Visible = true;
                }
                if (radioGroup3.SelectedIndex == 0)
                {
                    ViewCU.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Bốc xếp"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Vận chuyển"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["ĐG bốc xếp"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["ĐG vận chuyển"].OptionsColumn.AllowEdit = false;
                }
                if (chdn.Checked == true)
                {
                    ViewCU.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;
                }
                /*
                ViewCU.Columns["Số lượng"].OptionsColumn.AllowEdit = true;
                ViewCU.Columns["Trọng lượng"].OptionsColumn.AllowEdit = true;
                ViewCU.Columns["Đơn giá"].OptionsColumn.AllowEdit = true;
                ViewCU.Columns["Thành tiền"].OptionsColumn.AllowEdit = true;
                */
                denct.Enabled = true;
                if (txtsctchuyen.Text != "")
                {
                    btpxck.Visible = true;
                    btpxkkvcnb.Visible = true;
                }
            }
            else if (phieu == "tsbtddhtk")
            {
                lbtenddh.Text = "Đơn đặt hàng tại kho";

                if (chot.Checked == true)
                {
                    chot.Enabled = true;
                    ledvnhan.Enabled = false;
                }
                else
                    chot.Enabled = false;

                radioGroup2.Enabled = false;
                chnhtk.Enabled = false;
                if (chnhtk.Checked == false)
                    radioGroup3.Enabled = false;
                xtraTabPage2.PageVisible = false;
                xtraTabPage4.PageVisible = false;

                if (chdn.Checked == true)
                {
                    ViewCU.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    ViewCU.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
                }
                ViewCU.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
                ViewCU.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;
                denct.Enabled = true;
                if (radioGroup2.SelectedIndex == 0)
                {
                    btbbgnhtsl.Visible = true;
                    btbbgnh.Visible = true;
                    btbbgnhtl.Visible = true;
                    btbbgnhkxnn.Visible = true;
                }
                if (txtsctchuyen.Text != "")
                {
                    btpxck.Visible = true;
                    btpxkkvcnb.Visible = true;
                }
            }

            if (chhc.Checked == true)
                chhc.Enabled = false;
        }
        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                {
                    ledvnhan.Properties.ReadOnly = false;
                    legd.Properties.ReadOnly = false;
                    ledvdat.Properties.ReadOnly = false;
                }
                if (txtsctchuyen.Text == "")
                {
                    ledvnhan.Properties.ReadOnly = false;
                    legd.Properties.ReadOnly = false;
                }

                txtdienthoai.Properties.ReadOnly = false;
                denct.Properties.ReadOnly = false;
                dendh.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                lenv.Properties.ReadOnly = false;
                txtname.Properties.ReadOnly = false;
                txtdc.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                cbthue.Properties.ReadOnly = false;
                ViewVAT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                ViewVAT.OptionsBehavior.Editable = true;
                ViewCU.OptionsBehavior.Editable = true;
                ViewNOVAT.OptionsBehavior.Editable = true;
                txtngh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptgh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;
                txtptvc.Properties.ReadOnly = false;
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                chhc.Enabled = true;

                if (active == "1")
                {
                    tsbtnap.Enabled = true;
                    if (phieu == "tsbtddhtk" && chdn.Checked == false)
                    {
                        chdxck.Enabled = true;
                        if (chnhtk.Checked == true)
                            radioGroup3.Enabled = true;
                    }
                    else if (phieu == "tsbtcdh")
                    {
                        if (chdn.Checked == false && radioGroup3.SelectedIndex.ToString() == "1")
                        {
                            chdxck.Enabled = true;
                            radioGroup3.Enabled = true;
                        }
                        else if (chdn.Checked == false)
                        {
                            radioGroup3.Enabled = true;
                        }
                    }
                    else if (phieu == "tsbtddh")
                        chvctc.Enabled = true;
                }
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                sehd.Properties.ReadOnly = false;
                ledt.Focus();
            }
            else
            {
                txtdienthoai.Properties.ReadOnly = true;
                ledvnhan.Properties.ReadOnly = true;
                legd.Properties.ReadOnly = true;
                ledvdat.Properties.ReadOnly = true;
                lenv.Properties.ReadOnly = true;
                txtname.Properties.ReadOnly = true;
                txtdc.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                dendh.Properties.ReadOnly = true;
                txtptgh.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                ViewVAT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                ViewVAT.OptionsBehavior.Editable = false;
                ViewCU.OptionsBehavior.Editable = false;
                ViewNOVAT.OptionsBehavior.Editable = false;
                txtngh.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                txtptvc.Properties.ReadOnly = true;
                sehd.Properties.ReadOnly = true;
                chhc.Enabled = false;
                chvctc.Enabled = false;
                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                ledt.Focus();
            }
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
                if (phieu == "tsbtddh")
                    tsbtadd.Enabled = true;
            }
            else
            {
                tsbtnap.Enabled = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "ADD" && phieu == "tsbtddh")
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

        private void checkpxk() // check va luu phieu xuat kho
        {
            try
            {
                string dt = "";
                try {
                dt= gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtSQL.Text = sql;
                }
                

                string[,] detail = new string[30, 30];
                string rolexuat = null;
                string check = "0";
                for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                {
                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() == "")
                        check = "1";
                    else
                    {
                        string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        detail[i, 0] = mh;
                    }
                    if (ViewVAT.GetRowCellValue(i, "Số lượng").ToString() == "")
                        detail[i, 1] = "0";
                    else
                        detail[i, 1] = ViewVAT.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewVAT.GetRowCellValue(i, "Trọng lượng").ToString() == "")
                        check = "1";
                    detail[i, 2] = ViewVAT.GetRowCellValue(i, "Trọng lượng").ToString().Replace(".", "").Replace(",", ".");

                    if (ViewNOVAT.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail[i, 3] = ViewNOVAT.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewNOVAT.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 4] = ViewNOVAT.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");

                    if (ViewVAT.GetRowCellValue(i, "ĐG bốc xếp").ToString() == "")
                        detail[i, 5] = "0";
                    else
                        detail[i, 5] = ViewVAT.GetRowCellValue(i, "ĐG bốc xếp").ToString().Replace(".", "").Replace(",", ".");

                    if (ViewVAT.GetRowCellValue(i, "Bốc xếp").ToString() == "")
                        detail[i, 6] = "0";
                    else
                        detail[i, 6] = ViewVAT.GetRowCellValue(i, "Bốc xếp").ToString().Replace(".", "").Replace(",", ".");

                    if (ViewVAT.GetRowCellValue(i, "ĐG vận chuyển").ToString() == "")
                        detail[i, 7] = "0";
                    else
                        detail[i, 7] = ViewVAT.GetRowCellValue(i, "ĐG vận chuyển").ToString().ToString().Replace(".", "").Replace(",", ".");
                    if (ViewVAT.GetRowCellValue(i, "Vận chuyển").ToString() == "")
                        detail[i, 8] = "0";
                    else
                        detail[i, 8] = ViewVAT.GetRowCellValue(i, "Vận chuyển").ToString().Replace(".", "").Replace(",", ".");


                    if (ViewCU.GetRowCellValue(i, "Số lượng").ToString() == "")
                        detail[i, 9] = "0";
                    else
                        detail[i, 9] = ViewCU.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewCU.GetRowCellValue(i, "Trọng lượng").ToString() == "")
                        detail[i, 10] = "0";
                    else
                        detail[i, 10] = ViewCU.GetRowCellValue(i, "Trọng lượng").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewCU.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        detail[i, 11] = "0";
                    else
                        detail[i, 11] = ViewCU.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewCU.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        detail[i, 12] = "0";
                    else
                        detail[i, 12] = ViewCU.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewCU.GetRowCellValue(i, "ĐG bốc xếp").ToString() == "")
                        detail[i, 13] = "0";
                    else
                        detail[i, 13] = ViewCU.GetRowCellValue(i, "ĐG bốc xếp").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewCU.GetRowCellValue(i, "Bốc xếp").ToString() == "")
                        detail[i, 14] = "0";
                    else
                        detail[i, 14] = ViewCU.GetRowCellValue(i, "Bốc xếp").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewCU.GetRowCellValue(i, "ĐG vận chuyển").ToString() == "")
                        detail[i, 15] = "0";
                    else
                        detail[i, 15] = ViewCU.GetRowCellValue(i, "ĐG vận chuyển").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewCU.GetRowCellValue(i, "Vận chuyển").ToString() == "")
                        detail[i, 16] = "0";
                    else
                        detail[i, 16] = ViewCU.GetRowCellValue(i, "Vận chuyển").ToString().Replace(".", "").Replace(",", ".");

                    if (ViewVAT.GetRowCellValue(i, "ĐG số lượng").ToString() == "")
                        detail[i, 19] = "0";
                    else
                        detail[i, 19] = ViewVAT.GetRowCellValue(i, "ĐG số lượng").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewVAT.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        detail[i, 17] = "0";
                    else
                        detail[i, 17] = ViewVAT.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (ViewVAT.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        detail[i, 18] = "0";
                    else
                        detail[i, 18] = ViewVAT.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "").Replace(",", ".");

                    if (ViewVAT.GetRowCellValue(i, "Giảm giá").ToString() == "")
                        detail[i, 20] = "0";
                    else
                        detail[i, 20] = ViewVAT.GetRowCellValue(i, "Giảm giá").ToString().Replace(".", "").Replace(",", ".");

                    if (ViewVAT.GetRowCellValue(i, "Phí khác").ToString() == "")
                        detail[i, 21] = "0";
                    else
                        detail[i, 21] = ViewVAT.GetRowCellValue(i, "Phí khác").ToString().Replace(".", "").Replace(",", ".");

                    if (ViewVAT.GetRowCellValue(i, "Chi phí khác").ToString() == "")
                        detail[i, 22] = "0";
                    else
                        detail[i, 22] = ViewVAT.GetRowCellValue(i, "Chi phí khác").ToString().Replace(".", "").Replace(",", ".");
                }

                if (check == "1")
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Trọng lượng> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    getloi("1");
                    return;
                }
                else
                {
                    
                    string dv = "";
                    string dvn = "";
                    try {
                        dv = gen.GetString("select stockid from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
                        dvn = gen.GetString("select stockid from Stock where StockCode='" + ledvnhan.EditValue.ToString() + "'");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    int xuatchuyen = -1;
                    // cung ung
                    if (radioGroup3.SelectedIndex == 0) 
                        xuatchuyen = 0;
                    else if (radioGroup3.SelectedIndex == 1)
                        xuatchuyen = 1;

                    string cathang = "0";
                    if (chnhtk.Checked == true) // hangcat
                        cathang = "1";

                    string tongthanhtien = txtcth.EditValue.ToString().Replace(".", "");
                    string thue = txttthue.EditValue.ToString().Replace(".", "");
                    string giavon = txtgiavon.EditValue.ToString().Replace(".", "");
                    string bocxep = txtbx.EditValue.ToString().Replace(".", "");
                    string vanchuyen = txtvc.EditValue.ToString().Replace(".", "");
                    string phikhac = txtpk.EditValue.ToString().Replace(".", "");

                    string sql = "";

                    if (chgbct.Checked == false)
                    {
                        //if (Double.Parse(ViewVAT.Columns["Thành tiền"].SummaryText) != Double.Parse(tongthanhtien) + Double.Parse(thue))
                        if (Double.Parse(ViewVAT.Columns["Thành tiền"].SummaryText) != Double.Parse(txttc.Text))
                        {
                            XtraMessageBox.Show("Tổng tiền có thuế và chưa thuế không đúng vui lòng kiểm tra lại!" + tongthanhtien + thue, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            getloi("1");
                            return;
                        }
                    }
                    else if (Double.Parse(ViewVAT.Columns["Thành tiền"].SummaryText) != Double.Parse(tongthanhtien))
                    {
                        XtraMessageBox.Show("Tổng tiền thuế không đúng vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        getloi("1");
                        return;
                    }

                    string congno = "0";
                    string loaixuatchuyen = "0";
                    try
                    {
                        congno = txtcn.EditValue.ToString().Replace(".", "");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Vui long bam nut kiem tra cong no", "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //XtraMessageBox.Show("toi day chua ku23", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string nv = "NULL";
                    try
                    {
                        nv = "'" + gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + lenv.EditValue.ToString() + "'") + "'";
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //XtraMessageBox.Show("toi day chua ku2", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from DDH where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledvnhan.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            //XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        /*try
                        {*/
                        // hangban??? radioGroup2 --> chuyenkho --. chdxck
                        string mySQL = "insert into DDH(RefID, RefDate, RefNo, AccountingObjectID, AccountingObjectCode, AccountingObjectName, AccountingObjectAddress, Contactname, JournalMemo, DocumentIncluded, Posted, InStockID, AccountingObjectType, ShippingNo, Tax, EmployeeID, EmployeeIDSA, TotalFreightAmount, TotalAmount, TotalAmountOC, Cancel, ReceiveMethod, OutStockID, Sale, Stock, InOut, Factory, CostCap, PostedDate, Initialization, Notax, TotalCost, TotalTransport, OriginalRefNo, Received, Chot, Taixe, CMND, Dienthoai, GDT, RefNoCL, RefDateCL, TotalVATAmount, RefIDInvoice) ";
                        mySQL += " values(newid(), '" + denct.EditValue.ToString() + "', '" + txtsct.Text + "', '" + dt + "', '" + ledt.EditValue.ToString() + "', N'" + txtname.Text + "', N'" + txtdc.Text + "', N'" + txtngh.Text + "', N'" + txtldn.Text + "', N'" + txtctg.Text + "', 'False', '";
                        mySQL += dvn + "', '" + cathang + "', N'" + txtptvc.Text + "', '" + cbthue.Text + "', '" + userid + "', " + nv + ", '" + congno + "', '" + tongthanhtien + "', '" + thue + "', 'True', N'" + txtptgh.Text + "', '" + dv + "', '";
                        mySQL += radioGroup2.SelectedIndex.ToString() + "', '" + xuatchuyen + "', '" + chdxck.Checked + "', NULL, '" + giavon + "', '" + dendh.EditValue.ToString() + "', '" + DateTime.Now.ToString() + "', '" + chgbct.Checked + "', '" + bocxep + "', '" + vanchuyen + "', '";
                        mySQL += txtdienthoai.Text + "', '" + chnhtk.Checked + "', '" + chot.Checked + "', N'" + txttaixe.Text + "', N'" + txtcmnd.Text + "', '" + txtsdttaixe.Text + "', '" + legd.EditValue.ToString() + "', '" + phieucl + "', '" + ngaygiadieu + "', '" + phikhac + "', '" + chvctc.Checked + "')";
                        //gen.ExcuteNonquery(mySQL); --> viet lai sau
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("insert into DDH(RefID,RefDate,RefNo,AccountingObjectID,AccountingObjectCode,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,InStockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,ReceiveMethod,OutStockID,Sale,Stock,InOut,Factory,CostCap,PostedDate,Initialization) values(newid(),'" + denct.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "','" + ledt.EditValue.ToString() + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dvn + "','" + cathang + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + congno + "','" + tongthanhtien + "','" + thue + "','True',N'" + txtptgh.Text + "','" + dv + "','" + hangban.SelectedIndex.ToString() + "','" + xuatchuyen + "','" + chuyenkho.Checked + "',NULL,'" + giavon + "','" + dendh.EditValue.ToString() + "','" + DateTime.Now.ToString() + "')");
                        }*/

                        string refid = gen.GetString("select RefID from DDH where RefNo='" + txtsct.Text + "'");
                        getrole(refid);
                        // chi tiet
                        for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                        {
                            sql = sql + "insert into DDHDetail(SortOrder,RefDetailID,RefID,InventoryItemID,Quantity,QuantityConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,CustomField5,UnitPriceConvert,ConvertRate,Unit,UnitPriceOC,AmountOC,DiscountRate,UnitPriceConvertOC,DGPhi,PhiKhac) values('" + i + "',newid(),'" + refid + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "','" + detail[i, 18] + "', '" + detail[i, 19] + "', '" + detail[i, 20] + "', '" + detail[i, 21] + "', '" + detail[i, 22] + "');";
                            //gen.ExcuteNonquery("insert into DDHDetail(SortOrder,RefDetailID,RefID,InventoryItemID,Quantity,QuantityConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,CustomField5,UnitPriceConvert,ConvertRate,Unit,UnitPriceOC,AmountOC,DiscountRate,UnitPriceConvertOC,DGPhi,PhiKhac) values('" + i + "',newid(),'" + refid + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "','" + detail[i, 18] + "', '" + detail[i, 19] + "', '" + detail[i, 20] + "', '" + detail[i, 21] + "', '" + detail[i, 22] + "')");
                            /*for (int j = 0; j < hangton.Rows.Count; j++)
                            {
                                if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                {
                                    hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail[i, 1]);
                                    hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail[i, 2]);
                                    break;
                                }
                            }*/
                        }
                        //if (sql != "")
                            //gen.ExcuteNonquery(sql); --> viet lai sau
                    }
                    else // update day
                    {
                        //XtraMessageBox.Show("toi day chua ku", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*try
                        {*/
                        // thu viet lai kieu moi di em!!!!
                        // ieu cu: gen.ExcuteNonquery("update DDH set PostedDate='" + dendh.EditValue.ToString() + "',RefDate='" + denct.EditValue.ToString() + "',AccountingObjectID='" + dt + "',
                        //AccountingObjectCode =N'" + ledt.EditValue.ToString() + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeIDSA=" + nv + ",CostCap='" + giavon + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',ReceiveMethod=N'" + txtptgh.Text + "',TotalFreightAmount='" + congno + "',OutStockID='" + dv + "', Sale='" + hangban.SelectedIndex.ToString() + "',InOut='" + chuyenkho.Checked + "', AccountingObjectType='" + cathang + "', Notax='" + chgbct.Checked + "',TotalCost='" + bocxep + "',TotalTransport='" + vanchuyen + "',OriginalRefNo='" + txtdienthoai.Text + "',Received='" + chnhtk.Checked + "', Chot='" + chot.Checked + "', Taixe=N'" + txttaixe.Text + "',CMND=N'" + txtcmnd.Text + "',Dienthoai='" + txtsdttaixe.Text + "',GDT='" + legd.EditValue.ToString() + "',RefNoCL='" + phieucl + "',RefDateCL='" + ngaygiadieu + "',TotalVATAmount='" + phikhac + "',RefIDInvoice='" + chvctc.Checked + "'  where RefID='" + role + "'");
                        /*
                        DDH data = new DDH();
                        if (active == "0")
                        {
                            data.RefID = Guid.NewGuid();
                        }
                        else
                        {
                            data.RefID = Guid.Parse(role); ;
                        }
                        
                        data.CompanyCode = Globals.companycode;
                        
                        try {
                            data.PostedDate = Convert.ToDateTime(dendh.EditValue);
                            data.RefDate = Convert.ToDateTime(denct.EditValue);
                            data.AccountingObjectID = Guid.Parse(dt);
                        }
                        catch (Exception ex) { XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "AccountingObjectID", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                       
                        data.AccountingObjectCode = ledt.EditValue.ToString();
                        data.AccountingObjectName = txtname.Text;
                        data.AccountingObjectAddress = txtdc.Text;                        
                        data.JournalMemo = txtldn.Text;
                        data.DocumentIncluded = txtctg.Text;

                        data.RefNo = txtsct.Text;
                        data.Contactname = txtngh.Text;
                        data.ShippingNo =  txtptvc.Text;

                        
                        if (chgbct.Checked == true)
                        {
                            data.Notax = true;
                        }
                        if (tsbtboghi.Visible == true)
                        {
                            data.Posted = true;
                        }
                        else
                        {
                            data.Posted = false;
                        }
                        if (tsbtboghi.Enabled == true)
                        {
                             data.Cancel = false;                            
                        }

                        try
                        {
                            data.Tax = Int32.Parse(cbthue.Text);
                            data.TotalAmountOC = decimal.Parse(txttthue.EditValue.ToString());
                            data.CostCap = decimal.Parse(txtgiavon.EditValue.ToString());                            
                        }
                        catch { }
                        
                        


                        data.ReceiveMethod = txtptgh.Text;
                        if (chhc.Checked == true)
                            data.AccountingObjectType = 1;
                        else
                            data.AccountingObjectType = 0;
                        if (chdn.Checked == true)                            
                            data.Status = "true";
                        else
                            data.Status = "false";
                        data.RefIDInOutward = txtpxk.Text;

                        if (chvctc.Checked == true)
                            data.RefIDInvoice = true;
                        else
                            data.RefIDInvoice = false;                        

                        var db= gen.GetNewEntity(); 
                        {
                            try
                            {
                                if (active == "0") db.DDHs.Add(data); //insert
                                else db.Entry(data).State = System.Data.Entity.EntityState.Modified; // update
                                db.SaveChanges();
                                XtraMessageBox.Show("Submit successfully", "tsbtsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //catch (DbUpdateException ex) // exception khac
                            catch (DbUpdateConcurrencyException ex) // exception khac
                            {
                                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message + active, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //txtSQL.Text = ex.Message + data + active;
                            }
                        }
                        */
                       
                        if (chnhtk.Checked == false) // hang cat
                        {
                            if (xuatchuyen != -1)
                            {
                                if (gen.GetString("select Province from Stock where StockID='" + dv + "'") == gen.GetString("select Province from Stock where StockID='" + dvn + "'"))
                                {
                                    loaixuatchuyen = "1";
                                    if (gen.GetString("select Stock from DDH where RefID='" + role + "'") == "-1")
                                    {
                                        //themsctchuyen(ngaychungtu, txtsctchuyen, ledvdat.EditValue.ToString(), "0");
                                        //themsctnhan(ngaychungtu, txtsctnhan, ledvnhan.EditValue.ToString(), "0");
                                        //gen.ExcuteNonquery("insert into INTransfer(RefID,RefType,RefDate,PostedDate,RefNo,RefNoIn,AccountingObjectID,AccountingObjectName,Contactname,JournalMemo,Posted,OutwardStockID,InwardStockID,ShippingNo,TotalAmount,CostAmount,No,InvSeries,InvNo,InvDate,UserID,IsExport,RefSUID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denct.EditValue.ToString() + "','" + txtsctchuyen.Text + "','" + txtsctnhan.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + dvn + "',N'" + txtptvc.Text + "','" + giavon + "',0,'','','','" + denct.EditValue.ToString() + "','" + userid + "','" + chuyenkho.Checked + "','" + role + "')");
                                        //gen.ExcuteNonquery("update DDH set Factory='False', Handling='" + DateTime.Now.ToString() + "',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                    }
                                    else
                                    {
                                        //gen.ExcuteNonquery("update INTransfer set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denct.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',OutwardStockID='" + dv + "',InwardStockID='" + dvn + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',TotalAmount='" + giavon + "',CostAmount='0',UserID='" + userid + "',IsExport='" + chuyenkho.Checked + "'  where RefSUID='" + role + "'");
                                        //gen.ExcuteNonquery("update DDH set Factory='False',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                    }
                                    rolexuat = gen.GetString("select RefID from INTransfer where RefSUID='" + role + "'");
                                }
                                else
                                {
                                    if (gen.GetString("select Stock from DDH where RefID='" + role + "'") == "-1")
                                    {
                                        //themsctchuyen(ngaychungtu, txtsctchuyen, ledv.EditValue.ToString(), "1");
                                        //themsctnhan(ngaychungtu, txtsctnhan, ledvn.EditValue.ToString(), "1");
                                        //gen.ExcuteNonquery("insert into INTransferBranch(RefID,RefType,RefDate,PostedDate,RefNo,RefNoIn,AccountingObjectID,AccountingObjectName,Contactname,JournalMemo,Posted,OutwardStockID,InwardStockID,ShippingNo,TotalAmount,CostAmount,No,InvSeries,InvNo,InvDate,UserID,IsExport,RefSUID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denct.EditValue.ToString() + "','" + txtsctchuyen.Text + "','" + txtsctnhan.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + dvn + "',N'" + txtptvc.Text + "','" + giavon + "',0,'','','','" + denct.EditValue.ToString() + "','" + userid + "','" + chuyenkho.Checked + "','" + role + "')");
                                        //gen.ExcuteNonquery("update DDH set Factory='True', Handling='" + DateTime.Now.ToString() + "',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                    }
                                    else
                                    {
                                        //gen.ExcuteNonquery("update INTransferBranch set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denct.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',OutwardStockID='" + dv + "',InwardStockID='" + dvn + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',TotalAmount='" + giavon + "',CostAmount='0',UserID='" + userid + "',IsExport='" + chuyenkho.Checked + "'  where RefSUID='" + role + "'");
                                        //gen.ExcuteNonquery("update DDH set Factory='True',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                    }
                                    rolexuat = gen.GetString("select RefID from INTransferBranch where RefSUID='" + role + "'");
                                }
                            }
                            // detail    
                            gen.ExcuteNonquery("delete  from  DDHDetail where RefID='" + role + "'");
                            if (rolexuat != null)
                            {
                                gen.ExcuteNonquery("delete  from  INTransferDetail where RefID='" + rolexuat + "'");
                                gen.ExcuteNonquery("delete  from  INTransferBranchDetail where RefID='" + rolexuat + "'");
                            }
                            for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                            {
                                sql = sql + "insert into DDHDetail(SortOrder,RefDetailID,RefID,InventoryItemID,Quantity,QuantityConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,CustomField5,UnitPriceConvert,ConvertRate,Unit,UnitPriceOC,AmountOC,DiscountRate,UnitPriceConvertOC,DGPhi,PhiKhac) values('" + i + "',newid(),'" + role + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "','" + detail[i, 18] + "', '" + detail[i, 19] + "', '" + detail[i, 20] + "', '" + detail[i, 21] + "', '" + detail[i, 22] + "');";
                                //gen.ExcuteNonquery("insert into DDHDetail(SortOrder,RefDetailID,RefID,InventoryItemID,Quantity,QuantityConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,CustomField5,UnitPriceConvert,ConvertRate,Unit,UnitPriceOC,AmountOC,DiscountRate,UnitPriceConvertOC,DGPhi,PhiKhac) values('" + i + "',newid(),'" + role + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "','" + detail[i, 18] + "', '" + detail[i, 19] + "', '" + detail[i, 20] + "', '" + detail[i, 21] + "', '" + detail[i, 22] + "')");

                                if (xuatchuyen != -1)
                                {
                                    if (loaixuatchuyen != "0")
                                    {
                                        //gen.ExcuteNonquery("insert into INTransferDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,UnitPrice,Amount,Cost,UnitPriceOC,AmountOC) values(newid(),'" + rolexuat + "','" + detail[i, 9] + "','" + detail[i, 10] + "'," + i + ",'" + detail[i, 0] + "','','" + detail[i, 11] + "','" + detail[i, 12] + "','0','" + detail[i, 13] + "','" + detail[i, 14] + "')");
                                        sql = sql + "insert into INTransferDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,UnitPrice,Amount,Cost,UnitPriceOC,AmountOC) values(newid(),'" + rolexuat + "','" + detail[i, 9] + "','" + detail[i, 10] + "'," + i + ",'" + detail[i, 0] + "','','" + detail[i, 11] + "','" + detail[i, 12] + "','0','" + detail[i, 13] + "','" + detail[i, 14] + "');";
                                    }
                                    else
                                    {
                                        //gen.ExcuteNonquery("insert into INTransferBranchDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,UnitPrice,Amount,Cost,UnitPriceOC,AmountOC) values(newid(),'" + rolexuat + "','" + detail[i, 9] + "','" + detail[i, 10] + "'," + i + ",'" + detail[i, 0] + "','','" + detail[i, 11] + "','" + detail[i, 12] + "','0','" + detail[i, 13] + "','" + detail[i, 14] + "')");
                                        sql = sql + "insert into INTransferBranchDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,UnitPrice,Amount,Cost,UnitPriceOC,AmountOC) values(newid(),'" + rolexuat + "','" + detail[i, 9] + "','" + detail[i, 10] + "'," + i + ",'" + detail[i, 0] + "','','" + detail[i, 11] + "','" + detail[i, 12] + "','0','" + detail[i, 13] + "','" + detail[i, 14] + "');";
                                    }
                                }



                                /*
                                for (int j = 0; j < hangton.Rows.Count; j++)
                                {
                                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                    {
                                        hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail[i, 1]);
                                        hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail[i, 2]);
                                        break;
                                    }
                                }*/
                            }
                            if (sql != "")
                                gen.ExcuteNonquery(sql);
                        }
                        else // update nè
                        {
                            if (xuatchuyen != -1)
                            {
                                if (gen.GetString("select Province from Stock where StockID='" + dv + "'") == gen.GetString("select Province from Stock where StockID='" + dvn + "'"))
                                {
                                    if (gen.GetString("select Stock from DDH where RefID='" + role + "'") == "-1")
                                        gen.ExcuteNonquery("update DDH set Factory='False', Handling='" + DateTime.Now.ToString() + "',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                    else
                                        gen.ExcuteNonquery("update DDH set Factory='False',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                    //nguy hiem
                                    //gen.ExcuteNonquery("delete  from  INTransferDetail where RefID=(select RefID from INTransfer where RefSUID='" + role + "')");
                                    //gen.ExcuteNonquery("delete  from  INTransfer where RefID=(select RefID from INTransfer where RefSUID='" + role + "')");
                                }
                                else
                                {
                                    if (gen.GetString("select Stock from DDH where RefID='" + role + "'") == "-1")
                                        gen.ExcuteNonquery("update DDH set Factory='True', Handling='" + DateTime.Now.ToString() + "',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                    else
                                        gen.ExcuteNonquery("update DDH set Factory='True',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                    //nguy hiem
                                    //gen.ExcuteNonquery("delete  from  INTransferBranchDetail where RefID=(select RefID from INTransferBranch where RefSUID='" + role + "')");
                                    //gen.ExcuteNonquery("delete  from  INTransferBranch where RefID=(select RefID from INTransferBranch where RefSUID='" + role + "')");
                                }
                            }

                            gen.ExcuteNonquery("delete  from  DDHDetail where RefID='" + role + "'");

                            for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                            {
                                sql = sql + "insert into DDHDetail(SortOrder,RefDetailID,RefID,InventoryItemID,Quantity,QuantityConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,CustomField5,UnitPriceConvert,ConvertRate,Unit,UnitPriceOC,AmountOC,DiscountRate,UnitPriceConvertOC,DGPhi,PhiKhac) values('" + i + "',newid(),'" + role + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "','" + detail[i, 18] + "', '" + detail[i, 19] + "', '" + detail[i, 20] + "', '" + detail[i, 21] + "', '" + detail[i, 22] + "');";
                            }
                            //if (sql != "")
                               // gen.ExcuteNonquery(sql); --> chuyen doi sau.
                        }
                    }
                    getactive("1");
                    //XtraMessageBox.Show("toi cho nay chua?", "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                getloi("1");
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void themsctchuyen(string ngaychungtu, TextEdit txtsctchuyen, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public void themsct(string ngaychungtu, TextEdit txtsct, string mk, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            if (mk == "42")
                branch = "01";
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-DDHH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from DDH where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InStockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtsct.Text = sophieu;
            //checktruocsau(tsbttruoc, tsbtsau, mk, sophieu, ngaychungtu);
        }


        public string getloi(string a)
        {
            loi = a;
            return loi;
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            Double cth, gtgt;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { cth = 0; }
            gtgt = Double.Parse(txttthue.Text);
            txttc.Text = String.Format("{0:n0}", cth + gtgt);
        }

        private void ledvnhan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chon == 0)
                    ddh.loadchuathue(ViewVAT, ViewNOVAT, ViewCU, txtcth, txtgiavon, cbthue, chgbct);
                else
                    chon = 0;
            }
            catch { }

            hangtonthucte();

            for (int i = 0; i < ViewVAT.RowCount - 1; i++)
            {
                Double ton = 0;
                for (int j = 0; j < hangtoncungungthucte.Rows.Count; j++)
                {
                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() == hangtoncungungthucte.Rows[j][0].ToString())
                    {
                        ton = 1;

                        if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0)
                        {
                            Double soluong = 0;
                            try { soluong = Double.Parse(ViewVAT.GetRowCellValue(i, "Số lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) - soluong < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                {
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n0}", Double.Parse(hangtoncungungthucte.Rows[j][6].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }

                        else if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                        {
                            Double trongluong1 = 0;
                            try { trongluong1 = Double.Parse(ViewVAT.GetRowCellValue(i, "Trọng lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) - trongluong1 < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                {
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                    XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " bị âm kho " + string.Format("{0:n2}", Double.Parse(hangtoncungungthucte.Rows[j][7].ToString())) + " vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }
                        else
                        {
                            if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                            {
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        break;
                    }
                }
                if (ton == 0)
                {
                    if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                    {
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                        XtraMessageBox.Show(ViewVAT.GetRowCellValue(i, "Tên hàng").ToString() + " không có trong kho vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                }
            }
        }

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            if (ledt.EditValue != null)
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtname.Text = khach.Rows[i][2].ToString();
                        txtdc.Text = khach.Rows[i][3].ToString();
                        txtmst.Text = khach.Rows[i][4].ToString();
                        //loadhanmuc(khach.Rows[i][0].ToString());
                        //congnotam = 0;
                        return;
                    }
                }
            else
            {
                sehd.EditValue = null;
                txthn.EditValue = 0;
                txthm.EditValue = 0;
                txtcn.EditValue = 0;
            }
        }

        private void sehd_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void kiemtrahangam()
        {
            hangtonthucte();

            for (int i = 0; i < ViewVAT.RowCount - 1; i++)
            {
                Double ton = 0;
                for (int j = 0; j < hangtoncungungthucte.Rows.Count; j++)
                {
                    if (ViewVAT.GetRowCellValue(i, "Mã hàng").ToString() == hangtoncungungthucte.Rows[j][0].ToString())
                    {
                        ton = 1;

                        if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) != 0)
                        {
                            Double soluong = 0;
                            try { soluong = Double.Parse(ViewVAT.GetRowCellValue(i, "Số lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][6].ToString()) - soluong < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }

                        else if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) != 0)
                        {
                            Double trongluong1 = 0;
                            try { trongluong1 = Double.Parse(ViewVAT.GetRowCellValue(i, "Trọng lượng").ToString()); }
                            catch { }
                            if (Double.Parse(hangtoncungungthucte.Rows[j][7].ToString()) - trongluong1 < 0 && ledvnhan.EditValue.ToString() != null)
                            {
                                if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                                else
                                    ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                            }
                            else
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                        }
                        else
                        {
                            if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                            {
                                ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                            }
                        }
                        break;
                    }
                }
                if (ton == 0)
                {
                    if (ledvnhan.EditValue.ToString() != "01" && ledvnhan.EditValue.ToString() != "19")
                    {
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "1");
                    }
                    else
                        ViewVAT.SetRowCellValue(i, ViewVAT.Columns["Âm kho"], "0");
                }
            }
        }

        private void hangtonthucte()
        {
            string thang = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
            string nam = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();

            string thangtruoc = DateTime.Parse(DateTime.Now.ToString()).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(DateTime.Now.ToString()).AddMonths(-1).Year.ToString();

            string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
            string denngaydau = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).ToShortDateString()).AddSeconds(-1).ToString();

            string tungaycuoi = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).ToShortDateString()).ToString();
            string denngaycuoi = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            string kho = "";
            try
            {
                kho = gen.GetString("select StockId from Stock where StockCode='" + ledvnhan.EditValue.ToString() + "'");
                hangtoncungungthucte = gen.GetTable("baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','" + role + "' ");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace + ex.TargetSite + ex.InnerException.Message, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtSQL.Text = sql;
            }
            
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchLookUpEdit1.Properties.View.Columns.Clear();
            if (radioGroup1.SelectedIndex == 0)
            {
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
            else if (radioGroup1.SelectedIndex == 1)
            {
                DataTable temp = new DataTable();
                temp.Columns.Add("Mã hàng");
                temp.Columns.Add("Tên hàng hóa");
                temp.Columns.Add("Đơn vị tính");
                temp.Columns.Add("Đơn vị quy đổi");
                for (int i = 0; i < hang.Rows.Count; i++)
                {
                    DataRow dr = temp.NewRow();
                    dr[0] = hang.Rows[i][1].ToString();
                    dr[1] = hang.Rows[i][2].ToString();
                    dr[2] = hang.Rows[i][3].ToString();
                    dr[3] = hang.Rows[i][4].ToString();
                    temp.Rows.Add(dr);
                }
                searchLookUpEdit1.Properties.DataSource = temp;
                searchLookUpEdit1.Properties.DisplayMember = "Mã hàng";
                searchLookUpEdit1.Properties.ValueMember = "Mã hàng";
                searchLookUpEdit1.Focus();
            }
            searchLookUpEdit1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }

        private void btkiemtra_Click(object sender, EventArgs e)
        {
            if (ledt.EditValue != null)
                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        return;
                    }
        }

        private void loadhanmuc(string makhach)
        {
            lbngd.Visible = false;
            dengd.Visible = false;
            ngaychungtu = Globals.ngaychungtu;
            if (radioGroup2.SelectedIndex == 0)
            {
                string makho = gen.GetString("select StockID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
                string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledvdat.EditValue.ToString() + "'");
                Double hanmuc = 0, hanno = 0;
                DataTable temp = new DataTable();
                string mySQL = "select a.ParentContract,DebtLimitMax,LimitDate,a.SignedDate,EffectiveDate,a.ContractName from ";
                mySQL += " contractB a,(select ParentContract, MAX(SignedDate) as SignedDate, ContractName from contractB ";
                mySQL += " where (ContractName = N'Bán hàng' or ContractName = N'Gửi kho' or ContractName = N'' or No = '2') and AccountingObjectID = '" + makhach + "' ";
                mySQL += " and SignedDate<= '" + ngaychungtu + "'and EffectiveDate>= '" + ngaychungtu + "' and Inactive = 1 and DebtLimit> 0 and ";
                mySQL += " StockID in (select StockID from Stock where BranchID = '" + donvi + "') group by ParentContract,ContractName) b where a.ParentContract = b.ParentContract and a.SignedDate = b.SignedDate";
                DataTable da = gen.GetTable(mySQL);
                if (da.Rows.Count > 0)
                {
                    temp.Columns.Add("Hợp đồng");
                    temp.Columns.Add("Hạn mức");
                    temp.Columns.Add("Hạn nợ");
                    temp.Columns.Add("Ngày ký");
                    temp.Columns.Add("Ngày hết hạn");
                    for (int j = 0; j < da.Rows.Count; j++)
                    {
                        DataRow dr = temp.NewRow();
                        dr[0] = da.Rows[j][0].ToString();
                        dr[1] = String.Format("{0:n0}", Double.Parse(da.Rows[j][1].ToString()));
                        hanmuc = hanmuc + Double.Parse(da.Rows[j][1].ToString());
                        dr[2] = String.Format("{0:n0}", Double.Parse(da.Rows[j][2].ToString()));
                        hanno = Double.Parse(da.Rows[j][2].ToString());
                        dr[3] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(da.Rows[j][3].ToString()));
                        dr[4] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(da.Rows[j][4].ToString()));
                        if (da.Rows[j][5].ToString() == "Gửi kho")
                        {
                            if (phieu == "tsbtddh")
                            {
                                lbngd.Visible = true;
                                dengd.Visible = true;
                            }
                            hanmuc = hanmuc - Double.Parse(da.Rows[j][1].ToString());
                        }
                        temp.Rows.Add(dr);
                    }
                    sehd.Properties.DataSource = temp;
                    sehd.Properties.DisplayMember = "Hợp đồng";
                    sehd.Properties.ValueMember = "Hợp đồng";
                    sehd.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
                    if (temp.Rows.Count > 0)
                        sehd.EditValue = da.Rows[temp.Rows.Count - 1][0].ToString();
                    txthm.EditValue = hanmuc;
                    txthn.EditValue = hanno;
                    /*try
                    {*/
                    txtcn.EditValue = Double.Parse(gen.GetString("bangkecongnohanmuckhachhang '" + donvi + "','" + makhach + "', '" + ngaychungtu + "'"));
                    /*}
                    catch { txtcn.EditValue = 0; }*/
                }
                else
                {
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                    string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                    txtcn.EditValue = Double.Parse(gen.GetString("baocaocongnokiemtrakhonghopdong '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'"));
                    txthm.EditValue = Double.Parse(gen.GetString("select COALESCE(Amount,0) from AmountBranch where Year='" + nam + "' and BranchID='" + donvi + "'"));
                    sehd.EditValue = null;
                    txthn.EditValue = 0;
                }
            }
        }

        private void lenv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (lenv.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        txtnv.Text = khach.Rows[i][2].ToString();
                        return;
                    }
                }
            }
            catch { txtnv.EditValue = null; }
        }

        private void ledt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                key = -1;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (key == -1)
            {
                ledt.EditValue = searchLookUpEdit1.EditValue;
                ledt.Focus();
            }
            else if (key == -2)
            {
                lenv.EditValue = searchLookUpEdit1.EditValue;
                lenv.Focus();
            }
            else if (key != -1 && key != -2)
            {
                try
                {
                    string temp = ViewVAT.GetRowCellValue(ViewVAT.FocusedRowHandle, "Tên hàng").ToString();
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                    ViewVAT.Focus();
                }
                catch
                {
                    ViewVAT.AddNewRow();
                    ViewVAT.SetRowCellValue(ViewVAT.FocusedRowHandle, ViewVAT.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                    ViewVAT.Focus();
                }
            }
        }

        private void sbok_Click(object sender, EventArgs e)
        {
            ddh.tsbtpxk(txtpxk.Text, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
        }

        private void Frm_DNDH_Load(object sender, EventArgs e)
        {
            //lblStatus.Text = "Client: " + Globals.clientid + "; User: " + Globals.username + "; Transaction: BCTK";
            //txtSQL.Visible = false;
            tsbttruoc.Visible = false;
            tsbtsau.Visible = false;
            tsbtadd.Visible = false;
            tsbtsua.Visible = false;
            

            // kiem tra permission                       
            if (gen.checkPermission(Globals.username, Globals.transactioncode, Globals.companycode) == false)
            {
                XtraMessageBox.Show("You do not the permission to execute this transaction code " + Globals.transactioncode, "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


            //ledvnhan - cung ung
            DataTable da = new DataTable();
            DataTable tempdat = new DataTable();
            DataTable tempnhan = new DataTable();            
            var db= gen.GetNewEntity(); // khai bao new entity Framework
            {
                var query = db.Stocks
                    .Where(p => p.CompanyCode == Globals.companycode)
                    .OrderBy(p => p.StockCode)
                    .Select(p => new { p.StockCode, p.StockName })
                    .ToList();
                tempnhan = gen.ConvertToDataTable(query);
            }
            ledvnhan.Properties.DataSource = tempnhan;
            ledvnhan.Properties.DisplayMember = "StockCode";
            ledvnhan.Properties.ValueMember = "StockCode";
            ledvnhan.Properties.PopupWidth = 300;
           
            ledvdat.Properties.DataSource = tempnhan;
            ledvdat.Properties.DisplayMember = "StockCode";
            ledvdat.Properties.ValueMember = "StockCode";
            ledvdat.Properties.PopupWidth = 300;
            ledvdat.ItemIndex = 0;

            //gia dieu
           
            legd.Properties.DataSource = gen.GetTable("select StockII as 'Mã số', StockIIName as 'Diễn giải' from StockIIStock where TimeLine=2 order by StockII");
            legd.Properties.DisplayMember = "Diễn giải";
            legd.Properties.ValueMember = "Mã số";
            legd.Properties.PopupWidth = 200;
            legd.Properties.PopupFormMinSize = new System.Drawing.Size(0, 250);
            legd.ItemIndex = 0;

            // doi tuong
            DataTable tempmk = new DataTable();
            tempmk.Columns.Add("Mã đối tượng");
            tempmk.Columns.Add("Tên đối tượng");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = tempmk.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                tempmk.Rows.Add(dr);
            }
            lenv.Properties.DataSource = tempmk;
            lenv.Properties.DisplayMember = "Mã đối tượng";
            lenv.Properties.ValueMember = "Mã đối tượng";
            lenv.Properties.PopupWidth = 400;
            ledt.Properties.DataSource = tempmk;
            ledt.Properties.DisplayMember = "Mã đối tượng";
            ledt.Properties.ValueMember = "Mã đối tượng";
            ledt.Properties.PopupWidth = 400;

            // ma hang
            DataTable tempmh = new DataTable();
            tempmh.Columns.Add("Mã hàng");
            tempmh.Columns.Add("Tên hàng");
            for (int i = 0; i < hang.Rows.Count; i++)
            {
                DataRow dr = tempmh.NewRow();
                dr[0] = hang.Rows[i][1].ToString();
                dr[1] = hang.Rows[i][2].ToString();
                tempmh.Rows.Add(dr);
            }
            mahang.DataSource = tempmh;
            mahang.DisplayMember = "Mã hàng";
            mahang.ValueMember = "Mã hàng";
            mahang.PopupWidth = 400;


            DataTable dt = new DataTable();
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("ĐG số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));

            dt.Columns.Add("ĐG bốc xếp", Type.GetType("System.Double"));
            dt.Columns.Add("Bốc xếp", Type.GetType("System.Double"));
            dt.Columns.Add("ĐG vận chuyển", Type.GetType("System.Double"));
            dt.Columns.Add("Vận chuyển", Type.GetType("System.Double"));

            //dt.Columns.Add("Số lượng tồn", Type.GetType("System.Double"));
            //dt.Columns.Add("Trọng lượng tồn", Type.GetType("System.Double"));
            //dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Giảm giá", Type.GetType("System.Double"));
            dt.Columns.Add("Phí khác", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí khác", Type.GetType("System.Double"));
            dt.Columns.Add("Âm kho", Type.GetType("System.Double"));
            VAT.DataSource = dt;

            ViewVAT.Columns["Mã hàng"].ColumnEdit = mahang;
            ViewVAT.Columns["Số lượng"].ColumnEdit = soluong;
            ViewVAT.Columns["Trọng lượng"].ColumnEdit = trongluong;
            ViewVAT.Columns["ĐG số lượng"].ColumnEdit = dongia;
            ViewVAT.Columns["Đơn giá"].ColumnEdit = dongia;
            ViewVAT.Columns["Thành tiền"].ColumnEdit = thanhtien;
            ViewVAT.Columns["ĐG bốc xếp"].ColumnEdit = bocxep;
            ViewVAT.Columns["ĐG vận chuyển"].ColumnEdit = vanchuyen;
            ViewVAT.Columns["Vận chuyển"].ColumnEdit = thanhtien;
            ViewVAT.Columns["Giảm giá"].ColumnEdit = thanhtien;
            ViewVAT.Columns["Phí khác"].ColumnEdit = thanhtien;

            ViewVAT.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            ViewVAT.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewVAT.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewVAT.Columns["Chi phí khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Chi phí khác"].DisplayFormat.FormatString = "{0:n0}";
            ViewVAT.Columns["Chi phí khác"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewVAT.Columns["Chi phí khác"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewVAT.Columns["Phí khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Phí khác"].DisplayFormat.FormatString = "{0:n0}";

            ViewVAT.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n2}";
            ViewVAT.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewVAT.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n2}";


            ViewVAT.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            ViewVAT.Columns["ĐG số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["ĐG số lượng"].DisplayFormat.FormatString = "{0:n2}";

            ViewVAT.Columns["Giảm giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Giảm giá"].DisplayFormat.FormatString = "{0:n0}";

            ViewVAT.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            ViewVAT.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewVAT.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewVAT.Columns["ĐG bốc xếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["ĐG bốc xếp"].DisplayFormat.FormatString = "{0:n2}";
            ViewVAT.Columns["ĐG vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["ĐG vận chuyển"].DisplayFormat.FormatString = "{0:n2}";

            ViewVAT.Columns["Bốc xếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Bốc xếp"].DisplayFormat.FormatString = "{0:n0}";
            ViewVAT.Columns["Bốc xếp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewVAT.Columns["Bốc xếp"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewVAT.Columns["Vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewVAT.Columns["Vận chuyển"].DisplayFormat.FormatString = "{0:n0}";
            ViewVAT.Columns["Vận chuyển"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewVAT.Columns["Vận chuyển"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewVAT.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            ViewVAT.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            ViewVAT.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            ViewVAT.Columns["Tên hàng"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            ViewVAT.Columns["Bốc xếp"].OptionsColumn.AllowEdit = false;
            ViewVAT.Columns["Âm kho"].OptionsColumn.AllowEdit = false;

            ViewVAT.Columns["Giảm giá"].Visible = false;
            ViewVAT.Columns["Chi phí khác"].Visible = false;

            ViewVAT.Columns["Âm kho"].Width = 50;
            DataTable dtnovat = new DataTable();

            dtnovat.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dtnovat.Columns.Add("Tên hàng");
            dtnovat.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dtnovat.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dtnovat.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dtnovat.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            NOVAT.DataSource = dtnovat;

            ViewNOVAT.Columns["Thành tiền"].ColumnEdit = thanhtien;

            ViewNOVAT.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewNOVAT.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            ViewNOVAT.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewNOVAT.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewNOVAT.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewNOVAT.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n2}";
            ViewNOVAT.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewNOVAT.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n2}";

            ViewNOVAT.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewNOVAT.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            ViewNOVAT.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewNOVAT.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            ViewNOVAT.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewNOVAT.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewNOVAT.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            ViewNOVAT.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            ViewNOVAT.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            ViewNOVAT.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            ViewNOVAT.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
            ViewNOVAT.Columns["Trọng lượng"].OptionsColumn.AllowEdit = false;
            ViewNOVAT.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;

            radioGroup2.SelectedIndex = 1;
            DataTable dtcu = new DataTable();
            dtcu.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dtcu.Columns.Add("Tên hàng");
            dtcu.Columns.Add("Số lượng đặt", Type.GetType("System.Double"));
            dtcu.Columns.Add("Trọng lượng đặt", Type.GetType("System.Double"));

            dtcu.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dtcu.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dtcu.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dtcu.Columns.Add("Thành tiền", Type.GetType("System.Double"));

            dtcu.Columns.Add("ĐG bốc xếp", Type.GetType("System.Double"));
            dtcu.Columns.Add("Bốc xếp", Type.GetType("System.Double"));

            dtcu.Columns.Add("ĐG vận chuyển", Type.GetType("System.Double"));
            dtcu.Columns.Add("Vận chuyển", Type.GetType("System.Double"));

            CU.DataSource = dtcu;
            ViewCU.Columns["Số lượng đặt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["Số lượng đặt"].DisplayFormat.FormatString = "{0:n0}";
            ViewCU.Columns["Số lượng đặt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewCU.Columns["Số lượng đặt"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewCU.Columns["Trọng lượng đặt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["Trọng lượng đặt"].DisplayFormat.FormatString = "{0:n2}";
            ViewCU.Columns["Trọng lượng đặt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewCU.Columns["Trọng lượng đặt"].SummaryItem.DisplayFormat = "{0:n2}";

            ViewCU.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            ViewCU.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewCU.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewCU.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n2}";
            ViewCU.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewCU.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n2}";

            ViewCU.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            ViewCU.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            ViewCU.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewCU.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewCU.Columns["Mã hàng"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            ViewCU.Columns["Tên hàng"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            ViewCU.Columns["Số lượng đặt"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            ViewCU.Columns["Trọng lượng đặt"].AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;

            ViewCU.Columns["ĐG bốc xếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["ĐG bốc xếp"].DisplayFormat.FormatString = "{0:n2}";

            ViewCU.Columns["Bốc xếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["Bốc xếp"].DisplayFormat.FormatString = "{0:n0}";
            ViewCU.Columns["Bốc xếp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewCU.Columns["Bốc xếp"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewCU.Columns["ĐG vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["ĐG vận chuyển"].DisplayFormat.FormatString = "{0:n2}";

            ViewCU.Columns["Vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ViewCU.Columns["Vận chuyển"].DisplayFormat.FormatString = "{0:n0}";
            ViewCU.Columns["Vận chuyển"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ViewCU.Columns["Vận chuyển"].SummaryItem.DisplayFormat = "{0:n0}";

            ViewCU.Columns["Số lượng"].ColumnEdit = soluong;
            ViewCU.Columns["Trọng lượng"].ColumnEdit = trongluong;
            ViewCU.Columns["Đơn giá"].ColumnEdit = dongia;
            ViewCU.Columns["Thành tiền"].ColumnEdit = thanhtien;
            ViewCU.Columns["ĐG bốc xếp"].ColumnEdit = bocxep;
            ViewCU.Columns["ĐG vận chuyển"].ColumnEdit = vanchuyen;
            ViewCU.Columns["Vận chuyển"].ColumnEdit = thanhtien;


            ViewCU.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            ViewCU.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            ViewCU.Columns["Số lượng đặt"].OptionsColumn.AllowEdit = false;
            ViewCU.Columns["Trọng lượng đặt"].OptionsColumn.AllowEdit = false;
            ViewCU.Columns["Bốc xếp"].OptionsColumn.AllowEdit = false;
            ViewCU.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
            ViewCU.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;

            if (active == "1")
            {
                
                /*
                var ctx = gen.GetNewEntity(); 
                Guid RefID = Guid.Parse(role);
                var query = ctx.DDHs
                    .Where(x => x.CompanyCode == Globals.companycode
                    && x.RefID == RefID);
                foreach (var data in query)
                {
                    try
                    {
                        ledvnhan.Text = gen.GetString("select StockCode from Stock where StockID='" + data.InStockID.ToString() + "'");
                        txtdc.Text = gen.GetString("select StockCode from Stock where StockID='" + data.InStockID.ToString() + "'");
                    }
                    catch { }
                    

                    if (data.Chot == true)
                        chnhtk.Checked = true;
                    else
                        chnhtk.Checked = false;

                    legd.Properties.ReadOnly = false;
                    if (data.RefNoCL != "")
                        try {
                            legd.ItemIndex = Int32.Parse(data.RefNoCL) - 1;
                        } catch { legd.ItemIndex = 0; }
                        
                    else
                        legd.ItemIndex = 0;
                    legd.Properties.ReadOnly = true;

                    denct.EditValue = data.RefDate;
                    dendh.EditValue = data.PostedDate;

                    DataTable dacon = new DataTable();
                    
                    var query2 = ctx.DDHDetails
                         .Join(ctx.InventoryItems, a => a.InventoryItemID, b => b.InventoryItemID,
                         (a, b) => new {
                             a.RefID,
                             b.InventoryItemCode,
                             b.InventoryItemName,
                             a.Quantity,
                             a.QuantityConvert,
                             a.DiscountRate,
                             a.UnitPriceOC,
                             a.AmountOC,
                             a.CustomField1,
                             a.CustomField2,
                             a.CustomField3,
                             a.CustomField4,
                             a.UnitPriceConvertOC,
                             a.DGPhi,
                             a.PhiKhac,
                             a.QuantityExits,
                             a.QuantityConvertExits,
                             a.Cost,
                             a.DiscountAmount,
                             a.CustomField5,
                             a.UnitPriceConvert,
                             a.ConvertRate,
                             a.Unit,
                             a.UnitPrice,
                             a.Amount
                         })
                    .Where(x => x.RefID == RefID);
                    foreach (var data2 in query2) 
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = data2.InventoryItemCode;
                        dr[1] = data2.InventoryItemName;
                        dr[2] = data2.Quantity;
                        dr[3] = data2.QuantityConvert;
                        dr[4] = data2.DiscountRate;
                        dr[5] = data2.UnitPriceOC;
                        dr[6] = data2.AmountOC;
                        dr[7] = data2.CustomField1;
                        dr[8] = data2.CustomField2;
                        dr[9] = data2.CustomField3;
                        dr[10] = data2.CustomField4;

                        dr[11] = data2.UnitPriceConvertOC ?? 0;
                        dr[12] = data2.DGPhi ?? 0;
                        dr[13] = data2.PhiKhac ?? 0;

                        dt.Rows.Add(dr);

                        DataRow dr1 = dtcu.NewRow();
                        dr1[0] = data2.InventoryItemCode;
                        dr1[1] = data2.InventoryItemName;
                        dr1[2] = data2.Quantity;
                        dr1[3] = data2.QuantityConvert;
                        dr1[4] = data2.QuantityExits;
                        dr1[5] = data2.QuantityConvertExits;
                        dr1[6] = data2.Cost;
                        dr1[7] = data2.DiscountAmount;
                        dr1[8] = data2.CustomField5;
                        dr1[9] = data2.UnitPriceConvert;
                        dr1[10] = data2.ConvertRate;
                        dr1[11] = data2.Unit;
                        dtcu.Rows.Add(dr1);

                        DataRow dr2 = dtnovat.NewRow();
                        dr2[0] = data2.InventoryItemCode;
                        dr2[1] = data2.InventoryItemName;
                        dr2[2] = data2.Quantity;
                        dr2[3] = data2.QuantityConvert;
                        dr2[4] = data2.UnitPrice;
                        dr2[5] = data2.Amount;
                        dtnovat.Rows.Add(dr2);
                    }
                    VAT.DataSource = dt;
                    CU.DataSource = dtcu;
                    NOVAT.DataSource = dtnovat;


                    txttaixe.Text = data.Taixe;
                    txtcmnd.Text = data.CMND;
                    txtsdttaixe.Text = data.Dienthoai;
                    
                    if (data.Chot == true)
                        chot.Checked = true;
                    else
                        chot.Checked = false;

                    txtdienthoai.Text = data.OriginalRefNo;

                    if (data.UserCheck != "")
                    {
                        lbduyet.Text = data.UserCheck;
                        chduyet.Checked = true;
                        chduyet.Enabled = false;
                    }

                    if (data.Sale == false)
                        radioGroup2.SelectedIndex = 0;

                    if (data.Stock == 0)
                        radioGroup3.SelectedIndex = 0;
                    else if (data.Stock == 1)
                        radioGroup3.SelectedIndex = 1;
                    else
                        radioGroup3.SelectedIndex = -1;

                    if (data.INOut == true)
                        chdxck.Checked = true;
                    else
                        chdxck.Checked = false;

                    try
                    {
                        if (data.Factory == true)
                        {
                            txtsctchuyen.EditValue = gen.GetString("select RefNo from INTransferBranch where RefSUID='" + role + "'");
                            txtsctnhan.EditValue = gen.GetString("select RefNoIn from INTransferBranch where RefSUID='" + role + "'");
                        }
                        else if (data.Factory == false)
                        {
                            txtsctchuyen.EditValue = gen.GetString("select RefNo from INTransfer where RefSUID='" + role + "'");
                            txtsctnhan.EditValue = gen.GetString("select RefNoIn from INTransfer where RefSUID='" + role + "'");
                        }
                    }
                    catch { }
                    
                    try {
                        ledvdat.Text = gen.GetString("select StockCode from Stock where StockID='" + data.InStockID.ToString() + "'");  
                    } catch (Exception ex) { XtraMessageBox.Show(data.InStockID + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                    ledt.Text = data.AccountingObjectCode;
                    txtldn.Text = data.JournalMemo;
                    txtctg.Text = data.DocumentIncluded;

                    txtsct.Text = data.RefNo;
                    txtngh.Text = data.Contactname;
                    txtptvc.Text = data.ShippingNo;
                    
                    if (data.Notax == true)
                    {                        chgbct.Checked = true;
                    }
                    if (data.Posted == true)
                    {
                        tsbtghiso.Visible = false;
                        tsbtboghi.Visible = true;
                        tsbtsua.Enabled = false;
                        chdn.Enabled = false;
                    }
                    else
                    {
                        tsbtboghi.Visible = false;
                        tsbtghiso.Visible = true;
                    }
                    if (data.Cancel == true)
                    {
                        tsbtboghi.Enabled = false;
                        tsbtghiso.Enabled = false;
                    }

                    try
                    {

                        cbthue.Text = data.Tax.ToString();
                    }
                    catch { }
                    try
                    {
                        string nv = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + data.EmployeeIDSA.ToString() + "'");
                        lenv.EditValue = nv;
                    }
                    catch
                    {
                        lenv.EditValue = "3";
                    }
                    txtcth.Text = String.Format("{0:n0}", Double.Parse(ViewNOVAT.Columns["Thành tiền"].SummaryText));

                    txttthue.EditValue = data.TotalAmountOC;
                    txtgiavon.EditValue = data.CostCap;
                    txtbx.Text = String.Format("{0:n0}", Double.Parse(ViewVAT.Columns["Bốc xếp"].SummaryText));                    
                    txtvc.EditValue = Double.Parse(ViewVAT.Columns["Vận chuyển"].SummaryText);
                    txtpk.Text = String.Format("{0:n0}", Double.Parse(ViewVAT.Columns["Chi phí khác"].SummaryText));
                    
                    txtname.Text = data.AccountingObjectName;
                    txtptgh.Text = data.ReceiveMethod;
                    if (data.AccountingObjectType == 1)
                        chhc.Checked = true;
                    else
                        chhc.Checked = false;
                    if (data.Status == "True")
                        chdn.Checked = true;
                    else
                        chdn.Checked = false;
                    txtpxk.Text = data.RefIDInOutward;

                    if (data.RefIDInvoice == true)
                        chvctc.Checked = true;
                    else
                        chvctc.Checked = false;

                }
                
                  */  
                ///txtSQL.Text = sql;

            }// if active = 1 - edit

          //  XtraMessageBox.Show(active + role, "view_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
        

    }



        int key = 0;
        string SQLString = "";
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                //MessageBox.Show("ButtonEdit Validated!");

                //lblUsername.Text = gen.GetString2("Users", "FullName", "UserName", txtUser.Text, clientid);
                return true;
            }

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public Frm_DNDH()
        {
            InitializeComponent();
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




    }
}//