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
using CJ.Win.Security;
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmBankDiscounts : Form
    {
        private PromoDiscountBank oDiscountBank;
        private PromoDiscountBanks _oDiscountBanks;
        Banks oBanks;
        ProductGroups oProductGroups;
        Brands oBrands;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        bool IsCheck = false;
        public frmBankDiscounts()
        {
            InitializeComponent();
        }

        private void frmBankDiscounts_Load(object sender, EventArgs e)
        {
            UpdateSecurity();
            //LoadCombos();
            //LoadData();
            if (this.Tag == null)
            {
                LoadCombos();
            }
            LoadData();

        }
        private void UpdateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M26.7.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M26.7.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M26.7.3" == sPermissionKey)
                    {
                        btnApproved.Enabled = true;
                    }
                }
            }
        }
        private void LoadCombos()
        {
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("ALL");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;


            oBanks = new Banks();
            oBanks.Refresh();
            cmbBank.Items.Clear();
            cmbBank.Items.Add("ALL");
            foreach (Bank oBank in oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;

            oBrands = new Brands();
            oBrands.GetMasterBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("ALL");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("ALL");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.BankDiscountStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.BankDiscountStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("ALL");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;
        }
        private void LoadData()
        {
            _oDiscountBanks = new PromoDiscountBanks();
            lvwBankDiscount.Items.Clear();
            int nPGID = 0;
            if (cmbPG.SelectedIndex == 0)
            {
                nPGID = -1;
            }
            else
            {
                nPGID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;
            }

            int nMAGID = 0;
            if (cmbMAG.SelectedIndex == 0)
            {
                nMAGID = -1;
            }
            else
            {
                nMAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
            }

            int nASGID = 0;
            if (cmbASG.SelectedIndex == 0)
            {
                nASGID = -1;
            }
            else
            {
                nASGID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;
            }

            int nAGID = 0;
            if (cmbAG.SelectedIndex == 0)
            {
                nAGID = -1;
            }
            else
            {
                nAGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;
            }

            int nBankID = 0;
            if (cmbBank.SelectedIndex == 0)
            {
                nBankID = -1;
            }
            else
            {
                nBankID = oBanks[cmbBank.SelectedIndex -1].BankID;
            }
            int nBarndID = 0;
            if (cmbBrand.SelectedIndex == 0)
            {
                nBarndID = -1;
            }
            else
            {
                nBarndID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }

            int nStatus = -1;
            if (cmbStatus.SelectedIndex != 0)
            {
                nStatus = cmbStatus.SelectedIndex;
            }
            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex -1;
            }


            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oDiscountBanks.RefreshByBank(nPGID, nMAGID, nASGID, nAGID, nBankID, nBarndID, nStatus, nIsActive, dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck);
            this.Text = "Total" + "[" + _oDiscountBanks.Count + "]";

            foreach (PromoDiscountBank oDiscountBank in _oDiscountBanks)
            {
                ListViewItem oItem = lvwBankDiscount.Items.Add(oDiscountBank.PGName);
                oItem.SubItems.Add(oDiscountBank.MAGName);
                oItem.SubItems.Add(oDiscountBank.ASGName);
                oItem.SubItems.Add(oDiscountBank.AGName);
                oItem.SubItems.Add(oDiscountBank.Brand);
                oItem.SubItems.Add(oDiscountBank.BankName);
                oItem.SubItems.Add(oDiscountBank.FromDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDiscountBank.ToDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.BankDiscountStatus), oDiscountBank.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oDiscountBank.IsActive));
                oItem.SubItems.Add(oDiscountBank.DiscountPercent.ToString());
                oItem.SubItems.Add(oDiscountBank.CardTypeName);
                oItem.Tag = oDiscountBank;
            }
            setListViewRowColour();
        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("ALL");

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
            cmbASG.Items.Add("ALL");

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

            cmbAG.Items.Clear();
            cmbAG.Items.Add("ALL");

            if (cmbASG.SelectedIndex > 0)
            {
                //Load AG
                _oAG = new ProductGroups();
                _oAG.Refresh(_oASG[cmbASG.SelectedIndex - 1].PdtGroupID);
                foreach (ProductGroup oAG in _oAG)
                {
                    cmbAG.Items.Add(oAG.PdtGroupName);
                }
            }

            cmbAG.SelectedIndex = 0;
        }

        private void setListViewRowColour()
        {
            if (lvwBankDiscount.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwBankDiscount.Items)
                {
                    if (oItem.SubItems[8].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[8].Text == "Create")
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBankDiscount frmBankDiscount = new frmBankDiscount((int)Dictionary.BankDiscountStatus.Create);
            frmBankDiscount.ShowDialog();
            if (frmBankDiscount._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBankDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PromoDiscountBank _oDiscountBank = (PromoDiscountBank)lvwBankDiscount.SelectedItems[0].Tag;
            if (_oDiscountBank.Status == ((int)Dictionary.BankDiscountStatus.Create))
            {
                frmBankDiscountEdit ofrmBankDiscountEdit = new frmBankDiscountEdit((int)Dictionary.BankDiscountStatus.Create);
                ofrmBankDiscountEdit.ShowDialog(_oDiscountBank);
                if (ofrmBankDiscountEdit._bActionSave)
                    LoadData();
            }
            else
            {
                MessageBox.Show("Only create status can be edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwBankDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PromoDiscountBank _oDiscountBank = (PromoDiscountBank)lvwBankDiscount.SelectedItems[0].Tag;
            if (_oDiscountBank.Status == ((int)Dictionary.BankDiscountStatus.Create))
            {
                frmBankDiscountEdit ofrmBankDiscountEdit = new frmBankDiscountEdit((int)Dictionary.BankDiscountStatus.Create);
                ofrmBankDiscountEdit.ShowDialog(_oDiscountBank);
                if (ofrmBankDiscountEdit._bActionSave)
                    LoadData();
            }
            else
            {
                MessageBox.Show("Only create status can be edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwBankDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PromoDiscountBank oDiscountBank = (PromoDiscountBank)lvwBankDiscount.SelectedItems[0].Tag;
            if (oDiscountBank.Status != ((int)Dictionary.BankDiscountStatus.Create))
            {
                MessageBox.Show("Only create status can be approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure to approve!", "Confirm To Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDiscountBank.ApprovedBank();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_PromoDiscountBank";
                        oDataTran.DataID = Convert.ToInt32(oDiscountBank.BankDiscountID);
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
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (lvwBankDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PromoDiscountBank oDiscountBank = (PromoDiscountBank)lvwBankDiscount.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure to perform this action", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    int IsActive = (int)Dictionary.IsActive.Active;
                    if (btnIsActive.Text != "Active")
                    {
                        IsActive = (int)Dictionary.IsActive.InActive;
                    }
                    oDiscountBank.IsActive = IsActive;
                    oDiscountBank.UpdateStatus();

                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_PromoDiscountBank";
                        oDataTran.DataID = Convert.ToInt32(oDiscountBank.BankDiscountID);
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
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void lvwBankDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwBankDiscount.SelectedItems.Count == 0)
            {
                return;
            }
            PromoDiscountBank oDiscountBank = (PromoDiscountBank)lvwBankDiscount.SelectedItems[0].Tag;
            try
            {
                if (oDiscountBank.IsActive == (int)Dictionary.IsActive.InActive)
                {
                    btnIsActive.Text = "Active";
                }
                else
                {
                    btnIsActive.Text = "InActive";
                }

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
