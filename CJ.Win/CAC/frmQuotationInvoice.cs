using System;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CAC
{
    public partial class frmQuotationInvoice : Form
    {
        Quotation oQuotation;
        Quotations _oQuotations;
        QuotationInvoiceWise _oQuotationInvoiceWise;
        QuotationInvoiceWises _oQuotationInvoiceWises;
        int _nQuotationId = 0;

        public frmQuotationInvoice()
        {
            InitializeComponent();
        }
        public void ShowDialog(int nQuotationID,String sCode, String sPoAmount)
        {
            DBController.Instance.OpenNewConnection();
            //this.Tag = oQuotation;
            _nQuotationId = nQuotationID;
            lblCode.Text = sCode;
            lblPoAmount.Text = sPoAmount;

            QuotationInvoiceWises _oQuotationInvoiceWises = new QuotationInvoiceWises();
            _oQuotationInvoiceWises.Refresh(_nQuotationId);
            foreach (QuotationInvoiceWise oQuotationInvoiceWise in _oQuotationInvoiceWises)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvCACQuotationInvoice);
                    oRow.Cells[0].Value = oQuotationInvoiceWise.InvoiceID;
                    oRow.Cells[1].Value = oQuotationInvoiceWise.InvoiceNo;
                    oRow.Cells[2].Value = Convert.ToDateTime(oQuotationInvoiceWise.InvoiceDate.ToString("dd-MMM-yyyy"));
                    oRow.Cells[3].Value = oQuotationInvoiceWise.Ton;
                    oRow.Cells[4].Value = oQuotationInvoiceWise.Amount;
                    dgvCACQuotationInvoice.Rows.Add(oRow);
                }
                _oQuotationInvoiceWises.RefreshByOther(_nQuotationId);
            foreach (QuotationInvoiceWise oQuotationInvoiceWise in _oQuotationInvoiceWises)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvCACOtherInvoice);
                    oRow.Cells[0].Value = oQuotationInvoiceWise.InvoiceID;
                    oRow.Cells[1].Value = oQuotationInvoiceWise.InvoiceNo;
                    oRow.Cells[2].Value = Convert.ToDateTime(oQuotationInvoiceWise.InvoiceDate.ToString("dd-MMM-yyyy"));
                    oRow.Cells[3].Value = oQuotationInvoiceWise.Ton;
                    oRow.Cells[4].Value = oQuotationInvoiceWise.Amount;
                    dgvCACOtherInvoice.Rows.Add(oRow);
                }

            this.ShowDialog();
        }
        private void AddQuotationInvoice()
        {
            this.Cursor = Cursors.WaitCursor;
            //QuotationInvoiceWises _oQuotationInvoiceWises = new QuotationInvoiceWises();
            QuotationInvoiceWise oQuotationInvoiceWise = new QuotationInvoiceWise();
            oQuotationInvoiceWise.RefreshByInv(txtInvoiceNo.Text);
            if (oQuotationInvoiceWise.InvoiceNo != null)
            {
                DataGridViewRow oRow = new DataGridViewRow();

                    oRow.CreateCells(dgvCACQuotationInvoice);
                    oRow.Cells[0].Value = oQuotationInvoiceWise.InvoiceID;
                    oRow.Cells[1].Value = oQuotationInvoiceWise.InvoiceNo;
                    oRow.Cells[2].Value = Convert.ToDateTime(oQuotationInvoiceWise.InvoiceDate.ToString("dd-MMM-yyyy"));
                    oRow.Cells[3].Value = txtTon.Text;
                    oRow.Cells[4].Value = oQuotationInvoiceWise.Amount;
                    dgvCACQuotationInvoice.Rows.Add(oRow);
            }
            else
            {
                MessageBox.Show("Please Input Valid Invoice#");
            }
            this.Cursor = Cursors.Default;
        }
        private void Clear()
        {
            
            txtInvoiceNo.Text = "";
            txtTon.Text= "";


        }
        private bool CheckDuplicate()
        {

            foreach (DataGridViewRow oItemRow in dgvCACQuotationInvoice.Rows)
            {
                if (oItemRow.Index < dgvCACQuotationInvoice.Rows.Count)
                {
                    if (txtInvoiceNo.Text == oItemRow.Cells[1].Value.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void Save()
        {
            //if (this.Tag == null)
            //{
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oQuotationInvoiceWise = new QuotationInvoiceWise();
                    _oQuotationInvoiceWise.DeleteByQuotation(_nQuotationId);
                    foreach (DataGridViewRow oItemRow in dgvCACQuotationInvoice.Rows)
                    {
                        if (oItemRow.Index < dgvCACQuotationInvoice.Rows.Count)
                        {                            
                            QuotationInvoiceWise oQuotationInvoiceWise = new QuotationInvoiceWise();

                            oQuotationInvoiceWise.QuotationID = _nQuotationId;
                            oQuotationInvoiceWise.InvoiceNo = oItemRow.Cells[1].Value.ToString();
                            oQuotationInvoiceWise.InvoiceDate = Convert.ToDateTime(oItemRow.Cells[2].Value.ToString());
                            oQuotationInvoiceWise.Ton = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                            oQuotationInvoiceWise.Amount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                            oQuotationInvoiceWise.Type = (int)Dictionary.QuotationInvoiceType.Invoice;
                            oQuotationInvoiceWise.Add();
                        }
                    }
                    foreach (DataGridViewRow oItemRow in dgvCACOtherInvoice.Rows)
                    {
                        if (oItemRow.Index < dgvCACOtherInvoice.Rows.Count -1)
                        {
                            QuotationInvoiceWise oQuotationInvoiceWise = new QuotationInvoiceWise();

                            oQuotationInvoiceWise.QuotationID = _nQuotationId;
                            oQuotationInvoiceWise.InvoiceNo = oItemRow.Cells[1].Value.ToString();
                            oQuotationInvoiceWise.InvoiceDate = Convert.ToDateTime(oItemRow.Cells[2].Value.ToString());
                            oQuotationInvoiceWise.Ton = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                            oQuotationInvoiceWise.Amount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                            oQuotationInvoiceWise.Type = (int)Dictionary.QuotationInvoiceType.Non_Invoice;
                            oQuotationInvoiceWise.Add();
                        }
                    }
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Success fully Make Quotation Invoice# ", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}   
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            if (nColumnIndex == 4)
            {
                if (dgvCACQuotationInvoice.Rows[nRowIndex].Cells[4].Value.ToString() != null)
                {
                    try
                    {
                        dgvCACQuotationInvoice.Rows[nRowIndex].Cells[4].Value = Convert.ToDouble(dgvCACQuotationInvoice.Rows[nRowIndex].Cells[4].Value.ToString());

                    }
                    catch
                    {
                        //MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                    }
                }
                GetTotal();
            }

        }

        private void refreshRowOther(int nRowIndex, int nColumnIndex)
        {
            if (nColumnIndex == 4)
            {
                if (dgvCACOtherInvoice.Rows[nRowIndex].Cells[4].Value.ToString() != null)
                {
                    try
                    {
                        dgvCACOtherInvoice.Rows[nRowIndex].Cells[4].Value = Convert.ToDouble(dgvCACOtherInvoice.Rows[nRowIndex].Cells[4].Value.ToString());

                    }
                    catch
                    {
                        //MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                    }
                }
                GetTotal();
            }

        }
        private void GetTotal()
        {
            txtInvAmount.Text = "0.00";
            Double nInvAmount = 0.00;
            Double nOtherAmount = 0.00;
            txtOtherAmount.Text = "0.00";
            Double nTotalAmount = 0.00;
            txtTotalAmount.Text = "0.00";
            foreach (DataGridViewRow oRow in dgvCACQuotationInvoice.Rows)
            {
                if (oRow.Cells[4].Value != null)
                {

                    //txtInvAmount.Text = Convert.ToDouble(Convert.ToDouble(txtInvAmount.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();
                    nInvAmount += Convert.ToDouble(oRow.Cells[4].Value.ToString());
                }
            }
            txtInvAmount.Text = nInvAmount.ToString();

            foreach (DataGridViewRow oRow in dgvCACOtherInvoice.Rows)
            {
                if (oRow.Cells[4].Value != null)
                {

                    //txtOtherAmount.Text = Convert.ToDouble(Convert.ToDouble(txtOtherAmount.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();
                    nOtherAmount += Convert.ToDouble(oRow.Cells[4].Value.ToString());
                }
            }
            txtOtherAmount.Text = nOtherAmount.ToString();
            nTotalAmount = nInvAmount + nOtherAmount;
            txtTotalAmount.Text = nTotalAmount.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckDuplicate())
            {
                AddQuotationInvoice();
                Clear();
            }
            else
            {
                MessageBox.Show("Duplicate Invoice can't be added");
            }
           // AddQuotationInvoice();
            GetTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();   
        }

        private void dgvCACQuotationInvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvCACQuotationInvoice_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private void dgvCACOtherInvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRowOther(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvCACOtherInvoice_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }
    }
}