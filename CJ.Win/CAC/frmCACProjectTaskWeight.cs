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
    public partial class frmCACProjectTaskWeight : Form
    {
        CACProjectTasks oCACProjectTasks;
        CACProjectTaskWeight _oCACProjectTaskWeight;
        CACProjectTask oCACProjectTask;
        int nProjectID = 0;
        int nTaskID = 0;
        int _nStatus = 0;
        public bool IsTrue = false;
        int nProjectStatus = 0;

        public frmCACProjectTaskWeight(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(CACProject oCACProject)
        {
            this.Tag = oCACProject;
            nProjectID = oCACProject.ProjectID;
            lblCode.Text = oCACProject.ProjectCode;
            lblName.Text = oCACProject.ProjectName;
            nProjectStatus = oCACProject.Status;
            CACProjectTasks oCACProjectTasks = new CACProjectTasks();
            if (oCACProject.Status == (int)Dictionary.CACProjectStatus.Create|| oCACProject.Status == (int)Dictionary.CACProjectStatus.Pending)
            {
                oCACProjectTasks.Refresh();
            }
            else if (oCACProject.Status == (int)Dictionary.CACProjectStatus.Running)
            {
                oCACProjectTasks.RefreshWeight(nProjectID);
            }
            foreach (CACProjectTask oItem in oCACProjectTasks)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvTask);
                if (oCACProject.Status == (int)Dictionary.CACProjectStatus.Create || oCACProject.Status == (int)Dictionary.CACProjectStatus.Pending)
                {
                    oRow.Cells[0].Value = oItem.TaskName.ToString();
                    oRow.Cells[1].Value = DateTime.Now;
                    oRow.Cells[2].Value = DateTime.Now;
                    oRow.Cells[3].Value =0;
                }
                else if (oCACProject.Status == (int)Dictionary.CACProjectStatus.Running)
                {
                    oRow.Cells[0].Value = oItem.TaskName.ToString();
                    oRow.Cells[1].Value = oItem.StartDate.ToString("dd-MMM-yyyy");
                    oRow.Cells[2].Value = oItem.EndDate.ToString("dd-MMM-yyyy");
                    oRow.Cells[3].Value = oItem.Weight;
                }
                oRow.Cells[4].Value = oItem.TaskID.ToString();
                    dgvTask.Rows.Add(oRow);
                }           
            this.ShowDialog();
        }
        private void frmCACProjectTaskWeight_Load(object sender, EventArgs e)
        {
            if (nProjectStatus == (int)Dictionary.CACProjectStatus.Running)
            {
                foreach (DataGridViewRow oItemRow in dgvTask.Rows)
                {
                    oItemRow.Cells[1].ReadOnly = true;
                    oItemRow.Cells[2].ReadOnly = true;
                    oItemRow.Cells[1].Style.BackColor = Color.LightGray;
                    oItemRow.Cells[2].Style.BackColor = Color.LightGray;
                }
            }
            GetTotal();
        }
        private void GetTotal()
        {
           txtTotalWeight.Text = "0.00";

            foreach (DataGridViewRow oRow in dgvTask.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {

                    txtTotalWeight.Text = Convert.ToDouble(Convert.ToDouble(txtTotalWeight.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();

                }
            }

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            if (nColumnIndex == 3)
            {
                if (dgvTask.Rows[nRowIndex].Cells[3].Value.ToString() != null)
                {
                    try
                    {
                        dgvTask.Rows[nRowIndex].Cells[3].Value = Convert.ToDouble(dgvTask.Rows[nRowIndex].Cells[3].Value.ToString());

                    }
                    catch
                    {
                        //MessageBox.Show("");

                    }
                }                
                GetTotal();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ADDCACProjectTask(CACProjectTaskWeight oCACProjectTaskWeight)
        {
            //foreach (DataGridViewRow oItemRow in dgvTask.Rows)
            //{
            //    if (oItemRow.Index < dgvTask.Rows.Count)
            //    {
            //        oCACProjectTaskWeight = new CACProjectTaskWeight();
            //        oCACProjectTaskWeight.ProjectID= nProjectID;
            //        oCACProjectTaskWeight.TaskID = int.Parse(oItemRow.Cells[3].Value.ToString());
            //        oCACProjectTaskWeight.Weight = int.Parse(oItemRow.Cells[1].Value.ToString());
            //        oCACProjectTaskWeight.CompletePercent= int.Parse(oItemRow.Cells[2].Value.ToString());
            //        oCACProjectTaskWeight.Add();

            //    }
            //}            
        }       
        private bool UIvalidation()
        {
            if (nProjectStatus == (int)Dictionary.CACProjectStatus.Create)
            {
                if (Convert.ToDouble(txtTotalWeight.Text.Trim()) < 100 || Convert.ToDouble(txtTotalWeight.Text.Trim()) > 100)
                    {
                        MessageBox.Show("Weight not less than/Greater than 100 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTotalWeight.Focus();
                        return false;
                    }
            }
            else if(nProjectStatus == (int)Dictionary.CACProjectStatus.Running)
            {
                if (Convert.ToDouble(txtTotalWeight.Text.Trim()) == 100)
                {
                    MessageBox.Show("Weight is already exit ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTotalWeight.Focus();
                    return false;
                }
            }
            return true; 
        }

        private void Save()
        {
            if (UIvalidation())
            {
                try
            {
                DBController.Instance.BeginNewTransaction();
                _oCACProjectTaskWeight = new CACProjectTaskWeight();
                _oCACProjectTaskWeight.DeleteByTaskWeight(nProjectID);
                    foreach (DataGridViewRow oItemRow in dgvTask.Rows)
                    {
                        if (oItemRow.Index < dgvTask.Rows.Count)
                        {
                            CACProjectTaskWeight oCACProjectTaskWeight = new CACProjectTaskWeight();

                            oCACProjectTaskWeight.ProjectID = nProjectID;
                            oCACProjectTaskWeight.TaskID = int.Parse(oItemRow.Cells[4].Value.ToString());
                            oCACProjectTaskWeight.Weight = int.Parse(oItemRow.Cells[3].Value.ToString());
                            oCACProjectTaskWeight.StartDate = Convert.ToDateTime(oItemRow.Cells[1].Value.ToString());
                            oCACProjectTaskWeight.EndDate = Convert.ToDateTime(oItemRow.Cells[2].Value.ToString());
                            oCACProjectTaskWeight.CompletePercent = 0;
                            if (oCACProjectTaskWeight.Weight > 0)
                                oCACProjectTaskWeight.Add();
                        }
                    }
                    CACProject oCACProject = new CACProject();
                    if (_nStatus == (int)Dictionary.CACProjectStatus.Running)
                    {
                        oCACProject.Status = (int)Dictionary.CACProjectStatus.Running;
                    }
                    oCACProject.UpdateByTaskWeight(nProjectID);

                    DBController.Instance.CommitTran();
                MessageBox.Show("Success fully Save # ", "Task Weight", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }   
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            IsTrue = true;
        }

        private void dgvTask_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvTask_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }
    }
}
