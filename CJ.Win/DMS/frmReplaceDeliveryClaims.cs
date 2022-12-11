using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.DMS;
using CJ.Class.Report;
using CJ.Report;



namespace CJ.Win.DMS
{
    public partial class frmReplaceDeliveryClaims : Form
    {

        DMSReplaceClaimItem oDMSReplaceClaimItem;
        DMSReplaceClaimItems oDMSReplaceClaimItems;
        rptReplaceClaimDelivery orptReplaceClaimDelivery;
        rptReplaceClaimDeliverys orptReplaceClaimDeliverys;
        public frmReplaceDeliveryClaims()
        {
            oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            InitializeComponent();
        }

        private void frmReplaceDeliveryClaims_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            lvwReplaceClaims.Items.Clear();
            DBController.Instance.OpenNewConnection();

            if (ctlCustomer1.SelectedCustomer != null)
           
            {
                oDMSReplaceClaimItems.Refreshes(dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1),ctlCustomer1.SelectedCustomer.CustomerID );
                              
            }
            else oDMSReplaceClaimItems.Refreshes(dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1),-1);

          

            foreach (DMSReplaceClaimItem oDMSReplaceClaimItem in oDMSReplaceClaimItems)
            {
                ListViewItem oItem = lvwReplaceClaims.Items.Add(oDMSReplaceClaimItem.ReplaceClaimID.ToString());
                oItem.SubItems.Add(oDMSReplaceClaimItem.TranID.ToString());
                oItem.SubItems.Add(oDMSReplaceClaimItem.ReplaceClaimNo);
                oItem.SubItems.Add(oDMSReplaceClaimItem.SubClaimNumber);
                
                oItem.SubItems.Add(oDMSReplaceClaimItem.CustomerCode);
                oItem.SubItems.Add(oDMSReplaceClaimItem.CustomerName);
                //oItem.SubItems.Add(oDMSReplaceClaimItem.Status.ToString());
                oItem.SubItems.Add(oDMSReplaceClaimItem.ClaimDate.ToString("MMM-yyyy"));

                if (oDMSReplaceClaimItem.DeliveryDate < Convert.ToDateTime("01-Jan-2000"))
                {
                    oItem.SubItems.Add("Not Applicable");
                }
                else oItem.SubItems.Add(oDMSReplaceClaimItem.DeliveryDate.ToString("dd-MMM-yyyy"));

                if (oDMSReplaceClaimItem.Status == (int)Dictionary.ReplaceChallanStatus.Received)
                {
                    oItem.SubItems.Add("Receive");
                    oItem.BackColor = Color.Beige;
                }
                else if (oDMSReplaceClaimItem.Status == (int)Dictionary.ReplaceChallanStatus.Approved)
                {
                    oItem.SubItems.Add("Approved");                  
                    oItem.BackColor = Color.FromArgb(192, 255, 255);
                }
                else if (oDMSReplaceClaimItem.Status == (int)Dictionary.ReplaceChallanStatus.Delivered)
                {
                    oItem.SubItems.Add("Delivered");
                    oItem.BackColor = Color.White;
                }


                oItem.Tag = oDMSReplaceClaimItem;
            }
        
        
        
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            frmDMSReplaceClaim ofrmDMSReplaceClaim = new frmDMSReplaceClaim();
            ofrmDMSReplaceClaim.ShowDialog();
            LoadData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an ReplaceClaim Id to Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            DMSReplaceClaimItem oDMSReplaceClaimItem = (DMSReplaceClaimItem)lvwReplaceClaims.SelectedItems[0].Tag;
            int nReplaceClaimID = oDMSReplaceClaimItem.ReplaceClaimID;
            string sSubClaimNumber = oDMSReplaceClaimItem.SubClaimNumber;
            DBController.Instance.OpenNewConnection();

            oDMSReplaceClaimItems = new DMSReplaceClaimItems();        
            
                    
                    orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                    orptReplaceClaimDeliverys.ReplaceClaimDelivery(nReplaceClaimID, sSubClaimNumber);                                   
            
            
            rptReplaceClaimDeliveryItem oReports = new rptReplaceClaimDeliveryItem();            
            oReports.SetDataSource(orptReplaceClaimDeliverys);


            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReports);
            DBController.Instance.CloseConnection();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an ReplaceClaim Id to verify.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DBController.Instance.OpenNewConnection();

            DMSReplaceClaimItem oDMSReplaceClaimItem = (DMSReplaceClaimItem)lvwReplaceClaims.SelectedItems[0].Tag;
            int nReplaceClaimID = oDMSReplaceClaimItem.ReplaceClaimID;
            DBController.Instance.BeginNewTransaction();
            oDMSReplaceClaimItem.CheckStatus(nReplaceClaimID);

            if (oDMSReplaceClaimItem.Status == 3)
            {
                MessageBox.Show("Challan Already Delivered ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (oDMSReplaceClaimItem.Status == 2)
            {
                MessageBox.Show("Challan Already Approved ! Need not Verified ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDMSReplaceClaimItem.Update(nReplaceClaimID, 2, 0);
            DBController.Instance.CommitTransaction();
            DBController.Instance.CloseConnection();
            MessageBox.Show(" You Have Successfully Verified The Transaction ");
            LoadData();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            int nStatus = 0;
            int nIsPrinted = 0;
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an ReplaceClaim Id to Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DMSReplaceClaimItem oDMSReplaceClaimItem = (DMSReplaceClaimItem)lvwReplaceClaims.SelectedItems[0].Tag;
            int nReplaceClaimID = oDMSReplaceClaimItem.ReplaceClaimID;
            string sSubClaimNumber = oDMSReplaceClaimItem.SubClaimNumber;
            oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            DBController.Instance.OpenNewConnection();

            
            oDMSReplaceClaimItems.GetStatus(nReplaceClaimID);
            oDMSReplaceClaimItem = new DMSReplaceClaimItem();
           // oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            foreach (DMSReplaceClaimItem oDMSReplaceClaim in oDMSReplaceClaimItems)
            {
                nStatus = oDMSReplaceClaim.Status;
                nIsPrinted = oDMSReplaceClaim.IsPrinted;
            }

            if (nStatus == 2 && nIsPrinted == 0)
            {  

                

               if (oDMSReplaceClaimItems.CheckStock(nReplaceClaimID, sSubClaimNumber))
               {                                         


                    orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                    orptReplaceClaimDeliverys.ReplaceClaimDelivery(nReplaceClaimID, sSubClaimNumber);
                    CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptReplaceClaimDeliveryItemVerified));

                    oReport.SetDataSource(orptReplaceClaimDeliverys);

                    oReport.SetParameterValue("type", "Logistics Copy");
                    oReport.PrintToPrinter(1, true, 0, 0);
                    oReport.SetParameterValue("type", "Gate Pass");
                    oReport.PrintToPrinter(1, true, 1, 1);
                    oReport.SetParameterValue("type", "Customer Copy");
                    oReport.PrintToPrinter(1, true, 1, 1);
                    oReport.SetParameterValue("type", "Customer Received Copy");
                    oReport.PrintToPrinter(1, true, 1, 1);
                    frmPrintPreview oFrom = new frmPrintPreview();
                    oFrom.ShowDialog(oReport);

                    DBController.Instance.BeginNewTransaction();
                    //oDMSReplaceClaimItem.Update(nReplaceClaimID, 3, 1);
                    oDMSReplaceClaimItem.UpdateDelivery(nReplaceClaimID, 3, 1);

                    DBController.Instance.CommitTransaction();
                    
                   
                    DBController.Instance.BeginNewTransaction();
                    ReplaceClaimTran oReplaceClaimTran;
                    oReplaceClaimTran = new ReplaceClaimTran();
                    oReplaceClaimTran = GetUIProductTransactionData(oReplaceClaimTran);
                    DBController.Instance.CommitTransaction();
                                       

                    DBController.Instance.BeginNewTransaction();
                    oReplaceClaimTran.Insert();
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show(" Successfully Delivered ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                    
                else MessageBox.Show("Stock not Available");
                DBController.Instance.CloseConnection();
             }
                else
                {
                    if (nStatus != 2)
                        MessageBox.Show("Not Verified");
                    else
                        if (nIsPrinted == 1)
                            MessageBox.Show("Already Printed");


                }
                LoadData();
            }

        private void UpdateStock()
        {
            try
            {

                DMSReplaceClaimItem oDMSReplaceClaimItem = (DMSReplaceClaimItem)lvwReplaceClaims.SelectedItems[0].Tag;
                int nReplaceClaimID = oDMSReplaceClaimItem.ReplaceClaimID;

                DBController.Instance.BeginNewTransaction();
                ReplaceClaimTran oReplaceClaimTran;
                oReplaceClaimTran = new ReplaceClaimTran();
                oReplaceClaimTran = GetUIProductTransactionData(oReplaceClaimTran);             
                
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();  

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");        
            
            }

        }

        public ReplaceClaimTran GetUIProductTransactionData(ReplaceClaimTran oReplaceClaimTran)
        {
            DMSReplaceClaimItem oDMSReplaceClaimItem = (DMSReplaceClaimItem)lvwReplaceClaims.SelectedItems[0].Tag;
            int nReplaceClaimID = oDMSReplaceClaimItem.ReplaceClaimID;
            string sSubClaimNumber = oDMSReplaceClaimItem.SubClaimNumber;

            oDMSReplaceClaimItems.RefreshStock(nReplaceClaimID, sSubClaimNumber);
           // (int)Dictionary.ReplaceChallanStatus.Receive
            oReplaceClaimTran.TranNo = Convert.ToString(oDMSReplaceClaimItem.ReplaceClaimID);
            oReplaceClaimTran.TranDate = DateTime.Today;
            oReplaceClaimTran.TranTypeID = (int)Dictionary.ReplaceProductTran.StockIssue;
            oReplaceClaimTran.FromWHID = (int)Dictionary.ReplaceWareHouse.ReplaceCentralWH;
            oReplaceClaimTran.ToWHID = (int)Dictionary.ReplaceWareHouse.SystemWH;
            oReplaceClaimTran.RefInvoiceID = 0;
            oReplaceClaimTran.ReplaceClaimID = Convert.ToInt32(oDMSReplaceClaimItem.ReplaceClaimID); 
            oReplaceClaimTran.BatchNo = "";
            oReplaceClaimTran.UserID = Utility.UserId;
            oReplaceClaimTran.Remarks = "Product Issue";
            oReplaceClaimTran.SubClaimNo = oDMSReplaceClaimItem.SubClaimNumber;


            foreach (DMSReplaceClaimItem oDMSReplaceClaim in oDMSReplaceClaimItems)
            {
                ReplaceClaimTranItem oItem = new ReplaceClaimTranItem();

                if (oDMSReplaceClaim.ProductID != 0)
                {
                    oItem.ProductID = oDMSReplaceClaim.ProductID;
                    oItem.Quantity = oDMSReplaceClaim.ClaimedQty;
                    oItem.FGQty = oDMSReplaceClaim.ClaimedQty;
                    oReplaceClaimTran.Add(oItem);
                }
            }         


            return oReplaceClaimTran;
        }     

        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

           
           

       
              

       
    }
}