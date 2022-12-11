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

namespace CJ.Win
{
    public partial class frmOutletCommissionCalculation : Form
    {
        
        OutletCommissionDetail _oOutletCommissionDetail;
        OutletCommission _oOutletCommission;
        OutletCommissions _oOutletCommissions;
        TELLib _oLib;
        int nID;
        int nType;
        public frmOutletCommissionCalculation()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            frmOutletCommissionProcess oFrom = new frmOutletCommissionProcess();
            oFrom.ShowDialog();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {

            LoadData();
        }
        private void LoadCombos()
        {
            dtGetCommitionDate.Value = DateTime.Today;
            cmbEmpType.Items.Clear();
            cmbEmpType.Items.Add("<All>");

            //EmployeeType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutletEmployeeType)))
            {
                cmbEmpType.Items.Add(Enum.GetName(typeof(Dictionary.OutletEmployeeType), GetEnum));
            }
            cmbEmpType.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");

            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CommissionStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.CommissionStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void LoadData()
        {

            int nYear = Convert.ToInt32(dtGetCommitionDate.Value.Year);
            int nMonth = Convert.ToInt32(dtGetCommitionDate.Value.Month);

            _oOutletCommissions = new OutletCommissions();
            lvwOutletCommission.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oOutletCommissions.Refershs(nMonth, nYear, cmbEmpType.SelectedIndex, cmbStatus.SelectedIndex);
            DBController.Instance.CloseConnection();
            _oLib = new TELLib();
            foreach (OutletCommission oOutletCommission in _oOutletCommissions)
            {
                ListViewItem oItem = lvwOutletCommission.Items.Add(oOutletCommission.MonthNo.ToString());
                oItem.SubItems.Add(oOutletCommission.YearNo.ToString());
                //oItem.SubItems.Add(oOutletCommission.Type.ToString());
                oItem.SubItems.Add(oOutletCommission.TypeName.ToString());
                if (oOutletCommission.ApproveDate != "")
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oOutletCommission.ApproveDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(_oLib.TakaFormat(oOutletCommission.TotalAmount));
                oItem.SubItems.Add(oOutletCommission.Remarks.ToString());
                oItem.SubItems.Add(oOutletCommission.StatusName.ToString());

                oItem.Tag = oOutletCommission;
            }
            SetListViewRowColour();
        }

        private void SetListViewRowColour()
        {
            if (lvwOutletCommission.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOutletCommission.Items)
                {
                    if (oItem.SubItems[6].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else
                    {
                        oItem.BackColor = Color.LightGreen;
                    }

                }
            }
        }

        private void frmOutletCommissionCalculation_Load(object sender, EventArgs e)
        {
            btnProcess.Enabled = false;
            btnApproved.Enabled = false;
            btnAdjustment.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            LoadCombos();
            LoadData();
            ButtonPermission();
        }
        private void ButtonPermission()
        {
            UserPermission oUserPermission = new UserPermission();
            DBController.Instance.OpenNewConnection();
            if (oUserPermission.CheckPermission("M7.12.1", Utility.UserId))
            {
                btnProcess.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M7.12.2", Utility.UserId))
            {
                btnApproved.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M7.12.3", Utility.UserId))
            {
                btnAdjustment.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M7.12.4", Utility.UserId))
            {
                btnDelete.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M7.12.5", Utility.UserId))
            {
                btnPrint.Enabled = true;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwOutletCommission.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OutletCommission oOutletCommission = (OutletCommission)lvwOutletCommission.SelectedItems[0].Tag;

            if (oOutletCommission.Status == (int)Dictionary.CommissionStatus.Create)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to delete Commission : " + oOutletCommission.TypeName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        //Delete Commission/Commission Detail
                        oOutletCommission.DeleteCommission(oOutletCommission.ID);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
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
                MessageBox.Show("You Cannot Delete Data.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwOutletCommission.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Authorized.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OutletCommission oOutletCommissions = (OutletCommission)lvwOutletCommission.SelectedItems[0].Tag;
            if (oOutletCommissions.Status == (int)Dictionary.CommissionStatus.Create)
            {
                OutletCommission oOutletCommission = new OutletCommission();
                DBController.Instance.OpenNewConnection();
                DialogResult oResult = MessageBox.Show("Are you sure you want to Approved Commission: " + oOutletCommissions.TypeName + " and Amount : " + oOutletCommissions.TotalAmount + " ? ", "Confirm Ticket Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                  if (oResult == DialogResult.Yes)
                  {

                      try
                      {
                          oOutletCommission.ID = oOutletCommissions.ID;
                          oOutletCommission.Type = oOutletCommissions.Type;
                          oOutletCommission.ApproveUserID = Utility.UserId;
                          oOutletCommission.ApproveDate = DateTime.Now;
                          oOutletCommission.Status = (int)Dictionary.CommissionStatus.Approved;
                          DBController.Instance.BeginNewTransaction();
                          oOutletCommission.UpdateStatus();
                          DBController.Instance.CommitTran();
                          MessageBox.Show("Successfully Approved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          LoadData();

                      }
                      catch (Exception ex)
                      {
                          DBController.Instance.RollbackTransaction();
                          MessageBox.Show(" Error" + ex);
                      }
                  }
            }
            else
            {
                MessageBox.Show("Only Create status can be Approved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            if (lvwOutletCommission.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Adjust.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutletCommission oOutletCommission = (OutletCommission)lvwOutletCommission.SelectedItems[0].Tag;
            if (oOutletCommission.Status == (int)Dictionary.CommissionStatus.Create)
            {
                frmOutletCommissionADDDeduc oForm = new frmOutletCommissionADDDeduc();
                oForm.ShowDialog(oOutletCommission);
                LoadData();

            }
            else
            {
                MessageBox.Show("Only Create status can be Adjusted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwOutletCommission.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                nID = 0;
                nType = 0;
                OutletCommission oOutletCommission = (OutletCommission)lvwOutletCommission.SelectedItems[0].Tag;
                nID = oOutletCommission.ID;
                nType = oOutletCommission.Type;
                OutletCommission _oOutletCommission = new OutletCommission();
                DBController.Instance.OpenNewConnection();
                _oOutletCommission.RefreshOutletCommission(nID, nType);
                DBController.Instance.CloseConnection();

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptEmployeeWiseCommission));
                oReport.SetDataSource(_oOutletCommission);
                string sReportName = "";

                if (nType == (int)Dictionary.OutletEmployeeType.Executive)
                {
                    sReportName = "Commission Statement Report [Executive]";
                }
                else if (nType == (int)Dictionary.OutletEmployeeType.Manager)
                {
                    sReportName = "Commission Statement Report [Manager]";
                }
                else if (nType == (int)Dictionary.OutletEmployeeType.ShopAssistant)
                {
                    sReportName = "Commission Statement Report [ShopAssistant]";
                }
                //foreach (OutletCommissionDetail oOutletCommissionDetail in _oOutletCommission)
                //{
                    oReport.SetParameterValue("CompanyInfo", Utility.CompanyName);
                    oReport.SetParameterValue("ReportName", sReportName);
                    oReport.SetParameterValue("UserName", Utility.UserFullname);
                    oReport.SetParameterValue("EmployeeType", oOutletCommission.TypeName);
                    oReport.SetParameterValue("Year", oOutletCommission.YearNo.ToString());
                    oReport.SetParameterValue("Month", oOutletCommission.MonthNo.ToString());
                    frmPrintPreview oFrom = new frmPrintPreview();

                    oFrom.ShowDialog(oReport);
                    this.Cursor = Cursors.Default;




                //}
                

                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmOutletCommissionProcessNew oFrom = new frmOutletCommissionProcessNew();
            oFrom.ShowDialog();
            LoadData();
        }
    }
}