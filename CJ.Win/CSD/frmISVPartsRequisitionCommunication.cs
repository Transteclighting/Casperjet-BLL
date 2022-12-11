using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win
{
    public partial class frmISVPartsRequisitionCommunication : Form
    {
        ISVSpareCommunication _oISVSpareCommunication;

        public frmISVPartsRequisitionCommunication()
        {
            InitializeComponent();
        }
        public void DataLoadControl()
        {

            ISVSpareCommunications oISVSpareCommunications = new ISVSpareCommunications();

            dgvRequisitionItemCommu.Rows.Clear();
            DBController.Instance.OpenNewConnection();
            if (ctlInterService1.SelectedInterService != null)
            {
                oISVSpareCommunications.Refresh(txtRequisitionIDs.Text, txtSerialNos.Text, txtJobNos.Text, txtReportNos.Text, ctlInterService1.SelectedInterService.InterServiceID);
            }
            else
            {
                oISVSpareCommunications.Refresh(txtRequisitionIDs.Text, txtSerialNos.Text, txtJobNos.Text, txtReportNos.Text, 0);

            }

            foreach (ISVSpareCommunication oISVSpareCommunication in oISVSpareCommunications)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvRequisitionItemCommu);
                oRow.Cells[1].Value = oISVSpareCommunication.SpareParts.Code.ToString();
                oRow.Cells[2].Value = oISVSpareCommunication.SpareParts.Name.ToString();
                oRow.Cells[3].Value = oISVSpareCommunication.SparePartsTransactionDetail.ClaimQty.ToString();
                oRow.Cells[4].Value = oISVSpareCommunication.ReplaceJobFromCassandra.JobNo.ToString();
                oRow.Cells[5].Value = oISVSpareCommunication.Remarks.ToString();
                oRow.Cells[6].Value = oISVSpareCommunication.SparePartsTransactionDetail.SubStatusName.ToString();
                oRow.Cells[7].Value = oISVSpareCommunication.SerarchProduct.ProductName.ToString();
                oRow.Cells[8].Value = Convert.ToDateTime(oISVSpareCommunication.EDD.ToString("dd-MMM-yyyy"));
                oRow.Cells[9].Value = oISVSpareCommunication.InterService.Code.ToString();
                oRow.Cells[10].Value = oISVSpareCommunication.InterService.Name.ToString();
                oRow.Cells[11].Value = oISVSpareCommunication.SparePartsTransactionDetail.ISVRequisitionID.ToString();
                oRow.Cells[12].Value = oISVSpareCommunication.SparePartsTransaction.SerialNo.ToString();
                oRow.Cells[13].Value = oISVSpareCommunication.SparePartsTransaction.ReportNo.ToString();
                oRow.Cells[14].Value = oISVSpareCommunication.ID.ToString();


                dgvRequisitionItemCommu.Rows.Add(oRow);
            }

            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (dgvRequisitionItemCommu.RowCount > 0)
            {
                foreach (DataGridViewRow oRow in dgvRequisitionItemCommu.Rows)
                {
                    string RowType = oRow.Cells[6].Value.ToString();

                    if (RowType == Dictionary.ISVRequisitionSubStatus.ForeignOrder.ToString())
                    {
                        //oRow.DefaultCellStyle.BackColor = Color.Orange;
                        oRow.DefaultCellStyle.ForeColor = Color.RoyalBlue;
                        
                    }
                   else if (RowType == Dictionary.ISVRequisitionSubStatus.LocalPurchase.ToString())
                    {
                        //oRow.DefaultCellStyle.BackColor = Color.GreenYellow;
                        oRow.DefaultCellStyle.ForeColor = Color.SaddleBrown;
                    }
                    else if (RowType == Dictionary.ISVRequisitionSubStatus.LoanRequisition.ToString())
                    {
                        //oRow.DefaultCellStyle.BackColor = Color.GreenYellow;
                        oRow.DefaultCellStyle.ForeColor = Color.ForestGreen;
                    }
                    else if (RowType == Dictionary.ISVRequisitionSubStatus.Suspend.ToString())
                    {
                        //oRow.DefaultCellStyle.BackColor = Color.GreenYellow;
                        oRow.DefaultCellStyle.ForeColor = Color.DeepPink;
                    }
                    else if (RowType == Dictionary.ISVRequisitionSubStatus.Rejected.ToString())
                    {
                        //oRow.DefaultCellStyle.BackColor = Color.GreenYellow;
                        oRow.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    
                }
            }
        }
   

        private void frmISVPartsRequisitionCommunication_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (validateUIInput())
            //{
                Save();
                DataLoadControl();


            //}
        }
        private void Save()
        {
            if (dgvRequisitionItemCommu.Rows.Count != 0)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();


                    foreach (DataGridViewRow oItemRow in dgvRequisitionItemCommu.Rows)
                    {
                        if (oItemRow.Index < dgvRequisitionItemCommu.Rows.Count)
                        {

                            _oISVSpareCommunication = new ISVSpareCommunication();
                            _oISVSpareCommunication.ID = Convert.ToInt32(oItemRow.Cells[14].Value.ToString().Trim());

                            
                            if (Convert.ToBoolean(oItemRow.Cells[0].Value) == true)
                            {

                                _oISVSpareCommunication = new ISVSpareCommunication();

                                _oISVSpareCommunication.ID = Convert.ToInt32(oItemRow.Cells[14].Value.ToString().Trim());
                                _oISVSpareCommunication.Remarks = oItemRow.Cells[5].Value.ToString().Trim();
                                _oISVSpareCommunication.UpdateCommunication();
                            }
                            else
                            {
                                //DBController.Instance.CommitTransaction();
                                //MessageBox.Show("Please Checked Item(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("There Is no data to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                DBController.Instance.CommitTransaction();
                MessageBox.Show("There is no item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                foreach (DataGridViewRow oItemRow in dgvRequisitionItemCommu.Rows)
                {
                    if (oItemRow.Index < dgvRequisitionItemCommu.Rows.Count)
                    {
                        oItemRow.Cells[0].Value = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow oItemRow in dgvRequisitionItemCommu.Rows)
                {
                    if (oItemRow.Index < dgvRequisitionItemCommu.Rows.Count)
                    {
                        oItemRow.Cells[0].Value = false;
                    }
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }
}