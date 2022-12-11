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
    public partial class frmSCMPIS : Form
    {
        Companys _oCompanys;
        Suppliers _oSuppliers;
        SCMOrders _oSCMOrders;
        bool IsCheck = false;
        public frmSCMPIS()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();

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
            cmbSupplier.Items.Add("<All>");
            foreach (Supplier oSupplier in _oSuppliers)
            {
                cmbSupplier.Items.Add(oSupplier.SupplierName);
            }
            cmbSupplier.SelectedIndex = 0;

        }
        private void SetListViewRowColour()
        {
            if (lvwOrder.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrder.Items)
                {
                    if (oItem.SubItems[5].Text == "PSI")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[5].Text == "OrderPlace")
                    {
                        oItem.BackColor = Color.GreenYellow;

                    }
                    else if (oItem.SubItems[5].Text == "PIReceive")
                    {
                        oItem.BackColor = Color.LightPink;

                    }
                    else if (oItem.SubItems[5].Text == "LCProcessing")
                    {
                        oItem.BackColor = Color.LightSkyBlue;

                    }
                    else if (oItem.SubItems[5].Text == "LCOpening")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[5].Text == "Shipment")
                    {
                        oItem.BackColor = Color.Magenta;

                    }
                    else if (oItem.SubItems[5].Text == "CustomerClearance")
                    {
                        oItem.BackColor = Color.Yellow;

                    }
                    else if (oItem.SubItems[5].Text == "Release")
                    {
                        oItem.BackColor = Color.Cyan;

                    }
                    else if (oItem.SubItems[5].Text == "ReadyForGRD")
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
            _oSCMOrders = new SCMOrders();
            lvwOrder.Items.Clear();

            int nCompany = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompany = -1;
            }
            else
            {
                nCompany = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }

            int nSupplier = 0;

            if (cmbSupplier.SelectedIndex == 0)
            {
                nSupplier = -1;
            }
            else
            {
                nSupplier = _oSuppliers[cmbSupplier.SelectedIndex - 1].SupplierID;
            }


            DBController.Instance.OpenNewConnection();
            _oSCMOrders.RefreshOrderForPI(dtFromdate.Value.Date, dtTodate.Value.Date, nCompany, txtPSINo.Text.Trim(), IsCheck, nSupplier, txtOrderNo.Text.Trim());
            DBController.Instance.CloseConnection();

            foreach (SCMOrder oSCMOrder in _oSCMOrders)
            {
                ListViewItem oItem = lvwOrder.Items.Add(oSCMOrder.OrderNo.ToString());
                oItem.SubItems.Add(oSCMOrder.PSINo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSCMOrder.OrderPlaceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSCMOrder.CompanyName.ToString());
                oItem.SubItems.Add(oSCMOrder.SupplierName.ToString());
                oItem.SubItems.Add(oSCMOrder.StatusName.ToString());

                oItem.Tag = oSCMOrder;
            }
            this.Text = "PSI [" + _oSCMOrders.Count + "]";
            SetListViewRowColour();
        }

        private void frmSCMPIS_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPIReceived_Click(object sender, EventArgs e)
        {
            if (lvwOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Order to PI Receive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMOrder oSCMOrder = (SCMOrder)lvwOrder.SelectedItems[0].Tag;
            DBController.Instance.OpenNewConnection();
            oSCMOrder.RefreshPSI(oSCMOrder.PSIID);
            if (oSCMOrder.Status == (int)Dictionary.SCMStatus.OrderPlace)
            {
                if (oSCMOrder.CompanyID == 82942)       ///Bangladesh Electrical Industries Limited
                {
                    frmSCMPIBEIL oForm = new frmSCMPIBEIL();
                    oForm.ShowDialog(oSCMOrder);                    

                }
                else
                {
                    frmSCMPI oForm = new frmSCMPI();
                    oForm.ShowDialog(oSCMOrder);
                    
                }
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Order Status Can Be PI Receive", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (lvwOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Order to Update Status (PIReceive).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to Update Status  ", "Confirm Ticket Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    DBController.Instance.OpenNewConnection();
                    SCMOrder oSCMOrder = (SCMOrder)lvwOrder.SelectedItems[0].Tag;
                    oSCMOrder.OrderID = oSCMOrder.OrderID;
                    oSCMOrder.Status = (int)Dictionary.SCMStatus.PIReceive;
                    oSCMOrder.UpdateStatus();
                    oSCMOrder.RefreshPendingOrderStatus(oSCMOrder.PSIID);
                    if (oSCMOrder.PendingStatus == 0)
                    {
                        oSCMOrder.UpdateStatusPSI(oSCMOrder.PSIID);

                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Update Status", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                    return;
                    
                }
            }
        }
    }
}