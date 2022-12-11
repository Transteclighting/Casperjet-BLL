// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 04, 2014
// Time :  03:00 PM
// Description: UI for Discount Reason
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;  


namespace CJ.Win.POS
{
    public partial class frmDiscountReason : Form
    {

        DiscountReason _oDiscountReason;
        DiscountReasons _oDiscountReasons;
        DataTran _oDataTran;
        DataSyncManager _oDataSyncManager;

        public frmDiscountReason()
        {
            InitializeComponent();
        }

        public void ShowDialog(DiscountReason oDiscountReason)
        {

            this.Tag = oDiscountReason;
            txtDiscountReason.Text = oDiscountReason.Description;
            if (oDiscountReason.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                rdoActive.Checked = true;
                rdoInActive.Checked = false;
            }
            else
            {
                rdoActive.Checked = false;
                rdoInActive.Checked = true;
            }


            this.ShowDialog();
        }
        
        public bool UIValidation()
        {
            if (txtDiscountReason.Text.Trim()=="")
            {
                MessageBox.Show("Please Enter Payment Mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscountReason.Focus();
                return false;
            }
            
            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                if (this.Tag != null)
                {

                    DiscountReason oDiscountReason = (DiscountReason)this.Tag;

                    oDiscountReason.Description = txtDiscountReason.Text;
                    oDiscountReason.UpdateUserID = Utility.UserId;
                    oDiscountReason.UpdateDate = DateTime.Now;

                    if (rdoActive.Checked == true)
                    {
                        oDiscountReason.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                    }
                    else
                    {
                        oDiscountReason.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                    }
                     
                    try
                    {
                        _oDataSyncManager = new DataSyncManager();
                        DBController.Instance.BeginNewTransaction();
                        oDiscountReason.Update();
                        _oDataSyncManager.SendDiscountReasonToShowroom(oDiscountReason, Dictionary.DataTransferType.Edit);
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    _oDiscountReason = new DiscountReason();
                    _oDataSyncManager = new DataSyncManager();
                    _oDiscountReason.Description = txtDiscountReason.Text;
                    _oDiscountReason.CreateUserID = Utility.UserId;
                    _oDiscountReason.CreateDate = DateTime.Now;
                    _oDiscountReason.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oDiscountReason.Add();

                        _oDataSyncManager.SendDiscountReasonToShowroom(_oDiscountReason, Dictionary.DataTransferType.Add);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDiscountReason_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                this.Text = "Edit Discount Reason";
                rdoInActive.Visible = true;
                rdoActive.Visible = true;
            }
            else
            {
                this.Text = "Add Discount Reason";
                rdoInActive.Visible = false;
                rdoActive.Visible = false;
            }
        }
    }
}