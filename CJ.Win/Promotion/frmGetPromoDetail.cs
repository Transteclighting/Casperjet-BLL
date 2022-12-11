using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Promotion;

namespace CJ.Win.Promotion
{
    public partial class frmGetPromoDetail : Form
    {
        int nPromoID = 0;
        public bool _IsTrue = false;
        public frmGetPromoDetail()
        {
            InitializeComponent();
        }
        public void ShowDialog(ConsumerPromotion _oConsumerPromotion)
        {
            this.Tag = _oConsumerPromotion;
            this.Text = "Consumer Promotion Detail";
            nPromoID = _oConsumerPromotion.ConsumerPromoID;
            lblPromoNo.Text = _oConsumerPromotion.ConsumerPromoNo;
            lblPromoName.Text = _oConsumerPromotion.ConsumerPromoName;
            lblFromDate.Text = Convert.ToDateTime(_oConsumerPromotion.FromDate).ToString("dd-MMM-yyyy");
            lblTodate.Text = Convert.ToDateTime(_oConsumerPromotion.ToDate).ToString("dd-MMM-yyyy");
            lblCreateDate.Text = Convert.ToDateTime(_oConsumerPromotion.CreateDate).ToString("dd-MMM-yyyy");
            lblCreateUser.Text = _oConsumerPromotion.CreateUserName;
            lblApprovedUser.Text = _oConsumerPromotion.ApprovedUserName;
            if (_oConsumerPromotion.ApprovedDate != "")
            {
                lblApprovedDate.Text = Convert.ToDateTime(_oConsumerPromotion.ApprovedDate).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblApprovedDate.Text = "";
            }
            lblIsActive.Text = Enum.GetName(typeof(Dictionary.IsActive), _oConsumerPromotion.IsActive);
            lblStatus.Text = Enum.GetName(typeof(Dictionary.SalesPromStatus), _oConsumerPromotion.Status);
            lblRemarks.Text = _oConsumerPromotion.Remarks;

            LoadDataProduct(_oConsumerPromotion.ConsumerPromoID);
            LoadDataSlab(_oConsumerPromotion.ConsumerPromoID);
            ///ConsumerPromotionType
            SalesPromotionTypes oSalesPromotionTypes = new SalesPromotionTypes();
            oSalesPromotionTypes.GetPromoTypePromoIDWise(nPromoID);
            string sPromotionType = "";
            foreach (SalesPromotionType oSalesPromotionType in oSalesPromotionTypes)
            {
                if (sPromotionType == "")
                {
                    sPromotionType = oSalesPromotionType.SalesPromotionTypeName;
                }
                else sPromotionType = sPromotionType + "," + oSalesPromotionType.SalesPromotionTypeName;
            }
            txtPromoType.Text = sPromotionType.ToString();

            ///ConsumerPromotionChannel
            SPChannels oSPChannels = new SPChannels();
            oSPChannels.GetPromoChannel(nPromoID);
            string sChannel = "";
            foreach (SPChannel oSPChannel in oSPChannels)
            {
                if (sChannel == "")
                {
                    sChannel = Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
                }
                else sChannel = sChannel + "," + Enum.GetName(typeof(Dictionary.SalesType), oSPChannel.ChannelID);
            }
            txtSalesType.Text = sChannel.ToString();

            //Warehouse
            SPWarehouses oSPWarehouses = new SPWarehouses();
            oSPWarehouses.GetPromoWarehouse(nPromoID);
            string sWarehouse = "";
            foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
            {
                if (sWarehouse == "")
                    sWarehouse = oSPWarehouse.WarehouseName;
                else sWarehouse = sWarehouse + "," + oSPWarehouse.WarehouseName;
            }
            txtOutlet.Text = sWarehouse.ToString();
            this.ShowDialog();

        }
        private void frmGetPromoDetail_Load(object sender, EventArgs e)
        {

        }

