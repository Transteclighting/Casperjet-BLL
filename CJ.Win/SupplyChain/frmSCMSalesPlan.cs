using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.Library;

namespace CJ.Win.SupplyChain
{
    public partial class frmSCMSalesPlan : Form
    {
        SCMSalesPlan _oSCMSalesPlan;
        TELLib oTELLib;
        ProductGroups _oProductGroups;
        Brands _oBrands;
        public frmSCMSalesPlan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (this.Tag != null)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    _oSCMSalesPlan = new SCMSalesPlan();
                    _oSCMSalesPlan = GetUIData(_oSCMSalesPlan);
                    //_oPOSRequisition.Edit(nRequisitionID, Utility.CentralRetailWarehouse);

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Update SCM Sales Plan, ID: " + _oSCMSalesPlan.SCMSalesPlanID.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSCMSalesPlan = new SCMSalesPlan();
                    _oSCMSalesPlan = GetUIData(_oSCMSalesPlan);
                    _oSCMSalesPlan.Add();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Add SCM Sales Plan, ID: " + _oSCMSalesPlan.SCMSalesPlanID.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                int nCount = 0;

                dgvLineItem.Rows.Clear();
                _oSCMSalesPlan = new SCMSalesPlan();
                _oSCMSalesPlan.Refresh(_oProductGroups[cmbASG.SelectedIndex - 1].PdtGroupID, _oBrands[cmbBrand.SelectedIndex - 1].BrandID);
                oTELLib = new TELLib();
                foreach (SCMSalesPlanItem oSCMSalesPlanItem in _oSCMSalesPlan)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oSCMSalesPlanItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMSalesPlanItem.ProductName.ToString();
                    oRow.Cells[2].Value = oSCMSalesPlanItem.RSP.ToString();
                    oRow.Cells[3].Value = "0";
                    oRow.Cells[4].Value = "0";
                    oRow.Cells[5].Value = oSCMSalesPlanItem.ProductID.ToString();

                    dgvLineItem.Rows.Add(oRow);
                    nCount++;

                }
                if (nCount > 0)
                {
                    dtPlanMonth.Enabled = false;
                    cmbASG.Enabled = false;
                    cmbBrand.Enabled = false;
                }
            }
        }

        private bool UIValidation()
        {
            if (cmbASG.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select ASG ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbASG.Focus();
                return false;
            }
            if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Brand ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBrand.Focus();
                return false;
            }

            return true;
        }
        private void frmSCMSalesPlan_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            //Brand
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<Select>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;


            //ASG

            _oProductGroups = new ProductGroups();
            _oProductGroups.Refresh(Dictionary.ProductGroupType.ASG);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("<Select>");
            foreach (ProductGroup oProductGroup in _oProductGroups)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbASG.SelectedIndex = 0;

        }
        public SCMSalesPlan GetUIData(SCMSalesPlan _oSCMSalesPlan)
        {

            _oSCMSalesPlan.PlanMonth = dtPlanMonth.Value;
            _oSCMSalesPlan.PlanQty = Convert.ToInt32(txtTotal.Text);
            _oSCMSalesPlan.ASGID = _oProductGroups[cmbASG.SelectedIndex - 1].PdtGroupID;
            _oSCMSalesPlan.BrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;

            // Product Details
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value != "")
                    {
                        SCMSalesPlanItem _oSCMSalesPlanItem = new SCMSalesPlanItem();
                        _oSCMSalesPlanItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());

                        _oSCMSalesPlanItem.Qty = int.Parse(oItemRow.Cells[3].Value.ToString());

                        _oSCMSalesPlan.Add(_oSCMSalesPlanItem);
                    }

                }
            }

            return _oSCMSalesPlan;
        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 3)
            {
                oTELLib = new TELLib();

                if (dgvLineItem.Rows[nRowIndex].Cells[3].Value != null || Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[3].Value) != 0)
                {
                    dgvLineItem.Rows[nRowIndex].Cells[4].Value = oTELLib.TakaFormat(Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[2].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()));
                }
                GetTotalAmount();
            }

        }
        public void GetTotalAmount()
        {
            txtTotal.Text = "0";

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {
                    txtTotal.Text = Convert.ToDouble(Convert.ToDouble(txtTotal.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }
            }

        }

        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }
        public void ShowDialog(SCMSalesPlan oSCMSalesPlan)
        {
            this.Tag = oSCMSalesPlan;
            //oTELLib = new TELLib();
            LoadCombo();
            //nRequisitionID = 0;
            //nToWHID = 0;
            //nFromWHID = 0;


            ////lblToWH.Text = oPOSRequisition.ToWHName;
            ////lblRequisitionNo.Text = oPOSRequisition.RequisitionNo;
            ////lblRequisitionDate.Text = oPOSRequisition.RequisitionDate.ToString("dd-MMM-yyyy");
            ////lblFromWH.Text = oPOSRequisition.FromWHName;
            ////nRequisitionID = oPOSRequisition.RequisitionID;
            ////nToWHID = oPOSRequisition.ToWHID;
            ////nFromWHID = oPOSRequisition.FromWHID;
            ////sRequisitionNo = oPOSRequisition.RequisitionNo;

            cmbASG.SelectedIndex = _oProductGroups.GetIndex(oSCMSalesPlan.ASGID) + 1;
            cmbBrand.SelectedIndex = _oBrands.GetIndex(oSCMSalesPlan.BrandID) + 1;

            oSCMSalesPlan.GetExistingProduct(oSCMSalesPlan.ASGID, oSCMSalesPlan.BrandID, oSCMSalesPlan.SCMSalesPlanID);

            foreach (SCMSalesPlanItem oSCMSalesPlanItem in oSCMSalesPlan)
            {

                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSCMSalesPlanItem.ProductCode.ToString();
                oRow.Cells[1].Value = oSCMSalesPlanItem.ProductName.ToString();
                oRow.Cells[2].Value = oSCMSalesPlanItem.RSP.ToString();
                oRow.Cells[3].Value = oSCMSalesPlanItem.Qty.ToString();
                oRow.Cells[4].Value = (oSCMSalesPlanItem.Qty * oSCMSalesPlanItem.RSP);
                oRow.Cells[5].Value = oSCMSalesPlanItem.ProductID.ToString();

                dgvLineItem.Rows.Add(oRow);

            }

            GetTotalAmount();

            this.ShowDialog();
        }
    }
}