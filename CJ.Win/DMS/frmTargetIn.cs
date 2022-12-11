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
    public partial class frmTargetIn : Form
    {
        DMSTargetTOs _oDMSTargetTOs;
        public frmTargetIn()
        {
            InitializeComponent();
        }

        private void frmTargetIn_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            _oDMSTargetTOs = new DMSTargetTOs();
            lvwTargetList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            //if (ctlCustomer1.SelectedCustomer != null)
            _oDMSTargetTOs.RefreshBYTargetTO(dtFromDate.Value, dtToDate.Value, txtCustomerName.Text);
            //else _oAllStockIn.Refresh(dtFromDate.Value, dtToDate.Value, -1, oCustomerTypies[cmbCusType.SelectedIndex].CustTypeID);

            foreach (DMSTargetTO oDMSTargetTO in _oDMSTargetTOs)
            {
                ListViewItem oItem = lvwTargetList.Items.Add(oDMSTargetTO.DistributorID.ToString());
                //oItem.SubItems.Add(oStockIn.InvoiceDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDMSTargetTO.CustomerCode);
                oItem.SubItems.Add(oDMSTargetTO.CustomerName);
                oItem.SubItems.Add(oDMSTargetTO.AreaName);
                oItem.SubItems.Add(oDMSTargetTO.RouteID.ToString());
                oItem.SubItems.Add(oDMSTargetTO.RouteName);
                oItem.SubItems.Add(oDMSTargetTO.LMSale.ToString());
                oItem.SubItems.Add(oDMSTargetTO.TGTDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDMSTargetTO.ASGID.ToString());
                oItem.SubItems.Add(oDMSTargetTO.BrandID.ToString());

                //if (oStockIn.StockInCheck())
                //    oItem.SubItems.Add("Not Process");
                //else oItem.SubItems.Add("Process");
                oItem.Tag = oDMSTargetTO;
            }
            this.Text = "Total Target " + "[" + _oDMSTargetTOs.Count + "]";

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}