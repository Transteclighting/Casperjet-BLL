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
    public partial class frmSCMLCOpen : Form
    {
        SCMOrder _oSCMOrder;
        SCMOrders _oSCMOrders;
        SCMPI _oSCMPI;
        SCMPIs _oSCMPIs;
        SCMPIItem _oSCMPIItem;
        SCMPIBOMItem _oSCMPIBOMItem;

        Banks _oBanks;

        SCMLCItem _oSCMLCItem;
        int nPIID = 0;
        int nStatus = 0;
        int nExGRDWeek = 0;
        int nExGRDYear = 0;
        int nOrderID = 0;
        int nPSIID = 0;

        string sPINo = "";
        int nCompanyID = 0;

        public frmSCMLCOpen()
        {
            InitializeComponent();
        }
        public void ShowDialog(SCMPI oSCMPI)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombo();
            nPIID = 0;
            nPIID = oSCMPI.PIID;
            nExGRDWeek = 0;
            nExGRDWeek = oSCMPI.ExpectedGRDWeek;
            nExGRDYear = 0;
            nExGRDYear = oSCMPI.ExpectedGRDYear;
            nOrderID = oSCMPI.OrderID;
            nPSIID = oSCMPI.PSIID;
            nCompanyID = oSCMPI.CompanyID;
            sPINo = oSCMPI.PINO;
            lblCompanyName.Text = oSCMPI.CompanyName;
            lblSupplierName.Text = oSCMPI.SupplierName;
            lblPSINo.Text = oSCMPI.PSINo;
            lblPINO.Text = sPINo;
            lblExpGRDWeek.Text = Convert.ToString(nExGRDWeek);
            lblOrderNo.Text = oSCMPI.OrderNo;
            dgvBEILLCItem.Visible = false;
            dgvLCQty.Visible = false;

            this.Text = "LC Opening";

            if (oSCMPI.CompanyID == 82942)
            {
                dgvBEILLCItem.Visible = true;
                dgvLCQty.Visible = false;

                oSCMPI.GetBEILPIItem(nPIID);
                foreach (SCMPIItem oSCMPIItem in oSCMPI)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvBEILLCItem);
                    oRow.Cells[0].Value = oSCMPIItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMPIItem.ProductName.ToString();
                    oRow.Cells[2].Value = oSCMPIItem.BOMDescription.ToString();
                    oRow.Cells[3].Value = oSCMPIItem.PIQty.ToString();
                    oRow.Cells[4].Value = oSCMPIItem.PIQty.ToString();
                    oRow.Cells[5].Value = oSCMPIItem.ProductID.ToString();
                    oRow.Cells[6].Value = oSCMPIItem.BOMID.ToString();

                    dgvBEILLCItem.Rows.Add(oRow);

                }

            }
            else
            {
                dgvBEILLCItem.Visible = false;
                dgvLCQty.Visible = true;

                oSCMPI.GetPIItem(nPIID);
                foreach (SCMPIItem oSCMPIItem in oSCMPI)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLCQty);
                    oRow.Cells[0].Value = oSCMPIItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMPIItem.ProductName.ToString();
                    oRow.Cells[2].Value = oSCMPIItem.PIQty.ToString();
                    oRow.Cells[3].Value = oSCMPIItem.PIQty.ToString();
                    oRow.Cells[4].Value = oSCMPIItem.ProductID.ToString();

                    dgvLCQty.Rows.Add(oRow);

                }

            }
            this.Tag = oSCMPI;

            this.ShowDialog();


        }
        private void LoadCombo()
        {
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBankName.Items.Clear();
            cmbBankName.Items.Add("--Select Bank--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBankName.Items.Add(oBank.Name);
            }
            cmbBankName.SelectedIndex = 0;

            //Currency
            cmbCurrency.Items.Clear();
            cmbCurrency.Items.Add("--Select Currency--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Currency)))
            {
                cmbCurrency.Items.Add(Enum.GetName(typeof(Dictionary.Currency), GetEnum));
            }
            cmbCurrency.SelectedIndex = 0;

        }
        private bool validateUIInput()
        {
            if (nCompanyID == 82942)
            {
                #region ProductDetail
                foreach (DataGridViewRow oItemRow in dgvBEILLCItem.Rows)
                {
                    if (oItemRow.Index < dgvBEILLCItem.Rows.Count)
                    {
                        int nPIQty = 0;
                        int nLCQty = 0;

                        if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value != "")
                        {
                            nPIQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                        }

                        if (oItemRow.Cells[4].Value != null || oItemRow.Cells[4].Value.ToString().Trim() != "")
                        {
                            nLCQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                        }
                        if (nPIQty >= nLCQty)
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                            MessageBox.Show("LCQty must be less or equal PI Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (nLCQty == 0)
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                            MessageBox.Show("You have to inputed at least 1 (one) LCQty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }
                }
                #endregion
            }
            else
            {

                #region ProductDetail
                foreach (DataGridViewRow oItemRow in dgvLCQty.Rows)
                {
                    if (oItemRow.Index < dgvLCQty.Rows.Count)
                    {
                        int nPIQty = 0;
                        int nLCQty = 0;

                        if (oItemRow.Cells[2].Value != null || oItemRow.Cells[2].Value != "")
                        {
                            nPIQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                        }

                        if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value.ToString().Trim() != "")
                        {
                            nLCQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                        }
                        if (nPIQty >= nLCQty)
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                            MessageBox.Show("LCQty must be less or equal PI Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (nLCQty == 0)
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                            MessageBox.Show("You have to inputed at least 1 (one) LCQty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }
                }
                #endregion
            }

            #region ValidInput
            if (cmbBankName.SelectedIndex == null)
            {
                MessageBox.Show("Please Select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBankName.Focus();
                return false;
            }
            if (cmbCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCurrency.Focus();
                return false;
            }
            if (txtLCNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter LCNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLCNo.Focus();
                return false;
            }
            if (txtLCValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter LCValue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLCValue.Focus();
                return false;
            }
            if (txtHSCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter HSCode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHSCode.Focus();
                return false;
            }
            if (txtPreShipmentNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter HSCode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPreShipmentNo.Focus();
                return false;
            }
            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (validateUIInput())
            {
                _oSCMPI = new SCMPI();
                _oSCMPI.PIID = nPIID;
                _oSCMPI.Remarks = txtRemarks.Text;
                _oSCMPI.Status = (int)Dictionary.SCMStatus.LCOpening;
                _oSCMPI.ExpectedGRDWeek = nExGRDWeek;
                _oSCMPI.ExpectedGRDYear = nExGRDYear;
                _oSCMPI.LCNo = txtLCNo.Text;
                _oSCMPI.LCDate = dtLCDdate.Value.Date;
                _oSCMPI.Currency = cmbCurrency.SelectedIndex;
                _oSCMPI.LCValue = Convert.ToDouble(txtLCValue.Text);
                _oSCMPI.ConcernBankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                _oSCMPI.HSCode = txtHSCode.Text;
                _oSCMPI.PreShipmentInspNo = txtPreShipmentNo.Text;
                _oSCMPI.PreShipmentInspDate = dtPreShipment.Value.Date;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSCMPI.UpdateLCInfo(nPIID);

                    if (nCompanyID == 82942)
                    {
                        foreach (DataGridViewRow oItemRow in dgvBEILLCItem.Rows)
                        {
                            if (oItemRow.Index < dgvBEILLCItem.Rows.Count)
                            {

                                _oSCMPIBOMItem = new SCMPIBOMItem();
                                _oSCMPIBOMItem.PIID = nPIID;
                                _oSCMPIBOMItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                                _oSCMPIBOMItem.BOMID = int.Parse(oItemRow.Cells[6].Value.ToString());
                                _oSCMPIBOMItem.PIQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                                _oSCMPIBOMItem.LCQty = int.Parse(oItemRow.Cells[4].Value.ToString());

                                if (nCount == 0)
                                {
                                    //Delete
                                    _oSCMPIBOMItem.PIID = nPIID;
                                    _oSCMPIBOMItem.Delete();

                                    nCount++;
                                }
                                _oSCMPIBOMItem.Insert();

                            }
                        }

                        SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                        oSCMProcessHistory.TableName = "t_SCMPI";
                        oSCMProcessHistory.DateID = Convert.ToInt32(nPIID);
                        oSCMProcessHistory.StatusID = (int)Dictionary.SCMStatus.LCOpening;
                        oSCMProcessHistory.ExpectedGRDWeek = nExGRDWeek;
                        oSCMProcessHistory.ExpectedGRDYear = nExGRDYear;
                        oSCMProcessHistory.Remarks = _oSCMPI.Remarks;
                        oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                        oSCMProcessHistory.Add();
                    }

                    else
                    {
                        foreach (DataGridViewRow oItemRow in dgvLCQty.Rows)
                        {
                            if (oItemRow.Index < dgvLCQty.Rows.Count)
                            {

                                _oSCMPIItem = new SCMPIItem();

                                _oSCMPIItem.ProductID = int.Parse(oItemRow.Cells[4].Value.ToString());
                                _oSCMPIItem.PIQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                                _oSCMPIItem.LCQty = int.Parse(oItemRow.Cells[3].Value.ToString());

                                if (nCount == 0)
                                {
                                    //Delete
                                    _oSCMPIItem.PIID = nPIID;
                                    _oSCMPIItem.Delete();

                                    nCount++;
                                }
                                _oSCMPIItem.AddLCQty(nPIID, nExGRDWeek, nExGRDYear, _oSCMPI.Remarks);


                            }
                        }

                        SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                        oSCMProcessHistory.TableName = "t_SCMPI";
                        oSCMProcessHistory.DateID = Convert.ToInt32(nPIID);
                        oSCMProcessHistory.StatusID = (int)Dictionary.SCMStatus.LCOpening;
                        oSCMProcessHistory.ExpectedGRDWeek = nExGRDWeek;
                        oSCMProcessHistory.ExpectedGRDYear = nExGRDYear;
                        oSCMProcessHistory.Remarks = _oSCMPI.Remarks;
                        oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                        oSCMProcessHistory.Add();
                    }

                    //_oSCMPI.RefreshPendingPIStatus(_oSCMPI.OrderID);
                    //if (_oSCMPI.PendingStatus == 0)
                    //{
                    //    _oSCMPI.RefreshOrder(_oSCMPI.OrderID);
                    //    if (_oSCMPI.Status == (int)Dictionary.SCMStatus.LCOpening)
                    //    {
                    //        _oSCMPI.UpdateStatusLCProcessing(_oSCMPI.OrderID);
                    //        _oSCMPI.RefreshPendingLCProcess(_oSCMPI.PSIID);

                    //        if (_oSCMPI.PendingLCProcessStatus == 0)
                    //        {
                    //            _oSCMPI.UpdateStatusLCProcessingPSI(_oSCMPI.PSIID);

                    //        }
                    //    }

                    //}
                    SCMPI _oSCMPIStatus = new SCMPI();
                    _oSCMPIStatus.RefreshPendingLCOpenStatus(nOrderID);

                    if (_oSCMPIStatus.PendingStatus == 0)
                    {
                        _oSCMPIStatus.RefreshOrder(nOrderID);

                        if (_oSCMPIStatus.Status == (int)Dictionary.SCMStatus.LCProcessing)
                        {
                            _oSCMPIStatus.Status = (int)Dictionary.SCMStatus.LCOpening;
                            _oSCMPIStatus.UpdateOrderStatusAll(nOrderID);
                            _oSCMPIStatus.RefreshPendingLCOpen(nPSIID);

                            if (_oSCMPIStatus.PendingLCProcessStatus == 0)
                            {
                                _oSCMPIStatus.Status = (int)Dictionary.SCMStatus.LCOpening;
                                _oSCMPIStatus.UpdatePSIStatusAll(nPSIID);

                            }
                        }

                    }

                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Successfully Add LC # " + _oSCMPI.LCNo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}

