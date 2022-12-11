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
    public partial class frmStores : Form
    {
        public frmStores()
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

            lvwStores.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oStores.RefreshTranStore();

            this.Text = "Total " + "[" + oStores.Count + "]";
            foreach (Store oStore in oStores)
            {
                ListViewItem oItem = lvwStores.Items.Add(oStore.StoreCode.ToString());
                oItem.SubItems.Add(oStore.StoreName.ToString());
                oItem.SubItems.Add(oStore.ChildSotre.ToString());
                oItem.SubItems.Add(oStore.ParentSotre.ToString());
                if (oStore.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                {
                    oItem.SubItems.Add("True");
                }
                else oItem.SubItems.Add("False");
                
                oItem.SubItems.Add(oStore.User.Username.ToString());
                oItem.SubItems.Add(oStore.CreateDate.ToString());

                oItem.Tag = oStore;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmStore oForm = new frmStore();
            oForm.ShowDialog();
            DataLoadControl();
        
        }

        private void frmStores_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwStores.SelectedItems.Count != 0)
            {

                Store oStore = (Store)lvwStores.SelectedItems[0].Tag;

                frmStore oForm = new frmStore();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Transaction Store";
                oForm.ShowDialog(oStore);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwStores_DoubleClick(object sender, EventArgs e)
        {
            if (lvwStores.SelectedItems.Count != 0)
            {

                Store oStore = (Store)lvwStores.SelectedItems[0].Tag;

                frmStore oForm = new frmStore();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Transaction Store";
                oForm.ShowDialog(oStore);
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