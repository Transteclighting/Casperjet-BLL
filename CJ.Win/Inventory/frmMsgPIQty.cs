using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Report;

namespace CJ.Win.Inventory
{
    public partial class frmMsgPIQty : Form
    {
        PurchaseRequisition _oPurchaseRequisition;
        rptProductTransactionReport _orptProductTransactionReport;
        int _nPOID;
        string sPONO = "";

        public frmMsgPIQty( string _sPONO, rptProductTransactionReport orptProductTransactionReport)
        {
            InitializeComponent();        
            sPONO = _sPONO;
            _orptProductTransactionReport = orptProductTransactionReport;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            //MessageBoxButtons w = MessageBoxButtons.OKCancel;
            //MessageBoxButtons n;
            //n = (MessageBoxButtons)MessageBox.Show("Do You Want to Set This Purchase Requisition as not Warehouse Received Status ? ?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (w == n)
            //{              
                this.Close();
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //MessageBoxButtons w = MessageBoxButtons.OKCancel;
            //MessageBoxButtons n;
            //n = (MessageBoxButtons)MessageBox.Show("Do You Want to Set This Purchase Requisition as Warehouse Received Status ? ?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (w == n)
            //{
                this.DialogResult = DialogResult.OK;
                this.Close();
            //}
        }

        private void frmMsgPIQty_Load(object sender, EventArgs e)
        {

            lbPONo.Text = sPONO;          

            lvwStockList.Items.Clear();

            foreach (rptProductTransaction orptProductTransaction in _orptProductTransactionReport)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(orptProductTransaction.ProductCode);
                lstItem.SubItems.Add(orptProductTransaction.ProductName);
                lstItem.SubItems.Add(orptProductTransaction.PIQty.ToString());             
                lstItem.SubItems.Add(orptProductTransaction.Qty.ToString());

            }
        }
    }
}