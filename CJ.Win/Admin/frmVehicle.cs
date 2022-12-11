using System;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Admin;

namespace CJ.Win
{
    public partial class frmVehicle : Form
    {
       
        VehicleDrivers _oVehicleDrivers;
        Departments _oDepartments;
        Companys _oCompanys;
        Vehicle oVehicle;
        VehicleUsers _oVehicleUsers;

        Vehicles _oVendors;

        public frmVehicle()
        {
            InitializeComponent();
        }


        public void ShowDialog(Vehicle oVehicle)
        {
            this.Tag = oVehicle;
            LoadCombos();
            oVehicle.VehicleID = oVehicle.VehicleID;
            //oVehicle.Refresh();
            txtCode.Text = oVehicle.VehicleCode;
            txtName.Text = oVehicle.VehicleName;
            textRegNo.Text = oVehicle.RegistrationNo;
            dateTimePurchaseDt.Value = Convert.ToDateTime(oVehicle.PurchaseDate);
            textCostPrice.Text = oVehicle.CostPrice.ToString();
            textModel.Text = oVehicle.Model;
            textEngineNo.Text =(string)oVehicle.EngineNo;
            textChasisNo.Text =(string) oVehicle.ChasisNo;

            if (oVehicle.VehicleDriverID != -1)
                cmbDriverName.SelectedIndex = _oVehicleDrivers.GetIndex(oVehicle.VehicleDriverID);
            if (oVehicle.CompanyID != -1)
                cmbCompany.SelectedIndex = _oCompanys.GetIndex(oVehicle.CompanyID);
            if (oVehicle.DepartmentID != -1)
                cmbDepartment.SelectedIndex = _oDepartments.GetIndex(oVehicle.DepartmentID);
            cmbBusinessUnit.Text = oVehicle.BU;
            if (oVehicle.VehicleUserID != -1)
                cmbUserName.SelectedIndex = _oVehicleUsers.GetIndex(oVehicle.VehicleUserID);
            txtCapacity.Text = oVehicle.Capacity;
            
            if (oVehicle.InsuranceExpiryDate != null)
            {
                dateTimeInsExpDt.Value = Convert.ToDateTime(oVehicle.InsuranceExpiryDate);
            }
            else dateTimeInsExpDt.Value = DateTime.Today.Date;           

            if (oVehicle.RoadTaxExpiryDate != null)
            {
                dateTimeRdTxExpDate.Value = Convert.ToDateTime(oVehicle.RoadTaxExpiryDate);
            }
            else dateTimeRdTxExpDate.Value = DateTime.Today.Date;
            if (oVehicle.IsActive == 1)
            {
                cbxIsActive.Checked = true;
            }
            else
            {
                cbxIsActive.Checked = false;
            }


            Vehicle oVendor=new Vehicle();
            oVendor.GetVendorByVendorID(oVehicle.VendorID);

            cmbDeliveryMode.SelectedIndex = oVendor.DeliveryMode;
            
            //cmbVendor.SelectedIndex = oVehicle.VendorID + 1;

            cmbVendor.SelectedIndex = _oVendors.GetIndexVendor(oVehicle.VendorID)+1;

            ShowDialog();
        }

