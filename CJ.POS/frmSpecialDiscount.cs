﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Accounts;
using CJ.Class.POS;
using CJ.Control;

namespace CJ.POS
{
    public partial class frmSpecialDiscount : Form
    {
        RetailConsumer oRetailConsumer;
        ConsumerPromotionEngine oSpecialDiscount;
        ConsumerPromotionEngines oApplyTo;
        string sCustomerCode = "";
        EMITenures _oEMITenures;


        SystemInfo oSystemInfo;
        int nConsumerID = 0;
        public frmSpecialDiscount()
        {
            InitializeComponent();
        }
        public bool ValidateUIInput()
        {

            #region Validation
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
            {
                if (ctlCustomer1.txtDescription.Text == "")
                {
                    MessageBox.Show("Plese select customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCustomer1.txtCode.Focus();
                    return false;
                }
            }
            else
            {
                if (ctlCustomer1.txtDescription.Text == "")
                {
                    MessageBox.Show("Plese select customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCustomer1.txtCode.Focus();
                    return false;
                }
                if (txtConsumerName.Text == "")
                {
                    MessageBox.Show("Plese select customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConsumerName.Focus();
                    return false;
                }
            }


            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Plese select a product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }

            if (txtReason.Text == "")
            {
                MessageBox.Show("Plese input discount reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return false;
            }

            if (cmbType.SelectedIndex == 1)
            {
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("Plese input valid amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return false;
                }

                if (Convert.ToDouble(txtAmount.Text) <= 0)
                {
                    MessageBox.Show("Amount must be greater than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return false;
                }
            }
            else if (cmbType.SelectedIndex == 2)
            {
                if (cmbEMITenure.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select emi tenure", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEMITenure.Focus();
                    return false;
                }
            }
            #endregion
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //oSystemInfo = new SystemInfo();
            //oSystemInfo.Refresh();
            //sCustomerCode = oSystemInfo.CustomerCode;
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = 0;

            oApplyTo = new ConsumerPromotionEngines();
            cmbApplyTo.Items.Clear();
            oApplyTo.GetSpecialDiscountAuthority();
            cmbApplyTo.Items.Add("<Select>");
            foreach (ConsumerPromotionEngine oApply in oApplyTo)
            {
                cmbApplyTo.Items.Add(oApply.EmployeeName);
            }
            cmbApplyTo.SelectedIndex = 0;

            _oEMITenures = new EMITenures();
            _oEMITenures.GetEMITenure();
            cmbEMITenure.Items.Add("<Select>");
            foreach (EMITenure oEMITenure in _oEMITenures)
            {
                cmbEMITenure.Items.Add(oEMITenure.Tenure);
            }
            cmbEMITenure.SelectedIndex = 0;

            cmbType.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                oSpecialDiscount = new ConsumerPromotionEngine();

                oSpecialDiscount.ChannelID = cmbSalesType.SelectedIndex + 1;
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
                {
                    oSpecialDiscount.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    oSpecialDiscount.Type = (int)Dictionary.SpacialDiscountCustType.Customer;
                }
                else
                {
                    oSpecialDiscount.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    oSpecialDiscount.Type = (int)Dictionary.SpacialDiscountCustType.Consumer;
                }
                oSpecialDiscount.ConsumerID = nConsumerID;
                oSpecialDiscount.WarehouseID = oSystemInfo.WarehouseID;
                oSpecialDiscount.Amount = Convert.ToDouble(txtAmount.Text);
                oSpecialDiscount.IsApplicableB2BDiscount = (int)Dictionary.YesOrNoStatus.NO;
                oSpecialDiscount.Status = (int)Dictionary.SpacialDiscountStatus.Create;
                oSpecialDiscount.CreateDate = DateTime.Now.Date;
                oSpecialDiscount.CreateUserID = Utility.UserId;
                oSpecialDiscount.Reason = txtReason.Text;
                oSpecialDiscount.AuthorityID = oApplyTo[cmbApplyTo.SelectedIndex - 1].AuthorityID;

                oSpecialDiscount.DiscountType = cmbType.Text;
                if (cmbType.SelectedIndex == 1)
                {
                    oSpecialDiscount.EMITenureID = -1;
                }
                else
                {
                    oSpecialDiscount.EMITenureID = _oEMITenures[cmbEMITenure.SelectedIndex - 1].EMITenureID;
                }
                oSpecialDiscount.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                oSpecialDiscount.Terminal = (int)Dictionary.Terminal.Branch_Office;

                try
                {
                    oSpecialDiscount.AddSpacialDiscount(oSystemInfo.Shortcode);
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_PromoDiscountSpecial";
                    oDataTran.DataID = Convert.ToInt32(oSpecialDiscount.SpecialDiscountID);
                    oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;

                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }
                    MessageBox.Show("Successfully Apply for spacial discount. Discount#" + oSpecialDiscount.ApprovalNumber + "", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void frmSpecialDiscount_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            sCustomerCode = oSystemInfo.CustomerCode;
            if (this.Tag == null)
            {
                LoadCombo();
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
                lblAddNewConsumer.Enabled = false;
                ctlCustomer1.txtCode.Text = "";
                txtConsumerCode.Text = "";
            }
            else if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
            {
                ctlCustomer1.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtConsumerName.Enabled = true;
                lblAddNewConsumer.Enabled = true;
                txtConsumerCode.Text = "";
                ctlCustomer1.txtCode.Text = "";
            }
            else
            {
                ctlCustomer1.Enabled = false;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtConsumerName.Enabled = true;
                lblAddNewConsumer.Enabled = true;
                txtConsumerCode.Text = "";
                ctlCustomer1.txtCode.Text = "";
                sCustomerCode = oSystemInfo.CustomerCode;
                ctlCustomer1.txtCode.Text = sCustomerCode;
            }
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
                    nConsumerID = oRetailConsumer.ConsumerID;
                    sCustomerCode = oRetailConsumer.CustomerCode;
                    txtConsumerCode.SelectionStart = 0;
                    txtConsumerCode.SelectionLength = txtConsumerCode.Text.Length;
                    txtConsumerCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            oRetailConsumer = new RetailConsumer();
            frmReatilConsumerSearch oObj = new frmReatilConsumerSearch(cmbSalesType.SelectedIndex + 1, (int)Dictionary.Terminal.Branch_Office, oSystemInfo.WarehouseID);
            oObj.ShowDialog(oRetailConsumer);
            if (oRetailConsumer.ConsumerCode != null)
            {
                txtConsumerCode.Text = oRetailConsumer.ConsumerCode.ToString();
                sCustomerCode = oRetailConsumer.CustomerCode;
                ctlCustomer1.txtCode.Text = sCustomerCode;
            }
        }

        private void lblAddNewConsumer_Click(object sender, EventArgs e)
        {
            if (ctlCustomer1.txtDescription.Text != "")
            {
                frmConsumer ofrmConsumer = new frmConsumer(cmbSalesType.SelectedIndex + 1, ctlCustomer1.SelectedCustomer.CustomerID);
                ofrmConsumer.ShowDialog();
                if (ofrmConsumer._IsTrue == true)
                {
                    txtConsumerCode.Text = ofrmConsumer.sConsumerCode;
                }
            }
            else
            {
                MessageBox.Show("Please select customer first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return;
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtAmount.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Text = "0.00";
                }

            }
        }

        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.txtDescription.Text != "")
            {
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail)
                {
                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    string _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.Retail);
                    if (_sCustType.Contains(ctlCustomer1.SelectedCustomer.CustTypeID.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please select valid Retail Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCustomer1.txtCode.Text = "";
                        ctlCustomer1.txtCode.Focus();
                        return;
                    }
                }
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
                {
                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    string _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.B2B);
                    if (_sCustType.Contains(ctlCustomer1.SelectedCustomer.CustTypeID.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please select valid B2B Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCustomer1.txtCode.Text = "";
                        ctlCustomer1.txtCode.Focus();
                        return;
                    }


                }
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C)
                {

                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    string _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.B2C);
                    if (_sCustType.Contains(ctlCustomer1.SelectedCustomer.CustTypeID.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please select valid B2C Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCustomer1.txtCode.Text = "";
                        ctlCustomer1.txtCode.Focus();
                        return;
                    }
                }
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                {

                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    string _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.Dealer);
                    if (_sCustType.Contains(ctlCustomer1.SelectedCustomer.CustTypeID.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please select valid Dealer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCustomer1.txtCode.Text = "";
                        ctlCustomer1.txtCode.Focus();
                        return;
                    }
                }
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
                {

                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    string _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.HPA);
                    if (_sCustType.Contains(ctlCustomer1.SelectedCustomer.CustTypeID.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please select valid HPA customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCustomer1.txtCode.Text = "";
                        ctlCustomer1.txtCode.Focus();
                        return;
                    }
                }
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                {

                    //CustomerTypies oCustomerTypes = new CustomerTypies();
                    //string _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.eStore);
                    //if (_sCustType.Contains(ctlCustomer1.SelectedCustomer.CustTypeID.ToString()))
                    //{

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Please select valid eStore customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    ctlCustomer1.txtCode.Text = "";
                    //    ctlCustomer1.txtCode.Focus();
                    //    return;
                    //}
                }

            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
            {
                txtAmount.Enabled = false;
                cmbEMITenure.Enabled = false;
            }
            else if (cmbType.SelectedIndex == 1)
            {
                txtAmount.Enabled = true;
                cmbEMITenure.Enabled = false;
            }
            else
            {
                txtAmount.Enabled = false;
                cmbEMITenure.Enabled = true;
            }

        }
    }
}
