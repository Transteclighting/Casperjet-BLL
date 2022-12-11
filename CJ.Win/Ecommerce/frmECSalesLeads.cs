// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 23, 2015
// Time : 11:30 AM
// Description: Sales Lead
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Win.Security;

namespace CJ.Win.Ecommerce
{
    public partial class frmECSalesLeads : Form
    {
        ECSalesLeads _oECSalesLeads;
        SalesLeads _oSalesLeads;
        bool IsCheck;
        Showrooms _oShowrooms;
        int _isHVACLead = 0;
        SalesLeads _oActivations;
        public frmECSalesLeads(int isHVACLead)
        {
            InitializeComponent();
            _isHVACLead = isHVACLead;
        }

        private void frmECSalesLeads_Load(object sender, EventArgs e)
        {
            if (_isHVACLead == 1)
            {
                btnAssign.Visible = false;
                btnLeadQC.Visible = false;
                btnEdit.Visible = false;
            }

            if (this.Tag == null)
            {
                LoadCombo();
            }
            DataLoadControl();

            DBController.Instance.OpenNewConnection();

            updateSecurity();
        }
        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesLeadStatusPOS)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SalesLeadStatusPOS), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //Lead Type
            cmbLeadType.Items.Clear();
            cmbLeadType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CustomerTypeSalesLead)))
            {
                cmbLeadType.Items.Add(Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), GetEnum));
            }
            cmbLeadType.SelectedIndex = 0;

            //Showrooms 
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Clear();
            cmbOutlet.Items.Add("<All>");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomCode);
            }
            cmbOutlet.SelectedIndex = 0;

            //Terminal
            cmbTerminal.Items.Clear();
            cmbTerminal.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Terminal)))
            {
                cmbTerminal.Items.Add(Enum.GetName(typeof(Dictionary.Terminal), GetEnum));
            }
            cmbTerminal.SelectedIndex = 0;



            //Lead Source
            cmbLeadResource.Items.Clear();
            cmbLeadResource.Items.Add("<All>");

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeadSource)))
            {
                cmbLeadResource.Items.Add(Enum.GetName(typeof(Dictionary.LeadSource), GetEnum));
            }
            cmbLeadResource.SelectedIndex = 0;

            //Get Activation 
            _oActivations = new SalesLeads();
            cmbActivation.Items.Clear();
            cmbActivation.Items.Add("<All>");
            _oActivations.GetActivation();
            foreach (SalesLead oActivation in _oActivations)
            {
                cmbActivation.Items.Add(oActivation.ActivationName);
            }
            cmbActivation.SelectedIndex = 0;


            //IsValidLead
            cmbIsValidLead.Items.Clear();
            cmbIsValidLead.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsValidLead)))
            {
                cmbIsValidLead.Items.Add(Enum.GetName(typeof(Dictionary.IsValidLead), GetEnum));
            }
            cmbIsValidLead.SelectedIndex = 0;


            //IsVerified
            cmbIsVerified.Items.Clear();
            cmbIsVerified.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsVerified)))
            {
                cmbIsVerified.Items.Add(Enum.GetName(typeof(Dictionary.IsVerified), GetEnum));
            }
            cmbIsVerified.SelectedIndex = 0;

            //Lead Status
            cmbLeadStatus.Items.Clear();
            cmbLeadStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeadStatus)))
            {
                cmbLeadStatus.Items.Add(Enum.GetName(typeof(Dictionary.LeadStatus), GetEnum));
            }
            cmbLeadStatus.SelectedIndex = 0;

        }


        private void updateSecurity()
        {
            btnAdd.Enabled = false;
            btnAssign.Enabled = false;
            btnEdit.Enabled = false;
            btnLeadQC.Enabled = false;

            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");

            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {

                    if ("M7.14.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M7.14.2" == sPermissionKey)
                    {
                        btnAssign.Enabled = true;
                    }
                    if ("M7.14.3" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M7.14.4" == sPermissionKey)
                    {
                        btnLeadQC.Enabled = true;
                    }
                }
            }

        }

        private void setListViewRowColour()
        {
            //Product_Not_Available = 8,


            if (lvwLeadList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwLeadList.Items)
                {
                    if (oItem.SubItems[11].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[11].Text == "Sales_Executed")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[11].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;

                    }
                    else if (oItem.SubItems[11].Text == "In_Progress")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[11].Text == "No_Answer")
                    {
                        oItem.BackColor = Color.Orange;

                    }
                    else if (oItem.SubItems[11].Text == "Follow_Up")
                    {
                        oItem.BackColor = Color.LightBlue;

                    }
                    else if (oItem.SubItems[11].Text == "Product_Not_Available")
                    {
                        oItem.BackColor = Color.LightCoral;

                    }
                    else
                    {
                        oItem.BackColor = Color.Gray;
                    }

                }
            }
        }


        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oSalesLeads = new SalesLeads();
            lvwLeadList.Items.Clear();
            _oActivations = new SalesLeads();

            int nCustomerType = 0;
            if (cmbLeadType.SelectedIndex == 0)
            {
                nCustomerType = -1;
            }
            else
            {
                nCustomerType = cmbLeadType.SelectedIndex;
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

            int nWHID = 0;
            if (cmbOutlet.SelectedIndex == 0)
            {
                nWHID = -1;
            }
            else
            {
                nWHID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
            }

            int nTerminal = 0;
            if (cmbTerminal.SelectedIndex == 0)
            {
                nTerminal = -1;
            }
            else
            {
                nTerminal = cmbTerminal.SelectedIndex;
            }


            int nIsValidLead = 0;
            if (cmbIsValidLead.SelectedIndex == 0)
            {
                nIsValidLead = -1;
            }
            else
            {
                nIsValidLead = cmbIsValidLead.SelectedIndex - 1;
            }

            int nLeadStatus = 0;
            if (cmbLeadStatus.SelectedIndex == 0)
            {
                nLeadStatus = -1;
            }
            else
            {
                nLeadStatus = cmbLeadStatus.SelectedIndex;
            }


            int nLeadSource = 0;
            if (cmbLeadResource.SelectedIndex == 0)
            {
                nLeadSource = -1;
            }
            else
            {
                nLeadSource = cmbLeadResource.SelectedIndex -1;
            }


            int nActivation = 0;
            if (cmbActivation.SelectedIndex == 0)
            {
                nActivation = -1;
            }
            else
            {
                nActivation = cmbActivation.SelectedIndex;
            }


            //if (cmbLeadSource.SelectedIndex != 0)
            //{
            //    _oSalesLead.LeadSource = cmbLeadSource.SelectedIndex;
            //    _oSalesLead.ActivationID = _oActivations[cmbActivation.SelectedIndex - 1].ActivationID;
            //}
            //else
            //{
            //    _oSalesLead.LeadSource = cmbLeadSource.SelectedIndex;
            //    _oSalesLead.ActivationID = -1;
            //}


            int nIsVerified = 0;
            if (cmbIsVerified.SelectedIndex == 0)
            {
                nIsVerified = -1;
            }
            else
            {
                nIsVerified = cmbIsVerified.SelectedIndex - 1;
            }

            DBController.Instance.OpenNewConnection();
            _oSalesLeads.RefreshForHO(dtFromDate.Value.Date, dtToDate.Value.Date, nCustomerType, nStatus,
                txtCompany.Text.Trim(), txtName.Text.Trim(), txtContactNo.Text.Trim(), txtLeadNo.Text.Trim(), IsCheck,
                nWHID, nTerminal, nLeadSource, nActivation, nIsValidLead, nIsVerified,_isHVACLead, nLeadStatus);
            DBController.Instance.CloseConnection();

            foreach (SalesLead oSalesLead in _oSalesLeads)
            {
                ListViewItem oItem = lvwLeadList.Items.Add(oSalesLead.LeadNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSalesLead.LeadDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), oSalesLead.CustomerType));
                oItem.SubItems.Add(oSalesLead.CompanyName.ToString());
                oItem.SubItems.Add(oSalesLead.Name.ToString());
                oItem.SubItems.Add(oSalesLead.ContactNo.ToString());
                oItem.SubItems.Add(oSalesLead.Address.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oSalesLead.LeadAmount).ToString());
                oItem.SubItems.Add(oSalesLead.ShowroomCode.ToString());
                oItem.SubItems.Add(oSalesLead.SalesPerson.ToString());
                oItem.SubItems.Add(oSalesLead.InvoiceNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesLeadStatusPOS), oSalesLead.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.Terminal), oSalesLead.Terminal));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsValidLead), oSalesLead.IsValidLead));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsVerified), oSalesLead.IsVerified));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LeadStatus), oSalesLead.LeadStatus));
                oItem.SubItems.Add(oSalesLead.ActivationName.ToString());
                oItem.SubItems.Add(oSalesLead.Remarks.ToString());

                oItem.Tag = oSalesLead;
            }
            setListViewRowColour();
            this.Text = "Sales Leads [" + _oSalesLeads.Count + "]";
            this.Cursor = Cursors.Default;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmECSalesLead oform = new frmECSalesLead(1, _isHVACLead);
            oform.ShowDialog();
            if (oform._IsTrue == true)
            {
                DataLoadControl();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwLeadList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesLead oSalesLead = (SalesLead)lvwLeadList.SelectedItems[0].Tag;
            if (oSalesLead.Status != (int)Dictionary.SalesLeadStatusPOS.Sales_Executed)
            {
                frmECSalesLead oform = new frmECSalesLead(1, _isHVACLead);
                oform.ShowDialog(oSalesLead);
                if (oform._IsTrue == true)
                {
                    DataLoadControl();
                }
            }
            else
            {
                MessageBox.Show("Lead already executed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lvwLeadList_DoubleClick(object sender, EventArgs e)
        {
            //if (lvwLeadList.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //ECSalesLead oECSalesLead = (ECSalesLead)lvwLeadList.SelectedItems[0].Tag;
            //frmECSalesLead oform = new frmECSalesLead();
            //oform.ShowDialog(oECSalesLead);
            //DataLoadControl();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lvwLeadList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesLead oSalesLead = (SalesLead)lvwLeadList.SelectedItems[0].Tag;
            if (oSalesLead.WarehouseID == -1)
            {
                frmSalesLeadAssign oform = new frmSalesLeadAssign();
                oform.ShowDialog(oSalesLead);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Lead already assigned.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            //if (lvwLeadList.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //ECSalesLead oECSalesLead = (ECSalesLead)lvwLeadList.SelectedItems[0].Tag;

            //frmECSalesLeadAssign oform = new frmECSalesLeadAssign(2);
            //oform.ShowDialog(oECSalesLead);
            //RefreshData();
        }

        private void btnFromXL_Click(object sender, EventArgs e)
        {
            //frmECUploadFromXL oform = new frmECUploadFromXL();
            //oform.ShowDialog();
            //RefreshData();
        }

        private void btnHappyCall_Click(object sender, EventArgs e)
        {
            //if (lvwLeadList.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //ECSalesLead oECSalesLead = (ECSalesLead)lvwLeadList.SelectedItems[0].Tag;

            //frmECSalesLeadHappyCall oform = new frmECSalesLeadHappyCall();
            //oform.ShowDialog(oECSalesLead);
            //RefreshData();
        }

        private void btnLeadQC_Click(object sender, EventArgs e)
        {
             
            if (lvwLeadList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            SalesLead oSalesLead = (SalesLead)lvwLeadList.SelectedItems[0].Tag;

          
            if ((oSalesLead.Status != (int)Dictionary.SalesLeadStatusPOS.Sales_Executed && oSalesLead.IsVerified != (int)Dictionary.IsVerified.Verified) || (oSalesLead.Status != (int)Dictionary.SalesLeadStatusPOS.Sales_Executed && oSalesLead.LeadStatus == (int)Dictionary.LeadStatus.Not_Reached))
            {

                frmSalesLeadMgtQuestions ofrmSalesLeadMgtQuestions = new frmSalesLeadMgtQuestions();
                ofrmSalesLeadMgtQuestions.ShowDialog(oSalesLead);
                if (ofrmSalesLeadMgtQuestions._IsTrue == true)
                {
                    DataLoadControl();
                }
            }
            else
            {
                MessageBox.Show("Lead already verified or executed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}