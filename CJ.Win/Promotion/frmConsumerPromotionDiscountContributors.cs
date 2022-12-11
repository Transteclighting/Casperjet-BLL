using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Promotion;

namespace CJ.Win.Promotion
{
    public partial class frmConsumerPromotionDiscountContributors : Form
    {
        PromoDiscountContributors oConsumerPromotionDiscountContributors;
        public frmConsumerPromotionDiscountContributors()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddDiscountSharingType_Click(object sender, EventArgs e)
        {
            frmConsumerPromotionDiscountContributor oForm = new frmConsumerPromotionDiscountContributor();
            oForm.ShowDialog();
            if (oForm._bActionSave)
                LoadData();
        }

        private void LoadData()
        {
            oConsumerPromotionDiscountContributors = new PromoDiscountContributors();
            lvwDiscountSharingType.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oConsumerPromotionDiscountContributors.Refresh(txtDiscountContributorName.Text);

            foreach (PromoDiscountContributor oConsumerPromotionDiscountSharingType in oConsumerPromotionDiscountContributors)
            {
                ListViewItem oItem = lvwDiscountSharingType.Items.Add(oConsumerPromotionDiscountSharingType.DiscountContributorName.ToString());
                oItem.SubItems.Add(oConsumerPromotionDiscountSharingType.CreateUserName.ToString());
                oItem.SubItems.Add(oConsumerPromotionDiscountSharingType.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.Tag = oConsumerPromotionDiscountSharingType;
            }
        }

        private void btnCloseDiscountSharingType_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsumerPromotionDiscountContributors_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
