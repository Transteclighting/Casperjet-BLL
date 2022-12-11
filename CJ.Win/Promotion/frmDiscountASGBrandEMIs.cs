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

namespace CJ.Win.Promotion
{
    public partial class frmDiscountASGBrandEMIs : Form
    {
        Banks oBanks;
        ProductGroups oProductGroups;
        Brands oBrands;
        DiscountASGBrandEMIs _oDiscountASGBrandEMIs;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        public frmDiscountASGBrandEMIs()
        {
            InitializeComponent();
        }

        private void frmDiscountASGBrandEMIs_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            UpdateSecurity();
            LoadCombo();
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
                    if ("M3.28.4.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M3.28.4.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M3.28.4.3" == sPermissionKey)
                    {
                        btnApproved.Enabled = true;
                    }
                }
            }
        }
        private void LoadCombo()
        {
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("<ALL>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;

           // //Load MAG
           // _oMAG = new ProductGroups();
           // _oMAG.GETMAG();
           // cmbMAG.Items.Clear();
           // cmbMAG.Items.Add("<ALL>");

           // foreach (ProductGroup oMAG in _oMAG)
           // {
           //     cmbMAG.Items.Add(oMAG.PdtGroupName);
           // }
           // cmbMAG.SelectedIndex = 0;

           // //Load ASG
           // _oASG = new ProductGroups();
           // _oASG.GETASG();
           // cmbASG.Items.Clear();
           //cmbASG.Items.Add("<ALL>");

           // foreach (ProductGroup oASG in _oASG)
           // {
           //     cmbASG.Items.Add(oASG.PdtGroupName);
           // }
           // cmbASG.SelectedIndex = 0;

           // // Load AG 
           // oProductGroups = new ProductGroups();
           // oProductGroups.GETAGByEMITenure();
           // cmbAG.Items.Clear();
           // cmbAG.Items.Add("<ALL>");
           // foreach (ProductGroup oProductGroup in oProductGroups)
           // {
           //     cmbAG.Items.Add(oProductGroup.PdtGroupName);
           // }
           // cmbAG.SelectedIndex = 0;

            oBrands = new Brands();
            oBrands.GetAllBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<ALL>");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            cmbstatus.Items.Clear();
            cmbstatus.Items.Add("<ALL>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.BankDiscountStatus)))
            {
                cmbstatus.Items.Add(Enum.GetName(typeof(Dictionary.BankDiscountStatus), GetEnum));
            }
            cmbstatus.SelectedIndex = 0;

            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("<ALL>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;
        }
        private void LoadData()
        {
            _oDiscountASGBrandEMIs = new DiscountASGBrandEMIs();
            lvwDiscountASGBrandEMI.Items.Clear();

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
            if (cmbstatus.SelectedIndex != 0)
            {
                nStatus = cmbstatus.SelectedIndex;
            }
            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }
            DBController.Instance.OpenNewConnection();
            _oDiscountASGBrandEMIs.RefreshByEMITenure(nPGID, nMAGID, nASGID, nBarndID, nAGID, nStatus, nIsActive);
            foreach (DiscountASGBrandEMI oDiscountASGBrandEMI in _oDiscountASGBrandEMIs)
            {
                ListViewItem oItem = lvwDiscountASGBrandEMI.Items.Add(oDiscountASGBrandEMI.PGName);
                oItem.SubItems.Add(oDiscountASGBrandEMI.MAGName);
                oItem.SubItems.Add(oDiscountASGBrandEMI.ASGName);
                oItem.SubItems.Add(oDiscountASGBrandEMI.AGName);
                oItem.SubItems.Add(oDiscountASGBrandEMI.Tenure.ToString());
                oItem.SubItems.Add(oDiscountASGBrandEMI.Brand);
                oItem.SubItems.Add(oDiscountASGBrandEMI.CreateDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(oDiscountASGBrandEMI.EffectiveDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.BankDiscountStatus), oDiscountASGBrandEMI.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oDiscountASGBrandEMI.IsActive));
                oItem.Tag = oDiscountASGBrandEMI;
            }
            setListViewRowColour();
            this.Text = "ASG Brand Wise Free EMI List-" + _oDiscountASGBrandEMIs.Count + "";
        }

        private void setListViewRowColour()
        {
            if (lvwDiscountASGBrandEMI.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwDiscountASGBrandEMI.Items)
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDiscountASGBrandEMI ofrmDiscountASGBrandEMI = new frmDiscountASGBrandEMI((int)Dictionary.BankDiscountStatus.Create);
            ofrmDiscountASGBrandEMI.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDiscountASGBrandEMI.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvwDiscountASGBrandEMI.SelectedItems[0].SubItems[7].Text == "Approved")
            {
                MessageBox.Show("Can't edit as it already approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DiscountASGBrandEMI oDiscountASGBrandEMI = (DiscountASGBrandEMI)lvwDiscountASGBrandEMI.SelectedItems[0].Tag;
            frmDiscountASGBrandEMIEdit ofrmDiscountASGBrandEMI = new frmDiscountASGBrandEMIEdit((int)Dictionary.BankDiscountStatus.Create);
            ofrmDiscountASGBrandEMI.ShowDialog(oDiscountASGBrandEMI);

            LoadData();

        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwDiscountASGBrandEMI.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DiscountASGBrandEMI oDiscountASGBrandEMI = (DiscountASGBrandEMI)lvwDiscountASGBrandEMI.SelectedItems[0].Tag;
            if (oDiscountASGBrandEMI.Status == ((int)Dictionary.BankDiscountStatus.Create))
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Approved Status Can't Be Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to Approved ", "Confirm To Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDiscountASGBrandEMI.Approved();
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

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwDiscountASGBrandEMI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDiscountASGBrandEMI.SelectedItems.Count == 0)
            {
                return;
            }
            DiscountASGBrandEMI oDiscountASGBrandEMI = (DiscountASGBrandEMI)lvwDiscountASGBrandEMI.SelectedItems[0].Tag;
            try
            {
                if (oDiscountASGBrandEMI.IsActive == (int)Dictionary.IsActive.InActive)
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

        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (lvwDiscountASGBrandEMI.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DiscountASGBrandEMI oDiscountASGBrandEMI = (DiscountASGBrandEMI)lvwDiscountASGBrandEMI.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure to perform this action", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    int IsActive = 1;
                    if (btnIsActive.Text != "Active")
                    {
                        IsActive = 0;
                    }
                    oDiscountASGBrandEMI.ChangeIsActiveStatus(IsActive);
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
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
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
            cmbAG.Items.Clear();
            cmbAG.Items.Add("Select AG");

            if (cmbASG.SelectedIndex > 0)
            {
                //Load ASG
                _oAG = new ProductGroups();
                _oAG.Refresh(_oASG[cmbASG.SelectedIndex - 1].PdtGroupID);
                foreach (ProductGroup oAG in _oAG)
                {
                    cmbAG.Items.Add(oAG.PdtGroupName);
                }
            }

            cmbAG.SelectedIndex = 0;
        }
    }
}
