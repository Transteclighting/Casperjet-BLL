using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using System.Globalization;
using CJ.Win.CSD;
using CJ.Win.CSD.Account;
using CJ.Report;
using CJ.Report.CSD;



namespace CJ.Win
{
    public partial class frmTPBills : Form
    {
        CSDTPBills _oCSDTPBills;
        public frmTPBills()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintInterServiceBill();
        }
           
        private void PrintInterServiceBill()
        {

            CSDTPBills oCSDTPBills = new CSDTPBills();

            for (int i = 0; i < lvwTPBills.Items.Count; i++)
            {
                ListViewItem itm = lvwTPBills.Items[i];
                if (lvwTPBills.Items[i].Checked == true)
                {
                    oCSDTPBills.Add((CSDTPBill)lvwTPBills.Items[i].Tag);
                }
            }

            this.Cursor = Cursors.WaitCursor;
            CSDTPBillDetailss _oCSDTPBillDetailss = new CSDTPBillDetailss();
            CSDTPBillDetailss oCSDTPBillDetailss = new CSDTPBillDetailss();

            foreach (CSDTPBill oCSDTPBill in oCSDTPBills)
            {
                _oCSDTPBillDetailss.GetInterServiceWiseBill(oCSDTPBill.InterServiceID, oCSDTPBill.BillMonth, oCSDTPBill.BillYear);
                foreach (CSDTPBillDetails aCSDTPBillDetails in _oCSDTPBillDetailss)
                {
                    oCSDTPBillDetailss.Add(aCSDTPBillDetails);
                }

            }

            rptInterServiceBill oReport = new rptInterServiceBill();
            oReport.SetDataSource(oCSDTPBillDetailss);
            oReport.SetParameterValue("UserName", Utility.Username);
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            frmTPBillProcess oForm = new frmTPBillProcess();
            oForm.ShowDialog();
            if (oForm._bActivity)
            {
                DataLoadControl();
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            int nInterService = -1;
            if (ctlInterService1.txtDescription.Text != string.Empty)
            {
                nInterService = ctlInterService1.SelectedInterService.InterServiceID;
            }
            _oCSDTPBills = new CSDTPBills();
            _oCSDTPBills.Refresh(dtBillMonthYear.Value.Date, nInterService);
            this.Text = "CSD TP Bill | Total: " + "[" + _oCSDTPBills.Count + "]";
            lvwTPBills.Items.Clear();
            foreach (CSDTPBill oCSDTPBill in _oCSDTPBills)
            {
                ListViewItem oItem = lvwTPBills.Items.Add(oCSDTPBill.InterServiceName);
                oItem.SubItems.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(oCSDTPBill.BillMonth).Substring(0, 3));
                oItem.SubItems.Add(oCSDTPBill.BillYear.ToString());
                oItem.SubItems.Add(oCSDTPBill.ServiceCharge.ToString());
                oItem.SubItems.Add(oCSDTPBill.InstallationCharge.ToString());
                oItem.SubItems.Add(oCSDTPBill.MaterialCharge.ToString());
                oItem.SubItems.Add(oCSDTPBill.GasCharge.ToString());
                oItem.SubItems.Add(oCSDTPBill.OthersCharge.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDTPBillStatus), oCSDTPBill.Status));
                oItem.SubItems.Add(oCSDTPBill.CreateUserName);
                oItem.SubItems.Add(oCSDTPBill.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.Tag = oCSDTPBill;
            }
            this.Cursor = Cursors.Default;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < lvwTPBills.Items.Count; i++)
                {
                    ListViewItem itm = lvwTPBills.Items[i];
                    lvwTPBills.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lvwTPBills.Items.Count; i++)
                {
                    ListViewItem itm = lvwTPBills.Items[i];
                    lvwTPBills.Items[i].Checked = false;

                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CSDTPBills oCSDTPBills = new CSDTPBills();
            for (int i = 0; i < lvwTPBills.Items.Count; i++)
            {
                ListViewItem itm = lvwTPBills.Items[i];
                if (lvwTPBills.Items[i].Checked == true)
                {
                    oCSDTPBills.Add((CSDTPBill)lvwTPBills.Items[i].Tag);
                }
            }
            frmUpdateTPCharge oForm = new frmUpdateTPCharge();
            if (oCSDTPBills.Count != 0)
            {
                oForm.ShowDialog(oCSDTPBills);
            }
            else {
                MessageBox.Show("Please select a row", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }       
    }
}