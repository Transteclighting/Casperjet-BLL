using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Process;
using CJ.Class.Library;

namespace CJ.Win.Process
{
    public partial class frmSalesDataSyncItem : Form
    {
        SalesDataSyncs _oSalesDataSyncs;
        SalesDataSync _oSalesDataSync;
        TELLib _oTELLib;
        public frmSalesDataSyncItem()
        {
            InitializeComponent();
        }
        public void ShowDialog(SalesDataSync oSalesDataSync)
        {
            _oTELLib=new TELLib();
            this.Tag = oSalesDataSync;
            lblInvoiceNo.Text = oSalesDataSync.InvoiceNo.ToString();
            lblInvoiceAmount.Text=_oTELLib.TakaFormat(oSalesDataSync.InvoiceAmount).ToString();
           
            DataLoadControl();

            this.ShowDialog();
        }
        private void DataLoadControl()
        {
            _oTELLib = new TELLib();
            _oSalesDataSync = (SalesDataSync)this.Tag;
            _oSalesDataSyncs = new SalesDataSyncs();
            _oSalesDataSyncs.RefreshItem(_oSalesDataSync.InvoiceID);

            lvwInvoiceItem.Items.Clear();

            foreach (SalesDataSync oSalesDataSync in _oSalesDataSyncs)
            {
                ListViewItem oItem = lvwInvoiceItem.Items.Add(oSalesDataSync.ProductCode.ToString());
                oItem.SubItems.Add(oSalesDataSync.ProductName.ToString());
                oItem.SubItems.Add(oSalesDataSync.Qty.ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oSalesDataSync.UnitPrice).ToString());
                oItem.Tag = oSalesDataSync;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}