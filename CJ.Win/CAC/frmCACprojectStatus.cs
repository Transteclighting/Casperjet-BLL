using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CAC
{
    public partial class frmCACprojectStatus : Form
    {
        CACProject oCACProject;
        int _nStatus = 0;
        int _nProjectID =0;
        public frmCACprojectStatus(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(int nProjectID,string sCode,string sName)
        {
            DBController.Instance.OpenNewConnection();
            _nProjectID = nProjectID;
            lblCode.Text = sCode;
            lblName.Text = sName;
            this.ShowDialog();
        }
        private void frmCACprojectStatus_Load(object sender, EventArgs e)
        {
            if (_nStatus == (int)Dictionary.CACProjectStatus.Pending)
            {
                btnSave.Text = "Pending";
                lblRemarks.Text = "Reason";
            }
            else if (_nStatus == (int)Dictionary.CACProjectStatus.Cancel)
            {
                btnSave.Text = "Cancel";
                lblRemarks.Text = "Reason";
            }
            else if (_nStatus == (int)Dictionary.CACProjectStatus.Handover)
            {
                btnSave.Text = "Handover";
                lblRemarks.Text = "Handover";
                lblRemarks.Enabled = false;
                txtRemarks.Enabled = false;
                lblRemarks.Visible = false;
                txtRemarks.Visible = false;

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
                try
                {
                    oCACProject = new CACProject();
                    oCACProject.ProjectID = _nProjectID;
                    if (_nStatus == (int)Dictionary.CACProjectStatus.Pending)
                    {
                        oCACProject.Status = (int)Dictionary.CACProjectStatus.Pending;
                    }
                    else if (_nStatus == (int)Dictionary.CACProjectStatus.Cancel)
                    {
                        oCACProject.Status = (int)Dictionary.CACProjectStatus.Cancel;
                    }
                    else if (_nStatus == (int)Dictionary.CACProjectStatus.Handover)
                    {
                        oCACProject.Status = (int)Dictionary.CACProjectStatus.Handover;
                    }
                    oCACProject.StatusReason = txtRemarks.Text;                    
                    DBController.Instance.BeginNewTransaction();
                    oCACProject.UpdateByProjectStatus(_nProjectID,_nStatus);                    
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Success fully Save # " + oCACProject.ProjectID.ToString(), "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
