using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.BasicData;
using CJ.Control;

namespace CJ.Win.Accounts
{
    public partial class frmCustomerCreditApproval : Form
    {
        Showrooms _oShowrooms;
        CustomerCreditApproval _oCustomerCreditApproval;
        CustomerCreditApprovals _oCustomerCreditApprovals;
        Channel _oChannel;
        TELLib _oTELLib;
        int nID = 0;
        RetailConsumer oRetailConsumer;
        string sCustomerCode = "";
        int nConsumerID = 0;
        public frmCustomerCreditApproval()
        {
            InitializeComponent();
        }

        public void ShowDialog(CustomerCreditApproval oCustomerCreditApproval)
        {
            nID = oCustomerCreditApproval.ID;
            _oTELLib = new TELLib();
            this.Tag = oCustomerCreditApproval;
            LoadCombo();
            lblCAN.Text = "Credit Approval # " + oCustomerCreditApproval.ApprovalNo;
            txtAmount.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.CreditAmount).ToString();
            ctlCustomer1.txtCode.Text = oCustomerCreditApproval.CustomerCode;
            txtCreditPeriod.Text = oCustomerCreditApproval.CreditPeriod.ToString();
            txtProductOrService.Text = oCustomerCreditApproval.ProductOrService;
            txtRemarks.Text = oCustomerCreditApproval.Remarks;
            int nOutletIndex = 0;
            nOutletIndex = _oShowrooms.GetIndexWHID(oCustomerCreditApproval.WarehouseID);
            cboOutlet.SelectedIndex = nOutletIndex + 1;
            cboOutlet.Enabled = false;
            cmbSalesType.SelectedIndex = oCustomerCreditApproval.SalesType - 1;
            txtConsumerCode.Text = oCustomerCreditApproval.ConsumerCode;
            this.ShowDialog();

        }


