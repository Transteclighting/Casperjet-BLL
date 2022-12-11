using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmCustomerVarifications : Form
    {
        Customer _oCustomer;
        Customers _oCustomers;
        Channels oChannels;
        int nCustomerID;

        public frmCustomerVarifications()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            //dtFromdate.Value = DateTime.Today;
            //dtTodate.Value = DateTime.Today;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All Status--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CustomerVerificationStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.CustomerVerificationStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        
        }
        private void SetListViewRowColour()
        {
            if (lvwCustomer.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCustomer.Items)
                {
                    if (oItem.SubItems[6].Text == "NotVerified")
                    {
                        oItem.BackColor = Color.LightPink;
                    }
                    else
                    {
                        oItem.BackColor = Color.Transparent;
                    }

                }
            }
        }

        private void LoadData()
        {
            Customers oCustomers = new Customers();
            lvwCustomer.Items.Clear();
            int nCustType = 0;
            if (Utility.CompanyInfo == "TEL")
            {
                nCustType = 249;    ///TEL B2B
            }
            else if (Utility.CompanyInfo == "TML")
            {
                nCustType = 202;    ///TML B2B & Corporate
            }
            else
            {
                nCustType = 240;    /// BLL Institution Lighting
            }

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            DBController.Instance.OpenNewConnection();
            oCustomers.GetB2BCustomerForVarification(txtCustCode.Text, txtFind.Text, nStatus, nCustType);
            this.Text = "Customers" + "[" + oCustomers.Count + "]";
            
            foreach (Customer oCustomer in oCustomers)
            {
                ListViewItem lstItem = lvwCustomer.Items.Add(oCustomer.CustomerCode.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerName.ToString());
                lstItem.SubItems.Add(oCustomer.ParentCustomerName.ToString());
                lstItem.SubItems.Add(oCustomer.ChannelDescription.ToString());
                lstItem.SubItems.Add(oCustomer.AreaName.ToString());
                lstItem.SubItems.Add(oCustomer.Territory.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CustomerVerificationStatus), oCustomer.Status));
                lstItem.Tag = oCustomer;
            }
            SetListViewRowColour();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmCustomerVarifications_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (lvwCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Customer to Verified.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;
            if (oCustomer.Status == (int)Dictionary.CustomerVerificationStatus.NotVerified)
            {
                frmCustomerVarification oForm = new frmCustomerVarification();
                oForm.ShowDialog(oCustomer);
                LoadData();
            }
            else
            {
                MessageBox.Show("Only Not Verified Status Can be Verified.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}