using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.BasicData;
using CJ.Report;
using CJ.Report.POS;

namespace CJ.Win.Admin
{
    public partial class frmOfficeItemTrans : Form
    {
        Departments _oDepartments;
        Companys _oCompanys;
        Employee _oEmployee;
        OfficeItemTran _oOfficeItemTran;
        OfficeItemTrans _oOfficeItemTrans;
        bool IsCheck = false;
        int nWarehouseID = 0;
        int nTranID = 0;
        int nTerminal = 0;

        public frmOfficeItemTrans()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOfficeItemTran oFrom = new frmOfficeItemTran();
            oFrom.ShowDialog();
            DataLoadControl();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }
        private void LoadCombos()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

           
            //Company
            _oCompanys = new Companys();
            
            _oCompanys.Refresh();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");

            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            //Stationary Tran Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OfficeTranStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.OfficeTranStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


            cmbTerminal.Items.Clear();
            cmbTerminal.Items.Add("<All>");
            //Stationary Tran Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Terminal)))
            {
                cmbTerminal.Items.Add(Enum.GetName(typeof(Dictionary.Terminal), GetEnum));
            }
            cmbTerminal.SelectedIndex = 0;



        }

        private void SetListViewRowColour()
        {
            if (lvwOfficeItemTrans.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOfficeItemTrans.Items)
                {
                    if (oItem.SubItems[7].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[7].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.Magenta;
                    
                    }
                    else if (oItem.SubItems[7].Text == "Approve_By_HO")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else
                    {
                        oItem.BackColor = Color.Red;
                    }

                }
            }
        }

        private void DataLoadControl()
        {
            _oOfficeItemTrans = new OfficeItemTrans();
            lvwOfficeItemTrans.Items.Clear();
            
            int nCompany = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompany = -1;
            }
            else
            {
                nCompany = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex -1;
            }

            int nTerminal = 0;
            if (cmbTerminal.SelectedIndex == 0)
            {
                nTerminal = -1;
            }
            else
            {
                nTerminal = cmbTerminal.SelectedIndex;
            }

            int nEmployeeID = 0;
            if (ctlEmployee.txtCode.Text == "")
            {
                nEmployeeID = -1;
            }
            else
            {
                nEmployeeID = ctlEmployee.SelectedEmployee.EmployeeID;
            }
            DBController.Instance.OpenNewConnection();
            _oOfficeItemTrans.RefreshForHO(dtFromdate.Value.Date, dtTodate.Value.Date, nStatus, nCompany, txtTranNo.Text.Trim(), nEmployeeID, IsCheck, nTerminal);
            DBController.Instance.CloseConnection();

            foreach (OfficeItemTran oOfficeItemTran in _oOfficeItemTrans)
            {
                ListViewItem oItem = lvwOfficeItemTrans.Items.Add(oOfficeItemTran.TerminalName.ToString());
                oItem.SubItems.Add(oOfficeItemTran.TranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oOfficeItemTran.TranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oOfficeItemTran.TranTypeName.ToString());
                oItem.SubItems.Add(oOfficeItemTran.EmployeeName.ToString());
                oItem.SubItems.Add(oOfficeItemTran.DepartmentName.ToString());
                oItem.SubItems.Add(oOfficeItemTran.CompanyName.ToString());
                oItem.SubItems.Add(oOfficeItemTran.StatusName.ToString());

                oItem.Tag = oOfficeItemTran;
            }
            SetListViewRowColour();
        }

        private void frmOfficeItemTrans_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            DataLoadControl();
            //chkAll.Checked = true;
            //IsCheck = true;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwOfficeItemTrans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OfficeItemTran oOfficeItemTran = (OfficeItemTran)lvwOfficeItemTrans.SelectedItems[0].Tag;

            if (oOfficeItemTran.Status == (int)Dictionary.OfficeTranStatus.Create)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to delete Requisition No: " + oOfficeItemTran.TranNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        //Delete Tran/Tran Item
                        oOfficeItemTran.Delete_HQ(oOfficeItemTran.TranID);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("You cannot delete Data", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwOfficeItemTrans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OfficeItemTran oOfficeItemTran = (OfficeItemTran)lvwOfficeItemTrans.SelectedItems[0].Tag;
            if (oOfficeItemTran.Status == (int)Dictionary.OfficeTranStatus.Create && oOfficeItemTran.Terminal==(int) Dictionary.Terminal.Head_Office)
            {
                frmOfficeItemTran oForm = new frmOfficeItemTran();
                oForm.ShowDialog(oOfficeItemTran);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status & HO Requisition can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwOfficeItemTrans.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                nTranID = 0;
                nWarehouseID = 0;
                _oOfficeItemTran = (OfficeItemTran)lvwOfficeItemTrans.SelectedItems[0].Tag;
                nTranID = _oOfficeItemTran.TranID;
                nWarehouseID = _oOfficeItemTran.WarehouseID;
                nTerminal = _oOfficeItemTran.Terminal;
                _oOfficeItemTran = new OfficeItemTran();
                DBController.Instance.OpenNewConnection();
                _oOfficeItemTran.RefreshOfficeItemRequisition(nTranID, nWarehouseID, nTerminal);

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptOfficeItemRequisitionView));
                oReport.SetDataSource(_oOfficeItemTran);
                string sReportName = "";
                string sRequisitionNo = "";
                string sType = "";
                string sTypes = "";

                if (_oOfficeItemTran.TranTypeID == (int)Dictionary.StationaryTranType.Requisition)
                {
                    sReportName = "Requisition";
                    sRequisitionNo = "Requisition No: " + _oOfficeItemTran.TranNo;
                    sType = "Requisition Date: ";
                    sTypes = "Requisition Remarks: ";
                }
                else if (_oOfficeItemTran.TranTypeID == (int)Dictionary.StationaryTranType.Purchase)
                {
                    sReportName = "Purchase";
                    sRequisitionNo = "Purchase No:" + _oOfficeItemTran.TranNo;
                    sType = "Purchase Date: ";
                    sTypes = "Purchase Remarks: ";
                }
                else if (_oOfficeItemTran.TranTypeID == (int)Dictionary.StationaryTranType.Issue)
                {
                    sReportName = "Issue";
                    sRequisitionNo = "Issue No:" + _oOfficeItemTran.TranNo;
                    sType = "Issue Date: ";
                    sTypes = "Issue Remarks: ";
                }

                oReport.SetParameterValue("ReportName", sReportName);
                oReport.SetParameterValue("TranNo", sRequisitionNo);
                oReport.SetParameterValue("TranDate", sType + _oOfficeItemTran.TranDate.ToString("dd-MMM-yyyy"));
                if (_oOfficeItemTran.WarehouseID != 0)
                {
                    oReport.SetParameterValue("CustomerName", _oOfficeItemTran.CustomerName);
                }
                else
                {
                    oReport.SetParameterValue("CustomerName", "HO");
                
                }
                oReport.SetParameterValue("Remarks", sTypes + _oOfficeItemTran.Remarks);
                oReport.SetParameterValue("Status", _oOfficeItemTran.StatusName);

                if (_oOfficeItemTran.AuthorizeUserID != 0)
                {
                    oReport.SetParameterValue("AuthorizedUser", _oOfficeItemTran.AuthorizedUser);
                }
                else
                {
                    oReport.SetParameterValue("AuthorizedUser", "NA");
                }
                if (_oOfficeItemTran.AuthorizedUser == "NA")
                {
                    oReport.SetParameterValue("AuthorizedDate", "NA");
                }
                else
                {
                    oReport.SetParameterValue("AuthorizedDate", _oOfficeItemTran.ApprovedDate.ToString("dd-MMM-yyyy"));
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

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwOfficeItemTrans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OfficeItemTran oOfficeItemTran = (OfficeItemTran)lvwOfficeItemTrans.SelectedItems[0].Tag;
            if (oOfficeItemTran.Status == (int)Dictionary.OfficeTranStatus.Create)
            {
                frmOfficeItemsAuthorization oForm = new frmOfficeItemsAuthorization();
                oForm.ShowDialog(oOfficeItemTran);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be Authorize", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
        }

    }
}