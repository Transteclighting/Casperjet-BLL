using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmCSDSMSHistoryCreate : Form
    {
        CSDSMSHistory _oCSDSMSHistory;
        CSDSMSModels _oCSDSMSModels;
        public bool _bIsAnyAtivityDone = false;
        public frmCSDSMSHistoryCreate()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDSMSHistory oCSDSMSHistory)
        {
            this.Tag = oCSDSMSHistory;
            btnSend.Text = "Update";
            ctlCSDJob1.Enabled = false;
            ctlCSDJob1.txtCode.Text = oCSDSMSHistory.JobNo;
            txtMessage.Text = oCSDSMSHistory.SMSText;
            txtMobileNo.Text = oCSDSMSHistory.MobileNo;
            if (oCSDSMSHistory.OriginalSMS != null)
            {
                txtOriginalMessage.Text = Convert.ToString(oCSDSMSHistory.OriginalSMS);
            }
            this.ShowDialog();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                Send();
                _bIsAnyAtivityDone = true;
                this.Close();                
            }
        }
        private bool ValidateUIInput()
        {
            if (ctlCSDJob1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Select Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbSMSModel.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select SMS Model", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMessage.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMobileNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Mobile No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void Send()
        {
            try
            {
                _oCSDSMSHistory = new CSDSMSHistory();
                _oCSDSMSHistory.SMSModelID = _oCSDSMSModels[cmbSMSModel.SelectedIndex - 1].ID;
                _oCSDSMSHistory.JobID = ctlCSDJob1.SelectedJob.JobID;
                _oCSDSMSHistory.SMSText = txtMessage.Text;
                _oCSDSMSHistory.MobileNo = txtMobileNo.Text;

                if (this.Tag == null)
                {
                    _oCSDSMSHistory.Status = (int)Dictionary.SMSHistoryStatus.Send;
                    _oCSDSMSHistory.IsAutoCreate = 0;
                    _oCSDSMSHistory.CreateDate = DateTime.Now;
                    _oCSDSMSHistory.CreateUserID = Utility.UserId;
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    _oCSDSMSHistory.Add();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Added CSD SMS History", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CSDSMSHistory oCSDSMSHistory = (CSDSMSHistory)this.Tag;
                    _oCSDSMSHistory.ID = oCSDSMSHistory.ID;
                    _oCSDSMSHistory.UpdateUserID = Utility.UserId;
                    _oCSDSMSHistory.UpdateDate = DateTime.Now;

                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    _oCSDSMSHistory.Edit();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Eidited CSD SMS History", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void ctlCSDJob1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text != string.Empty)
            {
                txtMobileNo.Text = ctlCSDJob1.SelectedJob.MobileNo;
            }
        }
        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            _oCSDSMSModels = new CSDSMSModels();
            _oCSDSMSModels.RefreshForSmsModel();
            cmbSMSModel.Items.Add("--Select SMS Model--");
            foreach (CSDSMSModel oCSDSMSModel in _oCSDSMSModels)
            {
                cmbSMSModel.Items.Add(oCSDSMSModel.Text);
            }
            cmbSMSModel.SelectedIndex = 0;
            if (this.Tag != null)
            {
                CSDSMSHistory oCSDSMSHistory = new CSDSMSHistory();
                oCSDSMSHistory = (CSDSMSHistory)this.Tag;
                cmbSMSModel.SelectedIndex = _oCSDSMSModels.GetIndex(oCSDSMSHistory.SMSModelID)+1;
            }
        }

        private void frmCSDSMSHistoryCreate_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
           lblTextLength.Text=txtMessage.Text.Length.ToString();
           if (txtMessage.Text.Length <= 160)
           {
               lblTextLength.ForeColor = Color.Green;
           }
           else
           {
               lblTextLength.ForeColor = Color.Red;
           }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}