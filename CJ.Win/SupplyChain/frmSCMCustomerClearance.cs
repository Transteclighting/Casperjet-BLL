using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.BasicData;
using CJ.Class.Library;


namespace CJ.Win.SupplyChain
{
    public partial class frmSCMCustomerClearance : Form
    {
        SCMShipment _oSCMShipment;
        SCMShipments _oSCMShipments;
        int nShipmentID = 0;
        string sShipmentNo = "";
        int nExGRDWeek = 0;
        int nExGRDYear = 0;

        public frmSCMCustomerClearance()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(SCMShipment oSCMShipment)
        {

            nShipmentID = 0;
            nShipmentID = oSCMShipment.ShipmentID;
            sShipmentNo = "";
            sShipmentNo = oSCMShipment.ShipmentNo;
            nExGRDWeek = 0;
            nExGRDWeek = oSCMShipment.ExpectedHOArrivalWeek;
            nExGRDYear = 0;
            nExGRDYear = oSCMShipment.ExpectedHOArrivalYear;
            lblCompany.Text = oSCMShipment.CompanyName;
            lblSupplier.Text = oSCMShipment.SupplierName;
            lblShipmentNo.Text = sShipmentNo;
            lblLCNO.Text = oSCMShipment.LCNo;
            lblInvoiceNo.Text = oSCMShipment.InvoiceNo;
            lblOrderNo.Text = oSCMShipment.OrderNo;

            this.Text = "SCM Customer Clearance";

            this.Tag = oSCMShipment;

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region ValidInput
            if (txtCD.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter CD", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCD.Focus();
                return false;
            }
            if (txtRD.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter RD", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRD.Focus();
                return false;
            }
            if (txtSD.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter SD", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSD.Focus();
                return false;
            }
            if (txtVAT.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter VAT", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVAT.Focus();
                return false;
            }
            if (txtAIT.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter AIT", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAIT.Focus();
                return false;
            }
            if (txtATV.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter ATV", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtATV.Focus();
                return false;
            }
            if (txtPSI.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter PSI", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPSI.Focus();
                return false;
            }
            if (txtBG.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter BG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBG.Focus();
                return false;
            }
            if (txtCrfValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter CrfValue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCrfValue.Focus();
                return false;
            }
            if (txtAssessableValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Assessable Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAssessableValue.Focus();
                return false;
            }
            if (txtGlobalTax.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Global Tax", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGlobalTax.Focus();
                return false;
            }
            if (txtServiceCharge.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Service Charge", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceCharge.Focus();
                return false;
            }
            if (txtAdditional.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Additional Charge", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdditional.Focus();
                return false;
            }
            if (txtATV.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter ATV", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtATV.Focus();
                return false;
            }
            if (txtBENo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Bill of entry #", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBENo.Focus();
                return false;
            }
            #endregion

            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                _oSCMShipment = new SCMShipment();
                _oSCMShipment.CD = Convert.ToDouble(txtCD.Text);
                _oSCMShipment.RD = Convert.ToDouble(txtRD.Text);
                _oSCMShipment.SD = Convert.ToDouble(txtSD.Text);
                _oSCMShipment.VAT = Convert.ToDouble(txtVAT.Text);
                _oSCMShipment.AIT = Convert.ToDouble(txtAIT.Text);
                _oSCMShipment.ATV = Convert.ToDouble(txtATV.Text);
                _oSCMShipment.PSI = Convert.ToDouble(txtPSI.Text);
                _oSCMShipment.BG = Convert.ToDouble(txtBG.Text);
                _oSCMShipment.DateOfShippingRetireFromBank = dtDateOfSRBank.Value.Date;
                _oSCMShipment.DutyandTaxSubmittoFADate = dtDutyandTaxSubmittoFADate.Value.Date;
                _oSCMShipment.DutyPaidDate = dtFEDdate.Value.Date;
                _oSCMShipment.CrfValue = Convert.ToDouble(txtCrfValue.Text);
                _oSCMShipment.AssessableValue = Convert.ToDouble(txtAssessableValue.Text);
                _oSCMShipment.GlobalTax = Convert.ToDouble(txtGlobalTax.Text);
                _oSCMShipment.ServiceCharge = Convert.ToDouble(txtServiceCharge.Text);
                _oSCMShipment.Additional = Convert.ToDouble(txtAdditional.Text);
                _oSCMShipment.Status = (int)Dictionary.SCMStatus.CustomClearance;
                _oSCMShipment.BENo = txtBENo.Text;
                _oSCMShipment.BEDate = dtBEDate.Value.Date;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSCMShipment.UpdateCustomerClearance(nShipmentID, nExGRDWeek, nExGRDYear, txtRemarks.Text.Trim());

                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Successfully Add CustomerClearance ShipmentNo # " + sShipmentNo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}