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
    public partial class frmSCMPI : Form
    {
        SCMOrder _oSCMOrder;
        SCMOrders _oSCMOrders;
        SCMPI _oSCMPI;
        SCMPIs _oSCMPIs;

        SCMPurchaseOrder _oSCMPurchaseOrder;
        SCMLCItem _oSCMLCItem;
        int nPSIID = 0;
        string sPSINo = "";
        int nStatus = 0;
        string sCompanyName = "";
        int nExGRDWeek = 0;
        int nExGRDYear = 0;
        string sSupplierName = "";
        int nOrderID = 0;
        string sPINo = "";
        string sOrderNo = "";

        public frmSCMPI()
        {
            InitializeComponent();
            //_oDSBOMData = new DSBOM();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(SCMOrder oSCMOrder)
        {
            nOrderID = 0;
            nOrderID = oSCMOrder.OrderID;
            sOrderNo = oSCMOrder.OrderNo;
            nPSIID = 0;
            nPSIID = oSCMOrder.PSIID;
            sPSINo = "";
            sPSINo = oSCMOrder.PSINo;
            nExGRDWeek = 0;
            nExGRDWeek = oSCMOrder.ExpectedGRDWeek;
            nExGRDYear = 0;
            nExGRDYear = oSCMOrder.ExpectedGRDYear;
            sCompanyName = "";
            sCompanyName = oSCMOrder.CompanyName;
            sSupplierName = "";
            sSupplierName = oSCMOrder.SupplierName;
            sPINo = oSCMOrder.PINo;

            DBController.Instance.OpenNewConnection();
            oSCMOrder.GetOrderItem(nOrderID);


            lblCompanyName.Text = sCompanyName;
            lblSupplierName.Text = sSupplierName;
            lblExpGRDWeek.Text = (Convert.ToString(nExGRDWeek) + "-" + Convert.ToString(nExGRDYear));
            lblPSINo.Text = sPSINo;
            lblOrderNo.Text = oSCMOrder.OrderNo;
            lblOrderDate.Text = Convert.ToDateTime(oSCMOrder.OrderPlaceDate).ToString("dd-MMM-yyyy");


            this.Text = "PI Receive";

            foreach (SCMOrderItem oSCMOrderItem in oSCMOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvPIQty);
                oRow.Cells[0].Value = oSCMOrderItem.ProductCode.ToString();
                oRow.Cells[1].Value = oSCMOrderItem.ProductName.ToString();
                oRow.Cells[2].Value = oSCMOrderItem.OrderQty.ToString();
                oRow.Cells[3].Value = oSCMOrderItem.PIQty.ToString();
                oRow.Cells[4].Value = ((oSCMOrderItem.OrderQty) - (oSCMOrderItem.PIQty));
                oRow.Cells[5].Value = oSCMOrderItem.ProductID.ToString();

                dgvPIQty.Rows.Add(oRow);

            }
            this.Tag = oSCMOrder;


            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region ProductDetail
            foreach (DataGridViewRow oItemRow in dgvPIQty.Rows)
            {
                if (oItemRow.Index < dgvPIQty.Rows.Count)
                {
                    int nOrderQty = 0;
                    int nPIQty = 0;

                    if (oItemRow.Cells[2].Value != null || oItemRow.Cells[2].Value != "")
                    {
                        nOrderQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                    }

                    if (oItemRow.Cells[3].Value != null || oItemRow.Cells[3].Value.ToString().Trim() != "")
                    {
                        nPIQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }
                    if (nOrderQty >= nPIQty)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("PIQty must be less or equal Order Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (nOrderQty == 0)
                    {
                        oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                        MessageBox.Show("You have to inputed at least 1 (one) PIQty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            #region ValidInput
            if (txtPINO.Text == "")
            {
                MessageBox.Show("Please Input PI#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPINO.Focus();
                return false;
            }
            if (txtPIValue.Text == "")
            {
                MessageBox.Show("Please Input PI Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPIValue.Focus();
                return false;
            }
            if (cmbPICurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select PI Currency", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPICurrency.Focus();
                return false;
            }
            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            _oSCMPI = new SCMPI();
            SCMPI _oSCMPIGet = new SCMPI();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oSCMPIGet.RefreshIsOrderQtyEqual(nOrderID);

            if (_oSCMPIGet.IsEqual == 0)
            {
                MessageBox.Show("There is no Order Qty for PI Receive PSINo: " + sOrderNo, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();

            }
            else
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oSCMPI = new SCMPI();
                        _oSCMPI = GetUIData(_oSCMPI);
                        _oSCMPI.InsertPI();

                        _oSCMPIGet.RefreshIsOrderQtyEqual(nOrderID);
                        if (_oSCMPIGet.IsEqual == 0)
                        {
                            SCMOrder oSCMOrder = new SCMOrder();
                            oSCMOrder.OrderID = nOrderID;
                            oSCMOrder.Status = (int)Dictionary.SCMStatus.PIReceive;
                            oSCMOrder.UpdateStatus();
                            oSCMOrder.RefreshPendingOrderStatus(nPSIID);
                            if (oSCMOrder.PendingStatus == 0)
                            {
                                oSCMOrder.UpdateStatusPSI(nPSIID);

                            }
                        }


                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add PI # " + _oSCMPI.PINO.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public SCMPI GetUIData(SCMPI _oSCMPI)
        {
            _oSCMPI.OrderID = nOrderID;
            _oSCMPI.PINO = txtPINO.Text;
            _oSCMPI.PIReceiveDate = dtPIReceivedate.Value.Date; 
            _oSCMPI.Remarks = txtRemarks.Text;
            _oSCMPI.Status = (int)Dictionary.SCMStatus.PIReceive;
            _oSCMPI.ExpectedGRDWeek = nExGRDWeek;
            _oSCMPI.ExpectedGRDYear = nExGRDYear;

            _oSCMPI.PIValue = Convert.ToDouble(txtPIValue.Text);
            _oSCMPI.PICurrency = cmbPICurrency.SelectedIndex;

            // Item Details
            foreach (DataGridViewRow oItemRow in dgvPIQty.Rows)
            {
                if (oItemRow.Index < dgvPIQty.Rows.Count)
                {

                    SCMPIItem _oSCMPIItem = new SCMPIItem();

                    _oSCMPIItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    _oSCMPIItem.PIQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oSCMPIItem.LCQty = 0;
                    _oSCMPI.Add(_oSCMPIItem);

                }
            }


            return _oSCMPI;
        }

        private void dgvPIQty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmSCMPI_Load(object sender, EventArgs e)
        {
            //Currency
            cmbPICurrency.Items.Clear();
            cmbPICurrency.Items.Add("--Select Currency--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Currency)))
            {
                cmbPICurrency.Items.Add(Enum.GetName(typeof(Dictionary.Currency), GetEnum));
            }
            cmbPICurrency.SelectedIndex = 0;
        }

        private void txtPIValue_TextChanged(object sender, EventArgs e)
        {
            if (txtPIValue.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtPIValue.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid PI Value ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPIValue.Text = "";
                }

            }
        }
    }
}
