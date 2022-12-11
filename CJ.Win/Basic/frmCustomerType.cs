// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam kar
// Date: May 12, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Customer Type.
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

namespace CJ.Win.Basic
{
    public partial class frmCustomerType : Form
    {
        CustomerType _oCustomerType;
        CustomerTypies _oCustomerTypies;
        Channels _oChannels;
        public frmCustomerType()
        {
            InitializeComponent();
        }

        private void frmCustomerType_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Customer Type";
                LoadCombo();
            }
            else
            {
                this.Text = "Edit Customer Type";
            }
        }

        private void LoadCombo()
        {
            /******Load Channel***********/
            _oChannels = new Channels();
            cmbChannel.Items.Add("---Select Channel---");
            _oChannels.Refresh();
            foreach (Channel oChannel in _oChannels)
            {
                cmbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbChannel.SelectedIndex = 0;

            /******Load Reporting Channel***********/
            cmbReportingChannel.Items.Add("--Select Reporting Channel--");
            foreach (Channel oChannel in _oChannels)
            {
                cmbReportingChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbReportingChannel.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidUI())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                _oCustomerType = new CustomerType();
                _oCustomerTypies = new CustomerTypies();
                _oCustomerType.CustTypeCode = txtCode.Text;
                _oCustomerType.CustTypeDescription = txtDesc.Text;
                _oCustomerType.ChannelID = _oChannels[cmbChannel.SelectedIndex - 1].ChannelID;

                if (chkActive.Checked)
                {
                    _oCustomerType.IsActive = 1;
                }
                else
                {
                    _oCustomerType.IsActive = 0;
                }

                _oCustomerType.Pos = Convert.ToInt32(txtPos.Text);
                if (cmbReportingChannel.SelectedIndex != 0)
                {
                    _oCustomerType.ReportingChannelID = _oChannels[cmbReportingChannel.SelectedIndex - 1].ChannelID;
                }
                else
                {
                    _oCustomerType.ReportingChannelID = 0;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerType.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oCustomerType.CustTypeCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }


            else
            {
                int nIsActive = 0;
                _oCustomerType = (CustomerType)this.Tag;
                _oCustomerType.CustTypeCode = txtCode.Text;
                _oCustomerType.CustTypeDescription = txtDesc.Text;
                _oCustomerType.ChannelID = _oChannels[cmbChannel.SelectedIndex - 1].ChannelID;

                if (nIsActive == (int)Dictionary.YesOrNoStatus.NO)
                {
                    _oCustomerType.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                else
                {
                    _oCustomerType.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                _oCustomerType.Pos = Convert.ToInt32(txtPos.Text);

                if (cmbReportingChannel.SelectedIndex != 0)
                {
                    _oCustomerType.ReportingChannelID = _oChannels[cmbReportingChannel.SelectedIndex - 1].ChannelID;
                }
                else
                {
                    _oCustomerType.ReportingChannelID = 0;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerType.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oCustomerType.CustTypeCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private bool IsValidUI()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Code of Customer Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtDesc.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Description of Customer Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }
            if (cmbChannel.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Channel Name for Customer Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbChannel.Focus();
                return false;
            }
            if (txtPos.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Pos No for Customer Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPos.Focus();
                return false;
            }

            //if (cmbReportingChannel.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Reporting Channel Name for Customer Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbChannel.Focus();
            //    return false;
            //}
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(CustomerType oCustomerType)
        {
            _oCustomerTypies = new CustomerTypies();
            this.Tag = oCustomerType;
            LoadCombo();
            txtCode.Text = oCustomerType.CustTypeCode;
            txtDesc.Text = oCustomerType.CustTypeDescription;
            cmbChannel.SelectedIndex = _oChannels.GetIndex(oCustomerType.ChannelID) + 1;
            if (oCustomerType.IsActive == 1)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }
            txtPos.Text = Convert.ToInt32(oCustomerType.Pos).ToString();
            cmbReportingChannel.SelectedIndex = _oChannels.GetIndex(oCustomerType.ReportingChannelID) + 1;
            this.ShowDialog();
        }
    }
}