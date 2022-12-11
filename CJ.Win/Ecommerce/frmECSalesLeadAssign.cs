using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;

namespace CJ.Win.Ecommerce
{
    public partial class frmECSalesLeadAssign : Form
    {
        Showrooms _oShowrooms;
        int _nUIControl = 0;
        int nSalesLeadID = 0;
        string sMessage = "";
        string sCustomer = "";
        string sModel = "";
        string sMobile = "";
        public frmECSalesLeadAssign(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }
        }
        private bool UIValidation()
        {
            if (_nUIControl == 1)
            {
                if (rdoTD.Checked == true)
                {
                    if (cmbOutlet.Text == "<Select>")
                    {
                        MessageBox.Show("Please Select Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbOutlet.Focus();
                        return false;
                    }
                }

            }
            else
            {
                if (cmbStatus.Text == "<Select>")
                {
                    MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return false;
                }
                if (cmbStatus.Text == "Create")
                {
                    MessageBox.Show("Please Select Other Status Instead of This", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return false;
                }
                if (cmbStatus.Text == "Assign")
                {
                    MessageBox.Show("Please Select Other Status Instead of This", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return false;
                }
                if (cmbStatus.Text == "SalesExecuted")
                {
                    if (txtInvoiceNo.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Input Invoice No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtInvoiceNo.Focus();
                        return false;
                    }

                }
            }
            return true;
        }
        private void Save()
        {
            ECSalesLead oECSalesLead = new ECSalesLead();
            if (_nUIControl == 1)
            {
                oECSalesLead.Status = (int)Dictionary.SalesLeadStatus.Assign;
            }
            else
            {
                oECSalesLead.Status = cmbStatus.SelectedIndex - 1;
            }
            oECSalesLead.AssignOutlet = cmbOutlet.Text;
            oECSalesLead.InvoiceNo = txtInvoiceNo.Text;
            oECSalesLead.StatusRemarks = txtRemarks.Text;
            oECSalesLead.SalesLeadID = nSalesLeadID;
            try
            {
                DBController.Instance.BeginNewTransaction();
                if (_nUIControl == 1)
                {
                    SMSMessage oSMSMessage = new SMSMessage();
                    oECSalesLead.Assign();
                    sMessage = "Assign";
                    string sSendMobileNo = "";
                    string[] sProjMob = { "01713041247", "01714089022" };
                    string[] sCorpMob = { "01714089309", "01714089305" };

                    string sSMS = "ID:" + nSalesLeadID + ",Mob:" + sMobile + ",Cust:" + sCustomer + ",Prod:" + sModel + "; Send status to homecare@transcombd.com";
                    if (rdoTD.Checked == true)
                    {
                        Showroom oShowroom = new Showroom();
                        oShowroom.ShowroomID = _oShowrooms[cmbOutlet.SelectedIndex - 1].ShowroomID;
                        oShowroom.Refresh();
                        sSendMobileNo = oShowroom.MobileNo;

                        oSMSMessage = new SMSMessage();
                        oSMSMessage = GenerateMessage(oSMSMessage, sSMS, sSendMobileNo);
                        oSMSMessage.Add();
                    }
                    else if (rdoCorp.Checked == true)
                    {
                        for (int i = 0; i < sCorpMob.Length; i++)
                        {
                            sSendMobileNo = sCorpMob[i];
                            oSMSMessage = new SMSMessage();
                            oSMSMessage = GenerateMessage(oSMSMessage, sSMS, sSendMobileNo);
                            oSMSMessage.Add();
                        }
                    }
                    else if (rdoProject.Checked == true)
                    {
                        for (int i = 0; i < sProjMob.Length; i++)
                        {
                            sSendMobileNo = sProjMob[i];
                            oSMSMessage = new SMSMessage();
                            oSMSMessage = GenerateMessage(oSMSMessage, sSMS, sSendMobileNo);
                            oSMSMessage.Add();
                        }
                    }

                    oECSalesLead.AssignSMSID = oSMSMessage.SMSMessageID;
                    oECSalesLead.UpdateAssignSMSID();
                }
                else
                {
                    oECSalesLead.StatusUpdate();
                    sMessage = "Update";
                }

                DBController.Instance.CommitTransaction();
                MessageBox.Show("" + sMessage + " Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private SMSMessage GenerateMessage(SMSMessage oSMSMessage, string sSMSText, string sMobileNo)
        {
            oSMSMessage.RequestDate = DateTime.Now;
            oSMSMessage.SMSText = sSMSText;
            oSMSMessage.SMSType = 1;
            oSMSMessage.SingleMobileNo = sMobileNo;
            oSMSMessage.SendDate = DateTime.Now;
            oSMSMessage.Status = 1;
            oSMSMessage.SubmittedBy = Utility.Username;
            oSMSMessage.UserGroupName = "SalesLeadSMS";
            oSMSMessage.SuccessCount = 0;
            oSMSMessage.FailCount = 0;

            return oSMSMessage;
        }
        private void frmECSalesLeadAssign_Load(object sender, EventArgs e)
        {
            if (_nUIControl == 1)
            {
                this.Text = "Assign";
                btnStatusUpdate.Visible = false;
                cmbStatus.Visible = false;
                lblStat.Text = "Outlet";
                lblInvoiceNo.Visible = false;
                txtInvoiceNo.Visible = false;
                groupBox1.Visible = true;
                rdoTD.Checked = true;
            }
            else
            {
                this.Text = "Status Update";
                btnAssign.Visible = false;
                cmbOutlet.Visible = false;
                lblStat.Text = "Status";
                groupBox1.Visible = false;
            }
            LoadCombo();
        }
        public void ShowDialog(ECSalesLead oECSalesLead)
        {
            this.Tag = oECSalesLead;
            nSalesLeadID = oECSalesLead.SalesLeadID;
            sCustomer = oECSalesLead.Name;
            sModel = oECSalesLead.ProductModel;
            sMobile = oECSalesLead.ContactNo;
            lblLeasID.Text = "Lead ID: " + oECSalesLead.SalesLeadID.ToString();
            lblName.Text = "Name: " + oECSalesLead.Name;
            this.ShowDialog();
        }
        private void LoadCombo()
        {
            if (_nUIControl == 1)
            {
                _oShowrooms = new Showrooms();
                _oShowrooms.Refresh();
                cmbOutlet.Items.Clear();
                cmbOutlet.Items.Add("<Select>");
                foreach (Showroom oShowroom in _oShowrooms)
                {
                    cmbOutlet.Items.Add(oShowroom.ShowroomCode + "-" + oShowroom.ShowroomName);
                }
                if (_oShowrooms.Count > 0)
                    cmbOutlet.SelectedIndex = 0;
            }
            else
            {
                cmbStatus.Items.Add("<Select>");
                foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesLeadStatus)))
                {
                    cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SalesLeadStatus), GetEnum));
                }
                cmbStatus.SelectedIndex = 0;
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }
        }

        private void rdoTD_CheckedChanged(object sender, EventArgs e)
        {
            cmbOutlet.Enabled = true;
        }

        private void rdoCorp_CheckedChanged(object sender, EventArgs e)
        {
            cmbOutlet.Enabled = false;
        }

        private void rdoProject_CheckedChanged(object sender, EventArgs e)
        {
            cmbOutlet.Enabled = false;
        }
    }
}