using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win.CSD
{
    public partial class frmProductSearch : Form
    {

        private SerarchProduct _oSerarchProduct;

        public frmProductSearch()
        {
            InitializeComponent();
        }

        //private void LoadCombos()
        //{
            ////District
            ////_oDistricts = new Districts();
            //_oComplains = new Complains();
            ////_oComplains.Refresh();
            ////_oDistricts.Refresh();
            //cmbAssignWhom.Items.Clear();
            //foreach (Complain oComplain in _oComplains)
            //{
            //    cmbAssignWhom.Items.Add(oComplain.Employee);
            //}
            //if (_oComplains.Count > 0)
            //    cmbAssignWhom.SelectedIndex = _oComplains.Count - 1;

        //}

        private void frmProductSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            //Utility oUtility = _oUtilitys[cmbComplainStatus.SelectedIndex];
            //_nComplainStatus = oUtility.SatusId;

            SerarchProducts oSerarchProducts = new SerarchProducts();

            lvwProductSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSerarchProducts.Refresh(txtProductCode.Text, txtProductName.Text);

            //oServiceJobs.btnShow(txtJobNo.Text);
            this.Text = "Total Product = " + "[" + oSerarchProducts.Count + "]";
            foreach (SerarchProduct oSerarchProduct in oSerarchProducts)
            {
                ListViewItem oItem = lvwProductSearch.Items.Add(oSerarchProduct.ProductCode.ToString());
                oItem.SubItems.Add(oSerarchProduct.ProductName);
                oItem.SubItems.Add(oSerarchProduct.ASGName);
                oItem.SubItems.Add(oSerarchProduct.MAGName);
                oItem.SubItems.Add(oSerarchProduct.BrandDesc);

                oItem.Tag = oSerarchProduct;
            }
            //setListViewRowColour();
        }


        //private void getComplainStatus()
        //{
        //    _oUtilitys = new Utilities();
        //    cmbComplainStatus.Items.Clear();
        //    DBController.Instance.OpenNewConnection();
        //    _oUtilitys.GetComplainStatus();
        //    foreach (Utility oUtility in _oUtilitys)
        //    {
        //        cmbComplainStatus.Items.Add(oUtility.Satus);
        //    }
        //    cmbComplainStatus.SelectedIndex = cmbComplainStatus.Items.Count - 1;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductCode.Text = "";
            txtProductName.Text = "";
            DataLoadControl();
        }
    
        //private void lvwComplains_DoubleClick(object sender, EventArgs e)
        //{
        //    if (lvwComplains.SelectedItems.Count != 0)
        //    {
        //        Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;

        //        if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
        //        {
        //            if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.HappyCall)
        //            {
        //                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Action)
        //                {
        //                    frmComplain oForm = new frmComplain();
        //                    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //                    oForm.MaximizeBox = false;
        //                    oForm.Text = "Edit Complain";
        //                    oForm.ShowDialog(oComplain);
        //                    DataLoadControl();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    this.Refresh();
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                this.Refresh();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            this.Refresh();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        this.Refresh();
        //    }

        //}

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }


        private void lvwProductSearch_DoubleClick(object sender, EventArgs e)
        {

            SerarchProduct oSerarchProduct = (SerarchProduct)lvwProductSearch.SelectedItems[0].Tag;

            //_oEmployee.EmployeeCode = oEmployee.EmployeeCode;
            _oSerarchProduct.ProductCode = oSerarchProduct.ProductCode;
            _oSerarchProduct.ProductName = oSerarchProduct.ProductName;
            //_oEmployee.EmployeeName = oEmployee.EmployeeName;
            this.Close();
        }

        private void lvwProductSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            SerarchProduct oSerarchProduct = (SerarchProduct)lvwProductSearch.SelectedItems[0].Tag;

            _oSerarchProduct.ProductCode = oSerarchProduct.ProductCode;
            _oSerarchProduct.ProductName = oSerarchProduct.ProductName;
            this.Close();
        }

        public bool ShowDialog(SerarchProduct oSerarchProduct)
        {
            _oSerarchProduct = oSerarchProduct;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

    }

}