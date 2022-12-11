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
    public partial class frmPOSOutletDisplayPosition : Form
    {
        ProductDetail _oProductDetail;
        ProductDetail _oMAG;
        Product _oProduct;
        ProductBarcodes _oProductBarcodes;
        ProductBarcode _oProductBarcode;
        int nDisplayPositionID = 0;
        int nWHID = 0;
        int nMAGID = 0;
        string sPositionCode = "";
        OutletDisplayPosition _oOutletDisplayPosition;
        string sMAGName = "";
        public bool _IsTrue = false;
        SystemInfo _oSystemInfo;

        string _sMAGName = "";
        bool _bOpenForAll = false;

        public frmPOSOutletDisplayPosition()
        {
            InitializeComponent();

            DBController.Instance.OpenNewConnection();
            _oSystemInfo = new SystemInfo();
            _oSystemInfo.Refresh();
        }

        public void ShowDialog(OutletDisplayPosition oOutletDisplayPosition)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oOutletDisplayPosition;
            txtRackName.Text = oOutletDisplayPosition.RackName;
            txtPositionCode.Text = oOutletDisplayPosition.PositionCode;
            txtPositionName.Text = oOutletDisplayPosition.PositionName;
            txtForProduct.Text = "[" + oOutletDisplayPosition.ProductCode + "]" + oOutletDisplayPosition.ProductName;
            txtModelName.Text = oOutletDisplayPosition.ProductModel;

            if (oOutletDisplayPosition.SaleAfter != null)
            {
                lblSaleAfter.Text = Convert.ToDateTime(oOutletDisplayPosition.SaleAfter).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblSaleAfter.Text = "";
            }
            if (oOutletDisplayPosition.BlankRemarks != null)
            {
                txtBlankRemarks.Text = oOutletDisplayPosition.BlankRemarks;
            }
            else
            {
                txtBlankRemarks.Text = "";
            }
            if (oOutletDisplayPosition.OpenForAll == true)
            {
                lblOpenForAll.Text = "This Rack is Open for All Model with MAG- " + oOutletDisplayPosition.MAGName;
                lblOpenForAll.ForeColor = Color.Blue;
                _bOpenForAll = true;
            }
            else
            {
                lblOpenForAll.Text = "";
                _bOpenForAll = false;
            }

            _sMAGName = oOutletDisplayPosition.MAGName;

            nDisplayPositionID = oOutletDisplayPosition.DisplayPositionID;
            nWHID = oOutletDisplayPosition.WHID;

            _oProduct = new Product();
            _oProduct.ProductID = oOutletDisplayPosition.ProductID;
            _oProduct.RefreshByID();
            ctlProduct1.txtCode.Text = _oProduct.ProductCode;

            int nProductSerial = 0;
            _oProductBarcode = new ProductBarcode();
            _oProductBarcode.GetProductSerialID(oOutletDisplayPosition.ProductSerialNo);
            if (oOutletDisplayPosition.ProductSerialNo != "")
            {
                nProductSerial = _oProductBarcodes.GetIndex(_oProductBarcode.ProductStockSerialID);
                cmbProductSerial.SelectedIndex = nProductSerial + 1;
            }

            if (String.IsNullOrEmpty(oOutletDisplayPosition.ProductSerialNo))
            {
                btnSave.Enabled = true;
            }
            else
            {
                if (Convert.ToDateTime(oOutletDisplayPosition.SaleAfter) < Convert.ToDateTime(_oSystemInfo.OperationDate))
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }

            //if(oOutletDisplayPosition.Status==1 && oOutletDisplayPosition.SaleAfter!=null && Convert.ToDateTime(oOutletDisplayPosition.SaleAfter)<DateTime.Today)
            //{
            //    btnSave.Enabled = true;
            //}
            //else
            //{
            //    if (oOutletDisplayPosition.Status == 0 || oOutletDisplayPosition.SaleAfter == null)
            //    {
            //        btnSave.Enabled = true;
            //    }
            //    else
            //    {
            //        btnSave.Enabled = false;
            //    }
            //}

            this.ShowDialog();
        }
        private void chkIsBlank_CheckedChanged(object sender, EventArgs e)
        {
            ctlProduct1.txtCode.Text = "";
            cmbProductSerial.Items.Clear();
            cmbProductSerial.Items.Add("<Select Barcode>");
            cmbProductSerial.SelectedIndex = 0;
            //ctlProduct1_ChangeSelection(sender, e);
        }

        private void frmPOSOutletDisplayPosition_Load(object sender, EventArgs e)
        {
            this.Text = "Display Position for" + " " + sMAGName;


            //chkIsBlank.Visible = false;
        }
        private bool validateUIInput()
        {
            if (chkIsBlank.Checked)
            {
                if (txtBlankRemarks.Text.Trim() == "")
                {
                    MessageBox.Show("Please Write Blank Remarks", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlankRemarks.Focus();
                    return false;
                }
            }
            else
            {
                if (_bOpenForAll==false)
                {
                    if (ctlProduct1.txtCode.Text != "")
                    {
                        if (ctlProduct1.SelectedSerarchProduct.ProductModel.Trim() != txtModelName.Text.Trim())
                        {
                            MessageBox.Show("Position Model Name & Selected Model Name Not Matched.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlProduct1.txtCode.Focus();
                            return false;
                        }

                    }
                }
                else
                {
                    if (ctlProduct1.txtCode.Text != "")
                    {
                        if (ctlProduct1.SelectedSerarchProduct.MAGName.Trim() != _sMAGName.Trim())
                        {
                            MessageBox.Show("Position MAG Name & Selected MAG Name Not Matched.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlProduct1.txtCode.Focus();
                            return false;
                        }

                    }
                }


                if (ctlProduct1.txtCode.Text != "")
                {
                    if (cmbProductSerial.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select a ProductSerial.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbProductSerial.Focus();
                        return false;
                    }
                }

                if (cmbProductSerial.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Write Blank Remarks", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlankRemarks.Focus();
                    return false;
                }
            }


            return true;
        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oProductBarcodes = new ProductBarcodes();
            _oProductBarcodes.GetBarcodeForDisplayPosition(ctlProduct1.SelectedSerarchProduct.ProductID, nDisplayPositionID);

            cmbProductSerial.Items.Clear();
            cmbProductSerial.Items.Add("<Select Barcode>");
            if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "")
            {
                txtAssignModelName.Text = ctlProduct1.SelectedSerarchProduct.ProductModel;
                foreach (ProductBarcode oProductBarcode in _oProductBarcodes)
                {
                    cmbProductSerial.Items.Add(oProductBarcode.ProductSerialNo);
                }
                cmbProductSerial.SelectedIndex = 0;
            }
            else
            {
                txtAssignModelName.Text = "";
                _oProductBarcodes = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                _oOutletDisplayPosition = new OutletDisplayPosition();
                _oOutletDisplayPosition.DisplayPositionID = nDisplayPositionID;
                _oOutletDisplayPosition.WHID = nWHID;
                if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "")
                {
                    _oOutletDisplayPosition.AssignProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                    try
                    {
                        _oOutletDisplayPosition.ProductSerialNo = _oProductBarcodes[cmbProductSerial.SelectedIndex - 1].ProductSerialNo;
                    }
                    catch
                    {
                        _oOutletDisplayPosition.ProductSerialNo = "";
                    }
                    _oOutletDisplayPosition.Status = (int)Dictionary.DisplayPositionStatus.Fill;
                }
                else
                {
                    _oOutletDisplayPosition.ProductID = 0;
                    _oOutletDisplayPosition.AssignProductID = 0;
                    _oOutletDisplayPosition.ProductSerialNo = "";
                    _oOutletDisplayPosition.Status = (int)Dictionary.DisplayPositionStatus.Blank;

                }
                _oOutletDisplayPosition.AssignDate = DateTime.Now.Date;
                _oOutletDisplayPosition.AssignUserID = Utility.UserId;
                _oOutletDisplayPosition.BlankRemarks = txtBlankRemarks.Text;
                //if(!chkIsBlank.Checked)
                //{
                //    _oOutletDisplayPosition.SaleAfter = DateTime.Today.AddMonths(3);
                //}
                //else
                //{
                //    _oOutletDisplayPosition.SaleAfter = null;
                //}
                _oOutletDisplayPosition.OpenForAll = _bOpenForAll;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletDisplayPosition.EditForPOS();
                    _oOutletDisplayPosition.Type = _oOutletDisplayPosition.Status;
                    _oOutletDisplayPosition.CreateDate = DateTime.Now.Date;
                    _oOutletDisplayPosition.CreateUserID = Utility.UserId;
                    _oOutletDisplayPosition.AddHistory();

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_OutletDisplayPosition";
                    oDataTran.DataID = Convert.ToInt32(_oOutletDisplayPosition.DisplayPositionID);
                    oDataTran.WarehouseID = nWHID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }

                    DataTran oHistoryDataTran = new DataTran();
                    oHistoryDataTran.TableName = "t_OutletDisplayPositionHistory";
                    oHistoryDataTran.DataID = Convert.ToInt32(_oOutletDisplayPosition.HistoryID);
                    oHistoryDataTran.WarehouseID = nWHID;
                    oHistoryDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oHistoryDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oHistoryDataTran.BatchNo = 0;
                    if (oHistoryDataTran.CheckData() == false)
                    {
                        oHistoryDataTran.AddForTDPOS();
                    }

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _IsTrue = true;
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            _IsTrue = false;
            this.Close();
        }

        private void cmbProductSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductSerial.SelectedIndex != 0)
            {
                txtBlankRemarks.Text = "";
                txtBlankRemarks.Enabled = false;
            }
            else
            {
                txtBlankRemarks.Enabled = true;
            }
        }
    }
}