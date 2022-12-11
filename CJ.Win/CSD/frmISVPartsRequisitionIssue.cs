using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win
{
    public partial class frmISVPartsRequisitionIssue : Form
    {
        SparePartsTransaction _oSparePartsTransaction;
        SparePartsTransactions oSparePartsTransactions;
        SparePartsTransactionDetail _oSparePartsTransactionDetail;
        SPTranCassandra oSPTranCassandra;
        SPTranItemCassandra oSPTranItemCassandra;
        SparePartStockCassandra oSparePartStockCassandra;
        SparePartsIssueFromLoanSet oSparePartsIssueFromLoanSet;
        IssuePartsCassandra oIssuePartsCassandra;
        LoanProductCassandra _oLoanProductCassandra;

        public frmISVPartsRequisitionIssue()
        {
            InitializeComponent();
        }

        //private void getStatus()
        //{
        //    //Paid Job Status


        //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ISVRequisitionStatus)))
        //    {
        //        cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ISVRequisitionStatus), GetEnum));
        //    }
        //    cmbStatus.SelectedIndex = cmbStatus.Items.Count - 6;

        //}

        private void DataLoadControl()
        {
            _oSparePartsTransaction = (SparePartsTransaction)this.Tag;

            oSparePartsTransactions = new SparePartsTransactions();
            oSparePartsTransactions.RefreshByRequisitionIDView(_oSparePartsTransaction.ISVRequisitionID);
            lvwISVPartsRequisitionIssued.Items.Clear();

            foreach (SparePartsTransactionDetail _oSparePartsTransactionDetail in oSparePartsTransactions)
            {
                ListViewItem oItem = lvwISVPartsRequisitionIssued.Items.Add(_oSparePartsTransactionDetail.SpareParts.Code.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.SpareParts.Name.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.ClaimQty.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobNo.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.SerarchProduct.ProductName.ToString());
                if (_oSparePartsTransactionDetail.SubStatus == (int)Dictionary.ISVRequisitionSubStatus.FromStock)
                {
                    oItem.SubItems.Add("FromStock");
                }
                else if (_oSparePartsTransactionDetail.SubStatus == (int)Dictionary.ISVRequisitionSubStatus.FromLoanSet)
                {
                    oItem.SubItems.Add("FromLoanSet");
                }
                oItem.SubItems.Add(_oSparePartsTransactionDetail.LoanCode.ToString());

                oItem.Tag = _oSparePartsTransaction;
            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwISVPartsRequisitionIssued.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwISVPartsRequisitionIssued.Items)
                {
                    if (oItem.SubItems[5].Text == Dictionary.ISVRequisitionSubStatus.FromStock.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ISVRequisitionSubStatus.FromLoanSet.ToString())
                    {
                        oItem.BackColor = Color.BurlyWood;
                    }

                }
            }
        }
        public void ShowDialog(SparePartsTransaction _oSparePartsTransaction)
        {
            this.Tag = _oSparePartsTransaction;
            lblRequisitionID.Text = _oSparePartsTransaction.ISVRequisitionID.ToString();
            lblReportNo.Text = _oSparePartsTransaction.ReportNo.ToString();
            lblSerialNo.Text = _oSparePartsTransaction.SerialNo.ToString();
            lblReceiveDate.Text = _oSparePartsTransaction.ReceiveDate.Date.ToString("dd-MMM-yyyy");
            lblPrepareDate.Text = _oSparePartsTransaction.PrepareDate.Date.ToString("dd-MMM-yyyy");
            lblInterService.Text = _oSparePartsTransaction.InterService.Code + " / " + _oSparePartsTransaction.InterService.Name;

            _oSparePartsTransaction.RefreshByRequisitionID();

              foreach (SparePartsTransactionDetail _oSparePartsTransactionDetail in _oSparePartsTransaction)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvRequisitionItemIssue);
                oRow.Cells[0].Value = _oSparePartsTransactionDetail.SpareParts.Code.ToString();
                oRow.Cells[1].Value = _oSparePartsTransactionDetail.SpareParts.Name.ToString();
                oRow.Cells[2].Value = _oSparePartsTransactionDetail.SpareParts.SalePrice.ToString();
                oRow.Cells[3].Value = Convert.ToInt64(_oSparePartsTransactionDetail.ClaimQty.ToString());
                oRow.Cells[4].Value = Convert.ToInt64(_oSparePartsTransactionDetail.SparePartStockCassandra.SoundQty.ToString());
                oRow.Cells[5].Value = _oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobNo.ToString();
                oRow.Cells[6].Value = _oSparePartsTransactionDetail.SerarchProduct.ProductName.ToString();
                oRow.Cells[7].Value = _oSparePartsTransactionDetail.SubStatusName.ToString();
                oRow.Cells[11].Value = Convert.ToDateTime(_oSparePartsTransactionDetail.EDD);
                oRow.Cells[12].Value = _oSparePartsTransactionDetail.ISVRequisitionItemID.ToString();
                oRow.Cells[14].Value = _oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobID.ToString();
                oRow.Cells[15].Value = _oSparePartsTransactionDetail.SpareParts.ID;
                oRow.Cells[16].Value = _oSparePartsTransactionDetail.SpareParts.CostPrice.ToString();

                dgvRequisitionItemIssue.Rows.Add(oRow);
            }

            this.Tag = _oSparePartsTransaction;

            this.ShowDialog();
        }
        private void dgvRequisitionItemIssue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                frmSearchLoanProduct oForm = new frmSearchLoanProduct();
                oForm.ShowDialog();
                if (oForm._oLoanProductCassandra != null)
                {
                    dgvRequisitionItemIssue.Rows[e.RowIndex].Cells[8].Value = oForm._oLoanProductCassandra.JobCardNo;
                    dgvRequisitionItemIssue.Rows[e.RowIndex].Cells[10].Value = oForm._oLoanProductCassandra.ReplaceJobFromCassandra.ProductName;
                    dgvRequisitionItemIssue.Rows[e.RowIndex].Cells[13].Value = oForm._oLoanProductCassandra.ID;
                }
            }
           
        }
         private void dgvRequisitionItemIssue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex ==-1 || e.RowIndex ==-1)return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sLoanProductCode = "";

            if (nColumnIndex == 8 && dgvRequisitionItemIssue.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                try
                {
                    sLoanProductCode = dgvRequisitionItemIssue.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oLoanProductCassandra = new LoanProductCassandra();
                    _oLoanProductCassandra.JobCardNo = sLoanProductCode;
                    _oLoanProductCassandra.RefreshByJobCardNo();

                    if (_oLoanProductCassandra.Flag != false)
                    {
                        dgvRequisitionItemIssue.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oLoanProductCassandra.ProductName;
                        dgvRequisitionItemIssue.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = (_oLoanProductCassandra.ID).ToString();

                    }
                    else
                    {
                        dgvRequisitionItemIssue.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvRequisitionItemIssue.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = null;

                        MessageBox.Show("Loan Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Invalied Loan Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        //public SPTranCassandra GetUISPTranCassandraData(SPTranCassandra oSPTranCassandra)
        //{

        //    // Spare Parts Detail

        //    foreach (DataGridViewRow oItemRow in dgvRequisitionItemIssue.Rows)
        //    {
        //        if (oItemRow.Index < dgvRequisitionItemIssue.Rows.Count)
        //        {

        //            SPTranItemCassandra oItems = new SPTranItemCassandra();

        //            if (oItemRow.Cells[7].Value.ToString().Trim() == "FromStock" || oItemRow.Cells[7].Value.ToString().Trim() == "FromLoanSet")
        //            {
        //                oItems.SparePartID = Convert.ToInt32(oItemRow.Cells[15].Value.ToString().Trim());
        //                oItems.SoundQty = Convert.ToInt32(oItemRow.Cells[3].Value.ToString().Trim());
        //                oItems.CostPrice = Convert.ToInt32(oItemRow.Cells[16].Value.ToString().Trim());
        //                oItems.SalePrice = Convert.ToInt32(oItemRow.Cells[2].Value.ToString().Trim());
        //                oSPTranCassandra.Add(oItems);
        //            }
        //            else
        //            {

        //            }
        //        }

        //    }

        //    return oSPTranCassandra;
        //}

        private void Save()
        {
            if (dgvRequisitionItemIssue.Rows.Count != 0)
            {
                SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)this.Tag;

                oSparePartsTransaction.Clear();

                oSPTranCassandra = new SPTranCassandra();
                oSparePartStockCassandra = new SparePartStockCassandra();
                oSparePartsIssueFromLoanSet = new SparePartsIssueFromLoanSet();
                oSPTranItemCassandra = new SPTranItemCassandra();
                oIssuePartsCassandra = new IssuePartsCassandra();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgvRequisitionItemIssue.Rows)
                    {
                        if (oItemRow.Index < dgvRequisitionItemIssue.Rows.Count)
                        {
                            SPTranCassandra oItem = new SPTranCassandra();
                            oSPTranCassandra.JobID = Convert.ToInt32(oItemRow.Cells[14].Value.ToString().Trim());
                            oSPTranCassandra.InterServiceID = oSparePartsTransaction.InterServiceID;
                            oSPTranItemCassandra.SparePartID = Convert.ToInt32(oItemRow.Cells[15].Value.ToString().Trim());
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "FromStock" || oItemRow.Cells[7].Value.ToString().Trim() == "FromLoanSet")
                            {
                                if (oSPTranCassandra.CheckSPTranJobID())
                                {
                                    oSPTranCassandra.AddSPTranIssueParts();
                                }
                                else
                                {
                                }
                                if (oSPTranItemCassandra.CheckSPTranItem())
                                {
                                    SPTranCassandra oSPTC = new SPTranCassandra();
                                    oSPTC.JobID = Convert.ToInt32(oItemRow.Cells[14].Value.ToString().Trim());
                                    oSPTC.RefreshByJobID();
                                    oSPTranItemCassandra.SPTranID = oSPTC.SPTranID;
                                    oSPTranItemCassandra.SparePartID = Convert.ToInt32(oItemRow.Cells[15].Value.ToString().Trim());
                                    oSPTranItemCassandra.SoundQty = Convert.ToInt32(oItemRow.Cells[3].Value.ToString().Trim());
                                    oSPTranItemCassandra.CostPrice = Convert.ToInt32(oItemRow.Cells[16].Value.ToString().Trim());
                                    oSPTranItemCassandra.SalePrice = Convert.ToInt32(oItemRow.Cells[2].Value.ToString().Trim());
                                    oSPTranItemCassandra.AddSPTranItem();
                                }
                                else
                                {
                                }
                                oIssuePartsCassandra.SparePartID = Convert.ToInt32(oItemRow.Cells[15].Value.ToString().Trim());
                                oIssuePartsCassandra.JobID = Convert.ToInt32(oItemRow.Cells[14].Value.ToString().Trim());
                                oIssuePartsCassandra.IssueQty = Convert.ToInt32(oItemRow.Cells[3].Value.ToString().Trim());
                                if (oIssuePartsCassandra.CheckIssuePartsAgainstJob())
                                {
                                    oIssuePartsCassandra.AddIssueParts();
                                }
                                else
                                {
                                    oIssuePartsCassandra.UpdateIssueParts();
                                }
                            }
                            else
                            {
                            }
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "FromStock")
                            {
                                oSparePartStockCassandra.SparePartID = Convert.ToInt32(oItemRow.Cells[15].Value.ToString().Trim());
                                oSparePartStockCassandra.SoundQty = Convert.ToInt64(oItemRow.Cells[3].Value.ToString());
                                oSparePartStockCassandra.TotalQty = Convert.ToInt64(oItemRow.Cells[3].Value.ToString());
                                oSparePartStockCassandra.UpdateSprePartsStock();
                            }
                            else
                            {
                            }
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "FromLoanSet")
                            {
                                oSparePartsIssueFromLoanSet.SparePartsID = Convert.ToInt32(oItemRow.Cells[15].Value.ToString().Trim());
                                oSparePartsIssueFromLoanSet.JobID = Convert.ToInt32(oItemRow.Cells[14].Value.ToString().Trim());
                                oSparePartsIssueFromLoanSet.Quantity = Convert.ToInt32(oItemRow.Cells[3].Value.ToString().Trim());

                                LoanProductCassandra oLoanProductCassandra = new LoanProductCassandra();
                                oLoanProductCassandra.ID = Convert.ToInt32(oItemRow.Cells[13].Value.ToString().Trim());
                                oLoanProductCassandra.RefreshByID();
                                oSparePartsIssueFromLoanSet.DamageProductID = oLoanProductCassandra.ProductID;
                                oSparePartsIssueFromLoanSet.SerialNo = oLoanProductCassandra.SerialNo;
                                if (oSparePartsIssueFromLoanSet.CheckTran())
                                {
                                    oSparePartsIssueFromLoanSet.AddSpareFromLoanSet();
                                }
                                else
                                {
                                    oSparePartsIssueFromLoanSet.UpdateSpareFromLoanSet();
                                }
                            }
                            else
                            {
                            }
                        }
                    }
                    oSparePartsTransaction.Status = (int)Dictionary.ISVRequisitionStatus.Receive;
                    oSparePartsTransaction.UpdateStatus();
                    _oSparePartsTransactionDetail = new SparePartsTransactionDetail();

                    #region SparePartsTransactionDetail Update by SubStatus

                    foreach (DataGridViewRow oItemRow in dgvRequisitionItemIssue.Rows)
                    {
                        if (oItemRow.Index < dgvRequisitionItemIssue.Rows.Count)
                        {
                            SparePartsTransactionDetail oItem = new SparePartsTransactionDetail();

                            if (oItemRow.Cells[7].Value.ToString().Trim() == "FromStock")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                oItem.SubStatus = (int)Dictionary.ISVRequisitionSubStatus.FromStock;
                                oItem.LoanProductID = 0;
                                oItem.EDD = null;
                            }
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "FromLoanSet")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                oItem.SubStatus = (int)Dictionary.ISVRequisitionSubStatus.FromLoanSet;
                                oItem.LoanProductID = Convert.ToInt32(oItemRow.Cells[13].Value.ToString().Trim());
                                oItem.EDD = null;
                            }
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "LocalPurchase")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                oItem.SubStatus = (int)Dictionary.ISVRequisitionSubStatus.LocalPurchase;
                                oItem.LoanProductID = 0;
                                oItem.EDD = Convert.ToDateTime(oItemRow.Cells[11].Value.ToString().Trim());
                            }
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "ForeignOrder")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                oItem.SubStatus = (int)Dictionary.ISVRequisitionSubStatus.ForeignOrder;
                                oItem.LoanProductID = 0;
                                oItem.EDD = Convert.ToDateTime(oItemRow.Cells[11].Value.ToString().Trim());
                            }
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "LoanRequisition")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                oItem.SubStatus = (int)Dictionary.ISVRequisitionSubStatus.LoanRequisition;
                                oItem.LoanProductID = 0;
                                oItem.EDD = Convert.ToDateTime(oItemRow.Cells[11].Value.ToString().Trim());
                            }
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "Suspend")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                oItem.SubStatus = (int)Dictionary.ISVRequisitionSubStatus.Suspend;
                                oItem.LoanProductID = 0;
                                oItem.EDD = null;
                            }
                            if (oItemRow.Cells[7].Value.ToString().Trim() == "Rejected")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                oItem.SubStatus = (int)Dictionary.ISVRequisitionSubStatus.Rejected;
                                oItem.LoanProductID = 0;
                                oItem.EDD = null;
                            }
                            oItem.UpdateRequisitionItem();
                        }
                    }
                    #endregion

                    #region Create data for communication

                    foreach (DataGridViewRow oItemRow in dgvRequisitionItemIssue.Rows)
                    {
                        if (oItemRow.Index < dgvRequisitionItemIssue.Rows.Count)
                        {
                            ISVSpareCommunication oItem = new ISVSpareCommunication();


                            if (oItemRow.Cells[7].Value.ToString().Trim() == "LocalPurchase" || 
                                oItemRow.Cells[7].Value.ToString().Trim() == "ForeignOrder" ||
                                oItemRow.Cells[7].Value.ToString().Trim() == "LoanRequisition" ||
                                oItemRow.Cells[7].Value.ToString().Trim() == "Suspend" ||
                                oItemRow.Cells[7].Value.ToString().Trim() == "Rejected")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                oItem.EDD = Convert.ToDateTime(oItemRow.Cells[11].Value.ToString().Trim());

                                if (oItem.CheckRequisitionItemISVRIIDNDate())
                                {
                                    oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());
                                    oItem.EDD = Convert.ToDateTime(oItemRow.Cells[11].Value.ToString().Trim());
                                    oItem.AddCommunicationableData();
                                }
                                else
                                {
                                }

                            }
                            else
                            { 
                            }
                            
                        }
                    }

                    #endregion

                    #region Update Communication if Issue

                    foreach (DataGridViewRow oItemRow in dgvRequisitionItemIssue.Rows)
                    {
                        if (oItemRow.Index < dgvRequisitionItemIssue.Rows.Count)
                        {
                            ISVSpareCommunication oItem = new ISVSpareCommunication();

                            if (oItemRow.Cells[7].Value.ToString().Trim() == "FromStock" || oItemRow.Cells[7].Value.ToString().Trim() == "FromLoanSet")
                            {
                                oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString().Trim());

                                if (oItem.CheckRequisitionItemID())
                                {

                                }
                                else
                                {
                                    oItem.IsIssue = (int)Dictionary.InquiryCommunicationStatus.True;
                                    oItem.UpdateIssue();
                                }

                            }
                            else
                            {
                            }

                        }
                    }
                    #endregion

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Issue Successfully; Requisition ID- " + oSparePartsTransaction.ISVRequisitionID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                DBController.Instance.CommitTransaction();
                MessageBox.Show("There is no item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
                              
        private bool validateUIInput()
        {

            foreach (DataGridViewRow oItemRow in dgvRequisitionItemIssue.Rows)
            {
                if (oItemRow.Index < dgvRequisitionItemIssue.Rows.Count)
                {
                    if (oItemRow.Cells[7].Value.ToString().Trim() == "FromStock")
                    {
                        int SPartID = Convert.ToInt32(oItemRow.Cells[15].Value.ToString().Trim());
                        long sum = 0;
                        

                        foreach (DataGridViewRow oRow in dgvRequisitionItemIssue.Rows)
                        {
                            if (oRow.Index < dgvRequisitionItemIssue.Rows.Count)
                            {
                                if (Convert.ToInt32(oRow.Cells[15].Value.ToString().Trim()) == SPartID)
                                {
                                    sum = sum + Convert.ToInt64(oItemRow.Cells[3].Value.ToString());
                                }
                            }
                        }
                        SparePartStockCassandra oSPSC = new SparePartStockCassandra();
                        oSPSC.SparePartID = SPartID;
                        oSPSC.RefreshSpareID();
                        if (sum > oSPSC.SoundQty)
                        {
                            MessageBox.Show("Claim Qty must be less or equal Stock Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                    }


                    if (oItemRow.Cells[7].Value.ToString().Trim() == "FromLoanSet")
                    {
                        if (oItemRow.Cells[8].Value == null || oItemRow.Cells[8].Value.ToString().Trim() == "" ||
                            oItemRow.Cells[10].Value == null || oItemRow.Cells[13].Value == null || oItemRow.Cells[13].Value == "")
                        {
                            MessageBox.Show("Please Input Loan Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (oItemRow.Cells[7].Value.ToString().Trim() == "LocalPurchase" ||
                        oItemRow.Cells[7].Value.ToString().Trim() == "ForeignOrder" ||
                        oItemRow.Cells[7].Value.ToString().Trim() == "LoanRequisition" ||
                        oItemRow.Cells[7].Value.ToString().Trim() == "Suspend")
                    {
                        if (Convert.ToDateTime(oItemRow.Cells[11].Value) <= DateTime.Today)
                        {
                            MessageBox.Show("The EDD Must be greater than computer date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }


                }
            }
            

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void frmISVPartsRequisitionIssue_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}