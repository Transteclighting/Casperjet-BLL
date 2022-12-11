using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;

namespace CJ.Win.HR
{
    public partial class frmMAPProductGroups : Form
    {
        MapProductGroup oMapProductGroup;
        MapProductGroups oMapProductGroups;

        public frmMAPProductGroups()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMAPProductGroup oFrom = new frmMAPProductGroup();
            oFrom.ShowDialog();
            DataLoadControl();
        }
        public void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();

            cmbMAPEmployeeType.Items.Clear();
            cmbMAPEmployeeType.Items.Add("<All>");
            // EMPType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MapEmployeeType)))
            {
                cmbMAPEmployeeType.Items.Add(Enum.GetName(typeof(Dictionary.MapEmployeeType), GetEnum));
            }
            cmbMAPEmployeeType.SelectedIndex = 0;

            cmbMAPGroupType.Items.Clear();
            cmbMAPGroupType.Items.Add("<All>");
            // DataType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MapGroupType)))
            {
                cmbMAPGroupType.Items.Add(Enum.GetName(typeof(Dictionary.MapGroupType), GetEnum));
            }
            cmbMAPGroupType.SelectedIndex = 0;

        }
        private void DataLoadControl()
        {
            oMapProductGroups = new MapProductGroups();
            lvwMAPProductGroup.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nEmployeeType = 0;
            if (cmbMAPEmployeeType.SelectedIndex == 0)
            {
                nEmployeeType = -1;
            }
            else
            {
                nEmployeeType = cmbMAPEmployeeType.SelectedIndex;
            }

            int nGroupType = 0;
            if (cmbMAPGroupType.SelectedIndex == 0)
            {
                nGroupType = -1;
            }
            else
            {
                nGroupType = cmbMAPGroupType.SelectedIndex;
            }

            int nEmployeeID = 0;
            if (ctlEmployee.txtCode.Text == "")
            {
                nEmployeeID = -1;
            }
            else
            {
                nEmployeeID = ctlEmployee.SelectedEmployee.EmployeeID;
            }

            oMapProductGroups.GetData(nEmployeeType, nGroupType, nEmployeeID);

            this.Text = "MAP Employees  " + "[" + oMapProductGroups.Count + "]";

            foreach (MapProductGroup oMapProductGroup in oMapProductGroups)
            {
                ListViewItem oItem = lvwMAPProductGroup.Items.Add(oMapProductGroup.ID.ToString());
                oItem.SubItems.Add(oMapProductGroup.EmployeeName);
                oItem.SubItems.Add(oMapProductGroup.DesignationName);
                oItem.SubItems.Add(oMapProductGroup.MAPEmployeeTypeName);
                oItem.SubItems.Add(oMapProductGroup.MAPGroupTypeName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oMapProductGroup.IsActive));
                oItem.Tag = oMapProductGroup;
            }
        }

        private void frmMAPProductGroups_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void cmbMAPEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void cmbMAPGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void ctlEmployee_Load(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwMAPProductGroup.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MapProductGroup oMapProductGroup = (MapProductGroup)lvwMAPProductGroup.SelectedItems[0].Tag;

            frmMAPProductGroup oForm = new frmMAPProductGroup();
            oForm.ShowDialog(oMapProductGroup);
            DataLoadControl();
        }

        private void ctlEmployee_ChangeSelection(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwMAPProductGroup.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MapProductGroup oMapProductGroup = (MapProductGroup)lvwMAPProductGroup.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete this Data. Employee Name: " + oMapProductGroup.EmployeeName + " ? ", "Confirm MarketGroup Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapProductGroup.Delete();
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
    }
}