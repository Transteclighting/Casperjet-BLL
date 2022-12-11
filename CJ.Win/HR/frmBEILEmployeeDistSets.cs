using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmBEILEmployeeDistSets : Form
    {

        private MapERPBEILHREmployeeDistributionSets _oMapERPBEILHREmployeeDistributionSets;
        private MapERPBEILHREmployeeDistributionSet _oMapERPBEILHREmployeeDistributionSet;

        public frmBEILEmployeeDistSets()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            _oMapERPBEILHREmployeeDistributionSets = new MapERPBEILHREmployeeDistributionSets();

            string nEmployeeCode = null;
            if (ctlEmployee1.txtCode.Text == "")
            {
                nEmployeeCode = null;
            }
            else
            {
                nEmployeeCode = ctlEmployee1.SelectedEmployee.EmployeeCode;
            }

            lvwBEILEmployeeDistSet.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oMapERPBEILHREmployeeDistributionSets.RefreshByBEILEmployeeDistSet(nEmployeeCode, txtDistSet.Text.Trim());
            this.Text = "Serviceable Product/Item Groups (including Charges)" + "[" + _oMapERPBEILHREmployeeDistributionSets.Count + "]";

            foreach (MapERPBEILHREmployeeDistributionSet oBEIldistributionSet in _oMapERPBEILHREmployeeDistributionSets)
            {
                ListViewItem oItem = lvwBEILEmployeeDistSet.Items.Add(oBEIldistributionSet.EmployeeName);
                oItem.SubItems.Add(oBEIldistributionSet.EmplDeptCode);
                oItem.SubItems.Add(oBEIldistributionSet.DistributionSet);
                oItem.SubItems.Add(oBEIldistributionSet.DistributionSetDescription);
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TechnicianBlockStatus), oBlldistributionSet.Status));

                oItem.Tag = oBEIldistributionSet;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBEILEmployeeDistSet frmBEILEmployeedistset = new frmBEILEmployeeDistSet();
            frmBEILEmployeedistset.ShowDialog();
            if (frmBEILEmployeedistset._bActionSave)
                LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBEILEmployeeDistSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MapERPBEILHREmployeeDistributionSet oBEILEmployeedistSet = (MapERPBEILHREmployeeDistributionSet)lvwBEILEmployeeDistSet.SelectedItems[0].Tag;
            frmBEILEmployeeDistSet ofrmBEILEmployeedistset = new frmBEILEmployeeDistSet();
            ofrmBEILEmployeedistset.ShowDialog(oBEILEmployeedistSet);
            if (ofrmBEILEmployeedistset._bActionSave)
                LoadData();
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwBEILEmployeeDistSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MapERPBEILHREmployeeDistributionSet oBEILEmployeedistSet = (MapERPBEILHREmployeeDistributionSet)lvwBEILEmployeeDistSet.SelectedItems[0].Tag;
            frmBEILEmployeeDistSet ofrmBEILEmployeedistset = new frmBEILEmployeeDistSet();
            ofrmBEILEmployeedistset.ShowDialog(oBEILEmployeedistSet);
            if (ofrmBEILEmployeedistset._bActionSave)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBEILEmployeeDistSets_Load(object sender, EventArgs e)
        {
            //LoadData();
        }
    }
}
