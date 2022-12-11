// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 11,2011
// Time : 12.00 PM
// Description: order form for Distribution
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmPurchaseRequisition : Form
    {
        bool _bPriceAlterTicket;
        PurchaseRequisition oPurchaseRequisition ;
        Suppliers _oSuppliers;
        Utilities _oUtilitys;
        
        private int _nPOID;

        public frmPurchaseRequisition()
        {
            InitializeComponent();
        }
        private void frmPurchaseRequisition_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Purchase Requisition";
                LoadAllCombo();
            }
            else
            {
                this.Text = "Edit Purchase Requisition";
            }

        }
     
        public void LoadAllCombo()
        {
            _oSuppliers = new Suppliers();
            _oUtilitys = new Utilities();

            cmbSupplier.Items.Clear();            
            DBController.Instance.OpenNewConnection();
            _oSuppliers.GetSupplierName((int)Dictionary.SupplierType.Commercial);
            foreach (Supplier oSupplier in _oSuppliers)
            {
                
                cmbSupplier.Items.Add(oSupplier.SupplierName);                
            }
            cmbSupplier.SelectedIndex = 0;


            cmbApplyStatus.Items.Clear();          
            DBController.Instance.OpenNewConnection();
            _oUtilitys.GetStatus();
            foreach (Utility oUtility in _oUtilitys)
            {
                if (oUtility.SatusId>-1)
                cmbApplyStatus.Items.Add(oUtility.Satus);
            }
            cmbApplyStatus.SelectedIndex = 0;
       
        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[6].Value = oForm.sProductId;

                if (oForm.sProductCode != null)
                {
                    int nRowIndex = dgvLineItem.Rows.Add(oRow);
                    if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;   
                    }
                }    
                               
            }
          
        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    Product oProduct = new Product();
                    DBController.Instance.OpenNewConnection();
                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();

                    if (oProduct.Flag==false)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (oProduct.ProductID).ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }                             
            }
            else if (nColumnIndex == 3)
            {
                try
                {
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString());
                   
                   
                }
                catch
                {
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = 0;
                }
            }
           
        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                btnClear_Click(sender, e);
            }
           
        }
        private bool validateUIInput()
        {
            #region Transaction Master Information Validation

           
            if (cmbApplyStatus.Text == null)
            {
                MessageBox.Show("Please Select a Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }          
            if (txtPONo.Text.Trim() == "")
            {
                MessageBox.Show("Please Input PO Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.Tag == null)
            {
                oPurchaseRequisition = new PurchaseRequisition();
                oPurchaseRequisition.PONo = txtPONo.Text;
                oPurchaseRequisition.CheackPONo();

                if (oPurchaseRequisition.Flag == false)
                {
                    MessageBox.Show("Please Input Valied PO Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (cmbSupplier.Text == null)
            {
                MessageBox.Show("Please Select a Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (Utility.Terminal.Trim().Length == 0)
            {
                MessageBox.Show("Invalid Terminal Information.\n Please Contact to MIS", "Missing Terminal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbApplyStatus.Text == "APPROVED")
            {
                if (dtApprovalDate.Checked == false)
                {
                    MessageBox.Show("Please Input Approval Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (cmbApplyStatus.Text == "LC_OPENED")
            {
                if (dtApprovalDate.Checked == false)
                {
                    MessageBox.Show("Please Input Approval Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }               
                if (txtPINo.Text=="" )
                {
                    MessageBox.Show("Please Input PI Number or PI Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
               
            }           

            #endregion

            #region Transaction Details Information Validation

            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[6].Value == null )
                    {
                        MessageBox.Show("Please Input Valied Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[6].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valied Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("Please Input Approved Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Approved Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }
        public void Save()
        {
            if (this.Tag == null)
            {
                oPurchaseRequisition = new PurchaseRequisition();
                oPurchaseRequisition=SetInput(oPurchaseRequisition);
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPurchaseRequisition.Insert();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oPurchaseRequisition.PONo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                oPurchaseRequisition = (PurchaseRequisition)this.Tag;
                oPurchaseRequisition.Clear();
                oPurchaseRequisition = SetInput(oPurchaseRequisition);               
                
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPurchaseRequisition.Update();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Upadte The Transaction", "Upadte", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

        }

        public PurchaseRequisition SetInput(PurchaseRequisition oPurchaseRequisition)
        {
            Supplier oSupplier = _oSuppliers[cmbSupplier.SelectedIndex];
            Utility oUtility = _oUtilitys[cmbApplyStatus.SelectedIndex];

            oPurchaseRequisition.PONo = Convert.ToString(txtPONo.Text.Trim());
            oPurchaseRequisition.SupplierID = oSupplier.SupplierID;
            oPurchaseRequisition.Status = oUtility.SatusId;
            oPurchaseRequisition.Remarks = Convert.ToString(txtRemarks.Text.Trim());

            if (dtApprovalDate.Checked == true)
                oPurchaseRequisition.ApprovalDate = dtApprovalDate.Value.Date;
            else oPurchaseRequisition.ApprovalDate = null;

            oPurchaseRequisition.PortArrivalDate = null;
            oPurchaseRequisition.ReceivedDate = null;

            if (txtLCNo.Text != "") oPurchaseRequisition.LCNo = Convert.ToString(txtLCNo.Text.Trim());
            else oPurchaseRequisition.LCNo = null;

            if (txtLCValue.Text != "") oPurchaseRequisition.LCValue = Convert.ToDouble(txtLCValue.Text.Trim());
            else oPurchaseRequisition.LCValue = Convert.ToDouble(null);

            if (txtDocValue.Text != "") oPurchaseRequisition.DocValue = Convert.ToDouble(txtDocValue.Text.Trim());
            else oPurchaseRequisition.DocValue = Convert.ToDouble(null);

            if (txtDutyAmount.Text != "") oPurchaseRequisition.DutyAmount = Convert.ToDouble(txtDutyAmount.Text.Trim());
            else oPurchaseRequisition.DutyAmount = Convert.ToDouble(null);

            oPurchaseRequisition.LCInvoiceNo = null;
            oPurchaseRequisition.LCInvoiceDate = null;

            if (txtPINo.Text != "") oPurchaseRequisition.PINo = Convert.ToString(txtPINo.Text.Trim());
            else oPurchaseRequisition.PINo = null;

            if (dtPIDate.Checked == true)
                oPurchaseRequisition.PIDate = dtPIDate.Value.Date;
            else oPurchaseRequisition.PIDate = null;

            if (dtpLCDate.Checked == true)
                oPurchaseRequisition.LCDate = dtpLCDate.Value.Date;
            else oPurchaseRequisition.LCDate = null;
            

            if (dtDocDate.Checked == true)
                oPurchaseRequisition.DocDate = dtDocDate.Value.Date;
            else oPurchaseRequisition.DocDate = null;

            oPurchaseRequisition.ShipmentDate = null;

            if (dtDutyDate.Checked == true)
                oPurchaseRequisition.DutyDate = dtDutyDate.Value.Date;
            else oPurchaseRequisition.DutyDate = null;
       
            //Loop for Grid View

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    PurchaseRequisitionItem oItem = new PurchaseRequisitionItem();

                    try
                    {
                        oItem.ApprovedQty = Convert.ToInt64(oItemRow.Cells[3].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.ApprovedQty = Convert.ToInt64(0);
                    }

                    try
                    {
                        oItem.UnitValue = Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.UnitValue = Convert.ToDouble(0);
                    }
                    try
                    {
                        oItem.LCQty = Convert.ToInt64(oItemRow.Cells[5].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.LCQty = Convert.ToInt64(null);
                    }
                   
                    oItem.ReceivedQty = Convert.ToInt64(null);                    
                    oItem.ProductID = Convert.ToInt16(oItemRow.Cells[6].Value.ToString().Trim());

                    oPurchaseRequisition.Add(oItem);
                }
            }
            //End loop
            return oPurchaseRequisition;
        }

        private void cmbApplyStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (cmbApplyStatus.Text == "APPROVED")
                {
                    dtApprovalDate.Checked = true;                
                    
                }

                else if (cmbApplyStatus.Text == "LC_OPENED")
                {
                    dtApprovalDate.Checked = true;
                    dtpLCDate.Checked = true;                   

                }              
                else
                {
                    dtApprovalDate.Checked = false;
                    dtpLCDate.Checked = false;     
                  
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPONo.Text = "";
            txtRemarks.Text = "";
            txtDutyAmount.Text = "";
            txtDocValue.Text = "";
            LoadAllCombo();  
            dtApprovalDate.Checked = false;

            txtLCNo.Text = "";          
            txtLCValue.Text = "";
            txtPINo.Text = "";

            dtpLCDate.Checked = false;           
            dtDocDate.Checked = false;
            dtPIDate.Checked = false;
            dtDutyDate.Checked = false;
            dgvLineItem.Rows.Clear();   

           
        }
        public void ShowDialog(PurchaseRequisition oPurchaseRequisition)
        {
            if (oPurchaseRequisition != null)
            {
                this.Tag = oPurchaseRequisition;

                cbPOtype.Enabled = false;
                LoadAllCombo();
                cmbSupplier.SelectedIndex = _oSuppliers.GetIndexByID(oPurchaseRequisition.SupplierID);

                _nPOID = oPurchaseRequisition.POID;
                txtPONo.Text = oPurchaseRequisition.PONo;
                txtRemarks.Text = oPurchaseRequisition.Remarks;
                cmbApplyStatus.SelectedIndex = _oUtilitys.GetIndexByID(oPurchaseRequisition.Status);               

                if (oPurchaseRequisition.ApprovalDate != DBNull.Value)
                {
                    dtApprovalDate.Checked = true;
                    dtApprovalDate.Value = Convert.ToDateTime(oPurchaseRequisition.ApprovalDate);
                }               

                if (oPurchaseRequisition.LCNo != null || oPurchaseRequisition.LCNo != "")
                {
                    txtLCNo.Text = oPurchaseRequisition.LCNo;
                    txtLCValue.Text = oPurchaseRequisition.LCValue.ToString();
                    txtPINo.Text = oPurchaseRequisition.PINo;

                    txtDocValue.Text = oPurchaseRequisition.DocValue.ToString();
                    txtDutyAmount.Text = oPurchaseRequisition.DutyAmount.ToString();

                    if (oPurchaseRequisition.LCDate != DBNull.Value)
                    {
                        dtpLCDate.Checked = true;
                        dtpLCDate.Value = Convert.ToDateTime(oPurchaseRequisition.LCDate);
                    }

                    if (oPurchaseRequisition.DocDate != DBNull.Value)
                    {
                        dtDocDate.Checked = true;
                        dtDocDate.Value = Convert.ToDateTime(oPurchaseRequisition.DocDate);
                    }
                    if (oPurchaseRequisition.DutyDate != DBNull.Value)
                    {
                        dtDutyDate.Checked = true;
                        dtDutyDate.Value = Convert.ToDateTime(oPurchaseRequisition.DutyDate);
                    }
                    if (oPurchaseRequisition.PIDate != DBNull.Value)
                    {
                        dtPIDate.Checked = true;
                        dtPIDate.Value = Convert.ToDateTime(oPurchaseRequisition.PIDate);
                    }
                }

                foreach (PurchaseRequisitionItem oPurchaseRequisitionItem in oPurchaseRequisition)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oPurchaseRequisitionItem.ProductDetail.ProductCode.ToString();
                    oRow.Cells[2].Value = oPurchaseRequisitionItem.ProductDetail.ProductName.ToString();
                    oRow.Cells[3].Value = oPurchaseRequisitionItem.ApprovedQty.ToString();
                    oRow.Cells[4].Value = oPurchaseRequisitionItem.UnitValue.ToString();
                    oRow.Cells[5].Value = oPurchaseRequisitionItem.LCQty.ToString();                    
                    oRow.Cells[6].Value = oPurchaseRequisitionItem.ProductID.ToString();
                    oRow.Cells[0].ReadOnly = true;
                    dgvLineItem.Rows.Add(oRow);

                }
                this.Tag = oPurchaseRequisition;
                this.ShowDialog();
            }
            else
            {
                cbPOtype.Enabled = true;
                LoadAllCombo();
                this.ShowDialog();
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
        private void cbPOtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            oPurchaseRequisition = new PurchaseRequisition();
            if (cbPOtype.Text == "Light")
            {
                DBController.Instance.getNewConnection();
                txtPONo.Text= "L-"+ oPurchaseRequisition.GetPONo(cbPOtype.Text);
            }
            if (cbPOtype.Text == "Electronics")
            {
                DBController.Instance.getNewConnection();
                txtPONo.Text = "E-" + oPurchaseRequisition.GetPONo(cbPOtype.Text);
            }
            if (cbPOtype.Text == "Mobile")
            {
                DBController.Instance.getNewConnection();
                txtPONo.Text = "M-" + oPurchaseRequisition.GetPONo(cbPOtype.Text);
            }
        }
      
       
    }
}
           