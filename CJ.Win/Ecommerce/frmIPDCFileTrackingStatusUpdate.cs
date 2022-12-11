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
    public partial class frmIPDCFileTrackingStatusUpdate : Form
    {
        IPDCFileTracking oIPDCFileTracking;
        string _ncurrentForm;
        public bool _bActionSave = false;
        int nTrackingID = 0;

        private IPDCFileTrackingStatuss _oIPDCFileTrackingStatuss;
        public frmIPDCFileTrackingStatusUpdate(string currentForm)
        {
            _ncurrentForm = currentForm;
            InitializeComponent();
        }

        public void ShowDialog(IPDCFileTracking oIPDCFileTracking)
        {
            nTrackingID = oIPDCFileTracking.TrackingID;

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();

                _bActionSave = true;
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {

                IPDCFileTrackingStatusHistory oIPDCFileTrackingStatusHistory = new IPDCFileTrackingStatusHistory();

                IPDCFileTracking oIPDCFileTracking = new IPDCFileTracking();

                oIPDCFileTrackingStatusHistory.TrackingID = nTrackingID;
                oIPDCFileTrackingStatusHistory.Status = cmbStatus.SelectedIndex+1;
                oIPDCFileTrackingStatusHistory.Remarks = txtRemarks.Text;
                oIPDCFileTrackingStatusHistory.CreateDate = DateTime.Now.Date;
                oIPDCFileTrackingStatusHistory.CreateUserID = Utility.UserId;

                oIPDCFileTracking.TrackingID = nTrackingID;
                oIPDCFileTracking.Status = cmbStatus.SelectedIndex+1;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oIPDCFileTrackingStatusHistory.Add();

                    oIPDCFileTracking.UpdateStatus();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }



        private bool UIValidation()
        {

            if (cmbStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select A Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }


            if (txtRemarks.Text.Trim() == "")
            {
                MessageBox.Show("Please Input A Remark", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRemarks.Focus();
                return false;
            }

            return true;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIPDCFileTrackingStatusUpdate_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }


        private void LoadCombo()
        {
            _oIPDCFileTrackingStatuss = new IPDCFileTrackingStatuss();

            DBController.Instance.OpenNewConnection();

            _oIPDCFileTrackingStatuss.GetStatus();
            cmbStatus.Items.Add("-- Select a status --");
            foreach (IPDCFileTrackingStatus oIPDCFileTrackingStatus in _oIPDCFileTrackingStatuss)
            {
                cmbStatus.Items.Add(oIPDCFileTrackingStatus.StatusName);
            }
            cmbStatus.SelectedIndex = 0;
        }


    }
}
