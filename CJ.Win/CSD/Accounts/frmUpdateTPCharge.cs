using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
namespace CJ.Win
{
    public partial class frmUpdateTPCharge : Form
    {
        CSDTPBills _oCSDTPBills;
        CSDTPBillDetailss _oCSDTPBillDetailss;
        public frmUpdateTPCharge()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDTPBills oCSDTPBills)
        {
            _oCSDTPBills = new CSDTPBills();
            _oCSDTPBills = oCSDTPBills;
            foreach (CSDTPBill oCSDTPBill in _oCSDTPBills)
            {
                txtBillMonth.Text = Enum.GetName(typeof(Dictionary.MonthShortName), oCSDTPBill.BillMonth) + "," + oCSDTPBill.BillYear.ToString();
                break;
            }
            this.ShowDialog();
        }
        private void frmUpdateTPCharge_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            _oCSDTPBillDetailss = new CSDTPBillDetailss();
            foreach (CSDTPBill oCSDTPBill in _oCSDTPBills)
            {
                _oCSDTPBillDetailss.GetInterServiceWiseBill(oCSDTPBill.InterServiceID, oCSDTPBill.BillMonth, oCSDTPBill.BillYear);

                foreach (CSDTPBillDetails aCSDTPBillDetails in _oCSDTPBillDetailss)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvInterServiceJobs);
                    oRow.Cells[0].Value = aCSDTPBillDetails.InterServiceName;
                    oRow.Cells[1].Value = aCSDTPBillDetails.JobNo;
                    oRow.Cells[2].Value = aCSDTPBillDetails.MaterialCharge.ToString();
                    oRow.Cells[3].Value = aCSDTPBillDetails.GasCharge.ToString();
                    oRow.Cells[4].Value = aCSDTPBillDetails.OthersCharge.ToString();
                    oRow.Cells[5].Value = aCSDTPBillDetails.TPBillDetailID;
                    dgvInterServiceJobs.Rows.Add(oRow);
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Update()
        {
           
            DBController.Instance.OpenNewConnection();
            DBController.Instance.BeginNewTransaction();
            try
            {
                foreach (DataGridViewRow oItemRow in dgvInterServiceJobs.Rows)
                {
                    if (oItemRow.Index < dgvInterServiceJobs.Rows.Count - 1)
                    {
                        CSDTPBillDetails oItem = new CSDTPBillDetails();

                        if (oItemRow.Cells[2].Value != null)
                        {
                            oItem.MaterialCharge = Convert.ToDouble(oItemRow.Cells[2].Value.ToString().Trim());
                        }
                        if (oItemRow.Cells[3].Value != null)
                        {
                            oItem.GasCharge = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                        }
                        if (oItemRow.Cells[4].Value != null)
                        {
                            oItem.OthersCharge = Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim());
                        }
                        oItem.TPBillDetailID = Convert.ToInt32(oItemRow.Cells[5].Value.ToString().Trim());

                        if (oItem.MaterialCharge > 0 || oItem.GasCharge > 0 || oItem.OthersCharge > 0)
                        {                           
                            oItem.Edit();                            
                        }
                    }
                }
                int tMonth = 0;
                int tYear = 0;
                foreach (CSDTPBill oCSDTPBill in _oCSDTPBills)
                {
                    tMonth = oCSDTPBill.BillMonth;
                    tYear = oCSDTPBill.BillYear;
                    break;
                }
                //Update Tp Bill
                CSDTPBills oCSDTPBills = new CSDTPBills();
                oCSDTPBills.GetBillIDWiseTotalCharge(tMonth, tYear);
                foreach (CSDTPBill oCSDTPBill in oCSDTPBills)
                {
                    oCSDTPBill.UpdateTpBill();
                }
                DBController.Instance.CommitTran();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
            MessageBox.Show("Successfully Updated", "Informaton", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}