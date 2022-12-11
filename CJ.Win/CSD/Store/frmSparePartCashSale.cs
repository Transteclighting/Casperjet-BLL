using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Class.Duty;

//using log4net.Util.TypeConverters; 

namespace CJ.Win.CSD.Store
{
    public partial class frmSparePartCashSale : Form  
    {
        SparePartsR _oSparePartsR;
        SPTran oSPTran;
        SPStock oSPStock;
        Technicians _oTechnicians;
        Stores _oStores;
        Stores _Stores;
        CSDJobBill _oCSDJobBill;
        CSDJobBillHistory _oCSDJobBillHistory;
        CSDJobBillHistorys _oCSDJobBillHistorys;
        int nSelectedStoreID = 0;
        private DutyAccount _oDutyAccount;

        public frmSparePartCashSale()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvIssuePart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbStore.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                nSelectedStoreID = _Stores[cmbStore.SelectedIndex - 1].StoreID;
            }
            catch
            {
                nSelectedStoreID = 0;
            }
            if (e.ColumnIndex == 1)
            {
                frmSparePartSearchR oForm = new frmSparePartSearchR(nSelectedStoreID);
                oForm.ShowDialog();
                if (oForm._oSparePartsR != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvPartSale);
                    oRow.Cells[0].Value = oForm._oSparePartsR.Code;
                    oRow.Cells[2].Value = oForm._oSparePartsR.Name;
                    oRow.Cells[3].Value = oForm._oSparePartsR.CurrentStock;
                    oRow.Cells[5].Value = oForm._oSparePartsR.SalePrice;
                    oRow.Cells[7].Value = oForm._oSparePartsR.SparePartID;
                    oRow.Cells[8].Value = oForm._oSparePartsR.CostPrice;

                    if (oForm._oSparePartsR != null)
                    {
                        int nRowIndex = dgvPartSale.Rows.Add(oRow);

                        if (CheckDuplicateLineItem(dgvPartSale.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvPartSale.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvPartSale.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }
            }

        }

        private void dgvIssuePart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }

        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sSpareCode = "";

