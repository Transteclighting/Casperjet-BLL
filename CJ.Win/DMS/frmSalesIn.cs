using CJ.Class;
using CJ.Class.DMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.DMS
{
    public partial class frmSalesIn : Form
    {
        AllSalesIn _oAllSalesIn;
        CustomerTypies oCustomerTypies;
        public frmSalesIn()
        {
            
            InitializeComponent();
            DateTime frmDate = DateTime.Now;
            DateTime toDate = DateTime.Now;
            dtFromDate.Value = frmDate;
            dtToDate.Value = toDate;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            _oAllSalesIn = new AllSalesIn();
            lvwStockList.Items.Clear();
            DBController.Instance.OpenNewConnection();  
             _oAllSalesIn.RefreshStkIn(dtFromDate.Value, dtToDate.Value);  
            



            foreach (StockIn oStockIn in _oAllSalesIn)
            {
                ListViewItem oItem = lvwStockList.Items.Add(oStockIn.InvoiceNo);
                oItem.SubItems.Add(oStockIn.CustomerCode);
                oItem.SubItems.Add(oStockIn.CustomerName);
                oItem.SubItems.Add(oStockIn.InvoiceAmount.ToString()); 
                oItem.SubItems.Add(oStockIn.InvoiceDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add("Special DB");
                if (oStockIn.SalesInCheck())
                    oItem.SubItems.Add("Not Process");
                else oItem.SubItems.Add("Process");
                oItem.Tag = oStockIn;
            }
            this.Text = "Total Invoice " + "[" + _oAllSalesIn.Count + "]";

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (_oAllSalesIn != null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    pbStockIn.Visible = true;
                    pbStockIn.Minimum = 0;
                    pbStockIn.Maximum = _oAllSalesIn.Count;
                    pbStockIn.Step = 1;
                    pbStockIn.Value = 0;

                    foreach (StockIn oStockIn in _oAllSalesIn)
                    {
                        if (oStockIn.SalesInCheck())
                        {
                                oStockIn.AddToSales();
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
                    AppLogger.LogError("Win_DMS: Error for Process data - Stock in" + ex);

                }

            }
        }

        private void lvwStockList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
