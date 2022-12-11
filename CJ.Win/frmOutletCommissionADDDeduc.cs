using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.BasicData;

namespace CJ.Win
{
    public partial class frmOutletCommissionADDDeduc : Form
    {
        OutletCommissionDetail _oOutletCommissionDetail;
        OutletCommission _oOutletCommission;
        OutletCommissions _oOutletCommissions;
        TELLib _oLib;
        int nType = 0;
        public frmOutletCommissionADDDeduc()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                DBController.Instance.BeginNewTransaction();

                UpdateData(nType);
                DBController.Instance.CommitTran();
                MessageBox.Show("Success fully Update Commission ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();


            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void UpdateData(int _nType)
        {
            OutletCommissionDetail _oOutletCommissionDetail;

            foreach (DataGridViewRow oItemRow in dgvAddDuduct.Rows)
            {
                if (oItemRow.Index < dgvAddDuduct.Rows.Count - 1)
                {

                    _oOutletCommissionDetail = new OutletCommissionDetail();
                    _oOutletCommissionDetail.Addition = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                    _oOutletCommissionDetail.Deduction = Convert.ToDouble(oItemRow.Cells[5].Value.ToString());
                    _oOutletCommissionDetail.EmployeeID=Convert.ToInt32(oItemRow.Cells[7].Value.ToString());
                    _oOutletCommissionDetail.ID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString());
                    _oOutletCommissionDetail.ProductGroup =oItemRow.Cells[9].Value.ToString();

                    if (_nType == (int)Dictionary.OutletEmployeeType.Executive)
                    {
                        _oOutletCommissionDetail.UpdateExecutive();
                    }
                    else
                    {
                        _oOutletCommissionDetail.UpdateManager();
                    }


                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetTotalAmount()
        {
            lblTotalAmt.Text = "0.00";
            _oLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvAddDuduct.Rows)
            {
                if (oRow.Cells[6].Value != null)
                {
                    _oLib = new TELLib();
                    lblTotalAmt.Visible = true;
                    lblTotalAmt.Text = _oLib.TakaFormat(Convert.ToDouble(lblTotalAmt.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString()));
                                    
                }
                _oLib = new TELLib();
                lblAmountInWord.Visible = true;
                lblAmountInWord.Text = _oLib.TakaWords(Convert.ToDouble(lblTotalAmt.Text));
                _oOutletCommission = new OutletCommission();
            }

        }

        public void ShowDialog(OutletCommission oOutletCommission)
        {
            _oLib = new TELLib();
            this.Tag = oOutletCommission;
            int nID = 0;
            nID = oOutletCommission.ID;
            nType = oOutletCommission.Type;
            DBController.Instance.OpenNewConnection();
            oOutletCommission.GetCommissionDetail(oOutletCommission.ID, oOutletCommission.Type);
            DBController.Instance.CloseConnection();
            lblType.Text = oOutletCommission.TypeName;
            lblYear.Text = Convert.ToString(oOutletCommission.YearNo);
            lblMonth.Text = Convert.ToString(oOutletCommission.MonthNo);
            foreach (OutletCommissionDetail oOutletCommissionDetail in oOutletCommission)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvAddDuduct);
                oRow.Cells[0].Value = oOutletCommissionDetail.LocationName.ToString();
                oRow.Cells[1].Value = oOutletCommissionDetail.EmployeeCode.ToString();
                oRow.Cells[2].Value = oOutletCommissionDetail.EmployeeName.ToString();
                oRow.Cells[3].Value = _oLib.TakaFormat(Convert.ToDouble(( oOutletCommissionDetail.TotalCommission).ToString()));
                oRow.Cells[4].Value = _oLib.TakaFormat(Convert.ToDouble((oOutletCommissionDetail.Addition).ToString()));
                oRow.Cells[5].Value = _oLib.TakaFormat(Convert.ToDouble((oOutletCommissionDetail.Deduction.ToString())));
                oRow.Cells[6].Value = _oLib.TakaFormat(Convert.ToDouble(((oOutletCommissionDetail.TotalCommission + oOutletCommissionDetail.Addition)-oOutletCommissionDetail.Deduction).ToString()));;
                oRow.Cells[7].Value = oOutletCommissionDetail.EmployeeID.ToString();
                oRow.Cells[8].Value = oOutletCommissionDetail.ID.ToString();
                oRow.Cells[9].Value = oOutletCommissionDetail.ProductGroup.ToString();
                dgvAddDuduct.Rows.Add(oRow);

            }
            GetTotalAmount();


            this.ShowDialog();
        }
        private void frmOutletCommissionADDDeduc_Load(object sender, EventArgs e)
        {

        
        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
           
            if (nColumnIndex == 4)
            {
                _oLib = new TELLib();

                if (dgvAddDuduct.Rows[nRowIndex].Cells[4].Value != null || Convert.ToInt32(dgvAddDuduct.Rows[nRowIndex].Cells[4].Value) != 0)
                {
                    dgvAddDuduct.Rows[nRowIndex].Cells[6].Value = _oLib.TakaFormat((Convert.ToDouble(dgvAddDuduct.Rows[nRowIndex].Cells[3].Value.ToString()) + Convert.ToDouble(dgvAddDuduct.Rows[nRowIndex].Cells[4].Value.ToString())) - Convert.ToDouble(dgvAddDuduct.Rows[nRowIndex].Cells[5].Value.ToString()));
                }
                GetTotalAmount();
            }
            else if (nColumnIndex == 5)
            {
                _oLib = new TELLib();

                if (dgvAddDuduct.Rows[nRowIndex].Cells[5].Value != null || Convert.ToInt32(dgvAddDuduct.Rows[nRowIndex].Cells[5].Value) != 0)
                {
                    dgvAddDuduct.Rows[nRowIndex].Cells[6].Value = _oLib.TakaFormat((Convert.ToDouble(dgvAddDuduct.Rows[nRowIndex].Cells[3].Value.ToString()) + Convert.ToDouble(dgvAddDuduct.Rows[nRowIndex].Cells[4].Value.ToString())) - Convert.ToDouble(dgvAddDuduct.Rows[nRowIndex].Cells[5].Value.ToString()));
                }
                GetTotalAmount();
            }

        }
    }
}