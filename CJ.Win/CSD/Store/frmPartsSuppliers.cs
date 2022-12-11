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
    public partial class frmPartsSuppliers : Form
    {
        public frmPartsSuppliers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void DataLoadControl()
        {

            PartsSuppliers oPartsSuppliers = new PartsSuppliers();
            
            lvwPartsSuppliers.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oPartsSuppliers.Refresh(txtSupplierName.Text,txtSupplierAddress.Text);

            this.Text = "Total " + "[" + oPartsSuppliers.Count + "]";
            foreach (PartsSupplier oPartsSupplier in oPartsSuppliers)
            {
                ListViewItem oItem = lvwPartsSuppliers.Items.Add(oPartsSupplier.SupplierID.ToString());
                oItem.SubItems.Add(oPartsSupplier.Name.ToString());
                oItem.SubItems.Add(oPartsSupplier.Address.ToString());
                if (oPartsSupplier.ContactNo != null)
                {
                    oItem.SubItems.Add(oPartsSupplier.ContactNo.ToString());
                }
                else
                {
                    oItem.SubItems.Add(string.Empty);
                }
                if (oPartsSupplier.Category == (int)Dictionary.PartsSupplierCategory.Foreign)
                {
                    oItem.SubItems.Add("Foreign");
                }
                else if (oPartsSupplier.Category == (int)Dictionary.PartsSupplierCategory.Local)
                {
                    oItem.SubItems.Add("Local");
                }
                else
                {
                    oItem.SubItems.Add("Others");
                }
                oItem.SubItems.Add(oPartsSupplier.User.Username.ToString());
                oItem.SubItems.Add(oPartsSupplier.CreateDate.ToString());

                oItem.Tag = oPartsSupplier;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPartsSupplier oForm = new frmPartsSupplier();
            oForm.ShowDialog();
            DataLoadControl();
        
        }

        private void frmPartsSuppliers_Load(object sender, EventArgs e)
        {
            //DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPartsSuppliers.SelectedItems.Count != 0)
            {

                PartsSupplier oPartsSupplier = (PartsSupplier)lvwPartsSuppliers.SelectedItems[0].Tag;
                frmPartsSupplier oForm = new frmPartsSupplier();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Supplier";
                oForm.ShowDialog(oPartsSupplier);
                if (oForm._bIsActivityDone)
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

        private void lvwPartsSuppliers_DoubleClick(object sender, EventArgs e)
        {
            if (lvwPartsSuppliers.SelectedItems.Count != 0)
            {

                PartsSupplier oPartsSupplier = (PartsSupplier)lvwPartsSuppliers.SelectedItems[0].Tag;

                frmPartsSupplier oForm = new frmPartsSupplier();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Supplier";
                oForm.ShowDialog(oPartsSupplier);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    
    }
}