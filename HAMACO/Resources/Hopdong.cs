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
    class Hopdong
    {
        gencon gen = new gencon();

        public void loadhd(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string userid, string ngaychungtu)
        {
            string sql = "select ContractID,ContractCode,ContractName,c.AccountingObjectName,a.SignedDate,a.EffectiveDate,a.DebtLimit,a.LimitDate,a.NoPay,a.NoContract,a.Closed,c.AccountingObjectCode,Saved,b.StockCode+' - '+StockName,a.Inactive,a.DebtLimitMax from contractB a, Stock b, AccountingObject c where No=0 and a.StockID=b.StockID and a.AccountingObjectID=c.AccountingObjectID and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') and Year(a.EffectiveDate)>= '" + DateTime.Parse(ngaychungtu).Year + "' order by a.ContractName,a.ContractCode";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Loại hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Ngày ký", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hết hạn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hạn mức nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn mức tối đa", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hình thức", Type.GetType("System.String"));
            dt.Columns.Add("Hợp đồng", Type.GetType("System.String"));            
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Nơi lưu", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Thanh lý", Type.GetType("System.Boolean"));
            dt.Columns.Add("Hiệu lực", Type.GetType("System.Boolean"));
            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dr[6] = Double.Parse(temp.Rows[i][6].ToString());
                dr[7] = Double.Parse(temp.Rows[i][15].ToString());
                dr[8] = Double.Parse(temp.Rows[i][7].ToString());

                if (temp.Rows[i][8].ToString()=="1")
                    dr[9] = "Tiền mặt";
                else if(temp.Rows[i][8].ToString()=="2")
                    dr[9] = "Tín chấp";
                else if(temp.Rows[i][8].ToString() == "3")
                    dr[9] = "Bảo lãnh";

                if (temp.Rows[i][9].ToString() == "1")
                    dr[10] = "Nguyên tắc";
                else if (temp.Rows[i][9].ToString() == "2")
                    dr[10] = "Đơn hàng";                
                dr[11] = temp.Rows[i][11].ToString();
                dr[12] = temp.Rows[i][12].ToString();
                dr[13] = temp.Rows[i][13].ToString();
                dr[14] = "False";
                if (temp.Rows[i][10].ToString() == "1")
                {
                    dr[14] = "True";
                }
                dr[15] = "False";
                if (temp.Rows[i][14].ToString() == "1")
                {
                    dr[15] = "True";
                }                
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Ngày ký"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày ký"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày ký"].Width = 100;
            view.Columns["Ngày ký"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hết hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hết hạn"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hết hạn"].Width = 100;
            view.Columns["Ngày hết hạn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hạn mức nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức nợ"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn mức tối đa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức tối đa"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn mức tối đa"].AppearanceCell.BackColor = System.Drawing.Color.Salmon;
            view.Columns["Hạn mức tối đa"].AppearanceCell.BackColor2 = System.Drawing.Color.SeaShell;
          
            view.OptionsView.ShowFooter = true;
            view.Columns["Hình thức"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hợp đồng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Nơi lưu"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Hạn nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn nợ"].Width = 50;
            
            view.Columns["Khách hàng"].Width = 250;
            view.Columns["Thanh lý"].Width = 50;
            view.Columns["Hiệu lực"].Width = 50;
        
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Đơn vị"].GroupIndex = 0;
            view.ExpandAllGroups();
            view.Columns["Số hợp đồng"].BestFit();
        }

        public void loadplbl(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string userid, string ngaychungtu)
        {
            string sql = "select ContractID,ContractCode,ContractName,c.AccountingObjectName,a.SignedDate,a.EffectiveDate,a.DebtLimit,a.LimitDate,a.ParentContract,c.AccountingObjectCode, Saved,b.StockCode+' - '+StockName, No,a.Inactive,a.DebtLimitMax from contractB a, Stock b, AccountingObject c where No<>0 and a.StockID=b.StockID and a.AccountingObjectID=c.AccountingObjectID and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') and Year(a.EffectiveDate)>= '" + DateTime.Parse(ngaychungtu).Year + "' order by a.ParentContract,a.SignedDate";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số", Type.GetType("System.String"));
            dt.Columns.Add("Tên", Type.GetType("System.String"));
            dt.Columns.Add("Khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Ngày ký", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hết hạn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hạn mức nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn mức tối đa", Type.GetType("System.Double"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hợp đồng", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Nơi lưu", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị", Type.GetType("System.String"));
            dt.Columns.Add("Hiệu lực", Type.GetType("System.Boolean"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                if (temp.Rows[i][12].ToString() == "1")
                    dr[2] = "Phụ lục";
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                dr[6] = Double.Parse(temp.Rows[i][6].ToString());
                dr[7] = Double.Parse(temp.Rows[i][14].ToString());
                dr[8] = Double.Parse(temp.Rows[i][7].ToString());
                dr[9] = temp.Rows[i][8].ToString();                
                dr[10] = temp.Rows[i][9].ToString();
                dr[11] = temp.Rows[i][10].ToString();
                dr[12] = temp.Rows[i][11].ToString();
                
                dr[13] = "False";
                if (temp.Rows[i][13].ToString() == "1")
                {
                    dr[13] = "True";
                }

                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Ngày ký"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày ký"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày ký"].Width = 100;
            view.Columns["Ngày ký"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hết hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hết hạn"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hết hạn"].Width = 100;
            view.Columns["Ngày hết hạn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hạn mức nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức nợ"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn mức tối đa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn mức tối đa"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn mức tối đa"].AppearanceCell.BackColor = System.Drawing.Color.Salmon;
            view.Columns["Hạn mức tối đa"].AppearanceCell.BackColor2 = System.Drawing.Color.SeaShell;

            view.OptionsView.ShowFooter = true;
            view.Columns["Hợp đồng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Nơi lưu"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Hạn nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn nợ"].Width = 50;

            view.Columns["Khách hàng"].Width = 250;
            view.Columns["Hiệu lực"].Width = 50;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Đơn vị"].GroupIndex = 0;
            view.ExpandAllGroups();
            view.Columns["Số"].BestFit();
        }

        public void tsbthd(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, DataTable khach)
        {
            try
            {
                Frm_hdkh u = new Frm_hdkh();
                u.myac = new Frm_hdkh.ac(F.refreshhdkh);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getkhach(khach);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                try
                {
                if (a == "1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                else
                {
                    try
                    {
                        u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Đơn vị").ToString());
                    }
                    catch
                    {
                        u.getrole(gen.GetString("select Top 1 StockCode from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode"));
                    }
                }
                }
                catch { }
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn hợp đồng trước khi sửa."); }
        }

        public void loadstart(ComboBoxEdit cblhd, LookUpEdit ledv, SearchLookUpEdit sekh, DataTable khach, string userid, RadioButton rbhdnt, RadioButton rbtm)
        {
            cblhd.Properties.Items.Add("Bán hàng");
            cblhd.Properties.Items.Add("Mua hàng");
            cblhd.Properties.Items.Add("Thuê vận chuyển");
            cblhd.Properties.Items.Add("Vận chuyển");
            cblhd.Properties.Items.Add("Thuê tài sản");
            cblhd.Properties.Items.Add("Cho thuê tài sản");
            cblhd.Properties.Items.Add("Thuê kho");
            cblhd.Properties.Items.Add("Cho thuê kho");
            cblhd.Properties.Items.Add("Gửi kho");

            cblhd.SelectedIndex = 0;

            DataTable da = new DataTable();
            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã kho");
            temp1.Columns.Add("Tên kho");
            da = gen.GetTable("select StockCode,StockName from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='" + userid + "' order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp1.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp1;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;
            ledv.ItemIndex = 0;

            sekh.Properties.View.Columns.Clear();
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
            sekh.Properties.DataSource = temp;
            sekh.Properties.DisplayMember = "Mã khách";
            sekh.Properties.ValueMember = "Mã khách";

            rbhdnt.Checked = true;
            rbtm.Checked = true;
        }

        public void loadhdkh(string role, ComboBoxEdit cblhd, TextEdit txtshd, LookUpEdit ledv, SearchLookUpEdit sekh, TextEdit txtsdt, TextEdit txtfax, TextEdit txtndd, TextEdit txtcv, TextEdit txtguq, TextEdit txtsqpkd, MemoEdit txtnc, TextEdit txtltd, DateEdit dentd,
            TextEdit txtnh, TextEdit txtstk, DateEdit denk, DateEdit denhh, TextEdit txthmn, TextEdit txthn, RadioButton rbhdnt, RadioButton rbhddh, RadioButton rbtm, RadioButton rbtc, RadioButton rbbl, MemoEdit txtddgh, DateEdit denl, DateEdit deng, DateEdit denqv, TextEdit txtnl, CheckEdit chetl, DateEdit dentl, CheckEdit chenqv, TextEdit txthmtd)
        {
                                                                                
            
        }

        public void checkhd(string active,string role,ComboBoxEdit cblhd, TextEdit txtshd, LookUpEdit ledv, SearchLookUpEdit sekh, TextEdit txtsdt, TextEdit txtfax, TextEdit txtndd, TextEdit txtcv,TextEdit txtguq, TextEdit txtsqpkd, MemoEdit txtnc, TextEdit txtltd, DateEdit dentd, 
            TextEdit txtnh, TextEdit txtstk, DateEdit denk, DateEdit denhh, TextEdit txthmn, TextEdit txthn, RadioButton rbhdnt, RadioButton rbhddh, RadioButton rbtm, RadioButton rbtc, RadioButton rbbl, MemoEdit txtddgh, DateEdit denl, DateEdit deng, DateEdit denqv, TextEdit txtnl, CheckEdit chetl, DateEdit dentl, CheckEdit chenqv, TextEdit txthmtd)
        {
            string makho=gen.GetString("select * from Stock where StockCode='"+ledv.EditValue+"'");
            string makhach=gen.GetString("select * from AccountingObject where AccountingObjectCode='"+sekh.EditValue+"'");
            int loaihopdong=1;
            if(rbhddh.Checked==true)
             loaihopdong=2;
            int hinhthuc=1;
            if(rbtc.Checked==true)
                hinhthuc=2;
            else if(rbbl.Checked==true)
                hinhthuc=3;
            int thanhly = 0;
            if (chetl.Checked == true)
                thanhly = 1;

            int ngayve = 0;
            if (chenqv.Checked == true)
                ngayve = 1;

            if (active == "0")
                gen.ExcuteNonquery("insert ContractB(ContractID,ContractCode,ContractName,StockID,AccountingObjectID,SignerName,Position,License,IssuedBy,Change,ChangeDate,CompanyTel,CompanyFax,CompanyBankAccount,CompanyBankName,Proxy,SignedDate,EffectiveDate,DebtLimit,LimitDate,NoPay,NoContract,DeliveryPlace,Saved,Founded,Send,Received,Closed,ClosedDate,ParentContract,No,Inactive,DebtLimitMax)"
                    + "values(newid(),N'" + txtshd.EditValue + "',N'" + cblhd.EditValue + "','" + makho + "','" + makhach + "',N'" + txtndd.EditValue + "',N'" + txtcv.EditValue + "',N'" + txtguq.EditValue + "',N'" + txtnc.EditValue + "',N'" + txtltd.EditValue + "','" + dentd.EditValue + "',N'" + txtsdt.EditValue + "',N'" + txtfax.EditValue + "',N'" + txtstk.EditValue + "',N'" + txtnh.EditValue + "',N'" + txtsqpkd.EditValue + "','" + denk.EditValue + "','" + denhh.EditValue + "',N'" + txthmn.EditValue + "',N'" + txthn.EditValue + "','" + hinhthuc + "','" + loaihopdong + "',N'" + txtddgh.EditValue + "',N'" + txtnl.EditValue + "','" + denl.EditValue + "','" + deng.EditValue + "','" + denqv.EditValue + "','" + thanhly + "','" + dentl.EditValue + "',N'" + txtshd.EditValue + "',0,'" + ngayve + "',N'" + txthmtd.EditValue.ToString().Replace(".","") + "')");
            else
                gen.ExcuteNonquery("update ContractB set ContractCode=N'" + txtshd.EditValue + "',ContractName=N'" + cblhd.EditValue + "',StockID='" + makho + "',AccountingObjectID='" + makhach + "',SignerName=N'" + txtndd.EditValue + "',Position=N'" + txtcv.EditValue + "',License=N'" + txtguq.EditValue + "',IssuedBy=N'" + txtnc.EditValue + "',Change=N'" + txtltd.EditValue + "',ChangeDate=N'" + dentd.EditValue + "',CompanyTel=N'" + txtsdt.EditValue + "',CompanyFax=N'" + txtfax.EditValue + "',CompanyBankAccount=N'" + txtstk.EditValue + "',CompanyBankName=N'" + txtnh.EditValue + "',Proxy=N'" + txtsqpkd.EditValue + "',SignedDate='" + denk.EditValue + "',EffectiveDate='" + denhh.EditValue + "',DebtLimit='" + txthmn.EditValue + "',LimitDate='" + txthn.EditValue + "',NoPay=N'" + hinhthuc + "',NoContract=N'" + loaihopdong + "',DeliveryPlace=N'" + txtddgh.EditValue + "',Saved=N'" + txtnl.EditValue + "',Founded='" + denl.EditValue + "',Send='" + deng.EditValue + "',Received='" + denqv.EditValue + "',Closed='" + thanhly + "',ClosedDate='" + dentl.EditValue + "',ParentContract=N'" + txtshd.EditValue + "',Inactive='" + ngayve + "', DebtLimitMax=N'" + txthmtd.EditValue + "' where ContractID='" + role + "'");
        }


        public void tsbtplbl(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, DataTable khach)
        {
            try
            {
                Frm_plbl u = new Frm_plbl();
                u.myac = new Frm_plbl.ac(F.refreshhdkh);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getkhach(khach);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                try
                {
                    if (a == "1")
                        u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    else
                    {
                        try
                        {
                            u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Đơn vị").ToString());
                        }
                        catch
                        {
                            u.getrole(gen.GetString("select Top 1 StockCode from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode"));
                        }
                    }
                }
                catch { }
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn Phụ lục - Bảo lãnh trước khi sửa."); }
        }

        public void loadstartplbl(LookUpEdit lehd, LookUpEdit ledv, SearchLookUpEdit sekh, DataTable khach, string userid, RadioButton rbpl)
        {          
           
            DataTable da = new DataTable();

            DataTable temp2 = new DataTable();
            temp2.Columns.Add("Số hợp đồng");
            temp2.Columns.Add("Loại hợp đồng");
            da = gen.GetTable("select DISTINCT ContractCode, ContractName from contractB a, MSC_UserJoinStock b where No=0 and a.StockID=b.StockID and UserID='" + userid + "' order by ContractCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp2.Rows.Add(dr);
            }
            lehd.Properties.DataSource = temp2;
            lehd.Properties.DisplayMember = "Số hợp đồng";
            lehd.Properties.ValueMember = "Số hợp đồng";
            lehd.Properties.PopupWidth = 300;

            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã kho");
            temp1.Columns.Add("Tên kho");
            da = gen.GetTable("select StockCode,StockName from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='" + userid + "' order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp1.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp1;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;
            ledv.ItemIndex = 0;

            sekh.Properties.View.Columns.Clear();
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
            sekh.Properties.DataSource = temp;
            sekh.Properties.DisplayMember = "Mã khách";
            sekh.Properties.ValueMember = "Mã khách";

            rbpl.Checked = true;
        }

        public void checkplbl(string active, string role, LookUpEdit lehd, TextEdit txtshd, LookUpEdit ledv, SearchLookUpEdit sekh, TextEdit txtsdt, TextEdit txtfax, TextEdit txtndd, TextEdit txtcv, TextEdit txttbl,
           MemoEdit txtnh,MemoEdit txtndtd, DateEdit denk, DateEdit denhh, TextEdit txthmn, TextEdit txthn, RadioButton rbpl, RadioButton rbbl,  MemoEdit txtddgh, DateEdit denl, DateEdit deng, DateEdit denqv, TextEdit txtnl,TextEdit txttenbl, CheckEdit chenqv,TextEdit txthmtd)
        {
            string makho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue + "'");
            string makhach = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + sekh.EditValue + "'");
            int phuluc = 1;
            if (rbbl.Checked == true)
                phuluc = 2;
            int ngayve = 0;
            if (chenqv.Checked == true)
                ngayve = 1;
            if (active == "0")
                gen.ExcuteNonquery("insert ContractB(ContractID,ContractCode,ContractName,Description,StockID,AccountingObjectID,SignerName,Position,License,CompanyTel,CompanyFax,CompanyBankName,SignedDate,EffectiveDate,DebtLimit,LimitDate,DeliveryPlace,Saved,Founded,Send,Received,ParentContract,No,Inactive,DebtLimitMax)"
                    + "values(newid(),N'" + txtshd.EditValue + "',N'" + txttenbl.EditValue + "',N'" + txtndtd.EditValue + "','" + makho + "','" + makhach + "',N'" + txtndd.EditValue + "',N'" + txtcv.EditValue + "',N'" + txttbl.EditValue + "',N'" + txtsdt.EditValue + "',N'" + txtfax.EditValue + "',N'" + txtnh.EditValue + "','" + denk.EditValue + "','" + denhh.EditValue + "',N'" + txthmn.EditValue + "',N'" + txthn.EditValue + "',N'" + txtddgh.EditValue + "','" + txtnl.EditValue + "','" + denl.EditValue + "','" + deng.EditValue + "','" + denqv.EditValue + "',N'" + lehd.EditValue + "','" + phuluc + "','" + ngayve + "',N'" + txthmtd.EditValue + "')");
            else
                gen.ExcuteNonquery("update ContractB set ContractCode=N'" + txtshd.Text + "',ContractName=N'" + txttenbl.EditValue + "',Description=N'" + txtndtd.EditValue + "', StockID='" + makho + "',AccountingObjectID='" + makhach + "',SignerName=N'" + txtndd.EditValue + "',Position=N'" + txtcv.EditValue + "',License=N'" + txttbl.EditValue + "',CompanyTel=N'" + txtsdt.EditValue + "',CompanyFax=N'" + txtfax.EditValue + "',CompanyBankName=N'" + txtnh.EditValue + "',SignedDate='" + denk.EditValue + "',EffectiveDate='" + denhh.EditValue + "',DebtLimit='" + txthmn.EditValue + "',LimitDate='" + txthn.EditValue + "',DeliveryPlace=N'" + txtddgh.EditValue + "',Saved=N'" + txtnl.EditValue + "',Founded='" + denl.EditValue + "',Send='" + deng.EditValue + "',Received='" + denqv.EditValue + "',ParentContract=N'" + lehd.EditValue + "',Inactive='" + ngayve + "',DebtLimitMax ='" + txthmtd.EditValue + "' where ContractID='" + role + "'");
        }

        public void loadplbl(string active, string role, LookUpEdit lehd, TextEdit txtshd, LookUpEdit ledv, SearchLookUpEdit sekh, TextEdit txtsdt, TextEdit txtfax, TextEdit txtndd, TextEdit txtcv, TextEdit txttbl,
           MemoEdit txtnh, MemoEdit txtndtd, DateEdit denk, DateEdit denhh, TextEdit txthmn, TextEdit txthn, RadioButton rbpl, RadioButton rbbl, MemoEdit txtddgh, DateEdit denl, DateEdit deng, DateEdit denqv, TextEdit txtnl, TextEdit txttenbl, CheckEdit chenqv,TextEdit txthmtd)
        {
            DataTable dt = gen.GetTable("select No,ParentContract,ContractCode,ContractName,SignerName,Position,License,CompanyBankName,CompanyTel,CompanyFax,SignedDate,EffectiveDate,DebtLimit,LimitDate,DeliveryPlace,Saved,Founded,Send,Received,a.Description,a.Inactive,DebtLimitMax from ContractB a, Stock b,AccountingObject c  where a.StockID=b.StockID and a.AccountingObjectID=c.AccountingObjectID and ContractID='" + role + "' ");
            if (dt.Rows[0][0].ToString() == "2")
                rbbl.Checked = true;            
            lehd.EditValue = dt.Rows[0][1];
            txtshd.EditValue = dt.Rows[0][2];
            txttenbl.EditValue = dt.Rows[0][3];
            txtndd.EditValue = dt.Rows[0][4];
            txtcv.EditValue = dt.Rows[0][5];
            txttbl.EditValue = dt.Rows[0][6];
            txtnh.EditValue = dt.Rows[0][7];
            txtsdt.EditValue = dt.Rows[0][8];
            txtfax.EditValue = dt.Rows[0][9];
            denk.EditValue = dt.Rows[0][10];
            denhh.EditValue = dt.Rows[0][11];
            txthmn.EditValue = double.Parse(dt.Rows[0][12].ToString());
            txthmtd.EditValue = double.Parse(dt.Rows[0][21].ToString());
            txthn.EditValue = dt.Rows[0][13];
            txtddgh.EditValue = dt.Rows[0][14];
            txtnl.EditValue = dt.Rows[0][15];
            denl.EditValue = dt.Rows[0][16];
            deng.EditValue = dt.Rows[0][17];
            denqv.EditValue = dt.Rows[0][18];
            txtndtd.EditValue = dt.Rows[0][19];
            if (dt.Rows[0][20].ToString() == "1")
                chenqv.Checked = true;
           
        }

        public void tsbtdeletehd(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa Hợp đồng " + view.GetRowCellValue(view.FocusedRowHandle, "Số hợp đồng").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from ContractB where ContractID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn Hợp đồng trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public void tsbtdeleteplbl(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa Phụ lục - Bảo lãnh " + view.GetRowCellValue(view.FocusedRowHandle, "Số").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from ContractB where ContractID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn Phụ lục - Bảo lãnh trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}
