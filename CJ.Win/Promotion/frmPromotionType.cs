
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;  
using CJ.Class.Promotion;


namespace CJ.Win.Promotion
{
    public partial class frmPromotionType : Form
    {

        SalesPromotionType _oSalesPromotionType;
        SalesPromotionTypes _oSalesPromotionTypes;
        DataTran _oDataTran;
        DataSyncManager _oDataSyncManager;

        public frmPromotionType()
        {
            InitializeComponent();
        }

        public void ShowDialog(SalesPromotionType oSalesPromotionType)
        {

            this.Tag = oSalesPromotionType;
            txtPromotionType.Text = oSalesPromotionType.SalesPromotionTypeName;
            if (oSalesPromotionType.IsActive == (int)Dictionary.YesOrNoStatus.YES)
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
            if (txtPromotionType.Text.Trim()=="")
            {
                MessageBox.Show("Please Enter Sales Promotion Type Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPromotionType.Focus();
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

                    SalesPromotionType oSalesPromotionType = (SalesPromotionType)this.Tag;

                    oSalesPromotionType.SalesPromotionTypeName = txtPromotionType.Text;
                    oSalesPromotionType.UpdateUserID = Utility.UserId;
                    oSalesPromotionType.UpdateDate = DateTime.Now;

                    if (rdoActive.Checked == true)
                    {
                        oSalesPromotionType.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                    }
                    else
                    {
                        oSalesPromotionType.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                    }
                     
                    try
                    {
                        _oDataSyncManager = new DataSyncManager();
                        DBController.Instance.BeginNewTransaction();
                        oSalesPromotionType.Edit();
                        _oDataSyncManager.SendSalesPromotionTypeToShowroom(oSalesPromotionType, Dictionary.DataTransferType.Edit);
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
                    _oSalesPromotionType = new SalesPromotionType();
                    _oDataSyncManager = new DataSyncManager();
                    _oSalesPromotionType.SalesPromotionTypeName = txtPromotionType.Text;
                    _oSalesPromotionType.CreateUserID = Utility.UserId;
                    _oSalesPromotionType.CreateDate = DateTime.Now;
                    _oSalesPromotionType.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oSalesPromotionType.Add();

                        _oDataSyncManager.SendSalesPromotionTypeToShowroom(_oSalesPromotionType, Dictionary.DataTransferType.Add);

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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPromotionType_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                this.Text = "Edit Sales Promotion Type";
                rdoInActive.Visible = true;
                rdoActive.Visible = true;
            }
            else
            {
                this.Text = "Add Sales Promotion Type";
                rdoInActive.Visible = false;
                rdoActive.Visible = false;
            }
        }
    }
}