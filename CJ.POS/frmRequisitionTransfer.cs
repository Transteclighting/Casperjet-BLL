using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using CJ.POS.TELWEBSERVER;
using CJ.Class;


namespace CJ.POS
{
    public partial class frmRequisitionTransfer : Form
    {
        Service oService;
        DSWarehouse oDSFromWarehouse;
        DSWarehouse oDSToWarehouse;       
        DSRequisition _oDSRequisition;
        DSRequisition oDSRequisitionItem;
        DSBarcodeDetail oDSBarcodeDetail;
        bool IsIsProductSerialSkip = false;

        int nRequisitionID = 0;
        string sBarcodeList = "";
        string[] BarcodeList = new string[10000];

        public frmRequisitionTransfer()
        {
            InitializeComponent();
        }

        private void frmRequisitionTransfer_Load(object sender, EventArgs e)
        {        
            

        }
        public void Loadcmb()
        {
            cmbFromWarehouse.Items.Clear();
            oDSFromWarehouse = new DSWarehouse();
            oService = new Service();
            DSWarehouse.WarehouseRow oWarehouseRow = oDSFromWarehouse.Warehouse.NewWarehouseRow();
           // oWarehouseRow.UserID = Utility.UserId.ToString();
            oDSFromWarehouse.Warehouse.AddWarehouseRow(oWarehouseRow);
            oDSFromWarehouse.AcceptChanges();

            oDSFromWarehouse = oService.FromWarehouse(oDSFromWarehouse);

            if (oDSFromWarehouse != null)
            {
                cmbFromWarehouse.ValueMember = "WarehouseID";
                cmbFromWarehouse.DisplayMember = "WarehouseName";
                cmbFromWarehouse.DataSource = oDSFromWarehouse.Warehouse;

            }
        }
        public void ShowDialog(DSRequisition oDSRequisition)
        {
            nRequisitionID = 0;
            cmbFromWarehouse.Enabled = false;
            cmbToWarehouse.Enabled = false;
            try
            {
                Loadcmb();
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtRequisitionDate.Value = Convert.ToDateTime(oDSRequisition.Requisition[0].RequisitionDate);
            cmbFromWarehouse.SelectedValue = int.Parse(oDSRequisition.Requisition[0].FromWHID);
            cmbToWarehouse.SelectedValue = int.Parse(oDSRequisition.Requisition[0].ToWHID);
            txtRemarks.Text = oDSRequisition.Requisition[0].Remarks;

            nRequisitionID = int.Parse(oDSRequisition.Requisition[0].RequisitionID);

            this.Tag = oDSRequisition;

            oDSRequisitionItem = new DSRequisition();
            oService = new Service();
            try
            {
                oDSRequisitionItem = oService.RequisitionRefreshItem(oDSRequisitionItem, nRequisitionID);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DSRequisition.RequisitionItemRow oRequisitionItemRow in oDSRequisitionItem.RequisitionItem)
            {
                if (oRequisitionItemRow.AuthorizeQty > 0)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);

                    oRow.Cells[0].Value = oRequisitionItemRow.ProductCode;
                    oRow.Cells[1].Value = oRequisitionItemRow.ProductName;
                    oRow.Cells[2].Value = oRequisitionItemRow.AuthorizeQty;
                    oRow.Cells[3].Value = "";
                    oRow.Cells[4].Value = oRequisitionItemRow.ProductID;

                    dgvLineItem.Rows.Add(oRow);
                }
            }
            oService = new Service();
            try
            {
                if (oService.GetParentWarehouse(int.Parse(cmbFromWarehouse.SelectedValue.ToString())) != Utility.TDOID)
                {
                    dgvLineItem.Columns[3].ReadOnly = false;
                    dgvLineItem.Columns[3].DefaultCellStyle.BackColor = Color.White;
                    IsIsProductSerialSkip = true;
                    btBarcodeValid.Enabled = false;
                    btSave.Enabled = true;
                }
                else
                {
                    dgvLineItem.Columns[3].ReadOnly = true;
                    dgvLineItem.Columns[3].DefaultCellStyle.BackColor = Color.Silver;
                    IsIsProductSerialSkip = false;
                    btBarcodeValid.Enabled = true;
                    btSave.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.ShowDialog();
        }

        private void cmbFromWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            oDSToWarehouse = new DSWarehouse();
            oService = new Service();
            try
            {
                oDSToWarehouse = oService.ToWarehouse(oDSToWarehouse, cmbFromWarehouse.SelectedValue.ToString());
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (oDSToWarehouse != null)
            {
                cmbToWarehouse.ValueMember = "WarehouseID";
                cmbToWarehouse.DisplayMember = "WarehouseName";
                cmbToWarehouse.DataSource = oDSToWarehouse.Warehouse;

            }
        }

        private void btBarcodeValid_Click(object sender, EventArgs e)
        {
            int nCount = 0;           
            bool _bError = false;
            string sErrorMsg = "";

            if (BarcodeValidation()) //1st level validation at UI: Barcode Length and Format (numeric)
            {
                //Load Barcodes in DS to send Server for 2nd level validation.
                oDSBarcodeDetail = new DSBarcodeDetail();
                foreach (string sBarcode in BarcodeList)
                {
                    DSBarcodeDetail.BarcodeDetailRow oBarcodeDetailRow = oDSBarcodeDetail.BarcodeDetail.NewBarcodeDetailRow();
                    oBarcodeDetailRow.ProductCode = "";
                    oBarcodeDetailRow.Barcode = sBarcode;
                    oDSBarcodeDetail.BarcodeDetail.AddBarcodeDetailRow(oBarcodeDetailRow);
                    oDSBarcodeDetail.AcceptChanges();

                }

                //2nd level validation at Web Server: Validity of Barcode (Match with product)
                try
                {
                    oService = new Service();
                    oDSBarcodeDetail = oService.BarcodeValidation(oDSBarcodeDetail);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DSBarcodeDetail.BarcodeDetailRow _oBarcodeDetailRow in oDSBarcodeDetail.BarcodeDetail)
                {
                    if (_oBarcodeDetailRow.Result != "1")
                    {
                        _bError = true;
                        if (sErrorMsg == "")
                            sErrorMsg = _oBarcodeDetailRow.Result;
                        else sErrorMsg = sErrorMsg + "," + _oBarcodeDetailRow.Result;

                        btSave.Enabled = false;
                    }
                }
                if (_bError != true)
                {
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            nCount = 0;

                            foreach (DSBarcodeDetail.BarcodeDetailRow _oBarcodeDetailRow in oDSBarcodeDetail.BarcodeDetail)
                            {

                                if (oItemRow.Cells[0].Value.ToString() == _oBarcodeDetailRow.ProductCode)
                                {
                                    nCount++;
                                    _oBarcodeDetailRow.Check = "1";
                                    _oBarcodeDetailRow.ProductID = oItemRow.Cells[4].Value.ToString();
                                    oItemRow.Cells[3].Value = nCount;
                                }

                            }
                        }
                    }                  

                    // Check Greater or zero Qty
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {

                            if (oItemRow.Cells[3].Value.ToString() != "")
                            {
                                if (int.Parse(oItemRow.Cells[2].Value.ToString()) < int.Parse(oItemRow.Cells[3].Value.ToString()) || int.Parse(oItemRow.Cells[3].Value.ToString()) == 0)
                                {
                                    _bError = true;
                                    if (sErrorMsg == "")
                                        sErrorMsg = oItemRow.Cells[0].Value.ToString();
                                    else sErrorMsg = sErrorMsg + "," + oItemRow.Cells[0].Value;
                                }
                            }
                        }
                    }
                    if (_bError == true)
                    {
                        sErrorMsg = sErrorMsg + '\n' + "Barcode Qty is Greater Than  Authorize Requisition Qty or Zero";
                    }

                    // Check different product enter                        

                    foreach (DSBarcodeDetail.BarcodeDetailRow _oBarcodeDetailRow in oDSBarcodeDetail.BarcodeDetail)
                    {
                        if (_oBarcodeDetailRow.Check == "0")
                        {
                            _bError = true;
                            if (sErrorMsg == "")
                                sErrorMsg = _oBarcodeDetailRow.Barcode;
                            else sErrorMsg = sErrorMsg + "," + _oBarcodeDetailRow.Barcode;
                        }
                    }
                    if (_bError == true)
                    {
                        sErrorMsg = sErrorMsg + '\n' + "These are not Barcode of required  Product";
                    }

                    if (_bError != true)
                    {
                        btSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(sErrorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btSave.Enabled = false;
                    }

                }
                else
                {
                    MessageBox.Show(sErrorMsg + '\n' + "These Barcode is not valid Barcode ,these is not match with product or these barcode already use", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btSave.Enabled = false;
                }
            }
          

        }

