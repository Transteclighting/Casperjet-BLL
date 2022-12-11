using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Report.BEIL;

namespace CJ.Win.BEIL
{
    public partial class frmLCMComponents : Form
    {
        bool IsCheck;
        LCMComponents _oLCMComponents;
        int _nType = 0;
        ProductGroups _AG;

        public frmLCMComponents(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void frmLCMComponents_Load(object sender, EventArgs e)
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;
            if (_nType == (int)Dictionary.LCMStatus.Stage_1)
            {
                LoadCombos();
                DataLoadControl();
            }
            else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                LoadCombos();
                chkAll.Checked = true;
                label2.Enabled = false;
                cmbStatus.Enabled = false;
                btnAdd.Text = "Action";
                btnEdit.Visible = false;
                btnReport.Visible = true;
                DataLoadControl();
                
            }
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All Status--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LCMStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.LCMStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //Load AG in combo
            _AG = new ProductGroups();
            _AG.GetHTVAG();
            cmbAG.Items.Clear();
            cmbAG.Items.Add("<ALL>");
            foreach (ProductGroup oProductGroup in _AG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.SelectedIndex = 0;
        }

        private void SetListViewRowColour()
        {
            if (lvwLCMComponent.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwLCMComponent.Items)
                {
                    if (oItem.SubItems[3].Text == "Stage_1")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[3].Text == "Stage_2")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[3].Text == "Stage_3")
                    {
                        oItem.BackColor = Color.Transparent;

                    }
                    else
                    {
                        oItem.BackColor = Color.Bisque;
                    }

                }
            }
        }

        private void DataLoadControl()
        {
            _oLCMComponents = new LCMComponents();
            lvwLCMComponent.Items.Clear();

            int nStatus = 0;
            if (_nType == (int)Dictionary.LCMStatus.Stage_1)
            {
                if (cmbStatus.SelectedIndex == 0)
                {
                    nStatus = -1;
                }
                else
                {
                    nStatus = cmbStatus.SelectedIndex;
                }
            }
            else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                nStatus = (int)Dictionary.LCMStatus.Stage_3;
            }

            int nAGID = 0;
            if (cmbAG.SelectedIndex == 0)
            {
                nAGID = -1;
            }
            else
            {
                nAGID = _AG[cmbAG.SelectedIndex - 1].PdtGroupID;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oLCMComponents.Refresh(dtFromdate.Value.Date, dtTodate.Value.Date, nStatus, txtChassisSL.Text.Trim(), IsCheck, _nType, nAGID);
            DBController.Instance.CloseConnection();

            foreach (LCMComponent oLCMComponent in _oLCMComponents)
            {
                ListViewItem oItem = lvwLCMComponent.Items.Add(oLCMComponent.ChassisSerial.ToString());
                oItem.SubItems.Add(oLCMComponent.AGName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oLCMComponent.CreateDate).ToString("dd-MMM-yyyy hh:mm tt"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LCMStatus), oLCMComponent.Status));
                if (oLCMComponent.BrandID == 38)
                {
                    oItem.SubItems.Add("Samsung");
                }
                else if(oLCMComponent.BrandID == 23)
                {
                    oItem.SubItems.Add("Transtec");
                }
                oItem.SubItems.Add(oLCMComponent.Remarks.ToString());
                oItem.SubItems.Add(oLCMComponent.CreateUserName.ToString());

                oItem.Tag = oLCMComponent;
            }
            SetListViewRowColour();
            this.Text = "Total:[" + _oLCMComponents.Count + "]";
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.LCMStatus.Stage_1)
            {
                frmLCMStage1 oFrom = new frmLCMStage1();
                oFrom.ShowDialog();
            }
            else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                if (lvwLCMComponent.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LCMComponent oLCMComponent = (LCMComponent)lvwLCMComponent.SelectedItems[0].Tag;
                if (oLCMComponent.Status == (int)Dictionary.LCMStatus.Stage_3)
                {
                    frmLCMStage3 oFrom = new frmLCMStage3((int)Dictionary.LCMStatus.Stage_4);
                    oFrom.ShowDialog(oLCMComponent);
                }
            }
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _oLCMComponents = new LCMComponents();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oLCMComponents.RefreshForReport(dtFromdate.Value.Date, dtTodate.Value.Date, IsCheck);

            //CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptLCMDefectiveComponent1));
            rptLCMDefectiveComponent oReport = new rptLCMDefectiveComponent();
            oReport.SetDataSource(_oLCMComponents);
            oReport.SetParameterValue("ReportName", "LCM Defective Component Serial");
            if (IsCheck == false)
            {
                oReport.SetParameterValue("FromDate", dtFromdate.Value.Date.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("ToDate", dtTodate.Value.Date.ToString("dd-MMM-yyyy"));
            }
            else
            {
                oReport.SetParameterValue("FromDate", "ALL");
                oReport.SetParameterValue("ToDate", "ALL");
            }
            oReport.SetParameterValue("PrintBy", Utility.UserFullname);
            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwLCMComponent.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LCMComponent oLCMComponent = (LCMComponent)lvwLCMComponent.SelectedItems[0].Tag;
            if (oLCMComponent.Status == (int)(int)Dictionary.LCMStatus.Stage_1 || oLCMComponent.Status == (int)(int)Dictionary.LCMStatus.Stage_2)
            {
                //if (oLCMComponent.Status == (int)(int)Dictionary.LCMStatus.Stage_1)
                //{
                //    frmLCMStage1 oFrom = new frmLCMStage1();
                //    oFrom.ShowDialog(oLCMComponent);
                //}
                //else if (oLCMComponent.Status == (int)(int)Dictionary.LCMStatus.Stage_2)
                //{
                frmLCMComponentEdit oFrom = new frmLCMComponentEdit();
                oFrom.ShowDialog(oLCMComponent);
                //MessageBox.Show("Only Stage 1 is editable");
                //}
            }
            DataLoadControl();
        }
    }
}