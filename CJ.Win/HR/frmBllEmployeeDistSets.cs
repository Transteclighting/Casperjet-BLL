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
    public partial class frmBllEmployeeDistSets : Form
    {

        private MapERPHREmployeeDistributionSets _oMapERPHREmployeeDistributionSets;
        private MapERPHREmployeeDistributionSet _oMapERPHREmployeeDistributionSet;
        public frmBllEmployeeDistSets()
        {
            InitializeComponent();
        }

        private void frmBllEmployeeDistSets_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lvwBllEmployeeDistSet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            _oMapERPHREmployeeDistributionSets = new MapERPHREmployeeDistributionSets();

            int nEmployeeID = 0;
            if (ctlEmployee1.txtCode.Text == "")
            {
                nEmployeeID = -1;
            }
            else
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }

            lvwBllEmployeeDistSet.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oMapERPHREmployeeDistributionSets.RefreshByBllEmployeeDistSet(nEmployeeID,txtDistSet.Text.Trim());
            this.Text = "Serviceable Product/Item Groups (including Charges)" + "[" + _oMapERPHREmployeeDistributionSets.Count + "]";

            foreach (MapERPHREmployeeDistributionSet oBlldistributionSet in _oMapERPHREmployeeDistributionSets)
            {
                ListViewItem oItem = lvwBllEmployeeDistSet.Items.Add(oBlldistributionSet.CompanyName);
                oItem.SubItems.Add(oBlldistributionSet.EmployeeName);
                oItem.SubItems.Add(oBlldistributionSet.DistributionSet);
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TechnicianBlockStatus), oBlldistributionSet.Status));


                oItem.Tag = oBlldistributionSet;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBllEmployeeDistSet frmBllEmployeedistset = new frmBllEmployeeDistSet();
            frmBllEmployeedistset.ShowDialog();
            if (frmBllEmployeedistset._bActionSave)
                LoadData();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBllEmployeeDistSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MapERPHREmployeeDistributionSet oBllEmployeedistSet = (MapERPHREmployeeDistributionSet)lvwBllEmployeeDistSet.SelectedItems[0].Tag;
            frmBllEmployeeDistSet ofrmBllEmployeedistset = new frmBllEmployeeDistSet();
            ofrmBllEmployeedistset.ShowDialog(oBllEmployeedistSet);
            if (ofrmBllEmployeedistset._bActionSave)
                LoadData();
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwBllEmployeeDistSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MapERPHREmployeeDistributionSet oBllEmployeedistSet = (MapERPHREmployeeDistributionSet)lvwBllEmployeeDistSet.SelectedItems[0].Tag;
            frmBllEmployeeDistSet ofrmBllEmployeedistset = new frmBllEmployeeDistSet();
            ofrmBllEmployeedistset.ShowDialog(oBllEmployeedistSet);
            if (ofrmBllEmployeedistset._bActionSave)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtDistSet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
