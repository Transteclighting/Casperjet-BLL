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
    public partial class frmDMSReplaceClaim : Form
    {
        DMSReplaceClaimItem oDMSReplaceClaimItem;
        DMSReplaceClaimItems oDMSReplaceClaimItems;
        DMSReplaceClaimItems oDMSReplaceClaimItemsSubClaim;
        rptReplaceClaimDelivery orptReplaceClaimDelivery;
        rptReplaceClaimDeliverys orptReplaceClaimDeliverys;
        Customers oCustomers;
        Users oUsers;
        User oUser;
        int _nUserID = 0;
        public frmDMSReplaceClaim()
        {
            InitializeComponent();
        }

        private void frmDMSReplaceClaim_Load(object sender, EventArgs e)
        {
            User oUser = new User();
            _nUserID = Utility.UserId;

          
        

           
            
        }
        private void DataLoadControl()
        {
            dvwReplacement.Rows.Clear();
         //   pbreordering.Visible = false;


            DBController.Instance.OpenNewConnection();

            oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            if (ctlCustomer1.SelectedCustomer != null)
                oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value, dtToDate.Value, ctlCustomer1.SelectedCustomer.CustomerID);
            else
                oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value, dtToDate.Value, -1);
            int nReplaceClaimID = 0;
            if (oDMSReplaceClaimItems.Count > 0)
            {

                nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;



            }

            string  sSubClaimNumber=null;
            oDMSReplaceClaimItems.GetSubClaimNo(nReplaceClaimID);
            
            if (oDMSReplaceClaimItems.Count > 0)
            {
                if (cmbSubClaimNo.Text != "ALL")
                {
                    sSubClaimNumber = oDMSReplaceClaimItems[cmbSubClaimNo.SelectedIndex].SubClaimNumber;
                    oDMSReplaceClaimItems.Refresh(nReplaceClaimID, sSubClaimNumber);

                }
                else
                {
                    sSubClaimNumber = "-1";
                    oDMSReplaceClaimItems.RefreshAll(nReplaceClaimID);
                }
            }

            
            foreach (DMSReplaceClaimItem oDMSReplaceClaimItem in oDMSReplaceClaimItems)
            {

                DataGridViewRow oRow = new DataGridViewRow();

                oRow.CreateCells(dvwReplacement);
                oRow.Cells[0].Value = oDMSReplaceClaimItem.ProductID;
                oRow.Cells[1].Value = oDMSReplaceClaimItem.SubClaimNumber;
                oRow.Cells[2].Value = oDMSReplaceClaimItem.ProductCode;
                oRow.Cells[3].Value = oDMSReplaceClaimItem.ProductName;
                oRow.Cells[4].Value = oDMSReplaceClaimItem.ClaimedQty;

                dvwReplacement.Rows.Add(oRow);


            }


        }

        private void cmbClaimNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            oDMSReplaceClaimItemsSubClaim = new DMSReplaceClaimItems();
            int  nReplaceClaimID = 0;
            nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;
            DBController.Instance.OpenNewConnection();
            oDMSReplaceClaimItemsSubClaim.GetSubClaimNo(nReplaceClaimID);
            cmbSubClaimNo.Items.Clear();

            foreach (DMSReplaceClaimItem oDMSReplaceClaimItem in oDMSReplaceClaimItemsSubClaim)
            {
                cmbSubClaimNo.Items.Add(oDMSReplaceClaimItem.SubClaimNumber);

            }
            cmbSubClaimNo.SelectedIndex = 0;
            DBController.Instance.CloseConnection();
        
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.Instance.OpenNewConnection();

                oDMSReplaceClaimItems = new DMSReplaceClaimItems();
                if (ctlCustomer1.SelectedCustomer != null)
                    oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value, dtToDate.Value, ctlCustomer1.SelectedCustomer.CustomerID);
                else
                    oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value, dtToDate.Value, -1);
                int nReplaceClaimID = 0;
                if (oDMSReplaceClaimItems.Count > 0)
                {

                    nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;



                }

                oDMSReplaceClaimItemsSubClaim.GetSubClaimNo(nReplaceClaimID);
                DBController.Instance.CloseConnection();
                if (cmbSubClaimNo.Text != "ALL")
                {
                    User oUser = new User();
                    _nUserID = Utility.UserId;
                    oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;
                    string sReplaceClaimNo = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimNo;
                    string sSubClaimNo = oDMSReplaceClaimItemsSubClaim[cmbSubClaimNo.SelectedIndex].SubClaimNumber;
                    //  string sSubClaimNo = oDMSReplaceClaimItem.SubClaimNumber;
                    int nCartonQty = 0;
                    string sRemarks = TxtRemarks.Text.ToString();
                    DateTime dTranDate = DateTime.Now;
                    int nConfirmUserID = _nUserID;
                    int nStatus = 1;
                    int nIsPrinted = 0;


                    DBController.Instance.BeginNewTransaction();

                    oDMSReplaceClaimItem.Insert(nReplaceClaimID, sReplaceClaimNo, sSubClaimNo, nCartonQty, sRemarks, dTranDate, nConfirmUserID, nStatus, nIsPrinted);

                    DBController.Instance.CommitTransaction();

                    // pbreordering.PerformStep();


                    MessageBox.Show(" You Have Successfully Save The Transaction ");

                }
                else
                {
                   // for (int i = 0; i < oDMSReplaceClaimItemsSubClaim.Count-1; i++)
                  // {
                        foreach (DMSReplaceClaimItem oDMSReplaceClaimItem in oDMSReplaceClaimItemsSubClaim)
                        {

                            if (oDMSReplaceClaimItem.SubClaimNumber.ToString() == "ALL")
                                break;
                            else
                            {
                                User oUser = new User();
                                _nUserID = Utility.UserId;
                                nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;
                                string sReplaceClaimNo = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimNo;
                                //string sSubClaimNo = oDMSReplaceClaimItemsSubClaim[cmbSubClaimNo.SelectedIndex].SubClaimNumber;
                                string sSubClaimNo = oDMSReplaceClaimItem.SubClaimNumber;
                               // int nCartonQty = Convert.ToInt32(TxtCartonQty.Text);
                                int nCartonQty = 0;
                                string sRemarks = TxtRemarks.Text.ToString();
                                DateTime dTranDate = DateTime.Now;
                                int nConfirmUserID = _nUserID;
                                int nStatus = 1;
                                int nIsPrinted = 0;

                                DBController.Instance.OpenNewConnection();
                                DBController.Instance.BeginNewTransaction();

                                oDMSReplaceClaimItem.Insert(nReplaceClaimID, sReplaceClaimNo, sSubClaimNo, nCartonQty, sRemarks, dTranDate, nConfirmUserID, nStatus, nIsPrinted);

                                DBController.Instance.CommitTransaction();
                                DBController.Instance.CloseConnection();

                                // pbreordering.PerformStep();

                            }
                            
                       

                    }
                    MessageBox.Show(" You Have Successfully Save The Transaction ");
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnVerified_Click(object sender, EventArgs e)
        {

            
            oDMSReplaceClaimItem = new DMSReplaceClaimItem();
            DBController.Instance.OpenNewConnection();

            //oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            //if (ctlCustomer1.SelectedCustomer != null)
                //oDMSReplaceClaimItems.GetClaimNoPrint(dtFromDate.Value, dtToDate.Value, ctlCustomer1.SelectedCustomer.CustomerID);
            //else
                //oDMSReplaceClaimItems.GetClaimNoPrint(dtFromDate.Value, dtToDate.Value, -1);
            int nReplaceClaimID = 0;
            if (oDMSReplaceClaimItems.Count > 0)
            {
                if (cmbClaimNo.Text != "ALL")
                {
                    nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;

                }
                else
                {
                    nReplaceClaimID = -1;
                }
            }
            //int nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;

            
            DBController.Instance.BeginNewTransaction();
            oDMSReplaceClaimItem.Update(nReplaceClaimID,2, 0);
            DBController.Instance.CommitTransaction();
            DBController.Instance.CloseConnection();
            MessageBox.Show(" You Have Successfully Verified The Transaction ");
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();

            oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            if (ctlCustomer1.SelectedCustomer != null)
                oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value, dtToDate.Value, ctlCustomer1.SelectedCustomer.CustomerID);
            else
                oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value, dtToDate.Value, -1);
            int nReplaceClaimID = 0;
            if (oDMSReplaceClaimItems.Count > 0)
            {
                if (cmbClaimNo.Text != "ALL")
                {
                    nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;

                }
                else
                {
                    nReplaceClaimID = -1;
                }
            }
            string sSubClaimNumber = null;
            oDMSReplaceClaimItemsSubClaim.GetSubClaimNo(nReplaceClaimID);
            if (oDMSReplaceClaimItems.Count > 0)
            {
                if (cmbSubClaimNo.Text != "ALL")
                {
                    sSubClaimNumber = oDMSReplaceClaimItemsSubClaim[cmbSubClaimNo.SelectedIndex].SubClaimNumber;
                    oDMSReplaceClaimItems.Refresh(nReplaceClaimID, sSubClaimNumber);
                    orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                    orptReplaceClaimDeliverys.ReplaceClaimDelivery(nReplaceClaimID, sSubClaimNumber);

                }
                else
                {
                     sSubClaimNumber = "-1";
                    oDMSReplaceClaimItems.RefreshAll(nReplaceClaimID);
                    orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                    orptReplaceClaimDeliverys.ReplaceClaimDeliveryAll(nReplaceClaimID);
                }
            }
            
           
            rptReplaceClaimDeliveryItem oReports = new rptReplaceClaimDeliveryItem();
            //oReports.SetParameterValue("CartonQty", TxtCartonQty.Text.ToString());

            oReports.SetParameterValue("CartonQty",0) ;
            oReports.SetParameterValue("Comment", TxtRemarks.Text.ToString());
            oReports.SetDataSource(orptReplaceClaimDeliverys);
         

            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReports);
            DBController.Instance.CloseConnection();
        }

        private void btnVeifiedPrint_Click(object sender, EventArgs e)
        
        {
            int nStatus = 0;
            int nIsPrinted = 0;
            DBController.Instance.OpenNewConnection();

            //oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            //if (ctlCustomer1.SelectedCustomer != null)
            //    oDMSReplaceClaimItems.GetClaimNoPrint(dtFromDate.Value, dtToDate.Value, ctlCustomer1.SelectedCustomer.CustomerID);
            //else
            //    oDMSReplaceClaimItems.GetClaimNoPrint(dtFromDate.Value, dtToDate.Value, -1);
            int nReplaceClaimID = 0;
            if (oDMSReplaceClaimItems.Count > 0)
            {
                if (cmbClaimNo.Text != "ALL")
                {
                    nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;

                }
                else
                {
                    nReplaceClaimID = -1;
                }
            }

            string sSubClaimNumber = null;
            oDMSReplaceClaimItemsSubClaim.GetSubClaimNo(nReplaceClaimID);
            if (oDMSReplaceClaimItems.Count > 0)
            {
                if (cmbSubClaimNo.Text != "ALL")
                {
                    sSubClaimNumber = oDMSReplaceClaimItemsSubClaim[cmbSubClaimNo.SelectedIndex].SubClaimNumber;
                    oDMSReplaceClaimItems.Refresh(nReplaceClaimID, sSubClaimNumber);
                    orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                    orptReplaceClaimDeliverys.ReplaceClaimDelivery(nReplaceClaimID, sSubClaimNumber);

                }
                else
                {
                    sSubClaimNumber = "-1";
                    oDMSReplaceClaimItems.RefreshAll(nReplaceClaimID);
                    orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                    orptReplaceClaimDeliverys.ReplaceClaimDeliveryAll(nReplaceClaimID);
                }
            }

           
            oDMSReplaceClaimItems.GetStatus(nReplaceClaimID);
            oDMSReplaceClaimItem = new DMSReplaceClaimItem();
            foreach (DMSReplaceClaimItem oDMSReplaceClaim in oDMSReplaceClaimItems)
            {
                nStatus = oDMSReplaceClaim.Status;
                nIsPrinted = oDMSReplaceClaim.IsPrinted;
            }
            sSubClaimNumber = oDMSReplaceClaimItemsSubClaim[cmbSubClaimNo.SelectedIndex].SubClaimNumber;
            if (nStatus == 2 && nIsPrinted == 0)
            {
                orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                if (cmbSubClaimNo.Text != "ALL")
                {
                    orptReplaceClaimDeliverys.ReplaceClaimDelivery(nReplaceClaimID, sSubClaimNumber);
                }
                else
                {
                    orptReplaceClaimDeliverys.ReplaceClaimDeliveryAll(nReplaceClaimID);
                }
                rptReplaceClaimDeliveryItemVerified oReport = new rptReplaceClaimDeliveryItemVerified();

                oReport.SetDataSource(orptReplaceClaimDeliverys);
                oReport.SetParameterValue("CartonQty", TxtCartonQty.Text.ToString());
                oReport.SetParameterValue("Remarks", TxtRemarks.Text.ToString());
                oReport.SetParameterValue("type", "Logistics Copy");
                oReport.PrintToPrinter(1, true, 1, 1);
                oReport.SetParameterValue("type", "Gate Pass");
                oReport.PrintToPrinter(1, true, 1, 1);
                oReport.SetParameterValue("type", "Customer Copy");
                oReport.PrintToPrinter(1, true, 1, 1);
                oReport.SetParameterValue("type", "Customer Received Copy");
                oReport.PrintToPrinter(1, true, 1, 1);
                frmPrintPreview oFrom = new frmPrintPreview();
                oFrom.ShowDialog(oReport);
                
                DBController.Instance.BeginNewTransaction();
                oDMSReplaceClaimItem.Update(nReplaceClaimID, 2, 1);
                DBController.Instance.CommitTransaction();
                DBController.Instance.CloseConnection();
            }
            else
            {
                if (nStatus!=2)
                    MessageBox.Show("Not Verified");
                else
                    if (nIsPrinted==1)
                        MessageBox.Show("Already Printed");
                
            
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            
            DBController.Instance.OpenNewConnection();
            if (ctlCustomer1.SelectedCustomer != null)
                oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value,dtToDate.Value,ctlCustomer1.SelectedCustomer.CustomerID);
            else
                oDMSReplaceClaimItems.GetClaimNoAll( dtFromDate.Value, dtToDate.Value,-1);
            DBController.Instance.CloseConnection();
            cmbClaimNo.Items.Clear();

            foreach (DMSReplaceClaimItem oDMSReplaceClaimItem in oDMSReplaceClaimItems)
            {
                cmbClaimNo.Items.Add(oDMSReplaceClaimItem.ReplaceClaimNo);

            }
            //cmbClaimNo.SelectedIndex = 0;
            

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();

            oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            if (ctlCustomer1.SelectedCustomer != null)
                oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value, dtToDate.Value, ctlCustomer1.SelectedCustomer.CustomerID);
            else
                oDMSReplaceClaimItems.GetClaimNoAll(dtFromDate.Value, dtToDate.Value, -1);
            int nReplaceClaimID = 0;
            if (oDMSReplaceClaimItems.Count > 0)
            {
                if (cmbClaimNo.Text != "ALL")
                {
                    nReplaceClaimID = oDMSReplaceClaimItems[cmbClaimNo.SelectedIndex].ReplaceClaimID;

                }
                else
                {
                    nReplaceClaimID = -1;
                }
            }
            string sSubClaimNumber = null;
            oDMSReplaceClaimItemsSubClaim.GetSubClaimNo(nReplaceClaimID);
            if (oDMSReplaceClaimItems.Count > 0)
            {
                if (cmbSubClaimNo.Text != "ALL")
                {
                    sSubClaimNumber = oDMSReplaceClaimItemsSubClaim[cmbSubClaimNo.SelectedIndex].SubClaimNumber;
                    oDMSReplaceClaimItems.Refresh(nReplaceClaimID, sSubClaimNumber);
                    orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                    orptReplaceClaimDeliverys.ReplaceClaimDelivery(nReplaceClaimID, sSubClaimNumber);

                }
                else
                {
                    sSubClaimNumber = "-1";
                    oDMSReplaceClaimItems.RefreshAll(nReplaceClaimID);
                    orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
                    orptReplaceClaimDeliverys.ReplaceClaimDeliveryAll(nReplaceClaimID);
                }
            }


            rptReplaceClaimDeliveryItem oReports = new rptReplaceClaimDeliveryItem();
           
            oReports.SetDataSource(orptReplaceClaimDeliverys);

            oReports.SetParameterValue("CartonQty", 0);
            oReports.SetParameterValue("Comment", TxtRemarks.Text);
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReports);
            DBController.Instance.CloseConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       

       
    }
}