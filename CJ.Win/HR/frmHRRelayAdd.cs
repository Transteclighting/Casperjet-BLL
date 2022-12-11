using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRRelayAdd : Form
    {
        public frmHRRelayAdd()
        {
            InitializeComponent();
        }

        public void ShowDialog(HRRelay _oHRRelay)
        {
            if (_oHRRelay.IsActive == (int)Dictionary.HRRelayStatus.Active)
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoInactive.Checked = true;
            }
            txtRemarks.Text = _oHRRelay.Remarks;
            btnSave.Text = "Edit";
            this.Tag = _oHRRelay;
            this.ShowDialog();
        }
        private void frmHRRelayAdd_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                lblIsActive.Visible = false;
                rdoActive.Visible = false;
                rdoInactive.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();            
        }
        
        private void Save()
        {
            if (this.Tag == null)
            {
                HRRelay oHRRelay = new HRRelay();
                oHRRelay.Remarks = txtRemarks.Text;
                oHRRelay.StartTime = dtStartTime.Value;
                oHRRelay.EndTime = dtEndTime.Value;
                oHRRelay.IsActive = (int)Dictionary.HRRelayStatus.Active;
                oHRRelay.CreateUserID = Utility.UserId;
                oHRRelay.CreateDate = DateTime.Now;               

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRRelay.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save HR Relay","Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                HRRelay _oHRRelay = (HRRelay)this.Tag;
                _oHRRelay.Remarks = txtRemarks.Text;
                _oHRRelay.StartTime = dtStartTime.Value;
                _oHRRelay.EndTime = dtEndTime.Value;
                _oHRRelay.UpdateUserID = Utility.UserId;
                _oHRRelay.UpdateDate = DateTime.Now;
                if(rdoActive.Checked)
                {
                    _oHRRelay.IsActive = (int)Dictionary.HRRelayStatus.Active;
                }
                else
                {
                    _oHRRelay.IsActive = (int)Dictionary.HRRelayStatus.Inactive;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oHRRelay.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Edit HR Relay", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

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