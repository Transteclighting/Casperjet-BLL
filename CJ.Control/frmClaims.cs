using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Control
{
    public partial class frmClaims : Form
    {
        ReplaceClaims oReplaceClaims;      
        public ReplaceClaim _oReplaceClaim;

        public frmClaims()
        {
            InitializeComponent();
        }
        public bool ShowDialog(ReplaceClaim oReplaceClaim)
        {
            _oReplaceClaim = oReplaceClaim;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }      
        private void frmClaims_Load(object sender, EventArgs e)
        {
            
        }
        public void RefreshData()
        {
            lvwInvoice.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oReplaceClaims = new ReplaceClaims();
            oReplaceClaims.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date,txtClaimNo.Text);

            foreach (ReplaceClaim oReplaceClaim in oReplaceClaims)
            {
                ListViewItem lstItem = lvwInvoice.Items.Add(oReplaceClaim.ReplaceClaimNo.ToString());

                Customer oCustomer = new Customer();
                oCustomer.CustomerID = oReplaceClaim.CustomerID;
                oCustomer.refresh();
                lstItem.SubItems.Add(oCustomer.CustomerName);

                lstItem.SubItems.Add(Convert.ToDateTime(oReplaceClaim.ClaimDate).ToString("dd-MMM-yyyy"));
                if (oReplaceClaim.CheckClaimIsInvoice())
                    lstItem.SubItems.Add("Not Invoice");
                else lstItem.SubItems.Add("Invoiced");

                lstItem.Tag = oReplaceClaim;

            }      
            
        }

        private void lvwInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {        
                         
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void lvwInvoice_DoubleClick(object sender, EventArgs e)
        {          
            _oReplaceClaim = (ReplaceClaim)lvwInvoice.SelectedItems[0].Tag;
            this.Close();
        }
    }
}