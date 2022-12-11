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
    public partial class frmProductPortfolio : Form
    {
        ProductPortfolio _oProductPortfolio;
        ProductPortfolios _oProductPortfolios;
        public frmProductPortfolio()
        {
            InitializeComponent();
        }

        private void frmProductPortfolio_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                DataLoadControl();
            }
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oProductPortfolios = new ProductPortfolios();
            _oProductPortfolios.GetTDOutlet();
            DBController.Instance.CloseConnection();

            foreach (ProductPortfolio oProductPortfolio in _oProductPortfolios)
            {
                ListViewItem oItem = lvwOutlet.Items.Add(oProductPortfolio.Outlet);

                oItem.Tag = oProductPortfolio;
            }

        }

        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {

            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwOutlet.Items.Count; i++)
                {
                    ListViewItem itm = lvwOutlet.Items[i];

                    lvwOutlet.Items[i].Checked = true;

                }
                ckbSelect.Text = "Unchecked All";
            }
            else
            {
                for (int i = 0; i < lvwOutlet.Items.Count; i++)
                {
                    ListViewItem itm = lvwOutlet.Items[i];
                    lvwOutlet.Items[i].Checked = false;

                }
                ckbSelect.Text = "Checked All";
            }

        }
        public void ShowDialog(ProductPortfolio oProductPortfolio)
        {
            this.Tag = oProductPortfolio;

            ctlProduct1.txtCode.Text = oProductPortfolio.ProductCode;
            Customers oCustomers = new Customers();
            oCustomers.GetTDOutletByProductID(ctlProduct1.SelectedSerarchProduct.ProductID);
            DataLoadControl();

            for (int i = 0; i < lvwOutlet.Items.Count; i++)
            {
                ListViewItem itm = lvwOutlet.Items[i];
                string sOutlet = "";
                sOutlet = lvwOutlet.Items[i].SubItems[0].Text;
                foreach (Customer oCustomer in oCustomers)
                {
                    if (oCustomer.CustomerCode == sOutlet)
                    {
                        lvwOutlet.Items[i].Checked = true;
                    }

                }
            }


            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                Save();
                this.Close();
            }
            
        }
        private void Save()
        {

                DBController.Instance.BeginNewTransaction();
                int nCount = 0;
                _oProductPortfolio = new ProductPortfolio();
                if (this.Tag != null)
                {
                    _oProductPortfolio.Delete(ctlProduct1.SelectedSerarchProduct.ProductID);
                }
                for (int i = 0; i < lvwOutlet.Items.Count; i++)
                {
                    ListViewItem itm = lvwOutlet.Items[i];
                    if (lvwOutlet.Items[i].Checked == true)
                    {
                        ProductPortfolio oProductPortfolio = (ProductPortfolio)lvwOutlet.Items[i].Tag;
                        oProductPortfolio.CkeckStatus(ctlProduct1.SelectedSerarchProduct.ProductID);
                        if (oProductPortfolio.Flag == true)
                        {

                            oProductPortfolio.Add(ctlProduct1.SelectedSerarchProduct.ProductID);
                            nCount++;

                        }

                    }

                }

                if (nCount > 0)
                {
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DBController.Instance.CommitTransaction();
                    //successful message;
                }

        }


        private bool validation()
        {
            int nCount = 0;
            for (int i = 0; i < lvwOutlet.Items.Count; i++)
            {
                ListViewItem itm = lvwOutlet.Items[i];
                if (lvwOutlet.Items[i].Checked == true)
                {
                    nCount++;
                }

            }
            if (ctlProduct1.SelectedSerarchProduct == null || ctlProduct1.txtCode.Text == "")
            {

                MessageBox.Show("Please select product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (nCount > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please select at least an outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}