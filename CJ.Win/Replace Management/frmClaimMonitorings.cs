using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.DMS;
using CJ.Win.Security;

namespace CJ.Win.Replace_Management
{
    public partial class frmClaimMonitorings : Form
    {
        ClaimSettlements oClaimSettlements = new ClaimSettlements();
        int nStatus = 0;
        int nCustomerID = 0;
        
        public frmClaimMonitorings()
        {
            InitializeComponent();
            //cmbStatus.DataSource = Enum.GetValues(typeof(ClaimType));
            //pnlDate.Hide();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            //pnlDate.Hide();
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            oClaimSettlements = new ClaimSettlements();
            lvwReplaceClaims.Items.Clear();

            nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            nCustomerID = 0;
            if (ctlCustomer1.txtCode.Text == "")
            {
                nCustomerID = -1;
            }
            else
            {
                nCustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            }

            DBController.Instance.OpenNewConnection();

            oClaimSettlements.ClaimRefresh(nStatus, nCustomerID, dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1));

            foreach (ClaimSettlement oClaimSettlement in oClaimSettlements)
            {
                ListViewItem oItem = lvwReplaceClaims.Items.Add(oClaimSettlement.RegionName.ToString());
                oItem.SubItems.Add(oClaimSettlement.AreaName.ToString());
                oItem.SubItems.Add(oClaimSettlement.TerritoryName.ToString());
                oItem.SubItems.Add(oClaimSettlement.CustomerCode.ToString());
                oItem.SubItems.Add(oClaimSettlement.CustomerName.ToString());
                oItem.SubItems.Add(oClaimSettlement.CustomerTypeName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oClaimSettlement.SettlementDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oClaimSettlement.SettlementType.ToString());
                oItem.SubItems.Add(oClaimSettlement.Remarks.ToString());
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LiveDemoStatus), oLiveDemo.Status));



                oItem.Tag = oClaimSettlement;
            }
        }

        //private void DataLoadControl()
        //{
        //    //oDMSReplaceClaims = new DMSReplaceClaims();
        //    oClaimSettlements = new ClaimSettlements();
        //    lvwReplaceClaims.Items.Clear();
        //    DBController.Instance.CheckConnection();

        //    var list = new List<ClaimSettlement>();

        //    if (string.IsNullOrWhiteSpace(ctlCustomer1.txtCode.Text.ToString()))

        //    {
        //        list = oClaimSettlements.RefreshMonitoring(-1, dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1));

        //    }
        //    else
        //        list = oClaimSettlements.RefreshMonitoring(ctlCustomer1.SelectedCustomer.CustomerID, dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1));


        //    //if (string.IsNullOrWhiteSpace(txtTokenNo.Text) && cmbStatus.SelectedIndex == 0)
        //    //{
        //    //    foreach (DMSReplaceClaim oDMSReplaceClaim in list)
        //    //    {
        //    //        addRowToListview(oDMSReplaceClaim);
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    if (!string.IsNullOrWhiteSpace(txtTokenNo.Text))
        //    //    {
        //    //        int tokenNo;
        //    //        try
        //    //        {
        //    //            tokenNo = Int32.Parse(txtTokenNo.Text);
        //    //        }
        //    //        catch (Exception ex)
        //    //        {
        //    //            MessageBox.Show("Token No is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //            return;
        //    //        }
        //    //        var oDMSReplaceClaim = list.FirstOrDefault(rp => rp.ReplaceClaimNo == tokenNo.ToString());
        //    //        if (oDMSReplaceClaim == null)
        //    //        {
        //    //            MessageBox.Show("Token No is not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //            return;
        //    //        }
        //    //        addRowToListview(oDMSReplaceClaim);
        //    //    }
        //    //    else if (cmbStatus.SelectedIndex != 0)
        //    //    {
        //    //        foreach (DMSReplaceClaim oDMSReplaceClaim in list)
        //    //        {
        //    //            if ((int)cmbStatus.SelectedValue == (int)status.LogisticRecieved)
        //    //            {
        //    //                if (oDMSReplaceClaim.LogisticRecDate != default(DateTime) && oDMSReplaceClaim.ReplacementRecDate == default(DateTime))
        //    //                {
        //    //                    addRowToListview(oDMSReplaceClaim);
        //    //                }
        //    //            }
        //    //            if ((int)cmbStatus.SelectedValue == (int)status.SentToReplacement)
        //    //            {
        //    //                if (oDMSReplaceClaim.ReplacementRecDate != default(DateTime) && oDMSReplaceClaim.ApprovalDate == default(DateTime))
        //    //                {
        //    //                    addRowToListview(oDMSReplaceClaim);
        //    //                }
        //    //            }
        //    //            if ((int)cmbStatus.SelectedValue == (int)status.Approved)
        //    //            {
        //    //                if (oDMSReplaceClaim.ApprovalDate != default(DateTime) && oDMSReplaceClaim.DeliveryDate == default(DateTime))
        //    //                {
        //    //                    addRowToListview(oDMSReplaceClaim);
        //    //                }
        //    //            }
        //    //            if ((int)cmbStatus.SelectedValue == (int)status.Delivered)
        //    //            {
        //    //                if (oDMSReplaceClaim.DeliveryDate != default(DateTime))
        //    //                {
        //    //                    addRowToListview(oDMSReplaceClaim);
        //    //                }
        //    //            }

        //    //        }
        //    //    }
        //    //}
        //    ////if(list.Count>0)
        //    ////    lvwReplaceClaims.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    ////else
        //    ////    lvwReplaceClaims.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //}

        private void btRep_Click(object sender, EventArgs e)
        {
            frmReplacementClaimSettelement ofrom = new frmReplacementClaimSettelement();
            ofrom.ShowDialog();
            DataLoadControl();
        }

        private void frmClaimMonitorings_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void LoadCombos()
        {

            ClaimSettlements oClaimSettlements = new ClaimSettlements();
            DBController.Instance.OpenNewConnection();

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ClaimType)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ClaimType), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }
        private void btnTPKPI_Click(object sender, EventArgs e)
        {
            frmTPorKPISettlement ofrom = new frmTPorKPISettlement();
            ofrom.ShowDialog();
            DataLoadControl();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
