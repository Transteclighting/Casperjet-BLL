using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.BasicData;
//


namespace CJ.POS.RT
{
    public partial class frmPotentialCustomer : Form
    {
        int nID = 0;
        PotentialCustomer _oPotentialCustomer;
        public bool _IsTrue = false;

        public frmPotentialCustomer()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(PotentialCustomer oPotentialCustomer)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oPotentialCustomer;
            nID = 0;
            nID = oPotentialCustomer.ID;
            dtVisitdate.Value = oPotentialCustomer.VisitDate;
            txtCompany.Text = oPotentialCustomer.CompanyName;
            txtName.Text = oPotentialCustomer.Name;
            txtAddress.Text = oPotentialCustomer.Address;
            txtDesignation.Text = oPotentialCustomer.Designation;
            txtEmail.Text = oPotentialCustomer.Email;
            txtContact.Text = oPotentialCustomer.MobileNo;
            txtTelephone.Text = oPotentialCustomer.TelephoneNo;
            txtRemarks.Text = oPotentialCustomer.Remarks;

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
                        _oPotentialCustomer.Outlet = Utility.WarehouseID;
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
                        TELLib oLib = new TELLib();
                        _oPotentialCustomer.UpdateDate = oLib.ServerDateTime();
                        _oPotentialCustomer.UpdateUserID = Utility.UserId;
                        _oPotentialCustomer.EditforRT();
                        _IsTrue = true;
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
                        _oPotentialCustomer.Outlet = Utility.WarehouseID;
                        _oPotentialCustomer.CompanyName = txtCompany.Text;
                        _oPotentialCustomer.Name = txtName.Text;
                        _oPotentialCustomer.VisitDate = dtVisitdate.Value.Date;
                        _oPotentialCustomer.Designation = txtDesignation.Text;
                        _oPotentialCustomer.MobileNo = txtContact.Text;
                        _oPotentialCustomer.TelephoneNo = txtTelephone.Text;
                        _oPotentialCustomer.Address = txtAddress.Text;
                        _oPotentialCustomer.Email = txtEmail.Text;
                        _oPotentialCustomer.Remarks = txtRemarks.Text;
                        TELLib oLib = new TELLib();
                        _oPotentialCustomer.CreateDate = oLib.ServerDateTime().Date;
                        _oPotentialCustomer.CreateUserID = Utility.UserId;
                        _oPotentialCustomer.Status = (int)Dictionary.PotentialCustomer.Create;
                        _oPotentialCustomer.AddforRT();
                        _IsTrue = true;
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

        private void frmPotentialCustomer_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TELLib _oLib = new TELLib();
            dtVisitdate.Value = _oLib.ServerDateTime().Date;
        }
    }
}