using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace HAMACO.Resources
{
    class cuspro
    {
        gencon gen = new gencon();
               //gencon_ta genta=new gencon_ta();
               //gencon_tn gentn = new gencon_tn();
               //gencon_chk_tp gentp = new gencon_chk_tp();
        public void loadcuspro(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách hàng - nhà cung cấp", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách hàng - nhà cung cấp", Type.GetType("System.String"));
            dt.Columns.Add("Địa chỉ", Type.GetType("System.String"));
            dt.Columns.Add("Mã số thuế", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][7].ToString();
                dr[4] = temp.Rows[i][14].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
           
        }

        public void changetabcuspro(ListView lvinfo, ListView lvuser, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                DataTable da = new DataTable();
                string info = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();

                lvinfo.Clear();
                lvinfo.Columns.Add("", 180);
                lvinfo.Columns.Add("", 300);
                lvinfo.View = View.Details;
                da = gen.GetTable("select * from AccountingObject  where AccountingObjectID = '" + info + "'");
                ListViewItem item1;
                item1 = new ListViewItem("Mã KH-NCC");
                item1.SubItems.Add(da.Rows[0][1].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Tên KH-NCC");
                item1.SubItems.Add(da.Rows[0][2].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Địa chỉ");
                item1.SubItems.Add(da.Rows[0][7].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Điện thoại");
                item1.SubItems.Add(da.Rows[0][8].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Fax");
                item1.SubItems.Add(da.Rows[0][9].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Mã số thuế");
                item1.SubItems.Add(da.Rows[0][14].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Email");
                item1.SubItems.Add(da.Rows[0][10].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Website");
                item1.SubItems.Add(da.Rows[0][11].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("TK ngân hàng");
                item1.SubItems.Add(da.Rows[0][12].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Tên ngân hàng");
                item1.SubItems.Add(da.Rows[0][13].ToString());
                lvinfo.Items.Add(item1);
                gen.ResizeListViewColumns(lvuser);
            }
            catch { }
        }

        public void tsbtcuspro(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string userid)
        {
            try
            {
                Frm_cuspro m = new Frm_cuspro();
                m.myac = new Frm_cuspro.ac(F.refreshcuspro);
                m.getactive(a);
                m.getuserid(userid);
                if (a == "1")
                {
                    m.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                m.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn KH-NCC trước khi sửa."); }
        }

        public void checkcuspro(string ac, TextBox a, TextBox b, string sql, Frm_cuspro F)
        {
            try
            {
                string kq = gen.GetString("select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + a.Text + "'");
                MessageBox.Show("Mã khách hàng, nhà cung cấp này đã tồn tại.", "Thông báo");
            }
            catch
            {
                gen.ExcuteNonquery(sql);
                gen.ExcuteNonquery("insert into hamaco_ta.dbo.AccountingObject select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + a.Text + "'");
                gen.ExcuteNonquery("insert into hamaco_tn.dbo.AccountingObject select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + a.Text + "'");
                gen.ExcuteNonquery("insert into hamaco_vithanh.dbo.AccountingObject select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + a.Text + "'");
                //gen.ExcuteNonquery("insert into hamaco_qlk.dbo.AccountingObject select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + a.Text + "'");
                F.myac();
                F.Close();
            }
        }

        public void tsbtdeletecuspro(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng - nhà cung cấp " + view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng / nhà cung cấp").ToString() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from AccountingObject where AccountingObjectID='" + name + "'");
                    //F.refreshcuspro();
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { MessageBox.Show("Vui lòng chọn khách hàng - nhà cung cấp trước khi xóa."); }
        }

    }
}
