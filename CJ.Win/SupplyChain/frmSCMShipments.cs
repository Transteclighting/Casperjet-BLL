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
    public partial class frmSCMShipments : Form
    {

        SCMPIs _oSCMPIs;

        Companys _oCompanys;
        bool IsCheck = false;

       
        public frmSCMShipments()
        {
            InitializeComponent();
        }

        private void frmSCMShipments_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
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

        }

        private void SetListViewRowColour()
        {
            if (lvwShipment.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwShipment.Items)
                {
                    if (oItem.SubItems[7].Text == "PSI")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[7].Text == "OrderPlace")
                    {
                        oItem.BackColor = Color.GreenYellow;

                    }
                    else if (oItem.SubItems[7].Text == "PIReceive")
                    {
                        oItem.BackColor = Color.LightPink;

                    }
                    else if (oItem.SubItems[7].Text == "LCProcessing")
                    {
                        oItem.BackColor = Color.LightSkyBlue;

                    }
                    else if (oItem.SubItems[7].Text == "LCOpening")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[7].Text == "Shipment")
                    {
                        oItem.BackColor = Color.Magenta;

                    }
                    else if (oItem.SubItems[7].Text == "CustomerClearance")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[7].Text == "Release")
                    {
                        oItem.BackColor = Color.Cyan;

                    }
                    else if (oItem.SubItems[7].Text == "ReadyForGRD")
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
            _oSCMPIs = new SCMPIs();
            lvwShipment.Items.Clear();

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
            _oSCMPIs.GetShipmentableLC(dtFromdate.Value.Date, dtTodate.Value.Date, txtPINo.Text.Trim(), txtOrderNo.Text.Trim(), txtLCNo.Text.Trim(), txtPSINo.Text.Trim(), nCompany, IsCheck);
            DBController.Instance.CloseConnection();

            foreach (SCMPI oSCMPI in _oSCMPIs)
            {
                ListViewItem oItem = lvwShipment.Items.Add(oSCMPI.LCNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSCMPI.LCDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSCMPI.OrderNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSCMPI.OrderPlaceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSCMPI.PINO.ToString());
                oItem.SubItems.Add(oSCMPI.PSINo.ToString());
                oItem.SubItems.Add(oSCMPI.CompanyName.ToString());
                oItem.SubItems.Add(oSCMPI.StatusName.ToString());

                oItem.Tag = oSCMPI;
            }
            this.Text = "LC [" + _oSCMPIs.Count + "]";

            SetListViewRowColour();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a LC to Shipment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPI oSCMPI = (SCMPI)lvwShipment.SelectedItems[0].Tag;
            if (oSCMPI.Status == (int)Dictionary.SCMStatus.LCOpening)
            {
                frmShipment oForm = new frmShipment();
                oForm.ShowDialog(oSCMPI);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only PIReceive status can be LC Process", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (lvwShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a PI to Update Status (Shipment).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to Update Status  ", "Confirm Ticket Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    DBController.Instance.OpenNewConnection();
                    SCMPI oSCMPI = (SCMPI)lvwShipment.SelectedItems[0].Tag;
                    oSCMPI.PIID = oSCMPI.PIID;
                    oSCMPI.Status = (int)Dictionary.SCMStatus.Shipment;
                    oSCMPI.UpdateStatusShipment();
                    //oSCMOrder.RefreshPendingOrderStatus(oSCMOrder.PSIID);
                    //if (oSCMOrder.PendingStatus == 0)
                    //{
                    //    oSCMOrder.UpdateStatusPSI(oSCMOrder.PSIID);

                    //}
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Update Status", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                    return;

                }
            }


        }

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void lblPINO_Click(object sender, EventArgs e)
        //{

        //}

        //private void txtPINo_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtOrderNo_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtPSINo_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void lblOrderNo_Click(object sender, EventArgs e)
        //{

        //}

        //private void lblLCNo_Click(object sender, EventArgs e)
        //{

        //}

        //private void txtLCNo_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}