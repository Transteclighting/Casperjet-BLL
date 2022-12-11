using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Web.UI.Class;
using CJ.Report;

namespace CJ.Win.Claim
{
    public partial class frmReplaceClaimStockTran : Form
    {
        ReplaceClaimTrans oReplaceClaimTrans;
        Warehouses oFromWarehouses;
        Warehouses oToWarehouses;
        Warehouse oWarehouse;
        Channel oChannel;     
        ProductStock _oProductStock;
        ProductDetail _oProductDetail;
        DSProductTransaction oDSProductTransaction;
        ReplaceClaimTran oReplaceClaimTran;
        ReplaceClaim oReplaceClaim;
        CustomerDetail _oCustomerDetail;

        public frmReplaceClaimStockTran()
        {
            InitializeComponent();
        }

        private void frmReplaceClaimStockTran_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            oReplaceClaimTrans = new  ReplaceClaimTrans();
            oReplaceClaimTrans.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text);

            lvwStockList.Items.Clear();
            foreach (ReplaceClaimTran oReplaceClaimTran in oReplaceClaimTrans)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(oReplaceClaimTran.TranNo);
                lstItem.SubItems.Add(oReplaceClaimTran.TranDate.ToString("dd-MMM-yyyy"));
                //oWarehouse = new Warehouse();
                //oWarehouse.WarehouseID = oReplaceClaimTran.FromWHID;
                //oWarehouse.Reresh();
                //lstItem.SubItems.Add(oWarehouse.WarehouseName + " [" + oWarehouse.WarehouseCode + "]");
                
                if (oReplaceClaimTran.FromWHID== (int)Dictionary.ReplaceWareHouse.ProductionWH)
                {
                lstItem.SubItems.Add("Prouction HW");                               
                }

                else if (oReplaceClaimTran.FromWHID== (int)Dictionary.ReplaceWareHouse.ReengineeredWH)
                {
                lstItem.SubItems.Add("ReEngineerd WH");              
                
                }

                if (oReplaceClaimTran.ToWHID == (int)Dictionary.ReplaceWareHouse.ReplaceCentralWH)
                {
                    lstItem.SubItems.Add("Rep.Central HW");                   
                    
               }            

                if (oReplaceClaimTran.TranTypeID== (int)Dictionary.ReplaceClaimStockTranType.GOODS_RECEIVE)
                {
                lstItem.SubItems.Add("PLS Reveived");
                 
                }
                else if (oReplaceClaimTran.TranTypeID== (int)Dictionary.ReplaceClaimStockTranType.REENGINNER_GOODS_RECEIVE)
                {
                lstItem.SubItems.Add("RLS Reveived");
                lstItem.BackColor = Color.LightBlue;
                             
                                   
                }

                lstItem.SubItems.Add(oReplaceClaimTran.Remarks);
                   
                lstItem.Tag = oReplaceClaimTran;
            }
            this.Text = "Total Transaction  " + "[" + oReplaceClaimTrans.Count + "]";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmReengineeredStockTran ofrmReengineeredStockTran = new  frmReengineeredStockTran();
            ofrmReengineeredStockTran.ShowDialog();
            LoadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oReplaceClaimTran = (ReplaceClaimTran)lvwStockList.SelectedItems[0].Tag;
            oReplaceClaimTran.Refresh();
            oReplaceClaimTran.RefreshItem();

            oReplaceClaim = new ReplaceClaim();
            oReplaceClaim.ReplaceClaimID = oReplaceClaimTran.RefClaimID;
            oReplaceClaim.Refresh();            
           
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = oReplaceClaim.CustomerID;
            _oCustomerDetail.refresh();

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptReplaceClaimInvoice));

            doc.SetDataSource(oReplaceClaimTran);

            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username); 
            doc.SetParameterValue("InvoiceNo", oReplaceClaim.ReplaceClaimNo);
            doc.SetParameterValue("InvoiceDate", oReplaceClaimTran.TranDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("InvoiceHeader", "Customer Copy");
            doc.SetParameterValue("CustomerName", _oCustomerDetail.CustomerName.ToString());
            doc.SetParameterValue("CustomerCode", _oCustomerDetail.CustomerCode.ToString());
            doc.SetParameterValue("CustomerAddress", _oCustomerDetail.CustomerAddress.ToString());
            doc.SetParameterValue("CustomerPhoneNo", _oCustomerDetail.CustomerPhoneNo.ToString());
            doc.SetParameterValue("InvoiceAmount", "0");
            doc.SetParameterValue("Remarks", oReplaceClaimTran.Remarks);

            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(doc);
        }

        private void btnPrintStock_Click(object sender, EventArgs e)
        {
            frmReplaceClaimStockTranReport oForm = new frmReplaceClaimStockTranReport();
            oForm.ShowDialog();
        }

      
    }
}