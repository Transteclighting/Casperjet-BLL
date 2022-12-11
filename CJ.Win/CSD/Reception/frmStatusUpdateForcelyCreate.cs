using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmStatusUpdateForcelyCreate : Form
    {
        CSDJobStatuss _oCSDJobStatuss;
        JobHistory _oJobHistory;
        ProductChallan _oProductChallan;
        ProductChallanItem _oProductChallanItem;
        CSDJob _oCSDJob;

        public bool _bIsAnyActivityDone = false;
        public frmStatusUpdateForcelyCreate()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDJob oCSDJob)
        {
            txtJobNo.Text = oCSDJob.JobNo;
            txtProductName.Text = oCSDJob.ProductName;
            txtCustomerName.Text = oCSDJob.CustomerName;
            txtCustomerAddress.Text = oCSDJob.CustomerAddress;
            txtMobileNo.Text = oCSDJob.MobileNo;

            this.Tag = oCSDJob;
            this.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRemarks.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Remarks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are You Sure to Update Status?", "Update Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    Update();
                    this.Close();
                }

            }
        }
        private void Update()
        {
            CSDJob oCSDJob = (CSDJob)this.Tag;
            try
            {
                _oJobHistory = new JobHistory();
                _oJobHistory.JobID = oCSDJob.JobID;
                _oJobHistory.StatusID = _oCSDJobStatuss[cmbJobStatus.SelectedIndex].StatusID;
                _oJobHistory.CreateUserID = Utility.UserId;
                _oJobHistory.CreateDate = DateTime.Now;
                _oJobHistory.ServiceType = oCSDJob.ServiceType;
                _oJobHistory.Remarks = "[Forcely Update Status] " + txtRemarks.Text.Trim();
                _oJobHistory.SubStatusID = oCSDJob.SubStatus;

                oCSDJob.UpdateDate = DateTime.Now;
                oCSDJob.UpdateUserID = Utility.UserId;
                oCSDJob.Status = _oJobHistory.StatusID;
                oCSDJob.DeliveryDate = null;
                //oCSDJob.Status = _oCSDJobStatuss[cmbJobStatus.SelectedIndex].StatusID;
                DBController.Instance.BeginNewTransaction();
                oCSDJob.UpdateJobStatus();
                oCSDJob.IsDelivered = (int)Dictionary.YesOrNoStatus.NO;
                oCSDJob.UpdateDeliveryStatus();
                _oJobHistory.Add(oCSDJob.SubStatus);

                oCSDJob.ProductMovementStatus = (int)Enum.Parse(typeof(Dictionary.ProductMovementStatus), cmbProductMovementStatus.Text);
                oCSDJob.ProductLocation = (int)Enum.Parse(typeof(Dictionary.ProductLocation), cmbProductLocation.Text);
                oCSDJob.UpdateProductMovement();
                oCSDJob.ProductPhysicalLocation = (int)Enum.Parse(typeof(Dictionary.ProductPhysicalLocation), cmbProductPhysicalLocation.Text);
                oCSDJob.UpdateProductPhysicalLocation();
                //AddChallan();
                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _bIsAnyActivityDone = true;
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private void frmStatusUpdateForcelyCreate_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            
            CSDJob oCSDJob = (CSDJob)this.Tag;
            //if (oCSDJob.Status != 17 && oCSDJob.Status != 27 && oCSDJob.Status != 20
            //    && oCSDJob.Status != 21 && oCSDJob.Status != 22 && oCSDJob.Status != 23
            //    && oCSDJob.Status != 24 && oCSDJob.Status != 25 
            //    )
            //{
            //    cmbJobStatus.SelectedIndex = _oCSDJobStatuss.GetIndex(oCSDJob.Status);
            //}
            //else
            //{
                
            //}

            //Product Location
            cmbProductLocation.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductLocation)))
            {
                cmbProductLocation.Items.Add(Enum.GetName(typeof(Dictionary.ProductLocation), GetEnum));
            }
            cmbProductLocation.SelectedIndex = oCSDJob.ProductLocation - 1;

            //Product Physical Location
            cmbProductPhysicalLocation.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductPhysicalLocation)))
            {
                cmbProductPhysicalLocation.Items.Add(Enum.GetName(typeof(Dictionary.ProductPhysicalLocation), GetEnum));
            }
            cmbProductPhysicalLocation.SelectedIndex = oCSDJob.ProductPhysicalLocation - 1;


            //Product Movement Status
            cmbProductMovementStatus.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductMovementStatus)))
            {
                cmbProductMovementStatus.Items.Add(Enum.GetName(typeof(Dictionary.ProductMovementStatus), GetEnum));
            }
            if (oCSDJob.ProductMovementStatus != (int)Dictionary.ProductMovementStatus.None)
            {
                cmbProductMovementStatus.SelectedIndex = oCSDJob.ProductMovementStatus;
            }
            else
            {
                cmbProductMovementStatus.SelectedIndex = 5;
            }

            _oCSDJobStatuss = new CSDJobStatuss();
            _oCSDJobStatuss.Refresh();
            cmbJobStatus.Items.Clear();
            foreach (CSDJobStatus oCSDJobStatus in _oCSDJobStatuss)
            {
                cmbJobStatus.Items.Add(oCSDJobStatus.StatusName);
            }
            cmbJobStatus.SelectedIndex = 0;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbJobStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            CSDJob oCSDJob = (CSDJob)this.Tag;
            if (oCSDJob.Status == (int)Dictionary.JobStatus.ReturnFromCustomer)
            {
                cmbProductMovementStatus.Enabled = false;
                cmbProductMovementStatus.SelectedIndex = 5;//cmbProductMovementStatus = None
            }
            else
            {
                cmbProductMovementStatus.Enabled = true;
                if (oCSDJob.ProductMovementStatus == 9)
                {
                    cmbProductMovementStatus.SelectedIndex = 5;//cmbProductMovementStatus = None
                }
                else
                {
                    cmbProductMovementStatus.SelectedIndex = oCSDJob.ProductMovementStatus;
                }
            }
            //    || _oCSDJobStatuss[cmbJobStatus.SelectedIndex].StatusID 
            //    == (int)Dictionary.JobStatus.Delivered)
            //{
            //    cmbProductMovementStatus.Enabled = false;
            //    cmbProductMovementStatus.SelectedIndex = 5;
            //}
        }

        //private void AddChallan()
        //{
        //    _oCSDJob = new CSDJob();
        //    _oProductChallan = new ProductChallan();
        //    _oProductChallan.ChallanCreateFrom = (int)Dictionary.ChallanCreateFrom.FrontDesk;
        //    _oProductChallan.Status = _oJobHistory.StatusID;
        //    _oProductChallan.Remarks = "[Forcely Update Status] " + txtRemarks.Text.Trim();
        //    _oProductChallan.CreateUserID = Utility.UserId;
        //    _oProductChallan.CreateDate = DateTime.Now;

        //    _oProductChallanItem = new ProductChallanItem();
        //    _oProductChallanItem.JobID = _oCSDJob.JobID;

        //    int nStatus= _oCSDJobStatuss[cmbJobStatus.SelectedIndex].StatusID;
        //    if (nStatus == (int)Dictionary.JobStatus.ReturnFromCustomer && cmbProductLocation.Text == "Send_to_Workshop" &&
        //        cmbProductMovementStatus.Text == "Send_to_Workshop" && cmbProductPhysicalLocation.Text == "CentralService")
        //    {
        //        _oProductChallan.Insert();
        //        _oProductChallanItem.Insert(_oProductChallan.ChallanID);
        //    } 
        
        //}
    }
}