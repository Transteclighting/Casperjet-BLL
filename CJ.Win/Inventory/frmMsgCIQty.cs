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

    public partial class frmMsgCIQty : Form
    {
        rptProductTransactionReport _orptProductTransactionReport;
        CommercialInvoice _oCommercialInvoice;

        public frmMsgCIQty(CommercialInvoice oCommercialInvoice)
        {
            InitializeComponent();
            _oCommercialInvoice = oCommercialInvoice;
        }       

        private void btnOK_Click(object sender, EventArgs e)
        {
            //MessageBoxButtons w = MessageBoxButtons.OKCancel;
            //MessageBoxButtons n;
            //n = (MessageBoxButtons)MessageBox.Show("Do You Want to Set This Commercial Invoice as Fully Warehouse Received Status ?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (w == n)
            //{

                this.DialogResult = DialogResult.OK;
                this.Close();
            //}
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            //MessageBoxButtons w = MessageBoxButtons.OKCancel;
            //MessageBoxButtons n;
            //n = (MessageBoxButtons)MessageBox.Show("Do You Want to Set This Commercial Invoice as Partial Warehouse Received Status ?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (w == n)
            //{                
                this.Close();
            //}
        }

        private void frmMsgCIQty_Load(object sender, EventArgs e)
        {
            lbTranNo.Text = _oCommercialInvoice.CINo;
            _orptProductTransactionReport = new rptProductTransactionReport();
            _orptProductTransactionReport.GetDataForCIMsg(_oCommercialInvoice.CIID);

            lvwStockList.Items.Clear();

            foreach (rptProductTransaction orptProductTransaction in _orptProductTransactionReport)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(orptProductTransaction.oProductDetail.ProductCode);
                lstItem.SubItems.Add(orptProductTransaction.oProductDetail.ProductName);
                lstItem.SubItems.Add(orptProductTransaction.CIQty.ToString());
                lstItem.SubItems.Add(orptProductTransaction.Qty.ToString());

            }
        }
    }
}