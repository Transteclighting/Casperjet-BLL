using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Report;
using CJ.Class.Duty;
using CJ.Win.Security;
using CJ.Class.Web.UI.Class;
using CJ.Win.Claim;


namespace CJ.Win
{
    public partial class frmGiftVoucherEntry : Form
    {
        ProductDetail _oProductDetail;

        public frmGiftVoucherEntry()
        {
            InitializeComponent();
        }
        private bool validateUIInput()
        {

            #region Input Information Validation

            if (ctlProduct1.SelectedSerarchProduct == null || ctlProduct1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.Focus();
                return false;
            }
            if (txtFromSL.Text == "")
            {
                MessageBox.Show("Please enter Start Serial No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFromSL.Focus();
                return false;
            }
            else
            {
                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtFromSL.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Input Valid Serial No ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFromSL.Focus();
                    return false;
                }
                if (Convert.ToInt32(txtFromSL.Text.ToString())> Convert.ToInt32(txtToSL.Text.ToString()))
                {
                    MessageBox.Show("Start Serial No Munst be Less or Equal End Serial No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFromSL.Focus();
                    return false;
                }
            }
            if (txtToSL.Text == "")
            {
                MessageBox.Show("Please enter End Serial No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtToSL.Focus();
                return false;
            }
            else
            {
                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtToSL.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Input Valid Serial No ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtToSL.Focus();
                    return false;
                }
                //if (Convert.ToInt32(txtFromSL.Text.ToString()) > Convert.ToInt32(txtToSL.Text.ToString()))
                //{
                //    MessageBox.Show("Start Serial No Munst be Less or Equal End Serial No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtFromSL.Focus();
                //    return false;
                //}
            }
            if (txtValidMonth.Text == "")
            {
                MessageBox.Show("Please enter Month", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValidMonth.Focus();
                return false;
            }
            else
            {
                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtValidMonth.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Input Valid Month ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValidMonth.Focus();
                    return false;
                }

            }

            //oGiftVoucher.GetMaxSerialNo();
            //if ((Convert.ToInt32(txtFromSL.Text.ToString()) - oGiftVoucher.SerialNo) != 1)
            //{
            //    MessageBox.Show("Please Maintain Serial No Sequentially", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtFromSL.Focus();
            //    return false;
            //}


            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                DBController.Instance.OpenNewConnection();
                GiftVoucher oGiftVoucher = new GiftVoucher();

                oGiftVoucher.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                oGiftVoucher.SerialNo = Convert.ToInt32(txtFromSL.Text.ToString());

                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                _oProductDetail.Refresh();
                oGiftVoucher.UnitPrice = _oProductDetail.RSP;

                oGiftVoucher.ValidMonth = Convert.ToInt32(txtValidMonth.Text.ToString());
                oGiftVoucher.Qty = (Convert.ToInt32(txtToSL.Text.ToString()) - Convert.ToInt32(txtFromSL.Text.ToString()))+1;

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    oGiftVoucher.Add();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Create Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
                        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}