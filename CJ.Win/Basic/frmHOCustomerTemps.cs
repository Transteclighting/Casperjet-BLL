using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;


namespace CJ.Win.Basic
{
    public partial class frmHOCustomerTemps : Form
    {
        Customers oCustomers;
        bool IsCheck = false;
        Showrooms _oShowrooms;

        public frmHOCustomerTemps()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadCombos()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Company
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("<All>");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;

            // Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.B2BCustomerStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.B2BCustomerStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void DataLoadControl()
        {
            oCustomers = new Customers();
            lvwCustomer.Items.Clear();

            int nWarehouseID = 0;
            if (cmbShowroom.SelectedIndex == 0)
            {
                nWarehouseID = -1;
            }

            else
            {
                nWarehouseID = _oShowrooms[cmbShowroom.SelectedIndex - 1].WarehouseID;
            }

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            oCustomers.RefreshTempCustomerForHO(dtFromDate.Value.Date, dtToDate.Value.Date, txtCustomerCode.Text.Trim(), txtCustomerName.Text.Trim(), nWarehouseID, nStatus, IsCheck);
            foreach (Customer oCustomer in oCustomers)
            {
                ListViewItem lstItem = lvwCustomer.Items.Add(oCustomer.ShowroomCode.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerCode.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerName.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(oCustomer.EntryDate).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oCustomer.ContactPerson.ToString());
                lstItem.SubItems.Add(oCustomer.CellPhoneNo.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerAddress.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.B2BCustomerStatus), oCustomer.Status));

                lstItem.Tag = oCustomer;

            }
            SetListViewRowColour();
            this.Text = "Temp Customer List [" + oCustomers.Count + "]";
        }
        private void SetListViewRowColour()
        {
            if (lvwCustomer.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCustomer.Items)
                {
                    if (oItem.SubItems[7].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[7].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;

                    }
                    else if (oItem.SubItems[7].Text == "Approve_By_HO")
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

        private void frmHOCustomerTemps_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            DataLoadControl();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (lvwCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;
            if (oCustomer.Status == (int)Dictionary.B2BCustomerStatus.Create)
            {
                frmCustomer oForm = new frmCustomer(3);
                oForm.ShowDialog(oCustomer);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}