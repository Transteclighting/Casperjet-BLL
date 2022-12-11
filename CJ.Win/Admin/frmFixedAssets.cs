using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.Admin;
using CJ.Class;
using CJ.Win.Admin;

namespace CJ.Win
{
    public partial class frmFixedAssets : Form
    {
        FixedAssets oFixedAssets;
        FixedAssetHistory oFixedAssetHistory;

        public frmFixedAssets()
        {
            InitializeComponent();
        }
        private void frmFixedAssets_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = dtFromDate.Value.Date.AddDays(-30);
            RefreshData();
        }
        private void btGetData_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            oFixedAssets = new FixedAssets();
            DBController.Instance.OpenNewConnection();
            oFixedAssets.Refresh(dtFromDate.Value, dtToDate.Value, txtFANo.Text, txtSerial.Text);
            lvwAssetList.Items.Clear();

            foreach (FixedAsset oFixedAsset in oFixedAssets)
            {
                ListViewItem oItem = lvwAssetList.Items.Add(oFixedAsset.FANo);
                oItem.SubItems.Add(oFixedAsset.SerialNo);
                oItem.SubItems.Add(oFixedAsset.FixedAssetType.FATypeName);
                oItem.SubItems.Add(oFixedAsset.Company.CompanyName);

                if (oFixedAsset.DepartmentID != -1)
                    oItem.SubItems.Add(oFixedAsset.Department.DepartmentName);
                else oItem.SubItems.Add("NA");
                if (oFixedAsset.EmployeeID != -1)
                    oItem.SubItems.Add(oFixedAsset.Employee.EmployeeName);
                else oItem.SubItems.Add("NA");

                oItem.SubItems.Add(oFixedAsset.JobLocation.JobLocationName);

                oItem.Tag = oFixedAsset;
            }
            this.Text = "Fixed Asset " + "[" + oFixedAssets.Count + "]";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFixedAsset ofrmFixedAsset = new frmFixedAsset();
            ofrmFixedAsset.ShowDialog();
            RefreshData();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (lvwAssetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Asset to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FixedAsset oFixedAsset = (FixedAsset)lvwAssetList.SelectedItems[0].Tag;
            frmFixedAsset ofrmFixedAsset = new frmFixedAsset();
            ofrmFixedAsset.ShowDialog(oFixedAsset);
            RefreshData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvwAssetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Type to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FixedAsset oFixedAsset = (FixedAsset)lvwAssetList.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Asset: " + oFixedAsset.FANo + " ? ", "Confirm Asset Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oFixedAssetHistory = new FixedAssetHistory();
                    oFixedAssetHistory.FAID = oFixedAsset.FAID;
                    oFixedAssetHistory.Delete();
                    oFixedAsset.Delete();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Delete The Asset", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
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