using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_intonghop : DevExpress.XtraEditors.XtraForm
    {
        baocaocongno131 baocaocn131 = new baocaocongno131();
        public Frm_intonghop()
        {
            InitializeComponent();
        }
        string ngaychungtu, tsbt;
        GridView view;

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
        public GridView  getview(GridView a)
        {
            view = a;
            return view;
        }

        private void Frm_intonghop_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            if ( radioGroup1.EditValue.ToString() == "1" )
                baocaocn131.loadbccn(ngaychungtu, tsbt, "", view,"");
            else
                baocaocn131.loadbchitietlai(ngaychungtu, tsbt+"ctth", "", view);
        }
    }
}