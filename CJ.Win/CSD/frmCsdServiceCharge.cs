using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{ 
    public partial class frmCsdServiceCharge : Form
    {
        private CSDServiceCharges _oCSDServiceCharges;
        private CSDServiceChargeCustomers _oCSDServiceChargeCustomers;
        public bool _isAnyactivityDone = false;
        public frmCsdServiceCharge()
        {
            InitializeComponent();
        }

        public void ShowDialog(CSDServiceChargeProduct oCSDServiceChargeProduct)
        {
            this.Tag = oCSDServiceChargeProduct;
            LoadCombos();
            ctlProducts1.txtCode.Text = oCSDServiceChargeProduct.ProductCode;
            cmbServiceCharge.Text= oCSDServiceChargeProduct.ServiceChargeID.ToString();
            //cmbServiceCharge.SelectedIndex = (int)oCSDServiceChargeProduct.ServiceChargeID;
            cmbServiceCharge.SelectedIndex = _oCSDServiceCharges.GetIndex(oCSDServiceChargeProduct.ServiceChargeID) + 1;

            ctlProducts1.Enabled = false;
            this.ShowDialog();
        }

        private void LoadCombos()
        {
            _oCSDServiceCharges = new CSDServiceCharges();
            _oCSDServiceCharges.Refresh();
            cmbServiceCharge.Items.Clear();
            cmbServiceCharge.Items.Add("--Select Service Charge--");
            foreach (CSDServiceCharge oCSDServiceCharge in _oCSDServiceCharges)
            {
                cmbServiceCharge.Items.Add(oCSDServiceCharge.ServiceChargeName);
            }
            cmbServiceCharge.SelectedIndex = 0;
           
        }



        private void frmCsdServiceCharge_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (ctlProducts1.SelectedSerarchProduct == null || ctlProducts1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProducts1.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {
            _isAnyactivityDone = true;
            if (this.Tag == null)
            {
                CSDServiceChargeProduct oCSDServiceChargeProduct = new CSDServiceChargeProduct();
                oCSDServiceChargeProduct.ProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
                oCSDServiceChargeProduct.ServiceChargeID = _oCSDServiceCharges[cmbServiceCharge.SelectedIndex - 1].ServiceChargeID;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDServiceChargeProduct.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                
                CSDServiceChargeProduct oCSDServiceChargeProduct = (CSDServiceChargeProduct)this.Tag;
                oCSDServiceChargeProduct.ProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
                oCSDServiceChargeProduct.ServiceChargeID = _oCSDServiceCharges[cmbServiceCharge.SelectedIndex - 1].ServiceChargeID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDServiceChargeProduct.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The CSDServiceChargeProduct : " + oCSDServiceChargeProduct.ProductID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void cmbServiceCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServiceCharge.SelectedIndex > 0)
            {
                _oCSDServiceChargeCustomers = new CSDServiceChargeCustomers();
                int nServiceChargeID = 0;
                nServiceChargeID = _oCSDServiceCharges[cmbServiceCharge.SelectedIndex - 1].ServiceChargeID;
                DBController.Instance.OpenNewConnection();
                _oCSDServiceChargeCustomers.RefreshBySCID(nServiceChargeID);
                foreach (CSDServiceChargeCustomer oCSDServiceCharge in _oCSDServiceChargeCustomers)
                {
                    if (oCSDServiceCharge.ChargeType == (int)Dictionary.CSDServiceChargeType.Service_Charge)
                    {
                        txtServiceCharge.Text = oCSDServiceCharge.Amount.ToString();
                    }
                    else if (oCSDServiceCharge.ChargeType == (int)Dictionary.CSDServiceChargeType.Inspection_Charge)
                    {
                        txtInspectionCharge.Text = oCSDServiceCharge.Amount.ToString();
                    }
                    else if (oCSDServiceCharge.ChargeType == (int)Dictionary.CSDServiceChargeType.Installation_Charge)
                    {
                        txtInstallationCharge.Text = oCSDServiceCharge.Amount.ToString();
                    }
                    else if (oCSDServiceCharge.ChargeType == (int)Dictionary.CSDServiceChargeType.Re_Installation_Charge)
                    {
                        txtReInstallationCharge.Text = oCSDServiceCharge.Amount.ToString();
                    }
                    else if (oCSDServiceCharge.ChargeType == (int)Dictionary.CSDServiceChargeType.Dismantling_Charge)
                    {
                        txtDismantlingCharge.Text = oCSDServiceCharge.Amount.ToString();
                    }
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}