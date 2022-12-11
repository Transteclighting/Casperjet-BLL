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
    public partial class frmSCMOrders : Form
    {
        Companys _oCompanys;
        SCMPurchaseOrder _oSCMPurchaseOrder;
        SCMPurchaseOrders _oSCMPurchaseOrders;
        int nPOID = 0;
        string sPONo = "";
        bool IsCheck = false;

        public frmSCMOrders()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombos()
        {
            dtFromPIdate.Value = DateTime.Today;
            dtToPIdate.Value = DateTime.Today;

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

        }
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (lvwPI.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a PO to Order Place.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPurchaseOrder oSCMPurchaseOrder = (SCMPurchaseOrder)lvwPI.SelectedItems[0].Tag;
            if (oSCMPurchaseOrder.Status == (int)Dictionary.SCMStatus.PSI)
            {
                frmSCMOrderPlace oForm = new frmSCMOrderPlace();
                oForm.ShowDialog(oSCMPurchaseOrder);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only PSI status can be Placed Order", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
        private void SetListViewRowColour()
        {
            if (lvwPI.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwPI.Items)
                {
                    if (oItem.SubItems[3].Text == "PSI")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[3].Text == "OrderPlace")
                    {
                        oItem.BackColor = Color.GreenYellow;

                    }
                    else if (oItem.SubItems[3].Text == "PIReceive")
                    {
                        oItem.BackColor = Color.LightPink;

                    }
                    else if (oItem.SubItems[3].Text == "LCProcessing")
                    {
                        oItem.BackColor = Color.LightSkyBlue;

                    }
                    else if (oItem.SubItems[3].Text == "LCOpening")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[3].Text == "Shipment")
                    {
                        oItem.BackColor = Color.Magenta;

                    }
                    else if (oItem.SubItems[3].Text == "CustomerClearance")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[3].Text == "Release")
                    {
                        oItem.BackColor = Color.Cyan;

                    }
                    else if (oItem.SubItems[3].Text == "ReadyForGRD")
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
            _oSCMPurchaseOrders = new SCMPurchaseOrders();
            lvwPI.Items.Clear();

            int nCompany = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompany = -1;
            }
            else
            {
                nCompany = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }


            DBController.Instance.OpenNewConnection();
            _oSCMPurchaseOrders.RefreshPIForOrderPlace(dtFromPIdate.Value.Date, dtToPIdate.Value.Date, nCompany, txtPINo.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (SCMPurchaseOrder oSCMPurchaseOrder in _oSCMPurchaseOrders)
            {
                ListViewItem oItem = lvwPI.Items.Add(oSCMPurchaseOrder.PSINo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSCMPurchaseOrder.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSCMPurchaseOrder.CompanyName.ToString());
                oItem.SubItems.Add(oSCMPurchaseOrder.StatusName.ToString());

                oItem.Tag = oSCMPurchaseOrder;
            }
            this.Text = "Orders [" + _oSCMPurchaseOrders.Count + "]";
            SetListViewRowColour();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void frmSCMOrders_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromPIdate.Enabled = false;
                dtToPIdate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromPIdate.Enabled = true;
                dtToPIdate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (lvwPI.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a PSI to Update Status (OrderPlace).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to Update Status  ", "Confirm Ticket Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    DBController.Instance.OpenNewConnection();
                    SCMPurchaseOrder oSCMPurchaseOrder = (SCMPurchaseOrder)lvwPI.SelectedItems[0].Tag;
                    oSCMPurchaseOrder.PSIID = oSCMPurchaseOrder.PSIID;
                    oSCMPurchaseOrder.Status = (int)Dictionary.SCMStatus.OrderPlace;
                    oSCMPurchaseOrder.UpdateStatus();

                    MessageBox.Show("Successfully Update Status", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                    return;
                }
            }

        }
    }
}