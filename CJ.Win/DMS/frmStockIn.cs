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
    public partial class frmStockIn : Form
    {
        AllStockIn _oAllStockIn;
        CustomerTypies oCustomerTypies;

        public frmStockIn()
        {
            InitializeComponent();
        }
        private void frmStockIn_Load(object sender, EventArgs e)
        {
            oCustomerTypies = new CustomerTypies();
            oCustomerTypies.GetCustomerType();
            cmbCusType.Items.Clear();
            foreach (CustomerType oCustomerType in oCustomerTypies)
            {
                cmbCusType.Items.Add(oCustomerType.CustTypeDescription);
            }
            cmbCusType.SelectedIndex = oCustomerTypies.Count - 1;
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
           
            RefreshData();
        }
        public void RefreshData()
        {
            _oAllStockIn = new AllStockIn();
            lvwStockList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            if (ctlCustomer1.SelectedCustomer != null)
            {
               //  _oAllStockIn.Refresh(dtFromDate.Value, dtToDate.Value, ctlCustomer1.SelectedCustomer.CustomerID, oCustomerTypies[cmbCusType.SelectedIndex].CustTypeID);  // old Code                
                _oAllStockIn.RefreshStkIn(dtFromDate.Value.AddDays(-1), dtToDate.Value, ctlCustomer1.SelectedCustomer.CustomerID);  // New Code by Dipak
            }
            //else _oAllStockIn.Refresh(dtFromDate.Value, dtToDate.Value, -1,oCustomerTypies[cmbCusType.SelectedIndex].CustTypeID);
            else _oAllStockIn.RefreshStkIn(dtFromDate.Value.AddDays(-1), dtToDate.Value, -1);  // New Code by Dipak

          

            foreach (StockIn oStockIn in _oAllStockIn)
            {
                ListViewItem oItem = lvwStockList.Items.Add(oStockIn.InvoiceNo);                
                oItem.SubItems.Add(oStockIn.CustomerCode.ToString());
                oItem.SubItems.Add(oStockIn.CustomerName.ToString());
                oItem.SubItems.Add(oStockIn.InvoiceDate.ToString("dd-MMM-yyyy"));
                if (oStockIn.StockInCheck())
                
                    oItem.SubItems.Add("Not Process");
                
                else oItem.SubItems.Add("Process");
                oItem.SubItems.Add(oStockIn.Remarks.ToString());
                oItem.Tag = oStockIn;
            }
            this.Text = "Total Invoice " + "[" + _oAllStockIn.Count + "]";

          }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {            
            if (_oAllStockIn != null)
            {               
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    pbStockIn.Visible = true;
                    pbStockIn.Minimum = 0;
                    pbStockIn.Maximum = _oAllStockIn.Count;                   
                    pbStockIn.Step = 1;
                    pbStockIn.Value = 0;

                    foreach (StockIn oStockIn in _oAllStockIn)
                    {
                        if (oStockIn.StockInCheck())
                        {
                            oStockIn.Add();
                            //// New code by Hrashid date: 11-Aug-18

                            oStockIn.InvoiceID = oStockIn.InvoiceID;
                            oStockIn.RefreshforSMStoCustomer(oStockIn.InvoiceID,oStockIn.CustomerID);
                            oStockIn.AddSMSToCustomer();
                            oStockIn.IntegrateWithAPIBLL(oStockIn.ID, oStockIn.MobileNo, oStockIn.Message);
                        }                  

                        pbStockIn.PerformStep();
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Process Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppLogger.LogInfo("Win_DMS:You Have Successfully Process Data" + Utility.UserId);                  
                    RefreshData();
                    pbStockIn.Visible = false;
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                    AppLogger.LogError("Win_DMS: Error for Process data - Stock in"+ex);

                }

            }

        }

        private void btnRSL_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {

                StockIn oStockIn = (StockIn)lvwStockList.SelectedItems[0].Tag;
                DialogResult oResult = MessageBox.Show("Are you sure you want to RSL: " + oStockIn.InvoiceNo + " ? ", "Confirm Distributor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        if (this.Tag != null)
                        {
                            MessageBox.Show("Invalid Data ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        else
                        {
                            oStockIn.RSLInvoice(oStockIn.InvoiceNo);
                            MessageBox.Show("You Have Successfully Update The RSL. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                        DBController.Instance.CommitTransaction();
                        RefreshData();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }

            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}