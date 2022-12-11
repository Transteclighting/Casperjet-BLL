using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmProductRequisition : Form
    {
        public bool _IsTrue = false;
        DMSSecondarySalesOrders _oDMSSecondarySalesOrders;
        POSRequisition _oPOSRequisition;
        //SystemInfo oSystemInfo;
        ProductStock _oProductStock;
        ProductDetail _oProductDetail;
        int nUIControl = 0;
        TELLib oTELLib;
        int nRequisitionID = 0;
        int nToWHID = 0;
        string sRequisitionNo = "";
        int nReqisitionType = 0;

        public frmProductRequisition(int _nUIControl)
        {
            InitializeComponent();
            nUIControl = _nUIControl;
        }
        private void frmProductRequisition_Load(object sender, EventArgs e)
        {
            if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create)
            {
                if (this.Tag == null)
                {
                    this.Text = "Add Stock Requisition";
                    dgvLineItem.DefaultCellStyle.ForeColor = Color.Black;
                    cmbDMSOrder.Visible = true;
                    lblcmbDMSOrder.Visible = true;
                    LoadCombo();
                }
                else
                {
                    this.Text = "Edit Stock Requisition";

                    cmbDMSOrder.Visible = false;
                    lblcmbDMSOrder.Visible = false;
                }
            }

            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (nUIControl == (int)Dictionary.StockRequisitionType.Requisition)
                {
                    nReqisitionType = 2;
                }
                else
                {
                    nReqisitionType = 1;
                }
                frmSearchProduct oForm = new frmSearchProduct(nReqisitionType);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    if (nReqisitionType != 2)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                        oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                        oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
                        _oProductStock = new ProductStock();
                        //_oProductStock.GetProductStockWithMTD_YTD(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID, Utility.WarehouseID);
                        _oProductStock.GetProductStockWithMTD_YTDRT(_oProductDetail.ProductID);

                        oRow.Cells[4].Value = _oProductStock.YTDSaleQty.ToString();
                        oRow.Cells[5].Value = _oProductStock.MTDSaleQty.ToString();
                        oRow.Cells[10].Value = oForm._oProductDetail.ProductID;


                        //_oProductStock = new ProductStock();
                        //_oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID);
                        oRow.Cells[6].Value = Convert.ToString(_oProductStock.HOCurrentStock);

                        //_oProductStock = new ProductStock();
                        //_oProductStock.GetProductStock(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID);
                        oRow.Cells[7].Value = _oProductStock.OutletCurrentStock.ToString();

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
                    else
                    {
                        ProductDetails oProductDetails = new ProductDetails();
                        oProductDetails = oForm._oProductDetails;
                        if (oProductDetails.Count > 0)
                        {
                            foreach (ProductDetail oProductDetail in oProductDetails)
                            {
                                DataGridViewRow oRow = new DataGridViewRow();
                                oRow.CreateCells(dgvLineItem);
                                oRow.Cells[0].Value = oProductDetail.ProductCode;
                                oRow.Cells[2].Value = oProductDetail.ProductName;
                                oRow.Cells[3].Value = oProductDetail.RSP.ToString();
                                _oProductStock = new ProductStock();
                                _oProductStock.GetProductStockWithMTD_YTDRT(oProductDetail.ProductID);

                                oRow.Cells[4].Value = _oProductStock.YTDSaleQty.ToString();
                                oRow.Cells[5].Value = _oProductStock.MTDSaleQty.ToString();
                                oRow.Cells[10].Value = oProductDetail.ProductID;
                                

                                //_oProductStock = new ProductStock();
                                //_oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID);
                                oRow.Cells[6].Value = Convert.ToString(_oProductStock.HOCurrentStock);

                                //_oProductStock = new ProductStock();
                                //_oProductStock.GetProductStock(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oProductDetail.ProductID);
                                oRow.Cells[7].Value = _oProductStock.OutletCurrentStock.ToString();

                                if (oProductDetail.ProductCode != null)
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
                    }
                }

            }
            //if (e.ColumnIndex == 11)
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    string sProductCode = "";
            //    string sProductName = "";
            //    int nStockQty = 0;
            //    try
            //    {
            //        int nProductID = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[10].Value.ToString());
            //        sProductCode = dgvLineItem.Rows[e.RowIndex].Cells[0].Value.ToString();
            //        sProductName = dgvLineItem.Rows[e.RowIndex].Cells[2].Value.ToString();

            //        if (Utility.CheckInternetConnection())
            //        {
            //            if (Utility.CheckTELWEBServer())
            //            {
            //                try
            //                {
            //                    CJ.POS.TELWEBSERVER.Service oSerivce = new CJ.POS.TELWEBSERVER.Service();
            //                    nStockQty = oSerivce.GetCentralRetailStock(nProductID);
            //                }
            //                catch (Exception ex)
            //                {
            //                    throw (ex);
            //                }
            //                MessageBox.Show("Product Code : " + sProductCode + " \nProduct Name : " + sProductName + "\nCurrent Stock : " + nStockQty + "", "Central Retail Warehouse Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //            {
            //                MessageBox.Show("HO Server down!!! \n\nPlease try again later or contact concern person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Please Check Internet Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Please Select a Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    this.Cursor = Cursors.Default;
            //}
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

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();
                    _oProductStock = new ProductStock();
                    //_oProductStock.GetProductStockWithMTD_YTD(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID, Utility.WarehouseID);
                    _oProductStock.GetProductStockWithMTD_YTDRT(_oProductDetail.ProductID);

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oProductStock.YTDSaleQty.ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oProductStock.MTDSaleQty.ToString();

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 10].Value = (_oProductDetail.ProductID).ToString();


                    //_oProductStock = new ProductStock();
                    //_oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = Convert.ToString(_oProductStock.HOCurrentStock);

                    //_oProductStock = new ProductStock();
                    //_oProductStock.GetProductStock(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = _oProductStock.OutletCurrentStock.ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (nColumnIndex == 8)
            {

                dgvLineItem.Rows[nRowIndex].Cells[9].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[8].Value.ToString());
                
                GetTotalAmount();
            }

            
        }
        public void GTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            txtTotalQty.Text = "0";
            oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[8].Value != null)
                {
                    txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[9].Value.ToString())).ToString();
                    txtTotalQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(oRow.Cells[8].Value.ToString())).ToString();
                }
            }

        }


        public void GetTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            txtTotalQty.Text = "0";
            oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[8].Value != null)
                {
                    txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[9].Value.ToString())).ToString();
                    txtTotalQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(oRow.Cells[8].Value.ToString())).ToString();
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
            if (this.Tag != null)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oPOSRequisition = new POSRequisition();
                        _oPOSRequisition = GetUIData(_oPOSRequisition);
                        _oPOSRequisition.Edit(nRequisitionID, nToWHID);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update Stock Requisition # " + sRequisitionNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _IsTrue = true;
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
                        _oPOSRequisition = new POSRequisition();
                        _oPOSRequisition = GetUIData(_oPOSRequisition);

                        _oPOSRequisition.InsertStockRequisitionRT(nUIControl);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Stock Requisition # " + _oPOSRequisition.RequisitionNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _IsTrue = true;
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
        public POSRequisition GetUIData(POSRequisition _oPOSRequisition)
        {

            _oPOSRequisition.FromWHID = Utility.WarehouseID;
            //_oPOSRequisition.ToWHID = Utility.CentralRetailWarehouse;
            Showroom oGetMappedWH = new Showroom();
            _oPOSRequisition.ToWHID = oGetMappedWH.GetMappedWH(Utility.WarehouseID);

            _oPOSRequisition.Remarks = txtRemarks.Text;
            _oPOSRequisition.Terminal = (int)Dictionary.Terminal.Branch_Office;


            // Product Details
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {

                    POSRequisitionItem _oPOSRequisitionItem = new POSRequisitionItem();

                    _oPOSRequisitionItem.ProductID = int.Parse(oItemRow.Cells[10].Value.ToString());
                    _oPOSRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                    _oPOSRequisitionItem.AuthorizeQty = 0;

                    _oPOSRequisition.Add(_oPOSRequisitionItem);

                }
            }

            return _oPOSRequisition;
        }
        private bool validateUIInput()
        {
            #region Order Details Information Validation
            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("There is no Data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[10].Value.ToString());
                        if (int.Parse(oItemRow.Cells[10].Value.ToString()) < 1)
                        {
                            MessageBox.Show("Requisition quantity must be grather than 0", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Select a Product", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[8].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please enter requisition quantity", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }
        public void ShowDialog(POSRequisition oPOSRequisition)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            dgvLineItem.DefaultCellStyle.ForeColor = Color.Black;
            nRequisitionID = 0;
            nToWHID = 0;
            nRequisitionID = oPOSRequisition.RequisitionID;
            nToWHID = oPOSRequisition.ToWHID;
            sRequisitionNo = oPOSRequisition.RequisitionNo;
            oPOSRequisition.GetRequisitionItem(oPOSRequisition.RequisitionID);

            txtRemarks.Text = oPOSRequisition.Remarks;

            foreach (POSRequisitionItem oPOSRequisitionItem in oPOSRequisition)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oPOSRequisitionItem.ProductCode.ToString();
                oRow.Cells[2].Value = oPOSRequisitionItem.ProductName.ToString();



                _oProductStock = new ProductStock();
                //_oProductStock.GetProductStockWithMTD_YTD(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oPOSRequisitionItem.ProductID, Utility.WarehouseID);
                _oProductStock.GetProductStockWithMTD_YTDRT(oPOSRequisitionItem.ProductID);
                oRow.Cells[3].Value = oPOSRequisitionItem.RSP.ToString();
                oRow.Cells[4].Value = _oProductStock.YTDSaleQty.ToString();
                oRow.Cells[5].Value = _oProductStock.MTDSaleQty.ToString();

                //_oProductStock = new ProductStock();
                //_oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, oPOSRequisitionItem.ProductID);
                oRow.Cells[6].Value = Convert.ToString(_oProductStock.HOCurrentStock);

                //_oProductStock = new ProductStock();
                //_oProductStock.GetProductStock(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oPOSRequisitionItem.ProductID);
                oRow.Cells[7].Value = _oProductStock.OutletCurrentStock.ToString();

                oRow.Cells[8].Value = oPOSRequisitionItem.RequisitionQty.ToString();
                oRow.Cells[9].Value = (oPOSRequisitionItem.RequisitionQty * oPOSRequisitionItem.RSP).ToString();
                oRow.Cells[10].Value = oPOSRequisitionItem.ProductID.ToString();

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

        //private void btnUpdateHOStock_Click(object sender, EventArgs e)
        //{
        //    frmGetHOStock oForm = new frmGetHOStock();
        //    oForm.ShowDialog();

        //    oSystemInfo = new SystemInfo();
        //    DBController.Instance.OpenNewConnection();
        //    oSystemInfo.Refresh();
        //    if (oSystemInfo.HOStockUpdateDate != null)
        //        lblLastUpdateDate.Text = Convert.ToDateTime(oSystemInfo.HOStockUpdateDate).ToString("dd-MMM-yyyy hh:mm tt");
        //    else lblLastUpdateDate.Text = "N/A";
        //    lblLastUpdateDate.Refresh();
        //    foreach (DataGridViewRow oRow in dgvLineItem.Rows)
        //    {
        //        int nCount = 0;
        //        if (oRow.Index < dgvLineItem.Rows.Count - 1)
        //        {

        //            int nProductID = int.Parse(oRow.Cells[10].Value.ToString());

        //            _oProductStock = new ProductStock();
        //            _oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, nProductID);
        //            oRow.Cells[6].Value = Convert.ToString(_oProductStock.CurrentStock - _oProductStock.BookingStock);
        //            nCount++;
        //        }
        //        if (nCount > 0)
        //        {
        //            dgvLineItem.Refresh();
        //        }
        //    }
        //    DBController.Instance.CloseConnection();

        //}

        private void LoadCombo()
        {
            _oDMSSecondarySalesOrders = new DMSSecondarySalesOrders();
            _oDMSSecondarySalesOrders.GetConfirmOrderListRT("", "", (int)Dictionary.SalesType.Dealer);

            cmbDMSOrder.Items.Clear();
            cmbDMSOrder.Items.Add("<All>");
            foreach (DMSSecondarySalesOrder _oDMSSecondarySalesOrder in _oDMSSecondarySalesOrders)
            {
                cmbDMSOrder.Items.Add(_oDMSSecondarySalesOrder.OrderNo + "[" + _oDMSSecondarySalesOrder.CustomerName + "]");
            }
            cmbDMSOrder.SelectedIndex = 0;

        }

        public void LoadOrderData(string sOrderNo)
        {
            DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oDMSSecondarySalesOrder.GetConfirmedQty(sOrderNo);
            dgvLineItem.Rows.Clear();
            foreach (DMSSecondarySalesOrderDetail oItem in oDMSSecondarySalesOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oItem.ProductCode;
                oRow.Cells[2].Value = oItem.ProductName;
                oRow.Cells[3].Value = oItem.RSP.ToString();
                _oProductStock = new ProductStock();
                //_oProductStock.GetProductStockWithMTD_YTD(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oItem.ProductID, Utility.WarehouseID);
                _oProductStock.GetProductStockWithMTD_YTDRT(oItem.ProductID);
                oRow.Cells[4].Value = _oProductStock.YTDSaleQty.ToString();
                oRow.Cells[5].Value = _oProductStock.MTDSaleQty.ToString();
                oRow.Cells[10].Value = oItem.ProductID;

                //_oProductStock = new ProductStock();
                //_oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, oItem.ProductID);
                oRow.Cells[6].Value = Convert.ToString(_oProductStock.HOCurrentStock);

               // _oProductStock = new ProductStock();
                //_oProductStock.GetProductStock(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oItem.ProductID);
                oRow.Cells[7].Value = _oProductStock.OutletCurrentStock.ToString();
                oRow.Cells[8].Value = oItem.ConfirmedQty.ToString();
                oRow.Cells[9].Value = Convert.ToDouble(oItem.ConfirmedQty * oItem.RSP);
                dgvLineItem.Rows.Add(oRow);

                
            }

            GetTotalAmount();

        }
        private void cmbDMSOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDMSOrder.SelectedIndex > 0)
            {
                LoadOrderData(_oDMSSecondarySalesOrders[cmbDMSOrder.SelectedIndex - 1].OrderNo);
                txtRemarks.Text = "";
                txtRemarks.Text = "Requisition for " + _oDMSSecondarySalesOrders[cmbDMSOrder.SelectedIndex - 1].CustomerName + ". Order#" + _oDMSSecondarySalesOrders[cmbDMSOrder.SelectedIndex - 1].OrderNo + "";
            }
            else
            {
                dgvLineItem.Rows.Clear();
                txtRemarks.Text = "";
            }
        }
    }
}