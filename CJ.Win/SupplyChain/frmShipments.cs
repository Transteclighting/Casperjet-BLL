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
    public partial class frmShipments : Form
    {
        SCMShipment _oSCMShipment;
        SCMShipments _oSCMShipments;
        Companys _oCompanys;
        Suppliers _oSuppliers;
        bool IsCheck = false;

        public frmShipments()
        {
            InitializeComponent();
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            frmSCMShipments oform = new frmSCMShipments();
            oform.ShowDialog();
            DataLoadControl();

        }

        private void frmShipments_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombos()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            //Company
            _oCompanys = new Companys();
            _oCompanys.RefreshByCompany(Utility.CompanyInfo);
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            // Suppliers
            _oSuppliers = new Suppliers();
            _oSuppliers.GetSupplierBySupplierName();
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("<Select Supplier>");
            foreach (Supplier oSupplier in _oSuppliers)
            {
                cmbSupplier.Items.Add(oSupplier.SupplierName);
            }
            cmbSupplier.SelectedIndex = 0;

            // Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SCMStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SCMStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


        }

        private void SetListViewRowColour()
        {
            if (lvwShipment.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwShipment.Items)
                {
                    if (oItem.SubItems[8].Text == "PSI")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[8].Text == "OrderPlace")
                    {
                        oItem.BackColor = Color.GreenYellow;

                    }
                    else if (oItem.SubItems[8].Text == "PIReceive")
                    {
                        oItem.BackColor = Color.LightPink;

                    }
                    else if (oItem.SubItems[8].Text == "LCProcessing")
                    {
                        oItem.BackColor = Color.LightSkyBlue;

                    }
                    else if (oItem.SubItems[8].Text == "LCOpening")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[8].Text == "Shipment")
                    {
                        oItem.BackColor = Color.Magenta;

                    }
                    else if (oItem.SubItems[8].Text == "CustomerClearance")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[8].Text == "Release")
                    {
                        oItem.BackColor = Color.Pink;

                    }
                    else if (oItem.SubItems[8].Text == "ReadyForGRD")
                    {
                        oItem.BackColor = Color.Green;

                    }
                    else
                    {
                        oItem.BackColor = Color.Silver;
                    }

                }
            }
        }
        private void DataLoadControl()
        {
            _oSCMShipments = new SCMShipments();
            lvwShipment.Items.Clear();

            int nSupplier = 0;

            if (cmbSupplier.SelectedIndex == 0)
            {
                nSupplier = -1;
            }
            else
            {
                nSupplier = _oSuppliers[cmbSupplier.SelectedIndex - 1].SupplierID;
            }

            int nCompany = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompany = -1;
            }

            else
            {
                nCompany = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oSCMShipments.RefreshShipment(dtFromdate.Value.Date, dtTodate.Value.Date, txtShipmentNo.Text.Trim(), txtInvoiceNo.Text.Trim(), txtLCNo.Text.Trim(), txtOrderNo.Text.Trim(), txtPSINo.Text.Trim(),nSupplier, nCompany,nStatus, IsCheck);
            DBController.Instance.CloseConnection();
            foreach (SCMShipment oSCMShipment in _oSCMShipments)
            {
                ListViewItem oItem = lvwShipment.Items.Add(oSCMShipment.ShipmentNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSCMShipment.ShipmentDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSCMShipment.InvoiceNo.ToString());
                oItem.SubItems.Add(oSCMShipment.LCNo.ToString());
                oItem.SubItems.Add(oSCMShipment.OrderNo.ToString());
                oItem.SubItems.Add(oSCMShipment.PSINo.ToString());
                oItem.SubItems.Add(oSCMShipment.SupplierName.ToString());
                oItem.SubItems.Add(oSCMShipment.CompanyName.ToString());
                oItem.SubItems.Add(oSCMShipment.StatusName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SCMStatus), oSCMShipment.Status));
                oItem.Tag = oSCMShipment;
            }
            this.Text = "Shipments [" + _oSCMShipments.Count + "]";
            SetListViewRowColour();
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

        private void btnCustomerClearance_Click(object sender, EventArgs e)
        {
            if (lvwShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Shipment to Customer Clearance.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMShipment oSCMShipment = (SCMShipment)lvwShipment.SelectedItems[0].Tag;
            if (oSCMShipment.Status == (int)Dictionary.SCMStatus.Shipment)
            {
                frmSCMCustomerClearance oForm = new frmSCMCustomerClearance();
                oForm.ShowDialog(oSCMShipment);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Shipment status can be Customer Clearance", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (lvwShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Shipment to Release.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMShipment oSCMShipment = (SCMShipment)lvwShipment.SelectedItems[0].Tag;
            if (oSCMShipment.Status == (int)Dictionary.SCMStatus.CustomClearance)
            {
                frmSCMRelease oForm = new frmSCMRelease();
                oForm.ShowDialog(oSCMShipment);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only CustomerClearance status can be Release", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnReadyForGRD_Click(object sender, EventArgs e)
        {
            if (lvwShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Shipment to Ready For GRD.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMShipment oSCMShipment = (SCMShipment)lvwShipment.SelectedItems[0].Tag;
            if (oSCMShipment.Status == (int)Dictionary.SCMStatus.Release)
            {
                frmReadyForGRD oForm  = new frmReadyForGRD();
                oForm.ShowDialog(oSCMShipment);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Release status can be Ready For GRD", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            if (lvwShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Shipment to Billing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMShipment oSCMShipment = (SCMShipment)lvwShipment.SelectedItems[0].Tag;
            if (oSCMShipment.Status == (int)Dictionary.SCMStatus.LogAcknowledgement)
            {
                frmSCMBilling oForm = new frmSCMBilling();
                oForm.ShowDialog(oSCMShipment);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only log acknowledgement status can be Billing", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnfrmLogAcknowledgement_Click(object sender, EventArgs e)
        {
            if (lvwShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Shipment to Billing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMShipment oSCMShipment = (SCMShipment)lvwShipment.SelectedItems[0].Tag;
            if (oSCMShipment.Status == (int)Dictionary.SCMStatus.ReadyForGRD)
            {
                frmSCMLogAcknowledgements oForm = new frmSCMLogAcknowledgements();
                oForm.ShowDialog(oSCMShipment);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only ready for GRD status can be  log acknowledgement", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}