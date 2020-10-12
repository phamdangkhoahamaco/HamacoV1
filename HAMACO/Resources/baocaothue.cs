using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraSplashScreen;

namespace HAMACO.Resources
{
    class baocaothue
    {
        gencon gen = new gencon();
        public void loadthue(string ngaychungtu, string tsbt, string donvi,string loai,string congty,string userid)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Ký hiệu", Type.GetType("System.String"));

            dt.Columns.Add("Số hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Ngày hóa đơn", Type.GetType("System.DateTime"));

            dt.Columns.Add("Tên người bán", Type.GetType("System.String"));
            dt.Columns.Add("Mã số thuế", Type.GetType("System.String"));

            dt.Columns.Add("Mặt hàng", Type.GetType("System.String"));

            dt.Columns.Add("Doanh số", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế", Type.GetType("System.String"));

            dt.Columns.Add("Thuế GTGT", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));

            dt.Columns.Add("Loại", Type.GetType("System.String"));
            dt.Columns.Add("Nhóm", Type.GetType("System.String"));

            dt.Columns.Add("Mẫu số", Type.GetType("System.String"));

            int T0 = 1;
            int T5 = 1;
            int T10 = 1;
            DataTable temp=new DataTable();
            if(tsbt=="tsbtthuedauvao")
                temp = gen.GetTable("tonghopthuedaura '" + thang + "','" + nam + "','" + loai + "','" + donvi + "','"+userid+"'");
            else
                temp = gen.GetTable("tonghopthuedauvao '" + thang + "','" + nam + "','" + loai + "','" + donvi + "','"+userid+"'");
             
            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    if (Double.Parse(temp.Rows[i][7].ToString()) == 0)
                    {
                        dr[0] = T0.ToString();
                        dr[11] = "Hàng hóa, dịch vụ chịu thuế suất GTGT 0%";
                        dr[12] = "1";
                        dr[7] = Double.Parse(temp.Rows[i][6].ToString());
                        T0++;
                    }
                    else if (Double.Parse(temp.Rows[i][7].ToString()) == 5)
                    {
                        dr[0] = T5.ToString();
                        dr[11] = "Hàng hóa, dịch vụ chịu thuế suất GTGT 5%";
                        dr[12] = "2";
                        dr[7] = Double.Parse(temp.Rows[i][6].ToString());
                        dr[8] = temp.Rows[i][7].ToString() + "%";
                        dr[9] = Double.Parse(temp.Rows[i][8].ToString());
                        T5++;
                    }
                    else if (Double.Parse(temp.Rows[i][7].ToString()) == 10)
                    {
                        dr[0] = T10.ToString();
                        dr[11] = "Hàng hóa, dịch vụ chịu thuế suất GTGT 10%";
                        dr[12] = "3";
                        dr[7] = Double.Parse(temp.Rows[i][6].ToString());
                        dr[8] = temp.Rows[i][7].ToString() + "%";
                        if (temp.Rows[i][8].ToString() != "")
                            dr[9] = Double.Parse(temp.Rows[i][8].ToString());
                        T10++;
                    }
                    if (temp.Rows[i][0].ToString() != "")
                        dr[1] = temp.Rows[i][0].ToString();
                    if (temp.Rows[i][1].ToString() != "")
                        dr[2] = temp.Rows[i][1].ToString();
                    if (temp.Rows[i][2].ToString() != "")
                        dr[3] = temp.Rows[i][2].ToString();
                    dr[4] = temp.Rows[i][3].ToString();
                    dr[5] = temp.Rows[i][4].ToString();
                    dr[6] = temp.Rows[i][5].ToString();
                    dr[10] = temp.Rows[i][9].ToString();
                    dr[13] = temp.Rows[i][10].ToString();
                    dt.Rows.Add(dr);
                }
                catch { }
            }
            
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getkho(loai);
            rp.gettenkho(donvi);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.gettenkh(congty);
            rp.getaccount(userid);
            rp.Show();
        }

        public void loadthueloi(string ngaychungtu, string tsbt, string donvi, string loai, string congty, string userid)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Ký hiệu", Type.GetType("System.String"));

            dt.Columns.Add("Số hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Ngày hóa đơn", Type.GetType("System.DateTime"));

            dt.Columns.Add("Tên người bán", Type.GetType("System.String"));
            dt.Columns.Add("Mã số thuế", Type.GetType("System.String"));

            dt.Columns.Add("Mặt hàng", Type.GetType("System.String"));

            dt.Columns.Add("Doanh số", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế", Type.GetType("System.String"));

            dt.Columns.Add("Thuế GTGT", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));

            dt.Columns.Add("Loại", Type.GetType("System.String"));
            dt.Columns.Add("Nhóm", Type.GetType("System.String"));

            dt.Columns.Add("Mẫu số", Type.GetType("System.String"));

            int T0 = 1;
            int T5 = 1;
            int T10 = 1;
            DataTable temp = new DataTable();

            if (tsbt == "tsbtthuedauvao")
                temp = gen.GetTable("tonghopthuedauraloi '" + thang + "','" + nam + "','" + loai + "','" + donvi + "','" + userid + "'");
            else
                temp = gen.GetTable("tonghopthuedauvaoloi '" + thang + "','" + nam + "','" + loai + "','" + donvi + "','" + userid + "'");

            if (temp.Rows.Count > 0)
            {
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    if (Double.Parse(temp.Rows[i][7].ToString()) == 0)
                    {
                        dr[0] = T0.ToString();
                        dr[11] = "Hàng hóa, dịch vụ chịu thuế suất GTGT 0%";
                        dr[12] = "1";
                        try
                        {
                            dr[7] = Double.Parse(temp.Rows[i][6].ToString());
                        }
                        catch { }
                        T0++;
                    }
                    else if (Double.Parse(temp.Rows[i][7].ToString()) == 5)
                    {
                        dr[0] = T5.ToString();
                        dr[11] = "Hàng hóa, dịch vụ chịu thuế suất GTGT 5%";
                        dr[12] = "2";
                        try
                        {
                            dr[7] = Double.Parse(temp.Rows[i][6].ToString());
                        }
                        catch { }
                        dr[8] = temp.Rows[i][7].ToString() + "%";
                        try
                        {
                            dr[9] = Double.Parse(temp.Rows[i][8].ToString());
                        }
                        catch { }
                        T5++;
                    }
                    else if (Double.Parse(temp.Rows[i][7].ToString()) == 10)
                    {
                        dr[0] = T10.ToString();
                        dr[11] = "Hàng hóa, dịch vụ chịu thuế suất GTGT 10%";
                        dr[12] = "3";
                        try
                        {
                            dr[7] = Double.Parse(temp.Rows[i][6].ToString());
                        }
                        catch { }
                        dr[8] = temp.Rows[i][7].ToString() + "%";
                        try
                        {
                            if (temp.Rows[i][8].ToString() != "")
                                dr[9] = Double.Parse(temp.Rows[i][8].ToString());
                        }
                        catch { }
                        T10++;
                    }
                    if (temp.Rows[i][0].ToString() != "")
                        dr[1] = temp.Rows[i][0].ToString();
                    if (temp.Rows[i][1].ToString() != "")
                        dr[2] = temp.Rows[i][1].ToString();
                    if (temp.Rows[i][2].ToString() != "")
                        dr[3] = temp.Rows[i][2].ToString();
                    dr[4] = temp.Rows[i][3].ToString();
                    dr[5] = temp.Rows[i][4].ToString();
                    dr[6] = temp.Rows[i][5].ToString();
                    dr[10] = temp.Rows[i][9].ToString();
                    dr[13] = temp.Rows[i][10].ToString();
                    dt.Rows.Add(dr);
                }

                Frm_rpcongno rp1 = new Frm_rpcongno();
                rp1.getdata(dt);
                rp1.getkho(loai);
                rp1.gettenkho(donvi);
                rp1.getngaychungtu(ngaychungtu);
                rp1.gettsbt(tsbt);
                rp1.gettenkh(congty);
                rp1.getaccount(userid);
                rp1.ShowDialog();
            }
        }


        public void loadthuetong(string ngaychungtu, string tsbt, string loai,string userid)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            dt.Columns.Add("Doanh thu", Type.GetType("System.Double"));
            dt.Columns.Add("Thuế suất", Type.GetType("System.String"));
            dt.Columns.Add("Thuế", Type.GetType("System.Double"));
            if (tsbt == "tsbtthuedauvao")
                temp = gen.GetTable("tonghopthuedaura '" + thang + "','" + nam + "','" + loai + "','','"+userid+"'");
            else
                temp = gen.GetTable("tonghopthuedauvao '" + thang + "','" + nam + "','" + loai + "','','"+userid+"'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][2];
                dr[3] = temp.Rows[i][3]+"%";
                dr[4] = temp.Rows[i][4];
                dt.Rows.Add(dr);
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getkho(loai);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.Show();
        }


        public void loadbkthphi(string ngaychungtu, string tsbt, string ngaydau,string userid)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            string thangtruoc = DateTime.Parse(ngaydau).Month.ToString();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền có", Type.GetType("System.Double"));
            dt.Columns.Add("Tài khoản tổng hợp", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));

            DataTable temp = new DataTable();

            if(tsbt=="tsbtbkthcpthuan")
                temp = gen.GetTable("bangketonghopphi '" + thang + "','" + nam + "','thuan', '" + userid + "'");
            else if (tsbt == "tsbtbkthcp")
                temp = gen.GetTable("bangketonghopphi '" + thang + "','" + nam + "','tong','" + userid + "'");
            else if (tsbt == "tsbtbkthcptndn")
                temp = gen.GetTable("bangketonghopphitndn '" + thangtruoc + "','" + thang + "','" + nam + "','tong','" + userid + "'");
            else if (tsbt == "tsbtbkthcpthuantndn")
                temp = gen.GetTable("bangketonghopphitndn '" + thangtruoc + "','" + thang + "','" + nam + "','thuan','" + userid + "'");
            else if (tsbt == "tsbtbkthcptheokhotndn")
                temp = gen.GetTable("bangketonghopphitndn '" + thangtruoc + "','" + thang + "','" + nam + "','kho', '" + userid + "'");
            else if (tsbt == "tsbtbkthcptn")
                temp = gen.GetTable("bangketonghopphitndn '" + thangtruoc + "','" + thang + "','" + nam + "','tongtn','" + userid + "'");
            else if (tsbt == "tsbtbkthcptnrg")
            {
                temp = gen.GetTable("bangketonghopphitndn '" + thangtruoc + "','" + thang + "','" + nam + "','tongtnrg','" + userid + "'");
                tsbt = "tsbtbkthcptn";
            }
            else
                temp = gen.GetTable("bangketonghopphi '" + thang + "','" + nam + "','kho', '" + userid + "'");            


            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2].ToString();
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                dr[4] = "Tài khoản tổng hợp: " + temp.Rows[i][4].ToString();
                if (tsbt == "tsbtbkthcptheokho" || tsbt == "tsbtbkthcptheokhotndn" || tsbt == "tsbtbkthcpthuan" || tsbt == "tsbtbkthcpthuantndn")
                    dr[5] = temp.Rows[i][5].ToString() + " - " + temp.Rows[i][6].ToString();
                dt.Rows.Add(dr);
            }


            Frm_rpthuchi rp = new Frm_rpthuchi();
            rp.getda(dt);
            rp.getrole(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.getcongty(userid);
            rp.gethoten(ngaydau);
            rp.Show();
            SplashScreenManager.CloseForm();
        }

        public void loadbkthphi(string tungay, string denngay, string tsbt, string userid, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            view.Columns.Clear();

            if (tsbt == "tsbtbkthtncp")
            {
                view.ViewCaption = "   Bảng kê nhóm chi phí từ ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay));
                lvpq.DataSource = gen.GetTable("bangketonghopbaocaonhanh '" + userid + "','" + tungay + "','" + denngay + "','nhomchiphi'");
            }

            view.Columns["Xi măng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Xi măng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Xi măng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Xi măng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Đá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đá"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Đá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Đá"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Cát"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Cát"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Cát"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Cát"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Nhớt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Nhớt"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Nhớt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Nhớt"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Mỡ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Mỡ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Mỡ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Mỡ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Xăng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Xăng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Xăng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Xăng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Dầu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Dầu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Dầu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Dầu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["LPG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["LPG"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["LPG"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["LPG"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Sơn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Sơn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Sơn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Sơn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Thép"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thép"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thép"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thép"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Đường"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đường"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Đường"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Đường"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Dầu ăn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Dầu ăn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Dầu ăn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Dầu ăn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Gấu đỏ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Gấu đỏ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Gấu đỏ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Gấu đỏ"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Unilever"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Unilever"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Unilever"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Unilever"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tổng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsBehavior.Editable = false;
            view.OptionsView.ShowFooter = true;
            view.Columns[0].Width = 50;
            view.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns[1].Width = 200;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            SplashScreenManager.CloseForm();
        }

        public void loaddoanhthuvachiphi(string ngaychungtu, string ngaydau, string userid)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaydau).Month.ToString();     
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            dt.Columns.Add("Doanh thu", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));
            dt.Columns.Add("Chênh lệch", Type.GetType("System.Double"));           

            DataTable temp = new DataTable();
            temp = gen.GetTable("tonghopdoanhthuvachiphi '"+thangtruoc+"','"+nam+"','"+thang+"','"+nam+"','"+userid+"'");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[3] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[4] = temp.Rows[i][4].ToString();
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[5] = temp.Rows[i][5].ToString();
                dt.Rows.Add(dr);
            }

            Frm_rpthuchi rp = new Frm_rpthuchi();
            rp.getda(dt);
            rp.getrole(ngaychungtu);
            rp.gethoten(ngaydau);
            rp.gettsbt("tsbtthdtvcp"); 
            rp.getcongty(userid);
            rp.Show();
            SplashScreenManager.CloseForm();
        }

        public void loadbangcandoiketoan(string ngaychungtu, string tsbt, string userid,string tungay)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(tungay).Month.ToString();
            string namdauky = DateTime.Parse(ngaychungtu).AddYears(-1).Year.ToString();
            DataTable dt = new DataTable();
           
           
            dt.Columns.Add("Chỉ tiêu", Type.GetType("System.String"));
            dt.Columns.Add("Mã số", Type.GetType("System.String"));
            dt.Columns.Add("Số cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Số đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Nhóm 1", Type.GetType("System.String"));
            dt.Columns.Add("Mã số 1", Type.GetType("System.String"));
            dt.Columns.Add("Thuyết minh", Type.GetType("System.String"));
            dt.Columns.Add("Nhóm 2", Type.GetType("System.String"));
            dt.Columns.Add("Mã số 2", Type.GetType("System.String"));
            dt.Columns.Add("Nhóm 3", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhóm 3", Type.GetType("System.String"));
            dt.Columns.Add("Mã số 3", Type.GetType("System.String"));
            dt.Columns.Add("Thuyết minh chỉ tiêu", Type.GetType("System.String"));
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Cuối kỳ", Type.GetType("System.String"));
            dt.Columns.Add("Đầu kỳ", Type.GetType("System.String"));

            DataTable temp = new DataTable();
            if (DateTime.Parse(ngaychungtu).Year >= 2015)
            {
                temp = gen.GetTable("tonghopbangcandoiketoan '" + ngaychungtu + "','" + thangtruoc + "','" + thang + "','" + nam + "','12','" + namdauky + "'");

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    {
                        if (Double.Parse(temp.Rows[i][2].ToString()) < 0)
                        {
                            dr[14] = "(" + String.Format("{0:n0}", 0 - Double.Parse(temp.Rows[i][2].ToString())) + ")";
                        }
                        else
                        {
                            dr[14] = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                        }
                        if (i != 28 && i != 29 && i != 31 && i != 32 && i != 34 && i != 35 && i != 77 && i != 78 && i != 89 && i != 90)
                            dr[2] = temp.Rows[i][2].ToString();

                    }
                    else
                    {
                        dr[14] = "-";
                    }
                    if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    {
                        if (Double.Parse(temp.Rows[i][3].ToString()) < 0)
                        {
                            dr[15] = "(" + String.Format("{0:n0}", 0 - Double.Parse(temp.Rows[i][3].ToString())) + ")";
                        }
                        else
                        {
                            dr[15] = String.Format("{0:n0}", Double.Parse(temp.Rows[i][3].ToString()));
                        }
                        if (i != 28 && i != 29 && i != 31 && i != 32 && i != 34 && i != 35 && i != 77 && i != 78 && i != 89 && i != 90)
                            dr[3] = temp.Rows[i][3].ToString();
                    }
                    else
                    {
                        dr[15] = "-";
                    }
                    dr[4] = temp.Rows[i][4].ToString();
                    dr[5] = temp.Rows[i][5].ToString();
                    dr[6] = temp.Rows[i][6].ToString();
                    dr[7] = temp.Rows[i][7].ToString();
                    dr[8] = temp.Rows[i][8].ToString();
                    dr[9] = temp.Rows[i][9].ToString();
                    dr[10] = temp.Rows[i][10].ToString();
                    dr[11] = temp.Rows[i][11].ToString();
                    dr[12] = temp.Rows[i][12].ToString();
                    dr[13] = temp.Rows[i][13].ToString();
                    dt.Rows.Add(dr);
                    if (i == 19)
                    {
                        for (int j = 0; j < 18; j++)
                        {
                            DataRow dr1 = dt.NewRow();
                            dr1[4] = temp.Rows[i][4].ToString();
                            dr1[5] = temp.Rows[i][5].ToString();
                            dr1[6] = temp.Rows[i][6].ToString();
                            dr1[7] = temp.Rows[i][7].ToString();
                            dr1[8] = temp.Rows[i][8].ToString();
                            dr1[9] = temp.Rows[i][9].ToString();
                            dr1[10] = temp.Rows[i][10].ToString();
                            dr1[11] = temp.Rows[i][11].ToString();
                            dr1[12] = temp.Rows[i][12].ToString();
                            dr1[13] = temp.Rows[i][13].ToString();
                            dt.Rows.Add(dr1);
                        }
                    }
                    if (i == 48)
                    {
                        DataRow dr1 = dt.NewRow();
                        dr1[13] = "1.5";
                        dt.Rows.Add(dr1);

                    }
                }

            }
            else
            {
                temp = gen.GetTable("tonghopbangcandoiketoan2014 '" + ngaychungtu + "','" + thangtruoc + "','" + thang + "','" + nam + "','12','" + namdauky + "'");

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    {
                        if (Double.Parse(temp.Rows[i][2].ToString()) < 0)
                        {
                            dr[14] = "(" + String.Format("{0:n0}", 0 - Double.Parse(temp.Rows[i][2].ToString())) + ")";
                        }
                        else
                        {
                            dr[14] = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                        }
                        if (i != 23 && i != 24 && i != 26 && i != 27 && i != 29 && i != 30)
                            dr[2] = temp.Rows[i][2].ToString();

                    }
                    else
                    {
                        dr[14] = "-";
                    }
                    if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    {
                        if (Double.Parse(temp.Rows[i][3].ToString()) < 0)
                        {
                            dr[15] = "(" + String.Format("{0:n0}", 0 - Double.Parse(temp.Rows[i][3].ToString())) + ")";
                        }
                        else
                        {
                            dr[15] = String.Format("{0:n0}", Double.Parse(temp.Rows[i][3].ToString()));
                        }
                        if (i != 23 && i != 24 && i != 26 && i != 27 && i != 29 && i != 30)
                            dr[3] = temp.Rows[i][3].ToString();
                    }
                    else
                    {
                        dr[15] = "-";
                    }
                    dr[4] = temp.Rows[i][4].ToString();
                    dr[5] = temp.Rows[i][5].ToString();
                    dr[6] = temp.Rows[i][6].ToString();
                    dr[7] = temp.Rows[i][7].ToString();
                    dr[8] = temp.Rows[i][8].ToString();
                    dr[9] = temp.Rows[i][9].ToString();
                    dr[10] = temp.Rows[i][10].ToString();
                    dr[11] = temp.Rows[i][11].ToString();
                    dr[12] = temp.Rows[i][12].ToString();
                    dr[13] = temp.Rows[i][13].ToString();
                    dt.Rows.Add(dr);
                    if (i == 16)
                    {
                        for (int j = 0; j < 21; j++)
                        {
                            DataRow dr1 = dt.NewRow();
                            dr1[4] = temp.Rows[i][4].ToString();
                            dr1[5] = temp.Rows[i][5].ToString();
                            dr1[6] = temp.Rows[i][6].ToString();
                            dr1[7] = temp.Rows[i][7].ToString();
                            dr1[8] = temp.Rows[i][8].ToString();
                            dr1[9] = temp.Rows[i][9].ToString();
                            dr1[10] = temp.Rows[i][10].ToString();
                            dr1[11] = temp.Rows[i][11].ToString();
                            dr1[12] = temp.Rows[i][12].ToString();
                            dr1[13] = temp.Rows[i][13].ToString();
                            dt.Rows.Add(dr1);
                        }
                    }
                    if (i == 41)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            DataRow dr1 = dt.NewRow();
                            dr1[13] = "1.5";
                            dt.Rows.Add(dr1);
                        }
                    }
                }
            }

            Frm_rpthuchi rp = new Frm_rpthuchi();
            rp.getda(dt);
            rp.getrole(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.getcongty(userid);
            rp.Show();
            SplashScreenManager.CloseForm();
        }

        public void loadtinhhinhhoatdongkinhdoanh(string ngaychungtu, string tsbt, string userid,string tungay)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(tungay).Month.ToString();
            string namdauky = DateTime.Parse(ngaychungtu).AddYears(-1).Year.ToString();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Số cuối kỳ", Type.GetType("System.String"));
            dt.Columns.Add("Số đầu kỳ", Type.GetType("System.String"));
            dt.Columns.Add("Lũy kế", Type.GetType("System.String"));
            string loai = "quy";

            DataTable temp = new DataTable();
            if (thang == thangtruoc)
            {
                thangtruoc = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
                namdauky = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
                loai = "thang";
            }
            temp = gen.GetTable("tonghoptinhhinhhoatdongkinhdoanh '" + ngaychungtu + "','" + thangtruoc + "','" + thang + "','" + nam + "','"+namdauky+"','"+loai+"'");
            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                {
                    if (Double.Parse(temp.Rows[i][1].ToString()) < 0)
                    {
                        dr[0] = "(" + String.Format("{0:n0}", 0 - Double.Parse(temp.Rows[i][1].ToString())) + ")";
                    }
                    else
                    {
                        dr[0] = String.Format("{0:n0}", Double.Parse(temp.Rows[i][1].ToString()));
                    }
                }
                else
                {
                    dr[0] = "-";
                }

                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                {
                    if (Double.Parse(temp.Rows[i][2].ToString()) < 0)
                    {
                        dr[1] = "(" + String.Format("{0:n0}", 0 - Double.Parse(temp.Rows[i][2].ToString())) + ")";
                    }
                    else
                    {
                        dr[1] = String.Format("{0:n0}", Double.Parse(temp.Rows[i][2].ToString()));
                    }
                }
                else
                {
                    dr[1] = "-";
                }


                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                {
                    if (Double.Parse(temp.Rows[i][3].ToString()) < 0)
                    {
                        dr[2] = "(" + String.Format("{0:n0}", 0 - Double.Parse(temp.Rows[i][3].ToString())) + ")";
                    }
                    else
                    {
                        dr[2] = String.Format("{0:n0}", Double.Parse(temp.Rows[i][3].ToString()));
                    }
                }
                else
                {
                    dr[2] = "-";
                }

                dt.Rows.Add(dr);
            }
            Frm_rpthuchi rp = new Frm_rpthuchi();
            rp.getda(dt);
            rp.getrole(ngaychungtu);
            rp.gettsbt(tsbt);
            rp.getcongty(tungay);
            rp.Show();
            SplashScreenManager.CloseForm();
        }


        public void loadbcdtk(string ngaychungtu, string tsbt,GridView view,string yes)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài khoản", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            if (yes == "yes")
            {
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Nợ đầu kỳ").ToString() != "" || view.GetRowCellValue(i, "Có đầu kỳ").ToString() != "" || view.GetRowCellValue(i, "Phát sinh nợ").ToString() != "" || view.GetRowCellValue(i, "Phát sinh có").ToString() != "" || view.GetRowCellValue(i, "Nợ cuối kỳ").ToString() != "" || view.GetRowCellValue(i, "Có cuối kỳ").ToString() != "")
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = view.GetRowCellValue(i, "Tài khoản").ToString();
                        dr[1] = view.GetRowCellValue(i, "Tên tài khoản").ToString();
                        if (view.GetRowCellValue(i, "Nợ đầu kỳ").ToString() != "")
                            dr[2] = view.GetRowCellValue(i, "Nợ đầu kỳ").ToString();
                        if (view.GetRowCellValue(i, "Có đầu kỳ").ToString() != "")
                            dr[3] = view.GetRowCellValue(i, "Có đầu kỳ").ToString();
                        if (view.GetRowCellValue(i, "Phát sinh nợ").ToString() != "")
                            dr[4] = view.GetRowCellValue(i, "Phát sinh nợ").ToString();
                        if (view.GetRowCellValue(i, "Phát sinh có").ToString() != "")
                            dr[5] = view.GetRowCellValue(i, "Phát sinh có").ToString();
                        if (view.GetRowCellValue(i, "Lũy kế nợ").ToString() != "")
                            dr[6] = view.GetRowCellValue(i, "Lũy kế nợ").ToString();
                        if (view.GetRowCellValue(i, "Lũy kế có").ToString() != "")
                            dr[7] = view.GetRowCellValue(i, "Lũy kế có").ToString();
                        if (view.GetRowCellValue(i, "Nợ cuối kỳ").ToString() != "")
                            dr[8] = view.GetRowCellValue(i, "Nợ cuối kỳ").ToString();
                        if (view.GetRowCellValue(i, "Có cuối kỳ").ToString() != "")
                            dr[9] = view.GetRowCellValue(i, "Có cuối kỳ").ToString();
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Nợ cuối kỳ").ToString() != "" || view.GetRowCellValue(i, "Có cuối kỳ").ToString() != "")
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = view.GetRowCellValue(i, "Tài khoản").ToString();
                        dr[1] = view.GetRowCellValue(i, "Tên tài khoản").ToString();
                        if (view.GetRowCellValue(i, "Nợ đầu kỳ").ToString() != "")
                            dr[2] = view.GetRowCellValue(i, "Nợ đầu kỳ").ToString();
                        if (view.GetRowCellValue(i, "Có đầu kỳ").ToString() != "")
                            dr[3] = view.GetRowCellValue(i, "Có đầu kỳ").ToString();
                        if (view.GetRowCellValue(i, "Phát sinh nợ").ToString() != "")
                            dr[4] = view.GetRowCellValue(i, "Phát sinh nợ").ToString();
                        if (view.GetRowCellValue(i, "Phát sinh có").ToString() != "")
                            dr[5] = view.GetRowCellValue(i, "Phát sinh có").ToString();
                        if (view.GetRowCellValue(i, "Lũy kế nợ").ToString() != "")
                            dr[6] = view.GetRowCellValue(i, "Lũy kế nợ").ToString();
                        if (view.GetRowCellValue(i, "Lũy kế có").ToString() != "")
                            dr[7] = view.GetRowCellValue(i, "Lũy kế có").ToString();
                        if (view.GetRowCellValue(i, "Nợ cuối kỳ").ToString() != "")
                            dr[8] = view.GetRowCellValue(i, "Nợ cuối kỳ").ToString();
                        if (view.GetRowCellValue(i, "Có cuối kỳ").ToString() != "")
                            dr[9] = view.GetRowCellValue(i, "Có cuối kỳ").ToString();
                        dt.Rows.Add(dr);
                    }
                }
            }

            string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year,DateTime.Parse(ngaychungtu).Month).ToString();
            string tungay = DateTime.Parse(DateTime.Parse(ngaychungtu).Month + "/1/" + DateTime.Parse(ngaychungtu).Year).ToString();
            string denngay = DateTime.Parse(DateTime.Parse(ngaychungtu).Month + "/" + ngay + "/" + DateTime.Parse(ngaychungtu).Year).ToString();

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(denngay);
            rp.getdenngay(tungay);
            rp.gettsbt("tsbtbcdtk");
            rp.Show();            
        }

        public void loadbcdtkth(string ngaychungtu, string tsbt, string tungay)
        {

            SplashScreenManager.ShowForm(typeof(Frm_wait));
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangdau = DateTime.Parse(tungay).Month.ToString();
            string thangtruoc = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();   

            DataTable temp = gen.GetTable("tonghopbangcandoitaikhoan '"+thangtruoc+"','"+namtruoc+"','"+thangdau+"','"+thang+"','"+nam+"'");
            DataTable dt = new DataTable();
            dt.Columns.Add("Tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));
            Double dkn = 0, dkc = 0, psn = 0, psc = 0, lkn = 0, lkc = 0, ckn = 0, ckc = 0; 

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (Double.Parse(temp.Rows[i][8].ToString()) != 0 || Double.Parse(temp.Rows[i][9].ToString()) != 0 || Double.Parse(temp.Rows[i][2].ToString()) != 0 || Double.Parse(temp.Rows[i][3].ToString()) != 0 || Double.Parse(temp.Rows[i][6].ToString()) != 0 || Double.Parse(temp.Rows[i][7].ToString()) != 0)
                    {
                        if (temp.Rows[i][0].ToString() == "156" || temp.Rows[i][0].ToString() == "1561" || temp.Rows[i][0].ToString() == "1562")
                        {
                            if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                                ckn = ckn + Double.Parse(temp.Rows[i][8].ToString());
                            if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                                ckc = ckc + Double.Parse(temp.Rows[i][9].ToString());

                            if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                                dkn=dkn+Double.Parse(temp.Rows[i][2].ToString());
                            if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                                dkc = dkc+Double.Parse(temp.Rows[i][3].ToString());

                            if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                                psn = psn + Double.Parse(temp.Rows[i][4].ToString());
                            if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                                psc = psc + Double.Parse(temp.Rows[i][5].ToString());

                            if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                                lkn = lkn + Double.Parse(temp.Rows[i][6].ToString());
                            if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                                lkc = lkc + Double.Parse(temp.Rows[i][7].ToString());
                            
                            if (temp.Rows[i][0].ToString() == "1562" || (temp.Rows[i][0].ToString() == "1561" && temp.Rows[i+1][0].ToString() != "1562"))
                            {
                                DataRow dr = dt.NewRow();
                                dr[0] = "156";
                                dr[1] = "Hàng hóa";

                                if (ckn != 0 || ckc != 0)
                                    dr[2] = ckn - ckc;
                                /*if (ckc != 0)
                                    dr[3] = ckc;*/

                                if (dkn != 0 || dkc != 0)
                                    dr[8] = dkn - dkc;
                                /*if (dkc != 0)
                                    dr[9] = dkc;*/

                                if (psn != 0)
                                    dr[6] = psn;
                                if (psc != 0)
                                    dr[7] = psc;

                                if (lkn != 0)
                                    dr[4] = lkn;
                                if (lkc != 0)
                                    dr[5] = lkc;

                                dt.Rows.Add(dr);
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = temp.Rows[i][0];
                            dr[1] = temp.Rows[i][1];

                            if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                                dr[2] = temp.Rows[i][8];
                            if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                                dr[3] = temp.Rows[i][9];

                            if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                                dr[8] = temp.Rows[i][2];
                            if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                                dr[9] = temp.Rows[i][3];

                            if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                                dr[6] = temp.Rows[i][4];
                            if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                                dr[7] = temp.Rows[i][5];

                            if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                                dr[4] = temp.Rows[i][6];
                            if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                                dr[5] = temp.Rows[i][7];
                            dt.Rows.Add(dr);
                        }
                    }
                }
                SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(ngaychungtu);
            rp.getdenngay(tungay);
            rp.gettsbt("tsbtbcdtk");
            rp.Show(); 
        }

        public void loadbcdtkthtndn(string ngaychungtu, string tsbt, string tungay)
        {

            SplashScreenManager.ShowForm(typeof(Frm_wait));
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangdau = DateTime.Parse(tungay).Month.ToString();
            string thangtruoc = DateTime.Parse(tungay).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(tungay).AddMonths(-1).Year.ToString();
            DataTable temp = new DataTable();
            if (tsbt == "scth" || tsbt == "sktth")
                temp = gen.GetTable("tonghopbangcandoitaikhoan '" + thangtruoc + "','" + namtruoc + "','" + thangdau + "','" + thang + "','" + nam + "'");
            else
                temp = gen.GetTable("tonghopbangcandoitaikhoantomtat '" + thangtruoc + "','" + namtruoc + "','" + thangdau + "','" + thang + "','" + nam + "'");
            DataTable dt = new DataTable();
            dt.Columns.Add("Tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Tên tài khoản", Type.GetType("System.String"));
            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Có lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));
            Double dkn = 0, dkc = 0, psn = 0, psc = 0, lkn = 0, lkc = 0, ckn = 0, ckc = 0;

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0 || Double.Parse(temp.Rows[i][9].ToString()) != 0 || Double.Parse(temp.Rows[i][2].ToString()) != 0 || Double.Parse(temp.Rows[i][3].ToString()) != 0 || Double.Parse(temp.Rows[i][6].ToString()) != 0 || Double.Parse(temp.Rows[i][7].ToString()) != 0 || Double.Parse(temp.Rows[i][4].ToString()) != 0 || Double.Parse(temp.Rows[i][5].ToString()) != 0)
                {
                    if ((temp.Rows[i][0].ToString() == "156" || temp.Rows[i][0].ToString() == "1561" || temp.Rows[i][0].ToString() == "1562") && (tsbt == "scth" || tsbt == "tsbtbcdtktomtat" || tsbt == "scthtomtat" || tsbt == "sktthtomtat"))
                    {
                        if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                            ckn = ckn + Double.Parse(temp.Rows[i][8].ToString());
                        if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                            ckc = ckc + Double.Parse(temp.Rows[i][9].ToString());

                        if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                            dkn = dkn + Double.Parse(temp.Rows[i][2].ToString());
                        if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                            dkc = dkc + Double.Parse(temp.Rows[i][3].ToString());

                        if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                            psn = psn + Double.Parse(temp.Rows[i][4].ToString());
                        if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                            psc = psc + Double.Parse(temp.Rows[i][5].ToString());

                        if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                            lkn = lkn + Double.Parse(temp.Rows[i][6].ToString());
                        if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                            lkc = lkc + Double.Parse(temp.Rows[i][7].ToString());

                        if (temp.Rows[i][0].ToString() == "1562" || (temp.Rows[i][0].ToString() == "1561" && temp.Rows[i + 1][0].ToString() != "1562"))
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = "156";
                            dr[1] = "Hàng hóa";

                            if (ckn != 0 || ckc != 0)
                                dr[2] = ckn - ckc;

                            if (dkn != 0 || dkc != 0)
                                dr[8] = dkn - dkc;

                            if (psn != 0)
                                dr[6] = psn;
                            if (psc != 0)
                                dr[7] = psc;

                            if (lkn != 0)
                                dr[4] = lkn;
                            if (lkc != 0)
                                dr[5] = lkc;

                            dt.Rows.Add(dr);
                        }                 
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = temp.Rows[i][0];
                        dr[1] = temp.Rows[i][1];

                        if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                            dr[2] = temp.Rows[i][8];
                        if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                            dr[3] = temp.Rows[i][9];

                        if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                            dr[8] = temp.Rows[i][2];
                        if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                            dr[9] = temp.Rows[i][3];

                        if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                            dr[6] = temp.Rows[i][4];
                        if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                            dr[7] = temp.Rows[i][5];

                        if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                            dr[4] = temp.Rows[i][6];
                        if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                            dr[5] = temp.Rows[i][7];
                        dt.Rows.Add(dr);
                    }
                }
            }
            SplashScreenManager.CloseForm();
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(ngaychungtu);
            rp.getdenngay(tungay);
            rp.gettsbt(tsbt);
            rp.Show();
        }

        public void loadththnv(string ngaychungtu, string tsbt, DataTable temp)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            DataTable dt = new DataTable();
            dt.Columns.Add("Chỉ tiêu", Type.GetType("System.String"));
            dt.Columns.Add("Mã số", Type.GetType("System.String"));
            dt.Columns.Add("Số phải nộp đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Số phải nộp phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Số đã nộp phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Số phải nộp lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Số đã nộp lũy kế", Type.GetType("System.Double"));
            dt.Columns.Add("Số phải nộp cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Chỉ tiêu 1", Type.GetType("System.String"));
            dt.Columns.Add("Mã số 1", Type.GetType("System.String"));
            dt.Columns.Add("Chỉ tiêu 2", Type.GetType("System.String"));
            dt.Columns.Add("Mã số 2", Type.GetType("System.String"));
            double[,] detail = new double[20, 20];
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (Double.Parse(temp.Rows[i][8].ToString()) != 0 || Double.Parse(temp.Rows[i][9].ToString()) != 0 || Double.Parse(temp.Rows[i][2].ToString()) != 0 || Double.Parse(temp.Rows[i][3].ToString()) != 0 || Double.Parse(temp.Rows[i][6].ToString()) != 0 || Double.Parse(temp.Rows[i][7].ToString()) != 0)
                {
                    if (temp.Rows[i][0].ToString().Substring(0, 3) == "333")
                    {
                        if (temp.Rows[i][0].ToString() == "33311")
                        {
                            detail[0, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[0, 1];
                            detail[0, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[0, 2];
                            detail[0, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[0, 3];
                            detail[0, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[0, 4];
                            detail[0, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[0, 5];
                            detail[0, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[0, 6];
                            detail[0, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[0, 7];
                            detail[0, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[0, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "33312")
                        {
                            detail[1, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[1, 1];
                            detail[1, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[1, 2];
                            detail[1, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[1, 3];
                            detail[1, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[1, 4];
                            detail[1, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[1, 5];
                            detail[1, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[1, 6];
                            detail[1, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[1, 7];
                            detail[1, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[1, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "3332")
                        {
                            detail[2, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[2, 1];
                            detail[2, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[2, 2];
                            detail[2, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[2, 3];
                            detail[2, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[2, 4];
                            detail[2, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[2, 5];
                            detail[2, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[2, 6];
                            detail[2, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[2, 7];
                            detail[2, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[2, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "3333")
                        {
                            detail[3, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[3, 1];
                            detail[3, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[3, 2];
                            detail[3, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[3, 3];
                            detail[3, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[3, 4];
                            detail[3, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[3, 5];
                            detail[3, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[3, 6];
                            detail[3, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[3, 7];
                            detail[3, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[3, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "3334")
                        {
                            detail[4, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[4, 1];
                            detail[4, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[4, 2];
                            detail[4, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[4, 3];
                            detail[4, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[4, 4];
                            detail[4, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[4, 5];
                            detail[4, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[4, 6];
                            detail[4, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[4, 7];
                            detail[4, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[4, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "3335")
                        {
                            detail[5, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[5, 1];
                            detail[5, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[5, 2];
                            detail[5, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[5, 3];
                            detail[5, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[5, 4];
                            detail[5, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[5, 5];
                            detail[5, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[5, 6];
                            detail[5, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[5, 7];
                            detail[5, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[5, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "3336")
                        {
                            detail[6, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[6, 1];
                            detail[6, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[6, 2];
                            detail[6, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[6, 3];
                            detail[6, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[6, 4];
                            detail[6, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[6, 5];
                            detail[6, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[6, 6];
                            detail[6, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[6, 7];
                            detail[6, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[6, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "3337")
                        {
                            detail[7, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[7, 1];
                            detail[7, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[7, 2];
                            detail[7, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[7, 3];
                            detail[7, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[7, 4];
                            detail[7, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[7, 5];
                            detail[7, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[7, 6];
                            detail[7, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[7, 7];
                            detail[7, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[7, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "3338")
                        {
                            detail[8, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[8, 1];
                            detail[8, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[8, 2];
                            detail[8, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[8, 3];
                            detail[8, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[8, 4];
                            detail[8, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[8, 5];
                            detail[8, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[8, 6];
                            detail[8, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[8, 7];
                            detail[8, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[8, 8];
                        }
                        else if (temp.Rows[i][0].ToString() == "3339")
                        {
                            detail[9, 1] = Double.Parse(temp.Rows[i][8].ToString()) + detail[9, 1];
                            detail[9, 2] = Double.Parse(temp.Rows[i][9].ToString()) + detail[9, 2];
                            detail[9, 3] = Double.Parse(temp.Rows[i][6].ToString()) + detail[9, 3];
                            detail[9, 4] = Double.Parse(temp.Rows[i][7].ToString()) + detail[9, 4];
                            detail[9, 5] = Double.Parse(temp.Rows[i][4].ToString()) + detail[9, 5];
                            detail[9, 6] = Double.Parse(temp.Rows[i][5].ToString()) + detail[9, 6];
                            detail[9, 7] = Double.Parse(temp.Rows[i][2].ToString()) + detail[9, 7];
                            detail[9, 8] = Double.Parse(temp.Rows[i][3].ToString()) + detail[9, 8];
                        }
                    }
                }
            }
            SplashScreenManager.CloseForm();
            /*Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.getngaychungtu(ngaychungtu);
            rp.gettsbt("tsbtbcdtk");
            rp.Show();*/
        }

        public void loadlog(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Tên đăng nhập", Type.GetType("System.String"));
            dt.Columns.Add("Tên máy tính", Type.GetType("System.String"));
            dt.Columns.Add("Thời gian", Type.GetType("System.DateTime"));
            dt.Columns.Add("Tác vụ", Type.GetType("System.String"));
            dt.Columns.Add("Phiếu", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][6].ToString();
                dr[5] = temp.Rows[i][7].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Thời gian"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Thời gian"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            view.Columns["Thời gian"].Width = 200;
            view.Columns["Thời gian"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }

        public void deletelog(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F, string ngay)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa nhật ký truy cập tháng " + DateTime.Parse(ngay).Month.ToString() + " năm " + DateTime.Parse(ngay).Year.ToString() + " ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from MSC_Auditting_Log where Month(Time)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(Time)='" + DateTime.Parse(ngay).Year.ToString() + "'");
                    while (view.RowCount > 0)
                    {
                        view.DeleteRow(0);
                    }
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu nhập kho trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public void luuchuyentiente(string tungay, string denngay)
        {
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.gettungay(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt("tsblctt");
            rp.Show();
        }

        public void tinhhinhnghiavu(string tungay, string denngay)
        {
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.gettungay(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt("tsbtttthnvvnn");
            rp.Show();
        }
    }
}
