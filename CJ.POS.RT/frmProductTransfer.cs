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
using CJ.Class.Duty;

namespace CJ.POS.RT
{
    public partial class frmProductTransfer : Form
    {
        public bool _IsTrue = false;
        Showroom oShowroom;
        DutyTran oDutyTranVAT63_15;
        DutyTran oDutyTranVAT63_5;
        DutyTran oDutyTranVATExempted;
        POSRequisition _oPOSRequisition;
        //SystemInfo oSystemInfo;
        ProductStock _oProductStock;
        ProductDetail _oProductDetail;
        StockTran _oStockTran;
        //Warehouses _oWarehouses;
        //Warehouse _oWarehouse;
        Showrooms _oShowrooms;
        Product _oProduct;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;
        int[] ProductIDList ={ 9, 1823, 2810, 2935, 2936, 2937 };
        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;
        DutyAccount oDutyAccount;
        //SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        //SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        ProductTransferProductSerial _oProductTransferProductSerial;
        ProductTransferProductSerials _oProductTransferProductSerials;
        int _MappedWHID;
        int nUIControl = 0;
        TELLib oTELLib;
        int nRequisitionID = 0;
        int nToWHID = 0;
        string sRequisitionNo = "";
        string sSplit = "";
        int InitializeCondition = 0;
        private string[] sProductBarcodeArr = null;
        private int nArrayLen = 0;

        public frmProductTransfer(int _nUIControl)
        {
            InitializeComponent();
            InitializeCondition = 0;
            nUIControl = _nUIControl;
        }
        //CD
        private void frmProductRequisition_Load(object sender, EventArgs e)
        {


            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oShowroom = new Showroom();
            _MappedWHID = oShowroom.GetMappedWH(Utility.WarehouseID);

            if (nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Create)
            {
                if (this.Tag == null)
                {
                    this.Text = "Add ISGM to Other Outlet";
                }
                else
                {
                    this.Text = "Edit ISGM to Other Outlet";
                }
                LoadCombo();
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create)
            {
                if (this.Tag == null)
                {
                    this.Text = "Add ISGM to HO";
                }
                else
                {
                    this.Text = "Edit ISGM to HO";
                }
                lblToWH.Visible = false;
                cmbWarehouse.Visible = false;
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Create)
            {
                if (this.Tag == null)
                {
                    this.Text = "Add Send to CSD";
                }
                else
                {
                    this.Text = "Edit Send to CSD";
                }
                lblToWH.Visible = false;
                cmbWarehouse.Visible = false;
            }
        }
        //CD
        private void LoadCombo()
        {

            _oShowrooms = new Showrooms();
            _oShowrooms.GetShowroomForISGM(Utility.WarehouseID);

            cmbWarehouse.Items.Add("--Select Outlet--");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbWarehouse.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }

            cmbWarehouse.SelectedIndex = 0;
        }
        //CD
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //CD
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

                    oRow.Cells[6].Value = oForm._oProductDetail.ProductID;

                    oRow.Cells[9].Value = oForm._oProductDetail.TradePrice;
                    oRow.Cells[10].Value = oForm._oProductDetail.NSP;
                    oRow.Cells[11].Value = oForm._oProductDetail.RSP;
                    oRow.Cells[12].Value = oForm._oProductDetail.Vat;
                    oRow.Cells[13].Value = oForm._oProductDetail.SupplyType;
                    oRow.Cells[14].Value = oForm._oProductDetail.VATType;
                    oRow.Cells[15].Value = oForm._oProductDetail.VATApplicable;
                    oRow.Cells[16].Value = oForm._oProductDetail.VATCP;


