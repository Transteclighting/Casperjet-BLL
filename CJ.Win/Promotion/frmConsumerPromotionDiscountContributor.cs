using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Promotion;
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmConsumerPromotionDiscountContributor : Form
    {

        private string checkDuplicateValue;
        public bool _bActionSave = false;

        public frmConsumerPromotionDiscountContributor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                PromoDiscountContributor oConsumerPromotionDiscountSharingType = new PromoDiscountContributor();

                oConsumerPromotionDiscountSharingType.DiscountContributorName = txtDiscountContributorName.Text;
                oConsumerPromotionDiscountSharingType.CreateDate = DateTime.Now.Date;
                oConsumerPromotionDiscountSharingType.CreateUserID = Utility.UserId;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oConsumerPromotionDiscountSharingType.Add();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_PromoDiscountContributor";
                        oDataTran.DataID = Convert.ToInt32(oConsumerPromotionDiscountSharingType.DiscountContributorID);
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
                    MessageBox.Show("Your data has been updated successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private bool UIValidation()
        {
            if (string.IsNullOrEmpty(txtDiscountContributorName.Text))
            {
                MessageBox.Show("Please insert promo discount contributor name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscountContributorName.Focus();
                return false;
            }


            PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
            oPromoDiscountContributor.DiscountContributorName = txtDiscountContributorName.Text;
            checkDuplicateValue = oPromoDiscountContributor.CheckDuplicateData();

            if (checkDuplicateValue == "Yes" && this.Tag == null)
            {
                MessageBox.Show("Contributor name already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscountContributorName.Focus();
                return false;
            }

            return true;

        }
    }
}
