using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Ecommerce
{
    public partial class frmPotentialCustomerEntry : Form
    {
        int nID = 0;
        PotentialCustomer _oPotentialCustomer;
        ProductGroups _oMAG;
        public bool IsTrue = false;

        public frmPotentialCustomerEntry()
        {
            InitializeComponent();
        }
        private void LoadCombo()
        {
            dtVisitdate.Value = DateTime.Today;
            //Source
            cmbSource.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PotentialCustomerSource)))
            {
                cmbSource.Items.Add(Enum.GetName(typeof(Dictionary.PotentialCustomerSource), GetEnum));
            }
            cmbSource.SelectedIndex = 0;


            //MAG 
            _oMAG = new ProductGroups();
            _oMAG.Refresh(Dictionary.ProductGroupType.MAG);
            cmbMAG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;

        }

        public void ShowDialog(PotentialCustomer oPotentialCustomer)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oPotentialCustomer;
            nID = 0;
            nID = oPotentialCustomer.ID;
            LoadCombo();
            dtVisitdate.Value = oPotentialCustomer.VisitDate;
            txtCompany.Text = oPotentialCustomer.CompanyName;
            txtName.Text = oPotentialCustomer.Name;
            txtAddress.Text = oPotentialCustomer.Address;
            txtDesignation.Text = oPotentialCustomer.Designation;
            txtEmail.Text = oPotentialCustomer.Email;
            txtContact.Text = oPotentialCustomer.MobileNo;
            txtTelephone.Text = oPotentialCustomer.TelephoneNo;
            txtRemarks.Text = oPotentialCustomer.Remarks;
            
            int nMAGIndex = 0;
            nMAGIndex = _oMAG.GetIndex(oPotentialCustomer.MAGID);
            cmbMAG.SelectedIndex = nMAGIndex;
            int nSourceIndex = oPotentialCustomer.Source;
            cmbSource.SelectedIndex = nSourceIndex - 1;

            this.ShowDialog();
        }
        private bool UIValidation()
        {
            #region ValidInput

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (txtContact.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Contact No ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return false;
            }

            if (cmbMAG.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select MAG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMAG.Focus();
                return false;
            }

            #endregion
            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oPotentialCustomer = new PotentialCustomer();
                        _oPotentialCustomer.Outlet = -1;
                        _oPotentialCustomer.ID = nID;
                        _oPotentialCustomer.CompanyName = txtCompany.Text;
                        _oPotentialCustomer.Name = txtName.Text;
                        _oPotentialCustomer.VisitDate = dtVisitdate.Value.Date;
                        _oPotentialCustomer.Designation = txtDesignation.Text;
                        _oPotentialCustomer.MobileNo = txtContact.Text;
                        _oPotentialCustomer.TelephoneNo = txtTelephone.Text;
                        _oPotentialCustomer.Address = txtAddress.Text;
                        _oPotentialCustomer.Email = txtEmail.Text;
                        _oPotentialCustomer.Remarks = txtRemarks.Text;
                        _oPotentialCustomer.UpdateDate = DateTime.Now.Date;
                        _oPotentialCustomer.UpdateUserID = Utility.UserId;
                        _oPotentialCustomer.Source = cmbSource.SelectedIndex + 1;
                        _oPotentialCustomer.MAGID = _oMAG[cmbMAG.SelectedIndex].PdtGroupID;
                        _oPotentialCustomer.EditFromHO();
                        IsTrue = true;

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update SalesLead. Potential Customer Name # " + _oPotentialCustomer.Name.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {

                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oPotentialCustomer = new PotentialCustomer();
                        _oPotentialCustomer.Outlet = -1;
                        _oPotentialCustomer.CompanyName = txtCompany.Text;
                        _oPotentialCustomer.Name = txtName.Text;
                        _oPotentialCustomer.VisitDate = dtVisitdate.Value.Date;
                        _oPotentialCustomer.Designation = txtDesignation.Text;
                        _oPotentialCustomer.MobileNo = txtContact.Text;
                        _oPotentialCustomer.TelephoneNo = txtTelephone.Text;
                        _oPotentialCustomer.Address = txtAddress.Text;
                        _oPotentialCustomer.Email = txtEmail.Text;
                        _oPotentialCustomer.Remarks = txtRemarks.Text;
                        _oPotentialCustomer.CreateDate = DateTime.Now.Date;
                        _oPotentialCustomer.CreateUserID = Utility.UserId;
                        _oPotentialCustomer.Status = (int)Dictionary.PotentialCustomer.Create;
                        _oPotentialCustomer.Source = cmbSource.SelectedIndex;
                        _oPotentialCustomer.MAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
                        _oPotentialCustomer.AddFromHO();

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add SalesLead. Potential Customer Name # " + _oPotentialCustomer.Name.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();


                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void frmPotentialCustomerEntry_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}