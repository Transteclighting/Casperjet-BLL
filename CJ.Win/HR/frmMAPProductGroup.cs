using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;

namespace CJ.Win.HR
{
    public partial class frmMAPProductGroup : Form
    {
        Brands oBrands;
        ProductGroups oProductGroups;
        MapProductGroup oMapProductGroup;
        MapProductGroups MapProductGroups;
        MapProductGroupItem oMapProductGroupItem;
        int nID = 0;

        public void ShowDialog(MapProductGroup _oMapProductGroup)
        {
            Loadlvw();
            this.Tag = _oMapProductGroup;
            int nEMPType = _oMapProductGroup.MapEmployeeType;
            int nGroupType = _oMapProductGroup.MapGroupType;

            cmbEMPType.SelectedIndex = nEMPType - 1;
            cmbDatatype.SelectedIndex = nGroupType - 1;
            nID = _oMapProductGroup.ID;
            txtRemarks.Text = _oMapProductGroup.Remarks;
            txtSort.Text = _oMapProductGroup.Sort.ToString();
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = _oMapProductGroup.EmployeeID;
            oEmployee.Refresh();
            ctlEmployee.txtCode.Text = oEmployee.EmployeeCode;
            _oMapProductGroup.GetDataItem(nID);


            if (cmbEMPType.SelectedIndex + 1 == (int)Dictionary.MapGroupType.Brand)
            {
                for (int i = 0; i < lvwPGType.Items.Count; i++)
                {
                    Brand oBrand = (Brand)lvwPGType.Items[i].Tag;
                    foreach (MapProductGroupItem oItem in _oMapProductGroup)
                    {
                        if (oBrand.BrandID == oItem.DataID)
                        {
                            lvwPGType.Items[i].Checked = true;
                        }
                    }
                }
            }
            else if (cmbEMPType.SelectedIndex + 1 == (int)Dictionary.MapGroupType.MAG)
            {
                for (int i = 0; i < lvwPGType.Items.Count; i++)
                {
                    ProductGroup _oProductGroup = (ProductGroup)lvwPGType.Items[i].Tag;
                    foreach (MapProductGroupItem oItem in _oMapProductGroup)
                    {
                        if (_oProductGroup.PdtGroupID == oItem.DataID)
                        {
                            lvwPGType.Items[i].Checked = true;
                        }
                    }
                }
            }

            if (_oMapProductGroup.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            this.ShowDialog();

        }
        public frmMAPProductGroup()
        {
            InitializeComponent();
        }

        private void chkPGAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPGAll.Checked == true)
            {
                for (int i = 0; i < lvwPGType.Items.Count; i++)
                {
                    ListViewItem itm = lvwPGType.Items[i];
                    lvwPGType.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lvwPGType.Items.Count; i++)
                {
                    ListViewItem itm = lvwPGType.Items[i];
                    lvwPGType.Items[i].Checked = false;

                }
            }
        }
        public void Loadlvw()
        {
            DBController.Instance.OpenNewConnection();

            cmbEMPType.Items.Clear();
            //cmbEMPType.Items.Add("<All>");
            // EMPType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MapEmployeeType)))
            {
                cmbEMPType.Items.Add(Enum.GetName(typeof(Dictionary.MapEmployeeType), GetEnum));
            }
            cmbEMPType.SelectedIndex = 0;

            cmbDatatype.Items.Clear();
            // DataType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MapGroupType)))
            {
                cmbDatatype.Items.Add(Enum.GetName(typeof(Dictionary.MapGroupType), GetEnum));
            }
            cmbDatatype.SelectedIndex = 0;

            if (cmbDatatype.SelectedIndex + 1  == (int)Dictionary.MapGroupType.Brand)
            {

                oBrands = new Brands();
                oBrands.GetBrand();
                lvwPGType.Items.Clear();
                foreach (Brand oBrand in oBrands)
                {
                    ListViewItem oItem = lvwPGType.Items.Add(oBrand.BrandDesc);
                    //oItem.SubItems.Add(oChannel.ChannelDescription);
                    oItem.Tag = oBrand;
                }
            }
            else
            {

                oProductGroups = new ProductGroups();
                oProductGroups.GetMAG();
                lvwPGType.Items.Clear();
                foreach (ProductGroup oProductGroup in oProductGroups)
                {
                    ListViewItem oItem = lvwPGType.Items.Add(oProductGroup.PdtGroupName);
                    //oItem.SubItems.Add(oWarehouse.WarehouseName);
                    oItem.Tag = oProductGroup;
                }
            }

        }

