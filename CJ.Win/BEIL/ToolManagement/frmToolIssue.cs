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
using CJ.Class.BEIL;
namespace CJ.Win.BEIL.Tool_Management
{
    public partial class frmToolIssue : Form
    {
        int _ToolTranID = 0;
        int _nStatus = 0;
        string _ncurrentForm;
        public bool _bActionSave = false;
        int totalSoundStock = 0;
        int stockAvailability = 0;

        ToolTypes oToolTypes;
        private ToolTypes _oToolTypes;

        Tools oTools;
        private Tools _oTools;

        ToolTran oToolTran;
        private ToolTran _oToolTran;

        ToolTrans oToolTrans;
        private ToolTrans _oToolTrans;

        ToolTranItem oToolTranItem;
        private ToolTranItem _oToolTranItem;

        ToolStock oToolStock;
        private ToolStock _oToolStock;

        ToolStocks oToolStocks;
        private ToolStocks _oToolStocks;
        public frmToolIssue(int nStatus, string currentForm)
        {
            _nStatus = nStatus;
            _ncurrentForm = currentForm;
            InitializeComponent();
        }


        private void frmToolIssue_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
        }

        public void ShowDialog(ToolTran oToolTran)
        {
            this.Tag = oToolTran;
            _ToolTranID = oToolTran.ToolTranID;
            ctlEmployee1.txtCode.Text = oToolTran.EmployeeCode;
            ctlEmployee1.txtDescription.Text = oToolTran.EmployeeName;
            dtIssueDate.Value = oToolTran.TranDate;
            txtRemarks.Text = oToolTran.Remarks.ToString();
            LoadCombo();

            //cmb.SelectedIndex = _oBanks.GetIndexByID(oEMIBankMapping.BankID) + 1;
            //cmbTenure.SelectedIndex = _oEMITenures.GetIndex(oEMIBankMapping.EMITenureID) + 1;

            _oToolTrans = new ToolTrans();
            _oToolStock = new ToolStock();
            _oToolStocks = new ToolStocks();

            _oToolTrans.GetToolTranItems(oToolTran.ToolTranID);

            foreach (ToolTranItem ooToolTranItem in _oToolTrans)
            {
                Tools ooTools = new Tools();

                _oToolStock = new ToolStock();

                ooTools.GetToolforEdit(ooToolTranItem.ToolID);

                foreach (Tool ooTool in ooTools)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItems);
                    oRow.Cells[0].Value = ooTool.ToolTypeName;
                    oRow.Cells[1].Value = ooTool.ToolName;
                    oRow.Cells[2].Value = ooToolTranItem.Qty;
                    oRow.Cells[3].Value = ooTool.ToolID;

                    oRow.Cells[2].Style.BackColor = Color.White;

                    dgvLineItems.Rows.Add(oRow);

                }

