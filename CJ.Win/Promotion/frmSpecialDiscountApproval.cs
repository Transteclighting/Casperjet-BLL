using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.Promotion;
using CJ.Class.POS;

namespace CJ.Win.Promotion 
{
    public partial class frmSpecialDiscountApproval : Form 
    {
        PromoDiscountSpecials _oPromoDiscountSpecials;
        DataTree _oDataTree;
        DataTree oDataTree;
        Users oUsers;
        User oUser;
        int _nStatus = 0;
        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        int nWarehouseID = 0;

        public frmSpecialDiscountApproval()
        {
           // _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(PromoDiscountSpecial oPromoDiscountSpecial)
        {
            this.Tag = oPromoDiscountSpecial;
            txtApplyTo.Text = oPromoDiscountSpecial.AuthorityName;
            nWarehouseID = oPromoDiscountSpecial.WarehouseID;
            ctlCustomer.txtCode.Text = oPromoDiscountSpecial.CustomerCode;
            txtApprovalno.Text = oPromoDiscountSpecial.ApprovalNumber;
            dtFromDate.Value = oPromoDiscountSpecial.CreateDate;        
            txtCode.Text = oPromoDiscountSpecial.ConsumerCode;
            txtName.Text = oPromoDiscountSpecial.ConsumerName;
            txtAmount.Text = oPromoDiscountSpecial.Amount.ToString();
            txtSalestype.Text = Enum.GetName(typeof(Dictionary.SalesType), oPromoDiscountSpecial.SalesType);
            if (oPromoDiscountSpecial.IsApplicableB2BDiscount== (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsApplicableB2BDiscount.Checked = true;
            }
            else
            {
                chkIsApplicableB2BDiscount.Checked = false;
            }
            txtReason.Text = oPromoDiscountSpecial.Reason;
            txtRemarks.Text = oPromoDiscountSpecial.ApproveRemarks;

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save((int)Dictionary.SpacialDiscountStatus.Approved);
            this.Close();
        }
        private void Save(int nStatus)
        {
            PromoDiscountSpecial oPromoDiscountSpecial = (PromoDiscountSpecial)this.Tag;
            oPromoDiscountSpecial.Amount = Convert.ToDouble(txtAmount.Text);
            oPromoDiscountSpecial.ApprovalNumber= txtApprovalno.Text;
            if (chkIsApplicableB2BDiscount.Checked)
            {
                oPromoDiscountSpecial.IsApplicableB2BDiscount= (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                oPromoDiscountSpecial.IsApplicableB2BDiscount = (int)Dictionary.YesOrNoStatus.NO;
            }
            oPromoDiscountSpecial.Status = nStatus;            
            oPromoDiscountSpecial.ApproveRemarks= txtRemarks.Text;
            oPromoDiscountSpecial.ApproveUserID = Utility.UserId;
            oPromoDiscountSpecial.ApproveDate = DateTime.Now.Date;
            oPromoDiscountSpecial.WarehouseID = nWarehouseID;
            try
            {
                DBController.Instance.BeginNewTransaction();
                oPromoDiscountSpecial.Approved();
                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_PromoDiscountSpecial";
                oDataTran.DataID = oPromoDiscountSpecial.SpecialDiscountID;
                oDataTran.WarehouseID = nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckDataByType())
                {
                }
                else
                {
                    oDataTran.AddForTDPOS();
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The Transaction: " + oPromoDiscountSpecial.ApprovalNumber, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            Save((int)Dictionary.SpacialDiscountStatus.Rejected);
            this.Close();

        }
    }
}
