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
    public partial class frmChildStores : Form
    {
        public frmChildStores()
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

            lvwChildStores.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oStores.RefreshChildStore();

            this.Text = "Child Store " + "[" + oStores.Count + "]";
            foreach (Store oStore in oStores)
            {
                ListViewItem oItem = lvwChildStores.Items.Add(oStore.StoreCode.ToString());
                oItem.SubItems.Add(oStore.ChildSotre.ToString());
                oItem.SubItems.Add(oStore.ParentSotre.ToString());
                if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                {
                    oItem.SubItems.Add("True");
                }
                else
                    oItem.SubItems.Add("False");
                oItem.SubItems.Add(oStore.User.Username.ToString());
                oItem.SubItems.Add(oStore.CreateDate.ToString("dd-MMM-yyyy"));

                oItem.Tag = oStore;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmChildStore oForm = new frmChildStore();
            oForm.ShowDialog();
            DataLoadControl();

        }

        private void frmChildStores_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwChildStores.SelectedItems.Count != 0)
            {

                Store oStore = (Store)lvwChildStores.SelectedItems[0].Tag;

                frmChildStore oForm = new frmChildStore();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Child Store";
                oForm.ShowDialog(oStore);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwChildStores_DoubleClick(object sender, EventArgs e)
        {
            if (lvwChildStores.SelectedItems.Count != 0)
            {

                Store oStore = (Store)lvwChildStores.SelectedItems[0].Tag;

                frmChildStore oForm = new frmChildStore();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Child Store";
                oForm.ShowDialog(oStore);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }


        private void lvwChildStores_Click(object sender, EventArgs e)
        {
            Store oStore = (Store)lvwChildStores.SelectedItems[0].Tag;

            if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                btnIsActive.Text = "In Active";
            else
                btnIsActive.Text = "Active";
        }

        private void lvwChildStores_KeyDown(object sender, KeyEventArgs e)
        {
            Store oStore = (Store)lvwChildStores.SelectedItems[0].Tag;

            if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                btnIsActive.Text = "In Active";
            else
                btnIsActive.Text = "Active";
        }

        private void lvwChildStores_KeyUp(object sender, KeyEventArgs e)
        {
            Store oStore = (Store)lvwChildStores.SelectedItems[0].Tag;

            if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                btnIsActive.Text = "In Active";
            else
                btnIsActive.Text = "Active";
        }

        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (lvwChildStores.SelectedItems.Count != 0)
            {

                Store oStore = (Store)lvwChildStores.SelectedItems[0].Tag;
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