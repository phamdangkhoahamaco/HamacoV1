using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using DevExpress.XtraSplashScreen;

namespace HAMACO
{
    public partial class Frm_baocaotaichinh : DevExpress.XtraEditors.XtraForm
    {
        public Frm_baocaotaichinh()
        {
            InitializeComponent();
        }
        string chungtu, tsbt, userid, ID, ngaychungtu, makho, donvi;
        public delegate void ac();
        public ac myac;
        DataTable dt = new DataTable();
        DataTable khach = new DataTable();
        Double congno = 0;
        gencon gen = new gencon();

        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        public string getchungtu(string a)
        {
            chungtu = a;
            return chungtu;
        }
        public string getngaychungtu(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getid(string a)
        {
            ID = a;
            return ID;
        }
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        private void Frm_baocaotaichinh_Load(object sender, EventArgs e)
        {
            if (tsbt == "tsbthdbhchange" || tsbt=="tsbtddhlpgchange")
            {
                labelControl11.Text = "Mã khách cũ";
                labelControl1.Text = "Mã khách mới";
                textEdit1.Visible = false;
                searchLookUpEdit1.Visible = true;
                if (tsbt == "tsbthdbhchange")
                {
                    DataTable dulieu = gen.GetTable("select AccountingObjectCode,a.BranchID, PURefDate,a.TotalAmount-a.TotalDiscountAmount-a.TotalFreightAmount+a.TotalVATAmount from SSInvoice a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + ID + "'");
                    txtsct.Text = dulieu.Rows[0][0].ToString();
                    makho = dulieu.Rows[0][1].ToString();
                    //ngaychungtu = dulieu.Rows[0][2].ToString();
                    congno = Double.Parse(dulieu.Rows[0][3].ToString());
                    donvi = gen.GetString("select BranchID from Stock where StockID='" + makho + "'");
                }
                else if (tsbt == "tsbtddhlpgchange")
                    txtsct.Text = gen.GetString("select AccountingObjectCode from INOutwardLPG a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + ID + "'");
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
            else
                txtsct.Text = textEdit1.Text = chungtu;

        }

        private void sbok_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có thực sự muốn thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                if (tsbt == "tsbthdbhchange")
                {
                    try
                    {                            
                        DataTable makhach = gen.GetTable("select  AccountingObjectID,AccountingObjectName,Address,CompanyTaxCode from  AccountingObject where  AccountingObjectCode='" + searchLookUpEdit1.EditValue + "'");
                        /*
                        Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;
                        if (Double.Parse(txthm.EditValue.ToString()) + Double.Parse(txthm.EditValue.ToString()) * phantram < Double.Parse(txtcn.EditValue.ToString()) + congno)
                        {
                            XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        */
                        
                        if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004" || gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
                        {
                            Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;

                            Double dinhmuc = 0;
                            if (phantram > 0 && phantram < 0.5)
                                dinhmuc = 50000000;
                            else if (phantram > 0.5 && phantram < 1)
                                dinhmuc = 150000000;
                            else if (phantram == 1)
                                dinhmuc = 300000000;

                            if (sehd.Text != "" && (Double.Parse(txthm.EditValue.ToString()) + Double.Parse(txthm.EditValue.ToString()) * phantram < Double.Parse(txtcn.EditValue.ToString()) + congno || Double.Parse(txthm.EditValue.ToString()) + dinhmuc < Double.Parse(txtcn.EditValue.ToString()) + congno))
                            {
                                XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
                                if (Double.Parse(txthm.EditValue.ToString()) < Double.Parse(txtcn.EditValue.ToString()) - congno)
                                {
                                    XtraMessageBox.Show("Vui lòng thu tiền trước khi xuất lô hàng tiếp theo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                        }
                        else
                        {
                            Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;

                            Double dinhmuc = 0;
                            if (phantram > 0 && phantram < 0.5)
                                dinhmuc = 100000000;
                            else if (phantram >= 0.5)
                                dinhmuc = 300000000;

                            if ((Double.Parse(txthm.EditValue.ToString()) + Double.Parse(txthm.EditValue.ToString()) * phantram < Double.Parse(txtcn.EditValue.ToString()) + congno || Double.Parse(txthm.EditValue.ToString()) + dinhmuc < Double.Parse(txtcn.EditValue.ToString()) + congno))
                            {
                                XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        if (txtsct.Text != searchLookUpEdit1.Text && gen.GetString("select AccountingObjectType from SSInvoice where RefID='" + ID + "'") == "1")
                        {
                            Double hanmuc = 20000000;
                            Double tongxuat = Double.Parse(gen.GetString("select COALESCE(Sum(TotalAmount+TotalCost-TotalDiscountAmount-TotalFreightAmount+TotalVATAmount),0) from SSInvoice where Convert(varchar, CABARefDate,111)=(select Convert(varchar, CABARefDate,111) from SSInvoice where RefID='" + ID + "') and AccountingObjectID='" + makhach.Rows[0][0] + "' and AccountingObjectType='1' "));
                            Double tong = Double.Parse(gen.GetString("select COALESCE(TotalAmount+TotalCost-TotalDiscountAmount-TotalFreightAmount+TotalVATAmount,0) from SSInvoice where RefID='" + ID + "'"));
                            if (tongxuat + tong > hanmuc)
                            {
                                XtraMessageBox.Show("Tổng số tiền mặt trong ngày vượt quá 20 triệu, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        gen.ExcuteNonquery("update INOutwardLPG set AccountingObjectID='" + makhach.Rows[0][0] + "',AccountingObjectName=N'" + makhach.Rows[0][1] + "',AccountingObjectAddress=N'" + makhach.Rows[0][2] + "' where RefID in (select INOutwardRefID from (select Distinct INOutwardID from SSInvoiceINOutward where SSInvoiceID='" + ID + "') a, INOutward b where a.INOutwardID=b.RefID)");
                        gen.ExcuteNonquery("update DDH set AccountingObjectID='" + makhach.Rows[0][0] + "',AccountingObjectName=N'" + makhach.Rows[0][1] + "',AccountingObjectAddress=N'" + makhach.Rows[0][2] + "' where RefIDInOutward in (select RefNo from (select Distinct INOutwardID from SSInvoiceINOutward where SSInvoiceID='" + ID + "') a, INOutward b where a.INOutwardID=b.RefID)");
                        gen.ExcuteNonquery("update INOutward set AccountingObjectID='" + makhach.Rows[0][0] + "',AccountingObjectName=N'" + makhach.Rows[0][1] + "',AccountingObjectAddress=N'" + makhach.Rows[0][2] + "' where RefID in (select Distinct INOutwardID from SSInvoiceINOutward where SSInvoiceID='" + ID + "')");
                        gen.ExcuteNonquery("update SSInvoice set AccountingObjectID='" + makhach.Rows[0][0] + "',AccountingObjectName=N'" + makhach.Rows[0][1] + "',AccountingObjectAddress=N'" + makhach.Rows[0][2] + "',CustomField5='" + makhach.Rows[0][3] + "' where RefID='" + ID + "'");
                        gen.ExcuteNonquery("update HACHTOAN set AccountingObjectID='" + makhach.Rows[0][0] + "',AccountingObjectIDMain='" + makhach.Rows[0][0] + "' where RefID='" + ID + "'");
                        gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Đổi mã khách','" + chungtu + " " + txtsct.Text + "=" + searchLookUpEdit1.EditValue + "')");
                        XtraMessageBox.Show("Mã khách < " + txtsct.Text + " > đã được đổi thành < " + searchLookUpEdit1.EditValue + " > vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch
                    {
                        XtraMessageBox.Show("Bạn phải chọn mã khách mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (tsbt == "tsbtddhlpgchange")
                {
                    DataTable makhach = gen.GetTable("select  AccountingObjectID,AccountingObjectName,Address,CompanyTaxCode from  hamaco.dbo.AccountingObject where  AccountingObjectCode='" + searchLookUpEdit1.EditValue + "'");
                    //DataTable makhach_ta = gen.GetTable("select  AccountingObjectID,AccountingObjectName,Address,CompanyTaxCode from  hamaco_ta.dbo.AccountingObject where  AccountingObjectCode='" + searchLookUpEdit1.EditValue + "'");
                    //DataTable makhach_tn = gen.GetTable("select  AccountingObjectID,AccountingObjectName,Address,CompanyTaxCode from  hamaco_tn.dbo.AccountingObject where  AccountingObjectCode='" + searchLookUpEdit1.EditValue + "'");
                    //gen.ExcuteNonquery("update hamaco.dbo.INOutward set AccountingObjectID='" + makhach.Rows[0][0] + "',AccountingObjectName=N'" + makhach.Rows[0][1] + "',AccountingObjectAddress=N'" + makhach.Rows[0][2] + "' where INOutwardRefID='" + ID + "'");
                    //gen.ExcuteNonquery("update hamaco_ta.dbo.INOutward set AccountingObjectID='" + makhach_ta.Rows[0][0] + "',AccountingObjectName=N'" + makhach_ta.Rows[0][1] + "',AccountingObjectAddress=N'" + makhach_ta.Rows[0][2] + "' where INOutwardRefID='" + ID + "'");
                    //gen.ExcuteNonquery("update hamaco_tn.dbo.INOutward set AccountingObjectID='" + makhach_tn.Rows[0][0] + "',AccountingObjectName=N'" + makhach_tn.Rows[0][1] + "',AccountingObjectAddress=N'" + makhach_tn.Rows[0][2] + "' where INOutwardRefID='" + ID + "'");
                    gen.ExcuteNonquery("update INOutwardLPG set AccountingObjectID='" + makhach.Rows[0][0] + "',AccountingObjectName=N'" + makhach.Rows[0][1] + "',AccountingObjectAddress=N'" + makhach.Rows[0][2] + "' where RefID='" + ID + "'");
                    XtraMessageBox.Show("Mã khách < " + txtsct.Text + " > đã được đổi thành < " + searchLookUpEdit1.EditValue + " > vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    try
                    {
                        string ton = null;
                        if (tsbt == "tsbthdbh")
                            ton = gen.GetString("select * from SSInvoice where RefNo='" + textEdit1.Text + "'");
                        else if (tsbt == "tsbthdmh")
                            ton = gen.GetString("select * from PUInvoice where RefNo='" + textEdit1.Text + "'");
                        XtraMessageBox.Show("Số phiếu < " + textEdit1.Text + " > đã có trong hệ thống vui lòng xem lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        if (tsbt == "tsbthdbh")
                            gen.ExcuteNonquery("update SSInvoice set RefNo='" + textEdit1.Text + "' where RefID='" + ID + "'");
                        else if (tsbt == "tsbthdmh")
                            gen.ExcuteNonquery("update PUInvoice set RefNo='" + textEdit1.Text + "' where RefID='" + ID + "'");
                        gen.ExcuteNonquery("update HACHTOAN set RefNo='" + textEdit1.Text + "' where RefID='" + ID + "'");
                        this.myac();
                        gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Đổi phiếu','" + txtsct.Text + "=" + textEdit1.Text + "')");
                        XtraMessageBox.Show("Số phiếu < " + txtsct.Text + " > đã được đổi thành < " + textEdit1.Text + " > vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void loadhanmuc(string makhach)
        {
            //string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            //string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            Double hanmuc = 0, hanno = 0;
            DataTable temp = new DataTable();
            DataTable da = gen.GetTable("select a.ParentContract,DebtLimitMax,LimitDate,a.SignedDate,EffectiveDate from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where (ContractName=N'Bán hàng' or ContractName=N'' or No='2') and AccountingObjectID='" + makhach + "' and SignedDate<='" + ngaychungtu + "'and EffectiveDate>='" + ngaychungtu + "' and DebtLimit>0 and Inactive=1 and StockID in ( select StockID from Stock where BranchID='" + donvi + "') group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
            if (da.Rows.Count > 0 || gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004")
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
            else if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "18001113092")
            {
                txthm.EditValue = "1.000.000";
                txthn.EditValue = "0";
                txtcn.EditValue = Double.Parse(gen.GetString("bangkecongnohanmuckhachhang '" + donvi + "','" + makhach + "', '" + ngaychungtu + "'"));
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

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (tsbt == "tsbthdbhchange")
                loadhanmuc(gen.GetString("select  AccountingObjectID from  AccountingObject where  AccountingObjectCode='" + searchLookUpEdit1.EditValue + "'"));
        }

    }
}