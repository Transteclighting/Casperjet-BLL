// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: April 30, 2014
// Time :  4:55 PM
// Description: Forms for Brand/Sub Brand List.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmBrands : Form
    {
        private Dictionary.BrandLevel _nBrandLevel;

        public frmBrands(Dictionary.BrandLevel nBrandLevel)
        {
            _nBrandLevel = nBrandLevel;
            InitializeComponent();
        }

        private void frmBrands_Load(object sender, EventArgs e)
        {
            if (_nBrandLevel == Dictionary.BrandLevel.MasterBrand)
            {

            }
            else
            {
                lvwBrands.Columns.Add("Brand", 80);
            }

            DataLoadControl();
        }

        private void DataLoadControl()
        {
            Brands oBrands = new Brands();
            lvwBrands.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oBrands.Refresh(_nBrandLevel);
            if (_nBrandLevel == Dictionary.BrandLevel.MasterBrand)
            {
                this.Text = "Brand " + "[" + oBrands.Count + "]";
            }
            else
            {
                this.Text = "Sub Brand " + "[" + oBrands.Count + "]";
            }

            foreach (Brand oBrand in oBrands)
            {
                ListViewItem oItem = lvwBrands.Items.Add(oBrand.BrandCode);
                oItem.SubItems.Add(oBrand.BrandDesc);
                if (_nBrandLevel == Dictionary.BrandLevel.SubBrand)
                {
                    oItem.SubItems.Add(oBrand.ParentBrand.BrandDesc);
                }
                oItem.Tag = oBrand;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBrand oForm = new frmBrand(_nBrandLevel);
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBrands.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Brand to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Brand oBrand = (Brand)lvwBrands.SelectedItems[0].Tag;
            frmBrand oForm = new frmBrand(_nBrandLevel);
            oForm.ShowDialog(oBrand);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Brands oBrands = new Brands();
            //oBrands.Refresh();
            //rptBrands oReport = new rptBrands();
            //oReport.SetDataSource(oBrands);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwBrands.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Brand to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Brand oBrand = (Brand)lvwBrands.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Brand: " + oBrand.BrandCode + " ? ", "Confirm Brand Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBrand.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}