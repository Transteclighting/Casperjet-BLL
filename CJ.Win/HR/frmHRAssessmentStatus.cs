using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRAssessmentStatus : Form
    {


        public bool _bActionSave = false;
        int nAssessmentID = 0;
        int nID = 0;
        public frmHRAssessmentStatus()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHRAssessmentStatus_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
        }

        public void ShowDialog(HRAssessment oHRAssessment)
        {
            this.Tag = oHRAssessment;
            LoadCombos();
            this.Text = "Edit Assessment Data";
            nAssessmentID = oHRAssessment.AssessmentID;
            nID = oHRAssessment.ID;
            lblEmployee.Text = oHRAssessment.EmployeeName;
            lblLineManagerName.Text = oHRAssessment.LineManagerName;
            lblAssessmentType.Text = Enum.GetName(typeof(Dictionary.HRAssessmentType), oHRAssessment.AssessmentType);
            cmbStatus.SelectedIndex = oHRAssessment.Status;
            lblAssessmentYear.Text = oHRAssessment.AssessmentYear.ToString();
            lblBasicSalary.Text = oHRAssessment.BasicSalary.ToString();
            lblGrossSalary.Text = oHRAssessment.GrossSalary.ToString();
            lblLastIncrementAmount.Text = oHRAssessment.IncrementAmount.ToString();
            lblLastPromotion.Text = oHRAssessment.YearofLastPromotion.ToString();

            //if (oHRAssessment.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            //{
            //    chkIsActive.Checked = true;
            //}
            //else
            //{
            //    chkIsActive.Checked = false;
            //}

            this.ShowDialog();
        }

        private void LoadCombos()
        {

            //cmbAssessmentType.Items.Clear();
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRAssessmentType)))
            //{
            //    cmbAssessmentType.Items.Add(Enum.GetName(typeof(Dictionary.HRAssessmentType), GetEnum));
            //}
            //cmbAssessmentType.SelectedIndex = 0;


            cmbStatus.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRAssessmentStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.HRAssessmentStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag != null)
            {
                HRAssessment oHRAssessment = new HRAssessment();
                oHRAssessment.AssessmentID = nAssessmentID;
                oHRAssessment.ID = nID;
                oHRAssessment.Status = cmbStatus.SelectedIndex;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRAssessment.StatusUpdate();
                    oHRAssessment.StatusUpdateAssessmentEmployee();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }


        private bool UIValidation()
        {

            //if (cmbAssessmentType.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please select a assessment type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbAssessmentType.Focus();
            //    return false;
            //}
            return true;

        }
    }
}
