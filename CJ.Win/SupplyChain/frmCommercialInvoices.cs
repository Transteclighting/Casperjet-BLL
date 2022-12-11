// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 24,2011
// Time : 12.00 PM
// Description: order form for Distribution
// Modify Person And Date:
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
using CJ.Class.Report;

namespace CJ.Win
{
   

    public partial class frmCommercialInvoices : Form
    {
       
        public frmCommercialInvoices()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Close();           
        }
      
        private void frmProductTransactions_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = DateTime.Today.AddDays(-90);
            RefreshData();

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {          
            frmCommercialInvoice oForm = new frmCommercialInvoice();
            oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            oForm.MaximizeBox = false;
            oForm.ShowDialog(null);
            RefreshData();
         
        }        
      
        public void RefreshData()
        {

            CommercialInvoices oCommercialInvoices = new CommercialInvoices();
            lvwStockList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oCommercialInvoices.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date,txtTranNo.Text);


            foreach (CommercialInvoice oCommercialInvoice in oCommercialInvoices)
            {
                PurchaseRequisition oPurchaseRequisition = new PurchaseRequisition();              
                oPurchaseRequisition.RefreshForCommercialInvoice(oCommercialInvoice.POID);

                ListViewItem lstItem = lvwStockList.Items.Add(oPurchaseRequisition.PONo.ToString());
                lstItem.SubItems.Add(oCommercialInvoice.CINo.ToString());
                lstItem.SubItems.Add(oPurchaseRequisition.Supplier.SupplierName);

                if (oCommercialInvoice.Status == (int)Dictionary.CommercialInvoiceStatus.INVOICE)
                {
                    lstItem.SubItems.Add("INVOICE");
                }
                else if (oCommercialInvoice.Status == (int)Dictionary.CommercialInvoiceStatus.SHIPMENT)
                {
                    lstItem.SubItems.Add("SHIPMENT");
                }
                else if (oCommercialInvoice.Status == (int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_PORT)
                {
                    lstItem.SubItems.Add("RECEIVED_AT_PORT");
                }
                else if (oCommercialInvoice.Status == (int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_WH_PARTIAL)
                {
                    lstItem.SubItems.Add("RECEIVED_AT_WH_PARTIAL");
                }
                else if (oCommercialInvoice.Status == (int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_WH_FULLY)
                {
                    lstItem.SubItems.Add("RECEIVED_AT_WH_FULLY");
                }
                else if (oCommercialInvoice.Status == (int)Dictionary.CommercialInvoiceStatus.CANCELED)
                {
                    lstItem.SubItems.Add("CANCELED");
                }
                lstItem.SubItems.Add(oCommercialInvoice.Remarks.ToString());
                lstItem.SubItems.Add(oCommercialInvoice.CIDate.ToString());               

                lstItem.Tag = oCommercialInvoice;

            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwStockList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwStockList.Items)
                {
                    if (oItem.SubItems[3].Text == Dictionary.CommercialInvoiceStatus.INVOICE.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[3].Text == Dictionary.CommercialInvoiceStatus.SHIPMENT.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 192, 255);
                    }
                    else if (oItem.SubItems[3].Text == Dictionary.CommercialInvoiceStatus.RECEIVED_AT_PORT.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 255);
                    }

                    else if (oItem.SubItems[3].Text == Dictionary.CommercialInvoiceStatus.RECEIVED_AT_WH_PARTIAL.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 192);
                    }
                    else if (oItem.SubItems[3].Text == Dictionary.CommercialInvoiceStatus.RECEIVED_AT_WH_FULLY.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(128, 255, 128);
                    }
                    else
                    {
                        oItem.BackColor = Color.FromArgb(255, 128, 128);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                CommercialInvoice oCommercialInvoice = (CommercialInvoice)lvwStockList.SelectedItems[0].Tag;

                frmCommercialInvoice oForm = new frmCommercialInvoice();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oCommercialInvoice);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        } 


        private void lvwStockList_DoubleClick(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                CommercialInvoice oCommercialInvoice = (CommercialInvoice)lvwStockList.SelectedItems[0].Tag;

                frmCommercialInvoice oForm = new frmCommercialInvoice();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oCommercialInvoice);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                CommercialInvoice oCommercialInvoice = (CommercialInvoice)lvwStockList.SelectedItems[0].Tag;
                if (oCommercialInvoice.Status == (int)Dictionary.CommercialInvoiceStatus.CANCELED)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oCommercialInvoice.Delete();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Delete The Commercial Invoice : " + oCommercialInvoice.CINo, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Please Change Status as CANCELED and Then Delete it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
          
        }
    }
}
     