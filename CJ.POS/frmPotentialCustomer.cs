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
//using CJ.POS.TELWEBSERVER;


namespace CJ.POS
{
    public partial class frmPotentialCustomer : Form
    {
        int nID = 0;
        PotentialCustomer _oPotentialCustomer;
        SystemInfo _oSystemInfo;
        public bool _IsTrue = false;

        public frmPotentialCustomer()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Service oSerivce = new Service();
            //    double _Discount = 0;

            //    _Discount = oSerivce.GetPromoDiscount(txtName.Text);
            //    MessageBox.Show("Successfully Get Discount # " + _Discount.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch
            //{
            //    MessageBox.Show("Error");
            //}
            this.Close();
        }
        public void ShowDialog(PotentialCustomer oPotentialCustomer)
        {
            DBController.Instance.OpenNewConnection();
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
                        _oSystemInfo = new SystemInfo();
                        _oSystemInfo.Refresh();
                        _oPotentialCustomer.Outlet = _oSystemInfo.WarehouseID;
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
                        _oPotentialCustomer.Edit();
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
                        _oSystemInfo = new SystemInfo();
                        _oSystemInfo.Refresh();
                        _oPotentialCustomer.Outlet = _oSystemInfo.WarehouseID;
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
                        _oPotentialCustomer.Add();
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

        }
    }
}