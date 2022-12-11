using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Promotion;
using CJ.Class.POS;
using System.Text.RegularExpressions;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;
using CJ.Class.Warranty;
using CJ.Class.CLP;
using CJ.Class.Duty;



namespace CJ.POS.Invoice
{
    public partial class frmRetailInvoice : Form
    {
        private SalesLead oSalesLead;

        public SalesLead SelectedLeadCustomer
        {
            get
            {
                return oSalesLead;
            }
        }

        DSSalesInvoiceDiscount oDsSalesInvoiceDiscount;
        int IsChkVatEntry = 0;
        string _sCHKSerialNo = "";
        int nTotalQty = 0;
        int nLeadConsumer = 0;
        int nIsExistingConsumer = 0;
        int nLeadID = 0;
        Employees oEmployees;
        ProductDetail _oProductDetail;
        SPProduct oSPProduct;
        SPProducts oSPProducts;
        WUIUtility oWUIUtility;
        SPromotions oSPromotions;
        SPromotions oResultSPromotions;
        SPromotions oSelectedSPromotions;
        SPromotion oResultSPromotion;
        RetailConsumer oRetailConsumer;
        SalesInvoice _oSalesInvoice;
        CustomerTransaction _oCustomerTransaction;
        User oUser = new User();
        SystemInfo oSystemInfo;
        Branchs _oBranchs;
        Utilities oPaymentMode;
        StockTran _oStockTran;
        ProductStock _oProductStock;
        ProductTransaction _oProductTransaction;
        RetailSalesInvoice oRetailSalesInvoice;
        rptSalesInvoice orptSalesInvoice;
        WarrantyProducts oWarrantyProducts;
        WarrantyParameter oWarrantyParameter;
        TELLib oTELLib;
        DSSalesInvoiceDetail oDSSalesInvoiceProduct;
        DSSalesInvoiceDetail oDSFreeGiftProduct;
        DSSalesInvoiceDetail oDSSalesInvoiceDetail;
        CLPEligibility oCLPEligibility;
        CLPPoint oCLPPoint;
        CLPPointSlab oCLPPointSlab;
        CLPTran oCLPTran;
        SPSlabAllRatio _oSPSlabAllRatio;
        SPSlabRatio _oSPSlabRatio;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        SalesInvoiceProductSerials _oSIPSs;
        SalesInvoicePromotionFor _oSalesInvoicePromotionFor;
        SalesInvoicePromotionOffer _oSalesInvoicePromotionOffer;
        SalesInvoiceScratchCardInfo _oSalesInvoiceScratchCardInfo;
        SalesInvoicePromotionMapping _oSalesInvoicePromotionMapping;
        SalesInvoicePromotionMappings _oSalesInvoicePromotionMappings;
        SPProductGroup _oSPProductGroup;
        SPProductGroups _oSPProductGroups;
        DataTran _oDataTran;
        PaymentModes _oPaymentModes;
        DiscountReasons _oDiscountReasons;
        Product _oProduct;
        SalesPromotionTypes _oSalesPromotionTypes;
        SalesPromotionType _oSalesPromotionType;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;
        DutyTran oDutyTranVAT63;
        DutyAccount oDutyAccount;
        //string sProduct = "";
        string SL = "";
        Image iImage;
        string sApprove_Credit_No = "";
        double _MarkUpAMount = 0;
        double _TotalDiscount = 0;
        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;
        double _NewDutyBalance = 0;
        private int nArrayLen = 0;
        private int nDisplayPrmoCount = 0;
        private string[] sProductBarcodeArr = null;
        int _nUIControl = 0;
        string _sNumbers = "";
        int nConsumerID = 0;
        int nCustomerID = 0;
        int nConsumerSalesType = 0;
        int nTabClickCount = 0;
        CustomerDetail oCustomerDetail;
        int[] ProductIDList ={ 9, 1823, 2810, 2935, 2936, 2937 };
        public frmRetailInvoice(int nUIControl, string sNo)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
            _sNumbers = sNo;
        }

        private void frmRetailInvoice_Load(object sender, EventArgs e)
        {
            oUser.UserId = Utility.UserId;
            oUser.EmployeeID = Utility.EmployeeID;
            UILoad(_nUIControl);
            LoadData();
        }
        private void UILoad(int nUIControl)
        {
            if (nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
            {
                this.Text = "Retail Invoice";
                lblEmployee.Visible = false;
                strEmployee.Visible = false;
                strHPA.Visible = false;
                txtEmployeeNo.Visible = false;
                lblHPA.Visible = false;
                ctlCustomer1.Visible = false;

                ctlRetailConsumer1.Enabled = false;
                txtLeadNo.Visible = false;
                btnPicker.Visible = false;
                txtLeadCustName.Visible = false;

                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;
            }
            else if (nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
            {
                this.Text = "Corporate Invoice (B2C)";
                lblEmployee.Visible = true;
                txtEmployeeNo.Visible = true;
                lblHPA.Visible = true;
                ctlCustomer1.Visible = true;
                lblHPA.Text = "Corporate Cust:";
                strHPA.Visible = true;
                strEmployee.Visible = true;

                ctlRetailConsumer1.Enabled = false;
                txtLeadNo.Visible = false;
                btnPicker.Visible = false;
                txtLeadCustName.Visible = false;
                
                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;

            }
            else if (nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
            {
                this.Text = "Corporate Invoice (B2B)";
                lblEmployee.Visible = true;
                txtEmployeeNo.Visible = true;
                lblHPA.Visible = true;
                ctlCustomer1.Visible = true;
                lblHPA.Text = "Corporate Cust:";
                strHPA.Visible = true;
                strEmployee.Visible = true;
                //grpConsumerInfo.Enabled = false;
                rdoNewConsumer.Enabled = false;
                rdoExistingConsumer.Enabled = false;

                rdoLeadCust.Enabled = true;
                rdoLeadCust.Checked = true;
                txtLeadNo.Enabled = true;
                btnPicker.Enabled = true;
                txtLeadCustName.Enabled = true;

                ctlRetailConsumer1.Enabled = false;
                txtCustomerName.Enabled = false;
                cmbConType.Enabled = false;
                txtCustomerAddress.Enabled = false;
                txtEmail.Enabled = false;
                txtCell.Enabled = false;
                txtEmployeeNo.Enabled = false;
                txtNationalID.Enabled = false;
                txtTelePhone.Enabled = false;
                dtDateofBirth.Enabled = false;
                txtVatRegNo.Enabled = false;

                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;

            }
            else if (nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
            {
                this.Text = "Retail Invoice (HPA)";
                lblEmployee.Visible = false;
                txtEmployeeNo.Visible = false;
                strEmployee.Visible = false;
                lblHPA.Visible = true;
                ctlCustomer1.Visible = true;
                lblHPA.Text = "HPA Customer:";
                strHPA.Visible = true;

                ctlRetailConsumer1.Enabled = false;
                txtLeadNo.Visible = false;
                btnPicker.Visible = false;
                txtLeadCustName.Visible = false;

                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;
            }
            else if (nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
            {
                this.Text = "Dealer Invoice";
                lblEmployee.Visible = false;
                txtEmployeeNo.Visible = false;
                strEmployee.Visible = false;
                lblHPA.Visible = true;
                ctlCustomer1.Visible = true;
                lblHPA.Text = "Dealer:";
                strHPA.Visible = true;
                //grpConsumerInfo.Enabled = false;
                rdoNewConsumer.Enabled = false;
                rdoExistingConsumer.Enabled = false;

                rdoLeadCust.Enabled = true;
                rdoLeadCust.Checked = true;
                txtLeadNo.Enabled = true;
                btnPicker.Enabled = true;
                txtLeadCustName.Enabled = true;

                ctlRetailConsumer1.Enabled = false;
                txtCustomerName.Enabled = false;
                cmbConType.Enabled = false;
                txtCustomerAddress.Enabled = false;
                txtEmail.Enabled = false;
                txtCell.Enabled = false;
                txtEmployeeNo.Enabled = false;
                txtNationalID.Enabled = false;
                txtTelePhone.Enabled = false;
                dtDateofBirth.Enabled = false;
                txtVatRegNo.Enabled = false;

                lblBGAmount.Visible = true;
                lblBGAmt.Visible = true;
                lblCustomerBalance.Visible = true;
                lblCustomerBalanceAmt.Visible = true;


            }
            else if (nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
            {
                this.Text = "e-Store Invoice";
                lblEmployee.Visible = false;
                strEmployee.Visible = false;
                strHPA.Visible = false;
                txtEmployeeNo.Visible = false;
                lblHPA.Visible = false;
                ctlCustomer1.Visible = false;

                ctlRetailConsumer1.Enabled = false;

                txtLeadNo.Visible = false;
                btnPicker.Visible = false;
                txtLeadCustName.Visible = false;

                rdoNewConsumer.Enabled = false;
                rdoExistingConsumer.Enabled = false;
                rdoLeadCust.Enabled = false;
                rdoLeadCust.Checked = true;
                
                txtLeadNo.Enabled = false;
                btnPicker.Enabled = false;
                txtLeadCustName.Enabled = false;


                txtLeadNo.Text = _sNumbers;

                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;

            }

        }

        public void LoadData()
        {
            oEmployees = new Employees();
            cmbEmpoyee.Items.Clear();
            _oDiscountReasons = new DiscountReasons();
            cmbDiscountReason.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oEmployees.GetShowroomSalesPerson();
            cmbEmpoyee.Items.Add("<Select Sales Person>");
            foreach (Employee oEmployee in oEmployees)
            {
                cmbEmpoyee.Items.Add(oEmployee.EmployeeName);
            }
            if (oEmployees.Count > 0)
                cmbEmpoyee.SelectedIndex = 0;

            _oDiscountReasons.Refresh();
            cmbDiscountReason.Items.Add("<Select Reason>");
            foreach (DiscountReason oDiscountReason in _oDiscountReasons)
            {
                cmbDiscountReason.Items.Add(oDiscountReason.Description);
            }
            if (_oDiscountReasons.Count > 0)
                cmbDiscountReason.SelectedIndex = 0;

            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh((int)Dictionary.YesOrNoStatus.YES);
            cmbPromotionType.Items.Add("<Select Promotion Type>");
            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                cmbPromotionType.Items.Add(oSalesPromotionType.SalesPromotionTypeName);
            }
            if (_oSalesPromotionTypes.Count > 0)
                cmbPromotionType.SelectedIndex = 0;

            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            if (oSystemInfo.OperationDate != null)
            {
                dtInvoiceDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate.ToString()).Date;
                dtDeliveryDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate.ToString()).Date;
            }
            else
            {
                MessageBox.Show("Please Start Operation Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            cmbDeliveryPoint.Items.Add(oSystemInfo.WarehouseName);
            cmbDeliveryPoint.SelectedIndex = 0;

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.RetailCustomerType)))
            {
                cmbConType.Items.Add(Enum.GetName(typeof(Dictionary.RetailCustomerType), GetEnum));
            }
            cmbConType.SelectedIndex = 0;

            //_oBranchs = new Branchs();
            DBController.Instance.OpenNewConnection();
            //_oBranchs.GetAllBranch();

            _oPaymentModes = new PaymentModes();
            _oPaymentModes.Refresh();

            Banks oBanks = new Banks();
            oBanks.Refresh();

            ShowroomAssets oShowroomAssets = new ShowroomAssets();
            oShowroomAssets.Refresh(Dictionary.ShowroomAssetType.POSMachine);

            Utilities oIsEMI = new Utilities();
            oIsEMI.GetIsEMI();

            DataGridViewComboBoxColumn ColumnPaymentMode = new DataGridViewComboBoxColumn();
            ColumnPaymentMode.DataPropertyName = "PaymentMode";
            ColumnPaymentMode.HeaderText = "Payment Mode";
            ColumnPaymentMode.Width = 120;
            ColumnPaymentMode.DataSource = _oPaymentModes;
            ColumnPaymentMode.ValueMember = "PaymentModeID";
            ColumnPaymentMode.DisplayMember = "PaymentModeName";
            dgvPayment.Columns.Add(ColumnPaymentMode);

            DataGridViewTextBoxColumn txtAmount = new DataGridViewTextBoxColumn();
            txtAmount.HeaderText = "Amount";
            txtAmount.Width = 90;
            dgvPayment.Columns.Add(txtAmount);

            DataGridViewComboBoxColumn ColumnItem = new DataGridViewComboBoxColumn();
            ColumnItem.DataPropertyName = "Bank";
            ColumnItem.HeaderText = "Bank";
            ColumnItem.Width = 120;
            ColumnItem.DataSource = oBanks;
            ColumnItem.ValueMember = "BankID";
            ColumnItem.DisplayMember = "Name";
            dgvPayment.Columns.Add(ColumnItem);

            Utilities oCreditCardType = new Utilities();
            oCreditCardType.GetCreditCardType();

            DataGridViewComboBoxColumn ColumnItem3 = new DataGridViewComboBoxColumn();
            ColumnItem3.DataPropertyName = "CreditCardType";
            ColumnItem3.HeaderText = "Card Type";
            ColumnItem3.Width = 80;
            ColumnItem3.DataSource = oCreditCardType;
            ColumnItem3.ValueMember = "SatusId";
            ColumnItem3.DisplayMember = "Satus";
            dgvPayment.Columns.Add(ColumnItem3);

            DataGridViewComboBoxColumn ColumnItem1 = new DataGridViewComboBoxColumn();
            ColumnItem1.DataPropertyName = "POSMachine";
            ColumnItem1.HeaderText = "POS Machine";
            ColumnItem1.Width = 120;
            ColumnItem1.DataSource = oShowroomAssets;
            ColumnItem1.ValueMember = "AssetID";
            ColumnItem1.DisplayMember = "AssetName";
            dgvPayment.Columns.Add(ColumnItem1);

            Utilities oCreditCardCategory = new Utilities();
            oCreditCardCategory.GetCreditCardCategory();

            DataGridViewComboBoxColumn ColumnItem4 = new DataGridViewComboBoxColumn();
            ColumnItem4.DataPropertyName = "Category";
            ColumnItem4.HeaderText = "Category";
            ColumnItem4.Width = 120;
            ColumnItem4.DataSource = oCreditCardCategory;
            ColumnItem4.ValueMember = "SatusId";
            ColumnItem4.DisplayMember = "Satus";
            dgvPayment.Columns.Add(ColumnItem4);

            DataGridViewTextBoxColumn txtApprovalNo = new DataGridViewTextBoxColumn();

            txtApprovalNo.HeaderText = "ApprovalNo";
            txtApprovalNo.Width = 80;
            dgvPayment.Columns.Add(txtApprovalNo);



            DataGridViewComboBoxColumn ColumnItem2 = new DataGridViewComboBoxColumn();
            ColumnItem2.DataPropertyName = "IsEMI";
            ColumnItem2.HeaderText = "Is EMI";
            ColumnItem2.Width = 50;
            ColumnItem2.DataSource = oIsEMI;
            ColumnItem2.ValueMember = "SatusId";
            ColumnItem2.DisplayMember = "Satus";
            dgvPayment.Columns.Add(ColumnItem2);

            DataGridViewTextBoxColumn txtInstallmentNo = new DataGridViewTextBoxColumn();

            txtInstallmentNo.HeaderText = "# of Installment";
            txtInstallmentNo.Width = 60;
            dgvPayment.Columns.Add(txtInstallmentNo);

            DataGridViewTextBoxColumn txtInstrumentNo = new DataGridViewTextBoxColumn();

            txtInstrumentNo.HeaderText = "Instrument No";
            txtInstrumentNo.Width = 80;
            dgvPayment.Columns.Add(txtInstrumentNo);

            DataGridViewTextBoxColumn txtInstrumentDate = new DataGridViewTextBoxColumn();

            txtInstrumentDate.HeaderText = "Instrument Date";
            txtInstrumentDate.Width = 90;
            dgvPayment.Columns.Add(txtInstrumentDate);


            cmbInvoiceType.Items.Add("<Select Invoice Type>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSInvoiceType)))
            {
                cmbInvoiceType.Items.Add(Enum.GetName(typeof(Dictionary.POSInvoiceType), GetEnum));
            }
            cmbInvoiceType.SelectedIndex = 1;
        }

        ///
        // Grid Control
        ///

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[9].Value = oForm.sProductId;
                oRow.Cells[11].Value = 0;
                if (oForm.sProductId != 0)
                {
                    oWUIUtility = new WUIUtility();
                    oWUIUtility.GetRetailStock(oSystemInfo.WarehouseID, oForm.sProductId);

                    if (oWUIUtility.CurrentStock < 0)
                        oRow.Cells[5].Value = 0;
                    else oRow.Cells[5].Value = oWUIUtility.CurrentStock;
                }
                if (oForm.sProductCode != null)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate), oForm.sProductId);


                    oRow.Cells[3].Value = _oProductDetail.RSP.ToString();
                    int nRowIndex = dgvLineItem.Rows.Add(oRow);

                    _oProduct = new Product();
                    _oProduct.ProductID = Convert.ToInt32(oForm.sProductId);
                    _oProduct.RefreshByProductID();
                    oRow.Cells[10].Value = _oProduct.IsBarcodeItem;
                    if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[6].ReadOnly = false;
                        oRow.Cells[6].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[6].ReadOnly = true;
                    }

