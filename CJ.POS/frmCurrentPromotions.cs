using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Promotion;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.POS
{
    public partial class frmCurrentPromotions : Form
    {

        ConsumerPromotions oConsumerPromotions;
        SPromotions oSPromotions;

        DSPromotion oDSPromoProductFor;
        DSPromotion oDSPromoOffer;
        DSPromotion oDSPromotion;
        DSPromotion oDSPromoSlab;
        ProductDetail _oProductDetail;
        public frmCurrentPromotions()
        {
            InitializeComponent();
        }

        private void frmCurrentPromotions_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            oConsumerPromotions = new ConsumerPromotions();
            this.Cursor = Cursors.WaitCursor;

            oConsumerPromotions.GetCurrentPromotionList(txtPromoNo.Text.Trim(), txtPromoName.Text.Trim());
            lvwCurrentPromotionList.Items.Clear();

            foreach (ConsumerPromotion oConsumerPromotion in oConsumerPromotions)
            {
                ListViewItem lstItem = lvwCurrentPromotionList.Items.Add(oConsumerPromotion.ConsumerPromoNo.ToString());
                lstItem.SubItems.Add(oConsumerPromotion.ConsumerPromoName);
                lstItem.SubItems.Add((Convert.ToDateTime(oConsumerPromotion.FromDate)).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add((Convert.ToDateTime(oConsumerPromotion.ToDate)).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oConsumerPromotion.IsActive));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesPromStatus), oConsumerPromotion.Status));
                lstItem.SubItems.Add(oConsumerPromotion.PromotionType.ToString());

                lstItem.Tag = oConsumerPromotion;
            }
            this.Cursor = Cursors.Default;
            SetListViewRowColour();
            this.Text = "Trade Promotion List [" + oConsumerPromotions.Count + "]";
        }

        private void SetListViewRowColour()
        {
            if (lvwCurrentPromotionList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCurrentPromotionList.Items)
                {
                    if (oItem.SubItems[5].Text == "Create")
                    {
                        oItem.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        oItem.BackColor = Color.White;
                    }
                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (lvwCurrentPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            if (lvwCurrentPromotionList.SelectedItems[0].SubItems[6].Text == "TP")
            {
                PrintPromoTP();
            }
            else
            {
                PrintPromoCP();
            }            

            this.Cursor = Cursors.Default;
        }

        public void PrintPromoCP()
        {

            if (lvwCurrentPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sPromotionType = "";
            string sChannel = "";
            string sWarehouse = "";
            string sPromotionForProduct = "";
            string sRatio = "";
            oDSPromoProductFor = new DSPromotion();
            oDSPromotion = new DSPromotion();
            oDSPromoOffer = new DSPromotion();
            oDSPromoSlab = new DSPromotion();

            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwCurrentPromotionList.SelectedItems[0].Tag;
            oConsumerPromotion.GetPromoInfoForReport(oConsumerPromotion.ConsumerPromoID);
            foreach (ConsumerPromotionSlab oPromoProductFor in oConsumerPromotion)
            {
                DSPromotion.PromoProductForRow oPromoProductForRow = oDSPromoProductFor.PromoProductFor.NewPromoProductForRow();

                oPromoProductForRow.ProductName = oPromoProductFor.ProductName;
                oPromoProductForRow.TargetQty = oPromoProductFor.TargetQty;
                oPromoProductForRow.RegularSalesQty = oPromoProductFor.RegularSalesQty;
                oPromoProductForRow.DiscountRatio = oPromoProductFor.DiscountRatio;

                oDSPromoProductFor.PromoProductFor.AddPromoProductForRow(oPromoProductForRow);
                oDSPromoProductFor.AcceptChanges();
            }

            ConsumerPromotions oGetSlab = new ConsumerPromotions();
            oGetSlab.GetSlabByPromoID(oConsumerPromotion.ConsumerPromoID, "t_PromoCP");

            foreach (ConsumerPromotionSlab oConsumerPromotionSlab in oGetSlab)
            {
                ConsumerPromotionSlabRatios oRations = new ConsumerPromotionSlabRatios();
                oRations.Refresh(oConsumerPromotion.ConsumerPromoID, oConsumerPromotionSlab.SlabID);
                foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oRations)
                {
                    DSPromotion.PromoSlabRatioRow oPromoSlabRow = oDSPromoSlab.PromoSlabRatio.NewPromoSlabRatioRow();
                    oPromoSlabRow.SlabNo = oConsumerPromotionSlabRatio.SlabName;
                    oPromoSlabRow.SlabDetail = oConsumerPromotionSlabRatio.ProductName;
                    oPromoSlabRow.Qty = oConsumerPromotionSlabRatio.Qty;
                    oDSPromoSlab.PromoSlabRatio.AddPromoSlabRatioRow(oPromoSlabRow);
                    oDSPromoSlab.AcceptChanges();
                }


                //Offer
                ConsumerPromotionOffers oOffers = new ConsumerPromotionOffers();
                oOffers.Refresh(oConsumerPromotion.ConsumerPromoID, oConsumerPromotionSlab.SlabID, "t_PromoCP");
                foreach (ConsumerPromotionOffer oConsumerPromotionOffer in oOffers)
                {
                    DSPromotion.PromoOfferRow oPromoOfferRow = oDSPromoOffer.PromoOffer.NewPromoOfferRow();
                    oPromoOfferRow.OfferName = oConsumerPromotionOffer.OfferName;
                    oPromoOfferRow.Description = oConsumerPromotionOffer.Description;
                    oPromoOfferRow.SlabName = oConsumerPromotionSlab.SlabName;
                    oDSPromoOffer.PromoOffer.AddPromoOfferRow(oPromoOfferRow);
                    oDSPromoOffer.AcceptChanges();
                }

            }


            oDSPromotion.Merge(oDSPromoProductFor);
            oDSPromotion.Merge(oDSPromoSlab);
            oDSPromotion.Merge(oDSPromoOffer);
            oDSPromotion.AcceptChanges();

            rptConsumerPromotion doc;
            doc = new rptConsumerPromotion();
            doc.SetDataSource(oDSPromotion);

            doc.SetParameterValue("PromotionNo", oConsumerPromotion.ConsumerPromoNo);
            doc.SetParameterValue("Description", oConsumerPromotion.ConsumerPromoName);
            doc.SetParameterValue("StartDate", oConsumerPromotion.FromDate);
            doc.SetParameterValue("EndDate", oConsumerPromotion.ToDate);
            if (oConsumerPromotion.IsApplicableOnOfferPrice == (int)Dictionary.YesOrNoStatus.YES)
            {
                doc.SetParameterValue("ApplicableOn", "Offer Price");
            }
            else
            {
                doc.SetParameterValue("ApplicableOn", "MRP");
            }
            ///ConsumerPromotionType
            SalesPromotionTypes oSalesPromotionTypes = new SalesPromotionTypes();
            oSalesPromotionTypes.GetPromoTypePromoIDWise(oConsumerPromotion.ConsumerPromoID);
            foreach (SalesPromotionType oSalesPromotionType in oSalesPromotionTypes)
            {
                if (sPromotionType == "")
                {
                    sPromotionType = oSalesPromotionType.SalesPromotionTypeName;
                }
                else sPromotionType = sPromotionType + "," + oSalesPromotionType.SalesPromotionTypeName;
            }
            doc.SetParameterValue("ConsumerPromotionType", sPromotionType);

            ///ConsumerPromotionChannel
            SPChannels oSPChannels = new SPChannels();
            oSPChannels.GetPromoChannel(oConsumerPromotion.ConsumerPromoID);
            foreach (SPChannel oSPChannel in oSPChannels)
            {
                if (sChannel == "")
                {
                    sChannel = Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
                }
                else sChannel = sChannel + "," + Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
            }
            doc.SetParameterValue("Channel", sChannel);

            //Warehouse
            SPWarehouses oSPWarehouses = new SPWarehouses();
            oSPWarehouses.GetPromoWarehouse(oConsumerPromotion.ConsumerPromoID);
            foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
            {
                if (sWarehouse == "")
                    sWarehouse = oSPWarehouse.WarehouseName;
                else sWarehouse = sWarehouse + "," + oSPWarehouse.WarehouseName;
            }

            doc.SetParameterValue("Outlets", sWarehouse);
            TELLib oTELLib = new TELLib();
            doc.SetParameterValue("ContributionAmount", oTELLib.TakaFormat(Convert.ToDouble(oConsumerPromotion.ContributionAmount)));
            doc.SetParameterValue("PrintUser", Utility.Username.ToString());
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        public void PrintPromoTP()
        {
            if (lvwCurrentPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sPromotionType = "";
            string sChannel = "";
            string sWarehouse = "";
            string sPromotionForProduct = "";
            string sRatio = "";
            string sInvoiceQty = "";
            oDSPromoProductFor = new DSPromotion();
            oDSPromotion = new DSPromotion();
            oDSPromoOffer = new DSPromotion();
            oDSPromoSlab = new DSPromotion();

            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwCurrentPromotionList.SelectedItems[0].Tag;
            oConsumerPromotion.GetTPInfoForReport(oConsumerPromotion.ConsumerPromoID);
            foreach (ConsumerPromotionSlab oPromoProductFor in oConsumerPromotion)
            {
                DSPromotion.PromoProductForRow oPromoProductForRow = oDSPromoProductFor.PromoProductFor.NewPromoProductForRow();

                oPromoProductForRow.ProductGroupName = oPromoProductFor.ProductGroupName;
                oPromoProductForRow.BrandName = oPromoProductFor.BrandName;
                oPromoProductForRow.TargetQty = oPromoProductFor.TargetQty;
                oPromoProductForRow.RegularSalesQty = oPromoProductFor.RegularSalesQty;
                oPromoProductForRow.DiscountRatio = oPromoProductFor.DiscountRatio;

                oDSPromoProductFor.PromoProductFor.AddPromoProductForRow(oPromoProductForRow);
                oDSPromoProductFor.AcceptChanges();
            }

            ConsumerPromotions oGetSlab = new ConsumerPromotions();
            oGetSlab.GetSlabByPromoID(oConsumerPromotion.ConsumerPromoID, "t_PromoTP");

            foreach (ConsumerPromotionSlab oConsumerPromotionSlab in oGetSlab)
            {
                ConsumerPromotionSlabRatios oRations = new ConsumerPromotionSlabRatios();
                oRations.RefreshTPRatio(oConsumerPromotion.ConsumerPromoID, oConsumerPromotionSlab.SlabID);
                foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oRations)
                {
                    DSPromotion.PromoSlabRatioRow oPromoSlabRow = oDSPromoSlab.PromoSlabRatio.NewPromoSlabRatioRow();
                    oPromoSlabRow.SlabNo = oConsumerPromotionSlabRatio.SlabName;
                    oPromoSlabRow.ProductGroupName = oConsumerPromotionSlabRatio.ProductGroupName;
                    oPromoSlabRow.BrandName = oConsumerPromotionSlabRatio.BrandName;
                    oPromoSlabRow.Qty = oConsumerPromotionSlabRatio.Qty;
                    oDSPromoSlab.PromoSlabRatio.AddPromoSlabRatioRow(oPromoSlabRow);
                    oDSPromoSlab.AcceptChanges();
                }


                //Offer
                ConsumerPromotionOffers oOffers = new ConsumerPromotionOffers();
                oOffers.Refresh(oConsumerPromotion.ConsumerPromoID, oConsumerPromotionSlab.SlabID, "t_PromoTP");
                foreach (ConsumerPromotionOffer oConsumerPromotionOffer in oOffers)
                {
                    DSPromotion.PromoOfferRow oPromoOfferRow = oDSPromoOffer.PromoOffer.NewPromoOfferRow();
                    oPromoOfferRow.OfferName = oConsumerPromotionOffer.OfferName;
                    oPromoOfferRow.Description = oConsumerPromotionOffer.Description;
                    oPromoOfferRow.SlabName = oConsumerPromotionSlab.SlabName;
                    oDSPromoOffer.PromoOffer.AddPromoOfferRow(oPromoOfferRow);
                    oDSPromoOffer.AcceptChanges();
                }

            }


            oDSPromotion.Merge(oDSPromoProductFor);
            oDSPromotion.Merge(oDSPromoSlab);
            oDSPromotion.Merge(oDSPromoOffer);
            oDSPromotion.AcceptChanges();

            rptTradePromotion doc;
            doc = new rptTradePromotion();
            doc.SetDataSource(oDSPromotion);

            doc.SetParameterValue("PromotionNo", oConsumerPromotion.ConsumerPromoNo);
            doc.SetParameterValue("Description", oConsumerPromotion.ConsumerPromoName);
            doc.SetParameterValue("StartDate", oConsumerPromotion.FromDate);
            doc.SetParameterValue("EndDate", oConsumerPromotion.ToDate);
            if (oConsumerPromotion.IsApplicableOnOfferPrice == (int)Dictionary.YesOrNoStatus.YES)
            {
                doc.SetParameterValue("ApplicableOn", "Offer Price");
            }
            else
            {
                doc.SetParameterValue("ApplicableOn", "MRP");
            }

            ///ConsumerPromotionType
            SalesPromotionTypes oSalesPromotionTypes = new SalesPromotionTypes();
            oSalesPromotionTypes.GetTPTypePromoIDWise(oConsumerPromotion.ConsumerPromoID);
            foreach (SalesPromotionType oSalesPromotionType in oSalesPromotionTypes)
            {
                if (sPromotionType == "")
                {
                    sPromotionType = oSalesPromotionType.SalesPromotionTypeName;
                }
                else sPromotionType = sPromotionType + "," + oSalesPromotionType.SalesPromotionTypeName;
            }
            doc.SetParameterValue("ConsumerPromotionType", sPromotionType);

            ///ConsumerPromotionChannel
            SPChannels oSPChannels = new SPChannels();
            oSPChannels.GetTPChannel(oConsumerPromotion.ConsumerPromoID);
            foreach (SPChannel oSPChannel in oSPChannels)
            {
                if (sChannel == "")
                {
                    sChannel = Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
                }
                else sChannel = sChannel + "," + Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
            }
            doc.SetParameterValue("Channel", sChannel);

            //Warehouse
            SPWarehouses oSPWarehouses = new SPWarehouses();
            oSPWarehouses.GetTPWarehouse(oConsumerPromotion.ConsumerPromoID);
            foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
            {
                if (sWarehouse == "")
                    sWarehouse = oSPWarehouse.WarehouseName;
                else sWarehouse = sWarehouse + "," + oSPWarehouse.WarehouseName;
            }
            //InvoiceQty
            ConsumerPromotionSlabRatios oSlabInvoiceQty = new ConsumerPromotionSlabRatios();
            oSlabInvoiceQty.GetSalbInvoiceQty(oConsumerPromotion.ConsumerPromoID);
            foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oSlabInvoiceQty)
            {
                if (sInvoiceQty == "")
                    sInvoiceQty = oConsumerPromotionSlabRatio.SlabName;
                else sInvoiceQty = sInvoiceQty + "|" + oConsumerPromotionSlabRatio.SlabName;
            }
            doc.SetParameterValue("InvoiceQty", sInvoiceQty);
            doc.SetParameterValue("Outlets", sWarehouse);
            TELLib oTELLib = new TELLib();
            doc.SetParameterValue("ContributionAmount", oTELLib.TakaFormat(Convert.ToDouble(oConsumerPromotion.ContributionAmount)));
            doc.SetParameterValue("PrintUser", Utility.Username.ToString());
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
