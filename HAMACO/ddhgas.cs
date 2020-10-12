using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HAMACO.Resources;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Net.Mail;
using System.Net;

using System.IO.Ports;

using System.Net.Sockets;
using System.Threading;

using System.Text.RegularExpressions;

namespace HAMACO
{
    public partial class ddhgas : DevExpress.XtraEditors.XtraForm
    {
        public ddhgas()
        {
            InitializeComponent();          
            UDP_Thread();       
        }


        //Vùng thử dữ cuộc gọi đến
        
        UdpClient MyUDP = new UdpClient(1691);
        Thread UDPthread = default(Thread);
    
        private void UDP_Thread()
        {
            UDPthread = new Thread(UDP_Recive);
            UDPthread.Start();
            UDPthread.IsBackground = true;
        }

        private void UDP_Recive()
        {
            try
            {
                string RecvBuf = null;
                IPEndPoint remoteHost = new IPEndPoint(IPAddress.Any, 0);
                while ((MyUDP != null))
                {
                    byte[] buf = MyUDP.Receive(ref remoteHost);
                    RecvBuf = Encoding.ASCII.GetString(buf, 0, buf.Length);
                    Console.WriteLine(RecvBuf);
                    string[] cuocgoi = RecvBuf.Split(',');
                    if (cuocgoi[4] == "1")
                        SetText(cuocgoi[1]);
                }
            }catch{}

        }

