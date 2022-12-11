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
    public partial class frmCACQuotation : Form
    {
        Quotation oQuotation;
        QuotationHistory _oQuotationHistory;
        Quotation _oQuotation;
        Quotations _oQuotations;
        Brands oBrands;
        ProductGroups oProductGroups;
        QuotationDetail oQuotationDetail;
        int nCustomerID = 0;
        int _nStatus = 0;
        public frmCACQuotation(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }

        public void ShowDialog(Quotation oQuotation)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oQuotation;
            nCustomerID = 0;
            LoadCombo();
            txtReferenceNo.Text = oQuotation.Code;
            dtDate.Value = oQuotation.QuotationDate;
            if (oQuotation.Type==(int)Dictionary.YesOrNoStatus.YES)
            {
                rdoNewCustomer.Checked = true;
                rdoOldCustomer.Checked= false;
            }
            else
            {
                rdoNewCustomer.Checked = false;
                rdoOldCustomer.Checked = true;
            }


            if (rdoNewCustomer.Checked == true)
            {
                txtCustomer.Text=oQuotation.CustomerName;
                 nCustomerID= oQuotation.CustomerID;
            }
            else
            {
                ctlCustomer1.txtCode.Text = oQuotation.CustomerCode;
                ctlCustomer1.txtDescription.Text = oQuotation.CustomerName;
                nCustomerID = oQuotation.CustomerID;
            }
            txtPhone.Text = oQuotation.MobileNo;
            txtAddress.Text = oQuotation.Address;
            txtTelephoneNo.Text = oQuotation.TelephoneNo;

            txtTotalAmount.Text = oQuotation.TotalAmount.ToString();
            if (_nStatus != (int)Dictionary.QuotationStatus.PO_WO)
            {
                txtPOAmount.Text = "0.00";
            }
            else
            {
                txtPOAmount.Text = oQuotation.TotalAmount.ToString();
            }
            txtRemarks.Text = oQuotation.Remarks;
            
            Quotations oQuotations = new Quotations();
            oQuotations.RefreshByQuotationDetails(oQuotation.QuotationID);
            foreach (QuotationDetail oItem in oQuotations)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvCACQuotation);
                oRow.Cells[0].Value = oItem.BrandID.ToString();
                oRow.Cells[2].Value = oItem.BrandDesc.ToString();
                oRow.Cells[3].Value = oItem.MAGName.ToString();
                oRow.Cells[4].Value = oItem.Model.ToString();
                oRow.Cells[5].Value = oItem.Qty.ToString();
                oRow.Cells[6].Value = oItem.Ton.ToString();
                oRow.Cells[7].Value = oItem.Amount.ToString();
                dgvCACQuotation.Rows.Add(oRow);
            }

            this.ShowDialog();
        }
        private void frmCACQuotation_Load(object sender, EventArgs e)
        {
            //if (_nStatus != (int)Dictionary.QuotationStatus.PO_WO)
            //{
            //    lblPoAmount.Visible = false;
            //    txtPOAmount.Visible = false;
            //}
            //else
            //{
            //    lblTotalAmount.Visible = false;
            //    txtTotalAmount.Visible = false;
            //}
            if (this.Tag == null || this.Tag == " ")
            {               
                LoadCombo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private bool validateUIInput()
        {
            if(rdoOldCustomer.Checked==true)
            {
            if (ctlCustomer1.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Input valid customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            }
            else if (rdoNewCustomer.Checked == true)
            {
                if (txtCustomer.Text.Trim() == "")
                {
                    MessageBox.Show("Please Input customer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomer.Focus();
                    return false;
                }
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Valid Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if ((txtPhone.Text.Length < 11) && (txtPhone.Text.Length > 0))
            {
                MessageBox.Show("Please Input Valid Phone Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            
            //#region Transaction Details Information Validation

            //foreach (DataGridViewRow oItemRow in dgvCACQuotation.Rows)
            //{
            //    if (oItemRow.Index < dgvCACQuotation.Rows.Count - 1)
            //    {
            //        if (oItemRow.Cells[5].Value == null)
            //        {
            //            MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        //if (oItemRow.Cells[4].Value.ToString().Trim() == "")
            //        //{
            //        //    MessageBox.Show("Please Input Ton", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //    return false;
            //        //}
            //        if (oItemRow.Cells[7].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }
            //}
            //#endregion

            return true;
        }
        
        private void Save()
        {
            if (this.Tag != null)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        Quotation _oQuotation = (Quotation)this.Tag;
                        _oQuotation = GetUIData(_oQuotation);
                        _oQuotation.Edit(_nStatus);
                        if (_nStatus == (int)Dictionary.QuotationStatus.PO_WO)
                        {
                            ADDQuotationHistory(_oQuotation);
                        }
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update Quotation # " + _oQuotation.Code.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        _oQuotation = new Quotation();
                        _oQuotation = GetUIData(_oQuotation);
                        _oQuotation.Status = (int)Dictionary.QuotationStatus.Create;
                        _oQuotation.Add();
                        ADDQuotationHistory(_oQuotation);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add Quotation # " + _oQuotation.Code.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public Quotation GetUIData(Quotation _oQuotation)
        {
            _oQuotation.Code = txtReferenceNo.Text;
            if (rdoNewCustomer.Checked == true)
            {
                _oQuotation.Type = (int)Dictionary.YesOrNoStatus.YES;
                _oQuotation.CustomerID = 0;
            }
            else 
            {
                _oQuotation.Type = (int)Dictionary.YesOrNoStatus.NO;
                _oQuotation.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            }
            
            
            if (rdoNewCustomer.Checked == true)
            {
                _oQuotation.CustomerName = txtCustomer.Text;
            }
            else 
            {
                _oQuotation.CustomerName = ctlCustomer1.txtDescription.Text;
            }
            _oQuotation.QuotationDate = dtDate.Value;

            _oQuotation.Address = txtAddress.Text;
            _oQuotation.TelephoneNo = txtTelephoneNo.Text;
            _oQuotation.MobileNo = txtPhone.Text;
            
            _oQuotation.TotalAmount = Convert.ToDouble(txtTotalAmount.Text.ToString());
            _oQuotation.CreateUserID =Utility.UserId;
            _oQuotation.CreateDate = DateTime.Now;
            _oQuotation.UpdateUserID = Utility.UserId;
            _oQuotation.UpdateDate = DateTime.Now;
            _oQuotation.Remarks = txtRemarks.Text;
            _oQuotation.POReferenceNo = txtReferenceNo.Text;
            _oQuotation.POAmount = Convert.ToDouble(txtPOAmount.Text.ToString());
            

            if (_nStatus == (int)Dictionary.QuotationStatus.Create)
            {
                _oQuotation.Status = (int)Dictionary.QuotationStatus.Create;   
            }
            else if (_nStatus == (int)Dictionary.QuotationStatus.Submit)
            {
                _oQuotation.Status = (int)Dictionary.QuotationStatus.Submit;
            }
            else if (_nStatus == (int)Dictionary.QuotationStatus.PO_WO)
            {
                _oQuotation.Status = (int)Dictionary.QuotationStatus.PO_WO;
            }
            else
            {
                _oQuotation.Status = (int)Dictionary.QuotationStatus.Cancel;
            }
            
            // Details
                foreach (DataGridViewRow oItemRow in dgvCACQuotation.Rows)
                {
                    if (oItemRow.Index < dgvCACQuotation.Rows.Count)
                    {

                        QuotationDetail _oQuotationDetail = new QuotationDetail();

                        _oQuotationDetail.BrandID = int.Parse(oItemRow.Cells[0].Value.ToString());
                        _oQuotationDetail.MAGName = oItemRow.Cells[3].Value.ToString();
                        _oQuotationDetail.Model = oItemRow.Cells[4].Value.ToString();
                        _oQuotationDetail.Qty = int.Parse(oItemRow.Cells[5].Value.ToString());
                        _oQuotationDetail.Ton = Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                        _oQuotationDetail.Amount = Convert.ToDouble(oItemRow.Cells[7].Value.ToString());
                        _oQuotation.Add(_oQuotationDetail);

                    }
                }
            

            return _oQuotation;
        }
        
        private void LoadCombo()
        {
            oBrands = new Brands();
            oBrands.GetCACBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("-- Select Brand --");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            oProductGroups = new ProductGroups();
            oProductGroups.GETCACMAG();
            cmbMag.Items.Clear();
            cmbMag.Items.Add("-- Select MAG --");
            foreach (ProductGroup oProductGroup in oProductGroups)
            {
                cmbMag.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMag.SelectedIndex = 0;
        }
        private void Clear()
        {
            //txtTotalAmount.Text = "0.00";
            cmbBrand.SelectedIndex = 0;
            cmbMag.SelectedIndex = 0;
            txtModel.Text = "";
            txtQtyValue.Text = "";
            txtTonValue.Text = "";
            txtAmountValue.Text = "";

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            
            if (nColumnIndex == 7)
            {
                if (dgvCACQuotation.Rows[nRowIndex].Cells[7].Value.ToString() != null)
                {
                    try
                    {
                        dgvCACQuotation.Rows[nRowIndex].Cells[7].Value = Convert.ToDouble(dgvCACQuotation.Rows[nRowIndex].Cells[7].Value.ToString());
                        
                    }
                    catch
                    {
                        //MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                    }
                }
                GetTotal();
            }

        }
        private void GetTotal()
        {
            txtTotalAmount.Text = "0.00";
            txtPOAmount.Text = "0.00";

            foreach (DataGridViewRow oRow in dgvCACQuotation.Rows)
            {
                if (oRow.Cells[7].Value != null)
                {
                    if (_nStatus != (int)Dictionary.QuotationStatus.PO_WO)
                    {
                        txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[7].Value.ToString())).ToString();
                        //txtPOAmount.Text = Convert.ToDouble(Convert.ToDouble(txtPOAmount.Text) + Convert.ToDouble(oRow.Cells[7].Value.ToString())).ToString();
                    }
                    else
                    {
                        txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[7].Value.ToString())).ToString();
                        txtPOAmount.Text = Convert.ToDouble(Convert.ToDouble(txtPOAmount.Text) + Convert.ToDouble(oRow.Cells[7].Value.ToString())).ToString();

                    }

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                Clear();
            }
           
        }

        private void dgvCACQuotation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }

        }

        private void dgvCACQuotation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool CheckUIGridView()
        {
            if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }
            if (cmbMag.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select MAG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMag.Focus();
                return false;
            }
            if (txtTonValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Input value as 0 if have no Ton", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTonValue.Focus();
                return false;
            }
            if (txtQtyValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtyValue.Focus();
                return false;
            }
            if (txtAmountValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountValue.Focus();
                return false;
            }
            return true;
        }
        private void AddQuotationList()
        {
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvCACQuotation);
            oRow.Cells[0].Value = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            oRow.Cells[1].Value = oProductGroups[cmbMag.SelectedIndex - 1].MAGID;
            oRow.Cells[2].Value = oBrands[cmbBrand.SelectedIndex - 1].BrandDesc;
            oRow.Cells[3].Value = oProductGroups[cmbMag.SelectedIndex - 1].PdtGroupName;
            oRow.Cells[4].Value = txtModel.Text;
            oRow.Cells[5].Value = txtQtyValue.Text;
            oRow.Cells[6].Value = txtTonValue.Text;
            oRow.Cells[7].Value = txtAmountValue.Text.ToString();
            dgvCACQuotation.Rows.Add(oRow);
        }
        private void ADDQuotationHistory(Quotation oQuotationHistory)
        {
            _oQuotationHistory = new QuotationHistory();
            _oQuotationHistory.QuotationID = oQuotationHistory.QuotationID;
            _oQuotationHistory.CreateUserID = Utility.UserId;
            _oQuotationHistory.CreateDate= DateTime.Now;
            _oQuotationHistory.Status = oQuotationHistory.Status;
            _oQuotationHistory.Remarks = "";
            _oQuotationHistory.Add();

        }
        private void rdoNewCustomer_CheckedChanged(object sender, EventArgs e)
        {
            ctlCustomer1.Visible = false;
            txtCustomer.Visible = true;
        }

        private void rdoOldCustomer_CheckedChanged(object sender, EventArgs e)
        {
            ctlCustomer1.Visible = true;
            txtCustomer.Visible = false;
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (CheckUIGridView())
            {
                AddQuotationList();
                Clear();
                GetTotal();
            }
            
        }

        private void dgvCACQuotation_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            txtAddress.Text = ctlCustomer1.SelectedCustomer.CustomerAddress;
            txtTelephoneNo.Text = ctlCustomer1.SelectedCustomer.CustomerTelephone;
            txtPhone.Text = ctlCustomer1.SelectedCustomer.CellPhoneNo;
        }

        private void rdoNonExisting_CheckedChanged(object sender, EventArgs e)
        {
            lblProduct.Visible = false;
            ctlProduct1.Visible = false;
        }

        private void rdoExisting_CheckedChanged(object sender, EventArgs e)
        {
            lblProduct.Visible = true;
            ctlProduct1.Visible = true;

        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            cmbBrand.Text = ctlProduct1.SelectedSerarchProduct.BrandDesc;
            cmbMag.Text = ctlProduct1.SelectedSerarchProduct.MAGName;
        }

    }
}