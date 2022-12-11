using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CSD
{
    public partial class frmCustomerSatisfactions : Form
    {
        CSDCustomerSatisfactions _oCSDCustomerSatisfactions;
        bool IsCheck = false;
        Brands oBrands;
        string _sBrandID = "";

        public frmCustomerSatisfactions()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            oBrands = new Brands();
            oBrands.GetMasterBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("ALL");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;
            //IsHappyCall
            cmbIsHappyCall.Items.Clear();
            cmbIsHappyCall.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsHappyCall)))
            {
                cmbIsHappyCall.Items.Add(Enum.GetName(typeof(Dictionary.IsHappyCall), GetEnum));
            }
            cmbIsHappyCall.SelectedIndex = 0;

            //CSDJobType
            cmbJobType.Items.Clear();
            cmbJobType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDJobType)))
            {
                cmbJobType.Items.Add(Enum.GetName(typeof(Dictionary.CSDJobType), GetEnum));
            }
            cmbJobType.SelectedIndex = 0;

            //CSDServiceType
            cmbServiceType.Items.Clear();
            cmbServiceType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ServiceType)))
            {
                cmbServiceType.Items.Add(Enum.GetName(typeof(Dictionary.ServiceType), GetEnum));
            }
            cmbServiceType.SelectedIndex = 0;

            cmbCallStatus.Items.Clear();
            cmbCallStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDHappyCallStatus)))
            {
                cmbCallStatus.Items.Add(Enum.GetName(typeof(Dictionary.CSDHappyCallStatus), GetEnum));
            }
            cmbCallStatus.SelectedIndex = 0;

        }
        private void SetListViewRowColour()
        {
            if (lvwCustSatisfaction.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCustSatisfaction.Items)
                {
                    if (oItem.SubItems[10].Text == "Yes")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else 
                    {
                        oItem.BackColor = Color.LightPink;
                    }
                    //else 
                    //{
                    //    oItem.BackColor = Color.LightPink;
                    //}
                }
            }
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oCSDCustomerSatisfactions = new CSDCustomerSatisfactions();
            lvwCustSatisfaction.Items.Clear();

            int nIsHappyCall = 0;
            if (cmbIsHappyCall.SelectedIndex == 0)
            {
                nIsHappyCall = -1;
            }
            else
            {
                nIsHappyCall = cmbIsHappyCall.SelectedIndex -1;
            }
            int nJobType = 0;
            if (cmbJobType.SelectedIndex == 0)
            {
                nJobType = -1;
            }
            else
            {
                nJobType = cmbJobType.SelectedIndex;
            }

            int nServiceType = 0;
            if (cmbServiceType.SelectedIndex == 0)
            {
                nServiceType = -1;
            }
            else
            {
                nServiceType = cmbServiceType.SelectedIndex;
            }
            int nStatus = -1;
            if (cmbCallStatus.SelectedIndex != 0)
            {
                nStatus = cmbCallStatus.SelectedIndex;
            }
            //int nBarndID = 0;
            //if (cmbBrand.SelectedIndex == 0)
            //{
            //    nBarndID = -1;
            //}
            //else
            //{
            //    nBarndID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            //}
            string sBrnID = "";
            string sBrandID = _sBrandID;
            if (sBrandID == "")
            {
                if (cmbBrand.SelectedIndex != 0)
                {
                    sBrnID = Convert.ToString(oBrands[cmbBrand.SelectedIndex - 1].BrandID);
                }

            }
            if (sBrnID != "")
            {
                sBrandID = sBrnID;
            }

            DBController.Instance.OpenNewConnection();
            _oCSDCustomerSatisfactions.GetDataHappyCallStatus(dtFromdate.Value.Date, dtTodate.Value.Date, txtJobNo.Text.Trim(), txtMobile.Text.Trim(), txtCustName.Text.Trim(), txtProduct.Text.Trim(), txtSL.Text.Trim(), nIsHappyCall, nJobType, nServiceType,IsCheck, nStatus, sBrandID);
            DBController.Instance.CloseConnection();

            foreach (CSDCustomerSatisfaction oCSDCustomerSatisfaction in _oCSDCustomerSatisfactions)
            {
                ListViewItem oItem = lvwCustSatisfaction.Items.Add(oCSDCustomerSatisfaction.JobNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oCSDCustomerSatisfaction.JobCreationDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oCSDCustomerSatisfaction.DeliveryDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDCustomerSatisfaction.CustomerName.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.Mobile.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.ProductName.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.BrandDesc.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.SerialNo.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.JobTypeName.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.ServiceTypeName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsHappyCall), oCSDCustomerSatisfaction.IsHappyCall));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDHappyCallStatus), oCSDCustomerSatisfaction.Status));

                oItem.Tag = oCSDCustomerSatisfaction;
            }
            SetListViewRowColour();
            this.Text = "Call List [" + _oCSDCustomerSatisfactions.Count + "]";
            this.Cursor = Cursors.Default;
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmCustomerSatisfactions_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwCustSatisfaction.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDCustomerSatisfaction oCSDCustomerSatisfaction = (CSDCustomerSatisfaction)lvwCustSatisfaction.SelectedItems[0].Tag;
            if (lvwCustSatisfaction.SelectedItems[0].SubItems[11].Text == "Satisfy")
            {
                MessageBox.Show("After Satisfy Can't be Add Again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCustSatisfaction.SelectedItems[0].SubItems[11].Text == "Dissatisfy")
            {
                MessageBox.Show("After Dissatisfy Can't be Add Again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCustSatisfaction.SelectedItems[0].SubItems[11].Text == "Moderate")
            {
                MessageBox.Show("After Moderate Can't be Add Again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (oCSDCustomerSatisfaction.IsHappyCall == (int)Dictionary.IsHappyCall.No)
            //{
            frmCustomerSatisfaction oForm = new frmCustomerSatisfaction();
                oForm.ShowDialog(oCSDCustomerSatisfaction);
                if (oForm._bActivity)
                {
                    DataLoadControl();
                }
            //}
            //else
            //{
            //    MessageBox.Show("Only IsHappyCall No Status Can be Add.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklblMultiSelectBrands_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBrandsMultiSelect oForm = new frmBrandsMultiSelect();
            oForm.ShowDialog();
            linklblMultiSelectBrands.Text = "Selected " + oForm._nCount.ToString() + " Brands";
            _sBrandID = "";
            _sBrandID = oForm._sSelectedBrandID;
            if (_sBrandID != "")
            {
                cmbBrand.SelectedIndex = 0;
                cmbBrand.Enabled = false;
            }
            else
            {
                cmbBrand.Enabled = true;
            }
        }
    }
}