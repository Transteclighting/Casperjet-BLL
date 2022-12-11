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
    public partial class frmCACProjectTaskComplete : Form
    {
        CACProjectTaskComplete oCACProjectTaskComplete;
        CACProjectTaskWeights oCACProjectTaskWeights;
        int nProjectID = 0;
        int _nStatus = 0;
        public bool IsTrue = false;
        double dTotal = 0;
        int _nTotal = 0;
        int _nComplete = 0;
        int _nProgress = 0;
        public frmCACProjectTaskComplete(int nStatus)
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
            dTotal = oCACProject.CompleteTaskValue;
            CACProjectTaskWeights oCACProjectTaskWeights = new CACProjectTaskWeights();
            oCACProjectTaskWeights.RefreshByTaskWeight(nProjectID);
            foreach (CACProjectTaskWeight oItem in oCACProjectTaskWeights)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvTaskComplete);
                oRow.Cells[0].Value = oItem.TaskName.ToString();
                oRow.Cells[1].Value = Convert.ToDateTime(oItem.StartDate.ToString("dd-MMM-yyyy"));
                oRow.Cells[2].Value =Convert.ToDateTime(oItem.EndDate.ToString("dd - MMM - yyyy"));
                oRow.Cells[3].Value = oItem.Weight.ToString();
                //oRow.Cells[5].Value = int.Parse(oRow.Cells[3].Value.ToString()) - int.Parse(oRow.Cells[4].Value.ToString());
                oRow.Cells[4].Value = oItem.CompletePercent.ToString();
                oRow.Cells[5].Value = Math.Round((double.Parse(oRow.Cells[4].Value.ToString()) / double.Parse(oRow.Cells[3].Value.ToString()))*100,2);               
                oRow.Cells[6].Value = 0;
                oRow.Cells[7].Value = oItem.TaskID.ToString();
                oRow.Cells[8].Value = oItem.ID.ToString();
                dgvTaskComplete.Rows.Add(oRow);
            }
            this.ShowDialog();
        }
        private void frmCACProjectTaskComplete_Load(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetTotal()
        {
           txtTotalCompleteWeight.Text = "0.00";

            foreach (DataGridViewRow oRow in dgvTaskComplete.Rows)
            {
                if (oRow.Cells[6].Value != null)
                {

                    txtTotalCompleteWeight.Text = Convert.ToDouble(Convert.ToDouble(txtTotalCompleteWeight.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString())).ToString();

                }
            }

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            if (nColumnIndex == 6)
            {
                if (dgvTaskComplete.Rows[nRowIndex].Cells[6].Value.ToString() != null)
                {
                    try
                    {
                        dgvTaskComplete.Rows[nRowIndex].Cells[6].Value = Convert.ToDouble(dgvTaskComplete.Rows[nRowIndex].Cells[6].Value.ToString());

                    }
                    catch
                    {
                        //MessageBox.Show("");

                    }
                }
                GetTotal();
            }
        }
        private bool UIvalidation()
        {
            #region Transaction Details Information Validation 
                         
            foreach (DataGridViewRow oItemRow in dgvTaskComplete.Rows)
            {
                _nTotal = int.Parse(oItemRow.Cells[3].Value.ToString());
                _nComplete = int.Parse(oItemRow.Cells[4].Value.ToString());
                _nProgress = int.Parse(oItemRow.Cells[6].Value.ToString());
                int _Total = 0;
                _Total = _nTotal - _nComplete;
                if (oItemRow.Index < dgvTaskComplete.Rows.Count)
                {
                    if (int.Parse(oItemRow.Cells[6].Value.ToString()) > int.Parse(oItemRow.Cells[3].Value.ToString())|| _nProgress > _Total || _nProgress < 0)
                    {
                        MessageBox.Show("Progress Weight not grater than Weight/ or Negative", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            if (dTotal >= 100)
            {
                MessageBox.Show("Weight not Greater than 100 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalCompleteWeight.Focus();
                return false;
            }
            #endregion
            return true;
        }
        private void ADDCACProjectTaskCompleteWeight(CACProjectTaskComplete oCACProjectTaskComplete)
        {
            foreach (DataGridViewRow oItemRow in dgvTaskComplete.Rows)
            {
                if (oItemRow.Index < dgvTaskComplete.Rows.Count)
                {
                    oCACProjectTaskComplete = new CACProjectTaskComplete();
                    oCACProjectTaskComplete.ProjectID = nProjectID;
                    oCACProjectTaskComplete.TaskID = int.Parse(oItemRow.Cells[7].Value.ToString());
                    oCACProjectTaskComplete.Date = DateTime.Now;
                    oCACProjectTaskComplete.CompleteProgressWeight = int.Parse(oItemRow.Cells[6].Value.ToString());
                    oCACProjectTaskComplete.Add();

                }
            }

        }
        private void Save()
        {
            if (UIvalidation())
            {
                CACProjectTaskComplete oCACProjectTaskComplete = new CACProjectTaskComplete();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    ADDCACProjectTaskCompleteWeight(oCACProjectTaskComplete);
                    foreach (DataGridViewRow oItemRow in dgvTaskComplete.Rows)
                    {

                        if (oItemRow.Index < dgvTaskComplete.Rows.Count)
                        {
                            CACProjectTaskWeight oCACProjectTaskWeight = new CACProjectTaskWeight();
                            oCACProjectTaskWeight.ID = int.Parse(oItemRow.Cells[8].Value.ToString());
                            oCACProjectTaskWeight.ProjectID = nProjectID;
                            oCACProjectTaskWeight.CompletePercent = int.Parse(oItemRow.Cells[6].Value.ToString());
                            oCACProjectTaskWeight.UpdateCompleteTaskWeight(nProjectID, oCACProjectTaskWeight.ID);
                        }
                    }
                    CACProject oCACProject = new CACProject();
                    //int _nTotal = 0;
                    //int _nComplete = 0;
                    //int _nProgress = 0;
                    foreach (DataGridViewRow oItemRow in dgvTaskComplete.Rows)
                    {
                        if (oItemRow.Index < dgvTaskComplete.Rows.Count)
                        {
                            _nTotal += int.Parse(oItemRow.Cells[3].Value.ToString());
                            _nComplete += int.Parse(oItemRow.Cells[4].Value.ToString());
                            _nProgress+= int.Parse(oItemRow.Cells[6].Value.ToString());
                            //if (int.Parse(oItemRow.Cells[3].Value.ToString()) != (int.Parse(oItemRow.Cells[4].Value.ToString()) + int.Parse(oItemRow.Cells[6].Value.ToString())))
                            //{
                            //    _nStatus = (int)Dictionary.CACProjectStatus.Running;
                            //}
                            //else if (int.Parse(oItemRow.Cells[3].Value.ToString()) == int.Parse(oItemRow.Cells[4].Value.ToString()) + int.Parse(oItemRow.Cells[6].Value.ToString()))
                            //{
                            //    _nStatus = (int)Dictionary.CACProjectStatus.Complete;
                            //}
                        }
                    }
                    if (_nTotal != (_nComplete + _nProgress))
                    {
                        _nStatus = (int)Dictionary.CACProjectStatus.Running;
                    }
                    else
                    {
                        _nStatus = (int)Dictionary.CACProjectStatus.Complete;
                    }
                    oCACProject.CompleteTaskValue = Convert.ToDouble(txtTotalCompleteWeight.Text);
                    oCACProject.UpdateTaskCompleteprogress(nProjectID, _nStatus);
                    DBController.Instance.CommitTransaction();
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

                MessageBox.Show("Saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            IsTrue = true;
        }

        private void dgvTaskComplete_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvTaskComplete_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }
    }
}
