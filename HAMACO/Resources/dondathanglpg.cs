using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
namespace HAMACO.Resources
{
    class dondathanglpg
    {
        gencon gen = new gencon();
        public void loadddh(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu, string userid, string tsbt)
        {
            string sql = "select RefID,RefNo,RefDate,RefOrder,a.AccountingObjectName,JournalMemo,IsExport,Cancel,StockCode,Tax,Round(TotalAmount*1.1,0)-TotalFreightAmount,ShippingNo,AccountingObjectCode,a.AccountingObjectAddress,FullName,UserCheck,a.EmployeeID,TotalFreightAmount,a.CustomField2,a.CustomField6,a.District,a.CustomField3,a.CustomField4 from INOutwardLPG a, Stock b, AccountingObject c, MSC_User d where a.EmployeeID=d.Userid and a.AccountingObjectID=c.AccountingObjectID and a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') and Cancel='True' order by RefNo";
            view.OptionsView.ColumnAutoWidth = false;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Ngày chứng từ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hạch toán", Type.GetType("System.DateTime"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Địa chỉ", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("Thuế", Type.GetType("System.String"));
            dt.Columns.Add("Tổng tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Hủy", Type.GetType("System.String"));
            
            dt.Columns.Add("Hóa đơn", Type.GetType("System.Boolean"));
            dt.Columns.Add("Người lập", Type.GetType("System.String"));
            dt.Columns.Add("Người duyệt", Type.GetType("System.String"));
            dt.Columns.Add("User", Type.GetType("System.String"));

            dt.Columns.Add("Tài xế", Type.GetType("System.String"));
            dt.Columns.Add("Giao nhận", Type.GetType("System.String"));

            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));
            dt.Columns.Add("Tuyến", Type.GetType("System.String"));

            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));       
            
            
            dt.Columns.Add("Chọn", Type.GetType("System.Boolean"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][12].ToString();
                dr[5] = temp.Rows[i][4].ToString();
                dr[6] = temp.Rows[i][13].ToString();
                dr[7] = temp.Rows[i][5].ToString();
                dr[8] = temp.Rows[i][9].ToString();
                dr[9] = temp.Rows[i][10].ToString();

                dr[10] = temp.Rows[i][17].ToString();

                dr[11] = temp.Rows[i][8].ToString();
                if (temp.Rows[i][6].ToString() == "True")
                    dr[13] = "True";
                else
                    dr[13] = "False";

                if (DateTime.Parse(temp.Rows[i][3].ToString()).Hour >= 15)
                    dr[12] = "1";               
                
                dr[14] = temp.Rows[i][14].ToString();
                dr[15] = temp.Rows[i][15].ToString();

                dr[16] = temp.Rows[i][16].ToString();
                dr[17] = temp.Rows[i][11].ToString();       
                dr[18] = temp.Rows[i][18].ToString();

                dr[19] = temp.Rows[i][19].ToString();
                dr[20] = temp.Rows[i][20].ToString();
                if (temp.Rows[i][21].ToString() != "")
                    dr[21] = temp.Rows[i][21].ToString();
                if (temp.Rows[i][22].ToString() != "")
                    dr[22] = temp.Rows[i][22].ToString();

                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = true;
            //view.OptionsSelection.EnableAppearanceFocusedCell = false;
            //view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[12].Visible = false;
            view.Columns[16].Visible = false;
            view.Columns["Hạch toán"].Visible = false;
            view.Columns[8].Width = 50;
            view.Columns[8].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày chứng từ"].Width = 100;
            view.Columns["Ngày chứng từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hạch toán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Hạch toán"].DisplayFormat.FormatString = "hh:mm:ss";
            view.Columns["Hạch toán"].Width = 100;
            view.Columns["Hạch toán"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].Width = 100;
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Người duyệt"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Tổng tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tổng tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tổng tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tổng tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chiết khấu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chiết khấu"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[9].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số chứng từ"].Width = 150;
            view.Columns["Hóa đơn"].Width = 60;
            view.Columns["Chọn"].Width = 40;
            view.Columns["Mã kho"].GroupIndex = 0;

            view.Columns["Số chứng từ"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Ngày chứng từ"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Hạch toán"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Hóa đơn"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            view.Columns["Chọn"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Trọng lượng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Số lượng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Tuyến"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Phương tiện"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Giao nhận"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            view.Columns["Tài xế"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;

            view.Columns[0].OptionsColumn.AllowEdit = false;
            view.Columns[1].OptionsColumn.AllowEdit = false;
            view.Columns[2].OptionsColumn.AllowEdit = false;
            view.Columns[3].OptionsColumn.AllowEdit = false;
            view.Columns[4].OptionsColumn.AllowEdit = false;
            view.Columns[5].OptionsColumn.AllowEdit = false;
            view.Columns[6].OptionsColumn.AllowEdit = false;
            view.Columns[7].OptionsColumn.AllowEdit = false;
            view.Columns[8].OptionsColumn.AllowEdit = false;
            view.Columns[9].OptionsColumn.AllowEdit = false;
            view.Columns[10].OptionsColumn.AllowEdit = false;
            view.Columns[11].OptionsColumn.AllowEdit = false;
            view.Columns[12].OptionsColumn.AllowEdit = false;
            view.Columns[13].OptionsColumn.AllowEdit = false;
            view.Columns[14].OptionsColumn.AllowEdit = false;
            view.Columns[15].OptionsColumn.AllowEdit = false;
            view.Columns[16].OptionsColumn.AllowEdit = false;
            view.Columns[17].OptionsColumn.AllowEdit = false;
            view.Columns[18].OptionsColumn.AllowEdit = false;
            view.Columns[19].OptionsColumn.AllowEdit = false; 
            view.Columns[20].OptionsColumn.AllowEdit = false;
            view.Columns[21].OptionsColumn.AllowEdit = false;
            view.Columns[22].OptionsColumn.AllowEdit = false;
            view.Columns["Chọn"].OptionsColumn.AllowEdit = true;

            view.ExpandAllGroups();
        }

        public void tsbtddh(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang,DataTable giaban)
        {
            try
            {
                ddhgas u = new ddhgas();
                u.myac = new ddhgas.ac(F.refreshddhlpg);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getpt("pxk");
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.getkhach(khach);
                u.gethang(hang);
                u.getgiaban(giaban);

                if (a == "1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                else
                {
                    try
                    {
                        u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());
                    }
                    catch
                    {
                        u.getrole(gen.GetString("select Top 1 StockCode from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode"));
                    }
                }

                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn đơn đặt hàng trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, ComboBoxEdit cbthue, LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau, DataTable khach, DataTable hang, DevExpress.XtraGrid.GridControl gridControl2, GridView gridView2, DataTable dt1, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit congty, DevExpress.XtraGrid.GridControl gridQT, GridView viewQT, ComboBoxEdit cbpt, ComboBoxEdit cblkh, ComboBoxEdit cbptgh, ComboBoxEdit cbgiaonhan, DevExpress.XtraGrid.GridControl goiden, GridView gridView7, ComboBoxEdit cbtinh)
        {
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = true;
            tsbtboghi.Enabled = true;
            tsbtghiso.Enabled = true;
            tsbtnap.Enabled = true;
            tsbtxoa.Enabled = true;
            tsbtsua.Enabled = true;
            tsbtin.Enabled = true;

            cbtinh.Properties.Items.Clear();
            DataTable tinh = gen.GetTable("select distinct Province from ProvinceFull order by Province");
            for (int i = 0; i < tinh.Rows.Count; i++)
                cbtinh.Properties.Items.Add(tinh.Rows[i][0].ToString());
            tinh.Dispose();

            cbldt.Properties.Items.Clear();
            cbldt.Properties.Items.Add("Khách hàng");
            cbldt.Properties.Items.Add("Nhà cung cấp");
            cbldt.Properties.Items.Add("Nhân viên");
            cbldt.SelectedIndex = 0;

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");
            cbthue.SelectedIndex = 2;


            cbgiaonhan.Properties.Items.Clear();
            cbgiaonhan.Properties.Items.Add("ĐOÀN VĂN ĐẠT");
            cbgiaonhan.Properties.Items.Add("Lê Trung Nghĩa");
            cbgiaonhan.Properties.Items.Add("LÝ CHÍ THẢO");
            cbgiaonhan.Properties.Items.Add("Mai Đình Hướng");
            cbgiaonhan.Properties.Items.Add("Nguyễn Anh Khoa");
            cbgiaonhan.Properties.Items.Add("NGUYỄN CÔNG VĂN");
            cbgiaonhan.Properties.Items.Add("NGUYỄN ĐÔNG GIANG");
            cbgiaonhan.Properties.Items.Add("Nguyễn Phúc Hậu");
            cbgiaonhan.Properties.Items.Add("Nguyễn Hữu Tấn");
            cbgiaonhan.Properties.Items.Add("Nguyễn Văn Ngọc"); 
            cbgiaonhan.Properties.Items.Add("Phan Thành Trung");
            cbgiaonhan.Properties.Items.Add("Thạch Khanh");
            cbgiaonhan.Properties.Items.Add("THÁI TRUNG HẬU");            
           
           
            cbgiaonhan.SelectedIndex = -1;


            cbpt.Properties.Items.Clear();

            cbpt.Properties.Items.Add("Dương Thanh Châu");
            cbpt.Properties.Items.Add("ĐẶNG QUANG HOÀNG PHÚC");
            cbpt.Properties.Items.Add("ĐOÀN VĂN ĐẠT");
            cbpt.Properties.Items.Add("Lê Quốc Tuấn");
            cbpt.Properties.Items.Add("LÝ CHÍ THẢO");
            cbpt.Properties.Items.Add("Mai Vĩnh Xuyên");
            cbpt.Properties.Items.Add("NGÔ MẠNH TUẤN");
            cbpt.Properties.Items.Add("NGUYỄN ĐÔNG GIANG");
            cbpt.Properties.Items.Add("NGUYỄN MINH TRIỀU");
            cbpt.Properties.Items.Add("Nguyễn Phúc Hậu");
            cbpt.Properties.Items.Add("Nguyễn Quan Phương");
            cbpt.Properties.Items.Add("Nguyễn Thanh Sang");
            cbpt.Properties.Items.Add("NGUYỄN THANH HÙNG");
            cbpt.Properties.Items.Add("Nguyễn Thành Nghĩa");
            cbpt.Properties.Items.Add("NGUYỄN VĂN THĂM");
            cbpt.Properties.Items.Add("Thạch Khanh");
            cbpt.Properties.Items.Add("THÁI TRUNG HẬU");
            cbpt.Properties.Items.Add("THÁI VĂN BẰNG");
            cbpt.Properties.Items.Add("THÁI VĂN TUỆ");
            cbpt.Properties.Items.Add("Trần Anh Đức");
            cbpt.Properties.Items.Add("TRẦN CHÍ LINH");
            cbpt.Properties.Items.Add("Trần Văn Kiệt");     
            
            cbpt.SelectedIndex = -1;


            cbptgh.Properties.Items.Clear();
            cbptgh.Properties.Items.Add("65C 01957");
            cbptgh.Properties.Items.Add("65C 01994");     
            cbptgh.Properties.Items.Add("65C 03771");
            cbptgh.Properties.Items.Add("65C 04847");
            cbptgh.Properties.Items.Add("65C 04962");
            cbptgh.Properties.Items.Add("65C 05132");
            cbptgh.Properties.Items.Add("65C 6126");
            cbptgh.Properties.Items.Add("65C 08559");

            cbptgh.Properties.Items.Add("65N 0285");
            cbptgh.Properties.Items.Add("65N 1443");
            cbptgh.Properties.Items.Add("65M 2064");
            cbptgh.Properties.Items.Add("65M 2856");
            
            cbptgh.SelectedIndex = -1;

            cblkh.Properties.Items.Clear();
            cblkh.Properties.Items.Add("Bán lẻ");
            cblkh.Properties.Items.Add("Quán ăn");
            cblkh.Properties.Items.Add("Nhà hàng");
            cblkh.SelectedIndex = -1;

            DataTable da = new DataTable();
            DataTable temp = new DataTable();

            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            da = gen.GetTable("select * from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;
            ledv.ItemIndex = 0;

            DataTable temp3 = new DataTable();
            temp3.Columns.Add("Mã hàng");
            temp3.Columns.Add("Tên hàng");
            for (int i = 0; i < hang.Rows.Count; i++)
            {
                DataRow dr = temp3.NewRow();
                dr[0] = hang.Rows[i][1].ToString();
                dr[1] = hang.Rows[i][2].ToString();
                temp3.Rows.Add(dr);
            }
            mahang.DataSource = temp3;
            mahang.DisplayMember = "Mã hàng";
            mahang.ValueMember = "Mã hàng";
            mahang.PopupWidth = 300;

            DataTable temp5 = new DataTable();
            temp5.Columns.Add("Công ty");
            temp5.Rows.Add("HAMACO");
            temp5.Rows.Add("Thiên An");
            temp5.Rows.Add("Dịch vụ HAMACO");
            congty.DataSource = temp5;
            congty.DisplayMember = "Công ty";
            congty.ValueMember = "Công ty";
            congty.PopupWidth = 100;

            DataTable temp4 = new DataTable();
            temp4.Columns.Add("Mã nhân viên");
            temp4.Columns.Add("Tên nhân viên");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp4.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp4.Rows.Add(dr);
            }
            lenv.Properties.DataSource = temp4;
            lenv.Properties.DisplayMember = "Mã nhân viên";
            lenv.Properties.ValueMember = "Mã nhân viên";
            lenv.Properties.PopupWidth = 300;

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền CK", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng tồn", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi tồn", Type.GetType("System.Double"));
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Phí khác", Type.GetType("System.Double"));
            dt.Columns.Add("Ghi chú", Type.GetType("System.String"));
            dt.Columns.Add("Công ty", Type.GetType("System.String"));
            

            gridControl1.DataSource = dt;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Công ty"].ColumnEdit = congty;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Số lượng tồn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng tồn"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi tồn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi tồn"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Số lượng quy đổi"].Caption = "Trọng lượng";

            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Chi phí"].ColumnEdit = chietkhau;
            gridView1.Columns["Tiền CK"].ColumnEdit = chiphi;
            gridView1.Columns["Chiết khấu"].ColumnEdit = chietkhau;
            gridView1.Columns["Phí khác"].ColumnEdit = chiphi;

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Chi phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chi phí"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Chi phí"].Caption = "ĐG Số lượng";

            gridView1.Columns["Phí khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Phí khác"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            gridView1.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Chiết khấu"].Caption = "Đơn giá BX";

            gridView1.Columns["Tiền CK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Tiền CK"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Tiền CK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Tiền CK"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Tiền CK"].Caption = "Bốc xếp";

            gridView1.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            //gridView1.Columns[7].Visible = false;
            //gridView1.Columns[8].Visible = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[14].Visible = false;



            dt1.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt1.Columns.Add("Tên hàng");
            dt1.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt1.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt1.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt1.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt1.Columns.Add("Chi phí", Type.GetType("System.Double"));
            dt1.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt1.Columns.Add("Tiền CK", Type.GetType("System.Double"));

            gridControl2.DataSource = dt1;
            gridView2.Columns["Số lượng"].ColumnEdit = soluong;
            gridView2.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;

            gridView2.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView2.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView2.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView2.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";
            gridView2.Columns["Số lượng quy đổi"].Caption = "Trọng lượng";

            gridView2.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView2.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView2.Columns["Chi phí"].ColumnEdit = chiphi;
            gridView2.Columns["Chiết khấu"].ColumnEdit = chietkhau;

            gridView2.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            gridView2.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView2.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView2.Columns["Chi phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Chi phí"].DisplayFormat.FormatString = "{0:n0}";
            gridView2.Columns["Chi phí"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Chi phí"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView2.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView2.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            gridView2.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n2}";

            gridView2.Columns["Tiền CK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView2.Columns["Tiền CK"].DisplayFormat.FormatString = "{0:n0}";
            gridView2.Columns["Tiền CK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Tiền CK"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView2.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["Số lượng"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["Số lượng quy đổi"].OptionsColumn.AllowEdit = false;

            gridView2.Columns[6].Visible = false;
            gridView2.Columns[7].Visible = false;
            gridView2.Columns[8].Visible = false;


            DataTable temp6 = gen.GetTable("select InventoryItemID as 'Mã hàng',InventoryItemName as 'Tên hàng',unit as 'ĐVT', 0 as 'Số lượng' from InventoryItem where IsSystem='True' order by InventoryItemName");
            gridQT.DataSource = temp6;
            viewQT.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            viewQT.Columns["ĐVT"].OptionsColumn.AllowEdit = false;
            viewQT.Columns["Số lượng"].ColumnEdit = soluong;
            viewQT.Columns["ĐVT"].Width = 50;
            viewQT.Columns["Số lượng"].Width = 50;
            viewQT.Columns[0].Visible = false;
            viewQT.Columns["ĐVT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt2.Columns.Add("Số điện thoại");
            dt2.Columns.Add("Tên khách", Type.GetType("System.String"));
            dt2.Columns.Add("Địa chỉ", Type.GetType("System.String"));
            dt2.Columns.Add("Mặt hàng đã sử dụng", Type.GetType("System.String"));
            dt2.Columns.Add("Ghi chú", Type.GetType("System.String"));
            dt2.Columns.Add("Đối tượng", Type.GetType("System.String"));
            dt2.Columns.Add("Mã kho", Type.GetType("System.String"));

            dt2.Columns.Add("Tỉnh", Type.GetType("System.String"));
            dt2.Columns.Add("Huyện", Type.GetType("System.String"));
            dt2.Columns.Add("Xã", Type.GetType("System.String"));
            dt2.Columns.Add("Địa chỉ con", Type.GetType("System.String"));

            goiden.DataSource = dt2;
            gridView7.Columns[0].Visible = false;
            //gridView7.Columns[6].Visible = false;
            gridView7.Columns[7].Visible = false;
            //gridView7.Columns[8].Visible = false;
            gridView7.Columns[9].Visible = false;
            gridView7.Columns[10].Visible = false;
            gridView7.Columns[11].Visible = false;
            gridView7.Columns["Số điện thoại"].Width = 40;
            gridView7.Columns["Đối tượng"].Width = 30;
            gridView7.Columns["Số điện thoại"].OptionsColumn.AllowEdit = false;
            gridView7.Columns["Mặt hàng đã sử dụng"].OptionsColumn.AllowEdit = false;
        }

        public void loadpxk(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, ddhgas F, LookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, TextEdit txtcth, ComboBoxEdit cbthue
            , LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, TextEdit txtthue, DevExpress.XtraGrid.GridControl gridControl2, GridView gridView2, TextEdit txtten, TextEdit txtdc, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit congty, TextEdit txthamaco, TextEdit txtthienan, TextEdit txtdichvu, DevExpress.XtraGrid.GridControl gridQT, GridView viewQT, TextEdit txtsdt, SplitContainerControl split, ComboBoxEdit cbpt, ComboBoxEdit cblkh, LabelControl lbduyet, CheckEdit chduyet, ComboBoxEdit cbptgh, TextEdit txtphitaixe, TextEdit txtphigiaonhan, ComboBoxEdit cbgiaonhan, TextEdit txtdienthoai, DevExpress.XtraGrid.GridControl goiden, GridView gridView7, TextEdit txtck, ComboBoxEdit cbtinh, ComboBoxEdit cbhuyen, ComboBoxEdit cbxa,TextEdit txtdcc)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dongia, thanhtien, cbthue, lenv, chiphi, chietkhau, khach, hang, gridControl2, gridView2, dt1, congty, gridQT, viewQT, cbpt, cblkh, cbptgh, cbgiaonhan, goiden, gridView7, cbtinh);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  InventoryItemCode,Quantity,QuantityConvert,a.ConvertRate,InventoryItemName,a.UnitPriceOC,a.AmountOC,a.UnitPriceConvert,a.UnitPriceConvertOC,QuantityExits,QuantityConvertExits,RefDetailID,a.UnitPrice,a.Amount,DiscountRate,DiscountAmount,Cost,a.CustomField1,Description,a.CustomField4,a.CustomField5,DGPhi from INOutwardLPGDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][4].ToString();
                    dr[2] = da.Rows[i][1].ToString();
                    dr[3] = da.Rows[i][2].ToString();
                    dr[4] = da.Rows[i][7].ToString();
                    dr[5] = da.Rows[i][5].ToString();
                    dr[6] = da.Rows[i][6].ToString();
                    dr[7] = da.Rows[i][3].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    dr[9] = da.Rows[i][9].ToString();
                    dr[10] = da.Rows[i][10].ToString();
                    dr[11] = da.Rows[i][11].ToString();
                    dr[12] = "0";
                    if (da.Rows[i][21].ToString() != "")
                        dr[12] = da.Rows[i][21].ToString();
                    dr[13] = da.Rows[i][17].ToString();
                    dr[14] = da.Rows[i][18].ToString();
                    txtphitaixe.EditValue = Double.Parse(da.Rows[i][19].ToString());
                    txtphigiaonhan.EditValue = Double.Parse(da.Rows[i][20].ToString());
                    dt.Rows.Add(dr);

                    DataRow dr1 = dt1.NewRow();
                    dr1[0] = da.Rows[i][0].ToString();
                    dr1[1] = da.Rows[i][4].ToString();
                    dr1[2] = da.Rows[i][1].ToString();
                    dr1[3] = da.Rows[i][2].ToString();
                    dr1[4] = da.Rows[i][12].ToString();
                    dr1[5] = da.Rows[i][13].ToString();
                    dt1.Rows.Add(dr1);
                }
                gridControl1.DataSource = dt;
                gridControl2.DataSource = dt1;
                tsbtcat.Enabled = false;

                F.Text = "Xem đơn đặt hàng";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,Tax,EmployeeIDSA,TotalAmountOC,IsExport,a.AccountingObjectName,a.AccountingObjectAddress,CustomField6,RefType,CustomField8,ParalellRefNo,UserCheck,CustomField2,OriginalRefNo,TotalFreightAmount,a.Province,a.District,a.Ward,AdressSon  from INOutwardLPG a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                txtck.EditValue = Double.Parse(da.Rows[0][25].ToString());

                if (da.Rows[0][26].ToString() != "")
                    cbtinh.EditValue = da.Rows[0][26].ToString();
                if (da.Rows[0][27].ToString() != "")
                    cbhuyen.EditValue = da.Rows[0][27].ToString();
                if (da.Rows[0][28].ToString() != "")
                    cbxa.EditValue = da.Rows[0][28].ToString();
                txtdcc.Text = da.Rows[0][29].ToString();

                txtdienthoai.Text = da.Rows[0][24].ToString();
                lbduyet.Text = da.Rows[0][22].ToString();
                if (da.Rows[0][22].ToString() != "")
                {
                    chduyet.Checked = true;
                    chduyet.Enabled = false;
                }
                else
                    chduyet.Checked = false;

                //txtgiaonhan.Text = da.Rows[0][23].ToString();
                cbgiaonhan.EditValue = da.Rows[0][23].ToString();

                cblkh.Text = da.Rows[0][21].ToString();
                try
                {
                    cbldt.SelectedIndex = Int32.Parse(da.Rows[0][9].ToString());
                }
                catch { }
                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                try
                {
                    txtldn.Text = da.Rows[0][2].ToString();
                }
                catch { }
                txtctg.Text = da.Rows[0][3].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][6].ToString();
                try
                {
                    txthamaco.Text = gen.GetString("select distinct RefNo from hamaco.dbo.INOutward where INOutwardRefID='" + role + "'");
                }
                catch { txthamaco.Text = null; }
                try
                {
                    txtthienan.Text = gen.GetString("select distinct RefNo from hamaco_ta.dbo.INOutward where INOutwardRefID='" + role + "'");
                }
                catch { txtthienan.Text = null; }
                try
                {
                    txtdichvu.Text = gen.GetString("select distinct RefNo from hamaco_tn.dbo.INOutward where INOutwardRefID='" + role + "'");
                }
                catch { txtdichvu.Text = null; }

                txtngh.Text = da.Rows[0][1].ToString();

                //txtptvc.Text = da.Rows[0][11].ToString();
                cbpt.EditValue = da.Rows[0][11].ToString();
                

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
                try
                {
                    string px = gen.GetString("select RefID from SSInvoice where ShippingMethodID='" + role + "'");
                    tsbtsua.Enabled = false;
                    tsbtboghi.Enabled = false;
                }
                catch { }
                try
                {
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
                txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
                txtthue.EditValue = da.Rows[0][14].ToString();
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
                txtten.Text = da.Rows[0][16].ToString();
                txtdc.Text = da.Rows[0][17].ToString();

                //txtptgh.Text = da.Rows[0][18].ToString();
                cbptgh.EditValue = da.Rows[0][18].ToString();

                if (da.Rows[0][20].ToString() != "")
                {
                    txtsdt.Text = da.Rows[0][20].ToString();
                    txtsdt.Visible = true;
                    cbpt.Visible = true;
                    cblkh.Visible = true;
                    //split.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
                }
                else
                {
                    txtsdt.Visible = false;
                    //split.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
                }
                DataTable temp = gen.GetTable(" select InventoryItemID,Quantity from INOutwardLPGQTDetail where RefID='" + role + "'");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    for (int j = 0; j < viewQT.RowCount; j++)
                    {
                        if (temp.Rows[i][0].ToString() == viewQT.GetRowCellValue(j, "Mã hàng").ToString())
                            viewQT.SetRowCellValue(j, viewQT.Columns["Số lượng"], Double.Parse(temp.Rows[i][1].ToString()));
                    }
                }
            }
            else
            {
                F.Text = "Thêm phiếu xuất kho";
                if (role != null)
                    ledv.EditValue = role;
                //cbpt.SelectedIndex = -1;
                //txtptvc.Text = "";
                txtcth.Text = "0";
                denht.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void checkpxk(string active, string role, ddhgas F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, ComboBoxEdit cbthue, LookUpEdit lenv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txttthue, GridView gridView2, DataTable hangton, TextEdit txtptgh, TextEdit txthamaco, TextEdit txtthienan, TextEdit txtdichvu, TextEdit txtsdt, GridView viewQT, ComboBoxEdit cblkh, TextEdit txtgiaonhan, TextEdit txtphitaixe, TextEdit txtphigiaonhan, TextEdit txtdienthoai, TextEdit txtck, TextEdit txttc, ComboBoxEdit cbtinh,ComboBoxEdit cbhuyen, ComboBoxEdit cbxa, TextEdit txtdcc)
        {
            /*if (active == "0" && DateTime.Parse(DateTime.Parse(denct.EditValue.ToString()).ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ngày lập phiếu xuất kho không được nhỏ hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            try
            {
            string dtt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
            //string dt = gen.GetString("select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
            //string dt_ta = gen.GetString("select * from hamaco_ta.dbo.AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
            //string dt_tn = gen.GetString("select * from hamaco_tn.dbo.AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
     
                string[,] detail = new string[30, 25];
                /*Double[,] tong = new Double[20, 20];
                for (int j = 0; j < 3; j++)
                {
                    tong[j, 0] = 0;
                    tong[j, 1] = 0;
                    tong[j, 2] = 0;
                }*/
                string check = "0";
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == "")
                        check = "1";
                    if (gridView1.GetRowCellValue(i, "Số lượng").ToString() == "")
                        detail[i, 1] = "0";
                    else
                        detail[i, 1] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString() == "")
                        check = "1";
                    detail[i, 2] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");


                    if (gridView2.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail[i, 4] = gridView2.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView2.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 5] = gridView2.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    if (gridView2.GetRowCellValue(i, "Chi phí").ToString() == "")
                        detail[i, 6] = "0";
                    else
                        detail[i, 6] = gridView2.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView2.GetRowCellValue(i, "Chiết khấu").ToString() == "")
                        detail[i, 3] = "0";
                    else
                        detail[i, 3] = gridView2.GetRowCellValue(i, "Chiết khấu").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView2.GetRowCellValue(i, "Tiền CK").ToString() == "")
                        detail[i, 7] = "0";
                    else
                        detail[i, 7] = gridView2.GetRowCellValue(i, "Tiền CK").ToString().ToString().Replace(".", "");


                    if (gridView1.GetRowCellValue(i, "Số lượng tồn").ToString() == "")
                        detail[i, 8] = "0";
                    else
                        detail[i, 8] = gridView1.GetRowCellValue(i, "Số lượng tồn").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi tồn").ToString() == "")
                        detail[i, 9] = "0";
                    else
                        detail[i, 9] = gridView1.GetRowCellValue(i, "Số lượng quy đổi tồn").ToString().Replace(".", "").Replace(",", ".");
                    detail[i, 10] = gridView1.GetRowCellValue(i, "ID").ToString();


                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail[i, 11] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 12] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "Chi phí").ToString() == "")
                        detail[i, 15] = "0";
                    else
                        detail[i, 15] = gridView1.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Chiết khấu").ToString() == "")
                        detail[i, 13] = "0";
                    else
                        detail[i, 13] = gridView1.GetRowCellValue(i, "Chiết khấu").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Tiền CK").ToString() == "")
                        detail[i, 14] = "0";
                    else
                        detail[i, 14] = gridView1.GetRowCellValue(i, "Tiền CK").ToString().ToString().Replace(".", "");
                    
                    detail[i, 16] = gridView1.GetRowCellValue(i, "Công ty").ToString();                   
                    detail[i, 18] = gridView1.GetRowCellValue(i, "Ghi chú").ToString();
                    detail[i, 17] = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");


                    detail[i, 0] = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");

                    if (gridView1.GetRowCellValue(i, "Phí khác").ToString() == "")
                        detail[i, 19] = "0";
                    else
                        detail[i, 19] = gridView1.GetRowCellValue(i, "Phí khác").ToString().ToString().Replace(".", "");

                    /*if (detail[i, 16] == "HAMACO")
                    {
                        detail[i, 0] = gen.GetString("select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        try
                        {
                            tong[0, 0] = tong[0, 0] + Double.Parse(gridView2.GetRowCellValue(i, "Thành tiền").ToString());
                        }
                        catch { }
                        try
                        {
                            tong[0, 1] = tong[0, 1] + Double.Parse(gridView2.GetRowCellValue(i, "Tiền CK").ToString());
                        }
                        catch { }
                        tong[0, 2] = Math.Round(tong[0, 0] / 10, 0);
                    }
                    else if (detail[i, 16] == "Thiên An")
                    {
                        detail[i, 0] = gen.GetString("select * from hamaco_ta.dbo.InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        try
                        {
                            tong[1, 0] = tong[1, 0] + Double.Parse(gridView2.GetRowCellValue(i, "Thành tiền").ToString());
                        }
                        catch { }
                        try
                        {
                            tong[1, 1] = tong[1, 1] + Double.Parse(gridView2.GetRowCellValue(i, "Tiền CK").ToString());
                        }
                        catch { }
                        tong[1, 2] = Math.Round(tong[1, 0] / 10, 0);
                    }
                    else if (detail[i, 16] == "Dịch vụ HAMACO")
                    {
                        detail[i, 0] = gen.GetString("select * from hamaco_tn.dbo.InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        try
                        {
                            tong[2, 0] = tong[2, 0] + Double.Parse(gridView2.GetRowCellValue(i, "Thành tiền").ToString());
                        }
                        catch { }
                        try
                        {
                            tong[2, 1] = tong[2, 1] + Double.Parse(gridView2.GetRowCellValue(i, "Tiền CK").ToString());
                        }
                        catch { }
                        tong[2, 2] = Math.Round(tong[2, 0] / 10, 0);
                    }
                    else if (detail[i, 16] == "")
                        check = "1";
                     */
                }

                if (check == "1")
                {
                    F.getloi("1");
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> <Công ty> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";

                    string tongthanhtien = Math.Round(Double.Parse(gridView2.Columns["Thành tiền"].SummaryText) + Double.Parse(gridView2.Columns["Chi phí"].SummaryText), 0).ToString().Replace(".", "");
                    //string tongchiphi = gridView2.Columns["Tiền CK"].SummaryText;
                    string tongsoluong = gridView1.Columns["Số lượng"].SummaryText.Replace(".", "").Replace(",", ".");
                    string tongtrongluong = gridView1.Columns["Số lượng quy đổi"].SummaryText.Replace(".", "").Replace(",", ".");

                    string phitaixe = "0", phigiaonhan = "0", tongchiphi = "0";
                    if (txtck.Text != "")
                        tongchiphi = txtck.EditValue.ToString().Replace(".", "");                
                    if (txtphitaixe.Text != "")
                        phitaixe = txtphitaixe.EditValue.ToString().Replace(".", "");
                    if (txtphigiaonhan.Text != "")
                        phigiaonhan = txtphigiaonhan.EditValue.ToString().Replace(".", "");

                    string thue = txttthue.EditValue.ToString().Replace(".", "");

                    string tongcong = txttc.EditValue.ToString().Replace(".", "");
                    //MessageBox.Show(tongthanhtien.ToString() + "-" + thue.ToString() + "-" + tongchiphi.ToString());

                    if (Double.Parse(gridView1.Columns["Thành tiền"].SummaryText) != Double.Parse(tongcong) + Double.Parse(tongchiphi))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Tổng tiền có thuế và chưa thuế không đúng vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string nv = "NULL";
                    try
                    {
                        nv = "'" + gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + lenv.EditValue.ToString() + "'") + "'";
                    }
                    catch { }

                    if (active == "0")
                    {
                        /*try
                        {
                            string ton = gen.GetString("select * from INOutwardLPG where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }*/
                        /*try
                        {*/
                        themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                        gen.ExcuteNonquery("insert into INOutwardLPG(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField8,ParalellRefNo,RefOrder,CustomField2,OriginalRefNo,Province,District,Ward,AdressSon,CustomField3,CustomField4) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dtt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "'," + nv + ",'" + tongchiphi + "','" + tongthanhtien + "','" + thue + "','True',N'" + txtptgh.Text + "','" + txtsdt.Text + "',N'" + cblkh.Text + "','" + DateTime.Now.ToString() + "',N'" + txtgiaonhan.Text + "','" + txtdienthoai.Text + "',N'" + cbtinh.Text + "',N'" + cbhuyen.Text + "',N'" + cbxa.Text + "',N'" + txtdcc.Text + "','" + tongsoluong + "','" + tongtrongluong + "')");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("insert into INOutwardLPG(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tongchiphi + "','" + tongthanhtien + "','" + thue + "','True',N'" + txtptgh.Text + "')");
                        }*/
                        string refid = gen.GetString("select RefID from INOutwardLPG where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);

                        themsctchung(ngaychungtu, txthamaco, txtthienan, txtdichvu, ledv.EditValue.ToString(), branchid);
                        /*try
                        {*/
                        gen.ExcuteNonquery("insert into INOutward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID,RefOrder,Shipper,OriginalRefNo) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtdichvu.Text + "','" + dtt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "'," + nv + ",'" + tongchiphi + "','" + tongthanhtien + "','" + thue + "','True',N'" + txtptgh.Text + "','" + refid + "','" + DateTime.Now.ToString() + "',N'" + txtgiaonhan.Text + "','" + txtdienthoai.Text + "')");
                        //gen.ExcuteNonquery("insert into hamaco.dbo.INOutward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID,RefOrder,Shipper,OriginalRefNo) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txthamaco.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "'," + nv + ",'" + tong[0, 1] + "','" + tong[0, 0] + "','" + tong[0, 2] + "','True',N'" + txtptgh.Text + "','" + refid + "','" + DateTime.Now.ToString() + "',N'" + txtgiaonhan.Text + "','" + txtdienthoai.Text + "')");
                        //gen.ExcuteNonquery("insert into hamaco_ta.dbo.INOutward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID,RefOrder,Shipper,OriginalRefNo) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtthienan.Text + "','" + dt_ta + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "'," + nv + ",'" + tong[1, 1] + "','" + tong[1, 0] + "','" + tong[1, 2] + "','True',N'" + txtptgh.Text + "','" + refid + "','" + DateTime.Now.ToString() + "',N'" + txtgiaonhan.Text + "','" + txtdienthoai.Text + "')");
                        //gen.ExcuteNonquery("insert into hamaco_tn.dbo.INOutward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID,RefOrder,Shipper,OriginalRefNo) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtdichvu.Text + "','" + dt_tn + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "'," + nv + ",'" + tong[2, 1] + "','" + tong[2, 0] + "','" + tong[2, 2] + "','True',N'" + txtptgh.Text + "','" + refid + "','" + DateTime.Now.ToString() + "',N'" + txtgiaonhan.Text + "','" + txtdienthoai.Text + "')");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("insert into hamaco.dbo.INOutward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txthamaco.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tong[0, 1] + "','" + tong[0, 0] + "','" + tong[0, 2] + "','True',N'" + txtptgh.Text + "','" + refid + "')");
                            gen.ExcuteNonquery("insert into hamaco_ta.dbo.INOutward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtthienan.Text + "','" + dt_ta + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tong[1, 1] + "','" + tong[1, 0] + "','" + tong[1, 2] + "','True',N'" + txtptgh.Text + "','" + refid + "')");
                            gen.ExcuteNonquery("insert into hamaco_tn.dbo.INOutward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,INOutwardRefID) values(newid(),'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtdichvu.Text + "','" + dt_tn + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tong[2, 1] + "','" + tong[2, 0] + "','" + tong[2, 2] + "','True',N'" + txtptgh.Text + "','" + refid + "')");
                        }*/                       
                            for (int i = 0; i < gridView1.RowCount - 1; i++)
                            {
                                gen.ExcuteNonquery("insert into INOutwardLPGDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,Description,ListItemID,CustomField1,CustomField4,CustomField5,DGPhi) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 17] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "',0,0,'" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "',N'" + detail[i, 16] + "','" + detail[i, 0] + "',N'" + detail[i, 18] + "','" + phitaixe + "','" + phigiaonhan + "','" + detail[i, 19] + "')");
                                /*
                                for (int j = 0; j < hangton.Rows.Count; j++)
                                {
                                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                    {
                                        hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail[i, 1]);
                                        hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail[i, 2]);
                                        break;
                                    }
                                }*/
                            }

                            for (int i = 0; i < viewQT.RowCount; i++)
                            {
                                if (viewQT.GetRowCellValue(i, "Số lượng").ToString() != "")
                                {
                                    if (Double.Parse(viewQT.GetRowCellValue(i, "Số lượng").ToString()) != 0)
                                    {
                                        string soluong = viewQT.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                                        string mahang = viewQT.GetRowCellValue(i, "Mã hàng").ToString();
                                        string tenhang = viewQT.GetRowCellValue(i, "Tên hàng").ToString();
                                        string dvt = viewQT.GetRowCellValue(i, "ĐVT").ToString();
                                        gen.ExcuteNonquery("insert into INOutwardLPGQTDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,CustomField1) values(newid(),'" + refid + "','" + soluong + "','" + soluong + "'," + i + ",'" + mahang + "',N'" + tenhang + "',N'" + dvt + "')");
                                    }
                                }
                            }                            
                            gen.ExcuteNonquery("dondathanglpg '" + refid + "'");
                    }
                    else
                    {
                        Double hangxuat = 0;
                        try
                        {
                            hangxuat = Double.Parse(gen.GetString("select sum(QuantityConvertExits) from INOutwardLPGDetail where RefID='" + role + "'"));
                        }
                        catch { }
                        if (hangxuat != 0)
                        {
                            if (dtt != gen.GetString("select AccountingObjectID from INOutwardLPG where RefID='" + role + "'"))
                            {
                                XtraMessageBox.Show("Phiếu đã được xuất hóa đơn bạn không thể đổi tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ledt.EditValue = gen.GetString("select AccountingObjectCode from INOutwardLPG a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                                F.getloi("1");
                                return;
                            }
                        }


                        /*try
                        {*/
                        gen.ExcuteNonquery("update INOutwardLPG set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dtt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeIDSA=" + nv + ",TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',CustomField6=N'" + txtptgh.Text + "',CustomField8=N'" + txtsdt.Text + "',ParalellRefNo=N'" + cblkh.Text + "',CustomField2=N'" + txtgiaonhan.Text + "',OriginalRefNo='" + txtdienthoai.Text + "',Province=N'" + cbtinh.Text + "',District=N'" + cbhuyen.Text + "',Ward=N'" + cbxa.Text + "',AdressSon=N'" + txtdcc.Text + "',CustomField3='" + tongsoluong + "',CustomField4='" + tongtrongluong + "'  where RefID='" + role + "'");
                        gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dtt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeIDSA=" + nv + ",TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',CustomField6=N'" + txtptgh.Text + "', Shipper=N'" + txtgiaonhan.Text + "',OriginalRefNo='" + txtdienthoai.Text + "'  where INOutwardRefID='" + role + "'");
                        //gen.ExcuteNonquery("update hamaco.dbo.INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeIDSA=" + nv + ",TotalFreightAmount='" + tong[0, 1] + "',TotalAmount='" + tong[0, 0] + "',TotalAmountOC='" + tong[0, 2] + "',CustomField6=N'" + txtptgh.Text + "', Shipper=N'" + txtgiaonhan.Text + "',OriginalRefNo='" + txtdienthoai.Text + "'  where INOutwardRefID='" + role + "'");
                        //gen.ExcuteNonquery("update hamaco_ta.dbo.INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt_ta + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeIDSA=" + nv + ",TotalFreightAmount='" + tong[1, 1] + "',TotalAmount='" + tong[1, 0] + "',TotalAmountOC='" + tong[1, 2] + "',CustomField6=N'" + txtptgh.Text + "', Shipper=N'" + txtgiaonhan.Text + "',OriginalRefNo='" + txtdienthoai.Text + "'  where INOutwardRefID='" + role + "'");
                        //gen.ExcuteNonquery("update hamaco_tn.dbo.INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt_tn + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeIDSA=" + nv + ",TotalFreightAmount='" + tong[2, 1] + "',TotalAmount='" + tong[2, 0] + "',TotalAmountOC='" + tong[2, 2] + "',CustomField6=N'" + txtptgh.Text + "',Shipper=N'" + txtgiaonhan.Text + "',OriginalRefNo='" + txtdienthoai.Text + "'  where INOutwardRefID='" + role + "'");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("update INOutwardLPG set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',CustomField6=N'" + txtptgh.Text + "'  where RefID='" + role + "'");
                            gen.ExcuteNonquery("update hamaco.dbo.INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,TotalFreightAmount='" + tong[0, 1] + "',TotalAmount='" + tong[0, 0] + "',TotalAmountOC='" + tong[0, 2] + "',CustomField6=N'" + txtptgh.Text + "'  where INOutwardRefID='" + role + "'");
                            gen.ExcuteNonquery("update hamaco_ta.dbo.INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt_ta + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,TotalFreightAmount='" + tong[1, 1] + "',TotalAmount='" + tong[1, 0] + "',TotalAmountOC='" + tong[1, 2] + "',CustomField6=N'" + txtptgh.Text + "'  where INOutwardRefID='" + role + "'");
                            gen.ExcuteNonquery("update hamaco_tn.dbo.INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt_tn + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,TotalFreightAmount='" + tong[2, 1] + "',TotalAmount='" + tong[2, 0] + "',TotalAmountOC='" + tong[2, 2] + "',CustomField6=N'" + txtptgh.Text + "'  where INOutwardRefID='" + role + "'");
                        }*/

                        /*
                        DataTable hangchuyen = gen.GetTable("select InventoryItemID,Quantity,QuantityConvert from INOutwardLPGDetail where RefID='" + role + "' ");
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
                            gen.ExcuteNonquery("delete  from  INOutwardLPGDetail where RefID='" + role + "'");
                            for (int i = 0; i < gridView1.RowCount - 1; i++)
                            {
                                if (detail[i, 10] == "")
                                    gen.ExcuteNonquery("insert into INOutwardLPGDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,Description,ListItemID,CustomField1,CustomField4,CustomField5,DGPhi) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 17] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "',N'" + detail[i, 16] + "','" + detail[i, 0] + "',N'" + detail[i, 18] + "','" + phitaixe + "','" + phigiaonhan + "','" + detail[i, 19] + "')");
                                else
                                    gen.ExcuteNonquery("insert into INOutwardLPGDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,Description,ListItemID,CustomField1,CustomField4,CustomField5,DGPhi) values('" + detail[i, 10] + "','" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 17] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "',N'" + detail[i, 16] + "','" + detail[i, 0] + "',N'" + detail[i, 18] + "','" + phitaixe + "','" + phigiaonhan + "','" + detail[i, 19] + "')");
                                /*
                                for (int j = 0; j < hangton.Rows.Count; j++)
                                {
                                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                    {
                                        hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail[i, 1]);
                                        hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail[i, 2]);
                                        break;
                                    }
                                }*/

                            }

                            gen.ExcuteNonquery("delete  from  INOutwardLPGQTDetail where RefID='" + role + "'");
                            for (int i = 0; i < viewQT.RowCount; i++)
                            {
                                if (viewQT.GetRowCellValue(i, "Số lượng").ToString() != "")
                                {
                                    if (Double.Parse(viewQT.GetRowCellValue(i, "Số lượng").ToString()) != 0)
                                    {
                                        string soluong = viewQT.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                                        string mahang = viewQT.GetRowCellValue(i, "Mã hàng").ToString();
                                        string tenhang = viewQT.GetRowCellValue(i, "Tên hàng").ToString();
                                        string dvt = viewQT.GetRowCellValue(i, "ĐVT").ToString();
                                        gen.ExcuteNonquery("insert into INOutwardLPGQTDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,Description,CustomField1) values(newid(),'" + role + "','" + soluong + "','" + soluong + "'," + i + ",'" + mahang + "',N'" + tenhang + "',N'" + dvt + "')");
                                    }
                                }
                            }
                            
                         if (ledt.Properties.ReadOnly == false)
                            gen.ExcuteNonquery("dondathanglpg '" + role + "'");
                         else
                             gen.ExcuteNonquery("dondathanglpgcapnhat '" + role + "'");
                        /*Double ton = 0;
                        try
                        {
                            ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INOutwardLPGDetail where RefID='" + role + "'"));
                        }
                        catch { }
                        if (ton == 0)
                            gen.ExcuteNonquery("update INOutwardLPG set IsExport='True' where RefID='" + role + "'");
                        else
                            gen.ExcuteNonquery("update INOutwardLPG set IsExport='False' where RefID='" + role + "'");
                         */
                    }
                    //F.getactive("1");
                    F.gethangton(hangton);
                    F.Text = "Xem đơn đặt hàng";
                }
            }
            catch
            {
                F.getloi("1");
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void themsctchung(string ngaychungtu, TextEdit txthamaco, TextEdit txtthienan, TextEdit txtdichvu, string mk, string branchid)
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
            /*try
            {
                string id = gen.GetString("select Top 1 RefNo from hamaco.dbo.INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txthamaco.Text = sophieu;

            sophieu = branch + "-" + mk + "-PXKH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from hamaco_ta.dbo.INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtthienan.Text = sophieu;

            sophieu = branch + "-" + mk + "-PXKH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from hamaco_tn.dbo.INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtdichvu.Text = sophieu;*/

            //sophieu = branch + "-" + mk + "-PXKH";
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
            txtdichvu.Text = sophieu;
        }



        public void themsct(string ngaychungtu, TextEdit txtsct, string mk, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-DDHL";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INOutwardLPG where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
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


        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from INOutwardLPG where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  and Cancel='True'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INOutwardLPG where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  and Cancel='True'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void tsbtdeletepxk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F, string userid)
        {
            try
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, "User").ToString() != userid && Double.Parse(gen.GetString("select AuthenticationType from MSC_User where UserID='" + userid + "'")) < 2)
                {
                    XtraMessageBox.Show("Bạn không phải người lập đơn hàng này nên không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from INOutwardLPG where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string hoadon = view.GetRowCellValue(view.FocusedRowHandle, "Hóa đơn").ToString();
                if (hoadon == "False")
                {
                    try
                    {
                        Double temp = Double.Parse(gen.GetString("select COALESCE(sum(QuantityConvertExits),0)  from  hamaco.dbo.INOutwardDetail where RefID=(select RefID from hamaco.dbo.INOutward where INOutwardRefID='" + name + "')"));
                        temp = temp + Double.Parse(gen.GetString("select COALESCE(sum(QuantityConvertExits),0)  from  hamaco_ta.dbo.INOutwardDetail where RefID=(select RefID from hamaco_ta.dbo.INOutward where INOutwardRefID='" + name + "')"));
                        temp = temp + Double.Parse(gen.GetString("select COALESCE(sum(QuantityConvertExits),0)  from  hamaco_tn.dbo.INOutwardDetail where RefID=(select RefID from hamaco_tn.dbo.INOutward where INOutwardRefID='" + name + "')"));
                        if (temp != 0)
                        {
                            XtraMessageBox.Show("Một phần hoặc toàn bộ phiếu đã được xuất hóa đơn bạn không thể sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (XtraMessageBox.Show("Bạn có chắc muốn xóa đơn đặt hàng " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                gen.ExcuteNonquery("delete from INOutwardLPGDetail where RefID='" + name + "'");
                                gen.ExcuteNonquery("delete from INOutwardLPGQTDetail where RefID='" + name + "'");                                
                                gen.ExcuteNonquery("delete from INOutwardLPG where RefID='" + name + "'");                                

                                gen.ExcuteNonquery("delete from hamaco.dbo.INOutwardDetail where RefID=(select RefID from hamaco.dbo.INOutward where INOutwardRefID='" + name + "')");
                                gen.ExcuteNonquery("delete from hamaco.dbo.INOutward where INOutwardRefID='" + name + "'");

                                gen.ExcuteNonquery("delete from hamaco_ta.dbo.INOutwardDetail where RefID=(select RefID from hamaco_ta.dbo.INOutward where INOutwardRefID='" + name + "')");
                                gen.ExcuteNonquery("delete from hamaco_ta.dbo.INOutward where INOutwardRefID='" + name + "'");

                                gen.ExcuteNonquery("delete from hamaco_tn.dbo.INOutwardDetail where RefID=(select RefID from hamaco_tn.dbo.INOutward where INOutwardRefID='" + name + "')");
                                gen.ExcuteNonquery("delete from hamaco_tn.dbo.INOutward where INOutwardRefID='" + name + "'");
                                
                                view.DeleteRow(view.FocusedRowHandle);
                            }
                        }
                    }
                    catch
                    {
                        /*if (XtraMessageBox.Show("Bạn có chắc muốn xóa đơn đặt hàng dầu khí " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            gen.ExcuteNonquery("delete from INOutwardLPG where RefID='" + name + "'");
                        }*/
                        XtraMessageBox.Show("Vui lòng chọn đơn đặt hàng dầu khí trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Đơn đặt hàng đã được xuất hóa đơn bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn đơn đặt hàng dầu khí trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, ddhgas F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INOutwardLPG where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' and Cancel='True' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INOutwardLPG where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' and Cancel='True' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, ddhgas F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INOutwardLPG where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' and Cancel='True'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INOutwardLPG where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' and Cancel='True' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }

        public void loadthhdmain(DevExpress.XtraGrid.Views.Grid.GridView gridView2, DevExpress.XtraGrid.Views.Grid.GridView gridView1, TextEdit txtcth, ComboBoxEdit cbthue)
        {

            while (gridView2.RowCount > 0)
            {
                gridView2.DeleteRow(0);
            }
            Double thue = 0;
            try
            {
                thue = Double.Parse(cbthue.EditValue.ToString());
            }
            catch { cbthue.EditValue = 0; }
            int dong = 1;
            if (gridView1.OptionsView.NewItemRowPosition == DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None)
                dong = 0;
            for (int i = 0; i < gridView1.RowCount - dong; i++)
            {
                Double soluong = 0;
                Double soluongqd = 0;
                Double thanhtien = 0;
                Double dongiaban = 0;

                try
                {
                    soluongqd = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                    if (soluongqd != 0)
                    {
                        try
                        {
                            soluong = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng").ToString());
                        }
                        catch { }
                        try
                        {
                            thanhtien = Double.Parse(gridView1.GetRowCellValue(i, "Thành tiền").ToString());
                        }
                        catch { }
                        try
                        {
                            dongiaban = Double.Parse(gridView1.GetRowCellValue(i, "Đơn giá").ToString());
                        }
                        catch { }

                        thanhtien = Math.Round(thanhtien / ((100 + thue) / 100), 0);
                        dongiaban = Math.Round(thanhtien / soluongqd, 2);

                        if (gridView2.RowCount > 0)
                        {
                            gridView2.AddNewRow();
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tên hàng"], gridView1.GetRowCellValue(i, "Tên hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], soluong);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], dongiaban);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], thanhtien);
                            gridView2.UpdateCurrentRow();
                        }
                        else
                        {
                            gridView2.AddNewRow();
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Tên hàng"], gridView1.GetRowCellValue(i, "Tên hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], soluong);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], dongiaban);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], thanhtien);
                            gridView2.UpdateCurrentRow();
                        }
                    }
                }
                catch { }
            }
            txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
        }
        
    }
}
