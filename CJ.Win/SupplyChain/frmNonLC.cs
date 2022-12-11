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
    public partial class frmNonLC : Form
    {

        SCMPurchaseOrder _oSCMPurchaseOrder;
        SCMOrder _oSCMOrder;
        SCMOrders _oSCMOrders;
        SCMPI _oSCMPI;
        SCMPIs _oSCMPIs;
        int nPIID = 0;
        int nStatus = 0;
        int nExGRDWeek = 0;
        int nExGRDYear = 0;
        string sPINo = "";
        int nCompanyID = 0;
        int nOrderID = 0;
        int nPSIID = 0;

        public frmNonLC()
        {
            InitializeComponent();
        }

        public void ShowDialog(SCMPI oSCMPI)
        {

            nPIID = oSCMPI.PIID;
            sPINo = oSCMPI.PINO;
            nExGRDWeek = oSCMPI.ExpectedGRDWeek;
            nExGRDYear = oSCMPI.ExpectedGRDYear;
            nCompanyID=oSCMPI.CompanyID;
            nOrderID = oSCMPI.OrderID;
            nPSIID = oSCMPI.PSIID;

            dgvNONLCQty.Columns[2].Visible = false;

            DBController.Instance.OpenNewConnection();
            

            lblCompanyName.Text = oSCMPI.CompanyName; 
            lblSupplierName.Text = oSCMPI.SupplierName;
            lblPSINo.Text = oSCMPI.PSINo;
            lblExpGRDWeek.Text = (Convert.ToString(nExGRDWeek) + "-" + Convert.ToString(nExGRDYear));

            lblPINO.Text = oSCMPI.PINO;
            lbOrderNo.Text = oSCMPI.OrderNo;

            this.Text = "NON LC Processing";
            if (nCompanyID == 82942)
            {
                dgvNONLCQty.Columns[2].Visible = true;

                oSCMPI.GetBEILPIItem(nPIID);
                foreach (SCMPIItem oSCMPIItem in oSCMPI)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvNONLCQty);
                    oRow.Cells[0].Value = oSCMPIItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMPIItem.ProductName.ToString();
                    oRow.Cells[2].Value = oSCMPIItem.BOMDescription.ToString();
                    oRow.Cells[3].Value = oSCMPIItem.PIQty.ToString();
                    oRow.Cells[4].Value = oSCMPIItem.PIQty.ToString();
                    oRow.Cells[5].Value = oSCMPIItem.ProductID.ToString();
                    oRow.Cells[6].Value = oSCMPIItem.BOMID.ToString();

                    dgvNONLCQty.Rows.Add(oRow);

                }

            }

            else
            {
                
                dgvNONLCQty.Columns[2].Visible = false;

                oSCMPI.GetPIItem(nPIID);
                foreach (SCMPIItem oSCMPIItem in oSCMPI)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvNONLCQty);
                    oRow.Cells[0].Value = oSCMPIItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oSCMPIItem.ProductName.ToString();
                    oRow.Cells[3].Value = oSCMPIItem.PIQty.ToString();
                    oRow.Cells[4].Value = oSCMPIItem.PIQty.ToString();
                    oRow.Cells[5].Value = oSCMPIItem.ProductID.ToString();

                    dgvNONLCQty.Rows.Add(oRow);

                }
            }
            this.Tag = oSCMPI;

            this.ShowDialog();
        }
        private bool validateUIInput()
        {

            foreach (DataGridViewRow oItemRow in dgvNONLCQty.Rows)
            {
                if (oItemRow.Index < dgvNONLCQty.Rows.Count)
                {
                    int nNONLCQty = 0;
                    int nPIQty = 0;

                    if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value != "")
                    {
                        nPIQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }

                    if (oItemRow.Cells[4].Value != null || oItemRow.Cells[4].Value.ToString().Trim() != "")
                    {
                        nNONLCQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    if (nPIQty >= nNONLCQty)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("LC Qty must be less or equal PI Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (nNONLCQty == 0)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("You have to inputed at least 1 (one) Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }

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


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSCMPI.UpdateNONLCInfo(nPIID);

                    if (nCompanyID == 82942)
                    {
                        foreach (DataGridViewRow oItemRow in dgvNONLCQty.Rows)
                        {
                            if (oItemRow.Index < dgvNONLCQty.Rows.Count)
                            {

                                SCMPIBOMItem _oSCMPIBOMItem = new SCMPIBOMItem();
                                _oSCMPIBOMItem.PIID = nPIID;
                                _oSCMPIBOMItem.BOMID = int.Parse(oItemRow.Cells[6].Value.ToString());
                                _oSCMPIBOMItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                                _oSCMPIBOMItem.PIQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                                _oSCMPIBOMItem.LCQty = int.Parse(oItemRow.Cells[4].Value.ToString());

                                if (nCount == 0)
                                {
                                    //Delete

                                    _oSCMPIBOMItem.Delete();

                                    nCount++;
                                }
                                _oSCMPIBOMItem.Insert();


                            }
                        }

                    }
                    else
                    {
                        foreach (DataGridViewRow oItemRow in dgvNONLCQty.Rows)
                        {
                            if (oItemRow.Index < dgvNONLCQty.Rows.Count)
                            {

                                SCMPIItem _oSCMPIItem = new SCMPIItem();
                                _oSCMPIItem.PIID = nPIID;
                                _oSCMPIItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                                _oSCMPIItem.PIQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                                _oSCMPIItem.LCQty = int.Parse(oItemRow.Cells[4].Value.ToString());

                                if (nCount == 0)
                                {
                                    //Delete
                                    _oSCMPIItem.PIID = nPIID;
                                    _oSCMPIItem.Delete();

                                    nCount++;
                                }
                                _oSCMPIItem.Insert(nPIID);


                            }
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

                    MessageBox.Show("Successfully Add LC PI No # " + sPINo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}