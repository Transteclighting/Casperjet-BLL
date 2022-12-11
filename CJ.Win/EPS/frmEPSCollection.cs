using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.Library;

namespace CJ.Win.EPS
{
    public partial class frmEPSCollection : Form
    {
        Banks _oBanks;
        Branchs _oBranchs;
        EPSSalesInvoices _oEPSSalesInvoices;
        EPSCustomerTransaction _oEPSCustomerTransaction;
        rptEPSCollectionDetail _orptEPSCollectionDetail;
        rptEPSCollection _orptEPSCollection;
        TELLib oLib;
        SalesInvoice _oSalesInvoice;
        EPSSalesOrder _oEPSSalesOrder;
        double _Interest = 0;
        double _PrincipalAmt = 0;
        double _InterestAmt = 0;
        double _TotalAmt = 0;

        int _nUIControl = 0;

        public frmEPSCollection(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;

        }
        public void ShowDialog(SalesInvoice oSalesInvoice)
        {
            this.Tag = oSalesInvoice;
            if (_nUIControl != 1)
            {
                ctlCustomer1.txtCode.Text = oSalesInvoice.Customer.CustomerCode.ToString();
                ctlCustomer1.Enabled = false;
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                lblDate.Enabled = false;
                lblTo.Enabled = false;
                btnShow.Enabled = false;

            }
            //if (_nUIControl == 2)
            //{

            //    for (int i = 0; i < lvwItemList.Items.Count; i++)
            //    {
            //        ListViewItem itm = lvwItemList.Items[i];
            //        if (itm.SubItems[5].Text.ToString() == "Yes")
            //        {
            //            lvwItemList.Items[i].Checked = true;
            //        }
            //    }

            //    btSelectAll.Enabled = false;
            //    lvwItemList.Enabled = false;
            //}


            this.ShowDialog();
        }
        private void frmEPSCollection_Load(object sender, EventArgs e)
        {

            LoadInstrumentType();
            LoadAllBank();
            if(this.Tag!=null)
                btnShow_Click(null, null);

            if (_nUIControl == 4)
            {
                lvwItemList.Visible = false;
                dgvItemList.Visible = true;
                chkIsAdjustment.Visible = true;
                lblPartial.Visible = false;
            }
            else
            {
                lvwItemList.Visible = true;
                dgvItemList.Visible = false;
                chkIsAdjustment.Visible = false;
                lblPartial.Visible = true;
            }

        }
        public void LoadInstrumentType()
        {
            foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrumentType.Items.Add(GetEnum);
            }
            cmbInstrumentType.SelectedIndex = 0;
        }
        public void LoadAllBank()
        {
            _oBanks = new Banks();         
            _oBanks.Refresh();
            cmbBank.Items.Clear();
            foreach (Bank oBank in _oBanks)
                cmbBank.Items.Add(oBank.Name);  
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            _oBranchs = new Branchs();
            cmbBranch.Items.Clear();
            _oBranchs.Refresh(_oBanks[cmbBank.SelectedIndex].BankID);
            foreach (Branch oBranch in _oBranchs)
            {
                cmbBranch.Items.Add(oBranch.Name);
            }
            cmbBranch.SelectedIndex = 0;          
        }

