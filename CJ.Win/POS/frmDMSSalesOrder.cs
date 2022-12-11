using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Class.Library;
using CJ.Win.Control;

namespace CJ.Win.POS
{
    public partial class frmDMSSalesOrder : Form
    {
        ProductStock _oProductStock;
        SystemInfo oSystemInfo;
        ProductDetail _oProductDetail;
        TELLib oTELLib;
        Customer _oCustomer;
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        string sCustumerTypeID = "";
        DMSSecondarySalesOrder _oDMSSecondarySalesOrder;
        DMSSecondarySalesOrderDetail _oDMSSecondarySalesOrderDetail;
        Showroom _oShowRoom;
        int nDMSOrderID = 0;
        int nWarehouseID = 0;


        int _nSalesType = 0;
        public frmDMSSalesOrder()
        {
            InitializeComponent();
        }

        public void ShowDialog(DMSSecondarySalesOrder oDMSSecondarySalesOrder)
        {
            this.Tag = oDMSSecondarySalesOrder;
            // lblSalesType.Text =  oDMSSecondarySalesOrder.SalesType;
            if (oDMSSecondarySalesOrder.SalesType == (int)Dictionary.SalesType.Dealer)
            {
                lblSalesType.Text = "Dealer";
            }
            else if (oDMSSecondarySalesOrder.SalesType == (int)Dictionary.SalesType.B2B)
            {
                lblSalesType.Text = "B2B";
            }
            nDMSOrderID = oDMSSecondarySalesOrder.OrderID;
            nWarehouseID = oDMSSecondarySalesOrder.WarehouseID;
            lblEDD.Text = oDMSSecondarySalesOrder.EDD.ToString("dd-MMM-yyyy");
            lblCustomerName.Text = oDMSSecondarySalesOrder.CustomerName;
            lblOrderNumber.Text = oDMSSecondarySalesOrder.OrderNo;
            lblRemarks.Text = oDMSSecondarySalesOrder.Remarks;

            _oCustomer = new Customer();
            _oCustomer.GetCustomerDetailByID(oDMSSecondarySalesOrder.CustomerID);

            lblArea.Text = _oCustomer.AreaName;
            lblTerritory.Text = _oCustomer.TerritoryName;
            lblThana.Text = _oCustomer.ThanaName;
            lblDistrict.Text = _oCustomer.DistrictName;
            lblWarehouse.Text = _oCustomer.ParentCustomerName;

            
            _oProductDetail = new ProductDetail();
            int i = 0;
            _oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
            _oDMSSecondarySalesOrder.GetOrderItem(oDMSSecondarySalesOrder.OrderID, oDMSSecondarySalesOrder.WarehouseID);
            foreach (DMSSecondarySalesOrderDetail oOrderItem in _oDMSSecondarySalesOrder)
            {
                _oProductDetail.ProductID = oOrderItem.ProductID;
                _oProductDetail.Refresh();

                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);

                //oRow.Cells[0].Value = i + 1;
                oRow.Cells[0].Value = _oProductDetail.ProductCode;
                oRow.Cells[2].Value = _oProductDetail.ProductName;
                oRow.Cells[3].Value = oOrderItem.UnitPrice;

                _oProductStock = new ProductStock();
                _oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
                //dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value 
                 oRow.Cells[4].Value   = Convert.ToString(_oProductStock.CurrentStock - _oProductStock.BookingStock);

                _oProductStock = new ProductStock();
                _oProductStock.GetProductStock(oDMSSecondarySalesOrder.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
                oRow.Cells[5].Value = _oProductStock.CurrentStock.ToString();



                oRow.Cells[6].Value = oOrderItem.OrderQty;
                oRow.Cells[7].Value = oOrderItem.UnitPrice * oOrderItem.OrderQty;

                dgvLineItem.Rows.Add(oRow);
                
            }

            GetTotalAmount();

            this.ShowDialog();

        }
        public bool ValidateUIInput()
        {
             
            #region Invoice Basic Validation
            //if (cmbSalesType.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Sales Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbSalesType.Focus();
            //    return false;
            //}
            #endregion

            #region Invoice Item validation
            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[8].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[8].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[8].Value.ToString().Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    if (oItemRow.Cells[6].Value != null)
                    {
                        try
                        {
                            long temp = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Please Input Valid Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }

            #endregion


            return true;
        }

        //private void refreshRow(int nRowIndex, int nColumnIndex)
        //{
        //    string sProductCode = "";
        //    if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
        //    {
        //        if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
        //        {
        //            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            dgvLineItem.Rows.RemoveAt(nRowIndex);
        //            return;
        //        }
        //        try
        //        {
        //            sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

        //            _oProductDetail = new ProductDetail();
        //            DBController.Instance.OpenNewConnection();
        //            _oProductDetail.ProductCode = sProductCode;
        //            _oProductDetail.RefreshByCode();

        //            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
        //            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();
        //            oSystemInfo = new SystemInfo();
        //            oSystemInfo.Refresh();

        //            _oProductStock = new ProductStock();
        //            _oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
        //            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = Convert.ToString(_oProductStock.CurrentStock - _oProductStock.BookingStock);

        //            _oProductStock = new ProductStock();
        //            _oProductStock.GetProductStock(oSystemInfo.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
        //            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oProductStock.CurrentStock.ToString();
        //            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (_oProductDetail.ProductID).ToString();
        //            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }
        //    else if (nColumnIndex == 6)
        //    {
        //        try
        //        {
        //            int temp = Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[6].Value);
        //        }
        //        catch
        //        {

        //            MessageBox.Show("Please input valid order qty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        dgvLineItem.Rows[nRowIndex].Cells[7].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[6].Value.ToString());
        //        GetTotalAmount();
        //    }


        //}
        public void GetTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            txtTotalQty.Text = "0";
            oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[6].Value != null)
                {
                    txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[7].Value.ToString())).ToString();
                    txtTotalQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString())).ToString();
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

        //private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int nRowIndex = 0;
        //    if (e.ColumnIndex == 1)
        //    {
        //        frmSearchProduct oForm = new frmSearchProduct(1);
        //        oForm.ShowDialog();
        //        if (oForm._oProductDetail != null)
        //        {
        //            DataGridViewRow oRow = new DataGridViewRow();
        //            oRow.CreateCells(dgvLineItem);
        //            oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
        //            oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
        //            oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
        //            oSystemInfo = new SystemInfo();
        //            oSystemInfo.Refresh();
        //            _oProductStock = new ProductStock();
        //            _oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID);
        //            oRow.Cells[4].Value = Convert.ToString(_oProductStock.CurrentStock - _oProductStock.BookingStock);
        //            _oProductStock = new ProductStock();
        //            _oProductStock.GetProductStock(oSystemInfo.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID);
        //            oRow.Cells[5].Value = _oProductStock.CurrentStock.ToString();
        //            oRow.Cells[8].Value = oForm._oProductDetail.ProductID;

        //            if (oForm._oProductDetail.ProductCode != null)
        //            {
        //                nRowIndex = dgvLineItem.Rows.Add(oRow);
        //                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
        //                {
        //                    oRow.Cells[2].Value = "";
        //                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    dgvLineItem.Rows.RemoveAt(nRowIndex);
        //                    return;
        //                }
        //                else
        //                {
        //                    dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
        //                }
        //            }
        //        }

        //    }

        //}

        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            //refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }

        

     

        //private void btnCtlCustPicker_Click(object sender, EventArgs e)
        //{
        //    _oCustomer = new Customer();
        //    frmCustomerSearch oObj = new frmCustomerSearch(sCustumerTypeID);
        //    oObj.ShowDialog(_oCustomer);
        //    if (_oCustomer.CustomerCode != null)
        //    {
        //        if (_oCustomer.IsActive == (int)Dictionary.IsActive.Active)
        //        {
        //            txtCtlCustCode.Text = _oCustomer.CustomerCode.ToString();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtCtlCustCode.Text = "";
        //            txtCtlCustCode.Focus();
        //            return;
        //        }
        //    }
        //}

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblSalesType.Text == "Dealer")
            {
                this.Text = "Dealer Sales Order";
                _nSalesType = (int)Dictionary.SalesType.Dealer;
                if (Utility.CompanyInfo == "TEL")
                {
                    sCustumerTypeID = "217,2,219";
                }
                else
                {
                    sCustumerTypeID = "-1";
                }
            }
            else if (lblSalesType.Text == "B2B")
            {
                this.Text = "Corporate (B2B) Sales Order";
                _nSalesType = (int)Dictionary.SalesType.B2B;
                if (Utility.CompanyInfo == "TEL")
                {
                    sCustumerTypeID = "245,249";
                }
                else
                {
                    sCustumerTypeID = "217,202";
                }
            }
        }
       
        private void btnApprove_Click(object sender, EventArgs e)
        {
           
            try
            {
                DBController.Instance.BeginNewTransaction();

                _oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                _oDMSSecondarySalesOrder.OrderNo = lblOrderNumber.Text;
                _oDMSSecondarySalesOrder.Status = (int)Dictionary.DMSSecondarySalesOrderStatus.Approved_By_HO;
                _oDMSSecondarySalesOrder.Remarks = txtAuthorizeRemarks.Text;
                _oDMSSecondarySalesOrder.OrderID = nDMSOrderID;
                _oDMSSecondarySalesOrder.Approve();
                _oDMSSecondarySalesOrder.UpdateConfirmQty(_oDMSSecondarySalesOrder.Status, nWarehouseID);

                DataTran _oDataTranDMS = new DataTran();
                _oDataTranDMS.TableName = "t_DMSSecondarySalesOrder";
                _oDataTranDMS.DataID = nDMSOrderID;
                _oDataTranDMS.WarehouseID = nWarehouseID;
                _oDataTranDMS.TransferType = (int)Dictionary.DataTransferType.Add;
                _oDataTranDMS.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTranDMS.BatchNo = 0;
                if (_oDataTranDMS.CheckDataByWHID() == false)
                {
                    _oDataTranDMS.AddForTDPOS();
                }
                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Approved sales order # " + lblOrderNumber.Text, "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void frmDMSSalesOrder_Load(object sender, EventArgs e)
        {
           
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

            try
            {
                DBController.Instance.BeginNewTransaction();

                _oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                _oDMSSecondarySalesOrder.OrderNo = lblOrderNumber.Text;
                _oDMSSecondarySalesOrder.Status = (int)Dictionary.DMSSecondarySalesOrderStatus.Reject_By_HO;
                _oDMSSecondarySalesOrder.Remarks = txtAuthorizeRemarks.Text;
                _oDMSSecondarySalesOrder.OrderID = nDMSOrderID;
                _oDMSSecondarySalesOrder.Approve();
                _oDMSSecondarySalesOrder.UpdateConfirmQty(_oDMSSecondarySalesOrder.Status, nWarehouseID);

                DataTran _oDataTranDMS = new DataTran();
                _oDataTranDMS.TableName = "t_DMSSecondarySalesOrder";
                _oDataTranDMS.DataID = nDMSOrderID;
                _oDataTranDMS.WarehouseID = nWarehouseID;
                _oDataTranDMS.TransferType = (int)Dictionary.DataTransferType.Add;
                _oDataTranDMS.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTranDMS.BatchNo = 0;
                if (_oDataTranDMS.CheckDataByWHID() == false)
                {
                    _oDataTranDMS.AddForTDPOS();
                }
                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Rejected sales order # " + lblOrderNumber.Text, "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
