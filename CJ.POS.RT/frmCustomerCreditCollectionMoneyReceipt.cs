using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Report.POS;
using CJ.Report;

namespace CJ.POS.RT
{
    public partial class frmCustomerCreditCollectionMoneyReceipt : Form
    {
        CustomerCreditApprovalCollections _oCustomerCreditApprovalCollections;
        CustomerCreditApprovalCollection _oCustomerCreditApprovalCollection;
        TELLib _oTELLib;
        int nCreditApproval = 0;
        int nCreditApprovalCollectionID = 0;
        public frmCustomerCreditCollectionMoneyReceipt()
        {
            InitializeComponent();
        }
        public void ShowDialog(CustomerCreditApproval oCustomerCreditApproval)
        {

            this.Tag = oCustomerCreditApproval;
            _oTELLib = new TELLib();
            nCreditApproval=0;
            nCreditApproval= oCustomerCreditApproval.CreditApprovalID;
            lblCreditApprovalNo.Text = oCustomerCreditApproval.ApprovalNo;
            lblCreditPeriod.Text = oCustomerCreditApproval.CreditPeriod.ToString();
            lblCreditAmount.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.CreditAmount);
            
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oCustomerCreditApprovalCollections = new CustomerCreditApprovalCollections();
            _oCustomerCreditApprovalCollections.RefreshCollectionAmountForMoneyReceiptRT(nCreditApproval);
            
            foreach (CustomerCreditApprovalCollection oCustomerCreditApprovalCollection in _oCustomerCreditApprovalCollections)
            {
                ListViewItem oItem = lvwItemList.Items.Add(Convert.ToInt32(oCustomerCreditApprovalCollection.CreditApprovalCollectionID).ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oCustomerCreditApprovalCollection.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCustomerCreditApprovalCollection.ShowroomCode);
                oItem.SubItems.Add(oCustomerCreditApprovalCollection.CustomerCode);
                oItem.SubItems.Add(oCustomerCreditApprovalCollection.CustomerName);
                oItem.SubItems.Add(_oTELLib.TakaFormat(oCustomerCreditApprovalCollection.Amount));

                oItem.Tag = oCustomerCreditApprovalCollection;
            }

            this.ShowDialog();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                nCreditApprovalCollectionID = 0;
                _oCustomerCreditApprovalCollection = (CustomerCreditApprovalCollection)lvwItemList.SelectedItems[0].Tag;
                nCreditApprovalCollectionID = _oCustomerCreditApprovalCollection.CreditApprovalCollectionID;
                _oCustomerCreditApprovalCollection = new CustomerCreditApprovalCollection();
                _oCustomerCreditApprovalCollection.RefreshCollectionCollectionIDRT(nCreditApprovalCollectionID);
                rptCustomerCreditCollectionMoneyReceipt_ oReport = new rptCustomerCreditCollectionMoneyReceipt_();
                oReport.SetParameterValue("ApprovalNo", _oCustomerCreditApprovalCollection.ApprovalNo);
                oReport.SetParameterValue("CreateDate", Convert.ToDateTime(_oCustomerCreditApprovalCollection.CreateDate).ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("CollectionAmount", _oCustomerCreditApprovalCollection.Amount);
                oReport.SetParameterValue("OutletName", _oCustomerCreditApprovalCollection.ShowroomCode);
                oReport.SetParameterValue("CustomerCode", _oCustomerCreditApprovalCollection.CustomerCode);
                oReport.SetParameterValue("CustomerName", _oCustomerCreditApprovalCollection.CustomerName);
                oReport.SetParameterValue("CustomerAddress", _oCustomerCreditApprovalCollection.CustomerAddress);
                oReport.SetParameterValue("Mobile", _oCustomerCreditApprovalCollection.CellNo);
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintedBy", Utility.Username);
               
                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}