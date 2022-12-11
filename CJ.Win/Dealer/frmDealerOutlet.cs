using System;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Dealer
{
    public partial class frmDealerOutlet : Form
    {
        public frmDealerOutlet()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUiInput())
            {
                Save();
                Close();
            }
        }
        public void ShowDialog(DealerOutlet oDealerOutlet)
        {
            btnSave.Text = "Edit";
            ctlCustomer1.txtCode.Text = oDealerOutlet.CustomerCode;        
            txtOutletName.Text = oDealerOutlet.OutletName;
            rtbAddress.Text = oDealerOutlet.Address;
            txtContactPerson.Text = oDealerOutlet.ContactPerson;
            txtContactNo.Text = oDealerOutlet.ContactNo;
            txtEmail.Text = oDealerOutlet.Email;
            Tag = oDealerOutlet;
            ShowDialog();
        }
        private void Save()
        {
            if (Tag == null)
            {
                DealerOutlet oDealerOutlet = new DealerOutlet
                {
                    CustomerID = ctlCustomer1.SelectedCustomer.CustomerID,
                    OutletName = txtOutletName.Text.Trim(),
                    Address = rtbAddress.Text.Trim(),
                    ContactPerson = txtContactPerson.Text.Trim(),
                    ContactNo = txtContactNo.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    CreateUserID = Utility.UserId,
                    CreateDate = DateTime.Now
                };
                if (chkIsActive.Checked)
                {
                    oDealerOutlet.IsActive = (int) Dictionary.IsActive.Active;
                }
                else
                {
                    oDealerOutlet.IsActive = (int) Dictionary.IsActive.InActive;
                }

                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oDealerOutlet.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show(@"You Have Successfully Create A Outlet", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                DealerOutlet oDealerOutlet = (DealerOutlet) Tag;
                oDealerOutlet.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oDealerOutlet.OutletName = txtOutletName.Text.Trim();
                oDealerOutlet.Address = rtbAddress.Text.Trim();
                oDealerOutlet.ContactPerson = txtContactPerson.Text.Trim();
                oDealerOutlet.ContactNo = txtContactNo.Text.Trim();
                oDealerOutlet.Email = txtEmail.Text.Trim();
                oDealerOutlet.UpdateUserId = Utility.UserId;
                oDealerOutlet.UpdateDate = DateTime.Now;
                if (chkIsActive.Checked)
                {
                    oDealerOutlet.IsActive = (int) Dictionary.IsActive.Active;
                }
                else
                {
                    oDealerOutlet.IsActive = (int) Dictionary.IsActive.InActive;
                }


                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oDealerOutlet.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Edit Information of Outlet", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private bool ValidateUiInput()
        {
            if (ctlCustomer1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Select Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            if (txtOutletName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Outlet Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOutletName.Focus();
                return false;
            }
            if (txtContactPerson.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Contact Person of Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactPerson.Focus();
                return false;
            }
            if (rtbAddress.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Address of Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbAddress.Focus();
                return false;
            }
            if (txtContactNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Contact no. Of Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return false;
            }
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Email Of Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }


            return true;
        }

        private void frmDealerOutlet_Load(object sender, EventArgs e)
        {
            chkIsActive.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctlCustomer1_Load(object sender, EventArgs e)
        {

        }

        private void frmDealerOutlet_Click(object sender, EventArgs e)
        {
            if (ctlCustomer1.SelectedCustomer != null 
                && txtOutletName.Text.Trim() == string.Empty
                && rtbAddress.Text.Trim() == string.Empty
                && txtContactNo.Text.Trim() == string.Empty
                && txtContactPerson.Text.Trim() == string.Empty)
            {
                txtOutletName.Text = ctlCustomer1.SelectedCustomer.CustomerName;
                rtbAddress.Text = ctlCustomer1.SelectedCustomer.CustomerAddress;
                txtContactNo.Text = ctlCustomer1.SelectedCustomer.CustomerTelephone;
                txtContactPerson.Text = ctlCustomer1.SelectedCustomer.ContactPerson;
            }
        }
    }
}