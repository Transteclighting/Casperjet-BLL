// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam kar
// Date: Apr 27, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Warehouse.
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
    public partial class frmChannels : Form
    {
        Channel _oChannel;
        Channels _oChannels;
        public frmChannels()
        {
            //_oChannel = new Channel();
           // _oChannels = new Channels();
            InitializeComponent();
        }

        private void frmChannels_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            lvwChannels.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oChannels = new Channels();
            _oChannels.Refresh();

            foreach (Channel oChannel in _oChannels)
            {
                ListViewItem oItem = lvwChannels.Items.Add(oChannel.ChannelCode);
                oItem.SubItems.Add(oChannel.ChannelDescription);
                if (oChannel.IsActive == (int)Dictionary.YesOrNoStatus.YES)
                {
                    oItem.SubItems.Add("Active");
                }
                else
                {
                    oItem.SubItems.Add("InActive");
                }
                oItem.Tag = oChannel;
            }

            this.Text = "Channels " + "[" + _oChannels.Count + "]";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChannel oForm = new frmChannel();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwChannels.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Channel to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oChannels = new Channels();
            _oChannel = (Channel)lvwChannels.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Market: " + _oChannel.ChannelDescription + " ? ", "Confirm MarketGroup Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oChannel.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwChannels.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Channel Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oChannels = new Channels();
            _oChannel = (Channel)lvwChannels.SelectedItems[0].Tag;
            frmChannel oForm = new frmChannel();
            oForm.ShowDialog(_oChannel);
            LoadData();
        }
    }
}