using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using HAMACO.Resources;
using DevExpress.Utils;
using DevExpress.XtraNavBar;


namespace HAMACO
{
    public partial class Form1 : XtraForm
    {

        string tsbt, ngaychungtu, userid, branchid,donvicongno,roleid,subsys,tungay,denngay;
        string[,] hoadon = new string[20, 2];        
        Int32 dem = -1;
        DataTable khach = new DataTable();
        DataTable giaban = new DataTable();
        DataTable hang = new DataTable();
        gencon gen = new gencon();
        mscrole mscrole = new mscrole();
        account account = new account();
        cuspro cuspro = new cuspro();
        branch branch = new branch();
        stock stock = new stock();
        distrist distrist = new distrist();
        accountgroup accountgroup = new accountgroup();
        province province = new province();
        nhanvien nhanvien = new nhanvien();
        InventoryItemCategory iic = new InventoryItemCategory();
        ii ii = new ii();
        Hopdong hd = new Hopdong();
        chinhsachnhacungcap csncc = new chinhsachnhacungcap();
        phieuthutm pttm = new phieuthutm();
        phieuthunh ptnh = new phieuthunh();
        phieuchitm pctm = new phieuchitm();
        phieuchinh pcnh = new phieuchinh();
        uynhiemchi unc = new uynhiemchi();
        phieuketoan pkt = new phieuketoan();
        phieuthutmvt pttmvt = new phieuthutmvt();
        phieuthunhvt ptnhvt = new phieuthunhvt();
        phieuchitmvt pctmvt = new phieuchitmvt();
        phieuchinhvt pcnhvt = new phieuchinhvt();
        phieunhapkho pnk = new phieunhapkho();
        phieunhapkhothucte pnktt = new phieunhapkhothucte();
        phieuxuatkho pxk = new phieuxuatkho();
        phieuxuatkhocothue pxkct = new phieuxuatkhocothue();
        dondathang ddh = new dondathang();
        dondathangncc ddhncc = new dondathangncc();
        dondathanglpg ddhlpg = new dondathanglpg();
        phieunhapgas pnkgas = new phieunhapgas();
        phieuxuatgas pxkgas = new phieuxuatgas();
        phieunhapvo pnkvo = new phieunhapvo();
        phieunhapvodk pnkvodk = new phieunhapvodk();
        phieuxuatvo pxkvo = new phieuxuatvo();
        phieuchuyenkhonb cknb = new phieuchuyenkhonb();
        phieuchuyenkhonblpg cknblpg = new phieuchuyenkhonblpg();
        phieuchuyenkhonbvlpg cknbvlpg = new phieuchuyenkhonbvlpg();
        phieuxuathanggb xhgb = new phieuxuathanggb();
        phieuxuathanggblpg xhgblpg = new phieuxuathanggblpg();
        phieuxuathanggbvlpg xhgbvlpg = new phieuxuathanggbvlpg();      
        hdmuahang hdmh = new hdmuahang();
        hdbanhang hdbh = new hdbanhang();
        hoadonxhgb hdxhgb = new hoadonxhgb();
        phieunhapdieuchinh pndc = new phieunhapdieuchinh();
        phieunhapdieuchinhtk pndctk = new phieunhapdieuchinhtk();
        phieuxuatdieuchinh pxdc = new phieuxuatdieuchinh();
        phieunhaphangthua pnht = new phieunhaphangthua();
        phieuxuathangthieu pxht = new phieuxuathangthieu();
        phieunhaphangbantralai pnhbtl = new phieunhaphangbantralai();
        phieuxuathangmuatralai pxhmtl = new phieuxuathangmuatralai();
        phieunhaphangkhuyenmai pnkm = new phieunhaphangkhuyenmai();
        phieuxuathangkhuyenmai pxkm = new phieuxuathangkhuyenmai();
        tonghoptaikhoan thtk = new tonghoptaikhoan();

        baocaonhanh bcn = new baocaonhanh();
        baocaothue thue = new baocaothue();
        baocaocongno131 baocaocn131 = new baocaocongno131();
        tonghopkqkd thkqkd = new tonghopkqkd();

        baocaotonkho bctk = new baocaotonkho();
        baocaotonkhovo bctkv = new baocaotonkhovo();
        baocaotonkhothucte bctktt = new baocaotonkhothucte();

        hdbhkpx hdbhkpx = new hdbhkpx();
        hdmhkpn hdmhkpn = new hdmhkpn();

        phieuthuchi ptctm = new phieuthuchi();

        Frm_login login;
        public Form getform(Frm_login F)
        {
            login = F;
            return login;
        }
        public string getuserid(string a)
        {
            userid = a;
            return userid;
        }
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string gettungay(string a)
        {
            tungay = a;
            return tungay;
        }
        public string getdenngay(string a)
        {
            denngay = a;
            return denngay;
        }

        public string getdonvicongno(string a)
        {
            donvicongno = a;
            return donvicongno;
        }

        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }

        public void refresh(string sub)
        {
            subsys = sub;
            baxem.Enabled = false;
            baadd.Enabled = false;
            baedit.Enabled = false;
            badelete.Enabled = false;
            bapq.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bacvt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            babsbtchondonvi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barin.Enabled = false;
            DataTable dt = new DataTable();
            dt = gen.GetTable("select * from MSC_RolePermissionMaping with (NOLOCK) where RoleID='" + roleid + "' and SubSystemCode='" + sub + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][3].ToString() == "USE")
                    baxem.Enabled = true;
                else if (dt.Rows[i][3].ToString() == "ADD")
                    baadd.Enabled = true;
                else if (dt.Rows[i][3].ToString() == "DELETE")
                    badelete.Enabled = true;
                else if (dt.Rows[i][3].ToString() == "EDIT")
                    baedit.Enabled = true;
                else if (dt.Rows[i][3].ToString() == "PRINT")
                    barin.Enabled = true;
                
            }
            if(tsbt=="tsmsc")
                bapq.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            else if(tsbt == "tstbuser")
                bacvt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            else if (tsbt == "tstbuser")
                bacvt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;            
        }

        public void refreshbaocao(string tsbt)
        {
            baadd.Enabled = false;
            baedit.Enabled = false;
            badelete.Enabled = false;
            barin.Enabled = true;
            baxem.Enabled = true;
            bapq.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bacvt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            babsbtchondonvi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (tsbt == "tdv")
                babsbtchondonvi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        

        public void refresh()
        {
            /*if (Double.Parse(gen.GetString("select AuthenticationType from MSC_User where UserID='" + userid + "'")) > 2)
                babcslmb.Enabled = true;*/

            DataTable dtphanquyen = new DataTable();
            dtphanquyen = gen.GetTable("select DISTINCT(a.SubSystemCode) from MSC_RolePermissionMaping a with (NOLOCK), MSC_SubSystem b with (NOLOCK) where  RoleID='" + roleid + "' and a.SubSystemCode=b.SubSystemCode and (ParentSubSystemCode in (select SubSystemCode from MSC_RolePermissionMaping with (NOLOCK) where RoleID='" + roleid + "') or ParentSubSystemCode='ROOT') and PermissionID='USE'");
            for (int i = 0; i < dtphanquyen.Rows.Count; i++)
            {
                if (dtphanquyen.Rows[i][0].ToString() == "UTImnuBusinessQuickReport")
                {
                    barButtonItem8.Enabled = true;

                    navBarGroup2.Visible = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "UTImnuSystemPostBatch")
                    barButtonItem7.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "UTImnuBusinessFind")
                    barButtonItem4.Enabled = true;

                else if (dtphanquyen.Rows[i][0].ToString() == "FILE")
                    barSubItem1.Enabled = true;

                else if (dtphanquyen.Rows[i][0].ToString() == "FILEmnuFileDatabaseInfo")
                    barSubItem15.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "B01-DN_01")
                    babctktsl.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "B02-DN_01")
                    barbctktttdv.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "B03-DN_01")
                    babctkthtct.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "B09-DN")
                    babctkthdtndn.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "B09-QD48")
                    babctktndntdv.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BalanceSheet_02_48")
                    babctktndntct.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "03_TNDN")
                    navBarItem2.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BalanceSheet_02")
                    navBarItem3.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BalanceSheetReduce")
                    navBarItem8.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BalanceSheet_01")
                    navBarItem9.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "B02_DN_Obligation")
                    navBarItem10.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S38-DN")
                    navBarItem11.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S38-DN-Management")
                    babctkvlpgtt.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S02a-DN_02")
                    babctkvlpgtttdv.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S02a-DN_01")
                    babctkvlpgtttct.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "AccountLedger_Admin")
                    babctkvlpgtndn.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S02b-DN")
                    babctkvlpgtndntdv.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S02c1-DN")
                    babctkvlpgtct.Enabled = true;


                else if (dtphanquyen.Rows[i][0].ToString() == "FILEmnuFileImportData")
                    barSubItem16.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S03a-DN")
                {
                    babccn131.Enabled = true;
                    navBarItem26.Enabled = true;
                    barbchmnkh.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "S03b-DN")
                {
                    babccn131tdv.Enabled = true;
                    navBarItem27.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "S06-DN")
                {
                    babccn131tct.Enabled = true;
                    navBarItem28.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "S31-DN")
                    babcptnqh131.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S32-DN")
                    babcptnqh131tdv.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S33-DN")
                {
                    babcptcn131tct.Enabled = true;
                    barbcthmb.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "S34-DN")
                {
                    babccn331.Enabled = true;
                    navBarItem32.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "GLCorrespondingAmountTableDetail")
                {
                    babccn331tdv.Enabled = true;
                    navBarItem31.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "GLOriginVoucherSummary")
                {
                    babccn331tct.Enabled = true;
                    navBarItem52.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "AccountMovementSumarry")
                {
                    babccn1313.Enabled = true;
                    navBarItem30.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "AccountLedger")
                {
                    babccn1313tdv.Enabled = true;
                    navBarItem42.Enabled = true;
                    barbccnv.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "DetailAccountLedger")
                {
                    babccn1313tct.Enabled = true;
                    navBarItem25.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "Account007_Ledger")
                {
                    babccn3313.Enabled = true;
                    navBarItem38.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "S01-DN")
                {
                    babccn3313tdv.Enabled = true;
                    navBarItem37.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "S01-DN-QD48")
                {
                    babccn3313tct.Enabled = true;
                    navBarItem36.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "GroupVoucher")
                    babccn141.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "GroupVoucherDebitAccount")
                {
                    babccn141tct.Enabled = true;
                    navBarItem35.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "BUPlanByQuarter")
                {
                    //babccn31188.Enabled = true;
                    navBarItem33.Enabled = true;
                    barButtonItem39.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "BUAllowcationByMounth")
                {
                    babccn3388.Enabled = true;
                    navBarItem41.Enabled = true;
                    barButtonItem43.Enabled = true;
                    navBarItem53.Enabled = true;
                    barvnhk.Enabled = true;
                    barvdhk.Enabled = true;
                    navBarItem65.Enabled = true;
                    navBarItem66.Enabled = true;
                }

                else if (dtphanquyen.Rows[i][0].ToString() == "FILEmnuFileReport")
                { /*barSubItem18.Enabled = true;*/}
                else if (dtphanquyen.Rows[i][0].ToString() == "1")
                    barButtonItem26.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "2")
                    barButtonItem27.Enabled = true;

                else if (dtphanquyen.Rows[i][0].ToString() == "FILEmnuExportData")
                    barSubItem17.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "ListVourcherByBudgetItem")
                {
                    bathtksc.Enabled = true;
                    barButtonItem44.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "SummaryByAccountAndBudgetItem")
                {
                    bathtkskt.Enabled = true;
                    barButtonItem45.Enabled = true;
                    barcttk.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "SummaryByBudgetItemAndAccount")
                {
                    bathtktq.Enabled = true;
                    barbktdnh.Enabled = true;
                    barbctqtdvmain.Enabled = true;
                }

                else if (dtphanquyen.Rows[i][0].ToString() == "FILEmnuImportData")
                    babctcth.Enabled = true;



                else if (dtphanquyen.Rows[i][0].ToString() == "TA")
                    barSubItem19.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "TA153mnuBusiness")
                    barButtonItem28.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "TA153mnuBusinessDeletedInvoice")
                    barButtonItem29.Enabled = true;

                else if (dtphanquyen.Rows[i][0].ToString() == "FA")
                    barSubItem20.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "FAmnuBusinessFAAdjustmentList")
                {
                    babkthphi.Enabled = true;
                    babkthptn.Enabled = true;
                    babkthtncp.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "FAmnuBusinessFADecrementList")
                {
                    babkthptk.Enabled = true;
                    barbkcpt.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "FAmnuBusinessFADepreationList")
                    bathpnxtt.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "FAmnuBusinessFAIncrementList")
                    bathpnxdc.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "FAmnuBusinessFATransferList")
                    bathkqkd.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "FAmnuBusinessPUInvoiceFixedAssetList")
                    badtvcp.Enabled = true;


                else if (dtphanquyen.Rows[i][0].ToString() == "OPOmnuBusinessOPOpenningEntry")
                {
                    barbctctt.Enabled = true;
                    barkqkdth.Enabled = true;
                }


                else if (dtphanquyen.Rows[i][0].ToString() == "DI")
                    barSubItem2.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DIpopDictionaryAccount")
                    barSubItem7.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryAccount")
                    bahttk.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryAccountCategory")
                    bantk.Enabled = true;



                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryDepartment")
                    bapb.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryBranch")
                    badv.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "CT")
                {
                    barhdkh.Enabled = true;
                    barplbl.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryAccountingObjectGroup")
                    barButtonItem6.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryAccountingObject")
                    bakhncc.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryEmployee")
                    banv.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DIpopDictionaryPayroll")
                    barButtonItem9.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryStock")
                {
                    bakho.Enabled = true;
                    bartgp.Enabled = true;
                    barckkh.Enabled = true;
                    barctkqkd.Enabled = true;
                    barctlv.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryInventoryItemCategory")
                    balvthhccdd.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryInventoryItem")
                    bavthh.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryToolItem")
                    baccdd.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DIpopDictionaryShareHolder")
                    barButtonItem14.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryFixedAssetCategory")
                    barButtonItem15.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryFixedAsset")
                    barButtonItem16.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryExpense")
                    barButtonItem17.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryJob")
                    barButtonItem18.Enabled = true;

                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryBank")
                    barhd.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryBankInfo")
                    barButtonItem20.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryCreditCard")
                    barButtonItem21.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryInventoryItemCategoryTax")
                    barButtonItem22.Enabled = true;

                else if (dtphanquyen.Rows[i][0].ToString() == "DIpopDictionaryOther")
                    barSubItem5.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictinaryPaymentTerm")
                    battp.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryShippingMethod")
                    baqh.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DImnuDictionaryShareType")
                    battt.Enabled = true;


                else if (dtphanquyen.Rows[i][0].ToString() == "Business")
                    barSubItem3.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "IN")
                    barSubItem10.Enabled = true;

                else if (dtphanquyen.Rows[i][0].ToString() == "INmnuBusinessINInwardList")
                    bapnk.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "INmnuBusinessINOutwardList")
                {
                    bapxk.Enabled = true;
                    if (Double.Parse(gen.GetString("select Top 1 AuthenticationType from MSC_User with (NOLOCK) where UserID='" + userid + "'")) > 0)
                        bacsncc.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "INmnuBusinessAssemblyAndUnBuild")
                    bapnkgas.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "INmnuBusinessINTransferList")
                    bapxkgas.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "INmnuBusinessINAdjustmentList")
                {
                    bapnkvo.Enabled = true;
                    bapnkvtddh.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "INmnuBusinessINUpdateOutwardPrice")
                    bapxkvo.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BA")
                    backnb.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BAmnuBAOnlineBanking")
                    backnblpg.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BAmnuBusinessBACreditCardList")
                    backnbvlpg.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BAmnuBusinessBADepositList")
                    baxhgb.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BAmnuBusinessBAInternalTransfer")
                    baxhgblpg.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BAmnuBusinessBAReconciliation")
                    baxhgbvlpg.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "3")
                    bapncknb.Enabled = true;

                else if (dtphanquyen.Rows[i][0].ToString() == "S07a-DN")
                    bapncknblpg.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S07-DN")
                    bapncknbvlpg.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S03a1-DN")
                    bapnhgb.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "S03a2-DN")
                    bapnhgblpg.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "DetailMoneyInFundByExchange")
                    bapnhgbvlpg.Enabled = true;


                else if (dtphanquyen.Rows[i][0].ToString() == "CA")
                    barSubItem6.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "CAmnuBusinessCAReceiptList")
                    bapttm.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "CAmnuBusinessCAPaymentList")
                    bapctm.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BAmnuBusinessBATransferList")
                    bapttmvt.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BAmnuBusinessBAWithdrawList")
                    bapctmvt.Enabled = true;





                else if (dtphanquyen.Rows[i][0].ToString() == "BU")
                    barSubItem9.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BUmnuBUExpense")
                    baptnh.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "BUmnuBUAllocation")
                {
                    bapcnh.Enabled = true;
                    baunc.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "BUmnuBUUsingBudget")
                    baptnhvt.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "PUmnuBusinessPUPurchaseOrder")
                    bapcnhvt.Enabled = true;



                else if (dtphanquyen.Rows[i][0].ToString() == "PU")
                    barSubItem12.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "PUmnuBusinessPUReceiptItemList")
                    bahdmh.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "PUmnuBusinessPUInvoiceWithoutStockList")
                    bahdbh.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "PUmnuBusinessPUReceiptInvoiceList")
                    barButtonItem10.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SAmnuBusinessSAReturnAndDiscount")
                    barButtonItem33.Enabled = true;



                else if (dtphanquyen.Rows[i][0].ToString() == "SA")
                    barSubItem11.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "PUmnuBusinessPUEnterInvoiceList")
                    bapkt.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "PUmnuBusinessPUReturnAndDiscount")
                    bapndc.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "PUmnuBusinessPUVendorPaymentCashOnHandList")
                    bapxdc.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SAmnuSalePolicy")
                    bapnht.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SAmnuBusinessSASaleQuote")
                {
                    bapxht.Enabled = true;
                    bapxtdnb.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "SAmnuBusinessSASaleOrder")
                    bapnhkm.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SAmnuBusinessSAInvoiceWithoutCashList")
                    bapxhkm.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SAmnuBusinessSAInvoiceWithCashList")
                {
                    bapnhbtl.Enabled = true;
                    barpxhmtl.Enabled = true;
                }


                else if (dtphanquyen.Rows[i][0].ToString() == "SYS")
                    barSubItem4.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SYSmnuSystemChangeSystemDate")
                {
                    banctmn.Enabled = true;
                    banct.Enabled = true;
                }
                else if (dtphanquyen.Rows[i][0].ToString() == "SYSAnalysisFinance")
                    barButtonItem37.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SYSmnuSystemUser")
                    baqlnd.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SYSmnuSystemRoleAndRule")
                    bavtqh.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SYSmnuSystemAuditingLog")
                    barButtonItem40.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SYSTabSystemOptionCompanyInfo")
                    barButtonItem30.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SYSTabSystemOptionHumanResource")
                    barButtonItem32.Enabled = true;
                else if (dtphanquyen.Rows[i][0].ToString() == "SYSmnuAddOnManager")
                    barButtonItem42.Enabled = true;
            }
        }
       
        public void getnct()
        {
            banctbot.Caption = "Ngày chứng từ: " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            view.Columns.Clear();
            view.ViewCaption = "     Hệ thống";
            while (view.RowCount > 0)
            {
                view.DeleteRow(0);
            }
            bapq.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bacvt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            babsbtchondonvi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            tsbt = null;
            /*if (tsbt == "tsbtpttm")
                refreshpttm();
            else if (tsbt == "tsbtptnh")
                refreshptnh();
            else if (tsbt == "tsbtpctm")
                refreshpctm();
            else if (tsbt == "tsbtpcnh")
                refreshpcnh();
            else if (tsbt == "tsbtpkt")
                refreshpkt();
            else if (tsbt == "tsbtpttmvt")
                refreshpttmvt();
            else if (tsbt == "tsbtptnhvt")
                refreshptnhvt();
            else if (tsbt == "tsbtpctmvt")
                refreshpctmvt();
            else if (tsbt == "tsbtpnk")
                refreshpnk();
            else if (tsbt == "tsbthdmh")
                refreshhdmh();
            else if (tsbt == "tsbthdbh")
                refreshhdbh();*/
        }

        public void refreshbaocaonhanh()
        {
            view.OptionsView.ColumnAutoWidth = true;
            if (tsbt == "tsbtbcslbhtt")
            {
                view.ViewCaption = "   Đơn vị " + gen.GetString("select BranchCode+' - '+BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'") + " - Báo cáo sản lượng năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
                bcn.loadsanluongtheothang(lvpq, view, donvicongno, ngaychungtu, tsbt);
            }
            else if (tsbt == "tsbtbcdtlntt" || tsbt == "tsbtbcdtlnct")
            {
                view.ViewCaption = "   Đơn vị " + gen.GetString("select BranchCode+' - '+BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'") + " - Báo cáo doanh thu lợi nhuận năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
                bcn.loaddoanhthutheothang(lvpq, view, donvicongno, ngaychungtu, tsbt);
            }
            else if (tsbt == "tsbtbcslbhtq")
            {
                view.ViewCaption = "   Đơn vị " + gen.GetString("select BranchCode+' - '+BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'") + " - Báo cáo sản lượng năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
                bcn.loadsanluongtheoquy(lvpq, view, donvicongno, ngaychungtu, tsbt);
            }
            else if (tsbt == "tsbtbcdtlntq")
            {
                view.ViewCaption = "   Đơn vị " + gen.GetString("select BranchCode+' - '+BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'") + " - Báo cáo doanh thu lợi nhuận năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
                bcn.loaddoanhthutheoquy(lvpq, view, donvicongno, ngaychungtu, tsbt);
            }
            else if (tsbt == "tsbtbcdtsl")
            {
                view.ViewCaption = "   Đơn vị " + gen.GetString("select BranchCode+' - '+BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'") + " - Báo cáo doanh thu khách hàng từ ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                bcn.loaddoanhthusanluong(lvpq, view, donvicongno, tungay, denngay, tsbt);
            }
            else if (tsbt == "tsbtdskhm")
            {
                view.ViewCaption = "   Đơn vị " + gen.GetString("select BranchCode+' - '+BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'") + " - Danh sách khách hàng mới từ ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                bcn.loaddoanhthusanluong(lvpq, view, donvicongno, tungay, denngay, tsbt);
            }
            else if (tsbt == "tsbtdskhkpsdt")
            {
                view.ViewCaption = "   Đơn vị " + gen.GetString("select BranchCode+' - '+BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'") + " - Danh sách khách hàng không phát sinh doanh thu từ ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                bcn.loaddoanhthusanluong(lvpq, view, donvicongno, tungay, denngay, tsbt);
            }
            else if (tsbt == "tsbtbcthlthh")
            {
                view.ViewCaption = "   Kho " + gen.GetString("select StockCode+' - '+StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'") + " - Báo cáo tình hình lưu trữ tồn kho tháng " + String.Format("{0:MM}", DateTime.Parse(tungay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
                bcn.loadluutrutonkho(lvpq, view, donvicongno, denngay, tsbt);
            }
            view.BestFitColumns();
        }

        public void refreshmsc()
        {
            view.OptionsView.ColumnAutoWidth = true;
            mscrole.loadrole(lvpq, view, "Select * from MSC_Role with (NOLOCK)");
        }
        public void refreshcuspro()
        {
            cuspro.loadcuspro(lvpq, view, "select * from AccountingObject with (NOLOCK) where IsVendor='True' or IsCustomer='True' order by AccountingObjectCode");
        }
        public void refreshuser()
        {
            view.OptionsView.ColumnAutoWidth = true;
            mscrole.loaduser(lvpq, view);
        }
        public void refreshaccountgroup()
        {
            view.OptionsView.ColumnAutoWidth = true;
            accountgroup.loadgroupaccount(lvpq, view);
        }
        public void refreshaccount()
        {
            view.OptionsView.ColumnAutoWidth = true;
            account.loadaccount(lvpq, view);
        }
        public void refreshbranch()
        {
            branch.loadbranch(lvpq, view);
            view.OptionsView.ColumnAutoWidth = true;
        }
        public void refreshstock()
        {
            stock.loadstock(lvpq, view);
            view.OptionsView.ColumnAutoWidth = true;
        }
        public void refreshprovince()
        {
            view.OptionsView.ColumnAutoWidth = true;
            province.loadprovince(lvpq, view);
        }
        public void refreshdistrist()
        {
            view.OptionsView.ColumnAutoWidth = true;
            distrist.loaddistrist(lvpq, view);
        }
        public void refreshnhanvien()
        {
            view.OptionsView.ColumnAutoWidth = true;
            nhanvien.loadnv(lvpq, view, "select * from AccountingObject with (NOLOCK) where IsEmployee='True' order by BranchID, AccountingObjectCode");
        }
        public void refreshiic()
        {
            view.OptionsView.ColumnAutoWidth = true;
            //iic.loadiic(lvpq, view);
        }
        public void refreshii()
        {
            view.OptionsView.ColumnAutoWidth = true;
            ii.loadii(lvpq, view, "select InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,InventoryCategoryName,a.Inactive from InventoryItem a with (NOLOCK), InventoryItemCategory b with (NOLOCK) where a.InventoryCategoryID=b.InventoryCategoryID order by InventoryItemCode");
        }
        public void refreshpttm()  //phieu thu tien mat
        {
            view.OptionsView.ColumnAutoWidth = true;
            pttm.loadpttm(lvpq, view, "select RefID,RefNo,a.CustomField5,RefDate,PostedDate,AccountingObjectName,Contactname,JournalMemo,TotalAmount,StockCode,a.EditVersion from CAReceipt a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "')  order by RefNo");
        }

        public void refreshptctm() //phieu thu chi tien mat
        {
            ptctm.loadpttm(lvpq, view, "select * from CAReceiptTT with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "')  order by RefNo");
            view.OptionsView.ColumnAutoWidth = true;
        }

        public void refreshptnh() // phieu thu ngan hang
        {
            view.OptionsView.ColumnAutoWidth = true;
            ptnh.loadptnh(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,Contactname,JournalMemo,TotalAmount,StockCode from BADeposit a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpctm() // phieu chi tien mat
        {
            view.OptionsView.ColumnAutoWidth = true;
            pctm.loadpctm(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,Contactname,JournalMemo,TotalAmount,StockCode,a.EditVersion from CAPayment a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpcnh() // phieu chi ngan hang
        {
            view.OptionsView.ColumnAutoWidth = true;
            pcnh.loadpcnh(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,Contactname,JournalMemo,TotalAmount,StockCode from BATransfer a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshunc()
        {
            view.OptionsView.ColumnAutoWidth = true;
            unc.loadunc(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,Contactname,JournalMemo,TotalAmount,StockCode,a.AccountingObjectBankName,a.DocumentIncluded from BAAccreditative a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpkt() // PHIEU KE TOAN
        {
            view.OptionsView.ColumnAutoWidth = true;
            pkt.loadpkt(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,Contactname,JournalMemo,TotalAmount,StockCode,FullName from GLVoucher a with (NOLOCK), Stock b with (NOLOCK),MSC_User c with (NOLOCK) where a.StockID=b.StockID and a.UserID=c.UserID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpttmvt()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pttmvt.loadpttmvt(lvpq, view, "select * from SUCAReceipt with (NOLOCK)  where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'  order by RefNo");
        }
        public void refreshptnhvt()
        {
            view.OptionsView.ColumnAutoWidth = true;
            ptnhvt.loadptnhvt(lvpq, view, "select * from SUBADeposit with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' order by RefNo");
        }
        public void refreshpctmvt()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pctmvt.loadpctmvt(lvpq, view, "select * from SUCAPayment with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' order by RefNo");
        }
        public void refreshpcnhvt()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pcnhvt.loadpcnhvt(lvpq, view, "select * from SUBATransfer with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' order by RefNo");
        }
        public void refreshpnk()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnk.loadpnk(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,JournalMemo,IsExport,StockCode from INInward a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }

        public void refreshpnktt()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnktt.loadpnk(lvpq, view, "select * from INInwardTT with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') and RefType<>'3' order by RefNo");
        }

        public void refreshpxkhgkh()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnktt.loadpnk(lvpq, view, "select * from INInwardTT with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') and RefType='3' order by RefNo");
        }

        public void refreshpdctk()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pndctk.loadpndc(lvpq, view, "select * from INAdjustmentTT with (NOLOCK)  where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo");
        }

        public void refreshpnkgas()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnkgas.loadpnk(lvpq, view, "select * from INInward with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and refSUID is not Null and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpxk()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pxk.loadpxk(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,a.AccountingObjectName,JournalMemo,IsExport,Cancel,StockCode,Tax,TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)),ShippingNo,AccountingObjectCode,UserCheck,RefOrder,INOutwardRefID,FullName,a.EmployeeID,TotalFreightAmount from INOutward a with (NOLOCK), Stock b with (NOLOCK), AccountingObject c with (NOLOCK), MSC_User d with (NOLOCK) where a.EmployeeID=d.Userid and a.AccountingObjectID=c.AccountingObjectID and a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpxkct()
        {
            view.OptionsView.ColumnAutoWidth = true;
            //pxk.loadpxk(lvpq, view, "select a.*,b.CreditAmount,b.CreditAmoutAdd,b.Note,b.NoteMain from (select a.*,b.AccountingObjectCode as nhanvien,b.AccountingObjectName as hoten from (select RefID,RefNo,RefDate,PostedDate,a.AccountingObjectName,JournalMemo,IsExport,Cancel,StockCode,Tax,TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)) as tongtien,ShippingNo,c.AccountingObjectCode,UserCheck,RefOrder,INOutwardRefID,FullName,a.EmployeeID,TotalFreightAmount,EmployeeIDSA from INOutward a, Stock b, AccountingObject c, MSC_User d where a.EmployeeID=d.Userid and a.AccountingObjectID=c.AccountingObjectID and a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') and Cancel='True') a left join AccountingObject b on a.EmployeeIDSA=b.AccountingObjectID) a left join  (select RefNo,CreditAmount,Note,NoteMain,CreditAmoutAdd from OpeningAccountEntry131TT) b on a.RefNo=b.RefNo order by RefNo", thanhtien);
            pxk.loadpxk(lvpq, view, "select a.*,b.AccountingObjectCode as nhanvien,b.AccountingObjectName as hoten from (select RefID,RefNo,RefDate,PostedDate,a.AccountingObjectName,JournalMemo,IsExport,Cancel,StockCode,Tax,TotalAmountOC+TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)) as tongtien,ShippingNo,c.AccountingObjectCode,UserCheck,RefOrder,INOutwardRefID,FullName,a.EmployeeID,TotalFreightAmount,EmployeeIDSA from INOutward a with (NOLOCK), Stock b with (NOLOCK), AccountingObject c with (NOLOCK), MSC_User d with (NOLOCK) where a.EmployeeID=d.Userid and a.AccountingObjectID=c.AccountingObjectID and a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') and Cancel='True') a left join AccountingObject b with (NOLOCK) on a.EmployeeIDSA=b.AccountingObjectID order by RefNo");
        }
        
        public void refreshddhlpg()
        {
            ddhlpg.loadddh(lvpq, view, ngaychungtu, userid, tsbt);
        }
        public void refreshddhlpgcapnhap(string phuongtien, string taixe, string giaonhan)
        {
            for (int i = 0; i < Double.Parse(view.Columns[1].SummaryText.Replace("Số dòng:   ", "").Replace(".", "")); i++)
                if (view.GetRowCellValue(i, "Chọn").ToString() == "True")
                {
                    gen.ExcuteNonquery("update INOutwardLPG set CustomField2=N'" + giaonhan + "',ShippingNo=N'" + taixe + "',CustomField6=N'" + phuongtien + "' where RefID='" + view.GetRowCellValue(i, "ID").ToString() + "'");
                    gen.ExcuteNonquery("update INOutward set Taixe=N'" + taixe + "',ShippingNo=N'" + phuongtien + "',Shipper=N'" + giaonhan + "' where INOutwardRefID='" + view.GetRowCellValue(i, "ID").ToString() + "'");
                }
            refreshddhlpg();
        }

        public void refreshddh()
        {
            ddh.loadddh(lvpq, view, ngaychungtu, userid, tsbt);
        }
        public void refreshddhcl()
        {
            view.OptionsView.ColumnAutoWidth = true;
            ddh.loadddhcl(lvpq, view, ngaychungtu, userid, tsbt);
        }
        public void refreshddhncc()
        {
            view.OptionsView.ColumnAutoWidth = true;
            ddhncc.loadddh(lvpq, view, ngaychungtu, userid);
        }
        public void refreshpxkgas()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pxkgas.loadpxk(lvpq, view, "select * from INOutward with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and refSUID is not Null and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpnkvo()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnkvo.loadpnk(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,JournalMemo,TotalAmount,InwardType,StockCode from INInwardSU a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpnkvotddh()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnkvodk.loadpnk(lvpq, view, userid, ngaychungtu);
        }
        public void refreshpxkvo()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pxkvo.loadpxk(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,JournalMemo,TotalAmount,InwardType,StockCode from INOutwardSU a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshcknb()
        {
            view.OptionsView.ColumnAutoWidth = true;
            cknb.loadpck(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,c.StockCode,c.StockName,RefNoIn,IsExport,b.StockCode,TotalAmount,CostAmount,JournalMemo,ShippingNo,PostVersion from INTransfer a with (NOLOCK), Stock b with (NOLOCK),Stock c with (NOLOCK) where a.OutwardStockID=b.StockID and a.InwardStockID=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpncknb()
        {
            view.OptionsView.ColumnAutoWidth = true;
            cknb.loadpnck(lvpq, view, "select RefID,RefNoIn,RefDate,PostedDate,b.StockCode,b.StockName,case when RefSUID=NULL then RefNo else (select RefNo from DDH where RefID=RefSUID) end,IsExport,c.StockCode,TotalAmount,CostAmount,JournalMemo,ShippingNo,PostVersion from INTransfer a with (NOLOCK), Stock b with (NOLOCK),Stock c with (NOLOCK) where a.OutwardStockID=b.StockID and a.InwardStockID=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNoIn");
        }
        public void refreshcknblpg()
        {
            view.OptionsView.ColumnAutoWidth = true;
            cknblpg.loadpck(lvpq, view, "select * from INTransfer with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and RefSUID is not Null and OutwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpncknblpg()
        {
            view.OptionsView.ColumnAutoWidth = true;
            cknblpg.loadpnck(lvpq, view, "select * from INTransfer with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and RefSUID is not Null and InwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNoIn");
        }
        public void refreshcknbvlpg()
        {
            view.OptionsView.ColumnAutoWidth = true;
            cknbvlpg.loadpck(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,c.StockCode,c.StockName,RefNoIn,JournalMemo,TotalAmount,b.StockCode,PostVersion from INTransferSU a with (NOLOCK),Stock b with (NOLOCK),Stock c with (NOLOCK) where a.OutwardStockID=b.StockID and a.InwardStockID=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpncknbvlpg()
        {
            view.OptionsView.ColumnAutoWidth = true;
            cknbvlpg.loadpnck(lvpq, view, "select RefID,RefNoIn,RefDate,PostedDate,b.StockCode,b.StockName,RefNo,JournalMemo,TotalAmount,c.StockCode,PostVersion from INTransferSU a with (NOLOCK),Stock b with (NOLOCK),Stock c with (NOLOCK) where a.OutwardStockID=b.StockID and a.InwardStockID=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNoIn");
        }
        public void refreshxhgb()
        {
            view.OptionsView.ColumnAutoWidth = true;
            xhgb.loadpck(lvpq, view, "select RefID,RefNo,RefDate,PostedDate,c.StockCode,c.StockName,RefNoIn,IsExport,b.StockCode,TotalAmount,CostAmount,JournalMemo,ShippingNo,PostVersion from INTransferBranch a with (NOLOCK), Stock b with (NOLOCK),Stock c with (NOLOCK) where a.OutwardStockID=b.StockID and a.InwardStockID=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpnhgb()
        {
            view.OptionsView.ColumnAutoWidth = true;
            xhgb.loadpnck(lvpq, view, "select RefID,RefNoIn,RefDate,PostedDate,b.StockCode,b.StockName,RefNo,IsExport,c.StockCode,TotalAmount,CostAmount,JournalMemo,ShippingNo,PostVersion from INTransferBranch a with (NOLOCK), Stock b with (NOLOCK),Stock c with (NOLOCK) where a.OutwardStockID=b.StockID and a.InwardStockID=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNoIn");
        }
        public void refreshxhgblpg()
        {
            view.OptionsView.ColumnAutoWidth = true;
            xhgblpg.loadpck(lvpq, view, "select * from INTransferBranch with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and RefSUID is not Null and OutwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpnhgblpg()
        {
            view.OptionsView.ColumnAutoWidth = true;
            xhgblpg.loadpnck(lvpq, view, "select * from INTransferBranch with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and RefSUID is not Null and InwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNoIn");
        }
        public void refreshxhgbvlpg()
        {
            view.OptionsView.ColumnAutoWidth = true;
            xhgbvlpg.loadpck(lvpq, view, "select * from INTransferBranchSU with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpnhgbvlpg()
        {
            view.OptionsView.ColumnAutoWidth = true;
            xhgbvlpg.loadpnck(lvpq, view, "select * from INTransferBranchSU with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNoIn");
        }
        public void refreshhdmh()
        {
            hdmh.loadhdmh(lvpq, view, "select RefID,RefNo,AccountingObjectName,PURefDate,CABARefDate,DueDateTime,InvNo,TotalVATAmount,Tax,TotalAmount,TotalFreightAmount,IsExport,StockCode,PUJournalMemo,InwardRefNo,CABAAccountingObjectBankAccount from PUInvoice a with (NOLOCK), Stock b with (NOLOCK) where a.BranchID=b.StockID and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.BranchID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
            view.OptionsView.ColumnAutoWidth = true;
        }
        public void refreshhdbh()
        {
            hdbh.loadhdbh(lvpq, view, "select RefID,RefNo,a.AccountingObjectName,PURefDate,CABARefDate,DueDateTime,InvNo,TotalVATAmount,Tax,TotalAmount,TotalFreightAmount,TotalCost,TotalDiscountAmount,IsExport,StockCode,TotalDiscountAmount,c.AccountingObjectCode,PUContactName,PUPostedDate,DocumentIncluded from SSInvoice a with (NOLOCK), Stock b with (NOLOCK), AccountingObject c with (NOLOCK) where a.AccountingObjectID=c.AccountingObjectID and a.BranchID=b.StockID and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.BranchID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
            view.OptionsView.ColumnAutoWidth = true;
            //view.BestFitColumns();

        }
        public void refreshhdbhkpx()
        {
            view.OptionsView.ColumnAutoWidth = true;
            hdbh.loadhdbh(lvpq, view, "select RefID,RefNo,c.AccountingObjectName,PURefDate,CABARefDate,DueDateTime,InvNo,TotalVATAmount,Tax,TotalAmount,TotalFreightAmount,TotalCost,TotalDiscountAmount,IsExport,StockCode,TotalDiscountAmount,c.AccountingObjectCode,PUContactName,PUPostedDate from SSInvoice a with (NOLOCK), Stock b with (NOLOCK), AccountingObject c with (NOLOCK) where a.AccountingObjectID=c.AccountingObjectID and a.BranchID=b.StockID and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.BranchID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') and IsExport='True' order by RefNo");
            //view.BestFitColumns();        
        }
        public void refreshhdmhkpn()
        {
            view.OptionsView.ColumnAutoWidth = true;
            hdmh.loadhdmh(lvpq, view, "select RefID,RefNo,AccountingObjectName,PURefDate,CABARefDate,DueDateTime,InvNo,TotalVATAmount,Tax,TotalAmount,TotalFreightAmount,IsExport,StockCode,PUJournalMemo,InwardRefNo,CABAAccountingObjectBankAccount  from PUInvoice a with (NOLOCK), Stock b with (NOLOCK) where a.BranchID=b.StockID and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.BranchID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') and Cancel='True' order by RefNo");
            //view.BestFitColumns();        
        }
        public void refreshhdxhgb()
        {
            view.OptionsView.ColumnAutoWidth = true;
            hdxhgb.loadhdbh(lvpq, view, "select * from SSInvoiceBranch with (NOLOCK) where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID in (select BranchID from MSC_UserJoinStock a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and UserID='" + userid + "') order by RefNo");
            view.BestFitColumns();        
        }
        public void refreshpndc()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pndc.loadpndc(lvpq, view, "select * from INAdjustment with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpxdc()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pndc.loadpndc(lvpq, view, "select * from OUTAdjustment with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpnht()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnht.loadpnht(lvpq, view, "select * from INSurplus with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpxht()
        {
            pxht.loadpxht(lvpq, view, "select * from OUTdeficit with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and (Cancel='False' or Cancel is null) and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpxhtnb()
        {
            pxht.loadpxht(lvpq, view, "select * from OUTdeficit with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and Cancel='True' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpnhbtl()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnhbtl.loadpnhbtl(lvpq, view, "select * from INReInward with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }

        public void refreshpxhmtl()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnhbtl.loadpnhbtl(lvpq, view, "select * from INReOutward with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }

        public void refreshpnhkm()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pnkm.loadpnht(lvpq, view, "select * from INInwardFree with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }
        public void refreshpxhkm()
        {
            view.OptionsView.ColumnAutoWidth = true;
            pxkm.loadpxht(lvpq, view, "select * from INOutwardFree with (NOLOCK) where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by RefNo");
        }

        public void refreshckkh()
        {
            view.OptionsView.ColumnAutoWidth = true;
            thkqkd.loadkhauhao(lvpq, view, "select DepreciationID,DepreciationCode,DepreciationName,StartTime,DepreciationTime,EndTime,OriginalPrice,Price,ExitsPrice,ExitsTime,Tax,TaxPrice,StockCode+' - '+StockName,a.StockID from Depreciation a with (NOLOCK), Stock b with (NOLOCK)  where a.StockID=b.StockID and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by DepreciationCode");
        }

        public void refreshtgp()
        {
            view.OptionsView.ColumnAutoWidth = true;
            thkqkd.loadtanggiam(lvpq, view, "select DescascID,DescascCode,DescascName,PostDate,Amount,JournalMemo,StockCode,NoDescasc from Descasc a with (NOLOCK), Stock b with (NOLOCK) where a.StockID=b.StockID and Month(PostDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PostDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and a.StockID in (select StockID from MSC_UserJoinStock with (NOLOCK) where UserID='" + userid + "') order by NoDescasc,DescascCode");
        }

        public void refreshcsncc()
        {            
            view.OptionsView.ColumnAutoWidth = true;
            csncc.loadchinhsach(lvpq, view, ngaychungtu);
        }

        public void refreshhdkh()
        {
            view.OptionsView.ColumnAutoWidth = true;
            if (tsbt == "tsbthdkh")
                hd.loadhd(lvpq, view, userid, ngaychungtu);
            else if (tsbt == "tsbtplbl")
                hd.loadplbl(lvpq, view, userid, ngaychungtu);
        }

        public void refreshbccnhmn()
        {
            baocaocn131.loadbccntndnhmn(denngay, tsbt, lvpq, view, userid); //load bao cao moi --> viet lai
            refreshbaocao(tsbt);                   
        }

        public void refreshbccn131()
        {
            view.OptionsView.ColumnAutoWidth = true;
            if (tsbt == "tsbtbccn131")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - 131 - Thanh toán với người mua" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn131tdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - 131 - Thanh toán với người mua" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn131tct")
            {
                view.ViewCaption = "   TK - 131 - Thanh toán với người mua" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn331")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - 331 - Thanh toán với người bán" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn331tdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - 331 - Thanh toán với người bán" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn331tct")
            {
                view.ViewCaption = "   TK - 331 - Thanh toán với người bán" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn1313")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - TK - 1313 - Thanh toán với người mua vỏ bình" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn1313tdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - TK - 1313 - Thanh toán với người mua vỏ bình" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn1313tct")
            {
                view.ViewCaption = "   TK - 1313 - Thanh toán với người mua vỏ bình" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn3313")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - 3313 - Thanh toán với người bán vỏ bình" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn3313tdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - 3313 - Thanh toán với người bán vỏ bình" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn3313tct")
            {
                view.ViewCaption = "   TK - 3313 - Thanh toán với người bán vỏ bình" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn141")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + branchid + "'");
                view.ViewCaption = "   " + dv + " - TK - 141 - Tạm ứng" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn141tct")
            {
                view.ViewCaption = "   TK - 141 - Tạm ứng" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn1388")
            {
                view.ViewCaption = "   TK - 1388 - Phải thu khác" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn1388tct")
            {
                view.ViewCaption = "   TK - 1388 - Phải thu khác toàn công ty" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn3388tct")
            {
                view.ViewCaption = "   TK - 3388 - Phải nộp, phải trả khác toàn công ty" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn33881tct")
            {
                view.ViewCaption = "   TK - 33881 - Phải trả cổ tức năm trước" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn33882tct")
            {
                view.ViewCaption = "   TK - 33882 - Phải trả cổ tức năm trước" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn341118tct")
            {
                view.ViewCaption = "   TK - 341118 - Vay ngắn hạn khác" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn341128tct")
            {
                view.ViewCaption = "   TK - 341128 - Vay dài hạn khác" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbccn3388" || tsbt == "tsbtbccn3388tdv")
            {
                view.ViewCaption = "   TK - 3388 - Phải trả, phải nộp khác" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            if (tsbt != "tsbtbccn3388" && tsbt != "tsbtbccn141")
                baocaocn131.loadcn(lvpq, view, donvicongno, ngaychungtu,tsbt);
            else if (tsbt == "tsbtbccn141")
                baocaocn131.loadcn(lvpq, view, branchid, ngaychungtu, tsbt);
            else
                baocaocn131.loadcn31188(lvpq, view, donvicongno, ngaychungtu, tsbt);

        }
        public void refreshbcptcn131()
        {
            view.OptionsView.ColumnAutoWidth = true;
            if (tsbt == "tsbtbcptcn131")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - Phân tích nợ quá hạn thanh toán với người mua" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbcptcn131tdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   " + dv + " - Phân tích nợ quá hạn thanh toán với người mua" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else
            {
                view.ViewCaption = "  Phân tích nợ quá hạn thanh toán với người mua" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            baocaocn131.loadptcn(lvpq, view, donvicongno, ngaychungtu, tsbt,userid);
        }

        public void refreshtonkho()
        {
            if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                dv = gen.GetString("select StockCode from Stock with (NOLOCK) where StockID='" + donvicongno + "'") + " - " + dv;
                view.ViewCaption = "   Kho " + dv + " - Báo cáo tồn kho" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbctktttdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   Đơn vị " + dv + " - Báo cáo tồn kho" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else
            {
                view.ViewCaption = "  Báo cáo tồn kho toàn công ty" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            bctk.loadbctktsl(lvpq,view,ngaychungtu,tsbt, donvicongno);
        }

        public void refreshtonkhothucte()
        {
            if (tsbt == "tsbtbctktttt")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                dv = gen.GetString("select StockCode from Stock with (NOLOCK) where StockID='" + donvicongno + "'") + " - " + dv;
                view.ViewCaption = "   Kho " + dv + " - Báo cáo tồn kho thực tế" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbctktttttdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   Đơn vị " + dv + " - Báo cáo tồn kho thực tế" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else
            {
                view.ViewCaption = "  Báo cáo tồn kho thực tế toàn công ty" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            bctktt.loadbctktsl(lvpq, view, ngaychungtu, tsbt, donvicongno);
        }

        public void refreshtonkhotndn()
        {
            if (tsbt == "tsbtbctkthdtndn")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                dv = gen.GetString("select StockCode from Stock with (NOLOCK) where StockID='" + donvicongno + "'") + " - " + dv;
                view.ViewCaption = "   Kho " + dv + " - Báo cáo tồn kho" + " - Từ ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            }
            else if (tsbt == "tsbtbctktndntdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   Đơn vị " + dv + " - Báo cáo tồn kho" + " - Từ ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            }
            else
            {
                view.ViewCaption = "  Báo cáo tồn kho toàn công ty" + " - Từ ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            }
            bctk.loadbctkthdtndn(lvpq, view,tungay,denngay, tsbt, donvicongno);
        }

        public void refreshtonkhovo()
        {
            if (tsbt == "tsbtbctkvlpgtt")
            {
                string dv = gen.GetString("select StockName from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
                dv = gen.GetString("select StockCode from Stock with (NOLOCK) where StockID='" + donvicongno + "'") + " - " + dv;
                view.ViewCaption = "   Kho " + dv + " - Báo cáo tồn kho vỏ LPG" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtbctkvlpgtttdv")
            {
                string dv = gen.GetString("select BranchName from Branch with (NOLOCK) where BranchID='" + donvicongno + "'");
                view.ViewCaption = "   Đơn vị " + dv + " - Báo cáo tồn kho vỏ LPG" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else
            {
                view.ViewCaption = "  Báo cáo tồn kho vỏ LPG toàn công ty" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            bctkv.loadbctktsl(lvpq, view, ngaychungtu, tsbt, donvicongno);
        }

        

        public void refreshthtk()
        {
            view.OptionsView.ColumnAutoWidth = true;
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            if (tsbt == "tsbtthtkskt")
            {
                view.ViewCaption = "   Sổ kế toán" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtthtksc")
            {
                view.ViewCaption = "   Sổ cái" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            else if (tsbt == "tsbtthtktq")
            {
                view.ViewCaption = "   Tồn quỹ các loại" + " - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " Năm " + String.Format("{0: yyyy}", DateTime.Parse(ngaychungtu));
            }
            thtk.loadthtkskt(lvpq, view, ngaychungtu,tsbt);
            SplashScreenManager.CloseForm();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void view_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e) 
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (tsbt == "tsbtddh" || tsbt == "tsbtcdh" || tsbt == "tsbtddhtk")
                    {
                        if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[0]) != "")
                        {
                            e.Appearance.BackColor = Color.Salmon;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[10]) == "")
                        {
                            e.Appearance.BackColor2 = Color.Red;
                            e.Appearance.BackColor = Color.SeaShell;
                        }
                    }
                    else if (tsbt == "tsbtddhlpg")
                    {
                        if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[14]).ToString() == "Unchecked")
                        {
                            if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[16]) == "")
                            {
                                e.Appearance.BackColor = Color.Salmon;
                                e.Appearance.BackColor2 = Color.SeaShell;
                            }
                            else if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[12]) == "1")
                            {
                                e.Appearance.BackColor = Color.Green;
                                e.Appearance.BackColor2 = Color.SeaShell;
                            }

                            if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[7]).ToUpper() == "BÁN LẺ")
                            {
                                e.Appearance.BackColor = Color.DodgerBlue;
                                e.Appearance.BackColor2 = Color.SeaShell;
                            }
                        }
                    }
                    else if (tsbt == "131tndntcthmn" && view.GetRowCellDisplayText(e.RowHandle, view.Columns[11]) != "")
                    {                        
                            e.Appearance.BackColor = Color.Salmon;
                            e.Appearance.BackColor2 = Color.SeaShell;
                    }
                    else if (tsbt == "sctbhtkhvmhth")
                    {
                        if (Double.Parse(view.GetRowCellDisplayText(e.RowHandle, view.Columns[10]).ToString()) < 0)
                        {
                            e.Appearance.BackColor = Color.Salmon;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                    else if (tsbt == "barthkqkdhtd")
                    {
                        if (Double.Parse(view.GetRowCellDisplayText(e.RowHandle, view.Columns[9]).ToString()) < 0)
                        {
                            e.Appearance.BackColor = Color.Salmon;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                    else if (tsbt == "tsbtpxkct" && view.GetRowCellDisplayText(e.RowHandle, view.Columns[16]) != "")
                    {
                        if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[9]).ToString() == "Unchecked")
                        {
                            if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[14]) == "")
                            {
                                e.Appearance.BackColor = Color.Salmon;
                                e.Appearance.BackColor2 = Color.SeaShell;
                            }
                            else if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[15]) == "1")
                            {
                                e.Appearance.BackColor = Color.Green;
                                e.Appearance.BackColor2 = Color.SeaShell;
                            }

                            if (view.GetRowCellDisplayText(e.RowHandle, view.Columns[5]).ToUpper() == "BÁN LẺ")
                            {
                                e.Appearance.BackColor = Color.DodgerBlue;
                                e.Appearance.BackColor2 = Color.SeaShell;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userid = Globals.userid;
            
            this.Text = gen.GetString("select Top 1 CompanyName from Center with (NOLOCK)");
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberGroupSeparator = ".";
            customCulture.NumberFormat.NumberDecimalSeparator = ",";
            customCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            try
            {
                roleid = gen.GetString("select RoleID from MSC_UserJoinRole with (NOLOCK) where UserID='" + userid + "'");
                refresh();
            }
            catch
            {
                XtraMessageBox.Show("Tài khoản này chưa được phân quyền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            //MessageBox.Show(System.Environment.MachineName);
            //MessageBox.Show(System.Net.Dns.GetHostName());           
            //login.Hide();
            panelControl1.Visible = false;
            xtraTabControl1.Visible = false;
            DataTable dtinfo = gen.GetTable("select FullName,BranchName,a.BranchID from MSC_User a with (NOLOCK), Branch b with (NOLOCK) where UserID='" + userid + "' and a.BranchID=b.BranchID ");
            branchid = dtinfo.Rows[0][2].ToString();
            banguoidung.Caption = "Người dùng: " + dtinfo.Rows[0][0].ToString();

            /*
            SuperToolTip tooltip = new SuperToolTip();
            ToolTipTitleItem titleItem1 = new ToolTipTitleItem();
            titleItem1.Text = dtinfo.Rows[0][0].ToString();
            ToolTipItem item1 = new ToolTipItem();
            item1.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\avatar.JPG");
            ToolTipSeparatorItem titleItem = new ToolTipSeparatorItem();
            ToolTipItem titleItem2 = new ToolTipItem();
            titleItem2.Text = dtinfo.Rows[0][1].ToString()+"                 ";
            titleItem2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tooltip.Items.Add(titleItem1);
            tooltip.Items.Add(item1);
            tooltip.Items.Add(titleItem);
            tooltip.Items.Add(titleItem2);
            banguoidung.SuperTip = tooltip;*/

            khach = gen.GetTable("select AccountingObjectID as 'ID',AccountingObjectCode as 'Mã khách hàng',AccountingObjectName as 'Tên khách',Address as 'Địa chỉ', CompanyTaxCode as 'Mã số thuế', ContactHomeTel as 'Đội' from AccountingObject with (NOLOCK) order by AccountingObjectCode");

            hang = gen.GetTable("select InventoryItemID as 'ID',InventoryItemCode as 'Mã hàng hóa',InventoryItemName as 'Tên hàng',Unit as 'Đơn vị tính', ConvertUnit as 'Đơn vị quy đổi',convert(decimal(22,2),ConvertRate) as 'Tỷ lệ quy đổi',SalePrice as 'Đơn giá tham khảo',GuarantyPeriod as 'Công ty' from InventoryItem with (NOLOCK) order by InventoryItemCode");

            //khach = gen.GetTable("laymakhach ''");

            badvbot.Caption = "Đơn vị: " + dtinfo.Rows[0][1].ToString();
            ngaychungtu = DateTime.Now.ToString();
            banctbot.Caption = "Ngày chứng từ: " + String.Format("{0:dd/MM/yyyy}", DateTime.Now);

            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User with (NOLOCK) where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Đăng nhập','')");

            /*if (gen.GetString("select CompanyTaxCode from Center") == "")
            {
                navBarItem11.Enabled = true;
                navBarItem50.Enabled = false;
                navBarItem11.Caption = "Báo cáo tồn kho thực tế hàng gửi";
                navBarItem61.Caption = "Bảng kê chi phí bốc xếp hàng gửi kho";
            }
            else */
            SplashScreenManager.CloseForm();

            denngay = ngaychungtu;
            tsbt = "131tndntcthmn";
            refreshbccnhmn();  // load bao cao công nợ quá hạn        

            
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User with (NOLOCK) where UserID='" + userid + "'") + "','" + System.Environment.MachineName + "',GETDATE(),N'Đăng xuất','')");
                }
                catch { }
                this.Dispose();
                login.delete();
                login.Show();
            }
            else
                e.Cancel = true;
        }
        private void view_FocusedRowChanged(object sender, EventArgs e)
        {
            /*if (tsbt == "tsmsc") mscrole.changetabrole(lvinfo, lvuser, view);
            else if (tsbt == "tstbuser") mscrole.changetabuser(lvinfo, lvuser, view);
            else if (tsbt == "tsbtcuspro") cuspro.changetabcuspro(lvinfo, lvuser, view);
            else if (tsbt == "tsbtnhanvien") nhanvien.changetabnhanvien(lvinfo, lvuser, view);
            else if (tsbt == "tsbtpttm" || tsbt == "tsbtptnh" || tsbt == "tsbtpctm" || tsbt == "tsbtpcnh" || tsbt == "tsbtpkt") pttm.changetabpttm(lvinfo, lvuser, view, tsbt);
            else if (tsbt == "tsbtpttmvt" || tsbt == "tsbtptnhvt" || tsbt == "tsbtpctmvt" || tsbt == "tsbtpcnhvt") pttmvt.changetabpttmvt(lvinfo, lvuser, view, tsbt);*/
        }
        private void view_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (tsbt == "tsbtbccn3388")
            {
                if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
                {
                    if (view.GetRowCellValue(view.FocusedRowHandle, "Chọn").ToString() == "False")
                    {
                        string ma = view.GetRowCellValue(view.FocusedRowHandle, "Mã").ToString();
                        gen.ExcuteNonquery("insert into Open3388 values(newid(),'" + ma + "','" + ngaychungtu + "')");
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chọn"], "True");
                    }
                    else
                    {
                        string ma = view.GetRowCellValue(view.FocusedRowHandle, "Mã").ToString();
                        gen.ExcuteNonquery("delete Open3388 where AccountingObjectID='" + ma + "' and MONTH(PostedDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year + "'");
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chọn"], "False");
                    }
                }
            }
            else if (tsbt == "tsbtcuspro")
            {
                if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
                {
                    string ma = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                    DataSet da = new DataSet();
                    da.Tables.Add(gen.GetTable("bangkehoadon '" + ma + "'"));
                    gen.CreateExcel(da, view.GetRowCellValue(view.FocusedRowHandle, "Tên khách hàng - nhà cung cấp").ToString()+" - "+view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng - nhà cung cấp").ToString() + ".xlsx");
                }
            }
            else if (tsbt == "tsbtbctktttt")
            {
                if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
                {
                    try { view.Columns["Giá trị"].Visible = true; }
                    catch { }
                }
            }
            else if (tsbt == "tsbtpxkct" || tsbt == "tsbtpxk")
            {
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                {
                    try
                    {
                        DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' phiếu sẽ được tự động sửa lỗi.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                        {
                            SplashScreenManager.ShowForm(typeof(Frm_wait));
                            pxk.updatepn(view, ngaychungtu);
                            refreshpxkct();
                            SplashScreenManager.CloseForm();
                        }
                    }
                    catch { SplashScreenManager.CloseForm(); }
                }

                if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
                {
                    view.Columns["Chọn"].Visible = true;
                }

                if (e.KeyCode == Keys.X && e.Modifiers == Keys.Control)
                {
                    pxkct.tsbtdeletepxktra(view, this, userid);
                }

                if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
                {
                    for (int i = 0; i < Double.Parse(view.Columns[1].SummaryText.Replace("Số dòng:   ", "").Replace(".", "")); i++)
                        if (view.GetRowCellValue(i, "Chọn").ToString() == "True")
                            gen.ExcuteNonquery("insert OpeningAccountEntry131TT values(newid(),'" + view.GetRowCellValue(i, "Số chứng từ").ToString() + "',NULL,NULL,NULL,0,'" + view.GetRowCellValue(i, "Nhân viên").ToString() + "','" + userid + "','1',NULL,NULL)");

                    hangtieudung htd = new hangtieudung();
                    htd.loadbangkehangtheongayin(ngaychungtu, userid);
                    gen.ExcuteNonquery("delete OpeningAccountEntry131TT where EmployeeIDSAName='" + userid + "'");
                }
            }

            else if (tsbt == "tsbthdbh" || tsbt == "tsbthdmh" || tsbt == "tsbtddhlpg")
            {
                try
                {
                    if (e.KeyCode == Keys.W && e.Modifiers == Keys.Control)
                    {
                        Frm_baocaotaichinh F = new Frm_baocaotaichinh();
                        if (tsbt == "tsbthdbh")
                        {
                            if (gen.GetString("select Posted from SSInvoice with (NOLOCK) where RefID='" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "'") == "True")
                            {
                                XtraMessageBox.Show("Hóa đơn đã được ghi sổ không thể điều chỉnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            F.myac = new Frm_baocaotaichinh.ac(refreshhdbh);
                        }
                        else if (tsbt == "tsbthdmh")
                        {
                            if (gen.GetString("select Posted from PUInvoice with (NOLOCK) where RefID='" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "'") == "True")
                            {
                                XtraMessageBox.Show("Hóa đơn đã được ghi sổ không thể điều chỉnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            F.myac = new Frm_baocaotaichinh.ac(refreshhdmh);
                        }
                        F.getid(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        F.getchungtu(view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString());
                        F.getuser(userid);
                        F.gettsbt(tsbt);
                        F.ShowDialog();
                    }
                    else if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
                    {
                        if (tsbt == "tsbthdbh" || tsbt == "tsbtddhlpg")
                        {
                            Frm_baocaotaichinh F = new Frm_baocaotaichinh();
                            if (tsbt == "tsbthdbh")
                            {
                                if (gen.GetString("select Posted from SSInvoice with (NOLOCK) where RefID='" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "'") == "True")
                                {
                                    XtraMessageBox.Show("Hóa đơn đã được ghi sổ không thể điều chỉnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                F.myac = new Frm_baocaotaichinh.ac(refreshhdbh);
                            }
                            else if (tsbt == "tsbtddhlpg")
                            {
                                if (gen.GetString("select Posted from INOutward with (NOLOCK) where INOutwardRefID='" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "'") == "True")
                                {
                                    XtraMessageBox.Show("Đơn đặt hàng đã được ghi sổ không thể điều chỉnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                F.myac = new Frm_baocaotaichinh.ac(refreshddhlpg);
                            }
                            F.getid(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                            F.getchungtu(view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString());
                            F.getngaychungtu(ngaychungtu);
                            F.getkhach(khach);
                            F.getuser(userid);
                            F.gettsbt(tsbt + "change");
                            F.ShowDialog();
                        }
                    }

                    else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
                    {
                        if (tsbt == "tsbthdbh")
                        {
                            if (dem > -1)
                            {
                                for (int i = 0; i <= dem; i++)
                                    if (hoadon[i, 0] == view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString())
                                        return;
                                    else if (hoadon[i, 1] != view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString())
                                    {
                                        XtraMessageBox.Show("Hóa đơn này khác kho với hóa đơn bạn đã chọn trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }

                            }
                            dem = dem + 1;
                            hoadon[dem, 0] = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                            hoadon[dem, 1] = view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString();
                        }

                        else if (tsbt == "tsbtddhlpg")
                        {
                            if (gen.GetString("select Posted from INOutward with (NOLOCK) where INOutwardRefID='" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "'") == "True")
                            {
                                XtraMessageBox.Show("Đơn đặt hàng đã được ghi sổ không thể điều chỉnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            ddgaschuyen F = new ddgaschuyen();
                            F.getform(this);
                            F.gettsbt(tsbt + "change");
                            F.ShowDialog();
                        }
                    }
                }
                catch { XtraMessageBox.Show("Bạn phải chọn phiếu trước khi sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
        }
       
        private void view_DoubleClick(object sender, EventArgs e)
        {
            if (tsbt == "tsmsc") mscrole.tstbcnmsc("1", this, view, userid);
            else if (tsbt == "tstbuser") mscrole.tstbcnuser("1", this, view, userid);
            //else if (tsbt == "tsbtntk") accountgroup.tsbtntk(this, view);
            //else if (tsbt == "tsbthttk") account.tsbthttk("1", this, view, userid);
            //else if (tsbt == "tsbtcuspro") cuspro.tsbtcuspro("1", this, view, userid);
            //else if (tsbt == "tsbtdv") branch.tsbtbranch("1", this, view, userid);
            //else if (tsbt == "tsbtstock") stock.tsbtstock("1", this, view, userid);
            //else if (tsbt == "tsbtprovince") province.tsbtprovince("1", this, view, userid);
            //else if (tsbt == "tsbtdistrist") distrist.tsbtdistrist("1", this, view, userid);
            //else if (tsbt == "tsbtnhanvien") nhanvien.tsbtnhanvien("1", this, view, userid);
            //else if (tsbt == "tsbtlvthh") iic.tsbtiic("1", this, view, userid);
            //else if (tsbt == "tsbtvthh") ii.tsbtii("1", this, view, userid);
            // phieu thu tien mat
            else if (tsbt == "tsbtpttm") pttm.tsbtpttm("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtptnh") ptnh.tsbtptnh("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpctm") pctm.tsbtpctm("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpcnh") pcnh.tsbtpcnh("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpkt") pkt.tsbtpkt("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpttmvt") pttmvt.tsbtpttmvt("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtptnhvt") ptnhvt.tsbtptnhvt("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpctmvt") pctmvt.tsbtpctmvt("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpcnhvt") pcnhvt.tsbtpcnhvt("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpnk") pnk.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnktt") pnktt.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtpxkhg") pnktt.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtpxk") pxk.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdmh") hdmh.tsbthdmh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdxhgb") hdxhgb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdbh") hdbh.tsbthdbh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnkgas") pnkgas.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid);
            else if (tsbt == "tsbtpxkgas") pxkgas.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid);
            else if (tsbt == "tsbtcknb") cknb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtcknblpg") cknblpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtcknbvlpg") cknbvlpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtxhgb") xhgb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtxhgblpg") xhgblpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtxhgbvlpg") xhgbvlpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtpnkvo") pnkvo.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnkvtddh") pnkvodk.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtddhcl") ddh.tsbtddhcl("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang, branchid);
            else if (tsbt == "tsbtpxkvo") pxkvo.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpndc") pndc.tsbtpndc("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpdctk") pndctk.tsbtpndc("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnhkm") pnkm.tsbtpnht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxdc") pxdc.tsbtpxdc("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnht") pnht.tsbtpnht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxht") pxht.tsbtpxht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, false);
            else if (tsbt == "tsbtpxhtnb") pxht.tsbtpxht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, true);
            else if (tsbt == "tsbtpxhkm") pxkm.tsbtpxht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnhbtl") pnhbtl.tsbtpnhbtl("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxhmtl") pxhmtl.tsbtpxhmtl("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdbhkpx") hdbhkpx.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdmhkpn") hdmhkpn.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxkct") pxkct.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtddh") ddh.tsbtddh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtcdh") ddh.tsbtddh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtddhtk") ddh.tsbtddh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtddhlpg") ddhlpg.tsbtddh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, giaban);
            else if (tsbt == "tsbtunc") unc.tsbtunc("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtddhncc") ddhncc.tsbtddhncc("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            /*Thay thế nút xem-----------------------------------------------------------------------------------------------------*/
            else if (tsbt == "tsbtbccn131" || tsbt == "tsbtbccn131tdv" || tsbt == "tsbtbccn131tct" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn331tdv" || tsbt == "tsbtbccn331tct" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn1313tdv" || tsbt == "tsbtbccn1313tct" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3313tdv" || tsbt == "tsbtbccn3313tct" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388" || tsbt == "tsbtbccn1388tct" || tsbt == "tsbtbccn3388tct")
                baocaocn131.loadbchitietcn(ngaychungtu, tsbt, donvicongno, view, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            else if (tsbt == "tsbtbccn141" || tsbt == "tsbtbccn141tct")
                baocaocn131.loadbchitietcn(ngaychungtu, tsbt, branchid, view, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            else if (tsbt == "tsbtbcptcn131" || tsbt == "tsbtbcptcn131tdv" || tsbt == "tsbtbcptcn131tct")
                baocaocn131.loadbchitietptcn(ngaychungtu, tsbt, donvicongno, view);

            else if (tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388")
                baocaocn131.loadbchitietlai(ngaychungtu, tsbt, donvicongno, view);
            else if (tsbt == "tsbtthtkskt")
            {
                Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
                F.getngaychungtu(ngaychungtu);
                F.gettsbt(tsbt);
                F.getview(view);
                F.ShowDialog();
            }
            else if (tsbt == "tsbtthtksc")
                thtk.loadchitietsctong(ngaychungtu, tsbt, view);
            else if (tsbt == "tsbtthtktq")
            {
                Frm_ngay F = new Frm_ngay();
                F.getngaychungtu(ngaychungtu);
                F.gettsbt(tsbt);
                F.getview(view);
                F.ShowDialog();
            }

            else if (tsbt == "tsbtpncknb") cknb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtpncknblpg") cknblpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtpncknbvlpg") cknbvlpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtpnhgb") xhgb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtpnhgblpg") xhgblpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtpnhgbvlpg") xhgbvlpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);


            else if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu" || tsbt == "tsbtbctktttdv")
                try
                {
                    bctk.inthekho(ngaychungtu, tsbt, donvicongno, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid, hang, khach);
                }
                catch { }
            else if (tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctktttt")
                bctkv.inthekho(ngaychungtu, tsbt, donvicongno, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid);
            else if (tsbt == "tsbtbctkthtct")
                bctk.intonghop(ngaychungtu, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", tsbt);
            /*else if (tsbt == "tsbtpxk" || tsbt == "tsbtpxkct" || tsbt == "tsbthdbh")
                thtk.loadnhatkynhaphang(view.GetRowCellValue(view.FocusedRowHandle, "Ngày chứng từ").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Ngày chứng từ").ToString(), tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());*/
        }

        private void bahttk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbthttk";
            refresh("DImnuDictionaryAccount");
            view.ViewCaption = "   Hệ thống tài khoản";
            account.loadaccount(lvpq, view);            
        }

        private void bantk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtntk";
            refresh("DImnuDictionaryAccountCategory");
            view.ViewCaption = "   Nhóm tài khoản";
            accountgroup.loadgroupaccount(lvpq, view);
        }

        private void badv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtdv";
            refresh("DImnuDictionaryBranch");
            view.ViewCaption = "   Đơn vị";
            view.OptionsView.ColumnAutoWidth = true;
            branch.loadbranch(lvpq, view);
        }

        private void bakhncc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtcuspro";
            refresh("DImnuDictionaryAccountingObject");
            view.ViewCaption = "   Khách hàng - Nhà cung cấp";
            xtraTabPage1.Text = "Thông tin chung";
            xtraTabPage2.Text = "Chi tiết";
            khach = gen.GetTable("select AccountingObjectID as 'ID',AccountingObjectCode as 'Mã khách hàng',AccountingObjectName as 'Tên khách',Address as 'Địa chỉ', CompanyTaxCode as 'Mã số thuế', ContactHomeTel as 'Đội' from AccountingObject with (NOLOCK) order by AccountingObjectCode");
            cuspro.loadcuspro(lvpq, view, "select * from AccountingObject with (NOLOCK) where IsVendor='True' or IsCustomer='True' order by AccountingObjectCode");
        }

        private void banv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtnhanvien";
            refresh("DImnuDictionaryEmployee");
            view.ViewCaption = "   Nhân viên";
            nhanvien.loadnv(lvpq, view, "select * from AccountingObject with (NOLOCK) where IsEmployee='True' order by BranchID, AccountingObjectName");
        }

        private void bakho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtstock";
            refresh("DImnuDictionaryStock");
            view.ViewCaption = "   Kho";
            stock.loadstock(lvpq, view);
        }

        private void balvthhccdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtlvthh";
            refresh("DImnuDictionaryInventoryItemCategory");
            view.ViewCaption = "   Loại vật tư hàng hóa, công cụ dụng cụ";
            //iic.loadiic(lvpq, view);
        }

        private void bavthh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtvthh";
            refresh("DImnuDictionaryInventoryItem");
            hang = gen.GetTable("select InventoryItemID as 'ID',InventoryItemCode as 'Mã hàng hóa',InventoryItemName as 'Tên hàng',Unit as 'Đơn vị tính', ConvertUnit as 'Đơn vị quy đổi',ConvertRate as 'Tỷ lệ quy đổi' from InventoryItem with (NOLOCK) order by InventoryItemCode");
            view.ViewCaption = "   Vật tư hàng hóa";
            refreshii();
        }

        private void battp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtprovince";
            refresh("DImnuDictinaryPaymentTerm");
            view.ViewCaption = "   Tỉnh - Thành phố";
            province.loadprovince(lvpq, view);
        }

        private void baqh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtdistrist";
            refresh("DImnuDictionaryShippingMethod");
            view.ViewCaption = "   Quận - Huyện";
            distrist.loaddistrist(lvpq, view);
        }

        private void bapttm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpttm";
            refresh("CAmnuBusinessCAReceiptList");
            view.ViewCaption = "   Phiếu thu tiền mặt";
            refreshpttm();
        }

        private void baptnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtptnh";
            refresh("BUmnuBUExpense");
            view.ViewCaption = "   Phiếu thu ngân hàng";
            refreshptnh();
        }

        private void bapctm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpctm";
            refresh("CAmnuBusinessCAPaymentList");
            view.ViewCaption = "   Phiếu chi tiền mặt";
            refreshpctm();
        }

        private void bapcnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpcnh";
            refresh("BUmnuBUAllocation");
            view.ViewCaption = "   Phiếu chi ngân hàng";
            refreshpcnh();
        }

        private void bapkt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpkt";
            refresh("PUmnuBusinessPUEnterInvoiceList");
            view.ViewCaption = "   Phiếu kế toán";
            refreshpkt();
        }

        private void baqlnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tstbuser";
            refresh("SYSmnuSystemUser");
            view.ViewCaption = "   Quản lý người dùng";
            xtraTabPage1.Text = "Thông tin chung";
            xtraTabPage2.Text = "Chi tiết";
            mscrole.loaduser(lvpq, view);
        }

        private void bavtqh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsmsc";
            refresh("SYSmnuSystemRoleAndRule");
            view.ViewCaption = "   Vai trò và quyền hạn";
            xtraTabPage1.Text = "Thông tin chung";
            xtraTabPage2.Text = "Chi tiết";
            refreshmsc();
        }

        private void baadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tsbt == "tsmsc") mscrole.tstbcnmsc("0", this, view, userid);
            else if (tsbt == "tstbuser") mscrole.tstbcnuser("0", this, view, userid);
            else if (tsbt == "tsbthttk") account.tsbthttk("0", this, view, userid);
            else if (tsbt == "tsbtcuspro") cuspro.tsbtcuspro("0", this, view, userid);
            else if (tsbt == "tsbtdv") branch.tsbtbranch("0", this, view, userid);
            else if (tsbt == "tsbtstock") stock.tsbtstock("0", this, view, userid);
            else if (tsbt == "tsbtprovince") province.tsbtprovince("0", this, view, userid);
            else if (tsbt == "tsbtdistrist") distrist.tsbtdistrist("0", this, view, userid);
            else if (tsbt == "tsbtnhanvien") nhanvien.tsbtnhanvien("0", this, view, userid);
            //else if (tsbt == "tsbtlvthh") iic.tsbtiic("0", this, view, userid);
            else if (tsbt == "tsbtvthh") ii.tsbtii("0", this, view, userid);
            else if (tsbt == "tsbtpttm") pttm.tsbtpttm("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtptc") ptctm.tsbtpttm("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtptnh") ptnh.tsbtptnh("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpctm") pctm.tsbtpctm("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpcnh") pcnh.tsbtpcnh("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtunc") unc.tsbtunc("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpkt") pkt.tsbtpkt("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpttmvt") pttmvt.tsbtpttmvt("0", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtptnhvt") ptnhvt.tsbtptnhvt("0", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpctmvt") pctmvt.tsbtpctmvt("0", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpcnhvt") pcnhvt.tsbtpcnhvt("0", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpnk") pnk.tsbtpnk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnktt") pnktt.tsbtpnk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtpxkhg") pnktt.tsbtpnk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtpxk") pxk.tsbtpxk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnkgas") pnkgas.tsbtpnk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid);
            else if (tsbt == "tsbtpxkgas") pxkgas.tsbtpxk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid);
            else if (tsbt == "tsbtpnkvo") pnkvo.tsbtpnk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnkvtddh") pnkvodk.tsbtpnk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxkvo") pxkvo.tsbtpxk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtcknb") cknb.tsbtpck("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtcknblpg") cknblpg.tsbtpck("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtcknbvlpg") cknbvlpg.tsbtpck("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtxhgb") xhgb.tsbtpck("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtxhgblpg") xhgblpg.tsbtpck("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtxhgbvlpg") xhgbvlpg.tsbtpck("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbthdmh") hdmh.tsbthdmh("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdbh") hdbh.tsbthdbh("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdxhgb") hdxhgb.tsbtpck("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpndc") pndc.tsbtpndc("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpdctk") pndctk.tsbtpndc("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxdc") pxdc.tsbtpxdc("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnht") pnht.tsbtpnht("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnhkm") pnkm.tsbtpnht("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxht") pxht.tsbtpxht("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, false);
            else if (tsbt == "tsbtpxhtnb") pxht.tsbtpxht("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, true);
            else if (tsbt == "tsbtpxhkm") pxkm.tsbtpxht("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnhbtl") pnhbtl.tsbtpnhbtl("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxhmtl") pxhmtl.tsbtpxhmtl("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdbhkpx") hdbhkpx.tsbtpxk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdmhkpn") hdmhkpn.tsbtpxk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxkct") pxkct.tsbtpxk("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtckkh") thkqkd.tsbtckkh("0", this, view, ngaychungtu);
            else if (tsbt == "tsbttgp") thkqkd.tsbttgp("0", this, view, ngaychungtu);
            else if (tsbt == "tsbtcsncc") csncc.tsbtcsncc("0", this, view, userid, ngaychungtu);
            else if (tsbt == "tsbthdkh") hd.tsbthd("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtplbl") hd.tsbtplbl("0", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtddh") ddh.tsbtddh("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtddhcl") ddh.tsbtddhcl("0", this, view, roleid, subsys, ngaychungtu, userid, khach, hang, branchid);
            else if (tsbt == "tsbtddhlpg") ddhlpg.tsbtddh("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, giaban);
            else if (tsbt == "tsbtddhncc") ddhncc.tsbtddhncc("0", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
        }

        private void baedit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tsbt == "tsmsc") mscrole.tstbcnmsc("1", this, view, userid);
            else if (tsbt == "tstbuser") mscrole.tstbcnuser("1", this, view, userid);
            else if (tsbt == "tsbtntk") accountgroup.tsbtntk(this, view);
            else if (tsbt == "tsbthttk") account.tsbthttk("1", this, view, userid);
            else if (tsbt == "tsbtcuspro") cuspro.tsbtcuspro("1", this, view, userid);
            else if (tsbt == "tsbtdv") branch.tsbtbranch("1", this, view, userid);
            else if (tsbt == "tsbtstock") stock.tsbtstock("1", this, view, userid);
            else if (tsbt == "tsbtprovince") province.tsbtprovince("1", this, view, userid);
            else if (tsbt == "tsbtdistrist") distrist.tsbtdistrist("1", this, view, userid);
            else if (tsbt == "tsbtnhanvien") nhanvien.tsbtnhanvien("1", this, view, userid);
            //else if (tsbt == "tsbtlvthh") iic.tsbtiic("1", this, view, userid);
            else if (tsbt == "tsbtvthh") ii.tsbtii("1", this, view, userid);
            else if (tsbt == "tsbtpttm") pttm.tsbtpttm("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtptc") ptctm.tsbtpttm("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtptnh") ptnh.tsbtptnh("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpctm") pctm.tsbtpctm("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpcnh") pcnh.tsbtpcnh("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtunc") unc.tsbtunc("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpkt") pkt.tsbtpkt("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtpttmvt") pttmvt.tsbtpttmvt("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtptnhvt") ptnhvt.tsbtptnhvt("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpctmvt") pctmvt.tsbtpctmvt("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpcnhvt") pcnhvt.tsbtpcnhvt("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang);
            else if (tsbt == "tsbtpnk") pnk.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnktt") pnktt.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtpxkhg") pnktt.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtpxk") pxk.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdmh") hdmh.tsbthdmh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdxhgb") hdxhgb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdbh") hdbh.tsbthdbh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnkgas") pnkgas.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid);
            else if (tsbt == "tsbtpxkgas") pxkgas.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid);
            else if (tsbt == "tsbtcknb") cknb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtcknblpg") cknblpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtcknbvlpg") cknbvlpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtxhgb") xhgb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtxhgblpg") xhgblpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtxhgbvlpg") xhgbvlpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtpnkvo") pnkvo.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnkvtddh") pnkvodk.tsbtpnk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxkvo") pxkvo.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpndc") pndc.tsbtpndc("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpdctk") pndctk.tsbtpndc("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnhkm") pnkm.tsbtpnht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxdc") pxdc.tsbtpxdc("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnht") pnht.tsbtpnht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxht") pxht.tsbtpxht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, false);
            else if (tsbt == "tsbtpxhtnb") pxht.tsbtpxht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, true);
            else if (tsbt == "tsbtpxhkm") pxkm.tsbtpxht("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpnhbtl") pnhbtl.tsbtpnhbtl("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxhmtl") pxhmtl.tsbtpxhmtl("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdbhkpx") hdbhkpx.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbthdmhkpn") hdmhkpn.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtpxkct") pxkct.tsbtpxk("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
            else if (tsbt == "tsbtckkh") thkqkd.tsbtckkh("1", this, view, ngaychungtu);
            else if (tsbt == "tsbttgp") thkqkd.tsbttgp("1", this, view, ngaychungtu);
            else if (tsbt == "tsbtcsncc") csncc.tsbtcsncc("1", this, view, userid, ngaychungtu);
            else if (tsbt == "tsbthdkh") hd.tsbthd("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtplbl") hd.tsbtplbl("1", this, view, roleid, subsys, ngaychungtu, userid, khach);
            else if (tsbt == "tsbtddh") ddh.tsbtddh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtddhcl") ddh.tsbtddhcl("1", this, view, roleid, subsys, ngaychungtu, userid, khach, hang, branchid);
            else if (tsbt == "tsbtcdh") ddh.tsbtddh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtddhtk") ddh.tsbtddh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, tsbt);
            else if (tsbt == "tsbtddhlpg") ddhlpg.tsbtddh("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang, giaban);
            else if (tsbt == "tsbtddhncc") ddhncc.tsbtddhncc("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, khach, hang);
        }

        private void badelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User with (NOLOCK) where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Xóa','" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "')");
            }
            catch { }

            if (tsbt == "tsmsc") mscrole.tstbdelete(view, this);
            else if (tsbt == "tstbuser") mscrole.tstbdeleteuser(view, this);
            else if (tsbt == "tsbthttk") account.deleteaccount(view, this);
            else if (tsbt == "tsbtcuspro") cuspro.tsbtdeletecuspro(view, this);
            else if (tsbt == "tsbtdv") branch.tsbtdeletebranch(view, this);
            else if (tsbt == "tsbtstock") stock.tsbtdeletestock(view, this);
            else if (tsbt == "tsbtprovince") province.tsbtdeleteprovince(view, this);
            else if (tsbt == "tsbtdistrist") distrist.tsbtdeletedistrist(view, this);
            else if (tsbt == "tsbtnhanvien") nhanvien.tsbtdeletenhanvien(view, this);
            //else if (tsbt == "tsbtlvthh") iic.tsbtdeleteiic(view, this);
            else if (tsbt == "tsbtvthh") ii.tsbtdeleteii(view, this);
            else if (tsbt == "tsbtpttm") pttm.tsbtdeletepttm(view, this);
            else if (tsbt == "tsbtptnh") ptnh.tsbtdeleteptnh(view, this);
            else if (tsbt == "tsbtpctm") pctm.tsbtdeletepctm(view, this);
            else if (tsbt == "tsbtptc") ptctm.tsbtdeletepttm(view, this);
            else if (tsbt == "tsbtpcnh") pcnh.tsbtdeletepcnh(view, this);
            else if (tsbt == "tsbtunc") unc.tsbtdeleteunc(view, this);
            else if (tsbt == "tsbtpkt") pkt.tsbtdeletepkt(view, this);
            else if (tsbt == "tsbtpttmvt") pttmvt.tsbtdeletepttmvt(view, this);
            else if (tsbt == "tsbtptnhvt") ptnhvt.tsbtdeleteptnhvt(view, this);
            else if (tsbt == "tsbtpctmvt") pctmvt.tsbtdeletepctmvt(view, this);
            else if (tsbt == "tsbtpcnhvt") pcnhvt.tsbtdeletepcnhvt(view, this);
            else if (tsbt == "tsbtpnk") pnk.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtpnktt") pnktt.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtpxkhg") pnktt.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtpxk") pxk.tsbtdeletepxk(view, this, userid);
            else if (tsbt == "tsbthdmh") hdmh.tsbtdeletehdmh(view, this);
            else if (tsbt == "tsbthdbh") hdbh.tsbtdeletehdbh(view, this);
            else if (tsbt == "tsbthdxhgb") hdxhgb.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtpnhbtl") pnhbtl.tsbtdeletepndc(view, this);
            else if (tsbt == "tsbtpnhkm") pnkm.tsbtdeletepnht(view, this);
            else if (tsbt == "tsbtpxhkm") pxkm.tsbtdeletepxht(view, this);
            else if (tsbt == "tsbtpnkgas") pnkgas.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtpxkgas") pxkgas.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtnktc") thue.deletelog(view, this, ngaychungtu);
            else if (tsbt == "tsbtpnkvo") pnkvo.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtpnkvtddh") pnkvodk.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtpxkvo") pxkvo.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtpndc") pndc.tsbtdeletepndc(view, this);
            else if (tsbt == "tsbtpdctk") pndctk.tsbtdeletepndc(view, this);
            else if (tsbt == "tsbtpnhkm") pnkm.tsbtdeletepnht(view, this);
            else if (tsbt == "tsbtpxdc") pxdc.tsbtdeletepxdc(view, this);
            else if (tsbt == "tsbtpnht") pnht.tsbtdeletepnht(view, this);
            else if (tsbt == "tsbtpxht" || tsbt == "tsbtpxhtnb") pxht.tsbtdeletepxht(view, this);
            else if (tsbt == "tsbtpxhkm") pxkm.tsbtdeletepxht(view, this);
            else if (tsbt == "tsbtpnhbtl") pnhbtl.tsbtdeletepndc(view, this);
            else if (tsbt == "tsbtpxhmtl") pxhmtl.tsbtdeletepndc(view, this);
            else if (tsbt == "tsbtcknb") cknb.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtcknblpg") cknblpg.tsbtdeletepnk(view, this);

            else if (tsbt == "tsbtcknbvlpg") cknbvlpg.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtxhgb") xhgb.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtxhgblpg") xhgblpg.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbtxhgbvlpg") xhgbvlpg.tsbtdeletepnk(view, this);
            else if (tsbt == "tsbthdbhkpx") hdbhkpx.tsbtdelete(view, this);
            else if (tsbt == "tsbthdmhkpn") hdmhkpn.tsbtdelete(view, this);

            else if (tsbt == "tsbtpxkct") pxkct.tsbtdeletepxk(view, this, userid);
            else if (tsbt == "tsbtddhlpg") ddhlpg.tsbtdeletepxk(view, this, userid);
            else if (tsbt == "tsbtddh") ddh.tsbtdeletepxk(view, this);
            else if (tsbt == "tsbtddhcl") ddh.tsbtdeletepcl(view, this);

            else if (tsbt == "tsbtckkh") thkqkd.tsbtdeleteckkh(view, this);
            else if (tsbt == "tsbttgp") thkqkd.tsbtdeletetgp(view, this);
            else if (tsbt == "tsbthdkh") hd.tsbtdeletehd(view, this);
            else if (tsbt == "tsbtplbl") hd.tsbtdeleteplbl(view, this);
            else if (tsbt == "tsbtddhncc") ddhncc.tsbtdeletepnk(view, this);

            else if (tsbt == "tsbtcsncc") csncc.tsbtdeletecsncc(view, this, userid);
        }

        private void bapq_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tsbt == "tsmsc")
                mscrole.tstbmsc(view);
        }

        private void bacvt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mscrole.tstbchoiceuser(this, view);
        }

        private void banct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_nht u = new Frm_nht();
            u.myac = new Frm_nht.ac(getnct);
            u.getform(this);
            u.getdate(ngaychungtu);
            u.ShowDialog();
        }

        private void bapttmvt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpttmvt";
            refresh("BAmnuBusinessBATransferList");
            view.ViewCaption = "   Phiếu thu tiền mặt bán vật tư";
            refreshpttmvt();
        }

        private void baptnhvt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtptnhvt";
            refresh("BUmnuBUUsingBudget");
            view.ViewCaption = "   Phiếu thu ngân hàng bán vật tư";
            refreshptnhvt();
        }

        private void bapctmvt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpctmvt";
            refresh("BAmnuBusinessBAWithdrawList");
            view.ViewCaption = "   Phiếu chi tiền mặt mua vật tư";
            refreshpctmvt();
        }

        private void bapcnhvt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpcnhvt";
            refresh("PUmnuBusinessPUPurchaseOrder");
            view.ViewCaption = "   Phiếu chi ngân hàng mua vật tư";
            refreshpcnhvt();
        }

        private void bapxk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxk";
            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Phiếu xuất kho";
            refreshpxk();
        }

        private void bahdmh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbthdmh";
            refresh("PUmnuBusinessPUReceiptItemList");
            view.ViewCaption = "   Hóa đơn mua hàng";
            refreshhdmh();
        }

        private void bapnkgas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnkgas";
            refresh("INmnuBusinessAssemblyAndUnBuild");
            view.ViewCaption = "   Phiếu nhập kho Gas";
            refreshpnkgas();
        }

        private void bapnk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnk";
            refresh("INmnuBusinessINInwardList");
            view.ViewCaption = "   Phiếu nhập kho hàng hóa";
            refreshpnk();
        }

        private void bahdbh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaothue bc = new baocaothue();
            bc.loadthueloi(ngaychungtu, "tsbtthuedaura", "", "intonghop", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid);

            tsbt = "tsbthdbh";
            refresh("PUmnuBusinessPUInvoiceWithoutStockList");
            view.ViewCaption = "   Hóa đơn bán hàng";
            refreshhdbh();
        }

        private void bapxkgas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxkgas";
            refresh("INmnuBusinessINTransferList");
            view.ViewCaption = "   Phiếu xuất kho LPG";
            refreshpxkgas();
        }

        private void bapnkvo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnkvo";
            refresh("INmnuBusinessINAdjustmentList");
            view.ViewCaption = "   Phiếu nhập kho vỏ LPG";
            refreshpnkvo();
        }

        private void bapxkvo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxkvo";
            refresh("INmnuBusinessINUpdateOutwardPrice");
            view.ViewCaption = "   Phiếu xuất kho vỏ LPG";
            refreshpxkvo();
        }

        private void backnb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtcknb";
            refresh("BA");
            view.ViewCaption = "   Phiếu xuất chuyển kho nội bộ";
            refreshcknb();
        }

        private void backnblpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtcknblpg";
            refresh("BAmnuBAOnlineBanking");
            view.ViewCaption = "   Phiếu xuất chuyển kho nội bộ LPG";
            refreshcknblpg();
        }

        private void backnbvlpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtcknbvlpg";
            refresh("BAmnuBusinessBADepositList");
            view.ViewCaption = "   Phiếu xuất chuyển kho nội bộ vỏ LPG";
            refreshcknbvlpg();
        }

        private void baxhgb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtxhgb";
            refresh("BAmnuBusinessBADepositList");
            view.ViewCaption = "   Phiếu xuất hàng gửi bán";
            refreshxhgb();
        }

        private void baxhgbvlpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtxhgbvlpg";            
            refresh("BAmnuBusinessBAReconciliation");
            view.ViewCaption = "   Phiếu xuất hàng gửi bán vỏ LPG";
            refreshxhgbvlpg();
        }

        private void baxhgblpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtxhgblpg";
            refresh("BAmnuBusinessBAInternalTransfer");
            view.ViewCaption = "   Phiếu xuất hàng gửi bán LPG";
            refreshxhgblpg();
        }

        private void banctmn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_nht u = new Frm_nht();
            u.myac = new Frm_nht.ac(getnct);
            u.getform(this);
            u.getdate(ngaychungtu);
            u.ShowDialog();
        }

        private void bandcss_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void bapxdc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxdc";
            refresh("PUmnuBusinessPUVendorPaymentCashOnHandList");
            view.ViewCaption = "   Phiếu xuất điều chỉnh";
            refreshpxdc();
        }

        private void bapndc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpndc";
            refresh("PUmnuBusinessPUReturnAndDiscount");
            view.ViewCaption = "   Phiếu nhập điều chỉnh";
            refreshpndc();
        }

        private void bapnht_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnht";
            refresh("SAmnuSalePolicy");
            view.ViewCaption = "   Phiếu nhập hàng thừa";
            refreshpnht();
        }

        private void bapxht_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxht";
            refresh("SAmnuBusinessSASaleQuote");
            view.ViewCaption = "   Phiếu xuất hàng thiếu";
            refreshpxht();
        }

        private void babctktsl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt="tsbtbctktsl"; // bao cao ton kho hang hoa theo so luong
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkho);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }

        private void babctkthdtndn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbctkthdtndn";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkhotndn);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }

        private void bapnhbtl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnhbtl";
            refresh("SAmnuBusinessSAInvoiceWithCashList");
            view.ViewCaption = "   Phiếu nhập hàng bán trả lại";
            refreshpnhbtl();
        }      

        private void barbctktttdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbctktttdv";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkho);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }

      

        private void babctktndntdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbctktndntdv";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkhotndn);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }


        private void babctkthtct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            tsbt = "tsbtbctkthtct";
            refreshbaocao(tsbt);
            refreshtonkho();
            SplashScreenManager.CloseForm();
        }

        private void babctktndntct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbctktndntct";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkhotndn);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }

        private void babctkvlpgtt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbctkvlpgtt";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkhovo);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }

        private void babctkvlpgtttdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbctkvlpgtttdv";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkhovo);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }

        private void babctkvlpgtttct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            tsbt = "tsbtbctkvlpgtttct";
            refreshbaocao(tsbt);
            refreshtonkhovo();
            SplashScreenManager.CloseForm();
        }

        private void babctkvlpgtndn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbctkvlpgtndn");
            u.ShowDialog();
        }

        private void babctkvlpgtndntdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbctkvlpgtndntdv");
            u.ShowDialog();
        }

        private void babctkvlpgtct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbctkvlpgtndntct");
            u.ShowDialog();
        }

        private void babccn131_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn131");
            u.ShowDialog();
        }

        private void barin_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tsbt == "tsbtbccn131" || tsbt == "tsbtbccn131tct" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn331tct" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388" || tsbt == "tsbtbccn1388tct" || tsbt == "tsbtbccn3388tct" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn1313tct" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3313tct")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in công nợ đầy đủ, 'No' để in công nợ tóm tắt.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    baocaocn131.loadbccn(ngaychungtu, tsbt, donvicongno, view, userid);
                else if (dr == DialogResult.No)
                    baocaocn131.loadbccntomtat(ngaychungtu, tsbt, donvicongno, view);
                else if (dr == DialogResult.Cancel && tsbt == "tsbtbccn131tct")
                    baocaocn131.loadbccntheokho(ngaychungtu, tsbt, donvicongno, view);
            }
            else if (tsbt == "tsbtbcptcn131" || tsbt == "tsbtbcptcn131tdv")
                baocaocn131.loadbcptcn(ngaychungtu, tsbt, donvicongno, view);
            else if (tsbt == "tsbtbcptcn131tct")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in bảng quá hạn đầy đủ, 'No' để in bảng chi tiết theo kho.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    baocaocn131.loadbcptcn(ngaychungtu, tsbt, donvicongno, view);
                else if (dr == DialogResult.No)
                    baocaocn131.loadbcptcnkho(ngaychungtu, tsbt);
            }
            else if (tsbt == "tsbtthtkskt" || tsbt == "tsbtthtksc")
            {
                baocaothue bct = new baocaothue();
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in bảng cân đối đầy đủ, 'No' để in bảng cân đối tóm tắt.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    bct.loadbcdtk(ngaychungtu, tsbt, view, "yes");
                else if (dr == DialogResult.No)
                    bct.loadbcdtk(ngaychungtu, tsbt, view, "no");
            }
            else if (tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388")
            {
                Frm_intonghop F = new Frm_intonghop();
                F.getngaychungtu(ngaychungtu);
                F.getview(view);
                F.gettsbt(tsbt);
                F.ShowDialog();
            }

            else if (tsbt == "tsbtthtktq")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in tồn quỹ chi tiết, 'No' để in tồn quỹ tổng hợp.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    thtk.loadton(view, view.GetRowCellValue(view.FocusedRowHandle, "Tài khoản").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Tên tài khoản").ToString(), "tsbtthtktqtong", ngaychungtu);
                else if (dr == DialogResult.No)
                    thtk.loadtontheothang(view, view.GetRowCellValue(view.FocusedRowHandle, "Tài khoản").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Tên tài khoản").ToString(), "tsbtthtktqtongtheothang", ngaychungtu);
            }
            else if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu" || tsbt == "tsbtbctktttdv" || tsbt == "tsbtbctkthtct")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in tồn kho chi tiết, 'No' để in tồn kho tổng hợp.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    bctk.inbctk(ngaychungtu, tsbt, donvicongno, view, userid, "hien");
                else
                    bctk.inbctk(ngaychungtu, tsbt, donvicongno, view, userid, "an");
            }
            else if (tsbt == "tsbtbctkthdtndn" || tsbt == "tsbtbctktndntdv" || tsbt == "tsbtbctktndntct")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in tồn kho chi tiết, 'No' để in tồn kho tổng hợp.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    bctk.inbctktndn(tungay, denngay, tsbt, donvicongno, view, userid, "hien");
                else
                    bctk.inbctktndn(tungay, denngay, tsbt, donvicongno, view, userid, "an");
            }
            else if (tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctkvlpgtttdv" || tsbt == "tsbtbctkvlpgtttct")
                bctkv.inbctk(ngaychungtu, tsbt, donvicongno, view, userid);
            else if (tsbt == "tsbtbctktttt" || tsbt == "tsbtbctktttttdv" || tsbt == "tsbtbctktttct")
            {
                DialogResult dr = new DialogResult();
                if (gen.GetString("select CompanyTaxCode from Center with (NOLOCK)") == "")
                {
                    if (tsbt == "tsbtbctktttttdv")
                    {
                        dr = XtraMessageBox.Show("Nhấn 'Yes' để in tồn kho tổng hợp, 'No' để in chi tiết theo kho, 'Cancel' để in tồn kho theo loại.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                            bctktt.inbctk(ngaychungtu, tsbt, donvicongno, view);
                        else if (dr == DialogResult.No)
                            bctktt.inbctkcthgb(ngaychungtu, tsbt, donvicongno);
                        else if (dr == DialogResult.Cancel)
                            bctktt.inbctkcthgb(ngaychungtu, tsbt + "loai", donvicongno);
                    }
                    else
                    {
                        dr = XtraMessageBox.Show("Nhấn 'Yes' để in tồn kho tổng hợp, 'No' để in tồn kho hàng công ty, 'Cancel' để in tồn kho hàng gửi.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                            bctktt.inbctk(ngaychungtu, tsbt, donvicongno, view);
                        else if (dr == DialogResult.No)
                            bctktt.inbctkkm(ngaychungtu, tsbt, donvicongno, view);
                        else if (dr == DialogResult.Cancel)
                            bctktt.inbctkkm(ngaychungtu, tsbt + "hg", donvicongno, view);
                    }
                }
                else
                {
                    dr = XtraMessageBox.Show("Nhấn 'Yes' để in tồn kho thực tế, 'No' để in tồn kho khuyến mãi.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                        bctktt.inbctk(ngaychungtu, tsbt, donvicongno, view);
                    else if (dr == DialogResult.No)
                        bctktt.inbctkkm(ngaychungtu, tsbt, donvicongno, view);
                }
            }
            else if (tsbt == "tsbtpkt")
            {
                Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
                F.getngaychungtu(ngaychungtu);
                F.gettsbt(tsbt);
                F.ShowDialog();
            }
            else if (tsbt == "tsbtcuspro")
                gen.ViewExcel(view, "Danhsachkhachhang.xlsx");
            else if (tsbt == "tsbtvthh")
                gen.ViewExcel(view, "Danhsachhanghoa.xlsx");
            else if (tsbt == "tsbthdbh")
                gen.ViewExcel(view, "Hoadonbanhang" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
            else if (tsbt == "tsbtnktc")
                gen.ViewExcel(view, "Nhatkytruycap" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
            else if (tsbt == "tsbtpxkct")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in nhật ký xuất kho, 'No' để in bảng kê chênh lệch hóa đơn.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    gen.ViewExcel(view, "Nhatkyxuatkho" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
                else if (dr == DialogResult.No)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(gen.GetTable("select RefNo as 'Số phiếu',soluong as 'Số lượng',soluongxuat as 'Số lượng xuất',soluong-soluongxuat as 'Chênh lệch lượng',tien as 'Số tiền',tienxuat as 'Số tiền xuất',tien-tienxuat as 'Chênh lệch tiền' from (select a.RefID,RefNo,SUM(QuantityConvert) as soluong,SUM(Amount) as tien from INOutward a with (NOLOCK), INOutwardDetail b with (NOLOCK) where a.RefID=b.RefID and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "' and a.StockID='" + gen.GetString("select StockID from Stock with (NOLOCK) where StockCode='" + view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString() + "'") + "' group by a.RefID,RefNo) a, (select INOutwardID,SUM(QuantityConvert) as soluongxuat,SUM(TotalAmount) as tienxuat from SSInvoiceINOutward with (NOLOCK) group by INOutwardID) b where a.RefID=b.INOutwardID"));
                    gen.CreateExcel(ds, "Bangkechenhlechhoadon" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
                }
            }
            else if (tsbt == "bkcthddtt")
                gen.ViewExcel(view, "Bangkechitiethoadonduocthanhtoan" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
            else if (tsbt == "tsbtddh")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in tổng hợp, 'No' để in chi tiết.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    gen.ViewExcel(view, "Dondathangnoibo" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
                else if (dr == DialogResult.No)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(gen.GetTable("select RefDate as 'Ngày đặt',RefNo as 'Số phiếu',a.AccountingObjectName as 'Tên khách',a.AccountingObjectAddress as 'Địa chỉ',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng',QuantityExits as 'Số lượng',QuantityConvertExits as 'Trọng lượng',StockCode as 'Kho cung ứng', e.AccountingObjectName as 'Nhân viên' from DDH a,DDHDetail b, InventoryItem c, Stock d, AccountingObject e where a.RefID=b.RefID and b.InventoryItemID=c.InventoryItemID and a.OutStockID=d.StockID and a.EmployeeIDSA=e.AccountingObjectID and MONTH(RefDate)='" + DateTime.Parse(ngaychungtu).Month + "' and YEAR(RefDate)='" + DateTime.Parse(ngaychungtu).Year + "' and InStockID='" + gen.GetString("select StockID from Stock with (NOLOCK) where StockCode='" + view.GetRowCellValue(view.FocusedRowHandle, "Kho nhận").ToString() + "'") + "' order by RefDate"));
                    gen.CreateExcel(ds, "Dondathangnoibochitiet" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
                }

            }
            else if (tsbt == "tsbtptc")
                thtk.loadbangkephieuthu(ngaychungtu, "", tsbt, userid);
            else if (tsbt == "tsbthttk")
                lvpq.ShowPrintPreview();
            else if (tsbt == "tsbthdxhgb")
                gen.ViewExcel(view, "Hoadonguiban" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
            else if (tsbt == "tsbttgp")
                gen.ViewExcel(view, "Tanggiamphi" + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + ".xlsx");
            else if (tsbt == "tsbthdkh")
            {
                //DataSet da = new DataSet();
                //da.Tables.Add(gen.GetTable("bangkehopdong '" + userid + "'"));
                //gen.CreateExcel(da, "Hopdong.xlsx");
                gen.ViewExcel(view, "Hopdong_" + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)));
            }
            else if (tsbt == "131tndntcthmn")
                baocaocn131.loadbccntndnhmnin(ngaychungtu, ngaychungtu, tsbt, lvpq, view);

            else if (tsbt == "tsbtbcslbhtt" || tsbt == "tsbtbcdtlntt" || tsbt == "tsbtbcslbhtq" || tsbt == "tsbtbcdtlntq" || tsbt == "tsbtbcdtsl" || tsbt == "tsbtdskhm" || tsbt == "tsbtdskhkpsdt" || tsbt == "tsbtbcthlthh" || tsbt == "tsbtbcdtlnct")
                gen.ViewExcel(view, "Baocaonhanh.xlsx");
            else if (tsbt == "sctbhtkhvmhth")
                gen.ViewExcel(view, "Baocaosanluong_" + gen.GetString("select BranchCode from Branch with (NOLOCK) where BranchID='" + branchid + "'") + "_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + "_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay)));
            else if (tsbt == "barbkckncc")
                gen.ViewExcel(view, "Bangkechietkhaunhacungcap_" + String.Format("{0:MM-yyyy}", DateTime.Parse(ngaychungtu)));
            else if (tsbt == "barbccntnh")
                gen.ViewExcel(view, "Baocaocongnotheonganh_" + String.Format("{0:MM-yyyy}", DateTime.Parse(ngaychungtu)));
            else if (tsbt == "bccntnh")
                gen.ViewExcel(view, "Baocaocongnotheonganh_" + String.Format("{0:MM-yyyy}", DateTime.Parse(ngaychungtu)));
            else if (tsbt == "barthkqkdhtd")
                gen.ViewExcel(view, "Baocaodoanhthusanluong_" + String.Format("{0:MM-yyyy}", DateTime.Parse(ngaychungtu)));
            else if (tsbt == "barthkqkdhtdln")
                gen.ViewExcel(view, "Baocaotinhhinhkinhdoanh_" + String.Format("{0:MM-yyyy}", DateTime.Parse(ngaychungtu)));
            else if (tsbt == "bklstcv")
                gen.ViewExcel(view, "Lichsuthechanvo_" + String.Format("{0:dd-MM-yyyy}", DateTime.Now));
            else if (tsbt == "barbcdtth")
                gen.ViewExcel(view, "Baocaodoanhthutrahang_" + String.Format("{0:MM-yyyy}", DateTime.Parse(ngaychungtu)));
            else if (tsbt == "barbcthgnhh")
                gen.ViewExcel(view, "Baocaotinhhinhgiaonhanhanghoa_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu).AddDays(-1)));
            else if (tsbt == "barptncctct")
                gen.ViewExcel(view, "Baocaophaithunhacungcaptheochuongtrinh_" + String.Format("{0:MM-yyyy}", DateTime.Parse(ngaychungtu)));
            else if (tsbt == "tsbtbkthtncp")
                gen.ViewExcel(view, "Bangkenhomchiphi_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + "_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay)));
            else if (tsbt == "tsbtpnkvtddh")
            {
                Frm_reportmain F = new Frm_reportmain();
                F.getngaychungtu(ngaychungtu);
                F.getuser(userid);
                F.gettsbt("tsbtpnkvtddh");
                //F.gettsbt("bkthhhtx");
                F.ShowDialog();

            }
            else if (tsbt == "bcslmb")
                gen.ViewExcel(view, "Baocaosanluongmuaban_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + "_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay)));
            else if (tsbt == "tsbtpttm")
            {
                Frm_ngay F = new Frm_ngay();
                F.getngaychungtu(ngaychungtu);
                F.getuser(userid);
                F.gettsbt(tsbt);
                F.ShowDialog();
            }
        }

        private void baxem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tsbt == "tsbtbccn331" || tsbt == "tsbtbccn331tdv" || tsbt == "tsbtbccn331tct" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn1313tdv" || tsbt == "tsbtbccn1313tct" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3313tdv" || tsbt == "tsbtbccn3313tct" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388" || tsbt == "tsbtbccn1388tct" || tsbt == "tsbtbccn3388tct" || tsbt == "tsbtbccn33881tct" || tsbt == "tsbtbccn33882tct" || tsbt == "tsbtbccn341118tct" || tsbt == "tsbtbccn341128tct")
                baocaocn131.loadbchitietcn(ngaychungtu, tsbt, donvicongno, view, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            else if (tsbt == "tsbtbccn131tdv" || tsbt == "tsbtbccn131" || tsbt == "tsbtbccn131tct")
            {
                DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in chi tiết công nợ, 'No' để in biên bản xác nhận nợ.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    baocaocn131.loadbchitietcn(ngaychungtu, tsbt, donvicongno, view, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
                else if (dr == DialogResult.No)
                {
                    Frm_nhapxuat F = new Frm_nhapxuat();
                    F.gettsbt(tsbt.Replace("tdv", "").Replace("tct","") + "bienbanxacnhanno");
                    F.getngay(ngaychungtu);
                    F.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã").ToString());

                    if (view.GetRowCellValue(view.FocusedRowHandle, "Nợ cuối kỳ").ToString() != "")
                        F.getcongty(view.GetRowCellValue(view.FocusedRowHandle, "Nợ cuối kỳ").ToString());
                    else if (view.GetRowCellValue(view.FocusedRowHandle, "Có cuối kỳ").ToString() != "")
                        F.getcongty("-" + view.GetRowCellValue(view.FocusedRowHandle, "Có cuối kỳ").ToString());

                    if (tsbt == "tsbtbccn131")
                    {
                        if (gen.GetString("select Province from Stock where StockID='" + donvicongno + "'") != "CT")
                            F.getkho(donvicongno);
                    }

                    F.ShowDialog();
                }
            }
            else if (tsbt == "131tndntcthmn")
            {
                try
                {
                    string donvi = gen.GetString("select BranchID from Branch with (NOLOCK) where BranchCode='" + view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString().Substring(0, 2) + "'");
                    //baocaocn131.loadbchitietcn(denngay, "tsbtbccn131tdv", donvi, view, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
                    Frm_rpcongno rp = new Frm_rpcongno();
                    rp.getngaychungtu(ngaychungtu);
                    rp.getkho(donvi);
                    rp.getuserid(userid);
                    rp.gettenkho(view.GetRowCellValue(view.FocusedRowHandle, "Mã").ToString());
                    rp.gettsbt("tsbtbangkeluongthanhtoanlichsu");
                    rp.Show();
                }
                catch { }
            }
            else if (tsbt == "tsbtbccn141" || tsbt == "tsbtbccn141tct")
                baocaocn131.loadbchitietcn(ngaychungtu, tsbt, branchid, view, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            else if (tsbt == "tsbtbcptcn131" || tsbt == "tsbtbcptcn131tdv" || tsbt == "tsbtbcptcn131tct")
                baocaocn131.loadbchitietptcn(ngaychungtu, tsbt, donvicongno, view);

            else if (tsbt == "tsbtbccn31188" || tsbt == "tsbtbccn3388")
                baocaocn131.loadbchitietlai(ngaychungtu, tsbt, donvicongno, view);
            else if (tsbt == "tsbtthtkskt")
            {
                Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
                F.getngaychungtu(ngaychungtu);
                F.gettsbt(tsbt);
                F.getview(view);
                F.ShowDialog();
            }
            else if (tsbt == "tsbtthtksc")
                thtk.loadchitietsctong(ngaychungtu, tsbt, view);
            else if (tsbt == "tsbtthtktq")
            {
                Frm_ngay F = new Frm_ngay();
                F.getngaychungtu(ngaychungtu);
                F.gettsbt(tsbt);
                F.getview(view);
                F.ShowDialog();
            }
            else if (tsbt == "tsbtpncknb") cknb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtpncknblpg") cknblpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtpncknbvlpg") cknbvlpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtpnhgb") xhgb.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);
            else if (tsbt == "tsbtpnhgblpg") xhgblpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt);
            else if (tsbt == "tsbtpnhgbvlpg") xhgbvlpg.tsbtpck("1", this, view, roleid, subsys, ngaychungtu, userid, branchid, tsbt, khach, hang);


            else if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu" || tsbt == "tsbtbctktttdv" || tsbt=="tsbtbkclgdgv")
                try
                {
                    bctk.inthekho(ngaychungtu, tsbt, donvicongno, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid, hang, khach);
                }
                catch { }
            else if (tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctktttt")
                bctkv.inthekho(ngaychungtu, tsbt, donvicongno, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid);
            else if (tsbt == "tsbtbctkthtct")
                bctk.intonghop(ngaychungtu, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", tsbt);
            else if (tsbt == "tsbtpxk" || tsbt == "tsbtpxkct")
                thtk.loadnhatkynhaphang(view.GetRowCellValue(view.FocusedRowHandle, "Ngày chứng từ").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Ngày chứng từ").ToString(), tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());
            else if (tsbt == "tsbtddh" && view.GetRowCellValue(view.FocusedRowHandle, "Xuất").ToString() == "True")
                thtk.loadnhatkynhaphang(view.GetRowCellValue(view.FocusedRowHandle, "Xuất kho").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Xuất kho").ToString(), "tsbtpxkct", gen.GetString("select b.RefID from DDH a with (NOLOCK), INOutward b with (NOLOCK) where a.RefIDInOutward=b.RefNo and a.RefID='" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "'"), view.GetRowCellValue(view.FocusedRowHandle, "Kho nhận").ToString());
            else if (tsbt == "tsbthdbh")
            {
                if (dem == -1)
                {
                    DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in bảng kê đầy đủ, 'No' để in bảng kê tóm tắt.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                        thtk.loadchitiethoadon(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Hóa đơn").ToString(), tsbt + "chitiet", view.GetRowCellValue(view.FocusedRowHandle, "Ngày chứng từ").ToString());
                    else if (dr == DialogResult.No)
                        //thtk.loadnhatkynhaphang(view.GetRowCellValue(view.FocusedRowHandle, "Ngày chứng từ").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Ngày chứng từ").ToString(), tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());
                        thtk.loadchitiethoadon(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Hóa đơn").ToString(), tsbt + "chitiettomtat", view.GetRowCellValue(view.FocusedRowHandle, "Ngày chứng từ").ToString());
                }
                else
                {
                    thtk.loadnhatkybanhangchitiet(ngaychungtu, tsbt, hoadon, dem);
                    dem = -1;
                }
            }
            else if (tsbt == "tsbtbcthlthh")
                bctk.inthekholaigop(ngaychungtu, tsbt, donvicongno, view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng").ToString());

            else if (tsbt == "barthkqkdhtdln")
            {
                string dulieu = view.GetRowCellValue(view.FocusedRowHandle, "Mã ngành").ToString(), name = view.GetRowCellValue(view.FocusedRowHandle, "Mã ngành").ToString();
                if (name != "")
                    name = gen.GetString("select InventoryCategoryName from InventoryItemCategory with (NOLOCK) where InventoryCategoryCode='" + dulieu + "'");
                thtk.loadchitietskt(ngaychungtu, "tsbtbkthcptn", "", "", dulieu, name);
            }
            else if (tsbt == "tsbtbkthtncp")
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "Tên nhóm").ToString();
                string dulieu = view.GetRowCellValue(view.FocusedRowHandle, "Nhóm").ToString();
                thtk.loadchitietskt(denngay, "tsbtbkthtncp", userid, tungay, dulieu, name);
            }
        }

        private void babccn131tdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn131tdv");
            u.ShowDialog();
        }

        private void babsbtchondonvi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tsbt == "tsbtbccn131" || tsbt == "tsbtbccn331" || tsbt == "tsbtbcptcn131" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn131tdv" || tsbt == "tsbtbccn331tdv" || tsbt == "tsbtbcptcn131tdv" || tsbt == "tsbtbccn1313tdv" || tsbt == "tsbtbccn3313tdv" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388")
            {
                Frm_chonkho u = new Frm_chonkho();
                if (tsbt == "tsbtbccn131" || tsbt == "tsbtbccn131tdv" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1388")
                    u.myac = new Frm_chonkho.ac(refreshbccn131);
                else if (tsbt == "tsbtbccn331" || tsbt == "tsbtbccn331tdv")
                    u.myac = new Frm_chonkho.ac(refreshbccn131);
                else if (tsbt == "tsbtbcptcn131" || tsbt == "tsbtbcptcn131tdv")
                    u.myac = new Frm_chonkho.ac(refreshbcptcn131);
                else if (tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn3313")
                    u.myac = new Frm_chonkho.ac(refreshbccn131);
 
                u.getngaychungtu(ngaychungtu);
                u.getuser(userid);
                u.getform(this);
                u.gettsbt(tsbt);
                u.ShowDialog();
            }
            else if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu" || tsbt == "tsbtbctktttdv" || tsbt == "tsbtbctkthdtndn" || tsbt == "tsbtbctktndntdv" || tsbt == "tsbtbctkvlpgtttdv" || tsbt == "tsbtbctktttt" || tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctktttttdv")
            {
                Frm_chonkho u = new Frm_chonkho();
                if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktttdv" || tsbt == "tsbtbctktslcu")
                    u.myac = new Frm_chonkho.ac(refreshtonkho);

                else if (tsbt == "tsbtbctkthdtndn" ||tsbt == "tsbtbctktndntdv")
                    u.myac = new Frm_chonkho.ac(refreshtonkhotndn);


                else if (tsbt == "tsbtbctkvlpgtttdv" || tsbt=="tsbtbctkvlpgtt")
                    u.myac = new Frm_chonkho.ac(refreshtonkhovo);

                else if (tsbt == "tsbtbctktttt" || tsbt == "tsbtbctktttttdv")
                    u.myac = new Frm_chonkho.ac(refreshtonkhothucte);

                u.getngaychungtu(ngaychungtu);
                u.getuser(userid);
                u.getform(this);
                u.gettsbt(tsbt);
                u.ShowDialog();
            }
            
        }

        private void babccn131tct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn131tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void babcptnqh131_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbcptcn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbcptcn131");
            u.ShowDialog();
        }

        private void babcptnqh131tdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbcptcn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbcptcn131tdv");
            u.ShowDialog();
        }

        private void babcptcn131tct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            tsbt = "tsbtbcptcn131tct";
            refreshbaocao(tsbt);
            refreshbcptcn131();
            SplashScreenManager.CloseForm();
        }

        private void babccn331_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn331");
            u.ShowDialog();
        }

        private void babccn331tdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn331tdv");
            u.ShowDialog();
        }

        private void babccn331tct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn331tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void bapnhkm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnhkm";
            refresh("SAmnuBusinessSASaleOrder");
            view.ViewCaption = "   Phiếu nhập hàng khuyến mãi";
            refreshpnhkm();
        }

        private void bapxhkm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxhkm";
            refresh("SAmnuBusinessSAInvoiceWithoutCashList");
            view.ViewCaption = "   Phiếu xuất hàng khuyến mãi";
            refreshpxhkm();
        }

        private void babccn1313_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn1313");
            u.ShowDialog();
        }

        private void babccn1313tdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn1313tdv");
            u.ShowDialog();
        }

        private void babccn1313tct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn1313tct";
            refreshbccn131();
        }

        private void babccn3313_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn3313");
            u.ShowDialog();
        }

        private void babccn3313tdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn3313tdv");
            u.ShowDialog();
        }

        private void babccn3313tct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn3313tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void babccn141_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn141";
            refreshbaocao(tsbt);
            donvicongno = gen.GetString("select StockBranch from Branch with (NOLOCK) where BranchID='" + branchid + "'");
            refreshbccn131();
        }

        private void babccn141tct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn141tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void babccn31188_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn1388");
            u.ShowDialog();
        }

        private void babccn3388_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn3388";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void bathtkskt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtthtkskt";
            refreshbaocao(tsbt);
            refreshthtk();
        }

        private void bathtksc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtthtksc";
            refreshbaocao(tsbt);
            refreshthtk();
        }

        private void bathtktq_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtthtktq";
            refreshbaocao(tsbt);
            refreshthtk();
        }

        private void babctcth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtbctcth");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void bapb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void lvpq_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(panelControl1.Visible==true)
                panelControl1.Visible = false;
            else
                panelControl1.Visible = true;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            view.ShowFindPanel();
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("SYSmnuSystemOption");
            Frm_center F = new Frm_center();
            F.ShowDialog();
        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("SYSmnuSystemAuditingLog");
            tsbt = "tsbtnktc";
            view.ViewCaption = "   Nhật ký truy cập - Tháng " + String.Format("{0: MM}", DateTime.Parse(ngaychungtu)) + " năm " + DateTime.Parse(ngaychungtu).Year.ToString();
            thue.loadlog(lvpq, view, "select * from MSC_Auditting_Log with (NOLOCK) where Month(Time)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(Time)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' order by Time");
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbthdxhgb";
            refresh("PUmnuBusinessPUReceiptInvoiceList");
            view.ViewCaption = "   Hóa đơn xuất hàng gửi bán";
            refreshhdxhgb();
        }

        private void bapb_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryDepartment");
            Frm_chart F = new Frm_chart();
            F.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt="tsbthdkh";
            refresh("CT");
            view.ViewCaption = "   Hợp đồng";
            refreshhdkh();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryAccountingObjectGroup");
        }

        private void barButtonItem9_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DIpopDictionaryPayroll");
        }

        private void baccdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryToolItem");
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DIpopDictionaryShareHolder");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryFixedAssetCategory");
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_iistock F = new Frm_iistock();
            F.getuser(userid);
            F.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryExpense");
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryBank");
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryJob");
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryBankInfo");
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryCreditCard");
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh("DImnuDictionaryInventoryItemCategoryTax");
        }

        private void battt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_import F = new Frm_import();
            F.getngay(ngaychungtu);
            F.getuser(userid);
            F.getkhach(khach);
            F.gethang(hang);
            F.ShowDialog();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bapncknb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpncknb";
            view.ViewCaption = "   Phiếu nhập chuyển kho nội bộ";
            refresh("3");
            refreshpncknb();
        }

        private void bapncknblpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpncknblpg";
            view.ViewCaption = "   Phiếu nhập chuyển kho nội bộ LPG";
            refresh("S07a-DN");
            refreshpncknblpg();
        }

        private void bapncknbvlpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpncknbvlpg";
            view.ViewCaption = "   Phiếu nhập chuyển kho nội bộ vỏ LPG";
            refresh("S07-DN");
            refreshpncknbvlpg();
        }

        private void bapnhgb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnhgb";
            view.ViewCaption = "   Phiếu nhập nhập hàng gửi bán";
            refresh("S03a1-DN");
            refreshpnhgb();
        }

        private void bapnhgblpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnhgblpg";
            view.ViewCaption = "   Phiếu nhập nhập hàng gửi bán LPG";
            refresh("S03a2-DN");
            refreshpnhgblpg();
        }

        private void bapnhgbvlpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnhgbvlpg";
            view.ViewCaption = "   Phiếu nhập nhập hàng gửi bán vỏ LPG";
            refresh("DetailMoneyInFundByExchange");
            refreshpnhgbvlpg();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbkhhnd");
            u.ShowDialog();
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbkhhxd");
            u.ShowDialog();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaothue bc = new baocaothue();
            bc.loadthueloi(ngaychungtu, "tsbtthuedauvao", "", "intonghop", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid);
            Frm_chonkhotonghoptaikhoan u = new Frm_chonkhotonghoptaikhoan();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtthuedauvao");
            u.ShowDialog();        
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaothue bc = new baocaothue();
            bc.loadthueloi(ngaychungtu, "tsbtthuedaura", "", "intonghop", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid);
            Frm_chonkhotonghoptaikhoan u = new Frm_chonkhotonghoptaikhoan();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtthuedaura");
            u.ShowDialog();
        }

        private void babkthphi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //thue.loadbkthphi(ngaychungtu, "tsbtbkthcp", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG",userid);
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbkthcp");
            F.ShowDialog();
        }

        private void babkthptk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbkthcptheokho");
            F.ShowDialog();
        }

        private void bathpnxtt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtthpnxtt");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void bathpnxdc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtthpnxdc");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void bathkqkd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtthkqkd");
            F.ShowDialog();
        }

        private void badtvcp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*baocaothue bct = new baocaothue();
            bct.loaddoanhthuvachiphi(ngaychungtu, "tsbtthdtvcp", userid);*/
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtthdtvcp");
            F.ShowDialog();
        }

        private void barbctctt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbctctt");
            F.ShowDialog();
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_changepass F = new Frm_changepass();
            F.getuser(userid);
            F.ShowDialog();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtghiso");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtboghi");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void navBarItem43_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("sctbhtkhvhd");
            F.ShowDialog();
        }

        private void navBarItem17_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snkxcnb");
            F.ShowDialog();
        }

        private void navBarItem24_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snkncnb");
            F.ShowDialog();
        }

        private void navBarItem26_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("131tndn");
            F.ShowDialog();
        }

        private void navBarItem54_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("131tndnbh");
            F.ShowDialog();
        }

        private void navBarItem60_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("331tndnbh");
            F.ShowDialog();
        }

        private void navBarItem64_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bangkehoadondenhan");
            F.ShowDialog();
        }

        private void navBarItem59_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkptttkh");
            F.ShowDialog();
        }

        private void navBarItem62_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkpsnkh");
            F.ShowDialog();
        }

        private void navBarItem32_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("331tndn");
            F.ShowDialog();
        }

        private void navBarItem31_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("331tndntdv");
            F.ShowDialog();
        }
        private void navBarItem52_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("331tndntct");
            F.ShowDialog();
        }

        private void navBarItem27_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("131tndntdv");
            F.ShowDialog();
        }
        private void navBarItem68_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("131tndntdvth");
            F.ShowDialog();
        }
        private void navBarItem82_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("131tndntdvthtk");
            F.ShowDialog();
        }
        private void navBarItem28_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("131tndntct");
            F.ShowDialog();
        }

        private void navBarItem19_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkhdbvt");
            F.ShowDialog();
        }

        private void navBarItem18_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bknmvt");
            F.ShowDialog();
        }

        private void navBarItem20_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snkxcnbtc");
            F.ShowDialog();
        }

        private void navBarItem15_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcntt");
            F.ShowDialog();
        }

        private void navBarItem47_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcntttdv");
            F.ShowDialog();
        }

        private void navBarItem44_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "tsbtpnktt";
            refresh("INmnuBusinessINInwardList");
            view.ViewCaption = "   Phiếu nhập kho hàng hóa";
            refreshpnktt();
        }

        private void navBarItem76_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "tsbtpxkhg";
            refresh("INmnuBusinessINInwardList");
            view.ViewCaption = "   Phiếu xuất kho hàng gửi khách hàng";
            refreshpxkhgkh();
        }

        private void navBarItem75_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "tsbtpdctk";
            refresh("INmnuBusinessINInwardList");
            view.ViewCaption = "   Phiếu điều chỉnh tồn kho";
            refreshpdctk();
        }
        
        private void navBarItem46_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxnhtdv");
            F.ShowDialog();
        }

        private void navBarItem22_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcnttct");
            F.ShowDialog();
        }

        private void navBarItem16_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("thsdhd");
            F.ShowDialog();
        }

        private void navBarItem12_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snkxk");
            F.ShowDialog();
        }

        private void navBarItem51_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            gen.ExcuteNonquery("insert into MSC_Auditting_Log(EventID,LoginName,ComputerName,Time,PermissionTypeAlias,Reference) values(newid(),'" + gen.GetString("select UserName from MSC_User with (NOLOCK) where UserID='" + userid + "'").ToString() + "','" + System.Environment.MachineName + "',GETDATE(),N'Xem','KETQUATIEUTHU')");
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("kqtthhtt");
            F.ShowDialog();
        }

        private void navBarItem23_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snkxkct");
            F.ShowDialog();
        }

        private void navBarItem30_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("1313tndn");
            F.ShowDialog();
        }

        private void navBarItem42_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("1313tndntdv");
            F.ShowDialog();
        }

        private void navBarItem25_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("1313tndntct");
            F.ShowDialog();
        }

        private void navBarItem38_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("3313tndn");
            F.ShowDialog();
        }

        private void navBarItem37_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("3313tndntdv");
            F.ShowDialog();
        }

        private void navBarItem36_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("3313tndntct");
            F.ShowDialog();
        }

        private void navBarItem35_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("141tndntct");
            F.ShowDialog();
        }

        private void navBarItem45_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "tsbtptc";
            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Phiếu thu chi";
            refreshptctm();
        }

        private void navBarItem34_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("1388tndn");
            F.ShowDialog();
        }

        private void navBarItem33_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("1388tndntct");
            F.ShowDialog();
        }

        private void navBarItem40_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("3388tndn");
            F.ShowDialog();
        }

        private void navBarItem41_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("3388tndntct");
            F.ShowDialog();
        }

        private void navBarItem65_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("341118tndntct");
            F.ShowDialog();
        }

        private void navBarItem66_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("341128tndntct");
            F.ShowDialog();
        }

        private void navBarItem53_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("3388tndntcttl");
            F.ShowDialog();
        }

        private void navBarItem21_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbx");
            F.ShowDialog();
        }

        private void navBarItem99_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxthhh");
            F.ShowDialog();
        }

        private void navBarItem97_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxv");
            F.ShowDialog();
        }

        private void navBarItem86_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpvcbh");
            F.ShowDialog();
        }

        private void navBarItem83_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxth");
            F.ShowDialog();
        }

        private void navBarItem89_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxthnv");
            F.ShowDialog();
        }

        private void navBarItem94_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkthbhtnvkd");
            F.ShowDialog();
        }


        private void navBarItem93_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkthhkm");
            F.ShowDialog();
        }

        private void navBarItem90_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkthhhtx");
            F.ShowDialog();
        }

        private void navBarItem91_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bctkhhtn");
            F.ShowDialog();
        }

        private void navBarItem92_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "bccntnh";
            Frm_reportmain F = new Frm_reportmain();
            F.getform(this);
            F.myac = new Frm_reportmain.ac(refreshcongnotonghop);
            F.getngaychungtu(ngaychungtu);
            F.gettsbt(tsbt);
            F.ShowDialog();
            panelControl1.Visible = false;
        }

        private void refreshcongnotonghop()
        {
            view.ViewCaption = "   Báo cáo công nợ quá hạn chi tiết tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
            thtk.loadptcn(denngay, userid, lvpq, view);
        }

        private void navBarItem49_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxxck");
            F.ShowDialog();
        }

        private void navBarItem98_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxxckv");
            F.ShowDialog();
        }

        private void navBarItem84_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxnck");
            F.ShowDialog();
        }

        private void navBarItem96_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxnckv");
            F.ShowDialog();
        }

        private void navBarItem88_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpvcnck");
            F.ShowDialog();
        }
        private void navBarItem87_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpvcxck");
            F.ShowDialog();
        }
        private void navBarItem70_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "tsbtbctktslcu";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkho);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }

        private void navBarItem71_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "bklstcv";
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            thtk.loadthechan(userid, lvpq, view);
            panelControl1.Visible = false;
            SplashScreenManager.CloseForm();
        }

        private void navBarItem72_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbccnvkhth");
            F.ShowDialog();
        }

        private void navBarItem81_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbccnvkhtk");
            F.ShowDialog();
        }

        private void navBarItem73_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbccnvnccth");
            F.ShowDialog();
        }

        private void navBarItem13_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snknk");
            F.ShowDialog();
        }

        private void navBarItem29_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.getform(this);
            F.gettsbt("sctbhtkhvmh");
            F.ShowDialog();
        }

        private void navBarItem69_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "sctbhtkhvmhth";
            Frm_reportmain F = new Frm_reportmain();
            F.getform(this);
            F.myac = new Frm_reportmain.ac(refreshsanluong);
            F.getngaychungtu(ngaychungtu);
            F.gettsbt(tsbt);
            F.ShowDialog();
            panelControl1.Visible = false;
        }

        private void refreshsanluong()
        {
            view.ViewCaption = "   Báo cáo sản lượng từ ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            thtk.loadbaocaosanluong(branchid, tungay, denngay, tsbt, userid, lvpq, view);
        }

        private void navBarItem67_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbctkbcn");
            F.ShowDialog();
        }

        private void navBarItem74_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbctkbcnvo");
            F.ShowDialog();
        }

        private void navBarItem80_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbctkbcnvotndn");
            F.ShowDialog();
        }

        private void navBarItem55_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcthdbh");
            F.ShowDialog();
        }

        private void navBarItem57_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkpxbhttm");
            F.ShowDialog();
        }
        private void navBarItem61_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkpxhtdnb");
            F.ShowDialog();
        }
        private void navBarItem78_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxhgncc");
            F.ShowDialog();
        }
        private void navBarItem79_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkthpsv");
            F.ShowDialog();
        }
        private void navBarItem48_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkxktkhvmh");
            F.ShowDialog();
        }

        private void navBarItem58_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkxktmhpx");
            F.ShowDialog();
        }

        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snkbh");
            F.ShowDialog();
        }
        private void navBarItem6_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snkmh");
            F.ShowDialog();
        }
        private void navBarItem5_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("sctmhtmh");
            F.ShowDialog();
        }

        private void navBarItem7_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("lvphtbhtnvvsl");
            F.getkhach(khach);
            F.ShowDialog();
        }

        private void navBarItem4_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxnh");
            F.ShowDialog();
        }

        private void navBarItem95_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpbxnhv");
            F.ShowDialog();
        }

        private void navBarItem14_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbctktttndntaidv");
            u.ShowDialog();
        }

        private void navBarItem85_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbctkhgtttndntaidv");
            u.ShowDialog();
        }
        private void navBarItem77_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bchgkh");
            F.ShowDialog();
        }

        private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "tsbtbctktttt";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkhothucte);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }
        private void navBarItem3_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "tsbtbctktttttdv";
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.myac = new Frm_chonkho.ac(refreshtonkhothucte);
            u.getform(this);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }
        private void navBarItem8_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
                tsbt = "tsbtbctktttct";
                refreshbaocao(tsbt);
                refreshtonkhothucte();
            SplashScreenManager.CloseForm();
        }

        private void navBarItem9_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbctktttndn");
            u.ShowDialog();
        }

        private void navBarItem50_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbctktttndntpxk");
            u.ShowDialog();
        }

        private void navBarItem10_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            u.gettsbt("tsbtbctktttndntdv");
            u.ShowDialog();
        }
        private void navBarItem11_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.getuser(userid);
            u.getngaychungtu(ngaychungtu);
            if (gen.GetString("select CompanyTaxCode from Center with (NOLOCK)") == "")
                u.gettsbt("tsbtbctktttndnhgtct");
            else
                u.gettsbt("tsbtbctktttndntct");
            u.ShowDialog();
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbthdbhkpx";
            refresh("SAmnuBusinessSAReturnAndDiscount");
            view.ViewCaption = "   Hóa đơn bán hàng kiêm phiếu xuất";
            refreshhdbhkpx();
        }

        private void bar3388tdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn3388tdv");
            u.ShowDialog();
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaothue bc = new baocaothue();
            bc.loadthueloi(ngaychungtu, "tsbtthuedauvao", "", "intonghop", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid);

            tsbt = "tsbthdmhkpn";
            refresh("SAmnuBusinessSAReturnAndDiscount");
            view.ViewCaption = "   Hóa đơn mua hàng kiêm phiếu nhập";
            refreshhdmhkpn();
        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxkct";

            Frm_nhapxuat F = new Frm_nhapxuat();
            F.getrole(userid);
            F.gettsbt(tsbt+"loi");
            F.getngay(ngaychungtu);
            F.ShowDialog();

            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Phiếu xuất kho có thuế";
            refreshpxkct();
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn1388tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn3388tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void navBarItem63_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtthbhtdtkh");
            F.ShowDialog();
        }

        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          Frm_reportmain F = new Frm_reportmain();
          F.getngaychungtu(ngaychungtu);
          F.getuser(userid);
          F.gettsbt("scth");
          F.ShowDialog();
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("sktth");
            F.ShowDialog();
        }

        private void bapxtdnb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxhtnb";
            refresh("SAmnuBusinessSASaleQuote");
            view.ViewCaption = "   Phiếu xuất hàng tiêu dùng nội bộ";
            refreshpxhtnb();
        }

        private void barpxhmtl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpxhmtl";
            refresh("SAmnuBusinessSAInvoiceWithCashList");
            view.ViewCaption = "   Phiếu xuất hàng mua trả lại";
            refreshpxhmtl();
        }

        private void barckkh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtckkh";
            refresh("DImnuDictionaryStock");
            view.ViewCaption = "   Các khoản khấu hao tháng " + DateTime.Parse(ngaychungtu).Month + " năm " + DateTime.Parse(ngaychungtu).Year;
            refreshckkh();
        }

        private void bartgp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbttgp";
            refresh("DImnuDictionaryStock");
            view.ViewCaption = "   Tăng giảm phí tháng " + DateTime.Parse(ngaychungtu).Month + " năm " + DateTime.Parse(ngaychungtu).Year;
            refreshtgp();
        }

        private void barctlv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("05/01/2016"))
            {
                XtraMessageBox.Show("Chức năng này tạm thời chỉ khả dụng từ tháng 05 năm 2016.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtctlv");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void barctkqkd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("05/01/2016"))
            {
                XtraMessageBox.Show("Chức năng này tạm thời chỉ khả dụng từ tháng 05 năm 2016.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtctkqkd");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void barkqkdth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("05/01/2016"))
            {
                XtraMessageBox.Show("Chức năng này tạm thời chỉ khả dụng từ tháng 05 năm 2016.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtkqkdth");
            F.ShowDialog();
        }

        private void barbcthmb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.gettsbt("tsbtbcthmb");
            F.getngaychungtu(ngaychungtu);
            F.ShowDialog();
        }

        private void barbktdnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_ngay F = new Frm_ngay();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtbktdng");
            F.ShowDialog();
        }

        private void barbkcpt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbkthcpthuan");
            F.ShowDialog();
        }

        private void barplbl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtplbl";
            refresh("CT");
            view.ViewCaption = "   Phụ lục - Bảo lãnh";
            refreshhdkh();
        }

        private void barbchmnkh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain u = new Frm_reportmain();
            u.myac = new Frm_reportmain.ac(refreshbccnhmn);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("131tndntcthmn");
            u.ShowDialog();
        }

        private void barddhdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtddh";
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.getrole(userid);
            F.gettsbt(tsbt);
            F.getngay(ngaychungtu);
            F.ShowDialog();

            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Đơn đặt hàng";
            refreshddh();
        }

        private void barcdh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtcdh";

            Frm_nhapxuat F = new Frm_nhapxuat();
            F.getrole(userid);
            F.gettsbt(tsbt);
            F.getngay(ngaychungtu);
            F.ShowDialog();

            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Chuyển đặt hàng";
            refreshddh();
        }

        private void baunc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtunc";
            refresh("BUmnuBUAllocation");
            view.ViewCaption = "   Ủy nhiệm chi";
            refreshunc();
        }

        private void barbctkbcn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbccnvkh");
            F.ShowDialog();
        }

        private void barvnhk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn341118tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void barvdhk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn341128tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void barcttk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("chitiettaikhoan");
            F.ShowDialog();
        }

        private void barbccnv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbccnvncc");
            F.ShowDialog();
        }

        private void barddhlpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtddhlpg";

            Frm_nhapxuat F = new Frm_nhapxuat();
            F.getrole(userid);
            F.gettsbt(tsbt);
            F.getngay(ngaychungtu);
            F.ShowDialog();


            giaban = gen.GetTable("select * from AccountingObjectInventoryItem with (NOLOCK) where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year + "'");

            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Đơn đặt hàng LPG";
            refreshddhlpg();
        }

        private void barthkqkd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtlaigopkinhdoanh");
            F.ShowDialog();
        }

        private void ddhtk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtddhtk";
            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Đơn đặt hàng tại kho";
            refreshddh();
        }

        private void barbcsltt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbcslbhtt";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void barbcsltq_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbcslbhtq";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void barbcdtsl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbcdtsl";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void bardskhm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtdskhm";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void bardskhkpsdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtdskhkpsdt";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void barbcdtlntt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbcdtlntt";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void barbcdtlntq_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbcdtlntq";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void barncthlthh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbcthlthh";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void barbcdtlnct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbcdtlnct";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt(tsbt);
            F.myac = new Frm_reportmain.ac(refreshbaocaonhanh);
            F.getform(this);
            F.ShowDialog();
        }

        private void barddhncc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtddhncc";
            refresh("INmnuBusinessINInwardList");
            view.ViewCaption = "   Đơn đặt hàng nhà cung cấp";
            refreshddhncc();
        }

        private void barButtonItem19_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn33881tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbccn33882tct";
            refreshbaocao(tsbt);
            refreshbccn131();
        }

        private void barpnkvtddh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtpnkvtddh";
            refresh("INmnuBusinessINAdjustmentList");
            view.ViewCaption = "   Phiếu nhập kho vỏ LPG theo đơn đặt hàng";
            refreshpnkvotddh();
        }

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaotonkho("6A4A46B0-5A60-45D2-B1C4-921B606160ED");
        }

        private void baocaotonkho(string kho)
        {
            string thang = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
            string nam = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();

            string thangtruoc = DateTime.Parse(DateTime.Now.ToString()).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(DateTime.Now.ToString()).AddMonths(-1).Year.ToString();

            string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
            string denngaydau = DateTime.Parse(DateTime.Parse(tungaydau).ToShortDateString()).AddSeconds(-1).ToString();

            string tungaycuoi = tungaydau;
            string denngaycuoi = DateTime.Parse(DateTime.Parse(DateTime.Now.ToString()).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt1.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt1.Columns.Add("Công ty", Type.GetType("System.Double"));
            dt1.Columns.Add("TL Công ty", Type.GetType("System.Double"));
            dt1.Columns.Add("Hàng gửi", Type.GetType("System.Double"));
            dt1.Columns.Add("TL hàng gửi", Type.GetType("System.Double"));
            dt1.Columns.Add("Tồn cuối", Type.GetType("System.Double"));
            dt1.Columns.Add("TL tồn cuối", Type.GetType("System.Double"));
            dt1.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt1.Columns.Add("Tên kho", Type.GetType("System.String"));
            dt1.Columns.Add("Số lượng đầu", Type.GetType("System.Double"));
            dt1.Columns.Add("Trọng lượng đầu", Type.GetType("System.Double"));

            string thangcu = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString()).Month.ToString();
            string namcu = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString()).Year.ToString();

            string thangtruoccu = DateTime.Parse(DateTime.Now.ToString()).AddMonths(-2).Month.ToString();
            string namtruoccu = DateTime.Parse(DateTime.Now.ToString()).AddMonths(-2).Year.ToString();

            string tungaydaucu = DateTime.Parse(thangcu + "/1/" + namcu).ToString();
            string denngaydaucu = DateTime.Parse(DateTime.Parse(tungaydaucu).ToShortDateString()).AddSeconds(-1).ToString();

            string tungaycuoicu = tungaydaucu;
            string denngaycuoicu = DateTime.Parse(DateTime.Parse(tungaydau).ToShortDateString()).AddSeconds(-1).ToString();
       
            gen.ExcuteNonquery("hamaco.dbo.baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoccu + "','" + namtruoccu + "','" + tungaydaucu + "','" + denngaydaucu + "','" + tungaycuoicu + "','" + denngaycuoicu + "','0'");
            DataTable temp = gen.GetTable("hamaco.dbo.baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','4'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt1.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[6] = temp.Rows[i][6];
                if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    dr[7] = temp.Rows[i][7];
                dr[8] = temp.Rows[i][8];
                dr[9] = temp.Rows[i][9];
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = temp.Rows[i][10];
                if (Double.Parse(temp.Rows[i][11].ToString()) != 0)
                    dr[11] = temp.Rows[i][11];
                dt1.Rows.Add(dr);
            }
            Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
            rp.gettenkho(gen.GetString("select StockCode+' - '+ StockName from hamaco.dbo.Stock with (NOLOCK) where StockID='" + kho + "'"));
            rp.getdata(dt1);
            rp.gettungay(String.Format("{0:dd/MM/yyyy}", DateTime.Now));
            rp.getdenngay(String.Format("{0:dd/MM/yyyy}", DateTime.Now));
            rp.gettsbt("tsbtbctktttndntaidvhanggui");
            rp.getkho(kho);
            rp.getngaychungtu("thucte");
            rp.Show();
        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaotonkho("5B72D913-AD6C-4EA0-86CE-67B62158AAAA");
        }

        private void babkthptn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbkthcptn");
            F.ShowDialog();
        }

        private void babkthtncp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain u = new Frm_reportmain();
            u.myac = new Frm_reportmain.ac(refreshbkthncp);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbkthtncp");
            u.ShowDialog();
        }

        private void bathmbtct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "bcslmb";
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("bcslmb");
            F.getform(this);
            F.myac = new Frm_reportmain.ac(refreshsanluongmuaban);              
            F.ShowDialog();
        }
        private void refreshsanluongmuaban()
        {
            view.ViewCaption = "   Báo cáo sản lượng mua bán từ ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            thtk.loadbaocaosanluongmuaban(tungay, denngay, tsbt, lvpq, view, userid);
        }

        private void barButtonItem49_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaotonkho("2D9824B9-2ECB-485C-B40F-3E29FB0CBE92");
        }

        private void bacsncc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtcsncc";
            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Chính sách nhà cung cấp";
            refreshcsncc();
        }

        private void barhtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_hangtieudung F = new Frm_hangtieudung();
            F.getngay(ngaychungtu);
            F.getuser(userid);
            F.gethang(hang);
            F.ShowDialog();
        }

        private void barbchtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("bchtd");
            F.getngay(ngaychungtu);
            F.ShowDialog();*/
        }

        private void barbccnhtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt("bccnhtd");
            F.getngay(ngaychungtu);
            F.ShowDialog();
        }

        private void barbctqtdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Frm_rpcongno F = new Frm_rpcongno();
            F.gettsbt("bctqtdvtk");
            F.getngaychungtu(ngaychungtu);
            F.getkho(branchid);
            F.ShowDialog();*/
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bctqtkho");
            F.ShowDialog();
        }

        private void barbctqtdvmain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_rpcongno F = new Frm_rpcongno();
            F.gettsbt("bctqtdv");
            F.getngaychungtu(ngaychungtu);
            F.getkho(branchid);
            F.ShowDialog();
            /*Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bctqtkho");
            F.ShowDialog();*/
        }

        private void bardckmckunilever_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("bardckmckunilever");
            F.ShowDialog();
        }

        private void barthkqkdhtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barthkqkdhtd";
            Frm_reportmain u = new Frm_reportmain();
            u.myac = new Frm_reportmain.ac(refreshdoanhthusanluong);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt(tsbt);
            u.ShowDialog();
        }

        private void refreshdoanhthusanluong()
        {
            view.ViewCaption = "   Báo cáo doanh thu sản lượng tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu)) + " - " + gen.GetString("select StockCode from Stock with (NOLOCK) where StockID='" + donvicongno + "'");
            thtk.loadbaocaotinhhinhkinhdoanh(ngaychungtu, donvicongno, lvpq, view, tsbt);
        }

        private void barkqkd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barthkqkdhtdln";
            view.ViewCaption = "   Báo cáo tình hình kết quả kinh doanh " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            thtk.loadbaocaotinhhinhkinhdoanhloinhuan(ngaychungtu, userid, lvpq, view);
        }

        private void barbchtkhtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbctkhtd");
            F.ShowDialog();            
        }

        private void barbcptncc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn1388");
            u.ShowDialog();
        }

        private void barbccnncchtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn331");
            u.ShowDialog();
        }

        private void bardckmckgd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("bardckmckgaudo");
            F.ShowDialog();
        }

        private void barbcthgnhh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barbcthgnhh";
            view.ViewCaption = "   Báo cáo tình hình giao nhận hàng hóa ngày " + String.Format("{0:dd/MM/yyyy}",DateTime.Parse(ngaychungtu).AddDays(-1));
            thtk.loadbaocaotinhhinhgiaonhan(ngaychungtu, userid, lvpq, view);
        }

        private void barbcthcp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbkthcptnrg");
            F.ShowDialog();
        }

        private void barbcdtthhtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barbcdtth";
            view.ViewCaption = "   Báo cáo doanh thu trả hàng tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            thtk.loadbaocaodoanhthutrahang(ngaychungtu, userid, lvpq, view);
        }

        private void barptncctct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barptncctct";
            view.ViewCaption = "   Báo cáo phải thu nhà cung cấp theo chương trình " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            thtk.loadkhuyenmainhangtieudung(lvpq, view, ngaychungtu);
        }

        private void barctlvhtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtctlv");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void barkqkdtnhtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtthkqkd");
            F.ShowDialog();
        }

        private void barbchtktnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bctk.loadbctkthdtndnbcnnganhhang(ngaychungtu, userid);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbcptncctn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkho u = new Frm_chonkho();
            u.myac = new Frm_chonkho.ac(refreshbccn131);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbccn1388");
            u.ShowDialog();
        }

        private void barbcdtsltn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barthkqkdhtd";
            view.ViewCaption = "   Báo cáo doanh thu sản lượng tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            thtk.loadbaocaotinhhinhkinhdoanh(ngaychungtu, userid, lvpq, view, "barthkqkdtn");
        }

        private void barbcthtncp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain u = new Frm_reportmain();
            u.myac = new Frm_reportmain.ac(refreshbkthncp);
            u.getngaychungtu(ngaychungtu);
            u.getuser(userid);
            u.getform(this);
            u.gettsbt("tsbtbkthtncp");
            u.ShowDialog();
        }
        private void refreshbkthncp()
        {
            thue.loadbkthphi(tungay, denngay, "tsbtbkthtncp", userid, lvpq, view);
        }

        private void barbangketrahang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            thtk.loadnhatkynhaphang(ngaychungtu, ngaychungtu, "tsbttrahang", userid, branchid);
        }

        private void barthkqkdndk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barthkqkdhtdln";
            view.ViewCaption = "   Báo cáo tình hình kết quả kinh doanh " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            thtk.loadbaocaotinhhinhkinhdoanhloinhuan(ngaychungtu, userid, lvpq, view);
        }

        private void barbkthcpdk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("tsbtbkthcptnrg");
            F.ShowDialog();
        }

        private void btgdclgv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtbkclgdgv";
            view.ViewCaption = "   Bảng kê giá điều chênh lệch giá vốn tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            thtk.bangkegiadieuchenhlechgiavon(ngaychungtu, userid, lvpq, view);
        }

        private void barthkhtt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbgd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_iistock F = new Frm_iistock();
            F.getuser(userid);
            F.gettsbt("barbgdh");
            F.getngay(ngaychungtu);
            F.ShowDialog();
        }

        private void barbccntnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barbccntnh";
            view.ViewCaption = "   Báo cáo công nợ theo ngành tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            thtk.loadbaocaocongnotheonganh(ngaychungtu, userid, lvpq, view);
        }

        private void barButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaotonkho("490657CA-0760-4BC3-8065-F8AE8B212789");
        }

        private void bardhcl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbtddhcl";
            refresh("INmnuBusinessINOutwardList");
            view.ViewCaption = "   Đơn hàng chia lượng tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            refreshddhcl();
        }

        private void barbkckncc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "barbkckncc";
            view.ViewCaption = "   Bảng kê chiết khấu nhà cung cấp tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            thtk.loadbaocaosanluongchietkhau(ngaychungtu, userid, lvpq, view);
        }

        private void barctlvtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtctlvtn");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void bartanggiamphi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "tsbttgp";
            refresh("DImnuDictionaryStock");
            view.ViewCaption = "   Tăng giảm phí tháng " + DateTime.Parse(ngaychungtu).Month + " năm " + DateTime.Parse(ngaychungtu).Year;
            refreshtgp();
        }

        private void barbcsl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tsbt = "sctbhtkhvmhth";
            Frm_reportmain F = new Frm_reportmain();
            F.getform(this);
            F.myac = new Frm_reportmain.ac(refreshsanluongnhom);
            F.getngaychungtu(ngaychungtu);
            F.gettsbt(tsbt);
            F.ShowDialog();
            panelControl1.Visible = false;
        }
        private void refreshsanluongnhom()
        {
            view.ViewCaption = "   Báo cáo sản lượng từ ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(denngay));
            thtk.loadbaocaosanluong(branchid, tungay, denngay, tsbt+"nhom", userid, lvpq, view);
        }

        private void barctkqkdtt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("05/01/2016"))
            {
                XtraMessageBox.Show("Chức năng này tạm thời chỉ khả dụng từ tháng 05 năm 2016.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
            F.getngaychungtu(ngaychungtu);
            F.gettsbt("tsbtctkqkdtt");
            F.getuser(userid);
            F.ShowDialog();
        }

        private void barbctqtk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bctqtkho");
            F.ShowDialog();
        }

        private void navBarItem100_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bknckvlpg");
            F.ShowDialog();
        }

        private void navBarItem101_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkxckvlpg");
            F.ShowDialog();
        }

        private void navBarItem102_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bctkhhtnlpg");
            F.ShowDialog();
        }

        private void navBarItem103_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bctkhhtnvo");
            F.ShowDialog();
        }

        private void navBarItem105_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("snkxktx");
            F.ShowDialog();
        }

        private void barbctct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("barbctct");
            F.ShowDialog();
        }

        private void barbglpg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_iistock F = new Frm_iistock();
            F.getuser(userid);
            F.gettsbt("barbglpg");
            F.getngay(ngaychungtu);
            F.ShowDialog();
        }

        private void banctbot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainForm F = new MainForm();           
            F.Show();
        }

        private void lvpq_Click_1(object sender, EventArgs e)
        {

        }

        private void navBarItem106_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkcpk");
            F.ShowDialog();
        }

        private void navBarItem107_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkpxhtdnbdc");
            F.ShowDialog();
        }

        private void navBarItem108_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bchgkhkhach");
            F.ShowDialog();
        }

        private void navBarItem109_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            tsbt = "bkcthddtt";
            Frm_reportmain F = new Frm_reportmain();
            F.getform(this);
            F.myac = new Frm_reportmain.ac(refreshhoadonduocthanhtoan);
            F.getngaychungtu(ngaychungtu);
            F.gettsbt(tsbt);
            F.ShowDialog();
            panelControl1.Visible = false;
        }

        private void refreshhoadonduocthanhtoan()
        {
            view.ViewCaption = "   Bảng kê chi tiết hóa đơn được thanh toán tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(denngay));
            thtk.loadbkcthddtt(denngay, userid, lvpq, view);
        }

        private void barbccntdv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("131tndntdv");
            F.ShowDialog();
        }

        private void navBarItem110_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bctknxtt");
            F.ShowDialog();
        }

        private void navBarItem111_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(userid);
            F.gettsbt("bkthbhtnvkdlqh");
            F.ShowDialog();
        }
    }
}