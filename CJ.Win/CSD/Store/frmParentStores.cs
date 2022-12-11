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
    public partial class frmParentStores : Form
    {
        public frmParentStores()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {

            Stores oStores = new Stores();

            lvwParentStores.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oStores.RefreshParentStore();

            this.Text = "Total " + "[" + oStores.Count + "]";
            foreach (Store oStore in oStores)
            {
                ListViewItem oItem = lvwParentStores.Items.Add(oStore.StoreCode.ToString());
                oItem.SubItems.Add(oStore.StoreName.ToString());
                if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                {
                    oItem.SubItems.Add("True");
                }
                else
                    oItem.SubItems.Add("False");
                oItem.SubItems.Add(oStore.User.Username.ToString());
                oItem.SubItems.Add(oStore.CreateDate.ToString());

                oItem.Tag = oStore;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmParentStore oForm = new frmParentStore();
            oForm.ShowDialog();
            DataLoadControl();

        }

        private void frmParentStores_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwParentStores.SelectedItems.Count != 0)
            {

                Store oStore = (Store)lvwParentStores.SelectedItems[0].Tag;

                frmParentStore oForm = new frmParentStore();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Parent Store";
                oForm.ShowDialog(oStore);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwParentStores_DoubleClick(object sender, EventArgs e)
        {
            if (lvwParentStores.SelectedItems.Count != 0)
            {

                Store oStore = (Store)lvwParentStores.SelectedItems[0].Tag;

                frmParentStore oForm = new frmParentStore();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Parent Store";
                oForm.ShowDialog(oStore);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }


        private void lvwParentStores_Click(object sender, EventArgs e)
        {
            Store oStore = (Store)lvwParentStores.SelectedItems[0].Tag;

            if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                btnIsActive.Text = "In Active";
            else
                btnIsActive.Text = "Active";
        }

        private void lvwParentStores_KeyDown(object sender, KeyEventArgs e)
        {
            Store oStore = (Store)lvwParentStores.SelectedItems[0].Tag;

            if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                btnIsActive.Text = "In Active";
            else
                btnIsActive.Text = "Active";
        }

        private void lvwParentStores_KeyUp(object sender, KeyEventArgs e)
        {
            Store oStore = (Store)lvwParentStores.SelectedItems[0].Tag;

            if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                btnIsActive.Text = "In Active";
            else
                btnIsActive.Text = "Active";
        }

        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (lvwParentStores.SelectedItems.Count != 0)
            {

                Store oStore = (Store)lvwParentStores.SelectedItems[0].Tag;
                try
                {

                    if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                    {
                        oStore.IsActive = (int)Dictionary.InquiryCommunicationStatus.False;

                        oStore.ActiveInActive();
                        MessageBox.Show("In Active Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControl();
                    }

                    else
                    {
                        oStore.IsActive = (int)Dictionary.InquiryCommunicationStatus.True;

                        oStore.ActiveInActive();
                        MessageBox.Show("Active Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControl();
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
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

    }
}