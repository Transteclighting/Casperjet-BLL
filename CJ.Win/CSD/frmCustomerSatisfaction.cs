using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmCustomerSatisfaction : Form
    {
        public bool _bActivity = false;
        CSDCustomerSatisfaction _oCSDCustomerSatisfaction;
        int nJobID = 0;
        int nServiceType = 0;
        int nJobType = 0;
        string sJobNo = "";
        CSDSMS _oCSDSMS;
        CSDJob _oCSDJob;
        Communication _oCommunication;
         

        public frmCustomerSatisfaction()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDCustomerSatisfaction oCSDCustomerSatisfaction)
        {
            this.Tag = oCSDCustomerSatisfaction;
            DBController.Instance.OpenNewConnection();
            nJobID = oCSDCustomerSatisfaction.JobID;
            nServiceType = oCSDCustomerSatisfaction.ServiceType;
            nJobType = oCSDCustomerSatisfaction.JobType;
            sJobNo = oCSDCustomerSatisfaction.JobNo;

            txtJobNo.Text = oCSDCustomerSatisfaction.JobNo;
            lblJobCreationDate.Text = Convert.ToDateTime(oCSDCustomerSatisfaction.JobCreationDate).ToString("dd-MMM-yyyy");
            lblDeliveryDate.Text = Convert.ToDateTime(oCSDCustomerSatisfaction.DeliveryDate).ToString("dd-MMM-yyyy");
            lblJobType.Text = oCSDCustomerSatisfaction.JobTypeName;
            lblServiceType.Text = oCSDCustomerSatisfaction.ServiceTypeName;

            lblCustomerName.Text = oCSDCustomerSatisfaction.CustomerName;
            lblCustAddress.Text = oCSDCustomerSatisfaction.Address;
            lblPhonehome.Text = oCSDCustomerSatisfaction.PhoneHome;
            txtMobile.Text = oCSDCustomerSatisfaction.Mobile;
            lblPhoneOffice.Text = oCSDCustomerSatisfaction.PhoneOffice;

            lblProductCode.Text = oCSDCustomerSatisfaction.ProductCode;
            lblProductName.Text = oCSDCustomerSatisfaction.ProductName;
            lblAG.Text = oCSDCustomerSatisfaction.AGName;
            lblASG.Text = oCSDCustomerSatisfaction.ASGName;
            lblMAG.Text = oCSDCustomerSatisfaction.MAGName;
            lblPG.Text = oCSDCustomerSatisfaction.PGName;
            lblSerial.Text = oCSDCustomerSatisfaction.SerialNo;
            this.ShowDialog();
        }
        private void frmCustomerSatisfaction_Load(object sender, EventArgs e)
        {
            chkBanForever.Visible = false;
            CSDCustomerSatisfaction _oQuestion = new CSDCustomerSatisfaction();
            _oQuestion.GetQuestions(nServiceType);
            foreach (CSDCustomerSatisfactionDetail oCSDCustomerSatisfactionDetail in _oQuestion)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oCSDCustomerSatisfactionDetail.Questions.ToString();
                oRow.Cells[1].Value = oCSDCustomerSatisfactionDetail.ID.ToString();
                dgvLineItem.Rows.Add(oRow);
            }

            Utilities oCSDMark = new Utilities();
            oCSDMark.CSDMark();
            DataGridViewComboBoxColumn ColumnItem3 = new DataGridViewComboBoxColumn();
            ColumnItem3.DataPropertyName = "Mark";
            ColumnItem3.HeaderText = "Mark";
            ColumnItem3.Width = 120;
            ColumnItem3.DataSource = oCSDMark;
            ColumnItem3.ValueMember = "SatusId";
            ColumnItem3.DisplayMember = "Satus";
            dgvLineItem.Columns.Add(ColumnItem3);

        }

        public bool ValidateUIInput()
        {
            #region Mark
            if (rdoNoResponse.Checked == true || rdoNumbusy.Checked == true || rdoSwitchedOff.Checked == true)
            {

            }
            else
            {
                if (nServiceType == (int)Dictionary.ServiceType.Installation || nServiceType == (int)Dictionary.ServiceType.HomeCall)
                {
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            if (oItemRow.Cells[2].Value == null)
                            {
                                MessageBox.Show("Please Input Mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
            }
            #endregion

            return true;
        }
        public CSDCustomerSatisfaction GetUIData(CSDCustomerSatisfaction _oCSDCustomerSatisfaction)
        {
            _oCSDCustomerSatisfaction.JobID = nJobID;
            _oCSDCustomerSatisfaction.Remarks = txtRemarks.Text;

            if (rdoSatisfy.Checked == true)
            {
                _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.Satisfy;
            }
            else if (rdoDissatisfy.Checked == true)
            {
                _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.Dissatisfy;
            }
            else if (rdoModerate.Checked == true)
            {
                _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.Moderate;
            }
            else if (rdoNumbusy.Checked == true)
            {
                _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.NumBusy;
            }
            else if (rdoSwitchedOff.Checked == true)
            {
                _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.Switched_Off;
            }

            else if (rdoNoResponse.Checked == true)
            {
                //if (chkBanForever.Checked == true)
                //{
                //    _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.BanForever;
                //}
                //else
                //{
                    _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.NoResponse;
                //}

            }
            _oCSDCustomerSatisfaction.CreateUserID = Utility.UserId;
            _oCSDCustomerSatisfaction.CreateDate = DateTime.Now;
            _oCSDCustomerSatisfaction.IsNewJob = (int)Dictionary.YesNAStatus.Yes;


            // Item Details
            if (rdoNoResponse.Checked == true)
            {

            }
            else
            {
                if (nServiceType == (int)Dictionary.ServiceType.Installation || nServiceType == (int)Dictionary.ServiceType.HomeCall || nServiceType == (int)Dictionary.ServiceType.Walkin)
                {
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count)
                        {


                            CSDCustomerSatisfactionDetail _oCSDCustomerSatisfactionDetail = new CSDCustomerSatisfactionDetail();

                            _oCSDCustomerSatisfactionDetail.QuestionID = int.Parse(oItemRow.Cells[1].Value.ToString());
                            try
                            {
                                _oCSDCustomerSatisfactionDetail.Mark = int.Parse(oItemRow.Cells[2].Value.ToString());
                            }
                            catch
                            {
                                _oCSDCustomerSatisfactionDetail.Mark = -1;
                            }

                            _oCSDCustomerSatisfaction.Add(_oCSDCustomerSatisfactionDetail);

                        }
                    }
                }
            }
            return _oCSDCustomerSatisfaction;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();
                    _oCSDSMS = new CSDSMS();
                    _oCSDCustomerSatisfaction = GetUIData(_oCSDCustomerSatisfaction);
                    _oCSDCustomerSatisfaction.RefreshResponse(_oCSDCustomerSatisfaction.JobID);

                    if (_oCSDCustomerSatisfaction.RefreshResponse(_oCSDCustomerSatisfaction.JobID) > 0)
                    {
                        _oCSDCustomerSatisfaction.UpDateUserID = Utility.UserId;
                        _oCSDCustomerSatisfaction.UpdateDate = DateTime.Now;
                        _oCSDCustomerSatisfaction.Edit(_oCSDCustomerSatisfaction.JobID);
                    }
                    else
                    {
                        _oCSDCustomerSatisfaction.Add(nServiceType);
                    }


                    _oCSDJob = new CSDJob();
                    _oCSDJob.JobID = _oCSDCustomerSatisfaction.JobID;
                    _oCSDJob.IsHappyCall = (int)Dictionary.YesOrNoStatus.YES;
                    _oCSDJob.UpdateIsHappyCall();

                    //if (rdoNoResponse.Checked == true || rdoNumbusy.Checked == true || rdoSwitchedOff.Checked == true)
                    //{
                    //    _oCSDJob.IsHappyCall = (int)Dictionary.YesOrNoStatus.NO;
                    //}
                    //else
                    //{

                    //}

                    _oCommunication = new Communication();
                    _oCommunication.CreateDate = DateTime.Now;
                    _oCommunication.CreateUserID = Utility.UserId;
                    _oCommunication.JobID = _oCSDCustomerSatisfaction.JobID;
                    _oCommunication.CallType = (int)Dictionary.CallType.HappyCall;
                    _oCommunication.Remarks = txtRemarks.Text.Trim();
                    _oCommunication.CallCategory = (int)Dictionary.CallCategory.OutBoundCall;                    
                    _oCommunication.Add();
                    //_oCSDSMS.JobIDC = nJobID;
                    //_oCSDSMS.GetCallCentJoblistID();
                    //int nCallCentJobListID = 0;
                    //nCallCentJobListID = _oCSDSMS.CallCentJobListID;

                    //_oCSDSMS.CallType = 2;
                    //if (_oCSDCustomerSatisfaction.Status == (int)Dictionary.CSDHappyCallStatus.Satisfy)
                    //{
                    //    _oCSDSMS.ResponseType = _oCSDCustomerSatisfaction.Status;
                    //}
                    //else
                    //{
                    //    _oCSDSMS.ResponseType = 3;
                    //}
                    //_oCSDSMS.IsAttend = 1;
                    //_oCSDSMS.Remarks = _oCSDCustomerSatisfaction.Remarks;
                    //_oCSDSMS.UpdateCallCenterJobList();
                    //_oCSDSMS.AddCommunicationForCJ();                                 
                    DBController.Instance.CommitTransaction();
                    _bActivity = true;
                    MessageBox.Show("Add Successfull: JobNo # " + sJobNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoNoResponse_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNoResponse.Checked == true)
            {
                chkBanForever.Visible = true;
            }
            else
            {
                chkBanForever.Visible = false;
            }
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}