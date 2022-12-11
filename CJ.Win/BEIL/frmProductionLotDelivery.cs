using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;
using CJ.Class.Library;

namespace CJ.Win.BEIL
{
    public partial class frmProductionLotDelivery : Form
    {
        Customers _oCustomers;
        ProductionLot _oProductionLot;
        TELLib _oTELLib;
        string sChallanNo = "";
        int nID = 0;

        ProductionLotDelivery _oProductionLotDelivery;

        public frmProductionLotDelivery()
        {
            InitializeComponent();
        }

        public void ShowDialog(ProductionLotDelivery oProductionLotDelivery)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oProductionLotDelivery;
            LoadCombos();
            nID = 0;
            nID = oProductionLotDelivery.ID;
            sChallanNo = "";
            sChallanNo = oProductionLotDelivery.ChallanNo;
            oProductionLotDelivery.GetChallanItem(nID);
            int nLotType = 0;
            nLotType = oProductionLotDelivery.ChallanType;
            cmbLotType.SelectedIndex = nLotType;

            int nCustomerIndex = 0;
            nCustomerIndex = _oCustomers.GetIndex(oProductionLotDelivery.CustomerID);
            cmbCustomer.SelectedIndex = nCustomerIndex + 1;

            txtRemarks.Text = oProductionLotDelivery.Remarks;
            dtChallanDate.Value = oProductionLotDelivery.ChallanDate.Date;
            cmbCustomer.Enabled = false;
            cmbLotType.Enabled = false;

