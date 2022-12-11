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

namespace CJ.Win.Admin
{
    public partial class frmVehicleOperations : Form
    {
        Vehicle oVehicle;
        public frmVehicleOperations()
        {
            InitializeComponent();
        }      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmVehicleMaintenance oForm = new frmVehicleMaintenance();
            oForm.ShowDialog();
            RefreshData();
            //DataLoadControl();
        }

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    if (lvwVehicleOperation.SelectedItems.Count != 0)
        //    {
        //        VehicleOperation oVehicleOperation = (VehicleOperation)lvwVehicleOperation.SelectedItems[0].Tag;
        //        frmVehicleOperation oForm = new frmVehicleOperation();
        //        oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //        oForm.MaximizeBox = false;
        //        oForm.ShowDialog(oVehicleOperation);
        //        RefreshData();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }

        //}

        private void frmVehicleOperations_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CompanyID)))
            {
                cmbCompany.Items.Add(Enum.GetName(typeof(Dictionary.CompanyID), GetEnum));
            }
            cmbCompany.SelectedIndex = 0;

            dtFromDate.Value = DateTime.Today.AddDays(-2);
            RefreshData();

        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {

            VehicleOperations oVehicleOperations = new VehicleOperations();
            lvwVehicleOperation.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            string sCompany = "";
            if (cmbCompany.SelectedIndex != 0)
            {
                sCompany = cmbCompany.Text;
            }

            oVehicleOperations.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtVehicleCode.Text, sCompany);
            TELLib oTELLib = new TELLib();
            foreach (VehicleOperation oVehicleOperation in oVehicleOperations)
            {
                ListViewItem lstItem = lvwVehicleOperation.Items.Add(oVehicleOperation.Trandate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oVehicleOperation.VehicleCode.ToString());
                lstItem.SubItems.Add(oVehicleOperation.VehicleName.ToString());
                lstItem.SubItems.Add(oVehicleOperation.RegistrationNo.ToString());
                lstItem.SubItems.Add(oVehicleOperation.BU.ToString());
                lstItem.SubItems.Add(oVehicleOperation.Company.ToString());
                lstItem.SubItems.Add(oVehicleOperation.TripC.ToString());
                lstItem.SubItems.Add(oVehicleOperation.TripS.ToString());
                lstItem.SubItems.Add(oVehicleOperation.TripU.ToString());
                lstItem.SubItems.Add(oVehicleOperation.EndReading.ToString());
                lstItem.SubItems.Add(oVehicleOperation.KMRun.ToString());
                lstItem.SubItems.Add(oTELLib.TakaFormat(Convert.ToDouble(oVehicleOperation.InvoiceAmount)));

                lstItem.Tag = oVehicleOperation;
            }
            
        }
        public void DeteteOperation()
        {
            int nOperationID = 0;
            //VehicleOperationDetail oVehicleOperationDetail = new VehicleOperationDetail();
           // VehicleExpense oVehicleExpense = new VehicleExpense();            
            if (lvwVehicleOperation.SelectedItems.Count != 0)
            {
                VehicleOperation oVehicleOperation = (VehicleOperation)lvwVehicleOperation.SelectedItems[0].Tag;                
                DialogResult oResult = MessageBox.Show("Are you sure Delete Operation Details: " + oVehicleOperation.Vehicle.VehicleCode + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        nOperationID = oVehicleOperation.VehicleOperationID;
                        //oVehicleOperationDetail.DeleteAll();
                        //oVehicleExpense.Delete();
                        oVehicleOperation.DeleteAll();                        
                        oVehicleOperation.RefreshAll();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Delete The Operation Details : " + oVehicleOperation.Vehicle.VehicleCode, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btndelete_Click(object sender, EventArgs e)
        {
            DeteteOperation();

        }      
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            frmVehicleOperationReport oForm = new frmVehicleOperationReport();
        
            oForm.ShowDialog();
        }

        private void lvwVehicleOperation_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}