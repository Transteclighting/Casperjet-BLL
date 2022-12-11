using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;


namespace CJ.Win.BEIL
{
    public partial class frmBEILGRD : Form
    {
        SCMShipments _oSCMShipments;
        SCMShipment _oSCMShipment;
        SCMBOMStockTran _oSCMBOMStockTran;

        public frmBEILGRD()
        {
            InitializeComponent();
        }

        private void frmBEILGRD_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private bool ValidateUIInput()
        {
            #region ProductDetail
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    int nPrevGRDQty = 0;
                    int nGRDQty = 0;
                    int nShipmentQty = 0;

                    if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value != "")
                    {
                        nShipmentQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }
                    if (oItemRow.Cells[4].Value != null || oItemRow.Cells[4].Value != "")
                    {
                        nPrevGRDQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    if (oItemRow.Cells[5].Value != null || oItemRow.Cells[5].Value.ToString().Trim() != "")
                    {
                        nGRDQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                    }
                    if (nShipmentQty >= (nPrevGRDQty + nGRDQty))
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("(Prev GRD Qty + GRD Qty) Qty must be less or equal Shipment Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }


                }
            }
            #endregion

            #region ValidInput

            if (txtTransationRef.Text == "")
            {
                MessageBox.Show("Please Input GRD No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTransationRef.Focus();
                return false;
            }


            if (txtTransationRef.Text != "")
            {
                _oSCMBOMStockTran = new SCMBOMStockTran();
                _oSCMBOMStockTran.TranNo = txtTransationRef.Text;
                if (!_oSCMBOMStockTran.CheckTranNo())
                {
                    MessageBox.Show("Please Input Valied GRD No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTransationRef.Focus();

                    return false;
                }

            }

            #endregion

            return true;
        }
        public void LoadCombo()
        {
            // GetShipment
            _oSCMShipments = new SCMShipments();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            _oSCMShipments.GetBEILShipment();
            cmbShipmentNo.Items.Clear();
            cmbShipmentNo.Items.Add("<Select Shipment>");
            foreach (SCMShipment oSCMShipment in _oSCMShipments)
            {
                cmbShipmentNo.Items.Add(oSCMShipment.ShipmentNo);
            }
            cmbShipmentNo.SelectedIndex = 0;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            txtTransationRef.Text = "";
            txtRemarks.Text = "";
            cmbShipmentNo.SelectedIndex = 0;
            txtShipmentDate.Text = "";
            txtInvoiceNo.Text = "";
            txtInvoiceDate.Text = "";
            txtCompany.Text = "";
            txtSupplyer.Text = "";
            txtLCNo.Text = "";
            txtLCDate.Text = "";
            txtPINo.Text = "";
            txtPIDate.Text = "";
            txtOrderNo.Text = "";
            txtOrderDate.Text = "";
            txtPSINo.Text = "";
            txtPSIDate.Text = "";

            dgvLineItem.Rows.Clear();

        }

        private void cmbShipmentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbShipmentNo.SelectedIndex != 0)
            {
                dgvLineItem.Rows.Clear();
                _oSCMShipment = new SCMShipment();
                _oSCMShipment.RefreshShipmentForGRD(_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID);
                _oSCMShipment.RefreshBEILShipmentItemForGRD();
                txtShipmentDate.Text = Convert.ToDateTime(_oSCMShipment.ShipmentDate).ToString("dd-MMM-yyyy");
                txtInvoiceNo.Text = _oSCMShipment.InvoiceNo;
                txtInvoiceDate.Text = Convert.ToDateTime(_oSCMShipment.InvoiceDate).ToString("dd-MMM-yyyy");
                txtCompany.Text = _oSCMShipment.CompanyName;
                txtSupplyer.Text = _oSCMShipment.SupplierName;
                txtLCNo.Text = _oSCMShipment.LCNo;
                txtLCDate.Text = Convert.ToDateTime(_oSCMShipment.LCDate).ToString("dd-MMM-yyyy");
                txtPINo.Text = _oSCMShipment.PINo;
                txtPIDate.Text = Convert.ToDateTime(_oSCMShipment.PIReceiveDate).ToString("dd-MMM-yyyy");
                txtOrderNo.Text = _oSCMShipment.OrderNo;
                txtOrderDate.Text = Convert.ToDateTime(_oSCMShipment.OrderPlaceDate).ToString("dd-MMM-yyyy");
                txtPSINo.Text = _oSCMShipment.PSINo;
                txtPSIDate.Text = Convert.ToDateTime(_oSCMShipment.PSIDate).ToString("dd-MMM-yyyy");

                foreach (SCMShipmentItem oSCMShipmentItem in _oSCMShipment)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oSCMShipmentItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMShipmentItem.ProductName.ToString();
                    oRow.Cells[2].Value = oSCMShipmentItem.BOMDescription.ToString();
                    oRow.Cells[3].Value = oSCMShipmentItem.ShipmentQty.ToString();
                    oRow.Cells[4].Value = oSCMShipmentItem.GRDQty.ToString();
                    oRow.Cells[5].Value = ((oSCMShipmentItem.ShipmentQty) - (oSCMShipmentItem.GRDQty));
                    oRow.Cells[6].Value = 0;
                    oRow.Cells[7].Value = 0;
                    oRow.Cells[9].Value = oSCMShipmentItem.ProductID.ToString();
                    oRow.Cells[10].Value = oSCMShipmentItem.BOMID.ToString();

                    dgvLineItem.Rows.Add(oRow);

                }
            }
            else
            {
                Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _oSCMBOMStockTran = new SCMBOMStockTran();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oSCMBOMStockTran.RefreshIsShipmentQtyEqual(_oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID);

            if (_oSCMBOMStockTran.IsEqual == 0)
            {
                MessageBox.Show("There is no Shipment Qty for GRD: ShipmentNo " + _oSCMShipments[cmbShipmentNo.SelectedIndex].ShipmentNo, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();

            }

            else if (ValidateUIInput())
            {

                _oSCMBOMStockTran = new SCMBOMStockTran();
                _oSCMBOMStockTran.TranNo = txtTransationRef.Text;
                _oSCMBOMStockTran.TranDate = DateTime.Today.Date;
                _oSCMBOMStockTran.ShipmentID = _oSCMShipments[cmbShipmentNo.SelectedIndex - 1].ShipmentID;
                _oSCMBOMStockTran.LCNo = txtLCNo.Text;
                _oSCMBOMStockTran.LCDate = Convert.ToDateTime(txtLCDate.Text);
                _oSCMBOMStockTran.Remarks = txtRemarks.Text;
                _oSCMBOMStockTran.CreateUserID = Utility.UserId;
                _oSCMBOMStockTran.CreateDate = DateTime.Now.Date;

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    _oSCMBOMStockTran.Add();

                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count)
                        {

                            SCMBOMStockTranItem _oSCMBOMStockTranItem = new SCMBOMStockTranItem();

                            _oSCMBOMStockTranItem.Quantity = int.Parse(oItemRow.Cells[5].Value.ToString());
                            _oSCMBOMStockTranItem.ShortQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                            _oSCMBOMStockTranItem.DamagedQty = int.Parse(oItemRow.Cells[7].Value.ToString());
                            if (oItemRow.Cells[8].Value != null)
                            {
                                _oSCMBOMStockTranItem.Remarks = (oItemRow.Cells[8].Value.ToString()); ;
                            }
                            _oSCMBOMStockTranItem.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                            _oSCMBOMStockTranItem.BOMID = int.Parse(oItemRow.Cells[10].Value.ToString());

                            if (_oSCMBOMStockTranItem.Quantity != 0)
                                _oSCMBOMStockTranItem.Add(_oSCMBOMStockTran.TranID);
                        }

                    }

                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count)
                        {

                            SCMBOMStock oItem = new SCMBOMStock();

                            oItem.LocationID = (int)Dictionary.SCMBOMStockLocation.BEIL_Logistics;
                            oItem.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                            oItem.BOMID = int.Parse(oItemRow.Cells[10].Value.ToString());
                            oItem.GRDQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                            
                            if (oItem.CheckBOMStock())
                                oItem.UpdateCurrentStock_GRD(true);
                            else
                            {
                                oItem.Add();
                                oItem.UpdateCurrentStock_GRD(true);
                            }

                        }

                    }


                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("GRD Add Successfull: GRDNo # " + _oSCMBOMStockTran.TranNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

            }
        }

    }
}