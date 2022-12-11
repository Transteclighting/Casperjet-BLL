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
    public partial class frmBlldistributionsets : Form
    {
        private BlldistributionSets _oBlldistributionSets;
        private BlldistributionSet _oBlldistributionSet;
        public frmBlldistributionsets()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            _oBlldistributionSets = new BlldistributionSets();
            lvwBlldistributionSet.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oBlldistributionSets.RefreshByBllDistributionSet(txtCode.Text.Trim(),txtDistSet.Text.Trim());
            //DBController.Instance.CloseConnection();
            this.Text = "Total" + "[" + _oBlldistributionSets.Count + "]";

            foreach (BlldistributionSet oBlldistributionSet in _oBlldistributionSets)
            {
                ListViewItem oItem = lvwBlldistributionSet.Items.Add(oBlldistributionSet.CompanyName);
                oItem.SubItems.Add(oBlldistributionSet.DistributionSet);
                oItem.SubItems.Add(oBlldistributionSet.DepartmentCode);
                oItem.SubItems.Add(oBlldistributionSet.ASG);
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TechnicianBlockStatus), oBlldistributionSet.Status));

                oItem.Tag = oBlldistributionSet;
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBlldistributionset frmBlldistributionset = new frmBlldistributionset();
            frmBlldistributionset.ShowDialog();
            if(frmBlldistributionset._bActionSave)
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBlldistributionSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BlldistributionSet oBlldistributionSet = (BlldistributionSet)lvwBlldistributionSet.SelectedItems[0].Tag;
                frmBlldistributionset ofrmBlldistributionset = new frmBlldistributionset();
                ofrmBlldistributionset.ShowDialog(oBlldistributionSet);
            if (ofrmBlldistributionset._bActionSave)
                LoadData();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBlldistributionsets_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
