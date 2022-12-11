// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 24,2012
// Time : 11.21 AM
// Description: Technical Supervisor Entry form
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmTechnicalSupervisor : Form
    {
        //ComplainCategory oComplainCategory;
        //Utilities oComplainCategoryBeforeSale;
        //Utilities oComplainCategoryAfterSale;
        //ComplainCategories oComplainCategories;
        //ComplainTypes oComplainTypes;
        //ComplainType oComplainType;
        //Utilities oGetComplainType;
        
        public frmTechnicalSupervisor()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {

            //Technical Supervisor Category
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SupervisorCategory)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.SupervisorCategory), GetEnum));
            }
            cmbCategory.SelectedIndex = cmbCategory.Items.Count - 3;

            rdoTrue.Checked = true;

        }

        private void frmTechnicalSupervisor_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
                LoadCombos();
        }


        public void ShowDialog(TechnicalSupervisor oTechnicalSupervisor)
        {
            this.Tag = oTechnicalSupervisor;
            LoadCombos();
            ctlEmployee1.txtCode.Text = oTechnicalSupervisor.Employee.EmployeeCode;
            cmbCategory.SelectedIndex = oTechnicalSupervisor.Category;
            txtRemarks.Text = oTechnicalSupervisor.Remarks.ToString();
            txtMobileNo.Text = oTechnicalSupervisor.MobileNoSup.ToString();

            if (oTechnicalSupervisor.IsActive == 1)
            {
                rdoTrue.Checked = true;
                rdoFasle.Checked = false;
            }
            else
            {
                rdoTrue.Checked = false;
                rdoFasle.Checked = true;
            }

            this.ShowDialog();
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlEmployee1.SelectedEmployee == null || ctlEmployee1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.Focus();
                return false;
            }
            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Please enter Mobile No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
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

                TechnicalSupervisor oTechnicalSupervisor = new TechnicalSupervisor();

                oTechnicalSupervisor.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oTechnicalSupervisor.Remarks =txtRemarks.Text;
                oTechnicalSupervisor.Category =cmbCategory.SelectedIndex;
                oTechnicalSupervisor.MobileNoSup = txtMobileNo.Text.ToString();
                if (rdoTrue.Checked == true)
                    oTechnicalSupervisor.IsActive = (int)Dictionary.InquiryCommunicationStatus.True;
                else oTechnicalSupervisor.IsActive = (int)Dictionary.InquiryCommunicationStatus.False;

                
              try
                {
                    DBController.Instance.BeginNewTransaction();

                    if (oTechnicalSupervisor.CheckEmployee())
                    {
                        oTechnicalSupervisor.Add();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();
                    }
                    else
                    {
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("The Employee Already Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                TechnicalSupervisor oTechnicalSupervisor = (TechnicalSupervisor)this.Tag;
                //if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Action)
                {
                    oTechnicalSupervisor.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                    oTechnicalSupervisor.Remarks = txtRemarks.Text;
                    oTechnicalSupervisor.Category = cmbCategory.SelectedIndex;
                    oTechnicalSupervisor.MobileNoSup = txtMobileNo.Text.ToString();
                    if (rdoTrue.Checked == true)
                        oTechnicalSupervisor.IsActive = (int)Dictionary.InquiryCommunicationStatus.True;
                    else oTechnicalSupervisor.IsActive = (int)Dictionary.InquiryCommunicationStatus.False;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        //if (oTechnicalSupervisor.CheckEmployee())
                        //{
                            oTechnicalSupervisor.Edit();


                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();
                        //}
                        //else
                        //{
                        //    DBController.Instance.CommitTransaction();
                        //    MessageBox.Show("The Employee Already Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //}
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                //else
                //{
                //    MessageBox.Show("Please enter Complainer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }     
    }
}