using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.DMS;

namespace CJ.Win.DMS
{
    public partial class frmDMSDSRs : Form
    {
        DMSDSR oDMSDSR;
        Customer _oCustomer;
        Customers oCustomers;

        public frmDMSDSRs()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmDMSDSR ofrm = new frmDMSDSR();
            ofrm.ShowDialog();
            if(frmDMSDSR.isUpdated)
                DataLoadControlparam();
        }

        private void frmDMSDSRs_Load(object sender, EventArgs e)
        {
            DataLoadControlparam();
        }

        //private void DataLoadControl()
        //{
        //    int nDSRcode = 0;
        //    int nCustomerID = 0;
        //    DMSDSRs oDMSDSRs = new DMSDSRs();           
        //    _oCustomer = new Customer();          
        //    ctlCustomerID.txtCode.Text = _oCustomer.CustomerCode;
        //    lvwDSRs.Items.Clear();
        //    DBController.Instance.OpenNewConnection();
        //    oDMSDSRs.RefreshDSRDetails();
        //    DBController.Instance.CloseConnection();

        //    this.Text = "DMSDSR " + "[" + oDMSDSRs.Count + "]";
        //    foreach (DMSDSR oDMSDSR in oDMSDSRs)
        //    {
        //        ListViewItem oItem = lvwDSRs.Items.Add(oDMSDSR.AreaName.ToString());
        //        oItem.SubItems.Add(oDMSDSR.TerritoryName);
        //        oItem.SubItems.Add(oDMSDSR.CustomerName);
        //        oItem.SubItems.Add(oDMSDSR.DSRCode.ToString());
        //        oItem.SubItems.Add(oDMSDSR.DSRName);
        //        oItem.SubItems.Add(oDMSDSR.Designation);
        //        oItem.SubItems.Add(oDMSDSR.DSRMobile);
        //        oItem.SubItems.Add(oDMSDSR.FixedSalary.ToString());               
        //        oItem.SubItems.Add(oDMSDSR.DailyTADA.ToString());
        //        oItem.SubItems.Add(oDMSDSR.DailySpcAllowance.ToString());
        //        oItem.SubItems.Add(oDMSDSR.IsCurrent.ToString());
        //        oItem.Tag = oDMSDSR;
        //    }
            
        //}
        private void DataLoadControlparam()
        {
            int nDSRcode = 0;
            int nCustomerID = 0;
            DMSDSRs oDMSDSRs = new DMSDSRs();           
            _oCustomer = new Customer();          
            //ctlCustomerID.txtCode.Text = _oCustomer.CustomerCode;
            lvwDSRs.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            try
            {
                nDSRcode = Convert.ToInt32(txtDSRCode.Text.ToString());
            }
            catch
            {
                nDSRcode = 0;
            }

            //if (ctlCustomerID.SelectedCustomer.CustomerID != null)
            //{
            //    nCustomerID = Convert.ToInt32(ctlCustomerID.SelectedCustomer.CustomerID);
            //}
            //else nCustomerID = 0;


            //int nIsCurrent = 0;
            //if (cmbIsCurrent.SelectedIndex == 0)
            //{
            //    nIsCurrent = -1;
            //}
            //else
            //{
            //    nIsCurrent = cmbIsCurrent.SelectedIndex;
            //}

            oDMSDSRs.RefreshDSRDetailsparam(nDSRcode, txtDSRName.Text.Trim(), txtCustomerName.Text.Trim());
            DBController.Instance.CloseConnection();

            this.Text = "DMSDSR " + "[" + oDMSDSRs.Count + "]";
            foreach (DMSDSR oDMSDSR in oDMSDSRs)
            {
                ListViewItem oItem = lvwDSRs.Items.Add(oDMSDSR.AreaName.ToString());
                oItem.SubItems.Add(oDMSDSR.TerritoryName);
                oItem.SubItems.Add(oDMSDSR.CustomerName);
                oItem.SubItems.Add(oDMSDSR.DSRCode.ToString());
                oItem.SubItems.Add(oDMSDSR.DSRName);
                oItem.SubItems.Add(oDMSDSR.Designation);
                oItem.SubItems.Add(oDMSDSR.DSRMobile);
                oItem.SubItems.Add(oDMSDSR.FixedSalary.ToString());
                oItem.SubItems.Add(oDMSDSR.VariableSalary.ToString());
                oItem.SubItems.Add(oDMSDSR.DailyTADA.ToString());
                oItem.SubItems.Add(oDMSDSR.DBBLAccNo.ToString());
                oItem.SubItems.Add(oDMSDSR.DBBLMobNo.ToString());
                oItem.SubItems.Add(oDMSDSR.BkashAccountNo.ToString());
                oItem.SubItems.Add(oDMSDSR.Grade.ToString());
                oItem.SubItems.Add(oDMSDSR.Position.ToString());
                if (oDMSDSR.IsCurrent == 1)
                {
                    oItem.SubItems.Add("Active");
                }
                else oItem.SubItems.Add("Inactive");
                oItem.Tag = oDMSDSR;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (lvwDSRs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to Edit");
                return;
            }

            DMSDSR oDMSDSR = (DMSDSR)lvwDSRs.SelectedItems[0].Tag;

            frmDMSDSR ofrom = new frmDMSDSR();
            ofrom.ShowDialog(oDMSDSR);
            if (frmDMSDSR.isUpdated)
                DataLoadControlparam();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControlparam();
        }

        //private void ctlCustomerID_Load(object sender, EventArgs e)
        //{
        //    if (ctlCustomerID.SelectedCustomer != null && ctlCustomerID.txtCode.Text != "")
        //    {
        //        _oCustomer = new Customer();
        //        _oCustomer.CustomerID = ctlCustomerID.SelectedCustomer.CustomerID;              
        //        _oCustomer.refresh();
            

        //    }
        //}
    }
}