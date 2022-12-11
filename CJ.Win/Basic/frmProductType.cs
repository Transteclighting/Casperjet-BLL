using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmProductType : Form
    {
        ProductGroup _oProductGroup;
        ProductGroups _oProductGroups;
        private int _nProductGroup;
        public frmProductType(int nProductGroup)
        {
            _oProductGroup = new ProductGroup();
            _oProductGroups = new ProductGroups();
            _nProductGroup = nProductGroup;
            InitializeComponent();
        }
        private bool IsValidate()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Product Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtDesc.Text == "")
            {
                MessageBox.Show("Please enter Product Description.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }
            return true;
        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                ProductGroup oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupCode = txtCode.Text;
                oProductGroup.PdtGroupName=txtDesc.Text;
                if (_nProductGroup == 1)
                {
                    oProductGroup.PdtGroupType = 1;
                
                }
                else
                    if (_nProductGroup == 2)
                    {
                        oProductGroup.PdtGroupType = 2;

                    }
                    else
                        if (_nProductGroup == 3)
                        {
                            oProductGroup.PdtGroupType = 3;

                        }
                        else
                            if (_nProductGroup == 4)
                            {
                                oProductGroup.PdtGroupType = 4;

                            }
                            else
                                if (_nProductGroup == 5)
                                {
                                    oProductGroup.PdtGroupType = 5;

                                }
                if (_nProductGroup == 1)
                {
                    oProductGroup.ParentID = -1;

                }
                else
                {
                    oProductGroup.ParentID = _oProductGroups[cmbParent.SelectedIndex].PdtGroupID;
                }

                
                oProductGroup.POS = Convert.ToInt32(chkIsPOSActive.Checked);
                oProductGroup.IsActive = Convert.ToInt32(chkActive.Checked);
                
               
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProductGroup.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oProductGroup.PdtGroupCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                ProductGroup oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupCode = txtCode.Text;
                oProductGroup.PdtGroupName = txtDesc.Text;
                if (_nProductGroup == 1)
                {
                    oProductGroup.PdtGroupType = 1;

                }
                else
                    if (_nProductGroup == 2)
                    {
                        oProductGroup.PdtGroupType = 2;

                    }
                    else
                        if (_nProductGroup == 3)
                        {
                            oProductGroup.PdtGroupType = 3;

                        }
                        else
                            if (_nProductGroup == 4)
                            {
                                oProductGroup.PdtGroupType = 4;

                            }
                            else
                                if (_nProductGroup == 5)
                                {
                                    oProductGroup.PdtGroupType = 5;

                                }

                oProductGroup.ParentID = _oProductGroups[cmbParent.SelectedIndex].PdtGroupID;
                oProductGroup.IsActive = Convert.ToInt32(chkActive.Checked);
                oProductGroup.POS = Convert.ToInt32(chkIsPOSActive.Checked);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProductGroup.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Product : " + oProductGroup.PdtGroupCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void frmProductType_Load(object sender, EventArgs e)
        {
            if (_nProductGroup == 1)
            {
                if (this.Tag == null) this.Text = "Add New ProductGroup";
                else this.Text = "Edit ProductGroup";
                //Load Parent in combo
                _oProductGroups = new ProductGroups();
                _oProductGroups.Refresh(Dictionary.ProductGroupType.ProductGroup);
                cmbParent.Visible = false;
                lblParent.Visible = false;
               

            }
            else
                if (_nProductGroup == 2)
                {
                    if (this.Tag == null) this.Text = "Add New MAG";
                    else this.Text = "Edit MAG";
                    //Load Parent in combo
                    _oProductGroups = new ProductGroups();
                    _oProductGroups.Refresh(Dictionary.ProductGroupType.ProductGroup);
                    cmbParent.Items.Clear();
                    foreach (ProductGroup oProductGroup in _oProductGroups)
                    {
                        cmbParent.Items.Add(oProductGroup.PdtGroupName);
                    }
                    cmbParent.SelectedIndex = 0;
                }
                else
                    if (_nProductGroup == 3)
                    {
                        if (this.Tag == null) this.Text = "Add New ASG";
                        else this.Text = "Edit ASG";
                        //Load Parent in combo
                        _oProductGroups = new ProductGroups();
                        _oProductGroups.Refresh(Dictionary.ProductGroupType.MAG);
                        cmbParent.Items.Clear();
                        foreach (ProductGroup oProductGroup in _oProductGroups)
                        {
                            cmbParent.Items.Add(oProductGroup.PdtGroupName);
                        }
                        cmbParent.SelectedIndex = 0;
                    }
                    else
                        if (_nProductGroup == 4)
                        {
                            if (this.Tag == null) this.Text = "Add New AG";
                            else this.Text = "Edit AG";
                            //Load Parent in combo
                            _oProductGroups = new ProductGroups();
                            _oProductGroups.Refresh(Dictionary.ProductGroupType.ASG);
                            cmbParent.Items.Clear();
                            foreach (ProductGroup oProductGroup in _oProductGroups)
                            {
                                cmbParent.Items.Add(oProductGroup.PdtGroupName);
                            }
                            cmbParent.SelectedIndex = 0;
                        }
                        else
                            if (_nProductGroup == 5)
                            {
                                if (this.Tag == null) this.Text = "Add New Product";
                                else this.Text = "Edit Product";
                                //Load Parent in combo
                                _oProductGroups = new ProductGroups();
                                _oProductGroups.Refresh(Dictionary.ProductGroupType.AG);
                                cmbParent.Items.Clear();
                                foreach (ProductGroup oProductGroup in _oProductGroups)
                                {
                                    cmbParent.Items.Add(oProductGroup.PdtGroupName);
                                }
                                cmbParent.SelectedIndex = 0;
                            }
           
        }
        public void ShowDialog(ProductGroup oProductGroup)
        {
            this.Tag = oProductGroup;
           

            txtCode.Text = oProductGroup.PdtGroupCode;
            txtDesc.Text = oProductGroup.PdtGroupName;
            int nProductGroup = oProductGroup.PdtGroupType;

            if (nProductGroup == 2)
            {
                cmbParent.Visible = true;

                cmbParent.SelectedIndex = _oProductGroups.GetIndexByID(oProductGroup.PdtGroupID);
               
            }
            else
                if (nProductGroup == 3)
                {
                    cmbParent.Visible = true;
                    cmbParent.SelectedIndex = _oProductGroups.GetIndexByID(oProductGroup.PdtGroupID);
                    
                }
                else
                    if (nProductGroup == 4)
                    {
                        cmbParent.Visible = true;
                        cmbParent.SelectedIndex = _oProductGroups.GetIndexByID(oProductGroup.PdtGroupID);
                        
                    }
                    else
                        if (nProductGroup == 5)
                        {
                            cmbParent.Visible = true;
                            cmbParent.SelectedIndex = _oProductGroups.GetIndex(oProductGroup.PdtGroupID);
                            
                        }
                        else
                        {
                            cmbParent.Visible = false;
                        }
            if (oProductGroup.POS == 1)
            {
                chkIsPOSActive.Checked = true;
            }
            else
            {
                chkIsPOSActive.Checked = false;

            }


            if (oProductGroup.IsActive == 1)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;

            }

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}