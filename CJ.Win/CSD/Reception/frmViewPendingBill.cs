using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmViewPendingBill : Form
    {
        CSDJobBills _oCSDJobBills;
        public frmViewPendingBill()
        {
            InitializeComponent();
        }

        private void frmViewPendingJob_Load(object sender, EventArgs e)
        {
            DataloadConttol();  
        }
        private void DataloadConttol() 
        {             
            DBController.Instance.OpenNewConnection();
            _oCSDJobBills = new CSDJobBills();            
            DBController.Instance.OpenNewConnection();
            _oCSDJobBills.GetPendingBills(txtJobNo.Text.Trim(),txtMobileNo.Text.Trim(),txtCustomernName.Text.Trim(),txtTechName.Text.Trim());
            this.Text = "Pending Job | Total: " + "[" + _oCSDJobBills.Count + "]";
            lvwPendingJobs.Items.Clear();
            foreach (CSDJobBill oCSDJobBill in _oCSDJobBills)
            {
                ListViewItem oItem = lvwPendingJobs.Items.Add(oCSDJobBill._oCSDJob.JobNo);
                oItem.SubItems.Add(oCSDJobBill._oCSDJob.CustomerName);
                oItem.SubItems.Add(oCSDJobBill._oCSDJob.MobileNo);
                oItem.SubItems.Add(oCSDJobBill.Name);
                oItem.SubItems.Add(oCSDJobBill.TotalBill.ToString());
                oItem.SubItems.Add(oCSDJobBill.ReceivedAmount.ToString());
                oItem.SubItems.Add(oCSDJobBill.CurrentPayable.ToString());
                oItem.SubItems.Add(oCSDJobBill.Remarks);
                oItem.Tag = oCSDJobBill;
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataloadConttol();
        }

        private void btnBillPay_Click(object sender, EventArgs e)
        {
            if (lvwPendingJobs.SelectedItems.Count > 0)
            {
                CSDJobBill oCSDJobBill = (CSDJobBill)lvwPendingJobs.SelectedItems[0].Tag;
                frmPendingBillPay oForm = new frmPendingBillPay();
                oForm.ShowDialog(oCSDJobBill);
                if(oForm._bIsAnyActivityDone)
                {
                    DataloadConttol();
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void lvwPendingJobs_DoubleClick(object sender, EventArgs e)
        {
            if (lvwPendingJobs.SelectedItems.Count > 0)
            {
                CSDJobBill oCSDJobBill = (CSDJobBill)lvwPendingJobs.SelectedItems[0].Tag;
                frmPendingBillPay oForm = new frmPendingBillPay();
                oForm.ShowDialog(oCSDJobBill);
                if (oForm._bIsAnyActivityDone)
                {
                    DataloadConttol();
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}