        private void btSave_Click(object sender, EventArgs e)
        {         
            _oDSRequisition = (DSRequisition)this.Tag;         
            oDSRequisitionItem = new DSRequisition();

            //Loop for Grid View

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    DSRequisition.RequisitionItemRow oRequisitionItemRow = oDSRequisitionItem.RequisitionItem.NewRequisitionItemRow();

                    oRequisitionItemRow.RequisitionID = "-1";
                    oRequisitionItemRow.ProductID = oItemRow.Cells[4].Value.ToString().Trim();
                    oRequisitionItemRow.AuthorizeQty = int.Parse(oItemRow.Cells[2].Value.ToString().Trim());
                    oRequisitionItemRow.TransferQty = oItemRow.Cells[3].Value.ToString().Trim();
                    oDSRequisitionItem.RequisitionItem.AddRequisitionItemRow(oRequisitionItemRow);
                    oDSRequisitionItem.AcceptChanges();
                }
            }

            oService = new Service();
            try
            {
                if (IsIsProductSerialSkip)
                {
                    oDSBarcodeDetail = new DSBarcodeDetail();
                    _oDSRequisition = oService.ProductStockTranInsert(_oDSRequisition, oDSRequisitionItem, oDSBarcodeDetail, Utility.UserId, IsIsProductSerialSkip);
                }
                else _oDSRequisition = oService.ProductStockTranInsert(_oDSRequisition, oDSRequisitionItem, oDSBarcodeDetail, Utility.UserId, IsIsProductSerialSkip);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_oDSRequisition.Requisition[0].Result == "1")
            {
                MessageBox.Show("You Have Successfully Transfer Requisition, Requisition No - " + _oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show(_oDSRequisition.Requisition[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool BarcodeValidation()
        {
            int i = 0,j;
            bool _bError = false;
            string sErrorMsg = "";
            Regex rgBarcode = new Regex("^[0-9]*$");
            sBarcodeList = txtBarcodeList.Text;
            BarcodeList = sBarcodeList.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sBarcode in BarcodeList)
            {
                if (rgBarcode.IsMatch(sBarcode))
                {
                }
                else
                {
                    _bError = true;
                    sErrorMsg = sErrorMsg + sBarcode + "  - Barcode  is not valid format" + '\n';
                }
                if (sBarcode.Length > 15 || sBarcode.Length < 8)
                {
                    _bError = true;
                    sErrorMsg = sErrorMsg + sBarcode + "  - Barcode Size is Invalid " + '\n';
                }
                for (j = i + 1; j < BarcodeList.Length; j++)
                {
                    if (sBarcode == BarcodeList[j])
                    {
                        _bError = true;
                        sErrorMsg = sErrorMsg + sBarcode + "  - Barcode is Duplicates " + '\n';
                    }                   
                }
                i++;
            }
            if (_bError == true)
            {            
                sErrorMsg =  '\n' + sErrorMsg + "Barcode length should be within 8 to 15 and only digit and Unique";
                MessageBox.Show(sErrorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }      

            return true;
        }
    }
}