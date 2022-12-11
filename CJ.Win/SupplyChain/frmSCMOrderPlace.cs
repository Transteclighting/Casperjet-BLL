using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.BasicData;
using CJ.Class.Library;

namespace CJ.Win.SupplyChain
{
    public partial class frmSCMOrderPlace : Form
    {
        SCMPurchaseOrder _oSCMPurchaseOrder;
        SCMPurchaseOrders _oSCMPurchaseOrders;
        int nPSIID = 0;
        string sPSINo = "";
        int nStatus = 0;
        string sCompanyName = "";
        int nExGRDWeek = 0;
        int nExGRDYear = 0;
        string sSupplierName = "";
        Suppliers _oSuppliers;
        SCMOrder _oSCMOrder;


        public frmSCMOrderPlace()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(SCMPurchaseOrder oSCMPurchaseOrder)
        {

            nPSIID = 0;
            nPSIID = oSCMPurchaseOrder.PSIID;
            sPSINo = "";
            sPSINo = oSCMPurchaseOrder.PSINo;
            nExGRDWeek = 0;
            nExGRDWeek = oSCMPurchaseOrder.ExpectedHOArrivalWeek;
            nExGRDYear = 0;
            nExGRDYear = oSCMPurchaseOrder.ExpectedHOArrivalYear;
            sCompanyName = "";
            sCompanyName = oSCMPurchaseOrder.CompanyName;
            DBController.Instance.OpenNewConnection();
            oSCMPurchaseOrder.GetPSIItem(nPSIID);

            lblPSINo.Text = sPSINo;
            lblExpGRDWeek.Text = (Convert.ToString(nExGRDWeek) + "-" + Convert.ToString(nExGRDYear));
            lblCompanyName.Text = sCompanyName;

            // Suppliers
            _oSuppliers = new Suppliers();
            _oSuppliers.GetSupplierBySupplierName();
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("<Select Supplier>");
            foreach (Supplier oSupplier in _oSuppliers)
            {
                cmbSupplier.Items.Add(oSupplier.SupplierName);
            }
            cmbSupplier.SelectedIndex = 0;
            

            this.Text = "Order Place";

            foreach (SCMPurchaseOrderItem oSCMPurchaseOrderItem in oSCMPurchaseOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOrderQty);
                oRow.Cells[0].Value = oSCMPurchaseOrderItem.ProductCode.ToString();
                oRow.Cells[1].Value = oSCMPurchaseOrderItem.ProductName.ToString();

                oRow.Cells[2].Value = oSCMPurchaseOrderItem.PSIQty.ToString();
                oRow.Cells[3].Value = oSCMPurchaseOrderItem.OrderQty.ToString();
                oRow.Cells[4].Value = ((oSCMPurchaseOrderItem.PSIQty)-(oSCMPurchaseOrderItem.OrderQty));
                oRow.Cells[5].Value = oSCMPurchaseOrderItem.ProductID.ToString();

                dgvOrderQty.Rows.Add(oRow);

            }
            this.Tag = oSCMPurchaseOrder;

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region ProductDetail
            foreach (DataGridViewRow oItemRow in dgvOrderQty.Rows)
            {
                if (oItemRow.Index < dgvOrderQty.Rows.Count)
                {
                    int nPrevOrderQty = 0;
                    int nOrderQty = 0;
                    int nPSIQty = 0;

                    if (oItemRow.Cells[2].Value != null || oItemRow.Cells[2].Value != "")
                    {
                        nPSIQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                    }
                    if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value != "")
                    {
                        nPrevOrderQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }
                    if (oItemRow.Cells[4].Value != null || oItemRow.Cells[4].Value.ToString().Trim() != "")
                    {
                        nOrderQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    if (nPSIQty >= (nPrevOrderQty + nOrderQty))
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("(PrevOrderQty + OrderQty) Qty must be less or equal PSI Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (nOrderQty == 0)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("You have to inputed at least 1 (one) Order Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            #region ValidInput
            if (cmbSupplier.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _oSCMOrder = new SCMOrder();
            DBController.Instance.OpenNewConnection();
            _oSCMOrder.RefreshIsPSIQtyEqual(nPSIID);

            if (_oSCMOrder.IsEqual == 0)
            {
                MessageBox.Show("There is no PSI Qty for Order Place: PSINo " + sPSINo, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            
            }
            else
            {
                validateUIInput();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSCMOrder = new SCMOrder();
                    _oSCMOrder = GetUIData(_oSCMOrder);
                    _oSCMOrder.InsertOrder();
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Order Add Successfull: PSINo # " + sPSINo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }

        private void frmSCMOrderPlace_Load(object sender, EventArgs e)
        {

        }
        public SCMOrder GetUIData(SCMOrder _oSCMOrder)
        {
            _oSCMOrder.PSIID = nPSIID;
            _oSCMOrder.OrderPlaceDate = dtOrderPlascedate.Value.Date;
            _oSCMOrder.Remarks = txtRemarks.Text;
            _oSCMOrder.Status = (int)Dictionary.SCMStatus.OrderPlace;
            _oSCMOrder.ExpectedGRDWeek = nExGRDWeek;
            _oSCMOrder.ExpectedGRDYear = nExGRDYear;
            _oSCMOrder.SupplierID = _oSuppliers[cmbSupplier.SelectedIndex -1].SupplierID;


            // Item Details
            foreach (DataGridViewRow oItemRow in dgvOrderQty.Rows)
            {
                if (oItemRow.Index < dgvOrderQty.Rows.Count)
                {


                    SCMOrderItem _oSCMLCItem = new SCMOrderItem();

                    _oSCMLCItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    _oSCMLCItem.OrderQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    //_oSCMLCItem.PIQty = 0;
                    //_oSCMLCItem.LCQty = 0;
                    _oSCMOrder.Add(_oSCMLCItem);

                }
            }

            return _oSCMOrder;
        }


    }
}