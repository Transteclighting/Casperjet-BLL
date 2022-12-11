using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmProductPortfolios : Form
    {
        ProductPortfolios _oProductPortfolios;
        ProductPortfolio _oProductPortfolio;
        public frmProductPortfolios()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _oProductPortfolios = new ProductPortfolios();
            lvwProductPortfolio.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oProductPortfolios.GetPortfolioData(txtProductID.Text, txtProductName.Text, txtASG.Text);
            foreach (ProductPortfolio oProductPortfolio in _oProductPortfolios)
            {
                ListViewItem oItem = lvwProductPortfolio.Items.Add(oProductPortfolio.ProductCode.ToString());
                oItem.SubItems.Add(oProductPortfolio.ProductName.ToString());
                oItem.SubItems.Add(oProductPortfolio.ASGName.ToString());
                oItem.SubItems.Add(oProductPortfolio.IsActive.ToString());
                oItem.Tag = oProductPortfolio;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductPortfolio frmProduct = new frmProductPortfolio();
            frmProduct.Show();
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtASG_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductPortfolio.SelectedItems.Count != 0)
            {

                ProductPortfolio oProductPortfolio = (ProductPortfolio)lvwProductPortfolio.SelectedItems[0].Tag;

                frmProductPortfolio oForm = new frmProductPortfolio();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oProductPortfolio);
                LoadData();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void lvwProductPortfolio_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvwProductPortfolio.SelectedItems.Count != 0)
            {

                ProductPortfolio oProductPortfolio = (ProductPortfolio)lvwProductPortfolio.SelectedItems[0].Tag;

                frmProductPortfolio oForm = new frmProductPortfolio();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oProductPortfolio);
                LoadData();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lvwProductPortfolio_MouseClick(object sender, MouseEventArgs e)
        {
            btnIsActive.Text = "";
            int nVal = 0;
            if (lvwProductPortfolio.SelectedItems.Count == 1)
            {
                ListViewItem oItem = lvwProductPortfolio.SelectedItems[0];

                string nIsActive = oItem.SubItems[3].Text.ToString();
                if (nIsActive == nVal.ToString())
                {
                    btnIsActive.Text = "Active";
                }
                else
                {
                    btnIsActive.Text = "InActive";
                }
            }
        }

        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (lvwProductPortfolio.SelectedItems.Count == 1)
            {
                ProductPortfolio oProductPortfolio = (ProductPortfolio)lvwProductPortfolio.SelectedItems[0].Tag;
                int nProdID = oProductPortfolio.ProductID;
                DialogResult oResult = MessageBox.Show("Do you want to update: " + oProductPortfolio.ProductName + " ? ", "Confirm Porduct Active", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    int nIsActive = 0;
                    if (oProductPortfolio.IsActive == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        nIsActive = (int)Dictionary.YesOrNoStatus.NO;
                        _oProductPortfolio = new ProductPortfolio();
                        _oProductPortfolio.UpdateActive(nIsActive, oProductPortfolio.ProductID);
                        LoadData();
                    }
                    else
                    {
                        nIsActive = (int)Dictionary.YesOrNoStatus.YES;
                        _oProductPortfolio = new ProductPortfolio();
                        _oProductPortfolio.UpdateActive(nIsActive,oProductPortfolio.ProductID);
                        LoadData();
                        
                    }
                }
            }

            else
            {
                MessageBox.Show("Select a column first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}