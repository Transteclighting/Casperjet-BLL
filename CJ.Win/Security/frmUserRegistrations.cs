using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Security
{
    public partial class frmUserRegistrations : Form
    {
        bool IsCheck = false;
        UserRegistrations _oUserRegistrations;
        UserRegistration _oUserRegistration;

        public frmUserRegistrations()
        {
            InitializeComponent();
        }

        private void frmUserRegistrations_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;


            //Permited App
            cmbPermitedApp.Items.Clear();
            cmbPermitedApp.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AndroidAppID)))
            {
                cmbPermitedApp.Items.Add(Enum.GetName(typeof(Dictionary.AndroidAppID), GetEnum));
            }
            cmbPermitedApp.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AndroidAppRegStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.AndroidAppRegStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


        }
        private void DataLoadControl()
        {
            _oUserRegistrations = new UserRegistrations();
            lvwUserRegistrations.Items.Clear();

            int nAndroidAppID = 0;
            if (cmbPermitedApp.Text == "--All--")
            {
                nAndroidAppID = -1;
            }
            else if (cmbPermitedApp.Text == "All")
            {
                nAndroidAppID = (int)Dictionary.AndroidAppID.All;
            }
            else
            {
                nAndroidAppID = cmbPermitedApp.SelectedIndex;
            }

            int nEmployeeID = 0;
            try
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            catch
            {
                nEmployeeID = 0;
            }
            DBController.Instance.OpenNewConnection();

            _oUserRegistrations.RefreshData(dtFromdate.Value.Date, dtTodate.Value.Date, txtUserName.Text.Trim(), txtMobileName.Text.Trim(), nAndroidAppID, cmbStatus.Text, IsCheck, nEmployeeID);
            DBController.Instance.CloseConnection();

            foreach (UserRegistration oUserRegistration in _oUserRegistrations)
            {
                ListViewItem oItem = lvwUserRegistrations.Items.Add(oUserRegistration.UserFullName.ToString());
                oItem.SubItems.Add(oUserRegistration.UserName.ToString());
                oItem.SubItems.Add(oUserRegistration.MobileNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oUserRegistration.RequestDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oUserRegistration.IMEINo.ToString());
                oItem.SubItems.Add(oUserRegistration.SIMSerialNo.ToString());
                oItem.SubItems.Add(oUserRegistration.VersionNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.AndroidAppID), oUserRegistration.AndroidAppID));
                oItem.SubItems.Add(oUserRegistration.AuthenticateMode.ToString());
                oItem.SubItems.Add(oUserRegistration.ActivatedBy.ToString());
                oItem.SubItems.Add(oUserRegistration.EmployeeName.ToString());
                oItem.SubItems.Add(oUserRegistration.Status.ToString());
                oItem.Tag = oUserRegistration;
            }
            this.Text = "Android Apps User Registration" + "(" + _oUserRegistrations.Count + ")";
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (lvwUserRegistrations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserRegistration oUserRegistration = (UserRegistration)lvwUserRegistrations.SelectedItems[0].Tag;
            frmUserRegistration oForm = new frmUserRegistration();
            oForm.ShowDialog(oUserRegistration);
            DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwUserRegistrations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserRegistration oUserRegistration = (UserRegistration)lvwUserRegistrations.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete. User Name: " + oUserRegistration.UserFullName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    _oUserRegistration = new UserRegistration();

                    DBController.Instance.BeginNewTransaction();
                    _oUserRegistration.ID = oUserRegistration.ID;
                    _oUserRegistration.Delete();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void lvwUserRegistrations_DoubleClick(object sender, EventArgs e)
        {
            btnAction_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}