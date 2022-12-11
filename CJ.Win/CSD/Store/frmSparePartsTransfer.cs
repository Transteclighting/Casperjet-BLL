using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Duty;

namespace CJ.Win.CSD.Store
{
    public partial class frmSparePartsTransfer : Form
    {
        Stores _oFromStores;
        Stores _oToStores;
        SPTran _oSPTran;
        SparePartsR _oSparePartsR;
        private DutyAccount _oDutyAccount;
        


        public frmSparePartsTransfer()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertVAT65(int nTranId, string sTranNo)
        {
            //DutyAccounts oDetail = new DutyAccounts();
            //oDetail.GetDutyDetailNew("Transfer", Convert.ToInt32(nTranId));

            double _TotalAmount_65_15 = 0;
            int countMUSHAK_65_15 = 0;
            
            DutyTran oDutyTranVAT65_15 = new DutyTran();
            DutyTranDetail dutyTranDetail = new DutyTranDetail();
            dutyTranDetail.GetCsdVatHead("SP");

            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {

                        if (countMUSHAK_65_15 == 0)
                        {

                            DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                            DateTime time = DateTime.Now;
                            DateTime combine = day.Add(time.TimeOfDay);
                            oDutyTranVAT65_15.DutyTranDate = Convert.ToDateTime(combine);
                            oDutyTranVAT65_15.WHID = _oFromStores[cmbFromStore.SelectedIndex - 1].StoreID;
                            oDutyTranVAT65_15.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                            oDutyTranVAT65_15.DocumentNo = sTranNo;
                            oDutyTranVAT65_15.RefID = nTranId;
                            oDutyTranVAT65_15.DutyTypeID = (int)Dictionary.DutyType.VAT;
                            oDutyTranVAT65_15.DutyTranTypeID = (int)Dictionary.DutyTranType.Service_TRANSFER;
                            oDutyTranVAT65_15.Remarks = txtRemarks.Text;
                            oDutyTranVAT65_15.DutyAccountID = (int) Dictionary.DutyAccountNew.MUSHAK_6_5;
                            oDutyTranVAT65_15.Amount = 0;
                            oDutyTranVAT65_15.VehicleNumber = txtVehicleNo.Text.Trim();
                            oDutyTranVAT65_15.InsertServiceVat("SP",Utility.JobLocation);
                            countMUSHAK_65_15++;
                        }

                        DutyTranDetail oItem = new DutyTranDetail();
                        oItem.DutyTranID = oDutyTranVAT65_15.DutyTranID;
                        oItem.ProductID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        
                        try
                        {
                            oItem.Qty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                        }
                        catch
                        {
                            oItem.Qty = Convert.ToInt32(0);
                        }
                        oItem.DutyRate = dutyTranDetail.DutyRate / 100;
                        oItem.DutyPrice = Math.Round(((Convert.ToDouble(oItemRow.Cells[6].Value)) / oItem.Qty) / (1 + oItem.DutyRate), 2, MidpointRounding.AwayFromZero); 
                        oItem.WHID = _oFromStores[cmbFromStore.SelectedIndex - 1].StoreID;
                        oItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim());
                        oItem.VAT = (oItem.DutyPrice * oItem.DutyRate) * oItem.Qty;
                        oItem.VATType = dutyTranDetail.VATType; 
                        _TotalAmount_65_15 = _TotalAmount_65_15 + oItem.VAT;
                        oItem.InsertNewVATHO63();
                }
            }


            oDutyTranVAT65_15.Amount = _TotalAmount_65_15;
            oDutyTranVAT65_15.UpdateToatlVATAmountHO();


