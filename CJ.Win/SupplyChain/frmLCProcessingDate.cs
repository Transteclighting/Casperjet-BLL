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
    public partial class frmLCProcessingDate : Form
    {
        SCMPI _oSCMPI;
        SCMPIs _oSCMPIs;
        int nPSIID = 0;
        int nPIID = 0;
        int nOrderID = 0;
        SCMPIItem _oSCMPIItem;

        string sPINO = "";
        int nExGRDWeek = 0;
        int nExGRDYear = 0;
        int nCompanyID = 0;
        int nExGRDMonth = 0;

        public frmLCProcessingDate()
        {
            InitializeComponent();
        }

        private void LoadCombo()
        {
            //Payment Modality
            cmbPaymentModality.Items.Clear();
            cmbPaymentModality.Items.Add("--Select Payment Modality--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SCMPaymentModality)))
            {
                cmbPaymentModality.Items.Add(Enum.GetName(typeof(Dictionary.SCMPaymentModality), GetEnum));
            }
            cmbPaymentModality.SelectedIndex = 0;

            //Payment Modality
            cmbPortofDischarge.Items.Clear();
            cmbPortofDischarge.Items.Add("--Select Port of Discharge--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SCMPortofDischarge)))
            {
                cmbPortofDischarge.Items.Add(Enum.GetName(typeof(Dictionary.SCMPortofDischarge), GetEnum));
            }
            cmbPortofDischarge.SelectedIndex = 0;

            //Shipped By
            cmbShippedBy.Items.Clear();
            cmbShippedBy.Items.Add("--Select Shipped By--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SCMShippedBy)))
            {
                cmbShippedBy.Items.Add(Enum.GetName(typeof(Dictionary.SCMShippedBy), GetEnum));
            }
            cmbShippedBy.SelectedIndex = 0;

        }


        public void ShowDialog(SCMPI oSCMPI)
        {

            nPSIID = oSCMPI.PSIID;
            nPIID = oSCMPI.PIID;
            nOrderID = oSCMPI.OrderID;
            sPINO = oSCMPI.PINO;
            nExGRDWeek = oSCMPI.ExpectedGRDWeek;
            nExGRDYear = oSCMPI.ExpectedGRDYear;
            nExGRDMonth = oSCMPI.ExpectedGRDMonth;
            nCompanyID = oSCMPI.CompanyID;
            lblCompanyName.Text = oSCMPI.CompanyName;
            lblSupplierName.Text = oSCMPI.SupplierName;
            lblOrderNo.Text = oSCMPI.OrderNo;
            lblPIReceiveDate.Text = Convert.ToDateTime(oSCMPI.PIReceiveDate).ToString("dd-MMM-yyyy");
            lblPSINo.Text = oSCMPI.PSINo;
            lblPINO.Text = oSCMPI.PINO;
            this.Tag = oSCMPI;
           







            this.Text = "LC Processing";
            this.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool validateUIInput()
        {
            #region ValidInput
            if (lblPSINo.Text == "")
            {
                MessageBox.Show("Please Input PSI#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblPSINo.Focus();
                return false;
            }

            if (lblOrderNo.Text == "")
            {
                MessageBox.Show("Please Input Order#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblOrderNo.Focus();
                return false;
            }
            if (lblSupplierName.Text == "")
            {
                MessageBox.Show("Please Input Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblSupplierName.Focus();
                return false;
            }
            if (cmbPaymentModality.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Payment Modality", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentModality.Focus();
                return false;
            }
            if (txtPortOfShipment.Text == "")
            {
                MessageBox.Show("Please Input Port Of Shipment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPortOfShipment.Focus();
                return false;
            }

            if (cmbPortofDischarge.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Port of Discharge", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPortofDischarge.Focus();
                return false;
            }

            if (cmbShippedBy.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Shipped By", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbShippedBy.Focus();
                return false;
            }

            if (txtInconterm.Text == "")
            {
                MessageBox.Show("Please Input Inconterm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInconterm.Focus();
                return false;
            }
            if (txtStockTurnover.Text == "")
            {
                MessageBox.Show("Please Input Stock Turnover", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockTurnover.Focus();
                return false;
            }
            #endregion

            #region Detail

            if (dgvInvestment.Rows.Count == 1)
            {
                MessageBox.Show("Please Input  Investment In Stock", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow oItemRow in dgvLCStock.Rows)
            {
                if (oItemRow.Index < dgvLCStock.Rows.Count)
                {
                    int nM0Plan = 0;
                    int nM1Plan = 0;
                    int nM2Plan = 0;
                    int nM3Plan = 0;
                    int nM0Sales = 0;
                    int nM1Sales = 0;
                    int nM2Sales = 0;
                    int nM3Sales = 0;
                    int nClosingStock = 0;
                    int nWOS = 0;

                    try
                    {
                        nM0Plan = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid " + txtM0Plan.HeaderText + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        nM0Sales = int.Parse(oItemRow.Cells[5].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid " + txtM0Sales.HeaderText + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        nM1Plan = int.Parse(oItemRow.Cells[6].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid " + txtM1Plan.HeaderText + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    try
                    {
                        nM1Sales = int.Parse(oItemRow.Cells[7].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid " + txtM1Sales.HeaderText + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        nM2Plan = int.Parse(oItemRow.Cells[8].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid " + txtM2Plan.HeaderText + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    try
                    {
                        nM2Sales = int.Parse(oItemRow.Cells[9].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid " + txtM2Sales.HeaderText + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        nM3Plan = int.Parse(oItemRow.Cells[10].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid " + txtM3Plan.HeaderText + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    try
                    {
                        nM3Sales = int.Parse(oItemRow.Cells[11].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid " + txtM3Sales.HeaderText + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    try
                    {
                        nClosingStock = int.Parse(oItemRow.Cells[12].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid Closing Stock", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    try
                    {
                        nWOS = int.Parse(oItemRow.Cells[13].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid WOS", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }



            foreach (DataGridViewRow oItem in dgvInvestment.Rows)
            {
                if (oItem.Index < dgvInvestment.Rows.Count - 1)
                {
                    try
                    {
                        int nSL = Convert.ToInt32(oItem.Cells[0].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid SL# ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItem.Cells[1].Value.ToString() == "")
                    {
                        MessageBox.Show("Please Input Investment Description", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    double nValue = 0;
                    try
                    {
                        nValue = Convert.ToDouble(oItem.Cells[2].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input  Valid Investment Value", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
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
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSCMPI = new SCMPI();
                    _oSCMPI.LCProcessingDate = dtLCProcessingdate.Value.Date;
                    _oSCMPI.Status = (int)Dictionary.SCMStatus.LCProcessing;
                    _oSCMPI.UpdateLCProcessingDate(nPIID, nExGRDWeek, nExGRDYear, txtRemarks.Text.Trim());

                    _oSCMPI.RefreshPendingPIStatus(nOrderID);
                    if (nCompanyID == 82942)
                    {
                        if (_oSCMPI.PendingStatus == 0)
                        {
                            _oSCMPI.RefreshOrder(nOrderID);

                            if (_oSCMPI.Status == (int)Dictionary.SCMStatus.PIReceive)
                            {
                                _oSCMPI.UpdateStatusLCProcessing(nOrderID);
                                _oSCMPI.RefreshPendingLCProcess(nPSIID);

                                if (_oSCMPI.PendingLCProcessStatus == 0)
                                {
                                    _oSCMPI.UpdateStatusLCProcessingPSI(nPSIID);

                                }
                            }

                        }

                    }

                    else
                    {
                        if (_oSCMPI.PendingStatus == 0)
                        {
                            _oSCMPI.RefreshOrder(nOrderID);
                            _oSCMPIItem = new SCMPIItem();
                            _oSCMPIItem.CheckOPIQty(nOrderID);
                            if (_oSCMPIItem.QtyMatch == 0 || _oSCMPI.Status == (int)Dictionary.SCMStatus.PIReceive)
                            {
                                _oSCMPI.UpdateStatusLCProcessing(nOrderID);
                                _oSCMPI.RefreshPendingLCProcess(nPSIID);

                                if (_oSCMPI.PendingLCProcessStatus == 0)
                                {
                                    _oSCMPI.UpdateStatusLCProcessingPSI(nPSIID);

                                }
                            }

                        }
                    }
                    InsertLCRequisitionData();
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("LC Processing Successfull # " + sPINO, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcessData_Click(object sender, EventArgs e)
        {
            string sMAGID = "";
            string sBrandID = "";
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            ProductDetails oDetail = new ProductDetails();
            oDetail.GetPSIMAGByID(nPSIID);
            foreach (ProductDetail oProductDetail in oDetail)
            {
                if (sMAGID == "")
                    sMAGID = oProductDetail.MAGID.ToString();
                else sMAGID = sMAGID + ',' + oProductDetail.MAGID.ToString();

                if (sBrandID == "")
                    sBrandID = oProductDetail.BrandID.ToString();
                else sBrandID = sBrandID + ',' + oProductDetail.BrandID.ToString();
            }

            int nExpectedHOArrivalYear = nExGRDYear;
            int nM0Year = 0;
            int nM1Year = 0;
            int nM2Year = 0;
            int nM3Year = 0;
            int nM0Month = 0;
            int nM1Month = 0;
            int nM2Month = 0;
            int nM3Month = 0;

            nM0Month = dtLCProcessingdate.Value.Month;
            nM1Month = dtLCProcessingdate.Value.AddMonths(1).Month;
            nM2Month = dtLCProcessingdate.Value.AddMonths(2).Month;
            nM3Month = dtLCProcessingdate.Value.AddMonths(3).Month;


            nM0Year = dtLCProcessingdate.Value.Year;
            nM1Year = dtLCProcessingdate.Value.AddMonths(1).Year;
            nM2Year = dtLCProcessingdate.Value.AddMonths(2).Year;
            nM3Year = dtLCProcessingdate.Value.AddMonths(3).Year;


            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string sM0Month = mfi.GetMonthName(nM0Month).ToString();
            string sM1Month = mfi.GetMonthName(nM1Month).ToString();
            string sM2Month = mfi.GetMonthName(nM2Month).ToString();
            string sM3Month = mfi.GetMonthName(nM3Month).ToString();


            txtOpeningStock.HeaderText = "" + sM0Month.Substring(0, 3) + '-' + nM0Year.ToString() + @" Opening Stk";
            txtM0Sales.HeaderText = "" + sM0Month.Substring(0, 3) + '-' + nM0Year.ToString() + @" Sales";
            txtM0Plan.HeaderText = "" + sM0Month.Substring(0, 3) + '-' + nM0Year.ToString() + @" Arrival";
            txtM1Sales.HeaderText = "" + sM1Month.Substring(0, 3) + '-' + nM1Year.ToString() + @" Sales";
            txtM1Plan.HeaderText = "" + sM1Month.Substring(0, 3) + '-' + nM1Year.ToString() + @" Arrival";
            txtM2Sales.HeaderText = "" + sM2Month.Substring(0, 3) + '-' + nM2Year.ToString() + @" Sales";
            txtM2Plan.HeaderText = "" + sM2Month.Substring(0, 3) + '-' + nM2Year.ToString() + @" Arrival";
            txtM3Sales.HeaderText = "" + sM3Month.Substring(0, 3) + '-' + nM3Year.ToString() + @" Sales";
            txtM3Plan.HeaderText = "" + sM3Month.Substring(0, 3) + '-' + nM3Year.ToString() + @" Arrival";
            

            SCMPurchaseOrder oSCMPurchaseOrder = new SCMPurchaseOrder();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oSCMPurchaseOrder.GetLCRequisitionData(nExpectedHOArrivalYear, nM0Year, nM1Year, nM2Year, nM3Year, nM0Month, nM1Month, nM2Month, nM3Month, sMAGID, sBrandID);
            dgvLCStock.Rows.Clear();
            TELLib oTELLib = new TELLib();
            foreach (SCMPurchaseOrderItem oSCMPurchaseOrderItem in oSCMPurchaseOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLCStock);
                oRow.Cells[0].Value = oSCMPurchaseOrderItem.MAGName.ToString();
                oRow.Cells[1].Value = oSCMPurchaseOrderItem.PGName.ToString();
                oRow.Cells[2].Value = oSCMPurchaseOrderItem.BrandDesc.ToString();
                SCMPurchaseOrder oStk = new SCMPurchaseOrder();
                oRow.Cells[3].Value = oStk.GetOpeningStockByMAGID(oTELLib.FirstDayofMonth(dtLCProcessingdate.Value.Date), oSCMPurchaseOrderItem.MAGID, oSCMPurchaseOrderItem.BrandID); //opening
                oRow.Cells[4].Value = oSCMPurchaseOrderItem.M0Plan.ToString();
                oRow.Cells[5].Value = oSCMPurchaseOrderItem.M0Sales.ToString();
                oRow.Cells[6].Value = oSCMPurchaseOrderItem.M1Plan.ToString();
                oRow.Cells[7].Value = oSCMPurchaseOrderItem.M1Sales.ToString();
                oRow.Cells[8].Value = oSCMPurchaseOrderItem.M2Plan.ToString();
                oRow.Cells[9].Value = oSCMPurchaseOrderItem.M2Sales.ToString();
                oRow.Cells[10].Value = oSCMPurchaseOrderItem.M3Plan.ToString();
                oRow.Cells[11].Value = oSCMPurchaseOrderItem.M3Sales.ToString();
                oRow.Cells[12].Value = (Convert.ToInt32(oRow.Cells[3].Value) + (oSCMPurchaseOrderItem.M0Plan + oSCMPurchaseOrderItem.M1Plan + oSCMPurchaseOrderItem.M2Plan + oSCMPurchaseOrderItem.M3Plan)) - (oSCMPurchaseOrderItem.M0Sales + oSCMPurchaseOrderItem.M1Sales + oSCMPurchaseOrderItem.M2Sales + oSCMPurchaseOrderItem.M3Sales);///Closing Stock
                if (oSCMPurchaseOrderItem.M0Sales + oSCMPurchaseOrderItem.M1Sales + oSCMPurchaseOrderItem.M2Sales + oSCMPurchaseOrderItem.M3Sales <= 0)
                {
                    oRow.Cells[13].Value = 0;  ///WOS
                    double III = (Convert.ToDouble(oSCMPurchaseOrderItem.M0Sales + oSCMPurchaseOrderItem.M1Sales + oSCMPurchaseOrderItem.M2Sales + oSCMPurchaseOrderItem.M3Sales) / 16);
                }
                else
                {
                    double _WOS = Convert.ToDouble((Convert.ToInt32(oRow.Cells[3].Value) + oSCMPurchaseOrderItem.M0Plan + oSCMPurchaseOrderItem.M1Plan + oSCMPurchaseOrderItem.M2Plan + oSCMPurchaseOrderItem.M3Plan)) / ((oSCMPurchaseOrderItem.M0Sales + oSCMPurchaseOrderItem.M1Sales + oSCMPurchaseOrderItem.M2Sales + oSCMPurchaseOrderItem.M3Sales) / 16);
                    oRow.Cells[13].Value = Math.Round(_WOS, MidpointRounding.AwayFromZero);  ///WOS
                }
                oRow.Cells[14].Value = ""; ///remarks
                oRow.Cells[15].Value = oSCMPurchaseOrderItem.MAGID.ToString();
                oRow.Cells[16].Value = oSCMPurchaseOrderItem.PGID.ToString();
                oRow.Cells[17].Value = oSCMPurchaseOrderItem.BrandID.ToString();
                dgvLCStock.Rows.Add(oRow);

            }
        }

        private void frmLCProcessingDate_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        public void InsertLCRequisitionData()
        {
            SCMPI _oSCMPI = new SCMPI();
            _oSCMPI.LCProcessingDate = dtLCProcessingdate.Value.Date;
            _oSCMPI.PSINo = lblPSINo.Text;
            _oSCMPI.OrderNo = lblOrderNo.Text;
            _oSCMPI.ExpectedGRDWeek = nExGRDWeek;
            _oSCMPI.ExpectedGRDMonth = nExGRDMonth;
            _oSCMPI.ExpectedGRDYear = nExGRDYear;
            _oSCMPI.SupplierName = lblSupplierName.Text;
            _oSCMPI.PIID = nPIID;
            _oSCMPI.PaymentModality = cmbPaymentModality.SelectedIndex;
            _oSCMPI.PortofShipment = txtPortOfShipment.Text;
            _oSCMPI.PortofDischarge = cmbPortofDischarge.SelectedIndex;
            _oSCMPI.ShippedBy = cmbShippedBy.SelectedIndex;
            _oSCMPI.Inconterm = txtInconterm.Text;
            _oSCMPI.Remarks = txtRemarks.Text;
            _oSCMPI.Status = (int)Dictionary.SCMLCRequisitionStatus.Create;
            _oSCMPI.StockTurnover = Convert.ToDouble(txtStockTurnover.Text);
            _oSCMPI.InsertLCRequisition();

            // StockPosition
            foreach (DataGridViewRow oItemRow in dgvLCStock.Rows)
            {
                if (oItemRow.Index < dgvLCStock.Rows.Count)
                {
                    SCMPIItem _oSCMPIItem = new SCMPIItem();
                    _oSCMPIItem.LCRequisitionID = _oSCMPI.LCRequisitionID;
                    _oSCMPIItem.OpeningStock = int.Parse(oItemRow.Cells[3].Value.ToString());
                    _oSCMPIItem.M0Plan = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oSCMPIItem.M1Plan = int.Parse(oItemRow.Cells[6].Value.ToString());
                    _oSCMPIItem.M2Plan = int.Parse(oItemRow.Cells[8].Value.ToString());
                    _oSCMPIItem.M3Plan = int.Parse(oItemRow.Cells[10].Value.ToString());
                    _oSCMPIItem.M0Sales = int.Parse(oItemRow.Cells[5].Value.ToString());
                    _oSCMPIItem.M1Sales = int.Parse(oItemRow.Cells[7].Value.ToString());
                    _oSCMPIItem.M2Sales = int.Parse(oItemRow.Cells[9].Value.ToString());
                    _oSCMPIItem.M3Sales = int.Parse(oItemRow.Cells[11].Value.ToString());
                    _oSCMPIItem.ClosingStock = int.Parse(oItemRow.Cells[12].Value.ToString());
                    _oSCMPIItem.WOS = int.Parse(oItemRow.Cells[13].Value.ToString());
                    _oSCMPIItem.Remarks = oItemRow.Cells[14].Value.ToString();
                    _oSCMPIItem.MAGID = int.Parse(oItemRow.Cells[15].Value.ToString());
                    _oSCMPIItem.PGID = int.Parse(oItemRow.Cells[16].Value.ToString());
                    _oSCMPIItem.BrandID = int.Parse(oItemRow.Cells[17].Value.ToString());
                    _oSCMPIItem.AddLCReqStkPosition();

                }
            }
            // Investment
            foreach (DataGridViewRow oItemRow in dgvInvestment.Rows)
            {
                if (oItemRow.Index < dgvInvestment.Rows.Count - 1)
                {
                    SCMPIItem _oInvestment = new SCMPIItem();
                    _oInvestment.LCRequisitionID = _oSCMPI.LCRequisitionID;
                    _oInvestment.SL = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                    _oInvestment.Description = oItemRow.Cells[1].Value.ToString();
                    _oInvestment.Value = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                    try
                    {
                        _oInvestment.Remarks = oItemRow.Cells[3].Value.ToString();
                    }
                    catch
                    {
                        _oInvestment.Remarks = "";
                    }

                    _oInvestment.AddLCReqInvestment();

                }
            }

        }

        private void txtStockTurnover_TextChanged(object sender, EventArgs e)
        {
            if (txtStockTurnover.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtStockTurnover.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Stock Turnover Value ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStockTurnover.Text = "";
                }

            }
        }
    }
}