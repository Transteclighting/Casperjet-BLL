// <summary>
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
    public partial class frmGeoLocations : Form
    {

        GeoLocations _oGeoLocations;
        GeoLocation _oGeoLocation;
        int _nUIControl = 0;
        public frmGeoLocations(int nUIControl)
        {
            InitializeComponent();
            _oGeoLocations = new GeoLocations();
            _oGeoLocation = new GeoLocation();
            _nUIControl = nUIControl;

        }

        private void lblDataType_Click(object sender, EventArgs e)
        {

        }

        private void frmGeoLocations_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            lvwGeoLocations.Items.Clear();
            DBController.Instance.OpenNewConnection();


            _oGeoLocations.Refresh(_nUIControl);
            if (_nUIControl == 2)
            {
                this.Text = "Thana " + "[" + _oGeoLocations.Count + "]";
                lvwGeoLocations.Columns.Add("District", 80);
            }
            else
            {
                this.Text = "District " + "[" + _oGeoLocations.Count + "]";
            }
            //this.Text = "Department " + "[" + _oDepartments.Count + "]";
            foreach (GeoLocation oGeoLocation in _oGeoLocations)
            {
                ListViewItem oItem = lvwGeoLocations.Items.Add(oGeoLocation.GeoLocationCode);
                oItem.SubItems.Add(oGeoLocation.GeoLocationName);
               // oItem.SubItems.Add(oGeoLocation.GeoLocationCategory.ToString());
                if (_nUIControl == 2)
                {
                    oItem.SubItems.Add(oGeoLocation.ParentDistrict.GeoLocationName);
                    
                }
                oItem.Tag = oGeoLocation;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmGeoLocation ofrmGeoLocation = new frmGeoLocation(_nUIControl);
            ofrmGeoLocation.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwGeoLocations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an GeoLocation Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oGeoLocation = (GeoLocation)lvwGeoLocations.SelectedItems[0].Tag;
            frmGeoLocation ofrmGeoLocation = new frmGeoLocation(_nUIControl);
            ofrmGeoLocation.ShowDialog(_oGeoLocation);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwGeoLocations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Geo Location to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oGeoLocation = (GeoLocation)lvwGeoLocations.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Geo Location : " + _oGeoLocation.GeoLocationCode + " ? ", "Confirm Geo Location Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oGeoLocation.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
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
    }
}