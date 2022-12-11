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
    public partial class frmSpareParts : Form
    {
        SPGroups _oSPMainCats;
        public frmSpareParts()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            frmSparePart oForm = new frmSparePart();
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
        private void frmSpareParts_Load(object sender, EventArgs e)
        {
            LoadCombo();
            //DataLoadControl();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            SparePartsRs oSparePartsRs = new SparePartsRs();

            lvwSpareParts.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oSparePartsRs.Refresh(txtPartCode.Text, txtPartName.Text);
            this.Text = "Total " + "[" + oSparePartsRs.Count + "]";
            foreach (SparePartsR oSparePartsR in oSparePartsRs)
            {
                ListViewItem oItem = lvwSpareParts.Items.Add(oSparePartsR.Code.ToString());
                oItem.SubItems.Add(oSparePartsR.Name.ToString());
                oItem.SubItems.Add(oSparePartsR.SalePrice.ToString());
                oItem.SubItems.Add(oSparePartsR.SparePartLocation.LocationName.ToString());
                oItem.SubItems.Add(" ");
                oItem.SubItems.Add(oSparePartsR.MainCatName.ToString());
                oItem.SubItems.Add(oSparePartsR.ModelNo.ToString());
                //oItem.SubItems.Add(oSparePartsR.ProductDetailASG.ASGName.ToString());
                oItem.SubItems.Add(" ");
                oItem.SubItems.Add(oSparePartsR.ProductDetailBrand.BrandDesc.ToString());
                if (oSparePartsR.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                {
                    oItem.SubItems.Add("True");
                }
                else
                {
                    oItem.SubItems.Add("False");
                }
               
                oItem.SubItems.Add(oSparePartsR.User.Username.ToString());
                oItem.SubItems.Add(oSparePartsR.CreateDate.ToString());

                oItem.Tag = oSparePartsR;
                if (oSparePartsR.IsActive == (int)Dictionary.YesOrNoStatus.NO)
                {
                    oItem.BackColor = Color.LightGray;
                }
                else
                {
                    oItem.BackColor = Color.Transparent;
                }
                
            }
            this.Cursor = Cursors.Default;
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSpareParts.SelectedItems.Count != 0)
            {

                SparePartsR oSparePartsR = (SparePartsR)lvwSpareParts.SelectedItems[0].Tag;
                
                frmSparePart oForm = new frmSparePart();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Spare Part";
                oForm.ShowDialog(oSparePartsR);
                if (oForm._bIsAnyActivityDone)
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
        private void lvwSpareParts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwSpareParts.Sorting == SortOrder.Ascending)
            {
                lvwSpareParts.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwSpareParts.Sorting = SortOrder.Ascending;
            }
            lvwSpareParts.Sort();

        }

        private void lvwSpareParts_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSpareParts.SelectedItems.Count != 0)
            {
                SparePartsR oSparePartsR = (SparePartsR)lvwSpareParts.SelectedItems[0].Tag;

                frmSparePart oForm = new frmSparePart();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Spare Part";
                oForm.ShowDialog(oSparePartsR);
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

        private void btnEditPartCode_Click(object sender, EventArgs e)
        {
            //if (lvwSpareParts.SelectedItems.Count != 0)
            //{

            //    SparePartsR oSparePartsR = (SparePartsR)lvwSpareParts.SelectedItems[0].Tag;

            //    frmSparePart oForm = new frmSparePart();
            //    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            //    oForm.MaximizeBox = false;
            //    oForm.Text = "Edit Spare Part(Only Part Code)";
            //    oForm.ShowDialogs(oSparePartsR);
            //    DataLoadControl();

            //}
            //else
            //{
            //    MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Refresh();
            //}
        }
    }
}