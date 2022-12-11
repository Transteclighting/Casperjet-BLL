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
    public partial class frmSPMainCat : Form
    {
        public bool isAnyActivityDone = false;
        public frmSPMainCat()
        {
            InitializeComponent();
        }
      
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtMainCatName.Text == "" ||txtMainCatName.Text==null)
            {
                MessageBox.Show("Please enter Main Category Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public void ShowDialog(SPGroup oSPGroup)
        {
            this.Tag = oSPGroup;
            txtMainCatName.Text = oSPGroup.Name;
            this.ShowDialog();
        }
        private void Save()
        {
            isAnyActivityDone = true;
            if (this.Tag == null)
            {               
                SPGroup oSPGroup = new SPGroup();

                oSPGroup.Name = txtMainCatName.Text;
                oSPGroup.GroupCategory = (int)Dictionary.SparePartsGroupCategory.MainCategory;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oSPGroup.CheckSPGroupName())
                    {
                        
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //return;
                    }
                    else
                    {
                        oSPGroup.Add();

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
                SPGroup oSPGroup = (SPGroup)this.Tag;

                {

                    oSPGroup.Name = txtMainCatName.Text;
                    oSPGroup.GroupCategory = (int)Dictionary.SparePartsGroupCategory.MainCategory;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        if (oSPGroup.CheckSPGroupName())
                        {
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            oSPGroup.Edit();

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

    }
        
}