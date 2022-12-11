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
    public partial class frmPromotionTypes : Form
    {
        
        SalesPromotionType _oSalesPromotionType;
        SalesPromotionTypes _oSalesPromotionTypes;

        public frmPromotionTypes()
        {
            InitializeComponent();
        }

        private void frmPromotionTypes_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh();
            lvwSPType.Items.Clear();

            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                ListViewItem lstItem = lvwSPType.Items.Add(oSalesPromotionType.SalesPromotionTypeID.ToString());
                lstItem.SubItems.Add(oSalesPromotionType.SalesPromotionTypeName.ToString());
                if (oSalesPromotionType.IsActive == (int)Dictionary.YesOrNoStatus.YES)
                {
                    lstItem.SubItems.Add("Active");
                }
                else
                {
                    lstItem.SubItems.Add("In Active");
                }
                lstItem.Tag = oSalesPromotionType;
            }
            this.Text = "Total" + "[" + _oSalesPromotionTypes.Count + "]";

        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            frmPromotionType oForm = new frmPromotionType();
            oForm.ShowDialog();
            LoadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lvwSPType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesPromotionType oSalesPromotionType = (SalesPromotionType)lvwSPType.SelectedItems[0].Tag;
            frmPromotionType oForm = new frmPromotionType();
            oForm.ShowDialog(oSalesPromotionType);
            LoadData();

        }
        private void double_Click(object sender, EventArgs e)
        {
            if (lvwSPType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesPromotionType oSalesPromotionType = (SalesPromotionType)lvwSPType.SelectedItems[0].Tag;
            frmPromotionType oForm = new frmPromotionType();
            oForm.ShowDialog(oSalesPromotionType);
            LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}