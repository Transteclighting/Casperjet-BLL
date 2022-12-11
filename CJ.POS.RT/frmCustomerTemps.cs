using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmCustomerTemps : Form
    {
        bool IsCheck = false;


        public frmCustomerTemps()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerTemp oFrom = new frmCustomerTemp();
            oFrom.ShowDialog();
            DataLoadControl();

        }
        private void DataLoadControl()
        {
            Customers oCustomers = new Customers();
            lvwCustomer.Items.Clear();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oCustomers.RefreshTempCustomerRT(dtFromDate.Value.Date, dtToDate.Value.Date, txtCustCode.Text.Trim(), txtCustomerName.Text.Trim(), IsCheck, Utility.WarehouseID);
            foreach (Customer oCustomer in oCustomers)
            {
                ListViewItem lstItem = lvwCustomer.Items.Add(oCustomer.CustomerCode.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerName.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(oCustomer.EntryDate).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oCustomer.ContactPerson.ToString());
                lstItem.SubItems.Add(oCustomer.CellPhoneNo.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerAddress.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.B2BCustomerStatus), oCustomer.Status));

                lstItem.Tag = oCustomer;

            }
            SetListViewRowColour();
            this.Text = "B2B Customer List [" + oCustomers.Count + "]";
        }
        private void SetListViewRowColour()
        {
            if (lvwCustomer.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCustomer.Items)
                {
                    if (oItem.SubItems[6].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[6].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;

                    }
                    else if (oItem.SubItems[6].Text == "Approve_By_HO")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else
                    {
                        oItem.BackColor = Color.Red;
                    }

                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (lvwCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;
            if (oCustomer.Status == (int)Dictionary.B2BCustomerStatus.Create)
            {
                frmCustomerTemp oForm = new frmCustomerTemp();
                oForm.ShowDialog(oCustomer);
                if (oForm._IsTrue)
                    DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;

            if (oCustomer.Status == (int)Dictionary.B2BCustomerStatus.Create)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to Delete Customer: " + oCustomer.CustomerName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        //Delete 
                        oCustomer.DeleteTempCustomerRT();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("You Cannot Delete this Data", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerTemps_Load(object sender, EventArgs e)
        {
            TELLib _oTELLib = new TELLib();
            dtFromDate.Value = _oTELLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;
            DataLoadControl();
        }
    }
}