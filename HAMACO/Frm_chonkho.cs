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
    public partial class Frm_chonkho : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        baocaotonkho bctk = new baocaotonkho();
        baocaotonkhothucte bctktt = new baocaotonkhothucte();
        baocaotonkhovo bctkv = new baocaotonkhovo();
        baocaocongno131 bccn = new baocaocongno131();
        string userid,ngaychungtu,tsbt;

        public delegate void ac();
        public ac myac;

        Form1 F;
        public Form getform(Form1 a)
        {
            F = a;
            return F;
        }

        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public string getngaychungtu(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
        public Frm_chonkho()
        {
            InitializeComponent();
        }

        private void Frm_chonkho_Load(object sender, EventArgs e)
        {
            ledv.Select();
            if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu" || tsbt == "tsbtbctktttt" || tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbccn131" || tsbt == "tsbtbcptcn131" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388")
            {
                groupControl2.Hide();
                this.Height = 200;
            }
            else if (tsbt == "tsbtbctktttdv" || tsbt == "tsbtbctktttttdv" || tsbt == "tsbtbctkvlpgtttdv" || tsbt == "tsbtbccn131tdv" || tsbt == "tsbtbcptcn131tdv" || tsbt == "tsbtbccn1313tdv" || tsbt == "tsbtbccn3313tdv" || tsbt == "tsbtbccn331tdv")
            {
                groupControl2.Hide();
                this.Height = 200;
                this.Text = "Chọn đơn vị";
                groupControl1.Text = "Chọn đơn vị";
            }
           
            else if (tsbt == "tsbtbctktndntdv" || tsbt == "tsbtbctktttndntdv" || tsbt=="tsbtbctkvlpgtndntdv")
            {
                this.Text = "Chọn đơn vị";
                groupControl1.Text = "Chọn đơn vị";
            }
            else if (tsbt == "tsbtbctktndntct" || tsbt == "tsbtbctktttndntct" || tsbt == "tsbtbctktttndnhgtct" || tsbt == "tsbtbctkvlpgtndntct" || tsbt == "tsbtbkhhnd" || tsbt == "tsbtbkhhxd")
            {
                ledv.Hide();
                groupControl1.Height=55;
                groupControl1.Width = 175;
                btok.Location = new Point(10,20);
                btcancel.Location = new Point(90, 20);
                pictureEdit1.Hide();
                this.Height = 240;
                this.Text = "Chọn ngày";
                groupControl2.Location = new Point(12, 12);
                groupControl1.Location = new Point(177, 105);
                groupControl1.Text = "";
            }

            DataTable da = new DataTable();
            DataTable dt = new DataTable();
            if (tsbt == "tsbtbctktsl" ||tsbt == "tsbtbctktslcu"|| tsbt == "tsbtbctktttt" || tsbt == "tsbtbctkthdtndn" || tsbt == "tsbtbctktttndn" || tsbt == "tsbtbctktttndntpxk" || tsbt == "tsbtbctktttndntaidv")
            {
                dt.Columns.Add("Mã kho");
                dt.Columns.Add("Tên kho");
                dt.Columns.Add("Tên đơn vị");
                da = gen.GetTable("select StockCode,StockName,BranchName from Stock a, Branch b where a.BranchID=b.BranchID and LPG='False' and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode" );
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0];
                    dr[1] = da.Rows[i][1];
                    dr[2] = da.Rows[i][2];
                    dt.Rows.Add(dr);
                }
                ledv.Properties.DataSource = dt;
                ledv.Properties.ValueMember = "Mã kho";
                ledv.Properties.DisplayMember = "Mã kho";
            }
            else if (tsbt == "tsbtbccn131" || tsbt == "tsbtbcptcn131" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388")
            {
                bccn.loadStock(ngaychungtu, ledv, tsbt,userid);
            }
            else if (tsbt == "tsbtbccn131tdv" || tsbt == "tsbtbcptcn131tdv" || tsbt == "tsbtbccn331tdv" || tsbt == "tsbtbccn1313tdv" || tsbt == "tsbtbccn3313tdv" )
            {
                bccn.loadBranch(ngaychungtu, ledv, tsbt, userid);
            }
            else if (tsbt == "tsbtbctkvlpgtttdv" || tsbt == "tsbtbctkvlpgtndntdv")
            {
                /*dt.Columns.Add("Mã đơn vị");
                dt.Columns.Add("Tên đơn vị");
                da = gen.GetTable("select distinct Branchcode,BranchName from Stock a, Branch b where a.BranchID=b.BranchID and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by BranchCode");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0];
                    dr[1] = da.Rows[i][1];
                    dt.Rows.Add(dr);
                }
                ledv.Properties.DataSource = dt;
                ledv.Properties.ValueMember = "Mã đơn vị";
                ledv.Properties.DisplayMember = "Mã đơn vị";*/
                bccn.loadBranch(ngaychungtu, ledv, tsbt, userid);
            }

            else if (tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctkvlpgtndn")
            {
                bccn.loadStock(ngaychungtu, ledv, tsbt, userid);
            }
            else
            {
                dt.Columns.Add("Mã đơn vị");
                dt.Columns.Add("Tên đơn vị");
                da = gen.GetTable("select distinct Branchcode,BranchName from Stock a, Branch b where a.BranchID=b.BranchID and a.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by BranchCode");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0];
                    dr[1] = da.Rows[i][1];
                    dt.Rows.Add(dr);
                }
                ledv.Properties.DataSource = dt;
                ledv.Properties.ValueMember = "Mã đơn vị";
                ledv.Properties.DisplayMember = "Mã đơn vị";
            }

            ledv.Properties.PopupWidth = 350;
            ledv.ItemIndex = 0;
            try
            {
                detungay.EditValue = DateTime.Parse(DateTime.Parse(ngaychungtu).Month + "/" + "1" + "/" + DateTime.Parse(ngaychungtu).Year);
                dedenngay.EditValue = DateTime.Parse(ngaychungtu);
            }
            catch { }
        }

        private void btok_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            /* try
            {*/
           string makho = "";
           if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu" || tsbt == "tsbtbctktttt" || tsbt == "tsbtbctkthdtndn" || tsbt == "tsbtbctktttndn" || tsbt == "tsbtbctktttndntpxk" || tsbt == "tsbtbctktttndntaidv" || tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctkvlpgtndn" || tsbt == "tsbtbccn131" || tsbt == "tsbtbcptcn131" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388")
                makho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
           else
               makho = gen.GetString("select * from Branch where BranchCode='" + ledv.EditValue.ToString() + "'");
                //báo cáo tồn kho theo hóa đơn
           if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu" || tsbt == "tsbtbctktttdv")
           {
               F.gettsbt(tsbt);
               F.refreshbaocao("tdv");
               F.getdonvicongno(makho);
               myac();
               this.Close();               
           }
           //báo cáo tồn kho theo hóa đơn từ ngày đến ngày
           else if (tsbt == "tsbtbctkthdtndn" || tsbt == "tsbtbctktndntdv")
           {
               F.gettsbt(tsbt);
               F.refreshbaocao("tdv");
               F.getdonvicongno(makho);
               F.gettungay(detungay.EditValue.ToString());
               F.getdenngay(dedenngay.EditValue.ToString());
               myac();
               this.Close();
              // bctk.loadbctkthdtndn(detungay, dedenngay, makho, tsbt);
           }
           else if (tsbt == "tsbtbctktndntct")
           {
               F.gettsbt(tsbt);
               F.refreshbaocao(tsbt);
               F.getdonvicongno(makho);
               F.gettungay(detungay.EditValue.ToString());
               F.getdenngay(dedenngay.EditValue.ToString());
               myac();
               this.Close();
           }
           //báo cáo tồn kho theo đơn vị
           /*else if (tsbt == "tsbtbctktttdv")
               bctk.loadbctktsl(ngaychungtu, tsbt, makho);*/
           //báo cáo tồn kho theo đơn vị từ ngày đến ngày
           //bctk.loadbctkthdtndn(detungay, dedenngay, makho, tsbt);
           //báo cáo tồn kho theo đơn vị từ ngày đến ngày toàn công ty
           //bctk.loadbctkthdtndn(detungay, dedenngay, makho, tsbt);


          //báo cáo tồn kho thực tế
           else if (tsbt == "tsbtbctktttt" || tsbt == "tsbtbctktttttdv")
           {
               F.gettsbt(tsbt);
               F.refreshbaocao("tdv");
               F.getdonvicongno(makho);
               F.getdate(ngaychungtu);
               myac();
               this.Close();
           }
           //bctktt.loadbctktsl(ngaychungtu, tsbt, makho);
           //báo cáo tồn kho thực tế từ ngày đến ngày
           else if (tsbt == "tsbtbctktttndn" || tsbt == "tsbtbctktttndntpxk" || tsbt == "tsbtbctktttndntaidv")
           {
               bctktt.loadbctkthdtndn(detungay, dedenngay, makho, tsbt);
           }
           //bctktt.loadbctkthdtndn(detungay, dedenngay, makho, tsbt);
           //báo cáo tồn kho thực tế theo đơn vị
           //bctktt.loadbctktsl(ngaychungtu, tsbt, makho);
           //báo cáo tồn kho thực tế theo đơn vị từ ngày đến ngày
           else if (tsbt == "tsbtbctktttndntdv")
               bctktt.loadbctkthdtndn(detungay, dedenngay, makho, tsbt);
           //báo cáo tồn kho thực tế toàn công ty
           else if (tsbt == "tsbtbctktttndntct")
               bctktt.loadbctkthdtndn(detungay, dedenngay, makho, tsbt);
           else if (tsbt == "tsbtbctktttndnhgtct")
               bctktt.loadbctkthdtndn(detungay, dedenngay, makho, tsbt);
           //báo cáo tồn kho vỏ trong tháng
           else if (tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctkvlpgtttdv")
           {
               F.gettsbt(tsbt);
               F.refreshbaocao("tdv");
               F.getdonvicongno(makho);
               myac();
               this.Close();
           }

           //báo cáo tồn kho vỏ từ ngày đến ngày
           else if (tsbt == "tsbtbctkvlpgtndn")
               bctkv.loadbctkthdtndn(detungay, dedenngay, makho, tsbt,userid);
           else if (tsbt == "tsbtbctkvlpgtndntdv")
               bctkv.loadbctkthdtndn(detungay, dedenngay, makho, tsbt,userid);
           else if (tsbt == "tsbtbctkvlpgtndntct")
               bctkv.loadbctkthdtndn(detungay, dedenngay, makho, tsbt,userid);

           else if (tsbt == "tsbtbccn131tdv" || tsbt == "tsbtbcptcn131tdv" || tsbt == "tsbtbccn1313tdv" || tsbt == "tsbtbccn3313tdv" || tsbt == "tsbtbccn331tdv" || tsbt == "tsbtbccn131" || tsbt == "tsbtbcptcn131" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388")
           {
               F.gettsbt(tsbt);
               F.refreshbaocao("tdv");
               F.getdonvicongno(makho);
               myac();
               this.Close();
           }

           else if (tsbt == "tsbtbkhhnd" || tsbt == "tsbtbkhhxd")
           {
               Frm_chonkhotonghoptaikhoan u = new Frm_chonkhotonghoptaikhoan();
               u.getuser(userid);
               u.getngaychungtu(detungay.EditValue.ToString());
               u.getngaycuoi(DateTime.Parse(DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString());
               u.gettsbt(tsbt);
               u.ShowDialog();
           }

                /*else if (tsbt == "tsbtbccn3313tdv")
                {
                    F.getdonvicongno(makho);
                    myac();
                    this.Close();
                }*/

                SplashScreenManager.CloseForm();
            /*}
            catch 
            {
                XtraMessageBox.Show("Vui lòng chọn kho trước khi xem tồn kho.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }
    }
}