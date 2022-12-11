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
    public partial class frmChildStore : Form 
    {
        Stores _oParentStores;
        Store _oParentStore;
        public frmChildStore()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //Parent Store
            _oParentStores = new Stores();
            _oParentStores.GetParentStore();

            foreach (Store oParentStore in _oParentStores)
            {
                cmbParentStore.Items.Add(oParentStore.StoreName);

            }
            cmbParentStore.Items.Add("Select.....");
            cmbParentStore.SelectedIndex = _oParentStores.Count;

        }
        public void ShowDialog(Store oStore)
        {
            this.Tag = oStore;

            LoadCombos();

            txtPStoreCode.Text = oStore.StoreCode;
            txtPStoreName.Text = oStore.ChildSotre;

            _oParentStore = new Store();
            _oParentStore.StoreID = oStore.ParentID;
            cmbParentStore.SelectedIndex = _oParentStores.GetIndex(_oParentStore.StoreID);

            txtPStoreCode.Enabled = false;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtPStoreCode.Text.Trim() == "" || txtPStoreCode.Text == null)
            {
                MessageBox.Show("Please enter Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPStoreCode.Focus();
                return false;
            }
            if (txtPStoreName.Text.Trim() == "" || txtPStoreName.Text == null)
            {
                MessageBox.Show("Please enter Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPStoreName.Focus();
                return false;
            }
            if (cmbParentStore.Text == "" || cmbParentStore.Text == "Select.....")
            {
                MessageBox.Show("Please Select Parent Store", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbParentStore.Focus();
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
            if (this.Tag == null)
            {


                Store oStore = new Store();
                oStore.StoreCode = txtPStoreCode.Text;
                oStore.StoreName = txtPStoreName.Text;
                oStore.Category=(int)Dictionary.StoreCategory.Child;

                Store _oStore =_oParentStores[cmbParentStore.SelectedIndex];
                oStore.ParentID = _oStore.StoreID;

                 
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oStore.CheckStoreName())
                    {
                        oStore.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  
                    }
                    else
                    {

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
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
                Store oStore = (Store)this.Tag;
                
                {
                    oStore.StoreCode = txtPStoreCode.Text;
                    oStore.StoreName = txtPStoreName.Text;
                    oStore.Category = (int)Dictionary.StoreCategory.Child;

                    Store _oStore = _oParentStores[cmbParentStore.SelectedIndex];
                    oStore.ParentID = _oStore.StoreID;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        if (oStore.CheckStoreName())
                        {
                            oStore.Edit();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();  
                        }
                        else
                        {

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
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

        private void frmChildStore_Load(object sender, EventArgs e)
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
