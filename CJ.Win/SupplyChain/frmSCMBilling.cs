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
    public partial class frmSCMBilling : Form
    {
        SCMShipment _oSCMShipment;
        SCMShipments _oSCMShipments;
        int nShipmentID = 0;
        string sShipmentNo = "";
        int nExGRDWeek = 0;
        int nExGRDYear = 0;

        public frmSCMBilling()
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

            this.Text = "SCM Billing";

            this.Tag = oSCMShipment;

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _oSCMShipment = new SCMShipment();
            _oSCMShipment.OceanFreightinBDT =Convert.ToDouble(txtOceanFreightinBDT.Text);
            _oSCMShipment.Demurrage = Convert.ToDouble(txtDemurrage.Text);
            _oSCMShipment.Receivable = Convert.ToDouble(txtReceivable.Text);
            _oSCMShipment.MiscNonReceivable = Convert.ToDouble(txtMiscNonReceivable.Text);
            _oSCMShipment.AdvancedAmount = Convert.ToDouble(txtAdvancedAmount.Text);

            _oSCMShipment.Status = (int)Dictionary.SCMStatus.Billing;


            try
            {
                DBController.Instance.BeginNewTransaction();
                _oSCMShipment.UpdateBilling(nShipmentID, nExGRDWeek, nExGRDYear, txtRemarks.Text.Trim());

                DBController.Instance.CommitTransaction();

                MessageBox.Show("Successfully Billing ShipmentNo # " + sShipmentNo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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