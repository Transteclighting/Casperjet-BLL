using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Account
{
    public partial class frmTPBillProcess : Form
    {
        CSDTPBills _oCSDTPBills;
        CSDTPBills _oCSDTPBillsJobWise;
        CSDTPBillDetails _oCSDTPBillDetails;
        public bool _bActivity = false;
        public frmTPBillProcess()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            Process(); 
            this.Close();
        }
        private void Process()
        {
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            _oCSDTPBills = new CSDTPBills();
            _oCSDTPBills.GetTPBills(dtBillMonthYear.Value.Date);
            try
            {
                DBController.Instance.BeginNewTransaction();
                foreach (CSDTPBill oCSDTPBill in _oCSDTPBills)
                {
                    oCSDTPBill.CreateUserID = Utility.UserId;
                    oCSDTPBill.CreateDate = DateTime.Now;
                    oCSDTPBill.Status = (int)Dictionary.CSDTPBillStatus.Pending;
                    oCSDTPBill.Add();
                }
                DBController.Instance.CommitTran();

                _oCSDTPBillsJobWise = new CSDTPBills();
                _oCSDTPBillsJobWise.GetJobWiseTPBills(dtBillMonthYear.Value.Date);

                foreach (CSDTPBill aCSDTPBillsJobWise in _oCSDTPBillsJobWise)
                {
                    _oCSDTPBillDetails = new CSDTPBillDetails();
                    _oCSDTPBillDetails.TPBillID = aCSDTPBillsJobWise.TPBillID;
                    _oCSDTPBillDetails.JobID = aCSDTPBillsJobWise.JobID;
                    _oCSDTPBillDetails.ServiceCharge = aCSDTPBillsJobWise.ServiceCharge;
                    _oCSDTPBillDetails.InstallationCharge = aCSDTPBillsJobWise.InstallationCharge;
                    _oCSDTPBillDetails.MaterialCharge = aCSDTPBillsJobWise.MaterialCharge;
                    _oCSDTPBillDetails.GasCharge = aCSDTPBillsJobWise.GasCharge;
                    _oCSDTPBillDetails.OthersCharge = aCSDTPBillsJobWise.OthersCharge;
                    _oCSDTPBillDetails.Add();
                }
                DBController.Instance.CommitTran();
                _bActivity = true;
                string billMonthYear = Enum.GetName(typeof(Dictionary.MonthShortName), dtBillMonthYear.Value.Month) + ", " + dtBillMonthYear.Value.Year;
                MessageBox.Show("Successfully Processed Third Party Bill For Month of " + billMonthYear, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
            this.Cursor = Cursors.Default;
        }
    }
}