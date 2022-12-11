using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.Accounts
{
    public partial class frmBankGuaranty : Form
    {
        int nBGID = 0;
        public bool IsTrue = false;
        Banks _oBanks;

        public frmBankGuaranty()
        {
            InitializeComponent();
        }
        public void ShowDialog(CustomerBankGuaranty oCustomerBankGuaranty)
        {

            this.Tag = oCustomerBankGuaranty;
            DBController.Instance.OpenNewConnection();
            LoadCombo();
            nBGID = oCustomerBankGuaranty.BGID;
            ctlCustomer1.Enabled = false;
            cmbBankName.Enabled = false;
            txtBGAmount.Enabled = false;
            dtEffectiveDate.Enabled = false;
            dtExpiryDate.Enabled = false;

            ctlCustomer1.txtCode.Text = oCustomerBankGuaranty.CustomerCode;
            cmbBankName.SelectedIndex = _oBanks.GetIndexByID(oCustomerBankGuaranty.BankID) + 1;
            dtEffectiveDate.Value = oCustomerBankGuaranty.EffectiveDate;
            dtExpiryDate.Value = oCustomerBankGuaranty.ExpiryDate;
            txtBGAmount.Text = oCustomerBankGuaranty.BGAmount.ToString();

            if (oCustomerBankGuaranty.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            txtRemarks.Text = oCustomerBankGuaranty.Remarks;


            this.ShowDialog();
        }

        private void LoadCombo()
        {
            _oBanks = new Banks();
            DBController.Instance.OpenNewConnection();
            _oBanks.Refresh();
            cmbBankName.Items.Add("--Select Bank--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBankName.Items.Add(oBank.Name);
            }
            cmbBankName.SelectedIndex = 0;
        }

        private bool UIValidation()
        {
            if (cmbBankName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBankName.Focus();
                return false;
            }
            if (ctlCustomer1.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Select a Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            if (Convert.ToDouble(txtBGAmount.Text) <= 0)
            {
                MessageBox.Show("Please Enter Valid BG Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBGAmount.Focus();
                return false;
            }
            return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                CustomerBankGuaranty oCustomerBankGuaranty = new CustomerBankGuaranty();
                oCustomerBankGuaranty.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oCustomerBankGuaranty.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                oCustomerBankGuaranty.EffectiveDate = dtEffectiveDate.Value.Date;
                oCustomerBankGuaranty.ExpiryDate = dtExpiryDate.Value.Date;
                oCustomerBankGuaranty.BGAmount = Convert.ToDouble(txtBGAmount.Text);
                oCustomerBankGuaranty.Remarks = txtRemarks.Text;
                oCustomerBankGuaranty.CreateDate = DateTime.Now.Date;
                oCustomerBankGuaranty.CreateuserID = Utility.UserId;

                if (chkIsActive.Checked == true)
                {
                    oCustomerBankGuaranty.IsActive = (int)Dictionary.IsActive.Active;

                }
                else
                {
                    oCustomerBankGuaranty.IsActive = (int)Dictionary.IsActive.InActive;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCustomerBankGuaranty.Add();






                    Showroom oShowroom = new Showroom();
                    int nWarehouseID = oShowroom.GetWarehouseIDByCustomer(oCustomerBankGuaranty.CustomerID);

                    if (nWarehouseID != 0)
                    {

                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_CustomerBankGuaranty";
                        oDataTran.DataID = Convert.ToInt32(oCustomerBankGuaranty.BGID);
                        oDataTran.WarehouseID = nWarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }

                    }


                    #region Insert Customer Bank Guaranty Data for Super Outlet

                    Customer oCustomerGuaranty = new Customer();
                    oCustomerGuaranty.CustomerBalanceDataCreation(ctlCustomer1.SelectedCustomer.CustomerID, nWarehouseID, "t_CustomerBankGuaranty", Convert.ToInt32(oCustomerBankGuaranty.BGID));


                    //Customer oCustomer = new Customer();
                    //oCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    //if (oCustomer.CheckDistributionCustomer())
                    //{

                    //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SuperOutlet)))
                    //    {
                    //        DataTran oDataTran = new DataTran();
                    //        oDataTran.TableName = "t_CustomerBankGuaranty";
                    //        oDataTran.DataID = Convert.ToInt32(oCustomerBankGuaranty.BGID);
                    //        oDataTran.WarehouseID = GetEnum;
                    //        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    //        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    //        oDataTran.BatchNo = 0;
                    //        if (oDataTran.CheckData() == false)
                    //        {
                    //            oDataTran.AddForTDPOS();
                    //        }
                    //    }
                    //}
                    #endregion


                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                CustomerBankGuaranty oCustomerBankGuaranty = new CustomerBankGuaranty();
                oCustomerBankGuaranty.BGID = nBGID;
                oCustomerBankGuaranty.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oCustomerBankGuaranty.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                oCustomerBankGuaranty.EffectiveDate = dtEffectiveDate.Value.Date;
                oCustomerBankGuaranty.ExpiryDate = dtExpiryDate.Value.Date;
                oCustomerBankGuaranty.BGAmount = Convert.ToDouble(txtBGAmount.Text);
                oCustomerBankGuaranty.Remarks = txtRemarks.Text;
                oCustomerBankGuaranty.UpdateDate = DateTime.Now.Date;
                oCustomerBankGuaranty.UpdateUserID = Utility.UserId;

                if (chkIsActive.Checked == true)
                {
                    oCustomerBankGuaranty.IsActive = (int)Dictionary.IsActive.Active;

                }
                else
                {
                    oCustomerBankGuaranty.IsActive = (int)Dictionary.IsActive.InActive;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCustomerBankGuaranty.UpdateStatus();
                    #region Insert Customer Bank Guaranty Data for Super Outlet
                    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SuperOutlet)))
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_CustomerBankGuaranty";
                        oDataTran.DataID = Convert.ToInt32(oCustomerBankGuaranty.BGID);
                        oDataTran.WarehouseID = GetEnum;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    #endregion
                    Showroom oShowroom = new Showroom();
                    int nWarehouseID = oShowroom.GetWarehouseIDByCustomer(oCustomerBankGuaranty.CustomerID);
                    if (nWarehouseID != 0)
                    {

                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_CustomerBankGuaranty";
                        oDataTran.DataID = Convert.ToInt32(oCustomerBankGuaranty.BGID);
                        oDataTran.WarehouseID = nWarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }

                    }
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Edit Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                IsTrue = true;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            IsTrue = false;
        }

        private void frmBankGuaranty_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
                this.Text = "Add Customer Bank Guaranty";
            }
            else
            {
                this.Text = "Edit Customer Bank Guaranty";
            }
        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}