using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Class.Admin;
using CJ.Class.Library;
using CJ.Win.Security;

namespace CJ.Win.Admin
{
    public partial class frmVehicleOperationsAdmin : Form
    {
        Vehicle oVehicle;
        public frmVehicleOperationsAdmin()
        {
            InitializeComponent();
        }

        
        private void btnGetdata_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void updateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");

            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {

                    if ("M29.11.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M29.11.2" == sPermissionKey)
                    {
                        btnDelete.Enabled = true;
                    }
                    if ("M29.11.3" == sPermissionKey)
                    {
                        btnReport.Enabled = true;
                    }
                    
                }
            }

        }

        private void frmVehicleOperationsAdmin_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            updateSecurity();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CompanyID)))
            {
                cmbCompany.Items.Add(Enum.GetName(typeof(Dictionary.CompanyID), GetEnum));
            }
            cmbCompany.SelectedIndex = 0;

            dtFrmDate.Value = DateTime.Today.AddDays(-2);
            RefreshData();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVehicleMaintenanceAdmin oForm = new frmVehicleMaintenanceAdmin();
            oForm.ShowDialog();
            RefreshData();
        }

        public void RefreshData()
        {
            
            VehicleOperationsAdmin oVehicleOperationsAdmin = new VehicleOperationsAdmin();
            lvwVehicleOperationAdmin.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            string sCompany = "";
            if (cmbCompany.SelectedIndex != 0)
            {
                sCompany = cmbCompany.Text;
            }


            oVehicleOperationsAdmin.Refresh(dtFrmDate.Value.Date, dtToDate.Value.Date, txtVehicleCode.Text, sCompany);
            TELLib oTELLib = new TELLib();
            foreach (VehicleOperationAdmin oVehicleOperationAdmin in oVehicleOperationsAdmin)
            {

                ListViewItem lstItem = lvwVehicleOperationAdmin.Items.Add(oVehicleOperationAdmin.Trandate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oVehicleOperationAdmin.VehicleCode.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.VehicleName.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.RegistrationNo.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.BU.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.Company.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.TripC.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.TripS.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.TripU.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.EndReading.ToString());
                lstItem.SubItems.Add(oVehicleOperationAdmin.KMRun.ToString());
                lstItem.SubItems.Add(oTELLib.TakaFormat(Convert.ToDouble(oVehicleOperationAdmin.InvoiceAmount)));

                lstItem.Tag = oVehicleOperationAdmin;
            }
            this.Text = "Vehicle Operation Admin [" + oVehicleOperationsAdmin.Count + "]";
        }
        public void DeteteOperation()
        {
            int nOperationID = 0;
        
            if (lvwVehicleOperationAdmin.SelectedItems.Count != 0)
            {
                VehicleOperationAdmin oVehicleOperationAdmin = (VehicleOperationAdmin)lvwVehicleOperationAdmin.SelectedItems[0].Tag;
                DialogResult oResult = MessageBox.Show("Are you sure Delete Operation Details: " + oVehicleOperationAdmin.Vehicle.VehicleCode + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        nOperationID = oVehicleOperationAdmin.VehicleOperationID;
                        oVehicleOperationAdmin.DeleteAll();
                        oVehicleOperationAdmin.RefreshAll();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Delete The Operation Details : " + oVehicleOperationAdmin.Vehicle.VehicleCode, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Please Change Status as CANCELED and Then Delete it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeteteOperation();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DeteteOperation();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmVehicleOperationReportAdmin oForm = new frmVehicleOperationReportAdmin();
            oForm.ShowDialog();
        }

        private void RefreshVehicleName()
        {

            try
            {
                oVehicle = new Vehicle();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                oVehicle.VehicleCode = txtVehicleCode.Text; ;
                oVehicle.RefreshbyCode();
                txtVehicleDetails.Text = (string)oVehicle.VehicleName;

            }
            catch (Exception ex)
            {
                oVehicle = null;
            }
        }
        private void txtVehicleCode_TextChanged(object sender, EventArgs e)
        {
            RefreshVehicleName();
        }

        private void btVichel_Click(object sender, EventArgs e)
        {
            frmVehicles ofrmVehicles = new frmVehicles();
            ofrmVehicles.ShowDialog();

            if (ofrmVehicles._oVehicle != null)
            {
                txtVehicleCode.Text = ofrmVehicles._oVehicle.VehicleCode;
                txtVehicleDetails.Text = ofrmVehicles._oVehicle.VehicleName;
                oVehicle = ofrmVehicles._oVehicle;
            }
            else oVehicle = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}