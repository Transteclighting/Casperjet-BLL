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

namespace CJ.POS.RT
{
    public partial class frmDMSSalesOrder : Form
    {
        ProductStock _oProductStock;
        ProductDetail _oProductDetail;
        TELLib oTELLib;
        Customer _oCustomer;
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        string sCustumerTypeID = "";
        DMSSecondarySalesOrder _oDMSSecondarySalesOrder;
        int _nOrderID = 0;
        string _sOrderNo;

        int _nSalesType = 0;
        public frmDMSSalesOrder()
        {
            InitializeComponent();
        }

        public void ShowDialog(DMSSecondarySalesOrder oDMSSecondarySalesOrder)
        {
            this.Tag = oDMSSecondarySalesOrder;

            if (oDMSSecondarySalesOrder.SalesType == (int)Dictionary.SalesType.B2B)
            {
                cmbSalesType.SelectedIndex = 2;
            }
            else if (oDMSSecondarySalesOrder.SalesType == (int)Dictionary.SalesType.Dealer)
            {
                cmbSalesType.SelectedIndex = 1;
            }

           
            if (oDMSSecondarySalesOrder.OrderType != "")
            {
                cmbOrderType.Text = oDMSSecondarySalesOrder.OrderType;
            }
            else
            {
                cmbOrderType.SelectedIndex = 0;
            }

            _nOrderID = oDMSSecondarySalesOrder.OrderID;
            //nWarehouseID = oDMSSecondarySalesOrder.WarehouseID;
            //lblCustomerName.Text = oDMSSecondarySalesOrder.CustomerName;
            _sOrderNo = oDMSSecondarySalesOrder.OrderNo;
            txtRemarks.Text = oDMSSecondarySalesOrder.Remarks;
            dtEDD.Value = oDMSSecondarySalesOrder.EDD;

            _oCustomer = new Customer();
            _oCustomer.GetCustomerDetailByID(oDMSSecondarySalesOrder.CustomerID);
            txtCtlCustCode.Text = _oCustomer.CustomerCode;

            //lblArea.Text = _oCustomer.AreaName;
            //lblTerritory.Text = _oCustomer.TerritoryName;
            //lblThana.Text = _oCustomer.ThanaName;
            //lblDistrict.Text = _oCustomer.DistrictName;
            //lblWarehouse.Text = _oCustomer.ParentCustomerName;


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
                oRow.Cells[4].Value = Convert.ToString(_oProductStock.CurrentStock - _oProductStock.BookingStock);

                _oProductStock = new ProductStock();
                _oProductStock.GetProductStock(oDMSSecondarySalesOrder.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
                oRow.Cells[5].Value = _oProductStock.CurrentStock.ToString();



                oRow.Cells[6].Value = oOrderItem.OrderQty;
                oRow.Cells[7].Value = oOrderItem.UnitPrice * oOrderItem.OrderQty;
                oRow.Cells[8].Value = oOrderItem.ProductID;

                dgvLineItem.Rows.Add(oRow);

            }

            GetTotalAmount();

            this.ShowDialog();

        }
        public bool ValidateUIInput()
        {

            #region Invoice Basic Validation
            if (cmbSalesType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Sales Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSalesType.Focus();
                return false;
            }
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
                    DBController.Instance.OpenNewConnection();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();


                    _oProductStock = new ProductStock();
                    _oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = Convert.ToString(_oProductStock.CurrentStock - _oProductStock.BookingStock);

                    _oProductStock = new ProductStock();
                    _oProductStock.GetProductStock(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oProductStock.CurrentStock.ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (_oProductDetail.ProductID).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (nColumnIndex == 6)
            {
                try
                {
                    int temp = Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[6].Value);
                }
                catch
                {

                    MessageBox.Show("Please input valid order qty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvLineItem.Rows[nRowIndex].Cells[7].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[6].Value.ToString());
                GetTotalAmount();
            }


        }
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

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
    
                    _oProductStock = new ProductStock();
                    _oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID);
                    oRow.Cells[4].Value = Convert.ToString(_oProductStock.CurrentStock - _oProductStock.BookingStock);
                    _oProductStock = new ProductStock();
                    _oProductStock.GetProductStock(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID);
                    oRow.Cells[5].Value = _oProductStock.CurrentStock.ToString();
                    oRow.Cells[8].Value = oForm._oProductDetail.ProductID;

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

        }

        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }
        private void txtCtlCustCode_TextChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oCustomer = new Customer();

            txtCtlCustCode.ForeColor = System.Drawing.Color.Red;
            txtCtlCustName.Text = "";

            if (txtCtlCustCode.Text.Length >= 1 && txtCtlCustCode.Text.Length <= 25)
            {
                _oCustomer.CustomerCode = txtCtlCustCode.Text;
                _oCustomer.RefreshByCode();

                if (_oCustomer.CustomerName == null)
                {
                    _oCustomer = null;
                    AppLogger.LogFatal("There is no data in the Employee.");
                    return;
                }
                else if (_oCustomer.IsActive == (int)Dictionary.IsActive.InActive)
                {
                    MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Focus();
                    return;
                }
                else
                {
                    txtCtlCustName.Text = _oCustomer.CustomerName.ToString();
                    txtCtlCustCode.SelectionStart = 0;
                    txtCtlCustCode.SelectionLength = txtCtlCustCode.Text.Length;
                    txtCtlCustCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);
        }

