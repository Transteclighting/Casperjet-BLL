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
    public partial class frmBEILDistributionSets : Form 
    {
        private MapERPBEILHRDistributionSets _oMapERPBEILHRDistributionSets;
        private MapERPBEILHRDistributionSet oMapERPBEILHRDistributionSet;
        MapERPHRAccpacCJAllowanceIDs _oMapERPHRAccpacCJAllowanceIDs;
        int nID = 0;
        public frmBEILDistributionSets()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            _oMapERPBEILHRDistributionSets = new MapERPBEILHRDistributionSets();
            lvwBEILdistributionSet.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nAccpacAllowanceID = 0;
            if (cmbAllowanceType.SelectedIndex > 0) nAccpacAllowanceID = _oMapERPHRAccpacCJAllowanceIDs[cmbAllowanceType.SelectedIndex - 1].AccpacAllowanceID;

            _oMapERPBEILHRDistributionSets.RefreshByBEILDistributionSet(nAccpacAllowanceID,txtCode.Text.Trim(),txtDistSet.Text.Trim());
            this.Text = "Total" + "[" + _oMapERPBEILHRDistributionSets.Count + "]";

            foreach (MapERPBEILHRDistributionSet oBlldistributionSet in _oMapERPBEILHRDistributionSets)
            {
                ListViewItem oItem = lvwBEILdistributionSet.Items.Add(oBlldistributionSet.CompanyName);
                oItem.SubItems.Add(oBlldistributionSet.DistributionCode);
                oItem.SubItems.Add(oBlldistributionSet.DistributionSet);
                oItem.SubItems.Add(oBlldistributionSet.DistributionDescription);
                oItem.SubItems.Add(oBlldistributionSet.Department);
                oItem.SubItems.Add(oBlldistributionSet.AllowanceType);
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TechnicianBlockStatus), oBlldistributionSet.Status));

                oItem.Tag = oBlldistributionSet;
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmBEILDistributionSets_Load(object sender, EventArgs e)
        {
            //LoadData();
            LoadCombos();
        }
        private void LoadCombos()
        {
           _oMapERPHRAccpacCJAllowanceIDs = new MapERPHRAccpacCJAllowanceIDs();
            _oMapERPHRAccpacCJAllowanceIDs.RefreshByBEILDistSet();
            cmbAllowanceType.Items.Clear();
            cmbAllowanceType.Items.Add("ALL");
            foreach (MapERPHRAccpacCJAllowanceID oMapERPHRAccpacCJAllowanceID in _oMapERPHRAccpacCJAllowanceIDs)
            {
                cmbAllowanceType.Items.Add(oMapERPHRAccpacCJAllowanceID.Description);
            }

            cmbAllowanceType.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBEILDistributionSet frmBEILdistributionset = new frmBEILDistributionSet();
            frmBEILdistributionset.ShowDialog();
            if (frmBEILdistributionset._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBEILdistributionSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MapERPBEILHRDistributionSet oMapERPBEILHRDistributionSet = (MapERPBEILHRDistributionSet)lvwBEILdistributionSet.SelectedItems[0].Tag;
            frmBEILDistributionSet ofrmBEILDistributionSet = new frmBEILDistributionSet();
            ofrmBEILDistributionSet.ShowDialog(oMapERPBEILHRDistributionSet);
            if (ofrmBEILDistributionSet._bActionSave)
                LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
