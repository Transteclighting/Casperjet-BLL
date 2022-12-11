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
    public partial class frmISVPartsRequisition : Form
    {

        SparePartsTransaction oSparePartsTransaction;
        SparePartsTransactionDetail oSparePartsTransactionDetail;

        ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        Job _oJob;
        SpareParts _oSpareParts;
        public SpareParts oSpareParts;
        InterServices oInterServices;
        InterService oInterService;
        Product _oProduct;


        public frmISVPartsRequisition()
        {
            InitializeComponent();
        }
        public void ShowDialog(SparePartsTransaction _oSparePartsTransaction)
        {
            this.Tag = _oSparePartsTransaction;
            txtSerialNo.Text = _oSparePartsTransaction.SerialNo.ToString();
            txtReportNo.Text = _oSparePartsTransaction.ReportNo.ToString();
            txtRemarks.Text = _oSparePartsTransaction.Remarks.ToString();
            dtPrepareDate.Value = Convert.ToDateTime(_oSparePartsTransaction.PrepareDate.ToString());
            dtReceiveDate.Value = Convert.ToDateTime(_oSparePartsTransaction.ReceiveDate.ToString());
            ctlInterService1.txtCode.Text = _oSparePartsTransaction.InterService.Code;

           foreach (SparePartsTransactionDetail oSparePartsTransactionDetail in _oSparePartsTransaction)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvRequisitionItem);
                oRow.Cells[0].Value = oSparePartsTransactionDetail.SpareParts.Code.ToString();
                oRow.Cells[2].Value = oSparePartsTransactionDetail.SpareParts.Name.ToString();
                oRow.Cells[3].Value = oSparePartsTransactionDetail.SpareParts.SalePrice.ToString();
                oRow.Cells[4].Value = oSparePartsTransactionDetail.ClaimQty.ToString();
                oRow.Cells[5].Value = oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobNo.ToString();
                oRow.Cells[7].Value = oSparePartsTransactionDetail.ReplaceJobFromCassandra.ProductName.ToString();
                oRow.Cells[8].Value = oSparePartsTransactionDetail.SpareParts.ID.ToString();
                oRow.Cells[9].Value = oSparePartsTransactionDetail.JobID.ToString();
                oRow.Cells[10].Value = oSparePartsTransactionDetail.ISVRequisitionItemID.ToString();

                dgvRequisitionItem.Rows.Add(oRow);

            }

            this.Tag = _oSparePartsTransaction;
            this.ShowDialog();
        }
        private void dgvRequisitionItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                frmSparePartSearch oForm = new frmSparePartSearch();
                oForm.ShowDialog();
                if (oForm._oSpareParts != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRequisitionItem);
                    oRow.Cells[0].Value = oForm._oSpareParts.Code;
                    oRow.Cells[2].Value = oForm._oSpareParts.Name;
                    oRow.Cells[3].Value = oForm._oSpareParts.SalePrice;
                    oRow.Cells[8].Value = oForm._oSpareParts.ID;
                    lblLineItem.Text = dgvRequisitionItem.RowCount.ToString();
                    if (oForm._oSpareParts != null)
                    {
                        int nRowIndex = dgvRequisitionItem.Rows.Add(oRow);

                        //if (checkDuplicateLineItem(dgvRequisitionItem.Rows[nRowIndex].Cells[0].Value.ToString, dgvRequisitionItem.Rows[nRowIndex].Cells[5].Value.ToString()) > 1)
                        // {
                        //     oRow.Cells[2].Value = "";
                        //     MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //     dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                        //     return;
                        // }
                        // else
                        // {
                        //     dgvRequisitionItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        // }
                    }
                }
            }
            else if (e.ColumnIndex == 6)
            {
                frmJobSearchISV oForm = new frmJobSearchISV(0);
                oForm.ShowDialog();


                dgvRequisitionItem.Rows[e.RowIndex].Cells[5].Value = oForm._oJob.JobNo;
                dgvRequisitionItem.Rows[e.RowIndex].Cells[7].Value = oForm._oJob.ProductName;
                dgvRequisitionItem.Rows[e.RowIndex].Cells[9].Value = oForm._oJob.JobID;

                if (oForm._oJob != null)
                {
                    int nRowIndex = 0;
                    if (checkDuplicateLineItem(dgvRequisitionItem.Rows[nRowIndex].Cells[0].Value.ToString(), dgvRequisitionItem.Rows[nRowIndex].Cells[5].Value.ToString()) > 1)
                    {
                        MessageBox.Show("Duplicate Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                }

            }
        }
     
        private void dgvRequisitionItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == -1 || e.RowIndex == -1)return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }

        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sSpareCode = "";

            if (nColumnIndex == 0 && dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                //if (checkDuplicateLineItem(dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString(), dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value.ToString()) > 1)
                //{
                //    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                //    return;
                //}

                try
                {
                    sSpareCode = dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oSpareParts = new SpareParts();
                    _oSpareParts.Code = sSpareCode;
                    _oSpareParts.RefreshBySPCode();

                    if (_oSpareParts.Flag != false)
                    {
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oSpareParts.Name;
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oSpareParts.SalePrice;
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (_oSpareParts.ID).ToString();

                        lblLineItem.Text = dgvRequisitionItem.RowCount.ToString();

                    }
                    else
                    {
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = "";

                        MessageBox.Show("Spare Part Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Invalied Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            string sJobNo = "";

            if (nColumnIndex == 5 )
            {
                if (checkDuplicateLineItem(dgvRequisitionItem.Rows[nRowIndex].Cells[0].Value.ToString(), dgvRequisitionItem.Rows[nRowIndex].Cells[5].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sJobNo = dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
                    _oReplaceJobFromCassandra.JobNo = sJobNo;
                    _oReplaceJobFromCassandra.RefreshByJobNoISV();

                    if (_oReplaceJobFromCassandra.Flag != false)
                    {
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oReplaceJobFromCassandra.ProductName;
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = (_oReplaceJobFromCassandra.JobID).ToString();

                        //lblLineItem.Text = dgvRequisitionItem.RowCount.ToString();

                    }
                    else
                    {
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvRequisitionItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = "";

                        MessageBox.Show("Job Number Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Invalied Job Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private int checkDuplicateLineItem(string ItemCode,string JobNo)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvRequisitionItem.Rows)
            {
                if (oItemRow.Index < dgvRequisitionItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode && oItemRow.Cells[5].Value.ToString().Trim() == JobNo)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }
        private void Save()
        {

            if (validateUIInput())
            {
                if (this.Tag == null)
                {
                    oSparePartsTransaction = new SparePartsTransaction();
                    oSparePartsTransaction = GetUISparePartsTransactionData(oSparePartsTransaction);
                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        oSparePartsTransaction.AddRequisition();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully With Requisition ID- " + oSparePartsTransaction.ISVRequisitionID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)this.Tag;
                    oSparePartsTransaction.Clear();
                    //oSparePartsTransaction = GetUISparePartsTransactionData(oSparePartsTransaction);

                    oSparePartsTransaction.InterServiceID = ctlInterService1.SelectedInterService.InterServiceID;
                    //oSparePartsTransaction.Status = (int)Dictionary.ISVRequisitionStatus.Receive;
                    oSparePartsTransaction.SerialNo = txtSerialNo.Text;
                    oSparePartsTransaction.ReportNo = txtReportNo.Text;
                    oSparePartsTransaction.Remarks = txtRemarks.Text;
                    oSparePartsTransaction.PrepareDate = dtPrepareDate.Value.Date;
                    oSparePartsTransaction.ReceiveDate = dtReceiveDate.Value.Date;

                    // Spare Parts Detail



                    //return oSparePartsTransaction;


                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oSparePartsTransaction.EditRequisition();

                        foreach (DataGridViewRow oItemRow in dgvRequisitionItem.Rows)
                        {
                            if (oItemRow.Index < dgvRequisitionItem.Rows.Count - 1)
                            {

                                SparePartsTransactionDetail oItem = new SparePartsTransactionDetail();

                                try
                                {
                                    oItem.ClaimQty = Convert.ToInt64(oItemRow.Cells[4].Value.ToString().Trim());
                                }
                                catch (Exception ex)
                                {
                                    oItem.ClaimQty = Convert.ToInt64(0);
                                }
                                oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                                oItem.JobID = Convert.ToInt32(oItemRow.Cells[9].Value.ToString().Trim());

                                if (oItemRow.Cells[10].Value != null)
                                {
                                    oItem.ISVRequisitionItemID = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());
                                    oItem.ISVRequisitionID = oSparePartsTransaction.ISVRequisitionID;
                                    oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                                    oItem.ClaimQty = Convert.ToInt64(oItemRow.Cells[4].Value.ToString().Trim());
                                    oItem.JobID = Convert.ToInt32(oItemRow.Cells[9].Value.ToString().Trim());

                                    oItem.UpdateRequisitionItemEditMode();
                                }
                                else
                                {
                                    oItem = new SparePartsTransactionDetail();
                                    oItem.ISVRequisitionID = oSparePartsTransaction.ISVRequisitionID;
                                    oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                                    oItem.ClaimQty = Convert.ToInt64(oItemRow.Cells[4].Value.ToString().Trim());
                                    oItem.JobID = Convert.ToInt32(oItemRow.Cells[9].Value.ToString().Trim());

                                    oItem.AddRequisitionItemEditMode();
                                }
                                //if (oItem.ISVRequisitionItemID.ToString() != oItemRow.Cells[10].Value.ToString())
                                //{

                                //}

                            }
                        }

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully; Requisition ID- " + oSparePartsTransaction.ISVRequisitionID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
        }

        public SparePartsTransaction GetUISparePartsTransactionData(SparePartsTransaction oSparePartsTransaction)
        {
            oSparePartsTransaction.InterServiceID = ctlInterService1.SelectedInterService.InterServiceID;
            oSparePartsTransaction.Status = (int)Dictionary.ISVRequisitionStatus.Receive;
            oSparePartsTransaction.SerialNo = txtSerialNo.Text;
            oSparePartsTransaction.ReportNo = txtReportNo.Text;
            oSparePartsTransaction.Remarks = txtRemarks.Text;
            oSparePartsTransaction.PrepareDate = dtPrepareDate.Value.Date;
            oSparePartsTransaction.ReceiveDate = dtReceiveDate.Value.Date;

            // Spare Parts Detail

            foreach (DataGridViewRow oItemRow in dgvRequisitionItem.Rows)
            {
                if (oItemRow.Index < dgvRequisitionItem.Rows.Count - 1)
                {

                    SparePartsTransactionDetail oItem = new SparePartsTransactionDetail();

                    try
                    {
                        oItem.ClaimQty = Convert.ToInt64(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.ClaimQty = Convert.ToInt64(0);
                    }
                    oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                    oItem.JobID = Convert.ToInt32(oItemRow.Cells[9].Value.ToString().Trim());

                    oSparePartsTransaction.Add(oItem);


                }
            }

            return oSparePartsTransaction;
        }

        private void Clear()
        {
            DBController.Instance.OpenNewConnection();
            txtRemarks.Text = "";
            txtReportNo.Text = "";
            txtSerialNo.Text = "";
            dtPrepareDate.Value = DateTime.Today.Date;
            dtReceiveDate.Value = DateTime.Today.Date;
            ctlInterService1.txtCode.Text = "";
            dgvRequisitionItem.Rows.Clear();
            lblLineItem.Text = "0";
            lblTotalQty.Text = "0";
            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            #region Transaction Master Information Validation

            if (ctlInterService1.SelectedInterService == null || ctlInterService1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select Inter Service", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlInterService1.Focus();
                return false;
            }

            #endregion

            #region Transaction Details Information Validation

            if (dgvRequisitionItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Spare Parts ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvRequisitionItem.Rows)
            {
                if (oItemRow.Index < dgvRequisitionItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[8].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Part code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[8].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Part Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[9].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[9].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItemRow.Cells[4].Value == null || int.Parse(oItemRow.Cells[4].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("Please Input Claim Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            return true;
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                Clear();

            }
        }

        private void frmISVPartsRequisition_Load(object sender, EventArgs e)
        {
            lblLineItem.Text = "0";
            lblTotalQty.Text = "0";
        }
    }
}