        private void btnCtlCustPicker_Click(object sender, EventArgs e)
        {
            _oCustomer = new Customer();
            frmCustomerSearch oObj = new frmCustomerSearch(sCustumerTypeID);
            oObj.ShowDialog(_oCustomer);
            if (_oCustomer.CustomerCode != null)
            {
                if (_oCustomer.IsActive == (int)Dictionary.IsActive.Active)
                {
                    txtCtlCustCode.Text = _oCustomer.CustomerCode.ToString();
                }
                else
                {
                    MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Focus();
                    return;
                }
            }
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbSalesType.Text == "Dealer")
            {
                _nSalesType = (int)Dictionary.SalesType.Dealer;
            }
            else if (cmbSalesType.Text == "B2B")
            {
                _nSalesType = (int)Dictionary.SalesType.B2B;
            }
            else if (cmbSalesType.Text == "B2C")
            {
                _nSalesType = (int)Dictionary.SalesType.B2C;
            }
            else if (cmbSalesType.Text == "eStore")
            {
                _nSalesType = (int)Dictionary.SalesType.eStore;
            }
            else if (cmbSalesType.Text == "HPA")
            {
                _nSalesType = (int)Dictionary.SalesType.HPA;
            }
            else
            {
                _nSalesType = (int)Dictionary.SalesType.Retail;
            }

            CustomerTypies oCustomerTypes = new CustomerTypies();
            sCustumerTypeID = oCustomerTypes.GetCustTypeSalesTypeWise(_nSalesType);

            //if (cmbSalesType.Text == "Dealer")
            //{
            //    this.Text = "Dealer Sales Order";
            //    _nSalesType = (int)Dictionary.SalesType.Dealer;
            //    if (Utility.CompanyInfo == "TEL")
            //    {
                    

            //        sCustumerTypeID = "217,2,219";
            //    }
            //    else
            //    {
            //        sCustumerTypeID = "-1";
            //    }
            //}
            //else if (cmbSalesType.Text == "B2B")
            //{
            //    this.Text = "Corporate (B2B) Sales Order";
            //    _nSalesType = (int)Dictionary.SalesType.B2B;
            //    if (Utility.CompanyInfo == "TEL")
            //    {
            //        sCustumerTypeID = "245,249";
            //    }
            //    else
            //    {
            //        sCustumerTypeID = "217,202";
            //    }
            //}
        }
        public DMSSecondarySalesOrder GetUIData(DMSSecondarySalesOrder _oDMSSecondarySalesOrder)
        {
            oTELLib = new TELLib();

            _oDMSSecondarySalesOrder.ParentCustomerId = Utility.CustomerID;
            _oDMSSecondarySalesOrder.CustomerID = _oCustomer.CustomerID;
            _oDMSSecondarySalesOrder.Remarks = txtRemarks.Text;
            _oDMSSecondarySalesOrder.EDD = dtEDD.Value.Date;
            _oDMSSecondarySalesOrder.Amount = Convert.ToDouble(txtTotalAmount.Text);
            _oDMSSecondarySalesOrder.WarehouseID = Utility.WarehouseID;
            _oDMSSecondarySalesOrder.SalesType = _nSalesType;
            _oDMSSecondarySalesOrder.Shortcode = Utility.Shortcode;
            _oDMSSecondarySalesOrder.OrderType = cmbOrderType.Text;
            _oDMSSecondarySalesOrder.CreateDate = oTELLib.ServerDateTime().Date;
            _oDMSSecondarySalesOrder.CreateUserID = Utility.UserId;


            // Product Details
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {

                    DMSSecondarySalesOrderDetail _oDMSSecondarySalesOrderDetail = new DMSSecondarySalesOrderDetail();

                    _oDMSSecondarySalesOrderDetail.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
                    _oDMSSecondarySalesOrderDetail.OrderQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                    _oDMSSecondarySalesOrderDetail.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                    _oDMSSecondarySalesOrderDetail.WarehouseID = Utility.WarehouseID;
                    _oDMSSecondarySalesOrderDetail.ConfirmedQty = 0;

                    _oDMSSecondarySalesOrder.Add(_oDMSSecondarySalesOrderDetail);

                }
            }

            return _oDMSSecondarySalesOrder;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (ValidateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                        _oDMSSecondarySalesOrder = GetUIData(_oDMSSecondarySalesOrder);
                        _oDMSSecondarySalesOrder.EditNew(_nOrderID);


                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully edit sales order # " + _sOrderNo, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (ValidateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                        _oDMSSecondarySalesOrder = GetUIData(_oDMSSecondarySalesOrder);
                        _oDMSSecondarySalesOrder.AddNew();
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add Sales Order # " + _oDMSSecondarySalesOrder.Shortcode.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmDMSSalesOrder_Load(object sender, EventArgs e)
        {
            oTELLib = new TELLib();
            if (this.Tag == null)
            {
                cmbSalesType.SelectedIndex = 0;
                cmbOrderType.SelectedIndex = 0;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            //lblLastUpdateDate.Text = oTELLib.ServerDateTime().Date.ToString("dd-MMM-yyyy hh:mm tt");

            //lblLastUpdateDate.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
