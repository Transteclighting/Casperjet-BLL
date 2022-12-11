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

namespace CJ.Win.Accounts
{
    public partial class frmBankInterest : Form
    {
        BankIst _oBankIst;
        BankIsts _oBankIsts;
        Banks _oBanks;
        int nID = 0;
        object _dtEffectiveTo = null;

        public frmBankInterest()
        {
            _oBankIst = new BankIst();
            _oBankIsts = new BankIsts();
            _oBanks = new Banks();
            InitializeComponent();
        }

        private void frmBankInterest_Load(object sender, EventArgs e)
        {
            dtEffectiveDate.Value = DateTime.Now.Date;

            if (this.Tag == null)
            {
                this.Text = "Add New Interest Rate";
                LoadData();
            }
            else
            {
                this.Text = "Edit Interest Rate";
            }
        }

        private void LoadData()
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

        public void ShowDialog(BankIst oBankIst)
        {
            BankIsts oBankIsts = new BankIsts();
            this.Tag = oBankIst;
            LoadData();
            nID = oBankIst.ID;
            txtEMINo.Text = oBankIst.EMINo.ToString();
            txtInterestRate.Text = oBankIst.InsRate.ToString();
            cmbBankName.SelectedIndex = _oBanks.GetIndexByID(oBankIst.BankID) + 1;
            cmbBankName.Enabled = false;
            txtEMINo.Enabled = false;

            this.ShowDialog();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                BankIst oBankIst = new BankIst();
                oBankIst.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                oBankIst.EMINo = Convert.ToInt32(txtEMINo.Text);
                oBankIst.InsRate = Convert.ToDouble(txtInterestRate.Text);
                oBankIst.EffectiveFrom = dtEffectiveDate.Value.Date;
                oBankIst.IsActive = (int)Dictionary.IsActive.Active;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBankIst.Add();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BankIst oBankIst = new BankIst();
                oBankIst.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                oBankIst.EMINo = Convert.ToInt32(txtEMINo.Text);
                oBankIst.InsRate = Convert.ToDouble(txtInterestRate.Text);
                oBankIst.EffectiveFrom = dtEffectiveDate.Value.Date;
                oBankIst.IsActive = (int)Dictionary.IsActive.Active;


                try
                {
                    oBankIst.GetData();
                    if (oBankIst.InsRate == Convert.ToDouble(txtInterestRate.Text))
                    {
                        oBankIst.ID = nID;
                        oBankIst.InsRate = Convert.ToDouble(txtInterestRate.Text);
                        oBankIst.Update();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DBController.Instance.BeginNewTransaction();
                        oBankIst.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                        oBankIst.EMINo = Convert.ToInt32(txtEMINo.Text);
                        oBankIst.InsRate = Convert.ToDouble(txtInterestRate.Text);
                        oBankIst.EffectiveFrom = dtEffectiveDate.Value.Date;
                        oBankIst.IsActive = (int)Dictionary.IsActive.Active;

                        oBankIst.Add();
                        oBankIst.ID = nID;
                        oBankIst.IsActive = (int)Dictionary.IsActive.InActive;
                        oBankIst.EffectiveTo = dtEffectiveDate.Value.AddDays(-1);
                        oBankIst.Edit();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

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
            this.Close();
        }
    }
}