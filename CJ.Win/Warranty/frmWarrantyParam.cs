using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Warranty;
using CJ.Class.POS;

namespace CJ.Win.Warranty
{

    public partial class frmWarrantyParam : Form
    {
        WarrantyParams _oWarrantyParams;
        WarrantyParam _oWarrantyParam;
        public bool _IsTrue = false;
        int nWarrantyparamID = 0;
        public frmWarrantyParam()
        {
            InitializeComponent();
        }
        private bool validateUIInput()
        {
            if (dtEffectDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Please select valid effetive date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSW.Focus();
                return false;
            }
            //if (Convert.ToInt32(txtSW.Text.Trim())!= Convert.ToInt32(nudServiceWarranty.Text.Trim()))
            //{
            //    MessageBox.Show("S.W not Grater/Less than Free Service Month", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSW.Focus();
            //    return false;
            //}
            //if (Convert.ToInt32(txtSPW.Text.Trim()) != Convert.ToInt32(nudSpareParts.Text.Trim()))
            //{
            //    MessageBox.Show("SP.W not Grater/Less than Spare Parts Month", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSPW.Focus();
            //    return false;
            //}
            //if (Convert.ToInt32(txtSCW.Text.Trim()) != Convert.ToInt32(nudSpecialComponent.Text.Trim()))
            //{
            //    MessageBox.Show(@"SC.W not Grater/Less than Special Component Month", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSCW.Focus();
            //    return false;
            //}
            //try
            //{
            //    Convert.ToInt32(txtMISCExpAmount.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("Please Enter Valid MISCExp Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtMISCExpAmount.Focus();
            //    return false;
            //}

            return true;
        }
        private void Save()
        {
                foreach (WarrantyParam oWarrantyParam in _oWarrantyParams)
                {
                    oWarrantyParam.ProductID = oWarrantyParam.ProductID;
                    oWarrantyParam.ServiceWarranty = Convert.ToInt32(nudServiceWarranty.Value.ToString());
                    oWarrantyParam.PartsWarranty = Convert.ToInt32(nudSpareParts.Value.ToString());
                    oWarrantyParam.SpecialComponentWarranty = Convert.ToInt32(nudSpecialComponent.Value.ToString());
                    oWarrantyParam.EffectDate = dtEffectDate.Value.Date;

                    if (rdoCardPrintYes.Checked == true)
                    {
                        oWarrantyParam.IsPrintWarrantyCard = (int)Dictionary.IsPrintWarrantyCard.Yes;
                    }
                    else
                    {
                        oWarrantyParam.IsPrintWarrantyCard = (int)Dictionary.IsPrintWarrantyCard.No;
                    }
                    if (rdoBarcodeStoreYes.Checked == true)
                    {
                        oWarrantyParam.IsStoreBarcode = (int)Dictionary.IsStoreBarcode.Yes;
                    }
                    else
                    {
                        oWarrantyParam.IsStoreBarcode = (int)Dictionary.IsStoreBarcode.No;
                    }

                    try
                    {
                        DBController.Instance.BeginNewTransaction();


                    foreach (DataGridViewRow oItemRow in dgvList.Rows)
                    {
                        if (Convert.ToInt32(oItemRow.Cells[dgvList.Columns[1].Index].Value) != 0 || Convert.ToInt32(oItemRow.Cells[dgvList.Columns[2].Index].Value) != 0 || Convert.ToInt32(oItemRow.Cells[dgvList.Columns[3].Index].Value) != 0)
                        {
                            if (oItemRow.Index < dgvList.Rows.Count)
                            {
                                WarrantyParamDetails oWarrantyParamDetails = new WarrantyParamDetails();
                                oWarrantyParamDetails.SupplierID = int.Parse(oItemRow.Cells[4].Value.ToString());
                                oWarrantyParamDetails.ServiceWarranty = int.Parse(oItemRow.Cells[1].Value.ToString());
                                oWarrantyParamDetails.SparePartsWarranty = int.Parse(oItemRow.Cells[2].Value.ToString());
                                oWarrantyParamDetails.SpecialComponentWarranty = int.Parse(oItemRow.Cells[3].Value.ToString());
                                oWarrantyParam.Add(oWarrantyParamDetails);

                            }
                        }                   
                    }

                        oWarrantyParam.UpdateIsCurrent();
                        oWarrantyParam.Add();
                    // Details for Warranty Param
                   
                    Showrooms _oShowrooms = new Showrooms();
                        _oShowrooms.Refresh();

                        foreach (Showroom oShowroom in _oShowrooms)
                        {
                            DataTran oDataTran = new DataTran();

                            oDataTran.TableName = "t_WarrantyParam";
                            oDataTran.DataID = oWarrantyParam.WarrantyParamID;
                            oDataTran.WarehouseID = oShowroom.WarehouseID;
                            oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTran.BatchNo = 0;

                            oDataTran.AddForTDPOS();
                        }

                        DBController.Instance.CommitTransaction();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void GetTotal()
        {
            txtSW.Text = "0";
            txtSPW.Text = "0.00";
            txtSCW.Text = "0";

            foreach (DataGridViewRow oRow in dgvList.Rows)
            {
                if (oRow.Cells[1].Value != null)
                {

                    txtSW.Text = Convert.ToDouble(Convert.ToDouble(txtSW.Text) + Convert.ToDouble(oRow.Cells[1].Value.ToString())).ToString();
                    txtSPW.Text = Convert.ToDouble(Convert.ToDouble(txtSPW.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString())).ToString();
                    txtSCW.Text = Convert.ToDouble(Convert.ToDouble(txtSCW.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();

                }
            }
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            if (nColumnIndex == 1)
            {
                if (dgvList.Rows[nRowIndex].Cells[1].Value.ToString() != null)
                {
                    try
                    {
                        dgvList.Rows[nRowIndex].Cells[1].Value = Convert.ToDouble(dgvList.Rows[nRowIndex].Cells[1].Value.ToString());
                        dgvList.Rows[nRowIndex].Cells[2].Value = Convert.ToDouble(dgvList.Rows[nRowIndex].Cells[2].Value.ToString());
                        dgvList.Rows[nRowIndex].Cells[3].Value = Convert.ToDouble(dgvList.Rows[nRowIndex].Cells[3].Value.ToString());
                    }
                    catch
                    {
                        //MessageBox.Show("");

                    }
                }
                
                //else if (dgvSecurity.Rows[nRowIndex].Cells[3].Value.ToString() != null)
                //{
                //    try
                //    {
                //        dgvSecurity.Rows[nRowIndex].Cells[3].Value = Convert.ToDouble(dgvSecurity.Rows[nRowIndex].Cells[3].Value.ToString());

                //    }
                //    catch
                //    {
                //        //MessageBox.Show("");

                //    }
                //}
                GetTotal();
            }
        }
        public void ShowDialog(WarrantyParams oWarrantyParams)
        {
            _oWarrantyParams = oWarrantyParams;

            if (_oWarrantyParams.Count == 1)
            {
                foreach (WarrantyParam oWarrantyParam in _oWarrantyParams)
                {
                    nudServiceWarranty.Value = Convert.ToInt32(oWarrantyParam.ServiceWarranty.ToString());
                    nudSpareParts.Value = Convert.ToInt32(oWarrantyParam.PartsWarranty.ToString());
                    nudSpecialComponent.Value = Convert.ToInt32(oWarrantyParam.SpecialComponentWarranty.ToString());
                    nWarrantyparamID = oWarrantyParam.WarrantyParamID;

                    if (oWarrantyParam.IsPrintWarrantyCard == 0)
                    {
                        rdoCardPrintNo.Checked = true;
                        rdoCardPrintYes.Checked = false;
                    }
                    else
                    {
                        rdoCardPrintNo.Checked = false;
                        rdoCardPrintYes.Checked = true;
                    }
                    if (oWarrantyParam.IsStoreBarcode == 0)
                    {
                        rdoBarcodeStoreNo.Checked = true;
                        rdoBarcodeStoreYes.Checked = false;
                    }
                    else
                    {
                        rdoBarcodeStoreNo.Checked = false;
                        rdoBarcodeStoreYes.Checked = true;
                    }
                }
            }
            else
            {
                nudServiceWarranty.Value = 0;
                nudSpareParts.Value = 0;
                nudSpecialComponent.Value = 0;
                rdoCardPrintYes.Checked = true;
                rdoCardPrintNo.Checked = false;
                rdoBarcodeStoreNo.Checked = false;
                rdoBarcodeStoreYes.Checked = true;
            }

            this.ShowDialog();
        }
        private void LoadSupplier()
        {
            WarrantyParams oWarrantyParams = new WarrantyParams();
            oWarrantyParams.RefreshBySupplier();
            foreach (WarrantyParamDetails oItem in oWarrantyParams)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvList);
                oRow.Cells[0].Value = oItem.SupplierName.ToString();
                oRow.Cells[1].Value = 0;
                oRow.Cells[2].Value = 0;
                oRow.Cells[3].Value = 0;
                oRow.Cells[4].Value = oItem.SupplierID;
                dgvList.Rows.Add(oRow);
            }
        }
        private void frmWarrantyParam_Load(object sender, EventArgs e)
        {
            dtEffectDate.MinDate = DateTime.Today;
            LoadSupplier();
        }
        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                if (dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value || String.IsNullOrWhiteSpace(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }

                refreshRow(e.RowIndex, e.ColumnIndex);
            }
            GetTotal();
        }

        private void dgvList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {            
            GetTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _IsTrue = true;
                this.Close();
            }            
        }
    }
}