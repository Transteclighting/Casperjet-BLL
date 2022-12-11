using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmEMIBankMapping : Form
    {
        ///private EMIBankMappings _oEMIBankMappings;

        Banks _oBanks;
        EMITenures _oEMITenures;
        private EMIBankMappings _oEMIBankMappingsForTenure;
        private EMIBankMapping _oEMIBankMapping;
        private string checkDuplicateValue;
        public bool _bActionSave = false;

        int nID = 0;
        public frmEMIBankMapping()
        {
            InitializeComponent();
        }
        
        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            _oBanks = new Banks();
            _oEMITenures = new EMITenures();

            DBController.Instance.OpenNewConnection();
            _oBanks.GetEMIBankForMapping();
            cmbBank.Items.Add("--All--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;

            _oEMITenures.GetEMITenure();
            cmbTenure.Items.Add("--All--");
            foreach (EMITenure oEMITenure in _oEMITenures)
            {
                cmbTenure.Items.Add(oEMITenure.Tenure);
            }
            cmbTenure.SelectedIndex = 0;
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

        public void ShowDialog(EMIBankMapping oEMIBankMapping)
        {
            this.Tag = oEMIBankMapping;
            LoadCombo();
            nID = oEMIBankMapping.ID;
            cmbBank.SelectedIndex = _oBanks.GetIndexByID(oEMIBankMapping.BankID) + 1;
            cmbTenure.SelectedIndex = _oEMITenures.GetIndex(oEMIBankMapping.EMITenureID) + 1;

            //txtDiscountTypeName.Enabled = false;

            this.ShowDialog();
        }

        private bool UIValidation()
        {
            if (cmbBank.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBank.Focus();
                return false;
            }

            if (cmbTenure.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Tenure", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenure.Focus();
                return false;
            }

            EMIBankMapping oEMIBankMapping = new EMIBankMapping();
            oEMIBankMapping.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
            oEMIBankMapping.EMITenureID = _oEMITenures[cmbTenure.SelectedIndex - 1].EMITenureID;
            checkDuplicateValue = oEMIBankMapping.CheckDuplicateData();

            if (checkDuplicateValue == "Yes")
            {
                MessageBox.Show("Bank EMI already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenure.Focus();
                return false;
            }

          return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {

                if (cmbBank.SelectedIndex > 0 && cmbTenure.SelectedIndex > 0)
                {
                    EMIBankMapping oEMIBankMapping = new EMIBankMapping();

                    oEMIBankMapping.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                    oEMIBankMapping.EMITenureID = _oEMITenures[cmbTenure.SelectedIndex - 1].EMITenureID;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oEMIBankMapping.Add();
                        Showrooms oShowrooms = new Showrooms();
                        oShowrooms.Refresh();
                        foreach (Showroom oShowroom in oShowrooms)
                        {
                            DataTran oDataTran = new DataTran();
                            oDataTran.TableName = "t_EMIBankMapping";
                            oDataTran.DataID = Convert.ToInt32(oEMIBankMapping.ID);
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
                        MessageBox.Show("Your data has been updated successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }

                else
                {
                    MessageBox.Show("Please select values properly");
                }

            }
            else
            {
                EMIBankMapping oEMIBankMapping = (EMIBankMapping)this.Tag;
                oEMIBankMapping.ID = nID;
                oEMIBankMapping.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                oEMIBankMapping.EMITenureID = _oEMITenures[cmbTenure.SelectedIndex - 1].EMITenureID;

                checkDuplicateValue = oEMIBankMapping.CheckDuplicateData();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEMIBankMapping.Edit();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_EMIBankMapping";
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

        private void frmEMIBankMapping_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
        }

        private void txtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
