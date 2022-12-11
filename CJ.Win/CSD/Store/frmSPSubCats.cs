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
    public partial class frmSPSubCats : Form
    {
        SPGroups _oSPMainCats;
        
        public frmSPSubCats()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSPSubCat oForm = new frmSPSubCat();
            oForm.ShowDialog();
            if (oForm.isAnyActivityDone)
            {
                DataLoadControl();
            }            
        }
        private void LoadCombo()
        {
            _oSPMainCats = new SPGroups();
            _oSPMainCats.GetSPMainCat();
            cmbMainCategory.Items.Clear();
            cmbMainCategory.Items.Add("All");
            foreach (SPGroup oSPMainCat in _oSPMainCats)
            {
                cmbMainCategory.Items.Add(oSPMainCat.Name);
            }
            if (_oSPMainCats.Count >0)
                cmbMainCategory.SelectedIndex = 0; 
      
        }
        private void frmSPSubCats_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {

            SPGroups oSPSubCats = new SPGroups();

            lvwSPSubCats.Items.Clear();
            DBController.Instance.OpenNewConnection();
            if (cmbMainCategory.Text == "All")
            {
                oSPSubCats.RefreshSub(txtSubCatName.Text, -1);
            }
            else
            {
                oSPSubCats.RefreshSub(txtSubCatName.Text, _oSPMainCats[cmbMainCategory.SelectedIndex-1].SPGroupID);
            }
            this.Text = "Total " + "[" + oSPSubCats.Count + "]";
            foreach (SPGroup oSPSubCat in oSPSubCats)
            {
                ListViewItem oItem = lvwSPSubCats.Items.Add(oSPSubCat.Name.ToString());
                oItem.SubItems.Add(oSPSubCat.MainCatName.ToString());
                oItem.SubItems.Add(oSPSubCat.User.Username.ToString());
                oItem.SubItems.Add(oSPSubCat.CreateDate.ToString());

                oItem.Tag = oSPSubCat;
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSPSubCats.SelectedItems.Count != 0)
            {

                SPGroup oSPSubCat = (SPGroup)lvwSPSubCats.SelectedItems[0].Tag;

                frmSPSubCat oForm = new frmSPSubCat();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Spare Parts Sub Categroy";
                oForm.ShowDialog(oSPSubCat);
                if (oForm.isAnyActivityDone)
                {
                    DataLoadControl();
                }  

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwSPSubCats_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSPSubCats.SelectedItems.Count != 0)
            {
                SPGroup oSPSubCat = (SPGroup)lvwSPSubCats.SelectedItems[0].Tag;

                frmSPSubCat oForm = new frmSPSubCat();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Spare Parts Sub Categroy";
                oForm.ShowDialog(oSPSubCat);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }
    }
}