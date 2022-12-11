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
    public partial class frmDesignations : Form
    {
        public frmDesignations()
        {
            InitializeComponent();
        }

        private void frmDesignations_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }
        private void LoadCombos()
        {
            //Employee Status
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("<ALL>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsActive)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.IsActive), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;

        }


        private void DataLoadControl()
        {
            Designations oDesignations = new Designations();
            lvwDesignations.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }

            oDesignations.GetData(txtCode.Text, txtName.Text, nIsActive);
            this.Text = "Designation " + "[" + oDesignations.Count + "]";
            foreach (Designation oDesignation in oDesignations)
            {
                ListViewItem oItem = lvwDesignations.Items.Add(oDesignation.DesignationCode);
                oItem.SubItems.Add(oDesignation.DesignationName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oDesignation.IsActive));

                oItem.Tag = oDesignation;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDesignation oForm = new frmDesignation();
            oForm.ShowDialog();
            if (oForm._IsTrue == true)
                DataLoadControl();


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDesignations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Designation to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Designation oDesignation = (Designation)lvwDesignations.SelectedItems[0].Tag;
            frmDesignation oForm = new frmDesignation();
            oForm.ShowDialog(oDesignation);
            if (oForm._IsTrue == true)
                DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Designations oDesignations = new Designations();
            //oDesignations.Refresh();
            //rptDesignations oReport = new rptDesignations();
            //oReport.SetDataSource(oDesignations);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwDesignations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Designation to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Designation oDesignation = (Designation)lvwDesignations.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Designation: " + oDesignation.DesignationCode + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDesignation.Delete();
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