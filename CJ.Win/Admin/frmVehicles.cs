using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmVehicles : Form
    {
        public Vehicle _oVehicle;
        Vehicle oVehicle;
               
        Departments _oDepartments;
        Companys _oCompanys;


        public frmVehicles()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            cmbBusinessUnit.SelectedIndex = 0;

            _oDepartments = new Departments();
            _oCompanys = new Companys();
            _oDepartments.Refresh();
            _oCompanys.Refresh();
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            if (_oDepartments.Count > 0)
            {
                cmbDepartment.SelectedIndex = _oDepartments.Count - 1;
            }
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            if (_oCompanys.Count > 0)
            {
                cmbCompany.SelectedIndex = _oCompanys.Count - 1;
            }

        }
        private void frmVehicles_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void DataLoadControl()
        {
            Vehicles oVehicles = new Vehicles();
            lvwVehicles.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oVehicles.RefreshAll(txtCode.Text.Trim(), txtName.Text.Trim(), txtRegistrationNo.Text.Trim(), _oCompanys[cmbCompany.SelectedIndex].CompanyID, _oDepartments[cmbDepartment.SelectedIndex].DepartmentID, cmbBusinessUnit.Text);
            this.Text = "Vehicle " + "[" + oVehicles.Count + "]";
            foreach (Vehicle oVehicle in oVehicles)
            {
                ListViewItem oItem = lvwVehicles.Items.Add(oVehicle.VehicleCode);
                oItem.SubItems.Add(oVehicle.VehicleName);
                oItem.SubItems.Add(oVehicle.RegistrationNo);
                oItem.SubItems.Add(oVehicle.PurchaseDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oVehicle.CostPrice.ToString("#,##,##,##.00"));
                oItem.SubItems.Add(oVehicle.BU);
                oItem.SubItems.Add(oVehicle.Company);
                oItem.SubItems.Add(oVehicle.Department);
                oItem.SubItems.Add(oVehicle.DriverName);

                oItem.SubItems.Add(oVehicle.RegistrationNo);


                oItem.Tag = oVehicle;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVehicle oForm = new frmVehicle();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwVehicles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Vehicle to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Vehicle oVehicle = (Vehicle)lvwVehicles.SelectedItems[0].Tag;
            frmVehicle oForm = new frmVehicle();
            oForm.ShowDialog(oVehicle);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Vehicles oVehicles = new Vehicles();
            //oVehicles.Refresh();
            //rptVehicles oReport = new rptVehicles();
            //oReport.SetDataSource(oVehicles);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwVehicles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Vehicle to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Vehicle oVehicle = (Vehicle)lvwVehicles.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Vehicle: " + oVehicle.VehicleCode + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicle.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwVehicles_DoubleClick(object sender, EventArgs e)
        {
            _oVehicle = (Vehicle)lvwVehicles.SelectedItems[0].Tag;
            this.Close();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void RefreshVehicleName()
        {
            try
            {
                oVehicle = new Vehicle();
                DBController.Instance.OpenNewConnection();
                oVehicle.VehicleCode = txtCode.Text;
                oVehicle.RefreshbyCode();
                txtName.Text = (string)oVehicle.VehicleName;
            }
            catch (Exception ex)
            {
                oVehicle = null;
            }
        }


    }
}