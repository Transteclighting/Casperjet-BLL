
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using CJ.Class;
//using CJ.Class.EPS;

namespace CJ.Win.EPS
{
    public partial class frmEPSCustomer : Form
    {
        public frmEPSCustomer()
        {
            InitializeComponent();
        }
        public void ShowDialog(EPSCustomer oEPSCustomer)
        {
            this.Tag = oEPSCustomer;
            //LoadCombos();
            ctlCustomer1.txtCode.Text = oEPSCustomer.Customer.CustomerCode;
            txtCustomerCode.Text = oEPSCustomer.EmployeeCode;
            txtCustomerName.Text = oEPSCustomer.EmployeeName;
            txtDesignation.Text = oEPSCustomer.Designation;
            txtEmAddress.Text = oEPSCustomer.EmployeeAddress;
            txtEmail.Text = oEPSCustomer.Email;
            txtPhoneNo.Text = oEPSCustomer.PhoneNo;
            if (oEPSCustomer.EmployeeStatus == 0)
            {
                rdoRegular.Checked = true;   
            }
            else if (oEPSCustomer.EmployeeStatus == 1)
            {
                rdoTopMgt.Checked = true;
            }
            else
            {
                rdoResigned.Checked = true;
            }

            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (ctlCustomer1.txtCode.Text == "" || ctlCustomer1.txtDescription.Text == "")
            {
                MessageBox.Show("Please enter Customer Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            if (txtCustomerCode.Text == "")
            {
                MessageBox.Show("Please enter Employee Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                return false;
            }
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please enter Employee Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (txtDesignation.Text == "")
            {
                MessageBox.Show("Please enter Employee Designation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesignation.Focus();
                return false;
            }
            if (txtEmAddress.Text == "")
            {
                MessageBox.Show("Please enter Deliver Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmAddress.Focus();
                return false;
            }
            if (txtEmail.Text != "")
            {
                Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                Match m = emailregex.Match(txtEmail.Text);
                if (txtEmail.Text != "")
                {
                    if (!m.Success)
                    {
                        MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return false;
                    }
                }
            }


            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();              
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                EPSCustomer oEPSCustomer = new EPSCustomer();

                oEPSCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oEPSCustomer.EmployeeCode =txtCustomerCode.Text;
                oEPSCustomer.EmployeeName =txtCustomerName.Text;
                oEPSCustomer.EmployeeAddress = txtEmAddress.Text;
                oEPSCustomer.Designation = txtDesignation.Text;
                oEPSCustomer.PhoneNo = txtPhoneNo.Text;
                oEPSCustomer.Email = txtEmail.Text;

              try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEPSCustomer.InsertCustomer(true);
                    
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                EPSCustomer oEPSCustomer = (EPSCustomer)this.Tag;

                {
                    oEPSCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    oEPSCustomer.EmployeeCode = txtCustomerCode.Text;
                    oEPSCustomer.EmployeeName = txtCustomerName.Text;
                    oEPSCustomer.EmployeeAddress = txtEmAddress.Text;
                    oEPSCustomer.Designation = txtDesignation.Text;
                    oEPSCustomer.PhoneNo = txtPhoneNo.Text;
                    oEPSCustomer.Email = txtEmail.Text;
                    if (rdoRegular.Checked == true)
                    {
                        oEPSCustomer.EmployeeStatus = (int)Dictionary.EPSEmployeeStatus.Regular;
                    }
                    else if (rdoResigned.Checked == true)
                    {
                        oEPSCustomer.EmployeeStatus = (int)Dictionary.EPSEmployeeStatus.Resigned;
                    }
                    else
                    {
                        oEPSCustomer.EmployeeStatus = (int)Dictionary.EPSEmployeeStatus.TopManagement;
                    }

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oEPSCustomer.UpdateCustomer();

                       
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEPSCustomer_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                gbEmployeeStauts.Visible = false;
                rdoResigned.Visible = false;
                rdoRegular.Visible = false;
                rdoTopMgt.Visible = false;
            }
            else
            {
                gbEmployeeStauts.Visible = true;
                rdoResigned.Visible = true;
                rdoRegular.Visible = true;
                rdoTopMgt.Visible = true;
            }
        } 
    }
}



