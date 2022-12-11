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
    public partial class frmOutStationDuty : Form
    {
        public frmOutStationDuty()
        {
            InitializeComponent();
        }
        public void ShowDialog(OutStationDuty oOutStationDuty)
        {
            this.Tag = oOutStationDuty;
        
            ctlEmployee1.txtCode.Text = oOutStationDuty.Employee.EmployeeCode;

            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvOutStation);

            oRow.Cells[0].Value = oOutStationDuty.StartDate;
            oRow.Cells[1].Value = oOutStationDuty.EndDate;
            oRow.Cells[2].Value = oOutStationDuty.Adderss;
            oRow.Cells[3].Value = oOutStationDuty.Remarks;

            dgvOutStation.Rows.Add(oRow);
               
            this.ShowDialog();
        }

        private void frmOutStationDuty_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Duty";            
            }
            else this.Text = "Edit Duty";
            
        }
        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlEmployee1.SelectedEmployee == null || ctlEmployee1.txtCode.Text=="")
            {
                MessageBox.Show("Please Select a Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.Focus();
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvOutStation.Rows)
            {
                if (oItemRow.Index < dgvOutStation.Rows.Count - 1)
                {
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            //if (txtAddress.Text == "")
            //{
            //    MessageBox.Show("Please enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtAddress.Focus();
            //    return false;
            //}

            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();              
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {               
             
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgvOutStation.Rows)
                    {
                        if (oItemRow.Index < dgvOutStation.Rows.Count - 1)
                        {
                            OutStationDuty oOutStationDuty = new OutStationDuty();
                            oOutStationDuty.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                            oOutStationDuty.StartDate = Convert.ToDateTime(oItemRow.Cells[0].Value);
                            oOutStationDuty.EndDate = Convert.ToDateTime(oItemRow.Cells[1].Value);
                            oOutStationDuty.Adderss = oItemRow.Cells[2].Value.ToString().Trim();
                            oOutStationDuty.Remarks = oItemRow.Cells[3].Value.ToString().Trim();
                            oOutStationDuty.Status = (int)Dictionary.HROutStationDuty.Approved;
                            oOutStationDuty.Add();                           
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                } 
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {              
               

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgvOutStation.Rows)
                    {
                        if (oItemRow.Index < dgvOutStation.Rows.Count - 1)
                        {
                            OutStationDuty oOutStationDuty = (OutStationDuty)this.Tag;
                            oOutStationDuty.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                            oOutStationDuty.StartDate = Convert.ToDateTime(oItemRow.Cells[0].Value);
                            oOutStationDuty.EndDate = Convert.ToDateTime(oItemRow.Cells[1].Value);
                            oOutStationDuty.Adderss = oItemRow.Cells[2].Value.ToString().Trim();
                            oOutStationDuty.Remarks = oItemRow.Cells[3].Value.ToString().Trim();
                            oOutStationDuty.Status = (int)Dictionary.HROutStationDuty.Approved;
                            oOutStationDuty.Edit();
                        }
                    }                  
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("You Have Successfully Update The Duty ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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