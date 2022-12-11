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

namespace CJ.Win.Ecommerce
{
    public partial class frmIPDCFileTrackingStatusHistory : Form
    {
        IPDCFileTrackingStatusHistorys oIPDCFileTrackingStatusHistorys;
        private IPDCFileTrackingStatusHistorys _oIPDCFileTrackingStatusHistorys;


        IPDCFileTracking oIPDCFileTracking;
        string _ncurrentForm;
        public bool _bActionSave = false;
        int nTrackingID = 0;

        public frmIPDCFileTrackingStatusHistory(string currentForm)
        {
            _ncurrentForm = currentForm;
            InitializeComponent();
        }

        public void ShowDialog(IPDCFileTracking oIPDCFileTracking)
        {
            nTrackingID = oIPDCFileTracking.TrackingID;
            lblInvoiceNo.Text = oIPDCFileTracking.InvoiceNo;
            lblAmt.Text = oIPDCFileTracking.InvoiceAmount.ToString();
            lblCustName.Text = oIPDCFileTracking.CustomerName;
            lblAddress.Text = oIPDCFileTracking.CustomerContact;

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIPDCFileTrackingStatusHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            oIPDCFileTrackingStatusHistorys = new IPDCFileTrackingStatusHistorys();
            lvwIPDCFileTrackingStatusHistory.Items.Clear();

            DBController.Instance.OpenNewConnection();

            oIPDCFileTrackingStatusHistorys.Refresh(nTrackingID);

            foreach (IPDCFileTrackingStatusHistory ooIPDCFileTrackingStatusHistory in oIPDCFileTrackingStatusHistorys)
            {
                ListViewItem oItem = lvwIPDCFileTrackingStatusHistory.Items.Add(ooIPDCFileTrackingStatusHistory.StatusName.ToString());
                oItem.SubItems.Add(ooIPDCFileTrackingStatusHistory.Remarks.ToString());
                oItem.SubItems.Add(ooIPDCFileTrackingStatusHistory.UserName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(ooIPDCFileTrackingStatusHistory.CreateDate).ToString("dd-MMM-yyyy"));

                oItem.Tag = ooIPDCFileTrackingStatusHistory;
            }
            this.Text = "IPDC Files-" + oIPDCFileTrackingStatusHistorys.Count + "";
            //SetListViewRowColour();
        }


    }
}
