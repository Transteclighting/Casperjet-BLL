using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.Admin;
using CJ.Class;

namespace CJ.Win.Admin
{
    public partial class frmFixedAssetType : Form
    {
        FixedAssetType _oFixedAssetType;

        public frmFixedAssetType()
        {
            InitializeComponent();
        }
       
        public void ShowDialog(FixedAssetType oFixedAssetType)
        {
            this.Tag = oFixedAssetType;

            txtCode.Text = oFixedAssetType.FATypeCode;
            txtName.Text = oFixedAssetType.FATypeName;
            txtGroup.Text = oFixedAssetType.FATypeGroup;
           
            this.ShowDialog();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (UIValidation())
                {
                    _oFixedAssetType = new FixedAssetType();

                    _oFixedAssetType.FATypeCode = txtCode.Text;
                    _oFixedAssetType.FATypeName = txtName.Text;
                    _oFixedAssetType.FATypeGroup = txtGroup.Text;

                    if (_oFixedAssetType.CheckCode())
                    {
                        try
                        {
                            DBController.Instance.BeginNewTransaction();
                            _oFixedAssetType.Add();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Save The Type", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You enter duplicate Code, ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCode.Focus();
                    }
                }
            }
            else
            {
                if (UIValidation())
                {
                    _oFixedAssetType = (FixedAssetType)this.Tag;
                    
                    _oFixedAssetType.FATypeName = txtName.Text;
                    _oFixedAssetType.FATypeGroup = txtGroup.Text;

                    if (_oFixedAssetType.FATypeCode != txtCode.Text)
                    {
                        if (_oFixedAssetType.CheckCode())
                        {
                            _oFixedAssetType.FATypeCode = txtCode.Text;
                        }
                        else
                        {
                            MessageBox.Show("You enter duplicate Code, ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return;
                        }
                    }
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oFixedAssetType.Edit();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Update The Type", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool UIValidation()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Type Name ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtGroup.Text == "")
            {
                MessageBox.Show("Please enter Type Group ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGroup.Focus();
                return false;
            }         
            return true;
        }
    }
}