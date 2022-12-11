using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.HR;
using CJ.Class;
using CJ.Class.Admin;

namespace CJ.Win.HR
{
  
    public partial class frmAllowanceDeduction : Form
    {
        private AllowanceDeductions _oAllowanceDeductions;
        public frmAllowanceDeduction()
        {
            InitializeComponent();
        }

        private void frmAllowanceDeduction_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            GradeDataldControl();

        }
        private void DataLoadControl()
        {

            _oAllowanceDeductions = new AllowanceDeductions();
            lvwAllowDedu.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oAllowanceDeductions.Refresh();
            this.Text = "AllowanceDeductions" + "[" + _oAllowanceDeductions.Count + "]";
            foreach (AllowanceDeduction oAllowanceDeduction in _oAllowanceDeductions)
            {
                ListViewItem oItem = lvwAllowDedu.Items.Add(oAllowanceDeduction.Code);
                oItem.SubItems.Add(oAllowanceDeduction.Name);
                oItem.SubItems.Add(oAllowanceDeduction.TypeName);
                oItem.Tag = oAllowanceDeduction;
            }
        }
              

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if(lvwAllowDedu.SelectedItems.Count==0)            
            {
                MessageBox.Show("Please Select an Item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AllowanceDeduction oAllowanceDeduction = (AllowanceDeduction)lvwAllowDedu.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete : " + oAllowanceDeduction.Name + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oAllowanceDeduction.Delete();                   
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }


        }       

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (lvwAllowDedu.SelectedItems.Count==0)
            {
                MessageBox.Show("Please Select an Transection to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AllowanceDeduction oAllDed = (AllowanceDeduction)lvwAllowDedu.SelectedItems[0].Tag;
            frmAllowanceDeduct oForm = new frmAllowanceDeduct();
            oForm.ShowDialog(oAllDed);                  
            DataLoadControl();  

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAllowanceDeduct oForm = new frmAllowanceDeduct();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnGradeAdd_Click(object sender, EventArgs e)
        {
            frmAllDeductionGrade oForm = new frmAllDeductionGrade();                       
            oForm.ShowDialog();
            GradeDataldControl();

        }
        private void GradeDataldControl()
        {

            _oAllowanceDeductions = new AllowanceDeductions();
            lvwAllDedGrade.Items.Clear();           
            DBController.Instance.OpenNewConnection();
            _oAllowanceDeductions.RefreshGrade();
            this.Text = "AllowanceDeductions" + "[" + _oAllowanceDeductions.Count + "]";
            foreach (AllowanceDeduction oAllowanceDeduction in _oAllowanceDeductions)
            {
                ListViewItem oItem = lvwAllDedGrade.Items.Add(oAllowanceDeduction.Name);
                oItem.SubItems.Add(oAllowanceDeduction.GradeName);                
                oItem.Tag = oAllowanceDeduction;
            }        
        
        }

        private void btnGradeEdit_Click(object sender, EventArgs e)
        {
            if(lvwAllDedGrade.SelectedItems.Count==0)          
            {
                MessageBox.Show("Please Select an Record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AllowanceDeduction oAllowanceDeduction = (AllowanceDeduction)lvwAllDedGrade.SelectedItems[0].Tag;
            frmAllDeductionGrade oForm= new frmAllDeductionGrade();
            //oForm.ShowDialog(oAllowanceDeduction);
            GradeDataldControl();
           

        }

        private void btnGradeDelete_Click(object sender, EventArgs e)
        {
            if (lvwAllDedGrade.SelectedItems.Count==0)           
            {
                MessageBox.Show("Please Select an Item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AllowanceDeduction oAllowanceDeduction = (AllowanceDeduction)lvwAllDedGrade.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you  want to delete : " + oAllowanceDeduction.Name + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oAllowanceDeduction.DeleteADGrade();
                    DBController.Instance.CommitTransaction();
                    GradeDataldControl();
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