using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;


namespace CJ.Win.Claim
{
    public partial class frmReplaceClaims : Form
    {
        ReplaceClaims oReplaceClaims;
        ReplaceClaimTran oReplaceClaimTran;
        public ReplaceClaim _oReplaceClaim;
                     
        public frmReplaceClaims()
        {
            InitializeComponent();
        }
       

        private void frmReplaceClaims_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            lvwInvoice.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oReplaceClaims = new ReplaceClaims();
            oReplaceClaims.RefreshForClaimTransfer(dtFromDate.Value.Date, dtToDate.Value.Date);

            foreach (ReplaceClaim oReplaceClaim in oReplaceClaims)
            {
                ListViewItem lstItem = lvwInvoice.Items.Add(oReplaceClaim.ReplaceClaimNo.ToString());

                Customer oCustomer = new Customer();
                oCustomer.CustomerID = oReplaceClaim.CustomerID;
                oCustomer.refresh();
                lstItem.SubItems.Add(oCustomer.CustomerName);

                lstItem.SubItems.Add(Convert.ToDateTime(oReplaceClaim.ClaimDate).ToString("dd-MMM-yyyy"));

                lstItem.Tag = oReplaceClaim;

            }
            this.Text = "Total Claim [" + oReplaceClaims.Count.ToString() + "]";

            if (oReplaceClaims.Count <= 0)
            {
                oReplaceClaims = null;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (oReplaceClaims != null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    pbTransfer.Visible = true;
                    pbTransfer.Minimum = 0;
                    pbTransfer.Maximum = oReplaceClaims.Count;
                    pbTransfer.Step = 1;
                    pbTransfer.Value = 0;

                    foreach (ReplaceClaim oReplaceClaim in oReplaceClaims)
                    {
                        ReplaceClaimTran oReplaceClaimTran;
                        oReplaceClaimTran = new ReplaceClaimTran();

                        oReplaceClaimTran = SetData(oReplaceClaimTran,oReplaceClaim);
                        if (oReplaceClaimTran.CheckTranNo())
                        {
                            oReplaceClaimTran.Insert();

                            foreach (ReplaceClaimTranItem oReplaceClaimTranItem in oReplaceClaimTran)
                            {
                                ReplaceClaimStock oReplaceClaimStock = new ReplaceClaimStock();

                                oReplaceClaimStock.ProductID = oReplaceClaimTranItem.ProductID;
                                oReplaceClaimStock.Qty = oReplaceClaimTranItem.Quantity;
                                oReplaceClaimStock.WarehouseID = oReplaceClaimTran.ToWHID;

                                if (oReplaceClaimStock.CheckProductStock())
                                {
                                    oReplaceClaimStock.UpdateCurrentStock(true);
                                }
                                else
                                {
                                    oReplaceClaimStock.Insert();
                                    oReplaceClaimStock.UpdateCurrentStock(true);
                                }
                            }
                            pbTransfer.PerformStep();
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Process Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    RefreshData();
                    pbTransfer.Visible = false;
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                    pbTransfer.Visible = false;
                }
            }
        }
        public ReplaceClaimTran SetData(ReplaceClaimTran oReplaceClaimTran, ReplaceClaim oReplaceClaim)
        {         

            oReplaceClaimTran.TranNo = oReplaceClaim.ReplaceClaimNo;
            oReplaceClaimTran.TranTypeID = (int)Dictionary.ReplaceClaimStockTranType.CLAIM_RECEIVED;
            oReplaceClaimTran.FromWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
            oReplaceClaimTran.ToWHID = (int)Utility.ClaimWHID;
            oReplaceClaimTran.RefClaimID = oReplaceClaim.ReplaceClaimID;
            oReplaceClaimTran.RefInvoiceID = 0;
            oReplaceClaimTran.BatchNo = "";
            oReplaceClaimTran.UserID = Utility.UserId;
            oReplaceClaimTran.Remarks = "Receiveb Claim Stock";

            foreach (ReplaceClaimItem oReplaceClaimItem in oReplaceClaim)
            {
                ReplaceClaimTranItem oReplaceClaimTranItem = new ReplaceClaimTranItem();

                oReplaceClaimTranItem.ProductID = oReplaceClaimItem.ProductID;
                oReplaceClaimTranItem.Quantity = oReplaceClaimItem.ClaimedQty;

                oReplaceClaimTran.Add(oReplaceClaimTranItem);
            }
            return oReplaceClaimTran;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}