using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmSPSubCat : Form
    {
        public bool isAnyActivityDone = false;
        SPGroups _oSPMainCats;
        SPGroups _oSPSubCats;
        SPGroup _oSPSubCat;
        SPGroup _oSPMainCat;

        public frmSPSubCat()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            _oSPMainCats = new SPGroups();
            _oSPMainCats.GetSPMainCat();
            //cmbMainCategory.Items.Clear();
            foreach (SPGroup oSPMainCat in _oSPMainCats)
            {
                cmbMainCategory.Items.Add(oSPMainCat.Name);
            }
            cmbMainCategory.SelectedIndex = 0; 
        }
        public void ShowDialog(SPGroup oSPSubCat)
        {
            this.Tag = oSPSubCat;
            LoadCombos();
            txtSubCatName.Text = oSPSubCat.Name;

            _oSPMainCat = new SPGroup();
            _oSPMainCat.SPGroupID = oSPSubCat.SPGroupID;
            _oSPMainCat.GetParentID(_oSPMainCat.SPGroupID);
            cmbMainCategory.SelectedIndex = _oSPMainCats.GetIndex(_oSPMainCat.ParentID);
          
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtSubCatName.Text == " " ||txtSubCatName.Text==null)
            {
                MessageBox.Show("Please enter Sub Category Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Save()
        {
            isAnyActivityDone = true;
            if (this.Tag == null)
            {

                SPGroup oSPSubCat = new SPGroup();

                oSPSubCat.Name = txtSubCatName.Text;
                oSPSubCat.SPGroupID = oSPSubCat.SPGroupID;
                oSPSubCat.GroupCategory = (int)Dictionary.SparePartsGroupCategory.SubCategory;
                oSPSubCat.ParentID = _oSPMainCats[cmbMainCategory.SelectedIndex].SPGroupID;
                
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oSPSubCat.CheckSPGroupName())
                    {
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //return;
                    }
                    else
                    {
                        oSPSubCat.Add();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  
                    }

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                SPGroup oSPSubCat = (SPGroup)this.Tag;

                {
                    oSPSubCat.Name = txtSubCatName.Text;
                    oSPSubCat.SPGroupID = oSPSubCat.SPGroupID;
                    oSPSubCat.GroupCategory = (int)Dictionary.SparePartsGroupCategory.SubCategory;
                    oSPSubCat.ParentID = _oSPMainCats[cmbMainCategory.SelectedIndex].SPGroupID;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        if (oSPSubCat.CheckSPGroupName())
                        {
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //return;
                        }
                        else
                        {
                            oSPSubCat.Edit();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();
                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSPSubCat_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            else
            { 
            }
        }


    }
        
}