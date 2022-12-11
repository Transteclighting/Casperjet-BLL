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
    public partial class frmFixedAssetTypes : Form
    {
        FixedAssetTypes oFixedAssetTypes;
        public FixedAssetType _oFixedAssetType;
        bool _bIsPopUp = false;

        public frmFixedAssetTypes(bool IsPopUp)
        {
            InitializeComponent();
            _bIsPopUp = IsPopUp;
        }

        private void frmFixedAssetTypes_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            oFixedAssetTypes = new FixedAssetTypes();
            DBController.Instance.OpenNewConnection();
            oFixedAssetTypes.Refresh();          
            lvwAssetTypeList.Items.Clear();

            foreach (FixedAssetType oFixedAssetType in oFixedAssetTypes)
            {
                ListViewItem oItem = lvwAssetTypeList.Items.Add(oFixedAssetType.FATypeCode);
                oItem.SubItems.Add(oFixedAssetType.FATypeName);
                oItem.SubItems.Add(oFixedAssetType.FATypeGroup);

                oItem.Tag = oFixedAssetType;
            }
            this.Text = "Fixed Asset Type " + "[" + oFixedAssetTypes.Count + "]";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFixedAssetType ofrmFixedAssetType = new frmFixedAssetType();
            ofrmFixedAssetType.ShowDialog();
            RefreshData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwAssetTypeList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Type to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FixedAssetType oFixedAssetType = (FixedAssetType)lvwAssetTypeList.SelectedItems[0].Tag;
            frmFixedAssetType ofrmFixedAssetType = new frmFixedAssetType();
            ofrmFixedAssetType.ShowDialog(oFixedAssetType);
            RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvwAssetTypeList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Type to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FixedAssetType oFixedAssetType = (FixedAssetType)lvwAssetTypeList.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Type: " + oFixedAssetType.FATypeName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oFixedAssetType.Delete();
                    DBController.Instance.CommitTransaction();
                    RefreshData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void lvwAssetTypeList_DoubleClick(object sender, EventArgs e)
        {
            if (_bIsPopUp)
            {
                _oFixedAssetType = (FixedAssetType)lvwAssetTypeList.SelectedItems[0].Tag;
                this.Close();
            }
            else
            {
                FixedAssetType oFixedAssetType = (FixedAssetType)lvwAssetTypeList.SelectedItems[0].Tag;
                frmFixedAssetType ofrmFixedAssetType = new frmFixedAssetType();
                ofrmFixedAssetType.ShowDialog(oFixedAssetType);
                RefreshData();
            }
        }

      
    }
}