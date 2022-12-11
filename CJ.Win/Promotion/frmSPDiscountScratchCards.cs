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
using CJ.Class.Promotion;
using CJ.Win.Promotion;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Win.Promotion
{
    public partial class frmSPDiscountScratchCards : Form
    {
        ConsumerPromotions oConsumerPromotions;
        DSPromotion oDSPromoProductFor;
        public frmSPDiscountScratchCards()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //User oUser = new User();
            frmSPDiscountScratchCard oFrom = new frmSPDiscountScratchCard();
            oFrom.ShowDialog();

            LoadData();
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
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
            oConsumerPromotions.GetScratchCardOfferList(dtFromDate.Value.Date, dtToDate.Value.Date, nIsActive, nStatus, txtPromoNo.Text.Trim(), txtPromoName.Text.Trim());
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
            this.Text = "Consumer Promotion List [" + oConsumerPromotions.Count + "]";
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

        private void frmSPDiscountScratchCards_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadData();
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

                    oConsumerPromotion.ChangeIsActiveStatusScratchCardOffer(IsActive);
                    if (oConsumerPromotion.Status == ((int)Dictionary.SalesPromStatus.Approved))
                    {
                        SPWarehouses oShowrooms = new SPWarehouses();
                        oShowrooms.GetScratchCardOfferWarehouse(oConsumerPromotion.ConsumerPromoID);
                        foreach (SPWarehouse oShowroom in oShowrooms)
                        {
                            CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                            oDataTran.TableName = "t_ScratchCardOffer";
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
                    }
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

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwPromotionList.SelectedItems[0].Tag;

            if (oConsumerPromotion.Status == (int)Dictionary.SalesPromStatus.Create)
            {
                frmSPDiscountScratchCard oFrom = new frmSPDiscountScratchCard();
                oFrom.ShowDialog(oConsumerPromotion, true);

                LoadData();
            }
            else
            {
                MessageBox.Show("Already Approved", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