        private void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInstrumentType.Text == "CASH")
            {              
                cmbBranch.Items.Clear();               
                cmbBank.Enabled = false;
                cmbBranch.Enabled = false;
                txtInsNo.Enabled = false;
                txtBranchName.Text = "";
                txtBranchName.Enabled = false;
                dtInsdate.Enabled = false;
                txtInsNo.Text = "";
                CheckInsStatus.Checked = false;
                CheckInsStatus.Enabled = false;
            }
            else
            {
                cmbBank.Enabled = true;
                cmbBranch.Enabled = true;
                txtInsNo.Enabled = true;
                txtBranchName.Enabled = true;
                dtInsdate.Enabled = true;
                CheckInsStatus.Enabled = true;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            lvwItemList.Items.Clear();
            dgvItemList.Rows.Clear();
            _oEPSSalesInvoices = new EPSSalesInvoices();
            DBController.Instance.OpenNewConnection();
            if (_nUIControl == 1 || _nUIControl == 4)
            {
                if (ctlCustomer1.SelectedCustomer == null)
                {
                    MessageBox.Show("Please Select a Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _oEPSSalesInvoices.Refresh(ctlCustomer1.SelectedCustomer.CustomerID, dtFromDate.Value.Date, dtToDate.Value.Date);
            }
            else
            {
                _oSalesInvoice = (SalesInvoice)this.Tag;
                _oEPSSalesInvoices.RefreshByOrderID(_oSalesInvoice.OrderID);
            }
            if (_nUIControl != 4)
            {
                foreach (EPSSalesInvoice oEPSSalesInvoice in _oEPSSalesInvoices)
                {
                    foreach (EPSSalesInvoiceDetail oEPSSalesInvoiceDetail in oEPSSalesInvoice)
                    {
                        ListViewItem lstItem = lvwItemList.Items.Add(oEPSSalesInvoice.InvoiceNo);
                        lstItem.SubItems.Add(oEPSSalesInvoice.EmployeeName);
                        lstItem.SubItems.Add(oEPSSalesInvoiceDetail.InstallmentNo.ToString());
                        lstItem.SubItems.Add(oEPSSalesInvoiceDetail.PrincipalPayable.ToString());
                        lstItem.SubItems.Add(oEPSSalesInvoiceDetail.InterestPayable.ToString());

                        if (oEPSSalesInvoiceDetail.IsDue == 0)
                            lstItem.SubItems.Add("Yes");
                        else lstItem.SubItems.Add("No");
                        lstItem.SubItems.Add(oEPSSalesInvoiceDetail.IsPartial.ToString());

                        lstItem.Tag = oEPSSalesInvoice;
                    }
                    setListViewRowColour();
                }
            }
            else
            {

                foreach (EPSSalesInvoice oEPSSalesInvoice in _oEPSSalesInvoices)
                {
                    foreach (EPSSalesInvoiceDetail oEPSSalesInvoiceDetail in oEPSSalesInvoice)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvItemList);
                        oRow.Cells[0].Value = oEPSSalesInvoice.InvoiceNo;
                        oRow.Cells[1].Value = oEPSSalesInvoice.EmployeeName;
                        oRow.Cells[2].Value = oEPSSalesInvoiceDetail.InstallmentNo.ToString();
                        oRow.Cells[3].Value = oEPSSalesInvoiceDetail.CalPrincipalAmt.ToString();
                        oRow.Cells[4].Value = oEPSSalesInvoiceDetail.CalInterestAmt.ToString();
                        if (oEPSSalesInvoiceDetail.IsDue == 0)
                        {
                            oRow.Cells[5].Value = "Yes";
                        }
                        else
                        {
                            oRow.Cells[5].Value = "No";
                        }

                        dgvItemList.Rows.Add(oRow);
                    }
                }
            }

        }
        private void setListViewRowColour()
        {
            if (lvwItemList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwItemList.Items)
                {
                    if (oItem.SubItems[6].Text == "Yes")
                    {
                        oItem.BackColor = Color.BurlyWood;
                    }
                    else
                    {
                        oItem.BackColor = Color.White;

                    }
                }
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            # region Regular Transaction
            if (ValidUIInput())
            {                
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    ///
                    // Insert Customer Transaction
                    ///

                    _oEPSCustomerTransaction = new EPSCustomerTransaction();

                    _oEPSCustomerTransaction.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    _oEPSCustomerTransaction.TranDate = dtTranDate.Value.Date;
                    _oEPSCustomerTransaction.Amount = Convert.ToDouble(txtAmount.Text);
                    _oEPSCustomerTransaction.InstrumentType = cmbInstrumentType.SelectedIndex;
                    if (cmbInstrumentType.Text != "CASH")
                    {
                        Branch oBranch = _oBranchs[cmbBranch.SelectedIndex];
                        _oEPSCustomerTransaction.InstrumentNo = txtInsNo.Text;
                        _oEPSCustomerTransaction.BranchID = oBranch.BranchID;
                        if (txtBranchName.Text != "")
                            _oEPSCustomerTransaction.BranchName = txtBranchName.Text;
                        else _oEPSCustomerTransaction.BranchName = cmbBranch.Text;
                        _oEPSCustomerTransaction.InstrumentDate = dtInsdate.Value.Date;
                    }
                    
                    if (CheckInsStatus.Checked == true)
                    {
                        _oEPSCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;
                    }
                    else _oEPSCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.NOT_APPROVED;

                    _oEPSCustomerTransaction.Remarks = txtRemarks.Text;
                    if (chkIsAdjustment.Checked == true)
                    {
                        _oEPSCustomerTransaction.TranTypeID = (short)Dictionary.TransectionType.ADJUSTMENT;
                    }
                    else
                    {
                        _oEPSCustomerTransaction.TranTypeID = (short)Dictionary.TransectionType.CASH_RECEIVE;
                    }
                    _oEPSCustomerTransaction.Insert(true);

                    ///
                    // Insert Detail
                    ///

                    _orptEPSCollectionDetail = new rptEPSCollectionDetail();

                    if (_nUIControl != 4)
                    {

                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true && itm.SubItems[5].Text.ToString() == "Yes" && itm.SubItems[6].Text.ToString() == "No")
                            {
                                EPSSalesInvoice oEPSSalesInvoice = (EPSSalesInvoice)lvwItemList.Items[i].Tag;

                                _oEPSCustomerTransaction.InvoiceID = oEPSSalesInvoice.InvoiceID;
                                _oEPSCustomerTransaction.OrderID = oEPSSalesInvoice.OrderID;
                                _oEPSCustomerTransaction.EPSCustomerID = oEPSSalesInvoice.EPSCustomerID;
                                _oEPSCustomerTransaction.InstallmentNo = Convert.ToInt16(itm.SubItems[2].Text.ToString());

                                _oEPSCustomerTransaction.PrincipalAmount = Convert.ToDouble(itm.SubItems[3].Text.ToString());
                                if (_nUIControl == 2)
                                {
                                    _oEPSCustomerTransaction.InterestAmount = 0;
                                }
                                else
                                {
                                    _oEPSCustomerTransaction.InterestAmount = Convert.ToDouble(itm.SubItems[4].Text.ToString());
                                }
                                _oEPSCustomerTransaction.InsertDetail();
                                if (_nUIControl == 2)
                                {
                                    _oEPSCustomerTransaction.IsEarlyClose = (int)Dictionary.EPSIsEarlyClose.Yes;
                                    _oEPSCustomerTransaction.UpdateIsDue();

                                }
                                else
                                {
                                    _oEPSCustomerTransaction.IsEarlyClose = (int)Dictionary.EPSIsEarlyClose.No;
                                    _oEPSCustomerTransaction.UpdateIsDue();
                                }

                                _oEPSCustomerTransaction.UpdateClosingBalance(_oEPSCustomerTransaction.PrincipalAmount + _oEPSCustomerTransaction.InterestAmount);

                                _orptEPSCollection = new rptEPSCollection();

                                _orptEPSCollection.InvoiceNo = oEPSSalesInvoice.InvoiceNo;
                                _orptEPSCollection.InvoiceDate = oEPSSalesInvoice.InvoiceDate;
                                _orptEPSCollection.EmployeeName = oEPSSalesInvoice.EmployeeName;
                                _orptEPSCollection.InstallmentNo = _oEPSCustomerTransaction.InstallmentNo;
                                _orptEPSCollection.PrincipalPayable = _oEPSCustomerTransaction.PrincipalAmount;
                                if (_nUIControl == 2)
                                {
                                    _orptEPSCollection.InterestPayable = 0;
                                }
                                else
                                {
                                    _orptEPSCollection.InterestPayable = _oEPSCustomerTransaction.InterestAmount;
                                }


                                _orptEPSCollectionDetail.Add(_orptEPSCollection);
                                _oEPSSalesOrder = new EPSSalesOrder();
                                _oEPSSalesOrder.OrderID = oEPSSalesInvoice.OrderID;
                                if (_nUIControl != 2)
                                {
                                    if (_oEPSSalesOrder.CheckIsDue())
                                    {
                                        _oEPSSalesOrder.Status = (int)Dictionary.EPSStatus.Closed;
                                        _oEPSSalesOrder.UpdateStatus();
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                    _oEPSSalesOrder.Status = (int)Dictionary.EPSStatus.EarlyClosed;
                                    _oEPSSalesOrder.UpdateStatus();

                                    EPSSalesInvoiceDetail oEPSSalesInvoiceDetail = new EPSSalesInvoiceDetail();
                                    oEPSSalesInvoiceDetail.Refresh();
                                    if (oEPSSalesInvoiceDetail.IsPartial == "Yes")
                                    {
                                        _InterestAmt = _InterestAmt + oEPSSalesInvoiceDetail.CalInterestAmt;
                                    }
                                    else
                                    {
                                        _Interest = _Interest + Convert.ToDouble(itm.SubItems[4].Text.ToString());
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow oItemRow in dgvItemList.Rows)
                        {
                            if (oItemRow.Index < dgvItemList.Rows.Count)
                            {
                                if (oItemRow.Cells[6].Value == null || oItemRow.Cells[6].Value.ToString().Trim() == "")
                                {
                                    _PrincipalAmt = 0;
                                }
                                else
                                {
                                    _PrincipalAmt = Convert.ToDouble(oItemRow.Cells[6].Value.ToString().Trim());
                                   
                                }
                                if (oItemRow.Cells[7].Value == null || oItemRow.Cells[7].Value.ToString().Trim() == "")
                                {
                                    _InterestAmt = 0;
                                }
                                else
                                {
                                    _InterestAmt = Convert.ToDouble(oItemRow.Cells[7].Value.ToString().Trim());
                                    
                                }
                                
                               if (oItemRow.Cells[5].Value.ToString().Trim() == "Yes" && (_PrincipalAmt + _InterestAmt) > 0)

                                {
                                    EPSSalesInvoice oEPSSalesInvoice = new EPSSalesInvoice();

                                    oEPSSalesInvoice.InvoiceNo = oItemRow.Cells[0].Value.ToString().Trim();
                                    oEPSSalesInvoice.RefreshInvoiceNo();
                                    _oEPSCustomerTransaction.OrderID = oEPSSalesInvoice.OrderID;
                                    _oEPSCustomerTransaction.InvoiceID = oEPSSalesInvoice.InvoiceID;
                                    _oEPSCustomerTransaction.EPSCustomerID = oEPSSalesInvoice.EPSCustomerID;
                                    _oEPSCustomerTransaction.InstallmentNo = Convert.ToInt32(oItemRow.Cells[2].Value.ToString().Trim());
                                    _oEPSCustomerTransaction.PrincipalAmount = _PrincipalAmt;
                                    _oEPSCustomerTransaction.InterestAmount = _InterestAmt;
                                
                                    _oEPSCustomerTransaction.InsertDetail();

                                    _oEPSCustomerTransaction.UpdateClosingBalance(_oEPSCustomerTransaction.PrincipalAmount + _oEPSCustomerTransaction.InterestAmount);

                                    _orptEPSCollection = new rptEPSCollection();

                                    _orptEPSCollection.InvoiceNo = oEPSSalesInvoice.InvoiceNo;
                                    _orptEPSCollection.InvoiceDate = oEPSSalesInvoice.InvoiceDate;
                                    _orptEPSCollection.EmployeeName = oEPSSalesInvoice.EmployeeName;
                                    _orptEPSCollection.InstallmentNo = _oEPSCustomerTransaction.InstallmentNo;
                                    _orptEPSCollection.PrincipalPayable = _oEPSCustomerTransaction.PrincipalAmount;
                                    _orptEPSCollection.InterestPayable = _oEPSCustomerTransaction.InterestAmount;
                                    _orptEPSCollectionDetail.Add(_orptEPSCollection);

                                    oEPSSalesInvoice.GetClosingBalance(_oEPSCustomerTransaction.InstallmentNo);

                                    if (oEPSSalesInvoice.ClosingBalance==0)
                                    {
                                        _oEPSCustomerTransaction.IsEarlyClose = (int)Dictionary.EPSIsEarlyClose.No;
                                        _oEPSCustomerTransaction.UpdateIsDue();
                                    }

                                }

                            }
                        }
                    
                    }
                    if (_nUIControl == 2)
                    {
                        _oEPSCustomerTransaction.Amount = _Interest;
                        _oEPSCustomerTransaction.TranTypeID = (short)Dictionary.TransectionType.EPS_INTEREST_REVERSE;
                        _oEPSCustomerTransaction.Insert(false);
                    }
                    else
                    { 
                    }



                    AppLogger.LogInfo("Successfully Save The EPS Collection");
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The EPS Collection", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    oLib = new TELLib();                 
                    rptEPSCollectionReport oReport = new rptEPSCollectionReport();
                    oReport.SetDataSource(_orptEPSCollectionDetail);
                    oReport.SetParameterValue("CompanyName", ctlCustomer1.SelectedCustomer.CustomerName);
                    oReport.SetParameterValue("ComapnyCode", ctlCustomer1.SelectedCustomer.CustomerCode.ToString());
                    oReport.SetParameterValue("ReceiptNo", _oEPSCustomerTransaction.TranNo);
                    oReport.SetParameterValue("TotalAmount", txtAmount.Text);
                    oReport.SetParameterValue("Amountinword", oLib.TakaWords(Convert.ToDouble(txtAmount.Text)));

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(oReport);
                    btnShow_Click(null,null);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error in EPS Collection -"+ex);
                    MessageBox.Show("Error...please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            # endregion
        }
        public bool ValidUIInput()
        {
            double Sum = 0;
            if (_nUIControl == 1 || _nUIControl == 4)
            {
                if (ctlCustomer1.SelectedCustomer == null)
                {
                    MessageBox.Show("Please select a company.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            try
            {
                if (Convert.ToDouble(txtAmount.Text) != Convert.ToDouble(txtCAmount.Text))
                {
                    MessageBox.Show("Please Check Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Please Check Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbInstrumentType.Text != "CASH")
            {
                if (txtInsNo.Text == "")
                {
                    MessageBox.Show("Please input Instrument number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInsNo.Focus();
                    return false;
                }
                if (cmbBranch.Text == "" || cmbBank.Text == "")
                {
                    MessageBox.Show("Please select bank or branch.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBranch.Focus();
                    return false;
                }
            }
            if (_nUIControl != 4)
            {
                if (lvwItemList.Items.Count <= 0)
                {
                    MessageBox.Show("No Item for collection.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (_nUIControl != 2)
                {
                    for (int i = 0; i < lvwItemList.Items.Count; i++)
                    {
                        ListViewItem itm = lvwItemList.Items[i];
                        if (lvwItemList.Items[i].Checked == true && itm.SubItems[5].Text.ToString() == "Yes" && itm.SubItems[6].Text.ToString() == "No")
                        {
                            Sum = Sum + Convert.ToDouble(itm.SubItems[4].Text.ToString()) + Convert.ToDouble(itm.SubItems[3].Text.ToString());
                        }
                    }
                    if (Sum != Convert.ToDouble(txtAmount.Text))
                    {
                        MessageBox.Show("Input Amount and Collection Amount is not same.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    for (int i = 0; i < lvwItemList.Items.Count; i++)
                    {
                        ListViewItem itm = lvwItemList.Items[i];
                        if (lvwItemList.Items[i].Checked == true && itm.SubItems[5].Text.ToString() == "Yes")
                        {
                            Sum = Sum + Convert.ToDouble(itm.SubItems[3].Text.ToString());
                        }
                    }
                    if (Sum != Convert.ToDouble(txtAmount.Text))
                    {
                        MessageBox.Show("Input Amount and Collection Amount is not same.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            else   
            {
                foreach (DataGridViewRow oItemRow in dgvItemList.Rows)
                {
                    if (oItemRow.Index < dgvItemList.Rows.Count)
                    {
                        if (oItemRow.Cells[6].Value == null || oItemRow.Cells[6].Value.ToString().Trim() == "")
                        {
                            _PrincipalAmt = 0;
                        }
                        else
                        {
                            _PrincipalAmt = Convert.ToDouble(oItemRow.Cells[6].Value.ToString().Trim());
                        }
                        if (oItemRow.Cells[7].Value == null || oItemRow.Cells[7].Value.ToString().Trim() == "")
                        {
                            _InterestAmt = 0;
                        }
                        else
                        {
                            _InterestAmt = Convert.ToDouble(oItemRow.Cells[7].Value.ToString().Trim());
                        }
                        if(_PrincipalAmt > Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim()))
                        {
                            MessageBox.Show("Principal Receive must be less or equal Receivable Principal.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (_InterestAmt > Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim()))
                        {
                            MessageBox.Show("Interest Receive must be less or equal Receivable Interest.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        _TotalAmt = _TotalAmt + (_PrincipalAmt + _InterestAmt);
                    }
                }
                if (_TotalAmt != Convert.ToDouble(txtAmount.Text))
                {
                    MessageBox.Show("Input Amount and Collection Amount is not same.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            
            return true;
        }
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            if (btSelectAll.Text == "Select All")
            {
                for (int i = 0; i < lvwItemList.Items.Count; i++)
                {
                    ListViewItem itm = lvwItemList.Items[i];
                    if (itm.SubItems[5].Text.ToString() == "Yes")
                    {
                        lvwItemList.Items[i].Checked = true;
                    }
                }
                btSelectAll.Text = "DeSelect All";
            }
            else
            {
                for (int i = 0; i < lvwItemList.Items.Count; i++)
                {
                    ListViewItem itm = lvwItemList.Items[i];
                    if (itm.SubItems[5].Text.ToString() == "Yes")
                    {
                        lvwItemList.Items[i].Checked = false;
                    }
                }
                btSelectAll.Text = "Select All";
            }
        }

        private void btnGetTotal_Click(object sender, EventArgs e)
        {
            lblTotal.Text = "?";
            double Sum = 0;
            if (_nUIControl != 4)
            {
                if (_nUIControl != 2)
                {
                    for (int i = 0; i < lvwItemList.Items.Count; i++)
                    {
                        ListViewItem itm = lvwItemList.Items[i];
                        if (lvwItemList.Items[i].Checked == true && itm.SubItems[5].Text.ToString() == "Yes" && itm.SubItems[6].Text.ToString() == "No")
                        {
                            Sum = Sum + Convert.ToDouble(itm.SubItems[4].Text.ToString()) + Convert.ToDouble(itm.SubItems[3].Text.ToString());
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < lvwItemList.Items.Count; i++)
                    {
                        ListViewItem itm = lvwItemList.Items[i];
                        if (lvwItemList.Items[i].Checked == true && itm.SubItems[5].Text.ToString() == "Yes")
                        {
                            Sum = Sum + Convert.ToDouble(itm.SubItems[3].Text.ToString());
                        }
                    }
                }
            }
            lblTotal.Text = Sum.ToString();
        }
    }
}