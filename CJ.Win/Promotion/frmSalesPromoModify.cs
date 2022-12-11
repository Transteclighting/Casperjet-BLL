using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Promotion;
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmSalesPromoModify : Form
    {
        int nPromotionID = 0;
        public frmSalesPromoModify()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IUValidation())
            {
                SPromotion oSPromotion = new SPromotion();
                oSPromotion.SalesPromotionName = txtPromoDesc.Text.Trim();
                oSPromotion.FromDate = dtStartDate.Value.Date;
                oSPromotion.ToDate = dtEndDate.Value.Date;
                if (rdoActive.Checked == true)
                {
                    oSPromotion.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oSPromotion.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                oSPromotion.SalesPromotionID = nPromotionID;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSPromotion.Edit();

                    Showrooms _oShowrooms = new Showrooms();
                    _oShowrooms.Refresh();

                    foreach (Showroom oShowroom in _oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();

                        oDataTran.TableName = "t_SalesPromo";
                        oDataTran.DataID = nPromotionID;
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;

                        oDataTran.AddForTDPOS();
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Promotion", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private bool IUValidation()
        {
            if (txtPromoDesc.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Promotion Description", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtEndDate.Value.Date<dtStartDate.Value.Date)
            {
                MessageBox.Show("To Date must be Greater of Equal From Date", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalesPromoModify_Load(object sender, EventArgs e)
        {
            dtStartDate.Enabled = false;
        }
        public void ShowDialog(SPromotion _oSPromotion)
        {
            this.Tag = _oSPromotion;
            lblPromotion.Text =  _oSPromotion.SalesPromotionNo.ToString();
            txtPromoDesc.Text = _oSPromotion.SalesPromotionName;
            dtStartDate.Value = _oSPromotion.FromDate.Date;
            dtEndDate.Value = _oSPromotion.ToDate.Date;

            if (_oSPromotion.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoActive.Checked = false;
            }
            nPromotionID = _oSPromotion.SalesPromotionID;
            this.ShowDialog(); 
        }
    }
}