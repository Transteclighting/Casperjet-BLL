using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.SupplyChain;
using CJ.Class;

namespace CJ.Win.SupplyChain
{
    public partial class frmSCMSalsePlans : Form
    {
        SCMSalesPlans _oSCMSalesPlans;
        public frmSCMSalsePlans()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmSCMSalsePlans_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oSCMSalesPlans = new SCMSalesPlans();
            lvwSCMSalesPlan.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oSCMSalesPlans.Refresh();
            this.Text = "Total SCM Sales Paln " + "[" + _oSCMSalesPlans.Count + "]";
            foreach (SCMSalesPlan oSCMSalesPlan in _oSCMSalesPlans)
            {
                ListViewItem oItem = lvwSCMSalesPlan.Items.Add(oSCMSalesPlan.SCMSalesPlanID.ToString());
                oItem.SubItems.Add(oSCMSalesPlan.PlanMonth.ToString("MMM-yyyy"));
                oItem.SubItems.Add(oSCMSalesPlan.ASGname);
                oItem.SubItems.Add(oSCMSalesPlan.Brand);
                oItem.SubItems.Add(oSCMSalesPlan.PlanQty.ToString());

                oItem.Tag = oSCMSalesPlan;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSCMSalesPlan oForm = new frmSCMSalesPlan();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSCMSalesPlan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMSalesPlan oSCMSalesPlan = (SCMSalesPlan)lvwSCMSalesPlan.SelectedItems[0].Tag;
            frmSCMSalesPlan oForm = new frmSCMSalesPlan();
            oForm.ShowDialog(oSCMSalesPlan);
            DataLoadControl();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwSCMSalesPlan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMSalesPlan oSCMSalesPlan = (SCMSalesPlan)lvwSCMSalesPlan.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Plan : " + oSCMSalesPlan.SCMSalesPlanID.ToString() + " ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    SCMSalesPlanItem oSCMSalesPlanItem = new SCMSalesPlanItem();
                    oSCMSalesPlanItem.Delete(oSCMSalesPlan.SCMSalesPlanID);
                    oSCMSalesPlan.Delete();
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
    }
}