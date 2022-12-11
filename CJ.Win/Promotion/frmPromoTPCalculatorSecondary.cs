using CJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.Promotion;

namespace CJ.Win.Promotion
{
    public partial class frmPromoTPCalculatorSecondary : Form
    {
        CJ.Class.POS.DSSalesInvoice oInvoiceDiscountChargeMap;
        SalesPromotionTypes _oSalesPromotionTypes;
        int _nInvoiceCustomerTypeID = 0;
        int _nSalesType = 0;
        bool _IsApplyPromotion = false;
        private DSConsumerPromo _oDSInvoiceLineItem;
        private DSConsumerPromo _oDSInvoiceLineItemForPromo;
        private DSConsumerPromo _oDSEligiblePromo;
        private DSConsumerPromo _oDSPromoForProduct;
        private DSConsumerPromo _oDSPromoSlab;
        private DSConsumerPromo _oDSPromoSlabRatio;
        private DSConsumerPromo _oDSApplicablePromo;
        private DSConsumerPromo _oDSApplicablePromo_TP;
        private ConsumerPromotionEngines oEligiblePromos;
        ConsumerPromotionEngines _oConsumerPromotionEngines;

        private DSConsumerPromo _oDSEligiblePromoTP;
        private DSConsumerPromo _oDSEligiblePromoCPSimple;

        private DSConsumerPromo _oDSPromoTPForProduct;
        private DSConsumerPromo _oDSPromoTPSlab;
        private DSConsumerPromo _oDSPromoTPSlabRatio;





        string sDeliveryAddress = "";
        SalesOrder _oSalesOrder;
        Customer _oCustomer;
        CustomerDetail _oCustomerDetail;
        Employees _oEmployees;
        Warehouses _oWarehouses = new Warehouses();
        SalesPromotions _oSalesPromotions;
        ProvisionParam oProvisionParam;
        ProductDetail _oProductDetail;
        Users oUsers;
        WUIUtility _oWUIUtility;
        TELLib oLib;
        SPromotions oResultSPromotions;
        SPromotions oSPromotions;
        SPromotion oResultSPromotion;
        CustomerCreditLimit oCustomerCreditLimit;

        int _nRowIndex = 0;
        double _nPriceOption;
        bool IsUpdate = false;
        bool bFlag = true;
        bool IsAlterMOQ = false;
        string _sFeildName;
        int _nUIControl = 0;
        int nOrderID = 0;
        int sOrderNo = 0;
        object dOrderDate;
        int nCustTypeID = 0;