            if (nColumnIndex == 0 && dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (cmbStore.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStore.Focus();
                    return;
                }

                if (CheckDuplicateLineItem(dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvPartSale.Rows.RemoveAt(nRowIndex);
                    return;
                }

                try
                {
                    sSpareCode = dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oSparePartsR = new SparePartsR();
                    _oSparePartsR.Code = sSpareCode;
                    _oSparePartsR.CheckSpareByCode(_Stores[cmbStore.SelectedIndex - 1].StoreID);

                    if (_oSparePartsR.Flag)
                    {
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oSparePartsR.Name;
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oSparePartsR.CurrentStock;
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oSparePartsR.SalePrice;
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (_oSparePartsR.SparePartID).ToString();
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = _oSparePartsR.CostPrice;

                    }
                    else
                    {
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = "";
                        dgvPartSale.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;

                        MessageBox.Show("Spare Part Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (nColumnIndex == 4)//(nColumnIndex == 5 || nColumnIndex == 4 || nColumnIndex == 3)
            {
                if (dgvPartSale.Rows[nRowIndex].Cells[4].Value.ToString() != "" && dgvPartSale.Rows[nRowIndex].Cells[5].Value.ToString() != "")
                {
                    try
                    {
                        dgvPartSale.Rows[nRowIndex].Cells[6].Value = (Convert.ToDouble(dgvPartSale.Rows[nRowIndex].Cells[4].Value.ToString()) * Convert.ToDouble(dgvPartSale.Rows[nRowIndex].Cells[5].Value.ToString()));

                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                    }
                }

                GetTotal();
            }

        }
        private void GetTotal()
        {
            txtTotalSPCharge.Text = "0.00";
            double nTotalSpCharge = 0.00;
            foreach (DataGridViewRow oRow in dgvPartSale.Rows)
            {
                if (oRow.Cells[5].Value != null)
                {
                    //txtNetSalePrice.Text = Convert.ToDouble(Convert.ToDouble(txtNetSalePrice.Text)+Convert.ToDouble(Convert.ToDouble(txtOtherCharge.Text.Trim())) + Convert.ToDouble(oRow.Cells[6].Value.ToString())-Convert.ToDouble(Convert.ToDouble(txtDiscount.Text))).ToString();
                    nTotalSpCharge += Convert.ToDouble(oRow.Cells[6].Value.ToString());
                }
            }
            txtTotalSPCharge.Text = nTotalSpCharge.ToString();

        }

        private void Save()
        {

            if (this.Tag == null)
            {

                oSPTran = new SPTran();
                oSPTran = GetUISPTranData(oSPTran);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSPTran.Add();
                    if (ctlCSDJob1.txtDescription.Text != "")
                    {
                        AddJobBill();
                        AddJobBillHistory(_oCSDJobBill.BillID);
                    }
                    GetUISPStockData();
                    InsertVAT63(oSPTran.SPTranID, oSPTran.TranNo);
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully With Tran No- " + oSPTran.TranNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }
        private void LoadCombos()
        {
            _Stores = new Stores();
            _Stores.RefreshChildStore();
            cmbStore.Items.Add("<Select Store>");
            foreach (Class.Store oStore in _Stores)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oStore.ChildSotre;
                //item.Value = oStore.StoreID.ToString();
                //cmbStore.Items.Add(item);

                cmbStore.Items.Add(oStore.ChildSotre);
            }
            cmbStore.SelectedIndex = 0;
        }

        public SPTran GetUISPTranData(SPTran oSPTran)
        {
            oSPTran.CustomerName = txtCustomerName.Text;
            oSPTran.CashMemoNo = txtCashMemoNo.Text;
            oSPTran.CustomerAddress = txtAddress.Text;
            if (ctlCSDJob1.txtDescription.Text != "")
            {
                oSPTran.JobID = ctlCSDJob1.SelectedJob.JobID;

            }
            else
            {

                oSPTran.JobID = 0;

            }
            oSPTran.DiscountAmt = Convert.ToDouble(txtDiscount.Text);
            oSPTran.NetAmount = Convert.ToDouble(txtNetSalePrice.Text);
            oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.SparePartSale;
            oSPTran.TranSide = (int)Dictionary.SparePartTranSide.OUT;
            oSPTran.FromStoreID = _Stores[cmbStore.SelectedIndex - 1].StoreID;
            oSPTran.OtherCharge = Convert.ToDouble(txtOtherCharge.Text.Trim());

            oSPTran.ToStoreID = -1;

            oSPTran.Remarks = txtRemarks.Text;

            foreach (DataGridViewRow oItemRow in dgvPartSale.Rows)
            {
                if (oItemRow.Index < dgvPartSale.Rows.Count - 1)
                {
                    SPTranDetail oItem = new SPTranDetail();

                    try
                    {
                        oItem.Qty = Convert.ToInt64(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.Qty = Convert.ToInt64(0);
                    }
                    oItem.SalePrice = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim());
                    oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                    oItem.CostPrice = Convert.ToDouble(oItemRow.Cells[8].Value.ToString().Trim());

                    oSPTran.Add(oItem);
                }
            }

            return oSPTran;
        }
        private void GetUISPStockData()
        {

            foreach (DataGridViewRow oItemRow in dgvPartSale.Rows)
            {
                if (oItemRow.Index < dgvPartSale.Rows.Count - 1)
                {

                    SPStock oItem = new SPStock();

                    try
                    {
                        oItem.AddDeductStockQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.AddDeductStockQty = Convert.ToInt32(0);
                    }
                    oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                    oItem.StoreID = _Stores[cmbStore.SelectedIndex - 1].StoreID;

                    oItem.UpdateStock(false);

                }
            }

        }

        private void Clear()
        {
            DBController.Instance.OpenNewConnection();
            txtCustomerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCashMemoNo.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            cmbStore.SelectedIndex = 0;
            txtDiscount.Text = "0.00";
            txtNetSalePrice.Text = "0.00";
            txtReceiveAmount.Text = "0.00";
            dgvPartSale.Rows.Clear();

        }

        private bool validateUIInput()
        {
            #region Transaction Master Information Validation

            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Customer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Customer Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtCashMemoNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Cash Memo No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashMemoNo.Focus();
                return false;
            }
            if (cmbStore.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Store First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStore.Focus();
                return false;
            }


            #endregion

            #region Transaction Details Information Validation

            if (dgvPartSale.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Spare Parts ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvPartSale.Rows)
            {
                if (oItemRow.Index < dgvPartSale.Rows.Count - 1)
                {
                    if (oItemRow.Cells[7].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Part code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[7].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Part Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItemRow.Cells[4].Value == null || int.Parse(oItemRow.Cells[4].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    oSPStock = new SPStock();
                    oSPStock.SparePartID = int.Parse(oItemRow.Cells[7].Value.ToString());
                    oSPStock.StoreID = _Stores[cmbStore.SelectedIndex - 1].StoreID;
                    oSPStock.CheckStockBySpareID();
                    if (oSPStock.CurrentStockQty < int.Parse(oItemRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Issue Qty must be less of equal current Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }


                }
            }
            #endregion
            if (Convert.ToDouble(txtNetSalePrice.Text) <= 0)
            {
                MessageBox.Show("Net price can't be less than or equal to zero", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                Clear();

            }
        }

        private int CheckDuplicateLineItem(string itemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvPartSale.Rows)
            {
                if (oItemRow.Index < dgvPartSale.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == itemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != string.Empty)
            {
                GetNetCharge();
            }
            else
            {
                txtDiscount.Text = "0.00";
            }
        }

        private void frmSparePartCashSale_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbStore.SelectedIndex == 0)
            //{
            //    dgvPartSale.Enabled = false;
            //}
            //else
            //{
            //    dgvPartSale.Enabled = true;
            //}
        }
        private void GetNetCharge()
        {
            double nTotalCharge = Convert.ToDouble(txtTotalSPCharge.Text);
            double nOtherCharge = Convert.ToDouble(txtOtherCharge.Text);
            double nDiscount = Convert.ToDouble(txtDiscount.Text);
            double nNetCharge = nTotalCharge + nOtherCharge - nDiscount;
            txtNetSalePrice.Text = nNetCharge.ToString();
        }
        private void txtOtherCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtOtherCharge.Text.Trim() != string.Empty && txtTotalSPCharge.Text.Trim() != string.Empty)
            {
                GetNetCharge();
            }
            else
            {
                txtOtherCharge.Text = "0.00";
            }
        }
        private void txtTotalSPCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalSPCharge.Text != string.Empty && txtOtherCharge.Text.Trim() != string.Empty && txtTotalSPCharge.Text.Trim() != string.Empty)
            {
                GetNetCharge();
            }
        }

        private void AddJobBill()
        {
            _oCSDJobBill = new CSDJobBill();
            int nMaxJobBillID = _oCSDJobBill.GetMaxBillID();
            string sNoOfZero = string.Empty;
            for (int i = nMaxJobBillID.ToString().Length; i < 4; i++)
            {
                sNoOfZero += "0";
            }
            _oCSDJobBill.BillNo = "B-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + "-" + sNoOfZero + nMaxJobBillID;
            _oCSDJobBill.JobID = ctlCSDJob1.SelectedJob.JobID;
            _oCSDJobBill.BillDate = DateTime.Today;
            _oCSDJobBill.MaterialCharge = Convert.ToDouble(txtTotalSPCharge.Text);
            _oCSDJobBill.ActualMatCharge = Convert.ToDouble(txtTotalSPCharge.Text);
            _oCSDJobBill.InspectionCharge = 0;
            _oCSDJobBill.ActualInsCharge = 0;
            _oCSDJobBill.ServiceCharge = 0;
            _oCSDJobBill.ActualSerCharge = 0;
            _oCSDJobBill.InstallationCharge = 0;
            _oCSDJobBill.ActualInstallationCharge = 0;
            _oCSDJobBill.OtherCharge = Convert.ToDouble(txtOtherCharge.Text);
            _oCSDJobBill.SCDiscount = Convert.ToDouble(txtDiscount.Text);
            _oCSDJobBill.SPDiscount = Convert.ToDouble(txtDiscount.Text);
            _oCSDJobBill.InTranportationCharge = 0;
            _oCSDJobBill.OutTranportationCharge = 0;
            _oCSDJobBill.TotalBill = Convert.ToDouble(txtNetSalePrice.Text);
            _oCSDJobBill.ReceivedAmount = Convert.ToDouble(txtReceiveAmount.Text);
            _oCSDJobBill.CurrentPayable = Convert.ToDouble(txtNetSalePrice.Text) - Convert.ToDouble(txtReceiveAmount.Text);
            if (_oCSDJobBill.CurrentPayable > 0)
            {
                _oCSDJobBill.BillStatus = (int)Dictionary.CSDBillStatus.Partial;
                _oCSDJobBill.IsPartsSale = (int)Dictionary.YesOrNoStatus.NO;
            }
            else if (_oCSDJobBill.CurrentPayable == 0)
            {
                _oCSDJobBill.BillStatus = (int)Dictionary.CSDBillStatus.Paid;
                _oCSDJobBill.IsPartsSale = (int)Dictionary.YesOrNoStatus.YES;
            }
            _oCSDJobBill.UserID = Utility.UserId;
            _oCSDJobBill.Remarks = txtRemarks.Text;
            _oCSDJobBill.AddPartsSale();
            //return _oCSDJobBill.BillID;

        }

        private void AddJobBillHistory(int nBillID)
        {
            _oCSDJobBillHistory = new CSDJobBillHistory();
             nBillID = _oCSDJobBill.BillID;
            _oCSDJobBillHistory.BillID = nBillID;
            _oCSDJobBillHistory.ReceiveableAmount = Convert.ToDouble(txtReceiveAmount.Text);
            _oCSDJobBillHistory.SCDiscount = Convert.ToDouble(txtDiscount.Text);
            _oCSDJobBillHistory.SPDiscount = Convert.ToDouble(txtDiscount.Text);
            _oCSDJobBillHistory.NetPayable = Convert.ToDouble(txtNetSalePrice.Text);
            _oCSDJobBillHistory.ReceiveAmount = Convert.ToDouble(txtReceiveAmount.Text);
            _oCSDJobBillHistory.ReceiveDate = DateTime.Now;
            _oCSDJobBillHistory.InstrumentType = (int)Dictionary.InstrumentType.CASH;
            _oCSDJobBillHistory.InstrumentDate = DateTime.Now;            
            _oCSDJobBillHistory.BankID = 0;           
            _oCSDJobBillHistory.BillRemarks = txtRemarks.Text;
            _oCSDJobBillHistory.InstrumentNo ="";
            _oCSDJobBillHistory.BillRemarks= "";
            //_oCSDJobBillHistory.MoneyReceiptNo = "";
            _oCSDJobBillHistory.IsPending = (int)Dictionary.YesOrNoStatus.NO;

            _oCSDJobBillHistorys = new CSDJobBillHistorys();
            _oCSDJobBillHistorys.Refresh();
            int nNoOfBillHis = _oCSDJobBillHistorys.Count;
            string sNoOfZeros = "";
            for (int i = _oCSDJobBillHistorys.Count.ToString().Length; i < 4; i++)
            {
                sNoOfZeros += "0";
            }
            _oCSDJobBillHistory.MoneyReceiptNo = "M-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + sNoOfZeros + (_oCSDJobBillHistorys.Count + 1);

            //if (_nType == 1)
            //{
            //    _oCSDJobBillHistory.IsPending = (int)Dictionary.YesOrNoStatus.YES;
            //}
            //else
            //{
            //    _oCSDJobBillHistory.IsPending = (int)Dictionary.YesOrNoStatus.NO;
            //}
            _oCSDJobBillHistory.Add();
        }

        private void InsertVAT63(int tranId,string tranNo)
        {
            DutyTranDetail dutyTranDetail = new DutyTranDetail();
            dutyTranDetail.GetCsdVatHead("SP");

            DutyTran oDutyTranVAT63 = new DutyTran();
            double _TotalAmount = 0;
            DateTime day = Convert.ToDateTime(DateTime.Now.Date);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);

            oDutyTranVAT63.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT63.WHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
            oDutyTranVAT63.ChallanTypeID = (int)Dictionary.ChallanType.VAT_63;
            oDutyTranVAT63.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT63.DocumentNo = tranNo;
            oDutyTranVAT63.RefID = tranId;
            oDutyTranVAT63.DutyTranTypeID = (int)Dictionary.DutyTranType.Service_CASH_SALE;
            oDutyTranVAT63.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_3;
            oDutyTranVAT63.VehicleNumber = txtVehicleNo.Text.Trim();
            int nDutyTranID = oDutyTranVAT63.InsertServiceVat(dutyTranDetail.ShortCode, Utility.JobLocation);
            if (nDutyTranID != 0)
            {
                
                    foreach (DataGridViewRow oItemRow in dgvPartSale.Rows)
                    {
                        if (oItemRow.Index < dgvPartSale.Rows.Count - 1)
                        {
                            DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                            oDutyTranDetail.DutyTranID = nDutyTranID;
                            oDutyTranDetail.ProductID = Convert.ToInt32(oItemRow.Cells[7].Value);
                            oDutyTranDetail.Qty = Convert.ToInt32(oItemRow.Cells[4].Value);
                            oDutyTranDetail.DutyRate = dutyTranDetail.DutyRate / 100;
                            oDutyTranDetail.DutyPrice = Math.Round(((Convert.ToDouble(oItemRow.Cells[6].Value) + Convert.ToDouble(oItemRow.Cells[9].Value) - Convert.ToDouble(oItemRow.Cells[10].Value)) / oDutyTranDetail.Qty) / (1 + oDutyTranDetail.DutyRate), 2, MidpointRounding.AwayFromZero);
                            oDutyTranDetail.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                            oDutyTranDetail.WHID = _Stores[cmbStore.SelectedIndex - 1].StoreID;
                            oDutyTranDetail.UnitPrice = Convert.ToDouble(oItemRow.Cells[6].Value) + Convert.ToDouble(oItemRow.Cells[9].Value) - Convert.ToDouble(oItemRow.Cells[10].Value);
                            oDutyTranDetail.VATType = dutyTranDetail.VATType;
                            oDutyTranDetail.InsertNewVATHO63();
                            _TotalAmount = _TotalAmount + oDutyTranDetail.VAT;
                        }
                    }
                
                
            }

            oDutyTranVAT63.Amount = _TotalAmount;
            oDutyTranVAT63.UpdateToatlVATAmountHO();

        }
      

        private void txtOtherCharge_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow oRow in dgvPartSale.Rows)
            {
                double _Amount ;
                double _RawFreightAmt;
                try
                {
                    _Amount = Convert.ToDouble(oRow.Cells[6].Value);
                }
                catch
                {
                    _Amount = 0;
                }
                if (_Amount > 0)
                {
                    if (Convert.ToDouble(txtOtherCharge.Text) > 0)
                    {
                        try
                        {
                            _RawFreightAmt = Convert.ToDouble(Convert.ToDouble(txtOtherCharge.Text) / Convert.ToDouble(txtTotalSPCharge.Text) * _Amount);
                        }
                        catch
                        {
                            _RawFreightAmt = 0;
                        }

                        try
                        {
                            oRow.Cells[9].Value = _RawFreightAmt.ToString();
                        }
                        catch
                        {
                            oRow.Cells[9].Value = 0;
                        }
                    }

                }

            }

        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow oRow in dgvPartSale.Rows)
            {
                double _Amount = 0;
                double _RawFreightAmt = 0;
                try
                {
                    _Amount = Convert.ToDouble(oRow.Cells[6].Value);
                }
                catch
                {
                    _Amount = 0;
                }
                if (_Amount > 0)
                {
                    if (Convert.ToDouble(txtDiscount.Text) > 0)
                    {
                        try
                        {
                            _RawFreightAmt = Convert.ToDouble(Convert.ToDouble(txtDiscount.Text) / Convert.ToDouble(txtTotalSPCharge.Text) * _Amount);
                        }
                        catch
                        {
                            _RawFreightAmt = 0;
                        }

                        try
                        {
                            oRow.Cells[10].Value = _RawFreightAmt.ToString();
                        }
                        catch
                        {
                            oRow.Cells[10].Value = 0;
                        }
                    }

                }

            }

        }
    }
    
}
