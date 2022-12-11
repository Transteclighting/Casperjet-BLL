using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Report;
using CJ.Report.CSD;


namespace CJ.Win
{
    public partial class frmTechnicalSupervisors : Form
    {

        //private int _nComplainStatus;
        Utilities _oUtilitys;
        TechnicalSupervisors oTechnicalSupervisors;
        public TechnicalSupervisor oTechnicalSupervisor;
        public CSDMapping oCSDMapping;
        public User oUser;

        public frmTechnicalSupervisors()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {

            //Get Supervisor Category
            cmbCategory.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SupervisorCategory)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.SupervisorCategory), GetEnum));
            }

            cmbCategory.SelectedIndex = cmbCategory.Items.Count - 4;
            //Get Is Active Status
            cmbIsActive.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCommunicationStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.InquiryCommunicationStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = cmbIsActive.Items.Count - 3;

        }

        //private void ButtonPermission()
        //{
        //    DBController.Instance.BeginNewTransaction();

        //    User oUser = new User();
        //    oUser.UserId = Utility.UserId;
        //    oUser.Permission = "M34.8.1";

        //    oUser.che
        //    if(oUser.check.checkOtherPermission())

        //    if (oPaidJobForInterServiceHistory.CheckJobHistory())
        //    {
        //        oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
        //        oPaidJobForInterServiceHistory.Remarks = this.txtCancelReason.Text;
        //        oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.Cancel;
        //        //oPaidJobForInterServiceHistory.Dates = "";
        //        oPaidJobForInterServiceHistory.UpdateHistoryRemarks();
        //    }
        //    else
        //    {
        //        oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
        //        oPaidJobForInterServiceHistory.Remarks = this.txtCancelReason.Text;
        //        oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.Cancel;
        //        //oPaidJobForInterServiceHistory.Dates = "";
        //        oPaidJobForInterServiceHistory.AddPaidJobHistory();
        //    }
        //}


        private void frmTechnicalSupervisors_Load(object sender, EventArgs e)
        {


            LoadCombos();
            DataLoadControl();
            
        }

        private void DataLoadControl()
        {
            //Utility oUtility = _oUtilitys[cmbComplainStatus.SelectedIndex];
            //_nComplainStatus = oUtility.SatusId;
            TechnicalSupervisors oTechnicalSupervisors = new TechnicalSupervisors();


            lvwTechnicalSupervisors.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {

                oTechnicalSupervisors.Refresh(txtSupervisorID.Text, txtEmplCode.Text, txtEmplName.Text, cmbIsActive.SelectedIndex - 1, cmbCategory.SelectedIndex - 1);//

            }

            //oServiceJobs.btnShow(txtJobNo.Text);
            this.Text = "SupervisorID " + "[" + oTechnicalSupervisors.Count + "]";
            foreach (TechnicalSupervisor oTechnicalSupervisor in oTechnicalSupervisors)
            {
                ListViewItem oItem = lvwTechnicalSupervisors.Items.Add(oTechnicalSupervisor.SupervisorID.ToString());
                oItem.SubItems.Add(oTechnicalSupervisor.Employee.EmployeeCode);
                oItem.SubItems.Add(oTechnicalSupervisor.Employee.EmployeeName);
                oItem.SubItems.Add(oTechnicalSupervisor.Employee.Designation.DesignationName);
                oItem.SubItems.Add(oTechnicalSupervisor.MobileNoSup.ToString());
                oItem.SubItems.Add(oTechnicalSupervisor.Categorys);
                oItem.SubItems.Add(oTechnicalSupervisor.IsActives);
                oItem.SubItems.Add(oTechnicalSupervisor.User.Username.ToString());
                oItem.SubItems.Add(oTechnicalSupervisor.CreateDate.ToString());

                oItem.Tag = oTechnicalSupervisor;
            }
            setListViewRowColour();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmTechnicalSupervisor oForm = new frmTechnicalSupervisor();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwTechnicalSupervisors.SelectedItems.Count != 0)
            {
                TechnicalSupervisor oTechnicalSupervisor = (TechnicalSupervisor)lvwTechnicalSupervisors.SelectedItems[0].Tag;

                frmTechnicalSupervisor oForm = new frmTechnicalSupervisor();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Technical Supervisor";
                oForm.ShowDialog(oTechnicalSupervisor);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }
        private void Mapping_Click(object sender, EventArgs e)
        {
            if (lvwTechnicalSupervisors.SelectedItems.Count != 0)
            {
            TechnicalSupervisor oTechnicalSupervisor = (TechnicalSupervisor)lvwTechnicalSupervisors.SelectedItems[0].Tag;

            frmTechnicalSuperVSInterService oForm = new frmTechnicalSuperVSInterService();
            oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            oForm.MaximizeBox = false;
            oForm.Text = "Technical Supervisor VS Inter Service Mapping";
            oForm.ShowDialog(oTechnicalSupervisor);
            DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }
        private void lvwDoubleClick_Click(object sender, EventArgs e)
        {
                TechnicalSupervisor oTechnicalSupervisor = (TechnicalSupervisor)lvwTechnicalSupervisors.SelectedItems[0].Tag;

                frmTechnicalSupervisor oForm = new frmTechnicalSupervisor();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Technical Supervisor";
                oForm.ShowDialog(oTechnicalSupervisor);
                DataLoadControl();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }


        private void setListViewRowColour()
        {
            if (lvwTechnicalSupervisors.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwTechnicalSupervisors.Items)
                {
                    if (oItem.SubItems[5].Text == Dictionary.InquiryCommunicationStatus.False.ToString())
                    {
                        oItem.BackColor = Color.DarkGray;
                    }

                    else
                    {
                        oItem.BackColor = Color.Transparent;

                    }
                }
            }
        }


    }

}

