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

namespace CJ.Win.Promotion
{
    public partial class frmPromoWarranty : Form
    {
        PromoWarrantys oPromoWarrantys;
        int listSelectedId;
        int SelectedWarrantyId;
        public frmPromoWarranty()
        {
            InitializeComponent();
            isListItemSelect();
        }
        public void isListItemSelect()
        {
            if (lvwExchangeOffers.SelectedItems.Count <= 0)
            {
                btnIsApproved.Enabled = false;
                btnActive.Enabled = false;
            }
            else
            {
                btnIsApproved.Enabled = true;
                btnActive.Enabled = true;
            }
        }
        private void lvwExchangeOffers_SelectedIndexChanged(object sender, EventArgs e)
        {
            isListItemSelect();
            if (lvwExchangeOffers.SelectedItems.Count > 0)
            {
                int intselectedindex = lvwExchangeOffers.Items.IndexOf(lvwExchangeOffers.SelectedItems[0]);
                if (intselectedindex >= 0)
                {
                    listSelectedId = Convert.ToInt32(lvwExchangeOffers.Items[intselectedindex].Text);
                    int index = oPromoWarrantys.GetIndex(listSelectedId);
                    SelectedWarrantyId = oPromoWarrantys[index].WarrantyId;
                    if (oPromoWarrantys[index].Status == 2)
                    {
                        btnIsApproved.Enabled = false;
                    }
                    else
                    {
                        btnIsApproved.Enabled = true;
                    }
                    if (oPromoWarrantys[index].IsActive)
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

        private void frmPromoWarranty_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            LoadIsActiveCmb();
            LoadOfferStatusCmb();
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
        private void DataLoadControl()
        {
            isListItemSelect();
            oPromoWarrantys = new PromoWarrantys();
            lvwExchangeOffers.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oPromoWarrantys.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, cmbStatus.SelectedIndex, cmbIsActive.SelectedIndex);
            this.Text = "Promo Warranty " + "[" + oPromoWarrantys.Count + "]";
            foreach (PromoWarranty promoWarranty in oPromoWarrantys)
            {
                ListViewItem oItem = lvwExchangeOffers.Items.Add(promoWarranty.WarrantyId.ToString());
                oItem.SubItems.Add(promoWarranty.Description.ToString());
                oItem.SubItems.Add(promoWarranty.ExtendedWarranty.ToString());
                oItem.SubItems.Add(promoWarranty.FromDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(promoWarranty.ToDate.ToString("dd-MMM-yyyy"));
                if (promoWarranty.Status == 1)
                {
                    oItem.BackColor = Color.MistyRose;
                    oItem.SubItems.Add("Create");
                }
                else if (promoWarranty.Status == 2)
                {
                    oItem.SubItems.Add("Approved");
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(promoWarranty.IsActive.ToString());
                oItem.SubItems.Add(promoWarranty.CreateDate.ToString());
                oItem.SubItems.Add(promoWarranty.CreateUserId.ToString());
            }
            isListItemSelect();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPromoWarrantyAdd ofrmPromoWarranty = new frmPromoWarrantyAdd();
            ofrmPromoWarranty.ShowDialog();
            DataLoadControl();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnIsApproved_Click(object sender, EventArgs e)
        {
            int index = oPromoWarrantys.GetIndex(listSelectedId);
            int warrantyId = oPromoWarrantys[index].WarrantyId;
            // popup add form as approve from 
            Cursor.Current = Cursors.WaitCursor;
            frmPromoWarrantyAdd ofrmPromoWarranty = new frmPromoWarrantyAdd((int)Dictionary.PromoWarrantyFormType.Approved, warrantyId);
            Cursor.Current = Cursors.Default;
            ofrmPromoWarranty.ShowDialog();
            DataLoadControl();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            int index = oPromoWarrantys.GetIndex(listSelectedId);
            int warrantyId = oPromoWarrantys[index].WarrantyId;
            // popup add form as Active from 
            Cursor.Current = Cursors.WaitCursor;
            frmPromoWarrantyAdd ofrmPromoWarranty = new frmPromoWarrantyAdd((int)Dictionary.PromoWarrantyFormType.Inactive, warrantyId);
            Cursor.Current = Cursors.Default;
            ofrmPromoWarranty.ShowDialog();
            DataLoadControl();
        }
    }
}