        delegate void MethodInvoker(string text);
        private void SetText(string p)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(this.SetText);
                this.Invoke(invoker, p);
                return;
            }
            this.textEdit4.Text = p;
        }

        //Kết thúc

        DataTable dt = new DataTable();
        gencon gen = new gencon();
        doiso doi = new doiso();
       
        DataTable hangton = new DataTable();
        hdbanhang hdbh = new hdbanhang();
        dondathanglpg ddh = new dondathanglpg();
        DataTable khach = new DataTable();
        DataTable khachle = new DataTable();
        DataTable giaban = new DataTable();
        DataTable hang = new DataTable();
        public delegate void ac();
        public ac myac;
        string role, active, ngaychungtu, userid, branchid, pt, caseup, click, roleid, subsys, load = null, mahangtam, loi, makhachtam = null, hopdong = null;
        int K = -2;
        Double slhien = 0, slqdhien = 0,congnotam=0;

        sms sms = new sms();
        SerialPort _PORT = new SerialPort();

        public string getloi(string a)
        {
            loi = a;
            return loi;
        }
        public DataTable gethangton(DataTable a)
        {
            hangton = a;
            return hangton;
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
        public DataTable getgiaban(DataTable a)
        {
            giaban = a;
            return giaban;
        }

        public string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }  


        public void refreshpxk()
        {
            congnotam = 0;
            ddh.loadpxk(active, role, gridControl1, gridView1, txtsct, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, this, ledt, txtldn, txtctg, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, txtngh, dongia, thanhtien, txtcth, cbthue, lenv, chiphi, chietkhau, tsbttruoc, tsbtsau, khach, hang, txttthue, gridControl2, gridView2, txtname, txtdc, congty, txthamaco, txtthienan, txtdichvu, gridQT, ViewQT, txtsdt, splitContainerControl1, cbpt, cblkh, lbduyet, chduyet, cbptgh, txtphitaixe, txtphigiaonhan, cbgiaonhan, txtdienthoai, gridControl3, gridView7, txtck, cbtinh, cbhuyen, cbxa, txtdcc);
            if (active == "1")
            {
                congnotam = Double.Parse(txttc.EditValue.ToString());
                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        hopdong = sehd.Text;
                        break;
                    }
            }
        }
        
        private void ddhgas_Load(object sender, EventArgs e)
        {
            //sms
            if (sms.AutoConnect(_PORT) == false)
            {}
            //kết thúc sms
            
            dt = gen.GetTable("select * from MSC_RolePermissionMaping where RoleID='" + roleid + "' and SubSystemCode='" + subsys + "'");
            napkhachle();
            refreshrole();
            refreshpxk();
            change();
            load = "0";
            radioGroup1.SelectedIndex = -1;
        }

        private void ddhgas_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát và làm mới dữ liệu?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Yes)
            {
                _PORT.Close();
                _PORT = null;

                try
                {
                    this.myac();
                    MyUDP.Close();
                }
                catch { }
                this.Dispose();
            }
            else if (dr == DialogResult.No)
            {
                _PORT.Close();
                _PORT = null;

                MyUDP.Close();

                this.Dispose();
            }
            else if (dr == DialogResult.Cancel)
                e.Cancel = true;
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

        private void change()
        {
            if (tsbtcat.Enabled == true)
            {
                if (active == "0")
                {
                    ledv.Properties.ReadOnly = false;
                }

                if (Double.Parse(gen.GetString("select AuthenticationType from MSC_User where UserID='" + userid + "'")) > 0)
                    chduyet.Enabled = true;

                denct.Properties.ReadOnly = false;
                denht.Properties.ReadOnly = false;

                cbldt.Properties.ReadOnly = false;
                ledt.Properties.ReadOnly = false;
                lenv.Properties.ReadOnly = false;
                txtldn.Properties.ReadOnly = false;
                txtdienthoai.Properties.ReadOnly = false;
                txtphitaixe.Properties.ReadOnly = false;
                txtphigiaonhan.Properties.ReadOnly = false;
                //txtptgh.Properties.ReadOnly = false;
                //txtptvc.Properties.ReadOnly = false;
                //txtgiaonhan.Properties.ReadOnly = false;
                cbgiaonhan.Properties.ReadOnly = false;
                cbpt.Properties.ReadOnly = false;
                cbptgh.Properties.ReadOnly = false;

                cbthue.Properties.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.Editable = true;
                if (chduyet.Checked == true)
                {
                    gridView1.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Chi phí"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Số lượng quy đổi"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Công ty"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Ghi chú"].OptionsColumn.AllowEdit = false;
                }
                txtngh.Properties.ReadOnly = false;
                txtctg.Properties.ReadOnly = false;                
                txtctg.Properties.ReadOnly = false;
               
                tsbtxoa.Enabled = false;
                tsbtin.Enabled = false;
                if (active == "1")
                {
                    tsbtnap.Enabled = true;
                }
                tsbtsua.Enabled = false;
                tsbtghiso.Visible = false;
                ledv.Focus();
            }
            else
            {
                ledv.Properties.ReadOnly = true;
                lenv.Properties.ReadOnly = true;
                cbldt.Properties.ReadOnly = true;
                ledt.Properties.ReadOnly = true;
                txtldn.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;
                txtdienthoai.Properties.ReadOnly = true;
                denct.Properties.ReadOnly = true;
                
                denht.Properties.ReadOnly = true;
                cbthue.Properties.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                txtngh.Properties.ReadOnly = true;
                txtctg.Properties.ReadOnly = true;

                //txtgiaonhan.Properties.ReadOnly = true;
                //txtptgh.Properties.ReadOnly = true;
                //txtptvc.Properties.ReadOnly = true;
                cbgiaonhan.Properties.ReadOnly = true;
                cbpt.Properties.ReadOnly = true;
                cbptgh.Properties.ReadOnly = true;

                txtphitaixe.Properties.ReadOnly = true;
                txtphigiaonhan.Properties.ReadOnly = true;
                

                if (click == "true")
                {
                    tsbtghiso.Visible = false;
                    tsbtghiso.Visible = true;
                }
                ledv.Focus();
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

        private void mahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = gridView1.FocusedRowHandle;
                radioGroup1.SelectedIndex = 1;
                searchLookUpEdit1.Focus();
            }
        }
        private void lenv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                lenv.EditValue = null;
            }
            else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                K = -3;
                radioGroup1.SelectedIndex = 0;
                searchLookUpEdit1.Focus();
            }
        }

        private void dongia_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "7";
        }
        private void soluong_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "3";
            try
            {
                slhien = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
            }
            catch { }
        }
        private void soluongqd_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "10";
            try
            {
                slqdhien = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
            }
            catch { }
        }
        private void mahang_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "4";
            try
            {
                mahangtam = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString();
            }
            catch { }
        }
        private void thanhtien_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "2";
        }

        private void chiphi_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "5";
        }
        private void chietkhau_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "6";
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Mã hàng")
            {
                try
                {
                    if (caseup == "4")
                    {
                        Double ketqua = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString());
                        if (ketqua != 0)
                        {
                            XtraMessageBox.Show("< Số lượng quy đổi đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString() + " bạn không được nhập mã khác", "Thông báo");
                            caseup = null;
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], mahangtam);
                        }
                        {
                            for (int i = 0; i < hang.Rows.Count; i++)
                            {
                                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                                {
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Công ty"], hang.Rows[i][7].ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Công ty"], "Dịch vụ HAMACO");
                                    if (ledv.EditValue.ToString() == "07")
                                        for (int j = 0; j < giaban.Rows.Count; j++)
                                        {
                                            if (hang.Rows[i][0].ToString() == giaban.Rows[j][2].ToString() && makhachtam == giaban.Rows[j][1].ToString())
                                            {
                                                caseup = "6";
                                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], giaban.Rows[j][3].ToString());
                                                return;
                                            }
                                        }
                                    return;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    for (int i = 0; i < hang.Rows.Count; i++)
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], hang.Rows[i][2].ToString());
                            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Công ty"], hang.Rows[i][7].ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Công ty"], "Dịch vụ HAMACO");
                            if (ledv.EditValue.ToString() == "07")
                                for (int j = 0; j < giaban.Rows.Count; j++)
                                {
                                    if (hang.Rows[i][0].ToString() == giaban.Rows[j][2].ToString() && makhachtam == giaban.Rows[j][1].ToString())
                                    {
                                        caseup = "6";
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], giaban.Rows[j][3].ToString());
                                        return;
                                    }
                                }
                            return;
                        }
                    }
                }
            }
            gridView1.UpdateCurrentRow();
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    Double kiemtra = 0;
                    Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                    if (active == "1")
                    {
                        try
                        {
                            Double slton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString());
                            if (sl >= slton)
                                kiemtra = 1;
                        }
                        catch { kiemtra = 1; }
                    }
                    if (kiemtra == 1 || active == "0")
                    {
                        caseup = "1";
                        for (int i = 0; i < hang.Rows.Count; i++)
                        {
                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hang.Rows[i][1].ToString())
                            {
                                Double quydoi = Double.Parse(hang.Rows[i][5].ToString());
                                quydoi = Math.Round((sl * quydoi), 2);
                                if (active == "1")
                                {
                                    try
                                    {
                                        if (quydoi >= Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString()))
                                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], quydoi.ToString());
                                    }
                                    catch
                                    {
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi tồn"], "0");
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], quydoi.ToString());
                                    }
                                }
                                else
                                {
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], quydoi.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("< Số lượng đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng tồn").ToString() + " vui lòng nhập số lượng lớn hơn", "Thông báo");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], slhien.ToString());
                    }
                }
                catch { }
            }
            if (pt == "pxk" || pt == "pxkbarem")
            {
                if (e.Column.FieldName == "Số lượng quy đổi")
                {
                    if (caseup == "1" || caseup=="10")
                    {
                        Double kiemtra = 0;
                        Double sl = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        if (active == "1")
                        {
                            try
                            {
                                Double slton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString());
                                if (sl >= slton)
                                    kiemtra = 1;
                            }
                            catch { kiemtra = 1; }
                        }
                        if (kiemtra == 1 || active == "0")
                        {
                            if (caseup == "1")
                            {
                                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                                }
                                else if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí").ToString());
                                    Double c = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                                    if (c != 0)
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((a * b / c), 2).ToString());
                                }
                                else if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                                }
                            }
                            else if (caseup == "10")
                            {
                                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                                }
                                else if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                                }
                                else if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí").ToString() != "")
                                {
                                    Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                                    Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí").ToString());
                                    Double c = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                                    if (c != 0)
                                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((a * b / c), 2).ToString());
                                }  
                            }
                            
                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                            {
                                Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                                Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                                if (a != 0)
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], Math.Round((b / a), 2).ToString());
                            }
                            
                            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "")
                            {
                                Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                                Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a), 0).ToString());
                            }
                            ddh.loadthhdmain(gridView2, gridView1, txtcth, cbthue);
                        }
                        else
                        {
                            XtraMessageBox.Show("< Số lượng quy đổi đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString() + " vui lòng nhập số lượng quy đổi lớn hơn", "Thông báo");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], slqdhien.ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Đơn giá")
                {
                    if (caseup == "7")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                            ddh.loadthhdmain(gridView2, gridView1, txtcth, cbthue);
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            if (a != 0)
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], Math.Round((b / a), 2).ToString());
                        }
                    }

                }

                else if (e.Column.FieldName == "Thành tiền")
                {
                    Double thanhtien = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText);
                    txtcth.Text = String.Format("{0:n0}", thanhtien);
                    if (caseup == "2")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                            ddh.loadthhdmain(gridView2, gridView1, txtcth, cbthue);
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            if (a != 0)
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chi phí"], Math.Round((b / a), 2).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Chiết khấu")
                {
                    if (caseup == "6")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chiết khấu").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tiền CK"], Math.Round((b * a), 0).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Tiền CK")
                {
                    if (caseup == "5")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tiền CK").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tiền CK").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Chiết khấu"], Math.Round((a / b), 2).ToString());
                        }
                    }
                }

                else if (e.Column.FieldName == "Chi phí")
                {
                    if (caseup == "6")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Chi phí").ToString());
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Math.Round((a * b), 0).ToString());
                            ddh.loadthhdmain(gridView2, gridView1, txtcth, cbthue);
                        }
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString() != "")
                        {
                            Double a = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi").ToString());
                            Double b = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thành tiền").ToString());
                            if (a != 0)
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Đơn giá"], Math.Round((b / a), 2).ToString());
                        }
                    }
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, EventArgs e)
        {
            gridView1_FocusedRowChanged();
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                for (int i = 0; i < hangton.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() == hangton.Rows[i][3].ToString())
                    {
                        if (Double.Parse(hangton.Rows[i][1].ToString()) != 0)
                            textEdit1.Text = String.Format("{0:n0}", Double.Parse(hangton.Rows[i][1].ToString()));
                        else
                            textEdit1.Text = null;
                        if (Double.Parse(hangton.Rows[i][2].ToString()) != 0)
                            textEdit2.Text = String.Format("{0:n2}", Double.Parse(hangton.Rows[i][2].ToString()));
                        else
                            textEdit2.Text = null;
                        if (Double.Parse(hangton.Rows[i][1].ToString()) != 0 && Double.Parse(hangton.Rows[i][2].ToString()) != 0)
                            textEdit3.Text = String.Format("{0:n3}", Math.Round(Double.Parse(hangton.Rows[i][2].ToString()) / Double.Parse(hangton.Rows[i][1].ToString()), 3));
                        else
                            textEdit3.Text = null;
                        return;
                    }
                }
                textEdit1.Text = null;
                textEdit2.Text = null;
                textEdit3.Text = null;
            }
            catch
            {
                textEdit1.Text = null;
                textEdit2.Text = null;
                textEdit3.Text = null;
            }
        }


        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView2.UpdateCurrentRow();
            txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && tsbtcat.Enabled == true)
            {
                try
                {
                    Double ton = Double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString());
                    if (ton != 0)
                    {
                        XtraMessageBox.Show("< Số lượng quy đổi đã nhập cho hóa đơn là > " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Số lượng quy đổi tồn").ToString() + " nên bạn không được xóa dòng này", "Thông báo");
                    }
                    else
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView1.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;
                        gridView2.DeleteRow(gridView1.FocusedRowHandle);
                        gridView1.DeleteRow(gridView1.FocusedRowHandle);
                        txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
                    }
                }
                catch
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView1.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                }
            }
        }

        private void gridView7_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                try
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView7.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    gridView7.DeleteRow(gridView7.FocusedRowHandle);              
                }
                catch
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dòng " + (Int32.Parse(gridView7.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    gridView7.DeleteRow(gridView7.FocusedRowHandle);
                }
            }
            else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn chuyển dữ liệu dòng " + (Int32.Parse(gridView7.FocusedRowHandle.ToString()) + 1).ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                if (gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Mã kho").ToString() != "")
                    ledv.EditValue = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Mã kho").ToString();
                if(ledv.Text=="")
                    ledv.ItemIndex = 0;
                tsbtadd_Click(sender, e);
                ledt.EditValue = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Mã khách").ToString();
                txtname.Text = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Tên khách").ToString();

                cbtinh.EditValue = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Tỉnh").ToString();
                cbhuyen.EditValue = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Huyện").ToString();
                cbxa.EditValue = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Xã").ToString();
                txtdcc.Text = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Địa chỉ con").ToString();

                txtdc.Text = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Địa chỉ").ToString();
                txtsdt.Text = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Số điện thoại").ToString();
                cblkh.Text = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Đối tượng").ToString();
                txtldn.Text = "Bán lẻ";
                cblkh.Visible = true;
                
                    DataTable temp = gen.GetTable("select InventoryItemCode,InventoryItemName,a.Quantity,a.QuantityConvert,a.UnitPrice,a.AmountOC,a.Description  from INOutwardLPGDetail a, InventoryItem b, (select Top 1 * from INOutwardLPG where CustomField8='" + txtsdt.Text + "' order by RefDate DESC) c where a.RefID=c.RefID and a.InventoryItemID=b.InventoryItemID order by SortOrder");
                    for (int j = 0; j < temp.Rows.Count; j++)
                    {
                        gridView1.AddNewRow();
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], temp.Rows[j][0].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], temp.Rows[j][1].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], Double.Parse(temp.Rows[j][2].ToString()));
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Double.Parse(temp.Rows[j][3].ToString()));
                        caseup = "2";
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Double.Parse(temp.Rows[j][5].ToString()));
                        //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Công ty"], temp.Rows[j][6].ToString());
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Công ty"], "Dịch vụ HAMACO");
                        gridView1.UpdateCurrentRow();
                    }

                gridView7.DeleteRow(gridView7.FocusedRowHandle); 
            }
            if (gridView7.RowCount == 0)
            {
                gridControl3.Visible = false;
                textEdit4.Text = null;
            }
        }

        private void cbldt_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void ledt_EditValueChanged(object sender, EventArgs e)
        {
            /*try
            {*/
            if (ledt.EditValue != null)
                for (int i = 0; i < khach.Rows.Count; i++)
                {
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        makhachtam = khach.Rows[i][0].ToString();
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
            /*}
            catch { }*/
        }

        private void loadhanmuc(string makhach)
        {
            string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            Double hanmuc = 0, hanno = 0;
            DataTable temp = new DataTable();
            DataTable da = gen.GetTable("select a.ParentContract,DebtLimitMax,LimitDate,a.SignedDate,EffectiveDate from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where (ContractName=N'Bán hàng' or ContractName=N'' or No='2') and  AccountingObjectID='" + makhach + "' and SignedDate<='" + ngaychungtu + "'and EffectiveDate>='" + ngaychungtu + "' and Inactive=1 and StockID in ( select StockID from Stock where BranchID='" + donvi + "') group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
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

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (active == "0")
                {
                    ddh.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                    ddh.checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
                }
                string kho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
                string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                hangton = gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txtcth_EditValueChanged(object sender, EventArgs e)
        {
            /*Double cth, thue, gtgt, tong;
            cth = Double.Parse(txtcth.Text);
            try
            {
                thue = Double.Parse(cbthue.Text);
                gtgt = Math.Round((cth / 100) * thue, 0, MidpointRounding.AwayFromZero);
            }
            catch
            {
                gtgt = 0;
            }
            tong = cth + gtgt;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
             */
            Double cth, thue, gtgt, tong, ck;
            cth = Double.Parse(txtcth.Text);
            try
            {
                ck = Double.Parse(txtck.Text);
            }
            catch { ck = 0; }

            try
            {
                thue = Double.Parse(cbthue.Text);
                ck = ck / (1 + Double.Parse(cbthue.Text) / 100);
                gtgt = Math.Round(((cth - ck) / 100) * thue, 0, MidpointRounding.AwayFromZero);
            }
            catch
            {
                gtgt = 0;
            }
            tong = cth + gtgt - ck;
            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void txttthue_EditValueChanged(object sender, EventArgs e)
        {
            /*
            Double cth, gtgt, tong;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { cth = 0; }
            gtgt = Double.Parse(txttthue.Text);
            tong = cth + gtgt;

            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
            */
            Double cth, gtgt, tong, ck;
            try
            {
                cth = Double.Parse(txtcth.Text);
            }
            catch { cth = 0; }
            try
            {
                ck = Double.Parse(txtck.Text);
                ck = ck / (1 + Double.Parse(cbthue.Text) / 100);
            }
            catch { ck = 0; }

            gtgt = Double.Parse(txttthue.Text);
            tong = cth + gtgt - ck;

            txttthue.EditValue = gtgt;
            txttc.Text = String.Format("{0:n0}", tong);
            if (cth == 0)
                lbtienchu.Text = "";
        }

        private void cbthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddh.loadthhdmain(gridView2, gridView1, txtcth, cbthue);
            }
            catch { }
            /*try
            {
                Double cth, thue, gtgt, tong;
                cth = Double.Parse(txtcth.Text);
                try
                {
                    thue = Double.Parse(cbthue.Text);
                    gtgt = Math.Round((cth / 100) * thue, 0);
                }
                catch
                {
                    gtgt = 0;
                }
                tong = cth + gtgt;
                txttc.Text = String.Format("{0:n0}", tong);
                txttthue.EditValue = gtgt;
            }
            catch { }*/
            try
            {
                Double cth, thue, gtgt, tong, ck;
                cth = Double.Parse(txtcth.Text);
                try
                {
                    ck = Double.Parse(txtck.Text);
                }
                catch { ck = 0; }

                try
                {
                    thue = Double.Parse(cbthue.Text);
                    ck = ck / (1 + Double.Parse(cbthue.Text) / 100);
                    gtgt = Math.Round(((cth - ck) / 100) * thue, 0, MidpointRounding.AwayFromZero);
                }
                catch
                {
                    gtgt = 0;
                }
                tong = cth + gtgt - ck;
                txttc.Text = String.Format("{0:n0}", tong);
                txttthue.EditValue = gtgt;
            }
            catch { }
        }

        private void txttc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lbtienchu.Text = "Số tiền viết bằng chữ: " + doi.ChuyenSo(txttc.Text.Replace(".", "").Replace("-", ""));
            }
            catch { }
        }

        private void tsbtcat_Click(object sender, EventArgs e)
        {
            if (txtnv.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập nhân viên bán hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (gen.GetString("select Prefix from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'") != "1")
                if (Double.Parse(gen.GetString("select COALESCE(sum(ExitsMoney),0) from OpenExDate where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and DateEx>30 and AccountingObjectID='" + gen.GetString("select AccountingObjectID  from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "' ") + "'")) > 1000000)
                {
                    XtraMessageBox.Show("Khách hàng có quá hạn trên 30 ngày vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            /*if (sehd.Text == "")
                {
                    if ((active == "0" && Double.Parse(txtcn.EditValue.ToString()) > 1000000) || (active == "1" && Double.Parse(txtcn.EditValue.ToString()) - Double.Parse(txttc.EditValue.ToString()) > 1000000))
                    {
                        XtraMessageBox.Show("Vui lòng thu tiền khách hàng trước khi bán lô hàng tiếp theo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            */
            Double phantram = Double.Parse(gen.GetString("select Website from MSC_User where UserID='" + userid + "'")) / 100;

            Double dinhmuc = 0;
            if (phantram > 0 && phantram < 0.5)
                dinhmuc = 50000000;
            else if (phantram >0.5 && phantram < 1)
                dinhmuc = 150000000;
            else if (phantram == 1)
                dinhmuc = 300000000;

            if (sehd.Text != "" && (Double.Parse(txthm.EditValue.ToString()) + Double.Parse(txthm.EditValue.ToString()) * phantram < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam || Double.Parse(txthm.EditValue.ToString()) + dinhmuc < Double.Parse(txtcn.EditValue.ToString()) + Double.Parse(txttc.EditValue.ToString()) - congnotam))
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ vượt hạn mức hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string donvi = gen.GetString("select BranchID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();

            //Double hientai = Double.Parse(gen.GetString("baocaocongnokiemtra '" + donvi + "','" + ngaychungtu + "','" + ngaychungtu + "','" + thangtruoc + "','" + namtruoc + "'"));
            Double hientai = 0;
            Double dangky = 0;

            string manganh = "";
            try
            {
                manganh = gen.GetString("select ItemSource from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(0, "Mã hàng").ToString() + "'");
                hientai = Double.Parse(gen.GetString("baocaocongnotheonganhhangchan '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + manganh + "'"));
            }
            catch { }

            hientai = hientai + Double.Parse(txttc.EditValue.ToString()) - congnotam;

            try
            {
                dangky = Double.Parse(gen.GetString("select COALESCE(Amount,0) from AmountBranchMN where Year='" + nam + "' and MN='" + manganh + "'"));
            }
            catch { }

            if (dangky < hientai)
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại Tổng công nợ hiện tại " + String.Format("{0:n0}", hientai) + " đồng so với mức đăng ký là " + String.Format("{0:n0}", dangky) + " đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ledv.Focus();
            ddh.checkpxk(active, role, this, gridView1, ledt, ledv, cbldt, txtsct, txtname, txtdc, txtngh, txtctg, txtldn, denct, denht, tsbtboghi, tsbtghiso, tsbtxoa, tsbtcat, tsbtin, tsbtsua, tsbtnap, ngaychungtu, txtmst, cbpt, userid, branchid, cbthue, lenv, tsbttruoc, tsbtsau, txttthue, gridView2, hangton, cbptgh, txthamaco, txtthienan, txtdichvu, txtsdt, ViewQT, cblkh, cbgiaonhan, txtphitaixe, txtphigiaonhan, txtdienthoai, txtck, txttc, cbtinh, cbhuyen, cbxa, txtdcc);
            if (loi != "1")
            {
                if (active == "1")
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Sửa','" + txtsct.Text + "')");
                else
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Thêm','" + txtsct.Text + "')");
                active = "1";
                refreshrole();
                click = "true";
                change();
                click = "false";

                congnotam = Double.Parse(txttc.EditValue.ToString());
                hopdong = sehd.Text;

                for (int i = 0; i < khach.Rows.Count; i++)
                    if (ledt.EditValue.ToString() == khach.Rows[i][1].ToString())
                    {
                        loadhanmuc(khach.Rows[i][0].ToString());
                        break;
                    }
            }
            else loi = "0";
        }

        private void tsbtsua_Click(object sender, EventArgs e)
        {
            active = "1";
            this.Text = "Sửa đơn đặt hàng LPG";
            tsbtcat.Enabled = true;
            tsbtxoa.Enabled = false;
            tsbtin.Enabled = false;
            tsbtnap.Enabled = true;
            tsbtsua.Enabled = false;
            tsbtghiso.Enabled = false;
            change();
            try
            {
                Double temp = Double.Parse(gen.GetString("select COALESCE(sum(QuantityConvertExits),0)  from  hamaco.dbo.INOutwardDetail where RefID=(select RefID from hamaco.dbo.INOutward where INOutwardRefID='" + role + "')"));
                temp = temp + Double.Parse(gen.GetString("select COALESCE(sum(QuantityConvertExits),0)  from  hamaco_ta.dbo.INOutwardDetail where RefID=(select RefID from hamaco_ta.dbo.INOutward where INOutwardRefID='" + role + "')"));
                temp = temp + Double.Parse(gen.GetString("select COALESCE(sum(QuantityConvertExits),0)  from  hamaco_tn.dbo.INOutwardDetail where RefID=(select RefID from hamaco_tn.dbo.INOutward where INOutwardRefID='" + role + "')"));
                if (temp != 0)
                {
                    gridView1.OptionsBehavior.Editable = false;
                    ledt.Properties.ReadOnly = true;
                    searchLookUpEdit1.Properties.ReadOnly = true;
                }
            }
            catch { }
            
        }

        private void tsbttruoc_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            ddh.checktruoc(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
            refreshpxk();
            change();
        }

        private void tsbttruocnhat_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            ddh.checktruoc(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
            refreshpxk();
            change();
        }

        private void tsbtsau_ButtonClick(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            ddh.checksau(txtsct.Text, 0, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
            refreshpxk();
            change();
        }

        private void tsbtsaucung_Click(object sender, EventArgs e)
        {
            active = "1";
            refreshrole();
            ddh.checksau(txtsct.Text, 1, tsbttruoc, tsbtsau, this, ngaychungtu, ledv.EditValue.ToString());
            refreshpxk();
            change();
        }

        private void tsbtadd_Click(object sender, EventArgs e)
        {
            active = "0";
            txtck.Text = "0";
            cbgiaonhan.Text = "";
            txtdienthoai.Text = "";
            ledt.EditValue = null;
            chduyet.Checked = false;
            lbduyet.Text = "";
            refreshrole();
            cbldt.SelectedIndex = 0;
            cbpt.SelectedIndex = -1;
            congnotam = 0;
            hopdong = null;
            cblkh.SelectedIndex = -1;
            //cblkh.Visible = false;            
            lenv.EditValue = null;
            txtctg.Text = "";
            cbptgh.Text = "";
            txtldn.Text = "";
            txtngh.Text = "";
            txtsdt.Text = "";
            txtsdt.Visible = false;
            txtname.Text = "";
            txtdcc.Text = "";
            txtdc.Text = "";
            cbpt.Text = "";
            txthamaco.Text = "";
            txtthienan.Text = "";
            txtdichvu.Text = "";
            txtmst.Text = "";
            denct.EditValue = DateTime.Parse(ngaychungtu);
            denht.EditValue = DateTime.Parse(ngaychungtu);
            txtcth.Text = "0";
            txtphigiaonhan.Text = "0";
            txtphitaixe.Text = "0";
            searchLookUpEdit2.EditValue = "";
            change();
            ddh.themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
            ddh.checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            this.Text = "Thêm phiếu xuất kho";
            while (gridView1.RowCount > 1)
            {
                gridView1.DeleteRow(0);
            }

            while (gridView2.RowCount > 0)
            {
                gridView2.DeleteRow(0);
            }

            for (int i = 0; i < ViewQT.RowCount; i++)
            {
                ViewQT.SetRowCellValue(i, ViewQT.Columns["Số lượng"], 0);
            }
        }

        private void tsbtghiso_Click(object sender, EventArgs e)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = false;
            tsbtsua.Enabled = false;
            gen.ExcuteNonquery("update INOutwardLPG set Posted='True' where RefID='" + role + "'");
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
            gen.ExcuteNonquery("update INOutwardLPG set Posted='False' where RefID='" + role + "'");
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Bỏ ghi','" + txtsct.Text + "')");
        }

        private void tsbtnap_Click(object sender, EventArgs e)
        {
            refreshrole();
            refreshpxk();
            change();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("dondathanglpg");
            F.getrole(role);
            F.ShowDialog();
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
                K = gridView1.RowCount;
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
            else if (K == -3)
            {
                lenv.EditValue = searchLookUpEdit1.EditValue;
                lenv.Focus();
            }
            else if (K != -1)
            {
                caseup = "4";
                try
                {
                    string temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tên hàng").ToString();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                    gridView1.Focus();
                }
                catch
                {
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], searchLookUpEdit1.EditValue);
                    gridView1.Focus();
                }
            }
        }

        private void tsbtin_ButtonClick(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("dondathanglpgpgh");
            F.getrole(role);
            F.ShowDialog();
        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < khachle.Rows.Count; i++)
                {
                    if (searchLookUpEdit2.EditValue.ToString() == khachle.Rows[i][4].ToString())
                    {
                        ledt.EditValue = khachle.Rows[i][0].ToString();
                        txtname.Text = khachle.Rows[i][1].ToString();
                        
                        txtsdt.Text = khachle.Rows[i][2].ToString();
                        cblkh.Text = khachle.Rows[i][5].ToString();

                        cbtinh.EditValue = khachle.Rows[i][6].ToString();
                        cbhuyen.EditValue = khachle.Rows[i][7].ToString();
                        cbxa.EditValue = khachle.Rows[i][8].ToString();
                        txtdcc.Text = khachle.Rows[i][9].ToString();

                        txtdc.Text = khachle.Rows[i][3].ToString();

                        splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
                        txtldn.Text = "Bán lẻ";
                        cblkh.Visible = true;
                        if (active == "0")
                        {
                            DataTable temp = gen.GetTable("select InventoryItemCode,InventoryItemName,a.Quantity,a.QuantityConvert,a.UnitPrice,a.AmountOC,a.Description  from INOutwardLPGDetail a, InventoryItem b, (select Top 1 * from INOutwardLPG where CustomField8='" + txtsdt.Text + "' order by RefDate DESC) c where a.RefID=c.RefID and a.InventoryItemID=b.InventoryItemID order by SortOrder");
                            for (int j = 0; j < temp.Rows.Count; j++)
                            {
                                gridView1.AddNewRow();
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Mã hàng"], temp.Rows[j][0].ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Tên hàng"], temp.Rows[j][1].ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng"], Double.Parse(temp.Rows[j][2].ToString()));
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Số lượng quy đổi"], Double.Parse(temp.Rows[j][3].ToString()));
                                caseup = "2";
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Thành tiền"], Double.Parse(temp.Rows[j][5].ToString()));
                                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Công ty"], temp.Rows[j][6].ToString());
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Công ty"], "Dịch vụ HAMACO");
                                gridView1.UpdateCurrentRow();
                            }
                        }
                        return;
                    }
                }
        }

        private void sbok_Click(object sender, EventArgs e)
        {
            napkhachle();
        }

        private void napkhachle()
        {
            searchLookUpEdit2.Properties.View.Columns.Clear();
            searchLookUpEdit2.Properties.View.Columns.AddField("Mã khách").Visible = true;
            searchLookUpEdit2.Properties.View.Columns.AddField("Tên khách").Visible = true;
            searchLookUpEdit2.Properties.View.Columns.AddField("Số điện thoại").Visible = true;
            searchLookUpEdit2.Properties.View.Columns.AddField("Địa chỉ").Visible = true;
            searchLookUpEdit2.Properties.View.Columns.AddField("Loại").Visible = true;
            searchLookUpEdit2.Properties.View.Columns.AddField("Tỉnh").Visible = true;
            khachle = gen.GetTable("select AccountingObjectCode as 'Mã khách',AccountingObjectName as 'Tên khách',CustomField8 as 'Số điện thoại',AccountingObjectAddress as 'Địa chỉ', newid() as 'Mã',ParalellRefNo as 'Loại',a.Province as 'Tỉnh',a.District as 'Huyện',a.Ward as 'Xã',AdressSon as 'Địa chỉ con' from (select distinct AccountingObjectCode,a.AccountingObjectName,a.CustomField8,a.AccountingObjectAddress,ParalellRefNo,a.Province,a.District,a.Ward,AdressSon from INOutwardLPG a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and CustomField8 is not NULL and CustomField8<>'') a  order by CustomField8");
            searchLookUpEdit2.Properties.DataSource = khachle;
            searchLookUpEdit2.Properties.DisplayMember = "Số điện thoại";
            searchLookUpEdit2.Properties.ValueMember = "Mã";
            searchLookUpEdit2.Properties.PopupFormWidth = 900;
            searchLookUpEdit2.Focus();
        }

        private void gridView1_FocusedRowChanged()
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtsdt.Visible == false)
            {
                simpleButton1.Text = "Đóng";
                txtsdt.Visible = true;
                cblkh.Visible = true;
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            }
            else
            {
                simpleButton1.Text = "Thêm";
                txtsdt.Visible = false;
                cblkh.Visible = false;
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            }
        }

        private void ttddh_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("dondathanglpgthongtin");
            F.getrole(role);
            F.ShowDialog();
        }     

        private void cblkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenkhach = txtname.Text;
            string diachi = txtdc.Text;
            if (cblkh.Text == "Bán lẻ")
                ledt.EditValue = "71003795";
            else if (cblkh.Text == "Quán ăn")
                ledt.EditValue = "71000001";
            else if (cblkh.Text == "Nhà hàng")
                ledt.EditValue = "71000002";
            txtname.Text = tenkhach;
            txtdc.Text = diachi;
        }

        private void chduyet_CheckedChanged(object sender, EventArgs e)
        {
            if (chduyet.Checked == true && lbduyet.Text == "" && ledt.EditValue!=null)
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có thực sự muốn duyệt đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lbduyet.Text = gen.GetString("select FullName from MSC_User where UserID='" + userid + "'");
                    chduyet.Enabled = false;
                    gen.ExcuteNonquery("update INOutwardLPG set UserCheck=N'" + lbduyet.Text + "' where RefID='" + role + "'");
                    gen.ExcuteNonquery("update hamaco.dbo.INOutward set UserCheck=N'" + lbduyet.Text + "' where RefNo='" + txthamaco.Text + "'");
                    gen.ExcuteNonquery("update hamaco_ta.dbo.INOutward set UserCheck=N'" + lbduyet.Text + "' where RefNo='" + txtthienan.Text + "'");
                    gen.ExcuteNonquery("update hamaco_tn.dbo.INOutward set UserCheck=N'" + lbduyet.Text + "' where RefNo='" + txtdichvu.Text + "'");
                    //string email = gen.GetString("select Email from INOutwardLPG a, MSC_User b where a.EmployeeID=b.UserID and RefID='" + role + "'");
                    //Sendmail(email, "Đơn hàng " + txtsct.Text + " của bạn đã được duyệt bởi " + lbduyet.Text + ".");
                }
                else
                    chduyet.Checked = false;
            else if (chduyet.Checked == false && lbduyet.Text != "" && ledt.EditValue!=null)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có thực sự muốn bỏ duyệt đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lbduyet.Text = "";
                    gen.ExcuteNonquery("update INOutwardLPG set UserCheck=N'" + lbduyet.Text + "' where RefID='" + role + "'");
                    gen.ExcuteNonquery("update hamaco.dbo.INOutward set UserCheck=N'" + lbduyet.Text + "' where RefNo='" + txthamaco.Text + "'");
                    gen.ExcuteNonquery("update hamaco_ta.dbo.INOutward set UserCheck=N'" + lbduyet.Text + "' where RefNo='" + txtthienan.Text + "'");
                    gen.ExcuteNonquery("update hamaco_tn.dbo.INOutward set UserCheck=N'" + lbduyet.Text + "' where RefNo='" + txtdichvu.Text + "'");
                    //string email = gen.GetString("select Email from INOutwardLPG a, MSC_User b where a.EmployeeID=b.UserID and RefID='" + role + "'");
                    //Sendmail(email, "Đơn hàng " + txtsct.Text + " của bạn đã được bỏ duyệt.");
                }
            }
        }

        private void Sendmail(string email, string noidung)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("thanhduoc1234@gmail.com");
                mail.To.Add(email);
                mail.Subject = noidung;
                mail.Body = noidung;
                smtpServer.Port = 25;
                smtpServer.Credentials = new NetworkCredential("thanhduoc1234@gmail.com", "nguyen1234");
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                MessageBox.Show("Gửi email thành công đến: " + email);
            }
            catch
            {
                MessageBox.Show("Lổi xảy ra trong quá trình gửi mail");
            }
        }

        private void bbkxnc_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("pxkbienbanvatxacnhan");
            F.getrole(gen.GetString("select RefID from InOutward where INOutwardRefID='" + role + "'"));
            F.getcongty(role);
            F.ShowDialog();
        }

        private void bbtsl_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("pxkbienbanvatsoluong");
            F.getrole(gen.GetString("select RefID from InOutward where INOutwardRefID='" + role + "'"));
            F.getcongty(role);
            F.ShowDialog();
        }

        private void bbksl_Click(object sender, EventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("pxkbienbanvattrongluong");
            F.getrole(gen.GetString("select RefID from InOutward where INOutwardRefID='" + role + "'"));
            F.getcongty(role);
            F.ShowDialog();
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit4.Text != "")
            {
                this.Activate();
                gridControl3.Visible = true;
                DataTable temp = gen.GetTable("danhsachkhachgoiden '" + textEdit4.Text + "'");
                for (int j = 0; j < temp.Rows.Count; j++)
                {
                    gridView7.AddNewRow();
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Mã khách"], temp.Rows[j][0].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Số điện thoại"], temp.Rows[j][1].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Tên khách"], temp.Rows[j][2].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Địa chỉ"], temp.Rows[j][3].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Mặt hàng đã sử dụng"], temp.Rows[j][4].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Đối tượng"], temp.Rows[j][5].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Mã kho"], temp.Rows[j][6].ToString());

                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Tỉnh"], temp.Rows[j][7].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Huyện"], temp.Rows[j][8].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Xã"], temp.Rows[j][9].ToString());
                    gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Địa chỉ con"], temp.Rows[j][10].ToString());

                    gridView7.UpdateCurrentRow();
                }
                if (temp.Rows.Count == 0)
                {
                    string kiemtra = null;
                    for (int j = 0; j < khachle.Rows.Count; j++)
                    {
                        if (textEdit4.Text == khachle.Rows[j][3].ToString())
                        {
                            gridView7.AddNewRow();
                            gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Mã khách"], khachle.Rows[j][0].ToString());
                            gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Số điện thoại"], khachle.Rows[j][2].ToString());
                            gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Tên khách"], khachle.Rows[j][1].ToString());
                            gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Địa chỉ"], khachle.Rows[j][3].ToString());
                            gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Đối tượng"], khachle.Rows[j][5].ToString());
                            gridView7.UpdateCurrentRow();
                            kiemtra = "1";
                            return;
                        }
                    }
                    if (kiemtra == null)
                    {
                        gridView7.AddNewRow();
                        gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Mã khách"], "71003795");
                        gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Số điện thoại"], textEdit4.Text);
                        gridView7.SetRowCellValue(gridView7.FocusedRowHandle, gridView7.Columns["Đối tượng"], "Bán lẻ");
                        gridView7.UpdateCurrentRow();
                    }
                }
            }
        }


        private void gridView7_DoubleClick(object sender, EventArgs e)
        {
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.gettsbt("thhhkdm");
            F.getngaychungtu(gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "Số điện thoại").ToString());
            F.ShowDialog();
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(denct.EditValue.ToString()).Month != DateTime.Parse(ngaychungtu).Month || DateTime.Parse(denct.EditValue.ToString()).Year != DateTime.Parse(ngaychungtu).Year)
                denct.EditValue = ngaychungtu;
        }

        private void txtck_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Double cth, thue, gtgt, tong, ck;
                cth = Double.Parse(txtcth.Text);
                ck = Double.Parse(txtck.Text);
                try
                {
                    thue = Double.Parse(cbthue.Text);
                    ck = ck / (1 + thue / 100);
                    gtgt = Math.Round(((cth - ck) / 100) * thue, 0, MidpointRounding.AwayFromZero);
                }
                catch
                {
                    gtgt = 0;
                }

                tong = cth + gtgt - ck;
                txttthue.EditValue = gtgt;
                txttc.Text = String.Format("{0:n0}", tong);
                if (cth == 0)
                    lbtienchu.Text = "";
            }
            catch { }
        }

        private void tsbtxoa_Click(object sender, EventArgs e)
        {
            sms.sendsms(_PORT, "0918258468", "Xin chao Anh Hung!\n1 binh Total xanh 12kg, gia 350.000 VND\nKM: 1 goi Omo 1kg, 1 chai dau an Tuong An\nNV T.Q Hieu, SDT 0918000000 giao hang trong 20 phut.");
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

        private void cbtinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbhuyen.Properties.Items.Clear();
            DataTable tinh = gen.GetTable("select distinct District from ProvinceFull where Province=N'" + cbtinh.EditValue.ToString() + "' order by District");
            for (int i = 0; i < tinh.Rows.Count; i++)
                cbhuyen.Properties.Items.Add(tinh.Rows[i][0].ToString());
            tinh.Dispose();
            cbhuyen.SelectedIndex = -1;
        }

        private void cbhuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxa.Properties.Items.Clear();
            DataTable tinh = gen.GetTable("select distinct Ward from ProvinceFull where Province=N'" + cbtinh.EditValue.ToString() + "' and District=N'" + cbhuyen.EditValue.ToString() + "' order by Ward");
            for (int i = 0; i < tinh.Rows.Count; i++)
                cbxa.Properties.Items.Add(tinh.Rows[i][0].ToString());
            tinh.Dispose();
            cbxa.SelectedIndex = -1;
        }

        private void txtdcc_EditValueChanged(object sender, EventArgs e)
        {
            txtdc.Text = txtdcc.Text + ", " + cbxa.Text + ", " + cbhuyen.Text + ", " + cbtinh.Text;
        }

        private void cbxa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtdc.Text = txtdcc.Text + ", " + cbxa.Text + ", " + cbhuyen.Text + ", " + cbtinh.Text;
        }

        private void chqt_CheckedChanged(object sender, EventArgs e)
        {
            if (chqt.Checked == true)
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            else
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
        }

    }
}