            foreach (ProductionLotDeliveryItem oProductionLotDeliveryItem in oProductionLotDelivery)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvChallanItem);
                oRow.Cells[0].Value = oProductionLotDeliveryItem.ProductCode.ToString();
                oRow.Cells[1].Value = oProductionLotDeliveryItem.ProductName.ToString();
                oRow.Cells[2].Value = oProductionLotDeliveryItem.UnitPrice.ToString();
                oRow.Cells[3].Value = oProductionLotDeliveryItem.QCPassQty.ToString();
                oRow.Cells[4].Value = oProductionLotDeliveryItem.ChallanQty.ToString();
                oRow.Cells[5].Value = Convert.ToDouble(oProductionLotDeliveryItem.UnitPrice * oProductionLotDeliveryItem.ChallanQty).ToString();
                oRow.Cells[6].Value = oProductionLotDeliveryItem.ProductID.ToString();
                dgvChallanItem.Rows.Add(oRow);
            }
            GetTotalPOQty();


            this.ShowDialog();
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            dtChallanDate.Value = DateTime.Today;
            //Customer
            _oCustomers = new Customers();
            _oCustomers.GetBEILCustomer();
            cmbCustomer.Items.Clear();
            cmbCustomer.Items.Add("<All Customer>");
            foreach (Customer oCustomer in _oCustomers)
            {
                cmbCustomer.Items.Add(oCustomer.CustomerName);
            }
            cmbCustomer.SelectedIndex = 0;


            // Lot Type
            cmbLotType.Items.Clear();
            cmbLotType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductionLotType)))
            {
                cmbLotType.Items.Add(Enum.GetName(typeof(Dictionary.ProductionLotType), GetEnum));
            }
            cmbLotType.SelectedIndex = 0;
        }

        public void GetTotalPOQty()
        {
            txtQCPassQty.Text = "0";
            txtChallanQty.Text = "0";
            txtAmount.Text = "0";
            txtNetAmount.Text = "0";

            _oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvChallanItem.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {
                    txtQCPassQty.Text = Convert.ToDouble(Convert.ToDouble(txtQCPassQty.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }
                if (oRow.Cells[4].Value != null)
                {
                    txtChallanQty.Text = Convert.ToDouble(Convert.ToDouble(txtChallanQty.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();
                }
                if (oRow.Cells[5].Value != null)
                {
                    txtAmount.Text = Convert.ToDouble(Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(oRow.Cells[5].Value.ToString())).ToString();
                }
            }

            if (txtDiscount.Text.Trim() == "")
            {
                txtDiscount.Text = "0";
            }
            txtNetAmount.Text = Convert.ToDouble(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtDiscount.Text)).ToString();     
            lblAmountInWord.Visible = true;
            lblAmountInWord.Text = _oTELLib.TakaWords(Convert.ToDouble(txtNetAmount.Text));
        }
        private void cmbLotType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                _oProductionLot = new ProductionLot();
                _oProductionLot.GetQCPassQty(cmbLotType.SelectedIndex);
                dgvChallanItem.Rows.Clear();
                foreach (ProductionLotItem oProductionLotItem in _oProductionLot)
                {
                    DataGridViewRow oRow = new DataGridViewRow();

                    oRow.CreateCells(dgvChallanItem);
                    oRow.Cells[0].Value = oProductionLotItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oProductionLotItem.ProductName.ToString();
                    oRow.Cells[2].Value = oProductionLotItem.CostPrice.ToString();
                    oRow.Cells[3].Value = oProductionLotItem.QCPassQty.ToString();
                    oRow.Cells[4].Value = 0;
                    oRow.Cells[5].Value = 0;
                    oRow.Cells[6].Value = oProductionLotItem.ProductID.ToString();
                    dgvChallanItem.Rows.Add(oRow);
                }
                GetTotalPOQty();
            }
        }

        private void frmProductionLotDelivery_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Transection";
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                LoadCombos();
            }
            else
            {
                this.Text = "Edit Transection";
            }
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            int Qty = Convert.ToInt32(dgvChallanItem.Rows[nRowIndex].Cells[4].Value.ToString());
            dgvChallanItem.Rows[nRowIndex].Cells[5].Value = Convert.ToDouble(dgvChallanItem.Rows[nRowIndex].Cells[2].Value.ToString()) * Qty;

            GetTotalPOQty();
        }

        private void dgvChallanItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            txtNetAmount.Text = Convert.ToDouble(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtDiscount.Text)).ToString();
            lblAmountInWord.Visible = true;
            lblAmountInWord.Text = _oTELLib.TakaWords(Convert.ToDouble(txtNetAmount.Text));
        }

        private bool UIValidation()
        {
            #region ValidInput

            if (cmbLotType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Lot Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLotType.Focus();
                return false;
            }
            
            if (cmbCustomer.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustomer.Focus();
                return false;
            }
            #endregion

            #region ProductDetail
            foreach (DataGridViewRow oItemRow in dgvChallanItem.Rows)
            {
                if (oItemRow.Index < dgvChallanItem.Rows.Count)
                {
                    int nQCPassQty = 0;
                    int nChallanQty = 0;

                    if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value != "")
                    {
                        nQCPassQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }

                    if (oItemRow.Cells[4].Value != null || oItemRow.Cells[4].Value.ToString().Trim() != "")
                    {
                        nChallanQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    if (nQCPassQty >= nChallanQty)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("ChallanQty must be less or equal QCPass Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (nChallanQty == 0)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("You have to inputed at least 1 (one) Challan Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oProductionLotDelivery = new ProductionLotDelivery();
                        _oProductionLotDelivery = GetUIData(_oProductionLotDelivery);
                        _oProductionLotDelivery.Edit(nID);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update Challan. Lot # " + sChallanNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {


                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oProductionLotDelivery = new ProductionLotDelivery();
                        _oProductionLotDelivery = GetUIData(_oProductionLotDelivery);
                        _oProductionLotDelivery.Add();
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add ChallanNo # " + _oProductionLotDelivery.ChallanNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();


                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void dgvChallanItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalPOQty();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public ProductionLotDelivery GetUIData(ProductionLotDelivery _oProductionLotDelivery)
        {
            _oProductionLotDelivery.ChallanDate = dtChallanDate.Value.Date;
            _oProductionLotDelivery.ChallanType = cmbLotType.SelectedIndex;
            _oProductionLotDelivery.CustomerID = _oCustomers[cmbCustomer.SelectedIndex -1].CustomerID;
            _oProductionLotDelivery.ChallanAmount = Convert.ToDouble(txtAmount.Text);
            _oProductionLotDelivery.Discount = Convert.ToDouble(txtDiscount.Text);
            _oProductionLotDelivery.Remarks = txtRemarks.Text;
            _oProductionLotDelivery.CreateDate = DateTime.Now.Date;
            _oProductionLotDelivery.CreateUserID = Utility.UserId;
            _oProductionLotDelivery.Status = 1;


            foreach (DataGridViewRow oItemRow in dgvChallanItem.Rows)
            {
                if (oItemRow.Index < dgvChallanItem.Rows.Count)
                {
                    ProductionLotDeliveryItem _oProductionLotDeliveryItem = new ProductionLotDeliveryItem();

                    _oProductionLotDeliveryItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                    _oProductionLotDeliveryItem.Type = cmbLotType.SelectedIndex;
                    _oProductionLotDeliveryItem.ChallanQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oProductionLotDeliveryItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                    _oProductionLotDelivery.Add(_oProductionLotDeliveryItem);

                }
            }

            return _oProductionLotDelivery;
        }
    }
}

    

