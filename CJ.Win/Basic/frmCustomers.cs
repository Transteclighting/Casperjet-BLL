// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Shahnoor Saeed
// Date: May 15, 2007
// Time : 2:00 PM
// Description: Customer entry form.
// Modify Person And Date:Uttam Kar 22-May-2014
// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CJ.Class;
using CJ.Report;
using CJ.Class.POS;

namespace CJ.Win
{
    public partial class frmCustomers : Form
    {
        Customer _oCustomer;
        Customers _oCustomers;
        Channels oChannels;
        int nCustomerID;
        
        public frmCustomers()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            frmCustomer oForm = new frmCustomer(1);
            oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            oForm.MaximizeBox = false;
            oForm.ShowDialog();   
        }

        private void RefreshData()
        {
            throw new Exception("The method or operation is not implemented.");
        }
       
        private void RefreshList()
        {

        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Customers oCustomers = new Customers();
            lvwCustomer.Items.Clear();

            int nChannelID = 0;
            if (cbChannel.SelectedIndex == 0)
            {
                nChannelID = -1;
            }
            else
            {
                nChannelID = oChannels[cbChannel.SelectedIndex - 1].ChannelID;
            }


            DBController.Instance.OpenNewConnection();
            oCustomers.Refresh(txtCustCode.Text, txtFind.Text, nChannelID);
            this.Text = "Customers" + "[" + oCustomers.Count + "]";
            foreach (Customer oCustomer in oCustomers)
            {
                ListViewItem lstItem = lvwCustomer.Items.Add(oCustomer.CustomerCode.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerName.ToString());
                lstItem.SubItems.Add(oCustomer.ChannelDescription.ToString());
                lstItem.SubItems.Add(oCustomer.AreaName.ToString());
                lstItem.SubItems.Add(oCustomer.Territory.ToString());

                lstItem.Tag = oCustomer;

            }
        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
         

        }

        private void lvwCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvwCustomer.SelectedItems.Count == 0)
            {
                //MessageBox.Show("Please Select an Customer to create or delete account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;
            try
            {
                DBController.Instance.BeginNewTransaction();
                if (oCustomer.IsExitAccount(oCustomer.CustomerID))
                {
                    btnCreatorDeleteAccount.Text = "Delete Account";
                }
                else
                {
                    btnCreatorDeleteAccount.Text = "Create Account";
                }
                DBController.Instance.CommitTransaction();
                //LoadData();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            LoadChannelName();
        }

        private void LoadChannelName()
        {
            oChannels = new Channels();
            cbChannel.Items.Clear();
            cbChannel.Items.Add("<All>");
            DBController.Instance.OpenNewConnection();
            oChannels.GetChannel();

            foreach (Channel oChannel in oChannels)
            {
                cbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cbChannel.SelectedIndex = 0;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
            if (lvwCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Customer: " + oCustomer.CustomerCode + " ? ", "Confirm Customer Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCustomer.Delete();
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

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (lvwCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Customer Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;
            frmCustomer oForm = new frmCustomer(2);
            oForm.ShowDialog(_oCustomer);
            LoadData();
        }

        private void btnCreatorDeleteAccount_Click(object sender, EventArgs e)
        {
            if (lvwCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Customer to create or delete account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to create account: " + oCustomer.CustomerCode + " ? ", "Confirm Customer Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oCustomer.IsExitAccount(oCustomer.CustomerID))
                    {
                        btnCreatorDeleteAccount.Text = "Delete Account";
                    }
                    else
                    {
                        oCustomer.CreateAccount(oCustomer.CustomerID);
                        Showroom oShowroom = new Showroom();
                        oShowroom.GetShowroomByCustomerID(oCustomer.ParentCustomerID);
                        if (oCustomer.ParentCustomerID == oShowroom.CustomerID) 
                        {
                            //_oDataSyncManager.SendCustomerToShowroom(_oCustomer, Dictionary.DataTransferType.Add, oShowroom.WarehouseID);

                            DataTran oDataTransfer = new DataTran();
                            oDataTransfer.TableName = "t_CustomerAccount";
                            oDataTransfer.DataID = oCustomer.CustomerID;
                            oDataTransfer.WarehouseID = oShowroom.WarehouseID;
                            oDataTransfer.TransferType = 1;
                            oDataTransfer.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTransfer.BatchNo = 0;
                            oDataTransfer.AddForTDPOS();
                        }

                        #region Insert Customer Data for Super Outlet
                        Customer oCustomerAccountData = new Customer();
                        oCustomerAccountData.CustomerBalanceDataCreation(oCustomer.CustomerID, oShowroom.WarehouseID, "t_CustomerAccount", oCustomer.CustomerID);
                        #endregion
                    }

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwCustomer.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                nCustomerID = 0;
                _oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;
                nCustomerID = _oCustomer.CustomerID;
                _oCustomer = new Customer();
                DBController.Instance.OpenNewConnection();
                _oCustomer.GetCustomerDetailByID(nCustomerID);


                rptCustomerView oReport = new rptCustomerView();

                oReport.SetParameterValue("CustomerCode", _oCustomer.CustomerCode);
                oReport.SetParameterValue("CustomerName", _oCustomer.CustomerName);
                oReport.SetParameterValue("CustomerAddress", _oCustomer.CustomerAddress);
                oReport.SetParameterValue("Thana", _oCustomer.ThanaName);
                oReport.SetParameterValue("ContactPerson", _oCustomer.ContactPerson);
                oReport.SetParameterValue("AreaName", _oCustomer.AreaName);
                oReport.SetParameterValue("MobileNo", _oCustomer.CellPhoneNo);
                oReport.SetParameterValue("ChannelDescription", _oCustomer.ChannelDescription);
                oReport.SetParameterValue("ParentCustomerCode", _oCustomer.ParentCustomerCode);
                oReport.SetParameterValue("ParentCustomerName", _oCustomer.ParentCustomerName);
                oReport.SetParameterValue("District", _oCustomer.DistrictName);
                oReport.SetParameterValue("TerritoryName", _oCustomer.TerritoryName);
                oReport.SetParameterValue("ContactDesignation", _oCustomer.ContactDesignation);
                oReport.SetParameterValue("PhoneNo", _oCustomer.CustomerTelephone);
                oReport.SetParameterValue("CustomerType", _oCustomer.CustomerTypeName);
                oReport.SetParameterValue("CreateDate", _oCustomer.EntryDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintedBy", Utility.UserFullname);
                
                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

    }
}