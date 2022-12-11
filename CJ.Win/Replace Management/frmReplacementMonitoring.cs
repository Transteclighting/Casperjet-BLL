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
    public partial class frmReplacementMonitoring : Form
    {
        DMSReplaceClaims oDMSReplaceClaims = new DMSReplaceClaims();
        public enum status
        {
            SelectStatus = 0,
            LogisticRecieved = 1,
            SentToReplacement = 2,
            Approved = 3,
            Delivered = 4
        }

        public frmReplacementMonitoring()
        {
            InitializeComponent();
            cmbStatus.DataSource = Enum.GetValues(typeof(status));
            pnlDate.Hide();
            
        }

        private void frmReplacementMonitoring_Load(object sender, EventArgs e)
        {
            lvwReplaceClaims.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwReplaceClaims.Columns[0].Width = 270;
            UpdateSecurity();
        }
        private void UpdateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M25.7.1" == sPermissionKey)
                    {
                        btLogistic.Enabled = true;
                    }
                    if ("M25.7.2" == sPermissionKey)
                    {
                        btnReplacement.Enabled = true;
                    }
                    if ("M25.7.3" == sPermissionKey)
                    {
                        btnApproval.Enabled = true;
                    }
                    if ("M25.7.4" == sPermissionKey)
                    {
                        btnDelivered.Enabled = true;
                    }
                    if ("M25.7.5" == sPermissionKey)
                    {
                        btnEditDate.Enabled = true;
                    }
                }
            }
        }
        private void addRowToListview(DMSReplaceClaim oDMSReplaceClaim)
        {
            var oDMSReplaceClaimsInner = new DMSReplaceClaims();
            var ListStatus = oDMSReplaceClaimsInner.RefreshToStatus(oDMSReplaceClaim.ReplaceClaimID);
            ListViewItem oItem = lvwReplaceClaims.Items.Add(oDMSReplaceClaim.RegionName.ToString());
            oItem.SubItems.Add(oDMSReplaceClaim.AreaName.ToString());
            oItem.SubItems.Add(oDMSReplaceClaim.TerritoryName.ToString());
            // oItem.SubItems.Add(oDMSReplaceClaim.CustomerID.ToString());
            oItem.SubItems.Add(oDMSReplaceClaim.CustomerCode);
            oItem.SubItems.Add(oDMSReplaceClaim.CustomerName);
            oItem.SubItems.Add(oDMSReplaceClaim.ReplaceClaimNo.ToString());
            //oItem.SubItems.Add(oDMSReplaceClaim.ReplaceClaimID.ToString());
            oItem.SubItems.Add(oDMSReplaceClaim.ClaimedForMonth.ToString("MMM-yyyy"));
            oItem.SubItems.Add(oDMSReplaceClaim.EntryDate.ToString("dd-MMM-yyyy"));
            if (oDMSReplaceClaim.IsApproved)
            {
                oItem.SubItems.Add("Yes");
            }
            else
            {
                oItem.SubItems.Add("No");
            }

            oItem.SubItems.Add(oDMSReplaceClaim.ClaimAmount.ToString());
            if (oDMSReplaceClaim.LogisticRecDate != default(DateTime))
                oItem.SubItems.Add(oDMSReplaceClaim.LogisticRecDate.ToString("dd-MMM-yyyy"));
            else
                oItem.SubItems.Add("-");
            if (oDMSReplaceClaim.ReplacementRecDate != default(DateTime))
                oItem.SubItems.Add(oDMSReplaceClaim.ReplacementRecDate.ToString("dd-MMM-yyyy"));
            else
                oItem.SubItems.Add("-");
            if (oDMSReplaceClaim.ApprovalDate != default(DateTime))
                oItem.SubItems.Add(oDMSReplaceClaim.ApprovalDate.ToString("dd-MMM-yyyy"));
            else
                oItem.SubItems.Add("-");
            if (oDMSReplaceClaim.DeliveryDate != default(DateTime))
                oItem.SubItems.Add(oDMSReplaceClaim.DeliveryDate.ToString("dd-MMM-yyyy"));
            else
                oItem.SubItems.Add("-");
            //oItem.SubItems.Add(oDMSReplaceClaim.SubClaimNumber);

            //oItem.SubItems.Add(oDMSReplaceClaim.CustomerCode);
            //oItem.SubItems.Add(oDMSReplaceClaim.CustomerName);
            //oItem.SubItems.Add(oDMSReplaceClaim.Status.ToString());
            //oItem.SubItems.Add(oDMSReplaceClaim.ClaimDate.ToString("MMM-yyyy"));
            if (ListStatus.Count() > 0)
            {
                //if (oDMSReplaceClaim.DeliveryDate < Convert.ToDateTime("01-Jan-2000"))
                //{
                //    oItem.SubItems.Add("Not Applicable");
                //}
                //else oItem.SubItems.Add(oDMSReplaceClaim.DeliveryDate.ToString("dd-MMM-yyyy"));

                if (ListStatus[0].DeliveryUserID != 0)
                {
                    //oItem.SubItems.Add("Receive");
                    oItem.BackColor = Color.Cyan;
                }
                else if (ListStatus[0].ApprovedUserID != 0)
                {
                    //oItem.SubItems.Add("Approved");
                    oItem.BackColor = Color.YellowGreen;
                }
                else if (ListStatus[0].ReplacementUserID != 0)
                {
                    //oItem.SubItems.Add("Delivered");
                    oItem.BackColor = Color.LightSalmon;
                    //}
                }
                else if (ListStatus[0].LogisticUserID != 0)
                {
                    //oItem.SubItems.Add("Delivered");
                    oItem.BackColor = Color.Plum;
                    //}
                }

            }


            oItem.Tag = oDMSReplaceClaim;
        }
        private void DataLoadControl()
        {
            oDMSReplaceClaims = new DMSReplaceClaims();
            //DMSReplaceClaimItems oDMSReplaceClaimItems = new DMSReplaceClaimItems();
            lvwReplaceClaims.Items.Clear();

            //DBController.Instance.OpenNewConnection();
            DBController.Instance.CheckConnection();

            var list = new List<DMSReplaceClaim>();

            if (string.IsNullOrWhiteSpace(ctlCustomer1.txtCode.Text.ToString()))

            {
                list = oDMSReplaceClaims.RefreshReplacementMonitoring(-1, dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1));

            }
            else
                list = oDMSReplaceClaims.RefreshReplacementMonitoring(ctlCustomer1.SelectedCustomer.CustomerID, dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1));


            if (string.IsNullOrWhiteSpace(txtTokenNo.Text) && cmbStatus.SelectedIndex == 0)
            {
                foreach (DMSReplaceClaim oDMSReplaceClaim in list)
                {
                    addRowToListview(oDMSReplaceClaim);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtTokenNo.Text))
                {
                    int tokenNo;
                    try
                    {
                        tokenNo = Int32.Parse(txtTokenNo.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Token No is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var oDMSReplaceClaim = list.FirstOrDefault(rp => rp.ReplaceClaimNo == tokenNo.ToString());
                    if (oDMSReplaceClaim == null)
                    {
                        MessageBox.Show("Token No is not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    addRowToListview(oDMSReplaceClaim);
                }
                else if(cmbStatus.SelectedIndex != 0)
                {
                    foreach (DMSReplaceClaim oDMSReplaceClaim in list)
                    {
                        if((int)cmbStatus.SelectedValue == (int)status.LogisticRecieved)
                        {
                            if(oDMSReplaceClaim.LogisticRecDate != default(DateTime) && oDMSReplaceClaim.ReplacementRecDate == default(DateTime))
                            {
                                addRowToListview(oDMSReplaceClaim);
                            }
                        }
                        if((int)cmbStatus.SelectedValue == (int)status.SentToReplacement)
                        {
                            if (oDMSReplaceClaim.ReplacementRecDate != default(DateTime) && oDMSReplaceClaim.ApprovalDate == default(DateTime))
                            {
                                addRowToListview(oDMSReplaceClaim);
                            }
                        }
                        if ((int)cmbStatus.SelectedValue == (int)status.Approved)
                        {
                            if (oDMSReplaceClaim.ApprovalDate != default(DateTime) && oDMSReplaceClaim.DeliveryDate == default(DateTime))
                            {
                                addRowToListview(oDMSReplaceClaim);
                            }
                        }
                        if ((int)cmbStatus.SelectedValue == (int)status.Delivered)
                        {
                            if (oDMSReplaceClaim.DeliveryDate != default(DateTime))
                            {
                                addRowToListview(oDMSReplaceClaim);
                            }
                        }

                    }
                }
              }
            //if(list.Count>0)
            //    lvwReplaceClaims.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //else
            //    lvwReplaceClaims.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            pnlDate.Hide();
            DataLoadControl();
        }

        private void btLogistic_Click(object sender, EventArgs e)
        {
            DMSReplaceClaim _oDMSReplaceClaim = (DMSReplaceClaim)lvwReplaceClaims.SelectedItems[0].Tag;
            DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
            pnlDate.Hide();
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!_oDMSReplaceClaim.IsApproved)
            {
                MessageBox.Show("Not confirmed by ZI/ZSM yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            oDMSReplaceClaim = oDMSReplaceClaim.getStatusByReplaceClaimID(_oDMSReplaceClaim.ReplaceClaimID);
            if (oDMSReplaceClaim == null)
            {

                _oDMSReplaceClaim.ClaimMonth = _oDMSReplaceClaim.ClaimedForMonth;
                _oDMSReplaceClaim.Amount = _oDMSReplaceClaim.ClaimAmount;
                _oDMSReplaceClaim.EligibleAmount = 0;
                _oDMSReplaceClaim.LogisticRecDate = DateTime.Now;
                _oDMSReplaceClaim.LogisticUserID = Utility.UserId;
                _oDMSReplaceClaim.ReplacementRecDate = default(DateTime);
                _oDMSReplaceClaim.ReplacementUserID = 0;
                _oDMSReplaceClaim.ApprovalDate = default(DateTime);
                _oDMSReplaceClaim.ApprovedUserID = 0;
                _oDMSReplaceClaim.DeliveryDate = default(DateTime);
                _oDMSReplaceClaim.DeliveryUserID = 0;
                _oDMSReplaceClaim.AddToStatus();
                MessageBox.Show("Saved Successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This Operation Has Already Been Done", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataLoadControl();
        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            DMSReplaceClaim _oDMSReplaceClaim = (DMSReplaceClaim)lvwReplaceClaims.SelectedItems[0].Tag;
            DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
            pnlDate.Hide();
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_oDMSReplaceClaim.IsApproved)
            {
                MessageBox.Show("Not confirmed by ZI/ZSM yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDMSReplaceClaim = oDMSReplaceClaim.getStatusByReplaceClaimID(_oDMSReplaceClaim.ReplaceClaimID);
            if (oDMSReplaceClaim != null && oDMSReplaceClaim.LogisticUserID !=0 && oDMSReplaceClaim.ReplacementUserID == 0 && oDMSReplaceClaim.ApprovedUserID == 0 && oDMSReplaceClaim.DeliveryUserID == 0)
            {
                oDMSReplaceClaim.ReplacementRecDate = DateTime.Now;
                oDMSReplaceClaim.ReplacementUserID = Utility.UserId;
                oDMSReplaceClaim.ApprovalDate = default(DateTime);
                oDMSReplaceClaim.ApprovedUserID = 0;
                oDMSReplaceClaim.DeliveryDate = default(DateTime);
                oDMSReplaceClaim.DeliveryUserID = 0;
                oDMSReplaceClaim.EditToStatus();
                MessageBox.Show("Saved Successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if(oDMSReplaceClaim != null && oDMSReplaceClaim.LogisticUserID != 0 && oDMSReplaceClaim.ReplacementUserID != 0)
            {
                MessageBox.Show("This Operation Has Already Been Done", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Is Not Recieved By Logistics Yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataLoadControl();
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            DMSReplaceClaim _oDMSReplaceClaim = (DMSReplaceClaim)lvwReplaceClaims.SelectedItems[0].Tag;
            DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
            pnlDate.Hide();
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_oDMSReplaceClaim.IsApproved)
            {
                MessageBox.Show("Not confirmed by ZI/ZSM yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDMSReplaceClaim = oDMSReplaceClaim.getStatusByReplaceClaimID(_oDMSReplaceClaim.ReplaceClaimID);
            if (oDMSReplaceClaim != null && oDMSReplaceClaim.LogisticUserID != 0 && oDMSReplaceClaim.ReplacementUserID != 0 && oDMSReplaceClaim.ApprovedUserID == 0 && oDMSReplaceClaim.DeliveryUserID == 0)
            {
                oDMSReplaceClaim.ApprovalDate = DateTime.Now;
                oDMSReplaceClaim.ApprovedUserID = Utility.UserId;
                oDMSReplaceClaim.DeliveryDate = default(DateTime);
                oDMSReplaceClaim.DeliveryUserID = 0;
                oDMSReplaceClaim.EditToStatus();
                MessageBox.Show("Saved Successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (oDMSReplaceClaim != null && oDMSReplaceClaim.LogisticUserID != 0 && oDMSReplaceClaim.ReplacementUserID != 0 && oDMSReplaceClaim.ApprovedUserID != 0)
            {
                MessageBox.Show("This Operation Has Already Been Done", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Is Not Sent For Replacement Yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataLoadControl();
        }

        private void btnDelivered_Click(object sender, EventArgs e)
        {
            DMSReplaceClaim _oDMSReplaceClaim = (DMSReplaceClaim)lvwReplaceClaims.SelectedItems[0].Tag;
            DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
            pnlDate.Hide();
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_oDMSReplaceClaim.IsApproved)
            {
                MessageBox.Show("Not confirmed by ZI/ZSM yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDMSReplaceClaim = oDMSReplaceClaim.getStatusByReplaceClaimID(_oDMSReplaceClaim.ReplaceClaimID);
            if (oDMSReplaceClaim != null && oDMSReplaceClaim.LogisticUserID != 0 && oDMSReplaceClaim.ReplacementUserID != 0 && oDMSReplaceClaim.ApprovedUserID != 0 && oDMSReplaceClaim.DeliveryUserID == 0)
            {
                oDMSReplaceClaim.DeliveryDate = DateTime.Now;
                oDMSReplaceClaim.DeliveryUserID = Utility.UserId;
                oDMSReplaceClaim.EditToStatus();
                MessageBox.Show("Saved Successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (oDMSReplaceClaim != null && oDMSReplaceClaim.LogisticUserID != 0 && oDMSReplaceClaim.ReplacementUserID != 0 && oDMSReplaceClaim.ApprovedUserID != 0 && oDMSReplaceClaim.DeliveryUserID != 0)
            {
                MessageBox.Show("This Operation Has Already Been Done", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Is Not Approved Yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataLoadControl();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pnlDate.Hide();
            //if (lvwReplaceClaims.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select an ReplaceClaim Id to Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            //DMSReplaceClaim oDMSReplaceClaim = (DMSReplaceClaim)lvwReplaceClaims.SelectedItems[0].Tag;
            //int nReplaceClaimID = oDMSReplaceClaimItem.ReplaceClaimID;
            //string sSubClaimNumber = oDMSReplaceClaimItem.SubClaimNumber;
            DBController.Instance.OpenNewConnection();

            if (string.IsNullOrWhiteSpace(ctlCustomer1.txtCode.Text.ToString()))

            {
                oDMSReplaceClaims.MakeReport(-1, dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1));

            }
            else
                oDMSReplaceClaims.MakeReport(ctlCustomer1.SelectedCustomer.CustomerID, dtFromDate.Value.AddDays(-1), dtToDate.Value.AddDays(1));


            //oDMSReplaceClaimItem = new DMSReplaceClaimItem();


            //orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
            //orptReplaceClaimDeliverys.ReplaceClaimDelivery(nReplaceClaimID, sSubClaimNumber);


            rptReplecementMonitoringBLL oReports = new rptReplecementMonitoringBLL();
            oReports.SetDataSource(oDMSReplaceClaims);
            oReports.SetParameterValue("FromDate", dtFromDate.Value.ToShortDateString());
            oReports.SetParameterValue("ToDate", dtToDate.Value.ToShortDateString());


            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReports);
            DBController.Instance.CloseConnection();
        }
        private void btnSKUrpt_Click(object sender, EventArgs e)
        {
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pnlDate.Hide();
            DBController.Instance.OpenNewConnection();
            DMSReplaceClaim _oDMSReplaceClaim = (DMSReplaceClaim)lvwReplaceClaims.SelectedItems[0].Tag;
            oDMSReplaceClaims.SKUWiseReport(_oDMSReplaceClaim.ReplaceClaimID, _oDMSReplaceClaim.ClaimedForMonth);

            rptTokenWiseProductList oReports = new rptTokenWiseProductList();
            oReports.SetDataSource(oDMSReplaceClaims);
            oReports.SetParameterValue("UserName", Utility.Username);


            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReports);
            DBController.Instance.CloseConnection();

        }

        private void btnEditDate_Click(object sender, EventArgs e)
        {
            if (lvwReplaceClaims.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DMSReplaceClaim _oDMSReplaceClaim = (DMSReplaceClaim)lvwReplaceClaims.SelectedItems[0].Tag;
            if(_oDMSReplaceClaim.LogisticRecDate == default(DateTime))
            {
                dateTimePicker1.Value = _oDMSReplaceClaim.ClaimedForMonth;
                pnlDate.Show();
            }
            else
            {
                MessageBox.Show("Not Applicable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void lvwReplaceClaims_Click(object sender, EventArgs e)
        {
            pnlDate.Hide();
        }

        private void frmReplacementMonitoring_Click(object sender, EventArgs e)
        {
            pnlDate.Hide();
        }

        private void lvwReplaceClaims_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDate.Hide();
        }

        private void btnSaveDate_Click(object sender, EventArgs e)
        {
            DMSReplaceClaim _oDMSReplaceClaim = (DMSReplaceClaim)lvwReplaceClaims.SelectedItems[0].Tag;
            DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
            string date = dateTimePicker1.Text;
            date = "01-" + date;
            dateTimePicker1.Value = DateTime.Parse(date); 
            if (dateTimePicker1.Value>DateTime.Now)
            {
                MessageBox.Show("Date can not be taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(DateTime.Now.Year == dateTimePicker1.Value.Year)
            {
                if ((DateTime.Now.Month - dateTimePicker1.Value.Month) > 2)
                {
                    MessageBox.Show("Date can not be taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if((DateTime.Now.Year - dateTimePicker1.Value.Year)>1)
            {
                MessageBox.Show("Date can not be taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int flag = 0;
            if ((DateTime.Now.Year - dateTimePicker1.Value.Year) == 1)
            {
                if(DateTime.Now.Month == 1)
                {
                    if((DateTime.Now.Month - dateTimePicker1.Value.Month) == -11 || (DateTime.Now.Month - dateTimePicker1.Value.Month) == -10)
                    {
                        flag = 1;
                    }
                }
                else if (DateTime.Now.Month == 2)
                {
                    if ((DateTime.Now.Month - dateTimePicker1.Value.Month) == -10 || (DateTime.Now.Month - dateTimePicker1.Value.Month) == 1)
                    {
                        flag = 1;
                    }
                }
                if(flag == 0)
                {
                    MessageBox.Show("Date can not be taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            oDMSReplaceClaim.ClaimedForMonth = DateTime.Parse(date);
            oDMSReplaceClaim.ReplaceClaimID = _oDMSReplaceClaim.ReplaceClaimID;
            try
            {
                oDMSReplaceClaim.editDate();
                MessageBox.Show("Date has edited successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGetData.PerformClick();
                return;
            }
            int index = lvwReplaceClaims.SelectedItems[0].Index;
            btnGetData.PerformClick();
            lvwReplaceClaims.SelectedItems.Clear();
            lvwReplaceClaims.Items[index].Selected = true;
            pnlDate.Hide();
        }

        private void txtTokenNo_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtTokenNo.Text))
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTokenNo.Text = "";
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }

}
