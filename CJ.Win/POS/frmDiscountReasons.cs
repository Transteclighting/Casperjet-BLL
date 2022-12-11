// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 04, 2014
// Time :  03:00 PM
// Description: UI for Discount Reasons
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;


namespace CJ.Win.POS
{
    public partial class frmDiscountReasons : Form
    {
        DiscountReason _oDiscountReason;
        DiscountReasons _oDiscountReasons;

        public frmDiscountReasons()
        {
            InitializeComponent();
        }

        private void frmDiscountReason_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            _oDiscountReasons = new DiscountReasons();
            _oDiscountReasons.Refresh();
            lvwDiscountReason.Items.Clear();

            foreach (DiscountReason oDiscountReason in _oDiscountReasons)
            {
                ListViewItem lstItem = lvwDiscountReason.Items.Add(oDiscountReason.DiscountReasonID.ToString());
                lstItem.SubItems.Add(oDiscountReason.Description.ToString());

                if (oDiscountReason.IsActive == (int)Dictionary.YesOrNoStatus.YES)
                {
                    lstItem.SubItems.Add("Active");
                }
                else
                {
                    lstItem.SubItems.Add("In Active");
                }

                lstItem.Tag = oDiscountReason;
            }
            this.Text = "Total" + "[" + _oDiscountReasons.Count + "]";

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmDiscountReason oForm = new frmDiscountReason();
            oForm.ShowDialog();
            LoadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lvwDiscountReason.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DiscountReason oDiscountReason = (DiscountReason)lvwDiscountReason.SelectedItems[0].Tag;
            frmDiscountReason oForm = new frmDiscountReason();
            oForm.ShowDialog(oDiscountReason);
            LoadData();

        }
        private void double_Click(object sender, EventArgs e)
        {
            if (lvwDiscountReason.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DiscountReason oDiscountReason = (DiscountReason)lvwDiscountReason.SelectedItems[0].Tag;
            frmDiscountReason oForm = new frmDiscountReason();
            oForm.ShowDialog(oDiscountReason);
            LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}