using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.Inventory
{
    public partial class frmDPCorrection : Form
    {
        SalesInvoice oSalesInvoice;
        TELLib _oTELLib;
        long nInvoiceID = 0;
        int nCustomerID = 0;

        public frmDPCorrection()
        {
            InitializeComponent();
        }

        private void txtRefInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            oSalesInvoice = new SalesInvoice();
            txtRefInvoiceNo.ForeColor = System.Drawing.Color.Red;

            if (txtRefInvoiceNo.Text.Length >= 9)
            {
                DBController.Instance.OpenNewConnection();
                oSalesInvoice.RefreshByInvoiceNoForDP(txtRefInvoiceNo.Text.Trim());
                if (oSalesInvoice.InvoiceNo == null)
                {
                    oSalesInvoice = null;
                    AppLogger.LogFatal("There is no Data.");
                    return;
                }
                else
                {
                    nInvoiceID = 0;
                    nInvoiceID = oSalesInvoice.InvoiceID;
                    nCustomerID = 0;
                    nCustomerID = oSalesInvoice.CustomerID;
                    lblInvoiceNo.Text = oSalesInvoice.InvoiceNo;
                    lblInvoiceDate.Text = Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy");
                    lblConsumerName.Text = oSalesInvoice.CustomerName;
                    lblBalance.Text = oSalesInvoice.CurrentBalance.ToString();

                    _oTELLib = new TELLib();
                    oSalesInvoice = new SalesInvoice();
                    oSalesInvoice.InvoiceID = nInvoiceID;
                    oSalesInvoice.GetDPCorrectionItem();

                    dgvLineItem.Rows.Clear();
                    foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = oSalesInvoiceItem.ProductCode.ToString();
                        oRow.Cells[1].Value = oSalesInvoiceItem.ProductName.ToString();
                        oRow.Cells[2].Value = oSalesInvoiceItem.Quantity.ToString();
                        oRow.Cells[3].Value = _oTELLib.TakaFormat(oSalesInvoiceItem.UnitPrice).ToString();
                        oRow.Cells[4].Value = oSalesInvoiceItem.AdjustedDPAmount.ToString();
                        oRow.Cells[5].Value = Convert.ToDouble((oSalesInvoiceItem.Quantity * oSalesInvoiceItem.UnitPrice) - (oSalesInvoiceItem.Quantity * oSalesInvoiceItem.AdjustedDPAmount)).ToString();
                        oRow.Cells[6].Value = oSalesInvoiceItem.ProductID.ToString();

                        dgvLineItem.Rows.Add(oRow);
                    }

                    txtRefInvoiceNo.ForeColor = System.Drawing.Color.Empty;
                    txtRefInvoiceNo.Enabled = false;
                    GetTotalPOQty();
                }
            }
            else
            {
                lblInvoiceNo.Text = "";
                lblInvoiceDate.Text = "";
                lblConsumerName.Text = "";
                lblBalance.Text = "";

            }
        }

        public void GetTotalPOQty()
        {

            txtAmount.Text = "0";

            _oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {

                if (oRow.Cells[5].Value != null)
                {
                    txtAmount.Text = Convert.ToDouble(Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(oRow.Cells[5].Value.ToString())).ToString();
                }
            }

            
            lblAmountInword.Visible = true;
            lblAmountInword.Text = _oTELLib.TakaWords(Convert.ToDouble(txtAmount.Text));
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            int Qty = Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[2].Value.ToString());
            double UnitPrice = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString());
            double DPAmount = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString());

            dgvLineItem.Rows[nRowIndex].Cells[5].Value = Convert.ToDouble((UnitPrice * Qty) - (DPAmount * Qty)).ToString();

            GetTotalPOQty();
        }

        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalPOQty();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Save()
        {

            try
            {
                DBController.Instance.BeginNewTransaction();
                oSalesInvoice = new SalesInvoice();
                SalesInvoiceItem oSalesInvoiceItem = new SalesInvoiceItem();
                CustomerTransaction oCustomerTransaction = new CustomerTransaction();

                oSalesInvoice.InvoiceID = nInvoiceID;
                oSalesInvoice.CustomerID = nCustomerID;
                oSalesInvoice.InvoiceAmount = Convert.ToDouble(txtAmount.Text);

                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count)
                    {
                        oSalesInvoiceItem.InvoiceID = nInvoiceID;
                        oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                        oSalesInvoiceItem.AdjustedDPAmount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                        oSalesInvoiceItem.UpdateDPAmount();
                    }
                }
                oSalesInvoice.UpadteInvoiceAmount();
                oCustomerTransaction.InstrumentNo = lblInvoiceNo.Text;
                oCustomerTransaction.Amount = Convert.ToDouble(txtAmount.Text);
                //oCustomerTransaction.Refresh();
                DBController.Instance.CommitTransaction();

                MessageBox.Show("You Have Successfully Update The Transaction", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}