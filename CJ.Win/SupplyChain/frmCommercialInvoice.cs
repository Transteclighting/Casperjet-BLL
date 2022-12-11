using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmCommercialInvoice : Form
    {
        CommercialInvoice oCommercialInvoice;       
        Utilities _oUtilitys;
        private int _nPOID;
        private int _nCIId;

        public frmCommercialInvoice()
        {
            InitializeComponent();
        }

        private void frmCommercialInvoice_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Commercial Invoice";
                LoadAllCombo();
            }
            else
            {
                this.Text = "Edit Commercial Invoice";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                btnClear_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPONo.Text = "";
            txtPINo.Text = "";
            txtLCNo.Text = "";
            txtRemarks.Text = "";
            txtDocValue.Text = "";
            txtDutyAmount.Text = "";
            LoadAllCombo();
            txtInvoiceNo.Text = "";
            txtInvoiceValue.Text = "";
            dtpInvoiceDate.Checked = false;
            dtPortArrivalDate.Checked = false;
            dtpShipmentDate.Checked = false;
            dtReceivedDate.Checked = false;
            dtDocDate.Checked = false;
            dtDutyDate.Checked = false;
            dgvLineItem.Rows.Clear();   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadAllCombo()
        {
            _oUtilitys = new Utilities();           

            cmbApplyStatus.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oUtilitys.CommercialInvoiceStatus();
            foreach (Utility oUtility in _oUtilitys)
            {              
               cmbApplyStatus.Items.Add(oUtility.Satus);
            }
            cmbApplyStatus.SelectedIndex = 0;

        }
        public void ShowDialog(CommercialInvoice oCommercialInvoice)
        {
            if (oCommercialInvoice != null)
            {
                this.Tag = oCommercialInvoice;

                LoadAllCombo();
                PurchaseRequisition oPurchaseRequisition = new PurchaseRequisition();
                DBController.Instance.OpenNewConnection();
                oPurchaseRequisition.RefreshForCommercialInvoice(oCommercialInvoice.POID);

                btPOSearch.Visible = false;
                _nPOID = oCommercialInvoice.POID;
                _nCIId = oCommercialInvoice.CIID;

                cmbApplyStatus.SelectedIndex = _oUtilitys.GetIndexByID(oCommercialInvoice.Status);
                txtPONo.Text= oPurchaseRequisition.PONo;
                txtPINo.Text = oPurchaseRequisition.PINo;
                txtLCNo.Text = oPurchaseRequisition.LCNo;
                txtInvoiceNo.Text = oCommercialInvoice.CINo;
                txtInvoiceValue.Text = oCommercialInvoice.InvoiceValue.ToString();
                txtRemarks.Text = oCommercialInvoice.Remarks;
                txtDocValue.Text = oCommercialInvoice.DocValue.ToString();
                txtDutyAmount.Text = oCommercialInvoice.DutyAmount.ToString();

                if (oCommercialInvoice.CIDate != DBNull.Value)
                {
                    dtpInvoiceDate.Checked = true;
                    dtpInvoiceDate.Value = Convert.ToDateTime(oCommercialInvoice.CIDate);
                }

                if (oCommercialInvoice.SPortLeaveDate != DBNull.Value)
                {
                    dtpShipmentDate.Checked = true;
                    dtpShipmentDate.Value = Convert.ToDateTime(oCommercialInvoice.SPortLeaveDate);
                }

                if (oCommercialInvoice.RPortArrivalDate != DBNull.Value)
                {
                    dtPortArrivalDate.Checked = true;
                    dtPortArrivalDate.Value = Convert.ToDateTime(oCommercialInvoice.RPortArrivalDate);
                }

                if (oCommercialInvoice.ReceviedDate != DBNull.Value)
                {
                    dtReceivedDate.Checked = true;
                    dtReceivedDate.Value = Convert.ToDateTime(oCommercialInvoice.ReceviedDate);
                }
                if (oCommercialInvoice.DocDate != DBNull.Value)
                {
                    dtDocDate.Checked = true;
                    dtDocDate.Value = Convert.ToDateTime(oCommercialInvoice.DocDate);
                }
                if (oCommercialInvoice.DutyDate != DBNull.Value)
                {
                    dtDutyDate.Checked = true;
                    dtDutyDate.Value = Convert.ToDateTime(oCommercialInvoice.DutyDate);
                }
                oCommercialInvoice.RefreshItem();
                
                foreach (CommercialInvoiceItem oCommercialInvoiceItem in oCommercialInvoice)
                {
                    PurchaseRequisitionItem oPurchaseRequisitionItem = new PurchaseRequisitionItem();
                    DBController.Instance.OpenNewConnection();
                    oPurchaseRequisitionItem.Refresh(oCommercialInvoiceItem.ProductID, oCommercialInvoice.POID);
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oCommercialInvoiceItem.ProductDetail.ProductCode.ToString();
                    oRow.Cells[2].Value = oCommercialInvoiceItem.ProductDetail.ProductName.ToString();
                    oRow.Cells[3].Value = oCommercialInvoiceItem.UnitValue.ToString();
                    oRow.Cells[4].Value = oPurchaseRequisitionItem.LCQty.ToString();
                    oRow.Cells[5].Value = oCommercialInvoiceItem.Qty.ToString();
                    oRow.Cells[6].Value = oCommercialInvoiceItem.ProductID.ToString();                   
                    dgvLineItem.Rows.Add(oRow);

                }
                this.Tag = oCommercialInvoice;
                this.ShowDialog();
            }
            else
            {
                LoadAllCombo();               
                this.ShowDialog();
            }

        }

        private void btPOSearch_Click(object sender, EventArgs e)
        {
            frmPurchaseRequisitionSearch oForm = new frmPurchaseRequisitionSearch();
            oForm.ShowDialog();
            if (oForm.oPurchaseRequisition != null)
            {
                _nPOID = oForm.oPurchaseRequisition.POID;
                txtPONo.Text = oForm.oPurchaseRequisition.PONo;
                txtLCNo.Text = oForm.oPurchaseRequisition.LCNo;
                txtPINo.Text = oForm.oPurchaseRequisition.PINo;

                dgvLineItem.Rows.Clear();
                foreach (PurchaseRequisitionItem oPurchaseRequisitionItem in oForm.oPurchaseRequisition)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oPurchaseRequisitionItem.ProductDetail.ProductCode.ToString();
                    oRow.Cells[2].Value = oPurchaseRequisitionItem.ProductDetail.ProductName.ToString();
                    oRow.Cells[3].Value = oPurchaseRequisitionItem.UnitValue.ToString();
                    oRow.Cells[4].Value = oPurchaseRequisitionItem.LCQty.ToString();
                    oRow.Cells[6].Value = oPurchaseRequisitionItem.ProductID.ToString();
                    dgvLineItem.Rows.Add(oRow);

                }
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
            if (txtInvoiceNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Invoice Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbApplyStatus.Text == "INVOICE")
            {
                if (dtpInvoiceDate.Checked == false)
                {
                    MessageBox.Show("Please Input Invoice Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (this.Tag == null)
            {
                oCommercialInvoice = new CommercialInvoice();
                oCommercialInvoice.CINo = txtInvoiceNo.Text;
                bool IsTure=oCommercialInvoice.CheackCINo();
                if (IsTure==false)
                {
                    MessageBox.Show("Please Input Valied CI Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (cmbApplyStatus.Text == "SHIPPED")
            {
                if (dtpInvoiceDate.Checked == false)
                {
                    MessageBox.Show("Please Input Invoce Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dtpShipmentDate.Checked == false)
                {
                    MessageBox.Show("Please Input Shipped Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (cmbApplyStatus.Text == "RECEIVED_AT_PORT")
            {
                if (dtpShipmentDate.Checked == false)
                {
                    MessageBox.Show("Please Input Shipped Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dtPortArrivalDate.Checked == false)
                {
                    MessageBox.Show("Please Input Arrival Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (cmbApplyStatus.Text == "RECEIVED_AT_WH_PARTIAL" || cmbApplyStatus.Text == "RECEIVED_AT_WH_FULLY")
            {
                if (dtpShipmentDate.Checked == false)
                {
                    MessageBox.Show("Please Input Shipped Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dtPortArrivalDate.Checked == false)
                {
                    MessageBox.Show("Please Input Arrival Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dtReceivedDate.Checked == false)
                {
                    MessageBox.Show("Please Input Recevied Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
           #endregion

            #region Transaction Details Information Validation

            if (dgvLineItem.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    if (oItemRow.Cells[6].Value == null)
                    {
                        MessageBox.Show("Please Input Valied Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[6].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valied Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                   
                    if (oItemRow.Cells[5].Value.ToString().Trim() != "")
                    {
                        try
                        {
                           long temp = Convert.ToInt64(oItemRow.Cells[5].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please Input Valid Invoice Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                      
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
                oCommercialInvoice = new CommercialInvoice();
                oCommercialInvoice = SetInput(oCommercialInvoice);
                oCommercialInvoice.POID = _nPOID;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCommercialInvoice.Insert();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Invoice " , "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                oCommercialInvoice = (CommercialInvoice)this.Tag;
                oCommercialInvoice.Clear();
                oCommercialInvoice = SetInput(oCommercialInvoice);
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCommercialInvoice.Update();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Invoice ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }

        }
        public CommercialInvoice SetInput(CommercialInvoice oCommercialInvoice)
        {
            Utility oUtility = _oUtilitys[cmbApplyStatus.SelectedIndex];
        
            oCommercialInvoice.CINo = txtInvoiceNo.Text;
            oCommercialInvoice.Status = oUtility.SatusId;
            oCommercialInvoice.Remarks = Convert.ToString(txtRemarks.Text.Trim());

            try
            {
                oCommercialInvoice.InvoiceValue = Convert.ToDouble(txtInvoiceValue.Text.Trim());
            }

            catch (Exception ex)
            {
                oCommercialInvoice.InvoiceValue = Convert.ToDouble(null);
            }

            if (dtpInvoiceDate.Checked == true)
                oCommercialInvoice.CIDate = dtpInvoiceDate.Value.Date;
            else oCommercialInvoice.CIDate = null;

            if (dtPortArrivalDate.Checked == true)
                oCommercialInvoice.RPortArrivalDate = dtPortArrivalDate.Value.Date;
            else oCommercialInvoice.RPortArrivalDate = null;

            if (dtpShipmentDate.Checked== true)
                oCommercialInvoice.SPortLeaveDate = dtpShipmentDate.Value.Date;
            else oCommercialInvoice.SPortLeaveDate = null;

            if (dtReceivedDate.Checked== true)
                oCommercialInvoice.ReceviedDate = dtReceivedDate.Value.Date;
            else oCommercialInvoice.ReceviedDate = null;
            if (dtDocDate.Checked == true)
                oCommercialInvoice.DocDate = dtDocDate.Value.Date;
            else oCommercialInvoice.DocDate = null;        

            if (dtDutyDate.Checked == true)
                oCommercialInvoice.DutyDate = dtDutyDate.Value.Date;
            else oCommercialInvoice.DutyDate = null;

            if (txtDocValue.Text != "") oCommercialInvoice.DocValue = Convert.ToDouble(txtDocValue.Text.Trim());
            else oCommercialInvoice.DocValue = Convert.ToDouble(null);

            if (txtDutyAmount.Text != "") oCommercialInvoice.DutyAmount = Convert.ToDouble(txtDutyAmount.Text.Trim());
            else oCommercialInvoice.DutyAmount = Convert.ToDouble(null);
       
            
            //Loop for Grid View

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count )
                {
                   CommercialInvoiceItem oItem = new CommercialInvoiceItem();

                    try
                    {
                        oItem.UnitValue = Convert.ToInt64(oItemRow.Cells[3].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.UnitValue = Convert.ToInt64(0);
                    }
                 
                    try
                    {
                        oItem.Qty = Convert.ToInt64(oItemRow.Cells[5].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.Qty = Convert.ToInt64(0);
                    }
                   
                    oItem.ProductID = Convert.ToInt16(oItemRow.Cells[6].Value.ToString().Trim());

                    oCommercialInvoice.Add(oItem);
                }
            }
            //End loop
            return oCommercialInvoice;
        }

        private void cmbApplyStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbApplyStatus.Text == "INVOICE")
            {
                dtpInvoiceDate.Checked = true;
               
            }
            else
            {
                dtpShipmentDate.Checked = false;
                dtPortArrivalDate.Checked = false;
                dtReceivedDate.Checked = false;
            }
            if (cmbApplyStatus.Text == "SHIPPED")
            {
                dtpInvoiceDate.Checked=true;
                dtpShipmentDate.Checked = true;
            }
            else
            {
                dtPortArrivalDate.Checked = false;
                dtReceivedDate.Checked = false;
            }
            if (cmbApplyStatus.Text == "RECEIVED_AT_PORT")
            {
                dtpInvoiceDate.Checked = true;
                dtpShipmentDate.Checked = true;
                dtPortArrivalDate.Checked = true;
            }
            else
            {
               
                dtReceivedDate.Checked = false;
            }
            if (cmbApplyStatus.Text == "RECEIVED_AT_WH_PARTIAL" || cmbApplyStatus.Text == "RECEIVED_AT_WH_FULLY")
            {
                dtpInvoiceDate.Checked = true;
                dtpShipmentDate.Checked = true;
                dtPortArrivalDate.Checked = true;
                dtReceivedDate.Checked = true;
            }
            if (cmbApplyStatus.Text == "CANCELED")
            {             
                dtpShipmentDate.Checked = false;
                dtPortArrivalDate.Checked = false;
                dtReceivedDate.Checked = false;
            }
          
        }
    }
}