        private void frmCustomerCreditApproval_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Amount";
                lblCAN.Visible = false;
                //rdoB2B.Visible = true;
                //rdoTDDealer.Visible = true;
                LoadCombo();
            }
            else
            {
                this.Text = "Edit Amount";
                lblCAN.Visible = true;
                //rdoB2B.Visible = false;
                //rdoTDDealer.Visible = false;
            }



        }

        private void LoadCombo()
        {

            _oShowrooms = new Showrooms();
            _oShowrooms.RefreshHO();
            cboOutlet.Items.Clear();
            cboOutlet.Items.Add("-- Select --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cboOutlet.Items.Add(oShowroom.ShowroomCode + " - " + oShowroom.ShowroomName);
            }
            cboOutlet.SelectedIndex = 0;

            cmbSalesType.Items.Clear();
            //cmbSalesType.Items.Add("-- Select --");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = 0;
        }

        private bool UIValidation()
        {
            if (cboOutlet.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboOutlet.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            //if (txtApprovalNo.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Enter ApprovalNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }

        }
        private void Save()
        {
            _oCustomerCreditApproval = new CustomerCreditApproval();

            _oCustomerCreditApproval.WarehouseID = _oShowrooms[cboOutlet.SelectedIndex - 1].WarehouseID;
            _oCustomerCreditApproval.WarehouseCode = _oShowrooms[cboOutlet.SelectedIndex - 1].ShowroomCode;
            _oCustomerCreditApproval.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oCustomerCreditApproval.ProductOrService = txtProductOrService.Text.Trim();
            _oCustomerCreditApproval.CreditPeriod = Convert.ToInt32(txtCreditPeriod.Text);
            _oCustomerCreditApproval.CreditAmount = Convert.ToDouble(txtAmount.Text.Trim());
            _oCustomerCreditApproval.Remarks = txtRemarks.Text.Trim();
            _oCustomerCreditApproval.CreateUserID = Utility.UserId;
            _oCustomerCreditApproval.CreateDate = DateTime.Now;
            _oCustomerCreditApproval.UpdateUserID = Utility.UserId;
            _oCustomerCreditApproval.UpdateDate = DateTime.Now;
            _oCustomerCreditApproval.Status = (int)Dictionary.CreditApprovalStatus.Create;
            _oCustomerCreditApproval.ConsumerID = nConsumerID;
            _oCustomerCreditApproval.SalesType = cmbSalesType.SelectedIndex + 1;

            if (this.Tag == null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerCreditApproval.AddNew();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Data Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerCreditApproval.ID = nID;
                    _oCustomerCreditApproval.EditNew();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Data Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtConsumerCode_TextChanged(object sender, EventArgs e)
        {
            oRetailConsumer = new RetailConsumer();
            txtConsumerCode.ForeColor = System.Drawing.Color.Red;
            txtConsumerName.Text = "";
            if (txtConsumerCode.Text.Length >= 1 && txtConsumerCode.Text.Length <= 25)
            {
                oRetailConsumer.ConsumerCode = txtConsumerCode.Text;
                oRetailConsumer.RefreshConsumerByType(cmbSalesType.SelectedIndex + 1);
                if (oRetailConsumer.ConsumerName == null)
                {
                    oRetailConsumer = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    txtConsumerName.Text = oRetailConsumer.ConsumerName.ToString();
                    sCustomerCode = oRetailConsumer.CustomerCode;
                    nConsumerID = oRetailConsumer.ConsumerID;
                    txtConsumerCode.SelectionStart = 0;
                    txtConsumerCode.SelectionLength = txtConsumerCode.Text.Length;
                    txtConsumerCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
        }
        private void btnPicker_Click(object sender, EventArgs e)
        {

            if (cboOutlet.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboOutlet.Focus();
                return;
            }
            oRetailConsumer = new RetailConsumer();
            frmReatilConsumerSearch oObj = new frmReatilConsumerSearch(cmbSalesType.SelectedIndex + 1, (int)Dictionary.Terminal.Head_Office, _oShowrooms[cboOutlet.SelectedIndex - 1].WarehouseID);
            oObj.ShowDialog(oRetailConsumer);
            if (oRetailConsumer.ConsumerCode != null)
            {
                txtConsumerCode.Text = oRetailConsumer.ConsumerCode.ToString();
                sCustomerCode = oRetailConsumer.CustomerCode;
                ctlCustomer1.txtCode.Text = sCustomerCode;
            }
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
            {
                ctlCustomer1.Enabled = true;
                txtConsumerCode.Enabled = false;
                btnPicker.Enabled = false;
                txtConsumerName.Enabled = false;
                ctlCustomer1.txtCode.Text = "";
                txtConsumerCode.Text = "";
            }
            else if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
            {
                ctlCustomer1.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtConsumerName.Enabled = true;
                txtConsumerCode.Text = "";
                ctlCustomer1.txtCode.Text = "";
            }
            else
            {
                ctlCustomer1.Enabled = false;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtConsumerName.Enabled = true;
                txtConsumerCode.Text = "";
                ctlCustomer1.txtCode.Text = "";
                if (cboOutlet.SelectedIndex != 0)
                {
                    sCustomerCode = _oShowrooms[cboOutlet.SelectedIndex - 1].CustomerCode;
                    ctlCustomer1.txtCode.Text = sCustomerCode;
                }
                else
                {
                    txtConsumerCode.Text = "";
                    ctlCustomer1.txtCode.Text = "";
                }
            }
        }

        private void cboOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOutlet.SelectedIndex != 0)
            {
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
                {
                    ctlCustomer1.Enabled = true;
                    txtConsumerCode.Enabled = false;
                    btnPicker.Enabled = false;
                    txtConsumerName.Enabled = false;
                    ctlCustomer1.txtCode.Text = "";
                    txtConsumerCode.Text = "";
                }
                else if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
                {
                    ctlCustomer1.Enabled = true;
                    txtConsumerCode.Enabled = true;
                    btnPicker.Enabled = true;
                    txtConsumerName.Enabled = true;
                    txtConsumerCode.Text = "";
                    ctlCustomer1.txtCode.Text = "";
                }
                else
                {
                    ctlCustomer1.Enabled = false;
                    txtConsumerCode.Enabled = true;
                    btnPicker.Enabled = true;
                    txtConsumerName.Enabled = true;
                    txtConsumerCode.Text = "";
                    ctlCustomer1.txtCode.Text = "";
                    if (cboOutlet.SelectedIndex != 0)
                    {
                        sCustomerCode = _oShowrooms[cboOutlet.SelectedIndex - 1].CustomerCode;
                        ctlCustomer1.txtCode.Text = sCustomerCode;
                    }
                    else
                    {
                        txtConsumerCode.Text = "";
                        ctlCustomer1.txtCode.Text = "";
                    }
                }
            }
        }
    }
}

