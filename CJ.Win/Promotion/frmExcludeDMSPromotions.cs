using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class.Promotion;
using CJ.Class;


namespace CJ.Win.Promotion
{
    public partial class frmExcludeDMSPromotions : Form
    {
        
        ConsumerPromotions _oConsumerPromotions;

        public frmExcludeDMSPromotions()
        {
            InitializeComponent();
        }

        private void frmExcludeDMSPromotions_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            _oConsumerPromotions = new ConsumerPromotions();
            _oConsumerPromotions.RefreshCPExcludedDMS();
            lvwExcludedCP.Items.Clear();

            foreach (ConsumerPromotion oConsumerPromotion in _oConsumerPromotions)
            {
                ListViewItem lstItem = lvwExcludedCP.Items.Add(oConsumerPromotion.ConsumerPromoID.ToString());
                lstItem.SubItems.Add(oConsumerPromotion.ConsumerPromoNo.ToString());
                lstItem.SubItems.Add(oConsumerPromotion.ConsumerPromoName.ToString());
                lstItem.Tag = oConsumerPromotion;
            }
            this.Text = "Total" + "[" + _oConsumerPromotions.Count + "]";

        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            frmExcludeDMSPromotion oForm = new frmExcludeDMSPromotion();
            oForm.ShowDialog();
            LoadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lvwExcludedCP.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwExcludedCP.SelectedItems[0].Tag;
            frmExcludeDMSPromotion oForm = new frmExcludeDMSPromotion();
            oForm.ShowDialog(oConsumerPromotion);
            LoadData();

        }
        private void double_Click(object sender, EventArgs e)
        {
            if (lvwExcludedCP.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)lvwExcludedCP.SelectedItems[0].Tag;
            frmExcludeDMSPromotion oForm = new frmExcludeDMSPromotion();
            oForm.ShowDialog(oConsumerPromotion);
            LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}