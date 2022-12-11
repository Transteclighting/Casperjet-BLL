using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Promotion;
using CJ.Win.Promotion;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Win.Promotion
{
    public partial class frmPromoTPSecondarys : Form
    {
        ConsumerPromotions oConsumerPromotions;

        DSPromotion oDSPromoProductFor;
        DSPromotion oDSPromoOffer;
        DSPromotion oDSPromotion;
        DSPromotion oDSPromoSlab;

        public frmPromoTPSecondarys()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombo()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //IsActive
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsActive)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.IsActive), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;


            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesPromStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SalesPromStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void SetListViewRowColour()
        {
            if (lvwPromotionList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwPromotionList.Items)
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

        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            oConsumerPromotions = new ConsumerPromotions();
            this.Cursor = Cursors.WaitCursor;

            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            oConsumerPromotions.GetPromoTPListSecoundary(dtFromDate.Value.Date, dtToDate.Value.Date, nIsActive, nStatus, txtPromoNo.Text.Trim(), txtPromoName.Text.Trim());
            lvwPromotionList.Items.Clear();

            foreach (ConsumerPromotion oConsumerPromotion in oConsumerPromotions)
            {
                ListViewItem lstItem = lvwPromotionList.Items.Add(oConsumerPromotion.ConsumerPromoNo.ToString());
                lstItem.SubItems.Add(oConsumerPromotion.ConsumerPromoName);
                lstItem.SubItems.Add((Convert.ToDateTime(oConsumerPromotion.FromDate)).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add((Convert.ToDateTime(oConsumerPromotion.ToDate)).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oConsumerPromotion.IsActive));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesPromStatus), oConsumerPromotion.Status));

                lstItem.Tag = oConsumerPromotion;
            }
            this.Cursor = Cursors.Default;
            SetListViewRowColour();
            this.Text = "Trade Promotion (Secondary) [" + oConsumerPromotions.Count + "]";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPromoTPSecondary oFrom = new frmPromoTPSecondary();
            oFrom.ShowDialog();
            if (oFrom._IsTrue == true)
            {
                LoadData();
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PrintPromo();
            this.Cursor = Cursors.Default;
        }
        public void PrintPromo()
        {

            if (lvwPromotionList.SelectedItems.Count == 0)
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

            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwPromotionList.SelectedItems[0].Tag;
            oConsumerPromotion.GetTPInfoForReportSecoundary(oConsumerPromotion.ConsumerPromoID);
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
            oGetSlab.GetSlabByPromoID(oConsumerPromotion.ConsumerPromoID, "t_PromoTPSecondary");

            foreach (ConsumerPromotionSlab oConsumerPromotionSlab in oGetSlab)
            {
                ConsumerPromotionSlabRatios oRations = new ConsumerPromotionSlabRatios();
                oRations.RefreshTPRatioSecondary(oConsumerPromotion.ConsumerPromoID, oConsumerPromotionSlab.SlabID);
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
                oOffers.Refresh(oConsumerPromotion.ConsumerPromoID, oConsumerPromotionSlab.SlabID, "t_PromoTPSecondary");
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
            oSalesPromotionTypes.GetTPTypePromoIDWiseSecondary(oConsumerPromotion.ConsumerPromoID);
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
            /// 

            //SPChannels oSPChannels = new SPChannels();
            //oSPChannels.GetTPChannel(oConsumerPromotion.ConsumerPromoID);
            //foreach (SPChannel oSPChannel in oSPChannels)
            //{
            //    if (sChannel == "")
            //    {
            //        sChannel = Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
            //    }
            //    else sChannel = sChannel + "," + Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
            //}


            ///New 
            SPChannels oSPChannels = new SPChannels();
            oSPChannels.GetPromoChannelTPSecondary(oConsumerPromotion.ConsumerPromoID);
            foreach (SPChannel oSPChannel in oSPChannels)
            {
                CustomerType oCustomeType = new CustomerType();
                if (oSPChannel.CustType != "")
                {
                    oCustomeType.RefreshCustTypeDescription(oSPChannel.CustType);
                }
                if (sChannel == "")
                {
                    sChannel = Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
                    if (oSPChannel.CustType != "")
                    {
                        sChannel = sChannel + "(" + oCustomeType.CustTypeDescription + ")";
                    }

                }
                else if (oSPChannel.CustType == "")
                {
                    sChannel = sChannel + "," + Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
                }
                else
                {
                    sChannel = sChannel + "," + Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID) + "(" + oCustomeType.CustTypeDescription + ")";
                }


            }

            doc.SetParameterValue("Channel", sChannel);

            ////Warehouse
            //SPWarehouses oSPWarehouses = new SPWarehouses();
            //oSPWarehouses.GetTPWarehouse(oConsumerPromotion.ConsumerPromoID);
            //foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
            //{
            //    if (sWarehouse == "")
            //        sWarehouse = oSPWarehouse.WarehouseName;
            //    else sWarehouse = sWarehouse + "," + oSPWarehouse.WarehouseName;
            //}

            //InvoiceQty
            ConsumerPromotionSlabRatios oSlabInvoiceQty = new ConsumerPromotionSlabRatios();
            oSlabInvoiceQty.GetSalbInvoiceQtySecondary(oConsumerPromotion.ConsumerPromoID);
            foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oSlabInvoiceQty)
            {
                if (sInvoiceQty == "")
                    sInvoiceQty = oConsumerPromotionSlabRatio.SlabName;
                else sInvoiceQty = sInvoiceQty + "," + oConsumerPromotionSlabRatio.SlabName;
            }
            doc.SetParameterValue("InvoiceQty", sInvoiceQty);
            doc.SetParameterValue("Outlets", "");
            TELLib oTELLib = new TELLib();
            doc.SetParameterValue("ContributionAmount", oTELLib.TakaFormat(Convert.ToDouble(oConsumerPromotion.ContributionAmount)));
            doc.SetParameterValue("PrintUser", Utility.Username.ToString());
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
        private void frmPromoTPs_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadData();
        }

        private void btnEditCentral_Click(object sender, EventArgs e)
        {
            //if (lvwPromotionList.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            ////if (lvwPromotionList.SelectedItems[0].SubItems[5].Text == "Approved")
            ////{
            ////    MessageBox.Show("Can't edit as it already approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////    return;
            ////}

            //ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwPromotionList.SelectedItems[0].Tag;
            //frmEditPromotion ofrmEditPromotion = new frmEditPromotion();
            //oConsumerPromotion.PromotionTypeName = "TP";
            //ofrmEditPromotion.ShowDialog(oConsumerPromotion);
            //if (ofrmEditPromotion._bActionSave)
            //    LoadData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwPromotionList.SelectedItems[0].Tag;
            if (oConsumerPromotion.Status != ((int)Dictionary.SalesPromStatus.Create))
            {
                MessageBox.Show("Only create status be approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult oResult = MessageBox.Show("Are you sure you want to approved : " + oConsumerPromotion.ConsumerPromoNo + " ? ", "Confirm To Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oConsumerPromotion.Status = (int)Dictionary.SalesPromStatus.Approved;
                    oConsumerPromotion.UpdateStatus("t_PromoTPSecondary");

                   
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You have successfully approved the promotion", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            
            
        }


        private void lvwPromotionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPromotionList.SelectedItems.Count == 0)
            {
                return;
            }
            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwPromotionList.SelectedItems[0].Tag;
            try
            {
                if (oConsumerPromotion.IsActive == (int)Dictionary.IsActive.InActive)
                {
                    btnIsActive.Text = "Active";
                }
                else
                {
                    btnIsActive.Text = "InActive";
                }

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (lvwPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwPromotionList.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure to perform this action", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    int IsActive = 1;

                    if (btnIsActive.Text != "Active")
                    {
                        IsActive = 0;
                    }

                    oConsumerPromotion.ChangeIsActiveStatusSecondary(IsActive);
                    
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            frmPromoTPCalculatorSecondary ofrmPromoTPCalculatorSecondary = new frmPromoTPCalculatorSecondary();
            ofrmPromoTPCalculatorSecondary.ShowDialog();

        }
    }
}