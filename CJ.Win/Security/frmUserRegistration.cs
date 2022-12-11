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
    public partial class frmUserRegistration : Form
    {
        int nID = 0;
        string sUserName = "";
        Employee _oEmployee;
        UserRegistration _oUserRegistration;

        public frmUserRegistration()
        {
            InitializeComponent();
        }
        public void ShowDialog(UserRegistration oUserRegistration)
        {
            this.Tag = oUserRegistration;
            LoadCombo();
            nID = oUserRegistration.ID;
            sUserName = oUserRegistration.UserFullName;

            lblUserFullName.Text = sUserName;
            lblUserName.Text = oUserRegistration.UserName;
            lblMobile.Text = oUserRegistration.MobileNo;
            lblRequestDate.Text = Convert.ToDateTime(oUserRegistration.RequestDate).ToString("dd-MMM-yyyy");
            lblSIMSerial.Text = oUserRegistration.SIMSerialNo;
            lblIMEI.Text = oUserRegistration.IMEINo;
            lblVersionNo.Text = oUserRegistration.VersionNo;
            DBController.Instance.OpenNewConnection();
            _oEmployee = new Employee();
            _oEmployee.EmployeeID = oUserRegistration.EmployeeID;
            _oEmployee.Refresh();
            ctlEmployee1.txtCode.Text = _oEmployee.EmployeeCode;

            int nAPPID = 0;
            nAPPID = oUserRegistration.AndroidAppID;
            if (oUserRegistration.AndroidAppID == (int)Dictionary.AndroidAppID.All)
            {
                cmbPermittedApp.SelectedIndex = 7;
            }
            else
            {
                cmbPermittedApp.SelectedIndex = nAPPID;
            }

            if (oUserRegistration.Status == "InActive")
            {
                cmbStatus.SelectedIndex = 1;
            }
            else
            {
                cmbStatus.SelectedIndex = 0;
            }

            if (oUserRegistration.AuthenticateMode == "IMEI")
            {
                cmbAuthenticateMode.SelectedIndex = 1;
            }
            else if (oUserRegistration.AuthenticateMode == "SIMSerial")
            {
                cmbAuthenticateMode.SelectedIndex = 2;
            }
            else
            {
                cmbAuthenticateMode.SelectedIndex = 0;
            }

            this.ShowDialog();
        }
        private void LoadCombo()
        {
   

            //Permited App
            cmbPermittedApp.Items.Clear();
            cmbPermittedApp.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AndroidAppID)))
            {
                cmbPermittedApp.Items.Add(Enum.GetName(typeof(Dictionary.AndroidAppID), GetEnum));
            }
            cmbPermittedApp.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Clear();
            //cmbStatus.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AndroidAppRegStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.AndroidAppRegStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


            //Authenticate Mode
            cmbAuthenticateMode.Items.Clear();
            cmbAuthenticateMode.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AndroidAppAuthenticateMode)))
            {
                cmbAuthenticateMode.Items.Add(Enum.GetName(typeof(Dictionary.AndroidAppAuthenticateMode), GetEnum));
            }
            cmbAuthenticateMode.SelectedIndex = 0;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            if (rdoEmployee.Checked == true)
            {
                if (ctlEmployee1.txtCode.Text == "")
                {
                    MessageBox.Show("Please Select Employee Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlEmployee1.txtCode.Focus();
                    return false;

                }
            }

            if (cmbPermittedApp.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Permitted Apps Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPermittedApp.Focus();
                return false;
            }
            if (cmbAuthenticateMode.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Authenticate Mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAuthenticateMode.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                _oUserRegistration = new UserRegistration();
                _oUserRegistration.ID = nID;
                if (rdoEmployee.Checked == true)
                {
                    _oUserRegistration.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                }
                else
                {
                    _oUserRegistration.EmployeeID = -9; /// Non Employee

                }

                if (cmbPermittedApp.Text == "CJ_Apps")
                {
                    _oUserRegistration.AndroidAppID = (int)Dictionary.AndroidAppID.CJ_Apps;

                }
                else if (cmbPermittedApp.Text == "CJ_Digital")
                {
                    _oUserRegistration.AndroidAppID = (int)Dictionary.AndroidAppID.CJ_Digital;

                }
                else if (cmbPermittedApp.Text == "CJ_Lighting")
                {
                    _oUserRegistration.AndroidAppID = (int)Dictionary.AndroidAppID.CJ_Lighting;

                }
                else if (cmbPermittedApp.Text == "E_Csd")
                {
                    _oUserRegistration.AndroidAppID = (int)Dictionary.AndroidAppID.E_Csd;

                }
                else if (cmbPermittedApp.Text == "E_DMS")
                {
                    _oUserRegistration.AndroidAppID = (int)Dictionary.AndroidAppID.E_DMS;

                }
                else if (cmbPermittedApp.Text == "CJ_FieldForce")
                {
                    _oUserRegistration.AndroidAppID = (int)Dictionary.AndroidAppID.CJ_FieldForce;

                }
                else if (cmbPermittedApp.Text == "All")
                {
                    _oUserRegistration.AndroidAppID = (int)Dictionary.AndroidAppID.All;

                }

                _oUserRegistration.AuthenticateMode = cmbAuthenticateMode.Text;
                _oUserRegistration.Status = cmbStatus.Text;
                _oUserRegistration.ActivatedBy = Utility.Username;
                _oUserRegistration.ActivatedDate = DateTime.Now.Date;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oUserRegistration.Edit();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("You Have Successfully Update Apps Permission. UserName : " + sUserName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void rdoEmployee_CheckedChanged(object sender, EventArgs e)
        {
            ctlEmployee1.Enabled = true;
        }

        private void rdoNonEmployee_CheckedChanged(object sender, EventArgs e)
        {
            ctlEmployee1.txtCode.Text = "";
            ctlEmployee1.Enabled = false;
        }

        private void frmUserRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}