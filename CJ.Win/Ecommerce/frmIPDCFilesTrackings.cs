using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Win.Security;

namespace CJ.Win.Ecommerce
{
    public partial class frmIPDCFilesTrackings : Form
    {

        IPDCFileTrackings oIPDCFileTrackings;
        private IPDCFileTrackings _oIPDCFileTrackings;
        bool IsCheck = false;
        private IPDCFileTrackingStatuss _oIPDCFileTrackingStatuss;

        public frmIPDCFilesTrackings()
        {
            InitializeComponent();
            dtFromDate.Value = DateTime.Today.AddDays(-7);
        }

        private void IPDCFilesTrackings_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            _oIPDCFileTrackingStatuss = new IPDCFileTrackingStatuss();

            DBController.Instance.OpenNewConnection();

            _oIPDCFileTrackingStatuss.GetAllStatus();
            cmbStatus.Items.Add("-- All --");
            foreach (IPDCFileTrackingStatus oIPDCFileTrackingStatus in _oIPDCFileTrackingStatuss)
            {
                cmbStatus.Items.Add(oIPDCFileTrackingStatus.StatusName);
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string currentForm = "Add";

            frmIPDCFileTracking ofrmIPDCFileTracking = new frmIPDCFileTracking(currentForm);
            ofrmIPDCFileTracking.ShowDialog();
            if (ofrmIPDCFileTracking._bActionSave)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            oIPDCFileTrackings = new IPDCFileTrackings();
            lvwIPDCFilesTrackings.Items.Clear();

            DBController.Instance.OpenNewConnection();

            oIPDCFileTrackings.GetIPDCFileTrackingData(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck, txtInvoiceNo.Text, cmbStatus.SelectedIndex);

            foreach (IPDCFileTracking ooIPDCFileTracking in oIPDCFileTrackings)
            {
                ListViewItem oItem = lvwIPDCFilesTrackings.Items.Add(ooIPDCFileTracking.InvoiceNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(ooIPDCFileTracking.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(ooIPDCFileTracking.InvoiceAmount.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.ReferenceNo.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.Description.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.CustomerName.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.CustomerContact.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.Remarks.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.StatusName.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.TrackingID.ToString());

                oItem.Tag = ooIPDCFileTracking;
            }
            this.Text = "IPDC Files-" + oIPDCFileTrackings.Count + "";
            //SetListViewRowColour();
        }


       private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (lvwIPDCFilesTrackings.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IPDCFileTracking _oIPDCFileTracking = (IPDCFileTracking)lvwIPDCFilesTrackings.SelectedItems[0].Tag;


            string currentForm = "Status Update";

            frmIPDCFileTrackingStatusUpdate ofrmIPDCFileTrackingStatusUpdate = new frmIPDCFileTrackingStatusUpdate(currentForm);
            ofrmIPDCFileTrackingStatusUpdate.ShowDialog(_oIPDCFileTracking);
            if (ofrmIPDCFileTrackingStatusUpdate._bActionSave)
                LoadData();
        }

        private void btnStatusHistory_Click(object sender, EventArgs e)
        {
            if (lvwIPDCFilesTrackings.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IPDCFileTracking _oIPDCFileTracking = (IPDCFileTracking)lvwIPDCFilesTrackings.SelectedItems[0].Tag;


            string currentForm = "Status History";

            frmIPDCFileTrackingStatusHistory ofrmIPDCFileTrackingStatusHistory = new frmIPDCFileTrackingStatusHistory(currentForm);
            ofrmIPDCFileTrackingStatusHistory.ShowDialog(_oIPDCFileTracking);
            if (ofrmIPDCFileTrackingStatusHistory._bActionSave)
                LoadData();
        }
    }
}
