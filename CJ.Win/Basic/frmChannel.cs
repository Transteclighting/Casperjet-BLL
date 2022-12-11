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
    public partial class frmChannel : Form
    {
        Channel _oChannel;
        Channels _oChannels;
        SBUs _oSBUs;
        public frmChannel()
        {
            //_oChannel = new Channel();
            //_oChannels = new Channels();
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidUI())
            {
                Save();
                this.Close();
            }
        }

        private bool IsValidUI()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Code of Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtDesc.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Description of Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }
            if (cboType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Channel Type Name for Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboType.Focus();
                return false;
            }

            if (cboSbu.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select SBU Type Name for Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSbu.Focus();
                return false;
            }
            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                _oChannel = new Channel();
                //_oChannels = new Channels();
                _oChannel.ChannelCode = txtCode.Text;
                _oChannel.ChannelDescription = txtDesc.Text;
                if (chkActive.Checked)
                {
                    _oChannel.IsActive = 1;
                }
                else
                {
                    _oChannel.IsActive = 0;
                }

                _oChannel.ChannelType = cboType.SelectedIndex;
                _oChannel.SBUID = _oSBUs[cboSbu.SelectedIndex - 1].SBUID;
                _oChannel.ChannelCode = txtCode.Text;
                _oChannel.SortOrder =Convert.ToInt32(txtShortCode.Text);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oChannel.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oChannel.ChannelCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                _oChannel = (Channel)this.Tag;
                _oChannel.ChannelCode = txtCode.Text;
                _oChannel.ChannelDescription = txtDesc.Text;
                if (chkActive.Checked)
                {
                    _oChannel.IsActive = 1;
                }
                else
                {
                    _oChannel.IsActive = 0;
                }

                _oChannel.ChannelType = cboType.SelectedIndex;
                _oChannel.SBUID = _oSBUs[cboSbu.SelectedIndex - 1].SBUID;
                _oChannel.SortOrder = Convert.ToInt32(txtShortCode.Text);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oChannel.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Department : " + _oChannel.ChannelDescription, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void frmChannel_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Channel";
                LoadCombo();
            }
            else
            {
                this.Text = "Edit Channel";
            }
        }

        private void LoadCombo()
        {
            //_oChannel = new Channel();
            //_oChannels = new Channels();
            cboType.Items.Clear();
            cboType.Items.Add("---Select Channel---");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ChannelType)))
            {
                cboType.Items.Add(Enum.GetName(typeof(Dictionary.ChannelType), GetEnum));
            }
            cboType.SelectedIndex = 0;

            _oSBUs = new SBUs();
            cboSbu.Items.Clear();
            cboSbu.Items.Add("---Select SBU---");
            _oSBUs.Refresh();
            foreach (SBU oSBU in _oSBUs)
            {
                cboSbu.Items.Add(oSBU.SBUName);
            }
            cboSbu.SelectedIndex = 0;
        }

        public void ShowDialog(Channel oChannel)
        {
            this.Tag = oChannel;
            LoadCombo();
            txtCode.Text = oChannel.ChannelCode;
            txtDesc.Text = oChannel.ChannelDescription;
            if (oChannel.IsActive == 1)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }
            int nType = oChannel.ChannelType;
            cboType.SelectedIndex = nType;
            cboSbu.SelectedIndex = _oSBUs.GetIndex(oChannel.SBUID) + 1;
            txtShortCode.Text = oChannel.SortOrder.ToString();
            this.ShowDialog();
        }
    }
}