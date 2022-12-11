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
using CJ.Report;

namespace CJ.Win.Accounts
{
    public partial class frmCustomerCreditApprovals : Form
    {
        CustomerCreditApproval _oCustomerCreditApproval;
        CustomerCreditApprovals _oCustomerCreditApprovals;
        TELLib _oLib;
        Customer _oCustomer;
        Customers _oCustomers;
        Showrooms _oShowrooms;
        DataSyncManager _oDataSyncManager;

        bool IsCheck = false;

        public frmCustomerCreditApprovals()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerCreditApproval oFrom = new frmCustomerCreditApproval();
            oFrom.ShowDialog();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _oCustomerCreditApprovals = new CustomerCreditApprovals();
            lvwCustomerCreditApprovals.Items.Clear();
            int nCustomerID = 0;
            if (ctlCustomer1.txtDescription.Text == "")
            {
                nCustomerID = -1;
            }
            else
            {
                nCustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            }
            _oCustomerCreditApprovals.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtOutlet.Text.Trim(), txtCANo.Text.Trim(), nCustomerID, IsCheck);

            _oLib = new TELLib();            

            foreach (CustomerCreditApproval oCustomerCreditApproval in _oCustomerCreditApprovals)
            {
                ListViewItem oItem = lvwCustomerCreditApprovals.Items.Add(oCustomerCreditApproval.ApprovalNo.ToString());
                oItem.SubItems.Add(oCustomerCreditApproval.WarehouseCode.ToString());
                oItem.SubItems.Add(_oLib.TakaFormat(oCustomerCreditApproval.CreditAmount));
                oItem.SubItems.Add(_oLib.TakaFormat(oCustomerCreditApproval.InvoicedAmount));
                oItem.SubItems.Add(_oLib.TakaFormat(oCustomerCreditApproval.CollectedAmount));
                oItem.SubItems.Add(oCustomerCreditApproval.CustomerName + " [" + oCustomerCreditApproval.CustomerCode + "]");
                oItem.SubItems.Add(Convert.ToDateTime(oCustomerCreditApproval.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCustomerCreditApproval.CreditPeriod.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CreditApprovalStatus), oCustomerCreditApproval.Status));
                
                oItem.Tag = oCustomerCreditApproval;
            }
            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (lvwCustomerCreditApprovals.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCustomerCreditApprovals.Items)
                {
                    if (oItem.SubItems[8].Text == Dictionary.CreditApprovalStatus.Create.ToString())
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[8].Text == Dictionary.CreditApprovalStatus.Approve.ToString())
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else
                    {
                        oItem.BackColor = Color.DarkGray;

                    }
                }
            }
        }

        private void frmCustomerCreditApprovals_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            string sApproveButton = "M3.20.4.1";
            UserPermission oUserPermission = new UserPermission();
            if (oUserPermission.CheckPermission(sApproveButton))
            {
                btnApprove.Enabled = true;
            }
            else
            {
                btnApprove.Enabled = false;
            }
            LoadData();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwCustomerCreditApprovals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Approve", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomerCreditApproval = (CustomerCreditApproval)lvwCustomerCreditApprovals.SelectedItems[0].Tag;
            if (_oCustomerCreditApproval.Status != (int)Dictionary.CreditApprovalStatus.Create)
            {
                MessageBox.Show("Only Create Status can be Approved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to Approve CA#: " + _oCustomerCreditApproval.ApprovalNo + " ? ", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerCreditApproval.Status = (int)Dictionary.CreditApprovalStatus.Approve;
                    _oCustomerCreditApproval.StatusUpdateUserID = Utility.UserId;
                    _oCustomerCreditApproval.StatusUpdateDate = DateTime.Now;
                    _oCustomerCreditApproval.StatusUpdate();
                    _oDataSyncManager = new DataSyncManager();
                    _oDataSyncManager.SendCreditApprovalToShowroom(_oCustomerCreditApproval, Dictionary.DataTransferType.Add, _oCustomerCreditApproval.WarehouseID);
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Approve Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCustomerCreditApprovals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an ApprovalNo to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomerCreditApproval = (CustomerCreditApproval)lvwCustomerCreditApprovals.SelectedItems[0].Tag;
            if (_oCustomerCreditApproval.Status != (int)Dictionary.CreditApprovalStatus.Create)
            {
                MessageBox.Show("Only Create Status can be Eidted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmCustomerCreditApproval oForm = new frmCustomerCreditApproval();
            oForm.ShowDialog(_oCustomerCreditApproval);
            LoadData();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwCustomerCreditApprovals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Cancel", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _oCustomerCreditApproval = (CustomerCreditApproval)lvwCustomerCreditApprovals.SelectedItems[0].Tag;
            if (_oCustomerCreditApproval.Status != (int)Dictionary.CreditApprovalStatus.Create)
            {
                MessageBox.Show("Only Create Status can be Cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to Cancel CA#: " + _oCustomerCreditApproval.ApprovalNo + " ? ", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerCreditApproval.Status = (int)Dictionary.CreditApprovalStatus.Cancel;
                    _oCustomerCreditApproval.StatusUpdateUserID = Utility.UserId;
                    _oCustomerCreditApproval.StatusUpdateDate = DateTime.Now;
                    _oCustomerCreditApproval.StatusUpdate();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Cancelled Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (lvwCustomerCreditApprovals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Get History", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomerCreditApproval = (CustomerCreditApproval)lvwCustomerCreditApprovals.SelectedItems[0].Tag;
            frmCustomerCreditApprovalHistory oForm = new frmCustomerCreditApprovalHistory();
            oForm.ShowDialog(_oCustomerCreditApproval);
            LoadData();
        }

        private void frmPrint_Click(object sender, EventArgs e)
        {
            if (lvwCustomerCreditApprovals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;

            _oCustomerCreditApproval = (CustomerCreditApproval)lvwCustomerCreditApprovals.SelectedItems[0].Tag;
            
            CustomerCreditApprovals oCCAs = new CustomerCreditApprovals();
            oCCAs.Refresh(_oCustomerCreditApproval.ID);

            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptCustomerCreditApproval));
            oReport.SetDataSource(oCCAs);

            string sDB = "";
            string sCompany = "";
            double _TotalCreditAmtTEL = 0;
            double _TotalCreditAmtTML = 0;

            if (Utility.CompanyInfo == "TEL")
            {
                sDB = "TELSYSDB";
                sCompany = "TEL";
            }
            else
            {
                sDB = "TMLSYSDB";
                sCompany = "TML";
            }
            CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
            oCustomerCreditApproval.GetTotalCreditAmount(_oCustomerCreditApproval.ID, _oCustomerCreditApproval.WarehouseID, sDB, 1, sCompany);
            if (oCustomerCreditApproval.Company == "TEL")
            {
                _TotalCreditAmtTEL = oCustomerCreditApproval.TotalCreditAmount;
            }
            else
            {
                _TotalCreditAmtTML = oCustomerCreditApproval.TotalCreditAmount;
            }

            oCustomerCreditApproval.GetTotalCreditAmount(_oCustomerCreditApproval.ID, _oCustomerCreditApproval.WarehouseID, sDB, 2, sCompany);
            if (oCustomerCreditApproval.Company == "TEL")
            {
                _TotalCreditAmtTEL = oCustomerCreditApproval.TotalCreditAmount;
            }
            else
            {
                _TotalCreditAmtTML = oCustomerCreditApproval.TotalCreditAmount;
            }


            //oReport.SetParameterValue("ReportName", sReportName);

            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

    }
}