        public void LoadDataProduct(int nPromoID)
        {
            try
            {
                ConsumerPromotionProductFors oConsumerPromotionProductFors = new ConsumerPromotionProductFors();
                oConsumerPromotionProductFors.Refresh(nPromoID);
                lvwProduct.Items.Clear();

                foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
                {
                    ListViewItem lstItem = lvwProduct.Items.Add(oConsumerPromotionProductFor.ProductName.ToString());
                    lstItem.SubItems.Add(oConsumerPromotionProductFor.TGTQty.ToString());
                    lstItem.SubItems.Add(oConsumerPromotionProductFor.RegularSalesQty.ToString());
                    lstItem.SubItems.Add(oConsumerPromotionProductFor.DiscountRatio.ToString());

                    lstItem.Tag = oConsumerPromotionProductFor;
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        public void LoadDataSlab(int nPromoID)
        {
            try
            {
                ConsumerPromotions oConsumerPromotions = new ConsumerPromotions();
                oConsumerPromotions.GetSlabByPromoID(nPromoID, "t_PromoCP");
                lvwSlab.Items.Clear();

                foreach (ConsumerPromotionSlab oConsumerPromotionSlab in oConsumerPromotions)
                {
                    ListViewItem lstItem = lvwSlab.Items.Add(oConsumerPromotionSlab.SlabID.ToString());
                    lstItem.SubItems.Add(oConsumerPromotionSlab.SlabName.ToString());
                    lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oConsumerPromotionSlab.IsActive));

                    lstItem.Tag = oConsumerPromotionSlab;
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void lvwSlab_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSlabRation = "";
            txtSlabRatio.Text = "";
            if (lvwSlab.SelectedItems.Count == 0)
            {
                return;
            }
            ConsumerPromotionSlab oConsumerPromotionSlab = (ConsumerPromotionSlab)lvwSlab.SelectedItems[0].Tag;
            try
            {
                ConsumerPromotionSlabRatios oConsumerPromotionSlabRatios = new ConsumerPromotionSlabRatios();
                oConsumerPromotionSlabRatios.Refresh(nPromoID, oConsumerPromotionSlab.SlabID);
                foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oConsumerPromotionSlabRatios)
                {
                    if (sSlabRation == "")
                    {
                        sSlabRation = oConsumerPromotionSlabRatio.ProductName.ToString() + ' ' + oConsumerPromotionSlabRatio.Qty.ToString() + "Pcs";
                    }
                    else
                    {
                        sSlabRation = sSlabRation + "\n" + oConsumerPromotionSlabRatio.ProductName.ToString() + ' ' + oConsumerPromotionSlabRatio.Qty.ToString() + "Pcs";
                    }
                }
                txtSlabRatio.Text = sSlabRation.ToString();

                //Offer
                ConsumerPromotionOffers oConsumerPromotionOffers = new ConsumerPromotionOffers();
                oConsumerPromotionOffers.Refresh(nPromoID, oConsumerPromotionSlab.SlabID, "t_PromoCP");
                lvwOffer.Items.Clear();

                foreach (ConsumerPromotionOffer oConsumerPromotionOffer in oConsumerPromotionOffers)
                {
                    ListViewItem lstItem = lvwOffer.Items.Add(oConsumerPromotionOffer.OfferID.ToString());
                    lstItem.SubItems.Add(oConsumerPromotionOffer.OfferName.ToString());
                    lstItem.SubItems.Add(oConsumerPromotionOffer.Description.ToString());
                    lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oConsumerPromotionOffer.IsActive));
                    lstItem.Tag = oConsumerPromotionOffer;
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to approved : " + lblPromoNo.Text + " ? ", "Confirm To Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = nPromoID;
                    oConsumerPromotion.Status = (int)Dictionary.SalesPromStatus.Approved;
                    
                    oConsumerPromotion.UpdateStatus("t_PromoCP");
                    SPWarehouses oShowrooms = new SPWarehouses();
                    oShowrooms.GetPromoWarehouse(nPromoID);
                    foreach (SPWarehouse oShowroom in oShowrooms)
                    {
                        CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                        oDataTran.TableName = "t_PromoCP";
                        oDataTran.DataID = Convert.ToInt32(oConsumerPromotion.ConsumerPromoID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    _IsTrue = true;
                    MessageBox.Show("You have successfully approved the promotion", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DBController.Instance.CommitTransaction();
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

