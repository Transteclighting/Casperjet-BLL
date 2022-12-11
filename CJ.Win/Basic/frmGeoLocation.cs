// <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana
// Date: May 5, 2014
// Description: Forms for Add/Edit of District/Thana.
// Modify Person And Date:
// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmGeoLocation : Form
    {
        GeoLocation _oGeoLocation;
        GeoLocations _oGeoLocations;
        private int _nGeoLocation;

        public frmGeoLocation(int  nGeoLocation)
        {
            _oGeoLocation = new GeoLocation();
            _oGeoLocations = new GeoLocations();
            _nGeoLocation = nGeoLocation;
            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                _oGeoLocation.GeoLocationCode = txtCode.Text;
                _oGeoLocation.GeoLocationName = txtDesc.Text;

                if (cmbType.SelectedIndex  == (int)Dictionary.GeoLocationType.District)
                {
                    _oGeoLocation.GeoLocationType = cmbType.SelectedIndex + 1;
                    _oGeoLocation.ParentID = -1;
                    _oGeoLocation.GeoLocationCategory = "-1";

                }
                else
                {
                    _oGeoLocation.GeoLocationType = 2;
                    _oGeoLocation.ParentID = cmbParent.SelectedIndex;
                    _oGeoLocation.GeoLocationCategory = cmbCategory.SelectedItem.ToString();
                }



               

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oGeoLocation.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oGeoLocation.GeoLocationID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                _oGeoLocation = (GeoLocation)this.Tag;
                _oGeoLocation.GeoLocationCode = txtCode.Text;
                _oGeoLocation.GeoLocationName = txtDesc.Text;

                if (cmbType.SelectedIndex  == (int)Dictionary.GeoLocationType.District)
                {
                    _oGeoLocation.GeoLocationType = 2;
                    _oGeoLocation.ParentID = -1;
                    _oGeoLocation.GeoLocationCategory = "-1";
                }
                else
                {
                    _oGeoLocation.GeoLocationType = 2 ;
                    _oGeoLocation.ParentID = _oGeoLocations[cmbParent.SelectedIndex].GeoLocationID;
                    _oGeoLocation.GeoLocationCategory =cmbCategory.SelectedItem.ToString();
                         
                }



            

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oGeoLocation.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The GeoLocation : " + _oGeoLocation.GeoLocationName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private bool IsValidate()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter GeoLocation Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtDesc.Text == "")
            {
                MessageBox.Show("Please enter GeoLocation Description.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }
            return true;
        }

        private void frmGeoLocation_Load(object sender, EventArgs e)
        {

            if (_nGeoLocation == 1)
            {
                if (this.Tag == null) this.Text = "Add New District";
                else this.Text = "Edit District";

                cmbType.Items.Add(Dictionary.GeoLocationType.District);
                cmbType.SelectedIndex = 0;
                lblCategory.Visible = false;
                cmbCategory.Visible = false;
                cmbParent.Visible = false;
                lblParent.Visible = false;
            }
            else
            {
                if (this.Tag == null) this.Text = "Add New Thana";
                else this.Text = "Edit Thana";
                cmbType.Items.Add(Dictionary.GeoLocationType.Thana);
                cmbType.SelectedIndex = 0;
                lblCategory.Visible = true;
                cmbCategory.Visible = true;
                cmbParent.Visible = true;
                lblParent.Visible = true;


                
            }

            if (this.Tag == null)
            {
                LoadCombo();
            }

        }
        private void LoadCombo()
        {

            cmbParent.Items.Clear();
            _oGeoLocations.RefreshDistrict();

            foreach (GeoLocation oGeoLocation in _oGeoLocations)
            {
                cmbParent.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbParent.SelectedIndex = 0;

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ThanaCategory)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.ThanaCategory), GetEnum));
            }
            cmbCategory.SelectedIndex = 0;



        }




      


        public void ShowDialog(GeoLocation oGeoLocation)
        {
            this.Tag = oGeoLocation;
            LoadCombo();

            txtCode.Text = oGeoLocation.GeoLocationCode;
            txtDesc.Text = oGeoLocation.GeoLocationName;
            int nGeolocationType = oGeoLocation.GeoLocationType ;
           
            if (nGeolocationType == 2)
            {
                cmbParent.Visible = true;
                cmbParent.SelectedIndex = _oGeoLocations.GetIndexByID(oGeoLocation.ParentID);
                cmbType.Items.Add(Dictionary.GeoLocationType.Thana);
            }
            else
            {
                cmbParent.SelectedIndex = _oGeoLocations.GetIndexByID(oGeoLocation.ParentID) + 1;
            }


            cmbCategory.SelectedItem = oGeoLocation.GeoLocationCategory + 1;

            this.ShowDialog();
        }

       

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
    }
}