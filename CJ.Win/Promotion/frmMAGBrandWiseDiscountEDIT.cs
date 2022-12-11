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
using System.Collections.Generic;
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmMAGBrandWiseDiscountEDIT : Form
    {

        ProductGroups oProductGroups;
        Brands oBrands;
        int _nStatus = 0;
        DateTime _dEffectiveDate;
        DateTime _dPreEffectiveDate;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        string _PreDiscountPercent;
        string _ncurrentForm;
        public bool _bActionSave = false;


        public frmMAGBrandWiseDiscountEDIT(int nStatus, string currentForm)
        {
            _nStatus = nStatus;
            _ncurrentForm = currentForm;


            InitializeComponent();

            if (_ncurrentForm == "Edit")
            {
                chkIsActive.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (validateUIInput())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private bool validateUIInput()
        {

            if (dtEffectiveDate.Value.Date < _dPreEffectiveDate)
            {
                MessageBox.Show("Can't update backward date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtEffectiveDate.Focus();
                return false;
            }

            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Please enter Discount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                return false;
            }

            return true;
        }

    private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(PromoDiscountMAGBrand oPromoDiscountMAGBrand)
        {
            this.Tag = oPromoDiscountMAGBrand;

            PromoDiscountMAGBrands _oPromoDiscountMAGBrands = new PromoDiscountMAGBrands();

            int magId = oPromoDiscountMAGBrand.MAGID;

            _oPromoDiscountMAGBrands.GetParent(magId);

            foreach (PromoDiscountMAGBrand oPromoMAGBrand in _oPromoDiscountMAGBrands)
            {
                lblPG.Text = oPromoMAGBrand.PGName;
                lblMAG.Text = oPromoMAGBrand.MAGName;
            }


            lblBrand.Text = oPromoDiscountMAGBrand.Brand;
            txtDiscount.Text = oPromoDiscountMAGBrand.DiscountPercent.ToString();
            _PreDiscountPercent = txtDiscount.Text;
            dtEffectiveDate.Value = oPromoDiscountMAGBrand.EffectiveDate;
            _dEffectiveDate = dtEffectiveDate.Value;
            _dPreEffectiveDate = dtEffectiveDate.Value;

            if (oPromoDiscountMAGBrand.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            //txtDiscount.Enabled = false;
            this.ShowDialog();
        }

        private void Save()
        {
            PromoDiscountMAGBrand oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)this.Tag;

            oPromoDiscountMAGBrand.DiscountPercent = Convert.ToDouble(txtDiscount.Text.ToString());

            oPromoDiscountMAGBrand.PreDiscountPercent = Convert.ToDouble(_PreDiscountPercent);

            oPromoDiscountMAGBrand.EffectiveDate = dtEffectiveDate.Value.Date;

            oPromoDiscountMAGBrand.PreEffectiveDate = _dPreEffectiveDate;

            if (chkIsActive.Checked)
            {
                oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.NO;
            }
            if (_nStatus == (int)Dictionary.MAGBrandWiseDiscount.Create)
            {
                oPromoDiscountMAGBrand.Status = (int)Dictionary.MAGBrandWiseDiscount.Create;
            }
            else if (_nStatus == (int)Dictionary.MAGBrandWiseDiscount.Approved)
            {
                oPromoDiscountMAGBrand.Status = (int)Dictionary.MAGBrandWiseDiscount.Approved;
                oPromoDiscountMAGBrand.ApproveUserID = Utility.UserId;
                oPromoDiscountMAGBrand.ApproveDate = DateTime.Now;
            }
            oPromoDiscountMAGBrand.CreateUserID = Utility.UserId;
            oPromoDiscountMAGBrand.CreateDate = DateTime.Now;


            try
            {
                DBController.Instance.BeginNewTransaction();

                if (_ncurrentForm == "Edit")
                {
                    oPromoDiscountMAGBrand.UpdateUserID = Utility.UserId;
                    oPromoDiscountMAGBrand.UpdateDate = DateTime.Now;
                    oPromoDiscountMAGBrand.EditByMAGBrandWiseDiscount();
                }

                else if (_ncurrentForm == "Approve")
                {
                    oPromoDiscountMAGBrand.ApproveByMAGBrandWiseDiscount();
                }
                Showrooms oShowrooms = new Showrooms();
                oShowrooms.Refresh();
                foreach (Showroom oShowroom in oShowrooms)
                {
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_PromoDiscountMAGBrand";
                    oDataTran.DataID = Convert.ToInt32(oPromoDiscountMAGBrand.DiscountID);
                    oDataTran.WarehouseID = oShowroom.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByWHID() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You have successfully update the transaction: " + oPromoDiscountMAGBrand.DiscountID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frmMAGBrandWiseDiscountEDIT_Load(object sender, EventArgs e)
        {

        }
    }
}
