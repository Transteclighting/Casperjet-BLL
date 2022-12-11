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
    public partial class frmWorkshopLocations : Form
    {
        public frmWorkshopLocations()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {

            WorkshopLocations oWorkshopLocations = new WorkshopLocations();

            lvwWSLocations.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oWorkshopLocations.Refresh();

            this.Text = "Total " + "[" + oWorkshopLocations.Count + "]";
            foreach (WorkshopLocation oWorkshopLocation in oWorkshopLocations)
            {
                ListViewItem oItem = lvwWSLocations.Items.Add(oWorkshopLocation.WorkshopLocationID.ToString());
                oItem.SubItems.Add(oWorkshopLocation.Name.ToString());
                oItem.SubItems.Add(oWorkshopLocation.User.Username.ToString());
                oItem.SubItems.Add(oWorkshopLocation.CreateDate.ToString());

                oItem.Tag = oWorkshopLocation;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {

            frmWorkshopLocation oForm = new frmWorkshopLocation();
            oForm.ShowDialog();
            DataLoadControl();
        
        }

        private void frmWSLocations_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwWSLocations.SelectedItems.Count != 0)
            {

                WorkshopLocation oWorkshopLocation = (WorkshopLocation)lvwWSLocations.SelectedItems[0].Tag;
                
                frmWorkshopLocation oForm = new frmWorkshopLocation();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Workshop Location Name";
                oForm.ShowDialog(oWorkshopLocation);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwWSLocations_DoubleClick(object sender, EventArgs e)
        {
            if (lvwWSLocations.SelectedItems.Count != 0)
            {
                WorkshopLocation oWorkshopLocation = (WorkshopLocation)lvwWSLocations.SelectedItems[0].Tag;

                frmWorkshopLocation oForm = new frmWorkshopLocation();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Workshop Location Name";
                oForm.ShowDialog(oWorkshopLocation);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        
    }
}