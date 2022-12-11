// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam kar
// Date: May 12, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Warehouse.
// Modify Person And Date:
// </summary>
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
    public partial class frmCustomerTypes : Form
    {
        CustomerType _oCustomerType;
        CustomerTypies _oCustomerTypies;
        public frmCustomerTypes()
        {
            InitializeComponent();
        }

        private void frmCustomerTypes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _oCustomerTypies = new CustomerTypies();
            lvwCustomerType.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCustomerTypies.Refresh();

            foreach (CustomerType oCustomerType in _oCustomerTypies)
            {
                ListViewItem oItem = lvwCustomerType.Items.Add(oCustomerType.CustTypeCode);
                oItem.SubItems.Add(oCustomerType.CustTypeDescription);
                oItem.SubItems.Add(oCustomerType.ChnnelDesc.ChannelDescription);
                if (oCustomerType.IsActive == (int)Dictionary.YesOrNoStatus.YES)
                {
                    oItem.SubItems.Add("Active");
                }
                else
                {
                    oItem.SubItems.Add("InActive");
                }
                oItem.Tag = oCustomerType;
            }

            this.Text = "Customer Types " + "[" + _oCustomerTypies.Count + "]";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwCustomerType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Customer Type to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomerType = (CustomerType)lvwCustomerType.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Customer Type: " + _oCustomerType.CustTypeCode + " ? ", "Confirm CustomerType Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerType.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerType oForm = new frmCustomerType();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCustomerType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Customer Type Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomerType = (CustomerType)lvwCustomerType.SelectedItems[0].Tag;
            frmCustomerType oForm = new frmCustomerType();
            oForm.ShowDialog(_oCustomerType);
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}