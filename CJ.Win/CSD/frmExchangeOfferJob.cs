using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferJob : Form
    {
        ExchangeOfferJob _oExchangeOfferJob;

        public frmExchangeOfferJob()
        {
            InitializeComponent();
        }

        public void LoadData()
        {

            //*****--Contact Mode--*****
            cmbContactMode.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ExOContactMode)))
            {
                cmbContactMode.Items.Add(Enum.GetName(typeof(Dictionary.ExOContactMode), GetEnum));
            }
            cmbContactMode.SelectedIndex = 0;


            //*****--Product Detail--*****
            DataGridViewTextBoxColumn txtProductDetail = new DataGridViewTextBoxColumn();
            txtProductDetail.HeaderText = "Product Details";
            txtProductDetail.Width = 170;
            dgvExchangedProduct.Columns.Add(txtProductDetail);


            //*****--Product Type--*****
            Utilities oGetExchangedProduct = new Utilities();
            oGetExchangedProduct.GetExchangedProductType();

            DataGridViewComboBoxColumn ColumnProdutType = new DataGridViewComboBoxColumn();
            ColumnProdutType.DataPropertyName = "ProductType";
            ColumnProdutType.HeaderText = "Product Type";
            ColumnProdutType.Width = 100;
            ColumnProdutType.DataSource = oGetExchangedProduct;
            ColumnProdutType.ValueMember = "SatusId";
            ColumnProdutType.DisplayMember = "Satus";
            dgvExchangedProduct.Columns.Add(ColumnProdutType);

            //*****--Quantity--*****
            DataGridViewTextBoxColumn txtQuantity = new DataGridViewTextBoxColumn();
            txtQuantity.HeaderText = "Quantity";
            txtQuantity.Width = 60;
            dgvExchangedProduct.Columns.Add(txtQuantity);

            //*****--Product Size--*****
            DataGridViewTextBoxColumn txtProductSize = new DataGridViewTextBoxColumn();
            txtProductSize.HeaderText = "Product Size";
            txtProductSize.Width = 120;
            dgvExchangedProduct.Columns.Add(txtProductSize);

            //*****--Brand Name--*****
            DataGridViewTextBoxColumn txtBarnd = new DataGridViewTextBoxColumn();
            txtBarnd.HeaderText = "Brand Name";
            txtBarnd.Width = 100;
            dgvExchangedProduct.Columns.Add(txtBarnd);


            //*****--Have Remort--*****
            Utilities oHaveRemort = new Utilities();
            oHaveRemort.GetExchangedProductHaveRemort();

            DataGridViewComboBoxColumn ColumnHaveRemort = new DataGridViewComboBoxColumn();
            ColumnHaveRemort.DataPropertyName = "HaveRemort";
            ColumnHaveRemort.HeaderText = "Have Remort";
            ColumnHaveRemort.Width = 60;
            ColumnHaveRemort.DataSource = oHaveRemort;
            ColumnHaveRemort.ValueMember = "SatusId";
            ColumnHaveRemort.DisplayMember = "Satus";
            dgvExchangedProduct.Columns.Add(ColumnHaveRemort);


            //*****--Condition--*****
            Utilities oProductCondition = new Utilities();
            oProductCondition.GetExchangedProductCondition();

            DataGridViewComboBoxColumn ColumnCondition = new DataGridViewComboBoxColumn();
            ColumnCondition.DataPropertyName = "Condition";
            ColumnCondition.HeaderText = "Condition";
            ColumnCondition.Width = 60;
            ColumnCondition.DataSource = oProductCondition;
            ColumnCondition.ValueMember = "SatusId";
            ColumnCondition.DisplayMember = "Satus";
            dgvExchangedProduct.Columns.Add(ColumnCondition);

        }

        private void frmExchangeOfferJob_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter CustomerName", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return false;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter ContactNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return false;
            }
            if (txtEmial.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmial.Focus();
                return false;
            }

            #region Transaction Details Information Validation

            if (dgvExchangedProduct.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvExchangedProduct.Rows)
            {
                if (oItemRow.Index < dgvExchangedProduct.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Product Detail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("Please Select ProductType", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Product Size", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[4].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Brand Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("Please Input Remort Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[6].Value == null)
                    {
                        MessageBox.Show("Please Input Product Condition", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oExchangeOfferJob = new ExchangeOfferJob();
                        _oExchangeOfferJob = GetUIData(_oExchangeOfferJob);
                        _oExchangeOfferJob.Edit();

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update Stock Requisition # " + "", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oExchangeOfferJob = new ExchangeOfferJob();
                        _oExchangeOfferJob = GetUIData(_oExchangeOfferJob);
                        _oExchangeOfferJob.Add();

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Office Item # " + _oExchangeOfferJob.JobNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public ExchangeOfferJob GetUIData(ExchangeOfferJob _oExchangeOfferJob)
        {
            _oExchangeOfferJob.ContactMode = cmbContactMode.SelectedIndex;
            _oExchangeOfferJob.ContactDate = dtContactDate.Value.Date;
            _oExchangeOfferJob.CustomerName = txtCustomerName.Text;
            _oExchangeOfferJob.Address = txtAddress.Text;
            _oExchangeOfferJob.ContactNo = txtContactNo.Text;
            _oExchangeOfferJob.Email = txtEmial.Text;
            _oExchangeOfferJob.Status = (int)Dictionary.ExchangeOfferStatus.Create;
            _oExchangeOfferJob.Terminal = (int)Dictionary.Terminal.Head_Office;
            _oExchangeOfferJob.Remarks = txtRemarks.Text;
            _oExchangeOfferJob.HappyCallStatus = (int)Dictionary.ExchangeOfferHappyCall.YetToCall;

            // Item Details
            foreach (DataGridViewRow oItemRow in dgvExchangedProduct.Rows)
            {
                if (oItemRow.Index < dgvExchangedProduct.Rows.Count - 1)
                {

                    ExchangeOfferJobDetail _oExchangeOfferJobDetail = new ExchangeOfferJobDetail();

                    _oExchangeOfferJobDetail.ProductDetail = oItemRow.Cells[0].Value.ToString();

                    try
                    {
                        _oExchangeOfferJobDetail.ProductType = int.Parse(oItemRow.Cells[1].Value.ToString());
                    }
                    catch
                    {
                        _oExchangeOfferJobDetail.ProductType = -1;
                    }

                    _oExchangeOfferJobDetail.Quantity = int.Parse(oItemRow.Cells[2].Value.ToString());
                    _oExchangeOfferJobDetail.ProductSize = oItemRow.Cells[3].Value.ToString();
                    _oExchangeOfferJobDetail.BrandName = oItemRow.Cells[4].Value.ToString();
                    try
                    {
                        _oExchangeOfferJobDetail.HaveRemortCtrl = int.Parse(oItemRow.Cells[5].Value.ToString());
                    }
                    catch
                    {
                        _oExchangeOfferJobDetail.HaveRemortCtrl = -1;
                    }
                    try
                    {
                        _oExchangeOfferJobDetail.Condition = int.Parse(oItemRow.Cells[6].Value.ToString());
                    }
                    catch
                    {
                        _oExchangeOfferJobDetail.Condition = -1;
                    }

                    _oExchangeOfferJob.Add(_oExchangeOfferJobDetail);

                }
            }

            return _oExchangeOfferJob;
        }
    }
}