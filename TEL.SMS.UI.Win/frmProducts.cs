using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE ;
using TEL.SMS.BO.DA;


namespace TEL.SMS.UI.Win
{
    public partial class frmProducts : Form
    {
        private DSProduct _oDSProductSelected;

        public frmProducts()
        {
            InitializeComponent();
        }

        public bool ShowDialog(DSProduct oDSProduct)
        {
            _oDSProductSelected = oDSProduct;
            this.ShowDialog();
            return true;
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            //refreshList();
        }

        //private void refreshList()
        //{
        //    //Get All the mobiles.
        //    DSProduct oDSProduct = new DSProduct();
        //    DAProduct oDAProduct = new DAProduct();
        //    try
        //    {
        //        DBController.Instance.OpenNewConnection();
        //        oDAProduct.GetAllProducts(oDSProduct);
        //        DBController.Instance.CloseConnection();
        //    }
        //    catch(Exception e)
        //    {
        //        MessageBox.Show("Server not found. Please check the network cable or call system admin.", "Server connection",MessageBoxButtons.OK,MessageBoxIcon.Error);
        //    }
        //    //Clear and Populate list.
        //    lvwProduct.Items.Clear();
        //    foreach (DSProduct.ProductRow oProductRow in oDSProduct.Product)
        //    {
        //        ListViewItem oItem = lvwProduct.Items.Add(oProductRow.ProductID.ToString());
        //        oItem.SubItems.Add(oProductRow.ProductDescription);
        //        oItem.Tag = oProductRow;
        //    }

        //    this.Text = "Products " + lvwProduct.Items.Count.ToString();
  
        //    //Select first item in the list.
        //    if (lvwProduct.Items.Count > 0)
        //    {
        //        lvwProduct.Items[0].Selected = true;
        //        lvwProduct.Focus();
        //    }
        //}

        private void refreshListBySearch()
        {
            //Get All the mobiles.
            DSProduct oDSProduct = new DSProduct();
            DAProduct oDAProduct = new DAProduct();
            try
            {
                DBController.Instance.OpenNewConnection();
                oDAProduct.GetProductsBySearch(oDSProduct,txtFind.Text);
                DBController.Instance.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin.", "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clear and Populate list.
            lvwProduct.Items.Clear();
            foreach (DSProduct.ProductRow oProductRow in oDSProduct.Product)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductRow.ProductID.ToString());
                oItem.SubItems.Add(oProductRow.ProductDescription);
                oItem.Tag = oProductRow;
            }

            this.Text = "Products " + lvwProduct.Items.Count.ToString();

            //Select first item in the list.
            if (lvwProduct.Items.Count > 0)
            {
                lvwProduct.Items[0].Selected = true;
                lvwProduct.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            //int i = 0;
            //foreach (ListViewItem oItem in lvwProduct.Items)
            //{
            //    if (oItem.SubItems[1].Text.Length < txtFind.Text.Length)
            //        return;
            //    if (txtFind.Text.ToUpper() == oItem.SubItems[1].Text.Substring(0, txtFind.Text.Length).ToUpper())
            //    {
            //        lvwProduct.Items[i].Selected = true;
            //        lvwProduct.Items[i].EnsureVisible();
            //        return;
            //    }
            //    i = i + 1;
            //}

        }

        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {


            if (lvwProduct.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Nothing Selected", "Selected Info", MessageBoxButtons.OK);
                return;
            }

            foreach (ListViewItem oItem in lvwProduct.SelectedItems)
            {
                DSProduct.ProductRow oRow = _oDSProductSelected.Product.NewProductRow();
                oRow.ProductID = ((DSProduct.ProductRow)oItem.Tag).ProductID;
                oRow.ProductDescription = ((DSProduct.ProductRow)oItem.Tag).ProductDescription;
                oRow.RSP = ((DSProduct.ProductRow)oItem.Tag).RSP;
                _oDSProductSelected.Product.AddProductRow(oRow);
            }
            _oDSProductSelected.AcceptChanges();
            this.Close();

        }

        private void lvwProduct_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwProduct.Sorting == SortOrder.Ascending)
            {
                lvwProduct.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwProduct.Sorting = SortOrder.Ascending;
            }
            lvwProduct.Sort();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshListBySearch();
        }

    }
}