using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.BasicData;

namespace CJ.Win.Admin
{
    public partial class frmOfficeItemsAuthorization : Form
    {
        OfficeItemTran _oOfficeItemTran;
        OfficeItemTrans _oOfficeItemTrans;
        OfficeItem _oOfficeItem;
        int nStatus = 0;
        int nWarehouseID = 0;
        string sTranNo = "";
        int nTranID = 0;
        int nLineItemItdex= 0;
        int nQtyCount = 0;
        int nCount = 0;
        int nTerminal = 0;


        public frmOfficeItemsAuthorization()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(OfficeItemTran oOfficeItemTran)
        {

            nTranID = 0;
            nWarehouseID = 0;
            sTranNo = "";
            nStatus = 0;
            nTerminal = 0;
            nWarehouseID = oOfficeItemTran.WarehouseID;
            nTerminal = oOfficeItemTran.Terminal;
            nTranID = oOfficeItemTran.TranID;
            sTranNo = oOfficeItemTran.TranNo;
            sTranNo = oOfficeItemTran.TranNo;
            nStatus = oOfficeItemTran.Status;
            DBController.Instance.OpenNewConnection();
            oOfficeItemTran.GetOfficeItemPOS(oOfficeItemTran.TranID, oOfficeItemTran.WarehouseID);
            lblTranType.Text = oOfficeItemTran.TranTypeName;
            lblcompany.Text = oOfficeItemTran.CompanyName;
            lblStatus.Text = oOfficeItemTran.StatusName;
            lblDepartment.Text = oOfficeItemTran.DepartmentName;
            lblShowroom.Text = oOfficeItemTran.CustomerName;
            lblEmployeeName.Text = oOfficeItemTran.EmployeeName;
            if (oOfficeItemTran.TranTypeID == (int)Dictionary.StationaryTranType.Requisition)
            {
                this.Text = "Office Item Authorization";
                dgvStationaryItem.Columns[3].HeaderText = "Requi Qty";
            }
            if (oOfficeItemTran.TranTypeID == (int)Dictionary.StationaryTranType.Purchase)
            {

                this.Text = "Purchase Authorization";
                dgvStationaryItem.Columns[3].HeaderText = "Purchase Qty";
            }
            else
            {

                this.Text = "Issue Authorization";
                dgvStationaryItem.Columns[3].HeaderText = "Issue Qty";
            }
            

            if (oOfficeItemTran.Status == (int)Dictionary.OfficeTranStatus.Approve_By_HO)
            {
                btnRejected.Enabled = false;
            }
            foreach (OfficeItemTranDetail oOfficeItemTranDetail in oOfficeItemTran)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvStationaryItem);
                oRow.Cells[0].Value = oOfficeItemTranDetail.Code.ToString();
                oRow.Cells[2].Value = oOfficeItemTranDetail.ArticlesName.ToString();
                oRow.Cells[3].Value = oOfficeItemTranDetail.RequisitionQty.ToString();
                if (oOfficeItemTran.Status == (int)Dictionary.OfficeTranStatus.Approve_By_HO)
                {
                    oRow.Cells[4].Value = oOfficeItemTranDetail.AuthorizeQty.ToString();
                }
                else 
                {
                    oRow.Cells[4].Value = oOfficeItemTranDetail.RequisitionQty.ToString();
                
                }
                oRow.Cells[5].Value = oOfficeItemTranDetail.ID.ToString();
                dgvStationaryItem.Rows.Add(oRow);

            }

            GetTotalQty();
            this.Tag = oOfficeItemTran;

