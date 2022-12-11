using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report.CSD;
using CJ.Report;

namespace CJ.Win.CSD.Store
{
    public partial class frmSPIssuetoInternalPartys : Form
    {
        SPTrans _SPTrans;
        Stores _oInternalPartys;
        bool IsCheck = false;
        int _nType = 0;
        int nTranID = 0;
        SPTran _oSPTran;

        public frmSPIssuetoInternalPartys(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.SparePartTranStatus.Create)
            {
                frmSPIssuetoInternalParty oForm = new frmSPIssuetoInternalParty();
                oForm.ShowDialog();
                DataLoadControl();
            }
            else
            {


                if (lvwSPIssue.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select data to approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SPTran oSPTran = (SPTran)lvwSPIssue.SelectedItems[0].Tag;

                if (oSPTran.Status == (int)Dictionary.SparePartTranStatus.Create)
                {
                    DialogResult oResult = MessageBox.Show("Are you sure you want to approved this challan no: " + oSPTran.TranNo + " ? ", "Confirm Ticket Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (oResult == DialogResult.Yes)
                    {
                        try
                        {

                            DBController.Instance.BeginNewTransaction();
                            //Approved
                            oSPTran.Status = (int)Dictionary.SparePartTranStatus.Approved;
                            oSPTran.UpdateTranStatus();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Successfully Approved", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataLoadControl();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You cannot approved this challan", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetListViewRowColour()
        {
            if (lvwSPIssue.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwSPIssue.Items)
                {
                    if (oItem.SubItems[4].Text == "Create")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else
                    {
                        oItem.BackColor = Color.Transparent;
                    }

                }
            }
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _SPTrans = new SPTrans();
            lvwSPIssue.Items.Clear();

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            int nInternalParty = 0;
            if (cmbPartyName.SelectedIndex == 0)
            {
                nInternalParty = -1;
            }
            else
            {
                nInternalParty = _oInternalPartys[cmbPartyName.SelectedIndex - 1].InternalPartyID;
            }

            DBController.Instance.OpenNewConnection();
            _SPTrans.RefreshForInternalPartyChallan(dtFromDate.Value.Date, dtToDate.Value.Date, nStatus, txtTranNo.Text.Trim(), nInternalParty, IsCheck);
            DBController.Instance.CloseConnection();

            foreach (SPTran oSPTran in _SPTrans)
            {
                ListViewItem oItem = lvwSPIssue.Items.Add(oSPTran.TranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSPTran.TranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSPTran.InternalPartyName.ToString());
                oItem.SubItems.Add(oSPTran.UserName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SparePartTranStatus), oSPTran.Status));
                oItem.SubItems.Add(oSPTran.Remarks.ToString());

                oItem.Tag = oSPTran;
            }
            SetListViewRowColour();
            this.Text = "Total[" + _SPTrans.Count + "]";
            this.Cursor = Cursors.Default;
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            //Stationary Tran Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SparePartTranStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SparePartTranStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


            //Internal Partys
            _oInternalPartys = new Stores();
            _oInternalPartys.RefreshInternalParty();
            cmbPartyName.Items.Clear();
            cmbPartyName.Items.Add("<Select Internal Party>");
            foreach (CJ.Class.Store oStore in _oInternalPartys)
            {
                cmbPartyName.Items.Add(oStore.InternalPartyName);
            }
            cmbPartyName.SelectedIndex = 0;

        }
        private void frmSPIssuetoInternalPartys_Load(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.SparePartTranStatus.Create)
            {
                btnAdd.Text = "Add";
            }
            else
            {
                btnAdd.Text = "Approve";
            }
            LoadCombos();
            DataLoadControl();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwSPIssue.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                nTranID = 0;
                _oSPTran = (SPTran)lvwSPIssue.SelectedItems[0].Tag;
                nTranID = _oSPTran.SPTranID;

                _oSPTran = new SPTran();
                DBController.Instance.OpenNewConnection();
                _oSPTran.RefreshInternalPartyChallan(nTranID);

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(ptSparePartsInternalChallan));
                oReport.SetDataSource(_oSPTran);

                oReport.SetParameterValue("TranNo", _oSPTran.TranNo);
                oReport.SetParameterValue("TranDate", _oSPTran.TranDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("FromStoreName", _oSPTran.FromStoreName);
                oReport.SetParameterValue("PartyName", _oSPTran.InternalPartyName);

                oReport.SetParameterValue("CreateDate", _oSPTran.CreateDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("CreateUserName", _oSPTran.UserName);

                oReport.SetParameterValue("ApprovedByName", _oSPTran.ApprovedByName);
                if (_oSPTran.ApprovedDate != "")
                {
                    oReport.SetParameterValue("ApprovedDate", Convert.ToDateTime(_oSPTran.ApprovedDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oReport.SetParameterValue("ApprovedDate", "");
                }

                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintBy", Utility.UserFullname);

                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}