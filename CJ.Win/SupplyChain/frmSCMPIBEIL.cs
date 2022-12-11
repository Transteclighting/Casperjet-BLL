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
    public partial class frmSCMPIBEIL : Form
    {
        DSBOM _oDSBOM;
        DSBOM _oDSBOMData;
        SCMPI _oSCMPI;
        int nOrderID = 0;
        string sOrderNo = "";
        int nExGRDWeek = 0;
        int nExGRDYear = 0;


        public frmSCMPIBEIL()
        {
            InitializeComponent();
            _oDSBOMData = new DSBOM();
        }
        public void ShowDialog(SCMOrder oSCMOrder)
        {
            nOrderID = 0;
            nOrderID = oSCMOrder.OrderID;
            sOrderNo = oSCMOrder.OrderNo;
            nExGRDWeek = oSCMOrder.ExpectedGRDWeek;
            nExGRDYear = oSCMOrder.ExpectedGRDYear;

            DBController.Instance.OpenNewConnection();
            oSCMOrder.GetOrderItem(nOrderID);

            lblCompanyName.Text = oSCMOrder.CompanyName;
            lblSupplierName.Text = oSCMOrder.SupplierName;
            lblExpGRDWeek.Text = (Convert.ToString(oSCMOrder.ExpectedGRDWeek) + "-" + Convert.ToString(oSCMOrder.ExpectedGRDYear));
            lblPSINo.Text = oSCMOrder.PSINo;
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
                oRow.Cells[5].Value = oSCMOrderItem.ProductID.ToString();
                dgvPIQty.Rows.Add(oRow);

            }
            this.Tag = oSCMOrder;


            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region ValidInput
            if (txtPINO.Text == "")
            {
                MessageBox.Show("Please Input PINO", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPINO.Focus();
                return false;
            }
            #endregion

            return true;
        }

        private void dgvPIQty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _oDSBOM = new DSBOM();

            if (e.ColumnIndex == 4)
            {
                frmSCMBOM oForm = new frmSCMBOM();
                oForm.ShowDialog(_oDSBOM, nOrderID, Convert.ToInt32(dgvPIQty.CurrentRow.Cells[5].Value));

                _oDSBOM = oForm._oDSBOM;
                _oDSBOMData.Merge(_oDSBOM);
                _oDSBOMData.AcceptChanges();

                dgvPIQty.Rows[e.RowIndex].Cells[3].Value = oForm._sBOMList;


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            _oSCMPI = new SCMPI();
            DBController.Instance.OpenNewConnection();

            if (validateUIInput())
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSCMPI = new SCMPI();
                    _oSCMPI.OrderID = nOrderID;
                    _oSCMPI.PINO = txtPINO.Text;
                    _oSCMPI.PIReceiveDate = dtPIReceivedate.Value; ;
                    _oSCMPI.Remarks = txtRemarks.Text;
                    _oSCMPI.Status = (int)Dictionary.SCMStatus.PIReceive;
                    _oSCMPI.ExpectedGRDWeek = nExGRDWeek;
                    _oSCMPI.ExpectedGRDYear = nExGRDYear;
                    _oSCMPI.PIValue = Convert.ToDouble(txtPIValue.Text);
                    _oSCMPI.PICurrency = cmbPICurrency.SelectedIndex;
                    _oSCMPI.InsertPIBEIL();

                    #region BOMItem from PI
                    foreach (DSBOM.BOMItemRow oItemRow in _oDSBOMData.BOMItem)
                    {
                        if (oItemRow.BOMQty > 0)
                        {
                            SCMPIBOMItem _oSCMBOMItem = new SCMPIBOMItem();

                            _oSCMBOMItem.PIID = _oSCMPI.PIID;
                            _oSCMBOMItem.ProductID = Convert.ToInt32(oItemRow.ProductID);
                            _oSCMBOMItem.BOMID = Convert.ToInt32(oItemRow.BOMID);
                            _oSCMBOMItem.PIQty = oItemRow.BOMQty;
                            _oSCMBOMItem.Insert();

                        }
                    }
                    #endregion

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

        private void frmSCMPIBEIL_Load(object sender, EventArgs e)
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
    }
}