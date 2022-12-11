using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win
{
    public partial class frmSearchThana : Form
    {
        private GeoLocation _oGeoLocation;

        public frmSearchThana()
        {
            InitializeComponent();
        }

        private void frmThanSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {

            GeoLocations oGeoLocations = new GeoLocations();

            lvwThanaSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oGeoLocations.RefreshForSearch(txtThanaCode.Text, txtThana.Text, txtDistrict.Text);

            this.Text = "Total = " + "[" + oGeoLocations.Count + "]";
            foreach (GeoLocation oGeoLocation in oGeoLocations)
            {
                ListViewItem oItem = lvwThanaSearch.Items.Add(oGeoLocation.GeoLocationCode.ToString());
                oItem.SubItems.Add(oGeoLocation.GeoLocationName);
                oItem.SubItems.Add(oGeoLocation.DistrictCode);
                oItem.SubItems.Add(oGeoLocation.DistrictName);

                oItem.Tag = oGeoLocation;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwThanaSearch_DoubleClick(object sender, EventArgs e)
        {

            GeoLocation oGeoLocation = (GeoLocation)lvwThanaSearch.SelectedItems[0].Tag;

            _oGeoLocation.GeoLocationCode =oGeoLocation.GeoLocationCode;
            _oGeoLocation.GeoLocationName =oGeoLocation.GeoLocationName;
            _oGeoLocation.DistrictName =oGeoLocation.DistrictName;
            this.Close();
        }

        private void lvwThanaSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            GeoLocation oGeoLocation = (GeoLocation)lvwThanaSearch.SelectedItems[0].Tag;

            _oGeoLocation.GeoLocationCode = oGeoLocation.GeoLocationCode;
            _oGeoLocation.GeoLocationName = oGeoLocation.GeoLocationName;
            _oGeoLocation.DistrictName = oGeoLocation.DistrictName;
            this.Close();
        }

        public bool ShowDialog(GeoLocation oGeoLocation)
        {
            _oGeoLocation = oGeoLocation;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void txtThanaCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtThana_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtDistrict_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }

}