using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Win.CSD.CallCenter;

namespace CJ.Win.CSD
{
    public partial class frmCSDtechnicianJobsInHand : Form
    {
        CSDJobs _oCSDJobs;
        CSDTechnicianBlocks _oCSDTechnicianBlocks;
        DateTime _dFormDate;
        public frmCSDtechnicianJobsInHand(DateTime dFormDate)
        {
            InitializeComponent();
            _dFormDate = dFormDate;
        }
        public void ShowDialog(CSDTechnician oTechnician)
        {
            this.Tag = oTechnician;
            lblTechnicianName.Text = oTechnician.Name;
            lblThirdPartyName.Text = oTechnician.ThirdPartyName;
            this.ShowDialog();
        }
        private void DataLoadControl()
        {
            CSDTechnician oTechnician = (CSDTechnician)this.Tag;
            DBController.Instance.OpenNewConnection();
            _oCSDJobs = new CSDJobs();
            _oCSDJobs.RefreshByTechnicianID(oTechnician.TechnicianID);

            this.Text = "CSD Technician Assign Job | Total: " + "[" + _oCSDJobs.Count + "]";
            lvwTechnicianJobInHand.Items.Clear();
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwTechnicianJobInHand.Items.Add(Convert.ToDateTime(oCSDJob.VisitingDate).ToShortDateString());
                oItem.SubItems.Add(Convert.ToDateTime(oCSDJob.VisitingTimeFrom).ToShortTimeString());
                oItem.SubItems.Add(Convert.ToDateTime(oCSDJob.VisitingTimeTo).ToShortTimeString());
                oItem.SubItems.Add(oCSDJob.JobNo);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ServiceType),oCSDJob.ServiceType));
                oItem.SubItems.Add(oCSDJob.CustomerAddress);
                oItem.SubItems.Add(oCSDJob.ThanaName);
                oItem.SubItems.Add(oCSDJob.DistrictName);
                oItem.Tag = oCSDJob;
            }

        }

        private void LoadData(DateTime dDateTime)
        {
            CSDTechnician oTechnician = (CSDTechnician)this.Tag;
            DBController.Instance.OpenNewConnection();
            _oCSDTechnicianBlocks = new CSDTechnicianBlocks();
            _oCSDTechnicianBlocks.RefreshByTechnicianBlockJobInHand(oTechnician.TechnicianID, dDateTime.Date);

            this.Text = "CSD Technician Block | Total: " + "[" + _oCSDTechnicianBlocks.Count + "]";
            lvwTechnicianBlock.Items.Clear();
            foreach (CSDTechnicianBlock oCSDTechnicianBlock in _oCSDTechnicianBlocks)
            {
                ListViewItem oItem = lvwTechnicianBlock.Items.Add(oCSDTechnicianBlock.Code);
                oItem.SubItems.Add(oCSDTechnicianBlock.Name);
                oItem.SubItems.Add(oCSDTechnicianBlock.FromDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDTechnicianBlock.ToDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oCSDTechnicianBlock.IsFullTime));
                if (oCSDTechnicianBlock.IsFullTime == (int)Dictionary.YesOrNoStatus.NO)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDTechnicianBlock.FromTime).ToShortTimeString());
                }
                else
                {
                    oItem.SubItems.Add(" ");
                }
                if (oCSDTechnicianBlock.IsFullTime == (int)Dictionary.YesOrNoStatus.NO)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDTechnicianBlock.ToTime).ToShortTimeString());
                }
                else
                {
                    oItem.SubItems.Add(" ");
                }
                oItem.SubItems.Add(oCSDTechnicianBlock.CreateDate.ToString("dd-MMM-yyyy hh:mm tt"));
                oItem.SubItems.Add(oCSDTechnicianBlock.UserName);
                oItem.SubItems.Add(oCSDTechnicianBlock.ApprovedDate.ToString("dd-MMM-yyyy hh:mm tt"));
                oItem.SubItems.Add(oCSDTechnicianBlock.ApprovedBy);
                
                oItem.Tag = oCSDTechnicianBlock;
            }

        }

        private void frmCSDtechnicianJobsInHand_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            LoadData(_dFormDate);
        }

        private void lvwTechnicianJobInHand_DoubleClick(object sender, EventArgs e)
        {
            if (lvwTechnicianJobInHand.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                CSDJob oCSDJob = (CSDJob)lvwTechnicianJobInHand.SelectedItems[0].Tag;         
                frmJobDetail oform = new frmJobDetail();
                oform.ShowDialog(oCSDJob.JobNo, 0);
                this.Cursor = Cursors.Default;
            }
        }

    }
}