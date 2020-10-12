using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_ii : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        ii ii = new ii();
        string active, role,userid;
        public delegate void ac();
        public ac myac;
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getuserid(string a)
        {
            userid = a;
            return userid;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public Frm_ii()
        {
            InitializeComponent();
        }

        private void Frm_ii_Load(object sender, EventArgs e)
        {
            ii.loadiiccom(leloai, role, active);
            ii.loadiimb(lemb);
            if (active == "1")
            {
                this.Text = "Sửa vật tư hàng hóa";
                DataTable da = new DataTable();
                da = gen.GetTable("select * from InventoryItem where InventoryItemID='" + role + "'");
                txtcode.Text = da.Rows[0][2].ToString();
                txtname.Text = da.Rows[0][4].ToString();
                txtdvt.Text = da.Rows[0][6].ToString();
                txtdvcd.Text = da.Rows[0][7].ToString();
                try
                {
                    txttlcd.EditValue = Double.Parse(da.Rows[0][8].ToString());
                }
                catch { }
               
                txtthbh.Text = da.Rows[0][5].ToString();
                chbntdoi.Checked = (bool)da.Rows[0][22];
                try
                {
                    txtdgtk.EditValue = Double.Parse(da.Rows[0][10].ToString());
                }
                catch { }
                ii.loadiiccomtc(letc, active, da.Rows[0][20].ToString());
                ii.loadiiccomthue(lethue, active, da.Rows[0][18].ToString());
                ii.loadiimbrole(lemb, da.Rows[0][31].ToString());
                txtnganhhang.Text = da.Rows[0][25].ToString();
                txtnhomhang.Text = da.Rows[0][26].ToString();
                if (da.Rows[0][21].ToString() == "True")
                    chhkm.Checked = true;
            }
            else
            {
                this.Text = "Thêm vật tư, hàng hóa";
                ii.loadiiccomtc(letc, active, "");
                ii.loadiiccomthue(lethue, active, "");
            }
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            string loai = gen.GetString("select * from InventoryItemCategory where InventoryCategoryCode='" + leloai.EditValue.ToString().Trim() + "'");
            int tc = Convert.ToInt32(letc.EditValue.ToString());
            string thue = "0";
            string tlcd, dgtk;
            if (txttlcd.Text == "") tlcd = "NULL";
            else tlcd = txttlcd.Text.Replace(".", "").Replace(",", ".");
            if (txtdgtk.Text == "") dgtk = "NULL";
            else dgtk = txtdgtk.Text.Replace(".", "").Replace(",", ".");
            if (txtcode.Text == "") MessageBox.Show("Mã vật tư, hàng hóa không được bỏ trống.", "HAMACO");
            else if (txtname.Text == "") MessageBox.Show("Tên vật tư hàng hóa không được bỏ trống.", "HAMACO");
            {
                if (active == "1")
                {
                    try
                    {
                        string mb = gen.GetString("select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + lemb.Text + "'");
                        gen.ExcuteNonquery("update hamaco.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ", Parent='" + mb + "',SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked+ "' where InventoryItemCode='" + txtcode.Text + "'");
                        gen.ExcuteNonquery("update hamaco_ta.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ", Parent='" + mb + "',SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");
                        gen.ExcuteNonquery("update hamaco_tn.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ", Parent='" + mb + "',SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");
                        gen.ExcuteNonquery("update hamaco_vithanh.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ", Parent='" + mb + "',SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");
                        gen.ExcuteNonquery("update hamaco_qlk.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ", Parent='" + mb + "',SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");
                    }
                    catch
                    {
                        gen.ExcuteNonquery("update hamaco.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ",SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");
                        gen.ExcuteNonquery("update hamaco_ta.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ",SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");
                        gen.ExcuteNonquery("update hamaco_tn.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ",SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");
                        gen.ExcuteNonquery("update hamaco_vithanh.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ",SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");
                        gen.ExcuteNonquery("update hamaco_qlk.dbo.InventoryItem set InventoryItemName=N'" + txtname.Text + "',Unit=N'" + txtdvt.Text + "',ConvertUnit=N'" + txtdvcd.Text + "',ConvertRate=" + tlcd + ",GuarantyPeriod=N'" + txtthbh.Text + "',Inactive='" + chbntdoi.Checked.ToString() + "',InventoryCategoryID='" + loai + "',TaxRate='" + thue + "',InventoryItemType='" + tc + "',SalePrice=" + dgtk + ",SaleDescription=N'" + txtnganhhang.Text + "',PurchaseDescription=N'" + txtnhomhang.Text + "', IsSystem='" + chhkm.Checked + "' where InventoryItemCode='" + txtcode.Text + "'");                    
                    }
                    this.myac();
                    this.Close();
                }
                else
                {
                    try
                    {
                        string mb = gen.GetString("select * from hamaco.dbo.InventoryItem where InventoryItemCode='" + lemb.Text + "'");
                        ii.checkii(active, txtcode, txtname, "insert into hamaco.dbo.InventoryItem(InventoryItemID,InventoryCategoryID,InventoryItemCode,InventoryItemName,GuarantyPeriod,Unit,ConvertUnit,ConvertRate,SalePrice,TaxRate,InventoryItemType,Inactive,Parent,SaleDescription,PurchaseDescription,IsSystem) values(newid(),'" + loai + "','" + txtcode.Text + "',N'" + txtname.Text + "',N'" + txtthbh.Text + "',N'" + txtdvt.Text + "',N'" + txtdvcd.Text + "'," + tlcd + "," + dgtk + ",'" + thue + "','" + tc + "','" + chbntdoi.Checked.ToString() + "','" + mb + "',N'" + txtnganhhang.Text + "',N'" + txtnhomhang.Text + "','" + chhkm.Checked + "')", this);
                    }
                    catch
                    {
                        ii.checkii(active, txtcode, txtname, "insert into hamaco.dbo.InventoryItem(InventoryItemID,InventoryCategoryID,InventoryItemCode,InventoryItemName,GuarantyPeriod,Unit,ConvertUnit,ConvertRate,SalePrice,TaxRate,InventoryItemType,Inactive,SaleDescription,PurchaseDescription,IsSystem) values(newid(),'" + loai + "','" + txtcode.Text + "',N'" + txtname.Text + "',N'" + txtthbh.Text + "',N'" + txtdvt.Text + "',N'" + txtdvcd.Text + "'," + tlcd + "," + dgtk + ",'" + thue + "','" + tc + "','" + chbntdoi.Checked.ToString() + "',N'" + txtnganhhang.Text + "',N'" + txtnhomhang.Text + "','" + chhkm.Checked + "')", this);
                    }
                }
            }
        }

       
        private void txtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}