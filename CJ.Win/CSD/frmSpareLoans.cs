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
using CJ.Win.Security;

namespace CJ.Win
{
    public partial class frmSpareLoans : Form
    {
        public frmSpareLoans()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            //Utility oUtility = _oUtilitys[cmbStatus.SelectedIndex];
            //_nStatus = oUtility.SatusId;

            
            SpareLoans oSpareLoans = new SpareLoans();

            lvwSpareLoan.Items.Clear();
            //ckbSelect.Checked = false;
            DBController.Instance.OpenNewConnection();
            oSpareLoans.Refresh();//dtFromDate.Value.Date, dtToDate.Value.Date, txtJobNo.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId

            //oServiceJobs.btnShow(txtJobNo.Text);
            this.Text = "Total " + "[" + oSpareLoans.Count + "]";
            foreach (SpareLoan oSpareLoan in oSpareLoans)
            {
                ListViewItem oItem = lvwSpareLoan.Items.Add(oSpareLoan.SpareLoanID.ToString());
                oItem.SubItems.Add(oSpareLoan.ReplaceJobFromCassandra.JobNo);
                oItem.SubItems.Add(oSpareLoan.ReplaceJobFromCassandra.CustomerName);
                oItem.SubItems.Add(oSpareLoan.CreateDate.ToString());
                if (oSpareLoan.Status == (int)Dictionary.SpareLoanStatus.AddSpareOrder)
                {
                    oItem.SubItems.Add("AddSpareOrder");
                }
                else if (oSpareLoan.Status == (int)Dictionary.SpareLoanStatus.AddStock)
                {
                    oItem.SubItems.Add("AddStock");
                }
                else if (oSpareLoan.Status == (int)Dictionary.SpareLoanStatus.Approve)
                {
                    oItem.SubItems.Add("Approve");
                }
                else if (oSpareLoan.Status == (int)Dictionary.SpareLoanStatus.IssueAgainstJob)
                {
                    oItem.SubItems.Add("IssueAgainstJob");
                }
                else if (oSpareLoan.Status == (int)Dictionary.SpareLoanStatus.Raise)
                {
                    oItem.SubItems.Add("Raise");
                }
                else if (oSpareLoan.Status == (int)Dictionary.SpareLoanStatus.ReceiveFromSupplier)
                {
                    oItem.SubItems.Add("ReceiveFromSupplier");
                }
                else if (oSpareLoan.Status == (int)Dictionary.SpareLoanStatus.ReceiveFromWH)
                {
                    oItem.SubItems.Add("ReceiveFromWH");
                }
                else
                {
                    oItem.SubItems.Add("SpareReFixed");
                }
                
                oItem.SubItems.Add(oSpareLoan.Remarks);

                
                oItem.Tag = oSpareLoan;
            }
            //setListViewRowColour();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }






        private void frmSpareLoans_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //frmVehicleSchedule oForm = new frmVehicleSchedule();
            //oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            //oForm.MaximizeBox = false;
            //oForm.ShowDialog();
            //DataLoadControl();
        }
    }
}