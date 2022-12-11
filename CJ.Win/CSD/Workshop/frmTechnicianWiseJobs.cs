using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD;


namespace CJ.Win.CSD.Workshop
{
    public partial class frmTechnicianWiseJobs : Form
    {
        public frmTechnicianWiseJobs()
        {
            InitializeComponent();
        }
        CSDWorkshopTypes _oCSDWorkshopTypes;
        TechnicalSupervisors _oTechnicalSupervisors;
        Technicians _oTechnicians;
        Technician _oTechnician;
        CSDJobs _oCSDJobs;

        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            //Load Workshop Combo
            _oCSDWorkshopTypes = new CSDWorkshopTypes();
            _oCSDWorkshopTypes.Refresh();
            cmbWorkshop.Items.Clear();
            cmbWorkshop.Items.Add("<All>");
            foreach (CSDWorkshopType oCSDWorkshopType in _oCSDWorkshopTypes)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oCSDWorkshopType.Name;
                //item.Value = oCSDWorkshopType.WorkshopTypeID.ToString();
                //cmbWorkshop.Items.Add(item);
                cmbWorkshop.Items.Add(oCSDWorkshopType.Name);
            }
            cmbWorkshop.SelectedIndex = 0;
            //Load Supervisor
            _oTechnicalSupervisors = new TechnicalSupervisors();
            _oTechnicalSupervisors.RefreshAll();
            cmbSupervisor.Items.Clear();
            cmbSupervisor.Items.Add("<All>");
            foreach (TechnicalSupervisor oTechnicalSupervisor in _oTechnicalSupervisors)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oTechnicalSupervisor.Employee.EmployeeName;
                //item.Value = oTechnicalSupervisor.SupervisorID.ToString();
                //cmbSupervisor.Items.Add(item);
                cmbSupervisor.Items.Add(oTechnicalSupervisor.Employee.EmployeeName);
            }
            cmbSupervisor.SelectedIndex = 0;

            cmbTechnician.Items.Add("<Select technician>");
            cmbTechnician.SelectedIndex = 0;

        }

        private void cmbSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupervisor.SelectedIndex != 0)
            {
                DBController.Instance.OpenNewConnection();
                int nSupervisorID = _oTechnicalSupervisors[cmbSupervisor.SelectedIndex-1].SupervisorID;
                _oTechnicians = new Technicians();
                _oTechnicians.GetTechBySupID(nSupervisorID);

                cmbTechnician.Items.Clear();
                cmbTechnician.Items.Add("<All>");
                foreach (Technician oTechnician in _oTechnicians)
                {
                    //ComboboxItem item = new ComboboxItem();
                    //item.Text = oTechnician.Name;
                    //item.Value = oTechnician.TechnicianID.ToString();
                    //cmbTechnician.Items.Add(item);
                    cmbTechnician.Items.Add(oTechnician.Name);
                }
                cmbTechnician.SelectedIndex = 0;
            }
            else
            {
                cmbTechnician.Items.Clear();
                cmbTechnician.Items.Add("<All>");
                cmbTechnician.SelectedIndex = 0;
            }

        }

        private void cmbTechnician_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTechnician.SelectedIndex != 0)
            {
                _oTechnician = new Technician();
                _oTechnician.TechnicianID = _oTechnicians[cmbTechnician.SelectedIndex-1].TechnicianID;
                _oTechnician.RefreshByTechnicianID();
                if (_oTechnician.TechnicianTypeID == (int)Dictionary.CSDTechnicianType.Own)
                {
                    rdoOwn.Checked = true;
                }
                else
                {
                    rdoThirdparty.Checked = true;
                }
            }
            else
            {
                rdoAll.Checked = true;
            }
        }

        private void frmTechnicianWiseJobs_Load(object sender, EventArgs e)
        {

            LoadCombo();
            rdoAll.Checked = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                Preview();
            }
            
        }
        private bool ValidateUIInput()
        {
            if (cmbWorkshop.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Workshop", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbTechnician.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Technician", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void Preview()
        {
            this.Cursor = Cursors.WaitCursor;
            rptTechnicianWiseJobs doc = new rptTechnicianWiseJobs();
            int nTechnicianID = _oTechnicians[cmbTechnician.SelectedIndex-1].TechnicianID;
            int nWorkshopID = _oCSDWorkshopTypes[cmbWorkshop.SelectedIndex-1].WorkshopTypeID;// should check is if workshopid/workshoptypeid?
            _oCSDJobs = new CSDJobs();
            _oCSDJobs.GetJobsInTechHand(nTechnicianID, nWorkshopID);

            doc.SetDataSource(_oCSDJobs);
            doc.SetParameterValue("PrintUser", Utility.Username);

            doc.SetParameterValue("Workshop", cmbWorkshop.Text);
            doc.SetParameterValue("Supervisor",cmbSupervisor.Text);
            doc.SetParameterValue("Technician",cmbTechnician.Text);

            if(rdoAll.Checked)
            {
                doc.SetParameterValue("TechType","All");
            }
            else if (rdoOwn.Checked)
            {
               doc.SetParameterValue("TechType","Own"); 
            }
            else if(rdoThirdparty.Checked)
            {
                doc.SetParameterValue("TechType","Third Party"); 
            }
                        
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }
    }
}