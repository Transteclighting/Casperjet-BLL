using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Duty;

namespace CJ.Win.Inventory
{
    public partial class frmStockTransfer : Form
    {
        int _nRefMGTTranID = 0;
        Warehouses oFromWarehouses;
        Warehouses oToWarehouses;
        Channels oFromChannels;
        Channels oToChannels;
        Warehouse oWarehouse;
        Channel _oChannel;
        ProductDetail _oProductDetail;
        ProductTransaction oProductTransaction;
        WUIUtility _oWUIUtility;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;


        DutyTran oDutyTranVAT63;
        DutyTran oDutyTranVATExampled;
        DutyTran oDutyTranVAT65_15;
        DutyTran oDutyTranVAT65_5;
        DutyAccount oDutyAccount;
       
        string sSplit = "";
        int InitializeCondition = 0;
        int nFromParentWarehouse;
        int nToParentWarehouse;
        ProductTransferProductSerial _oProductTransferProductSerial;
        ProductTransferProductSerials _oProductTransferProductSerials;
        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;
        ProductStockTranTypes _oProductStockTranTypes;
        int _nType = 0;

        public frmStockTransfer(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void frmStockTransfer_Load(object sender, EventArgs e)
        {
            if (_nType == 1)
            {
                ///Stock Transfer
                lblLoanRefNo.Visible = false;
                txtLoanRefNo.Visible = false;
                rdoStockIn.Visible = false;
                rdoStockOut.Visible = false;
                lblTransferType.Visible = false;
                lblTransSide.Visible = false;
                cmbTransferType.Visible = false;
                txtVehicleNumber.Visible = true;
                lblVehicleNumber.Visible = true;
            }
            else if (_nType == 2)
            {
                ///Stock Adjustment
                lblLoanRefNo.Visible = false;
                txtLoanRefNo.Visible = false;
                rdoStockIn.Visible = true;
                rdoStockOut.Visible = true;
                lblTransferType.Visible = true;
                lblTransSide.Visible = true;
                cmbTransferType.Visible = true;
                txtVehicleNumber.Visible = false;
                lblVehicleNumber.Visible = false;
            }
            else if (_nType == 3)
            {
                ///Management Loan Return
                lblLoanRefNo.Visible = true;
                txtLoanRefNo.Visible = true;
                rdoStockIn.Visible = false;
                rdoStockOut.Visible = false;
                lblTransferType.Visible = false;
                lblTransSide.Visible = false;
                cmbTransferType.Visible = false;
                this.currentStock.HeaderText = "Returnable Qty";
                this.txtQuantity.HeaderText = "Return Qty";
                txtVehicleNumber.Visible = true;
                lblVehicleNumber.Visible = true;
            }



            if (this.Tag == null)
                Loadcmb();
            if (_nType == 2)
            {
                rdoStockIn.Checked = true;
            }

        }
        public void Loadcmb()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            cmbFromChannel.Items.Clear();
            oFromChannels = new Channels();
            oFromChannels.GetAllChannel();
            foreach (Channel oChannel in oFromChannels)
            {
                cmbFromChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbFromChannel.SelectedIndex = oFromChannels.Count - 1;

            cmbToChannel.Items.Clear();
            oToChannels = new Channels();
            oToChannels.GetAllChannel();
            foreach (Channel oChannel in oFromChannels)
            {
                cmbToChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbToChannel.SelectedIndex = oToChannels.Count - 1;
            if (_nType == 2)
            {
                LoadcmbTransferType();
            }
        }

        public void LoadcmbTransferType()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nTranSide = 0;
            if (rdoStockIn.Checked == true)
            {
                nTranSide = (int)Dictionary.TranSide.IN;
            }
            else
            {
                nTranSide = (int)Dictionary.TranSide.OUT;
            }
            cmbTransferType.Items.Clear();
            _oProductStockTranTypes = new ProductStockTranTypes();
            _oProductStockTranTypes.GetStockTranTypeByTranSide(nTranSide);

            foreach (ProductStockTranType oProductStockTranType in _oProductStockTranTypes)
            {
                cmbTransferType.Items.Add(oProductStockTranType.TranTypeName);
            }
            cmbTransferType.SelectedIndex = 0;
        }

        private void cmbFromChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFromWH.Items.Clear();
            oFromWarehouses = new Warehouses();
            oFromWarehouses.GetAllWarehousByChannel(oFromChannels[cmbFromChannel.SelectedIndex].ChannelID);
            foreach (Warehouse oWarehouse in oFromWarehouses)
            {
                    cmbFromWH.Items.Add(oWarehouse.WarehouseDetail);
            }
            cmbFromWH.SelectedIndex = oFromWarehouses.Count - 1;

        }

