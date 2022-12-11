
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmInterService : Form
    {
        GeoLocations _oThanas;     
        GeoLocations _oDistricts;
        GeoLocation _oDistrict;

        public frmInterService()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //District
            _oDistricts = new GeoLocations();
            _oDistricts.RefreshDistrict();
            cmbDistrict.Items.Clear();
            foreach (GeoLocation oGeoLocation in _oDistricts)
            {
                cmbDistrict.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbDistrict.Items.Add("Select District");
            cmbDistrict.SelectedIndex = _oDistricts.Count;

            //Is Active
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCommunicationStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.InquiryCommunicationStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = 1;
            //InterService Category
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InterServiceCategory)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.InterServiceCategory), GetEnum));
            }
            cmbCategory.SelectedIndex = 0;
            //InterService Grade
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InterServiceGrade)))
            {
                cmbGrade.Items.Add(Enum.GetName(typeof(Dictionary.InterServiceGrade), GetEnum));
            }
            cmbGrade.SelectedIndex = 0;
        }
        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistrict.Text != "Select District")
            {
                //Thana
                _oThanas = new GeoLocations();
                _oThanas.GetThana(_oDistricts[cmbDistrict.SelectedIndex].GeoLocationID);
                cmbThana.Items.Clear();
                foreach (GeoLocation oGeoLocation in _oThanas)
                {
                    cmbThana.Items.Add(oGeoLocation.GeoLocationName);
                }
                if (_oThanas.Count > 0) cmbThana.SelectedIndex = 0;
            }
            else
            {
                cmbThana.Items.Clear();
            }
        }
        public void ShowDialog(InterServiceR oInterServiceR)
        {
            this.Tag = oInterServiceR;
            LoadCombos();

            txtCode.Text=oInterServiceR.Code;
            txtName.Text=oInterServiceR.Name;
            txtAddress.Text=oInterServiceR.Address;
            txtMobileNo.Text=oInterServiceR.Mobile;
            txtPhone.Text=oInterServiceR.Phone;
            txtEmail.Text=oInterServiceR.Email;
            txtContactPerson.Text=oInterServiceR.ContactPerson;
            cmbCategory.SelectedIndex = oInterServiceR.Category - 1;
            cmbGrade.SelectedIndex = oInterServiceR.Grade - 1;
            cmbIsActive.SelectedIndex=oInterServiceR.IsActive;

                _oDistrict = new GeoLocation();
                _oDistrict.GeoLocationID = oInterServiceR.ThanaID;
                _oDistrict.GetParentID(_oDistrict.GeoLocationID);

                cmbDistrict.SelectedIndex = _oDistricts.GetIndexByID(_oDistrict.ParentID);
                cmbDistrict_SelectedIndexChanged(null, null);
                cmbThana.SelectedIndex = _oThanas.GetIndexByID(oInterServiceR.ThanaID);
          

            txtRemarks.Text=oInterServiceR.Remarks;
            txtCode.Enabled = false;
          
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Inter service Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Inter Service Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtMobileNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Mobile No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
            }
            if (txtMobileNo.Text.Trim().Length != 11)
            {
                MessageBox.Show("Please enter Valid Mobile No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
            }
            if (txtContactPerson.Text == "")
            {
                MessageBox.Show("Please enter Contact Person Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactPerson.Focus();
                return false;
            }
            if (cmbThana.Text == "")
            {
                MessageBox.Show("Please enter Thana", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbThana.Focus();
                return false;
            }

            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                InterServiceR oInterServiceR = new InterServiceR();
                oInterServiceR.Code = txtCode.Text;
                oInterServiceR.Name = txtName.Text;
                oInterServiceR.Address = txtAddress.Text;
                oInterServiceR.Mobile = txtMobileNo.Text;
                oInterServiceR.Phone = txtPhone.Text;
                oInterServiceR.Email = txtEmail.Text;
                oInterServiceR.ContactPerson = txtContactPerson.Text;
                oInterServiceR.Category = cmbCategory.SelectedIndex +1;
                oInterServiceR.Grade = cmbGrade.SelectedIndex + 1 ;
                oInterServiceR.IsActive = cmbIsActive.SelectedIndex;

                GeoLocation oGeoLocation=_oThanas[cmbThana.SelectedIndex];
                oInterServiceR.ThanaID = oGeoLocation.GeoLocationID;
                oInterServiceR.Remarks = txtRemarks.Text;
                
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oInterServiceR.CheckInterServiceCode())
                    {

                        oInterServiceR.Add();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  
                    }
                    else
                    {
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //return;
                    }

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                InterServiceR oInterServiceR = (InterServiceR)this.Tag;
                
                {
                    oInterServiceR.Code = txtCode.Text;
                    oInterServiceR.Name = txtName.Text;
                    oInterServiceR.Address = txtAddress.Text;
                    oInterServiceR.Mobile = txtMobileNo.Text;
                    oInterServiceR.Phone = txtPhone.Text;
                    oInterServiceR.Email = txtEmail.Text;
                    oInterServiceR.ContactPerson = txtContactPerson.Text;
                    oInterServiceR.Category = cmbCategory.SelectedIndex + 1;
                    oInterServiceR.Grade = cmbGrade.SelectedIndex + 1;
                    oInterServiceR.IsActive = cmbIsActive.SelectedIndex;
                    GeoLocation oGeoLocation = _oThanas[cmbThana.SelectedIndex];
                    oInterServiceR.ThanaID = oGeoLocation.GeoLocationID;
                    oInterServiceR.Remarks = txtRemarks.Text;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        oInterServiceR.Edit();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();
                        
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInterService_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            else
            { 
            }
        }

    }
        
}