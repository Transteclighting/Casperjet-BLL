using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Warranty;

namespace CJ.Win.Warranty
{
    public partial class frmWarrantyClaimDistribution : Form
    {
        WarrantyClaimDistributions _oWarrantyClaimDists;
        WarrantyClaimDistribution _oWarrantyClaimDist;
        CSDJobsForWarrantys _oCSDJobsForWarrantys;
        CSDJobsForWarranty _oCSDJobsForWarranty;

        public bool _IsTrue = false;
        int nWarrantyClaimDistID = 0;
        public bool _bActionSave = false;

        public frmWarrantyClaimDistribution()
        {
            InitializeComponent();
        }

        private void frmWarrantyClaimDistribution_Load(object sender, EventArgs e)
        {
            LoadSupplier();
        }

        private bool validateUIInput()
        {
            
             //double ServiceCharge = Convert.ToInt32(txtSCharge.Text.ToString());
            if (txtTotalServiceCharge.Text != txtSCharge.Text)
            {
                MessageBox.Show("Service Charge not matched", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalServiceCharge.Focus();
                return false;
            }

            if (txtTotalSPCharge.Text != txtSPCharge.Text)
            {
                MessageBox.Show("Spare Parts Charge not matched", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalSPCharge.Focus();
                return false;
            }

            if (txtTotalTransportationCharge.Text != txtTransportCharge.Text)
            {
                MessageBox.Show("Transportation Charge not matched", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalTransportationCharge.Focus();
                return false;
            }

            if (txtTotalOtherCharge.Text != txtOCharge.Text)
            {
                MessageBox.Show("Other Charge not matched", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalOtherCharge.Focus();
                return false;
            }

            return true;
        }

        private void Save()
        {
            foreach (CSDJobsForWarranty oCSDJobsForWarranty in _oCSDJobsForWarrantys)
            {
                int joibID = oCSDJobsForWarranty.JobID;

                try
                {
                    DBController.Instance.BeginNewTransaction();


                    foreach (DataGridViewRow oItemRow in dgvList.Rows)
                    {
                        if (Convert.ToInt32(oItemRow.Cells[dgvList.Columns[1].Index].Value) != 0 || Convert.ToInt32(oItemRow.Cells[dgvList.Columns[2].Index].Value) != 0 || Convert.ToInt32(oItemRow.Cells[dgvList.Columns[3].Index].Value) != 0 || Convert.ToInt32(oItemRow.Cells[dgvList.Columns[4].Index].Value) != 0)
                        {
                            if (oItemRow.Index < dgvList.Rows.Count)
                            {
                                WarrantyClaimDistribution oWarrantyClaimDist = new WarrantyClaimDistribution();
                                oWarrantyClaimDist.JobID = joibID;
                                oWarrantyClaimDist.SupplierID = int.Parse(oItemRow.Cells[5].Value.ToString());
                                oWarrantyClaimDist.ServiceCharge = int.Parse(oItemRow.Cells[1].Value.ToString());
                                oWarrantyClaimDist.SparePartsCharge = int.Parse(oItemRow.Cells[2].Value.ToString());
                                oWarrantyClaimDist.TransportationCharge = int.Parse(oItemRow.Cells[3].Value.ToString());
                                oWarrantyClaimDist.OtherCharge = int.Parse(oItemRow.Cells[4].Value.ToString());
                                oWarrantyClaimDist.Add();

                            }
                        }
                    }

                    oCSDJobsForWarranty.IsWarrantyDistribution = 1;

                    oCSDJobsForWarranty.UpdateCSDJobBill();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void GetTotal()
        {
            txtTotalServiceCharge.Text = "0.00";
            txtTotalSPCharge.Text = "0.00";
            txtTotalTransportationCharge.Text = "0.00";
            txtTotalOtherCharge.Text = "0.00";

            foreach (DataGridViewRow oRow in dgvList.Rows)
            {
                if (oRow.Cells[1].Value != null)
                {

                    txtTotalServiceCharge.Text = Convert.ToDouble(Convert.ToDouble(txtTotalServiceCharge.Text) + Convert.ToDouble(oRow.Cells[1].Value.ToString())).ToString();
                    txtTotalSPCharge.Text = Convert.ToDouble(Convert.ToDouble(txtTotalSPCharge.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString())).ToString();
                    txtTotalTransportationCharge.Text = Convert.ToDouble(Convert.ToDouble(txtTotalTransportationCharge.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                    txtTotalOtherCharge.Text = Convert.ToDouble(Convert.ToDouble(txtTotalOtherCharge.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();

                }
            }
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            if (nColumnIndex == 1)
            {


                if (dgvList.Rows[nRowIndex].Cells[1].Value.ToString() != null)
                {
                    try
                    {
                        dgvList.Rows[nRowIndex].Cells[1].Value = Convert.ToDouble(dgvList.Rows[nRowIndex].Cells[1].Value.ToString());
                        dgvList.Rows[nRowIndex].Cells[2].Value = Convert.ToDouble(dgvList.Rows[nRowIndex].Cells[2].Value.ToString());
                        dgvList.Rows[nRowIndex].Cells[3].Value = Convert.ToDouble(dgvList.Rows[nRowIndex].Cells[3].Value.ToString());
                        dgvList.Rows[nRowIndex].Cells[4].Value = Convert.ToDouble(dgvList.Rows[nRowIndex].Cells[4].Value.ToString());
                    }
                    catch
                    {
                        //MessageBox.Show("");

                    }
                }

                GetTotal();
            }
        }

        public void ShowDialog(CSDJobsForWarrantys oCSDJobsForWarrantys)
        {
            _oCSDJobsForWarrantys = oCSDJobsForWarrantys;

            if (_oCSDJobsForWarrantys.Count == 1)
            {
                foreach (CSDJobsForWarranty oCSDJobsForWarranty in _oCSDJobsForWarrantys)
                {
                    txtSCharge.Text = oCSDJobsForWarranty.ServiceCharge.ToString();
                    txtSPCharge.Text = oCSDJobsForWarranty.SparePartsCharge.ToString();
                    txtTransportCharge.Text = oCSDJobsForWarranty.TransportationCharge.ToString();
                    txtOCharge.Text = oCSDJobsForWarranty.OtherCharge.ToString();
                }
            }

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _IsTrue = true;
                this.Close();
            }
        }

        private void LoadSupplier()
        {
            WarrantyParams oWarrantyParams = new WarrantyParams();
            oWarrantyParams.RefreshBySupplier();
            foreach (WarrantyParamDetails oItem in oWarrantyParams)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvList);
                oRow.Cells[0].Value = oItem.SupplierName.ToString();
                oRow.Cells[1].Value = 0;
                oRow.Cells[2].Value = 0;
                oRow.Cells[3].Value = 0;
                oRow.Cells[4].Value = 0;
                oRow.Cells[5].Value = oItem.SupplierID; 
                dgvList.Rows.Add(oRow);
            }
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                if (dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value || String.IsNullOrWhiteSpace(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }

                refreshRow(e.RowIndex, e.ColumnIndex);
            }
            GetTotal();
        }

    }
}
