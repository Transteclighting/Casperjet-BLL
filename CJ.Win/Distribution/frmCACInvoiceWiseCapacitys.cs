using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Class.Distribution;

namespace CJ.Win.Distribution
{
    public partial class frmCACInvoiceWiseCapacitys : Form
    {
        CACInvoiceWiseCapacitys oCACInvoiceWiseCapacitys;
        int nInvoiceID = 0;

        public frmCACInvoiceWiseCapacitys()
        {
            InitializeComponent();
        }

        private void frmCACInvoiceWiseCapacitys_Load(object sender, EventArgs e)
        {

        }
        private void DataLoadControl()
        {
            
            DBController.Instance.OpenNewConnection();
            oCACInvoiceWiseCapacitys = new CACInvoiceWiseCapacitys();
            DBController.Instance.OpenNewConnection();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oCACInvoiceWiseCapacitys.RefreshByInvoiceCapacity(txtCustomer.Text, txtInvNo.Text);
            this.Text = "Dealer Outlet | Total: " + "[" + oCACInvoiceWiseCapacitys.Count + "]";
            lvwList.Items.Clear();
            foreach (CACInvoiceWiseCapacity oCACInvoiceWiseCapacity in oCACInvoiceWiseCapacitys)
            {
                ListViewItem oItem = lvwList.Items.Add(oCACInvoiceWiseCapacity.CustomerName.ToString());
                oItem.SubItems.Add(oCACInvoiceWiseCapacity.InvoiceNo.ToString());
                oItem.SubItems.Add(oCACInvoiceWiseCapacity.InvoiceAmount.ToString());
                oItem.SubItems.Add(oCACInvoiceWiseCapacity.IndoorCapacity.ToString());
                oItem.SubItems.Add(oCACInvoiceWiseCapacity.OutdoorCapacity.ToString());
                oItem.SubItems.Add(oCACInvoiceWiseCapacity.Remarks.ToString());
                oItem.Tag = oCACInvoiceWiseCapacity;
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCACInvoiceWiseCapacity oFrom = new frmCACInvoiceWiseCapacity();           
                oFrom.Show();
            if (oFrom.IsTrue == true)

                DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACInvoiceWiseCapacity oCACInvoiceWiseCapacity = (CACInvoiceWiseCapacity)lvwList.SelectedItems[0].Tag;
            frmCACInvoiceWiseCapacity oform = new frmCACInvoiceWiseCapacity();
            oform.ShowDialog(oCACInvoiceWiseCapacity);
            if (oform.IsTrue == true)
                DataLoadControl();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
