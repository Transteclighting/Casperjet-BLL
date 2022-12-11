using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmAllDeductionGrade : Form 
    {
        JobGrades _oJobGrades;
        AllowanceDeductions _oAllowanceDeductions;
        AllowanceDeduction oAllowanceDeduction;

        
        public frmAllDeductionGrade()
        {
            InitializeComponent();
        }

        private void frmAllDeductionGrade_Load(object sender, EventArgs e)
        {            
               
                Loadcombo();
          
        }
        private void Loadcombo()
        {
            _oJobGrades = new JobGrades();
            _oJobGrades.Refresh();
            _oAllowanceDeductions= new AllowanceDeductions();
            _oAllowanceDeductions.Refresh();

            cmbAllCode.Items.Clear();
            cmbGradeName.Items.Clear();

            foreach (AllowanceDeduction oAllowanceDeduction in _oAllowanceDeductions)
            {

                cmbAllCode.Items.Add(oAllowanceDeduction.Name);               

            }
            if (_oAllowanceDeductions.Count > 0)
            {
                cmbAllCode.SelectedIndex = _oAllowanceDeductions.Count - 1;
            }



            foreach (JobGrade oJobGrade in _oJobGrades)
            {
                cmbGradeName.Items.Add(oJobGrade.JobGradeName);               

            }
            if (_oJobGrades.Count > 0)
            {
                cmbGradeName.SelectedIndex = _oJobGrades.Count - 1;
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                AllowanceDeduction oAllowanceDeduction = new AllowanceDeduction();
                JobGrade oJobGrade = new JobGrade();
                
                oAllowanceDeduction.ID = _oAllowanceDeductions[cmbAllCode.SelectedIndex].ID;
                oAllowanceDeduction.GradeID = _oJobGrades[cmbGradeName.SelectedIndex].JobGradeID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oAllowanceDeduction.AddGrade();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oAllowanceDeduction.Name, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                AllowanceDeduction oAllowanceDeduction=(AllowanceDeduction)this.Tag;
                oAllowanceDeduction = GetAllounceData(oAllowanceDeduction);                       
                
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oAllowanceDeduction.EditAllGrade();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Updated  : " + oAllowanceDeduction.Name, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        public AllowanceDeduction GetAllounceData(AllowanceDeduction oAllowanceDeduction)
        {

            oAllowanceDeduction.ID = _oAllowanceDeductions[cmbAllCode.SelectedIndex].ID;
            oAllowanceDeduction.GradeID = _oJobGrades[cmbGradeName.SelectedIndex].JobGradeID;
            return oAllowanceDeduction;
        }




        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
       

    }
}