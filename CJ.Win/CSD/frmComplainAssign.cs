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
    public partial class frmComplainAssign : Form
    {
        public frmComplainAssign()
        {
            InitializeComponent();
        }

        public void ShowDialog(Complain oComplain)
        {
            this.Tag = oComplain;
            //LoadCombos();

            lblComplainDetail.Text = oComplain.ComplainDetails;
            lblContacNo.Text = oComplain.ContactNo;
            lblComplainer.Text = oComplain.Complainer;
            lblComplainNo.Text = oComplain.ComplainID.ToString();
            label1.Text = oComplain.ActionDate.ToString();

            ctlEmployee1.txtCode.Text = oComplain.Employee.EmployeeCode;
            ctlEmployee1.txtDescription.Text = oComplain.Employee.EmployeeName;

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlEmployee1.SelectedEmployee == null)
            {
                MessageBox.Show("Please enter Emplyoee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            #endregion

            return true;
        }
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {

            Complain oComplain = (Complain)this.Tag;

            oComplain.AssignEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            //oComplain.ComplainStatus = (int)Dictionary.ComplainStatus.Assign;
            //oComplain.ComplainStatus = 1;

            try
            {
                DBController.Instance.BeginNewTransaction();
                if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Assign)
                {
                    oComplain.UpdateAssignmentEdit();
                }
                else
                {
                    oComplain.UpdateAssignment();
                }
                
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Assign Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Refresh();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }


}