        private void cmbToChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbToWH.Items.Clear();
            oToWarehouses = new Warehouses();
            oToWarehouses.GetAllWarehousByChannel(oToChannels[cmbToChannel.SelectedIndex].ChannelID);
            foreach (Warehouse oWarehouse in oToWarehouses)
            {
                    cmbToWH.Items.Add(oWarehouse.WarehouseDetail);
            }
            cmbToWH.SelectedIndex = oToWarehouses.Count - 1;
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_nType == 1 || _nType == 2)

            {
                int nRowIndex = 0;
                cmbFromChannel.Enabled = false;
                cmbFromWH.Enabled = false;
                cmbToChannel.Enabled = false;
                cmbToWH.Enabled = false;
                txtFromChannelCode.Enabled = false;
                txtFromWHCode.Enabled = false;
                txtToChannelCode.Enabled = false;
                txtToWHCode.Enabled = false;
                cmbTransferType.Enabled = false;
                rdoStockIn.Enabled = false;
                rdoStockOut.Enabled = false;


                if (e.ColumnIndex == 1)
                {
                    if (oFromChannels[cmbFromChannel.SelectedIndex].ChannelID == -1)
                    {
                        MessageBox.Show("Please select from channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID == -1)
                    {
                        MessageBox.Show("Please select from warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    frmSearchProduct oForm = new frmSearchProduct(1);
                    oForm.ShowDialog();
                    if (oForm._oProductDetail != null)
                    {
                        if (oForm._oProductDetail.RSP == 0 || oForm._oProductDetail.CostPrice == 0)
                        {
                            MessageBox.Show("Please Check Product Price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                        oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                        oRow.Cells[6].Value = oForm._oProductDetail.ProductID;
                        oRow.Cells[8].Value = oForm._nISBarcodeItem;
                        if (oForm._oProductDetail.ProductCode != null)
                        {
                            nRowIndex = dgvLineItem.Rows.Add(oRow);
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
                            if (_nType == 1) ///Stock Transfer
                            {
                                _oWUIUtility = new WUIUtility();
                                _oWUIUtility.GetCurrentStock(oFromChannels[cmbFromChannel.SelectedIndex].ChannelID, oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID, oForm._oProductDetail.ProductID);
                                oRow.Cells[4].Value = _oWUIUtility.CurrentStock;
                            }
                            else if (_nType == 2)///Stock Adjustment
                            {
                                if (_oProductStockTranTypes[cmbTransferType.SelectedIndex].TransactionSide == (int)Dictionary.TranSide.IN)
                                {
                                    _oWUIUtility = new WUIUtility();
                                    _oWUIUtility.GetCurrentStock(oToChannels[cmbToChannel.SelectedIndex].ChannelID, oToWarehouses[cmbToWH.SelectedIndex].WarehouseID, oForm._oProductDetail.ProductID);
                                    oRow.Cells[4].Value = _oWUIUtility.CurrentStock;
                                }
                                else
                                {
                                    _oWUIUtility = new WUIUtility();
                                    _oWUIUtility.GetCurrentStock(oFromChannels[cmbFromChannel.SelectedIndex].ChannelID, oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID, oForm._oProductDetail.ProductID);
                                    oRow.Cells[4].Value = _oWUIUtility.CurrentStock;
                                }
                            }

                            cmbFromChannel.Enabled = false;
                            cmbFromWH.Enabled = false;
                            txtFromChannelCode.Enabled = false;
                            txtFromWHCode.Enabled = false;
                        }

                    }
                }
            }

        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (oFromChannels == null)
            {
                return;
            }
            if (oFromWarehouses == null)
            {
                return;
            }
            if (oFromChannels[cmbFromChannel.SelectedIndex].ChannelID == -1)
            {
                MessageBox.Show("Please select from channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID == -1)
            {
                MessageBox.Show("Please select from warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_nType == 1 || _nType == 2)
            {
                if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
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

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        if (_oProductDetail.RSP == 0 || _oProductDetail.CostPrice == 0)
                        {
                            MessageBox.Show("Please Check Product Price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (_oProductDetail.ProductID).ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (_oProductDetail.IsBarcodeItem).ToString();

                        if (_nType == 1) ///Transfer
                        {
                            _oWUIUtility = new WUIUtility();
                            _oWUIUtility.GetCurrentStock(oFromChannels[cmbFromChannel.SelectedIndex].ChannelID, oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oWUIUtility.CurrentStock;
                        }
                        else if (_nType == 2) ///Adjustment
                        {
                            if (_oProductStockTranTypes[cmbTransferType.SelectedIndex].TransactionSide == (int)Dictionary.TranSide.IN)
                            {
                                _oWUIUtility = new WUIUtility();
                                _oWUIUtility.GetCurrentStock(oToChannels[cmbToChannel.SelectedIndex].ChannelID, oToWarehouses[cmbToWH.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                                dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oWUIUtility.CurrentStock;
                            }
                            else
                            {
                                _oWUIUtility = new WUIUtility();
                                _oWUIUtility.GetCurrentStock(oFromChannels[cmbFromChannel.SelectedIndex].ChannelID, oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                                dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oWUIUtility.CurrentStock;
                            }
                        }

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                        cmbFromChannel.Enabled = false;
                        cmbFromWH.Enabled = false;
                        txtFromChannelCode.Enabled = false;
                        txtFromWHCode.Enabled = false;

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
            if (nColumnIndex == 3)
            {
                long nRem = 0;
                long nQuotient = 0;

                if (_oWUIUtility.UOMConversionFactor != 0)
                {
                    try
                    {
                        nQuotient = Math.DivRem(Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[3].Value), _oWUIUtility.UOMConversionFactor, out nRem);

                        if (nRem > 0)
                        {
                            MessageBox.Show("Breaking MOQ. Please Enter Full MOQ.MOQ for the " + dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString() + "  is, " + _oWUIUtility.UOMConversionFactor.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvLineItem.Rows[nRowIndex].Cells[5].Value = "";
                            return;

                        }
                        else
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[5].Value = nQuotient;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please Enter Valied Product Quantity ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvLineItem.Rows[nRowIndex].Cells[5].Value = "";
                        return;
                    }
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

        private void txtFromChannelCode_TextChanged(object sender, EventArgs e)
        {
            _oChannel = new Channel();
            _oChannel.ChannelCode = txtFromChannelCode.Text;
            _oChannel.RefreshByCode();
            if (_oChannel.ChannelID != 0)
            {
                cmbFromChannel.SelectedIndex = oFromChannels.GetIndex(_oChannel.ChannelID);
                txtFromWHCode.Enabled = true;
                cmbFromChannel_SelectedIndexChanged(null, null);
            }
            else
            {
                cmbFromChannel.SelectedIndex = oFromChannels.Count - 1;
                txtFromWHCode.Enabled = false;
                cmbFromChannel_SelectedIndexChanged(null, null);
            }
        }

        private void txtFromWHCode_TextChanged(object sender, EventArgs e)
        {
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseCode = txtFromWHCode.Text;
            oWarehouse.RereshByCode();
            if (oWarehouse.WarehouseID != 0)
            {
                if (oFromWarehouses.GetIndex(oWarehouse.WarehouseID) != -1)
                    cmbFromWH.SelectedIndex = oFromWarehouses.GetIndex(oWarehouse.WarehouseID);
                else cmbFromWH.SelectedIndex = oFromWarehouses.Count - 1;

            }
            else cmbFromWH.SelectedIndex = oFromWarehouses.Count - 1;
        }

        private void txtToChannelCode_TextChanged(object sender, EventArgs e)
        {
            _oChannel = new Channel();
            _oChannel.ChannelCode = txtToChannelCode.Text;
            _oChannel.RefreshByCode();
            if (_oChannel.ChannelID != 0)
            {
                cmbToChannel.SelectedIndex = oToChannels.GetIndex(_oChannel.ChannelID);
                txtToWHCode.Enabled = true;
                cmbToChannel_SelectedIndexChanged(null, null);
            }
            else
            {
                cmbToChannel.SelectedIndex = oToChannels.Count - 1;
                txtToWHCode.Enabled = false;
                cmbToChannel_SelectedIndexChanged(null, null);
            }
        }

        private void txtToWHCode_TextChanged(object sender, EventArgs e)
        {
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseCode = txtToWHCode.Text;
            oWarehouse.RereshByCode();
            if (oWarehouse.WarehouseID != 0)
            {
                if (oToWarehouses.GetIndex(oWarehouse.WarehouseID) != -1)
                    cmbToWH.SelectedIndex = oToWarehouses.GetIndex(oWarehouse.WarehouseID);
                else cmbToWH.SelectedIndex = oToWarehouses.Count - 1;
            }
            else cmbToWH.SelectedIndex = oToWarehouses.Count - 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool validateUIInput()
        {
            #region Transaction Master Information Validation
            ProductTransaction  oProductTran = new ProductTransaction();
            oProductTran.TranNo = txtTransationNo.Text;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (!oProductTran.CheckTranNo())
            {
                MessageBox.Show("Duplicate Transaction# .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTransationNo.Focus();
                return false;
            }

            if (txtTransationNo.Text == "")
            {
                MessageBox.Show("Please input tranno.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTransationNo.Focus();
                return false;
            }
            if (oFromChannels[cmbFromChannel.SelectedIndex].ChannelID == -1)
            {
                MessageBox.Show("Please Select a From Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFromChannel.Focus();
                return false;
            }
            if (oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID == -1)
            {
                MessageBox.Show("Please Select a from Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFromWH.Focus();
                return false;
            }
            if (oToChannels[cmbToChannel.SelectedIndex].ChannelID == -1)
            {
                MessageBox.Show("Please Select a to Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToChannel.Focus();
                return false;
            }
            if (oToWarehouses[cmbToWH.SelectedIndex].WarehouseID == -1)
            {
                MessageBox.Show("Please Select a to Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToWH.Focus();
                return false;
            }

            if (oToWarehouses[cmbToWH.SelectedIndex].WarehouseID == oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID)
            {
                MessageBox.Show("From warehouse & to warehouse must be different", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToWH.Focus();
                return false;
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
                    if (oItemRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (int.Parse(oItemRow.Cells[8].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        try
                        {
                            int temps = int.Parse(oItemRow.Cells[7].Value.ToString());
                        }
                        catch
                        {
                            MessageBox.Show("Please Provide Barcode Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    //if (oItemRow.Cells[3].Value != null)
                    //{
                    //    DBController.Instance.OpenNewConnection();
                    //    Product _oProduct = new Product();
                    //    _oProduct.ProductID = Convert.ToInt32(oItemRow.Cells[6].Value);
                    //    _oProduct.RefreshByProductID();
                    //    if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.YES)
                    //    {
                    //        if (Convert.ToInt32(oItemRow.Cells[3].Value) != Convert.ToInt32(oItemRow.Cells[7].Value))
                    //        {
                    //            MessageBox.Show("Please Provide Barcode Serial ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            return false;
                    //        }
                    //    }
                    //}
                    if (rdoStockIn.Checked == true)
                    {

                    }
                    else
                    {
                        if (int.Parse(oItemRow.Cells[3].Value.ToString()) > int.Parse(oItemRow.Cells[4].Value.ToString()))
                        {
                            MessageBox.Show("Quntity Must Less or equal Current stock Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
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
                if (this.Tag == null)
                {
                    try
                    {
                        oProductTransaction = new ProductTransaction();
                        oProductTransaction = GetUIProductTransactionData(oProductTransaction);
                        DBController.Instance.BeginNewTransaction();

                        oProductTransaction.LastUpdateUserID = Utility.UserId;
                        oProductTransaction.LastUpdateDate = DateTime.Now;
                        bool IsTrue = false;


                        if (_nType == 1)
                        {
                            IsTrue = true;
                        }
                        else if (_nType == 3)
                        {
                            IsTrue = true;
                        }
                        else if (_nType == 2)
                        {
                            if (rdoStockIn.Checked == true)
                            {
                                IsTrue = true;
                            }
                            else
                            {
                                IsTrue = false;
                            }

                        }

                        if (oProductTransaction.CheckTranNo())
                        {
                            if (oProductTransaction.InsertForTransferWithIMEI(IsTrue, _nType, _nRefMGTTranID))
                            {

                                if (_oProductTransferProductSerials != null)
                                {

                                    foreach (ProductTransferProductSerial oPTPS in _oProductTransferProductSerials)
                                    {
                                        //Insert t_ProductTransferProductSerial
                                        if (Utility.CompanyInfo == "TEL")
                                        {
                                            oPTPS.DeleteFromHO();
                                            oPTPS.InsertHOStockSerial(oProductTransaction.TranID, oProductTransaction.ToWHID);
                                            oPTPS.InsertTELHQ(oProductTransaction.TranID);

                                        }
                                        else if (Utility.CompanyInfo == "TML")
                                        {
                                            oPTPS.DeleteFromHO();
                                            oPTPS.InsertHOStockSerial(oProductTransaction.TranID, oProductTransaction.ToWHID);
                                            oPTPS.InsertTML(oProductTransaction.TranID);
                                        }

                                    }
                                }

                                #region New Duty
                                if (_nType != 2)///Adjestment 
                                {
                                    DutyTran oElegForVat = new DutyTran();
                                    if (oElegForVat.IsElegiableForDutyTran(oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID))
                                    {
                                        if (oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseParentID != oToWarehouses[cmbToWH.SelectedIndex].WarehouseParentID)
                                        {
                                            if (Utility.CompanyInfo == "TEL")
                                            {
                                                InsertVAT65(oProductTransaction.TranID, oProductTransaction.TranNo);
                                            }
                                        }
                                    }
                                }
                                #endregion


                                #region Serial Validation
                                ProductStockTran oChkProductStockTran = new ProductStockTran();
                                if (oChkProductStockTran.CheckStockTranItem(oProductTransaction.TranID))
                                {
                                    if (oChkProductStockTran.CheckStockSerial(oProductTransaction.TranID))
                                    {
                                        MessageBox.Show(@"Duplicate Product Serial", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(@"Product serial & tran qty not matched", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                #endregion

                                DBController.Instance.CommitTransaction();
                                MessageBox.Show("You Have Successfully Add the transaction- " + oProductTransaction.TranNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                DBController.Instance.RollbackTransaction();
                                MessageBox.Show("Stock error... ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        else
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Duplicate tran no,please input valied tran no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
                else
                {
                }

            }
        }
        private void InsertVAT65(int nTranID, string sTranNo)
        {
            DutyAccounts oDetail = new DutyAccounts();
            oDetail.GetDutyDetailNew("Transfer", Convert.ToInt32(nTranID));

            double _TotalAmount_65_15 = 0;
            double _TotalAmount_65_5 = 0;
            int countMUSHAK_65_15 = 0;
            int countMUSHAK_65_5 = 0;
            int countMUSHAK_Exampled = 0;

            oDutyTranVAT65_15 = new DutyTran();
            oDutyTranVAT65_5 = new DutyTran();
            oDutyTranVATExampled = new DutyTran();

            foreach (DutyAccount oDutyTranDetail in oDetail)
            {
                if (oDutyTranDetail.VATType == (int)Dictionary.VATType.IMPORTED_15 || oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_15)
                {
                    if (countMUSHAK_65_15 == 0)
                    {

                        DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVAT65_15.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVAT65_15.WHID = oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID;
                        oDutyTranVAT65_15.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVAT65_15.DocumentNo = sTranNo;
                        oDutyTranVAT65_15.RefID = nTranID;
                        oDutyTranVAT65_15.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVAT65_15.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                        oDutyTranVAT65_15.Remarks = txtRemarks.Text;
                        oDutyTranVAT65_15.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVAT65_15.Amount = 0;
                        oDutyTranVAT65_15.VehicleNumber = txtVehicleNumber.Text.Trim();
                        oDutyTranVAT65_15.InsertNewHOVAT();
                        countMUSHAK_65_15++;
                    }

                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVAT65_15.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    oItem.DutyPrice = oDutyTranDetail.VATCP;
                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    oItem.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;
                    _TotalAmount_65_15 = _TotalAmount_65_15 + oItem.VAT;
                    oItem.InsertNewVATHO63();

                }
                else if (oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_5 || oDutyTranDetail.VATType == (int)Dictionary.VATType.IMPORTED_5)
                {
                    if (countMUSHAK_65_5 == 0)
                    {

                        DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVAT65_5.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVAT65_5.WHID = oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID;
                        oDutyTranVAT65_5.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVAT65_5.DocumentNo = sTranNo;
                        oDutyTranVAT65_5.RefID = nTranID;
                        oDutyTranVAT65_5.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVAT65_5.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                        oDutyTranVAT65_5.Remarks = txtRemarks.Text;
                        oDutyTranVAT65_5.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVAT65_5.Amount = 0;
                        oDutyTranVAT65_5.VehicleNumber = txtVehicleNumber.Text.Trim();
                        oDutyTranVAT65_5.InsertNewHOVAT();
                        countMUSHAK_65_5++;
                    }

                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVAT65_5.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    oItem.DutyPrice = oDutyTranDetail.VATCP;
                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    oItem.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;
                    _TotalAmount_65_5 = _TotalAmount_65_5 + oItem.VAT;
                    oItem.InsertNewVATHO63();

                }
                else
                {
                    if (countMUSHAK_Exampled == 0)
                    {

                        DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVATExampled.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVATExampled.WHID = oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID;
                        oDutyTranVATExampled.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVATExampled.DocumentNo = sTranNo;
                        oDutyTranVATExampled.RefID = nTranID;
                        oDutyTranVATExampled.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVATExampled.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                        oDutyTranVATExampled.Remarks = txtRemarks.Text;
                        oDutyTranVATExampled.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVATExampled.Amount = 0;
                        oDutyTranVATExampled.VehicleNumber = txtVehicleNumber.Text.Trim();
                        oDutyTranVATExampled.InsertNewHOVAT();
                        countMUSHAK_Exampled++;
                    }
                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVATExampled.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    oItem.DutyPrice = oDutyTranDetail.VATCP;
                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    oItem.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;
                    oItem.InsertNewVATHO63();

                }

            }

            oDutyTranVAT65_15.Amount = _TotalAmount_65_15;
            oDutyTranVAT65_15.UpdateToatlVATAmountHO();

            oDutyTranVAT65_5.Amount = _TotalAmount_65_5;
            oDutyTranVAT65_5.UpdateToatlVATAmountHO();



            oDutyAccount = new DutyAccount();
            oDutyAccount.DutyAccountTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
            oDutyAccount.Balance = _TotalAmount_65_15 + _TotalAmount_65_5;
            oDutyAccount.UpdateBalance(true);



        }
        public ProductTransaction GetUIProductTransactionData(ProductTransaction oProductTransaction)
        {
            oProductTransaction.TranNo = txtTransationNo.Text;
            oProductTransaction.TranDate = dtTransactionDate.Value;
            oProductTransaction.UserID = Utility.UserId;
            oProductTransaction.CreateDate = dtTransactionDate.Value.Date;
            if (_nType == 1) ///Transfer 
            {
                oProductTransaction.TranTypeID = (int)Dictionary.ProductStockTranType.TRANSFER;
            }
            else if (_nType == 2)///Adjustment
            {
                oProductTransaction.TranTypeID = _oProductStockTranTypes[cmbTransferType.SelectedIndex].TranTypeID;
            }
            if (_nType == 3) ///Loan Return
            {
                oProductTransaction.TranTypeID = (int)Dictionary.ProductStockTranType.TRANSFER;
            }
            oProductTransaction.ToWHID = oToWarehouses[cmbToWH.SelectedIndex].WarehouseID;
            oProductTransaction.ToChannelID = oToChannels[cmbToChannel.SelectedIndex].ChannelID;
            oProductTransaction.FromChannelID = oFromChannels[cmbFromChannel.SelectedIndex].ChannelID;
            oProductTransaction.FromWHID = oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID;


            oProductTransaction.Remarks = txtRemarks.Text;
            oProductTransaction.Status = (int)Dictionary.StockTransactionStatus.COMPLETE;

            // Product Detail

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    ProductTransactionDetail oItem = new ProductTransactionDetail();

                    try
                    {
                        oItem.Qty = Convert.ToInt64(oItemRow.Cells[3].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.Qty = Convert.ToInt64(0);
                    }
                    oItem.ProductID = Convert.ToInt16(oItemRow.Cells[6].Value.ToString().Trim());
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = oItem.ProductID;
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    _oProductDetail.Refresh();
                    oItem.StockPrice = _oProductDetail.CostPrice;

                    oProductTransaction.Add(oItem);


                }
            }

            return oProductTransaction;
        }

        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA)
        {
            oDutyTranVAT11KA = new DutyTran();

            oDutyTranVAT11KA.DutyTranDate = oProductTransaction.TranDate;
            oDutyTranVAT11KA.WHID = oProductTransaction.FromWHID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = oProductTransaction.TranNo;
            oDutyTranVAT11KA.RefID = oProductTransaction.TranID;
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11KA.Remarks = "NA";
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (ProductTransactionDetail oItem in oProductTransaction)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = (int)oItem.Qty;

                    CustomerDetail oCustomerDetail = new CustomerDetail();
                    //oProductTransaction = new ProductTransaction();
                    oCustomerDetail.ChannelID = oProductTransaction.FromChannelID;
                    oCustomerDetail.RefreshChannel(oProductTransaction.FromChannelID);

                    if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                    {
                        oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                        oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                    }
                    else
                    {
                        oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                        oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                    }


                    //oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                    //oDutyTranDetail.DutyRate = _oProductDetail.Vat;

                    _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11KA.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        ///
        //  For VAT 11 
        ///
        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11)
        {
            oDutyTranVAT11 = new DutyTran();

            oDutyTranVAT11.DutyTranDate = oProductTransaction.TranDate;
            oDutyTranVAT11.WHID = oProductTransaction.FromWHID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = oProductTransaction.TranNo;
            oDutyTranVAT11.RefID = oProductTransaction.TranID;
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11.Remarks = "NA";
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (ProductTransactionDetail oItem in oProductTransaction)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = (int)oItem.Qty;

                    CustomerDetail oCustomerDetail = new CustomerDetail();
                    //oProductTransaction = new ProductTransaction();
                    oCustomerDetail.ChannelID = oProductTransaction.FromChannelID;
                    oCustomerDetail.RefreshChannel(oProductTransaction.FromChannelID);

                    if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                    {
                        oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                        oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                    }
                    else
                    {
                        oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                        oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                    }

                    //oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                    //oDutyTranDetail.DutyRate = _oProductDetail.Vat;

                    _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }
        public bool IMEICheckFromCollection()
        {
            foreach (ProductTransferProductSerial oSIPS in _oProductTransferProductSerials)
            {
                if (oSIPS.ProductSerialNo != sSplit)
                {
                    return true;
                }
            }

            return false;
        }

        private void btIMEIValid_Click(object sender, EventArgs e)
        {
            int IMEIQty = 0;
            if (txtIMEIList.Text.Trim() != "")
            {
                if (InitializeCondition == 0)
                {
                    _oProductTransferProductSerials = new ProductTransferProductSerials();
                }
                _oProductTransferProductSerial = new ProductTransferProductSerial();
                string value = txtIMEIList.Text;
                char[] delimiter = new char[] { '\r', '\n' };
                string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                {

                    sSplit = parts[i].ToString();

                    _oProductTransferProductSerial = new ProductTransferProductSerial();
                    _oProductTransferProductSerial.ProductSerialNo = sSplit.Trim();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    _oProductTransferProductSerial.WarehouseID = oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID;
                    _oProductTransferProductSerial.GetUnusedBarcodeHoNew();
                    DBController.Instance.CloseConnection();

                    if (dgvLineItem.Rows.Count > 0)
                    {

                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {
                            if (oItemRow.Cells[3].Value != null)
                            {
                                if ((oItemRow.Cells[0].Value.ToString().Trim()) == _oProductTransferProductSerial.ProductCode)
                                {

                                    if (oItemRow.Cells[7].Value == null)
                                    {
                                        IMEIQty = 0;
                                        if (IMEIQty <= Convert.ToInt32(oItemRow.Cells[3].Value))
                                        {
                                            oItemRow.Cells[7].Value = IMEIQty + 1;

                                            _oProductTransferProductSerial.ProductID = _oProductTransferProductSerial.ProductID;
                                            _oProductTransferProductSerial.ProductSerialNo = sSplit;
                                            _oProductTransferProductSerials.Add(_oProductTransferProductSerial);

                                            InitializeCondition = 1;
                                        }

                                    }
                                    else
                                    {

                                        if (IMEICheckFromCollection())
                                        {
                                            if (Convert.ToInt32(oItemRow.Cells[7].Value) < Convert.ToInt32(oItemRow.Cells[3].Value))
                                            {
                                                oItemRow.Cells[7].Value = Convert.ToInt32(oItemRow.Cells[7].Value) + 1;

                                                _oProductTransferProductSerial.ProductID = _oProductTransferProductSerial.ProductID;
                                                _oProductTransferProductSerial.ProductSerialNo = sSplit;
                                                _oProductTransferProductSerials.Add(_oProductTransferProductSerial);
                                            }


                                        }
                                        else
                                        {
                                        }
                                    }

                                }

                            }

                        }

                    }

                }
                txtIMEIList.Text = "";
            }
            else
            {
                MessageBox.Show("There is no Barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void rdoStockOut_CheckedChanged(object sender, EventArgs e)
        {
            if (_nType == 2) ///Adjustment
            {
                LoadcmbTransferType();
                if (_oProductStockTranTypes[cmbTransferType.SelectedIndex].TransactionSide == (int)Dictionary.TranSide.IN)
                {
                    cmbFromChannel.SelectedIndex = oFromChannels.GetIndex(1);
                    cmbFromWH.SelectedIndex = oFromWarehouses.GetIndex(1);
                    cmbFromChannel.Enabled = false;
                    cmbFromWH.Enabled = false;
                    cmbToChannel.Enabled = true;
                    cmbToWH.Enabled = true;
                }
                else
                {
                    cmbToChannel.SelectedIndex = oToChannels.GetIndex(1);
                    cmbToWH.SelectedIndex = oToWarehouses.GetIndex(1);
                    cmbFromChannel.Enabled = true;
                    cmbFromWH.Enabled = true;
                    cmbToChannel.Enabled = false;
                    cmbToWH.Enabled = false;
                }
            }
        }

        private void rdoStockIn_CheckedChanged(object sender, EventArgs e)
        {
            if (_nType == 2)  ///Adjustment
            {
                LoadcmbTransferType();
                if (_oProductStockTranTypes[cmbTransferType.SelectedIndex].TransactionSide == (int)Dictionary.TranSide.IN)
                {
                    cmbFromChannel.SelectedIndex = oFromChannels.GetIndex(1);
                    cmbFromWH.SelectedIndex = oFromWarehouses.GetIndex(1);
                    cmbFromChannel.Enabled = false;
                    cmbFromWH.Enabled = false;
                    cmbToChannel.Enabled = true;
                    cmbToWH.Enabled = true;
                    txtFromChannelCode.Enabled = false;
                    txtFromWHCode.Enabled = false;
                    txtToChannelCode.Enabled = true;
                    txtToWHCode.Enabled = true;
                }
                else
                {
                    cmbToChannel.SelectedIndex = oToChannels.GetIndex(1);
                    cmbToWH.SelectedIndex = oToWarehouses.GetIndex(1);
                    cmbFromChannel.Enabled = true;
                    cmbFromWH.Enabled = true;
                    cmbToChannel.Enabled = false;
                    cmbToWH.Enabled = false;
                    txtFromChannelCode.Enabled = true;
                    txtFromWHCode.Enabled = true;
                    txtToChannelCode.Enabled = false;
                    txtToWHCode.Enabled = false;
                }
            }
        }

        private void txtLoanRefNo_TextChanged(object sender, EventArgs e)
        {
            if (_nType == 3)
            {
                _nRefMGTTranID = 0;
                ProductStockTran oTran = new ProductStockTran();
                if (oTran.GetWarehouseCode(txtLoanRefNo.Text))
                {
                    _nRefMGTTranID = oTran.TranID;
                    txtLoanRefNo.Enabled = false;
                    txtFromChannelCode.Text = oTran.FromChannelCode;
                    txtFromWHCode.Text = oTran.FromWarehouse;
                    txtToChannelCode.Text = oTran.ToChannelCode;
                    txtToWHCode.Text = oTran.ToWarehouse;

                    cmbFromChannel.Enabled = false;
                    cmbFromWH.Enabled = false;
                    cmbToChannel.Enabled = false;
                    cmbToWH.Enabled = false;
                    txtFromChannelCode.Enabled = false;
                    txtFromWHCode.Enabled = false;
                    txtToChannelCode.Enabled = false;
                    txtToWHCode.Enabled = false;

                    ProductStockTranItems oProductStockTranItems = new ProductStockTranItems();
                    oProductStockTranItems.GetMGTItem(txtLoanRefNo.Text);
                    dgvLineItem.Rows.Clear();

                    foreach (ProductStockTranItem oItem in oProductStockTranItems)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);

                        oRow.Cells[0].Value = oItem.ProductCode.ToString();
                        oRow.Cells[2].Value = oItem.ProductName.ToString();
                        oRow.Cells[3].Value = oItem.Qty.ToString();
                        oRow.Cells[4].Value = oItem.Qty.ToString();
                        oRow.Cells[6].Value = oItem.ProductID.ToString();
                        oRow.Cells[8].Value = oItem.IsBarcodeItem.ToString();
                        dgvLineItem.Rows.Add(oRow);

                    }
                }

                
            }
        }

        private void cmbTransferType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}