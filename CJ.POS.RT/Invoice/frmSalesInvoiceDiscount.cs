using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.Accounts;

namespace CJ.POS.RT.Invoice
{
    public partial class frmSalesInvoiceDiscount : Form
    {
        private int nArrayLen = 0;
        private string[] sProductBarcodeArr = null;
        int _OfferType = 0;
        public DSSalesInvoiceDiscount _oDSSalesInvoiceDiscount;
        public double _TotalDiscount = 0;
        public double _TotalCharge = 0;
        public bool _IsTrue = false;
        private int _nProductID = 0;
        string _sProductName = "";
        int _nUIControl = 0;
        double _TotalRsAmount = 0;
        int nCustomerID = 0;
        string sConsumerCode = "";
        public bool _IsApplicableB2BDiscountDiscount;
        Product _oProduct;
        bool _bIsApplicableB2BDiscount = false;

        bool _IsActiveSCDiscount = false;
        private bool _bPromoExchangeOffer = false;

        public frmSalesInvoiceDiscount(int nProductID, string sProductName, int _UIControl, int _nCustomerID, string _sConsumerCode, bool _IsApplicableB2BDiscountPayment, double _nTotalRsAmount,bool bIsApplicableB2BDiscount,bool nIsActiveSCDiscount,int nOfferType, bool bPromoExchangeOffer)
        {
            InitializeComponent();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _bIsApplicableB2BDiscount = bIsApplicableB2BDiscount;
            _TotalRsAmount = _nTotalRsAmount;
            _nProductID = nProductID;
            _sProductName = sProductName;
            _nUIControl = _UIControl;
            nCustomerID = _nCustomerID;
            sConsumerCode = _sConsumerCode;
            _IsApplicableB2BDiscountDiscount = _IsApplicableB2BDiscountPayment;
            lblProductName.Text = sProductName;
            _OfferType = nOfferType;
            _bPromoExchangeOffer = bPromoExchangeOffer;
            _IsActiveSCDiscount = nIsActiveSCDiscount;
            if (nIsActiveSCDiscount)
            {
                if (nOfferType == (int)Dictionary.OfferTypeSC.Both)
                {
                    dgvScratchCardQty.Enabled = true;
                }
                else if (nOfferType == (int)Dictionary.OfferTypeSC.FreeProduct)
                {
                    dgvScratchCardQty.Enabled = true;
                }
                else
                {
                    dgvScratchCardQty.Enabled = false;
                }

            }
            else
            {
                dgvScratchCardQty.Enabled = false;
            }
            
        }

        public void ShowDialog(DSSalesInvoiceDiscount oDSSalesInvoiceDiscount)
        {
            TELLib oLib = new TELLib();
            if (oDSSalesInvoiceDiscount.SalesInvoiceDiscount.Count != 0)
            {
                foreach (DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow in oDSSalesInvoiceDiscount.SalesInvoiceDiscount)
                {
                    if (oSalesInvoiceDiscountRow.Type == (int)Dictionary.DiscountChargeType.Discount)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvSalesInvoiceDiscount);
                        oRow.Cells[0].Value = oSalesInvoiceDiscountRow.DiscountTypeID;
                        oRow.Cells[1].Value = oSalesInvoiceDiscountRow.DiscountTypeName.ToString();
                        bool _isTrue = false;
                        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DiscountChargeItem)))
                        {
                            if (GetEnum == oSalesInvoiceDiscountRow.DiscountTypeID)
                            {
                                _isTrue = true;
                            }
                        }
                        if (_isTrue == true)
                        {
                            oRow.Cells[2].ReadOnly = true;
                            oRow.Cells[2].Style.BackColor = Color.LightGray;
                        }
                        if (_nUIControl == (int)Dictionary.SalesType.B2B)
                        {
                            if (oSalesInvoiceDiscountRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.B2B_Discount)
                            {
                                if (_bIsApplicableB2BDiscount)
                                {
                                    oRow.Cells[2].Value = oLib.TakaFormat(0.00);
                                }
                                else
                                {
                                    oRow.Cells[2].Value = oLib.TakaFormat(oSalesInvoiceDiscountRow.Amount);
                                }
                            }
                            else
                            {
                                oRow.Cells[2].Value = oLib.TakaFormat(oSalesInvoiceDiscountRow.Amount);
                            }
                        }
                        else
                        {
                            oRow.Cells[2].Value = oLib.TakaFormat(oSalesInvoiceDiscountRow.Amount);
                        }
                        oRow.Cells[3].Value = oSalesInvoiceDiscountRow.InstrumentNo.ToString();
                        oRow.Cells[4].Value = oSalesInvoiceDiscountRow.Description.ToString();
                        oRow.Cells[5].Value = _nProductID;
                        oRow.Cells[6].Value = (int)Dictionary.DiscountChargeType.Discount;

