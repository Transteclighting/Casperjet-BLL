using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.BasicData;
using CJ.Class.Library;
using CJ.Class.CSD;

namespace CJ.Win.Inventory
{
    public partial class frmGRD : Form
    {
        Channels _oChannels;
        Warehouses _oWarehouses;
        SCMShipment _oSCMShipment;
        SCMShipments _oSCMShipments;
        ProductTransaction _oProductTransaction;
        ProductTransaction _oProductTransactionGRD;
        int _nSupplierID = 0;
        ProductTransactionDetail _oProductTransactionDetail;
        int nQty = 0;
        double nCP = 0;


        public frmGRD()
        {
            InitializeComponent();
        }

        public void LoadCombo()
        {
            //// Channels
            //_oChannels = new Channels();
            //_oChannels.GetChannelForGRD();
            //cmbToChannel.Items.Clear();
            //cmbToChannel.Items.Add("<Select Channel>");
            //foreach (Channel oChannel in _oChannels)
            //{
            //    cmbToChannel.Items.Add(oChannel.ChannelDescription + "[" + oChannel.ChannelCode + "]");
            //}
            //cmbToChannel.SelectedIndex = 0;
            _oChannels = new Channels();
            _oChannels.GetAllChannel();
            cmbToChannel.Items.Clear();
            foreach (Channel oChannel in _oChannels)
            {
                cmbToChannel.Items.Add(oChannel.ChannelDescription + "[" + oChannel.ChannelCode + "]");
            }
            if (_oChannels.Count > 0)
                cmbToChannel.SelectedIndex = _oChannels.Count - 1;


            // GetShipment

            _oSCMShipments = new SCMShipments();
            _oSCMShipments.GetShipment();
            cmbShipmentNo.Items.Clear();
            cmbShipmentNo.Items.Add("<Select Shipment >");
            foreach (SCMShipment oSCMShipment in _oSCMShipments)
            {
                cmbShipmentNo.Items.Add(oSCMShipment.ShipmentNo);
            }
            cmbShipmentNo.SelectedIndex = 0;


        }
        private void cmbToChannel_SelectedIndexChanged(object sender, EventArgs e)
        {


            //// Warehouses
            //_oWarehouses = new Warehouses();
            //_oWarehouses.GetWHForGRD(_oChannels[cmbToChannel.SelectedIndex].ChannelID);
            //cmbToWarehouse.Items.Clear();
            //cmbToWarehouse.Items.Add("<Select Warehouse >");
            //foreach (Warehouse oWarehouse in _oWarehouses)
            //{
            //    cmbToWarehouse.Items.Add(oWarehouse.WarehouseName + "[" + oWarehouse.WarehouseCode + "]");
            //}
            //cmbToWarehouse.SelectedIndex = 0;
            _oWarehouses = new Warehouses();
            _oWarehouses.GetWarehousByChannel(_oChannels[cmbToChannel.SelectedIndex].ChannelID);
            cmbToWarehouse.Items.Clear();
            foreach (Warehouse oWarehouse in _oWarehouses)
            {
                cmbToWarehouse.Items.Add(oWarehouse.WarehouseName + "[" + oWarehouse.WarehouseCode + "]");
            }
            if (_oWarehouses.Count > 0)
                cmbToWarehouse.SelectedIndex = _oWarehouses.Count - 1;


        }

