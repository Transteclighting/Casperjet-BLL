using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmCACProjectTask : Form
    {
        public bool _Istrue = false;
        int nID = 0;
        CACProjectTask _oCACProjectTask;
        public frmCACProjectTask()
        {
            InitializeComponent();
        }
        public void ShowDialog(CACProjectTask oCACProjectTask)
        {
            this.Tag = oCACProjectTask;
            nID = oCACProjectTask.TaskID;
            txtTaskName.Text = oCACProjectTask.TaskName;
            if(oCACProjectTask.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            this.ShowDialog();
        }
        private void frmCACProjectTask_Load(object sender, EventArgs e)
        {

        }
        private bool UIValidation()
        {
            #region ValidInput
            if (txtTaskName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Task Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaskName.Focus();
                return false;
            }            
            #endregion

            return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oCACProjectTask = new CACProjectTask();
                _oCACProjectTask.TaskName= txtTaskName.Text;
                _oCACProjectTask.CreateUserID = Utility.UserId;
                _oCACProjectTask.CreateDate = DateTime.Now;
                if(chkIsActive.Checked==true)
                {
                    _oCACProjectTask.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oCACProjectTask.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCACProjectTask.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add . Payment Type : " + _oCACProjectTask.TaskID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                CACProjectTask _oCACProjectTask = (CACProjectTask)this.Tag;
                _oCACProjectTask.TaskName = txtTaskName.Text;
                _oCACProjectTask.CreateUserID = Utility.UserId;
                _oCACProjectTask.CreateDate = DateTime.Now;
                if (chkIsActive.Checked == true)
                {
                    _oCACProjectTask.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oCACProjectTask.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCACProjectTask.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add . Payment Type  : " + _oCACProjectTask.TaskID, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _Istrue = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _Istrue = false;
            this.Close();
        }
    }
}
