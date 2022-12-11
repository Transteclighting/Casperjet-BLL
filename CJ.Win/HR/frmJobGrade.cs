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
    public partial class frmJobGrade : Form
    {
        public frmJobGrade()
        {
            InitializeComponent();
        }


        public void ShowDialog(JobGrade oJobGrade)
        {
            this.Tag = oJobGrade;
            LoadCombos();
            txtCode.Text = oJobGrade.JobGradeCode;
            txtName.Text = oJobGrade.JobGradeName;
            cmbGradeType.SelectedIndex = oJobGrade.GradeType;
            txtMedicalLimit.Text = oJobGrade.MedicalLimit.ToString();

            this.ShowDialog();
        }

        private void frmJobGrade_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New JobGrade";
                LoadCombos();
            }
            else
            {
                this.Text = "Edit JobGrade";
            }
        }

        private void LoadCombos()
        {
            //Status
            cmbGradeType.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollType)))
            {
                cmbGradeType.Items.Add(Enum.GetName(typeof(Dictionary.PayrollType), GetEnum));
            }
            cmbGradeType.SelectedIndex = 0;

        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of JobGrade", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name if JobGrade", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (cmbGradeType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Grade Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtMedicalLimit.Text == "")
            {
                MessageBox.Show("Please enter Medical Limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedicalLimit.Focus();
                return false;
            }

            try
            {
                double temp = Convert.ToDouble(txtMedicalLimit.Text);
            }
            catch
            {
                MessageBox.Show("Please input valid Medical Limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                JobGrade oJobGrade = new JobGrade();
                oJobGrade.JobGradeCode = txtCode.Text;
                oJobGrade.JobGradeName = txtName.Text;
                oJobGrade.MinBasicSalary = 0;
                oJobGrade.MaxBasicSalary = 0;
                oJobGrade.MedicalLimit = Convert.ToDouble(txtMedicalLimit.Text);
                oJobGrade.GradePOS = 0;
                oJobGrade.IsActive = true;
                oJobGrade.GradeType = cmbGradeType.SelectedIndex;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oJobGrade.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oJobGrade.JobGradeCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                JobGrade oJobGrade = (JobGrade)this.Tag;
                oJobGrade.JobGradeCode = txtCode.Text;
                oJobGrade.JobGradeName = txtName.Text;
                oJobGrade.MinBasicSalary = 0;
                oJobGrade.MaxBasicSalary = 0;
                oJobGrade.MedicalLimit = Convert.ToDouble(txtMedicalLimit.Text);
                oJobGrade.GradePOS = 0;
                oJobGrade.GradeType = cmbGradeType.SelectedIndex;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oJobGrade.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The JobGrade : " + oJobGrade.JobGradeCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

    }
}