            _oDutyAccount = new DutyAccount
            {
                DutyAccountTypeID = (int) Dictionary.DutyAccountNew.MUSHAK_6_5,
                Balance = _TotalAmount_65_15 + _TotalAmount_65_15
            };
            _oDutyAccount.UpdateBalance(true);

        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (ValidateUIControl())
            {
                Transfer();
                Close();
            }
        }
        private void Transfer()
        {
            
            try
            {
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();
                _oSPTran = new SPTran();
                _oSPTran.TranDate = dtTranferDate.Value.Date;
                _oSPTran.FromStoreID = _oFromStores[cmbFromStore.SelectedIndex - 1].StoreID;
                _oSPTran.ToStoreID = _oToStores[cmbToStore.SelectedIndex - 1].StoreID;                
                _oSPTran.TranSide = (int)Dictionary.SparePartTranSide.Other;
                _oSPTran.Remarks = txtRemarks.Text;
                _oSPTran.CreateUserID = Utility.UserId;
                _oSPTran.CreateDate = DateTime.Now;
                _oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.Transfer;

                double nNetAmt=0;
                foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
                {
                    if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
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
                        _oSPTran.Add(oItem);
                        nNetAmt += Convert.ToDouble(oItemRow.Cells[6].Value.ToString().Trim());
                        
                        CSDSparePartStock oCSDSparePartStock = new CSDSparePartStock();
                        oCSDSparePartStock.StoreID = _oToStores[cmbToStore.SelectedIndex-1].StoreID;
                        oCSDSparePartStock.SparePartID = oItem.SparePartID;
                        oCSDSparePartStock.CurrentStockQty = Convert.ToInt32(oItem.Qty);

                        //Stock In/Update Into Selected To Store
                        if (oCSDSparePartStock.CheckBySpID())
                        {                            
                            oCSDSparePartStock.UpdateStock((int)Dictionary.YesOrNoStatus.YES);                            
                        }
                        else
                        {                            
                            oCSDSparePartStock.Add();
                        }

                        //Stock Out From Selected From Store
                        oCSDSparePartStock.StoreID = _oToStores[cmbFromStore.SelectedIndex - 1].StoreID;
                        oCSDSparePartStock.UpdateStock((int)Dictionary.YesOrNoStatus.NO);  
                        
                    }
                }
                _oSPTran.NetAmount = nNetAmt;
                _oSPTran.Add();

                InsertVAT65(_oSPTran.SPTranID, _oSPTran.TranNo);

                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Transfered Spare Parts From Store " + cmbFromStore.Text + "To " + cmbToStore.Text, "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }
        private bool ValidateUIControl()
        {
            if (cmbFromStore.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select From Store", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFromStore.Focus();
                return false;
            }
            if (cmbToStore.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select To Store", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToStore.Focus();
                return false;
            }
            if (cmbFromStore.SelectedIndex == cmbToStore.SelectedIndex)
            {
                MessageBox.Show("Check From Store and To Store", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFromStore.Focus();
                return false;
            }
            return true;
        }
        private void frmSparePartsTransfer_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sSpareCode = "";

            if (nColumnIndex == 0 && dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString().Trim() != "")
            {
                if (cmbFromStore.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select From Store","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cmbFromStore.Focus();
                    return;
                }

                if (CheckDuplicateLineItem(dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString().Trim()) > 1)
                {
                    MessageBox.Show("Duplicate Parts Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvIssuePart.Rows.RemoveAt(nRowIndex);
                    return;
                }

                try
                {
                    sSpareCode = dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oSparePartsR = new SparePartsR();
                    _oSparePartsR.Code = sSpareCode;
                    _oSparePartsR.CheckSpareByCode(_oToStores[cmbFromStore.SelectedIndex-1].StoreID);

                    if (_oSparePartsR.Flag != false)
                    {
                        //dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oSparePartsR.Name;
                        //dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oSparePartsR.CurrentStock.ToString();
                        //dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oSparePartsR.SalePrice.ToString();
                        //dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (_oSparePartsR.SparePartID);
                        //dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = _oSparePartsR.CostPrice.ToString();


                        dgvIssuePart.Rows[nRowIndex].Cells[2].Value = _oSparePartsR.Name;

                        dgvIssuePart.Rows[nRowIndex].Cells[3].Value = _oSparePartsR.CurrentStock;
                        dgvIssuePart.Rows[nRowIndex].Cells[5].Value = _oSparePartsR.SalePrice;
                        dgvIssuePart.Rows[nRowIndex].Cells[7].Value = _oSparePartsR.SparePartID;
                        dgvIssuePart.Rows[nRowIndex].Cells[8].Value = _oSparePartsR.CostPrice;
        




                        //oRow.Cells[0].Value = oForm._oSparePartsR.Code;
                        //oRow.Cells[2].Value = oForm._oSparePartsR.Name;
                        //oRow.Cells[3].Value = oForm._oSparePartsR.CurrentStock;
                        //oRow.Cells[5].Value = oForm._oSparePartsR.SalePrice;
                        //oRow.Cells[7].Value = oForm._oSparePartsR.SparePartID;
                        //oRow.Cells[8].Value = oForm._oSparePartsR.CostPrice;

                    }
                    else
                    {
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        dgvIssuePart.Rows[nRowIndex].Cells[4].Value = 0;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = "";
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;

                        MessageBox.Show("Spare Part Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dgvRequisitionItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (nColumnIndex == 4) //(nColumnIndex == 5 || nColumnIndex == 4)
            {
                if (dgvIssuePart.Rows[nRowIndex].Cells[4].Value.ToString() != null && dgvIssuePart.Rows[nRowIndex].Cells[5].Value.ToString() != null)
                {
                    if (dgvIssuePart.Rows[nRowIndex].Cells[4].Value.ToString() != "" && dgvIssuePart.Rows[nRowIndex].Cells[5].Value.ToString() != "")
                    {
                        try
                        {
                            dgvIssuePart.Rows[nRowIndex].Cells[6].Value = (Convert.ToDouble(dgvIssuePart.Rows[nRowIndex].Cells[4].Value.ToString()) * Convert.ToDouble(dgvIssuePart.Rows[nRowIndex].Cells[5].Value.ToString()));

                        }
                        catch
                        {
                            MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                        }
                    }

                }
            }

        }
        private void LoadCombo()
        {
            //From Store
            _oFromStores = new Stores();
            _oFromStores.RefreshChildStore();
            cmbFromStore.Items.Clear();
            cmbFromStore.Items.Add("--Select Store--");
            foreach (Class.Store oStore in _oFromStores)
            {
                cmbFromStore.Items.Add(oStore.ChildSotre);
            }
            cmbFromStore.SelectedIndex = 0;

            //From Store
            _oToStores = new Stores();
            _oToStores.RefreshChildStore();
            cmbToStore.Items.Clear();
            cmbToStore.Items.Add("--Select Store--");
            foreach (Class.Store oStore in _oToStores)
            {
                cmbToStore.Items.Add(oStore.ChildSotre);
            }
            cmbToStore.SelectedIndex = 0;
        }
        private void dgvIssuePart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbFromStore.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select From Store", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int nStoreID;
            try
            {
                nStoreID = _oFromStores[cmbFromStore.SelectedIndex - 1].StoreID;
            }
            catch
            {
                nStoreID = 0;
            }

            if (e.ColumnIndex == 1)
            {
                frmSparePartSearchR oForm = new frmSparePartSearchR(nStoreID);
                oForm.ShowDialog();
                if (oForm._oSparePartsR != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvIssuePart);
                    oRow.Cells[0].Value = oForm._oSparePartsR.Code;
                    oRow.Cells[2].Value = oForm._oSparePartsR.Name;
                    oRow.Cells[3].Value = oForm._oSparePartsR.CurrentStock;
                    oRow.Cells[5].Value = oForm._oSparePartsR.SalePrice;
                    oRow.Cells[7].Value = oForm._oSparePartsR.SparePartID;
                    oRow.Cells[8].Value = oForm._oSparePartsR.CostPrice;

                    if (oForm._oSparePartsR != null)
                    {
                        int nRowIndex = dgvIssuePart.Rows.Add(oRow);

                        if (CheckDuplicateLineItem(dgvIssuePart.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvIssuePart.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvIssuePart.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }
            }
        }
        private int CheckDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
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
        private void dgvIssuePart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                RefreshRow(e.RowIndex, e.ColumnIndex);
            }
        }
    }
}