using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HAMACO.Resources;

namespace HAMACO.Resources
{
    class chinhsachnhacungcap
    {
        gencon gen = new gencon();
        public void loadchinhsach(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu)
        {
            string sql = "select PolicyID as 'ID',PolicyCode as 'Chính sách',b.InventoryItemName+'-'+a.InventoryItemCode as 'Nhà cung cấp',PolicyName as 'Nội dung',BeginDate as 'Ngày bắt đầu', EndDate as 'Ngày kết thúc',BeginQuantity as 'Từ sản lượng', EndQuantity as 'Đến sản lượng', Unit as 'Đơn vị tính', Discount as 'Chiết khấu', PolicyParent as 'Nhóm',Species as 'Theo',UserName as 'Người lập' from Policy a, InventoryItemSub b where substring(a.InventoryItemCode,1,3)=b.InventoryCategoryCode and substring(a.InventoryItemCode,5,2)=b.InventoryItemCode and (YEAR(BeginDate)='" + DateTime.Parse(ngaychungtu).Year + "' or YEAR(EndDate)='" + DateTime.Parse(ngaychungtu).Year + "')";
            view.Columns.Clear();
            DataTable temp = gen.GetTable(sql);
            lvpq.DataSource = temp;
            view.OptionsView.ShowGroupPanel = true;           
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Ngày bắt đầu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày bắt đầu"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày bắt đầu"].Width = 100;
            view.Columns["Ngày bắt đầu"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày kết thúc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày kết thúc"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày kết thúc"].Width = 100;
            view.Columns["Ngày kết thúc"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
           
            view.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Từ sản lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Từ sản lượng"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Đến sản lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đến sản lượng"].DisplayFormat.FormatString = "{0:n0}";
           
