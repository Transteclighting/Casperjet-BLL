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
    public partial class frmPartsIssueToJob : Form
    {
        SparePartsR _oSparePartsR;
        SPTran oSPTran;
        SPStock oSPStock;
        Technicians _oTechnicians;
        Stores _oStores;

        SPTrans _oSPTrans;
        CSDSparePartStock _oCSDSparePartStock;

        int _nSPTranID = 0;
        int _UIControl = 0;
        int nSelectedStoreID = 0;
        bool _bIsEditMode = false;
        int nSpareUser_WHID = 0;

        public frmPartsIssueToJob(int UIControl)
        {
            InitializeComponent();
            _UIControl = UIControl;
        }

        private void frmSparePartsReceive_Load(object sender, EventArgs e)
        {
            if (_UIControl == 1)
            {
                LoadCombos();
                ctlJobAll1.Visible = true;
                lblJobNo.Text = "Job Number";
                cmbTechnician.Visible = false;
                cmbBranch.Visible = false;
                this.Text = "Parts Issue to Job";
            }
            else if (_UIControl == 2)
            {
                LoadCombos();
                ctlJobAll1.Visible = false;
                lblJobNo.Text = "Technician Name";
                cmbTechnician.Visible = true;
                cmbBranch.Visible = false;
                this.Text = "Parts Issue to Technician";
            }
            else
            {
                LoadCombos();
                ctlJobAll1.Visible = false;
                lblJobNo.Text = "Branch Name";
                cmbTechnician.Visible = false;
                cmbBranch.Visible = true;
                this.Text = "Parts Issue to Branch";
            }
        }

        private void LoadCombos()
        {
            if (_UIControl == 2)
            {
                //Technician
                _oTechnicians = new Technicians();
                _oTechnicians.GetTechnician();
                cmbTechnician.Items.Add("<Select Technician>");
                foreach (Technician oTechnician in _oTechnicians)
                {
                    cmbTechnician.Items.Add(oTechnician.Name);
                }
                if (_oTechnicians.Count > 0)
                {
                    cmbTechnician.SelectedIndex = 0;
                }
            }
            else if (_UIControl == 3)
            {
                //Branch

                //_oStores = new Stores();
                //_oStores.GetBranch();
                //cmbBranch.Items.Add("<Select Branch>");
                //foreach (Store oStore in _oStores)
                //{
                //    cmbBranch.Items.Add(oStore.StoreName);
                //}
                //if (_oStores.Count > 0)
                //{
                //    cmbBranch.SelectedIndex = 0;
                //}
            }

            _oStores = new Stores();
            _oStores.RefreshChildStore();
            cmbStore.Items.Clear();
            cmbStore.Items.Add("<Select Store>");
            foreach (Store oStore in _oStores)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oStore.ChildSotre;
                //item.Value = oStore.StoreID.ToString();
                //cmbStore.Items.Add(item);
                cmbStore.Items.Add(oStore.ChildSotre);
            }
            cmbStore.SelectedIndex = 0;

        }

        private int PreviousIssuePartsAgaintsJob()
        {
            int nCount = 0;
            int nFromStoreID = 0;
            _oSPTrans = new SPTrans();

            lvwSPIssues.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oSPTrans.GetIssuePartsByJobID(ctlJobAll1.SelectedJob.JobID);
            foreach (SPTran oSPTran in _oSPTrans)
            {
                if (oSPTran.TranSide != 1)
                {
                    ListViewItem oItem = lvwSPIssues.Items.Add(oSPTran.PartCode.ToString());
                    oItem.SubItems.Add(oSPTran.PartName);
                    oItem.SubItems.Add(oSPTran.Qty.ToString());
                    oItem.SubItems.Add(oSPTran.TotalPrice.ToString());
                    oItem.SubItems.Add(oSPTran.TranDate.ToShortDateString());
                    oItem.Tag = oSPTran;

                    if (nCount == 0)
                    {
                        nFromStoreID = oSPTran.FromStoreID;
                        nCount++;
                    }
                }

                SPStock aSpStock = new SPStock();
                aSpStock.SparePartID = oSPTran.SparePartID;
                aSpStock.StoreID = (int)Dictionary.Store.CentralSoundStore;
                aSpStock.CurrentStockQty = 0;
                aSpStock.CheckStockBySpareID();
                if (!aSpStock.Flag)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        aSpStock.Add();
                        DBController.Instance.CommitTran();
                    }
                    catch
                    { }
                }

            }
            if (_oSPTrans.Count > 0)
            {
                btnEdit.Enabled = true;
            }

            return nFromStoreID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvIssuePart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbStore.SelectedIndex == 0 && _bIsEditMode == false)
            {
                MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                nSelectedStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
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

                        if (checkDuplicateLineItem(dgvIssuePart.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
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

            if (e.ColumnIndex == 12)
            {
                dgvIssuePart.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
                {
                    if (Convert.ToBoolean(oItemRow.Cells[12].Value))
                    {
                        oItemRow.Cells[13].ReadOnly = false;
                        oItemRow.Cells[13].Style.BackColor = Color.White;
                    }
                    else
                    {
                        oItemRow.Cells[13].ReadOnly = true;
                        oItemRow.Cells[13].Style.BackColor = ColorTranslator.FromHtml("#E0E0E0");
                        oItemRow.Cells[13].Value = string.Empty;
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


            if (nColumnIndex == 0 && dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (cmbStore.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStore.Focus();
                    dgvIssuePart.Rows.RemoveAt(nRowIndex);
                    return;
                }
                if (checkDuplicateLineItem(dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
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
                    _oSparePartsR.CheckSpareByCode(_oStores[cmbStore.SelectedIndex - 1].StoreID);

                    if (_oSparePartsR.Flag != false)
                    {

                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oSparePartsR.Name;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = Convert.ToString(_oSparePartsR.CurrentStock);
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oSparePartsR.SalePrice;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (_oSparePartsR.SparePartID).ToString();
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = _oSparePartsR.CostPrice;

                    }
                    else
                    {
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = "";
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;

                        MessageBox.Show("Spare Part Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvIssuePart.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (nColumnIndex == 4)
            {
                if (dgvIssuePart.Rows[nRowIndex].Cells[4].Value.ToString() != "" && dgvIssuePart.Rows[nRowIndex].Cells[4].Value != null)
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

                    GetUISPStockData(false);
                    if (_UIControl == 1)
                    {
                        UpdateSpartToJob(ctlJobAll1.SelectedJob.JobID);
                    }
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

        public SPTran GetUISPTranData(SPTran oSPTran)
        {
            if (_UIControl == 1)
            {
                oSPTran.JobID = ctlJobAll1.SelectedJob.JobID;
                oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.IssueAgainstJob;

                oSPTran.FromStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
            }
            else if (_UIControl == 2)
            {
                _oTechnicians = new Technicians();
                _oTechnicians.GetTechnician();
                oSPTran.TechnicianID = _oTechnicians[cmbTechnician.SelectedIndex - 1].TechnicianID;
                oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.AdvanceIssueToTechnician;
                
                oSPTran.FromStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
            }
            else
            {
                //_oStores = new Stores();
                //_oStores.GetBranch();
                //oSPTran.ToStoreID = _oStores[cmbBranch.SelectedIndex - 1].StoreID;
                //oSPTran.ParentStoreID = _oStores[cmbBranch.SelectedIndex - 1].StoreID;
                //oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.IssueToBranch;
            }
            oSPTran.TranSide = (int)Dictionary.SparePartTranSide.OUT;
            //if (_bIsEditMode == false)
            //{
            //    oSPTran.FromStoreID = Convert.ToInt32((cmbStore.SelectedItem as ComboboxItem).Value.ToString());
            //}

            //if (_UIControl != 3)
            //{
            //    oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
            //}
            oSPTran.Remarks = txtRemarks.Text;
            oSPTran.IsWarrantyValid = (int)Dictionary.CSDIsWarantyValid.No;

            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    long nQty = 0;
                    try
                    {
                        nQty = Convert.ToInt64(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch {}

                    if (nQty > 0)
                    {
                        SPTranDetail oItem = new SPTranDetail();

                        oItem.Qty = nQty;

                        oItem.SalePrice = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim());
                        oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        oItem.CostPrice = Convert.ToDouble(oItemRow.Cells[8].Value.ToString().Trim());

                        oSPTran.Add(oItem);
                    }
                }
            }

            return oSPTran;
        }

        public SPTran GetUISPTranDataEdit(SPTran oSPTran)
        {
            if (_UIControl == 1)
            {
                oSPTran.JobID = ctlJobAll1.SelectedJob.JobID;
                oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.IssueAgainstJob;

                oSPTran.FromStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
            }
            else if (_UIControl == 2)
            {
                _oTechnicians = new Technicians();
                _oTechnicians.GetTechnician();
                oSPTran.TechnicianID = _oTechnicians[cmbTechnician.SelectedIndex - 1].TechnicianID;
                oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.AdvanceIssueToTechnician;
            }
            else
            {
                //_oStores = new Stores();
                //_oStores.GetBranch();
                //oSPTran.ToStoreID = _oStores[cmbBranch.SelectedIndex - 1].StoreID;
                //oSPTran.ParentStoreID = _oStores[cmbBranch.SelectedIndex - 1].StoreID;
                //oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.IssueToBranch;
            }
            oSPTran.TranSide = (int)Dictionary.SparePartTranSide.OUT;

            oSPTran.Remarks = txtRemarks.Text;
            oSPTran.IsWarrantyValid = (int)Dictionary.CSDIsWarantyValid.No;

            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    int nQty = 0;
                    int nPreviousQty = 0;
                    int nSparePartID = 0;

                    try
                    {
                        nQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch {}
                    try
                    {
                        nPreviousQty = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());
                    }
                    catch {}
                    try
                    {
                        nSparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                    }
                    catch {}

                    if (nQty > nPreviousQty)
                    {
                        SPTranDetail oItem = new SPTranDetail();

                        oItem.Qty = nQty - nPreviousQty;
                        oItem.SalePrice = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim());
                        oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        oItem.CostPrice = Convert.ToDouble(oItemRow.Cells[8].Value.ToString().Trim());

                        oSPTran.Add(oItem);
                    }
                }
            }

            return oSPTran;
        }

        public bool ReturnItemCheck()
        {
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    int nQty = 0;
                    int nPreviousQty = 0;
                    int nTranID = 0;

                    try
                    {
                        nQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch {}
                    try
                    {
                        nPreviousQty = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());
                    }
                    catch {}
                    try
                    {
                        nTranID = Convert.ToInt32(oItemRow.Cells[11].Value.ToString().Trim());
                    }
                    catch {}

                    //if (nTranID != 0)
                    {
                        if (nQty < nPreviousQty)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IssueItemCheck()
        {
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    int nQty = 0;
                    int nPreviousQty = 0;

                    try
                    {
                        nQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch {}
                    try
                    {
                        nPreviousQty = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());
                    }
                    catch { }

                    if (nQty > nPreviousQty)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public SPTran GetUISPReturnData(SPTran oSPTran)
        {
            if (_UIControl == 1)
            {
                oSPTran.JobID = ctlJobAll1.SelectedJob.JobID;
                oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.ReturnFromJob;

                if (_bIsEditMode == false)
                {
                    oSPTran.FromStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                    oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
                }
                else
                {
                    oSPTran.FromStoreID = (int)Dictionary.Store.SystemStore;
                    oSPTran.ToStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                }
            }
            else if (_UIControl == 2)
            {
                _oTechnicians = new Technicians();
                _oTechnicians.GetTechnician();
                oSPTran.TechnicianID = _oTechnicians[cmbTechnician.SelectedIndex - 1].TechnicianID;
                oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.RetrunFormTechnician;

                if (_bIsEditMode == false)
                {
                    oSPTran.FromStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                    oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
                }
                else
                {
                    oSPTran.FromStoreID = (int)Dictionary.Store.SystemStore;
                    oSPTran.ToStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                }
            }
            else
            {
                //_oStores = new Stores();
                //_oStores.GetBranch();
                //oSPTran.ToStoreID = _oStores[cmbBranch.SelectedIndex - 1].StoreID;
                //oSPTran.ParentStoreID = _oStores[cmbBranch.SelectedIndex - 1].StoreID;
                //oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.ReturnFromBranch;
            }
            oSPTran.TranSide = (int)Dictionary.SparePartTranSide.IN;
            if (_bIsEditMode == false)
            {
                oSPTran.FromStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
            }

            if (_UIControl != 3)
            {
                //oSPTran.FromStoreID = _oStores[cmbBranch.SelectedIndex - 1].StoreID;
                //oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
            }
            oSPTran.Remarks = txtRemarks.Text;
            oSPTran.IsWarrantyValid = (int)Dictionary.CSDIsWarantyValid.No;

            //foreach (SPTran _oSPTran in _oSPTrans)
            //{
            //    if (_oSPTran.Qty > 0)
            //    {
            //        SPTranDetail oItem = new SPTranDetail();

            //        oItem.Qty = _oSPTran.Qty;
            //        oItem.SparePartID = _oSPTran.SparePartID;

            //        oSPStock = new SPStock();
            //        oSPStock.SparePartID = _oSPTran.SparePartID;
            //        oSPStock.StoreID = _oSPTran.FromStoreID;
            //        oSPStock.CheckStockBySpareID();

            //        oItem.SalePrice = oSPStock.SalePrice;
            //        oItem.CostPrice = oSPStock.CostPrice;

            //        oSPTran.Add(oItem);
            //    }
            //}

            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    int nQty = 0;
                    int nPreviousQty = 0;
                    int nTranID = 0;
                    int nSparePartID = 0;

                    try
                    {
                        nQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                    } catch  {}
                    try
                    {
                        nPreviousQty = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());
                    }
                    catch { }
                    try
                    {
                        nTranID = Convert.ToInt32(oItemRow.Cells[11].Value.ToString().Trim());
                    }
                    catch { }
                    try
                    {
                        nSparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                    }
                    catch { }

                    //if (nTranID != 0)
                    {
                        if (nQty < nPreviousQty)
                        {
                            SPTranDetail oItem = new SPTranDetail();

                            oItem.Qty = nPreviousQty - nQty;
                            oItem.SparePartID = nSparePartID;
                            
                            oSPStock = new SPStock();
                            oSPStock.SparePartID = nSparePartID;
                            oSPStock.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                            oSPStock.CheckStockBySpareID();

                            //if (!oSPStock.Flag)
                            //{
                            //    try
                            //    {
                            //        oSPStock.CurrentStockQty = 0;
                            //        oSPStock.Add();
                            //    }
                            //    catch { }
                            //}  

                            oItem.SalePrice = oSPStock.SalePrice;
                            oItem.CostPrice = oSPStock.CostPrice;

                            oSPTran.Add(oItem);
                        }
                    }
                }
            }

            return oSPTran;
        }

        private void GetUISPStockData(bool _bFlag)
        {
            //oSPTran.JobID = ctlJobAll1.SelectedJob.JobID;

            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    //_Stores
                    int nStockQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                    if (nStockQty > 0)
                    {
                        SPStock oItem = new SPStock();
                        oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        oItem.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                        oItem.CheckStockBySpareID();

                        //if (!oItem.Flag)
                        //{
                        //    oItem.CurrentStockQty = 0;
                        //    try
                        //    {
                        //        oItem.Add();
                        //    }
                        //    catch
                        //    { }
                        //}

                        try
                        {
                            oItem.AddDeductStockQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            oItem.AddDeductStockQty = 0;
                        }


                        oItem.UpdateStock(_bFlag);
                    }
                }
            }
        }

        private void GetUISPStockDataEdit(SPTran oSPTran, bool _bFlag)
        {
            //oSPTran.JobID = ctlJobAll1.SelectedJob.JobID;

            foreach (SPTranDetail oSPTranDetail in oSPTran)
            {
                //if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    //_Stores
                    int nQty = Convert.ToInt32(oSPTranDetail.Qty);
                    if (nQty > 0)
                    {
                        SPStock oItem = new SPStock();
                        oItem.SparePartID = oSPTranDetail.SparePartID;
                        oItem.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                        oItem.CheckStockBySpareID();
                        //if (!oItem.Flag)
                        //{
                        //    oItem.CurrentStockQty = 0;
                        //    try
                        //    {
                        //        oItem.Add();
                        //    }
                        //    catch
                        //    { }
                        //}

                        try
                        {
                            oItem.AddDeductStockQty = nQty;
                        }
                        catch (Exception ex)
                        {
                            oItem.AddDeductStockQty = 0;
                        }


                        oItem.UpdateStock(_bFlag);
                    }
                }
            }
        }

        private void GetUISPStockReverseData(SPTran oSPTran, bool _bFlag)
        {
            //oSPTran.JobID = ctlJobAll1.SelectedJob.JobID;
            foreach (SPTranDetail _oSPTranDetail in oSPTran)
            {
                if (_oSPTranDetail.Qty > 0)
                {
                    SPStock oItem = new SPStock();
                    oItem.SparePartID = _oSPTranDetail.SparePartID;
                    oItem.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                    
                    
                    //oItem.CheckStockBySpareID();
                    //if (oItem == null)
                    //{
                    //    oItem.CurrentStockQty = 0;
                    //    oItem.Add();
                    //}
                    
                    oItem.AddDeductStockQty = Convert.ToInt32(_oSPTranDetail.Qty);
                    oItem.UpdateStock(_bFlag);
                }
            }

            //foreach (SPTran _oSPTran in _oSPTrans)
            //{
            //    if (_oSPTran.Qty > 0)
            //    {
            //        SPStock oItem = new SPStock();

            //        oItem.AddDeductStockQty = _oSPTran.Qty;
            //        oItem.SparePartID = _oSPTran.SparePartID;
            //        oItem.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;

            //        oItem.UpdateStock(_bFlag);
            //    }
            //}

        }

        private void UpdateSpartToJob(int nJobID)
        {
            SPTranDetail _oSPTranDetail = new SPTranDetail();
            if (_bIsEditMode)
                _oSPTranDetail.DeleteUseParts(nJobID);

            CSDJob oCSDJob = new CSDJob();
            oCSDJob.UpdateSparePartUse(nJobID, false);
            int nCount = 0;
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {

                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    int nQty = 0;
                    try
                    {
                        nQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch {}

                    if (nQty > 0)
                    {
                        _oSPTranDetail.Qty = nQty;
                        _oSPTranDetail.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        _oSPTranDetail.CostPrice = Convert.ToDouble(oItemRow.Cells[8].Value.ToString().Trim());
                        _oSPTranDetail.SalePrice = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim());
                        if (_oSPTranDetail.CheckSpareParts(nJobID, _oSPTranDetail.SparePartID))
                        {
                            _oSPTranDetail.UpdateUseParts(nJobID, _bIsEditMode);
                        }
                        else
                        {
                            _oSPTranDetail.InsertPartsToJob(nJobID);
                        }
                        nCount++;
                    }
                }
            }
            if (nCount != 0)
            {
                oCSDJob.UpdateSparePartUse(nJobID, true);
            }
            else
            {
                oCSDJob.UpdateSparePartUse(nJobID, false);
            }
        }
        private void Clear()
        {
            DBController.Instance.OpenNewConnection();
            dgvIssuePart.Rows.Clear();
            lvwSPIssues.Items.Clear();
            ctlJobAll1.txtCode.Text = string.Empty;
            LoadCombos();
            cmbStore.Enabled = true;
            ctlJobAll1.Enabled = true;
            txtRemarks.Text = string.Empty;
        }

        private bool validateUIInput()
        {
            #region Transaction Master Information Validation
            if (_UIControl == 1)
            {
                if (ctlJobAll1.SelectedJob == null || ctlJobAll1.txtCode.Text == "")
                {
                    MessageBox.Show("Please Select Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlJobAll1.Focus();
                    return false;
                }
            }
            else if (_UIControl == 2)
            {
                if (cmbTechnician.Text == null || cmbTechnician.Text == "<Select Technician>")
                {
                    MessageBox.Show("Please Select Technician", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTechnician.Focus();
                    return false;
                }
            }
            else
            {
                if (cmbBranch.Text == null || cmbBranch.Text == "<Select Branch>")
                {
                    MessageBox.Show("Please Select Branch", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBranch.Focus();
                    return false;
                }
            }

            #endregion

            #region Transaction Details Information Validation

            if (dgvIssuePart.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Spare Parts ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
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
                    // For edit mode if qty zeor the row should remove
                    if (!_bIsEditMode)
                    {
                        if (oItemRow.Cells[4].Value == null || int.Parse(oItemRow.Cells[4].Value.ToString()) <= 0)
                        {
                            MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    oSPStock = new SPStock();
                    oSPStock.SparePartID = int.Parse(oItemRow.Cells[7].Value.ToString());
                    //oSPStock.StoreID = Convert.ToInt32((cmbStore.SelectedItem as ComboboxItem).Value.ToString());
                    oSPStock.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                    oSPStock.CheckStockBySpareID();
                    if (!_bIsEditMode)
                    {
                        if (oSPStock.CurrentStockQty < int.Parse(oItemRow.Cells[4].Value.ToString()))
                        {
                            MessageBox.Show("Issue Qty must be less or equal to current Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        if(Convert.ToBoolean(oItemRow.Cells[12].Value) && oItemRow.Cells[13].Value != null)
                        {
                            if (Convert.ToDouble(oItemRow.Cells[13].Value)
                                > Convert.ToDouble(oItemRow.Cells[3].Value) + Convert.ToDouble(oItemRow.Cells[13].Value)
                                ||
                                Convert.ToDouble(oItemRow.Cells[13].Value) 
                                > Convert.ToDouble(oItemRow.Cells[10].Value)
                                )
                            {
                                MessageBox.Show("USP Quantity Must Be Less Than Or Equal To Current Stock & Previously Issued Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false; 
                            }
                            
                        }
                        else if (Convert.ToBoolean(oItemRow.Cells[12].Value) && oItemRow.Cells[13].Value == null)
                        {
                            MessageBox.Show("Please Enter USP Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false; 
                        }
                    }


                }
            }
            #endregion
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                if (_bIsEditMode)
                {
                    Edit();
                }
                else
                {
                    Save();
                }
                Clear();
                if (_bIsEditMode)
                {
                    _bIsEditMode = false;
                }
                this.Close();
            }
        }
        private bool IsSpIssueAbleJob(CSDJob oCSDJob)
        { 
            if (oCSDJob.Status == (int)Dictionary.JobStatus.WalkinJobCreated ||
              oCSDJob.Status == (int)Dictionary.JobStatus.HomecallJobCreated ||
              oCSDJob.Status == (int)Dictionary.JobStatus.InstallationJobCreated ||
              oCSDJob.Status == (int)Dictionary.JobStatus.Cancel ||
              oCSDJob.Status == (int)Dictionary.JobStatus.Return ||
              oCSDJob.Status == (int)Dictionary.JobStatus.Replace ||
              oCSDJob.Status == (int)Dictionary.JobStatus.ServiceProvided ||
              oCSDJob.Status == (int)Dictionary.JobStatus.ReturnFromCustomer ||
              oCSDJob.Status == (int)Dictionary.JobStatus.Delivered ||
              oCSDJob.Status == (int)Dictionary.JobStatus.Repaired ||
              oCSDJob.Status == (int)Dictionary.JobStatus.TransportRequired ||
              oCSDJob.Status == (int)Dictionary.JobStatus.ConvertedFromHomeCall ||
              oCSDJob.Status == (int)Dictionary.JobStatus.ReadyForTest ||
              oCSDJob.Status == (int)Dictionary.JobStatus.ReadyForDelivery ||
              oCSDJob.IsDelivered == (int)Dictionary.YesOrNoStatus.YES ||
              (oCSDJob.OwnOrOtherTechnician == (int)Dictionary.OwnOrOtherTechnician.ThirdParty_Technician && oCSDJob.JobType == (int)Dictionary.CSDJobType.Paid) ||
              ctlJobAll1.SelectedJob.AssignTo == 0
              )
            {
                MessageBox.Show("You Can't Isuue Part Against This Job", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlJobAll1.txtCode.Focus();
                return false;
            }
            return true;
        }
        private int checkDuplicateLineItem(string ItemCode)
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

        private void ctlCSDJob1_Load(object sender, EventArgs e)
        {

        }

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void ctlJobAll1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlJobAll1.txtDescription.Text != string.Empty)
            {
                nSpareUser_WHID = PreviousIssuePartsAgaintsJob();
                if (nSpareUser_WHID != 0)
                {
                    int Index = _oStores.GetIndex(nSpareUser_WHID);
                    cmbStore.SelectedIndex = Index + 1;
                    cmbStore.Enabled = false;
                }
                else
                {
                    cmbStore.Enabled = true;
                    cmbStore.SelectedIndex = 0;
                }
                if (!IsSpIssueAbleJob(ctlJobAll1.SelectedJob))
                {
                    ctlJobAll1.txtCode.Text = string.Empty;
                    dgvIssuePart.Rows.Clear();
                    lvwSPIssues.Items.Clear();
                }
            }
            else
            {
                dgvIssuePart.Rows.Clear();
                lvwSPIssues.Items.Clear();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ctlJobAll1.txtDescription.Text != string.Empty)
            {
                _bIsEditMode = true;
                ctlJobAll1.Enabled = false;
                cmbStore.Enabled = false;
                btnIssue.Text = "Save";
                btnEdit.Enabled = false;
                dgvIssuePart.AllowUserToDeleteRows = false;
                LoadPreviousPartsInGrid();
            }
            else if (cmbTechnician.Text != string.Empty)
            {
                _bIsEditMode = true;
                ctlJobAll1.Enabled = false;
                cmbStore.Enabled = false;
                btnIssue.Text = "Save";
                btnEdit.Enabled = false;
                dgvIssuePart.AllowUserToDeleteRows = false;
                LoadPreviousPartsInGrid();
            }
            else
            {
                lvwSPIssues.Items.Clear();
            }
        }

        private void LoadPreviousPartsInGrid()
        {

            int nFromStoreID = 0;
            dgvIssuePart.Rows.Clear();
            foreach (SPTran oSPTran in _oSPTrans)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvIssuePart);
                oRow.Cells[0].Value = oSPTran.PartCode;
                oRow.Cells[2].Value = oSPTran.PartName;
                oRow.Cells[4].Value = oSPTran.Qty.ToString();
                oRow.Cells[9].Value = oSPTran.FromStoreID.ToString();
                oRow.Cells[10].Value = oSPTran.Qty.ToString();
                _nSPTranID = oSPTran.SPTranID;
                oRow.Cells[11].Value = oSPTran.SPTranID.ToString();
                oRow.Cells[7].Value = oSPTran.SparePartID.ToString();
                if (nFromStoreID == 0)
                {
                    nFromStoreID = oSPTran.FromStoreID;
                }
                oSPStock = new SPStock();
                oSPStock.SparePartID = oSPTran.SparePartID;
                oSPStock.StoreID = oSPTran.FromStoreID;
                oSPStock.CheckStockBySpareID();

                oRow.Cells[3].Value = oSPStock.CurrentStockQty.ToString();
                oRow.Cells[5].Value = oSPStock.SalePrice.ToString();
                oRow.Cells[8].Value = oSPStock.CostPrice.ToString();
                oRow.Cells[6].Value = (oSPStock.SalePrice * oSPTran.Qty).ToString();
                dgvIssuePart.Columns["chkIsUSP"].Visible = true;
                dgvIssuePart.Columns["colUSPQty"].Visible = true;
                dgvIssuePart.Rows.Add(oRow);
            }

            //cmbStore.Items.Clear();
            //Store oStore = new Store();
            //oStore.GetParentID(nFromStoreID);
            //ComboboxItem item = new ComboboxItem();
            //item.Text = oStore.ParentSotre;
            //item.Value = oStore.StoreID.ToString();
            //cmbStore.Items.Add(item);
            //cmbStore.SelectedIndex = 0;

            _oStores = new Stores();
            _oStores.RefreshChildStore();
            cmbStore.Items.Clear();
            cmbStore.Items.Add("<Select Store>");
            foreach (Store oStore in _oStores)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oStore.ChildSotre;
                //item.Value = oStore.StoreID.ToString();
                cmbStore.Items.Add(oStore.ChildSotre);
            }

            cmbStore.SelectedIndex = _oStores.GetIndex(nFromStoreID) + 1;
        }

        private void Edit()
        {
            try
            {
                int nCount = 0;

                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();

                if (ReturnItemCheck())
                {
                    oSPTran = new SPTran();
                    oSPTran = GetUISPReturnData(oSPTran);
                    oSPTran.Add();
                    GetUISPStockReverseData(oSPTran, true);
                }

                if (IssueItemCheck())
                {
                    oSPTran = new SPTran();
                    oSPTran = GetUISPTranDataEdit(oSPTran);
                    oSPTran.Add();
                    GetUISPStockDataEdit(oSPTran, false);
                }
                if (_UIControl == 1)
                {
                    UpdateSpartToJob(ctlJobAll1.SelectedJob.JobID);
                    AddUnusualSparePart();
                }
                

                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Edited, Tran# " + oSPTran.TranNo + "", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private void AddUnusualSparePart()
        {
            int haveUSP = 0; 
            SPTran aSPTran = new SPTran();
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    if (Convert.ToBoolean(oItemRow.Cells[12].Value))
                    {
                        ++haveUSP;
                        break;
                    }
                }
            }
            if (haveUSP != 0)
            {                
                aSPTran.TranDate = DateTime.Today;
                aSPTran.TranTypeID = (int)Dictionary.SparePartTranType.ReturnDefectiveSpare;
                aSPTran.TranSide = (int)Dictionary.TranSide.OUT;
                aSPTran.JobID = ctlJobAll1.SelectedJob.JobID;
                aSPTran.TechnicianID = ctlJobAll1.SelectedJob.AssignTo;
                aSPTran.Remarks = txtRemarks.Text.Trim();
                aSPTran.CreateUserID = Utility.UserId;
                aSPTran.CreateDate = DateTime.Now;
                aSPTran.FromStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                aSPTran.ToStoreID = 4;//4=Defective Store
                aSPTran.RefTranID = oSPTran.SPTranID;
                aSPTran.Add();

                foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
                {
                    if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                    {
                        if (Convert.ToBoolean(oItemRow.Cells[12].Value))
                        {
                            //Tran Item
                            CSDSPTranItem oCSDSPTranItem = new CSDSPTranItem();
                            oCSDSPTranItem.SPTranID = aSPTran.SPTranID; //oSPTran.SPTranID = RDS Tran
                            oCSDSPTranItem.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString());
                            oCSDSPTranItem.Qty = Convert.ToInt32(oItemRow.Cells[13].Value.ToString());
                            oCSDSPTranItem.CostPrice = Convert.ToInt32(oItemRow.Cells[8].Value.ToString());
                            oCSDSPTranItem.SalePrice = Convert.ToInt32(oItemRow.Cells[5].Value.ToString());
                            oCSDSPTranItem.Add();

                            //Update Stock
                            SPStock aSPStock = new SPStock();
                            aSPStock.AddDeductStockQty = Convert.ToInt32(oItemRow.Cells[13].Value.ToString());
                            aSPStock.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                            aSPStock.SparePartID = oCSDSPTranItem.SparePartID;
                            aSPStock.UpdateStock(false);

                            //ADD USP
                            CSDSparePartUSP oCSDSparePartUSP = new CSDSparePartUSP();
                            oCSDSparePartUSP.TranID = aSPTran.SPTranID; //oSPTran.SPTranID = RDS Tran
                            oCSDSparePartUSP.Type = (int)Dictionary.SparePartUSP.Auto;
                            oCSDSparePartUSP.JobID = ctlJobAll1.SelectedJob.JobID;
                            oCSDSparePartUSP.TechnicianID = ctlJobAll1.SelectedJob.AssignTo;
                            oCSDSparePartUSP.SPID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                            oCSDSparePartUSP.Qty = Convert.ToInt32(oItemRow.Cells[13].Value.ToString().Trim());
                            oCSDSparePartUSP.CreateUserID = Utility.UserId;
                            oCSDSparePartUSP.CreateDate = DateTime.Now;
                            oCSDSparePartUSP.Add();

                            //Update Stock
                            SPStock aSPStockUsp = new SPStock();
                            aSPStockUsp.AddDeductStockQty = Convert.ToInt32(oItemRow.Cells[13].Value.ToString());
                            aSPStockUsp.StoreID = 4;
                            aSPStockUsp.SparePartID = oCSDSPTranItem.SparePartID;
                            aSPStockUsp.CheckStockBySpareID();
                            if (aSPStockUsp.Flag)
                            {
                                aSPStockUsp.UpdateStock(true);
                            }
                            else
                            {
                                aSPStockUsp.AddDeductStockQty = 0;
                                aSPStockUsp.Add();
                                aSPStockUsp.AddDeductStockQty = Convert.ToInt32(oItemRow.Cells[13].Value.ToString());
                                aSPStockUsp.UpdateStock(true);
                            }
                        }
                    }
                }
            }

           
        }
        private void AddStock()
        {
            foreach (SPTran oSPTran in _oSPTrans)
            {
                _oCSDSparePartStock = new CSDSparePartStock();
                _oCSDSparePartStock.CurrentStockQty = oSPTran.Qty;
                _oCSDSparePartStock.SparePartID = oSPTran.SparePartID;
                _oCSDSparePartStock.StoreID = oSPTran.FromStoreID;
                _oCSDSparePartStock.UpdateStock((int)Dictionary.YesOrNoStatus.YES);
            }
        }

        private bool ValidateUIForEdit()
        {
            if (lvwSPIssues.Items.Count == 0)
            {
                MessageBox.Show("There is no data to edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    oSPStock = new SPStock();
                    oSPStock.SparePartID = int.Parse(oItemRow.Cells[7].Value.ToString());
                    //oSPStock.StoreID = Convert.ToInt32((cmbStore.SelectedItem as ComboboxItem).Value.ToString()); ;
                    oSPStock.StoreID = _oStores[cmbStore.SelectedIndex-1].StoreID;
                    
                    oSPStock.CheckStockBySpareID();
                    if (oSPStock.CurrentStockQty < int.Parse(oItemRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Issue Qty must be less or equal to current Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private void cmbTechnician_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbTechnician.SelectedIndex != 0)
            //{
            //    PreviousIssuePartsTechnician();
            //} 

            if (cmbTechnician.SelectedIndex != 0)
            {
                nSpareUser_WHID = PreviousIssuePartsTechnician();
                if (nSpareUser_WHID != 0)
                {
                    int Index = _oStores.GetIndex(nSpareUser_WHID);
                    cmbStore.SelectedIndex = Index + 1;
                    cmbStore.Enabled = false;
                }
                else
                {
                    cmbStore.Enabled = true;
                    cmbStore.SelectedIndex = 0;
                }
                //if (!IsSpIssueAbleJob(ctlJobAll1.SelectedJob))
                //{
                //    ctlJobAll1.txtCode.Text = string.Empty;
                //    dgvIssuePart.Rows.Clear();
                //    lvwSPIssues.Items.Clear();
                //}
            }
            else
            {
                dgvIssuePart.Rows.Clear();
                lvwSPIssues.Items.Clear();
            }
        }

        private void GetIssuedPartsByTechID()
        {
            int nTechnicianID = _oTechnicians[cmbTechnician.SelectedIndex - 1].TechnicianID;
            _oSPTrans = new SPTrans();

            lvwSPIssues.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oSPTrans.GetIssuedPartsByTechID(nTechnicianID);
            foreach (SPTran oSPTran in _oSPTrans)
            {
                ListViewItem oItem = lvwSPIssues.Items.Add(oSPTran.PartCode.ToString());
                oItem.SubItems.Add(oSPTran.PartName);
                oItem.SubItems.Add(oSPTran.Qty.ToString());
                oItem.SubItems.Add(oSPTran.TotalPrice.ToString());
                oItem.Tag = oSPTran;
            }
            if (_oSPTrans.Count > 0)
            {
                btnEdit.Enabled = true;
            }
        }
        private int PreviousIssuePartsTechnician()
        {
            int nTechnicianID = _oTechnicians[cmbTechnician.SelectedIndex - 1].TechnicianID;
            int nCount = 0;
            int nFromStoreID = 0;
            _oSPTrans = new SPTrans();

            lvwSPIssues.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oSPTrans.RefreshIssuedPartsByTechID(nTechnicianID);
            foreach (SPTran oSPTran in _oSPTrans)
            {
                if (oSPTran.TranSide != 1)
                {
                    ListViewItem oItem = lvwSPIssues.Items.Add(oSPTran.PartCode.ToString());
                    oItem.SubItems.Add(oSPTran.PartName);
                    oItem.SubItems.Add(oSPTran.Qty.ToString());
                    oItem.SubItems.Add(oSPTran.TotalPrice.ToString());
                    oItem.SubItems.Add(oSPTran.TranDate.ToShortDateString());
                    oItem.Tag = oSPTran;

                    if (nCount == 0)
                    {
                        nFromStoreID = oSPTran.FromStoreID;
                        nCount++;
                    }
                }

                SPStock aSpStock = new SPStock();
                aSpStock.SparePartID = oSPTran.SparePartID;
                aSpStock.StoreID = (int)Dictionary.Store.CentralSoundStore;
                aSpStock.CurrentStockQty = 0;
                aSpStock.CheckStockBySpareID();
                if (!aSpStock.Flag)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        aSpStock.Add();
                        DBController.Instance.CommitTran();
                    }
                    catch
                    { }
                }

            }
            if (_oSPTrans.Count > 0)
            {
                btnEdit.Enabled = true;
            }

            return nFromStoreID;
        }

        private void cmbTechnician_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
