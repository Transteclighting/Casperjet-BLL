using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Accounts;
using CJ.Class.POS;

namespace CJ.Win.Accounts
{
    public partial class frmExtendedEMICharge : Form
    {

        private string checkDuplicateValue;
        EMITenures _oEMITenures;
        public bool _bActionSave = false;
        EMIExtendedCharges _oEMIExtendedCharges;
        Banks _oBanks;

        
        int nID = 0;
        public frmExtendedEMICharge()
        {
            InitializeComponent();
        }

        private void LoadCombo()
        {
            _oEMIExtendedCharges = new EMIExtendedCharges();
            DBController.Instance.OpenNewConnection();
            _oEMIExtendedCharges.GetEMITenure();
            cmbEMI.Items.Add("--Select EMI Tenure--");
            foreach (EMIExtendedCharge oEMIExtendedCharge in _oEMIExtendedCharges)
            {
                cmbEMI.Items.Add(oEMIExtendedCharge.EMITenure);
            }
            cmbEMI.SelectedIndex = 0;
        }

        private void LoadBank()
        {
            _oBanks = new Banks();
            DBController.Instance.OpenNewConnection();
            _oBanks.GetBankForFinancialInstitution();
            cmbBankName.Items.Clear();
            cmbBankName.Items.Add("--Select Bank--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBankName.Items.Add(oBank.Name);
            }
            cmbBankName.SelectedIndex = 0;
        }

        public void ShowDialog(EMIExtendedCharge oEMIExtendedCharge)
        {
            this.Tag = oEMIExtendedCharge;
            LoadCombo();
            nID = oEMIExtendedCharge.ID;
            cmbEMI.SelectedIndex = _oEMIExtendedCharges.GetIndexByID(oEMIExtendedCharge.EMITenureID) + 1;
            txtChgPercentage.Text = oEMIExtendedCharge.ChargePercent.ToString();

            if (oEMIExtendedCharge.BankID == -1)
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
                cmbBankName.SelectedIndex = _oBanks.GetIndexByID(oEMIExtendedCharge.BankID) + 1;
            }
            
            //txtDiscountTypeName.Enabled = false;

            this.ShowDialog();
        }
        private void Save()
        {
            if (this.Tag == null)
            {                           

                EMIExtendedCharge oEMIExtendedCharge = new EMIExtendedCharge();
                oEMIExtendedCharge.EMITenureID = _oEMIExtendedCharges[cmbEMI.SelectedIndex - 1].EMITenureID;
                oEMIExtendedCharge.ChargePercent = Convert.ToDouble(txtChgPercentage.Text);
                if (checkBox1.Checked == true)
                {
                    oEMIExtendedCharge.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                }
                else
                {
                    oEMIExtendedCharge.BankID = -1;
                }


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEMIExtendedCharge.Add();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_EMIExtendedCharge";
                        oDataTran.DataID = Convert.ToInt32(oEMIExtendedCharge.ID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                EMIExtendedCharge oEMIExtendedCharge = (EMIExtendedCharge)this.Tag;
                oEMIExtendedCharge.ID = nID;
                oEMIExtendedCharge.EMITenure = _oEMIExtendedCharges[cmbEMI.SelectedIndex - 1].EMITenure;
                oEMIExtendedCharge.ChargePercent = Convert.ToDouble(txtChgPercentage.Text);
                if (checkBox1.Checked == true)
                {
                    oEMIExtendedCharge.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                }
                else
                {
                    oEMIExtendedCharge.BankID = -1;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEMIExtendedCharge.Edit();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_EMIExtendedCharge";
                        oDataTran.DataID = Convert.ToInt32(nID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                
                _bActionSave = true;
                this.Close();
            }
        }

        private bool UIValidation()
        {
            if (cmbEMI.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an EMI Tenure Month", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEMI.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtChgPercentage.Text))
            {
                MessageBox.Show("Please insert an charge percentage", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChgPercentage.Focus();
                return false;
            }

            int number;
            if (int.TryParse(txtChgPercentage.Text, out number))
            {
                if (number <= 0)
                {
                    MessageBox.Show("Charge percentage must be greater than zero", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChgPercentage.Focus();
                    return false;
                }
            }

            EMIExtendedCharge oEMIExtendedCharge = new EMIExtendedCharge();
            oEMIExtendedCharge.ChargePercent = Double.Parse(txtChgPercentage.Text);
            oEMIExtendedCharge.EMITenureID = _oEMIExtendedCharges[cmbEMI.SelectedIndex - 1].EMITenureID;
            checkDuplicateValue = oEMIExtendedCharge.CheckDuplicateData();

            frmEMITenure ofrmEMITenure = new frmEMITenure();

            if (checkDuplicateValue == "Yes")
            {
                MessageBox.Show("EMI extendend charge already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChgPercentage.Focus();
                return false;
            }


            return true;

        }   

        private void frmExtendedEMICharge_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
        }

        private void txtChgPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                cmbBankName.Enabled = true;
                lblBankName.Enabled = true;
                LoadBank();
            }
            else
            {
                cmbBankName.Enabled = false;
                lblBankName.Enabled = false;
                cmbBankName.Items.Clear();
                cmbBankName.Items.Add("--N/A--");
                cmbBankName.SelectedIndex = 0;
            }
        }
    }
}
