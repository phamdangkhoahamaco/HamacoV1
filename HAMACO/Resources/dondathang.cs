using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;

namespace HAMACO.Resources
{
    class dondathang
    {
        gencon gen = new gencon();
        public delegate void NewHome();
        public event NewHome OnNewHome;

        //Ham load data
        void LoadData(string sql)
        {
            SqlConnection conn = gen.GetConn();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }    
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Notification = null;
            SqlDependency de = new SqlDependency(cmd);
            de.OnChange += new OnChangeEventHandler(de_OnChange);
        }

        public void de_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency de = sender as SqlDependency;
            de.OnChange -= de_OnChange;
            if (OnNewHome != null)
            {
                OnNewHome();
            }
        }

        public void loadddh(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu, string userid, string tsbt)
        {
            string sql = null;
            if (tsbt == "tsbtddh")
                sql = "select Case when Sale=0 then COALESCE(Tien,TotalAmount)-CostCap-COALESCE(TotalCost,0)-COALESCE(TotalTransport,0) else 0 end,RefID,RefNo,PostedDate,RefDate,d.AccountingObjectCode,d.AccountingObjectName,b.StockCode,JournalMemo,COALESCE(Tien,TotalAmount),CostCap,c.StockCode,ShippingNo,ReceiveMethod,Sale,Stock,InOut,Status,RefIDInOutward,a.Export,COALESCE(TotalTransport,0) from (select a.*,b.IsExport as Export,b.TotalAmount as Tien from (select * from DDH where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "') a left join  INOutward b on a.RefIDInOutward=b.RefNo) a, Stock b, Stock c, AccountingObject d where a.AccountingObjectID=d.AccountingObjectID and a.OutStockID=b.StockID and a.InStockID=c.StockID and c.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo";
            else if (tsbt == "tsbtcdh")
                sql = "select Case when Sale=0 then TotalAmount-CostCap-COALESCE(TotalCost,0)-COALESCE(TotalTransport,0) else 0 end,RefID,RefNo,PostedDate,RefDate,d.AccountingObjectCode,d.AccountingObjectName,b.StockCode,JournalMemo,TotalAmount,CostCap,c.StockCode,ShippingNo,ReceiveMethod,Sale,Stock,InOut,Status,RefIDInOutward from DDH a, Stock b, Stock c, AccountingObject d where a.AccountingObjectID=d.AccountingObjectID and a.OutStockID=b.StockID and a.InStockID=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo";
            else if (tsbt=="tsbtddhtk")
                sql = "select Case when Sale=0 then TotalAmount-CostCap-COALESCE(TotalCost,0)-COALESCE(TotalTransport,0) else 0 end,RefID,RefNo,PostedDate,RefDate,d.AccountingObjectCode,d.AccountingObjectName,b.StockCode,JournalMemo,TotalAmount,CostCap,c.StockCode,ShippingNo,ReceiveMethod,Sale,Stock,InOut,Status,RefIDInOutward from DDH a, Stock b, Stock c, AccountingObject d where a.AccountingObjectID=d.AccountingObjectID and a.OutStockID=b.StockID and a.InStockID=c.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') and (Stock='0' or Received='1') order by RefNo";            
                  
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);

            dt.Columns.Add("Lãi lỗ", Type.GetType("System.Double"));
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Đặt hàng", Type.GetType("System.DateTime"));
            dt.Columns.Add("Xuất kho", Type.GetType("System.DateTime"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Cung ứng", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            
            dt.Columns.Add("Tiền hàng", Type.GetType("System.Double"));
            dt.Columns.Add("Giá vốn", Type.GetType("System.Double"));
            dt.Columns.Add("Kho nhận", Type.GetType("System.String"));
            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));
            dt.Columns.Add("Tài xế", Type.GetType("System.String"));
            dt.Columns.Add("Trạng thái", Type.GetType("System.String"));            
            dt.Columns.Add("Từ", Type.GetType("System.String"));
            dt.Columns.Add("Chuyển", Type.GetType("System.Boolean"));
            dt.Columns.Add("Nhận", Type.GetType("System.Boolean"));
            dt.Columns.Add("Xuất", Type.GetType("System.Boolean"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.Boolean"));

            dt.Columns.Add("Vận chuyển", Type.GetType("System.Double"));
            dt.Columns.Add("Lãi", Type.GetType("System.Double"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (Double.Parse(temp.Rows[i][0].ToString()) < 0)
                    dr[0] = temp.Rows[i][0].ToString();

                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dr[6] = temp.Rows[i][6].ToString();
                dr[7] = temp.Rows[i][7].ToString();
                dr[8] = temp.Rows[i][8].ToString();
                
                if (Double.Parse(temp.Rows[i][9].ToString()) != 0)
                    dr[9] = temp.Rows[i][9].ToString();
                if (Double.Parse(temp.Rows[i][10].ToString()) != 0)
                    dr[10] = temp.Rows[i][10].ToString();
                dr[11] = temp.Rows[i][11].ToString();
                dr[12] = temp.Rows[i][12].ToString();
                dr[13] = temp.Rows[i][13].ToString();
                if (temp.Rows[i][14].ToString() == "True")
                    dr[14] = "Nhập kho";
                else
                {
                    dr[14] = "Giao thẳng";
                    if (tsbt == "tsbtddh")
                    {
                        if (temp.Rows[i][18].ToString() != "")
                            dr[18] = "True";
                        if (temp.Rows[i][19].ToString() == "True")
                            dr[19] = "True";

                        if (Double.Parse(temp.Rows[i][20].ToString()) != 0)
                            dr[20] = temp.Rows[i][20].ToString();
                        dr[21] = temp.Rows[i][0].ToString();
                    }
                }

                if (temp.Rows[i][15].ToString() == "0")
                    dr[15] = "Công ty";
                else if (temp.Rows[i][15].ToString() == "1")
                    dr[15] = "Nhà máy";

                if (temp.Rows[i][16].ToString() == "True")
                    dr[16] = "True";
                if (temp.Rows[i][17].ToString() == "True")
                    dr[17] = "True";           

                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[1].Visible = false;
            view.OptionsView.ColumnAutoWidth = false;
           
            view.Columns["Xuất kho"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Xuất kho"].DisplayFormat.FormatString = "dd/MM/yyyy";
            
            view.Columns["Xuất kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Đặt hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Đặt hàng"].DisplayFormat.FormatString = "dd/MM/yyyy";
           
            view.Columns["Đặt hàng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Tiền hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tiền hàng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tiền hàng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tiền hàng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Giá vốn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Giá vốn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Giá vốn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Giá vốn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[2].SummaryItem.DisplayFormat = "Số dòng:   {0}";

           
            view.Columns["Trạng thái"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;                       
           
            view.Columns["Kho nhận"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;            
            view.Columns["Cung ứng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Số chứng từ"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Đặt hàng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Xuất kho"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            view.Columns["Hóa đơn"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Xuất"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Nhận"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Chuyển"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Từ"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Trạng thái"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;

            view.Columns["Hóa đơn"].Width = 60;
            view.Columns["Xuất"].Width = 50;
            view.Columns["Nhận"].Width = 50;
            view.Columns["Chuyển"].Width = 60; 
            view.Columns["Trạng thái"].Width = 80;
            view.Columns["Từ"].Width = 70;
            view.Columns["Kho nhận"].Width = 70;
            view.Columns["Cung ứng"].Width = 70;

            view.Columns["Số chứng từ"].Width=170;
            view.Columns["Xuất kho"].Width = 80;
            view.Columns["Đặt hàng"].Width = 80;
            view.Columns["Giá vốn"].Width=100;
            view.Columns["Tiền hàng"].Width=100;
            view.Columns["Mã khách"].Width=100;
            view.Columns["Tên khách hàng"].Width=200;

            view.Columns["Lý do"].Width = 150;
            view.Columns["Phương tiện"].Width = 150;
            view.Columns["Tài xế"].Width = 150;

            if (tsbt == "tsbtddh")
                view.Columns["Kho nhận"].GroupIndex = 0;
            else if (tsbt == "tsbtcdh" || tsbt == "tsbtddhtk")
            {
                view.Columns[18].Visible = false;
                view.Columns[19].Visible = false;
                view.Columns["Cung ứng"].GroupIndex = 0;
                view.Columns["Kho nhận"].GroupIndex = 1;                
            }

            view.Columns["Vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Vận chuyển"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Vận chuyển"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Vận chuyển"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Lãi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Lãi"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Lãi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Lãi"].SummaryItem.DisplayFormat = "{0:n0}";

            view.ExpandAllGroups();            
        }

        public void loadddhcl(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu, string userid, string tsbt)
        {
            string sql = "select RefID as 'ID',RefNo as 'Số chứng từ',RefDate as 'Ngày bắt đầu',PostedDate as 'Giá điều ngày',b.StockCode as 'Mã kho',AccountingObjectCode as 'Mã hàng',AccountingObjectName as 'Tên hàng',TotalAmount as 'Trọng lượng',TotalTransport as 'Đã sử dụng', Contactname as 'Người duyệt', Cancel as 'Hủy' from DDHCL a, Stock b where a.InStockID=b.StockID and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo";
           
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            lvpq.DataSource = gen.GetTable(sql);
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.OptionsView.ColumnAutoWidth = true;

            view.Columns["Số chứng từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Ngày bắt đầu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày bắt đầu"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày bắt đầu"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Giá điều ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Giá điều ngày"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Giá điều ngày"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Mã hàng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n0}";
            
            view.Columns["Đã sử dụng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đã sử dụng"].DisplayFormat.FormatString = "{0:n0}";
          
            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
          
            view.Columns["Mã kho"].GroupIndex = 0;            
            view.ExpandAllGroups();
        }

        public void tsbtpxk(string sophieu, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang)
        {
            sophieu = gen.GetString("select RefID from INOutward where RefNo='" + sophieu + "'");
            Frm_phieunhapkhovat u = new Frm_phieunhapkhovat();
            u.getactive("1");
            u.getroleid(roleid);
            u.getsub(subsys);
            u.getpt("pxk");
            u.getdate(ngaychungtu);
            u.getuser(userid);
            u.getbranch(branchid);
            u.getkhach(khach);
            u.gethang(hang);
            u.getrole(sophieu);
            u.ShowDialog();
        }

        public void tsbtddh(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang, string tsbt)
        {
            /*try
            {*/
                Frm_ddh u = new Frm_ddh();
                u.myac = new Frm_ddh.ac(F.refreshddh);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getpt(tsbt);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.getkhach(khach);
                u.gethang(hang);

                if (a == "1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                else
                {
                    try
                    {
                        u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());
                    }
                    catch { }
                }

                u.ShowDialog();
            /*}
            catch 
            {
                XtraMessageBox.Show("Vui lòng chọn đơn đặt hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        public void tsbtddhcl(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string roleid, string subsys, string ngaychungtu, string userid, DataTable khach, DataTable hang, string branchid)
        {
            try
            {
                Frm_ddhcl u = new Frm_ddhcl();
                u.myac = new Frm_ddhcl.ac(F.refreshddhcl);
                u.getuser(userid);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getactive(a);
                u.getkhach(khach);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.gethang(hang);
                u.getbranch(branchid);

                if (a == "1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                else
                {
                    try
                    {
                        u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());
                    }
                    catch { }
                }
                u.ShowDialog();
            }
            catch { XtraMessageBox.Show("Vui lòng chọn đơn hàng chia lượng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        
        }

        public DataTable hangton(LookUpEdit ledv, string ngaychungtu)
        {
            string kho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            string thangtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Month.ToString();
            string namtruoc = DateTime.Parse(ngaychungtu).AddMonths(-1).Year.ToString();
            return gen.GetTable("baocaotonkhotheothangthuctett '" + kho + "','" + thang + "','" + nam + "','" + thangtruoc + "','" + namtruoc + "'");
        }

        public void loadstart(DevExpress.XtraGrid.GridControl VAT, GridView ViewVAT, DevExpress.XtraGrid.GridControl NOVAT, GridView ViewNOVAT,DevExpress.XtraGrid.GridControl CU, GridView ViewCU, LookUpEdit ledvdat, LookUpEdit ledvnhan, DateEdit denct, DevExpress.XtraEditors.RadioGroup radioGroup2,
          DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit trongluong, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
          ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DataTable dtnovat, DataTable dtcu, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, ComboBoxEdit cbthue, LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit bocxep, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit vanchuyen, DataTable khach, DataTable hang, string tsbt, DateEdit dendh, LookUpEdit legd)
        {
            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            DataTable da = new DataTable();
            DataTable tempdat = new DataTable();
            DataTable tempnhan = new DataTable();
            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("10/01/2019"))
                legd.Properties.DataSource = gen.GetTable("select StockII as 'Mã số', StockIIName as 'Diễn giải' from StockIIStock where TimeLine=1 order by StockII");
            else
                legd.Properties.DataSource = gen.GetTable("select StockII as 'Mã số', StockIIName as 'Diễn giải' from StockIIStock where TimeLine=2 order by StockII");
            legd.Properties.DisplayMember = "Diễn giải";
            legd.Properties.ValueMember = "Mã số";
            legd.Properties.PopupWidth = 200;
            legd.Properties.PopupFormMinSize = new System.Drawing.Size(0, 250);
            legd.ItemIndex = 0;


            tempdat.Columns.Add("Mã kho");
            tempdat.Columns.Add("Tên kho");
            if (tsbt == "tsbtddh")
                da = gen.GetTable("select * from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode");
            else
                da = gen.GetTable("select * from Stock order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = tempdat.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                tempdat.Rows.Add(dr);
            }
            ledvdat.Properties.DataSource = tempdat;
            ledvdat.Properties.DisplayMember = "Mã kho";
            ledvdat.Properties.ValueMember = "Mã kho";
            ledvdat.Properties.PopupWidth = 300;
            ledvdat.ItemIndex = 0;


            tempnhan.Columns.Add("Mã kho");
            tempnhan.Columns.Add("Tên kho");
            da = gen.GetTable("select * from Stock order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = tempnhan.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                tempnhan.Rows.Add(dr);
            }
            ledvnhan.Properties.DataSource = tempnhan;
            ledvnhan.Properties.DisplayMember = "Mã kho";
            ledvnhan.Properties.ValueMember = "Mã kho";
            ledvnhan.Properties.PopupWidth = 300;
            
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

            //ViewVAT.Columns["Số lượng tồn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //ViewVAT.Columns["Số lượng tồn"].DisplayFormat.FormatString = "{0:n0}";
            //ViewVAT.Columns["Trọng lượng tồn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //ViewVAT.Columns["Trọng lượng tồn"].DisplayFormat.FormatString = "{0:n2}";     

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
            //ViewVAT.Columns["Số lượng tồn"].Visible = false;
            //ViewVAT.Columns["Trọng lượng tồn"].Visible = false;            



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

        }

        public void loadddh(DevExpress.XtraGrid.GridControl VAT, GridView ViewVAT, DevExpress.XtraGrid.GridControl NOVAT, GridView ViewNOVAT, DevExpress.XtraGrid.GridControl CU, GridView ViewCU, LookUpEdit ledvdat, LookUpEdit ledvnhan, DateEdit denct,
          DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit trongluong, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
          ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, ComboBoxEdit cbthue, LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit bocxep, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit vanchuyen, DataTable khach, DataTable hang, string role,
            TextEdit txtldn, TextEdit txtctg, TextEdit txtsct, TextEdit txtngh, TextEdit txtptvc, TextEdit txtcth, TextEdit txtthue, TextEdit txtten, TextEdit txtdc, TextEdit txtptgh, RadioGroup hangban, RadioGroup cungung, CheckEdit chuyenkho, TextEdit txtgiavon, TextEdit txtcn, string tsbt, TextEdit txtsctchuyen, TextEdit txtsctnhan, DateEdit dendh, CheckEdit chdn, TextEdit txtpxk, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_ddh F, CheckEdit chhc, CheckEdit chgbct, TextEdit txtbx, TextEdit txtvc, CheckEdit chduyet, LabelControl lbduyet, TextEdit txtdienthoai, CheckEdit chnhtk, CheckEdit chot, TextEdit txttaixe, TextEdit txtcmnd, TextEdit txtsdttaixe, LookUpEdit legd, TextEdit txtpk, CheckEdit chvctc)
        {
            DataTable dt = new DataTable();
            DataTable dtnovat = new DataTable();
            DataTable dtcu = new DataTable();
            txtsctchuyen.Text = "";
            txtsctnhan.Text = "";
            chgbct.Checked = false;
            txtdienthoai.Text = "";
            txtcmnd.Text = "";
            txttaixe.Text = "";
 
            loadstart(VAT, ViewVAT, NOVAT, ViewNOVAT, CU, ViewCU, ledvdat, ledvnhan, denct, hangban, mahang, soluong, trongluong, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dtnovat, dtcu, dongia, thanhtien, cbthue, lenv, bocxep, vanchuyen, khach, hang, tsbt, dendh,legd);
            if (active == "1")
            {
                DataTable da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,OutStockID,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,Tax,EmployeeIDSA,TotalAmountOC,IsExport,a.AccountingObjectName,a.AccountingObjectAddress,ReceiveMethod, Sale, Stock, INOut, Factory, CostCap,TotalFreightAmount,PostedDate,Status,RefIDInOutward,Notax,UserCheck,OriginalRefNo,Received,Chot,Taixe,CMND,Dienthoai,GDT,RefNoCL,RefDateCL,RefIDInvoice  from DDH a,Stock c where a.InStockID=c.StockID and RefID='" + role + "'");
                
                if (da.Rows[0][37].ToString() != "")
                {
                    F.getphieucl(da.Rows[0][37].ToString());
                    F.getdategiadieu(da.Rows[0][38].ToString());
                    F.getmahang(gen.GetString("select AccountingObjectCode from DDHCL where RefNo='" + da.Rows[0][37].ToString() + "'"));
                }
                
                ledvnhan.EditValue = gen.GetString("select StockCode from Stock where StockID='" + da.Rows[0][5].ToString() + "'");
                if (da.Rows[0][31].ToString() == "True")
                    chnhtk.Checked = true;
                else
                    chnhtk.Checked = false;
                legd.Properties.ReadOnly = false;
                if (da.Rows[0][36].ToString() != "")
                    legd.ItemIndex = Int32.Parse(da.Rows[0][36].ToString()) - 1;
                else
                    legd.ItemIndex = 0;
                legd.Properties.ReadOnly = true; ;

                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                dendh.EditValue = DateTime.Parse(da.Rows[0][25].ToString());


                DataTable dacon = new DataTable();
                dacon = gen.GetTable("select InventoryItemCode,InventoryItemName,Quantity,QuantityConvert,UnitPriceOC,AmountOC,CustomField1,CustomField2,CustomField3,CustomField4,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,CustomField5,UnitPriceConvert,a.ConvertRate,a.Unit,a.UnitPrice,Amount,a.DiscountRate,a.UnitPriceConvertOC,DGPhi,PhiKhac from DDHDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < dacon.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = dacon.Rows[i][0].ToString();
                    dr[1] = dacon.Rows[i][1].ToString();
                    dr[2] = dacon.Rows[i][2].ToString();
                    dr[3] = dacon.Rows[i][3].ToString();
                    dr[4] = dacon.Rows[i][20].ToString();
                    dr[5] = dacon.Rows[i][4].ToString();
                    dr[6] = dacon.Rows[i][5].ToString();
                    dr[7] = dacon.Rows[i][6].ToString();
                    dr[8] = dacon.Rows[i][7].ToString();
                    dr[9] = dacon.Rows[i][8].ToString();
                    dr[10] = dacon.Rows[i][9].ToString();
                    if (dacon.Rows[i][21].ToString() != "")
                        dr[11] = dacon.Rows[i][21].ToString();
                    else dr[11] = "0";

                    if (dacon.Rows[i][22].ToString() != "")
                        dr[12] = dacon.Rows[i][22].ToString();
                    else dr[12] = "0";

                    if (dacon.Rows[i][23].ToString() != "")
                        dr[13] = dacon.Rows[i][23].ToString();
                    else dr[13] = "0";

                    dt.Rows.Add(dr);

                    DataRow dr1 = dtcu.NewRow();
                    dr1[0] = dacon.Rows[i][0].ToString();
                    dr1[1] = dacon.Rows[i][1].ToString();
                    dr1[2] = dacon.Rows[i][2].ToString();
                    dr1[3] = dacon.Rows[i][3].ToString();
                    dr1[4] = dacon.Rows[i][10].ToString();
                    dr1[5] = dacon.Rows[i][11].ToString();
                    dr1[6] = dacon.Rows[i][12].ToString();
                    dr1[7] = dacon.Rows[i][13].ToString();
                    dr1[8] = dacon.Rows[i][14].ToString();
                    dr1[9] = dacon.Rows[i][15].ToString();
                    dr1[10] = dacon.Rows[i][16].ToString();
                    dr1[11] = dacon.Rows[i][17].ToString();
                    dtcu.Rows.Add(dr1);

                    DataRow dr2 = dtnovat.NewRow();
                    dr2[0] = dacon.Rows[i][0].ToString();
                    dr2[1] = dacon.Rows[i][1].ToString();
                    dr2[2] = dacon.Rows[i][2].ToString();
                    dr2[3] = dacon.Rows[i][3].ToString();
                    dr2[4] = dacon.Rows[i][18].ToString();
                    dr2[5] = dacon.Rows[i][19].ToString();
                    dtnovat.Rows.Add(dr2);
                }
                VAT.DataSource = dt;
                CU.DataSource = dtcu;
                NOVAT.DataSource = dtnovat;
                tsbtcat.Enabled = false;

              
                txttaixe.Text = da.Rows[0][33].ToString();
                txtcmnd.Text = da.Rows[0][34].ToString();
                txtsdttaixe.Text = da.Rows[0][35].ToString();

                if (da.Rows[0][32].ToString() == "True")
                    chot.Checked = true;
                else
                    chot.Checked = false;               

                txtdienthoai.Text = da.Rows[0][30].ToString();

                if (da.Rows[0][29].ToString() != "")
                {
                    lbduyet.Text = da.Rows[0][29].ToString();
                    chduyet.Checked = true;
                    chduyet.Enabled = false;
                }

                if (da.Rows[0][19].ToString() == "False")
                    hangban.SelectedIndex = 0;
                
                if (da.Rows[0][20].ToString() == "0")
                    cungung.SelectedIndex = 0;
                else if (da.Rows[0][20].ToString() == "1")
                    cungung.SelectedIndex = 1;
                else
                    cungung.SelectedIndex = -1;

                if (da.Rows[0][21].ToString() == "True")
                    chuyenkho.Checked = true;
                else
                    chuyenkho.Checked = false;

                try
                {
                    if (da.Rows[0][22].ToString() == "True")
                    {
                        txtsctchuyen.EditValue = gen.GetString("select RefNo from INTransferBranch where RefSUID='" + role + "'");
                        txtsctnhan.EditValue = gen.GetString("select RefNoIn from INTransferBranch where RefSUID='" + role + "'");
                    }
                    else if (da.Rows[0][22].ToString() == "False")
                    {
                        txtsctchuyen.EditValue = gen.GetString("select RefNo from INTransfer where RefSUID='" + role + "'");
                        txtsctnhan.EditValue = gen.GetString("select RefNoIn from INTransfer where RefSUID='" + role + "'");
                    }
                }
                catch{}

                ledvdat.EditValue = da.Rows[0][7].ToString();

                F.getchon(1);
               
                ledt.EditValue = da.Rows[0][0].ToString();
                txtldn.Text = da.Rows[0][2].ToString();
                txtctg.Text = da.Rows[0][3].ToString();
                
                txtsct.Text = da.Rows[0][6].ToString();
                txtngh.Text = da.Rows[0][1].ToString();
                txtptvc.Text = da.Rows[0][11].ToString();
                if (da.Rows[0][28].ToString() == "True")
                {
                    F.getchon(1);
                    chgbct.Checked = true;
                }
                if (da.Rows[0][8].ToString() == "True")
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
                if (da.Rows[0][10].ToString() == "True")
                {
                    tsbtboghi.Enabled = false;
                    tsbtghiso.Enabled = false;
                }
                try
                {
                    F.getchon(1);
                    cbthue.Text = da.Rows[0][12].ToString();
                }
                catch { }
                try
                {
                    string nv = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][13].ToString() + "'");
                    lenv.EditValue = nv;
                }
                catch
                {
                    lenv.EditValue = "3";
                }
                txtcth.Text = String.Format("{0:n0}", Double.Parse(ViewNOVAT.Columns["Thành tiền"].SummaryText));
                txtthue.EditValue = Double.Parse(da.Rows[0][14].ToString());
                txtgiavon.EditValue = Double.Parse(da.Rows[0][23].ToString());
                txtbx.Text = String.Format("{0:n0}", Double.Parse(ViewVAT.Columns["Bốc xếp"].SummaryText));
                //txtvc.Text = String.Format("{0:n0}", Double.Parse(ViewVAT.Columns["Vận chuyển"].SummaryText));
                txtvc.EditValue = Double.Parse(ViewVAT.Columns["Vận chuyển"].SummaryText);
                txtpk.Text = String.Format("{0:n0}", Double.Parse(ViewVAT.Columns["Chi phí khác"].SummaryText));
                //txtcn.EditValue = Double.Parse(da.Rows[0][24].ToString());
                txtten.Text = da.Rows[0][16].ToString();
                txtdc.Text = da.Rows[0][17].ToString();
                txtptgh.Text = da.Rows[0][18].ToString();
                if (da.Rows[0][9].ToString() == "1")
                    chhc.Checked = true;
                else
                    chhc.Checked = false;
                if (da.Rows[0][26].ToString() == "True")
                    chdn.Checked = true;
                else
                    chdn.Checked = false;
                txtpxk.Text = da.Rows[0][27].ToString();

                if (da.Rows[0][39].ToString() == "True")
                    chvctc.Checked = true;
                else
                    chvctc.Checked = false;

                checktruocsau(tsbttruoc, tsbtsau, ledvdat.EditValue.ToString(), txtsct.Text, ngaychungtu);                
            }
            else
            {
                ledvnhan.ItemIndex = 0;
                txtbx.Text = "0";
                txtvc.Text = "0";
                txtpk.Text = "0";
                cbthue.SelectedIndex = 2;
                denct.EditValue = DateTime.Parse(ngaychungtu);
                dendh.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void loadchuathue(DevExpress.XtraGrid.Views.Grid.GridView ViewVAT, DevExpress.XtraGrid.Views.Grid.GridView ViewNOVAT, DevExpress.XtraGrid.Views.Grid.GridView ViewCU, TextEdit txtcth, TextEdit txtgiavon, ComboBoxEdit cbthue, CheckEdit chgbct)
        {
            while (ViewNOVAT.RowCount > 0)
            {
                ViewNOVAT.DeleteRow(0);
            }
            while (ViewCU.RowCount > 0)
            {
                ViewCU.DeleteRow(0);
            }
            Double thue = 0;
            try
            {
                thue = Double.Parse(cbthue.EditValue.ToString());
            }
            catch { cbthue.EditValue = 0; }

            int dong = 1;
            if (ViewVAT.OptionsView.NewItemRowPosition == DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None)
                dong = 0;

            for (int i = 0; i < ViewVAT.RowCount - dong; i++)
            {
                Double soluong = 0;
                Double trongluong = 0;
                Double thanhtien = 0;
                Double dongia = 0;

                try
                {
                    trongluong = Double.Parse(ViewVAT.GetRowCellValue(i, "Trọng lượng").ToString());
                    if (trongluong != 0)
                    {
                        try
                        {
                            soluong = Double.Parse(ViewVAT.GetRowCellValue(i, "Số lượng").ToString());
                        }
                        catch { }
                        try
                        {
                            thanhtien = Double.Parse(ViewVAT.GetRowCellValue(i, "Thành tiền").ToString());
                        }
                        catch { }

                        thanhtien = Math.Round(thanhtien / ((100 + thue) / 100), 0, MidpointRounding.AwayFromZero);
                        dongia = Math.Round(thanhtien / trongluong, 2, MidpointRounding.AwayFromZero);
                        if (chgbct.Checked == true)
                        {
                            ViewNOVAT.AddNewRow();
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Mã hàng"], ViewVAT.GetRowCellValue(i, "Mã hàng").ToString());
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Tên hàng"], ViewVAT.GetRowCellValue(i, "Tên hàng").ToString());
                            if (ViewVAT.GetRowCellValue(i, "Số lượng").ToString() != "")
                                ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Số lượng"], ViewVAT.GetRowCellValue(i, "Số lượng").ToString());
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Trọng lượng"], ViewVAT.GetRowCellValue(i, "Trọng lượng").ToString());
                            if (ViewVAT.GetRowCellValue(i, "Đơn giá").ToString() != "")
                                ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Đơn giá"], ViewVAT.GetRowCellValue(i, "Đơn giá").ToString());
                            if (ViewVAT.GetRowCellValue(i, "Thành tiền").ToString() != "")
                                ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Thành tiền"], ViewVAT.GetRowCellValue(i, "Thành tiền").ToString());
                            ViewNOVAT.UpdateCurrentRow();
                        }
                        else
                        {
                            ViewNOVAT.AddNewRow();
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Mã hàng"], ViewVAT.GetRowCellValue(i, "Mã hàng").ToString());
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Tên hàng"], ViewVAT.GetRowCellValue(i, "Tên hàng").ToString());
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Số lượng"], soluong);
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Trọng lượng"], trongluong);
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Đơn giá"], dongia);
                            ViewNOVAT.SetRowCellValue(ViewNOVAT.FocusedRowHandle, ViewNOVAT.Columns["Thành tiền"], thanhtien);
                            ViewNOVAT.UpdateCurrentRow();
                        }

                        ViewCU.AddNewRow();
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Mã hàng"], ViewVAT.GetRowCellValue(i, "Mã hàng").ToString());
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Tên hàng"], ViewVAT.GetRowCellValue(i, "Tên hàng").ToString());
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Số lượng đặt"], soluong);
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Trọng lượng đặt"], trongluong);
                        ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Số lượng"], soluong);
                        if (soluong == 0)
                            ViewCU.SetRowCellValue(ViewCU.FocusedRowHandle, ViewCU.Columns["Trọng lượng"], trongluong);
                        ViewCU.UpdateCurrentRow();
                    }
                }
                catch { }
            }
            txtcth.Text = String.Format("{0:n0}", Double.Parse(ViewNOVAT.Columns["Thành tiền"].SummaryText));
            txtgiavon.Text = String.Format("{0:n0}", Double.Parse(ViewCU.Columns["Thành tiền"].SummaryText));
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
            checktruocsau(tsbttruoc, tsbtsau, mk, sophieu, ngaychungtu);
        }

        public void checkpxk(string active, string role, Frm_ddh F, GridView ViewVAT, LookUpEdit ledt, LookUpEdit ledvn, LookUpEdit ledv, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
          TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit dendh, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
          ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, ComboBoxEdit cbthue, LookUpEdit lenv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txttthue, GridView ViewNOVAT, DataTable hangton, TextEdit txtptgh, GridView ViewCU, RadioGroup hangban, RadioGroup cungung, CheckEdit chuyenkho, TextEdit txtcth, TextEdit txtcn, TextEdit txtgiavon, TextEdit txtsctchuyen, TextEdit txtsctnhan, CheckEdit hangcat, CheckEdit chgbct, TextEdit txtbx, TextEdit txtvc, TextEdit txtdienthoai, CheckEdit chnhtk, CheckEdit chot, TextEdit txttaixe, TextEdit txtcmnd, TextEdit txtsdttaixe, LookUpEdit legd, string phieucl, string ngaygiadieu, TextEdit txtpk, CheckEdit chvctc)
        {
            try
            {
                string dt = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");

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
                    F.getloi("1");
                    return;
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string dvn = gen.GetString("select * from Stock where StockCode='" + ledvn.EditValue.ToString() + "'");

                    int xuatchuyen = -1;
                    if (cungung.SelectedIndex == 0)
                        xuatchuyen = 0;
                    else if (cungung.SelectedIndex == 1)
                        xuatchuyen = 1;

                    string cathang = "0";
                    if (hangcat.Checked == true)
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
                        if (Double.Parse(ViewVAT.Columns["Thành tiền"].SummaryText) != Double.Parse(tongthanhtien) + Double.Parse(thue))
                        {
                            XtraMessageBox.Show("Tổng tiền có thuế và chưa thuế không đúng vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            F.getloi("1");
                            return;
                        }
                    }
                    else if (Double.Parse(ViewVAT.Columns["Thành tiền"].SummaryText) != Double.Parse(tongthanhtien))
                    {
                        XtraMessageBox.Show("Tổng tiền thuế không đúng vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        F.getloi("1");
                        return;
                    }

                    string congno = "0";
                    string loaixuatchuyen = "0";
                    try
                    {
                        congno = txtcn.EditValue.ToString().Replace(".", "");
                    }
                    catch { }

                    string nv = "NULL";
                    try
                    {
                        nv = "'" + gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + lenv.EditValue.ToString() + "'") + "'";
                    }
                    catch { }

                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from DDH where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledvn.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            //XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        /*try
                        {*/
                        gen.ExcuteNonquery("insert into DDH(RefID,RefDate,RefNo,AccountingObjectID,AccountingObjectCode,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,InStockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,ReceiveMethod,OutStockID, Sale,Stock,InOut,Factory,CostCap,PostedDate,Initialization,Notax,TotalCost,TotalTransport,OriginalRefNo,Received,Chot,Taixe,CMND,Dienthoai,GDT,RefNoCL,RefDateCL,TotalVATAmount,RefIDInvoice) values(newid(),'" + denct.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "','" + ledt.EditValue.ToString() + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dvn + "','" + cathang + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "'," + nv + ",'" + congno + "','" + tongthanhtien + "','" + thue + "','True',N'" + txtptgh.Text + "','" + dv + "','" + hangban.SelectedIndex.ToString() + "','" + xuatchuyen + "','" + chuyenkho.Checked + "',NULL,'" + giavon + "','" + dendh.EditValue.ToString() + "','" + DateTime.Now.ToString() + "','" + chgbct.Checked + "','" + bocxep + "','" + vanchuyen + "','" + txtdienthoai.Text + "','" + chnhtk.Checked + "','" + chot.Checked + "',N'" + txttaixe.Text + "',N'" + txtcmnd.Text + "','" + txtsdttaixe.Text + "','" + legd.EditValue.ToString() + "','" + phieucl + "','" + ngaygiadieu + "','" + phikhac + "','" + chvctc.Checked + "')");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("insert into DDH(RefID,RefDate,RefNo,AccountingObjectID,AccountingObjectCode,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,InStockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,ReceiveMethod,OutStockID,Sale,Stock,InOut,Factory,CostCap,PostedDate,Initialization) values(newid(),'" + denct.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "','" + ledt.EditValue.ToString() + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dvn + "','" + cathang + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + congno + "','" + tongthanhtien + "','" + thue + "','True',N'" + txtptgh.Text + "','" + dv + "','" + hangban.SelectedIndex.ToString() + "','" + xuatchuyen + "','" + chuyenkho.Checked + "',NULL,'" + giavon + "','" + dendh.EditValue.ToString() + "','" + DateTime.Now.ToString() + "')");
                        }*/

                        string refid = gen.GetString("select RefID from DDH where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                       
                        for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                        {
                            sql = sql+ "insert into DDHDetail(SortOrder,RefDetailID,RefID,InventoryItemID,Quantity,QuantityConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,CustomField5,UnitPriceConvert,ConvertRate,Unit,UnitPriceOC,AmountOC,DiscountRate,UnitPriceConvertOC,DGPhi,PhiKhac) values('" + i + "',newid(),'" + refid + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "','" + detail[i, 18] + "', '" + detail[i, 19] + "', '" + detail[i, 20] + "', '" + detail[i, 21] + "', '" + detail[i, 22] + "');";
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
                        if (sql != "")
                            gen.ExcuteNonquery(sql);
                    }
                    else
                    {
                        /*try
                        {*/
                            gen.ExcuteNonquery("update DDH set PostedDate='" + dendh.EditValue.ToString() + "',RefDate='" + denct.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectCode=N'" + ledt.EditValue.ToString() + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeIDSA=" + nv + ",CostCap='" + giavon + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',ReceiveMethod=N'" + txtptgh.Text + "',TotalFreightAmount='" + congno + "',OutStockID='" + dv + "', Sale='" + hangban.SelectedIndex.ToString() + "',InOut='" + chuyenkho.Checked + "', AccountingObjectType='" + cathang + "', Notax='" + chgbct.Checked + "',TotalCost='" + bocxep + "',TotalTransport='" + vanchuyen + "',OriginalRefNo='" + txtdienthoai.Text + "',Received='" + chnhtk.Checked + "', Chot='" + chot.Checked + "', Taixe=N'" + txttaixe.Text + "',CMND=N'" + txtcmnd.Text + "',Dienthoai='" + txtsdttaixe.Text + "',GDT='" + legd.EditValue.ToString() + "',RefNoCL='" + phieucl + "',RefDateCL='" + ngaygiadieu + "',TotalVATAmount='" + phikhac + "',RefIDInvoice='" + chvctc.Checked + "'  where RefID='" + role + "'");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("update DDH set PostedDate='" + dendh.EditValue.ToString() + "',RefDate='" + denct.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectCode=N'" + ledt.EditValue.ToString() + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,CostCap='" + giavon + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',ReceiveMethod=N'" + txtptgh.Text + "',TotalFreightAmount='" + congno + "',OutStockID='" + dv + "', Sale='" + hangban.SelectedIndex.ToString() + "',InOut='" + chuyenkho.Checked + "', AccountingObjectType='" + cathang + "'  where RefID='" + role + "'");
                        }*/
                            if (hangcat.Checked == false)
                            {
                                if (xuatchuyen != -1)
                                {
                                    if (gen.GetString("select Province from Stock where StockID='" + dv + "'") == gen.GetString("select Province from Stock where StockID='" + dvn + "'"))
                                    {
                                        loaixuatchuyen = "1";
                                        if (gen.GetString("select Stock from DDH where RefID='" + role + "'") == "-1")
                                        {
                                            themsctchuyen(ngaychungtu, txtsctchuyen, ledv.EditValue.ToString(), "0");
                                            themsctnhan(ngaychungtu, txtsctnhan, ledvn.EditValue.ToString(), "0");
                                            gen.ExcuteNonquery("insert into INTransfer(RefID,RefType,RefDate,PostedDate,RefNo,RefNoIn,AccountingObjectID,AccountingObjectName,Contactname,JournalMemo,Posted,OutwardStockID,InwardStockID,ShippingNo,TotalAmount,CostAmount,No,InvSeries,InvNo,InvDate,UserID,IsExport,RefSUID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denct.EditValue.ToString() + "','" + txtsctchuyen.Text + "','" + txtsctnhan.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + dvn + "',N'" + txtptvc.Text + "','" + giavon + "',0,'','','','" + denct.EditValue.ToString() + "','" + userid + "','" + chuyenkho.Checked + "','" + role + "')");
                                            gen.ExcuteNonquery("update DDH set Factory='False', Handling='" + DateTime.Now.ToString() + "',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                        }
                                        else
                                        {
                                            gen.ExcuteNonquery("update INTransfer set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denct.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',OutwardStockID='" + dv + "',InwardStockID='" + dvn + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',TotalAmount='" + giavon + "',CostAmount='0',UserID='" + userid + "',IsExport='" + chuyenkho.Checked + "'  where RefSUID='" + role + "'");
                                            gen.ExcuteNonquery("update DDH set Factory='False',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                        }
                                        rolexuat = gen.GetString("select RefID from INTransfer where RefSUID='" + role + "'");
                                    }
                                    else
                                    {
                                        if (gen.GetString("select Stock from DDH where RefID='" + role + "'") == "-1")
                                        {
                                            themsctchuyen(ngaychungtu, txtsctchuyen, ledv.EditValue.ToString(), "1");
                                            themsctnhan(ngaychungtu, txtsctnhan, ledvn.EditValue.ToString(), "1");
                                            gen.ExcuteNonquery("insert into INTransferBranch(RefID,RefType,RefDate,PostedDate,RefNo,RefNoIn,AccountingObjectID,AccountingObjectName,Contactname,JournalMemo,Posted,OutwardStockID,InwardStockID,ShippingNo,TotalAmount,CostAmount,No,InvSeries,InvNo,InvDate,UserID,IsExport,RefSUID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denct.EditValue.ToString() + "','" + txtsctchuyen.Text + "','" + txtsctnhan.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + dvn + "',N'" + txtptvc.Text + "','" + giavon + "',0,'','','','" + denct.EditValue.ToString() + "','" + userid + "','" + chuyenkho.Checked + "','" + role + "')");
                                            gen.ExcuteNonquery("update DDH set Factory='True', Handling='" + DateTime.Now.ToString() + "',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                        }
                                        else
                                        {
                                            gen.ExcuteNonquery("update INTransferBranch set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denct.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',OutwardStockID='" + dv + "',InwardStockID='" + dvn + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',TotalAmount='" + giavon + "',CostAmount='0',UserID='" + userid + "',IsExport='" + chuyenkho.Checked + "'  where RefSUID='" + role + "'");
                                            gen.ExcuteNonquery("update DDH set Factory='True',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                        }
                                        rolexuat = gen.GetString("select RefID from INTransferBranch where RefSUID='" + role + "'");
                                    }
                                }
                                /*
                                DataTable hangchuyen = gen.GetTable("select InventoryItemID,Quantity,QuantityConvert from DDHDetail where RefID='" + role + "' ");
                                for (int z = 0; z < hangchuyen.Rows.Count; z++)
                                {
                                    for (int j = 0; j < hangton.Rows.Count; j++)
                                    {
                                        if (hangchuyen.Rows[z][0].ToString().ToLower() == hangton.Rows[j][0].ToString().ToLower())
                                        {
                                            hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) + Double.Parse(hangchuyen.Rows[z][1].ToString());
                                            hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) + Double.Parse(hangchuyen.Rows[z][2].ToString());
                                            break;
                                        }
                                    }
                                }    
                                */
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
                            else
                            {
                                if (xuatchuyen != -1)
                                {
                                    if (gen.GetString("select Province from Stock where StockID='" + dv + "'") == gen.GetString("select Province from Stock where StockID='" + dvn + "'"))
                                    {
                                        if (gen.GetString("select Stock from DDH where RefID='" + role + "'") == "-1")
                                            gen.ExcuteNonquery("update DDH set Factory='False', Handling='" + DateTime.Now.ToString() + "',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                        else
                                            gen.ExcuteNonquery("update DDH set Factory='False',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");

                                        gen.ExcuteNonquery("delete  from  INTransferDetail where RefID=(select RefID from INTransfer where RefSUID='" + role + "')");
                                        gen.ExcuteNonquery("delete  from  INTransfer where RefID=(select RefID from INTransfer where RefSUID='" + role + "')");                         
                                    }
                                    else
                                    {
                                        if (gen.GetString("select Stock from DDH where RefID='" + role + "'") == "-1")
                                            gen.ExcuteNonquery("update DDH set Factory='True', Handling='" + DateTime.Now.ToString() + "',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");
                                        else
                                            gen.ExcuteNonquery("update DDH set Factory='True',Stock='" + xuatchuyen + "' where RefID='" + role + "' ");

                                        gen.ExcuteNonquery("delete  from  INTransferBranchDetail where RefID=(select RefID from INTransferBranch where RefSUID='" + role + "')");
                                        gen.ExcuteNonquery("delete  from  INTransferBranch where RefID=(select RefID from INTransferBranch where RefSUID='" + role + "')");                                       
                                    }
                                }

                                gen.ExcuteNonquery("delete  from  DDHDetail where RefID='" + role + "'");    

                                for (int i = 0; i < ViewVAT.RowCount - 1; i++)
                                {
                                    sql = sql + "insert into DDHDetail(SortOrder,RefDetailID,RefID,InventoryItemID,Quantity,QuantityConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,CustomField5,UnitPriceConvert,ConvertRate,Unit,UnitPriceOC,AmountOC,DiscountRate,UnitPriceConvertOC,DGPhi,PhiKhac) values('" + i + "',newid(),'" + role + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "','" + detail[i, 16] + "','" + detail[i, 17] + "','" + detail[i, 18] + "', '" + detail[i, 19] + "', '" + detail[i, 20] + "', '" + detail[i, 21] + "', '" + detail[i, 22] + "');";
                                }
                                if (sql != "")
                                    gen.ExcuteNonquery(sql);
                            }
                    }
                    F.getactive("1");
                    //F.gethangton(hangton);
                }
            }
            catch
            {
                F.getloi("1");
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void themsctchuyen(string ngaychungtu, TextEdit txtsct, string ledv, string loai)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkho = gen.GetString("select * from Stock where StockCode='" + ledv + "'");
            string dv = gen.GetString("select BranchCode from Branch a, Stock b where a.BranchID=b.BranchID and b.StockCode='" + ledv + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = null;
            if (loai == "0")
                sophieu = dv + "-" + ledv + "-XKNB";
            else
                sophieu = dv + "-" + ledv + "-XHGB";

            try
            {
                string id = null;
                if (loai == "0")
                    id = gen.GetString("select Top 1 RefNo from INTransfer where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID='" + idkho + "'  order by RefNo DESC");
                else
                    id = gen.GetString("select Top 1 RefNo from INTransferBranch where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and OutwardStockID='" + idkho + "'  order by RefNo DESC");
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

        public void themsctnhan(string ngaychungtu, TextEdit txtsctn, string ledvn, string loai)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkhon = gen.GetString("select * from Stock where StockCode='" + ledvn + "'");
            string dvn = gen.GetString("select BranchCode from Branch a, Stock b where a.BranchID=b.BranchID and b.StockCode='" + ledvn + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieuvo=null;
            if (loai == "0")
                sophieuvo = dvn + "-" + ledvn + "-NKNB";
            else
                sophieuvo = dvn + "-" + ledvn + "-NHGB";
            try
            {
                string id = null;
                if (loai == "0")
                    id = gen.GetString("select Top 1 RefNoIn from INTransfer where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID='" + idkhon + "'  order by RefNoIn DESC");
                else
                    id = gen.GetString("select Top 1 RefNoIn from INTransferBranch where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InwardStockID='" + idkhon + "'  order by RefNoIn DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieuvo = sophieuvo + "0";
                }
                sophieuvo = sophieuvo + ct.ToString() + nam;
            }
            catch { sophieuvo = sophieuvo + "00001" + nam; }
            txtsctn.Text = sophieuvo;
        }

        public void tsbtdeletepxk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Chot from DDH where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được chốt vui lòng liên hệ đơn vị cung ứng tháo chốt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (gen.GetString("select InOut from DDH where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã chuyển kho hoàn tất không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa đơn đặt hàng " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string phieucl = gen.GetString("select RefNoCL from DDH where RefID='" + name + "'");
                    if (phieucl != "")
                        gen.ExcuteNonquery("update DDHCL set TotalTransport=TotalTransport-(select SUM(QuantityConvertExits) from DDHDetail where RefID='" + name + "' ) where RefNo='" + phieucl + "'");

                    gen.ExcuteNonquery("insert DDHBK select *,GETDATE() from DDH where RefID='" + name + "'");
                    gen.ExcuteNonquery("insert DDHDetailBK select * from DDHDetail where RefID='" + name + "'");

                    gen.ExcuteNonquery("delete from DDH where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from DDHDetail where RefID='" + name + "'");

                    gen.ExcuteNonquery("delete  from  INTransferDetail where RefID in (select RefID from INTransfer where RefSUID='" + name + "')");
                    gen.ExcuteNonquery("delete  from  INTransfer where RefSUID='" + name + "'");

                    gen.ExcuteNonquery("delete  from  INTransferBranchDetail where RefID in (select RefID from INTransferBranch where RefSUID='" + name + "')");
                    gen.ExcuteNonquery("delete  from  INTransferBranch where RefSUID='" + name + "'");

                    view.DeleteRow(view.FocusedRowHandle);
                }                       
            }
            catch { XtraMessageBox.Show("Vui lòng chọn đơn đặt hàng trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public void tsbtdeletepcl(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Đã sử dụng").ToString()) != 0)
                {
                    XtraMessageBox.Show("Phiếu đã được chuyển sang đơn đặt hàng bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa đơn đặt hàng " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete DDHCL where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn đơn hàng chia lượng trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public void themsctpxk(string ngaychungtu, TextEdit txtsct, string mk, string branchid)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PXKH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
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

        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from DDH where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InStockID='" + idkho + "' ");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from DDH where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InStockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_ddh F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from DDH where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and InStockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from DDH where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and InStockID='" + idkho + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_ddh F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from DDH where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and InStockID='" + idkho + "'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from DDH where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and InStockID='" + idkho + "' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }
    }
}
