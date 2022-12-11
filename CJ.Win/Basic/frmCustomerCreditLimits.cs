using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Win.Basic
{
    public partial class frmCustomerCreditLimits : Form
        {

        CustomerCreditLimit oCustomerCreditLimit;
        CustomerCreditLimits oCustomerCreditLimits;
        CustomerDetail _oCustomerDetail;

        public frmCustomerCreditLimits()
        {
            InitializeComponent();
        }

        private void frmCustomerCreditLimits_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (lvwCustCreditLimit.SelectedItems.Count != 0)
            {
                CustomerCreditLimit oCustomerCreditLimit = (CustomerCreditLimit)lvwCustCreditLimit.SelectedItems[0].Tag;                
                frmCustomerCreditLimit oFrom = new frmCustomerCreditLimit();
                oFrom.ShowDialog(oCustomerCreditLimit);
                DataLoadControl();
              
            }
            else
            {
                //frmCustomerCreditLimit oFrom = new frmCustomerCreditLimit();
                //oFrom.ShowDialog();
                //DataLoadControl();

                MessageBox.Show(" No Customer Selected ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.Focus();

                
            //    frmCustomerCreditLimit oFrom = new frmCustomerCreditLimit();
            //    oFrom.ShowDialog();
            //    //DataLoadControl();
            }
            
            
        }

        private void DataLoadControlCustomer()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        private void DataLoadControl()
        {           

            CustomerCreditLimits oCustomerCreditLimits = new CustomerCreditLimits();
            {
                lvwCustCreditLimit.Items.Clear();
                DBController.Instance.OpenNewConnection();
                if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text=="")
                {                    
                    //oCustomerCreditLimits.RefreshAll(0);
                    oCustomerCreditLimits.RefreshforCLimit(0);
                }
               // else oCustomerCreditLimits.RefreshAll(ctlCustomer1.SelectedCustomer.CustomerID);
                else oCustomerCreditLimits.RefreshforCLimit(ctlCustomer1.SelectedCustomer.CustomerID);

                this.Text = " Customer Credit Limit " + "[" + oCustomerCreditLimits.Count + "]";
                foreach (CustomerCreditLimit oCustomerCreditLimit in oCustomerCreditLimits)
                {
                    ListViewItem oItem = lvwCustCreditLimit.Items.Add( oCustomerCreditLimit.CustomerID.ToString());
                    oItem.SubItems.Add(oCustomerCreditLimit.CustomerCode);
                    oItem.SubItems.Add(oCustomerCreditLimit.CustomerName);
                    oItem.SubItems.Add(oCustomerCreditLimit.CreatedDate.ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oCustomerCreditLimit.LimitExpiryDate.ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oCustomerCreditLimit.MinCreditLimit.ToString("#,##,##,##"));
                    oItem.SubItems.Add(oCustomerCreditLimit.MaxCreditLimit.ToString("#,##,##,##"));
                    oItem.SubItems.Add(oCustomerCreditLimit.ChannelDescription.ToString());
                    oItem.SubItems.Add(oCustomerCreditLimit.Currentbalance.ToString());
                    
                    oItem.Tag = oCustomerCreditLimit;

                }            
            }
        }
       

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ( lvwCustCreditLimit.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Customer to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CustomerCreditLimit oCustomerCreditLimit = (CustomerCreditLimit)lvwCustCreditLimit.SelectedItems[0].Tag;
            frmCustomerCreditLimit oForm = new frmCustomerCreditLimit();
            oForm.ShowDialog(oCustomerCreditLimit);            
            DataLoadControl();

                     
                       
        }

        private void lvwCustCreditLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //oCustomerCreditLimit = (CustomerCreditLimit)lvwCustCreditLimit.SelectedItems[0].Tag;
            
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {            
           

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwCustCreditLimit.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Customer to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CustomerCreditLimit oCustomerCreditLimit = (CustomerCreditLimit)lvwCustCreditLimit.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure to delete Customer Credit Limit : " + oCustomerCreditLimit.CustomerName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCustomerCreditLimit.Delete();                    
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