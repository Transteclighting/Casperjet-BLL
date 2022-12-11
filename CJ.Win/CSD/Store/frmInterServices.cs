
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
    public partial class frmInterServices : Form
    {
        SPGroups _oSPMainCats;
        
        public frmInterServices()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            frmInterService oForm = new frmInterService();
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void LoadCombo()
        {
            //_oSPMainCats = new SPMainCats();
            //_oSPMainCats.RefreshForFilter();
            //cmbMainCategory.Items.Clear();

            //foreach (SPMainCat oSPMainCat in _oSPMainCats)
            //{
            //    cmbMainCategory.Items.Add(oSPMainCat.Name);
            //}
            //if (_oSPMainCats.Count >0)
            //    cmbMainCategory.SelectedIndex = _oSPMainCats.Count - 1; 
      
        }
        private void frmInterServices_Load(object sender, EventArgs e)
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

            InterServicesR oInterServicesR = new InterServicesR();

            lvwInterServices.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oInterServicesR.Refresh(txtCode.Text, txtName.Text,txtPhone.Text, txtMobile.Text, txtAddress.Text);
            this.Text = "Total " + "[" + oInterServicesR.Count + "]";
            foreach (InterServiceR oInterServiceR in oInterServicesR)
            {
                ListViewItem oItem = lvwInterServices.Items.Add(oInterServiceR.Code.ToString());
                oItem.SubItems.Add(oInterServiceR.Name.ToString());
                oItem.SubItems.Add(oInterServiceR.Address.ToString());
                oItem.SubItems.Add(oInterServiceR.Mobile.ToString());

                if (oInterServiceR.Category == (int)Dictionary.InterServiceCategory.Electronics)
                {
                    oItem.SubItems.Add("Electronics");
                }
                else if (oInterServiceR.Category == (int)Dictionary.InterServiceCategory.Appliances)
                {
                    oItem.SubItems.Add("Appliances");
                }
                else if (oInterServiceR.Category == (int)Dictionary.InterServiceCategory.Both)
                {
                    oItem.SubItems.Add("Both");
                }
                else if (oInterServiceR.Category == (int)Dictionary.InterServiceCategory.Aircondition)
                {
                    oItem.SubItems.Add("Aircondition");
                }

                if (oInterServiceR.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                {
                    oItem.SubItems.Add("True");
                }
                else
                {
                    oItem.SubItems.Add("False");
                }

                oItem.SubItems.Add(oInterServiceR.User.Username.ToString());
                oItem.SubItems.Add(oInterServiceR.CreateDate.ToString());

                oItem.Tag = oInterServiceR;
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwInterServices.SelectedItems.Count != 0)
            {

                InterServiceR oInterServiceR = (InterServiceR)lvwInterServices.SelectedItems[0].Tag;

                frmInterService oForm = new frmInterService();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Inter Service";
                oForm.ShowDialog(oInterServiceR);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwInterServices_DoubleClick(object sender, EventArgs e)
        {
            if (lvwInterServices.SelectedItems.Count != 0)
            {

                InterServiceR oInterServiceR = (InterServiceR)lvwInterServices.SelectedItems[0].Tag;

                frmInterService oForm = new frmInterService();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Inter Service";
                oForm.ShowDialog(oInterServiceR);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}