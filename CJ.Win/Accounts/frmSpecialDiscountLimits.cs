using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Accounts;

using CJ.Class.Library;

namespace CJ.Win.Accounts
{
    public partial class frmSpecialDiscountLimits : Form
    {
        TELLib _oTELLib;

        PromoDiscountSpecialAuthorityLimits _oPromoDiscountSpecialAuthorityLimits;
        
        public frmSpecialDiscountLimits()
        {
            InitializeComponent();
        }

        private void frmSpecialDiscountLimits_Load(object sender, EventArgs e)
        {
            DateTime _Date = Convert.ToDateTime("01-" + (dtDate.Value.Month) + "-" + dtDate.Value.Year);
            //dtDate.Value = _Date.AddMonths(-1);
            dtDate.Value = _Date;
            LoadData();
        }

        private void LoadData()
        {
            _oPromoDiscountSpecialAuthorityLimits = new PromoDiscountSpecialAuthorityLimits();
            lvwSPLimits.Items.Clear();
            DBController.Instance.OpenNewConnection();
            
            _oPromoDiscountSpecialAuthorityLimits.RefreshBySpecialDiscountLimit(dtDate.Value);
            foreach (PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit in _oPromoDiscountSpecialAuthorityLimits)
            {
                ListViewItem oItem = lvwSPLimits.Items.Add(oPromoDiscountSpecialAuthorityLimit.EmployeeName);
                oItem.SubItems.Add(oPromoDiscountSpecialAuthorityLimit.Limit.ToString());
                oItem.SubItems.Add(oPromoDiscountSpecialAuthorityLimit.Discount.ToString());
                oItem.SubItems.Add(oPromoDiscountSpecialAuthorityLimit.AvailableLimit.ToString());
                oItem.SubItems.Add(dtDate.Value.ToString("MMM-yyyy"));
                oItem.Tag = oPromoDiscountSpecialAuthorityLimit;
            }
            this.Text = "Total = " + _oPromoDiscountSpecialAuthorityLimits.Count + "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();
            DateTime _dtDate = DateTime.Now.Date;
            //DateTime firstDay = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            DateTime _dFirstDateOfThisMonth = _oTELLib.FirstDayofMonth(_dtDate);
            DateTime _dFirstDateOfSelectedMonth = _oTELLib.FirstDayofMonth(dtDate.Value);

            if (lvwSPLimits.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Add.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_dFirstDateOfThisMonth > _dFirstDateOfSelectedMonth)
            {
                MessageBox.Show("Can't Add backmonth data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit = (PromoDiscountSpecialAuthorityLimit)lvwSPLimits.SelectedItems[0].Tag;
                frmSpecialDiscountLimit oForm = new frmSpecialDiscountLimit(dtDate.Value);
                oForm.ShowDialog(oPromoDiscountSpecialAuthorityLimit);
            }
       
            LoadData();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (lvwSPLimits.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit = (PromoDiscountSpecialAuthorityLimit)lvwSPLimits.SelectedItems[0].Tag;
            frmSpecialDiscountLimitHistory oForm = new frmSpecialDiscountLimitHistory();
            oForm.ShowDialog(oPromoDiscountSpecialAuthorityLimit);
            LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
