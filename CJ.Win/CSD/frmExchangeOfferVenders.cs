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
    public partial class frmExchangeOfferVenders : Form
    {
        ExchangeOfferVenders oExchangeOfferVenders;

        public frmExchangeOfferVenders()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            oExchangeOfferVenders = new ExchangeOfferVenders();
            lvwExchangeOfferVenders.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oExchangeOfferVenders.GetVenders(txtCode.Text.Trim(), txtName.Text.Trim(), txtContactNo.Text.Trim(),txtParentCustomer.Text.Trim(),txtParentVender.Text.Trim());
            DBController.Instance.CloseConnection();
            foreach (ExchangeOfferVender oExchangeOfferVender in oExchangeOfferVenders)
            {
                ListViewItem oItem = lvwExchangeOfferVenders.Items.Add(oExchangeOfferVender.Code.ToString());
                oItem.SubItems.Add(oExchangeOfferVender.Name.ToString());
                oItem.SubItems.Add(oExchangeOfferVender.ParentVenderName.ToString());
                oItem.SubItems.Add(oExchangeOfferVender.ParentCustomerName.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oExchangeOfferVender.Balance).ToString());
                oItem.SubItems.Add(oExchangeOfferVender.Remarks.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oExchangeOfferVender.IsActive));

                oItem.Tag = oExchangeOfferVender;
            }
            this.Text = "Exchange Offer Vender List [" + oExchangeOfferVenders.Count + "]";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExchangeOfferVender oForm = new frmExchangeOfferVender();
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
            ExchangeOfferVender oExchangeOfferVender = (ExchangeOfferVender)lvwExchangeOfferVenders.SelectedItems[0].Tag;

            frmExchangeOfferVender oForm = new frmExchangeOfferVender();
            oForm.ShowDialog(oExchangeOfferVender);
            DataLoadControl();


        }

        private void frmExchangeOfferVenders_Load(object sender, EventArgs e)
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtParentVender_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtParentCustomer_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}