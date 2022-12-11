using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Workshop
{
    public partial class frmTechnicianBlock : Form
    {
        public frmTechnicianBlock()
        {
            InitializeComponent();
        }

        public void ShowDialog(CSDTechnicianBlock oCSDTechnicianBlock)
        {
            this.Tag = oCSDTechnicianBlock;
            ctlCSDTechnician1.txtCode.Text = oCSDTechnicianBlock.Code;
            dtFromDate.Value = oCSDTechnicianBlock.FromDate;
            dtToDate.Value = oCSDTechnicianBlock.ToDate;
            txtRemarks.Text = oCSDTechnicianBlock.Remarks;
            if (oCSDTechnicianBlock.IsFullTime == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkFullDay.Checked = true;
                dtFromTime.Visible = false;
                dtToTime.Visible = false;
                label2.Visible = false;
                label1.Visible = false;
            }
            else
            {
                chkFullDay.Checked = false;
                dtFromTime.Visible = true;
                dtToTime.Visible = true;
                label2.Visible = true;
                label1.Visible = true;
            }
            if (oCSDTechnicianBlock.FromTime != null)
            {
                dtFromTime.Value = Convert.ToDateTime(oCSDTechnicianBlock.FromTime);

            }

            if (oCSDTechnicianBlock.ToTime != null)
            {
                dtToTime.Value = Convert.ToDateTime(oCSDTechnicianBlock.ToTime);
            }

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (ctlCSDTechnician1.SelectedTechnician == null || ctlCSDTechnician1.txtCode.Text == "")
            {
                MessageBox.Show("Please Enter Technician Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCSDTechnician1.Focus();
                return false;
            }
            #endregion
            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                CSDTechnicianBlock oCSDTechnicianBlock = new CSDTechnicianBlock();
                oCSDTechnicianBlock .TechnicianID= ctlCSDTechnician1.SelectedTechnician.TechnicianID;
                oCSDTechnicianBlock.FromDate = dtFromDate.Value;
                oCSDTechnicianBlock.ToDate = dtToDate.Value;
                if (!chkFullDay.Checked)
                {
                    oCSDTechnicianBlock.FromTime = dtFromTime.Value;
                    oCSDTechnicianBlock.ToTime = dtToTime.Value;
                }                
                oCSDTechnicianBlock.CreateUserID = Utility.UserId;
                oCSDTechnicianBlock.CreateDate = DateTime.Now;
                oCSDTechnicianBlock.Remarks = txtRemarks.Text;
                if (chkFullDay.Checked)
                {
                    oCSDTechnicianBlock.IsFullTime = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oCSDTechnicianBlock.IsFullTime = (int)Dictionary.YesOrNoStatus.NO;
                }

                oCSDTechnicianBlock.Status = (int)Dictionary.TechnicianBlockStatus.Create;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDTechnicianBlock.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Technician", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                CSDTechnicianBlock oCSDTechnicianBlock = (CSDTechnicianBlock)this.Tag;
                oCSDTechnicianBlock.TechnicianID = ctlCSDTechnician1.SelectedTechnician.TechnicianID;
                oCSDTechnicianBlock.FromDate = dtFromDate.Value;
                oCSDTechnicianBlock.ToDate = dtToDate.Value;

                if (!chkFullDay.Checked)
                {
                    oCSDTechnicianBlock.FromTime = dtFromTime.Value;
                    oCSDTechnicianBlock.ToTime = dtToTime.Value;
                }
                else
                {
                    oCSDTechnicianBlock.FromTime = null;
                    oCSDTechnicianBlock.ToTime = null;
                }
                
                if (chkFullDay.Checked)
                {
                    oCSDTechnicianBlock.IsFullTime = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oCSDTechnicianBlock.IsFullTime = (int)Dictionary.YesOrNoStatus.NO;
                }

                oCSDTechnicianBlock.UpdateUserID = Utility.UserId;
                oCSDTechnicianBlock.UpdateDate = DateTime.Now;
                oCSDTechnicianBlock.Remarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDTechnicianBlock.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Technician : " + oCSDTechnicianBlock.ID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void frmTechnicianBlock_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void chkFullDay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFullDay.Checked)
            {
                dtFromTime.Visible = false;
                dtToTime.Visible = false;
                label2.Visible = false;
                label1.Visible = false;
            }
            else
            {
                dtFromTime.Visible = true;
                dtToTime.Visible = true;
                label2.Visible = true;
                label1.Visible = true;
            }
        }
    }
}