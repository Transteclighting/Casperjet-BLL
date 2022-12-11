using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Store
{
    public partial class frmServiceCharges : Form
    {
         
        public frmServiceCharges()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmServiceCharge oForm = new frmServiceCharge();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void frmServiceCharges_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            CSDServiceCharges oCSDServiceCharges = new CSDServiceCharges();
            lvwServiceCharges.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oCSDServiceCharges.Refresh();

            this.Text = "CSD Service Charge | Total: " + "[" + oCSDServiceCharges.Count + "]";
            foreach (CSDServiceCharge oCSDServiceCharge in oCSDServiceCharges)
            {
                ListViewItem oItem = lvwServiceCharges.Items.Add(oCSDServiceCharge.ServiceChargeCode.ToString());
                oItem.SubItems.Add(oCSDServiceCharge.ServiceChargeName.ToString());
                oItem.Tag = oCSDServiceCharge;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {            
            if (lvwServiceCharges.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Update Service Charge", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            CSDServiceCharge oCSDServiceCharge = (CSDServiceCharge)lvwServiceCharges.SelectedItems[0].Tag;
            frmServiceCharge oForm = new frmServiceCharge();
            oForm.ShowDialog(oCSDServiceCharge);

            DataLoadControl();
        }      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteServiceCharge();
            DataLoadControl();
            
        }
        private void DeleteServiceCharge()
        {
            DialogResult oResult = MessageBox.Show("Are You Sure to Delete Service Charge?", "Delete Service Charge", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                CSDServiceCharge oCSDServiceCharge = (CSDServiceCharge)lvwServiceCharges.SelectedItems[0].Tag;
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCSDServiceCharge.Delete();
                    DBController.Instance.CommitTransaction();
                    DBController.Instance.CloseConnection();
                    MessageBox.Show("You Have Successfully Delete Service Charge ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnUpdateCharge_Click(object sender, EventArgs e)
        {
            if (lvwServiceCharges.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Update Service Charge", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           CSDServiceCharge oCSDServiceCharge = (CSDServiceCharge)lvwServiceCharges.SelectedItems[0].Tag;
            frmServiceChargeCustomer oForm = new frmServiceChargeCustomer();
            oForm.ShowDialog(oCSDServiceCharge);
            DataLoadControl();
        }
    }
}