                        oRow.Cells[7].Value = -1;
                        oRow.Cells[8].Value = -1;
                        oRow.Cells[9].Value = "";
                        oRow.Cells[10].Value = -1;

                        dgvSalesInvoiceDiscount.Rows.Add(oRow);
                    }
                    //Scretch Card Product
                    else if (oSalesInvoiceDiscountRow.Type == (int)Dictionary.DiscountChargeType.Free_Product)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvScratchCardQty);
                        Product oProduct = new Product();
                        oProduct.ProductID = oSalesInvoiceDiscountRow.FreeProductID;
                        oProduct.RefreshByID();

                        oRow.Cells[0].Value = oProduct.ProductCode.ToString();
                        oRow.Cells[2].Value = oProduct.ProductName.ToString();
                        oRow.Cells[3].Value = oSalesInvoiceDiscountRow.FreeQty.ToString();
                        oRow.Cells[4].Value = oSalesInvoiceDiscountRow.ProductSerialNo.ToString();
                        oRow.Cells[6].Value = oSalesInvoiceDiscountRow.InstrumentNo.ToString();
                        oRow.Cells[7].Value = oSalesInvoiceDiscountRow.Description.ToString();
                        oRow.Cells[8].Value = oSalesInvoiceDiscountRow.FreeProductID.ToString();
                        oRow.Cells[9].Value = oProduct.IsBarcodeItem.ToString();
                        dgvScratchCardQty.Rows.Add(oRow);
                    }



                }
            }
            else
            {
                DiscountReasons oReasons = new DiscountReasons();
                oReasons.GetSalesInvoiceDiscountTypeWithSCImact((int)Dictionary.DiscountChargeType.Discount, _nUIControl, _IsActiveSCDiscount, _OfferType, _bPromoExchangeOffer);
                foreach (DiscountReason oDiscountReason in oReasons)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvSalesInvoiceDiscount);
                    oRow.Cells[0].Value = oDiscountReason.DiscountTypeID;
                    oRow.Cells[1].Value = oDiscountReason.DiscountTypeName.ToString();
                    oRow.Cells[2].Value = oLib.TakaFormat(0.00);
                    bool _isTrue = false;
                    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DiscountChargeItem)))
                    {
                        if (GetEnum == oDiscountReason.DiscountTypeID)
                        {
                            _isTrue = true;
                        }
                    }
                    if (_isTrue == true)
                    {
                        oRow.Cells[2].ReadOnly = true;
                        oRow.Cells[2].Style.BackColor = Color.LightGray;
                    }
                    oRow.Cells[3].Value = "";
                    oRow.Cells[4].Value = "";
                    oRow.Cells[5].Value = _nProductID;
                    oRow.Cells[6].Value = (int)Dictionary.DiscountChargeType.Discount;
                    oRow.Cells[7].Value = -1;
                    oRow.Cells[8].Value = -1;
                    oRow.Cells[9].Value = "";
                    oRow.Cells[10].Value = -1;
                    dgvSalesInvoiceDiscount.Rows.Add(oRow);
                }
            }

            //Charges
            if (oDSSalesInvoiceDiscount.SalesInvoiceCharge.Count != 0)
            {
                foreach (DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow in oDSSalesInvoiceDiscount.SalesInvoiceCharge)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvChargeType);

                    oRow.Cells[0].Value = oSalesInvoiceChargeRow.DiscountTypeID;
                    oRow.Cells[1].Value = oSalesInvoiceChargeRow.DiscountTypeName.ToString();
                    oRow.Cells[2].Value = oLib.TakaFormat(oSalesInvoiceChargeRow.Amount);
                    bool _isTrue = false;
                    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DiscountChargeItem)))
                    {
                        if (GetEnum == oSalesInvoiceChargeRow.DiscountTypeID)
                        {
                            _isTrue = true;
                        }
                    }
                    if (_isTrue == true)
                    {
                        oRow.Cells[2].ReadOnly = true;
                        oRow.Cells[2].Style.BackColor = Color.LightGray;
                    }
                    oRow.Cells[3].Value = oSalesInvoiceChargeRow.InstrumentNo.ToString();
                    oRow.Cells[4].Value = oSalesInvoiceChargeRow.Description.ToString();
                    oRow.Cells[5].Value = _nProductID;
                    oRow.Cells[6].Value = (int)Dictionary.DiscountChargeType.Charge;
                    dgvChargeType.Rows.Add(oRow);
                }
            }
            else
            {
                DiscountReasons oReasons = new DiscountReasons();
                oReasons.GetSalesInvoiceDiscountType((int)Dictionary.DiscountChargeType.Charge, _nUIControl);
                foreach (DiscountReason oDiscountReason in oReasons)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvChargeType);
                    oRow.Cells[0].Value = oDiscountReason.DiscountTypeID;
                    oRow.Cells[1].Value = oDiscountReason.DiscountTypeName.ToString();
                    oRow.Cells[2].Value = oLib.TakaFormat(0.00);
                    bool _isTrue = false;
                    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DiscountChargeItem)))
                    {
                        if (GetEnum == oDiscountReason.DiscountTypeID)
                        {
                            _isTrue = true;
                        }
                    }
                    if (_isTrue == true)
                    {
                        oRow.Cells[2].ReadOnly = true;
                        oRow.Cells[2].Style.BackColor = Color.LightGray;
                    }
                    oRow.Cells[3].Value = "";
                    oRow.Cells[4].Value = "";
                    oRow.Cells[5].Value = _nProductID;
                    oRow.Cells[6].Value = (int)Dictionary.DiscountChargeType.Charge;
                    dgvChargeType.Rows.Add(oRow);
                }
            }
            GetTotalAmount();
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ValidateUIInput()
        {
            #region Sales Invoice Discount Validation
            //Discount
            foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
            {
                double nAmount = 0;
                string sInstrumentNo = "";
                if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                {
                    try
                    {
                        nAmount = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                    }
                    catch
                    {
                        nAmount = 0;
                    }

                    try
                    {
                        sInstrumentNo = oItemRow.Cells[3].Value.ToString();
                    }
                    catch
                    {
                        sInstrumentNo = "";
                    }

                    if (nAmount > 0)
                    {
                        SalesInvoiceDiscountType oSalesInvoiceDiscountType = new SalesInvoiceDiscountType();
                        oSalesInvoiceDiscountType.DiscountTypeID= int.Parse(oItemRow.Cells[0].Value.ToString());
                        oSalesInvoiceDiscountType.Refresh();  

                        if(oSalesInvoiceDiscountType.IsMandatoryInstrumentNo== (int)Dictionary.YesOrNoStatus.YES)
                        {
                            if(sInstrumentNo=="")
                            {
                                MessageBox.Show("Please Input valid Instrument Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Scratch Card Product Validation
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


            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (ValidateUIInput())
            {
                DSSalesInvoiceDiscount oDSSalesInvoiceDiscount = new DSSalesInvoiceDiscount();
                //Discount
                foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                {
                    if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                    {
                        DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow =
                            oDSSalesInvoiceDiscount.SalesInvoiceDiscount.NewSalesInvoiceDiscountRow();

                        oSalesInvoiceDiscountRow.DiscountTypeID = int.Parse(oItemRow.Cells[0].Value.ToString());
                        oSalesInvoiceDiscountRow.DiscountTypeName = oItemRow.Cells[1].Value.ToString();
                        try
                        {
                            oSalesInvoiceDiscountRow.Amount = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        }
                        catch
                        {
                            oSalesInvoiceDiscountRow.Amount = 0;
                        }
                        try
                        {
                            oSalesInvoiceDiscountRow.InstrumentNo = oItemRow.Cells[3].Value.ToString();
                        }
                        catch
                        {
                            oSalesInvoiceDiscountRow.InstrumentNo = "";
                        }
                        
                        try
                        {
                            oSalesInvoiceDiscountRow.Description = oItemRow.Cells[4].Value.ToString();
                        }
                        catch
                        {
                            oSalesInvoiceDiscountRow.Description = "";
                        }
                        oSalesInvoiceDiscountRow.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                        oSalesInvoiceDiscountRow.Type = int.Parse(oItemRow.Cells[6].Value.ToString());

                        oSalesInvoiceDiscountRow.FreeProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                        oSalesInvoiceDiscountRow.FreeQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                        oSalesInvoiceDiscountRow.ProductSerialNo = oItemRow.Cells[9].Value.ToString();
                        oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct = int.Parse(oItemRow.Cells[10].Value.ToString());

                        oDSSalesInvoiceDiscount.SalesInvoiceDiscount.AddSalesInvoiceDiscountRow(oSalesInvoiceDiscountRow);
                        oDSSalesInvoiceDiscount.AcceptChanges();

                    }
                }
                //Scratch Card Product
                if (dgvScratchCardQty.Rows.Count > 1)
                {
                    foreach (DataGridViewRow oItemRow in dgvScratchCardQty.Rows)
                    {
                        if (oItemRow.Index < dgvScratchCardQty.Rows.Count - 1)
                        {
                            DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow =
                            oDSSalesInvoiceDiscount.SalesInvoiceDiscount.NewSalesInvoiceDiscountRow();

                            oSalesInvoiceDiscountRow.DiscountTypeID = -1;
                            oSalesInvoiceDiscountRow.DiscountTypeName = "";
                            oSalesInvoiceDiscountRow.Amount = 0;
                            try
                            {
                                oSalesInvoiceDiscountRow.InstrumentNo = oItemRow.Cells[6].Value.ToString().Trim();
                            }
                            catch
                            {
                                oSalesInvoiceDiscountRow.InstrumentNo = "";
                            }
                            try
                            {
                                oSalesInvoiceDiscountRow.Description = oItemRow.Cells[7].Value.ToString().Trim();
                            }
                            catch
                            {
                                oSalesInvoiceDiscountRow.Description = "";
                            }
                            oSalesInvoiceDiscountRow.ProductID = _nProductID;
                            oSalesInvoiceDiscountRow.Type = (int)Dictionary.DiscountChargeType.Free_Product;
                            oSalesInvoiceDiscountRow.FreeProductID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString());
                            oSalesInvoiceDiscountRow.FreeQty = Convert.ToInt32(oItemRow.Cells[3].Value.ToString());
                            try
                            {
                                oSalesInvoiceDiscountRow.ProductSerialNo = oItemRow.Cells[4].Value.ToString().Trim();
                            }
                            catch
                            {
                                oSalesInvoiceDiscountRow.ProductSerialNo = "";
                            }
                            oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct = Convert.ToInt32(oItemRow.Cells[9].Value.ToString());

                            oDSSalesInvoiceDiscount.SalesInvoiceDiscount.AddSalesInvoiceDiscountRow(oSalesInvoiceDiscountRow);
                            oDSSalesInvoiceDiscount.AcceptChanges();

                        }
                    }
                }

                //Charges
                foreach (DataGridViewRow oItemRow in dgvChargeType.Rows)
                {
                    if (oItemRow.Index < dgvChargeType.Rows.Count)
                    {
                        DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow =
                            oDSSalesInvoiceDiscount.SalesInvoiceCharge.NewSalesInvoiceChargeRow();

                        oSalesInvoiceChargeRow.DiscountTypeID = int.Parse(oItemRow.Cells[0].Value.ToString());
                        oSalesInvoiceChargeRow.DiscountTypeName = oItemRow.Cells[1].Value.ToString();
                        try
                        {
                            oSalesInvoiceChargeRow.Amount = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        }
                        catch
                        {
                            oSalesInvoiceChargeRow.Amount = 0;
                        }
                        try
                        {
                            oSalesInvoiceChargeRow.InstrumentNo = oItemRow.Cells[3].Value.ToString();
                        }
                        catch
                        {
                            oSalesInvoiceChargeRow.InstrumentNo = "";
                        }
                        try
                        {
                            oSalesInvoiceChargeRow.Description = oItemRow.Cells[4].Value.ToString();
                        }
                        catch
                        {
                            oSalesInvoiceChargeRow.Description = "";
                        }
                        oSalesInvoiceChargeRow.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                        oSalesInvoiceChargeRow.Type = int.Parse(oItemRow.Cells[6].Value.ToString());
                        oDSSalesInvoiceDiscount.SalesInvoiceCharge.AddSalesInvoiceChargeRow(oSalesInvoiceChargeRow);
                        oDSSalesInvoiceDiscount.AcceptChanges();

                    }
                }

                _oDSSalesInvoiceDiscount = new DSSalesInvoiceDiscount();
                _oDSSalesInvoiceDiscount.Merge(oDSSalesInvoiceDiscount);
                _oDSSalesInvoiceDiscount.AcceptChanges();
                _TotalDiscount = Convert.ToDouble(txtTotalAmount.Text);
                _TotalCharge = Convert.ToDouble(txtTotalCharge.Text);
                _IsTrue = true;
                this.Close();
            }
        }

        public void GetTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            txtTotalCharge.Text = "0.00";
            TELLib oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvSalesInvoiceDiscount.Rows)
            {
                if (oRow.Cells[2].Value != null)
                {
                    txtTotalAmount.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString())));
                }
            }
            foreach (DataGridViewRow oRow in dgvChargeType.Rows)
            {
                if (oRow.Cells[2].Value != null)
                {
                    txtTotalCharge.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtTotalCharge.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString())));
                }
            }

        }

        public void GetSpecialDiscount()
        {
            foreach (DataGridViewRow oRow in dgvSalesInvoiceDiscount.Rows)
            {
                if (oRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                {
                    TELLib oTELLib = new TELLib();
                    if (Convert.ToInt32(oRow.Cells[0].Value) == (int)Dictionary.DiscountChargeItem.Special_Discount)
                    {
                        ConsumerPromotionEngine oSpecialDiscount = new ConsumerPromotionEngine();
                        if (oRow.Cells[3].Value != null)
                        {
                            oRow.Cells[2].Value = oTELLib.TakaFormat(oSpecialDiscount.GetSpecialDiscountRT(Utility.WarehouseID, nCustomerID, sConsumerCode, oRow.Cells[3].Value.ToString(), _nUIControl));
                            if (_nUIControl == (int)Dictionary.SalesType.B2B)
                            {
                                if (Convert.ToDouble(oRow.Cells[2].Value) > 0)
                                {
                                    ConsumerPromotionEngine oIsGetB2bDiscount = new ConsumerPromotionEngine();
                                    _IsApplicableB2BDiscountDiscount = oIsGetB2bDiscount.GetIsGetB2BDiscount(nCustomerID, oRow.Cells[3].Value.ToString());
                                }
                                else
                                {
                                    _IsApplicableB2BDiscountDiscount = true;
                                }
                            }
                        }
                        else
                        {
                            oRow.Cells[2].Value = oTELLib.TakaFormat(0.00);
                            _IsApplicableB2BDiscountDiscount = true;
                        }
                    }
                }
            }
            IsApppliacbleB2BDiscount();
        }

        public void IsApppliacbleB2BDiscount()
        {
            if (_nUIControl == (int)Dictionary.SalesType.B2B)
            {
                foreach (DataGridViewRow oRow in dgvSalesInvoiceDiscount.Rows)
                {
                    if (oRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                    {
                        TELLib oTELLib = new TELLib();
                        if (Convert.ToInt32(oRow.Cells[0].Value) == (int)Dictionary.DiscountChargeItem.B2B_Discount)
                        {
                            if (_IsApplicableB2BDiscountDiscount == false)
                            {
                                oRow.Cells[2].Value = oTELLib.TakaFormat(0.00);
                            }
                            else
                            {
                                ConsumerPromotionEngine oB2BDiscount = new ConsumerPromotionEngine();
                                oRow.Cells[2].Value = oTELLib.TakaFormat(oB2BDiscount.GetB2BDiscount(nCustomerID, _TotalRsAmount, oTELLib.ServerDateTime().Date));

                            }

                        }
                    }
                }
            }
        }
        
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (nColumnIndex == 2)
            {
                GetTotalAmount();
            }
            else if (nColumnIndex == 3)
            {
                GetSpecialDiscount();
            }
        }

        private void dgvSalesInvoiceDiscount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void dgvChargeType_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void frmSalesInvoiceDiscount_Load(object sender, EventArgs e)
        {

        }

        private void dgvScratchCardQty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm.sProductName != null)
                {
                    if (oForm._IsActive == (int)Dictionary.IsActive.InActive)
                    {
                        MessageBox.Show("Please select active product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

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
                frmAvailableBarcode ofrmAvailableBarcode = new frmAvailableBarcode(int.Parse(dgvScratchCardQty.Rows[e.RowIndex].Cells[8].Value.ToString()), Utility.WarehouseID, "", 0);
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
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();
                    if (oProduct.Flag != true)
                    {
                        if (oProduct.IsActiveProduct == (int)Dictionary.IsActive.InActive)
                        {
                            MessageBox.Show("Please select active product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvScratchCardQty.Rows[nRowIndex].Cells[nColumnIndex].Value = "";
                            dgvScratchCardQty.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                    }

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
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvScratchCardQty.Rows)
            {
                if (oItemRow.Index < dgvScratchCardQty.Rows.Count - 1)
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

        private void dgvChargeType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvSalesInvoiceDiscount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
