using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpmauthuchidonvi : DevExpress.XtraReports.UI.XtraReport
    {
        public rpmauthuchidonvi()
        {
            InitializeComponent();
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            //xrLabel11.DataBindings.Add("Text", DataSource, "nguoinop");      
            //xrLabel19.DataBindings.Add("Text", DataSource, "chungtugoc");
            //
            xrLabel9.DataBindings.Add("Text", DataSource, "sophieu");
            //xrLabel4.DataBindings.Add("Text", DataSource, "hoten");
            //xrLabel7.DataBindings.Add("Text", DataSource, "mauso");
            //xrTableCell8.DataBindings.Add("Text", DataSource, "sotien", "{0:n0}");
            //xrTableCell2.DataBindings.Add("Text", DataSource, "no");
            //xrTableCell7.DataBindings.Add("Text", DataSource, "co");
            //xrTableCell57.DataBindings.Add("Text", DataSource, "sotien", "{0:n0}");
            //xrTableCell5.DataBindings.Add("Text", DataSource, "sotien", "{0:n0}");
            //xrTableCell1.DataBindings.Add("Text", DataSource, "makhach");
            //xrLabel2.DataBindings.Add("Text", DataSource, "phieu");


            xrLabel3.DataBindings.Add("Text", DataSource, "ngaychungtu");
            xrLabel11.DataBindings.Add("Text", DataSource, "tenkhach");
            xrLabel13.DataBindings.Add("Text", DataSource, "diachi");
            xrLabel14.DataBindings.Add("Text", DataSource, "sotien", "{0:n0}");
            xrLabel21.DataBindings.Add("Text", DataSource, "sotienchu");
            xrLabel17.DataBindings.Add("Text", DataSource, "lydo");
            xrLabel6.DataBindings.Add("Text", DataSource, "kho");
            xrLabel1.DataBindings.Add("Text", DataSource, "congty");
        }
    }
}
