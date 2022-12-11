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
    public partial class frmSPLocations : Form
    {
       
        public frmSPLocations()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSPLocation oForm = new frmSPLocation();
            oForm.ShowDialog();            
            if (oForm.isAnyActivityDone)
            {
                DataLoadControl();
            }
        }

        private void frmSPLocations_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {

            SparePartLocations oSparePartLocations = new SparePartLocations();

            lvwSPLocations.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oSparePartLocations.Refresh(txtLocationName.Text, txtDescription.Text);

            this.Text = "Total " + "[" + oSparePartLocations.Count + "]";
            foreach (SparePartLocation oSparePartLocation in oSparePartLocations)
            {
                ListViewItem oItem = lvwSPLocations.Items.Add(oSparePartLocation.SPLocationID.ToString());
                oItem.SubItems.Add(oSparePartLocation.LocationName.ToString());
                oItem.SubItems.Add(oSparePartLocation.Description.ToString());
                if (oSparePartLocation.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                {
                    oItem.SubItems.Add("True");
                }
                else
                {
                    oItem.SubItems.Add("False");
                }
                oItem.SubItems.Add(oSparePartLocation.User.Username.ToString());
                oItem.SubItems.Add(oSparePartLocation.CreateDate.ToString("dd-MMM-yyyy"));

                oItem.Tag = oSparePartLocation;
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSPLocations.SelectedItems.Count != 0)
            {

                SparePartLocation oSparePartLocation = (SparePartLocation)lvwSPLocations.SelectedItems[0].Tag;

                frmSPLocation oForm = new frmSPLocation();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Spare Part";
                oForm.ShowDialog(oSparePartLocation);
                if (oForm.isAnyActivityDone)
                {
                    DataLoadControl();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwSPLocations_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSPLocations.SelectedItems.Count != 0)
            {
                SparePartLocation oSparePartLocation = (SparePartLocation)lvwSPLocations.SelectedItems[0].Tag;

                frmSPLocation oForm = new frmSPLocation();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Spare Part";
                oForm.ShowDialog(oSparePartLocation);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}