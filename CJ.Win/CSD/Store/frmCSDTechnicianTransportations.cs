using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.CSD;
using CJ.Win.Security;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win.CSD.Store
{
    public partial class frmCSDTechnicianTransportations : Form
    {

        private CSDTechnicianTransportation oCSDTechnicianTransportation;
        private CSDTechnicianTransportations _oCSDTechnicianTransportations;

        public frmCSDTechnicianTransportations()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmCSDTechnicianTransportations_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            LoadData();
        }

        private void LoadCombos()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("ALL");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDTechnicianTransportationStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.CSDTechnicianTransportationStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void LoadData()
        {
            _oCSDTechnicianTransportations = new CSDTechnicianTransportations();
            lvwTechTranList.Items.Clear();

            int nStatus = -1;
            if (cmbStatus.SelectedIndex != 0)
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oCSDTechnicianTransportations.Refresh(txtTechCode.Text.Trim(), txtTechName.Text.Trim(), dtFromDate.Value.Date, dtToDate.Value.Date,  nStatus);
            this.Text = "Total" + "[" + _oCSDTechnicianTransportations.Count + "]";

            foreach (CSDTechnicianTransportation oCSDTechnicianTransportation in _oCSDTechnicianTransportations)
            {
                ListViewItem oItem = lvwTechTranList.Items.Add(oCSDTechnicianTransportation.TechnicianCode);
                oItem.SubItems.Add(oCSDTechnicianTransportation.TechnicianName);
                oItem.SubItems.Add(oCSDTechnicianTransportation.FromDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDTechnicianTransportation.ToDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDTechnicianTransportation.Amount.ToString());
                oItem.SubItems.Add(oCSDTechnicianTransportation.PartialAmount.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDTechnicianTransportationStatus), oCSDTechnicianTransportation.Status));
                oItem.SubItems.Add(oCSDTechnicianTransportation.CreateDate.ToString("dd-MMM-yyyy"));

                oItem.Tag = oCSDTechnicianTransportation;
            }
            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (lvwTechTranList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwTechTranList.Items)
                {
                    if (oItem.SubItems[6].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[6].Text == "Create")
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                }
            }
        }

        private void btnReportView_Click(object sender, EventArgs e)
        {
            if (lvwTechTranList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to to view report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                        this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            ReportDataLoad();
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }

        private void ReportDataLoad()
        {
            _oCSDTechnicianTransportations = new CSDTechnicianTransportations();

            CSDTechnicianTransportation _oCSDTechnicianTransportation = (CSDTechnicianTransportation)lvwTechTranList.SelectedItems[0].Tag;
            _oCSDTechnicianTransportations.LoadDataForReport(_oCSDTechnicianTransportation.TransportationID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCSDTechnicianTransportation));
            doc.SetDataSource(_oCSDTechnicianTransportations);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("TechnicianCode", _oCSDTechnicianTransportation.TechnicianCode);
            doc.SetParameterValue("TechnicianName", _oCSDTechnicianTransportation.TechnicianName);
            doc.SetParameterValue("Amount", _oCSDTechnicianTransportation.Amount);
            doc.SetParameterValue("PartialAmount", _oCSDTechnicianTransportation.PartialAmount);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwTechTranList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvwTechTranList.SelectedItems[0].SubItems[6].Text == "Approved")
            {
                MessageBox.Show("Can't approve as it already has approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CSDTechnicianTransportation _oCSDTechnicianTransportation = (CSDTechnicianTransportation)lvwTechTranList.SelectedItems[0].Tag;
            frmCSDTechnicianTransportationApprove ofrmfrmCSDTechnicianTransportationApprove = new frmCSDTechnicianTransportationApprove((int)Dictionary.CSDTechnicianTransportationStatus.Approved);
            ofrmfrmCSDTechnicianTransportationApprove.ShowDialog(_oCSDTechnicianTransportation);
            if (ofrmfrmCSDTechnicianTransportationApprove._bActionSave)
                LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
