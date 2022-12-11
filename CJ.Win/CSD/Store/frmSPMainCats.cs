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
    public partial class frmSPMainCats : Form
    {

        public frmSPMainCats()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {

            SPGroups oSPMainCats = new SPGroups();

            lvwSPMainCats.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSPMainCats.RefreshMain(txtMainCatName.Text);

            this.Text = "Total " + "[" + oSPMainCats.Count + "]";
            foreach (SPGroup oSPMainCat in oSPMainCats)
            {
                ListViewItem oItem = lvwSPMainCats.Items.Add(oSPMainCat.Name.ToString());
                oItem.SubItems.Add(oSPMainCat.User.Username.ToString());
                oItem.SubItems.Add(oSPMainCat.CreateDate.ToString("dd-MMM-yyyy"));

                oItem.Tag = oSPMainCat;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSPMainCat oForm = new frmSPMainCat();
            oForm.ShowDialog();
            if (oForm.isAnyActivityDone)
            {
                DataLoadControl();
            }

        }

        private void frmSPMainCats_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSPMainCats.SelectedItems.Count != 0)
            {

                SPGroup oSPMainCat = (SPGroup)lvwSPMainCats.SelectedItems[0].Tag;

                frmSPMainCat oForm = new frmSPMainCat();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Spare Parts Main Categroy";
                oForm.ShowDialog(oSPMainCat);
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

        private void lvwSPMainCats_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSPMainCats.SelectedItems.Count != 0)
            {
                SPGroup oSPMainCat = (SPGroup)lvwSPMainCats.SelectedItems[0].Tag;

                frmSPMainCat oForm = new frmSPMainCat();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Spare Parts Main Categroy";
                oForm.ShowDialog(oSPMainCat);
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