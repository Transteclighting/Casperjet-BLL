using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.POS;

namespace CJ.Win.Admin
{
    public partial class frmOfficeItem : Form
    {
        OfficeItem oOfficeItem;
        OfficeItems oOfficeItems;
        DataSyncManager _oDataSyncManager;

        public frmOfficeItem()
        {
            InitializeComponent();
        }

        public void ShowDialog(OfficeItem oOfficeItem)
        {
            this.Tag = oOfficeItem;
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            txtCode.Text = oOfficeItem.Code;
            txtName.Text = oOfficeItem.ArticlesName;
            cmbCategory.SelectedIndex = oOfficeItem.Category;
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Item Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Item Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            #endregion

            return true;
        }
        private void LoadCombos()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("<Select Type>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OfficeItemType)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.OfficeItemType), GetEnum));
            }
            cmbCategory.SelectedIndex = 0;        
        
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
                oOfficeItem = new OfficeItem();
                oOfficeItem.Code = txtCode.Text;
                oOfficeItem.ArticlesName = txtName.Text;
                oOfficeItem.Category = cmbCategory.SelectedIndex;
                oOfficeItem.CreateDate = DateTime.Now;
                oOfficeItem.CreateUserID = Utility.UserId;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oDataSyncManager = new DataSyncManager();
                    oOfficeItem.Add();
                    _oDataSyncManager.SendOfficeItemToShowroom(oOfficeItem, Dictionary.DataTransferType.Add);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Data Save Successfully. Item Code: " + oOfficeItem.Code, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {

                oOfficeItem = (OfficeItem)this.Tag;
                oOfficeItem.Code = txtCode.Text;
                oOfficeItem.ArticlesName = txtName.Text;
                oOfficeItem.Category = cmbCategory.SelectedIndex;
                oOfficeItem.UpdateDate = DateTime.Now;
                oOfficeItem.UpdateUserID = Utility.UserId;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oDataSyncManager = new DataSyncManager();
                    oOfficeItem.Edit();
                    _oDataSyncManager.SendOfficeItemToShowroom(oOfficeItem, Dictionary.DataTransferType.Edit);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Data Update Successfully. Item Code: " + oOfficeItem.Code, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void frmStationaryItem_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Office Item";
                LoadCombos();
            }
            else
            {
                this.Text = "Edit Item Info";
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}