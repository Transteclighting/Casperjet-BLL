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
    public partial class frmIPDCFileTrackingAdd : Form
    {
        IPDCFileTracking oIPDCFileTracking;
        string _ncurrentForm;
        public bool _bActionSave = false;
        int nInvoiceID = 0;

        public frmIPDCFileTrackingAdd(string currentForm)
        {
            _ncurrentForm = currentForm;
            InitializeComponent();
        }

        public void ShowDialog(IPDCFileTracking oIPDCFileTracking)
        {
            nInvoiceID = oIPDCFileTracking.InvoiceID;
            lblInvoiceNo.Text = oIPDCFileTracking.InvoiceNo;
            //lblInvoiceDate.Text = oIPDCFileTracking.InvoiceDate.ToShortDateString();
            lblAmt.Text = oIPDCFileTracking.InvoiceAmount.ToString();
            lblCustName.Text = oIPDCFileTracking.CustomerName;
            lblAddress.Text = oIPDCFileTracking.CustomerContact;
            lblMobileNo.Text = oIPDCFileTracking.MobileNo;

            this.ShowDialog();
        }


        private void frmIPDCFileTrackingAdd_Load(object sender, EventArgs e)
        {

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

                IPDCFileTracking oIPDCFileTracking = new IPDCFileTracking();

                oIPDCFileTracking.InvoiceID = nInvoiceID;
                oIPDCFileTracking.ReferenceNo = txtRefNo.Text;
                oIPDCFileTracking.Description = txtDescription.Text;
                oIPDCFileTracking.Remarks = txtRemarks.Text;
                oIPDCFileTracking.CreateDate = DateTime.Now.Date;
                oIPDCFileTracking.CreateUserID = Utility.UserId;
                oIPDCFileTracking.Status = 1;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oIPDCFileTracking.Add();

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

            if (txtRefNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Reference No", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRefNo.Focus();
                return false;
            }


            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Description", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                return false;
            }


            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
