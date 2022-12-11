using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;

namespace CJ.Win.Admin
{
    public partial class frmVehicleMaintenance : Form
    {
        double nAmount = 0;
        double nFuelTotal = 0;
        double nExpenseAmount = 0;
        double nExpenseTotal = 0;
        double nExpenseCash = 0;
        double nExpenseCredit = 0;

        int nVehicleID = 0;
        Vehicle oVehicle;

        VehicleOperation oVehicleOperation;
        VehicleExpenseHeads _oVehicleExpenseHeads;
        VehicleFuelTypes _oVehicleFuelTypes;
        VehicleExpense oVehicleExpense;
        //vehicleExpenses ovehicleExpenses;
        
        public frmVehicleMaintenance()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                save();
                Clear();
            }

        }
        private bool validateUIInput()
        {
            #region Vehicle Operation  Information Validation

            if (oVehicle == null)
            {
                MessageBox.Show("Please Select a Vehicle Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtVehicleCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Select a Vehicle Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtTripC.Text.Trim() == "")
            {
                MessageBox.Show("Please Select No of Tripc ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtTripS.Text.Trim() == "")
            {
                MessageBox.Show("Please Select No of TripS ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtTripU.Text.Trim() == "")
            {
                MessageBox.Show("Please Select No of TripU ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtEndReading.Text.Trim() == "")
            {
                MessageBox.Show("Please End Reading ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #endregion

            return true;
        }

        public void save()
        {
            int nOpID = 0;
            int nCount = 0;

            double Cash = 0;
            double Credit = 0;

            if (this.Tag == null)
            {
                oVehicleOperation = new VehicleOperation();
                oVehicleOperation = SetInput(oVehicleOperation);
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleOperation.Add();                   
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show(" You Have Successfully Save The Transaction ");

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

        }
        private void Clear()
        {
            txtVehicleCode.Text = "";
            txtVehicleDetails.Text = "";
            txtTripC.Text = "";
            txtTripS.Text = "";
            txtTripU.Text = "";
            txtEndReading.Text = "";
            //txtTotalExpAmount = "";           
            txtKmRun.Text = "";
            txtInvoiceAmount.Text = "";
            txtExpAmount.Text = "";
            ckbActive.Checked = false;
            dgvExpanse.Rows.Clear();

        }
        public VehicleOperation SetInput(VehicleOperation oVehicleOperation)
        {
            string sPaymentType = "";
            double _Cash = 0;
            double _Credit = 0;

            oVehicleOperation.VehicleID = oVehicle.VehicleID;
            oVehicleOperation.Trandate = Convert.ToDateTime(dateTimePicker1.Text);
            if (ckbActive.Checked == true)
            {
                oVehicleOperation.ActiveToday = 1;
            }
            else oVehicleOperation.ActiveToday = 0;
            oVehicleOperation.TripC = Convert.ToInt32(txtTripC.Text);
            oVehicleOperation.TripS = Convert.ToInt32(txtTripS.Text);
            oVehicleOperation.TripU = Convert.ToInt32(txtTripU.Text);
            oVehicleOperation.EndReading = Convert.ToInt32(txtEndReading.Text);
            oVehicleOperation.KMRun = Convert.ToInt32(txtKmRun.Text);
            oVehicleOperation.InvoiceAmount = Convert.ToInt32(txtInvoiceAmount.Text);

            foreach (DataGridViewRow oItemRow in dgvExpanse.Rows)
            {              

                if (oItemRow.Index < dgvExpanse.Rows.Count - 1)
                {
                     

                     try
                     {
                         _Cash = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                     }
                     catch
                     {
                         _Cash = 0;
                     }
                     try
                     {
                         _Credit = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                     }
                     catch
                     {
                         _Credit = 0;
                     }

                     //Credit = Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim());
                     if (_Cash != 0)
                     {
                         VehicleExpense oItem = new VehicleExpense();
                         try
                         {
                             oItem.ExpenseheadID = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                         }
                         catch (Exception ex)
                         {
                             oItem.ExpenseheadID = Convert.ToInt32(0);
                         }

                         try
                         {
                             oItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[1].Value.ToString().Trim());
                         }
                         catch (Exception ex)
                         {
                             oItem.UnitPrice = Convert.ToDouble(0);
                         }
                         try
                         {
                             oItem.Qty = Convert.ToDouble(oItemRow.Cells[2].Value.ToString().Trim());
                         }
                         catch (Exception ex)
                         {
                             oItem.Qty = Convert.ToDouble(0);
                         }

                         try
                         {
                             oItem.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                         }
                         catch (Exception ex)
                         {
                             oItem.Amount = Convert.ToDouble(0);
                         }
                         oItem.Remarks = (string)txtRemarks.Text;

                         if (oItem.Qty != 0)
                         {
                             oItem.PaymentType = 1;  //Cash 
                         }
                         if (oItem.Qty != 0)
                         {
                             oVehicleOperation.Add(oItem);

                         }
                         
                     }
                     if (_Credit != 0)
                     {
                         VehicleExpense oItem = new VehicleExpense();
                         try
                         {
                             oItem.ExpenseheadID = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                         }
                         catch (Exception ex)
                         {
                             oItem.ExpenseheadID = Convert.ToInt32(0);
                         }

                         try
                         {
                             oItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[1].Value.ToString().Trim());
                         }
                         catch (Exception ex)
                         {
                             oItem.UnitPrice = Convert.ToDouble(0);
                         }
                         try
                         {
                             oItem.Qty = Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim());
                         }
                         catch (Exception ex)
                         {
                             oItem.Qty = Convert.ToDouble(0);
                         }

                         try
                         {
                             oItem.Amount = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim());
                         }
                         catch (Exception ex)
                         {
                             oItem.Amount = Convert.ToDouble(0);
                         }
                         oItem.Remarks = (string)txtRemarks.Text;

                         if (oItem.Qty != 0)
                         {
                             oItem.PaymentType = 2;  //Credit 
                         }
                         if (oItem.Qty != 0)
                         {
                             oVehicleOperation.Add(oItem);
                         }

                     }                    
                }

            }
        
            return oVehicleOperation;
        }

        private void txtVehicleCode_TextChanged(object sender, EventArgs e)
        {
            RefreshVehicleName();
        }
        private void RefreshVehicleName()
        {

            try
            {
                oVehicle = new Vehicle();
                DBController.Instance.OpenNewConnection();
                oVehicle.VehicleCode = txtVehicleCode.Text; ;
                oVehicle.RefreshbyCode();
                nVehicleID = Convert.ToInt32(oVehicle.VehicleID);
                txtVehicleDetails.Text = (string)oVehicle.VehicleName;
                txtRegNo.Text = (string)oVehicle.RegistrationNo;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Fuel price Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oVehicle = null;
            }
        }

        private void txtEndReading_TextChanged(object sender, EventArgs e)
        {
            int nReading = 0;
            int nMaxReading = 0;
            int nKMRun = 0;
            try
            {
                oVehicleOperation = new VehicleOperation();
                nReading = Convert.ToInt32(txtEndReading.Text);
                DBController.Instance.OpenNewConnection();
                oVehicleOperation.VehicleID = nVehicleID;
                oVehicleOperation.GetMaxReading();
                nMaxReading = oVehicleOperation.MaxReading;
                nKMRun = nReading - nMaxReading;
                txtKmRun.Text = Convert.ToString(nKMRun);

            }
            catch
            {

            }

        }

        private void btVichel_Click(object sender, EventArgs e)
        {
            frmVehicles ofrmVehicles = new frmVehicles();
            ofrmVehicles.ShowDialog();

            if (ofrmVehicles._oVehicle != null)
            {
                txtVehicleCode.Text = ofrmVehicles._oVehicle.VehicleCode;
                txtVehicleDetails.Text = ofrmVehicles._oVehicle.VehicleName;
                txtRegNo.Text = ofrmVehicles._oVehicle.RegistrationNo;

                oVehicle = ofrmVehicles._oVehicle;
            }
            else oVehicle = null;

        }

        private void dgvExpanse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);

        }
        private void dgvExpanse_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);

        }
        
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {   
            if (nColumnIndex == 2)
            {
               if (dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex].Value != null)
                {                    
                 dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex + 1].Value = (Convert.ToDouble(dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex - 1].Value.ToString()) * Convert.ToDouble(dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()));
                 nExpenseCash =Convert.ToDouble( dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex + 1].Value);
                 nExpenseTotal = nExpenseTotal + nExpenseCash;

                }      
            }

            else if (nColumnIndex == 4)
            {
                if (dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex].Value != null)
                {
                    dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex + 1].Value = (Convert.ToDouble(dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex - 3].Value.ToString()) * Convert.ToDouble(dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()));
                    nExpenseCredit = Convert.ToDouble(dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex + 1].Value);
                    nExpenseTotal = nExpenseTotal + nExpenseCredit;

                }
            } 

            //nAmount = Convert.ToDouble(dgvExpanse.Rows[nRowIndex].Cells[nColumnIndex + 2].Value);
            //nFuelTotal = Convert.ToDouble(nFuelTotal) + Convert.ToDouble(nAmount);
            //txtFuelExpAmount.Text = Convert.ToString(nFuelTotal);
            txtExpAmount.Text =Convert.ToString(nExpenseTotal);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVehicleMaintenance_Load(object sender, EventArgs e)
        {
            gvdLoad();
        }

        public void gvdLoad()
        {
            
            // Load the Expanse Type Name         
            _oVehicleExpenseHeads = new VehicleExpenseHeads();
            DBController.Instance.OpenNewConnection();
            _oVehicleExpenseHeads.GetExpanseHeadName();

            foreach (VehicleExpenseHead oVehicleExpenseHead in _oVehicleExpenseHeads)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvExpanse);
                oRow.Cells[0].Value = oVehicleExpenseHead.ExpenseHeadName.ToString();
                oRow.Cells[1].Value = oVehicleExpenseHead.UnitPrice.ToString();
                oRow.Cells[6].Value = oVehicleExpenseHead.ExpenseHeadID;
                dgvExpanse.Rows.Add(oRow);              
                
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtTripU_TextChanged(object sender, EventArgs e)
        {

        }
    }
}