using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;
using CJ.Report.CSD;
using CJ.Report;
using CJ.Win.CSD;


namespace CJ.Win
{
    public partial class frmReplaces : Form
    {
        
        private int _nStatus;
        Utilities _oUtilitys;

        public ReplaceHistory oReplaceHistory;
        public Product oProduct;


        public frmReplaces()
        {
            InitializeComponent();
        }

        private void frmReplaces_Load(object sender, EventArgs e)
        {

            getReplaceStatus();
            LoadCombos();
            DataLoadControl();
        }
        private void LoadCombos()
        {

            //Paper Location
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ReplacePapersLocation)))
            {
               cmbPaperLocation.Items.Add(Enum.GetName(typeof(Dictionary.ReplacePapersLocation), GetEnum));
            }
            cmbPaperLocation.SelectedIndex = (int)Dictionary.ReplacePapersLocation.ALL;
        }
        private void DataLoadControl()
        {
            Utility oUtility = _oUtilitys[cmbStatus.SelectedIndex];
            //Utility oUtilityy = _oUtilitys[cmbPaperLocation.SelectedIndex];

            _nStatus = oUtility.SatusId;
           
            Replaces oReplaces = new Replaces();

            lvwReplaces.Items.Clear();
            ckbSelect.Checked = false;
            DBController.Instance.OpenNewConnection();
            {
                int nCheckedAll = 0;
                int nPaperLocation = 0;

                if (All.Checked == true)
                {
                    nCheckedAll = -1;
                }
                if (cmbPaperLocation.Text == "ALL")
                {
                    nPaperLocation = -1;
                }
                else
                {
                    nPaperLocation = cmbPaperLocation.SelectedIndex;
                }
                //if (All.Checked == false)
                //{
                  

                 oReplaces.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtReplaceID.Text, txtJobNo.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId, nPaperLocation, txtCustomerName.Text, txtAddress.Text, txtContactNo.Text, nCheckedAll);//txtComplainerName.Text,txtContactNo.Text,
                //else oReplaces.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtReplaceID.Text, txtJobNo.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId, -1, txtCustomerName.Text, txtAddress.Text, txtContactNo.Text);
                //}
                //else
                //{
                //    if (cmbPaperLocation.Text != "ALL")
                 // oReplaces.RefreshAll(txtReplaceID.Text, txtJobNo.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId,  cmbPaperLocation.SelectedIndex, txtCustomerName.Text, txtAddress.Text, txtContactNo.Text);
                //    else oReplaces.RefreshAll(txtReplaceID.Text, txtJobNo.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId, -1, txtCustomerName.Text, txtAddress.Text, txtContactNo.Text);

                //}
            }
            
            //oServiceJobs.btnShow(txtJobNo.Text);
            this.Text = "Total " + "[" + oReplaces.Count + "]";
            foreach (Replace oReplace in oReplaces)
            {
                ListViewItem oItem = lvwReplaces.Items.Add(oReplace.ReplaceID.ToString());
                oItem.SubItems.Add(oReplace.ReplaceJobFromCassandra.JobNo);
                oItem.SubItems.Add(oReplace.ReplaceJobFromCassandra.CustomerName);
                oItem.SubItems.Add(oReplace.ReplaceJobFromCassandra.FirstAddress);
                oItem.SubItems.Add(oReplace.ReplaceJobFromCassandra.Mobile);

                if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.Approve)
                {
                    oItem.SubItems.Add("Approve");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.Cancel)
                {
                    oItem.SubItems.Add("Cancel");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.Delivered)
                {
                    oItem.SubItems.Add("Delivered");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.DepositToLog)
                {
                    oItem.SubItems.Add("DepositToLog");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.HappyCall)
                {
                    oItem.SubItems.Add("HappyCall");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.InformToCustomer)
                {
                    oItem.SubItems.Add("InformToCustomer");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.IssueFromLog)
                {
                    oItem.SubItems.Add("IssueFromLog");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.Raise)
                {
                    oItem.SubItems.Add("Raise");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.PaperAcknowledge)
                {
                    oItem.SubItems.Add("PaperAcknowledge");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.ReceiveAtCSD)
                {
                    oItem.SubItems.Add("ReceiveAtCSD");
                }
                else if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.SentToCSD)
                {
                    oItem.SubItems.Add("SentToCSD");
                }


                    if (oReplace.PapersLocation == (int)Dictionary.ReplacePapersLocation.Logistics)
                    {
                        oItem.SubItems.Add("Logistics");
                    }
                    else if (oReplace.PapersLocation == (int)Dictionary.ReplacePapersLocation.Workshop)
                    {
                        oItem.SubItems.Add("Workshop");
                    }
                    else if (oReplace.PapersLocation == (int)Dictionary.ReplacePapersLocation.ReceiveAtCSD)
                    {
                        oItem.SubItems.Add("ReceiveAtCSD");
                    }
                    else if (oReplace.PapersLocation == (int)Dictionary.ReplacePapersLocation.SendToCSD)
                    {
                        oItem.SubItems.Add("SendToCSD");
                    }


                //else 
                //{
                //    oItem.SubItems.Add("Workshop");
                //}

                //oItem.SubItems.Add(oComplain.User.Username.ToString());
                oItem.Tag = oReplace;
            }
            setListViewRowColour();
        }
       
        private void getReplaceStatus()
        {
            _oUtilitys = new Utilities();
            cmbStatus.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oUtilitys.GetReplaceStatus();
            foreach (Utility oUtility in _oUtilitys)
            {
                cmbStatus.Items.Add(oUtility.Satus);
            }
            cmbStatus.SelectedIndex = cmbStatus.Items.Count - 1;
        }
        //private void GetReplacePapersLocation()
        //{
        //    _oUtilitys = new Utilities();
        //    cmbPaperLocation.Items.Clear();
        //    DBController.Instance.OpenNewConnection();
        //    _oUtilitys.GetReplacePapersLocation();
        //    foreach (Utility oUtility in _oUtilitys)
        //    {
        //        cmbPaperLocation.Items.Add(oUtility.Satus);
        //    }
        //    cmbPaperLocation.SelectedIndex = cmbPaperLocation.Items.Count - 1;
        //}

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmReplaceRaise oForm = new frmReplaceRaise();
            oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            oForm.MaximizeBox = false;
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];
                    if (lvwReplaces.Items[i].Checked == true)
                    {
                        Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                        if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.Raise)
                        {
                            oReplace.ApproveReplace();
                            {
                                oReplaceHistory = new ReplaceHistory();
                                oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Approve;
                                oReplaceHistory.Remarks = "";
                                oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                                oReplaceHistory.AddReplaceHistory();
                            }
                        }

                    }
                }
                MessageBox.Show("Update Successfully ", "Approve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataLoadControl();
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];
                    if (lvwReplaces.Items[i].Checked == true)
                    {
                        Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                        if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.Approve||oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.InformToCustomer)
                        {
                            oReplace.DepositReplace();
                            {
                                oReplaceHistory = new ReplaceHistory();
                                oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.DepositToLog;
                                oReplaceHistory.Remarks = "";
                                oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                                oReplaceHistory.AddReplaceHistory();
                            }
                        }

                    }
                }
                MessageBox.Show("Update Successfully ", "Deposit to Logistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                if (lvwReplaces.CheckedItems.Count == 1)
                {
                    for (int i = 0; i < lvwReplaces.Items.Count; i++)
                    {
                        ListViewItem itm = lvwReplaces.Items[i];
                        if (lvwReplaces.Items[i].Checked == true)
                        {
                            Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                            if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.DepositToLog || oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.IssueFromLog)
                            {
                                frmReplaceIssue oForm = new frmReplaceIssue();
                                oForm.ShowDialog(oReplace);
                                DataLoadControl();
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("You have to Checked only one row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSendToCSD_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];
                    if (lvwReplaces.Items[i].Checked == true)
                    {
                        Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                        if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.IssueFromLog)
                        {
                            oReplace.SendToCSDReplace();
                            {
                                oReplaceHistory = new ReplaceHistory();
                                oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.SentToCSD;
                                oReplaceHistory.Remarks = "";
                                oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                                oReplaceHistory.AddReplaceHistory();
                            }
                        }

                    }
                }
                MessageBox.Show("Update Successfully ", "Send to CSD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReceiveAtCSD_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];
                    if (lvwReplaces.Items[i].Checked == true)
                    {
                        Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                        if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.SentToCSD)
                        {
                            oReplace.ReceiveAtCSDReplace();
                            {
                                oReplaceHistory = new ReplaceHistory();
                                oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.ReceiveAtCSD;
                                oReplaceHistory.Remarks = "";
                                oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                                oReplaceHistory.AddReplaceHistory();
                            }
                        }

                    }
                }
                MessageBox.Show("Update Successfully ", "Receive at CSD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInformToCustomer_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                if (lvwReplaces.CheckedItems.Count == 1)
                {
                    for (int i = 0; i < lvwReplaces.Items.Count; i++)
                    {
                        ListViewItem itm = lvwReplaces.Items[i];
                        if (lvwReplaces.Items[i].Checked == true)
                        {
                            Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                            //if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.ReceiveAtCSD)
                            {
                                frmReplaceInform oForm = new frmReplaceInform();
                                oForm.ShowDialog(oReplace);
                                DataLoadControl();
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("You have to Checked only one row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                if (lvwReplaces.CheckedItems.Count == 1)
                {
                    for (int i = 0; i < lvwReplaces.Items.Count; i++)
                    {
                        ListViewItem itm = lvwReplaces.Items[i];
                        if (lvwReplaces.Items[i].Checked == true)
                        {
                            Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                            if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.InformToCustomer||oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.Delivered)
                            {
                                frmReplaceDelivery oForm = new frmReplaceDelivery();
                                oForm.ShowDialog(oReplace);
                                DataLoadControl();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You have to Checked only one row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaperAcknowledge_Click(object sender, EventArgs e)
        {
          if (lvwReplaces.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];
                    if (lvwReplaces.Items[i].Checked == true)
                    {
                        Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                        if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.Delivered)
                        {

                            oReplace.PaperAcknowledgeReplace();
                            {
                                oReplaceHistory = new ReplaceHistory();
                                oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.PaperAcknowledge;
                                oReplaceHistory.Remarks = "";
                                oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                                oReplaceHistory.AddReplaceHistory();

                            }
                        }

                    }
                }
                MessageBox.Show("Update Successfully ", "Receive at CSD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHappyCall_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                if (lvwReplaces.CheckedItems.Count == 1)
                {
                    for (int i = 0; i < lvwReplaces.Items.Count; i++)
                    {
                        ListViewItem itm = lvwReplaces.Items[i];
                        if (lvwReplaces.Items[i].Checked == true)
                        {
                            Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                            if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.PaperAcknowledge)
                            {
                                frmReplaceHappyCall oForm = new frmReplaceHappyCall();
                                oForm.ShowDialog(oReplace);
                                DataLoadControl();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You have to Checked only one row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }
    
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwReplaces.Items.Count; i++)
            {
                ListViewItem itm = lvwReplaces.Items[i];

                lvwReplaces.Items[i].Checked = true;

            }
        }

        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];

                    lvwReplaces.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];

                    lvwReplaces.Items[i].Checked = false;

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setListViewRowColour()
        {
            if (lvwReplaces.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwReplaces.Items)
                {
                    if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.Raise.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.Approve.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.DepositToLog.ToString())
                    {
                        oItem.BackColor = Color.LightSteelBlue;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.IssueFromLog.ToString())
                    {
                        oItem.BackColor = Color.DarkKhaki;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.SentToCSD.ToString())
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.ReceiveAtCSD.ToString())
                    {
                        oItem.BackColor = Color.LightSkyBlue;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.InformToCustomer.ToString())
                    {
                        oItem.BackColor = Color.Khaki;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.Delivered.ToString())
                    {
                        oItem.BackColor = Color.Violet;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.PaperAcknowledge.ToString())
                    {
                        oItem.BackColor = Color.Thistle;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.ReplaceStatusCriteria.HappyCall.ToString())
                    {
                        oItem.BackColor = Color.CadetBlue;
                    }
                    else
                    {
                        oItem.BackColor = Color.DarkGray;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmProductSearch oForm = new frmProductSearch();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
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

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to View/Print Replace History.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Replace oReplace = (Replace)lvwReplaces.SelectedItems[0].Tag;

            frmReplaceHistory oForm = new frmReplaceHistory();
            oForm.ShowDialog(oReplace);
            DataLoadControl();
        }

        private void btnFormPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lvwReplaces.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to print Replace Form.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Replace _oReplace = new Replace();
            Replace oReplace = (Replace)lvwReplaces.SelectedItems[0].Tag;

            rptReplaceRaiseForm oReport = new rptReplaceRaiseForm();
            
            oReport.SetParameterValue("RefNo", oReplace.ReplaceID);
            oReport.SetParameterValue("Name", oReplace.ReplaceJobFromCassandra.CustomerName);
            oReport.SetParameterValue("Address", oReplace.ReplaceJobFromCassandra.FirstAddress);
            //oITRequisition.Employee.ReadDB = true;
            oReport.SetParameterValue("ContactNo", oReplace.ReplaceJobFromCassandra.Mobile);
            oReport.SetParameterValue("JobNo", oReplace.ReplaceJobFromCassandra.JobNo);
            oReport.SetParameterValue("RaiseDate", oReplace.CreateDate.ToString());
            oReport.SetParameterValue("Serial", oReplace.ReplaceJobFromCassandra.SerialNo.ToString());
            oReport.SetParameterValue("PName", oReplace.ReplaceJobFromCassandra.ProductName);
            oReport.SetParameterValue("PCode", oReplace.ReplaceJobFromCassandra.ProductCode);
            oReport.SetParameterValue("CusComplain", oReplace.FaultDescription);
            oReport.SetParameterValue("InvoiceNo", oReplace.InvoiceCashMemo.ToString());
            oReport.SetParameterValue("DOP", oReplace.DateOfPurchase.ToString());
            oReport.SetParameterValue("WarrantyPeriod", oReplace.FullWarrantyPeriod.ToString());
            oReport.SetParameterValue("ActualFault", oReplace.RemarksAcutalFault.ToString());
            oReport.SetParameterValue("Sources", oReplace.Source.ToString());
            oReport.SetParameterValue("SourcesName", oReplace.SourceName.ToString());
            oReport.SetParameterValue("PrintUserName", Utility.Username.ToString());
            oReport.SetParameterValue("REDD", oReplace.EDD1.ToString());
            oReport.SetParameterValue("TSComments", oReplace.SupComments);
            oReport.SetParameterValue("TSMComments", oReplace.TmComments);
            oReport.SetParameterValue("CSMComments", oReplace.CusComments);
            oReport.SetParameterValue("HOSComments", oReplace.HsComments);
            oReport.SetParameterValue("HSComments", oReplace.HOSComments);

            if (_oReplace.RefreshByProductCode(oReplace.ReplaceJobFromCassandra.ProductCode))
            {
                oReport.SetParameterValue("TSQ", _oReplace.SalesQty.ToString());
                oReport.SetParameterValue("TSVCQ", _oReplace.SvrQty.ToString());
                if (_oReplace.SalesQty != 0)
                {
                    double SVCP = (((float)_oReplace.SvrQty * 100) / _oReplace.SalesQty);
                    double SVC = Math.Round(SVCP, 2);
                    oReport.SetParameterValue("SVC%", SVC.ToString() + "%");
                }
                else
                {
                    oReport.SetParameterValue("SVC%", "0%");
                }
                oReport.SetParameterValue("TRQ", _oReplace.RepQty.ToString());
                if (_oReplace.SalesQty != 0)
                {
                    double RP = ((float)_oReplace.RepQty * 100) / _oReplace.SalesQty;
                    double RepP = Math.Round(RP, 2);
                    oReport.SetParameterValue("R%", RepP.ToString() + "%");
                }
                else
                {
                    oReport.SetParameterValue("R%", "0%");
                }

            }
            else
            {
                oReport.SetParameterValue("TSQ", "0");
                oReport.SetParameterValue("TSVCQ", "0");
                oReport.SetParameterValue("SVC%", "0%");
                oReport.SetParameterValue("TRQ", "0");
                oReport.SetParameterValue("R%", "0%");
            }
            this.Cursor = Cursors.Default;

            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(oReport);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (lvwReplaces.SelectedItems.Count != 0)
            {
                Replace oReplace = (Replace)lvwReplaces.SelectedItems[0].Tag;

                //if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                //{
                //    if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.HappyCall)
                //    {
                //        if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Action)
                //        {
                frmReplaceRaise oForm = new frmReplaceRaise();
                
                oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Replace";
                oForm.ShowDialog(oReplace);
                DataLoadControl();
                //            }
                //            else
                //            {
                //                MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                this.Refresh();
                //            }
                //        }
                //        else
                //        {
                //            MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            this.Refresh();
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        this.Refresh();
                //    }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwReplaces_DoubleClick(object sender, EventArgs e)
        {
            if (lvwReplaces.SelectedItems.Count != 0)
            {
                Replace oReplace = (Replace)lvwReplaces.SelectedItems[0].Tag;
                frmReplaceRaise oForm = new frmReplaceRaise();

                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Replace";
                oForm.ShowDialog(oReplace);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void btnPaperSend_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];
                    if (lvwReplaces.Items[i].Checked == true)
                    {
                        Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;

                                oReplace.ReplacePapersSend();
                                DataLoadControl();

                    }
                }
                MessageBox.Show("Papers Send Successfully ", "Send", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataLoadControl();
            }

        }

        private void btnPaperReceive_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwReplaces.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaces.Items[i];
                    if (lvwReplaces.Items[i].Checked == true)
                    {
                        Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;

                                oReplace.ReplacePapersReceive();
                                DataLoadControl();

                    }
                }
                MessageBox.Show("Papers Receive Successfully ", "Send", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataLoadControl();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (lvwReplaces.CheckedItems.Count != 0)
            {
                if (lvwReplaces.CheckedItems.Count == 1)
                {
                    for (int i = 0; i < lvwReplaces.Items.Count; i++)
                    {
                        ListViewItem itm = lvwReplaces.Items[i];
                        if (lvwReplaces.Items[i].Checked == true)
                        {
                            Replace oReplace = (Replace)lvwReplaces.Items[i].Tag;
                            //if (oReplace.Status == (int)Dictionary.ReplaceStatusCriteria.DepositToLog)
                            {
                                frmReplaceCancel oForm = new frmReplaceCancel();
                                oForm.ShowDialog(oReplace);
                                DataLoadControl();
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("You have to Checked only one row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Checked a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAcknowledge_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lvwReplaces.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to print Replace Form.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Replace oReplace = (Replace)lvwReplaces.SelectedItems[0].Tag;

            rptReplacedProductAcknowledgement oReport = new rptReplacedProductAcknowledgement();

            oReport.SetParameterValue("RepID", oReplace.ReplaceID);
            oReport.SetParameterValue("Name", oReplace.ReplaceJobFromCassandra.CustomerName);
            oReport.SetParameterValue("Address", oReplace.ReplaceJobFromCassandra.FirstAddress);
            //oITRequisition.Employee.ReadDB = true;
            oReport.SetParameterValue("ContactNo", oReplace.ReplaceJobFromCassandra.Mobile);
            oReport.SetParameterValue("JobNo", oReplace.ReplaceJobFromCassandra.JobNo);
            //oReport.SetParameterValue("RaiseDate", oReplace.CreateDate.ToString());
            oReport.SetParameterValue("Serial", oReplace.ReplaceJobFromCassandra.SerialNo.ToString());
            oReport.SetParameterValue("PNamee", oReplace.ReplaceJobFromCassandra.ProductName);
            oReport.SetParameterValue("PCodee", oReplace.ReplaceJobFromCassandra.ProductCode);
            //oReport.SetParameterValue("CusComplain", oReplace.FaultDescription);
            oReport.SetParameterValue("InvoiceNo", oReplace.InvoiceCashMemo.ToString());
            oReport.SetParameterValue("DOP", oReplace.DateOfPurchase.ToString());

            oReport.SetParameterValue("PC", oReplace.Product.ProductCode);
            oReport.SetParameterValue("PN", oReplace.Product.ProductName);

            //oReport.SetParameterValue("PC", oReplace.Product.ProductCode.ToString());
            //oReport.SetParameterValue("PN", oReplace.Product.ProductName.ToString());
            oReport.SetParameterValue("RPBarcode", oReplace.IssueProductBarcode.ToString());
            //oReport.SetParameterValue("WarrantyPeriod", oReplace.FullWarrantyPeriod.ToString());
            //oReport.SetParameterValue("ActualFault", oReplace.RemarksAcutalFault.ToString());
            //oReport.SetParameterValue("Sources", oReplace.Source.ToString());
            //oReport.SetParameterValue("SourcesName", oReplace.SourceName.ToString());
            oReport.SetParameterValue("PrintUserName", Utility.Username.ToString());
            this.Cursor = Cursors.Default;
            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(oReport);
        }

        private void btnEditComments_Click(object sender, EventArgs e)
        {
            if (lvwReplaces.SelectedItems.Count != 0)
            {
                Replace oReplace = (Replace)lvwReplaces.SelectedItems[0].Tag;
                frmEditComments oForm = new frmEditComments();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oReplace);
                //oForm.Show();
            }
            else
            {
                MessageBox.Show("Select a Row First!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }


    }

}