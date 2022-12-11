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

namespace CJ.Win.POS
{
    public partial class frmStockRequisitionAuthorizationRT : Form
    {
        int nRequisitionID = 0;
        int nRequisitionType = 0;
        int nToWHID = 0;
        int nFromWHID = 0;
        string sRequisitionNo = "";
        int nRequisitionStatus = 0;
        ProductStock _oProductStock;
        TELLib oTELLib;
        ProductDetail _oProductDetail;
        POSRequisition _oPOSRequisition;
        DataTran _oDataTran;
        int _UIControl = 0;
        int nCount = 0;
        int nLineItemItdex = 0;
        int nStockTranID;

        public frmStockRequisitionAuthorizationRT(int nUIControl)
        {
            InitializeComponent();
            _UIControl = nUIControl;
            nCount = 0;
            if (_UIControl != (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive && _UIControl != (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Authorization)
            {
                dgvLineItem.Columns[9].ReadOnly = true;
                dgvLineItem.Columns[0].ReadOnly = true;
                dgvLineItem.Columns[0].DefaultCellStyle.BackColor = Color.Silver;
                btnFindProduct.Visible = false;
                dgvLineItem.Columns[13].ReadOnly = true;
                dgvLineItem.Columns[13].DefaultCellStyle.BackColor = Color.Silver;
                dgvLineItem.AllowUserToAddRows = false;
                dgvLineItem.AllowUserToDeleteRows = false;
                nCount = 0;

            }
            else
            {
                nCount = 1;
            }

        }
        private void btnRejected_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to Reject the  Requisition # " + sRequisitionNo + " ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                _oPOSRequisition = new POSRequisition();
                _oPOSRequisition.RequisitionID = nRequisitionID;
                _oPOSRequisition.Status = (int)Dictionary.StockRequisitionStatus.Reject_By_HO;
                _oPOSRequisition.AuthorizedBy = Utility.UserId;
                _oPOSRequisition.AuthorizeDate = DateTime.Now;
                _oPOSRequisition.AuthorizeRemarks = txtRemarks.Text;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oPOSRequisition.AuthorizeUpdate();
                    _oPOSRequisition.UpdateStatus();
                    _oPOSRequisition.GetTerminal(_oPOSRequisition.RequisitionID);

                    _oPOSRequisition.Refresh();

                    ProductTransferProductSerials oPTPSs = new ProductTransferProductSerials();
                    oPTPSs.GetProductTransferProductSerial(_oPOSRequisition.StockTranID);

                    foreach (ProductTransferProductSerial oPTPS in oPTPSs)
                    {
                        ProductBarcode oProductBarcode = new ProductBarcode();
                        oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                        oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                        ////Update Vat Paid Data
                        if (nRequisitionType == (int)Dictionary.StockRequisitionType.ISGM || nRequisitionType == (int)Dictionary.StockRequisitionType.Return_To_HO)
                        {
                            oProductBarcode.UpdateVatPaidProductSerial(nFromWHID, oPTPS.TradePrice, oPTPS.VAT, (int)Dictionary.ProductStockTranType.TRANSFER, _oPOSRequisition.RequisitionNo, Convert.ToDateTime(DateTime.Now.Date));
                        }

                        oProductBarcode.UpdateProductSerial();

                        oProductBarcode.GetProductSerialID(oPTPS.ProductSerialNo);
                        oProductBarcode.GetProductSerialHitoryID(oProductBarcode.ProductStockSerialID);
                        oProductBarcode.DeleteProductSerialHistoryByID(oProductBarcode.ProductStockSerialHistoryID);

                    }

                    StockTran oStockTran = new StockTran();
                    oStockTran.DeleteTran(_oPOSRequisition.StockTranID);

                    _oPOSRequisition.StockTranID = -1;
                    _oPOSRequisition.UpdateStockTranID_POS();              

                    if (_oPOSRequisition.Terminal != (int)Dictionary.Terminal.Head_Office)
                    {
                        _oDataTran = new DataTran();
                        _oDataTran.TableName = "t_StockRequisition";
                        _oDataTran.DataID = _oPOSRequisition.RequisitionID;
                        _oDataTran.WarehouseID = nFromWHID;
                        _oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        _oDataTran.BatchNo = 0;
                        if (_oDataTran.CheckDataByWHID() == false)
                        {
                            _oDataTran.AddForTDPOS();
                        }
                    }
                    

                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Successfully Rejected the Requisition # " + sRequisitionNo, "Reject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void btnAuthorized_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (validateUIInput())
            {
                _oPOSRequisition = new POSRequisition();
                _oPOSRequisition.RequisitionID = nRequisitionID;
                _oPOSRequisition.Status = (int)Dictionary.StockRequisitionStatus.Approve_By_HO;
                _oPOSRequisition.AuthorizedBy = Utility.UserId;
                _oPOSRequisition.AuthorizeDate = DateTime.Now;
                _oPOSRequisition.AuthorizeRemarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    _oPOSRequisition.AuthorizeUpdateRT();

                    ProductTransaction oProductTransaction = new ProductTransaction();
                    //Update Product stock tran Status (complete instead of pending)
                    oProductTransaction.TranID = nStockTranID;
                    oProductTransaction.Status = (int)Dictionary.StockTransactionStatus.COMPLETE;
                    oProductTransaction.UpdateStockTranStatus();


                    POSRequisitionItem _oPOSRequisitionItem = new POSRequisitionItem();
                    _oPOSRequisitionItem.RequisitionID = nRequisitionID;
                    _oPOSRequisitionItem.Delete();

                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - nLineItemItdex)
                        {
                            _oPOSRequisitionItem = new POSRequisitionItem();
                            _oPOSRequisitionItem.ProductID = int.Parse(oItemRow.Cells[15].Value.ToString());
                            try
                            {
                                _oPOSRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[12].Value.ToString());
                            }
                            catch
                            {
                                _oPOSRequisitionItem.RequisitionQty = 0;
                            }
                            try
                            {
                                _oPOSRequisitionItem.AuthorizeQty = int.Parse(oItemRow.Cells[13].Value.ToString());
                            }
                            catch
                            {
                                _oPOSRequisitionItem.AuthorizeQty =0;
                            }
                            try
                            {
                                _oPOSRequisitionItem.PreviousAuthorizeQty = int.Parse(oItemRow.Cells[16].Value.ToString());
                            }
                            catch
                            {
                                _oPOSRequisitionItem.PreviousAuthorizeQty = 0;
                            }
                            _oPOSRequisitionItem.Add(_oPOSRequisition.RequisitionID);

                            //Set Booking/Update stock
                            if (nRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
                            {
                                _oProductStock = new ProductStock();
                                _oProductStock.UpdateBookingStock(false, _oPOSRequisitionItem.PreviousAuthorizeQty, nToWHID, _oPOSRequisitionItem.ProductID);


                                _oProductStock = new ProductStock();
                                 _oProductStock.UpdateBookingStock(true, _oPOSRequisitionItem.AuthorizeQty, nToWHID, _oPOSRequisitionItem.ProductID);
                            }
                            else if (nRequisitionType == (int)Dictionary.StockRequisitionType.ISGM)
                            {

                                //_oProductStock = new ProductStock();
                                //_oProductStock.Quantity = _oPOSRequisitionItem.AuthorizeQty;
                                //_oProductStock.ProductID = _oPOSRequisitionItem.ProductID;
                                //_oProductStock.WarehouseID = nFromWHID;
                                //_oProductStock.UpdateCurrentStock_POS(true);
                                //_oProductStock.UpdateBookingStock_POS(false);
                                //_oProductStock.UpdateTransitStock_POS(false);


                                //_oProductStock.WarehouseID = nToWHID;
                                //_oProductStock.UpdateCurrentStock_POS(true);
                                //_oProductStock.UpdateBookingStock_POS(false);
                                //_oProductStock.UpdateTransitStock_POS(false);



                                //_oProductStock = new ProductStock();
                                //_oProductStock.UpdateBookingStock(true, _oPOSRequisitionItem.AuthorizeQty, nToWHID, _oPOSRequisitionItem.ProductID);
                            }
                            else
                            {
                                //_oProductStock = new ProductStock();
                                //_oProductStock.Refresh(_oPOSRequisitionItem.ProductID, Utility.TDRetailChannelID, nToWHID);
                                //if (_oProductStock.Flag == true)
                                //{
                                //    _oProductStock.Quantity = _oPOSRequisitionItem.AuthorizeQty;
                                //    _oProductStock.ProductID = _oPOSRequisitionItem.ProductID;
                                //    _oProductStock.ChannelID = Utility.TDRetailChannelID;

                                //    Warehouse oChkCentralWH = new Warehouse();
                                //    //if (oChkCentralWH.ChkChkCentralWarehouse(nToWHID))
                                //    if (nToWHID != Utility.CentralRetailWarehouse)
                                //    {
                                //        _oProductStock.WarehouseID = nFromWHID;
                                //        _oProductStock.UpdateCurrentStock_GRD(false);

                                //        _oProductStock.WarehouseID = nToWHID;
                                //        _oProductStock.UpdateCurrentStock_GRD(true);

                                //        if (_oProductStock.Flag == false)
                                //        {
                                //            _oProductStock.Insert();
                                //            _oProductStock.UpdateCurrentStock_GRD(true);
                                //        }

                                //    }
                                //    else
                                //    {
                                //        _oProductStock.WarehouseID = nFromWHID;
                                //        _oProductStock.BookingStock = _oPOSRequisitionItem.AuthorizeQty;
                                //        _oProductStock.UpdateBookingStock_POS(true);
                                //    }
                                //}
                                //else
                                //{
                                //    _oProductStock.Quantity = _oPOSRequisitionItem.AuthorizeQty;
                                //    _oProductStock.ProductID = _oPOSRequisitionItem.ProductID;

                                //    _oProductStock.ChannelID = Utility.TDRetailChannelID;
                                //    _oProductStock.WarehouseID = nToWHID;
                                //    _oProductStock.Insert();
                                //    Warehouse oChkCentralWH = new Warehouse();
                                //    //if (oChkCentralWH.ChkChkCentralWarehouse(nToWHID))
                                //    if (nToWHID != Utility.CentralRetailWarehouse)
                                //    {
                                //        _oProductStock.WarehouseID = nFromWHID;
                                //        _oProductStock.UpdateCurrentStock_GRD(false);

                                //        _oProductStock.WarehouseID = nToWHID;
                                //        _oProductStock.UpdateCurrentStock_GRD(true);

                                //        if (_oProductStock.Flag == false)
                                //        {
                                //            _oProductStock.Insert();
                                //            _oProductStock.UpdateCurrentStock_GRD(true);
                                //        }

                                //    }
                                //    else
                                //    {
                                //        _oProductStock.WarehouseID = nFromWHID;
                                //        _oProductStock.BookingStock = _oPOSRequisitionItem.AuthorizeQty;
                                //        _oProductStock.UpdateBookingStock_POS(true);
                                //    }
                                //}

                            }

                        }
                    }


                    ////Update Vat Paid Data
                    ProductBarcode _oMAXID = new ProductBarcode();
                    int nID = _oMAXID.GetMaxID();

                    if (nRequisitionType == (int)Dictionary.StockRequisitionType.ISGM || nRequisitionType == (int)Dictionary.StockRequisitionType.Return_To_HO)
                    {
                        ProductTransferProductSerials oVatPaidSerial = new ProductTransferProductSerials();
                        oVatPaidSerial.GetProductTransferProductSerial(nStockTranID);
                        foreach (ProductTransferProductSerial oVatPaid in oVatPaidSerial)
                        {
                            if (oVatPaid.IsVATPaidProduct == 1)
                            {
                                //ProductBarcode oProductBarcode = new ProductBarcode();
                                //Update VAT Paid Data
                                //oProductBarcode.UpdateVatPaidProductSerial(oSystemInfo.WarehouseID, oVatPaid.TradePrice, oVatPaid.VAT, (int)Dictionary.ProductStockTranType.TRANSFER, _oPOSRequisition.RequisitionNo, Convert.ToDateTime(oProductTransaction.TranDate));
                                ProductBarcode _oProductBarcode = new ProductBarcode();
                                _oProductBarcode.VatPaidID = nID;
                                _oProductBarcode.ProductId = oVatPaid.ProductID;
                                _oProductBarcode.WarehouseID = nToWHID;
                                _oProductBarcode.ProductSerialNo = oVatPaid.ProductSerialNo;
                                _oProductBarcode.TranNo = sRequisitionNo;
                                _oProductBarcode.TranDate = Convert.ToDateTime(DateTime.Now.Date);
                                _oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                                _oProductBarcode.InsertVatPaidProductSerial();

                            }

                        }

                    }

                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Successfully Approved the Requisition # " + sRequisitionNo, "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool validateUIInput()
        {
            
            int nQtyCount = 0;
            int nCount = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - nLineItemItdex)
                {
                    int nAuthorizedQty = 0;
                   

                    if (oItemRow.Cells[12].Value == null || oItemRow.Cells[12].Value == "")
                    {
                        nAuthorizedQty = 0;
                    }
                    else
                    {
                        nAuthorizedQty = int.Parse(oItemRow.Cells[13].Value.ToString());
                    }
                    nQtyCount = nQtyCount + nAuthorizedQty;

                    if (nRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
                    {
                        if (nAuthorizedQty > int.Parse(oItemRow.Cells[8].Value.ToString()))
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                            nCount++;
                        }
                        else
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }

                }
            }
            if (nCount > 0)
            {
                MessageBox.Show("Authorized Qty must be less of equal sound Stock Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nQtyCount == 0)
            {
                MessageBox.Show("You have to inputed at least 1 (one) Authorized Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(POSRequisition oPOSRequisition)

        {
            nStockTranID = oPOSRequisition.StockTranID;
            nRequisitionID = 0;
            nToWHID = 0;
            nFromWHID = 0;
            nRequisitionType = 0;
            sRequisitionNo = "";
            nRequisitionID = oPOSRequisition.RequisitionID;
            nToWHID = oPOSRequisition.ToWHID;
            nRequisitionStatus = oPOSRequisition.Status;
            sRequisitionNo = oPOSRequisition.RequisitionNo;
            //dgvLineItem.Columns[8].HeaderText = oPOSRequisition.ToWHName + " Stock";
            dgvLineItem.Columns[11].HeaderText = oPOSRequisition.FromWHName + " Stock";

            oPOSRequisition.GetRequisitionItem(oPOSRequisition.RequisitionID);
            //oPOSRequisition.RefreshByStockRequisitionID(oPOSRequisition.RequisitionID);
            nFromWHID = oPOSRequisition.FromWHID;
            lblFromWHID.Text = oPOSRequisition.FromWHName + "[" + oPOSRequisition.FromWHCode + "]";
            lblToWHID.Text = oPOSRequisition.ToWHName + "[" + oPOSRequisition.ToWHCode + "]";
            lblStatus.Text = oPOSRequisition.StatusName;
            nRequisitionType = oPOSRequisition.RequisitionType;
            txtRemarks.Text = oPOSRequisition.AuthorizeRemarks; 
            if (oPOSRequisition.RequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
            {
                nLineItemItdex = 1;
                this.Text = "Stock Requisition Authorization";
                dgvLineItem.Columns[12].HeaderText = "Requi Qty";
            }
            else
            {
                nLineItemItdex = 0;
                this.Text = "ISGM Authorization";
                dgvLineItem.Columns[12].HeaderText = "ISGM Qty";
            }
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Approve_By_HO)
            {
                btnRejected.Enabled = false;
            }
            foreach (POSRequisitionItem oPOSRequisitionItem in oPOSRequisition)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oPOSRequisitionItem.ProductCode.ToString();
                oRow.Cells[2].Value = oPOSRequisitionItem.ProductName.ToString();

                _oProductStock = new ProductStock();
                //_oProductStock.GetProductStockWithMTD_YTD(oPOSRequisition.ToWHID, (int)Dictionary.WareHouseStockType.SOUND, oPOSRequisitionItem.ProductID, oPOSRequisition.FromWHID);
                _oProductStock.GetProductStockWithMTD_YTDNewDepot(oPOSRequisition.ToWHID, oPOSRequisitionItem.ProductID, oPOSRequisition.FromWHID);

                oRow.Cells[3].Value = _oProductStock.YTDSaleQty.ToString();
                oRow.Cells[4].Value = _oProductStock.MTDSaleQty.ToString();
                oRow.Cells[5].Value = oPOSRequisitionItem.RSP.ToString();
                //oRow.Cells[6].Value = _oProductStock.GetTDStock(oPOSRequisitionItem.ProductID).ToString();
                oRow.Cells[6].Value = _oProductStock.ALLShowroomStock;
                oRow.Cells[7].Value = _oProductStock.AllDepotStock;

                if (_oProductStock.BookingStock > _oProductStock.CurrentStock)
                {
                    oRow.Cells[8].Value = 0;
                }
                else
                {
                    int nCurrentStock = Convert.ToInt32(_oProductStock.CurrentStock + oPOSRequisitionItem.AuthorizeQty);
                    oRow.Cells[8].Value = (nCurrentStock - _oProductStock.BookingStock);
                }
                oRow.Cells[9].Value = 0;//Buffer Stock 
                oRow.Cells[10].Value = (0 - _oProductStock.OutletCurrentStock);//Gap Stock =Buffer-concern outlet stock
                oRow.Cells[11].Value = _oProductStock.OutletCurrentStock;
                oRow.Cells[12].Value = oPOSRequisitionItem.RequisitionQty.ToString();
                if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Approve_By_HO)
                {
                    oRow.Cells[13].Value = oPOSRequisitionItem.AuthorizeQty.ToString();
                }
                else
                {
                    oRow.Cells[13].Value = oPOSRequisitionItem.RequisitionQty.ToString();
                }
                oRow.Cells[14].Value = (oPOSRequisitionItem.RequisitionQty * oPOSRequisitionItem.RSP).ToString();
                oRow.Cells[15].Value = oPOSRequisitionItem.ProductID.ToString();
                oRow.Cells[16].Value = oPOSRequisitionItem.AuthorizeQty.ToString();
                dgvLineItem.Rows.Add(oRow);

            }
            GetTotalAmount();
            this.Tag = oPOSRequisition;

            this.ShowDialog();
        }
        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }
        public void GetTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            txtAuthQty.Text = "0";
            txtReqQty.Text = "0";
            oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[15].Value != null)
                {
                    txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[14].Value.ToString())).ToString();
                    txtAuthQty.Text = Convert.ToDouble(Convert.ToDouble(txtAuthQty.Text) + Convert.ToDouble(oRow.Cells[13].Value.ToString())).ToString();
                    txtReqQty.Text = Convert.ToDouble(Convert.ToDouble(txtReqQty.Text) + Convert.ToDouble(oRow.Cells[12].Value.ToString())).ToString();
                }
            }

        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                //if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
                //{
                //    MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;

                    _oProductStock = new ProductStock();
                    //_oProductStock.GetProductStockWithMTD_YTD(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID, nFromWHID);
                    //_oProductStock.GetProductStockWithMTD_YTDNew(Utility.CentralRetailWarehouse, oForm._oProductDetail.ProductID, nFromWHID);
                    _oProductStock.GetProductStockWithMTD_YTDNewDepot(nToWHID, oForm._oProductDetail.ProductID, nFromWHID);//_oProductStock.GetProductStockWithMTD_YTDNew(nToWHID, oForm._oProductDetail.ProductID, nFromWHID);


                    oRow.Cells[3].Value = _oProductStock.YTDSaleQty.ToString();
                    oRow.Cells[4].Value = _oProductStock.MTDSaleQty.ToString();
                    oRow.Cells[5].Value = oForm._oProductDetail.RSP.ToString();
                    //oRow.Cells[6].Value = _oProductStock.GetTDStock(oForm._oProductDetail.ProductID).ToString();
                    oRow.Cells[6].Value = _oProductStock.ALLShowroomStock;
                    oRow.Cells[7].Value = _oProductStock.AllDepotStock;

                    if (_oProductStock.BookingStock > _oProductStock.CurrentStock)
                    {
                        oRow.Cells[8].Value = 0;
                    }
                    else
                    {
                        oRow.Cells[8].Value = (_oProductStock.CurrentStock - _oProductStock.BookingStock);
                    }

                    oRow.Cells[9].Value = 0;//Buffer Stock 
                    oRow.Cells[10].Value = (0 - _oProductStock.OutletCurrentStock);//Gap Stock =Buffer-concern outlet stock
                    oRow.Cells[11].Value = _oProductStock.OutletCurrentStock;
                    oRow.Cells[12].Value = 0;
                    oRow.Cells[13].Value = 0;
                    oRow.Cells[14].Value = 0;
                    oRow.Cells[15].Value = oForm._oProductDetail.ProductID;
                    oRow.Cells[16].Value = 0;
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
                    }
                }

            }

            if(e.ColumnIndex==7)
            {
                frmAllDepotStock oForm = new frmAllDepotStock(Convert.ToInt32(dgvLineItem.Rows[e.RowIndex].Cells[15].Value), dgvLineItem.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvLineItem.Rows[e.RowIndex].Cells[2].Value.ToString());
                oForm.ShowDialog();
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
                //if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
                //{
                //    MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

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
                    DBController.Instance.OpenNewConnection();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;

                    _oProductStock = new ProductStock();
                    //_oProductStock.GetProductStockWithMTD_YTD(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID, nFromWHID);
                    //_oProductStock.GetProductStockWithMTD_YTDNew(Utility.CentralRetailWarehouse, _oProductDetail.ProductID, nFromWHID);
                    _oProductStock.GetProductStockWithMTD_YTDNewDepot(nToWHID, _oProductDetail.ProductID, nFromWHID);

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductStock.YTDSaleQty.ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oProductStock.MTDSaleQty.ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oProductDetail.RSP.ToString();
                    //dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = _oProductStock.GetTDStock(_oProductDetail.ProductID).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = _oProductStock.ALLShowroomStock.ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = _oProductStock.AllDepotStock.ToString();//AllDepotStock

                    if (_oProductStock.BookingStock > _oProductStock.CurrentStock)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;
                    }
                    else
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (_oProductStock.CurrentStock - _oProductStock.BookingStock);
                    }
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = 0;//Buffer Stock
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 10].Value = 0 - _oProductStock.OutletCurrentStock;//Gap Stock
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 11].Value = _oProductStock.OutletCurrentStock;
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 12].Value = 0;
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 13].Value = 0;
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 14].Value = 0;
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 15].Value = (_oProductDetail.ProductID).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 16].Value = 0;
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (nColumnIndex == 13)
            {

                dgvLineItem.Rows[nRowIndex].Cells[14].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[5].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[13].Value.ToString());

                GetTotalAmount();
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
        private void dgvLineItem_RowsRemoved_1(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }

        private void frmStockRequisitionAuthorizationRT_Load(object sender, EventArgs e)
        {

        }
    }
}