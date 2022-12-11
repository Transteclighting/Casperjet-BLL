
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
    public partial class frmStore : Form
    {
        Stores _oParentStores;
        Stores _oChildStores;
        Store _oParentStore;

        public frmStore()
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
        private void cmbParentStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParentStore.Text != "Select.....")
            {
                //Child Store
                _oChildStores = new Stores();
                _oChildStores.GetChildStore(_oParentStores[cmbParentStore.SelectedIndex].StoreID);
                cmbChildStore.Items.Clear();
                foreach (Store oChildStore in _oChildStores)
                {
                    cmbChildStore.Items.Add(oChildStore.StoreName);
                }
                if (_oChildStores.Count > 0) cmbChildStore.SelectedIndex = 0;
            }
            else
            {
                cmbChildStore.Items.Clear();
            }
        }
        public void ShowDialog(Store oStore)
        {
            this.Tag = oStore;
            LoadCombos();

            txtPStoreCode.Text = oStore.StoreCode;
            txtStoreName.Text = oStore.StoreName;

            _oParentStore = new Store();
            _oParentStore.StoreID = oStore.StoreID;
            _oParentStore.GetParentID(_oParentStore.StoreID);

            _oParentStore.GetParentID(_oParentStore.ParentID);

            cmbParentStore.SelectedIndex = _oParentStores.GetIndex(_oParentStore.ParentID);
            cmbParentStore_SelectedIndexChanged(null, null);
            cmbChildStore.SelectedIndex = _oChildStores.GetIndex(_oParentStore.StoreID);

            this.ShowDialog();
        }
      
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtPStoreCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Store Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPStoreCode.Focus();
                return false;
            }

            if (txtStoreName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Store Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreName.Focus();
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
                oStore.StoreName =txtStoreName.Text;
                Store _oStore = _oChildStores[cmbChildStore.SelectedIndex];
                oStore.ParentID = _oStore.StoreID;
                oStore.Category = (int)Dictionary.StoreCategory.Transaction;
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
                    oStore.StoreName = txtStoreName.Text;
                    Store _oStore = _oChildStores[cmbChildStore.SelectedIndex];
                    oStore.ParentID = _oStore.StoreID;
                    oStore.Category = (int)Dictionary.StoreCategory.Transaction;
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

        private void frmStore_Load(object sender, EventArgs e)
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
