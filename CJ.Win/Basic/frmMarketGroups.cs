// <summary>
// Compamy: Transcom Electronics Limited
// Author:Uttam Kar 30-Apr-2014.
// Date: April 25, 2011
// Time :  12:00 PM
// Description: Class for Channel.
// Modify Person And Date:.
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
    public partial class frmMarketGroups : Form
    {
        MarketGroups _oMarketGroups;
        MarketGroup _oMarketGroup;
        int _nUIControl = 0;
     
        private Dictionary.MarketGroupType _nMarketGrouptype;
        public frmMarketGroups(int nUIControl)
        {
            InitializeComponent();
           
            _oMarketGroup = new MarketGroup();
            _nUIControl = nUIControl;
            
        }

        private void frmMarketGroups_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            lvwMarketGroups.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oMarketGroups = new MarketGroups();
            _oMarketGroups.Refresh(_nUIControl);
            if (_nUIControl == (int)Dictionary.MarketGroupType.Area)
            {
                this.Text = "Area " + "[" + _oMarketGroups.Count + "]";
            }
            else
            {
                this.Text = "Territory " + "[" + _oMarketGroups.Count + "]";
            }
            foreach (MarketGroup oMarketGroup in _oMarketGroups)
            {
                ListViewItem oItem = lvwMarketGroups.Items.Add(oMarketGroup.MarketGroupCode);
                oItem.SubItems.Add(oMarketGroup.MarketGroupDesc);                
                oItem.SubItems.Add(oMarketGroup.ChnnelDesc.ChannelDescription);
                if (_nUIControl ==(int) Dictionary.MarketGroupType.Territory)
                {
                    oItem.SubItems.Add(oMarketGroup.MarketDesc.MarketGroupDesc);
                }
                oItem.Tag = oMarketGroup;
            }
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMarketGroup ofrmMarketGroup = new frmMarketGroup(_nUIControl);
            ofrmMarketGroup.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwMarketGroups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a MarketGroup to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oMarketGroup = (MarketGroup)lvwMarketGroups.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Market: " + _oMarketGroup.MarketGroupCode + " ? ", "Confirm MarketGroup Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oMarketGroup.Delete();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwMarketGroups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an MarketGroup Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oMarketGroup = (MarketGroup)lvwMarketGroups.SelectedItems[0].Tag;
            frmMarketGroup ofrmMarketGroup = new frmMarketGroup(_nUIControl);
            ofrmMarketGroup.ShowDialog(_oMarketGroup);
            LoadData();
        }      

    }
}