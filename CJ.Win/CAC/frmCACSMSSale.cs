using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;

namespace CJ.Win.CAC
{
    public partial class frmCACSMSSale : Form
    {
        Brands oBrands;
        public frmCACSMSSale()
        {
            InitializeComponent();
        }

        public void ShowDialog(CACSMSSale oCACSMSSale)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oCACSMSSale;
            LoadCombo();
            ctlCustomer1.txtCode.Text = oCACSMSSale.CustomerCode;
            txtProjectID.Text = oCACSMSSale.ProjectID.ToString();
            txtCode.Text = oCACSMSSale.ProjectCode;
            txtProjectName.Text= oCACSMSSale.ProjectName;
            dtDate.Value = oCACSMSSale.EntryDate;
            cmbBrand.SelectedIndex = oBrands.GetIndex(oCACSMSSale.BrandID) + 1;
            txtSMSValue.Text =oCACSMSSale.SMSValue.ToString();
            txtCostValue.Text = oCACSMSSale.CostValue.ToString();
            
            this.ShowDialog();
        }
        private void frmCACSMSSale_Load(object sender, EventArgs e)
        {
            if (this.Tag == null || this.Tag == " ")
            {
                LoadCombo();
            }            
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }                        
            oBrands = new Brands();
            oBrands.GetCACBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("-- All--");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;
        }

        private bool validation()
        {
            if (ctlCustomer1.txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            if (cmbBrand.Text.Trim() == "-- All--")
            {
                MessageBox.Show("Please Input brand name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                Save();
            }
        }
        private void Save()
        {
            CACSMSSale oCACSMSSale;
            if (this.Tag == null)
            {
                oCACSMSSale = new CACSMSSale();
                oCACSMSSale.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oCACSMSSale.CustomerName = ctlCustomer1.SelectedCustomer.CustomerName;
                oCACSMSSale.ProjectID =Convert.ToInt32(txtProjectID.Text.ToString());
                oCACSMSSale.ProjectName = txtProjectName.Text;
                oCACSMSSale.EntryDate = dtDate.Value;
                oCACSMSSale.BrandID = oBrands[cmbBrand.SelectedIndex -1].BrandID;
                oCACSMSSale.SMSValue =Convert.ToDouble(txtSMSValue.Text);
                oCACSMSSale.CostValue = Convert.ToDouble(txtCostValue.Text);
                oCACSMSSale.CreateUser = Utility.UserId;
                oCACSMSSale.CreateDate = DateTime.Now;
                oCACSMSSale.Status = (int)Dictionary.CACSMSSale.Create;

                DBController.Instance.BeginNewTransaction();
                oCACSMSSale.Add();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add CACSMSSale. CACSMSSale Code # " + oCACSMSSale.ID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                oCACSMSSale =(CACSMSSale)this.Tag;
                oCACSMSSale.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oCACSMSSale.CustomerName = ctlCustomer1.SelectedCustomer.CustomerName;
                oCACSMSSale.ProjectID = Convert.ToInt32(txtProjectID.Text.ToString());
                oCACSMSSale.ProjectName = txtProjectName.Text;
                oCACSMSSale.EntryDate = dtDate.Value;
                oCACSMSSale.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                oCACSMSSale.SMSValue = Convert.ToDouble(txtSMSValue.Text);
                oCACSMSSale.CostValue = Convert.ToDouble(txtCostValue.Text);

                DBController.Instance.BeginNewTransaction();
                oCACSMSSale.Edit();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Edit CACSMSSale. CACSMSSale Code # " + oCACSMSSale.ID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please Enter Code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
            }

            else
            {

                CACProject oCACProject = new CACProject();
                oCACProject.RefreshBySMSSale(txtCode.Text);
                oCACProject.ProjectCode= txtCode.Text.ToString();
                //if (nCustomerID == oCACSMSSaleCollection.CustomerID)
                //{
                    txtProjectName.Text = oCACProject.ProjectName;
                    txtProjectID.Text = oCACProject.ProjectID.ToString();
                    txtCode.Enabled = false;
                    txtProjectName.Enabled = false;
                //}
                //else
                //{
                //    MessageBox.Show("Please Input Valid Customer Tran#");
                //}
            }
        }
    }
}
