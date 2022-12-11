using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmCACProjectInvoiceWise : Form
    {
        CACProjectInvoiceWise oCACProjectInvoiceWise;
        CACProjectInvoiceWises oCACProjectInvoiceWises;
        Suppliers oSuppliers;
        SalesInvoice oSalesInvoice;
        int _nProjectID = 0;
        //double ntotalAmount = 0;
        DateTime _dtDate;
        public bool _Istrue = false;
        //string sInvoiceNo = "";
        int _nCustomerID = 0;
        public frmCACProjectInvoiceWise()
        {
            InitializeComponent();
        }
        public void ShowDialog(int nProjectID,string sCode,string sName,int nCustomerID)
        {
            DBController.Instance.OpenNewConnection();
            _nProjectID = nProjectID;
            lblCode.Text = sCode;
            lblName.Text = sName;
            _nCustomerID = nCustomerID;
            this.ShowDialog();
        }
        private void frmCACProjectInvoiceWise_Load(object sender, EventArgs e)
        {           
            //rdoInvoice.Checked = true;
            LoadCombo();
            LoadInvoiceList();
            Total();


        }
        private void LoadCombo()
        {           
            //oSuppliers = new Suppliers();
            //oSuppliers.GetByCACSupplierName();
            //cmbSupplier.Items.Clear();
            //cmbSupplier.Items.Add("-- All--");
            //foreach (Supplier oSupplier in oSuppliers)
            //{
            //    cmbSupplier.Items.Add(oSupplier.SupplierName);
            //}
            //cmbSupplier.SelectedIndex = 0;
        }        
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (txtInvNo.Text == "")
            {
                MessageBox.Show("Please Enter Valid Invoice#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvNo.Focus();
            }            
            else
            {
                SalesInvoice oSalesInvoice = new SalesInvoice();
                oSalesInvoice.GetByCACInvoiceNo(txtInvNo.Text);
                if (oSalesInvoice.CheckInvoiceNo(txtInvNo.Text) == false)
                {
                    if (_nCustomerID == oSalesInvoice.CustomerID)
                    {
                        _dtDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);
                        dtInvDate.Value = _dtDate;
                        txtInvAmount.Text = oSalesInvoice.InvoiceAmount.ToString();
                        _nCustomerID = oSalesInvoice.CustomerID;
                    }
                    else
                    {
                        MessageBox.Show("Please Input Valid Customer Invoice#");
                    }
                }
                else
                {
                    MessageBox.Show("Please Input Valid Invoice#");
                }                 

            }

            this.Cursor = Cursors.Default;

        }

        private void rdoInvoice_CheckedChanged(object sender, EventArgs e)
        {            
                txtInvNo.Visible = true;
                dtInvDate.Visible = true;
                txtInvAmount.Visible = true;
                btnAddInvoiceList.Visible = true;
                dgvCACProjectInvoiceWise.Visible = true;
                btnGo.Visible = true;
                txtRemarks.Visible = true;
                lblNumber.Text = "Invoice #";
                dtDate.Visible = false;                            
        }
        private void LoadInvoiceList()
        {
            this.Cursor = Cursors.WaitCursor;            
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
           oCACProjectInvoiceWises = new CACProjectInvoiceWises();
           lvwInvoiceMap.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oCACProjectInvoiceWises.Refresh(_nProjectID);

            foreach (CACProjectInvoiceWise oCACProjectInvoiceWise in oCACProjectInvoiceWises)
            {
                ListViewItem oItem = lvwInvoiceMap.Items.Add(oCACProjectInvoiceWise.InvoiceNo);                
                oItem.SubItems.Add(Convert.ToDateTime(oCACProjectInvoiceWise.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCACProjectInvoiceWise.Amount.ToString());
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CACProjectStatus), oCACProjectInvoiceWise.Status));
                oItem.Tag = oCACProjectInvoiceWise;
            }
            grpInvoiceMap.Text = " Total Invoice list" + "-[" + oCACProjectInvoiceWises.Count + "]";
            this.Cursor = Cursors.Default;
        }
        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            txtInvNo.Visible = false;
            dtInvDate.Visible = false;
            txtInvAmount.Visible = false;
            txtInvAmount.Visible = false;
            dgvCACProjectInvoiceWise.Visible = false;
            dtDate.Visible = true;
            btnGo.Visible = false;
            txtRemarks.Visible = true;
            lblNumber.Text = "Supplier";
        }
        private void Save()
        {
            //if (this.Tag == null)
            //{
            try
            {
                DBController.Instance.BeginNewTransaction();
                CACProjectInvoiceWise _oCACProjectInvoiceWise = new CACProjectInvoiceWise();
                //_oCACProjectInvoiceWise.DeleteByInvoiceWise(_nProjectID);               
                foreach (DataGridViewRow oItemRow in dgvCACProjectInvoiceWise.Rows)
                {
                    if (oItemRow.Index < dgvCACProjectInvoiceWise.Rows.Count)
                    {
                        CACProjectInvoiceWise oCACProjectInvoiceWise = new CACProjectInvoiceWise();

                        oCACProjectInvoiceWise.ProjectID = _nProjectID;
                        oCACProjectInvoiceWise.InvoiceNo = oItemRow.Cells[0].Value.ToString();
                        oCACProjectInvoiceWise.InvoiceDate = Convert.ToDateTime(oItemRow.Cells[1].Value.ToString());
                        oCACProjectInvoiceWise.Amount = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        oCACProjectInvoiceWise.Type =(int)Dictionary.CACProjectInvoiceType.Invoice;
                        oCACProjectInvoiceWise.Remarks = oItemRow.Cells[3].Value.ToString();
                        oCACProjectInvoiceWise.Add();
                    }
                }
                //foreach (DataGridViewRow oItemRow in dgvCACProjectSupplier.Rows)
                //{
                //    if (oItemRow.Index < dgvCACProjectSupplier.Rows.Count)
                //    {
                //        CACProjectInvoiceWise oCACProjectInvoiceWise = new CACProjectInvoiceWise();

                //        oCACProjectInvoiceWise.ProjectID = _nProjectID;
                //        oCACProjectInvoiceWise.SupplierID = oItemRow.Cells[3].Value.ToString();
                //        oCACProjectInvoiceWise.InvoiceDate = Convert.ToDateTime(oItemRow.Cells[1].Value.ToString());
                //        oCACProjectInvoiceWise.Amount = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                //        oCACProjectInvoiceWise.Type = (int)Dictionary.CACProjectInvoiceType.Others;
                //        oCACProjectInvoiceWise.Remarks = oItemRow.Cells[4].Value.ToString();
                //        oCACProjectInvoiceWise.Add();
                //    }
                //}
                CACProject oCACProject = new CACProject();
                oCACProject.InvoiceAmount = Convert.ToDouble(txtTotalAmount.Text);
                oCACProject.UpdateByInvoiceWise(_nProjectID);
                DBController.Instance.CommitTran();
                MessageBox.Show("Success fully Make Invoice# ", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}   
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInvoiceNo())
            {
                MessageBox.Show("InvoiceNo is already exit");
            }
            else
            {
                Save();
            }
            //Save();
            _Istrue = true;
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            if (nColumnIndex == 2)
            {
                //if (lvwInvoiceMap.Items[nRowIndex].SubItems[2].Text.ToString() != null)
                //{
                //    try
                //    {
                //        lvwInvoiceMap.Items[nRowIndex].SubItems[2].Text = lvwInvoiceMap.Items[nRowIndex].SubItems[2].Text.ToString();

                //    }
                //    catch
                //    {
                //        //MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                //    }
                //}
                GetTotal();
            }

        }
        private void GetTotal()
        {
            Double nInvAmount = 0.00;
            Double nTotalAmount = 0.00;
            txtTotalAmount.Text = "0.00";
            double nTotal= 0.00; 
            foreach (DataGridViewRow oRow in dgvCACProjectInvoiceWise.Rows)
            {
                if (oRow.Cells[2].Value != null)
                {
                    nInvAmount += Convert.ToDouble(oRow.Cells[2].Value.ToString());
                }
            }
            nTotalAmount = nInvAmount;
            txtTotalAmount.Text = nTotalAmount.ToString();
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearInvoice()
        {
            txtInvNo.Text = "";
            dtInvDate.Value = DateTime.Now;
            txtInvAmount.Text = "";
            txtRemarks.Text = "";
        }
        private void ClearOthers()
        {
            dtDate.Value = DateTime.Now;
            txtRemarks.Text = "";
        }
        private bool CheckDuplicate()
        {

            foreach (DataGridViewRow oItemRow in dgvCACProjectInvoiceWise.Rows)
            {
                if (oItemRow.Index < dgvCACProjectInvoiceWise.Rows.Count)
                {
                    if (txtInvNo.Text == oItemRow.Cells[0].Value.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool CheckUIGridViewInvoiceWise()
        {                      
            
            if (txtInvAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvAmount.Focus();
                return false;
            }
            try
            {
                Convert.ToInt32(txtInvAmount.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvAmount.Focus();
                return false;
            }
            return true;
        }
        //private bool CheckUIGridViewOthers()
        //{
            //if (cmbSupplier.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbSupplier.Focus();
            //    return false;
            //}
            //if (txtOtherAmount.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtOtherAmount.Focus();
            //    return false;
            //}
            //try
            //{
            //    Convert.ToInt32(txtOtherAmount.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("Please Enter Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtOtherAmount.Focus();
            //    return false;
            //}
            //return true;
        //}
        private void AddInvoiceList()
        {
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvCACProjectInvoiceWise);
            oRow.Cells[0].Value = txtInvNo.Text;
            oRow.Cells[1].Value = dtInvDate.Value;
            oRow.Cells[2].Value = txtInvAmount.Text;
            oRow.Cells[3].Value = txtRemarks.Text;
            dgvCACProjectInvoiceWise.Rows.Add(oRow);
        }
        private void btnAddInvoiceList_Click(object sender, EventArgs e)
        {
            if (CheckDuplicate())
            {              
                    AddInvoiceList();
                    ClearInvoice();                                 
            }
            else
            {
                MessageBox.Show("Duplicate Invoice can't be added");
            }
            GetTotal();
        }
        private void AddOthersList()
        {
            //DataGridViewRow oRow = new DataGridViewRow();
            //oRow.CreateCells(dgvCACProjectSupplier);
            //oRow.Cells[0].Value = cmbSupplier.Text;
            //oRow.Cells[1].Value = dtDate.Value;
            //oRow.Cells[2].Value = txtOtherAmount.Text;
            //oRow.Cells[3].Value = cmbSupplier.SelectedIndex;
            //oRow.Cells[4].Value = txtRemarks.Text;
            //dgvCACProjectSupplier.Rows.Add(oRow);
        }
        private void btnOtherList_Click(object sender, EventArgs e)
        {
            //if (CheckUIGridViewOthers())
            //{
            //    AddOthersList();
            //    ClearOthers();
            //    GetTotal();
            //}
        }

        private void dgvCACProjectOther_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvCACProjectOther_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private void dgvCACProjectInvoiceWise_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvCACProjectInvoiceWise_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private bool CheckInvoiceNo()
        {
            foreach (DataGridViewRow oItemRow in dgvCACProjectInvoiceWise.Rows)
            {
                oCACProjectInvoiceWise = new CACProjectInvoiceWise();
                oCACProjectInvoiceWise.RefreshByInvoiceWise(oItemRow.Cells[0].Value.ToString(), _nProjectID);                
                    if (oItemRow.Index < dgvCACProjectInvoiceWise.Rows.Count)
                    {
                        if (oItemRow.Cells[0].Value.ToString() != oCACProjectInvoiceWise.InvoiceNo)
                        {
                            return false;
                        }
                    }          
            }           
            return true;
        }

        private void lvwInvoiceMap_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwInvoiceMap.Columns[e.ColumnIndex].Width;
        }
        private void Total()
        {
            double value = 0;
            for (int i = 0; i < lvwInvoiceMap.Items.Count; i++)
            {
                value += Convert.ToDouble(lvwInvoiceMap.Items[i].SubItems[2].Text);
            }

            txtTotal.Text = value.ToString();
        }
    }
}