                    _oProductStock = new ProductStock();
                    _oProductStock.GetProductStockRT(Utility.WarehouseID,(int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID);

                    if (_oProductStock.CurrentStock != 0)
                    {
                        oRow.Cells[3].Value = _oProductStock.CurrentStock.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product Stock not avialable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nRowIndex = dgvLineItem.Rows.Add(oRow);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }


                    oRow.Cells[8].Value = oForm._IsBarcodeItem;
                    if (oForm._IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[4].ReadOnly = false;
                        oRow.Cells[4].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                    }

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
            else if (e.ColumnIndex == 7)
            {

                try
                {
                    int temp = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[6].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Select a Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmAvailableBarcode ofrmAvailableBarcode = new frmAvailableBarcode(int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[6].Value.ToString()), Utility.WarehouseID, "", 0);
                ofrmAvailableBarcode.ShowDialog();
                if (int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[8].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (ofrmAvailableBarcode._nCount > 0)
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[5].Value = ofrmAvailableBarcode._sBarcode;
                        dgvLineItem.Rows[e.RowIndex].Cells[4].Value = ofrmAvailableBarcode._nCount;
                        GetTotalAmount();
                    }
                }
                else
                {
                    GetTotalAmount();
                }
            }

        }
        //CD
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        //CD
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
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (_oProductDetail.ProductID).ToString();

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = (_oProductDetail.TradePrice).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 10].Value = (_oProductDetail.NSP).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 11].Value = (_oProductDetail.RSP).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 12].Value = (_oProductDetail.Vat).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 13].Value = (_oProductDetail.SupplyType).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 14].Value = (_oProductDetail.VATType).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 15].Value = (_oProductDetail.VATApplicable).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 16].Value = (_oProductDetail.VATCP).ToString();

                    _oProductStock = new ProductStock();
                    _oProductStock.GetProductStockRT(Utility.WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID);
                    if (_oProductStock.CurrentStock != 0)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductStock.CurrentStock.ToString(); 
                    }
                    else
                    {
                        MessageBox.Show("Product Stock not avialable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = _oProductDetail.IsBarcodeItem;
                    if (_oProductDetail.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].ReadOnly = false;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].ReadOnly = true;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            
        }
        //CD
        public void GetTotalAmount()
        {
            
            txtTotalQty.Text = "0";
            oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[4].Value != null)
                {
                    txtTotalQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();
                }
            }

        }
        //CD
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
        //CD
        private void InsertVAT65New(int nTranID, string sTranNo,int _nRequisitionID)
        {
            double _TotalAmount_63_15 = 0;
            double _TotalAmount_63_5 = 0;

            int countMUSHAK_63_15 = 0;
            int countMUSHAK_63_5 = 0;

            int countMUSHAK_Exempted = 0;



            oDutyTranVAT63_15 = new DutyTran();
            oDutyTranVAT63_5 = new DutyTran();

            oDutyTranVATExempted = new DutyTran();

            ////15%
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (int.Parse(oItemRow.Cells[15].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        if (int.Parse(oItemRow.Cells[14].Value.ToString()) == (int)Dictionary.VATType.IMPORTED_15 || int.Parse(oItemRow.Cells[14].Value.ToString()) == (int)Dictionary.VATType.LOCAL_15)
                        {
                            if (countMUSHAK_63_15 == 0)
                            {
                                DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                                DateTime time = DateTime.Now;
                                DateTime combine = day.Add(time.TimeOfDay);
                                oDutyTranVAT63_15.DutyTranDate = Convert.ToDateTime(combine);
                                oDutyTranVAT63_15.WHID = Utility.WarehouseID;
                                oDutyTranVAT63_15.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                                oDutyTranVAT63_15.DocumentNo = sTranNo;
                                oDutyTranVAT63_15.RefID = nTranID;
                                oDutyTranVAT63_15.DutyTypeID = (int)Dictionary.DutyType.VAT;
                                oDutyTranVAT63_15.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                                oDutyTranVAT63_15.Remarks = txtRemarks.Text;
                                oDutyTranVAT63_15.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;
                                oDutyTranVAT63_15.Amount = 0;
                                oDutyTranVAT63_15.VehicleDetail = txtVehicleNo.Text;

                                oDutyTranVAT63_15.InsertForPOSISGMNewRT(Utility.WarehouseCode, 1);
                                countMUSHAK_63_15++;
                            }

                            DutyTranDetail oItem = new DutyTranDetail();

                            oItem.DutyTranID = oDutyTranVAT63_15.DutyTranID;
                            oItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                            oItem.Qty = int.Parse(oItemRow.Cells[4].Value.ToString());
                            oItem.DutyPrice = Convert.ToDouble(oItemRow.Cells[16].Value.ToString());
                            oItem.DutyRate = Convert.ToDouble(oItemRow.Cells[12].Value.ToString());
                            oItem.WHID = Utility.WarehouseID;
                            oItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[11].Value.ToString());
                            oItem.VAT = (oItem.DutyPrice * oItem.DutyRate) * oItem.Qty;
                            oItem.VATType = int.Parse(oItemRow.Cells[14].Value.ToString());
                            _TotalAmount_63_15 = _TotalAmount_63_15 + oItem.VAT;
                            oItem.InsertForPOSISGM();

                            oItem.StockRequisitionID = _nRequisitionID;
                            oItem.DutyTranNo = oDutyTranVAT63_15.DutyTranNo;
                            oItem.TranID = nTranID;
                            oItem.UpdateVATNoStockRequisition();
                            //oItem.UpdateVATNoStockTranItem();


                        }

                    }

                }
            }


            ////5%
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (int.Parse(oItemRow.Cells[15].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        if (int.Parse(oItemRow.Cells[14].Value.ToString()) == (int)Dictionary.VATType.LOCAL_5|| int.Parse(oItemRow.Cells[14].Value.ToString()) == (int)Dictionary.VATType.IMPORTED_5)
                        {
                            if (countMUSHAK_63_5 == 0)
                            {

                                DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                                DateTime time = DateTime.Now;
                                DateTime combine = day.Add(time.TimeOfDay);
                                oDutyTranVAT63_5.DutyTranDate = Convert.ToDateTime(combine);
                                oDutyTranVAT63_5.WHID = Utility.WarehouseID;
                                oDutyTranVAT63_5.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                                oDutyTranVAT63_5.DocumentNo = sTranNo;
                                oDutyTranVAT63_5.RefID = nTranID;
                                oDutyTranVAT63_5.DutyTypeID = (int)Dictionary.DutyType.VAT;
                                oDutyTranVAT63_5.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                                oDutyTranVAT63_5.Remarks = txtRemarks.Text;
                                oDutyTranVAT63_5.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;
                                oDutyTranVAT63_5.Amount = 0;
                                oDutyTranVAT63_5.VehicleDetail = txtVehicleNo.Text;

                                oDutyTranVAT63_5.InsertForPOSISGMNewRT(Utility.WarehouseCode, 1);
                                countMUSHAK_63_5++;
                            }

                            DutyTranDetail oItem = new DutyTranDetail();
                            oItem.DutyTranID = oDutyTranVAT63_5.DutyTranID;
                            oItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                            oItem.Qty = int.Parse(oItemRow.Cells[4].Value.ToString());
                            oItem.DutyPrice = Convert.ToDouble(oItemRow.Cells[16].Value.ToString());
                            oItem.DutyRate = Convert.ToDouble(oItemRow.Cells[12].Value.ToString());
                            oItem.WHID = Utility.WarehouseID;
                            oItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[11].Value.ToString());
                            oItem.VAT = (oItem.DutyPrice * oItem.DutyRate) * oItem.Qty;
                            oItem.VATType = int.Parse(oItemRow.Cells[14].Value.ToString());
                            _TotalAmount_63_5 = _TotalAmount_63_5 + oItem.VAT;
                            oItem.InsertForPOSISGM();


                            oItem.StockRequisitionID = _nRequisitionID;
                            oItem.DutyTranNo = oDutyTranVAT63_5.DutyTranNo;
                            oItem.TranID = nTranID;
                            oItem.UpdateVATNoStockRequisition();
                            //oItem.UpdateVATNoStockTranItem();

                        }
                    }

                }
            }




            ////Vat Exempted
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (int.Parse(oItemRow.Cells[15].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        if (int.Parse(oItemRow.Cells[14].Value.ToString()) == (int)Dictionary.VATType.VAT_Exempted)
                        {
                            if (countMUSHAK_Exempted == 0)
                            {

                                DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                                DateTime time = DateTime.Now;
                                DateTime combine = day.Add(time.TimeOfDay);
                                oDutyTranVATExempted.DutyTranDate = Convert.ToDateTime(combine);
                                oDutyTranVATExempted.WHID = Utility.WarehouseID;
                                oDutyTranVATExempted.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                                oDutyTranVATExempted.DocumentNo = sTranNo;
                                oDutyTranVATExempted.RefID = nTranID;
                                oDutyTranVATExempted.DutyTypeID = (int)Dictionary.DutyType.VAT;
                                oDutyTranVATExempted.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                                oDutyTranVATExempted.Remarks = txtRemarks.Text;
                                oDutyTranVATExempted.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;
                                oDutyTranVATExempted.Amount = 0;
                                oDutyTranVATExempted.VehicleDetail = txtVehicleNo.Text;

                                oDutyTranVATExempted.InsertForPOSISGMNewRT(Utility.WarehouseCode, 1);
                                countMUSHAK_Exempted++;
                            }

                            DutyTranDetail oItem = new DutyTranDetail();
                            oItem.DutyTranID = oDutyTranVATExempted.DutyTranID;
                            oItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                            oItem.Qty = int.Parse(oItemRow.Cells[4].Value.ToString());
                            oItem.DutyPrice = Convert.ToDouble(oItemRow.Cells[16].Value.ToString());
                            oItem.DutyRate = Convert.ToDouble(oItemRow.Cells[12].Value.ToString());
                            oItem.WHID = Utility.WarehouseID;
                            oItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[11].Value.ToString());
                            oItem.VAT = (oItem.DutyPrice * oItem.DutyRate) * oItem.Qty;
                            oItem.VATType = int.Parse(oItemRow.Cells[14].Value.ToString());
                            //_TotalAmount_63_5 = _TotalAmount_63_5 + oItem.VAT;
                            oItem.InsertForPOSISGM();


                            oItem.StockRequisitionID = _nRequisitionID;
                            oItem.DutyTranNo = oDutyTranVATExempted.DutyTranNo;
                            oItem.TranID = nTranID;
                            oItem.UpdateVATNoStockRequisition();
                            //oItem.UpdateVATNoStockTranItem();

                        }
                    }

                }
            }



            oDutyTranVAT63_15.Amount = _TotalAmount_63_15;
            oDutyTranVAT63_15.UpdateToatlVATAmountISGMRT();

            oDutyTranVAT63_5.Amount = _TotalAmount_63_5;
            oDutyTranVAT63_5.UpdateToatlVATAmountISGMRT();



            oDutyAccount = new DutyAccount();
            oDutyAccount.DutyAccountTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
            oDutyAccount.Balance = _TotalAmount_63_15 + _TotalAmount_63_5;
            oDutyAccount.UpdateBalanceForPOSISGM(true);



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                _oPOSRequisition = (POSRequisition)this.Tag;
                if (_nIsUpdateVehicle == 1)
                {
                    if (txtVehicleNo.Text.Trim() == "")
                    {
                        MessageBox.Show("Please put Vehicle Detail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtVehicleNo.Focus();
                        return;
                    }
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        DutyTran oDutyTran = new DutyTran();
                        oDutyTran.DutyTranID = _nDutyTranID;
                        oDutyTran.VehicleDetail = txtVehicleNo.Text.Trim();
                        oDutyTran.WHID = Utility.WarehouseID;
                        oDutyTran.UpdateVehicleDetailISGMRT();


                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update Vehicle Detail Requisition # " + _oPOSRequisition.RequisitionNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        //Insert Stock Requisition, Requisition Item & Update Product Stock
                        _oPOSRequisition.InsertStockRequisitionRT(nUIControl);
                        _oStockTran = new StockTran();
                        _oStockTran = GetDataForProductStockTran(_oStockTran);
                        _oStockTran.TranTypeID = (int)Dictionary.ProductStockTranType.TRANSFER;
                        //Insert t_ProductStockTran/t_ProductStockTranItem
                       // _oStockTran.InsertTranBranch(false);
                        _oStockTran.InsertTranBranchRT(true);
                        _oPOSRequisition.StockTranID = _oStockTran.TranID;
                        //Update t_StockRequisition/StockTranID from t_ProductStockTran
                        _oPOSRequisition.UpdateStockTranID_POS();

                        #region barcode from Invoice Item
                        int _nCount = 1;
                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {
                            if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                            {
                                {
                                    char[] splitchar = { ',' };
                                    if (oItemRow.Cells[5].Value != null)
                                    {
                                        string sProductBarcode = oItemRow.Cells[5].Value.ToString();
                                        sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                        nArrayLen = sProductBarcodeArr.Length;
                                        int nProductID = Convert.ToInt32(oItemRow.Cells[6].Value.ToString());

                                        for (int i = 0; i < nArrayLen; i++)
                                        {

                                            ProductBarcode oProductBarcode = new ProductBarcode();
                                            oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];

                                            //Insert t_ProductTransferProductSerial
                                            ProductTransferProductSerial oPTPS = new ProductTransferProductSerial();
                                            oPTPS.ProductID = nProductID;
                                            oPTPS.SerialNo = _nCount;
                                            oPTPS.ProductSerialNo = oProductBarcode.ProductSerialNo;
                                            oPTPS.Insert(_oStockTran.TranID);

                                            

                                            if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create)
                                            {
                                                oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Send_from_Outlet_to_HO;
                                                oProductBarcode.ToWHID = _MappedWHID;
                                            }
                                            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Create)
                                            {
                                                oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Send_from_Outlet_to_Outlet;
                                                oProductBarcode.ToWHID = _oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID;
                                            }
                                            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Create)
                                            {
                                                oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Send_from_Outlet_CSD;
                                                oProductBarcode.ToWHID = Utility.CSDWarehouse;
                                            }
                    
                                            //update Vat Paid Data
                                            Product oProduct = new Product();
                                            oProduct.ProductID = nProductID;
                                            oProduct.RefreshByID();
                                            oProductBarcode.UpdateVatPaidProductSerial(Utility.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.TRANSFER, _oStockTran.TranNo, Convert.ToDateTime(_oStockTran.TranDate));

                                            oProductBarcode.CreateDate = DateTime.Now;
                                            oProductBarcode.FromWHID = Utility.WarehouseID;
                                            oProductBarcode.GetProductSerialIDRT(oProductBarcode.ProductSerialNo);
                                            oProductBarcode.InsertProductSerialHistory();
                                            oProductBarcode.IsTransitStock = 1;
                                            oProductBarcode.UpdateProductSerialRT();

                                            _nCount++;

                                        }
                                    }

                                }
                            }
                        }
                        #endregion

                        #region New Duty
                        if (Utility.CompanyInfo == "TEL")
                        {
                            InsertVAT65New(_oStockTran.TranID, _oStockTran.TranNo, _oPOSRequisition.RequisitionID);
                        }
                        #endregion

                        
                        DBController.Instance.CommitTran();
                        _IsTrue = true;
                        MessageBox.Show("Success fully Add Stock Requisition # " + _oPOSRequisition.RequisitionNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //CD
        public POSRequisition GetUIData(POSRequisition _oPOSRequisition)
        {


            _oPOSRequisition.FromWHID = Utility.WarehouseID;
            if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create)
            {
                _oPOSRequisition.ToWHID = _MappedWHID;
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Create)
            {
                _oPOSRequisition.ToWHID = _oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Create)
            {
                _oPOSRequisition.ToWHID = Utility.CSDWarehouse;
            }
            _oPOSRequisition.Remarks = txtRemarks.Text;
            _oPOSRequisition.Terminal = (int)Dictionary.Terminal.Branch_Office;


            // Product Details
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {

                    POSRequisitionItem _oPOSRequisitionItem = new POSRequisitionItem();

                    _oPOSRequisitionItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                    _oPOSRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oPOSRequisitionItem.AuthorizeQty = 0;

                    _oPOSRequisition.Add(_oPOSRequisitionItem);

                }
            }

            return _oPOSRequisition;
        }
        //CD
        public StockTran GetDataForProductStockTran(StockTran _oStockTran)
        {

            _oStockTran.LastUpdateDate = DateTime.Now;
            _oStockTran.CreateDate = DateTime.Now;
            _oStockTran.TranNo = _oPOSRequisition.RequisitionNo;
            _oStockTran.TranDate = DateTime.Now.Date;
            _oStockTran.FromWHID = Utility.WarehouseID;
            _oStockTran.FromChannelID = Utility.ChannelID;
            if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create)
            {
                _oStockTran.ToWHID = _MappedWHID;  
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Create)
            {
                _oStockTran.ToWHID = _oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Create)
            {
                _oStockTran.ToWHID = Utility.CSDWarehouse;
            }
            _oStockTran.ToChannelID = Utility.RetailChannelID;
            _oStockTran.Status = (int)Dictionary.StockTransactionStatus.PENDING;
            _oStockTran.UserID = Utility.UserId;
            _oStockTran.Remarks = txtRemarks.Text;


            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.GetPriceByProductID(int.Parse(oItemRow.Cells[6].Value.ToString()));

                    StockTranItem _oStockTranItem = new StockTranItem();

                    _oStockTranItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                    _oStockTranItem.StockPrice = _oProductDetail.RSP;
                    _oStockTranItem.Qty = int.Parse(oItemRow.Cells[4].Value.ToString());

                    _oStockTran.Add(_oStockTranItem);
                }
            }

            return _oStockTran;
        }
        //CD
        private bool validateUIInput()
        {
            #region Order Master Information Validation
            if (nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Create)
            {
                if (cmbWarehouse.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select a Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbWarehouse.Focus();
                    return false;
                }
            }

            #endregion

            #region Order Details Information Validation
            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Insert Product ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[6].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Insert Product ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input valid Qty ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (int.Parse(oItemRow.Cells[4].Value.ToString()) > int.Parse(oItemRow.Cells[3].Value.ToString()))
                    {
                        MessageBox.Show("Transfer/ISGM Qty must be equal or same to Stock Qty ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            #endregion

            return true;
        }

        int _nIsUpdateVehicle = 0;
        int _nDutyTranID = 0;
        public void ShowDialog(POSRequisition oPOSRequisition, int nDutyTranID)
        {
            _nIsUpdateVehicle = 1;
            _nDutyTranID = nDutyTranID;
            cmbWarehouse.Enabled = false;
            dgvLineItem.Enabled = false;
            txtRemarks.Enabled = false;

            this.Tag = oPOSRequisition;
            this.ShowDialog();
        }
        //public void ShowDialog(POSRequisition oPOSRequisition)
        //{

        //    nRequisitionID = 0;
        //    nToWHID = 0;
        //    nRequisitionID = oPOSRequisition.RequisitionID;
        //    nToWHID = oPOSRequisition.ToWHID;
        //    sRequisitionNo = oPOSRequisition.RequisitionNo;
        //    oPOSRequisition.GetRequisitionItem(oPOSRequisition.RequisitionID);

        //    txtRemarks.Text = oPOSRequisition.Remarks;

        //    foreach (POSRequisitionItem oPOSRequisitionItem in oPOSRequisition)
        //    {
        //        DataGridViewRow oRow = new DataGridViewRow();
        //        oRow.CreateCells(dgvLineItem);
        //        oRow.Cells[0].Value = oPOSRequisitionItem.ProductCode.ToString();
        //        oRow.Cells[2].Value = oPOSRequisitionItem.ProductName.ToString();

        //        oRow.Cells[4].Value = _oProductStock.CurrentStock.ToString();

        //        oRow.Cells[4].Value = oPOSRequisitionItem.RequisitionQty.ToString();

        //        oRow.Cells[6].Value = oPOSRequisitionItem.ProductID.ToString();

        //        dgvLineItem.Rows.Add(oRow);

        //    }
        //    GetTotalAmount();
        //    this.Tag = oPOSRequisition;

        //    this.ShowDialog();
        //}
        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }



    }
}