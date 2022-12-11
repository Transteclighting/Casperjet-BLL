using CJ.Class;
using CJ.Class.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Promotion
{
    public partial class frmExchangeOffers : Form
    {
        int listSelectedId;
        int SelectedOfferId;
        Class.Promotion.ExchangeOfferss oExhangeOffers;
        public frmExchangeOffers()
        {
            InitializeComponent();
        }
        private void DataLoadControl()
        {
            oExhangeOffers = new Class.Promotion.ExchangeOfferss();
            lvwExchangeOffers.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oExhangeOffers.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, cmbStatus.SelectedIndex, cmbIsActive.SelectedIndex);
            this.Text = "Exchange Offers " + "[" + oExhangeOffers.Count + "]";
            foreach (Class.Promotion.ExchangeOffers exchangeoffer in oExhangeOffers)
            {
                ListViewItem oItem = lvwExchangeOffers.Items.Add(exchangeoffer.OfferId.ToString());
                oItem.SubItems.Add(exchangeoffer.OfferCode.ToString());
                oItem.SubItems.Add(exchangeoffer.Description.ToString());
                oItem.SubItems.Add(exchangeoffer.FromDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(exchangeoffer.ToDate.ToString("dd-MMM-yyyy"));
                //oItem.SubItems.Add(exchangeoffer.Status.ToString());
                if (exchangeoffer.Status == 1)
                {
                    oItem.BackColor = Color.MistyRose;
                    oItem.SubItems.Add("Create");
                }
                else if (exchangeoffer.Status == 2)
                {
                    oItem.SubItems.Add("Approved");
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(exchangeoffer.IsActive.ToString());
            }
        }

        private void frmExchangeOffers_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            LoadIsActiveCmb();
            LoadOfferStatusCmb();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddExchangeOffer ofrmAddExchangeOffer = new frmAddExchangeOffer();
            ofrmAddExchangeOffer.ShowDialog();
            DataLoadControl();

        }

        private void lvwExchangeOffers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwExchangeOffers.SelectedItems.Count > 0)
            {
                int intselectedindex = lvwExchangeOffers.Items.IndexOf(lvwExchangeOffers.SelectedItems[0]);
                if (intselectedindex >= 0)
                {
                    listSelectedId = Convert.ToInt32(lvwExchangeOffers.Items[intselectedindex].Text);
                    int index = oExhangeOffers.GetIndex(listSelectedId);
                    SelectedOfferId = oExhangeOffers[index].OfferId;
                    if (oExhangeOffers[index].Status == 2)
                    {
                        btnIsApproved.Enabled = false;
                    }
                    else
                    {
                        btnIsApproved.Enabled = true;
                    }
                    if (oExhangeOffers[index].IsActive)
                    {
                        btnActive.Enabled = true;
                    }
                    else
                    {
                        btnActive.Enabled = false;
                        btnIsApproved.Enabled = false;
                    }

                }
            }
            else
            {
                return;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIsApproved_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Are you Sure?", "Approve Exchange Offer", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                DBController.Instance.BeginNewTransaction();
                //approve the data
                int index = oExhangeOffers.GetIndex(listSelectedId);
                int offerId = oExhangeOffers[index].OfferId;
                oExhangeOffers[index].EditStatus(offerId, (int)Dictionary.ExchangeOfeerStatus.Approved, DateTime.Now,Utility.UserId);
                //sync data to WareHouse
                //oExhangeOffers.GetTPWarehouse();

                SPWarehouses oShowrooms = new SPWarehouses();
                oShowrooms.GetExchangeWarehouse(offerId);
                foreach (SPWarehouse oShowroom in oShowrooms)
                {
                   CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                   oDataTran.TableName = "t_PromoExchangeOffers";
                   oDataTran.DataID = offerId;
                   oDataTran.WarehouseID = oShowroom.WarehouseID;
                   oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                   oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                   oDataTran.BatchNo = 0;
                   if (oDataTran.CheckDataByWHID() == false)
                   {
                       oDataTran.AddForTDPOS();
                   }
                }
                
                DBController.Instance.CommitTransaction();
                DataLoadControl();
                // Set cursor as default arrowf
                Cursor.Current = Cursors.Default;
                MessageBox.Show("You have successfully approved the Exchange offer", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else

            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void LoadOfferStatusCmb()
        {
            // Source
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ExchangeOfeerStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ExchangeOfeerStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        public void LoadIsActiveCmb()
        {
            // Source
            cmbIsActive.Items.Add("All");
            cmbIsActive.Items.Add("Active");
            cmbIsActive.Items.Add("Inactive");
            cmbIsActive.SelectedIndex = 0;
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you Sure?", "inactivate Exchange Offer", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                DBController.Instance.BeginNewTransaction();
                //approve the data
                int index = oExhangeOffers.GetIndex(listSelectedId);
                int offerId = oExhangeOffers[index].OfferId;
                bool isChanged = oExhangeOffers[index].EditActiveStatus(offerId, 0, DateTime.Now, Utility.UserId);
                if (isChanged)
                {
                    SPWarehouses oShowrooms = new SPWarehouses();
                    oShowrooms.GetExchangeWarehouse(offerId);
                    foreach (SPWarehouse oShowroom in oShowrooms)
                    {
                        CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                        oDataTran.TableName = "t_PromoExchangeOffers";
                        oDataTran.DataID = offerId;
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                }
                DBController.Instance.CommitTransaction();
                DataLoadControl();
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else

            }
        }
    }
}