                    if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        GetTotalRSAmount();
                    }
                }

            }
            else if (e.ColumnIndex == 8)
            {
                if (cmbDeliveryPoint.Text == "")
                {
                    MessageBox.Show("Please Select a Delivery Point.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    int temp = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[9].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Select a Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmAvailableBarcode ofrmAvailableBarcode = new frmAvailableBarcode(int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[9].Value.ToString()), oSystemInfo.WarehouseID, "", 0);
                ofrmAvailableBarcode.ShowDialog();
                if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (ofrmAvailableBarcode._nCount > 0)
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[7].Value = ofrmAvailableBarcode._sBarcode;
                        dgvLineItem.Rows[e.RowIndex].Cells[6].Value = ofrmAvailableBarcode._nCount;
                        dgvLineItem.Rows[e.RowIndex].Cells[13].Value = ofrmAvailableBarcode._sChkBarcode;
                        GetTotalRSAmount();
                    }
                }
                else
                {
                    GetTotalRSAmount();
                }
            }

        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    Product oProduct = new Product();
                    DBController.Instance.OpenNewConnection();
                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();

                    if (oProduct.Flag != true)
                    {
                        _oProductDetail = new ProductDetail();
                        _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate), oProduct.ProductID);

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP;

                        oWUIUtility = new WUIUtility();
                        oWUIUtility.GetRetailStock(oSystemInfo.WarehouseID, oProduct.ProductID);
                        if (oWUIUtility.CurrentStock < 0)
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        else dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = oWUIUtility.CurrentStock;

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = (oProduct.ProductID).ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 11].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                        _oProduct = new Product();
                        _oProduct.ProductID = Convert.ToInt32(oProduct.ProductID);
                        _oProduct.RefreshByProductID();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 10].Value = _oProduct.IsBarcodeItem;
                        if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].ReadOnly = false;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].ReadOnly = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else if (nColumnIndex == 6)
            {

                if (dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
                {
                    GetTotalRSAmount();
                }
            }


        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTotalRSAmount();
            if (tabControl1.SelectedIndex == 0)
            {
                nTabClickCount = 0;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                ///
                // Promotion Calculation 
                ///  

                if (cmbPromotionType.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Promotion Type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedIndex = 0;
                    return;
                }

                cmbPromotionType.Enabled = false;
                oTELLib = new TELLib();
                txtTotalDisount.Text = "0.00";
                txtPromoDiscount.Text = "0.00";
                txtSMSDiscount.Text = "0.00";

                dvgProduct.Rows.Clear();
                dgvDiscount.Rows.Clear();
                dgvPromoProduct.Rows.Clear();

                if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                {
                    CalculatePromotionForSlab(Utility.RetailChannelID);
                    CalculatePromotionNonSlab(Utility.RetailChannelID);
                }
                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                {
                    CalculatePromotionForSlab(Utility.TDCorporateChannelID);//New Add
                    CalculatePromotionNonSlab(Utility.TDCorporateChannelID);
                }
                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                {
                    CalculatePromotionForSlab(Utility.TDHPAChannelID);
                    CalculatePromotionNonSlab(Utility.TDHPAChannelID);
                }
                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                {
                    CalculatePromotionForSlab(Utility.TDCorporateChannelID);//New Add
                    CalculatePromotionNonSlab(Utility.TDCorporateChannelID);
                }
                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                {
                    CalculatePromotionForSlab(Utility.DealerChannelID);//New Add
                    CalculatePromotionNonSlab(Utility.DealerChannelID);
                }
                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                {
                    CalculatePromotionForSlab(16);//New Add
                    CalculatePromotionNonSlab(16);
                }
                txtTotalDisount.Text = oTELLib.TakaFormat(GetDiscountTotal());
                txtPromoDiscount.Text = oTELLib.TakaFormat(GetDiscountTotal());
                nTabClickCount++;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (nTabClickCount == 0)
                {
                    MessageBox.Show("You have to go Promotion Detail Tab", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedIndex = 1;
                    //nTabClickCount++;
                    return;
                }
                if (oTELLib != null)
                {
                    txtSMSDiscount.Text = oTELLib.TakaFormat(GetSMSDiscountTotal());
                    GetNetAmount();
                }
            }

        }

        public SPromotions GetPromotionResult(SPromotions oResultSPromotions, int nChannelID)
        {
            bool _bFlag = true;
            int nCount = 0;
            int nRatioSet = 1;
            int nIndex = 0;
            DBController.Instance.OpenNewConnection();
            oSPromotions = new SPromotions();
            if (cmbPromotionType.SelectedIndex == 0)
            {
                nIndex = 0;
            }
            else
            {
                nIndex = _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID;
            }
            oSPromotions.GetPromotionByActive(dtInvoiceDate.Value.Date, nIndex);

            foreach (SPromotion oSPromotion in oSPromotions)
            {
                _bFlag = true;
                oResultSPromotion = new SPromotion();
                ///
                // Check Channel
                ///
                nCount = 0;
                foreach (SPChannel oSPChannel in oSPromotion.SPChannels)
                {
                    if (oSPChannel.ChannelID == nChannelID)
                    {
                        nCount++;
                        break;
                    }
                }
                if (nCount == 0)
                {
                    _bFlag = false;
                    continue;
                }
                ///
                // Check Warehouse
                ///
                nCount = 0;
                foreach (SPWarehouse oSPWarehouse in oSPromotion.SPWarehouses)
                {
                    if (oSPWarehouse.WarehouseID == oSystemInfo.WarehouseID)
                    {
                        nCount++;
                        break;
                    }
                }
                if (nCount == 0)
                {
                    _bFlag = false;
                    continue;
                }
                ///
                // Check Promotional Product
                ///
                foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                {
                    //nRatioSet = oSalesPromotionSlab.RatioSet;
                }

                if (nRatioSet == 1)
                {
                    foreach (SPProduct oSPProduct in oSPromotion.SPProducts)
                    {
                        nCount = 0;
                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {
                            if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                            {
                                if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                                {
                                    nCount++;
                                }
                            }
                        }

                        if (nCount == 0)
                        {
                            _bFlag = false;
                            break;
                        }
                    }
                }
                else
                {
                    nCount = 0;
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        foreach (SPProduct oSPProduct in oSPromotion.SPProducts)
                        {
                            if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                            {
                                if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                                {
                                    nCount++;
                                    break;
                                }
                            }
                        }
                        if (nCount != 0)
                        {
                            break;
                        }
                    }

                    if (nCount == 0)
                    {
                        _bFlag = false;
                        continue;
                    }
                }

                if (_bFlag == true)
                {
                    ///
                    // Slab Checking 
                    ///                 

                    bool _IsSlab = true;
                    foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                    {
                        if (nRatioSet == 1)
                        {
                            foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                            {
                                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                                {
                                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                    {
                                        if (oSPSlabRatio.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                                        {
                                            //if (oSPSlabRatio.Qty <= int.Parse(oItemRow.Cells[3].Value.ToString()))
                                            //{
                                            //    _IsSlab = true;
                                            //}
                                            //else
                                            //{
                                            //    _IsSlab = false;
                                            //    break;
                                            //}
                                            _IsSlab = true;
                                        }
                                    }
                                }
                                if (_IsSlab == false)
                                {
                                    break;
                                }
                            }
                            if (_IsSlab)
                            {
                                oResultSPromotion.Clear();
                                oResultSPromotion.Add(oSalesPromotionSlab);
                                oResultSPromotion.SalesPromotionID = oSPromotion.SalesPromotionID;
                                oResultSPromotion.SalesPromotionNo = oSPromotion.SalesPromotionNo;
                            }
                        }
                        else
                        {
                            oResultSPromotion.Clear();
                            oResultSPromotion.Add(oSalesPromotionSlab);
                            oResultSPromotion.SalesPromotionID = oSPromotion.SalesPromotionID;
                            oResultSPromotion.SalesPromotionNo = oSPromotion.SalesPromotionNo;
                        }
                    }
                    oResultSPromotions.Add(oResultSPromotion);
                }

            }
            return oResultSPromotions;
        }
        public SPromotions GetNonSlabPromotionResult(SPromotions oResultSPromotions, int nChannelID)
        {
            bool _bFlag = true;
            int nCount = 0;
            int nRatioSet = 1;
            double _Amt = 0;
            double _TotalAmt = 0;
            DBController.Instance.OpenNewConnection();
            oSPromotions = new SPromotions();
            oSPromotions.GetPromotionByActive(dtInvoiceDate.Value.Date, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID);

            foreach (SPromotion oSPromotion in oSPromotions)
            {
                _bFlag = true;
                oResultSPromotion = new SPromotion();
                ///
                // Check Channel
                ///
                nCount = 0;
                foreach (SPChannel oSPChannel in oSPromotion.SPChannels)
                {
                    if (oSPChannel.ChannelID == nChannelID)
                    {
                        nCount++;
                        break;
                    }
                }
                if (nCount == 0)
                {
                    _bFlag = false;
                    continue;
                }
                ///
                // Check Warehouse
                ///
                nCount = 0;
                foreach (SPWarehouse oSPWarehouse in oSPromotion.SPWarehouses)
                {
                    if (oSPWarehouse.WarehouseID == oSystemInfo.WarehouseID)
                    {
                        nCount++;
                        break;
                    }
                }
                if (nCount == 0)
                {
                    _bFlag = false;
                    continue;
                }
                ///
                // Check Promotional Product
                ///

                nCount = 0;
                _Amt = 0;
                if (_bFlag == true)
                {
                    foreach (SPProductGroup oSPProductGroup in oSPromotion.SPProductGroups)
                    {
                        if (oSPromotion.SalesPromotionID == oSPProductGroup.SalesPromotionID)
                        {

                            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                            {
                                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                {
                                    int nProductID = 0;
                                    int nQty = 0;
                                    double _Amount = 0;


                                    nQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                                    _Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                    nProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                                    _oProductDetail = new ProductDetail();
                                    _oProductDetail.Refresh(nProductID);

                                    if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.Product)
                                    {
                                        if (oSPProductGroup.ProductGroupID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                                        {
                                            if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                            {
                                                _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                            }
                                            else
                                            {
                                                _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.ProductGroup)
                                        {
                                            if (_oProductDetail.PGID == oSPProductGroup.ProductGroupID)
                                            {
                                                if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                                {
                                                    _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                                }
                                                else
                                                {
                                                    _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                                }
                                            }
                                        }
                                        else if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.MAG)
                                        {
                                            if (_oProductDetail.MAGID == oSPProductGroup.ProductGroupID)
                                            {
                                                if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                                {
                                                    _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                                }
                                                else
                                                {
                                                    _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                                }
                                            }
                                        }
                                        else if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.ASG)
                                        {
                                            if (_oProductDetail.ASGID == oSPProductGroup.ProductGroupID)
                                            {
                                                if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                                {
                                                    _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                                }
                                                else
                                                {
                                                    _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                                }
                                            }
                                        }
                                        else if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.AG)
                                        {
                                            if (_oProductDetail.AGID == oSPProductGroup.ProductGroupID)
                                            {
                                                if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                                {
                                                    _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                                }
                                                else
                                                {
                                                    _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                                }
                                            }
                                        }
                                    }

                                    nCount++;
                                }

                            }
                        }


                    }
                }
                _TotalAmt = _TotalAmt + _Amt;
                if (_Amt > 0)
                {
                    InsertDiscount(oSPromotion.SalesPromotionID, 1, _Amt);
                }

            }
            txtTotalDisount.Text = _TotalAmt.ToString();
            GetNetAmount();
            return oResultSPromotions;
        }
        public void DispalyPromotionResult(SPromotions oResultSPromotions)
        {
            ///
            // Result Display
            ///     
            int nCount = 0;
            int nGetComboSlabQty = 0;
            int nRatioSet = 1;
            double _Amount = 0;
            double _TotalAmt = 0;
            //dvgProduct.Rows.Clear();
            //dgvDiscount.Rows.Clear();
            //dgvPromoProduct.Rows.Clear();
            bool _bFlag = false;

            if (oResultSPromotions.Count > 0)
            {
                foreach (SPromotion oSPromotion in oResultSPromotions)
                {

                    SPProduct _oSPProduct = new SPProduct();
                    _oSPProduct.SalesPromotionID = oSPromotion.SalesPromotionID;


                    foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                    {
                        _oSPProduct.Refresh();
                        _bFlag = _oSPProduct.Flag;

                        if (_oSPProduct.Flag == true)
                        {
                            nCount = NumberOfBonus(oSalesPromotionSlab);
                        }
                        else
                        {
                            nCount = NumberOfBonus(oSalesPromotionSlab, oSPromotion);
                            //nGetComboSlabQty = GetComboSlabQty(oSPromotion.SalesPromotionID);
                        }


                        //if (oSalesPromotionSlab.SPFlatSlab.FlatAmount > 0)
                        {
                            //ListViewItem lstItemAmount = lvwFlatAmount.Items.Add(oSPromotion.SalesPromotionNo.ToString());
                            //lstItemAmount.SubItems.Add(Convert.ToString(oSalesPromotionSlab.SPFlatSlab.FlatAmount * nCount));

                            //foreach (SalesPromotionSlab _oSalesPromotionSlab in oSPromotion)
                            //{
                            //    //nRatioSet = _oSalesPromotionSlab.RatioSet;

                            //}
                            if (_oSPProduct.Flag == true)
                            {
                                if (oSalesPromotionSlab.DiscountType != (int)Dictionary.SalesPromSlabDiscountType.None)
                                {
                                    oTELLib = new TELLib();


                                    oSPProducts = new SPProducts();
                                    oSPProducts.Refresh(oSPromotion.SalesPromotionID);
                                    int _nCount = 0;


                                    foreach (SPProduct oSPProduct in oSPProducts)
                                    {
                                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                                        {
                                            if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                            {
                                                if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                                                {
                                                    _nCount++;
                                                    _TotalAmt = _TotalAmt + int.Parse(oItemRow.Cells[3].Value.ToString());


                                                }

                                            }
                                        }

                                    }
                                    if (_nCount == oSPProducts.Count)
                                    {
                                        if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.FlatAmount)
                                        {
                                            _Amount = _Amount + ((oSalesPromotionSlab.Discount) * nCount);
                                            InsertDiscount(oSPromotion.SalesPromotionID, 1, _Amount);
                                        }
                                        else if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.Parcent)
                                        {
                                            _Amount = _Amount + ((oSalesPromotionSlab.Discount * _TotalAmt / 100) * nCount);
                                            InsertDiscount(oSPromotion.SalesPromotionID, 1, _Amount);
                                        }
                                    }
                                    //txtTotalDisount.Text = oTELLib.TakaFormat(_Amount);
                                    //txtPromoDiscount.Text = oTELLib.TakaFormat(_Amount);
                                }
                            }
                            else
                            {
                                if (oSalesPromotionSlab.DiscountType != (int)Dictionary.SalesPromSlabDiscountType.None)
                                {
                                    oSPProducts = new SPProducts();
                                    oSPProducts.Refresh(oSPromotion.SalesPromotionID);

                                    oTELLib = new TELLib();
                                    foreach (SPProduct oSPProduct in oSPProducts)
                                    {
                                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                                        {
                                            if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                            {
                                                if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                                                {
                                                    _oSPSlabAllRatio = new SPSlabAllRatio();
                                                    _oSPSlabAllRatio.GetProductRatio(oSPromotion.SalesPromotionID, oSPProduct.ProductID, Convert.ToInt32(oItemRow.Cells[6].Value.ToString()));
                                                    int nQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                                                    foreach (SPSlabRatio oSPSlabRatio in _oSPSlabAllRatio)
                                                    {
                                                        for (int i = nQty; oSPSlabRatio.Qty <= nQty; )
                                                        {
                                                            if (oSPSlabRatio.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.FlatAmount)
                                                            {
                                                                _Amount = 0;
                                                                _Amount = _Amount + (oSPSlabRatio.Discount);
                                                                InsertDiscount(oSPromotion.SalesPromotionID, oSPSlabRatio.SlabNo, _Amount);
                                                            }
                                                            else if (oSPSlabRatio.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.Parcent)
                                                            {
                                                                _Amount = 0;
                                                                double nTotalAmount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) * oSPSlabRatio.Qty;
                                                                _Amount = _Amount + (oSPSlabRatio.Discount * nTotalAmount / 100);
                                                                InsertDiscount(oSPromotion.SalesPromotionID, oSPSlabRatio.SlabNo, _Amount);
                                                            }
                                                            nQty = nQty - oSPSlabRatio.Qty;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //if (_Amount > 0)
                                    //{
                                    //    txtTotalDisount.Text = oTELLib.TakaFormat(_Amount);
                                    //    txtPromoDiscount.Text = oTELLib.TakaFormat(_Amount);
                                    //}
                                    if (dgvLineItem.Rows.Count == 1)
                                    {
                                        txtTotalDisount.Text = "0.00";
                                        txtPromoDiscount.Text = "0.00";
                                    }
                                }
                            }
                        }
                        foreach (SPFreeProduct oSPFreeProduct in oSalesPromotionSlab.SPFreeProducts)
                        {

                            _oProduct = new Product();
                            _oProduct.ProductID = oSPFreeProduct.ProductID;
                            _oProduct.RefreshByProductID();

                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dvgProduct);
                            oRow.Cells[1].Value = oSPromotion.SalesPromotionNo;
                            oRow.Cells[2].Value = _oProduct.ProductCode;
                            oRow.Cells[3].Value = _oProduct.ProductName;

                            if (_oSPProduct.Flag == true)
                            {
                                oRow.Cells[4].Value = oSPFreeProduct.Qty * nCount;
                            }
                            else
                            {
                                int nQty = GetComboSlabQty(oSPromotion.SalesPromotionID, oSPFreeProduct.ProductID, oSalesPromotionSlab.SPFreeProducts);
                                oRow.Cells[4].Value = nQty * nCount;
                            }

                            oRow.Cells[7].Value = oSPFreeProduct.ProductID;
                            oRow.Cells[8].Value = _oProduct.ItemCategory;
                            oRow.Cells[9].Value = oSPromotion.SalesPromotionID;
                            oRow.Cells[10].Value = oSPFreeProduct.SlabNo;
                            oRow.Cells[11].Value = _oProduct.IsBarcodeItem;

                            int nRowIndex = dvgProduct.Rows.Add(oRow);

                        }
                        DispalyPromoProduct(oSPromotion.SalesPromotionID, oSPromotion.SalesPromotionNo.ToString(), nCount, _bFlag);

                    }

                }



                if (nCount == 0)
                {
                    dvgProduct.Rows.Clear();
                    dgvDiscount.Rows.Clear();
                    dgvPromoProduct.Rows.Clear();
                }
            }
        }
        public void InsertDiscount(int nSalesPromotionID, int nSlabNo, double _Amount)
        {
            oTELLib = new TELLib();
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvDiscount);
            oRow.Cells[0].Value = nSalesPromotionID;
            oRow.Cells[1].Value = nSlabNo;
            oRow.Cells[2].Value = oTELLib.TakaFormat(_Amount);
            dgvDiscount.Rows.Add(oRow);
        }
        public int GetComboSlabQty(int nSalesPromotionID, int nFreeProductID, SPFreeProducts oSPFreeProducts)
        {
            int nComboSlabQty = 0;

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    int nQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                    int nProductID = int.Parse(oItemRow.Cells[9].Value.ToString());

                    _oSPSlabAllRatio = new SPSlabAllRatio();
                    _oSPSlabAllRatio.GetProductRatio(nSalesPromotionID, nProductID, nQty);
                    foreach (SPSlabRatio oSPSlabRatio in _oSPSlabAllRatio)
                    {

                        if (_oSPSlabAllRatio.Count == 1)
                        {
                            SPFreeProduct _oSPFreeProduct = new SPFreeProduct();
                            _oSPFreeProduct.RefreshByCPSID(oSPSlabRatio.CPSID);
                            nComboSlabQty = _oSPFreeProduct.Qty;

                            _oSPFreeProduct.SlabNo = oSPSlabRatio.SlabNo;


                        }

                    }
                }
            }
            return nComboSlabQty;

        }
        public double GetDiscountTotal()
        {
            double _DiscountTotal = 0;
            double Total = 0;
            if (dgvDiscount.Rows.Count > 0)
            {
                foreach (DataGridViewRow oItemRow in dgvDiscount.Rows)
                {
                    if (oItemRow.Index < dgvDiscount.Rows.Count)
                    {
                        Total = Total + Convert.ToDouble(oItemRow.Cells[2].Value.ToString());

                    }

                }
                _DiscountTotal = Math.Round(Total, 0, MidpointRounding.AwayFromZero);
            }
            return _DiscountTotal;
        }
        public double GetSMSDiscountTotal()
        {
            double _SMSDiscountTotal = 0;
            double Total = 0;
            if (dgvScratchCardAmt.Rows.Count > 1)
            {
                foreach (DataGridViewRow oItemRow in dgvScratchCardAmt.Rows)
                {
                    if (oItemRow.Index < dgvScratchCardAmt.Rows.Count - 1)
                    {
                        Total = Total + Convert.ToDouble(oItemRow.Cells[2].Value.ToString());

                    }

                }
                _SMSDiscountTotal = Math.Round(Total, 0, MidpointRounding.AwayFromZero);
            }
            return _SMSDiscountTotal;
        }
        public int NumberOfBonus(SalesPromotionSlab oSalesPromotionSlab)
        {
            double[] NumberOfBonus = new double[10];
            int nTimesofBonus = 1000;

            int i = 0;

            foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
            {
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        if (oSPSlabRatio.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                        {
                            NumberOfBonus[i] = int.Parse(oItemRow.Cells[6].Value.ToString()) / oSPSlabRatio.Qty;
                            i++;
                        }
                    }
                }
            }
            for (int j = 0; j < i; j++)
            {
                if (nTimesofBonus > NumberOfBonus[j])
                    nTimesofBonus = Convert.ToInt16(Math.Round(NumberOfBonus[j]));
            }
            return nTimesofBonus;
        }
        public int NumberOfBonus(SalesPromotionSlab oSalesPromotionSlab, SPromotion oSPromotion)
        {
            int nTimesofBonus = 0;
            oSPromotion.SPProducts.Refresh(oSPromotion.SalesPromotionID);
            foreach (SPProduct oSPProduct in oSPromotion.SPProducts)
            {
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                        {
                            nTimesofBonus = int.Parse(oItemRow.Cells[6].Value.ToString()) + nTimesofBonus;

                        }
                    }
                }
            }
            return nTimesofBonus;
        }

        private void btApplyPromotion_Click(object sender, EventArgs e)
        {
            int i;
            string sBarcode = "";
            oSelectedSPromotions = new SPromotions();
            foreach (DataGridViewRow oItemRow in dvgProduct.Rows)
            {
                if (oItemRow.Index < dvgProduct.Rows.Count - 1)
                {
                    if (Convert.ToBoolean(oItemRow.Cells[0].Value) == true)
                    {
                        if (int.Parse(oItemRow.Cells[8].Value.ToString()) != (int)Dictionary.ItemCategory.Gift_Item)
                        {
                            if (oItemRow.Cells[5].Value == null)
                            {
                                MessageBox.Show("Please Select Valid Barcode for Free Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (oItemRow.Cells[5].Value.ToString() == "")
                            {
                                MessageBox.Show("Please Select Valid Barcode for Free Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
            }
            foreach (DataGridViewRow oItem in dgvLineItem.Rows)
            {
                if (oItem.Index < dgvLineItem.Rows.Count - 1)
                {
                    oItem.Cells[4].Value = null;
                }
            }
            foreach (DataGridViewRow oItem in dgvLineItem.Rows)
            {
                if (oItem.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (int.Parse(oItem.Cells[11].Value.ToString()) == 1)
                    {
                        dgvLineItem.Rows.RemoveAt(oItem.Index);
                    }
                }
            }

            //foreach (DataGridViewRow oItemRow in dgvDiscount.Rows)
            //{
            //    if (oItemRow.Index < dgvDiscount.Rows.Count - 1)
            //    {
            //        if (Convert.ToBoolean(oItemRow.Cells[0].Value) == true)
            //        {
            //            foreach (DataGridViewRow oItem in dgvLineItem.Rows)
            //            {
            //                if (oItem.Index < dgvLineItem.Rows.Count - 1)
            //                {
            //                    if (int.Parse(oItem.Cells[9].Value.ToString()) == int.Parse(oItemRow.Cells[5].Value.ToString()))
            //                    {
            //                        try
            //                        {
            //                            if (oItem.Cells[4].Value == null)
            //                                oItem.Cells[4].Value = oItemRow.Cells[4].Value;
            //                            else oItem.Cells[4].Value = int.Parse(oItem.Cells[4].Value.ToString()) + int.Parse(oItemRow.Cells[4].Value.ToString());

            //                            SPromotion oSPromotion = new SPromotion();
            //                            oSPromotion.SalesPromotionID = int.Parse(oItemRow.Cells[6].Value.ToString());
            //                            oSelectedSPromotions.Add(oSPromotion);

            //                        }
            //                        catch
            //                        {
            //                            oItem.Cells[4].Value = "";
            //                        }

            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            foreach (DataGridViewRow oItemRow in dvgProduct.Rows)
            {
                if (oItemRow.Index < dvgProduct.Rows.Count - 1)
                {
                    if (Convert.ToBoolean(oItemRow.Cells[0].Value) == true)
                    {
                        DBController.Instance.OpenNewConnection();
                        _oProductDetail = new ProductDetail();
                        _oProductDetail.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                        _oProductDetail.Refresh();

                        if (int.Parse(oItemRow.Cells[8].Value.ToString()) != (int)Dictionary.ItemCategory.Gift_Item)
                        {
                            if (oItemRow.Cells[5].Value == null)
                            {
                                MessageBox.Show("Please Select Valid Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (oItemRow.Cells[5].Value.ToString() == "")
                            {
                                MessageBox.Show("Please Select Valid Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            sBarcode = oItemRow.Cells[5].Value.ToString();
                        }
                        else sBarcode = "";

                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = _oProductDetail.ProductCode;
                        oRow.Cells[2].Value = _oProductDetail.ProductName;
                        oRow.Cells[9].Value = _oProductDetail.ProductID;
                        oRow.Cells[11].Value = 1;
                        oRow.Cells[12].Value = int.Parse(oItemRow.Cells[4].Value.ToString());
                        oRow.Cells[7].Value = sBarcode;

                        oWUIUtility = new WUIUtility();
                        oWUIUtility.GetRetailStock(oSystemInfo.WarehouseID, _oProductDetail.ProductID);
                        if (oWUIUtility.CurrentStock < 0)
                            oRow.Cells[5].Value = 0;
                        else oRow.Cells[5].Value = oWUIUtility.CurrentStock;

                        oRow.Cells[10].Value = _oProductDetail.ItemCategory;
                        oRow.Cells[3].Value = _oProductDetail.RSP.ToString();
                        int nRowIndex = dgvLineItem.Rows.Add(oRow);

                        //
                        /*if (checkDuplicateLineItem(_oProductDetail.ProductCode) > 1)
                        {
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            foreach (DataGridViewRow oRowItem in dgvLineItem.Rows)
                            {
                                if (oRowItem.Index < dgvLineItem.Rows.Count - 1)
                                {
                                    if (oRowItem.Cells[0].Value == null)
                                    {
                                        continue;
                                    }
                                    if (oRowItem.Cells[0].Value.ToString().Trim() == _oProductDetail.ProductCode)
                                    {
                                        oRowItem.Cells[12].Value = 1;
                                        oRowItem.Cells[13].Value = int.Parse(oItemRow.Cells[4].Value.ToString());
                                        sBarcode = sBarcode + "," + oRowItem.Cells[8].Value.ToString();
                                        oRowItem.Cells[8].Value = sBarcode;
                                    }
                                }
                            }
                        }*/

                        i = 0;
                        foreach (SPromotion oSelectSPromotion in oSelectedSPromotions)
                        {
                            if (oSelectSPromotion.SalesPromotionID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                            {
                                oSelectedSPromotions.RemoveAt(i);
                                break;
                            }
                            i++;
                        }
                        SPromotion oSPromotion = new SPromotion();
                        oSPromotion.SalesPromotionID = int.Parse(oItemRow.Cells[9].Value.ToString());
                        oSelectedSPromotions.Add(oSPromotion);

                    }

                }
            }
            GetTotalDiscountAmount();

        }
        private void dvgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (cmbDeliveryPoint.Text == "")
                {
                    MessageBox.Show("Please Select a Delivery Point.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    int temp = int.Parse(dvgProduct.Rows[e.RowIndex].Cells[7].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Select a Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                frmAvailableBarcode ofrmAvailableBarcode = new frmAvailableBarcode(int.Parse(dvgProduct.Rows[e.RowIndex].Cells[7].Value.ToString()), oSystemInfo.WarehouseID, "", 0);
                ofrmAvailableBarcode.ShowDialog();

                if (ofrmAvailableBarcode._nCount == int.Parse(dvgProduct.Rows[e.RowIndex].Cells[4].Value.ToString()))
                {
                    dvgProduct.Rows[e.RowIndex].Cells[5].Value = ofrmAvailableBarcode._sBarcode;
                    //dvgProduct.Rows[e.RowIndex].Cells[13].Value = ofrmAvailableBarcode._sChkBarcode;
                }
                else
                {
                    dvgProduct.Rows[e.RowIndex].Cells[5].Value = "";
                    MessageBox.Show("Please Select Valid Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void ctlRetailConsumer1_ChangeSelection(object sender, EventArgs e)
        {
            oRetailConsumer = (RetailConsumer)ctlRetailConsumer1.SelectedCustomer;

            if (oRetailConsumer.ConsumerName != null)
            {
                cmbConType.SelectedIndex = oRetailConsumer.ConsumerType;
                txtCustomerName.Text = oRetailConsumer.ConsumerName;
                txtCustomerAddress.Text = oRetailConsumer.Address;
                txtEmail.Text = oRetailConsumer.Email;
                txtNationalID.Text = oRetailConsumer.NationalID;
                txtCell.Text = oRetailConsumer.CellNo;
                txtTelePhone.Text = oRetailConsumer.PhoneNo;
                txtVatRegNo.Text = oRetailConsumer.VatRegNo;
                if (oRetailConsumer.DateofBirth != null)
                {
                    dtDateofBirth.Checked = true;
                    dtDateofBirth.Value = Convert.ToDateTime(oRetailConsumer.DateofBirth);
                }

                txtCustomerName.Enabled = false;
                txtCustomerAddress.Enabled = false;
                txtEmail.Enabled = false;
                txtNationalID.Enabled = false;
                txtTelePhone.Enabled = false;
                txtCell.Enabled = false;
                dtDateofBirth.Enabled = false;
                txtVatRegNo.Enabled = false;
                cmbConType.Enabled = false;
            }
            else
            {
                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                cmbConType.Enabled = true;
                txtEmail.Enabled = true;
                txtNationalID.Enabled = true;
                txtTelePhone.Enabled = true;
                txtCell.Enabled = true;
                dtDateofBirth.Enabled = true;
                txtVatRegNo.Enabled = true;

                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtEmail.Text = "";
                txtNationalID.Text = "";
                txtTelePhone.Text = "";
                txtCell.Text = "";
                txtVatRegNo.Text = "";
            }
        }

        public bool ValidateUIInput()
        {
            /// Promotion Validation
            /// 
            bool _bCheckPromotion = false;
            double _RSPValue = 0;

            /*
            oResultSPromotions = new SPromotions();
            oResultSPromotions = GetPromotionResult(oResultSPromotions, Utility.RetailChannelID);

            if (oResultSPromotions.Count > 0)
            {
                if (oSelectedSPromotions == null)
                {
                    MessageBox.Show("Please Apply Promotion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (oSelectedSPromotions.Count ==0)
                {
                    MessageBox.Show("Please select Promotional Discount or Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                foreach (SPromotion oSPromotion in oResultSPromotions)
                {
                    foreach (SPromotion oSelectSPromotion in oSelectedSPromotions)
                    {
                        if (oSPromotion.SalesPromotionID == oSelectSPromotion.SalesPromotionID)
                        {
                            _bCheckPromotion = true;
                            break;
                        }
                        else _bCheckPromotion = false;

                    }
                    if (_bCheckPromotion == false)
                    {
                        MessageBox.Show("Please All Apply Promotion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
             */
            if (cmbEmpoyee.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Sales Person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmpoyee.Focus();
                return false;
            }
            if (cmbInvoiceType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Invoice Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInvoiceType.Focus();
                return false;
            }
            if (cmbPromotionType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Promotion Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPromotionType.Focus();
                return false;
            }

            double nDisAmt = 0;
            nDisAmt = Convert.ToDouble(txtFlatAmount.Text.Trim());

            if (nDisAmt > 0)
            {
                if (cmbDiscountReason.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Discount reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDiscountReason.Focus();
                    return false;
                }
            }
            nDisAmt = 0;
            nDisAmt = Convert.ToDouble(txtParcentage.Text.Trim());
            if (nDisAmt > 0)
            {
                if (cmbDiscountReason.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Discount reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDiscountReason.Focus();
                    return false;
                }
            }

            if (ctlRetailConsumer1.SelectedCustomer != null)
            {
                oRetailConsumer = new RetailConsumer();

                if (DBController._conn.State != ConnectionState.Open)
                {
                    DBController.Instance.OpenNewConnection();
                }
                if (oRetailConsumer.GetConsumer(ctlRetailConsumer1.SelectedCustomer.ConsumerID))
                {
                    nConsumerSalesType = oRetailConsumer.SalesType;

                    if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                    {
                        if (nConsumerSalesType != (int)Dictionary.SalesType.Retail)
                        {
                            MessageBox.Show("Please Select Retail Consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlRetailConsumer1.Focus();
                            return false;
                        }
                    }
                    else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                    {
                        if (nConsumerSalesType != (int)Dictionary.SalesType.HPA)
                        {
                            MessageBox.Show("Please Select HPA Consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlRetailConsumer1.Focus();
                            return false;
                        }
                    }
                    else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                    {
                        if (nConsumerSalesType != (int)Dictionary.SalesType.B2C)
                        {
                            MessageBox.Show("Please Select B2C Consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlRetailConsumer1.Focus();
                            return false;
                        }
                    }
                }
            }



            if (_nUIControl != (int)Dictionary.POSInvoiceUIControl.eStore)
            {
                if (_nUIControl != (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                {
                    if (ctlCustomer1.SelectedCustomer == null)
                    {
                        if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                        {
                            MessageBox.Show("Please Enter a HPA Customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.Focus();
                            return false;
                        }
                        else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C || _nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                        {
                            MessageBox.Show("Please Enter a Corporate Customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.Focus();
                            return false;
                        }
                        else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                        {
                            MessageBox.Show("Please Enter a Dealer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.Focus();
                            return false;
                        }
                    }
                    if (ctlCustomer1.txtCode.Text == "")
                    {
                        if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                        {
                            MessageBox.Show("Please Enter a HPA Customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.Focus();
                            return false;
                        }
                        else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C || _nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                        {
                            MessageBox.Show("Please Enter a Corporate Customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.Focus();
                            return false;
                        }
                        else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                        {
                            MessageBox.Show("Please Enter a Dealer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.Focus();
                            return false;
                        }
                    }

                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    DBController.Instance.OpenNewConnection();
                    oCustomer.refresh();
                    DBController.Instance.CloseConnection();

                    if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                    {
                        if (oCustomer.CustTypeID != Utility.CustomerType_TDHPA)
                        {
                            MessageBox.Show("Please Select HPA Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.Focus();
                            return false;
                        }
                    }
                    //else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C || _nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                    //{
                    //    if (oCustomer.CustTypeID != Utility.CustomerType_TDCorporate)
                    //    {
                    //        MessageBox.Show("Please Select TD Corporate Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        ctlCustomer1.Focus();
                    //        return false;
                    //    }
                    //}
                    else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                    {
                        if (oCustomer.ChannelID != 3)
                        {
                            MessageBox.Show("Please Select Dealer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.Focus();
                            return false;
                        }
                    }

                }
                else if (ctlRetailConsumer1.txtDescription.Text.Trim() == "")
                {
                    if (txtCustomerName.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter a consumer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCustomerName.Focus();
                        return false;
                    }
                    if (txtCustomerAddress.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter a consumer address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCustomerAddress.Focus();
                        return false;
                    }
                    if (txtEmail.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter a consumer email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCustomerAddress.Focus();
                        return false;
                    }
                    if (txtEmail.Text.Trim() != "")
                    {
                        Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                        Match m = emailregex.Match(txtEmail.Text);
                        if (!m.Success)
                        {
                            MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                            return false;
                        }
                    }
                    if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B || _nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                    {
                        if (txtEmployeeNo.Text.Trim() == "")
                        {
                            MessageBox.Show("Please Input Employee #", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmployeeNo.Focus();
                            return false;
                        }
                    }
                    if (txtCell.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter a consumer cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCell.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtCell.Text.Trim().Length != 11)
                        {
                            MessageBox.Show("Please enter a valid cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCell.Focus();
                            return false;
                        }
                        Regex rgCell = new Regex("[0-9]");
                        if (rgCell.IsMatch(txtCell.Text))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please Input Valid Cell no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
            {

                if (txtCustomerName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a consumer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerName.Focus();
                    return false;
                }
                if (txtCustomerAddress.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a consumer address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerAddress.Focus();
                    return false;
                }
                if (txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a consumer email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerAddress.Focus();
                    return false;
                }
                if (txtEmail.Text.Trim() != "")
                {
                    Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                    Match m = emailregex.Match(txtEmail.Text);
                    if (!m.Success)
                    {
                        MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return false;
                    }
                }
                if (txtCell.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a consumer cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCell.Focus();
                    return false;
                }
                else
                {
                    if (txtCell.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Please enter a valid cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCell.Focus();
                        return false;
                    }
                    Regex rgCell = new Regex("[0-9]");
                    if (rgCell.IsMatch(txtCell.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Input Valid Cell no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            //else
            //{
            //    if (ctlRetailConsumer1.txtCode.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Please enter a consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #region Invoice Item
            nTotalQty = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[10].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[10].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[10].Value.ToString().Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (oItemRow.Cells[6].Value != null)
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[6].Value.ToString().Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Please Input Valid Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (int.Parse(oItemRow.Cells[10].Value.ToString()) != (int)Dictionary.YesOrNoStatus.NO)
                    {
                        if (oItemRow.Cells[7].Value == null)
                        {
                            MessageBox.Show("Please Input Valid Product Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        char[] splitchar = { ',' };
                        string sProductBarcode = oItemRow.Cells[7].Value.ToString();
                        sProductBarcodeArr = sProductBarcode.Split(splitchar);
                        nArrayLen = sProductBarcodeArr.Length;


                        if (_sCHKSerialNo == "")
                        {
                            _sCHKSerialNo = oItemRow.Cells[13].Value.ToString();
                        }
                        else
                        {
                            _sCHKSerialNo = _sCHKSerialNo + "," + oItemRow.Cells[13].Value.ToString();
                        }
                        if (nTotalQty == 0)
                        {
                            nTotalQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                        }
                        else
                        {
                            nTotalQty = nTotalQty + int.Parse(oItemRow.Cells[6].Value.ToString());
                        }

                        if (int.Parse(oItemRow.Cells[11].Value.ToString()) == 0)
                        {
                            if (int.Parse(oItemRow.Cells[6].Value.ToString()) < nArrayLen)
                            {
                                MessageBox.Show("Unavailable Stock Quantity ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            if (int.Parse(oItemRow.Cells[12].Value.ToString()) < nArrayLen)
                            {
                                MessageBox.Show("Unavailable Stock Quantity ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }


                    }
                }
            }
            
            SystemInfo oIsVatActive = new SystemInfo();
            DBController.Instance.OpenNewConnection();
            int nIsNewVatActive = oIsVatActive.IsNewVatActive();
            DBController.Instance.OpenNewConnection();
            if (nIsNewVatActive == 1)
            {
                IsChkVatEntry = 0;
                if (_sCHKSerialNo != "")
                {
                    ProductBarcode oChkVatPaidBarcode = new ProductBarcode();
                    DBController.Instance.OpenNewConnection();
                    int nBarcode = oChkVatPaidBarcode.GetVatPaidBarcode(_sCHKSerialNo);
                    if (nBarcode == nTotalQty)
                    {
                        IsChkVatEntry = (int)Dictionary.YesOrNoStatus.NO;
                    }
                    else if (nTotalQty - nBarcode == nTotalQty)
                    {
                        IsChkVatEntry = (int)Dictionary.YesOrNoStatus.YES;
                    }
                    else
                    {
                        MessageBox.Show("Please Invoice Vat Paid Product Separately", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }

            #endregion

            #region Scratch Card Amount
            foreach (DataGridViewRow oItemRowSCardAmt in dgvScratchCardAmt.Rows)
            {
                if (oItemRowSCardAmt.Index < dgvScratchCardAmt.Rows.Count - 1)
                {
                    if (oItemRowSCardAmt.Cells[0].Value != null)
                    {
                        if (oItemRowSCardAmt.Cells[0].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Please Input Valid Scratch Card Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input Scratch Card Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRowSCardAmt.Cells[1].Value != null)
                    {
                        if (oItemRowSCardAmt.Cells[1].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Please Input Valid Scratch Card Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input Scratch Card Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRowSCardAmt.Cells[2].Value != null)
                    {
                        if (oItemRowSCardAmt.Cells[2].Value.ToString().Trim() != "")
                        {

                            try
                            {
                                double tmp = Convert.ToDouble(oItemRowSCardAmt.Cells[2].Value.ToString().Trim());
                            }
                            catch
                            {
                                MessageBox.Show("Please Input valid Scratch Card amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Input valid Scratch Card amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input Scratch Card amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            #region Scratch Card Product
            foreach (DataGridViewRow oItemRowSCard in dgvScratchCardQty.Rows)
            {
                if (oItemRowSCard.Index < dgvScratchCardQty.Rows.Count - 1)
                {
                    if (oItemRowSCard.Cells[0].Value != null)
                    {
                        if (oItemRowSCard.Cells[8].Value == null)
                        {
                            MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRowSCard.Cells[6].Value != null)
                    {
                        if (oItemRowSCard.Cells[6].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Please Input valid Scratch Card Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input Scratch Card Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRowSCard.Cells[7].Value != null)
                    {
                        if (oItemRowSCard.Cells[7].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Please Input valid Scratch Card Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input Scratch Card Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (int.Parse(oItemRowSCard.Cells[9].Value.ToString()) != (int)Dictionary.YesOrNoStatus.NO)
                    {
                        if (oItemRowSCard.Cells[4].Value == null)
                        {
                            MessageBox.Show("Please Input Valid Product Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        char[] splitchar = { ',' };
                        string sProductBarcode = oItemRowSCard.Cells[4].Value.ToString();
                        sProductBarcodeArr = sProductBarcode.Split(splitchar);
                        nArrayLen = sProductBarcodeArr.Length;
                    }
                    else
                    {
                        if (oItemRowSCard.Cells[3].Value != null)
                        {
                            try
                            {
                                int tem = Convert.ToInt32(oItemRowSCard.Cells[3].Value.ToString().Trim());
                            }
                            catch
                            {
                                MessageBox.Show("Please Input Valid Scratch Card Product Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Input Scratch Card Product Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                }
            }
            #endregion
            // RSP validetion
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[3].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            if (int.Parse(oItemRow.Cells[11].Value.ToString()) != 1)
                                _RSPValue = _RSPValue + Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) * Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                        }
                        catch
                        {
                            _RSPValue = 0;
                            break;
                        }
                    }
                }
            }
            if (_RSPValue != Convert.ToDouble(txtTotal.Text))
            {
                MessageBox.Show("Please check your total RS value and entered total product unit price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #region Payment Collection Validation
            if (dgvPayment.Rows.Count - 1 == 0)
            {
                MessageBox.Show("Please Input Payment Collection ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Payment Mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            try
                            {
                                double tmp = Convert.ToDouble(oItemRow.Cells[1].Value);
                            }
                            catch
                            {
                                MessageBox.Show("Please Input valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }
                    if (int.Parse(oItemRow.Cells[0].Value.ToString()) == (int)Dictionary.PaymentMode.Credit_Card)
                    {
                        if (oItemRow.Cells[2].Value == null)
                        {
                            MessageBox.Show("Please Select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[3].Value == null)
                        {
                            MessageBox.Show("Please Select Card Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[4].Value == null)
                        {
                            MessageBox.Show("Please Select POS Machine", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (oItemRow.Cells[5].Value == null)
                        {
                            MessageBox.Show("Please Select Card Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (oItemRow.Cells[6].Value == null)
                        {
                            {

                                MessageBox.Show("Please input Approval Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            if (oItemRow.Cells[6].Value != null)
                            {
                                try
                                {
                                    int tem = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                                }
                                catch
                                {
                                    MessageBox.Show("Please input valid Approval Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                            }

                        }


                        if (oItemRow.Cells[7].Value != null)
                        {
                            if (Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                if (oItemRow.Cells[8].Value != null)
                                {
                                    try
                                    {
                                        int tem = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Please input valid Installment Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please input #of Installment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                            }
                        }

                        if (oItemRow.Cells[10].Value != null)
                        {
                            try
                            {
                                DateTime tmp = Convert.ToDateTime(oItemRow.Cells[10].Value);
                            }
                            catch
                            {
                                MessageBox.Show("Please input valid Date like: 01-Jan-2050 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }

                    }

                    ////Start Customer BG///
                    if (int.Parse(oItemRow.Cells[0].Value.ToString()) == (int)Dictionary.PaymentMode.Customer_BG)
                    {
                        if (_nUIControl != (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                        {
                            MessageBox.Show("Bank guaranty is not eligible for this type of invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            PaymentMode oPaymentMode = new PaymentMode();
                            double _Balance = oPaymentMode.CheckBGAmount(ctlCustomer1.SelectedCustomer.CustomerID, Convert.ToDateTime(oSystemInfo.OperationDate).Date, Convert.ToDouble(oItemRow.Cells[1].Value));
                            if (_Balance < 0)
                            {
                                MessageBox.Show("Insufficient customer balance against bank guaranty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }

                    }
                    ///END Customer BG///
                }
            }
            //Approve Credit Validation
            double dApproveCredit = 0;
            string sCreditApprovalNo = "";
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (Convert.ToInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Approve_Credit)
                    {
                        sCreditApprovalNo = Convert.ToString(oItemRow.Cells[9].Value);
                        dApproveCredit = Convert.ToDouble(oItemRow.Cells[1].Value);
                        DBController.Instance.OpenNewConnection();
                        CustomerCreditApproval oCCA = new CustomerCreditApproval();
                        oCCA.RefreshByApprovalNo(sCreditApprovalNo);
                        double _Amount = oCCA.CreditAmount - oCCA.InvoicedAmount;
                        if (_Amount >= dApproveCredit)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Insufficient Credit Balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }

                }
            }
            #endregion

            double _Total = 0;
            int nPMCashCount = 0;
            int nPMAdvancePaymentCount = 0;
            int nPMEPSCount = 0;
            int nPMCustomerBG = 0;
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (Convert.ToUInt32(oItemRow.Cells[0].Value) == 1)
                    {
                        nPMCashCount++;
                    }
                    if (Convert.ToUInt32(oItemRow.Cells[0].Value) == 3)
                    {
                        nPMAdvancePaymentCount++;
                    }
                    if (Convert.ToUInt32(oItemRow.Cells[0].Value) == 4)
                    {
                        nPMEPSCount++;
                    }

                    if (Convert.ToUInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Customer_BG)
                    {
                        nPMCustomerBG++;
                    }

                    try
                    {
                        _Total = _Total + Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            if (nPMCashCount > 1)
            {
                MessageBox.Show("Payment Mode 'Cash Duplicate'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nPMAdvancePaymentCount > 1)
            {
                MessageBox.Show("Payment Mode 'Advance Payment' Duplicate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nPMEPSCount > 1)
            {
                MessageBox.Show("Payment Amount 'EPS' Duplicate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nPMCustomerBG > 1)
            {
                MessageBox.Show("Payment Amount 'Customer Bank Guaranty' Duplicate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_Total <= 0)
            {
                MessageBox.Show("Payment Amount should be positive or grether than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_Total != Convert.ToDouble(txtNetPay.Text))
            {
                MessageBox.Show("Payment Amount and Net Amount Must Be Same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();

                    #region Consumer Entry
                    //if (ctlRetailConsumer1.SelectedCustomer == null || ctlRetailConsumer1.txtCode.Text == "")
                    if (rdoNewConsumer.Checked== true)
                    {

                        oRetailConsumer = new RetailConsumer();
                        if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B || _nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                        {
                            int nSalesType = 0;
                            if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                                nSalesType = (int)Dictionary.SalesType.B2B;
                            else nSalesType = (int)Dictionary.SalesType.Dealer;

                            if (oRetailConsumer.CheckConsumer(ctlCustomer1.SelectedCustomer.CustomerID, nSalesType))
                            {
                                nConsumerID = oRetailConsumer.ConsumerID;
                                nCustomerID = oRetailConsumer.CustomerID;
                            }
                            else
                            {
                                oCustomerDetail = new CustomerDetail();
                                oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                                oCustomerDetail.RefreshForSalesOrder();

                                oRetailConsumer.ConsumerName = oCustomerDetail.CustomerName;
                                oRetailConsumer.Address = oCustomerDetail.CustomerAddress;
                                oRetailConsumer.ConsumerType = (int)Dictionary.RetailCustomerType.General;
                                oRetailConsumer.Email = "";
                                oRetailConsumer.NationalID = "";
                                oRetailConsumer.CellNo = oCustomerDetail.CustomerPhoneNo;
                                oRetailConsumer.PhoneNo = "";
                                oRetailConsumer.VatRegNo = "";
                                oRetailConsumer.EmployeeCode = "";
                                oRetailConsumer.DateofBirth = null;
                                oRetailConsumer.CustomerID = oCustomerDetail.CustomerID;

                                nCustomerID = oCustomerDetail.CustomerID;

                                oRetailConsumer.ParentCustomerID = oCustomerDetail.ParentCustomerID;
                                oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;

                                if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.Retail;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.B2C;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.B2B;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.HPA;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.Dealer;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.eStore;

                                oRetailConsumer.Add();

                            }
                        }
                        else
                        {
                            oRetailConsumer.ConsumerName = txtCustomerName.Text;
                            oRetailConsumer.Address = txtCustomerAddress.Text;
                            oRetailConsumer.ConsumerType = cmbConType.SelectedIndex;
                            oRetailConsumer.Email = txtEmail.Text;
                            oRetailConsumer.NationalID = txtNationalID.Text;
                            oRetailConsumer.CellNo = txtCell.Text;
                            oRetailConsumer.PhoneNo = txtTelePhone.Text;
                            oRetailConsumer.VatRegNo = txtVatRegNo.Text;
                            oRetailConsumer.EmployeeCode = txtEmployeeNo.Text;
                            if (dtDateofBirth.Checked == true)
                                oRetailConsumer.DateofBirth = dtDateofBirth.Value.Date;
                            else oRetailConsumer.DateofBirth = null;

                            if (_nUIControl != (int)Dictionary.POSInvoiceUIControl.eStore)
                            {
                                if (_nUIControl != (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                                {
                                    oRetailConsumer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                                    oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                                }
                                else
                                {
                                    oRetailConsumer.CustomerID = oSystemInfo.CustomerID;
                                    oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                                }
                            }
                            else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                            {
                                oRetailConsumer.CustomerID = oSystemInfo.CustomerID;
                                oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                            }

                            nCustomerID = oRetailConsumer.CustomerID;
                            oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;

                            if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                                oRetailConsumer.SalesType = (int)Dictionary.SalesType.Retail;
                            else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                                oRetailConsumer.SalesType = (int)Dictionary.SalesType.B2C;
                            else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                                oRetailConsumer.SalesType = (int)Dictionary.SalesType.B2B;
                            else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                                oRetailConsumer.SalesType = (int)Dictionary.SalesType.HPA;
                            else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                                oRetailConsumer.SalesType = (int)Dictionary.SalesType.Dealer;
                            else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                                oRetailConsumer.SalesType = (int)Dictionary.SalesType.eStore;

                            oRetailConsumer.Add();
                        }
                    }
                    else if (rdoExistingConsumer.Checked == true)
                    {
                        oRetailConsumer = new RetailConsumer();

                        oRetailConsumer.GetConsumer(ctlRetailConsumer1.SelectedCustomer.ConsumerID);
                        nCustomerID = oRetailConsumer.CustomerID;
                    }
                    else if (rdoLeadCust.Checked == true)
                    {
                        SalesLead _SalesLeadManagement = new SalesLead();
                        if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice || _nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore || _nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                        {
                            _SalesLeadManagement.LeadNo = txtLeadNo.Text;
                            _SalesLeadManagement.GetCustomerByLeadNo();
                            nIsExistingConsumer = _SalesLeadManagement.IsExistingConsumer;
                            if (nIsExistingConsumer == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                _SalesLeadManagement.GetSalesInvoiceConsumerID(_SalesLeadManagement.RefLeadNo);
                                try
                                {
                                    nLeadConsumer = _SalesLeadManagement.ConsumerID;
                                }
                                catch
                                {
                                    nLeadConsumer = 0;
                                }
                            }
                        }



                        oRetailConsumer = new RetailConsumer();
                        if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B || _nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                        {
                            int nSalesType = 0;
                            if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                                nSalesType = (int)Dictionary.SalesType.B2B;
                            else nSalesType = (int)Dictionary.SalesType.Dealer;

                            if (oRetailConsumer.CheckConsumer(ctlCustomer1.SelectedCustomer.CustomerID, nSalesType))
                            {
                                nConsumerID = oRetailConsumer.ConsumerID;
                                nCustomerID = oRetailConsumer.CustomerID;
                            }
                            else
                            {
                                oCustomerDetail = new CustomerDetail();
                                oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                                oCustomerDetail.RefreshForSalesOrder();

                                oRetailConsumer.ConsumerName = oCustomerDetail.CustomerName;
                                oRetailConsumer.Address = oCustomerDetail.CustomerAddress;
                                oRetailConsumer.ConsumerType = (int)Dictionary.RetailCustomerType.General;
                                oRetailConsumer.Email = "";
                                oRetailConsumer.NationalID = "";
                                oRetailConsumer.CellNo = oCustomerDetail.CustomerPhoneNo;
                                oRetailConsumer.PhoneNo = "";
                                oRetailConsumer.VatRegNo = "";
                                oRetailConsumer.EmployeeCode = "";
                                oRetailConsumer.DateofBirth = null;
                                oRetailConsumer.CustomerID = oCustomerDetail.CustomerID;

                                nCustomerID = oCustomerDetail.CustomerID;

                                oRetailConsumer.ParentCustomerID = oCustomerDetail.ParentCustomerID;
                                oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;

                                if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.Retail;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.B2C;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.B2B;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.HPA;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.Dealer;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.eStore;

                                oRetailConsumer.Add();

                            }
                        }
                        else
                        {
                            if (nLeadConsumer != 0)
                            {
                                nConsumerID = _SalesLeadManagement.ConsumerID;
                                nCustomerID = _SalesLeadManagement.CustomerID;
                            }
                            else
                            {
                                oRetailConsumer.ConsumerName = txtCustomerName.Text;
                                oRetailConsumer.Address = txtCustomerAddress.Text;
                                oRetailConsumer.ConsumerType = cmbConType.SelectedIndex;
                                oRetailConsumer.Email = txtEmail.Text;
                                oRetailConsumer.NationalID = txtNationalID.Text;
                                oRetailConsumer.CellNo = txtCell.Text;
                                oRetailConsumer.PhoneNo = txtTelePhone.Text;
                                oRetailConsumer.VatRegNo = txtVatRegNo.Text;
                                oRetailConsumer.EmployeeCode = txtEmployeeNo.Text;
                                if (dtDateofBirth.Checked == true)
                                    oRetailConsumer.DateofBirth = dtDateofBirth.Value.Date;
                                else oRetailConsumer.DateofBirth = null;

                                if (_nUIControl != (int)Dictionary.POSInvoiceUIControl.eStore)
                                {
                                    if (_nUIControl != (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                                    {
                                        oRetailConsumer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                                        oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                                    }
                                    else
                                    {
                                        oRetailConsumer.CustomerID = oSystemInfo.CustomerID;
                                        oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                                    }
                                }
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                                {
                                    oRetailConsumer.CustomerID = oSystemInfo.CustomerID;
                                    oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                                }

                                nCustomerID = oRetailConsumer.CustomerID;
                                oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;

                                if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.Retail;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.B2C;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.B2B;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.HPA;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.Dealer;
                                else if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.eStore;

                                oRetailConsumer.Add();

                            }
                        }


                    }
                    #endregion

                    #region Insert in SalesInvoice and SalesInvoiceDetail
                    ///
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice);
                    _oSalesInvoice.InsertPOSInvoice(true);
                    #endregion

                    #region Insert Promotional Effect in Invoice
                    if (oResultSPromotions != null)
                    {
                        foreach (SPromotion oSelectSPromotion in oResultSPromotions)
                        {
                            _oSalesInvoice.SalesPromotionID = oSelectSPromotion.SalesPromotionID;

                            _oSalesInvoice.InsertSalesInvoicePromo();
                        }
                    }
                    #endregion

                    #region barcode from Invoice Item
                    int _nCount = 1;
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            if (int.Parse(oItemRow.Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                char[] splitchar = { ',' };
                                string sProductBarcode = oItemRow.Cells[7].Value.ToString();
                                sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                nArrayLen = sProductBarcodeArr.Length;

                                for (int i = 0; i < nArrayLen; i++)
                                {

                                    ProductBarcode oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];

                                    oProductBarcode.UpdateProductSerial();

                                    SalesInvoiceProductSerial oChkVatPaidProductSerial = new SalesInvoiceProductSerial();
                                    oChkVatPaidProductSerial.ProductSerialNo = oProductBarcode.ProductSerialNo;
                                    if (oChkVatPaidProductSerial.CheckVatPaidProductSerial())
                                    {
                                       // oProductBarcode.UpdateVatPaidProductSerial(oSystemInfo.WarehouseID);
                                    }

                                    oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);

                                    oProductBarcode.FromWHID = oSystemInfo.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.WarehouseType.SYSTEM;
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                    oProductBarcode.InsertProductSerialHistory();


                                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                                    _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                    _oSalesInvoiceProductSerial.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                                    _oSalesInvoiceProductSerial.SerialNo = _nCount;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = sProductBarcodeArr[i];

                                    _oSalesInvoiceProductSerial.Insert();
                                    _nCount++;

                                }

                            }
                        }
                    }
                    #endregion

                    #region barcode from Promotion/Gift Item
                    foreach (DataGridViewRow oItemRow in dvgProduct.Rows)
                    {
                        if (oItemRow.Index < dvgProduct.Rows.Count)
                        {
                            if (int.Parse(oItemRow.Cells[11].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                char[] splitchar = { ',' };
                                string sProductBarcode = oItemRow.Cells[5].Value.ToString();
                                sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                nArrayLen = sProductBarcodeArr.Length;

                                for (int i = 0; i < nArrayLen; i++)
                                {

                                    ProductBarcode oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];

                                    oProductBarcode.UpdateProductSerial();

                                    oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);

                                    oProductBarcode.FromWHID = oSystemInfo.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.WarehouseType.SYSTEM;
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                    oProductBarcode.InsertProductSerialHistory();


                                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                                    _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                    _oSalesInvoiceProductSerial.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                    _oSalesInvoiceProductSerial.SerialNo = _nCount;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = sProductBarcodeArr[i];

                                    _oSalesInvoiceProductSerial.Insert();
                                    _nCount++;

                                }
                            }
                        }
                    }
                    #endregion

                    #region barcode from Scratch Card Item
                    foreach (DataGridViewRow oItemRow in dgvScratchCardQty.Rows)
                    {
                        if (oItemRow.Index < dgvScratchCardQty.Rows.Count - 1)
                        {
                            if (int.Parse(oItemRow.Cells[9].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                char[] splitchar = { ',' };
                                string sProductBarcode = oItemRow.Cells[4].Value.ToString();
                                sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                nArrayLen = sProductBarcodeArr.Length;

                                for (int i = 0; i < nArrayLen; i++)
                                {

                                    ProductBarcode oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];

                                    oProductBarcode.UpdateProductSerial();

                                    oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);

                                    oProductBarcode.FromWHID = oSystemInfo.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.WarehouseType.SYSTEM;
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                    oProductBarcode.InsertProductSerialHistory();


                                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                                    _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                    _oSalesInvoiceProductSerial.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
                                    _oSalesInvoiceProductSerial.SerialNo = _nCount;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = sProductBarcodeArr[i];

                                    _oSalesInvoiceProductSerial.Insert();
                                    _nCount++;

                                }

                            }
                        }
                    }
                    #endregion

                    #region Insert in Customer Transaction and Update Customer Account.
                    ///

                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction);
                    if (_oCustomerTransaction.CheckTranNo())
                        //_oCustomerTransaction.AddTran(true);
                        _oCustomerTransaction.AddTranNew();
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Duplicate Customer Transaction", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                    #endregion

                    #region Sales Promotion Mapping
                    // Sales Invoice Promotion for
                    if (dgvPromoProduct.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow oItemRow in dgvPromoProduct.Rows)
                        {
                            if (oItemRow.Index < dgvPromoProduct.Rows.Count)
                            {
                                _oSalesInvoicePromotionFor = new SalesInvoicePromotionFor();

                                _oSalesInvoicePromotionFor.OutletID = oSystemInfo.WarehouseID;
                                _oSalesInvoicePromotionFor.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                _oSalesInvoicePromotionFor.ProductID = int.Parse(oItemRow.Cells[3].Value.ToString());
                                _oSalesInvoicePromotionFor.ForQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                                _oSalesInvoicePromotionFor.SalesPromotionID = int.Parse(oItemRow.Cells[5].Value.ToString());
                                _oSalesInvoicePromotionFor.Add();

                            }
                        }
                    }
                    // Sales Invoice Promotion Offer (Product)
                    if (dvgProduct.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow oItemRow in dvgProduct.Rows)
                        {
                            if (oItemRow.Index < dvgProduct.Rows.Count)
                            {
                                _oSalesInvoicePromotionOffer = new SalesInvoicePromotionOffer();

                                _oSalesInvoicePromotionOffer.OutletID = oSystemInfo.WarehouseID;
                                _oSalesInvoicePromotionOffer.Type = (int)Dictionary.ProductOrAmountStatus.Product;
                                _oSalesInvoicePromotionOffer.FreeProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                _oSalesInvoicePromotionOffer.FreeQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                                _oSalesInvoicePromotionOffer.SlabNo = int.Parse(oItemRow.Cells[10].Value.ToString());
                                _oSalesInvoicePromotionOffer.SalesPromotionID = int.Parse(oItemRow.Cells[9].Value.ToString());
                                _oSalesInvoicePromotionOffer.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                _oSalesInvoicePromotionOffer.Add();

                            }
                        }
                    }
                    // Sales Invoice Promotion Offer (Amount)
                    if (dgvDiscount.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow oItemRow in dgvDiscount.Rows)
                        {
                            if (oItemRow.Index < dgvDiscount.Rows.Count)
                            {
                                _oSalesInvoicePromotionOffer = new SalesInvoicePromotionOffer();

                                _oSalesInvoicePromotionOffer.OutletID = oSystemInfo.WarehouseID;
                                _oSalesInvoicePromotionOffer.Type = (int)Dictionary.ProductOrAmountStatus.Amount;
                                _oSalesInvoicePromotionOffer.DiscountAmount = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                                _oSalesInvoicePromotionOffer.SlabNo = int.Parse(oItemRow.Cells[1].Value.ToString());
                                _oSalesInvoicePromotionOffer.SalesPromotionID = int.Parse(oItemRow.Cells[0].Value.ToString());
                                _oSalesInvoicePromotionOffer.InvoiceNo = _oSalesInvoice.InvoiceNo;

                                _oSalesInvoicePromotionOffer.Add();

                            }
                        }
                    }

                    // Sales Invoice Promotion Mapping
                    if (dgvPromoProduct.Rows.Count > 0)
                    {
                        int nSalesPromotionID = 0;
                        string sInvoiceNo = "";
                        foreach (DataGridViewRow oItemRow in dgvPromoProduct.Rows)
                        {
                            if (oItemRow.Index < dgvPromoProduct.Rows.Count)
                            {
                                if (nSalesPromotionID != int.Parse(oItemRow.Cells[5].Value.ToString()))
                                {
                                    nSalesPromotionID = int.Parse(oItemRow.Cells[5].Value.ToString());
                                    sInvoiceNo = _oSalesInvoice.InvoiceNo;
                                    InsertPromotionMapping(nSalesPromotionID, sInvoiceNo);
                                }

                            }
                        }
                    }

                    #endregion

                    #region Scratch Card Info Insert
                    //When Product 
                    if (dgvScratchCardQty.Rows.Count > 1)
                    {
                        foreach (DataGridViewRow oItemRow in dgvScratchCardQty.Rows)
                        {
                            if (oItemRow.Index < dgvScratchCardQty.Rows.Count - 1)
                            {
                                _oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();
                                _oSalesInvoiceScratchCardInfo.OutletID = oSystemInfo.WarehouseID;
                                _oSalesInvoiceScratchCardInfo.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                _oSalesInvoiceScratchCardInfo.Type = (int)Dictionary.ProductOrAmountStatus.Product;
                                _oSalesInvoiceScratchCardInfo.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
                                _oSalesInvoiceScratchCardInfo.Qty = int.Parse(oItemRow.Cells[3].Value.ToString());
                                _oSalesInvoiceScratchCardInfo.ScratchCardNo = oItemRow.Cells[6].Value.ToString().Trim();
                                _oSalesInvoiceScratchCardInfo.Description = oItemRow.Cells[7].Value.ToString().Trim();
                                _oSalesInvoiceScratchCardInfo.Add();

                            }
                        }
                    }
                    //When Amount 
                    if (dgvScratchCardAmt.Rows.Count > 1)
                    {
                        foreach (DataGridViewRow oItemRow in dgvScratchCardAmt.Rows)
                        {
                            if (oItemRow.Index < dgvScratchCardAmt.Rows.Count - 1)
                            {
                                _oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();
                                _oSalesInvoiceScratchCardInfo.OutletID = oSystemInfo.WarehouseID;
                                _oSalesInvoiceScratchCardInfo.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                _oSalesInvoiceScratchCardInfo.Type = (int)Dictionary.ProductOrAmountStatus.Amount;
                                _oSalesInvoiceScratchCardInfo.Amount = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                                _oSalesInvoiceScratchCardInfo.ScratchCardNo = oItemRow.Cells[0].Value.ToString().Trim();
                                _oSalesInvoiceScratchCardInfo.Description = oItemRow.Cells[1].Value.ToString().Trim();
                                _oSalesInvoiceScratchCardInfo.Add();

                            }
                        }
                    }
                    #endregion

                    #region Update Product Satock
                    ///

                    foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
                    {
                        ProductStock oProductStock = new ProductStock();

                        oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
                        oProductStock.Quantity = _oSalesInvoiceItem.Quantity + _oSalesInvoiceItem.FreeQty;
                        oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                        oProductStock.ChannelID = oSystemInfo.ChannelID;

                        oProductStock.Edit();
                    }
                    #endregion

                    #region Customer Tran(Collection){CustomerTran/Invoice wise payment/CustomerAccount (+)}
                    
                    double _CustomerBGAmt = 0;
                    foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
                    {
                        if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                        {
                            if (Convert.ToInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Customer_BG)
                            {
                                _CustomerBGAmt = _CustomerBGAmt + Convert.ToDouble(oItemRow.Cells[1].Value);

                            }

                        }
                    }
                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction = GetCustomerTranForCollection(_oCustomerTransaction, _oSalesInvoice);
                    _oCustomerTransaction.InsertForPOSNew(oSystemInfo.WarehouseID, Convert.ToDateTime(oSystemInfo.OperationDate), _CustomerBGAmt);

                    #endregion

                    #region PROCESSING Delivery
                    _oSalesInvoice.UpdateDate = oSystemInfo.OperationDate;
                    _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                    #endregion

                    #region Delivery Invoice & ProductStock Tran

                    _oStockTran = new StockTran();
                    _oStockTran = SetData(_oStockTran, _oSalesInvoice);
                    _oSalesInvoice.UserID = Utility.UserId;
                    _oSalesInvoice.DeliveryDate = oSystemInfo.OperationDate;
                    _oSalesInvoice.RetailDeliveryInvoice(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.DELIVERED, _oSalesInvoice.WarehouseID);
                    _oStockTran.UserID = Utility.UserId;
                    _oStockTran.Insert();

                    foreach (StockTranItem oItem in _oStockTran)
                    {
                        _oProductStock = new ProductStock();
                        _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);
                        if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((_oProductStock.BookingStock - oItem.Qty) < 0)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.Update(oItem.StockPrice);

                        if (_oProductStock.Flag == false)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        _oProductStock = new ProductStock();
                        _oProductStock.ProductID = oItem.ProductID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.WarehouseID = _oStockTran.ToWHID;
                        _oProductStock.Quantity = _oStockTran.ToChannelID;

                        _oProductStock.UpdateCurrentStock(true);

                    }

                    #endregion

                    #region Insert Retail Invoice Extra & Payment Mode

                    oRetailSalesInvoice = new RetailSalesInvoice();

                    oRetailSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;

                    try
                    {
                        oRetailSalesInvoice.SPParcentage = Convert.ToDouble(txtParcentage.Text);
                    }
                    catch
                    {
                        oRetailSalesInvoice.SPParcentage = 0;
                    }
                    try
                    {
                        oRetailSalesInvoice.FaltAmount = Convert.ToDouble(txtFlatAmount.Text);
                    }
                    catch
                    {
                        oRetailSalesInvoice.FaltAmount = 0;
                    }
                    try
                    {
                        oRetailSalesInvoice.SPDiscount = Convert.ToDouble(txtTotalDisount.Text);
                    }
                    catch
                    {
                        oRetailSalesInvoice.SPDiscount = 0;
                    }
                    try
                    {
                        oRetailSalesInvoice.InstallationCharge = Convert.ToDouble(txtInstallationCharge.Text);
                    }
                    catch
                    {
                        oRetailSalesInvoice.InstallationCharge = 0;
                    }
                    try
                    {
                        oRetailSalesInvoice.FreightCharge = Convert.ToDouble(txtFreightCharge.Text);
                    }
                    catch
                    {
                        oRetailSalesInvoice.FreightCharge = 0;
                    }
                    try
                    {
                        oRetailSalesInvoice.OtherCharge = Convert.ToDouble(txtOtherCharge.Text);
                    }
                    catch
                    {
                        oRetailSalesInvoice.OtherCharge = 0;
                    }
                    try
                    {
                        oRetailSalesInvoice.MarkUpAmount = Convert.ToDouble(txtMarkUp.Text);
                    }
                    catch
                    {
                        oRetailSalesInvoice.MarkUpAmount = 0;
                    }
                    if (cmbDiscountReason.SelectedIndex != 0)
                    {
                        oRetailSalesInvoice.DiscountReasonID = _oDiscountReasons[cmbDiscountReason.SelectedIndex - 1].DiscountReasonID;
                    }
                    else
                    {
                        oRetailSalesInvoice.DiscountReasonID = cmbDiscountReason.SelectedIndex;
                    }
                    if (cmbPromotionType.SelectedIndex != 0)
                    {
                        oRetailSalesInvoice.SalesPromotionType = _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID;
                    }
                    else
                    {
                        oRetailSalesInvoice.SalesPromotionType = cmbPromotionType.SelectedIndex;
                    }

                    oRetailSalesInvoice.InsertCharge();

                    foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
                    {
                        int nPaymentModeID = 0;
                        if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                        {
                            oRetailSalesInvoice.PaymentModeID = int.Parse(oItemRow.Cells[0].Value.ToString());
                            nPaymentModeID = oRetailSalesInvoice.PaymentModeID;
                            oRetailSalesInvoice.Amount = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                            try
                            {
                                oRetailSalesInvoice.BankID = int.Parse(oItemRow.Cells[2].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.BankID = -1;

                            }
                            try
                            {
                                oRetailSalesInvoice.CardType = int.Parse(oItemRow.Cells[3].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.CardType = -1;
                            }
                            try
                            {
                                oRetailSalesInvoice.POSMachineID = int.Parse(oItemRow.Cells[4].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.POSMachineID = -1;

                            }

                            try
                            {
                                oRetailSalesInvoice.CardCategory = int.Parse(oItemRow.Cells[5].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.CardCategory = -1;

                            }


                            try
                            {
                                oRetailSalesInvoice.ApprovalNo = oItemRow.Cells[6].Value.ToString().Trim();
                            }
                            catch
                            {
                                oRetailSalesInvoice.ApprovalNo = "";

                            }

                            try
                            {
                                oRetailSalesInvoice.IsEMI = int.Parse(oItemRow.Cells[7].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.IsEMI = -1;

                            }
                            try
                            {
                                oRetailSalesInvoice.NoOfInstallment = int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
                            }
                            catch
                            {
                                oRetailSalesInvoice.NoOfInstallment = -1;

                            }
                            try
                            {
                                oRetailSalesInvoice.InstrumentNo = oItemRow.Cells[9].Value.ToString().Trim();
                            }
                            catch
                            {
                                oRetailSalesInvoice.InstrumentNo = "";

                            }

                            try
                            {
                                oRetailSalesInvoice.InstrumentDate = Convert.ToDateTime(oItemRow.Cells[10].Value.ToString().Trim());
                            }
                            catch
                            {
                                oRetailSalesInvoice.InstrumentDate = null;

                            }
                            oRetailSalesInvoice.InsertPayMode();
                            if (oRetailSalesInvoice.PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                            {
                                CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
                                oCustomerCreditApproval.ApprovalNo = Convert.ToString(oItemRow.Cells[9].Value);
                                oCustomerCreditApproval.InvoicedAmount = Convert.ToDouble(oItemRow.Cells[1].Value);
                                oCustomerCreditApproval.UpdateInvoicedAmount(true);

                            }
                            ////Insert Money Receipt Data
                            if (oRetailSalesInvoice.PaymentModeID == (int)Dictionary.PaymentMode.Exchange_Offer_Money_Receipt)
                            {
                                ExchangeOfferMR _oExchangeOfferMR = new ExchangeOfferMR();
                                _oExchangeOfferMR.MoneyReceiptNo = Convert.ToString(oItemRow.Cells[9].Value);
                                _oExchangeOfferMR.Status = (int)Dictionary.ExchangeOfferMRStatus.SalesExecuted;
                                _oExchangeOfferMR.RedeemWHID = _oSalesInvoice.WarehouseID;
                                _oExchangeOfferMR.UpdateMoneyReceipt();

                                ExchangeOfferMR oGETMR = new ExchangeOfferMR();
                                oGETMR.RefreshMRByMRNo(Convert.ToString(oItemRow.Cells[9].Value));

                                ExchangeOfferJob oExchangeOfferJob = new ExchangeOfferJob();
                                oExchangeOfferJob.JobID = oGETMR.JobID;
                                oExchangeOfferJob.RefInvoiceNo = _oSalesInvoice.InvoiceNo;
                                oExchangeOfferJob.SalesExecuteDate =Convert.ToDateTime(_oSalesInvoice.InvoiceDate);
                                oExchangeOfferJob.Status = (int)Dictionary.ExchangeOfferStatus.SalesExecuted;
                                oExchangeOfferJob.UpdateSalesStatus();

                                DataTran oDataTran = new DataTran();
                                oDataTran.TableName = "t_ExchangeOfferMR";
                                oDataTran.DataID = Convert.ToInt32(oGETMR.MoneyReceiptID);
                                oDataTran.WarehouseID = _oSalesInvoice.WarehouseID;
                                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                                oDataTran.BatchNo = 0;

                                if (oDataTran.CheckData() == false)
                                {
                                    oDataTran.AddForTDPOS();
                                }

                                DataTran oDTran = new DataTran();
                                oDTran.TableName = "t_ExchangeOfferJob";
                                oDTran.DataID = Convert.ToInt32(oExchangeOfferJob.JobID);
                                oDTran.WarehouseID = _oSalesInvoice.WarehouseID;
                                oDTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                                oDTran.IsDownload = (int)Dictionary.IsDownload.No;
                                oDTran.BatchNo = 0;

                                if (oDTran.CheckData() == false)
                                {
                                    oDTran.AddForTDPOS();
                                }

                            }

                            if (oRetailSalesInvoice.PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
                            {
                                ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();

                                oConsumerBalanceTran.CustomerID = oSystemInfo.CustomerID;

                                oConsumerBalanceTran.TranType = Dictionary.ConsumerAdvancePaymentTranType.Adjust;
                                oConsumerBalanceTran.TranSide = Dictionary.TransectionSide.DEBIT;

                                oConsumerBalanceTran.AdvancePaymentNo = "";
                                oConsumerBalanceTran.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                oConsumerBalanceTran.Amount = oRetailSalesInvoice.Amount;
                                oConsumerBalanceTran.Purpose = "";
                                oConsumerBalanceTran.ProductID = -1;
                                oConsumerBalanceTran.PaymentMode = (Dictionary.ConsumerAdvancePaymentMode.Cash);
                                oConsumerBalanceTran.Remarks = "";
                                oConsumerBalanceTran.IsUpload = (int)Dictionary.YesOrNoStatus.NO;
                                oConsumerBalanceTran.CreateUserID = Utility.UserId;
                                oConsumerBalanceTran.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);

                                oConsumerBalanceTran.ConsumerID = Convert.ToInt32(_oSalesInvoice.SundryCustomerID);
                                oConsumerBalanceTran.Add(true, false);

                                oConsumerBalanceTran.CheckConsumerBalance();
                                if (oConsumerBalanceTran.Amount >= oConsumerBalanceTran.Amount)
                                {
                                    oConsumerBalanceTran.UpdateConsumerBalance(false, oRetailSalesInvoice.Amount);
                                }
                                else
                                {
                                    try
                                    {
                                        int tmp = Convert.ToInt32("Hakim");
                                    }
                                    catch (Exception ex)
                                    {

                                        MessageBox.Show("Insufficient Consumer Balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        throw (ex);
                                    }
                                }

                            }

                        }
                        if (nPaymentModeID != 0)
                        {
                            if (nPaymentModeID == (int)Dictionary.PaymentMode.Cash)
                            {
                                _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.CASH;
                            }
                            else if (nPaymentModeID == (int)Dictionary.PaymentMode.EPS)
                            {
                                _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.EPS;
                            }
                            else if (nPaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                            {
                                if (oRetailSalesInvoice.IsEMI == (int)Dictionary.YesOrNoStatus.YES)
                                {
                                    _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.EASY_BUY;
                                }
                                else
                                {
                                    _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.CREDIT;
                                }

                            }
                            else
                            {
                                _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.CREDIT;
                            }

                            _oSalesInvoice.UpadteInvoiceType();

                        }
                    }

                    #endregion

                    #region Invoice/Warranty Print

                    #endregion

                    #region Invoice/Warranty With CLP Print
                    /*
                    if (oRetailConsumer.CheckCLPConsumer())
                    {
                        oCLPEligibility = new CLPEligibility();
                        oCLPEligibility.EffectDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
                        oCLPEligibility.Amount = Convert.ToDouble(txtTotal.Text);
                        if (oCLPEligibility.CheckEligibility())
                        {
                            DialogResult oResult = MessageBox.Show("Are you sure the consumer want to join in club digital ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (oResult == DialogResult.Yes)
                            {
                                frmConsumer ofrm = new frmConsumer();
                                ofrm.ShowDialog(oRetailConsumer);
                                if (ofrm.IsSuccessfull == true)
                                    CalculateCLP(_oSalesInvoice, true);
                            }
                        }
                    
                        PrintRetailInvoice(_oSalesInvoice.InvoiceID, false);
                        
                        try
                        {
                            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                            {

                                Product oProduct = new Product();
                                oProduct.ProductID = oSalesInvoiceItem.ProductID;
                                oProduct.RefreshByID();
                                //if (oProduct.ItemCategory != (int)Dictionary.ItemCategory.Gift_Item)
                                {
                                    if (cmbInvoiceType.SelectedIndex == 1)
                                    {
                                        //ProductBarcode oProductBarcode = new ProductBarcode();
                                        //oProductBarcode.WarehouseID = _oSalesInvoice.WarehouseID;
                                        //oProductBarcode.ProductId = oSalesInvoiceItem.ProductID; ;
                                        //oProductBarcode.TranNo = _oSalesInvoice.InvoiceNo;
                                        //oProductBarcode.GetReatilBarcode();

                                        _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                                        _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                        _oSalesInvoiceProductSerial.ProductID = oProduct.ProductID;
                                        _oSalesInvoiceProductSerial.GetBarcode();


                                        char[] splitchar = { ',' };
                                        string sProductBarcode = _oSalesInvoiceProductSerial.ProductSerialNo;
                                        sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                        nArrayLen = sProductBarcodeArr.Length;
                                        for (int i = 0; i < nArrayLen; i++)
                                        {
                                            PrintWarrantyCard(oSalesInvoiceItem.ProductID, _oSalesInvoice, sProductBarcodeArr[i]);
                                        }
                                    }
                                    else
                                    {
                                        PrintWarrantyCardForBulk(oSalesInvoiceItem.ProductID, _oSalesInvoice);
                                    }
                                }

                            }
                        }
                        catch
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error...Please Check your input ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        CalculateCLP(_oSalesInvoice, false);
                        PrintRetailInvoice(_oSalesInvoice.InvoiceID,true);
                        try
                        {
                            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                            {
                                Product oProduct = new Product();
                                oProduct.ProductID = oSalesInvoiceItem.ProductID;
                                oProduct.RefreshByID();
                                //if (oProduct.ItemCategory != (int)Dictionary.ItemCategory.Gift_Item)
                                {
                                    if (cmbInvoiceType.SelectedIndex == 1)
                                    {
                                        //ProductBarcode oProductBarcode = new ProductBarcode();
                                        //oProductBarcode.WarehouseID = _oSalesInvoice.WarehouseID;
                                        //oProductBarcode.ProductId = oSalesInvoiceItem.ProductID; ;
                                        //oProductBarcode.TranNo = _oSalesInvoice.InvoiceNo;
                                        //oProductBarcode.GetReatilBarcode();

                                        _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                                        _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                        _oSalesInvoiceProductSerial.ProductID = oProduct.ProductID;
                                        _oSalesInvoiceProductSerial.GetBarcode();

                                        char[] splitchar = { ',' };
                                        string sProductBarcode = _oSalesInvoiceProductSerial.ProductSerialNo;
                                        sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                        nArrayLen = sProductBarcodeArr.Length;
                                        for (int i = 0; i < nArrayLen; i++)
                                        {
                                            PrintWarrantyCard(oSalesInvoiceItem.ProductID, _oSalesInvoice, sProductBarcodeArr[i]);
                                        }
                                    }
                                    else
                                    {
                                        PrintWarrantyCardForBulk(oSalesInvoiceItem.ProductID, _oSalesInvoice);
                                    }
                                }
                            }
                        }
                        catch
                        {
                            DBController.Instance.RollbackTransaction();

                            MessageBox.Show("Error...Please Check your input ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                     */
                    #endregion

                    #region Duty
                    if (Utility.CompanyInfo == "TEL")
                    {
                        _DutyLocalBalance = 0;
                        _DutyImportBalance = 0;

                        SystemInfo oIsVatActive = new SystemInfo();
                        int nIsActive = oIsVatActive.IsNewVatActive();
                        if (nIsActive == 1)
                        {
                            string dtDate = "30-Jun-2017";
                            DateTime dtVatDate = Convert.ToDateTime(dtDate).Date;
                            if (Convert.ToDateTime(oSystemInfo.OperationDate).Date > dtVatDate.Date)
                            {
                                if (IsChkVatEntry == (int)Dictionary.YesOrNoStatus.YES)
                                {
                                    oDutyTranVAT63 = GetDataForVAT63(oDutyTranVAT63);
                                    if (oDutyTranVAT63.Count > 0)
                                    {
                                        if (oDutyTranVAT63.Amount > 0)
                                        {
                                            oDutyTranVAT63.Remarks = _oSalesInvoice.Remarks;
                                            oDutyTranVAT63.InsertForPOSNew(oSystemInfo.WarehouseCode);
                                        }
                                    }
                                    oDutyAccount = new DutyAccount();
                                    oDutyAccount.DutyAccountTypeID = 3;
                                    oDutyAccount.Balance = _NewDutyBalance;
                                    oDutyAccount.UpdateBalanceForPOS(true);
                                }

                            }

                        }
                        else
                        {
                            oDutyTranVAT11 = GetDataForVAT11(oDutyTranVAT11);
                            oDutyTranVAT11KA = GetDataForVAT11KA(oDutyTranVAT11KA);

                            if (oDutyTranVAT11.Count > 0)
                            {
                                if (oDutyTranVAT11.Amount > 0)
                                {
                                    oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                                    oDutyTranVAT11.InsertForPOS(oSystemInfo.WarehouseCode);
                                }
                            }
                            if (oDutyTranVAT11KA.Count > 0)
                            {
                                if (oDutyTranVAT11KA.Amount > 0)
                                {
                                    oDutyTranVAT11KA.Remarks = _oSalesInvoice.Remarks;
                                    oDutyTranVAT11KA.InsertForPOS(oSystemInfo.WarehouseCode);
                                }
                            }


                            oDutyAccount = new DutyAccount();
                            oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                            oDutyAccount.Balance = _DutyLocalBalance;
                            oDutyAccount.UpdateBalanceForPOS(true);

                            oDutyAccount = new DutyAccount();
                            oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                            oDutyAccount.Balance = _DutyImportBalance;
                            oDutyAccount.UpdateBalanceForPOS(true);
                        }

                        //PrintVatChallan(_oSalesInvoice);
                    }

                    #endregion

                    #region SalesLead
                    if (rdoLeadCust.Checked == true && txtCustomerName.Text != "")
                    {
                        SalesLead _oSalesLead = new SalesLead();
                        _oSalesLead.LeadNo = txtLeadNo.Text;
                        _oSalesLead.RefreshByLeadNo(_nUIControl);
                        _oSalesLead.InvoiceNo = _oSalesInvoice.InvoiceNo;
                        _oSalesLead.InvoiceDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate);
                        if (_oSalesLead.Type == 1)
                        {
                            _oSalesLead.UpdateInvoiceStatus();
                        }
                        else if (_oSalesLead.Type == 2)
                        {

                            #region E-Commerce Data Update

                            EcommerceOrder _oEcommerceOrder = new EcommerceOrder();
                            _oEcommerceOrder.EComOrderID = _oSalesLead.LeadID;
                            _oEcommerceOrder.RefInvoiceNo = _oSalesInvoice.InvoiceNo;
                            _oEcommerceOrder.Status = (int)Dictionary.ECommerceOrderStatus.Invoiced;
                            _oEcommerceOrder.UpdateLeadInvoiceStatus();

                            DataTran _oDataTran = new DataTran();
                            _oDataTran.TableName = "t_SalesInvoiceEcommerce";
                            _oDataTran.DataID = _oEcommerceOrder.EComOrderID;
                            _oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                            _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            _oDataTran.BatchNo = 0;
                            _oDataTran.CreateDate = DateTime.Now.Date;
                            if (_oDataTran.CheckData())
                            {

                            }
                            else
                            {
                                _oDataTran.AddForTDPOS();
                            }
                            #endregion
                        }

                    }
                    #endregion

                    #region Outlet Display Position
                    OutletDisplayPositions _oOutletDisplayPositions = new OutletDisplayPositions();

                    _oOutletDisplayPositions.RefreshInvoiceData(_oSalesInvoice.InvoiceID);
                    foreach (OutletDisplayPosition oOutletDisplayPosition in _oOutletDisplayPositions)
                    {
                        OutletDisplayPosition oOutletDP = new OutletDisplayPosition();
                        oOutletDP.DisplayPositionID = oOutletDisplayPosition.DisplayPositionID;
                        oOutletDP.ProductSerialNo = oOutletDisplayPosition.ProductSerialNo;
                        oOutletDP.Status = (int)Dictionary.DisplayPositionStatus.Blank;
                        oOutletDP.Type = (int)Dictionary.DisplayPositionStatus.Blank;
                        oOutletDP.CreateDate = DateTime.Now.Date;
                        oOutletDP.CreateUserID = Utility.UserId;
                        oOutletDP.EditForPOSInvoice();
                        oOutletDP.AddHistory();

                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_OutletDisplayPosition";
                        oDataTran.DataID = Convert.ToInt32(oOutletDP.DisplayPositionID);
                        oDataTran.WarehouseID = Convert.ToInt32(_oSalesInvoice.WarehouseID);
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }

                        DataTran oHistoryDataTran = new DataTran();
                        oHistoryDataTran.TableName = "t_OutletDisplayPositionHistory";
                        oHistoryDataTran.DataID = Convert.ToInt32(oOutletDP.HistoryID);
                        oHistoryDataTran.WarehouseID = Convert.ToInt32(_oSalesInvoice.WarehouseID);
                        oHistoryDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oHistoryDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oHistoryDataTran.BatchNo = 0;
                        if (oHistoryDataTran.CheckData() == false)
                        {
                            oHistoryDataTran.AddForTDPOS();
                        }

                    }
                    #endregion


                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btSave.Enabled = false;
                    DBController.Instance.OpenNewConnection();
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        InvoiceWiseBarcode();
                        PrintRetailInvoice(_oSalesInvoice.InvoiceID, false);
                        if (Utility.CompanyInfo == "TEL")
                        {
                            PrintWarrantyCard(_oSalesInvoice);
                        }
                        DBController.Instance.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
        ///
        //  For VAT 11
        ///
        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11)
        {
            oDutyTranVAT11 = new DutyTran();

            DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);

            oDutyTranVAT11.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT11.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                // _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh(oItem.ProductID);
                if (_oProductDetail.VATApplicable == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                    {
                        DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                        oDutyTranDetail.ProductID = oItem.ProductID;
                        oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);
                        if (CheckProductID(oDutyTranDetail.ProductID))
                        {
                            if (oItem.UnitPrice == 0)
                            {
                                CustomerDetail oCustomerDetail = new CustomerDetail();
                                oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
                                oCustomerDetail.refresh();

                                if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                            }
                            else
                            {
                                TPVATProduct _oTPVATProduct = new TPVATProduct();
                                if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                                {
                                    oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(oItem.UnitPrice / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                }


                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = 0;
                            oDutyTranDetail.DutyRate = 0;
                        }

                        _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                        oDutyTranVAT11.Add(oDutyTranDetail);
                    }
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }
        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA)
        {
            oDutyTranVAT11KA = new DutyTran();

            DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);


            oDutyTranVAT11KA.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT11KA.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11KA.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                //_oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh(oItem.ProductID);
                if (_oProductDetail.VATApplicable == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                    {
                        DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                        oDutyTranDetail.ProductID = oItem.ProductID;
                        oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);
                        if (CheckProductID(oDutyTranDetail.ProductID))
                        {
                            if (oItem.UnitPrice == 0)
                            {
                                CustomerDetail oCustomerDetail = new CustomerDetail();
                                oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
                                oCustomerDetail.refresh();

                                if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                            }
                            else
                            {
                                TPVATProduct _oTPVATProduct = new TPVATProduct();
                                if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                                {
                                    oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(oItem.UnitPrice / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                }

                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = 0;
                            oDutyTranDetail.DutyRate = 0;
                        }

                        _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                        oDutyTranVAT11KA.Add(oDutyTranDetail);
                    }
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        ///
        //  For VAT 6.3 
        ///
        public DutyTran GetDataForVAT63(DutyTran oDutyTranVAT63)
        {
            oDutyTranVAT63 = new DutyTran();

            DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);


            oDutyTranVAT63.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT63.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT63.ChallanTypeID = (int)Dictionary.ChallanType.VAT_63;
            oDutyTranVAT63.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT63.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT63.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT63.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT63.DutyAccountID = 3;

            ProductDetails oVatProductItem = new ProductDetails();
            oVatProductItem.RefreshVatProduct(_oSalesInvoice.InvoiceID);
            foreach (ProductDetail oItem in oVatProductItem)
            {

                DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                oDutyTranDetail.ProductID = oItem.ProductID;
                oDutyTranDetail.Qty = oItem.Quantity;
                oDutyTranDetail.DutyPrice = oItem.DutyPrice;
                oDutyTranDetail.DutyRate = oItem.DutyRate;
                oDutyTranDetail.WHID = oSystemInfo.WarehouseID;
                oDutyTranDetail.UnitPrice = oItem.UnitPrice;
                oDutyTranDetail.VAT = oItem.Vat;

                _NewDutyBalance = _NewDutyBalance + oDutyTranDetail.VAT;

                oDutyTranVAT63.Add(oDutyTranDetail);


            }
            oDutyTranVAT63.Amount = _NewDutyBalance;

            return oDutyTranVAT63;
        }

        public bool CheckProductID(int nProductID)
        {
            int nCount = 0;
            foreach (int PID in ProductIDList)
            {
                if (PID == nProductID)
                    nCount++;
            }
            if (nCount == 0)
                return true;
            else return false;

        }
        private void PrintWarrantyCard(SalesInvoice _oSalesInvoice)
        {
            try
            {
                foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                {

                    Product oProduct = new Product();
                    oProduct.ProductID = oSalesInvoiceItem.ProductID;
                    oProduct.RefreshByID();
                    {
                        if (cmbInvoiceType.SelectedIndex == 1)
                        {
                            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                            _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                            _oSalesInvoiceProductSerial.ProductID = oProduct.ProductID;
                            _oSalesInvoiceProductSerial.GetBarcode();


                            char[] splitchar = { ',' };
                            if (_oSalesInvoiceProductSerial.ProductSerialNo != null)
                            {
                                string sProductBarcode = _oSalesInvoiceProductSerial.ProductSerialNo;
                                sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                nArrayLen = sProductBarcodeArr.Length;
                                for (int i = 0; i < nArrayLen; i++)
                                {
                                    PrintWarrantyCard(oSalesInvoiceItem.ProductID, _oSalesInvoice, sProductBarcodeArr[i]);
                                }
                            }
                        }
                        else
                        {
                            PrintWarrantyCardForBulk(oSalesInvoiceItem.ProductID, _oSalesInvoice);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw (ex);
                //DBController.Instance.RollbackTransaction();
                //MessageBox.Show("Error...Printing Warranty Card ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

        }
        public void InsertPromotionMapping(int nSalesPromotionID, string sInvoiceNo)
        {
            _oSalesInvoicePromotionMappings = new SalesInvoicePromotionMappings();
            _oSalesInvoicePromotionMappings.RefreshBySalesPromotionID(nSalesPromotionID);

            foreach (SalesInvoicePromotionMapping oSIPM in _oSalesInvoicePromotionMappings)
            {
                oSIPM.OutletID = oSystemInfo.WarehouseID;
                oSIPM.InvoiceNo = sInvoiceNo;
                oSIPM.Add();
            }
        }
        public void InvoiceWiseBarcode()
        {
            SL = "";

            //SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(_oSalesInvoice.InvoiceID);

            foreach (SalesInvoiceProductSerial SIPS in _oSalesInvoiceProductSerials)
            {
                //IsSL = true;
                string PCode = "";

                _oSIPSs = new SalesInvoiceProductSerials();
                _oSIPSs.GetBarcodeByInvoiceNProduct(SIPS.InvoiceID, SIPS.ProductID);

                foreach (SalesInvoiceProductSerial SIPSs in _oSIPSs)
                {
                    //IsSL = false;
                    if (PCode == "")
                    {
                        PCode = "<" + SIPSs.ProductCode + ">";
                    }
                    else
                    {
                        PCode = " ";
                    }
                    if (SL != "")
                    {
                        SL = SL + ",";
                    }
                    SL = SL + PCode + SIPSs.ProductSerialNo;
                }
            }
        }

        ///
        // Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///
        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice)
        {

            double Charge = 0;

            _oSalesInvoice.InvoiceDate = dtInvoiceDate.Value.Date;
            if (_nUIControl != (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
            {
                _oSalesInvoice.CustomerID = nCustomerID;
            }
            else
            {
                _oSalesInvoice.CustomerID = oSystemInfo.CustomerID;
            }
            _oSalesInvoice.DeliveryAddress = oSystemInfo.WarehouseAddress;
            _oSalesInvoice.DeliveryDate = dtDeliveryDate.Value.Date;
            _oSalesInvoice.SalesPersonID = oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;
            _oSalesInvoice.WarehouseID = oSystemInfo.WarehouseID;
            _oSalesInvoice.InvoiceStatus = (int)Dictionary.InvoiceStatus.DELIVERED;
            _oSalesInvoice.CreateDate = dtInvoiceDate.Value.Date;
            try
            {
                _oSalesInvoice.Discount = _TotalDiscount;
            }
            catch
            {
                _oSalesInvoice.Discount = 0;
            }
            _oSalesInvoice.Remarks = txtRemarks.Text;
            _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CASH;

            _oSalesInvoice.UserID = Utility.UserId;
            try
            {
                _oSalesInvoice.InvoiceAmount = Convert.ToDouble(txtNetPay.Text);
            }
            catch
            {
                _oSalesInvoice.InvoiceAmount = 0;
            }
            _oSalesInvoice.PriceOptionID = (int)Dictionary.PriceOption.RSP;

            try
            {
                Charge = Charge + Convert.ToDouble(txtInstallationCharge.Text);
            }
            catch
            {

            }
            try
            {
                Charge = Charge + Convert.ToDouble(txtFreightCharge.Text);
            }
            catch
            {

            }
            try
            {
                Charge = Charge + Convert.ToDouble(txtOtherCharge.Text);
            }
            catch
            {

            }
            try
            {
                Charge = Charge + Convert.ToDouble(txtMarkUp.Text);
            }
            catch
            {

            }
            _oSalesInvoice.OtherCharge = Charge;
            //if (ctlRetailConsumer1.SelectedCustomer == null || ctlRetailConsumer1.txtCode.Text == "")
            //{
            //    _oSalesInvoice.SundryCustomerID = oRetailConsumer.ConsumerID;
            //}
            //else
            //{
            //    _oSalesInvoice.SundryCustomerID = ctlRetailConsumer1.SelectedCustomer.ConsumerID;
            //}

            if (rdoNewConsumer.Checked == true)
            {
                _oSalesInvoice.SundryCustomerID = oRetailConsumer.ConsumerID;
            }
            else if (rdoExistingConsumer.Checked == true)
            {
                _oSalesInvoice.SundryCustomerID = ctlRetailConsumer1.SelectedCustomer.ConsumerID;
            }
            else if (rdoLeadCust.Checked == true)
            {
                if (nLeadConsumer != 0)
                {
                    _oSalesInvoice.SundryCustomerID = nLeadConsumer;
                }
                else
                {
                    _oSalesInvoice.SundryCustomerID = oRetailConsumer.ConsumerID;
                }

            }

            #region Get Line Item
            if (dgvLineItem.Rows.Count > 1)
            {
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                        _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                        _oSalesInvoiceItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());

                        _oProductDetail = new ProductDetail();
                        _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate), _oSalesInvoiceItem.ProductID);

                        _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                        _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                        if (_oSalesInvoiceItem.UnitPrice == 0)
                        {
                            _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                        }
                        else
                        {
                            TPVATProduct _oTPVATProduct = new TPVATProduct();
                            if (_oTPVATProduct.IsProductExists(_oSalesInvoiceItem.ProductID))
                            {

                                _oSalesInvoiceItem.TradePrice = _oTPVATProduct.TradePrice;
                            }
                            else
                            {
                                _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                            }

                        }

                        _oSalesInvoiceItem.AdjustedDPAmount = 0;
                        _oSalesInvoiceItem.AdjustedPWAmount = 0;
                        _oSalesInvoiceItem.AdjustedTPAmount = 0;
                        _oSalesInvoiceItem.PromotionalDiscount = 0;

                        int nIsFreeProduct = 0;
                        int nFreeQty = 0;

                        foreach (DataGridViewRow oItemProdRow in dvgProduct.Rows)
                        {
                            if (oItemProdRow.Index < dvgProduct.Rows.Count)
                            {
                                if (_oSalesInvoiceItem.ProductID == int.Parse(oItemProdRow.Cells[7].Value.ToString()))
                                {
                                    nIsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                                    nFreeQty = nFreeQty + int.Parse(oItemProdRow.Cells[4].Value.ToString());
                                }

                            }
                        }

                        foreach (DataGridViewRow oItemSCQRow in dgvScratchCardQty.Rows)
                        {
                            if (oItemSCQRow.Index < dgvScratchCardQty.Rows.Count - 1)
                            {
                                if (_oSalesInvoiceItem.ProductID == int.Parse(oItemSCQRow.Cells[8].Value.ToString()))
                                {
                                    nIsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                                    nFreeQty = nFreeQty + int.Parse(oItemSCQRow.Cells[3].Value.ToString());
                                }
                            }
                        }

                        try
                        {
                            //_oSalesInvoiceItem.IsFreeProduct = int.Parse(oItemRow.Cells[11].Value.ToString());
                            _oSalesInvoiceItem.IsFreeProduct = nIsFreeProduct;

                        }
                        catch
                        {
                            _oSalesInvoiceItem.IsFreeProduct = 0;

                        }

                        try
                        {
                            //_oSalesInvoiceItem.FreeQty = int.Parse(oItemRow.Cells[12].Value.ToString());
                            _oSalesInvoiceItem.FreeQty = nFreeQty;
                        }
                        catch
                        {
                            _oSalesInvoiceItem.FreeQty = 0;

                        }
                        try
                        {
                            _oSalesInvoiceItem.Quantity = int.Parse(oItemRow.Cells[6].Value.ToString());

                        }
                        catch
                        {
                            _oSalesInvoiceItem.Quantity = 0;

                        }

                        _oSalesInvoice.Add(_oSalesInvoiceItem);
                    }
                }
            }
            #endregion
            #region Get Free/Promotional Product
            if (dvgProduct.Rows.Count > 0)
            {
                int nCount = 0;
                foreach (DataGridViewRow oItemRow in dvgProduct.Rows)
                {
                    if (oItemRow.Index < dvgProduct.Rows.Count)
                    {
                        foreach (DataGridViewRow oItemLineRow in dgvLineItem.Rows)
                        {
                            if (oItemLineRow.Index < dgvLineItem.Rows.Count - 1)
                            {
                                if (int.Parse(oItemRow.Cells[7].Value.ToString()) == int.Parse(oItemLineRow.Cells[9].Value.ToString()))
                                {
                                    nCount++;
                                }

                            }
                        }
                        if (nCount == 0)
                        {

                            SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                            _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());

                            _oProductDetail = new ProductDetail();
                            _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate), _oSalesInvoiceItem.ProductID);

                            _oSalesInvoiceItem.UnitPrice = _oProductDetail.RSP;
                            _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                            _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                            if (_oSalesInvoiceItem.UnitPrice == 0)
                                _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                            else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / 1.02, 4);

                            _oSalesInvoiceItem.AdjustedDPAmount = 0;
                            _oSalesInvoiceItem.AdjustedPWAmount = 0;
                            _oSalesInvoiceItem.AdjustedTPAmount = 0;
                            _oSalesInvoiceItem.PromotionalDiscount = 0;

                            _oSalesInvoiceItem.IsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                            _oSalesInvoiceItem.FreeQty = int.Parse(oItemRow.Cells[4].Value.ToString());


                            _oSalesInvoiceItem.Quantity = 0;

                            _oSalesInvoice.Add(_oSalesInvoiceItem);
                        }
                    }

                }
            }
            #endregion
            #region Get Scratch Card Product
            if (dgvScratchCardQty.Rows.Count > 1)
            {
                int nCount = 0;

                foreach (DataGridViewRow oItemRow in dgvScratchCardQty.Rows)
                {
                    if (oItemRow.Index < dgvScratchCardQty.Rows.Count - 1)
                    {
                        foreach (DataGridViewRow oItemLineRow in dgvLineItem.Rows)
                        {
                            if (oItemLineRow.Index < dgvLineItem.Rows.Count - 1)
                            {
                                if (int.Parse(oItemRow.Cells[8].Value.ToString()) == int.Parse(oItemLineRow.Cells[9].Value.ToString()))
                                {
                                    nCount++;
                                }
                            }
                        }

                        if (nCount == 0)
                        {

                            SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                            _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());

                            _oProductDetail = new ProductDetail();
                            _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate), _oSalesInvoiceItem.ProductID);

                            _oSalesInvoiceItem.UnitPrice = _oProductDetail.RSP;
                            _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                            _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                            if (_oSalesInvoiceItem.UnitPrice == 0)
                                _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                            else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / 1.02, 4);

                            _oSalesInvoiceItem.AdjustedDPAmount = 0;
                            _oSalesInvoiceItem.AdjustedPWAmount = 0;
                            _oSalesInvoiceItem.AdjustedTPAmount = 0;
                            _oSalesInvoiceItem.PromotionalDiscount = 0;

                            _oSalesInvoiceItem.IsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                            _oSalesInvoiceItem.FreeQty = int.Parse(oItemRow.Cells[3].Value.ToString());


                            _oSalesInvoiceItem.Quantity = 0;

                            _oSalesInvoice.Add(_oSalesInvoiceItem);
                        }
                    }

                }
            }
            #endregion
            return _oSalesInvoice;
        }
        ///
        // End  Customer Transaction.
        ///

        ///
        // Get Data for  Product Transaction.
        ///
        public StockTran SetData(StockTran oStockTran, SalesInvoice _oSalesInvoice)
        {
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
            oStockTran.FromChannelID = oSystemInfo.ChannelID;
            oStockTran.FromWHID = _oSalesInvoice.WarehouseID;
            oStockTran.ToChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
            oStockTran.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;

            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = Convert.ToDateTime(oSystemInfo.OperationDate);

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                if (oSalesInvoiceItem.IsFreeProduct == 0)
                    oItem.Qty = oSalesInvoiceItem.Quantity;
                else oItem.Qty = oSalesInvoiceItem.FreeQty;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
            }
            return oStockTran;
        }

        ///
        // End Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///

        ///
        // Get Data for  Customer Transaction.
        ///
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction)
        {
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = txtRemarks.Text;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;

            return _oCustomerTransaction;
        }

        public CustomerTransaction GetCustomerTranForCollection(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice)
        {
            _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.TranDate = DateTime.Today.Date;
            double _BGAmt = 0;
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (Convert.ToInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Customer_BG)
                    {
                        _BGAmt = _BGAmt + Convert.ToDouble(oItemRow.Cells[1].Value);

                    }

                }
            }
            _oCustomerTransaction.Amount = Convert.ToDouble(txtNetPay.Text) - _BGAmt;
            _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;

            return _oCustomerTransaction;
        }

        public void GetTotalRSAmount()
        {
            txtTotal.Text = "0.00";
            oTELLib = new TELLib();
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[3].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            txtTotal.Text = oTELLib.TakaFormat(Convert.ToDouble(txtTotal.Text) + Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) * Convert.ToDouble(oItemRow.Cells[6].Value.ToString()));

                        }
                        catch
                        {

                        }
                    }

                }
            }
            GetNetAmount();

        }

        public void GetTotalDiscountAmount()
        {
            txtTotalDisount.Text = "0.00";
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[4].Value != null)
                    {
                        try
                        {
                            txtTotalDisount.Text = Convert.ToString(Convert.ToDouble(txtTotalDisount.Text) + Convert.ToDouble(oItemRow.Cells[4].Value.ToString()));

                        }
                        catch
                        {

                        }
                    }

                }
            }

        }

        private void ckbMarkup_CheckedChanged(object sender, EventArgs e)
        {

            if (ckbMarkup.Checked)
            {
                txtMarkUp.Text = _MarkUpAMount.ToString();

            }
            else
            {

                txtMarkUp.Text = "0.0";
            }
        }

        private void rdoPercentage_CheckedChanged(object sender, EventArgs e)
        {
            txtParcentage.Enabled = true;
            txtFlatAmount.Enabled = false;
            txtFlatAmount.Text = "0.00";
            cmbDiscountReason.Enabled = true;
            GetNetAmount();
        }

        private void rdoFlatAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtFlatAmount.Enabled = true;
            txtParcentage.Enabled = false;
            txtParcentage.Text = "0.00";
            cmbDiscountReason.Enabled = true;
            GetNetAmount();
        }

        private void txtInstallationCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtInstallationCharge.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtInstallationCharge.Text);
                    GetNetAmount();

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInstallationCharge.Text = "";
                }
            }

        }

        private void txtFreightCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtFreightCharge.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtFreightCharge.Text);
                    GetNetAmount();

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFreightCharge.Text = "";
                }
            }

        }

        private void txtOtherCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtOtherCharge.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtOtherCharge.Text);
                    GetNetAmount();

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOtherCharge.Text = "";
                }
            }

        }

        private void txtParcentage_TextChanged(object sender, EventArgs e)
        {
            if (txtParcentage.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtParcentage.Text);
                    GetNetAmount();

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Parcentage ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtParcentage.Text = "";
                }
            }


        }

        private void txtFlatAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtFlatAmount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtFlatAmount.Text);
                    GetNetAmount();

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFlatAmount.Text = "";
                }
            }

        }

        private void GetNetAmount()
        {
            double _Percentage = 0;
            double _FlatAmount = 0;

            double _InstallationCharge = 0;
            double _FreightCharge = 0;
            double _OtherCharge = 0;

            if (rdoPercentage.Checked == true)
            {
                if (txtParcentage.Text != "")
                {
                    _Percentage = ((Convert.ToDouble(txtTotal.Text)) * (Convert.ToDouble(txtParcentage.Text) / 100));
                }
            }
            else
            {

                if (txtFlatAmount.Text != "")
                {
                    _FlatAmount = Math.Round(Convert.ToDouble(txtFlatAmount.Text), 0, MidpointRounding.AwayFromZero);
                }
            }

            if (txtInstallationCharge.Text != "")
                _InstallationCharge = Math.Round(Convert.ToDouble(txtInstallationCharge.Text), 0, MidpointRounding.AwayFromZero);

            if (txtFreightCharge.Text != "")
                _FreightCharge = Math.Round(Convert.ToDouble(txtFreightCharge.Text), 0, MidpointRounding.AwayFromZero);

            if (txtOtherCharge.Text != "")
                _OtherCharge = Math.Round(Convert.ToDouble(txtOtherCharge.Text), 0, MidpointRounding.AwayFromZero);

            _TotalDiscount = Math.Round(Convert.ToDouble(txtTotalDisount.Text), 0, MidpointRounding.AwayFromZero) + _FlatAmount + Math.Round(_Percentage, 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDouble(txtSMSDiscount.Text), 0, MidpointRounding.AwayFromZero);

            oTELLib = new TELLib();
            txtNetPay.Text = oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtTotal.Text), 0, MidpointRounding.AwayFromZero) + _InstallationCharge + _FreightCharge + _OtherCharge + Math.Round(Convert.ToDouble(txtMarkUp.Text), 0, MidpointRounding.AwayFromZero) - _TotalDiscount);

            if (Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero) >= 0)
                txtNetPay.ForeColor = Color.Green;
            else txtNetPay.ForeColor = Color.Red;
            lblpayableAmount.Text = "Net Payable (In Word): " + oTELLib.TakaWords(Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero));
            txtDueAmount.Text = oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero) - Math.Round(Convert.ToDouble(txtCollectionAmount.Text), 0, MidpointRounding.AwayFromZero));

            if (Math.Round(Convert.ToDouble(txtDueAmount.Text), 0, MidpointRounding.AwayFromZero) != 0)
                txtDueAmount.ForeColor = Color.Red;
            else txtDueAmount.ForeColor = Color.Green;
        }

        public void PrintRetailInvoice(long nInvoiceID, bool IsCLP)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            bool _bCreditCardVisible = false;
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            oTELLib = new TELLib();
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = Convert.ToInt32(orptSalesInvoice.SalesPersonID);
            oEmployee.RefreshForPOS();

            foreach (rptSalesInvoiceDetail orptSalesInvoiceDetail in orptSalesInvoice)
            {
                if (orptSalesInvoiceDetail.Quantity != 0)
                {
                    DSSalesInvoiceDetail.SalesProductRow oSalesProductRow = oDSSalesInvoiceProduct.SalesProduct.NewSalesProductRow();

                    oSalesProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oSalesProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oSalesProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oSalesProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;
                    oSalesProductRow.UnitPrice = orptSalesInvoiceDetail.UnitPrice;
                    oSalesProductRow.Qty = orptSalesInvoiceDetail.Quantity;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                else if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    oFreeGiftProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oFreeGiftProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    //oFreeGiftProductRow.Barcode = orptSalesInvoiceDetail.FreeProductBarcode;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();
            if (ctlRetailConsumer1.SelectedCustomer == null)
            {
                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = int.Parse(orptSalesInvoice.CustomerID.ToString());
            }
            oRetailConsumer.RefreshForPOS();

            oRetailSalesInvoice = new RetailSalesInvoice();
            oRetailSalesInvoice.InvoiceID = nInvoiceID;
            oRetailSalesInvoice.RefreshInvoiceCharge();
            oRetailSalesInvoice.RefreshPaymentMode();
            oRetailSalesInvoice.RefreshSMSDiscoutn(orptSalesInvoice.InvoiceNo);
            rptRetailInvoice doc;
            doc = new rptRetailInvoice();
            doc.SetDataSource(oDSSalesInvoiceDetail);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("Address", oSystemInfo.WarehouseAddress + ", Outlet Phone No:" + oSystemInfo.WarehousePhoneNo);
            doc.SetParameterValue("Mobile", oSystemInfo.WarehouseCellNo + ", e-mail:" + oSystemInfo.WarehouseEmail);
            doc.SetParameterValue("HC", oSystemInfo.HCMobileNo + ", e-mail:" + oSystemInfo.HCEmail);

            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");

            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");
            doc.SetParameterValue("RefInvoice", "");
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);

            doc.SetParameterValue("SPDiscount", oRetailSalesInvoice.SPDiscount);
            if (oRetailSalesInvoice.TotalDiscount != 0)
            {
                if (oRetailSalesInvoice.SPParcentage != 0)
                {
                    doc.SetParameterValue("IspercentDiscount?", true);
                }
                else
                {
                    doc.SetParameterValue("IspercentDiscount?", false);
                }
            }
            else
            {
                doc.SetParameterValue("IspercentDiscount?", false);
            }
            doc.SetParameterValue("SDiscount", oRetailSalesInvoice.TotalDiscount);
            doc.SetParameterValue("Discount", orptSalesInvoice.Discount);
            doc.SetParameterValue("smsDiscount", oRetailSalesInvoice.smsDiscount);

            doc.SetParameterValue("FCharge", oRetailSalesInvoice.FreightCharge);
            doc.SetParameterValue("ICharge", oRetailSalesInvoice.InstallationCharge);
            doc.SetParameterValue("OCharge", oRetailSalesInvoice.OtherCharge);
            doc.SetParameterValue("MCharge", oRetailSalesInvoice.MarkUpAmount);
            doc.SetParameterValue("Charge", oRetailSalesInvoice.TotalCharge);

            doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

            doc.SetParameterValue("Cash", oRetailSalesInvoice.Cash);
            doc.SetParameterValue("Credit", oRetailSalesInvoice.Credit);
            doc.SetParameterValue("AdvanceAdjust", oRetailSalesInvoice.AdvanceAdjust);
            doc.SetParameterValue("OthersPayment", oRetailSalesInvoice.Others);
            doc.SetParameterValue("Payment", oRetailSalesInvoice.TotalAmount);

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            //doc.SetParameterValue("Barcode", sBarcode);

            doc.SetParameterValue("Barcode", SL);

            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);
            doc.SetParameterValue("IsVisibleCreditCard", _bCreditCardVisible);

            doc.SetParameterValue("IsCLP", IsCLP);
            if (IsCLP)
            {
                doc.SetParameterValue("PBalance", oCLPTran.PreviousPoint);
                doc.SetParameterValue("RBalance", oCLPTran.CurrentPoint - oCLPTran.PreviousPoint);
                doc.SetParameterValue("CBalance", oCLPTran.CurrentPoint);
            }
            else
            {
                doc.SetParameterValue("PBalance", 0);
                doc.SetParameterValue("RBalance", 0);
                doc.SetParameterValue("CBalance", 0);
            }
            SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
            oSalesInvoiceEcommerceLeadChallan.GetOrderNobyInvNo(orptSalesInvoice.InvoiceNo.ToString());
            if (oSalesInvoiceEcommerceLeadChallan.ChallanNo != null)
            {
                doc.SetParameterValue("EcommOrderNo", oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString());
            }
            else
            {
                doc.SetParameterValue("EcommOrderNo", "");
            }


            frmPrintPreviewWithoutExport frmView;
            frmView = new frmPrintPreviewWithoutExport();
            frmView.ShowDialog(doc);
        }

        public void PrintWarrantyCardForBulk(int nProductID, SalesInvoice _oSalesInvoice)
        {
            WarrantyParam oWarrantyParam = new WarrantyParam();

            if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            {

                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                oRetailConsumer.Refresh();

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();


                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                _oSalesInvoiceProductSerial.ProductID = nProductID;
                _oSalesInvoiceProductSerial.GetBarcode();

                try
                {
                    oWarrantyParameter = new WarrantyParameter();

                    //oWarrantyParameter.GetNextWarrantyCardNo(int.Parse(_oSalesInvoice.InvoiceID.ToString()), _oSalesInvoice.WarehouseID, nProductID, oWarrantyParam.WarrantyParamID);

                }
                catch (Exception ex)
                {
                    int Tem = int.Parse("");
                }

                rptWarrantyCard doc;
                doc = new rptWarrantyCard();

                doc.SetParameterValue("WarrantyCardNo", oWarrantyParameter.WarrantyCardNo);

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);

                doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                doc.SetParameterValue("Address", oRetailConsumer.Address);
                doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                doc.SetParameterValue("Email", oRetailConsumer.Email);

                //doc.SetParameterValue("AG", oProductDetail.AGName);
                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                //doc.SetParameterValue("ModelName", oProductDetail.ProductModel);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("OutletName", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", _oSalesInvoiceProductSerial.ProductSerialNo);

                if (oProductDetail.MAGID == 791) //FPTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 792) //HTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 22) //REF
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 811) //FRZ
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 0) //LCAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 25) //RAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 804) //CAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 23) //WM
                {
                    doc.SetParameterValue("SpecialComponent", "Motor");
                }
                else
                {
                    doc.SetParameterValue("SpecialComponent", "SpecialComponent");
                }


                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
        }

        public void PrintWarrantyCard(int nProductID, SalesInvoice _oSalesInvoice, string sBarcode)
        {

            //oWarrantyProducts = new WarrantyProducts();
            WarrantyParam oWarrantyParam = new WarrantyParam();

            if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            {

                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                oRetailConsumer.RefreshForPOS();

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();

                try
                {
                    oWarrantyParameter = new WarrantyParameter();

                    oWarrantyParameter.GetNextWarrantyCardNo(int.Parse(_oSalesInvoice.InvoiceID.ToString()), _oSalesInvoice.WarehouseID, nProductID, oWarrantyParam.WarrantyParamID, sBarcode);

                }
                catch (Exception ex)
                {
                    int Tem = int.Parse("");
                }

                QRCodeGen(oWarrantyParam, oRetailConsumer, _oSalesInvoice, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();

                rptWarrantyCard doc;
                doc = new rptWarrantyCard();

                doc.SetDataSource(oDSQRCode);

                doc.SetParameterValue("WarrantyCardNo", oWarrantyParameter.WarrantyCardNo);

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);
                if (oRetailConsumer.SalesType != (int)Dictionary.SalesType.Dealer)
                {
                    doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                    doc.SetParameterValue("Address", oRetailConsumer.Address);
                    doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                    doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                    doc.SetParameterValue("Email", oRetailConsumer.Email);
                    doc.SetParameterValue("DealerName", "");
                    doc.SetParameterValue("IsDealer", false);
                    doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("Name", "");
                    doc.SetParameterValue("Address", "");
                    doc.SetParameterValue("Telephone", "");
                    doc.SetParameterValue("Mobile", "");
                    doc.SetParameterValue("Email", "");
                    doc.SetParameterValue("DealerName", oRetailConsumer.ConsumerName + "/" + Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("yyyyMMdd"));
                    doc.SetParameterValue("IsDealer", true);
                    doc.SetParameterValue("InvoiceDate", "");
                }
                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("OutletName", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", sBarcode);
                if (oProductDetail.MAGID == 791) //FPTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 792) //HTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 22) //REF
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 811) //FRZ
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 0) //LCAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 25) //RAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 804) //CAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 23) //WM
                {
                    doc.SetParameterValue("SpecialComponent", "Motor");
                }
                else
                {
                    doc.SetParameterValue("SpecialComponent", "SpecialComponent");
                }


                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();

        }

        private void QRCodeGen(WarrantyParam oWarrantyParam, RetailConsumer oRetailConsumer, SalesInvoice _oSalesInvoice, string sBarcode, string sProductCode, string sProductName)
        {
            ZAM.QRCode.Codec.QRCodeEncoder qrCodeEncoder = new ZAM.QRCode.Codec.QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = ZAM.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE;
            try
            {
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 15;
                qrCodeEncoder.QRCodeErrorCorrect = ZAM.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.M;

                String data = oRetailConsumer.ConsumerCode +
                                "\n" + _oSalesInvoice.InvoiceNo +
                                "\n" + _oSalesInvoice.InvoiceDate.ToString();
                if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                {
                    data = data + "\n" + "" +
                     "\n" + "" +
                     "\n" + "" +
                     "\n" + "";
                }
                else
                {
                    data = data + "\n" + oRetailConsumer.ConsumerName +
                    "\n" + oRetailConsumer.Address +
                    "\n" + oRetailConsumer.CellNo +
                    "\n" + oRetailConsumer.Email;
                }
                data = data + "\n" + sProductCode +
                "\n" + sProductName +
                "\n" + sBarcode +
                "\n" + oWarrantyParam.ServiceWarranty +
                "\n" + oWarrantyParam.PartsWarranty +
                "\n" + oWarrantyParam.SpecialComponentWarranty +
                "\n" + oRetailConsumer.ParentCustomerID;
                if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                {
                    data = data + "\n" + Convert.ToString(Utility.DealerChannelID);
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2B || oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2C)
                {
                    data = data + "\n" + Convert.ToString(Utility.TDCorporateChannelID);
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.HPA)
                {
                    data = data + "\n" + Convert.ToString(Utility.TDHPAChannelID);
                }
                else
                {
                    data = data + "\n" + Convert.ToString(Utility.RetailChannelID);
                }
                iImage = qrCodeEncoder.Encode(data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void CalculateCLP(SalesInvoice _oSalesInvoice, bool IsTrue)
        {
            oCLPPoint = new CLPPoint();
            oCLPPointSlab = new CLPPointSlab();
            oCLPPoint.EffectDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
            oCLPPoint.GetCLPPoint();
            oCLPPointSlab.PointID = oCLPPoint.PointID;
            oCLPPointSlab.Refresh();

            oCLPTran = new CLPTran();

            oCLPTran.TranDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
            oCLPTran.WarehouseID = _oSalesInvoice.WarehouseID;
            oCLPTran.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
            oCLPTran.CustomerID = oSystemInfo.CustomerID;
            oCLPTran.PreviousPoint = oRetailConsumer.CurrentCLP;
            double _CPonit = Convert.ToDouble(txtTotal.Text) / oCLPPointSlab.SlabAmount + oRetailConsumer.CurrentCLP;
            oCLPTran.CurrentPoint = (int)_CPonit;
            oCLPTran.EncashmentPoint = 0;
            oCLPTran.UserID = Utility.UserId;
            oCLPTran.TranTypeID = (int)Dictionary.CLPTranType.INVOICE;

            oCLPTran.Insert(IsTrue);
        }

        public ProductTransaction GetUIProductTransactionData(ProductTransaction oProductTransaction, SalesInvoice _oSalesInvoice, SalesInvoiceItem _oSalesInvoiceItem)
        {
            oProductTransaction.TranNo = _oSalesInvoice.InvoiceNo;

            oProductTransaction.POID = -1;
            oProductTransaction.LCNo = "";
            oProductTransaction.ToWHID = _oSalesInvoice.WarehouseID;
            oProductTransaction.ToChannelID = oSystemInfo.ChannelID;
            oProductTransaction.Remarks = _oSalesInvoice.Remarks;
            oProductTransaction.UserID = Utility.UserId;
            oProductTransaction.Terminal = 1;

            // Product Detail


            ProductTransactionDetail oItem = new ProductTransactionDetail();

            try
            {
                oItem.Qty = Convert.ToInt64(_oSalesInvoiceItem.FreeQty);
            }
            catch (Exception ex)
            {
                oItem.Qty = Convert.ToInt64(0);
            }

            oItem.LCShortQty = 0;
            oItem.LCDamagedQty = 0;
            oItem.LCMinorDefectiveQty = 0;
            oItem.LCRemarks = "";

            oItem.ProductID = _oSalesInvoiceItem.ProductID;
            oItem.StockPrice = 0;

            oProductTransaction.Add(oItem);


            return oProductTransaction;
        }

        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            oSelectedSPromotions = new SPromotions();

        }

        private void dgvLineItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[11].Value.ToString()) == 0)
                    oSelectedSPromotions = new SPromotions();
            }
            catch
            {
                oSelectedSPromotions = new SPromotions();
            }
        }

        public void CalculatePromotionForSlab(int nChannelID)
        {
            if (dgvLineItem.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[9].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (oItemRow.Cells[9].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[9].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (oItemRow.Cells[9].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[6].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please Input Valid Product Barocde or Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (dgvLineItem.Rows.Count == 1)
            {
                dvgProduct.Rows.Clear();
                dgvDiscount.Rows.Clear();
                dgvPromoProduct.Rows.Clear();
                return;
            }
            DBController.Instance.OpenNewConnection();
            oResultSPromotions = new SPromotions();
            oResultSPromotions = GetPromotionResult(oResultSPromotions, nChannelID);
            DispalyPromotionResult(oResultSPromotions);
            nDisplayPrmoCount++;
        }

        public void DispalyPromoProduct(int nSalesPromotionID, string sSalesPromotionNo, int nCount, bool _bFlag)
        {
            oSPProducts = new SPProducts();
            oSPProducts.Refresh(nSalesPromotionID);

            foreach (SPProduct oSPProduct in oSPProducts)
            {
                _oProductDetail = new ProductDetail();
                //_oProductDetail.ProductID = oSPProduct.ProductID;
                _oProductDetail.Refresh(oSPProduct.ProductID);
                int nInvoiceQty = 0;

                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
                        {
                            nInvoiceQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                        }
                    }
                }
                _oSPSlabRatio = new SPSlabRatio();
                bool _b = _oSPSlabRatio.RefreshRatioQty(nSalesPromotionID, oSPProduct.ProductID, nInvoiceQty);

                if (_b)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvPromoProduct);
                    oRow.Cells[0].Value = sSalesPromotionNo;
                    oRow.Cells[1].Value = _oProductDetail.ProductCode;
                    oRow.Cells[2].Value = _oProductDetail.ProductName;
                    oRow.Cells[3].Value = _oProductDetail.ProductID;
                    if (_bFlag == true)
                    {
                        oRow.Cells[4].Value = _oSPSlabRatio.Qty * nCount;
                    }
                    else
                    {
                        oRow.Cells[4].Value = _oSPSlabRatio.Qty;
                    }
                    oRow.Cells[5].Value = nSalesPromotionID;
                    int nRowIndex = dgvPromoProduct.Rows.Add(oRow);
                }
            }
        }

        public void CalculatePromotionNonSlab(int nChannelID)
        {
            if (dgvLineItem.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[9].Value == null)
                    {
                        MessageBox.Show("Please Input Valied Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (oItemRow.Cells[9].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[9].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please Input Valied Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (oItemRow.Cells[9].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[6].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please Input Valied Product Barocde or Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (dgvLineItem.Rows.Count == 1)
            {
                dvgProduct.Rows.Clear();
                dgvDiscount.Rows.Clear();
                dgvPromoProduct.Rows.Clear();
                return;
            }
            DBController.Instance.OpenNewConnection();
            oResultSPromotions = new SPromotions();
            //dgvDiscount.Rows.Clear();
            oResultSPromotions = GetNonSlabPromotionResult(oResultSPromotions, nChannelID);
            //DispalyPromotionResult(oResultSPromotions);
            //nDisplayPrmoCount++;
        }

        private void dgvScratchCardQty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvScratchCardQty);
                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[8].Value = oForm.sProductId;


                if (oForm.sProductCode != null)
                {

                    int nRowIndex = dgvScratchCardQty.Rows.Add(oRow);
                    if (checkDuplicateLineItem(dgvScratchCardQty.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScratchCardQty.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvScratchCardQty.Rows[e.RowIndex].Cells[0].ReadOnly = true;

                        _oProduct = new Product();
                        _oProduct.ProductID = Convert.ToInt32(oForm.sProductId);
                        _oProduct.RefreshByProductID();
                        dgvScratchCardQty.Rows[e.RowIndex].Cells[9].Value = _oProduct.IsBarcodeItem;
                        if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                        {
                            dgvScratchCardQty.Rows[e.RowIndex].Cells[3].ReadOnly = false;
                            dgvScratchCardQty.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dgvScratchCardQty.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                        }
                    }
                }

            }
            else if (e.ColumnIndex == 5)
            {
                try
                {
                    int temp = int.Parse(dgvScratchCardQty.Rows[e.RowIndex].Cells[8].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Select a Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmAvailableBarcode ofrmAvailableBarcode = new frmAvailableBarcode(int.Parse(dgvScratchCardQty.Rows[e.RowIndex].Cells[8].Value.ToString()), oSystemInfo.WarehouseID, "", 0);
                ofrmAvailableBarcode.ShowDialog();

                if (ofrmAvailableBarcode._nCount > 0)
                {
                    dgvScratchCardQty.Rows[e.RowIndex].Cells[4].Value = ofrmAvailableBarcode._sBarcode;
                    dgvScratchCardQty.Rows[e.RowIndex].Cells[3].Value = ofrmAvailableBarcode._nCount;
                }
            }


        }

        private void dgvScratchCardQty_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshScratchCardRow(e.RowIndex, e.ColumnIndex);
        }

        private void refreshScratchCardRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateLineItem(dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvScratchCardQty.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    Product oProduct = new Product();
                    DBController.Instance.OpenNewConnection();
                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();

                    if (oProduct.Flag != true)
                    {
                        dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                        dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (oProduct.ProductID).ToString();
                        dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                        _oProduct = new Product();
                        _oProduct.ProductID = Convert.ToInt32(oProduct.ProductID);
                        _oProduct.RefreshByProductID();
                        dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = _oProduct.IsBarcodeItem;
                        if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                        {
                            dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex + 3].ReadOnly = false;
                            dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex + 3].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex + 3].ReadOnly = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScratchCardQty.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        }

        double _dPaymentTotal = 0;
        double _dDueAmount = 0;

        private void dgvPayment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _dPaymentTotal = 0;
            _dDueAmount = 0;
            txtCollectionAmount.Text = "0.00";
            txtDueAmount.Text = "0.00";

            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (Convert.ToInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Advance_Payment)
                    {
                        oItemRow.Cells[1].ReadOnly = true;
                        oItemRow.Cells[1].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[0].ReadOnly = true;
                    }
                    else
                    {
                        oItemRow.Cells[1].ReadOnly = false;
                        oItemRow.Cells[1].Style.BackColor = Color.Transparent;
                        oItemRow.Cells[0].ReadOnly = true;
                    }
                }
            }


            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (Convert.ToInt32(oItemRow.Cells[0].Value) == 1)
                    {
                        oItemRow.Cells[1].ReadOnly = false;
                        oItemRow.Cells[1].Style.BackColor = Color.Transparent;
                        oItemRow.Cells[2].ReadOnly = true;
                        oItemRow.Cells[2].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[3].ReadOnly = true;
                        oItemRow.Cells[3].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[4].ReadOnly = true;
                        oItemRow.Cells[4].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[5].ReadOnly = true;
                        oItemRow.Cells[5].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[6].ReadOnly = true;
                        oItemRow.Cells[6].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[7].ReadOnly = true;
                        oItemRow.Cells[7].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[8].ReadOnly = true;
                        oItemRow.Cells[8].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[9].ReadOnly = true;
                        oItemRow.Cells[9].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[10].ReadOnly = true;
                        oItemRow.Cells[10].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[0].ReadOnly = true;
                    }
                    //else
                    //{
                    //    oItemRow.Cells[1].ReadOnly = false;
                    //    oItemRow.Cells[1].Style.BackColor = Color.Transparent;
                    //    //oItemRow.Cells[2].ReadOnly = true;
                    //    //oItemRow.Cells[2].Style.BackColor = Color.Transparent;
                    //    //oItemRow.Cells[3].ReadOnly = true;
                    //    //oItemRow.Cells[3].Style.BackColor = Color.Transparent;
                    //    //oItemRow.Cells[4].ReadOnly = true;
                    //    //oItemRow.Cells[4].Style.BackColor = Color.Transparent;
                    //    //oItemRow.Cells[5].ReadOnly = true;
                    //    //oItemRow.Cells[5].Style.BackColor = Color.Transparent;
                    //    //oItemRow.Cells[6].ReadOnly = true;
                    //    //oItemRow.Cells[6].Style.BackColor = Color.Transparent;
                    //    //oItemRow.Cells[7].ReadOnly = true;
                    //    //oItemRow.Cells[7].Style.BackColor = Color.Transparent;
                    //    //oItemRow.Cells[8].ReadOnly = true;
                    //    //oItemRow.Cells[8].Style.BackColor = Color.Transparent;
                    //    //oItemRow.Cells[0].ReadOnly = true;
                    //}
                }
            }

            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[2].Value != null)
                    {
                        Bank oBank = new Bank();
                        int nBankID = int.Parse(oItemRow.Cells[2].Value.ToString());
                        oBank.BankID = nBankID;
                        DBController.Instance.OpenNewConnection();
                        oBank.Refresh();
                        if (oBank.IsEMI == (int)Dictionary.IsEMI.Yes)
                        {
                            oItemRow.Cells[7].ReadOnly = false;
                            oItemRow.Cells[7].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[8].ReadOnly = false;
                            oItemRow.Cells[8].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[9].ReadOnly = false;
                            oItemRow.Cells[9].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[10].ReadOnly = false;
                            oItemRow.Cells[10].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[2].ReadOnly = true;
                        }
                        else
                        {
                            oItemRow.Cells[7].ReadOnly = true;
                            oItemRow.Cells[7].Value = 0;
                            oItemRow.Cells[7].Style.BackColor = Color.LightGray;
                            oItemRow.Cells[8].ReadOnly = true;
                            oItemRow.Cells[8].Style.BackColor = Color.LightGray;
                            oItemRow.Cells[9].ReadOnly = false;
                            oItemRow.Cells[9].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[10].ReadOnly = false;
                            oItemRow.Cells[10].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[2].ReadOnly = true;
                        }
                    }

                }
            }


            oTELLib = new TELLib();
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[9].Value != null)
                    {
                        if (Convert.ToInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Advance_Payment)
                        {
                            ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();
                            oConsumerBalanceTran.ConsumerCode = Convert.ToString(oItemRow.Cells[9].Value);
                            DBController.Instance.OpenNewConnection();
                            double _balance = oConsumerBalanceTran.GetConsumerBalance();
                            if (ctlRetailConsumer1.SelectedCustomer != null)
                            {
                                if (oConsumerBalanceTran.ConsumerID == ctlRetailConsumer1.SelectedCustomer.ConsumerID)
                                {
                                    oItemRow.Cells[1].Value = _balance;
                                }
                                else
                                {
                                    MessageBox.Show("Please Select Valid Consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        else if (Convert.ToInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Approve_Credit)
                        {
                            CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();

                            DBController.Instance.OpenNewConnection();
                            oSystemInfo = new SystemInfo();
                            oSystemInfo.Refresh();
                            if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B || _nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                            {
                                if (ctlCustomer1.SelectedCustomer != null)
                                {
                                    if (sApprove_Credit_No != Convert.ToString(oItemRow.Cells[9].Value))
                                    {
                                        double _balance = oCustomerCreditApproval.GetCustomerCreditBalance(Convert.ToString(oItemRow.Cells[9].Value), ctlCustomer1.SelectedCustomer.CustomerID);
                                        if (oCustomerCreditApproval.CustomerID == ctlCustomer1.SelectedCustomer.CustomerID)
                                        {
                                            sApprove_Credit_No = Convert.ToString(oItemRow.Cells[9].Value);
                                            oItemRow.Cells[1].Value = _balance;

                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Select Valid Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        ////Exchange Offer MR
                        else if (Convert.ToInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Exchange_Offer_Money_Receipt)
                        {
                            ExchangeOfferMR oExchangeOfferMR = new ExchangeOfferMR();
                            oExchangeOfferMR.MoneyReceiptNo = Convert.ToString(oItemRow.Cells[9].Value);
                            DBController.Instance.OpenNewConnection();
                            oExchangeOfferMR.GetMRAmount();
                            double _Amount = 0;
                            _Amount = oExchangeOfferMR.Amount;

                            if (oExchangeOfferMR.MoneyReceiptID != 0)
                            {
                                oItemRow.Cells[1].Value = _Amount;
                                oItemRow.Cells[1].ReadOnly = true;
                                oItemRow.Cells[9].ReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show("Please Input Valid Money Receipt No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                            
                        

                    }
                }
            }
            _dPaymentTotal = 0;
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value != null)
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            try
                            {
                                txtCollectionAmount.Text = "0.00";
                                txtDueAmount.Text = "0.00";
                                double tmp = Convert.ToDouble(oItemRow.Cells[1].Value.ToString().Trim());
                                _dPaymentTotal = _dPaymentTotal + tmp;
                            }
                            catch
                            {
                                MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                    }
                }
            }
            Collection(_dPaymentTotal);
        }

        private void Collection(double _Amount)
        {
            TELLib oTELLib = new TELLib();


            txtCollectionAmount.Text = oTELLib.TakaFormat(_Amount);
            txtDueAmount.Text = oTELLib.TakaFormat((Convert.ToDouble(txtNetPay.Text) - Convert.ToDouble(txtCollectionAmount.Text)));

            if (Convert.ToDouble(txtDueAmount.Text) != 0)
                txtDueAmount.ForeColor = Color.Red;
            else txtDueAmount.ForeColor = Color.Green;
        }

        private void dgvPayment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            _dPaymentTotal = 0;
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value != null)
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            try
                            {
                                txtCollectionAmount.Text = "0.00";
                                txtDueAmount.Text = "0.00";
                                double tmp = Convert.ToDouble(oItemRow.Cells[1].Value.ToString().Trim());
                                _dPaymentTotal = _dPaymentTotal + tmp;
                            }
                            catch
                            {
                                MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                    }
                }
            }
            Collection(_dPaymentTotal);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PreviewInvoice();
            this.Cursor = Cursors.Default;
        }

        private void PreviewInvoice()
        {
            oTELLib = new TELLib();
            string sBarcode = "";
            bool _bGiftItemVisible = false;
            bool _bCreditCardVisible = false;
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            DSSalesInvoiceDetail oDSScratchCardProduct = new DSSalesInvoiceDetail();
            DSSalesInvoiceDetail oDSCreditCard = new DSSalesInvoiceDetail();
            /*
            
            int nInvoiceID = 0;

            
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = Convert.ToInt32(orptSalesInvoice.SalesPersonID);
            oEmployee.RefreshForPOS();
            */
            if (dgvLineItem.Rows.Count > 1)
            {
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {


                        DSSalesInvoiceDetail.SalesProductRow oSalesProductRow = oDSSalesInvoiceProduct.SalesProduct.NewSalesProductRow();

                        oSalesProductRow.ProductCode = oItemRow.Cells[0].Value.ToString();
                        oSalesProductRow.ProductName = oItemRow.Cells[2].Value.ToString();
                        oSalesProductRow.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                        oSalesProductRow.Qty = Convert.ToInt32(oItemRow.Cells[6].Value.ToString());

                        oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                        oDSSalesInvoiceProduct.AcceptChanges();

                        if (sBarcode == "")
                        {
                            sBarcode = oItemRow.Cells[7].Value.ToString();
                        }
                        else
                        {
                            sBarcode = sBarcode + "," + oItemRow.Cells[7].Value.ToString();
                        }
                    }
                }
            }
            if (dvgProduct.Rows.Count > 0)
            {
                int nCount = 0;
                foreach (DataGridViewRow oFreeProductRow in dvgProduct.Rows)
                {
                    if (oFreeProductRow.Index < dvgProduct.Rows.Count)
                    {
                        if (nCount == 0)
                        {
                            _bGiftItemVisible = true;
                            nCount++;
                        }
                        DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                        oFreeGiftProductRow.ProductCode = oFreeProductRow.Cells[1].Value.ToString();
                        oFreeGiftProductRow.ProductName = oFreeProductRow.Cells[2].Value.ToString();
                        oFreeGiftProductRow.Qty = Convert.ToInt32(oFreeProductRow.Cells[3].Value);
                        //oFreeGiftProductRow.Barcode = orptSalesInvoiceDetail.FreeProductBarcode;

                        oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                        oDSFreeGiftProduct.AcceptChanges();
                    }
                }
            }
            if (dgvScratchCardQty.Rows.Count > 1)
            {
                int nCount = 0;
                foreach (DataGridViewRow oScratchCardRow in dgvScratchCardQty.Rows)
                {
                    if (oScratchCardRow.Index < dgvScratchCardQty.Rows.Count - 1)
                    {
                        if (nCount == 0)
                        {
                            _bGiftItemVisible = true;
                            nCount++;
                        }
                        DSSalesInvoiceDetail.FreeGiftProductRow oScratchCardProdRow = oDSScratchCardProduct.FreeGiftProduct.NewFreeGiftProductRow();

                        oScratchCardProdRow.ProductCode = oScratchCardRow.Cells[0].Value.ToString();
                        oScratchCardProdRow.ProductName = oScratchCardRow.Cells[2].Value.ToString();
                        oScratchCardProdRow.Qty = Convert.ToInt32(oScratchCardRow.Cells[3].Value);
                        //oScratchCardProdRow.Barcode = orptSalesInvoiceDetail.FreeProductBarcode;

                        oDSScratchCardProduct.FreeGiftProduct.AddFreeGiftProductRow(oScratchCardProdRow);
                        oDSScratchCardProduct.AcceptChanges();
                    }
                }
            }
            if (dgvPayment.Rows.Count > 1)
            {
                int nPaymentModeID = 0;
                int nCount = 0;
                foreach (DataGridViewRow oCreditCardRow in dgvPayment.Rows)
                {
                    if (oCreditCardRow.Index < dgvPayment.Rows.Count - 1)
                    {
                        nPaymentModeID = Convert.ToInt32(oCreditCardRow.Cells[0].Value);
                        if (nPaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                        {
                            if (nCount == 0)
                            {
                                _bCreditCardVisible = true;
                                nCount++;
                            }

                            DSSalesInvoiceDetail.CreditCardInfoRow oCreditCardInfoRow = oDSCreditCard.CreditCardInfo.NewCreditCardInfoRow();

                            string sCardNo = oCreditCardRow.Cells[9].Value.ToString();

                            string subStr = sCardNo.Substring(sCardNo.Length - 4);
                            subStr = "************" + subStr;
                            oCreditCardInfoRow.BankName = oCreditCardRow.Cells[2].FormattedValue.ToString();
                            oCreditCardInfoRow.Amount = Convert.ToDouble(oCreditCardRow.Cells[1].Value);
                            oCreditCardInfoRow.CardType = oCreditCardRow.Cells[3].FormattedValue.ToString();
                            oCreditCardInfoRow.CardNo = subStr;
                            oCreditCardInfoRow.IsEMI = oCreditCardRow.Cells[7].FormattedValue.ToString();
                            oCreditCardInfoRow.InstallmentNo = Convert.ToInt32(oCreditCardRow.Cells[8].Value);
                            oCreditCardInfoRow.POSMachine = oCreditCardRow.Cells[4].FormattedValue.ToString();

                            oDSCreditCard.CreditCardInfo.AddCreditCardInfoRow(oCreditCardInfoRow);
                            oDSCreditCard.AcceptChanges();
                        }
                    }
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.Merge(oDSScratchCardProduct);
            oDSSalesInvoiceDetail.Merge(oDSCreditCard);
            oDSSalesInvoiceDetail.AcceptChanges();

            //oRetailConsumer = new RetailConsumer();
            //oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
            //oRetailConsumer.CustomerID = int.Parse(orptSalesInvoice.CustomerID.ToString());

            //oRetailConsumer.RefreshForPOS();

            //oRetailSalesInvoice = new RetailSalesInvoice();
            //oRetailSalesInvoice.InvoiceID = nInvoiceID;
            //oRetailSalesInvoice.RefreshInvoiceCharge();
            //oRetailSalesInvoice.RefreshPaymentMode();
            //oRetailSalesInvoice.RefreshSMSDiscoutn(orptSalesInvoice.InvoiceNo);



            rptRetailInvoiceDummy doc;
            doc = new rptRetailInvoiceDummy();
            doc.SetDataSource(oDSSalesInvoiceDetail);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("Address", oSystemInfo.WarehouseAddress + ", Outlet Phone No:" + oSystemInfo.WarehousePhoneNo);
            doc.SetParameterValue("Mobile", oSystemInfo.WarehouseCellNo + ", e-mail:" + oSystemInfo.WarehouseEmail);
            doc.SetParameterValue("HC", oSystemInfo.HCMobileNo + ", e-mail:" + oSystemInfo.HCEmail);

            doc.SetParameterValue("CustomerName", txtCustomerName.Text);
            doc.SetParameterValue("CustomerCode", "");
            doc.SetParameterValue("CustomerAddress", txtCustomerAddress.Text);
            doc.SetParameterValue("CustomerPhoneNo", "");
            doc.SetParameterValue("CustomerCellNo", txtCell.Text);

            if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", "");

            doc.SetParameterValue("EmployeeName", cmbEmpoyee.Text);
            doc.SetParameterValue("InvoiceTitle", "Dummy Invoice");
            doc.SetParameterValue("RefInvoice", "");

            doc.SetParameterValue("InvoiceNo", "xxx-yyyy-zzzz");
            doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
            doc.SetParameterValue("DeliveryW/H", "");

            double _dis = 0;
            if (rdoPercentage.Checked == true)
            {
                doc.SetParameterValue("IspercentDiscount?", true);
                _dis = Convert.ToDouble(txtParcentage.Text);
            }
            else
            {
                doc.SetParameterValue("IspercentDiscount?", false);
                _dis = Convert.ToDouble(txtFlatAmount.Text);
            }
            double _Percentage = 0;
            double _FlatAmount = 0;
            double _TotalDiscount = 0;
            double _TotalCharge = 0;

            _Percentage = ((Convert.ToDouble(txtTotal.Text)) * (Convert.ToDouble(txtParcentage.Text) / 100));
            _FlatAmount = Math.Round(Convert.ToDouble(txtFlatAmount.Text), 0, MidpointRounding.AwayFromZero);
            _TotalDiscount = Math.Round(Convert.ToDouble(txtTotalDisount.Text), 0, MidpointRounding.AwayFromZero) + _FlatAmount + Math.Round(_Percentage, 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDouble(txtSMSDiscount.Text), 0, MidpointRounding.AwayFromZero);

            doc.SetParameterValue("SPDiscount", oTELLib.TakaFormat(Convert.ToDouble(txtPromoDiscount.Text)));
            doc.SetParameterValue("SDiscount", oTELLib.TakaFormat(_dis));
            doc.SetParameterValue("Discount", oTELLib.TakaFormat(_TotalDiscount));
            doc.SetParameterValue("smsDiscount", oTELLib.TakaFormat(Convert.ToDouble(txtSMSDiscount.Text)));


            _TotalCharge = Math.Round(Convert.ToDouble(txtFreightCharge.Text), 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDouble(txtInstallationCharge.Text), 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDouble(txtOtherCharge.Text), 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDouble(txtMarkUp.Text), 0, MidpointRounding.AwayFromZero);

            doc.SetParameterValue("FCharge", oTELLib.TakaFormat(Convert.ToDouble(txtFreightCharge.Text)));
            doc.SetParameterValue("ICharge", oTELLib.TakaFormat(Convert.ToDouble(txtInstallationCharge.Text)));
            doc.SetParameterValue("OCharge", oTELLib.TakaFormat(Convert.ToDouble(txtOtherCharge.Text)));
            doc.SetParameterValue("MCharge", oTELLib.TakaFormat(Convert.ToDouble(txtMarkUp.Text)));
            doc.SetParameterValue("Charge", oTELLib.TakaFormat(_TotalCharge));

            doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(txtNetPay.Text)));
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(Convert.ToDouble(txtNetPay.Text)));

            double _TotalCash = 0;
            double _TotalCredit = 0;
            double _TotalAdvanceAdjust = 0;
            double _TotalOthersPayment = 0;
            double _TotalPayment = 0;

            foreach (DataGridViewRow oItemPaymentRow in dgvPayment.Rows)
            {
                int nPaymentModeID = 0;
                if (oItemPaymentRow.Index < dgvPayment.Rows.Count - 1)
                {
                    nPaymentModeID = Convert.ToInt32(oItemPaymentRow.Cells[0].Value);

                    if (nPaymentModeID == (int)Dictionary.PaymentMode.Cash)
                    {
                        _TotalCash = _TotalCash + Convert.ToDouble(oItemPaymentRow.Cells[1].Value);
                    }
                    else if (nPaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                    {
                        _TotalCredit = _TotalCredit + Convert.ToDouble(oItemPaymentRow.Cells[1].Value);
                    }
                    else if (nPaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
                    {
                        _TotalAdvanceAdjust = _TotalAdvanceAdjust + Convert.ToDouble(oItemPaymentRow.Cells[1].Value);
                    }
                    else
                    {
                        _TotalOthersPayment = _TotalOthersPayment + Convert.ToDouble(oItemPaymentRow.Cells[1].Value);
                    }
                }
            }
            _TotalPayment = _TotalCash + _TotalCredit + _TotalAdvanceAdjust + _TotalOthersPayment;
            doc.SetParameterValue("Cash", oTELLib.TakaFormat(_TotalCash));
            doc.SetParameterValue("Credit", oTELLib.TakaFormat(_TotalCredit));
            doc.SetParameterValue("AdvanceAdjust", oTELLib.TakaFormat(_TotalAdvanceAdjust));
            doc.SetParameterValue("OthersPayment", oTELLib.TakaFormat(_TotalOthersPayment));
            doc.SetParameterValue("Payment", oTELLib.TakaFormat(_TotalPayment));

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            doc.SetParameterValue("Barcode", sBarcode);

            //doc.SetParameterValue("Barcode", SL);
            doc.SetParameterValue("Remarks", txtRemarks.Text);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            doc.SetParameterValue("IsVisible", _bGiftItemVisible);
            doc.SetParameterValue("IsVisibleCreditCard", _bCreditCardVisible);

            doc.SetParameterValue("IsCLP", false);
            doc.SetParameterValue("PBalance", 0);
            doc.SetParameterValue("RBalance", 0);
            doc.SetParameterValue("CBalance", 0);


            frmPrintPreviewWithoutPrintExport frmView;
            frmView = new frmPrintPreviewWithoutPrintExport();
            frmView.ShowDialog(doc);
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            oSalesLead = new SalesLead();
            frmSalesLeadConsumerSarch oObj = new frmSalesLeadConsumerSarch(_nUIControl);
            oObj.ShowDialog(oSalesLead);
            if (oSalesLead.LeadNo != null)
            {
                txtLeadNo.Text = oSalesLead.LeadNo.ToString();
                txtLeadCustName.Text = oSalesLead.Name.ToString();
            }
        }

        private void txtLeadNo_TextChanged(object sender, EventArgs e)
        {
            SalesLead _oSalesLead = new SalesLead();
            _oSalesLead.LeadNo = txtLeadNo.Text;
            txtLeadNo.ForeColor = System.Drawing.Color.Red;
            txtLeadCustName.Text = "";
            //if (txtLeadNo.Text.Length == 14)
            //{
                DBController.Instance.OpenNewConnection();
                _oSalesLead.RefreshByLeadNo(_nUIControl);
                nLeadID = 0;
                nLeadID = _oSalesLead.LeadID;
                if (_oSalesLead.Name == null)
                {
                    _oSalesLead = null;
                    AppLogger.LogFatal("There is no data.");
                    txtCustomerName.Text = "";
                    txtCustomerAddress.Text = "";
                    txtEmail.Text = "";
                    txtCell.Text = "";
                    txtLeadCustName.Text = "";
                    return;
                }
                else
                {
                    txtCustomerName.Text = _oSalesLead.Name.ToString();
                    txtCustomerAddress.Text = _oSalesLead.Address.ToString();
                    txtEmail.Text = _oSalesLead.Email.ToString();
                    txtCell.Text = _oSalesLead.ContactNo.ToString();
                    txtLeadCustName.Text = _oSalesLead.Name.ToString();

                    txtLeadNo.SelectionStart = 0;
                    txtLeadNo.SelectionLength = txtLeadNo.Text.Length;
                    txtLeadNo.ForeColor = System.Drawing.Color.Empty;
                }
            //}
            //else
            //{
            //    txtCustomerName.Text = "";
            //    txtCustomerAddress.Text = "";
            //    txtEmail.Text = "";
            //    txtCell.Text = "";
            //    txtLeadCustName.Text = "";
            //}
        }

        private void rdoLeadCust_CheckedChanged(object sender, EventArgs e)
        {
            ctlRetailConsumer1.Visible = false;
            txtLeadNo.Visible = true;
            btnPicker.Visible = true;
            txtLeadCustName.Visible = true;


            ctlRetailConsumer1.txtCode.Text = "";
            txtLeadNo.Text = "";
            txtCustomerName.Text = "";
            cmbConType.Text = "";
            txtCustomerAddress.Text = "";
            txtEmail.Text = "";
            txtCell.Text = "";
            txtEmployeeNo.Text = "";
            txtNationalID.Text = "";
            txtTelePhone.Text = "";
            txtVatRegNo.Text = "";

            txtCustomerName.Enabled = true;
            cmbConType.Enabled = true;
            txtCustomerAddress.Enabled = true;
            txtEmail.Enabled = true;
            txtCell.Enabled = true;
            txtEmployeeNo.Enabled = true;
            txtNationalID.Enabled = true;
            txtTelePhone.Enabled = true;
            txtVatRegNo.Enabled = true;
            dtDateofBirth.Enabled = true;
        }

        private void rdoExistingConsumer_CheckedChanged(object sender, EventArgs e)
        {
            ctlRetailConsumer1.Enabled = true;
            ctlRetailConsumer1.Visible = true;
            txtLeadNo.Visible = false;
            btnPicker.Visible = false;
            txtLeadCustName.Visible = false;


            ctlRetailConsumer1.txtCode.Text = "";
            txtLeadNo.Text = "";
            txtCustomerName.Text = "";
            cmbConType.Text = "";
            txtCustomerAddress.Text = "";
            txtEmail.Text = "";
            txtCell.Text = "";
            txtEmployeeNo.Text = "";
            txtNationalID.Text = "";
            txtTelePhone.Text = "";
            txtVatRegNo.Text = "";


            txtCustomerName.Enabled = false;
            cmbConType.Enabled = false;
            txtCustomerAddress.Enabled = false;
            txtEmail.Enabled = false;
            txtCell.Enabled = false;
            txtEmployeeNo.Enabled = false;
            txtNationalID.Enabled = false;
            txtTelePhone.Enabled = false;
            txtVatRegNo.Enabled = false;
            dtDateofBirth.Enabled = false;
        }

        private void rdoNewConsumer_CheckedChanged(object sender, EventArgs e)
        {
            ctlRetailConsumer1.Enabled = false;
            label9.Enabled = false;
            txtLeadNo.Visible = false;
            btnPicker.Visible = false;
            txtLeadCustName.Visible = false;

            ctlRetailConsumer1.txtCode.Text = "";
            txtLeadNo.Text = "";
            txtCustomerName.Text = "";
            cmbConType.Text = "";
            txtCustomerAddress.Text = "";
            txtEmail.Text = "";
            txtCell.Text = "";
            txtEmployeeNo.Text = "";
            txtNationalID.Text = "";
            txtTelePhone.Text = "";
            txtVatRegNo.Text = "";

            txtCustomerName.Enabled = true;
            cmbConType.Enabled = true;
            txtCustomerAddress.Enabled = true;
            txtEmail.Enabled = true;
            txtCell.Enabled = true;
            txtEmployeeNo.Enabled = true;
            txtNationalID.Enabled = true;
            txtTelePhone.Enabled = true;
            txtVatRegNo.Enabled = true;
            dtDateofBirth.Enabled = true;
        }

        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.txtDescription.Text != "")
            {
                Customer oCustomer = new Customer();
                oCustomer.RefreshByID(ctlCustomer1.SelectedCustomer.CustomerID);

                if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
                {
                    TELLib oTELLib = new TELLib();
                    PaymentMode oGetBalance = new PaymentMode();
                    oGetBalance.GetCustomerBalance(DateTime.Now.Date, ctlCustomer1.SelectedCustomer.CustomerID);
                    lblCustomerBalanceAmt.Text = oTELLib.TakaFormat(oGetBalance.CurrentBalance);
                    lblBGAmt.Text = oTELLib.TakaFormat(oGetBalance.BankGuaranty);
                }
                if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B)
                {
                    if (Utility.CompanyInfo == "TEL")
                    {
                        if (oCustomer.CustTypeID == 249 || oCustomer.CustTypeID == 245)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please select valid B2B customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return false;
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                        }
                    }
                    else if (Utility.CompanyInfo == "TML")
                    {
                        if (oCustomer.CustTypeID == 202 || oCustomer.CustTypeID == 217)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please select valid B2B customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return false;
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                        }
                    }
                }
                if (_nUIControl == (int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C)
                {
                    if (Utility.CompanyInfo == "TEL")
                    {
                        if (oCustomer.CustTypeID != 245)
                        {
                            MessageBox.Show("Please select valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return false;
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                        }
                    }
                    else if (Utility.CompanyInfo == "TML")
                    {
                        if (oCustomer.CustTypeID != 217)
                        {
                            MessageBox.Show("Please select valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return false;
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                        }
                    }
                }
            }
        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            //frmSalesInvoiceDiscount oFrmSalesInvoiceDiscount = new frmSalesInvoiceDiscount();
            //oFrmSalesInvoiceDiscount.ShowDialog(oDsSalesInvoiceDiscount);
            //oDsSalesInvoiceDiscount = new DSSalesInvoiceDiscount();
            //oDsSalesInvoiceDiscount = oFrmSalesInvoiceDiscount._oDSSalesInvoiceDiscount;
            //oTELLib = new TELLib();
            //txtTotalDiscount.Text = oTELLib.TakaFormat(oFrmSalesInvoiceDiscount._TotalDiscount);
        }
    }
}