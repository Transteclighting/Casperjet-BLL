using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.Win.POS
{
    public partial class frmUnsoldDefectiveAcknowledge : Form
    {
        public bool _IsTrue = false;
        int _nUIControl = 0;
        UnsoldDefectiveProduct _oUnsoldDefectiveProduct;
        UnsoldDefectiveProducts _UnsoldDefectiveProducts;
        int nDefectiveID = 0;
        string sDefectiveNo = "";
        int nWarehouseID = 0;
        private void LoadCombos()
        {
           


            //Defective Type
            cmbDefectiveType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsoldDefectiveProductType)))
            {
                cmbDefectiveType.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), GetEnum));
            }
            cmbDefectiveType.SelectedIndex = 0;

            
        }
        public frmUnsoldDefectiveAcknowledge(int nUIControl) 
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }
        private void frmUnsoldDefectiveStatus_Load(object sender, EventArgs e)
        {

        }


       

        public void ShowDialog(UnsoldDefectiveProduct oUnsoldDefectiveProduct)
        {
            LoadCombos();
            nDefectiveID = 0;
            nDefectiveID = oUnsoldDefectiveProduct.DefectiveID;
            sDefectiveNo = "";
            sDefectiveNo = oUnsoldDefectiveProduct.DefectiveNo;
            nWarehouseID = 0;
            nWarehouseID = oUnsoldDefectiveProduct.WarehouseID;
            txtDefectiveNo.Text = sDefectiveNo;
            lblCreateDate.Text = Convert.ToDateTime(oUnsoldDefectiveProduct.CreateDate).ToString("dd-MMM-yyyy");
            lblOutletName.Text = oUnsoldDefectiveProduct.ShowroomCode;
            lblStatus.Text = Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), oUnsoldDefectiveProduct.Status);
            lblProductName.Text = '[' + oUnsoldDefectiveProduct.ProductCode + ']' + oUnsoldDefectiveProduct.ProductName;
            lblProductSerial.Text = oUnsoldDefectiveProduct.BarcodeSL;
            txtOriginalSL.Text = oUnsoldDefectiveProduct.OriginalSL;
            cmbDefectiveType.SelectedIndex = oUnsoldDefectiveProduct.DefectiveType - 1;
            lblFault.Text = oUnsoldDefectiveProduct.Fault;
            lblReason.Text = oUnsoldDefectiveProduct.Reason;
            if (oUnsoldDefectiveProduct.JobNo != "")
                txtJobNo.Text = oUnsoldDefectiveProduct.JobNo.ToString() + '[' + Convert.ToDateTime(oUnsoldDefectiveProduct.JobDate).ToString("dd-MMM-yyyy") + ']';
            if (oUnsoldDefectiveProduct.RefTranNo != "")
                txtRefTranNo.Text = oUnsoldDefectiveProduct.RefTranNo + '[' + Convert.ToDateTime(oUnsoldDefectiveProduct.RefTranDate).ToString("dd-MMM-yyyy") + ']';
            txtRemarks.Text = oUnsoldDefectiveProduct.Remarks.ToString();
            txtAcknowledgeRemarks.Text = oUnsoldDefectiveProduct.AcknowledgmentRemarks;
            txtPaneltyAmount.Text = oUnsoldDefectiveProduct.PaneltyAmount.ToString();
            txtProposedAmt.Text = oUnsoldDefectiveProduct.ProposeDicAmount.ToString();
            txtApprovedAmt.Text = oUnsoldDefectiveProduct.ApproveDicAmount.ToString();
            TELLib oTELLib = new TELLib();
            //txtPrice.Text = "CP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.CostPrice) + "|NSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.NSP) + "|RSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP) + "|VAT:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.VAT) + "";
            this.Tag = oUnsoldDefectiveProduct;

            if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed)
            {
                this.Text = "Defective Product for Assessment";
                txtPaneltyAmount.Enabled = false;
                txtProposedAmt.Enabled = false;
                txtApprovedAmt.Enabled = false;
                //btnSave.Text = "Assessed";
                txtPrice.Text = "RSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP) + "|VAT:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.VAT) + "";
            }
            //else if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Reject)
            //{
            //    this.Text = "Defective Product for Reject";
            //    btnSave.Text = "Reject";
            //    txtPrice.Text = "RSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP) + "|VAT:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.VAT) + "";
            //}
            //else if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Discount_Approved)
            //{
            //    this.Text = "Defective Product for Price Approval";
            //    btnSave.Text = "Approved";
            //    txtPrice.Text = "CP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.CostPrice) + "|NSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.NSP) + "|RSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP) + "|VAT:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.VAT) + "";
            //}
            else
            {
                this.Text = "Unsold Defective Product (Assign Job#)";
                txtPrice.Text = "RSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP) + "|VAT:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.VAT) + "";
                
                lblJobNo.Text = "Job Number";
                btnAssignJob.Visible = true;
                cmbDefectiveType.Enabled = false;
                //txtAcknowledgeRemarks.Enabled = false;
                txtPaneltyAmount.Enabled = false;
                txtProposedAmt.Enabled = false;
                txtApprovedAmt.Enabled = false;
            }
            this.ShowDialog();

        }
        public bool UIValidation()
        {
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPaneltyAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPaneltyAmount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtPaneltyAmount.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPaneltyAmount.Text = "0.00";
                }

            }
        }
        private void txtProposedAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtProposedAmt.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtProposedAmt.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProposedAmt.Text = "0.00";
                }

            }
        }
        private void txtApprovedAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtApprovedAmt.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtApprovedAmt.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApprovedAmt.Text = "0.00";
                }

            }
        }
        private void btnAssignJob_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    _oUnsoldDefectiveProduct.IsDefectiveAcknowledged = 1;
                    _oUnsoldDefectiveProduct.AcknowledgmentRemarks = txtAcknowledgeRemarks.Text;
                    _oUnsoldDefectiveProduct.DefectiveID = nDefectiveID;
                    _oUnsoldDefectiveProduct.WarehouseID = nWarehouseID;
                    _oUnsoldDefectiveProduct.UpdateAcknowledge();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Acknowledged. DefectiveNo # " + sDefectiveNo, "Acknowledge", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _IsTrue = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmbDefectiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        private void cmbIsLocallyRepaired_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbIsRepairable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbLocallySaleable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}