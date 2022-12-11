using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.Win.Accounts
{
    public partial class frmPettyCashExpense : Form
    {
        public bool _ISLoad = false;
        PettyCashExpense oPettyCashExpense;
        int nID = 0;
        string sCode = "";
        int nWarehouseID = 0;


        public frmPettyCashExpense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public PettyCashExpense GetData(PettyCashExpense _oPettyCashExpense)
        {
            // Item Details
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    PettyCashExpenseDetail _oPettyCashExpenseDetail = new PettyCashExpenseDetail();
                   _oPettyCashExpenseDetail.WarehouseID = _oPettyCashExpense.WarehouseID;
                    _oPettyCashExpenseDetail.ExpenseHeadID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    try
                    {
                        _oPettyCashExpenseDetail.VoucherNo = (oItemRow.Cells[1].Value.ToString());
                    }
                    catch
                    {
                        _oPettyCashExpenseDetail.VoucherNo = "";
                    }
                    try
                    {
                        _oPettyCashExpenseDetail.Purpose = (oItemRow.Cells[2].Value.ToString());
                    }
                    catch
                    {
                        _oPettyCashExpenseDetail.Purpose = "";
                    }
                    try
                    {
                        _oPettyCashExpenseDetail.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                    }
                    catch
                    {
                        _oPettyCashExpenseDetail.Amount = 0;
                    }
                    _oPettyCashExpenseDetail.ApprovedAmount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString()); 
                    if (_oPettyCashExpenseDetail.Amount > 0)
                        _oPettyCashExpense.Add(_oPettyCashExpenseDetail);

                }
            }

            return _oPettyCashExpense;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save((int)Dictionary.PettyCashExpenseStatus.Approved);
            this.Close();
        }
        private void Save(int nStatus)
        {
            PettyCashExpense oPettyCashExpense = (PettyCashExpense)this.Tag;
            try
            {
                DBController.Instance.BeginNewTransaction();
                if (nStatus == (int)Dictionary.PettyCashExpenseStatus.Approved)
                {
                    oPettyCashExpense = GetData(oPettyCashExpense);
                }
                oPettyCashExpense.ID = nID;
                oPettyCashExpense.ApproveDate = DateTime.Now;
                oPettyCashExpense.ApproveUserID = Utility.UserId;
                oPettyCashExpense.Status = nStatus;
                oPettyCashExpense.Remarks = txtRemarks.Text;
                oPettyCashExpense.WarehouseID = nWarehouseID;
                oPettyCashExpense.Approved(nStatus);
                _ISLoad = true;

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_PettyCashExpense";
                oDataTran.DataID = oPettyCashExpense.ID;
                oDataTran.WarehouseID = nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckDataByWHID() == false)
                {
                    oDataTran.AddForTDPOS();
                }

                DBController.Instance.CommitTran();

                MessageBox.Show("Successfully Edit Petty Cash Expense. Expance#: " + oPettyCashExpense.ExpanceCode.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void ShowDialog(PettyCashExpense oPettyCashExpense)
        {
            this.Tag = oPettyCashExpense;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            nID = oPettyCashExpense.ID;
            sCode = oPettyCashExpense.ExpanceCode;
            dtDate.Value = oPettyCashExpense.CreateDate;
            txtRemarks.Text = oPettyCashExpense.Remarks;
            nWarehouseID = oPettyCashExpense.WarehouseID;
            PettyCashExpense _oPettyCashExpense = new PettyCashExpense();
            _oPettyCashExpense.GetItem(nID,oPettyCashExpense.WarehouseID);
            TELLib oTELLib = new TELLib();
            foreach (PettyCashExpenseDetail oPettyCashExpenseDetail in _oPettyCashExpense)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvItem);

                oRow.Cells[0].Value = oPettyCashExpenseDetail.Description.ToString();
                oRow.Cells[1].Value = oPettyCashExpenseDetail.VoucherNo.ToString();
                oRow.Cells[2].Value = oPettyCashExpenseDetail.Purpose;
                oRow.Cells[3].Value = oTELLib.TakaFormat(oPettyCashExpenseDetail.Amount);
                oRow.Cells[4].Value = oTELLib.TakaFormat(oPettyCashExpenseDetail.Amount);
                oRow.Cells[5].Value = oPettyCashExpenseDetail.ExpenseHeadID;
                dgvItem.Rows.Add(oRow);
            }
            

            this.ShowDialog();
        }
        private void frmPettyCashExpense_Load(object sender, EventArgs e)
        {
            //if (!DBController.Instance.CheckConnection())
            //{
            //    DBController.Instance.OpenNewConnection();
            //}
            //oSystemInfo = new SystemInfo();
            //oSystemInfo.Refresh();

            //if (this.Tag == null)
            //{
            //    this.Text = "Add New Petty Cash Expense";
            //    dtDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            //    PettyCashExpense _oPettyCashExpense = new PettyCashExpense();
            //    _oPettyCashExpense.GetItem(0);
            //    TELLib oTELLib = new TELLib();
            //    foreach (PettyCashExpenseDetail oPettyCashExpenseDetail in _oPettyCashExpense)
            //    {
            //        DataGridViewRow oRow = new DataGridViewRow();
            //        oRow.CreateCells(dgvItem);

            //        oRow.Cells[0].Value = oPettyCashExpenseDetail.Description.ToString();
            //        oRow.Cells[1].Value = oPettyCashExpenseDetail.VoucherNo.ToString();
            //        oRow.Cells[2].Value = oPettyCashExpenseDetail.Purpose;
            //        oRow.Cells[3].Value = oTELLib.TakaFormat(oPettyCashExpenseDetail.Amount);
            //        oRow.Cells[4].Value = oPettyCashExpenseDetail.ExpenseHeadID;
            //        dgvItem.Rows.Add(oRow);
            //    }
            //}
            //else
            //{
            //    this.Text = "Edit Petty Cash Expense";
            //}

            
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            Save((int)Dictionary.PettyCashExpenseStatus.Reject);
        }
    }
}