            this.ShowDialog();
        }

        private void dgvStationaryItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmOfficeItemSarch oForm = new frmOfficeItemSarch();
                oForm.ShowDialog();

                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvStationaryItem);

                oRow.Cells[0].Value = oForm.sCode;
                oRow.Cells[2].Value = oForm.sArticlesName;
                oRow.Cells[5].Value = oForm.sId;
                oRow.Cells[3].Value = 0;
                oRow.Cells[4].Value = 0;

                if (oForm.sCode != null)
                {
                    int nRowIndex = dgvStationaryItem.Rows.Add(oRow);

                    if (checkDuplicateOfficeItem(dgvStationaryItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvStationaryItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvStationaryItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    }

                }

            }

        }
        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sCode = "";
            if (nColumnIndex == 0 && dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateOfficeItem(dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvStationaryItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sCode = dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oOfficeItem = new OfficeItem();
                    DBController.Instance.OpenNewConnection();
                    _oOfficeItem.Code = sCode;
                    _oOfficeItem.RefreshByCode();

                    if (_oOfficeItem.Flag == false)
                    {
                        MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvStationaryItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }

                    dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oOfficeItem.ArticlesName;
                    dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = (_oOfficeItem.ID).ToString();

                    dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


        }

        private void dgvStationaryItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
        }
        private int checkDuplicateOfficeItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvStationaryItem.Rows)
            {
                if (oItemRow.Index < dgvStationaryItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }

        private void frmOfficeItemsAuthorization_Load(object sender, EventArgs e)
        {

        }
        public void GetTotalQty()
        {
            txtAuthQty.Text = "0";
            txtReqQty.Text = "0";

            foreach (DataGridViewRow oRow in dgvStationaryItem.Rows)
            {
                if (oRow.Cells[5].Value != null)
                {
                    
                    txtAuthQty.Text = Convert.ToDouble(Convert.ToDouble(txtAuthQty.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();
                    txtReqQty.Text = Convert.ToDouble(Convert.ToDouble(txtReqQty.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }
            }

        }

        private bool validateUIInput()
        {


            foreach (DataGridViewRow oItemRow in dgvStationaryItem.Rows)
            {
                if (oItemRow.Index < dgvStationaryItem.Rows.Count - nLineItemItdex)
                {
                    int nAuthorizedQty = 0;


                    if (oItemRow.Cells[3].Value == null || oItemRow.Cells[3].Value == "")
                    {
                        nAuthorizedQty = 0;
                    }
                    else
                    {
                        nAuthorizedQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    nQtyCount = nQtyCount + nAuthorizedQty;

                    
                }
            }
            if (nQtyCount == 0)
            {
                MessageBox.Show("You have to inputed at least 1 (one) Authorized Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (validateUIInput())
            {
                _oOfficeItemTran = new OfficeItemTran();
                _oOfficeItemTran.TranID = nTranID;
                _oOfficeItemTran.Status = (int)Dictionary.OfficeTranStatus.Approve_By_HO;
                _oOfficeItemTran.AuthorizeUserID = Utility.UserId;
                _oOfficeItemTran.ApprovedDate = DateTime.Now;
                _oOfficeItemTran.WarehouseID = nWarehouseID;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOfficeItemTran.AuthorizeUpdate();
                    _oOfficeItemTran.UpdateStatus();

                    foreach (DataGridViewRow oItemRow in dgvStationaryItem.Rows)
                    {
                        if (oItemRow.Index < dgvStationaryItem.Rows.Count - 1)
                        {

                            OfficeItemTranDetail _oOfficeItemTranDetail = new OfficeItemTranDetail();

                            _oOfficeItemTranDetail.ID = int.Parse(oItemRow.Cells[5].Value.ToString());
                            _oOfficeItemTranDetail.RequisitionQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                            _oOfficeItemTranDetail.AuthorizeQty = int.Parse(oItemRow.Cells[4].Value.ToString());

                            if (nCount == 0)
                            { 
                            //Delete
                                _oOfficeItemTranDetail.TranID = _oOfficeItemTran.TranID;
                                _oOfficeItemTranDetail.WarehouseID = nWarehouseID;
                                _oOfficeItemTranDetail.Delete();

                                nCount++;
                            }
                            _oOfficeItemTranDetail.Add(_oOfficeItemTran.TranID, nWarehouseID);
              
                        }
                    }

                    if (nTerminal == (int)Dictionary.Terminal.Branch_Office)
                    {

                        //oSystemInfo = new SystemInfo();
                        //oSystemInfo.Refresh();

                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_OfficeItemTran";
                        oDataTran.DataID = Convert.ToInt32(nTranID);
                        oDataTran.WarehouseID = Convert.ToInt32(nWarehouseID);
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;

                        oDataTran.AddForTDPOS();
                    }

                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Successfully Approved the Requisition # " + sTranNo, "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRejected_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to Reject the  TranNo # " + sTranNo + " ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                _oOfficeItemTran = new OfficeItemTran();
                _oOfficeItemTran.TranID = nTranID;
                _oOfficeItemTran.Status = (int)Dictionary.OfficeTranStatus.Reject_By_HO;
                _oOfficeItemTran.AuthorizeUserID = Utility.UserId;
                _oOfficeItemTran.ApprovedDate = DateTime.Now;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOfficeItemTran.AuthorizeUpdate();
                    _oOfficeItemTran.UpdateStatus();
                    _oOfficeItemTran.GetTerminal(_oOfficeItemTran.TranID);

                    _oOfficeItemTran.Refresh();
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Successfully Rejected the TranNo # " + sTranNo, "Reject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dgvStationaryItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalQty();
        }
    }
}