        private void frmMAPProductGroup_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add";
                Loadlvw();
            }
            else
            {
                this.Text = "Edit";
            }

        }
        public bool validateUIInput()
        {
            int nCount = 0;
            
            for (int i = 0; i < lvwPGType.Items.Count; i++)
            {
                ListViewItem itm = lvwPGType.Items[i];
                if (lvwPGType.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Select at least one Brand/PG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public MapProductGroup GetUIData(MapProductGroup oMapProductGroup)
        {
            oMapProductGroup.EmployeeID = ctlEmployee.SelectedEmployee.EmployeeID;
            oMapProductGroup.MapEmployeeType = cmbEMPType.SelectedIndex + 1 ;
            oMapProductGroup.MapGroupType = cmbDatatype.SelectedIndex + 1;
            oMapProductGroup.Remarks = txtRemarks.Text;
            oMapProductGroup.Sort = Convert.ToInt32(txtSort.Text);

            if (chkIsActive.Checked == true)
            {
                oMapProductGroup.IsActive = (int)Dictionary.YesOrNoStatus.YES; 
            }
            else
            {
                oMapProductGroup.IsActive = (int)Dictionary.YesOrNoStatus.NO;
            }
            if (cmbDatatype.SelectedIndex + 1 == (int)Dictionary.MapGroupType.Brand)
            {

                // Brand 
                //oMapProductGroup.MapProductGroupItems.Clear();
                for (int i = 0; i < lvwPGType.Items.Count; i++)
                {
                    ListViewItem itm = lvwPGType.Items[i];
                    if (lvwPGType.Items[i].Checked == true)
                    {
                        Brand oBrand = (Brand)lvwPGType.Items[i].Tag;
                        MapProductGroupItem oMapProductGroupItem = new MapProductGroupItem();
                        oMapProductGroupItem.DataID = oBrand.BrandID;

                        oMapProductGroup.Add(oMapProductGroupItem);
                    }
                }
            }
            else
            {

                // MAG 
                //oMapProductGroup.MapProductGroupItems.Clear();
                for (int i = 0; i < lvwPGType.Items.Count; i++)
                {
                    ListViewItem itm = lvwPGType.Items[i];
                    if (lvwPGType.Items[i].Checked == true)
                    {
                        ProductGroup oProductGroup = (ProductGroup)lvwPGType.Items[i].Tag;
                        MapProductGroupItem oMapProductGroupItem = new MapProductGroupItem();
                        oMapProductGroupItem.DataID = oProductGroup.PdtGroupID;

                        oMapProductGroup.Add(oMapProductGroupItem);
                    }
                }
            }

            return oMapProductGroup;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (validateUIInput())
                {
                    oMapProductGroup = new MapProductGroup();
                    oMapProductGroup = GetUIData(oMapProductGroup);

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oMapProductGroup.Insert();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Add Job Responsibility", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
            else
            {
                oMapProductGroup = new MapProductGroup();
                if (validateUIInput())
                {
                    oMapProductGroup = GetUIData(oMapProductGroup);

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oMapProductGroup.Edit(nID);
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Update The Job Responsibility", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }

        }

        private void cmbDatatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            if (cmbDatatype.SelectedIndex + 1 == (int)Dictionary.MapGroupType.Brand)
            {

                oBrands = new Brands();
                oBrands.GetAllBrand();
                lvwPGType.Items.Clear();
                foreach (Brand oBrand in oBrands)
                {
                    ListViewItem oItem = lvwPGType.Items.Add(oBrand.BrandDesc);
                    oItem.Tag = oBrand;
                }
            }
            else
            {

                oProductGroups = new ProductGroups();
                oProductGroups.GetMAG();
                lvwPGType.Items.Clear();
                foreach (ProductGroup oProductGroup in oProductGroups)
                {
                    ListViewItem oItem = lvwPGType.Items.Add(oProductGroup.PdtGroupName);
                    oItem.Tag = oProductGroup;
                }
            }

        }
    }
}