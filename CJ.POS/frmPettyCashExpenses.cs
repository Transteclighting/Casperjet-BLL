using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Report;
using CJ.Report.POS;

namespace CJ.POS
{
    public partial class frmPettyCashExpenses : Form
    {
        PettyCashExpenses _oPettyCashExpenses;
        PettyCashExpense oPettyCashExpense;
        bool IsCheck = false;
        SystemInfo oSystemInfo;
        int nID;
        public frmPettyCashExpenses()
        {
            InitializeComponent();
        }

        private void frmPettyCashExpenses_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }
        private void LoadCombos()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");

            //Stationary Tran Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PettyCashExpenseStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.PettyCashExpenseStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void DataLoadControl()
        {
            _oPettyCashExpenses = new PettyCashExpenses();
            lvwPettyCashExpense.Items.Clear();


            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex ;
            }
            this.Cursor = Cursors.WaitCursor;

               
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oPettyCashExpenses.RefreshByPettyCashExpense(dtFromDate.Value.Date, dtToDate.Value.Date, nStatus, txtCode.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (PettyCashExpense oPettyCashExpense in _oPettyCashExpenses)
            {
                ListViewItem oItem = lvwPettyCashExpense.Items.Add(oPettyCashExpense.Outlet.ToString());
                oItem.SubItems.Add(oPettyCashExpense.ExpanceCode.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oPettyCashExpense.CreateDate).ToString("dd-MMM-yyyy"));
                //oItem.SubItems.Add(oPettyCashExpense.Status.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PettyCashExpenseStatus), oPettyCashExpense.Status));
                oItem.SubItems.Add(oPettyCashExpense.Amount.ToString());
                oItem.SubItems.Add(oPettyCashExpense.ApprovedAmount.ToString());
                oItem.SubItems.Add(oPettyCashExpense.Remarks.ToString());


                oItem.Tag = oPettyCashExpense;
            }
            setListViewRowColour();
            this.Text = "Total [" + _oPettyCashExpenses.Count + "]";
            this.Cursor = Cursors.Default;
        }
        private void setListViewRowColour()
        {
            if (lvwPettyCashExpense.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwPettyCashExpense.Items)
                {
                    if (oItem.SubItems[3].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[3].Text == "Create")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else if (oItem.SubItems[3].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[3].Text == "Reject")
                    {
                        oItem.BackColor = Color.Orange;
                    }
                }
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPettyCashExpense oFrom = new frmPettyCashExpense();
            oFrom.ShowDialog();
            if (oFrom._ISLoad == true)
                DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPettyCashExpense.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PettyCashExpense oPettyCashExpense = (PettyCashExpense)lvwPettyCashExpense.SelectedItems[0].Tag;
            if (oPettyCashExpense.Status == (int)Dictionary.PettyCashExpenseStatus.Create)
            {
                frmPettyCashExpense oForm = new frmPettyCashExpense();
                oForm.ShowDialog(oPettyCashExpense);
                if (oForm._ISLoad == true)
                    DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwPettyCashExpense.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            nID = 0;
            oPettyCashExpense = (PettyCashExpense)lvwPettyCashExpense.SelectedItems[0].Tag;
            nID = oPettyCashExpense.ID;
            PettyCashExpenses oPettyCashExpenses = new PettyCashExpenses();
            oPettyCashExpenses.ViewPettyCashExpense(nID, oPettyCashExpense.WarehouseID);
            rptPettyCashExpenses oReport = new rptPettyCashExpenses();

            List<PosPettyCashExpense> oList = new List<PosPettyCashExpense>();

            foreach (PettyCashExpense oPettyCashExpense in oPettyCashExpenses)
            {
                var oPosPettyCashExpense = new PosPettyCashExpense
                {
                    Description = oPettyCashExpense.Description,
                    voucherNo = oPettyCashExpense.voucherNo,
                    Purpose = oPettyCashExpense.Purpose,
                    Amount = oPettyCashExpense.Amount,
                    ApprovedAmount = oPettyCashExpense.ApprovedAmount
                };
                oList.Add(oPosPettyCashExpense);
            }
            oReport.SetDataSource(oList);
            //oReport.SetDataSource(oPettyCashExpenses);
            oReport.SetParameterValue("ExpenseCode", oPettyCashExpense.ExpanceCode);
            oReport.SetParameterValue("CreateDate", oPettyCashExpense.CreateDate);
            oReport.SetParameterValue("CompanyName", Utility.CompanyName);
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            //oReport.SetParameterValue("Outlet", oSystemInfo.WarehouseName + "[" + oSystemInfo.WarehouseCode + "]");
            oReport.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            oReport.SetParameterValue("ReportName", "Petty Cash Expense");
            oReport.SetParameterValue("Remarks", oPettyCashExpense.Remarks);
            oReport.SetParameterValue("UserName", Utility.Username);
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }
    }
}
