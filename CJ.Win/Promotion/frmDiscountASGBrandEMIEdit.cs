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
    public partial class frmDiscountASGBrandEMIEdit : Form
    {
        ProductGroups oProductGroups;
        Brands oBrands;
        int _nStatus = 0;
        DateTime _dEffectiveDate;
        //DateTime _dToDate;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        DiscountASGBrandEMIs _oDiscountASGBrandEMIs;
        public frmDiscountASGBrandEMIEdit(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(DiscountASGBrandEMI oDiscountASGBrandEMI)
        {
            this.Tag = oDiscountASGBrandEMI;
            _dEffectiveDate = oDiscountASGBrandEMI.EffectiveDate;
            DiscountASGBrandEMIs _oDiscountASGBrandEMIs = new DiscountASGBrandEMIs();

            int agId = oDiscountASGBrandEMI.AGID;

            _oDiscountASGBrandEMIs.GetParent(agId);

            foreach (DiscountASGBrandEMI oDiscountB2B2 in _oDiscountASGBrandEMIs)
            {
                lblPG.Text = oDiscountB2B2.PGName;
                lblMAG.Text = oDiscountB2B2.MAGName;
                lblASG.Text = oDiscountB2B2.ASGName;
                lblAG.Text = oDiscountB2B2.AGName;
            }

            lblEMITenure.Text = oDiscountASGBrandEMI.Tenure.ToString();
            lblBrand.Text = oDiscountASGBrandEMI.Brand;
            dtEffectiveDate.Value = oDiscountASGBrandEMI.EffectiveDate;

            if (oDiscountASGBrandEMI.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation
            
            if (dtEffectiveDate.Value.Date < DateTime.Today.Date)
            {
                MessageBox.Show("Can't update backward date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtEffectiveDate.Focus();
                return false;
            }
            
            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save()
        {
            DiscountASGBrandEMI oDiscountASGBrandEMI = (DiscountASGBrandEMI)this.Tag;

            oDiscountASGBrandEMI.EffectiveDate = dtEffectiveDate.Value.Date;
            if (chkIsActive.Checked)
            {
                oDiscountASGBrandEMI.IsActive = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                oDiscountASGBrandEMI.IsActive = (int)Dictionary.YesOrNoStatus.NO;
            }
            if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
            {
                oDiscountASGBrandEMI.Status = (int)Dictionary.BankDiscountStatus.Create;
            }
            else if (_nStatus == (int)Dictionary.BankDiscountStatus.Approved)
            {
                oDiscountASGBrandEMI.Status = (int)Dictionary.BankDiscountStatus.Approved; 
            }
            oDiscountASGBrandEMI.CreateUserID = Utility.UserId;
            oDiscountASGBrandEMI.CreateDate = DateTime.Now;
            oDiscountASGBrandEMI.UpdateUserID = Utility.UserId;
            oDiscountASGBrandEMI.UpdateDate = DateTime.Now;

            try
            {
                DBController.Instance.BeginNewTransaction();
                if (_dEffectiveDate.Date == dtEffectiveDate.Value.Date)
                {
                    oDiscountASGBrandEMI.EditByASGBrandEMI();
                }
                else
                {
                    oDiscountASGBrandEMI.UpdateIsActive();
                    oDiscountASGBrandEMI.Add();
                }

                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Update The Transaction: " + oDiscountASGBrandEMI.ID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private void frmDiscountASGBrandEMIEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
