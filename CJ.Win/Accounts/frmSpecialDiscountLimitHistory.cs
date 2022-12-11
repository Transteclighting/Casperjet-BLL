using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmSpecialDiscountLimitHistory : Form
    {
        PromoDiscountSpecialAuthorityLimitHistorys _oPromoDiscountSpecialAuthorityLimitHistorys;
        int nAuthorityID = 0;
        public frmSpecialDiscountLimitHistory()
        {
            InitializeComponent();
        }

        private void frmSpecialDiscountLimitHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void ShowDialog(PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit)
        {

            this.Tag = oPromoDiscountSpecialAuthorityLimit;
            DBController.Instance.OpenNewConnection();
            nAuthorityID = oPromoDiscountSpecialAuthorityLimit.AuthorityID;
            lblName.Text = oPromoDiscountSpecialAuthorityLimit.EmployeeName;
            dtDate.Value = DateTime.Today;
            this.ShowDialog();
        }
        private void LoadData()
        {
            _oPromoDiscountSpecialAuthorityLimitHistorys = new PromoDiscountSpecialAuthorityLimitHistorys();
            lvwSPLimits.Items.Clear();
            DBController.Instance.OpenNewConnection();
           
            _oPromoDiscountSpecialAuthorityLimitHistorys.RefreshBySpecialDiscountLimitHistory(dtDate.Value, nAuthorityID);
            foreach (PromoDiscountSpecialAuthorityLimitHistory oPromoDiscountSpecialAuthorityLimitHistory in _oPromoDiscountSpecialAuthorityLimitHistorys)
            {
                ListViewItem oItem = lvwSPLimits.Items.Add(oPromoDiscountSpecialAuthorityLimitHistory.Limit.ToString());
                oItem.SubItems.Add(oPromoDiscountSpecialAuthorityLimitHistory.UserName);
                oItem.SubItems.Add(oPromoDiscountSpecialAuthorityLimitHistory.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPromoDiscountSpecialAuthorityLimitHistory.Remarks);
                oItem.Tag = oPromoDiscountSpecialAuthorityLimitHistory;
            }
            this.Text = "Total = " + _oPromoDiscountSpecialAuthorityLimitHistorys.Count + "";
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
