using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferVenderParnets : Form
    {
        ExchangeOfferVenderParents oExchangeOfferVenderParents;

        public frmExchangeOfferVenderParnets()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            oExchangeOfferVenderParents = new ExchangeOfferVenderParents();
            lvwExchangeOfferVenders.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oExchangeOfferVenderParents.Refresh(txtCode.Text.Trim(), txtName.Text.Trim(), txtContactNo.Text.Trim());
            DBController.Instance.CloseConnection();
            foreach (ExchangeOfferVenderParent oExchangeOfferVenderParent in oExchangeOfferVenderParents)
            {
                ListViewItem oItem = lvwExchangeOfferVenders.Items.Add(oExchangeOfferVenderParent.ParentVenderCode.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderParent.ParentVenderName.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderParent.ContactPerson.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderParent.ContactNo.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderParent.Address.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderParent.Email.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderParent.MotherAcctBalance.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderParent.ChildAcctBalance.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderParent.Remarks.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oExchangeOfferVenderParent.IsActive));

                oItem.Tag = oExchangeOfferVenderParent;
            }
            this.Text = "Exchange Offer Parent Vender List [" + oExchangeOfferVenderParents.Count + "]";
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExchangeOfferVenderParent oForm = new frmExchangeOfferVenderParent();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwExchangeOfferVenders.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExchangeOfferVenderParent oExchangeOfferVenderParent = (ExchangeOfferVenderParent)lvwExchangeOfferVenders.SelectedItems[0].Tag;

            frmExchangeOfferVenderParent oForm = new frmExchangeOfferVenderParent();
            oForm.ShowDialog(oExchangeOfferVenderParent);
            DataLoadControl();
        }

        private void lvwExchangeOfferVenders_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }
    }
}