        private void cmbShipmentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbShipmentNo.SelectedIndex != 0)
            {
                dgvLineItem.Rows.Clear();
                _oSCMShipment = new SCMShipment();
                if (_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].Description == "Shipment")
                {
                    _oSCMShipment.RefreshShipmentForGRD(_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID);
                    _oSCMShipment.RefreshShipmentItemForGRD();
                }
                else if (_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].Description == "Challan")
                {
                    _oSCMShipment.RefreshChallanForGRD(_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID);
                    _oSCMShipment.RefreshChallanItemForGRD();
                }

                _nSupplierID = _oSCMShipment.SupplierID;
                txtShipmentDate.Text = Convert.ToDateTime(_oSCMShipment.ShipmentDate).ToString("dd-MMM-yyyy");
                txtInvoiceNo.Text = _oSCMShipment.InvoiceNo;
                txtInvoiceDate.Text = Convert.ToDateTime(_oSCMShipment.InvoiceDate).ToString("dd-MMM-yyyy");
                txtCompany.Text = _oSCMShipment.CompanyName;
                txtSupplyer.Text = _oSCMShipment.SupplierName;
                txtLCNo.Text = _oSCMShipment.LCNo;
                txtLCDate.Text = Convert.ToDateTime(_oSCMShipment.LCDate).ToString("dd-MMM-yyyy");
                txtPINo.Text = _oSCMShipment.PINo;
                txtPIDate.Text = Convert.ToDateTime(_oSCMShipment.PIReceiveDate).ToString("dd-MMM-yyyy");
                txtOrderNo.Text = _oSCMShipment.OrderNo;
                txtOrderDate.Text = Convert.ToDateTime(_oSCMShipment.OrderPlaceDate).ToString("dd-MMM-yyyy");
                txtPSINo.Text = _oSCMShipment.PSINo;
                txtPSIDate.Text = Convert.ToDateTime(_oSCMShipment.PSIDate).ToString("dd-MMM-yyyy");

                foreach (SCMShipmentItem oSCMShipmentItem in _oSCMShipment)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oSCMShipmentItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMShipmentItem.ProductName.ToString();
                    oRow.Cells[2].Value = oSCMShipmentItem.ShipmentQty.ToString();
                    oRow.Cells[3].Value = oSCMShipmentItem.GRDQty.ToString();
                    oRow.Cells[4].Value = ((oSCMShipmentItem.ShipmentQty) - (oSCMShipmentItem.GRDQty));
                    oRow.Cells[5].Value = 0;
                    oRow.Cells[6].Value = 0;
                    oRow.Cells[7].Value = 0;
                    //oRow.Cells[7].Value = "";
                    oRow.Cells[9].Value = oSCMShipmentItem.ProductID.ToString();
                    oRow.Cells[10].Value = oSCMShipmentItem.CostPrice.ToString();
                    oRow.Cells[11].Value = oSCMShipmentItem.IsBarcodeItem.ToString();
                    oRow.Cells[12].Value = oSCMShipmentItem.InventoryCategory.ToString();
                    dgvLineItem.Rows.Add(oRow);

                }
            }
            else
            {
                _nSupplierID = 0;
                Clear();
            }
        }

        private void frmGRD_Load(object sender, EventArgs e)
        {
            LoadCombo();

        }
        private bool ValidateUIInput()
        {
            #region ProductDetail
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    int nPrevGRDQty = 0;
                    int nGRDQty = 0;
                    int nShipmentQty = 0;

                    if (Convert.ToInt32(oItemRow.Cells[12].Value) == (int)Dictionary.InventoryCate.Aged || Convert.ToInt32(oItemRow.Cells[12].Value) == (int)Dictionary.InventoryCate.Discontinue)
                    {
                        MessageBox.Show(@"You cannot choose an irregular or eol product for GRD", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }                   

                    if (oItemRow.Cells[2].Value != null || oItemRow.Cells[2].Value != "")
                    {
                        nShipmentQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                    }
                    if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value != "")
                    {
                        nPrevGRDQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }
                    if (oItemRow.Cells[4].Value != null || oItemRow.Cells[4].Value.ToString().Trim() != "")
                    {
                        nGRDQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    if (nShipmentQty >= (nPrevGRDQty + nGRDQty))
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("(Prev GRD Qty + GRD Qty) Qty must be less or equal Shipment Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }


                }
            }
            #endregion

            #region ValidInput

            if (txtTransationRef.Text == "")
            {
                MessageBox.Show("Please Input GRD No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTransationRef.Focus();
                return false;
            }

            
            if (txtTransationRef.Text != "")
            {
                _oProductTransaction = new ProductTransaction();
                _oProductTransaction.TranNo = txtTransationRef.Text;
                if (!_oProductTransaction.CheckProductStockTranNo())
                {
                    MessageBox.Show("Please input valied GRD No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTransationRef.Focus();

                    return false;
                }

            }

            if (_oChannels[cmbToChannel.SelectedIndex].ChannelID == -1)
            {
                MessageBox.Show("Please Select a Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToChannel.Focus();
                return false;
            }

            if (_oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID == -1)
            {
                MessageBox.Show("Please Select a Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToWarehouse.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductTransaction _oTransaction = new ProductTransaction();
            DBController.Instance.OpenNewConnection();
            if (_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].Description == "Shipment")
            {
                _oTransaction.RefreshIsShipmentQtyEqual(_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID);
            }
            else if (_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].Description == "Challan")
            {
                _oTransaction.RefreshIsChallanQtyEqual(_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID);
            }

            if (_oTransaction.IsEqual == 0)
            {
                MessageBox.Show("There is no Shipment Qty for GRD: PSINo " + _oSCMShipments[cmbShipmentNo.SelectedIndex].ShipmentNo, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();

            }
            else if (ValidateUIInput())
            {

                _oProductTransaction = new ProductTransaction();
                _oProductTransaction.TranNo = txtTransationRef.Text;
                _oProductTransaction.TranDate = DateTime.Today.Date;
                _oProductTransaction.ToWHID = _oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID;
                _oProductTransaction.ToChannelID = _oChannels[cmbToChannel.SelectedIndex].ChannelID;
                _oProductTransaction.Remarks = txtRemarks.Text;
                _oProductTransaction.UserID = Utility.UserId;
                _oProductTransaction.Terminal = (int)Dictionary.Terminal.Head_Office;
                _oProductTransaction.LCNo = txtLCNo.Text;
                _oProductTransaction.LCDate = Convert.ToDateTime(txtLCDate.Text);
                _oProductTransaction.LCInvoiceNo = txtInvoiceNo.Text;
                _oProductTransaction.LCInvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
                _oProductTransaction.ShipmentID = _oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    //_oProductTransaction = new ProductTransaction();
                    //_oProductTransaction = GetUIData(_oProductTransaction);
                    _oProductTransaction.Add();
                    _oProductTransactionGRD = new ProductTransaction();
                    if (_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].Description == "Shipment")
                    {
                        _oProductTransactionGRD.TranID = _oProductTransaction.TranID;
                        _oProductTransactionGRD.ShipmentID = _oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID;
                        _oProductTransactionGRD.AddSCMGRDData();
                    }
                    else if (_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].Description == "Challan")
                    {
                        _oProductTransactionGRD.TranID = _oProductTransaction.TranID;
                        _oProductTransactionGRD.ChallanID = _oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID;
                        _oProductTransactionGRD.AddSCMGRDData();
                    }
                    int nNoofBarcodeQty = 0;

                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count)
                        {

                            _oProductTransactionDetail = new ProductTransactionDetail();

                            _oProductTransactionDetail.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                            nQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                            _oProductTransactionDetail.Qty = nQty;
                            nCP = Convert.ToDouble(oItemRow.Cells[10].Value.ToString());
                            _oProductTransactionDetail.StockPrice = nQty * nCP;
                            _oProductTransactionDetail.LCShortQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                            _oProductTransactionDetail.LCDamagedQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                            _oProductTransactionDetail.LCMinorDefectiveQty = int.Parse(oItemRow.Cells[7].Value.ToString());
                            if (int.Parse(oItemRow.Cells[11].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                nNoofBarcodeQty = nNoofBarcodeQty + nQty;
                            }


                            if (oItemRow.Cells[8].Value != null)
                            {
                                _oProductTransactionDetail.LCRemarks = (oItemRow.Cells[8].Value.ToString());;
                            }
                            if (_oProductTransactionDetail.Qty != 0)
                                _oProductTransactionDetail.InsertForGRD(_oProductTransaction.TranID);
                        }
                        
                    }
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count)
                        {

                            ProductStock oItem = new ProductStock();

                            oItem.WarehouseID = _oProductTransaction.ToWHID;
                            oItem.ChannelID = _oProductTransaction.ToChannelID;
                            oItem.Quantity = int.Parse(oItemRow.Cells[4].Value.ToString());
                            oItem.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                            if (oItem.CheckProductStockBy())
                                oItem.UpdateCurrentStock_GRD(true);
                            else
                            {
                                oItem.Insert();
                                oItem.UpdateCurrentStock_GRD(true);
                            }

                        }
                        
                    }

                    bool _IsTrueBarcodeUpload = false;

                    if (nNoofBarcodeQty > 0)
                    {
                        _IsTrueBarcodeUpload = false;
                        if (MessageBox.Show("Do you want to generate barcode automatically ", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmBarcodeSystemBE oForm = new frmBarcodeSystemBE(txtTransationRef.Text, _oProductTransaction.TranDate, _oProductTransaction.TranID, _oProductTransaction.ToWHID);
                            oForm.ShowDialog();
                            if (oForm._TotalGereratedQty == nNoofBarcodeQty)
                            {
                                _IsTrueBarcodeUpload = oForm._IsTrue;
                            }
                            else
                            {
                                DBController.Instance.RollbackTransaction();
                                MessageBox.Show("GRD & uploaded serial qty not matched...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                _IsTrueBarcodeUpload = false;
                            }
                          
                        }
                        else
                        {
                            frmProductSerialUpload oForm = new frmProductSerialUpload(_oProductTransaction.ToWHID, _oProductTransaction.TranNo, _oProductTransaction.TranID);
                            oForm.ShowDialog();
                            if (oForm._TotalGereratedQty == nNoofBarcodeQty)
                            {
                                _IsTrueBarcodeUpload = oForm._IsTrue;
                            }
                            else
                            {
                                DBController.Instance.RollbackTransaction();
                                MessageBox.Show("GRD & uploaded serial qty not matched...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                _IsTrueBarcodeUpload = false;
                            }
                        }
                    }
                    else
                    {
                        _IsTrueBarcodeUpload = true;
                    }

                    #region Serial Validation
                    ProductStockTran oChkProductStockTran = new ProductStockTran();
                    if (oChkProductStockTran.CheckStockTranItem(_oProductTransaction.TranID))
                    {
                        if (oChkProductStockTran.CheckHOSerialDiff(_oProductTransaction.TranID))
                        {
                            if (oChkProductStockTran.CheckStockSerial(_oProductTransaction.TranID))
                            {
                                DBController.Instance.RollbackTransaction();
                                MessageBox.Show(@"Duplicate Product Serial", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(@"Product serial & tran qty not matched", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion

                    if (_IsTrueBarcodeUpload == true)
                    {
                        _oProductTransaction.UpdateSupplierID(_nSupplierID, txtTransationRef.Text);

                        DBController.Instance.CommitTransaction();
                        if (!DBController.Instance.CheckConnection())
                        {
                            DBController.Instance.OpenNewConnection();
                        }
                        SCMShipments _SCMShipments = new SCMShipments();
                        _SCMShipments.GETGRDText(_oProductTransaction.TranID);
                        string sText = "";
                        foreach (SCMShipment oItem in _SCMShipments)
                        {
                            if (sText == "")
                            {
                                sText = oItem.Text;
                            }
                            else
                            {
                                sText = sText + "\r\n" + oItem.Text;
                            }

                        }
                        if (sText != "")
                        {
                            SCMShipments _SCMShipment = new SCMShipments();
                            _SCMShipments.GETSMSMobileNo(24);
                            foreach (SCMShipment oItem in _SCMShipment)
                            {
                                SMSMaker _oSMSMaker = new SMSMaker();
                                // bool IsSend = _oSMSMaker.IntegrateWithAPI(1, oItem.MobileNo, sText);
                            }
                        }

                        MessageBox.Show("Added Successfully : GRD# " + _oProductTransaction.TranNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error Upload Barcode...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            { 
            
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            DBController.Instance.OpenNewConnection();
            txtTransationRef.Text = "";
            cmbToChannel.SelectedIndex = _oChannels.Count - 1;
            cmbToWarehouse.Items.Clear();
            txtRemarks.Text = "";
            cmbShipmentNo.SelectedIndex = 0;
            txtShipmentDate.Text = "";
            txtInvoiceNo.Text = "";
            txtInvoiceDate.Text = "";
            txtCompany.Text = "";
            txtSupplyer.Text = "";
            txtLCNo.Text = "";
            txtLCDate.Text = "";
            txtPINo.Text = "";
            txtPIDate.Text = "";
            txtOrderNo.Text = "";
            txtOrderDate.Text = "";
            txtPSINo.Text = "";
            txtPSIDate.Text = "";


            dgvLineItem.Rows.Clear();

        }

        private void txtMessageText_TextChanged(object sender, EventArgs e)
        {

        }

        //public ProductTransaction GetUIData(ProductTransaction oProductTransaction)
        //{

        //    oProductTransaction.TranNo = txtTransationRef.Text;
        //    oProductTransaction.TranDate = DateTime.Today.Date;
        //    oProductTransaction.ToWHID = _oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID;
        //    oProductTransaction.ToChannelID = _oChannels[cmbToChannel.SelectedIndex].ChannelID;
        //    oProductTransaction.Remarks = txtRemarks.Text;
        //    oProductTransaction.UserID = Utility.UserId;
        //    oProductTransaction.Terminal = (int)Dictionary.Terminal.Head_Office;
        //    oProductTransaction.LCNo = txtLCNo.Text;
        //    oProductTransaction.LCDate = Convert.ToDateTime(txtLCDate.Text);
        //    oProductTransaction.LCInvoiceNo = txtInvoiceNo.Text;
        //    oProductTransaction.LCInvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
        //    oProductTransaction.ShipmentID = _oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID;

        //    // Item Details
        //    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
        //    {
        //        if (oItemRow.Index < dgvLineItem.Rows.Count)
        //        {

        //            ProductTransactionDetail oItem = new ProductTransactionDetail();

        //            oItem.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
        //            nQty = int.Parse(oItemRow.Cells[3].Value.ToString());
        //            oItem.Qty = nQty;
        //            nCP = Convert.ToDouble(oItemRow.Cells[9].Value.ToString());
        //            oItem.StockPrice = nQty * nCP;
        //            oItem.LCShortQty = int.Parse(oItemRow.Cells[4].Value.ToString());
        //            oItem.LCDamagedQty = int.Parse(oItemRow.Cells[5].Value.ToString());
        //            oItem.LCMinorDefectiveQty = int.Parse(oItemRow.Cells[6].Value.ToString());
        //            oItem.LCRemarks = (oItemRow.Cells[7].Value.ToString());
        //            if (oItem.Qty != 0)
        //                oProductTransaction.Add(oItem);

        //        }
        //    }

        //    return oProductTransaction;
        //}
    }
}