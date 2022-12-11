using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.BEIL;
using CJ.Win.Security;
using CJ.Class;
using CJ.Class.BEIL;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.BEIL;


namespace CJ.Win.BEIL.Tool_Management
{
    public partial class frmGoodsReceiveForTools : Form
    {
        ToolTrans oToolTrans;
        ToolTran _ooToolTran;
        ToolTranItem _oToolTranItem;
        private ToolTrans _oToolTrans;
        bool IsCheck = false;
        int _toolTranType = 0;
        int nToolTranID;
        public frmGoodsReceiveForTools(int toolTranType)
        {
            InitializeComponent();
            _toolTranType = toolTranType;
        }

        private void frmGoodsReceives_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_toolTranType == 1)
            {
                string currentForm = "Add";

                frmGoodsReceiveForTool ofrmGoodsReceiveForTool = new frmGoodsReceiveForTool((int)Dictionary.ToolManagement.Create, currentForm);
                ofrmGoodsReceiveForTool.ShowDialog();
                if (ofrmGoodsReceiveForTool._bActionSave)
                    LoadData();
            }


            if (_toolTranType == 2)
            {
                string currentForm = "Add";

                frmToolIssue ofrmToolIssue = new frmToolIssue((int)Dictionary.ToolManagement.Create, currentForm);
                ofrmToolIssue.ShowDialog();
                if (ofrmToolIssue._bActionSave)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwToolGoodsReceive.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_toolTranType == 1)
            {
                ToolTran _oToolTran = (ToolTran)lvwToolGoodsReceive.SelectedItems[0].Tag;
                string currentForm = "Edit";
                frmGoodsReceiveForTool ofrmGoodsReceiveForTool = new frmGoodsReceiveForTool((int)Dictionary.ToolManagement.Create, currentForm);

                ofrmGoodsReceiveForTool.ShowDialog(_oToolTran);
                if (ofrmGoodsReceiveForTool._bActionSave)
                    LoadData();
            }


            if (_toolTranType == 2)
            {

                ToolTran _oToolTran = (ToolTran)lvwToolGoodsReceive.SelectedItems[0].Tag;
                string currentForm = "Edit";
                frmToolIssue ofrmToolIssue = new frmToolIssue((int)Dictionary.ToolManagement.Create, currentForm);

                ofrmToolIssue.ShowDialog(_oToolTran);
                if (ofrmToolIssue._bActionSave)
                    LoadData();
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            oToolTrans = new ToolTrans();
            lvwToolGoodsReceive.Items.Clear();

            DBController.Instance.OpenNewConnection();


            oToolTrans.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck, _toolTranType);

            foreach (ToolTran ooToolTran in oToolTrans)
            {
                ListViewItem oItem = lvwToolGoodsReceive.Items.Add(ooToolTran.ToolTranID.ToString());
                oItem.SubItems.Add(ooToolTran.TranDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(ooToolTran.FromWH.ToString());
                oItem.SubItems.Add(ooToolTran.ToWH.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ToolManagementStatus), ooToolTran.Status));
                oItem.SubItems.Add(ooToolTran.Remarks.ToString());
                //oItem.SubItems.Add(ooToolTran.EmployeeName.ToString());
                //oItem.SubItems.Add(ooToolTran.SupplierName.ToString());
                oItem.Tag = ooToolTran;
            }
            this.Text = "Tool Tran List-" + oToolTrans.Count + "";
            SetListViewRowColour();
        }

        private void SetListViewRowColour()
        {
            if (lvwToolGoodsReceive.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwToolGoodsReceive.Items)
                {
                    if (oItem.SubItems[2].Text == "Create")
                    {
                        oItem.BackColor = Color.Pink;
                    }
                    else
                    {
                        oItem.BackColor = Color.Transparent;
                    }

                }
            }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PrintPromo();
            this.Cursor = Cursors.Default;
        }

        public void PrintPromo()
        {
            if (lvwToolGoodsReceive.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                nToolTranID = 0;


                _ooToolTran = (ToolTran)lvwToolGoodsReceive.SelectedItems[0].Tag;
                nToolTranID = _ooToolTran.ToolTranID;

                _ooToolTran = new ToolTran();
                _oToolTranItem = new ToolTranItem();
                DBController.Instance.OpenNewConnection();

                if (_toolTranType == 1)
                {
                    _ooToolTran.GetDataForReportToolReceived(nToolTranID);

                    CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptToolReceived));
                    oReport.SetDataSource(_ooToolTran);

                    oReport.SetParameterValue("TranDate", _ooToolTran.TranDate);
                    if (_ooToolTran.SupplierName != null)
                        oReport.SetParameterValue("SupplierName", _ooToolTran.SupplierName);
                    else
                        oReport.SetParameterValue("SupplierName", "NA");
                    oReport.SetParameterValue("FromWH", _ooToolTran.FromWH);
                    oReport.SetParameterValue("ToWh", _ooToolTran.ToWH);
                    oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                    oReport.SetParameterValue("PrintBy", Utility.UserFullname);

                    frmPrintPreview oFrom = new frmPrintPreview();

                    oFrom.ShowDialog(oReport);
                    this.Cursor = Cursors.Default;
                }

                else
                {
                    _ooToolTran.GetDataForReportToolIssue(nToolTranID);

                    CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptToolsIssue));
                    oReport.SetDataSource(_ooToolTran);

                    oReport.SetParameterValue("TranDate", _ooToolTran.TranDate);
                    oReport.SetParameterValue("EmployeeCode", _ooToolTran.EmployeeCode);
                    oReport.SetParameterValue("EmployeeName", _ooToolTran.EmployeeName);
                    oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                    oReport.SetParameterValue("PrintBy", Utility.UserFullname);

                    frmPrintPreview oFrom = new frmPrintPreview();

                    oFrom.ShowDialog(oReport);
                    this.Cursor = Cursors.Default;
                }

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
  }
}
