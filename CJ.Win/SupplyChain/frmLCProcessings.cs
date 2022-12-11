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
    public partial class frmLCProcessings : Form
    {
        SCMOrder _oSCMOrder;
        SCMOrders _oSCMOrders;

        SCMLCItem _oSCMLCItem;
        int nPSIID = 0;
        string sPSINo = "";
        int nStatus = 0;
        string sCompanyName = "";
        int nExGRDWeek = 0;
        int nExGRDYear = 0;
        string sSupplierName = "";
        int nOrderID = 0;
        string sPINo = "";


        public frmLCProcessings()
        {
            InitializeComponent();
        }
        public void ShowDialog(SCMOrder oSCMOrder)
        {

            nPSIID = 0;
            nPSIID = oSCMOrder.PSIID;
            sPINo = "";
            sPSINo = oSCMOrder.PSINo;
            nExGRDWeek = 0;
            nExGRDWeek = oSCMOrder.ExpectedGRDWeek;
            nExGRDYear = 0;
            nExGRDYear = oSCMOrder.ExpectedGRDYear;
            sCompanyName = "";
            sCompanyName = oSCMOrder.CompanyName;
            sSupplierName = "";
            sSupplierName = oSCMOrder.SupplierName;
            sPINo = "";
            sPINo = oSCMOrder.PINo;
            object dtPIDate = oSCMOrder.PIReceiveDate;

            lblPOID.Text = Convert.ToString(nPSIID);
            lblPONo.Text = sPINo;
            lblExpGRDWeek.Text = (Convert.ToString(nExGRDWeek) + "-" + Convert.ToString(nExGRDYear));
            lblCompanyName.Text = sCompanyName;
            lblSupplierName.Text = sSupplierName;
            //lblPINO.Text = nPINo;
            //lblPIReceiveDate.Text = Convert.ToDateTime(dtPIDate).ToString("dd-MMM-yyyy");

            this.Text = "LC Processings";
            if (oSCMOrder.Status == (int)Dictionary.SCMStatus.PIReceive)
            {
                btnNonLC.Enabled = true;

            }
            else
            {
                btnNonLC.Enabled = false;

            }
            this.Tag = oSCMOrder;

            this.ShowDialog();
        }

        private void DataLoadControl()
        {
            _oSCMOrders = new SCMOrders();
            _oSCMOrder = new SCMOrder();
            lvwLCProcess.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oSCMOrder.PSIID = nPSIID;
            //_oSCMLCs.RefreshLC(_oSCMLC.PSIID);
            DBController.Instance.CloseConnection();

            //foreach (SCMOrder oSCMOrder in _oSCMLCItem)
            //{
            //    ListViewItem oItem = lvwLCProcess.Items.Add(oSCMOrder.PSINo.ToString());
            //    oItem.SubItems.Add(Convert.ToDateTime(oSCMOrder.PIReceiveDate).ToString("dd-MMM-yyyy"));
            //    oItem.SubItems.Add(Convert.ToDateTime(oSCMOrder.OrderPlaceDate).ToString("dd-MMM-yyyy"));
            //    oItem.SubItems.Add(oSCMOrder.StatusName.ToString());
            //    oItem.SubItems.Add(oSCMOrder.OrderID.ToString());
            //    oItem.SubItems.Add(oSCMOrder.LCNo.ToString());

            //    oItem.Tag = oSCMOrder;
            //}
            SetListViewRowColour();
        }
        private void SetListViewRowColour()
        {
            if (lvwLCProcess.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwLCProcess.Items)
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
                        oItem.BackColor = Color.Pink;

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
        private void btnLCProcessing_Click(object sender, EventArgs e)
        {
            //SCMPurchaseOrder oSCMPurchaseOrder = new SCMPurchaseOrder();

            //oSCMPurchaseOrder.PSIID = nPSIID;
            //DBController.Instance.OpenNewConnection();
            //oSCMPurchaseOrder.RefreshByPSIID(oSCMPurchaseOrder.PSIID);
            //oSCMPurchaseOrder.RefreshLCProcessingItemByPSIID(oSCMPurchaseOrder.PSIID);
            //frmLCProcessingDate oForm = new frmLCProcessingDate();
            //oForm.ShowDialog(oSCMPurchaseOrder);
            //DataLoadControl();


        }

        private void btnShipment_Click(object sender, EventArgs e)
        {

        }

        private void btnLCOpen_Click(object sender, EventArgs e)
        {
            //if (lvwLCProcess.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a Data to LC Open.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;

            //}
            //SCMOrder oSCMOrder = (SCMOrder)lvwLCProcess.SelectedItems[0].Tag;
            //if (oSCMOrder.Status == (int)Dictionary.SCMStatus.LCProcessing)
            //{
            //    frmSCMLCOpen oForm = new frmSCMLCOpen();
            //    oForm.ShowDialog(oSCMOrder);
            //    DataLoadControl();

            //}
            //else
            //{
            //    MessageBox.Show("Only LCProcessing status can be LC Open", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

        }

        private void frmLCProcessings_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnNonLC_Click(object sender, EventArgs e)
        {

            //SCMPurchaseOrder oSCMPurchaseOrder = new SCMPurchaseOrder();

            //oSCMPurchaseOrder.PSIID = nPSIID;
            //DBController.Instance.OpenNewConnection();
            //oSCMPurchaseOrder.RefreshByPSIID(oSCMPurchaseOrder.PSIID);
            ////oSCMPurchaseOrder.RefreshLCProcessingItemByPOID(oSCMPurchaseOrder.POID);
            //frmNonLC oForm = new frmNonLC();
            //oForm.ShowDialog(oSCMPurchaseOrder);
            //DataLoadControl();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}