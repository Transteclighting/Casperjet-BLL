
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
    public partial class frmTechnicians : Form
    {
        Workshops _oWorkshop;
        TechnicalSupervisors _oTechnicalSupervisors;
        public frmTechnicians()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void DataLoadControl()
        {

                Technicians oTechnicians = new Technicians();

                lvwTechnicians.Items.Clear();
                DBController.Instance.OpenNewConnection();
                int nTechnicianTypeID = 0;
                if (cmbTechnicianType.SelectedIndex != 0)
                {
                    nTechnicianTypeID = cmbTechnicianType.SelectedIndex;
                }
                int nWorkshopTypeID = 0;
                if (cmbWorkshopType.SelectedIndex != 0)
                {
                    nWorkshopTypeID = _oWorkshop[cmbWorkshopType.SelectedIndex - 1].WorkshopTypeID;
                }
                int nSupervisorID = 0;
                if (cmbSupervisor.SelectedIndex != 0)
                {
                    nSupervisorID = _oTechnicalSupervisors[cmbSupervisor.SelectedIndex - 1].SupervisorID;
                }
                int nThirdPartyID = 0;
                if (ctlInterService1.txtDescription.Text != string.Empty)
                {
                    nThirdPartyID = ctlInterService1.SelectedInterService.InterServiceID;
                }
                oTechnicians.Refresh(txtTechnicianCode.Text.Trim(), txtTechnicianName.Text.Trim(), txtMobile.Text.Trim(), nTechnicianTypeID, nWorkshopTypeID, nSupervisorID, nThirdPartyID);

                this.Text = "Total " + "[" + oTechnicians.Count + "]";
                foreach (Technician oTechnician in oTechnicians)
                {
                    ListViewItem oItem = lvwTechnicians.Items.Add(oTechnician.Code.ToString());
                    oItem.SubItems.Add(oTechnician.Name.ToString());
                    oItem.SubItems.Add(oTechnician.Workshop.Name.ToString());
                    oItem.SubItems.Add(oTechnician.WorkshopLocation.Name.ToString());
                    oItem.SubItems.Add(oTechnician.SupervisorName);
                    if (oTechnician.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                    {
                        oItem.SubItems.Add("True");
                    }
                    else
                    {
                        oItem.SubItems.Add("False");
                    }
                    oItem.SubItems.Add(oTechnician.User.Username.ToString());

                    oItem.SubItems.Add(oTechnician.TechnicianTypeName.ToString());

                    if (oTechnician.IsVariable == 1)
                    {
                        oItem.SubItems.Add("Yes");
                    }
                    else
                    {
                        oItem.SubItems.Add("No");
                    }

                    oItem.SubItems.Add(oTechnician.ThirdPartyName.ToString());
                    oItem.SubItems.Add(oTechnician.MobileNo);
                    oItem.SubItems.Add(oTechnician.MobileNo1);
                    oItem.SubItems.Add(oTechnician.CreateDate.ToString("dd-MMM-yyyy"));
                    oItem.Tag = oTechnician;
                }
                setListViewRowColour();
            
        }
        private void setListViewRowColour()
        {
            if (lvwTechnicians.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwTechnicians.Items)
                {
                   
                    if (oItem.SubItems[5].Text == Dictionary.InquiryCommunicationStatus.False.ToString())
                    {
                        oItem.BackColor = Color.DarkGray;
                    }
                    
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmTechnician oForm = new frmTechnician();
            oForm.ShowDialog();
            if (oForm._bAction)
            {
                DataLoadControl();
            }      
        }

        private void frmTechnicians_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }
        private void LoadCombos()
        {
            //Get Technician Type
            cmbTechnicianType.Items.Clear();
            cmbTechnicianType.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDTechnicianType)))
            {
                cmbTechnicianType.Items.Add(Enum.GetName(typeof(Dictionary.CSDTechnicianType), GetEnum));
            }
            cmbTechnicianType.SelectedIndex = 0;

           
            //Get Workshop Type
            _oWorkshop = new Workshops();
            _oWorkshop.Refresh();
            cmbWorkshopType.Items.Clear();
            cmbWorkshopType.Items.Add("--All--");
            foreach (Workshop oWorkshop in _oWorkshop)
            {
                cmbWorkshopType.Items.Add(oWorkshop.Name);
            }
            cmbWorkshopType.SelectedIndex = 0;

            //Get Technician Supervisor
            _oTechnicalSupervisors = new TechnicalSupervisors();
            _oTechnicalSupervisors.RefreshAll();
            cmbSupervisor.Items.Add("--All--");
            foreach (TechnicalSupervisor oTechnicalSupervisor in _oTechnicalSupervisors)
            {
                cmbSupervisor.Items.Add(oTechnicalSupervisor.Employee.EmployeeName);
            }
            cmbSupervisor.SelectedIndex = 0;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwTechnicians.SelectedItems.Count != 0)
            {

                Technician oTechnician = (Technician)lvwTechnicians.SelectedItems[0].Tag;

                frmTechnician oForm = new frmTechnician();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Technician";
                oForm.ShowDialog(oTechnician);
                if (oForm._bAction)
                {
                    DataLoadControl();
                }

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwWorkshops_DoubleClick(object sender, EventArgs e)
        {
            if (lvwTechnicians.SelectedItems.Count != 0)
            {

                Technician oTechnician = (Technician)lvwTechnicians.SelectedItems[0].Tag;

                frmTechnician oForm = new frmTechnician();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Technician";
                oForm.ShowDialog(oTechnician);
                if (oForm._bAction)
                {
                    DataLoadControl();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        
    }
}