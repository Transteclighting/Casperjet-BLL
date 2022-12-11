

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
    public partial class frmSparePartSearchR : Form
    {
        public string sSPCode;
        public string sSPName;
        public int nSPId;
        public int nCurrentStock;
        public double sCostPrice;
        public double sSalePrice;
        Stores _oStores;
        
        public SparePartsR _oSparePartsR;
        int _nStoreID = 0;

        public frmSparePartSearchR(int nStoreID)
        {
            InitializeComponent();
            _nStoreID = nStoreID;
        }

        private void frmSPSearchR_Load(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void DataLoadControl()
        {
            SparePartsRs oSparePartsRs = new SparePartsRs();            
            lvwSPSearchR.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSparePartsRs.RefreshForSearch(txtCode.Text, txtName.Text, txtModel.Text, txtBrand.Text, txtLocationCode.Text, _oStores[cmbStore.SelectedIndex-1].StoreID);
            this.Text = "Total Job = " + "[" + oSparePartsRs.Count + "]";
            foreach (SparePartsR oSparePartsR in oSparePartsRs)
            {
                ListViewItem oItem = lvwSPSearchR.Items.Add(oSparePartsR.Code.ToString());
                oItem.SubItems.Add(oSparePartsR.Name);
                oItem.SubItems.Add(oSparePartsR.ModelNo);
                oItem.SubItems.Add(oSparePartsR.BrandName);
                oItem.SubItems.Add(oSparePartsR.LocationName);
                oItem.SubItems.Add(oSparePartsR.CurrentStock.ToString());
                oItem.SubItems.Add(oSparePartsR.SalePrice.ToString());
                oItem.Tag = oSparePartsR;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwSPSearchR_DoubleClick(object sender, EventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }

        private void returnSelectedProduct()
        {
            foreach (ListViewItem oItem in lvwSPSearchR.SelectedItems)
            {
                _oSparePartsR = (SparePartsR)lvwSPSearchR.SelectedItems[0].Tag;

                nSPId = _oSparePartsR.SparePartID;
                sSPCode = _oSparePartsR.Code;
                sSPName = _oSparePartsR.Name;
                nCurrentStock = _oSparePartsR.CurrentStock;
                sCostPrice = _oSparePartsR.CostPrice;
                sSalePrice = _oSparePartsR.SalePrice;

            }

        }
        private void lvwSPSearchR_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }

        public bool ShowDialog(SparePartsR oSparePartsR)
        {
            _oSparePartsR = oSparePartsR;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (cmbStore.SelectedIndex != 0)
            {
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select Store First","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void frmSparePartSearchR_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        private void LoadCombos()
        {
            _oStores = new Stores();
            _oStores.RefreshChildStore();
            cmbStore.Items.Clear();
            cmbStore.Items.Add("<Select Store>");
            foreach (Store oStore in _oStores)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oStore.ChildSotre;
                //item.Value = oStore.StoreID.ToString();
                //cmbStore.Items.Add(item);

                cmbStore.Items.Add(oStore.ChildSotre);
            }
            if (_nStoreID == 0)
            {
                cmbStore.SelectedIndex = 0;
            }
            else
            {
                cmbStore.SelectedIndex = _oStores.GetIndex(_nStoreID)+1;
                cmbStore.Enabled = false;
                DataLoadControl();
            }

        }

    }

}