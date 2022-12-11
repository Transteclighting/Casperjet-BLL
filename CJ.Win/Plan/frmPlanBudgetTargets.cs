using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.Plan;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.Plan
{
    public partial class frmPlanBudgetTargets : Form
    {
        string sTableName = "";
        PlanBudgetTargetVersions _oPlanBudgetTargetVersions;
        public frmPlanBudgetTargets()
        {
            InitializeComponent();
        }

        private void frmPlanBudgetTargets_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnView.Enabled = false;
            btnApprove.Enabled = false;
            btnDelete.Enabled = false;
            RefreshData();
            ButtonPermission();
        }
        public void RefreshData()
        {
            lvwPlanBudgetTarget.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oPlanBudgetTargetVersions = new PlanBudgetTargetVersions();

            bool IsCheck = false;

            if (chkAll.Checked == true)
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }
            _oPlanBudgetTargetVersions.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck);

            foreach (PlanBudgetTargetVersion _oPlanBudgetTargetVersion in _oPlanBudgetTargetVersions)
            {
                ListViewItem lstItem = lvwPlanBudgetTarget.Items.Add(_oPlanBudgetTargetVersion.VersionNo.ToString());
               
                lstItem.SubItems.Add(_oPlanBudgetTargetVersion.VersionName.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(_oPlanBudgetTargetVersion.VersionDate).ToString("dd-MMM-yyyy"));

                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PlanVersionType), _oPlanBudgetTargetVersion.Type));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PlanVersionStatus), _oPlanBudgetTargetVersion.Status));
                lstItem.SubItems.Add(_oPlanBudgetTargetVersion.Remarks);


                lstItem.Tag = _oPlanBudgetTargetVersion;

            }
            this.Text = "Total" + "[" + _oPlanBudgetTargetVersions.Count + "]";
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void ButtonPermission()
        {
            UserPermission oUserPermission = new UserPermission();
            if (oUserPermission.CheckPermission("M12.10.1", Utility.UserId))
            {
                btnAdd.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M12.10.2", Utility.UserId))
            {
               btnView.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M12.10.3", Utility.UserId))
            {
                btnApprove.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M12.10.4", Utility.UserId))
            {
                btnDelete.Enabled = true;
            }
        
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPlanBudgetTragetUploader oform = new frmPlanBudgetTragetUploader();
            oform.ShowDialog();
            RefreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwPlanBudgetTarget.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PlanBudgetTargetVersion oPlanBudgetTargetVersion = (PlanBudgetTargetVersion)lvwPlanBudgetTarget.SelectedItems[0].Tag;
            if (oPlanBudgetTargetVersion.Status == (int)Dictionary.PlanVersionStatus.Approve)
            {
                MessageBox.Show("Approved Plan couldn't be deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Plan Version: " + oPlanBudgetTargetVersion.VersionNo.ToString() + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    //if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.ExecutiveWeekTarget)
                    //{
                    //    PlanExecutiveWeekTarget oPEWT = new PlanExecutiveWeekTarget();
                    //    oPEWT.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                    //    oPEWT.Delete();
                    //}
                    //else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.PGWiseTargetValue)
                    //{
                    //    PlanPGMonthValueTarget oPWTV = new PlanPGMonthValueTarget();
                    //    oPWTV.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                    //    oPWTV.Delete();
                    //}
                    //else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
                    //{
                    //    PlanMAGWeekQtyTarget oPMWTQ = new PlanMAGWeekQtyTarget();
                    //    oPMWTQ.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                    //    oPMWTQ.Delete();
                    //}
                    //else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
                    //{
                    //    PlanExecutiveWeekTarget oExecutiveLeadTarget = new PlanExecutiveWeekTarget();
                    //    oExecutiveLeadTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                    //    oExecutiveLeadTarget.DeleteLeadTarget();
                    //}
                    //else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.OpportunityTarget)
                    //{
                    //    PlanExecutiveWeekTarget oExecutiveLeadTarget = new PlanExecutiveWeekTarget();
                    //    oExecutiveLeadTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                    //    oExecutiveLeadTarget.DeleteOT();
                    //}

                    //ExecutiveWeekTarget = 1,
                    //PGWiseTargetValue = 2,
                    //MAGWiseTargetQty = 3,
                    //CustomerTargetQty = 4,
                    //ExecutiveLeadTarget = 5,
                    //ExecutiveMAGWeekTargetQty = 6,
                    //OpportunityTarget = 7,
                    //PlanDealerMAGTarget = 8,

                    string sDeleteTableName = "";
                    if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.ExecutiveWeekTarget)
                    {
                        sDeleteTableName = "t_PlanExecutiveWeekTarget";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
                    {
                        sDeleteTableName = "t_PlanMAGWeekTargetQty";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
                    {
                        sDeleteTableName = "t_PlanExecutiveLeadTarget";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
                    {
                        sDeleteTableName = "t_PlanExecutiveLeadTarget";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.OpportunityTarget)
                    {
                        sDeleteTableName = "t_PlanOpportunityTarget";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.PlanDealerMAGTarget)
                    {
                        sDeleteTableName = "t_PlanDealerMAGTarget";

                    }
                    oPlanBudgetTargetVersion.DeleteDetail(sDeleteTableName);
                    oPlanBudgetTargetVersion.Delete();
                    DBController.Instance.CommitTransaction();
                    RefreshData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwPlanBudgetTarget.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PlanBudgetTargetVersion oPlanBudgetTargetVersion = (PlanBudgetTargetVersion)lvwPlanBudgetTarget.SelectedItems[0].Tag;

            if (oPlanBudgetTargetVersion.Status == (int)Dictionary.PlanVersionStatus.Approve)
            {
                MessageBox.Show("The Plan is already Approved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to Approve the Plan Version: " + oPlanBudgetTargetVersion.VersionNo.ToString() + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    PlanBudgetTargetVersion oPBT = new PlanBudgetTargetVersion();
                    oPBT.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                    oPBT.Status = (int)Dictionary.PlanVersionStatus.Approve;
                    oPBT.UpdateStatus();
                    //SendSMS(oPlanBudgetTargetVersion.VersionName);

                    DataTran oDataTransfer;
                    Showrooms oShowrooms = new Showrooms();
                    sTableName = "";

                    if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.ExecutiveWeekTarget)
                    {
                        sTableName = "t_PlanExecutiveWeekTarget";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
                    {
                        sTableName = "t_PlanMAGWeekTargetQty";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
                    {
                        sTableName = "t_PlanExecutiveLeadTarget";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
                    {
                        sTableName = "t_PlanExecutiveLeadTarget";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.OpportunityTarget)
                    {
                        sTableName = "t_PlanOpportunityTarget";

                    }
                    else if (oPlanBudgetTargetVersion.Type == (int)Dictionary.PlanVersionType.PlanDealerMAGTarget)
                    {
                        sTableName = "t_PlanDealerMAGTarget";

                    }
                    oShowrooms.RefreshForTarget(sTableName, oPlanBudgetTargetVersion.VersionNo);
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        oDataTransfer = new DataTran();
                        oDataTransfer.TableName = sTableName;
                        oDataTransfer.DataID = oPlanBudgetTargetVersion.VersionNo;
                        oDataTransfer.WarehouseID = oShowroom.WarehouseID;
                        oDataTransfer.TransferType = 1;
                        oDataTransfer.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTransfer.BatchNo = 0;
                        oDataTransfer.AddForTDPOS();
                    }
                    DBController.Instance.CommitTransaction();
                    RefreshData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }
        private void SendSMS(string sVersionName)
        {
            SMSMessages oSMSMessages = new SMSMessages();
            oSMSMessages.GetMobileNoByGroup(199);//199=TEL_SalesTargetUploadNitificationGroup

            foreach (SMSMessage oSMSMessage in oSMSMessages)
            {

                oSMSMessage.RequestDate = DateTime.Now;
                oSMSMessage.SMSText = sVersionName + " approved!!";
                oSMSMessage.SMSType = 1;
                oSMSMessage.SendDate = DateTime.Now;
                oSMSMessage.Status = 1;
                oSMSMessage.SubmittedBy = Utility.Username;
                oSMSMessage.SuccessCount = 0;
                oSMSMessage.FailCount = 0;

                oSMSMessage.Add();
            }
        }
    }
}