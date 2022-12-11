using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.CSD;
using CJ.Class;


namespace CJ.Win.CSD.Workshop
{
    public partial class frmChangeTechnician : Form
    {
        CSDJob _oCSDJob;

        public frmChangeTechnician()
        {
            InitializeComponent();
        }

        private void frmChangeTechnician_Load(object sender, EventArgs e)
        {

        }

        private void ctlCSDTechnician1_Load(object sender, EventArgs e)
        {

        }
        private bool ValidateUIInput()
        {
            if (ctlCSDJob1.txtDescription.Text == string.Empty)
            {
                if (ctlCSDJob1.txtCode.Text != string.Empty)
                {
                    MessageBox.Show("Please Enter Valid Job Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please Enter Job Code/Select Job", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                return false;
            }
            if (ctlCSDTechnician1.txtDescription.Text == string.Empty)
            {
                if (ctlCSDTechnician1.txtCode.Text != string.Empty)
                {
                    MessageBox.Show("Please Enter Valid Job Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please Enter technician Code/Select Technician", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
                
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateUIInput())
            {
                UpdateTechnician();
                this.Close();
            }
             
             
        }
        private void UpdateTechnician()
        { 
            _oCSDJob = new CSDJob();
            _oCSDJob.JobID = ctlCSDJob1.SelectedJob.JobID;
            _oCSDJob.AssignTo = ctlCSDTechnician1.SelectedTechnician.TechnicianID;
            _oCSDJob.UpdateTechnician();
            MessageBox.Show("Successfully Assigned Technician", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}