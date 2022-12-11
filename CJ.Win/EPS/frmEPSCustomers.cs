using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using CJ.Class;
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.Library;
using CJ.Class.Web.UI.Class;

namespace CJ.Win.EPS
{
    public partial class frmEPSCustomers : Form
    {
        EPSSalesOrder _oEPSSalesOrder;
        public frmEPSCustomers()
        {
            InitializeComponent();
        }
        private void DataLoadControl()
        {


            EPSCustomers oEPSCustomers = new EPSCustomers();

            lvwEPSCustomers.Items.Clear();
            DBController.Instance.OpenNewConnection();
            if (ctlCustomer1.SelectedCustomer != null)
            {
                oEPSCustomers.Refresh(ctlCustomer1.SelectedCustomer.CustomerID, txtEPSCustomerCode.Text, txtEmployeeName.Text);
            }
            else
            {
                oEPSCustomers.Refresh(0, txtEPSCustomerCode.Text, txtEmployeeName.Text);
            }
            this.Text = "Total = " + "[" + oEPSCustomers.Count + "]";
            foreach (EPSCustomer oEPSCustomer in oEPSCustomers)
            {
                ListViewItem oItem = lvwEPSCustomers.Items.Add(oEPSCustomer.EPSCustomerCode.ToString());
                oItem.SubItems.Add(oEPSCustomer.EmployeeName);
                oItem.SubItems.Add(oEPSCustomer.PhoneNo);
                oItem.SubItems.Add(oEPSCustomer.Customer.CustomerCode);
                oItem.SubItems.Add(oEPSCustomer.Customer.CustomerName);

                oItem.Tag = oEPSCustomer;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwEPSCustomers.SelectedItems.Count != 0)
            {
                EPSCustomer oEPSCustomer = (EPSCustomer)lvwEPSCustomers.SelectedItems[0].Tag;

                frmEPSCustomer oForm = new frmEPSCustomer();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit EPS Customer";
                oForm.ShowDialog(oEPSCustomer);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwEPSCustomers_DoubleClick(object sender, EventArgs e)
        {
            if (lvwEPSCustomers.SelectedItems.Count != 0)
            {
                EPSCustomer oEPSCustomer = (EPSCustomer)lvwEPSCustomers.SelectedItems[0].Tag;

                frmEPSCustomer oForm = new frmEPSCustomer();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit EPS Customer";
                oForm.ShowDialog(oEPSCustomer);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEPSCustomer oForm = new frmEPSCustomer();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwEPSCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an EPS Customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EPSCustomer oEPSCustomer = (EPSCustomer)lvwEPSCustomers.SelectedItems[0].Tag;
            _oEPSSalesOrder = new EPSSalesOrder();
            _oEPSSalesOrder.EPSCustomerID = oEPSCustomer.EPSCustomerID;
            if (_oEPSSalesOrder.CheckEPSCustomer())
            {

                DialogResult oResult = MessageBox.Show("Are you sure you want to delete EPS Customer: " + oEPSCustomer.EPSCustomerCode + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oEPSCustomer.DeleteEPSCustomer();
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
            else
            {
                MessageBox.Show("This EPS Customer Is Not Eligible to Delete.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

    }
}





