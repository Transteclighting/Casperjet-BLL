using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;



namespace CJ.Win
{
    public partial class frmSPReturnToSuplier : Form
    {
        SPTrans _oSPTrans;
        SparePartsRs _oSparePartsRs;
        CSDSparePartStock _oCSDSparePartStock;
        SPTranDetail _oSPTranDetail;
        SpareParts _oSpareParts;
        int nSPTranID = 0;
        int nSPToStoreID = 0;
        int nSupplierID = 0;

        SPTran _oSPTran;

        public frmSPReturnToSuplier()
        {
            InitializeComponent();
        }
        //public void ShowDialog(SPTran oSPTran)
        //{
        //    txtGRDNo.Text = oSPTran.TranNo;
        //    txtGRDNo.Enabled = false;
        //    DataLoadControl();
        //    this.ShowDialog();
        //}
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateUIControl()
        {
            if (txtGRDNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter GRD No", "GRD No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            bool validateDGV = false;
            foreach (DataGridViewRow oItemRow in dgvGDRIteams.Rows)
            {
                if (oItemRow.Index <= dgvGDRIteams.Rows.Count-1)
                {
                    if (oItemRow.Cells[4].Value != null)
                    {
                        if (Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim()) > Convert.ToInt32(oItemRow.Cells[2].Value.ToString().Trim()))
                        {
                            validateDGV = true;
                            if (Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim()) > Convert.ToInt32(oItemRow.Cells[3].Value.ToString().Trim()))
                            {
                                validateDGV = true;
                            }
                        }
                    }
                }
            }
            if (validateDGV) {
                MessageBox.Show("Please Check Return Quantity", "Return Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (ValidateUIControl())
            {
                DataLoadControl();
            }            
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oSPTrans = new SPTrans();

            DBController.Instance.OpenNewConnection();
            _oSPTrans.RefreshForGRD(Convert.ToDateTime("01-01-1990"), DateTime.Now, txtGRDNo.Text.Trim(), 0);


            foreach (SPTran oSPTran in _oSPTrans)
            {
                if (oSPTran.TranTypeID == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)
                {
                    nSPToStoreID = oSPTran.ToStoreID;
                    nSPTranID = oSPTran.SPTranID;
                    nSupplierID = oSPTran.SupplierID;
                    lblSupplierName.Text = oSPTran.SupplierName;
                    lblDate.Text = oSPTran.ReceiveDate.ToShortDateString();
                    lblStore.Text = oSPTran.ToStoreName;
                }
            }
            _oSparePartsRs = new SparePartsRs();
            _oSparePartsRs.GetGRDItem(nSPTranID);
            this.Text = "GRD Itemes | Total: " + "[" + _oSparePartsRs.Count + "]";
            dgvGDRIteams.Rows.Clear();
            foreach (SparePartsR oSparePartsR in _oSparePartsRs)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvGDRIteams);
                oRow.Cells[0].Value = oSparePartsR.Code;
                oRow.Cells[1].Value = oSparePartsR.Name;
                oRow.Cells[2].Value = oSparePartsR.Qty;
                oRow.Cells[3].Value = oSparePartsR.CurrentStock.ToString();
                oRow.Cells[5].Value = oSparePartsR.SparePartID.ToString();
                dgvGDRIteams.Rows.Add(oRow);
            }

        }

        private void frmSPReturnToSuplier_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIControl())
            {
                ReturnToSupplier();
                this.Close();
            }
        }
        private void ReturnToSupplier()
        {
            try
            {
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();
                //Add Spare Tran
                _oSPTran = new SPTran();
                _oSPTran.TranDate = DateTime.Today;
                _oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.ReturnToSuplier;
                _oSPTran.TranSide = (int)Dictionary.TranSide.OUT;
                _oSPTran.FromStoreID = nSPToStoreID;
                _oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
                _oSPTran.Remarks = txtRemarks.Text.Trim();
                _oSPTran.CreateDate = DateTime.Now;
                _oSPTran.CreateUserID = Utility.UserId;
                _oSPTran.SupplierID = nSupplierID;
                _oSPTran.RefTranID=nSPTranID;
                _oSPTran.Add();

                foreach (DataGridViewRow oItemRow in dgvGDRIteams.Rows)
                {
                    if (oItemRow.Index <= dgvGDRIteams.Rows.Count-1)
                    {
                        if (oItemRow.Cells[4].Value != null)
                        {
                            if (Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim())>0)
                            {
                                if (Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim()) <= Convert.ToInt32(oItemRow.Cells[2].Value.ToString().Trim()))
                                {
                                    if (Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim()) <= Convert.ToInt32(oItemRow.Cells[3].Value.ToString().Trim()))
                                    {
                                        //Deduct Stock
                                        _oCSDSparePartStock = new CSDSparePartStock();
                                        _oCSDSparePartStock.StoreID = nSPToStoreID;
                                        _oCSDSparePartStock.SparePartID = Convert.ToInt32(oItemRow.Cells[5].Value.ToString().Trim());
                                        _oCSDSparePartStock.CurrentStockQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                                        _oCSDSparePartStock.UpdateStock((int)Dictionary.YesOrNoStatus.NO);

                                        //Add Spare Tran Item                          
                                        _oSpareParts = new SpareParts();
                                        _oSpareParts.ID = _oCSDSparePartStock.SparePartID;
                                        _oSpareParts.RefreshBySPID();

                                        _oSPTranDetail = new SPTranDetail();
                                        _oSPTranDetail.SPTranID = _oSPTran.SPTranID;
                                        _oSPTranDetail.SparePartID = _oSpareParts.ID;
                                        _oSPTranDetail.Qty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                                        _oSPTranDetail.CostPrice = _oSpareParts.CostPrice;
                                        _oSPTranDetail.SalePrice = _oSpareParts.SalePrice;
                                        _oSPTranDetail.Add();
                                    }
                                }
                            }
                        }

                    }
                }

                DBController.Instance.CommitTran();
                MessageBox.Show("You Have Successfully Returned Spare Part To Supplier", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }



    }
}