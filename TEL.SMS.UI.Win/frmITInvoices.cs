using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;

namespace TEL.SMS.UI.Win
{
    public partial class frmITInvoices : Form
    {
        private ITProduct _oDSSupplier;

        public frmITInvoices()
        {
            InitializeComponent();
        }

        private void frmITInvoices_Load(object sender, EventArgs e)
        {
            //Get All the supplier.
            _oDSSupplier = new ITProduct();
            DAITProduct oDAITProduct = new DAITProduct();
            try
            {
                DBController.Instance.OpenNewConnection();
                oDAITProduct.GetAllSuppliers(_oDSSupplier);
                DBController.Instance.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin.", "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            refreshList();
        }

        private void refreshList()
        {
            //Get All the mobiles.
            ITProduct oITProduct = new ITProduct();
            DAITProduct oDAITProduct = new DAITProduct();
            try
            {
                DBController.Instance.OpenNewConnection();
                oDAITProduct.GetAllInvoices(oITProduct);
                DBController.Instance.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin.", "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clear and Populate list.
            lvwITInvoice.Items.Clear();
            foreach (ITProduct.InvoiceRow oInvoice in oITProduct.Invoice)
            {
                ListViewItem oItem = lvwITInvoice.Items.Add(oInvoice.InvoiceNo);
                oItem.SubItems.Add(oInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                DataRow[] supplierRows = _oDSSupplier.ITSupplier.Select("SupplierID=" + oInvoice.SupplierID);
                oItem.SubItems.Add(supplierRows[0][0].ToString());
                oItem.SubItems.Add(oInvoice.ChalanNo);
                oItem.SubItems.Add(oInvoice.GRDNo);
                if (oInvoice.IsRemarksNull())
                {
                    oItem.SubItems.Add("");
                }
                else
                {
                    oItem.SubItems.Add(oInvoice.Remarks);
                }

                oItem.Tag = oInvoice;
            }

            //this.Text = "IT Invoices " + lvwITProductInvoice.Items.Count.ToString();
            this.Text = "IT Invoices ";
            //Select first item in the list.
            if (lvwITInvoice.Items.Count > 0)
            {
                lvwITInvoice.Items[0].Selected = true;
                lvwITInvoice.Focus();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmITInvoice oFrom = new frmITInvoice();
            oFrom.ShowDialog();
            refreshList();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////If no item is selected from the list.
            if (lvwITInvoice.SelectedItems.Count == 0)
            {
                return;
            }

            ITProduct.InvoiceRow oSelectedITInvoice = (ITProduct.InvoiceRow)lvwITInvoice.SelectedItems[0].Tag;
            ITProduct oITProduct = new ITProduct();
            ITProduct.InvoiceRow oRow = oITProduct.Invoice.NewInvoiceRow();
            oRow.InvoiceID = oSelectedITInvoice.InvoiceID;
            oITProduct.Invoice.AddInvoiceRow(oRow);
            oITProduct.AcceptChanges();

            frmITInvoice ofrmITInvoice = new frmITInvoice();
            ofrmITInvoice.ShowDialog(oITProduct);
            refreshList();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwITInvoice.SelectedItems.Count == 0)
            {
                return;
            }

            ITProduct.InvoiceRow oSelectedInvoice = (ITProduct.InvoiceRow)lvwITInvoice.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete " + oSelectedInvoice.InvoiceNo + "?", "Confirm invoice delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                ITProduct oITProduct = new ITProduct();
                DAITProduct oDAITProduct = new DAITProduct();
                ITProduct.InvoiceRow oRow = oITProduct.Invoice.NewInvoiceRow();
                oRow.InvoiceID= oSelectedInvoice.InvoiceID;
                oITProduct.Invoice.AddInvoiceRow(oRow);
                oITProduct.AcceptChanges();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDAITProduct.Delete(oITProduct);
                    DBController.Instance.CommitTransaction();
                    refreshList();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!");
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmITInvoice oFrom = new frmITInvoice();
            oFrom.ShowDialog();
            refreshList();           
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            removeToolStripMenuItem_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void dtTransactionDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbsupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            ////If no item is selected from the list.
            if (lvwITInvoice.SelectedItems.Count == 0)
            {
                return;
            }

            ITProduct.InvoiceRow oSelectedITInvoice = (ITProduct.InvoiceRow)lvwITInvoice.SelectedItems[0].Tag;
            ITProduct oITProduct = new ITProduct();
            ITProduct.InvoiceRow oRow = oITProduct.Invoice.NewInvoiceRow();
            oRow.InvoiceID = oSelectedITInvoice.InvoiceID;
            oITProduct.Invoice.AddInvoiceRow(oRow);
            oITProduct.AcceptChanges();

            frmITInvoice ofrmITInvoice = new frmITInvoice();
            ofrmITInvoice.ShowDialog(oITProduct);
            refreshList();
        }

        

        
        //////private void modifyPersonToolStripMenuItem_Click(object sender, EventArgs e)
        //////{
        //////    //If no item is selected from the list.
        //////    if (lvwPerson.SelectedItems.Count == 0)
        //////    {
        //////        return;
        //////    }

        //////    DSPerson.PersonRow oSelectedPerson = (DSPerson.PersonRow)lvwPerson.SelectedItems[0].Tag;

        //////    DSPerson oDSPerson = new DSPerson();
        //////    DSPerson.PersonRow oRow = oDSPerson.Person.NewPersonRow();
        //////    oRow.PersonID = oSelectedPerson.PersonID;
        //////    oDSPerson.Person.AddPersonRow(oRow);
        //////    oDSPerson.AcceptChanges();

        //////    frmPerson ofrmPerson = new frmPerson();
        //////    ofrmPerson.ShowDialog(oDSPerson);
        //////    refreshList();

        //////}

    }
}