        private void frmVehicle_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Vehicle";
                LoadCombos();
            }
            else this.Text = "Edit Vehicle";
            
            
        }
        private void LoadCombos()
        {
            cmbBusinessUnit.SelectedIndex = 0;
            ////Vendor
            //cmbVendor.Items.Clear();
            //cmbVendor.Items.Add("--Select Vendor--");
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DeliveryShipmentVendor)))
            //{
            //    cmbVendor.Items.Add(Enum.GetName(typeof(Dictionary.DeliveryShipmentVendor), GetEnum));
            //}
            //cmbVendor.SelectedIndex = 0;

            //Vendor
            cmbDeliveryMode.Items.Clear();
            cmbDeliveryMode.Items.Add("Select Delivery Mode.....");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LogDeliveryShipmentDeliveryMode)))
            {
                cmbDeliveryMode.Items.Add(Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), GetEnum));
            }
            cmbDeliveryMode.SelectedIndex = 0;

            //Vendor
            _oVendors = new Vehicles();
            _oVendors.GetVendorByDeliveryMode((int)Dictionary.LogDeliveryShipmentVendorType.Direct_Vendor, 1);
            cmbVendor.Items.Clear();
            cmbVendor.Items.Add("Select Vendor.....");
            foreach (Vehicle oVendor in _oVendors)
            {
                cmbVendor.Items.Add(oVendor.VendorName);
            }
            cmbVendor.SelectedIndex = 0;

            _oVehicleDrivers =new VehicleDrivers();
            _oDepartments = new Departments();
            _oCompanys = new Companys();
            _oVehicleUsers = new VehicleUsers();


            _oVehicleDrivers.Refresh(string.Empty,string.Empty, string.Empty);
            _oDepartments.RefreshNew();
            _oCompanys.RefreshNew();
            _oVehicleUsers.Refresh();

            cmbDriverName.Items.Clear();
            cmbCompany.Items.Clear();
            cmbDepartment.Items.Clear();
            cmbUserName.Items.Clear();

            foreach (VehicleUser oVehicleUser in _oVehicleUsers)
            {
                cmbUserName.Items.Add(oVehicleUser.VehicleUserName);

            }
            if (_oVehicleUsers.Count > 0)
            {
                cmbUserName.SelectedIndex = _oVehicleUsers.Count - 1;
            }
            

            foreach (VehicleDriver oVehicleDriver in _oVehicleDrivers)
            {
                cmbDriverName.Items.Add(oVehicleDriver.VehicleDriverName);
            
            }
            if (_oVehicleDrivers.Count > 0)
            {
                cmbDriverName.SelectedIndex = _oVehicleDrivers.Count - 1;
            }

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


        private bool ValidateUiInput()
        {
            #region Input Information Validation
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of Vehicle", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name Of Vehicle", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (textRegNo.Text == "")
            {
                MessageBox.Show("Please Enter Name of Registration No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textRegNo.Focus();
                return false;
            }
            if (textCostPrice.Text == "")
            {
                MessageBox.Show("Please Enter Cost Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCostPrice.Focus();
                return false;
            }
            if (textModel.Text == "")
            {
                MessageBox.Show("Please Enter Model", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textModel.Focus();
                return false;
            }

            if (textEngineNo.Text == "")
            {
                MessageBox.Show("Please Enter EngineNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEngineNo.Focus();
                return false;
            }
            if (textChasisNo.Text == "")
            {
                MessageBox.Show("Please Enter ChasisNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textChasisNo.Focus();
                return false;
            }
            if (cmbVendor.SelectedIndex == 0)
            {
                MessageBox.Show("Please select vendor first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVendor.Focus();
                return false;
            }

            if (_oCompanys[cmbCompany.SelectedIndex].CompanyID == -1)
            {
                MessageBox.Show("Please select company first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCompany.Focus();
                return false;
            }
            if (_oDepartments[cmbDepartment.SelectedIndex].DepartmentID == -1)
            {
                MessageBox.Show("Please select department first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return false;
            }

            if (txtCapacity.Text == "")
            {
                MessageBox.Show("Please Enter Capacity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapacity.Focus();
                return false;
            }
            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUiInput())
            {
                Save();
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                Vehicle oVehicle = new Vehicle();
                oVehicle = GetVehicleData(oVehicle);
                //oVehicle.VehicleCode = txtCode.Text;
                //oVehicle.VehicleName = txtName.Text;
                //oVehicle.RegistrationNo = textRegNo.Text;                
                //oVehicle.PurchaseDate = Convert.ToDateTime(dateTimePurchaseDt.Value.Date);
                //oVehicle.CostPrice = Convert.ToDouble(textCostPrice.Text);
                //oVehicle.Model = textModel.Text;
                //oVehicle.EngineNo = textEngineNo.Text;
                //oVehicle.ChasisNo = textChasisNo.Text;
                //oVehicle.InsuranceExpiryDate = dateTimeInsExpDt.Value.Date;
                //oVehicle.RoadTaxExpiryDate = dateTimeRdTxExpDate.Value.Date;
                //if (cbxIsActive.Checked == true)
                //{
                //    oVehicle.IsActive = 1;
                //}
                //else oVehicle.IsActive = 0;


                //oVehicle.FuelTypeID = 0;

                //if (_oVehicleUsers[cmbUserName.SelectedIndex].VehicleUserID != -1)
                //    oVehicle.VehicleUserID = _oVehicleUsers[cmbUserName.SelectedIndex].VehicleUserID;
                //else oVehicle.VehicleUserID = -1;


                //if (_oVehicleDrivers[cmbDriverName.SelectedIndex].VehicleDriverID != -1)
                //    oVehicle.VehicleDriverID = _oVehicleDrivers[cmbDriverName.SelectedIndex].VehicleDriverID;
                //else oVehicle.VehicleDriverID = -1;

                //if (_oDepartments[cmbDepartment.SelectedIndex].DepartmentID != -1)
                //oVehicle.DepartmentID = _oDepartments[cmbDepartment.SelectedIndex].DepartmentID;
                //else oVehicle.DepartmentID = -1;

                //if (_oCompanys[cmbCompany.SelectedIndex].CompanyID != -1)
                //    oVehicle.CompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
                //else oVehicle.CompanyID = -1;


                //oVehicle.BU = cmbBusinessUnit.Text;
                //oVehicle.DriverName = cmbDriverName.Text;
                //oVehicle.Capacity = txtCapacity.Text;

                //if (cmbVendor.SelectedIndex != 0)
                //{
                //    oVehicle.VendorID = cmbVendor.SelectedIndex - 1;
                //}
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicle.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oVehicle.VehicleCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Vehicle oVehicle = (Vehicle) this.Tag;
                oVehicle = GetVehicleData(oVehicle);                             
                

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicle.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Vehicle : " + oVehicle.VehicleCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }


        public Vehicle GetVehicleData(Vehicle oVehicle)
        {

            oVehicle.VehicleCode = txtCode.Text;
            oVehicle.VehicleName = txtName.Text;
            oVehicle.RegistrationNo = textRegNo.Text;
            if (_oVehicleUsers[cmbUserName.SelectedIndex].VehicleUserID != -1)
                oVehicle.VehicleUserID = _oVehicleUsers[cmbUserName.SelectedIndex].VehicleUserID;
            else oVehicle.VehicleUserID = -1;
            oVehicle.PurchaseDate = Convert.ToDateTime(dateTimePurchaseDt.Value.Date);
            try
            {
                oVehicle.CostPrice = int.Parse(textCostPrice.Text);
            }
            catch
            {
                oVehicle.CostPrice = 0;
            }
            oVehicle.Model = textModel.Text;
            oVehicle.EngineNo = textEngineNo.Text;
            oVehicle.ChasisNo = textChasisNo.Text;
            oVehicle.InsuranceExpiryDate = dateTimeInsExpDt.Value.Date;
            oVehicle.RoadTaxExpiryDate = dateTimeRdTxExpDate.Value.Date;
            if (cbxIsActive.Checked == true)
            {
                oVehicle.IsActive = 1;
            }
            else oVehicle.IsActive = 0;
            if (_oVehicleDrivers[cmbDriverName.SelectedIndex].VehicleDriverID != -1)
                oVehicle.VehicleDriverID = _oVehicleDrivers[cmbDriverName.SelectedIndex].VehicleDriverID;
            else oVehicle.VehicleDriverID = -1;
            oVehicle.FuelTypeID = 0;
            if (_oDepartments[cmbDepartment.SelectedIndex].DepartmentID != -1)
                oVehicle.DepartmentID = _oDepartments[cmbDepartment.SelectedIndex].DepartmentID;
            else oVehicle.DepartmentID = -1;

            if (_oCompanys[cmbCompany.SelectedIndex].CompanyID != -1)
                oVehicle.CompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            else oVehicle.CompanyID = -1;
            oVehicle.BU = cmbBusinessUnit.Text;
            oVehicle.DriverName = cmbDriverName.Text;
            oVehicle.Capacity = txtCapacity.Text;
            
            //oVehicle.VendorID = cmbVendor.SelectedIndex - 1;
            oVehicle.VendorID= _oVendors[cmbVendor.SelectedIndex - 1].VendorID;

            return oVehicle;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDeliveryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeliveryMode.SelectedIndex == 0)
            {
                //Vehicle
                cmbVendor.Items.Clear();
                cmbVendor.Items.Add("Select Vendor.....");
                cmbVendor.SelectedIndex = 0;
                cmbParcelType.Enabled = false;

                cmbParcelType.Items.Clear();
                cmbParcelType.Items.Add("N/A.....");
                cmbParcelType.SelectedIndex = 0;
            }
            else
            {

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                //Vendor
                _oVendors = new Vehicles();
                _oVendors.GetVendorByDeliveryMode((int)Dictionary.LogDeliveryShipmentVendorType.Direct_Vendor, cmbDeliveryMode.SelectedIndex);
                cmbVendor.Items.Clear();
                cmbVendor.Items.Add("Select Vendor.....");
                foreach (Vehicle oVendor in _oVendors)
                {
                    cmbVendor.Items.Add(oVendor.VendorName);
                }
                cmbVendor.SelectedIndex = 0;

            }
            if (cmbDeliveryMode.SelectedIndex == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
            {
                cmbParcelType.Enabled = true;
                cmbParcelType.Items.Clear();
                cmbParcelType.Items.Add("Select Parcel Type.....");
                foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LogDeliveryShipmentParcelType)))
                {
                    cmbParcelType.Items.Add(Enum.GetName(typeof(Dictionary.LogDeliveryShipmentParcelType), GetEnum));
                }
                cmbParcelType.SelectedIndex = 0;
            }
            else
            {
                cmbParcelType.Items.Clear();
                cmbParcelType.Items.Add("N/A.....");
                cmbParcelType.SelectedIndex = 0;
                cmbParcelType.Enabled = false;

            }
        }
    }
}