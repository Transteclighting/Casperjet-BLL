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
    public partial class frmPartsSupplier : Form
    {
        public bool _bIsActivityDone = false;
        public frmPartsSupplier()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //Category
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PartsSupplierCategory)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.PartsSupplierCategory), GetEnum));
            }
            cmbCategory.SelectedIndex = (int)Dictionary.PartsSupplierCategory.Local;
        }
        public void ShowDialog(PartsSupplier oPartsSupplier)
        {
            this.Tag = oPartsSupplier;
            LoadCombos();
           
            txtSupplierName.Text = oPartsSupplier.Name;
            txtAddress.Text = oPartsSupplier.Address;
            txtContactNo.Text = oPartsSupplier.ContactNo;
            cmbCategory.SelectedIndex = oPartsSupplier.Category;

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtSupplierName.Text == "")
            {
                MessageBox.Show("Please Input Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please Input Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please Input Contact No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
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

                PartsSupplier oPartsSupplier = new PartsSupplier();

                oPartsSupplier.Name = txtSupplierName.Text;
                oPartsSupplier.Address = txtAddress.Text;
                oPartsSupplier.ContactNo = txtContactNo.Text;
                oPartsSupplier.Category = cmbCategory.SelectedIndex;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    //if (oPartsSupplier.CheckBySupplier())
                    //{
                        oPartsSupplier.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  
                    //}
                    //else
                    //{

                    //    DBController.Instance.CommitTransaction();
                    //    MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return;
                    //}

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                PartsSupplier oPartsSupplier = (PartsSupplier)this.Tag;                
                {
                    oPartsSupplier.Name = txtSupplierName.Text;
                    oPartsSupplier.Address = txtAddress.Text;
                    oPartsSupplier.ContactNo = txtContactNo.Text;
                    oPartsSupplier.Category = cmbCategory.SelectedIndex;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        //if (oPartsSupplier.CheckBySupplier())
                        //{
                            oPartsSupplier.Edit();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _bIsActivityDone = true;
                        //}
                        //else
                        //{
                        //    DBController.Instance.CommitTransaction();
                        //    MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //    return;
                        //}

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }

        private void frmPartsSupplier_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            else
            { 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
        
}
