using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.POS
{
    public partial class frmUnsoldDefectiveProduct : Form
    {
        ProductDetail _oProductDetail;
        ProductBarcodes _oProductBarcodes;

        ProductBarcode _oProductBarcode;
        SystemInfo _oSystemInfo;
        UnsoldDefectiveProduct oUnsoldDefectiveProduct;
        int nDefectiveID;
        int nOutletID;
        string sDefectiveProductNo;
        string sBarcode;
        string sOriginalSL;
        public frmUnsoldDefectiveProduct()
        {
            InitializeComponent();

        }

        private void frmUnsoldDefectiveProduct_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Defective Product";
                LoadCombos();

            }
            else
            {
                this.Text = "Edit Defective Product";

            }
            txtRefNo.Enabled = false;
            txtRefTrandate.Enabled = false;

        }

        private void LoadCombos()
        {

            cmbDefectiveType.Items.Clear();
            cmbDefectiveType.Items.Add("<Select Defective Type>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsoldDefectiveProductType)))
            {
                cmbDefectiveType.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), GetEnum));
            }
            cmbDefectiveType.SelectedIndex = 0;

        }

        public void SetUI(ProductDetail _oProductDetail)
        {
            _oProductBarcodes = new ProductBarcodes();
            _oProductBarcodes.GetProductBarcodeByProductID(_oProductDetail.ProductID);

            if (_oProductDetail.ProductID != null)
            {
                cmbBarcode.Items.Clear();
                cmbBarcode.Items.Add("<Select Barcode>");
                foreach (ProductBarcode oProductBarcode in _oProductBarcodes)
                {
                    cmbBarcode.Items.Add(oProductBarcode.ProductSerialNo);
                }
                cmbBarcode.SelectedIndex = 0;
            }

            else _oProductBarcodes = null;

         
            //_oProductBarcodes.GetRefNoByProductBarcode(_oProductBarcodes[cmbBarcode.SelectedIndex].ProductSerialNo);

        }
        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "")
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                _oProductDetail.RefreshForDefectiveProduct();
                SetUI(_oProductDetail);
            }
        }
        private bool validateUIInput()
        {
            if (ctlProduct1.SelectedSerarchProduct == null || ctlProduct1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.Focus();
                return false;
            }
            if (cmbBarcode.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a ProductSerial.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBarcode.Focus();
                return false;
            }
            if (txtOriginalSerial.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Original Serial.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOriginalSerial.Focus();
                return false;
            }
            if (cmbDefectiveType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Defective Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDefectiveType.Focus();
                return false;
            }
            if (txtFault.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Fault Description.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFault.Focus();
                return false;
            }
            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Valid Reason.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return false;
            }
            //if (cmbDefectiveType.SelectedIndex == (int)Dictionary.UnsoldDefectiveProductType.Aesthetic_Minor)
            //{
            if (txtProposeDicAmt.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Propose Discount Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProposeDicAmt.Focus();
                return false;

            }
            //}
            return true;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(UnsoldDefectiveProduct oUnsoldDefectiveProduct)
        {

            this.Tag = oUnsoldDefectiveProduct;
            LoadCombos();
            nDefectiveID = 0;
            nOutletID = 0;
            sDefectiveProductNo = "";
            sBarcode = "";
            sOriginalSL = "";
            nDefectiveID = oUnsoldDefectiveProduct.DefectiveID;
            sDefectiveProductNo = oUnsoldDefectiveProduct.DefectiveNo;
            nOutletID = oUnsoldDefectiveProduct.WarehouseID;
            sBarcode = oUnsoldDefectiveProduct.BarcodeSL;
            sOriginalSL= oUnsoldDefectiveProduct.OriginalSL;
            ctlProduct1.txtCode.Text = oUnsoldDefectiveProduct.ProductCode;
            cmbDefectiveType.SelectedIndex = oUnsoldDefectiveProduct.DefectiveType;
            txtFault.Text = oUnsoldDefectiveProduct.Fault;
            txtReason.Text = oUnsoldDefectiveProduct.Reason;
            txtRemarks.Text = oUnsoldDefectiveProduct.Remarks.ToString();
            txtProposeDicAmt.Text = Convert.ToDouble(oUnsoldDefectiveProduct.ProposeDicAmount).ToString();
            //txtJobNo.Text = oUnsoldDefectiveProduct.JobNo.ToString();
            txtOriginalSerial.Text = sOriginalSL;
            txtRefTrandate.Text = Convert.ToDateTime(oUnsoldDefectiveProduct.RefTranDate).ToString("dd-MMM-yyyy");
            txtRefNo.Text = oUnsoldDefectiveProduct.RefTranNo;
            cmbBarcode.Text = sBarcode;
            this.ShowDialog();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (validateUIInput())
                {
                    oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    _oSystemInfo = new SystemInfo();
                    _oSystemInfo.Refresh();
                    _oProductBarcodes = new ProductBarcodes();
                    _oProductBarcodes.GetProductBarcodeByProductID(_oProductDetail.ProductID);
                    oUnsoldDefectiveProduct.WarehouseID = _oSystemInfo.WarehouseID;
                    oUnsoldDefectiveProduct.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                    oUnsoldDefectiveProduct.BarcodeSL = _oProductBarcodes[cmbBarcode.SelectedIndex-1].ProductSerialNo;
                    oUnsoldDefectiveProduct.OriginalSL = txtOriginalSerial.Text;
                    oUnsoldDefectiveProduct.DefectiveType = cmbDefectiveType.SelectedIndex;
                    oUnsoldDefectiveProduct.Fault = txtFault.Text;
                    oUnsoldDefectiveProduct.Reason = txtReason.Text;
                    oUnsoldDefectiveProduct.Remarks = txtRemarks.Text;
                    oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Create;
                    oUnsoldDefectiveProduct.CreateUserID = Utility.UserId;
                    oUnsoldDefectiveProduct.CreateDate = DateTime.Now;
                    oUnsoldDefectiveProduct.RefTranNo = txtRefNo.Text;
                    oUnsoldDefectiveProduct.RefTranDate = Convert.ToDateTime(txtRefTrandate.Text);
                    //oUnsoldDefectiveProduct.JobNo = txtJobNo.Text;
                    if (txtProposeDicAmt.Text.Trim() != "")
                    {
                        oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(txtProposeDicAmt.Text);
                        
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ProposeDicAmount = 0;
                    
                    }
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oUnsoldDefectiveProduct.InsertDefectiveProduct();

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
            else
            {
                if (validateUIInput())
                {
                    oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    _oSystemInfo = new SystemInfo();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    _oSystemInfo.Refresh();
                    oUnsoldDefectiveProduct.DefectiveID = nDefectiveID;
                    oUnsoldDefectiveProduct.WarehouseID = _oSystemInfo.WarehouseID;
                    oUnsoldDefectiveProduct.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                    oUnsoldDefectiveProduct.BarcodeSL = _oProductBarcodes[cmbBarcode.SelectedIndex - 1].ProductSerialNo;
                    oUnsoldDefectiveProduct.OriginalSL = txtOriginalSerial.Text;
                    oUnsoldDefectiveProduct.DefectiveType = cmbDefectiveType.SelectedIndex;
                    oUnsoldDefectiveProduct.Fault = txtFault.Text;
                    oUnsoldDefectiveProduct.Reason = txtReason.Text;
                    oUnsoldDefectiveProduct.Remarks = txtRemarks.Text;
                    oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Create;
                    oUnsoldDefectiveProduct.CreateUserID = Utility.UserId;
                    oUnsoldDefectiveProduct.CreateDate = DateTime.Now;
                    oUnsoldDefectiveProduct.RefTranNo = txtRefTrandate.Text;
                    oUnsoldDefectiveProduct.RefTranDate = Convert.ToDateTime(txtRefTrandate.Text);
                    //oUnsoldDefectiveProduct.JobNo = txtJobNo.Text;
                    if (txtProposeDicAmt.Text.Trim() != "")
                    {
                        oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(txtProposeDicAmt.Text);

                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ProposeDicAmount = 0;
                    }

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oUnsoldDefectiveProduct.EditDefectiveProduct();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }

        }

        private void cmbBarcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBarcode.SelectedIndex != 0)
            {
                _oProductBarcode = new ProductBarcode();

                _oProductBarcode.ProductSerialNo = _oProductBarcodes[cmbBarcode.SelectedIndex - 1].ProductSerialNo;
                _oProductBarcode.Refresh(_oProductBarcode.ProductSerialNo);
                 txtRefNo.Text = _oProductBarcode.TranNo;
                 txtRefTrandate.Text = Convert.ToDateTime(_oProductBarcode.TranDate).ToString("dd-MMM-yyyy");

            }


        }

        private void cmbDefectiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbDefectiveType.SelectedIndex == (int)Dictionary.UnsoldDefectiveProductType.Aesthetic_Minor)
            //{
            //    txtProposeDicAmt.Enabled = true;

            //}
            //else
            //{
            //    txtProposeDicAmt.Enabled = true;
            //}
        }

    }
}