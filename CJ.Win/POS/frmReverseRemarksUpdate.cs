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
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.Win.POS
{
    public partial class frmReverseRemarksUpdate : Form
    {

        InvoiceReverse _oInvoiceReverse;
        int nReverseID = 0;
        int nWarehouseID = 0;
        int _nType = 0;
        double _Amt = 0;
        double _DisAmt = 0;
        long nInvoiceID = 0;
        TELLib _oTelLib;
        SalesInvoice _oSalesInvoice;
        RetailSalesInvoice _oRetailSalesInvoice;
        private string sActualReason = "";

        public frmReverseRemarksUpdate()
        {
            InitializeComponent();
        }

        public void ShowDialog(InvoiceReverse oInvoiceReverse)
        {
            this.Tag = oInvoiceReverse;
            txtRefInvoiceNo.Text = oInvoiceReverse.InvoiceNo; 
            nReverseID = oInvoiceReverse.ReverseID;
            nWarehouseID = oInvoiceReverse.WarehouseID;
            nWarehouseID = oInvoiceReverse.WarehouseID;
            txtReasonText.Text = oInvoiceReverse.Reason;
            sActualReason= oInvoiceReverse.Reason;
           
           

            this.ShowDialog();
        }

        private void txtRefInvoiceNo_TextChanged(object sender, EventArgs e)
        {

            _oInvoiceReverse = new InvoiceReverse();
            txtRefInvoiceNo.ForeColor = System.Drawing.Color.Red;
            if (txtRefInvoiceNo.Text.Length == 13)
            {
                DBController.Instance.OpenNewConnection();
                _oInvoiceReverse.RefreshByInvoiceNoHO(txtRefInvoiceNo.Text.Trim());
                if (_oInvoiceReverse.InvoiceNo == null)
                {
                    _oInvoiceReverse = null;
                    AppLogger.LogFatal("There is no Data.");
                    return;
                }
                else
                {
                    nInvoiceID = 0;
                    nInvoiceID = _oInvoiceReverse.InvoiceID;
                    lblInvoiceNo.Text = _oInvoiceReverse.InvoiceNo;
                    lblInvoiceDate.Text = Convert.ToDateTime(_oInvoiceReverse.InvoiceDate).ToString("dd-MMM-yyyy");
                    lblConsumerName.Text = _oInvoiceReverse.ConsumerName;
                    lblConsumerAddress.Text = _oInvoiceReverse.ConsumerAddress;
                    lblMobile.Text = _oInvoiceReverse.MobileNo;
                    lblEmail.Text = _oInvoiceReverse.Email;
                    _Amt = 0;
                    _DisAmt = 0;
                    _oTelLib = new TELLib();
                    lblInvoiceAmount.Text = _oTelLib.TakaFormat(_oInvoiceReverse.InvoiceAmount);



                    lblRetailSalesAmt.Text =
                        _oTelLib.TakaFormat(_oInvoiceReverse.InvoiceAmount + _oInvoiceReverse.Discount -
                                            _oInvoiceReverse.OtherCharge);
                    lblDiscount.Text = _oTelLib.TakaFormat(_oInvoiceReverse.InvoiceAmount);


                    lblInstallChange.Text =@"0.00";
                    lblFreightCharge.Text = @"0.00";
                    lblOthersCharge.Text = lblDiscount.Text = _oTelLib.TakaFormat(_oInvoiceReverse.OtherCharge);


                    txtRefInvoiceNo.ForeColor = System.Drawing.Color.Empty;
                    txtRefInvoiceNo.Enabled = false;
                }
            }
            else
            {
                lblInvoiceNo.Text = "";
                lblInvoiceDate.Text = "";
                lblConsumerName.Text = "";
                lblConsumerAddress.Text = "";
                lblMobile.Text = "";
                lblEmail.Text = "";
                lblInstallChange.Text = "";
                lblFreightCharge.Text = "";
                lblOthersCharge.Text = "";
                lblRetailSalesAmt.Text = "";
                lblDiscount.Text = "";
                lblInvoiceAmount.Text = "";

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtReasonText.Text == "")
            {
                MessageBox.Show(@"Please Enter Reason", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReasonText.Focus();
                return;
            }
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oInvoiceReverse = new InvoiceReverse
                {
                    ReverseID = nReverseID,
                    WarehouseID = nWarehouseID,
                    Reason = txtReasonText.Text,
                    ActualReason = sActualReason
                };
                _oInvoiceReverse.UpdateReason();
                MessageBox.Show(@"Update Successfully ", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBController.Instance.CommitTransaction();
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
