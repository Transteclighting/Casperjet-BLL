// <summary>
// Compamy: Transcom Electronics Limited
// Author:Uttam Kar 30-Apr-2014.
// Date: April 25, 2011
// Time :  12:00 PM
// Description: Market Group Interface.
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
    public partial class frmMarketGroup : Form
    {
        MarketGroup _oMarketGroup;
        MarketGroups _oMarketGroups;
        Channels _oChannels;

        private Dictionary.MarketGroupType _nMarketGrouptype;
        int nUIControl = 0;
        public frmMarketGroup(int nMarketGrouptype)
        {
           
           // _oChannels = new Channels();
            nUIControl = nMarketGrouptype;
            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            _oMarketGroup = new MarketGroup();
            _oMarketGroups = new MarketGroups();
            if (this.Tag == null)
            {

                _oMarketGroup.Pos = Convert.ToInt32(txtPos.Text);
                _oMarketGroup.MarketGroupCode = txtCode.Text;
                _oMarketGroup.MarketGroupDesc = txtDesc.Text;

                if (cmbType.SelectedIndex + 1 == (int)Dictionary.MarketGroupType.Area)
                {
                    _oMarketGroup.MarketGroupType = cmbType.SelectedIndex +1;
                    _oMarketGroup.ParentID = -1;
                }
                else
                {
                    _oMarketGroup.MarketGroupType = cmbType.SelectedIndex + 1;
                    _oMarketGroup.ParentID = _oMarketGroups[cmbParent.SelectedIndex].MarketGroupID;
                }



                _oMarketGroup.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                _oMarketGroup.ChannelID = _oChannels[cmbChannel.SelectedIndex - 1].ChannelID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oMarketGroup.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oMarketGroup.MarketGroupID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                _oMarketGroup = (MarketGroup)this.Tag;
                _oMarketGroup.Pos = Convert.ToInt32(txtPos.Text);
                _oMarketGroup.MarketGroupCode = txtCode.Text;
                _oMarketGroup.MarketGroupDesc = txtDesc.Text;

                if (cmbType.SelectedIndex + 1 == (int)Dictionary.MarketGroupType.Area)
                {
                    _oMarketGroup.MarketGroupType = cmbType.SelectedIndex + 1;
                    _oMarketGroup.ParentID = -1;
                }
                else
                {
                    _oMarketGroup.MarketGroupType = cmbType.SelectedIndex + 1;
                    _oMarketGroup.ParentID = _oMarketGroups[cmbParent.SelectedIndex].MarketGroupID;
                }



                _oMarketGroup.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                _oMarketGroup.ChannelID = _oChannels[cmbChannel.SelectedIndex - 1].ChannelID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oMarketGroup.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Department : " + _oMarketGroup.MarketGroupDesc, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private bool IsValidate()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter MarketGroup Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtDesc.Text == "")
            {
                MessageBox.Show("Please enter MarketGroup Description.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }
            if (cmbChannel.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Channel Name for market group", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbChannel.Focus();
                return false;
            }

            //if (cmbType.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Market Type for market group", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbChannel.Focus();
            //    return false;
            //}

            return true;
        }

        private void frmMarketGroup_Load(object sender, EventArgs e)
        {
            if (nUIControl == (int)Dictionary.MarketGroupType.Area)
            {
                if (this.Tag == null) this.Text = "Add New Area";
                else this.Text = "Edit Area";
                cmbParent.Visible = false;
                lblParent.Visible = false;
            }
            else
            {
                if (this.Tag == null) this.Text = "Add New Territory";
                else this.Text = "Edit Territory";
                cmbParent.Visible = true;
                lblParent.Visible = true;
            }

            if (this.Tag == null)
            {
                LoadArea();
                LoadChannel();
                LoadParent();
            }
            
        }

        private void LoadArea()
        {
            //cmbType.Items.Add("--Select MarketGroup--");
            if (nUIControl == (int)Dictionary.MarketGroupType.Area)
            {
                foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MarketGroupType)))
                {
                    cmbType.Items.Add(Enum.GetName(typeof(Dictionary.MarketGroupType), GetEnum));
                }
                cmbType.SelectedIndex = 0;
            }
            else
            {
                foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MarketGroupType)))
                {
                    cmbType.Items.Add(Enum.GetName(typeof(Dictionary.MarketGroupType), GetEnum));
                }
                cmbType.SelectedIndex = 1;
            }
        }

        private void LoadChannel()
        {
            cmbChannel.Items.Add("--Select Channel--");
            _oChannels = new Channels();
            _oChannels.GetChannel();
            foreach (Channel oChannel in _oChannels)
            {
                cmbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbChannel.SelectedIndex = 0;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.Tag == null)
            //{
            //    LoadParent();
            //}
        }

        private void LoadParent()
        {
            _oMarketGroups = new MarketGroups();
            _oMarketGroups.GetParentID();
            //_oMarketGroups.Refresh((int) Dictionary.MarketGroupType.Area)
            foreach (MarketGroup oMarketGroup in _oMarketGroups)
            {
                cmbParent.Items.Add(oMarketGroup.MarketGroupDesc);
            }
            cmbParent.SelectedIndex = 0;
        }

        public void ShowDialog(MarketGroup oMarketGroup)
        {
            this.Tag = oMarketGroup;
            LoadChannel();
            LoadArea();
            LoadParent();
            //_oMarketGroups = new MarketGroups();
            txtPos.Text = Convert.ToString(oMarketGroup.Pos);
            txtCode.Text = oMarketGroup.MarketGroupCode;
            txtDesc.Text = oMarketGroup.MarketGroupDesc;
            cmbParent.SelectedIndex = _oMarketGroups.GetIndex(oMarketGroup.MarketGroupID);
            if (oMarketGroup.EmployeeID != 0)
            {
                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = oMarketGroup.EmployeeID;
                oEmployee.Refresh();
                ctlEmployee1.txtCode.Text = oEmployee.EmployeeCode;
            }
            cmbChannel.SelectedIndex = _oChannels.GetIndex(oMarketGroup.ChannelID + 1);
            
            this.ShowDialog();
        }
    }
}