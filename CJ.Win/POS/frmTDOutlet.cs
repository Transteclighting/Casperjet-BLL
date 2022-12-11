using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using System.Text.RegularExpressions;
using CJ.Class.POS;

namespace CJ.Win.POS
{
    public partial class frmTDOutlet : Form
    {
        Warehouses _oWarehouses;
        Channel oChannel;
        SystemInfo oSystemInfo;
        Customer oCustomer;

        public frmTDOutlet()
        {
            InitializeComponent();
        }

        private void frmTDOutlet_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
                LoadCmb();
        }
        public void ShowDialog(SystemInfo _oSystemInfo)
        {
            this.Tag = _oSystemInfo;

            LoadCmb();
            cmbWarehouse.SelectedIndex = _oWarehouses.GetIndex(_oSystemInfo.WarehouseID);
            cmbWarehouse.Enabled = false;
            txtAddress.Text = _oSystemInfo.WarehouseAddress;

            oCustomer = new Customer();
            oCustomer.CustomerID = _oSystemInfo.CustomerID;
            oCustomer.refresh();
            ctlCustomer1.txtCode.Text = oCustomer.CustomerCode;
            txtMobile.Text = _oSystemInfo.WarehouseCellNo;
            txtPhone.Text = _oSystemInfo.WarehousePhoneNo;
            txtEmail.Text = _oSystemInfo.WarehouseEmail;
            txtHCMobile.Text = _oSystemInfo.HCMobileNo;
            txtHCPhone.Text = _oSystemInfo.HCPhoneNo;
            txtHCEmail.Text = _oSystemInfo.HCEmail;
            cmbActive.SelectedIndex = _oSystemInfo.IsActive;
            txtVATRegistrationNo.Text = _oSystemInfo.VATRegistrationNo;

            this.ShowDialog();

        }
        public void LoadCmb()
        {
            _oWarehouses = new Warehouses();
            _oWarehouses.GetAllWarehouse();
            cmbWarehouse.Items.Clear();
            foreach (Warehouse oWarehouse in _oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            if (_oWarehouses.Count > 0)
                cmbWarehouse.SelectedIndex = _oWarehouses.Count - 1;
            cmbActive.SelectedIndex = 1;
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtShortCode.Text = _oWarehouses[cmbWarehouse.SelectedIndex].Shortcode;
            oChannel = new Channel();
            oChannel.ChannelID = _oWarehouses[cmbWarehouse.SelectedIndex].ChannelID;
            oChannel.Refresh();
            txtChannel.Text = oChannel.ChannelDescription;

        }
        public bool UIValidation()
        {
            if (_oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID == -1)
            {
                MessageBox.Show("Please select a Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                return false;
            }
            if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
            {
                MessageBox.Show("Please select a Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtEmail.Text != "")
            {
                Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                Match m = emailregex.Match(txtEmail.Text);
                if (!m.Success)
                {
                    MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }
            if(txtHCEmail.Text!="")
            {
                Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                Match m = emailregex.Match(txtHCEmail.Text);
                if (!m.Success)
                {
                    MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHCEmail.Focus();
                    return false;
                }
            }
            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                if (this.Tag != null)
                {
                    oSystemInfo = (SystemInfo)this.Tag;               

                    oSystemInfo.WarehouseAddress = txtAddress.Text;
                    oSystemInfo.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    oSystemInfo.WarehouseCellNo = txtMobile.Text;
                    oSystemInfo.WarehousePhoneNo = txtPhone.Text;
                    oSystemInfo.WarehouseEmail = txtEmail.Text;
                    oSystemInfo.HCMobileNo = txtHCMobile.Text;
                    oSystemInfo.HCPhoneNo = txtHCPhone.Text;
                    oSystemInfo.HCEmail = txtHCEmail.Text;                
                    oSystemInfo.IsActive = cmbActive.SelectedIndex;
                    oSystemInfo.VATRegistrationNo = txtVATRegistrationNo.Text;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oSystemInfo.Update();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Update The Outlet ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    oSystemInfo = new SystemInfo();

                    oSystemInfo.WarehouseID = _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID;
                    oSystemInfo.WarehouseName = _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseName;
                    oSystemInfo.Shortcode = _oWarehouses[cmbWarehouse.SelectedIndex].Shortcode;
                    oSystemInfo.ChannelID = _oWarehouses[cmbWarehouse.SelectedIndex].ChannelID;

                    oSystemInfo.WarehouseAddress = txtAddress.Text;
                    oSystemInfo.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    oSystemInfo.WarehouseCellNo = txtMobile.Text;
                    oSystemInfo.WarehousePhoneNo = txtPhone.Text;
                    oSystemInfo.WarehouseEmail = txtEmail.Text;
                    oSystemInfo.HCMobileNo = txtHCMobile.Text;
                    oSystemInfo.HCPhoneNo = txtHCPhone.Text;
                    oSystemInfo.HCEmail = txtHCEmail.Text;

                    oSystemInfo.LastOperationDate = null;
                    oSystemInfo.OperationDate = null;
                    oSystemInfo.NextOperationDate = null;
                    oSystemInfo.LastMonthEndDate = null;
                    oSystemInfo.LastYearEndDate = null;

                    oSystemInfo.CreatedBy = Utility.UserId;
                    oSystemInfo.CreateDate = DateTime.Today.Date;
                    oSystemInfo.IsActive = cmbActive.SelectedIndex;
                    oSystemInfo.VATRegistrationNo = txtVATRegistrationNo.Text;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oSystemInfo.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Save The Outlet ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}