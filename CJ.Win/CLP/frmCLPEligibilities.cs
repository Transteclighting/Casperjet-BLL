using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CLP;
using CJ.Class;

namespace CJ.Win.CLP
{
    public partial class frmCLPEligibilities : Form
    {
        CLPEligibilities oCLPEligibilities;

        public frmCLPEligibilities()
        {
            InitializeComponent();
        }

        private void frmCLPEligibilities_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            oCLPEligibilities = new CLPEligibilities();
            oCLPEligibilities.Refresh();

            lvwEligibilityList.Items.Clear();

            foreach (CLPEligibility oCLPEligibility in oCLPEligibilities)
            {
                ListViewItem lstItem = lvwEligibilityList.Items.Add((Convert.ToDateTime(oCLPEligibility.EffectDate)).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oCLPEligibility.Amount.ToString());
                lstItem.SubItems.Add((Convert.ToDateTime(oCLPEligibility.CreatedDate)).ToString("dd-MMM-yyyy"));

                lstItem.Tag = oCLPEligibility;
            }
            this.Text = "Eligibility " + "[" + oCLPEligibilities.Count + "]";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCLPEligibility ofrmCLPEligibility = new frmCLPEligibility();
            ofrmCLPEligibility.ShowDialog();
            LoadData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvwEligibilityList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CLPEligibility oCLPEligibility = (CLPEligibility)lvwEligibilityList.SelectedItems[0].Tag;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oCLPEligibility.Delete();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Delete Data", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
            
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}