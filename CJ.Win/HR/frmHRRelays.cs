using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRRelays : Form
    {
        HRRelays _oHRRelays;
        public frmHRRelays()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRelay();
        }
        private void AddRelay()
        {
            frmHRRelayAdd _ofrmHRRelayAdd = new frmHRRelayAdd();
            _ofrmHRRelayAdd.ShowDialog();
            DataLoadControl();            
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRelay();
        }
        private void EditRelay()
        {
            if (lvwHRRelays.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Edit HR Relay", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmHRRelayAdd _ofrmHRRelayAdd = new frmHRRelayAdd();
            HRRelay oHRRelay = (HRRelay)lvwHRRelays.SelectedItems[0].Tag;
            _ofrmHRRelayAdd.ShowDialog(oHRRelay);
            DataLoadControl();
        }

        private void frmHRRelays_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            HRRelays _oHRRelays = new HRRelays();
            lvwHRRelays.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oHRRelays.Refresh();
            this.Text = "HR Relays | Total: " + "[" + _oHRRelays.Count + "]";
            foreach (HRRelay oHRRelay in _oHRRelays)
            {
                ListViewItem oItem = lvwHRRelays.Items.Add(oHRRelay.RelayID.ToString());
                oItem.SubItems.Add(oHRRelay.RelayName);
                oItem.SubItems.Add(oHRRelay.CreateDate.ToShortDateString());
                oItem.SubItems.Add(oHRRelay.CreatedBy);
                oItem.SubItems.Add(oHRRelay.Remarks);
                oItem.Tag = oHRRelay;
            }           
        }
    }
}