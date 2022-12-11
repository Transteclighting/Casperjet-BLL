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
    public partial class frmShipment : Form
    {
        SCMShipment _oSCMShipment;
        SCMShipments _oSCMShipments;
        SCMOrder _oSCMOrder;
        SCMPI _oSCMPI;
        SCMPIs _oSCMPIs;

        int nPIID = 0;
        int nExGRDWeek = 0;
        int nExGRDYear = 0;
        int nShipmentID = 0;
        string sPINO = "";
        int nCompanyID = 0;



        public frmShipment()
        {
            InitializeComponent();
        }

        public void ShowDialog(SCMPI oSCMPI)
        {
            DBController.Instance.OpenNewConnection();
            nPIID = 0;
            nPIID = oSCMPI.PIID;
            sPINO = "";
            sPINO = oSCMPI.PINO;

            nExGRDWeek = 0;
            nExGRDWeek = oSCMPI.ExpectedGRDWeek;
            nExGRDYear = 0;
            nExGRDYear = oSCMPI.ExpectedGRDYear;
            nCompanyID = oSCMPI.CompanyID;


            lblCompany.Text = oSCMPI.CompanyName;
            lblLCNO.Text = oSCMPI.LCNo;
            lblOrderNo.Text = oSCMPI.OrderNo;
            dgvShipmentQty.Columns[2].Visible = false;

            //Currency
            cmbCurrency.Items.Clear();
            cmbCurrency.Items.Add("--Select Currency--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Currency)))
            {
                cmbCurrency.Items.Add(Enum.GetName(typeof(Dictionary.Currency), GetEnum));
            }
            cmbCurrency.SelectedIndex = 0;

            this.Text = "Shipment";

            if (nCompanyID == 82942)
            {
                dgvShipmentQty.Columns[2].Visible = true;

                oSCMPI.GetBEILShipmentItem(nPIID);
                foreach (SCMPIItem oSCMPIItem in oSCMPI)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvShipmentQty);
                    oRow.Cells[0].Value = oSCMPIItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMPIItem.ProductName.ToString();
                    oRow.Cells[2].Value = oSCMPIItem.BOMDescription.ToString();
                    oRow.Cells[3].Value = oSCMPIItem.LCQty.ToString();
                    oRow.Cells[4].Value = oSCMPIItem.ShipmentQty.ToString();
                    oRow.Cells[5].Value = (oSCMPIItem.LCQty - oSCMPIItem.ShipmentQty);
                    oRow.Cells[6].Value = oSCMPIItem.ProductID.ToString();
                    oRow.Cells[7].Value = oSCMPIItem.BOMID.ToString();

                    dgvShipmentQty.Rows.Add(oRow);

                }

            }
            else
            {
                dgvShipmentQty.Columns[2].Visible = false;

                oSCMPI.GetShipmentItem(nPIID);
                foreach (SCMPIItem oSCMPIItem in oSCMPI)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvShipmentQty);
                    oRow.Cells[0].Value = oSCMPIItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMPIItem.ProductName.ToString();
                    oRow.Cells[3].Value = oSCMPIItem.LCQty.ToString();
                    oRow.Cells[4].Value = oSCMPIItem.ShipmentQty.ToString();
                    oRow.Cells[5].Value = (oSCMPIItem.LCQty - oSCMPIItem.ShipmentQty);
                    oRow.Cells[6].Value = oSCMPIItem.ProductID.ToString();

                    dgvShipmentQty.Rows.Add(oRow);

                }
            }

            this.Tag = oSCMPI;

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region ProductDetail
            foreach (DataGridViewRow oItemRow in dgvShipmentQty.Rows)
            {
                if (oItemRow.Index < dgvShipmentQty.Rows.Count)
                {
                    int nLCQty = 0;
                    int nPreShipmentQty = 0;
                    int nShipmentQty = 0;

                    if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value != "")
                    {
                        nLCQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }
                    if (oItemRow.Cells[4].Value != null || oItemRow.Cells[4].Value.ToString().Trim() != "")
                    {
                        nPreShipmentQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    if (oItemRow.Cells[5].Value != null || oItemRow.Cells[5].Value.ToString().Trim() != "")
                    {
                        nShipmentQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                    }
                    if (nLCQty >= nShipmentQty + nPreShipmentQty)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("(ShipmentQty + PreShipmentQty) must be less or equal LCQty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (nShipmentQty == 0)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("You have to inputed at least 1 (one) ShipmentQty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            #region ValidInput

            if (cmbCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCurrency.Focus();
                return false;
            }
            if (txtForwarderName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter ForwarderName", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtForwarderName.Focus();
                return false;
            }
            if (txtBLNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter BLNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBLNo.Focus();
                return false;
            }
            if (txtContainerNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter ContainerNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContainerNo.Focus();
                return false;
            }

            if (txtMeasurementCBM.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Measurement CBM", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMeasurementCBM.Focus();
                return false;
            }

            if (txtNoOfCarton.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter No Of Carton", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoOfCarton.Focus();
                return false;
            }
            if (txtInvNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter No Of Invoice No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvNo.Focus();
                return false;
            }
            if (txtInvAmt.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter No Of Invoice Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvAmt.Focus();
                return false;
            }
            if (txtNetWeightKG.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter No Of Net Weight", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNetWeightKG.Focus();
                return false;
            }
            if (txtGrossWeightKG.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter No Of Net Weight", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrossWeightKG.Focus();
                return false;
            }
            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            _oSCMShipment = new SCMShipment();
            DBController.Instance.OpenNewConnection();
            if (nCompanyID == 82942)
            {
                _oSCMShipment.RefreshBEILIsPIQtyEqual(nPIID);
            }
            else
            {
                _oSCMShipment.RefreshIsPIQtyEqual(nPIID);
            }

            if (_oSCMShipment.IsEqual == 0)
            {
                MessageBox.Show("There is no PI Qty for Shipment PINo: " + sPINO, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
           
            else if (this.Tag != null)
            {
                if (validateUIInput())
                {
                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        _oSCMShipment = new SCMShipment();
                        _oSCMShipment = GetUIData(_oSCMShipment);
                        _oSCMShipment.InsertShipment(nCompanyID);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Shipment # " + _oSCMShipment.ShipmentNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        _oSCMShipment = new SCMShipment();
                        _oSCMShipment = GetUIData(_oSCMShipment);
                        _oSCMShipment.Edit();

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update Shipment ID # " + nShipmentID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public SCMShipment GetUIData(SCMShipment _oSCMShipment)
        {
            _oSCMShipment.PIID = nPIID;
            _oSCMShipment.ShipmentDate = dtShipmentDate.Value;
            _oSCMShipment.ForwarderName = txtForwarderName.Text;
            _oSCMShipment.ForwarderEngagementDate = dtFEDdate.Value.Date;
            _oSCMShipment.BLNo = txtBLNo.Text;
            _oSCMShipment.BLDate = dtBLDate.Value.Date;
            _oSCMShipment.ContainerNo = txtContainerNo.Text;
            _oSCMShipment.MeasurementCBM =Convert.ToDouble(txtMeasurementCBM.Text);
            _oSCMShipment.NoOfCarton = Convert.ToInt32(txtNoOfCarton.Text);
            _oSCMShipment.InvoiceNo = txtInvNo.Text;
            _oSCMShipment.InvoiceDate = dtInvDate.Value.Date;
            _oSCMShipment.InvoiceAmount = Convert.ToDouble(txtInvAmt.Text);
            _oSCMShipment.Currency = cmbCurrency.SelectedIndex;
            _oSCMShipment.ShipmentDocRcvbyBankDate = dtSDocRcvbyBankDate.Value.Date;
            _oSCMShipment.NetWeightKG = Convert.ToDouble(txtNetWeightKG.Text);
            _oSCMShipment.GrossWeightKG = Convert.ToDouble(txtGrossWeightKG.Text);
            _oSCMShipment.Remarks = txtRemarks.Text;
            _oSCMShipment.ExpectedHOArrivalWeek = nExGRDWeek;
            _oSCMShipment.ExpectedHOArrivalYear = nExGRDYear;
            _oSCMShipment.Status = (int)Dictionary.SCMStatus.Shipment;

            if (nCompanyID == 82942)
            {
                foreach (DataGridViewRow oItemRow in dgvShipmentQty.Rows)
                {
                    if (oItemRow.Index < dgvShipmentQty.Rows.Count)
                    {

                        SCMShipmentItem _oSCMShipmentItem = new SCMShipmentItem();

                        _oSCMShipmentItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                        _oSCMShipmentItem.BOMID = int.Parse(oItemRow.Cells[7].Value.ToString());
                        _oSCMShipmentItem.ShipmentQty = int.Parse(oItemRow.Cells[5].Value.ToString());

                        _oSCMShipment.Add(_oSCMShipmentItem);
                    }
                }
            }
            else
            {


                // Item Details
                foreach (DataGridViewRow oItemRow in dgvShipmentQty.Rows)
                {
                    if (oItemRow.Index < dgvShipmentQty.Rows.Count)
                    {

                        SCMShipmentItem _oSCMShipmentItem = new SCMShipmentItem();

                        _oSCMShipmentItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                        _oSCMShipmentItem.ShipmentQty = int.Parse(oItemRow.Cells[5].Value.ToString());

                        _oSCMShipment.Add(_oSCMShipmentItem);
                    }
                }
            }

            return _oSCMShipment;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmShipment_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Shipment";

            }
            else
            {
                this.Text = "Edit Shipment";
            }

        }

    }
}