            view.Columns["Theo"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Theo"].Width = 50;

            view.OptionsView.ShowFooter = true;

            view.Columns["Chính sách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;           
            view.Columns["Chính sách"].Width = 50;

            view.Columns["Nhóm"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Nhóm"].Width = 50;

            view.Columns["Theo"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Theo"].Width = 50;

            view.Columns["Nhà cung cấp"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Nhà cung cấp"].Width = 50;

            view.Columns["Người lập"].Width = 100;
            view.Columns["Đơn vị tính"].Width = 100;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Nhà cung cấp"].GroupIndex = 0;
            view.Columns["Nhóm"].GroupIndex = 1;
            view.ExpandAllGroups();
        }

        public void tsbtcsncc(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string userid,string ngaychungtu)
        {
            try
            {
                Frm_chinhsach u = new Frm_chinhsach();
                u.myac = new Frm_chinhsach.ac(F.refreshcsncc);
                u.getactive(a);
                u.getdate(ngaychungtu);
                userid = gen.GetString("select Top 1 FullName from MSC_User where UserID='" + userid + "'");
                u.getuser(userid);
                try
                {
                    if (a == "1")
                    {
                        if (userid.ToUpper() == view.GetRowCellValue(view.FocusedRowHandle, "Người lập").ToString().ToUpper() || Double.Parse(gen.GetString("select Top 1 AuthenticationType from MSC_User where UserID='" + userid + "'")) > 1)
                            u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        else
                        {
                            XtraMessageBox.Show("Bạn không phải người lập chính sách này.");
                            return;
                        }

                    }
                }
                catch { }
                u.ShowDialog();
            }
            catch { XtraMessageBox.Show("Vui lòng chọn chính sách trước khi sửa."); }
        }


        public void loadstart(LookUpEdit lencc, string ngaychungtu, RadioButton rbthang, RadioButton rbkg, TextEdit txtscs, TextEdit txttsl,TextEdit txtdsl,TextEdit txtck)
        {
            DataTable da = new DataTable();
            da = gen.GetTable("select InventoryCategoryCode+'-'+InventoryItemCode as 'Mã nhà cung cấp',InventoryItemName as 'Nhà cung cấp' from InventoryItemSub order by InventoryCategoryCode+'-'+InventoryItemCode");
            lencc.Properties.DataSource = da;
            lencc.Properties.DisplayMember = "Mã nhà cung cấp";
            lencc.Properties.ValueMember = "Mã nhà cung cấp";
            lencc.Properties.PopupWidth = 300;
            lencc.ItemIndex = 0;

            rbthang.Checked = true;
            rbkg.Checked = true;

            txttsl.EditValue = 0;
            txtdsl.EditValue = 0;
            txtck.EditValue = 0;

            try
            {
                txtscs.Text = (Double.Parse(gen.GetString("select Max(PolicyCode) from  Policy")) + 1).ToString();
            }
            catch { txtscs.Text = "1"; }
        }


        public void loadchinhsach( string role, LookUpEdit lencc, LookUpEdit lencs, TextEdit txtscs, DateEdit detn,DateEdit dedn,TextEdit txttsl, TextEdit txtdsl, TextEdit txtck, RadioButton rbthang, RadioButton rbquy, RadioButton rbnam, RadioButton rbkg, RadioButton rbtan, MemoEdit txtnd, LabelControl lauser)
        {
            DataTable dt = gen.GetTable("select PolicyCode,InventoryItemCode,PolicyName,BeginDate,EndDate,Unit,Discount,PolicyParent,Species,BeginQuantity,EndQuantity,UserName from Policy where PolicyID='" + role + "'");
            txtscs.EditValue = dt.Rows[0][0];
            lencc.EditValue = dt.Rows[0][1];
            txtnd.EditValue = dt.Rows[0][2];
            detn.EditValue = dt.Rows[0][3];
            dedn.EditValue = dt.Rows[0][4];
            if (dt.Rows[0][5].ToString() == "Kg")
                rbkg.Checked = true;
            else if (dt.Rows[0][5].ToString() == "Tấn")
                rbtan.Checked = true;

            txtck.EditValue = double.Parse(dt.Rows[0][6].ToString());
            lencs.EditValue = dt.Rows[0][7];
            
            if (dt.Rows[0][8].ToString() == "Tháng")
                rbthang.Checked = true;
            else if (dt.Rows[0][8].ToString() == "Quý")
                rbquy.Checked = true;
            else if (dt.Rows[0][8].ToString() == "Năm")
                rbnam.Checked = true;           

            txttsl.EditValue = double.Parse(dt.Rows[0][9].ToString());
            txtdsl.EditValue = double.Parse(dt.Rows[0][10].ToString());
            lauser.Text = dt.Rows[0][11].ToString();

        }


        public void checkhd(string active, string role, LookUpEdit lencc, LookUpEdit lencs, TextEdit txtscs, DateEdit detn,DateEdit dedn,TextEdit txttsl, TextEdit txtdsl, TextEdit txtck, RadioButton rbthang, RadioButton rbquy, RadioButton rbnam, RadioButton rbkg, RadioButton rbtan, MemoEdit txtnd, LabelControl lauser)
        {
            string theo = "Tháng";
            if (rbquy.Checked == true)
                theo = "Quý";
            if (rbnam.Checked == true)
                theo = "Năm";

            string donvitinh = "Kg";
            if (rbtan.Checked == true)
                donvitinh = "Tấn";


            if (active == "0")
            {
                try
                {
                    txtscs.Text = (Double.Parse(gen.GetString("select Max(PolicyCode) from  Policy")) + 1).ToString();
                }
                catch { txtscs.Text = "1"; }
                string cha = txtscs.Text;
                if (lencs.EditValue != null)
                    cha = lencs.EditValue.ToString();
                
                gen.ExcuteNonquery("insert into Policy(PolicyID,PolicyCode,InventoryItemCode,PolicyName,BeginDate,EndDate,Unit,Discount,PolicyParent,Species,BeginQuantity,EndQuantity,UserName)"
                    + "values(newid(),'" + txtscs.Text + "','" + lencc.EditValue + "',N'" + txtnd.Text + "','" + detn.EditValue + "','" + dedn.EditValue + "',N'" + donvitinh + "','" + txtck.EditValue.ToString().Replace(".", "") + "','" + cha + "',N'" + theo + "','" + txttsl.EditValue.ToString().Replace(".", "") + "','" + txtdsl.EditValue.ToString().Replace(".", "") + "',N'" + lauser.Text + "')");
            }
            else
            {
                string cha = txtscs.Text;
                if (lencs.EditValue != null)
                    cha = lencs.EditValue.ToString();
                gen.ExcuteNonquery("update Policy set PolicyCode='" + txtscs.Text + "',InventoryItemCode='" + lencc.EditValue + "',PolicyName=N'" + txtnd.Text + "',BeginDate='" + detn.EditValue + "',EndDate='" + dedn.EditValue + "',Unit=N'" + donvitinh + "',Discount='" + txtck.EditValue.ToString().Replace(".", "") + "',PolicyParent='" + cha + "',Species=N'" + theo + "',BeginQuantity='" + txttsl.EditValue.ToString().Replace(".", "") + "',EndQuantity='" + txtdsl.EditValue.ToString().Replace(".", "") + "',UserName=N'" + lauser.Text + "' where PolicyID='" + role + "'");
            }
            
        }


        public void tsbtdeletecsncc(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F, string userid)
        {
            try
            {
                userid = gen.GetString("select Top 1 FullName from MSC_User where UserID='" + userid + "'");
                if (userid.ToUpper() == view.GetRowCellValue(view.FocusedRowHandle, "Người lập").ToString().ToUpper() || Double.Parse(gen.GetString("select Top 1 AuthenticationType from MSC_User where UserID='" + userid + "'")) > 1)
                {
                    string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                    if (XtraMessageBox.Show("Bạn có chắc muốn xóa Chính sách " + view.GetRowCellValue(view.FocusedRowHandle, "Chính sách").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        gen.ExcuteNonquery("delete from Policy where PolicyID='" + name + "'");
                        view.DeleteRow(view.FocusedRowHandle);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn không phải người lập chính sách này.");
                    return;
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn Chính sách trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

    }
}