        public frmPromoTPCalculatorSecondary()
        {
            InitializeComponent();
        }
        private void SumNetPayable()
        {
            double _GrossAmount = 0;
            double _TotalDiscount = 0;
            double _DP = 0;
            double _TP = 0;
            double _RpC = 0;
            double _ConsumerPromotion = 0;
            double _TradePromotion = 0;
            double _CPS = 0;


            double _nGrossAmount = 0;
            double _nTotalDiscount = 0;
            double _nPayable = 0;
            double _nAdditionalDiscount = 0;
            double _TotalProvisition = 0;
            try
            {
                _nAdditionalDiscount = Convert.ToDouble(txtAdditionalDiscount.Text);
            }
            catch
            {
                _nAdditionalDiscount = 0;
            }

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {

                    try
                    {
                        _GrossAmount = Convert.ToDouble(oItemRow.Cells[10].Value);
                    }
                    catch
                    {
                        _GrossAmount = 0;
                    }
                    _nGrossAmount = _nGrossAmount + _GrossAmount;


                    try
                    {
                        _ConsumerPromotion = Convert.ToDouble(oItemRow.Cells[25].Value);
                    }
                    catch
                    {
                        _ConsumerPromotion = 0;
                    }
                    try
                    {
                        _TradePromotion = Convert.ToDouble(oItemRow.Cells[26].Value);
                    }
                    catch
                    {
                        _TradePromotion = 0;
                    }
                    try
                    {
                        _CPS = Convert.ToDouble(oItemRow.Cells[27].Value);
                    }
                    catch
                    {
                        _CPS = 0;
                    }

                    double _TotoalPromotionalAmount = _ConsumerPromotion + _TradePromotion + _CPS;
                    double _NetUnitPrice = 0;
                    int _OrderQty = 0;

                    if (_nUIControl == 1)
                    {
                        _OrderQty = Convert.ToInt32(oItemRow.Cells[8].Value);
                    }
                    else
                    {
                        _OrderQty = Convert.ToInt32(oItemRow.Cells[9].Value);
                    }


                    try
                    {
                        _NetUnitPrice = (_GrossAmount - _TotoalPromotionalAmount) / _OrderQty;
                    }
                    catch
                    {
                        _NetUnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value);
                    }

                    ProvisionParam oProvisionParam = new ProvisionParam();
                    oProvisionParam.GetProvisionParam(Convert.ToInt32(oItemRow.Cells[16].Value), ctlCustomer1.SelectedCustomer.CustTypeID);
                    double SC = 0;
                    double TP = 0;
                    double PW = 0;
                    try
                    {
                        SC = (_NetUnitPrice * oProvisionParam.SC * _OrderQty);
                    }
                    catch
                    {
                        SC = 0;
                    }
                    try
                    {
                        TP = (_NetUnitPrice * oProvisionParam.TP * _OrderQty);
                    }
                    catch
                    {
                        TP = 0;
                    }
                    try
                    {
                        PW = (_NetUnitPrice * oProvisionParam.PW * _OrderQty);
                    }
                    catch
                    {
                        PW = 0;
                    }

                    //double AdjustedSC = (_NetUnitPrice * oProvisionParam.SC);
                    //double AdjustedTP = (_NetUnitPrice * oProvisionParam.TP);
                    //double AdjustedPW = (_NetUnitPrice * oProvisionParam.PW);              

                    if (Convert.ToInt32(oItemRow.Cells[32].Value) == 1)//IsApplicableOnOfferPrice
                    {
                        //oItemRow.Cells[11].Value = SC.ToString();
                        _NetUnitPrice = ((_GrossAmount - _TotoalPromotionalAmount) / _OrderQty) - (Math.Round(_NetUnitPrice * oProvisionParam.TP) + Math.Round(_NetUnitPrice * oProvisionParam.PW));
                        double AdjustedSC = Math.Round(_NetUnitPrice * oProvisionParam.SC);
                        oItemRow.Cells[17].Value = AdjustedSC.ToString();
                        oItemRow.Cells[11].Value = (AdjustedSC * _OrderQty).ToString();
                    }
                    if (Convert.ToInt32(oItemRow.Cells[33].Value) == 1)//IsApplicableOnOfferPrice
                    {
                        //oItemRow.Cells[12].Value = TP.ToString();
                        _NetUnitPrice = ((_GrossAmount - _TotoalPromotionalAmount) / _OrderQty) - (Math.Round(_NetUnitPrice * oProvisionParam.SC) + Math.Round(_NetUnitPrice * oProvisionParam.PW));
                        double AdjustedTP = Math.Round(_NetUnitPrice * oProvisionParam.TP);
                        oItemRow.Cells[18].Value = AdjustedTP.ToString();
                        oItemRow.Cells[12].Value = (AdjustedTP * _OrderQty).ToString();
                    }
                    if (Convert.ToInt32(oItemRow.Cells[34].Value) == 1)//IsApplicableOnOfferPrice
                    {
                        //oItemRow.Cells[13].Value = PW.ToString();
                        _NetUnitPrice = ((_GrossAmount - _TotoalPromotionalAmount) / _OrderQty) - (Math.Round(_NetUnitPrice * oProvisionParam.SC) + Math.Round(_NetUnitPrice * oProvisionParam.TP));
                        double AdjustedPW = Math.Round(_NetUnitPrice * oProvisionParam.PW);
                        oItemRow.Cells[19].Value = AdjustedPW.ToString();
                        oItemRow.Cells[13].Value = (AdjustedPW * _OrderQty).ToString();
                    }

                    try
                    {
                        _DP = Convert.ToDouble(oItemRow.Cells[11].Value);
                    }
                    catch
                    {
                        _DP = 0;
                    }
                    try
                    {
                        _TP = Convert.ToDouble(oItemRow.Cells[12].Value);
                    }
                    catch
                    {
                        _TP = 0;
                    }
                    try
                    {
                        _RpC = Convert.ToDouble(oItemRow.Cells[13].Value);
                    }
                    catch
                    {
                        _RpC = 0;
                    }


                    try
                    {
                        _TotalDiscount = _DP + _TP + _RpC + _ConsumerPromotion + _TradePromotion + _CPS;
                    }
                    catch
                    {
                        _TotalDiscount = 0;
                    }
                    _nTotalDiscount = _nTotalDiscount + _TotalDiscount;

                    oItemRow.Cells[28].Value = _TotalDiscount;
                    //oItemRow.Cells[15].Value = Convert.ToDouble(oItemRow.Cells[13].Value) + Convert.ToDouble(oItemRow.Cells[14].Value) + Convert.ToDouble(oItemRow.Cells[20].Value) + Convert.ToDouble(oItemRow.Cells[27].Value);//Discount
                    oItemRow.Cells[29].Value = _GrossAmount - _TotalDiscount;
                    _nPayable = _nPayable + (_GrossAmount - _TotalDiscount);
                    try
                    {
                        _TotalProvisition = _TotalProvisition + _DP + _TP + _RpC;
                    }
                    catch
                    {
                        _TotalProvisition = 0;
                    }

                }
            }
            TELLib oLib = new TELLib();
            txtTotalAmount.Text = oLib.TakaFormat(_nGrossAmount - _TotalProvisition);
            txtAdditionalDiscount.Text = oLib.TakaFormat(_nAdditionalDiscount);
            txtTradeDiscount.Text = oLib.TakaFormat(_nTotalDiscount + _nAdditionalDiscount);
            txtNetPay.Text = oLib.TakaFormat(_nGrossAmount - (_nTotalDiscount + _nAdditionalDiscount));
            txtProvision.Text = oLib.TakaFormat(_TotalProvisition);
            lblAmountInWord.Visible = true;
            lblAmountInWord.Text = oLib.TakaWords(Convert.ToDouble(txtNetPay.Text));
        }
        private void GetPromotion()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            if (ctlCustomer1.txtDescription.Text == "")
            {
                MessageBox.Show("Please select customer first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _nInvoiceCustomerTypeID = ctlCustomer1.SelectedCustomer.CustTypeID;
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oCustomerDetail.refresh();
            _nSalesType = _oCustomerDetail.SalesType;

            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbPromotionType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Promotion Type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dsvPromotion.Rows.Clear();
            dgvPromoCPSimple.Rows.Clear();
            dvgFreeProduct.Rows.Clear();
            //Clear Promo Discount & PromoEMI from Line Itme
            foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
            {
                if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {

                    dgvLineItem.Rows[_oItemRow.Index].Cells[25].Value = 0; //CP
                    dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value = 0; //TP
                    dgvLineItem.Rows[_oItemRow.Index].Cells[27].Value = 0; //CPS
                    dgvLineItem.Rows[_oItemRow.Index].Cells[30].Value = 0;//EMI

                    double _CP = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[25].Value);
                    double _TP = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value);
                    double _CPS = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[27].Value);

                    dgvLineItem.Rows[_oItemRow.Index].Cells[28].Value = (Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[28].Value) + (_CP + _TP + _CPS));//Total Discount
                    dgvLineItem.Rows[_oItemRow.Index].Cells[29].Value = (Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[10].Value) - (_CP + _TP + _CPS));//Payable



                }
            }
            SumNetPayable();
            _IsApplyPromotion = true;
            

            _oDSInvoiceLineItem = new DSConsumerPromo();
            _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
            _oDSEligiblePromo = new DSConsumerPromo();
            _oDSPromoForProduct = new DSConsumerPromo();
            _oDSPromoSlab = new DSConsumerPromo();
            _oDSPromoSlabRatio = new DSConsumerPromo();
            _oDSApplicablePromo = new DSConsumerPromo();
            _oDSApplicablePromo_TP = new DSConsumerPromo();

            _oDSEligiblePromoTP = new DSConsumerPromo();
            _oDSPromoTPForProduct = new DSConsumerPromo();
            _oDSPromoTPSlab = new DSConsumerPromo();
            _oDSPromoTPSlabRatio = new DSConsumerPromo();



            string sProductID = "";
            string sPromoID = "";
            string sPromoNo = "";
            string sPromoName = "";
            string sSlabName = "";
            int nMinInvoiceQty = 0;
            int nPromoID = 0;
            int nSlabID = 0;
            int nOfferMultiplyTimes = 0;
            int nIsApplicableOnOfferPrice = 0;
            string sMAGID = "";
            string sBrandID = "";

            String _sSystemDate = DateTime.Now.Date.ToString("dd-MMM-yyyy");
            oEligiblePromos = new ConsumerPromotionEngines();
            //Get Invoice Line Item
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    DSConsumerPromo.ConsumerPromoRow _oLineItemRow = _oDSInvoiceLineItem.ConsumerPromo.NewConsumerPromoRow();
                    _oLineItemRow.ProductID = int.Parse(oItemRow.Cells[16].Value.ToString());


                    try
                    {
                        _oLineItemRow.Qty = int.Parse(oItemRow.Cells[9].Value.ToString());//Confirm Qty
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Confirm Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ProductDetail oDetail = new ProductDetail();
                    oDetail.ProductID = _oLineItemRow.ProductID;
                    oDetail.Refresh();

                    _oLineItemRow.ProductGroupID = oDetail.MAGID;
                    _oLineItemRow.BrandID = oDetail.BrandID;

                    if (sProductID != "")
                    {
                        sProductID += "," + _oLineItemRow.ProductID.ToString();
                    }
                    else
                    {
                        sProductID += _oLineItemRow.ProductID.ToString();
                    }

                    if (sMAGID != "")
                    {
                        sMAGID += "," + _oLineItemRow.ProductGroupID;
                    }
                    else
                    {
                        sMAGID += _oLineItemRow.ProductGroupID;
                    }

                    if (sBrandID != "")
                    {
                        sBrandID += "," + _oLineItemRow.BrandID;
                    }
                    else
                    {
                        sBrandID += _oLineItemRow.BrandID;
                    }

                    _oDSInvoiceLineItem.ConsumerPromo.AddConsumerPromoRow(_oLineItemRow);
                    _oDSInvoiceLineItem.AcceptChanges();


                    #region CP Simple
                    _oDSEligiblePromoCPSimple = new DSConsumerPromo();
                    try
                    {
                        ////Get Eligible Simple Promo
                        //_oDSEligiblePromoCPSimple = oEligiblePromos.GetEligiblePromoCPSimple(Convert.ToDateTime(_sSystemDate), _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, _nSalesType, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID, _nInvoiceCustomerTypeID, _oLineItemRow.ProductID);
                        //_oDSApplicablePromo.Merge(_oDSEligiblePromoCPSimple);
                        //_oDSApplicablePromo.AcceptChanges();

                    }
                    catch
                    {

                    }
                    #endregion

                }
            }



            #region CP
            ////oEligiblePromos = new ConsumerPromotionEngines();
            ////Get Eligible Promo
            //_oDSEligiblePromo = oEligiblePromos.GetEligiblePromo(Convert.ToDateTime(_sSystemDate), sProductID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, _nSalesType, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID, _nInvoiceCustomerTypeID);

            //if (_oDSEligiblePromo.ConsumerPromo.Rows.Count > 0)
            //{
            //    foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSEligiblePromo.ConsumerPromo)
            //    {
            //        if (sPromoID != "")
            //        {
            //            sPromoID += "," + _oDSRow.ConsumerPromoID.ToString();
            //        }
            //        else
            //        {
            //            sPromoID += _oDSRow.ConsumerPromoID.ToString();
            //        }
            //    }

            //    _oDSPromoForProduct = oEligiblePromos.GetPromoForProduct(sPromoID);
            //    _oDSPromoSlab = oEligiblePromos.GetPromoSlab(sPromoID);
            //    _oDSPromoSlabRatio = oEligiblePromos.GetPromoSlabRatio(sPromoID);
            //    _oDSInvoiceLineItemForPromo.Merge(_oDSInvoiceLineItem);
            //    _oDSInvoiceLineItemForPromo.AcceptChanges();
            //    foreach (DSConsumerPromo.ConsumerPromoRow _oEligibleRow in _oDSEligiblePromo.ConsumerPromo)
            //    {
            //        DSConsumerPromo oDSForProductByPromo = new DSConsumerPromo();
            //        DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "'");
            //        oDSForProductByPromo.Merge(oDR);
            //        oDSForProductByPromo.AcceptChanges();
            //        sPromoNo = _oEligibleRow.ConsumerPromoNo;
            //        sPromoName = _oEligibleRow.ConsumerPromoName;
            //        nIsApplicableOnOfferPrice = _oEligibleRow.IsApplicableOnOfferPrice;
            //        int nCount = 0;
            //        foreach (DSConsumerPromo.ConsumerPromoRow _oDSForProductRow in oDSForProductByPromo.ConsumerPromo)
            //        {
            //            DataRow[] oDRLineItem = _oDSInvoiceLineItem.ConsumerPromo.Select(" ProductID= '" + _oDSForProductRow.ProductID + "'");

            //            if (oDRLineItem.Length != 0)
            //            {
            //                nCount++;
            //            }
            //            else
            //            {
            //                break;
            //            }

            //        }
            //        if (nCount > 0)
            //        {
            //            if (oDSForProductByPromo.ConsumerPromo.Rows.Count == nCount)
            //            {
            //                DSConsumerPromo _DSPromoSlab = new DSConsumerPromo();
            //                DataRow[] oDRSlab = _oDSPromoSlab.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "'");

            //                //string x = oDRSlab[0]["SlabID"].ToString();

            //                _DSPromoSlab.Merge(oDRSlab);
            //                _DSPromoSlab.AcceptChanges();

            //                //DataRow[] y = _DSPromoSlab.ConsumerPromo.Select("SlabID = Min(Slab)");
            //                //string z = y[0]["SlabID"].ToString();

            //                foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRow in _DSPromoSlab.ConsumerPromo)
            //                {
            //                    DSConsumerPromo _DSPromoSlabRatio = new DSConsumerPromo();
            //                    DataRow[] oDRSlabRatio = _oDSPromoSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "' and SlabID= '" + _oSlabRow.SlabID + "' ");
            //                    _DSPromoSlabRatio.Merge(oDRSlabRatio);
            //                    _DSPromoSlabRatio.AcceptChanges();
            //                    sSlabName = _oSlabRow.SlabName;

            //                    int nCountSlabRatio = 0;

            //                    foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRatioRow in _DSPromoSlabRatio.ConsumerPromo)
            //                    {
            //                        DataRow[] oDRLineItemCheck = _oDSInvoiceLineItemForPromo.ConsumerPromo.Select(" ProductID = '" + _oSlabRatioRow.ProductID + "' and Qty >= '" + _oSlabRatioRow.Qty + "' ");
            //                        //int x = Convert.ToInt32(oDRLineItemCheck[0]["Qty"]);
            //                        nPromoID = _oSlabRatioRow.ConsumerPromoID;
            //                        nSlabID = _oSlabRatioRow.SlabID;

            //                        if (oDRLineItemCheck.Length != 0)
            //                        {
            //                            nCountSlabRatio++;
            //                            //break;
            //                        }
            //                    }

            //                    if (_DSPromoSlabRatio.ConsumerPromo.Rows.Count == nCountSlabRatio)
            //                    {
            //                        nOfferMultiplyTimes = 0;
            //                        DSConsumerPromo _oDSConsumerPromoTemp = new DSConsumerPromo();
            //                        foreach (DSConsumerPromo.ConsumerPromoRow _dsRow in _oDSInvoiceLineItemForPromo.ConsumerPromo)
            //                        {
            //                            int nRevisedQty = 0;

            //                            DataRow[] oDRLineItemCheckForPromo = _oDSPromoSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and SlabID= '" + nSlabID + "' and ProductID='" + _dsRow.ProductID + "' ");
            //                            if (oDRLineItemCheckForPromo.Length != 0)
            //                            {
            //                                int nRatioQty = Convert.ToInt32(oDRLineItemCheckForPromo[0]["Qty"]);
            //                                //nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
            //                                if (nOfferMultiplyTimes == 0)
            //                                {
            //                                    nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
            //                                }
            //                                else
            //                                {
            //                                    if (nOfferMultiplyTimes > Convert.ToInt32(_dsRow.Qty / nRatioQty))
            //                                    {
            //                                        nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
            //                                    }
            //                                }

            //                                nRevisedQty = _dsRow.Qty - (nRatioQty * nOfferMultiplyTimes);
            //                            }
            //                            else
            //                            {
            //                                nRevisedQty = _dsRow.Qty;
            //                            }
            //                            DSConsumerPromo.ConsumerPromoRow _oTempRow = _oDSConsumerPromoTemp.ConsumerPromo.NewConsumerPromoRow();
            //                            _oTempRow.ProductID = _dsRow.ProductID;
            //                            _oTempRow.Qty = nRevisedQty;
            //                            _oDSConsumerPromoTemp.ConsumerPromo.AddConsumerPromoRow(_oTempRow);
            //                            _oDSConsumerPromoTemp.AcceptChanges();
            //                        }

            //                        _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
            //                        _oDSInvoiceLineItemForPromo.Merge(_oDSConsumerPromoTemp);
            //                        _oDSInvoiceLineItemForPromo.AcceptChanges();



            //                        DSConsumerPromo.ConsumerPromoRow _oDSApplicablePromoRow = _oDSApplicablePromo.ConsumerPromo.NewConsumerPromoRow();
            //                        _oDSApplicablePromoRow.ConsumerPromoID = nPromoID;
            //                        _oDSApplicablePromoRow.ConsumerPromoNo = sPromoNo;
            //                        _oDSApplicablePromoRow.ConsumerPromoName = sPromoName;
            //                        _oDSApplicablePromoRow.SlabID = nSlabID;
            //                        _oDSApplicablePromoRow.SlabName = sSlabName;
            //                        _oDSApplicablePromoRow.PromoType = "CP";
            //                        _oDSApplicablePromoRow.MultiplyTimes = nOfferMultiplyTimes;
            //                        _oDSApplicablePromoRow.IsApplicableOnOfferPrice = nIsApplicableOnOfferPrice;
            //                        oEligiblePromos.GetPromoOffer(nPromoID, nSlabID);
            //                        if (oEligiblePromos.Count == 1)//Single offer will be auto effected
            //                        {
            //                            foreach (ConsumerPromotionEngine oPromoData in oEligiblePromos)
            //                            {
            //                                _oDSApplicablePromoRow.OfferID = oPromoData.OfferID;
            //                                _oDSApplicablePromoRow.OfferDescription = oPromoData.OfferDesctiption;
            //                                _oDSApplicablePromoRow.Flag = false;
            //                            }
            //                        }
            //                        else
            //                        {
            //                            _oDSApplicablePromoRow.OfferID = 0;
            //                            _oDSApplicablePromoRow.OfferDescription = "< Please Select an Offer >";
            //                            _oDSApplicablePromoRow.Flag = true;
            //                        }
            //                        _oDSApplicablePromo.ConsumerPromo.AddConsumerPromoRow(_oDSApplicablePromoRow);
            //                        _oDSApplicablePromo.AcceptChanges();

            //                    }

            //                }
            //                _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
            //                _oDSInvoiceLineItemForPromo.Merge(_oDSInvoiceLineItem);
            //                _oDSInvoiceLineItemForPromo.AcceptChanges();
            //            }
            //        }

            //    }
            //}
            #endregion

            #region TP
            oEligiblePromos = new ConsumerPromotionEngines();
            //Get Eligible Promo
            ConsumerPromotionEngine oConsumerPromotionEngine = new Class.ConsumerPromotionEngine();
            _oDSEligiblePromoTP = oEligiblePromos.GetEligiblePromoTPSecondary(Convert.ToDateTime(_sSystemDate), sMAGID, sBrandID, _nSalesType, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID, _nInvoiceCustomerTypeID);


            if (_oDSEligiblePromoTP.ConsumerPromo.Rows.Count > 0)
            {
                string _sPromoID = "";
                //Get eligible promo id
                foreach (DSConsumerPromo.ConsumerPromoRow _oRowX in _oDSEligiblePromoTP.ConsumerPromo)
                {
                    if (_sPromoID != "")
                    {
                        _sPromoID += "," + _oRowX.ConsumerPromoID;
                    }
                    else
                    {
                        _sPromoID += _oRowX.ConsumerPromoID;
                    }
                }
                DSConsumerPromo _XdsTPForProd = new DSConsumerPromo();
                _XdsTPForProd = oEligiblePromos.GetPromoTPForProductSecondary(_sPromoID);
                _sPromoID = "";

                //Get for applicable all sku under promos
                foreach (DSConsumerPromo.ConsumerPromoRow _oRowY in _XdsTPForProd.ConsumerPromo)
                {
                    //Check specific product for combo
                    DataRow[] oDSRow = _XdsTPForProd.ConsumerPromo.Select(" ConsumerPromoID= '" + _oRowY.ConsumerPromoID + "' and IsApplicableOnAllSKU = 0 ");

                    if (oDSRow.Length > 0)
                    {
                        //return;
                    }
                    else
                    {

                        if (_oRowY.IsApplicableOnAllSKU == 1)
                        {
                            if (_sPromoID != "")
                            {
                                _sPromoID += "," + _oRowY.ConsumerPromoID;
                            }
                            else
                            {
                                _sPromoID += _oRowY.ConsumerPromoID;
                            }
                        }
                    }
                }
                

                DSConsumerPromo _oDSForProdSplitProdID = new DSConsumerPromo();
                foreach (DSConsumerPromo.ConsumerPromoRow _oRowY in _XdsTPForProd.ConsumerPromo)
                {
                    if (_oRowY.IsApplicableOnAllSKU == 0)
                    {
                        string s = _oRowY.ApplicableProductID;
                        string[] values = s.Split(',');
                        for (int i = 0; i < values.Length; i++)
                        {
                            DSConsumerPromo.ConsumerPromoRow _oDSRowX = _oDSForProdSplitProdID.ConsumerPromo.NewConsumerPromoRow();
                            _oDSRowX.ConsumerPromoID = _oRowY.ConsumerPromoID;
                            _oDSRowX.ApplicableProductID = values[i].Trim();
                            _oDSForProdSplitProdID.ConsumerPromo.AddConsumerPromoRow(_oDSRowX);
                            _oDSForProdSplitProdID.AcceptChanges();
                        }
                    }
                }

                foreach (DSConsumerPromo.ConsumerPromoRow _oDSRowX in _oDSInvoiceLineItem.ConsumerPromo)
                {
                    DataRow[] oDSRow = _oDSForProdSplitProdID.ConsumerPromo.Select(" ApplicableProductID= '" + _oDSRowX.ProductID + "'");

                    if (oDSRow.Length > 0)
                    {
                        if (_sPromoID != "")
                        {
                            _sPromoID += "," + oDSRow[0]["ConsumerPromoID"];
                        }
                        else
                        {
                            _sPromoID += oDSRow[0]["ConsumerPromoID"];
                        }
                    }
                }
                

                _oDSEligiblePromoTP = new DSConsumerPromo();
                oEligiblePromos = new ConsumerPromotionEngines();
                if (_sPromoID != "")
                    _oDSEligiblePromoTP = oEligiblePromos.GetPromoTPByPromoIDSecondary(_sPromoID);

                nIsApplicableOnOfferPrice = 0;
                if (_oDSEligiblePromoTP.ConsumerPromo.Rows.Count > 0)
                {
                    //Group by MAG & Brand
                    DSConsumerPromo _oDSMAGBrandGroupby = new DSConsumerPromo();
                    foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSInvoiceLineItem.ConsumerPromo)
                    {

                        DataRow[] oDSRow = _oDSMAGBrandGroupby.ConsumerPromo.Select(" ProductGroupID= '" + _oDSRow.ProductGroupID + "' and BrandID = '" + _oDSRow.BrandID + "' ");

                        if (oDSRow.Length == 0)
                        {
                            DSConsumerPromo.ConsumerPromoRow _oDSMAGBrandGroupbyRow = _oDSMAGBrandGroupby.ConsumerPromo.NewConsumerPromoRow();
                            _oDSMAGBrandGroupbyRow.ProductGroupID = _oDSRow.ProductGroupID;
                            _oDSMAGBrandGroupbyRow.BrandID = _oDSRow.BrandID;
                            _oDSMAGBrandGroupbyRow.Qty = 0;
                            _oDSMAGBrandGroupby.ConsumerPromo.AddConsumerPromoRow(_oDSMAGBrandGroupbyRow);
                            _oDSMAGBrandGroupby.AcceptChanges();

                        }
                    }

                    //Sum Qty by MAG & Brand
                    DSConsumerPromo _oDSMAGBrandGroupbyWithQty = new DSConsumerPromo();
                    DSConsumerPromo _oDSMAGBrandGroupbyWithQtyTemp = new DSConsumerPromo();
                    foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSMAGBrandGroupby.ConsumerPromo)
                    {
                        DSConsumerPromo _oDSInvoiceLineItemTemp = new DSConsumerPromo();
                        DataRow[] oDSRow = _oDSInvoiceLineItem.ConsumerPromo.Select(" ProductGroupID= '" + _oDSRow.ProductGroupID + "' and BrandID = '" + _oDSRow.BrandID + "' ");
                        _oDSInvoiceLineItemTemp.Merge(oDSRow);
                        _oDSInvoiceLineItemTemp.AcceptChanges();
                        int nSumQty = 0;
                        if (oDSRow.Length != 0)
                        {
                            foreach (DSConsumerPromo.ConsumerPromoRow _oDSRowTemp in _oDSInvoiceLineItemTemp.ConsumerPromo)
                            {
                                nSumQty += _oDSRowTemp.Qty;
                            }

                        }

                        DSConsumerPromo.ConsumerPromoRow _oGroupbyQtyRow = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.NewConsumerPromoRow();
                        _oGroupbyQtyRow.ProductGroupID = _oDSRow.ProductGroupID;
                        _oGroupbyQtyRow.BrandID = _oDSRow.BrandID;
                        _oGroupbyQtyRow.Qty = nSumQty;
                        _oDSMAGBrandGroupbyWithQty.ConsumerPromo.AddConsumerPromoRow(_oGroupbyQtyRow);
                        _oDSMAGBrandGroupbyWithQty.AcceptChanges();
                    }

                    _oDSMAGBrandGroupbyWithQtyTemp.Merge(_oDSMAGBrandGroupbyWithQty);
                    _oDSMAGBrandGroupbyWithQtyTemp.AcceptChanges();

                    //Get Eligible Promo
                    sPromoID = "";
                    foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSEligiblePromoTP.ConsumerPromo)
                    {
                        if (sPromoID != "")
                        {
                            sPromoID += "," + _oDSRow.ConsumerPromoID.ToString();
                        }
                        else
                        {
                            sPromoID += _oDSRow.ConsumerPromoID.ToString();
                        }
                    }

                    _oDSPromoTPForProduct = oEligiblePromos.GetPromoTPForProductSecondary(sPromoID);
                    _oDSPromoTPSlab = oEligiblePromos.GetPromoSlabTPSecondary(sPromoID);
                    _oDSPromoTPSlabRatio = oEligiblePromos.GetPromoSlabRatioTPSecondary(sPromoID);

                    foreach (DSConsumerPromo.ConsumerPromoRow _oEligibleRowTP in _oDSEligiblePromoTP.ConsumerPromo)
                    {
                        DSConsumerPromo oDSForProductByPromoTP = new DSConsumerPromo();
                        DataRow[] oDR = _oDSPromoTPForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "'");
                        oDSForProductByPromoTP.Merge(oDR);
                        oDSForProductByPromoTP.AcceptChanges();
                        sPromoNo = _oEligibleRowTP.ConsumerPromoNo;
                        sPromoName = _oEligibleRowTP.ConsumerPromoName;
                        nIsApplicableOnOfferPrice = _oEligibleRowTP.IsApplicableOnOfferPrice;
                        int nCount = 0;

                        foreach (DSConsumerPromo.ConsumerPromoRow _oDSForProductRowTP in oDSForProductByPromoTP.ConsumerPromo)
                        {
                            DataRow[] oDRLineItem = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.Select(" ProductGroupID= '" + _oDSForProductRowTP.ProductGroupID + "' and BrandID= '" + _oDSForProductRowTP.BrandID + "'");

                            if (oDRLineItem.Length != 0)
                            {
                                nCount++;
                            }
                            else
                            {
                                DataRow[] oDRCheckMinQtyZero = _oDSPromoTPSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "' and SlabID=1  and ProductGroupID = '" + _oDSForProductRowTP.ProductGroupID + "' and BrandID= '" + _oDSForProductRowTP.BrandID + "' and MinQty = 0 ");
                                if (oDRCheckMinQtyZero.Length > 0)
                                {
                                    nCount++;
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        if (nCount > 0)
                        {
                            if (oDSForProductByPromoTP.ConsumerPromo.Rows.Count == nCount)
                            {
                                DSConsumerPromo _DSPromoSlabTP = new DSConsumerPromo();
                                DataRow[] oDRSlab = _oDSPromoTPSlab.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "'");

                                //string x = oDRSlab[0]["SlabID"].ToString();

                                _DSPromoSlabTP.Merge(oDRSlab);
                                _DSPromoSlabTP.AcceptChanges();

                                //DataRow[] y = _DSPromoSlab.ConsumerPromo.Select("SlabID = Min(Slab)");
                                //string z = y[0]["SlabID"].ToString();

                                foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRowTP in _DSPromoSlabTP.ConsumerPromo)
                                {
                                    DSConsumerPromo _DSPromoSlabRatioTP = new DSConsumerPromo();
                                    DataRow[] oDRSlabRatioTP = _oDSPromoTPSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "' and SlabID= '" + _oSlabRowTP.SlabID + "' ");
                                    _DSPromoSlabRatioTP.Merge(oDRSlabRatioTP);
                                    _DSPromoSlabRatioTP.AcceptChanges();
                                    sSlabName = _oSlabRowTP.SlabName;
                                    nMinInvoiceQty = _oSlabRowTP.MinInvoiceQty;
                                    int nCountSlabRatio = 0;
                                    int nInvoiceQty = 0;
                                    int nProductGroupID = 0;
                                    int nBrandID = 0;
                                    foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRatioRow in _DSPromoSlabRatioTP.ConsumerPromo)
                                    {
                                        DataRow[] oDRLineItemCheck = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.Select(" ProductGroupID = '" + _oSlabRatioRow.ProductGroupID + "' and BrandID = '" + _oSlabRatioRow.BrandID + "' and Qty >= '" + _oSlabRatioRow.MinQty + "'");
                                        nProductGroupID = _oSlabRatioRow.ProductGroupID;
                                        nBrandID = _oSlabRatioRow.BrandID;

                                        if (oDRLineItemCheck.Length != 0)
                                        {
                                            nInvoiceQty += Convert.ToInt32(oDRLineItemCheck[0]["Qty"]);
                                            nPromoID = _oSlabRatioRow.ConsumerPromoID;
                                            nSlabID = _oSlabRatioRow.SlabID;

                                            nCountSlabRatio++;
                                            //break;
                                        }
                                        else
                                        {
                                            DataRow[] oDRCheckMinQtyZero = _oDSPromoTPSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "' and SlabID=1  and ProductGroupID = '" + _oSlabRatioRow.ProductGroupID + "' and BrandID= '" + _oSlabRatioRow.BrandID + "' and MinQty = 0 ");
                                            if (oDRCheckMinQtyZero.Length > 0)
                                            {
                                                nCountSlabRatio++;
                                            }
                                        }
                                    }

                                    if (_DSPromoSlabRatioTP.ConsumerPromo.Rows.Count == nCountSlabRatio)
                                    {
                                        nOfferMultiplyTimes = 0;
                                        if (nInvoiceQty >= nMinInvoiceQty)
                                        {
                                            for (int i = 0; nMinInvoiceQty <= nInvoiceQty; i++)
                                            {
                                                nOfferMultiplyTimes++;
                                                nInvoiceQty = nInvoiceQty - nMinInvoiceQty;
                                            }

                                            //Update Data set
                                            DSConsumerPromo _oDSTemp = new DSConsumerPromo();
                                            int nTotalGroup = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.Count;

                                            if (nInvoiceQty != 0)
                                            {
                                                double x = (nInvoiceQty / nTotalGroup);
                                                x = Math.Round(x, 0);
                                                int nX = 0;
                                                int nQty = 0;
                                                foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSMAGBrandGroupbyWithQty.ConsumerPromo)
                                                {
                                                    nX++;
                                                    if (nTotalGroup == nX)
                                                    {
                                                        x = (nInvoiceQty - nQty);
                                                    }
                                                    else
                                                    {
                                                        nQty += Convert.ToInt32(x);
                                                    }
                                                    DSConsumerPromo.ConsumerPromoRow _oRow = _oDSTemp.ConsumerPromo.NewConsumerPromoRow();
                                                    _oRow.ProductGroupID = _oDSRow.ProductGroupID;
                                                    _oRow.BrandID = _oDSRow.BrandID;
                                                    _oRow.Qty = Convert.ToInt32(x);
                                                    _oDSTemp.ConsumerPromo.AddConsumerPromoRow(_oRow);
                                                    _oDSTemp.AcceptChanges();
                                                }

                                            }
                                            else
                                            {

                                                foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSMAGBrandGroupbyWithQty.ConsumerPromo)
                                                {
                                                    DSConsumerPromo.ConsumerPromoRow _oRow = _oDSTemp.ConsumerPromo.NewConsumerPromoRow();
                                                    _oRow.ProductGroupID = _oDSRow.ProductGroupID;
                                                    _oRow.BrandID = _oDSRow.BrandID;
                                                    _oRow.Qty = 0;
                                                    _oDSTemp.ConsumerPromo.AddConsumerPromoRow(_oRow);
                                                    _oDSTemp.AcceptChanges();
                                                }
                                            }

                                            _oDSMAGBrandGroupbyWithQty.Merge(_oDSTemp);
                                            _oDSMAGBrandGroupbyWithQty.AcceptChanges();


                                            DSConsumerPromo.ConsumerPromoRow _oDSApplicablePromoRow = _oDSApplicablePromo_TP.ConsumerPromo.NewConsumerPromoRow();
                                            _oDSApplicablePromoRow.ConsumerPromoID = nPromoID;
                                            _oDSApplicablePromoRow.ConsumerPromoNo = sPromoNo;
                                            _oDSApplicablePromoRow.ConsumerPromoName = sPromoName;
                                            _oDSApplicablePromoRow.SlabID = nSlabID;
                                            _oDSApplicablePromoRow.SlabName = sSlabName;
                                            _oDSApplicablePromoRow.PromoType = "TP";
                                            _oDSApplicablePromoRow.MultiplyTimes = nOfferMultiplyTimes;
                                            _oDSApplicablePromoRow.IsApplicableOnOfferPrice = nIsApplicableOnOfferPrice;
                                            oEligiblePromos.GetPromoOfferTPSecondary(nPromoID, nSlabID);
                                            if (oEligiblePromos.Count == 1)//Single offer will be auto effected
                                            {
                                                foreach (ConsumerPromotionEngine oPromoData in oEligiblePromos)
                                                {
                                                    _oDSApplicablePromoRow.OfferID = oPromoData.OfferID;
                                                    _oDSApplicablePromoRow.OfferDescription = oPromoData.OfferDesctiption;
                                                    _oDSApplicablePromoRow.Flag = false;
                                                }
                                            }
                                            else
                                            {
                                                _oDSApplicablePromoRow.OfferID = 0;
                                                _oDSApplicablePromoRow.OfferDescription = "< Please Select an Offer >";
                                                _oDSApplicablePromoRow.Flag = true;
                                            }
                                            _oDSApplicablePromo_TP.ConsumerPromo.AddConsumerPromoRow(_oDSApplicablePromoRow);
                                            _oDSApplicablePromo_TP.AcceptChanges();
                                            break;////Should be deleted (Gozamil Code)
                                        }
                                    }

                                }
                            }
                        }

                        //Merge
                        _oDSMAGBrandGroupbyWithQty.Merge(_oDSMAGBrandGroupbyWithQtyTemp);
                        _oDSMAGBrandGroupbyWithQty.AcceptChanges();

                    }
                }
            }
            #endregion
            //Set Promotions

            _oDSApplicablePromo.Merge(_oDSApplicablePromo_TP);
            _oDSApplicablePromo.AcceptChanges();






            dsvPromotion.Rows.Clear();
            int nCountPromo = 0;
            string sPromoSimpleID = "";

            foreach (DSConsumerPromo.ConsumerPromoRow oDSApplicablePromoRow in _oDSApplicablePromo.ConsumerPromo)
            {
                nCountPromo++;

                ///Newly Add for PromoCPSimple
                if (oDSApplicablePromoRow.PromoType == "CPSimple")
                {

                    #region Newly Add for PromoCPSimple
                    DataGridViewRow oRows = new DataGridViewRow();
                    oRows.CreateCells(dgvPromoCPSimple);
                    oRows.Cells[0].Value = oDSApplicablePromoRow.ConsumerPromoID;
                    oRows.Cells[1].Value = oDSApplicablePromoRow.DiscountType;
                    oRows.Cells[2].Value = oDSApplicablePromoRow.DiscountAmount;
                    oRows.Cells[3].Value = oDSApplicablePromoRow.FreeEMITenureID;
                    oRows.Cells[4].Value = oDSApplicablePromoRow.ProductID;
                    dgvPromoCPSimple.Rows.Add(oRows);
                    #endregion 


                    if (nCountPromo != 1)
                    {
                        if (!sPromoSimpleID.Contains(oDSApplicablePromoRow.ConsumerPromoID.ToString()))
                        {
                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dsvPromotion);
                            oRow.Cells[0].Value = oDSApplicablePromoRow.ConsumerPromoNo;
                            oRow.Cells[1].Value = oDSApplicablePromoRow.ConsumerPromoName;
                            oRow.Cells[2].Value = oDSApplicablePromoRow.PromoType;
                            oRow.Cells[3].Value = oDSApplicablePromoRow.SlabName;
                            oRow.Cells[4].Value = oDSApplicablePromoRow.OfferDescription;
                            if (oDSApplicablePromoRow.Flag == false)
                            {
                                oRow.Cells[5].ReadOnly = true;
                            }
                            oRow.Cells[6].Value = oDSApplicablePromoRow.OfferID;
                            oRow.Cells[7].Value = oDSApplicablePromoRow.SlabID;
                            oRow.Cells[8].Value = oDSApplicablePromoRow.ConsumerPromoID;
                            oRow.Cells[9].Value = oDSApplicablePromoRow.MultiplyTimes;
                            oRow.Cells[10].Value = oDSApplicablePromoRow.IsApplicableOnOfferPrice;


                            if (sPromoSimpleID == "")
                            {
                                sPromoSimpleID = oRow.Cells[8].Value.ToString();
                            }
                            else
                            {
                                sPromoSimpleID = sPromoSimpleID + "," + oRow.Cells[8].Value.ToString();
                            }

                            dsvPromotion.Rows.Add(oRow);
                        }
                    }
                    else
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dsvPromotion);
                        oRow.Cells[0].Value = oDSApplicablePromoRow.ConsumerPromoNo;
                        oRow.Cells[1].Value = oDSApplicablePromoRow.ConsumerPromoName;
                        oRow.Cells[2].Value = oDSApplicablePromoRow.PromoType;
                        oRow.Cells[3].Value = oDSApplicablePromoRow.SlabName;
                        oRow.Cells[4].Value = oDSApplicablePromoRow.OfferDescription;
                        if (oDSApplicablePromoRow.Flag == false)
                        {
                            oRow.Cells[5].ReadOnly = true;
                        }
                        oRow.Cells[6].Value = oDSApplicablePromoRow.OfferID;
                        oRow.Cells[7].Value = oDSApplicablePromoRow.SlabID;
                        oRow.Cells[8].Value = oDSApplicablePromoRow.ConsumerPromoID;
                        oRow.Cells[9].Value = oDSApplicablePromoRow.MultiplyTimes;
                        oRow.Cells[10].Value = oDSApplicablePromoRow.IsApplicableOnOfferPrice;

                        if (sPromoSimpleID == "")
                        {
                            sPromoSimpleID = oRow.Cells[8].Value.ToString();
                        }
                        else
                        {
                            sPromoSimpleID = sPromoSimpleID + "," + oRow.Cells[8].Value.ToString();
                        }
                        dsvPromotion.Rows.Add(oRow);
                    }
                }
                //END Newly Add for PromoCPSimple
                else
                {


                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dsvPromotion);
                    oRow.Cells[0].Value = oDSApplicablePromoRow.ConsumerPromoNo;
                    oRow.Cells[1].Value = oDSApplicablePromoRow.ConsumerPromoName;
                    oRow.Cells[2].Value = oDSApplicablePromoRow.PromoType;
                    oRow.Cells[3].Value = oDSApplicablePromoRow.SlabName;
                    oRow.Cells[4].Value = oDSApplicablePromoRow.OfferDescription;
                    if (oDSApplicablePromoRow.Flag == false)
                    {
                        oRow.Cells[5].ReadOnly = true;
                    }
                    oRow.Cells[6].Value = oDSApplicablePromoRow.OfferID;
                    oRow.Cells[7].Value = oDSApplicablePromoRow.SlabID;
                    oRow.Cells[8].Value = oDSApplicablePromoRow.ConsumerPromoID;
                    oRow.Cells[9].Value = oDSApplicablePromoRow.MultiplyTimes;
                    oRow.Cells[10].Value = oDSApplicablePromoRow.IsApplicableOnOfferPrice;
                    dsvPromotion.Rows.Add(oRow);
                }

            }
            if (nCountPromo == 0)
            {
                _IsApplyPromotion = true;
            }
            else
            {
                _IsApplyPromotion = false;
            }
            
        }
        private void btnGetPromotion_Click(object sender, EventArgs e)
        {
            GetPromotion();
        }
        private bool ApplyPromotionValidation()
        {
            if (dsvPromotion.Rows.Count == 0)
            {
                MessageBox.Show("There is no applicable promotion ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                foreach (DataGridViewRow oItemRow in dsvPromotion.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count)
                    {
                        if (Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim()) == 0)
                        {
                            MessageBox.Show("Please Select an Offer before applying promotion", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }

            }

            return true;
        }
        private void ApplyPromotion()
        {
                       
            cmbPromotionType.Enabled = false;
            if (ApplyPromotionValidation())
            {
                oInvoiceDiscountChargeMap = new CJ.Class.POS.DSSalesInvoice();
                dvgFreeProduct.Rows.Clear();
                //Clear Promo Discount & PromoEMI from Line Itme
                foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                {
                    if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {


                        double _CP = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[25].Value);
                        double _TP = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value);
                        double _CPSimple = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[27].Value);
                        dgvLineItem.Rows[_oItemRow.Index].Cells[25].Value = 0; //CP
                        dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value = 0; //TP
                        dgvLineItem.Rows[_oItemRow.Index].Cells[27].Value = 0; //CPSimple
                        dgvLineItem.Rows[_oItemRow.Index].Cells[28].Value = (Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[28].Value) + (_CP + _TP));//Total Discount
                        dgvLineItem.Rows[_oItemRow.Index].Cells[29].Value = (Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[10].Value) - (_CP + _TP));//Payable
                        dgvLineItem.Rows[_oItemRow.Index].Cells[30].Value = 0;//EMI


                    }




                }


                #region Promo CP Simple

                //foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                //{
                //    if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                //    {
                //        double _discount = 0;
                //        int nFreeEMIID = 0;
                //        int nFreeTenure = 0;
                //        foreach (DataGridViewRow _oPromoSimpleLine in dgvPromoCPSimple.Rows)
                //        {
                //            if (_oPromoSimpleLine.Index < dgvPromoCPSimple.Rows.Count)
                //            {
                //                if (Convert.ToInt32(_oPromoSimpleLine.Cells[4].Value.ToString().Trim()) == Convert.ToInt32(_oItemRow.Cells[16].Value.ToString().Trim()))
                //                {

                //                    if (Convert.ToInt32(_oPromoSimpleLine.Cells[1].Value.ToString().Trim()) == (int)Dictionary.SalesPromSlabDiscountType.Parcent)
                //                    {

                //                        double discount = (Convert.ToInt32(_oItemRow.Cells[3].Value.ToString().Trim()) * Convert.ToInt32(_oPromoSimpleLine.Cells[2].Value.ToString().Trim()) / 100) * Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim()); ;

                //                        if (_discount == 0)
                //                        {
                //                            _discount = discount;
                //                        }
                //                        else
                //                        {
                //                            _discount = _discount + discount;
                //                        }

                //                        #region Promo CP Simple Percent
                //                        ///Consumer Promotion Simple=57
                //                        SetPromoMap(57, Convert.ToInt32(_oPromoSimpleLine.Cells[0].Value.ToString()), 1, 1, "t_PromoCPSimple", 1, discount, -1, 0, Convert.ToInt32(_oPromoSimpleLine.Cells[4].Value.ToString()), -1, -1);
                //                        #endregion
                //                    }
                //                    else if (Convert.ToInt32(_oPromoSimpleLine.Cells[1].Value.ToString().Trim()) == (int)Dictionary.SalesPromSlabDiscountType.FlatAmount)
                //                    {
                //                        double discount = Convert.ToInt32(_oPromoSimpleLine.Cells[2].Value) * Convert.ToInt32(_oItemRow.Cells[9].Value);
                //                        if (_discount == 0)
                //                        {
                //                            _discount = discount;
                //                        }
                //                        else
                //                        {
                //                            _discount = _discount + discount;
                //                        }

                //                        #region Promo CP Simple FlatAmount

                //                        SetPromoMap(57, Convert.ToInt32(_oPromoSimpleLine.Cells[0].Value.ToString()), 1, 1, "t_PromoCPSimple", 1, discount, -1, 0, Convert.ToInt32(_oPromoSimpleLine.Cells[4].Value.ToString()), -1, -1);
                //                        #endregion

                //                    }
                //                    if (Convert.ToInt32(_oPromoSimpleLine.Cells[3].Value) != -1 || Convert.ToInt32(_oPromoSimpleLine.Cells[3].Value) != 0)
                //                    {
                //                        #region Promo CP Simple EMI
                //                        SetPromoMap(-1, Convert.ToInt32(_oPromoSimpleLine.Cells[0].Value.ToString()), 1, 1, "t_PromoCPSimple", 1, 0, -1, 0, Convert.ToInt32(_oPromoSimpleLine.Cells[4].Value.ToString()), Convert.ToInt32(_oPromoSimpleLine.Cells[3].Value), -1);
                //                        #endregion

                //                        Class.Accounts.EMITenure oGetMaxTenure = new Class.Accounts.EMITenure();
                //                        oGetMaxTenure.EMITenureID = Convert.ToInt32(_oPromoSimpleLine.Cells[3].Value);
                //                        oGetMaxTenure.Refresh();
                //                        if (nFreeEMIID == 0)
                //                        {
                //                            nFreeEMIID = oGetMaxTenure.EMITenureID;
                //                            nFreeTenure = oGetMaxTenure.Tenure;
                //                        }
                //                        else
                //                        {
                //                            if (nFreeTenure < oGetMaxTenure.Tenure)
                //                            {
                //                                nFreeTenure = oGetMaxTenure.Tenure;
                //                                nFreeEMIID = oGetMaxTenure.EMITenureID;
                //                            }

                //                        }

                //                    }

                //                }
                //            }
                //        }

                //        _oItemRow.Cells[27].Value = _discount.ToString();
                //        _oItemRow.Cells[31].Value = nFreeEMIID.ToString();
                //    }
                //}
                #endregion



                foreach (DataGridViewRow oItemRow in dsvPromotion.Rows)
                {
                    if (oItemRow.Index < dsvPromotion.Rows.Count)
                    {
                        string sPromoType = oItemRow.Cells[2].Value.ToString().Trim();
                        int nOfferID = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                        int nSlabID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        int nPromoID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                        int nMultiplyTimes = Convert.ToInt32(oItemRow.Cells[9].Value.ToString().Trim());
                        int nIsApplicableOnOfferPrice = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());
                        string sPromotionNo = oItemRow.Cells[0].Value.ToString().Trim();
                        _oConsumerPromotionEngines = new ConsumerPromotionEngines();
                        double _DisAmt = 0;
                        if (sPromoType == "CP")
                        {
                            //if (!DBController.Instance.CheckConnection())
                            //{
                            //    DBController.Instance.OpenNewConnection();
                            //}
                            //_oConsumerPromotionEngines.GetPromoOfferDetail(nPromoID, nSlabID, nOfferID);

                            //foreach (ConsumerPromotionEngine oCPE in _oConsumerPromotionEngines)
                            //{
                            //    if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Product)
                            //    {
                            //        Product oProduct = new Product();
                            //        oProduct.ProductID = oCPE.OfferProductID;
                            //        oProduct.RefreshByID();

                            //        DataGridViewRow oRow = new DataGridViewRow();
                            //        oRow.CreateCells(dvgFreeProduct);
                            //        oRow.Cells[0].Value = sPromotionNo;
                            //        oRow.Cells[1].Value = oProduct.ProductCode;
                            //        oRow.Cells[2].Value = oProduct.ProductName;
                            //        oRow.Cells[3].Value = oCPE.OfferQty * nMultiplyTimes;
                            //        oRow.Cells[4].Value = oProduct.ProductID;
                            //        oRow.Cells[5].Value = oCPE.ConsumerPromoID;
                            //        oRow.Cells[6].Value = oCPE.SlabID;
                            //        oRow.Cells[7].Value = oCPE.OfferID;
                            //        oRow.Cells[8].Value = oProduct.IsBarcodeItem;
                            //        oRow.Cells[9].Value = oProduct.CostPrice;
                            //        oRow.Cells[10].Value = "CP";

                            //        //oRow.Cells[0].Value = oProduct.ProductCode;
                            //        //oRow.Cells[1].Value = oProduct.ProductName;
                            //        //oRow.Cells[2].Value = oCPE.OfferQty * nMultiplyTimes;
                            //        //oRow.Cells[5].Value = oProduct.ProductID;
                            //        //oRow.Cells[6].Value = oProduct.CostPrice;
                            //        //oRow.Cells[7].Value = oProduct.IsBarcodeItem;

                            //        //oRow.Cells[8].Value = "CP";
                            //        //oRow.Cells[9].Value = oCPE.ConsumerPromoID;
                            //        //oRow.Cells[10].Value = oCPE.SlabID;
                            //        //oRow.Cells[11].Value = oCPE.OfferID;

                            //        dvgFreeProduct.Rows.Add(oRow);

                            //        #region Promo MAP
                            //        SetPromoMap(-1, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, 0, oProduct.ProductID, Convert.ToInt32(oRow.Cells[3].Value), -1, -1, 0);
                            //        #endregion 
                            //    }
                            //    else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.FlatAmount || oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
                            //    {
                            //        //Get Discount amount by percent
                            //        double _DisAmount = 0;
                            //        double _DiscountEligiblePrice = 0;
                            //        if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
                            //        {
                            //            foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                            //            {
                            //                if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                            //                {
                            //                    int nProductID = Convert.ToInt32(_oItemRow.Cells[16].Value.ToString().Trim());
                            //                    DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

                            //                    if (oDR.Length != 0)
                            //                    {
                            //                        double _UnitPrice = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[3].Value);
                            //                        int _Qty = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[9].Value);
                            //                        double _TotalDiscount = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[28].Value);
                            //                        //_DisAmount = _DisAmount + (_UnitPrice * _Qty);
                            //                        if (nIsApplicableOnOfferPrice == (int)Dictionary.YesOrNoStatus.YES)
                            //                        {
                            //                            _DiscountEligiblePrice = _DiscountEligiblePrice + (_UnitPrice - _TotalDiscount);
                            //                        }
                            //                        else
                            //                        {
                            //                            _DiscountEligiblePrice = _DiscountEligiblePrice + _UnitPrice;
                            //                        }
                            //                    }
                            //                }
                            //            }
                            //            _DisAmount = _DiscountEligiblePrice * oCPE.Discount / 100;

                            //        }

                            //        foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                            //        {
                            //            if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                            //            {
                            //                int nProductID = Convert.ToInt32(_oItemRow.Cells[16].Value.ToString().Trim());
                            //                DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

                            //                if (oDR.Length != 0)
                            //                {
                            //                    double _DiscountRatio = Convert.ToDouble(oDR[0]["DiscountRatio"]);
                            //                    _DisAmt = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[25].Value);

                            //                    double _SingleDiscount = 0;

                            //                    if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.FlatAmount)
                            //                    {
                            //                        dgvLineItem.Rows[_oItemRow.Index].Cells[25].Value = _DisAmt + (_DiscountRatio * oCPE.Discount / 100) * nMultiplyTimes;
                            //                        _SingleDiscount = (_DiscountRatio * oCPE.Discount / 100) * nMultiplyTimes;
                            //                    }
                            //                    else
                            //                    {
                            //                        dgvLineItem.Rows[_oItemRow.Index].Cells[25].Value = Math.Round(_DisAmt + (_DiscountRatio * _DisAmount / 100) * nMultiplyTimes, 0);
                            //                        _SingleDiscount = Math.Round((_DiscountRatio * _DisAmount / 100) * nMultiplyTimes, 0);
                            //                    }

                            //                    #region Promo MAP
                            //                    //SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value), -1, 0, nProductID, -1, -1);
                            //                    SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, _SingleDiscount, -1, 0, nProductID, -1, -1);
                            //                    #endregion 

                            //                    dgvLineItem.Rows[_oItemRow.Index].Cells[28].Value = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[11].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[12].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[13].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[25].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[27].Value);
                            //                }
                            //            }
                            //        }

                            //    }
                            //    else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.EMI)
                            //    {
                            //        foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                            //        {
                            //            if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                            //            {
                            //                int nProductID = Convert.ToInt32(_oItemRow.Cells[16].Value.ToString().Trim());
                            //                DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

                            //                if (oDR.Length != 0)
                            //                {
                            //                    dgvLineItem.Rows[_oItemRow.Index].Cells[30].Value = oCPE.EMITenureID;

                            //                    #region Promo MAP
                            //                    SetPromoMap(-1, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, 0, -1, 0, Convert.ToInt32(_oItemRow.Cells[16].Value.ToString().Trim()), Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[30].Value), -1);
                            //                    #endregion 

                            //                }
                            //            }
                            //        }
                            //    }
                            //}
                        }
                        else if (sPromoType == "TP")
                        {
                            //TP
                            _oConsumerPromotionEngines.GetPromoTPOfferDetailSecondary(nPromoID, nSlabID, nOfferID);
                            foreach (ConsumerPromotionEngine oCPE in _oConsumerPromotionEngines)
                            {
                                double _DisAmount = 0;
                                //if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
                                //{
                                foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                                {
                                    if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                    {
                                        //int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
                                        ProductDetail oDetails = new ProductDetail();
                                        oDetails.ProductID = Convert.ToInt32(_oItemRow.Cells[16].Value.ToString().Trim());
                                        oDetails.Refresh();

                                        int nMAGID = oDetails.MAGID;
                                        int nBrandID = oDetails.BrandID;


                                        double _Discount = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value);
                                        double _TotalDiscount = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[28].Value);
                                        DataRow[] oDR = _oDSPromoTPForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductGroupID='" + nMAGID + "' and BrandID='" + nBrandID + "' ");

                                        if (oDR.Length != 0)
                                        {
                                            double _UnitPrice = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[3].Value);
                                            int _Qty = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[9].Value);
                                            if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
                                            {
                                                double _SingleTPDiscountParcent = 0;
                                                if (nIsApplicableOnOfferPrice == (int)Dictionary.YesOrNoStatus.YES)
                                                {
                                                    dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value = _Discount + (((_UnitPrice * _Qty) - _TotalDiscount) * oCPE.Discount / 100);
                                                    _SingleTPDiscountParcent = (((_UnitPrice * _Qty) - _TotalDiscount) * oCPE.Discount / 100);
                                                }
                                                else
                                                {
                                                    dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value = _Discount + ((_UnitPrice * _Qty) * oCPE.Discount / 100);
                                                    _SingleTPDiscountParcent = ((_UnitPrice * _Qty) * oCPE.Discount / 100);


                                                }
                                                #region Promo MAP
                                                
                                                //SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, _SingleTPDiscountParcent, -1, 0, Convert.ToInt32(_oItemRow.Cells[16].Value.ToString().Trim()), -1, -1);
                                                #endregion
                                            }
                                            else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.FlatAmount)
                                            {
                                                double _SingleTPDiscount = 0;

                                                dgvLineItem.Rows[_oItemRow.Index].Cells[26].Value = _Discount + (_Qty * oCPE.Discount);
                                                _SingleTPDiscount = (_Qty * oCPE.Discount);

                                                #region Promo MAP
                                                
                                                //SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, _SingleTPDiscount, -1, 0, Convert.ToInt32(_oItemRow.Cells[16].Value.ToString().Trim()), -1, -1);
                                                #endregion
                                            }
                                            else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Product)
                                            {
                                                //New added
                                                Product oProduct = new Product();
                                                oProduct.ProductID = oCPE.OfferProductID;
                                                oProduct.RefreshByID();

                                                DataGridViewRow oRow = new DataGridViewRow();
                                                oRow.CreateCells(dvgFreeProduct);

                                                oRow.Cells[0].Value = sPromotionNo;
                                                oRow.Cells[1].Value = oProduct.ProductCode;
                                                oRow.Cells[2].Value = oProduct.ProductName;
                                                oRow.Cells[3].Value = oCPE.OfferQty * nMultiplyTimes;
                                                oRow.Cells[4].Value = oProduct.ProductID;
                                                oRow.Cells[5].Value = oCPE.ConsumerPromoID;
                                                oRow.Cells[6].Value = oCPE.SlabID;
                                                oRow.Cells[7].Value = oCPE.OfferID;
                                                oRow.Cells[8].Value = oProduct.IsBarcodeItem;
                                                oRow.Cells[9].Value = oProduct.CostPrice;
                                                oRow.Cells[10].Value = "TP";

                                                

                                                dvgFreeProduct.Rows.Add(oRow);

                                                #region Promo MAP
                                                //SetPromoMap(-1, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, 0, oProduct.ProductID, Convert.ToInt32(oRow.Cells[3].Value), -1, -1, 0);
                                                #endregion

                                                break;
                                            }


                                        }
                                    }
                                }



                            }
                        }

                    }
                }


                SumNetPayable();
                


                #region Promo MAP DP/TP/PW
                //foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                //{
                //    if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                //    {
                //        double AdjustedDPAmount = 0;
                //        double AdjustedTPAmount = 0;
                //        double AdjustedPWAmount = 0;
                //        int _ConfirmQty = 0;
                //        try
                //        {
                //            AdjustedDPAmount = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[17].Value);
                //        }
                //        catch
                //        {
                //            AdjustedDPAmount = 0;
                //        }
                //        try
                //        {
                //            AdjustedTPAmount = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[18].Value);
                //        }
                //        catch
                //        {
                //            AdjustedTPAmount = 0;

                //        }
                //        try
                //        {
                //            AdjustedPWAmount = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[19].Value);
                //        }
                //        catch
                //        {
                //            AdjustedPWAmount = 0;
                //        }
                //        try
                //        {
                //            _ConfirmQty = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[9].Value);

                //        }
                //        catch
                //        {
                //            _ConfirmQty = 0;
                //        }
                //        if (AdjustedDPAmount + AdjustedTPAmount + AdjustedPWAmount > 0)
                //        {
                //            SetPromoMap(58, -1, -1, -1, "t_ProvisionParam", 1, (AdjustedDPAmount + AdjustedTPAmount + AdjustedPWAmount) * _ConfirmQty, -1, 0, Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[16].Value), -1, -1);
                //        }

                //    }
                //}
                #endregion
                
            }
        }
        private void btnApplyPromotion_Click(object sender, EventArgs e)
        {
            ApplyPromotion();
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                if (_nUIControl == 2)
                {
                    //btnSave.Enabled = false;
                    cmbPromotionType.Enabled = true;
                }
                else
                {
                    //btnSave.Enabled = true;

                }
                if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
                {
                    MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _oCustomerDetail = new CustomerDetail();
                _oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                _oCustomerDetail.refresh();
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    _IsApplyPromotion = false;
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
                        oRow.Cells[3].Value = oForm._oProductDetail.NSP.ToString();
                    else oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
                    oRow.Cells[16].Value = oForm._oProductDetail.ProductID;

                    _oWUIUtility = new WUIUtility();
                    _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, 68, oForm._oProductDetail.ProductID);

                    oRow.Cells[7].Value = _oWUIUtility.CurrentStock.ToString();

                    if (_nUIControl == 1)
                    {
                        oRow.Cells[9].Value = 0;
                        dgvLineItem.Rows[e.RowIndex].Cells[9].ReadOnly = true;
                    }
                    else
                    {
                        oRow.Cells[8].Value = 0;
                        dgvLineItem.Rows[e.RowIndex].Cells[8].ReadOnly = true;
                    }
                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvLineItem.Rows.Add(oRow);
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
                        }
                    }
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

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {


            int nIndex = 0;
            if (_nUIControl == 1)
            {
                nIndex = 8;
            }
            else
            {
                nIndex = 9;
            }
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
                {
                    MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();
                    if (_nUIControl == 2)
                    {
                        //btnSave.Enabled = false;
                        cmbPromotionType.Enabled = true;
                    }
                    else
                    {
                        //btnSave.Enabled = true;
                    }

                    if (_oProductDetail.Flag != false)
                    {
                        _IsApplyPromotion = false;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 16].Value = (_oProductDetail.ProductID).ToString();

                        _oCustomerDetail = new CustomerDetail();
                        _oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                        _oCustomerDetail.refresh();
                        if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.NSP.ToString();
                        }
                        else
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();
                        }

                        _oWUIUtility = new WUIUtility();
                        _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, 68, _oProductDetail.ProductID);

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = _oWUIUtility.CurrentStock.ToString();

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                        if (nIndex == 8)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = 0;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].ReadOnly = true;

                        }
                        else if (nIndex == 9)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].ReadOnly = true;
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
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (nColumnIndex == nIndex)
            {
                if (_nUIControl == 2)
                {
                   // btnSave.Enabled = false;
                    cmbPromotionType.Enabled = true;
                }
                else
                {
                   // btnSave.Enabled = true;
                }
                long nRem = 0;
                long nQuotient = 0;
                if (dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "" && _oWUIUtility.UOMConversionFactor != 0)
                {
                    _IsApplyPromotion = false;
                    int nProductID = Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[16].Value);
                    WUIUtility oWUIUtility = new WUIUtility();
                    oWUIUtility.GetMOUByProductID(nProductID);
                    nQuotient = Math.DivRem(Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()), oWUIUtility.UOMConversionFactor, out nRem);
                    if (nRem > 0)
                    {
                        MessageBox.Show("Breaking MOQ. Please Enter Full MOQ.MOQ for the " + dgvLineItem.Rows[nRowIndex].Cells[2].Value.ToString() + "  is, " + _oWUIUtility.UOMConversionFactor.ToString());
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[10].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[11].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[12].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[13].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[14].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[15].Value = 0;

                        dgvLineItem.Rows[nRowIndex].Cells[32].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[33].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[34].Value = 0;



                        return;
                    }
                    else
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[15].Value = nQuotient.ToString();
                    }
                    oProvisionParam = new ProvisionParam();
                    if (_oProductDetail == null)
                    {
                        _oProductDetail = new ProductDetail();
                        oProvisionParam.GetProvisionParam(Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[16].Value), _oCustomerDetail.CustomerTypeID);
                        _oProductDetail = null;
                    }
                    else
                    {
                        oProvisionParam.GetProvisionParam(_oProductDetail.ProductID, _oCustomerDetail.CustomerTypeID);
                    }
                    dgvLineItem.Rows[nRowIndex].Cells[11].Value = Math.Round(Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.SC) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString());
                    dgvLineItem.Rows[nRowIndex].Cells[12].Value = Math.Round(Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.TP) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString());
                    dgvLineItem.Rows[nRowIndex].Cells[13].Value = Math.Round(Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.PW) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString());

                    double TotalProvision = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[11].Value.ToString())) + (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[12].Value.ToString())) + (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[13].Value.ToString()));
                    dgvLineItem.Rows[nRowIndex].Cells[10].Value = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString()));
                    dgvLineItem.Rows[nRowIndex].Cells[14].Value = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString())) - TotalProvision;

                    dgvLineItem.Rows[nRowIndex].Cells[17].Value = Math.Round(Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.SC);
                    dgvLineItem.Rows[nRowIndex].Cells[18].Value = Math.Round(Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.TP);
                    dgvLineItem.Rows[nRowIndex].Cells[19].Value = Math.Round(Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.PW);


                    dgvLineItem.Rows[nRowIndex].Cells[32].Value = oProvisionParam.IsApplicableOnOfferPriceSC;
                    dgvLineItem.Rows[nRowIndex].Cells[33].Value = oProvisionParam.IsApplicableOnOfferPriceTP;
                    dgvLineItem.Rows[nRowIndex].Cells[34].Value = oProvisionParam.IsApplicableOnOfferPricePW;

                }
              //  cmbWarehouse.Enabled = false;
                ctlCustomer1.Enabled = false;
                SumNetPayable();
                //GetTotalAmount();
            }

        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void frmPromoTPCalculatorSecondary_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh((int)Dictionary.YesOrNoStatus.YES);
            cmbPromotionType.Items.Add("<Select Promotion Type>");
            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                cmbPromotionType.Items.Add(oSalesPromotionType.SalesPromotionTypeName);
            }
            if (_oSalesPromotionTypes.Count > 0)
                cmbPromotionType.SelectedIndex = 0;
        }

        private void dsvPromotion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string sPromoNo = dsvPromotion.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sPromoName = dsvPromotion.Rows[e.RowIndex].Cells[1].Value.ToString();
                string sPromoType = dsvPromotion.Rows[e.RowIndex].Cells[2].Value.ToString();
                string sPromoSlab = dsvPromotion.Rows[e.RowIndex].Cells[3].Value.ToString();


                int nOfferID = int.Parse(dsvPromotion.Rows[e.RowIndex].Cells[6].Value.ToString());
                int nSlabID = int.Parse(dsvPromotion.Rows[e.RowIndex].Cells[7].Value.ToString());
                int nPromoID = int.Parse(dsvPromotion.Rows[e.RowIndex].Cells[8].Value.ToString());

                frmPromotionalOffer oForm = new frmPromotionalOffer(sPromoNo, sPromoName, "TPSecondary", sPromoSlab, nOfferID, nSlabID, nPromoID);
                oForm.ShowDialog();
                if (oForm._Flag)
                {
                    dsvPromotion.Rows[e.RowIndex].Cells[4].Value = oForm.sOfferDescription;
                    dsvPromotion.Rows[e.RowIndex].Cells[6].Value = oForm.nOfferID;
                    //btnSave.Enabled = false;
                }

            }
        }
    }
}
