using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win
{
    public partial class frmSparePartSearch : Form
    {
        public string sSPCode;
        public string sSPName;
        public int nSPId;
        public Object sSalePrice;

        public SpareParts _oSpareParts;

        public frmSparePartSearch()
        {
            InitializeComponent();
        }

        private void frmSPSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {

            SparePartss oSparePartss = new SparePartss();

            lvwSPSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSparePartss.RefreshSP(txtCode.Text, txtName.Text, txtModel.Text, txtBrand.Text, txtLocationCode.Text);

            this.Text = "Total Job = " + "[" + oSparePartss.Count + "]";
            foreach (SpareParts oSpareParts in oSparePartss)
            {
                ListViewItem oItem = lvwSPSearch.Items.Add(oSpareParts.Code.ToString());
                oItem.SubItems.Add(oSpareParts.Name);
                oItem.SubItems.Add(oSpareParts.ModelNo);
                oItem.SubItems.Add(oSpareParts.BrandName);
                oItem.SubItems.Add(oSpareParts.LocationCode);

                oItem.Tag = oSpareParts;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwSPSearch_DoubleClick(object sender, EventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }

        private void returnSelectedProduct()
        {
            foreach (ListViewItem oItem in lvwSPSearch.SelectedItems)
            {
                _oSpareParts = (SpareParts)lvwSPSearch.SelectedItems[0].Tag;

                
                nSPId = _oSpareParts.ID;
                sSPCode = _oSpareParts.Code;
                sSPName = _oSpareParts.Name;
                sSalePrice = _oSpareParts.SalePrice;

            }

        }
        private void lvwSPSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }

        public bool ShowDialog(SpareParts oSpareParts)
        {
            _oSpareParts = oSpareParts;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }

}