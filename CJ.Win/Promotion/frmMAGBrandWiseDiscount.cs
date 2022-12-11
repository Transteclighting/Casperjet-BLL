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
    public partial class frmMAGBrandWiseDiscount : Form
    {
        Banks oBanks;
        ProductGroups oProductGroups;
        Brands oBrands;
        int _nStatus = 0;
        DateTime _dEffectiveDate;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        public bool _bActionSave = false;

        private string checkDuplicateValue;


        public frmMAGBrandWiseDiscount(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMAGBrandWiseDiscount_Load(object sender, EventArgs e)
        {
            //if (this.Tag == null)
            //{
                LoadCombos();
            //}
        }

        private void LoadCombos()
        {
            //Load PG in combo
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("--ALL--");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;


            oBrands = new Brands();
            oBrands.GetMasterBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("--ALL--");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            cmbSalesType.Items.Clear();
            cmbSalesType.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                if (GetEnum == (int)Dictionary.SalesType.B2C || GetEnum == (int)Dictionary.SalesType.Dealer)
                {
                    cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
                }
            }
            cmbSalesType.SelectedIndex = 0;
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (cmbPG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select PG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPG.Focus();
                return false;
            }

            for (int i = 0; i < lvwMAG.Items.Count; i++)
            {
                ListViewItem item = lvwMAG.Items[i];
                if (lvwMAG.Items[i].Checked == true)
                {
                    lvwMAG.Items[i].Selected = true;
                }
            }

            if (lvwMAG.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbSalesType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Sales Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }

            if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }

            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Please enter Discount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                return false;
            }

            if (dtEffectiveDate.Value.Date < DateTime.Today.Date)
            {
                MessageBox.Show("Can't update backward date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtEffectiveDate.Focus();
                return false;
            }


            //PromoDiscountMAGBrand oPromoDiscountMAGBrand = new PromoDiscountMAGBrand();


            //for (int i = 0; i < lvwMAG.Items.Count; i++)
            //{
            //    ListViewItem item = lvwMAG.Items[i];
            //    if (lvwMAG.Items[i].Checked == true)
            //    {
            //        oPromoDiscountMAGBrand.MAGID = Convert.ToInt32(item.SubItems[0].Text.ToString());
            //        oPromoDiscountMAGBrand.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            //    }

            //    checkDuplicateValue = oPromoDiscountMAGBrand.CheckDuplicateData();

            //    if (checkDuplicateValue == "Yes")
            //    {
            //        MessageBox.Show("MAG Brand already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        cmbBrand.Focus();
            //        return false;
            //    }

            //}

            #endregion

            return true;
        }

        public void ShowDialog(PromoDiscountMAGBrand oPromoDiscountMAGBrand)
        {
            this.Tag = oPromoDiscountMAGBrand;


            LoadCombos();
            cmbPG.SelectedIndex = _oPG.GetIndex(oPromoDiscountMAGBrand.PGID) + 1;       
            
            // cmbBrand.SelectedIndex = oBrands.GetIndex(oPromoDiscountMAGBrand.BrandID);
            //cmbSalesType.SelectedIndex = _oPG.GetIndex(oPromoDiscountMAGBrand.BrandID) + 1;

            txtDiscount.Text = oPromoDiscountMAGBrand.DiscountPercent.ToString();
            dtEffectiveDate.Value = oPromoDiscountMAGBrand.EffectiveDate;

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

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPG.SelectedIndex > 0)
            {
                //Load MAG
                _oMAG = new ProductGroups();
                _oMAG.Refresh(_oPG[cmbPG.SelectedIndex - 1].PdtGroupID);
                lvwMAG.Items.Clear();
                foreach (ProductGroup oMAG in _oMAG)
                {
                    ListViewItem oItem = lvwMAG.Items.Add(oMAG.PdtGroupID.ToString());
                    oItem.SubItems.Add(oMAG.PdtGroupName.ToString());
                    oItem.Tag = oMAG;
                }
            }

            else
            {
                lvwMAG.Items.Clear();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                PromoDiscountMAGBrand oPromoDiscountMAGBrand = new PromoDiscountMAGBrand();

                for (int i = 0; i < lvwMAG.Items.Count; i++)
                {
                    ListViewItem item = lvwMAG.Items[i];
                    if (lvwMAG.Items[i].Checked == true)
                    {
                        oPromoDiscountMAGBrand.MAGID = Convert.ToInt32(item.SubItems[0].Text.ToString());

                        oPromoDiscountMAGBrand.SalesType = (int)Enum.Parse(typeof(Dictionary.SalesType), cmbSalesType.SelectedItem.ToString());

                        oPromoDiscountMAGBrand.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                        oPromoDiscountMAGBrand.EffectiveDate = dtEffectiveDate.Value.Date;
                        oPromoDiscountMAGBrand.Remarks = txtRemarks.Text.ToString();

                        oPromoDiscountMAGBrand.DiscountPercent = Convert.ToDouble(txtDiscount.Text.ToString());
                        if (chkIsActive.Checked)
                        {
                            oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                        }
                        else
                        {
                            oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                        }
                        if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
                        {
                            oPromoDiscountMAGBrand.Status = (int)Dictionary.BankDiscountStatus.Create;
                        }
                        else
                        {
                            oPromoDiscountMAGBrand.Status = (int)Dictionary.BankDiscountStatus.Approved;
                        }
                        oPromoDiscountMAGBrand.CreateUserID = Utility.UserId;
                        oPromoDiscountMAGBrand.CreateDate = DateTime.Now;

                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            oPromoDiscountMAGBrand.UpdateIsActiveForDuplicate((int)Dictionary.YesOrNoStatus.NO);

                            oPromoDiscountMAGBrand.Add();
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
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }


                    }
                }

                MessageBox.Show("Your data has been updated successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                PromoDiscountMAGBrand oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)this.Tag;
                // oDiscountBank.AGID = _oAG[cmbAG.SelectedIndex].PdtGroupID;
                oPromoDiscountMAGBrand.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                oPromoDiscountMAGBrand.EffectiveDate = dtEffectiveDate.Value;
                oPromoDiscountMAGBrand.DiscountPercent = Convert.ToDouble(txtDiscount.Text.ToString());
                oPromoDiscountMAGBrand.Remarks = txtRemarks.Text.ToString();

                if (chkIsActive.Checked)
                {
                    oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
                {
                    oPromoDiscountMAGBrand.Status = (int)Dictionary.BankDiscountStatus.Create;
                }
                else if (_nStatus == (int)Dictionary.BankDiscountStatus.Approved)
                {
                    oPromoDiscountMAGBrand.Status = (int)Dictionary.BankDiscountStatus.Approved;
                }
                oPromoDiscountMAGBrand.CreateUserID = Utility.UserId;
                oPromoDiscountMAGBrand.CreateDate = DateTime.Now;
                oPromoDiscountMAGBrand.UpdateUserID = Utility.UserId;
                oPromoDiscountMAGBrand.UpdateDate = DateTime.Now;

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    if (_dEffectiveDate.Date == dtEffectiveDate.Value.Date)
                    {
                        oPromoDiscountMAGBrand.EditByMAGBrandWiseDiscount();
                    }
                    else
                    {
                        oPromoDiscountMAGBrand.UpdateIsActiveForDuplicate((int)Dictionary.YesOrNoStatus.NO);
                        oPromoDiscountMAGBrand.Add();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You have successfully updated the transaction : " + oPromoDiscountMAGBrand.DiscountID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        int NumberOfClick = 1;
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            switch (NumberOfClick)
            {
                case 1:
                    for (int i = 0; i < lvwMAG.Items.Count; i++)
                    {
                        ListViewItem itm = lvwMAG.Items[i];
                        lvwMAG.Items[i].Checked = true;
                    }
                    ++NumberOfClick;
                    btnSelectAll.Text = "Uncheck All";
                    break;
                case 2:
                    for (int i = 0; i < lvwMAG.Items.Count; i++)
                    {
                        ListViewItem itm = lvwMAG.Items[i];
                        lvwMAG.Items[i].Checked = false;
                    }
                    --NumberOfClick;
                    btnSelectAll.Text = "Check All";
                    break;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


    }
}
