using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Report.CSD;
using CJ.Report;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmProductMovements : Form
    {
        int _nUIControl = 0;
        int nChallanCreateFrom = 0;
        ProductChallans _oProductChallans;
        ProductChallans _oProdChallans;
        JobHistory _oJobHistory;
        bool IsCheck;

        public frmProductMovements(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;

            if (nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Workshop)
            {
                nChallanCreateFrom = (int)Dictionary.ChallanCreateFrom.FrontDesk;
            }
            else if (nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Front)
            {
                nChallanCreateFrom = (int)Dictionary.ChallanCreateFrom.Workshop;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductMovements_Load(object sender, EventArgs e)
        {
            AppearanceControl();
            LoadCombo();
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oProductChallans = new ProductChallans();
            lvwProductMovements.Items.Clear();

            int nStatus = GetComboIndex();


            DBController.Instance.OpenNewConnection();
            {
                _oProductChallans.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck, _nUIControl, nStatus, txtChallanNo.Text.Trim());//
            }
            this.Text = "Total " + "[" + _oProductChallans.Count + "]";
            foreach (ProductChallan oProductChallan in _oProductChallans)
            {
                ListViewItem oItem = lvwProductMovements.Items.Add(oProductChallan.ChallanNo.ToString());
                oItem.SubItems.Add(oProductChallan.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oProductChallan.CountJob.ToString());
                oItem.SubItems.Add(oProductChallan.StatusName);
                oItem.SubItems.Add(oProductChallan.UserFullName);
                oItem.SubItems.Add(oProductChallan.Remarks);

                oItem.Tag = oProductChallan;
            }
            //setListViewRowColour();
        }

        private void AppearanceControl()
        {
            if (_nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Workshop)
            {
                this.Text = "Product Send to Workshop";
                btnAdd.Visible = true;
                btndelete.Visible = true;
                btnEdit.Visible = true;
                btnSend.Visible = true;
                btnReceive.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Front)
            {
                this.Text = "Product Send to Front Desk";
                btnAdd.Visible = true;
                btndelete.Visible = true;
                btnEdit.Visible = true;
                btnSend.Visible = true;
                btnReceive.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Front)
            {
                this.Text = "Product Receive at Front Desk";
                btnAdd.Visible = false;
                btndelete.Visible = false;
                btnEdit.Visible = false;
                btnSend.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Workshop)
            {
                this.Text = "Product Receive at Workshop";
                btnAdd.Visible = false;
                btndelete.Visible = false;
                btnEdit.Visible = false;
                btnSend.Visible = false;
            }
        }

        private void LoadCombo()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");

            if (_nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Workshop)
            {
                cmbStatus.Items.Add("Create");
                cmbStatus.Items.Add("Sent to Workshop");
                cmbStatus.Items.Add("Received at Workshop");
                cmbStatus.SelectedIndex = 0;
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Workshop)
            {
                cmbStatus.Items.Add("Sent to Workshop");
                cmbStatus.Items.Add("Received at Workshop");
                cmbStatus.SelectedIndex = 1;
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Front)
            {
                cmbStatus.Items.Add("Create");
                cmbStatus.Items.Add("Sent to Front Desk");
                cmbStatus.Items.Add("Received at Front Desk");
                cmbStatus.SelectedIndex = 0;
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Front)
            {
                cmbStatus.Items.Add("Sent to Front Desk");
                cmbStatus.Items.Add("Received at Front Desk");
                cmbStatus.SelectedIndex = 1;
            }

        }

        private int GetComboIndex()
        {
            int nIndex = 0;

            if (_nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Workshop)
            {

                if (cmbStatus.SelectedIndex == 1)
                {
                    nIndex = 0;
                }
                else if (cmbStatus.SelectedIndex == 2)
                {
                    nIndex = 1;
                }
                else if (cmbStatus.SelectedIndex == 3)
                {
                    nIndex = 2;
                }
                else
                {
                    nIndex = -1;
                }
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Workshop)
            {

                if (cmbStatus.SelectedIndex == 1)
                {
                    nIndex = 1;
                }
                else if (cmbStatus.SelectedIndex == 2)
                {
                    nIndex = 2;
                }
                else
                {
                    nIndex = -1;
                }
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Front)
            {

                if (cmbStatus.SelectedIndex == 1)
                {
                    nIndex = 0;
                }
                else if (cmbStatus.SelectedIndex == 2)
                {
                    nIndex = 3;
                }
                else if (cmbStatus.SelectedIndex == 3)
                {
                    nIndex = 4;
                }
                else
                {
                    nIndex = -1;
                }
            }
            else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Front)
            {

                if (cmbStatus.SelectedIndex == 1)
                {
                    nIndex = 3;
                }
                else if (cmbStatus.SelectedIndex == 2)
                {
                    nIndex = 4;
                }
                else
                {
                    nIndex = -1;
                }
            }


            return nIndex;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductMovement oForm = new frmProductMovement(nChallanCreateFrom);
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductMovements.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Challan to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductChallan oProductChallan = (ProductChallan)lvwProductMovements.SelectedItems[0].Tag;
            if (oProductChallan.Status == (int)Dictionary.ProductMovementStatus.Create)
            {
                frmProductMovement oForm = new frmProductMovement(nChallanCreateFrom);
                oForm.ShowDialog(oProductChallan);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwProductMovements.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Challan to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductChallan oProductChallan = (ProductChallan)lvwProductMovements.SelectedItems[0].Tag;
            if (oProductChallan.Status != (int)Dictionary.ProductMovementStatus.Create)
            {
                MessageBox.Show("Only Create Challan Status can be deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure to Delete Challan # " + oProductChallan.ChallanNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oProductChallans = new ProductChallans();
                    _oProductChallans.RefreshByChallan(oProductChallan.ChallanID);
                    foreach (ProductChallan oProdChallan in _oProductChallans)
                    {
                        CSDJob oCSDJob = new CSDJob();
                        oCSDJob.JobID = oProdChallan.JobID;
                        if (nChallanCreateFrom == (int)Dictionary.ChallanCreateFrom.FrontDesk)
                        {
                            oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.None;
                            oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_FrontDesk;
                        }
                        else if (nChallanCreateFrom == (int)Dictionary.ChallanCreateFrom.Workshop)
                        {
                            oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Receive_at_Workshop;
                            oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_Workshop;
                        }
                        oCSDJob.UpdateProductMovement();

                    }

                    oProductChallan.Delete();
                    DBController.Instance.CommitTransaction();
                }
                catch
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error Deleting Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                DataLoadControl();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwProductMovements.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Print();
            }
        }
        
        private void Print()
        {
            this.Cursor = Cursors.WaitCursor;

            ProductChallan oProductChallan = (ProductChallan)lvwProductMovements.SelectedItems[0].Tag;
            rptChallan doc = new rptChallan();

            ProductChallans oProductChallansList = new ProductChallans();

            string PCode = "";

            _oProductChallans = new ProductChallans();
            _oProductChallans.GetJobIdByChallanID(oProductChallan.ChallanID);

            //ProductChallan oPC = new ProductChallan();
            //foreach (ProductChallan aProdChallan in _oProdChallans)
            //{
            //    oPC.JobID = aProdChallan.JobID;
            //    oPC.JobNo = aProdChallan.JobNo;
            //    oPC.ProductName = aProdChallan.ProductName;
            //    oPC.CustomerName = aProdChallan.CustomerName;
            //    oPC.Remarks = aProdChallan.Remarks;
            //    oPC.Accessories += aProdChallan.Accessories;
            //}
            //oProductChallansList.Add(oPC);

            List<CsdChallan> aList = new List<CsdChallan>();
            foreach (ProductChallan aPC in _oProductChallans)
            {

                _oProdChallans = new ProductChallans();
                _oProdChallans.GetChallanByJobNChallan(aPC.ChallanID, aPC.JobID);
                
                foreach (ProductChallan aProductChallan in _oProdChallans)
                {
                    var CProdChallan = new CsdChallan
                    {
                        JobID = aProductChallan.JobID,
                        JobNo = aProductChallan.JobNo,
                        CustomerName = aProductChallan.CustomerName,
                        ProductName = aProductChallan.ProductName,
                        Remarks = aProductChallan.Remarks,
                        Accessories = aProductChallan.Accessories 
                        //Accessories = string.Join(",", aProductChallan.Accessories)
                    };
                    aList.Add(CProdChallan);
                }
            }
            
            doc.SetDataSource(aList);
            //doc.SetDataSource(oProductChallansList);

            doc.SetParameterValue("ChallanNo", oProductChallan.ChallanNo);
            doc.SetParameterValue("ChallanDate", oProductChallan.CreateDate.ToShortDateString());
            doc.SetParameterValue("StatusName", oProductChallan.StatusName);
            doc.SetParameterValue("PrintUser", Utility.Username);
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lvwProductMovements.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Challan to Send.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductChallan oProductChallan = (ProductChallan)lvwProductMovements.SelectedItems[0].Tag;
            if (oProductChallan.Status != (int)Dictionary.ProductMovementStatus.Create)
            {
                MessageBox.Show("Only Create Challan Status can be sent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure to send Challan # " + oProductChallan.ChallanNo + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oProductChallans = new ProductChallans();
                    _oProductChallans.RefreshByChallan(oProductChallan.ChallanID);
                    foreach (ProductChallan oProdChallan in _oProductChallans)
                    {
                        CSDJob oCSDJob = new CSDJob();
                        _oJobHistory = new JobHistory();
                        _oJobHistory.JobID = oProdChallan.JobID;
                        _oJobHistory.CreateUserID = Utility.UserId;
                        _oJobHistory.CreateDate = DateTime.Now;
                        _oJobHistory.Remarks = oProdChallan.Remarks;

                        oCSDJob.JobID = oProdChallan.JobID;
                        if (nChallanCreateFrom == (int)Dictionary.ChallanCreateFrom.FrontDesk)
                        {
                            oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Send_to_Workshop;
                            oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.Send_to_Workshop;
                            _oJobHistory.StatusID = (int)Dictionary.JobStatus.SentToWorkshop;
                        }
                        else if (nChallanCreateFrom == (int)Dictionary.ChallanCreateFrom.Workshop)
                        {
                            oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Send_to_Front;
                            oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.Send_to_FrontDesk;
                            _oJobHistory.StatusID = (int)Dictionary.JobStatus.SentToFrontDesk;
                        }
                        oCSDJob.UpdateProductMovement();
                        _oJobHistory.Add(null);

                    }
                    if (nChallanCreateFrom == (int)Dictionary.ChallanCreateFrom.FrontDesk)
                    {
                        oProductChallan.Status = (int)Dictionary.ProductMovementStatus.Send_to_Workshop;
                    }
                    else if (nChallanCreateFrom == (int)Dictionary.ChallanCreateFrom.Workshop)
                    {
                        oProductChallan.Status = (int)Dictionary.ProductMovementStatus.Send_to_Front;
                    }
                    oProductChallan.UpdateStatus();
                    DBController.Instance.CommitTransaction();
                }
                catch
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error Sending Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                DataLoadControl();
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (lvwProductMovements.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Challan to Receive", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductChallan oProductChallan = (ProductChallan)lvwProductMovements.SelectedItems[0].Tag;
            if (oProductChallan.Status != (int)Dictionary.ProductMovementStatus.Send_to_Front && oProductChallan.Status != (int)Dictionary.ProductMovementStatus.Send_to_Workshop)
            {
                MessageBox.Show("Only Send Challan Status could be Received", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure to Receive Challan # " + oProductChallan.ChallanNo + " ? ", "Confirm Receive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oProductChallans = new ProductChallans();
                    _oProductChallans.RefreshByChallan(oProductChallan.ChallanID);
                    foreach (ProductChallan oProdChallan in _oProductChallans)
                    {
                        CSDJob oCSDJob = new CSDJob();
                        oCSDJob.JobID = oProdChallan.JobID;

                        _oJobHistory = new JobHistory();
                        _oJobHistory.JobID = oProdChallan.JobID;
                        _oJobHistory.CreateUserID = Utility.UserId;
                        _oJobHistory.CreateDate = DateTime.Now;
                        _oJobHistory.Remarks = oProdChallan.Remarks;


                        if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Workshop)
                        {
                            oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Receive_at_Workshop;
                            _oJobHistory.StatusID = (int)Dictionary.JobStatus.ReceivedAtworkshop;
                            oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_Workshop;
                        }
                        else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Front)
                        {
                            oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Receive_at_Front;
                            _oJobHistory.StatusID = (int)Dictionary.JobStatus.ReceivedAtFrontDesk;
                            oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_FrontDesk;
                        }
                        oCSDJob.UpdateProductMovement();
                        _oJobHistory.Add(null);
                    }

                    if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Workshop)
                    {
                        oProductChallan.Status = (int)Dictionary.ProductMovementStatus.Receive_at_Workshop;
                    }
                    else if (_nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Front)
                    {
                        oProductChallan.Status = (int)Dictionary.ProductMovementStatus.Receive_at_Front;
                    }
                    oProductChallan.UpdateStatus();
                    //DBController.Instance.CommitTransaction();
                    DBController.Instance.CommitTran();//Added By Sajib
                }
                catch
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error Receiving Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                DataLoadControl();
            }
        }
    }
}