                _oToolStock.ToolID = ooToolTranItem.ToolID;
                _oToolStock.SoundStock = ooToolTranItem.Qty;
                _oToolStocks.Add(_oToolStock);
            }

            this.ShowDialog();
        }


        private void LoadCombo()
        {
            _oToolTypes = new ToolTypes();

            DBController.Instance.OpenNewConnection();

            _oToolTypes.GetToolType();
            cmbToolType.Items.Add("-- Select --");
            foreach (ToolType oToolType in _oToolTypes)
            {
                cmbToolType.Items.Add(oToolType.ToolTypeName);
            }
            cmbToolType.SelectedIndex = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool UIValidation()
        {

            if (cmbToolType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a tool type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbToolName.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a tool", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtQty.Text.Trim() == "")
            {
                MessageBox.Show("Please input qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQty.Focus();
                return false;
            }
            else
            {
                try
                {
                    int x = Convert.ToInt32(txtQty.Text);
                }
                catch
                {
                    MessageBox.Show("Please input valid qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }


            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private bool validateUIInput()
        {
            int nCount = 0;


            if (ctlEmployee1.SelectedEmployee == null || ctlEmployee1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.Focus();
                return false;
            }

            if (dgvLineItems.Rows.Count == 0)
            {
                MessageBox.Show("Please enter tool details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
            {
                if (oItemRow.Index < dgvLineItems.Rows.Count)
                {
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToInt32(oItemRow.Cells[2].Value) < 0)
                    {
                        MessageBox.Show("Stock quantity must be grater than or equal to zero ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }

            return true;
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oToolTran = new ToolTran();
                        //_oToolStock = new ToolStock();
                        _oToolTran = GetData();
                        _oToolTran.AddToolTran();


                        foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
                        {
                            if (oItemRow.Index < dgvLineItems.Rows.Count)
                            {
                                ToolStock oToolStock = new ToolStock();
                                oToolStock.ToolID = Convert.ToInt32(oItemRow.Cells[3].Value.ToString());
                                oToolStock.SoundStock = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());

                                if (oToolStock.StockCheck(oToolStock.ToolID))
                                {
                                    oToolStock.EditToolStock(false);
                                }
                                else
                                {
                                    oToolStock.AddToolStock();
                                }
                            }
                        }


                        DBController.Instance.CommitTran();
                        MessageBox.Show("You Have Successfully Issued Goods", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
            else
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oToolTran = new ToolTran();
                        //_oToolStock = new ToolStock();
                        _oToolTran = GetData();
                        _oToolTran.ToolTranID = _ToolTranID;
                        _oToolTran.Edit();


                        foreach (ToolStock oToolStock in _oToolStocks)
                        {
                            oToolStock.ForEditAddToolStock();
                        }

                        foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
                        {
                            if (oItemRow.Index < dgvLineItems.Rows.Count)
                            {
                                ToolStock oToolStock = new ToolStock();
                                oToolStock.ToolID = Convert.ToInt32(oItemRow.Cells[3].Value.ToString());
                                oToolStock.SoundStock = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());

                                if (oToolStock.StockCheck(oToolStock.ToolID))
                                {
                                    oToolStock.EditToolStock(false);
                                    if (!oToolStock.checkTotalStock(oToolStock.ToolID))
                                    {
                                        DBController.Instance.RollbackTransaction();
                                        MessageBox.Show("Stock is less than the given qty", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         return;
                                    }
                                }
                                else
                                {
                                    //oToolStock.AddToolStock();
                                    MessageBox.Show("Stock not available", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }


                        DBController.Instance.CommitTran();
                        MessageBox.Show("You Have Successfully Edited Issued Goods", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }


        }

        private ToolTran GetData()
        {
            ToolTran _oToolTran = new ToolTran();
            _oToolTran.TranDate = Convert.ToDateTime(dtIssueDate.Value);
            _oToolTran.CreateDate = DateTime.Now.Date;
            _oToolTran.FromWH = (Enum.GetName(typeof(Dictionary.ToolManagementWarehouse), 2)).ToString();
            _oToolTran.ToWH = (Enum.GetName(typeof(Dictionary.ToolManagementWarehouse), 1)).ToString();
            _oToolTran.UserID = Utility.UserId;
            _oToolTran.Status = (int)Dictionary.ToolManagementStatus.Issued;
            _oToolTran.Remarks = txtRemarks.Text;
            _oToolTran.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;

            foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
            {
                if (oItemRow.Index < dgvLineItems.Rows.Count)
                {
                    _oToolTranItem = new ToolTranItem();

                    _oToolTranItem.ToolID = Convert.ToInt32(oItemRow.Cells[3].Value.ToString());
                    _oToolTranItem.Qty = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());
                    _oToolTran.Add(_oToolTranItem);

                    totalSoundStock = totalSoundStock + _oToolTranItem.Qty;
                }
            }

            return _oToolTran;

        }


        private void cmbToolType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbToolName.Items.Clear();
            cmbToolName.Items.Add("-- Select --");

            if (cmbToolType.SelectedIndex > 0)
            {
                //Load Tool 

                _oTools = new Tools();
                _oTools.GetTool(_oToolTypes[cmbToolType.SelectedIndex - 1].ToolTypeID);

                foreach (Tool oTool in _oTools)
                {
                    cmbToolName.Items.Add(oTool.ToolName);
                }
            }
            cmbToolName.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {

                for (int i = 0; i < dgvLineItems.Rows.Count; i++)
                {
                    if ((cmbToolType.Text == dgvLineItems.Rows[i].Cells[0].Value.ToString()) && (cmbToolName.Text == dgvLineItems.Rows[i].Cells[1].Value.ToString()))
                    {
                        MessageBox.Show("Data already exists in the list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                ToolStock oToolStock = new ToolStock();

                if (oToolStock.StockCheck(_oTools[cmbToolName.SelectedIndex - 1].ToolID))
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItems);

                    oRow.Cells[0].Value = cmbToolType.Text;
                    oRow.Cells[1].Value = cmbToolName.Text;
                    oRow.Cells[2].Value = txtQty.Text;
                    oRow.Cells[3].Value = _oTools[cmbToolName.SelectedIndex - 1].ToolID;

                    dgvLineItems.Rows.Add(oRow);
                }

                else
                {
                    MessageBox.Show("No Stock Available for Issue", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
