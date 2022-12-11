using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmJobLocations : Form
    {
        JobLocations _oJobLocations;
        public frmJobLocations()
        {
            InitializeComponent();
        }

        private void frmJobLocations_Load(object sender, EventArgs e)
        {
            LoadCombos();
           // DataLoadControl();
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //Location
            _oJobLocations = new JobLocations();
            _oJobLocations.JobLocationType();
            cmbType.Items.Clear();
            cmbType.Items.Add("<All>");
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cmbType.Items.Add(oJobLocation.TypeName);
            }
            cmbType.SelectedIndex = 0;


        }
        private void DataLoadControl()
        {
            JobLocations oJobLocations = new JobLocations();
            lvwJobLocations.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nType = 0;
            if (cmbType.SelectedIndex == 0)
            {
                nType = -1;
            }
            else
            {
                nType = _oJobLocations[cmbType.SelectedIndex - 1].TypeID;
            }
            oJobLocations.Getdata(txtCode.Text, txtName.Text, txtDescription.Text, nType);
            this.Text = "JobLocation " + "[" + oJobLocations.Count + "]";
            foreach (JobLocation oJobLocation in oJobLocations)
            {
                ListViewItem oItem = lvwJobLocations.Items.Add(oJobLocation.JobLocationCode);
                oItem.SubItems.Add(oJobLocation.JobLocationName);
                oItem.SubItems.Add(oJobLocation.Description);
                oItem.SubItems.Add(oJobLocation.TypeName);
                oItem.SubItems.Add(oJobLocation.Sort.ToString());

                oItem.Tag = oJobLocation;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmJobLocation oForm = new frmJobLocation();
            oForm.ShowDialog();
            if (oForm._isSet == true)
                DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwJobLocations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an JobLocation to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JobLocation oJobLocation = (JobLocation)lvwJobLocations.SelectedItems[0].Tag;
            frmJobLocation oForm = new frmJobLocation();
            oForm.ShowDialog(oJobLocation);
            if (oForm._isSet == true)
                DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //JobLocations oJobLocations = new JobLocations();
            //oJobLocations.Refresh();
            //rptJobLocations oReport = new rptJobLocations();
            //oReport.SetDataSource(oJobLocations);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwJobLocations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an JobLocation to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JobLocation oJobLocation = (JobLocation)lvwJobLocations.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete JobLocation: " + oJobLocation.JobLocationCode  + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oJobLocation.Delete();
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}