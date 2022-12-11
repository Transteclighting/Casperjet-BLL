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
    public partial class frmIPDCFileTracking : Form
    {

        IPDCFileTrackings oIPDCFileTrackings;
        private IPDCFileTrackings _oIPDCFileTrackings;

        IPDCFileTracking oIPDCFileTracking;
        string _ncurrentForm;
        public bool _bActionSave = false;

        public frmIPDCFileTracking(string currentForm)
        {
            _ncurrentForm = currentForm;
            InitializeComponent();
            dtFromDate.Value = DateTime.Today.AddDays(-7);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        public void ShowDialog(IPDCFileTracking oIPDCFileTracking)
        {
            this.ShowDialog();
        }

        private void LoadData()
        {
            oIPDCFileTrackings = new IPDCFileTrackings();
            lvwIPDCFileTracking.Items.Clear();

            DBController.Instance.OpenNewConnection();

            oIPDCFileTrackings.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtInvoiceNo.Text);

            foreach (IPDCFileTracking ooIPDCFileTracking in oIPDCFileTrackings)
            {
                ListViewItem oItem = lvwIPDCFileTracking.Items.Add(ooIPDCFileTracking.InvoiceNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(ooIPDCFileTracking.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(ooIPDCFileTracking.InvoiceAmount.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.CustomerName.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.CustomerContact.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.MobileNo.ToString());
                oItem.SubItems.Add(ooIPDCFileTracking.Remarks.ToString());

                oItem.Tag = ooIPDCFileTracking;
            }
            this.Text = "IPDC Files-" + oIPDCFileTrackings.Count + "";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _bActionSave = true;
            this.Close();

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (lvwIPDCFileTracking.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IPDCFileTracking _oIPDCFileTracking = (IPDCFileTracking)lvwIPDCFileTracking.SelectedItems[0].Tag;


            string currentForm = "Add";

            frmIPDCFileTrackingAdd ofrmIPDCFileTrackingAdd = new frmIPDCFileTrackingAdd(currentForm);
            ofrmIPDCFileTrackingAdd.ShowDialog(_oIPDCFileTracking);
            if (ofrmIPDCFileTrackingAdd._bActionSave)
                LoadData();
        }

        private void frmIPDCFileTracking_Load(object sender, EventArgs e)
        {

        }

        private void frmIPDCFileTracking_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bActionSave = true;
            LoadData();
        }
    }
}
