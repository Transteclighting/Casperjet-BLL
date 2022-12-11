using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmJobGrades : Form
    {
        public frmJobGrades()
        {
            InitializeComponent();
        }

        private void frmJobGrades_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void LoadCombos()
        {
            //Status
            cmbGradeType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollType)))
            {
                cmbGradeType.Items.Add(Enum.GetName(typeof(Dictionary.PayrollType), GetEnum));
            }
            cmbGradeType.SelectedIndex = 0;

        }

        private void DataLoadControl()
        {
            JobGrades oJobGrades = new JobGrades();
            lvwJobGrades.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oJobGrades.GetGrade(cmbGradeType.SelectedIndex);
            this.Text = "Job Grade | Total: " + "[" + oJobGrades.Count + "]";
            foreach (JobGrade oJobGrade in oJobGrades)
            {
                ListViewItem oItem = lvwJobGrades.Items.Add(oJobGrade.JobGradeCode);
                oItem.SubItems.Add(oJobGrade.JobGradeName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PayrollType), oJobGrade.GradeType));
                if (oJobGrade.IsActive == true)
                {
                    oItem.SubItems.Add("Yes");
                }
                else
                {
                    oItem.SubItems.Add("No");
                }
                
                oItem.Tag = oJobGrade;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmJobGrade oForm = new frmJobGrade();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (lvwJobGrades.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an JobGrade to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JobGrade oJobGrade = (JobGrade)lvwJobGrades.SelectedItems[0].Tag;
            frmJobGrade oForm = new frmJobGrade();
            oForm.ShowDialog(oJobGrade);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //JobGrades oJobGrades = new JobGrades();
            //oJobGrades.Refresh();
            //rptJobGrades oReport = new rptJobGrades();
            //oReport.SetDataSource(oJobGrades);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwJobGrades.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an JobGrade to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JobGrade oJobGrade = (JobGrade)lvwJobGrades.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete JobGrade: " + oJobGrade.JobGradeCode  + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oJobGrade.Delete();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwJobGrades_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}