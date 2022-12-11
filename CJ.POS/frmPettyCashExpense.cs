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

namespace CJ.POS
{
    public partial class frmPettyCashExpense : Form
    {
        SystemInfo oSystemInfo;
       public bool _ISLoad = false;
        PettyCashExpense oPettyCashExpense;
        int _nType = 0;
        int nID = 0;
        string sCode = "";

        public frmPettyCashExpense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            #region Transaction Details Information Validation

            if (dgvItem.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Valid Data ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Purposre", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[2].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Purposre", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == null)
                    {
                        MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        double tmp = Convert.ToDouble(oItemRow.Cells[3].Value);
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            return true;
        }
        public PettyCashExpense GetData(PettyCashExpense _oPettyCashExpense)
        {
            _oPettyCashExpense.WarehouseID = oSystemInfo.WarehouseID;
            _oPettyCashExpense.Remarks = txtRemarks.Text;
            _oPettyCashExpense.CreateDate = dtDate.Value.Date;
            _oPettyCashExpense.CreateUserID = Utility.UserId;
            _oPettyCashExpense.Status = (int)Dictionary.PettyCashExpenseStatus.Create;

            // Item Details
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    PettyCashExpenseDetail _oPettyCashExpenseDetail = new PettyCashExpenseDetail();
                    _oPettyCashExpenseDetail.ExpenseHeadID = int.Parse(oItemRow.Cells[4].Value.ToString());
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
                    _oPettyCashExpenseDetail.ApprovedAmount = 0;
                    if (_oPettyCashExpenseDetail.Amount > 0)
                        _oPettyCashExpense.Add(_oPettyCashExpenseDetail);

                }
            }

            return _oPettyCashExpense;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPettyCashExpense = new PettyCashExpense();
                    oPettyCashExpense = GetData(oPettyCashExpense);
                    if (this.Tag == null)
                    {
                        oPettyCashExpense.Add(oSystemInfo.Shortcode);
                        _ISLoad = true;
                    }
                    else
                    {
                        oPettyCashExpense.ID = nID;
                        oPettyCashExpense.ExpanceCode = sCode;
                        oPettyCashExpense.UpdateDate = dtDate.Value.Date;
                        oPettyCashExpense.UpdateUserID = Utility.UserId;
                        oPettyCashExpense.Edit();
                        _ISLoad = true;
                    }
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_PettyCashExpense";
                    oDataTran.DataID = oPettyCashExpense.ID;
                    oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }

                    DBController.Instance.CommitTran();
                    if (this.Tag == null)
                    {
                        MessageBox.Show("Successfully Add Petty Cash Expense. Expance#: " + oPettyCashExpense.ExpanceCode.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Successfully Edit Petty Cash Expense. Expance#: " + oPettyCashExpense.ExpanceCode.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();



                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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

            PettyCashExpense _oPettyCashExpense = new PettyCashExpense();
            _oPettyCashExpense.GetItem(nID, oPettyCashExpense.WarehouseID);
            TELLib oTELLib = new TELLib();
            foreach (PettyCashExpenseDetail oPettyCashExpenseDetail in _oPettyCashExpense)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvItem);

                oRow.Cells[0].Value = oPettyCashExpenseDetail.Description.ToString();
                oRow.Cells[1].Value = oPettyCashExpenseDetail.VoucherNo.ToString();
                oRow.Cells[2].Value = oPettyCashExpenseDetail.Purpose;
                oRow.Cells[3].Value = oTELLib.TakaFormat(oPettyCashExpenseDetail.Amount);
                oRow.Cells[4].Value = oPettyCashExpenseDetail.ExpenseHeadID;
                dgvItem.Rows.Add(oRow);
            }
            

            this.ShowDialog();
        }
        private void frmPettyCashExpense_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();

            if (this.Tag == null)
            {
                this.Text = "Add New Petty Cash Expense";
                dtDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
                PettyCashExpense _oPettyCashExpense = new PettyCashExpense();
                _oPettyCashExpense.GetItem(0,-1);
                TELLib oTELLib = new TELLib();
                foreach (PettyCashExpenseDetail oPettyCashExpenseDetail in _oPettyCashExpense)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvItem);

                    oRow.Cells[0].Value = oPettyCashExpenseDetail.Description.ToString();
                    oRow.Cells[1].Value = oPettyCashExpenseDetail.VoucherNo.ToString();
                    oRow.Cells[2].Value = oPettyCashExpenseDetail.Purpose;
                    oRow.Cells[3].Value = oTELLib.TakaFormat(oPettyCashExpenseDetail.Amount);
                    oRow.Cells[4].Value = oPettyCashExpenseDetail.ExpenseHeadID;
                    dgvItem.Rows.Add(oRow);
                }
            }
            else
            {
                this.Text = "Edit Petty Cash Expense";
            }

            
        }
    }
}
