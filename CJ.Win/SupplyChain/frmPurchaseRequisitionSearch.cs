using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmPurchaseRequisitionSearch : Form
    {
        public PurchaseRequisition oPurchaseRequisition;

        public frmPurchaseRequisitionSearch()
        {
            InitializeComponent();
        }
        private void frmPurchaseRequisitionSearch_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = DateTime.Today.AddDays(-90);
            RefreshData();
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();

        }
        public void RefreshData()
        {

            PurchaseRequisitions oPurchaseRequisitions = new PurchaseRequisitions();
            lvwStockList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oPurchaseRequisitions.RefreshForCommercialInvoice(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text, 2);


            foreach (PurchaseRequisition oPurchaseRequisition in oPurchaseRequisitions)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(oPurchaseRequisition.PONo.ToString());
                lstItem.SubItems.Add(oPurchaseRequisition.LCNo.ToString());                
                lstItem.SubItems.Add(oPurchaseRequisition.Supplier.SupplierName.ToString());

                if (oPurchaseRequisition.Status == 0)
                {
                    lstItem.SubItems.Add("NOT INVOICED ");
                }
                
                else 
                {
                    lstItem.SubItems.Add("INVOICED(" + oPurchaseRequisition.Count + ")");
                }
                lstItem.SubItems.Add(oPurchaseRequisition.Remarks.ToString());              

                lstItem.Tag = oPurchaseRequisition;

            }           
        }

        private void lvwStockList_DoubleClick(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                oPurchaseRequisition = (PurchaseRequisition)lvwStockList.SelectedItems[0].Tag;
             
            }
            this.Close();
        }

       
    }
}