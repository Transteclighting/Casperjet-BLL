using System;
using System.Drawing;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmPOSOfficeItemTrans : Form
    {
        OfficeItemTrans _oOfficeItemTrans;
        bool IsCheck = false;
        int nTranID;
        int nWarehouseID;
        OfficeItemTran _oOfficeItemTran;
        int nTerminal = 0;
        
        public frmPOSOfficeItemTrans()
        {
            InitializeComponent();
        }

        private void frmPOSOfficeItemTrans_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPOSOfficeItemTran oFrom = new frmPOSOfficeItemTran();
            oFrom.ShowDialog();
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oOfficeItemTrans = new OfficeItemTrans();
            lvwOfficeItemTrans.Items.Clear();


            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oOfficeItemTrans.RefreshForPOS(dtFromDate.Value.Date, dtToDate.Value.Date, nStatus, txtTranNo.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (OfficeItemTran oOfficeItemTran in _oOfficeItemTrans)
            {
                ListViewItem oItem = lvwOfficeItemTrans.Items.Add(oOfficeItemTran.TranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oOfficeItemTran.TranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oOfficeItemTran.TranTypeName.ToString());
                oItem.SubItems.Add(oOfficeItemTran.StatusName.ToString());

                oItem.Tag = oOfficeItemTran;
            }
            SetListViewRowColour();
            this.Text = "Office Item Requisitions [" + _oOfficeItemTrans .Count+ "]";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwOfficeItemTrans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OfficeItemTran oOfficeItemTran = (OfficeItemTran)lvwOfficeItemTrans.SelectedItems[0].Tag;
            if (oOfficeItemTran.Status == (int)Dictionary.OfficeTranStatus.Create)
            {
                frmPOSOfficeItemTran oForm = new frmPOSOfficeItemTran();
                oForm.ShowDialog(oOfficeItemTran);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
                        oOfficeItemTran.DeleteRT(oOfficeItemTran.TranID, Utility.WarehouseID);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SetListViewRowColour()
        {
            if (lvwOfficeItemTrans.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOfficeItemTrans.Items)
                {
                    if (oItem.SubItems[3].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[3].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;

                    }
                    else if (oItem.SubItems[3].Text == "Approve_By_HO")
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
        private void btnGetData_Click(object sender, EventArgs e)
        {
           
            DataLoadControl();
        }
        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TELLib oTELLib = new TELLib();
            dtFromDate.Value = oTELLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");

            //Stationary Tran Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OfficeTranStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.OfficeTranStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

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
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

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
                oReport.SetParameterValue("CustomerName", _oOfficeItemTran.CustomerName);
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
                    oReport.SetParameterValue("AuthorizedDate", _oOfficeItemTran.ApprovedDate.ToString());
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