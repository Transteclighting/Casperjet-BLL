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
    public partial class frmDiscountASGBrandEMI : Form
    {
        EMITenures _oEMITenures;
        ProductGroups oProductGroups;
        Brands _oBrands;
        int _nStatus = 0;
        DateTime _dEffectiveDate;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oAG;
        ProductGroups _oASG;
        public frmDiscountASGBrandEMI(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(DiscountASGBrandEMI oDiscountASGBrandEMI)
        {
            this.Tag = oDiscountASGBrandEMI;
            _dEffectiveDate = oDiscountASGBrandEMI.EffectiveDate;
            LoadCombos();
            cmbASG.Enabled = false;
            cmbTenure.Enabled = false;
            cmbBrand.Enabled = false;
            cmbTenure.SelectedIndex = _oEMITenures.GetIndex(oDiscountASGBrandEMI.EMITenureID) + 1;
            cmbBrand.SelectedIndex = _oBrands.GetIndex(oDiscountASGBrandEMI.BrandID) + 1;
            cmbASG.SelectedIndex = oProductGroups.GetIndex(oDiscountASGBrandEMI.AGID) + 1;
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
        private void frmDiscountASGBrandEMI_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }

        }
        private void LoadCombos()
        {
            _oEMITenures= new EMITenures();
            _oEMITenures.RefreshByTenure();
            //cmbTenure.Items.Clear();
            cmbTenure.Items.Add("ALL");
            foreach (EMITenure oEMITenure in _oEMITenures)
            {
                cmbTenure.Items.Add(oEMITenure.Tenure);
            }
            cmbTenure.SelectedIndex = 0;

            _oBrands = new Brands();
            _oBrands.GetMasterBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("ALL");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("Select PG");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;
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

            if (cmbMAG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select MAG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMAG.Focus();
                return false;
            }
            if (cmbASG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select ASG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbASG.Focus();
                return false;
            }
            for (int i = 0; i < lvwAG.Items.Count; i++)
            {
                ListViewItem item = lvwAG.Items[i];
                if (lvwAG.Items[i].Checked == true)
                {
                    lvwAG.Items[i].Selected = true;
                }
            }
            if (lvwAG.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (cmbTenure.SelectedIndex == 0)
            {
                MessageBox.Show("Please select tenure", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenure.Focus();
                return false;
            }
            if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Please select brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }
            if (dtEffectiveDate.Value.Date < DateTime.Today.Date)
            {
                MessageBox.Show("Can't update backward date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtEffectiveDate.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                DiscountASGBrandEMI oDiscountASGBrandEMI = new DiscountASGBrandEMI();
                for (int i = 0; i < lvwAG.Items.Count; i++)
                {
                    ListViewItem item = lvwAG.Items[i];
                    if (lvwAG.Items[i].Checked == true)
                    {
                        oDiscountASGBrandEMI.EMITenureID = _oEMITenures[cmbTenure.SelectedIndex - 1].EMITenureID;
                        oDiscountASGBrandEMI.AGID = Convert.ToInt32(item.SubItems[0].Text.ToString());
                        oDiscountASGBrandEMI.BrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                        oDiscountASGBrandEMI.EffectiveDate = dtEffectiveDate.Value.Date;
                        if (chkIsActive.Checked)
                        {
                            oDiscountASGBrandEMI.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                        }
                        else
                        {
                            oDiscountASGBrandEMI.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                        }
                        if (_nStatus == (int)Dictionary.ASGWaiseFreeEMIStatus.Create)
                        {
                            oDiscountASGBrandEMI.Status = (int)Dictionary.ASGWaiseFreeEMIStatus.Create;
                        }
                        else
                        {
                            oDiscountASGBrandEMI.Status = (int)Dictionary.ASGWaiseFreeEMIStatus.Approved;
                        }
                        oDiscountASGBrandEMI.CreateUserID = Utility.UserId;
                        oDiscountASGBrandEMI.CreateDate = DateTime.Now;

                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            oDiscountASGBrandEMI.UpdateIsActiveForDuplicate((int)Dictionary.YesOrNoStatus.NO);

                            oDiscountASGBrandEMI.Add();
                            Showrooms oShowrooms = new Showrooms();
                            oShowrooms.Refresh();
                            foreach (Showroom oShowroom in oShowrooms)
                            {
                                CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                                oDataTran.TableName = "t_PromoDiscountASGBrandEMI";
                                oDataTran.DataID = Convert.ToInt32(oDiscountASGBrandEMI.ID);
                                oDataTran.WarehouseID = oShowroom.WarehouseID;
                                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
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

                MessageBox.Show("You have successfully save the transaction", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          //else
          //  {
          //      DiscountASGBrandEMI oDiscountASGBrandEMI = (DiscountASGBrandEMI)this.Tag;
          //      oDiscountASGBrandEMI.EMITenureID = _oEMITenures[cmbTenure.SelectedIndex - 1].EMITenureID;
          //      oDiscountASGBrandEMI.AGID = oProductGroups[cmbAG.SelectedIndex - 1].PdtGroupID;
          //      oDiscountASGBrandEMI.BrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
          //      if (chkIsActive.Checked)
          //      {
          //          oDiscountASGBrandEMI.IsActive = (int)Dictionary.YesOrNoStatus.YES;
          //      }
          //      else
          //      {
          //          oDiscountASGBrandEMI.IsActive = (int)Dictionary.YesOrNoStatus.NO;
          //      }
          //      if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
          //      {
          //          oDiscountASGBrandEMI.Status = (int)Dictionary.BankDiscountStatus.Create;
          //      }
          //      else if (_nStatus == (int)Dictionary.BankDiscountStatus.Approved)
          //      {
          //          oDiscountASGBrandEMI.Status = (int)Dictionary.BankDiscountStatus.Approved;
          //      }
          //      oDiscountASGBrandEMI.CreateUserID = Utility.UserId;
          //      oDiscountASGBrandEMI.CreateDate = DateTime.Now;
          //      oDiscountASGBrandEMI.UpdateUserID = Utility.UserId;
          //      oDiscountASGBrandEMI.UpdateDate = DateTime.Now;

          //      try
          //      {
          //          DBController.Instance.BeginNewTransaction();
          //          if (_dEffectiveDate.Date == dtEffectiveDate.Value.Date) 
          //          {
          //              oDiscountASGBrandEMI.EditByASGBrandEMI();
          //          } 
          //          else
          //          {
          //              oDiscountASGBrandEMI.UpdateIsActive();
          //              oDiscountASGBrandEMI.Add();
          //          }

          //          DBController.Instance.CommitTransaction();
          //          MessageBox.Show("You Have Successfully Update The ASG Brand Wise Discount : " + oDiscountASGBrandEMI.ID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

          //      }
          //      catch (Exception ex)
          //      {
          //          DBController.Instance.RollbackTransaction();
          //          MessageBox.Show(ex.Message, "Error!!!");
          //      }
          //  }
            
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

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("Select MAG");

            if (cmbPG.SelectedIndex > 0)
            {
                //Load MAG
                _oMAG = new ProductGroups();
                _oMAG.Refresh(_oPG[cmbPG.SelectedIndex - 1].PdtGroupID);

                foreach (ProductGroup oMAG in _oMAG)
                {
                    cmbMAG.Items.Add(oMAG.PdtGroupName);
                }
            }
            cmbMAG.SelectedIndex = 0;
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbASG.Items.Clear();
            cmbASG.Items.Add("Select ASG");

            if (cmbMAG.SelectedIndex > 0)
            {
                //Load ASG
                _oASG = new ProductGroups();
                _oASG.Refresh(_oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID);
                foreach (ProductGroup oASG in _oASG)
                {
                    cmbASG.Items.Add(oASG.PdtGroupName);
                }
            }

            cmbASG.SelectedIndex = 0;
        }

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbASG.SelectedIndex > 0)
            {
                //Load AG
                _oAG = new ProductGroups();
                _oAG.Refresh(_oASG[cmbASG.SelectedIndex - 1].PdtGroupID);
                lvwAG.Items.Clear();
                foreach (ProductGroup oAG in _oAG)
                {
                    ListViewItem oItem = lvwAG.Items.Add(oAG.PdtGroupID.ToString());
                    oItem.SubItems.Add(oAG.PdtGroupName.ToString());
                    oItem.Tag = oAG;
                }
            }

            else
            {
                lvwAG.Items.Clear();
            }
        }


        int NumberOfClick = 1;

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            switch (NumberOfClick)
            {
                case 1:
                    for (int i = 0; i < lvwAG.Items.Count; i++)
                    {
                        ListViewItem itm = lvwAG.Items[i];
                        lvwAG.Items[i].Checked = true;
                    }
                    ++NumberOfClick;
                    btnSelectAll.Text = "Uncheck All";
                    break;
                case 2:
                    for (int i = 0; i < lvwAG.Items.Count; i++)
                    {
                        ListViewItem itm = lvwAG.Items[i];
                        lvwAG.Items[i].Checked = false;
                    }
                    --NumberOfClick;
                    btnSelectAll.Text = "Check All";
                    break;
            }
        }

    }
}
