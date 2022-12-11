using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CAC
{
    public partial class frmCACQuotations : Form
    {
        Quotations oQuotations;
        bool IsCheck = false;
        public frmCACQuotations()
        {
            InitializeComponent();
        }

        private void frmCACQuotations_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl();
        }

        private void LoadCombo()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.QuotationStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.QuotationStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            oQuotations = new Quotations();
            lvwQuotations.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oQuotations.RefreshByQuotation(dtFromDate.Value.Date, dtToDate.Value.Date, txtCustomer.Text.Trim(), nStatus,IsCheck);

            foreach (Quotation oQuotation in oQuotations)
            {
                ListViewItem oItem = lvwQuotations.Items.Add(oQuotation.CustomerName);
                oItem.SubItems.Add(oQuotation.MobileNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oQuotation.QuotationDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oQuotation.TotalAmount.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.QuotationStatus), oQuotation.Status));
                oItem.SubItems.Add(oQuotation.Remarks);
                oItem.Tag = oQuotation;
            }
            this.Text = " Total " + "[" + oQuotations.Count + "]";
            this.Cursor = Cursors.Default;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCACQuotation oForm = new frmCACQuotation((int)Dictionary.QuotationStatus.Create);
            oForm.ShowDialog();
            DataLoadControl();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwQuotations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                Quotation oQuotation = (Quotation)lvwQuotations.SelectedItems[0].Tag;
                if (oQuotation.Status != (int)Dictionary.QuotationStatus.PO_WO)
                {
                    frmCACQuotation oForm = new frmCACQuotation(oQuotation.Status);
                    oForm.ShowDialog(oQuotation);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("After Worker Order Can't be Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnWorkOrder_Click(object sender, EventArgs e)
        {
            if (lvwQuotations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item for Worker Order.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Quotation oQuotation = (Quotation)lvwQuotations.SelectedItems[0].Tag;
            if (oQuotation.Status == (int)Dictionary.QuotationStatus.Submit)
            {
                frmCACQuotation oForm = new frmCACQuotation((int)Dictionary.QuotationStatus.PO_WO);
                oForm.ShowDialog(oQuotation);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Submit Status Can be Ordered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lvwQuotations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to Submit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Quotation oQuotation = (Quotation)lvwQuotations.SelectedItems[0].Tag;
            if (oQuotation.Status != (int)Dictionary.QuotationStatus.PO_WO && oQuotation.Status!= (int)Dictionary.QuotationStatus.Cancel)
            {
                frmCACSubmitQuotation oForm = new frmCACSubmitQuotation((int)Dictionary.QuotationStatus.Submit);
                oForm.ShowDialog(oQuotation.QuotationID);
                DataLoadControl();  
            }
            else
            {
                MessageBox.Show("Can't Submit after Ordered & Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
               
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwQuotations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Quotation oQuotation = (Quotation)lvwQuotations.SelectedItems[0].Tag;

            frmCACSubmitQuotation oForm = new frmCACSubmitQuotation((int)Dictionary.QuotationStatus.Cancel);
            oForm.ShowDialog(oQuotation.QuotationID);
            DataLoadControl();
        }
          
      

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (lvwQuotations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to Submit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Quotation oQuotation = (Quotation)lvwQuotations.SelectedItems[0].Tag;
            if (oQuotation.Status == ((int)Dictionary.QuotationStatus.PO_WO))
            {
                frmQuotationInvoice oForm = new frmQuotationInvoice();
                oForm.ShowDialog(oQuotation.QuotationID,oQuotation.Code,oQuotation.POAmount.ToString());
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Worder Order Can be Mapping.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }

        }
    }
}